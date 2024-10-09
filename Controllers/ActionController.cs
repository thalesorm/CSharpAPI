using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ActionModel = ApiGap.Models.Action;

namespace ApiGap.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<ActionModel>> GetAllAction()
        {
            return Ok();
        }
    }
}
