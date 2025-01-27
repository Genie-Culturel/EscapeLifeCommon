namespace EscapeLife.Models.Messages.Chat
{
    /// <summary>
    /// Message sent by the server to the clients relating to notify an event with user connection/disconnection 
    /// </summary>
    public partial class EventMessage : MessageBase
    {
        public string Username { get; set; }
        public int ConnectedUsers { get; set; }
        public bool Connection { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()} a {GetType().Name} with Username '{Username}', ConnectedUsers '{ConnectedUsers}' and Connection '{Connection}'";
        }
    }
}
