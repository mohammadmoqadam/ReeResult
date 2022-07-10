namespace ReeResult
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
            result.IsSuccess = false;
            result.IsFailed = true;
            result.Value = null;
            result.AddError(message);
            return result;
        }

        public static Result<ResultType> Fail<ResultType>(string message)
        {
            var result = new Result<ResultType>();
            result.IsSuccess = false;
            result.IsFailed = true;
            result.Value = null;
            result.AddError(message);
            return result;
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

        public Result AddReason(string message)
        {
            if (Reasons == null)
                Reasons = new List<string>();
            Reasons.Add(message);

            return this;
        }

    }


}

