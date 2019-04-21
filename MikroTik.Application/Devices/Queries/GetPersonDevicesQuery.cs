using System.Collections.Generic;
using MediatR;
using MikroTik.Application.Devices.Models;

namespace MikroTik.Application.Devices.Queries
{
    public class GetPersonDevicesQuery : IRequest<List<DeviceModel>>
    {
        public int PersonId { get; set; }
    }
}
