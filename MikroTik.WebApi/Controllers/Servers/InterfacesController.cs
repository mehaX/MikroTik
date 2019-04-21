using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MikroTik.Application.TikServer.Interfaces.Models;
using MikroTik.Application.TikServer.Interfaces.Queries;
using MikroTik.WebApi.Infrastructure;

namespace MikroTik.WebApi.Controllers.Servers
{
    [Route("api/servers/{serverId}/[controller]")]
    [ApiController]
    public class InterfacesController : BaseController
    {
        public InterfacesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<InterfaceModel>>> GetAll([FromRoute] int serverId)
        {
            return Ok(await _mediator.Send(new GetAllInterfacesQuery {ServerId = serverId}));
        }
    }
}
