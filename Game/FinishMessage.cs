namespace EscapeLife.Models.Messages.Game
{
    /// <summary>
    /// Message sent by the server to the clients to finish a game
    /// </summary>
    public partial class FinishMessage : MessageBase
    {
        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name}";
        }
    }
}
