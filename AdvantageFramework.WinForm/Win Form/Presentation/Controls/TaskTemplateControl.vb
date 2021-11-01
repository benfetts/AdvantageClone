Namespace WinForm.Presentation.Controls

    Public Class TaskTemplateControl
        Public Event SelectedDetailChangedEvent()
        Public Event InitNewDetailRowEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _TaskTemplateCode As String = Nothing
        Private _Loaded As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property HasASelectedDetail As Boolean
            Get
                HasASelectedDetail = DataGridViewForm_TaskTemplateDetails.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property IsNewItemRowSelected As Boolean
            Get
                IsNewItemRowSelected = DataGridViewForm_TaskTemplateDetails.IsNewItemRow(DataGridViewForm_TaskTemplateDetails.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property Loaded As Boolean
            Get
                Loaded = _Loaded
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.TaskTemplate.Properties.Code)
                                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.TaskTemplate.Properties.Description)

                                TextBoxScheduleCompletionDays_Standard.ReadOnly = True
                                TextBoxScheduleCompletionDays_Standard.ByPassUserEntryChanged = True

                                TextBoxScheduleCompletionDays_Rush.ReadOnly = True
                                TextBoxScheduleCompletionDays_Rush.ByPassUserEntryChanged = True

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate)

            If TaskTemplate IsNot Nothing Then

                TaskTemplate.Code = TextBoxForm_Code.Text
                TaskTemplate.Description = TextBoxForm_Description.Text

                If TextBoxScheduleCompletionDays_Standard.Text <> "" Then

                    TaskTemplate.TotalStandardDays = CShort(TextBoxScheduleCompletionDays_Standard.Text)

                Else

                    TaskTemplate.TotalStandardDays = Nothing

                End If

                If TextBoxScheduleCompletionDays_Rush.Text <> "" Then

                    TaskTemplate.TotalRushDays = CShort(TextBoxScheduleCompletionDays_Rush.Text)

                Else

                    TaskTemplate.TotalRushDays = Nothing

                End If

            End If

        End Sub
        Private Sub LoadTaskTemplateDetails()

            If String.IsNullOrEmpty(_TaskTemplateCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewForm_TaskTemplateDetails.DataSource = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, _TaskTemplateCode).OrderBy(Function(TaskTemplateDetail) TaskTemplateDetail.ProcessOrderNumber)
                        DataGridViewForm_TaskTemplateDetails.CurrentView.BestFitColumns()

                        'TextBoxScheduleCompletionDays_Rush.Text = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalRushDaysByTaskTemplateCode(DbContext, DataContext, _TaskTemplateCode), "d")
                        'TextBoxScheduleCompletionDays_Standard.Text = Format(AdvantageFramework.Database.Procedures.TaskTemplate.LoadTotalStandardDaysByTaskTemplateCode(DbContext, DataContext, _TaskTemplateCode), "d")

                        CalculateRushAndStandardDays()

                    End Using

                End Using

                'AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me.DataGridViewForm_TaskTemplateDetails)

            End If

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.TaskTemplate

            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

            Try

                If IsNew Then

                    TaskTemplate = New AdvantageFramework.Database.Entities.TaskTemplate

                    LoadEntity(TaskTemplate)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, _TaskTemplateCode)

                        If TaskTemplate IsNot Nothing Then

                            LoadEntity(TaskTemplate)

                        End If

                    End Using

                End If

            Catch ex As Exception
                TaskTemplate = Nothing
            End Try

            FillObject = TaskTemplate

        End Function
        Private Sub SaveDetailsGrid()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    SaveDetailsGrid(DbContext, DataContext)

                End Using

            End Using

        End Sub
        Private Sub SaveDetailsGrid(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext)

            'objects
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim TaskTemplateDtl As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

            If DbContext IsNot Nothing AndAlso DataContext IsNot Nothing Then

                For Each TaskTemplateDtl In DataGridViewForm_TaskTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.TaskTemplateDetail).ToList

                    TaskTemplateDetail = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateDetailID(DataContext, TaskTemplateDtl.ID)

                    TaskTemplateDetail.PhaseID = TaskTemplateDtl.PhaseID
                    TaskTemplateDetail.TaskCode = TaskTemplateDtl.TaskCode
                    TaskTemplateDetail.ProcessOrderNumber = TaskTemplateDtl.ProcessOrderNumber
                    TaskTemplateDetail.DaysToComplete = TaskTemplateDtl.DaysToComplete
                    TaskTemplateDetail.HoursAllowed = TaskTemplateDtl.HoursAllowed
                    TaskTemplateDetail.RushDaysToComplete = TaskTemplateDtl.RushDaysToComplete
                    TaskTemplateDetail.RushHoursToComplete = TaskTemplateDtl.RushHoursToComplete
                    TaskTemplateDetail.IsMilestone = TaskTemplateDtl.IsMilestone
                    TaskTemplateDetail.EmployeeCode = TaskTemplateDtl.EmployeeCode
                    TaskTemplateDetail.FunctionCode = TaskTemplateDtl.FunctionCode

                    AdvantageFramework.Database.Procedures.TaskTemplateDetail.Update(DbContext, DataContext, TaskTemplateDetail)

                Next

            Else

                SaveDetailsGrid()

            End If

        End Sub
        Private Sub CalculateRushAndStandardDays()

            'objects
            Dim StandardDays As Nullable(Of Integer) = Nothing
            Dim RushDays As Nullable(Of Integer) = Nothing
            Dim TaskTemplateDetails As Generic.List(Of AdvantageFramework.Database.Entities.TaskTemplateDetail) = Nothing

            Try

                TaskTemplateDetails = DataGridViewForm_TaskTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.TaskTemplateDetail).ToList

            Catch ex As Exception
                TaskTemplateDetails = Nothing
            End Try

            If TaskTemplateDetails IsNot Nothing Then

                Try

                    RushDays = (From TaskTemplateDetail In TaskTemplateDetails
                                Where TaskTemplateDetail.TaskTemplateCode = _TaskTemplateCode
                                Group TaskTemplateDetail By TaskTemplateDetail.ProcessOrderNumber Into TaskTemplateDetailsGroup = Group
                                Select TaskTemplateDetailsGroup.Max(Function(Entity) Entity.RushDaysToComplete.GetValueOrDefault(0))).Sum

                Catch ex As Exception
                    RushDays = Nothing
                End Try

                Try

                    StandardDays = (From TaskTemplateDetail In TaskTemplateDetails
                                    Where TaskTemplateDetail.TaskTemplateCode = _TaskTemplateCode
                                    Group TaskTemplateDetail By TaskTemplateDetail.ProcessOrderNumber Into TaskTemplateDetailsGroup = Group
                                    Select TaskTemplateDetailsGroup.Max(Function(Entity) Entity.DaysToComplete.GetValueOrDefault(0))).Sum

                Catch ex As Exception
                    StandardDays = Nothing
                End Try

            End If

            TextBoxScheduleCompletionDays_Rush.Text = RushDays
            TextBoxScheduleCompletionDays_Standard.Text = StandardDays

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TaskTemplate = Me.FillObject(False)

                    If TaskTemplate IsNot Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.TaskTemplate.Update(DbContext, TaskTemplate)

                        If Saved Then

                            SaveDetailsGrid()

                        End If

                    End If

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
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        TaskTemplate = Me.FillObject(False)

                        If TaskTemplate IsNot Nothing Then

                            Deleted = AdvantageFramework.Database.Procedures.TaskTemplate.Delete(DbContext, DataContext, TaskTemplate)

                            If Deleted = False Then

                                ErrorMessage = "The task template is in use and cannot be deleted."

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
        Public Function Insert(ByRef TaskTemplateCode As String) As Boolean

            'objects
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing
            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    TaskTemplate = Me.FillObject(True)

                    If TaskTemplate IsNot Nothing Then

                        TaskTemplate.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.TaskTemplate.Insert(DbContext, TaskTemplate) Then

                            TaskTemplateCode = TaskTemplate.Code
                            Inserted = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub CopyFrom()

            'objects
            Dim SelectedObject As IEnumerable = Nothing
            Dim TaskTemplateCode As String = Nothing
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim NewTaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim AtLeastOneDetailCopied As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                If String.IsNullOrEmpty(_TaskTemplateCode) = False Then

                    If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.TaskTemplate, True, True, SelectedObject, False, "Copy From Task Template...") = Windows.Forms.DialogResult.OK Then

                        If SelectedObject IsNot Nothing Then

                            Try

                                TaskTemplateCode = (From Entity In SelectedObject
                                                    Select Entity.Code).FirstOrDefault

                            Catch ex As Exception
                                TaskTemplateCode = Nothing
                            End Try

                            If TaskTemplateCode IsNot Nothing Then

                                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                        SaveDetailsGrid(DbContext, DataContext)

                                        For Each TaskTemplateDetail In AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateCode(DataContext, TaskTemplateCode)

                                            NewTaskTemplateDetail = New AdvantageFramework.Database.Entities.TaskTemplateDetail

                                            NewTaskTemplateDetail.TaskTemplateCode = _TaskTemplateCode
                                            NewTaskTemplateDetail.TaskCode = TaskTemplateDetail.TaskCode
                                            NewTaskTemplateDetail.PhaseID = TaskTemplateDetail.PhaseID
                                            NewTaskTemplateDetail.ProcessOrderNumber = TaskTemplateDetail.ProcessOrderNumber
                                            NewTaskTemplateDetail.DaysToComplete = TaskTemplateDetail.DaysToComplete
                                            NewTaskTemplateDetail.HoursAllowed = TaskTemplateDetail.HoursAllowed
                                            NewTaskTemplateDetail.RushDaysToComplete = TaskTemplateDetail.RushDaysToComplete
                                            NewTaskTemplateDetail.RushHoursToComplete = TaskTemplateDetail.RushHoursToComplete
                                            NewTaskTemplateDetail.IsMilestone = TaskTemplateDetail.IsMilestone
                                            NewTaskTemplateDetail.EmployeeCode = TaskTemplateDetail.EmployeeCode
                                            NewTaskTemplateDetail.FunctionCode = TaskTemplateDetail.FunctionCode
                                            NewTaskTemplateDetail.RoleCode = TaskTemplateDetail.RoleCode

                                            If AdvantageFramework.Database.Procedures.TaskTemplateDetail.Insert(DbContext, DataContext, NewTaskTemplateDetail) Then

                                                AtLeastOneDetailCopied = True

                                            End If

                                        Next

                                    End Using

                                End Using

                                If AtLeastOneDetailCopied Then

                                    LoadTaskTemplateDetails()

                                End If

                            End If

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to copy task template details. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Function LoadControl(ByVal TaskTemplateCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim TaskTemplate As AdvantageFramework.Database.Entities.TaskTemplate = Nothing

            _TaskTemplateCode = TaskTemplateCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _TaskTemplateCode <> "" Then

                    TextBoxForm_Code.Enabled = False
                    TextBoxForm_Code.ReadOnly = True

                    TaskTemplate = AdvantageFramework.Database.Procedures.TaskTemplate.LoadByTaskTemplateCode(DbContext, _TaskTemplateCode)

                    If TaskTemplate IsNot Nothing Then

                        TextBoxForm_Code.Text = TaskTemplate.Code
                        TextBoxForm_Description.Text = TaskTemplate.Description

                        LoadTaskTemplateDetails()

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxForm_Code.Enabled = True
                    TextBoxForm_Code.ReadOnly = False

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _Loaded = Loaded

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            TextBoxForm_Code.Text = ""
            TextBoxForm_Description.Text = ""
            DataGridViewForm_TaskTemplateDetails.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.TaskTemplateDetail))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CancelNewDetail()

            DataGridViewForm_TaskTemplateDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedDetail()

            'objects
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim TaskTemplateDetailID As Integer = Nothing
            Dim ErrorMessage As String = ""

            Try

                If DataGridViewForm_TaskTemplateDetails.HasOnlyOneSelectedRow Then

                    If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            TaskTemplateDetailID = DirectCast(DataGridViewForm_TaskTemplateDetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Entities.TaskTemplateDetail).ID

                        Catch ex As Exception
                            TaskTemplateDetailID = Nothing
                        End Try

                        If TaskTemplateDetailID <> Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    SaveDetailsGrid(DbContext, DataContext)

                                    TaskTemplateDetail = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateDetailID(DataContext, TaskTemplateDetailID)

                                    If TaskTemplateDetail IsNot Nothing Then

                                        If AdvantageFramework.Database.Procedures.TaskTemplateDetail.Delete(DbContext, DataContext, TaskTemplateDetail) Then

                                            LoadTaskTemplateDetails()

                                        End If

                                    End If

                                End Using

                            End Using

                        End If

                        Me.CloseWaitForm()

                    End If


                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub TaskTemplateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_TaskTemplateDetails_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_TaskTemplateDetails.AddNewRowEvent

            'objects
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.TaskTemplateDetail Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        TaskTemplateDetail = DirectCast(RowObject, AdvantageFramework.Database.Entities.TaskTemplateDetail)

                        If AdvantageFramework.Database.Procedures.TaskTemplateDetail.Insert(DbContext, DataContext, TaskTemplateDetail) Then

                            SaveDetailsGrid(DbContext, DataContext)

                            LoadTaskTemplateDetails()

                        End If

                    End Using

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_TaskTemplateDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TaskTemplateDetails.CellValueChangedEvent

            'objects
            Dim Task As AdvantageFramework.Database.Entities.Task = Nothing
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.TaskCode.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Task = AdvantageFramework.Database.Procedures.Task.LoadByTaskCode(DbContext, e.Value)

                    If Task IsNot Nothing Then

                        TaskTemplateDetail = DataGridViewForm_TaskTemplateDetails.CurrentView.GetRow(e.RowHandle)

                        If TaskTemplateDetail IsNot Nothing Then

                            TaskTemplateDetail.IsMilestone = Task.IsMilestone
                            TaskTemplateDetail.ProcessOrderNumber = Task.ProcessOrderNumber
                            TaskTemplateDetail.DaysToComplete = Task.DaysToComplete
                            TaskTemplateDetail.HoursAllowed = Task.HoursAllowed
                            TaskTemplateDetail.FunctionCode = Task.FunctionCode

                        End If

                    End If

                End Using

            ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.DaysToComplete.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.RushDaysToComplete.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.ProcessOrderNumber.ToString Then

                CalculateRushAndStandardDays()

            End If

        End Sub
        Private Sub DataGridViewForm_TaskTemplateDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TaskTemplateDetails.CellValueChangingEvent

            'objects
            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing
            Dim TaskTemplateDetailID As Integer = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.IsMilestone.ToString Then

                If DataGridViewForm_TaskTemplateDetails.IsNewItemRow(e.RowHandle) = False Then

                    Try

                        TaskTemplateDetailID = DirectCast(DataGridViewForm_TaskTemplateDetails.GetFirstSelectedRowDataBoundItem, AdvantageFramework.Database.Entities.TaskTemplateDetail).ID

                    Catch ex As Exception
                        TaskTemplateDetailID = Nothing
                    End Try

                    If TaskTemplateDetailID <> Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                TaskTemplateDetail = AdvantageFramework.Database.Procedures.TaskTemplateDetail.LoadByTaskTemplateDetailID(DataContext, TaskTemplateDetailID)

                                TaskTemplateDetail.IsMilestone = CLng(e.Value)

                                Saved = AdvantageFramework.Database.Procedures.TaskTemplateDetail.Update(DbContext, DataContext, TaskTemplateDetail)

                            End Using

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TaskTemplateDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_TaskTemplateDetails.InitNewRowEvent

            DataGridViewForm_TaskTemplateDetails.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.TaskTemplateCode.ToString, _TaskTemplateCode)

            RaiseEvent InitNewDetailRowEvent()

        End Sub
        Private Sub DataGridViewForm_TaskTemplateDetails_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_TaskTemplateDetails.NewItemRowCellValueChangedEvent

            Dim TaskTemplateDetail As AdvantageFramework.Database.Entities.TaskTemplateDetail = Nothing

            If e.Column.FieldName <> AdvantageFramework.Database.Entities.TaskTemplateDetail.Properties.PhaseID.ToString Then

                TaskTemplateDetail = DataGridViewForm_TaskTemplateDetails.CurrentView.GetRow(e.RowHandle)

                If TaskTemplateDetail IsNot Nothing Then

                    If TaskTemplateDetail.PhaseID = CLng(0) Then

                        TaskTemplateDetail.PhaseID = Nothing

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_TaskTemplateDetails_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewForm_TaskTemplateDetails.SelectionChangedEvent

            RaiseEvent SelectedDetailChangedEvent()

        End Sub

#End Region

#End Region

    End Class

End Namespace
