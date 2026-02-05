using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message containing localized text and audio urls
    /// </summary>
    [Serializable]
    public partial class AutomaticAudio : MessageBase
    {
        public Dictionary<string, string> LocalizedStrings = new();

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with {LocalizedStrings.Count} localized strings and {(AudioUrls?.Count ?? 0)} audio urls";
        }
    }
}
