using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System;
using System.IO;
using System.ComponentModel;
using System.IO.Ports;
using System.Xml.Serialization;
using TrueTestPatternGenerator;
using TrueTestEngine;
using System.Runtime.CompilerServices;

namespace StandardDI
{
    [Serializable()]
    public class StandardDI : PatternGeneratorBase, IDisposable
    {
        private int NumberOfSequenceExposures = 0;
        private int ExposuresCompleted = 0;
        private bool AckRecieved = false;

        // Enumerator list for the avialble commands
        public enum SerialCommand
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

        // Enumerator list which represents the termination character of a signal
        public enum TerminatorEnum
        {
            None = 0,
            Cr = 1,
            Lf = 2,
            CrLf = 3,
            LfCr = 4
        }

        [XmlIgnore()]
        [NonSerialized()]
        [Browsable(false)]
        private SerialPort _SerialPort;

        [XmlIgnore()]
        [Browsable(false)]
        public SerialPort SerialPort
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            get
            {
                return _SerialPort;
            }

            [MethodImpl(MethodImplOptions.Synchronized)]
            set
            {
                if (_SerialPort != null)
                {
                    _SerialPort.DataReceived -= SerialPort_DataReceived;
                }

                _SerialPort = value;
                if (_SerialPort != null)
                {
                    _SerialPort.DataReceived += SerialPort_DataReceived;
                }
            }
        }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("The serial port name used to communicate with the fixture PLC.")]
        public string PortName { get; set; }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("Parity of communication protocol.")]
        public System.IO.Ports.Parity Parity { get; set; }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("Number of databits in communication protocol.")]
        public int DataBits { get; set; }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("Stop Bits in communication protocol.")]
        public StopBits StopBits { get; set; }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("The Baud Rate of communication protocol.")]
        public int BaudRate { get; set; }

        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("The number of miliseconds to wait before considering communcation dropped.")]
        public int WaitTime { get; set; }

        private string mTerminator = Constants.vbCrLf;
        [Category("Fixture Serial Port Parameters")]
        [Browsable(true)]
        [Description("The terminating character in communication protocol.")]
        public TerminatorEnum Terminator
        {
            get
            {
                switch (mTerminator)
                {
                    case "":
                        {
                            return TerminatorEnum.None;
                        }

                    case Constants.vbCr:
                        {
                            return TerminatorEnum.Cr;
                        }

                    case Constants.vbLf:
                        {
                            return TerminatorEnum.Lf;
                        }

                    case Constants.vbCrLf:
                        {
                            return TerminatorEnum.CrLf;
                        }

                    case Constants.vbLf + Constants.vbCr:
                        {
                            return TerminatorEnum.LfCr;
                        }

                    default:
                        {
                            return TerminatorEnum.CrLf;
                        }
                }
            }
            set
            {
                switch (value)
                {
                    case TerminatorEnum.None:
                        {
                            mTerminator = "";
                            break;
                        }

                    case TerminatorEnum.Cr:
                        {
                            mTerminator = Constants.vbCr;
                            break;
                        }

                    case TerminatorEnum.Lf:
                        {
                            mTerminator = Constants.vbLf;
                            break;
                        }

                    case TerminatorEnum.CrLf:
                        {
                            mTerminator = Constants.vbCrLf;
                            break;
                        }

                    case TerminatorEnum.LfCr:
                        {
                            mTerminator = Constants.vbLf + Constants.vbCr;
                            break;
                        }

                    default:
                        {
                            mTerminator = Constants.vbCrLf;
                            break;
                        }
                }
            }
        }

        internal bool Initialized = false;



        [Category("Log File Parameters")]
        [Browsable(true)]
        [Description("The file path of the log file")]
        public string LogFilePath { get; set; }

        [Category("Log File Parameters")]
        [Browsable(true)]
        [Description("Determines if a communications log will be written>")]
        public bool WriteToCommunicationsLog { get; set; }


        //Set initial defaults
        StandardDI()
        {
            SerialPort = null;
            PortName = "COM1";
            Parity = Parity.None;
            DataBits = 8;
            StopBits = StopBits.One;
            BaudRate = 9600;
            WaitTime = 3000;
            LogFilePath = @"C:\Radiant Vision Systems Data\TrueTest\AppData";
            WriteToCommunicationsLog = true;
        }


        /// <summary>
        /// Overwrites Initialize() in PatternGeneraorBase so the serial port will be initialized along with the PG.
        /// </summary>
        protected override bool Initialize()
        {
            Initialized = false;
            AddEventHandlers();
            return InitializeSerialPort();
        }

        internal void AddEventHandlers()
        {
            TrueTest.ExposureComplete += ExposureComplete;
            TrueTest.SequenceComplete += SequenceComplete;
            TrueTest.SequenceRunAllStarted += PrepareForSequenceRunAll;
        }

        internal void RemoveHandlers()
        {
            TrueTest.ExposureComplete -= ExposureComplete;
            TrueTest.SequenceComplete -= SequenceComplete;
            TrueTest.SequenceRunAllStarted -= PrepareForSequenceRunAll;
        }

        /// <summary>
        /// Initializes the serial port.
        /// </summary>
        /// <returns> Returns true if port was successfully initialized.</returns>
        private bool InitializeSerialPort()
        {
            try
            {
                SerialPort = new SerialPort(PortName, BaudRate, Parity, DataBits, StopBits)
                {
                    ReceivedBytesThreshold = 1,
                    DiscardNull = true,
                    NewLine = mTerminator,
                    WriteTimeout = WaitTime,
                    ReadTimeout = WaitTime
                };
                SerialPort.Open();
                Initialized = true;

                // Initialization for pattern generator
                this.IsInitialized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fixture Serial Port Error");
                SerialPort = null;
            }

            return Initialized;
        }

        protected override bool IsInitializationRequired(TrueTestPatternGenerator.PatternGeneratorBase NewPGObject)
        {
            if (NewPGObject == null)
                return false;
            return true; // reinitialize always
        }

        /// <summary>
        /// Overwrites ShutDown() in PatternGeneraorBase so that the serial port will be closed along with the PG.
        /// </summary>
        /// <returns> true </returns>
        protected override bool ShutDown()
        {
            if (Initialized == false)
                return true;
            Close();
            RemoveHandlers();
            this.IsInitialized = false;
            return true;
        }

        /// <summary>
        /// Closes serial port.
        /// </summary>
        private void Close()
        {
            try
            {
                if (SerialPort != null)
                {
                    if (SerialPort.IsOpen)
                    {
                        SerialPort.Close();
                        Initialized = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Fixture Serial Port Error");
            }
        }


        /// <summary>
        /// Listens for commands from serial port and calls functions depending upon command received.
        /// </summary>
        private void SerialPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            try
            {
                // 20ms Sleep introduced in order to allow the buffer to completely fill.
                System.Threading.Thread.Sleep(20);

                string RecievedString = SerialPort.ReadLine();
                PacketSerial ReceivedPacket = new PacketSerial(RecievedString);

                switch (ReceivedPacket.Request())
                {
                    case SerialCommand.SerialNumber:
                        {
                            string SerialNumber = ReceivedPacket.Data[0];
                            WriteToLog("Received: SN," + SerialNumber);
                            TrueTest.set_SerialNumber(0, SerialNumber);
                            SerialPort.WriteLine("SA," + SerialNumber);
                            return;
                        }

                    case SerialCommand.DeviceReady:
                        {
                            WriteToLog("Received: RD");

                            // Run the sequence
                            TrueTest.SequenceRunAll();

                            return;
                        }

                    case SerialCommand.PatternAcknowledge:
                        {
                            WriteToLog("Received: PA," + ReceivedPacket.Data[0]);
                            AckRecieved = true;
                            break;
                        }

                    case SerialCommand.UnloadAcknowledge:
                        {
                            WriteToLog("Received: UA");
                            break;
                        }

                    case SerialCommand.ResultAcknowledge:
                        {
                            WriteToLog("Received: RA," + ReceivedPacket.Data[0]);
                            break;
                        }

                    default:
                        {
                            WriteToLog("Unrecognized command: " + RecievedString);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "SerialPort Error");
                WriteToLog("Receive Error: " + ex.Message);
            }
        }



        private void ExposureComplete(object sender, ExposureCompleteEventArgs e)
        {
            ExposuresCompleted += 1;
            WriteToLog("Exposure Number " + ExposuresCompleted + " is complete.");
            if (ExposuresCompleted >= NumberOfSequenceExposures)
            {
                // We've taken all of the exposures and we can unload the panel now
                PacketSerial UnloadPacket = new PacketSerial(SerialCommand.Unload);
                UnloadPacket.Send(this);
            }
        }

        public void MeasurementComplete(object sender, MeasurementCompleteEventArgs e)
        {
            WriteToLog("Measurement Complete...");
        }

        public void AnalysisComplete(object sender, AnalysisCompleteEventArgs e)
        {
            WriteToLog("Analysis finished...");
        }

        public void SequenceComplete(object sender, SequenceCompleteEventsArgs e)
        {
            WriteToLog("Sequence Complete...");

            string ResultString = e.PassFail == TrueTest.AnalysisResultEnum.Pass ? "OK" : "NG";

            List<string> DataStringList = new List<string>() { ResultString };

            PacketSerial ResultPacket = new PacketSerial(SerialCommand.Result, DataStringList);
            ResultPacket.Send(this);
        }


        /// <summary>
        /// This is a blocking call that doesn't finish until the requested pattern is confirmed to be displayed.
        /// </summary>
        /// <param name="p"> The pattern to be displayed and confirmed. </param>
        protected override void ShowPattern(TrueTestPattern p)
        {
            if (p == null)
                return;

            // Check that the pattern is the appropriate type for the DI to send.
            if (!p.Pattern.GetType().Equals(typeof(SimplePattern)))
                return;

            AckRecieved = false;
            SimplePattern pattern = (SimplePattern)p.Pattern;
            string PatternNumber = pattern.ImageNumber.ToString();
            List<string> PacketDataList = new List<string>() { PatternNumber };
            PacketSerial PatternPacket = new PacketSerial(SerialCommand.ShowPattern, PacketDataList);
            PatternPacket.Send(this);

            if (!WaitForAck())
            {
                // Fixture timed out changing the pattern
                WriteToLog("Fixture did not send the Pattern Ready (PR) command after TrueTest requested pattern #" + PatternNumber + ".");
                TrueTest.SequenceStop(); // Cancel sequence
            }
        }

        private bool WaitForAck()
        {
            // Wait for ack from board

            // loop in increments of 10ms
            int Timeout = WaitTime / 10;
            int TimeoutCounter = 0;
            do
            {
                System.Threading.Thread.Sleep(10);
                TimeoutCounter += 1;
            }
            while (!(AckRecieved | TimeoutCounter > Timeout));
            if (TimeoutCounter >= Timeout)
                // never got anything back
                WriteToLog("No acknowledgement from board. Please check connection and power.");

            if (AckRecieved)
            {
                AckRecieved = false;
                return true;
            }

            AckRecieved = false;
            return AckRecieved;
        }

        /// <summary>
        /// Writes the string to the com log with a time stamp.
        /// </summary>
        private object LogSyncLock = new object();
        internal void WriteToLog(string Message)
        {
            DateTime dt = DateTime.Now;
            string LogFilename = LogFilePath + @"\" + dt.ToString("yyyyMMdd") + " Comm Log.txt";
            bool FileExists = File.Exists(LogFilename);

            try
            {
                lock (LogSyncLock)
                {
                    StreamWriter sw = new StreamWriter(LogFilename, true);

                    if (FileExists == false)
                        sw.WriteLine("Log created" + Constants.vbTab + dt.ToString("yyyy/MM/dd HH:mm:ss.fff"));

                    if (Message != null)
                    {
                        Message = Message + Constants.vbTab + dt.ToString("yyyy/MM/dd HH:mm:ss.fff");
                        sw.WriteLine(Message);
                    }

                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Log File Error");
            }
        }


        /// <summary>
        /// Checks the sequence for each unique measurement as analyses may reuse measurements already taken for others.
        /// </summary>
        public void PrepareForSequenceRunAll(object sender, EventArgs e)
        {
            // Calculate how many exposures are going to be required to run the sequence
            List<PatternSetup> PatternList = new List<PatternSetup>();
            NumberOfSequenceExposures = 0;
            var sequence = TrueTest.get_Sequence(0);
            foreach (TrueTestEngine.SequenceItem SeqStep in sequence.Items)
            {
                if (!SeqStep.Selected)
                    continue;
                PatternSetup ps = sequence.GetPatternSetupByName(SeqStep.PatternSetupName);
                if (ps == null)
                    continue;

                // Check to see if we already counted this pattern's exposures
                bool RepeatPattern = false;
                foreach (PatternSetup P in PatternList)
                {
                    if (P == ps)
                    {
                        RepeatPattern = true;
                        break;
                    }
                }

                if (!RepeatPattern)
                {
                    PatternList.Add(ps);
                    NumberOfSequenceExposures += 1;
                }
            }
            WriteToLog("This sequence will require " + NumberOfSequenceExposures + " camera exposures.");
            // Reset the number of exposures completed
            ExposuresCompleted = 0;
        }
    }
}
