Namespace DTO.Maintenance.Media.PlanEstimateTemplate

    Public Class OutdoorType
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            Selected
            OutOfHomeTypeCode
            OutOfHomeTypeDescription
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Selected() As Boolean
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OutOfHomeTypeCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property OutOfHomeTypeDescription() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace
