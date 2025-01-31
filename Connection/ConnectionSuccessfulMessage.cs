using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Connection
{
    /// <summary>
    /// Message sent by the server to a newly connected client
    /// </summary>
    public partial class ConnectionSuccessfulMessage : MessageBase
    {
        public List<MessageBase> VideoMessages { get; set; }
        public MessageBase CurrentStepMessage { get; set; }
        public string ConnectedAs { get; set; }

        public override string ToString()
        {
            string currentStepType = "null";

            if (CurrentStepMessage != null)
                currentStepType = CurrentStepMessage.MessageType;

            return $"{base.ToString()} a {GetType().Name} for '{ConnectedAs}' with '{VideoMessages.Count}' video messages and current step message type '{currentStepType}'";
        }
    }
}
