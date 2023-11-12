Public Class Form1
    Dim Timer As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label50.Text = "User: " & Form2.TextBox1.Text
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer += 1
        Label53.Text = Timer & " s"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        TextBox1.Text = "Press here and use arrows to move"
    End Sub

    Private Sub TextBox1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyDown
        'GAME IS STARTED?'
        If Timer = 0 Then
            Return
        End If

        'PLAYER MOVING'
        If e.KeyCode = Keys.Up Then
            Label22.Top -= 5
        End If
        If e.KeyCode = Keys.Down Then
            Label22.Top += 5
        End If
        If e.KeyCode = Keys.Left Then
            Label22.Left -= 5
        End If
        If e.KeyCode = Keys.Right Then
            Label22.Left += 5
        End If

        'START | FINISH'
        If Label22.Bounds.IntersectsWith(Label13.Bounds()) Then
            TextBox1.Text = "You won"
            Label52.Text += 10

            Label22.Location = New Point(185, 123)
            Timer1.Stop()
            Timer = 0

            Form3.Show()
            Return
        End If
        If Label22.Bounds.IntersectsWith(Label12.Bounds()) Then
            TextBox1.Text = "This is a start"
            Label22.Location = New Point(185, 123)
            Return
        End If

        'COLLISION'
        For Each label In Me.Controls.OfType(Of Label)
            If label IsNot Label22 And Label22.Bounds.IntersectsWith(label.Bounds) Then
                TextBox1.Text = "You touched the wall"
                Label52.Text -= 1

                If e.KeyCode = Keys.Up Then
                    Label22.Top += 7
                End If
                If e.KeyCode = Keys.Down Then
                    Label22.Top -= 7
                End If
                If e.KeyCode = Keys.Left Then
                    Label22.Left += 7
                End If
                If e.KeyCode = Keys.Right Then
                    Label22.Left -= 7
                End If
            End If
        Next
    End Sub
End Class
