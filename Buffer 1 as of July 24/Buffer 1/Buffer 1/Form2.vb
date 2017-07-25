Public Class Form2
    Public Property TextBox_pass As Object

    'Boot up
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    'Password textbox
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
    'Password enter button
    Private Sub enterButton_Click(sender As Object, e As EventArgs) Handles enterButton.Click
        If TextBox1.Text = "12" Then
            Form3.Show()
        Else
            MessageBox.Show("Password is not correct")
        End If
    End Sub

End Class