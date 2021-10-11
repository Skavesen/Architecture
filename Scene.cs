using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using AMath;
using System.IO;
using System.Drawing;

namespace Visualizer
{
    public class Scene
    {
        private bool _isPerspective;
        private bool _isWireframe;
        private bool _isFilled;
        private double _near;
        private double _far;
        private bool _isZBuffer;
        public Camera MainCamera;
        public ObservableCollection<SceneObject> ObjectList { get; set; }

        public double Far {
            get
            {
                return _far;
            }
            set
            {
                _far = value;
                ScenePropertiesChanged();
            }
        }

        public double Near
        {
            get
            {
                return _near;
            }
            set
            {
                _near = value;
                ScenePropertiesChanged();
            }
        }

        public bool IsZBuffer
        {
            get
            {
                return _isZBuffer;
            }
            set
            {
                _isZBuffer = value;
                ScenePropertiesChanged();
            }
        }

        public bool IsPerspective {
            get
            {
                return _isPerspective;
            }
            set
            {
                _isPerspective = value;
                ScenePropertiesChanged();
            }
        }

        public bool IsWireframe
        {
            get
            {
                return _isWireframe;
            }
            set
            {
                _isWireframe = value;
                ScenePropertiesChanged();
            }
        }

        public bool IsFilled
        {
            get
            {
                return _isFilled;
            }
            set
            {
                _isFilled = value;
                ScenePropertiesChanged();
            }
        }

        public event SceneChanged OnSceneChangedEvent; 
        public delegate void SceneChanged();
        public event ObjectListChanged OnObjectListChanged;
        public delegate void ObjectListChanged();

        public Scene()
        {
            MainCamera = new Camera(-4, 2, 4);
            MainCamera.OnPositionChangedEvent += ScenePropertiesChanged;
            MainCamera.OnObserverPointChangedEvent += ScenePropertiesChanged;
            MainCamera.PropertyChanged += MainCamera_PropertyChanged;
            ObjectList = new ObservableCollection<SceneObject>();
            ObjectList.CollectionChanged += ObjectCollectionChanged;
            _isPerspective = true;
            _isFilled = true;
            _isWireframe = false;
            _isZBuffer = true;
            _near = 0.2;
            _far = 100.0;
        }

        private void MainCamera_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            OnSceneChangedEvent();
        }

        public void AddObject(SceneObject obj)
        {
            obj.PropertyChanged += TransformChanged;
            ObjectList.Add(obj);
        }

        private void TransformChanged(object sender, PropertyChangedEventArgs e)
        {
            OnSceneChangedEvent();
        }

