using System.Runtime.InteropServices;

namespace ULTRACUBE
{
    internal class Cursor
    {

        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        public static Point GetPosition()
        {
            GetCursorPos(out Point lpPoint);
            return lpPoint;
        }
    }
}
