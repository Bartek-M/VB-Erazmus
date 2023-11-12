Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Winning As New List(Of Integer)

        While Winning.Count <= 7
            Dim Num As Integer

            If Winning.Count < 5 Then
                Num = (Rnd() * 49) + 1
            Else
                Num = (Rnd() * 6) + 1
            End If

            If Not Winning.Contains(Num) Then
                Winning.Add(Num)
            End If
        End While

        Label2.Text = Winning(0)
        Label3.Text = Winning(1)
        Label4.Text = Winning(2)
        Label5.Text = Winning(3)
        Label6.Text = Winning(4)

        Label7.Text = Winning(5)
        Label8.Text = Winning(6)
    End Sub
End Class
