using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ReeResult.HttpResponse
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            var result = (ObjectResult)context.Result;
            try
            {

                if (result == null || result.Value == null || result.Value.GetType().GetInterfaces().FirstOrDefault()?.Name != nameof(ReeResult.HttpResponse.ResHttp)) return;

                var response = new ReeResult.Result();

                var responseResult = result.Value as ResHttp;
                if (responseResult != null && responseResult.IsFailed)
                {

                    response.IsSuccess = false;
                    response.IsFailed = true;
                    response.Errors = responseResult.Errors;
                    switch (responseResult.StatusCode)
                    {
                        case null:
                            context.Result = new BadRequestObjectResult(response);
                            break;
                        case HttpStatusCode.BadRequest:
                            context.Result = new BadRequestObjectResult(response);
                            break;
                        case HttpStatusCode.Conflict:
                            context.Result = new ConflictObjectResult(response);
                            break;
                        case HttpStatusCode.Unauthorized:
                            context.Result = new UnauthorizedObjectResult(response);
                            break;
                        case HttpStatusCode.NotFound:
                            context.Result = new NotFoundObjectResult(response);
                            break;
                        default:
                            context.Result = new BadRequestObjectResult(response);
                            break;
                    }
                }
                else
                {
                    response.Value = responseResult?.Value;
                    context.Result = new OkObjectResult(response);
                }
            }
            catch (Exception)
            {

                context.Result = new OkObjectResult(result.Value);
            }

        }

    }
}
