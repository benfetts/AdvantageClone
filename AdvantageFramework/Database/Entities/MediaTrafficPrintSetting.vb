Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_TRAFFIC_PRINT_DEF")>
    Public Class MediaTrafficPrintSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            MediaType
            LocationID
            IncludeGuidelines
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_TRAFFIC_PRINT_DEF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID As Integer
        <Required>
        <Column("USER_ID", TypeName:="varchar")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode As String
        <Required>
        <Column("MEDIA_TYPE", TypeName:="varchar")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaType As String
        <MaxLength(6)>
        <Column("LOCATION_ID", TypeName:="varchar")>
        Public Property LocationID As String
        <Required>
        <Column("INCLUDE_GUIDELINES")>
        Public Property IncludeGuidelines As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode & " " & Me.MediaType

        End Function

#End Region

    End Class

End Namespace