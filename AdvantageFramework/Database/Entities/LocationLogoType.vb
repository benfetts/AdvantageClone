Namespace Database.Entities

    <Table("LOCATION_LOGO_TYPE")>
    Public Class LocationLogoType
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            Name
            Description
            IsFooter
            IsLandscape
            InchHeight
            InchWidth
            DPI
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("LOCATION_LOGO_TYPE_ID")>
        Public Property ID() As Integer

        <Required>
        <Column("NAME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Name() As String

        <Required>
        <Column("DESCRIPTION")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property Description() As String

        <Required>
        <Column("IS_FOOTER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsFooter() As Boolean

        <Required>
        <Column("IS_LANDSCAPE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IsLandscape() As Boolean

        <Required>
        <Column("INCH_HEIGHT")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InchHeight() As Decimal

        <Required>
        <Column("INCH_WIDTH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property InchWidth() As Decimal

        <Required>
        <Column("DPI")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property DPI() As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
