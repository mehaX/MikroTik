using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MikroTik.Application.People.Models;
using MikroTik.Application.People.Queries;
using MikroTik.Domain.Entities;
using MikroTik.Persistence;

namespace MikroTik.Application.People.Commands.CommandHandlers
{
    public class RegisterPersonCommandHandler : IRequestHandler<RegisterPersonCommand, PersonModel>
    {
        private MikroTikDbContext _dbContext;
        private IMediator _mediator;

        public RegisterPersonCommandHandler(MikroTikDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<PersonModel> Handle(RegisterPersonCommand request, CancellationToken cancellationToken)
        {
            var entityPerson = new Person
            {
                ServerId = request.ServerId,
                Name = request.Name,
                Address = request.Address.Value
            };
            await _dbContext.People.AddAsync(entityPerson);
            await _dbContext.SaveChangesAsync();

            var entityDevices = request.Devices.Select(device => new Device
            {
                PersonId = entityPerson.Id,
                Name = device.Name,
                Address = device.Address.Value,
                MacAddress = device.MacAddress
            });
            await _dbContext.Devices.AddRangeAsync(entityDevices);
            await _dbContext.SaveChangesAsync();

            return await _mediator.Send(new GetPersonQuery() { Id = entityPerson.Id });
        }
    }
}
