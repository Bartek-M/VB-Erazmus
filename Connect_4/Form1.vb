Public Class Form1
    Dim Player As String = "RED"
    Dim matching As Integer = 0

    Dim diagonals_LR As New List(Of Integer) From {3, 4, 5, 6, 13, 20}
    Dim diagonals_RL As New List(Of Integer) From {14, 7, 0, 1, 2, 3}

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label44.Text = "Turn: " & Player
    End Sub

    Sub Set_Winner()
        Label45.Text = "Winner: " & Player & "!"
        Player = "-"
    End Sub

    Sub Set_Free(label, column)
        Dim labels = Me.Controls.OfType(Of Label).Reverse()

        labels(label).BackColor = If(Player = "RED", Color.Red(), Color.Yellow())
        Check_Winner(label, column)

        If Player = "RED" Then
            Player = "YELLOW"
        ElseIf Player = "YELLOW" Then
            Player = "RED"
        End If
    End Sub

    Sub Check_Free(column)
        Dim labels = Me.Controls.OfType(Of Label).Reverse()

        For i As Integer = 0 To 5
            If Not labels(column - 1 + (7 * i)).BackColor = Color.WhiteSmoke() Or i = 5 Then
                If i = 5 And labels(column - 1 + (7 * i)).BackColor = Color.WhiteSmoke() Then
                    Set_Free(column - 1 + (7 * i), column)
                ElseIf Not i - 1 < 0 Then
                    Set_Free(column - 1 + (7 * (i - 1)), column)
                End If

                Return
            End If
        Next
    End Sub

    Sub Check_Winner(label, column)
        Dim labels = Me.Controls.OfType(Of Label).Reverse()
        Dim sender_label = labels(label)

        'COLS'
        matching = 0

        For i As Integer = 0 To 5
            If labels(column - 1 + (7 * i)).BackColor = sender_label.BackColor Then
                matching += 1
            Else
                matching = 0
            End If

            If matching = 4 Then
                Set_Winner()
                Return
            End If
        Next

        'ROWS'
        matching = 0

        For i As Integer = 0 To 6
            If labels(i + ((label \ 7) * 7)).BackColor = sender_label.BackColor Then
                matching += 1
            Else
                matching = 0
            End If

            If matching = 4 Then
                Set_Winner()
                Return
            End If
        Next

        'DIAGONALS'
        matching = 0

        'LEFT - RIGHT'
        For Each num In diagonals_LR
            If (label - num) Mod 6 = 0 And label >= num Then
                Dim current As Integer = num

                While current < If(num > 4, 39, 30)
                    If labels(current).BackColor = sender_label.BackColor Then
                        matching += 1
                    Else
                        matching = 0
                    End If

                    If matching = 4 Then
                        Set_Winner()
                        Return
                    End If

                    current += 6
                End While

                Exit For
            End If
        Next

        'RIGHT - LEFT'
        For Each num In diagonals_RL
            If (label - num) Mod 8 = 0 And num <= label Then
                Dim current As Integer = num

                While current < If(num = 2 Or num = 3, 35, 42)
                    If labels(current).BackColor = sender_label.BackColor Then
                        matching += 1
                    Else
                        matching = 0
                    End If

                    If matching = 4 Then
                        Set_Winner()
                        Return
                    End If

                    current += 8
                End While

                Exit For
            End If
        Next
    End Sub

    'HANDLE PLAYER MOVES'
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click, Button6.Click, Button5.Click, Button4.Click, Button3.Click, Button2.Click, Button1.Click
        If Player = "-" Then
            Return
        End If

        Check_Free(sender.Text)
        Label44.Text = "Turn: " & Player
    End Sub

    'PLAY AGAIN'
    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Player = "RED"
        Label44.Text = "Turn: " & Player
        Label45.Text = "Winner: "

        For Each button In Me.Controls.OfType(Of Label)
            button.BackColor = Color.WhiteSmoke()
        Next
    End Sub
End Class
