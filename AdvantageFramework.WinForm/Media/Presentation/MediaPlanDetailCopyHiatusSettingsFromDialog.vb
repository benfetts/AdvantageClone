Namespace Media.Presentation

    Public Class MediaPlanDetailCopyHiatusSettingsFromDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan = Nothing
        Private _CopyToMediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
        Private _MediaPlanEstimates As Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, CopyToMediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate)

            ' This call is required by the designer.
            InitializeComponent()

            _MediaPlan = MediaPlan
            _CopyToMediaPlanEstimate = CopyToMediaPlanEstimate

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
        Private Sub SetHiatusDatesData(RowIndexes As Generic.List(Of Integer), CellDates As Generic.List(Of Date))

            'objects
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            If RowIndexes IsNot Nothing AndAlso CellDates IsNot Nothing Then

                For Each RowIndex In RowIndexes

                    For Each CellDate In CellDates

                        Try

                            MediaPlanDetailLevelLineData = _CopyToMediaPlanEstimate.MediaPlanDetailLevelLineDatas.SingleOrDefault(Function(MPDLLD) MPDLLD.RowIndex = RowIndex AndAlso
                                                                                                                                                   CDate(MPDLLD.StartDate.ToShortDateString) = CDate(CellDate.ToShortDateString))

                        Catch ex As Exception
                            MediaPlanDetailLevelLineData = Nothing
                        End Try

                        If MediaPlanDetailLevelLineData IsNot Nothing Then

                            If MediaPlanDetailLevelLineData.HasPendingOrders Then

                                _CopyToMediaPlanEstimate.ClearMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData)

                            Else

                                _CopyToMediaPlanEstimate.RemoveMediaPlanDetailLevelLineData(MediaPlanDetailLevelLineData)

                            End If

                        End If

                    Next

                Next

            End If

        End Sub
        Private Function GetHiatusColumn(MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) As AdvantageFramework.MediaPlanning.DataColumns

            'objects
            Dim HiatusColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.Methods.DataColumns.Date
            Dim HighestAreaIndex As Integer = -1

            Try

                For Each MPDF In MediaPlanEstimate.MediaPlanDetailFields.Where(Function(Entity) Entity.Area = 1 AndAlso Entity.IsVisible).OrderBy(Function(Entity) Entity.AreaIndex).ToList

                    If MPDF.AreaIndex > HighestAreaIndex Then

                        HighestAreaIndex = MPDF.AreaIndex
                        HiatusColumn = AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.MediaPlanning.DataColumns), MPDF.FieldID)

                    End If

                Next

            Catch ex As Exception
                HiatusColumn = MediaPlanning.Methods.DataColumns.Date
            Finally
                GetHiatusColumn = HiatusColumn
            End Try

        End Function
        Private Sub EnableOrDisableActions()

            ButtonForm_OK.Enabled = DataGridViewForm_Estimates.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal MediaPlan As AdvantageFramework.MediaPlanning.Classes.MediaPlan, CopyToMediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaPlanDetailCopyHiatusSettingsFromDialog As AdvantageFramework.Media.Presentation.MediaPlanDetailCopyHiatusSettingsFromDialog = Nothing

            MediaPlanDetailCopyHiatusSettingsFromDialog = New AdvantageFramework.Media.Presentation.MediaPlanDetailCopyHiatusSettingsFromDialog(MediaPlan, CopyToMediaPlanEstimate)

            ShowFormDialog = MediaPlanDetailCopyHiatusSettingsFromDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaPlanDetailCopyHiatusSettingsFromDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim CopyToMediaPlanEstimateHiatusColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.Methods.DataColumns.Date
            Dim HiatusColumn As AdvantageFramework.MediaPlanning.DataColumns = MediaPlanning.Methods.DataColumns.Date

            DataGridViewForm_Estimates.SetBookmarkColumnIndex(0)

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Try

                CopyToMediaPlanEstimateHiatusColumn = GetHiatusColumn(_CopyToMediaPlanEstimate)

                _MediaPlanEstimates = New Generic.List(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder)

                If CopyToMediaPlanEstimateHiatusColumn = MediaPlanning.Methods.DataColumns.Week OrElse CopyToMediaPlanEstimateHiatusColumn = MediaPlanning.Methods.DataColumns.Month OrElse
                        CopyToMediaPlanEstimateHiatusColumn = MediaPlanning.Methods.DataColumns.MonthName Then

                    For Each MPE In _MediaPlan.MediaPlanEstimates.Values.OfType(Of AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate).OrderBy(Function(Entity) Entity.OrderNumber).ToList

                        HiatusColumn = MediaPlanning.Methods.DataColumns.Date

                        If MPE.ID <> _CopyToMediaPlanEstimate.ID AndAlso MPE.IsCalendarMonth = _CopyToMediaPlanEstimate.IsCalendarMonth AndAlso MPE.SplitWeeks = _CopyToMediaPlanEstimate.SplitWeeks Then

                            HiatusColumn = GetHiatusColumn(MPE)

                            If (HiatusColumn = MediaPlanning.Methods.DataColumns.Week AndAlso CopyToMediaPlanEstimateHiatusColumn = MediaPlanning.Methods.DataColumns.Week) OrElse
                                    (HiatusColumn.ToString.StartsWith(MediaPlanning.Methods.DataColumns.Month.ToString) AndAlso CopyToMediaPlanEstimateHiatusColumn.ToString.StartsWith(MediaPlanning.Methods.DataColumns.Month.ToString)) Then

                                _MediaPlanEstimates.Add(New AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder(MPE))

                            End If

                        End If

                    Next

                End If

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
        Private Sub MediaPlanDetailCopyHiatusSettingsFromDialog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim MediaPlanEstimateOrder As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimateOrder = Nothing
            Dim MediaPlanEstimate As AdvantageFramework.MediaPlanning.Classes.MediaPlanEstimate = Nothing
            Dim RowIndexes As Generic.List(Of Integer) = Nothing
            Dim CellDates As Generic.List(Of Date) = Nothing
            Dim MediaPlanDetailLevelLineData As AdvantageFramework.Database.Entities.MediaPlanDetailLevelLineData = Nothing

            Try

                MediaPlanEstimateOrder = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                MediaPlanEstimateOrder = Nothing
            End Try

            If MediaPlanEstimateOrder IsNot Nothing Then

                MediaPlanEstimate = MediaPlanEstimateOrder.GetMediaPlanEstimate

                If MediaPlanEstimate IsNot Nothing Then

                    If AdvantageFramework.WinForm.MessageBox.Show("WARNING: Copying Hiatus settings will delete all data in those ranges." & vbNewLine & vbNewLine & "Do you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = WinForm.Presentation.FormActions.Modifying
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Modifying...")

                        Try

                            _CopyToMediaPlanEstimate.HiatusMonths.Clear()
                            _CopyToMediaPlanEstimate.HiatusWeeks.Clear()

                            _CopyToMediaPlanEstimate.HiatusMonths.AddRange(MediaPlanEstimate.HiatusMonths)
                            _CopyToMediaPlanEstimate.HiatusWeeks.AddRange(MediaPlanEstimate.HiatusWeeks)

                            _CopyToMediaPlanEstimate.SaveHiatusWeeks()
                            _CopyToMediaPlanEstimate.SaveHiatusMonths()

                            RowIndexes = _CopyToMediaPlanEstimate.MediaPlanDetailLevelLineDatas.Select(Function(Entity) Entity.RowIndex).Distinct.ToList

                            For Each HiatusDate In _CopyToMediaPlanEstimate.HiatusMonths

                                CellDates = _CopyToMediaPlanEstimate.GetMonthDates(HiatusDate)

                                SetHiatusDatesData(RowIndexes, CellDates)

                            Next

                            For Each HiatusDate In _CopyToMediaPlanEstimate.HiatusWeeks

                                CellDates = _CopyToMediaPlanEstimate.GetWeekDates(HiatusDate)

                                SetHiatusDatesData(RowIndexes, CellDates)

                            Next

                            _CopyToMediaPlanEstimate.FieldsChanged()

                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Estimates_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Estimates.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
