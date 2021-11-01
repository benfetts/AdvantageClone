Namespace ProjectManagement.Presentation

    Public Class ExistingEstimateFunctionsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _JobNumber As Integer = Nothing
        Private _JobComponentNumber As Short = Nothing
        Private _Quantity As Decimal = Nothing
        Private _Rate As Decimal = nothing
        Private _ExtendedAmount As Decimal = nothing
        Private _MarkupPercent As Decimal = nothing
        Private _MarkupAmount As Decimal = Nothing
        Private _FunctionCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobNumber As Integer
            Get
                JobNumber = _JobNumber
            End Get
        End Property
        Private ReadOnly Property JobComponentNumber As Short
            Get
                JobComponentNumber = _JobComponentNumber
            End Get
        End Property
        Private ReadOnly Property Quantity As Decimal
            Get
                Quantity = _Quantity
            End Get
        End Property
        Private ReadOnly Property Rate As Decimal
            Get
                Rate = _Rate
            End Get
        End Property
        Private ReadOnly Property ExtendedAmount As Decimal
            Get
                ExtendedAmount = _ExtendedAmount
            End Get
        End Property
        Private ReadOnly Property MarkupPercent As Decimal
            Get
                MarkupPercent = _MarkupPercent
            End Get
        End Property
        Private ReadOnly Property MarkupAmount As Decimal
            Get
                MarkupAmount = _MarkupAmount
            End Get
        End Property
        Private ReadOnly Property FunctionCode As String
            Get
                FunctionCode = _FunctionCode
            End Get
        End Property


#End Region

