using System.Net;


namespace ReeResult.HttpResponse
{
    public static class ResultExtensions 
    {
      
        public static Result AddError(this Result result, string message, HttpStatusCode statusCode)
        {
            result.Errors.Add(message);

            return new Result
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false,
                Value = statusCode
            };
        }

        public static Result<ResultType> AddError<ResultType>(this Result<ResultType> result, string message, HttpStatusCode statusCode)
        {
            return new Result<ResultType>()
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false,
                Value = statusCode
            };
        }

    }
}
