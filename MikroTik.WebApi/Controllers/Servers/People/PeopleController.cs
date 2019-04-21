using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MikroTik.Application.People.Commands;
using MikroTik.Application.People.Models;
using MikroTik.Application.People.Queries;
using MikroTik.WebApi.Infrastructure;

namespace MikroTik.WebApi.Controllers.Servers.People
{
    [Route("api/servers/{serverId}/[controller]")]
    [ApiController]
    public class PeopleController : BaseController
    {
        public PeopleController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<PersonModel>>> GetAll([FromRoute] int serverId)
        {
            return Ok(await _mediator.Send(new GetAllPeopleQuery(){ ServerId = serverId }));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> Get([FromRoute] int id)
        {
            return Ok(await _mediator.Send(new GetPersonQuery() {Id = id}));
        }

        [HttpPost]
        public async Task<ActionResult<PersonModel>> Post([FromBody] RegisterPersonCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
