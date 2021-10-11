using AMath;
using System.Collections.Generic;

namespace Visualizer
{
    public class Face
    {
        public List<int> Points;
        public Vector3 Normal;

        public Face(params int[] Points)
        {
            this.Points = new List<int>(Points);
        }
    }
}
