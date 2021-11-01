Namespace ViewModels.Media.MediaBroadcastWorksheet

    Public Class MediaBroadcastWorksheetMarketBuyerViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property FindBuyerEmployeeCode As String
        Public Property ReplaceBuyerEmployeeCode As String
        Public Property MediaBuyerEmployeeCodes As Generic.List(Of AdvantageFramework.DTO.Media.BuyerEmployee)
        Public Property MissingMediaBuyerEmployeeCodes As Generic.List(Of AdvantageFramework.DTO.Media.BuyerEmployee)
#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBuyerEmployeeCodes = New Generic.List(Of DTO.Media.BuyerEmployee)
            Me.MissingMediaBuyerEmployeeCodes = New Generic.List(Of AdvantageFramework.DTO.Media.BuyerEmployee)

        End Sub

#End Region

    End Class

End Namespace
