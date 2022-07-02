using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult
{
    public  class ResultBase
    {
        public bool IsSuccess { get; set; } = true;
        public bool IsFailed { get; set; } = false;
        public List<string> Reasons { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
        public object? Value { get; set; } = null;

        public static Result<ResultType> Ok<ResultType>(ResultType value)
        {
            return new Result<ResultType>
            {
                Value = value
            };
        }

        public static Result<ResultType> Fail<ResultType>(string message)
        {
            return new Result<ResultType>
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false
            };
        }

        public static Result Fail(string message)
        {
            return new Result()
            {
                Errors = new List<string> { message },
                IsFailed = true,
                IsSuccess = false
            };
        }

        protected void AddErrorConfig()
        {
            this.IsFailed = true;
            this.IsSuccess = false;
            this.Value = null;
        }


    }
}
