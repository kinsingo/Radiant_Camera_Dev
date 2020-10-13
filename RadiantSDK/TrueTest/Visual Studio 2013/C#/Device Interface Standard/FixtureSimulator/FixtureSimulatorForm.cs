using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System;
using System.IO.Ports;
using System.Runtime.CompilerServices;

namespace FixtureSimulator
{
    public partial class FixtureSimulatorForm : Form
    {
        public FixtureSimulatorForm()
        {


            _serialPort = null;
            InitializeComponent();
        }

        private Parity _Parity = System.IO.Ports.Parity.None;
        private StopBits _StopBits = System.IO.Ports.StopBits.One;
        private string outputText = null;
        private string inputText = null;
        private bool PortOpen = false;
        private string[] COMMANDS = new[] { "SN,000000", "SN,111111", "RD", "PA," + "1", "UA", "RA," + "OK" };
        private string[] PortList = new[] { "COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9" };
        private string[] BaudRate = new[] { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200" };
        private string[] DataBits = new[] { "8", "6", "7" };
        private string[] Parity = new[] { "None", "Odd", "Even", "Mark", "Space" };
        private string[] StopBits = new[] { "1", "2" };

        enum SerialCommand
        {
            SerialNumber,
            SerialAcknowledge,
            DeviceReady,
            ShowPattern,
            PatternAcknowledge,
            Unload,
            UnloadAcknowledge,
            Result,
            ResultAcknowledge
        }
        private void FixtureSimulatorForm_Load(object sender, EventArgs e)
        {
            commandsListBox.Items.AddRange(COMMANDS);
            PortListBox.Items.AddRange(PortList);
            BaudRateListBox.Items.AddRange(BaudRate);
            ParityListBox.Items.AddRange(Parity);
            DataBitsListBox.Items.AddRange(DataBits);
            StopBitsListBox.Items.AddRange(StopBits);
            PortListBox.SelectedIndex = 1;
            BaudRateListBox.SelectedIndex = 6;
            ParityListBox.SelectedIndex = 0;
            DataBitsListBox.SelectedIndex = 0;
            StopBitsListBox.SelectedIndex = 0;
            commandsListBox.SelectedIndex = 0;
            closeButton.Enabled = false;
        }

        private void OpenButton_Click(object sender, EventArgs e)
        {
            var _BaudRate = System.Convert.ToInt32(BaudRateListBox.SelectedItem.ToString());
            var Parity_ = ParityListBox.SelectedItem.ToString();
            switch (Parity_)
            {
                case "None":
                    {
                        _Parity = System.IO.Ports.Parity.None;
                        break;
                    }

                case "Odd":
                    {
                        _Parity = System.IO.Ports.Parity.Odd;
                        break;
                    }

                case "Even":
                    {
                        _Parity = System.IO.Ports.Parity.Even;
                        break;
                    }

                case "Mark":
                    {
                        _Parity = System.IO.Ports.Parity.Mark;
                        break;
                    }

                case "Space":
                    {
                        _Parity = System.IO.Ports.Parity.Space;
                        break;
                    }
            }
            var _DataBits = System.Convert.ToInt32(DataBitsListBox.SelectedItem.ToString());
            var StopBits_ = StopBitsListBox.SelectedItem.ToString();
            switch (StopBits_)
            {
                case "1":
                    {
                        _StopBits = System.IO.Ports.StopBits.One;
                        break;
                    }

                case "1.5":
                    {
                        _StopBits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    }

                case "2":
                    {
                        _StopBits = System.IO.Ports.StopBits.Two;
                        break;
                    }
            }
            var _Port = PortListBox.SelectedItem.ToString();
            try
            {
                OpenSerialPort(_Port, _BaudRate, _Parity, _DataBits, _StopBits);
                outputText += "The Port has been Opened" + Constants.vbCrLf;
                UpdateTextboxes();
                PortOpen = true;
                openButton.Enabled = false;
                PortListBox.Enabled = false;
                BaudRateListBox.Enabled = false;
                ParityListBox.Enabled = false;
                DataBitsListBox.Enabled = false;
                StopBitsListBox.Enabled = false;
                closeButton.Enabled = true;
            }
            catch
            {
                outputText += "The Port is occupied" + Constants.vbCrLf;
                UpdateTextboxes();

                SerialPort = null;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseSerialPort();
            PortOpen = false;
            outputText += "The Port has been Closed" + Constants.vbCrLf;
            UpdateTextboxes();
            openButton.Enabled = true;
            PortListBox.Enabled = true;
            BaudRateListBox.Enabled = true;
            ParityListBox.Enabled = true;
            DataBitsListBox.Enabled = true;
            StopBitsListBox.Enabled = true;
            closeButton.Enabled = false;
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string selectedCommand = commandsListBox.SelectedItem.ToString();
            DateTime dt = DateTime.Now;
            if (PortOpen == true)
            {
                SendCommand(selectedCommand);
                outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to application: " + selectedCommand + Constants.vbCrLf;
                UpdateTextboxes();
            }
            else
            {
                outputText += "The Port is not open" + Constants.vbCrLf;
                UpdateTextboxes();
            }
        }

        private void SendCustomButton_Click(object sender, EventArgs e)
        {
            string selectedCommand = commandsListBox.SelectedItem.ToString();
            DateTime dt = DateTime.Now;
            if (PortOpen == true)
            {
                SendCommand(CustomCommandBox.Text);
                outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to application: " + CustomCommandBox.Text + Constants.vbCrLf;
                UpdateTextboxes();
            }
            else
            {
                outputText += "The Port is not open" + Constants.vbCrLf;
                UpdateTextboxes();
            }

            if (InvokeRequired)
                CustomCommandBox.BeginInvoke((MethodInvoker)delegate { outputTextBox.Text = string.Empty; ; });
            else
                CustomCommandBox.Text = string.Empty;
        }

        private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SendCustomButton_Click(SendCustomButton, EventArgs.Empty);
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            inputText = string.Empty;
            outputText = string.Empty;
            UpdateTextboxes();
        }
        public void UpdateTextboxes()
        {
            string inputTextValue = inputText;
            string outputTextValue = outputText;

            if (InvokeRequired)
                inputTextBox.BeginInvoke((MethodInvoker)delegate { inputTextBox.Text = Convert.ToString(inputTextValue); ; });
            else
                inputTextBox.Text = inputText;

            if (InvokeRequired)
                outputTextBox.BeginInvoke((MethodInvoker)delegate { outputTextBox.Text = Convert.ToString(outputTextValue); ; });
            else
                outputTextBox.Text = outputText;
        }

        public void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //try
            //{
                // 20ms Sleep introduced in order to allow the buffer to completely fill.
                System.Threading.Thread.Sleep(50);

                string RecievedString = SerialPort.ReadLine();
                PacketSerial ReceivedPacket = new PacketSerial(RecievedString);
                DateTime dt = DateTime.Now;
                Bitmap bmp = new Bitmap(300, 300);
                Graphics g = Graphics.FromImage(bmp);

                switch (ReceivedPacket.Request())
                {
                    case SerialCommand.SerialAcknowledge:
                        {
                            this.inputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command received: SA," + ReceivedPacket.Data[0] + Constants.vbCrLf;
                            break;
                        }

                    case SerialCommand.ShowPattern:
                        {
                            this.inputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command received: SP," + ReceivedPacket.Data[0] + Constants.vbCrLf;
                            switch (ReceivedPacket.Data[0])
                            {
                                case "1":
                                    {
                                        g.Clear(Color.White);
                                        this.PictureBox1.Image = bmp;
                                        SerialPort.WriteLine("PA,1");
                                        this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: PA,1" + Constants.vbCrLf;
                                        break;
                                    }

                                case "2":
                                    {
                                        g.Clear(Color.Black);
                                        this.PictureBox1.Image = bmp;
                                        SerialPort.WriteLine("PA,2");
                                        this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: PA,2" + Constants.vbCrLf;
                                        break;
                                    }

                                case "3":
                                    {
                                        g.Clear(Color.Red);
                                        this.PictureBox1.Image = bmp;
                                        SerialPort.WriteLine("PA,3");
                                        this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: PA,3" + Constants.vbCrLf;
                                        break;
                                    }

                                case "4":
                                    {
                                        g.Clear(Color.Lime);
                                        this.PictureBox1.Image = bmp;
                                        SerialPort.WriteLine("PA,4");
                                        this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: PA,4" + Constants.vbCrLf;
                                        break;
                                    }

                                case "5":
                                    {
                                        g.Clear(Color.Blue);
                                        this.PictureBox1.Image = bmp;
                                        _serialPort.WriteLine("PA,5");
                                        this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: PA,5" + Constants.vbCrLf;
                                        break;
                                    }

                                default:
                                    {
                                        this.inputText += "     " + ReceivedPacket.Data[0] + " is not a defined pattern!" + Constants.vbCrLf;
                                        break;
                                    }
                            }

                            break;
                        }

                    case SerialCommand.Unload:
                        {
                            this.inputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command received: UL" + Constants.vbCrLf;
                            SerialPort.WriteLine("UA");
                            this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: UA" + Constants.vbCrLf;
                            break;
                        }

                    case SerialCommand.Result:
                        {
                            this.inputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command received: RS," + ReceivedPacket.Data[0] + Constants.vbCrLf;
                            SerialPort.WriteLine("RA," + ReceivedPacket.Data[0]);
                            this.outputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Command sent to applicaiton: RA," + ReceivedPacket.Data[0] + Constants.vbCrLf;
                            break;
                        }

                    default:
                        {
                            this.inputText += dt.ToString("yyyy/MM/dd HH:mm:ss ") + "Unrecognized command: " + RecievedString;
                            break;
                        }
                }

                this.UpdateTextboxes();

                SerialPort.DiscardInBuffer();
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private SerialPort __serialPort;

        private SerialPort _serialPort
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return __serialPort;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (__serialPort != null)
                {
                    __serialPort.DataReceived -= SerialPort_DataReceived;
                }

                __serialPort = value;
                if (__serialPort != null)
                {
                    __serialPort.DataReceived += SerialPort_DataReceived;
                }
            }
        }

