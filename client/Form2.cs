using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//бот
namespace SeaBattle
{
    public partial class Form2 : Form
    {
        //задаем игровую карту бота
        char[,] playenemyscheme = { { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                                    { '0', '1', '0', '0', '0', '0', '0', '0', '0', '0' },
                                    { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' },
                                    { '0', '0', '4', '4', '4', '4', '0', '0', '0', '1' },
                                    { '0', '0', '0', '0', '0', '0', '0', '1', '0', '0' },
                                    { '0', '0', '0', '2', '2', '0', '0', '0', '0', '1' },
                                    { '0', '3', '0', '0', '0', '0', '2', '2', '0', '0' },
                                    { '0', '3', '0', '0', '2', '0', '0', '0', '0', '0' },
                                    { '0', '3', '0', '0', '2', '0', '3', '3', '3', '0' },
                                    { '0', '0', '0', '0', '0', '0', '0', '0', '0', '0' } };
        Button[,] fitem = new Button[10, 10];
        Button[,] enemyfitem = new Button[10, 10];
        bool playerturn = true;
        int myscore = 0;
        int enemyscore = 0;
      
        public Form2(Button[,] butarr)
        {
            InitializeComponent();
            fitem = butarr;
            enemylb.Visible = false;
        }

        private void gameclose(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void mousedown(object sender, EventArgs e)
        {
            //ход игрока
            if (playerturn)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (sender.Equals(enemyfitem[i, j]))
                        {
                            //если попал
                            if (playenemyscheme[i, j] != '0')
                            {
                                if (playenemyscheme[i, j] == '1')
                                    enemyfitem[i, j].BackColor = Color.Brown;
                                if (playenemyscheme[i, j] == '2')
                                    enemyfitem[i, j].BackColor = Color.Brown;
                                if (playenemyscheme[i, j] == '3')
                                    enemyfitem[i, j].BackColor = Color.Brown;
                                if (playenemyscheme[i, j] == '4')
                                    enemyfitem[i, j].BackColor = Color.Brown;
                                myscore++;
                                myscoretb.Text = Convert.ToString(myscore);
                                playerturn = true;
                            }
                            else
                            //промах 
                            {
                                enemyfitem[i, j].BackColor = Color.LightGray;
                                playerturn = false;
                                playlb.Visible = false;
                                enemylb.Visible = true;
                                timer1.Start();
                            }
                            enemyfitem[i, j].Enabled = false;
                        }
                    }
                }
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            timer2.Start();
            enemyscoretb.Text = Convert.ToString(enemyscore);
            myscoretb.Text = Convert.ToString(myscore);
            playlb.Visible = true;
            timer2.Interval = 1000;
            //рисуем поле бота и игрока
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //playenemyscheme[i, j] = '0';
                    fitem[i, j].Location = new Point(270 + 16 * i, 10 + 16 * j);
                    fitem[i, j].Size = new Size(16, 16);
                    this.Controls.Add(fitem[i, j]);
                    fitem[i, j].Parent = this;
                    fitem[i, j].Enabled = false;
                    enemyfitem[i, j] = new Button();
                    enemyfitem[i, j].Location = new Point(170 + 36 * i, 230 + 36 * j);
                    enemyfitem[i, j].FlatStyle = FlatStyle.Popup;
                    enemyfitem[i, j].Size = new Size(36, 36);
                    this.Controls.Add(enemyfitem[i, j]);
                    enemyfitem[i, j].BringToFront();
                    enemyfitem[i, j].Parent = this;
                    enemyfitem[i, j].MouseClick += mousedown;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //для стрельбы бота генерируем координаты кнопки
            Random rnd = new Random();
            int x = rnd.Next(0, 10);
            int y = rnd.Next(0, 10);
            
            while (fitem[x, y].BackColor == Color.Gray || fitem[x, y].BackColor == Color.LightGray)
            {
                x = rnd.Next(0, 10);
                y = rnd.Next(0, 10);
            }
            
            if (fitem[x, y].BackColor != SystemColors.Control)
            {
                fitem[x, y].BackColor = Color.Gray;
                enemyscore++;
                enemyscoretb.Text = Convert.ToString(enemyscore);
            }
            else
            {
                fitem[x, y].BackColor = Color.LightGray;
                enemylb.Visible = false;
                playlb.Visible = true;
                playerturn = true;
                timer1.Stop();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (myscore == 20)
            {
                timer2.Stop();
                MessageBox.Show("Победа!");
                Application.Restart();
            }
            if (enemyscore == 20)
            {
                timer2.Stop();
                MessageBox.Show("Вы проиграли");
                Application.Restart();
            }
        }

    }
}
