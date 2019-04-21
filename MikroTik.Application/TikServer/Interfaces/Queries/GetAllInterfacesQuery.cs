using System.Collections.Generic;
using MediatR;
using MikroTik.Application.TikServer.Infrastructure;
using MikroTik.Application.TikServer.Interfaces.Models;

namespace MikroTik.Application.TikServer.Interfaces.Queries
{
    public class GetAllInterfacesQuery : TikServerQuery, IRequest<List<InterfaceModel>>
    {
    }
}
