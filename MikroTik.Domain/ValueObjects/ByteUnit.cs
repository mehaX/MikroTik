using System;

namespace MikroTik.Domain.ValueObjects
{
    public class ByteUnit
    {
        private static readonly string[] Units = new string[]{ "bytes", "KB", "MB", "GB", "TB" };
        private readonly long _value;

        public ByteUnit(long value)
        {
            _value = value;
        }

        public long BytesValue => _value;

        public string HumanValue
        {
            get
            {
                double result = _value;
                string unit = Units[0];
                int index = 0;
                while(result >= 1024)
                {
                    unit = Units[++index];
                    result /= 1024;
                }

                return $"{Math.Round(result, 2)} {unit}";
            }
        }
    }
}
