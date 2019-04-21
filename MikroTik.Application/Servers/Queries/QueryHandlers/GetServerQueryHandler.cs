using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Exceptions;
using MikroTik.Application.Servers.Models;
using MikroTik.Persistence;

namespace MikroTik.Application.Servers.Queries.QueryHandlers
{
    public class GetServerQueryHandler : IRequestHandler<GetServerQuery, ServerModel>
    {
        private readonly MikroTikDbContext _context;

        public GetServerQueryHandler(MikroTikDbContext context)
        {
            _context = context;
        }

        public async Task<ServerModel> Handle(GetServerQuery request, CancellationToken cancellationToken)
        {
            var entity = await _context.Servers.FirstOrDefaultAsync(s => s.Id == request.Id, cancellationToken: cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(GetServerQuery), request.Id);
            }

            return ServerModel.Create(entity);
        }
    }
}
 