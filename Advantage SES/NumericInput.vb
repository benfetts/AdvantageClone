Public Class NumericInput
    Inherits System.Windows.Forms.NumericUpDown

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        Try

            Me.Controls(0).Hide()

        Catch ex As Exception

        End Try

    End Sub
    Protected Overrides Sub OnTextBoxResize(source As Object, e As EventArgs)

        Try

            Me.Controls(1).Width = Me.Width - 4

        Catch ex As Exception

        End Try

    End Sub

#End Region

End Class
