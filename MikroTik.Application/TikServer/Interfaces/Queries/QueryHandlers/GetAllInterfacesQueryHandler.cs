using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Servers.Queries;
using MikroTik.Application.TikServer.Interfaces.Models;
using MikroTik.Domain.Entities;
using MikroTik.Infrastructure.Tik4Net;
using MikroTik.Persistence;
using tik4net.Objects;
using tik4net.Objects.Interface;

namespace MikroTik.Application.TikServer.Interfaces.Queries.QueryHandlers
{
    public class GetAllInterfacesQueryHandler : IRequestHandler<GetAllInterfacesQuery, List<InterfaceModel>>
    {
        private MikroTikDbContext _dbContext;
        private readonly TikService _tikService;

        public GetAllInterfacesQueryHandler(MikroTikDbContext dbContext, TikService tikService)
        {
            _dbContext = dbContext;
            _tikService = tikService;
        }

        public async Task<List<InterfaceModel>> Handle(GetAllInterfacesQuery request, CancellationToken cancellationToken)
        {
            var server = await _dbContext.Servers.FirstOrDefaultAsync(s => s.Id == request.ServerId);

            return _tikService
                .CreateConnection(server)
                .Connection
                .LoadAll<Interface>()
                .AsQueryable()
                .Select(InterfaceModel.Projection)
                .ToList();
        }
    }
}
