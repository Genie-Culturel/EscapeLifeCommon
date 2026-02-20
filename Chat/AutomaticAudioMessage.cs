using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message containing localized text and audio urls.
    /// This message is sent after the text message when TTS audio is ready.
    /// </summary>
    [Serializable]
    public partial class AutomaticAudioMessage : MessageBase
    {
        // Localized text versions (same content as AutomaticMessage)
        public Dictionary<string, string> LocalizedStrings = new();

        // ----------------------------------------------------------
        // IMPORTANT:
        // Audio URLs for each language (relative paths from server)
        // Example: "/audio/xxxxxxxx.mp3"
        // This field must exist to receive audio data from the server
        // ----------------------------------------------------------
        public Dictionary<string, string> AudioUrls = new();

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} " +
                   $"with {LocalizedStrings.Count} localized strings " +
                   $"and {(AudioUrls?.Count ?? 0)} audio urls";
        }
    }
}