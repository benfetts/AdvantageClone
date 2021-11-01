Namespace Database.Entities

    <Table("LOCATION_LOGO")>
    Public Class LocationLogo
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            LocationID
            LocationLogoTypeID
            Image
            Thumbnail
            IsActive
            CreateDate
            UserCode
            LocationLogoType
            Location
        End Enum


#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("LOCATION_LOGO_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Required>
        <Column("LOCATION_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LocationID() As String

        <Required>
        <Column("LOCATION_LOGO_TYPE_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property LocationLogoTypeID() As Integer

        <Required>
        <Column("IMAGE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Image() As Byte()

        <Column("THUMBNAIL")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property Thumbnail() As Byte()

        <Required>
        <Column("IS_ACTIVE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsActive() As Boolean

        <Required>
        <Column("CREATE_DATE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property CreateDate() As Date

        <Required>
        <Column("USER_CODE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode As String

        Public Overridable Property LocationLogoType As Database.Entities.LocationLogoType
        Public Overridable Property Location As Database.Entities.Location

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
