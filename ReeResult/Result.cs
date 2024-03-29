﻿namespace ReeResult
{

    public class DefaultResult
    {

    }

    public class Result : ResultBase<DefaultResult>
    {
  
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

        public Result AddError(string message)
        {
            this.SetFaild();
            if (Errors == null)
                Errors = new List<string>();
            Errors.Add(message);

            return this;
        }

        public Result AddReason(string message)
        {
            if (Reasons == null)
                Reasons = new List<string>();
            Reasons.Add(message);

            return this;
        }

        public Result Merge<ResultType>(ResultBase<ResultType> data)
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


}

