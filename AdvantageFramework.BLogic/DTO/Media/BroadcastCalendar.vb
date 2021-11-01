Namespace DTO.Media

    Public Class BroadcastCalendar
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property BroadcastYear As Integer
        Public Property BroadcastMonth As Integer
        Public Property BroadcastWeekStart As Date
        Public Property BroadcastWeekEnd As Date
        Public Property MonthAbbrevisation As String
        Public Property WeekNumber As Integer
        Public Property MonthYear As String
        Public Property YearMonth As String

#End Region

#Region " Methods "

        Public Sub New()



        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.YearMonth

        End Function

#End Region

    End Class

End Namespace
