Namespace Database.Entities

    <System.ComponentModel.DataAnnotations.Schema.Table("MEDIA_RFP_PRINT_DEF")>
    Public Class MediaRFPPrintSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            MediaType
            IncludeCPP
            IncludeGRP
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("MEDIA_RFP_PRINT_DEF_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID As Integer
        <Required>
        <Column("USER_ID")>
        <MaxLength(100)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode As String
        <Required>
        <Column("MEDIA_TYPE")>
        <MaxLength(1)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property MediaType As String
        <Required>
        <Column("INCLUDE_CPP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IncludeCPP As Short
        <Required>
        <Column("INCLUDE_GRP")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property IncludeGRP As Short

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.UserCode & " " & Me.MediaType

        End Function

#End Region

    End Class

End Namespace