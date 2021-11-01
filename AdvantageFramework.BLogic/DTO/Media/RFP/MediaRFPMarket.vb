Namespace DTO.Media.RFP

    Public Class MediaRFPMarket
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaRFPHeaderID
            SourceMarketName
            MarketCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaRFPHeaderID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property SourceMarketName As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
        Public Property MarketCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property Modified As Boolean

#End Region

#Region " Methods "

        Public Sub New()


        End Sub

#End Region

    End Class

End Namespace
