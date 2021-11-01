Namespace Employee.Presentation

    Public Class EmployeeTimesheetPrintOptionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _EmployeeCode As String = False
        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property EmployeeCode As String
            Get
                EmployeeCode = _EmployeeCode
            End Get
        End Property
        Private ReadOnly Property StartDate As Date
            Get
                StartDate = _StartDate
            End Get
        End Property
        Private ReadOnly Property EndDate As Date
            Get
                EndDate = _EndDate
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date)

            ' This call is required by the designer.
            InitializeComponent()

            _EmployeeCode = EmployeeCode
            _StartDate = StartDate
            _EndDate = EndDate

        End Sub
        Private Sub SetDefaultDates()

            'objects
            Dim CurrentDate As Date = Nothing

            If RadioButtonControlForm_DetailWithComments.Checked Then

                DateTimePickerForm_StartDate.ValueObject = _StartDate
                DateTimePickerForm_EndDate.ValueObject = _EndDate

            Else

                CurrentDate = _StartDate

                If _StartDate.DayOfWeek <> DayOfWeek.Sunday Then

                    Do While CurrentDate.DayOfWeek <> DayOfWeek.Sunday

                        CurrentDate = CurrentDate.AddDays(-1)

                    Loop

                End If

                DateTimePickerForm_StartDate.ValueObject = CurrentDate
                DateTimePickerForm_EndDate.ValueObject = CurrentDate.AddDays(6)

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            DateTimePickerForm_EndDate.Enabled = RadioButtonControlForm_DetailWithComments.Checked
            DateTimePickerForm_StartDate.Enabled = RadioButtonControlForm_DetailWithComments.Checked

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As System.Windows.Forms.DialogResult

            'objects
            Dim EmployeeTimesheetPrintOptionsDialog As AdvantageFramework.Employee.Presentation.EmployeeTimesheetPrintOptionsDialog = Nothing

            EmployeeTimesheetPrintOptionsDialog = New AdvantageFramework.Employee.Presentation.EmployeeTimesheetPrintOptionsDialog(EmployeeCode, StartDate, EndDate)

            ShowFormDialog = EmployeeTimesheetPrintOptionsDialog.ShowDialog()

            EmployeeCode = EmployeeTimesheetPrintOptionsDialog.EmployeeCode
            StartDate = EmployeeTimesheetPrintOptionsDialog.StartDate
            EndDate = EmployeeTimesheetPrintOptionsDialog.EndDate

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EmployeeTimesheetPrintOptionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            RadioButtonControlForm_DetailWithComments.ByPassUserEntryChanged = True
            RadioButtonControlForm_Summary.ByPassUserEntryChanged = True
            CheckBoxForm_ExcludeEmployeeSignature.ByPassUserEntryChanged = True
            ComboBoxForm_SortBy.ByPassUserEntryChanged = True
            DateTimePickerForm_StartDate.ByPassUserEntryChanged = True
            DateTimePickerForm_EndDate.ByPassUserEntryChanged = True

            ComboBoxForm_SortBy.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.EmployeeTimesheet.ReportSortByOptions))
                                              Select [Code] = EnumObject.Code,
                                                     [Description] = EnumObject.Description).ToList

            If _StartDate.DayOfWeek <> DayOfWeek.Sunday Then

                If _EndDate.DayOfWeek < _StartDate.DayOfWeek Then

                    DateTimePickerForm_StartDate.ValueObject = _StartDate
                    DateTimePickerForm_EndDate.ValueObject = _EndDate
                    RadioButtonControlForm_DetailWithComments.Checked = True

                End If

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

            SetDefaultDates()
            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Print_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Print.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Datasouce As Object = Nothing
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim ReportType As AdvantageFramework.Reporting.ReportTypes = Nothing
            Dim ReportSortByOption As AdvantageFramework.EmployeeTimesheet.ReportSortByOptions = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ParameterList = New Generic.Dictionary(Of String, Object)

                    If ComboBoxForm_SortBy.HasASelectedValue Then

                        ReportSortByOption = CShort(ComboBoxForm_SortBy.GetSelectedValue)

                    Else

                        ReportSortByOption = EmployeeTimesheet.ReportSortByOptions.None

                    End If

                    If RadioButtonControlForm_Summary.Checked Then

                        ReportType = Reporting.ReportTypes.EmployeeTimesheetReport

                        Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext)
                                     Where Entity.Code = _EmployeeCode
                                     Select Entity).ToList

                        ParameterList.Add("DataSource", Datasouce)
                        ParameterList.Add("WeekOfDate", _StartDate)
                        ParameterList.Add("SortBy", ReportSortByOption)

                    ElseIf RadioButtonControlForm_DetailWithComments.Checked Then

                        ReportType = Reporting.ReportTypes.EmployeeTimesheetDetailReport

                        If ReportSortByOption <> EmployeeTimesheet.ReportSortByOptions.None Then

                            Select Case ReportSortByOption

                                Case EmployeeTimesheet.ReportSortByOptions.Client

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.ClientCode
                                                 Select Entity).ToList

                                Case EmployeeTimesheet.ReportSortByOptions.Division

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.ClientCode, Entity.DivisionCode
                                                 Select Entity).ToList

                                Case EmployeeTimesheet.ReportSortByOptions.Product

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.ClientCode, Entity.DivisionCode, Entity.ProductCode
                                                 Select Entity).ToList

                                Case EmployeeTimesheet.ReportSortByOptions.FunctionCategory

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.FunctionCategory
                                                 Select Entity).ToList

                                Case EmployeeTimesheet.ReportSortByOptions.JobAndComponent

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.JobNumber, Entity.JobComponentNumber
                                                 Select Entity).ToList

                                Case EmployeeTimesheet.ReportSortByOptions.Department

                                    Datasouce = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode)
                                                 Order By Entity.EmployeeDate, Entity.DepartmentTeamCode
                                                 Select Entity).ToList

                            End Select

                        Else

                            Datasouce = AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, _EmployeeCode, DateTimePickerForm_StartDate.Value, DateTimePickerForm_EndDate.Value, "", Me.Session.UserCode).ToList

                        End If

                        ParameterList.Add("DataSource", Datasouce)

                    End If

                    ParameterList.Add("ExcludeEmployeeSignature", CheckBoxForm_ExcludeEmployeeSignature.Checked)

                    If AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ReportType, ParameterList, Nothing, Nothing, Nothing, Nothing) = Windows.Forms.DialogResult.OK Then



                    End If

                End Using

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub RadioButtonControlForm_DetailWithComments_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlForm_DetailWithComments.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlForm_DetailWithComments.Checked Then

                    SetDefaultDates()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlForm_Summary_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlForm_Summary.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If RadioButtonControlForm_Summary.Checked Then

                    SetDefaultDates()
                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DateTimePickerForm_EndDate_VisibleChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_EndDate.VisibleChanged

            DateTimePickerForm_EndDate.SetRequired(DateTimePickerForm_EndDate.Visible)

        End Sub
        Private Sub DateTimePickerForm_StartDate_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_StartDate.ValueChanged

            DateTimePickerForm_EndDate.MinDate = DateTimePickerForm_StartDate.Value

        End Sub
        Private Sub DateTimePickerForm_StartDate_VisibleChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_StartDate.VisibleChanged

            DateTimePickerForm_StartDate.SetRequired(DateTimePickerForm_StartDate.Visible)

        End Sub

#End Region

#End Region

    End Class

End Namespace