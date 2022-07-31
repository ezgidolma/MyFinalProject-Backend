using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Results
{
    public class Result : IResult
    {


        public Result(bool success, string message):this(success)//üstteki çalışırken alttakin de çalıştırır
        {
           Message = message;//set etme
      
        }

        public Result(bool success)
        {
         
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
