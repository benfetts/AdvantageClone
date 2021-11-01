Imports DevExpress.XtraGrid.Views.Grid

Namespace WinForm.Presentation.Controls

    Public Class TimesheetControl
        Public Event SelectedEntryChangedEvent()
        Public Event RecordAddedEvent()
        Public Event SelectedCopyOptionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Loaded As Boolean = False
        Private _Timesheet As AdvantageFramework.EmployeeTimesheet.Classes.Timesheet = Nothing
        Private _ShowComments As Boolean = False
        Private _CanCopyTimesheet As Boolean = False
        Private _UseProductCategory As Boolean = False
        Private _TimesheetGroupByOption As AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions = EmployeeTimesheet.TimesheetGroupByOptions.None
        Private _ColorList As Generic.Dictionary(Of System.Drawing.Color, System.Drawing.Color) = Nothing
        Private _ShowEstimateApprovalMessage As Boolean = False
        Private _EstimateApprovalMessage As String = ""

        Private MonPend As Boolean = False
        Private TuePend As Boolean = False
        Private WedPend As Boolean = False
        Private ThuPend As Boolean = False
        Private FriPend As Boolean = False
        Private SatPend As Boolean = False
        Private SunPend As Boolean = False

        Private MonEdit As Boolean = True
        Private TueEdit As Boolean = True
        Private WedEdit As Boolean = True
        Private ThuEdit As Boolean = True
        Private FriEdit As Boolean = True
        Private SatEdit As Boolean = True
        Private SunEdit As Boolean = True

        Private SunClosedPP As Boolean = False
        Private MonClosedPP As Boolean = False
        Private TueClosedPP As Boolean = False
        Private WedClosedPP As Boolean = False
        Private ThuClosedPP As Boolean = False
        Private FriClosedPP As Boolean = False
        Private SatClosedPP As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property Loaded As Boolean
            Get
                Loaded = _Loaded
            End Get
        End Property
        Public Property ShowComments As Boolean
            Get
                ShowComments = _ShowComments
            End Get
            Set(value As Boolean)
                _ShowComments = value
                ModifyColumnVisibility()
            End Set
        End Property
        Public ReadOnly Property TimeEntriesDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                TimeEntriesDataGridView = DataGridViewForm_TimesheetEntries
            End Get
        End Property
        Public ReadOnly Property IsDirectTimeSelected As Boolean
            Get

                'objects
                Dim Result As Boolean = False

                Try

                    If DataGridViewForm_TimesheetEntries.HasOnlyOneSelectedRow AndAlso DataGridViewForm_TimesheetEntries.IsNewItemRow = False Then

                        Result = Not DirectCast(DataGridViewForm_TimesheetEntries.GetFirstSelectedRowDataBoundItem, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry).IsIndirectTime

                    End If

                Catch ex As Exception
                    Result = False
                End Try

                IsDirectTimeSelected = Result

            End Get
        End Property
        Public ReadOnly Property CurrentCopyFromDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get

                'objects
                Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

                If TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromProjectTab Then

                    DataGridView = DataGridViewCopyFromProject_ProjectTemplates

                ElseIf TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromTemplateTab Then

                    DataGridView = DataGridViewCopyFromTemplate_Templates

                ElseIf TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromTimesheetTab Then

                    DataGridView = DataGridViewCopyFromTimesheet_TimesheetTemplates

                End If

                CurrentCopyFromDataGridView = DataGridView

            End Get
        End Property
        Public ReadOnly Property CanDeleteEntry() As Boolean
            Get

                'objects
                Dim CanDelete As Boolean = False
                Dim Timesheet As AdvantageFramework.EmployeeTimesheet.Classes.Timesheet = Nothing

                Try

                    For Each SelectedRowHandle In DataGridViewForm_TimesheetEntries.CurrentView.GetSelectedRows

                        If DataGridViewForm_TimesheetEntries.CurrentView.IsGroupRow(SelectedRowHandle) = False Then

                            If _Timesheet.Day1Status = EmployeeTimesheet.Methods.DayStatus.Pending Or _Timesheet.Day2Status = EmployeeTimesheet.Methods.DayStatus.Pending Or _Timesheet.Day3Status = EmployeeTimesheet.Methods.DayStatus.Pending Or
                               _Timesheet.Day4Status = EmployeeTimesheet.Methods.DayStatus.Pending Or _Timesheet.Day5Status = EmployeeTimesheet.Methods.DayStatus.Pending Or _Timesheet.Day6Status = EmployeeTimesheet.Methods.DayStatus.Pending Or
                               _Timesheet.Day7Status = EmployeeTimesheet.Methods.DayStatus.Pending Or _Timesheet.Day1Status = EmployeeTimesheet.Methods.DayStatus.Approved Or _Timesheet.Day2Status = EmployeeTimesheet.Methods.DayStatus.Approved Or
                               _Timesheet.Day3Status = EmployeeTimesheet.Methods.DayStatus.Approved Or _Timesheet.Day4Status = EmployeeTimesheet.Methods.DayStatus.Approved Or _Timesheet.Day5Status = EmployeeTimesheet.Methods.DayStatus.Approved Or
                               _Timesheet.Day6Status = EmployeeTimesheet.Methods.DayStatus.Approved Or _Timesheet.Day7Status = EmployeeTimesheet.Methods.DayStatus.Approved Then


                                CanDelete = False
                                Exit For
                            Else
                                CanDelete = True
                                Exit For
                            End If

                        End If

                    Next

                Catch ex As Exception

                End Try

                CanDeleteEntry = CanDelete

            End Get
        End Property
        Public Property TimesheetGroupByOption As AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions
            Get
                TimesheetGroupByOption = _TimesheetGroupByOption
            End Get
            Set(value As AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions)
                _TimesheetGroupByOption = value
                GroupTimesheet()
                SaveDropGroupByIndexAppVar()
            End Set
        End Property
        Public ReadOnly Property SupervisorApprovalRequired As Boolean
            Get

                If _Timesheet IsNot Nothing Then

                    SupervisorApprovalRequired = _Timesheet.SupervisorApprovalActive

                Else

                    SupervisorApprovalRequired = False

                End If

            End Get
        End Property
        Public ReadOnly Property ReportMissingTime As AdvantageFramework.Database.Entities.ReportMissingTime
            Get

                If _Timesheet IsNot Nothing Then

                    ReportMissingTime = _Timesheet.ReportMissingTime

                Else

                    ReportMissingTime = Database.Entities.ReportMissingTime.ByDay

                End If

            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DataGridViewForm_TimesheetEntries.CurrentView.GridControl.ToolTipController = ToolTipControllerControl_ToolTip

                                _ColorList = New Dictionary(Of System.Drawing.Color, System.Drawing.Color)

                                _ColorList.Add(System.Drawing.Color.Red, System.Drawing.ColorTranslator.FromHtml("#E72F40"))
                                _ColorList.Add(System.Drawing.Color.Green, System.Drawing.ColorTranslator.FromHtml("#3EB71E"))
                                _ColorList.Add(System.Drawing.Color.Gold, System.Drawing.Color.Gold)

                                _UseProductCategory = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).EnableProductCategory.GetValueOrDefault(0))

                                DataGridViewForm_TimesheetEntries.OptionsView.ShowFooter = True
                                DataGridViewForm_TimesheetEntries.AutoFilterLookupColumns = True
                                DataGridViewForm_TimesheetEntries.AllowDrop = True

                                DataGridViewCopyFromTemplate_Templates.AutoFilterLookupColumns = True
                                DataGridViewCopyFromTemplate_Templates.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                                DataGridViewCopyFromProject_ProjectTemplates.ByPassUserEntryChanged = True
                                DataGridViewCopyFromTimesheet_TimesheetTemplates.ByPassUserEntryChanged = True
                                DataGridViewCopyFromTimesheet_TimesheetTemplates.AllowExtraItemsInGridLookupEdits = False

                                Me.AllowDrop = True

                                ComboBoxCopyFromTemplate_GroupBy.ByPassUserEntryChanged = True
                                ComboBoxCopyFromTemplate_GroupBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.EmployeeTimesheet.TemplateGroupByOptions))

                                Try

                                    _TimesheetGroupByOption = CInt(LoadDropGroupByIndexAppVar(DbContext).Value)

                                Catch ex As Exception
                                    _TimesheetGroupByOption = EmployeeTimesheet.TimesheetGroupByOptions.None
                                End Try

                                DataGridViewForm_TimesheetEntries.ShowColumnMenuOnRightClick = True

                                'AddHandler DataGridViewTimesheet_TimesheetTemplates.CurrentView.MouseDown, AddressOf DataGridViewTest_DragDrop_MouseDown
                                'AddHandler DataGridViewTimesheet_TimesheetTemplates.CurrentView.MouseMove, AddressOf DataGridViewTest_DragDrop_MouseMove

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub SetTotalGridColumnExpression()

            'objects
            Dim VisibleDayHoursColumns As Generic.List(Of String) = Nothing

            If DataGridViewForm_TimesheetEntries.Columns("Total") IsNot Nothing Then

                VisibleDayHoursColumns = New Generic.List(Of String)

                For Each GridColumn In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName.Contains("Day") AndAlso GridColumn.FieldName.Contains("Hours") AndAlso GridColumn.Visible = True Then

                        VisibleDayHoursColumns.Add("IsNull([" & GridColumn.FieldName & "], 0.00)")

                    End If

                Next

                DataGridViewForm_TimesheetEntries.Columns("Total").UnboundExpression = String.Join(" + ", VisibleDayHoursColumns)

                Try
                    Dim vi As Integer = (From Column In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                         Where Column.FieldName <> "Total" AndAlso Column.FieldName <> "EstimateHours" AndAlso Column.FieldName <> "EstimateHoursAll" AndAlso Column.FieldName <> "ScheduleHours" AndAlso Column.FieldName <> "ScheduleHoursAll" AndAlso Column.FieldName <> "EstimateVariance" AndAlso Column.FieldName <> "EstimateVarianceAll" AndAlso Column.FieldName <> "ScheduleVariance" AndAlso Column.FieldName <> "ScheduleVarianceAll"
                                         Select Column.VisibleIndex).Max + 1

                    DataGridViewForm_TimesheetEntries.Columns("Total").VisibleIndex = vi

                    SaveGridLayout()

                Catch ex As Exception
                    DataGridViewForm_TimesheetEntries.Columns("Total").VisibleIndex = 1
                End Try

            End If

        End Sub
        Private Sub ModifyColumnVisibility()

            Dim VisibleIndex As Integer = 1

            For Each GridColumn In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                GridColumn.Visible = False

            Next

            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientName.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionName.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductName.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString, _UseProductCategory)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString, _UseProductCategory)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobDescription.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompDescription.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamDescription.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString, _ShowComments)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString, True)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Key.ToString, False)
            DataGridViewForm_TimesheetEntries.HideOrShowColumn("Total", True)

            SetRequiredColumnOrder()

            DataGridViewForm_TimesheetEntries.CurrentView.BestFitColumns()

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            Dim ShowColumn As Boolean = False

            If DataGridViewForm_TimesheetEntries.Columns(FieldName) IsNot Nothing Then

                If Visible Then

                    If IsDateColumn(FieldName, False) Then

                        If IsDateColumnVisible(FieldName) Then

                            ShowColumn = True

                        End If

                    Else

                        ShowColumn = True

                    End If

                End If

                DataGridViewForm_TimesheetEntries.Columns(FieldName).Visible = ShowColumn

                If ShowColumn Then

                    DataGridViewForm_TimesheetEntries.Columns(FieldName).VisibleIndex = VisibleIndex
                    VisibleIndex = VisibleIndex + 1

                Else

                    DataGridViewForm_TimesheetEntries.Columns(FieldName).VisibleIndex = -1

                End If

            End If

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByRef VisibleIndex As Integer)

            Dim ShowColumn As Boolean = False
            Dim Visible As Boolean = False

            If DataGridViewForm_TimesheetEntries.Columns(FieldName) IsNot Nothing Then

                If FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString OrElse
                   FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString Then

                    Visible = _ShowComments

                ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString Then

                    Visible = _UseProductCategory

                Else

                    Visible = DataGridViewForm_TimesheetEntries.Columns(FieldName).Visible

                End If

                HideOrShowColumn(FieldName, Visible, VisibleIndex)

            End If

        End Sub
        Private Sub SetRequiredColumnOrder()

            'objects
            Dim VisibleIndex As Integer = 0

            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientName.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionName.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductName.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobDescription.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompDescription.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamDescription.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString, VisibleIndex)
            HideOrShowColumn("Total", VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString, VisibleIndex)
            HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString, VisibleIndex)

        End Sub
        Private Function IsDateColumn(ByVal FieldName As String, ByRef IsCommentColumn As Boolean) As Boolean

            'objects
            Dim DateColumn As Boolean = False

            Try

                IsCommentColumn = False

                If FieldName.Contains("Day") Then

                    If IsDateHoursColumn(FieldName) Then

                        DateColumn = True
                        IsCommentColumn = False

                    ElseIf IsDateCommentsColumn(FieldName) Then

                        DateColumn = True
                        IsCommentColumn = True

                    End If

                End If

            Catch ex As Exception
                DateColumn = True
            Finally
                IsDateColumn = DateColumn
            End Try

        End Function
        Private Function IsDateHoursColumn(ByVal FieldName As String) As Boolean

            'objects
            Dim HoursColumn As Boolean = False

            Try

                HoursColumn = FieldName.Contains("Hours")

            Catch ex As Exception
                HoursColumn = True
            Finally
                IsDateHoursColumn = HoursColumn
            End Try

        End Function
        Private Function IsDateCommentsColumn(ByVal FieldName As String) As Boolean

            'objects
            Dim CommentsColumn As Boolean = False

            Try

                CommentsColumn = FieldName.Contains("Comments")

            Catch ex As Exception
                CommentsColumn = True
            Finally
                IsDateCommentsColumn = CommentsColumn
            End Try

        End Function
        Private Function IsDateColumnVisible(ByVal FieldName As String) As Boolean

            'objects
            Dim DateColumnVisible As Boolean = False

            Try

                If _Timesheet.StartDate <= GetDateColumnDate(FieldName) AndAlso _Timesheet.EndDate >= GetDateColumnDate(FieldName) Then

                    If IsDateCommentsColumn(FieldName) Then

                        DateColumnVisible = _ShowComments

                    Else

                        DateColumnVisible = True

                    End If

                End If

            Catch ex As Exception
                DateColumnVisible = False
            Finally
                IsDateColumnVisible = DateColumnVisible
            End Try

        End Function
        Private Function GetDateColumnDate(ByVal FieldName As String) As Date

            'objects
            Dim DateColumnDate As Date = Nothing
            Dim DateColumnDay As Integer = Nothing

            Try

                DateColumnDay = CInt(FieldName.Replace("Day", "").Replace("Hours", "").Replace("Comments", ""))

                DateColumnDate = _Timesheet.StartDate.AddDays(DateColumnDay - 1)

            Catch ex As Exception
                DateColumnDate = Nothing
            Finally
                GetDateColumnDate = DateColumnDate
            End Try

        End Function
        Private Sub EnableOrDisableActions()

            TabItemOptions_CopyFromTimesheetTab.Visible = _CanCopyTimesheet

        End Sub
        Private Function FormatUserSettingColumnCaption(ByVal Caption As String) As String

            'objects
            Dim NewCaption As String = Nothing

            Try

                NewCaption = Caption.Trim

                If NewCaption.EndsWith("Code") = False Then

                    NewCaption = NewCaption & " Code"

                End If

            Catch ex As Exception
                NewCaption = Caption
            End Try

            FormatUserSettingColumnCaption = Caption

        End Function
        Private Function SaveTimesheetEntry(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Day As Integer, ByVal TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) As Boolean

            'objects
            Dim DayKey As String = Nothing
            Dim DayHours As Nullable(Of Decimal) = Nothing
            Dim DayComments As String = Nothing
            Dim EmployeeTimeID As Integer = Nothing
            Dim EmployeeTimeDetailID As Integer = Nothing
            Dim ReturnMessage As String = Nothing
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeTimeIndirect As AdvantageFramework.Database.Entities.EmployeeTimeIndirect = Nothing
            Dim EmployeeTime As AdvantageFramework.Database.Entities.EmployeeTime = Nothing
            Dim Passed As Boolean = True

            Try

                Select Case Day

                    Case 1

                        DayKey = TimesheetEntry.Day1Key
                        DayHours = TimesheetEntry.Day1Hours
                        DayComments = TimesheetEntry.Day1Comments

                    Case 2

                        DayKey = TimesheetEntry.Day2Key
                        DayHours = TimesheetEntry.Day2Hours
                        DayComments = TimesheetEntry.Day2Comments

                    Case 3

                        DayKey = TimesheetEntry.Day3Key
                        DayHours = TimesheetEntry.Day3Hours
                        DayComments = TimesheetEntry.Day3Comments

                    Case 4

                        DayKey = TimesheetEntry.Day4Key
                        DayHours = TimesheetEntry.Day4Hours
                        DayComments = TimesheetEntry.Day4Comments

                    Case 5

                        DayKey = TimesheetEntry.Day5Key
                        DayHours = TimesheetEntry.Day5Hours
                        DayComments = TimesheetEntry.Day5Comments

                    Case 6

                        DayKey = TimesheetEntry.Day6Key
                        DayHours = TimesheetEntry.Day6Hours
                        DayComments = TimesheetEntry.Day6Comments

                    Case 7

                        DayKey = TimesheetEntry.Day7Key
                        DayHours = TimesheetEntry.Day7Hours
                        DayComments = TimesheetEntry.Day7Comments

                    Case Else

                        DayKey = Nothing
                        DayHours = Nothing
                        DayComments = Nothing

                End Select

                If DayHours.HasValue Then

                    If String.IsNullOrEmpty(DayKey) = False Then

                        EmployeeTimeID = CInt(DayKey.Split("|").ElementAt(0))
                        EmployeeTimeDetailID = CInt(DayKey.Split("|").ElementAt(1))

                    Else

                        EmployeeTimeID = 0
                        EmployeeTimeDetailID = 0

                    End If

                    If AdvantageFramework.EmployeeTimesheet.SaveTimesheetDay(_Session, DbContext, EmployeeTimeID, EmployeeTimeDetailID, _Timesheet.EmployeeCode, _Timesheet.StartDate.AddDays(Day - 1), TimesheetEntry.FunctionCode,
                                                                             DayHours.Value, TimesheetEntry.JobNumber.GetValueOrDefault(0), TimesheetEntry.JobCompNumber.GetValueOrDefault(0),
                                                                             TimesheetEntry.DepartmentTeamCode, TimesheetEntry.ProductCategoryCode, _Session.UserCode, DayComments, 0, ReturnMessage) = True Then

                        AdvantageFramework.EmployeeTimesheet.ParseDetailRecordInformation(ReturnMessage, EmployeeTimeID, EmployeeTimeDetailID)

                        If (EmployeeTimeID = Nothing OrElse EmployeeTimeID <= 0) AndAlso (EmployeeTimeDetailID = Nothing OrElse EmployeeTimeDetailID <= 0) Then

                            Passed = False

                        Else

                            TimesheetEntry.SetDataKey(Day, EmployeeTimeID, EmployeeTimeDetailID)

                        End If

                        If _ShowEstimateApprovalMessage = False Then

                            _ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(ReturnMessage, _EstimateApprovalMessage)

                            'If _ShowEstimateApprovalMessage = False And Passed = False And ReturnMessage <> "" Then

                            '    _ShowEstimateApprovalMessage = True
                            '    _EstimateApprovalMessage = ReturnMessage

                            'End If

                        End If

                    Else

                        Passed = False

                        If _ShowEstimateApprovalMessage = False Then

                            _ShowEstimateApprovalMessage = Me.ShowNewEntryMessage(ReturnMessage, _EstimateApprovalMessage)

                        End If

                    End If

                ElseIf String.IsNullOrEmpty(DayKey) = False Then

                    EmployeeTimeID = CInt(DayKey.Split("|").ElementAt(0))
                    EmployeeTimeDetailID = CInt(DayKey.Split("|").ElementAt(1))

                    If TimesheetEntry.IsIndirectTime = True Then

                        Passed = AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Delete(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                    Else

                        Passed = AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Delete(DbContext, EmployeeTimeID, EmployeeTimeDetailID)

                    End If

                End If

            Catch ex As Exception

            End Try

            SaveTimesheetEntry = Passed

        End Function
        Private Function SaveTimesheetEntry(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry) As Boolean

            'objects
            Dim Saved As Boolean = True

            For DayNumber = 1 To (_Timesheet.EndDate.Day - _Timesheet.StartDate.Day + 1)

                If SaveTimesheetEntry(DbContext, DayNumber, TimesheetEntry) = False Then

                    Saved = False

                End If

            Next

            If _ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(_EstimateApprovalMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show(_EstimateApprovalMessage)

                _ShowEstimateApprovalMessage = False

            End If

            SaveTimesheetEntry = Saved

        End Function
        Private Sub LoadCopyFromProjectTab()

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Timesheet.EmployeeCode)

                DataGridViewCopyFromProject_ProjectTemplates.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimesheetTask.Load(DbContext, _Session.UserCode, _Timesheet.EmployeeCode).ToList
                                                                           Select New AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate With {.ClientCode = Entity.ClientCode,
                                                                                                                                                         .DivisionCode = Entity.DivisionCode,
                                                                                                                                                         .ProductCode = Entity.ProductCode,
                                                                                                                                                         .JobNumber = Entity.JobNumber,
                                                                                                                                                         .JobDescription = Entity.JobDescription,
                                                                                                                                                         .JobCompNumber = Entity.JobCompNumber,
                                                                                                                                                         .JobCompDescription = Entity.JobCompDescription,
                                                                                                                                                         .FunctionCode = Entity.FunctionCode,
                                                                                                                                                         .TaskDescription = Entity.TaskDescription,
                                                                                                                                                         .ProductCategoryCode = "",
                                                                                                                                                         .DepartmentTeamCode = Employee.DepartmentTeamCode}).ToList
                DataGridViewCopyFromProject_ProjectTemplates.CurrentView.BestFitColumns()
                DataGridViewCopyFromProject_ProjectTemplates.MakeColumnNotVisible("ClientName")
                DataGridViewCopyFromProject_ProjectTemplates.MakeColumnNotVisible("DivisionName")
                DataGridViewCopyFromProject_ProjectTemplates.MakeColumnNotVisible("ProductDescription")

            End Using

            TabItemOptions_CopyFromProjectTab.Tag = True

        End Sub
        Private Sub LoadCopyFromTemplateTab()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    DataGridViewCopyFromTemplate_Templates.DataSource = AdvantageFramework.Database.Procedures.EmployeeTimeTemplateComplex.Load(DbContext, _Timesheet.EmployeeCode, _Session.UserCode).ToList _
                                                                        .Select(Function(Complex) New AdvantageFramework.Database.Classes.EmployeeTimeTemplate(Complex)).ToList

                Catch ex As Exception

                End Try

                DataGridViewCopyFromTemplate_Templates.CurrentView.BestFitColumns()

            End Using

            TabItemOptions_CopyFromTemplateTab.Tag = True

        End Sub
        Private Sub LoadCopyFromTimesheetTab()

            'objects
            Dim DayRecords As Generic.List(Of AdvantageFramework.EmployeeTimesheet.Classes.DayRecord) = Nothing

            If _CanCopyTimesheet Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewCopyFromTimesheet_TimesheetTemplates.ItemDescription = "Timesheet Record(s)"

                        Try

                            DayRecords = (From EmpTimeDetail In AdvantageFramework.Database.Procedures.EmployeeTimeDetail.Load(DbContext).Include("EmployeeTime")
                                          Join Job In AdvantageFramework.Database.Procedures.JobView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, _Session.UserCode) On Job.JobNumber Equals EmpTimeDetail.JobNumber
                                          Where EmpTimeDetail.EmployeeTime.EmployeeCode = _Timesheet.EmployeeCode AndAlso
                                            (EmpTimeDetail.EmployeeTime.Date < _Timesheet.StartDate OrElse
                                             EmpTimeDetail.EmployeeTime.Date > _Timesheet.EndDate)
                                          Select New AdvantageFramework.EmployeeTimesheet.Classes.DayRecord With {.EmployeeTimeID = EmpTimeDetail.EmployeeTimeID,
                                                                                                              .EmployeeTimeDetailID = EmpTimeDetail.EmployeeTimeDetailID,
                                                                                                              .EmployeeDate = EmpTimeDetail.EmployeeTime.Date,
                                                                                                              .EmployeeHours = EmpTimeDetail.Hours,
                                                                                                              .JobNumber = EmpTimeDetail.JobNumber,
                                                                                                              .JobCompNumber = EmpTimeDetail.JobComponentNumber,
                                                                                                              .ClientCode = Job.ClientCode,
                                                                                                              .DivisionCode = Job.DivisionCode,
                                                                                                              .ProductCode = Job.ProductCode,
                                                                                                              .FunctionCode = EmpTimeDetail.FunctionCode,
                                                                                                              .DeptTeamCode = EmpTimeDetail.DepartmentTeamCode,
                                                                                                              .IsIndirectTime = False}).ToList _
                                     .Union((From EmpTimeIndirect In AdvantageFramework.Database.Procedures.EmployeeTimeIndirect.Load(DbContext).Include("EmployeeTime")
                                             Where EmpTimeIndirect.EmployeeTime.EmployeeCode = _Timesheet.EmployeeCode AndAlso
                                                   (EmpTimeIndirect.EmployeeTime.Date < _Timesheet.StartDate OrElse
                                                    EmpTimeIndirect.EmployeeTime.Date > _Timesheet.EndDate)
                                             Select New AdvantageFramework.EmployeeTimesheet.Classes.DayRecord With {.EmployeeTimeID = EmpTimeIndirect.ID,
                                                                                                                     .EmployeeTimeDetailID = EmpTimeIndirect.EmployeeTimeDetailID,
                                                                                                                     .EmployeeHours = EmpTimeIndirect.Hours,
                                                                                                                     .EmployeeDate = EmpTimeIndirect.EmployeeTime.Date,
                                                                                                                     .FunctionCode = EmpTimeIndirect.Category,
                                                                                                                     .DeptTeamCode = EmpTimeIndirect.DepartmentTeamCode,
                                                                                                                     .IsIndirectTime = True})).OrderByDescending(Function(Rec) Rec.EmployeeDate).ToList

                        Catch ex As Exception

                        End Try

                        DataGridViewCopyFromTimesheet_TimesheetTemplates.DataSource = DayRecords
                        DataGridViewCopyFromTimesheet_TimesheetTemplates.CurrentView.BestFitColumns()

                    End Using

                End Using

                TabItemOptions_CopyFromTimesheetTab.Tag = True

            End If

        End Sub
        Private Sub LoadCopyFromOptions(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If _Timesheet IsNot Nothing Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlOptions_Options.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlOptions_Options.SelectedTab

                End If

                If TabItem.Tag = False Then

                    If TabItem Is TabItemOptions_CopyFromProjectTab Then

                        LoadCopyFromProjectTab()

                    ElseIf TabItem Is TabItemOptions_CopyFromTemplateTab Then

                        LoadCopyFromTemplateTab()

                    ElseIf TabItem Is TabItemOptions_CopyFromTimesheetTab Then

                        LoadCopyFromTimesheetTab()

                    End If

                End If

            End If

        End Sub
        Private Function CopyFromProjects(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim ProjectTemplate As AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate = Nothing

            If DataGridViewCopyFromProject_ProjectTemplates.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedRow In DataGridViewCopyFromProject_ProjectTemplates.GetAllSelectedRowsDataBoundItems

                        Try

                            ProjectTemplate = DirectCast(SelectedRow, AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate)

                            'If _UseProductCategory Then

                            '    If ProjectTemplate.ProductCategoryCode = "" Then

                            '        ErrorMessage = "Please select a product category."
                            '        Exit For

                            '    End If

                            'End If

                        Catch ex As Exception
                            ProjectTemplate = Nothing
                        End Try

                        If ProjectTemplate IsNot Nothing Then

                            TimesheetEntry = New AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry

                            With TimesheetEntry

                                .JobNumber = ProjectTemplate.JobNumber
                                .JobCompNumber = ProjectTemplate.JobCompNumber
                                .FunctionCode = ProjectTemplate.FunctionCode
                                .DepartmentTeamCode = ProjectTemplate.DepartmentTeamCode
                                .ProductCategoryCode = ProjectTemplate.ProductCategoryCode

                                .Day1Hours = 0

                                If _Timesheet.StartDate.AddDays(1) <= _Timesheet.EndDate Then

                                    .Day2Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(2) <= _Timesheet.EndDate Then

                                    .Day3Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(3) <= _Timesheet.EndDate Then

                                    .Day4Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(4) <= _Timesheet.EndDate Then

                                    .Day5Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(5) <= _Timesheet.EndDate Then

                                    .Day6Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(6) <= _Timesheet.EndDate Then

                                    .Day7Hours = 0

                                End If

                            End With

                            If SaveTimesheetEntry(DbContext, TimesheetEntry) Then

                                Copied = True

                            End If

                        End If

                    Next

                End Using

            Else

                ErrorMessage = "Please select a project template."

            End If

            CopyFromProjects = Copied

        End Function
        Private Function CopyFromTemplates(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim SelectedDates As Date() = Nothing
            Dim Cancel As Boolean = False
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            If DataGridViewCopyFromTemplate_Templates.HasASelectedRow Then

                If _Timesheet.StartDate = _Timesheet.EndDate Then

                    SelectedDates = {_Timesheet.StartDate}

                Else

                    If AdvantageFramework.Employee.Presentation.TimesheetSelectDayDialog.ShowFormDialog(_Timesheet.StartDate, _Timesheet.EndDate, SelectedDates) = Windows.Forms.DialogResult.Cancel Then

                        Cancel = True

                    End If

                End If

                If Cancel = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each EmployeeTimeTemplate In DataGridViewCopyFromTemplate_Templates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeTimeTemplate)()

                            TimesheetEntry = New AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry

                            TimesheetEntry.ClientCode = EmployeeTimeTemplate.ClientCode
                            TimesheetEntry.DivisionCode = EmployeeTimeTemplate.DivisionCode
                            TimesheetEntry.ProductCode = EmployeeTimeTemplate.ProductCode
                            TimesheetEntry.JobNumber = EmployeeTimeTemplate.JobNumber
                            TimesheetEntry.JobCompNumber = EmployeeTimeTemplate.JobCompNumber
                            TimesheetEntry.FunctionCode = EmployeeTimeTemplate.FunctionCode
                            TimesheetEntry.DepartmentTeamCode = EmployeeTimeTemplate.DepartmentTeamCode

                            If SelectedDates.Contains(_Timesheet.StartDate) Then

                                TimesheetEntry.Day1Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day1Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(1)) Then

                                TimesheetEntry.Day2Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day2Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(2)) Then

                                TimesheetEntry.Day3Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day3Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(3)) Then

                                TimesheetEntry.Day4Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day4Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(4)) Then

                                TimesheetEntry.Day5Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day5Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(5)) Then

                                TimesheetEntry.Day6Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day6Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            If SelectedDates.Contains(_Timesheet.StartDate.AddDays(6)) Then

                                TimesheetEntry.Day7Comments = EmployeeTimeTemplate.Comment
                                TimesheetEntry.Day7Hours = EmployeeTimeTemplate.EmployeeHours

                            End If

                            Copied = SaveTimesheetEntry(DbContext, TimesheetEntry)

                        Next

                    End Using

                End If

            Else

                ErrorMessage = "Please select a template."

            End If

            CopyFromTemplates = Copied

        End Function
        Private Function CopyFromTimesheets(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim DayRecord As AdvantageFramework.EmployeeTimesheet.Classes.DayRecord = Nothing
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim Copied As Boolean = False

            If DataGridViewCopyFromTimesheet_TimesheetTemplates.HasASelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedRow In DataGridViewCopyFromTimesheet_TimesheetTemplates.GetAllSelectedRowsDataBoundItems

                        Try

                            DayRecord = DirectCast(SelectedRow, AdvantageFramework.EmployeeTimesheet.Classes.DayRecord)

                        Catch ex As Exception
                            DayRecord = Nothing
                        End Try

                        If DayRecord IsNot Nothing Then

                            TimesheetEntry = New AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry

                            With TimesheetEntry

                                .JobNumber = DayRecord.JobNumber
                                .JobCompNumber = DayRecord.JobCompNumber
                                .FunctionCode = DayRecord.FunctionCode
                                .DepartmentTeamCode = DayRecord.DeptTeamCode

                                .Day1Hours = 0

                                If _Timesheet.StartDate.AddDays(1) <= _Timesheet.EndDate Then

                                    .Day2Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(2) <= _Timesheet.EndDate Then

                                    .Day3Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(3) <= _Timesheet.EndDate Then

                                    .Day4Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(4) <= _Timesheet.EndDate Then

                                    .Day5Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(5) <= _Timesheet.EndDate Then

                                    .Day6Hours = 0

                                End If

                                If _Timesheet.StartDate.AddDays(6) <= _Timesheet.EndDate Then

                                    .Day7Hours = 0

                                End If

                            End With

                            If SaveTimesheetEntry(DbContext, TimesheetEntry) Then

                                Copied = True

                            End If

                        End If

                    Next

                End Using

            Else

                ErrorMessage = "Please select a record."

            End If

            CopyFromTimesheets = Copied

        End Function
        Private Sub LoadTimesheetSettings()

            'objects
            Dim UserDaysToDisplay As Short = Nothing
            Dim UserStartWeekOn As String = Nothing
            Dim UserShowCommentsUsing As String = Nothing
            Dim UserMainTimesheetNoPaging As Boolean = Nothing
            Dim UserDivision As String = Nothing
            Dim UserProduct As String = Nothing
            Dim UserProductCategory As String = Nothing
            Dim UserJob As String = Nothing
            Dim UserJobComp As String = Nothing
            Dim UserFunctionCategory As String = Nothing
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim IsCommentColumn As Boolean = False
            Dim CommentsRequired As Boolean = False

            AdvantageFramework.EmployeeTimesheet.LoadTimesheetSettings(_Session, _Session.UserCode, UserDaysToDisplay, UserStartWeekOn,
                                                                       UserShowCommentsUsing, UserMainTimesheetNoPaging, UserDivision, UserProduct,
                                                                       UserProductCategory, UserJob, UserJobComp, UserFunctionCategory, CommentsRequired)

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString).Caption = UserDivision

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionName.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionName.ToString).Caption = UserDivision & " Name"

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString).Caption = UserProduct

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductName.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductName.ToString).Caption = UserProduct & " Name"

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString).Caption = UserProductCategory

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString).Caption = UserProductCategory & " Description"

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString).Caption = UserJob

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobDescription.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobDescription.ToString).Caption = UserJob & " Description"

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString).Caption = UserJobComp

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompDescription.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompDescription.ToString).Caption = UserJobComp & " Description"

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString).Caption = UserFunctionCategory

            End If

            If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString) IsNot Nothing Then

                DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString).Caption = UserFunctionCategory & " Description"

            End If

            If UserShowCommentsUsing = "icon" And CommentsRequired = False Then

                _ShowComments = False

            Else

                _ShowComments = True

            End If

            For Each GridColumn In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If IsDateColumn(GridColumn.FieldName, IsCommentColumn) Then

                    If IsCommentColumn = False Then

                        If GridColumn.ColumnEdit IsNot Nothing Then

                            If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox Then

                                SubItemTextBox = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox)

                                SubItemTextBox.Buttons(0).Visible = Not _ShowComments
                                SubItemTextBox.Mask.EditMask = "N2"
                                SubItemTextBox.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                                SubItemTextBox.Mask.UseMaskAsDisplayFormat = True

                            End If

                        End If

                    End If

                End If

            Next

            Dim MaxVisibleIndex As Integer = 1

            Try

                MaxVisibleIndex = (From Column In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                   Select Column.VisibleIndex).Max + 1

            Catch ex As Exception
                MaxVisibleIndex = 1
            End Try

            If UserDaysToDisplay = 7 Then

                LoadStoredLayout()

                If _ShowComments = True Then

                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString, _ShowComments, MaxVisibleIndex)

                End If

                HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString, True, MaxVisibleIndex)
                HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString, _ShowComments, MaxVisibleIndex)
                HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString, True, MaxVisibleIndex)
                HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString, _ShowComments, MaxVisibleIndex)

                Try
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString, True, MaxVisibleIndex)
                    End If
                Catch ex As Exception
                End Try



                SaveGridLayout()

            Else

                LoadStoredLayout()

                If _ShowComments = True Then

                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString, _ShowComments, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString, True, MaxVisibleIndex)
                    HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString, _ShowComments, MaxVisibleIndex)

                End If

                DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString, False)
                DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString, _ShowComments)
                DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString, False)
                DataGridViewForm_TimesheetEntries.HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString, _ShowComments)

                Try
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString, True, MaxVisibleIndex)
                    End If
                    If DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString) IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString).Visible = True Then
                        HideOrShowColumn(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString, True, MaxVisibleIndex)
                    End If
                Catch ex As Exception
                End Try

                SaveGridLayout()

            End If


        End Sub
        Private Sub CheckTimesheetApprovalStatus()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).SupervisorApprovalActive.GetValueOrDefault(0) = 1 Then

                    For Each GridColumn In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()



                    Next

                End If

            End Using

        End Sub
        Private Sub GroupTimesheet()

            DataGridViewForm_TimesheetEntries.CurrentView.ClearGrouping()
            DataGridViewForm_TimesheetEntries.CurrentView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.Hidden

            If DataGridViewForm_TimesheetEntries.Columns("CustomGroupByKey") IsNot Nothing Then

                If _TimesheetGroupByOption <> EmployeeTimesheet.TimesheetGroupByOptions.None Then

                    DataGridViewForm_TimesheetEntries.Columns("CustomGroupByKey").Group()
                    DataGridViewForm_TimesheetEntries.CurrentView.ExpandAllGroups()
                    DataGridViewForm_TimesheetEntries.CurrentView.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleIfExpanded

                End If

                DataGridViewForm_TimesheetEntries.Columns("CustomGroupByKey").Visible = False

            End If

        End Sub
        Private Sub SaveDropGroupByIndexAppVar()

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing
            Dim VarValue As String = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VarValue = CInt(_TimesheetGroupByOption).ToString

                    AppVar = LoadDropGroupByIndexAppVar(DbContext)

                    If AppVar Is Nothing Then

                        AppVar = New AdvantageFramework.Database.Entities.AppVars

                        AppVar.DbContext = DbContext
                        AppVar.UserCode = _Session.UserCode
                        AppVar.Application = "TIMESHEET"
                        AppVar.Group = 0
                        AppVar.Name = "DropGroupByIndex"
                        AppVar.Type = "Integer"
                        AppVar.Value = VarValue

                        AdvantageFramework.Database.Procedures.AppVars.Insert(DbContext, AppVar)

                    Else

                        AppVar.Value = VarValue
                        AdvantageFramework.Database.Procedures.AppVars.Update(DbContext, AppVar)

                    End If

                End Using

            End If

        End Sub
        Private Function LoadDropGroupByIndexAppVar(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.AppVars

            'objects
            Dim AppVar As AdvantageFramework.Database.Entities.AppVars = Nothing

            Try

                AppVar = (From Entity In AdvantageFramework.Database.Procedures.AppVars.LoadByApplicationName(DbContext, _Session.UserCode, "TIMESHEET")
                          Where Entity.Name = "DropGroupByIndex"
                          Select Entity).SingleOrDefault

            Catch ex As Exception
                AppVar = Nothing
            Finally
                LoadDropGroupByIndexAppVar = AppVar
            End Try

        End Function
        Private Sub CheckTimesheetHours(ByVal IsAddingRow As Boolean)

            'objects
            Dim HasHours As Boolean = False
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim DayHours As Decimal = Nothing
            Dim CheckHours As Boolean = True
            Dim DayNumber As Short = 0
            Dim ExceedDates As Generic.List(Of Date) = Nothing
            Dim WarningMessage As String = Nothing

            If IsAddingRow Then

                TimesheetEntry = DirectCast(DataGridViewForm_TimesheetEntries.CurrentView.GetRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle), AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)

            End If

            For DayNumber = 1 To 7

                DayHours = 0
                CheckHours = True

                If IsAddingRow Then

                    Select Case DayNumber

                        Case 1

                            CheckHours = TimesheetEntry.Day1Hours.HasValue

                        Case 2

                            CheckHours = TimesheetEntry.Day2Hours.HasValue

                        Case 3

                            CheckHours = TimesheetEntry.Day3Hours.HasValue

                        Case 4

                            CheckHours = TimesheetEntry.Day4Hours.HasValue

                        Case 5

                            CheckHours = TimesheetEntry.Day5Hours.HasValue

                        Case 6

                            CheckHours = TimesheetEntry.Day6Hours.HasValue

                        Case 7

                            CheckHours = TimesheetEntry.Day7Hours.HasValue

                    End Select

                End If

                If CheckHours Then

                    Try

                        DayHours = If(DayNumber = 1, _Timesheet.Day1Hours,
                                   If(DayNumber = 2, _Timesheet.Day2Hours,
                                   If(DayNumber = 3, _Timesheet.Day3Hours,
                                   If(DayNumber = 4, _Timesheet.Day4Hours,
                                   If(DayNumber = 5, _Timesheet.Day5Hours,
                                   If(DayNumber = 6, _Timesheet.Day6Hours,
                                   If(DayNumber = 7, _Timesheet.Day7Hours, 0)))))))

                    Catch ex As Exception
                        DayHours = 0
                    End Try

                    If DayHours > 24 Then

                        If ExceedDates Is Nothing Then

                            ExceedDates = New Generic.List(Of Date)

                        End If

                        ExceedDates.Add(_Timesheet.StartDate.AddDays(DayNumber - 1))

                    End If

                End If

            Next

            If ExceedDates IsNot Nothing AndAlso ExceedDates.Count > 0 Then

                WarningMessage = "Warning! You have entered over 24 hours for "

                For Each ExceedDate In ExceedDates

                    If ExceedDates.Count > 1 Then

                        If ExceedDate = ExceedDates.Last Then

                            WarningMessage = WarningMessage.Remove(WarningMessage.Length - 2, 1)

                            WarningMessage &= "& " & ExceedDate.ToShortDateString & "."

                        Else

                            WarningMessage &= ExceedDate.ToShortDateString & ", "

                        End If

                    Else

                        WarningMessage &= ExceedDate.ToShortDateString & "."

                    End If

                Next

            End If

            If String.IsNullOrEmpty(WarningMessage) = False Then

                AdvantageFramework.Navigation.ShowMessageBox(WarningMessage)

            End If

        End Sub
        Private Sub SetAvailableColumnsForPopupMenu()

            'objects
            Dim BarCheckItem As DevExpress.XtraBars.BarCheckItem = Nothing
            Dim AllowShowHideColumns As Generic.List(Of String) = Nothing

            AllowShowHideColumns = New List(Of String)

            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientName.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionName.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductName.ToString)

            If _UseProductCategory Then

                'AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString)
                AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString)

            End If

            'AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobDescription.ToString)
            'AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompDescription.ToString)
            'AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamDescription.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHours.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateHoursAll.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHours.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleHoursAll.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVariance.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.EstimateVarianceAll.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVariance.ToString)
            AllowShowHideColumns.Add(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ScheduleVarianceAll.ToString)
            AllowShowHideColumns.Add("Total")

            For Each GridColumn In DataGridViewForm_TimesheetEntries.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If AllowShowHideColumns.Contains(GridColumn.FieldName) Then

                    GridColumn.OptionsColumn.AllowShowHide = True
                    GridColumn.OptionsColumn.ShowInCustomizationForm = True

                Else

                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub SaveGridLayout()

            AdvantageFramework.WinForm.Presentation.Controls.SaveMinimalDataGridViewLayout(_Session, DataGridViewForm_TimesheetEntries, Database.Entities.GridAdvantageType.EmployeeTimesheet)
            'DataGridViewForm_TimesheetEntries.RefreshRestoredLayoutNonVisibleGridColumnList()

        End Sub
        Private Sub ModifyCommentsColumn()

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim Image As System.Drawing.Image = Nothing
            Dim ToolTip As String = Nothing
            Dim MissingComments As Boolean = False
            Dim FocusedColumn As String = Nothing
            Dim IsCommentColumn As Boolean = False

            FocusedColumn = DataGridViewForm_TimesheetEntries.CurrentView.FocusedColumn.FieldName

            If IsDateColumn(FocusedColumn, IsCommentColumn) = True Then

                If IsCommentColumn = False Then

                    If TypeOf DataGridViewForm_TimesheetEntries.CurrentView.FocusedColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox Then

                        SubItemTextBox = DirectCast(DataGridViewForm_TimesheetEntries.CurrentView.FocusedColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox)

                        Image = AdvantageFramework.My.Resources.DocumentTimeImage
                        ToolTip = "Add Comment"

                        Try

                            If DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRow IsNot Nothing Then

                                TimesheetEntry = DirectCast(DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRow, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)

                                If TimesheetEntry IsNot Nothing AndAlso TimesheetEntry.CommentsRequired = True Then

                                    Select Case FocusedColumn

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString

                                            MissingComments = TimesheetEntry.Day1Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day1Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString

                                            MissingComments = TimesheetEntry.Day2Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day2Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString

                                            MissingComments = TimesheetEntry.Day3Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day3Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString

                                            MissingComments = TimesheetEntry.Day4Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day4Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString

                                            MissingComments = TimesheetEntry.Day5Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day5Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString

                                            MissingComments = TimesheetEntry.Day6Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day6Comments)

                                        Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString

                                            MissingComments = TimesheetEntry.Day7Hours.GetValueOrDefault(0) > 0 AndAlso String.IsNullOrWhiteSpace(TimesheetEntry.Day7Comments)

                                    End Select

                                    If MissingComments Then

                                        Image = AdvantageFramework.My.Resources.DocumentWarningImage
                                        ToolTip = "Comment is missing; click to add"

                                    End If

                                End If

                            End If

                        Catch ex As Exception

                        End Try

                        SubItemTextBox.Buttons(0).Image = Image
                        SubItemTextBox.Buttons(0).ToolTip = ToolTip

                    End If

                End If

            End If

        End Sub
        Private Function GetDayStatus(ByVal TimesheetDate As Date) As AdvantageFramework.EmployeeTimesheet.DayStatus

            'objects
            Dim TimesheetDateDayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing

            If _Timesheet IsNot Nothing AndAlso _Timesheet.StartDate <= TimesheetDate AndAlso _Timesheet.EndDate >= TimesheetDate Then

                If TimesheetDate = _Timesheet.StartDate Then

                    TimesheetDateDayStatus = _Timesheet.Day1Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(1) Then

                    TimesheetDateDayStatus = _Timesheet.Day2Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(2) Then

                    TimesheetDateDayStatus = _Timesheet.Day3Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(3) Then

                    TimesheetDateDayStatus = _Timesheet.Day4Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(4) Then

                    TimesheetDateDayStatus = _Timesheet.Day5Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(5) Then

                    TimesheetDateDayStatus = _Timesheet.Day6Status

                ElseIf TimesheetDate = _Timesheet.StartDate.AddDays(6) Then

                    TimesheetDateDayStatus = _Timesheet.Day7Status

                End If

            End If

            GetDayStatus = TimesheetDateDayStatus

        End Function
        Private Sub ModifyDateColumns()

            'objects
            Dim SubItemTextBox As AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim DateColumnEditable As Boolean = True
            Dim IsCommentsColumn As Boolean = False
            Dim DateColumnDate As Date = Nothing
            Dim Caption As String = ""
            Dim DateColumnDayStatus As AdvantageFramework.EmployeeTimesheet.DayStatus = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            For Each GridColumn In (From GridCol In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()
                                    Where IsDateColumn(GridCol.FieldName, IsCommentsColumn) = True
                                    Select GridCol).ToList

                DateColumnEditable = True

                DateColumnDate = GetDateColumnDate(GridColumn.FieldName)

                Caption = DateColumnDate.Month & "/" & DateColumnDate.Day

                DateColumnDayStatus = GetDayStatus(DateColumnDate)

                If DateColumnDayStatus = EmployeeTimesheet.DayStatus.Open OrElse DateColumnDayStatus = EmployeeTimesheet.DayStatus.Denied Then

                    DateColumnEditable = True

                Else

                    DateColumnEditable = False

                End If

                If IsDateCommentsColumn(GridColumn.FieldName) Then

                    Caption &= " Comments"
                    GridColumn.OptionsColumn.ReadOnly = Not DateColumnEditable

                    If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit Then

                        DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemMemoEdit).AllowDropDownWhenReadOnly = DevExpress.Utils.DefaultBoolean.True

                    End If

                Else

                    If DateColumnDayStatus = EmployeeTimesheet.DayStatus.Open Then

                        GridColumn.Image = Nothing
                        GridColumn.ToolTip = ""

                    Else

                        Select Case DateColumnDayStatus

                            Case EmployeeTimesheet.DayStatus.Approved

                                GridColumn.Image = AdvantageFramework.My.Resources.SmallCheckMarkImage

                            Case EmployeeTimesheet.DayStatus.Denied

                                GridColumn.Image = AdvantageFramework.My.Resources.TimesheetDeniedImage

                            Case EmployeeTimesheet.DayStatus.Pending

                                GridColumn.Image = AdvantageFramework.My.Resources.TimesheetPendingImage

                            Case EmployeeTimesheet.DayStatus.PostPeriodClosed

                                GridColumn.Image = AdvantageFramework.My.Resources.TimesheetPostPeriodLockedImage

                        End Select

                        GridColumn.ImageAlignment = System.Drawing.StringAlignment.Near
                        GridColumn.ToolTip = AdvantageFramework.StringUtilities.GetNameAsWords(DateColumnDayStatus.ToString)

                    End If

                    GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

                    GridGroupSummaryItem.FieldName = GridColumn.FieldName
                    GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn

                    DataGridViewForm_TimesheetEntries.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

                    GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                    GridColumn.SummaryItem.DisplayFormat = "{0:N2}"
                    GridColumn.AllowSummaryMenu = False

                    If TypeOf GridColumn.ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox Then

                        SubItemTextBox = DirectCast(GridColumn.ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemTextBox)

                        If DateColumnEditable = False Then

                            SubItemTextBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor

                        Else

                            SubItemTextBox.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard

                        End If

                    End If

                End If

                GridColumn.Caption = Caption

            Next

        End Sub
        Private Sub LoadStoredLayout()

            'objects
            Dim IsCommentsColumn As Boolean = False
            Dim TotalGridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim GridGroupSummaryItem As DevExpress.XtraGrid.GridGroupSummaryItem = Nothing

            If DataGridViewForm_TimesheetEntries.Columns("Total") Is Nothing Then

                TotalGridColumn = DataGridViewForm_TimesheetEntries.Columns.Add()

                TotalGridColumn.Name = "Total"
                TotalGridColumn.FieldName = "Total"
                TotalGridColumn.Caption = "Total"
                TotalGridColumn.UnboundType = DevExpress.Data.UnboundColumnType.Decimal
                TotalGridColumn.OptionsColumn.AllowFocus = False
                TotalGridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                TotalGridColumn.DisplayFormat.FormatString = "N2"
                TotalGridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                TotalGridColumn.SummaryItem.DisplayFormat = "{0:N2}"
                TotalGridColumn.AllowSummaryMenu = False

            End If

            'If DataGridViewForm_TimesheetEntries.Columns("HoursRemaining") IsNot Nothing Then

            '    GridGroupSummaryItem = New DevExpress.XtraGrid.GridGroupSummaryItem

            '    GridGroupSummaryItem.FieldName = GridColumn.FieldName
            '    GridGroupSummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            '    GridGroupSummaryItem.ShowInGroupColumnFooter = GridColumn

            '    DataGridViewForm_TimesheetEntries.CurrentView.GroupSummary.Add(GridGroupSummaryItem)

            '    GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
            '    GridColumn.SummaryItem.DisplayFormat = "{0:N2}"
            '    GridColumn.AllowSummaryMenu = False

            'End If

            If AdvantageFramework.WinForm.Presentation.Controls.LoadMinimalDataGridViewLayout(_Session, DataGridViewForm_TimesheetEntries, Database.Entities.GridAdvantageType.EmployeeTimesheet) Then

                For Each GridColumn In DataGridViewForm_TimesheetEntries.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If IsDateColumn(GridColumn.FieldName, False) Then

                        GridColumn.Visible = IsDateColumnVisible(GridColumn.FieldName)

                    ElseIf GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString OrElse
                           GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryDescription.ToString Then

                        If DataGridViewForm_TimesheetEntries.Columns(GridColumn.FieldName) IsNot Nothing Then

                            GridColumn.Visible = _UseProductCategory AndAlso DataGridViewForm_TimesheetEntries.Columns(GridColumn.FieldName).Visible

                        Else

                            GridColumn.Visible = _UseProductCategory

                        End If

                    ElseIf GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString Then

                        GridColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum

                    Else

                        If DataGridViewForm_TimesheetEntries.Columns(GridColumn.FieldName) IsNot Nothing Then

                            GridColumn.Visible = DataGridViewForm_TimesheetEntries.Columns(GridColumn.FieldName).Visible

                        End If

                    End If

                Next

            End If

        End Sub
        Private Function ShowNewEntryMessage(ByVal DataKey As String, ByRef Message As String) As Boolean
            Dim ReturnValue As Boolean = False

            Try

                If DataKey.Contains("|") = True Then

                    Dim ar() As String

                    ar = DataKey.Split("|") '"INSERT_SUCCESS|4129|1|8.000|120.000|0|-15|Warning, your time entry will cause the total hours posted to exceed the approved estimate amount for the function."

                    If ar IsNot Nothing AndAlso ar.Length > 7 Then
                        If ar(6) IsNot Nothing AndAlso ar(7) IsNot Nothing Then

                            Select Case CType(ar(6), Integer)
                                Case -15, -16, -17

                                    ReturnValue = True
                                    Message = ar(7)

                            End Select

                        End If
                    End If

                End If

            Catch ex As Exception
            End Try

            Return ReturnValue

        End Function

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim EmployeeTimeID As Integer = Nothing
            Dim EmployeeTimeDetailID As Integer = Nothing
            Dim ReturnMessage As String = ""
            Dim MessageList As Generic.List(Of String) = Nothing
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate = Nothing

            Try

                DataGridViewForm_TimesheetEntries.CurrentView.CloseEditorForUpdating()
                DataGridViewCopyFromTemplate_Templates.CurrentView.CloseEditorForUpdating()

                If DataGridViewForm_TimesheetEntries.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid time entries. "

                End If

                If DataGridViewCopyFromTemplate_Templates.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid time templates. "

                End If

                If ErrorMessage = "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each TimesheetEntry In DataGridViewForm_TimesheetEntries.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)()

                            For DayNumber = 1 To 7

                                SaveTimesheetEntry(DbContext, DayNumber, TimesheetEntry)

                            Next

                        Next

                        If _ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(_EstimateApprovalMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show(_EstimateApprovalMessage)

                            _ShowEstimateApprovalMessage = False

                        End If

                        CheckTimesheetHours(False)

                        AdvantageFramework.EmployeeTimesheet.DeleteMissingTimeDetail(DbContext, _Timesheet.EmployeeCode)
                        AdvantageFramework.EmployeeTimesheet.ProcessMissingTime(_Session, _Timesheet.EmployeeCode, _Timesheet.StartDate)

                        For Each EmployeeTimeTemplateClass In DataGridViewCopyFromTemplate_Templates.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeTimeTemplate)()

                            EmployeeTimeTemplate = AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.LoadByID(DbContext, EmployeeTimeTemplateClass.ID)

                            If EmployeeTimeTemplate IsNot Nothing Then

                                EmployeeTimeTemplate.EmployeeHours = EmployeeTimeTemplateClass.EmployeeHours
                                EmployeeTimeTemplate.DefaultComment = EmployeeTimeTemplateClass.Comment
                                EmployeeTimeTemplate.FunctionCode = EmployeeTimeTemplateClass.FunctionCode
                                EmployeeTimeTemplate.DepartmentTeamCode = EmployeeTimeTemplateClass.DepartmentTeamCode
                                EmployeeTimeTemplate.ProductCategoryCode = EmployeeTimeTemplateClass.ProductCategoryCode

                                AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.Update(DbContext, EmployeeTimeTemplate)

                            End If

                        Next

                    End Using

                    Saved = True

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim DayHours As Decimal? = Nothing
            Dim AllDeleted As Boolean = True
            Dim HasHours As Boolean = False

            If DataGridViewForm_TimesheetEntries.HasASelectedRow Then

                DataGridViewForm_TimesheetEntries.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each RowHandlesAndDataBoundItem In DataGridViewForm_TimesheetEntries.GetAllSelectedRowsRowHandlesAndDataBoundItems

                                Try

                                    TimesheetEntry = RowHandlesAndDataBoundItem.Value

                                Catch ex As Exception
                                    TimesheetEntry = Nothing
                                End Try

                                If TimesheetEntry IsNot Nothing Then

                                    For DayNumber = 1 To 7

                                        HasHours = False

                                        Select Case DayNumber

                                            Case 1

                                                DayHours = TimesheetEntry.Day1Hours
                                                TimesheetEntry.Day1Hours = Nothing

                                            Case 2

                                                DayHours = TimesheetEntry.Day2Hours
                                                TimesheetEntry.Day2Hours = Nothing

                                            Case 3

                                                DayHours = TimesheetEntry.Day3Hours
                                                TimesheetEntry.Day3Hours = Nothing

                                            Case 4

                                                DayHours = TimesheetEntry.Day4Hours
                                                TimesheetEntry.Day4Hours = Nothing

                                            Case 5

                                                DayHours = TimesheetEntry.Day5Hours
                                                TimesheetEntry.Day5Hours = Nothing

                                            Case 6

                                                DayHours = TimesheetEntry.Day6Hours
                                                TimesheetEntry.Day6Hours = Nothing

                                            Case 7

                                                DayHours = TimesheetEntry.Day7Hours
                                                TimesheetEntry.Day7Hours = Nothing

                                        End Select

                                        If DayHours.HasValue Then

                                            If SaveTimesheetEntry(DbContext, DayNumber, TimesheetEntry) = False Then

                                                Select Case DayNumber

                                                    Case 1

                                                        TimesheetEntry.Day1Hours = DayHours

                                                    Case 2

                                                        TimesheetEntry.Day2Hours = DayHours

                                                    Case 3

                                                        TimesheetEntry.Day3Hours = DayHours

                                                    Case 4

                                                        TimesheetEntry.Day4Hours = DayHours

                                                    Case 5

                                                        TimesheetEntry.Day5Hours = DayHours

                                                    Case 6

                                                        TimesheetEntry.Day6Hours = DayHours

                                                    Case 7

                                                        TimesheetEntry.Day7Hours = DayHours

                                                End Select

                                                AllDeleted = False

                                            End If

                                        End If

                                    Next

                                    If AllDeleted Then

                                        DataGridViewForm_TimesheetEntries.CurrentView.DeleteFromDataSource(TimesheetEntry)

                                    End If

                                End If

                            Next

                        End Using

                    Catch ex As Exception
                        ErrorMessage = "Failed trying to delete from the database. Please contact software support."
                    End Try

                    Me.CloseWaitForm()

                End If

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function LoadControl(ByVal EmployeeCode As String, ByVal StartDate As Date, ByVal EndDate As Date) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim ErrorMessage As String = Nothing

            If StartDate.AddDays(6) < EndDate Then

                EndDate = StartDate.AddDays(6)

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _Timesheet = New AdvantageFramework.EmployeeTimesheet.Classes.Timesheet(DbContext, EmployeeCode, StartDate, EndDate, "", _Session.UserCode)

                If _Timesheet IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.Load(DbContext).SupervisorApprovalActive.GetValueOrDefault(0) = 1 Then

                        'SetApprovals(_Timesheet.TimeSheetEntries)

                    End If

                    If StartDate = EndDate Then

                        DataGridViewForm_TimesheetEntries.ItemDescription = "Record(s) for " & StartDate.ToShortDateString

                    Else

                        DataGridViewForm_TimesheetEntries.ItemDescription = "Record(s) from " & StartDate.ToShortDateString & " - " & EndDate.ToShortDateString

                    End If

                    'LoadStoredLayout()

                    DataGridViewForm_TimesheetEntries.DataSource = _Timesheet.TimeSheetEntries

                    GroupTimesheet()

                    _CanCopyTimesheet = CBool(AdvantageFramework.Database.Procedures.Agency.Load(DbContext).CopyTimesheetFeature.GetValueOrDefault(0))

                    If _Timesheet.Day1Status <> EmployeeTimesheet.DayStatus.Open AndAlso _Timesheet.Day2Status <> EmployeeTimesheet.DayStatus.Open AndAlso
                        _Timesheet.Day3Status <> EmployeeTimesheet.DayStatus.Open AndAlso _Timesheet.Day4Status <> EmployeeTimesheet.DayStatus.Open AndAlso
                        _Timesheet.Day5Status <> EmployeeTimesheet.DayStatus.Open AndAlso _Timesheet.Day6Status <> EmployeeTimesheet.DayStatus.Open AndAlso
                        _Timesheet.Day7Status <> EmployeeTimesheet.DayStatus.Open Then

                        DataGridViewForm_TimesheetEntries.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                    End If

                    LoadCopyFromOptions(Nothing)

                Else

                    Loaded = False

                End If

                AdvantageFramework.EmployeeTimesheet.DeletePriorZeroHours(DbContext, EmployeeCode, StartDate, ErrorMessage)

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _Loaded = Loaded

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            DataGridViewForm_TimesheetEntries.CancelNewItemRow()
            DataGridViewForm_TimesheetEntries.DataSource = Nothing
            DataGridViewCopyFromProject_ProjectTemplates.DataSource = Nothing
            DataGridViewCopyFromTemplate_Templates.DataSource = Nothing
            DataGridViewCopyFromTimesheet_TimesheetTemplates.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function OpenTimesheetSettings()

            'objects
            Dim Changed As Boolean = False

            If AdvantageFramework.Employee.Presentation.TimesheetSettingsDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                Changed = True

            End If

            OpenTimesheetSettings = Changed

        End Function
        Public Function CopyItem()

            'objects
            Dim Copied As Boolean = False
            Dim ErrorMessage As String = ""

            If ExpandablePanelControl_Options.Expanded = False Then

                ExpandablePanelControl_Options.Expanded = True

            Else

                If TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromProjectTab Then

                    Copied = CopyFromProjects(ErrorMessage)

                ElseIf TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromTemplateTab Then

                    Copied = CopyFromTemplates(ErrorMessage)

                ElseIf TabControlOptions_Options.SelectedTab Is TabItemOptions_CopyFromTimesheetTab Then

                    Copied = CopyFromTimesheets(ErrorMessage)

                End If

            End If

            If ErrorMessage <> "" Then

                Throw New Exception(ErrorMessage)

            End If

            CopyItem = Copied

        End Function
        Public Function DeleteCopyItem() As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = Nothing

            If Me.CurrentCopyFromDataGridView Is DataGridViewCopyFromTemplate_Templates Then

                If DataGridViewCopyFromTemplate_Templates.HasASelectedRow Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each EmployeeTimeTemplateClass In DataGridViewCopyFromTemplate_Templates.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EmployeeTimeTemplate)()

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM [dbo].[EMP_TIME_TMPLT] WHERE [EMP_TIME_TMPLT_ID] = {0}", EmployeeTimeTemplateClass.ID))

                                    DataGridViewCopyFromTemplate_Templates.CurrentView.DeleteFromDataSource(EmployeeTimeTemplateClass)

                                Next

                            End Using

                        Catch ex As Exception
                            ErrorMessage = "Failed trying to delete from the database. Please contact software support."
                        End Try

                        Me.CloseWaitForm()

                    End If

                End If

            End If

            DeleteCopyItem = Deleted

        End Function
        Public Sub ResetCopyOptions()

            TabControlOptions_Options.SelectedTab.Tag = Nothing

            LoadCopyFromOptions(TabControlOptions_Options.SelectedTab)

        End Sub
        Public Function AddNewCommentView()

            'objects
            Dim Added As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                If AdvantageFramework.Employee.Presentation.EmployeeTimesheeCommentViewDialog.ShowFormDialog(_Timesheet.EmployeeCode, _Timesheet.StartDate, _Timesheet.EndDate) = Windows.Forms.DialogResult.OK Then

                    Added = True

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem adding new time. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            AddNewCommentView = Added

        End Function
        Public Function SetApproval() As Boolean

            'objects
            Dim ApprovalsSet As Boolean = False

            If AdvantageFramework.Employee.Presentation.EmployeeTimesheetSubmitDialog.ShowFormDialog(_Timesheet.EmployeeCode, _Timesheet.StartDate, _Timesheet.EndDate) = Windows.Forms.DialogResult.OK Then

                ApprovalsSet = True

            End If

            SetApproval = ApprovalsSet

        End Function
        Public Sub ViewDirectTimeDetails()

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim EmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing

            If Me.IsDirectTimeSelected AndAlso DataGridViewForm_TimesheetEntries.HasOnlyOneSelectedRow Then

                TimesheetEntry = DataGridViewForm_TimesheetEntries.GetFirstSelectedRowDataBoundItem

                AdvantageFramework.Employee.Presentation.TimesheetDetailsDialog.ShowFormDialog(TimesheetEntry.JobNumber, TimesheetEntry.JobCompNumber, TimesheetEntry.FunctionCode, _Timesheet.EmployeeCode)

            End If

        End Sub
        Public Sub Print()

            AdvantageFramework.Employee.Presentation.EmployeeTimesheetPrintOptionsDialog.ShowFormDialog(_Timesheet.EmployeeCode, _Timesheet.StartDate, _Timesheet.EndDate)

        End Sub
        Public Sub ShowCustomization()

            DataGridViewForm_TimesheetEntries.OptionsMenu.EnableColumnMenu = True
            DataGridViewForm_TimesheetEntries.OptionsCustomization.AllowColumnMoving = True

            For Each GridColumn In DataGridViewForm_TimesheetEntries.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                If GridColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString Then

                    GridColumn.OptionsColumn.AllowMove = True
                    GridColumn.OptionsColumn.AllowShowHide = True
                    GridColumn.OptionsColumn.ShowInCustomizationForm = True

                Else

                    GridColumn.OptionsColumn.AllowMove = False
                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

            DataGridViewForm_TimesheetEntries.CurrentView.ShowCustomization()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub TimesheetControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub GridLookUpEdit_JobComponent_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs)

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobCompNumber As Short = Nothing

            Try

                GridLookUpEdit = sender

            Catch ex As Exception
                GridLookUpEdit = Nothing
            End Try

            If GridLookUpEdit IsNot Nothing AndAlso GridLookUpEdit.EditValue IsNot Nothing Then

                Try

                    JobNumber = CInt(GridLookUpEdit.Properties.View.GetFocusedRowCellValue("JobNumber"))

                Catch ex As Exception
                    JobNumber = Nothing
                End Try

                If JobNumber <> 0 Then

                    JobCompNumber = GridLookUpEdit.EditValue

                    If TypeOf GridLookUpEdit.Parent.Parent Is AdvantageFramework.WinForm.Presentation.Controls.DataGridView Then

                        DirectCast(GridLookUpEdit.Parent.Parent, AdvantageFramework.WinForm.Presentation.Controls.DataGridView).CurrentView.SetFocusedRowCellValue("JobNumber", JobNumber)
                        DirectCast(GridLookUpEdit.Parent.Parent, AdvantageFramework.WinForm.Presentation.Controls.DataGridView).CurrentView.SetFocusedRowCellValue("JobCompNumber", JobCompNumber)

                    Else

                        DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString, JobNumber)
                        DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString, JobCompNumber)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_TimesheetEntries.AddNewRowEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim TimeEntered As Boolean = False

            If TypeOf RowObject Is AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry Then

                Me.ShowWaitForm("Processing...")

                TimesheetEntry = DirectCast(RowObject, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For DayNumber = 1 To 7

                        SaveTimesheetEntry(DbContext, DayNumber, TimesheetEntry)

                    Next

                    If _ShowEstimateApprovalMessage = True AndAlso String.IsNullOrWhiteSpace(_EstimateApprovalMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(_EstimateApprovalMessage)

                        _ShowEstimateApprovalMessage = False

                    End If

                    CheckTimesheetHours(True)
                    TimesheetEntry.SetIsNewRecord(False)
                    AdvantageFramework.EmployeeTimesheet.DeleteMissingTimeDetail(DbContext, _Timesheet.EmployeeCode)
                    AdvantageFramework.EmployeeTimesheet.ProcessMissingTime(_Session, _Timesheet.EmployeeCode, _Timesheet.StartDate)

                    RaiseEvent RecordAddedEvent()

                    LoadControl(_Timesheet.EmployeeCode, _Timesheet.StartDate, _Timesheet.EndDate)

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TimesheetEntries.DataSourceChangedEvent

            'objects
            Dim TotalGridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            DataGridViewForm_TimesheetEntries.CurrentView.GroupSummary.Clear()

            If DataGridViewForm_TimesheetEntries.Columns IsNot Nothing AndAlso DataGridViewForm_TimesheetEntries.Columns.Count > 0 Then

                LoadTimesheetSettings()

                ModifyDateColumns()

                SetTotalGridColumnExpression()

                SetRequiredColumnOrder()

                SetAvailableColumnsForPopupMenu()

                LoadStoredLayout()

                DataGridViewForm_TimesheetEntries.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_TimesheetEntries.QueryPopupNeedDatasourceEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim FunctionCodes As String() = Nothing
            Dim EmployeeDepartments As String() = Nothing
            Dim IsIndirectTime As Boolean = True
            Dim LoadFunctionsByEmployee As Boolean = False
            Dim EmployeeUserIDs As Integer() = Nothing
            Dim JobNumbers As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString Then

                        OverrideDefaultDatasource = True

                        Try

                            TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(DataGridViewForm_TimesheetEntries.CurrentView.FocusedRowHandle)

                        Catch ex As Exception
                            TimesheetEntry = Nothing
                        End Try

                        If TimesheetEntry IsNot Nothing Then

                            IsIndirectTime = TimesheetEntry.IsIndirectTime

                        End If

                        Datasource = AdvantageFramework.EmployeeTimesheet.LoadTimeCategorOrFunctionListByEmployee(_Session, _Timesheet.EmployeeCode, IsIndirectTime)

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString Then

                        OverrideDefaultDatasource = True

                        Datasource = AdvantageFramework.EmployeeTimesheet.LoadEmployeeDepartments(_Session, _Timesheet.EmployeeCode)

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString Then

                        OverrideDefaultDatasource = True

                        'Datasource = AdvantageFramework.Database.Procedures.Client.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                        Datasource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString Then

                        OverrideDefaultDatasource = True

                        ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)

                        If String.IsNullOrEmpty(ClientCode) = False Then

                            'Datasource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '             Where Entity.ClientCode = ClientCode
                            '             Select Entity

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                         Where Entity.ClientCode = ClientCode
                                         Select Entity

                        Else

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                         Select Entity

                        End If

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString Then

                        OverrideDefaultDatasource = True

                        ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)

                        If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                            'Datasource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '             Where Entity.ClientCode = ClientCode AndAlso
                            '                   Entity.DivisionCode = DivisionCode
                            '             Select Entity

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                         Where Entity.ClientCode = ClientCode AndAlso
                                               Entity.DivisionCode = DivisionCode
                                         Select Entity

                        ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                         Where Entity.ClientCode = ClientCode
                                         Select Entity

                        Else

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                         Select Entity

                        End If

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString Then

                        OverrideDefaultDatasource = True

                        ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)

                        If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.ProductCategory.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)
                                         Where Entity.IsInactive Is Nothing OrElse
                                               Entity.IsInactive = 0
                                         Select Entity

                        End If

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString Then

                        OverrideDefaultDatasource = True

                        ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)

                        'If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                        '    Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                        '                 Where Entity.ClientCode = ClientCode AndAlso
                        '                       Entity.DivisionCode = DivisionCode AndAlso
                        '                       Entity.ProductCode = ProductCode
                        '                 Select Entity

                        'ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                        '    Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                        '                 Where Entity.ClientCode = ClientCode AndAlso
                        '                       Entity.DivisionCode = DivisionCode
                        '                 Select Entity

                        'ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                        '    Datasource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                        '                 Where Entity.ClientCode = ClientCode
                        '                 Select Entity

                        'Else

                        'Datasource = AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                        Datasource = (From Item In AdvantageFramework.EmployeeTimesheet.Methods.LoadAvailableJobs(DbContext, ClientCode, DivisionCode, ProductCode)
                                      Select New With {.ClientCode = Item.ClientCode,
                                                           .DivisionCode = Item.DivisionCode,
                                                           .ProductCode = Item.ProductCode,
                                                           .Number = Item.Number,
                                                           .Description = Item.Description}).OrderByDescending(Function(Job) Job.Number).ToList

                        'End If

                    ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString Then

                        OverrideDefaultDatasource = True

                        ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                        DivisionCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
                        ProductCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)
                        JobNumber = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString)

                        If JobNumber > 0 Then

                            Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                                         Where Entity.JobNumber = JobNumber
                                         Select Entity

                        Else

                            'If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                            '    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '                  Where Entity.ClientCode = ClientCode AndAlso
                            '                        Entity.DivisionCode = DivisionCode AndAlso
                            '                        Entity.ProductCode = ProductCode
                            '                  Select Entity.Number).ToArray

                            'ElseIf String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False Then

                            '    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '                  Where Entity.ClientCode = ClientCode AndAlso
                            '                        Entity.DivisionCode = DivisionCode
                            '                  Select Entity.Number).ToArray

                            'ElseIf String.IsNullOrEmpty(ClientCode) = False Then

                            '    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '                  Where Entity.ClientCode = ClientCode
                            '                  Select Entity.Number).ToArray

                            'Else

                            '    JobNumbers = (From Entity In AdvantageFramework.Database.Procedures.Job.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '                  Select Entity.Number).ToArray

                            'End If

                            'Datasource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadByUserForEmployeeCode(DbContext, SecurityDbContext, _Session.UserCode, _Timesheet.EmployeeCode, True)
                            '             Where JobNumbers.Contains(Entity.JobNumber)
                            '             Select Entity

                            Datasource = (From Item In AdvantageFramework.EmployeeTimesheet.LoadAvailableJobComponents(DbContext, ClientCode, DivisionCode, ProductCode, JobNumber)
                                          Select New With {.ClientCode = Item.ClientCode,
                                                           .ClientName = Item.ClientName,
                                                           .DivisionCode = Item.DivisionCode,
                                                           .DivisionName = Item.DivisionName,
                                                           .ProductCode = Item.ProductCode,
                                                           .ProductName = Item.ProductDescription,
                                                           .JobNumber = Item.JobNumber,
                                                           .JobDescription = Item.JobDescription,
                                                           .Number = Item.JobComponentNumber,
                                                           .Description = Item.JobComponentDescription}).OrderByDescending(Function(Job) Job.JobNumber).ToList

                        End If

                    End If

                    If OverrideDefaultDatasource = True AndAlso Datasource IsNot Nothing Then

                        Datasource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(Datasource)

                    End If

                End Using

            End Using


        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_TimesheetEntries.ShowingEditorEvent

            'objects
            Dim Cancel As Boolean = False
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Hours As String = Nothing
            Dim IsNewItemRow As Boolean = False
            Dim FieldName As String = Nothing

            FieldName = DataGridViewForm_TimesheetEntries.CurrentView.FocusedColumn.FieldName
            IsNewItemRow = DataGridViewForm_TimesheetEntries.CurrentView.IsNewItemRow(DataGridViewForm_TimesheetEntries.CurrentView.FocusedRowHandle)

            Select Case FieldName

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Hours.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Hours.ToString

                    Cancel = False

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day1Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day2Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day3Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day4Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day5Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day6Comments.ToString,
                     AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Day7Comments.ToString

                    Hours = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellDisplayText(FieldName.Replace("Comments", "Hours"))

                    If String.IsNullOrEmpty(Hours) Then

                        Cancel = True

                    End If

                Case AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCategoryCode.ToString

                    ClientCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewForm_TimesheetEntries.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)

                    If IsNewItemRow = False Then

                        Cancel = True

                    ElseIf String.IsNullOrEmpty(ClientCode) OrElse String.IsNullOrEmpty(DivisionCode) OrElse String.IsNullOrEmpty(ProductCode) Then

                        Cancel = True

                    End If

                Case Else

                    If IsNewItemRow = False Then

                        Cancel = True

                    End If

            End Select

            e.Cancel = Cancel

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TimesheetEntries.SelectionChangedEvent

            ModifyCommentsColumn()
            RaiseEvent SelectedEntryChangedEvent()

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TimesheetEntries.ShownEditorEvent

            If DataGridViewForm_TimesheetEntries.CurrentView.FocusedColumn.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString Then

                If TypeOf DataGridViewForm_TimesheetEntries.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    AddHandler DataGridViewForm_TimesheetEntries.CurrentView.ActiveEditor.EditValueChanged, AddressOf GridLookUpEdit_JobComponent_EditValueChanged

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TimesheetEntries.CellValueChangedEvent

            'objects
            Dim ClearFunction As Boolean = False
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobNumber.ToString OrElse
               e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.JobCompNumber.ToString Then

                Try

                    TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    TimesheetEntry = Nothing
                End Try

                If TimesheetEntry IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If String.IsNullOrEmpty(TimesheetEntry.FunctionCode) = False Then

                            If TimesheetEntry.IsIndirectTime = True Then

                                ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext)
                                                     Where Entity.Code = TimesheetEntry.FunctionCode
                                                     Select Entity).Any

                            Else

                                ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.Function.Load(DbContext)
                                                     Where Entity.Code = TimesheetEntry.FunctionCode
                                                     Select Entity).Any

                            End If

                            If ClearFunction Then

                                DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString, Nothing)

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CustomUnboundColumnDataEvent(ByVal Sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles DataGridViewForm_TimesheetEntries.CustomUnboundColumnDataEvent

            'objects
            Dim Value As String() = Nothing
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim Client As String = Nothing
            Dim Division As String = Nothing
            Dim Product As String = Nothing
            Dim Job As String = Nothing

            If e.IsGetData() Then

                If e.Column.FieldName = "CustomGroupByKey" Then

                    Try

                        TimesheetEntry = DirectCast(e.Row, AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry)

                    Catch ex As Exception
                        TimesheetEntry = Nothing
                    End Try

                    If TimesheetEntry IsNot Nothing Then

                        If TimesheetEntry.IsIndirectTime = False Then

                            Client = "Client: " & TimesheetEntry.ClientName
                            Division = "Division: " & TimesheetEntry.DivisionName
                            Product = "Product: " & TimesheetEntry.ProductName
                            Job = "Job: " & TimesheetEntry.JobNumber.ToString

                            Select Case _TimesheetGroupByOption

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.Client

                                    Value = {Client}

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivision

                                    Value = {Client, Division}

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProduct

                                    Value = {Client, Division, Product}

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientJob

                                    Value = {Client, Job}

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionJob

                                    Value = {Client, Division, Job}

                                Case AdvantageFramework.EmployeeTimesheet.TimesheetGroupByOptions.ClientDivisionProductJob

                                    Value = {Client, Division, Product, Job}

                                Case EmployeeTimesheet.TimesheetGroupByOptions.None

                                    Value = {""}

                            End Select

                        Else

                            Value = {""}

                        End If

                        If Value IsNot Nothing Then

                            e.Value = String.Join(" | ", Value)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewForm_TimesheetEntries.CustomDrawGroupRowEvent

            'object
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing

            Try

                GridGroupRowInfo = e.Info

            Catch ex As Exception

            End Try

            If GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = "CustomGroupByKey" Then

                    If GridGroupRowInfo.EditValue IsNot Nothing Then

                        GridGroupRowInfo.GroupText = GridGroupRowInfo.EditValue.ToString

                    Else

                        GridGroupRowInfo.GroupText = ""

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TimesheetEntries.NewItemRowCellValueChangedEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim DepartmentTeam As AdvantageFramework.Database.Entities.DepartmentTeam = Nothing

            Try

                TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                TimesheetEntry = Nothing
            End Try

            If TimesheetEntry IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If e.Column.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString Then

                        If String.IsNullOrEmpty(TimesheetEntry.FunctionCode) Then

                            If TimesheetEntry.IsIndirectTime = False Then

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, _Timesheet.DefaultEmployeeFunctionCode)

                                If [Function] IsNot Nothing Then

                                    DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionCode.ToString, _Timesheet.DefaultEmployeeFunctionCode)
                                    DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.FunctionDescription.ToString, [Function].Description)

                                End If

                            End If

                        End If

                    End If

                    If e.Column.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString AndAlso
                        e.Column.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamDescription.ToString Then

                        If String.IsNullOrEmpty(TimesheetEntry.DepartmentTeamCode) Then

                            DepartmentTeam = AdvantageFramework.Database.Procedures.DepartmentTeam.LoadByDepartmentTeamCode(DbContext, _Timesheet.DefaultEmployeeDepartmentTeam)

                            If DepartmentTeam IsNot Nothing Then

                                DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamCode.ToString, _Timesheet.DefaultEmployeeDepartmentTeam)
                                DataGridViewForm_TimesheetEntries.CurrentView.SetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DepartmentTeamDescription.ToString, DepartmentTeam.Description)

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_TimesheetEntries.InitNewRowEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            Try

                TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                TimesheetEntry = Nothing
            End Try

            If TimesheetEntry IsNot Nothing Then

                TimesheetEntry.SetStartDate(_Timesheet.StartDate)

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_ColumnPositionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_TimesheetEntries.ColumnPositionChangedEvent

            SetRequiredColumnOrder()

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_TimesheetEntries.CustomRowCellEditEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing
            Dim RepositoryItemProgressBar As DevExpress.XtraEditors.Repository.RepositoryItemProgressBar = Nothing
            Dim ProgressType As AdvantageFramework.EmployeeTimesheet.ProgressTypes = EmployeeTimesheet.ProgressTypes.NotQuoted

            If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString Then

                Try

                    TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception

                End Try

                If TimesheetEntry IsNot Nothing Then

                    If TimesheetEntry.QuotedHours.GetValueOrDefault(0) > 0 Then

                        If TimesheetEntry.IsOverThreshold.GetValueOrDefault(False) = True Then

                            ProgressType = EmployeeTimesheet.ProgressTypes.OverThreshold

                        Else

                            ProgressType = EmployeeTimesheet.ProgressTypes.Quoted

                        End If

                    Else

                        ProgressType = EmployeeTimesheet.ProgressTypes.NotQuoted

                    End If

                    Try

                        RepositoryItemProgressBar = (From Entity In DataGridViewForm_TimesheetEntries.CurrentView.GridControl.RepositoryItems.OfType(Of DevExpress.XtraEditors.Repository.RepositoryItemProgressBar)()
                                                     Where Entity.Tag = ProgressType
                                                     Select Entity).FirstOrDefault

                    Catch ex As Exception

                    End Try

                    If RepositoryItemProgressBar IsNot Nothing Then

                        e.RepositoryItem = RepositoryItemProgressBar

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_TimesheetEntries.CustomColumnDisplayTextEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString Then

                TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(DataGridViewForm_TimesheetEntries.CurrentView.GetRowHandle(e.ListSourceRowIndex))

                If TimesheetEntry IsNot Nothing Then

                    If TimesheetEntry.QuotedHours.GetValueOrDefault(0) <= 0 Then

                        e.DisplayText = TimesheetEntry.ActualHours.GetValueOrDefault(0).ToString & " * "

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_RowCellStyleEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs) Handles DataGridViewForm_TimesheetEntries.RowCellStyleEvent

            'objects
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            If DataGridViewForm_TimesheetEntries.IsNewItemRow(e.RowHandle) = False Then

                If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString Then

                    TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(e.RowHandle)

                    If TimesheetEntry.QuotedHours.GetValueOrDefault(0) > 0 Then

                        If TimesheetEntry.IsOverThreshold Then

                            e.Appearance.ForeColor = _ColorList(System.Drawing.Color.Red)

                        Else

                            e.Appearance.ForeColor = _ColorList(System.Drawing.Color.Green)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_CustomDrawFooterCellEvent(e As DevExpress.XtraGrid.Views.Grid.FooterCellCustomDrawEventArgs) Handles DataGridViewForm_TimesheetEntries.CustomDrawFooterCellEvent

            If e.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.HoursRemaining.ToString Then

                e.Appearance.DrawString(e.Cache, "* denotes Posted", e.Bounds)
                e.Handled = True

            End If

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_PopupMenuClosing() Handles DataGridViewForm_TimesheetEntries.PopupMenuClosing

            SaveGridLayout()

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_FocusedColumnChangedEvent(e As DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs) Handles DataGridViewForm_TimesheetEntries.FocusedColumnChangedEvent

            ModifyCommentsColumn()

        End Sub
        Private Sub ToolTipControllerControl_ToolTip_GetActiveObjectInfo(sender As Object, e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles ToolTipControllerControl_ToolTip.GetActiveObjectInfo

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim TimesheetEntry As AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry = Nothing

            If e.SelectedControl Is DataGridViewForm_TimesheetEntries.CurrentView.GridControl Then

                GridHitInfo = DataGridViewForm_TimesheetEntries.CurrentView.CalcHitInfo(e.ControlMousePosition)

                If GridHitInfo.InRowCell Then

                    If GridHitInfo.Column.FieldName = AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.Progress.ToString Then

                        Try

                            TimesheetEntry = DataGridViewForm_TimesheetEntries.CurrentView.GetRow(GridHitInfo.RowHandle)

                        Catch ex As Exception

                        End Try

                        If TimesheetEntry IsNot Nothing Then

                            e.Info = New DevExpress.Utils.ToolTipControlInfo(GridHitInfo.RowHandle.ToString & " - " & GridHitInfo.Column.ToString, TimesheetEntry.QvAStatusMessage)

                        End If

                    End If

                End If

            End If

        End Sub

#Region "  Copy Options "

        Private Sub TabControlOptions_Options_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlOptions_Options.SelectedTabChanged

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

            End If

            RaiseEvent SelectedCopyOptionChangedEvent()

        End Sub
        Private Sub TabControlOptions_Options_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlOptions_Options.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

            End If

            LoadCopyFromOptions(e.NewTab)

        End Sub

#Region "   Timesheet Templates Grid "

        Private Sub DataGridViewCopyFromTimesheet_TimesheetTemplates_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.DataSourceChangedEvent

            'objects
            Dim FieldNames As String() = Nothing

            If DataGridViewCopyFromTimesheet_TimesheetTemplates.Columns.Count > 0 Then

                FieldNames = {AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.FunctionCode.ToString, AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.DeptTeamCode.ToString}

                For Each FieldName In FieldNames

                    Try

                        DirectCast(DataGridViewCopyFromTimesheet_TimesheetTemplates.Columns(FieldName).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                    Catch ex As Exception

                    End Try

                Next

            End If

        End Sub
        Private Sub DataGridViewCopyFromTimesheet_TimesheetTemplates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.QueryPopupNeedDatasourceEvent

            'objects
            Dim DayRecord As AdvantageFramework.EmployeeTimesheet.Classes.DayRecord = Nothing
            Dim IsIndirectTime As Boolean = True

            Try

                DayRecord = DataGridViewCopyFromTimesheet_TimesheetTemplates.CurrentView.GetFocusedRow

            Catch ex As Exception
                DayRecord = Nothing
            End Try

            If DayRecord IsNot Nothing Then

                If String.IsNullOrEmpty(DayRecord.ClientCode) = False OrElse
                    String.IsNullOrEmpty(DayRecord.DivisionCode) = False OrElse
                    String.IsNullOrEmpty(DayRecord.ProductCode) = False OrElse
                    DayRecord.JobNumber.HasValue OrElse
                    DayRecord.JobCompNumber.HasValue Then

                    IsIndirectTime = False

                End If

            End If

            Select Case FieldName

                Case AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.DeptTeamCode.ToString

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.EmployeeTimesheet.LoadEmployeeDepartments(_Session, _Timesheet.EmployeeCode)

                Case AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.FunctionCode.ToString

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.EmployeeTimesheet.LoadTimeCategorOrFunctionListByEmployee(_Session, _Timesheet.EmployeeCode, IsIndirectTime)

            End Select

        End Sub
        Private Sub DataGridViewCopyFromTimesheet_TimesheetTemplates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.SelectionChangedEvent

            RaiseEvent SelectedCopyOptionChangedEvent()

        End Sub
        Private Sub DataGridViewCopyFromTimesheet_TimesheetTemplates_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.ShowingEditorEvent

            If DataGridViewCopyFromTimesheet_TimesheetTemplates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.FunctionCode.ToString AndAlso
               DataGridViewCopyFromTimesheet_TimesheetTemplates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.EmployeeTimesheet.Classes.DayRecord.Properties.DeptTeamCode.ToString Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region "   Project Template Grid "

        Private Sub DataGridViewCopyFromProject_ProjectTemplates_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromProject_ProjectTemplates.DataSourceChangedEvent

            'objects
            Dim FieldNames As String() = Nothing

            If DataGridViewCopyFromProject_ProjectTemplates.Columns.Count > 0 Then

                FieldNames = {AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate.Properties.FunctionCode.ToString, AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate.Properties.DepartmentTeamCode.ToString}

                For Each FieldName In FieldNames

                    Try

                        DirectCast(DataGridViewCopyFromProject_ProjectTemplates.Columns(FieldName).ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).AllowNullInput = DevExpress.Utils.DefaultBoolean.False

                    Catch ex As Exception

                    End Try

                Next

            End If

        End Sub
        Private Sub DataGridViewCopyFromProject_ProjectTemplates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewCopyFromProject_ProjectTemplates.QueryPopupNeedDatasourceEvent

            'objects
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
            Dim EmployeeDepartments As String() = Nothing

            If FieldName = AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate.Properties.DepartmentTeamCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, _Timesheet.EmployeeCode)

                    If Employee IsNot Nothing Then

                        EmployeeDepartments = (From Entity In AdvantageFramework.Database.Procedures.EmployeeDepartment.LoadByEmployeeCode(DbContext, Employee.Code)
                                               Select Entity.DepartmentTeamCode).ToArray

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.Load(DbContext)
                                      Where EmployeeDepartments.Contains(Entity.Code)
                                      Select New With {.Code = Entity.Code,
                                                       .Description = Entity.Description & If(Entity.Code = Employee.DepartmentTeamCode, "*", "")}).ToList

                    End If

                End Using

            ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate.Properties.FunctionCode.ToString Then

                Dim DayRecord As AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate = Nothing
                Dim IsIndirectTime As Boolean = True

                Try

                    DayRecord = DataGridViewCopyFromProject_ProjectTemplates.CurrentView.GetFocusedRow

                Catch ex As Exception
                    DayRecord = Nothing
                End Try

                If DayRecord IsNot Nothing Then

                    If String.IsNullOrEmpty(DayRecord.ClientCode) = False OrElse
                    String.IsNullOrEmpty(DayRecord.DivisionCode) = False OrElse
                    String.IsNullOrEmpty(DayRecord.ProductCode) = False OrElse
                    DayRecord.JobNumber > 0 OrElse
                    DayRecord.JobCompNumber > 0 Then

                        IsIndirectTime = False

                    End If

                End If

                OverrideDefaultDatasource = True

                Datasource = AdvantageFramework.EmployeeTimesheet.LoadTimeCategorOrFunctionListByEmployee(_Session, _Timesheet.EmployeeCode, IsIndirectTime)

            ElseIf FieldName = AdvantageFramework.EmployeeTimesheet.Classes.ProjectTemplate.Properties.ProductCategoryCode.ToString And _UseProductCategory Then

                OverrideDefaultDatasource = True

                Dim ClientCode As String = Nothing
                Dim DivisionCode As String = Nothing
                Dim ProductCode As String = Nothing

                Try

                    ClientCode = DataGridViewCopyFromProject_ProjectTemplates.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewCopyFromProject_ProjectTemplates.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewCopyFromProject_ProjectTemplates.CurrentView.GetFocusedRowCellValue(AdvantageFramework.EmployeeTimesheet.Classes.TimesheetEntry.Properties.ProductCode.ToString)

                Catch ex As Exception

                End Try

                If String.IsNullOrEmpty(ClientCode) = False AndAlso String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.ProductCategory.LoadAllActive(DbContext)
                                      Where Entity.ClientCode = ClientCode AndAlso
                                            Entity.DivisionCode = DivisionCode AndAlso
                                            Entity.ProductCode = ProductCode
                                      Select Entity).ToList



                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewCopyFromProject_ProjectTemplates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromProject_ProjectTemplates.SelectionChangedEvent

            RaiseEvent SelectedCopyOptionChangedEvent()

        End Sub

