using Core.Ultities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Ultities.Business
{
    public static class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //bütün kuralları gez uymayanları yazdır.
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
