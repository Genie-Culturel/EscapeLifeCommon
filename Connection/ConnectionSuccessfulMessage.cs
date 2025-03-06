using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Connection
{
    /// <summary>
    /// Message sent by the server to a newly connected client
    /// </summary>
    public partial class ConnectionSuccessfulMessage : MessageBase
    {
        public List<MoveMessage> MoveMessages { get; set; }
        public DateTime? StartedAt { get; set;}
        public string ConnectedAs { get; set; }
        public string Site { get; set; }

        public override string ToString()
        {
            string currentStepType = "null";

            if (CurrentStepMessage != null)
                currentStepType = CurrentStepMessage.MessageType;

            return $"{base.ToString()} a {GetType().Name} for '{ConnectedAs}' with Site '{Site}', '{MoveMessages.Count}' move messages and StartedAt '{(StartedAt?.ToShortTimeString() ?? "null")}'";
        }
    }
}
