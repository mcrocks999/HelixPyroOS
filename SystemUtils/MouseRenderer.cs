using Cosmos;
using Cosmos.Core.Plugs;
using Input;
using Sys = Cosmos.System;

namespace Display
{
    public class MouseRenderer
    {
        private MouseDriver mouse;
        private DisplayDriver display;
        private int color;

        public MouseRenderer(MouseDriver m, DisplayDriver d, int c) {
            mouse = m;
            display = d;
            color = c;
        }

        public virtual void renderMouse ()
        {
            int X = mouse.X();
            int Y = mouse.Y();

            display.setPixel(X, Y, 0);
            display.setPixel(X+1, Y, 0);
            display.setPixel(X+2, Y, 0);
            display.setPixel(X+3, Y, 0);
            display.setPixel(X+4, Y, 0);

            display.setPixel(X, Y+1, 0);
            display.setPixel(X+1, Y+1, color);
            display.setPixel(X+2, Y+1, color);
            display.setPixel(X+3, Y+1, 0);

            display.setPixel(X, Y+2, 0);
            display.setPixel(X+1, Y+2, color);
            display.setPixel(X+2, Y+2, 0);

            display.setPixel(X, Y+3, 0);
            display.setPixel(X+1, Y+3, 0);

            display.setPixel(X, Y+4, 0);
        }

    }
}
