using AMath;

namespace Visualizer
{
    public class Vertex
    {
        public Vector3 Position { get; set; }

        public Vertex()
        {
            Position = new Vector3();
        }

        public Vertex(Vector3 v3)
        {
            Position = v3;
        }

        public Vertex(double x, double y, double z)
        {
            Position = new Vector3(x, y, z);
        }

        public Vertex(Vector4 v4)
        {
            Position = new Vector3(v4);
        }

        public override string ToString()
        {
            return Position.X + " " + Position.Y + " " + Position.Z;
        }
    }
}
