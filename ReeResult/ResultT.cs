﻿using System;
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
}