        public SerialPort SerialPort
        {
            get
            {
                return _serialPort;
            }
            set
            {
                _serialPort = value;
            }
        }

        public void OpenSerialPort(string Portname, int BaudRate, System.IO.Ports.Parity Parity, int DataBits, System.IO.Ports.StopBits StopBits)
        {
            if (_serialPort == null)
            {
                _serialPort = new SerialPort(Portname, BaudRate, Parity, DataBits, StopBits);
                _serialPort.NewLine = Constants.vbCrLf;
            }

            if (_serialPort.IsOpen)
                return;
            else
            {
                _serialPort.Open();
                _serialPort.ReceivedBytesThreshold = 1;
                _serialPort.DiscardNull = true;
            }
        }

        public void CloseSerialPort()
        {
            if (_serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort = null;
            }
        }

        public void SendCommand(string Command)
        {
            if (_serialPort.IsOpen)
                _serialPort.WriteLine(Command);
        }

        private class PacketSerial
        {
            public SerialCommand Command;
            public List<string> Data;

            /// <summary>
            /// Parses text to known commands
            /// </summary>
            public PacketSerial(string PayloadString)
            {
                if (PayloadString == null)
                    return;
                string[] CommandAndData = PayloadString.Split(System.Convert.ToChar(","));

                // Remove Space if exists after command
                Command = GetCommand(CommandAndData[0].Trim());
                if (CommandAndData.Count() > 1)
                {
                    Data = CommandAndData.ToList();
                    Data.RemoveAt(0);
                }
                else
                    Data = null;
            }

