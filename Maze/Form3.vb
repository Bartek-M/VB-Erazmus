Imports System.Reflection.Emit

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = "You won " & Form2.TextBox1.Text & "!"
        Label2.Text = "Points: " & Form1.Label52.Text
        Label3.Text = "Time: " & Form1.Label53.Text
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Label53.Text = "0 s"
        Form1.TextBox1.Text = "Press start to continue"
        Me.Hide()
    End Sub
End Class