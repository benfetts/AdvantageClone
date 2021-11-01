Namespace Database

    Public Class ODBC

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property DNSName() As String
        Public Property ServerName() As String
        Public Property DatabaseName() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.DNSName = String.Empty
            Me.ServerName = String.Empty
            Me.DatabaseName = String.Empty

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.DNSName & " - {" & Me.ServerName & " " & Me.DatabaseName & "}"

        End Function

#End Region

    End Class

End Namespace
