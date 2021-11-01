Namespace Database.Entities

    <Table("MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME")>
    Public Class MediaPlanDetailPackagePlacementName
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanDetailID
            MediaPlanID
            RowIndex
            PlacementName
            CreatedByUserCode
            CreatedDate
            MediaPlan
            MediaPlanDetail
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_PLAN_DTL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanDetailID() As Integer
        <Required>
        <Column("MEDIA_PLAN_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaPlanID() As Integer
        <Required>
        <Column("ROW_INDEX")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property RowIndex() As Integer
        <Required>
        <MaxLength(255)>
        <Column("PLACEMENT_NAME", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property PlacementName() As String
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property CreatedDate() As Date

        Public Overridable Property MediaPlan As Database.Entities.MediaPlan
        Public Overridable Property MediaPlanDetail As Database.Entities.MediaPlanDetail

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
