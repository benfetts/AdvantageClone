Namespace DTO.Maintenance.Media.MarketGroup

    Public Class Market
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            [Select]
            Code
            Description
            IsInactive
            CountryID
            Country
            StateID
            State
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property [Select]() As Boolean
        <Required>
        <MaxLength(10)>
        Public Property Code() As String
        <Required>
        <MaxLength(40)>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property IsInactive() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="Country")>
        Public Property CountryID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Country() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False, CustomColumnCaption:="State/Province")>
        Public Property StateID As Nullable(Of Integer)
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="State/Province")>
        Public Property State() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.Select = False
            Me.Code = String.Empty
            Me.Description = String.Empty
            Me.IsInactive = False
            Me.CountryID = Nothing
            Me.Country = String.Empty
            Me.StateID = Nothing
            Me.State = String.Empty

        End Sub
        Public Sub New(Market As AdvantageFramework.Database.Entities.Market)

            Me.Select = False
            Me.Code = Market.Code
            Me.Description = Market.Description
            Me.IsInactive = If(Market.IsInactive.GetValueOrDefault(0) = 0, False, True)
            Me.CountryID = Market.CountryID
            Me.Country = If(Market.Country IsNot Nothing, Market.Country.Name, String.Empty)
            Me.StateID = Market.StateID
            Me.State = If(Market.State IsNot Nothing, Market.State.StateName, String.Empty)

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.Code & " - " & Me.Description

        End Function

#End Region

    End Class

End Namespace
