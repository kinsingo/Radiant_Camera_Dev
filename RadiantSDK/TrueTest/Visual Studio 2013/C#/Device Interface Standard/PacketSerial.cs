using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Linq;
using System.Collections.Generic;
using System.Collections;
using System;
using System.Xml.Linq;
using StandardDI;

namespace StandardDI
{
    internal class PacketSerial
    {
        private StandardDI.SerialCommand Command = new StandardDI.SerialCommand();
        public List<string> Data;

        /// <summary>
    /// Creates a received packet from the passed in string.
    /// </summary>
    /// <param name="PayloadString"> The string to become the payload packet.</param>
        public PacketSerial(string PayloadString)
        {
            if (PayloadString == null)
                return;
            string[] CommandAndData = PayloadString.Split(System.Convert.ToChar(","));

            Command = GetCommand(CommandAndData[0]);
            if (CommandAndData.Count() > 1)
            {
                Data = CommandAndData.ToList();
                Data.RemoveAt(0);
            }
            else
                Data = null;
        }

        /// <summary>
    /// Creates a data packet with the command and optionally some data.
    /// </summary>
    /// <param name="NewCommand">The data packet's serial command.</param>
    /// <param name="NewData">The data packet's optional data, such as the pattern number.</param>
        public PacketSerial(StandardDI.SerialCommand NewCommand, List<string> NewData = null)
        {
            Command = NewCommand;
            Data = NewData;
        }

        private StandardDI.SerialCommand GetCommand(string CommandString)
        {
            switch (CommandString)
            {
                case "SN":
                    {
                        return StandardDI.SerialCommand.SerialNumber;
                    }

                case "SA":
                    {
                        return StandardDI.SerialCommand.SerialAcknowledge;
                    }

                case "RD":
                    {
                        return StandardDI.SerialCommand.DeviceReady;
                    }

                case "SP":
                    {
                        return StandardDI.SerialCommand.ShowPattern;
                    }

                case "PA":
                    {
                        return StandardDI.SerialCommand.PatternAcknowledge;
                    }

                case "UL":
                    {
                        return StandardDI.SerialCommand.Unload;
                    }

                case "UA":
                    {
                        return StandardDI.SerialCommand.UnloadAcknowledge;
                    }

                case "RS":
                    {
                        return StandardDI.SerialCommand.Result;
                    }

                case "RA":
                    {
                        return StandardDI.SerialCommand.ResultAcknowledge;
                    }

                default:
                    {
                        return default(StandardDI.SerialCommand);
                    }
            }
        }

        private string GetCommandString(StandardDI.SerialCommand Command)
        {
            switch (Command)
            {
                case StandardDI.SerialCommand.SerialNumber:
                    {
                        return "SN";
                    }

                case StandardDI.SerialCommand.SerialAcknowledge:
                    {
                        return "SA";
                    }

                case StandardDI.SerialCommand.DeviceReady:
                    {
                        return "RD";
                    }

                case StandardDI.SerialCommand.ShowPattern:
                    {
                        return "SP";
                    }

                case StandardDI.SerialCommand.PatternAcknowledge:
                    {
                        return "PA";
                    }

                case StandardDI.SerialCommand.Unload:
                    {
                        return "UL";
                    }

                case StandardDI.SerialCommand.UnloadAcknowledge:
                    {
                        return "UA";
                    }

                case StandardDI.SerialCommand.Result:
                    {
                        return "RS";
                    }

                case StandardDI.SerialCommand.ResultAcknowledge:
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
    /// Sends all the data packet over the serial port.
    /// </summary>
    /// <param name="TheDI"> The device interface to send the packet.</param>
        public void Send(StandardDI TheDI)
        {
            if (TheDI.Initialized == false)
            {
                string Err = "The serial port is not initialized.";
                MessageBox.Show(Err, "Serial Port Error");
                return;
            }

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
                MessageBox.Show(ex.Message, "Serial Port Error");
                TheDI.WriteToLog("Send Error(" + PayloadString + "): " + ex.Message);
            }
        }

        public StandardDI.SerialCommand Request()
        {
            return Command;
        }
    }
}
