Namespace ViewModels.FinanceAndAccounting.Exports

    Public Class VATExportViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property PostPeriods As Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)
        Public Property CurrencyCodes As Generic.List(Of AdvantageFramework.Database.Entities.CurrencyCode)

        Public Property PostPeriodCodeStart As String
        Public Property PostPeriodCodeEnd As String
        Public Property AgencyVATNumber As String
        Public Property CurrencyCode As String
        Public Property OutputFolder As String

        Public Property IsAgencyASP As Boolean
        Public Property AgencyImportPath As String

        Public Property VATExportRows As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)

#End Region

#Region " Methods "

        Public Sub New()

            PostPeriods = New Generic.List(Of AdvantageFramework.Database.Entities.PostPeriod)

            CurrencyCodes = New Generic.List(Of AdvantageFramework.Database.Entities.CurrencyCode)

            VATExportRows = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.VATExportRow)

        End Sub

#End Region

    End Class

End Namespace