            public PacketSerial(SerialCommand NewCommand, List<string> NewData = null)
            {
                Command = NewCommand;
                Data = NewData;
            }

            private SerialCommand GetCommand(string CommandString)
            {
                switch (CommandString)
                {
                    case "SN":
                        {
                            return SerialCommand.SerialNumber;
                        }

                    case "SA":
                        {
                            return SerialCommand.SerialAcknowledge;
                        }

                    case "RD":
                        {
                            return SerialCommand.DeviceReady;
                        }

                    case "SP":
                        {
                            return SerialCommand.ShowPattern;
                        }

                    case "PA":
                        {
                            return SerialCommand.PatternAcknowledge;
                        }

                    case "UL":
                        {
                            return SerialCommand.Unload;
                        }

                    case "UA":
                        {
                            return SerialCommand.UnloadAcknowledge;
                        }

                    case "RS":
                        {
                            return SerialCommand.Result;
                        }

                    case "RA":
                        {
                            return SerialCommand.ResultAcknowledge;
                        }

                    default:
                        {
                            return default(SerialCommand);
                        }
                }
            }

            private string GetCommandString(SerialCommand Command)
            {
                switch (Command)
                {
                    case SerialCommand.SerialNumber:
                        {
                            return "SN";
                        }

                    case SerialCommand.SerialAcknowledge:
                        {
                            return "SA";
                        }

                    case SerialCommand.DeviceReady:
                        {
                            return "RD";
                        }

                    case SerialCommand.ShowPattern:
                        {
                            return "SP";
                        }

                    case SerialCommand.PatternAcknowledge:
                        {
                            return "PA";
                        }

                    case SerialCommand.Unload:
                        {
                            return "UL";
                        }

                    case SerialCommand.UnloadAcknowledge:
                        {
                            return "UA";
                        }

                    case SerialCommand.Result:
                        {
                            return "RS";
                        }

                    case SerialCommand.ResultAcknowledge:
                        {
                            return "RA";
                        }

                    default:
                        {
                            return null;
                        }
                }
            }

            /// <summary>
            /// Sends Cmd over serial port.
            /// </summary>
            public void Send(FixtureSimulatorForm TheDI)
            {
                string PayloadString = GetCommandString(Command);

                try
                {
                    if (Data != null)
                    {
                        foreach (string s in Data)
                            PayloadString += "," + s;
                    }

                    TheDI.SerialPort.DiscardInBuffer();
                    TheDI.SerialPort.WriteLine(PayloadString);
                }
                catch (Exception ex)
                {
                }
            }

            public SerialCommand Request()
            {
                return Command;
            }
        }

        public event CommandReadyEventHandler CommandReady;

        public delegate void CommandReadyEventHandler(string Command);

        public void OnCommandReady(string Command)
        {
            CommandReady.Invoke(Command);
        }
    }
}
