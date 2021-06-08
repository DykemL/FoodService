using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class ErrorUtils
    {
        private static string errorKey = "CustomError";
        public static void SetError(ITempDataDictionary temp, string error)
        {
            temp[errorKey] = error;
        }
        public static string PopError(ITempDataDictionary temp)
        {
            if (temp.ContainsKey(errorKey))
            {
                string error = temp[errorKey].ToString();
                temp.Remove(errorKey);
                return error;
            }
            else
                return null;
        }
    }
}
