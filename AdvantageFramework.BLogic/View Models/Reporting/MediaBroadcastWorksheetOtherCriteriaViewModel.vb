Namespace ViewModels.Reporting

    Public Class MediaBroadcastWorksheetOtherCriteriaViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property Reports As Generic.List(Of EnumUtilities.Attributes.EnumObjectAttribute)

        Public Property MediaBroadcastWorksheetStartDate As Date
        Public Property MediaBroadcastWorksheetEndDate As Date

        Public Property WorksheetMarkets As Generic.List(Of DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

        Public Property AllWorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

        Public Property WorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor)

        Public Property HasPrimaryMediaDemographic As Boolean
        Public Property MediaBroadcastWorksheetDateTypeID As Integer

#End Region

#Region " Methods "

        Public Sub New()

            Me.WorksheetMarkets = New List(Of DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

            Me.AllWorksheetMarketVendors = New List(Of DTO.Reporting.WorksheetMarketVendor)

            Me.WorksheetMarketVendors = New List(Of DTO.Reporting.WorksheetMarketVendor)

        End Sub

#End Region

    End Class

End Namespace