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
            this.send_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.clear_btn = new System.Windows.Forms.Button();
            this.cmd_dev_status = new System.Windows.Forms.CheckBox();
            this.cmd_recv_data = new System.Windows.Forms.CheckBox();
            this.data_display = new System.Windows.Forms.TextBox();
            this.updateData = new System.Windows.Forms.Button();
            this.light_CB = new System.Windows.Forms.CheckBox();
            this.pressure_CB = new System.Windows.Forms.CheckBox();
            this.temprature_CB = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.temp_tbx = new System.Windows.Forms.TextBox();
            this.light_tbx = new System.Windows.Forms.TextBox();
            this.press_tbx = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // change_state_btn
            // 
            this.change_state_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.change_state_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.change_state_btn.Location = new System.Drawing.Point(16, 305);
            this.change_state_btn.Name = "change_state_btn";
            this.change_state_btn.Size = new System.Drawing.Size(136, 27);
            this.change_state_btn.TabIndex = 0;
            this.change_state_btn.Text = "Change State";
            this.change_state_btn.UseVisualStyleBackColor = true;
            this.change_state_btn.Click += new System.EventHandler(this.change_state_btn_Click);
            // 
            // send_btn
            // 
            this.send_btn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.send_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.send_btn.Location = new System.Drawing.Point(24, 180);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(102, 23);
            this.send_btn.TabIndex = 1;
            this.send_btn.Text = "Send Command";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.send_btn_Click);
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(21, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Select Commands to Send";
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
            // cmd_dev_status
            // 
            this.cmd_dev_status.AutoSize = true;
            this.cmd_dev_status.Location = new System.Drawing.Point(24, 133);
            this.cmd_dev_status.Name = "cmd_dev_status";
            this.cmd_dev_status.Size = new System.Drawing.Size(136, 17);
            this.cmd_dev_status.TabIndex = 7;
            this.cmd_dev_status.Text = "Retrieve Device Status";
            this.cmd_dev_status.UseVisualStyleBackColor = true;
            // 
            // cmd_recv_data
            // 
            this.cmd_recv_data.AutoSize = true;
            this.cmd_recv_data.Location = new System.Drawing.Point(24, 157);
            this.cmd_recv_data.Name = "cmd_recv_data";
            this.cmd_recv_data.Size = new System.Drawing.Size(128, 17);
            this.cmd_recv_data.TabIndex = 8;
            this.cmd_recv_data.Text = "Receive Sensor Data";
            this.cmd_recv_data.UseVisualStyleBackColor = true;
            // 
            // data_display
            // 
            this.data_display.Location = new System.Drawing.Point(522, 133);
            this.data_display.Multiline = true;
            this.data_display.Name = "data_display";
            this.data_display.ReadOnly = true;
            this.data_display.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.data_display.Size = new System.Drawing.Size(237, 327);
            this.data_display.TabIndex = 9;
            // 
            // updateData
            // 
            this.updateData.Location = new System.Drawing.Point(603, 98);
            this.updateData.Name = "updateData";
            this.updateData.Size = new System.Drawing.Size(75, 23);
            this.updateData.TabIndex = 10;
            this.updateData.Text = "Update Data";
            this.updateData.UseVisualStyleBackColor = true;
            this.updateData.Click += new System.EventHandler(this.updateData_Click);
            // 
            // light_CB
            // 
            this.light_CB.AutoSize = true;
            this.light_CB.Location = new System.Drawing.Point(24, 282);
            this.light_CB.Name = "light_CB";
            this.light_CB.Size = new System.Drawing.Size(49, 17);
            this.light_CB.TabIndex = 11;
            this.light_CB.Text = "Light";
            this.light_CB.UseVisualStyleBackColor = true;
            // 
            // pressure_CB
            // 
            this.pressure_CB.AutoSize = true;
            this.pressure_CB.Location = new System.Drawing.Point(24, 250);
            this.pressure_CB.Name = "pressure_CB";
            this.pressure_CB.Size = new System.Drawing.Size(67, 17);
            this.pressure_CB.TabIndex = 12;
            this.pressure_CB.Text = "Pressure";
            this.pressure_CB.UseVisualStyleBackColor = true;
            // 
            // temprature_CB
            // 
            this.temprature_CB.AutoSize = true;
            this.temprature_CB.Location = new System.Drawing.Point(24, 218);
            this.temprature_CB.Name = "temprature_CB";
            this.temprature_CB.Size = new System.Drawing.Size(80, 17);
            this.temprature_CB.TabIndex = 13;
            this.temprature_CB.Text = "Temprature";
            this.temprature_CB.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(273, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Current Temp:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(273, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Current Light:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(273, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Current Pressure:";
            // 
            // temp_tbx
            // 
            this.temp_tbx.Location = new System.Drawing.Point(359, 146);
            this.temp_tbx.Name = "temp_tbx";
            this.temp_tbx.Size = new System.Drawing.Size(141, 20);
            this.temp_tbx.TabIndex = 17;
            // 
            // light_tbx
            // 
            this.light_tbx.Location = new System.Drawing.Point(359, 176);
            this.light_tbx.Name = "light_tbx";
            this.light_tbx.Size = new System.Drawing.Size(141, 20);
            this.light_tbx.TabIndex = 18;
            // 
            // press_tbx
            // 
            this.press_tbx.Location = new System.Drawing.Point(359, 208);
            this.press_tbx.Name = "press_tbx";
            this.press_tbx.Size = new System.Drawing.Size(141, 20);
            this.press_tbx.TabIndex = 19;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.press_tbx);
            this.Controls.Add(this.light_tbx);
            this.Controls.Add(this.temp_tbx);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.temprature_CB);
            this.Controls.Add(this.pressure_CB);
            this.Controls.Add(this.light_CB);
            this.Controls.Add(this.updateData);
            this.Controls.Add(this.data_display);
            this.Controls.Add(this.cmd_recv_data);
            this.Controls.Add(this.cmd_dev_status);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.change_state_btn);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Realtime Weather Station";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button change_state_btn;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button clear_btn;
        private System.Windows.Forms.CheckBox cmd_dev_status;
        private System.Windows.Forms.CheckBox cmd_recv_data;
        private System.Windows.Forms.TextBox data_display;
        private System.Windows.Forms.Button updateData;
        private System.Windows.Forms.CheckBox light_CB;
        private System.Windows.Forms.CheckBox pressure_CB;
        private System.Windows.Forms.CheckBox temprature_CB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox temp_tbx;
        private System.Windows.Forms.TextBox light_tbx;
        private System.Windows.Forms.TextBox press_tbx;
    }
}

