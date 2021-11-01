Namespace Media.Presentation

    Public Class MediaManagerGenerateOrdersReviewDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder) = Nothing
        Private _SendToOrderReps As Boolean = True
        Private _ContactTypes As Generic.List(Of Integer) = Nothing
        Private _DocumentTypes As Generic.List(Of Long) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), SendToOrderReps As Boolean, ContactTypes As Generic.List(Of Integer), DocumentTypes As Generic.List(Of Long))

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _GenerateOrders = GenerateOrders
            _ContactTypes = ContactTypes
            _DocumentTypes = DocumentTypes
            _SendToOrderReps = SendToOrderReps

        End Sub
        Private Sub LoadGrid()

            If AdvantageFramework.MediaManager.CheckForVaildOrders(Me.Session, _GenerateOrders, _SendToOrderReps, _ContactTypes.ToArray) Then

                ButtonItemActions_Continue.Enabled = _GenerateOrders.Any(Function(Entity) Entity.Status = True)

                DataGridViewDetails_Details.DataSource = _GenerateOrders

                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobNumber.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobComponentNumber.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Quote.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.RevisionNumber.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Cancelled.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobMediaBillDate.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.StartDate.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.EndDate.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.PaymentMethod.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.TotalCostPayableToVendor.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.AmountPaidRedeemed.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.VCCLimit.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.VCCCardAmount.ToString)
                DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderLineStatus.ToString)

                DataGridViewDetails_Details.MakeColumnVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString)
                DataGridViewDetails_Details.MakeColumnVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderMessage.ToString)

                DataGridViewDetails_Details.CurrentView.ClearSorting()
                DataGridViewDetails_Details.CurrentView.BeginSort()
                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
                DataGridViewDetails_Details.CurrentView.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.LineNumber.ToString).SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
                DataGridViewDetails_Details.CurrentView.EndSort()

                DataGridViewDetails_Details.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub AddSubItemCheckBox(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal GridColumn As DevExpress.XtraGrid.Columns.GridColumn)

            'objects
            Dim RepositoryItemCheckEdit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
            Dim ImagesCollection As DevExpress.Utils.ImageCollection = Nothing

            RepositoryItemCheckEdit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit

            RepositoryItemCheckEdit.ExportMode = DevExpress.XtraEditors.Repository.ExportMode.DisplayText

            RepositoryItemCheckEdit.DisplayValueChecked = "Success"
            RepositoryItemCheckEdit.DisplayValueUnchecked = "Faliure"
            RepositoryItemCheckEdit.DisplayValueGrayed = "Pending"

            RepositoryItemCheckEdit.ValueChecked = True
            RepositoryItemCheckEdit.ValueUnchecked = False
            RepositoryItemCheckEdit.ValueGrayed = Nothing

            RepositoryItemCheckEdit.NullText = "Pending"
            RepositoryItemCheckEdit.NullStyle = DevExpress.XtraEditors.Controls.StyleIndeterminate.Inactive

            RepositoryItemCheckEdit.AllowGrayed = True
            RepositoryItemCheckEdit.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined

            ImagesCollection = New DevExpress.Utils.ImageCollection

            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatGreenCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatRedCircleImage)
            ImagesCollection.AddImage(AdvantageFramework.My.Resources.SmallFlatYellowCircleImage)

            RepositoryItemCheckEdit.Images = ImagesCollection

            RepositoryItemCheckEdit.ImageIndexChecked = 0
            RepositoryItemCheckEdit.ImageIndexUnchecked = 1
            RepositoryItemCheckEdit.ImageIndexGrayed = 2

            DataGridView.GridControl.RepositoryItems.Add(RepositoryItemCheckEdit)

            GridColumn.ColumnEdit = RepositoryItemCheckEdit

        End Sub
        Private Sub LoadData()

            Me.FormAction = WinForm.Presentation.FormActions.Loading
            Me.ShowWaitForm("Reviewing...")

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None
            Me.CloseWaitForm()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(GenerateOrders As Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder), SendToOrderReps As Boolean, ContactTypes As Generic.List(Of Integer), DocumentTypes As Generic.List(Of Long)) As System.Windows.Forms.DialogResult

            'objects
            Dim MediaManagerGenerateOrdersReviewDialog As MediaManagerGenerateOrdersReviewDialog = Nothing

            MediaManagerGenerateOrdersReviewDialog = New MediaManagerGenerateOrdersReviewDialog(GenerateOrders, SendToOrderReps, ContactTypes, DocumentTypes)

            ShowFormDialog = MediaManagerGenerateOrdersReviewDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub MediaManagerGenerateOrdersReviewDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim SubItemGridLookUpEditControl As AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl = Nothing

            ButtonItemActions_Continue.Image = AdvantageFramework.My.Resources.ArrowRight
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            DataGridViewDetails_Details.ItemDescription = "Order(s)"
            DataGridViewDetails_Details.ClearDatasource(New Generic.List(Of AdvantageFramework.MediaManager.Classes.GenerateOrder))

            AddSubItemCheckBox(DataGridViewDetails_Details, DataGridViewDetails_Details.Columns(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Status.ToString))

            DataGridViewDetails_Details.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True

            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobNumber.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobComponentNumber.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Quote.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.RevisionNumber.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.Cancelled.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.JobMediaBillDate.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.StartDate.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.EndDate.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.PaymentMethod.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.TotalCostPayableToVendor.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.AmountPaidRedeemed.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.VCCLimit.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.VCCCardAmount.ToString)
            DataGridViewDetails_Details.MakeColumnNotVisible(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.OrderLineStatus.ToString)

            DataGridViewDetails_Details.CurrentView.GridControl.ShowOnlyPredefinedDetails = True

            Try

                GridColumn = DataGridViewDetails_Details.Columns.ColumnByFieldName(AdvantageFramework.MediaManager.Classes.GenerateOrder.Properties.DefaultCorrespondenceMethod.ToString)

                If GridColumn IsNot Nothing Then

                    SubItemGridLookUpEditControl = AdvantageFramework.WinForm.Presentation.Controls.CreateSubItemGridLookupEdit(Me.Session, WinForm.Presentation.Controls.SubItemGridLookUpEditControl.Type.EnumDataTable,
                                                                                                                                GridColumn.FieldName, Nothing, Nothing,
                                                                                                                                GetType(AdvantageFramework.Database.Entities.DefaultCorrespondenceMethods), True)

                    If SubItemGridLookUpEditControl IsNot Nothing Then

                        SubItemGridLookUpEditControl.ExtraComboBoxItem = AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl.ExtraComboBoxItems.None
                        SubItemGridLookUpEditControl.ValueType = GetType(Short)

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                SubItemGridLookUpEditControl.LoadDefaultDataSourceView(DbContext, DataContext)

                            End Using

                        End Using

                        DataGridViewDetails_Details.GridControl.RepositoryItems.Add(SubItemGridLookUpEditControl)

                        GridColumn.ColumnEdit = SubItemGridLookUpEditControl

                    End If

                End If

            Catch ex As Exception

            End Try

            ButtonItemActions_Continue.Enabled = False

        End Sub
        Private Sub MediaManagerGenerateOrdersReviewDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            LoadData()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Continue_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Continue.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace