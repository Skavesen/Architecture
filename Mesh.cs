using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using AMath;
using System.Windows.Forms;

namespace Visualizer
{
    public class Mesh
    {
        public List<Vertex> Verteces;
        public List<Face> Faces;

        public Mesh()
        {
            Verteces = new List<Vertex>();
            Faces = new List<Face>();
        }

        public Mesh(Mesh other)
        {
            Verteces = new List<Vertex>(other.Verteces);
            Faces = new List<Face>(other.Faces);
        }

        public static Mesh CoordinateSystem()
        {
            Mesh ms = new Mesh();
            ms.Verteces.Add(new Vertex(0, 0, 0));
            ms.Verteces.Add(new Vertex(10, 0, 0));
            ms.Verteces.Add(new Vertex(0, 10, 0));
            ms.Verteces.Add(new Vertex(0, 0, 10));
            ms.Faces.Add(new Face(0, 1, 0));
            ms.Faces.Add(new Face(0, 2, 0));
            ms.Faces.Add(new Face(0, 3, 0));
            return ms;
        }

        public Mesh(string ObjFile)
        {
            try
            {
                List<string> Lines = new List<string>(File.ReadAllLines(ObjFile));
                Verteces = new List<Vertex>(Lines.Where(l => Regex.IsMatch(l, @"^v(\s+-?\d+\.?\d+([eE][-+]?\d+)?){3,3}$"))
                    .Select(l => Regex.Split(l, @"\s+", RegexOptions.None).Skip(1).ToArray())
                    .Select(coords => new Vertex(double.Parse(coords[0].Replace('.', ',')), double.Parse(coords[1].Replace('.', ',')), double.Parse(coords[2].Replace('.', ',')))));
                Faces = new List<Face>(Lines.Where(l => Regex.IsMatch(l, @"^f(\s\d+(\/+\d+)?){3,}$"))
                    .Select(l => Regex.Split(l, @"\s+", RegexOptions.None).Skip(1).ToArray())
                    .Select(points => new Face(points.Select(p => int.Parse(p) - 1).ToArray())));
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл " + ObjFile + " не найден!", "Ошибка загрузки файла!");
            }
        }

        public Vector3 Center()
        {
            return new Vector3(Verteces.Select(v => v.Position.X).ToList().Sum() / Verteces.Count,
                               Verteces.Select(v => v.Position.Y).ToList().Sum() / Verteces.Count,
                               Verteces.Select(v => v.Position.Z).ToList().Sum() / Verteces.Count);
        }

        public Vector3 FaceCenter(int index)
        {
            if(index < 0 || index >= Faces.Count)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                List<Vertex> FaceVerteces = Faces[index].Points.Select(p => Verteces[p]).ToList();
                return new Vector3(FaceVerteces.Select(v => v.Position.X).Sum() / FaceVerteces.Count,
                                   FaceVerteces.Select(v => v.Position.Y).Sum() / FaceVerteces.Count,
                                   FaceVerteces.Select(v => v.Position.Z).Sum() / FaceVerteces.Count);
            }
        }

        public Vector3 FaceCenter(Face f1)
        {
            List<Vertex> FaceVerteces = Faces[Faces.IndexOf(f1)].Points.Select(p => Verteces[p]).ToList();
            return new Vector3(FaceVerteces.Select(v => v.Position.X).Sum() / FaceVerteces.Count,
                                FaceVerteces.Select(v => v.Position.Y).Sum() / FaceVerteces.Count,
                                FaceVerteces.Select(v => v.Position.Z).Sum() / FaceVerteces.Count);
        }

        public static Mesh testTriangles()
        {
            Mesh result = new Mesh();

            result.Verteces.Add(new Vertex(new Vector3(0, 0, 0)));
            result.Verteces.Add(new Vertex(new Vector3(0, 1, 0)));
            result.Verteces.Add(new Vertex(new Vector3(0, 0, 1)));
            result.Verteces.Add(new Vertex(new Vector3(1, 0, 0)));
            result.Faces.Add(new Face(new int[] { 0, 2, 3 }));
            result.Faces.Add(new Face(new int[] { 0, 1, 2 }));

            return result;
        }
    }
}
