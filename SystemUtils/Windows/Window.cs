using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display;
using SystemUtils;
using Input;

namespace Windows
{
    public class Window
    {
        public int x = 0;
        public int y = 0;
        public int width = 150;
        public int height = 100;

        public void renderWindow(BufferedDisplayDriver display, IconRenderer ir, FontRenderer fr)
        {
            for (int i = 0; i <= width; i++)
            {
                for (int i2 = 0; i2 <= height; i2++)
                {
                    display.setPixel(i + x, i2 + y, 63);
                }
            }
            for (int i = 0; i <= width; i++)
            {
                display.setPixel(i + x, y, 0);
                display.setPixel(i + x, y + 20, 0);
                display.setPixel(i + x, y + height, 0);
            }
            for (int i = 0; i <= height; i++)
            {
                display.setPixel(x, y + i, 0);
                display.setPixel(x + width, y + i, 0);
            }

            ir.renderIcon(x + width - 20, y, 'X', 2);
            ir.renderIcon(x + width - 40, y, 'M', 2);
            ir.renderIcon(x + width - 60, y, '_', 2);

            fr.renderString(x + 10, y + 12, "WINDOW");
        }

        private Boolean held = false;

        public void handleMouse(MouseDriver mouse)
        {
            if (mouse.LeftClickState())
            {
                if (held)
                {
                    x = mouse.X();
                    y = mouse.Y();
                }
                else
                {
                    if (mouse.X() > x && mouse.X() < (x + width - 60) && mouse.Y() > y && mouse.Y() < y + 20)
                    {
                        held = true;
                    }
                }
            }
            else
            {
                held = false;
            }
        }
    }
}
