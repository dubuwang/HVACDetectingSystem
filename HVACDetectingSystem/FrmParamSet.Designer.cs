namespace HVACDetectingSystem
{
    partial class FrmParamSet
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSet = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRead = new System.Windows.Forms.Button();
            this.cboType = new System.Windows.Forms.ComboBox();
            this.dgvParamSet = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamSet)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.label4.BackColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(490, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(6, 900);
            this.label4.TabIndex = 7;
            this.label4.Text = "                                                                                 " +
    "                                  ";
            // 
            // lblSet
            // 
            this.lblSet.AutoSize = true;
            this.lblSet.Font = new System.Drawing.Font("微软雅黑", 25.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblSet.Location = new System.Drawing.Point(770, 15);
            this.lblSet.Name = "lblSet";
            this.lblSet.Size = new System.Drawing.Size(314, 57);
            this.lblSet.TabIndex = 9;
            this.lblSet.Text = "参   数   设   置";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(100, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 27);
            this.label2.TabIndex = 10;
            this.label2.Text = "产品型号：";
            // 
            // btnRead
            // 
            this.btnRead.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnRead.Location = new System.Drawing.Point(195, 205);
            this.btnRead.Name = "btnRead";
            this.btnRead.Size = new System.Drawing.Size(225, 40);
            this.btnRead.TabIndex = 12;
            this.btnRead.Text = "读取参数";
            this.btnRead.UseVisualStyleBackColor = true;
            this.btnRead.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // cboType
            // 
            this.cboType.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.cboType.FormattingEnabled = true;
            this.cboType.Location = new System.Drawing.Point(195, 135);
            this.cboType.Name = "cboType";
            this.cboType.Size = new System.Drawing.Size(225, 35);
            this.cboType.TabIndex = 13;
            // 
            // dgvParamSet
            // 
            this.dgvParamSet.AllowUserToAddRows = false;
            this.dgvParamSet.AllowUserToDeleteRows = false;
            this.dgvParamSet.AllowUserToResizeColumns = false;
            this.dgvParamSet.AllowUserToResizeRows = false;
            this.dgvParamSet.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParamSet.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvParamSet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParamSet.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.ValueUpper,
            this.ValueLower});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParamSet.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvParamSet.EnableHeadersVisualStyles = false;
            this.dgvParamSet.Location = new System.Drawing.Point(565, 85);
            this.dgvParamSet.Name = "dgvParamSet";
            this.dgvParamSet.RowHeadersVisible = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvParamSet.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvParamSet.RowTemplate.Height = 27;
            this.dgvParamSet.Size = new System.Drawing.Size(750, 800);
            this.dgvParamSet.TabIndex = 16;
            // 
            // ParamName
            // 
            this.ParamName.DataPropertyName = "Note";
            this.ParamName.HeaderText = "参数名";
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            this.ParamName.Width = 300;
            // 
            // ValueUpper
            // 
            this.ValueUpper.DataPropertyName = "ValueUpper";
            this.ValueUpper.HeaderText = "上限值";
            this.ValueUpper.Name = "ValueUpper";
            this.ValueUpper.Width = 224;
            // 
            // ValueLower
            // 
            this.ValueLower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueLower.DataPropertyName = "ValueLower";
            this.ValueLower.HeaderText = "下限值";
            this.ValueLower.Name = "ValueLower";
            this.ValueLower.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(195, 430);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(225, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "保存参数";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FrmParamSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1902, 899);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dgvParamSet);
            this.Controls.Add(this.cboType);
            this.Controls.Add(this.btnRead);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSet);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmParamSet";
            this.Text = "FrmParamSet";
            ((System.ComponentModel.ISupportInitialize)(this.dgvParamSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRead;
        private System.Windows.Forms.ComboBox cboType;
        private System.Windows.Forms.DataGridView dgvParamSet;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueLower;
        private System.Windows.Forms.Button btnSave;
    }
}