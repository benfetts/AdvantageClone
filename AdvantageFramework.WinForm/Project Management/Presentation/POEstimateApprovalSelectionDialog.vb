Namespace ProjectManagement.Presentation

    Public Class POEstimateApprovalSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _PONumber As Integer = Nothing
        Private _VendorCode As String = ""
        Private _EstimateRevisionDetails As Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail) = Nothing
        Private _HasASelectedJob As Boolean = False
        Private _HasASelectedCampaign As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property PONumber As Integer
            Get
                PONumber = _PONumber
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal PONumber As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _PONumber = PONumber

            CheckBoxForm_ItemsAssociatedToPOVendorOnly.ByPassUserEntryChanged = True
            RadioButtonControlForm_AddByCampaign.ByPassUserEntryChanged = True
            RadioButtonControlForm_AddByJob.ByPassUserEntryChanged = True

        End Sub
        Private Sub LoadSearchGrids()

            'objects
            Dim JobComponentIDs As Integer() = Nothing
            Dim JobAndComps As String() = Nothing
            Dim CampaignIDs As Integer() = Nothing
            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If CheckBoxForm_ItemsAssociatedToPOVendorOnly.Checked Then

                        CampaignIDs = (From Entity In _EstimateRevisionDetails
                                       Where Entity.VendorCode = _VendorCode AndAlso
                                         Entity.CampaignID.HasValue = True
                                       Select Entity.CampaignID.GetValueOrDefault(0)).Distinct.ToArray

                        JobAndComps = (From Entity In _EstimateRevisionDetails
                                       Where Entity.VendorCode = _VendorCode
                                       Select Entity.JobNumber.ToString & "|" & Entity.JobComponentNumber.ToString).Distinct.ToArray

                        Try


                            DataGridViewLeftSection_Campaign.DataSource = From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                          Where CampaignIDs.Contains(Entity.ID) AndAlso
                                                                            (Entity.IsClosed Is Nothing OrElse
                                                                             Entity.IsClosed = 0)
                                                                          Order By Entity.ID Descending
                                                                          Select Entity

                        Catch ex As Exception

                        End Try

                        Try

                            DataGridViewLeftSection_JobsAndComponents.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Me.Session.UserCode, OpenComponentsOnly:=True)
                                                                                    Where JobAndComps.Contains(Entity.JobNumber & "|" & Entity.JobComponentNumber)
                                                                                    Select Entity
                                                                                    Order By Entity.JobNumber Descending, Entity.JobComponentNumber Ascending)

                        Catch ex As Exception

                        End Try

                    Else

                        DataGridViewLeftSection_Campaign.DataSource = From Entity In AdvantageFramework.Database.Procedures.CampaignView.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext, Me.Session.UserCode)
                                                                      Where Entity.IsClosed Is Nothing OrElse
                                                                            Entity.IsClosed = 0
                                                                      Order By Entity.ID Descending
                                                                      Select Entity

                        JobComponentIDs = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext).Include("JobComponent")
                                           Select Entity.JobComponent.ID).ToArray

                        DataGridViewLeftSection_JobsAndComponents.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobComponentView.LoadByUserCode(DbContext, Me.Session.UserCode, OpenComponentsOnly:=True)
                                                                                Where JobComponentIDs.Contains(Entity.ID)
                                                                                Select Entity
                                                                                Order By Entity.JobNumber Descending, Entity.JobComponentNumber Ascending)

                    End If

                End Using

            End Using

            DataGridViewLeftSection_JobsAndComponents.CurrentView.BestFitColumns()
            DataGridViewLeftSection_Campaign.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim ContinueLoad As Boolean = False
            Dim JobNumbers As Integer() = Nothing
            Dim VendorCode As String = ""
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing
            Dim CampaignIDs As Integer() = Nothing
            Dim JobAndCompNumbers As Generic.List(Of String) = Nothing

            If RadioButtonControlForm_AddByCampaign.Checked Then

                If _HasASelectedCampaign Then

                    ContinueLoad = True

                End If

            ElseIf RadioButtonControlForm_AddByJob.Checked Then

                If _HasASelectedJob Then

                    ContinueLoad = True

                End If

            End If

            If ContinueLoad Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        If String.IsNullOrEmpty(_VendorCode) = False AndAlso CheckBoxForm_ItemsAssociatedToPOVendorOnly.Checked Then

                            VendorCode = _VendorCode

                        End If

                        If RadioButtonControlForm_AddByCampaign.Checked Then

                            CampaignIDs = DataGridViewLeftSection_Campaign.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToArray

                            DataGridViewRightSection_EstimateFunctions.DataSource = (From EstRevDetail In _EstimateRevisionDetails
                                                                                     Where EstRevDetail.CampaignID.HasValue AndAlso
                                                                                           CampaignIDs.Contains(EstRevDetail.CampaignID) AndAlso
                                                                                           EstRevDetail.VendorCode = If(String.IsNullOrEmpty(VendorCode), EstRevDetail.VendorCode, VendorCode)
                                                                                     Order By EstRevDetail.JobNumber Descending
                                                                                     Select EstRevDetail).ToList

                        ElseIf RadioButtonControlForm_AddByJob.Checked Then

                            JobAndCompNumbers = New Generic.List(Of String)

                            For Each SelectedRow In DataGridViewLeftSection_JobsAndComponents.GetAllSelectedRowsDataBoundItems

                                JobAndCompNumbers.Add(CInt(SelectedRow.JobNumber).ToString & "|" & CInt(SelectedRow.JobComponentNumber).ToString)

                            Next

                            DataGridViewRightSection_EstimateFunctions.DataSource = (From EstRevDetail In _EstimateRevisionDetails
                                                                                     Where JobAndCompNumbers.Contains(EstRevDetail.JobNumber.ToString & "|" & EstRevDetail.JobComponentNumber.ToString) AndAlso
                                                                                           EstRevDetail.VendorCode = If(String.IsNullOrEmpty(VendorCode), EstRevDetail.VendorCode, VendorCode)
                                                                                     Order By EstRevDetail.JobNumber Descending
                                                                                     Select EstRevDetail).ToList

                        End If

                    Catch ex As Exception
                        DataGridViewRightSection_EstimateFunctions.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)
                    End Try

                End Using

            Else

                DataGridViewRightSection_EstimateFunctions.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)

            End If

            DataGridViewRightSection_EstimateFunctions.CurrentView.BestFitColumns()

        End Sub
        Private Sub EnableOrDisableActions()



        End Sub
        Private Sub SetupSearch()

            If RadioButtonControlForm_AddByCampaign.Checked Then

                DataGridViewLeftSection_Campaign.Visible = True
                DataGridViewLeftSection_JobsAndComponents.Visible = False
                DataGridViewLeftSection_Campaign.FocusToFindPanel(True)

            ElseIf RadioButtonControlForm_AddByJob.Checked Then

                DataGridViewLeftSection_Campaign.Visible = False
                DataGridViewLeftSection_JobsAndComponents.Visible = True
                DataGridViewLeftSection_JobsAndComponents.FocusToFindPanel(True)

            Else

                RadioButtonControlForm_AddByCampaign.Checked = True
                DataGridViewLeftSection_Campaign.Visible = True
                DataGridViewLeftSection_JobsAndComponents.Visible = False
                DataGridViewLeftSection_Campaign.FocusToFindPanel(True)

            End If

            _HasASelectedCampaign = False
            _HasASelectedJob = False

            DataGridViewRightSection_EstimateFunctions.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PONumber As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim POEstimateApprovalSelectionDialog As AdvantageFramework.ProjectManagement.Presentation.POEstimateApprovalSelectionDialog = Nothing

            POEstimateApprovalSelectionDialog = New AdvantageFramework.ProjectManagement.Presentation.POEstimateApprovalSelectionDialog(PONumber)

            ShowFormDialog = POEstimateApprovalSelectionDialog.ShowDialog()

            PONumber = POEstimateApprovalSelectionDialog.PONumber

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub POEstimateApprovalSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
            Dim PurchaseOrder As AdvantageFramework.Database.Entities.PurchaseOrder = Nothing

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            DataGridViewRightSection_EstimateFunctions.MultiSelect = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                PurchaseOrder = AdvantageFramework.Database.Procedures.PurchaseOrder.LoadByPONumber(DbContext, _PONumber)

                If PurchaseOrder IsNot Nothing Then

                    _EstimateRevisionDetails = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)("exec [advsp_po_load_approved_est]").ToList

                    If String.IsNullOrEmpty(PurchaseOrder.VendorCode) = False Then

                        _VendorCode = PurchaseOrder.VendorCode
                        CheckBoxForm_ItemsAssociatedToPOVendorOnly.Checked = True

                    End If

                    LoadSearchGrids()

                    SetupSearch()

                    DataGridViewRightSection_EstimateFunctions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail))

                Else

                    Loaded = False

                End If

            End Using

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the purchase order!")

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Ok_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Ok.Click

            'objects
            Dim PurchaseOrderDetail As AdvantageFramework.Database.Entities.PurchaseOrderDetail = Nothing
            Dim EstimateRevisionDetails As Generic.List(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail) = Nothing
            Dim NonBillableSelected As Boolean = False

            If DataGridViewRightSection_EstimateFunctions.HasASelectedRow Then

                EstimateRevisionDetails = DataGridViewRightSection_EstimateFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail).ToList

                Try

                    NonBillableSelected = (From EstimateRevisionDetail In EstimateRevisionDetails
                                           Where EstimateRevisionDetail.NonBillable = 1
                                           Select EstimateRevisionDetail).Any

                Catch ex As Exception
                    NonBillableSelected = False
                End Try

                If NonBillableSelected = False OrElse
                    AdvantageFramework.Navigation.ShowMessageBox("One or more job components are marked as non billable. Are you sure you want to continue?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each EstimateRevisionDetail In DataGridViewRightSection_EstimateFunctions.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.EstimateRevisionDetail)()

                            PurchaseOrderDetail = New AdvantageFramework.Database.Entities.PurchaseOrderDetail

                            PurchaseOrderDetail.JobNumber = EstimateRevisionDetail.JobNumber
                            PurchaseOrderDetail.JobComponentNumber = EstimateRevisionDetail.JobComponentNumber
                            PurchaseOrderDetail.FunctionCode = EstimateRevisionDetail.FunctionCode
                            PurchaseOrderDetail.Quantity = EstimateRevisionDetail.Quantity
                            PurchaseOrderDetail.Rate = EstimateRevisionDetail.Rate
                            PurchaseOrderDetail.ExtendedAmount = EstimateRevisionDetail.ExtendedAmount
                            PurchaseOrderDetail.PurchaseOrderNumber = _PONumber
                            PurchaseOrderDetail.CommissionPercent = EstimateRevisionDetail.MarkupPercent
                            PurchaseOrderDetail.ExtendedMarkupAmount = EstimateRevisionDetail.ExtendedMarkupAmount

                            AdvantageFramework.Database.Procedures.PurchaseOrderDetail.Insert(DbContext, PurchaseOrderDetail)

                        Next

                    End Using

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate function.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub CheckBoxBottomLevel_ItemsAssociatedToPOVendorOnly_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxForm_ItemsAssociatedToPOVendorOnly.CheckedChangedEx

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                    LoadSearchGrids()
                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlForm_AddByCampaign_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlForm_AddByCampaign.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                SetupSearch()

            End If

        End Sub
        Private Sub RadioButtonControlForm_AddByJob_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlForm_AddByJob.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                SetupSearch()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Campaign_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_Campaign.DataSourceChangedEvent

            If DataGridViewLeftSection_Campaign.Columns IsNot Nothing AndAlso DataGridViewLeftSection_Campaign.Columns.Count > 0 Then

                DataGridViewLeftSection_Campaign.HideOrShowColumn(AdvantageFramework.Database.Views.CampaignView.Properties.IsClosed.ToString, False)

            End If

        End Sub
        Private Sub DataGridViewLeftSection_Campaign_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_Campaign.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewLeftSection_Campaign.Visible Then

                    _HasASelectedCampaign = True
                    LoadGrid()

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobsAndComponents_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_JobsAndComponents.DataSourceChangedEvent

            'objects
            Dim VisibleColumnsDictionary As Dictionary(Of String, Integer) = Nothing

            If DataGridViewLeftSection_JobsAndComponents.Columns IsNot Nothing AndAlso DataGridViewLeftSection_JobsAndComponents.Columns.Count > 0 Then

                DataGridViewLeftSection_JobsAndComponents.CurrentView.BeginUpdate()

                VisibleColumnsDictionary = New Dictionary(Of String, Integer)

                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.JobNumber.ToString, 1)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.JobDescription.ToString, 2)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.JobComponentNumber.ToString, 3)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.JobComponentDescription.ToString, 4)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.OfficeCode.ToString, 5)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.OfficeName.ToString, 6)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.ClientCode.ToString, 7)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.ClientName.ToString, 8)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.DivisionCode.ToString, 9)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.DivisionName.ToString, 10)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.ProductCode.ToString, 11)
                VisibleColumnsDictionary.Add(AdvantageFramework.Database.Views.JobComponentView.Properties.ProductDescription.ToString, 12)

                For Each GridColumn In DataGridViewLeftSection_JobsAndComponents.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    GridColumn.Visible = False

                Next

                For Each DictionaryItem In VisibleColumnsDictionary

                    If DataGridViewLeftSection_JobsAndComponents.Columns(DictionaryItem.Key) IsNot Nothing Then

                        DataGridViewLeftSection_JobsAndComponents.Columns(DictionaryItem.Key).Visible = True
                        DataGridViewLeftSection_JobsAndComponents.Columns(DictionaryItem.Key).VisibleIndex = DictionaryItem.Value

                    End If

                Next

                DataGridViewLeftSection_JobsAndComponents.CurrentView.EndUpdate()

            End If

        End Sub
        Private Sub DataGridViewLeftSection_JobsAndComponents_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_JobsAndComponents.SelectionChangedEvent

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                If DataGridViewLeftSection_JobsAndComponents.Visible Then

                    _HasASelectedJob = True
                    LoadGrid()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace