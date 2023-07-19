using System.Runtime.InteropServices;

namespace ULTRACUBE
{
    internal class ConsolePrinter
    {
        public void PrintFrame(string content)
        {
            try
            {
                Console.SetCursorPosition(0, 0);
                Console.WriteLine(content);
            }
            catch
            {
                Console.Clear();
            }
        }
        public void SetScreenSize()
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    Console.WindowWidth = 200;
            }
            catch { }
        }
    }
}
