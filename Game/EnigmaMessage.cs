using System;

namespace EscapeLife.Models.Messages.Game
{
    /// <summary>
    /// Message sent by the server to the clients to start a new enigma step
    /// </summary>
    public partial class EnigmaMessage : MessageBase
    {
        public string Name { get; set; }
        public TimeSpan? TargetTime { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with name '{Name}'";
        }
    }
}
