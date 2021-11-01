Imports AdvantageFramework.Timesheet.Methods
Imports Aspose.Cells

Namespace EmployeeTimesheet.Classes

    Public Class ExcelReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _SecuritySession As AdvantageFramework.Security.Session = Nothing
        Private _CurrentRow As Integer = 0
        Private _CurrentColumn As Integer = 0
        Private _Workbook As Aspose.Cells.Workbook = Nothing
        Private _License As Aspose.Cells.License = Nothing
        Private _Worksheet As Aspose.Cells.Worksheet = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Public "

        Public Function BuildReport(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal DaysToGet As Integer,
                                    ByVal [Sort] As TimesheetSort?, ByRef ErrorMessage As String) As Aspose.Cells.Workbook

            Dim Success As Boolean = False
            Dim Timesheet As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetViewModel = Nothing
            Dim UserSettings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            ErrorMessage = String.Empty
            DaysToGet = 7

            Try
                Using DbContext = New AdvantageFramework.Database.DbContext(_SecuritySession.ConnectionString, _SecuritySession.UserCode)

                    If Sort Is Nothing Then Sort = TimesheetSort.NewestFirst
                    Dim TimesheetController As New AdvantageFramework.Controller.Employee.TimesheetMvcController(_SecuritySession)

                    If TimesheetController IsNot Nothing Then

                        UserSettings = TimesheetController.GetUserSettings(DbContext)

                        If UserSettings Is Nothing Then UserSettings = New ViewModels.Employee.Timesheet.Settings

                        Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, EmployeeCode)

                        If Employee IsNot Nothing Then

                            If Employee.SundayHours IsNot Nothing Then UserSettings.SundayHoursGoal = Employee.SundayHours
                            If Employee.MondayHours IsNot Nothing Then UserSettings.MondayHoursGoal = Employee.MondayHours
                            If Employee.TuesdayHours IsNot Nothing Then UserSettings.TuesdayHoursGoal = Employee.TuesdayHours
                            If Employee.WednesdayHours IsNot Nothing Then UserSettings.WednesdayHoursGoal = Employee.WednesdayHours
                            If Employee.ThursdayHours IsNot Nothing Then UserSettings.ThursdayHoursGoal = Employee.ThursdayHours
                            If Employee.FridayHours IsNot Nothing Then UserSettings.FridayHoursGoal = Employee.FridayHours
                            If Employee.SaturdayHours IsNot Nothing Then UserSettings.SaturdayHoursGoal = Employee.SaturdayHours

                        End If

                        StartDate = FirstDayOfWeek(StartDate, UserSettings, DaysToGet)

                        Timesheet = TimesheetController.GetTimeSheet(DbContext, EmployeeCode, StartDate, DaysToGet, Sort, TimesheetGroupBy.None, UserSettings, ErrorMessage)

                        If Timesheet IsNot Nothing Then

                            'Build header
                            Dim DayText As String = ""
                            Dim DateText As String = ""
                            Dim DayID As String = ""

                            _CurrentRow = 1
                            _CurrentColumn = 1
                            SetBoldTextCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), "Description")

                            Timesheet.UserSettings = UserSettings

                            For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Timesheet.Days

                                _CurrentColumn += 1
                                SetBoldTextCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), Day.Date.ToShortDateString)

                            Next

                            _CurrentColumn += 1
                            SetBoldTextCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), "Total")

                            'Build body
                            For Each Row As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel In Timesheet.Lines

                                Dim Entry As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetEntryViewModel = Nothing
                                Dim Value As Decimal = 0.00
                                Dim ID As String = String.Empty
                                Dim EntryDate As String = String.Empty
                                Dim NullFound As Boolean = False

                                _CurrentRow += 1
                                _CurrentColumn = 1
                                _Worksheet.Cells(_CurrentRow, _CurrentColumn).Value = BuildDescription(Timesheet.UserSettings, Row)

                                For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Timesheet.Days

                                    _CurrentColumn += 1
                                    Value = 0.00
                                    ID = String.Empty
                                    NullFound = False
                                    EntryDate = String.Empty
                                    EntryDate = Day.Date.ToShortDateString

                                    Entry = (From Entity In Day.Entries
                                             Where Entity.Date.ToShortDateString = Day.Date.ToShortDateString And Entity.LineID = Row.LineID
                                             Select Entity).FirstOrDefault

                                    If Entry IsNot Nothing Then

                                        If Entry.Hours IsNot Nothing Then Value = Entry.Hours

                                    End If

                                    SetHoursCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), Value)

                                Next

                                _CurrentColumn += 1
                                SetTotalCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), Value)

                            Next

                            'Build footer
                            _CurrentRow += 1
                            _CurrentColumn = 1
                            SetBoldTextCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), "Total")

                            For Each Day As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetDayViewModel In Timesheet.Days

                                _CurrentColumn += 1
                                SetFooterTotalCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), Day.TotalHours)

                            Next

                            'Grand total
                            _CurrentColumn += 1
                            Dim Total As Decimal = 0.00
                            Total = (From Entity In Timesheet.Days
                                     Select Entity.TotalHours).Sum

                            SetFooterTotalCell(_Worksheet.Cells(_CurrentRow, _CurrentColumn), Total)

                        End If

                    End If

                    _Workbook.FileName = "Timesheet_For_" & Employee.ToString.Replace(" ", "_").Replace(".", "").Replace("'", "") & "Week_Of__" & StartDate.Year.ToString & StartDate.Month.ToString & StartDate.Day.ToString & ".xlsx"

                    ErrorMessage = String.Empty

                End Using

            Catch ex As Exception
                ErrorMessage = AdvantageFramework.StringUtilities.FullErrorToString(ex)
                Success = False
            End Try

            Return _Workbook

        End Function

