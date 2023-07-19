namespace ULTRACUBE
{
    internal class Cube
    {
        public readonly Side Side0;
        public readonly Side Side1;
        public readonly Side Side2;
        public readonly Side Side3;

        private int _rotation;
        public int Rotation
        {
            get
            {
                return _rotation;
            }
            set
            {
                _rotation = value;
                if (_rotation < 0) Rotation += 360;
                if (_rotation > 360) Rotation -= 360;
                Side0.RotationX = _rotation;
                Side1.RotationX = _rotation + 90;
                Side2.RotationX = _rotation + 180;
                Side3.RotationX = _rotation + 270;
            }
        }
        private int _size;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
                Side0.Size = _size;
                Side1.Size = _size;
                Side2.Size = _size;
                Side3.Size = _size;
            }
        }
        public Cube(int rotation, int size)
        {
            Side0 = new(rotation, size);
            Side1 = new(rotation + 90, size);
            Side2 = new(rotation + 180, size);
            Side3 = new(rotation + 270, size);
            Size = size;
        }
        public void Rotate(int degrees)
        {
            Rotation += degrees;
        }
    }
}
