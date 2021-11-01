Namespace Database.Entities

    <Table("MEDIA_CALENDAR")>
    Public Class MediaCalendar
        Inherits BaseClasses.Entity

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            [Date]
            DateName
            Day
            DayOfWeek
            DayOfYear
            WeekDate
            Week
            WeekOfQuarter
            Month
            Quarter
            Year
            BroadcastDay
            BroadcastDayOfWeek
            BroadcastDayOfYear
            BroadcastWeekDate
            BroadcastWeek
            BroadcastWeekOfQuarter
            BroadcastMonth
            BroadcastQuarter
            BroadcastYear
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Key>
        <Required>
        <Column("DATE")>
        Public Property [Date]() As Date
        <Required>
        <Column("DATE_NAME", TypeName:="varchar")>
        Public Property DateName() As String
        <Required>
        <Column("DAY")>
        Public Property Day() As Integer
        <Required>
        <Column("DAY_OF_WEEK")>
        Public Property DayOfWeek() As Integer
        <Required>
        <Column("DAY_OF_YEAR")>
        Public Property DayOfYear() As Integer
        <Required>
        <Column("WEEKDATE")>
        Public Property WeekDate() As Date
        <Required>
        <Column("WEEK")>
        Public Property Week() As Integer
        <Required>
        <Column("WEEK_OF_QUARTER")>
        Public Property WeekOfQuarter() As Integer
        <Required>
        <Column("MONTH")>
        Public Property Month() As Integer
        <Required>
        <Column("QUARTER")>
        Public Property Quarter() As Integer
        <Required>
        <Column("YEAR")>
        Public Property Year() As Integer
        <Required>
        <Column("BROADCAST_DAY")>
        Public Property BroadcastDay() As Integer
        <Required>
        <Column("BROADCAST_DAY_OF_WEEK")>
        Public Property BroadcastDayOfWeek() As Integer
        <Required>
        <Column("BROADCAST_DAY_OF_YEAR")>
        Public Property BroadcastDayOfYear() As Integer
        <Required>
        <Column("BROADCAST_WEEKDATE")>
        Public Property BroadcastWeekDate() As Date
        <Required>
        <Column("BROADCAST_WEEK")>
        Public Property BroadcastWeek() As Integer
        <Required>
        <Column("BROADCAST_WEEK_OF_QUARTER")>
        Public Property BroadcastWeekOfQuarter() As Integer
        <Required>
        <Column("BROADCAST_MONTH")>
        Public Property BroadcastMonth() As Integer
        <Required>
        <Column("BROADCAST_QUARTER")>
        Public Property BroadcastQuarter() As Integer
        <Required>
        <Column("BROADCAST_YEAR")>
        Public Property BroadcastYear() As Integer

#End Region

#Region " Methods "

        Public Overrides Function ToString() As String

            ToString = Me.Date.ToShortDateString & " - " & Me.DateName.ToString

        End Function

#End Region

    End Class

End Namespace
