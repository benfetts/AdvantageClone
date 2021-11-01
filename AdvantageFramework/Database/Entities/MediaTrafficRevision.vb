Namespace Database.Entities

    <Table("MEDIA_TRAFFIC_REVISION")>
    Public Class MediaTrafficRevision
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaTrafficID
            RevisionNumber
            StartDate
            EndDate
            Description
            CreatedByUserCode
            CreatedDate
            ModifiedByUserCode
            ModifiedDate
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_REVISION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_TRAFFIC_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaTrafficID() As Integer
        <Required>
        <Column("REVISION_NUMBER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property RevisionNumber() As Integer
        <Required>
        <Column("START_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property StartDate() As Date
        <Required>
        <Column("END_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property EndDate() As Date
        <Required>
        <MaxLength(80)>
        <Column("DESCRIPTION", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Description() As String
        <Required>
        <MaxLength(100)>
        <Column("USER_CREATED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedByUserCode() As String
        <Required>
        <Column("CREATED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreatedDate() As Date
        <MaxLength(100)>
        <Column("USER_MODIFIED", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedByUserCode() As String
        <Column("MODIFIED_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ModifiedDate() As Nullable(Of Date)

        Public Overridable Property MediaTrafficVendors As ICollection(Of AdvantageFramework.Database.Entities.MediaTrafficVendor)

        Public Overridable Property MediaTrafficCreativeGroups As ICollection(Of AdvantageFramework.Database.Entities.MediaTrafficCreativeGroup)

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
