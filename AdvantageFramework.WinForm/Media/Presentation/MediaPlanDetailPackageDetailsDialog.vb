Namespace Media.Presentation

    Public Class MediaPlanDetailPackageDetailsDialog

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

            DataGridViewForm_AdSizes.DataSource = _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = _RowIndex).ToList

            DataGridViewForm_AdSizes.Columns(AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail.Properties.SizeCode.ToString).MinWidth = 250

            DataGridViewForm_AdSizes.CurrentView.BestFitColumns()

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

            If DataGridViewForm_AdSizes.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Delete.Enabled = DataGridViewForm_AdSizes.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, RowIndex As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailPackageDetailsDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailPackageDetailsDialog = Nothing

            MediaPlanDetailPackageDetailsDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailPackageDetailsDialog(MediaPlan, RowIndex)

            ShowFormDialog = MediaPlanDetailPackageDetailsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailPackageDetailsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim KeepLoading As Boolean = False

            Me.ControlBox = False
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewForm_AdSizes.OptionsView.ShowFooter = False

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
        Private Sub MediaPlanDetailPackageDetailsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadLineAndLevelDetails()

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            DataGridViewForm_AdSizes.ValidateAllRows()

            If Me.Validator AndAlso DataGridViewForm_AdSizes.HasAnyInvalidRows = False Then

                Me.ClearChanged()

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please correct errors before continuing.")

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            'objects
            Dim MediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing

            If DataGridViewForm_AdSizes.HasASelectedRow Then

                For Each MediaPlanDetailPackageDetail In DataGridViewForm_AdSizes.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).ToList

                    'MediaPlanDetailPackageDetail = MediaPlanEstimatePackageDetail.GetEntity

                    _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) = _MediaPlan.MediaPlanEstimate.RemoveMediaPlanDetailPackageDetail(MediaPlanDetailPackageDetail)
                    DataGridViewForm_AdSizes.CurrentView.DeleteFromDataSource(MediaPlanDetailPackageDetail)

                Next

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_AdSizes.CancelNewItemRow()

        End Sub
        Private Sub DataGridViewForm_AdSizes_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_AdSizes.InitNewRowEvent

            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).MediaPlanID = _MediaPlan.ID
            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).MediaPlanDetailID = _MediaPlan.MediaPlanEstimate.ID
            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).RowIndex = _RowIndex
            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).MediaType = "I"
            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).CreatedByUserCode = Me.Session.UserCode
            DirectCast(DataGridViewForm_AdSizes.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail).CreatedDate = Now

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AdSizes_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_AdSizes.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_AdSizes_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_AdSizes.AddNewRowEvent

            'objects
            Dim MediaPlanDetailPackageDetail As AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail = Nothing
            Dim AdSize As AdvantageFramework.Database.Entities.AdSize = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail Then

                Me.ShowWaitForm("Processing...")

                MediaPlanDetailPackageDetail = RowObject

                _MediaPlan.MediaPlanEstimate.AddMediaPlanDetailPackageDetail(MediaPlanDetailPackageDetail)

                AdSize = AdvantageFramework.Database.Procedures.AdSize.LoadByCodeAndMediaType(_MediaPlan.DbContext, MediaPlanDetailPackageDetail.SizeCode, "I")

                Me.CloseWaitForm()

                If AdSize IsNot Nothing Then

                    If _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString).ToString.Trim = "" Then

                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) & AdSize.Description

                    Else

                        _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) = _MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Rows.Item(_RowIndex)(AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString) & "," & AdSize.Description

                    End If

                End If

                _MediaPlan.MediaPlanEstimate.FieldsChanged()

            End If

        End Sub
        Private Sub DataGridViewForm_AdSizes_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_AdSizes.QueryPopupNeedDatasourceEvent

            'objects
            Dim AdSizeCodes() As String = Nothing

            If FieldName = AdvantageFramework.Database.Entities.MediaPlanDetailPackageDetail.Properties.SizeCode.ToString Then

                OverrideDefaultDatasource = True

                AdSizeCodes = _MediaPlan.MediaPlanEstimate.MediaPlanDetailPackageDetails.Where(Function(Entity) Entity.RowIndex = _RowIndex).Select(Function(Entity) Entity.SizeCode).Distinct.ToArray

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.AdSize.LoadAllActive(DbContext)
                                  Where Entity.MediaType = "I" AndAlso
                                        AdSizeCodes.Contains(Entity.Code) = False
                                  Select Entity).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_AdSizes_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewForm_AdSizes.ShowingEditorEvent

            If DataGridViewForm_AdSizes.IsNewItemRow() = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace