using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;

namespace Triple.Infrastructure
{
    internal static class JsonUtils
    {
        /// <summary>
        /// Deserializes the JSON to the specified .NET type
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize to.</typeparam>
        /// <param name="value">The JSON to deserialize.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static T DeserializeObject<T>(
            string value)
        {
            return (T)DeserializeObject(value, typeof(T));
        }

        /// <summary>
        /// Deserializes the JSON to the specified .NET type
        /// </summary>
        /// <param name="value">The JSON to deserialize.</param>
        /// <param name="type">The type of the object to deserialize to.</param>
        /// <returns>The deserialized object from the JSON string.</returns>
        public static object DeserializeObject(
            string value,
            Type type)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            return JsonSerializer.Deserialize<Type>(value);
        }

        /// <summary>
        /// Serializes the specified object to a JSON string without using any default settings.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <returns>A JSON string representation of the object.</returns>
        public static string SerializeObject(
            object value)
        {
            return JsonSerializer.Serialize(value);
        }
    }
}
