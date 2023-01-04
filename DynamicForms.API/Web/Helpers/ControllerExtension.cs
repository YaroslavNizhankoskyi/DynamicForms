using Application.Helpers.Exceptions;
using LanguageExt.Common;
using Microsoft.AspNetCore.Mvc;

namespace Web.Helpers
{
    internal static class ControllerExtensions
    {
        public static IActionResult ToOk<TResult>(
            this Result<TResult> result)
        {
            return result.Match<IActionResult>(x =>
            {
                return new OkObjectResult(x);
            }, exception =>
            {
                return exception.ExceptionToActionResult();
            });
        }

        public static IActionResult ExceptionToActionResult(this Exception exc)
        {
            switch (exc)
            {
                case NullReferenceException:
                    return new NotFoundObjectResult(exc.Message);
                case SignInFailureException:
                default:
                    return new StatusCodeResult(500);
            }
        }
    }
}
