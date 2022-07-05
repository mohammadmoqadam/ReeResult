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

                if (result == null || result.Value == null || result.Value.GetType().GetInterfaces().FirstOrDefault()?.Name!=nameof(ReeResult.HttpResponse.ResHttp)) return;



                var responseResult = result.Value as ResHttp;
                if (responseResult != null && responseResult.IsFailed)
                {
                    var res = result.Value as ResultBase;
                    var res2 = new ReeResult.Result();
                    res2.IsSuccess = false;
                    res2.IsFailed = true;
                    res2.Errors = res.Errors;
                    res2.Value = res.Value;
                    switch (responseResult.StatusCode)
                    {
                        case null:
                            context.Result = new BadRequestObjectResult(res2);
                            break;
                        case HttpStatusCode.BadRequest:
                            context.Result = new BadRequestObjectResult(res2);
                            break;
                        case HttpStatusCode.Conflict:
                            context.Result = new ConflictObjectResult(res2);
                            break;
                        case HttpStatusCode.Unauthorized:
                            context.Result = new UnauthorizedObjectResult(res2);
                            break;
                        case HttpStatusCode.NotFound:
                            context.Result=new NotFoundObjectResult(res2);
                            break;
                        default:
                            context.Result = new BadRequestObjectResult(res2);
                            break;
                    }
                }
            }
            catch (Exception)
            {

                context.Result = new OkObjectResult(result.Value);
            }

        }

    }
}
