using MediatR;
using MikroTik.Application.Servers.Models;

namespace MikroTik.Application.Servers.Queries
{
    public class GetServerQuery : IRequest<ServerModel>
    {
        public int Id { get; set; }
    }
}
