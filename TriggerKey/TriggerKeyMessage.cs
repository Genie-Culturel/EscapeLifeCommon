namespace EscapeLife.Messages.TriggerKey
{
    /// <summary>
    /// Message sent by both the client (Type=Query) and server (Type=Success||Failure) for TriggerKey management
    /// </summary>
    public partial class TriggerKeyMessage : MessageBase
    {
        public TriggerKeyMessageType Type { get; set; }
        public string TriggerKey { get; set; }
        public string StepName { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} {Type.ToString()} for key '{TriggerKey}'";
        }
    }
}
