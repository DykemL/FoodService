using FoodService.Models.DtoModels;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodService.Utils
{
    public static class TempStorage
    {
        private static Dictionary<string, object> tempObjects = new();
        public static void SetObject(string userName, object obj)
        {
            if (tempObjects.Count < 1000)
                tempObjects.Add(userName, obj);
        }
        public static T GetObject<T>(string userName)
        {
            return (T)tempObjects[userName];
        }
        public static T PopObject<T>(string userName)
        {
            object tempTempObj = tempObjects[userName];
            tempObjects.Remove(userName);
            return (T)tempTempObj;
        }
        public static void RemoveObject(string userName)
        {
            try
            {
                tempObjects.Remove(userName);
            }
            catch (Exception)
            {}
        }
        public static bool IsEmpty(string userName)
        {
            return !tempObjects.ContainsKey(userName);
        }
    }
}
