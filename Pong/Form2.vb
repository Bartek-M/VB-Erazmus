Public Class Form2
    Dim direction As Integer = Rnd() * 2
    Dim speed As Integer = 4

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Randomize()
        Label2.Text = "Player: " & Form1.TextBox1.Text
        Label5.Location = New Point(765, (Rnd() * Me.Height - 60) + 20)

        'DIFFICULTY LEVELS'
        If Form1.RadioButton2.Checked Then
            Label1.Height = 170
        End If
        If Form1.RadioButton3.Checked Then
            Label1.Height = 100
        End If
    End Sub

    Sub Finish(score)
        Label4.Text += score
        Label5.Location = New Point(765, (Rnd() * Me.Height - 60) + 20)
        direction = Rnd() * 2

        'SPEED'
        If speed <= 20 Then
            If Form1.RadioButton2.Checked Then
                speed *= 1.05
            ElseIf Form1.RadioButton3.Checked Then
                speed *= 1.2
            Else
                speed *= 1.02
            End If
        End If
    End Sub

    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyValue = Keys.Up And Label1.Top > 30 Then
            Label1.Top -= 25
        End If

        If e.KeyValue = Keys.Down And Label1.Bottom < Me.Height - 60 Then
            Label1.Top += 25
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Label5.Left -= speed

        'MOVE INTO SPECIFIC DIRECTION'
        If direction >= 1 Then
            Label5.Top -= If(Form1.RadioButton1.Checked, 2, 6)
        End If
        If direction < 1 Then
            Label5.Top += If(Form1.RadioButton1.Checked, 2, 6)
        End If

        'BOUNCE OF THE WALLS'
        If Label5.Top < 20 Then
            direction = 0
        End If
        If Label5.Bottom > Me.Height - 40 Then
            direction = 2
        End If

        'BOUNCE OF THE PLAYER' 
        If Label5.Bounds.IntersectsWith(Label1.Bounds) Then
            Finish(2)
            Return
        End If
        If Label5.Location.X <= 190 Then
            Finish(-1)
            Return
        End If
    End Sub
End Class