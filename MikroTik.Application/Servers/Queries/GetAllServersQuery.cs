using System.Collections.Generic;
using MediatR;
using MikroTik.Application.Servers.Models;

namespace MikroTik.Application.Servers.Queries
{
    public class GetAllServersQuery : IRequest<List<ServerModel>>
    {
    }
}
