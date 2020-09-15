using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catstagram.Server.Controllers
{
    public class CatsController : ApiController
    {
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<int>> Create()
        {

            return null;
        }

    }
}
