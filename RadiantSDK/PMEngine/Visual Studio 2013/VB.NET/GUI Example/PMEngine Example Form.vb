Public Class PMEngineExampleForm
    Dim mPMObj As PMEngine
    Dim MeasSetup As MeasurementSetup
    Dim Meas As PMMeasurementF

    Private Sub PMEngineCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles PMEngineCheckBox.CheckedChanged
        If PMEngineCheckBox.Checked Then
            'Create a new pmengine obj
            mPMObj = New PMEngine

            'Set the calibration database
            mPMObj.SetCalibrationDatabase("C:\Radiant Vision Systems Data\ProMetric\CalibrationData\PM Calibration Demo Camera.calx")

            'Start the camera
            mPMObj.InitializeCamera()

            'Set the measurement database
            mPMObj.MeasurementDatabaseName = "C:\Radiant Vision Systems Data\ProMetric\UserData\Sample.pmxm"

            'Enable miscellaneous controls
            MeasSetupComboBox.Enabled = True
            AdjustExposureButton.Enabled = True
            TakeMeasurementButton.Enabled = True
            FixedExposureNumber.Enabled = True

            'Get the list of measurement setups and put into the combo box
            Dim MSList(-1) As ListItem
            mPMObj.GetMeasurementSetupList(MSList)
            CommonFunctions.LoadComboBoxNoSelect(MeasSetupComboBox, MSList)
            MeasSetupComboBox.SelectedIndex = 0
        Else
            'Set the PMEngine object to nothing
            mPMObj = Nothing

            'Disable controls on the form to prevent errors
            MeasSetupComboBox.Enabled = False
            AdjustExposureButton.Enabled = False
            TakeMeasurementButton.Enabled = False
            GetValueButton.Enabled = False
        End If
    End Sub

    Private Sub MeasSetupComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles MeasSetupComboBox.SelectedIndexChanged
        'Get the measurementsetup ID from the combo box
        Dim MeasSetupID As Integer = CommonFunctions.GetListItemIDfromComboBox(MeasSetupComboBox)

        'Read the measurementsetup from the database
        MeasSetup = mPMObj.ReadMeasurementSetupfromDatabase(MeasSetupID)

        'Additionally alter the measurementsetup if needed
        MeasSetup.SubFrameRegion = New Rectangle(0, 0, 0, 0) 'maximizes subframe

        'Update the fixed exposure value
        FixedExposureNumber.Value = CDec(MeasSetup.FixedExposureTime(1))
    End Sub


    Private Sub AdjustExposureButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AdjustExposureButton.Click
        'Shows the adjust exposure form (exposure times are saved to exposure property)
        mPMObj.ShowAdjustExposureForm(MeasSetup)
    End Sub

    Private Sub TakeMeasurementButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles TakeMeasurementButton.Click

        If UseCustomExposureCheckBox.Checked Then
            MeasSetup.UseFixedExposureTimes = True
        Else
            MeasSetup.UseFixedExposureTimes = False
        End If

        'Take a measurement
        Meas = mPMObj.TakeMeasurementF(MeasSetup, "Descript", 0, 0, "", "")

        'You can get array of tristimulus values if needed using the below line
        'Dim yImageArray As Single(,) = Meas.GetTristimulusArrayF(MeasurementBase.TristimlusType.TrisY)


        'Enable the get value button
        GetValueButton.Enabled = True
    End Sub

    Private Sub GetValueButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GetValueButton.Click
        'Create a circular detector for the size specified
        Dim ROICircleObj As New ROICircle(DistanceUnitType.Millimeters, CSng(DetSizeTextBox.Text))

        'Set other detector properties, such as location
        Dim LocationX As Single = CSng(XLocTextBox.Text)
        Dim LocationY As Single = CSng(YLocTextBox.Text)
        ROICircleObj.LocationDistanceScale = DistanceScaleType.Relative
        ROICircleObj.Center(Meas) = New PointF(LocationX, LocationY)

        'Create a new CIEColor object
        Dim CIEColorObj As CIEColor
        CIEColorObj = ROICircleObj.GetColor(Meas)

        'Display the luminance value
        ValueTextBox.Text = CStr(CIEColorObj.Lv)

    End Sub

    Private Sub PMEngineExampleForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If mPMObj IsNot Nothing Then mPMObj.Shutdown()
    End Sub

    Private Sub FixedExposureNumber_ValueChanged(sender As Object, e As EventArgs) Handles FixedExposureNumber.ValueChanged
        'Set the chosen value to the second fixed exposure element (ususally Y filter). 
        MeasSetup.FixedExposureTime(1) = FixedExposureNumber.Value

        'Save the changed exposure time to the database
        mPMObj.WriteMeasurementSetuptoDatabase(MeasSetup)
    End Sub
End Class
