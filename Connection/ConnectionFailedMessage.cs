using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Connection
{
    /// <summary>
    /// Message sent by the server to a client that tried to connect but was not successful
    /// </summary>
    public partial class ConnectionFailedMessage : MessageBase
    {
        public ConnectionFailedType ConnectionFailedType;
        
        public static ConnectionFailedMessage GameInvalid() {
            return new ConnectionFailedMessage
            {
                Sender = "System",
                GameId = -1,
                ConnectionFailedType = ConnectionFailedType.GameInvalid
            };
        }
        
        public static ConnectionFailedMessage GameNotFound() {
            return new ConnectionFailedMessage
            {
                Sender = "System",
                GameId = -1,
                ConnectionFailedType = ConnectionFailedType.GameNotFound
            };
        }
        
        public static ConnectionFailedMessage UsernameInvalid() {
            return new ConnectionFailedMessage
            {
                Sender = "System",
                GameId = -1,
                ConnectionFailedType = ConnectionFailedType.UsernameInvalid
            };
        }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with ConnectionFailedType '{ConnectionFailedType}'";
        }
    }
}
