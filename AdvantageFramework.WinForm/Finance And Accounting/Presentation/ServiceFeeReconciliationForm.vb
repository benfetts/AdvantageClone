Namespace FinanceAndAccounting.Presentation

    Public Class ServiceFeeReconciliationForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod = Nothing
        Private _SelectedCriteria As IEnumerable = Nothing
        Private _FeeTimeFrom As Date = Nothing
        Private _FeeTimeTo As Date = Nothing
        Private _IncomeOnlySalesClassCodes As Generic.List(Of String) = Nothing
        Private _IncomeOnlyFunctionCodes As Generic.List(Of String) = Nothing
        Private _ProductionCommissionSalesClassCodes As Generic.List(Of String) = Nothing
        Private _ProductionCommissionFunctionCodes As Generic.List(Of String) = Nothing
        Private _ServiceFeeTypeCodes As Generic.List(Of String) = Nothing
        Private _ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions = Nothing
        Private _ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod
            Get
                FeePostPeriodFrom = _FeePostPeriodFrom
            End Get
        End Property
        Private ReadOnly Property FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod
            Get
                FeePostPeriodTo = _FeePostPeriodTo
            End Get
        End Property
        Private ReadOnly Property SelectedCriteria As IEnumerable
            Get
                SelectedCriteria = _SelectedCriteria
            End Get
        End Property
        Private ReadOnly Property FeeTimeFrom As Date
            Get
                FeeTimeFrom = _FeeTimeFrom
            End Get
        End Property
        Private ReadOnly Property FeeTimeTo As Date
            Get
                FeeTimeTo = _FeeTimeTo
            End Get
        End Property
        Private ReadOnly Property IncomeOnlySalesClassCodes As Generic.List(Of String)
            Get
                IncomeOnlySalesClassCodes = _IncomeOnlySalesClassCodes
            End Get
        End Property
        Private ReadOnly Property IncomeOnlyFunctionCodes As Generic.List(Of String)
            Get
                IncomeOnlyFunctionCodes = _IncomeOnlyFunctionCodes
            End Get
        End Property
        Private ReadOnly Property ProductionCommissionSalesClassCodes As Generic.List(Of String)
            Get
                ProductionCommissionSalesClassCodes = _ProductionCommissionSalesClassCodes
            End Get
        End Property
        Private ReadOnly Property ProductionCommissionFunctionCodes As Generic.List(Of String)
            Get
                ProductionCommissionFunctionCodes = _ProductionCommissionFunctionCodes
            End Get
        End Property
        Private ReadOnly Property ServiceFeeTypeCodes As Generic.List(Of String)
            Get
                ServiceFeeTypeCodes = _ServiceFeeTypeCodes
            End Get
        End Property
        Private ReadOnly Property ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions
            Get
                ServiceFeeReconciliationGroupByOption = _ServiceFeeReconciliationGroupByOption
            End Get
        End Property
        Private ReadOnly Property ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles
            Get
                ServiceFeeReconciliationSummaryStyle = _ServiceFeeReconciliationSummaryStyle
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal IsDialog As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

            If IsDialog Then

                TabControlForm_ServiceFeeReconciliation.Height = Me.Height - (Me.Height - ButtonForm_Process.Location.Y) - 25

                ButtonForm_Process.Visible = True
                ButtonForm_Cancel.Visible = True

            Else

                ButtonForm_Process.Visible = False
                ButtonForm_Cancel.Visible = False

            End If

        End Sub
        Public Sub LoadCriteria()

            DataGridViewSelectionCriteria_Criteria.Enabled = Not RadioButtonSelectionCriteria_All.Checked

            DataGridViewSelectionCriteria_Criteria.CurrentView.ClearSorting()
            DataGridViewSelectionCriteria_Criteria.CurrentView.ClearColumnsFilter()
            DataGridViewSelectionCriteria_Criteria.CurrentView.ClearGrouping()
            DataGridViewSelectionCriteria_Criteria.CurrentView.GroupSummary.Clear()
            DataGridViewSelectionCriteria_Criteria.DataSource = Nothing

            DataGridViewSelectionCriteria_Criteria.ClearGridCustomization()
            DataGridViewSelectionCriteria_Criteria.ClearColumns()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If RadioButtonSelectionCriteria_Client.Checked Then

                        DataGridViewSelectionCriteria_Criteria.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).ToList

                    ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                        DataGridViewSelectionCriteria_Criteria.DataSource = AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client").Where(Function(Division) Division.Client.IsActive = 1).ToList

                    ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                        DataGridViewSelectionCriteria_Criteria.DataSource = AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Include("Client").Include("Division").Where(Function(Product) Product.Client.IsActive = 1 AndAlso Product.Division.IsActive = 1).ToList

                    End If

                End Using

            End Using

            DataGridViewSelectionCriteria_Criteria.CurrentView.BestFitColumns()

        End Sub
        Private Sub SaveServiceFeeReconciliationSettings()

            'objects
            Dim ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing
            Dim Codes() As String = Nothing
            Dim IsNewSetting As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ServiceFeeReconciliationSetting = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

                If ServiceFeeReconciliationSetting Is Nothing Then

                    ServiceFeeReconciliationSetting = New AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting

                    ServiceFeeReconciliationSetting.DbContext = SecurityDbContext

                    IsNewSetting = True

                End If

                ServiceFeeReconciliationSetting.UserCode = Me.Session.UserCode

                AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.DeleteByUserCode(SecurityDbContext, Me.Session.UserCode)

                AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.DeleteByUserID(SecurityDbContext, Me.Session.User.ID)

                If RadioButtonServiceFeeTypeCriteria_None.Checked Then

                    ServiceFeeReconciliationSetting.ServiceFeeTypeSelection = 0

                ElseIf RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Checked Then

                    ServiceFeeReconciliationSetting.ServiceFeeTypeSelection = 1

                ElseIf RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Checked Then

                    ServiceFeeReconciliationSetting.ServiceFeeTypeSelection = 2

                ElseIf RadioButtonServiceFeeTypeCriteria_JobComponent.Checked Then

                    ServiceFeeReconciliationSetting.ServiceFeeTypeSelection = 3

                End If

                If RadioButtonServiceFeeTypeCriteria_None.Checked = False Then

                    Codes = DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                    If Codes.Length > 0 Then

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.Insert(SecurityDbContext, Me.Session.UserCode, Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.SERVICE_FEE_TYPE, Codes)

                    End If

                End If

                ServiceFeeReconciliationSetting.GroupByOption = CInt(ComboBoxRightSection_GroupBy.GetSelectedValue)

                ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel = CheckBoxRightSection_IncludeServiceFeeTypeLevel.Checked
                ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy = CheckBoxRightSection_AddFeeDescriptionToGroupBy.Checked

                ServiceFeeReconciliationSetting.SummaryStyle = CInt(ComboBoxRightSection_SummaryStyle.GetSelectedValue)

                If RadioButtonSelectionCriteria_All.Checked Then

                    ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption = 4

                ElseIf RadioButtonSelectionCriteria_Client.Checked Then

                    ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption = 1

                    Codes = DataGridViewSelectionCriteria_Criteria.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                    If Codes.Length > 0 Then

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.Insert(SecurityDbContext, Me.Session.User.ID, Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.Client, Codes)

                    End If

                ElseIf RadioButtonSelectionCriteria_ClientDivision.Checked Then

                    ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption = 2

                    Codes = DataGridViewSelectionCriteria_Criteria.GetAllSelectedRowsDataBoundItems.OfType(Of Object).Select(Function(Division) CStr(Division.ClientCode & "|" & Division.Code)).ToArray

                    If Codes.Length > 0 Then

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.Insert(SecurityDbContext, Me.Session.User.ID, Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivision, Codes)

                    End If

                ElseIf RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                    ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption = 3

                    Codes = DataGridViewSelectionCriteria_Criteria.GetAllSelectedRowsDataBoundItems.OfType(Of Object).Select(Function(Product) CStr(Product.ClientCode & "|" & Product.DivisionCode & "|" & Product.Code)).ToArray

                    If Codes.Length > 0 Then

                        AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.Insert(SecurityDbContext, Me.Session.User.ID, Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivisionProduct, Codes)

                    End If

                End If

                If CheckBoxStandardFee_StandardFee.Checked Then

                    ServiceFeeReconciliationSetting.IncludeIncomeOnly = 1

                    If CheckBoxStandardFee_AllComponentsMarkedAsFee.Checked Then

                        ServiceFeeReconciliationSetting.IncomeOnlyJobCompMarkedAsFee = 1

                    Else

                        ServiceFeeReconciliationSetting.IncomeOnlyJobCompMarkedAsFee = 0

                    End If

                    If CheckBoxStandardFee_PostedBasedOnSalesClass.Checked Then

                        ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnSalesClass = 1

                        Codes = DataGridViewStandardFee_SalesClasses.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        If Codes.Length > 0 Then

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.Insert(SecurityDbContext, Me.Session.UserCode, Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_SC, Codes)

                        End If

                    Else

                        ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnSalesClass = 0

                    End If

                    If CheckBoxStandardFee_PostedBasedOnFunctions.Checked Then

                        ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnFunction = 1

                        Codes = DataGridViewStandardFee_Functions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        If Codes.Length > 0 Then

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.Insert(SecurityDbContext, Me.Session.UserCode, Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_FUNC, Codes)

                        End If

                    Else

                        ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnFunction = 0

                    End If

                Else

                    ServiceFeeReconciliationSetting.IncludeIncomeOnly = 0
                    ServiceFeeReconciliationSetting.IncomeOnlyJobCompMarkedAsFee = 0
                    ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnSalesClass = 0
                    ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnFunction = 0

                End If

                If CheckBoxProductionCommission_ProductionCommission.Checked Then

                    ServiceFeeReconciliationSetting.IncludeProductionCommission = 1

                    If CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked Then

                        ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnSalesClass = 1

                        Codes = DataGridViewProductionCommission_SalesClasses.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        If Codes.Length > 0 Then

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.Insert(SecurityDbContext, Me.Session.UserCode, Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_SC, Codes)

                        End If

                    Else

                        ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnSalesClass = 0

                    End If

                    If CheckBoxProductionCommission_PostedBasedOnFunctions.Checked Then

                        ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnFunction = 1

                        Codes = DataGridViewProductionCommission_Functions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                        If Codes.Length > 0 Then

                            AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.Insert(SecurityDbContext, Me.Session.UserCode, Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_FUNC, Codes)

                        End If

                    Else

                        ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnFunction = 0

                    End If

                Else

                    ServiceFeeReconciliationSetting.IncludeProductionCommission = 0
                    ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnSalesClass = 0
                    ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnFunction = 0

                End If

                If CheckBoxMediaCommission_MediaCommission.Checked Then

                    ServiceFeeReconciliationSetting.IncludeMediaCommission = 1

                    If CheckBoxMediaCommission_Broadcast.Checked Then

                        ServiceFeeReconciliationSetting.BroadcastCommission = 1

                    Else

                        ServiceFeeReconciliationSetting.BroadcastCommission = 0

                    End If

                    If CheckBoxMediaCommission_Magazine.Checked Then

                        ServiceFeeReconciliationSetting.MagazineCommission = 1

                    Else

                        ServiceFeeReconciliationSetting.MagazineCommission = 0

                    End If

                    If CheckBoxMediaCommission_Newspaper.Checked Then

                        ServiceFeeReconciliationSetting.NewspaperCommission = 1

                    Else

                        ServiceFeeReconciliationSetting.NewspaperCommission = 0

                    End If

                    If CheckBoxMediaCommission_Internet.Checked Then

                        ServiceFeeReconciliationSetting.InternetCommission = 1

                    Else

                        ServiceFeeReconciliationSetting.InternetCommission = 0

                    End If

                    If CheckBoxMediaCommission_OutOfHome.Checked Then

                        ServiceFeeReconciliationSetting.OutOfHomeCommission = 1

                    Else

                        ServiceFeeReconciliationSetting.OutOfHomeCommission = 0

                    End If

                Else

                    ServiceFeeReconciliationSetting.IncludeMediaCommission = 0
                    ServiceFeeReconciliationSetting.BroadcastCommission = 0
                    ServiceFeeReconciliationSetting.MagazineCommission = 0
                    ServiceFeeReconciliationSetting.NewspaperCommission = 0
                    ServiceFeeReconciliationSetting.InternetCommission = 0
                    ServiceFeeReconciliationSetting.OutOfHomeCommission = 0

                End If

                If CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Checked Then

                    ServiceFeeReconciliationSetting.IncludeUnreconciledOnly = 1

                Else

                    ServiceFeeReconciliationSetting.IncludeUnreconciledOnly = 0

                End If

                If CheckBoxFeeTimeCriteria_StandardFeeTime.Checked Then

                    ServiceFeeReconciliationSetting.IncludeIncomeOnlyFeeTime = 1

                Else

                    ServiceFeeReconciliationSetting.IncludeIncomeOnlyFeeTime = 0

                End If

                If CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Checked Then

                    ServiceFeeReconciliationSetting.IncludeProductionCommissionFeeTime = 1

                Else

                    ServiceFeeReconciliationSetting.IncludeProductionCommissionFeeTime = 0

                End If

                If CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Checked Then

                    ServiceFeeReconciliationSetting.IncludeMediaCommissionFeeTime = 1

                Else

                    ServiceFeeReconciliationSetting.IncludeMediaCommissionFeeTime = 0

                End If

                If RadioButtonPrimaryDisplayOption_Client.Checked Then

                    ServiceFeeReconciliationSetting.PrimaryDisplayOption = 1

                ElseIf RadioButtonPrimaryDisplayOption_ClientDivision.Checked Then

                    ServiceFeeReconciliationSetting.PrimaryDisplayOption = 2

                ElseIf RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Checked Then

                    ServiceFeeReconciliationSetting.PrimaryDisplayOption = 3

                End If

                If IsNewSetting Then

                    AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.Insert(SecurityDbContext, ServiceFeeReconciliationSetting)

                Else

                    AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.Update(SecurityDbContext, ServiceFeeReconciliationSetting)

                End If

            End Using

        End Sub
        Private Function ProcessServiceFeeReconciliationReport() As Boolean

            'objects
            Dim Process As Boolean = True

            If RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Checked OrElse
                    RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Checked OrElse
                    RadioButtonServiceFeeTypeCriteria_JobComponent.Checked Then

                If DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.HasASelectedRow = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select service fee type criteria")

                    Process = False

                End If

            ElseIf RadioButtonServiceFeeTypeCriteria_None.Checked = False Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select service fee type criteria option to include")

                Process = False

            End If

            If Process Then

                If ComboBoxRightSection_GroupBy.HasASelectedValue = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a group by option")

                    Process = False

                End If

            End If

            If Process Then

                If ComboBoxRightSection_SummaryStyle.HasASelectedValue = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a summary style")

                    Process = False

                End If

            End If

            If Process Then

                If RadioButtonSelectionCriteria_Client.Checked OrElse RadioButtonSelectionCriteria_ClientDivision.Checked OrElse
                    RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                    If DataGridViewSelectionCriteria_Criteria.HasASelectedRow = False Then

                        AdvantageFramework.WinForm.MessageBox.Show("Please select criteria")

                        Process = False

                    End If

                ElseIf RadioButtonSelectionCriteria_All.Checked = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select criteria option to include")

                    Process = False

                End If

            End If

            If Process Then

                If RadioButtonPrimaryDisplayOption_Client.Checked = False AndAlso RadioButtonPrimaryDisplayOption_ClientDivision.Checked = False AndAlso
                        RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Checked = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select primary display option")

                    Process = False

                End If

            End If

            If Process Then

                If ComboBoxRightSection_GroupBy.HasASelectedValue = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a group by option")

                    Process = False

                End If

            End If

            If Process Then

                If ComboBoxRightSection_SummaryStyle.HasASelectedValue = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a summary style")

                    Process = False

                End If

            End If

            If Process Then

                If TextBoxLeftSection_FeePeriodsFrom.Text = "" OrElse TextBoxLeftSection_FeePeriodsFrom.Tag Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid start fee post period")

                    Process = False

                ElseIf TextBoxLeftSection_FeePeriodsTo.Text = "" OrElse TextBoxLeftSection_FeePeriodsTo.Tag Is Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid end fee post period")

                    Process = False

                End If

            End If

            If Process Then

                If DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Value = Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid start fee time posted")

                    Process = False

                ElseIf DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Value = Nothing Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select valid end fee time posted")

                    Process = False

                ElseIf DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Value < DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Value Then

                    AdvantageFramework.WinForm.MessageBox.Show("End fee time posted is less than start fee time posted")

                    Process = False

                End If

            End If

            If Process Then

                If CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Checked OrElse CheckBoxFeeTimeCriteria_StandardFeeTime.Checked OrElse
                        CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Checked OrElse CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Checked OrElse
                        CheckBoxStandardFee_StandardFee.Checked OrElse CheckBoxProductionCommission_ProductionCommission.Checked OrElse
                        CheckBoxMediaCommission_MediaCommission.Checked Then

                    If CheckBoxStandardFee_StandardFee.Checked Then

                        If CheckBoxStandardFee_AllComponentsMarkedAsFee.Checked OrElse CheckBoxStandardFee_PostedBasedOnSalesClass.Checked OrElse
                                CheckBoxStandardFee_PostedBasedOnFunctions.Checked Then

                            If CheckBoxStandardFee_PostedBasedOnSalesClass.Checked Then

                                If DataGridViewStandardFee_SalesClasses.HasASelectedRow = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Sales Class")

                                    Process = False

                                End If

                            End If

                            If Process Then

                                If CheckBoxStandardFee_PostedBasedOnFunctions.Checked Then

                                    If DataGridViewStandardFee_Functions.HasASelectedRow = False Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Function")

                                        Process = False

                                    End If

                                End If

                            End If

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Standard Fee Option.")

                            Process = False

                        End If

                    End If

                    If Process Then

                        If CheckBoxProductionCommission_ProductionCommission.Checked Then

                            If CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked Then

                                If DataGridViewProductionCommission_SalesClasses.HasASelectedRow = False Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Sales Class")

                                    Process = False

                                End If

                            End If

                            If Process Then

                                If CheckBoxProductionCommission_PostedBasedOnFunctions.Checked Then

                                    If DataGridViewProductionCommission_Functions.HasASelectedRow = False Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Function")

                                        Process = False

                                    End If

                                End If

                            End If

                        End If

                    End If

                    If Process Then

                        If CheckBoxMediaCommission_MediaCommission.Checked Then

                            If CheckBoxMediaCommission_Broadcast.Checked = False AndAlso CheckBoxMediaCommission_Magazine.Checked = False AndAlso
                                    CheckBoxMediaCommission_Newspaper.Checked = False AndAlso CheckBoxMediaCommission_Internet.Checked = False AndAlso
                                    CheckBoxMediaCommission_OutOfHome.Checked = False Then

                                AdvantageFramework.WinForm.MessageBox.Show("Must select at least one Media Commission type.")

                                Process = False

                            End If

                        End If

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("At least one option must be selected from the Fee Criteria tab.")

                    Process = False

                End If

            End If

            If Process Then

                SaveServiceFeeReconciliationSettings()

                _FeePostPeriodFrom = TextBoxLeftSection_FeePeriodsFrom.Tag
                _FeePostPeriodTo = TextBoxLeftSection_FeePeriodsTo.Tag
                _SelectedCriteria = DataGridViewSelectionCriteria_Criteria.GetAllSelectedRowsDataBoundItems.OfType(Of Object).ToList
                _FeeTimeFrom = DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Value
                _FeeTimeTo = DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Value
                _IncomeOnlySalesClassCodes = DataGridViewStandardFee_SalesClasses.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList
                _IncomeOnlyFunctionCodes = DataGridViewStandardFee_Functions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList
                _ProductionCommissionSalesClassCodes = DataGridViewProductionCommission_SalesClasses.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList
                _ProductionCommissionFunctionCodes = DataGridViewProductionCommission_Functions.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList
                _ServiceFeeTypeCodes = DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToList
                _ServiceFeeReconciliationGroupByOption = ComboBoxRightSection_GroupBy.GetSelectedValue
                _ServiceFeeReconciliationSummaryStyle = ComboBoxRightSection_SummaryStyle.GetSelectedValue

            End If

            ProcessServiceFeeReconciliationReport = Process

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef FeePostPeriodFrom As AdvantageFramework.Database.Entities.PostPeriod, ByRef FeePostPeriodTo As AdvantageFramework.Database.Entities.PostPeriod,
                                              ByRef SelectedCriteria As IEnumerable, ByRef FeeTimeFrom As Date, ByRef FeeTimeTo As Date,
                                              ByRef IncomeOnlySalesClassCodes As Generic.List(Of String), ByRef IncomeOnlyFunctionCodes As Generic.List(Of String),
                                              ByRef ProductionCommissionSalesClassCodes As Generic.List(Of String), ByRef ProductionCommissionFunctionCodes As Generic.List(Of String),
                                              ByRef ServiceFeeTypeCodes As Generic.List(Of String),
                                              ByRef ServiceFeeReconciliationGroupByOption As AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions,
                                              ByRef ServiceFeeReconciliationSummaryStyle As AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles) As System.Windows.Forms.DialogResult

            'objects
            Dim ServiceFeeReconciliationForm As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm = Nothing

            ServiceFeeReconciliationForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm(True)

            ShowFormDialog = ServiceFeeReconciliationForm.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                FeePostPeriodFrom = ServiceFeeReconciliationForm.FeePostPeriodFrom
                FeePostPeriodTo = ServiceFeeReconciliationForm.FeePostPeriodTo
                SelectedCriteria = ServiceFeeReconciliationForm.SelectedCriteria.OfType(Of Object).ToList
                FeeTimeFrom = ServiceFeeReconciliationForm.FeeTimeFrom
                FeeTimeTo = ServiceFeeReconciliationForm.FeeTimeTo
                IncomeOnlySalesClassCodes = ServiceFeeReconciliationForm.IncomeOnlySalesClassCodes.ToList
                IncomeOnlyFunctionCodes = ServiceFeeReconciliationForm.IncomeOnlyFunctionCodes.ToList
                ProductionCommissionSalesClassCodes = ServiceFeeReconciliationForm.ProductionCommissionSalesClassCodes.ToList
                ProductionCommissionFunctionCodes = ServiceFeeReconciliationForm.ProductionCommissionFunctionCodes.ToList
                ServiceFeeTypeCodes = ServiceFeeReconciliationForm.ServiceFeeTypeCodes.ToList
                ServiceFeeReconciliationGroupByOption = ServiceFeeReconciliationForm.ServiceFeeReconciliationGroupByOption
                ServiceFeeReconciliationSummaryStyle = ServiceFeeReconciliationForm.ServiceFeeReconciliationSummaryStyle

            End If

            Try

                ServiceFeeReconciliationForm.Dispose()

            Catch ex As Exception

            End Try

            Try

                ServiceFeeReconciliationForm = Nothing

            Catch ex As Exception

            End Try

        End Function
        Public Shared Sub ShowForm()

            'objects
            Dim ServiceFeeReconciliationForm As AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm = Nothing

            ServiceFeeReconciliationForm = New AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationForm(False)

            ServiceFeeReconciliationForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub ServiceFeeReconciliationForm_BeforeFormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            SaveServiceFeeReconciliationSettings()

        End Sub
        Private Sub ServiceFeeReconciliationForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim SalesClassList As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing
            Dim FunctionList As Generic.List(Of AdvantageFramework.Database.Entities.Function) = Nothing
            Dim ServiceFeeReconciliationSetting As AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSetting = Nothing
            Dim ServiceFeeReconciliationSettingDetialsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetail) = Nothing
            Dim ServiceFeeReconciliationSettingCDPsList As Generic.List(Of AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDP) = Nothing
            Dim RowHandle As Integer = 0

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage

            Me.ShowUnsavedChangesOnFormClosing = False

            DataGridViewStandardFee_Functions.ShowSelectDeselectAllButtons = True
            DataGridViewStandardFee_SalesClasses.ShowSelectDeselectAllButtons = True
            DataGridViewProductionCommission_Functions.ShowSelectDeselectAllButtons = True
            DataGridViewProductionCommission_SalesClasses.ShowSelectDeselectAllButtons = True
            DataGridViewSelectionCriteria_Criteria.ShowSelectDeselectAllButtons = True

            ComboBoxRightSection_GroupBy.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ServiceFeeReconciliationGroupByOptions))
            ComboBoxRightSection_SummaryStyle.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.ServiceFeeReconciliationSummaryStyles))

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SalesClassList = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

                DataGridViewStandardFee_SalesClasses.DataSource = SalesClassList
                DataGridViewProductionCommission_SalesClasses.DataSource = SalesClassList

                DataGridViewStandardFee_SalesClasses.CurrentView.BestFitColumns()
                DataGridViewProductionCommission_SalesClasses.CurrentView.BestFitColumns()

                DataGridViewStandardFee_SalesClasses.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                DataGridViewProductionCommission_SalesClasses.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                FunctionList = AdvantageFramework.Database.Procedures.Function.Load(DbContext).ToList

                DataGridViewStandardFee_Functions.DataSource = FunctionList.Where(Function([Function]) [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.I.ToString).ToList
                DataGridViewProductionCommission_Functions.DataSource = FunctionList.Where(Function([Function]) [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.V.ToString).ToList

                DataGridViewStandardFee_Functions.CurrentView.BestFitColumns()
                DataGridViewProductionCommission_Functions.CurrentView.BestFitColumns()

                DataGridViewStandardFee_Functions.CurrentView.AFActiveFilterString = "[IsInactive] = False"
                DataGridViewProductionCommission_Functions.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.DataSource = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList

                DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.BestFitColumns()

                DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            End Using

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ServiceFeeReconciliationSetting = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSetting.LoadByUserCode(SecurityDbContext, Me.Session.UserCode)

                If ServiceFeeReconciliationSetting IsNot Nothing Then

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 0 Then

                        RadioButtonServiceFeeTypeCriteria_None.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 1 Then

                        RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 2 Then

                        RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 3 Then

                        RadioButtonServiceFeeTypeCriteria_JobComponent.Checked = True

                    End If

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) > 0 Then

                        DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.ClearSelection()

                        ServiceFeeReconciliationSettingDetialsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.LoadByUserCodeAndType(SecurityDbContext, Me.Session.UserCode, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.SERVICE_FEE_TYPE.ToString).ToList

                        If ServiceFeeReconciliationSettingDetialsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingDetialsList.Count > 0 Then

                            For RowHandle = 0 To DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.RowCount - 1

                                If ServiceFeeReconciliationSettingDetialsList.Any(Function(SFRSDetail) SFRSDetail.Code = DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.GetRowBookmarkValue(RowHandle)) Then

                                    DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.SelectRow(RowHandle)

                                    DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.CurrentView.FocusedRowHandle = RowHandle

                                End If

                            Next

                        End If

                    End If

                    If ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption.GetValueOrDefault(4) = 4 Then

                        RadioButtonSelectionCriteria_All.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption.GetValueOrDefault(4) = 3 Then

                        RadioButtonSelectionCriteria_ClientDivisionProduct.Checked = True

                        ServiceFeeReconciliationSettingCDPsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.LoadByUserID(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivisionProduct).ToList

                        If ServiceFeeReconciliationSettingCDPsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingCDPsList.Count > 0 Then

                            For RowHandle = 0 To DataGridViewSelectionCriteria_Criteria.CurrentView.RowCount - 1

                                If ServiceFeeReconciliationSettingCDPsList.Any(Function(SFRSCDP) SFRSCDP.ClientCode = DataGridViewSelectionCriteria_Criteria.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Product.Properties.ClientCode.ToString) AndAlso
                                                                                                 SFRSCDP.DivisionCode = DataGridViewSelectionCriteria_Criteria.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Product.Properties.DivisionCode.ToString) AndAlso
                                                                                                 SFRSCDP.ProductCode = DataGridViewSelectionCriteria_Criteria.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Product.Properties.Code.ToString)) Then

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.SelectRow(RowHandle)

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.FocusedRowHandle = RowHandle

                                End If

                            Next

                        End If

                    ElseIf ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption.GetValueOrDefault(4) = 2 Then

                        RadioButtonSelectionCriteria_ClientDivision.Checked = True

                        ServiceFeeReconciliationSettingCDPsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.LoadByUserID(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.ClientDivision).ToList

                        If ServiceFeeReconciliationSettingCDPsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingCDPsList.Count > 0 Then

                            For RowHandle = 0 To DataGridViewSelectionCriteria_Criteria.CurrentView.RowCount - 1

                                If ServiceFeeReconciliationSettingCDPsList.Any(Function(SFRSCDP) SFRSCDP.ClientCode = DataGridViewSelectionCriteria_Criteria.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Division.Properties.ClientCode.ToString) AndAlso
                                                                                                 SFRSCDP.DivisionCode = DataGridViewSelectionCriteria_Criteria.CurrentView.GetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.Division.Properties.Code.ToString)) Then

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.SelectRow(RowHandle)

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.FocusedRowHandle = RowHandle

                                End If

                            Next

                        End If

                    ElseIf ServiceFeeReconciliationSetting.ClientDivisionProductIncludeOption.GetValueOrDefault(4) = 1 Then

                        RadioButtonSelectionCriteria_Client.Checked = True

                        ServiceFeeReconciliationSettingCDPsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingCDP.LoadByUserID(SecurityDbContext, Me.Session.User.ID, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingCDPTypes.Client).ToList

                        If ServiceFeeReconciliationSettingCDPsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingCDPsList.Count > 0 Then

                            For RowHandle = 0 To DataGridViewSelectionCriteria_Criteria.CurrentView.RowCount - 1

                                If ServiceFeeReconciliationSettingCDPsList.Any(Function(SFRSCDP) SFRSCDP.ClientCode = DataGridViewSelectionCriteria_Criteria.GetRowBookmarkValue(RowHandle)) Then

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.SelectRow(RowHandle)

                                    DataGridViewSelectionCriteria_Criteria.CurrentView.FocusedRowHandle = RowHandle

                                End If

                            Next

                        End If

                    End If

                    ComboBoxRightSection_GroupBy.SelectedValue = ServiceFeeReconciliationSetting.GroupByOption.GetValueOrDefault(1).ToString

                    CheckBoxRightSection_IncludeServiceFeeTypeLevel.Checked = ServiceFeeReconciliationSetting.IncludeServiceFeeTypeLevel

                    If ServiceFeeReconciliationSetting.ServiceFeeTypeSelection.GetValueOrDefault(0) = 0 Then

                        CheckBoxRightSection_IncludeServiceFeeTypeLevel.Checked = False
                        CheckBoxRightSection_IncludeServiceFeeTypeLevel.Enabled = False

                    End If

                    CheckBoxRightSection_AddFeeDescriptionToGroupBy.Checked = ServiceFeeReconciliationSetting.AddFeeDescriptionToGroupBy

                    ComboBoxRightSection_SummaryStyle.SelectedValue = ServiceFeeReconciliationSetting.SummaryStyle.GetValueOrDefault(1).ToString

                    If ServiceFeeReconciliationSetting.IncludeIncomeOnly.GetValueOrDefault(0) = 1 Then

                        CheckBoxStandardFee_StandardFee.Checked = True

                        If ServiceFeeReconciliationSetting.IncomeOnlyJobCompMarkedAsFee.GetValueOrDefault(0) = 1 Then

                            CheckBoxStandardFee_AllComponentsMarkedAsFee.Checked = True

                        Else

                            CheckBoxStandardFee_AllComponentsMarkedAsFee.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnSalesClass.GetValueOrDefault(0) = 1 Then

                            CheckBoxStandardFee_PostedBasedOnSalesClass.Checked = True

                            DataGridViewStandardFee_SalesClasses.CurrentView.ClearSelection()

                            ServiceFeeReconciliationSettingDetialsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.LoadByUserCodeAndType(SecurityDbContext, Me.Session.UserCode, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_SC.ToString).ToList

                            If ServiceFeeReconciliationSettingDetialsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingDetialsList.Count > 0 Then

                                For RowHandle = 0 To DataGridViewStandardFee_SalesClasses.CurrentView.RowCount - 1

                                    If ServiceFeeReconciliationSettingDetialsList.Any(Function(SFRSDetail) SFRSDetail.Code = DataGridViewStandardFee_SalesClasses.GetRowBookmarkValue(RowHandle)) Then

                                        DataGridViewStandardFee_SalesClasses.CurrentView.SelectRow(RowHandle)

                                        DataGridViewStandardFee_SalesClasses.CurrentView.FocusedRowHandle = RowHandle

                                    End If

                                Next

                            End If

                        Else

                            CheckBoxStandardFee_PostedBasedOnSalesClass.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.IncomeOnlyPostedBasedOnFunction.GetValueOrDefault(0) = 1 Then

                            CheckBoxStandardFee_PostedBasedOnFunctions.Checked = True

                            DataGridViewStandardFee_Functions.CurrentView.ClearSelection()

                            ServiceFeeReconciliationSettingDetialsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.LoadByUserCodeAndType(SecurityDbContext, Me.Session.UserCode, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.STD_FEE_FUNC.ToString).ToList

                            If ServiceFeeReconciliationSettingDetialsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingDetialsList.Count > 0 Then

                                For RowHandle = 0 To DataGridViewStandardFee_Functions.CurrentView.RowCount - 1

                                    If ServiceFeeReconciliationSettingDetialsList.Any(Function(SFRSDetail) SFRSDetail.Code = DataGridViewStandardFee_Functions.GetRowBookmarkValue(RowHandle)) Then

                                        DataGridViewStandardFee_Functions.CurrentView.SelectRow(RowHandle)

                                        DataGridViewStandardFee_Functions.CurrentView.FocusedRowHandle = RowHandle

                                    End If

                                Next

                            End If

                        Else

                            CheckBoxStandardFee_PostedBasedOnFunctions.Checked = False

                        End If

                    Else

                        CheckBoxStandardFee_StandardFee.Checked = False
                        CheckBoxStandardFee_AllComponentsMarkedAsFee.Checked = False
                        CheckBoxStandardFee_PostedBasedOnSalesClass.Checked = False
                        CheckBoxStandardFee_PostedBasedOnFunctions.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeProductionCommission.GetValueOrDefault(0) = 1 Then

                        CheckBoxProductionCommission_ProductionCommission.Checked = True

                        If ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnSalesClass.GetValueOrDefault(0) = 1 Then

                            CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked = True

                            DataGridViewProductionCommission_SalesClasses.CurrentView.ClearSelection()

                            ServiceFeeReconciliationSettingDetialsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.LoadByUserCodeAndType(SecurityDbContext, Me.Session.UserCode, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_SC.ToString).ToList

                            If ServiceFeeReconciliationSettingDetialsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingDetialsList.Count > 0 Then

                                For RowHandle = 0 To DataGridViewProductionCommission_SalesClasses.CurrentView.RowCount - 1

                                    If ServiceFeeReconciliationSettingDetialsList.Any(Function(SFRSDetail) SFRSDetail.Code = DataGridViewProductionCommission_SalesClasses.GetRowBookmarkValue(RowHandle)) Then

                                        DataGridViewProductionCommission_SalesClasses.CurrentView.SelectRow(RowHandle)

                                        DataGridViewProductionCommission_SalesClasses.CurrentView.FocusedRowHandle = RowHandle

                                    End If

                                Next

                            End If

                        Else

                            CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.ProductionCommissionPostedBasedOnFunction.GetValueOrDefault(0) = 1 Then

                            CheckBoxProductionCommission_PostedBasedOnFunctions.Checked = True

                            DataGridViewProductionCommission_Functions.CurrentView.ClearSelection()

                            ServiceFeeReconciliationSettingDetialsList = AdvantageFramework.Security.Database.Procedures.ServiceFeeReconciliationSettingDetail.LoadByUserCodeAndType(SecurityDbContext, Me.Session.UserCode, AdvantageFramework.Security.Database.Entities.ServiceFeeReconciliationSettingDetailTypes.PROD_COMM_FUNC.ToString).ToList

                            If ServiceFeeReconciliationSettingDetialsList IsNot Nothing AndAlso ServiceFeeReconciliationSettingDetialsList.Count > 0 Then

                                For RowHandle = 0 To DataGridViewProductionCommission_Functions.CurrentView.RowCount - 1

                                    If ServiceFeeReconciliationSettingDetialsList.Any(Function(SFRSDetail) SFRSDetail.Code = DataGridViewProductionCommission_Functions.GetRowBookmarkValue(RowHandle)) Then

                                        DataGridViewProductionCommission_Functions.CurrentView.SelectRow(RowHandle)

                                        DataGridViewProductionCommission_Functions.CurrentView.FocusedRowHandle = RowHandle

                                    End If

                                Next

                            End If

                        Else

                            CheckBoxProductionCommission_PostedBasedOnFunctions.Checked = False

                        End If

                    Else

                        CheckBoxProductionCommission_ProductionCommission.Checked = False
                        CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked = False
                        CheckBoxProductionCommission_PostedBasedOnFunctions.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeMediaCommission.GetValueOrDefault(0) = 1 Then

                        CheckBoxMediaCommission_MediaCommission.Checked = True

                        If ServiceFeeReconciliationSetting.BroadcastCommission.GetValueOrDefault(0) = 1 Then

                            CheckBoxMediaCommission_Broadcast.Checked = True

                        Else

                            CheckBoxMediaCommission_Broadcast.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.MagazineCommission.GetValueOrDefault(0) = 1 Then

                            CheckBoxMediaCommission_Magazine.Checked = True

                        Else

                            CheckBoxMediaCommission_Magazine.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.NewspaperCommission.GetValueOrDefault(0) = 1 Then

                            CheckBoxMediaCommission_Newspaper.Checked = True

                        Else

                            CheckBoxMediaCommission_Newspaper.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.InternetCommission.GetValueOrDefault(0) = 1 Then

                            CheckBoxMediaCommission_Internet.Checked = True

                        Else

                            CheckBoxMediaCommission_Internet.Checked = False

                        End If

                        If ServiceFeeReconciliationSetting.OutOfHomeCommission.GetValueOrDefault(0) = 1 Then

                            CheckBoxMediaCommission_OutOfHome.Checked = True

                        Else

                            CheckBoxMediaCommission_OutOfHome.Checked = False

                        End If

                    Else

                        CheckBoxMediaCommission_MediaCommission.Checked = False
                        CheckBoxMediaCommission_Broadcast.Checked = False
                        CheckBoxMediaCommission_Magazine.Checked = False
                        CheckBoxMediaCommission_Newspaper.Checked = False
                        CheckBoxMediaCommission_Internet.Checked = False
                        CheckBoxMediaCommission_OutOfHome.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeUnreconciledOnly.GetValueOrDefault(0) = 1 Then

                        CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Checked = True

                    Else

                        CheckBoxFeeTimeCriteria_IncludeUnreconciledOnly.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeIncomeOnlyFeeTime.GetValueOrDefault(0) = 1 Then

                        CheckBoxFeeTimeCriteria_StandardFeeTime.Checked = True

                    Else

                        CheckBoxFeeTimeCriteria_StandardFeeTime.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeProductionCommissionFeeTime.GetValueOrDefault(0) = 1 Then

                        CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Checked = True

                    Else

                        CheckBoxFeeTimeCriteria_FeeTimeProductionCommission.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.IncludeMediaCommissionFeeTime.GetValueOrDefault(0) = 1 Then

                        CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Checked = True

                    Else

                        CheckBoxFeeTimeCriteria_FeeTimeMediaCommission.Checked = False

                    End If

                    If ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 1 Then

                        RadioButtonPrimaryDisplayOption_Client.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 2 Then

                        RadioButtonPrimaryDisplayOption_ClientDivision.Checked = True

                    ElseIf ServiceFeeReconciliationSetting.PrimaryDisplayOption.GetValueOrDefault(1) = 3 Then

                        RadioButtonPrimaryDisplayOption_ClientDivisionProduct.Checked = True

                    End If

                End If

            End Using

            TabControlForm_ServiceFeeReconciliation.SelectedTab = TabItemServiceFeeReconciliation_ServiceFeeTypeCriteriaTab

            TabControlFeeCriteria_Settings.SelectedTab = TabItemSettings_StandardFeeTab

            If Debugger.IsAttached Then

                TextBoxLeftSection_FeePeriodsFrom.Text = "200401"
                TextBoxLeftSection_FeePeriodsTo.Text = "201212"

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub RadioButtonSelectionCriteria_All_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectionCriteria_All.CheckedChanged

            If Me.HasLoaded AndAlso RadioButtonSelectionCriteria_All.Checked Then

                LoadCriteria()

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_Client_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectionCriteria_Client.CheckedChanged

            If Me.HasLoaded AndAlso RadioButtonSelectionCriteria_Client.Checked Then

                LoadCriteria()

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_ClientDivision_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectionCriteria_ClientDivision.CheckedChanged

            If Me.HasLoaded AndAlso RadioButtonSelectionCriteria_ClientDivision.Checked Then

                LoadCriteria()

            End If

        End Sub
        Private Sub RadioButtonSelectionCriteria_ClientDivisionProduct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonSelectionCriteria_ClientDivisionProduct.CheckedChanged

            If Me.HasLoaded AndAlso RadioButtonSelectionCriteria_ClientDivisionProduct.Checked Then

                LoadCriteria()

            End If

        End Sub
        Private Sub TextBoxSelectionCriteria_FeePeriodsFrom_TagObjectChanged() Handles TextBoxLeftSection_FeePeriodsFrom.TagObjectChanged

            If TextBoxLeftSection_FeePeriodsFrom.Tag IsNot Nothing AndAlso
                    TypeOf TextBoxLeftSection_FeePeriodsFrom.Tag Is AdvantageFramework.Database.Entities.PostPeriod Then

                DateTimePickerLeftSection_FeeTimePostedDateRangeFrom.Value = DirectCast(TextBoxLeftSection_FeePeriodsFrom.Tag, AdvantageFramework.Database.Entities.PostPeriod).StartDate

            End If

        End Sub
        Private Sub TextBoxSelectionCriteria_FeePeriodsTo_TagObjectChanged() Handles TextBoxLeftSection_FeePeriodsTo.TagObjectChanged

            If TextBoxLeftSection_FeePeriodsTo.Tag IsNot Nothing AndAlso
                    TypeOf TextBoxLeftSection_FeePeriodsTo.Tag Is AdvantageFramework.Database.Entities.PostPeriod Then

                DateTimePickerLeftSection_FeeTimePostedDateRangeTo.Value = DirectCast(TextBoxLeftSection_FeePeriodsTo.Tag, AdvantageFramework.Database.Entities.PostPeriod).EndDate

            End If

        End Sub
        Private Sub CheckBoxStandardFee_StandardFee_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxStandardFee_StandardFee.CheckedChanged

            CheckBoxStandardFee_AllComponentsMarkedAsFee.Enabled = CheckBoxStandardFee_StandardFee.Checked
            CheckBoxStandardFee_PostedBasedOnSalesClass.Enabled = CheckBoxStandardFee_StandardFee.Checked
            CheckBoxStandardFee_PostedBasedOnFunctions.Enabled = CheckBoxStandardFee_StandardFee.Checked

            DataGridViewStandardFee_Functions.Enabled = (CheckBoxStandardFee_StandardFee.Checked AndAlso CheckBoxStandardFee_PostedBasedOnFunctions.Checked)
            DataGridViewStandardFee_SalesClasses.Enabled = (CheckBoxStandardFee_StandardFee.Checked AndAlso CheckBoxStandardFee_PostedBasedOnSalesClass.Checked)

        End Sub
        Private Sub CheckBoxProductionCommission_ProductionCommission_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxProductionCommission_ProductionCommission.CheckedChanged

            CheckBoxProductionCommission_PostedBasedOnSalesClass.Enabled = CheckBoxProductionCommission_ProductionCommission.Checked
            CheckBoxProductionCommission_PostedBasedOnFunctions.Enabled = CheckBoxProductionCommission_ProductionCommission.Checked

            DataGridViewProductionCommission_Functions.Enabled = (CheckBoxProductionCommission_ProductionCommission.Checked AndAlso CheckBoxProductionCommission_PostedBasedOnFunctions.Checked)
            DataGridViewProductionCommission_SalesClasses.Enabled = (CheckBoxProductionCommission_ProductionCommission.Checked AndAlso CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked)

        End Sub
        Private Sub CheckBoxMediaCommission_MediaCommission_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxMediaCommission_MediaCommission.CheckedChanged

            CheckBoxMediaCommission_Broadcast.Enabled = CheckBoxMediaCommission_MediaCommission.Checked
            CheckBoxMediaCommission_Magazine.Enabled = CheckBoxMediaCommission_MediaCommission.Checked
            CheckBoxMediaCommission_Newspaper.Enabled = CheckBoxMediaCommission_MediaCommission.Checked
            CheckBoxMediaCommission_Internet.Enabled = CheckBoxMediaCommission_MediaCommission.Checked
            CheckBoxMediaCommission_OutOfHome.Enabled = CheckBoxMediaCommission_MediaCommission.Checked

        End Sub
        Private Sub CheckBoxStandardFee_PostedBasedOnSalesClass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxStandardFee_PostedBasedOnSalesClass.CheckedChanged

            DataGridViewStandardFee_SalesClasses.Enabled = CheckBoxStandardFee_PostedBasedOnSalesClass.Checked

        End Sub
        Private Sub CheckBoxStandardFee_PostedBasedOnFunctions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxStandardFee_PostedBasedOnFunctions.CheckedChanged

            DataGridViewStandardFee_Functions.Enabled = CheckBoxStandardFee_PostedBasedOnFunctions.Checked

        End Sub
        Private Sub CheckBoxProductionCommission_PostedBasedOnSalesClass_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxProductionCommission_PostedBasedOnSalesClass.CheckedChanged

            DataGridViewProductionCommission_SalesClasses.Enabled = CheckBoxProductionCommission_PostedBasedOnSalesClass.Checked

        End Sub
        Private Sub CheckBoxProductionCommission_PostedBasedOnFunctions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxProductionCommission_PostedBasedOnFunctions.CheckedChanged

            DataGridViewProductionCommission_Functions.Enabled = CheckBoxProductionCommission_PostedBasedOnFunctions.Checked

        End Sub
        Private Sub ButtonItemActions_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Process.Click

            If ProcessServiceFeeReconciliationReport() Then

                AdvantageFramework.FinanceAndAccounting.Presentation.ServiceFeeReconciliationReportForm.ShowFormDialog(_FeePostPeriodFrom, _FeePostPeriodTo, _SelectedCriteria, _FeeTimeFrom, _FeeTimeTo,
                                                                                                                       _IncomeOnlySalesClassCodes, _IncomeOnlyFunctionCodes,
                                                                                                                       _ProductionCommissionSalesClassCodes, _ProductionCommissionFunctionCodes,
                                                                                                                       _ServiceFeeTypeCodes, _ServiceFeeReconciliationGroupByOption, _ServiceFeeReconciliationSummaryStyle)

            End If

        End Sub
        Private Sub RadioButtonServiceFeeTypeCriteria_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonServiceFeeTypeCriteria_None.CheckedChanged,
                                                                                                                      RadioButtonServiceFeeTypeCriteria_EmployeeDefaultDepartment.CheckedChanged,
                                                                                                                      RadioButtonServiceFeeTypeCriteria_EmployeeTimeEntryDepartment.CheckedChanged,
                                                                                                                      RadioButtonServiceFeeTypeCriteria_JobComponent.CheckedChanged

            DataGridViewServiceFeeTypeCriteria_ServiceFeeTypes.Enabled = (RadioButtonServiceFeeTypeCriteria_None.Checked = False)

            If RadioButtonServiceFeeTypeCriteria_None.Checked Then

                CheckBoxRightSection_IncludeServiceFeeTypeLevel.Checked = False
                CheckBoxRightSection_IncludeServiceFeeTypeLevel.Enabled = False

            Else

                CheckBoxRightSection_IncludeServiceFeeTypeLevel.Enabled = True

            End If

        End Sub
        Private Sub ButtonForm_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Process.Click

            If ProcessServiceFeeReconciliationReport() Then

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
