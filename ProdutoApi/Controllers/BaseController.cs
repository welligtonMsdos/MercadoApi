using Microsoft.AspNetCore.Mvc;

namespace ProdutoApi.Controllers
{

    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected BaseController()
        {

        }

        protected new ActionResult Response(object result = null)
        {
            return Ok(new
            {
                Success = true,
                Message = "sucesso",
                Data = result
            });
        }
       
    }
}
