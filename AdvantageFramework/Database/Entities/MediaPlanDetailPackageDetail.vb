Namespace Database.Entities

    <Table("MEDIA_PLAN_DTL_PACKAGE_DETAIL")>
    Public Class MediaPlanDetailPackageDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaPlanDetailID
            MediaPlanID
            RowIndex
            MediaType
            SizeCode
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
        <Column("MEDIA_PLAN_DTL_PACKAGE_DETAIL_ID")>
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
        <MaxLength(1)>
        <Column("MEDIA_TYPE", Order:=0, TypeName:="varchar")>
        <ForeignKey("AdSize")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property MediaType() As String
        <Required>
        <MaxLength(6)>
        <Column("SIZE_CODE", Order:=1, TypeName:="varchar")>
        <ForeignKey("AdSize")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="", PropertyType:=BaseClasses.PropertyTypes.AdSizeCode, CustomColumnCaption:="Ad Size")>
        Public Property SizeCode() As String
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
        Public Overridable Property AdSize As Database.Entities.AdSize

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
