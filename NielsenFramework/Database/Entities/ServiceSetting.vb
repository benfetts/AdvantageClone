Namespace Database.Entities

    <Table("SERVICE_SETTING")>
    Public Class ServiceSetting
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            TVSpotPath
            TVNationalPath
            RadioSpotPath
            TimerMinutes
            NCCDataPath
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedAttribute(ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None)>
        <Required>
        <Column("SERVICE_SETTING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property ID() As Integer
        <Required>
        <MaxLength(2147483647)>
        <Column("TV_SPOT_PATH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TVSpotPath() As String
        <Required>
        <MaxLength(2147483647)>
        <Column("TV_NATIONAL_PATH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TVNationalPath() As String
        <Required>
        <MaxLength(2147483647)>
        <Column("RADIO_SPOT_PATH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property RadioSpotPath() As String
        <Required>
        <Column("TIMER_MINUTES")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property TimerMinutes() As Integer
        <Required>
        <MaxLength(2147483647)>
        <Column("NCC_DATA_PATH")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property NCCDataPath() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
