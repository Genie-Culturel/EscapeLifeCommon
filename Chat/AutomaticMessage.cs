using System;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message prefilled in that database for clues or the start of a step
    /// </summary>
    [Serializable]
    public partial class AutomaticMessage : MessageBase
    {
        public string TextFr { get; set; }
        public string TextEn { get; set; }
        public string TextGe { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with TextFr '{TextFr}', TextEn '{TextEn}' and TextGe '{TextGe}'";
        }
    }
}
