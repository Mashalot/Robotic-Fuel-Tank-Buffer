Imports System.IO.Ports

Module Module1
    Public tailStock As Double   'current location of tail stock
    Public counter1 As Integer
    Public counter2 As Integer
    Public counter3 As Integer
    Public counter4 As Integer
    Public counter5 As Integer
    Public counter6 As Integer
    Public stringVal As String
    Public Process As Integer
    Public ProcessB As Integer
    Public ProcessC As Integer
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
    Public bufferWheelOneDiameterReturn As Double
    Public bufferWheelOneWholeNumber As Integer
    Public bufferWheelOneFraction As Decimal
    Public bufferWheelOneFraction1 As Decimal
    Public bufferStationOneRPM As Integer
    Public tailStockOneOpen As Decimal
    Public tailStockOneOpenWholeNumber As Integer
    Public tailStockOneOpenFraction As Decimal
    Public tailStockOneOpenFraction1 As Decimal
    Public buffingOneFinishedBoolean As Boolean

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
    Public entryTankSwitchBoolean As Boolean   'a11, a10, true if entry window tank switch is triggered
    Public entryWindowOpenSwitchBoolean As Boolean   'a21, a20, true if entry window is open
    Public entryWindowClosedSwitchBoolean As Boolean   'a22, a23, true if entry window is closed
    Public entryWindowAvailableBoolean As Boolean   'true if entry window is open and ready for a new fuel tank
    Public exitWindowOpenSwitchBoolean As Boolean   'a31, a30
    Public exitWindowClosedSwitchBoolean As Boolean   'a32, a33
    Public exitWindowAvailableBoolean As Boolean    'true if exit window is closed and ready to receive the fuel tank
    Public robotInPositionBoolean As Boolean   'a41, a40, true if robot is in position
    Public robotHasSuctionBoolean As Boolean   'a61, a60, true if robot has suction
    Public exitWindowTankSwitchBoolean As Boolean   'a81, a80, true if exit window tank switch is triggered

    'Measurements
    Public bufferOneTankLengthDouble As Double
    Public bufferOneTraverseLengthDouble As Double
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
    Public exitWindowTankLengthString As String
    Public tankWidthBoolean As Boolean   'true if we have tank width

    Public robotVacuumSwitchBoolean As Boolean   'b21, b20, turn robot suction on if true
    Public entryWindowBoolean As Boolean   'b31, b30, true if entry window is open
    Public exitWindowBoolean As Boolean   'b41, b40, true if exit window is closed
    Public robotHomeBoolean As Boolean
    Public measurementsBoolean As Boolean
    Public PICisAliveBoolean As Boolean

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
        Module1.bufferWheelOneDiameter = 18
        Module1.axisOneOKBoolean = False
        Module1.axisTwoOKBoolean = False
        Module1.axisThreeOKBoolean = False
        Module1.axisFourOKBoolean = False
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
        If Module1.entryTankSwitchBoolean = True Then
            If Module1.entryWindowTankWidthDouble > 0 And Module1.tankLength > 0 Then
                Module1.measurementsBoolean = True
            Else
                SerialPort3.WriteLine("b71" & " measure entry tank width")
                SerialPort3.WriteLine("b81" & " measure entry tank length")
                System.Threading.Thread.Sleep(2000)
            End If
        End If
        TextBox13.Text = Module1.entryWindowTankWidthDouble
        If Module1.tankLength1 > 0 Or Module1.tankLength2 > 0 Then
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
        'close exit window
        If Module1.exitWindowTankSwitchBoolean = False And Module1.exitWindowAvailableBoolean = False Then
            System.Threading.Thread.Sleep(3000)
            SerialPort3.WriteLine("b40" & "close exit window if no tank in exit window")
        End If
        'if buffer 1 has suction, it's not available
        If Module1.bufferStationOneHasSuctionBoolean = True Then
            Module1.bufferStationOneAvailableBoolean = False
        Else
            Module1.bufferStationOneAvailableBoolean = True
        End If
        'if there's a tank in exit window, it's not available
        If Module1.exitWindowTankSwitchBoolean = True And Module1.exitWindowAvailableBoolean = True Then
            Module1.exitWindowAvailableBoolean = False
        End If
        'if robot does not reach its destination within 1 min, error
        If Module1.robotInPositionBoolean = False Then
            Dim index As Integer = 1
            While Module1.robotInPositionBoolean = False
                index += 1
                If index >= 600 Then
                    Timer1.Enabled = False
                    Timer2.Enabled = False
                    Timer3.Enabled = False
                    MsgBox("Error. Robot not in position. Please wait for polishing to finish. When finished, turn power off and fix the issue.")
                    Exit While
                Else
                    Exit While
                End If
            End While
        End If
    End Sub
    'Buffer 1 processes
    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'if buffer 1 available and entry window closed, if buffer wheel has been measured without error, send robot to entry window, robot suction on, move tail stock to 6" outside tank length
        If Module1.Process = 1 And Module1.ProcessB = 4 And Module1.bufferStationOneAvailableBoolean = True And Module1.entryWindowClosedSwitchBoolean = True Then
            SerialPort3.WriteLine("send robot to pick up tank in entry window")
            SerialPort3.WriteLine("b21 " & "turn robot suction on")

            Module1.bufferOneTankLengthDouble = Module1.tankLength   'entry window tank length becomes buffer 1 tank length, as a double
            Module1.ConvertDoubleString(Module1.bufferOneTankLengthDouble)   'convert tank length to a string, to put in text box 10
            Module1.bufferOneTankLengthString = Module1.stringVal   'save tank length string into buffer one tank length string
            TextBox10.Text = Module1.bufferOneTankLengthString   'put this string into text box 10

            Module1.bufferOneTankID = Module1.entryWindowTankID   'entry window tank ID becomes buffer one tank ID
            TextBox2.Text = Module1.bufferOneTankID   'enter this tank ID into text box 2

            Module1.bufferOneTankWidthDouble = Module1.entryWindowTankWidthDouble   'move tank width measurement from entry window to buffer 1
            TextBox14.Text = Module1.bufferOneTankWidthDouble       'enter tank width, now in buffer 1, into text box 14

            Module1.tailStockOneOpen = 102.5 - Module1.bufferOneTankLengthDouble - 6    'calculate how far to open tail stock
            Module1.tailStockOneOpenWholeNumber = Math.Truncate(Module1.tailStockOneOpen)
            Module1.tailStockOneOpenFraction = Module1.tailStockOneOpen - Module1.tailStockOneOpenWholeNumber
            If Module1.tailStockOneOpenFraction = 0 Then
                Module1.tailStockOneOpenFraction1 = 0
            ElseIf Module1.tailStockOneOpenFraction = 0.125 Then
                Module1.tailStockOneOpenFraction1 = 1
            ElseIf Module1.tailStockOneOpenFraction = 0.25 Then
                Module1.tailStockOneOpenFraction1 = 2
            ElseIf Module1.tailStockOneOpenFraction = 0.375 Then
                Module1.tailStockOneOpenFraction1 = 3
            ElseIf Module1.tailStockOneOpenFraction = 0.5 Then
                Module1.tailStockOneOpenFraction1 = 4
            ElseIf Module1.tailStockOneOpenFraction = 0.625 Then
                Module1.tailStockOneOpenFraction1 = 5
            ElseIf Module1.tailStockOneOpenFraction = 0.75 Then
                Module1.tailStockOneOpenFraction1 = 6
            ElseIf Module1.tailStockOneOpenFraction = 0.875 Then
                Module1.tailStockOneOpenFraction1 = 7
            Else
                Module1.tailStockOneOpenFraction1 = 0
            End If
            'SerialPort1.WriteLine("$2F0" & Module1.tailStockOneOpenWholeNumber & "E" & Module1.tailStockOneOpenFraction1 & " move tail stock to tank length plus 6")
            SerialPort3.WriteLine("$2F0" & Module1.tailStockOneOpenWholeNumber & "E" & Module1.tailStockOneOpenFraction1 & " move tail stock to tank length plus 6")
            Module1.Process = 2
            Module1.entryTankSwitchBoolean = False
            Module1.robotInPositionBoolean = False
        End If

        'is robot in position at entry window?
        If Module1.Process = 2 And Module1.robotInPositionBoolean = True Then
            SerialPort3.WriteLine("robot in position at entry window")
            Module1.Process = 3
        End If

        'does robot have suction at entry window? 10 seconds to say yes
        While Module1.Process = 3 And Module1.robotHasSuctionBoolean = False
            System.Threading.Thread.Sleep(1000)
            Module1.counter1 += 1
            SerialPort3.WriteLine(counter1)
            If Module1.counter1 >= 10 Then
                Module1.Process = 99
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                MessageBox.Show("Error, robot does not have suction. Wait for polishing to finish. When finished, turn power off and fix the issue.", "Error", MessageBoxButtons.OK)
            ElseIf Module1.counter1 < 10 And Module1.robotHasSuctionBoolean = True Then
                SerialPort3.WriteLine("robot has suction at entry window")
                SerialPort1.WriteLine("!21 " & " turn buffer 1 suction on")
                Module1.Process = 4
                Module1.axisTwoOKBoolean = False
                Exit While
            End If
        End While

        'if buffer 1 tail stock in position, and tail stock is in place, move tank to buffer 1
        If Module1.Process = 4 And Module1.axisTwoOKBoolean = True Then
            SerialPort3.WriteLine("tail stock in position" & " tell robot to move tank from entry window to buffer 1")
            'SerialPort3.WriteLine("tell robot to move tank from entry window to buffer 1")
            Module1.robotInPositionBoolean = False
            Module1.axisTwoOKBoolean = False
            Module1.Process = 5
        End If

        'if robot in position at buffer 1, move tail stock in 6 inches
        If Module1.Process = 5 And Module1.robotInPositionBoolean = True Then
            Me.SerialPort1.WriteLine("b31" & " open entry window to receive tank")
            SerialPort1.WriteLine("$2F006E0" & " move tail stock in 6 inches")
            Module1.bufferStationOneHasSuctionBoolean = False
            Module1.Process = 6
        End If

        'does buffer 1 have suction? 10 seconds to say yes, if yes, turn robot suction off
        While Module1.Process = 6 And Module1.bufferStationOneHasSuctionBoolean = False And Module1.axisTwoOKBoolean = True
            System.Threading.Thread.Sleep(1000)
            Module1.counter2 += 1
            SerialPort3.WriteLine(counter2 & " does buffer 1 have suction?")
            If Module1.counter2 >= 10 Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                MsgBox("Error, buffer 1 does not have suction.")
                SerialPort3.WriteLine("tell robot to send tank back to entry window")
                If Module1.robotInPositionBoolean = True Then
                    SerialPort3.WriteLine("b20" & " release suction if robot back at entry window")
                    Dim counter As Integer = 1
                    'did robot release suction?
                    While Module1.robotHasSuctionBoolean = True
                        System.Threading.Thread.Sleep(1000)
                        counter += 0
                        SerialPort3.WriteLine(counter & " did robot release suction on the tank?")
                        If counter = 10 Then
                            Module1.Process = 99
                            Timer1.Enabled = False
                            Timer2.Enabled = False
                            Timer3.Enabled = False
                            MsgBox("Error, robot not releasing suction. Let polishing finish, then remove power and correct issue.")
                            Exit While
                        ElseIf counter < 10 And Module1.robotHasSuctionBoolean = False Then
                            Timer1.Enabled = False
                            Timer2.Enabled = False
                            Timer3.Enabled = False
                            SerialPort3.WriteLine("Robot has returned tank to entry window. Let polishing finish, then remove power and correct issue.")
                            SerialPort3.WriteLine("b61" & " send robot home")
                            Exit While
                        End If
                    End While
                    Exit While
                End If
            ElseIf Module1.counter2 < 10 And Module1.bufferStationOneHasSuctionBoolean = True Then
                SerialPort3.WriteLine("b20" & " release robot suction because buffer 1 has suction now")
                Module1.Process = 7
                Module1.axisTwoOKBoolean = False
                Exit While
            End If
        End While

        'did robot release suction on tank? 10 seconds to say yes
        While Module1.Process = 7 And Module1.robotHasSuctionBoolean = True
            System.Threading.Thread.Sleep(1000)
            Module1.counter3 += 1
            SerialPort3.WriteLine(counter3 & " did robot release suction on the tank?")
            If Module1.counter3 = 10 Then
                Module1.Process = 99
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                MsgBox("Error, robot not releasing suction. Let buffing finish, then remove power and correct issue.")
                Exit While
            ElseIf Module1.counter3 < 10 And Module1.robotHasSuctionBoolean = False Then
                SerialPort3.WriteLine("robot has released tank")
                SerialPort3.WriteLine("b61" & " send robot home")
                Module1.Process = 8
                Exit While
            End If
        End While

        'move carriage to buffing start position, 7" away from carriage home
        If Module1.Process = 8 Then
            Me.SerialPort1.WriteLine("$1F007E0" & " move carriage to buffing start point")
            Module1.Process = 9
        End If

        'turn buffer on, once carriage is in position
        If Module1.Process = 9 And Module1.axisOneOKBoolean = True Then
            Me.SerialPort1.WriteLine("!35" & " turn buffer on")
            System.Threading.Thread.Sleep(1000)
            Module1.axisOneOKBoolean = False
            Timer4.Enabled = True
            Module1.Process = 10
        End If

        'look at timer 4 to see buffing algorithm

        'Once the tank is done buffing, if exit window is available and no tank in exit window tray, send robot to get the tank and turn robot suction on
        If Module1.Process = 11 And Module1.axisOneOKBoolean = True And Module1.exitWindowAvailableBoolean = True And Module1.exitWindowTankSwitchBoolean = False Then
            SerialPort3.WriteLine("send robot to get tank at buffer 1, post buffing")
            SerialPort3.WriteLine("b21" & " turn robot suction on")
            Module1.buffingOneFinishedBoolean = False
            Module1.robotInPositionBoolean = False  'might delete this
            Module1.Process = 12
        End If

        'if robot is in position at buffer 1,
        If Module1.Process = 12 And Module1.robotInPositionBoolean = True Then
            SerialPort3.WriteLine("robot in position")
            Module1.Process = 13
        End If

        'does robot have suction at buffer 1? 10 seconds to say yes, if yes, turn buffer 1 suction off
        While Module1.Process = 13 And Module1.robotHasSuctionBoolean = False
            System.Threading.Thread.Sleep(1000)
            Module1.counter4 += 1
            SerialPort3.WriteLine(counter4)
            If Module1.counter4 = 10 Then
                Module1.Process = 99
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                MsgBox("Error, robot does not have suction. Let buffing finish, then remove power and correct issue.")
                Exit While
            ElseIf Module1.counter4 < 10 And Module1.robotHasSuctionBoolean = True Then
                SerialPort3.WriteLine("robot has suction at buffer 1")
                SerialPort1.WriteLine("!22 " & "turn buffer 1 suction off")
                Module1.Process = 14
                Exit While
            End If
        End While

        'is buffer 1 suction off? 10 seconds to turn off
        While Module1.Process = 14 And Module1.bufferStationOneHasSuctionBoolean = True And Module1.axisTwoOKBoolean = True
            System.Threading.Thread.Sleep(1000)
            Module1.counter5 += 1
            SerialPort3.WriteLine(counter5 & " does buffer 1 have suction?")
            If Module1.counter5 = 10 Then
                Module1.Process = 99
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                MsgBox("Error, buffer 1 still has suction. Remove power and correct issue.")
                Exit While
            ElseIf Module1.counter5 < 10 And Module1.bufferStationOneHasSuctionBoolean = False Then
                SerialPort1.WriteLine("$2R006E0" & " move tail stock out 6 inches, now that buffer 1 doesn't have suction")
                Module1.Process = 15
                Module1.axisTwoOKBoolean = False
                Exit While
            End If
        End While

        'if tail stock in position, send tail stock to home position and tell robot to move tank from buffer 1 to exit window
        If Module1.Process = 15 And Module1.robotHasSuctionBoolean = True And Module1.axisTwoOKBoolean = True Then
            SerialPort1.WriteLine("$2R0" & Module1.tailStockOneOpenWholeNumber & "E" & Module1.tailStockOneOpenFraction1 & " move tail stock back to home position")

            'SerialPort3.WriteLine("tell robot to move tank from buffer 1 to buffer 2")

            SerialPort3.WriteLine("tell robot to move tank from buffer 1 to exit window")
            Module1.robotInPositionBoolean = False
            Module1.axisTwoOKBoolean = False
            Module1.Process = 16
        End If

        'if robot is in position at exit window, release suction
        If Module1.Process = 16 And Module1.robotInPositionBoolean = True And Module1.robotHasSuctionBoolean = True Then
            SerialPort3.WriteLine("b20" & " release robot suction")
            'did robot release suction on tank?
            While Module1.Process = 16 And Module1.robotInPositionBoolean = True And Module1.robotHasSuctionBoolean = True
                System.Threading.Thread.Sleep(1000)
                Module1.counter6 += 1
                SerialPort3.WriteLine(counter6)
                If Module1.counter6 = 10 Then
                    Module1.Process = 99
                    Timer1.Enabled = False
                    Timer2.Enabled = False
                    Timer3.Enabled = False
                    MsgBox("Error. Robot not releasing suction. Remove power and correct issue")
                    Exit While
                ElseIf Module1.counter6 < 10 And Module1.robotHasSuctionBoolean = False Then
                    SerialPort3.WriteLine("robot has released tank")
                    SerialPort3.WriteLine("b61" & " send robot home")
                    Module1.Process = 17
                    Exit While
                End If
            End While
        ElseIf Module1.Process = 16 And Module1.robotInPositionBoolean = True And Module1.robotHasSuctionBoolean = False Then
            Module1.exitWindowTankID = Module1.bufferOneTankID
            TextBox4.Text = Module1.exitWindowTankID
            Module1.exitWindowTankLengthString = Module1.bufferOneTankLengthString
            TextBox12.Text = Module1.exitWindowTankLengthString
            Module1.exitWindowTankWidthDouble = Module1.bufferOneTankWidthDouble
            TextBox16.Text = Module1.exitWindowTankWidthDouble
            'Module1.bufferStationOneAvailableBoolean = True
            Module1.Process = 17
        End If

        'open exit window for personnel to remove tank
        If Module1.Process = 17 Then
            SerialPort3.WriteLine("b41" & " open exit window")
            Module1.Process = 99
        End If
        'reset everything and stop timer 2, 3, 4, end the process chain
        If Module1.Process = 99 Then
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False
            Module1.entryTankSwitchBoolean = False
            Module1.measurementsBoolean = False
            Module1.entryWindowTankWidthDouble = 0
            Module1.tankLength = 0
            Module1.tankLength1 = 0
            Module1.tankLength2 = 0
            TextBox1.Text = ""
            TextBox9.Text = ""
            TextBox13.Text = ""
            Module1.counter1 = 0
            Module1.counter2 = 0
            Module1.counter3 = 0
            Module1.counter4 = 0
            Module1.counter5 = 0
            Module1.counter6 = 0
            Module1.tailStockOneOpen = 0
            Module1.tailStockOneOpenWholeNumber = 0
            Module1.tailStockOneOpenFraction = 0
            Module1.robotHasSuctionBoolean = False  'only here for testing
            Module1.robotInPositionBoolean = False  'only here for testing
            Module1.axisOneOKBoolean = False
            Module1.axisTwoOKBoolean = False
            Module1.axisThreeOKBoolean = False
            Module1.axisFourOKBoolean = False
            Module1.bufferStationOneHasSuctionBoolean = False
            Module1.bufferOneMeasuringSwitchBoolean = False
            Module1.buffingOneFinishedBoolean = False
            Module1.entryWindowAvailableBoolean = True
        End If
    End Sub
    'get buffer wheel 1 measurement
    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'advance the piston, move buffer wheel up to where an 18" wheel should press measuring switch, 16.5" - 9" = 7.5"
        If Module1.ProcessB = 1 Then
            'Me.SerialPort1.WriteLine("!23" & " advance piston")
            Me.SerialPort3.WriteLine("!23" & " advance piston")
            System.Threading.Thread.Sleep(1000)
            'Me.SerialPort1.WriteLine("$3F007E4" & " advance buffer wheel")
            Me.SerialPort3.WriteLine("$3F007E4" & " advance buffer wheel")
            Module1.axisThreeOKBoolean = False
            Module1.bufferOneMeasuringSwitchBoolean = False
            Module1.ProcessB = 2
        End If
        'Get buffer 1 wheel measurement and calculate RPM
        If Module1.ProcessB = 2 And Module1.axisThreeOKBoolean = True And Module1.bufferOneMeasuringSwitchBoolean = False Then
            'Me.SerialPort1.WriteLine("$3F000E4")
            Me.SerialPort3.WriteLine("$3F000E4")
            Module1.bufferWheelOneDiameter -= 0.5
            Module1.axisThreeOKBoolean = False
        ElseIf Module1.ProcessB = 2 And Module1.axisThreeOKBoolean = True And Module1.bufferOneMeasuringSwitchBoolean = True Then
            If Module1.bufferWheelOneDiameter = 18 Or Module1.bufferWheelOneDiameter = 17.5 Then
                'Me.SerialPort1.WriteLine("!11")
                Me.SerialPort3.WriteLine("!11")
                Module1.ProcessB = 3
            ElseIf Module1.bufferWheelOneDiameter = 17 Or Module1.bufferWheelOneDiameter = 16.5 Then
                'Me.SerialPort1.WriteLine("!12")
                Me.SerialPort3.WriteLine("!12")
                Module1.ProcessB = 3
            ElseIf Module1.bufferWheelOneDiameter = 16 Or Module1.bufferWheelOneDiameter = 15.5 Then
                'Me.SerialPort1.WriteLine("!13")
                Me.SerialPort3.WriteLine("!13")
                Module1.ProcessB = 3
            ElseIf Module1.bufferWheelOneDiameter = 15 Or Module1.bufferWheelOneDiameter = 14.5 Then
                'Me.SerialPort1.WriteLine("!14")
                Me.SerialPort3.WriteLine("!14")
                Module1.ProcessB = 3
            ElseIf Module1.bufferWheelOneDiameter = 14 Or Module1.bufferWheelOneDiameter = 13.5 Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                Timer4.Enabled = False
                Dim result As Integer
                result = MessageBox.Show("Error, buffing wheel at 14 inches. Needs to be changed soon. Continue anyway?", "Error", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Me.SerialPort1.WriteLine("!10" & " stop buffer wheel")
                    Me.SerialPort1.WriteLine("!24" & " retract piston")
                    Me.SerialPort1.WriteLine("$3R007E4" & " retract buffer wheel")
                    While Module1.bufferWheelHomeSwitchBoolean = False
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = False Then
                            Me.SerialPort1.WriteLine("$3R000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    While Module1.bufferWheelHomeSwitchBoolean = True
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = True Then
                            Me.SerialPort1.WriteLine("$3F000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    Module1.bufferWheelOneDiameter = 18
                    Module1.ProcessB = 1
                    Timer1.Enabled = True
                    Timer2.Enabled = True
                    Timer3.Enabled = True
                    Timer4.Enabled = True
                    Module1.Process = 99
                End If
                If result = DialogResult.Yes Then
                    'Me.SerialPort1.WriteLine("!15")
                    Me.SerialPort3.WriteLine("!15")
                    Module1.ProcessB = 3
                    Timer3.Enabled = True
                End If
            ElseIf Module1.bufferWheelOneDiameter = 13 Then
                Timer3.Enabled = False
                Dim result As Integer
                result = MessageBox.Show("Error, buffing wheel at 13 inches. Needs to be changed very soon. Continue anyway?", "Error", MessageBoxButtons.YesNo)
                If result = DialogResult.No Then
                    Timer1.Enabled = False
                    Timer2.Enabled = False
                    Timer3.Enabled = False
                    Timer4.Enabled = False
                    Me.SerialPort1.WriteLine("!10" & " stop buffer wheel")
                    Me.SerialPort1.WriteLine("!24" & " retract piston")
                    Me.SerialPort1.WriteLine("$3R007E4" & " retract buffer wheel")
                    While Module1.bufferWheelHomeSwitchBoolean = False
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = False Then
                            Me.SerialPort1.WriteLine("$3R000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    While Module1.bufferWheelHomeSwitchBoolean = True
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = True Then
                            Me.SerialPort1.WriteLine("$3F000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    Module1.bufferWheelOneDiameter = 18
                    Module1.ProcessB = 1
                    Timer1.Enabled = True
                    Timer2.Enabled = True
                    Timer3.Enabled = True
                    Timer4.Enabled = True
                    Module1.Process = 99
                End If
                If result = DialogResult.Yes Then
                    'Me.SerialPort1.WriteLine("!16")
                    Me.SerialPort3.WriteLine("!16")
                    Module1.ProcessB = 3
                    Timer3.Enabled = True
                End If
            ElseIf Module1.bufferWheelOneDiameter < 13 Then
                Timer1.Enabled = False
                Timer2.Enabled = False
                Timer3.Enabled = False
                Timer4.Enabled = False
                Dim result As Integer
                result = MessageBox.Show("Error, buffing wheel must be changed.", "Error", MessageBoxButtons.OK)
                If result = DialogResult.OK Then
                    Me.SerialPort1.WriteLine("!24" & " retract piston")
                    Me.SerialPort1.WriteLine("$3R007E4" & " retract buffer wheel")
                    While Module1.bufferWheelHomeSwitchBoolean = False
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = False Then
                            Me.SerialPort1.WriteLine("$3R000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    While Module1.bufferWheelHomeSwitchBoolean = True
                        If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = True Then
                            Me.SerialPort1.WriteLine("$3F000E4")
                            System.Threading.Thread.Sleep(300)
                        End If
                    End While
                    Module1.bufferWheelOneDiameter = 18
                    Module1.ProcessB = 1
                    Timer1.Enabled = True
                    Timer2.Enabled = True
                    Timer3.Enabled = True
                    Timer4.Enabled = True
                    Module1.Process = 99
                End If
            End If
        End If
        'retract piston in preparation for buffing
        If Module1.ProcessB = 3 Then
            Me.SerialPort1.WriteLine("!24" & " retract piston")
            Module1.ProcessB = 4
            Timer3.Enabled = False
        End If
    End Sub
    'buff the sides of tank and close exit window
    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        'buff sides of tank
        If Module1.Process = 10 Then
            TextBox6.Text = TimeString
            'DataGridView1.CurrentRow(TextBox1.Text, Module1.tankLength, Module1.entryWindowTankWidthDouble, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox13.Text, TextBox13.Text, TextBox8.Text, TextBox17.Text, TextBox13.Text)
            Dim index As Integer = 1
            Module1.bufferOneTraverseLengthDouble = Module1.tailStockOneOpenWholeNumber + 4
            While index <= 5   'loop 40 times, change to 40 when done testing
                If Module1.ProcessC = 0 And Module1.axisOneOKBoolean = True Then
                    Me.SerialPort1.WriteLine("!23" & " advance piston")
                    System.Threading.Thread.Sleep(1000)
                    Me.SerialPort1.WriteLine("$1F0" & Module1.bufferOneTraverseLengthDouble & "E" & Module1.tailStockOneOpenFraction1 & " send buffer, tank length plus 4")
                    Module1.axisOneOKBoolean = False
                    Module1.ProcessC = 1
                End If
                If Module1.ProcessC = 1 And Module1.axisOneOKBoolean = True Then
                    Me.SerialPort1.WriteLine("!24" & " retract piston")
                    If Module1.axisFourOKBoolean = True Then
                        Me.SerialPort1.WriteLine("!33" & " rotate tank 1 increment")
                    End If
                    System.Threading.Thread.Sleep(1000)
                    Me.SerialPort1.WriteLine("$1R0" & Module1.bufferOneTraverseLengthDouble & "E" & Module1.tailStockOneOpenFraction1 & " return buffer, tank length plus 4")
                    Module1.axisOneOKBoolean = False
                    Module1.ProcessC = 0
                    index = index + 1
                End If
            End While
            Me.SerialPort1.WriteLine("!36" & " turn buffer off")
            Me.SerialPort1.WriteLine("$1R007E0" & " move carriage to home position")
            Module1.Process = 11
            Module1.buffingOneFinishedBoolean = True
            Module1.axisOneOKBoolean = False
            Timer4.Enabled = False
        End If
    End Sub
    'check to see if PIC is still alive
    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        If Module1.PICisAliveBoolean = True Then
            Module1.PICisAliveBoolean = False
            SerialPort3.WriteLine("PIC is good")
        ElseIf Module1.PICisAliveBoolean = False Then
            While Module1.PICisAliveBoolean = False
                System.Threading.Thread.Sleep(100)
                Dim counter As Integer
                counter += 1
                SerialPort3.WriteLine(counter)
                If counter = 10 Then
                    MsgBox("Error. No communication with buffer 1. Check all electrical connections or call for service")
                    Timer1.Enabled = False
                    Module1.Process = 99
                    Timer3.Enabled = False
                    Timer4.Enabled = False
                    Exit While
                ElseIf counter < 10 And Module1.PICisAliveBoolean = True Then
                    Module1.PICisAliveBoolean = False
                    Exit While
                End If
            End While
        End If



    End Sub
    'errors timer
    Private Sub Timer6_Tick(sender As Object, e As EventArgs) Handles Timer6.Tick
        'just for handling errors where we have to wait for buffing to finish
        If Module1.Process = 98 And Timer4.Enabled = True Then
            If Timer4.Enabled = False Then
                Module1.Process = 99
            End If
        End If
        'if there's an error that requires everything shut down
        If Module1.Process = 100 Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False
            Module1.entryTankSwitchBoolean = False
            Module1.measurementsBoolean = False
            Module1.entryWindowTankWidthDouble = 0
            Module1.tankLength = 0
            Module1.tankLength1 = 0
            Module1.tankLength2 = 0
            TextBox1.Text = ""
            TextBox9.Text = ""
            TextBox13.Text = ""
            Module1.counter1 = 0
            Module1.counter2 = 0
            Module1.counter3 = 0
            Module1.counter4 = 0
            Module1.counter5 = 0
            Module1.counter6 = 0
            Module1.tailStockOneOpen = 0
            Module1.tailStockOneOpenWholeNumber = 0
            Module1.tailStockOneOpenFraction = 0
            Module1.robotHasSuctionBoolean = False  'only here for testing
            Module1.robotInPositionBoolean = False  'only here for testing
            Module1.axisOneOKBoolean = False
            Module1.axisTwoOKBoolean = False
            Module1.axisThreeOKBoolean = False
            Module1.axisFourOKBoolean = False
            Module1.bufferStationOneHasSuctionBoolean = False
            Module1.bufferOneMeasuringSwitchBoolean = False
            Module1.buffingOneFinishedBoolean = False
            Module1.entryWindowAvailableBoolean = True
        End If
    End Sub

    'Start Button
    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        addRowButton.Enabled = True
        removeRowButton.Enabled = True
        createFileButton.Enabled = True
        pauseFinishButton.Enabled = True
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
        Me.SerialPort3.WriteLine("b30" & " close entry window")
        System.Threading.Thread.Sleep(2000)
        If Module1.entryWindowClosedSwitchBoolean = True Then
            Timer2.Enabled = True
            Timer3.Enabled = True
            Module1.Process = 1
            Module1.ProcessB = 1
        Else
            MsgBox("Error, entry window not closed")
            Exit Sub
        End If

        TextBox5.Text = TimeString
        TextBox17.Text = DateString
        DataGridView1.Rows.Add(TextBox1.Text, Module1.tankLength, Module1.entryWindowTankWidthDouble, TextBox5.Text, TextBox6.Text, TextBox7.Text, TextBox13.Text, TextBox13.Text, TextBox8.Text, TextBox17.Text, TextBox13.Text)
        TextBox1.Text = ""
    End Sub
    'Pause/Finish Button
    Private Sub pauseFinishButton_Click(sender As Object, e As EventArgs) Handles pauseFinishButton.Click
        If (pauseFinishButton.Text = "Pause") Then
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False
            Timer4.Enabled = False
            Timer5.Enabled = False
            Timer6.Enabled = False
            pauseFinishButton.Text = "Finish"
        Else
            Timer1.Enabled = True
            Timer2.Enabled = True
            Timer3.Enabled = True
            Timer4.Enabled = True
            Timer5.Enabled = True
            Timer6.Enabled = True
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
            Me.SerialPort1.WriteLine("!36")   'turn buffer 1 off
            Me.SerialPort2.WriteLine("!36")   'turn buffer 2 off
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
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 49 And incoming2 = 48 Then '*10, axis 1 not OK
            Module1.axisOneOKBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 50 And incoming2 = 49 Then '*21, axis 2 OK
            Module1.axisTwoOKBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 50 And incoming2 = 48 Then '*20, axis 2 not OK
            Module1.axisTwoOKBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 51 And incoming2 = 49 Then '*31, axis 3 OK
            Module1.axisThreeOKBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 51 And incoming2 = 48 Then '*30, axis 3 not OK
            Module1.axisThreeOKBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 52 And incoming2 = 49 Then '*41, axis 4 OK
            Module1.axisFourOKBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 52 And incoming2 = 48 Then '*40, axis 4 not OK
            Module1.axisFourOKBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 54 And incoming2 = 49 Then 'if *61, carriage home switch is on
            Module1.carriageHomeSwitchBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 54 And incoming2 = 48 Then 'if *60, carriage home switch is off
            Module1.carriageHomeSwitchBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 55 And incoming2 = 49 Then 'if *71, buffer wheel home switch is on
            Module1.bufferWheelHomeSwitchBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 55 And incoming2 = 48 Then 'if *70, buffer wheel home switch is off
            Module1.bufferWheelHomeSwitchBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 56 And incoming2 = 49 Then 'if *81, wheel measure switch is on
            Module1.bufferOneMeasuringSwitchBoolean = True
            'End If
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 56 And incoming2 = 48 Then 'if *80, wheel measure switch is off
            Module1.bufferOneMeasuringSwitchBoolean = False
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 49 Then '*91, vacuum suction switch is on
            Module1.vacuumSuctionSwitchBoolean = True
            incoming = 0
            incoming1 = 0
            incoming2 = 0
        End If
        If incoming = 42 And incoming1 = 57 And incoming2 = 48 Then '*90, vacuum suction switch is off
            Module1.vacuumSuctionSwitchBoolean = False
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
        If incoming6 = 121 And incoming7 = 101 And incoming8 = 115 Then 'yes, PIC is still active
            Module1.PICisAliveBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
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
            Module1.entryWindowAvailableBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 50 And incoming8 = 51 Then 'a23, entry window closed switch false
            Module1.entryWindowClosedSwitchBoolean = False
            Module1.entryWindowAvailableBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 49 Then 'a31, exit window closed switch true
            Module1.exitWindowClosedSwitchBoolean = True
            Module1.exitWindowAvailableBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 51 And incoming8 = 48 Then 'a30, exit window closed switch false
            Module1.exitWindowClosedSwitchBoolean = False
            Module1.exitWindowAvailableBoolean = False
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
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 54 And incoming8 = 48 Then 'a60, does robot have suction? no robot suction
            Module1.robotHasSuctionBoolean = False
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 56 And incoming8 = 49 Then 'a81, exit window tank switch OK
            Module1.exitWindowTankSwitchBoolean = True
            incoming6 = 0
            incoming7 = 0
            incoming8 = 0
        End If
        If incoming6 = 97 And incoming7 = 56 And incoming8 = 48 Then 'a80, exit window tank switch not OK
            Module1.exitWindowTankSwitchBoolean = False
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

    'when buffer 1 is finished, the buffer wheel should be at the measuring switch
    'tail stock should be home, and carriage should be home
    'before you can send the robot to get the tank from buffer 1, to move it to buffer 2,
    'have to check if buffer 2 is available, if buffer 2 has suction, it's not available
    'if buffer 2 is available?
    'if yes, send robot to tank
    'is robot in position? 10 seconds to respond
    'does robot have suction? 10 seconds to respond
    'move buffing station 2 cradle to home position
    'move buffer 2 buffing wheel to tank length plus 12
    'if everything good so far, move tank to buffing station 2
    'move buffers to tank length
    'engage buffer 2 suction
    'is suction good? 10 seconds to respond
    'check buffer diameter, set buffer speed, turn buffer on
    'move buffer to tank length
    'move tank so that buffer is at center of tank
    'move tank half Of tank diameter In positive y axis direction plus 6 inches
    'run buffer the width Of tank
    'move buffer up
    'run buffer the width Of tank again
    'so on And so forth until tank ends are buffed depending on measurements
    'move cradle tank In reverse diameter plus 12 inches
    'repeat dependent On tank diameter
    'retract buffer
    'move buffer To measurement spot
    'move cradle To home position
    'tell robot To move To buffer 2 position, Using previous variables
    'Is robot ok? Check for 10 seconds
    'Is suction good? Within 10 seconds otherwise error message
End Class
