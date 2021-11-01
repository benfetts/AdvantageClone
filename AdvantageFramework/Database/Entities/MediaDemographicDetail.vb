Namespace Database.Entities

    <Table("MEDIA_DEMO_DETAIL")>
    Public Class MediaDemographicDetail
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            MediaDemographicID
            NielsenDemographicID
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_DEMO_DETAIL_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <Required>
        <Column("MEDIA_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaDemographicID() As Integer
        <Required>
        <Column("NIELSEN_DEMO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property NielsenDemographicID() As Integer

        <ForeignKey("MediaDemographicID")>
        Public Overridable Property MediaDemographic As Database.Entities.MediaDemographic

        <ForeignKey("NielsenDemographicID")>
        Public Overridable Property NielsenDemographic As Database.Entities.NielsenDemographic

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
