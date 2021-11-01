Public Class DesktopCardDayNavigator
    Inherits System.Web.UI.UserControl

    Public Event GoToday()
    Public Event GoNext()
    Public Event GoPrevious()

    Public Property [Date] As Nullable(Of Date)
        Get
            If Session("DesktopCardDayNavigator_Date") Is Nothing Then
                Return cEmployee.TimeZoneToday
            Else
                Return CDate(Session("DesktopCardDayNavigator_Date"))
            End If
        End Get
        Set(value As Nullable(Of Date))
            Session("DesktopCardDayNavigator_Date") = CDate(value).ToShortDateString()
        End Set
    End Property

    Private Sub ImageButtonToday_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonToday.Click

        [Date] = cEmployee.TimeZoneToday
        DisplayDate()
        RaiseEvent GoToday()

    End Sub
    Private Sub ImageButtonPrevious_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonPrevious.Click

        [Date] = DateAdd(DateInterval.Day, -1, CDate([Date]))
        DisplayDate()
        RaiseEvent GoPrevious()

    End Sub
    Private Sub ImageButtonNext_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonNext.Click

        [Date] = DateAdd(DateInterval.Day, 1, CDate([Date]))
        DisplayDate()
        RaiseEvent GoNext()

    End Sub

    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        DisplayDate()

    End Sub
    Private Sub DisplayDate()

        Me.LinkButtonDate.Text = CDate([Date]).DayOfWeek.ToString() & ", " & CDate([Date]).ToShortDateString()
        Me.LinkButtonDate.ToolTip = CDate([Date]).ToLongDateString()

    End Sub

    Public Event DateClicked()
    Private Sub LinkButtonDate_Click(sender As Object, e As EventArgs) Handles LinkButtonDate.Click

        RaiseEvent DateClicked()

    End Sub

End Class