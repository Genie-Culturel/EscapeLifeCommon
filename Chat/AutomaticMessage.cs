using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message prefilled in database for clues or steps
    /// Can optionally contain audio URLs for TTS playback
    /// </summary>
    [Serializable]
    public partial class AutomaticMessage : MessageBase
    {
        public Dictionary<string, string> LocalizedStrings = new();

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} " +
                   $"with {LocalizedStrings.Count} localized strings " +
                   $"and {(AudioUrls?.Count ?? 0)} audio urls";
        }
    }
}
