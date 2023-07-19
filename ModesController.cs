namespace ULTRACUBE
{
    internal class ModesController
    {
        private CubeLinker _linker;
        private Cube _cube;
        private Timer _timer = new(1000 / 60, true);
        private Autorotation? _autorotation;
        private ConsolePrinter _printer;
        public ModesController(Cube cube, Mode mode)
        {
            _linker = new(cube);
            _cube = cube;
            CurrentMode = mode;
            _printer = new();
        }

        public enum Mode
        {
            Auto,
            RotationToCursor
        }
        public Mode CurrentMode { get; set; }
        public void Start()
        {
            if (CurrentMode == Mode.Auto)
            {
                _autorotation = new(_cube, 5, 1000 / 60, _timer);
                _timer.OnTick += UpdateAutoRotation;
            }
            if (CurrentMode == Mode.RotationToCursor)
            {
                _timer.OnTick += UpdateRotationToCursor;
            }
        }
        private void UpdateAutoRotation(int _)
        {
            _printer.SetScreenSize();
            _printer.PrintFrame(_linker.LinkCube());
        }
        private void UpdateRotationToCursor(int _)
        {
            _cube.Rotation = -Cursor.GetPosition().X / 5;
            _printer.SetScreenSize();
            _printer.PrintFrame(_linker.LinkCube());
        }
    }
}
