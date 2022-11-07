using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace ASP_NET_Core_MVC.Controllers
{
    public class ErrorController : Controller
    {
        [HttpGet]
        public IActionResult ErrorHandler()
        {
            var statusCode = HttpContext.Response.StatusCode;

            switch (statusCode)
            {
                case 500:
                    {
                        var exceptionMessage = "";
                        var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

                        if (exceptionHandlerPathFeature?.Error is FileNotFoundException)
                        {
                            exceptionMessage = "The file was not found.";
                        }
                        else if (exceptionHandlerPathFeature?.Error is NullReferenceException)
                        {
                            exceptionMessage = "Access the NULL variable.";
                        }
                        ViewBag.ExceptionMessage = exceptionMessage;

                        return View("InternalServerError");
                    }

                default: return View("NotFound");
            }
        }

        public new IActionResult StatusCode(int statusCode)
        {
            return View();
        }
    }
}
