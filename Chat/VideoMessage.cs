using System;
using System.Collections.Generic;

namespace EscapeLifeCommon.Messages.Chat
{
    /// <summary>
    /// Message sent by the server to the clients containing a Uri to be displayed
    /// </summary>
    [Serializable]
    public partial class VideoMessage : MessageBase
    {
        public Dictionary<string, string> LocalizedVideoNames = new();
            
        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with {LocalizedVideoNames.Count} localized video names.";
        }
    }
}
