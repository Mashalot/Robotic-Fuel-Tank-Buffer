Public Class Form3

    Private incoming As Byte
    Private incoming1 As Byte
    Private incoming2 As Byte
    Private incoming3 As Byte
    Private incoming4 As Byte
    Private incoming5 As Byte
    Private incoming6 As Byte
    Private incoming7 As Byte
    Private incoming8 As Byte
    'Form 3 boot up
    Public Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tailStockIsHomeButton.BackColor = Color.Green
        carriageIsHomeButton.BackColor = Color.Green
        bufferWheelIsHomeButton.BackColor = Color.Green
        endTailStockIsHomeButton.BackColor = Color.Green
        endCarriageIsHomeButton.BackColor = Color.Green
        endBufferWheelIsHomeButton.BackColor = Color.Green
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Module1.carriageHomeSwitchBoolean = True Then  '*61, *60
            carriageIsHomeButton.BackColor = Color.Red
            carriageRetractSmallButton.Enabled = False
            carriageRetractBigButton.Enabled = False
            carriageHomeButton.Enabled = False
        ElseIf Module1.carriageHomeSwitchBoolean = False Then
            carriageIsHomeButton.BackColor = Color.Green
            carriageRetractSmallButton.Enabled = True
            carriageRetractBigButton.Enabled = True
            carriageHomeButton.Enabled = True
        End If
        If Module1.tailStockHomeSwitchBoolean = True Then  '*51, *50
            tailStockIsHomeButton.BackColor = Color.Red
            tailStockOutSmallButton.Enabled = False
            tailStockOutBigButton.Enabled = False
            tailStockHomeButton.Enabled = False
        ElseIf Module1.tailStockHomeSwitchBoolean = False Then
            tailStockIsHomeButton.BackColor = Color.Green
            tailStockOutSmallButton.Enabled = True
            tailStockOutBigButton.Enabled = True
            tailStockHomeButton.Enabled = True
        End If
        If Module1.bufferWheelHomeSwitchBoolean = True Then  '*71, *70
            bufferWheelIsHomeButton.BackColor = Color.Red
            bufferWheelHomeButton.Enabled = False
            pistonRetractButton.Enabled = False
        ElseIf Module1.bufferWheelHomeSwitchBoolean = False Then
            bufferWheelIsHomeButton.BackColor = Color.Green
            bufferWheelHomeButton.Enabled = True
            pistonRetractButton.Enabled = True
        End If

        If Module1.endCarriageHomeSwitchBoolean = True Then  '#61, #60
            endCarriageIsHomeButton.BackColor = Color.Red
            endCarriageRetractSmallButton.Enabled = False
            endCarriageRetractBigButton.Enabled = False
            endCarriageHomeButton.Enabled = False
        ElseIf Module1.endCarriageHomeSwitchBoolean = False Then
            endCarriageIsHomeButton.BackColor = Color.Green
            endCarriageRetractSmallButton.Enabled = True
            endCarriageRetractBigButton.Enabled = True
            endCarriageHomeButton.Enabled = True
        End If
        If Module1.endTailStockHomeSwitchBoolean = True Then  '#51, #50
            endTailStockIsHomeButton.BackColor = Color.Red
            endTailStockOutSmallButton.Enabled = False
            endTailStockOutBigButton.Enabled = False
            endTailStockHomeButton.Enabled = False
        ElseIf Module1.endTailStockHomeSwitchBoolean = False Then
            endTailStockIsHomeButton.BackColor = Color.Green
            endTailStockOutSmallButton.Enabled = True
            endTailStockOutBigButton.Enabled = True
            endTailStockHomeButton.Enabled = True
        End If
        If Module1.endBufferWheelHomeSwitchBoolean = True Then  '#71, #70
            endBufferWheelIsHomeButton.BackColor = Color.Red
            endBufferWheelHomeButton.Enabled = False
            endPistonRetractButton.Enabled = False
        ElseIf Module1.endBufferWheelHomeSwitchBoolean = False Then
            endBufferWheelIsHomeButton.BackColor = Color.Green
            endBufferWheelHomeButton.Enabled = True
            endPistonRetractButton.Enabled = True
        End If
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

    'Rotate tank button:
    Public Sub rotateAdvanceButton_Click(sender As Object, e As EventArgs) Handles rotateAdvanceButton.Click

    End Sub

    'Entry Window buttons:
    Public Sub openEntryWindowTrayButton_Click(sender As Object, e As EventArgs) Handles openEntryWindowTrayButton.Click
        Me.SerialPort3.WriteLine("b31")
        Module1.entryWindowBoolean = True
    End Sub
    Public Sub closeEntryWindowTrayButton_Click(sender As Object, e As EventArgs) Handles closeEntryWindowTrayButton.Click
        Me.SerialPort3.WriteLine("b30")
        Module1.entryWindowBoolean = False
    End Sub

    'Side Buffer:
    Public Sub pistonAdvanceButton_Click(sender As Object, e As EventArgs) Handles pistonAdvanceButton.Click
        Me.SerialPort1.WriteLine("!23")
    End Sub
    Public Sub pistonRetractButton_Click(sender As Object, e As EventArgs) Handles pistonRetractButton.Click
        Me.SerialPort1.WriteLine("!24")
    End Sub
    Public Sub bufferWheelAdvanceButton_Click(sender As Object, e As EventArgs) Handles bufferWheelAdvanceButton.Click
        Me.SerialPort1.WriteLine("$3F000E4")
    End Sub
    Public Sub bufferWheelHomeButton_Click(sender As Object, e As EventArgs) Handles bufferWheelHomeButton.Click
        Module1.axisThreeOKBoolean = True
        While Module1.bufferWheelHomeSwitchBoolean = False
            If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = False Then '*31, *30, *71, *70
                Me.SerialPort1.WriteLine("$3R000E4")
            End If
            'System.Threading.Thread.Sleep(100)
        End While
        While Module1.bufferWheelHomeSwitchBoolean = True
            If Module1.axisThreeOKBoolean = True And Module1.bufferWheelHomeSwitchBoolean = True Then '*31, *30, *71, *70
                Me.SerialPort1.WriteLine("$3F000E4")
            End If
            'System.Threading.Thread.Sleep(100)
        End While
    End Sub
    Public Sub carriageAdvanceSmallButton_Click(sender As Object, e As EventArgs) Handles carriageAdvanceSmallButton.Click
        Me.SerialPort1.WriteLine("$1F000E1")
    End Sub
    Public Sub carriageAdvanceBigButton_Click(sender As Object, e As EventArgs) Handles carriageAdvanceBigButton.Click
        Me.SerialPort1.WriteLine("$1F002E0")
    End Sub
    Public Sub carriageRetractSmallButton_Click(sender As Object, e As EventArgs) Handles carriageRetractSmallButton.Click
        Module1.axisOneOKBoolean = True
        Me.SerialPort1.WriteLine("$1R000E1")
        While Module1.carriageHomeSwitchBoolean = True
            If Module1.axisOneOKBoolean = True And Module1.carriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort1.WriteLine("$1F000E1")
            End If
        End While
        carriageIsHomeButton.BackColor = Color.Green
        carriageRetractSmallButton.Enabled = True
    End Sub
    Public Sub carriageRetractBigButton_Click(sender As Object, e As EventArgs) Handles carriageRetractBigButton.Click
        Module1.axisOneOKBoolean = True
        Me.SerialPort1.WriteLine("$1R002E0")
        While Module1.carriageHomeSwitchBoolean = True
            If Module1.axisOneOKBoolean = True And Module1.carriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort1.WriteLine("$1F002E0")
            End If
        End While
        carriageIsHomeButton.BackColor = Color.Green
        carriageRetractBigButton.Enabled = True
    End Sub
    Public Sub carriageHomeButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles carriageHomeButton.Click
        Module1.axisOneOKBoolean = True
        While Module1.carriageHomeSwitchBoolean = False
            If Module1.axisOneOKBoolean = True And Module1.carriageHomeSwitchBoolean = False Then   '*11, *10, *61, *60
                Me.SerialPort1.WriteLine("$1R001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        While Module1.carriageHomeSwitchBoolean = True
            If Module1.axisOneOKBoolean = True And Module1.carriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort1.WriteLine("$1F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
    End Sub
    Public Sub tailStockInSmallButton_Click(sender As Object, e As EventArgs) Handles tailStockInSmallButton.Click
        Me.SerialPort1.WriteLine("$2F000E1")   'move tail stock in 1/8"
    End Sub
    Public Sub tailStockInBigButton_Click(sender As Object, e As EventArgs) Handles tailStockInBigButton.Click
        Me.SerialPort1.WriteLine("$2F002E0") 'move tail stock in 2"   
    End Sub
    Public Sub tailStockOutSmallButton_Click(sender As Object, e As EventArgs) Handles tailStockOutSmallButton.Click
        Module1.axisTwoOKBoolean = True
        Me.SerialPort1.WriteLine("$2R000E1")
        While Module1.tailStockHomeSwitchBoolean = True
            If Module1.axisTwoOKBoolean = True And Module1.tailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort1.WriteLine("$2F000E1")
            End If
        End While
        tailStockIsHomeButton.BackColor = Color.Green
        tailStockOutSmallButton.Enabled = True
    End Sub
    Public Sub tailStockOutBigButton_Click(sender As Object, e As EventArgs) Handles tailStockOutBigButton.Click
        Module1.axisTwoOKBoolean = True
        Me.SerialPort1.WriteLine("$2R002E0")
        While Module1.tailStockHomeSwitchBoolean = True
            If Module1.axisTwoOKBoolean = True And Module1.tailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort1.WriteLine("$2F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        tailStockIsHomeButton.BackColor = Color.Green
        tailStockOutBigButton.Enabled = True
    End Sub
    Public Sub tailStockHomeButton_Click(sender As Object, e As EventArgs) Handles tailStockHomeButton.Click
        Module1.axisTwoOKBoolean = True
        While Module1.tailStockHomeSwitchBoolean = False
            If Module1.axisTwoOKBoolean = True And Module1.tailStockHomeSwitchBoolean = False Then   '*21, *20, *51, *50
                Me.SerialPort1.WriteLine("$2R001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        While Module1.tailStockHomeSwitchBoolean = True
            If Module1.axisTwoOKBoolean = True And Module1.tailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort1.WriteLine("$2F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
    End Sub

    'Home indicator buttons for side buffer:
    Public Sub tailStockIsHomeButton_Click(sender As Object, e As EventArgs) Handles tailStockIsHomeButton.Click

    End Sub
    Public Sub carriageIsHomeButton_Click(sender As Object, e As EventArgs) Handles carriageIsHomeButton.Click

    End Sub
    Public Sub bufferWheelIsHomeButton_Click(sender As Object, e As EventArgs) Handles bufferWheelIsHomeButton.Click

    End Sub

    'Buttons for testing side buffer:
    Public Sub setHomeButton_Click(sender As Object, e As EventArgs) Handles setHomeButton.Click
        Module1.tailStockHomeSwitchBoolean = True
        Module1.carriageHomeSwitchBoolean = True
        Module1.bufferWheelHomeSwitchBoolean = True
    End Sub
    Public Sub resetHomeButton_Click(sender As Object, e As EventArgs) Handles resetHomeButton.Click
        Module1.tailStockHomeSwitchBoolean = False
        Module1.carriageHomeSwitchBoolean = False
        Module1.bufferWheelHomeSwitchBoolean = False
    End Sub
    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Module1.carriageHomeSwitchBoolean = True Then
            carriageIsHomeButton.BackColor = Color.Red
        Else
            carriageIsHomeButton.BackColor = Color.Green
        End If
        If Module1.tailStockHomeSwitchBoolean = True Then
            tailStockIsHomeButton.BackColor = Color.Red
        Else
            tailStockIsHomeButton.BackColor = Color.Green
        End If
        If Module1.bufferWheelHomeSwitchBoolean = True Then
            bufferWheelIsHomeButton.BackColor = Color.Red
        Else
            bufferWheelIsHomeButton.BackColor = Color.Green
        End If
    End Sub

    'End buffer:
    Public Sub endPistonAdvanceButton_Click(sender As Object, e As EventArgs) Handles endPistonAdvanceButton.Click
        Me.SerialPort2.WriteLine("!23")
    End Sub
    Public Sub endPistonRetractButton_Click(sender As Object, e As EventArgs) Handles endPistonRetractButton.Click
        Me.SerialPort2.WriteLine("!24")
    End Sub
    Public Sub endBufferWheelAdvanceButton_Click(sender As Object, e As EventArgs) Handles endBufferWheelAdvanceButton.Click
        Me.SerialPort2.WriteLine("$3F000E4")
    End Sub
    Public Sub endBufferWheelHomeButton_Click(sender As Object, e As EventArgs) Handles endBufferWheelHomeButton.Click
        Module1.endAxisThreeOKBoolean = True
        While Module1.endBufferWheelHomeSwitchBoolean = False
            If Module1.endAxisThreeOKBoolean = True And Module1.endBufferWheelHomeSwitchBoolean = False Then '#31, #30, #71, #70
                Me.SerialPort2.WriteLine("$3R000E4")
            End If
            'System.Threading.Thread.Sleep(100)
        End While
        While Module1.endBufferWheelHomeSwitchBoolean = True
            If Module1.endAxisThreeOKBoolean = True And Module1.endBufferWheelHomeSwitchBoolean = True Then '#31, *30, *71, *70
                Me.SerialPort2.WriteLine("$3F000E4")
            End If
            'System.Threading.Thread.Sleep(100)
        End While
    End Sub
    Public Sub endCarriageAdvanceSmallButton_Click(sender As Object, e As EventArgs) Handles endCarriageAdvanceSmallButton.Click
        Me.SerialPort2.WriteLine("$1F000E1")
    End Sub
    Public Sub endCarriageAdvanceBigButton_Click(sender As Object, e As EventArgs) Handles endCarriageAdvanceBigButton.Click
        Me.SerialPort2.WriteLine("$1F002E0")
    End Sub
    Public Sub endCarriageRetractSmallButton_Click(sender As Object, e As EventArgs) Handles endCarriageRetractSmallButton.Click
        Module1.endAxisOneOKBoolean = True
        Me.SerialPort2.WriteLine("$1R000E1")
        While Module1.endCarriageHomeSwitchBoolean = True
            If Module1.endAxisOneOKBoolean = True And Module1.endCarriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort2.WriteLine("$1F000E1")
            End If
        End While
        endCarriageIsHomeButton.BackColor = Color.Green
        endCarriageRetractSmallButton.Enabled = True
    End Sub
    Public Sub endCarriageRetractBigButton_Click(sender As Object, e As EventArgs) Handles endCarriageRetractBigButton.Click
        Module1.endAxisOneOKBoolean = True
        Me.SerialPort2.WriteLine("$1R002E0")
        While Module1.endCarriageHomeSwitchBoolean = True
            If Module1.endAxisOneOKBoolean = True And Module1.endCarriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort2.WriteLine("$1F002E0")
            End If
        End While
        endCarriageIsHomeButton.BackColor = Color.Green
        endCarriageRetractBigButton.Enabled = True
    End Sub
    Public Sub endCarriageHomeButton_Click(sender As Object, e As EventArgs) Handles endCarriageHomeButton.Click
        Module1.endAxisOneOKBoolean = True
        While Module1.endCarriageHomeSwitchBoolean = False
            If Module1.endAxisOneOKBoolean = True And Module1.endCarriageHomeSwitchBoolean = False Then   '*11, *10, *61, *60
                Me.SerialPort2.WriteLine("$1R001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        While Module1.endCarriageHomeSwitchBoolean = True
            If Module1.endAxisOneOKBoolean = True And Module1.endCarriageHomeSwitchBoolean = True Then   '*11, *10, *61, *60
                Me.SerialPort2.WriteLine("$1F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
    End Sub
    Public Sub endTailStockInSmallButton_Click(sender As Object, e As EventArgs) Handles endTailStockInSmallButton.Click
        Me.SerialPort2.WriteLine("$2F000E1")   'move tail stock in 1/8"
    End Sub
    Public Sub endTailStockInBigButton_Click(sender As Object, e As EventArgs) Handles endTailStockInBigButton.Click
        Me.SerialPort2.WriteLine("$2F002E0") 'move tail stock in 2"
    End Sub
    Public Sub endTailStockOutSmallButton_Click(sender As Object, e As EventArgs) Handles endTailStockOutSmallButton.Click
        Module1.endAxisTwoOKBoolean = True
        Me.SerialPort2.WriteLine("$2R000E1")
        While Module1.endTailStockHomeSwitchBoolean = True
            If Module1.endAxisTwoOKBoolean = True And Module1.endTailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort2.WriteLine("$2F000E1")
            End If
        End While
        endTailStockIsHomeButton.BackColor = Color.Green
        endTailStockOutSmallButton.Enabled = True
    End Sub
    Public Sub endTailStockOutBigButton_Click(sender As Object, e As EventArgs) Handles endTailStockOutBigButton.Click
        Module1.endAxisTwoOKBoolean = True
        Me.SerialPort2.WriteLine("$2R002E0")
        While Module1.endTailStockHomeSwitchBoolean = True
            If Module1.endAxisTwoOKBoolean = True And Module1.endTailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort2.WriteLine("$2F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        endTailStockIsHomeButton.BackColor = Color.Green
        endTailStockOutBigButton.Enabled = True
    End Sub
    Public Sub endTailStockHomeButton_Click(sender As Object, e As EventArgs) Handles endTailStockHomeButton.Click
        Module1.endAxisTwoOKBoolean = True
        While Module1.endTailStockHomeSwitchBoolean = False
            If Module1.endAxisTwoOKBoolean = True And Module1.endTailStockHomeSwitchBoolean = False Then   '*21, *20, *51, *50
                Me.SerialPort2.WriteLine("$2R001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
        While Module1.endTailStockHomeSwitchBoolean = True
            If Module1.endAxisTwoOKBoolean = True And Module1.endTailStockHomeSwitchBoolean = True Then   '*21, *20, *51, *50
                Me.SerialPort2.WriteLine("$2F001E0")
            End If
            'System.Threading.Thread.Sleep(2000)
        End While
    End Sub

    'Home indicator buttons for end buffer:
    Public Sub endTailStockIsHomeButton_Click(sender As Object, e As EventArgs) Handles endTailStockIsHomeButton.Click

    End Sub
    Public Sub endCarriageIsHomeButton_Click(sender As Object, e As EventArgs) Handles endCarriageIsHomeButton.Click

    End Sub
    Public Sub endBufferWheelIsHomeButton_Click(sender As Object, e As EventArgs) Handles endBufferWheelIsHomeButton.Click

    End Sub

    'Buttons for testing end buffer:
    Public Sub endSetHomeButton_Click(sender As Object, e As EventArgs) Handles endSetHomeButton.Click
        Module1.endTailStockHomeSwitchBoolean = True
        Module1.endCarriageHomeSwitchBoolean = True
        Module1.endBufferWheelHomeSwitchBoolean = True
    End Sub
    Public Sub endResetHomeButton_Click(sender As Object, e As EventArgs) Handles endResetHomeButton.Click
        Module1.endTailStockHomeSwitchBoolean = False
        Module1.endCarriageHomeSwitchBoolean = False
        Module1.endBufferWheelHomeSwitchBoolean = False
    End Sub
    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Module1.endCarriageHomeSwitchBoolean = True Then
            endCarriageIsHomeButton.BackColor = Color.Red
        Else
            endCarriageIsHomeButton.BackColor = Color.Green
        End If
        If Module1.endTailStockHomeSwitchBoolean = True Then
            endTailStockIsHomeButton.BackColor = Color.Red
        Else
            endTailStockIsHomeButton.BackColor = Color.Green
        End If
        If Module1.endBufferWheelHomeSwitchBoolean = True Then
            endBufferWheelIsHomeButton.BackColor = Color.Red
        Else
            endBufferWheelIsHomeButton.BackColor = Color.Green
        End If
    End Sub

    'Exit window buttons:
    Public Sub openExitWindowTrayButton_Click(sender As Object, e As EventArgs) Handles openExitWindowTrayButton.Click
        Me.SerialPort3.WriteLine("b41")
        Module1.exitWindowBoolean = False
    End Sub
    Public Sub closeExitWindowTrayButton_Click(sender As Object, e As EventArgs) Handles closeExitWindowTrayButton.Click
        Me.SerialPort3.WriteLine("b40")
        Module1.exitWindowBoolean = True
    End Sub

    'Test button for serial communication
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'manageBoolean.changeEndTailStockHomeSwitchBoolean(True)
        'Dim endTailStockHomeSwitchBoolean As Boolean
        'endTailStockHomeSwitchBoolean = Module1.getChangeEndTailStockHomeSwitchBoolean()
        'If endTailStockHomeSwitchBoolean = True Then
        '    MsgBox("It worked!!!!")
        '    Module1.changeEndTailStockHomeSwitchBoolean(False)
        'End If
        'If (Button3.Text = "Pause") Then
        '    SerialPort1.WriteLine("<P006ON>")
        '    Button3.Text = "Finish"
        'Else
        '    SerialPort1.WriteLine("<P006OF>")
        '    Button3.Text = "Pause"
        'End If
        'Do While Module1.axisTwoOKBoolean = True
        '    Module1.LEDOn()
        '    Module1.SerialPort1.ReadTimeout = 1200
        'Loop
        'Module1.LEDOff()

        'Dim index As Integer = 1
        'While Module1.axisTwoOKBoolean = False
        '    SerialPort1.WriteLine(index)
        '    index += 1
        '    Try
        '        SerialPort1.ReadTimeout = 5000
        '        SerialPort1.ReadLine()
        '        If incoming = 42 And incoming1 = 50 And incoming2 = 49 Then '*21, axis 2 OK
        '            Module1.axisTwoOKBoolean = True
        '            incoming = 0
        '            incoming1 = 0
        '            incoming2 = 0
        '        End If
        '        If Module1.axisTwoOKBoolean = True Then
        '            Exit While
        '        End If
        '        System.Threading.Thread.Sleep(1000)
        '    Catch

        '    End Try
        'End While

        SerialPort1.WriteLine("<P006ON>")
        If Module1.axisTwoOKBoolean = True Then
            MsgBox("axis two works!!!!")
        End If
        SerialPort1.WriteLine("<P006OF>")

    End Sub

    'When this form closes
    Private Sub Form3_Closing(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        ' Determine if text has changed in the textbox by comparing to original text.
        Me.SerialPort1.Close()
        'Me.SerialPort2.Close()
        'Me.SerialPort3.Close()
        Form1.SerialPort1.Open()
        'Form1.SerialPort2.Open()
        'Form1.SerialPort3.Open()
        Me.Timer1.Enabled = False
        Form1.Timer1.Enabled = True
    End Sub 'Form1_Closing

End Class