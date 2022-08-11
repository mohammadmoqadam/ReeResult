using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;


namespace ReeResult.HttpResponse
{
    public class Result : ResultBase<DefaultResult>, ResHttp<DefaultResult>
    {
        public HttpStatusCode? StatusCode { get; internal set; }
        public static Result Fail(string message)
        {
            var result = new Result();
            result.AddError(message);
            return result;
        }
        public static Result<ResultType> Fail<ResultType>(string message)
        {
            var result = new Result<ResultType>();
            result.AddError(message);
            return result;
        }
        public static Result Fail(string message, HttpStatusCode statusCode)
        {
            var result = new Result();
            result.AddError(message);
            result.StatusCode = statusCode;
            return result;
        }
        public static Result<ResultType> Fail<ResultType>(string message, HttpStatusCode statusCode)
        {
            var result = new Result<ResultType>();
            result.AddError(message);
            result.StatusCode = statusCode;
            return result;
        }
        public static Result Ok()
        {
            return new Result();
        }
        public static Result<ResultType> Ok<ResultType>(ResultType value)
        {
            var result = new Result<ResultType>();
            result.Value = value;
            return result;
        }

        public Result AddError(string message)
        {
            SetFaild();
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);


            return this;
        }
        public Result AddError(string message, HttpStatusCode statusCode)
        {
            SetFaild();
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
        public Result Merge<ResultType>(Result<ResultType> data)
        {
            if (data == null) return this;
            if (this.IsSuccess && data.IsFailed)
            {
                SetFaild();
            }
            this.Errors.AddRange(data.Errors);
            this.Reasons.AddRange(data.Reasons);
            return this;

        }
        public Result Merge(Result data)
        {
            if (data == null) return this;
            if (this.IsSuccess && data.IsFailed)
            {
                SetFaild();
            }
            this.Errors.AddRange(data.Errors);
            this.Reasons.AddRange(data.Reasons);
            return this;

        }
    }

  

    public interface ResHttp<T>
    {
        bool IsFailed { get; set; }
        List<string> Errors { get; set; }
        HttpStatusCode? StatusCode { get; }
        public T? Value { get; }
    }


}
