<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.rotateAdvanceButton = New System.Windows.Forms.Button()
        Me.pistonAdvanceButton = New System.Windows.Forms.Button()
        Me.pistonRetractButton = New System.Windows.Forms.Button()
        Me.tailStockInBigButton = New System.Windows.Forms.Button()
        Me.bufferWheelHomeButton = New System.Windows.Forms.Button()
        Me.bufferWheelAdvanceButton = New System.Windows.Forms.Button()
        Me.tailStockOutBigButton = New System.Windows.Forms.Button()
        Me.tailStockHomeButton = New System.Windows.Forms.Button()
        Me.carriageAdvanceBigButton = New System.Windows.Forms.Button()
        Me.carriageRetractBigButton = New System.Windows.Forms.Button()
        Me.carriageHomeButton = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.tailStockInSmallButton = New System.Windows.Forms.Button()
        Me.tailStockOutSmallButton = New System.Windows.Forms.Button()
        Me.tailStockIsHomeButton = New System.Windows.Forms.Button()
        Me.carriageIsHomeButton = New System.Windows.Forms.Button()
        Me.setHomeButton = New System.Windows.Forms.Button()
        Me.resetHomeButton = New System.Windows.Forms.Button()
        Me.carriageAdvanceSmallButton = New System.Windows.Forms.Button()
        Me.carriageRetractSmallButton = New System.Windows.Forms.Button()
        Me.bufferWheelIsHomeButton = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.endCarriageRetractSmallButton = New System.Windows.Forms.Button()
        Me.endCarriageAdvanceSmallButton = New System.Windows.Forms.Button()
        Me.endTailStockOutSmallButton = New System.Windows.Forms.Button()
        Me.endTailStockInSmallButton = New System.Windows.Forms.Button()
        Me.endCarriageHomeButton = New System.Windows.Forms.Button()
        Me.endCarriageRetractBigButton = New System.Windows.Forms.Button()
        Me.endCarriageAdvanceBigButton = New System.Windows.Forms.Button()
        Me.endTailStockHomeButton = New System.Windows.Forms.Button()
        Me.endTailStockOutBigButton = New System.Windows.Forms.Button()
        Me.endBufferWheelAdvanceButton = New System.Windows.Forms.Button()
        Me.endBufferWheelHomeButton = New System.Windows.Forms.Button()
        Me.endTailStockInBigButton = New System.Windows.Forms.Button()
        Me.endPistonRetractButton = New System.Windows.Forms.Button()
        Me.endPistonAdvanceButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.endBufferWheelIsHomeButton = New System.Windows.Forms.Button()
        Me.endResetHomeButton = New System.Windows.Forms.Button()
        Me.endSetHomeButton = New System.Windows.Forms.Button()
        Me.endCarriageIsHomeButton = New System.Windows.Forms.Button()
        Me.endTailStockIsHomeButton = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.openEntryWindowTrayButton = New System.Windows.Forms.Button()
        Me.closeEntryWindowTrayButton = New System.Windows.Forms.Button()
        Me.openExitWindowTrayButton = New System.Windows.Forms.Button()
        Me.closeExitWindowTrayButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialPort2 = New System.IO.Ports.SerialPort(Me.components)
        Me.SerialPort3 = New System.IO.Ports.SerialPort(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'rotateAdvanceButton
        '
        Me.rotateAdvanceButton.Location = New System.Drawing.Point(17, 926)
        Me.rotateAdvanceButton.Name = "rotateAdvanceButton"
        Me.rotateAdvanceButton.Size = New System.Drawing.Size(326, 136)
        Me.rotateAdvanceButton.TabIndex = 1
        Me.rotateAdvanceButton.Text = "Rotate Tank Advance"
        Me.rotateAdvanceButton.UseVisualStyleBackColor = True
        '
        'pistonAdvanceButton
        '
        Me.pistonAdvanceButton.Location = New System.Drawing.Point(17, 96)
        Me.pistonAdvanceButton.Name = "pistonAdvanceButton"
        Me.pistonAdvanceButton.Size = New System.Drawing.Size(326, 136)
        Me.pistonAdvanceButton.TabIndex = 3
        Me.pistonAdvanceButton.Text = "Piston Advance"
        Me.pistonAdvanceButton.UseVisualStyleBackColor = True
        '
        'pistonRetractButton
        '
        Me.pistonRetractButton.Location = New System.Drawing.Point(17, 253)
        Me.pistonRetractButton.Name = "pistonRetractButton"
        Me.pistonRetractButton.Size = New System.Drawing.Size(326, 136)
        Me.pistonRetractButton.TabIndex = 4
        Me.pistonRetractButton.Text = "Piston Retract"
        Me.pistonRetractButton.UseVisualStyleBackColor = True
        '
        'tailStockInBigButton
        '
        Me.tailStockInBigButton.Location = New System.Drawing.Point(705, 254)
        Me.tailStockInBigButton.Name = "tailStockInBigButton"
        Me.tailStockInBigButton.Size = New System.Drawing.Size(326, 136)
        Me.tailStockInBigButton.TabIndex = 5
        Me.tailStockInBigButton.Text = "Tail Stock In 2"""
        Me.tailStockInBigButton.UseVisualStyleBackColor = True
        '
        'bufferWheelHomeButton
        '
        Me.bufferWheelHomeButton.Location = New System.Drawing.Point(17, 564)
        Me.bufferWheelHomeButton.Name = "bufferWheelHomeButton"
        Me.bufferWheelHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.bufferWheelHomeButton.TabIndex = 7
        Me.bufferWheelHomeButton.Text = "Buffer Wheel Home"
        Me.bufferWheelHomeButton.UseVisualStyleBackColor = True
        '
        'bufferWheelAdvanceButton
        '
        Me.bufferWheelAdvanceButton.Location = New System.Drawing.Point(17, 411)
        Me.bufferWheelAdvanceButton.Name = "bufferWheelAdvanceButton"
        Me.bufferWheelAdvanceButton.Size = New System.Drawing.Size(326, 136)
        Me.bufferWheelAdvanceButton.TabIndex = 8
        Me.bufferWheelAdvanceButton.Text = "Buffer Wheel Advance"
        Me.bufferWheelAdvanceButton.UseVisualStyleBackColor = True
        '
        'tailStockOutBigButton
        '
        Me.tailStockOutBigButton.Location = New System.Drawing.Point(705, 565)
        Me.tailStockOutBigButton.Name = "tailStockOutBigButton"
        Me.tailStockOutBigButton.Size = New System.Drawing.Size(326, 136)
        Me.tailStockOutBigButton.TabIndex = 9
        Me.tailStockOutBigButton.Text = "Tail Stock Out 2"""
        Me.tailStockOutBigButton.UseVisualStyleBackColor = True
        '
        'tailStockHomeButton
        '
        Me.tailStockHomeButton.Location = New System.Drawing.Point(705, 718)
        Me.tailStockHomeButton.Name = "tailStockHomeButton"
        Me.tailStockHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.tailStockHomeButton.TabIndex = 10
        Me.tailStockHomeButton.Text = "Tail Stock Home"
        Me.tailStockHomeButton.UseVisualStyleBackColor = True
        '
        'carriageAdvanceBigButton
        '
        Me.carriageAdvanceBigButton.Location = New System.Drawing.Point(362, 254)
        Me.carriageAdvanceBigButton.Name = "carriageAdvanceBigButton"
        Me.carriageAdvanceBigButton.Size = New System.Drawing.Size(326, 136)
        Me.carriageAdvanceBigButton.TabIndex = 11
        Me.carriageAdvanceBigButton.Text = "Carriage Advance 2"""
        Me.carriageAdvanceBigButton.UseVisualStyleBackColor = True
        '
        'carriageRetractBigButton
        '
        Me.carriageRetractBigButton.Location = New System.Drawing.Point(362, 565)
        Me.carriageRetractBigButton.Name = "carriageRetractBigButton"
        Me.carriageRetractBigButton.Size = New System.Drawing.Size(326, 136)
        Me.carriageRetractBigButton.TabIndex = 12
        Me.carriageRetractBigButton.Text = "Carriage Retract 2"""
        Me.carriageRetractBigButton.UseVisualStyleBackColor = True
        '
        'carriageHomeButton
        '
        Me.carriageHomeButton.Location = New System.Drawing.Point(362, 718)
        Me.carriageHomeButton.Name = "carriageHomeButton"
        Me.carriageHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.carriageHomeButton.TabIndex = 13
        Me.carriageHomeButton.Text = "Carriage Home"
        Me.carriageHomeButton.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'tailStockInSmallButton
        '
        Me.tailStockInSmallButton.Location = New System.Drawing.Point(705, 97)
        Me.tailStockInSmallButton.Name = "tailStockInSmallButton"
        Me.tailStockInSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.tailStockInSmallButton.TabIndex = 21
        Me.tailStockInSmallButton.Text = "Tail Stock In 1/8"""
        Me.tailStockInSmallButton.UseVisualStyleBackColor = True
        '
        'tailStockOutSmallButton
        '
        Me.tailStockOutSmallButton.Location = New System.Drawing.Point(705, 412)
        Me.tailStockOutSmallButton.Name = "tailStockOutSmallButton"
        Me.tailStockOutSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.tailStockOutSmallButton.TabIndex = 22
        Me.tailStockOutSmallButton.Text = "Tail Stock Out 1/8"""
        Me.tailStockOutSmallButton.UseVisualStyleBackColor = True
        '
        'tailStockIsHomeButton
        '
        Me.tailStockIsHomeButton.Location = New System.Drawing.Point(1059, 96)
        Me.tailStockIsHomeButton.Name = "tailStockIsHomeButton"
        Me.tailStockIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.tailStockIsHomeButton.TabIndex = 28
        Me.tailStockIsHomeButton.Text = "Tail Stock"
        Me.tailStockIsHomeButton.UseVisualStyleBackColor = True
        '
        'carriageIsHomeButton
        '
        Me.carriageIsHomeButton.Location = New System.Drawing.Point(1059, 186)
        Me.carriageIsHomeButton.Name = "carriageIsHomeButton"
        Me.carriageIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.carriageIsHomeButton.TabIndex = 29
        Me.carriageIsHomeButton.Text = "Carriage"
        Me.carriageIsHomeButton.UseVisualStyleBackColor = True
        '
        'setHomeButton
        '
        Me.setHomeButton.Location = New System.Drawing.Point(1059, 372)
        Me.setHomeButton.Name = "setHomeButton"
        Me.setHomeButton.Size = New System.Drawing.Size(111, 86)
        Me.setHomeButton.TabIndex = 30
        Me.setHomeButton.Text = "Set Home Boolean"
        Me.setHomeButton.UseVisualStyleBackColor = True
        '
        'resetHomeButton
        '
        Me.resetHomeButton.Location = New System.Drawing.Point(1059, 461)
        Me.resetHomeButton.Name = "resetHomeButton"
        Me.resetHomeButton.Size = New System.Drawing.Size(111, 86)
        Me.resetHomeButton.TabIndex = 31
        Me.resetHomeButton.Text = "Reset Home Boolean"
        Me.resetHomeButton.UseVisualStyleBackColor = True
        '
        'carriageAdvanceSmallButton
        '
        Me.carriageAdvanceSmallButton.Location = New System.Drawing.Point(362, 97)
        Me.carriageAdvanceSmallButton.Name = "carriageAdvanceSmallButton"
        Me.carriageAdvanceSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.carriageAdvanceSmallButton.TabIndex = 32
        Me.carriageAdvanceSmallButton.Text = "Carriage Advance 1/8"""
        Me.carriageAdvanceSmallButton.UseVisualStyleBackColor = True
        '
        'carriageRetractSmallButton
        '
        Me.carriageRetractSmallButton.Location = New System.Drawing.Point(362, 412)
        Me.carriageRetractSmallButton.Name = "carriageRetractSmallButton"
        Me.carriageRetractSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.carriageRetractSmallButton.TabIndex = 33
        Me.carriageRetractSmallButton.Text = "Carriage Retract 1/8"""
        Me.carriageRetractSmallButton.UseVisualStyleBackColor = True
        '
        'bufferWheelIsHomeButton
        '
        Me.bufferWheelIsHomeButton.Location = New System.Drawing.Point(1059, 276)
        Me.bufferWheelIsHomeButton.Name = "bufferWheelIsHomeButton"
        Me.bufferWheelIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.bufferWheelIsHomeButton.TabIndex = 34
        Me.bufferWheelIsHomeButton.Text = "Buffer Wheel"
        Me.bufferWheelIsHomeButton.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1059, 550)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(111, 86)
        Me.Button1.TabIndex = 35
        Me.Button1.Text = "Change Color"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1052, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 37)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Home"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(351, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(316, 64)
        Me.Label2.TabIndex = 38
        Me.Label2.Text = "Side Buffer"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1531, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(302, 64)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "End Buffer"
        '
        'endCarriageRetractSmallButton
        '
        Me.endCarriageRetractSmallButton.Location = New System.Drawing.Point(1542, 411)
        Me.endCarriageRetractSmallButton.Name = "endCarriageRetractSmallButton"
        Me.endCarriageRetractSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.endCarriageRetractSmallButton.TabIndex = 53
        Me.endCarriageRetractSmallButton.Text = "Carriage Retract 1/8"""
        Me.endCarriageRetractSmallButton.UseVisualStyleBackColor = True
        '
        'endCarriageAdvanceSmallButton
        '
        Me.endCarriageAdvanceSmallButton.Location = New System.Drawing.Point(1542, 97)
        Me.endCarriageAdvanceSmallButton.Name = "endCarriageAdvanceSmallButton"
        Me.endCarriageAdvanceSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.endCarriageAdvanceSmallButton.TabIndex = 52
        Me.endCarriageAdvanceSmallButton.Text = "Carriage Advance 1/8"""
        Me.endCarriageAdvanceSmallButton.UseVisualStyleBackColor = True
        '
        'endTailStockOutSmallButton
        '
        Me.endTailStockOutSmallButton.Location = New System.Drawing.Point(1883, 411)
        Me.endTailStockOutSmallButton.Name = "endTailStockOutSmallButton"
        Me.endTailStockOutSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.endTailStockOutSmallButton.TabIndex = 51
        Me.endTailStockOutSmallButton.Text = "Tail Stock Out 1/8"""
        Me.endTailStockOutSmallButton.UseVisualStyleBackColor = True
        '
        'endTailStockInSmallButton
        '
        Me.endTailStockInSmallButton.Location = New System.Drawing.Point(1883, 97)
        Me.endTailStockInSmallButton.Name = "endTailStockInSmallButton"
        Me.endTailStockInSmallButton.Size = New System.Drawing.Size(326, 136)
        Me.endTailStockInSmallButton.TabIndex = 50
        Me.endTailStockInSmallButton.Text = "Tail Stock In 1/8"""
        Me.endTailStockInSmallButton.UseVisualStyleBackColor = True
        '
        'endCarriageHomeButton
        '
        Me.endCarriageHomeButton.Location = New System.Drawing.Point(1542, 718)
        Me.endCarriageHomeButton.Name = "endCarriageHomeButton"
        Me.endCarriageHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.endCarriageHomeButton.TabIndex = 49
        Me.endCarriageHomeButton.Text = "Carriage Home"
        Me.endCarriageHomeButton.UseVisualStyleBackColor = True
        '
        'endCarriageRetractBigButton
        '
        Me.endCarriageRetractBigButton.Location = New System.Drawing.Point(1542, 564)
        Me.endCarriageRetractBigButton.Name = "endCarriageRetractBigButton"
        Me.endCarriageRetractBigButton.Size = New System.Drawing.Size(326, 136)
        Me.endCarriageRetractBigButton.TabIndex = 48
        Me.endCarriageRetractBigButton.Text = "Carriage Retract 2"""
        Me.endCarriageRetractBigButton.UseVisualStyleBackColor = True
        '
        'endCarriageAdvanceBigButton
        '
        Me.endCarriageAdvanceBigButton.Location = New System.Drawing.Point(1542, 253)
        Me.endCarriageAdvanceBigButton.Name = "endCarriageAdvanceBigButton"
        Me.endCarriageAdvanceBigButton.Size = New System.Drawing.Size(326, 136)
        Me.endCarriageAdvanceBigButton.TabIndex = 47
        Me.endCarriageAdvanceBigButton.Text = "Carriage Advance 2"""
        Me.endCarriageAdvanceBigButton.UseVisualStyleBackColor = True
        '
        'endTailStockHomeButton
        '
        Me.endTailStockHomeButton.Location = New System.Drawing.Point(1883, 718)
        Me.endTailStockHomeButton.Name = "endTailStockHomeButton"
        Me.endTailStockHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.endTailStockHomeButton.TabIndex = 46
        Me.endTailStockHomeButton.Text = "Tail Stock Home"
        Me.endTailStockHomeButton.UseVisualStyleBackColor = True
        '
        'endTailStockOutBigButton
        '
        Me.endTailStockOutBigButton.Location = New System.Drawing.Point(1883, 564)
        Me.endTailStockOutBigButton.Name = "endTailStockOutBigButton"
        Me.endTailStockOutBigButton.Size = New System.Drawing.Size(326, 136)
        Me.endTailStockOutBigButton.TabIndex = 45
        Me.endTailStockOutBigButton.Text = "Tail Stock Out 2"""
        Me.endTailStockOutBigButton.UseVisualStyleBackColor = True
        '
        'endBufferWheelAdvanceButton
        '
        Me.endBufferWheelAdvanceButton.Location = New System.Drawing.Point(1198, 411)
        Me.endBufferWheelAdvanceButton.Name = "endBufferWheelAdvanceButton"
        Me.endBufferWheelAdvanceButton.Size = New System.Drawing.Size(326, 136)
        Me.endBufferWheelAdvanceButton.TabIndex = 44
        Me.endBufferWheelAdvanceButton.Text = "Buffer Wheel Advance"
        Me.endBufferWheelAdvanceButton.UseVisualStyleBackColor = True
        '
        'endBufferWheelHomeButton
        '
        Me.endBufferWheelHomeButton.Location = New System.Drawing.Point(1198, 564)
        Me.endBufferWheelHomeButton.Name = "endBufferWheelHomeButton"
        Me.endBufferWheelHomeButton.Size = New System.Drawing.Size(326, 136)
        Me.endBufferWheelHomeButton.TabIndex = 43
        Me.endBufferWheelHomeButton.Text = "Buffer Wheel Home"
        Me.endBufferWheelHomeButton.UseVisualStyleBackColor = True
        '
        'endTailStockInBigButton
        '
        Me.endTailStockInBigButton.Location = New System.Drawing.Point(1883, 253)
        Me.endTailStockInBigButton.Name = "endTailStockInBigButton"
        Me.endTailStockInBigButton.Size = New System.Drawing.Size(326, 136)
        Me.endTailStockInBigButton.TabIndex = 42
        Me.endTailStockInBigButton.Text = "Tail Stock In 2"""
        Me.endTailStockInBigButton.UseVisualStyleBackColor = True
        '
        'endPistonRetractButton
        '
        Me.endPistonRetractButton.Location = New System.Drawing.Point(1198, 253)
        Me.endPistonRetractButton.Name = "endPistonRetractButton"
        Me.endPistonRetractButton.Size = New System.Drawing.Size(326, 136)
        Me.endPistonRetractButton.TabIndex = 41
        Me.endPistonRetractButton.Text = "Piston Retract"
        Me.endPistonRetractButton.UseVisualStyleBackColor = True
        '
        'endPistonAdvanceButton
        '
        Me.endPistonAdvanceButton.Location = New System.Drawing.Point(1198, 97)
        Me.endPistonAdvanceButton.Name = "endPistonAdvanceButton"
        Me.endPistonAdvanceButton.Size = New System.Drawing.Size(326, 136)
        Me.endPistonAdvanceButton.TabIndex = 40
        Me.endPistonAdvanceButton.Text = "Piston Advance"
        Me.endPistonAdvanceButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(2230, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 37)
        Me.Label4.TabIndex = 60
        Me.Label4.Text = "Home"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(2237, 550)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(111, 86)
        Me.Button2.TabIndex = 59
        Me.Button2.Text = "Change Color"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'endBufferWheelIsHomeButton
        '
        Me.endBufferWheelIsHomeButton.Location = New System.Drawing.Point(2237, 276)
        Me.endBufferWheelIsHomeButton.Name = "endBufferWheelIsHomeButton"
        Me.endBufferWheelIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.endBufferWheelIsHomeButton.TabIndex = 58
        Me.endBufferWheelIsHomeButton.Text = "Buffer Wheel"
        Me.endBufferWheelIsHomeButton.UseVisualStyleBackColor = True
        '
        'endResetHomeButton
        '
        Me.endResetHomeButton.Location = New System.Drawing.Point(2237, 461)
        Me.endResetHomeButton.Name = "endResetHomeButton"
        Me.endResetHomeButton.Size = New System.Drawing.Size(111, 86)
        Me.endResetHomeButton.TabIndex = 57
        Me.endResetHomeButton.Text = "Reset Home Boolean"
        Me.endResetHomeButton.UseVisualStyleBackColor = True
        '
        'endSetHomeButton
        '
        Me.endSetHomeButton.Location = New System.Drawing.Point(2237, 372)
        Me.endSetHomeButton.Name = "endSetHomeButton"
        Me.endSetHomeButton.Size = New System.Drawing.Size(111, 86)
        Me.endSetHomeButton.TabIndex = 56
        Me.endSetHomeButton.Text = "Set Home Boolean"
        Me.endSetHomeButton.UseVisualStyleBackColor = True
        '
        'endCarriageIsHomeButton
        '
        Me.endCarriageIsHomeButton.Location = New System.Drawing.Point(2237, 186)
        Me.endCarriageIsHomeButton.Name = "endCarriageIsHomeButton"
        Me.endCarriageIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.endCarriageIsHomeButton.TabIndex = 55
        Me.endCarriageIsHomeButton.Text = "Carriage"
        Me.endCarriageIsHomeButton.UseVisualStyleBackColor = True
        '
        'endTailStockIsHomeButton
        '
        Me.endTailStockIsHomeButton.Location = New System.Drawing.Point(2237, 96)
        Me.endTailStockIsHomeButton.Name = "endTailStockIsHomeButton"
        Me.endTailStockIsHomeButton.Size = New System.Drawing.Size(90, 90)
        Me.endTailStockIsHomeButton.TabIndex = 54
        Me.endTailStockIsHomeButton.Text = "Tail Stock"
        Me.endTailStockIsHomeButton.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1098, 731)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(244, 111)
        Me.Button3.TabIndex = 61
        Me.Button3.Text = "Pause"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'openEntryWindowTrayButton
        '
        Me.openEntryWindowTrayButton.Location = New System.Drawing.Point(501, 926)
        Me.openEntryWindowTrayButton.Name = "openEntryWindowTrayButton"
        Me.openEntryWindowTrayButton.Size = New System.Drawing.Size(326, 136)
        Me.openEntryWindowTrayButton.TabIndex = 62
        Me.openEntryWindowTrayButton.Text = "Open Entry Window Tray"
        Me.openEntryWindowTrayButton.UseVisualStyleBackColor = True
        '
        'closeEntryWindowTrayButton
        '
        Me.closeEntryWindowTrayButton.Location = New System.Drawing.Point(844, 926)
        Me.closeEntryWindowTrayButton.Name = "closeEntryWindowTrayButton"
        Me.closeEntryWindowTrayButton.Size = New System.Drawing.Size(326, 136)
        Me.closeEntryWindowTrayButton.TabIndex = 63
        Me.closeEntryWindowTrayButton.Text = "Close Entry Window Tray"
        Me.closeEntryWindowTrayButton.UseVisualStyleBackColor = True
        '
        'openExitWindowTrayButton
        '
        Me.openExitWindowTrayButton.Location = New System.Drawing.Point(1248, 926)
        Me.openExitWindowTrayButton.Name = "openExitWindowTrayButton"
        Me.openExitWindowTrayButton.Size = New System.Drawing.Size(326, 136)
        Me.openExitWindowTrayButton.TabIndex = 64
        Me.openExitWindowTrayButton.Text = "Open Exit Window Tray"
        Me.openExitWindowTrayButton.UseVisualStyleBackColor = True
        '
        'closeExitWindowTrayButton
        '
        Me.closeExitWindowTrayButton.Location = New System.Drawing.Point(1589, 926)
        Me.closeExitWindowTrayButton.Name = "closeExitWindowTrayButton"
        Me.closeExitWindowTrayButton.Size = New System.Drawing.Size(326, 136)
        Me.closeExitWindowTrayButton.TabIndex = 65
        Me.closeExitWindowTrayButton.Text = "Close Exit Window Tray"
        Me.closeExitWindowTrayButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(694, 859)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(385, 64)
        Me.Label5.TabIndex = 66
        Me.Label5.Text = "Entry Window"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 28.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(1431, 859)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(347, 64)
        Me.Label6.TabIndex = 67
        Me.Label6.Text = "Exit Window"
        '
        'SerialPort1
        '
        '
        'SerialPort2
        '
        Me.SerialPort2.PortName = "COM6"
        '
        'SerialPort3
        '
        Me.SerialPort3.PortName = "COM4"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(1285, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 20)
        Me.Label7.TabIndex = 69
        Me.Label7.Text = "Label7"
        '
        'Form3
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.ClientSize = New System.Drawing.Size(2456, 1086)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.closeExitWindowTrayButton)
        Me.Controls.Add(Me.openExitWindowTrayButton)
        Me.Controls.Add(Me.closeEntryWindowTrayButton)
        Me.Controls.Add(Me.openEntryWindowTrayButton)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.endBufferWheelIsHomeButton)
        Me.Controls.Add(Me.endResetHomeButton)
        Me.Controls.Add(Me.endSetHomeButton)
        Me.Controls.Add(Me.endCarriageIsHomeButton)
        Me.Controls.Add(Me.endTailStockIsHomeButton)
        Me.Controls.Add(Me.endCarriageRetractSmallButton)
        Me.Controls.Add(Me.endCarriageAdvanceSmallButton)
        Me.Controls.Add(Me.endTailStockOutSmallButton)
        Me.Controls.Add(Me.endTailStockInSmallButton)
        Me.Controls.Add(Me.endCarriageHomeButton)
        Me.Controls.Add(Me.endCarriageRetractBigButton)
        Me.Controls.Add(Me.endCarriageAdvanceBigButton)
        Me.Controls.Add(Me.endTailStockHomeButton)
        Me.Controls.Add(Me.endTailStockOutBigButton)
        Me.Controls.Add(Me.endBufferWheelAdvanceButton)
        Me.Controls.Add(Me.endBufferWheelHomeButton)
        Me.Controls.Add(Me.endTailStockInBigButton)
        Me.Controls.Add(Me.endPistonRetractButton)
        Me.Controls.Add(Me.endPistonAdvanceButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.bufferWheelIsHomeButton)
        Me.Controls.Add(Me.carriageRetractSmallButton)
        Me.Controls.Add(Me.carriageAdvanceSmallButton)
        Me.Controls.Add(Me.resetHomeButton)
        Me.Controls.Add(Me.setHomeButton)
        Me.Controls.Add(Me.carriageIsHomeButton)
        Me.Controls.Add(Me.tailStockIsHomeButton)
        Me.Controls.Add(Me.tailStockOutSmallButton)
        Me.Controls.Add(Me.tailStockInSmallButton)
        Me.Controls.Add(Me.carriageHomeButton)
        Me.Controls.Add(Me.carriageRetractBigButton)
        Me.Controls.Add(Me.carriageAdvanceBigButton)
        Me.Controls.Add(Me.tailStockHomeButton)
        Me.Controls.Add(Me.tailStockOutBigButton)
        Me.Controls.Add(Me.bufferWheelAdvanceButton)
        Me.Controls.Add(Me.bufferWheelHomeButton)
        Me.Controls.Add(Me.tailStockInBigButton)
        Me.Controls.Add(Me.pistonRetractButton)
        Me.Controls.Add(Me.pistonAdvanceButton)
        Me.Controls.Add(Me.rotateAdvanceButton)
        Me.Name = "Form3"
        Me.Text = "Service"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rotateAdvanceButton As Button
    Friend WithEvents pistonAdvanceButton As Button
    Friend WithEvents pistonRetractButton As Button
    Friend WithEvents tailStockInBigButton As Button
    Friend WithEvents bufferWheelHomeButton As Button
    Friend WithEvents bufferWheelAdvanceButton As Button
    Friend WithEvents tailStockOutBigButton As Button
    Friend WithEvents tailStockHomeButton As Button
    Friend WithEvents carriageAdvanceBigButton As Button
    Friend WithEvents carriageRetractBigButton As Button
    Friend WithEvents carriageHomeButton As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents tailStockInSmallButton As Button
    Friend WithEvents tailStockOutSmallButton As Button
    Friend WithEvents tailStockIsHomeButton As Button
    Friend WithEvents carriageIsHomeButton As Button
    Friend WithEvents setHomeButton As Button
    Friend WithEvents resetHomeButton As Button
    Friend WithEvents carriageAdvanceSmallButton As Button
    Friend WithEvents carriageRetractSmallButton As Button
    Friend WithEvents bufferWheelIsHomeButton As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents endCarriageRetractSmallButton As Button
    Friend WithEvents endCarriageAdvanceSmallButton As Button
    Friend WithEvents endTailStockOutSmallButton As Button
    Friend WithEvents endTailStockInSmallButton As Button
    Friend WithEvents endCarriageHomeButton As Button
    Friend WithEvents endCarriageRetractBigButton As Button
    Friend WithEvents endCarriageAdvanceBigButton As Button
    Friend WithEvents endTailStockHomeButton As Button
    Friend WithEvents endTailStockOutBigButton As Button
    Friend WithEvents endBufferWheelAdvanceButton As Button
    Friend WithEvents endBufferWheelHomeButton As Button
    Friend WithEvents endTailStockInBigButton As Button
    Friend WithEvents endPistonRetractButton As Button
    Friend WithEvents endPistonAdvanceButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents endBufferWheelIsHomeButton As Button
    Friend WithEvents endResetHomeButton As Button
    Friend WithEvents endSetHomeButton As Button
    Friend WithEvents endCarriageIsHomeButton As Button
    Friend WithEvents endTailStockIsHomeButton As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents openEntryWindowTrayButton As Button
    Friend WithEvents closeEntryWindowTrayButton As Button
    Friend WithEvents openExitWindowTrayButton As Button
    Friend WithEvents closeExitWindowTrayButton As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
    Friend WithEvents SerialPort2 As IO.Ports.SerialPort
    Friend WithEvents SerialPort3 As IO.Ports.SerialPort
    Friend WithEvents Label7 As Label
End Class
