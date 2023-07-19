using ULTRACUBE.src.Cubes;

namespace ULTRACUBE.src.Actions
{
    internal class Autorotation
    {
        public readonly Cube Cube;
        public int RotationSpeed { get; set; }

        private readonly Timer _timer;
        /// <summary>
        /// rotates cube automatically
        /// </summary>
        /// <param name="cube">Cube rotate to</param>
        /// <param name="rotationSpeed">degrees per frame</param>
        /// <param name="interval">in ms</param>
        public Autorotation(Cube cube, int rotationSpeed, Timer timer)
        {
            Cube = cube;
            RotationSpeed = rotationSpeed;
            _timer = timer;
            _timer.OnTick += Rotate;
        }
        private void Rotate(int _)
        {
            Cube.Rotate(RotationSpeed);
        }
    }
}
