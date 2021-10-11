using System;

namespace AMath
{
    public class Vector4
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
        public double W { get; set; }

        public Vector4()
        {
            X = 0.0;
            Y = 0.0;
            Z = 0.0;
            W = 0.0;
        }

        public Vector4(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
            W = 1.0;
        }

        public Vector4(Vector3 v3)
        {
            X = v3.X;
            Y = v3.Y;
            Z = v3.Z;
            W = 1.0;
        }

        public Vector4(double[] arr)
        {
            if (arr.Length == 3)
            {
                X = arr[0];
                Y = arr[1];
                Z = arr[2];
                W = 1.0;
            }
            else if (arr.Length == 4)
            {
                X = arr[0];
                Y = arr[1];
                Z = arr[2];
                W = arr[3];
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public double this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return X;

                    case 1:
                        return Y;

                    case 2:
                        return Z;

                    case 3:
                        return W;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        X = value;
                        break;

                    case 1:
                        Y = value;
                        break;

                    case 2:
                        Z = value;
                        break;

                    case 3:
                        W = value;
                        break;
                    default:
                        throw new IndexOutOfRangeException();
                }
            }
        }

        public double[] ToArray()
        {
            double[] res = new double[4];
            res[0] = X;
            res[1] = Y;
            res[2] = Z;
            res[3] = W;
            return res;
        }
    }
}
