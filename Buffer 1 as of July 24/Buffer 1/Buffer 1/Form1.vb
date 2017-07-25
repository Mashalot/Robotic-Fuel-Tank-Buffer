Imports System.IO.Ports

Module Module1
    Public tailStock As Double   'current location of tail stock
    Public counter As Integer
    Public stringVal As String
    Public Process As Integer
    'Computer and buffer 1 communication, serial port 1
    Public axisOneOKBoolean As Boolean   '*11, *10, *11 = on, *10 = off
    Public axisTwoOKBoolean As Boolean   '*21, *20
    Public axisThreeOKBoolean As Boolean   '*31, *30
    Public axisFourOKBoolean As Boolean   '*41, *40
    Public tailStockHomeSwitchBoolean As Boolean   '*51, *50
    Public carriageHomeSwitchBoolean As Boolean   '*61, *60
    Public bufferWheelHomeSwitchBoolean As Boolean   '*71, *70
    Public bufferOneMeasuringSwitchBoolean As Boolean   '*81, *80
    Public vacuumSuctionSwitchBoolean As Boolean   '*91, *90
    Public bufferStationOneDoneBuffingBoolean As Boolean   '*99, *98
    Public bufferStationOneHasSuctionBoolean As Boolean   '*a1, *a0
    Public bufferStationOneAvailableBoolean As Boolean
    Public bufferWheelOneDiameter As Double
    Public bufferStationOneRPM As Integer
    Public tailStockOneOpen As Integer

    'Computer and buffer 2 communication, serial port 2
    Public endAxisOneOKBoolean As Boolean   '#11, #10, #11 = on, #10 = off
    Public endAxisTwoOKBoolean As Boolean   '#21, #20
    Public endAxisThreeOKBoolean As Boolean   '#31, #30
    Public endAxisFourOKBoolean As Boolean   '#41, #40
    Public endTailStockHomeSwitchBoolean As Boolean   '#51, #50
    Public endCarriageHomeSwitchBoolean As Boolean   '#61, #60
    Public endBufferWheelHomeSwitchBoolean As Boolean   '#71, #70
    Public endWheelMeasureSwitchBoolean As Boolean   '#81, #80
    Public endVacuumSuctionSwitchBoolean As Boolean   '#91, #90
    Public bufferStationTwoAvailableBoolean As Boolean
    Public bufferTwoMeasuringSwitchBoolean As Boolean
    Public bufferWheelTwoDiameter As Double
    Public bufferStationTwoRPM As Double

    'Computer and micro communication, serial port 3
    Public entryWindowTankID As String   'storage for tank ID
    Public bufferOneTankID As String   'tank ID at buffer station 1
    Public bufferTwoTankID As String   'tank ID at buffer station 2
    Public exitWindowTankID As String   'tank ID at exit window
    Public tankIDBoolean As Boolean    'true if we have tank ID
    Public entryTankSwitchBoolean As Boolean   'a11, a10, true if entry window tank switch is triggered
    Public entryWindowOpenSwitchBoolean As Boolean   'a21, a20
    Public entryWindowClosedSwitchBoolean As Boolean   'a22, a23
    Public exitWindowOpenSwitchBoolean As Boolean   'a31, a30
    Public exitWindowClosedSwitchBoolean As Boolean   'a32, a33
    Public robotInPositionBoolean As Boolean   'a41, a40
    Public robotHasSuctionBoolean As Boolean   'a61, a60, true if robot has suction
    Public exitTankSwitchBoolean As Boolean   'a81, a80, true if exit window tank switch is triggered


    Public bufferOneTankLengthDouble As Double
    Public bufferOneTankLengthString As String
    Public bufferTwoTankLengthDouble As Double
    Public bufferTwoTankLengthString As String
    Public tankLength1 As Double
    Public tankLength2 As Double
    Public tankLength3 As Double
    Public tankLength As Double = tankLength1 + tankLength2
    Public tankLengthBoolean As Boolean   'true if we have tank length

    Public entryWindowTankWidthDouble As Double
    Public entryWindowTankWidthString As String
    Public bufferOneTankWidthDouble As Double
    Public bufferOneTankWidthString As String
    Public bufferTwoTankWidthDouble As Double
    Public bufferTwoTankWidthString As String
    Public exitWindowTankWidthDouble As Double
    Public exitWindowTankWidthString As String
    Public tankWidthBoolean As Boolean   'true if we have tank width

    Public robotVacuumSwitchBoolean As Boolean   'b21, b20, turn robot suction on if true
    Public entryWindowBoolean As Boolean   'b31, b30, true if entry window is open
    Public exitWindowBoolean As Boolean   'b41, b40, true if exit window is closed
    Public exitWindowAvailableBoolean As Boolean
    Public entryWindowAvailableBoolean As Boolean
    Public robotHomeBoolean As Boolean
    Public measurementsBoolean As Boolean

    Public Sub ConvertDoubleString(ByVal doubleVal As Double)
        ' A conversion from Double to String cannot overflow.       
        stringVal = System.Convert.ToString(doubleVal)
        System.Console.WriteLine("{0} as a String is: {1}",
                              doubleVal, stringVal)
        Try
            doubleVal = System.Convert.ToDouble(stringVal)
            System.Console.WriteLine("{0} as a Double is: {1}",
                                  stringVal, doubleVal)
        Catch exception As System.OverflowException
            System.Console.WriteLine(
            "Overflow in String-to-Double conversion.")
        Catch exception As System.FormatException
            System.Console.WriteLine(
            "The string is not formatted as a Double.")
        Catch exception As System.ArgumentException
            System.Console.WriteLine("The string is null.")
        End Try
    End Sub