#End Region

#Region " Private "

        Private Function BuildDescription(ByVal Settings As AdvantageFramework.ViewModels.Employee.Timesheet.Settings,
                                          ByVal Row As AdvantageFramework.ViewModels.Employee.Timesheet.TimesheetLineViewModel) As String

            Dim Desc As New System.Text.StringBuilder

            If Row.JobNumber IsNot Nothing AndAlso Row.JobNumber > 0 Then

                Desc.Append(Row.JobDescription)

                If Settings.ShowJobAndComponentNumber = True Then

                    Desc.Append(" (")
                    Desc.Append(Row.JobNumber.ToString.PadLeft(6, "0"))
                    Desc.Append("/")
                    Desc.Append(Row.JobComponentNumber.ToString.PadLeft(2, "0"))
                    Desc.Append(")")

                End If

                Desc.Append(", ")

                If Settings.ShowComponentName = True AndAlso Row.JobComponentDescription <> Row.JobDescription Then

                    Desc.Append(Row.JobComponentDescription)

                End If

                Desc.Append(", ")

                If Settings.ShowFunctionCategory = True Then

                    Desc.Append(Row.FunctionCategoryDescription)

                End If
                If Settings.ShowAssignment Then

                    If Settings.ShowFunctionCategory = True Then

                        Desc.Append(" | ")
                        Desc.Append(Row.AlertSubject)

                    End If

                End If

                Desc.Append(", ")

                If Settings.ShowClientName = True Then

                    Desc.Append(Row.ClientName)

                    If Settings.ShowDivisionName AndAlso Row.DivisionName <> Row.ClientName Then

                        Desc.Append(" | ")
                        Desc.Append(Row.DivisionName)

                    End If
                    If Settings.ShowDivisionName = True AndAlso Settings.ShowProductName = True AndAlso Row.ProductDescription <> Row.DivisionName Then

                        Desc.Append(" | ")
                        Desc.Append(Row.ProductDescription)

                    End If

                End If

            Else

                Desc.Append(Row.FunctionCategoryDescription)

            End If

            Return Desc.ToString

        End Function
        Private Sub BoldCellStyle(ByRef Cell As Aspose.Cells.Cell)

            Dim Style As Aspose.Cells.Style = Nothing

            Style = Cell.GetStyle
            Style.Font.IsBold = True

            Cell.SetStyle(Style)

        End Sub
        Private Sub SetBoldTextCell(ByRef Cell As Aspose.Cells.Cell, ByVal Value As String)

            Dim Style As Aspose.Cells.Style = Nothing

            Style = Cell.GetStyle
            Style.Font.IsBold = True

            Cell.SetStyle(Style)
            Cell.Value = Value

        End Sub
        Private Sub SetHoursCell(ByRef Cell As Aspose.Cells.Cell, ByVal Value As Decimal)

            Dim Style As Aspose.Cells.Style = Nothing

            Style = Cell.GetStyle
            Style.Number = 2

            Cell.SetStyle(Style)
            Cell.Value = Value

        End Sub
        Private Sub SetTotalCell(ByRef Cell As Aspose.Cells.Cell, ByVal Value As Decimal)

            Dim Style As Aspose.Cells.Style = Nothing

            Style = Cell.GetStyle
            Style.Number = 2
            Style.Font.IsBold = True

            Cell.SetStyle(Style)
            Cell.Value = Value

        End Sub
        Private Sub SetFooterTotalCell(ByRef Cell As Aspose.Cells.Cell, ByVal Value As Decimal)

            Dim Style As Aspose.Cells.Style = Nothing

            Style = Cell.GetStyle
            Style.Number = 2
            Style.Font.IsBold = True
            Style.SetBorder(BorderType.TopBorder, CellBorderType.Thin, System.Drawing.Color.Black)
            Cell.SetStyle(Style)
            Cell.Value = Value

        End Sub

#End Region

        Public Sub New(ByRef SecuritySession As AdvantageFramework.Security.Session)

            Me._SecuritySession = SecuritySession

            Dim Style As Aspose.Cells.Style = Nothing
            Style = New Aspose.Cells.Style
            Style.Font.Name = "Calibri"
            Style.Font.Size = 11

            _CurrentRow = -1
            _CurrentColumn = 0

            _License = New Aspose.Cells.License
            _License.SetLicense("Aspose.Total.lic")

            _Workbook = New Aspose.Cells.Workbook
            _Workbook.Worksheets.Clear()
            _Workbook.Worksheets.Add(Aspose.Cells.SheetType.Worksheet)

            _Worksheet = _Workbook.Worksheets(0)
            _Worksheet.Cells.ApplyStyle(Style, New Aspose.Cells.StyleFlag With {.Font = True})
            _Worksheet.Zoom = 100
            _Worksheet.IsGridlinesVisible = True
            _Worksheet.AutoFitColumns()

        End Sub

#End Region

    End Class

End Namespace
