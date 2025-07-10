using CleanArq.Application.Exceptions;
using CleanArq.Application.External.Roma;
using CleanArq.Application.Features;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CleanArq.Api.Controllers
{
    [Route("api/roma")]
    [ApiController]
    [TypeFilter(typeof(ExceptionManager))]
    public class RomaController : ControllerBase
    {
        [HttpGet, Route("GetCategories")]
        public async Task<IActionResult> GetCategories(int build, [FromServices] IRomaService srv)
        {
            var data = await srv.Execute(build);
            return StatusCode(200, ResponseApiService.Response(200, "Ejecución exitosa", data));
        }
    }
}
