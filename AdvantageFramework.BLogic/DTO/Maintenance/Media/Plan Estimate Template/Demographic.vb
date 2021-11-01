Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class Demographic
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            MediaDemoID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(ShowColumnInGrid:=False)>
        Public Property MediaDemoID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Demographic() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
