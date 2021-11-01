Namespace MediaManager.Classes
    Public Class WeekData

        Public Property BeginWeekDate As Date
        Public Property EndWeekDate As Date

        Public Property AirTime As String
        Public Property Programming As String
        Public Property NetworkID As String
        Public Property DaypartID As Nullable(Of Integer)
        Public Property Length As Integer

        Public Property SunDate As Nullable(Of Date)
        Public Property MonDate As Nullable(Of Date)
        Public Property TueDate As Nullable(Of Date)
        Public Property WedDate As Nullable(Of Date)
        Public Property ThrDate As Nullable(Of Date)
        Public Property FriDate As Nullable(Of Date)
        Public Property SatDate As Nullable(Of Date)

        Public Property SunSpots As Integer = 0
        Public Property MonSpots As Integer = 0
        Public Property TueSpots As Integer = 0
        Public Property WedSpots As Integer = 0
        Public Property ThrSpots As Integer = 0
        Public Property FriSpots As Integer = 0
        Public Property SatSpots As Integer = 0

        Public Property SunRate As Decimal
        Public Property MonRate As Decimal
        Public Property TueRate As Decimal
        Public Property WedRate As Decimal
        Public Property ThrRate As Decimal
        Public Property FriRate As Decimal
        Public Property SatRate As Decimal

        Public Property WeekSpots As Integer = 0
        Public Property Rate As Decimal = 0
    End Class
End Namespace

