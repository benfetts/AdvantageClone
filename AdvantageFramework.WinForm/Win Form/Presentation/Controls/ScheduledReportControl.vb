Namespace WinForm.Presentation.Controls

    Public Class ScheduledReportControl

        Public Event ScheduledReportSelectionChangedEvent()
        Public Event ScheduledReportChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Type
            [Default]
            ViewOnly
        End Enum

#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _DynamicReportID As Nullable(Of Integer) = Nothing
        Private _DynamicReportType As Nullable(Of Integer) = Nothing
        Private _IsAgencyASP As Boolean = False
        Private _SerializedParameterDictionary As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ShowCriteriaEdit As Boolean
            Get
                Dim AdvantageServiceReportSchedule As AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule = Nothing

                AdvantageServiceReportSchedule = DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule)

                If AdvantageServiceReportSchedule IsNot Nothing AndAlso AdvantageServiceReportSchedule.DynamicReportType <> AdvantageFramework.Reporting.DynamicReports.Employees AndAlso
                        AdvantageServiceReportSchedule.DynamicReportType <> AdvantageFramework.Reporting.DynamicReports.VirtualCreditCardTransactionEFS Then

                    ShowCriteriaEdit = True

                Else

                    ShowCriteriaEdit = False

                End If
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            _IsAgencyASP = AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim AdvantageServiceReportSchedule As Generic.List(Of AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule) = Nothing
            Dim SubItemDateInput As WinForm.Presentation.Controls.SubItemDateInput = Nothing
            Dim SubItemTextBox As WinForm.Presentation.Controls.SubItemTextBox = Nothing
            Dim DynamicReports As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport) = Nothing

            AdvantageServiceReportSchedule = New Generic.List(Of AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DynamicReports = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.Load(ReportingDbContext).ToList

                End Using

                If _DynamicReportID.HasValue Then

                    AdvantageServiceReportSchedule.AddRange(From ASRS In AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.LoadByReportScheduleTypeAndReportID(DbContext, AdvantageFramework.Database.Entities.AdvantageServiceReportScheduleType.DynamicReport, _DynamicReportID).ToList
                                                            Select New AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule(ASRS, _IsAgencyASP, DynamicReports))

                Else

                    AdvantageServiceReportSchedule.AddRange(From ASRS In AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.Load(DbContext).ToList
                                                            Select New AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule(ASRS, _IsAgencyASP, DynamicReports))

                End If

            End Using

            DataGridViewForm_ScheduledReports.DataSource = AdvantageServiceReportSchedule

            If DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.EmployeeCode.ToString) IsNot Nothing Then

                DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.EmployeeCode.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.LastRan.ToString) IsNot Nothing Then

                DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.LastRan.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ParameterDictionary.ToString) IsNot Nothing Then

                DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ParameterDictionary.ToString).OptionsColumn.AllowFocus = False

            End If

            If DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ScheduleStartTime.ToString) IsNot Nothing Then

                SubItemDateInput = DataGridViewForm_ScheduledReports.Columns(AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.ScheduleStartTime.ToString).ColumnEdit
                SubItemDateInput.ControlType = WinForm.MVC.Presentation.Controls.SubItemDateInput.Type.ShortDateAndTime

            End If

            DataGridViewForm_ScheduledReports.CurrentView.BestFitColumns()

        End Sub

