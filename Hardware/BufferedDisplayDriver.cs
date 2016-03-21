using Sys = Cosmos.System;
using System.Drawing;

namespace Display
{
    public class BufferedDisplayDriver: DisplayDriver
    {
        byte[] buffer = new byte[320 * 200];

        public BufferedDisplayDriver():base()
        {
        }

        public void setPallete(int index, Color color)
        {
            base.screen.SetPaletteEntry(index, color);
        }

        override public void setPixel(int x, int y, int c)
        {
            if (buffer[x + (y * 320)] != (byte)c)
                buffer[x + (y * 320)] = (byte)c;
            else
                buffer[x + (y * 320)] = 255;
        }

        public void setRealPixel(int x, int y, int c)
        {
            base.setPixel(x, y, c);
            buffer[x + (y * 320)] = 255;
        }

        public override byte getPixel(int x, int y)
        {
            return buffer[x+(y*320)];
        }

        public byte getPixelReal(int x, int y)
        {
            return base.getPixel(x, y);
        }

        public override void clear(int c)
        {
            for (int x = 0; x < getWidth(); x++)
            {
                for (int y=0; y< getHeight(); y++)
                {
                    if (buffer[x+(y*320)] != (byte) c)
                        buffer[x+(y*320)] = (byte)c;
                }
            }
        }

        public void clearReal (int c)
        {
            base.clear(c);
        }

        public void reDraw()
        {
            for (int x = 0; x < buffer.Length/200; x++)
            {
                for (int y = 0; y < buffer.Length/320; y++)
                {
                    if (buffer[x + (y * 320)]!=255)
                    {
                        base.setPixel(x, y, buffer[x + (y * 320)]);
                    }
                }
            }
        }

        public override void step()
        {
            reDraw();
        }

    }
}
