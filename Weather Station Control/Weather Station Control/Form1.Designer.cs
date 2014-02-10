namespace Weather_Station_Control
{
    partial class Form1
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
            this.change_state_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.clear_btn = new System.Windows.Forms.Button();
            this.data_display = new System.Windows.Forms.TextBox();
            this.light_CB = new System.Windows.Forms.CheckBox();
            this.pressure_CB = new System.Windows.Forms.CheckBox();
            this.temprature_CB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.temp_tbx = new System.Windows.Forms.TextBox();
            this.light_tbx = new System.Windows.Forms.TextBox();
            this.press_tbx = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.stopSensor_btn = new System.Windows.Forms.Button();
            this.startSensorState_btn = new System.Windows.Forms.Button();
            this.pressureState_tb = new System.Windows.Forms.TextBox();
            this.lightState_tb = new System.Windows.Forms.TextBox();
            this.tempState_tb = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // change_state_btn
            // 
            this.change_state_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change_state_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_state_btn.Location = new System.Drawing.Point(16, 210);
            this.change_state_btn.Name = "change_state_btn";
            this.change_state_btn.Size = new System.Drawing.Size(136, 27);
            this.change_state_btn.TabIndex = 0;
            this.change_state_btn.Text = "Select Sensor";
            this.change_state_btn.UseVisualStyleBackColor = true;
            this.change_state_btn.Click += new System.EventHandler(this.change_state_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label1.Location = new System.Drawing.Point(278, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Control Center V 1.0";
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(684, 98);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(75, 23);
            this.clear_btn.TabIndex = 6;
            this.clear_btn.Text = "Clear Data";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // data_display
            // 
            this.data_display.Location = new System.Drawing.Point(536, 133);
            this.data_display.Multiline = true;
            this.data_display.Name = "data_display";
            this.data_display.ReadOnly = true;
            this.data_display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_display.Size = new System.Drawing.Size(223, 206);
            this.data_display.TabIndex = 9;
            // 
            // light_CB
            // 
            this.light_CB.AutoSize = true;
            this.light_CB.Location = new System.Drawing.Point(16, 177);
            this.light_CB.Name = "light_CB";
            this.light_CB.Size = new System.Drawing.Size(49, 17);
            this.light_CB.TabIndex = 11;
            this.light_CB.Text = "Light";
            this.light_CB.UseVisualStyleBackColor = true;
            // 
            // pressure_CB
            // 
            this.pressure_CB.AutoSize = true;
            this.pressure_CB.Location = new System.Drawing.Point(16, 145);
            this.pressure_CB.Name = "pressure_CB";
            this.pressure_CB.Size = new System.Drawing.Size(67, 17);
            this.pressure_CB.TabIndex = 12;
            this.pressure_CB.Text = "Pressure";
            this.pressure_CB.UseVisualStyleBackColor = true;
            // 
            // temprature_CB
            // 
            this.temprature_CB.AutoSize = true;
            this.temprature_CB.Location = new System.Drawing.Point(16, 113);
            this.temprature_CB.Name = "temprature_CB";
            this.temprature_CB.Size = new System.Drawing.Size(80, 17);
            this.temprature_CB.TabIndex = 13;
            this.temprature_CB.Text = "Temprature";
            this.temprature_CB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(198, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Temp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(198, 207);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Light:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(198, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Pressure:";
            // 
            // temp_tbx
            // 
            this.temp_tbx.Location = new System.Drawing.Point(259, 178);
            this.temp_tbx.Name = "temp_tbx";
            this.temp_tbx.Size = new System.Drawing.Size(119, 20);
            this.temp_tbx.TabIndex = 17;
            // 
            // light_tbx
            // 
            this.light_tbx.Location = new System.Drawing.Point(259, 207);
            this.light_tbx.Name = "light_tbx";
            this.light_tbx.Size = new System.Drawing.Size(119, 20);
            this.light_tbx.TabIndex = 18;
            // 
            // press_tbx
            // 
            this.press_tbx.Location = new System.Drawing.Point(259, 243);
            this.press_tbx.Name = "press_tbx";
            this.press_tbx.Size = new System.Drawing.Size(119, 20);
            this.press_tbx.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Chose sensors for use:";
            // 
            // stopSensor_btn
            // 
            this.stopSensor_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopSensor_btn.Location = new System.Drawing.Point(16, 293);
            this.stopSensor_btn.Name = "stopSensor_btn";
            this.stopSensor_btn.Size = new System.Drawing.Size(136, 23);
            this.stopSensor_btn.TabIndex = 21;
            this.stopSensor_btn.Text = "Stop Sensors";
            this.stopSensor_btn.UseVisualStyleBackColor = true;
            this.stopSensor_btn.Click += new System.EventHandler(this.stopSensor_btn_Click);
            // 
            // startSensorState_btn
            // 
            this.startSensorState_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startSensorState_btn.Location = new System.Drawing.Point(16, 253);
            this.startSensorState_btn.Name = "startSensorState_btn";
            this.startSensorState_btn.Size = new System.Drawing.Size(136, 23);
            this.startSensorState_btn.TabIndex = 22;
            this.startSensorState_btn.Text = "Start Sensors";
            this.startSensorState_btn.UseVisualStyleBackColor = true;
            this.startSensorState_btn.Click += new System.EventHandler(this.startSensorState_btn_Click);
            // 
            // pressureState_tb
            // 
            this.pressureState_tb.Location = new System.Drawing.Point(394, 247);
            this.pressureState_tb.Name = "pressureState_tb";
            this.pressureState_tb.Size = new System.Drawing.Size(100, 20);
            this.pressureState_tb.TabIndex = 23;
            // 
            // lightState_tb
            // 
            this.lightState_tb.Location = new System.Drawing.Point(394, 210);
            this.lightState_tb.Name = "lightState_tb";
            this.lightState_tb.Size = new System.Drawing.Size(100, 20);
            this.lightState_tb.TabIndex = 24;
            // 
            // tempState_tb
            // 
            this.tempState_tb.Location = new System.Drawing.Point(394, 181);
            this.tempState_tb.Name = "tempState_tb";
            this.tempState_tb.Size = new System.Drawing.Size(100, 20);
            this.tempState_tb.TabIndex = 25;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(391, 152);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Current State:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(256, 152);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 13);
            this.label7.TabIndex = 27;
            this.label7.Text = "Current Reading";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 415);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tempState_tb);
            this.Controls.Add(this.lightState_tb);
            this.Controls.Add(this.pressureState_tb);
            this.Controls.Add(this.startSensorState_btn);
            this.Controls.Add(this.stopSensor_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.press_tbx);
            this.Controls.Add(this.light_tbx);
            this.Controls.Add(this.temp_tbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.temprature_CB);
            this.Controls.Add(this.pressure_CB);
            this.Controls.Add(this.light_CB);
            this.Controls.Add(this.data_display);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.change_state_btn);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Realtime Wireles Weather Station ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_state_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.TextBox data_display;
        private System.Windows.Forms.CheckBox light_CB;
        private System.Windows.Forms.CheckBox pressure_CB;
        private System.Windows.Forms.CheckBox temprature_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox temp_tbx;
        private System.Windows.Forms.TextBox light_tbx;
        private System.Windows.Forms.TextBox press_tbx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button stopSensor_btn;
        private System.Windows.Forms.Button startSensorState_btn;
        private System.Windows.Forms.TextBox pressureState_tb;
        private System.Windows.Forms.TextBox lightState_tb;
        private System.Windows.Forms.TextBox tempState_tb;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

