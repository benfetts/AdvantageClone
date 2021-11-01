Namespace Database.Entities

    <Table("EMP_TIME_STAGING_IDS")>
    Public Class EmployeeTimeStagingIDs
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            OutlookID
            GoogleID
            CalendarID

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ET_ID_STAGING_ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property ID() As Integer
        <MaxLength(500)>
        <Column("OUTLOOK_ID", TypeName:="varchar")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property OutlookID() As String
        <Column("GOOGLE_ID", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property GoogleID() As String
        <Column("CALENDAR_ID", TypeName:="varchar(MAX)")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=False, DisplayFormat:="")>
        Public Property CalendarID() As String

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.ID

        End Function

#End Region

    End Class

End Namespace
