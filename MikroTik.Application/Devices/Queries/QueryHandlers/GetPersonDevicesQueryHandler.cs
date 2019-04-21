using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Devices.Models;
using MikroTik.Application.Exceptions;
using MikroTik.Domain.ValueObjects;
using MikroTik.Infrastructure.Tik4Net;
using MikroTik.Infrastructure.Tik4Net.Objects;
using MikroTik.Persistence;
using tik4net.Objects;
using tik4net.Objects.Ip.DhcpServer;

namespace MikroTik.Application.Devices.Queries.QueryHandlers
{
    public class GetPersonDevicesQueryHandler : IRequestHandler<GetPersonDevicesQuery, List<DeviceModel>>
    {
        private MikroTikDbContext _dbContext;
        private TikService _tikService;

        public GetPersonDevicesQueryHandler(MikroTikDbContext dbContext, TikService tikService)
        {
            _dbContext = dbContext;
            _tikService = tikService;
        }

        public async Task<List<DeviceModel>> Handle(GetPersonDevicesQuery request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == request.PersonId);
            if (person == null)
            {
                throw new NotFoundException(nameof(person), request.PersonId);
            }

            var server = await _dbContext.Servers.FirstOrDefaultAsync(s => s.Id == person.ServerId);
            var devices = await _dbContext.Devices.Where(d => d.PersonId == person.Id).ToListAsync();

            _tikService.CreateConnection(server);
            var leases = _tikService.Connection.LoadAll<DhcpServerLease>().ToList();
            var hosts = _tikService.Connection.LoadAll<HotspotHost>().ToList();

            return DeviceModel.GenerateDevices(devices, leases, hosts, new IPAddress(person.Address));
        }
    }
}
