using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Connection
{
    /// <summary>
    /// Message sent by the server to a client that tried to connect but was not successful
    /// </summary>
    public partial class ConnectionFailedMessage : MessageBase
    {
        public ConnectionFailedType ConnectionFailedType;

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with ConnectionFailedType '{ConnectionFailedType}'";
        }
    }
}
