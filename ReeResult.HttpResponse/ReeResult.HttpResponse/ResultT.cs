using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult.HttpResponse
{
    public class Result<ResultType> : ResultBase<ResultType>, ResHttp
    {
        public HttpStatusCode? StatusCode { get; internal set; }

        public Result<ResultType> AddError(string message, HttpStatusCode statusCode)
        {
            SetFaild();
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
            SetFaild();
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

        public Result<ResultType> Merge<ResultTypeT>(Result<ResultTypeT> data)
        {
            if (data == null) return this;
            if (this.IsSuccess && data.IsFailed)
            {
                SetFaild();
                if (data.StatusCode != null)
                    this.StatusCode = data.StatusCode;
            }
            this.Errors.AddRange(data.Errors);
            this.Reasons.AddRange(data.Reasons);
            if (typeof(ResultType) == typeof(ResultTypeT) && this.IsSuccess && this.Value == null && data.Value != null)
                this.Value = data.Value;
            return this;

        }
        public Result<ResultType> Merge(Result data)
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

        public ResultType? GetValue()
        {
            return this.Value == null ? default(ResultType?) : (ResultType)this.Value;
        }
    }
}
