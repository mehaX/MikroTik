﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MikroTik.Application.Servers.Models;
using MikroTik.Application.Servers.Queries;
using MikroTik.WebApi.Infrastructure;

namespace MikroTik.WebApi.Controllers.Servers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : BaseController
    {
        public ServersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ActionResult<List<ServerModel>>> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllServersQuery()));
        }

        [HttpGet("{serverId}")]
        public async Task<ActionResult<ServerModel>> Get([FromRoute] int serverId)
        {
            return Ok(await _mediator.Send(new GetServerQuery() {Id = serverId}));
        }
    }
}