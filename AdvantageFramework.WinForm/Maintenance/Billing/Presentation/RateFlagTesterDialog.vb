Namespace Maintenance.Billing.Presentation

    Public Class RateFlagTesterDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _HaveJobsBeenFiltered As Boolean = False

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()


        End Sub
        Private Sub LoadComboBoxes()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext)
                ComboBoxForm_Job.DataSource = AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext).OrderByDescending(Function(Job) Job.Number)
                ComboBoxForm_Function.DataSource = AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                ComboBoxForm_Employee.DataSource = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext)
                ComboBoxForm_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext)
                ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
                ComboBoxForm_JobComponent.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)
                ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            ComboBoxForm_Division.Enabled = ComboBoxForm_Client.HasASelectedValue
            ComboBoxForm_Product.Enabled = If(ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue, True, False)
            ComboBoxForm_JobComponent.Enabled = ComboBoxForm_Job.HasASelectedValue

        End Sub
        Private Sub ResetControls()

            LabelForm_RateLevelPlaceholder.Text = ""
            LabelForm_RatePlaceholder.Text = ""
            LabelForm_NonBillableLevelPlaceholder.Text = ""
            LabelForm_CommissionLevelPlaceholder.Text = ""
            LabelForm_CommissionPlaceholder.Text = ""
            LabelForm_TaxCodePlaceholder.Text = ""
            LabelForm_TaxCodeLevelPlaceholder.Text = ""
            LabelForm_FeeTimePlaceholder.Text = ""
            LabelForm_FeeTimeLevelPlaceholder.Text = ""
            DateTimePickerForm_EffectiveDate.ValueObject = Nothing

            ComboBoxForm_Division.Enabled = False
            ComboBoxForm_Product.Enabled = False
            ComboBoxForm_JobComponent.Enabled = False

            PictureBoxForm_NonBillable.Image = Nothing
            PictureBoxForm_Taxable.Image = Nothing
            PictureBoxForm_TaxCommission.Image = Nothing
            PictureBoxForm_TaxCommissionOnly.Image = Nothing

        End Sub
        Private Sub FilterJobComponents()

            'objects
            Dim JobNumber As Integer = Nothing

            If ComboBoxForm_Job.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    JobNumber = ComboBoxForm_Job.GetSelectedValue

                    ComboBoxForm_JobComponent.DataSource = From Entity In AdvantageFramework.Database.Procedures.JobComponent.LoadAllOpen(DbContext)
                                                           Order By Entity.JobNumber Descending, Entity.Number Ascending
                                                           Where Entity.JobNumber = JobNumber
                                                           Select Entity

                    ComboBoxForm_JobComponent.Enabled = True

                End Using

            Else

                Try

                    ComboBoxForm_JobComponent.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.JobComponent)
                    ComboBoxForm_JobComponent.Enabled = False
                    ComboBoxForm_JobComponent.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FilterDivisions()

            'objects
            Dim ClientCode As String = Nothing

            If ComboBoxForm_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue

                    ComboBoxForm_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode)
                                                       Where Entity.IsActive = 1
                                                       Select Entity

                    ComboBoxForm_Division.Enabled = True

                End Using

            Else

                Try

                    ComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Division)
                    ComboBoxForm_Division.Enabled = False
                    ComboBoxForm_Division.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FilterProducts()

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue
                    DivisionCode = ComboBoxForm_Division.GetSelectedValue

                    ComboBoxForm_Product.DataSource = From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                      Where Entity.IsActive = 1
                                                      Select Entity

                    ComboBoxForm_Product.Enabled = True

                End Using

            Else

                Try

                    ComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Product)
                    ComboBoxForm_Product.Enabled = False
                    ComboBoxForm_Product.SelectedValue = Nothing

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FilterJobs(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            If Me.Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing AndAlso ProductCode IsNot Nothing Then

                        ComboBoxForm_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)
                                                      Where Entity.IsOpen = 1
                                                      Order By Entity.Number Descending
                                                      Select Entity

                        _HaveJobsBeenFiltered = True

                    ElseIf ClientCode IsNot Nothing AndAlso DivisionCode IsNot Nothing Then

                        ComboBoxForm_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)
                                                      Where Entity.IsOpen = 1
                                                      Order By Entity.Number Descending
                                                      Select Entity

                        _HaveJobsBeenFiltered = True

                    ElseIf ClientCode IsNot Nothing Then

                        ComboBoxForm_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadByClientCode(DbContext, ClientCode)
                                                      Where Entity.IsOpen = 1
                                                      Order By Entity.Number Descending
                                                      Select Entity

                        _HaveJobsBeenFiltered = True

                    Else

                        ComboBoxForm_Job.DataSource = From Entity In AdvantageFramework.Database.Procedures.Job.LoadAllOpen(DbContext)
                                                      Order By Entity.Number Descending
                                                      Select Entity

                    End If

                End Using

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim RateFlagTesterDialog As AdvantageFramework.Maintenance.Billing.Presentation.RateFlagTesterDialog = Nothing

            RateFlagTesterDialog = New AdvantageFramework.Maintenance.Billing.Presentation.RateFlagTesterDialog()

            ShowFormDialog = RateFlagTesterDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub RateFlagTesterDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ComboBoxForm_Job.AutoFindItemInDataSource = True
            ComboBoxForm_JobComponent.AutoFindItemInDataSource = True
            ComboBoxForm_Function.SetRequired(True)
            ResetControls()

            Try

                LoadComboBoxes()

            Catch ex As Exception

            End Try

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub


