using System.Drawing;
using System.Windows.Forms;
using RiPMEngine;
using System;
using RadiantCommon;

namespace PMEngine_Example
{
    public partial class PMEngineExampleForm : Form
    {
        public PMEngineExampleForm()
        {
            InitializeComponent();
        }

        private PMEngine mPMObj;
        private MeasurementSetup measSetup;
        private PMMeasurementF meas;

        private void PMEngineCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PMEngineCheckBox.Checked)
            {
                // Create a new pmengine obj
                mPMObj = new PMEngine();

                // Set the calibration database
                mPMObj.SetCalibrationDatabase(@"C:\Radiant Vision Systems Data\ProMetric\CalibrationData\PM Calibration Demo Camera.calx");

                // Start the camera
                mPMObj.InitializeCamera();

                // Set the measurement database
                mPMObj.MeasurementDatabaseName = @"C:\Radiant Vision Systems Data\ProMetric\UserData\Sample.pmxm";

                // Enable miscellaneous controls
                MeasSetupComboBox.Enabled = true;
                AdjustExposureButton.Enabled = true;
                TakeMeasurementButton.Enabled = true;
                FixedExposureNumber.Enabled = true;

                // Get the list of measurement setups and put into the combo box
                ListItem[] MSList = new ListItem[0];
                mPMObj.GetMeasurementSetupList(ref MSList);
                CommonFunctions.LoadComboBoxNoSelect(ref MeasSetupComboBox, MSList);
                MeasSetupComboBox.SelectedIndex = 0;
            }
            else
            {
                // Set the PMEngine object to nothing
                mPMObj = null;

                // Disable controls on the form to prevent errors
                MeasSetupComboBox.Enabled = false;
                AdjustExposureButton.Enabled = false;
                TakeMeasurementButton.Enabled = false;
                GetValueButton.Enabled = false;
            }
        }

        private void AdjustExposureButton_Click(object sender, EventArgs e)
        {
            // Shows the adjust exposure form (exposure times are saved to exposure property)
            mPMObj.ShowAdjustExposureForm(ref measSetup);
        }

        private void TakeMeasurementButton_Click(object sender, EventArgs e)
        {
            if (UseCustomExposureCheckBox.Checked)
                measSetup.UseFixedExposureTimes = true;
            else
                measSetup.UseFixedExposureTimes = false;

            //Take a measurement
            int isBlank = 0;
            float[] averageIntensity = { 0 };
            meas = mPMObj.TakeMeasurementF(measSetup, "Descript", 0, 0, "", "", ref isBlank, ref averageIntensity);

            //You can get array of tristimulus values if needed using the below line
            //float[,] yImageArray = meas.GetTristimulusArrayF(MeasurementBase.TristimlusType.TrisY);

            // Enable the get value button
            GetValueButton.Enabled = true;
        }

        private void MeasSetupComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the measurementsetup ID from the combo box
            int MeasSetupID = CommonFunctions.GetListItemIDfromComboBox(MeasSetupComboBox);

            // Read the measurementsetup from the database
            measSetup = mPMObj.ReadMeasurementSetupfromDatabase(MeasSetupID);

            // Additionally alter the measurementsetup if needed
            measSetup.SubFrameRegion = new Rectangle(0, 0, 0, 0); // maximizes subframe

            // Update the fixed exposure value
            FixedExposureNumber.Value = (decimal)measSetup.FixedExposureTime[1];
        }

        private void FixedExposureNumber_ValueChanged(object sender, EventArgs e)
        {
            //Set the fixed exposure time for the current measurement setup
            measSetup.FixedExposureTime[1] = (float)FixedExposureNumber.Value;

            //Save the changed exposure time to the database
            mPMObj.WriteMeasurementSetuptoDatabase(ref measSetup);
        }

        private void GetValueButton_Click(object sender, EventArgs e)
        {
            // Create a circular detector for the size specified
            ROICircle ROICircleObj = new ROICircle(DistanceUnitType.Millimeters, Convert.ToSingle(DetSizeTextBox.Text));

            // Set other detector properties, such as location
            float LocationX = Convert.ToSingle(XLocTextBox.Text);
            float LocationY = Convert.ToSingle(YLocTextBox.Text);
            ROICircleObj.LocationDistanceScale = DistanceScaleType.Relative;
            ROICircleObj.set_Center(meas, new PointF(LocationX, LocationY));

            // Create a new CIEColor object
            CIEColor CIEColorObj;
            CIEColorObj = ROICircleObj.GetColor(meas);

            // Display the luminance value
            ValueTextBox.Text = Convert.ToString(CIEColorObj.Lv);
        }
    }
}
