using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Exceptions;
using MikroTik.Persistence;

namespace MikroTik.Application.Devices.Commands.CommandHandlers
{
    public class RenameDeviceCommandHandler : IRequestHandler<RenameDeviceCommand, Unit>
    {
        private MikroTikDbContext _dbContext;

        public RenameDeviceCommandHandler(MikroTikDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(RenameDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _dbContext.Devices.FirstOrDefaultAsync(d => d.Id == request.Id);
            if (device == null)
            {
                throw new NotFoundException(nameof(device), request.Id);
            }

            device.Name = request.Name;
            await _dbContext.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
