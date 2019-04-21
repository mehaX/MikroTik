namespace MikroTik.Domain.Entities
{
    public class Server
    {
        public int Id { get; set; }
        public string Hostname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
    }
}
