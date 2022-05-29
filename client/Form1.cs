using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace SeaBattle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //задаем количества кораблей
        int onekol = 4;
        int twokol = 3;
        int threekol = 2;
        int fourkol = 1;
        //задаем игровое поле
        Button[,] fitems = new Button[10, 10];
        bool twoPlayer = false;
        //начинаем расставлять корабли
        private void fitemmouseclick(object sender, EventArgs e)
        {
            if ((onepb.Checked || twopb.Checked || threepb.Checked || fourpb.Checked) && (horrb.Checked || verrb.Checked))
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (sender.Equals(fitems[i, j]))
                        {
                            if (onepb.Checked)
                            {
                                fitems[i, j].BackColor = Color.Brown;
                                fitems[i, j].Enabled = false;
                                onekol--;
                                if (i - 1 > -1)
                                {
                                    fitems[i - 1, j].BackColor = Color.LightGray;
                                    fitems[i - 1, j].Enabled = false;
                                    if (j + 1 < 10)
                                    {
                                        fitems[i - 1, j + 1].BackColor = Color.LightGray;
                                        fitems[i - 1, j + 1].Enabled = false;
                                    }
                                    if (j - 1 > -1)
                                    {
                                        fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                        fitems[i - 1, j - 1].Enabled = false;
                                    }
                                }
                                if (i + 1 < 10)
                                {
                                    fitems[i + 1, j].BackColor = Color.LightGray;
                                    fitems[i + 1, j].Enabled = false;
                                    if (j + 1 < 10)
                                    {
                                        fitems[i + 1, j + 1].BackColor = Color.LightGray;
                                        fitems[i + 1, j + 1].Enabled = false;
                                    }
                                    if (j - 1 > -1)
                                    {
                                        fitems[i + 1, j - 1].BackColor = Color.LightGray;
                                        fitems[i + 1, j - 1].Enabled = false;
                                    }
                                }
                                if (j - 1 > -1)
                                {
                                    fitems[i, j - 1].BackColor = Color.LightGray;
                                    fitems[i, j - 1].Enabled = false;
                                }
                                if (j + 1 < 10)
                                {
                                    fitems[i, j + 1].BackColor = Color.LightGray;
                                    fitems[i, j + 1].Enabled = false;
                                }
                            }
                            if (twopb.Checked)
                            {
                                if (horrb.Checked)
                                {
                                    bool check = true;
                                    if (i + 1 < 10)
                                    {
                                        for (int q = i; q < i + 2; q++)
                                        {
                                            if (fitems[q, j].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            twokol--;
                                            int t = i;
                                            while (t < i + 2)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.Brown;
                                                fitems[t, j].Enabled = false;
                                                t++;
                                            }
                                            if (i > 0)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[i - 1, j + 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i - 1, j].BackColor = Color.LightGray;
                                                fitems[i - 1, j].Enabled = false;
                                            }
                                            if (t < 10)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.LightGray;
                                                fitems[t, j].Enabled = false;
                                            }
                                        }
                                    }
                                    else
                                        MessageBox.Show("Нельзя поставить");
                                }
                                else
                                {
                                    bool check = true;
                                    if (j + 1 < 10)
                                    {
                                        for (int q = j; q < j + 2; q++)
                                        {
                                            if (fitems[i, q].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            twokol--;
                                            int t = j;
                                            while (t < j + 2)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.Brown;
                                                fitems[i, t].Enabled = false;
                                                t++;
                                            }
                                            if (j > 0)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i + 1, j - 1].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i, j - 1].BackColor = Color.LightGray;
                                                fitems[i, j - 1].Enabled = false;
                                            }
                                            if (t < 10)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.LightGray;
                                                fitems[i, t].Enabled = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Нельзя поставить");
                                    }
                                }
                            }
                            if (threepb.Checked)
                            {
                                if (horrb.Checked)
                                {
                                    bool check = true;
                                    if (i + 2 < 10)
                                    {
                                        for (int q = i; q < i + 3; q++)
                                        {
                                            if (fitems[q, j].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            threekol--;
                                            int t = i;
                                            while (t < i + 3)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.Brown;
                                                fitems[t, j].Enabled = false;
                                                t++;
                                            }
                                            if (i > 0)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[i - 1, j + 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i - 1, j].BackColor = Color.LightGray;
                                                fitems[i - 1, j].Enabled = false;
                                            }
                                            if (t < 10)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.LightGray;
                                                fitems[t, j].Enabled = false;
                                            }

                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Нельзя поставить");
                                    }
                                }
                                else
                                {
                                    if (j + 2 < 10)
                                    {
                                        bool check = true;
                                        for (int q = j; q < j + 3; q++)
                                        {
                                            if (fitems[i, q].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            threekol--;
                                            int t = j;
                                            while (t < j + 3)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.Brown;
                                                fitems[i, t].Enabled = false;
                                                t++;
                                            }
                                            if (j - 1 > 0)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i + 1, j - 1].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i, j - 1].BackColor = Color.LightGray;
                                            }
                                            if (t < 10)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.LightGray;
                                                fitems[i, t].Enabled = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Нельзя поставить");
                                    }
                                }
                            }
                            if (fourpb.Checked)
                            {
                                if (horrb.Checked)
                                {
                                    if (i + 3 < 10)
                                    {
                                        bool check = true;
                                        for (int q = i; q < i + 4; q++)
                                        {
                                            if (fitems[q, j].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            fourkol--;
                                            int t = i;
                                            while (t < i + 4)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.Brown;
                                                fitems[t, j].Enabled = false;
                                                t++;
                                            }
                                            if (i > 0)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[i - 1, j + 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i - 1, j].BackColor = Color.LightGray;
                                                fitems[i - 1, j].Enabled = false;
                                            }
                                            if (t < 10)
                                            {
                                                if (j + 1 < 10)
                                                {
                                                    fitems[t, j + 1].BackColor = Color.LightGray;
                                                    fitems[t, j + 1].Enabled = false;
                                                }
                                                if (j - 1 > -1)
                                                {
                                                    fitems[t, j - 1].BackColor = Color.LightGray;
                                                    fitems[t, j - 1].Enabled = false;
                                                }
                                                fitems[t, j].BackColor = Color.LightGray;
                                                fitems[t, j].Enabled = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Нельзя поставаить");
                                    }
                                }
                                else
                                {
                                    if (j + 3 < 10)
                                    {
                                        bool check = true;
                                        for (int q = j; q < j + 4; q++)
                                        {
                                            if (fitems[i, q].BackColor != SystemColors.Control)
                                                check = false;
                                        }
                                        if (check)
                                        {
                                            fourkol--;
                                            int t = j;
                                            while (t < j + 4)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.Brown;
                                                fitems[i, t].Enabled = false;
                                                t++;
                                            }
                                            if (j - 1 > 0)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i + 1, j - 1].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, j - 1].BackColor = Color.LightGray;
                                                    fitems[i - 1, j - 1].Enabled = false;
                                                }
                                                fitems[i, j - 1].BackColor = Color.LightGray;
                                                fitems[i, j - 1].Enabled = false;
                                            }
                                            if (t < 10)
                                            {
                                                if (i + 1 < 10)
                                                {
                                                    fitems[i + 1, t].BackColor = Color.LightGray;
                                                    fitems[i + 1, t].Enabled = false;
                                                }
                                                if (i - 1 > -1)
                                                {
                                                    fitems[i - 1, t].BackColor = Color.LightGray;
                                                    fitems[i - 1, t].Enabled = false;
                                                }
                                                fitems[i, t].BackColor = Color.LightGray;
                                                fitems[i, t].Enabled = false;
                                            }

                                        }
                                    }
                                    else
                                        MessageBox.Show("Нельзя поставить");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите значения");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            //создаем поле кнопок на форме
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button fitem = new Button();
                    fitem.Size = new Size(32, 32);
                    fitem.Location = new Point(32 * i + 80, 32 * j + 120);
                    fitems[i, j] = fitem;
                    this.Controls.Add(fitems[i, j]);
                    fitems[i, j].Parent = this;
                    fitems[i, j].BringToFront();
                    fitems[i, j].FlatStyle = FlatStyle.Popup;
                    fitems[i, j].MouseClick += fitemmouseclick;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //для отображения количества палуб на форме
            if (onekol == 0)
            {
                onepb.Enabled = false;
                onepb.Checked = false;
            }
            if (twokol == 0)
            {
                twopb.Enabled = false;
                twopb.Checked = false;
            }
            if (threekol == 0)
            {
                threepb.Enabled = false;
                threepb.Checked = false;
            }
            if (fourkol == 0)
            {
                fourpb.Enabled = false;
                fourpb.Checked = false;
            }
            //если все корабли расствлены, можно начать игру
            if (onekol == 0 && twokol == 0 && threekol == 0 && fourkol == 0)
                procbut.Enabled = true;
        }

        private void resbut_Click(object sender, EventArgs e)
        {
            reset();
        }

        private void procbut_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (fitems[i, j].BackColor == Color.LightGray)
                        fitems[i, j].BackColor = SystemColors.Control;
                }
            }

            if(TwoPlayer.Checked)
            {
                Form3 gameForm = new Form3(fitems);
                gameForm.Show();

            }
            else
            {
                Form2 gameform = new Form2(fitems);
                gameform.Show();                
            }
            this.Enabled = false;
        }
        private void reset()
        {
            //сброс
            procbut.Enabled = false;
            fourkol = 1;
            threekol = 2;
            twokol = 3;
            onekol = 4;
            fourpb.Enabled = true;
            threepb.Enabled = true;
            twopb.Enabled = true;
            onepb.Enabled = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    fitems[i, j].Enabled = true;
                    fitems[i, j].BackColor = SystemColors.Control;
                }
            }
        }
    }
}
