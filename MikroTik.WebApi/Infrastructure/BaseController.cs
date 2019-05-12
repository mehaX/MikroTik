using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MikroTik.WebApi.Infrastructure
{
    public abstract class BaseController : Controller
    {
        protected readonly IMediator Mediator;

        protected BaseController(IMediator mediator)
        {
            Mediator = mediator;
        }
    }
}
