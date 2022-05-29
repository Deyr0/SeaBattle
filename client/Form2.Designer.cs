
namespace SeaBattle
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.enemyscoretb = new System.Windows.Forms.TextBox();
            this.myscoretb = new System.Windows.Forms.TextBox();
            this.playlb = new System.Windows.Forms.Label();
            this.enemylb = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // timer2
            // 
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // enemyscoretb
            // 
            this.enemyscoretb.Location = new System.Drawing.Point(142, 48);
            this.enemyscoretb.Name = "enemyscoretb";
            this.enemyscoretb.Size = new System.Drawing.Size(100, 26);
            this.enemyscoretb.TabIndex = 0;
            // 
            // myscoretb
            // 
            this.myscoretb.Location = new System.Drawing.Point(992, 48);
            this.myscoretb.Name = "myscoretb";
            this.myscoretb.Size = new System.Drawing.Size(100, 26);
            this.myscoretb.TabIndex = 1;
            // 
            // playlb
            // 
            this.playlb.AutoSize = true;
            this.playlb.Location = new System.Drawing.Point(517, 278);
            this.playlb.Name = "playlb";
            this.playlb.Size = new System.Drawing.Size(76, 20);
            this.playlb.TabIndex = 2;
            this.playlb.Text = "твой ход";
            // 
            // enemylb
            // 
            this.enemylb.AutoSize = true;
            this.enemylb.Location = new System.Drawing.Point(599, 278);
            this.enemylb.Name = "enemylb";
            this.enemylb.Size = new System.Drawing.Size(89, 20);
            this.enemylb.TabIndex = 3;
            this.enemylb.Text = "противник";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Счет противника";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(971, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Твой счет";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1338, 1050);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enemylb);
            this.Controls.Add(this.playlb);
            this.Controls.Add(this.myscoretb);
            this.Controls.Add(this.enemyscoretb);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.gameclose);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.TextBox enemyscoretb;
        private System.Windows.Forms.TextBox myscoretb;
        private System.Windows.Forms.Label playlb;
        private System.Windows.Forms.Label enemylb;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}