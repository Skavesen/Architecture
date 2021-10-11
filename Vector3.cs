using System;
using System.ComponentModel;

namespace AMath
{
    public class Vector3 : INotifyPropertyChanged
    {
        private double _x;
        private double _y;
        private double _z;
        public double X {
            get
            {
                return _x;
            }
            set
            {
                _x = value;
                OnCoordinateChanged("X");
            }
        }
        public double Y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
                OnCoordinateChanged("Y");
            }
        }
        public double Z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
                OnCoordinateChanged("Z");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnCoordinateChanged(string propertyName)
        {
            OnCoordinateChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnCoordinateChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }

        public Vector3()
        {
            X = 0;
            Y = 0;
            Z = 0;
        }

        public Vector3(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector3(params double[] coords)
        {
            X = coords[0];
            Y = coords[1];
            Z = coords[2];
        }

        public Vector3(Vector3 v3)
        {
            X = v3.X;
            Y = v3.Y;
            Z = v3.Z;
        }

        public Vector3(Vector4 v4)
        {
            X = v4.X;
            Y = v4.Y;
            Z = v4.Z;
        }

        public double Length()
        {
            return Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public static double Length(Vector3 v)
        {
            return Math.Sqrt(v.X * v.X + v.Y * v.Y + v.Z * v.Z);
        }

        public Vector3 Abs()
        {
            return new Vector3(Math.Abs(X), Math.Abs(Y), Math.Abs(Z));
        }

        public static Vector3 operator -(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }

        public static Vector3 operator -(Vector3 v1)
        {
            return new Vector3() - v1;
        }

        public static double operator *(Vector3 v1, Vector3 v2)
        {
            return v1.X * v2.X + 
                v1.Y * v2.Y + 
                v1.Z * v2.Z;
        }

        public static Vector3 operator +(Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }

        public static Vector3 operator *(Vector3 v1, double constanta)
        {
            return new Vector3(v1.X * constanta, v1.Y * constanta, v1.Z * constanta);
        }

        public static Vector3 CrossRight(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.Y * v2.Z - v1.Z * v2.Y,
                v1.Z * v2.X - v1.X * v2.Z,
                v1.X * v2.Y - v1.Y * v2.X);
        }

        public static Vector3 CrossLeft(Vector3 v1, Vector3 v2)
        {
            return new Vector3(
                v1.Z * v2.Y - v1.Y * v2.Z, 
                v1.X * v2.Z - v1.Z * v2.X, 
                v1.Y * v2.X - v1.X * v2.Z);
        }

        public Vector3(Vector3 v1, Vector3 v2)
        {
            Vector3 v3 = v1 - v2;
            X = v3.X;
            Y = v3.Y;
            Z = v3.Z;
        }

        public static Vector3 Normal(Vector3 v1, Vector3 v2, Vector3 v3)
        {
            Vector3 a = v2 - v1;
            Vector3 b = v3 - v1;
            return CrossRight(a, b);
        }

        public void Normalize()
        {
            double length = Length();
            if(length != 0)
            {
                _x /= length;
                _y /= length;
                _z /= length;
            }
        }

        public static Vector3 Normalize(Vector3 v)
        {
            if(v.Length() != 0)
            {
                return v * (1 / v.Length());
            }
            else
            {
                return v;
            }
        }

        public override string ToString()
        {
            return X + "; " + Y + "; " + Z;
        }
    }
}
