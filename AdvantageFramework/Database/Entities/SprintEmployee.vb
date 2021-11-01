Namespace Database.Entities

    <Table("SPRINT_EMPLOYEE")>
    Public Class SprintEmployee
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            SprintDetailID
            WeekStart
            WeekEnd
            WeekNumber
            Hours
            AlertID
            EmployeeCode

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("ID")>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="")>
        Public Property ID() As Integer

        <Column("SPRINT_DTL_ID")>
        Public Property SprintDetailID As Integer?

        <Column("WEEK_START")>
        Public Property WeekStart As DateTime?

        <Column("WEEK_END")>
        Public Property WeekEnd As DateTime?

        <Column("WEEK_NUM")>
        Public Property StartWeekNumber As Integer?

        <Column("HOURS")>
        Public Property Hours As Decimal?

        <Column("ALERT_ID")>
        Public Property AlertID As Integer?

        <Column("EMP_CODE")>
        Public Property EmployeeCode As String

#End Region

#Region " Methods "

        Sub New()

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
