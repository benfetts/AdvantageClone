Namespace DTO.Media.ComscorePrecache

    Public Class Market

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ComscorePrecacheMarketID
            Code
            Name
            ComscoreNewMarketNumber
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscorePrecacheMarketID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Code() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Name() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreNewMarketNumber() As Short

#End Region

#Region " Methods "

        Public Sub New(ComscorePrecacheMarket As AdvantageFramework.Database.Entities.ComscorePrecacheMarket)

            Me.ComscorePrecacheMarketID = ComscorePrecacheMarket.ID
            Me.Code = ComscorePrecacheMarket.MarketCode
            Me.Name = ComscorePrecacheMarket.Market.Description
            Me.ComscoreNewMarketNumber = ComscorePrecacheMarket.Market.ComscoreNewMarketNumber.Value

        End Sub

#End Region

    End Class

End Namespace
