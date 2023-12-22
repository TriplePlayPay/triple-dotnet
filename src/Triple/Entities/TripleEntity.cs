using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml;
using Triple.Infrastructure;
using Triple.Interfaces;

namespace Triple.Entities
{
    public abstract class TripleEntity : ITripleEntity
    {
        /// <summary>
        /// Gets the raw <see cref="JsonDocument">JObject</see> exposed by the System.Text.Json library.
        /// This can be used to access properties that are not directly exposed by Triple's .NET
        /// library.
        /// </summary>
        /// <remarks>
        /// You should always prefer using the standard property accessors whenever possible. This
        /// accessor is not considered fully stable and might change or be removed in future
        /// versions.
        /// </remarks>
        /// <returns>The raw <see cref="JsonDocument">JObject</see>.</returns>
        [JsonIgnore]
        public JsonDocument RawJObject { get; protected set; }

        [JsonIgnore]
        public TripleResponse TripleResponse { get; set; }

        /// <summary>Deserializes the JSON to the specified Triple object type.</summary>
        /// <typeparam name="T">The type of the Triple object to deserialize to.</typeparam>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized Triple object from the JSON string.</returns>
        public static T FromJson<T>(string value)
            where T : ITripleEntity
        {
            return JsonUtils.DeserializeObject<T>(value);
        }

        internal void SetRawJObject(JsonDocument rawJObject)
        {
            this.RawJObject = rawJObject;
        }

        /// <summary>Reports a Triple object as a string.</summary>
        /// <returns>
        /// A string representing the Triple object, including its JSON serialization.
        /// </returns>
        /// <seealso cref="ToJson"/>
        public override string ToString()
        {
            return string.Format(
                "<{0}@{1} id={2}> JSON: {3}",
                this.GetType().FullName,
                RuntimeHelpers.GetHashCode(this),
                this.GetIdString(),
                this.ToJson());
        }

        /// <summary>Serializes the Triple object as a JSON string.</summary>
        /// <returns>An indented JSON string represensation of the object.</returns>
        public string ToJson()
        {
            return JsonUtils.SerializeObject(
                this);
        }

        /// <summary>
        /// Sets a string ID on an expandable field. If the expandable field does not exist,
        /// a new one is initialized. If the expandable field exists and already contains an
        /// expanded object, and the ID within the expanded object does not match the new string ID,
        /// expanded object is discarded.
        /// </summary>
        /// <typeparam name="T">Type of the expanded object.</typeparam>
        /// <param name="id">The string ID.</param>
        /// <param name="expandable">The expandable field.</param>
        /// <returns>The expandable field with its ID set to the provided string ID.</returns>
        protected static ExpandableField<T> SetExpandableFieldId<T>(
            string id,
            ExpandableField<T> expandable)
            where T : IHasId
        {
            if (expandable == null)
            {
                expandable = new ExpandableField<T>();
                expandable.Id = id;
            }
            else if (expandable.Id != id)
            {
                expandable.ExpandedObject = default;
                expandable.Id = id;
            }

            return expandable;
        }

        /// <summary>
        /// Sets an expanded object on an expandable field. If the expandable field does not exist,
        /// a new one is initialized.
        /// </summary>
        /// <typeparam name="T">Type of the expanded object.</typeparam>
        /// <param name="obj">The expanded object.</param>
        /// <param name="expandable">The expandable field.</param>
        /// <returns>
        /// The expandable field with its expanded object set to the provided object.
        /// </returns>
        protected static ExpandableField<T> SetExpandableFieldObject<T>(
            T obj,
            ExpandableField<T> expandable)
            where T : IHasId
        {
            if (expandable == null)
            {
                expandable = new ExpandableField<T>();
            }

            expandable.ExpandedObject = obj;

            return expandable;
        }

        protected static List<ExpandableField<T>> SetExpandableArrayIds<T>(List<string> ids)
            where T : IHasId
        {
            return ids?.Select((id) =>
            {
                var expandable = new ExpandableField<T>();
                expandable.Id = id;
                return expandable;
            }).ToList();
        }

        protected static List<ExpandableField<T>> SetExpandableArrayObjects<T>(List<T> objects)
            where T : IHasId
        {
            return objects?.Select((obj) =>
            {
                var expandable = new ExpandableField<T>();
                expandable.Id = obj.Id;
                expandable.ExpandedObject = obj;
                return expandable;
            }).ToList();
        }

        private object GetIdString()
        {
            foreach (var property in this.GetType().GetTypeInfo().DeclaredProperties)
            {
                if (property.Name == "Id")
                {
                    return property.GetValue(this);
                }
            }

            return null;
        }
    }

    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleType", Justification = "Generic variant")]
    public abstract class TripleEntity<T> : TripleEntity
        where T : TripleEntity<T>
    {
        /// <summary>Deserializes the JSON to a Triple object type.</summary>
        /// <param name="value">The object to deserialize.</param>
        /// <returns>The deserialized Triple object from the JSON string.</returns>
        public static new T FromJson(string value)
        {
            return TripleEntity.FromJson<T>(value);
        }
    }
}
