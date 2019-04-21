using MediatR;
using MikroTik.Application.People.Models;

namespace MikroTik.Application.People.Queries
{
    public class GetPersonQuery : IRequest<PersonModel>
    {
        public int Id { get; set; }
    }
}