End Module

Public Class Form1

    'Form 1 boot up settings
    Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form4.Show()
        startButton.Enabled = False
        addRowButton.Enabled = False
        removeRowButton.Enabled = False
        createFileButton.Enabled = False
        pauseFinishButton.Enabled = True
        menuButton.Enabled = True
        emergencyStopButton.Enabled = True
    End Sub

    Private manageBoolean As New BluePrint
    Private BACKSPACE As Boolean
    Private incoming As Byte
    Private incoming1 As Byte
    Private incoming2 As Byte
    Private incoming3 As Byte
    Private incoming4 As Byte
    Private incoming5 As Byte
    Private incoming6 As Byte
    Private incoming7 As Byte
    Private incoming8 As Byte

    'Timer 1, focus on text box 1
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If String.IsNullOrEmpty(TextBox1.Text) = True Then
            SerialPort3.WriteLine("b51" & " read barcode")
        End If

        If Module1.entryWindowTankWidthDouble > 0 And Module1.tankLength > 0 Then
            Module1.measurementsBoolean = True
        Else
            SerialPort3.WriteLine("b71" & " measure entry tank width")   'measure entry tank width
            SerialPort3.WriteLine("b81" & " measure entry tank length")   'measure entry tank length
            System.Threading.Thread.Sleep(4000)
        End If

        TextBox13.Text = Module1.entryWindowTankWidthDouble

        If Module1.tankLength1 > 0 And Module1.tankLength2 > 0 Then
            Module1.tankLength = Module1.tankLength1 + Module1.tankLength2
            TextBox9.Text = Module1.tankLength
        End If

        'tank in entry window? tank ID? tank measurements?
        If Module1.entryTankSwitchBoolean = False Or String.IsNullOrEmpty(TextBox1.Text) = True Or Module1.measurementsBoolean = False Then
            startButton.BackColor = Color.Gray
            startButton.Enabled = False
        Else
            startButton.BackColor = Color.Green
            startButton.Enabled = True
        End If



        'If Module1.bufferStationOneDoneBuffingBoolean = True And Module1.exitWindowAvailableBoolean = True And Module1.Process6 = True Then
        '    'SerialPort3.WriteLine("send robot to pick up tank at buffer 1 to move it to exit window")
        '    'SerialPort3.WriteLine("b21")   'turn robot suction on
        '    Module1.Process7 = True
        '    Module1.Process6 = False
        'End If
        'If Module1.robotInPositionBoolean = True And Module1.robotHasSuctionBoolean = True And Module1.Process7 = True Then
        '    SerialPort1.WriteLine("!22")   'turn buffer 1 suction off
        '    Module1.Process8 = True
        '    Module1.Process7 = False
        'End If
        'If Module1.exitWindowAvailableBoolean = True And Module1.Process8 = True Then
        '    SerialPort3.WriteLine("tell robot to move tank from buffer1 to exit window")
        '    Module1.bufferStationOneAvailableBoolean = True
        '    Module1.Process9 = True
        '    Module1.Process8 = False
        'End If
        'If Module1.bufferStationOneHasSuctionBoolean = False And Module1.tailStockHomeSwitchBoolean = False And Module1.Process9 = True Then
        '    SerialPort1.WriteLine("$2R0" & Module1.tailStockOneOpen & "E0")   'move tail stock back to home
        '    Module1.Process10 = True
        '    Module1.Process9 = False
        'End If
        'If Module1.axisTwoOKBoolean = True And Module1.tailStockHomeSwitchBoolean = False And Module1.Process10 = True Then   'ensure tail stock is home
        '    Me.SerialPort1.WriteLine("$2R001E0")
        '    If Module1.tailStockHomeSwitchBoolean = True Then
        '        Module1.Process10 = False
        '    End If
        'End If
    End Sub
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'reset everything and stop timer 2
        If Module1.Process = 99 Then
            Timer2.Enabled = False
            Module1.Process = 0
            Module1.bufferStationOneAvailableBoolean = False
            Module1.entryWindowClosedSwitchBoolean = False
            Module1.counter = 0
            Module1.measurementsBoolean = False
            Module1.entryTankSwitchBoolean = False
            Module1.robotHasSuctionBoolean = False
            Module1.robotInPositionBoolean = False
            Module1.bufferStationOneHasSuctionBoolean = False
            Module1.axisTwoOKBoolean = False
            Module1.axisOneOKBoolean = False
            Module1.carriageHomeSwitchBoolean = False
            Module1.axisThreeOKBoolean = False
            Module1.bufferOneMeasuringSwitchBoolean = False
        End If

        'if buffer 1 available and entry window closed, send robot to entry window, robot suction on, move tail stock to 6" outside tank length
        If Module1.Process = 1 And Module1.bufferStationOneAvailableBoolean = True And Module1.entryWindowClosedSwitchBoolean = True Then
            SerialPort3.WriteLine("send robot to pick up tank in entry window")
            SerialPort3.WriteLine("b21 " & "turn robot suction on")   'turn robot suction on
            Module1.bufferOneTankLengthDouble = Module1.tankLength   'entry window tank length becomes buffer one tank length, double
            Module1.ConvertDoubleString(Module1.tankLength)   'convert tank length to a string
            Module1.bufferOneTankLengthString = Module1.stringVal   'save tank length string into buffer one tank length string
            TextBox10.Text = Module1.bufferOneTankLengthString   'put this string into text box 10
            Module1.bufferOneTankID = Module1.entryWindowTankID   'entry window tank ID becomes buffer one tank ID
            TextBox2.Text = Module1.bufferOneTankID   'enter this tank ID into text box 2
            Module1.bufferOneTankWidthDouble = Module1.entryWindowTankWidthDouble
            TextBox14.Text = Module1.bufferOneTankWidthDouble
            Module1.tailStockOneOpen = 102.5 - Module1.bufferOneTankLengthDouble - 6
            SerialPort1.WriteLine("$2F0" & Module1.tailStockOneOpen & "E0" & " move tail stock to tank length plus 6")   'move tail stock to tank length plus 6"
            Module1.Process = 2
            Module1.bufferStationOneAvailableBoolean = False
            Module1.entryTankSwitchBoolean = False
        End If

        'is robot in position at entry window?
        If Module1.Process = 2 And Module1.robotInPositionBoolean = True Then
            SerialPort3.WriteLine("robot in position")
            Module1.Process = 3
        End If

        'does robot have suction at entry window? 10 seconds to say yes
        While Module1.Process = 3 And Module1.robotHasSuctionBoolean = False
            System.Threading.Thread.Sleep(1000)
            counter += 1
            SerialPort3.WriteLine(counter)
            If counter = 10 Then
                Module1.Process = 99
                MsgBox("error, robot does not have suction")
                Exit While
            ElseIf counter < 10 And Module1.robotHasSuctionBoolean = True Then
                SerialPort3.WriteLine("robot has suction at entry window")
                SerialPort1.WriteLine("!21 " & "turn buffer 1 suction on")   'turn buffer 1 suction on
                Module1.Process = 4
                Exit While
            End If
        End While

        'if buffer 1 tail stock in position, move tank to buffer 1
        If Module1.Process = 4 And Module1.axisTwoOKBoolean = True Then
            SerialPort3.WriteLine("tail stock in position")
            SerialPort3.WriteLine("tell robot to move tank from entry window to buffer 1")
            Module1.Process = 5
        End If

        'if robot in position at buffer 1, move tail stock in 6 inches
        If Module1.Process = 5 And Module1.robotInPositionBoolean = True Then
            SerialPort1.WriteLine("$2F006E0" & " move tail stock in 6 inches")   'move tail stock in 6"
            Module1.Process = 6
        End If

        'if tail stock is in position and buffer 1 has suction, robot release tank
        If Module1.Process = 6 And Module1.axisTwoOKBoolean = True And Module1.bufferStationOneHasSuctionBoolean = True Then
            SerialPort3.WriteLine("b20" & " release robot suction")
            Module1.Process = 7
        End If

        'if robot no longer has suction, send robot to perch
        If Module1.Process = 7 And Module1.robotHasSuctionBoolean = False Then
            SerialPort3.WriteLine("b61" & " send robot home")
            Module1.Process = 8
        End If

        'turn piston on / piston advance, move buffer wheel up to where an 18" wheel should press measuring switch, 16.5" - 9" = 7.5"
        If Module1.Process = 8 Then
            Me.SerialPort1.WriteLine("!23")
            System.Threading.Thread.Sleep(1000)
            Me.SerialPort1.WriteLine("$3F007E4")
            Module1.Process = 9
        End If

        'Get buffer 1 wheel measurement and calculate RPM
        If Module1.Process = 9 And Module1.axisThreeOKBoolean = True And Module1.bufferOneMeasuringSwitchBoolean = False Then
            Me.SerialPort1.WriteLine("$3F000E4")
            Module1.bufferWheelOneDiameter -= 0.5
            System.Threading.Thread.Sleep(1000)
        ElseIf Module1.Process = 9 And Module1.axisThreeOKBoolean = True And Module1.bufferOneMeasuringSwitchBoolean = True Then
            If Module1.bufferWheelOneDiameter = 18 Then
                Me.SerialPort1.WriteLine("!11")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 17 Then
                Me.SerialPort1.WriteLine("!12")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 16 Then
                Me.SerialPort1.WriteLine("!13")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 15 Then
                Me.SerialPort1.WriteLine("!14")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 14 Then
                Me.SerialPort1.WriteLine("!15")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 13 Then
                Me.SerialPort1.WriteLine("!16")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 12 Then
                Me.SerialPort1.WriteLine("!17")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter = 11 Then
                Me.SerialPort1.WriteLine("!18")
                Module1.Process = 10
            ElseIf Module1.bufferWheelOneDiameter <= 10 Then
                Me.SerialPort1.WriteLine("!10")
                Timer2.Enabled = False
                Dim result As Integer
                result = MessageBox.Show("Error, buffing wheel needs to be changed. Continue anyway?", "Error", MessageBoxButtons.AbortRetryIgnore)
                If result = DialogResult.Abort Then
                    Me.SerialPort1.WriteLine("!10")
                    Module1.Process = 99
                End If
                If result = DialogResult.Retry Then
                    Module1.bufferWheelOneDiameter = 18
                    Module1.bufferOneMeasuringSwitchBoolean = False
                    Module1.Process = 9
                    Timer2.Enabled = True
                End If
                If result = DialogResult.Ignore Then
                    Me.SerialPort1.WriteLine("!18")
                    Module1.Process = 10
                    Timer2.Enabled = True
                End If
            End If
        End If

        'retract piston in preparation for buffing
        If Module1.Process = 10 Then
            Me.SerialPort1.WriteLine("!24")
            Module1.Process = 11
        End If

        'move carriage to buffing start position, 7" away from home
        If Module1.Process = 11 Then
            Me.SerialPort1.WriteLine("$1F007E0")
            Module1.Process = 12
        End If

        'turn buffer on and turn piston on, once carriage is in position
        If Module1.Process = 12 And Module1.axisOneOKBoolean = True Then
            Me.SerialPort1.WriteLine("!35")     'turn buffer on
            Me.SerialPort1.WriteLine("!23")     'turn piston on
            Module1.Process = 13
        End If

        'send buffer tank length plus 4"
        'retract piston
        'rotate tank 1 increment
        'send buffer back, tank length plus 4"
        'advance piston
        'repeat 40 times
    End Sub
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick

    End Sub

    'Start Button
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        addRowButton.Enabled = True
        removeRowButton.Enabled = True
        createFileButton.Enabled = True
        pauseFinishButton.Enabled = True
        Module1.bufferWheelOneDiameter = 18
        Module1.entryWindowTankID = TextBox1.Text

        Dim result As Integer
        If (Module1.entryWindowTankWidthDouble < 19.5 Or Module1.entryWindowTankWidthDouble > 26.5) Or (Module1.entryWindowTankWidthDouble > 20.5 And Module1.entryWindowTankWidthDouble < 22.5) Or (Module1.entryWindowTankWidthDouble > 23.5 And Module1.entryWindowTankWidthDouble < 25.5) Then
            result = MessageBox.Show("Error, tank width outside standard. Continue anyway?", "Error", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                TextBox1.Text = ""
                TextBox9.Text = ""
                TextBox13.Text = ""
                Exit Sub
            ElseIf result = DialogResult.Yes Then
            End If
        End If
        Me.SerialPort3.WriteLine("b30" & " close entry window") 'close entry window
        System.Threading.Thread.Sleep(2000)
        If Module1.entryWindowClosedSwitchBoolean = True Then
            Timer2.Enabled = True
            Module1.Process = 1
        Else
            MsgBox("Error, entry window not closed")
            Exit Sub
        End If

        TextBox5.Text = TimeString
        TextBox17.Text = DateString
        DataGridView1.Rows.Add("count", TextBox1.Text, "sequence #", TextBox9.Text, TextBox13.Text, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox13.Text, TextBox13.Text, TextBox8.Text, TextBox17.Text, TextBox13.Text)
        'reset input textboxes
        'TextBox1.Text = ""
    End Sub
    'Pause/Finish Button
    Private Sub pauseFinishButton_Click(sender As Object, e As EventArgs) Handles pauseFinishButton.Click
        If (pauseFinishButton.Text = "Pause") Then
            Me.SerialPort1.WriteLine("tell system to pause")
            'Me.SerialPort2.WriteLine("tell system to pause")
            'Me.SerialPort3.WriteLine("tell system to pause")
            pauseFinishButton.Text = "Finish"
        Else
            Me.SerialPort1.WriteLine("tell system to resume")
            'Me.SerialPort2.WriteLine("tell system to resume")
            'Me.SerialPort3.WriteLine("tell system to resume")
            pauseFinishButton.Text = "Pause"
        End If
    End Sub
    'Reset button
    Private Sub resetButton_Click(sender As Object, e As EventArgs) Handles resetButton.Click
        If (resetButton.Text = "Reset") Then
            'Me.SerialPort1.WriteLine("reset port 1")
            'Me.SerialPort2.WriteLine("reset port 2")
            'Me.SerialPort3.WriteLine("reset port 3")
            resetButton.Text = "Resetting"
        Else
            'Me.SerialPort1.WriteLine("<P005OF>")
            resetButton.Text = "Reset"
        End If
    End Sub
    'Emergency Stop button
    Private Sub emergencyStopButton_Click(sender As Object, e As EventArgs) Handles emergencyStopButton.Click
        If (emergencyStopButton.Text = "Emergency Stop") Then
            Me.SerialPort1.WriteLine("!26")   'disable axis 1
            Me.SerialPort1.WriteLine("!28")   'disable axis 2
            Me.SerialPort1.WriteLine("!30")   'disable axis 3
            Me.SerialPort1.WriteLine("!32")   'disable axis 4
            Me.SerialPort2.WriteLine("!26")   'disable axis 1
            Me.SerialPort2.WriteLine("!28")   'disable axis 2
            Me.SerialPort2.WriteLine("!30")   'disable axis 3
            Me.SerialPort2.WriteLine("!32")   'disable axis 4
            Me.SerialPort3.WriteLine("b00")   'emergency stop to micro, stop robot
            emergencyStopButton.Text = "Stopped"
        Else
            emergencyStopButton.Text = "Emergency Stop"
        End If
    End Sub
    'Menu button
    Private Sub menuButton_Click(sender As Object, e As EventArgs) Handles menuButton.Click
        Me.Timer1.Enabled = False
        Me.SerialPort1.Close()
        'Me.SerialPort2.Close()
        'Me.SerialPort3.Close()
        Form3.SerialPort1.Open()
        'Form3.SerialPort2.Open()
        'Form3.SerialPort3.Open()
        Form3.Timer1.Enabled = True
        Form3.Show()
    End Sub

    'Data Grid View
    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        'datagridId.items.count
        'Dim dr As DataRow
        'dr("id") = txt_id.Text
        'Dim datagridId As Object = Nothing
        'datagridId.items.count
    End Sub
    'Input Tank ID text box
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    'Input Tank ID text box
    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If BACKSPACE = False Then
            Dim allowedChars As String = "0123456789."
            If allowedChars.IndexOf(e.KeyChar) = -1 Then
                e.Handled = True
            End If
        End If
    End Sub
    'Input length text box
    Private Sub TextBox9_TextChanged(sender As Object, e As EventArgs) Handles TextBox9.TextChanged

    End Sub
    'Input width text box
    Private Sub TextBox13_TextChanged(sender As Object, e As EventArgs) Handles TextBox13.TextChanged

    End Sub

    'Serial Ports:
    Public Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        incoming = SerialPort1.ReadByte
        incoming1 = SerialPort1.ReadByte
        incoming2 = SerialPort1.ReadByte
        'Serial Port 1, computer and buffer 1
        If incoming = 42 And incoming1 = 49 And incoming2 = 49 Then     '*11, axis 1 OK
            Module1.axisOneOKBoolean = True
            'SerialPort1.WriteLine("axis 1 ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 49 And incoming2 = 48 Then '*10, axis 1 not OK
            Module1.axisOneOKBoolean = False
            'SerialPort1.WriteLine("axis 1 not ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 50 And incoming2 = 49 Then '*21, axis 2 OK
            Module1.axisTwoOKBoolean = True
            'SerialPort1.WriteLine("axis 2 ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 50 And incoming2 = 48 Then '*20, axis 2 not OK
            Module1.axisTwoOKBoolean = False
            'SerialPort1.WriteLine("axis 2 not ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 51 And incoming2 = 49 Then '*31, axis 3 OK
            Module1.axisThreeOKBoolean = True
            'SerialPort1.WriteLine("axis 3 ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 51 And incoming2 = 48 Then '*30, axis 3 not OK
            Module1.axisThreeOKBoolean = False
            'SerialPort1.WriteLine("axis 3 not ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 52 And incoming2 = 49 Then '*41, axis 4 OK
            Module1.axisFourOKBoolean = True
            'SerialPort1.WriteLine("axis 4 ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 52 And incoming2 = 48 Then '*40, axis 4 not OK
            Module1.axisFourOKBoolean = False
            'SerialPort1.WriteLine("axis 4 not ok")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 53 And incoming2 = 49 Then 'if *51, tail stock home switch is on
            Module1.tailStockHomeSwitchBoolean = True
            'SerialPort1.WriteLine("tail stock home switch is on")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 53 And incoming2 = 48 Then 'if *50, tail stock home switch is off
            Module1.tailStockHomeSwitchBoolean = False
            'SerialPort1.WriteLine("tail stock home switch is off")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 54 And incoming2 = 49 Then 'if *61, carriage home switch is on
            Module1.carriageHomeSwitchBoolean = True
            'SerialPort1.WriteLine("carriage home switch is on")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 54 And incoming2 = 48 Then 'if *60, carriage home switch is off
            Module1.carriageHomeSwitchBoolean = False
            'SerialPort1.WriteLine("carriage home switch is off")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 55 And incoming2 = 49 Then 'if *71, buffer wheel home switch is on
            Module1.bufferWheelHomeSwitchBoolean = True
            'SerialPort1.WriteLine("buffer wheel home switch is on")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 55 And incoming2 = 48 Then 'if *70, buffer wheel home switch is off
            Module1.bufferWheelHomeSwitchBoolean = False
            'SerialPort1.WriteLine("buffer wheel home switch is off")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 56 And incoming2 = 49 Then 'if *81, wheel measure switch is on
            Module1.bufferOneMeasuringSwitchBoolean = True
            'SerialPort1.WriteLine("wheel measure switch is on")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 56 And incoming2 = 48 Then 'if *80, wheel measure switch is off
            Module1.bufferOneMeasuringSwitchBoolean = False
            'SerialPort1.WriteLine("wheel measure switch is off")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 49 Then '*91, vacuum suction switch is on
            Module1.vacuumSuctionSwitchBoolean = True
            'SerialPort1.WriteLine("vacuum suction switch is on")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 48 Then '*90, vacuum suction switch is off
            Module1.vacuumSuctionSwitchBoolean = False
            'SerialPort1.WriteLine("vacuum suction switch is off")
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 57 Then '*99, buffer 1 done buffing
            Module1.bufferStationOneDoneBuffingBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 56 Then '*98, buffer 1 done buffing
            Module1.bufferStationOneDoneBuffingBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 97 And incoming2 = 49 Then    '*a1, buffer 1 has suction
            Module1.bufferStationOneHasSuctionBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 97 And incoming2 = 48 Then    '*a0, buffer 1 does not have suction
            Module1.bufferStationOneHasSuctionBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        'If incoming = 42 And incoming1 = 48 And incoming2 = 48 Then '*00, commands
        '    SerialPort1.WriteLine("tail stock *51, carriage *61, buffer wheel *71, wheel measure *81, buffer1 vacuum suction *91")
        '    incoming = 0
        '    incoming1 = 0
        '    incoming2 = 0
        'End If
    End Sub
    Public Sub SerialPort2_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort2.DataReceived
        incoming3 = SerialPort2.ReadByte
        incoming4 = SerialPort2.ReadByte
        incoming5 = SerialPort2.ReadByte
        'Serial Port 2, computer and buffer 2
        If incoming3 = 35 And incoming4 = 49 And incoming5 = 49 Then '#11, end axis 1 OK
            Module1.endAxisOneOKBoolean = True
            'SerialPort1.WriteLine("end axis 1 OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 49 And incoming5 = 48 Then '#10, end axis 1 not OK
            Module1.endAxisOneOKBoolean = False
            'SerialPort1.WriteLine("end axis 1 not OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 50 And incoming5 = 49 Then '#21, end axis 2 OK
            Module1.endAxisTwoOKBoolean = True
            'SerialPort1.WriteLine("end axis 2 OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 50 And incoming5 = 48 Then '#20, end axis 2 not OK
            Module1.endAxisTwoOKBoolean = False
            'SerialPort1.WriteLine("end axis 2 not OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 51 And incoming5 = 49 Then '#31, end axis 3 OK
            Module1.endAxisThreeOKBoolean = True
            'SerialPort1.WriteLine("end axis 3 OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 51 And incoming5 = 48 Then '#30, end axis 3 not OK
            Module1.endAxisThreeOKBoolean = False
            'SerialPort1.WriteLine("end axis 3 not OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 52 And incoming5 = 49 Then '#41, end axis 4 OK
            Module1.endAxisFourOKBoolean = True
            'SerialPort1.WriteLine("end axis 4 OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 52 And incoming5 = 48 Then '#40, end axis 4 not OK
            Module1.endAxisFourOKBoolean = False
            'SerialPort1.WriteLine("end axis 4 not OK")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 53 And incoming5 = 49 Then 'if #51, end tail stock home switch is on
            Module1.endTailStockHomeSwitchBoolean = True
            'SerialPort1.WriteLine("end tail stock home switch is on")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 53 And incoming5 = 48 Then 'if #50, end tail stock home switch is off
            Module1.endTailStockHomeSwitchBoolean = False
            'SerialPort1.WriteLine("end tail stock home switch is off")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 54 And incoming5 = 49 Then 'if #61, end carriage home switch is on
            Module1.endCarriageHomeSwitchBoolean = True
            'SerialPort1.WriteLine("end carriage home switch is on")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 54 And incoming5 = 48 Then 'if #60, end carriage home switch is off
            Module1.endCarriageHomeSwitchBoolean = False
            'SerialPort1.WriteLine("end carriage home switch is off")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 55 And incoming5 = 49 Then 'if #71, end buffer wheel home switch is on
            Module1.endBufferWheelHomeSwitchBoolean = True
            'SerialPort1.WriteLine("end buffer wheel home switch is on")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 55 And incoming5 = 48 Then 'if #70, end buffer wheel home switch is off
            Module1.endBufferWheelHomeSwitchBoolean = False
            'SerialPort1.WriteLine("end buffer wheel home switch is off")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 56 And incoming5 = 49 Then 'if #81, end wheel measure switch is on
            Module1.endWheelMeasureSwitchBoolean = True
            'SerialPort1.WriteLine("end wheel measure switch is on")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 56 And incoming5 = 48 Then 'if #80, end wheel measure switch is off
            Module1.endWheelMeasureSwitchBoolean = False
            'SerialPort1.WriteLine("end wheel measure switch is off")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 57 And incoming5 = 49 Then '#91, end vacuum suction switch is on
            Module1.endVacuumSuctionSwitchBoolean = True
            'SerialPort1.WriteLine("end vacuum suction switch is on")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
        If incoming3 = 35 And incoming4 = 57 And incoming5 = 48 Then '#90, end vacuum suction switch is off
            Module1.endVacuumSuctionSwitchBoolean = False
            'SerialPort1.WriteLine("end vacuum suction switch is off")
            incoming3 = 0
            incoming4 = 0
            incoming5 = 0
        End If
    End Sub
    Public Sub SerialPort3_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort3.DataReceived
        incoming6 = SerialPort3.ReadByte
        incoming7 = SerialPort3.ReadByte
        incoming8 = SerialPort3.ReadByte
        'Serial Port 3, Computer and microcontroller
        If incoming6 = 97 And incoming7 = 49 And incoming8 = 49 Then 'a11, entry window tank switch triggered
            Module1.entryTankSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 49 And incoming8 = 48 Then 'a10, entry window tank switch not triggered
            Module1.entryTankSwitchBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 50 And incoming8 = 49 Then 'a21, entry window open switch true
            Module1.entryWindowOpenSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 50 And incoming8 = 48 Then 'a20, entry window open switch false
            Module1.entryWindowOpenSwitchBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 50 And incoming8 = 50 Then 'a22, entry window closed switch true
            Module1.entryWindowClosedSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 50 And incoming8 = 51 Then 'a23, entry window closed switch false
            Module1.entryWindowClosedSwitchBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 49 Then 'a31, exit window closed switch true
            Module1.exitWindowClosedSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 48 Then 'a30, exit window closed switch false
            Module1.exitWindowClosedSwitchBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 50 Then 'a32, exit window open switch true
            Module1.exitWindowOpenSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 51 Then 'a33, exit window open switch false
            Module1.exitWindowOpenSwitchBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 52 And incoming8 = 49 Then 'a41, robot in position
            Module1.robotInPositionBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 52 And incoming8 = 48 Then 'a40, robot not in position
            Module1.robotInPositionBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 53 And incoming8 = 49 Then 'a51, tank width? yes, we have tank width
            Module1.tankWidthBoolean = True
            'SerialPort1.WriteLine("we have tank width")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 53 And incoming8 = 48 Then 'a50, tank width? no tank width
            Module1.tankWidthBoolean = False
            'SerialPort1.WriteLine("no tank width")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 54 And incoming8 = 49 Then 'a61, does robot have suction? yes robot suction
            Module1.robotHasSuctionBoolean = True
            'SerialPort1.WriteLine("yes robot suction")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 54 And incoming8 = 48 Then 'a60, does robot have suction? no robot suction
            Module1.robotHasSuctionBoolean = False
            'SerialPort1.WriteLine("no robot suction")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 56 And incoming8 = 49 Then 'a81, exit window tank switch OK
            Module1.exitTankSwitchBoolean = True
            'SerialPort1.WriteLine("exit window tank switch OK")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 56 And incoming8 = 48 Then 'a80, exit window tank switch not OK
            Module1.exitTankSwitchBoolean = False
            'SerialPort1.WriteLine("exit window tank switch not OK")
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 48 Then 'D00, tank diameter = 19"  .125 .25 .375 .5 .625 .75 .875 1
            Module1.entryWindowTankWidthDouble = 19.0

            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 49 Then 'D01, tank diameter = 19.125"
            Module1.entryWindowTankWidthDouble = 19.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 50 Then 'D02, tank diameter = 19.25"
            Module1.entryWindowTankWidthDouble = 19.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 51 Then 'D03, tank diameter = 19.375"
            Module1.entryWindowTankWidthDouble = 19.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 52 Then 'D04, tank diameter = 19.5"
            Module1.entryWindowTankWidthDouble = 19.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 53 Then 'D05, tank diameter = 19.625"
            Module1.entryWindowTankWidthDouble = 19.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 54 Then 'D06, tank diameter = 19.75"
            Module1.entryWindowTankWidthDouble = 19.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 55 Then 'D07, tank diameter = 19.875"
            Module1.entryWindowTankWidthDouble = 19.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 56 Then 'D08, tank diameter = 20"
            Module1.entryWindowTankWidthDouble = 20.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 48 And incoming8 = 57 Then 'D09, tank diameter = 20.125"
            Module1.entryWindowTankWidthDouble = 20.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 48 Then 'D10, tank diameter = 20.25"
            Module1.entryWindowTankWidthDouble = 20.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 49 Then 'D11, tank diameter = 20.375"
            Module1.entryWindowTankWidthDouble = 20.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 50 Then 'D12, tank diameter = 20.5"
            Module1.entryWindowTankWidthDouble = 20.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 51 Then 'D13, tank diameter = 20.625"
            Module1.entryWindowTankWidthDouble = 20.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 52 Then 'D14, tank diameter = 20.75"
            Module1.entryWindowTankWidthDouble = 20.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 53 Then 'D15, tank diameter = 20.875"
            Module1.entryWindowTankWidthDouble = 20.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 54 Then 'D16, tank diameter = 21"
            Module1.entryWindowTankWidthDouble = 21.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 55 Then 'D17, tank diameter = 21.125"
            Module1.entryWindowTankWidthDouble = 21.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 56 Then 'D18, tank diameter = 21.25"
            Module1.entryWindowTankWidthDouble = 21.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 49 And incoming8 = 57 Then 'D19, tank diameter = 21.375"
            Module1.entryWindowTankWidthDouble = 21.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 48 Then 'D20, tank diameter = 21.5"
            Module1.entryWindowTankWidthDouble = 21.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 49 Then 'D21, tank diameter = 21.625"
            Module1.entryWindowTankWidthDouble = 21.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 50 Then 'D22, tank diameter = 21.75"
            Module1.entryWindowTankWidthDouble = 21.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 51 Then 'D23, tank diameter = 21.875"
            Module1.entryWindowTankWidthDouble = 21.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 52 Then 'D24, tank diameter = 22"
            Module1.entryWindowTankWidthDouble = 22.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 53 Then 'D25, tank diameter = 22.125"
            Module1.entryWindowTankWidthDouble = 22.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 54 Then 'D26, tank diameter = 22.25"
            Module1.entryWindowTankWidthDouble = 22.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 55 Then 'D27, tank diameter = 22.375"
            Module1.entryWindowTankWidthDouble = 22.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 56 Then 'D28, tank diameter = 22.5"
            Module1.entryWindowTankWidthDouble = 22.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 50 And incoming8 = 57 Then 'D29, tank diameter = 22.625"
            Module1.entryWindowTankWidthDouble = 22.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 48 Then 'D30, tank diameter = 22.75"
            Module1.entryWindowTankWidthDouble = 22.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 49 Then 'D31, tank diameter = 22.875"
            Module1.entryWindowTankWidthDouble = 22.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 50 Then 'D32, tank diameter = 23"
            Module1.entryWindowTankWidthDouble = 23.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 51 Then 'D33, tank diameter = 23.125"
            Module1.entryWindowTankWidthDouble = 23.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 52 Then 'D34, tank diameter = 23.25"
            Module1.entryWindowTankWidthDouble = 23.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 53 Then 'D35, tank diameter = 23.375"
            Module1.entryWindowTankWidthDouble = 23.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 54 Then 'D36, tank diameter = 23.5"
            Module1.entryWindowTankWidthDouble = 23.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 55 Then 'D37, tank diameter = 23.625"
            Module1.entryWindowTankWidthDouble = 23.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 56 Then 'D38, tank diameter = 23.75"
            Module1.entryWindowTankWidthDouble = 23.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 51 And incoming8 = 57 Then 'D39, tank diameter = 23.875"
            Module1.entryWindowTankWidthDouble = 23.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 48 Then 'D40, tank diameter = 24"
            Module1.entryWindowTankWidthDouble = 24.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 49 Then 'D41, tank diameter = 24.125"
            Module1.entryWindowTankWidthDouble = 24.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 50 Then 'D42, tank diameter = 24.25"
            Module1.entryWindowTankWidthDouble = 24.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 51 Then 'D43, tank diameter = 24.375"
            Module1.entryWindowTankWidthDouble = 24.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 52 Then 'D44, tank diameter = 24.5"
            Module1.entryWindowTankWidthDouble = 24.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 53 Then 'D45, tank diameter = 24.625"
            Module1.entryWindowTankWidthDouble = 24.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 54 Then 'D46, tank diameter = 24.75"
            Module1.entryWindowTankWidthDouble = 24.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 55 Then 'D47, tank diameter = 24.875"
            Module1.entryWindowTankWidthDouble = 24.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 56 Then 'D48, tank diameter = 25"
            Module1.entryWindowTankWidthDouble = 25.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 52 And incoming8 = 57 Then 'D49, tank diameter = 25.125"
            Module1.entryWindowTankWidthDouble = 25.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 48 Then 'D50, tank diameter = 25.25"
            Module1.entryWindowTankWidthDouble = 25.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 49 Then 'D51, tank diameter = 25.375"
            Module1.entryWindowTankWidthDouble = 25.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 50 Then 'D52, tank diameter = 25.5"
            Module1.entryWindowTankWidthDouble = 25.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 51 Then 'D53, tank diameter = 25.625"
            Module1.entryWindowTankWidthDouble = 25.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 52 Then 'D54, tank diameter = 25.75"
            Module1.entryWindowTankWidthDouble = 25.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 53 Then 'D55, tank diameter = 25.875"
            Module1.entryWindowTankWidthDouble = 25.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 68 And incoming7 = 53 And incoming8 = 54 Then 'D56, tank diameter = 26"
            Module1.entryWindowTankWidthDouble = 26.0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming7 = 48 Then
            Module1.tankLength1 = 0
        End If
        If incoming6 = 76 And incoming7 = 49 Then
            Module1.tankLength1 = 10
        End If
        If incoming6 = 76 And incoming7 = 50 Then
            Module1.tankLength1 = 20
        End If
        If incoming6 = 76 And incoming7 = 51 Then
            Module1.tankLength1 = 30
        End If
        If incoming6 = 76 And incoming7 = 52 Then
            Module1.tankLength1 = 40
        End If
        If incoming6 = 76 And incoming7 = 53 Then
            Module1.tankLength1 = 50
        End If
        If incoming6 = 76 And incoming7 = 54 Then
            Module1.tankLength1 = 60
        End If
        If incoming6 = 76 And incoming7 = 55 Then
            Module1.tankLength1 = 70
        End If
        If incoming6 = 76 And incoming7 = 56 Then
            Module1.tankLength1 = 80
        End If
        If incoming6 = 76 And incoming7 = 57 Then
            Module1.tankLength1 = 90
        End If
        If incoming6 = 76 And incoming8 = 48 Then
            Module1.tankLength1 = Module1.tankLength1 + 0
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 49 Then
            Module1.tankLength1 = Module1.tankLength1 + 1
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 50 Then
            Module1.tankLength1 = Module1.tankLength1 + 2
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 51 Then
            Module1.tankLength1 = Module1.tankLength1 + 3
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 52 Then
            Module1.tankLength1 = Module1.tankLength1 + 4
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 53 Then
            Module1.tankLength1 = Module1.tankLength1 + 5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 54 Then
            Module1.tankLength1 = Module1.tankLength1 + 6
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 55 Then
            Module1.tankLength1 = Module1.tankLength1 + 7
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 56 Then
            Module1.tankLength1 = Module1.tankLength1 + 8
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 76 And incoming8 = 57 Then
            Module1.tankLength1 = Module1.tankLength1 + 9
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 48 Then 'M00, tank length2 = 0  .125 .25 .375 .5 .625 .75 .875 1
            Module1.tankLength2 = 0.00
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 49 Then 'M01, tank length2 = .125"
            Module1.tankLength2 = 0.125
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 50 Then 'M02, tank length2 = .25"
            Module1.tankLength2 = 0.25
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 51 Then 'M03, tank length2 = .375"
            Module1.tankLength2 = 0.375
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 52 Then 'M04, tank length2 = .5"
            Module1.tankLength2 = 0.5
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 53 Then 'M05, tank length2 = .625"
            Module1.tankLength2 = 0.625
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 54 Then 'M06, tank length2 = .75"
            Module1.tankLength2 = 0.75
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 77 And incoming7 = 48 And incoming8 = 55 Then 'M07, tank length2 = .875"
            Module1.tankLength2 = 0.875
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
    End Sub

    'Save the file
    Private Sub SaveFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles SaveFileDialog1.FileOk

    End Sub
    'Add a row in the data grid view
    Private Sub addRowButton_Click(sender As Object, e As EventArgs) Handles addRowButton.Click
        Me.DataGridView1.Rows.Add("count", TextBox1.Text, "sequence #", TextBox9.Text, TextBox13.Text,
                                    TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox13.Text, TextBox13.Text,
                                    TextBox8.Text, TextBox17.Text, TextBox13.Text)
    End Sub
    'Remove row in data grid view
    Private Sub removeRowButton_Click(sender As Object, e As EventArgs) Handles removeRowButton.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            For i As Integer = DataGridView1.SelectedRows.Count - 1 To 0 Step -1
                DataGridView1.Rows.RemoveAt(DataGridView1.SelectedRows(i).Index)
            Next
        Else
            MessageBox.Show("No rows to select")
        End If
    End Sub
    'Test button to create a csv file
    Private Sub createFileButton_Click(sender As Object, e As EventArgs) Handles createFileButton.Click
        Dim file As System.IO.StreamWriter
        file = My.Computer.FileSystem.OpenTextFileWriter("c:/testfile/testfile.csv", True)
        file.WriteLine("this is only a test")
        file.Close()
    End Sub
    'Testing start button window
    Private Sub openTestingWindowButton_Click(sender As Object, e As EventArgs) Handles openTestingWindowButton.Click
        If (openTestingWindowButton.Text = "Open Testing Window") Then
            Form5.Show()
            openTestingWindowButton.Text = "Testing"
        Else
            Form5.Close()
            openTestingWindowButton.Text = "Open Testing Window"
        End If
    End Sub

End Class
