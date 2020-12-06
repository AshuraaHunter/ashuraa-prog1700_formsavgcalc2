Public Class Form1
    Dim gradeAvg As Single
    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If TextBox1.Text = "" Or Not IsNumeric(TextBox1.Text) Then
            MsgBox("Please input a numeric value in the entry field.")
        ElseIf CSng(TextBox1.Text) < 0 = True Or TextBox1.Text > 100 = True Then
            MsgBox("Grade values may not fall below 0 or exceed 100.")
        Else
            listBoxGrades.Items.Add(TextBox1.Text)
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub buttonCalc_Click(sender As Object, e As EventArgs) Handles buttonCalc.Click
        Dim gradeTotal As Single = 0
        Dim gradesOverEightyNine As Single = 0
        If listBoxGrades.Items.Count = 0 Then
            MsgBox("You have not inputted any grades. Please try again.")
        Else
            For i = 0 To listBoxGrades.Items.Count - 1
                gradeTotal = (gradeTotal + listBoxGrades.Items(i))
                If listBoxGrades.Items(i) > 89 Then
                    gradesOverEightyNine = (gradesOverEightyNine + 1)
                End If
            Next
            gradeAvg = (gradeTotal / listBoxGrades.Items.Count)
            If (gradeAvg > 59) Then
                resultLabel.Text = gradeAvg.ToString("N")
                resultLabel.ForeColor = Color.Green
                rewriteNotifier.Text = ""
            Else
                resultLabel.Text = gradeAvg.ToString("N")
                resultLabel.ForeColor = Color.Red
                Select Case listBoxGrades.Items.Count
                    Case 1 To 3
                        If gradesOverEightyNine >= 1 Then
                            rewriteNotifier.Text = "Rewrite eligible!"
                            rewriteNotifier.ForeColor = Color.CornflowerBlue
                        Else
                            rewriteNotifier.Text = "Rewrite not eligible."
                            rewriteNotifier.ForeColor = Color.Orange
                        End If
                    Case 4 To 6
                        If gradesOverEightyNine >= 2 Then
                            rewriteNotifier.Text = "Rewrite eligible!"
                            rewriteNotifier.ForeColor = Color.CornflowerBlue
                        Else
                            rewriteNotifier.Text = "Rewrite not eligible."
                            rewriteNotifier.ForeColor = Color.Orange
                        End If
                    Case Is > 6
                        If gradesOverEightyNine >= 3 Then
                            rewriteNotifier.Text = "Rewrite eligible!"
                            rewriteNotifier.ForeColor = Color.CornflowerBlue
                        Else
                            rewriteNotifier.Text = "Rewrite not eligible."
                            rewriteNotifier.ForeColor = Color.Orange
                        End If
                    Case Else
                        MsgBox("How in Sam Hill did you get here?")
                End Select
            End If
        End If
    End Sub

    Private Sub buttonClear_Click(sender As Object, e As EventArgs) Handles buttonClear.Click
        listBoxGrades.Items.Clear()
        TextBox1.Text = ""
        resultLabel.Text = ""
        rewriteNotifier.Text = ""
        gradeAvg = 0
    End Sub
End Class
