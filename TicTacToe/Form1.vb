Public Class Form1
    Dim Player As String = "X"

    Sub Set_Winner(pos_1, pos_2, pos_3)
        Label2.Text = "Winner: " & Player

        pos_1.BackColor = Color.DeepSkyBlue()
        pos_2.BackColor = Color.DeepSkyBlue()
        pos_3.BackColor = Color.DeepSkyBlue()
    End Sub

    Sub Check_Winner()
        'ROWS'
        If (Button1.Text = Button2.Text And Button1.Text = Button3.Text And Not Button1.Text = "-") Then
            Set_Winner(Button1, Button2, Button3)
        End If

        If (Button4.Text = Button5.Text And Button4.Text = Button6.Text And Not Button4.Text = "-") Then
            Set_Winner(Button4, Button5, Button6)
        End If

        If (Button7.Text = Button8.Text And Button7.Text = Button9.Text And Not Button7.Text = "-") Then
            Set_Winner(Button7, Button8, Button9)
        End If

        'COLUMN'
        If (Button1.Text = Button4.Text And Button1.Text = Button7.Text And Not Button1.Text = "-") Then
            Set_Winner(Button1, Button4, Button7)
        End If

        If (Button2.Text = Button5.Text And Button2.Text = Button8.Text And Not Button2.Text = "-") Then
            Set_Winner(Button2, Button5, Button8)
        End If

        If (Button3.Text = Button6.Text And Button3.Text = Button9.Text And Not Button3.Text = "-") Then
            Set_Winner(Button3, Button6, Button9)
        End If

        'DIAGONALS'
        If (Button1.Text = Button5.Text And Button1.Text = Button9.Text And Not Button1.Text = "-") Then
            Set_Winner(Button1, Button5, Button9)
        End If

        If (Button3.Text = Button5.Text And Button3.Text = Button7.Text And Not Button3.Text = "-") Then
            Set_Winner(Button3, Button5, Button7)
        End If

        'DRAW'

        Player = If(Player = "X", "O", "X")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button9.Click, Button8.Click, Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click
        If Not sender.Text = "-" Then
            Return
        End If

        sender.Text = Player
        Check_Winner()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        For Each button In Me.Controls.OfType(Of Button)
            If Not button.Name = Button10.Name Then
                button.Text = "-"
                button.BackColor = Color.WhiteSmoke()
            End If
        Next

        Player = "X"
        Label2.Text = "Winner: "
    End Sub
End Class
