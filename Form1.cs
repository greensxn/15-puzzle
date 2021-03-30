using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PitnaForm
{
    public partial class Form1 : Form
    {
        List<int> num = new List<int>();
        Buttons button;
        private Button[] btns;
        private int btnNull = 16;
        private Color Gamma = Color.Gold;
        private Color BlackMode = Color.FromArgb(32, 32, 32);
        private String Direction = "";
        private bool Started = false;

        public Form1()
        {
            InitializeComponent();
            btns = new Button[] { button1, button2, button3, button4,
                                  button5, button6, button7, button8,
                                  button9, button10, button11, button12,
                                  button13, button14, button15, button16,
            };
            button = new Buttons(btns);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripMenuItem1_Click(blackModeToolStripMenuItem, null);
            button.ChangeColor(Gamma);
            RefreshBtn(true);
            Started = true;
        }

        private void RefreshBtn(bool x)
        {
            for (int i = 1; i <= 16; i++) {
                if (i == 16) {
                    button.getButton(i).Visible = false;
                    button.getButton(i).Text = i.ToString();
                    break;
                }
                button.getButton(i).Visible = true;
                button.getButton(i).Text = i.ToString();
            }
            btnNull = 16;
            if (x) {
                Random r = new Random();
                for (int i = 1; i <= 100; i++) {
                    int c = r.Next(1, 17);
                    ChangePosition(button.getButton(c));
                }
                btnNull = 16;
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            var btn = sender as Button;
            if (IsBeside(btn)) {
                pictureBox1.Visible = false;
                AnimationBtn(btn);
                ChangePosition(btn);

                if (Started) IsWin();
            }
        }

        private async void IsWin()
        {
            int Correct = 0;
            for (int i = 0; i < btns.Length; i++)
                if (btns[i].Text == btns[i].Tag.ToString())
                    Correct++;

            if (Correct == 15) {
                pictureBox1.Visible = true;
                //Thread.Sleep(1500);
                //await WinAnimation();
            }
        }

        private async Task WinAnimation()
        {
            int X = pictureBox1.Location.X;
            int Y = pictureBox1.Location.Y;

            //await Task.Factory.StartNew(() => {
            await Task.Factory.StartNew(() => {
                Thread.Sleep(1200);
            });
            //});

            for (int i = 1; i <= 128; i++) {
                await Task.Factory.StartNew(() => {
                    Thread.Sleep(2);
                });
                pictureBox1.Location = new Point(X - i, Y - i);
            }
            for (int i = 1; i <= 128; i++) {
                await Task.Factory.StartNew(() => {
                    Thread.Sleep(2);
                });
                pictureBox1.Location = new Point(X - i, Y - i);
            }
            await Task.Factory.StartNew(() => {
                Thread.Sleep(1200);
            });

            pictureBox1.Visible = false;
            pictureBox1.Location = new Point(X, Y);
        }

        private void AnimationBtn(Button btn)
        {
            Direction = button.Dir(Convert.ToInt32(btn.Tag), btnNull);
            if (Started)
                button.Animation(Direction, btn, btnNull);
        }

        private void ChangePosition(Button btn)
        {
            button.getButton(btnNull).Text = btn.Text;
            btnNull = Convert.ToInt32(btn.Tag);
        }

        private bool IsBeside(Button btn)
        {
            bool IsTrue = false;
            int Tag = Convert.ToInt32(btn.Tag);

            if (btnNull == Tag + 4 ||
                btnNull == Tag - 4 ||
                btnNull == Tag + 1 ||
                btnNull == Tag - 1)
                IsTrue = true;

            return IsTrue;
        }

        private void новаяИграToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;
            RefreshBtn(true);
        }


        private void toolStripMenuItem8_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.OK) {
                Gamma = this.colorDialog1.Color;
                button.ChangeColor(Gamma);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var Tool = sender as ToolStripMenuItem;
            if (Tool.Text == "Black Mode") {
                this.BackColor = BlackMode;
                menuStrip1.BackColor = BlackMode;

                настройкиToolStripMenuItem.BackColor = BlackMode;
                цветаToolStripMenuItem.BackColor = BlackMode;
                новаяИграToolStripMenuItem.BackColor = BlackMode;
                asdasdToolStripMenuItem.BackColor = BlackMode;
                настройкиToolStripMenuItem.ForeColor = Color.White;
                цветаToolStripMenuItem.ForeColor = Color.White;
                новаяИграToolStripMenuItem.ForeColor = Color.White;
                asdasdToolStripMenuItem.ForeColor = Color.White;

                Tool.BackColor = Color.White;
                Tool.ForeColor = Color.Black;
                Tool.Text = "White Mode";

                return;
            }
            else if (Tool.Text == "White Mode") {
                this.BackColor = Color.White;
                menuStrip1.BackColor = Color.White;

                настройкиToolStripMenuItem.BackColor = Color.White;
                цветаToolStripMenuItem.BackColor = Color.White;
                новаяИграToolStripMenuItem.BackColor = Color.White;
                asdasdToolStripMenuItem.BackColor = Color.White;
                настройкиToolStripMenuItem.ForeColor = Color.Black;
                цветаToolStripMenuItem.ForeColor = Color.Black;
                новаяИграToolStripMenuItem.ForeColor = Color.Black;
                asdasdToolStripMenuItem.ForeColor = Color.Black;

                Tool.BackColor = BlackMode;
                Tool.ForeColor = Color.DarkGray;
                Tool.Text = "Black Mode";

                return;
            }
            Gamma = Tool.BackColor;
            button.ChangeColor(Gamma);
        }

        private void asdasdToolStripMenuItem_Click(object sender, EventArgs e) //по порядку
        {
            RefreshBtn(false);
            int i = 1;
            foreach (var btn in btns) {
                btn.Text = i.ToString();
                i++;
            }
        }

        private void button16_MouseUp(object sender, MouseEventArgs e)
        {
            (sender as Button).FlatAppearance.MouseOverBackColor = Gamma;
        }
    }
}
