﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Catstagram.Server.Features.Search.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static Catstagram.Server.Infrastructure.WebConstants;

namespace Catstagram.Server.Features.Search
{
    public class SearchController : ApiController
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            this._searchService = searchService;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route(QueryRoute)]
        public async Task<IEnumerable<ProfileSearchServiceModel>> Profiles(string query)
        {
            var result = await this._searchService.Profiles(query);

            return result;
        }
    }
}
