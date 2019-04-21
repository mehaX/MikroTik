using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Servers.Models;
using MikroTik.Persistence;

namespace MikroTik.Application.Servers.Queries.QueryHandlers
{
    public class GetAllServersQueryHandler : IRequestHandler<GetAllServersQuery, List<ServerModel>>
    {
        private readonly MikroTikDbContext _context;

        public GetAllServersQueryHandler(MikroTikDbContext context)
        {
            _context = context;
        }

        public async Task<List<ServerModel>> Handle(GetAllServersQuery request, CancellationToken cancellationToken)
        {
            return await _context.Servers.Select(ServerModel.Projection).ToListAsync();
        }
    }
}
