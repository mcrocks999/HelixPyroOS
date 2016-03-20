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
    public class NotepadWindow
    {
        public static int x = 0;
        public static int y = 0;
        public static int width = 150;
        public static int height = 100;

        public static Boolean isVisible = false;

        public static void reset()
        {
            isVisible = true;
            x = 0;
            y = 0;
            width = 150;
            height = 100;
        }

        public static void renderWindow(BufferedDisplayDriver display, IconRenderer ir, FontRenderer fr)
        {
            if (isVisible)
            {
                for (int i = 0; i <= width; i++)
                {
                    for (int i2 = 0; i2 <= height; i2++)
                    {
                        display.setPixel(i + x, i2 + y, 63);
                    }
                }
                for (int i = 0; i <= 20; i++)
                {
                    for (int i2 = 0; i2 <= 20; i2++)
                    {
                        display.setPixel(x + width - i, y + height - i2, 63);
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

                fr.renderString(x + 10, y + 12, "NOTEPAD");
            }
        }

        private static Boolean held = false;

        public static void handleMouse(MouseDriver mouse)
        {
            if (isVisible)
            {
                if (mouse.LeftClickState())
                {
                    if (held)
                    {
                        if (mouse.X() + width < 320)
                        {
                            x = mouse.X();
                        }
                        else
                        {
                            x = 320 - width;
                        }
                        if (mouse.Y() + height < 200)
                        {
                            y = mouse.Y();
                        }
                        else
                        {
                            y = 200 - height;
                        }
                    }
                    else
                    {
                        if (mouse.X() > (x + width - 20) && mouse.X() < (x + width) && mouse.Y() > y && mouse.Y() < y + 20)
                        {
                            isVisible = false;
                        }
                        else
                        {
                            if (mouse.X() > x && mouse.X() < (x + width - 60) && mouse.Y() > y && mouse.Y() < y + 20)
                            {
                                held = true;
                            }
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
}
