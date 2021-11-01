Namespace DTO.Media.MediaBroadcastWorksheet

	Public Class NielsenRadioMarket
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

		Public Enum Properties
			MarketCode
			MarketDescription
			NielsenRadioCode
			NielsenBlackRadioCode
            NielsenHispanicRadioCode
            EastlanRadioCode
            EastlanBlackRadioCode
            EastlanHispanicRadioCode
            IsNielsenPMM
            IsEastlanPMM
            HasNielsenBlackMarketBooks
            HasNielsenHispanicMarketBooks
            HasEastlanBlackMarketBooks
            HasEastlanHispanicMarketBooks
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

		<Required>
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property MarketCode() As String
		<Required>
		<MaxLength(40)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property MarketDescription() As String
		<Required>
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
		Public Property NielsenRadioCode As String
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
		Public Property NielsenBlackRadioCode As String
		<MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property NielsenHispanicRadioCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EastlanRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EastlanBlackRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property EastlanHispanicRadioCode As Nullable(Of Short)
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsNielsenPMM As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IsEastlanPMM As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property HasNielsenBlackMarketBooks As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property HasNielsenHispanicMarketBooks As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property HasEastlanBlackMarketBooks As Boolean
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property HasEastlanHispanicMarketBooks As Boolean

#End Region

#Region " Methods "

        Public Sub New()

			Me.MarketCode = String.Empty
			Me.MarketDescription = String.Empty
			Me.NielsenRadioCode = String.Empty
			Me.NielsenBlackRadioCode = String.Empty
            Me.NielsenHispanicRadioCode = String.Empty
            Me.EastlanRadioCode = Nothing
            Me.EastlanBlackRadioCode = Nothing
            Me.EastlanHispanicRadioCode = Nothing
            Me.IsNielsenPMM = False
            Me.IsEastlanPMM = False
            Me.HasNielsenBlackMarketBooks = False
            Me.HasNielsenHispanicMarketBooks = False
            Me.HasEastlanBlackMarketBooks = False
            Me.HasEastlanHispanicMarketBooks = False

        End Sub
        'Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

        '    Me.MarketCode = Market.Code
        '    Me.MarketDescription = Market.Description
        '    Me.NielsenRadioCode = Market.NielsenRadioCode
        '    Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
        '    Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
        '    Me.EastlanRadioCode = Market.EastlanRadioCode
        '    Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
        '    Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
        '    Me.IsPMM = False
        '    Me.HasBlackMarketBooks = False
        '    Me.HasHispanicMarketBooks = False

        'End Sub
        Public Sub New(Market As AdvantageFramework.DTO.Market)

            Me.MarketCode = Market.Code
            Me.MarketDescription = Market.Description
            Me.NielsenRadioCode = Market.NielsenRadioCode
            Me.NielsenBlackRadioCode = Market.NielsenBlackRadioCode
            Me.NielsenHispanicRadioCode = Market.NielsenHispanicRadioCode
            Me.EastlanRadioCode = Market.EastlanRadioCode
            Me.EastlanBlackRadioCode = Market.EastlanBlackRadioCode
            Me.EastlanHispanicRadioCode = Market.EastlanHispanicRadioCode
            Me.IsNielsenPMM = False
            Me.IsEastlanPMM = False
            Me.HasNielsenBlackMarketBooks = False
            Me.HasNielsenHispanicMarketBooks = False
            Me.HasEastlanBlackMarketBooks = False
            Me.HasEastlanHispanicMarketBooks = False

        End Sub
        Public Overrides Function ToString() As String

			ToString = Me.MarketCode

		End Function

#End Region

	End Class

End Namespace
