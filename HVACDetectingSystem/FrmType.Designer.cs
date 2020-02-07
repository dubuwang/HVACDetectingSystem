namespace HVACDetectingSystem
{
    partial class FrmType
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
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnD01 = new System.Windows.Forms.Button();
            this.btnD03 = new System.Windows.Forms.Button();
            this.btnD02 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(0, 485);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(1902, 6);
            this.label3.TabIndex = 5;
            this.label3.Text = "                                                                                 " +
    "                                  ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(580, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(745, 90);
            this.label5.TabIndex = 7;
            this.label5.Text = "汽 车 空 调 检 测 系 统";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(775, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(348, 57);
            this.label1.TabIndex = 8;
            this.label1.Text = "产 品 型 号 选 择";
            // 
            // btnD01
            // 
            this.btnD01.AutoSize = true;
            this.btnD01.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnD01.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD01.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnD01.Location = new System.Drawing.Point(575, 680);
            this.btnD01.Name = "btnD01";
            this.btnD01.Size = new System.Drawing.Size(145, 48);
            this.btnD01.TabIndex = 9;
            this.btnD01.Text = "D01";
            this.btnD01.UseVisualStyleBackColor = false;
            this.btnD01.Click += new System.EventHandler(this.btnD01_Click);
            // 
            // btnD03
            // 
            this.btnD03.AutoSize = true;
            this.btnD03.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnD03.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD03.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnD03.Location = new System.Drawing.Point(1179, 680);
            this.btnD03.Name = "btnD03";
            this.btnD03.Size = new System.Drawing.Size(145, 48);
            this.btnD03.TabIndex = 10;
            this.btnD03.Text = "D03";
            this.btnD03.UseVisualStyleBackColor = false;
            this.btnD03.Click += new System.EventHandler(this.btnD03_Click);
            // 
            // btnD02
            // 
            this.btnD02.AutoSize = true;
            this.btnD02.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.btnD02.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnD02.Font = new System.Drawing.Font("微软雅黑", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnD02.Location = new System.Drawing.Point(877, 680);
            this.btnD02.Name = "btnD02";
            this.btnD02.Size = new System.Drawing.Size(145, 48);
            this.btnD02.TabIndex = 11;
            this.btnD02.Text = "D02";
            this.btnD02.UseVisualStyleBackColor = false;
            this.btnD02.Click += new System.EventHandler(this.btnD02_Click);
            // 
            // FrmType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1902, 899);
            this.Controls.Add(this.btnD02);
            this.Controls.Add(this.btnD03);
            this.Controls.Add(this.btnD01);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmType";
            this.Text = "FrmBackground";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnD01;
        private System.Windows.Forms.Button btnD03;
        private System.Windows.Forms.Button btnD02;
    }
}