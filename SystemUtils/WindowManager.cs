using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Display;
using Windows;
using Input;

namespace SystemUtils
{
    public class WindowManager
    {
        public static void drawWindows(BufferedDisplayDriver display, IconRenderer ir, FontRenderer fr)
        {
            NotepadWindow.renderWindow(display, ir, fr);
        }

        public static void handleMouse(MouseDriver mouse)
        {
            NotepadWindow.handleMouse(mouse);
        }
    }
}
