Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Namespace WinForm.Presentation.Controls

    Public Class JobVersionTemplateControl

        Public Event SelectedDetailChangedEvent()
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _JobVersionTemplateCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _JobVersionDatabaseTypes As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property IsNewItemRowFocused As Boolean
            Get
                IsNewItemRowFocused = DataGridViewControl_JobVersionTemplateDetails.IsNewItemRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property IsDetailListRow(Optional ByVal Rowhandle As Nullable(Of Integer) = Nothing) As Boolean
            Get

                Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
                Dim IsListRow As Boolean = False

                If Rowhandle.HasValue = False Then

                    Rowhandle = DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle

                End If

                Try

                    JobVersionTemplateDetail = DataGridViewControl_JobVersionTemplateDetails.CurrentView.GetRow(Rowhandle)

                Catch ex As Exception
                    JobVersionTemplateDetail = Nothing
                End Try

                If JobVersionTemplateDetail IsNot Nothing Then

                    If (From DatabaseType In _JobVersionDatabaseTypes
                        Where DatabaseType.ID = JobVersionTemplateDetail.DatabaseTypeID AndAlso
                              DatabaseType.IsList = CShort(1)
                        Select DatabaseType).Any Then

                        IsListRow = True

                    End If

                End If

                IsDetailListRow = IsListRow

            End Get
        End Property
        Public ReadOnly Property HasOnlyOneSelectedDetail As Boolean
            Get
                HasOnlyOneSelectedDetail = DataGridViewControl_JobVersionTemplateDetails.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property CanMoveSelectedDetailUp As Boolean
            Get

                'objects
                Dim CanMove As Boolean = False

                If DataGridViewControl_JobVersionTemplateDetails.CurrentView.IsNewItemRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle) = False AndAlso
                   DataGridViewControl_JobVersionTemplateDetails.CurrentView.IsFirstRow = False Then

                    CanMove = True

                End If

                CanMoveSelectedDetailUp = CanMove

            End Get
        End Property
        Public ReadOnly Property CanMoveSelectedDetailDown As Boolean
            Get

                'objects
                Dim CanMove As Boolean = False

                If DataGridViewControl_JobVersionTemplateDetails.CurrentView.IsNewItemRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle) = False AndAlso
                   DataGridViewControl_JobVersionTemplateDetails.CurrentView.IsLastRow = False Then

                    CanMove = True

                End If

                CanMoveSelectedDetailDown = CanMove

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

                            DataGridViewControl_JobVersionTemplateDetails.MultiSelect = False
                            DataGridViewControl_JobVersionTemplateDetails.OptionsCustomization.AllowSort = False
                            DataGridViewControl_JobVersionTemplateDetails.OptionsCustomization.AllowFilter = False

                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.JobVersionTemplate.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.JobVersionTemplate.Properties.Description)

                            _JobVersionDatabaseTypes = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.Load(DbContext).ToList

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate)

            If JobVersionTemplate IsNot Nothing Then

                JobVersionTemplate.Code = TextBoxControl_Code.Text
                JobVersionTemplate.Description = TextBoxControl_Description.Text
                JobVersionTemplate.IsInactive = CShort(CheckBoxControl_Inactive.Checked)

            End If

        End Sub
        Private Sub LoadJobVersionTemplateDetails()

            If _JobVersionTemplateCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewControl_JobVersionTemplateDetails.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCode(DbContext, _JobVersionTemplateCode)
                                                                                Select Entity
                                                                                Order By Entity.OrderNumber).ToList

                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.Columns("OrderNumber").SortOrder = DevExpress.Data.ColumnSortOrder.Ascending

                End Using

            Else

                DataGridViewControl_JobVersionTemplateDetails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            End If

            DataGridViewControl_JobVersionTemplateDetails.CurrentView.BestFitColumns()

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.JobVersionTemplate

            Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

            Try

                If IsNew Then

                    JobVersionTemplate = New AdvantageFramework.Database.Entities.JobVersionTemplate

                    LoadEntity(JobVersionTemplate)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, _JobVersionTemplateCode)

                    End Using

                    If JobVersionTemplate IsNot Nothing Then

                        LoadEntity(JobVersionTemplate)

                    End If

                End If

            Catch ex As Exception
                JobVersionTemplate = Nothing
            End Try

            FillObject = JobVersionTemplate

        End Function

