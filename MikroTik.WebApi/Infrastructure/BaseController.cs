using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MikroTik.WebApi.Infrastructure
{
    public class BaseController : Controller
    {
        protected IMediator _mediator;

        protected BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
