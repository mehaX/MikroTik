using System;
using System.Collections.Generic;
using System.Linq;
using MikroTik.Domain.Entities;
using MikroTik.Domain.ValueObjects;
using MikroTik.Infrastructure.Tik4Net.Objects;
using tik4net.Objects.Ip.DhcpServer;

namespace MikroTik.Application.Devices.Models
{
    public class DeviceModel
    {
        public int? Id { get; set; }
        public int? PersonId { get; set; }
        public string Name { get; set; }
        public string HostName { get; set; }
        public bool Connected { get; set; }
        public TimeSpan? Uptime { get; set; }
        public IPAddress Address { get; set; }
        public string MacAddress { get; set; }
        public TransferData TransferData { get; set; } = new TransferData(0, 0);

        public static List<DeviceModel> GenerateDevices(List<Device> devices,
            List<DhcpServerLease> leases,
            List<HotspotHost> hosts,
            IPAddress subnetAddress = null)
        {
            if (subnetAddress != null)
            {
                leases = leases.Where(lease => subnetAddress.UnderSubnet(new IPAddress(lease.Address))).ToList();
                hosts = hosts.Where(host => subnetAddress.UnderSubnet(new IPAddress(host.Address))).ToList();
            }

            return leases
                .Select(lease =>
                {
                    var newDevice = new DeviceModel()
                    {
                        Address = new IPAddress(lease.Address),
                        MacAddress = lease.MacAddress
                    };
                    var host = hosts.FirstOrDefault(h => h.Address == lease.Address);
                    if (host != null)
                    {
                        newDevice.Connected = true;
                        newDevice.Uptime = host.UpTime;
                        newDevice.TransferData = new TransferData(host.BytesIn, host.BytesOut);

                        hosts.Remove(host);
                    }

                    var device = devices.FirstOrDefault(d => d.Address == lease.Address);
                    if (device != null)
                    {
                        newDevice.Id = device.Id;
                        newDevice.PersonId = device.PersonId;
                        newDevice.Name = device.Name;

                        devices.Remove(device);
                    }
                    else
                    {
                        newDevice.Name = lease.HostName;
                    }

                    return newDevice;
                })
                .Concat(devices.Select(device => new DeviceModel
                {
                    Id = device.Id,
                    Name = device.Name,
                    Address = new IPAddress(device.Address),
                    Connected = false,
                    MacAddress = device.MacAddress
                }))
                .ToList();
        }
    }
}
