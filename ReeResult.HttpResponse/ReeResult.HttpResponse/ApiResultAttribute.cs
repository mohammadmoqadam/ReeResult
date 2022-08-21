using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace ReeResult.HttpResponse
{
    public class ApiResultAttribute : ActionFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result.GetType() != typeof(ObjectResult)) return;
            var result = (ObjectResult)context.Result;
            var classType = result?.Value?.GetType();
            try
            {

                if (result == null || result.Value == null || result.Value.GetType().Assembly.GetName().Name != "ReeResult.HttpResponse") return;

                var response = new ReeResult.Result<object>();


                var isSuccess = result.Value?.GetType()?.GetProperty("IsSuccess")?.GetValue(result.Value) as Boolean?;
                if (isSuccess == true)
                {
                    var value = result.Value?.GetType()?.GetProperty("Value")?.GetValue(result.Value);
                    response.Value = value;
                    context.Result = new OkObjectResult(response);
                    return;
                }


                var errors = result.Value?.GetType()?.GetProperty("Errors")?.GetValue(result.Value) as List<String>;
                var reasons = result.Value?.GetType()?.GetProperty("Reasons")?.GetValue(result.Value) as List<String>;
                var statusCode = result.Value?.GetType()?.GetProperty("StatusCode")?.GetValue(result.Value) as HttpStatusCode?;
                response.IsSuccess = false;
                response.IsFailed = true;
                response.Errors = errors ?? new List<string>();
                response.Reasons = reasons ?? new List<string>();
                switch (statusCode)
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
                    case HttpStatusCode.OK:
                        context.Result = new OkObjectResult(response);
                        break;
                    default:
                        context.Result = new BadRequestObjectResult(response);
                        break;
                }

            }
            catch (Exception)
            {

                context.Result = new OkObjectResult(result.Value);
            }

        }

    }
}