#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Process_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Process.Click

            Dim BillingRate As AdvantageFramework.Database.Classes.BillingRate = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As String = Nothing
            Dim JobComponent As String = Nothing
            Dim SalesClassCode As String = Nothing
            Dim FunctionCode As String = Nothing
            Dim EmployeeCode As String = Nothing
            Dim EffectiveDate As System.DateTime = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ComboBoxForm_Client.GetSelectedValue
                    DivisionCode = ComboBoxForm_Division.GetSelectedValue
                    ProductCode = ComboBoxForm_Product.GetSelectedValue
                    JobNumber = ComboBoxForm_Job.GetSelectedValue
                    JobComponent = ComboBoxForm_JobComponent.GetSelectedValue
                    SalesClassCode = ComboBoxForm_SalesClass.GetSelectedValue
                    FunctionCode = ComboBoxForm_Function.GetSelectedValue
                    EmployeeCode = ComboBoxForm_Employee.GetSelectedValue
                    EffectiveDate = DateTimePickerForm_EffectiveDate.Value

                    BillingRate = AdvantageFramework.ExpenseReports.LoadBillingRate(DbContext, FunctionCode, ClientCode, DivisionCode, ProductCode, JobNumber, JobComponent, SalesClassCode, EmployeeCode, EffectiveDate)

                    If BillingRate IsNot Nothing Then

                        LabelForm_RatePlaceholder.Text = String.Format("{0:F2}", BillingRate.BILLING_RATE)
                        LabelForm_RateLevelPlaceholder.Text = BillingRate.GetLevelDescription(DbContext, BillingRate.RATE_LEVEL.GetValueOrDefault(0))

                        LabelForm_NonBillableLevelPlaceholder.Text = BillingRate.GetLevelDescription(DbContext, BillingRate.NOBILL_LEVEL.GetValueOrDefault(0))

                        LabelForm_CommissionPlaceholder.Text = BillingRate.COMM
                        LabelForm_CommissionLevelPlaceholder.Text = BillingRate.GetLevelDescription(DbContext, BillingRate.COMM_LEVEL.GetValueOrDefault(0))

                        LabelForm_TaxCodePlaceholder.Text = BillingRate.TAX_CODE
                        LabelForm_TaxCodeLevelPlaceholder.Text = BillingRate.GetLevelDescription(DbContext, BillingRate.TAX_LEVEL.GetValueOrDefault(0))

                        If BillingRate.FEE_TIME_FLAG.HasValue Then

                            Try

                                LabelForm_FeeTimePlaceholder.Text = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.FeeTimes))
                                                                     Where EnumObject.Code = BillingRate.FEE_TIME_FLAG.ToString
                                                                     Select EnumObject.Description).SingleOrDefault

                            Catch ex As Exception
                                LabelForm_FeeTimePlaceholder.Text = ""
                            End Try

                        Else

                            LabelForm_FeeTimePlaceholder.Text = ""

                        End If

                        LabelForm_FeeTimeLevelPlaceholder.Text = BillingRate.GetLevelDescription(DbContext, BillingRate.FEE_TIME_LEVEL.GetValueOrDefault(0))

                        Select Case BillingRate.NOBILL_FLAG

                            Case 1

                                PictureBoxForm_NonBillable.Image = AdvantageFramework.My.Resources.SmallGreenCircleImage

                            Case 0

                                PictureBoxForm_NonBillable.Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                            Case Else

                                PictureBoxForm_NonBillable.Image = Nothing

                        End Select

                        If BillingRate.TAX_CODE IsNot Nothing AndAlso BillingRate.TAX_CODE <> "" Then

                            PictureBoxForm_Taxable.Image = AdvantageFramework.My.Resources.SmallGreenCircleImage

                        Else

                            PictureBoxForm_Taxable.Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                        End If

                        Select Case BillingRate.TAX_COMM

                            Case 1

                                PictureBoxForm_TaxCommission.Image = AdvantageFramework.My.Resources.SmallGreenCircleImage

                            Case 0


                                PictureBoxForm_TaxCommission.Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                            Case Else

                                PictureBoxForm_TaxCommission.Image = Nothing

                        End Select

                        Select Case BillingRate.TAX_COMM_ONLY

                            Case 1

                                PictureBoxForm_TaxCommissionOnly.Image = AdvantageFramework.My.Resources.SmallGreenCircleImage

                            Case 0

                                PictureBoxForm_TaxCommissionOnly.Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                            Case Else

                                PictureBoxForm_TaxCommissionOnly.Image = Nothing

                        End Select

                        If ComboBoxForm_Client.HasASelectedValue AndAlso ComboBoxForm_Division.HasASelectedValue AndAlso ComboBoxForm_Product.HasASelectedValue Then

                            Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                            If Convert.ToBoolean(Product.ProductionBillNet.GetValueOrDefault(0)) Then

                                PictureBoxForm_BillNet.Image = AdvantageFramework.My.Resources.SmallGreenCircleImage

                            Else

                                PictureBoxForm_BillNet.Image = AdvantageFramework.My.Resources.SmallRedCircleImage

                            End If

                        Else

                            PictureBoxForm_BillNet.Image = Nothing

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonForm_Reset_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Reset.Click

            ResetControls()
            LoadComboBoxes()

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ComboBoxForm_Client_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Client.SelectedValueChanged

            If Me.FormShown Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    ComboBoxForm_Division.SelectedValue = Nothing
                    ComboBoxForm_Product.SelectedValue = Nothing
                    ComboBoxForm_Job.SelectedValue = Nothing
                    ComboBoxForm_JobComponent.SelectedValue = Nothing

                    FilterDivisions()

                    If ComboBoxForm_Division.SelectSingleItemDataSource() Then

                        FilterProducts()

                        If ComboBoxForm_Product.SelectSingleItemDataSource() Then

                            FilterJobs(ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue, ComboBoxForm_Product.GetSelectedValue)

                        Else

                            FilterJobs(ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue, Nothing)

                        End If

                    Else

                        FilterJobs(ComboBoxForm_Client.GetSelectedValue, Nothing, Nothing)

                    End If

                    EnableOrDisableActions()

                    If ComboBoxForm_Division.Enabled Then

                        ComboBoxForm_Division.Focus()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_Division_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Division.SelectedValueChanged

            If Me.FormShown Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    ComboBoxForm_Product.SelectedValue = Nothing
                    ComboBoxForm_Job.SelectedValue = Nothing
                    ComboBoxForm_JobComponent.SelectedValue = Nothing

                    FilterProducts()

                    If ComboBoxForm_Product.SelectSingleItemDataSource() Then

                        FilterJobs(ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue, ComboBoxForm_Product.GetSelectedValue)

                    Else

                        FilterJobs(ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue, Nothing)

                    End If

                    EnableOrDisableActions()

                    If ComboBoxForm_Product.Enabled Then

                        ComboBoxForm_Division.Focus()

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_Product_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_Product.SelectedValueChanged

            If Me.FormShown Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    FilterJobs(ComboBoxForm_Client.GetSelectedValue, ComboBoxForm_Division.GetSelectedValue, ComboBoxForm_Product.GetSelectedValue)

                    ComboBoxForm_Job.SelectedValue = Nothing
                    ComboBoxForm_JobComponent.SelectedValue = 0

                    EnableOrDisableActions()

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        Private Sub ComboBoxForm_Job_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxForm_Job.SelectedValueChanged

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing

            If Me.FormShown Then

                If Me.FormAction = WinForm.Presentation.FormActions.None Then

                    Me.FormAction = WinForm.Presentation.FormActions.Loading

                    If ComboBoxForm_Job.HasASelectedValue Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, ComboBoxForm_Job.GetSelectedValue)

                        End Using

                    End If

                    If Job IsNot Nothing Then

                        If ComboBoxForm_Client.HasASelectedValue = False Then

                            ComboBoxForm_Client.SelectedValue = Job.ClientCode

                            FilterDivisions()

                        End If

                        If ComboBoxForm_Division.HasASelectedValue = False Then

                            ComboBoxForm_Division.SelectedValue = Job.DivisionCode

                            FilterProducts()

                        End If

                        If ComboBoxForm_Product.HasASelectedValue = False Then

                            ComboBoxForm_Product.SelectedValue = Job.ProductCode

                        End If

                        FilterJobs(Job.ClientCode, Job.DivisionCode, Job.ProductCode)

                        ComboBoxForm_Job.SelectedValue = Job.Number

                        FilterJobComponents()

                        ComboBoxForm_JobComponent.SelectSingleItemDataSource()

                        EnableOrDisableActions()

                        If ComboBoxForm_JobComponent.Enabled Then

                            ComboBoxForm_JobComponent.Focus()

                        End If

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.None

                End If

            End If

        End Sub
        
#End Region

#End Region
        
    End Class

End Namespace