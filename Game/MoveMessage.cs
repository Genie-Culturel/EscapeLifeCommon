using System;

namespace EscapeLifeCommon.Messages.Game
{
    /// <summary>
    /// Message sent by the server to the clients to start a new move step
    /// </summary>
    public partial class MoveMessage : MessageBase
    {
        public string Name { get; set; }
        public string FromCoordinates { get; set; }
        public string ToCoordinates { get; set; }
        public TimeSpan? TargetTime { get; set; }
        public string VideoName { get; set;}

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} from coordinates '{FromCoordinates}' to '{ToCoordinates}' with name '{Name}'";
        }
    }
}
