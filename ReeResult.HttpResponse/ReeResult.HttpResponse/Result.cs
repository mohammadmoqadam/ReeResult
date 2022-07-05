using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult.HttpResponse
{
    public class Result : ResultBase, ResHttp
    {
        public HttpStatusCode? StatusCode { get; set; } = null;
        public static Result Fail(string message, HttpStatusCode statusCode)
        {
            return new Result()
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false,
                StatusCode = statusCode
            };
        }
    }

    public class Result<ResultType> : ReeResult.Result<ResultType>, ResHttp
    {
        public HttpStatusCode? StatusCode { get; set; } = null;
        public static Result<ResultType> Fail<ResultType>(string message, HttpStatusCode statusCode)
        {
            return new Result<ResultType>
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false,
                StatusCode = statusCode
            };
        }

        public Result<ResultType> AddError(string message, HttpStatusCode statusCode)
        {
            base.AddErrorConfig();
            this.StatusCode = statusCode;
            base.AddError(message);

            return this;

        }
    }

    public interface ResHttp
    {
        bool IsFailed { get; set; }
        List<string> Errors { get; set; }
        HttpStatusCode? StatusCode { get; set; }
    }


}
