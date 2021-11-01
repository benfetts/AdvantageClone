Namespace DTO

	Public Class Market
		Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Code
            Description
            IsInactive
            NielsenTVCode
            NielsenTVDMACode
            NielsenRadioCode
            NielsenBlackRadioCode
            NielsenHispanicRadioCode
            EastlanRadioCode
            EastlanBlackRadioCode
            EastlanHispanicRadioCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
		<MaxLength(10)>
		Public Property Code() As String
		<Required>
		<MaxLength(40)>
		Public Property Description() As String
		Public Property IsInactive() As Boolean
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property NielsenTVCode As String
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True, CustomColumnCaption:="Nielsen TV DMA Code")>
		Public Property NielsenTVDMACode As String
		<MaxLength(3)>
		<AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
		Public Property NielsenRadioCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenBlackRadioCode As String
        <MaxLength(3)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property NielsenHispanicRadioCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EastlanRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EastlanBlackRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property EastlanHispanicRadioCode As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ComscoreMarketNumber As Nullable(Of Short)
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", IsReadOnlyColumn:=True)>
        Public Property ComscoreNewMarketNumber As Nullable(Of Short)

#End Region

#Region " Methods "

        Public Sub New()

			Me.Code = String.Empty
			Me.Description = String.Empty
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

			Me.Code = Market.Code
			Me.Description = Market.Description
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
		Public Overrides Function ToString() As String

			ToString = Me.Code & " - " & Me.Description

		End Function

#End Region

	End Class

End Namespace
