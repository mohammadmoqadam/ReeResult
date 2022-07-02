using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult
{
    public abstract class ResultBase
    {
        public bool IsSuccess { get; set; } = true;
        public bool IsFailed { get; set; } = false;
        public List<string> Reasons { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
        public object? Value { get; set; } = null;

        public static Result OK<ResultType>(ResultType value)
        {
            return new Result
            {
                Value = value
            };
        }

        public static Result Fail<ResultType>(string message)
        {
            return new Result()
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
