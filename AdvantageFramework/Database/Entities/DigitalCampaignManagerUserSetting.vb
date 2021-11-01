Namespace Database.Entities

    <Table("DIGITAL_CAMPAIGN_MGR_USER_SETTING")>
    Public Class DigitalCampaignManagerUserSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            UserCode
            IncludeInternet
            IncludeMagazine
            IncludeNewspaper
            IncludeOutOfHome
            IncludeRadio
            IncludeTV
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity)>
        <Required>
        <Column("DIGITAL_CAMPAIGN_MGR_USER_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(100)>
        <Column("USER_CODE", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property UserCode() As String
        <Required>
        <Column("INCLUDE_INTERNET")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeInternet() As Boolean
        <Required>
        <Column("INCLUDE_MAGAZINE")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeMagazine As Boolean
        <Required>
        <Column("INCLUDE_NEWSPAPER")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeNewspaper As Boolean
        <Required>
        <Column("INCLUDE_OUTOFHOME")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeOutOfHome As Boolean
        <Required>
        <Column("INCLUDE_RADIO")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeRadio As Boolean
        <Required>
        <Column("INCLUDE_TV")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property IncludeTV As Boolean

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
