Namespace DTO.Media.ComscorePrecache

    Public Class Station

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsSelected
            Number
            CallLetters
            Name
            IsCable
            MarketStationID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsSelected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Number() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property CallLetters() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property Name() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsCable() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketStationID As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
