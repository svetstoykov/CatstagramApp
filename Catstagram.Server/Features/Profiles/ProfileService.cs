﻿using System.Linq;
using System.Threading.Tasks;
using Catstagram.Server.Data;
using Catstagram.Server.Data.Models;
using Catstagram.Server.Features.Profiles.Models;
using Catstagram.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Catstagram.Server.Features.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly CatstagramDbContext _dbContext;

        public ProfileService(CatstagramDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<ProfileResponseModel> GetUserDetails(string userId)
        {
            var user = await this._dbContext.Users
                .Where(u => u.Id == userId)
                .Select(u => new ProfileResponseModel
                {
                    Name = u.Profile.Name,
                    Biography = u.Profile.Biography,
                    Gender = u.Profile.Gender.ToString(),
                    IsPrivateProfile = u.Profile.IsPrivateProfile,
                    ProfilePhotoUrl = u.Profile.ProfilePhotoUrl,
                    Username = u.UserName,
                    Website = u.Profile.Website
                })
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<Result> UpdateUserDetail(UpdateProfileRequestModel updateModel, string userId)
        {
            var user = await this._dbContext.Users
                .Where(u => u.Id == userId)
                .FirstOrDefaultAsync();

            if (user == null)
            {
                return "User does not exist.";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }

            var result = await UpdateEmail(updateModel, user, userId);
            if (!result.Succeeded)
            {
                return result;
            }

            result = await UpdateUserName(updateModel, user, userId);
            if (!result.Succeeded)
            {
                return result;
            }

            UpdateRemainingProperties(updateModel, user);

            await this._dbContext.SaveChangesAsync();

            return true;
        }

        private static void UpdateRemainingProperties(UpdateProfileRequestModel updateModel, User user)
        {
            foreach (var prop in updateModel.GetType().GetProperties().Skip(2))
            {
                var propValue = prop.GetValue(updateModel);

                if (propValue == null)
                {
                    continue;
                }

                foreach (var userProp in user.Profile.GetType().GetProperties())
                {
                    var userPropValue = userProp.GetValue(user.Profile);

                    if (prop.Name == userProp.Name
                        && propValue != userPropValue)
                    {
                        userProp.SetValue(user.Profile, propValue);
                        break;
                    }
                }
            }
        }

        private async Task<Result> UpdateEmail(UpdateProfileRequestModel updateModel, User user, string userId)
        {
            if (updateModel.Email != user.Email && !string.IsNullOrWhiteSpace(updateModel.Email))
            {
                var isEmailInUse = await this._dbContext.Users
                    .AnyAsync(u => u.Id != userId && u.Email == updateModel.Email);

                if (isEmailInUse)
                {
                    return "The provided email is already taken.";
                }

                user.Email = updateModel.Email;
            }

            return true;
        }

        private async Task<Result> UpdateUserName(UpdateProfileRequestModel updateModel, User user, string userId)
        {
            if (updateModel.UserName == user.UserName && !string.IsNullOrWhiteSpace(updateModel.Email))
            {
                var isUsernameInUse = await this._dbContext.Users
                    .AnyAsync(u => u.Id != userId && u.UserName == updateModel.UserName);

                if (isUsernameInUse)
                {
                    return "The provided username is already taken.";
                }

                user.UserName = updateModel.UserName;
            }

            return true;
        }
    }
}
