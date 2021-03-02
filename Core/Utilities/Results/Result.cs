using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool isSucces, string message) : this(isSucces)
        {
            Message = message;
        }

        public Result(bool isSucces)
        {
            Success = isSucces;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
