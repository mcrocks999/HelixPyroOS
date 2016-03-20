using Sys = Cosmos.System;
using Display;

namespace SystemUtils
{
    public class IconRenderer
    {
        private DisplayDriver driver;
        private IconPack iconPack;

        public IconRenderer(DisplayDriver dd, IconPack ip)
        {
            driver = dd;
            iconPack = ip;
        }

        public void renderChar(int x, int y, char c, int sm)
        {
            renderIcon(x, y, c, sm);
        }

        public void renderIcon(int x, int y, char c, int sizeMultiplier)
        {
            int[] charArray = iconPack.getChar(c);
            for (int i = 0; i < iconPack.iconPackSize * sizeMultiplier; i++)
            {
                for (int j = 0; j < iconPack.iconPackSize * sizeMultiplier; j++)
                {
                    int color = charArray[((i / sizeMultiplier) * iconPack.iconPackSize) + (j / sizeMultiplier)];
                    if (color != 0)
                    {
                        if (color == 64)
                        {
                            color = 0;
                        }
                        driver.setPixel(x + j, y + i, color);
                    }
                }
            }
        }
    }
}
