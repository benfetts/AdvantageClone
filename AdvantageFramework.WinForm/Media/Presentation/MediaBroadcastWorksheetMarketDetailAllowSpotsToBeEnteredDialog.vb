Namespace Media.Presentation

    Public Class MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel = Nothing
        Protected _Controller As AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController = Nothing
        Protected _DataTableID As Integer = 0
        Protected _OverrideChanged As Boolean = False
        Protected _RowHasBeenModified As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property RowHasBeenModified
            Get
                RowHasBeenModified = _RowHasBeenModified
            End Get
        End Property

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

            DataGridViewForm_LineAllowSpotsToBeEntered.DataSource = DataTable.DefaultView.ToTable()

        End Sub
        Private Sub SaveViewModel()

            'objects
            Dim DataTableID As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing

            For RowHandle = 0 To DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.RowCount - 1

                If DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.IsDataRow(RowHandle) Then

                    DataTableID = DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController.MarketDetailsColumns.ID.ToString)

                    DataRow = _ViewModel.DataTable.Rows.Find(DataTableID)

                    For Each GridColumn In DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.VisibleColumns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)

                        DataRow(GridColumn.FieldName) = DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.GetRowCellValue(RowHandle, GridColumn.FieldName)

                        If DataRow(GridColumn.FieldName) = False Then

                            If DataRow(GridColumn.FieldName.Replace("Entered", "Date")) > 0 Then

                                _Controller.MarketDetails_MarketDetailDateValueChanged(_ViewModel, _ViewModel.DataTable.Rows.IndexOf(DataRow), GridColumn.FieldName.Replace("Entered", "Date"))

                                _RowHasBeenModified = True

                            End If

                            DataRow(GridColumn.FieldName.Replace("Entered", "Date")) = 0

                        End If

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

            For Each GridColumn In DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                ShowColumn = False

                GridColumn.OptionsColumn.AllowMove = False
                GridColumn.OptionsColumn.ShowInCustomizationForm = False
                GridColumn.OptionsColumn.ShowInExpressionEditor = False
                GridColumn.OptionsColumn.AllowShowHide = False

                If _ViewModel.AllowSpotsToBeEnteredDates.ContainsValue(GridColumn.FieldName) Then

                    DateNumber = AdvantageFramework.StringUtilities.RemoveAllNonNumeric(GridColumn.FieldName, "0")

                    If _ViewModel.HideHiatusDates Then

                        ColumnName = GridColumn.FieldName.Replace("Entered", "Date")

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

                        GridColumn.Visible = True

                    Else

                        GridColumn.Visible = False

                    End If

                Else

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetControlPropertySettings()

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewForm_LineAllowSpotsToBeEntered.OptionsView.ShowViewCaption = False
            DataGridViewForm_LineAllowSpotsToBeEntered.OptionsCustomization.AllowSort = False
            DataGridViewForm_LineAllowSpotsToBeEntered.OptionsCustomization.AllowFilter = False
            DataGridViewForm_LineAllowSpotsToBeEntered.OptionsCustomization.AllowGroup = False

        End Sub
        Private Sub CloseGridEditorAndSaveValueToDataSource()

            If DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.PostEditor() Then

                DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.UpdateCurrentRow()

            End If

        End Sub
        Private Sub RepositoryItemAllowSpotsToBeEntered_EditValueChanging(sender As Object, e As DevExpress.XtraEditors.Controls.ChangingEventArgs)

            'objects
            Dim WarnUser As Boolean = False
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RowIndex As Integer = -1

            DataRow = CType(DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.GetRow(DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.FocusedRowHandle), System.Data.DataRowView).Row

            RowIndex = _ViewModel.DataTable.Rows.IndexOf(DataRow)

            If e.NewValue = False AndAlso DataRow(DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.FocusedColumn.FieldName.Replace("Entered", "Date")) > 0 Then

                If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Setting this override will clear the spots for this date." & vbNewLine & vbNewLine & "Do you want to continue?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    DataRow(DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.FocusedColumn.FieldName.Replace("Entered", "Date")) = 0

                Else

                    e.Cancel = True

                End If

            End If

        End Sub
        Private Sub RepositoryItemCheckEdit_MouseDown(sender As Object, e As System.Windows.Forms.MouseEventArgs)

            'objects
            Dim CheckEdit As DevExpress.XtraEditors.CheckEdit = Nothing
            Dim CheckEditViewInfo As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo = Nothing
            Dim Rectangle As System.Drawing.Rectangle = Nothing
            Dim EditorRectangle As System.Drawing.Rectangle = Nothing

            CheckEdit = CType(sender, DevExpress.XtraEditors.CheckEdit)
            CheckEditViewInfo = CType(CheckEdit.GetViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
            Rectangle = CheckEditViewInfo.CheckInfo.GlyphRect

            EditorRectangle = New System.Drawing.Rectangle(New System.Drawing.Point(0, 0), CheckEdit.Size)

            If (Not Rectangle.Contains(e.Location)) AndAlso EditorRectangle.Contains(e.Location) Then

                CType(e, DevExpress.Utils.DXMouseEventArgs).Handled = True

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(DateTableID As Integer,
                                              ByRef MediaBroadcastWorksheetMarketDetailsViewModel As AdvantageFramework.ViewModels.Media.MediaBroadcastWorksheet.MediaBroadcastWorksheetMarketDetailsViewModel,
                                              ByRef RowHasBeenModified As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog As MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog = Nothing

            MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog = New MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog(DateTableID, MediaBroadcastWorksheetMarketDetailsViewModel)

            ShowFormDialog = MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                RowHasBeenModified = MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog.RowHasBeenModified

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            _Controller = New AdvantageFramework.Controller.Media.MediaBroadcastWorksheetController(Me.Session)

            SetControlPropertySettings()

        End Sub
        Private Sub MediaBroadcastWorksheetMarketDetailAllowSpotsToBeEnteredDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Loading)

            LoadViewModel()

            FormatControls()

            RefreshViewModel()

            Me.ClearChanged()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.Focus()

            For Each GridColumn In DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.VisibleColumns

                DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.FocusedColumn = GridColumn
                Exit For

            Next

            DataGridViewForm_LineAllowSpotsToBeEntered.CurrentView.ShowEditor()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As EventArgs) Handles ButtonForm_OK.Click

            CloseGridEditorAndSaveValueToDataSource()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Modifying)

            SaveViewModel()

            Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            If _OverrideChanged Then

                Me.DialogResult = Windows.Forms.DialogResult.OK

            Else

                Me.DialogResult = Windows.Forms.DialogResult.Cancel

            End If

            Me.Close()

        End Sub
        Private Sub DataGridViewForm_LineAllowSpotsToBeEntered_CellValueChangedEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_LineAllowSpotsToBeEntered.CellValueChangedEvent

            _OverrideChanged = True

        End Sub
        Private Sub DataGridViewForm_LineAllowSpotsToBeEntered_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewForm_LineAllowSpotsToBeEntered.CustomRowCellEditEvent

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

            If e.Column.FieldName.StartsWith("Entered") Then

                RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

                RepositoryItemCheckEdit.AllowGrayed = False

                AddHandler RepositoryItemCheckEdit.EditValueChanging, AddressOf RepositoryItemAllowSpotsToBeEntered_EditValueChanging
                AddHandler RepositoryItemCheckEdit.MouseDown, AddressOf RepositoryItemCheckEdit_MouseDown

                e.RepositoryItem = RepositoryItemCheckEdit

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
