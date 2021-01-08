using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
