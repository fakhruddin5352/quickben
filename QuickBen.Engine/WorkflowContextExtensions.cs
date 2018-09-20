using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBen.Engine
{
    public static class WorkflowContextExtensions
    {
        public static string SetContextProperty(this JObject context, string property, object value)
        {
            var values = property.Split('.');
            var token = context;
            for (int i = 0; i < values.Length; i++)
            {
                if (i == values.Length - 1)
                {
                    token[values[i]] = value != null ? JToken.FromObject(value) : null;
                    return token[values[i]]?.Path;
                }
                token = (JObject)token[values[i]] ?? new JObject();
            }
            return null;
        }

        public static object GetContextProperty(this JObject context, string path, Type propertyType)
        {
            var token = context.SelectToken(path);
            // Don't need to check if the property exists
            // It has already been done when building the graph

            var value = token?.ToObject(propertyType);
            return value;
        }
    }
}
