using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using Display;
using SystemUtils;
using BasicOS;
using Input;
using Windows;

namespace HelixPyroOS
{
    public class HelixPyroOS : Sys.Kernel
    {
        protected int mCount = 0;
        protected int mColor = 1;
        protected int mOffset = 0;
        public BufferedDisplayDriver display;
        public KeyboardDriver keyboard;
        public MouseDriver mouse;
        public MouseRenderer mr;
        public UnixTime time = new UnixTime();

        Boolean startMenu;
        Boolean held;

        int fps = 0;
        int temp = 0;
        int second = 0;

        FontRenderer fr;
        Font f;

        public Object[] renderArray;

        public HelixPyroOS()
        { 
        }

        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted sucessfully, now starting Kernel");
            display = new BufferedDisplayDriver();
            display.init();

            f = new BasicFont();
            fr = new FontRenderer(display, f, 0);

            second = time.Second();

            keyboard = new KeyboardDriver();

            // mouse = new MouseDriver(display.getHeight(), display.getWidth());
            // mr = new MouseRenderer(mouse, display, 63);
        }

        protected override void Run()
        {
            display.clear(63);
            fr.renderString(5, 5, "HI THERE. MY NAME IS PAUL.");
            fr.renderString(5, 25, time.Hour().ToString() + ":" + time.Minute().ToString() + ":" + time.Second().ToString() + "    " + fps.ToString());

            if (second != time.Second())
            {
                fps = temp;
                temp = 0;
                second = time.Second();
            }
            else
            {
                temp++;
            }

            display.step();
        }

        /* protected override void Run()
        {
            Font f = new BasicFont();
            FontRenderer fr = new FontRenderer(display, f, 63);
            FontRenderer dfr = new FontRenderer(display, f, 0);

            IconPack ip = new BasicIconPack();
            IconRenderer ir = new IconRenderer(display, ip);

            startMenu = false;
            held = false;

            second = time.Second();
            while (true)
            {
                WindowManager.handleMouse(mouse);
                handleMouse(mouse);
                draw(fr, dfr, startMenu, ir);
                WindowManager.drawWindows(display, ir, dfr);
                mr.renderMouse();
                display.step();
        } */

        public void handleMouse(MouseDriver mouse)
        {
            if (mouse.LeftClickState())
            {
                if (held == false)
                {
                    if (mouse.X() > 0 && mouse.X() < 120 && mouse.Y() > 0 && mouse.Y() < 15)
                    {
                        startMenu = !startMenu;
                    }
                    else if (startMenu && mouse.X() > 0 && mouse.X() < 120 && mouse.Y() > 15 && mouse.Y() < 155)
                    {
                        if (mouse.X() > 25 && mouse.X() < 110 && mouse.Y() > 80 && mouse.Y() < 95)
                        {
                            Sys.Power.Reboot();
                        }
                    }
                    else
                    {
                        if (mouse.X() > 85 && mouse.X() < 105 && mouse.Y() > 15 && mouse.Y() < 25)
                        {
                            NotepadWindow.reset();
                        }
                        if (startMenu == true)
                        {
                            startMenu = false;
                        }
                    }
                    held = true;
                }
            }
            else
            {
                held = false;
            }
        }

        public void draw(FontRenderer fr, FontRenderer dfr, Boolean startMenu, IconRenderer ir)
        {
            display.clearReal(63);

            for (int i = 0; i <= 120; i++)
            {
                for (int i2 = 0; i2 <= 15; i2++)
                {
                    display.setPixel(i, i2, 25);
                }
            }
            for (int i = 120; i <= 320; i++)
            {
                for (int i2 = 0; i2 <= 15; i2++)
                {
                    display.setPixel(i, i2, 43);
                }
            }

            drawDesktop(ir, dfr);

            if (startMenu)
            {
                for (int i = 0; i <= 120; i++)
                {
                    for (int i2 = 0; i2 <= 90; i2++)
                    {
                        display.setPixel(i, i2+15, 43);
                    }
                }
                for (int i = 0; i <= 85; i++)
                {
                    for (int i2 = 0; i2 <= 15; i2++)
                    {
                        display.setPixel(i+25, i2 + 25, 25);
                    }
                }
                ir.renderIcon(10, 27, 'C', 1);
                fr.renderString(30, 30, "MY COMPUTER");

                for (int i = 0; i <= 85; i++)
                {
                    for (int i2 = 0; i2 <= 15; i2++)
                    {
                        display.setPixel(i + 25, i2 + 50, 25);
                    }
                }
                ir.renderIcon(10, 52, 'N', 1);
                fr.renderString(30, 55, "NOTEPAD");

                for (int i = 0; i <= 85; i++)
                {
                    for (int i2 = 0; i2 <= 15; i2++)
                    {
                        display.setPixel(i + 25, i2 + 80, 25);
                    }
                }
                ir.renderIcon(10, 82, 'P', 1);
                fr.renderString(30, 85, "REBOOT");
            }
            
            if (second!=time.Second())
            {
                fps = temp;
                temp = 0;
                second = time.Second();
            }
            else
            {
                temp++;
            }

            fr.renderString(5, 5, "HELIX PYRO OS");
            fr.renderString(125, 5, time.Hour().ToString() + ":" + time.Minute().ToString() + ":" + time.Second().ToString() + "    " + fps.ToString());
        }

        public void drawDesktop(IconRenderer ir, FontRenderer dfr)
        {
            ir.renderIcon(5, 20, 'C', 4);
            dfr.renderString(10, 65, "MY PC");

            ir.renderIcon(65, 20, 'N', 4);
            dfr.renderString(62, 65, "NOTEPAD");
        }
    }
}
