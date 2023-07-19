using ULTRACUBE.src.Actions;

namespace ULTRACUBE.src
{
    using static ModesController;
    internal class Program
    {
        const int SIZE = 20;
        const int DEGREES_PER_FRAME = 1;
        static int _degrees;

        static void Main()
        {
            Console.WriteLine("Select mode between automatic (A) and manual (M)");
            Mode mode = Console.ReadLine() == "A" ? Mode.Auto : Mode.RotationToCursor;
            ModesController modesController = new(new(0, SIZE), mode);
            modesController.Start();
            Thread.Sleep(int.MaxValue);
        }
    }
}