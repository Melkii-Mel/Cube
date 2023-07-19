namespace ULTRACUBE
{
    internal class Timer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deltaTime">milliseconds</param>
        public delegate void TickEventHandler(int deltaTime);
        public event TickEventHandler? OnTick;

        private int _timerInterval = 100;

        /// <summary>
        /// in milliseconds
        /// </summary>
        public int Interval
        {
            get
            {
                return _timerInterval;
            }
            set
            {
                _timerInterval = value;


            }
        }
        public bool Running { get; set; }

        public Timer(int interval, bool enableOnStart)
        {
            Console.CancelKeyPress += (sender, e) => Stop();
            _timerInterval = interval;
            if (enableOnStart)
            {
                Start();
            }
        }

        async public void Start()
        {
            if (Running)
            {
                return;
            }
            Running = true;
            await Task.Run(Tick);
        }
        public void Stop()
        {
            Running = false;
        }
        async public Task Tick()
        {
            while (Running)
            {
                OnTick?.Invoke(_timerInterval);
                await Task.Delay(_timerInterval);
            }
        }
    }
}
