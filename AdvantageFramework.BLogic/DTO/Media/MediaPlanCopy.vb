Imports AdvantageFramework.BaseClasses

Namespace DTO.Media

    Public Class MediaPlanCopy
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            MediaPlanDetailID
            Name
            SalesClassType
            SalesClassCode
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property MediaPlanDetailID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property Name() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property SalesClassType() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, PropertyType:=BaseClasses.Methods.PropertyTypes.SalesClassCode)>
        Public Property SalesClassCode() As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Sub New(MediaPlanDetail As AdvantageFramework.Database.Entities.MediaPlanDetail)

            Me.MediaPlanDetailID = MediaPlanDetail.ID
            Me.Name = MediaPlanDetail.Name
            Me.SalesClassType = MediaPlanDetail.SalesClassType
            Me.SalesClassCode = Nothing

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.MediaPlanDetailID.ToString

        End Function

#End Region

    End Class

End Namespace
