using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Devices.Models;
using MikroTik.Application.Exceptions;
using MikroTik.Application.People.Models;
using MikroTik.Domain.ValueObjects;
using MikroTik.Infrastructure.Tik4Net;
using MikroTik.Infrastructure.Tik4Net.Objects;
using MikroTik.Persistence;
using tik4net.Objects;
using tik4net.Objects.Ip.DhcpServer;

namespace MikroTik.Application.People.Queries.QueryHandlers
{
    public class GetPersonQueryHandler : IRequestHandler<GetPersonQuery, PersonModel>
    {
        private MikroTikDbContext _dbContext;
        private TikService _tikService;

        public GetPersonQueryHandler(MikroTikDbContext dbContext, TikService tikService)
        {
            _dbContext = dbContext;
            _tikService = tikService;
        }

        public async Task<PersonModel> Handle(GetPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _dbContext.People.FirstOrDefaultAsync(p => p.Id == request.Id);
            if (person == null)
            {
                throw new NotFoundException(nameof(person), request.Id);
            }

            var devices = await _dbContext.Devices.Where(d => d.PersonId == person.Id).ToListAsync();
            var server = await _dbContext.Servers.FirstOrDefaultAsync(s => s.Id == person.ServerId);

            _tikService.CreateConnection(server);
            var leases = _tikService.Connection.LoadAll<DhcpServerLease>().ToList();
            var hosts = _tikService.Connection.LoadAll<HotspotHost>().ToList();

            var deviceModels = DeviceModel.GenerateDevices(devices, leases, hosts, new IPAddress(person.Address));

            return PersonModel.CreateModel(person, deviceModels);
        }
    }
}
