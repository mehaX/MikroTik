using System.Collections.Generic;
using System.Linq;
using MikroTik.Application.Devices.Models;
using MikroTik.Domain.Entities;
using MikroTik.Domain.ValueObjects;
using tik4net.Objects.Queue;

namespace MikroTik.Application.People.Models
{
    public class PersonModel
    {
        public int? Id { get; set; }
        public int ServerId { get; set; }
        public string Name { get; set; }
        public IPAddress Address { get; set; }
        public TransferData TransferData { get; set; } = new TransferData(0, 0);

        public List<DeviceModel> Devices { get; set; } = new List<DeviceModel>();

        public static PersonModel CreateModel(Person person, List<DeviceModel> deviceModels,
            int? serverId = null, QueueSimple queue = null)
        {
            return new PersonModel()
            {
                Id = person?.Id,
                ServerId = person?.ServerId ?? serverId.GetValueOrDefault(),
                Name = person?.Name ?? queue?.Name,
                Address = new IPAddress(person?.Address ?? queue?.Target),
                TransferData = new TransferData(queue?.Rate),
                Devices = deviceModels,
            };
        }

        public static List<PersonModel> GeneratePeople(List<Person> people,
            Server server,
            List<DeviceModel> deviceModels,
            List<QueueSimple> queues)
        {
            return queues
                .Select(queue =>
                {
                    var person = people.FirstOrDefault(p => p.Address == queue.Target);
                    if (person != null)
                    {
                        people.Remove(person);
                    }

                    var ipAddress = new IPAddress(queue.Target);
                    var personDevices = deviceModels.Where(d =>
                        (person != null && d.PersonId == person.Id) || d.Address.UnderSubnet(ipAddress)).ToList();

                    return CreateModel(person, personDevices, server.Id, queue);
                })
                .Concat(people.Select(person =>
                {
                    var personDevices = deviceModels
                        .Where(d => d.PersonId == person.Id || d.Address.UnderSubnet(person.Address)).ToList();

                    return CreateModel(person, personDevices);
                }))
                .ToList();
        }
    }
}
