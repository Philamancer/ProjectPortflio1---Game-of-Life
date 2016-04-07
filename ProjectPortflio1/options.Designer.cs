namespace ProjectPortflio1
{
    partial class options
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.widthUD = new System.Windows.Forms.NumericUpDown();
            this.heightUD = new System.Windows.Forms.NumericUpDown();
            this.tickUD = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tickUD)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(25, 119);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(137, 119);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(107, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // widthUD
            // 
            this.widthUD.Location = new System.Drawing.Point(124, 31);
            this.widthUD.Name = "widthUD";
            this.widthUD.Size = new System.Drawing.Size(120, 20);
            this.widthUD.TabIndex = 2;
            // 
            // heightUD
            // 
            this.heightUD.Location = new System.Drawing.Point(124, 57);
            this.heightUD.Name = "heightUD";
            this.heightUD.Size = new System.Drawing.Size(120, 20);
            this.heightUD.TabIndex = 3;
            // 
            // tickUD
            // 
            this.tickUD.Location = new System.Drawing.Point(183, 83);
            this.tickUD.Name = "tickUD";
            this.tickUD.Size = new System.Drawing.Size(61, 20);
            this.tickUD.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Height";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(165, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Time between ticks (Milliseconds)";
            // 
            // options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 155);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tickUD);
            this.Controls.Add(this.heightUD);
            this.Controls.Add(this.widthUD);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "options";
            this.Text = "options";
            ((System.ComponentModel.ISupportInitialize)(this.widthUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tickUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown widthUD;
        private System.Windows.Forms.NumericUpDown heightUD;
        private System.Windows.Forms.NumericUpDown tickUD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}