Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class Market
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            MarketCode
            MarketName
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property MarketName() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
