using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MikroTik.Application.People.Notifications;
using MikroTik.Persistence;

namespace MikroTik.Application.People.Services
{
    public class PeopleService : IPeopleService
    {
        private MikroTikDbContext _dbContext;
        private IMediator _mediator;
        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        public DateTime? TimerStarted { get; set; }
        
        public PeopleService(MikroTikDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public void Start()
        {
            if (TimerStarted == null)
            {
                TimerStarted = DateTime.Now;
                _autoResetEvent = new AutoResetEvent(false);
                _timer = new Timer(Execute, _autoResetEvent, 1000, 2000);
            }
        }

        private void Execute(object stateInfo)
        {
            // TODO: Fix the disposable bug
//            Task.Run(async () =>
//            {
//                var servers = await _dbContext.Servers.ToListAsync();
//
//                foreach (var server in servers)
//                {
//                    await _mediator.Publish(new SendPeopleNotification() {ServerId = server.Id});
//                }
//            }).Wait();
            
            if (TimerStarted != null && (DateTime.Now - TimerStarted)?.Seconds > 60)
            {
                _timer.Dispose();
            }
        }
    }
}