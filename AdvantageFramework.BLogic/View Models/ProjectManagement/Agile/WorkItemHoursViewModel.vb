Namespace ViewModels.ProjectManagement.Agile

    <Serializable()>
    Public Class WorkItemHoursViewModel

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties

            ID
            SprintEmployeeID
            EmployeeCode
            FullName
            Picture
            WeekNumber
            WeekStart
            WeekEnd
            HoursAssigned
            HoursAvailableForWeek
            HoursAssignedForWeek
            HoursBalance
            SprintDetailID
            AlertID
            Title

        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ID As Integer?
        Public Property AlertID As Integer?
        Public Property SprintDetailID As Integer?
        Public Property SprintEmployeeID As Integer?
        Public Property EmployeeCode As String
        Public Property FullName As String
        Public Property WeekNumber As Integer?
        Public Property HoursPostedPrior As Decimal? = 0.0
        Public Property HoursLeft As Decimal? = 0.0
        Public Property WeekStart As DateTime?
        Public Property WeekEnd As DateTime?
        Public Property HoursAssigned As Decimal? = 0.0
        Public Property HoursAvailableForWeek As Decimal? = 0.0
        Public Property HoursAssignedForWeek As Decimal? = 0.0
        Public Property HoursBalance As Decimal? = 0.0
        Public Property HoursPostedThis As Decimal? = 0.0
        Public Property Complete As Short? = 1

        Public ReadOnly Property sWeekStart
            Get
                Try
                    Return CDate(WeekStart).ToString("MM/dd/yyyy")
                Catch ex As Exception
                    Return String.Empty
                End Try
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

        End Sub

#End Region

    End Class

End Namespace
