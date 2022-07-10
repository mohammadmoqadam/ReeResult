using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace ReeResult.HttpResponse
{
    public class Result : ResultBase<DefaultResult>, ResHttp
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
        public static Result Ok()
        {
            return new Result();
        }
        public static Result<T> Ok<T>()
        {
            return new Result<T>();
        }
        public Result AddError(string message)
        {
            this.IsSuccess = false;
            this.IsFailed = true;
            this.Value = null;
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);


            return this;
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
        public Result AddReason(string message)
        {
            if (Reasons == null)
                Reasons = new List<string>();
            Reasons.Add(message);

            return this;
        }

    }

    public class Result<ResultType> : ResultBase<ResultType>, ResHttp
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

        public Result<ResultType> AddValue(ResultType resultType)
        {
            this.Value = resultType;
            return this;
        }

        public Result<ResultType> AddError(string message)
        {
            this.IsFailed = true;
            this.IsSuccess = false;
            this.Value = null;

            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);

            return this;

        }

        public Result<ResultType> AddReason(string message)
        {
            if (Reasons == null)
                Reasons = new List<string>();
            Reasons.Add(message);

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
