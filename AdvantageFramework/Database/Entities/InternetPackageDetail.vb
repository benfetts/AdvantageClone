Namespace Database.Entities

    <Table("INTERNET_PACKAGE_DETAIL")>
    Public Class InternetPackageDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OrderNumber
            LineNumber
            RevisionNumber
            SequenceNumber
            IsActiveRevision
            AdSizeCode
            AdServerID
            AdServerPlacementID
            AdServerCreatedBy
            AdServerCreatedDateTime
            AdServerLastModifiedBy
            AdServerLastModifiedByDateTime
            PlacementName
            AdditionalAdSizeCodes
            MediaPlanDetailPackagePlacementNameID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("INTERNET_PACKAGE_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="", ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <Column("ORDER_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property OrderNumber() As Integer
        <Required>
        <Column("LINE_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LineNumber() As Short
        <Required>
        <Column("REV_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Short
        <Required>
        <Column("SEQ_NBR")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property SequenceNumber() As Short
        <Required>
        <Column("ACTIVE_REV")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsActiveRevision() As Boolean
        <Required>
        <Column("AD_SIZE_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property AdSizeCode() As String
        <Column("AD_SERVER_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerID() As Nullable(Of Short)
        <Column("AD_SERVER_PLACEMENT_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerPlacementID() As Nullable(Of Long)
        <Column("AD_SERVER_CREATED_BY", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCreatedBy() As String
        <Column("AD_SERVER_CREATED_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerCreatedDateTime() As Nullable(Of Date)
        <Column("AD_SERVER_LAST_MODIFIED_BY", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerLastModifiedBy() As String
        <Column("AD_SERVER_LAST_MODIFIED_DATETIME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdServerLastModifiedByDateTime() As Nullable(Of Date)
        <Column("PLACEMENT_NAME", TypeName:="varchar")>
        <MaxLength(255)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property PlacementName() As String
        <Column("ADDITIONAL_AD_SIZE_CODES", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property AdditionalAdSizeCodes As String
        <Column("MEDIA_PLAN_DTL_PACKAGE_PLACEMENT_NAME_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property MediaPlanDetailPackagePlacementNameID As Nullable(Of Integer)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
