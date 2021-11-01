Namespace Media.Presentation

    Public Class MediaPlanDetailOrderDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "
        
        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan

        End Sub
        Private Sub LoadGrid()

            DataGridViewForm_Estimates.DataSource = _MediaPlanEstimates

            DataGridViewForm_Estimates.CurrentView.BestFitColumns()

        End Sub
        Protected Sub AddSubItemImageComboBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallBlueSemiCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallRedCircleImage)

            RepositoryItemImageComboBox.SmallImages = ImagesCollection

            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Ordered", 0, 0))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("PartiallyOrdered", 1, 1))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("NotOrdered", 2, 2))

            RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

            GridColumn.ColumnEdit = RepositoryItemImageComboBox

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonForm_MoveUp.Enabled = DataGridViewForm_Estimates.HasASelectedRow
            ButtonForm_MoveDown.Enabled = DataGridViewForm_Estimates.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailOrderDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailOrderDialog = Nothing

            MediaPlanDetailOrderDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailOrderDialog(MediaPlan)

            ShowFormDialog = MediaPlanDetailOrderDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailOrderDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DataGridViewForm_Estimates.SetBookmarkColumnIndex(0)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                _MediaPlanEstimates = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder)

                For Each MPE In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                    _MediaPlanEstimates.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder(MPE))

                Next

                LoadGrid()

                If DataGridViewForm_Estimates.Columns("PartialOrdered") IsNot Nothing Then

                    DataGridViewForm_Estimates.Columns("PartialOrdered").Visible = False

                End If

                If DataGridViewForm_Estimates.Columns("FullOrdered") IsNot Nothing Then

                    DataGridViewForm_Estimates.Columns("FullOrdered").Visible = False

                End If

                If DataGridViewForm_Estimates.Columns("Ordered") IsNot Nothing Then

                    AddSubItemImageComboBox(DataGridViewForm_Estimates, DataGridViewForm_Estimates.Columns("Ordered"))

                End If

                If DataGridViewForm_Estimates.Columns("DollarsAmount") IsNot Nothing Then

                    DataGridViewForm_Estimates.Columns("DollarsAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    DataGridViewForm_Estimates.Columns("DollarsAmount").DisplayFormat.FormatString = "c2"

                    DataGridViewForm_Estimates.Columns("DollarsAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewForm_Estimates.Columns("DollarsAmount").DisplayFormat.Format)

                End If

                If DataGridViewForm_Estimates.Columns("BillableAmount") IsNot Nothing Then

                    DataGridViewForm_Estimates.Columns("BillableAmount").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    DataGridViewForm_Estimates.Columns("BillableAmount").DisplayFormat.FormatString = "c2"

                    DataGridViewForm_Estimates.Columns("BillableAmount").SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Sum, "{0:c2}", DataGridViewForm_Estimates.Columns("BillableAmount").DisplayFormat.Format)

                End If

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub MediaPlanDetailOrderDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects

            Me.FormAction = WinForm.Presentation.FormActions.Modifying
            Me.ShowWaitForm()
            Me.ShowWaitForm("Modifying...")

            Try

                For Each MediaPlanEstimateOrder In _MediaPlanEstimates

                    MediaPlanEstimateOrder.OrderNumber = _MediaPlanEstimates.IndexOf(MediaPlanEstimateOrder) + 1

                    Try

                        _MediaPlan.DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.MEDIA_PLAN_DTL SET ORDER_NUMBER = {0} WHERE MEDIA_PLAN_DTL_ID = {1}", MediaPlanEstimateOrder.OrderNumber, MediaPlanEstimateOrder.ID))

                    Catch ex As Exception

                    End Try

                Next

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Estimates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Estimates.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonForm_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveUp.Click

            'objects
            Dim MediaPlanEstimateOrder As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder = Nothing
            Dim Index As Integer = -1

            If DataGridViewForm_Estimates.HasASelectedRow Then

                Try

                    MediaPlanEstimateOrder = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    MediaPlanEstimateOrder = Nothing
                End Try

                If MediaPlanEstimateOrder IsNot Nothing Then

                    Index = _MediaPlanEstimates.IndexOf(MediaPlanEstimateOrder)

                    If Index > 0 Then

                        _MediaPlanEstimates.RemoveAt(Index)

                        _MediaPlanEstimates.Insert(Index - 1, MediaPlanEstimateOrder)

                    End If

                End If

                DataGridViewForm_Estimates.CurrentView.RefreshData()

                If MediaPlanEstimateOrder IsNot Nothing Then

                    DataGridViewForm_Estimates.SelectRow(MediaPlanEstimateOrder.ID)

                End If

            End If

        End Sub
        Private Sub ButtonForm_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonForm_MoveDown.Click

            'objects
            Dim MediaPlanEstimateOrder As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder = Nothing
            Dim Index As Integer = -1

            If DataGridViewForm_Estimates.HasASelectedRow Then

                Try

                    MediaPlanEstimateOrder = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    MediaPlanEstimateOrder = Nothing
                End Try

                If MediaPlanEstimateOrder IsNot Nothing Then

                    Index = _MediaPlanEstimates.IndexOf(MediaPlanEstimateOrder)

                    If Index < _MediaPlanEstimates.Count - 1 Then

                        _MediaPlanEstimates.RemoveAt(Index)

                        _MediaPlanEstimates.Insert(Index + 1, MediaPlanEstimateOrder)

                    End If

                End If

                DataGridViewForm_Estimates.CurrentView.RefreshData()

                If MediaPlanEstimateOrder IsNot Nothing Then

                    DataGridViewForm_Estimates.SelectRow(MediaPlanEstimateOrder.ID)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
