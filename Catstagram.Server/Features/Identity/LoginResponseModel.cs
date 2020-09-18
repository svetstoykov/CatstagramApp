namespace Catstagram.Server.Features.Identity
{
    public class LoginResponseModel
    {
        public LoginResponseModel(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}
