using System;

namespace AMath
{
    public class Matrix4 : SquareMatrix
    {
        public Matrix4() : base(4) { }

        public Matrix4(SquareMatrix matrix)
        {
            if (matrix.Size == 4)
            {
                Size = matrix.Size;
                Cells = matrix.Cells;
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        public static Vector4 operator *(Vector4 v4, Matrix4 m4)
        {
            return new Vector4(v4.ToArray() * m4);
        }

        public static Vector4 operator *(Matrix4 m4, Vector4 v4)
        {
            return new Vector4(m4 * v4.ToArray());
        }

        public double this[int index1, int index2]
        {
            get
            {
                return Cells[index1, index2];
            }
            set
            {
                Cells[index1, index2] = value;
            }
        }

        public static Matrix4 Rotate(Vector3 rotateVector)
        {
            Matrix4 rotX = new Matrix4(IdentityMatrix(4));
            rotX[1, 1] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.X));
            rotX[1, 2] = Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.X));
            rotX[2, 1] = -Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.X));
            rotX[2, 2] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.X));

            Matrix4 rotY = new Matrix4(IdentityMatrix(4));
            rotY[0, 0] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.Y));
            rotY[0, 2] = -Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.Y));
            rotY[2, 0] = Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.Y));
            rotY[2, 2] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.Y));

            Matrix4 rotZ = new Matrix4(IdentityMatrix(4));
            rotZ[0, 0] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.Z));
            rotZ[0, 1] = Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.Z));
            rotZ[1, 0] = -Math.Sin(AMath.AMathHelper.ToRadians(rotateVector.Z));
            rotZ[1, 1] = Math.Cos(AMath.AMathHelper.ToRadians(rotateVector.Z));

            return new Matrix4(rotZ * rotY * rotX);
        }

        public static Matrix4 Move(Vector3 translateVector)
        {
            Matrix4 result = new Matrix4(SquareMatrix.IdentityMatrix(4));

            result[3, 0] = translateVector.X;
            result[3, 1] = translateVector.Y;
            result[3, 2] = translateVector.Z;

            return result;
        }

        public static Matrix4 Scale(Vector3 scaleVector)
        {
            Matrix4 result = new Matrix4(SquareMatrix.IdentityMatrix(4));

            result[0, 0] = scaleVector.X;
            result[1, 1] = scaleVector.Y;
            result[2, 2] = scaleVector.Z;

            return result;
        }

        public static Matrix4 World(Vector3 translateVector, Vector3 rotateVector, Vector3 scaleVector)
        {
            return new Matrix4(Scale(scaleVector) * Rotate(rotateVector) * Move(translateVector));
        }

        //public static Matrix4 View(Vector3 camera, Vector3 lookAt)
        //{
        //    Vector3 sphericalCamera = AMathHelper.CartesianToSpherical(camera - lookAt);
        //    double ro = sphericalCamera.X;
        //    double fi = sphericalCamera.Z;
        //    double teta = sphericalCamera.Y;

        //    Matrix4 result = new Matrix4(IdentityMatrix(4));
        //    result[0, 0] = -Math.Sin(teta);
        //    result[0, 1] = -Math.Cos(fi) * Math.Cos(teta);
        //    result[0, 2] = -Math.Sin(fi) * Math.Cos(teta);
        //    result[1, 0] = Math.Cos(teta);
        //    result[1, 1] = -Math.Cos(fi) * Math.Sin(teta);
        //    result[1, 2] = -Math.Sin(fi) * Math.Sin(teta);
        //    result[2, 1] = Math.Sin(fi);
        //    result[2, 2] = -Math.Sin(fi);
        //    result[3, 2] = sphericalCamera.X;

        //    return result;
        //}

        public static Matrix4 View(Vector3 CameraPosition, Vector3 TargetPoint)
        {
            Vector3 ZAxis = Vector3.Normalize(TargetPoint - CameraPosition);
            Vector3 XAxis = Vector3.Normalize(Vector3.CrossRight(new Vector3(0.0, 1.0, 0.0), ZAxis));
            Vector3 YAxis = Vector3.CrossRight(ZAxis, XAxis);

            Matrix4 viewMatrix = new Matrix4(SquareMatrix.IdentityMatrix(4));
            viewMatrix[0, 0] = XAxis.X;
            viewMatrix[0, 1] = YAxis.X;
            viewMatrix[0, 2] = ZAxis.X;

            viewMatrix[1, 0] = XAxis.Y;
            viewMatrix[1, 1] = YAxis.Y;
            viewMatrix[1, 2] = ZAxis.Y;

            viewMatrix[2, 0] = XAxis.Z;
            viewMatrix[2, 1] = YAxis.Z;
            viewMatrix[2, 2] = ZAxis.Z;

            viewMatrix[3, 0] = -(XAxis * CameraPosition);
            viewMatrix[3, 1] = -(YAxis * CameraPosition);
            viewMatrix[3, 2] = -(ZAxis * CameraPosition);

            return viewMatrix;
        }

        public static Matrix4 PerspectiveFoV(double fieldOfView, double aspectRatio,
            double nearRemoteControlDistance, double farRemoteControlDistance)
        {
            Matrix4 result = new Matrix4();

            double yScale = 1 / Math.Tan(fieldOfView * 0.5);
            double xScale = yScale / aspectRatio;

            result[0, 0] = xScale;
            result[1, 1] = yScale;
            result[2, 2] = farRemoteControlDistance / 
                    (farRemoteControlDistance - nearRemoteControlDistance);
            result[2, 3] = 1.0f;
            result[3, 2] = -nearRemoteControlDistance * farRemoteControlDistance /
                (farRemoteControlDistance - nearRemoteControlDistance);

            return result;
        }

        public static Matrix4 Orthographic(double width, double height, double zNearRemoteControl, double zFarRemoteControl)
        {
            Matrix4 result = new Matrix4();

            result[0, 0] = 2.0f / width;
            result[1, 1] = 2.0f / height;
            result[2, 2] = 1.0f / (zFarRemoteControl - zNearRemoteControl);
            result[3, 2] = zFarRemoteControl / (zNearRemoteControl - zFarRemoteControl);
            result[3, 3] = 1.0f;

            return result;
        }
    }
}