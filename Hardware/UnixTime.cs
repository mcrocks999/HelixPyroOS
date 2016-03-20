using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;
namespace SystemUtils
{
    public class UnixTime
    {
        public UnixTime() {}

        public int Hour()
        {
            return RTC.Hour;
        }

        public int Minute()
        {
            return RTC.Minute;
        }

        public int Second()
        {
            return RTC.Second;
        }
    }
}
