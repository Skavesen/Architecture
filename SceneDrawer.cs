using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using AMath;

namespace Visualizer
{
    class SceneDrawer
    {
        public Bitmap ImageBitmap { get; set; }
        private double[,] ZBuffer;
        private bool useZBuffer;

        public SceneDrawer(int width, int height, bool zBuffer)
        {
            ImageBitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            if (zBuffer)
            {
                ZBuffer = new double[height, width];
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        ZBuffer[i, j] = double.MaxValue;
                    }
                }
            }
            useZBuffer = zBuffer;
        }

        public void DrawPoly(List<Vector3> vertexList, Color color)
        {
            if (vertexList[0].Y == vertexList[1].Y && vertexList[0].Y == vertexList[2].Y)
            {
                return;
            }

            vertexList.Sort((v1, v2) => v1.Y.CompareTo(v2.Y));

            int totalHeight = (int)Math.Round(vertexList[2].Y - vertexList[0].Y);
            BitmapData data = ImageBitmap.LockBits( new Rectangle(0, 0, ImageBitmap.Width, ImageBitmap.Height),
                ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            unsafe
            {
                for (int i = 0; i < totalHeight; i++)
                {
                    bool secondHalf = i > vertexList[1].Y - vertexList[0].Y || vertexList[1].Y == vertexList[0].Y;
                    int segmentHeight = (int)(secondHalf ? vertexList[2].Y - vertexList[1].Y : vertexList[1].Y - vertexList[0].Y);
                    double alpha = (double)i / totalHeight;
                    double beta = (double)(segmentHeight == 0 ? 0 : (i - (secondHalf ? vertexList[1].Y - vertexList[0].Y : 0)) / segmentHeight);
                    Vector3 A = vertexList[0] + (vertexList[2] - vertexList[0]) * alpha;
                    Vector3 B = secondHalf ? vertexList[1] + (vertexList[2] - vertexList[1]) * beta : vertexList[0] + (vertexList[1] - vertexList[0]) * beta;

                    if (A.X > B.X)
                    {
                        Vector3 temp = A;
                        A = B;
                        B = temp;
                    }

                    for (int j = (int)Math.Round(A.X); j <= (int)Math.Round(B.X); j++)
                    {
                        if ((i + (int)Math.Round(vertexList[0].Y)) >= 0 && (i + (int)Math.Round(vertexList[0].Y)) < ImageBitmap.Height &&
                            j >= 0 && j < ImageBitmap.Width)
                        {
                            byte* row = (byte*)data.Scan0 + ((i + (int)Math.Round(vertexList[0].Y)) * data.Stride);
                            if (useZBuffer)
                            {
                                double phi = B.X == A.X ? 1.0 : (j - A.X) / (B.X - A.X);
                                Vector3 P = A + (B - A) * phi;
                                if (P.X < ImageBitmap.Width && P.X > 0 && P.Y < ImageBitmap.Height && P.Y > 0)
                                {
                                    if (ZBuffer[(int)P.Y, (int)P.X] > P.Z)
                                    {
                                        ZBuffer[(int)P.Y, (int)P.X] = P.Z;
                                        row[j * 4] = color.B;
                                        row[j * 4 + 1] = color.G;
                                        row[j * 4 + 2] = color.R;
                                        row[j * 4 + 3] = color.A;
                                    }
                                }
                            }
                            else
                            {
                                row[j * 4] = color.B;
                                row[j * 4 + 1] = color.G;
                                row[j * 4 + 2] = color.R;
                                row[j * 4 + 3] = color.A;
                            }
                        }
                    }
                }
            }

            ImageBitmap.UnlockBits(data);
        }

        public void DrawWireframePoly(List<Vector3> vertexList, Color color)
        {
            DrawLine(vertexList[0], vertexList[1], color);
            DrawLine(vertexList[1], vertexList[2], color);
            DrawLine(vertexList[2], vertexList[0], color);
        }

        public void DrawLine(Vector3 v0, Vector3 v1, Color color)
        {
            double x0 = v0.X;
            double x1 = v1.X;
            double y0 = v0.Y;
            double y1 = v1.Y;

            if (y0 == y1)
            {
                return;
            }

            bool steep = false;

            if (Math.Abs(x0 - x1) < Math.Abs(y0 - y1))
            {
                double x = x0;
                x0 = y0;
                y0 = x;
                x = x1;
                x1 = y1;
                y1 = x;
                steep = true;
            }

            if (x0 > x1)
            {
                double x = x0;
                x0 = x1;
                x1 = x;
                x = y0;
                y0 = y1;
                y1 = x;
            }

            int totalHeight = (int)(y1 - y0);
            BitmapData data = ImageBitmap.LockBits(
                new Rectangle(0, 0, ImageBitmap.Width, ImageBitmap.Height),
                ImageLockMode.WriteOnly,
                PixelFormat.Format32bppArgb);

            unsafe
            {
                for (int x = (int)Math.Round(x0); x < (int)Math.Round(x1); x++)
                {
                    double t = (x - x0) / (x1 - x0);
                    int y = (int)(y0 * (1.0 - t) + y1 * t);
                    if (steep)
                    {
                        if (x >= 0 && x < ImageBitmap.Height && y >= 0 && y < ImageBitmap.Width)
                        {
                            byte* row = (byte*)data.Scan0 + (x * data.Stride);
                            row[y * 4] = color.B;
                            row[y * 4 + 1] = color.G;
                            row[y * 4 + 2] = color.R;
                            row[y * 4 + 3] = color.A;
                        }
                    }
                    else
                    {
                        if (x >= 0 && x < ImageBitmap.Width && y >= 0 && y < ImageBitmap.Height)
                        {
                            byte* row = (byte*)data.Scan0 + (y * data.Stride);
                            row[x * 4] = color.B;
                            row[x * 4 + 1] = color.G;
                            row[x * 4 + 2] = color.R;
                            row[x * 4 + 3] = color.A;
                        }
                    }
                }
            }

            ImageBitmap.UnlockBits(data);
        }
    }
}
