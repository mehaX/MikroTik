using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MikroTik.Application.Devices.Commands;
using MikroTik.Application.Devices.Models;
using MikroTik.Application.Devices.Queries;
using MikroTik.WebApi.Infrastructure;

namespace MikroTik.WebApi.Controllers.Servers.People
{
    [Route("api/people/{personId}/[controller]")]
    [ApiController]
    public class DevicesController : BaseController
    {
        public DevicesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<DeviceModel>>> GetAll([FromRoute] int serverId, [FromRoute] int personId)
        {
            return await Mediator.Send(new GetPersonDevicesQuery {PersonId = personId});
        }

        [HttpPatch("{deviceId}/rename")]
        public async Task<ActionResult<Unit>> Rename([FromRoute] int deviceId, [FromBody] RenameDeviceCommand command)
        {
            command.Id = deviceId;
            return await Mediator.Send(command);
        }
    }
}
