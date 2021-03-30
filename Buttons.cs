using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PitnaForm
{
    class Buttons
    {
        private Button[] btns;

        public Buttons(Button[] btn)
        {
            this.btns = new Button[btn.Length];
            this.btns = btn;
        }

        public Button getButton(int Tag)
        {
            return btns[Tag - 1];
        }

        public void ChangeColor(Color Color)
        {
            foreach (Button btn in btns) {
                btn.BackColor = Color;
                btn.FlatAppearance.MouseOverBackColor = Color;
                btn.FlatAppearance.MouseDownBackColor = Color;
            }
        }

        public String Dir(int btnTag, int btnNull)
        {
            String Dir = "";
            int c = btnNull - btnTag;
            if (c == 4) {
                Dir = "↓";
            }
            else if (c == 1) {
                Dir = "→";
            }
            else if (c == -1) {
                Dir = "←";
            }
            else if (c == -4) {
                Dir = "↑";
            }
            return Dir;
        }

        public void Animation(String Dir, Button btn, int btnNull)
        {
            int LocX = btn.Location.X;
            int LocY = btn.Location.Y;
            //int x = 5;
            int Sleep = 1;

            if (Dir == "↓")
                for (int i = 1; i <= 86; i++) {
                    btn.Location = new Point(LocX, LocY + i);
                    Thread.Sleep(Sleep);
                }
            if (Dir == "↑")
                for (int i = 1; i <= 86; i++) {
                    btn.Location = new Point(LocX, LocY - i);
                    Thread.Sleep(Sleep);
                }
            if (Dir == "→")
                for (int i = 1; i <= 86; i++) {
                    btn.Location = new Point(LocX + i, LocY);
                    Thread.Sleep(Sleep);
                }
            if (Dir == "←")
                for (int i = 1; i <= 86; i++) {
                    btn.Location = new Point(LocX - i, LocY);
                    Thread.Sleep(Sleep);
                }
            getButton(btnNull).Visible = true;
            btn.Visible = false;
            btn.Location = new Point(LocX, LocY);
        }

        public int[] RandomNum(int max)
        {
            Random r = new Random();
            int[] data = new int[max];
            for (int i = 1; i <= max; i++)
                data[i - 1] = i;
            for (int i = data.Length - 1; i >= 1; i--) {
                int j = r.Next(i + 1);
                var temp = data[j];
                data[j] = data[i];
                data[i] = temp;
            }
            return data;
        }
    }
}
