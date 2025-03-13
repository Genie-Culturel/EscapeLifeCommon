using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message sent by both server and clients containning an image
    /// </summary>
    [Serializable]
    public partial class ImageMessage : MessageBase
    {
        public Dictionary<string, string> LocalizedBase64 = new();
        public string Extension { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with {LocalizedStrings.Count} localized Base64 images with Extension '{Extension}'";
        }
    }
}
