using System;
using System.Collections.Generic;
using System.Linq;
using AMath;

namespace Visualizer
{
    public class MeshCreater
    {
        //public static Mesh Keel(Vertex basement, double height, double baseLength)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X + height / 10, basement.Position.Y, basement.Position.Z - height / 10));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Verteces.Add(new Vertex(basement.Position.X - height / 10, basement.Position.Y, basement.Position.Z - height / 10));

        //    result.Verteces.Add(new Vertex(basement.Position.X + height / 10, basement.Position.Y + height, basement.Position.Z - baseLength * 2 / 3 - height / 10));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y + height, basement.Position.Z - baseLength * 2 / 3));
        //    result.Verteces.Add(new Vertex(basement.Position.X - height / 10, basement.Position.Y + height, basement.Position.Z - baseLength * 2 / 3 - height / 10));

        //    result.Verteces.Add(new Vertex(basement.Position.X + height / 10, basement.Position.Y + height, basement.Position.Z - baseLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y + height, basement.Position.Z - baseLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - height / 10, basement.Position.Y + height, basement.Position.Z - baseLength));

        //    result.Verteces.Add(new Vertex(basement.Position.X + height / 10, basement.Position.Y, basement.Position.Z - baseLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z - baseLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - height / 10, basement.Position.Y, basement.Position.Z - baseLength));

        //    result.Faces.AddRange(Connect(0, 2, 3, 5));
        //    result.Faces.AddRange(Connect(3, 5, 6, 8));
        //    result.Faces.AddRange(Connect(6, 8, 9, 11));
        //    result.Faces.AddRange(Connect(0, 2, 9, 11));
        //    result.Faces.Add(new Face(0, 3, 9));
        //    result.Faces.Add(new Face(3, 6, 9));
        //    result.Faces.Add(new Face(2, 5, 11));
        //    result.Faces.Add(new Face(5, 8, 11));

        //    return result;
        //}

        //public static Mesh Wing(Vertex basement, double startLength, double endLength)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y + startLength / 20, basement.Position.Z));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y + startLength / 20, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X + startLength, basement.Position.Y, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X + startLength, basement.Position.Y + startLength / 20, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - startLength, basement.Position.Y, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - startLength, basement.Position.Y + startLength / 20, basement.Position.Z - startLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X + startLength, basement.Position.Y, basement.Position.Z - startLength + endLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X + startLength, basement.Position.Y + startLength / 20, basement.Position.Z - startLength + endLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - startLength, basement.Position.Y, basement.Position.Z - startLength + endLength));
        //    result.Verteces.Add(new Vertex(basement.Position.X - startLength, basement.Position.Y + startLength / 20, basement.Position.Z - startLength + endLength));

        //    result.Faces.AddRange(Connect(4, 5, 8, 9));
        //    result.Faces.AddRange(Connect(6, 7, 10, 11));
        //    result.Faces.AddRange(Connect(0, 1, 10, 11));
        //    result.Faces.AddRange(Connect(0, 1, 8, 9));
        //    result.Faces.AddRange(Connect(2, 3, 6, 7));
        //    result.Faces.AddRange(Connect(2, 3, 4, 5));
        //    result.Faces.Add(new Face(1, 11, 3));
        //    result.Faces.Add(new Face(11, 7, 3));
        //    result.Faces.Add(new Face(1, 9, 3));
        //    result.Faces.Add(new Face(9, 5, 3));
        //    result.Faces.Add(new Face(0, 10, 2));
        //    result.Faces.Add(new Face(10, 6, 2));
        //    result.Faces.Add(new Face(0, 8, 2));
        //    result.Faces.Add(new Face(8, 4, 2));

        //    return result;
        //}

