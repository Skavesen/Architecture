using System;
using System.Windows.Forms;

namespace Visualizer
{
    public partial class TourParams : Form
    {
        public event StereoReady OnStereoReady;
        public delegate void StereoReady(int buttonCount, double length, double width, double height, int stereoCount, 
            double legRadius, double legHeight, double boxWidth, double boxHeight, double buttonRadius,
            double buttonHeight, double stereoRadius, double controle, string name);

        public TourParams(int index)
        {
            InitializeComponent();
            NameBox.Text = "Башня_" + index;
        }

        public TourParams(TourDeEifel remoteControl, string name)
        {
            InitializeComponent();
            flagCount.Value = (decimal)(remoteControl.flagCount);
            //length.Value = (decimal)(remoteControl.length);
            //width.Value = (decimal)(remoteControl.width);
            //height.Value = (decimal)(remoteControl.height);
            arcCount.Value = (decimal)(remoteControl.arcCount);
            thirdWidth.Value = (decimal)(remoteControl.thirdWidth);
            thirdHeight.Value = (decimal)(remoteControl.thirdHeight);
            flagHeigth.Value = (decimal)(remoteControl.flagHeigth);
            flagWidth.Value = (decimal)(remoteControl.flagWidth);
            supportHeigth.Value = (decimal)(remoteControl.supportWidth);
            supportWidth.Value = (decimal)(remoteControl.supportHeight);
            antenaHeight.Value = (decimal)(remoteControl.antenaHeigth);
            //controle.Value = (decimal)(remoteControl.controle);
            NameBox.Text = name;
            button2.Text = "Изменить";
        }

        public TourParams(int index, TourDeEifel remoteControl)
        {
            InitializeComponent();
            NameBox.Text = "Объект" + index;
            flagCount.Value = (decimal)(remoteControl.flagCount);
            //length.Value = (decimal)(remoteControl.length);
            //width.Value = (decimal)(remoteControl.width);
            //height.Value = (decimal)(remoteControl.height);
            arcCount.Value = (decimal)(remoteControl.arcCount);
            thirdWidth.Value = (decimal)(remoteControl.thirdWidth);
            thirdHeight.Value = (decimal)(remoteControl.thirdHeight);
            flagHeigth.Value = (decimal)(remoteControl.flagHeigth);
            flagWidth.Value = (decimal)(remoteControl.flagWidth);
            supportHeigth.Value = (decimal)(remoteControl.supportWidth);
            supportWidth.Value = (decimal)(remoteControl.supportHeight);
            antenaHeight.Value = (decimal)(remoteControl.antenaHeigth);
            //controle.Value = (decimal)(remoteControl.controle);
        }

        private void Noop() { }

        private void button2_Click(object sender, EventArgs e)
        {
            if (flagCount.Value > 4)
            {
                MessageBox.Show("Сигнальных огней не может быть больше 4-х!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (arcCount.Value > 4)
            {
                MessageBox.Show("Декоративных арочных конструкций не может быть больше 4-х!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (supportWidth.Value > (decimal) 4)
            {
                MessageBox.Show("Высота опор не может быть больше 4-х метров!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (supportHeigth.Value > (decimal) 10)
            {
                MessageBox.Show("Высота опор не может быть больше 10-ти метров!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (antenaHeight.Value > (decimal) 10)
            {
                MessageBox.Show("Высота антены не может быть больше 10-ти метров!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (flagHeigth.Value > antenaHeight.Value / (decimal) 2)
            {
                MessageBox.Show("Высота сигнальных огней не может превышать 1/2 от высоты антены!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (thirdHeight.Value > (decimal) 2)
            {
                MessageBox.Show("Высота 3-го этажа башни не может превышать 2-х метров!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (thirdWidth.Value > (decimal) 5)
            {
                MessageBox.Show("Ширина 3-го этажа башни не может превышать 5-ти метров!",
                    "Tour De Eifel | Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            OnStereoReady((int)flagCount.Value, 0, 0, 
                0, (int)arcCount.Value, (double)thirdWidth.Value, 
                (double)thirdHeight.Value, (double)flagHeigth.Value, 
                (double)flagWidth.Value, (double)supportHeigth.Value, 
                (double)supportWidth.Value, (double)antenaHeight.Value, 
                0, NameBox.Text);
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
