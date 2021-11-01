Namespace Billing.Presentation

    Public Class BillingCommandCenterProductionCoopDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingUser As String = Nothing
        Private _BillingCommandCenterID As Integer = Nothing
        Private _InvoiceTaxFlag As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingUser As String, ByVal BillingCommandCenterID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _BillingUser = BillingUser
            _BillingCommandCenterID = BillingCommandCenterID

        End Sub
        Private Sub LoadGrid()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewLeftSection_JobComponents.DataSource = AdvantageFramework.BillingCommandCenter.GetInvoiceAssignedCoopJob(BCCDbContext, _BillingUser).ToList

            End Using

            DataGridViewLeftSection_JobComponents.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedDetailItem()

            Dim SummaryIDs As IEnumerable(Of Integer) = Nothing

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                DataGridViewTop_FunctionTotals.DataSource = (From Entity In AdvantageFramework.BillingCommandCenter.GetInvoiceAssignedCoop(BCCDbContext, _BillingUser, DataGridViewLeftSection_JobComponents.GetFirstSelectedRowBookmarkValue(0), DataGridViewLeftSection_JobComponents.GetFirstSelectedRowBookmarkValue(1))
                                                             Where Entity.IsSummaryFlag.GetValueOrDefault(False) = True
                                                             Select New AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop(Entity)).ToList

                DataGridViewBottom_JobComponentDetails.DataSource = (From Entity In AdvantageFramework.BillingCommandCenter.GetInvoiceAssignedCoop(BCCDbContext, _BillingUser, DataGridViewLeftSection_JobComponents.GetFirstSelectedRowBookmarkValue(0), DataGridViewLeftSection_JobComponents.GetFirstSelectedRowBookmarkValue(1))
                                                                     Where Entity.IsSummaryFlag.GetValueOrDefault(False) = False
                                                                     Select New AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop(Entity)).ToList

            End Using

            SummaryIDs = (From Entity In DataGridViewBottom_JobComponentDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList
                          Where Entity.Reconciled = True
                          Select Entity.SummaryRowId.Value).Distinct.ToArray

            For Each DataBoundItem In DataGridViewTop_FunctionTotals.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList

                If SummaryIDs.Contains(DataBoundItem.WorkARFunctionID) Then

                    DataBoundItem.Reconciled = True

                End If

            Next

            If DataGridViewTop_FunctionTotals.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Status.ToString) IsNot Nothing Then

                AddSubItemImageComboBox(DataGridViewTop_FunctionTotals, DataGridViewTop_FunctionTotals.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Status.ToString))

            End If

            DataGridViewTop_FunctionTotals.CurrentView.ViewCaption = "Job Totals by Function"
            DataGridViewTop_FunctionTotals.CurrentView.BestFitColumns()

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Status.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Status.ToString).Visible = False

            End If

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Variance.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Variance.ToString).Visible = False

            End If

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Reconciled.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.Reconciled.ToString).Visible = False

            End If

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.TotalAmount.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.TotalAmount.ToString).Visible = False

            End If

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.RowTotal.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.RowTotal.ToString).Visible = True

            End If

            ApplyGrouping()

            DataGridViewBottom_JobComponentDetails.CurrentView.BestFitColumns()

            EnableOrDisableActions()

        End Sub
        Private Sub AddSubItemImageComboBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            Dim RepositoryItemImageComboBox As DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemImageComboBox = New DevExpress.XtraEditors.Repository.RepositoryItemImageComboBox

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatRedCircleImage)

            RepositoryItemImageComboBox.SmallImages = ImagesCollection

            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Function in balance - Green", 0, 0))
            RepositoryItemImageComboBox.Items.Add(New DevExpress.XtraEditors.Controls.ImageComboBoxItem("Function out of balance - Red", 1, 1))

            RepositoryItemImageComboBox.GlyphAlignment = DevExpress.Utils.HorzAlignment.Center

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemImageComboBox)

            GridColumn.ColumnEdit = RepositoryItemImageComboBox

        End Sub
        Private Sub ApplyGrouping()

            If DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.CDP.ToString) IsNot Nothing Then

                DataGridViewBottom_JobComponentDetails.OptionsView.ShowGroupedColumns = True
                DataGridViewBottom_JobComponentDetails.Columns(AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.CDP.ToString).GroupIndex = 0
                DataGridViewBottom_JobComponentDetails.CurrentView.ExpandAllGroups()

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            Dim InvoiceAssignedCoops As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop) = Nothing
            Dim Saved As Boolean = False
            Dim BillingCommandCenter As AdvantageFramework.BillingCommandCenter.Database.Entities.BillingCommandCenter = Nothing
            'Dim Result As Integer = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ReturnValue As Short = 0

            DataGridViewBottom_JobComponentDetails.CurrentView.CloseEditorForUpdating()

            InvoiceAssignedCoops = DataGridViewBottom_JobComponentDetails.GetAllModifiedRows.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList()

            Using BCCDbContext As New AdvantageFramework.BillingCommandCenter.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each InvoiceAssignedCoop In InvoiceAssignedCoops

                    AdvantageFramework.BillingCommandCenter.UpdateWorkARFunctionAmounts(BCCDbContext, InvoiceAssignedCoop.WorkARFunctionID, InvoiceAssignedCoop.CostAmount, InvoiceAssignedCoop.IncomeAmount, _BillingUser)

                Next

                BCCDbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.BILLING SET COOP_SAVED = 1 WHERE BILLING_USER = '{0}'", _BillingUser))

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    BillingCommandCenter = AdvantageFramework.BillingCommandCenter.Database.Procedures.BillingCommandCenter.LoadByID(BCCDbContext, _BillingCommandCenterID)

                    If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) Then

                        AdvantageFramework.Billing.Presentation.AvaTaxProcessDialog.ShowFormDialog(Session.ConnectionString, BillingCommandCenter.BillingUser, AvaTaxProcessDialog.AvaTaxMode.CalculateTax, Session.UserCode, ErrorMessage, ReturnValue)

                        If ReturnValue = 0 Then

                            AdvantageFramework.WinForm.MessageBox.Show("AvaTax values successfully calculated.")

                        Else

                            If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                            End If

                        End If

                    End If

                End Using

            End Using

            Saved = True

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            Dim InvoiceAssignedCoopFunctions As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop) = Nothing

            InvoiceAssignedCoopFunctions = DataGridViewTop_FunctionTotals.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList

            ButtonItemActions_Save.Enabled = DataGridViewBottom_JobComponentDetails.UserEntryChanged AndAlso InvoiceAssignedCoopFunctions.Where(Function(Coop) Coop.Status = 1).Any = False
            ButtonItemActions_Cancel.Enabled = DataGridViewBottom_JobComponentDetails.UserEntryChanged

        End Sub
        Private Sub UpdateFunctionStatus()

            Dim InvoiceAssignedCoopFunctionLevels As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop) = Nothing
            Dim InvoiceAssignedCoopDetails As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop) = Nothing

            InvoiceAssignedCoopFunctionLevels = DataGridViewTop_FunctionTotals.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList
            InvoiceAssignedCoopDetails = DataGridViewBottom_JobComponentDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).ToList

            For Each InvoiceAssignedCoopFunctionLevel In InvoiceAssignedCoopFunctionLevels

                InvoiceAssignedCoopFunctionLevel.IncomeAmount = InvoiceAssignedCoopDetails.Where(Function(Det) Det.FunctionCode = InvoiceAssignedCoopFunctionLevel.FunctionCode).Sum(Function(Det) Det.IncomeAmount)
                InvoiceAssignedCoopFunctionLevel.CostAmount = InvoiceAssignedCoopDetails.Where(Function(Det) Det.FunctionCode = InvoiceAssignedCoopFunctionLevel.FunctionCode).Sum(Function(Det) Det.CostAmount)

            Next

            DataGridViewTop_FunctionTotals.CurrentView.RefreshData()

        End Sub

