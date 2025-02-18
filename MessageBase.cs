using Newtonsoft.Json;
using System;
using System.Runtime.Serialization;

namespace EscapeLifeCommon.Messages
{
    /// <summary>
    /// Parent of all our messages sent in a game
    /// </summary>
    [Serializable] 
    [JsonConverter(typeof(MessageBaseConverter))]
    public abstract partial class MessageBase
    {
        public MessageBase() { 
            SentAt = DateTime.UtcNow;
        }

        // When it has been sent (Set automatically)
        public DateTime SentAt { get; set; }

        // Who sent it
        public string Sender { get; set; }

        // In which game
        public int GameId { get; set; } = -1;

        // Type of message (used for json conversion, do not touch it)
        public string MessageType { get; set; }

        public override string ToString()
        {
            return $"{Sender} sent at {SentAt.ToShortTimeString()} in GameId {GameId}";
        }

        // Set the message type automatically on serialization
        [OnSerializing]
        internal void OnSerializingMethod(StreamingContext context)
        {
            string fullTypeName = GetType().FullName;
            string baseNamespace = typeof(MessageBase).Namespace;
            MessageType = fullTypeName.Replace(baseNamespace + ".", "");
        }
    }
}
