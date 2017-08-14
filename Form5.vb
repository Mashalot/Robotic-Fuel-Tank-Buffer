Public Class Form5
    Private Sub Form5_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (Button1.Text = "Buffer Station One Available") Then
            Module1.bufferStationOneAvailableBoolean = True
            Button1.Text = "Buffer Station One Not Available"
        Else
            Module1.bufferStationOneAvailableBoolean = False
            Button1.Text = "Buffer Station One Available"
        End If
    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If (Button2.Text = "Entry Tank Switch On") Then
            Module1.entryTankSwitchBoolean = True
            Button2.Text = "Entry Tank Switch Off"
        Else
            Module1.entryTankSwitchBoolean = False
            Button2.Text = "Entry Tank Switch On"
        End If
    End Sub
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If (Button3.Text = "Robot Suction On") Then
            Module1.robotHasSuctionBoolean = 1
            Button3.Text = "Robot currently has suction"
        Else
            Module1.robotHasSuctionBoolean = 0
            Button3.Text = "Robot Suction On"
        End If
    End Sub
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If (Button4.Text = "Robot Has Tank At Buffer Station One") Then
            Module1.robotInPositionBoolean = True
            Button4.Text = "Robot currently has Tank At Buffer Station One"
        Else
            Module1.robotInPositionBoolean = False
            Button4.Text = "Robot Has Tank At Buffer Station One"
        End If
    End Sub
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If (Button5.Text = "Buffer Station 1 Has Suction") Then
            Module1.bufferStationOneHasSuctionBoolean = True
            Button5.Text = "Buffer Station 1 currently has Suction"
        Else
            Module1.bufferStationOneHasSuctionBoolean = False
            Button5.Text = "Buffer Station 1 Has Suction"
        End If
    End Sub
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If (Button6.Text = "Carriage Home Switch On") Then
            Module1.carriageHomeSwitchBoolean = True
            Button6.Text = "Carriage currently home"
        Else
            Module1.carriageHomeSwitchBoolean = False
            Button6.Text = "Carriage Home Switch On"
        End If
    End Sub
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        If (Button7.Text = "Buffer One Measuring Switch On") Then
            Module1.bufferOneMeasuringSwitchBoolean = True
            Button7.Text = "Buffer One Measuring Switch Currently On"
        Else
            Module1.bufferOneMeasuringSwitchBoolean = False
            Button7.Text = "Buffer One Measuring Switch On"
        End If
    End Sub
    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        If (Button10.Text = "Axis 1 OK") Then
            Module1.axisOneOKBoolean = True
            Button10.Text = "Axis 1 Not OK"
        Else
            Module1.axisOneOKBoolean = False
            Button10.Text = "Axis 1 OK"
        End If
    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        If (Button11.Text = "Axis 2 OK") Then
            Module1.axisTwoOKBoolean = True
            Button11.Text = "Axis 2 Not OK"
        Else
            Module1.axisTwoOKBoolean = False
            Button11.Text = "Axis 2 OK"
        End If
    End Sub
    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        If (Button13.Text = "Process 1") Then
            'Module1.Process1 = True
            Button13.Text = "Process 1 Off"
        Else
            'Module1.Process1 = False
            Button13.Text = "Process 1"
        End If
    End Sub
    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        If (Button14.Text = "Process 2") Then
            'Module1.Process2 = True
            Button14.Text = "Process 2 Off"
        Else
            'Module1.Process2 = False
            Button14.Text = "Process 2"
        End If
    End Sub
    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        If (Button15.Text = "Process 3") Then
            'Module1.Process3 = True
            Button15.Text = "Process 3 Off"
        Else
            'Module1.Process3 = False
            Button15.Text = "Process 3"
        End If
    End Sub
    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        If (Button16.Text = "Process 4") Then
            'Module1.Process4 = True
            Button16.Text = "Process 4 Off"
        Else
            'Module1.Process4 = False
            Button16.Text = "Process 4"
        End If
    End Sub
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If (Button8.Text = "Process 5") Then
            'Module1.Process5 = True
            Button8.Text = "Process 5 Off"
        Else
            'Module1.Process5 = False
            Button8.Text = "Process 5"
        End If
    End Sub
    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        If (Button12.Text = "Axis 3 OK") Then
            Module1.axisThreeOKBoolean = True
            Button12.Text = "Axis 3 Not OK"
        Else
            Module1.axisThreeOKBoolean = False
            Button12.Text = "Axis 3 OK"
        End If
    End Sub

    'reset buffer 1
    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click

        If (Button9.Text = "Reset System") Then
            Form1.TextBox1.Text = ""
            Module1.entryWindowTankWidthDouble = 0
            Module1.tankLength1 = 0
            Module1.tankLength2 = 0
            Module1.bufferStationOneAvailableBoolean = True
            Module1.entryWindowClosedSwitchBoolean = True   'only here for testing
            Module1.tailStockOneOpen = 0
            Module1.robotHasSuctionBoolean = False  'only here for testing
            Module1.robotInPositionBoolean = False  'only here for testing
            Module1.axisTwoOKBoolean = False

            'Module1.bufferStationOneHasSuctionBoolean = False
            'Module1.axisThreeOKBoolean = False
            'Module1.bufferOneMeasuringSwitchBoolean = False
            'Module1.bufferWheelOneDiameter = 18
            'Module1.axisOneOKBoolean = False
            'Me.SerialPort1.WriteLine("!36")     'turn buffer off
            'Me.SerialPort1.WriteLine("b31" & " open entry window to receive tank")
            'Module1.entryWindowAvailableBoolean = True              'true if entry window available
            'Module1.entryWindowBoolean = True                       'true if entry window is open
            ''Me.SerialPort3.WriteLine("b40")                         'close exit window tray
            'Module1.exitWindowAvailableBoolean = True               'true if exit window is available
            'Module1.exitWindowBoolean = True

            Module1.bufferStationOneHasSuctionBoolean = False
            Module1.axisThreeOKBoolean = False
            Module1.bufferOneMeasuringSwitchBoolean = False
            Module1.bufferWheelOneDiameter = 18
            Module1.axisOneOKBoolean = False
            Form1.SerialPort1.WriteLine("!36")     'turn buffer off


            Button9.Text = "System resetting"
        Else
            Button9.Text = "Reset System"
        End If
    End Sub





End Class