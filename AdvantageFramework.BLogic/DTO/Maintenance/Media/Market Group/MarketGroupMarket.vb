Namespace DTO.Maintenance.Media.MarketGroup

    Public Class MarketGroupMarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MarketGroupID
            MarketCode
            Order
            StateProvince
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MarketGroupID() As Integer
        <Required>
        <MaxLength(10)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Market() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property Order() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property StateProvince() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.MarketGroupID = 0
            Me.MarketCode = String.Empty
            Me.Market = String.Empty
            Me.Order = 0
            Me.StateProvince = String.Empty

        End Sub
        Public Sub New(MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket)

            Me.ID = MarketGroupMarket.ID
            Me.MarketGroupID = MarketGroupMarket.MarketGroupID
            Me.MarketCode = MarketGroupMarket.MarketCode
            Me.Market = MarketGroupMarket.Market.Description
            Me.Order = MarketGroupMarket.Order

            If MarketGroupMarket.Market.State IsNot Nothing Then

                Me.StateProvince = MarketGroupMarket.Market.State.StateName

            Else

                Me.StateProvince = String.Empty

            End If

        End Sub
        Public Sub SaveToEntity(ByRef MarketGroupMarket As AdvantageFramework.Database.Entities.MarketGroupMarket)

            MarketGroupMarket.MarketGroupID = Me.MarketGroupID
            MarketGroupMarket.MarketCode = Me.MarketCode
            MarketGroupMarket.Order = Me.Order

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString & " - " & Me.MarketCode

        End Function

#End Region

    End Class

End Namespace
