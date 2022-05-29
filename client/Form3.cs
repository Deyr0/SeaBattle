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
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace SeaBattle
{
    public partial class Form3 : Form
    {
        private delegate void printer(string data);
        private delegate void booll(bool b);
        private delegate void butEnabled(bool enabled, int x, int y);
        private delegate void butColor(Color col, int x, int y);
        booll Booll;
        booll Booll2;
        printer Printer;
        printer Printer2;
        butEnabled ButEnemyEnabled;
        butEnabled ButPlayerEnabled;
        butColor ButColorPlayer;
        butColor ButColorEnemy;
        int myscore = 0;
        int enemyscore = 0;
        int FirstMove = 2;
        Button[,] fitem = new Button[10, 10];
        Button[,] enemyfitem = new Button[10, 10];
        bool playerturn = true;
        static TcpClient client;
        static NetworkStream stream;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        public Form3(Button[,] fitems)
        {
            InitializeComponent();
            fitem = fitems;
            enemylb.Visible = false;
            client = new TcpClient();

            client.Connect(host, port); //подключение клиента
            stream = client.GetStream(); // получаем поток

            string message = "111";
            byte[] data = Encoding.Unicode.GetBytes(message);
            stream.Write(data, 0, data.Length);
            Printer = new printer(print);
            Printer2 = new printer(print2);
            Booll = new booll(boolEnemy);
            Booll2 = new booll(boolPlayer);
            ButEnemyEnabled = new butEnabled(EnabledEnemy);
            ButPlayerEnabled = new butEnabled(EnabledPlayer);
            ButColorPlayer = new butColor(ColorPlayer);
            ButColorEnemy = new butColor(ColorEnemy);
            Task.Delay(1000);
            Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
            receiveThread.Start(); //старт потока

        }


        private void Form3_Load(object sender, EventArgs e)
        {
            enemyscoretb.Text = Convert.ToString(enemyscore);
            myscoretb.Text = Convert.ToString(myscore);
            
         
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    //playenemyscheme[i, j] = '0';
                    fitem[i, j].Location = new Point(270 + 16 * i, 10 + 16 * j);
                    fitem[i, j].Size = new Size(16, 16);
                    this.Controls.Add(fitem[i, j]);
                    fitem[i, j].Parent = this;
                    //fitem[i, j].Enabled = false;
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
        private void gameclose(object sender, FormClosedEventArgs e)
        {

            Environment.Exit(Environment.ExitCode);
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
                            string mess = Convert.ToString(i) + Convert.ToString(j) + "*";
                            byte[] data = Encoding.Unicode.GetBytes(mess);
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }
            }
        }
        private void ReceiveMessage()
        {
            while (true)
            {
                
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    MemoryStream Stream = new MemoryStream();
                    do
                    {
                        stream.Read(data, 0, data.Length);
                        Stream.Append(data);
                    }
                    while (stream.DataAvailable);
                    byte[] bytes = Stream.ToArray();


                    if (FirstMove == 2)
                    {
                        FirstMove = BitConverter.ToInt32(bytes, 0);
                        if (FirstMove == 1)
                        {
                            playerturn = true;
                            
                        boolPlayer(true);
                        boolEnemy(false);
                        }
                        if (FirstMove == 10)
                        {
                            playerturn = false;
                            boolPlayer(false);
                            boolEnemy(true);
                        }
                    }
                    else
                    {
                        string message = Encoding.Unicode.GetString(bytes, 0, bytes.Length);
                        
                        string a = Convert.ToString(message[0]);
                        int X = Convert.ToInt32(a);
                   
                   a = Convert.ToString(message[1]);
                    int Y = Convert.ToInt32(a);
                        char status = message[2];
                    
                    if (status == '*')
                        {
                            if (fitem[X, Y].BackColor != SystemColors.Control)
                            {
                             
                                message = Convert.ToString(X) + Convert.ToString(Y) + "1";
                            ///fitem[X, Y].BackColor = Color.Gray;
                                ColorPlayer(Color.Gray, X, Y);
                                enemyscore++;
                                print( Convert.ToString(enemyscore));
                            if (enemyscore == 20)
                            {
                                MessageBox.Show("Вы проиграли");
                                Application.Restart();
                            }
                        }
                            else
                            {
                               
                                //fitem[X, Y].BackColor = Color.LightGray;
                                ColorPlayer(Color.LightGray, X, Y);
                                message = Convert.ToString(X) + Convert.ToString(Y) + "0";
                                boolPlayer(true);
                                boolEnemy(false);
                                playerturn = true;
                            }
                        byte[] dat = Encoding.Unicode.GetBytes(message);
                        stream.Write(dat, 0, dat.Length);
                        }
                        if (status == '0')
                        {
                        //enemyfitem[X, Y].BackColor = Color.LightGray;
                            ColorEnemy(Color.LightGray, X, Y);
                            EnabledEnemy(false, X, Y);   //enemyfitem[X, Y].Enabled = false;
                            playerturn = false;
                            boolPlayer(false);
                            boolEnemy(true);
                        }
                        if (status == '1')
                        {
                            //enemyfitem[X, Y].BackColor = Color.Brown;
                            //enemyfitem[X, Y].Enabled = false;
                            ColorEnemy(Color.Brown, X, Y);
                            EnabledEnemy(false, X, Y);
                            playerturn = true;
                            myscore++;
                            print2(Convert.ToString(myscore));
                        if (myscore == 20)
                        {
                            
                            MessageBox.Show("Победа!");
                            Application.Restart();
                        }
                    }
                    }
                
            }
        }
        private void print(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer, msg);
                return;
            }
           
                enemyscoretb.Text = msg;
        }
        private void print2(string msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Printer2, msg);
                return;
            }
            
                myscoretb.Text = msg;
        }

        private void boolPlayer(bool msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Booll2, msg);
                return;
            }
            playlb.Visible = msg;
        }

        private void boolEnemy(bool msg)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(Booll, msg);
                return;
            }
            enemylb.Visible = msg;
        }

        private void EnabledPlayer(bool msg, int x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(ButPlayerEnabled, msg, x, y);
                return;
            }
            fitem[x,y].Enabled = msg;
        }
        private void EnabledEnemy(bool msg, int x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(ButEnemyEnabled, msg, x, y);
                return;
            }
            enemyfitem[x, y].Enabled = msg;
        }
        private void ColorEnemy(Color color, int x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(ButColorEnemy, color, x, y);
                return;
            }
            enemyfitem[x, y].BackColor = color;
        }
        private void ColorPlayer(Color color, int x, int y)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(ButColorPlayer, color, x, y);
                return;
            }
            fitem[x, y].BackColor = color;
        }
    }
    public static class MemoryStreamExtensions
    {
        public static void Append(this MemoryStream Stream, byte value)
        {
            Stream.Append(new[] { value });
        }

        public static void Append(this MemoryStream Stream, byte[] values)
        {
            Stream.Write(values, 0, values.Length);
        }
    }
}
