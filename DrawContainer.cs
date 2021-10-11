using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AMath;

namespace Visualizer
{
    public partial class DrawContainer : Control
    {
        private int Multiplier;
        public Scene DrawScene = new Scene();

        public DrawContainer()
        {
            InitializeComponent();
        }

        public DrawContainer(Scene scene)
        {
            InitializeComponent();
            MouseWheel += DrawContainer_MouseWheel;
            DoubleBuffered = true;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DrawScene = scene;

        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;
            g.Clear(Color.FromArgb(255, 15, 42, 1));//g.Clear(Color.FromArgb(255, 180, 180, 180));
            Multiplier = 100;

            double xSceneCenter = Width / 2;
            double ySceneCenter = Height / 2;
            Vector3 view = DrawScene.MainCamera.ViewVector();
            
            SceneDrawer drawer = new SceneDrawer(Width, Height, DrawScene.IsZBuffer);

            foreach (SceneObject DrawObject in DrawScene.ObjectList)
            {
                SceneObject Obj = new SceneObject(DrawObject);

                //Перевод в мировые координаты
                Matrix4 world = Matrix4.World(DrawObject.Transfer, DrawObject.Rotation, DrawObject.Scale);
                Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(new Vector4(v.Position) * world)).ToList();
                
                //Подсчет нормалей
                Obj.Mesh.Faces = Obj.Mesh.Faces.Select(f =>
                {
                    List<Vertex> FaceVerteces = f.Points.Select(p => Obj.Mesh.Verteces[p]).ToList();
                    Vector3 normal = Vector3.Normal(FaceVerteces[0].Position, FaceVerteces[1].Position, FaceVerteces[2].Position);
                    f.Normal = normal;
                    return f;
                }).ToList();
                
                //Алгоритм художника
                Obj.Mesh.Faces.Sort((f1, f2) =>
                {
                    List<Vertex> Face1Verteces = f1.Points.Select(p => Obj.Mesh.Verteces[p]).ToList();
                    Vector3 face1Center = new Vector3(Face1Verteces.Select(v => v.Position.X).Sum() / Face1Verteces.Count,
                                        Face1Verteces.Select(v => v.Position.Y).Sum() / Face1Verteces.Count,
                                        Face1Verteces.Select(v => v.Position.Z).Sum() / Face1Verteces.Count);
                    List<Vertex> Face2Verteces = f2.Points.Select(p => Obj.Mesh.Verteces[p]).ToList();
                    Vector3 face2Center = new Vector3(Face2Verteces.Select(v => v.Position.X).Sum() / Face2Verteces.Count,
                                        Face2Verteces.Select(v => v.Position.Y).Sum() / Face2Verteces.Count,
                                        Face2Verteces.Select(v => v.Position.Z).Sum() / Face2Verteces.Count);
                    return (DrawScene.MainCamera.Position - face2Center).Length().CompareTo((DrawScene.MainCamera.Position - face1Center).Length());
                });

                //Перевод в видовые координаты
                Matrix4 View = Matrix4.View(DrawScene.MainCamera.Position, DrawScene.MainCamera.ObserverPoint);
                Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(new Vector4(v.Position) * View)).ToList();

                //Перевод в кординаты перспективы
                if (DrawScene.IsPerspective)
                {
                    Matrix4 perspective = Matrix4.PerspectiveFoV(Math.PI / 2, Width / (double)Height, DrawScene.Near, DrawScene.Far);
                    Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(new Vector4(v.Position) * perspective)).ToList();
                    Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(v.Position.X / v.Position.Z, v.Position.Y / v.Position.Z, v.Position.Z)).ToList();
                    //Отсечение по Z координате
                    for (int i = 0; i < Obj.Mesh.Faces.Count;)
                    {
                        double CenterZ = Obj.Mesh.FaceCenter(i).Z;
                        if (CenterZ < DrawScene.Near || CenterZ > DrawScene.Far)
                        {
                            Obj.Mesh.Faces.RemoveAt(i);
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
                else
                {
                    Matrix4 ortho = Matrix4.Orthographic(Width, Height, DrawScene.Near, DrawScene.Far);
                    Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(new Vector4(v.Position) * ortho)).ToList();
                    double scale = -view.Length() + 42;
                    Obj.Mesh.Verteces = Obj.Mesh.Verteces.Select(v => new Vertex(v.Position.X * scale, v.Position.Y * scale, v.Position.Z)).ToList();
                }

                int t = DateTime.Now.Millisecond;

                for (int i = 0; i < Obj.Mesh.Faces.Count; i++)
                {
                    if (DrawScene.IsFilled)
                    {
                    drawer.DrawPoly(
                        Obj.Mesh.Faces[i].Points
                        .Select(p => Obj.Mesh.Verteces[p].Position)
                        .Select(v => new Vector3(xSceneCenter + v.X * Width, ySceneCenter - v.Y * Height, v.Z)).ToList(), /*Color.Blue*/
                        Obj.RenderColor(Math.Abs((Vector3.Normalize(Obj.Mesh.Faces[i].Normal) * Vector3.Normalize(DrawScene.MainCamera.ViewVector())))));
                    }
                    if (DrawScene.IsWireframe)
                    {
                        drawer.DrawWireframePoly(
                            Obj.Mesh.Faces[i].Points
                            .Select(p => Obj.Mesh.Verteces[p].Position)
                            .Select(v => new Vector3(xSceneCenter + v.X * Width, ySceneCenter - v.Y * Height, v.Z)).ToList(), Color.White);
                    }
                }
                Console.WriteLine("Render: {0} ms", DateTime.Now.Millisecond - t);
            }
            g.DrawImageUnscaled(drawer.ImageBitmap, new Point(0, 0));
            drawer.ImageBitmap.Dispose();
        }

        private void DrawContainer_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Multiplier + e.Delta / 100 > 0)
            {
                Multiplier += e.Delta / 100;
            }
        }

        private void DrawContainer_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }
    }
}
