using System;
using System.Linq.Expressions;
using MikroTik.Domain.Entities;

namespace MikroTik.Application.Servers.Models
{
    public class ServerModel
    {
        public int Id { get; set; }
        public string Hostname { get; set; }

        public static Expression<Func<Server, ServerModel>> Projection
        {
            get
            {
                return server => new ServerModel
                {
                    Id = server.Id,
                    Hostname =  server.Hostname
                };
            }
        }

        public static ServerModel Create(Server server)
        {
            return Projection.Compile().Invoke(server);
        }
    }
}
