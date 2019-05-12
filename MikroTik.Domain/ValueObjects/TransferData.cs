using System;

namespace MikroTik.Domain.ValueObjects
{
    public class TransferData
    {
        public ByteUnit Tx { get; set; }
        public ByteUnit Rx { get; set; }

        public TransferData(string value)
        {
            try
            {
                var data = value.Split('/');
                Tx = new ByteUnit(Convert.ToInt32(data[0]));
                Rx = new ByteUnit(Convert.ToInt32(data[1]));
            }
            catch (Exception e)
            {
                Tx = new ByteUnit(0);
                Rx = new ByteUnit(0);
            }
        }

        public TransferData(long tx, long rx)
        {
            Tx = new ByteUnit(tx);
            Rx = new ByteUnit(rx);
        }
    }
}
