Namespace Media.Presentation

    Public Class MediaPlanEstimateLevelLineDataDialog

#Region " Constants "



#End Region

#Region " Enum "

       

#End Region

#Region " Variables "

        Private _MediaPlanID As Integer = Nothing
        Private _MediaPlanDetailID As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _MediaPlanID = MediaPlanID
            _MediaPlanDetailID = MediaPlanDetailID

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

			MediaPlan = New AdvantageFramework.MediaPlanning.Classes.MediaPlan(Me.Session.ConnectionString, Me.Session.UserCode, _MediaPlanID)

			MediaPlan.SelectMediaPlanEstimateByMediaPlanDetailID(_MediaPlanDetailID)

			DataGridViewLeftSection_Estimates.DataSource = MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable

			For Each GridColumn In DataGridViewLeftSection_Estimates.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Visible = False

            Next

            For Each DataColumn In MediaPlan.MediaPlanEstimate.LevelsAndLinesDataTable.Columns.OfType(Of System.Data.DataColumn).OrderBy(Function(DC) DC.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)).ToList

                If DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.RowIndex.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.ID.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.Color.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageDetails.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackageName.ToString AndAlso
                        DataColumn.ColumnName <> AdvantageFramework.MediaPlanning.LevelLineColumns.PackagePlacement.ToString Then

                    Try

                        GridColumn = DataGridViewLeftSection_Estimates.Columns(DataColumn.ColumnName)

                    Catch ex As Exception
                        GridColumn = Nothing
                    End Try

                    If GridColumn IsNot Nothing Then

                        Try

                            GridColumn.VisibleIndex = DataColumn.ExtendedProperties(AdvantageFramework.Database.Entities.MediaPlanDetailLevel.Properties.OrderNumber.ToString)

                        Catch ex As Exception
                            GridColumn.VisibleIndex = 0
                        End Try

                    End If

                End If

            Next

            DataGridViewLeftSection_Estimates.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadDetailLevelLineData()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim RowIndex As Integer = 0
            Dim MediaPlanDetailLevelLineDatas As Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData) = Nothing

            If TypeOf DataGridViewLeftSection_Estimates.DataSource Is System.Windows.Forms.BindingSource Then

                BindingSource = DataGridViewLeftSection_Estimates.DataSource

                If BindingSource IsNot Nothing Then

                    If DataGridViewLeftSection_Estimates.CurrentView.FocusedRowHandle >= 0 AndAlso DataGridViewLeftSection_Estimates.CurrentView.FocusedRowHandle < BindingSource.Count Then

                        RowIndex = DirectCast(BindingSource.Item(DataGridViewLeftSection_Estimates.CurrentView.GetDataSourceRowIndex(DataGridViewLeftSection_Estimates.CurrentView.FocusedRowHandle)), DataRowView).Row.Item(AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData.Properties.RowIndex.ToString)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            MediaPlanDetailLevelLineDatas = AdvantageFramework.Database.Procedures.MediaPlanDetailLevelLineData.LoadByMediaPlanDetailID(DbContext, _MediaPlanDetailID).ToList

                        End Using

                    End If

                End If

            End If

            If MediaPlanDetailLevelLineDatas Is Nothing Then

                MediaPlanDetailLevelLineDatas = New Generic.List(Of AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData)

            End If

            DataGridViewRightSection_LevelLineData.DataSource = (From Entity In MediaPlanDetailLevelLineDatas
                                                                 Where Entity.RowIndex = RowIndex
                                                                 Select Entity.StartDate,
                                                                        Entity.OrderNumber,
                                                                        Entity.OrderLineNumber).OrderBy(Function(E) E.StartDate).ToList

            DataGridViewRightSection_LevelLineData.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlanID As Integer, ByVal MediaPlanDetailID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanEstimateLevelLineDataDialog As AdvantageFramework.Media.Presentation.MediaPlanEstimateLevelLineDataDialog = Nothing

            MediaPlanEstimateLevelLineDataDialog = New AdvantageFramework.Media.Presentation.MediaPlanEstimateLevelLineDataDialog(MediaPlanID, MediaPlanDetailID)

            ShowFormDialog = MediaPlanEstimateLevelLineDataDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanEstimateLevelLineDataDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewLeftSection_Estimates.OptionsView.ShowFooter = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanEstimateLevelLineDataDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadDetailLevelLineData()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Estimates_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Estimates.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadDetailLevelLineData()

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
