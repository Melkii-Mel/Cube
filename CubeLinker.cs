namespace ULTRACUBE
{
    internal class CubeLinker
    {
        public Cube Cube;

        public CubeLinker(Cube cube)
        {
            Cube = cube;
        }
        public string LinkCube()
        {
            List<string> strLeft = new();
            List<string> strRight = new();

            #region left side
            if (Cube.Side0.RotationX < 90)
            {
                strLeft = Cube.Side0.Text;
            }
            if (Cube.Side1.RotationX < 90)
            {
                strLeft = Cube.Side1.Text;
            }
            if (Cube.Side2.RotationX < 90)
            {
                strLeft = Cube.Side2.Text;
            }
            if (Cube.Side3.RotationX < 90)
            {
                strLeft = Cube.Side3.Text;
            }
            #endregion
            #region right side

            if (Cube.Side0.RotationX >= 270)
            {
                strRight = Cube.Side0.Text;
            }
            if (Cube.Side1.RotationX >= 270)
            {
                strRight = Cube.Side1.Text;
            }
            if (Cube.Side2.RotationX >= 270)
            {
                strRight = Cube.Side2.Text;
            }
            if (Cube.Side3.RotationX >= 270)
            {
                strRight = Cube.Side3.Text;
            }

            #endregion

            return LinkSides(strLeft, strRight);
        }

        private static string LinkSides(List<string> part0, List<string> part1)
        {
            string result = string.Empty;
            string border = new(' ', (Console.WindowWidth - part0[0].Length - part1[0].Length) / 2);
            for (int i = 0; i < part0.Count; i++)
            {
                result += border;
                result += part0[i];
                result += part1[i];
                result += border;
                result += '\n';
            }
            return result;
        }
    }
}
