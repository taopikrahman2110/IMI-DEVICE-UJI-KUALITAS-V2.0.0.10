using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Script.Serialization;

namespace MRZReader
{
    public static class JSONHelper
    {
        /// <summary>
        /// Serialize any object into any depth level
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            return serializer.Serialize(obj);
        }

        /// <summary>
        /// Serialize any object into specified depth level
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="recursionDepth"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj, int recursionDepth)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            serializer.RecursionLimit = recursionDepth;
            return serializer.Serialize(obj);
        }

        public static T ToObj<T>(this string response)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            T value = serializer.Deserialize<T>(response);

            return value;
        }
    }
}
