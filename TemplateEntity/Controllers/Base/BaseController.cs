using Domain;
using Microsoft.AspNetCore.Mvc;

namespace TemplateEntity.Controllers.Base
{
    [ApiController] 
    [ApiVersion("1.0")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CustomReturn<T>(BaseResponse<T> retorno) where T : class
        {
            switch (retorno?.StatusCode ?? System.Net.HttpStatusCode.BadRequest)
            {
                case System.Net.HttpStatusCode.OK:
                    return Ok(retorno);
                case System.Net.HttpStatusCode.Unauthorized:
                    return Unauthorized(retorno);
                default: return StatusCode((int)(retorno?.StatusCode ?? System.Net.HttpStatusCode.BadRequest), retorno);
            }
        }
    }
}
