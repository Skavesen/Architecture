using AMath;
using System.ComponentModel;
using System.Drawing;

namespace Visualizer
{
    public class SceneObject
    {
        private Mesh _mesh;
        public Vector3 _transfer;
        public Vector3 _rotate;
        public Vector3 _scale;
        private Color _color;

        public Mesh Mesh
        {
            get
            {
                return _mesh;
            }
            set
            {
                _mesh = value;
                OnCoordinateChanged("Mesh");
            }
        }

        public Color Color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnCoordinateChanged("Color");
            }
        }

        public Vector3 Transfer
        {
            get
            {
                return _transfer;
            }
            set
            {
                _transfer = value;
                OnCoordinateChanged("Transform");
            }
        }

        public Vector3 Rotation
        {
            get
            {
                return _rotate;
            }
            set
            {
                _rotate = value;
                OnCoordinateChanged("Rotate");
            }
        }

        public Vector3 Scale
        {
            get
            {
                return _scale;
            }
            set
            {
                _scale = value;
                OnCoordinateChanged("Scale");
            }
        }

        public string Name;
        public static int counter;

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnCoordinateChanged(string propertyName)
        {
            OnCoordinateChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected void OnCoordinateChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }

        private void CameraObserverPointChanged(object sender, PropertyChangedEventArgs e)
        {
            OnCoordinateChanged(e.PropertyName);
        }

        public SceneObject()
        {
            Mesh = new Mesh();
            Transfer = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3();
            Color = Color.Aqua;
            Transfer.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = "NewObject" + counter;
            counter++;
        }

        public SceneObject(SceneObject other)
        {
            _mesh = new Mesh(other.Mesh);
            _transfer = other.Transfer;
            _rotate = other.Rotation;
            _scale = other.Scale;
            Color = other.Color;
            Transfer.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = other.Name;
            counter++;
        }

        public SceneObject(Mesh Mesh)
        {
            this.Mesh = Mesh;
            Transfer = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3(1, 1, 1);
            Color = Color.Aqua;
            Transfer.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = "NewObject" + counter;
            counter++;
        }

        public SceneObject(Mesh Mesh, string name)
        {
            this.Mesh = Mesh;
            Transfer = new Vector3();
            Rotation = new Vector3();
            Scale = new Vector3(1, 1, 1);
            Color = Color.Aqua;
            Transfer.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = name;
            counter++;
        }

        public SceneObject(Mesh Mesh, Vector3 Transform, Vector3 Rotation, Vector3 Scale)
        {
            this.Mesh = Mesh;
            this.Transfer = Transform;
            this.Rotation = Rotation;
            this.Scale = Scale;
            Color = Color.Aqua;
            Transform.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = "NewObject" + counter;
            counter++;
        }

        public SceneObject(Mesh Mesh, Vector3 Transform, Vector3 Rotation, Vector3 Scale, string name)
        {
            this.Mesh = Mesh;
            this.Transfer = Transform;
            this.Rotation = Rotation;
            this.Scale = Scale;
            Color = Color.Aqua;
            Transform.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            Name = name;
            counter++;
        }

        public SceneObject(string name, Mesh Mesh, Vector3 Transform, Vector3 Rotation, Vector3 Scale, Color color)
        {
            Name = name;
            Color = color;
            this.Mesh = Mesh;
            this.Transfer = Transform;
            this.Rotation = Rotation;
            this.Scale = Scale;
            Transform.PropertyChanged += CameraObserverPointChanged;
            Rotation.PropertyChanged += CameraObserverPointChanged;
            Scale.PropertyChanged += CameraObserverPointChanged;
            counter++;
        }

        public Color RenderColor(double multiplier)
        {
            return Color.FromArgb(Color.A, (int)(139 * multiplier), (int)(69 * multiplier), (int)(19 * multiplier));
        }

        public override string ToString()
        {
            return Name;
        }
    }
}