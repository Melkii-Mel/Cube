namespace ULTRACUBE.src.Cubes
{
    internal class Side
    {
        private delegate void PropertiesUpdateEventHandler();
        private event PropertiesUpdateEventHandler OnUpdate;
        private int _rotX;
        private int _size;
        private List<string> _text = new();
        public List<string> Text { get { return _text; } }

        public Side(int rotation, int size)
        {
            RotationX = rotation;
            Size = size;
            OnUpdate += Refresh;

            Refresh();
        }

        public int RotationX
        {
            get
            {
                return _rotX;
            }
            set
            {
                _rotX = value;
                while (_rotX >= 360) _rotX -= 360;
                while (_rotX < 0) _rotX += 360;
                OnUpdate?.Invoke();
            }
        }
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                OnUpdate?.Invoke();
            }
        }

        public void RotateX(int degrees)
        {
            RotationX += degrees;
        }

        private void Refresh()
        {
            List<string> result = new();
            for (int i = 0; i < _size; i++)
            {
                string str = "";
                for (int j = 0; j < GetCoefficient(_size); j++)
                {
                    int index = GetCoefficient(Brightness.Char.Count - 1);
                    str += Brightness.Char[index];
                    str += ' ';
                }
                result.Add(str);
            }
            _text = result;
        }

        private int GetCoefficient(int value)
        {
            float coeff = 0;
            if (_rotX < 90)
            {
                coeff = MathF.Sqrt(1f - (_rotX + 90) % 90 / 90f);
            }
            else if (_rotX > 270)
            {
                coeff = MathF.Sqrt((_rotX + 90) % 90 / 90f);
            }
            return (int)(coeff * value);
        }
    }
}
