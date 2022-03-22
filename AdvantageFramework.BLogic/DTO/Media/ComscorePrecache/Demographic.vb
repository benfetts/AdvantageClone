Namespace DTO.Media.ComscorePrecache

    Public Class Demographic

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            IsSelected
            Description
            ComscoreDemoNumber
            MarketDemoID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="")>
        Public Property IsSelected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Description() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property ComscoreDemoNumber() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MarketDemoID() As Nullable(Of Integer)

#End Region

#Region " Methods "



#End Region

    End Class

End Namespace
