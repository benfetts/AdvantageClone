Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionBillHoldDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingCommandCenterID As Integer = 0
        Private _IncludeContingency As Short = 0
        Private _ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary) = Nothing
        Private WithEvents _ToolTipController As DevExpress.Utils.ToolTipController = Nothing
        Private _ObjectTypePropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary))

            ' This call is required by the designer.
            InitializeComponent()

            _BillingCommandCenterID = BillingCommandCenterID
            _IncludeContingency = IncludeContingency
            _ProductionSummaryList = ProductionSummaryList

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim LayoutLoaded As Boolean = False
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            BindingSource = DataGridViewForm_ProductionBillHold.DataSource

            If BindingSource IsNot Nothing AndAlso BindingSource.DataSource IsNot Nothing Then
                
                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionBillHold, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterBillHold)

            End If

            DataGridViewForm_ProductionBillHold.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionBillHold.ClearGridCustomization()
            DataGridViewForm_ProductionBillHold.ClearDatasource(New Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold))
            DataGridViewForm_ProductionBillHold.ItemDescription = "Job Component(s)"

            LayoutLoaded = AdvantageFramework.WinForm.Presentation.Controls.LoadDataGridViewLayout(Session, DataGridViewForm_ProductionBillHold, Database.Entities.GridAdvantageType.BillingCommandCenterBillHold)

            DataGridViewForm_ProductionBillHold.DataSource = (From Entity In _ProductionSummaryList _
                                                              Where Entity.BillStatus <> AdvantageFramework.BillingCommandCenter.BillStatus.AdvanceBill
                                                              Select New AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold(Entity)).ToList

            If Not LayoutLoaded Then

                SetColumnDefaultVisibility()

                For Each GridColumn In DataGridViewForm_ProductionBillHold.Columns

                    If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ClientCode.ToString OrElse _
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.JobNumber.ToString OrElse _
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ComponentNumber.ToString OrElse _
                            GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.NewBillHoldStatus.ToString Then

                        GridColumn.OptionsColumn.AllowShowHide = False
                        GridColumn.OptionsColumn.ShowInCustomizationForm = False

                    End If

                Next

                DataGridViewForm_ProductionBillHold.CurrentView.ClearSorting()
                DataGridViewForm_ProductionBillHold.CurrentView.BeginSort()
                DataGridViewForm_ProductionBillHold.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.JobNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewForm_ProductionBillHold.CurrentView.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ComponentNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewForm_ProductionBillHold.CurrentView.EndSort()

            Else

                AdvantageFramework.WinForm.Presentation.Controls.SortGridViewBySortedColumns(DataGridViewForm_ProductionBillHold)

            End If

            If DataGridViewForm_ProductionBillHold.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillStatus.ToString) IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewForm_ProductionBillHold, DataGridViewForm_ProductionBillHold.Columns(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillStatus.ToString))

            End If

            If Not LayoutLoaded Then

                DataGridViewForm_ProductionBillHold.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            Dim BillHold As String = Nothing

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

            ButtonItemGridOptions_ChooseColumns.Enabled = Not Me.UserEntryChanged
            ButtonItemGridOptions_RestoreDefaults.Enabled = Not Me.UserEntryChanged

            BillHold = ComboBoxBillHold_BillHold.GetSelectedValue

            ButtonItemBillHold_AcceptRequested.Enabled = If(BillHold = "1" OrElse BillHold = "2", True, False) AndAlso DataGridViewForm_ProductionBillHold.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold).Any(Function(BH) BH.JobBillHoldRequested = True)

        End Sub
        Private Sub SetColumnDefaultVisibility()

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            For Each GridColumn In DataGridViewForm_ProductionBillHold.CurrentView.Columns

                If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ClientName.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.DivisionCode.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.DivisionName.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ProductCode.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ProductDescription.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.JobDescription.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.ComponentDescription.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillHoldAmount.ToString OrElse _
                        GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillingApprovalHeaderComment.ToString Then

                    GridColumn.Visible = False

                End If

            Next

        End Sub
        Private Sub SetNewBillHold()

            Dim ProductionBillHoldList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold) = Nothing
            Dim NewBillHold As Nullable(Of Short) = Nothing

            DataGridViewForm_ProductionBillHold.CurrentView.CloseEditorForUpdating()

            ProductionBillHoldList = DataGridViewForm_ProductionBillHold.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold).ToList()

            For Each ProductionBillHold In ProductionBillHoldList

                NewBillHold = ComboBoxBillHold_BillHold.GetSelectedValue

                ProductionBillHold.NewBillHoldStatus = NewBillHold

                DataGridViewForm_ProductionBillHold.SetUserEntryChanged()

            Next

            DataGridViewForm_ProductionBillHold.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingCommandCenterID As Integer, ByVal IncludeContingency As Short, ByVal ProductionSummaryList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary)) As System.Windows.Forms.DialogResult

            'objects
            Dim BillingCommandCenterProductionBillHoldDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillHoldDialog = Nothing

            BillingCommandCenterProductionBillHoldDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionBillHoldDialog(BillingCommandCenterID, IncludeContingency, ProductionSummaryList)

            ShowFormDialog = BillingCommandCenterProductionBillHoldDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionBillHoldDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            If e.CloseReason = Windows.Forms.CloseReason.UserClosing Then

                AdvantageFramework.WinForm.Presentation.Controls.SaveDataGridViewLayout(Session, DataGridViewForm_ProductionBillHold, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterBillHold)

            End If
            
        End Sub
        Private Sub BillingCommandCenterProductionBillHoldDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemGridOptions_ChooseColumns.Image = AdvantageFramework.My.Resources.ColumnImage
            ButtonItemGridOptions_RestoreDefaults.Image = AdvantageFramework.My.Resources.RestoreDefaultsImage

            ComboBoxBillHold_BillHold.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus)).ToList _
                                                    Select [Code] = CShort(EnumObject.Code),
                                                           [Description] = EnumObject.Description).ToList

            ComboBoxBillHold_BillHold.ByPassUserEntryChanged = True

            DataGridViewForm_ProductionBillHold.CurrentView.OptionsLayout.StoreDataSettings = True
            DataGridViewForm_ProductionBillHold.CurrentView.OptionsLayout.StoreAppearance = True
            DataGridViewForm_ProductionBillHold.CurrentView.OptionsLayout.StoreVisualOptions = True

            DataGridViewForm_ProductionBillHold.CurrentView.OptionsLayout.Columns.StoreAllOptions = True
            DataGridViewForm_ProductionBillHold.CurrentView.OptionsLayout.Columns.StoreAppearance = True

            DataGridViewForm_ProductionBillHold.AutoloadRepositoryDatasource = True
            DataGridViewForm_ProductionBillHold.AddFixedColumnCheckItemsToGridMenu = True
            DataGridViewForm_ProductionBillHold.OptionsMenu.EnableColumnMenu = True

            DataGridViewForm_ProductionBillHold.OptionsCustomization.AllowColumnMoving = True

            DataGridViewForm_ProductionBillHold.ShowSelectDeselectAllButtons = True

            _ToolTipController = New DevExpress.Utils.ToolTipController()

            DataGridViewForm_ProductionBillHold.GridControl.ToolTipController = _ToolTipController

        End Sub
        Private Sub BillingCommandCenterProductionBillHoldDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadGrid()

            DataGridViewForm_ProductionBillHold.SelectAll()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub _ToolTipController_GetActiveObjectInfo(ByVal sender As Object, ByVal e As DevExpress.Utils.ToolTipControllerGetActiveObjectInfoEventArgs) Handles _ToolTipController.GetActiveObjectInfo

            'objects
            Dim ToolTipControlInfo As DevExpress.Utils.ToolTipControlInfo = Nothing
            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing
            Dim RowID As Integer = 0
            Dim ToolTipText As String = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing

            If e.SelectedControl Is DataGridViewForm_ProductionBillHold.GridControl Then

                Try

                    GridView = CType(DataGridViewForm_ProductionBillHold.GridControl.GetViewAt(e.ControlMousePosition), DevExpress.XtraGrid.Views.Grid.GridView)

                    If GridView IsNot Nothing Then

                        GridHitInfo = GridView.CalcHitInfo(e.ControlMousePosition)

                        If GridHitInfo.InRowCell AndAlso GridHitInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillStatus.ToString Then

                            Try

                                RowID = DataGridViewForm_ProductionBillHold.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold.Properties.BillStatus.ToString)

                            Catch ex As Exception

                            End Try

                            If RowID > -1 Then

                                Select Case RowID

                                    Case 1

                                        ToolTipText = "Progress Bill"

                                    Case 2

                                        ToolTipText = "Advance Bill"

                                    Case 3

                                        ToolTipText = "Job on Permanent Bill Hold"

                                    Case 4

                                        ToolTipText = "Job on Temporary Bill Hold"

                                    Case 5

                                        ToolTipText = "Job Details on Hold"

                                    Case 6

                                        ToolTipText = "Reconciled - Select for billing and process"

                                    Case 7

                                        ToolTipText = "Final Reconciled w/Pending Advance Bill"

                                End Select

                            End If

                        ElseIf GridHitInfo.InRowCell Then

                            If _ObjectTypePropertyDescriptors Is Nothing Then

                                _ObjectTypePropertyDescriptors = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold)).OfType(Of System.ComponentModel.PropertyDescriptor)().ToList()

                            End If

                            Try

                                PropertyDescriptor = (From [Property] In _ObjectTypePropertyDescriptors _
                                                      Where [Property].Name = GridHitInfo.Column.FieldName _
                                                      Select [Property]).SingleOrDefault

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            If PropertyDescriptor IsNot Nothing AndAlso PropertyDescriptor.PropertyType Is GetType(String) Then

                                ToolTipText = DataGridViewForm_ProductionBillHold.CurrentView.GetRowCellValue(GridHitInfo.RowHandle, GridHitInfo.Column.FieldName)

                            End If

                        End If

                        If String.IsNullOrEmpty(ToolTipText) = False Then

                            ToolTipControlInfo = New DevExpress.Utils.ToolTipControlInfo(RowID, ToolTipText)

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
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            Dim ReturnValue As Integer = -1
            Dim HoldAction As Integer = Nothing
            Dim ProductionSummary As AdvantageFramework.BillingCommandCenter.Classes.ProductionSummary = Nothing

            Me.ShowWaitForm("Saving...")

            DataGridViewForm_ProductionBillHold.CurrentView.CloseEditorForUpdating()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                If BillingCommandCenter IsNot Nothing Then

                    For Each DataBoundItem In DataGridViewForm_ProductionBillHold.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold).ToList.Where(Function(Entity) Entity.NewBillHoldStatus IsNot Nothing AndAlso Entity.NewBillHoldStatus >= 0).ToList

                        If DataBoundItem.NewBillHoldStatus = AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Clear Then

                            HoldAction = -1

                        Else

                            HoldAction = DataBoundItem.NewBillHoldStatus

                        End If

                        ReturnValue = AdvantageFramework.BillingCommandCenter.UpdateProductionBillHoldStatus(BCCDbContext, DataBoundItem.JobNumber, DataBoundItem.ComponentNumber, BillingCommandCenter.BillingUser, HoldAction)

                        If ReturnValue = 0 Then

                            ProductionSummary = _ProductionSummaryList.Where(Function(PS) PS.JobNumber = DataBoundItem.JobNumber AndAlso PS.ComponentNumber = DataBoundItem.ComponentNumber).FirstOrDefault

                            If ProductionSummary IsNot Nothing Then

                                Select Case HoldAction

                                    Case -1

                                        ProductionSummary.BillStatus = 1

                                    Case AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Temporary_Job

                                        ProductionSummary.BillStatus = 4

                                    Case AdvantageFramework.BillingCommandCenter.ProductionBillHoldStatus.Permanent_Job

                                        ProductionSummary.BillStatus = 3

                                End Select

                            End If

                        End If

                    Next

                    LoadGrid()

                    Me.ClearChanged()

                    EnableOrDisableActions()

                End If

            End Using

            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewForm_ProductionBillHold_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_ProductionBillHold.ColumnValueChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_ProductionBillHold_HideCustomizationFormEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ProductionBillHold.HideCustomizationFormEvent

            If ButtonItemGridOptions_ChooseColumns.Checked Then

                ButtonItemGridOptions_ChooseColumns.Checked = False

            End If

        End Sub
        Private Sub ButtonItemGridOptions_ChooseColumns_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_ChooseColumns.CheckedChanged

            Try

                If ButtonItemGridOptions_ChooseColumns.Checked Then

                    If DataGridViewForm_ProductionBillHold.CurrentView.CustomizationForm Is Nothing Then

                        DataGridViewForm_ProductionBillHold.CurrentView.ShowCustomization()

                    End If

                Else

                    If DataGridViewForm_ProductionBillHold.CurrentView.CustomizationForm IsNot Nothing Then

                        DataGridViewForm_ProductionBillHold.CurrentView.DestroyCustomization()

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemGridOptions_RestoreDefaults_Click(sender As Object, e As EventArgs) Handles ButtonItemGridOptions_RestoreDefaults.Click

            Me.ShowWaitForm("Loading...")

            Using DataContext As New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                AdvantageFramework.Database.Procedures.GridAdvantage.Delete(DataContext, AdvantageFramework.Database.Entities.GridAdvantageType.BillingCommandCenterBillHold, Session.UserCode)

            End Using

            DataGridViewForm_ProductionBillHold.SetBookmarkColumnIndex(-1)
            DataGridViewForm_ProductionBillHold.Columns.Clear()

            DataGridViewForm_ProductionBillHold.ClearDatasource()

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

            Me.CloseWaitForm()

        End Sub
        Private Sub ButtonItemBillHold_AcceptRequested_Click(sender As Object, e As EventArgs) Handles ButtonItemBillHold_AcceptRequested.Click

            Dim ProductionBillHoldList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold) = Nothing
            Dim NewBillHold As Nullable(Of Short) = Nothing

            DataGridViewForm_ProductionBillHold.CurrentView.CloseEditorForUpdating()

            ProductionBillHoldList = DataGridViewForm_ProductionBillHold.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.ProductionBillHold).Where(Function(BH) BH.JobBillHoldRequested = True).ToList()

            For Each ProductionBillHold In ProductionBillHoldList

                NewBillHold = ComboBoxBillHold_BillHold.GetSelectedValue

                ProductionBillHold.NewBillHoldStatus = NewBillHold

                DataGridViewForm_ProductionBillHold.SetUserEntryChanged()

            Next

            DataGridViewForm_ProductionBillHold.CurrentView.RefreshData()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemBillHold_MarkSelected_Click(sender As Object, e As EventArgs) Handles ButtonItemBillHold_MarkSelected.Click

            SetNewBillHold()

        End Sub
        Private Sub ComboBoxBillHold_BillHold_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxBillHold_BillHold.SelectedValueChanged

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace