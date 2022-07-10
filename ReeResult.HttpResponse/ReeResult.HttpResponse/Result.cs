using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace ReeResult.HttpResponse
{
    public class Result : ReeResult.Result, ResHttp
    {
        public HttpStatusCode? StatusCode { get; internal set; }
        public static Result Fail(string message, HttpStatusCode statusCode)
        {
            var result = new Result();
            result.AddError(message);
            result.StatusCode = statusCode;
            return result;
        }
        public static Result<T> Fail<T>(string message, HttpStatusCode statusCode)
        {
            var result = new Result<T>();
            result.AddError(message);
            result.StatusCode = statusCode;
            return result;
        }

        public Result AddError(string message, HttpStatusCode statusCode)
        {
            this.IsSuccess = false;
            this.IsFailed = true;
            this.Value = null;
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);
            this.StatusCode = StatusCode;

            return this;
        }

    }

    public class Result<ResultType> : ReeResult.Result<ResultType>, ResHttp
    {
        public HttpStatusCode? StatusCode { get; internal set; }

        public Result<ResultType> AddError(string message, HttpStatusCode statusCode)
        {
            this.IsFailed = true;
            this.IsSuccess = false;
            this.Value = null;
            this.StatusCode = statusCode;
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);

            return this;

        }

    }

    public interface ResHttp
    {
        bool IsFailed { get; set; }
        List<string> Errors { get; set; }
        HttpStatusCode? StatusCode { get; }
    }


}