#Region "  Show Form Methods "

        Public Overloads Shared Sub ShowDialog(ByVal BillingUser As String, ByVal BillingCommandCenterID As Integer)

            'objects
            Dim BillingCommandCenterProductionCoopDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionCoopDialog = Nothing

            BillingCommandCenterProductionCoopDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterProductionCoopDialog(BillingUser, BillingCommandCenterID)

            BillingCommandCenterProductionCoopDialog.ShowDialog()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterProductionCoopDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewTop_FunctionTotals.OptionsCustomization.AllowFilter = False

            LoadGrid()

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                _InvoiceTaxFlag = AdvantageFramework.Database.Procedures.Agency.InvoiceTaxFlag(DbContext)

            End Using

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If Save() Then

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadSelectedDetailItem()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewLeftSection_JobComponents_LeavingRowEvent(e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_JobComponents.LeavingRowEvent

            e.Allow = CheckForUnsavedChanges()

        End Sub
        Private Sub DataGridViewLeftSection_JobComponents_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_JobComponents.SelectionChangedEvent

            LoadSelectedDetailItem()

        End Sub
        Private Sub DataGridViewBottom_JobComponentDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewBottom_JobComponentDetails.CellValueChangedEvent

            DataGridViewBottom_JobComponentDetails.CurrentView.UpdateTotalSummary()

            UpdateFunctionStatus()

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewBottom_JobComponentDetails_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewBottom_JobComponentDetails.CustomDrawGroupRowEvent

            Dim GridView As DevExpress.XtraGrid.Views.Grid.GridView = Nothing
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim InvoiceAssignedCoop As AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop = Nothing

            GridView = TryCast(sender, DevExpress.XtraGrid.Views.Grid.GridView)
            GridGroupRowInfo = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

            If GridView IsNot Nothing AndAlso GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.CDP.ToString Then

                    InvoiceAssignedCoop = DataGridViewBottom_JobComponentDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop)().Where(Function(Entity) Entity.CDP = GridGroupRowInfo.EditValue).FirstOrDefault

                    If InvoiceAssignedCoop IsNot Nothing Then

                        GridGroupRowInfo.GroupText = "Client: " & InvoiceAssignedCoop.ClientName & " | " &
                                                     "<color=Blue>Division: " & InvoiceAssignedCoop.DivisionName & "</color> | " &
                                                     "<color=Purple>Product: " & InvoiceAssignedCoop.ProductDescription & "</color> | " &
                                                     "<color=Green>Co-op Pct: " & FormatNumber(InvoiceAssignedCoop.CoopPercent.GetValueOrDefault(0), 4) & " %</color>"
                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewBottom_JobComponentDetails_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewBottom_JobComponentDetails.DataSourceChangedEvent

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            If Not Me.IsFormClosing Then

                DataGridViewBottom_JobComponentDetails.CurrentView.OptionsView.ShowFooter = True

                'DataGridViewRightSection_JobComponentDetails.CurrentView.OptionsView.EnableAppearanceOddRow = True
                'DataGridViewRightSection_JobComponentDetails.CurrentView.Appearance.OddRow.BackColor = Drawing.Color.FromArgb(240, 240, 240)

                For Each GridColumn In DataGridViewBottom_JobComponentDetails.Columns

                    If GridColumn.ColumnType Is GetType(System.Decimal) OrElse GridColumn.ColumnType Is GetType(System.Nullable(Of Decimal)) Then

                        If GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.IncomeAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.CostAmount.ToString OrElse
                                GridColumn.FieldName = AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop.Properties.TotalAmount.ToString Then

                            SetColumnAsSumColumn(DataGridViewBottom_JobComponentDetails, GridColumn.FieldName)

                        End If

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewBottom_JobComponentDetails_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewBottom_JobComponentDetails.ShowingEditorEvent

            If DirectCast(DataGridViewBottom_JobComponentDetails.CurrentView.GetRow(DataGridViewBottom_JobComponentDetails.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).Reconciled Then

                e.Cancel = True

            ElseIf Not _InvoiceTaxFlag AndAlso Not String.IsNullOrWhiteSpace(DirectCast(DataGridViewBottom_JobComponentDetails.CurrentView.GetRow(DataGridViewBottom_JobComponentDetails.CurrentView.FocusedRowHandle), AdvantageFramework.BillingCommandCenter.Classes.InvoiceAssignedCoop).SalesTaxCode) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace