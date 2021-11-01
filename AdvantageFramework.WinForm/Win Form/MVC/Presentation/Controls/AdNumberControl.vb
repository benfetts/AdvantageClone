Namespace WinForm.MVC.Presentation.Controls

    Public Class AdNumberControl

        Public Event AdNumber_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event AdNumber_SelectionChangedEvent(sender As Object, e As EventArgs)
        Public Event AdNumber_Changed()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _ViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel = Nothing
        Private _Controller As AdvantageFramework.Controller.Maintenance.ProjectManagement.AdNumberSetupController = Nothing
        Private _ClientCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ViewModel As AdvantageFramework.ViewModels.Maintenance.ProjectManagement.AdNumberSetupViewModel
            Get
                ViewModel = _ViewModel
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.MVC.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    If _Controller Is Nothing Then

                        _Controller = New AdvantageFramework.Controller.Maintenance.ProjectManagement.AdNumberSetupController(DirectCast(Form, AdvantageFramework.WinForm.MVC.Presentation.BaseForms.Interfaces.IBaseForm).Session)

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadViewModel()

            DataGridViewControl_AdNumbers.DataSource = _ViewModel.AdNumbers

            FormatGrid()

        End Sub
        Private Sub AddAdNumber(AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            Dim ErrorMessage As String = Nothing

            If AdNumber IsNot Nothing Then

                If _Controller.AddAdNumber(_ViewModel, AdNumber, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewControl_AdNumbers.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewControl_AdNumbers.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    LoadViewModel()

                End If

            End If

        End Sub
        Private Sub FormatGrid()

            'objects
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            If DataGridViewControl_AdNumbers.Columns(AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.MediaType.ToString) IsNot Nothing AndAlso
                    TypeOf DataGridViewControl_AdNumbers.Columns(AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.MediaType.ToString).ColumnEdit IsNot AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl Then

                SubItemGridLookUpEditControl = New AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl

                SubItemGridLookUpEditControl.ControlType = AdvantageFramework.WinForm.MVC.Presentation.Controls.SubItemGridLookUpEditControl.Type.Default

                SubItemGridLookUpEditControl.NullText = ""
                SubItemGridLookUpEditControl.DisplayMember = "Display"
                SubItemGridLookUpEditControl.ValueMember = "Value"

                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Value",, "Code"))
                SubItemGridLookUpEditControl.View.Columns.Add(AdvantageFramework.WinForm.MVC.Presentation.Controls.GetNewColumn("Display", , "Media Type"))

                BindingSource = New System.Windows.Forms.BindingSource

                BindingSource.DataSource = _ViewModel.MediaTypes

                SubItemGridLookUpEditControl.DataSource = BindingSource

                DataGridViewControl_AdNumbers.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                DataGridViewControl_AdNumbers.Columns(AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.MediaType.ToString).ColumnEdit = SubItemGridLookUpEditControl

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(Optional ByVal ClientCode As String = Nothing) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ClientCode = ClientCode

            _ViewModel = _Controller.Load(ClientCode)

            LoadViewModel()

            DataGridViewControl_AdNumbers.CurrentView.BestFitColumns()

            DataGridViewControl_AdNumbers.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub Delete()

            DataGridViewControl_AdNumbers.CloseGridEditorAndSaveValueToDataSource()

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                _Controller.Delete(_ViewModel)

                DataGridViewControl_AdNumbers.DataSource = _ViewModel.AdNumbers

                DataGridViewControl_AdNumbers.GridViewSelectionChanged()

            End If

        End Sub
        Public Sub Save()

            DataGridViewControl_AdNumbers.CloseGridEditorAndSaveValueToDataSource()

            DataGridViewControl_AdNumbers.ValidateAllRows()

            If _ViewModel.AdNumbers.Any(Function(Entity) Entity.HasError) = False Then

                _Controller.Save(_ViewModel)

                DataGridViewControl_AdNumbers.ClearChanged()

                Me.ViewModel.SaveEnabled = False

                RaiseEvent AdNumber_Changed()

            End If

        End Sub
        Public Sub CancelNewItemRow()

            DataGridViewControl_AdNumbers.CurrentView.CancelNewItemRow()

            _ViewModel.CancelEnabled = False

        End Sub
        Public Sub DeleteDocument()

            If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                If _ViewModel.HasOnlyOneSelectedAdNumber AndAlso _ViewModel.SelectedAdNumberHasDocument Then

                    If _Controller.DeleteDocument(_ViewModel) Then

                        _ViewModel.SelectedAdNumbers.First.DocumentID = Nothing
                        _ViewModel.SelectedAdNumbers.First.DocumentName = Nothing
                        _ViewModel.SelectedAdNumbers.First.DocumentIsURL = False

                        DataGridViewControl_AdNumbers.CurrentView.RefreshData()

                    End If

                End If

            End If

        End Sub
        Public Sub DownloadDocument()

            Dim Document As AdvantageFramework.Database.Entities.Document = Nothing
            Dim Documents As Generic.List(Of AdvantageFramework.Database.Entities.Document) = Nothing

            If _ViewModel.HasOnlyOneSelectedAdNumber AndAlso _ViewModel.SelectedAdNumberHasDocument Then

                Document = _Controller.GetDocument(_ViewModel.SelectedAdNumbers.First.DocumentID.Value)

                If Document IsNot Nothing Then

                    Documents = New Generic.List(Of AdvantageFramework.Database.Entities.Document)

                    Documents.Add(Document)

                    AdvantageFramework.WinForm.Presentation.SaveDocument(_ViewModel.Session, Documents)

                End If

            End If

        End Sub
        Public Sub UploadDocument()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing
            Dim Upload As Boolean = True

            If _ViewModel.HasOnlyOneSelectedAdNumber Then

                If _ViewModel.SelectedAdNumberHasDocument Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Replace existing document?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.No Then

                        Upload = False

                    End If

                End If

                If Upload Then

                    DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber)
                    DocumentLevelSetting.AdNumber = _ViewModel.SelectedAdNumbers.First.Number

                    If AdvantageFramework.Desktop.Presentation.DocumentUploadDialog.ShowFormDialog(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber, DocumentLevelSetting, AdvantageFramework.Database.Entities.DocumentSubLevel.Default) = Windows.Forms.DialogResult.OK Then

                        _Controller.RefreshDocument(_ViewModel)

                        DataGridViewControl_AdNumbers.CurrentView.RefreshData()
                        DataGridViewControl_AdNumbers.CurrentView.RefreshEditor(True)

                    End If

                End If

            End If

        End Sub
        Public Sub SendASPUploadEmail()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If _ViewModel.HasOnlyOneSelectedAdNumber Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.AdNumber) With {.AdNumber = _ViewModel.SelectedAdNumbers.First.Number}

                If AdvantageFramework.WinForm.Presentation.SendASPUploadEmail(_ViewModel.Session, AdvantageFramework.Database.Entities.DocumentLevel.AdNumber, AdvantageFramework.Database.Entities.DocumentSubLevel.Default, DocumentLevelSetting) Then

                    AdvantageFramework.WinForm.MessageBox.Show("Upload email sent!")

                End If

            End If

        End Sub
        Public Sub Export()

            DataGridViewControl_AdNumbers.Print(DevExpress.LookAndFeel.UserLookAndFeel.Default, "Ad Number Maintenance", _Controller.GetAgency, _Controller.Session, UseLandscape:=True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub AdNumberControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_AdNumbers_CellValueChangingEvent(ByRef Saved As Boolean, sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_AdNumbers.CellValueChangingEvent

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle Then

                If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.IsInactive.ToString Then

                    If _Controller.UpdateIsInactive(e.Value, _ViewModel) Then

                        DataGridViewControl_AdNumbers.RemoveFromModifiedRows(_ViewModel.SelectedAdNumbers.First)

                    End If

                Else

                    DataGridViewControl_AdNumbers.AddToModifiedRows(e.RowHandle)

                End If

            End If

            Me.ViewModel.SaveEnabled = Me.DataGridViewControl_AdNumbers.CheckForModifiedRows()

            RaiseEvent AdNumber_Changed()

        End Sub
        Private Sub DataGridViewControl_AdNumbers_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_AdNumbers.CellValueChangedEvent

            'objects
            Dim AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber = Nothing

            AdNumber = DirectCast(DataGridViewControl_AdNumbers.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber)

            If e.Column.FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ClientCode.ToString Then

                _Controller.ClientCodeChanged(_ViewModel, e.Value, AdNumber)

            ElseIf e.Column.FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.DivisionCode.ToString Then

                _Controller.DivisionCodeChanged(_ViewModel, e.Value, AdNumber)

            End If

        End Sub
        Private Sub DataGridViewControl_AdNumbers_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_AdNumbers.InitNewRowEvent

            DirectCast(DataGridViewControl_AdNumbers.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber).ClientCode = _ClientCode

            _Controller.AdNumbers_InitNewRowEvent(_ViewModel)

            RaiseEvent AdNumber_InitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_AdNumbers_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_AdNumbers.QueryPopupNeedDatasourceEvent

            'objects
            Dim AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber = Nothing

            AdNumber = DataGridViewControl_AdNumbers.CurrentView.GetRow(DataGridViewControl_AdNumbers.CurrentView.FocusedRowHandle)

            If FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ClientCode.ToString Then

                Datasource = _Controller.GetRepositoryClients(_ClientCode)

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.DivisionCode.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetRepositoryDivisions(AdNumber.ClientCode)

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ProductCode.ToString Then

                OverrideDefaultDatasource = True

                Datasource = _Controller.GetRepositoryProducts(AdNumber.ClientCode, AdNumber.DivisionCode)

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.BlackplateCode1.ToString Then

                Datasource = _Controller.GetRepositoryBlackplates()

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.BlackplateCode2.ToString Then

                Datasource = _Controller.GetRepositoryBlackplates()

            End If

        End Sub
        Private Sub DataGridViewControl_AdNumbers_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewControl_AdNumbers.RepositoryDataSourceLoadingEvent

            If FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ClientCode.ToString Then

                Datasource = _ViewModel.Clients

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.DivisionCode.ToString Then

                Datasource = _ViewModel.Divisions

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ProductCode.ToString Then

                Datasource = _ViewModel.Products

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.BlackplateCode1.ToString Then

                Datasource = _ViewModel.Blackplates

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.BlackplateCode2.ToString Then

                Datasource = _ViewModel.Blackplates

            ElseIf FieldName = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.MediaType.ToString Then

                Datasource = _ViewModel.MediaTypes

            End If

        End Sub
        Private Sub DataGridViewControl_AdNumbers_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_AdNumbers.SelectionChangedEvent

            'objects
            Dim SelectedAdNumbers As Generic.List(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber) = Nothing

            SelectedAdNumbers = DataGridViewControl_AdNumbers.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber).ToList

            _Controller.AdNumbers_SelectedChanged(_ViewModel, DataGridViewControl_AdNumbers.IsNewItemRow, SelectedAdNumbers)

            RaiseEvent AdNumber_SelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_AdNumbers_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_AdNumbers.ShowingEditorEvent

            'objects
            Dim AdNumber As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber = Nothing

            AdNumber = DataGridViewControl_AdNumbers.CurrentView.GetRow(DataGridViewControl_AdNumbers.CurrentView.FocusedRowHandle)

            If DataGridViewControl_AdNumbers.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.Number.ToString Then

                If DataGridViewControl_AdNumbers.IsNewItemRow = False Then

                    e.Cancel = True

                End If

            ElseIf DataGridViewControl_AdNumbers.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ClientCode.ToString AndAlso
                    String.IsNullOrWhiteSpace(_ClientCode) = False Then

                e.Cancel = True

            ElseIf DataGridViewControl_AdNumbers.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.DivisionCode.ToString AndAlso
                    (AdNumber Is Nothing OrElse String.IsNullOrWhiteSpace(AdNumber.ClientCode)) Then

                e.Cancel = True

            ElseIf DataGridViewControl_AdNumbers.CurrentView.FocusedColumn.Name = AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber.Properties.ProductCode.ToString AndAlso
                    (AdNumber Is Nothing OrElse String.IsNullOrWhiteSpace(AdNumber.DivisionCode)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewControl_AdNumbers_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_AdNumbers.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Maintenance.ProjectManagement.AdNumber = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewControl_AdNumbers.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewControl_AdNumbers.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewControl_AdNumbers.CurrentView.SetColumnError(DataGridViewControl_AdNumbers.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewControl_AdNumbers_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewControl_AdNumbers.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewControl_AdNumbers.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewControl_AdNumbers.CurrentView.NewItemRowText = e.ErrorText
                    'DataGridViewControl_AdNumbers.CurrentView.SetColumnError(DataGridViewControl_AdNumbers.CurrentView.Columns("Name"), e.ErrorText)

                    If e.Valid Then

                        AddAdNumber(e.Row)

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
