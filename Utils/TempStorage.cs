using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class TempStorage
    {
        private static string tempKey = "TempStorage";
        public static void SetObject(ITempDataDictionary temp, object obj)
        {
            temp[tempKey] = obj;
        }
        public static T PopObject<T>(ITempDataDictionary temp)
        {
            return (T)temp[tempKey];
        }
        public static bool IsEmpty(ITempDataDictionary temp)
        {
            return temp[tempKey] == null;
        }
    }
}
