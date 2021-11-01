Namespace Services

    Public Class Gmail
        Inherits Base.ServiceBase

#Region " Constants "

#End Region

#Region " Enum "


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Shared ReadOnly Property Scope As String
            Get
                Return "https://mail.google.com/"
            End Get
        End Property

#End Region

#Region " Methods "

#Region " Public "

        Public Sub New(ByVal ConnectionString As String, ByVal EmployeeCode As String, ByVal EmailAddress As String, ByVal IsWebvantage As Boolean, ByVal UseWindowsAuthentication As Boolean)

            MyBase.New(ConnectionString, EmployeeCode, EmailAddress, IsWebvantage, UseWindowsAuthentication)

        End Sub
        Public Overrides Function GetScope() As IEnumerable(Of String)

            Return {Scope}

        End Function

#End Region

#End Region

    End Class

End Namespace