#Region " Public "

        Public Function LoadControl(ByVal JobVersionTemplateCode As String, ByVal IsCopy As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

            _JobVersionTemplateCode = JobVersionTemplateCode
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobVersionTemplateCode <> "" AndAlso _IsCopy = False Then

                    JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, _JobVersionTemplateCode)

                    If JobVersionTemplate IsNot Nothing Then

                        TextBoxControl_Code.Enabled = False

                        TextBoxControl_Code.Text = JobVersionTemplate.Code
                        TextBoxControl_Description.Text = JobVersionTemplate.Description
                        CheckBoxControl_Inactive.Checked = CBool(JobVersionTemplate.IsInactive.GetValueOrDefault(0))

                    Else

                        Loaded = False

                    End If

                ElseIf _JobVersionTemplateCode <> "" AndAlso _IsCopy = True Then

                    JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, _JobVersionTemplateCode)

                    If JobVersionTemplate IsNot Nothing Then

                        DataGridViewControl_JobVersionTemplateDetails.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None
                        TextBoxControl_Code.Enabled = True

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxControl_Code.Enabled = True
                    DataGridViewControl_JobVersionTemplateDetails.Enabled = False

                End If

            End Using

            LoadJobVersionTemplateDetails()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            TextBoxControl_Code.Text = Nothing
            CheckBoxControl_Inactive.Checked = False
            TextBoxControl_Description.Text = Nothing

            DataGridViewControl_JobVersionTemplateDetails.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim JobVersionTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail) = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewControl_JobVersionTemplateDetails.CurrentView.CloseEditorForUpdating()

                        JobVersionTemplate = Me.FillObject(False)

                        If JobVersionTemplate IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.JobVersionTemplate.Update(DbContext, DataContext, JobVersionTemplate) Then

                                Saved = True

                                JobVersionTemplateDetails = DataGridViewControl_JobVersionTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail).ToList

                                For Each JobVersionTemplateDetail In JobVersionTemplateDetails

                                    JobVersionTemplateDetail.OrderNumber = JobVersionTemplateDetails.IndexOf(JobVersionTemplateDetail)

                                    JobVersionTemplateDetail.JobVersionTemplateCode = JobVersionTemplate.Code

                                    AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetail)

                                Next

                            End If

                        End If

                    End Using

                End Using

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
            Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        JobVersionTemplate = Me.FillObject(False)

                        If JobVersionTemplate IsNot Nothing Then

                            Deleted = AdvantageFramework.Database.Procedures.JobVersionTemplate.Delete(DbContext, DataContext, JobVersionTemplate)

                            If Deleted = False Then

                                ErrorMessage = "The Job Version Template is in use and cannot be deleted."

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef Code As String) As Boolean

            'objects
            Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing
            Dim NewJobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim NewJobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewControl_JobVersionTemplateDetails.CurrentView.CloseEditorForUpdating()

                        JobVersionTemplate = Me.FillObject(True)

                        If JobVersionTemplate IsNot Nothing Then

                            JobVersionTemplate.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.JobVersionTemplate.Insert(DbContext, DataContext, JobVersionTemplate) Then

                                Inserted = True

                                Code = JobVersionTemplate.Code

                                If _IsCopy Then

                                    For Each JobVersionTemplateDetail In DataGridViewControl_JobVersionTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail).ToList

                                        NewJobVersionTemplateDetail = New AdvantageFramework.Database.Entities.JobVersionTemplateDetail

                                        NewJobVersionTemplateDetail = JobVersionTemplateDetail.DuplicateEntity()

                                        NewJobVersionTemplateDetail.JobVersionTemplateCode = JobVersionTemplate.Code

                                        NewJobVersionTemplateDetail.DbContext = DbContext

                                        If AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Insert(DbContext, NewJobVersionTemplateDetail) Then

                                            Try

                                                If AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, NewJobVersionTemplateDetail.DatabaseTypeID).IsList = CShort(1) Then

                                                    For Each JobVersionTemplateDetailListValue In AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailID(DataContext, JobVersionTemplateDetail.ID).ToList

                                                        NewJobVersionTemplateDetailListValue = New AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue

                                                        NewJobVersionTemplateDetailListValue.DataContext = DataContext
                                                        NewJobVersionTemplateDetailListValue.JobVersionTemplateDetailID = NewJobVersionTemplateDetail.ID
                                                        NewJobVersionTemplateDetailListValue.Value = JobVersionTemplateDetailListValue.Value

                                                        AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Insert(DataContext, NewJobVersionTemplateDetailListValue)

                                                    Next

                                                End If

                                            Catch ex As Exception

                                            End Try

                                        End If

                                    Next

                                End If

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub CancelAddNewDetail()

            DataGridViewControl_JobVersionTemplateDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedDetail()

            'objects
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing

            If DataGridViewControl_JobVersionTemplateDetails.HasOnlyOneSelectedRow Then

                DataGridViewControl_JobVersionTemplateDetails.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    Try

                        Try

                            JobVersionTemplateDetail = DataGridViewControl_JobVersionTemplateDetails.GetFirstSelectedRowDataBoundItem

                        Catch ex As Exception
                            JobVersionTemplateDetail = Nothing
                        End Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Delete(DbContext, DataContext, JobVersionTemplateDetail) Then

                                    LoadJobVersionTemplateDetails()

                                End If

                            End Using

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Public Sub MoveSelectedDetail(ByVal MoveUp As Boolean)

            'objects
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim SwitchWithJobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim FocusedRowHandle As Integer = Nothing
            Dim NewOrderNumber As Integer = Nothing
            Dim OldOrderNumber As Integer = Nothing
            Dim SwitchWithRowHandle As Integer = Nothing

            FocusedRowHandle = DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle

            Try

                JobVersionTemplateDetail = DataGridViewControl_JobVersionTemplateDetails.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                JobVersionTemplateDetail = Nothing
            End Try

            If JobVersionTemplateDetail IsNot Nothing Then

                Try

                    If MoveUp Then

                        SwitchWithRowHandle = FocusedRowHandle - 1

                    Else

                        SwitchWithRowHandle = FocusedRowHandle + 1

                    End If

                    SwitchWithJobVersionTemplateDetail = DataGridViewControl_JobVersionTemplateDetails.CurrentView.GetRow(SwitchWithRowHandle)

                Catch ex As Exception
                    SwitchWithJobVersionTemplateDetail = Nothing
                End Try

                If SwitchWithJobVersionTemplateDetail IsNot Nothing Then

                    NewOrderNumber = SwitchWithJobVersionTemplateDetail.OrderNumber
                    OldOrderNumber = JobVersionTemplateDetail.OrderNumber

                    If NewOrderNumber = OldOrderNumber Then

                        If MoveUp Then

                            OldOrderNumber += 1

                        Else

                            OldOrderNumber -= 1

                        End If

                    End If

                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.SetRowCellValue(FocusedRowHandle, AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.OrderNumber.ToString, NewOrderNumber)
                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.SetRowCellValue(SwitchWithRowHandle, AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.OrderNumber.ToString, OldOrderNumber)

                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.RefreshData()

                    DataGridViewControl_JobVersionTemplateDetails.SetUserEntryChanged()

                End If

            End If

        End Sub
        Public Sub EditDetailListValues()

            If Me.IsDetailListRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle) Then

                If AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobVersionDetailListEditDialog.ShowFormDialog(DataGridViewControl_JobVersionTemplateDetails.GetFirstSelectedRowBookmarkValue) = Windows.Forms.DialogResult.OK Then

                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.CollapseMasterRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle, 0)

                    DataGridViewControl_JobVersionTemplateDetails.CurrentView.ExpandMasterRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle, 0)

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub JobVersionTemplateControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_JobVersionTemplateDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_JobVersionTemplateDetails.AddNewRowEvent

            'objects
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim JobVersionTemplateDetailMapping As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.JobVersionTemplateDetail Then

                If _JobVersionTemplateCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    JobVersionTemplateDetail = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If JobVersionTemplateDetail.IsEntityBeingAdded() Then

                            JobVersionTemplateDetailMapping = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCodeAndMapping(DbContext, _JobVersionTemplateCode, JobVersionTemplateDetail.JobTemplateMapping, 0)

                            If JobVersionTemplateDetailMapping IsNot Nothing Then

                                Me.CloseWaitForm()

                                AdvantageFramework.WinForm.MessageBox.Show("This field is already mapped.  Please choose a different field.")

                                JobVersionTemplateDetail.JobTemplateMapping = Nothing

                            End If

                            JobVersionTemplateDetail.DbContext = DbContext

                            JobVersionTemplateDetail.JobVersionTemplateCode = TextBoxControl_Code.Text

                            AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Insert(DbContext, JobVersionTemplateDetail)

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub

        Private Sub DataGridViewControl_JobVersionTemplateDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_JobVersionTemplateDetails.CellValueChangingEvent

            'objects
            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim JobVersionTemplateDetailMapping As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim DataTable As System.Data.DataTable = Nothing
            Dim ErrorMessage As String = ""

            If _IsCopy = False Then

                If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.IsRequired.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.IsInactive.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.JobTemplateMapping.ToString Then

                    Try

                        JobVersionTemplateDetail = DataGridViewControl_JobVersionTemplateDetails.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        JobVersionTemplateDetail = Nothing
                    End Try

                    If JobVersionTemplateDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If e.Column.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.JobTemplateMapping.ToString Then

                                JobVersionTemplateDetailMapping = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCodeAndMapping(DbContext, JobVersionTemplateDetail.JobVersionTemplateCode, e.Value, JobVersionTemplateDetail.ID)

                                If JobVersionTemplateDetailMapping IsNot Nothing Then

                                    AdvantageFramework.WinForm.MessageBox.Show("This field is already mapped.  Please choose a different field.")

                                End If

                            End If

                            Select Case e.Column.FieldName

                                Case AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.IsRequired.ToString

                                    JobVersionTemplateDetail.IsRequired = CShort(e.Value)

                                Case AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.IsInactive.ToString

                                    JobVersionTemplateDetail.IsInactive = CShort(e.Value)

                                Case AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.JobTemplateMapping.ToString

                                    If JobVersionTemplateDetailMapping Is Nothing Then

                                        JobVersionTemplateDetail.JobTemplateMapping = e.Value

                                    End If

                            End Select

                            Saved = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetail)

                            LoadJobVersionTemplateDetails()

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_JobVersionTemplateDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_JobVersionTemplateDetails.InitNewRowEvent

            If _JobVersionTemplateCode <> "" Then

                DataGridViewControl_JobVersionTemplateDetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.JobVersionTemplateCode.ToString, TextBoxControl_Code.Text)

            End If

        End Sub
        Private Sub DataGridViewControl_JobVersionTemplateDetails_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewControl_JobVersionTemplateDetails.SelectionChangedEvent

            RaiseEvent SelectedDetailChangedEvent()

        End Sub
        Private Sub DataGridViewControl_JobVersionTemplateDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_JobVersionTemplateDetails.ShowingEditorEvent

            If DataGridViewControl_JobVersionTemplateDetails.IsNewItemRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle) = False Then

                If DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.DatabaseTypeID.ToString Then

                    e.Cancel = Not _IsCopy

                End If

            End If

        End Sub
        Private Sub CheckBoxControl_Inactive_CheckedChangedEx(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxControl_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxControl_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxControl_Inactive.Checked = Not CheckBoxControl_Inactive.Checked

                End If

            End If

        End Sub

        Private Sub DataGridViewControl_JobVersionTemplateDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_JobVersionTemplateDetails.QueryPopupNeedDatasourceEvent

            Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
            Dim JobVersionDatabaseType As AdvantageFramework.Database.Entities.JobVersionDatabaseType = Nothing
            Dim DataTable As System.Data.DataTable = Nothing

            JobVersionTemplateDetail = DirectCast(DataGridViewControl_JobVersionTemplateDetails.CurrentView.GetRow(DataGridViewControl_JobVersionTemplateDetails.CurrentView.FocusedRowHandle), AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If FieldName = AdvantageFramework.Database.Entities.JobVersionTemplateDetail.Properties.JobTemplateMapping.ToString Then

                    OverrideDefaultDatasource = True

                    If JobVersionTemplateDetail Is Nothing Then

                        Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext)
                                      Where Entity.DatabaseTypeID = -1
                                      Select Entity.Code, Entity.Description).ToList

                    Else

                        JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, JobVersionTemplateDetail.DatabaseTypeID)
                        If JobVersionDatabaseType.DatabaseTypeID = 1 Then
                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext)
                                          Where Entity.DatabaseTypeID = 1 Or
                                                     Entity.DatabaseTypeID = 6
                                          Select Entity.Code, Entity.Description).ToList
                        Else
                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.LoadByCodeandDatabaseTypeID(DbContext, JobVersionDatabaseType.DatabaseTypeID)
                                          Select Entity.Code, Entity.Description).ToList
                        End If

                    End If

                End If

            End Using


        End Sub


#End Region

#End Region

    End Class

End Namespace