Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailRateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _DataTableID As Integer = 0
        Protected _RateChanged As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(DateTableID As Integer, ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel)

            ' This call is required by the designer.
            InitializeComponent()

            _ViewModel = MediaBroadcastWorksheetMarketDetailsViewModel
            _DataTableID = DateTableID

        End Sub
        Private Sub LoadViewModel()

            'objects
            Dim DataTable As System.Data.DataTable = Nothing

            DataTable = _ViewModel.DataTable.DefaultView.ToTable()

            DataTable.DefaultView.RowFilter = AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString & " = " & _DataTableID

            DataGridViewForm_LineDateRate.DataSource = DataTable.DefaultView.ToTable()

        End Sub
        Private Sub SaveViewModel()

            'objects
            Dim DataTableID As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing

            For RowHandle = 0 To DataGridViewForm_LineDateRate.CurrentView.RowCount - 1

                If DataGridViewForm_LineDateRate.CurrentView.IsDataRow(RowHandle) Then

                    DataTableID = DataGridViewForm_LineDateRate.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

                    DataRow = _ViewModel.DataTable.Rows.Find(DataTableID)

                    For Each GridColumn In DataGridViewForm_LineDateRate.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                        If DataRow(GridColumn.FieldName) <> DataGridViewForm_LineDateRate.CurrentView.GetRowCellValue(RowHandle, GridColumn.FieldName) Then

                            _Controller.MarketDetails_RateChanged(_ViewModel, _ViewModel.DataTable.Rows.IndexOf(DataRow), GridColumn.FieldName, True)

                        End If

                        DataRow(GridColumn.FieldName) = DataGridViewForm_LineDateRate.CurrentView.GetRowCellValue(RowHandle, GridColumn.FieldName)

                    Next

                End If

            Next

        End Sub
        Private Sub RefreshViewModel()



        End Sub
        Private Sub FormatControls()

            'objects
            Dim DateNumber As Integer = 0
            Dim StartDateNumber As Integer = 0
            Dim EndDateNumber As Integer = 0
            Dim ColumnName As String = String.Empty
            Dim ShowColumn As Boolean = False

            StartDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_ViewModel.StartDateSelection, "0")
            EndDateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(_ViewModel.EndDateSelection, "0")

            For Each GridColumn In DataGridViewForm_LineDateRate.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                ShowColumn = False

                If _ViewModel.RateDates.ContainsValue(GridColumn.FieldName) Then

                    DateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(GridColumn.FieldName, "0")

                    If _ViewModel.HideHiatusDates Then

                        ColumnName = GridColumn.FieldName.Replace("Rate", "Date")

                        If _ViewModel.HiatusDataTable.Rows(0)(ColumnName) = False Then

                            ShowColumn = True

                        Else

                            ShowColumn = False

                        End If

                    Else

                        ShowColumn = True

                    End If

                    If (DateNumber >= StartDateNumber AndAlso DateNumber <= EndDateNumber) AndAlso
                            ShowColumn Then

                        GridColumn.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        GridColumn.DisplayFormat.FormatString = "c2"
                        GridColumn.OptionsColumn.AllowMove = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False
                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.AllowFocus = Not _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date"))
                        GridColumn.Visible = True

                    Else

                        GridColumn.OptionsColumn.AllowMove = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False
                        GridColumn.OptionsColumn.ShowInExpressionEditor = False
                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.Visible = False

                    End If

                Else

                    GridColumn.OptionsColumn.AllowMove = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False
                    GridColumn.OptionsColumn.ShowInExpressionEditor = False
                    GridColumn.OptionsColumn.AllowShowHide = False
                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_LineDateRate.OptionsView.ShowViewCaption = False
            DataGridViewForm_LineDateRate.OptionsCustomization.AllowSort = False
            DataGridViewForm_LineDateRate.OptionsCustomization.AllowFilter = False
            DataGridViewForm_LineDateRate.OptionsCustomization.AllowGroup = False

            Me.Text = _ViewModel.DateRateCaption

        End Sub
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewForm_LineDateRate.CurrentView.PostEditor() Then

                DataGridViewForm_LineDateRate.CurrentView.UpdateCurrentRow()

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DateTableID As Integer, ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketDetailRateDialog As MediaBroadcastWorksheetMarketDetailRateDialog = Nothing

            MediaBroadcastWorksheetMarketDetailRateDialog = New MediaBroadcastWorksheetMarketDetailRateDialog(DateTableID, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketDetailRateDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailRateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailRateDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            FormatControls()

            RefreshViewModel()

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_LineDateRate.CurrentView.Focus()

            For Each GridColumn In DataGridViewForm_LineDateRate.CurrentView.VisibleColumns

                If _ViewModel.HiatusDataTable.Rows(0)(GridColumn.FieldName.Replace("Rate", "Date")) = False Then

                    DataGridViewForm_LineDateRate.CurrentView.FocusedColumn = GridColumn
                    Exit For

                End If

            Next

            DataGridViewForm_LineDateRate.CurrentView.ShowEditor()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

            SaveViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            If _RateChanged Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Else

                Me.DialogResult = Windows.Forms.DialogResult.Cancel

            End If

            Me.Close()

        End Sub
        Private Sub DataGridViewForm_LineDateRate_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_LineDateRate.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemSpinEdit As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit = Nothing

            If _ViewModel.RateDates.ContainsValue(e.Column.FieldName) Then

                RepositoryItemSpinEdit = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit

                RepositoryItemSpinEdit.AllowMouseWheel = False
                RepositoryItemSpinEdit.AllowNullInput = DevExpress.Utils.DefaultBoolean.False
                RepositoryItemSpinEdit.EditMask = "c2"
                RepositoryItemSpinEdit.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.DisplayFormat.FormatString = "c2"
                RepositoryItemSpinEdit.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                RepositoryItemSpinEdit.EditFormat.FormatString = "c2"
                RepositoryItemSpinEdit.Mask.UseMaskAsDisplayFormat = True
                RepositoryItemSpinEdit.Mask.EditMask = "c2"
                RepositoryItemSpinEdit.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
                RepositoryItemSpinEdit.IsFloatValue = True
                RepositoryItemSpinEdit.MinValue = 0
                RepositoryItemSpinEdit.MaxValue = 999999.99
                RepositoryItemSpinEdit.MaxLength = 9
                RepositoryItemSpinEdit.Buttons.Clear()

                e.RepositoryItem = RepositoryItemSpinEdit

            End If

        End Sub
        Private Sub DataGridViewForm_LineDateRate_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_LineDateRate.CellValueChangedEvent

            _RateChanged = True

        End Sub
        Private Sub DataGridViewForm_LineDateRate_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewForm_LineDateRate.CustomDrawCellEvent

            If _ViewModel.RateDates.ContainsValue(e.Column.FieldName) Then

                If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName.Replace("Rate", "Date")) = True Then

                    e.Appearance.BackColor = System.Drawing.Color.WhiteSmoke

                    e.Appearance.DrawBackground(e.Cache, e.Bounds)

                    e.Handled = True

                ElseIf DataGridViewForm_LineDateRate.CurrentView.GetRowCellValue(e.RowHandle, e.Column.FieldName.Replace("Rate", "Entered")) = False Then

                    e.Appearance.BackColor = System.Drawing.Color.White

                    e.Appearance.DrawBackground(e.Cache, e.Bounds)

                    e.Handled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_LineDateRate_CustomDrawColumnHeaderEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.ColumnHeaderCustomDrawEventArgs) Handles DataGridViewForm_LineDateRate.CustomDrawColumnHeaderEvent

            If e.Column IsNot Nothing AndAlso _ViewModel IsNot Nothing AndAlso _ViewModel.RateDates.ContainsValue(e.Column.FieldName) AndAlso _ViewModel.HiatusDataTable.Rows.Count > 0 Then

                If _ViewModel.HiatusDataTable.Rows(0)(e.Column.FieldName.Replace("Rate", "Date")) = True Then

                    e.Appearance.ForeColor = System.Drawing.Color.Red

                    e.DefaultDraw()

                    e.Handled = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
