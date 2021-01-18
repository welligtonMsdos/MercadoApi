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
            if (result.ToString().Contains("error"))
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Erro",
                    Data = result
                });
            }

            return Ok(new
            {
                Success = true,
                Message = "sucesso",
                Data = result
            });
        }
       
    }
}
