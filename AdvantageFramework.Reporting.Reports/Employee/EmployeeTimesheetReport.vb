Namespace Employee

    Public Class EmployeeTimesheetReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AgencyName As String = ""
        Private _ExcludeEmployeeSignature As Boolean = False
        Private _Date As String = String.Empty
        Private _WeekOfDate As Date = Nothing
        Private _UseProductCategory As Boolean = False
        Private _SortBy As AdvantageFramework.EmployeeTimesheet.ReportSortByOptions = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property
        Public Property ExcludeEmployeeSignature As Boolean
            Get
                ExcludeEmployeeSignature = _ExcludeEmployeeSignature
            End Get
            Set(value As Boolean)
                _ExcludeEmployeeSignature = value
            End Set
        End Property
        Public Property WeekOfDate As Date
            Get
                WeekOfDate = _WeekOfDate
            End Get
            Set(value As Date)
                _WeekOfDate = value
            End Set
        End Property
        Public Property SortBy As AdvantageFramework.EmployeeTimesheet.ReportSortByOptions
            Get
                SortBy = _SortBy
            End Get
            Set(value As AdvantageFramework.EmployeeTimesheet.ReportSortByOptions)
                _SortBy = value
            End Set
        End Property
        Public ReadOnly Property FirstDayOfWeek As Date
            Get

                If _WeekOfDate.DayOfWeek <> DayOfWeek.Sunday Then

                    FirstDayOfWeek = _WeekOfDate.AddDays(-_WeekOfDate.DayOfWeek)

                Else

                    FirstDayOfWeek = _WeekOfDate

                End If

            End Get
        End Property
        Public ReadOnly Property LastDayOfWeek As Date
            Get

                LastDayOfWeek = Me.FirstDayOfWeek.AddDays(6)

            End Get
        End Property
        Public Property UseProductCategory As Boolean
            Get
                UseProductCategory = _UseProductCategory
            End Get
            Set(value As Boolean)
                _UseProductCategory = value
            End Set
        End Property

#End Region

#Region " Methods "

        Private Function GetCurrentEmployee() As AdvantageFramework.Database.Views.Employee

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Try

                Employee = DirectCast(Me.GetCurrentRow, AdvantageFramework.Database.Views.Employee)

            Catch ex As Exception
                Employee = Nothing
            Finally
                GetCurrentEmployee = Employee
            End Try

        End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub LabelPageHeader_Title_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_Title.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim LabelText As String = Nothing

            Try

                Employee = GetCurrentEmployee()

                If Employee IsNot Nothing Then

                    LabelText = "Timesheet for " & Employee.ToString & " (" & Me.FirstDayOfWeek & " - " & Me.LastDayOfWeek & ")"

                End If

            Catch ex As Exception
                LabelText = ""
            Finally
                LabelPageHeader_Title.Text = LabelText
            End Try

        End Sub
        Private Sub EmployeeTimesheetReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub PageHeader_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_Agency.Text = _AgencyName

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageFooter_Date.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub Subreport_TimesheetDetails_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Subreport_TimesheetDetails.BeforePrint

            'objects
            Dim Timesheet As AdvantageFramework.EmployeeTimesheet.Classes.Timesheet = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Timesheet = New AdvantageFramework.EmployeeTimesheet.Classes.Timesheet(DbContext, GetCurrentEmployee().Code, Me.FirstDayOfWeek, Me.LastDayOfWeek, "", _Session.UserCode)

                    DirectCast(Subreport_TimesheetDetails.ReportSource, AdvantageFramework.Reporting.Reports.Employee.TimesheetDetailsSubReport).UseProductCategory = _UseProductCategory

                    If _SortBy <> EmployeeTimesheet.ReportSortByOptions.None Then

                        Select Case _SortBy

                            Case EmployeeTimesheet.ReportSortByOptions.Client

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.ClientCode _
                                                                                      Select Entity).ToList

                            Case EmployeeTimesheet.ReportSortByOptions.Division

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.ClientCode, Entity.DivisionCode _
                                                                                      Select Entity).ToList

                            Case EmployeeTimesheet.ReportSortByOptions.Product

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode _
                                                                                      Select Entity).ToList

                            Case EmployeeTimesheet.ReportSortByOptions.JobAndComponent

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.JobNumber, Entity.JobCompNumber _
                                                                                      Select Entity).ToList

                            Case EmployeeTimesheet.ReportSortByOptions.FunctionCategory

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.FunctionCode _
                                                                                      Select Entity).ToList

                            Case EmployeeTimesheet.ReportSortByOptions.Department

                                Subreport_TimesheetDetails.ReportSource.DataSource = (From Entity In Timesheet.TimeSheetEntries _
                                                                                      Order By Entity.DepartmentTeamCode _
                                                                                      Select Entity).ToList

                        End Select

                    Else

                        Subreport_TimesheetDetails.ReportSource.DataSource = Timesheet.TimeSheetEntries

                    End If
                    
                End Using

            Catch ex As Exception
                Subreport_TimesheetDetails.ReportSource.DataSource = Nothing
            End Try

        End Sub
        Private Sub PictureBoxEmployeeSignature_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PictureBoxEmployeeSignature.BeforePrint

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            If _ExcludeEmployeeSignature = False Then

                Try

                    Employee = Me.GetCurrentEmployee

                Catch ex As Exception
                    Employee = Nothing
                End Try

                If Employee IsNot Nothing Then

                    If Employee.SignatureImage IsNot Nothing Then

                        Try

                            MemoryStream = New System.IO.MemoryStream(Employee.SignatureImage)

                            PictureBoxEmployeeSignature.Image = System.Drawing.Image.FromStream(MemoryStream)

                        Catch ex As Exception

                        End Try

                    Else

                        PictureBoxEmployeeSignature.Image = Nothing

                    End If

                End If

            Else

                PictureBoxEmployeeSignature.Image = Nothing

            End If

        End Sub
        Private Sub LabelSignatureDate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelSignatureDate.BeforePrint

            If _ExcludeEmployeeSignature Then

                LabelSignatureDate.Text = ""

            Else

                LabelSignatureDate.Text = System.DateTime.Today.ToShortDateString

            End If

        End Sub

#End Region

#End Region

        
    End Class

End Namespace
