namespace Catstagram.Server.Features.Identity.Models
{
    public class TokenResponseModel
    {
        public TokenResponseModel(string token)
        {
            this.Token = token;
        }

        public string Token { get; set; }
    }
}
