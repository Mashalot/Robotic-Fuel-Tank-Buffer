
'All global variables here, booleans, measurements, etc

Public Class BluePrint

    'Computer and buffer 1 communication, side buffer, Serial Port 1
    Public axisOneOKBoolean As Boolean   '*11, *10, *11 = on, *10 = off
    Public Sub changeAxisOneOKBoolean(ByVal var As Boolean)
        axisOneOKBoolean = var
    End Sub
    Public Function getChangeAxisOneOKBoolean() As Boolean
        Return axisOneOKBoolean
    End Function
    Public axisTwoOKBoolean As Boolean   '*21, *20
    Public Sub changeAxisTwoOKBoolean(ByVal var As Boolean)
        axisTwoOKBoolean = var
    End Sub
    Public Function getChangeAxisTwoOKBoolean() As Boolean
        Return axisTwoOKBoolean
    End Function
    Public axisThreeOKBoolean As Boolean   '*31, *30
    Public Sub changeAxisThreeOKBoolean(ByVal var As Boolean)
        axisThreeOKBoolean = var
    End Sub
    Public Function getChangeAxisThreeOKBoolean() As Boolean
        Return axisThreeOKBoolean
    End Function
    Public axisFourOKBoolean As Boolean   '*41, *40
    Public Sub changeAxisFourOKBoolean(ByVal var As Boolean)
        axisFourOKBoolean = var
    End Sub
    Public Function getChangeAxisFourOKBoolean() As Boolean
        Return axisFourOKBoolean
    End Function
    Public tailStockHomeSwitchBoolean As Boolean   '*51, *50
    Public Sub changeTailStockHomeSwitchBoolean(ByVal var As Boolean)
        tailStockHomeSwitchBoolean = var
    End Sub
    Public Function getChangeTailStockHomeSwitchBoolean() As Boolean
        Return tailStockHomeSwitchBoolean
    End Function
    Public carriageHomeSwitchBoolean As Boolean   '*61, *60
    Public Sub changeCarriageHomeSwitchBoolean(ByVal var As Boolean)
        carriageHomeSwitchBoolean = var
    End Sub
    Public Function getChangeCarriageHomeSwitchBoolean() As Boolean
        Return carriageHomeSwitchBoolean
    End Function
    Public bufferWheelHomeSwitchBoolean As Boolean   '*71, *70
    Public Sub changeBufferWheelHomeSwitchBoolean(ByVal var As Boolean)
        bufferWheelHomeSwitchBoolean = var
    End Sub
    Public Function getChangeBufferWheelHomeSwitchBoolean() As Boolean
        Return bufferWheelHomeSwitchBoolean
    End Function
    Public wheelMeasureSwitchBoolean As Boolean   '*81, *80
    Public Sub changeWheelMeasureSwitchBoolean(ByVal var As Boolean)
        wheelMeasureSwitchBoolean = var
    End Sub
    Public Function getChangeWheelMeasureSwitchBoolean() As Boolean
        Return wheelMeasureSwitchBoolean
    End Function
    Public vacuumSuctionSwitchBoolean As Boolean   '*91, *90
    Public Sub changeVacuumSuctionSwitchBoolean(ByVal var As Boolean)
        vacuumSuctionSwitchBoolean = var
    End Sub
    Public Function getChangeVacuumSuctionSwitchBoolean() As Boolean
        Return vacuumSuctionSwitchBoolean
    End Function

    'Computer and buffer 2 communication, end buffer, Serial Port 2
    Public endAxisOneOKBoolean As Boolean   '*11, *10
    Public Sub changeEndAxisOneOKBoolean(ByVal var As Boolean)
        endAxisOneOKBoolean = var
    End Sub
    Public Function getChangeEndAxisOneOKBoolean() As Boolean
        Return endAxisOneOKBoolean
    End Function
    Public endAxisTwoOKBoolean As Boolean   '*21, *20
    Public Sub changeEndAxisTwoOKBoolean(ByVal var As Boolean)
        endAxisTwoOKBoolean = var
    End Sub
    Public Function getChangeEndAxisTwoOKBoolean() As Boolean
        Return endAxisTwoOKBoolean
    End Function
    Public endAxisThreeOKBoolean As Boolean   '*31, *30
    Public Sub changeEndAxisThreeOKBoolean(ByVal var As Boolean)
        endAxisThreeOKBoolean = var
    End Sub
    Public Function getChangeEndAxisThreeOKBoolean() As Boolean
        Return endAxisThreeOKBoolean
    End Function
    Public endAxisFourOKBoolean As Boolean   '*41, *40
    Public Sub changeEndAxisFourOKBoolean(ByVal var As Boolean)
        endAxisFourOKBoolean = var
    End Sub
    Public Function getChangeEndAxisFourOKBoolean() As Boolean
        Return endAxisFourOKBoolean
    End Function
    Public endTailStockHomeSwitchBoolean As Boolean   '*51, *50
    Public Sub changeEndTailStockHomeSwitchBoolean(ByVal var As Boolean)
        endTailStockHomeSwitchBoolean = var
    End Sub
    Public Function getChangeEndTailStockHomeSwitchBoolean() As Boolean
        Return endTailStockHomeSwitchBoolean
    End Function
    Public endCarriageHomeSwitchBoolean As Boolean   '*61, *60
    Public Sub changeEndCarriageHomeSwitchBoolean(ByVal var As Boolean)
        endCarriageHomeSwitchBoolean = var
    End Sub
    Public Function getChangeEndCarriageHomeSwitchBoolean() As Boolean
        Return endCarriageHomeSwitchBoolean
    End Function
    Public endBufferWheelHomeSwitchBoolean As Boolean   '*71, *70
    Public Sub changeEndBufferWheelHomeSwitchBoolean(ByVal var As Boolean)
        endBufferWheelHomeSwitchBoolean = var
    End Sub
    Public Function getChangeEndBufferWheelHomeSwitchBoolean() As Boolean
        Return endBufferWheelHomeSwitchBoolean
    End Function
    Public endWheelMeasureSwitchBoolean As Boolean   '*81, *80
    Public Sub changeEndWheelMeasureSwitchBoolean(ByVal var As Boolean)
        endWheelMeasureSwitchBoolean = var
    End Sub
    Public Function getChangeEndWheelMeasureSwitchBoolean() As Boolean
        Return endWheelMeasureSwitchBoolean
    End Function
    Public endVacuumSuctionSwitchBoolean As Boolean   '*91, *90
    Public Sub changeEndVacuumSuctionSwitchBoolean(ByVal var As Boolean)
        endVacuumSuctionSwitchBoolean = var
    End Sub
    Public Function getChangeEndVacuumSuctionSwitchBoolean() As Boolean
        Return endVacuumSuctionSwitchBoolean
    End Function

    'Computer and board communication, PIC micro, Serial Port 3
    Public entryWindowTankBoolean As Boolean   'b31, b30
    Public Sub changeEntryWindowTankBoolean(ByVal var As Boolean)
        entryWindowTankBoolean = var
    End Sub
    Public Function getChangeEntryWindowTankBoolean() As Boolean
        Return entryWindowTankBoolean
    End Function
    Public tankSwitchBoolean As Boolean   'a11, a10
    Public Sub changeTankSwitchBoolean(ByVal var As Boolean)
        tankSwitchBoolean = var
    End Sub
    Public Function getChangeTankSwitchBoolean() As Boolean
        Return tankSwitchBoolean
    End Function
    Public tankLengthBoolean As Boolean   'a31, a30
    Public Sub changeTankLengthBoolean(ByVal var As Boolean)
        tankLengthBoolean = var
    End Sub
    Public Function getChangeTankLengthBoolean()
        Return tankLengthBoolean
    End Function
    Public tankLength As Integer   'a21
    Public Sub changeTankLength(ByVal length As Integer)
        tankLength = length
    End Sub
    Public Function getChangeTankLength() As Integer
        Return tankLength
    End Function
    Public tankWidth As Integer   'a41
    Public Sub changeTankWidth(ByVal width As Integer)
        tankWidth = width
    End Sub
    Public Function getChangeTankWidth() As Integer
        Return tankWidth
    End Function
    Public tankWidthBoolean As Boolean   'a51, a50
    Public Sub changeTankWidthBoolean(ByVal var As Boolean)
        tankWidthBoolean = var
    End Sub
    Public Function getChangeTankWidthBoolean()
        Return tankWidthBoolean
    End Function
    Public robotVacuumSuctionBoolean As Boolean   'a61, a60
    Public Sub changeRobotVacuumSuctionBoolean(ByVal var As Boolean)
        robotVacuumSuctionBoolean = var
    End Sub
    Public Function getChangeRobotVacuumSuctionBoolean() As Boolean
        Return robotVacuumSuctionBoolean
    End Function
    Public barcodeReadBoolean As Boolean   'a71, a70
    Public Sub changeBarcodeReadBoolean(ByVal var As Boolean)
        barcodeReadBoolean = var
    End Sub
    Public Function getChangeBarcodeReadBoolean()
        Return barcodeReadBoolean
    End Function
    Public barcodeRead As Integer   'b51
    Public Sub changeBarcodeRead(ByVal var As Integer)
        barcodeRead = var
    End Sub
    Public Function getChangeBarcodeRead() As Integer
        Return barcodeRead
    End Function
    Public exitWindowTankBoolean As Boolean   'b41, b40
    Public Sub changeExitWindowTankBoolean(ByVal var As Boolean)
        exitWindowTankBoolean = var
    End Sub
    Public Function getChangeExitWindowTankBoolean() As Boolean
        Return exitWindowTankBoolean
    End Function
    Public robotVacuumSwitch As Boolean   'b21, b20
    Public Sub changeRobotVacuumSwitch(ByVal var As Boolean)
        robotVacuumSwitch = var
    End Sub
    Public Function getChangeRobotVacuumSwitch() As Boolean
        Return robotVacuumSwitch
    End Function
End Class
