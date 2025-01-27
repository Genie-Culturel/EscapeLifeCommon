namespace EscapeLife.Models.Messages.Chat
{
    /// <summary>
    /// Message sent by both server and clients containning a text
    /// </summary>
    public partial class TextMessage : MessageBase
    {
        public string Text { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with Text '{Text}'";
        }
    }
}
