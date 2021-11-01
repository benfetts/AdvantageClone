Namespace Maintenance.Billing.Presentation

    Public Class BillRateCopyCDPDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingRateLevelID As Integer = Nothing
        Private _ClientEnabled As Boolean = False
        Private _DivisionEnabled As Boolean = False
        Private _ProductEnabled As Boolean = False
        Private _SalesClassEnabled As Boolean = False
        Private _FunctionEnabled As Boolean = False
        Private _EmployeeEnabled As Boolean = False
        Private _EmployeeTitleEnabled As Boolean = False
        Private _ReplaceRatesEnabled As Boolean = False
        Private _ReplaceNonBillableEnabled As Boolean = False
        Private _ReplaceMarkupPercent As Boolean = False
        Private _ReplaceSalesTaxEnabled As Boolean = False
        Private _ReplaceMarkupTaxFlagsEnabled As Boolean = False
        Private _ReplaceFeeTimeEnabled As Boolean = False
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal BillingRateLevelID As Integer, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _BillingRateLevelID = BillingRateLevelID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

        End Sub
        Private Sub LoadComboBoxes()

            'objects
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Core.Client) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Clients = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext))

                ComboBoxForm_SourceClient.DataSource = Clients
                ComboBoxForm_TargetClient.DataSource = Clients

            End Using

        End Sub
        Private Sub EnableOrDisableControls()

            ComboBoxForm_TargetClient.Enabled = _ClientEnabled
            ComboBoxForm_TargetDivision.Enabled = If(_DivisionEnabled, ComboBoxForm_TargetClient.HasASelectedValue, False)
            ComboBoxForm_TargetProduct.Enabled = If(_ProductEnabled, ComboBoxForm_TargetDivision.HasASelectedValue, False)
            CheckBoxForm_TargetDivision.Enabled = If(_DivisionEnabled, ComboBoxForm_TargetClient.HasASelectedValue, False)
            CheckBoxForm_TargetProduct.Enabled = If(_ProductEnabled, ComboBoxForm_TargetDivision.HasASelectedValue, False)

            CheckBoxNewRows_ReplaceRates.Enabled = _ReplaceRatesEnabled
            CheckBoxNewRows_ReplaceNonbillable.Enabled = _ReplaceNonBillableEnabled
            CheckBoxNewRows_ReplaceMarkupPercent.Enabled = _ReplaceMarkupPercent
            CheckBoxNewRows_ReplaceSalesTax.Enabled = _ReplaceSalesTaxEnabled
            CheckBoxNewRows_ReplaceMarkupTaxFlags.Enabled = _ReplaceMarkupTaxFlagsEnabled
            CheckBoxNewRows_ReplaceFeeTime.Enabled = _ReplaceFeeTimeEnabled

            CheckBoxExistingRows_ReplaceRates.Enabled = _ReplaceRatesEnabled
            CheckBoxExistingRows_ReplaceNonbillable.Enabled = _ReplaceNonBillableEnabled
            CheckBoxExistingRows_ReplaceMarkupPercent.Enabled = _ReplaceMarkupPercent
            CheckBoxExistingRows_ReplaceSalesTax.Enabled = _ReplaceSalesTaxEnabled
            CheckBoxExistingRows_ReplaceMarkupTaxFlags.Enabled = _ReplaceMarkupTaxFlagsEnabled
            CheckBoxExistingRows_ReplaceFeeTime.Enabled = _ReplaceFeeTimeEnabled

        End Sub
        Private Sub ResetControls()

            CheckBoxNewRows_ReplaceRates.Checked = _ReplaceRatesEnabled
            CheckBoxNewRows_ReplaceNonbillable.Checked = _ReplaceNonBillableEnabled
            CheckBoxNewRows_ReplaceMarkupPercent.Checked = _ReplaceMarkupPercent
            CheckBoxNewRows_ReplaceSalesTax.Checked = _ReplaceSalesTaxEnabled
            CheckBoxNewRows_ReplaceMarkupTaxFlags.Checked = _ReplaceMarkupTaxFlagsEnabled
            CheckBoxNewRows_ReplaceFeeTime.Checked = _ReplaceFeeTimeEnabled

            CheckBoxExistingRows_ReplaceRates.Checked = False
            CheckBoxExistingRows_ReplaceNonbillable.Checked = False
            CheckBoxExistingRows_ReplaceMarkupPercent.Checked = False
            CheckBoxExistingRows_ReplaceSalesTax.Checked = False
            CheckBoxExistingRows_ReplaceMarkupTaxFlags.Checked = False
            CheckBoxExistingRows_ReplaceFeeTime.Checked = False

            Try

                ComboBoxForm_TargetClient.SelectedIndex = 0
                ComboBoxForm_TargetDivision.SelectedIndex = 0
                ComboBoxForm_TargetProduct.SelectedIndex = 0

            Catch ex As Exception

            End Try

        End Sub
        Private Sub FilterDivisions(ByVal ClientComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox, ByVal DivisionComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox)

            'objects
            Dim ClientCode As String = Nothing

            If ClientComboBox.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ClientComboBox.GetSelectedValue

                    DivisionComboBox.DataSource = From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, ClientCode)
                                                  Where Entity.IsActive = 1
                                                  Select Entity

                    DivisionComboBox.Enabled = True

                    DivisionComboBox.SelectSingleItemDataSource()

                End Using

            Else

                Try

                    DivisionComboBox.Enabled = False
                    DivisionComboBox.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FilterProducts(ByVal ClientComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox, ByVal DivisionComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox, ByVal ProductComboBox As AdvantageFramework.WinForm.Presentation.Controls.ComboBox)

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing

            If DivisionComboBox.HasASelectedValue AndAlso ClientComboBox.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ClientCode = ClientComboBox.GetSelectedValue
                    DivisionCode = DivisionComboBox.GetSelectedValue

                    ProductComboBox.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode).ToList
                                                  Where Entity.IsActive = 1
                                                  Select Entity).ToList

                    ProductComboBox.Enabled = True

                    ProductComboBox.SelectSingleItemDataSource()

                End Using

            Else

                Try

                    ProductComboBox.Enabled = False
                    ProductComboBox.SelectedIndex = 0

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Function DuplicateBillingRateDetail(ByVal SourceBillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail, ByVal TargetBillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail, ByVal IsNew As Boolean) As Boolean

            'objects
            Dim Duplicated As Boolean = False
            Dim ReplaceRates As Boolean = Nothing
            Dim ReplaceNonBillable As Boolean = Nothing
            Dim ReplaceMarkupPercent As Boolean = Nothing
            Dim ReplaceSalesTax As Boolean = Nothing
            Dim ReplaceMarkupTaxFlags As Boolean = Nothing
            Dim ReplaceFeeTime As Boolean = Nothing

            If SourceBillingRateDetail IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If IsNew Then

                        ReplaceRates = CheckBoxNewRows_ReplaceRates.Checked
                        ReplaceNonBillable = CheckBoxNewRows_ReplaceNonbillable.Checked
                        ReplaceMarkupPercent = CheckBoxNewRows_ReplaceMarkupPercent.Checked
                        ReplaceSalesTax = CheckBoxNewRows_ReplaceSalesTax.Checked
                        ReplaceMarkupTaxFlags = CheckBoxNewRows_ReplaceMarkupTaxFlags.Checked
                        ReplaceFeeTime = CheckBoxNewRows_ReplaceFeeTime.Checked

                    Else

                        ReplaceRates = CheckBoxExistingRows_ReplaceRates.Checked
                        ReplaceNonBillable = CheckBoxExistingRows_ReplaceNonbillable.Checked
                        ReplaceMarkupPercent = CheckBoxExistingRows_ReplaceMarkupPercent.Checked
                        ReplaceSalesTax = CheckBoxExistingRows_ReplaceSalesTax.Checked
                        ReplaceMarkupTaxFlags = CheckBoxExistingRows_ReplaceMarkupTaxFlags.Checked
                        ReplaceFeeTime = CheckBoxExistingRows_ReplaceFeeTime.Checked

                    End If

                    TargetBillingRateDetail.BillingRateLevelID = SourceBillingRateDetail.BillingRateLevelID
                    TargetBillingRateDetail.EffectiveDate = SourceBillingRateDetail.EffectiveDate
                    TargetBillingRateDetail.IsInactive = SourceBillingRateDetail.IsInactive

                    If ReplaceRates Then

                        TargetBillingRateDetail.RateAmount = SourceBillingRateDetail.RateAmount

                    End If

                    If ReplaceNonBillable Then

                        TargetBillingRateDetail.IsNonBillable = SourceBillingRateDetail.IsNonBillable

                    End If

                    If ReplaceMarkupPercent Then

                        TargetBillingRateDetail.IsCommission = SourceBillingRateDetail.IsCommission

                    End If

                    If ReplaceSalesTax Then

                        TargetBillingRateDetail.IsTax = SourceBillingRateDetail.IsTax
                        TargetBillingRateDetail.TaxCode = SourceBillingRateDetail.TaxCode

                    End If

                    If ReplaceMarkupTaxFlags Then

                        TargetBillingRateDetail.IsTaxCommission = SourceBillingRateDetail.IsTaxCommission

                    End If

                    If ReplaceFeeTime Then

                        TargetBillingRateDetail.IsFeeTime = SourceBillingRateDetail.IsFeeTime

                    End If

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        If IsNew Then

                            TargetBillingRateDetail.DbContext = DbContext

                            Duplicated = AdvantageFramework.Database.Procedures.BillingRateDetail.Insert(DbContext, TargetBillingRateDetail)

                        Else

                            Duplicated = AdvantageFramework.Database.Procedures.BillingRateDetail.Update(DbContext, TargetBillingRateDetail)

                        End If

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End Using

            End If

            DuplicateBillingRateDetail = Duplicated

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal BillingRateLevelID As Integer, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim BillRateCopyCDPDialog As AdvantageFramework.Maintenance.Billing.Presentation.BillRateCopyCDPDialog = Nothing

            BillRateCopyCDPDialog = New AdvantageFramework.Maintenance.Billing.Presentation.BillRateCopyCDPDialog(BillingRateLevelID, ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = BillRateCopyCDPDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BillRateCopyCDPDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim BillingRateLevel As AdvantageFramework.Database.Entities.BillingRateLevel = Nothing
            Dim BillingRateLevelDescriptionPart As String = ""

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                BillingRateLevel = AdvantageFramework.Database.Procedures.BillingRateLevel.LoadByBillingRateLevelID(DbContext, _BillingRateLevelID)

                If BillingRateLevel IsNot Nothing Then

                    LabelForm_StructureLevel.Text = BillingRateLevel.ToString

                    BillingRateLevelDescriptionPart = Split(BillingRateLevel.Description, "/").Last

                    _ClientEnabled = Convert.ToBoolean(BillingRateLevel.IsClientIncluded.GetValueOrDefault(0))
                    _DivisionEnabled = Convert.ToBoolean(BillingRateLevel.IsDivisionIncluded.GetValueOrDefault(0))
                    _ProductEnabled = Convert.ToBoolean(BillingRateLevel.IsProductIncluded.GetValueOrDefault(0))
                    _SalesClassEnabled = Convert.ToBoolean(BillingRateLevel.IsSalesClassIncluded.GetValueOrDefault(0))
                    _FunctionEnabled = Convert.ToBoolean(BillingRateLevel.IsFunctionIncluded.GetValueOrDefault(0))
                    _EmployeeEnabled = Convert.ToBoolean(BillingRateLevel.IsEmployeeIncluded.GetValueOrDefault(0))
                    _EmployeeTitleEnabled = Convert.ToBoolean(BillingRateLevel.IsEmployeeTitleIncluded.GetValueOrDefault(0))
                    _ReplaceRatesEnabled = Convert.ToBoolean(BillingRateLevel.IsBillingRateDetailIncluded.GetValueOrDefault(0))
                    _ReplaceNonBillableEnabled = Convert.ToBoolean(BillingRateLevel.IsNonBillableIncluded.GetValueOrDefault(0))
                    _ReplaceMarkupPercent = Convert.ToBoolean(BillingRateLevel.IsCommissionIncluded.GetValueOrDefault(0))
                    _ReplaceSalesTaxEnabled = Convert.ToBoolean(BillingRateLevel.IsTaxIncluded.GetValueOrDefault(0))
                    _ReplaceMarkupTaxFlagsEnabled = Convert.ToBoolean(BillingRateLevel.IsTaxCommissionIncluded.GetValueOrDefault(0))
                    _ReplaceFeeTimeEnabled = Convert.ToBoolean(BillingRateLevel.IsFeeTimeIncluded.GetValueOrDefault(0))

                    LoadComboBoxes()

                    If _ClientEnabled AndAlso String.IsNullOrEmpty(_ClientCode) = False Then

                        Try

                            ComboBoxForm_SourceClient.SelectedValue = _ClientCode

                        Catch ex As Exception

                        End Try

                        If _DivisionEnabled AndAlso ComboBoxForm_SourceClient.HasASelectedValue Then

                            FilterDivisions(ComboBoxForm_SourceClient, ComboBoxForm_SourceDivision)

                        End If

                    Else

                        ComboBoxForm_SourceClient.SecurityEnabled = _ClientEnabled
                        ComboBoxForm_SourceClient.Enabled = True

                    End If

                    If _DivisionEnabled AndAlso ComboBoxForm_SourceClient.HasASelectedValue AndAlso String.IsNullOrEmpty(_DivisionCode) = False Then

                        Try

                            ComboBoxForm_SourceDivision.SelectedValue = _DivisionCode

                        Catch ex As Exception

                        End Try

                        If _ProductEnabled AndAlso ComboBoxForm_SourceDivision.HasASelectedValue Then

                            FilterProducts(ComboBoxForm_SourceClient, ComboBoxForm_SourceDivision, ComboBoxForm_SourceProduct)

                        End If

                    Else

                        ComboBoxForm_SourceDivision.SecurityEnabled = _DivisionEnabled
                        ComboBoxForm_SourceDivision.Enabled = False

                    End If

                    If _ProductEnabled AndAlso ComboBoxForm_SourceClient.HasASelectedValue AndAlso ComboBoxForm_SourceDivision.HasASelectedValue AndAlso String.IsNullOrEmpty(_ProductCode) = False Then

                        Try

                            ComboBoxForm_SourceProduct.SelectedValue = _ProductCode

                        Catch ex As Exception

                        End Try

                        If ComboBoxForm_SourceProduct.HasASelectedValue = False Then

                            ComboBoxForm_SourceProduct.SelectedIndex = 0

                        End If

                    Else

                        ComboBoxForm_SourceProduct.SecurityEnabled = _ProductEnabled
                        ComboBoxForm_SourceProduct.Enabled = False

                    End If

                    ComboBoxForm_SourceClient.SetRequired(_ClientEnabled)
                    ComboBoxForm_SourceDivision.SetRequired(_DivisionEnabled)
                    ComboBoxForm_SourceProduct.SetRequired(_ProductEnabled)

                    ComboBoxForm_TargetClient.SetRequired(_ClientEnabled)
                    ComboBoxForm_TargetDivision.SetRequired(_DivisionEnabled)
                    ComboBoxForm_TargetProduct.SetRequired(_ProductEnabled)

                    CheckBoxNewRows_ReplaceRates.Checked = CheckBoxNewRows_ReplaceRates.Enabled
                    CheckBoxNewRows_ReplaceNonbillable.Checked = CheckBoxNewRows_ReplaceNonbillable.Enabled
                    CheckBoxNewRows_ReplaceMarkupPercent.Checked = CheckBoxNewRows_ReplaceMarkupPercent.Enabled
                    CheckBoxNewRows_ReplaceSalesTax.Checked = CheckBoxNewRows_ReplaceSalesTax.Enabled
                    CheckBoxNewRows_ReplaceMarkupTaxFlags.Checked = CheckBoxNewRows_ReplaceMarkupTaxFlags.Enabled
                    CheckBoxNewRows_ReplaceFeeTime.Checked = CheckBoxNewRows_ReplaceFeeTime.Enabled

                    EnableOrDisableControls()

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The billing rate level you are trying to copy does not exist.", WinForm.MessageBox.MessageBoxButtons.OK)

                    Me.DialogResult = Windows.Forms.DialogResult.Cancel
                    Me.Close()

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Copy_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Copy.Click

            'objects
            Dim SourceBillingRateDetailIDs() As Integer = Nothing
            Dim SourceBillingRateDetails As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing
            Dim TargetBillingRateDetail As AdvantageFramework.Database.Entities.BillingRateDetail = Nothing
            Dim LevelBillingRateDetails As Generic.List(Of AdvantageFramework.Database.Entities.BillingRateDetail) = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim TargetClientCode As String = Nothing
            Dim TargetDivisionCode As String = Nothing
            Dim TargetProductCode As String = Nothing
            Dim TargetSalesClassCode As String = Nothing
            Dim TargetFunctionCode As String = Nothing
            Dim TargetEmployeeCode As String = Nothing
            Dim TargetEmployeeTitleID As Nullable(Of Integer) = Nothing
            Dim TargetDivisions As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim TargetProducts As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim TargetDivision As AdvantageFramework.Database.Entities.Division = Nothing
            Dim TargetProduct As AdvantageFramework.Database.Entities.Product = Nothing
            Dim IsNew As Boolean = False
            Dim Duplicated As Boolean = False
            Dim CanCopy As Boolean = True
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                If ComboBoxForm_TargetClient.HasASelectedValue Then

                    If _DivisionEnabled AndAlso ComboBoxForm_TargetDivision.HasASelectedValue = False AndAlso CheckBoxForm_TargetDivision.Checked = False Then

                        ErrorMessage = "Please select a valid division."
                        CanCopy = False

                    End If

                    If CanCopy Then

                        If _ProductEnabled AndAlso ComboBoxForm_TargetProduct.HasASelectedValue = False AndAlso CheckBoxForm_TargetProduct.Checked = False Then

                            ErrorMessage = "Please select a valid product."
                            CanCopy = False

                        End If

                    End If

                End If

                If CanCopy Then

                    If AdvantageFramework.WinForm.MessageBox.Show("This process will copy new rows to the currect Structure Level: " & vbCrLf & vbCrLf &
                                                                  LabelForm_StructureLevel.Text & vbCrLf & vbCrLf &
                                                                  "Are you sure you want to continue?",
                                                                  WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving
                        Me.ShowWaitForm()
                        Me.ShowWaitForm("Copying...")

                        Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                ClientCode = ComboBoxForm_SourceClient.GetSelectedValue

                                If _DivisionEnabled Then

                                    DivisionCode = ComboBoxForm_SourceDivision.GetSelectedValue

                                End If

                                If _ProductEnabled Then

                                    ProductCode = ComboBoxForm_SourceProduct.GetSelectedValue

                                End If

                                If String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = False Then

                                    Try

                                        SourceBillingRateDetails = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.Load(DbContext)
                                                                    Where Entity.BillingRateLevelID = _BillingRateLevelID AndAlso
                                                                          Entity.ClientCode = ClientCode AndAlso
                                                                          Entity.DivisionCode = DivisionCode AndAlso
                                                                          Entity.ProductCode = ProductCode
                                                                    Select Entity).ToList

                                    Catch ex As Exception
                                        SourceBillingRateDetails = Nothing
                                    End Try

                                ElseIf String.IsNullOrEmpty(DivisionCode) = False AndAlso String.IsNullOrEmpty(ProductCode) = True Then

                                    Try

                                        SourceBillingRateDetails = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.Load(DbContext)
                                                                    Where Entity.BillingRateLevelID = _BillingRateLevelID AndAlso
                                                                          Entity.ClientCode = ClientCode AndAlso
                                                                          Entity.DivisionCode = DivisionCode
                                                                    Select Entity).ToList

                                    Catch ex As Exception
                                        SourceBillingRateDetails = Nothing
                                    End Try

                                ElseIf String.IsNullOrEmpty(DivisionCode) = True AndAlso String.IsNullOrEmpty(ProductCode) = True Then

                                    Try

                                        SourceBillingRateDetails = (From Entity In AdvantageFramework.Database.Procedures.BillingRateDetail.Load(DbContext)
                                                                    Where Entity.BillingRateLevelID = _BillingRateLevelID AndAlso
                                                                          Entity.ClientCode = ClientCode
                                                                    Select Entity).ToList

                                    Catch ex As Exception
                                        SourceBillingRateDetails = Nothing
                                    End Try

                                End If

                                If SourceBillingRateDetails IsNot Nothing AndAlso SourceBillingRateDetails.Count > 0 Then

                                    LevelBillingRateDetails = AdvantageFramework.Database.Procedures.BillingRateDetail.LoadByBillingRateLevelID(DbContext, _BillingRateLevelID).ToList

                                    For Each SourceBillingRateDetail In SourceBillingRateDetails

                                        IsNew = False
                                        TargetBillingRateDetail = Nothing

                                        TargetClientCode = Nothing
                                        TargetDivisionCode = Nothing
                                        TargetProductCode = Nothing
                                        TargetSalesClassCode = Nothing
                                        TargetFunctionCode = Nothing
                                        TargetEmployeeCode = Nothing
                                        TargetEmployeeTitleID = Nothing

                                        If ComboBoxForm_TargetClient.HasASelectedValue Then

                                            TargetClientCode = ComboBoxForm_TargetClient.GetSelectedValue

                                        Else

                                            TargetClientCode = SourceBillingRateDetail.ClientCode

                                        End If

                                        If ComboBoxForm_TargetDivision.HasASelectedValue Then

                                            TargetDivisionCode = ComboBoxForm_TargetDivision.GetSelectedValue

                                        Else

                                            TargetDivisionCode = SourceBillingRateDetail.DivisionCode

                                        End If

                                        If ComboBoxForm_TargetProduct.HasASelectedValue Then

                                            TargetProductCode = ComboBoxForm_TargetProduct.GetSelectedValue

                                        Else

                                            TargetProductCode = SourceBillingRateDetail.ProductCode

                                        End If

                                        TargetSalesClassCode = SourceBillingRateDetail.SalesClassCode
                                        TargetFunctionCode = SourceBillingRateDetail.FunctionCode
                                        TargetEmployeeCode = SourceBillingRateDetail.EmployeeCode
                                        TargetEmployeeTitleID = SourceBillingRateDetail.EmployeeTitleID

                                        If CheckBoxForm_TargetDivision.Checked AndAlso CheckBoxForm_TargetProduct.Checked Then

                                            TargetProducts = AdvantageFramework.Database.Procedures.Product.LoadByClientCode(DbContext, TargetClientCode).ToList

                                            For Each TargetProduct In TargetProducts

                                                Try

                                                    TargetBillingRateDetail = (From Entity In LevelBillingRateDetails
                                                                               Where Entity.ClientCode = TargetClientCode AndAlso
                                                                                      Entity.DivisionCode = TargetProduct.DivisionCode AndAlso
                                                                                      Entity.ProductCode = TargetProduct.Code AndAlso
                                                                                      Entity.SalesClassCode = TargetSalesClassCode AndAlso
                                                                                      Entity.FunctionCode = TargetFunctionCode AndAlso
                                                                                      Entity.EmployeeCode = TargetEmployeeCode AndAlso
                                                                                      Entity.EmployeeTitleID.GetValueOrDefault(0) = TargetEmployeeTitleID.GetValueOrDefault(0)
                                                                               Select Entity).SingleOrDefault

                                                Catch ex As Exception
                                                    TargetBillingRateDetail = Nothing
                                                End Try

                                                If TargetBillingRateDetail Is Nothing Then

                                                    IsNew = True

                                                    TargetBillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                                                End If

                                                TargetBillingRateDetail.ClientCode = TargetClientCode
                                                TargetBillingRateDetail.DivisionCode = TargetProduct.DivisionCode
                                                TargetBillingRateDetail.ProductCode = TargetProduct.Code
                                                TargetBillingRateDetail.SalesClassCode = TargetSalesClassCode
                                                TargetBillingRateDetail.FunctionCode = TargetFunctionCode
                                                TargetBillingRateDetail.EmployeeCode = TargetEmployeeCode

                                                If TargetEmployeeTitleID IsNot Nothing Then

                                                    TargetBillingRateDetail.EmployeeTitleID = TargetEmployeeTitleID

                                                Else

                                                    TargetBillingRateDetail.EmployeeTitleID = Nothing

                                                End If

                                                If DuplicateBillingRateDetail(SourceBillingRateDetail, TargetBillingRateDetail, IsNew) Then

                                                    Duplicated = True

                                                End If

                                            Next

                                        ElseIf CheckBoxForm_TargetDivision.Checked Then

                                            TargetDivisions = AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, TargetClientCode).ToList

                                            For Each TargetDivision In TargetDivisions

                                                Try

                                                    TargetBillingRateDetail = (From Entity In LevelBillingRateDetails
                                                                               Where Entity.ClientCode = TargetClientCode AndAlso
                                                                                      Entity.DivisionCode = TargetDivision.Code AndAlso
                                                                                      Entity.ProductCode = TargetProductCode AndAlso
                                                                                      Entity.SalesClassCode = TargetSalesClassCode AndAlso
                                                                                      Entity.FunctionCode = TargetFunctionCode AndAlso
                                                                                      Entity.EmployeeCode = TargetEmployeeCode AndAlso
                                                                                      Entity.EmployeeTitleID.GetValueOrDefault(0) = TargetEmployeeTitleID.GetValueOrDefault(0)
                                                                               Select Entity).SingleOrDefault

                                                Catch ex As Exception
                                                    TargetBillingRateDetail = Nothing
                                                End Try

                                                If TargetBillingRateDetail Is Nothing Then

                                                    IsNew = True

                                                    TargetBillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                                                End If

                                                TargetBillingRateDetail.ClientCode = TargetClientCode
                                                TargetBillingRateDetail.DivisionCode = TargetDivision.Code
                                                TargetBillingRateDetail.ProductCode = TargetProductCode
                                                TargetBillingRateDetail.SalesClassCode = TargetSalesClassCode
                                                TargetBillingRateDetail.FunctionCode = TargetFunctionCode
                                                TargetBillingRateDetail.EmployeeCode = TargetEmployeeCode

                                                If TargetEmployeeTitleID IsNot Nothing Then

                                                    TargetBillingRateDetail.EmployeeTitleID = TargetEmployeeTitleID

                                                Else

                                                    TargetBillingRateDetail.EmployeeTitleID = Nothing

                                                End If

                                                If DuplicateBillingRateDetail(SourceBillingRateDetail, TargetBillingRateDetail, IsNew) Then

                                                    Duplicated = True

                                                End If

                                            Next

                                        ElseIf CheckBoxForm_TargetProduct.Checked Then

                                            TargetProducts = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, TargetClientCode, TargetDivisionCode).ToList

                                            For Each TargetProduct In TargetProducts

                                                Try

                                                    TargetBillingRateDetail = (From Entity In LevelBillingRateDetails
                                                                               Where Entity.ClientCode = TargetClientCode AndAlso
                                                                                      Entity.DivisionCode = TargetDivisionCode AndAlso
                                                                                      Entity.ProductCode = TargetProduct.Code AndAlso
                                                                                      Entity.SalesClassCode = TargetSalesClassCode AndAlso
                                                                                      Entity.FunctionCode = TargetFunctionCode AndAlso
                                                                                      Entity.EmployeeCode = TargetEmployeeCode AndAlso
                                                                                      Entity.EmployeeTitleID.GetValueOrDefault(0) = TargetEmployeeTitleID.GetValueOrDefault(0)
                                                                               Select Entity).SingleOrDefault

                                                Catch ex As Exception
                                                    TargetBillingRateDetail = Nothing
                                                End Try

                                                If TargetBillingRateDetail Is Nothing Then

                                                    IsNew = True

                                                    TargetBillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                                                End If

                                                TargetBillingRateDetail.ClientCode = TargetClientCode
                                                TargetBillingRateDetail.DivisionCode = TargetDivisionCode
                                                TargetBillingRateDetail.ProductCode = TargetProduct.Code
                                                TargetBillingRateDetail.SalesClassCode = TargetSalesClassCode
                                                TargetBillingRateDetail.FunctionCode = TargetFunctionCode
                                                TargetBillingRateDetail.EmployeeCode = TargetEmployeeCode

                                                If TargetEmployeeTitleID IsNot Nothing Then

                                                    TargetBillingRateDetail.EmployeeTitleID = TargetEmployeeTitleID

                                                Else

                                                    TargetBillingRateDetail.EmployeeTitleID = Nothing

                                                End If

                                                If DuplicateBillingRateDetail(SourceBillingRateDetail, TargetBillingRateDetail, IsNew) Then

                                                    Duplicated = True

                                                End If

                                            Next

                                        Else

                                            Try

                                                TargetBillingRateDetail = (From Entity In LevelBillingRateDetails
                                                                           Where Entity.ClientCode = TargetClientCode AndAlso
                                                                                  Entity.DivisionCode = TargetDivisionCode AndAlso
                                                                                  Entity.ProductCode = TargetProductCode AndAlso
                                                                                  Entity.SalesClassCode = TargetSalesClassCode AndAlso
                                                                                  Entity.FunctionCode = TargetFunctionCode AndAlso
                                                                                  Entity.EmployeeCode = TargetEmployeeCode AndAlso
                                                                                  Entity.EmployeeTitleID.GetValueOrDefault(0) = TargetEmployeeTitleID.GetValueOrDefault(0)
                                                                           Select Entity).SingleOrDefault

                                            Catch ex As Exception
                                                TargetBillingRateDetail = Nothing
                                            End Try

                                            If TargetBillingRateDetail Is Nothing Then

                                                IsNew = True

                                                TargetBillingRateDetail = New AdvantageFramework.Database.Entities.BillingRateDetail

                                            End If

                                            TargetBillingRateDetail.ClientCode = TargetClientCode
                                            TargetBillingRateDetail.DivisionCode = TargetDivisionCode
                                            TargetBillingRateDetail.ProductCode = TargetProductCode
                                            TargetBillingRateDetail.SalesClassCode = TargetSalesClassCode
                                            TargetBillingRateDetail.FunctionCode = TargetFunctionCode
                                            TargetBillingRateDetail.EmployeeCode = TargetEmployeeCode

                                            If TargetEmployeeTitleID IsNot Nothing Then

                                                TargetBillingRateDetail.EmployeeTitleID = TargetEmployeeTitleID

                                            Else

                                                TargetBillingRateDetail.EmployeeTitleID = Nothing

                                            End If

                                            If DuplicateBillingRateDetail(SourceBillingRateDetail, TargetBillingRateDetail, IsNew) Then

                                                Duplicated = True

                                            End If

                                        End If

                                    Next

                                End If

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.FormAction = WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                        If Duplicated Then

                            AdvantageFramework.WinForm.MessageBox.Show("Copy was successful.")
                            Me.DialogResult = Windows.Forms.DialogResult.OK
                            Me.Close()

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("0 Rows Copied.")

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End If

        End Sub
        Private Sub ButtonForm_Close_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Close.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_ClearAll_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_ClearAll.Click

            ResetControls()
            LoadComboBoxes()

        End Sub
        Private Sub ComboBoxForm_TargetClient_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_TargetClient.SelectedValueChanged

            If _DivisionEnabled Then

                FilterDivisions(ComboBoxForm_TargetClient, ComboBoxForm_TargetDivision)

                CheckBoxForm_TargetDivision.Enabled = ComboBoxForm_TargetClient.HasASelectedValue

            End If

        End Sub
        Private Sub ComboBoxForm_TargetDivision_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_TargetDivision.SelectedValueChanged

            If _ProductEnabled Then

                FilterProducts(ComboBoxForm_TargetClient, ComboBoxForm_TargetDivision, ComboBoxForm_TargetProduct)

                CheckBoxForm_TargetProduct.Enabled = ComboBoxForm_TargetDivision.HasASelectedValue

            End If

        End Sub
        Private Sub ComboBoxForm_SourceClient_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_SourceClient.SelectedValueChanged

            If _DivisionEnabled AndAlso Me.FormShown Then

                FilterDivisions(ComboBoxForm_SourceClient, ComboBoxForm_SourceDivision)

            End If

        End Sub
        Private Sub ComboBoxForm_SourceDivision_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxForm_SourceDivision.SelectedValueChanged

            If _ProductEnabled AndAlso Me.FormShown Then

                FilterProducts(ComboBoxForm_SourceClient, ComboBoxForm_SourceDivision, ComboBoxForm_SourceProduct)

            End If

        End Sub
        Private Sub CheckBoxForm_TargetDivision_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxForm_TargetDivision.CheckedChanged

            If CheckBoxForm_TargetDivision.Checked Then

                ComboBoxForm_TargetDivision.SetRequired(False)
                ComboBoxForm_TargetDivision.Enabled = False

                If _ProductEnabled Then

                    CheckBoxForm_TargetProduct.Checked = True
                    CheckBoxForm_TargetProduct.Enabled = False


                End If

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ValidateControl(ComboBoxForm_TargetDivision)

                End If

            Else

                ComboBoxForm_TargetDivision.SetRequired(_DivisionEnabled)
                ComboBoxForm_TargetDivision.Enabled = If(_DivisionEnabled, ComboBoxForm_TargetClient.HasASelectedValue, False)

                If _ProductEnabled Then

                    CheckBoxForm_TargetProduct.Checked = False
                    CheckBoxForm_TargetProduct.Enabled = ComboBoxForm_TargetDivision.HasASelectedValue

                End If

            End If

        End Sub
        Private Sub CheckBoxForm_TargetProduct_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxForm_TargetProduct.CheckedChanged

            If CheckBoxForm_TargetProduct.Checked Then

                ComboBoxForm_TargetProduct.SetRequired(False)
                ComboBoxForm_TargetProduct.Enabled = False

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ValidateControl(ComboBoxForm_TargetProduct)

                End If

            Else

                ComboBoxForm_TargetProduct.SetRequired(_ProductEnabled)
                ComboBoxForm_TargetProduct.Enabled = If(_ProductEnabled, ComboBoxForm_TargetDivision.HasASelectedValue, False)

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
