Namespace DTO.Media.MediaBroadcastWorksheet

    Public Class WorksheetMarketSelection
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            Code
            Description
            IsCable
            MediaBroadcastWorksheetMarketRadioEthnicityID
            IsInactive
            NielsenTVCode
            NielsenTVDMACode
            NielsenRadioCode
            NielsenBlackRadioCode
            NielsenHispanicRadioCode
            EastlanRadioCode
            EastlanBlackRadioCode
            EastlanHispanicRadioCode
            ComscoreMarketNumber
            ComscoreNewMarketNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property IsCable As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, CustomColumnCaption:="Ethnicity")>
        Public Property MediaBroadcastWorksheetMarketRadioEthnicityID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property IsInactive() As Boolean
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property NielsenTVCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False, CustomColumnCaption:="Nielsen TV DMA Code")>
        Public Property NielsenTVDMACode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property NielsenRadioCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property NielsenBlackRadioCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property NielsenHispanicRadioCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property EastlanRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property EastlanBlackRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property EastlanHispanicRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ComscoreMarketNumber As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ComscoreNewMarketNumber As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

            Me.Selected = False
            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.IsCable = False
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = 1
            Me.IsInactive = False
            Me.NielsenTVCode = String.Empty
            Me.NielsenTVDMACode = String.Empty
            Me.NielsenRadioCode = String.Empty
            Me.NielsenBlackRadioCode = String.Empty
            Me.NielsenHispanicRadioCode = String.Empty
            Me.EastlanRadioCode = Nothing
            Me.EastlanBlackRadioCode = Nothing
            Me.EastlanHispanicRadioCode = Nothing
            Me.ComscoreMarketNumber = Nothing
            Me.ComscoreNewMarketNumber = Nothing

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.Selected = False
            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsCable = False
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = 1
            Me.IsInactive = If(Market.IsInactive.GetValueOrDefault(0) = 0, False, True)
            Me.NielsenTVCode = Market.NielsenTVCode
            Me.NielsenTVDMACode = Market.NielsenTVDMACode
            Me.NielsenRadioCode = Market.NielsenRadioCode
            Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
            Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
            Me.EastlanRadioCode = Market.EastlanRadioCode
            Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
            Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
            Me.ComscoreMarketNumber = Market.ComscoreNewMarketNumber
            Me.ComscoreNewMarketNumber = Market.ComscoreNewMarketNumber

        End Sub
        Public Sub New(Market As AdvantageFramework.DTO.Market)

            Me.Selected = False
            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsCable = False
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = 1
            Me.IsInactive = Market.IsInactive
            Me.NielsenTVCode = Market.NielsenTVCode
            Me.NielsenTVDMACode = Market.NielsenTVDMACode
            Me.NielsenRadioCode = Market.NielsenRadioCode
            Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
            Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
            Me.EastlanRadioCode = Market.EastlanRadioCode
            Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
            Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
            Me.ComscoreMarketNumber = Market.ComscoreNewMarketNumber
            Me.ComscoreNewMarketNumber = Market.ComscoreNewMarketNumber

        End Sub
        Public Sub New(Market As AdvantageFramework.DTO.Market, IsCable As Boolean)

            Me.Selected = False
            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsCable = IsCable
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = 1
            Me.IsInactive = Market.IsInactive
            Me.NielsenTVCode = Market.NielsenTVCode
            Me.NielsenTVDMACode = Market.NielsenTVDMACode
            Me.NielsenRadioCode = Market.NielsenRadioCode
            Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
            Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
            Me.EastlanRadioCode = Market.EastlanRadioCode
            Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
            Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
            Me.ComscoreMarketNumber = Market.ComscoreNewMarketNumber
            Me.ComscoreNewMarketNumber = Market.ComscoreNewMarketNumber

        End Sub
        Public Sub New(Market As AdvantageFramework.DTO.Market, RadioEthnicity As AdvantageFramework.DTO.Media.MediaBroadcastWorksheet.RadioEthnicities)

            Me.Selected = False
            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsCable = IsCable
            Me.MediaBroadcastWorksheetMarketRadioEthnicityID = CInt(RadioEthnicity)
            Me.IsInactive = Market.IsInactive
            Me.NielsenTVCode = Market.NielsenTVCode
            Me.NielsenTVDMACode = Market.NielsenTVDMACode
            Me.NielsenRadioCode = Market.NielsenRadioCode
            Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
            Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
            Me.EastlanRadioCode = Market.EastlanRadioCode
            Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
            Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
            Me.ComscoreMarketNumber = Market.ComscoreNewMarketNumber
            Me.ComscoreNewMarketNumber = Market.ComscoreNewMarketNumber

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
