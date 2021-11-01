Namespace Media.Presentation

    Public Class MediaPlanCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Controller As AdvantageFramework.Controller.Media.MediaPlanningController = Nothing
        Private _ViewModel As AdvantageFramework.ViewModels.Media.MediaPlanCopyViewModel = Nothing
        Private _MediaPlanDetailIDs As IEnumerable(Of Integer) = Nothing
        Private _DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String)
            Get
                DictionaryMediaPlanDetailIDs = _DictionaryMediaPlanDetailIDs
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(MediaPlanDetailIDs As IEnumerable(Of Integer))

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlanDetailIDs = MediaPlanDetailIDs

        End Sub
        'Private Sub ValidateViewModel()

        '    _ViewModel.MediaPlanCopyList = DataGridViewForm_MediaEstimates.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanCopy).ToList

        '    _Controller.ValidateMediaPlanCopys(_ViewModel)

        '    DataGridViewForm_MediaEstimates.DataSource = Nothing
        '    DataGridViewForm_MediaEstimates.DataSource = _ViewModel.MediaPlanCopyList

        'End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlanDetailIDs As IEnumerable(Of Integer),
                                              ByRef DictionaryMediaPlanDetailIDs As Dictionary(Of Integer, String)) As Windows.Forms.DialogResult

            'objects
            Dim MediaPlanCopyDialog As AdvantageFramework.Media.Presentation.MediaPlanCopyDialog = Nothing

            MediaPlanCopyDialog = New AdvantageFramework.Media.Presentation.MediaPlanCopyDialog(MediaPlanDetailIDs)

            ShowFormDialog = MediaPlanCopyDialog.ShowDialog()

            DictionaryMediaPlanDetailIDs = MediaPlanCopyDialog.DictionaryMediaPlanDetailIDs

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanCopyDialog_Load(sender As Object, e As EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaPlanningController(Me.Session)

            _ViewModel = _Controller.LoadMediaPlanCopy(_MediaPlanDetailIDs)

            DataGridViewForm_MediaEstimates.DataSource = _ViewModel.MediaPlanCopyList
            DataGridViewForm_MediaEstimates.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            DataGridViewForm_MediaEstimates.CurrentView.CloseEditorForUpdating()

            DataGridViewForm_MediaEstimates.ValidateAllRows()

            If _ViewModel.MediaPlanCopyList.Any(Function(Entity) Entity.HasError) = False Then

                _DictionaryMediaPlanDetailIDs = DataGridViewForm_MediaEstimates.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.DTO.Media.MediaPlanCopy).ToDictionary(Function(DTO) DTO.MediaPlanDetailID, Function(DTO) DTO.SalesClassCode)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please fix data entry errors before saving.")

            End If

        End Sub
        Private Sub DataGridViewForm_MediaEstimates_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_MediaEstimates.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.DTO.Media.MediaPlanCopy.Properties.SalesClassCode.ToString Then

                OverrideDefaultDatasource = True
                Datasource = _Controller.GetSalesClassesBySalesClassTypeCode(DirectCast(DataGridViewForm_MediaEstimates.GetRowDataBoundItem(DataGridViewForm_MediaEstimates.CurrentView.FocusedRowHandle), AdvantageFramework.DTO.Media.MediaPlanCopy).SalesClassType)

            End If

        End Sub
        Private Sub DataGridViewForm_MediaEstimates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_MediaEstimates.ShowingEditorEvent

            If DataGridViewForm_MediaEstimates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.DTO.Media.MediaPlanCopy.Properties.SalesClassCode.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_MediaEstimates_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_MediaEstimates.ValidateRowEvent

            If e.Row IsNot Nothing Then

                e.ErrorText = _Controller.ValidateEntity(e.Row, e.Valid)

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewForm_MediaEstimates_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_MediaEstimates.ValidatingEditorEvent

            'objects
            Dim FocusedRow As AdvantageFramework.DTO.Media.MediaPlanCopy = Nothing
            Dim ErrorText As String = String.Empty

            FocusedRow = DataGridViewForm_MediaEstimates.CurrentView.GetFocusedRow

            If FocusedRow IsNot Nothing Then

                ErrorText = _Controller.ValidateProperty(FocusedRow, DataGridViewForm_MediaEstimates.CurrentView.FocusedColumn.FieldName, e.Valid, e.Value)

                e.Valid = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace