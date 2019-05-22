using MediatR;

namespace MikroTik.Application.People.Notifications
{
    public class SendPeopleNotification : INotification
    {
        public int ServerId { get; set; }
    }
}