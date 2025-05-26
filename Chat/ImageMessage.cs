using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message sent by both server and clients containning an image
    /// </summary>
    [Serializable]
    public partial class ImageMessage : MessageBase {
        public Dictionary<string, string> LocalizedImageNames = new();

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with {LocalizedImageNames.Count} localized image names.";
        }
    }
}
