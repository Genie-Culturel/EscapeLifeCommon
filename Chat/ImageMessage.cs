using System;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message sent by both server and clients containning an image
    /// </summary>
    [Serializable]
    public partial class ImageMessage : MessageBase
    {
        public string Base64Image { get; set; }
        public string Extension { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with Base64Image '{Base64Image}' with Extension '{Extension}'";
        }
    }
}
