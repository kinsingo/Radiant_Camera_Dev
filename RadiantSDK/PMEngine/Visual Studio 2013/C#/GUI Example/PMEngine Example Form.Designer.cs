namespace PMEngine_Example
{
    partial class PMEngineExampleForm
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
            this.FixedExposureNumber = new System.Windows.Forms.NumericUpDown();
            this.UseCustomExposureCheckBox = new System.Windows.Forms.CheckBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.DetSizeTextBox = new System.Windows.Forms.TextBox();
            this.Label5 = new System.Windows.Forms.Label();
            this.ValueTextBox = new System.Windows.Forms.TextBox();
            this.GetValueButton = new System.Windows.Forms.Button();
            this.YLocTextBox = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.XLocTextBox = new System.Windows.Forms.TextBox();
            this.TakeMeasurementButton = new System.Windows.Forms.Button();
            this.AdjustExposureButton = new System.Windows.Forms.Button();
            this.MeasSetupComboBox = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.PMEngineCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.FixedExposureNumber)).BeginInit();
            this.SuspendLayout();
            // 
            // FixedExposureNumber
            // 
            this.FixedExposureNumber.Enabled = false;
            this.FixedExposureNumber.Location = new System.Drawing.Point(345, 72);
            this.FixedExposureNumber.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.FixedExposureNumber.Name = "FixedExposureNumber";
            this.FixedExposureNumber.Size = new System.Drawing.Size(107, 20);
            this.FixedExposureNumber.TabIndex = 35;
            this.FixedExposureNumber.ValueChanged += new System.EventHandler(this.FixedExposureNumber_ValueChanged);
            // 
            // UseCustomExposureCheckBox
            // 
            this.UseCustomExposureCheckBox.AutoSize = true;
            this.UseCustomExposureCheckBox.Location = new System.Drawing.Point(209, 73);
            this.UseCustomExposureCheckBox.Name = "UseCustomExposureCheckBox";
            this.UseCustomExposureCheckBox.Size = new System.Drawing.Size(130, 17);
            this.UseCustomExposureCheckBox.TabIndex = 34;
            this.UseCustomExposureCheckBox.Text = "Use Custom Exposure";
            this.UseCustomExposureCheckBox.UseVisualStyleBackColor = true;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(9, 213);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(22, 13);
            this.Label7.TabIndex = 32;
            this.Label7.Text = "Lv:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(458, 149);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(23, 13);
            this.Label6.TabIndex = 30;
            this.Label6.Text = "mm";
            // 
            // DetSizeTextBox
            // 
            this.DetSizeTextBox.Location = new System.Drawing.Point(382, 146);
            this.DetSizeTextBox.Name = "DetSizeTextBox";
            this.DetSizeTextBox.Size = new System.Drawing.Size(70, 20);
            this.DetSizeTextBox.TabIndex = 29;
            this.DetSizeTextBox.Text = "25";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(302, 149);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(74, 13);
            this.Label5.TabIndex = 28;
            this.Label5.Text = "Detector Size:";
            // 
            // ValueTextBox
            // 
            this.ValueTextBox.Location = new System.Drawing.Point(53, 210);
            this.ValueTextBox.Name = "ValueTextBox";
            this.ValueTextBox.ReadOnly = true;
            this.ValueTextBox.Size = new System.Drawing.Size(100, 20);
            this.ValueTextBox.TabIndex = 33;
            // 
            // GetValueButton
            // 
            this.GetValueButton.Enabled = false;
            this.GetValueButton.Location = new System.Drawing.Point(12, 181);
            this.GetValueButton.Name = "GetValueButton";
            this.GetValueButton.Size = new System.Drawing.Size(159, 23);
            this.GetValueButton.TabIndex = 31;
            this.GetValueButton.Text = "Get Value at Position";
            this.GetValueButton.UseVisualStyleBackColor = true;
            this.GetValueButton.Click += new System.EventHandler(this.GetValueButton_Click);
            // 
            // YLocTextBox
            // 
            this.YLocTextBox.Location = new System.Drawing.Point(182, 146);
            this.YLocTextBox.Name = "YLocTextBox";
            this.YLocTextBox.Size = new System.Drawing.Size(70, 20);
            this.YLocTextBox.TabIndex = 27;
            this.YLocTextBox.Text = "0.5";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(9, 130);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(130, 13);
            this.Label4.TabIndex = 23;
            this.Label4.Text = "Position (relative location):";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(141, 149);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(35, 13);
            this.Label3.TabIndex = 26;
            this.Label3.Text = "Y-Loc";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(9, 149);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(35, 13);
            this.Label2.TabIndex = 24;
            this.Label2.Text = "X-Loc";
            // 
            // XLocTextBox
            // 
            this.XLocTextBox.Location = new System.Drawing.Point(53, 146);
            this.XLocTextBox.Name = "XLocTextBox";
            this.XLocTextBox.Size = new System.Drawing.Size(70, 20);
            this.XLocTextBox.TabIndex = 25;
            this.XLocTextBox.Text = "0.5";
            // 
            // TakeMeasurementButton
            // 
            this.TakeMeasurementButton.Enabled = false;
            this.TakeMeasurementButton.Location = new System.Drawing.Point(12, 98);
            this.TakeMeasurementButton.Name = "TakeMeasurementButton";
            this.TakeMeasurementButton.Size = new System.Drawing.Size(162, 23);
            this.TakeMeasurementButton.TabIndex = 22;
            this.TakeMeasurementButton.Text = "Take Measurement";
            this.TakeMeasurementButton.UseVisualStyleBackColor = true;
            this.TakeMeasurementButton.Click += new System.EventHandler(this.TakeMeasurementButton_Click);
            // 
            // AdjustExposureButton
            // 
            this.AdjustExposureButton.Enabled = false;
            this.AdjustExposureButton.Location = new System.Drawing.Point(12, 69);
            this.AdjustExposureButton.Name = "AdjustExposureButton";
            this.AdjustExposureButton.Size = new System.Drawing.Size(163, 23);
            this.AdjustExposureButton.TabIndex = 21;
            this.AdjustExposureButton.Text = "Show Adjust Exposure Form";
            this.AdjustExposureButton.UseVisualStyleBackColor = true;
            this.AdjustExposureButton.Click += new System.EventHandler(this.AdjustExposureButton_Click);
            // 
            // MeasSetupComboBox
            // 
            this.MeasSetupComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MeasSetupComboBox.Enabled = false;
            this.MeasSetupComboBox.FormattingEnabled = true;
            this.MeasSetupComboBox.Location = new System.Drawing.Point(209, 39);
            this.MeasSetupComboBox.Name = "MeasSetupComboBox";
            this.MeasSetupComboBox.Size = new System.Drawing.Size(243, 21);
            this.MeasSetupComboBox.TabIndex = 20;
            this.MeasSetupComboBox.SelectedIndexChanged += new System.EventHandler(this.MeasSetupComboBox_SelectedIndexChanged);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(9, 42);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(110, 13);
            this.Label1.TabIndex = 19;
            this.Label1.Text = "Measurement Setups:";
            // 
            // PMEngineCheckBox
            // 
            this.PMEngineCheckBox.Appearance = System.Windows.Forms.Appearance.Button;
            this.PMEngineCheckBox.AutoSize = true;
            this.PMEngineCheckBox.Location = new System.Drawing.Point(12, 12);
            this.PMEngineCheckBox.Name = "PMEngineCheckBox";
            this.PMEngineCheckBox.Size = new System.Drawing.Size(91, 23);
            this.PMEngineCheckBox.TabIndex = 18;
            this.PMEngineCheckBox.Text = "Start PMEngine";
            this.PMEngineCheckBox.UseVisualStyleBackColor = true;
            this.PMEngineCheckBox.CheckedChanged += new System.EventHandler(this.PMEngineCheckBox_CheckedChanged);
            // 
            // PMEngine_Example_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 251);
            this.Controls.Add(this.FixedExposureNumber);
            this.Controls.Add(this.UseCustomExposureCheckBox);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.DetSizeTextBox);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.ValueTextBox);
            this.Controls.Add(this.GetValueButton);
            this.Controls.Add(this.YLocTextBox);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.XLocTextBox);
            this.Controls.Add(this.TakeMeasurementButton);
            this.Controls.Add(this.AdjustExposureButton);
            this.Controls.Add(this.MeasSetupComboBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.PMEngineCheckBox);
            this.Name = "PMEngine_Example_Form";
            this.Text = "PMEngine Example Form";
            ((System.ComponentModel.ISupportInitialize)(this.FixedExposureNumber)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.NumericUpDown FixedExposureNumber;
        internal System.Windows.Forms.CheckBox UseCustomExposureCheckBox;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.TextBox DetSizeTextBox;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.TextBox ValueTextBox;
        internal System.Windows.Forms.Button GetValueButton;
        internal System.Windows.Forms.TextBox YLocTextBox;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.TextBox XLocTextBox;
        internal System.Windows.Forms.Button TakeMeasurementButton;
        internal System.Windows.Forms.Button AdjustExposureButton;
        internal System.Windows.Forms.ComboBox MeasSetupComboBox;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.CheckBox PMEngineCheckBox;
    }
}