#Region "  Public "

        Public Sub CancelNewItem()

            DataGridViewForm_ScheduledReports.CancelNewItemRow()

        End Sub
        Public Function LoadControl(AllowAddingNewRows As Boolean, Optional SerializedParameterDictionary As String = Nothing, Optional DynamicReportID As Integer? = Nothing,
                                    Optional DatabaseProfile As AdvantageFramework.Database.DatabaseProfile = Nothing)

            'objects
            Dim Loaded As Boolean = True
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            _DynamicReportID = DynamicReportID
            _SerializedParameterDictionary = SerializedParameterDictionary

            DataGridViewForm_ScheduledReports.MultiSelect = False

            If DatabaseProfile IsNot Nothing Then

                _Session = Nothing

                _Session = New AdvantageFramework.Security.Session(Security.Application.Advantage, DatabaseProfile.ConnectionString, DatabaseProfile.DatabaseUserName, 0, DatabaseProfile.ConnectionString)

            End If

            LoadGrid()

            If AllowAddingNewRows Then

                Me.DataGridViewForm_ScheduledReports.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

            End If

            If _DynamicReportID.HasValue Then

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _DynamicReportID)

                    If DynamicReport IsNot Nothing Then

                        _DynamicReportType = DynamicReport.Type

                    End If

                End Using

            End If

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function DeleteSelectedScheduledReport() As Boolean

            'objects
            Dim AdvantageServiceReportSchedule As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule = Nothing
            Dim ID As Integer
            Dim Deleted As Boolean = False
            Dim Message As String = ""

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Deleting...")

                ID = DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).ID

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageServiceReportSchedule = AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.LoadByID(DbContext, ID)

                    If AdvantageServiceReportSchedule IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.DeleteByID(DbContext, ID)

                        LoadGrid()

                    End If

                End Using

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

            DeleteSelectedScheduledReport = Deleted

        End Function
        Public Sub ClearControl()

            DataGridViewForm_ScheduledReports.ClearDatasource(New Generic.List(Of AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim AdvantageServiceReportSchedules As Generic.List(Of AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule) = Nothing
            Dim AdvantageServiceReportScheduleEntity As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule = Nothing
            Dim Saved As Boolean = True

            If DataGridViewForm_ScheduledReports.HasRows Then

                DataGridViewForm_ScheduledReports.CurrentView.CloseEditorForUpdating()

                DataGridViewForm_ScheduledReports.ValidateAllRows()

                If DataGridViewForm_ScheduledReports.HasAnyInvalidRows Then

                    AdvantageFramework.WinForm.MessageBox.Show("Fix errors in grid.")
                    Saved = False

                Else

                    AdvantageServiceReportSchedules = DataGridViewForm_ScheduledReports.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule)().ToList

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each AdvantageServiceReportSchedule In AdvantageServiceReportSchedules

                                AdvantageServiceReportScheduleEntity = DbContext.AdvantageServiceReportSchedules.Find(AdvantageServiceReportSchedule.ID)

                                If AdvantageServiceReportScheduleEntity IsNot Nothing Then

                                    AdvantageServiceReportScheduleEntity.ReportScheduleType = AdvantageServiceReportSchedule.ReportScheduleType
                                    AdvantageServiceReportScheduleEntity.EmployeeCode = AdvantageServiceReportSchedule.EmployeeCode
                                    AdvantageServiceReportScheduleEntity.ReportID = AdvantageServiceReportSchedule.ReportID
                                    AdvantageServiceReportScheduleEntity.ExportType = AdvantageServiceReportSchedule.ExportType
                                    AdvantageServiceReportScheduleEntity.Frequency = AdvantageServiceReportSchedule.Frequency
                                    AdvantageServiceReportScheduleEntity.Sunday = AdvantageServiceReportSchedule.Sunday
                                    AdvantageServiceReportScheduleEntity.Monday = AdvantageServiceReportSchedule.Monday
                                    AdvantageServiceReportScheduleEntity.Tuesday = AdvantageServiceReportSchedule.Tuesday
                                    AdvantageServiceReportScheduleEntity.Wednesday = AdvantageServiceReportSchedule.Wednesday
                                    AdvantageServiceReportScheduleEntity.Thursday = AdvantageServiceReportSchedule.Thursday
                                    AdvantageServiceReportScheduleEntity.Friday = AdvantageServiceReportSchedule.Friday
                                    AdvantageServiceReportScheduleEntity.Saturday = AdvantageServiceReportSchedule.Saturday
                                    AdvantageServiceReportScheduleEntity.DayOfMonth = AdvantageServiceReportSchedule.DayOfMonth
                                    AdvantageServiceReportScheduleEntity.ScheduleStartTime = AdvantageServiceReportSchedule.ScheduleStartTime
                                    AdvantageServiceReportScheduleEntity.ScheduleEndDate = AdvantageServiceReportSchedule.ScheduleEndDate
                                    AdvantageServiceReportScheduleEntity.LastRan = AdvantageServiceReportSchedule.LastRan
                                    AdvantageServiceReportScheduleEntity.ParameterDictionary = AdvantageServiceReportSchedule.ParameterDictionary
                                    AdvantageServiceReportScheduleEntity.EmailAddress = AdvantageServiceReportSchedule.EmailAddress
                                    AdvantageServiceReportScheduleEntity.Criteria = AdvantageServiceReportSchedule.Criteria
                                    AdvantageServiceReportScheduleEntity.FilterString = AdvantageServiceReportSchedule.FilterString
                                    AdvantageServiceReportScheduleEntity.FromDate = AdvantageServiceReportSchedule.FromDate.ToShortDateString
                                    AdvantageServiceReportScheduleEntity.ToDate = AdvantageServiceReportSchedule.ToDate.ToShortDateString
                                    AdvantageServiceReportScheduleEntity.ShowJobsWithNoDetails = AdvantageServiceReportSchedule.ShowJobsWithNoDetails

                                    DbContext.Entry(AdvantageServiceReportScheduleEntity).State = Entity.EntityState.Modified

                                End If

                            Next

                            DbContext.SaveChanges()

                        End Using

                    Catch ex As Exception
                        Saved = False
                    End Try

                    Try

                        DataGridViewForm_ScheduledReports.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

            Save = Saved

        End Function
        Public Sub EditCriteria()

            'objects
            Dim AdvantageServiceReportSchedule As AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule = Nothing
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            AdvantageServiceReportSchedule = DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule)

            ParameterDictionary = AdvantageFramework.ClassUtilities.ReadObjectContentInDocument(AdvantageServiceReportSchedule.ParameterDictionary)

            If AdvantageFramework.Desktop.Presentation.LaunchInitialLoadingDialog(AdvantageServiceReportSchedule.DynamicReportType, AdvantageServiceReportSchedule.Criteria, AdvantageServiceReportSchedule.FilterString, AdvantageServiceReportSchedule.FromDate, AdvantageServiceReportSchedule.ToDate, AdvantageServiceReportSchedule.ShowJobsWithNoDetails, ParameterDictionary, Nothing) Then

                AdvantageServiceReportSchedule.ParameterDictionary = AdvantageFramework.ClassUtilities.GetParameterContent(ParameterDictionary)

                AdvantageServiceReportSchedule.ValidateEntity(True)

                If DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle > -1 Then

                    DataGridViewForm_ScheduledReports.SetUserEntryChanged()

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ScheduledReportControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_ScheduledReports_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_ScheduledReports.AddNewRowEvent

            'objects
            Dim AdvantageServiceReportScheduleEntity As AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule = Nothing
            Dim AdvantageServiceReportSchedule As AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule = Nothing

            AdvantageServiceReportScheduleEntity = New AdvantageFramework.Database.Entities.AdvantageServiceReportSchedule

            AdvantageServiceReportSchedule = RowObject

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageServiceReportScheduleEntity.ReportScheduleType = AdvantageServiceReportSchedule.ReportScheduleType
                AdvantageServiceReportScheduleEntity.EmployeeCode = AdvantageServiceReportSchedule.EmployeeCode
                AdvantageServiceReportScheduleEntity.ReportID = AdvantageServiceReportSchedule.ReportID
                AdvantageServiceReportScheduleEntity.ExportType = AdvantageServiceReportSchedule.ExportType
                AdvantageServiceReportScheduleEntity.Frequency = AdvantageServiceReportSchedule.Frequency
                AdvantageServiceReportScheduleEntity.Sunday = AdvantageServiceReportSchedule.Sunday
                AdvantageServiceReportScheduleEntity.Monday = AdvantageServiceReportSchedule.Monday
                AdvantageServiceReportScheduleEntity.Tuesday = AdvantageServiceReportSchedule.Tuesday
                AdvantageServiceReportScheduleEntity.Wednesday = AdvantageServiceReportSchedule.Wednesday
                AdvantageServiceReportScheduleEntity.Thursday = AdvantageServiceReportSchedule.Thursday
                AdvantageServiceReportScheduleEntity.Friday = AdvantageServiceReportSchedule.Friday
                AdvantageServiceReportScheduleEntity.Saturday = AdvantageServiceReportSchedule.Saturday
                AdvantageServiceReportScheduleEntity.DayOfMonth = AdvantageServiceReportSchedule.DayOfMonth
                AdvantageServiceReportScheduleEntity.ScheduleStartTime = AdvantageServiceReportSchedule.ScheduleStartTime
                AdvantageServiceReportScheduleEntity.ScheduleEndDate = AdvantageServiceReportSchedule.ScheduleEndDate
                AdvantageServiceReportScheduleEntity.LastRan = AdvantageServiceReportSchedule.LastRan
                AdvantageServiceReportScheduleEntity.ParameterDictionary = AdvantageServiceReportSchedule.ParameterDictionary
                AdvantageServiceReportScheduleEntity.EmailAddress = AdvantageServiceReportSchedule.EmailAddress
                AdvantageServiceReportScheduleEntity.Criteria = AdvantageServiceReportSchedule.Criteria
                AdvantageServiceReportScheduleEntity.FilterString = AdvantageServiceReportSchedule.FilterString
                AdvantageServiceReportScheduleEntity.FromDate = AdvantageServiceReportSchedule.FromDate
                AdvantageServiceReportScheduleEntity.ToDate = AdvantageServiceReportSchedule.ToDate
                AdvantageServiceReportScheduleEntity.ShowJobsWithNoDetails = AdvantageServiceReportSchedule.ShowJobsWithNoDetails

                If AdvantageFramework.Database.Procedures.AdvantageServiceReportSchedule.Insert(DbContext, AdvantageServiceReportScheduleEntity) Then

                    AdvantageServiceReportSchedule.ID = AdvantageServiceReportScheduleEntity.ID

                End If

            End Using

        End Sub
        Private Sub DataGridViewForm_ScheduledReports_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_ScheduledReports.CellValueChangedEvent

            If e.Column.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Frequency.ToString AndAlso e.Value IsNot Nothing Then

                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).SetFrequency(e.Value)

                DataGridViewForm_ScheduledReports.CurrentView.RefreshRow(e.RowHandle)

            End If

            RaiseEvent ScheduledReportChangedEvent()

        End Sub
        Private Sub DataGridViewForm_ScheduledReports_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_ScheduledReports.InitNewRowEvent

            If TypeOf DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule Then

                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).EmployeeCode = _Session.User.EmployeeCode
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).ScheduleStartTime = Now
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).ReportScheduleType = Database.Entities.Methods.AdvantageServiceReportScheduleType.DynamicReport
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).ReportID = _DynamicReportID
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).DynamicReportType = _DynamicReportType
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).ParameterDictionary = _SerializedParameterDictionary
                DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).IsAgencyASP = _IsAgencyASP

            End If

        End Sub
        Private Sub DataGridViewForm_ScheduledReports_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ScheduledReports.SelectionChangedEvent

            RaiseEvent ScheduledReportSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewForm_ScheduledReports_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_ScheduledReports.ShowingEditorEvent

            If DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule) IsNot Nothing Then

                If (DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Sunday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Monday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Tuesday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Wednesday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Thursday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Friday.ToString OrElse
                        DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.Saturday.ToString) AndAlso
                        DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).Frequency <> Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Weekly Then

                    e.Cancel = True

                ElseIf DataGridViewForm_ScheduledReports.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule.Properties.DayOfMonth.ToString AndAlso
                        DirectCast(DataGridViewForm_ScheduledReports.CurrentView.GetRow(DataGridViewForm_ScheduledReports.CurrentView.FocusedRowHandle), AdvantageFramework.Desktop.Classes.AdvantageServiceReportSchedule).Frequency <> Database.Entities.Methods.AdvantageServiceReportScheduleFrequency.Monthly Then

                    e.Cancel = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
