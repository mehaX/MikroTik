using System;
using System.Linq;

namespace MikroTik.Domain.ValueObjects
{
    public class IPAddress
    {
        public string Value { get; }

        public int[] Segments { get; }
        public int? Subnet { get; }

        public IPAddress(string value)
        {
            Value = value;

            var parts = value.Split('/');
            var segments = parts[0].Split('.');

            Segments = null;
            Subnet = null;
            try
            {
                if (segments.Length == 4)
                {
                    Segments = segments.Select(seg => Convert.ToInt32(seg)).ToArray();
                }

                if (parts.Length > 0)
                {
                    Subnet = Convert.ToInt32(parts[1]);
                }
            }
            catch (Exception e)
            {
                // ignored
            }
        }

        public bool UnderSubnet(string address)
        {
            return UnderSubnet(new IPAddress(address));
        }

        public bool UnderSubnet(IPAddress address)
        {
            if (Segments != null && address.Segments != null)
            {
                return Segments[0] == address.Segments[0] &&
                       Segments[1] == address.Segments[1] &&
                       Segments[2] == address.Segments[2];
            }

            return false;
        }
    }
}