#Region " Methods "

        Private Sub New(ByVal JobNumber As Integer, ByRef JobComponentNumber As Short, ByRef Quantity As Decimal, ByRef Rate As Decimal, _
                        ByRef ExtendedAmount As Decimal, ByRef MarkupPercent As Decimal, ByRef MarkupAmount As Decimal, ByRef FunctionCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _JobNumber = JobNumber
            _JobComponentNumber = JobComponentNumber
            _Quantity = Quantity
            _Rate = Rate
            _ExtendedAmount = ExtendedAmount
            _MarkupPercent = MarkupPercent
            _MarkupAmount = MarkupAmount
            _FunctionCode = FunctionCode

        End Sub
        Private Sub ModifyGridColumns()

            Try

                If DataGridViewForm_EstimateFunctions.Columns(AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.FunctionCode.ToString) IsNot Nothing Then

                    DataGridViewForm_EstimateFunctions.Columns(AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.FunctionCode.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                    If TypeOf DataGridViewForm_EstimateFunctions.Columns("FunctionCode").ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        DirectCast(DataGridViewForm_EstimateFunctions.Columns("FunctionCode").ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DisplayMember = "Description"

                    End If

                End If

                If DataGridViewForm_EstimateFunctions.Columns(AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.EstimateQuoteNumber.ToString) IsNot Nothing Then

                    DataGridViewForm_EstimateFunctions.Columns(AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.EstimateQuoteNumber.ToString).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left

                End If

                If DataGridViewForm_EstimateFunctions.Columns(AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.VendorCode.ToString) IsNot Nothing Then

                    If TypeOf DataGridViewForm_EstimateFunctions.Columns("VendorCode").ColumnEdit Is AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl Then

                        DirectCast(DataGridViewForm_EstimateFunctions.Columns("VendorCode").ColumnEdit, AdvantageFramework.WinForm.Presentation.Controls.SubItemGridLookUpEditControl).DisplayMember = "Name"

                    End If

                End If

            Catch ex As Exception

            End Try

            DataGridViewForm_EstimateFunctions.CurrentView.BestFitColumns()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal JobNumber As Integer, Optional ByRef JobComponentNumber As Short = Nothing, _
                                              Optional ByRef Quantity As Decimal = Nothing, Optional ByRef Rate As Decimal = Nothing, _
                                              Optional ByRef ExtendedAmount As Decimal = Nothing, Optional ByRef MarkupPercent As Decimal = Nothing, _
                                              Optional ByRef MarkupAmount As Decimal = Nothing, Optional ByRef FunctionCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim ExistingEstimateFunctionsDialog As AdvantageFramework.ProjectManagement.Presentation.ExistingEstimateFunctionsDialog = Nothing

            ExistingEstimateFunctionsDialog = New AdvantageFramework.ProjectManagement.Presentation.ExistingEstimateFunctionsDialog(JobNumber, JobComponentNumber, Quantity, Rate, ExtendedAmount, MarkupPercent, MarkupAmount, FunctionCode)

            ShowFormDialog = ExistingEstimateFunctionsDialog.ShowDialog()

            JobNumber = ExistingEstimateFunctionsDialog.JobNumber
            JobComponentNumber = ExistingEstimateFunctionsDialog.JobComponentNumber
            Quantity = ExistingEstimateFunctionsDialog.Quantity
            Rate = ExistingEstimateFunctionsDialog.Rate
            ExtendedAmount = ExistingEstimateFunctionsDialog.ExtendedAmount
            MarkupPercent = ExistingEstimateFunctionsDialog.MarkupPercent
            MarkupAmount = ExistingEstimateFunctionsDialog.MarkupAmount
            FunctionCode = ExistingEstimateFunctionsDialog.FunctionCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExistingEstimateFunctionsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Loaded As Boolean = True
            Dim EstimateApproval As AdvantageFramework.Database.Views.EstimateApproval = Nothing
            Dim FncCode As String = Nothing

            DataGridViewForm_EstimateFunctions.MultiSelect = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _JobNumber <> 0 Then

                    If _JobComponentNumber = Nothing OrElse _JobComponentNumber = 0 Then

                        Try

                            _JobComponentNumber = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                                   Where Entity.JobNumber = _JobNumber
                                                   Select Entity.Number).Max

                        Catch ex As Exception
                            _JobComponentNumber = 1
                        End Try

                    End If

                    Try

                        EstimateApproval = (From Entity In AdvantageFramework.Database.Procedures.EstimateApprovalView.Load(DbContext)
                                            Where Entity.JobNumber = _JobNumber AndAlso
                                                   Entity.JobComponentNumber = _JobComponentNumber
                                            Select Entity).SingleOrDefault

                    Catch ex As Exception
                        EstimateApproval = Nothing
                    End Try

                    If EstimateApproval IsNot Nothing Then

                        FncCode = FunctionCode

                        If String.IsNullOrWhiteSpace(FncCode) Then

                            FncCode = ""

                        End If

                        DataGridViewForm_EstimateFunctions.DataSource = (From Entity In AdvantageFramework.Database.Procedures.EstimateRevisionDetail.Load(DbContext)
                                                                         Where Entity.EstimateNumber = EstimateApproval.EstimateNumber AndAlso
                                                                               Entity.EstimateComponentNumber = EstimateApproval.EstimateComponentNumber AndAlso
                                                                               Entity.EstimateQuoteNumber = EstimateApproval.EstimateQuoteNumber AndAlso
                                                                               Entity.EstimateRevisionNumber = EstimateApproval.EstimateRevisionNumber AndAlso
                                                                               Entity.Function.Type = "V" AndAlso
                                                                               Entity.FunctionCode = If(FncCode <> "", FncCode, Entity.FunctionCode)
                                                                         Select Entity).ToList

                        ModifyGridColumns()

                    Else

                        Loaded = False

                    End If

                Else

                    Loaded = False

                End If

            End Using

            If Loaded = False Then

                AdvantageFramework.WinForm.MessageBox.Show("An estimate has not been approved for this job and component.")

                Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            If DataGridViewForm_EstimateFunctions.HasOnlyOneSelectedRow Then

                _Quantity = CDec(DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.Quantity.ToString))
                _Rate = CDec(DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.RateAmount.ToString))
                _ExtendedAmount = CDec(DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.ExtendedAmount.ToString))
                _MarkupPercent = CDec(DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.CommissionPercent.ToString))
                _MarkupAmount = CDec(DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.MarkupAmount.ToString))
                _FunctionCode = DataGridViewForm_EstimateFunctions.CurrentView.GetRowCellValue(DataGridViewForm_EstimateFunctions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.EstimateRevisionDetail.Properties.FunctionCode.ToString)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an estimate function.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace