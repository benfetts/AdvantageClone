Namespace DTO.Media.RFP

    Public Class MediaRFPMarketCrossReference
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            SourceMarketCode
            MarketCode
            MarketDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True)>
        <MaxLength(50)>
        Public Property SourceMarketCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.MarketCode)>
        Public Property MarketCode As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketDescription As String

#End Region

#Region " Methods "

        Public Sub New()


        End Sub
        Public Sub New(MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference)

            Me.ID = MediaRFPMarketCrossReference.ID
            Me.SourceMarketCode = MediaRFPMarketCrossReference.SourceMarketCode
            Me.MarketCode = MediaRFPMarketCrossReference.MarketCode
            Me.MarketDescription = MediaRFPMarketCrossReference.Market.Description

        End Sub
        Public Sub SaveToEntity(ByRef MediaRFPMarketCrossReference As AdvantageFramework.Database.Entities.MediaRFPMarketCrossReference)

            MediaRFPMarketCrossReference.ID = Me.ID
            MediaRFPMarketCrossReference.SourceMarketCode = Me.SourceMarketCode
            MediaRFPMarketCrossReference.MarketCode = Me.MarketCode

        End Sub

#End Region

    End Class

End Namespace
