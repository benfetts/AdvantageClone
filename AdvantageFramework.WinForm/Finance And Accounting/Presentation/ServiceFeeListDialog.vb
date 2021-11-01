Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeListDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _ServiceFeeContractIDs As Integer() = Nothing
        Private _GenerateMissing As Boolean = Nothing
        Private _ContractDisplayStrings As Generic.Dictionary(Of Integer, String) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ServiceFeeContractIDs As Integer()
            Get
                ServiceFeeContractIDs = _ServiceFeeContractIDs
            End Get
        End Property
        Private ReadOnly Property GenerateMissing As Integer
            Get
                GenerateMissing = _GenerateMissing
            End Get
        End Property
        Private ReadOnly Property SelectedNonCreatedFees As Integer
            Get
                'objects
                Dim Counter As Integer = 0

                If DataGridViewForm_ServiceFees.HasASelectedRow Then

                    For Each RowHandle In DataGridViewForm_ServiceFees.CurrentView.GetSelectedRows

                        If CBool(DataGridViewForm_ServiceFees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ServiceFee.Properties.Created.ToString)) = False Then

                            Counter = Counter + 1

                        End If

                    Next

                End If

                SelectedNonCreatedFees = Counter

            End Get
        End Property
        Private ReadOnly Property SelectedCreatedFees As Integer
            Get
                'objects
                Dim Counter As Integer = 0

                If DataGridViewForm_ServiceFees.HasASelectedRow Then

                    For Each RowHandle In DataGridViewForm_ServiceFees.CurrentView.GetSelectedRows

                        If CBool(DataGridViewForm_ServiceFees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ServiceFee.Properties.Created.ToString)) = True Then

                            Counter = Counter + 1

                        End If

                    Next

                End If

                SelectedCreatedFees = Counter

            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ServiceFeeContractIDs As Integer(), ByVal GenerateMissing As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ServiceFeeContractIDs = ServiceFeeContractIDs
            _GenerateMissing = GenerateMissing

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim SQLString As String = ""
            Dim ServiceFeeList As Generic.List(Of AdvantageFramework.Database.Classes.ServiceFee) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ServiceFeeList = New Generic.List(Of Database.Classes.ServiceFee)

                For Each ServiceFeeContractID In _ServiceFeeContractIDs

                    SQLString = String.Format("EXEC [dbo].[advsp_job_service_fee_contract_items_load] {0}, {1}", ServiceFeeContractID, If(_GenerateMissing, 1, 0))

                    ServiceFeeList.AddRange(DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ServiceFee)(SQLString).ToList)

                Next

                DataGridViewForm_ServiceFees.DataSource = ServiceFeeList

            End Using

            DataGridViewForm_ServiceFees.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadContractDisplayData()

            'objects
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing

            If _ServiceFeeContractIDs IsNot Nothing AndAlso _ServiceFeeContractIDs.Count > 1 Then

                _ContractDisplayStrings = New Generic.Dictionary(Of Integer, String)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    For Each ServiceFeeContractID In _ServiceFeeContractIDs

                        JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, ServiceFeeContractID)

                        If JobServiceFee IsNot Nothing Then

                            _ContractDisplayStrings.Add(JobServiceFee.ID, String.Format("{0} | {1} - {2}",
                                                                                         JobServiceFee.Description,
                                                                                         If(JobServiceFee.FeeStartDate.HasValue, JobServiceFee.FeeStartDate.Value.ToShortDateString, ""),
                                                                                         If(JobServiceFee.FeeEndDate.HasValue, JobServiceFee.FeeEndDate.Value.ToShortDateString, "")))

                        End If

                    Next

                End Using

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonForm_Create.Enabled = Me.SelectedNonCreatedFees > 0 AndAlso Me.SelectedCreatedFees = 0

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ServiceFeeContractID As Integer, ByVal GenerateMissing As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeListDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog = Nothing
            Dim ServiceFeeContractIDs As Integer() = Nothing

            ServiceFeeContractIDs = {ServiceFeeContractID}

            ServiceFeeListDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog(ServiceFeeContractIDs, GenerateMissing)

            ShowFormDialog = ServiceFeeListDialog.ShowDialog()

        End Function
        Public Shared Function ShowFormDialog(ByVal ServiceFeeContractIDs As Integer(), ByVal GenerateMissing As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeListDialog As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog = Nothing

            ServiceFeeListDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeListDialog(ServiceFeeContractIDs, GenerateMissing)

            ShowFormDialog = ServiceFeeListDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeListDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = False
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing

            If _ServiceFeeContractIDs IsNot Nothing AndAlso ServiceFeeContractIDs.Count > 0 Then

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                Try

                    LoadContractDisplayData()

                Catch ex As Exception

                End Try

                Loaded = True

            Else

                Loaded = False

            End If

            If _GenerateMissing Then

                DataGridViewForm_ServiceFees.ShowSelectDeselectAllButtons = True
                ButtonForm_Ok.Visible = False
                ButtonForm_Create.Visible = True
                PanelForm_TopSection.Visible = True

                Try

                    DataGridViewForm_ServiceFees.CurrentView.AFActiveFilterString = "[Created] = False"

                Catch ex As Exception

                End Try

            Else

                DataGridViewForm_ServiceFees.ShowSelectDeselectAllButtons = False
                ButtonForm_Ok.Visible = True
                ButtonForm_Create.Visible = False
                PanelForm_TopSection.Visible = False

            End If

            ButtonForm_Create.SecurityEnabled = AdvantageFramework.Security.CanUserAddInModule(Me.Session, Security.Modules.FinanceAccounting_IncomeOnly)

            EnableOrDisableActions()

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("There was a problem loading the Service Fee Contract items.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(sender As Object, e As EventArgs) Handles ButtonForm_Create.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Created As Boolean = False
            Dim InvoiceDates As Generic.List(Of Date) = Nothing

            If Me.SelectedNonCreatedFees > 0 AndAlso Me.SelectedCreatedFees = 0 Then

                Try

                    InvoiceDates = New Generic.List(Of Date)

                    For Each ServiceFeeContractID In _ServiceFeeContractIDs

                        InvoiceDates.Clear()

                        For Each RowHandle In DataGridViewForm_ServiceFees.CurrentView.GetSelectedRows()

                            If DataGridViewForm_ServiceFees.CurrentView.IsGroupRow(RowHandle) = False Then

                                If DataGridViewForm_ServiceFees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ServiceFee.Properties.JobServiceFeeContractID.ToString) = ServiceFeeContractID Then

                                    InvoiceDates.Add(DataGridViewForm_ServiceFees.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Classes.ServiceFee.Properties.InvoiceDate.ToString))

                                End If

                            End If

                        Next

                        If InvoiceDates IsNot Nothing AndAlso InvoiceDates.Count > 0 Then

                            Created = AdvantageFramework.IncomeOnly.CreateFromServiceFee(Me.Session, ServiceFeeContractID, InvoiceDates.ToArray)

                        End If

                    Next

                Catch ex As Exception

                End Try

            Else

                ErrorMessage = "Please select at least one service fee that has not been created."

            End If

            If Created Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    ErrorMessage = "There was a problem generating income only records."

                End If

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Ok_Click(sender As Object, e As EventArgs) Handles ButtonForm_Ok.Click

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_ServiceFees_CustomDrawGroupRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs) Handles DataGridViewForm_ServiceFees.CustomDrawGroupRowEvent

            'object
            Dim GridGroupRowInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo = Nothing
            Dim GroupText As String = Nothing

            Try

                GridGroupRowInfo = e.Info

            Catch ex As Exception
                GridGroupRowInfo = Nothing
            End Try

            If GridGroupRowInfo IsNot Nothing Then

                If GridGroupRowInfo.Column.FieldName = AdvantageFramework.Database.Classes.ServiceFee.Properties.JobServiceFeeContractID.ToString Then

                    If GridGroupRowInfo.EditValue IsNot Nothing Then

                        If _ContractDisplayStrings IsNot Nothing AndAlso _ContractDisplayStrings.Count > 0 Then

                            Try

                                GroupText = _ContractDisplayStrings(CInt(GridGroupRowInfo.EditValue))

                            Catch ex As Exception
                                GroupText = ""
                            End Try

                        End If

                        If String.IsNullOrWhiteSpace(GroupText) Then

                            GroupText = CStr(GridGroupRowInfo.EditValue)

                        End If

                    Else

                        GroupText = ""

                    End If

                    GridGroupRowInfo.GroupText = GroupText

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFees_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ServiceFees.DataSourceChangedEvent

            DataGridViewForm_ServiceFees.CurrentView.ClearGrouping()

            If DataGridViewForm_ServiceFees.Columns IsNot Nothing AndAlso DataGridViewForm_ServiceFees.Columns.Count > 0 Then

                If _ServiceFeeContractIDs IsNot Nothing AndAlso _ServiceFeeContractIDs.Count > 0 Then

                    If _ServiceFeeContractIDs.Count > 1 Then

                        DataGridViewForm_ServiceFees.Columns(AdvantageFramework.Database.Classes.ServiceFee.Properties.JobServiceFeeContractID.ToString).Group()
                        DataGridViewForm_ServiceFees.CurrentView.ExpandAllGroups()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_ServiceFees_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_ServiceFees.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
