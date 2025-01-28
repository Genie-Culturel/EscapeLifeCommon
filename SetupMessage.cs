using System.Collections.Generic;

namespace EscapeLife.Messages
{
    /// <summary>
    /// Message sent by the server to a newly connected client
    /// </summary>
    public partial class SetupMessage : MessageBase
    {
        public List<MessageBase> VideoMessages { get; set; }
        public MessageBase CurrentStepMessage { get; set; }

        public override string ToString()
        {
            string currentStepType = "null";

            if (CurrentStepMessage != null)
                currentStepType = CurrentStepMessage.MessageType;

            return $"{base.ToString()} a {GetType().Name} with '{VideoMessages.Count}' video messages and current step message type '{currentStepType}'";
        }
    }
}
