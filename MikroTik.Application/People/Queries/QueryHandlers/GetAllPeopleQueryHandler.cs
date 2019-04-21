using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.Devices.Models;
using MikroTik.Application.People.Models;
using MikroTik.Infrastructure.Tik4Net;
using MikroTik.Infrastructure.Tik4Net.Objects;
using MikroTik.Persistence;
using tik4net.Objects;
using tik4net.Objects.Ip.DhcpServer;
using tik4net.Objects.Queue;

namespace MikroTik.Application.People.Queries.QueryHandlers
{
    public class GetAllPeopleQueryHandler : IRequestHandler<GetAllPeopleQuery, List<PersonModel>>
    {
        private MikroTikDbContext _dbContext;
        private TikService _tikService;

        public GetAllPeopleQueryHandler(MikroTikDbContext dbContext, TikService tikService)
        {
            _dbContext = dbContext;
            _tikService = tikService;
        }

        public async Task<List<PersonModel>> Handle(GetAllPeopleQuery request, CancellationToken cancellationToken)
        {
            // Retrieve server data from db
            var server = await _dbContext.Servers.FirstOrDefaultAsync(s => s.Id == request.ServerId);

            // Retrieve server's people from db
            var people = await _dbContext.People.Where(p => p.ServerId == server.Id).ToListAsync();

            // Retrieve server's devices from db
            var peopleIds = people.Select(p => p.Id).ToList();
            var devices = await _dbContext.Devices.Where(d => peopleIds.Contains(d.PersonId)).ToListAsync();

            _tikService.CreateConnection(server); // Create mikrotik connection
            var queues = _tikService.Connection.LoadAll<QueueSimple>().ToList(); // Retrieve server's queues from mikrotik
            var leases = _tikService.Connection.LoadAll<DhcpServerLease>().ToList(); // Retrieve server's DHCP Server leases from mikrotik
            var hosts = _tikService.Connection.LoadAll<HotspotHost>().ToList(); // Retrieve server's hosts from mikrotik

            // Join device models
            var deviceModels = DeviceModel.GenerateDevices(devices, leases, hosts);

            // Join person models
            var personModels = PersonModel.GeneratePeople(people, server, deviceModels, queues);

            return personModels;
        }
    }
}