        private void ObjectCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnSceneChangedEvent();
            OnObjectListChanged();
        }

        private void ScenePropertiesChanged()
        {
            OnSceneChangedEvent();
        }

        public Scene(string fileName)
        {
            List<string> lines = new List<string>(File.ReadLines(fileName));

            _isZBuffer = Convert.ToBoolean(lines[1].Split(' ').Last());
            _isPerspective = Convert.ToBoolean(lines[2].Split(' ').Last());
            _isWireframe = Convert.ToBoolean(lines[3].Split(' ').Last());
            _isFilled = Convert.ToBoolean(lines[4].Split(' ').Last());
            _near = Convert.ToDouble(lines[5].Split(' ').Last());
            _far = Convert.ToDouble(lines[6].Split(' ').Last());
            Vector3 position = new Vector3(lines[8].Split(':').ElementAt(1).Split(';').Select(s => Convert.ToDouble(s.Trim())).ToArray());
            Vector3 observerPoint = new Vector3(lines[9].Split(':').ElementAt(1).Split(';').Select(s => Convert.ToDouble(s.Trim())).ToArray());
            MainCamera = new Camera(position, observerPoint);
            ObjectList = new ObservableCollection<SceneObject>();

            for(int i = 11; i < lines.Count; i += 20)
            {
                string name = lines[i].Substring(2, lines[i].Length - 3);
                byte[] bColor = lines[i + 2].Substring(13, lines[i + 2].Length - 14).Split(',').Select(s => Convert.ToByte(s.Trim())).ToArray();
                Color color = Color.FromArgb(bColor[0], bColor[1], bColor[2], bColor[3]);
                Vector3 transfer = new Vector3(lines[i + 3].Split(':').ElementAt(1).Split(';').Select(s => Convert.ToDouble(s.Trim())).ToArray());
                Vector3 rotation = new Vector3(lines[i + 4].Split(':').ElementAt(1).Split(';').Select(s => Convert.ToDouble(s.Trim())).ToArray());
                Vector3 scale = new Vector3(lines[i + 5].Split(':').ElementAt(1).Split(';').Select(s => Convert.ToDouble(s.Trim())).ToArray());
                int buttonCount = Convert.ToInt32(lines[i + 7].Split(' ').Last());
                double length = Convert.ToDouble(lines[i + 8].Split(' ').Last());
                double height = Convert.ToDouble(lines[i + 9].Split(' ').Last());
                double width = Convert.ToDouble(lines[i + 10].Split(' ').Last());
                int stereoCount = Convert.ToInt32(lines[i + 11].Split(' ').Last());
                double boxWidth = Convert.ToDouble(lines[i + 12].Split(' ').Last());
                double boxHeight = Convert.ToDouble(lines[i + 13].Split(' ').Last());
                double buttonRadius = Convert.ToDouble(lines[i + 14].Split(' ').Last());
                double buttonHeight = Convert.ToDouble(lines[i + 15].Split(' ').Last());
                double legRadius = Convert.ToDouble(lines[i + 16].Split(' ').Last());
                double ledHeight = Convert.ToDouble(lines[i + 17].Split(' ').Last());
                double stereoRadius = Convert.ToDouble(lines[i + 18].Split(' ').Last());
                double controle = Convert.ToDouble(lines[i + 19].Split(' ').Last());
                ObjectList.Add(new SceneObject(name, new TourDeEifel(buttonCount, length,
                    width, height, stereoCount, boxWidth, boxHeight,
                    buttonRadius, buttonHeight, legRadius,
                    ledHeight, stereoRadius, controle), transfer, rotation, scale, color));
            }

            MainCamera.OnPositionChangedEvent += ScenePropertiesChanged;
            MainCamera.OnObserverPointChangedEvent += ScenePropertiesChanged;
            MainCamera.PropertyChanged += MainCamera_PropertyChanged;
            ObjectList.CollectionChanged += ObjectCollectionChanged;
        }

        public void SaveToFile(string fileName)
        {
            List<string> result = new List<string>();

            result.Add("СЦЕНА");
            result.Add(" Буфер: " + IsZBuffer);
            result.Add(" Перспектива: " + IsPerspective);
            result.Add(" Сетка: " + IsWireframe);
            result.Add(" Полигоны: " + IsFilled);
            result.Add(" Ближняя: " + Near);
            result.Add(" Дальняя: " + Far);
            result.Add("КАМЕРА");
            result.Add(" Позиция: " + MainCamera.Position);
            result.Add(" Центр: " + MainCamera.ObserverPoint);
            result.Add(string.Format("ОБЪЕКТЫ(Count = {0})", ObjectList.Count));

            foreach(SceneObject so in ObjectList)
            {
                result.Add(" \"" + so.Name + "\"");
                result.Add(" " + string.Format(" {0} вершины, {1} полигоны", so.Mesh.Verteces.Count, so.Mesh.Faces.Count));
                result.Add("  Цвет: " + string.Format("argb({0}, {1}, {2}, {3})", so.Color.A, so.Color.R, so.Color.G, so.Color.B));
                result.Add("  Смещение: " + so.Transfer);
                result.Add("  Поворот: " + so.Rotation);
                result.Add("  Масштаб: " + so.Scale);
                result.Add("ПАРАМЕТРЫ");
                result.Add(" Кол-во сигнальных огней: " + ((TourDeEifel)so.Mesh).flagCount);
                result.Add(" Длина: " + ((TourDeEifel)so.Mesh).length);
                result.Add(" Высота: " + ((TourDeEifel)so.Mesh).height);
                result.Add(" Ширина: " + ((TourDeEifel)so.Mesh).width);
                result.Add(" Кол-во декоративных арочных проемов: " + ((TourDeEifel)so.Mesh).arcCount);
                result.Add(" Ширина 3-го этажа: " + ((TourDeEifel)so.Mesh).thirdWidth);
                result.Add(" Высота 3-го этажа: " + ((TourDeEifel)so.Mesh).thirdHeight);
                result.Add(" Высота сигнальных огней: " + ((TourDeEifel)so.Mesh).flagHeigth);
                result.Add(" Ширина сигнальных огней: " + ((TourDeEifel)so.Mesh).flagWidth);
                result.Add(" Ширина опор: " + ((TourDeEifel)so.Mesh).supportWidth);
                result.Add(" Высота опор: " + ((TourDeEifel)so.Mesh).supportHeight);
                result.Add(" Высота антены: " + ((TourDeEifel)so.Mesh).antenaHeigth);
                result.Add(" Расстояния от края: " + ((TourDeEifel)so.Mesh).controle);
            }

            File.WriteAllLines(fileName, result.ToArray());
        }
    }
}
