using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message prefilled in that database for clues or the start of a step
    /// </summary>
    [Serializable]
    public partial class AutomaticMessage : MessageBase
    {
        public Dictionary<string, string> LocalizedStrings = new();

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with {LocalizedStrings.Count} localized strings";
        }
    }
}
