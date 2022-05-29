
namespace SeaBattle
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.resbut = new System.Windows.Forms.Button();
            this.procbut = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.onepb = new System.Windows.Forms.RadioButton();
            this.twopb = new System.Windows.Forms.RadioButton();
            this.threepb = new System.Windows.Forms.RadioButton();
            this.fourpb = new System.Windows.Forms.RadioButton();
            this.horrb = new System.Windows.Forms.RadioButton();
            this.verrb = new System.Windows.Forms.RadioButton();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.TwoPlayer = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // resbut
            // 
            this.resbut.Location = new System.Drawing.Point(103, 12);
            this.resbut.Name = "resbut";
            this.resbut.Size = new System.Drawing.Size(88, 38);
            this.resbut.TabIndex = 0;
            this.resbut.Text = "Сброс";
            this.resbut.UseVisualStyleBackColor = true;
            this.resbut.Click += new System.EventHandler(this.resbut_Click);
            // 
            // procbut
            // 
            this.procbut.Location = new System.Drawing.Point(103, 62);
            this.procbut.Name = "procbut";
            this.procbut.Size = new System.Drawing.Size(93, 38);
            this.procbut.TabIndex = 1;
            this.procbut.Text = "Играть";
            this.procbut.UseVisualStyleBackColor = true;
            this.procbut.Click += new System.EventHandler(this.procbut_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.onepb);
            this.groupBox1.Controls.Add(this.twopb);
            this.groupBox1.Controls.Add(this.threepb);
            this.groupBox1.Controls.Add(this.fourpb);
            this.groupBox1.Location = new System.Drawing.Point(449, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 79);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // onepb
            // 
            this.onepb.AutoSize = true;
            this.onepb.Location = new System.Drawing.Point(114, 43);
            this.onepb.Name = "onepb";
            this.onepb.Size = new System.Drawing.Size(100, 24);
            this.onepb.TabIndex = 5;
            this.onepb.TabStop = true;
            this.onepb.Text = "1 палуба";
            this.onepb.UseVisualStyleBackColor = true;
            // 
            // twopb
            // 
            this.twopb.AutoSize = true;
            this.twopb.Location = new System.Drawing.Point(114, 13);
            this.twopb.Name = "twopb";
            this.twopb.Size = new System.Drawing.Size(102, 24);
            this.twopb.TabIndex = 4;
            this.twopb.TabStop = true;
            this.twopb.Text = "2 палубы";
            this.twopb.UseVisualStyleBackColor = true;
            // 
            // threepb
            // 
            this.threepb.AutoSize = true;
            this.threepb.Location = new System.Drawing.Point(6, 43);
            this.threepb.Name = "threepb";
            this.threepb.Size = new System.Drawing.Size(102, 24);
            this.threepb.TabIndex = 3;
            this.threepb.TabStop = true;
            this.threepb.Text = "3 палубы";
            this.threepb.UseVisualStyleBackColor = true;
            // 
            // fourpb
            // 
            this.fourpb.AutoSize = true;
            this.fourpb.Location = new System.Drawing.Point(6, 13);
            this.fourpb.Name = "fourpb";
            this.fourpb.Size = new System.Drawing.Size(102, 24);
            this.fourpb.TabIndex = 0;
            this.fourpb.TabStop = true;
            this.fourpb.Text = "4 палубы";
            this.fourpb.UseVisualStyleBackColor = true;
            // 
            // horrb
            // 
            this.horrb.AutoSize = true;
            this.horrb.Location = new System.Drawing.Point(279, 12);
            this.horrb.Name = "horrb";
            this.horrb.Size = new System.Drawing.Size(151, 24);
            this.horrb.TabIndex = 5;
            this.horrb.TabStop = true;
            this.horrb.Text = "Горизонтально";
            this.horrb.UseVisualStyleBackColor = true;
            // 
            // verrb
            // 
            this.verrb.AutoSize = true;
            this.verrb.Location = new System.Drawing.Point(279, 55);
            this.verrb.Name = "verrb";
            this.verrb.Size = new System.Drawing.Size(135, 24);
            this.verrb.TabIndex = 6;
            this.verrb.TabStop = true;
            this.verrb.Text = "Вертикально";
            this.verrb.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Два игрока";
            // 
            // TwoPlayer
            // 
            this.TwoPlayer.AutoSize = true;
            this.TwoPlayer.Location = new System.Drawing.Point(62, 54);
            this.TwoPlayer.Name = "TwoPlayer";
            this.TwoPlayer.Size = new System.Drawing.Size(55, 24);
            this.TwoPlayer.TabIndex = 9;
            this.TwoPlayer.TabStop = true;
            this.TwoPlayer.Text = "Да";
            this.TwoPlayer.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.TwoPlayer);
            this.groupBox2.Location = new System.Drawing.Point(742, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 88);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 584);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.verrb);
            this.Controls.Add(this.horrb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.procbut);
            this.Controls.Add(this.resbut);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button resbut;
        private System.Windows.Forms.Button procbut;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton fourpb;
        private System.Windows.Forms.RadioButton threepb;
        private System.Windows.Forms.RadioButton twopb;
        private System.Windows.Forms.RadioButton onepb;
        private System.Windows.Forms.RadioButton horrb;
        private System.Windows.Forms.RadioButton verrb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton TwoPlayer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

