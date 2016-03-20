using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.HAL;

namespace Input
{
    public class KeyboardDriver
    {
        public PS2Keyboard keyboard;

        public KeyboardDriver()
        {
            keyboard = new PS2Keyboard();
        }

        public String readKey()
        {
            return keyboard.ReadKey().KeyChar.ToString();
        }

    }
}
