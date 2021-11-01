Namespace Media.Presentation

    Public Class MediaPlanDetailPackagePlacementDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _RowIndex As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlan = MediaPlan
            _RowIndex = RowIndex

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Placements.DataSource = _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackagePlacementNames.Where(Function(Entity) Entity.RowIndex = _RowIndex).ToList

            DataGridViewForm_Placements.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName.Properties.PlacementName.ToString).MinWidth = 250

            DataGridViewForm_Placements.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadLineAndLevelDetails()

            'objects
            Dim MediaPlanDetailLevelLine As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLine = Nothing
            Dim RowIndex As Integer = 0

            For Each MediaPlanDetailLevel In _MediaPlan.MediaPlanEstimate.MediaPlanDetailLevels.OrderBy(Function(Entity) Entity.OrderNumber).ToList

                Try

                    MediaPlanDetailLevelLine = MediaPlanDetailLevel.MediaPlanDetailLevelLines.SingleOrDefault(Function(Entity) Entity.RowIndex = _RowIndex)

                Catch ex As Exception
                    MediaPlanDetailLevelLine = Nothing
                End Try

                If MediaPlanDetailLevelLine IsNot Nothing Then

                    LabelForm_LineData.Text = If(LabelForm_LineData.Text = "", MediaPlanDetailLevelLine.Description, LabelForm_LineData.Text & " | " & MediaPlanDetailLevelLine.Description)

                End If

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            If DataGridViewForm_Placements.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Delete.Enabled = DataGridViewForm_Placements.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailPackagePlacementDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailPackagePlacementDialog = Nothing

            MediaPlanDetailPackagePlacementDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailPackagePlacementDialog(MediaPlan, RowIndex)

            ShowFormDialog = MediaPlanDetailPackagePlacementDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailPackagePlacementDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim KeepLoading As Boolean = False

            Me.ControlBox = False
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_Placements.OptionsView.ShowFooter = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                If _MediaPlan IsNot Nothing Then

                    KeepLoading = True

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The media plan you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanDetailPackagePlacementDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadLineAndLevelDetails()

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            DataGridViewForm_Placements.CurrentView.CloseEditorForUpdating()

            DataGridViewForm_Placements.ValidateAllRows()

            If Me.Validator AndAlso DataGridViewForm_Placements.HasAnyInvalidRows = False Then

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please correct errors before continuing.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            If DataGridViewForm_Placements.HasASelectedRow Then

                For Each MediaPlanDetailPackagePlacementName In DataGridViewForm_Placements.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).ToList

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = _MediaPlan.MediaPlanEstimate.RemoveMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName)
                    DataGridViewForm_Placements.CurrentView.DeleteFromDataSource(MediaPlanDetailPackagePlacementName)

                Next

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Placements.CancelNewItemRow()

        End Sub
        Private Sub DataGridViewForm_Placements_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Placements.InitNewRowEvent

            DirectCast(DataGridViewForm_Placements.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).MediaPlanID = _MediaPlan.ID
            DirectCast(DataGridViewForm_Placements.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
            DirectCast(DataGridViewForm_Placements.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).RowIndex = _RowIndex
            DirectCast(DataGridViewForm_Placements.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).CreatedByUserCode = Me.Session.UserCode
            DirectCast(DataGridViewForm_Placements.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName).CreatedDate = Now

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Placements_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Placements.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Placements_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_Placements.AddNewRowEvent

            'objects
            Dim MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName Then

                Me.ShowWaitForm("Processing...")

                MediaPlanDetailPackagePlacementName = RowObject

                _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName)

                Me.CloseWaitForm()

                If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString).ToString.Trim = "" Then

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) & MediaPlanDetailPackagePlacementName.PlacementName

                Else

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) & "," & MediaPlanDetailPackagePlacementName.PlacementName

                End If

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_Placements_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Placements.CellValueChangedEvent

            'objects
            Dim MediaPlanDetailPackagePlacementName As AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName = Nothing

            If e.RowHandle >= 0 Then

                MediaPlanDetailPackagePlacementName = DirectCast(DataGridViewForm_Placements.GetRowDataBoundItem(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackagePlacementName)

                _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString) = _MediaPlan.MediaPlanEstimate.UpdateMediaPlanDetailPackagePlacement(MediaPlanDetailPackagePlacementName)

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace