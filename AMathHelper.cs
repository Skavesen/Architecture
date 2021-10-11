using System;

namespace AMath
{
    static public class AMathHelper
    {
        public static double ToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        public static double ToDegree(double angle)
        {
            return angle * 180 / Math.PI;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public static Vector3 CartesianToSpherical(Vector3 cartesian)
        {
            return new Vector3(cartesian.Length(),
                Math.Acos(cartesian.Z / cartesian.Length()),
                (cartesian.Y == 0) ? 0 : Math.Atan(cartesian.X / cartesian.Y));
        }

        public static Vector3 SphericalToCartesian(Vector3 spherical)
        {
            return new Vector3(spherical.X * Math.Sin(spherical.Y) * Math.Cos(spherical.Z),
                spherical.X * Math.Sin(spherical.Y) * Math.Sin(spherical.Z),
                spherical.X * Math.Cos(spherical.Y));
        }
    }
}
