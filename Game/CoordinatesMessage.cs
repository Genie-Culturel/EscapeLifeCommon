namespace EscapeLifeCommon.Messages.Game
{
    /// <summary>
    /// Message sent by the client to the server to tell them where there are during a move step
    /// </summary>
    public partial class CoordinatesMessage : MessageBase
    {
        public string Coordinates { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with coordinates '{Coordinates}'";
        }
    }
}
