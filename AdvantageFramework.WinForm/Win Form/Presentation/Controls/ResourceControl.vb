Namespace WinForm.Presentation.Controls

    Public Class ResourceControl

        Public Event ResourceTasksSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ResourceTasksInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event ResourceInActiveChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ResourceCode As String = Nothing
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property ResourceTasksHasRows() As Boolean
            Get
                ResourceTasksHasRows = DataGridViewControl_ResourceTasks.HasRows
            End Get
        End Property
        Public ReadOnly Property ResourceTasksHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                ResourceTasksHasOnlyOneSelectedRow = DataGridViewControl_ResourceTasks.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property ResourceTasksIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                ResourceTasksIsNewItemRow = DataGridViewControl_ResourceTasks.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property ResourceTasksFocusedRowHandle() As Integer
            Get
                ResourceTasksFocusedRowHandle = DataGridViewControl_ResourceTasks.CurrentView.FocusedRowHandle
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

                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Resource.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.Resource.Properties.Description)
                            NumericInputControl_Priority.SetPropertySettings(AdvantageFramework.Database.Entities.Resource.Properties.Priority)
                            NumericInputControl_Priority.Properties.MinValue = 0
                            NumericInputControl_Priority.Properties.MaxValue = 9999
                            NumericInputControl_Priority.Properties.MaxLength = 4

                        End Using

                        LoadDropDownDataSources()

                    End If

                    CheckBoxControl_Inactive.ByPassUserEntryChanged = True

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadControlDetails()

            Dim ResourceTasks As Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ResourceCode <> "" Then

                    ResourceTasks = AdvantageFramework.Database.Procedures.ResourceTask.LoadByResourceCode(DbContext, _ResourceCode).ToList

                    If ResourceTasks IsNot Nothing Then

                        LoadControlDetails(ResourceTasks)

                    End If
                End If

            End Using

        End Sub
        Private Sub LoadControlDetails(ByVal ResourceTasks As Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask))

            DataGridViewControl_ResourceTasks.DataSource = ResourceTasks

            DataGridViewControl_ResourceTasks.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadResourceEntity(ByVal Resource As AdvantageFramework.Database.Entities.Resource)

            If Resource IsNot Nothing Then

                Resource.Code = TextBoxControl_Code.Text
                Resource.Description = TextBoxControl_Description.Text
                Resource.Priority = NumericInputControl_Priority.Text
                Resource.IsInactive = CShort(CheckBoxControl_Inactive.CheckValue)

                Resource.ResourceTypeCode = SearchableComboBoxControl_ResourceType.GetSelectedValue

            End If

        End Sub
        Private Sub CheckGrid(ByVal RowHandle As Integer)

            If DirectCast(DataGridViewControl_ResourceTasks.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Entities.ResourceTask).HoursAllowed > 23 Then

                AdvantageFramework.WinForm.MessageBox.Show("Hours Allowed cannot be greater than 23.00", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK)

                DataGridViewControl_ResourceTasks.CurrentView.SetRowCellValue(RowHandle, DataGridViewControl_ResourceTasks.CurrentView.Columns("HoursAllowed"), 0)

            ElseIf DirectCast(DataGridViewControl_ResourceTasks.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Entities.ResourceTask).SetHours > 23 Then

                AdvantageFramework.WinForm.MessageBox.Show("Set Hours cannot be greater than 23.00", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.OK)

                DataGridViewControl_ResourceTasks.CurrentView.SetRowCellValue(RowHandle, DataGridViewControl_ResourceTasks.CurrentView.Columns("SetHours"), 0)

            End If

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewControl_ResourceTasks.UseEmbeddedNavigator = True

            Else

                DataGridViewControl_ResourceTasks.UseEmbeddedNavigator = False

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxControl_ResourceType.DataSource = AdvantageFramework.Database.Procedures.ResourceType.LoadAllActive(DbContext)

            End Using

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal ResourceCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing

            _ResourceCode = ResourceCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ResourceCode <> "" Then

                    Resource = AdvantageFramework.Database.Procedures.Resource.LoadByCode(DbContext, _ResourceCode)

                    If Resource IsNot Nothing Then

                        _IsLoading = True

                        TextBoxControl_Code.Enabled = False

                        TextBoxControl_Code.Text = Resource.Code
                        TextBoxControl_Description.Text = Resource.Description
                        NumericInputControl_Priority.Text = Resource.Priority.ToString
                        CheckBoxControl_Inactive.CheckValue = Resource.IsInactive.GetValueOrDefault(0)
                        SearchableComboBoxControl_ResourceType.SelectedValue = Resource.ResourceTypeCode

                        LoadControlDetails()

                        _IsLoading = False

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxControl_Code.Enabled = True

                    LoadControlDetails(New Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask))

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillResourceTaskObjects() As Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask)

            'objects
            Dim ResourceTasks As Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask) = Nothing

            DataGridViewControl_ResourceTasks.CurrentView.CloseEditorForUpdating()

            ResourceTasks = DataGridViewControl_ResourceTasks.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ResourceTask).ToList

            FillResourceTaskObjects = ResourceTasks

        End Function
        Public Sub ResourceTasksCancelNewItemRow()

            DataGridViewControl_ResourceTasks.CancelNewItemRow()

        End Sub
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Resource

            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing

            Try

                If IsNew Then

                    Resource = New AdvantageFramework.Database.Entities.Resource

                    LoadResourceEntity(Resource)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Resource = AdvantageFramework.Database.Procedures.Resource.LoadByCode(DbContext, _ResourceCode)

                    End Using

                    If Resource IsNot Nothing Then

                        LoadResourceEntity(Resource)

                    End If

                End If

            Catch ex As Exception
                Resource = Nothing
            End Try

            FillObject = Resource

        End Function
        Public Sub DeleteResourceTasks()

            'objects
            Dim ResourceTasks As Generic.List(Of AdvantageFramework.Database.Entities.ResourceTask) = Nothing

            If DataGridViewControl_ResourceTasks.HasASelectedRow Then

                If _ResourceCode <> "" Then

                    DataGridViewControl_ResourceTasks.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            ResourceTasks = DataGridViewControl_ResourceTasks.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ResourceTask)().ToList

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each ResourceTask In ResourceTasks

                                    AdvantageFramework.Database.Procedures.ResourceTask.Delete(DbContext, ResourceTask)

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                        LoadControlDetails()

                    End If

                Else

                    DataGridViewControl_ResourceTasks.CurrentView.DeleteSelectedRows()

                End If

            End If

        End Sub
        Public Sub ClearControl()

            _IsClearing = True

            TextBoxControl_Code.Text = Nothing
            CheckBoxControl_Inactive.Checked = False
            TextBoxControl_Description.Text = Nothing
            NumericInputControl_Priority.Text = Nothing

            SearchableComboBoxControl_ResourceType.SelectedValue = Nothing

            DataGridViewControl_ResourceTasks.DataSource = Nothing
            DataGridViewControl_ResourceTasks.ClearColumns()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

        End Sub
        Public Sub ExportResourceTasks()

            If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                DataGridViewControl_ResourceTasks.Print(DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).DefaultLookAndFeel.LookAndFeel, Me.FindForm.Name.Replace("SetupForm", ""))

            End If

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Resource = Me.FillObject(False)

                    If Resource IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Resource.Update(DbContext, Resource) Then

                            Saved = True

                            For Each ResourceTask In FillResourceTaskObjects()

                                ResourceTask.ResourceCode = Resource.Code

                                AdvantageFramework.Database.Procedures.ResourceTask.Update(DbContext, ResourceTask)

                            Next

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
            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Resource = Me.FillObject(False)

                    If Resource IsNot Nothing Then

                        If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM dbo.EVENT WHERE RESOURCE_CODE = '" & Resource.Code & "'").FirstOrDefault = 0 Then

                            Deleted = AdvantageFramework.Database.Procedures.Resource.Delete(DbContext, Resource)

                        End If

                    End If

                End Using

                If Deleted = False AndAlso ErrorMessage = "" Then

                    ErrorMessage = "The Resource is in use and cannot be deleted."

                End If

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
            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Resource = Me.FillObject(True)

                    If Resource IsNot Nothing Then

                        Resource.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Resource.Insert(DbContext, Resource) Then

                            Inserted = True

                            For Each ResourceTask In FillResourceTaskObjects()

                                ResourceTask.ResourceCode = Resource.Code

                                AdvantageFramework.Database.Procedures.ResourceTask.Insert(DbContext, ResourceTask)

                            Next

                            Code = Resource.Code

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
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ResourceControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub CheckBoxControl_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControl_Inactive.CheckedChanged

            Dim Resource As AdvantageFramework.Database.Entities.Resource = Nothing

            If Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Resource = AdvantageFramework.Database.Procedures.Resource.LoadByCode(DbContext, _ResourceCode)

                    If Resource IsNot Nothing Then

                        Resource.IsInactive = CheckBoxControl_Inactive.Checked

                        If AdvantageFramework.Database.Procedures.Resource.Update(DbContext, Resource) Then

                            RaiseEvent ResourceInActiveChanged()

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_ResourceTasks.AddNewRowEvent

            'objects
            Dim ResourceTask As AdvantageFramework.Database.Entities.ResourceTask = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ResourceTask Then

                If _ResourceCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    ResourceTask = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If ResourceTask.IsEntityBeingAdded() Then

                            ResourceTask.DbContext = DbContext

                            ResourceTask.ResourceCode = TextBoxControl_Code.Text

                            AdvantageFramework.Database.Procedures.ResourceTask.Insert(DbContext, ResourceTask)

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_ResourceTasks.SelectionChangedEvent

            RaiseEvent ResourceTasksSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_ResourceTasks.InitNewRowEvent

            If TypeOf DataGridViewControl_ResourceTasks.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.ResourceTask Then

                DirectCast(DataGridViewControl_ResourceTasks.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.ResourceTask).ResourceCode = TextBoxControl_Code.Text

                RaiseEvent ResourceTasksInitNewRowEvent(sender, e)

            End If

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_CellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_ResourceTasks.CellValueChangedEvent

            If DataGridViewControl_ResourceTasks.GetFirstSelectedRowBookmarkValue IsNot Nothing Then

                CheckGrid(e.RowHandle)

            End If

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_NewItemRowCellValueChangedEvent(ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_ResourceTasks.NewItemRowCellValueChangedEvent

            CheckGrid(e.RowHandle)

        End Sub
        Private Sub DataGridViewControl_ResourceTasks_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_ResourceTasks.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewControl_ResourceTasks.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteResourceTasks()

                        e.Handled = True

                End Select

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
