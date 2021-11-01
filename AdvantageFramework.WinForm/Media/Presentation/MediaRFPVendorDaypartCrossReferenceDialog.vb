Namespace Media.Presentation

    Public Class MediaRFPVendorDaypartCrossReferenceDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaRFPVendorDaypartCrossReferenceViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaRFPVendorDaypartCrossReferenceController = Nothing
        Protected _VendorCode As String = Nothing
        Protected _VendorName As String = Nothing
        Protected _MediaTypeCode As String = Nothing
        Protected _DaypartNames As IEnumerable(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(VendorCode As String, VendorName As String, MediaTypeCode As String, DaypartNames As IEnumerable(Of String))

            ' This call is required by the designer.
            InitializeComponent()

            _VendorCode = VendorCode
            _VendorName = VendorName
            _MediaTypeCode = MediaTypeCode
            _DaypartNames = DaypartNames

        End Sub
        Private Sub LoadViewModel()

            _ViewModel = _Controller.Load(_VendorCode, _MediaTypeCode, _DaypartNames)

        End Sub
        Private Sub LoadGrid()

            DataGridViewPanel_VendorDayparts.DataSource = _ViewModel.MediaRFPVendorDaypartCrossReferenceList

        End Sub
        Private Sub RefreshViewModel(LoadGrid As Boolean)

            If LoadGrid Then

                DataGridViewPanel_VendorDayparts.CurrentView.RefreshData()

            End If

            ButtonItemActions_Save.Enabled = _ViewModel.SaveEnabled
            ButtonItemActions_Delete.Enabled = _ViewModel.DeleteEnabled
            ButtonItemActions_Cancel.Enabled = _ViewModel.CancelEnabled

        End Sub
        Private Sub SetControlPropertySettings()

            TextBoxPanel_VendorCode.ReadOnly = True
            TextBoxPanel_VendorName.ReadOnly = True

            DataGridViewPanel_VendorDayparts.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top
            DataGridViewPanel_VendorDayparts.OptionsBehavior.Editable = True
            DataGridViewPanel_VendorDayparts.MultiSelect = False

        End Sub
        Private Sub AddNewRow(MediaRFPVendorDaypartCrossReference As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference)

            Dim ErrorMessage As String = Nothing

            If MediaRFPVendorDaypartCrossReference IsNot Nothing Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.Adding)

                If _Controller.Add(MediaRFPVendorDaypartCrossReference, ErrorMessage) = False Then

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                Else

                    DataGridViewPanel_VendorDayparts.CurrentView.FocusedRowHandle = DevExpress.XtraGrid.GridControl.NewItemRowHandle
                    DataGridViewPanel_VendorDayparts.CurrentView.SelectRow(DevExpress.XtraGrid.GridControl.NewItemRowHandle)

                    RefreshViewModel(True)

                End If

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.Methods.FormActions.None)

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(VendorCode As String, VendorName As String, MediaTypeCode As String, DaypartNames As IEnumerable(Of String)) As System.Windows.Forms.DialogResult

            'objects
            Dim RFPVendorDaypartCrossReferenceDialog As MediaRFPVendorDaypartCrossReferenceDialog = Nothing

            RFPVendorDaypartCrossReferenceDialog = New MediaRFPVendorDaypartCrossReferenceDialog(VendorCode, VendorName, MediaTypeCode, DaypartNames)

            ShowFormDialog = RFPVendorDaypartCrossReferenceDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaRFPVendorDaypartCrossReferenceDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            _Controller = New AdvantageFramework.Controller.Media.MediaRFPVendorDaypartCrossReferenceController(Me.Session)

            SetControlPropertySettings()

            TextBoxPanel_VendorCode.Text = _VendorCode
            TextBoxPanel_VendorName.Text = _VendorName

        End Sub
        Private Sub MediaRFPVendorDaypartCrossReferenceDialog_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            LoadGrid()

            RefreshViewModel(True)

            Me.ClearChanged()

            DataGridViewPanel_VendorDayparts.CurrentView.BestFitColumns()

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            Me.CloseWaitForm()

        End Sub
        Private Sub MediaRFPVendorDaypartCrossReferenceDialog_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.UserEntryChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub
        Private Sub MediaRFPVendorDaypartCrossReferenceDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            If _ViewModel IsNot Nothing Then

                _Controller.ClearChanged(_ViewModel)

                RefreshViewModel(False)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewPanel_VendorDayparts.CancelNewItemRow()

            _Controller.CancelNewItemRow(_ViewModel)

            RefreshViewModel(False)

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If DataGridViewPanel_VendorDayparts.HasASelectedRow Then

                DataGridViewPanel_VendorDayparts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting)

                    If _Controller.Delete(_ViewModel, ErrorMessage) = False Then

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                    RefreshViewModel(True)

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_VendorDayparts.IsNewItemRow, DataGridViewPanel_VendorDayparts.GetFirstSelectedRowDataBoundItem)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            DataGridViewPanel_VendorDayparts.CurrentView.CloseEditorForUpdating()

            If _ViewModel.MediaRFPVendorDaypartCrossReferenceList.Any(Function(Entity) Entity.HasError) = False Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving)

                _Controller.Save(_ViewModel)

                RefreshViewModel(False)

                Me.ClearChanged()

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before saving.")

            End If

        End Sub
        Private Sub DataGridViewPanel_VendorDayparts_FocusedRowChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles DataGridViewPanel_VendorDayparts.FocusedRowChangedEvent

            _Controller.SelectionChanged(_ViewModel, DataGridViewPanel_VendorDayparts.IsNewItemRow, DataGridViewPanel_VendorDayparts.GetFirstSelectedRowDataBoundItem)

            RefreshViewModel(False)

        End Sub
        Private Sub DataGridViewPanel_VendorDayparts_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewPanel_VendorDayparts.InitNewRowEvent

            DirectCast(DataGridViewPanel_VendorDayparts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference).VendorCode = _VendorCode

        End Sub
        Private Sub DataGridViewPanel_VendorDayparts_RepositoryDataSourceLoadingEvent(FieldName As String, ByRef Datasource As Object) Handles DataGridViewPanel_VendorDayparts.RepositoryDataSourceLoadingEvent

            If FieldName = DTO.Media.RFP.MediaRFPVendorDaypartCrossReference.Properties.DaypartID.ToString Then

                Datasource = _ViewModel.RepositoryDaypartList

            End If

        End Sub
        Private Sub DataGridViewPanel_VendorDayparts_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewPanel_VendorDayparts.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                If DataGridViewPanel_VendorDayparts.CurrentView.IsNewItemRow(e.RowHandle) = False Then

                    e.Valid = True

                Else

                    DataGridViewPanel_VendorDayparts.CurrentView.NewItemRowText = e.ErrorText

                    If e.Valid Then

                        AddNewRow(e.Row)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewPanel_VendorDayparts_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewPanel_VendorDayparts.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.RFP.MediaRFPVendorDaypartCrossReference = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewPanel_VendorDayparts.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewPanel_VendorDayparts.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                DataGridViewPanel_VendorDayparts.CurrentView.SetColumnError(DataGridViewPanel_VendorDayparts.CurrentView.FocusedColumn, ErrorText)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
