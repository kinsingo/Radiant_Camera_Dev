using System.Windows.Forms;

namespace FixtureSimulator
{
    partial class FixtureSimulatorForm
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
            this.ClearButton = new System.Windows.Forms.Button();
            this.Label11 = new System.Windows.Forms.Label();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.StopBitsListBox = new System.Windows.Forms.ComboBox();
            this.DataBitsListBox = new System.Windows.Forms.ComboBox();
            this.ParityListBox = new System.Windows.Forms.ComboBox();
            this.BaudRateListBox = new System.Windows.Forms.ComboBox();
            this.PortListBox = new System.Windows.Forms.ComboBox();
            this.PictureBox1 = new System.Windows.Forms.PictureBox();
            this.SendCustomButton = new System.Windows.Forms.Button();
            this.CustomCommandBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.inputTextBox = new System.Windows.Forms.TextBox();
            this.commandsListBox = new System.Windows.Forms.ListBox();
            this.outputTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.openButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(21, 80);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(75, 23);
            this.ClearButton.TabIndex = 57;
            this.ClearButton.Text = "Clear Logs";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Label11
            // 
            this.Label11.AutoSize = true;
            this.Label11.Location = new System.Drawing.Point(392, 15);
            this.Label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label11.Name = "Label11";
            this.Label11.Size = new System.Drawing.Size(97, 13);
            this.Label11.TabIndex = 56;
            this.Label11.Text = "Custom Commands";
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.BackColor = System.Drawing.SystemColors.Control;
            this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Label10.Enabled = false;
            this.Label10.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Label10.Location = new System.Drawing.Point(171, 141);
            this.Label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label10.Name = "Label10";
            this.Label10.Padding = new System.Windows.Forms.Padding(14, 3, 14, 3);
            this.Label10.Size = new System.Drawing.Size(56, 21);
            this.Label10.TabIndex = 55;
            this.Label10.Text = "CrLf";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Location = new System.Drawing.Point(114, 145);
            this.Label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(57, 13);
            this.Label9.TabIndex = 54;
            this.Label9.Text = "Terminator";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(11, 356);
            this.Label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(49, 13);
            this.Label8.TabIndex = 53;
            this.Label8.Text = "InputBox";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(11, 188);
            this.Label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(57, 13);
            this.Label7.TabIndex = 52;
            this.Label7.Text = "OutputBox";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Location = new System.Drawing.Point(114, 118);
            this.Label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(46, 13);
            this.Label6.TabIndex = 51;
            this.Label6.Text = "StopBits";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(114, 93);
            this.Label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(47, 13);
            this.Label5.TabIndex = 50;
            this.Label5.Text = "DataBits";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Location = new System.Drawing.Point(114, 68);
            this.Label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(33, 13);
            this.Label4.TabIndex = 49;
            this.Label4.Text = "Parity";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Location = new System.Drawing.Point(114, 42);
            this.Label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(55, 13);
            this.Label3.TabIndex = 48;
            this.Label3.Text = "BaudRate";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(114, 17);
            this.Label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(26, 13);
            this.Label2.TabIndex = 47;
            this.Label2.Text = "Port";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(404, 203);
            this.Label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(78, 13);
            this.Label1.TabIndex = 46;
            this.Label1.Text = "Pattern Display";
            // 
            // StopBitsListBox
            // 
            this.StopBitsListBox.FormattingEnabled = true;
            this.StopBitsListBox.Location = new System.Drawing.Point(171, 115);
            this.StopBitsListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.StopBitsListBox.Name = "StopBitsListBox";
            this.StopBitsListBox.Size = new System.Drawing.Size(56, 21);
            this.StopBitsListBox.TabIndex = 45;
            // 
            // DataBitsListBox
            // 
            this.DataBitsListBox.FormattingEnabled = true;
            this.DataBitsListBox.Location = new System.Drawing.Point(171, 90);
            this.DataBitsListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.DataBitsListBox.Name = "DataBitsListBox";
            this.DataBitsListBox.Size = new System.Drawing.Size(56, 21);
            this.DataBitsListBox.TabIndex = 44;
            // 
            // ParityListBox
            // 
            this.ParityListBox.FormattingEnabled = true;
            this.ParityListBox.Location = new System.Drawing.Point(171, 65);
            this.ParityListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ParityListBox.Name = "ParityListBox";
            this.ParityListBox.Size = new System.Drawing.Size(56, 21);
            this.ParityListBox.TabIndex = 43;
            // 
            // BaudRateListBox
            // 
            this.BaudRateListBox.FormattingEnabled = true;
            this.BaudRateListBox.Location = new System.Drawing.Point(171, 40);
            this.BaudRateListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BaudRateListBox.Name = "BaudRateListBox";
            this.BaudRateListBox.Size = new System.Drawing.Size(56, 21);
            this.BaudRateListBox.TabIndex = 42;
            // 
            // PortListBox
            // 
            this.PortListBox.FormattingEnabled = true;
            this.PortListBox.Location = new System.Drawing.Point(171, 13);
            this.PortListBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PortListBox.Name = "PortListBox";
            this.PortListBox.Size = new System.Drawing.Size(56, 21);
            this.PortListBox.TabIndex = 41;
            // 
            // PictureBox1
            // 
            this.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureBox1.Location = new System.Drawing.Point(407, 219);
            this.PictureBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.PictureBox1.Name = "PictureBox1";
            this.PictureBox1.Size = new System.Drawing.Size(256, 256);
            this.PictureBox1.TabIndex = 40;
            this.PictureBox1.TabStop = false;
            // 
            // SendCustomButton
            // 
            this.SendCustomButton.Location = new System.Drawing.Point(588, 32);
            this.SendCustomButton.Name = "SendCustomButton";
            this.SendCustomButton.Size = new System.Drawing.Size(75, 23);
            this.SendCustomButton.TabIndex = 39;
            this.SendCustomButton.Text = "Send";
            this.SendCustomButton.UseVisualStyleBackColor = true;
            this.SendCustomButton.Click += new System.EventHandler(this.SendCustomButton_Click);
            // 
            // CustomCommandBox
            // 
            this.CustomCommandBox.AcceptsReturn = true;
            this.CustomCommandBox.Location = new System.Drawing.Point(395, 32);
            this.CustomCommandBox.Name = "CustomCommandBox";
            this.CustomCommandBox.ShortcutsEnabled = false;
            this.CustomCommandBox.Size = new System.Drawing.Size(187, 20);
            this.CustomCommandBox.TabIndex = 38;
            this.CustomCommandBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(279, 108);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(96, 23);
            this.sendButton.TabIndex = 37;
            this.sendButton.Text = "Send Selected";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(14, 372);
            this.inputTextBox.Multiline = true;
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.ReadOnly = true;
            this.inputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.inputTextBox.Size = new System.Drawing.Size(361, 116);
            this.inputTextBox.TabIndex = 36;
            // 
            // commandsListBox
            // 
            this.commandsListBox.FormattingEnabled = true;
            this.commandsListBox.Location = new System.Drawing.Point(279, 15);
            this.commandsListBox.Name = "commandsListBox";
            this.commandsListBox.Size = new System.Drawing.Size(97, 82);
            this.commandsListBox.TabIndex = 35;
            // 
            // outputTextBox
            // 
            this.outputTextBox.Location = new System.Drawing.Point(14, 204);
            this.outputTextBox.Multiline = true;
            this.outputTextBox.Name = "outputTextBox";
            this.outputTextBox.ReadOnly = true;
            this.outputTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputTextBox.Size = new System.Drawing.Size(361, 124);
            this.outputTextBox.TabIndex = 34;
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(21, 47);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 33;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // openButton
            // 
            this.openButton.Location = new System.Drawing.Point(21, 15);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 32;
            this.openButton.Text = "Open";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.OpenButton_Click);
            // 
            // FixtureSimulatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 508);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.Label11);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.StopBitsListBox);
            this.Controls.Add(this.DataBitsListBox);
            this.Controls.Add(this.ParityListBox);
            this.Controls.Add(this.BaudRateListBox);
            this.Controls.Add(this.PortListBox);
            this.Controls.Add(this.PictureBox1);
            this.Controls.Add(this.SendCustomButton);
            this.Controls.Add(this.CustomCommandBox);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.inputTextBox);
            this.Controls.Add(this.commandsListBox);
            this.Controls.Add(this.outputTextBox);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.openButton);
            this.Name = "FixtureSimulatorForm";
            this.Text = "Standard DI Fixture Simulator";
            this.Load += new System.EventHandler(this.FixtureSimulatorForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ClearButton;
        internal System.Windows.Forms.Label Label11;
        internal System.Windows.Forms.Label Label10;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox StopBitsListBox;
        internal System.Windows.Forms.ComboBox DataBitsListBox;
        internal System.Windows.Forms.ComboBox ParityListBox;
        internal System.Windows.Forms.ComboBox BaudRateListBox;
        internal System.Windows.Forms.ComboBox PortListBox;
        internal System.Windows.Forms.PictureBox PictureBox1;
        internal System.Windows.Forms.Button SendCustomButton;
        internal System.Windows.Forms.TextBox CustomCommandBox;
        internal System.Windows.Forms.Button sendButton;
        internal System.Windows.Forms.TextBox inputTextBox;
        internal System.Windows.Forms.ListBox commandsListBox;
        internal System.Windows.Forms.TextBox outputTextBox;
        internal System.Windows.Forms.Button closeButton;
        internal System.Windows.Forms.Button openButton;
    }
}

