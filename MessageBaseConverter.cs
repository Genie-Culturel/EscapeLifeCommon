using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace EscapeLife.Messages
{
    // https://stackoverflow.com/questions/20995865/deserializing-json-to-abstract-class

    /// <summary>
    /// Tells to which class a json string can be converted and how
    /// </summary>
    public class MessageBaseSpecifiedConcreteClassConverter : DefaultContractResolver
    {
        protected override JsonConverter ResolveContractConverter(Type objectType)
        {
            if (typeof(MessageBase).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }

    /// <summary>
    /// Converts a JSON string back to its concrete class
    /// </summary>
    public class MessageBaseConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new JsonSerializerSettings { ContractResolver = new MessageBaseSpecifiedConcreteClassConverter() };

        // Use the default serialization method
        public override bool CanWrite => false;

        public override bool CanConvert(Type objectType) => objectType == typeof(MessageBase);

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
                return null;

            JObject jo = JObject.Load(reader);

            Type messageType = GetTypeFromMessageType(jo["MessageType"].ToString());

            return JsonConvert.DeserializeObject(jo.ToString(), messageType, SpecifiedSubclassConversion);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        private Type GetTypeFromMessageType(string messageType)
        {
            string fullMessageType = typeof(MessageBase).Namespace + "." + messageType;

            return Type.GetType(fullMessageType);
        }
    }
}
