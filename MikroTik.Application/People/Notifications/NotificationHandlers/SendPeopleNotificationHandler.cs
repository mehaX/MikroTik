using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using MikroTik.Application.People.Hubs;
using MikroTik.Application.People.Queries;

namespace MikroTik.Application.People.Notifications.NotificationHandlers
{
    public class SendPeopleNotificationHandler : INotificationHandler<SendPeopleNotification>
    {
        private Mediator _mediator;
        private PeopleHub _peopleHub;

        public SendPeopleNotificationHandler(Mediator mediator, PeopleHub peopleHub)
        {
            _mediator = mediator;
            _peopleHub = peopleHub;
        }
        
        public async Task Handle(SendPeopleNotification notification, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllPeopleQuery() {ServerId = notification.ServerId});

            await _peopleHub.Clients
                .Group("server-" + notification.ServerId)
                .SendAsync("people", result, cancellationToken);
        }
    }
}