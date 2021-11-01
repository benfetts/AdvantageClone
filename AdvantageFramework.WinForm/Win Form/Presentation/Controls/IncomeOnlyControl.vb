Namespace WinForm.Presentation.Controls

    Public Class IncomeOnlyControl

#Region " Events "

        Public Event SelectedRowsChangedEvent()
        Public Event SelectedTabChangedEvent()
        Public Event OpeningContractEvent(ByRef Cancel As Boolean)

#End Region

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _JobNumber As Integer? = Nothing
        Private _JobComponentNumber As Integer? = Nothing
        Private _FunctionCode As String = Nothing
        Private _UpdateAllowed As Boolean = False
        Private _PrintAllowed As Boolean = False
        Private _AddAllowed As Boolean = False
        Private _BatchListIDs As Generic.List(Of Integer) = Nothing
        Private _CombosFiltering As Boolean = False
        Private _ShowDescriptions As Boolean = False
        Private _ControlHasLoaded As Boolean = False
        Private _ShowExistingIncomeOnlys As Boolean = False
        Private _LastFilter As String = Nothing
        Private _NewItemChanged As Boolean = False
        Private _AllowedInContracts As Boolean = False
        Private _InitNewRow As Boolean = False
        'Private _LoadedClientFullSource As Boolean = False
        'Private _LoadedDivisionFullSource As Boolean = False
        'Private _LoadedProductFullSource As Boolean = False
        'Private _LoadedJobFullSource As Boolean = False
        'Private _LoadedJobComponentFullSource As Boolean = False
        Private _LoadedFunctionFullSource As Boolean = False
        Private _ClientFilter As String = Nothing
        Private _DivisionFilter As String = Nothing
        Private _ProductFilter As String = Nothing
        Private _JobFilter As Integer? = Nothing
        Private _JobComponentFilter As Integer? = Nothing
        Private _FunctionFilter As String = Nothing
        Private _InvoiceDateFilter As Date? = Nothing
        Private _ReferenceCodeFilter As String = Nothing
        Private _ContractsFilter As Integer? = Nothing
        Private _FilterValueChanged As Boolean = False
        Private _MediaOrderLineSelectionInIncomeOnly As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DetailsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DetailsDataGridView = DataGridViewForm_Details
            End Get
        End Property
        Public ReadOnly Property ContractsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                ContractsDataGridView = ServiceFeeContractControlContracts_Contracts.DetailsDataGridView
            End Get
        End Property
        Public ReadOnly Property CanDeleteSelectedRows As Boolean
            Get
                'objects
                Dim CanDelete As Boolean = False

                If Me.UpdateAllowed Then

                    If DataGridViewForm_Details.HasASelectedRow Then

                        CanDelete = True

                        For Each IOnly In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()

                            If String.IsNullOrWhiteSpace(IOnly.BillingUser) = False Then

                                CanDelete = False
                                Exit For

                            End If

                        Next

                    End If

                End If

                CanDeleteSelectedRows = CanDelete

            End Get
        End Property
        Public ReadOnly Property CanCopySelectedRows As Boolean
            Get
                'objects
                Dim CanCopy As Boolean = False

                If Me.AddAllowed Then

                    If DataGridViewForm_Details.HasASelectedRow Then

                        CanCopy = True

                        For Each IOnly In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()

                            If String.IsNullOrWhiteSpace(IOnly.BillingUser) = False Then

                                CanCopy = False
                                Exit For

                            End If

                        Next

                    End If

                End If

                CanCopySelectedRows = CanCopy

            End Get
        End Property
        Public ReadOnly Property UpdateAllowed As Boolean
            Get
                UpdateAllowed = _UpdateAllowed
            End Get
        End Property
        Public ReadOnly Property PrintAllowed As Boolean
            Get
                PrintAllowed = _PrintAllowed
            End Get
        End Property
        Public ReadOnly Property AddAllowed As Boolean
            Get
                AddAllowed = _AddAllowed
            End Get
        End Property
        Public ReadOnly Property BatchListIDs As Generic.List(Of Integer)
            Get
                BatchListIDs = _BatchListIDs
            End Get
        End Property
        Public Property ShowDescriptions As Boolean
            Get
                ShowDescriptions = _ShowDescriptions
            End Get
            Set(value As Boolean)

                _ShowDescriptions = value

                ServiceFeeContractControlContracts_Contracts.ShowDescriptions = value

                RefreshColumnOrderAndVisibility()

                If _Session IsNot Nothing Then

                    AdvantageFramework.Security.SaveUserSetting(_Session, _Session.User.ID, Security.UserSettings.ShowDescriptionsInIncomeOnly, _ShowDescriptions)

                End If

            End Set
        End Property
        Public ReadOnly Property IsIncomeOnlyTabSeleted As Boolean
            Get
                IsIncomeOnlyTabSeleted = If(TabControlForm_IncomeOnly.SelectedTab Is TabItemIncomeOnly_IncomeOnlyTab, True, False)
            End Get
        End Property
        Public ReadOnly Property IsContractsTabSeleted As Boolean
            Get
                IsContractsTabSeleted = If(TabControlForm_IncomeOnly.SelectedTab Is TabItemIncomeOnly_ContractsTab, True, False)
            End Get
        End Property
        Public ReadOnly Property ServiceFeeContractControl As AdvantageFramework.WinForm.Presentation.Controls.ServiceFeeContractControl
            Get
                ServiceFeeContractControl = ServiceFeeContractControlContracts_Contracts
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        DataGridViewForm_Details.AutoFilterLookupColumns = True

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                DateTimePickerForm_InvoiceDate.ValueObject = Nothing

                                TabControlForm_IncomeOnly.SelectedTab = TabItemIncomeOnly_IncomeOnlyTab

                                ServiceFeeContractControlContracts_Contracts.AllowAddNew = False

                                _ShowDescriptions = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Security.UserSettings.ShowDescriptionsInIncomeOnly)
                                _AllowedInContracts = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, Security.Modules.FinanceAccounting_ServiceFees)

                                HideOrShowContractsTab()

                                DataGridViewForm_Details.AutoFilterLookupColumns = True

                                DataGridViewForm_Details.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Default

                                _UpdateAllowed = AdvantageFramework.Security.CanUserUpdateInModule(_Session, Security.Modules.FinanceAccounting_IncomeOnly)
                                _PrintAllowed = AdvantageFramework.Security.CanUserPrintInModule(_Session, Security.Modules.FinanceAccounting_IncomeOnly)
                                _AddAllowed = AdvantageFramework.Security.CanUserAddInModule(_Session, Security.Modules.FinanceAccounting_IncomeOnly)

                                _BatchListIDs = New Generic.List(Of Integer)

                                If _AddAllowed = False Then

                                    DataGridViewForm_Details.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                                End If

                                TextBoxForm_ReferenceCode.SetPropertySettings(AdvantageFramework.Database.Entities.IncomeOnly.Properties.ReferenceNumber)

                                SearchableComboBoxForm_Client.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Division.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Product.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Job.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Component.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Contracts.ByPassUserEntryChanged = True
                                SearchableComboBoxForm_Function.ByPassUserEntryChanged = True
                                TextBoxForm_ReferenceCode.ByPassUserEntryChanged = True
                                DateTimePickerForm_InvoiceDate.ByPassUserEntryChanged = True

                                SearchableComboBoxForm_Contracts.HideValueMemberColumn = True

                                SearchableComboBoxForm_Client.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.Client)
                                SearchableComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.DivisionView)
                                SearchableComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.ProductView)
                                SearchableComboBoxForm_Job.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobView)
                                SearchableComboBoxForm_Component.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.JobComponentView)
                                SearchableComboBoxForm_Function.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.FunctionView)

                                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                                    _MediaOrderLineSelectionInIncomeOnly = AdvantageFramework.Agency.LoadMediaOrderLineSelectionInIncomeOnly(DataContext)

                                End Using

                                'CdpJobCompFilterForm_Filter.InitializeDataControls()

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Protected Sub LoadTab(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            If TabItem Is Nothing Then

                For Each TabItem In TabControlForm_IncomeOnly.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                    TabItem.Tag = False

                Next

                TabItem = TabControlForm_IncomeOnly.SelectedTab

            End If

            If TabItem IsNot Nothing Then

                'AdvantageFramework.WinForm.Presentation.ShowWaitForm()

                If TabItem.Tag = False Then

                    If TabItem Is TabItemIncomeOnly_IncomeOnlyTab Then

                        LoadIncomeOnlyTab()

                    ElseIf TabItem Is TabItemIncomeOnly_ContractsTab Then

                        LoadContractsTab()

                    End If

                End If

                'AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Protected Sub LoadIncomeOnlyTab()

            'objects
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing
            Dim IncomeOnlyIDs As Integer() = Nothing

            If _Session IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ShowExistingIncomeOnlys = False Then

                        If _BatchListIDs IsNot Nothing AndAlso _BatchListIDs.Count > 0 Then

                            IncomeOnlyIDs = _BatchListIDs.ToArray

                        Else

                            IncomeOnlyIDs = New Integer() {-1}

                        End If

                    End If

                    DataGridViewForm_Details.DataSource = AdvantageFramework.IncomeOnly.Search(DbContext, _ClientCode, _DivisionCode, _ProductCode, _JobNumber.GetValueOrDefault(0), _JobComponentNumber.GetValueOrDefault(0), False, IncomeOnlyIDs).ToList

                End Using

                DataGridViewForm_Details.CurrentView.BestFitColumns()

                TabItemIncomeOnly_IncomeOnlyTab.Tag = True

            End If

        End Sub
        Protected Sub LoadContractsTab()

            Try

                ServiceFeeContractControlContracts_Contracts.ClearControl()

                ServiceFeeContractControlContracts_Contracts.Enabled = String.IsNullOrWhiteSpace(_ClientCode) = False OrElse _JobNumber.GetValueOrDefault(0) > 0

                If ServiceFeeContractControlContracts_Contracts.Enabled Then

                    ServiceFeeContractControlContracts_Contracts.LoadControl(Nothing, _ClientCode, _DivisionCode, _ProductCode, _JobNumber.GetValueOrDefault(0), _JobComponentNumber.GetValueOrDefault(0))

                    AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(ServiceFeeContractControlContracts_Contracts)

                End If

            Catch ex As Exception

            End Try

        End Sub
        Protected Sub CalculateLineItem(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly, ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount)

            If IncomeOnly IsNot Nothing Then

                CalculateBaseAmount(IncomeOnly.Quantity, IncomeOnly.Rate, IncomeOnly.Amount, IncomeOnly.FunctionCode, FieldChanged)
                CalculateLineItemCommission(IncomeOnly, True, False)
                CalculateLineItemTaxes(IncomeOnly)

            End If

        End Sub
        Protected Sub CalculateLineItem(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly, ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount)

            If IncomeOnly IsNot Nothing Then

                CalculateBaseAmount(IncomeOnly.Quantity, IncomeOnly.Rate, IncomeOnly.Amount, IncomeOnly.FunctionCode, FieldChanged)
                CalculateLineItemCommission(IncomeOnly, True, False)
                CalculateLineItemTaxes(IncomeOnly)

            End If

        End Sub
        Protected Sub CalculateBaseAmount(ByRef Quantity As Decimal?, ByRef Rate As Decimal?, ByRef Amount As Decimal?, ByVal FunctionCode As String, ByVal FieldChanged As AdvantageFramework.BillingSystem.QtyRateAmount)

            'objects
            Dim UseCPM As Boolean = False

            If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    UseCPM = CBool(AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode).CPMFlag.GetValueOrDefault(0))

                End Using

            End If

            AdvantageFramework.BillingSystem.CalculateQuantityRateAndAmount(Quantity, Rate, Amount, FieldChanged, 2, 4, 2, UseCPM)

        End Sub
        Protected Sub CalculateLineItemCommission(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly, ByVal PercentChanged As Boolean, ByVal CalculateItemTaxes As Boolean)

            If IncomeOnly IsNot Nothing Then

                CalculateCommission(IncomeOnly.Amount, IncomeOnly.CommissionPercent, IncomeOnly.MarkupAmount, PercentChanged)

                If CalculateItemTaxes Then

                    CalculateLineItemTaxes(IncomeOnly)

                End If

            End If

        End Sub
        Protected Sub CalculateLineItemCommission(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly, ByVal PercentChanged As Boolean, ByVal CalculateItemTaxes As Boolean)

            If IncomeOnly IsNot Nothing Then

                CalculateCommission(IncomeOnly.Amount, IncomeOnly.CommissionPercent, IncomeOnly.ExtendedMarkupAmount, PercentChanged)

                If CalculateItemTaxes Then

                    CalculateLineItemTaxes(IncomeOnly)

                End If

            End If

        End Sub
        Protected Sub CalculateCommission(ByVal Amount As Decimal?, ByRef CommissionPercent As Decimal?, ByRef MarkupAmount As Decimal?, ByVal PercentChanged As Boolean)

            AdvantageFramework.IncomeOnly.CalculateCommission(Amount, CommissionPercent, MarkupAmount, PercentChanged)

        End Sub
        Protected Sub CalculateLineItemTaxes(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            If IncomeOnly IsNot Nothing Then

                CalculateTaxes(IncomeOnly.Amount, IncomeOnly.MarkupAmount.GetValueOrDefault(0), IncomeOnly.TaxCityPercent.GetValueOrDefault(0), IncomeOnly.TaxCountyPercent.GetValueOrDefault(0), IncomeOnly.TaxStatePercent.GetValueOrDefault(0),
                               CBool(IncomeOnly.TaxCommission.GetValueOrDefault(0)), CBool(IncomeOnly.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnly.CityTaxAmount, IncomeOnly.CountyTaxAmount, IncomeOnly.StateTaxAmount)

            End If

        End Sub
        Protected Sub CalculateLineItemTaxes(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly)

            If IncomeOnly IsNot Nothing Then

                CalculateTaxes(IncomeOnly.Amount, IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0), IncomeOnly.TaxCityPercent.GetValueOrDefault(0), IncomeOnly.TaxCountyPercent.GetValueOrDefault(0), IncomeOnly.TaxStatePercent.GetValueOrDefault(0),
                               CBool(IncomeOnly.TaxCommission.GetValueOrDefault(0)), CBool(IncomeOnly.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnly.ExtendedCityResale, IncomeOnly.ExtendedCountyResale, IncomeOnly.ExtendedStateResale)

            End If

        End Sub
        Protected Sub CalculateTaxes(ByVal Amount As Decimal?, ByVal MarkupAmount As Decimal?, ByVal CityTaxPercent As Decimal?, ByVal CountyTaxPercent As Decimal?, ByVal StateTaxPercent As Decimal?,
                                     ByVal TaxCommission As Boolean, ByVal TaxCommissionOnly As Boolean, ByRef CityTaxAmount As Decimal?, ByRef CountyTaxAmount As Decimal?, ByRef StateTaxAmount As Decimal?)

            AdvantageFramework.IncomeOnly.CalculateTaxes(AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(_Session), Amount, MarkupAmount, CityTaxPercent, CountyTaxPercent, StateTaxPercent, TaxCommission, TaxCommissionOnly, CityTaxAmount, CountyTaxAmount, StateTaxAmount)

        End Sub
        Protected Sub UpdateBillingRate(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            If IncomeOnly IsNot Nothing Then

                LoadBillingRate(IncomeOnly.FunctionCode, IncomeOnly.ClientCode, IncomeOnly.DivisionCode, IncomeOnly.ProductCode, IncomeOnly.JobNumber, IncomeOnly.JobComponentNumber, IncomeOnly.SalesClassCode,
                                IncomeOnly.InvoiceDate, IncomeOnly.Rate, IncomeOnly.CommissionPercent, IncomeOnly.TaxCommission, IncomeOnly.TaxCommissionOnly, IncomeOnly.TaxCode, IncomeOnly.NonBillable)

                LoadSalesTax(IncomeOnly.TaxCode, IncomeOnly.TaxResale, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent)

                CalculateLineItem(IncomeOnly, BillingSystem.QtyRateAmount.Rate)

            End If

        End Sub
        Protected Sub LoadBillingRate(ByVal FunctionCode As String, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String,
                                      ByVal JobNumber As Integer?, ByVal JobComponentNumber As Integer?, ByVal SalesClassCode As String, ByVal InvoiceDate As Date,
                                      ByRef Rate As Decimal?, ByRef CommissionPercent As Decimal?, ByRef TaxCommission As Short?, ByRef TaxCommissionOnly As Short?,
                                      ByRef TaxCode As String, ByRef NonBillable As Short?)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageFramework.IncomeOnly.LoadBillingRate(DbContext, AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(DbContext), FunctionCode, ClientCode, DivisionCode,
                                                              ProductCode, JobNumber, JobComponentNumber, SalesClassCode, InvoiceDate, Rate,
                                                              CommissionPercent, TaxCommission, TaxCommissionOnly, TaxCode, NonBillable)

            End Using

        End Sub
        Protected Sub UpdateSalesTax(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            If IncomeOnly IsNot Nothing Then

                LoadSalesTax(IncomeOnly.TaxCode, IncomeOnly.TaxResale, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent)

                CalculateTaxes(IncomeOnly.Amount, IncomeOnly.MarkupAmount, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent, CBool(IncomeOnly.TaxCommission.GetValueOrDefault(0)),
                               CBool(IncomeOnly.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnly.CityTaxAmount, IncomeOnly.CountyTaxAmount, IncomeOnly.StateTaxAmount)

            End If

        End Sub
        Protected Sub UpdateSalesTax(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly)

            If IncomeOnly IsNot Nothing Then

                LoadSalesTax(IncomeOnly.TaxCode, IncomeOnly.TaxResale, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent)

                CalculateTaxes(IncomeOnly.Amount, IncomeOnly.ExtendedMarkupAmount, IncomeOnly.TaxCityPercent, IncomeOnly.TaxCountyPercent, IncomeOnly.TaxStatePercent, CBool(IncomeOnly.TaxCommission.GetValueOrDefault(0)),
                               CBool(IncomeOnly.TaxCommissionOnly.GetValueOrDefault(0)), IncomeOnly.ExtendedCityResale, IncomeOnly.ExtendedCountyResale, IncomeOnly.ExtendedStateResale)

            End If

        End Sub
        Protected Sub LoadSalesTax(ByVal TaxCode As String, ByRef TaxResale As Short?, ByRef TaxCityPercent As Decimal?, ByRef TaxCountyPercent As Decimal?, ByRef TaxStatePercent As Decimal?)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AdvantageFramework.IncomeOnly.LoadSalesTax(DbContext, AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(DbContext), TaxCode, TaxResale, TaxCityPercent, TaxCountyPercent, TaxStatePercent)

            End Using

        End Sub
        Protected Sub AddIncomeOnlyToBatchList(ByVal IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            AddIncomeOnlyToBatchList(IncomeOnly.ID)

        End Sub
        Protected Sub AddIncomeOnlyToBatchList(ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly)

            AddIncomeOnlyToBatchList(IncomeOnly.ID)

        End Sub
        Protected Sub AddIncomeOnlyToBatchList(ByVal IncomeOnlyID As Integer)

            If _BatchListIDs Is Nothing Then

                _BatchListIDs = New Generic.List(Of Integer)

            End If

            If _BatchListIDs.Contains(IncomeOnlyID) = False Then

                _BatchListIDs.Add(IncomeOnlyID)

            End If

        End Sub
        Protected Sub AddIncomeOnlysToBatchList(ByVal IncomeOnlyIDs As Integer())

            If IncomeOnlyIDs IsNot Nothing Then

                For Each IncomeOnlyID In IncomeOnlyIDs

                    AddIncomeOnlyToBatchList(IncomeOnlyID)

                Next

            End If

        End Sub
        Protected Sub EnableOrDisableActions()




        End Sub
        Protected Sub SetSearchableComboBoxPresetValue(ByVal SearchableComboBox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox, ByVal Value As Object)

            'objects
            Dim Enabled As Boolean = True

            If Value IsNot Nothing Then

                If TypeOf Value Is System.String Then

                    If String.IsNullOrWhiteSpace(CStr(Value)) = False Then

                        Enabled = False

                    End If

                ElseIf TypeOf Value Is System.Int32 Then

                    If CInt(Value) > 0 Then

                        Enabled = False

                    End If

                End If

            End If

            SearchableComboBox.SecurityEnabled = Enabled

            If SearchableComboBox.Enabled = False Then

                SearchableComboBox.SelectedValue = Value

            End If

        End Sub
        'Protected Function CopyIncomeOnly(ByVal IncomeOnlyToCopy As AdvantageFramework.Database.Entities.IncomeOnly, ByVal CopyToClientCode As String, ByVal CopyToDivisionCode As String, _
        '                                  ByVal CopyToProductCode As String, ByVal CopyToJobNumber As Integer, ByVal CopyToJobComponentNumber As Short, ByVal CopyToSalesClassCode As String)

        '    'objects
        '    Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
        '    Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

        '    Try

        '        If IncomeOnlyToCopy IsNot Nothing Then

        '            IncomeOnly = New AdvantageFramework.Database.Entities.IncomeOnly

        '            IncomeOnly.ID = Nothing
        '            IncomeOnly.SequenceNumber = Nothing
        '            IncomeOnly.ReferenceNumber = IncomeOnlyToCopy.ReferenceNumber
        '            IncomeOnly.JobNumber = IncomeOnlyToCopy.JobNumber
        '            IncomeOnly.JobComponentNumber = IncomeOnlyToCopy.JobComponentNumber
        '            IncomeOnly.FunctionCode = IncomeOnlyToCopy.FunctionCode
        '            IncomeOnly.InvoiceDate = IncomeOnlyToCopy.InvoiceDate
        '            IncomeOnly.Description = IncomeOnlyToCopy.Description
        '            IncomeOnly.DepartmentTeamCode = GetFunctionDepartmentTeamCode(IncomeOnly.FunctionCode)
        '            IncomeOnly.Quantity = IncomeOnlyToCopy.Quantity
        '            IncomeOnly.Rate = IncomeOnlyToCopy.Rate
        '            IncomeOnly.Amount = IncomeOnlyToCopy.Amount
        '            IncomeOnly.CommissionPercent = IncomeOnlyToCopy.CommissionPercent
        '            IncomeOnly.Comment = IncomeOnlyToCopy.Comment

        '            LoadBillingRate(IncomeOnly.FunctionCode, CopyToClientCode, CopyToDivisionCode, CopyToProductCode, _
        '                            CopyToJobNumber, CopyToJobComponentNumber, CopyToSalesClassCode, IncomeOnly.InvoiceDate, _
        '                            0, 0, IncomeOnly.TaxCommission, IncomeOnly.TaxCommissionOnly, IncomeOnly.TaxCode, IncomeOnly.NonBillable)

        '            UpdateSalesTax(IncomeOnly)

        '            CalculateLineItem(IncomeOnly, BillingSystem.QtyRateAmount.Amount)

        '            IncomeOnly.LineTotal = Math.Round(IncomeOnly.Amount.GetValueOrDefault(0) + IncomeOnly.ExtendedMarkupAmount.GetValueOrDefault(0) + _
        '                                              IncomeOnly.ExtendedCityResale.GetValueOrDefault(0) + IncomeOnly.ExtendedCountyResale.GetValueOrDefault(0) + _
        '                                              IncomeOnly.ExtendedStateResale.GetValueOrDefault(0), 2, MidpointRounding.AwayFromZero)

        '            IncomeOnly.BillHoldFlag = Nothing
        '            IncomeOnly.ARInvoiceNumber = Nothing
        '            IncomeOnly.ARInvoiceSequence = Nothing
        '            IncomeOnly.ARType = Nothing
        '            IncomeOnly.BillingUser = Nothing
        '            IncomeOnly.AdjusterComments = Nothing
        '            IncomeOnly.GeneralLedgerBilling = Nothing
        '            IncomeOnly.GeneralLedgerSales = Nothing
        '            IncomeOnly.GeneralLedgerState = Nothing
        '            IncomeOnly.GeneralLedgerCounty = Nothing
        '            IncomeOnly.GeneralLedgerCity = Nothing
        '            IncomeOnly.GeneralLedgerAccountSales = Nothing
        '            IncomeOnly.GeneralLedgerAccountState = Nothing
        '            IncomeOnly.GeneralLedgerAccountCounty = Nothing
        '            IncomeOnly.GeneralLedgerAccountCity = Nothing
        '            IncomeOnly.AdvanceBillFlag = Nothing
        '            IncomeOnly.IsModified = Nothing
        '            IncomeOnly.ModifiedBy = _Session.UserCode
        '            IncomeOnly.ModifiedDate = System.DateTime.Today
        '            IncomeOnly.DeleteFlag = Nothing
        '            IncomeOnly.DeletedBy = Nothing
        '            IncomeOnly.DeletedDate = Nothing
        '            IncomeOnly.PostPeriod = Nothing
        '            IncomeOnly.AdvanceBillID = Nothing
        '            IncomeOnly.CampaignUpdatedInvoiceDate = Nothing
        '            IncomeOnly.CampaignUpdatedPostPeriod = Nothing
        '            IncomeOnly.TransferFromJob = Nothing
        '            IncomeOnly.TransferFromJobComponent = Nothing
        '            IncomeOnly.TransferFromFunction = Nothing
        '            IncomeOnly.TransferFromIncomeOnlyID = Nothing
        '            IncomeOnly.TransferFromSequenceNumber = Nothing
        '            IncomeOnly.TransferAdjustedUser = Nothing
        '            IncomeOnly.TransferAdjustedDate = Nothing
        '            IncomeOnly.FeeInvoice = Nothing
        '            IncomeOnly.IsArchived = Nothing
        '            IncomeOnly.BillingApprovalID = Nothing
        '            IncomeOnly.BillingCommandCenterID = Nothing
        '            IncomeOnly.JobServiceFeeID = Nothing

        '        End If

        '    Catch ex As Exception
        '        IncomeOnly = Nothing
        '    Finally
        '        CopyIncomeOnly = IncomeOnly
        '    End Try

        'End Function
        'Protected Function CopyIncomeOnly(ByVal IncomeOnlyToCopy As AdvantageFramework.Database.Entities.IncomeOnly, ByVal CopyToJobComponent As AdvantageFramework.IncomeOnly.Classes.JobComponent) As AdvantageFramework.Database.Entities.IncomeOnly

        '    CopyIncomeOnly = CopyIncomeOnly(IncomeOnlyToCopy, CopyToJobComponent.ClientCode, CopyToJobComponent.DivisionCode, CopyToJobComponent.ProductCode, CopyToJobComponent.JobNumber, CopyToJobComponent.JobComponentNumber, CopyToJobComponent.SalesClassCode)

        'End Function
        Private Sub RefreshColumnOrderAndVisibility()

            'objects
            Dim ShowClient As Boolean = False
            Dim ShowDivision As Boolean = False
            Dim ShowProduct As Boolean = False
            Dim ShowJob As Boolean = False
            Dim ShowComponent As Boolean = False
            Dim VisibleIndex As Integer = 1

            If DataGridViewForm_Details.Columns IsNot Nothing AndAlso DataGridViewForm_Details.Columns.Count > 0 Then

                DataGridViewForm_Details.CurrentView.BeginUpdate()

                For Each GridColumn In DataGridViewForm_Details.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn).ToList

                    GridColumn.Visible = False

                Next

                ShowClient = Not SearchableComboBoxForm_Client.HasASelectedValue
                ShowDivision = Not SearchableComboBoxForm_Division.HasASelectedValue
                ShowProduct = Not SearchableComboBoxForm_Product.HasASelectedValue
                ShowJob = Not SearchableComboBoxForm_Job.HasASelectedValue
                ShowComponent = Not SearchableComboBoxForm_Component.HasASelectedValue

                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString, ShowClient, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientName.ToString, ShowClient AndAlso _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString, ShowDivision, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionName.ToString, ShowDivision AndAlso _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString, ShowProduct, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductName.ToString, ShowProduct AndAlso _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString, ShowJob, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobDescription.ToString, ShowJob AndAlso _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentNumber.ToString, False, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString, ShowComponent, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentDescription.ToString, ShowComponent AndAlso _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MediaType.ToString, _ShowDescriptions AndAlso _MediaOrderLineSelectionInIncomeOnly, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderNumber.ToString, _MediaOrderLineSelectionInIncomeOnly, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderDescription.ToString, _ShowDescriptions AndAlso _MediaOrderLineSelectionInIncomeOnly, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderLineNumber.ToString, _MediaOrderLineSelectionInIncomeOnly, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionDescription.ToString, _ShowDescriptions, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.InvoiceDate.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Quantity.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Rate.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Amount.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.CommissionPercent.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MarkupAmount.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.TaxCode.ToString, Not AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(_Session), VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Taxes.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.TotalAmount.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Description.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Comment.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.BillingUser.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.IsServiceFee.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.IsBilled.ToString, True, VisibleIndex)
                HideOrShowColumn(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.NonBillable.ToString, True, VisibleIndex)

                DataGridViewForm_Details.CurrentView.EndUpdate()

                DataGridViewForm_Details.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub HideOrShowColumn(ByVal FieldName As String, ByVal Visible As Boolean, ByRef VisibleIndex As Integer)

            If DataGridViewForm_Details.CurrentView.Columns(FieldName) IsNot Nothing Then

                DataGridViewForm_Details.CurrentView.Columns(FieldName).Visible = Visible

                If Visible Then

                    DataGridViewForm_Details.CurrentView.Columns(FieldName).VisibleIndex = VisibleIndex

                    VisibleIndex = VisibleIndex + 1

                End If

            End If

        End Sub
        Private Sub SetColumnFilter(ByVal FieldName As String, ByVal FilterValue As Object)

            'objects
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing
            Dim ColumnFilterInfo As DevExpress.XtraGrid.Columns.ColumnFilterInfo = Nothing
            Dim FilterString As String = ""

            GridColumn = DataGridViewForm_Details.CurrentView.Columns(FieldName)

            If GridColumn IsNot Nothing Then

                GridColumn.ClearFilter()

                If FilterValue IsNot Nothing Then

                    If GridColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString Then

                        FilterString = "[" & AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString & "] LIKE '%" & FilterValue.ToString & "%'"

                    Else

                        ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(GridColumn, FilterValue)

                    End If

                    If String.IsNullOrWhiteSpace(FilterString) = False Then

                        ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo(FilterString)

                    End If

                End If

                If ColumnFilterInfo IsNot Nothing Then

                    GridColumn.FilterInfo = ColumnFilterInfo

                End If

            End If

        End Sub
        Private Sub FilterByOptions(ByVal FieldName As String)

            ClearColumnFilter(FieldName)

            DataGridViewForm_Details.CurrentView.RefreshData()

        End Sub
        Private Sub ClearColumnFilter(ByVal FieldName As String)

            If String.IsNullOrWhiteSpace(FieldName) = False Then

                If DataGridViewForm_Details.CurrentView.Columns(FieldName) IsNot Nothing Then

                    DataGridViewForm_Details.CurrentView.Columns(FieldName).ClearFilter()

                    If FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientName.ToString)

                    ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionName.ToString)

                    ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductName.ToString)

                    ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobDescription.ToString)

                    ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentDescription.ToString)

                    ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString Then

                        ClearColumnFilter(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionDescription.ToString)

                    End If

                End If

            End If

        End Sub
        Private Sub LoadContractsLookup()

            'objects
            Dim JobNumbers As Integer() = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Integer = 0
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobServiceFeeObjectQuery As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobServiceFee) = Nothing

            SearchableComboBoxForm_Contracts.SelectedValue = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobNumber = SearchableComboBoxForm_Job.GetSelectedValue
                JobComponentNumber = SearchableComboBoxForm_Component.GetSelectedValue

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    JobServiceFeeObjectQuery = From Entity In AdvantageFramework.Database.Procedures.JobServiceFee.Load(DbContext)
                                               Where Entity.JobNumber = JobNumber AndAlso
                                                      Entity.JobComponentNumber = JobComponentNumber
                                               Select Entity

                Else

                    If JobNumber > 0 Then

                        JobNumbers = {JobNumber}

                    Else

                        ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
                        DivisionCode = SearchableComboBoxForm_Division.GetSelectedValue
                        ProductCode = SearchableComboBoxForm_Product.GetSelectedValue

                        JobNumbers = (From Item In AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode)
                                      Select [Jn] = Item.JobNumber).ToArray

                    End If

                    Try

                        If JobNumbers IsNot Nothing AndAlso JobNumbers.Count > 0 Then

                            'objects
                            JobServiceFeeObjectQuery = From Entity In AdvantageFramework.Database.Procedures.JobServiceFee.Load(DbContext)
                                                       Where JobNumbers.Contains(Entity.JobNumber)
                                                       Select Entity

                        End If

                    Catch ex As Exception

                    End Try

                End If

                If JobServiceFeeObjectQuery IsNot Nothing AndAlso JobServiceFeeObjectQuery.Count > 0 Then

                    SearchableComboBoxForm_Contracts.DataSource = JobServiceFeeObjectQuery

                Else

                    SearchableComboBoxForm_Contracts.DataSource = Nothing

                End If

            End Using

        End Sub
        Private Sub UpdateContractsFilter()

            'objects
            Dim SelectedContractID As Integer = Nothing

            If SearchableComboBoxForm_Contracts.HasASelectedValue Then

                SelectedContractID = SearchableComboBoxForm_Contracts.GetSelectedValue

            End If

            LoadContractsLookup()

            If SelectedContractID > 0 Then

                Try

                    SearchableComboBoxForm_Contracts.SelectedValue = SelectedContractID

                Catch ex As Exception
                    SearchableComboBoxForm_Contracts.SelectedValue = Nothing
                End Try

            End If

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True
            Dim BaseForm As AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm = Nothing

            If AdvantageFramework.WinForm.Presentation.Controls.CheckUserEntryChangedSetting(Me) Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                        BaseForm = DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm)

                    End If

                    If BaseForm IsNot Nothing Then

                        If IsOkay Then

                            IsOkay = False

                            BaseForm.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

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

                            BaseForm.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        End If

                    End If

                End If

            End If

            If IsOkay Then

                AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function SaveIncomeOnlyTab(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim NewIncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim ModifiedIncomeOnlyList As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly) = Nothing
            Dim JobComponentList As String() = Nothing
            Dim SelectedForBilling As Boolean = False
            Dim Reverse As Boolean = False
            Dim ApplyTaxUponBilling As Boolean = False
            Dim SqlParameterInvoiceDate As System.Data.SqlClient.SqlParameter = Nothing
            Dim SqlParameterID As System.Data.SqlClient.SqlParameter = Nothing

            Try

                If DataGridViewForm_Details.CurrentView.HasAnyInvalidRows = False Then

                    If _UpdateAllowed Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ApplyTaxUponBilling = AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(DbContext)

                            JobComponentList = (From Entity In AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode)
                                                Select Entity.JobNumber,
                                                       Entity.JobComponentNumber).ToList.Select(Function(JC) JC.JobNumber.ToString & "|" & JC.JobComponentNumber.ToString).ToArray

                            ModifiedIncomeOnlyList = DataGridViewForm_Details.GetAllModifiedRows.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)().ToList

                            For Each IncomeOnlyClass In ModifiedIncomeOnlyList

                                Reverse = False

                                IncomeOnly = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DbContext, IncomeOnlyClass.ID, IncomeOnlyClass.SequenceNumber)

                                If IncomeOnly IsNot Nothing Then

                                    If String.IsNullOrWhiteSpace(IncomeOnly.BillingUser) Then

                                        If IncomeOnlyClass.IsRevised Then

                                            Reverse = True

                                        ElseIf IncomeOnly.ARInvoiceNumber.HasValue AndAlso IncomeOnlyClass.IsBilled = False Then ' record was billed with app open

                                            Reverse = True

                                        End If

                                        If JobComponentList.Contains(IncomeOnlyClass.JobNumber.ToString & "|" & IncomeOnlyClass.JobComponentNumber.ToString) Then

                                            If Reverse Then

                                                NewIncomeOnly = IncomeOnly.DuplicateEntity()

                                                If AdvantageFramework.Database.Procedures.IncomeOnly.Reverse(DbContext, IncomeOnly, Database.Procedures.IncomeOnly.ReverseAction.Modify) Then

                                                    LoadBillingRate(IncomeOnlyClass.FunctionCode, IncomeOnlyClass.ClientCode, IncomeOnlyClass.DivisionCode, IncomeOnlyClass.ProductCode,
                                                                    IncomeOnlyClass.JobNumber, IncomeOnlyClass.JobComponentNumber, IncomeOnlyClass.SalesClassCode, IncomeOnlyClass.InvoiceDate,
                                                                    0, 0, IncomeOnlyClass.TaxCommission, IncomeOnlyClass.TaxCommissionOnly, "", IncomeOnlyClass.NonBillable)

                                                    UpdateSalesTax(IncomeOnlyClass)

                                                    CalculateLineItem(IncomeOnlyClass, BillingSystem.QtyRateAmount.Amount)

                                                    IncomeOnlyClass.FillIncomeOnlyEntity(NewIncomeOnly)

                                                    NewIncomeOnly.SequenceNumber = Nothing

                                                    If ApplyTaxUponBilling Then

                                                        NewIncomeOnly.TaxCode = Nothing

                                                    End If

                                                    NewIncomeOnly.BillHoldFlag = Nothing
                                                    NewIncomeOnly.ARInvoiceNumber = Nothing
                                                    NewIncomeOnly.ARInvoiceSequence = Nothing
                                                    NewIncomeOnly.ARType = Nothing
                                                    NewIncomeOnly.BillingUser = Nothing
                                                    'tax pct fields already handled
                                                    NewIncomeOnly.AdjusterComments = Nothing
                                                    NewIncomeOnly.GeneralLedgerBilling = Nothing
                                                    NewIncomeOnly.GeneralLedgerSales = Nothing
                                                    NewIncomeOnly.GeneralLedgerState = Nothing
                                                    NewIncomeOnly.GeneralLedgerCounty = Nothing
                                                    NewIncomeOnly.GeneralLedgerCity = Nothing
                                                    NewIncomeOnly.GeneralLedgerAccountSales = Nothing
                                                    NewIncomeOnly.GeneralLedgerAccountState = Nothing
                                                    NewIncomeOnly.GeneralLedgerAccountCounty = Nothing
                                                    NewIncomeOnly.GeneralLedgerAccountCity = Nothing
                                                    'NewIncomeOnly.AdvanceBillFlag  handled on Insert
                                                    NewIncomeOnly.DepartmentTeamCode = Nothing
                                                    'tax amt fields already handled
                                                    NewIncomeOnly.IsModified = Nothing
                                                    NewIncomeOnly.ModifiedBy = _Session.UserCode
                                                    NewIncomeOnly.ModifiedDate = System.DateTime.Today
                                                    NewIncomeOnly.DeleteFlag = Nothing
                                                    NewIncomeOnly.DeletedBy = Nothing
                                                    NewIncomeOnly.DeletedDate = Nothing
                                                    NewIncomeOnly.PostPeriod = Nothing
                                                    NewIncomeOnly.AdvanceBillID = Nothing
                                                    NewIncomeOnly.CampaignUpdatedInvoiceDate = Nothing
                                                    NewIncomeOnly.CampaignUpdatedPostPeriod = Nothing
                                                    NewIncomeOnly.TransferFromJob = Nothing
                                                    NewIncomeOnly.TransferFromJobComponent = Nothing
                                                    NewIncomeOnly.TransferFromFunction = Nothing
                                                    NewIncomeOnly.TransferFromIncomeOnlyID = Nothing
                                                    NewIncomeOnly.TransferFromSequenceNumber = Nothing
                                                    NewIncomeOnly.TransferAdjustedUser = Nothing
                                                    NewIncomeOnly.TransferAdjustedDate = Nothing
                                                    NewIncomeOnly.IsArchived = Nothing
                                                    NewIncomeOnly.BillingApprovalID = Nothing
                                                    NewIncomeOnly.BillingCommandCenterID = Nothing

                                                    If AdvantageFramework.Database.Procedures.IncomeOnly.Insert(DbContext, NewIncomeOnly) Then

                                                        Saved = True

                                                        SqlParameterInvoiceDate = New System.Data.SqlClient.SqlParameter("@IO_INV_DATE", System.Data.SqlDbType.SmallDateTime)
                                                        SqlParameterID = New System.Data.SqlClient.SqlParameter("@IO_ID", System.Data.SqlDbType.Int)

                                                        SqlParameterInvoiceDate.Value = NewIncomeOnly.InvoiceDate.Value
                                                        SqlParameterID.Value = NewIncomeOnly.ID

                                                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.INCOME_ONLY SET IO_INV_DATE = @IO_INV_DATE WHERE IO_ID = @IO_ID", SqlParameterInvoiceDate, SqlParameterID)

                                                    End If

                                                End If

                                            Else

                                                IncomeOnlyClass.FillIncomeOnlyEntity(IncomeOnly)

                                                IncomeOnly.ModifiedBy = _Session.UserCode
                                                IncomeOnly.ModifiedDate = System.DateTime.Today

                                                If AdvantageFramework.Database.Procedures.IncomeOnly.Update(DbContext, IncomeOnly) Then

                                                    Saved = True

                                                End If

                                            End If

                                        End If

                                    Else

                                        DataGridViewForm_Details.RemoveFromModifiedRows(IncomeOnlyClass)

                                        RefreshIncomeOnlyClass(DbContext, IncomeOnlyClass, IncomeOnly)

                                        SelectedForBilling = True

                                    End If

                                End If

                            Next

                        End Using

                    End If

                    If SelectedForBilling = True Then

                        If ModifiedIncomeOnlyList.Count > 1 Then

                            ErrorMessage = "One or more records are selected for billing and cannot be modified."

                        Else

                            ErrorMessage = "Record is selected for billing and cannot be modified."

                        End If

                    End If

                Else

                    ErrorMessage = "Please fix the invalid rows before saving."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            Finally
                SaveIncomeOnlyTab = Saved
            End Try

        End Function
        Private Function SaveContractsTab(ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Saved As Boolean = False

            Try

                If _UpdateAllowed Then

                    Saved = ServiceFeeContractControlContracts_Contracts.Save(ErrorMessage)

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            Finally
                SaveContractsTab = Saved
            End Try

        End Function
        Private Sub BackFillContractData()

            'objects
            Dim JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee = Nothing
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim JobServiceFeeID As Integer = Nothing
            Dim ReloadJobComp As Boolean = False
            Dim ReloadDivision As Boolean = False
            Dim ReloadProduct As Boolean = False

            If SearchableComboBoxForm_Contracts.HasASelectedValue Then

                If SearchableComboBoxForm_Job.HasASelectedValue = False OrElse SearchableComboBoxForm_Component.HasASelectedValue = False OrElse SearchableComboBoxForm_Function.HasASelectedValue = False Then

                    JobServiceFeeID = SearchableComboBoxForm_Contracts.GetSelectedValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobServiceFee = AdvantageFramework.Database.Procedures.JobServiceFee.LoadByID(DbContext, JobServiceFeeID)

                        If JobServiceFee IsNot Nothing Then

                            JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobServiceFee.JobNumber, JobServiceFee.JobComponentNumber)

                            Try

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    If SearchableComboBoxForm_Job.GetSelectedValue() <> JobComponentView.JobNumber Then

                                        LoadJobSource(DbContext, JobComponentView.JobNumber, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode, False)

                                        SearchableComboBoxForm_Job.SelectedValue = JobComponentView.JobNumber

                                        ReloadJobComp = True

                                    End If

                                    If ReloadJobComp = True OrElse SearchableComboBoxForm_Component.GetSelectedValue() <> JobComponentView.JobComponentNumber Then

                                        LoadJobCompSource(DbContext, JobComponentView.JobNumber, JobComponentView.JobComponentNumber, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode, False)

                                        SearchableComboBoxForm_Component.SelectedValue = JobComponentView.JobComponentNumber

                                    End If

                                    If SearchableComboBoxForm_Client.GetSelectedValue() <> JobComponentView.ClientCode Then

                                        LoadClientSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, False)

                                        SearchableComboBoxForm_Client.SelectedValue = JobComponentView.ClientCode

                                        ReloadDivision = True

                                    End If

                                    If ReloadDivision = True OrElse SearchableComboBoxForm_Division.GetSelectedValue() <> JobComponentView.DivisionCode Then

                                        LoadDivisionSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, JobComponentView.DivisionCode, False)

                                        SearchableComboBoxForm_Division.SelectedValue = JobComponentView.DivisionCode

                                        ReloadProduct = True

                                    End If

                                    If ReloadProduct = True OrElse SearchableComboBoxForm_Product.GetSelectedValue() <> JobComponentView.ProductCode Then

                                        LoadProductSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode, False)

                                        SearchableComboBoxForm_Product.SelectedValue = JobComponentView.ProductCode

                                    End If

                                    If SearchableComboBoxForm_Function.GetSelectedValue() <> JobServiceFee.FunctionCode Then

                                        LoadFunctionSource(DbContext)

                                        SearchableComboBoxForm_Function.SelectedValue = JobServiceFee.FunctionCode

                                    End If

                                End Using

                            Catch ex As Exception

                            End Try

                        End If

                    End Using

                    SearchableComboBoxForm_Contracts.SelectedValue = JobServiceFeeID

                End If

            End If

        End Sub
        Private Sub AddEventHandlers()

            RemoveEventHandlers()

            'AddHandler CdpJobCompFilterForm_Filter.ClientChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ClientChangedEvent
            'AddHandler CdpJobCompFilterForm_Filter.DivisionChangedEvent, AddressOf CdpJobCompFilterForm_Filter_DivisionChangedEvent
            'AddHandler CdpJobCompFilterForm_Filter.ProductChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ProductChangedEvent
            'AddHandler CdpJobCompFilterForm_Filter.JobChangedEvent, AddressOf CdpJobCompFilterForm_Filter_JobChangedEvent
            'AddHandler CdpJobCompFilterForm_Filter.ComponentChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ComponentChangedEvent

            'AddHandler SearchableComboBoxForm_Contracts.EditValueChanged, AddressOf SearchableComboBoxForm_Contracts_EditValueChanged
            'AddHandler SearchableComboBoxForm_Function.EditValueChanged, AddressOf SearchableComboBoxForm_Function_EditValueChanged
            'AddHandler DateTimePickerForm_InvoiceDate.ValueObjectChanged, AddressOf DateTimePickerForm_InvoiceDate_ValueObjectChanged
            'AddHandler TextBoxForm_ReferenceCode.Validating, AddressOf TextBoxForm_ReferenceCode_Validating

        End Sub
        Private Sub RemoveEventHandlers()

            'RemoveHandler CdpJobCompFilterForm_Filter.ClientChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ClientChangedEvent
            'RemoveHandler CdpJobCompFilterForm_Filter.DivisionChangedEvent, AddressOf CdpJobCompFilterForm_Filter_DivisionChangedEvent
            'RemoveHandler CdpJobCompFilterForm_Filter.ProductChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ProductChangedEvent
            'RemoveHandler CdpJobCompFilterForm_Filter.JobChangedEvent, AddressOf CdpJobCompFilterForm_Filter_JobChangedEvent
            'RemoveHandler CdpJobCompFilterForm_Filter.ComponentChangedEvent, AddressOf CdpJobCompFilterForm_Filter_ComponentChangedEvent

            'RemoveHandler SearchableComboBoxForm_Contracts.EditValueChanged, AddressOf SearchableComboBoxForm_Contracts_EditValueChanged
            'RemoveHandler SearchableComboBoxForm_Function.EditValueChanged, AddressOf SearchableComboBoxForm_Function_EditValueChanged
            'RemoveHandler DateTimePickerForm_InvoiceDate.ValueObjectChanged, AddressOf DateTimePickerForm_InvoiceDate_ValueObjectChanged
            'RemoveHandler TextBoxForm_ReferenceCode.Validating, AddressOf TextBoxForm_ReferenceCode_Validating

        End Sub
        Private Sub HideOrShowContractsTab()

            TabControlForm_IncomeOnly.SuspendLayout()
            PanelIncomeOnly_IncomeOnly.SuspendLayout()

            If String.IsNullOrWhiteSpace(_ClientCode) = False OrElse _JobNumber.GetValueOrDefault(0) > 0 Then

                TabItemIncomeOnly_ContractsTab.Visible = _AllowedInContracts
                TabControlForm_IncomeOnly.TabsVisible = _AllowedInContracts

            Else

                TabItemIncomeOnly_ContractsTab.Visible = False
                TabControlForm_IncomeOnly.TabsVisible = False

            End If

            If TabControlForm_IncomeOnly.TabsVisible = True Then

                PanelIncomeOnly_IncomeOnly.Dock = Windows.Forms.DockStyle.None
                PanelIncomeOnly_IncomeOnly.Location = New System.Drawing.Point(4, 4)
                PanelIncomeOnly_IncomeOnly.Size = New System.Drawing.Size(TabControlPanelIncomeOnly_IncomeOnly.Size.Width - 8, TabControlPanelIncomeOnly_IncomeOnly.Size.Height - 8)
                PanelIncomeOnly_IncomeOnly.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                                            Or System.Windows.Forms.AnchorStyles.Left) _
                                                            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

            Else

                PanelIncomeOnly_IncomeOnly.Dock = Windows.Forms.DockStyle.Fill

            End If

            PanelIncomeOnly_IncomeOnly.ResumeLayout()
            TabControlForm_IncomeOnly.ResumeLayout()

        End Sub
        Private Sub RefreshIncomeOnlyClass(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                           ByRef IncomeOnlyClass As AdvantageFramework.IncomeOnly.Classes.IncomeOnly,
                                           ByVal IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly)

            'objects
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

            If IncomeOnlyClass IsNot Nothing AndAlso IncomeOnly IsNot Nothing Then

                IncomeOnlyClass.ID = IncomeOnly.ID
                IncomeOnlyClass.SequenceNumber = IncomeOnly.SequenceNumber

                If IncomeOnlyClass.JobNumber.GetValueOrDefault(0) <> IncomeOnly.JobNumber OrElse
                   IncomeOnlyClass.JobComponentNumber.GetValueOrDefault(0) <> IncomeOnly.JobComponentNumber Then

                    JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, IncomeOnly.JobNumber, IncomeOnly.JobComponentNumber)
                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobComponentView.JobNumber)

                    IncomeOnlyClass.SalesClassCode = Job.SalesClassCode
                    IncomeOnlyClass.ClientCode = JobComponentView.ClientCode
                    IncomeOnlyClass.ClientName = JobComponentView.ClientName
                    IncomeOnlyClass.DivisionCode = JobComponentView.DivisionCode
                    IncomeOnlyClass.DivisionName = JobComponentView.DivisionName
                    IncomeOnlyClass.ProductCode = JobComponentView.ProductCode
                    IncomeOnlyClass.ProductName = JobComponentView.ProductDescription
                    IncomeOnlyClass.JobDescription = JobComponentView.JobDescription
                    IncomeOnlyClass.JobComponentDescription = JobComponentView.JobComponentDescription
                    IncomeOnlyClass.JobComponentID = JobComponentView.ID

                End If

                If IncomeOnlyClass.FunctionCode <> IncomeOnly.FunctionCode Then

                    [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, IncomeOnly.FunctionCode)

                    IncomeOnlyClass.FunctionDescription = [Function].Description

                End If

                IncomeOnlyClass.JobNumber = IncomeOnly.JobNumber
                IncomeOnlyClass.JobComponentNumber = IncomeOnly.JobComponentNumber
                IncomeOnlyClass.OrderNumber = IncomeOnly.OrderNumber
                IncomeOnlyClass.OrderLineNumber = IncomeOnly.LineNumber
                IncomeOnlyClass.FunctionCode = IncomeOnly.FunctionCode
                IncomeOnlyClass.TaxCode = IncomeOnly.TaxCode
                IncomeOnlyClass.InvoiceDate = IncomeOnly.InvoiceDate
                IncomeOnlyClass.Quantity = IncomeOnly.Quantity
                IncomeOnlyClass.Rate = IncomeOnly.Rate
                IncomeOnlyClass.Amount = IncomeOnly.Amount
                IncomeOnlyClass.CommissionPercent = IncomeOnly.CommissionPercent
                IncomeOnlyClass.MarkupAmount = IncomeOnly.ExtendedMarkupAmount
                IncomeOnlyClass.CityTaxAmount = IncomeOnly.ExtendedCityResale
                IncomeOnlyClass.CountyTaxAmount = IncomeOnly.ExtendedCountyResale
                IncomeOnlyClass.StateTaxAmount = IncomeOnly.ExtendedStateResale
                IncomeOnlyClass.Description = IncomeOnly.Description
                IncomeOnlyClass.ReferenceNumber = IncomeOnly.ReferenceNumber
                IncomeOnlyClass.Comment = IncomeOnly.Comment
                IncomeOnlyClass.BillingUser = IncomeOnly.BillingUser
                IncomeOnlyClass.TaxStatePercent = IncomeOnly.TaxStatePercent
                IncomeOnlyClass.TaxCityPercent = IncomeOnly.TaxCityPercent
                IncomeOnlyClass.TaxCountyPercent = IncomeOnly.TaxCountyPercent
                IncomeOnlyClass.TaxCommission = IncomeOnly.TaxCommission
                IncomeOnlyClass.TaxCommissionOnly = IncomeOnly.TaxCommissionOnly
                IncomeOnlyClass.TaxResale = IncomeOnly.TaxResale
                IncomeOnlyClass.IsServiceFee = CBool(IncomeOnly.FeeInvoice.GetValueOrDefault(0))
                IncomeOnlyClass.IsBilled = IncomeOnly.ARInvoiceNumber.HasValue
                IncomeOnlyClass.NonBillable = IncomeOnly.NonBillable
                IncomeOnlyClass.IsRevised = False
                IncomeOnlyClass.JobServiceFeeID = IncomeOnly.JobServiceFeeID

            End If

        End Sub
        Private Function GetFunctionDepartmentTeamCode(ByVal FunctionCode As String) As String

            'objects
            Dim DepartmentTeamCode As String = Nothing

            If String.IsNullOrWhiteSpace(FunctionCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        DepartmentTeamCode = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode).DepartmentTeamCode

                    Catch ex As Exception
                        DepartmentTeamCode = Nothing
                    End Try

                End Using

            End If

            GetFunctionDepartmentTeamCode = DepartmentTeamCode

        End Function
        Private Function HaveAnySelectedRecordsBeenBilled()

            'objects
            Dim BeenBilled As Boolean = False

            If DataGridViewForm_Details.HasASelectedRow Then

                Try

                    If (From IncomeOnly In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()
                        Where IncomeOnly.IsBilled = True OrElse
                              IncomeOnly.EverBilled = True
                        Select IncomeOnly).Any = True Then

                        BeenBilled = True

                    End If

                Catch ex As Exception
                    BeenBilled = False
                End Try

            End If

            HaveAnySelectedRecordsBeenBilled = BeenBilled

        End Function
        Private Sub LoadClientSource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ClientCode As String, ByVal MinimalDataSource As Boolean)

            'objects
            Dim DataSource As IEnumerable = Nothing

            If MinimalDataSource AndAlso String.IsNullOrWhiteSpace(ClientCode) = False Then

                DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                             Where Entity.IsActive = 1 AndAlso
                                   Entity.Code = ClientCode
                             Select Entity

            Else

                DataSource = From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                             Where Entity.IsActive = 1
                             Select Entity

            End If

            SearchableComboBoxForm_Client.DataSource = DataSource

        End Sub
        Private Sub LoadClientSource(ByVal ClientCode As String, ByVal MinimalDataSource As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadClientSource(DbContext, SecurityDbContext, ClientCode, MinimalDataSource)

                End Using

            End Using

        End Sub
        Private Sub LoadDivisionSource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                       ByVal ClientCode As String, ByVal DivisionCode As String, ByVal MinimalDataSource As Boolean)

            'objects
            Dim DoQuery As Boolean = True
            Dim DataSource As IEnumerable = Nothing

            If MinimalDataSource AndAlso String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                SearchableComboBoxForm_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                             Where Entity.IsActive = 1 AndAlso
                                                                   Entity.ClientCode = ClientCode AndAlso
                                                                   Entity.DivisionCode = DivisionCode
                                                             Select Entity

                SearchableComboBoxForm_Division.Tag = Nothing

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    If SearchableComboBoxForm_Division.Tag IsNot Nothing Then

                        If SearchableComboBoxForm_Division.Tag.ClientCode = ClientCode Then

                            DoQuery = False

                        End If

                    End If

                Catch ex As Exception
                    DoQuery = True
                End Try

                If DoQuery Then

                    SearchableComboBoxForm_Division.DataSource = From Entity In AdvantageFramework.Database.Procedures.DivisionView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                                 Where Entity.IsActive = 1 AndAlso
                                                                       Entity.ClientCode = ClientCode
                                                                 Select Entity

                    SearchableComboBoxForm_Division.Tag = New With {.ClientCode = ClientCode}

                End If

            Else

                SearchableComboBoxForm_Division.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.DivisionView)
                SearchableComboBoxForm_Division.Tag = Nothing

            End If

        End Sub
        Private Sub LoadDivisionSource(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal MinimalDataSource As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadDivisionSource(DbContext, SecurityDbContext, ClientCode, DivisionCode, MinimalDataSource)

                End Using

            End Using

        End Sub
        Private Sub LoadProductSource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal SecurityDbContext As AdvantageFramework.Security.Database.DbContext,
                                      ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            'objects
            Dim DoQuery As Boolean = True

            If MinimalDataSource AndAlso String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                SearchableComboBoxForm_Product.DataSource = From Item In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True).ToList
                                                            Where Item.ClientCode = ClientCode AndAlso
                                                                  Item.DivisionCode = DivisionCode AndAlso
                                                                  Item.ProductCode = ProductCode
                                                            Select Item

                SearchableComboBoxForm_Product.Tag = Nothing

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                Try

                    If SearchableComboBoxForm_Product.Tag IsNot Nothing Then

                        If SearchableComboBoxForm_Product.Tag.ClientCode = ClientCode AndAlso
                            SearchableComboBoxForm_Product.Tag.DivisionCode = DivisionCode Then

                            DoQuery = False

                        End If

                    End If

                Catch ex As Exception
                    DoQuery = True
                End Try

                If DoQuery Then

                    SearchableComboBoxForm_Product.DataSource = From Item In AdvantageFramework.Database.Procedures.ProductView.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True).ToList
                                                                Where Item.ClientCode = ClientCode AndAlso
                                                                      Item.DivisionCode = DivisionCode
                                                                Select Item

                    SearchableComboBoxForm_Product.Tag = New With {.ClientCode = ClientCode,
                                                                   .DivisionCode = DivisionCode}

                End If

            Else

                SearchableComboBoxForm_Product.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.ProductView)
                SearchableComboBoxForm_Product.Tag = Nothing

            End If

        End Sub
        Private Sub LoadProductSource(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadProductSource(DbContext, SecurityDbContext, ClientCode, DivisionCode, ProductCode, MinimalDataSource)

                End Using

            End Using

        End Sub
        Private Sub LoadJobSource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            'objects
            Dim DoQuery As Boolean = True

            If MinimalDataSource AndAlso JobNumber.GetValueOrDefault(0) > 0 Then

                SearchableComboBoxForm_Job.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, _Session.UserCode, JobNumber:=JobNumber)

                SearchableComboBoxForm_Job.Tag = Nothing

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                If SearchableComboBoxForm_Job.Tag IsNot Nothing Then

                    Try

                        If SearchableComboBoxForm_Job.Tag.ClientCode = ClientCode AndAlso
                            SearchableComboBoxForm_Job.Tag.DivisionCode = DivisionCode AndAlso
                            SearchableComboBoxForm_Job.Tag.ProductCode = ProductCode Then

                            DoQuery = False

                        End If

                    Catch ex As Exception
                        DoQuery = True
                    End Try

                End If

                If DoQuery Then

                    SearchableComboBoxForm_Job.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode)

                    SearchableComboBoxForm_Job.Tag = New With {.ClientCode = ClientCode,
                                                               .DivisionCode = DivisionCode,
                                                               .ProductCode = ProductCode}

                End If

            Else

                SearchableComboBoxForm_Job.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, _Session.UserCode)
                SearchableComboBoxForm_Job.Tag = Nothing

            End If

        End Sub
        Private Sub LoadJobSource(ByVal JobNumber As Integer?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadJobSource(DbContext, JobNumber, ClientCode, DivisionCode, ProductCode, MinimalDataSource)

            End Using

        End Sub
        Private Sub LoadJobCompSource(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer?, ByVal JobCompNumber As Short?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            'objects
            Dim DoQuery As Boolean = True

            If MinimalDataSource AndAlso JobNumber.GetValueOrDefault(0) > 0 AndAlso JobCompNumber.GetValueOrDefault(0) > 0 Then

                SearchableComboBoxForm_Component.DataSource = From Item In AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode)
                                                              Where Item.JobNumber = JobNumber AndAlso
                                                                    Item.JobComponentNumber = JobCompNumber
                                                              Select Item

                SearchableComboBoxForm_Component.Tag = Nothing

            ElseIf JobNumber.GetValueOrDefault(0) > 0 Then

                Try

                    If SearchableComboBoxForm_Component.Tag IsNot Nothing Then

                        If SearchableComboBoxForm_Component.Tag.JobNumber = JobNumber.GetValueOrDefault(0) Then

                            DoQuery = False

                        End If

                    End If

                Catch ex As Exception
                    DoQuery = True
                End Try

                If DoQuery = True Then

                    SearchableComboBoxForm_Component.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode, Nothing, Nothing, Nothing, JobNumber.GetValueOrDefault(0))

                    SearchableComboBoxForm_Component.Tag = New With {.JobNumber = JobNumber.GetValueOrDefault(0),
                                                                     .ClientCode = Nothing,
                                                                     .DivisionCode = Nothing,
                                                                     .ProductCode = Nothing}

                End If

            ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                Try

                    If SearchableComboBoxForm_Component.Tag IsNot Nothing Then

                        If SearchableComboBoxForm_Component.Tag.ClientCode = ClientCode AndAlso
                            SearchableComboBoxForm_Component.Tag.DivisionCode = DivisionCode AndAlso
                            SearchableComboBoxForm_Component.Tag.ProductCode = ProductCode Then

                            DoQuery = False

                        End If

                    End If

                Catch ex As Exception
                    DoQuery = True
                End Try

                If DoQuery Then

                    SearchableComboBoxForm_Component.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode)

                    SearchableComboBoxForm_Component.Tag = New With {.JobNumber = Nothing,
                                                                                           .ClientCode = ClientCode,
                                                                                           .DivisionCode = DivisionCode,
                                                                                           .ProductCode = ProductCode}

                End If

            Else

                SearchableComboBoxForm_Component.DataSource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode)

                SearchableComboBoxForm_Component.Tag = Nothing

            End If

        End Sub
        Private Sub LoadJobCompSource(ByVal JobNumber As Integer?, ByVal JobCompNumber As Short?, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal MinimalDataSource As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadJobCompSource(DbContext, JobNumber, JobCompNumber, ClientCode, DivisionCode, ProductCode, MinimalDataSource)

            End Using

        End Sub
        Private Sub LoadFunctionSource(ByVal DbContext As AdvantageFramework.Database.DbContext)

            If _LoadedFunctionFullSource = False Then

                SearchableComboBoxForm_Function.DataSource = From Entity In AdvantageFramework.Database.Procedures.FunctionView.LoadAllActive(DbContext)
                                                             Where Entity.Type = "I"
                                                             Select Entity

                _LoadedFunctionFullSource = True

            End If

        End Sub
        Private Sub LoadFunctionSource()

            If _LoadedFunctionFullSource = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    LoadFunctionSource(DbContext)

                End Using

            End If

        End Sub
        Private Sub CheckCDPOfficeSecurityInFilters(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            'objects
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If Not SearchableComboBoxForm_Client.HasASelectedValue Then

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                If Client IsNot Nothing Then

                    SearchableComboBoxForm_Client.AddComboItemToExistingDataSource(Client.ToString(), Client.Code, False)
                    SearchableComboBoxForm_Client.SelectedValue = Client.Code

                End If

            End If

            If Not SearchableComboBoxForm_Division.HasASelectedValue Then

                Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, ClientCode, DivisionCode)

                If Division IsNot Nothing Then

                    SearchableComboBoxForm_Division.AddComboItemToExistingDataSource(Division.ToString(), Division.Code, False)
                    SearchableComboBoxForm_Division.SelectedValue = Division.Code

                End If

            End If

            If Not SearchableComboBoxForm_Product.HasASelectedValue Then

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                If Product IsNot Nothing Then

                    SearchableComboBoxForm_Product.AddComboItemToExistingDataSource(Product.ToString(), Product.Code, False)
                    SearchableComboBoxForm_Product.SelectedValue = Product.Code

                End If

            End If

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            If Me.IsIncomeOnlyTabSeleted Then

                Saved = SaveIncomeOnlyTab(ErrorMessage)

            ElseIf Me.IsContractsTabSeleted Then

                Saved = SaveContractsTab(ErrorMessage)

            End If

            If Not Saved Then

                If String.IsNullOrWhiteSpace(ErrorMessage) Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            Else

                LoadTab(Nothing)

            End If

            Save = Saved

        End Function
        Public Function Copy() As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim IDsToCopy As Integer() = Nothing
            Dim NewIDs As Integer() = Nothing
            Dim IncomeOnlyClass As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing

            Try

                If _AddAllowed Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        IncomeOnlyClass = DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)().First

                        IDsToCopy = (From Item In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()
                                     Select Item.ID).ToArray

                        If IDsToCopy IsNot Nothing AndAlso IDsToCopy.Count > 0 Then

                            AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                            NewIDs = AdvantageFramework.IncomeOnly.CopyIncomeOnlys(DbContext, _Session.UserCode, IncomeOnlyClass.JobNumber, IncomeOnlyClass.JobComponentNumber, Nothing, Nothing, Nothing, Nothing, Nothing, IDsToCopy, True)

                            If NewIDs IsNot Nothing AndAlso NewIDs.Count > 0 Then

                                Copied = True
                                AddIncomeOnlysToBatchList(NewIDs)

                            End If

                        End If

                    End Using

                    If Copied Then

                        LoadIncomeOnlyTab()

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                Copy = Copied

            End Try

        End Function
        Public Function CopyTo() As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobComponentList As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent) = Nothing
            Dim CopyFromIDs As Integer() = Nothing
            Dim NewIDs As Integer() = Nothing

            Try

                If AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.ShowFormDialog(FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.Mode.CopyTo, JobComponentList) = Windows.Forms.DialogResult.OK Then

                    If JobComponentList IsNot Nothing Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            CopyFromIDs = (From Item In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()
                                           Select Item.ID).ToArray

                            For Each JobComponent In JobComponentList

                                NewIDs = AdvantageFramework.IncomeOnly.CopyIncomeOnlys(DbContext, _Session.UserCode, JobComponent.JobNumber, JobComponent.JobComponentNumber, Nothing, Nothing, Nothing, Nothing, Nothing, CopyFromIDs)

                                If NewIDs IsNot Nothing AndAlso NewIDs.Count > 0 Then

                                    AddIncomeOnlysToBatchList(NewIDs)
                                    Copied = True

                                End If

                            Next

                        End Using

                        If Copied Then

                            LoadIncomeOnlyTab()

                        End If

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                CopyTo = Copied

            End Try

        End Function
        Public Function CopyFrom() As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim JobComponentList As IEnumerable(Of AdvantageFramework.IncomeOnly.Classes.JobComponent) = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Integer = Nothing
            Dim NewIDs As Integer() = Nothing

            Try

                If _JobNumber.HasValue Then

                    JobNumber = _JobNumber

                    If _JobComponentNumber.HasValue Then

                        JobComponentNumber = _JobComponentNumber

                    End If

                End If

                If AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.ShowFormDialog(FinanceAndAccounting.Presentation.IncomeOnlyCopyDialog.Mode.CopyFrom, JobComponentList, _ClientCode, _DivisionCode, _ProductCode, JobNumber, JobComponentNumber) = Windows.Forms.DialogResult.OK Then

                    If JobComponentList IsNot Nothing Then

                        AdvantageFramework.WinForm.Presentation.ShowWaitForm("Copying...")

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each JobComponent In JobComponentList

                                NewIDs = AdvantageFramework.IncomeOnly.CopyIncomeOnlys(DbContext, _Session.UserCode, JobNumber, JobComponentNumber, Nothing, Nothing, Nothing, JobComponent.JobNumber, JobComponent.JobComponentNumber, Nothing)

                                If NewIDs IsNot Nothing AndAlso NewIDs.Count > 0 Then

                                    Copied = True

                                    For Each NewID In NewIDs

                                        AddIncomeOnlyToBatchList(NewID)

                                    Next

                                End If

                            Next

                        End Using

                        If Copied Then

                            LoadIncomeOnlyTab()

                        End If

                    End If

                End If

            Catch ex As Exception
                Copied = False
            Finally

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                CopyFrom = Copied

            End Try

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim SelectedForBilling As Boolean = False
            Dim BilledRecordAlreadyDeleted As Boolean = False
            Dim DisplayMessage As String = Nothing
            Dim ContinueDelete As Boolean = True

            Try

                If _UpdateAllowed Then

                    If DataGridViewForm_Details.HasASelectedRow Then

                        If HaveAnySelectedRecordsBeenBilled() Then

                            DisplayMessage = "You are about to delete billed record(s). If you continue, the amount will be set to 0.00 but cannot be permanently deleted. Are you sure you want to continue?"

                        Else

                            DisplayMessage = "Are you sure you want to delete?"

                        End If

                        If AdvantageFramework.Navigation.ShowMessageBox(DisplayMessage, MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each IncomeOnlyClass In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)().ToList

                                    ContinueDelete = True

                                    IncomeOnly = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DbContext, IncomeOnlyClass.ID, IncomeOnlyClass.SequenceNumber)

                                    If IncomeOnly IsNot Nothing Then

                                        If String.IsNullOrWhiteSpace(IncomeOnly.BillingUser) = False Then

                                            DataGridViewForm_Details.RemoveFromModifiedRows(IncomeOnlyClass)

                                            RefreshIncomeOnlyClass(DbContext, IncomeOnlyClass, IncomeOnly)

                                            SelectedForBilling = True

                                        Else

                                            If IncomeOnly.Amount.GetValueOrDefault(0) = 0 AndAlso IncomeOnlyClass.EverBilled = True Then

                                                BilledRecordAlreadyDeleted = True

                                                ContinueDelete = False

                                            End If

                                            If ContinueDelete Then

                                                If AdvantageFramework.Database.Procedures.IncomeOnly.Delete(DbContext, IncomeOnly) Then

                                                    AddIncomeOnlyToBatchList(IncomeOnly)
                                                    Deleted = True

                                                    If IncomeOnlyClass.EverBilled = False Then

                                                        DataGridViewForm_Details.CurrentView.DeleteFromDataSource(IncomeOnlyClass)

                                                    Else

                                                        IncomeOnlyClass.SequenceNumber = (From IOEntity In AdvantageFramework.Database.Procedures.IncomeOnly.LoadByID(DbContext, IncomeOnly.ID)
                                                                                          Select IOEntity.SequenceNumber).Max

                                                        IncomeOnlyClass.Quantity = 0
                                                        IncomeOnlyClass.Amount = 0
                                                        IncomeOnlyClass.CityTaxAmount = 0
                                                        IncomeOnlyClass.StateTaxAmount = 0
                                                        IncomeOnlyClass.CountyTaxAmount = 0
                                                        IncomeOnlyClass.MarkupAmount = 0
                                                        IncomeOnlyClass.IsBilled = False

                                                    End If

                                                End If

                                            End If

                                        End If

                                    End If

                                Next

                            End Using

                        End If

                    End If

                End If

                If BilledRecordAlreadyDeleted Then

                    ErrorMessage = "One or more selected records have been billed or partially billed and cannot be permanently deleted."

                End If

                If SelectedForBilling Then

                    ErrorMessage &= "One or more selected records are selected for billing and cannot be deleted."

                End If

                DataGridViewForm_Details.CurrentView.RefreshData()

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Sub PrintBatch()

            'objects
            Dim ParameterList As Generic.Dictionary(Of String, Object) = Nothing
            Dim BatchIDs As Integer() = Nothing
            Dim UserCode As String = Nothing
            Dim [From] As Date = Nothing
            Dim [To] As Date = Nothing

            Try

                If _PrintAllowed Then

                    If AdvantageFramework.FinanceAndAccounting.Presentation.IncomeOnlyBatchReportDialog.ShowFormDialog([From], [To], UserCode) = Windows.Forms.DialogResult.OK Then

                        ParameterList = New Generic.Dictionary(Of String, Object)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ParameterList("DataSource") = AdvantageFramework.IncomeOnly.LoadBatchReport(DbContext, [From], [To], UserCode)

                        End Using

                        ParameterList("ForUser") = UserCode

                        AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(_Session, Reporting.ReportTypes.IncomeOnlyBatchSummaryReport, ParameterList, Nothing, Nothing, Nothing, Nothing)

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Public Function LoadControl(Optional ByVal ClientCode As String = Nothing, Optional ByVal DivisionCode As String = Nothing, Optional ByRef ProductCode As String = Nothing,
                                    Optional ByVal JobNumber As Integer? = Nothing, Optional ByVal JobComponentNumber As Integer? = Nothing) As Boolean

            'objects
            Dim Loaded As Boolean = True

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode
            _JobNumber = JobNumber.GetValueOrDefault(0)
            _JobComponentNumber = JobComponentNumber.GetValueOrDefault(0)

            SearchableComboBoxForm_Client.SecurityEnabled = String.IsNullOrWhiteSpace(_ClientCode)
            SearchableComboBoxForm_Division.SecurityEnabled = String.IsNullOrWhiteSpace(_DivisionCode)
            SearchableComboBoxForm_Product.SecurityEnabled = String.IsNullOrWhiteSpace(_ProductCode)
            SearchableComboBoxForm_Job.SecurityEnabled = _JobNumber.HasValue = False OrElse _JobNumber.Value = 0
            SearchableComboBoxForm_Component.SecurityEnabled = _JobComponentNumber.HasValue = False OrElse _JobComponentNumber.Value = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrWhiteSpace(ClientCode) = False Then

                        LoadClientSource(DbContext, SecurityDbContext, ClientCode, True)

                        If String.IsNullOrWhiteSpace(DivisionCode) = False Then

                            LoadDivisionSource(DbContext, SecurityDbContext, ClientCode, DivisionCode, True)

                            If String.IsNullOrWhiteSpace(ProductCode) = False Then

                                LoadProductSource(DbContext, SecurityDbContext, ClientCode, DivisionCode, ProductCode, True)

                            End If

                        End If

                    End If

                    If JobNumber.GetValueOrDefault(0) > 0 Then

                        LoadJobSource(DbContext, JobNumber, ClientCode, DivisionCode, ProductCode, True)

                        If JobComponentNumber.GetValueOrDefault(0) > 0 Then

                            LoadJobCompSource(DbContext, JobNumber, JobComponentNumber, ClientCode, DivisionCode, ProductCode, True)

                        End If

                    End If

                End Using

            End Using

            'TP CdpJobCompFilterForm_Filter.InitializeDataControls()

            'TP CdpJobCompFilterForm_Filter.SetInitialValues(_ClientCode, _DivisionCode, _ProductCode, _JobNumber, _JobComponentNumber)

            'TP CdpJobCompFilterForm_Filter.SelectSingleItemDataSource()

            _FilterValueChanged = True

            Try

                SearchableComboBoxForm_Client.SelectedValue = ClientCode
                SearchableComboBoxForm_Division.SelectedValue = DivisionCode
                SearchableComboBoxForm_Product.SelectedValue = ProductCode
                SearchableComboBoxForm_Job.SelectedValue = JobNumber
                SearchableComboBoxForm_Component.SelectedValue = JobComponentNumber

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    CheckCDPOfficeSecurityInFilters(DbContext, ClientCode, DivisionCode, ProductCode)

                End Using

                LoadContractsLookup()

            Catch ex As Exception

            End Try

            _FilterValueChanged = False

            HideOrShowContractsTab()

            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString)
            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString)
            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString)
            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString)
            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString)

            LoadTab(Nothing)

            AddEventHandlers()

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _ControlHasLoaded = True ' prevents selected tab events from firing prior to first load

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            RemoveEventHandlers()

            _ClientFilter = SearchableComboBoxForm_Client.GetSelectedValue
            _DivisionFilter = SearchableComboBoxForm_Division.GetSelectedValue
            _ProductFilter = SearchableComboBoxForm_Product.GetSelectedValue
            _JobFilter = SearchableComboBoxForm_Job.GetSelectedValue

            Try

                _JobComponentFilter = CInt(SearchableComboBoxForm_Component.GetSelectedValue)

            Catch ex As Exception
                _JobComponentFilter = Nothing
            End Try

            If _JobComponentFilter.GetValueOrDefault(0) = 0 Then

                _JobComponentFilter = Nothing

            End If

            _ContractsFilter = SearchableComboBoxForm_Contracts.GetSelectedValue
            _FunctionFilter = SearchableComboBoxForm_Function.GetSelectedValue
            _ReferenceCodeFilter = TextBoxForm_ReferenceCode.GetText
            _InvoiceDateFilter = DateTimePickerForm_InvoiceDate.ValueObject

            If DataGridViewForm_Details.CurrentView.ActiveFilterEnabled Then

                _LastFilter = DataGridViewForm_Details.CurrentView.AFActiveFilterString

            Else

                _LastFilter = Nothing

            End If

            _FilterValueChanged = True

            Try

                SearchableComboBoxForm_Client.SelectedValue = Nothing
                SearchableComboBoxForm_Division.SelectedValue = Nothing
                SearchableComboBoxForm_Product.SelectedValue = Nothing
                SearchableComboBoxForm_Job.SelectedValue = Nothing
                SearchableComboBoxForm_Component.SelectedValue = Nothing
                SearchableComboBoxForm_Contracts.SelectedValue = Nothing

            Catch ex As Exception

            End Try

            _FilterValueChanged = False

            SearchableComboBoxForm_Function.SelectedValue = Nothing
            TextBoxForm_ReferenceCode.Text = Nothing
            DateTimePickerForm_InvoiceDate.ValueObject = Nothing

            DataGridViewForm_Details.CurrentView.ActiveFilter.Clear()
            DataGridViewForm_Details.DataSource = Nothing

            ServiceFeeContractControlContracts_Contracts.ClearControl()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub ApplyLastFilter()

            If String.IsNullOrWhiteSpace(_ClientFilter) = False Then

                SearchableComboBoxForm_Client.SelectedValue = _ClientFilter

            End If

            If String.IsNullOrWhiteSpace(_DivisionFilter) = False Then

                SearchableComboBoxForm_Division.SelectedValue = _DivisionFilter

            End If

            If String.IsNullOrWhiteSpace(_ProductFilter) = False Then

                SearchableComboBoxForm_Product.SelectedValue = _ProductFilter

            End If

            If _JobFilter.GetValueOrDefault(0) > 0 Then

                SearchableComboBoxForm_Job.SelectedValue = _JobFilter

            End If

            If _JobComponentFilter.GetValueOrDefault(0) > 0 Then

                SearchableComboBoxForm_Component.SelectedValue = _JobComponentFilter

            End If

            If _ContractsFilter.GetValueOrDefault(0) > 0 Then

                SearchableComboBoxForm_Contracts.SelectedValue = _ContractsFilter

            End If

            If String.IsNullOrWhiteSpace(_FunctionFilter) = False Then

                SearchableComboBoxForm_Function.SelectedValue = _FunctionFilter

            End If

            If String.IsNullOrWhiteSpace(_ReferenceCodeFilter) = False Then

                TextBoxForm_ReferenceCode.Text = _ReferenceCodeFilter

            End If

            If _InvoiceDateFilter.HasValue Then

                DateTimePickerForm_InvoiceDate.ValueObject = _InvoiceDateFilter

            End If

            If String.IsNullOrWhiteSpace(_LastFilter) = False Then

                Try

                    DataGridViewForm_Details.CurrentView.AFActiveFilterString = _LastFilter

                Catch ex As Exception

                End Try

            End If

        End Sub
        Public Sub ViewContracts()

            AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode, _JobNumber, _JobComponentNumber)

        End Sub
        Public Function FlagAsServiceFee() As Boolean

            ''objects
            'Dim Flagged As Boolean = False
            'Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            'Dim IncomeOnlyClass As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing

            'Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            '    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            '        For Each IncomeOnlyClass In DataGridViewForm_Details.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.IncomeOnly.Classes.IncomeOnly)()

            '            IncomeOnly = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DataContext, IncomeOnlyClass.ID, IncomeOnlyClass.SequenceNumber)

            '            If IncomeOnly IsNot Nothing Then

            '                IncomeOnly.FeeInvoice = 1

            '                If AdvantageFramework.Database.Procedures.IncomeOnly.Update(DbContext, DataContext, IncomeOnly) Then

            '                    IncomeOnlyClass.IsServiceFee = True
            '                    Flagged = True

            '                End If

            '            End If

            '        Next

            '    End Using

            'End Using

            FlagAsServiceFee = False

        End Function
        Public Sub ResetFilters()

            If String.IsNullOrWhiteSpace(_ClientCode) Then

                SearchableComboBoxForm_Client.SelectedValue = Nothing

            End If

            If String.IsNullOrWhiteSpace(_DivisionCode) Then

                SearchableComboBoxForm_Division.SelectedValue = Nothing

            End If

            If String.IsNullOrWhiteSpace(_ProductCode) Then

                SearchableComboBoxForm_Product.SelectedValue = Nothing

            End If

            If _JobNumber.GetValueOrDefault(0) = 0 Then

                SearchableComboBoxForm_Job.SelectedValue = Nothing

            End If

            If _JobComponentNumber.GetValueOrDefault(0) = 0 Then

                SearchableComboBoxForm_Component.SelectedValue = Nothing

            End If

            SearchableComboBoxForm_Contracts.SelectedValue = Nothing
            SearchableComboBoxForm_Function.SelectedValue = Nothing
            TextBoxForm_ReferenceCode.Text = Nothing
            DateTimePickerForm_InvoiceDate.ValueObject = Nothing

        End Sub
        Public Function EditSelectedContract() As Boolean

            'objects
            Dim Edited As Boolean = False

            Try

                If ServiceFeeContractControlContracts_Contracts.EditSelectedContract Then

                    Edited = True

                    '_LoadedJobComponentFullSource = False ' forces refresh on next popup

                End If

            Catch ex As Exception
                Edited = False
            Finally
                EditSelectedContract = Edited
            End Try

        End Function
        Public Function DeleteSelectedContracts() As Boolean

            'objects
            Dim Deleted As Boolean = False

            Try

                If ServiceFeeContractControlContracts_Contracts.DeleteContract() Then

                    LoadTab(Nothing)

                    Deleted = True

                    UpdateContractsFilter()

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                DeleteSelectedContracts = Deleted
            End Try

        End Function
        Public Function GenerateContractServiceFees() As Boolean

            'objects
            Dim Generated As Boolean = False

            Try

                If ServiceFeeContractControlContracts_Contracts.GenerateFees(True) Then

                    Generated = True

                    TabItemIncomeOnly_IncomeOnlyTab.Tag = False

                End If

            Catch ex As Exception
                Generated = False
            Finally
                GenerateContractServiceFees = Generated
            End Try

        End Function
        Public Function GenerateAllContractServiceFees() As Boolean

            'objects
            Dim Generated As Boolean = False

            Try

                If ServiceFeeContractControlContracts_Contracts.GenerateAllFees() Then

                    Generated = True

                    TabItemIncomeOnly_IncomeOnlyTab.Tag = False

                End If

            Catch ex As Exception
                Generated = False
            Finally
                GenerateAllContractServiceFees = Generated
            End Try

        End Function
        Public Sub ViewContractServiceFees()

            ServiceFeeContractControlContracts_Contracts.GenerateFees(False)

        End Sub
        Public Function AddContract() As Boolean

            'objects
            Dim Added As Boolean = False

            Try

                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog.ShowFormDialog(_ClientCode, _DivisionCode, _ProductCode, _JobNumber.GetValueOrDefault(0), _JobComponentNumber.GetValueOrDefault(0), True) = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                    LoadTab(Nothing)

                    Added = True

                    UpdateContractsFilter()

                    '_LoadedJobComponentFullSource = False ' forces refresh on next popup

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            Catch ex As Exception
                Added = False
            Finally
                AddContract = Added
            End Try

        End Function
        Public Function CopyContract() As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim ContractID As Integer = Nothing

            Try

                ContractID = ServiceFeeContractControlContracts_Contracts.SelectedContractID

                If AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeContractDialog.ShowFormDialog(ContractID, True) = Windows.Forms.DialogResult.OK Then

                    AdvantageFramework.WinForm.Presentation.ShowWaitForm("Loading...")

                    LoadTab(Nothing)

                    Copied = True

                    UpdateContractsFilter()

                    '_LoadedJobComponentFullSource = False ' forces refresh on next popup

                    AdvantageFramework.WinForm.Presentation.CloseWaitForm()

                End If

            Catch ex As Exception
                Copied = False
            Finally
                CopyContract = Copied
            End Try

        End Function
        Public Sub ShowExistingIncomeOnlys(ByVal ShowExisting As Boolean)

            _ShowExistingIncomeOnlys = ShowExisting

            LoadIncomeOnlyTab()

        End Sub
        Public Sub ViewIncomeOnlyHistory()

            'objects
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

            If DataGridViewForm_Details.HasOnlyOneSelectedRow Then

                ParameterDictionary = New Dictionary(Of String, Object)

                ParameterDictionary.Add("ID", CType(DataGridViewForm_Details.GetFirstSelectedRowDataBoundItem, AdvantageFramework.IncomeOnly.Classes.IncomeOnly).ID)

                AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(CRUDDialog.Type.IncomeOnlyHistory, False, False, Nothing, False, "Income Only History", False, False, ParameterDictionary)

            End If

        End Sub
        Public Sub RefreshControl()

            '_LoadedClientFullSource = False
            '_LoadedDivisionFullSource = False
            '_LoadedProductFullSource = False
            '_LoadedJobFullSource = False
            '_LoadedJobComponentFullSource = False
            _LoadedFunctionFullSource = False

            'RefreshColumnOrderAndVisibility()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub IncomeOnlyControl_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed

            RemoveHandler AdvantageFramework.IncomeOnly.IncomeOnlyCreatedEvent, AddressOf AddIncomeOnlyToBatchList

        End Sub
        Private Sub IncomeOnlyControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            AddHandler AdvantageFramework.IncomeOnly.IncomeOnlyCreatedEvent, AddressOf AddIncomeOnlyToBatchList

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewForm_Details_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_Details.AddNewRowEvent

            'objects
            Dim IncomeOnly As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim IncomeOnlyClass As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing

            If TypeOf RowObject Is AdvantageFramework.IncomeOnly.Classes.IncomeOnly Then

                Me.ShowWaitForm("Processing...")

                IncomeOnlyClass = RowObject

                If IncomeOnlyClass IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            IncomeOnlyClass.FillIncomeOnlyEntity(IncomeOnly)

                            If IncomeOnly IsNot Nothing Then

                                IncomeOnly.ID = Nothing
                                IncomeOnly.SequenceNumber = Nothing

                                IncomeOnly.DbContext = DbContext

                                IncomeOnly.AdvanceBillFlag = 0

                                IncomeOnly.ModifiedDate = System.DateTime.Today
                                IncomeOnly.ModifiedBy = _Session.UserCode

                                If AdvantageFramework.Database.Procedures.IncomeOnly.Insert(DbContext, IncomeOnly) Then

                                    IncomeOnlyClass.ID = IncomeOnly.ID
                                    IncomeOnlyClass.SequenceNumber = IncomeOnly.SequenceNumber

                                    AddIncomeOnlyToBatchList(IncomeOnly)

                                Else

                                    DataGridViewForm_Details.CurrentView.DeleteFromDataSource(IncomeOnlyClass)

                                End If

                            End If

                        End Using

                    End Using

                End If

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewForm_Details_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewForm_Details.BeforeAddNewRowEvent

            'objects
            Dim IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing

            If TypeOf RowObject Is AdvantageFramework.IncomeOnly.Classes.IncomeOnly Then

                IncomeOnly = RowObject

                If IncomeOnly.JobNumber.HasValue AndAlso IncomeOnly.JobComponentNumber.HasValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If (From JobComp In AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode, JobNumber:=IncomeOnly.JobNumber)
                            Where JobComp.JobComponentNumber = IncomeOnly.JobComponentNumber
                            Select JobComp).Any = False Then

                            Cancel = True
                            AdvantageFramework.Navigation.ShowMessageBox("Please select a valid job.")

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Details.CellValueChangedEvent

            'objects
            Dim IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing
            Dim IncomeOnlyEntity As AdvantageFramework.Database.Entities.IncomeOnly = Nothing
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim SalesClassCode As String = Nothing
            Dim EditableNonRevisionFieldNames As String() = Nothing
            Dim DepartmentTeamCode As String = Nothing

            Try

                IncomeOnly = DirectCast(DataGridViewForm_Details.CurrentView.GetRow(e.RowHandle), AdvantageFramework.IncomeOnly.Classes.IncomeOnly)

            Catch ex As Exception
                IncomeOnly = Nothing
            End Try

            If IncomeOnly IsNot Nothing Then

                EditableNonRevisionFieldNames = {AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Description.ToString,
                                                 AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString,
                                                 AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Comment.ToString}

                If IncomeOnly.IsBilled = True Then

                    IncomeOnly.IsRevised = True

                ElseIf DataGridViewForm_Details.IsNewItemRow = False Then

                    If EditableNonRevisionFieldNames.Contains(e.Column.FieldName) = False Then

                        IncomeOnly.IsRevised = True

                    End If

                End If

                If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentNumber.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString Then

                    If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString Then

                        If e.Value IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Value)

                                If [Function] IsNot Nothing Then

                                    DepartmentTeamCode = [Function].DepartmentTeamCode

                                End If

                            End Using

                        End If

                        IncomeOnly.DepartmentTeamCode = DepartmentTeamCode

                    ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString Then

                        If e.Value IsNot Nothing Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, e.Value)

                                If Job IsNot Nothing Then

                                    SalesClassCode = Job.SalesClassCode

                                End If

                            End Using

                        End If

                        IncomeOnly.SalesClassCode = SalesClassCode
                        IncomeOnly.MediaType = Nothing
                        IncomeOnly.OrderDescription = Nothing
                        IncomeOnly.OrderNumber = Nothing
                        IncomeOnly.OrderLineNumber = Nothing

                    Else

                        IncomeOnly.MediaType = Nothing
                        IncomeOnly.OrderDescription = Nothing
                        IncomeOnly.OrderNumber = Nothing
                        IncomeOnly.OrderLineNumber = Nothing

                    End If

                    If e.Column.FieldName = DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName Then

                        UpdateBillingRate(IncomeOnly)

                    End If

                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.CommissionPercent.ToString Then

                    CalculateLineItemCommission(IncomeOnly, True, True)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MarkupAmount.ToString Then

                    CalculateLineItemCommission(IncomeOnly, False, True)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.TaxCode.ToString Then

                    UpdateSalesTax(IncomeOnly)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Amount.ToString Then

                    CalculateLineItem(IncomeOnly, BillingSystem.QtyRateAmount.Amount)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Rate.ToString Then

                    CalculateLineItem(IncomeOnly, BillingSystem.QtyRateAmount.Rate)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Quantity.ToString Then

                    CalculateLineItem(IncomeOnly, BillingSystem.QtyRateAmount.Quantity)
                    DataGridViewForm_Details.CurrentView.RefreshRow(e.RowHandle)

                ElseIf e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.IsServiceFee.ToString Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        IncomeOnlyEntity = AdvantageFramework.Database.Procedures.IncomeOnly.LoadByIDAndSequenceNumber(DbContext, IncomeOnly.ID, IncomeOnly.SequenceNumber)

                        If IncomeOnlyEntity IsNot Nothing Then

                            IncomeOnlyEntity.FeeInvoice = If(IncomeOnly.IsServiceFee, 1, 0)

                            AdvantageFramework.Database.Procedures.IncomeOnly.Update(DbContext, IncomeOnlyEntity)

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_ColumnValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs, ViaCellValueChangedEvent As Boolean) Handles DataGridViewForm_Details.ColumnValueChangedEvent

            'objects
            Dim Orders As Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order) = Nothing
            Dim Order As AdvantageFramework.IncomeOnly.Classes.Order = Nothing
            Dim MediaType As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer = 0
            Dim ComponentNumber As Short = 0

            If e IsNot Nothing AndAlso e.Column IsNot Nothing AndAlso e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderNumber.ToString AndAlso ViaCellValueChangedEvent = False Then

                If TypeOf DataGridViewForm_Details.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    OrderNumber = CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).EditValue

                    If CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).EditValue IsNot Nothing Then

                        MediaType = CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.View.GetFocusedRowCellValue("MediaType")

                        DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MediaType.ToString, MediaType)

                    End If

                    If TypeOf CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.DataSource Is System.Windows.Forms.BindingSource AndAlso
                            TypeOf CType(CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.DataSource, System.Windows.Forms.BindingSource).DataSource Is Generic.List(Of AdvantageFramework.IncomeOnly.Classes.Order) Then

                        Orders = CType(CType(DataGridViewForm_Details.CurrentView.ActiveEditor, DevExpress.XtraEditors.GridLookUpEdit).Properties.DataSource, System.Windows.Forms.BindingSource).DataSource

                        If Orders.Where(Function(Entity) Entity.OrderNumber = OrderNumber).Count = 1 Then

                            Try

                                Order = Orders.SingleOrDefault(Function(Entity) Entity.OrderNumber = OrderNumber)

                            Catch ex As Exception
                                Order = Nothing
                            End Try

                            If Order IsNot Nothing Then

                                DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderLineNumber.ToString, Order.LineNumber)

                            End If

                        Else

                            DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderLineNumber.ToString, Nothing)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_CustomColumnDisplayTextEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs) Handles DataGridViewForm_Details.CustomColumnDisplayTextEvent

            'If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ID.ToString OrElse _
            '       e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString OrElse _
            '       e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentNumber.ToString OrElse _
            '       e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString Then

            '    If e.Value Is Nothing OrElse e.Value = 0 Then

            '        e.DisplayText = " "

            '    End If

            'End If

        End Sub
        Private Sub DataGridViewForm_Details_CustomColumnSortEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.CustomColumnSortEventArgs) Handles DataGridViewForm_Details.CustomColumnSortEvent

            'objects
            Dim IncomeOnly1 As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing
            Dim IncomeOnly2 As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing

            Dim JobComponentNumber1 As Short = Nothing
            Dim JobComponentNumber2 As Short = Nothing

            If e.Column.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString Then

                If e.SortOrder <> DevExpress.Data.ColumnSortOrder.None Then

                    Try

                        JobComponentNumber1 = CType(e.RowObject1, AdvantageFramework.IncomeOnly.Classes.IncomeOnly).JobComponentNumber

                    Catch ex As Exception

                    End Try

                    Try

                        JobComponentNumber2 = CType(e.RowObject2, AdvantageFramework.IncomeOnly.Classes.IncomeOnly).JobComponentNumber

                    Catch ex As Exception

                    End Try

                    e.Handled = True

                    If JobComponentNumber1 = JobComponentNumber2 Then

                        e.Result = 0

                    ElseIf JobComponentNumber1 > JobComponentNumber2 Then

                        e.Result = 1

                    ElseIf JobComponentNumber1 < JobComponentNumber2 Then

                        e.Result = -1

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_CustomRowFilterEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowFilterEventArgs) Handles DataGridViewForm_Details.CustomRowFilterEvent

            'objects
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing
            Dim StartDate As Date = Nothing
            Dim EndDate As Date = Nothing

            Try

                BindingSource = DataGridViewForm_Details.DataSource

            Catch ex As Exception

            End Try

            If BindingSource IsNot Nothing Then

                If BindingSource(e.ListSourceRow) IsNot Nothing Then

                    If TypeOf BindingSource(e.ListSourceRow) Is AdvantageFramework.IncomeOnly.Classes.IncomeOnly Then

                        IncomeOnly = BindingSource(e.ListSourceRow)

                        If String.IsNullOrEmpty(SearchableComboBoxForm_Client.GetSelectedValue) = False Then

                            If IncomeOnly.ClientCode <> SearchableComboBoxForm_Client.GetSelectedValue Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If String.IsNullOrEmpty(SearchableComboBoxForm_Division.GetSelectedValue) = False Then

                            If IncomeOnly.DivisionCode <> SearchableComboBoxForm_Division.GetSelectedValue Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If String.IsNullOrEmpty(SearchableComboBoxForm_Product.GetSelectedValue) = False Then

                            If IncomeOnly.ProductCode <> SearchableComboBoxForm_Product.GetSelectedValue Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If SearchableComboBoxForm_Job.GetSelectedValue > 0 Then

                            If IncomeOnly.JobNumber.GetValueOrDefault(0) <> SearchableComboBoxForm_Job.GetSelectedValue Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If SearchableComboBoxForm_Component.GetSelectedValue > 0 Then

                            If (IncomeOnly.JobNumber.GetValueOrDefault(0) & "|" & IncomeOnly.JobComponentNumber.GetValueOrDefault(0)).ToString <> (SearchableComboBoxForm_Job.GetSelectedValue & "|" & SearchableComboBoxForm_Component.GetSelectedValue).ToString Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(SearchableComboBoxForm_Function.GetSelectedValue) = False Then

                            If IncomeOnly.FunctionCode <> CStr(SearchableComboBoxForm_Function.GetSelectedValue) Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If String.IsNullOrWhiteSpace(TextBoxForm_ReferenceCode.Text) = False Then

                            If String.IsNullOrWhiteSpace(IncomeOnly.ReferenceNumber) OrElse IncomeOnly.ReferenceNumber.ToUpper.Contains(TextBoxForm_ReferenceCode.Text.ToUpper) = False Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If DateTimePickerForm_InvoiceDate.ValueObject IsNot Nothing Then

                            StartDate = DateTimePickerForm_InvoiceDate.Value.Date
                            EndDate = StartDate.AddDays(1).AddSeconds(-1)

                            If IncomeOnly.InvoiceDate < StartDate OrElse IncomeOnly.InvoiceDate > EndDate Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                        If SearchableComboBoxForm_Contracts.GetSelectedValue IsNot Nothing Then

                            If IncomeOnly.JobServiceFeeID.GetValueOrDefault(0) <> CInt(SearchableComboBoxForm_Contracts.GetSelectedValue) Then

                                e.Visible = False
                                e.Handled = True

                            End If

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Details.DataSourceChangedEvent

            If DataGridViewForm_Details.Columns IsNot Nothing AndAlso DataGridViewForm_Details.Columns.Count > 0 Then

                RefreshColumnOrderAndVisibility()

                For Each GridColumn In DataGridViewForm_Details.Columns.OfType(Of DevExpress.XtraGrid.Columns.GridColumn)()

                    If GridColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value

                    ElseIf GridColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString Then

                        GridColumn.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom
                        GridColumn.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText

                    End If

                Next

            End If

        End Sub
        Private Sub DataGridViewForm_Details_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Details.InitNewRowEvent

            'objects
            Dim IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer = 0
            Dim JobComponentNumber As Short = Nothing

            Try

                ClientCode = SearchableComboBoxForm_Client.GetSelectedValue
                DivisionCode = SearchableComboBoxForm_Division.GetSelectedValue
                ProductCode = SearchableComboBoxForm_Product.GetSelectedValue
                JobNumber = SearchableComboBoxForm_Job.GetSelectedValue
                JobComponentNumber = SearchableComboBoxForm_Component.GetSelectedValue

                IncomeOnly = DataGridViewForm_Details.CurrentView.GetRow(e.RowHandle)

                If IncomeOnly IsNot Nothing Then

                    IncomeOnly.ClientCode = Nothing
                    IncomeOnly.ClientName = Nothing
                    IncomeOnly.DivisionCode = Nothing
                    IncomeOnly.DivisionName = Nothing
                    IncomeOnly.ProductCode = Nothing
                    IncomeOnly.ProductName = Nothing
                    IncomeOnly.JobNumber = Nothing
                    IncomeOnly.JobDescription = Nothing
                    IncomeOnly.JobComponentNumber = Nothing
                    IncomeOnly.JobComponentDescription = Nothing
                    IncomeOnly.JobComponentID = Nothing

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                            With AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                                IncomeOnly.ClientCode = .ClientCode
                                IncomeOnly.ClientName = .ClientName
                                IncomeOnly.DivisionCode = .DivisionCode
                                IncomeOnly.DivisionName = .DivisionName
                                IncomeOnly.ProductCode = .ProductCode
                                IncomeOnly.ProductName = .ProductDescription
                                IncomeOnly.JobNumber = .JobNumber
                                IncomeOnly.JobDescription = .JobDescription
                                IncomeOnly.JobComponentNumber = .JobComponentNumber
                                IncomeOnly.JobComponentDescription = .JobComponentDescription
                                IncomeOnly.JobComponentID = .ID

                            End With

                        ElseIf JobNumber > 0 Then

                            With AdvantageFramework.Database.Procedures.JobView.LoadByJobNumber(DbContext, SearchableComboBoxForm_Job.GetSelectedValue)

                                IncomeOnly.ClientCode = .ClientCode
                                IncomeOnly.ClientName = .ClientName
                                IncomeOnly.DivisionCode = .DivisionCode
                                IncomeOnly.DivisionName = .DivisionName
                                IncomeOnly.ProductCode = .ProductCode
                                IncomeOnly.ProductName = .ProductDescription
                                IncomeOnly.JobNumber = .JobNumber
                                IncomeOnly.JobDescription = .JobDescription

                            End With

                        ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                            With (From Prod In AdvantageFramework.Database.Procedures.ProductView.Load(DbContext)
                                  Where Prod.ClientCode = ClientCode AndAlso
                                        Prod.DivisionCode = DivisionCode AndAlso
                                        Prod.ProductCode = ProductCode
                                  Select Prod).SingleOrDefault

                                IncomeOnly.ClientCode = .ClientCode
                                IncomeOnly.ClientName = .ClientName
                                IncomeOnly.DivisionCode = .DivisionCode
                                IncomeOnly.DivisionName = .DivisionName
                                IncomeOnly.ProductCode = .ProductCode
                                IncomeOnly.ProductName = .ProductDescription

                            End With

                        ElseIf String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False Then

                            With (From Div In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext)
                                  Where Div.ClientCode = ClientCode AndAlso
                                        Div.DivisionCode = DivisionCode
                                  Select Div).SingleOrDefault

                                IncomeOnly.ClientCode = .ClientCode
                                IncomeOnly.ClientName = .ClientName
                                IncomeOnly.DivisionCode = .DivisionCode
                                IncomeOnly.DivisionName = .DivisionName

                            End With

                        ElseIf String.IsNullOrWhiteSpace(ClientCode) = False Then

                            With AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                                IncomeOnly.ClientCode = .Code
                                IncomeOnly.ClientName = .Name

                            End With

                        End If

                        If String.IsNullOrWhiteSpace(SearchableComboBoxForm_Function.GetSelectedValue) = False Then

                            With AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, SearchableComboBoxForm_Function.GetSelectedValue)

                                IncomeOnly.FunctionCode = .Code
                                IncomeOnly.FunctionDescription = .Description
                                IncomeOnly.DepartmentTeamCode = .DepartmentTeamCode

                            End With

                        End If

                        If IncomeOnly.JobNumber.GetValueOrDefault(0) > 0 Then

                            With AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, IncomeOnly.JobNumber.GetValueOrDefault(0))

                                IncomeOnly.SalesClassCode = .SalesClassCode

                            End With

                        End If

                        If DateTimePickerForm_InvoiceDate.ValueObject IsNot Nothing Then

                            IncomeOnly.InvoiceDate = DateTimePickerForm_InvoiceDate.Value

                        End If

                        If Not String.IsNullOrWhiteSpace(TextBoxForm_ReferenceCode.Text) Then

                            IncomeOnly.ReferenceNumber = TextBoxForm_ReferenceCode.Text

                        End If

                    End Using

                    UpdateBillingRate(IncomeOnly)

                End If

                'DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString, CdpJobCompFilterForm_Filter.ClientCode)

                'If String.IsNullOrEmpty(CdpJobCompFilterForm_Filter.ClientCode) Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientName.ToString, Nothing)

                'End If

                'DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString, CdpJobCompFilterForm_Filter.DivisionCode)

                'If String.IsNullOrEmpty(CdpJobCompFilterForm_Filter.DivisionCode) Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionName.ToString, Nothing)

                'End If

                'DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString, CdpJobCompFilterForm_Filter.ProductCode)

                'If String.IsNullOrEmpty(CdpJobCompFilterForm_Filter.ProductCode) Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductName.ToString, Nothing)

                'End If

                'DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString, CdpJobCompFilterForm_Filter.JobNumber)

                'If CdpJobCompFilterForm_Filter.JobNumber.GetValueOrDefault(0) = 0 Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobDescription.ToString, Nothing)

                'End If

                'DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString, CdpJobCompFilterForm_Filter.JobComponentID)

                'If CdpJobCompFilterForm_Filter.JobComponentID.GetValueOrDefault(0) = 0 Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobDescription.ToString, Nothing)

                'End If

                ''DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentNumber.ToString, CdpJobCompFilterForm_Filter.JobComponentNumber)

                'If SearchableComboBoxForm_Function.HasASelectedValue Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString, SearchableComboBoxForm_Function.GetSelectedValue)

                'End If

                'If DateTimePickerForm_InvoiceDate.ValueObject IsNot Nothing Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.InvoiceDate.ToString, DateTimePickerForm_InvoiceDate.Value)

                'End If

                'If Not String.IsNullOrWhiteSpace(TextBoxForm_ReferenceCode.Text) Then

                '    DataGridViewForm_Details.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString, TextBoxForm_ReferenceCode.Text)

                'End If

            Catch ex As Exception

            End Try

            _NewItemChanged = False

        End Sub
        Private Sub DataGridViewForm_Details_NewItemRowCanceledEvent() Handles DataGridViewForm_Details.NewItemRowCanceledEvent

            _NewItemChanged = False

        End Sub
        Private Sub DataGridViewForm_Details_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Details.NewItemRowCellValueChangedEvent

            _NewItemChanged = True

        End Sub
        Private Sub DataGridViewForm_Details_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Details.QueryPopupNeedDatasourceEvent

            'objects
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim JobNumber As Integer? = Nothing

            If FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString Then

                OverrideDefaultDatasource = True

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.Function.LoadCore(DbContext)
                                  Where (Entity.IsInactive Is Nothing OrElse
                                         Entity.IsInactive = 0) AndAlso
                                        Entity.Type = "I"
                                  Select Entity).ToList

                End Using

            ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString Then

                OverrideDefaultDatasource = True

                ClientCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Datasource = AdvantageFramework.IncomeOnly.LoadAvailableJobs(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode).ToList

                End Using

            ElseIf FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString Then

                OverrideDefaultDatasource = True

                ClientCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString)
                DivisionCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString)
                ProductCode = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString)
                JobNumber = DataGridViewForm_Details.CurrentView.GetFocusedRowCellValue(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Datasource = AdvantageFramework.IncomeOnly.LoadAvailableComponents(DbContext, _Session.UserCode, ClientCode, DivisionCode, ProductCode, JobNumber).ToList

                End Using

            End If

        End Sub
        Private Sub DataGridViewForm_Details_RowDoubleClickEvent() Handles DataGridViewForm_Details.RowDoubleClickEvent

            ViewIncomeOnlyHistory()

        End Sub
        Private Sub DataGridViewForm_Details_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Details.SelectionChangedEvent

            RaiseEvent SelectedRowsChangedEvent()

        End Sub
        Private Sub DataGridViewForm_Details_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewForm_Details.ShowingEditorEvent

            'objects
            Dim IncomeOnly As AdvantageFramework.IncomeOnly.Classes.IncomeOnly = Nothing
            Dim Fieldname As String = Nothing
            Dim EditableColumns As String() = Nothing

            IncomeOnly = DataGridViewForm_Details.CurrentView.GetRow(DataGridViewForm_Details.CurrentView.FocusedRowHandle)

            Fieldname = DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName

            If DataGridViewForm_Details.IsNewItemOrAutoFilterRow Then

                If IncomeOnly Is Nothing Then

                    DataGridViewForm_Details.CurrentView.AddNewRow()

                End If

            ElseIf _UpdateAllowed Then

                If IncomeOnly IsNot Nothing Then

                    If String.IsNullOrWhiteSpace(IncomeOnly.BillingUser) = False Then

                        e.Cancel = True

                    ElseIf IncomeOnly.IsBilled = True Then

                        EditableColumns = {AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Quantity.ToString,
                                           AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Rate.ToString,
                                           AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.Amount.ToString,
                                           AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.CommissionPercent.ToString,
                                           AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MarkupAmount.ToString}

                        e.Cancel = Not EditableColumns.Contains(DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName)

                    ElseIf Fieldname = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString Then

                        If IncomeOnly.JobServiceFeeID.HasValue AndAlso IncomeOnly.JobServiceFeeID.GetValueOrDefault(0) > 0 Then

                            e.Cancel = True

                        End If

                    ElseIf Fieldname = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.TaxCode.ToString Then

                        e.Cancel = AdvantageFramework.IncomeOnly.LoadApplyTaxUponBilling(_Session)

                    End If

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewForm_Details_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Details.ShownEditorEvent

            'objects
            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing
            Dim MediaType As String = Nothing
            Dim OrderNumber As Integer = 0
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If TypeOf DataGridViewForm_Details.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                GridLookUpEdit = DataGridViewForm_Details.CurrentView.ActiveEditor

                If DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderNumber.ToString Then

                    ClientCode = DataGridViewForm_Details.CurrentView.GetRowCellValue(DataGridViewForm_Details.CurrentView.FocusedRowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString)
                    DivisionCode = DataGridViewForm_Details.CurrentView.GetRowCellValue(DataGridViewForm_Details.CurrentView.FocusedRowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString)
                    ProductCode = DataGridViewForm_Details.CurrentView.GetRowCellValue(DataGridViewForm_Details.CurrentView.FocusedRowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString)

                    If String.IsNullOrWhiteSpace(ClientCode) = False AndAlso String.IsNullOrWhiteSpace(DivisionCode) = False AndAlso String.IsNullOrWhiteSpace(ProductCode) = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            BindingSource = New System.Windows.Forms.BindingSource

                            BindingSource.DataSource = AdvantageFramework.IncomeOnly.LoadOrders(DbContext, ClientCode, DivisionCode, ProductCode, 0, 0)

                        End Using

                        GridLookUpEdit.Properties.ValueMember = "OrderNumber"
                        GridLookUpEdit.Properties.DataSource = BindingSource

                    Else

                        DataGridViewForm_Details.CurrentView.CloseEditor()

                    End If

                ElseIf DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderLineNumber.ToString Then

                    OrderNumber = DataGridViewForm_Details.CurrentView.GetRowCellValue(DataGridViewForm_Details.CurrentView.FocusedRowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.OrderNumber.ToString)
                    MediaType = DataGridViewForm_Details.CurrentView.GetRowCellValue(DataGridViewForm_Details.CurrentView.FocusedRowHandle, AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.MediaType.ToString)

                    If OrderNumber <> 0 AndAlso String.IsNullOrWhiteSpace(MediaType) = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            BindingSource = New System.Windows.Forms.BindingSource

                            If MediaType = "M" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.MagazineDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber))

                            ElseIf MediaType = "N" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.NewspaperDetailView.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber))

                            ElseIf MediaType = "I" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber))

                            ElseIf MediaType = "O" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadNonCancelledNonCommissionByOrderNumber(DbContext, OrderNumber))

                            ElseIf MediaType = "R" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadNonCancelledByOrderNumber(DbContext, OrderNumber))

                            ElseIf MediaType = "T" Then

                                BindingSource.DataSource = AdvantageFramework.WinForm.Presentation.Controls.LoadGridViewDataSourceView(AdvantageFramework.Database.Procedures.TVOrderDetail.LoadNonCancelledByOrderNumber(DbContext, OrderNumber))

                            End If

                            GridLookUpEdit.Properties.DataSource = BindingSource

                        End Using

                    Else

                        DataGridViewForm_Details.CurrentView.CloseEditor()

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Details_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewForm_Details.ValidatingEditorEvent

            If DataGridViewForm_Details.CurrentView.FocusedColumn.FieldName = AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.InvoiceDate.ToString Then

                If e.Value IsNot Nothing AndAlso Math.Abs(DateDiff(DateInterval.Day, e.Value, Now)) > 60 Then

                    If AdvantageFramework.WinForm.MessageBox.Show("The invoice date is outside of normal range, are you sure you want to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.No Then

                        e.Valid = False

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Contracts_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Contracts.EditValueChanged

            If _FilterValueChanged = False Then

                _FilterValueChanged = True

                BackFillContractData()

                _FilterValueChanged = False

                FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobServiceFeeID.ToString)

                DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Function_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Function.EditValueChanged

            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.FunctionCode.ToString)

            RefreshColumnOrderAndVisibility()

            DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

        End Sub
        Private Sub SearchableComboBoxForm_Function_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxForm_Function.QueryPopupNeedDataSource

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxForm_Function.DataSource = From Entity In AdvantageFramework.Database.Procedures.FunctionView.LoadAllActive(DbContext)
                                                             Where Entity.Type = "I"
                                                             Select Entity

                DataSourceSet = True

            End Using

        End Sub
        Private Sub DateTimePickerForm_InvoiceDate_ValueObjectChanged(sender As Object, e As EventArgs) Handles DateTimePickerForm_InvoiceDate.ValueObjectChanged

            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.InvoiceDate.ToString)

            DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

        End Sub
        Private Sub TextBoxForm_ReferenceCode_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles TextBoxForm_ReferenceCode.Validating

            FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ReferenceNumber.ToString)

            DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

        End Sub
        Private Sub TabControlForm_IncomeOnly_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_IncomeOnly.SelectedTabChanged

            If _ControlHasLoaded Then

                LoadTab(e.NewTab)

                RaiseEvent SelectedTabChangedEvent()

            End If

        End Sub
        Private Sub TabControlForm_IncomeOnly_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_IncomeOnly.SelectedTabChanging

            If _ControlHasLoaded Then

                e.Cancel = Not CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub DataGridViewForm_Details_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewForm_Details.ValidateRowEvent

            If e.Row IsNot Nothing AndAlso True Then

                If DataGridViewForm_Details.CurrentView.IsNewItemRow(e.RowHandle) Then

                    If CType(e.Row, AdvantageFramework.IncomeOnly.Classes.IncomeOnly).ID = 0 Then

                        If _NewItemChanged = False Then

                            DataGridViewForm_Details.CancelNewItemRow()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Client_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Client.EditValueChanged

            'objects
            Dim Handled As Boolean = False

            If _FilterValueChanged = False Then

                _FilterValueChanged = True

                Try

                    SearchableComboBoxForm_Division.SelectedValue = Nothing
                    SearchableComboBoxForm_Product.SelectedValue = Nothing
                    SearchableComboBoxForm_Job.SelectedValue = Nothing
                    SearchableComboBoxForm_Component.SelectedValue = Nothing

                    LoadDivisionSource(SearchableComboBoxForm_Client.GetSelectedValue, "", False)

                Catch ex As Exception

                End Try

                _FilterValueChanged = False

                If Not [String].IsNullOrWhiteSpace(SearchableComboBoxForm_Client.GetSelectedValue) Then

                    Handled = SearchableComboBoxForm_Division.SelectSingleItemDataSource()

                End If

                If Not Handled Then

                    LoadContractsLookup()

                    FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ClientCode.ToString)

                    RefreshColumnOrderAndVisibility()

                    DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Client_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Client.QueryPopUp

            LoadClientSource(SearchableComboBoxForm_Client.GetSelectedValue, False)

        End Sub
        Private Sub SearchableComboBoxForm_Division_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Division.EditValueChanged

            'objects
            Dim Handled As Boolean = False

            If _FilterValueChanged = False Then

                _FilterValueChanged = True

                Try

                    SearchableComboBoxForm_Product.SelectedValue = Nothing
                    SearchableComboBoxForm_Job.SelectedValue = Nothing
                    SearchableComboBoxForm_Component.SelectedValue = Nothing

                    LoadProductSource(SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, "", False)

                Catch ex As Exception

                End Try

                _FilterValueChanged = False

                If Not [String].IsNullOrWhiteSpace(SearchableComboBoxForm_Division.GetSelectedValue) Then

                    Handled = SearchableComboBoxForm_Product.SelectSingleItemDataSource()

                End If

                If Not Handled Then

                    LoadContractsLookup()

                    FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.DivisionCode.ToString)

                    RefreshColumnOrderAndVisibility()

                    DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Division_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Division.QueryPopUp

            LoadDivisionSource(SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, False)

        End Sub
        Private Sub SearchableComboBoxForm_Product_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Product.EditValueChanged

            'objects
            Dim Handled As Boolean = False

            If _FilterValueChanged = False Then

                _FilterValueChanged = True

                Try

                    SearchableComboBoxForm_Job.SelectedValue = Nothing
                    SearchableComboBoxForm_Component.SelectedValue = Nothing

                    LoadJobSource(Nothing, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue, False)

                Catch ex As Exception

                End Try

                _FilterValueChanged = False

                If Not String.IsNullOrWhiteSpace(SearchableComboBoxForm_Product.GetSelectedValue) Then

                    Handled = SearchableComboBoxForm_Job.SelectSingleItemDataSource()

                End If

                If Not Handled Then

                    LoadContractsLookup()

                    FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.ProductCode.ToString)

                    RefreshColumnOrderAndVisibility()

                    DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Product_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Product.QueryPopUp

            LoadProductSource(SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue, False)

        End Sub
        Private Sub SearchableComboBoxForm_Job_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Job.EditValueChanged

            'objects
            Dim Job As AdvantageFramework.Database.Entities.Job = Nothing
            Dim JobNumber As Integer = Nothing
            Dim Handled As Boolean = False

            JobNumber = SearchableComboBoxForm_Job.GetSelectedValue

            If _FilterValueChanged = False Then

                _FilterValueChanged = True

                Try

                    SearchableComboBoxForm_Component.SelectedValue = Nothing

                    LoadJobCompSource(JobNumber, Nothing, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue, False)

                Catch ex As Exception

                End Try

                _FilterValueChanged = False

                If JobNumber > 0 Then

                    Handled = SearchableComboBoxForm_Component.SelectSingleItemDataSource()

                End If

                If Not Handled Then

                    _FilterValueChanged = True

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, JobNumber)

                            If Job IsNot Nothing Then

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    If SearchableComboBoxForm_Client.GetSelectedValue() <> Job.ClientCode Then

                                        LoadClientSource(DbContext, SecurityDbContext, Job.ClientCode, False)

                                        SearchableComboBoxForm_Client.SelectedValue = Job.ClientCode

                                    End If

                                    If SearchableComboBoxForm_Division.GetSelectedValue() <> Job.DivisionCode Then

                                        LoadDivisionSource(DbContext, SecurityDbContext, Job.ClientCode, Job.DivisionCode, False)

                                        SearchableComboBoxForm_Division.SelectedValue = Job.DivisionCode

                                    End If

                                    If SearchableComboBoxForm_Product.GetSelectedValue() <> Job.ProductCode Then

                                        LoadProductSource(DbContext, SecurityDbContext, Job.ClientCode, Job.DivisionCode, Job.ProductCode, False)

                                        SearchableComboBoxForm_Product.SelectedValue = Job.ProductCode

                                    End If

                                End Using

                                CheckCDPOfficeSecurityInFilters(DbContext, Job.ClientCode, Job.DivisionCode, Job.ProductCode)

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    _FilterValueChanged = False

                    LoadContractsLookup()

                    FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobNumber.ToString)

                    RefreshColumnOrderAndVisibility()

                    DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Job_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Job.QueryPopUp

            LoadJobSource(SearchableComboBoxForm_Job.GetSelectedValue, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue, False)

        End Sub
        Private Sub SearchableComboBoxForm_Component_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Component.EditValueChanged

            'objects
            Dim JobComponentView As AdvantageFramework.Database.Views.JobComponentView = Nothing
            Dim JobNumber As Integer = Nothing
            Dim JobComponentNumber As Short = Nothing

            Try

                If SearchableComboBoxForm_Job.HasASelectedValue Then

                    JobNumber = SearchableComboBoxForm_Job.GetSelectedValue

                Else

                    JobNumber = SearchableComboBoxForm_Component.Properties.View.GetFocusedRowCellValue("JobNumber")

                End If

            Catch ex As Exception
                JobNumber = 0
            End Try

            JobComponentNumber = SearchableComboBoxForm_Component.GetSelectedValue

            If _FilterValueChanged = False Then

                If JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobComponentView = AdvantageFramework.Database.Procedures.JobComponentView.LoadByJobNumberAndJobComponentNumber(DbContext, JobNumber, JobComponentNumber)

                        If JobComponentView IsNot Nothing Then

                            _FilterValueChanged = True

                            Try

                                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    If SearchableComboBoxForm_Job.GetSelectedValue() <> JobComponentView.JobNumber Then

                                        LoadJobSource(DbContext, JobComponentView.JobNumber, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode, False)

                                        SearchableComboBoxForm_Job.SelectedValue = JobComponentView.JobNumber

                                    End If

                                    If SearchableComboBoxForm_Client.GetSelectedValue() <> JobComponentView.ClientCode Then

                                        LoadClientSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, False)

                                        SearchableComboBoxForm_Client.SelectedValue = JobComponentView.ClientCode

                                    End If

                                    If SearchableComboBoxForm_Division.GetSelectedValue() <> JobComponentView.DivisionCode Then

                                        LoadDivisionSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, JobComponentView.DivisionCode, False)

                                        SearchableComboBoxForm_Division.SelectedValue = JobComponentView.DivisionCode

                                    End If

                                    If SearchableComboBoxForm_Product.GetSelectedValue() <> JobComponentView.ProductCode Then

                                        LoadProductSource(DbContext, SecurityDbContext, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode, False)

                                        SearchableComboBoxForm_Product.SelectedValue = JobComponentView.ProductCode

                                    End If

                                    CheckCDPOfficeSecurityInFilters(DbContext, JobComponentView.ClientCode, JobComponentView.DivisionCode, JobComponentView.ProductCode)

                                End Using

                            Catch ex As Exception

                            End Try

                            _FilterValueChanged = False

                        End If

                    End Using

                    SearchableComboBoxForm_Job.SelectedValue = JobNumber
                    SearchableComboBoxForm_Component.SelectedValue = JobComponentNumber

                End If

                LoadContractsLookup()

                FilterByOptions(AdvantageFramework.IncomeOnly.Classes.IncomeOnly.Properties.JobComponentID.ToString)

                RefreshColumnOrderAndVisibility()

                DataGridViewForm_Details.CurrentView.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub SearchableComboBoxForm_Component_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Component.QueryPopUp

            LoadJobCompSource(SearchableComboBoxForm_Job.GetSelectedValue, SearchableComboBoxForm_Component.GetSelectedValue, SearchableComboBoxForm_Client.GetSelectedValue, SearchableComboBoxForm_Division.GetSelectedValue, SearchableComboBoxForm_Product.GetSelectedValue, False)

            Try

                If SearchableComboBoxForm_Component.Properties.View.Columns("JobNumber") IsNot Nothing Then

                    If SearchableComboBoxForm_Job.GetSelectedValue() > 0 Then

                        SearchableComboBoxForm_Component.Properties.View.Columns("JobNumber").Visible = False

                    Else

                        SearchableComboBoxForm_Component.Properties.View.Columns("JobNumber").Visible = True

                    End If

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub SearchableComboBoxForm_Function_QueryPopUp(sender As Object, e As ComponentModel.CancelEventArgs) Handles SearchableComboBoxForm_Function.QueryPopUp

            LoadFunctionSource()

        End Sub

#Region "  Contracts "

        Private Sub ServiceFeeContractControlContracts_Contracts_CheckForUnsavedChangesEvent(ByRef Cancel As Boolean) Handles ServiceFeeContractControlContracts_Contracts.CheckForUnsavedChangesEvent

            Cancel = Not CheckForUnsavedChanges()

        End Sub
        Private Sub ServiceFeeContractControlContracts_Contracts_SelectedContractChanged() Handles ServiceFeeContractControlContracts_Contracts.SelectedContractChanged

            RaiseEvent SelectedRowsChangedEvent()

        End Sub

#End Region

#End Region

#End Region

    End Class

End Namespace
