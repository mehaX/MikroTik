using System;
using tik4net.Objects;

namespace MikroTik.Infrastructure.Tik4Net.Objects
{
    [TikEntity("/ip/hotspot/host", IsReadOnly = true)]
    public class HotspotHost
    {
        [TikProperty(".id", IsMandatory = true, IsReadOnly = true)]
        public string Id { get; private set; }

        [TikProperty("address", IsReadOnly = true)]
        public string Address { get; set; }

        [TikProperty("mac-address", IsReadOnly = true)]
        public string MacAddress { get; set; }

        [TikProperty("to-address", IsReadOnly = true)]
        public string ToAddress { get; set; }

        [TikProperty("server", IsReadOnly = true)]
        public string Server { get; set; }

        [TikProperty("uptime", IsReadOnly = true)]
        public TimeSpan UpTime { get; set; }

        [TikProperty("idle-time", IsReadOnly = true)]
        public TimeSpan IdleTime { get; set; }

        [TikProperty("keepalive", IsReadOnly = true)]
        public TimeSpan KeepAlive { get; set; }

        [TikProperty("host-dead", IsReadOnly = true)]
        public string HostDead { get; set; }

        [TikProperty("bytes-in", IsReadOnly = true)]
        public long BytesIn { get; private set; }

        [TikProperty("bytes-out", IsReadOnly = true)]
        public long BytesOut { get; private set; }

        [TikProperty("packets-in", IsReadOnly = true)]
        public string PacketsIn { get; private set; }

        [TikProperty("packets-out", IsReadOnly = true)]
        public string PacketsOut { get; private set; }

        [TikProperty("found-by", IsReadOnly = true)]
        public string FoundBy { get; private set; }

        [TikProperty("authorized", IsReadOnly = true)]
        public bool Authorized { get; private set; }

        [TikProperty("bypassed", IsReadOnly = true)]
        public bool Bypassed { get; private set; }
    }
}
