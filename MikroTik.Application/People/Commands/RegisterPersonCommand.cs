using System.Collections.Generic;
using MediatR;
using MikroTik.Application.Devices.Models;
using MikroTik.Application.People.Models;
using MikroTik.Domain.ValueObjects;

namespace MikroTik.Application.People.Commands
{
    public class RegisterPersonCommand : IRequest<PersonModel>
    {
        public int ServerId { get; set; }
        public string Name { get; set; }
        public IPAddress Address { get; set; }

        public List<DeviceModel> Devices { get; set; }
    }
}
