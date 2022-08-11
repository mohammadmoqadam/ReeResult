using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult
{
    public abstract class ResultBase<T>
    {
        public bool IsSuccess { get; set; } = true;
        public bool IsFailed { get; set; } = false;
        public List<string> Reasons { get; set; } = new List<string>();
        public List<string> Errors { get; set; } = new List<string>();
        public T? Value { get; set; } = default(T?);


        protected void SetFaild()
        {
            this.IsSuccess = false;
            this.IsFailed = true;
            this.Value = default(T?);
        }
    }
}
