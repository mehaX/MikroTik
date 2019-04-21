using System.Collections.Generic;
using MediatR;
using MikroTik.Application.People.Models;

namespace MikroTik.Application.People.Queries
{
    public class GetAllPeopleQuery : IRequest<List<PersonModel>>
    {
        public int ServerId { get; set; }
    }
}
