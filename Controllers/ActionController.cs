using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Action>> GetAllAction()
        {
            return Ok();
        }
    }
}
