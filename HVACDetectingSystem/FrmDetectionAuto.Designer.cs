namespace HVACDetectingSystem
{
    partial class FrmDetectionAuto
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LComm = new MyControls.UserLantern();
            this.txtVoltage = new System.Windows.Forms.TextBox();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBlower_Gear = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtBlower_Current = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtModeMotor_Current = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtHeatMotor_Current = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtCycleMotor_Current = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.PTC_R = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtEnv_Temp = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txtPTC_Temp = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.txtChiller_Temp = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.txtIndoorSensor_Temp = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ugcMode = new MyControls.UserGaugeChart();
            this.ugcHeat = new MyControls.UserGaugeChart();
            this.label26 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.userLantern1 = new MyControls.UserLantern();
            this.userLantern2 = new MyControls.UserLantern();
            this.LFaceDef_Sponge = new MyControls.UserLantern();
            this.label30 = new System.Windows.Forms.Label();
            this.LExpansion_Sponge = new MyControls.UserLantern();
            this.label31 = new System.Windows.Forms.Label();
            this.LWind_Sponge = new MyControls.UserLantern();
            this.label32 = new System.Windows.Forms.Label();
            this.LTube_Direction = new MyControls.UserLantern();
            this.label33 = new System.Windows.Forms.Label();
            this.dgvParam = new System.Windows.Forms.DataGridView();
            this.ParamName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueUpper = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ValueLower = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsPassed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtUnPass = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timerCheckComm = new System.Windows.Forms.Timer(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(52, 186);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "合格数量：";
            // 
            // txtPass
            // 
            this.txtPass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPass.Location = new System.Drawing.Point(133, 183);
            this.txtPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(53, 29);
            this.txtPass.TabIndex = 2;
            this.txtPass.Text = "0";
            this.txtPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTitle.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.lblTitle, 3);
            this.lblTitle.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblTitle.Location = new System.Drawing.Point(211, 0);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(334, 46);
            this.lblTitle.TabIndex = 7;
            this.lblTitle.Text = "D01空调总成生产线";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(39, 44);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 21);
            this.label2.TabIndex = 8;
            this.label2.Text = "通信指示灯：";
            // 
            // LComm
            // 
            this.LComm.BackColor = System.Drawing.Color.Transparent;
            this.LComm.LanternBackground = System.Drawing.Color.Red;
            this.LComm.Location = new System.Drawing.Point(135, 41);
            this.LComm.Name = "LComm";
            this.LComm.Size = new System.Drawing.Size(28, 28);
            this.LComm.TabIndex = 9;
            // 
            // txtVoltage
            // 
            this.txtVoltage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVoltage.Location = new System.Drawing.Point(133, 259);
            this.txtVoltage.Margin = new System.Windows.Forms.Padding(2);
            this.txtVoltage.Name = "txtVoltage";
            this.txtVoltage.Size = new System.Drawing.Size(53, 29);
            this.txtVoltage.TabIndex = 11;
            this.txtVoltage.Text = "24";
            this.txtVoltage.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblVoltage
            // 
            this.lblVoltage.AutoSize = true;
            this.lblVoltage.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblVoltage.Location = new System.Drawing.Point(52, 262);
            this.lblVoltage.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(90, 21);
            this.lblVoltage.TabIndex = 10;
            this.lblVoltage.Text = "电源电压：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(190, 262);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 21);
            this.label7.TabIndex = 14;
            this.label7.Text = "V";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(37, 300);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "鼓风机档位：";
            // 
            // txtBlower_Gear
            // 
            this.txtBlower_Gear.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBlower_Gear.Location = new System.Drawing.Point(133, 297);
            this.txtBlower_Gear.Margin = new System.Windows.Forms.Padding(2);
            this.txtBlower_Gear.Name = "txtBlower_Gear";
            this.txtBlower_Gear.Size = new System.Drawing.Size(53, 29);
            this.txtBlower_Gear.TabIndex = 16;
            this.txtBlower_Gear.Text = "0";
            this.txtBlower_Gear.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(190, 300);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "档";
            // 
            // txtBlower_Current
            // 
            this.txtBlower_Current.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBlower_Current.Location = new System.Drawing.Point(133, 335);
            this.txtBlower_Current.Margin = new System.Windows.Forms.Padding(2);
            this.txtBlower_Current.Name = "txtBlower_Current";
            this.txtBlower_Current.Size = new System.Drawing.Size(53, 29);
            this.txtBlower_Current.TabIndex = 19;
            this.txtBlower_Current.Text = "0";
            this.txtBlower_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(37, 338);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(106, 21);
            this.label8.TabIndex = 18;
            this.label8.Text = "鼓风机电流：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(190, 338);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 21);
            this.label9.TabIndex = 20;
            this.label9.Text = "A";
            // 
            // txtModeMotor_Current
            // 
            this.txtModeMotor_Current.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtModeMotor_Current.Location = new System.Drawing.Point(149, 40);
            this.txtModeMotor_Current.Margin = new System.Windows.Forms.Padding(2);
            this.txtModeMotor_Current.Name = "txtModeMotor_Current";
            this.txtModeMotor_Current.Size = new System.Drawing.Size(43, 29);
            this.txtModeMotor_Current.TabIndex = 22;
            this.txtModeMotor_Current.Text = "24";
            this.txtModeMotor_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(38, 43);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 21);
            this.label10.TabIndex = 21;
            this.label10.Text = "模式电机电流：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(196, 43);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(21, 21);
            this.label11.TabIndex = 23;
            this.label11.Text = "A";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(196, 98);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(21, 21);
            this.label12.TabIndex = 26;
            this.label12.Text = "A";
            // 
            // txtHeatMotor_Current
            // 
            this.txtHeatMotor_Current.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeatMotor_Current.Location = new System.Drawing.Point(149, 95);
            this.txtHeatMotor_Current.Margin = new System.Windows.Forms.Padding(2);
            this.txtHeatMotor_Current.Name = "txtHeatMotor_Current";
            this.txtHeatMotor_Current.Size = new System.Drawing.Size(43, 29);
            this.txtHeatMotor_Current.TabIndex = 25;
            this.txtHeatMotor_Current.Text = "24";
            this.txtHeatMotor_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(38, 98);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(122, 21);
            this.label13.TabIndex = 24;
            this.label13.Text = "冷暖电机电流：";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(196, 153);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(21, 21);
            this.label14.TabIndex = 29;
            this.label14.Text = "A";
            // 
            // txtCycleMotor_Current
            // 
            this.txtCycleMotor_Current.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtCycleMotor_Current.Location = new System.Drawing.Point(149, 151);
            this.txtCycleMotor_Current.Margin = new System.Windows.Forms.Padding(2);
            this.txtCycleMotor_Current.Name = "txtCycleMotor_Current";
            this.txtCycleMotor_Current.Size = new System.Drawing.Size(43, 29);
            this.txtCycleMotor_Current.TabIndex = 28;
            this.txtCycleMotor_Current.Text = "24";
            this.txtCycleMotor_Current.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(38, 153);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 21);
            this.label15.TabIndex = 27;
            this.label15.Text = "循环电机电流：";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(70, 208);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(88, 21);
            this.label16.TabIndex = 30;
            this.label16.Text = "PTC电阻：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(196, 208);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 21);
            this.label17.TabIndex = 32;
            this.label17.Text = "Ω";
            // 
            // PTC_R
            // 
            this.PTC_R.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.PTC_R.Location = new System.Drawing.Point(149, 205);
            this.PTC_R.Margin = new System.Windows.Forms.Padding(2);
            this.PTC_R.Name = "PTC_R";
            this.PTC_R.Size = new System.Drawing.Size(43, 29);
            this.PTC_R.TabIndex = 31;
            this.PTC_R.Text = "24";
            this.PTC_R.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(190, 209);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(26, 21);
            this.label18.TabIndex = 44;
            this.label18.Text = "℃";
            // 
            // txtEnv_Temp
            // 
            this.txtEnv_Temp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtEnv_Temp.Location = new System.Drawing.Point(143, 206);
            this.txtEnv_Temp.Margin = new System.Windows.Forms.Padding(2);
            this.txtEnv_Temp.Name = "txtEnv_Temp";
            this.txtEnv_Temp.Size = new System.Drawing.Size(42, 29);
            this.txtEnv_Temp.TabIndex = 43;
            this.txtEnv_Temp.Text = "24";
            this.txtEnv_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(64, 209);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(90, 21);
            this.label19.TabIndex = 42;
            this.label19.Text = "环境温度：";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(190, 155);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(26, 21);
            this.label20.TabIndex = 41;
            this.label20.Text = "℃";
            // 
            // txtPTC_Temp
            // 
            this.txtPTC_Temp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPTC_Temp.Location = new System.Drawing.Point(143, 152);
            this.txtPTC_Temp.Margin = new System.Windows.Forms.Padding(2);
            this.txtPTC_Temp.Name = "txtPTC_Temp";
            this.txtPTC_Temp.Size = new System.Drawing.Size(43, 29);
            this.txtPTC_Temp.TabIndex = 40;
            this.txtPTC_Temp.Text = "24";
            this.txtPTC_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label21.Location = new System.Drawing.Point(18, 154);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(136, 21);
            this.label21.TabIndex = 39;
            this.label21.Text = "PTC传感器温度：";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label22.Location = new System.Drawing.Point(190, 99);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(26, 21);
            this.label22.TabIndex = 38;
            this.label22.Text = "℃";
            // 
            // txtChiller_Temp
            // 
            this.txtChiller_Temp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtChiller_Temp.Location = new System.Drawing.Point(143, 96);
            this.txtChiller_Temp.Margin = new System.Windows.Forms.Padding(2);
            this.txtChiller_Temp.Name = "txtChiller_Temp";
            this.txtChiller_Temp.Size = new System.Drawing.Size(43, 29);
            this.txtChiller_Temp.TabIndex = 37;
            this.txtChiller_Temp.Text = "24";
            this.txtChiller_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label23.Location = new System.Drawing.Point(48, 99);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(106, 21);
            this.label23.TabIndex = 36;
            this.label23.Text = "蒸发器温度：";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label24.Location = new System.Drawing.Point(190, 44);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(26, 21);
            this.label24.TabIndex = 35;
            this.label24.Text = "℃";
            // 
            // txtIndoorSensor_Temp
            // 
            this.txtIndoorSensor_Temp.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtIndoorSensor_Temp.Location = new System.Drawing.Point(143, 41);
            this.txtIndoorSensor_Temp.Margin = new System.Windows.Forms.Padding(2);
            this.txtIndoorSensor_Temp.Name = "txtIndoorSensor_Temp";
            this.txtIndoorSensor_Temp.Size = new System.Drawing.Size(43, 29);
            this.txtIndoorSensor_Temp.TabIndex = 34;
            this.txtIndoorSensor_Temp.Text = "24";
            this.txtIndoorSensor_Temp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label25.Location = new System.Drawing.Point(16, 44);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(138, 21);
            this.label25.TabIndex = 33;
            this.label25.Text = "室内传感器温度：";
            // 
            // ugcMode
            // 
            this.ugcMode.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ugcMode.BackColor = System.Drawing.Color.Transparent;
            this.ugcMode.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ugcMode.IsBigSemiCircle = true;
            this.ugcMode.Location = new System.Drawing.Point(25, 36);
            this.ugcMode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ugcMode.Name = "ugcMode";
            this.ugcMode.Size = new System.Drawing.Size(200, 130);
            this.ugcMode.TabIndex = 45;
            this.ugcMode.Value = 3.5D;
            this.ugcMode.ValueAlarmMax = 5D;
            this.ugcMode.ValueAlarmMin = 0D;
            this.ugcMode.ValueMax = 5D;
            // 
            // ugcHeat
            // 
            this.ugcHeat.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ugcHeat.BackColor = System.Drawing.Color.Transparent;
            this.ugcHeat.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ugcHeat.IsBigSemiCircle = true;
            this.ugcHeat.Location = new System.Drawing.Point(264, 36);
            this.ugcHeat.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ugcHeat.Name = "ugcHeat";
            this.ugcHeat.Size = new System.Drawing.Size(200, 130);
            this.ugcHeat.TabIndex = 46;
            this.ugcHeat.Value = 3.5D;
            this.ugcHeat.ValueAlarmMax = 5D;
            this.ugcHeat.ValueAlarmMin = 0D;
            this.ugcHeat.ValueMax = 5D;
            // 
            // label26
            // 
            this.label26.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label26.Location = new System.Drawing.Point(52, 169);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(106, 21);
            this.label26.TabIndex = 47;
            this.label26.Text = "模式执行器：";
            // 
            // label27
            // 
            this.label27.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label27.Location = new System.Drawing.Point(300, 169);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(106, 21);
            this.label27.TabIndex = 48;
            this.label27.Text = "冷暖执行器：";
            // 
            // userLantern1
            // 
            this.userLantern1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userLantern1.BackColor = System.Drawing.Color.Transparent;
            this.userLantern1.LanternBackground = System.Drawing.Color.Red;
            this.userLantern1.Location = new System.Drawing.Point(146, 167);
            this.userLantern1.Name = "userLantern1";
            this.userLantern1.Size = new System.Drawing.Size(28, 28);
            this.userLantern1.TabIndex = 50;
            // 
            // userLantern2
            // 
            this.userLantern2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.userLantern2.BackColor = System.Drawing.Color.Transparent;
            this.userLantern2.LanternBackground = System.Drawing.Color.Red;
            this.userLantern2.Location = new System.Drawing.Point(391, 167);
            this.userLantern2.Name = "userLantern2";
            this.userLantern2.Size = new System.Drawing.Size(28, 28);
            this.userLantern2.TabIndex = 52;
            // 
            // LFaceDef_Sponge
            // 
            this.LFaceDef_Sponge.BackColor = System.Drawing.Color.Transparent;
            this.LFaceDef_Sponge.LanternBackground = System.Drawing.Color.Red;
            this.LFaceDef_Sponge.Location = new System.Drawing.Point(149, 262);
            this.LFaceDef_Sponge.Name = "LFaceDef_Sponge";
            this.LFaceDef_Sponge.Size = new System.Drawing.Size(28, 28);
            this.LFaceDef_Sponge.TabIndex = 54;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label30.Location = new System.Drawing.Point(38, 263);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(122, 21);
            this.label30.TabIndex = 53;
            this.label30.Text = "吹面除霜海绵：";
            // 
            // LExpansion_Sponge
            // 
            this.LExpansion_Sponge.BackColor = System.Drawing.Color.Transparent;
            this.LExpansion_Sponge.LanternBackground = System.Drawing.Color.Red;
            this.LExpansion_Sponge.Location = new System.Drawing.Point(149, 315);
            this.LExpansion_Sponge.Name = "LExpansion_Sponge";
            this.LExpansion_Sponge.Size = new System.Drawing.Size(28, 28);
            this.LExpansion_Sponge.TabIndex = 56;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label31.Location = new System.Drawing.Point(53, 318);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(106, 21);
            this.label31.TabIndex = 55;
            this.label31.Text = "膨胀阀橡塑：";
            // 
            // LWind_Sponge
            // 
            this.LWind_Sponge.BackColor = System.Drawing.Color.Transparent;
            this.LWind_Sponge.LanternBackground = System.Drawing.Color.Red;
            this.LWind_Sponge.Location = new System.Drawing.Point(143, 316);
            this.LWind_Sponge.Name = "LWind_Sponge";
            this.LWind_Sponge.Size = new System.Drawing.Size(28, 28);
            this.LWind_Sponge.TabIndex = 60;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label32.Location = new System.Drawing.Point(49, 319);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(106, 21);
            this.label32.TabIndex = 59;
            this.label32.Text = "进风口海绵：";
            // 
            // LTube_Direction
            // 
            this.LTube_Direction.BackColor = System.Drawing.Color.Transparent;
            this.LTube_Direction.LanternBackground = System.Drawing.Color.Red;
            this.LTube_Direction.Location = new System.Drawing.Point(143, 264);
            this.LTube_Direction.Name = "LTube_Direction";
            this.LTube_Direction.Size = new System.Drawing.Size(28, 28);
            this.LTube_Direction.TabIndex = 58;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label33.Location = new System.Drawing.Point(49, 264);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(106, 21);
            this.label33.TabIndex = 57;
            this.label33.Text = "排水管方向：";
            // 
            // dgvParam
            // 
            this.dgvParam.AllowUserToAddRows = false;
            this.dgvParam.AllowUserToDeleteRows = false;
            this.dgvParam.AllowUserToResizeRows = false;
            this.dgvParam.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvParam.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvParam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvParam.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ParamName,
            this.ValueUpper,
            this.ValueLower,
            this.Value,
            this.IsPassed});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvParam.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvParam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvParam.EnableHeadersVisualStyles = false;
            this.dgvParam.Location = new System.Drawing.Point(757, 1);
            this.dgvParam.Margin = new System.Windows.Forms.Padding(1);
            this.dgvParam.Name = "dgvParam";
            this.dgvParam.ReadOnly = true;
            this.dgvParam.RowHeadersVisible = false;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dgvParam.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.tableLayoutPanel1.SetRowSpan(this.dgvParam, 3);
            this.dgvParam.RowTemplate.Height = 27;
            this.dgvParam.Size = new System.Drawing.Size(506, 686);
            this.dgvParam.TabIndex = 61;
            // 
            // ParamName
            // 
            this.ParamName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ParamName.DataPropertyName = "Note";
            this.ParamName.FillWeight = 130F;
            this.ParamName.HeaderText = "参数名";
            this.ParamName.Name = "ParamName";
            this.ParamName.ReadOnly = true;
            // 
            // ValueUpper
            // 
            this.ValueUpper.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueUpper.DataPropertyName = "ValueUpper";
            this.ValueUpper.FillWeight = 80F;
            this.ValueUpper.HeaderText = "上限值";
            this.ValueUpper.Name = "ValueUpper";
            this.ValueUpper.ReadOnly = true;
            // 
            // ValueLower
            // 
            this.ValueLower.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ValueLower.DataPropertyName = "ValueLower";
            this.ValueLower.FillWeight = 80F;
            this.ValueLower.HeaderText = "下限值";
            this.ValueLower.Name = "ValueLower";
            this.ValueLower.ReadOnly = true;
            this.ValueLower.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Value
            // 
            this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Value.DataPropertyName = "Value";
            this.Value.FillWeight = 80F;
            this.Value.HeaderText = "检测值";
            this.Value.Name = "Value";
            this.Value.ReadOnly = true;
            // 
            // IsPassed
            // 
            this.IsPassed.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IsPassed.DataPropertyName = "IsPassed";
            this.IsPassed.FillWeight = 80F;
            this.IsPassed.HeaderText = "结果";
            this.IsPassed.Name = "IsPassed";
            this.IsPassed.ReadOnly = true;
            // 
            // btnStart
            // 
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStart.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStart.Location = new System.Drawing.Point(78, 83);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 32);
            this.btnStart.TabIndex = 62;
            this.btnStart.Text = "开始检测";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtUnPass
            // 
            this.txtUnPass.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtUnPass.Location = new System.Drawing.Point(133, 221);
            this.txtUnPass.Margin = new System.Windows.Forms.Padding(2);
            this.txtUnPass.Name = "txtUnPass";
            this.txtUnPass.Size = new System.Drawing.Size(53, 29);
            this.txtUnPass.TabIndex = 64;
            this.txtUnPass.Text = "0";
            this.txtUnPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(52, 224);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 21);
            this.label3.TabIndex = 63;
            this.label3.Text = "不合格数：";
            // 
            // timerCheckComm
            // 
            this.timerCheckComm.Tick += new System.EventHandler(this.timerCheckComm_Tick);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSave.Location = new System.Drawing.Point(78, 133);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 32);
            this.btnSave.TabIndex = 65;
            this.btnSave.Text = "存储产品";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dgvParam, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 61.11111F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 38.88889F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1264, 688);
            this.tableLayoutPanel1.TabIndex = 66;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtEnv_Temp);
            this.panel1.Controls.Add(this.txtPTC_Temp);
            this.panel1.Controls.Add(this.txtChiller_Temp);
            this.panel1.Controls.Add(this.txtIndoorSensor_Temp);
            this.panel1.Controls.Add(this.LWind_Sponge);
            this.panel1.Controls.Add(this.LTube_Direction);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(506, 48);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 388);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LComm);
            this.panel2.Controls.Add(this.txtUnPass);
            this.panel2.Controls.Add(this.txtPass);
            this.panel2.Controls.Add(this.txtBlower_Gear);
            this.panel2.Controls.Add(this.txtVoltage);
            this.panel2.Controls.Add(this.btnStart);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.txtBlower_Current);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.lblVoltage);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(2, 48);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 388);
            this.panel2.TabIndex = 62;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.LFaceDef_Sponge);
            this.panel3.Controls.Add(this.LExpansion_Sponge);
            this.panel3.Controls.Add(this.txtHeatMotor_Current);
            this.panel3.Controls.Add(this.txtModeMotor_Current);
            this.panel3.Controls.Add(this.txtCycleMotor_Current);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.PTC_R);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label30);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label31);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.panel3.Location = new System.Drawing.Point(255, 49);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(246, 386);
            this.panel3.TabIndex = 63;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 441);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(246, 244);
            this.panel4.TabIndex = 64;
            // 
            // panel5
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panel5, 2);
            this.panel5.Controls.Add(this.userLantern2);
            this.panel5.Controls.Add(this.userLantern1);
            this.panel5.Controls.Add(this.ugcHeat);
            this.panel5.Controls.Add(this.label26);
            this.panel5.Controls.Add(this.ugcMode);
            this.panel5.Controls.Add(this.label27);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(255, 441);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(498, 244);
            this.panel5.TabIndex = 65;
            // 
            // FrmDetectionAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1264, 688);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FrmDetectionAuto";
            this.Text = "FrmDetectionAuto";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDetectionAuto_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvParam)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label2;
        private MyControls.UserLantern LComm;
        private System.Windows.Forms.TextBox txtVoltage;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBlower_Gear;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtBlower_Current;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtModeMotor_Current;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtHeatMotor_Current;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtCycleMotor_Current;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox PTC_R;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtEnv_Temp;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtPTC_Temp;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox txtChiller_Temp;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox txtIndoorSensor_Temp;
        private System.Windows.Forms.Label label25;
        private MyControls.UserGaugeChart ugcMode;
        private MyControls.UserGaugeChart ugcHeat;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label27;
        private MyControls.UserLantern userLantern1;
        private MyControls.UserLantern userLantern2;
        private MyControls.UserLantern LFaceDef_Sponge;
        private System.Windows.Forms.Label label30;
        private MyControls.UserLantern LExpansion_Sponge;
        private System.Windows.Forms.Label label31;
        private MyControls.UserLantern LWind_Sponge;
        private System.Windows.Forms.Label label32;
        private MyControls.UserLantern LTube_Direction;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.DataGridView dgvParam;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtUnPass;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerCheckComm;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParamName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueUpper;
        private System.Windows.Forms.DataGridViewTextBoxColumn ValueLower;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsPassed;
    }
}