        //public static Mesh Cone(Vertex basement, double radius, double height, int vertexCount)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + height));
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z), radius, vertexCount));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        public static Mesh Box(Vertex basement, double length, double width, double height)
        {

            basement.Position.X = basement.Position.X / 5;
            basement.Position.Y = basement.Position.Y / 5;
            basement.Position.Z = basement.Position.Z / 5;

            length = length / 5;
            width = width / 5;
            height = height / 5;

            Mesh result = new Mesh();

            result.Verteces.Add(new Vertex(basement.Position.X + width / 2, basement.Position.Y, basement.Position.Z + length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X - width / 2, basement.Position.Y, basement.Position.Z + length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X + width / 2, basement.Position.Y, basement.Position.Z - length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X - width / 2, basement.Position.Y, basement.Position.Z - length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X + width / 2, basement.Position.Y + height, basement.Position.Z + length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X - width / 2, basement.Position.Y + height, basement.Position.Z + length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X + width / 2, basement.Position.Y + height, basement.Position.Z - length / 2));
            result.Verteces.Add(new Vertex(basement.Position.X - width / 2, basement.Position.Y + height, basement.Position.Z - length / 2));

            result.Faces.Add(new Face(0, 1, 2));
            result.Faces.Add(new Face(1, 2, 3));
            result.Faces.Add(new Face(0, 2, 4));
            result.Faces.Add(new Face(2, 4, 6));
            result.Faces.Add(new Face(0, 1, 5));
            result.Faces.Add(new Face(0, 4, 5));
            result.Faces.Add(new Face(1, 3, 7));
            result.Faces.Add(new Face(1, 5, 7));
            result.Faces.Add(new Face(2, 3, 7));
            result.Faces.Add(new Face(2, 6, 7));
            result.Faces.Add(new Face(4, 5, 6));
            result.Faces.Add(new Face(5, 6, 7));

            return result;
        }

        public static Mesh LinearCurve1(Vertex startBasement, Vertex finishBasement, double width)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            width = width / 5;

            Mesh result = new Mesh();

            double t = 0;
            double step = 0.25;
            int i = 0;

            while (t < 1)
            {
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X + width, finishBasement.Position.X + width, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t + step), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t + step), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X + width, finishBasement.Position.X + width, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X + width, finishBasement.Position.X + width, t + step), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t + step), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                t += step;
            }

            return result;
        }

        public static Mesh LinearCurve2(Vertex startBasement, Vertex finishBasement, double width)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            width = width / 5;

            Mesh result = new Mesh();

            double t = 0;
            double step = 0.25;
            int i = 0;

            while (t < 1)
            {
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z - width, finishBasement.Position.Z - width, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t + step), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t + step), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z - width, finishBasement.Position.Z - width, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t), LinearBezierCurve(startBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(LinearBezierCurve(startBasement.Position.X, finishBasement.Position.X, t + step), LinearBezierCurve(startBasement.Position.Y, finishBasement.Position.Y, t + step), LinearBezierCurve(startBasement.Position.Z - width, finishBasement.Position.Z - width, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                t += step;
            }

            return result;
        }

        public static Mesh QuadraticCurve1(Vertex startBasement, Vertex centerBasement, Vertex finishBasement, double width)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            centerBasement.Position.X = centerBasement.Position.X / 5;
            centerBasement.Position.Y = centerBasement.Position.Y / 5;
            centerBasement.Position.Z = centerBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            Mesh result = new Mesh();

            double t = 0;
            double step = 0.05;
            int i = 0;

            while (t < 1)
            {
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X + width, centerBasement.Position.X + width, finishBasement.Position.X + width, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t + step), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t + step), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X + width, centerBasement.Position.X + width, finishBasement.Position.X + width, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X + width, centerBasement.Position.X + width, finishBasement.Position.X + width, t + step), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t + step), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                t += step;
            }

            return result;
        }

        public static Mesh QuadraticCurve2(Vertex startBasement, Vertex centerBasement, Vertex finishBasement, double width)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            centerBasement.Position.X = centerBasement.Position.X / 5;
            centerBasement.Position.Y = centerBasement.Position.Y / 5;
            centerBasement.Position.Z = centerBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            Mesh result = new Mesh();

            double t = 0;
            double step = 0.05;
            int i = 0;

            while (t < 1)
            {
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z - width, centerBasement.Position.Z - width, finishBasement.Position.Z - width, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t + step), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t + step), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z - width, centerBasement.Position.Z - width, finishBasement.Position.Z - width, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t), QuadraticBezierCurve(startBasement.Position.Z, centerBasement.Position.Z, finishBasement.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement.Position.X, centerBasement.Position.X, finishBasement.Position.X, t + step), QuadraticBezierCurve(startBasement.Position.Y, centerBasement.Position.Y, finishBasement.Position.Y, t + step), QuadraticBezierCurve(startBasement.Position.Z - width, centerBasement.Position.Z - width, finishBasement.Position.Z - width, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                t += step;
            }

            return result;
        }

        public static Mesh QuadraticCurve3(Vertex startBasement1, Vertex centerBasement, Vertex finishBasement1, Vertex startBasement2)
        {
            startBasement1.Position.X = startBasement1.Position.X / 5;
            startBasement1.Position.Y = startBasement1.Position.Y / 5;
            startBasement1.Position.Z = startBasement1.Position.Z / 5;

            startBasement2.Position.X = startBasement2.Position.X / 5;
            startBasement2.Position.Y = startBasement2.Position.Y / 5;
            startBasement2.Position.Z = startBasement2.Position.Z / 5;

            finishBasement1.Position.X = finishBasement1.Position.X / 5;
            finishBasement1.Position.Y = finishBasement1.Position.Y / 5;
            finishBasement1.Position.Z = finishBasement1.Position.Z / 5;

            centerBasement.Position.X = centerBasement.Position.X / 5;
            centerBasement.Position.Y = centerBasement.Position.Y / 5;
            centerBasement.Position.Z = centerBasement.Position.Z / 5;

            Mesh result = new Mesh();

            double t = 0;
            double step = 0.05;
            int i = 0;

            while (t < 1)
            {
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement1.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t), QuadraticBezierCurve(startBasement1.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t), QuadraticBezierCurve(startBasement1.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement2.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t), QuadraticBezierCurve(startBasement2.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t), QuadraticBezierCurve(startBasement2.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement1.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t + step), QuadraticBezierCurve(startBasement1.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t + step), QuadraticBezierCurve(startBasement1.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement2.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t), QuadraticBezierCurve(startBasement2.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t), QuadraticBezierCurve(startBasement2.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement1.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t), QuadraticBezierCurve(startBasement1.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t), QuadraticBezierCurve(startBasement1.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t)));
                result.Verteces.Add(new Vertex(QuadraticBezierCurve(startBasement2.Position.X, centerBasement.Position.X, finishBasement1.Position.X, t + step), QuadraticBezierCurve(startBasement2.Position.Y, centerBasement.Position.Y, finishBasement1.Position.Y, t + step), QuadraticBezierCurve(startBasement2.Position.Z, centerBasement.Position.Z, finishBasement1.Position.Z, t + step)));

                result.Faces.Add(new Face(i, i + 1, i + 2));
                i = i + 3;

                t += step;
            }

            return result;
        }

        // Алгоритм Безье для линейных кривых
        public static double LinearBezierCurve(double P0, double P1, double t)
        {
            return (1 - t) * P0 + t * P1;
        }

        // Алгоритм Безье для квадратичных кривых
        public static double QuadraticBezierCurve(double P0, double P1, double P2, double t)
        {
            return Math.Pow((1 - t), 2) * P0 + 2 * t * (1 - t) * P1 + Math.Pow(t, 2) * P2;
        }

        public static Mesh Grille1(Vertex startBasement, Vertex finishBasement, double heigth)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            Mesh result = new Mesh();

            return result;
        }

        public static Mesh Grille2(Vertex startBasement, Vertex finishBasement, double height)
        {
            startBasement.Position.X = startBasement.Position.X / 5;
            startBasement.Position.Y = startBasement.Position.Y / 5;
            startBasement.Position.Z = startBasement.Position.Z / 5;

            finishBasement.Position.X = finishBasement.Position.X / 5;
            finishBasement.Position.Y = finishBasement.Position.Y / 5;
            finishBasement.Position.Z = finishBasement.Position.Z / 5;

            height = height / 5;

            Mesh result = new Mesh();

            return result;
        }

        //public static Mesh HalfSphere(Vertex basement, double radius, int segments, int rings)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + radius));
        //    double step = 1.0 / rings;
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + radius * (1 - step)), Math.Sqrt(radius * radius - radius * (1 - step) * radius * (1 - step)), segments));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - segments, result.Verteces.Count - 1));

        //    for (int i = 2; i <= rings; i++)
        //    {
        //        result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + radius * (1 - step * i)), Math.Sqrt(radius * radius - radius * (1 - step * i) * radius * (1 - step * i)), segments));
        //        result.Faces.AddRange(Connect(result.Verteces.Count - segments * 2, result.Verteces.Count - segments - 1, result.Verteces.Count - segments, result.Verteces.Count - 1));
        //    }

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - segments - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        //public static Mesh Sphere(Vertex basement, double radius, int segments, int rings)
        //{
        //    basement.Position.X = basement.Position.X / 5;
        //    basement.Position.Y = basement.Position.Y / 5;
        //    basement.Position.Z = basement.Position.Z / 5;

        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + radius));
        //    double step = 2.0 / (rings + 1);
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + radius * (1 - step)), Math.Sqrt(radius * radius - radius * (1 - step) * radius * (1 - step)), segments));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - segments, result.Verteces.Count - 1));

        //    for (int i = 2; i <= rings; i++)
        //    {
        //        result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + radius * (1 - step * i)), Math.Sqrt(radius * radius - radius * (1 - step * i) * radius * (1 - step * i)), segments));
        //        result.Faces.AddRange(Connect(result.Verteces.Count - segments * 2, result.Verteces.Count - segments - 1, result.Verteces.Count - segments, result.Verteces.Count - 1));
        //    }

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z - radius));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - segments - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        //public static Mesh SegmentCylinder(Vertex basement, double radius, double height, int segments, int rings)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + height));
        //    double step = 1.0 / (rings);
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height), radius, segments));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - segments, result.Verteces.Count - 1));

        //    for (int i = 1; i < rings + 1; i++)
        //    {
        //        result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height * (1 - step * i)), radius, segments));
        //        result.Faces.AddRange(Connect(result.Verteces.Count - segments * 2, result.Verteces.Count - segments - 1, result.Verteces.Count - segments, result.Verteces.Count - 1));
        //    }

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - segments - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        //public static Mesh Cylinder(Vertex basement, double height, double radius, int vertexCount)
        //{
        //    basement.Position.X = basement.Position.X / 5;
        //    basement.Position.Y = basement.Position.Y / 5;
        //    basement.Position.Z = basement.Position.Z / 5;

        //    height = height / 5;
        //    radius = radius / 5;

        //    Mesh result = new Mesh();

        //    result.Verteces.Add(basement);
        //    result.Verteces.AddRange(CreateRing(basement.Position, radius, vertexCount));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y + height, basement.Position.Z ), radius, vertexCount));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - vertexCount * 2, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y + height, basement.Position.Z));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        //public static Mesh CuttedConeLeft(Vertex basement, double height, double smallRadius, double bigRadius, int vertexCount)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + height));
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height), smallRadius, vertexCount));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));

        //    Matrix4 transform = new Matrix4(
        //        Matrix4.Move(-new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height)) *
        //        Matrix4.Scale(new Vector3(1, bigRadius / smallRadius, 1)) *
        //        Matrix4.Move(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height)) *
        //        Matrix4.Move(new Vector3(0, (bigRadius - smallRadius), 0))
        //        );
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z), smallRadius, vertexCount).Select(v => new Vertex(new Vector4(v.Position) * transform)).ToList());
        //    result.Faces.AddRange(Connect(result.Verteces.Count - vertexCount * 2, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        //public static Mesh CuttedConeRight(Vertex basement, double height, double smallRadius, double bigRadius, int vertexCount)
        //{
        //    Mesh result = new Mesh();

        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z));
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z), bigRadius, vertexCount));
        //    result.Faces.AddRange(Connect(0, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));

        //    Matrix4 transform = new Matrix4(
        //        Matrix4.Move(-new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z)) *
        //        Matrix4.Scale(new Vector3(1, bigRadius / smallRadius, 1)) *
        //        Matrix4.Move(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z)) *
        //        Matrix4.Move(new Vector3(0, (bigRadius - smallRadius), 0))
        //        );
        //    result.Verteces.AddRange(CreateRing(new Vector3(basement.Position.X, basement.Position.Y, basement.Position.Z + height), smallRadius, vertexCount).Select(v => new Vertex(new Vector4(v.Position) * transform)).ToList());
        //    result.Faces.AddRange(Connect(result.Verteces.Count - vertexCount * 2, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - vertexCount, result.Verteces.Count - 1));
        //    result.Verteces.Add(new Vertex(basement.Position.X, basement.Position.Y, basement.Position.Z + height));
        //    result.Faces.AddRange(Connect(result.Verteces.Count - 1, result.Verteces.Count - vertexCount - 1, result.Verteces.Count - 2));

        //    return result;
        //}

        private static List<Face> Connect(int v1, int elStart, int elEnd)
        {
            List<Face> faces = new List<Face>();

            for (int i = elStart; i < elEnd; i++)
            {
                faces.Add(new Face(v1, i, i + 1));
            }

            faces.Add(new Face(v1, elEnd, elStart));

            return faces;
        }

        private static List<Face> Connect(int el1Start, int el1End, int el2Start, int el2End)
        {
            List<Face> faces = new List<Face>();

            for (int i = 0; i < el1End - el1Start - 1; i++)
            {
                faces.Add(new Face(el1Start + i, el2Start + i, el2Start + i + 1));
                faces.Add(new Face(el1Start + i, el1Start + i + 1, el2Start + i + 1));
            }

            faces.Add(new Face(el1End - 1, el2End - 1, el2End));
            faces.Add(new Face(el1End - 1, el1End, el2End));
            faces.Add(new Face(el1End, el2End, el2Start));
            faces.Add(new Face(el1End, el1Start, el2Start));

            return faces;
        }

        private static List<Vertex> CreateRing(Vector3 center, double radius, int vertexCount)
        {
            List<Vertex> list = new List<Vertex>();

            double angle = Math.PI * 2 / vertexCount;

            for (int i = 0; i < vertexCount; i++)
            {
                list.Add(new Vertex(center.X + radius * Math.Cos(Math.PI - angle * i), center.Y + radius *
                    Math.Sin(Math.PI - angle * i), center.Z));
            }

            return list;
        }
    }
}
