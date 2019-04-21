using MikroTik.Domain.Entities;
using tik4net;

namespace MikroTik.Infrastructure.Tik4Net
{
    public class TikService
    {
        public ITikConnection Connection { get; private set; }

        public TikService CreateConnection(Server server)
        {
            Connection = ConnectionFactory.OpenConnection(TikConnectionType.Api, server.Hostname,
                server.Port, server.Username, server.Password);
            return this;
        }
    }
}
