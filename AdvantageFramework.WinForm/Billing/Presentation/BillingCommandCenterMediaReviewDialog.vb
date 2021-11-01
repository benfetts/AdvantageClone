Namespace Billing.Presentation

    Public Class BillingCommandCenterMediaReviewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _BillingStatus As AdvantageFramework.BillingCommandCenter.Database.Classes.BillingStatus = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID

        End Sub
        Private Sub SaveGridLayout()

            Dim AFActiveFilterString As String = Nothing

            AFActiveFilterString = DataGridViewForm_MediaSummary.CurrentView.AFActiveFilterString

            AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_MediaSummary, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterMediaReview)

            DataGridViewForm_MediaSummary.CurrentView.AFActiveFilterString = AFActiveFilterString

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim SelectedOrderLines As Generic.List(Of String) = Nothing
            Dim MediaSummary As AdvantageFramework.BillingCommandCenter.Classes.MediaSummary = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim AFActiveFilterString As String = Nothing
            Dim DictionaryGrid As Dictionary(Of Integer, Object) = Nothing

            Me.ShowWaitForm()

            AFActiveFilterString = DataGridViewForm_MediaSummary.CurrentView.AFActiveFilterString

            BindingSource = DataGridViewForm_MediaSummary.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then

                SaveGridLayout()

            End If

            If DataGridViewForm_MediaSummary.CurrentView.SelectedRowsCount >= 1 Then

                SelectedOrderLines = (From MS In DataGridViewForm_MediaSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)()
                                      Select MS.OrderNumber & "|" & MS.LineNumber).ToList

            End If

            DataGridViewForm_MediaSummary.SetBookmarkColumnIndex(-1)
            DataGridViewForm_MediaSummary.ClearGridCustomization()
            DataGridViewForm_MediaSummary.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary))
            DataGridViewForm_MediaSummary.ItemDescription = "Media Summary(ies)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_MediaSummary, Database.Entities.GridAdvantageType.BillingCommandCenterMediaReview)

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewForm_MediaSummary.DataSource = BCCDbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)(String.Format("SET ARITHABORT ON; exec dbo.advsp_bcc_get_media_summary {0}", _BillingCommandCenterID)).ToList

            End Using

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility(DataGridViewForm_MediaSummary)

                ApplyGrouping()

                DataGridViewForm_MediaSummary.CurrentView.ClearSorting()
                DataGridViewForm_MediaSummary.CurrentView.BeginSort()
                DataGridViewForm_MediaSummary.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_MediaSummary.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_MediaSummary.CurrentView.EndSort()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_MediaSummary)

                DataGridViewForm_MediaSummary.CurrentView.ExpandAllGroups()

            End If

            DataGridViewForm_MediaSummary.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            AddFixedLeftColumns(DataGridViewForm_MediaSummary)

            If DataGridViewForm_MediaSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBoxMediaBillStatus(DataGridViewForm_MediaSummary, DataGridViewForm_MediaSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString))

            End If

            If SelectedOrderLines IsNot Nothing AndAlso SelectedOrderLines.Count > 0 Then

                DataGridViewForm_MediaSummary.CurrentView.BeginSelection()

                DataGridViewForm_MediaSummary.CurrentView.ClearSelection()

                For Each RowHandlesAndDataBoundItem In DataGridViewForm_MediaSummary.GetAllRowsRowHandlesAndDataBoundItems

                    Try

                        MediaSummary = RowHandlesAndDataBoundItem.Value

                    Catch ex As Exception
                        MediaSummary = Nothing
                    End Try

                    If MediaSummary IsNot Nothing AndAlso SelectedOrderLines.Contains(MediaSummary.OrderNumber & "|" & MediaSummary.LineNumber) Then

                        DataGridViewForm_MediaSummary.CurrentView.SelectRow(RowHandlesAndDataBoundItem.Key)
                        DataGridViewForm_MediaSummary.CurrentView.FocusedRowHandle = RowHandlesAndDataBoundItem.Key

                    End If

                Next

                DataGridViewForm_MediaSummary.CurrentView.EndSelection()

            End If

            DataGridViewForm_MediaSummary.CurrentView.AFActiveFilterString = AFActiveFilterString

            If Not LayoutLoaded Then

                DataGridViewForm_MediaSummary.CurrentView.BestFitColumns()

            End If

            If DataGridViewForm_MediaSummary.CurrentView.SelectedRowsCount = 1 AndAlso Not DataGridViewForm_MediaSummary.HasOnlyOneSelectedRow Then

                DictionaryGrid = DataGridViewForm_MediaSummary.GetAllRowsRowHandlesAndDataBoundItems()

                DataGridViewForm_MediaSummary.CurrentView.BeginSelection()

                For Each RowItem In DictionaryGrid

                    DataGridViewForm_MediaSummary.CurrentView.ClearSelection()
                    DataGridViewForm_MediaSummary.CurrentView.SelectRow(RowItem.Key)
                    DataGridViewForm_MediaSummary.CurrentView.FocusedRowHandle = RowItem.Key
                    Exit For

                Next

                DataGridViewForm_MediaSummary.CurrentView.EndSelection()

            End If

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub AddFixedLeftColumns(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            If DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString) IsNot Nothing Then

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).VisibleIndex = 0

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).OptionsColumn.AllowMove = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString).OptionsColumn.AllowShowHide = False

            End If

            If DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString) IsNot Nothing Then

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).VisibleIndex = 0

                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).OptionsColumn.AllowMove = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).OptionsColumn.AllowShowHide = False
                DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString).Caption = "Selected"

                AddSubItemImageCheckBox(DataGridView, DataGridView.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString))

            End If

        End Sub
        Private Sub ApplyGrouping()

            DataGridViewForm_MediaSummary.OptionsView.ShowGroupedColumns = True
            DataGridViewForm_MediaSummary.Columns(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.MediaFrom.ToString).GroupIndex = 0
            DataGridViewForm_MediaSummary.CurrentView.ExpandAllGroups()

        End Sub
        Private Sub SetColumnDefaultVisibility(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridView.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.OfficeDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.DivisionName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.ProductDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.CampaignCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.CampaignName.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.CampaignID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.SalesClassCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.SalesClassDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.LinkID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingCoopCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.MarketCode.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.MarketDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Buyer.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.CloseDate.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.DateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.OrderProcessControl.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.JobNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.JobComponentNumber.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.LinkLineID.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.UnbilledResaleTax.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.UnbilledTotal.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Spots.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Headline.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Programming.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.JobMediaDateToBill.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.JobDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.CompDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.HasBillingApprovalStatus.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AdjustedMarkupPercent.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.MarginPercent.ToString Then

                    GridColumn.Visible = False

                ElseIf GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingSelectionSelect.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.IsSelected.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingUser.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.AmountSelectedforBilling.ToString Then

                    GridColumn.Visible = False
                    GridColumn.OptionsColumn.ShowInCustomizationForm = False

                End If

            Next

        End Sub
        Private Sub LoadBillingStatus()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _BillingStatus = AdvantageFramework.BillingCommandCenter.GetBillingStatus(BCCDbContext, _BillingCommandCenterID)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            Dim MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemActions_BillingSelection.Enabled = DataGridViewForm_MediaSummary.HasASelectedRow

                If DataGridViewForm_MediaSummary.HasASelectedRow Then

                    MediaSummaryList = DataGridViewForm_MediaSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList

                    If (From Entity In MediaSummaryList
                        Select Entity.OrderNumber).Distinct.Count = 1 Then

                        LineNumbers = (From Entity In MediaSummaryList
                                       Where Entity.LineNumber.HasValue
                                       Select Entity.LineNumber.Value).ToArray

                        If LineNumbers.Count > 0 Then

                            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                                ButtonItemView_BillingHistory.Enabled = AdvantageFramework.BillingCommandCenter.GetMediaBillingHistory(BCCDbContext, MediaSummaryList.FirstOrDefault.OrderNumber, LineNumbers).Any

                            End Using

                        Else

                            ButtonItemView_BillingHistory.Enabled = False

                        End If

                    Else

                        ButtonItemView_BillingHistory.Enabled = False

                    End If

                Else

                    ButtonItemView_BillingHistory.Enabled = False

                End If

                If _BillingStatus IsNot Nothing Then

                    If _BillingStatus.IsAssigned.GetValueOrDefault(0) = 1 Then

                        ButtonItemActions_Export.Enabled = False
                        ButtonItemActions_Refresh.Enabled = False
                        ButtonItemActions_BillingSelection.Enabled = True

                    Else

                        ButtonItemActions_Export.Enabled = True
                        ButtonItemActions_Refresh.Enabled = True

                    End If

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal BaseFormParent As AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm, ByVal BillingCommandCenterID As Integer)

            Dim BillingCommandCenterMediaReviewDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaReviewDialog = Nothing

            BillingCommandCenterMediaReviewDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaReviewDialog(BillingCommandCenterID)

            BillingCommandCenterMediaReviewDialog.SetBaseFormParent(BaseFormParent, BillingCommandCenterMediaReviewDialog)

            BillingCommandCenterMediaReviewDialog.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterMediaReviewDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                SaveGridLayout()

            End If

        End Sub
        Private Sub BillingCommandCenterMediaReviewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.Methods.FormActions.Loading

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_BillingSelection.Image = AdvantageFramework.My.Resources.BillSelectImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemView_BillingHistory.Image = AdvantageFramework.My.Resources.BillHistoryImage

            ButtonItemReport_Billing.Image = AdvantageFramework.My.Resources.PrintImage

            DataGridViewForm_MediaSummary.ShowSelectDeselectAllButtons = True

            DataGridViewForm_MediaSummary.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_MediaSummary.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_MediaSummary.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_MediaSummary.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_MediaSummary.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_MediaSummary.GridControl.ToolTipController = _ToolTipController
            DataGridViewForm_MediaSummary.AddFixedColumnCheckItemsToGridMenu = True

            RibbonBarOptions_Report.Visible = False

        End Sub
        Private Sub BillingCommandCenterMediaReviewDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadBillingStatus()

            LoadGrid()

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowValue As String = Nothing
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewForm_MediaSummary.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_MediaSummary.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString Then

                            Try

                                RowValue = DataGridViewForm_MediaSummary.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillStatus.ToString)

                            Catch ex As Exception

                            End Try

                            Select Case RowValue

                                Case 1

                                    ToolTipText = "Prebill"

                                Case 2

                                    ToolTipText = "Post Bill"

                            End Select

                        ElseIf GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.HasBillingApprovalStatus.ToString Then

                            Try

                                RowValue = DataGridViewForm_MediaSummary.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.BillingApprovedDateBy.ToString)

                            Catch ex As Exception

                            End Try

                            ToolTipText = RowValue

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors
                                                      Where [Property].Name = GridHitInfo.Column.FieldName
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                ToolTipText = DataGridViewForm_MediaSummary.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowValue, ToolTipText)

                        End If

                    End If

                Catch ex As Exception

                Finally
                    e.Info = ToolTipControlInfo
                End Try

            End If

        End Sub
        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_MediaSummary.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_MediaSummary.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_MediaSummary.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_MediaSummary.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterMediaReview, Session.UserCode)

            End Using

            DataGridViewForm_MediaSummary.ClearDatasource()

            LoadGrid()

        End Sub
        Private Sub ButtonItemActions_Export_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Export.Click

            'objects
            Dim MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing
            Dim LayoutLoaded As Boolean = False

            MediaSummaryList = DataGridViewForm_MediaSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)().ToList

            SaveGridLayout()

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_Export, Database.Entities.GridAdvantageType.BillingCommandCenterMediaReview)

            Try

                DataGridViewForm_Export.DataSource = MediaSummaryList

            Catch ex As Exception

            End Try

            If LayoutLoaded Then

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_Export)

            End If

            AddFixedLeftColumns(DataGridViewForm_Export)

            'https://www.devexpress.com/Support/Center/Question/Details/Q383062
            DataGridViewForm_Export.CurrentView.ClearDocument()
            DevExpress.Utils.Paint.XPaint.ForceGDIPlusPaint()
            DataGridViewForm_Export.CurrentView.OptionsView.ColumnAutoWidth = False
            DataGridViewForm_Export.CurrentView.BestFitColumns()
            DataGridViewForm_Export.CurrentView.OptionsPrint.AutoWidth = False
            DevExpress.Utils.Paint.XPaint.ForceAPIPaint()

            DataGridViewForm_Export.Print(DefaultLookAndFeel.LookAndFeel, "Media Review", UseLandscape:=True)

        End Sub
        Private Sub ButtonItemActions_BillingSelection_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_BillingSelection.Click

            'objects
            Dim MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing
            Dim IsBatchFinished As Boolean = False

            MediaSummaryList = DataGridViewForm_MediaSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary)().ToList

            SaveGridLayout()

            AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingSelectionDialog.ShowFormDialog(_BillingCommandCenterID, MediaSummaryList, IsBatchFinished)

            If IsBatchFinished Then

                Me.Close()

            Else

                LoadBillingStatus()

                LoadGrid()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            LoadGrid()

        End Sub
        Private Sub ButtonItemReport_Billing_Click(sender As Object, e As EventArgs) Handles ButtonItemReport_Billing.Click



        End Sub
        Private Sub ButtonItemView_BillingHistory_Click(sender As Object, e As EventArgs) Handles ButtonItemView_BillingHistory.Click

            'objects
            Dim MediaSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary) = Nothing
            Dim LineNumbers As IEnumerable(Of Integer) = Nothing

            If DataGridViewForm_MediaSummary.HasASelectedRow Then

                MediaSummaryList = DataGridViewForm_MediaSummary.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.MediaSummary).ToList

                LineNumbers = (From Entity In MediaSummaryList
                               Where Entity.LineNumber.HasValue
                               Select Entity.LineNumber.Value).ToArray

                AdvantageFramework.Billing.Presentation.BillingCommandCenterMediaBillingHistoryDialog.ShowFormDialog(MediaSummaryList.FirstOrDefault.OrderNumber, LineNumbers, MediaSummaryList.FirstOrDefault.OrderDescription)

            End If

        End Sub
        Private Sub DataGridViewForm_MediaSummary_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_MediaSummary.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub DataGridViewForm_MediaSummary_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_MediaSummary.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_MediaSummary_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_MediaSummary.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewForm_MediaSummary.CurrentView.OptionsView.ShowFooter = True

                DataGridViewForm_MediaSummary.CurrentView.OptionsView.EnableAppearanceOddRow = True
                DataGridViewForm_MediaSummary.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewForm_MediaSummary.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse
                            GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) OrElse
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Spots.ToString Then

                        AdvantageFramework.Billing.Presentation.SetColumnAsSumColumn(DataGridViewForm_MediaSummary, GridColumn.FieldName)

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.MediaSummary.Properties.Spots.ToString Then

                            GridColumn.SummaryItem.DisplayFormat = "{0:n0}"

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_MediaSummary_ShowCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_MediaSummary.ShowCustomizationFormEvent

            For Each GridColumn In DataGridViewForm_MediaSummary.CurrentView.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                GridColumn.Caption = GridColumn.Caption.Replace(vbCrLf, " ")

            Next

        End Sub

#End Region

#End Region

    End Class

End Namespace