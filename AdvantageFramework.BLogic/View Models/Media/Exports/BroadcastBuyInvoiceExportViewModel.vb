Namespace ViewModels.Media.Exports

    Public Class BroadcastBuyInvoiceExportViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SelectedClientCodes As IEnumerable(Of String)
        Public Property BroadcastMonthList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property BroadcastQuarterList As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)
        Public Property ClientList As Generic.List(Of AdvantageFramework.DTO.Client)

        Public Property OutputFolder As String

        Public Property IsAgencyASP As Boolean
        Public Property AgencyImportPath As String
        Public Property StartDate As Date
        Public Property EndDate As Date
        Public Property Year As Integer
        Public Property FilePrefix As String
        Public Property Quarter As String

#End Region

#Region " Methods "

        Public Sub New()

            SelectedClientCodes = Nothing

        End Sub

#End Region

    End Class

End Namespace
