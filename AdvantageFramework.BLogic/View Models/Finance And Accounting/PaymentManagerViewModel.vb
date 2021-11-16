Namespace ViewModels.FinanceAndAccounting

    Public Class PaymentManagerViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BankCode As String
        Public Property CheckRunID As String

        Public Property Bank As AdvantageFramework.Database.Entities.Bank

        Public Property AgencyImportPath As String
        Public Property BankExportFile As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.BankCode = String.Empty
            Me.CheckRunID = String.Empty

            Me.Bank = Nothing

            Me.AgencyImportPath = String.Empty
            Me.BankExportFile = String.Empty

        End Sub

#End Region

    End Class

End Namespace
