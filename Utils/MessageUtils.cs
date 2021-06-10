using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class MessageUtils
    {
        private static string errorKey = "CustomError";
        private static string successMessageKey = "CustomSuccessMessage";
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
        public static void SetSuccessMessage(ITempDataDictionary temp, string successMessage)
        {
            temp[successMessageKey] = successMessage;
        }
        public static string PopSuccessMessage(ITempDataDictionary temp)
        {
            if (temp.ContainsKey(successMessageKey))
            {
                string successMessage = temp[successMessageKey].ToString();
                temp.Remove(successMessageKey);
                return successMessage;
            }
            else
                return null;
        }
    }
}
