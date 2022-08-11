using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult
{
    public class Result<ResultType> : ResultBase<ResultType>
    {
        public Result<ResultType> AddValue(ResultType resultType)
        {
            this.Value = resultType;
            return this;
        }

        public Result<ResultType> AddError(string message)
        {
            this.SetFaild();
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

        public Result<ResultType> Merge<ResultTypeT>(ResultBase<ResultTypeT?> data)
        {
            if (data == null) return this;
            if (this.IsSuccess && data.IsFailed)
            {
                SetFaild();
            }
            this.Errors.AddRange(data.Errors);
            this.Reasons.AddRange(data.Reasons);
            if (typeof(ResultType) == typeof(ResultTypeT) && this.IsSuccess && this.Value == null && data != null && data.Value != null)
                this.Value = (ResultType)(object)data.Value;
            return this;

        }

        public ResultType? GetValue()
        {
            return this.Value == null ? default(ResultType?) : (ResultType)this.Value;
        }
    }
}
