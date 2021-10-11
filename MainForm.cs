using AMath;
using System;
using System.Linq;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class MainForm : Form
    {
        public Scene MainScene = new Scene();
        
        

        public MainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            MouseWheel += MainForm_MouseWheel;
            MainScene = new Scene();
            MainScene.OnSceneChangedEvent += DrawContainerUpdate;
            MainScene.OnObjectListChanged += ChangeObjectList;
            KeyPreview = true;



        }

        private void ChangeObjectList()
        {
            int oldIndex = ObjectList.SelectedIndex;
            ObjectList.Items.Clear();
            ObjectList.Items.AddRange(MainScene.ObjectList.ToArray());
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if(e.Delta > 0)
            {
                MainScene.MainCamera.GoCloser(0.1);
            }
            else
            {
                MainScene.MainCamera.GoFarther(0.1);
            }
        }

        private void DrawContainerUpdate()
        {
            drawContainer1.DrawScene = MainScene;
            drawContainer1.Invalidate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MainScene.ObjectList[1].Rotation.X += 5;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MainScene.ObjectList[1].Rotation.Y += 5;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MainScene.ObjectList[1].Rotation.Y -= 5;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MainScene.ObjectList[1].Rotation.X -= 5;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.NumPad5:
                    MainScene.IsPerspective = !MainScene.IsPerspective;
                    break;
                case Keys.P:
                    MainScene.IsPerspective = !MainScene.IsPerspective;
                    break;
                case Keys.Z:
                    MainScene.IsZBuffer = !MainScene.IsZBuffer;
                    break;
                case Keys.Add:
                    MainScene.MainCamera.GoCloser(0.1);
                    break;
                case Keys.Subtract:
                    MainScene.MainCamera.GoFarther(0.1);
                    break;
            }
        }

        private void AddObject_Click(object sender, EventArgs e)
        {
            AddNewObject();
        }

        private void RemoteControlReady(int buttonCount,
            double length,
            double width,
            double height,
            int stereoCount,
            double boxButtonWidth,
            double boxButtonHeight,
            double centralButtonRadius,
            double centralButtonHeight,
            double smallButtonRadius,
            double smallButtonHeight,
            double lampRadius,
            double buttonControle,
            string name)
        {
            MainScene.AddObject(new SceneObject(new TourDeEifel(buttonCount,
                length, width, height, stereoCount, boxButtonWidth, boxButtonHeight, centralButtonRadius, centralButtonHeight,
                smallButtonRadius, smallButtonHeight, lampRadius, buttonControle), name));
        }

        private void AddNewObject()
        {
            if(ObjectList.SelectedItem != null)
            {
                TourParams RemoteControlParamsForm = new TourParams(SceneObject.counter, ((TourDeEifel)((SceneObject)ObjectList.SelectedItem).Mesh));
                RemoteControlParamsForm.OnStereoReady += RemoteControlReady;
                RemoteControlParamsForm.ShowDialog();
                RemoteControlParamsForm.Dispose();
            }
            else
            {
                TourParams RemoteControlParamsForm = new TourParams(SceneObject.counter);
                RemoteControlParamsForm.OnStereoReady += RemoteControlReady;
                RemoteControlParamsForm.ShowDialog();
                RemoteControlParamsForm.Dispose();
            }
        }

        private void RemoteControlChange(int buttonCount,
            double length,
            double width,
            double height,
            int stereoCount,
            double boxButtonWidth,
            double boxButtonHeight,
            double centralButtonRadius,
            double centralButtonHeight,
            double smallButtonRadius,
            double smallButtonHeight,
            double lampRadius,
            double buttonControle,
            string name)
        {
            Vector3 transfer = ((SceneObject)ObjectList.SelectedItem).Transfer;
            Vector3 rotation = ((SceneObject)ObjectList.SelectedItem).Rotation;
            Vector3 scale = ((SceneObject)ObjectList.SelectedItem).Scale;
            MainScene.ObjectList.Remove(((SceneObject)ObjectList.SelectedItem));
            MainScene.AddObject(new SceneObject(new TourDeEifel(buttonCount, length,
                width, height, stereoCount, boxButtonWidth, boxButtonHeight,
                centralButtonRadius, centralButtonHeight, smallButtonRadius,
                smallButtonHeight, lampRadius, buttonControle), 
                transfer, rotation, scale, name));
        }

        private void ChangeObject()
        {
            if (ObjectList.SelectedItem != null)
            {
                TourParams RemoteControlParamsForm = new TourParams(((TourDeEifel)((SceneObject)ObjectList.SelectedItem).Mesh), ObjectList.SelectedItem.ToString());
                RemoteControlParamsForm.OnStereoReady += RemoteControlChange;
                RemoteControlParamsForm.ShowDialog();
                RemoteControlParamsForm.Dispose();
            }
        }

        private void ChangeObjectProperty_Click(object sender, EventArgs e)
        {
            ChangeObject();
        }

        private void DeleteObject_Click(object sender, EventArgs e)
        {
            if(ObjectList.SelectedItem != null)
            {
                MainScene.ObjectList.Remove((SceneObject)ObjectList.SelectedItem);
            }
        }

        private void ChangeProjection_Click(object sender, EventArgs e)
        {
            MainScene.IsPerspective = !MainScene.IsPerspective;
        }

        private void Near_ValueChanged(object sender, EventArgs e)
        {
            //MainScene.Near = (double)Near.Value;
        }

        private void Far_ValueChanged(object sender, EventArgs e)
        {
            //MainScene.Far = (double)Far.Value;
        }

        private void TransferX_ValueChanged(object sender, EventArgs e)
        {
            if(ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Transfer.X = (double)TransferX.Value;
            }
        }

        private void TransferY_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Transfer.Y = (double)TransferY.Value;
            }
        }

        private void TransferZ_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Transfer.Z = (double)TransferZ.Value;
            }
        }

        private void RotateX_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Rotation.X = (double)RotateX.Value;
            }
        }

        private void RotateY_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Rotation.Y = (double)RotateY.Value;
            }
        }

        private void RotateZ_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Rotation.Z = (double)RotateZ.Value;
            }
        }

        private void ScaleX_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Scale.X = (double)ScaleX.Value;
            }
        }

        private void ScaleY_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Scale.Y = (double)ScaleY.Value;
            }
        }

        private void ScaleZ_ValueChanged(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                ((SceneObject)ObjectList.SelectedItem).Scale.Z = (double)ScaleZ.Value;
            }
        }

        private void CameraX_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.ObserverPoint.X = (double)CameraX.Value;
            MainScene.IsPerspective = true;
        }

        private void CameraY_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.ObserverPoint.Y = (double)CameraY.Value;
            MainScene.IsPerspective = true;

        }

        private void CameraZ_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.ObserverPoint.Z = (double)CameraZ.Value;
            MainScene.IsPerspective = true;

        }

        private void EyeX_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.Position.X = (double)EyeX.Value;
            MainScene.IsPerspective = true;
        }

        private void EyeY_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.Position.Y = (double)EyeY.Value;
            MainScene.IsPerspective = true;
        }

        private void EyeZ_ValueChanged(object sender, EventArgs e)
        {
            MainScene.MainCamera.Position.Z = (double)EyeZ.Value;
            MainScene.IsPerspective = true;
        }

        private void ObjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ObjectList.SelectedItem != null)
            {
                TransferX.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Transfer.X;
                TransferY.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Transfer.Y;
                TransferZ.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Transfer.Z;
                RotateX.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Rotation.X;
                RotateY.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Rotation.Y;
                RotateZ.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Rotation.Z;
                ScaleX.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Scale.X;
                ScaleY.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Scale.Y;
                ScaleZ.Value = (decimal)((SceneObject)ObjectList.SelectedItem).Scale.Z;
            }
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            if(ObjectList.SelectedItem != null)
            {
                if(colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    ((SceneObject)ObjectList.SelectedItem).Color = colorDialog1.Color;
                }
            }
        }

        private void добавитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddNewObject();
        }

        private void изменитьПараметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeObject();
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ObjectList.SelectedItem != null)
            {
                MainScene.ObjectList.Remove((SceneObject)ObjectList.SelectedItem);
            }
        }

        private void сохранитьСценуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.DefaultExt = ".sn";

            if (ObjectList.SelectedItem != null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MainScene.SaveToFile(saveFileDialog1.FileName);
                }
            }
            else
            {
                MessageBox.Show("Выберите объект из списка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void открытьСценуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Scene files (*.sn)|*.sn";

            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                MainScene = new Scene(openFileDialog1.FileName);
                MainScene.OnSceneChangedEvent += DrawContainerUpdate;
                MainScene.OnObjectListChanged += ChangeObjectList;
                ChangeObjectList();
                DrawContainerUpdate();
            }
        }
       
        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            MainScene.MainCamera.Rotate(AMathHelper.ToRadians(trackBar1.Value), AMathHelper.ToRadians(trackBar2.Value));
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            MainScene.MainCamera.Rotate(AMathHelper.ToRadians(trackBar1.Value), AMathHelper.ToRadians(trackBar2.Value));
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked == true)
            {
                MainScene.IsFilled = true;
                MainScene.IsWireframe = false;
            }
            else
            {
                MainScene.IsFilled = false;
                MainScene.IsWireframe = true;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                MainScene.IsFilled = true;
                MainScene.IsWireframe = false;
            }
            else
            {
                MainScene.IsFilled = false;
                MainScene.IsWireframe = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MainScene.MainCamera.GoCloser(0.1);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            MainScene.MainCamera.GoFarther(0.1);
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Работа выполенена ст. гр. ИПО-14а Морневой А. Е. 2017г.", "Справка");
        }

        private void выходToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Выход",
                                         MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Close();
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton4.Checked == true)
            {
                MainScene.IsPerspective = false;
            }
            else
            {
                MainScene.IsPerspective = true;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                MainScene.IsPerspective = true;
            }
            else
            {
                MainScene.IsPerspective = false;
            }

        }
    }
}
