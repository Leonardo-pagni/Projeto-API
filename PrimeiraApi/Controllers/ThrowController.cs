using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace PrimeiraApi.Controllers
{
    //indica para não fazer parte da API
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ThrowController : ControllerBase
    {

        [Route("/error")]
        public IActionResult HanleError() =>
            Problem();

        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment
        ([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }
    }
}