#End Region

#Region "  Templates Grid "

        Private Sub DataGridViewCopyFromTemplate_Templates_AddNewRowEvent(RowObject As Object) Handles DataGridViewCopyFromTemplate_Templates.AddNewRowEvent

            'objects
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Entities.EmployeeTimeTemplate = Nothing
            Dim EmployeeTimeTemplateClass As AdvantageFramework.Database.Classes.EmployeeTimeTemplate = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.EmployeeTimeTemplate Then

                Me.ShowWaitForm("Processing...")

                EmployeeTimeTemplateClass = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EmployeeTimeTemplate = New AdvantageFramework.Database.Entities.EmployeeTimeTemplate With {.EmployeeCode = EmployeeTimeTemplateClass.EmployeeCode,
                                                                                                               .JobNumber = EmployeeTimeTemplateClass.JobNumber,
                                                                                                               .JobComponentNumber = EmployeeTimeTemplateClass.JobCompNumber,
                                                                                                               .FunctionCode = EmployeeTimeTemplateClass.FunctionCode,
                                                                                                               .DefaultComment = EmployeeTimeTemplateClass.Comment,
                                                                                                               .DepartmentTeamCode = EmployeeTimeTemplateClass.DepartmentTeamCode,
                                                                                                               .ProductCategoryCode = EmployeeTimeTemplateClass.ProductCategoryCode,
                                                                                                               .EmployeeHours = EmployeeTimeTemplateClass.EmployeeHours,
                                                                                                               .ApplyToDays = EmployeeTimeTemplateClass.ApplyToDays}

                    EmployeeTimeTemplate.DbContext = DbContext

                    AdvantageFramework.Database.Procedures.EmployeeTimeTemplate.Insert(DbContext, EmployeeTimeTemplate)

                    Me.CloseWaitForm()

                End Using

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewCopyFromTemplate_Templates.CellValueChangedEvent

            'objects
            Dim ClearFunction As Boolean = False
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Classes.EmployeeTimeTemplate = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ClientCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.DivisionCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCode.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.JobNumber.ToString OrElse
               e.Column.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.JobCompNumber.ToString Then

                Try

                    EmployeeTimeTemplate = DataGridViewCopyFromTemplate_Templates.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    EmployeeTimeTemplate = Nothing
                End Try

                If EmployeeTimeTemplate IsNot Nothing AndAlso String.IsNullOrEmpty(EmployeeTimeTemplate.FunctionCode) = False Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If String.IsNullOrEmpty(EmployeeTimeTemplate.ClientCode) = False OrElse
                            String.IsNullOrEmpty(EmployeeTimeTemplate.DivisionCode) = False OrElse
                            String.IsNullOrEmpty(EmployeeTimeTemplate.ProductCode) = False OrElse
                            EmployeeTimeTemplate.JobNumber.HasValue OrElse
                            EmployeeTimeTemplate.JobCompNumber.HasValue Then

                            ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.Function.Load(DbContext)
                                                 Where Entity.Code = EmployeeTimeTemplate.FunctionCode
                                                 Select Entity).Any

                        Else

                            ClearFunction = Not (From Entity In AdvantageFramework.Database.Procedures.IndirectCategory.Load(DbContext)
                                                 Where Entity.Code = EmployeeTimeTemplate.FunctionCode
                                                 Select Entity).Any

                        End If

                    End Using

                    If ClearFunction Then

                        DataGridViewCopyFromTemplate_Templates.CurrentView.SetFocusedRowCellValue(AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.FunctionCode.ToString, Nothing)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewCopyFromTemplate_Templates.CustomDrawGroupRowEvent

            'object
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing

            Try

                GridGroupRowInfo = e.Info

            Catch ex As Exception

            End Try

            If GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = "CustomGroupByKey" Then

                    If GridGroupRowInfo.EditValue IsNot Nothing Then

                        GridGroupRowInfo.GroupText = GridGroupRowInfo.EditValue.ToString

                    Else

                        GridGroupRowInfo.GroupText = ""

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromTemplate_Templates.DataSourceChangedEvent

            If DataGridViewCopyFromTemplate_Templates.Columns(AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCategoryCode.ToString) IsNot Nothing Then

                DataGridViewCopyFromTemplate_Templates.Columns(AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCategoryCode.ToString).Visible = _UseProductCategory

            End If

            If DataGridViewCopyFromTemplate_Templates.Columns(AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCategoryDescription.ToString) IsNot Nothing Then

                DataGridViewCopyFromTemplate_Templates.Columns(AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.ProductCategoryDescription.ToString).Visible = _UseProductCategory

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewCopyFromTemplate_Templates.InitNewRowEvent

            DataGridViewCopyFromTemplate_Templates.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.EmployeeCode.ToString, _Timesheet.EmployeeCode)

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewCopyFromTemplate_Templates.QueryPopupNeedDatasourceEvent

            'objects
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Classes.EmployeeTimeTemplate = Nothing
            Dim IsIndirectTime As Boolean = True

            Try

                EmployeeTimeTemplate = DataGridViewCopyFromTemplate_Templates.CurrentView.GetRow(DataGridViewCopyFromTemplate_Templates.CurrentView.FocusedRowHandle)

            Catch ex As Exception
                EmployeeTimeTemplate = Nothing
            End Try

            If EmployeeTimeTemplate IsNot Nothing Then

                If String.IsNullOrEmpty(EmployeeTimeTemplate.ClientCode) = False OrElse
                    String.IsNullOrEmpty(EmployeeTimeTemplate.DivisionCode) = False OrElse
                    String.IsNullOrEmpty(EmployeeTimeTemplate.ProductCode) = False OrElse
                    EmployeeTimeTemplate.JobNumber.HasValue OrElse
                    EmployeeTimeTemplate.JobCompNumber.HasValue Then

                    IsIndirectTime = False

                End If

            End If

            Select Case FieldName

                Case AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.DepartmentTeamCode.ToString

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.EmployeeTimesheet.LoadEmployeeDepartments(_Session, _Timesheet.EmployeeCode)

                Case AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.FunctionCode.ToString

                    OverrideDefaultDatasource = True

                    Datasource = AdvantageFramework.EmployeeTimesheet.LoadTimeCategorOrFunctionListByEmployee(_Session, _Timesheet.EmployeeCode, IsIndirectTime)

            End Select

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromTemplate_Templates.SelectionChangedEvent

            RaiseEvent SelectedCopyOptionChangedEvent()

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewCopyFromTemplate_Templates.ShowingEditorEvent

            'objects
            Dim FieldName As String = Nothing

            FieldName = DataGridViewCopyFromTemplate_Templates.CurrentView.FocusedColumn.FieldName

            If DataGridViewCopyFromTemplate_Templates.IsNewItemRow() = False Then

                If FieldName <> AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.Comment.ToString AndAlso
                   FieldName <> AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.EmployeeHours.ToString Then

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewCopyFromTemplate_Templates.ShownEditorEvent

            If DataGridViewCopyFromTemplate_Templates.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.EmployeeTimeTemplate.Properties.JobCompNumber.ToString Then

                If TypeOf DataGridViewCopyFromTemplate_Templates.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    AddHandler DataGridViewCopyFromTemplate_Templates.CurrentView.ActiveEditor.EditValueChanged, AddressOf GridLookUpEdit_JobComponent_EditValueChanged

                End If

            End If

        End Sub
        Private Sub ComboBoxCopyFromTemplate_GroupBy_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles ComboBoxCopyFromTemplate_GroupBy.SelectionChangeCommitted

            'objects
            Dim GroupByFieldName As String = Nothing
            Dim GroupByColumnValues As String() = Nothing
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Classes.EmployeeTimeTemplate = Nothing
            Dim UnBoundExpression As String() = Nothing

            DataGridViewCopyFromTemplate_Templates.CurrentView.ClearGrouping()

            If ComboBoxCopyFromTemplate_GroupBy.HasASelectedValue Then

                If DataGridViewCopyFromTemplate_Templates.Columns("CustomGroupByKey") IsNot Nothing Then

                    DataGridViewCopyFromTemplate_Templates.Columns("CustomGroupByKey").Group()
                    DataGridViewCopyFromTemplate_Templates.CurrentView.ExpandAllGroups()

                End If

            Else

                DataGridViewCopyFromTemplate_Templates.Columns("CustomGroupByKey").Visible = False

            End If

        End Sub
        Private Sub DataGridViewCopyFromTemplate_Templates_CustomUnboundColumnDataEvent(ByVal Sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs) Handles DataGridViewCopyFromTemplate_Templates.CustomUnboundColumnDataEvent

            'objects
            Dim Value As String() = Nothing
            Dim EmployeeTimeTemplate As AdvantageFramework.Database.Classes.EmployeeTimeTemplate = Nothing

            If e.IsGetData() Then

                If e.Column.FieldName = "CustomGroupByKey" Then

                    If ComboBoxCopyFromTemplate_GroupBy.HasASelectedValue Then

                        Try

                            EmployeeTimeTemplate = DataGridViewCopyFromTemplate_Templates.CurrentView.GetRow(e.ListSourceRowIndex)

                        Catch ex As Exception
                            EmployeeTimeTemplate = Nothing
                        End Try

                        If EmployeeTimeTemplate IsNot Nothing Then

                            If EmployeeTimeTemplate.ClientCode <> "" Then

                                Select Case CInt(ComboBoxCopyFromTemplate_GroupBy.GetSelectedValue)

                                    Case AdvantageFramework.EmployeeTimesheet.TemplateGroupByOptions.Client

                                        Value = {EmployeeTimeTemplate.ClientCode}

                                    Case AdvantageFramework.EmployeeTimesheet.TemplateGroupByOptions.Division

                                        Value = {EmployeeTimeTemplate.ClientCode, EmployeeTimeTemplate.DivisionCode}

                                    Case AdvantageFramework.EmployeeTimesheet.TemplateGroupByOptions.Product

                                        Value = {EmployeeTimeTemplate.ClientCode, EmployeeTimeTemplate.DivisionCode, EmployeeTimeTemplate.ProductCode}

                                    Case AdvantageFramework.EmployeeTimesheet.TemplateGroupByOptions.Job

                                        Value = {EmployeeTimeTemplate.ClientCode, EmployeeTimeTemplate.DivisionCode, EmployeeTimeTemplate.ProductCode, EmployeeTimeTemplate.JobNumber.GetValueOrDefault(0)}

                                End Select

                            Else

                                Value = {"[None]"}

                            End If

                        End If

                        e.Value = String.Join("\", Value)

                    Else

                        e.Value = Nothing

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

#Region " Drag Drop "

        Private _DownHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

#Region " Timesheet Grid "

        Private Sub DataGridViewForm_TimesheetEntries_DragDrop(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridViewForm_TimesheetEntries.DragDrop

            Dim RowObjects As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim EmployeeTimeID As Integer = Nothing
            Dim EmployeeTimeDetailID As Integer = Nothing
            Dim EmployeeTimeComplex As AdvantageFramework.Database.Classes.EmployeeTimeComplex = Nothing
            Dim CopyEmployeeTimeDetail As AdvantageFramework.Database.Entities.EmployeeTimeDetail = Nothing
            Dim EmployeeCode As String = Nothing
            Dim EmployeeDate As String = Nothing

            Try

                RowObjects = CType(e.Data.GetData(GetType(Generic.Dictionary(Of Integer, Object))), Generic.Dictionary(Of Integer, Object))

                If RowObjects IsNot Nothing AndAlso RowObjects.Count > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each RowObject In RowObjects

                            Try

                                EmployeeTimeID = RowObject.Value.EmployeeTimeID
                                EmployeeTimeDetailID = RowObject.Value.EmployeeTimeDetailID
                                EmployeeCode = RowObject.Value.EmployeeCode
                                EmployeeDate = RowObject.Value.EmployeeDate

                                EmployeeTimeComplex = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTimeComplex.Load(DbContext, EmployeeCode, EmployeeDate, EmployeeDate, "", _Session.UserCode)
                                                       Where Entity.EmployeeTimeID = EmployeeTimeID AndAlso
                                                             Entity.EmployeeTimeDetailID = EmployeeTimeDetailID
                                                       Select Entity).SingleOrDefault

                            Catch ex As Exception
                                EmployeeTimeComplex = Nothing
                            End Try

                            If EmployeeTimeComplex IsNot Nothing Then

                                _Timesheet.CreateTimesheetRecord(EmployeeTimeComplex)

                            End If

                        Next

                        DataGridViewForm_TimesheetEntries.DataSource = _Timesheet.TimeSheetEntries

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub DataGridViewForm_TimesheetEntries_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles DataGridViewForm_TimesheetEntries.DragOver

            Dim SomeStuff As Object = Nothing

            SomeStuff = e.Data.GetFormats()

            If e.Data.GetDataPresent(GetType(Generic.Dictionary(Of Integer, Object))) Then

                e.Effect = Windows.Forms.DragDropEffects.Move

            Else

                e.Effect = Windows.Forms.DragDropEffects.None

            End If

        End Sub

#End Region

        Private Sub DataGridViewCopyFromTimesheet_TimesheetTemplates_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.MouseDown

            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            _DownHitInfo = Nothing

            GridHitInfo = DataGridViewCopyFromTimesheet_TimesheetTemplates.CurrentView.CalcHitInfo(New System.Drawing.Point(e.X, e.Y))

            If Not System.Windows.Forms.Control.ModifierKeys = Windows.Forms.Keys.None Then

                Exit Sub

            End If

            If e.Button = Windows.Forms.MouseButtons.Left AndAlso GridHitInfo.RowHandle >= 0 Then

                _DownHitInfo = GridHitInfo

            End If

        End Sub
        Private Sub DataGridViewTest_DragDrop_MouseMove(sender As Object, e As Windows.Forms.MouseEventArgs) Handles DataGridViewCopyFromTimesheet_TimesheetTemplates.MouseMove

            Dim DragSize As System.Drawing.Size = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim RowObject As Object = Nothing

            If e.Button = Windows.Forms.MouseButtons.Left AndAlso _DownHitInfo IsNot Nothing Then

                DragSize = System.Windows.Forms.SystemInformation.DragSize

                Rectangle = New System.Drawing.Rectangle(New System.Drawing.Point(_DownHitInfo.HitPoint.X - DragSize.Width / 2, _DownHitInfo.HitPoint.Y - DragSize.Height / 2), DragSize)

                If Rectangle.Contains(New System.Drawing.Point(e.X, e.Y)) = False Then

                    'RowObject = DataGridViewTest_DragDrop.CurrentView.GetRow(_DownHitInfo.RowHandle)

                    RowObject = DataGridViewCopyFromTimesheet_TimesheetTemplates.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    DataGridViewCopyFromTimesheet_TimesheetTemplates.GridControl.DoDragDrop(RowObject, Windows.Forms.DragDropEffects.Move)

                    _DownHitInfo = Nothing

                    DevExpress.Utils.DXMouseEventArgs.GetMouseArgs(e).Handled = True

                End If

            End If

        End Sub



#End Region

#End Region

#End Region

    End Class

End Namespace