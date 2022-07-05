using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReeResult
{
    public interface IResult
    {
        IResult Fail(string message);

    }
}
