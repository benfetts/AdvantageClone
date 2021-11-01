Namespace Quickbooks.Classes

    Public Class Account

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Id
            Name
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Id As String
        Public Property Name As String

#End Region

#Region " Methods "

        Public Sub New(Account As Intuit.Ipp.Data.Account)

            Me.Id = Account.Id
            Me.Name = Account.Name

        End Sub

#End Region

    End Class

End Namespace
