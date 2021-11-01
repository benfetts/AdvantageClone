Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketGoalsCopy
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaBroadcastWorksheetMarketID
            Selected
            MarketCode
            MarketDescription
            IsCable
            MediaBroadcastWorksheetMarketRadioEthnicityID
            MarketNielsenTVCode
            MarketNielsenTVDMACode
            MarketNielsenRadioCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaBroadcastWorksheetMarketID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Selected() As Boolean
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketDescription() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property IsCable() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", CustomColumnCaption:="Ethnicity")>
        Public Property MediaBroadcastWorksheetMarketRadioEthnicityID() As Nullable(Of Integer)
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketNielsenTVCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Nielsen TV DMA Code")>
        Public Property MarketNielsenTVDMACode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property MarketNielsenRadioCode As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.MediaBroadcastWorksheetMarketID = 0
            Me.Selected = False
            Me.MarketCode = String.Empty
            Me.MarketDescription = String.Empty
            Me.IsCable = False
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = Nothing
            Me.MarketNielsenTVCode = String.Empty
            Me.MarketNielsenTVDMACode = String.Empty
            Me.MarketNielsenRadioCode = String.Empty

        End Sub
        Public Sub New(MediaBroadcastWorksheetMarket As AdvantageFramework.Database.Entities.MediaBroadcastWorksheetMarket)

            Me.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarket.ID
            Me.Selected = False
            Me.MarketCode = MediaBroadcastWorksheetMarket.MarketCode
            Me.MarketDescription = MediaBroadcastWorksheetMarket.Market.Description
            Me.IsCable = MediaBroadcastWorksheetMarket.IsCable
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = MediaBroadcastWorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID
            Me.MarketNielsenTVCode = MediaBroadcastWorksheetMarket.Market.NielsenTVCode
            Me.MarketNielsenTVDMACode = MediaBroadcastWorksheetMarket.Market.NielsenTVDMACode
            Me.MarketNielsenRadioCode = MediaBroadcastWorksheetMarket.Market.NielsenRadioCode

        End Sub
        Public Sub New(WorksheetMarket As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.WorksheetMarket)

            Me.MediaBroadcastWorksheetMarketID = WorksheetMarket.ID
            Me.Selected = False
            Me.MarketCode = WorksheetMarket.MarketCode
            Me.MarketDescription = WorksheetMarket.MarketDescription
            Me.IsCable = WorksheetMarket.IsCable
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = WorksheetMarket.MediaBroadcastWorksheetMarketRadioEthnicityID
            Me.MarketNielsenTVCode = WorksheetMarket.MarketNielsenTVCode
            Me.MarketNielsenTVDMACode = WorksheetMarket.MarketNielsenTVDMACode
            Me.MarketNielsenRadioCode = WorksheetMarket.MarketNielsenRadioCode

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaBroadcastWorksheetMarketID.ToString

        End Function

#End Region

    End Class

End Namespace
