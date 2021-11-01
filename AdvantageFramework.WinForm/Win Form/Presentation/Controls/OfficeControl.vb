Namespace WinForm.Presentation.Controls

    Public Class OfficeControl

        Public Event SelectedTabChanged()
        Public Event FunctionAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event FunctionAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SalesClassFunctionAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event SalesClassFunctionAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SalesClassFunctionAccountsSalesClassSelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SalesTaxAccountsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event SalesTaxAccountsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event SalesClassAccountsComboboxChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event OfficeInActiveChanged()
        Public Event SelectedDocumentChanged()
        Public Event OverheadSetsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event OverheadSetsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OfficeCode As String = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _OfficeFunctionAccountsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount) = Nothing
        Private _OfficeInterCompanyDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing
        Private _OfficeSalesClassFunctionAccountsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount) = Nothing
        Private _OfficeSalesTaxAccountsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount) = Nothing
        Private _CopyDefaultAccounts As Boolean = False
        Private _CopyDefaultProductionAccounts As Boolean = False
        Private _CopyProductionFunctionAccts As Boolean = False
        Private _CopyDefaultMediaAccounts As Boolean = False
        Private _CopySalesTaxAccts As Boolean = False
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False
        Private _ReplaceOfficeSegment As Boolean = False
        Private _HasAccessToDocuments As Boolean = False
        Private _GeneralLedgerOfficeSegmentRequired As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeFunctionAccountsHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewOfficeFunctionAccountsHasOnlyOneSelectedRow = DataGridViewFunctionAccounts_FunctionAccounts.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeFunctionAccountsIsNewItemRow() As Boolean
            Get
                DataGridViewOfficeFunctionAccountsIsNewItemRow = DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.IsNewItemRow(DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeFunctionAccountsHasRows As Boolean
            Get
                DataGridViewOfficeFunctionAccountsHasRows = DataGridViewFunctionAccounts_FunctionAccounts.HasRows
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeSalesClassFunctionAccountsHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewOfficeSalesClassFunctionAccountsHasOnlyOneSelectedRow = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeSalesClassFunctionAccountsIsNewItemRow() As Boolean
            Get
                DataGridViewOfficeSalesClassFunctionAccountsIsNewItemRow = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.IsNewItemRow(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DataGridViewOfficeSalesClassFunctionAccountsHasRows As Boolean
            Get
                DataGridViewOfficeSalesClassFunctionAccountsHasRows = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasRows
            End Get
        End Property
        Public ReadOnly Property DataGridViewSalesTaxAccountsIsNewItemRow() As Boolean
            Get
                DataGridViewSalesTaxAccountsIsNewItemRow = DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.IsNewItemRow(DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DataGridViewSalesTaxAccountsHasRows As Boolean
            Get
                DataGridViewSalesTaxAccountsHasRows = DataGridViewSalesTaxAccounts_SalesTaxAccounts.HasRows
            End Get
        End Property
        Public ReadOnly Property DataGridViewSalesTaxAccountsHasOnlyOneSelectedRow() As Boolean
            Get
                DataGridViewSalesTaxAccountsHasOnlyOneSelectedRow = DataGridViewSalesTaxAccounts_SalesTaxAccounts.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property CanCopyGLSalesClassFunctionAccounts As Boolean
            Get

                If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasRows OrElse
                        SearchableComboBoxSalesClassAccounts_ProductionSales.HasASelectedValue OrElse
                        SearchableComboBoxSalesClassAccounts_ProductionCOS.HasASelectedValue OrElse
                        SearchableComboBoxSalesClassAccounts_MediaSales.HasASelectedValue OrElse
                        SearchableComboBoxSalesClassAccounts_MediaCOS.HasASelectedValue Then

                    CanCopyGLSalesClassFunctionAccounts = False

                Else

                    CanCopyGLSalesClassFunctionAccounts = True

                End If

            End Get
        End Property
        Public ReadOnly Property DocumentManager As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_OfficeDocuments
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
            End Get
        End Property
        Public ReadOnly Property DataGridViewOverheadSetsIsNewItemRow() As Boolean
            Get
                DataGridViewOverheadSetsIsNewItemRow = DataGridViewOverheadSets_OverheadSets.CurrentView.IsNewItemRow(DataGridViewOverheadSets_OverheadSets.CurrentView.FocusedRowHandle)
            End Get
        End Property
        Public ReadOnly Property DataGridViewOverheadSetsHasRows As Boolean
            Get
                DataGridViewOverheadSetsHasRows = DataGridViewOverheadSets_OverheadSets.HasRows
            End Get
        End Property
        Public ReadOnly Property CanCopyGLFunctionAccounts As Boolean
            Get

                If DataGridViewFunctionAccounts_FunctionAccounts.HasRows Then

                    CanCopyGLFunctionAccounts = False

                Else

                    CanCopyGLFunctionAccounts = True

                End If

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

            Dim PropertyDescriptorsList As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Office)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            PropertyDescriptorsList = System.ComponentModel.TypeDescriptor.GetProperties(GetType(AdvantageFramework.Database.Entities.Office)).OfType(Of System.ComponentModel.PropertyDescriptor).ToList

                            '
                            ' PROPERTY SETTINGS
                            '
                            TextBoxControl_Code.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.Name)

                            _GeneralLedgerOfficeSegmentRequired = AdvantageFramework.GeneralLedger.GeneralLedgerConfigRequiresSegment(Me._Session, Database.Entities.GeneralLedgerConfigSegmentType.Office, Nothing)

                            ComboBoxControl_GLXREFCode.SetRequired(_GeneralLedgerOfficeSegmentRequired)

                            ' Default tab
                            SearchableComboBoxDefault_AccountsReceivableGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.AccountsReceivableGLACode)
                            SearchableComboBoxDefault_AccountsPayableGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.AccountsPayableGLACode)
                            SearchableComboBoxDefault_AccountsPayableDiscountGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.AccountsPayableDiscountGLACode)
                            SearchableComboBoxDefault_SuspenseGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.SuspenseGLACode)
                            SearchableComboBoxDefault_StateTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.StateTaxGLACode)
                            SearchableComboBoxDefault_CountyTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.CountyTaxGLACode)
                            SearchableComboBoxDefault_CityTaxGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.CityTaxGLACode)
                            SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ClientLatePaymentFeeGLACode)

                            'SearchableComboBoxDefault_CurrencyGainLossGLACode.SetRequired(AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext))

                            SearchableComboBoxViewDefault_AccountsPayableDiscountGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_AccountsPayableGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_AccountsReceivableGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_CityTaxGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_CountyTaxGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_StateTaxGLACode.IsInGridLookupEditControl = True
                            'SearchableComboBoxViewDefault_SuspenseGLACode.IsInGridLookupEditControl = True
                            SearchableComboBoxViewDefault_ClientLatePaymentFeeGLACode.IsInGridLookupEditControl = True

                            ' Production defaults tab
                            SearchableComboBoxProductionDefaults_Sales.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionSalesGLACode)
                            SearchableComboBoxProductionDefaults_COS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionCostOfSalesGLACode)
                            SearchableComboBoxProductionDefaults_WIP.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionWorkInProgressGLACode)
                            SearchableComboBoxProductionDefaults_DeferredSales.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionDeferredSalesGLACode)
                            SearchableComboBoxProductionDefaults_AccruedCOS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionAccruedCostOfSalesGLACode)
                            SearchableComboBoxProductionDefaults_AccruedAP.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionAccruedAccountsPayableGLACode)
                            SearchableComboBoxProductionDefaults_DeferredCOS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.ProductionDeferredCostOfSalesGLACode)

                            SearchableComboBoxViewProductionDefaults_AccruedAP.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_AccruedCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_COS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_DeferredCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_DeferredSales.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_Sales.IsInGridLookupEditControl = True
                            SearchableComboBoxViewProductionDefaults_WIP.IsInGridLookupEditControl = True

                            ' Function accounts tab
                            DataGridViewFunctionAccounts_FunctionAccounts.MultiSelect = True

                            ' Sales class/function accounts tab
                            SearchableComboBoxSalesClassFunctionAccounts_SalesClass.SetPropertySettings(AdvantageFramework.Database.Entities.OfficeSalesClassAccount.Properties.SalesClassCode)
                            SearchableComboBoxSalesClassFunctionAccounts_SalesClass.ByPassUserEntryChanged = True
                            SearchableComboBoxSalesClassFunctionAccounts_SalesClass.SetRequired(False)
                            SearchableComboBoxSalesClassAccounts_ProductionSales.SetPropertySettings(AdvantageFramework.Database.Entities.OfficeSalesClassAccount.Properties.ProductionSalesGLACode)
                            SearchableComboBoxSalesClassAccounts_ProductionCOS.SetPropertySettings(AdvantageFramework.Database.Entities.OfficeSalesClassAccount.Properties.ProductionCostOfSalesGLACode)
                            SearchableComboBoxSalesClassAccounts_MediaSales.SetPropertySettings(AdvantageFramework.Database.Entities.OfficeSalesClassAccount.Properties.MediaSalesGLACode)
                            SearchableComboBoxSalesClassAccounts_MediaCOS.SetPropertySettings(AdvantageFramework.Database.Entities.OfficeSalesClassAccount.Properties.MediaCostOfSalesGLACode)

                            SearchableComboBoxViewSalesClassAccounts_MediaCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewSalesClassAccounts_MediaSales.IsInGridLookupEditControl = True
                            SearchableComboBoxViewSalesClassAccounts_ProductionCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewSalesClassAccounts_ProductionSales.IsInGridLookupEditControl = True

                            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.MultiSelect = True
                            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AutoFilterLookupColumns = True

                            ' Media defaults tab
                            SearchableComboBoxMediaDefaults_Sales.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaSalesGLACode)
                            SearchableComboBoxMediaDefaults_COS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaCostOfSalesGLACode)
                            SearchableComboBoxMediaDefaults_WIP.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaWorkInProgressGLACode)
                            SearchableComboBoxMediaDefaults_DeferredSales.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaDeferredSalesGLACode)
                            SearchableComboBoxMediaDefaults_AccruedCOS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaAccruedCostOfSalesGLACode)
                            SearchableComboBoxMediaDefaults_AccruedAP.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaAccruedAccountsPayableGLACode)
                            SearchableComboBoxMediaDefaults_DeferredCOS.SetPropertySettings(PropertyDescriptorsList, AdvantageFramework.Database.Entities.Office.Properties.MediaDeferredCostOfSalesGLACode)

                            SearchableComboBoxViewMediaDefaults_AccruedAP.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_AccruedCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_COS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_DeferredCOS.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_DeferredSales.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_Sales.IsInGridLookupEditControl = True
                            SearchableComboBoxViewMediaDefaults_WIP.IsInGridLookupEditControl = True

                            ' Sales tax accounts tab
                            DataGridViewSalesTaxAccounts_SalesTaxAccounts.MultiSelect = False

                            ' inter-company accounts tab
                            DataGridViewInterCompanyAccounts_InterCompanyAccounts.MultiSelect = False

                            LoadDropDownDataSources()

                        End Using

                        CheckBoxControl_Inactive.ByPassUserEntryChanged = True

                        RadioButtonABIncomeRecognition_UponReconciliation.ByPassUserEntryChanged = True
                        RadioButtonABIncomeRecognition_InitalBilling.ByPassUserEntryChanged = True

                        RadioButtonPrebillIncomeRecognition_BillingDate.ByPassUserEntryChanged = True
                        RadioButtonPrebillIncomeRecognition_CloseDate.ByPassUserEntryChanged = True
                        RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.ByPassUserEntryChanged = True

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            Dim NonRequiredBackColor As System.Drawing.Color = Nothing

            NonRequiredBackColor = Windows.Forms.ComboBox.DefaultBackColor

            If SearchableComboBoxSalesClassAccounts_ProductionSales.GetSelectedValue IsNot Nothing OrElse SearchableComboBoxSalesClassAccounts_ProductionCOS.GetSelectedValue IsNot Nothing Then

                SearchableComboBoxSalesClassAccounts_ProductionSales.SetRequired(True)
                SearchableComboBoxSalesClassAccounts_ProductionCOS.SetRequired(True)

            Else

                SearchableComboBoxSalesClassAccounts_ProductionSales.SetRequired(False)
                SearchableComboBoxSalesClassAccounts_ProductionSales.BackColor = NonRequiredBackColor
                SearchableComboBoxSalesClassAccounts_ProductionCOS.SetRequired(False)
                SearchableComboBoxSalesClassAccounts_ProductionCOS.BackColor = NonRequiredBackColor

            End If

            If SearchableComboBoxSalesClassAccounts_MediaSales.GetSelectedValue IsNot Nothing OrElse SearchableComboBoxSalesClassAccounts_MediaCOS.GetSelectedValue IsNot Nothing Then

                SearchableComboBoxSalesClassAccounts_MediaSales.SetRequired(True)
                SearchableComboBoxSalesClassAccounts_MediaCOS.SetRequired(True)

            Else

                SearchableComboBoxSalesClassAccounts_MediaSales.SetRequired(False)
                SearchableComboBoxSalesClassAccounts_MediaSales.BackColor = NonRequiredBackColor
                SearchableComboBoxSalesClassAccounts_MediaCOS.SetRequired(False)
                SearchableComboBoxSalesClassAccounts_MediaCOS.BackColor = NonRequiredBackColor

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean, ByRef GeneralLedgerXrefCode As String) As AdvantageFramework.Database.Entities.Office

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            Try

                If IsNew Then

                    Office = New AdvantageFramework.Database.Entities.Office

                    LoadOfficeEntity(Office, True)

                    Office.IsInactive = If(CheckBoxControl_Inactive.Checked, 1, 0)
                    Office.Code = TextBoxControl_Code.Text
                    Office.Name = TextBoxControl_Description.Text

                    GeneralLedgerXrefCode = ComboBoxControl_GLXREFCode.GetSelectedValue

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, _OfficeCode)

                        If Office IsNot Nothing Then

                            LoadOfficeEntity(Office, False)

                            Office.IsInactive = If(CheckBoxControl_Inactive.Checked, 1, 0)

                            Office.Name = TextBoxControl_Description.Text

                        End If

                    End Using

                End If

            Catch ex As Exception
                Office = Nothing
            End Try

            FillObject = Office

        End Function
        Private Function FillOfficeSalesClassAccountObject() As AdvantageFramework.Database.Entities.OfficeSalesClassAccount

            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing

            If TabItemOffice_SalesClassFunctionAccountsTab.Tag = True Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue, _OfficeCode)

                        If OfficeSalesClassAccount Is Nothing Then

                            OfficeSalesClassAccount = New AdvantageFramework.Database.Entities.OfficeSalesClassAccount
                            OfficeSalesClassAccount.OfficeCode = _OfficeCode
                            OfficeSalesClassAccount.SalesClassCode = SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue

                        End If

                    End Using

                    If SearchableComboBoxSalesClassAccounts_ProductionSales.HasASelectedValue Then

                        OfficeSalesClassAccount.ProductionSalesGLACode = SearchableComboBoxSalesClassAccounts_ProductionSales.GetSelectedValue

                    Else

                        OfficeSalesClassAccount.ProductionSalesGLACode = Nothing

                    End If

                    If SearchableComboBoxSalesClassAccounts_ProductionCOS.HasASelectedValue Then

                        OfficeSalesClassAccount.ProductionCostOfSalesGLACode = SearchableComboBoxSalesClassAccounts_ProductionCOS.GetSelectedValue

                    Else

                        OfficeSalesClassAccount.ProductionCostOfSalesGLACode = Nothing

                    End If

                    If SearchableComboBoxSalesClassAccounts_MediaSales.HasASelectedValue Then

                        OfficeSalesClassAccount.MediaSalesGLACode = SearchableComboBoxSalesClassAccounts_MediaSales.GetSelectedValue

                    Else

                        OfficeSalesClassAccount.MediaSalesGLACode = Nothing

                    End If

                    If SearchableComboBoxSalesClassAccounts_MediaCOS.HasASelectedValue Then

                        OfficeSalesClassAccount.MediaCostOfSalesGLACode = SearchableComboBoxSalesClassAccounts_MediaCOS.GetSelectedValue

                    Else

                        OfficeSalesClassAccount.MediaCostOfSalesGLACode = Nothing

                    End If

                Catch ex As Exception
                    OfficeSalesClassAccount = Nothing
                End Try

            End If

            FillOfficeSalesClassAccountObject = OfficeSalesClassAccount

        End Function
        Private Sub InitializeOfficeInterCompany(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim OfficeInterCompanyDetails As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing
            Dim OfficeInterCompanyDetail As AdvantageFramework.Database.Classes.OfficeInterCompanyDetail = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing

            OfficeInterCompanyDetails = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail)

            For Each GeneralLedgerOfficeCrossReference In AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadOrderByOffice(DbContext)

                If GeneralLedgerOfficeCrossReference.OfficeCode IsNot Nothing Then

                    OfficeInterCompany = New AdvantageFramework.Database.Entities.OfficeInterCompany

                    OfficeInterCompany.Code = GeneralLedgerOfficeCrossReference.OfficeCode

                    OfficeInterCompanyDetail = New AdvantageFramework.Database.Classes.OfficeInterCompanyDetail(DbContext, OfficeInterCompany)

                    OfficeInterCompanyDetails.Add(OfficeInterCompanyDetail)

                End If

            Next

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.DataSource = OfficeInterCompanyDetails

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.BestFitColumns()

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.ValidateAllRows()

            RenameInterCompanyAccountsGridColumns()

        End Sub
        Private Sub LoadOfficeEntity(ByVal Office As AdvantageFramework.Database.Entities.Office, ByVal IsNew As Boolean)

            If Office IsNot Nothing Then

                If IsNew OrElse TabItemOffice_DefaultTab.Tag = True Then

                    SaveDefaultTab(Office)

                End If

                If IsNew OrElse TabItemOffice_ProductionDefaultsTab.Tag = True Then

                    SaveProductionDefaultsTab(Office)

                End If

                If IsNew OrElse TabItemOffice_FunctionAccountsTab.Tag = True Then

                    SaveFunctionAccountsTab()

                End If

                If IsNew OrElse TabItemOffice_SalesClassFunctionAccountsTab.Tag = True Then

                    SaveSalesClassFunctionAccountsTab()

                End If

                If IsNew OrElse TabItemOffice_MediaDefaultsTab.Tag = True Then

                    SaveMediaDefaultsTab(Office)

                End If

                If IsNew OrElse TabItemOffice_SalesTaxAccountsTab.Tag = True Then

                    SaveSalesTaxAccountsTab()

                End If

                If IsNew OrElse TabItemOffice_InterCompanyAccountsTab.Tag = True Then

                    SaveInterCompanyAccountsTab()

                End If

            End If

        End Sub
        Private Sub LoadEntityDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            If _OfficeCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, _OfficeCode)

                    If Office IsNot Nothing Then

                        If TabItem Is Nothing Then

                            For Each TabItem In TabControlControl_Office.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                                TabItem.Tag = False

                            Next

                            TabItem = TabControlControl_Office.SelectedTab

                        End If

                        If TabItem.Tag = False Then

                            If TabItem Is TabItemOffice_DefaultTab Then

                                If Not _IsCopy OrElse (_IsCopy AndAlso _CopyDefaultAccounts) Then

                                    LoadDefaultTab(Office)

                                End If

                            ElseIf TabItem Is TabItemOffice_FunctionAccountsTab Then

                                If Not _IsCopy Then

                                    LoadFunctionAccountsTab()

                                End If

                            ElseIf TabItem Is TabItemOffice_InterCompanyAccountsTab Then

                                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                                    If Not _IsCopy Then

                                        LoadInterCompanyAccounts()

                                    End If

                                End If

                            ElseIf TabItem Is TabItemOffice_MediaDefaultsTab Then

                                If Not _IsCopy OrElse (_IsCopy And _CopyDefaultMediaAccounts) Then

                                    LoadMediaDefaultsTab(Office)

                                End If

                            ElseIf TabItem Is TabItemOffice_ProductionDefaultsTab Then

                                If Not _IsCopy OrElse (_IsCopy And _CopyDefaultProductionAccounts) Then

                                    LoadProductionDefaultsTab(Office)

                                End If

                            ElseIf TabItem Is TabItemOffice_SalesClassFunctionAccountsTab Then

                                If Not _IsCopy Then

                                    LoadSalesClassFunctionAccountsTab()

                                End If

                            ElseIf TabItem Is TabItemOffice_SalesTaxAccountsTab Then

                                If Not _IsCopy Then

                                    LoadSalesTaxAccounts()

                                End If

                            ElseIf TabItem Is TabItemOffice_OverheadSetsTab Then

                                If Not _IsCopy Then

                                    LoadOverheadSetsTab()

                                End If

                            ElseIf TabItem Is TabItemOffice_DocumentsTab Then

                                If Not _IsCopy Then

                                    LoadDocumentsTab(Office)

                                End If

                            End If

                        End If

                    End If

                End Using

            End If

        End Sub
        'Private Function InterCompanyComplete(ByRef IsValid As Boolean) As String

        '    Dim OfficeInterCompanyDetails As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing
        '    Dim ErrorText As String = Nothing
        '    Dim PropertyErrorText As String = Nothing
        '    Dim FailedOnce As Boolean = False

        '    If TabItemOffice_InterCompanyAccountsTab.Tag = True OrElse DataGridViewInterCompanyAccounts_InterCompanyAccounts.HasAnyInvalidRows Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

        '                OfficeInterCompanyDetails = DataGridViewInterCompanyAccounts_InterCompanyAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail)().ToList

        '                For Each OfficeInterCompanyDetail In OfficeInterCompanyDetails

        '                    OfficeInterCompanyDetail.OfficeCode = TextBoxControl_Code.Text

        '                    PropertyErrorText = OfficeInterCompanyDetail.ValidateEntity(IsValid)

        '                    If IsValid = False Then

        '                        ErrorText = IIf(ErrorText = "", PropertyErrorText, ErrorText & Environment.NewLine & PropertyErrorText)

        '                        FailedOnce = True

        '                    End If

        '                Next

        '            End If

        '        End Using

        '    End If

        '    IsValid = Not FailedOnce

        '    InterCompanyComplete = ErrorText

        'End Function
        Private Sub LoadDefaultTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If Office IsNot Nothing Then

                SearchableComboBoxDefault_AccountsReceivableGLACode.SelectedValue = Office.AccountsReceivableGLACode
                SearchableComboBoxDefault_AccountsPayableGLACode.SelectedValue = Office.AccountsPayableGLACode
                SearchableComboBoxDefault_AccountsPayableDiscountGLACode.SelectedValue = Office.AccountsPayableDiscountGLACode
                SearchableComboBoxDefault_SuspenseGLACode.SelectedValue = Office.SuspenseGLACode
                SearchableComboBoxDefault_StateTaxGLACode.SelectedValue = Office.StateTaxGLACode
                SearchableComboBoxDefault_CountyTaxGLACode.SelectedValue = Office.CountyTaxGLACode
                SearchableComboBoxDefault_CityTaxGLACode.SelectedValue = Office.CityTaxGLACode
                'SearchableComboBoxDefault_CurrencyGainLossGLACode.SelectedValue = Office.CurrencyGainLossGLACode
                SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.SelectedValue = Office.ClientLatePaymentFeeGLACode

                TabItemOffice_DefaultTab.Tag = True

            End If

        End Sub
        Private Sub LoadProductionDefaultsTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If Office IsNot Nothing Then

                SearchableComboBoxProductionDefaults_Sales.SelectedValue = Office.ProductionSalesGLACode
                SearchableComboBoxProductionDefaults_COS.SelectedValue = Office.ProductionCostOfSalesGLACode
                SearchableComboBoxProductionDefaults_WIP.SelectedValue = Office.ProductionWorkInProgressGLACode
                SearchableComboBoxProductionDefaults_DeferredSales.SelectedValue = Office.ProductionDeferredSalesGLACode
                SearchableComboBoxProductionDefaults_AccruedCOS.SelectedValue = Office.ProductionAccruedCostOfSalesGLACode
                SearchableComboBoxProductionDefaults_AccruedAP.SelectedValue = Office.ProductionAccruedAccountsPayableGLACode
                SearchableComboBoxProductionDefaults_DeferredCOS.SelectedValue = Office.ProductionDeferredCostOfSalesGLACode
                'SearchableComboBoxProductionDefaults_AccruedSalesTax.SelectedValue = Office.ProductionAccruedSalesTaxGLACode

                If Office.ProductionAdvancedBillingIncome IsNot Nothing Then

                    _IsLoading = True

                    Select Case Office.ProductionAdvancedBillingIncome

                        Case AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation

                            RadioButtonABIncomeRecognition_UponReconciliation.Checked = True

                        Case AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling

                            RadioButtonABIncomeRecognition_InitalBilling.Checked = True

                    End Select

                    _IsLoading = False

                End If

                TabItemOffice_ProductionDefaultsTab.Tag = True

            End If

        End Sub
        Private Sub LoadFunctionAccountsTab()

            If _OfficeCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewFunctionAccounts_FunctionAccounts.DataSource = (From OFA In AdvantageFramework.Database.Procedures.OfficeFunctionAccount.LoadByOfficeCode(DbContext, _OfficeCode).ToList
                                                                                Select New AdvantageFramework.Database.Classes.OfficeFunctionAccount(OFA)).ToList

                End Using

                TabItemOffice_FunctionAccountsTab.Tag = True

            End If

            DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadOverheadSetsTab()

            If _OfficeCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        DataGridViewOverheadSets_OverheadSets.DataSource = (From OOS In AdvantageFramework.Database.Procedures.OfficeOverheadSet.LoadByOfficeCode(DataContext, _OfficeCode).ToList
                                                                            Select New AdvantageFramework.Database.Classes.OfficeOverheadSet(DbContext, OOS)).ToList

                    End Using

                End Using

                TabItemOffice_OverheadSetsTab.Tag = True

            End If

            DataGridViewOverheadSets_OverheadSets.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSalesClassFunctionAccounts()

            Dim OfficeSalesClassFunctionAccountDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount) = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            OfficeSalesClassFunctionAccountDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount)

            If _OfficeCode <> "" Then

                If SearchableComboBoxSalesClassFunctionAccounts_SalesClass.HasASelectedValue Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OfficeSalesClassFunctionAccountDetailsList.AddRange(From OSCFA In AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.LoadBySalesClassCodeOfficeCode(DbContext, SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue, _OfficeCode).ToList
                                                                            Select New AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount(OSCFA))

                    End Using

                End If

            End If

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.DataSource = OfficeSalesClassFunctionAccountDetailsList

            For Each GridColumn In DataGridViewGLSalesClassFunctionAccounts_GLSCFA.Columns

                If GridColumn.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.FunctionDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.ProductionCostOfSalesGLDescription.ToString OrElse
                        GridColumn.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.ProductionSalesGLDescription.ToString Then

                    GridColumn.OptionsColumn.AllowFocus = False

                End If
            Next

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSalesClassFunctionAccountsTab()

            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim SalesClassCode As String = Nothing

            If _OfficeCode <> "" Then

                SalesClassCode = SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue

                If SalesClassCode IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, SalesClassCode, _OfficeCode)

                        Try

                            SearchableComboBoxSalesClassAccounts_ProductionSales.ByPassUserEntryChanged = True
                            SearchableComboBoxSalesClassAccounts_ProductionCOS.ByPassUserEntryChanged = True
                            SearchableComboBoxSalesClassAccounts_MediaSales.ByPassUserEntryChanged = True
                            SearchableComboBoxSalesClassAccounts_MediaCOS.ByPassUserEntryChanged = True

                            If OfficeSalesClassAccount IsNot Nothing Then

                                SearchableComboBoxSalesClassAccounts_ProductionSales.SelectedValue = OfficeSalesClassAccount.ProductionSalesGLACode
                                SearchableComboBoxSalesClassAccounts_ProductionCOS.SelectedValue = OfficeSalesClassAccount.ProductionCostOfSalesGLACode
                                SearchableComboBoxSalesClassAccounts_MediaSales.SelectedValue = OfficeSalesClassAccount.MediaSalesGLACode
                                SearchableComboBoxSalesClassAccounts_MediaCOS.SelectedValue = OfficeSalesClassAccount.MediaCostOfSalesGLACode

                            Else

                                SearchableComboBoxSalesClassAccounts_ProductionSales.SelectedValue = Nothing
                                SearchableComboBoxSalesClassAccounts_ProductionCOS.SelectedValue = Nothing
                                SearchableComboBoxSalesClassAccounts_MediaSales.SelectedValue = Nothing
                                SearchableComboBoxSalesClassAccounts_MediaCOS.SelectedValue = Nothing

                            End If

                        Catch ex As Exception

                        Finally
                            SearchableComboBoxSalesClassAccounts_ProductionSales.ByPassUserEntryChanged = False
                            SearchableComboBoxSalesClassAccounts_ProductionCOS.ByPassUserEntryChanged = False
                            SearchableComboBoxSalesClassAccounts_MediaSales.ByPassUserEntryChanged = False
                            SearchableComboBoxSalesClassAccounts_MediaCOS.ByPassUserEntryChanged = False
                        End Try

                    End Using

                End If

                TabItemOffice_SalesClassFunctionAccountsTab.Tag = True

            End If

            LoadSalesClassFunctionAccounts()

        End Sub
        Private Sub LoadMediaDefaultsTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If Office IsNot Nothing Then

                SearchableComboBoxMediaDefaults_Sales.SelectedValue = Office.MediaSalesGLACode
                SearchableComboBoxMediaDefaults_COS.SelectedValue = Office.MediaCostOfSalesGLACode
                SearchableComboBoxMediaDefaults_WIP.SelectedValue = Office.MediaWorkInProgressGLACode
                SearchableComboBoxMediaDefaults_DeferredSales.SelectedValue = Office.MediaDeferredSalesGLACode
                SearchableComboBoxMediaDefaults_AccruedCOS.SelectedValue = Office.MediaAccruedCostOfSalesGLACode
                SearchableComboBoxMediaDefaults_AccruedAP.SelectedValue = Office.MediaAccruedAccountsPayableGLACode
                SearchableComboBoxMediaDefaults_DeferredCOS.SelectedValue = Office.MediaDeferredCostOfSalesGLACode
                'SearchableComboBoxMediaDefaults_AccruedSalesTax.SelectedValue = Office.MediaAccruedSalesTaxGLACode

                If Office.MediaAdvancedBillingIncome IsNot Nothing Then

                    _IsLoading = True

                    Select Case Office.MediaAdvancedBillingIncome

                        Case AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.BillingDate

                            RadioButtonPrebillIncomeRecognition_BillingDate.Checked = True

                        Case AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.InsertionBroadcast

                            RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Checked = True

                        Case AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.CloseDate

                            RadioButtonPrebillIncomeRecognition_CloseDate.Checked = True

                    End Select

					GroupBoxMediaDefaults_PrebillIncomeRecognition.Tag = Office.MediaAdvancedBillingIncome

					_IsLoading = False

                End If

                TabItemOffice_MediaDefaultsTab.Tag = True

            End If

        End Sub
        Private Sub LoadDocumentsTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            DocumentManagerControlDocuments_OfficeDocuments.ClearControl()

            DocumentManagerControlDocuments_OfficeDocuments.Enabled = (Office IsNot Nothing)

            If DocumentManagerControlDocuments_OfficeDocuments.Enabled Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Office) With {.OfficeCode = Office.Code}

                DocumentManagerControlDocuments_OfficeDocuments.Enabled = DocumentManagerControlDocuments_OfficeDocuments.LoadControl(Database.Entities.DocumentLevel.Office, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

                TabItemOffice_DocumentsTab.Tag = True

            End If

        End Sub
        Private Sub LoadSalesTaxAccounts()

            Dim OfficeSalesTaxAccounts As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount) = Nothing

            OfficeSalesTaxAccounts = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount)

            If _OfficeCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OfficeSalesTaxAccounts.AddRange(From OfficeSalesTaxAccount In AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.LoadByOfficeCode(DbContext, _OfficeCode).ToList
                                                    Select New AdvantageFramework.Database.Classes.OfficeSalesTaxAccount(DbContext, OfficeSalesTaxAccount))

                End Using

                TabItemOffice_SalesTaxAccountsTab.Tag = True

            End If

            DataGridViewSalesTaxAccounts_SalesTaxAccounts.DataSource = OfficeSalesTaxAccounts

            DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadInterCompanyAccounts()

            Dim OfficeInterCompanyDetails As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing
            Dim OfficeCodes As Generic.List(Of String) = Nothing
            Dim OfficeInterCompanyNew As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeInterCompanyDetail As AdvantageFramework.Database.Classes.OfficeInterCompanyDetail = Nothing

            OfficeInterCompanyDetails = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail)

            If _OfficeCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OfficeInterCompanyDetails.AddRange(From OfficeInterCompany In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, _OfficeCode).ToList
                                                       Select New AdvantageFramework.Database.Classes.OfficeInterCompanyDetail(DbContext, OfficeInterCompany))

                    OfficeCodes = DbContext.Database.SqlQuery(Of String)(String.Format("select OFFICE_CODE from OFFICE where OFFICE_CODE not in (select INTER_CO_CODE from OFF_INTER_CO a where OFFICE_CODE ='{0}') and OFFICE_CODE <> '{0}'", _OfficeCode)).ToList

                    For Each OfficeCode In OfficeCodes

                        OfficeInterCompanyNew = New AdvantageFramework.Database.Entities.OfficeInterCompany
                        OfficeInterCompanyNew.OfficeCode = _OfficeCode
                        OfficeInterCompanyNew.Code = OfficeCode
                        OfficeInterCompanyDetail = New AdvantageFramework.Database.Classes.OfficeInterCompanyDetail(DbContext, OfficeInterCompanyNew)

                        OfficeInterCompanyDetails.Add(OfficeInterCompanyDetail)

                    Next

                End Using

                TabItemOffice_InterCompanyAccountsTab.Tag = True

            End If

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.DataSource = OfficeInterCompanyDetails

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.BestFitColumns()

            DataGridViewInterCompanyAccounts_InterCompanyAccounts.ValidateAllRows()

            RenameInterCompanyAccountsGridColumns()

        End Sub
        Private Sub RenameInterCompanyAccountsGridColumns()

            Dim OfficeInterCompanyDetailList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                    If DataGridViewInterCompanyAccounts_InterCompanyAccounts.Columns(AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueFromGLACode.ToString) IsNot Nothing Then

                        DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.Columns(AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueFromGLACode.ToString).Caption = "Office '" & TextBoxControl_Code.Text & "' Account"

                        DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.BestFitColumns()

                    End If

                    OfficeInterCompanyDetailList = DataGridViewInterCompanyAccounts_InterCompanyAccounts.GetAllRowsDataBoundItems().OfType(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail).ToList()

                    For Each OfficeInterCompanyDetail In OfficeInterCompanyDetailList

                        If TextBoxControl_Code.GetText <> "" Then

                            OfficeInterCompanyDetail.OfficeCode = TextBoxControl_Code.GetText
                            OfficeInterCompanyDetail.ValidateEntity(True)

                        End If

                    Next

                End If

            End Using

        End Sub
        Private Sub ReplaceAllGLAccountOfficeSegments()

            Dim GeneralLedgerConfig As AdvantageFramework.Database.Entities.GeneralLedgerConfig = Nothing
            Dim OfficeSegment As String = Nothing

            If AdvantageFramework.GeneralLedger.GeneralLedgerConfigRequiresSegment(_Session, Database.Entities.GeneralLedgerConfigSegmentType.Office, Nothing) AndAlso
                    ComboBoxControl_GLXREFCode.HasASelectedValue Then

                OfficeSegment = ComboBoxControl_GLXREFCode.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_AccountsReceivableGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_AccountsPayableGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_AccountsPayableDiscountGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_SuspenseGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_StateTaxGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_CountyTaxGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_CityTaxGLACode, OfficeSegment)
                    'ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_CurrencyGainLossGLACode, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxDefault_ClientLatePaymentFeeGLACode, OfficeSegment)

                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_Sales, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_COS, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_WIP, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_DeferredSales, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_AccruedCOS, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_AccruedAP, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxProductionDefaults_DeferredCOS, OfficeSegment)

                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_Sales, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_COS, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_WIP, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_DeferredSales, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_AccruedCOS, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_AccruedAP, OfficeSegment)
                    ReplaceOfficeSegment(DbContext, SearchableComboBoxMediaDefaults_DeferredCOS, OfficeSegment)

                End Using

            End If

        End Sub
        Private Sub ReplaceOfficeSegment(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef Combo As SearchableComboBox, ByVal OfficeSegment As String)

            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            If Combo.HasASelectedValue Then

                GeneralLedgerAccount = AdvantageFramework.GeneralLedger.SubstituteOfficeSegment(DbContext, Combo.GetSelectedValue, OfficeSegment)

                If GeneralLedgerAccount IsNot Nothing Then

                    Combo.SelectedValue = GeneralLedgerAccount.Code

                End If

            End If

        End Sub
        Private Sub SaveDefaultTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If Office IsNot Nothing Then

                If SearchableComboBoxDefault_AccountsReceivableGLACode.HasASelectedValue Then

                    Office.AccountsReceivableGLACode = SearchableComboBoxDefault_AccountsReceivableGLACode.GetSelectedValue

                Else

                    Office.AccountsReceivableGLACode = Nothing

                End If

                If SearchableComboBoxDefault_AccountsPayableGLACode.HasASelectedValue Then

                    Office.AccountsPayableGLACode = SearchableComboBoxDefault_AccountsPayableGLACode.GetSelectedValue

                Else

                    Office.AccountsPayableGLACode = Nothing

                End If

                If SearchableComboBoxDefault_AccountsPayableDiscountGLACode.HasASelectedValue Then

                    Office.AccountsPayableDiscountGLACode = SearchableComboBoxDefault_AccountsPayableDiscountGLACode.GetSelectedValue

                Else

                    Office.AccountsPayableDiscountGLACode = Nothing

                End If

                If SearchableComboBoxDefault_SuspenseGLACode.HasASelectedValue Then

                    Office.SuspenseGLACode = SearchableComboBoxDefault_SuspenseGLACode.GetSelectedValue

                Else

                    Office.SuspenseGLACode = Nothing

                End If

                'If SearchableComboBoxDefault_CurrencyGainLossGLACode.HasASelectedValue Then

                '    Office.CurrencyGainLossGLACode = SearchableComboBoxDefault_CurrencyGainLossGLACode.GetSelectedValue

                'Else

                '    Office.CurrencyGainLossGLACode = Nothing

                'End If

                If SearchableComboBoxDefault_StateTaxGLACode.HasASelectedValue Then

                    Office.StateTaxGLACode = SearchableComboBoxDefault_StateTaxGLACode.GetSelectedValue

                Else

                    Office.StateTaxGLACode = Nothing

                End If

                If SearchableComboBoxDefault_CountyTaxGLACode.HasASelectedValue Then

                    Office.CountyTaxGLACode = SearchableComboBoxDefault_CountyTaxGLACode.GetSelectedValue

                Else

                    Office.CountyTaxGLACode = Nothing

                End If

                If SearchableComboBoxDefault_CityTaxGLACode.HasASelectedValue Then

                    Office.CityTaxGLACode = SearchableComboBoxDefault_CityTaxGLACode.GetSelectedValue

                Else

                    Office.CityTaxGLACode = Nothing

                End If

                If SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.HasASelectedValue Then

                    Office.ClientLatePaymentFeeGLACode = SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.GetSelectedValue

                Else

                    Office.ClientLatePaymentFeeGLACode = Nothing

                End If

            End If

        End Sub
        Private Sub SaveProductionDefaultsTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If SearchableComboBoxProductionDefaults_Sales.HasASelectedValue Then

                Office.ProductionSalesGLACode = SearchableComboBoxProductionDefaults_Sales.GetSelectedValue

            Else

                Office.ProductionSalesGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_COS.HasASelectedValue Then

                Office.ProductionCostOfSalesGLACode = SearchableComboBoxProductionDefaults_COS.GetSelectedValue

            Else

                Office.ProductionCostOfSalesGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_WIP.HasASelectedValue Then

                Office.ProductionWorkInProgressGLACode = SearchableComboBoxProductionDefaults_WIP.GetSelectedValue

            Else

                Office.ProductionWorkInProgressGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_DeferredSales.HasASelectedValue Then

                Office.ProductionDeferredSalesGLACode = SearchableComboBoxProductionDefaults_DeferredSales.GetSelectedValue

            Else

                Office.ProductionDeferredSalesGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_AccruedCOS.HasASelectedValue Then

                Office.ProductionAccruedCostOfSalesGLACode = SearchableComboBoxProductionDefaults_AccruedCOS.GetSelectedValue

            Else

                Office.ProductionAccruedCostOfSalesGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_AccruedAP.HasASelectedValue Then

                Office.ProductionAccruedAccountsPayableGLACode = SearchableComboBoxProductionDefaults_AccruedAP.GetSelectedValue

            Else

                Office.ProductionAccruedAccountsPayableGLACode = Nothing

            End If

            If SearchableComboBoxProductionDefaults_DeferredCOS.HasASelectedValue Then

                Office.ProductionDeferredCostOfSalesGLACode = SearchableComboBoxProductionDefaults_DeferredCOS.GetSelectedValue

            Else

                Office.ProductionDeferredCostOfSalesGLACode = Nothing

            End If

            'If SearchableComboBoxProductionDefaults_AccruedSalesTax.HasASelectedValue Then

            '    Office.ProductionAccruedSalesTaxGLACode = SearchableComboBoxProductionDefaults_AccruedSalesTax.GetSelectedValue

            'Else

            '    Office.ProductionAccruedSalesTaxGLACode = Nothing

            'End If

            If RadioButtonABIncomeRecognition_InitalBilling.Checked Then

                Office.ProductionAdvancedBillingIncome = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling

            ElseIf RadioButtonABIncomeRecognition_UponReconciliation.Checked Then

                Office.ProductionAdvancedBillingIncome = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation

            End If

        End Sub
        Private Sub SaveFunctionAccountsTab()

            'objects
            Dim OfficeFunctionAccountDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount) = Nothing

            If DataGridViewFunctionAccounts_FunctionAccounts.HasRows Then

                DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.CloseEditorForUpdating()

                OfficeFunctionAccountDetailsList = DataGridViewFunctionAccounts_FunctionAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount)().ToList

                _OfficeFunctionAccountsList = OfficeFunctionAccountDetailsList

            Else

                _OfficeFunctionAccountsList = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount)

            End If

        End Sub
        Private Sub SaveSalesClassFunctionAccountsTab()

            Dim OfficeSalesClassFunctionAccountsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount) = Nothing

            If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasRows Then

                DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.CloseEditorForUpdating()

                OfficeSalesClassFunctionAccountsList = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount)().ToList

                _OfficeSalesClassFunctionAccountsList = OfficeSalesClassFunctionAccountsList

            Else

                _OfficeSalesClassFunctionAccountsList = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount)

            End If

        End Sub
        Private Sub SaveMediaDefaultsTab(ByVal Office As AdvantageFramework.Database.Entities.Office)

            If SearchableComboBoxMediaDefaults_Sales.HasASelectedValue Then

                Office.MediaSalesGLACode = SearchableComboBoxMediaDefaults_Sales.GetSelectedValue

            Else

                Office.MediaSalesGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_COS.HasASelectedValue Then

                Office.MediaCostOfSalesGLACode = SearchableComboBoxMediaDefaults_COS.GetSelectedValue

            Else

                Office.MediaCostOfSalesGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_WIP.HasASelectedValue Then

                Office.MediaWorkInProgressGLACode = SearchableComboBoxMediaDefaults_WIP.GetSelectedValue

            Else

                Office.MediaWorkInProgressGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_DeferredSales.HasASelectedValue Then

                Office.MediaDeferredSalesGLACode = SearchableComboBoxMediaDefaults_DeferredSales.GetSelectedValue

            Else

                Office.MediaDeferredSalesGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_AccruedCOS.HasASelectedValue Then

                Office.MediaAccruedCostOfSalesGLACode = SearchableComboBoxMediaDefaults_AccruedCOS.GetSelectedValue

            Else

                Office.MediaAccruedCostOfSalesGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_AccruedAP.HasASelectedValue Then

                Office.MediaAccruedAccountsPayableGLACode = SearchableComboBoxMediaDefaults_AccruedAP.GetSelectedValue

            Else

                Office.MediaAccruedAccountsPayableGLACode = Nothing

            End If

            If SearchableComboBoxMediaDefaults_DeferredCOS.HasASelectedValue Then

                Office.MediaDeferredCostOfSalesGLACode = SearchableComboBoxMediaDefaults_DeferredCOS.GetSelectedValue

            Else

                Office.MediaDeferredCostOfSalesGLACode = Nothing

            End If

            'If SearchableComboBoxMediaDefaults_AccruedSalesTax.HasASelectedValue Then

            '    Office.MediaAccruedSalesTaxGLACode = SearchableComboBoxMediaDefaults_AccruedSalesTax.GetSelectedValue

            'Else

            '    Office.MediaAccruedSalesTaxGLACode = Nothing

            'End If

            If RadioButtonPrebillIncomeRecognition_BillingDate.Checked Then

                Office.MediaAdvancedBillingIncome = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.BillingDate

            ElseIf RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Checked Then

                Office.MediaAdvancedBillingIncome = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.InsertionBroadcast

            ElseIf RadioButtonPrebillIncomeRecognition_CloseDate.Checked Then

                Office.MediaAdvancedBillingIncome = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.CloseDate

            End If

        End Sub
        Private Sub SaveSalesTaxAccountsTab()

            Dim OfficeSalesTaxAccounts As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount) = Nothing

            If DataGridViewSalesTaxAccounts_SalesTaxAccounts.HasRows Then

                DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.CloseEditorForUpdating()

                OfficeSalesTaxAccounts = DataGridViewSalesTaxAccounts_SalesTaxAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount)().ToList

                _OfficeSalesTaxAccountsList = OfficeSalesTaxAccounts

            Else

                _OfficeSalesTaxAccountsList = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount)

            End If

        End Sub
        Private Sub SaveInterCompanyAccountsTab()

            'objects
            Dim OfficeInterCompanyDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) AndAlso DataGridViewInterCompanyAccounts_InterCompanyAccounts.HasRows Then

                    DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.CloseEditorForUpdating()

                    OfficeInterCompanyDetailsList = DataGridViewInterCompanyAccounts_InterCompanyAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail)().ToList

                    _OfficeInterCompanyDetailsList = OfficeInterCompanyDetailsList

                Else

                    _OfficeInterCompanyDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.OfficeInterCompanyDetail)

                End If

            End Using

        End Sub
        Private Sub SaveOffice(ByVal OfficeProperty As AdvantageFramework.Database.Entities.Office.Properties, ByVal NewValue As Object)

            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, _OfficeCode)

                If Office IsNot Nothing Then

                    Try

                        PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(Office).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                              Where [Property].Name = OfficeProperty.ToString
                                              Select [Property]).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        PropertyDescriptor.SetValue(Office, NewValue)

                    End If

                    AdvantageFramework.Database.Procedures.Office.Update(DbContext, Office)

                End If

            End Using

        End Sub
        Private Sub SetGeneralLedgerAccountDataSource(ByVal SearchableCombobox As AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox, ByRef DataSourceSet As Boolean)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _OfficeCode <> "" Then

                    SearchableCombobox.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext), _Session.AccessibleGLOfficeCodes, _Session.HasLimitedOfficeCodes).Select(Function(Entity) New With {Entity.Code, Entity.Description}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                                                                                                                                                                                                                                                                       .Description = Entity.Description}).ToList

                Else

                    SearchableCombobox.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Select(Function(Entity) New With {Entity.Code, Entity.Description}).Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                                                                                                                                                   .Description = Entity.Description}).ToList

                End If

            End Using

            DataSourceSet = True

        End Sub
        Private Function ValidateControl(ByRef ErrorText As String) As Boolean

            Dim IsInterCompanyValid As Boolean = True
            Dim IsValid As Boolean = False

            DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.CloseEditorForUpdating()
            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.CloseEditorForUpdating()
            DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.CloseEditorForUpdating()
            DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.CloseEditorForUpdating()

            If TabItemOffice_InterCompanyAccountsTab.Tag = True Then

                DataGridViewInterCompanyAccounts_InterCompanyAccounts.ValidateAllRows()

                ErrorText = If(DataGridViewInterCompanyAccounts_InterCompanyAccounts.HasAnyInvalidRows = True, "Fix inter-company grid errors.", "")

                IsInterCompanyValid = Not DataGridViewInterCompanyAccounts_InterCompanyAccounts.HasAnyInvalidRows()

            End If

            If Me.Validate AndAlso IsInterCompanyValid Then

                IsValid = True

            End If

            ValidateControl = IsValid

        End Function
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ' QueryPopupNeedDataSource event will force reset
                SearchableComboBoxDefault_AccountsReceivableGLACode.DataSource = Nothing
                SearchableComboBoxDefault_AccountsPayableGLACode.DataSource = Nothing
                SearchableComboBoxDefault_AccountsPayableDiscountGLACode.DataSource = Nothing
                SearchableComboBoxDefault_CityTaxGLACode.DataSource = Nothing
                SearchableComboBoxDefault_CountyTaxGLACode.DataSource = Nothing
                SearchableComboBoxDefault_StateTaxGLACode.DataSource = Nothing
                SearchableComboBoxDefault_SuspenseGLACode.DataSource = Nothing
                'SearchableComboBoxDefault_CurrencyGainLossGLACode.DataSource = Nothing
                SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.DataSource = Nothing
                SearchableComboBoxMediaDefaults_AccruedAP.DataSource = Nothing
                SearchableComboBoxMediaDefaults_AccruedCOS.DataSource = Nothing
                SearchableComboBoxMediaDefaults_COS.DataSource = Nothing
                SearchableComboBoxMediaDefaults_DeferredCOS.DataSource = Nothing
                SearchableComboBoxMediaDefaults_DeferredSales.DataSource = Nothing
                SearchableComboBoxMediaDefaults_Sales.DataSource = Nothing
                SearchableComboBoxMediaDefaults_WIP.DataSource = Nothing
                SearchableComboBoxProductionDefaults_AccruedAP.DataSource = Nothing
                SearchableComboBoxProductionDefaults_AccruedCOS.DataSource = Nothing
                SearchableComboBoxProductionDefaults_COS.DataSource = Nothing
                SearchableComboBoxProductionDefaults_DeferredCOS.DataSource = Nothing
                SearchableComboBoxProductionDefaults_DeferredSales.DataSource = Nothing
                SearchableComboBoxProductionDefaults_Sales.DataSource = Nothing
                SearchableComboBoxProductionDefaults_WIP.DataSource = Nothing
                SearchableComboBoxSalesClassAccounts_MediaCOS.DataSource = Nothing
                SearchableComboBoxSalesClassAccounts_MediaSales.DataSource = Nothing
                SearchableComboBoxSalesClassAccounts_ProductionCOS.DataSource = Nothing
                SearchableComboBoxSalesClassAccounts_ProductionSales.DataSource = Nothing

                SearchableComboBoxSalesClassFunctionAccounts_SalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext)

            End Using

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim OfficeInterCompany As AdvantageFramework.Database.Entities.OfficeInterCompany = Nothing
            Dim OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet = Nothing

            If ValidateControl(ErrorMessage) Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Office = Me.FillObject(False, "")

                        If Office IsNot Nothing Then

                            Try

                                DbContext.Database.Connection.Open()

                                DataContext.Connection.Open()

                                DbTransaction = DbContext.Database.BeginTransaction

                                If AdvantageFramework.Database.Procedures.Office.Update(DbContext, Office) = False Then

                                    Throw New Exception("Failed to update Office.")

                                End If

                                If _OfficeFunctionAccountsList IsNot Nothing Then

                                    For Each OfficeFunctionAccount In _OfficeFunctionAccountsList

                                        DbContext.UpdateObject(OfficeFunctionAccount.OfficeFunctionAccount)

                                    Next

                                    DbContext.SaveChanges()

                                End If

                                OfficeSalesClassAccount = Me.FillOfficeSalesClassAccountObject

                                If OfficeSalesClassAccount IsNot Nothing Then

                                    If Me.DataGridViewOfficeSalesClassFunctionAccountsHasRows = False AndAlso
                                        OfficeSalesClassAccount.MediaCostOfSalesGLACode Is Nothing AndAlso
                                        OfficeSalesClassAccount.MediaSalesGLACode Is Nothing AndAlso
                                        OfficeSalesClassAccount.ProductionCostOfSalesGLACode Is Nothing AndAlso
                                        OfficeSalesClassAccount.ProductionSalesGLACode Is Nothing Then

                                        OfficeSalesClassAccount = AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, OfficeSalesClassAccount.SalesClassCode, OfficeSalesClassAccount.OfficeCode)

                                        If OfficeSalesClassAccount IsNot Nothing Then

                                            If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Delete(DbContext, OfficeSalesClassAccount) = False Then

                                                Throw New Exception("Failed to delete Office Sales Class Account.")

                                            End If

                                        End If

                                    Else

                                        If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, OfficeSalesClassAccount.SalesClassCode, OfficeSalesClassAccount.OfficeCode) Is Nothing Then

                                            OfficeSalesClassAccount.DbContext = DbContext

                                            If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Insert(DbContext, OfficeSalesClassAccount) = False Then

                                                Throw New Exception("Failed to insert Office Sales Class Account.")

                                            End If

                                        Else

                                            If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Update(DbContext, OfficeSalesClassAccount) = False Then

                                                Throw New Exception("Failed to update Office Sales Class Account.")

                                            End If

                                        End If

                                        If _OfficeSalesClassFunctionAccountsList IsNot Nothing Then

                                            For Each OfficeSalesClassFunctionAccount In _OfficeSalesClassFunctionAccountsList

                                                DbContext.UpdateObject(OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount)

                                            Next

                                            DbContext.SaveChanges()

                                        End If

                                    End If

                                End If

                                If _OfficeSalesTaxAccountsList IsNot Nothing Then

                                    For Each OfficeSalesTaxAccount In _OfficeSalesTaxAccountsList

                                        DbContext.UpdateObject(OfficeSalesTaxAccount.OfficeSalesTaxAccount)

                                    Next

                                    DbContext.SaveChanges()

                                End If

                                If _OfficeInterCompanyDetailsList IsNot Nothing Then

                                    For Each OfficeInterCompanyDetail In _OfficeInterCompanyDetailsList

                                        If OfficeInterCompanyDetail.DueFromGLACode IsNot Nothing AndAlso OfficeInterCompanyDetail.DueToGLACode IsNot Nothing Then

                                            OfficeInterCompanyDetail.OfficeInterCompany.DbContext = DbContext

                                            OfficeInterCompanyDetail.OfficeInterCompany.DueFromGLACode = OfficeInterCompanyDetail.DueFromGLACode
                                            OfficeInterCompanyDetail.OfficeInterCompany.DueToGLACode = OfficeInterCompanyDetail.DueToGLACode

                                            If OfficeInterCompanyDetail.OfficeInterCompany.IsEntityBeingAdded() Then

                                                If AdvantageFramework.Database.Procedures.OfficeInterCompany.Insert(DbContext, OfficeInterCompanyDetail.OfficeInterCompany) = False Then

                                                    Throw New Exception("Failed to insert Office Inter Company.")

                                                End If

                                            Else

                                                If AdvantageFramework.Database.Procedures.OfficeInterCompany.Update(DbContext, OfficeInterCompanyDetail.OfficeInterCompany) = False Then

                                                    Throw New Exception("Failed to update Office Inter Company.")

                                                End If

                                            End If

                                        Else

                                            OfficeInterCompany = (From OI In AdvantageFramework.Database.Procedures.OfficeInterCompany.LoadByOfficeCode(DbContext, OfficeInterCompanyDetail.OfficeCode)
                                                                  Where OI.Code = OfficeInterCompanyDetail.Code
                                                                  Select OI).SingleOrDefault

                                            If OfficeInterCompany IsNot Nothing Then

                                                If AdvantageFramework.Database.Procedures.OfficeInterCompany.Delete(DbContext, OfficeInterCompany) = False Then

                                                    Throw New Exception("Failed to delete Office Inter Company.")

                                                End If

                                            End If

                                        End If

                                    Next

                                End If

                                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE dbo.OFF_ASSIGN WHERE OFF_CODE = '{0}'", Office.Code))

                                DbTransaction.Commit()

                                Saved = True

                            Catch ex As Exception
                                DbTransaction.Rollback()
                                ErrorMessage = "Failed trying to save to the database. Please contact software support."
                            Finally

                                If DbContext.Database.Connection.State = ConnectionState.Open Then

                                    DbContext.Database.Connection.Close()

                                End If

                                If DataContext.Connection.State = ConnectionState.Open Then

                                    DataContext.Connection.Close()

                                End If

                            End Try

                        End If

                    End Using

                End Using

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Office = Me.FillObject(False, "")

                    If Office IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Office.Delete(DbContext, Office)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The office is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef OfficeCode As String, ByVal CopyProductionFunctionAccts As Boolean, ByVal CopySalesTaxAccts As Boolean,
                               ByVal CopyMediaSalesClassAccts As Boolean, ByVal CopyProductionSalesClassFunctionAccts As Boolean) As Boolean

            'objects
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GeneralLedgerOfficeCrossReference As AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference = Nothing
            Dim GeneralLedgerXrefCode As String = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing
            Dim OfficeSegment As String = Nothing

            If ValidateControl(ErrorMessage) Then

                OfficeSegment = ComboBoxControl_GLXREFCode.GetSelectedValue

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Office = Me.FillObject(True, GeneralLedgerXrefCode)

                    If Office IsNot Nothing Then

                        Try

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            Office.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.Office.Insert(DbContext, Office) = False Then

                                Throw New Exception("Failed to Insert Office.")

                            End If

                            For Each OfficeInterCompanyDetail In _OfficeInterCompanyDetailsList

                                If OfficeInterCompanyDetail.DueFromGLACode IsNot Nothing AndAlso OfficeInterCompanyDetail.DueToGLACode IsNot Nothing Then

                                    OfficeInterCompanyDetail.OfficeInterCompany.DbContext = DbContext

                                    OfficeInterCompanyDetail.OfficeCode = Office.Code
                                    OfficeInterCompanyDetail.OfficeInterCompany.DueFromGLACode = OfficeInterCompanyDetail.DueFromGLACode
                                    OfficeInterCompanyDetail.OfficeInterCompany.DueToGLACode = OfficeInterCompanyDetail.DueToGLACode

                                    If AdvantageFramework.Database.Procedures.OfficeInterCompany.Insert(DbContext, OfficeInterCompanyDetail.OfficeInterCompany) = False Then

                                        Throw New Exception("Failed to Insert Office Inter Company.")

                                    End If

                                End If

                            Next

                            If _IsCopy AndAlso CopyProductionFunctionAccts Then

                                If AdvantageFramework.Database.Procedures.OfficeFunctionAccount.InsertFromExistingOffice(DbContext, _OfficeCode, Office.Code, _ReplaceOfficeSegment, OfficeSegment) = False Then

                                    Throw New Exception("Failed to Insert Office Function Account.")

                                End If

                            End If

                            If _IsCopy AndAlso CopySalesTaxAccts Then

                                If AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.InsertFromExistingOffice(DbContext, _OfficeCode, Office.Code) = False Then

                                    Throw New Exception("Failed to Insert Office Sales Tax Account.")

                                End If

                            End If

                            If _IsCopy AndAlso (CopyMediaSalesClassAccts OrElse CopyProductionSalesClassFunctionAccts) Then

                                If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.InsertFromExistingOffice(DbContext, _OfficeCode, Office.Code, CopyMediaSalesClassAccts, CopyProductionSalesClassFunctionAccts, _ReplaceOfficeSegment, OfficeSegment) = False Then

                                    Throw New Exception("Failed to Insert Office Sales Class Account.")

                                End If

                            End If

                            If _IsCopy AndAlso CopyProductionSalesClassFunctionAccts Then

                                If AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.InsertFromExistingOffice(DbContext, _OfficeCode, Office.Code, _ReplaceOfficeSegment, OfficeSegment) = False Then

                                    Throw New Exception("Failed to Insert Office Sales Class Function Account.")

                                End If

                            End If

                            If GeneralLedgerXrefCode IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByCode(DbContext, GeneralLedgerXrefCode) Is Nothing Then

                                    GeneralLedgerOfficeCrossReference = New AdvantageFramework.Database.Entities.GeneralLedgerOfficeCrossReference
                                    GeneralLedgerOfficeCrossReference.DbContext = DbContext

                                    GeneralLedgerOfficeCrossReference.Code = GeneralLedgerXrefCode
                                    GeneralLedgerOfficeCrossReference.OfficeCode = Office.Code
                                    GeneralLedgerOfficeCrossReference.UserCode = _Session.UserCode
                                    GeneralLedgerOfficeCrossReference.EnteredDate = Now.ToShortDateString

                                    If AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.Insert(DbContext, GeneralLedgerOfficeCrossReference) = False Then

                                        Throw New Exception("Failed to Insert GL Office Cross Reference.")

                                    End If

                                End If

                            End If

                            OfficeCode = Office.Code

                            DbTransaction.Commit()

                            Inserted = True

                        Catch ex As Exception
                            DbTransaction.Rollback()
                            ErrorMessage = "Failed trying to insert into the database. Please contact software support."
                            ErrorMessage += vbCrLf & ex.Message
                        Finally

                            If DbContext.Database.Connection.State = ConnectionState.Open Then

                                DbContext.Database.Connection.Close()

                            End If

                        End Try

                    End If

                End Using

            End If

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal OfficeCode As String, ByVal IsCopy As Boolean, ByVal CopyDefaultAccounts As Boolean, ByVal CopyDefaultProductionAccounts As Boolean, ByVal CopyDefaultMediaAccounts As Boolean, ByVal CopyProductionSalesClassAccts As Boolean, ByVal CopyProductionFunctionAccts As Boolean, ByVal CopyMediaSalesClassAccts As Boolean, ByVal CopySalesTaxAccts As Boolean, ByVal ReplaceOfficeSegment As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Office As AdvantageFramework.Database.Entities.Office = Nothing
            Dim GLCrossReferenceOfficeCodes As Generic.List(Of String) = Nothing

            _OfficeCode = OfficeCode
            _CopyDefaultAccounts = CopyDefaultAccounts
            _CopyDefaultProductionAccounts = CopyDefaultProductionAccounts
            _CopyProductionFunctionAccts = CopyProductionFunctionAccts
            _CopyDefaultMediaAccounts = CopyDefaultMediaAccounts
            _CopySalesTaxAccts = CopySalesTaxAccts
            _ReplaceOfficeSegment = ReplaceOfficeSegment
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _OfficeCode <> "" Then

                    TextBoxControl_Code.Enabled = IsCopy

                    Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, _OfficeCode)

                    If Office IsNot Nothing Then

                        _IsLoading = True

                        If IsCopy = False Then

                            TextBoxControl_Code.Text = Office.Code
                            TextBoxControl_Description.Text = Office.Name

                            ComboBoxControl_GLXREFCode.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerOfficeCrossReference.LoadByOfficeCode(DbContext, _OfficeCode)
                            ComboBoxControl_GLXREFCode.Enabled = False

                            TabItemOffice_DocumentsTab.Visible = _HasAccessToDocuments

                        Else

                            TabItemOffice_FunctionAccountsTab.Visible = False
                            TabItemOffice_SalesClassFunctionAccountsTab.Visible = False
                            TabItemOffice_SalesTaxAccountsTab.Visible = False
                            TabItemOffice_OverheadSetsTab.Visible = False
                            TabItemOffice_DocumentsTab.Visible = False

                            Try

                                GLCrossReferenceOfficeCodes = DbContext.Database.SqlQuery(Of String)("SELECT DISTINCT GLAOFFICE FROM dbo.GLACCOUNT a left join dbo.GLOXREF b on a.GLAOFFICE = b.GLOXGLOFFICE where b.GLOXGLOFFICE is null").ToList

                                ComboBoxControl_GLXREFCode.DataSource = GLCrossReferenceOfficeCodes

                            Catch ex As Exception
                                ComboBoxControl_GLXREFCode.DataSource = Nothing
                            End Try

                        End If

                        If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                            InitializeOfficeInterCompany(DbContext)

                        Else

                            TabItemOffice_InterCompanyAccountsTab.Visible = False

                        End If

                        CheckBoxControl_Inactive.Checked = Convert.ToBoolean(Office.IsInactive.GetValueOrDefault(0))

                        LoadEntityDetails(Nothing)

                        If IsCopy Then

                            For Each TabItem In TabControlControl_Office.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).ToList

                                If TabItem IsNot TabControlControl_Office.SelectedTab Then

                                    LoadEntityDetails(TabItem)

                                End If

                            Next

                            If _ReplaceOfficeSegment Then

                                ReplaceAllGLAccountOfficeSegments()

                            End If

                        End If

                        _IsLoading = False

                    Else

                        Loaded = False

                    End If

                Else

                    ' new office
                    TextBoxControl_Code.Enabled = True
                    ComboBoxControl_GLXREFCode.Enabled = _GeneralLedgerOfficeSegmentRequired
                    TabItemOffice_FunctionAccountsTab.Visible = False
                    TabItemOffice_SalesClassFunctionAccountsTab.Visible = False
                    TabItemOffice_SalesTaxAccountsTab.Visible = False
                    TabItemOffice_OverheadSetsTab.Visible = False
                    TabItemOffice_DocumentsTab.Visible = False
                    RadioButtonABIncomeRecognition_InitalBilling.Checked = True
                    RadioButtonPrebillIncomeRecognition_CloseDate.Checked = True

                    Try

                        GLCrossReferenceOfficeCodes = DbContext.Database.SqlQuery(Of String)("SELECT DISTINCT GLAOFFICE FROM dbo.GLACCOUNT a left join dbo.GLOXREF b on a.GLAOFFICE = b.GLOXGLOFFICE where b.GLOXGLOFFICE is null").ToList

                        ComboBoxControl_GLXREFCode.DataSource = GLCrossReferenceOfficeCodes

                    Catch ex As Exception
                        ComboBoxControl_GLXREFCode.DataSource = Nothing
                    End Try

                    If AdvantageFramework.Database.Procedures.Agency.IsInterCompanyTransactionsEnabled(DbContext) Then

                        InitializeOfficeInterCompany(DbContext)

                    Else

                        TabItemOffice_InterCompanyAccountsTab.Visible = False

                    End If

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub LoadRequiredNonGridControlsForValidation()

            If _OfficeCode <> "" Then

                If TabItemOffice_DefaultTab IsNot TabControlControl_Office.SelectedTab Then

                    LoadEntityDetails(TabItemOffice_DefaultTab)

                End If

                If TabItemOffice_ProductionDefaultsTab IsNot TabControlControl_Office.SelectedTab Then

                    LoadEntityDetails(TabItemOffice_ProductionDefaultsTab)

                End If

                If TabItemOffice_MediaDefaultsTab IsNot TabControlControl_Office.SelectedTab Then

                    LoadEntityDetails(TabItemOffice_MediaDefaultsTab)

                End If

            End If

        End Sub
        Public Sub ClearControl()

            _IsClearing = True

            TextBoxControl_Code.Text = Nothing
            TextBoxControl_Description.Text = Nothing
            ComboBoxControl_GLXREFCode.SelectedValue = Nothing
            CheckBoxControl_Inactive.Checked = False

            ' Default tab
            SearchableComboBoxDefault_AccountsReceivableGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_AccountsPayableGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_AccountsPayableDiscountGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_SuspenseGLACode.SelectedValue = Nothing
            'SearchableComboBoxDefault_CurrencyGainLossGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_StateTaxGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_CountyTaxGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_CityTaxGLACode.SelectedValue = Nothing
            SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.SelectedValue = Nothing

            ' Production defaults tab
            SearchableComboBoxProductionDefaults_Sales.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_COS.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_WIP.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_DeferredSales.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_AccruedCOS.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_AccruedAP.SelectedValue = Nothing
            SearchableComboBoxProductionDefaults_DeferredCOS.SelectedValue = Nothing
            'SearchableComboBoxProductionDefaults_AccruedSalesTax.SelectedValue = Nothing

            RadioButtonABIncomeRecognition_InitalBilling.Checked = False
            RadioButtonABIncomeRecognition_UponReconciliation.Checked = False

            ' Function accounts tab
            DataGridViewFunctionAccounts_FunctionAccounts.ClearGridCustomization()

            ' Sales class/function accounts tab

            With SearchableComboBoxSalesClassFunctionAccounts_SalesClass

                Try

                    If .DataSource IsNot Nothing Then

                        .SelectedValue = (From Item In DirectCast(DirectCast(.DataSource, System.Windows.Forms.BindingSource).DataSource, IEnumerable)
                                          Select Item.Code).First

                    End If

                Catch ex As Exception
                    .SelectedValue = Nothing
                End Try

            End With

            SearchableComboBoxSalesClassAccounts_ProductionSales.SelectedValue = Nothing
            SearchableComboBoxSalesClassAccounts_ProductionCOS.SelectedValue = Nothing
            SearchableComboBoxSalesClassAccounts_MediaSales.SelectedValue = Nothing
            SearchableComboBoxSalesClassAccounts_MediaCOS.SelectedValue = Nothing

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ClearGridCustomization()

            ' Media defaults tab
            SearchableComboBoxMediaDefaults_Sales.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_COS.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_WIP.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_DeferredSales.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_AccruedCOS.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_AccruedAP.SelectedValue = Nothing
            SearchableComboBoxMediaDefaults_DeferredCOS.SelectedValue = Nothing
            'SearchableComboBoxMediaDefaults_AccruedSalesTax.SelectedValue = Nothing

            RadioButtonPrebillIncomeRecognition_BillingDate.Checked = False
            RadioButtonPrebillIncomeRecognition_CloseDate.Checked = False
            RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Checked = False

            ' Sales tax accounts tab
            DataGridViewSalesTaxAccounts_SalesTaxAccounts.ClearGridCustomization()

            ' inter-company accounts tab
            DataGridViewInterCompanyAccounts_InterCompanyAccounts.ClearGridCustomization()

            ' documents tab
            DocumentManagerControlDocuments_OfficeDocuments.ClearControl()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

        End Sub
        Public Sub RefreshSalesClassTab()

            LoadSalesClassFunctionAccountsTab()

        End Sub
        Public Sub DeleteSelectedFunctionAccount()

            'objects
            Dim OfficeFunctionAccounts As Generic.List(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount) = Nothing
            Dim OfficeFunctionAccount As AdvantageFramework.Database.Entities.OfficeFunctionAccount = Nothing
            Dim FunctionCode As String = Nothing

            If DataGridViewFunctionAccounts_FunctionAccounts.HasASelectedRow Then

                DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    OfficeFunctionAccounts = DataGridViewFunctionAccounts_FunctionAccounts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount)().ToList

                    If _OfficeCode <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each OfficeFunctionAccountItem In OfficeFunctionAccounts

                                FunctionCode = OfficeFunctionAccountItem.FunctionCode

                                Try

                                    OfficeFunctionAccount = (From Entity In AdvantageFramework.Database.Procedures.OfficeFunctionAccount.LoadByOfficeCode(DbContext, _OfficeCode).ToList
                                                             Where Entity.FunctionCode = FunctionCode
                                                             Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    OfficeFunctionAccount = Nothing
                                End Try

                                If OfficeFunctionAccount IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.OfficeFunctionAccount.Delete(DbContext, OfficeFunctionAccount)

                                End If

                            Next

                        End Using

                        LoadFunctionAccountsTab()

                        Me.CloseWaitForm()

                    Else

                        DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.DeleteSelectedRows()

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewSalesClassFunctionAccount()

            DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedSalesClassFunctionAccount()

            'objects
            Dim OfficeSalesClassFunctionAccounts As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount) = Nothing
            Dim OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Entities.OfficeSalesClassFunctionAccount = Nothing
            Dim FunctionCode As String = Nothing

            If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.HasASelectedRow Then

                DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    OfficeSalesClassFunctionAccounts = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount)().ToList

                    If _OfficeCode <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each OfficeSalesClassFunctionAccountItem In OfficeSalesClassFunctionAccounts

                                FunctionCode = OfficeSalesClassFunctionAccountItem.FunctionCode

                                Try

                                    OfficeSalesClassFunctionAccount = (From Entity In AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.LoadBySalesClassCodeOfficeCode(DbContext, OfficeSalesClassFunctionAccountItem.OfficeSalesClassFunctionAccount.SalesClassCode, _OfficeCode).ToList
                                                                       Where Entity.FunctionCode = FunctionCode
                                                                       Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    OfficeSalesClassFunctionAccount = Nothing
                                End Try

                                If OfficeSalesClassFunctionAccount IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.Delete(DbContext, OfficeSalesClassFunctionAccount)

                                End If

                            Next

                        End Using

                        LoadSalesClassFunctionAccounts()

                        Me.CloseWaitForm()

                    Else

                        DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.DeleteSelectedRows()

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewFunctionAccount()

            DataGridViewFunctionAccounts_FunctionAccounts.CancelNewItemRow()

        End Sub
        Public Sub CancelAddNewSalesTaxAccount()

            DataGridViewSalesTaxAccounts_SalesTaxAccounts.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedSalesTaxAccount()

            'objects
            Dim OfficeSalesTaxAccounts As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount) = Nothing
            Dim OfficeSalesTaxAccount As AdvantageFramework.Database.Entities.OfficeSalesTaxAccount = Nothing
            Dim SalesTaxCode As String = Nothing

            If DataGridViewSalesTaxAccounts_SalesTaxAccounts.HasASelectedRow Then

                DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    OfficeSalesTaxAccounts = DataGridViewSalesTaxAccounts_SalesTaxAccounts.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount)().ToList

                    If _OfficeCode <> "" Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each OfficeSalesTaxAccountItem In OfficeSalesTaxAccounts

                                SalesTaxCode = OfficeSalesTaxAccountItem.SalesTaxCode

                                Try

                                    OfficeSalesTaxAccount = AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.LoadByOfficeCodeTaxCode(DbContext, _OfficeCode, OfficeSalesTaxAccountItem.SalesTaxCode)

                                Catch ex As Exception
                                    OfficeSalesTaxAccount = Nothing
                                End Try

                                If OfficeSalesTaxAccount IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.Delete(DbContext, OfficeSalesTaxAccount)

                                End If

                            Next

                        End Using

                        LoadSalesTaxAccounts()

                        Me.CloseWaitForm()

                    Else

                        DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.DeleteSelectedRows()

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddNewOverheadSet()

            DataGridViewOverheadSets_OverheadSets.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedOverheadSet()

            'objects
            Dim OfficeOverheadSets As Generic.List(Of AdvantageFramework.Database.Classes.OfficeOverheadSet) = Nothing
            Dim OfficeOverheadSet As AdvantageFramework.Database.Entities.OfficeOverheadSet = Nothing
            Dim OverheadSetCode As String = Nothing

            If DataGridViewOverheadSets_OverheadSets.HasASelectedRow Then

                DataGridViewOverheadSets_OverheadSets.CurrentView.CloseEditorForUpdating()

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.ShowWaitForm("Processing...")

                    OfficeOverheadSets = DataGridViewOverheadSets_OverheadSets.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeOverheadSet)().ToList

                    If _OfficeCode <> "" Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            For Each OfficeOverheadSetItem In OfficeOverheadSets

                                OverheadSetCode = OfficeOverheadSetItem.Code

                                Try

                                    OfficeOverheadSet = (From Entity In AdvantageFramework.Database.Procedures.OfficeOverheadSet.LoadByOfficeCode(DataContext, _OfficeCode).ToList
                                                         Where Entity.Code = OverheadSetCode
                                                         Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    OfficeOverheadSet = Nothing
                                End Try

                                If OfficeOverheadSet IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.OfficeOverheadSet.Delete(DataContext, OfficeOverheadSet)

                                End If

                            Next

                        End Using

                        LoadOverheadSetsTab()

                        Me.CloseWaitForm()

                    Else

                        DataGridViewOverheadSets_OverheadSets.CurrentView.DeleteSelectedRows()

                    End If

                End If

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub
        Public Sub RefreshFunctionAccountsTab()

            LoadFunctionAccountsTab()

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#Region "  Custom Control Event Handlers "

        Private Sub TabControlControl_GeneralInformation_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_Office.SelectedTabChanging

            If Me.FindForm IsNot Nothing Then

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = True

                LoadEntityDetails(e.NewTab)

                DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).SuspendedForLoading = False

                _SelectedTab = e.NewTab

            End If

            RaiseEvent SelectedTabChanged()

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewFunctionAccounts_FunctionAccounts.AddNewRowEvent

            Dim OfficeFunctionAccount As AdvantageFramework.Database.Classes.OfficeFunctionAccount = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OfficeFunctionAccount Then

                If _OfficeCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    OfficeFunctionAccount = RowObject

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            OfficeFunctionAccount.OfficeFunctionAccount.DbContext = DbContext
                            OfficeFunctionAccount.OfficeFunctionAccount.OfficeCode = _OfficeCode

                            If AdvantageFramework.Database.Procedures.OfficeFunctionAccount.Insert(DbContext, OfficeFunctionAccount.OfficeFunctionAccount) Then

                                LoadFunctionAccountsTab()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewFunctionAccounts_FunctionAccounts.BeforeAddNewRowEvent

            Dim OfficeFunctionAccount As AdvantageFramework.Database.Classes.OfficeFunctionAccount = Nothing

            OfficeFunctionAccount = DirectCast(RowObject, AdvantageFramework.Database.Classes.OfficeFunctionAccount)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.OfficeFunctionAccount.LoadByOfficeCode(DbContext, TextBoxControl_Code.Text).ToList
                    Where Entity.FunctionCode.ToUpper = OfficeFunctionAccount.FunctionCode.ToUpper
                    Select Entity).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                    OfficeFunctionAccount.FunctionCode = ""
                    OfficeFunctionAccount.FunctionDescription = Nothing

                    Cancel = True

                End If

            End Using

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewFunctionAccounts_FunctionAccounts.CellValueChangedEvent

            Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim OfficeFunctionAccount As AdvantageFramework.Database.Classes.OfficeFunctionAccount = Nothing
            Dim OfficeFunctionAccountList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount) = Nothing

            If TypeOf DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OfficeFunctionAccount Then

                OfficeFunctionAccount = DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.GetRow(e.RowHandle)

                If OfficeFunctionAccount IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeFunctionAccount.Properties.FunctionCode.ToString Then

                            OfficeFunctionAccountList = DataGridViewFunctionAccounts_FunctionAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeFunctionAccount).ToList

                            If (From OFA In OfficeFunctionAccountList
                                Where OFA.FunctionCode = e.Value
                                Select OFA).Count > 1 Then

                                AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                                OfficeFunctionAccount.FunctionCode = ""
                                OfficeFunctionAccount.FunctionDescription = Nothing

                            Else

                                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Value)

                                If [Function] IsNot Nothing Then

                                    OfficeFunctionAccount.FunctionDescription = [Function].Description

                                End If

                            End If

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeFunctionAccount.Properties.ProductionCostOfSalesGLACode.ToString Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GeneralLedgerAccount IsNot Nothing Then

                                OfficeFunctionAccount.ProductionCostOfSalesGLDescription = GeneralLedgerAccount.Description

                            End If

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeFunctionAccount.Properties.ProductionSalesGLACode.ToString Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GeneralLedgerAccount IsNot Nothing Then

                                OfficeFunctionAccount.ProductionSalesGLDescription = GeneralLedgerAccount.Description

                            End If

                        End If

                    End Using

                    DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.RefreshRow(e.RowHandle)

                End If

            End If

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewFunctionAccounts_FunctionAccounts.InitNewRowEvent

            RaiseEvent FunctionAccountsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewFunctionAccounts_FunctionAccounts.SelectionChangedEvent

            If DataGridViewFunctionAccounts_FunctionAccounts.CustomDeleteButton IsNot Nothing Then

                DataGridViewFunctionAccounts_FunctionAccounts.CustomDeleteButton.Enabled = Not DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.IsNewItemRow(DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent FunctionAccountsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.AddNewRowEvent

            Dim OfficeSalesClassAccount As AdvantageFramework.Database.Entities.OfficeSalesClassAccount = Nothing
            Dim OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount Then

                If _OfficeCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    OfficeSalesClassFunctionAccount = RowObject

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            If AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.LoadBySalesClassCodeOfficeCode(DbContext, OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount.SalesClassCode, OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount.OfficeCode) Is Nothing Then

                                OfficeSalesClassAccount = New AdvantageFramework.Database.Entities.OfficeSalesClassAccount
                                OfficeSalesClassAccount.DbContext = DbContext

                                OfficeSalesClassAccount.OfficeCode = OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount.OfficeCode
                                OfficeSalesClassAccount.SalesClassCode = OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount.SalesClassCode

                                AdvantageFramework.Database.Procedures.OfficeSalesClassAccount.Insert(DbContext, OfficeSalesClassAccount)

                            End If

                            OfficeSalesClassFunctionAccount.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.Insert(DbContext, OfficeSalesClassFunctionAccount.OfficeSalesClassFunctionAccount) Then

                                LoadSalesClassFunctionAccounts()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.BeforeAddNewRowEvent

            Dim OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount = Nothing

            OfficeSalesClassFunctionAccount = DirectCast(RowObject, AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.OfficeSalesClassFunctionAccount.LoadBySalesClassCodeOfficeCode(DbContext, SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue, _OfficeCode).ToList
                    Where Entity.FunctionCode.ToUpper = OfficeSalesClassFunctionAccount.FunctionCode.ToUpper
                    Select Entity).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                    OfficeSalesClassFunctionAccount.FunctionCode = ""
                    OfficeSalesClassFunctionAccount.FunctionDescription = Nothing

                    Cancel = True

                End If

            End Using

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CellValueChangedEvent

            Dim OfficeSalesClassFunctionAccountList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount) = Nothing
            Dim OfficeSalesClassFunctionAccount As AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount = Nothing
            Dim GeneralLedgerAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            If TypeOf DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount Then

                OfficeSalesClassFunctionAccount = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle)

                If OfficeSalesClassFunctionAccount IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.FunctionCode.ToString Then

                            OfficeSalesClassFunctionAccountList = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount).ToList

                            If (From OFA In OfficeSalesClassFunctionAccountList
                                Where OFA.FunctionCode = e.Value
                                Select OFA).Count > 1 Then

                                AdvantageFramework.WinForm.MessageBox.Show("Duplicate function code.")

                                OfficeSalesClassFunctionAccount.FunctionCode = ""
                                OfficeSalesClassFunctionAccount.FunctionDescription = Nothing

                            End If

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.ProductionCostOfSalesGLACode.ToString Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GeneralLedgerAccount IsNot Nothing Then

                                OfficeSalesClassFunctionAccount.ProductionCostOfSalesGLDescription = GeneralLedgerAccount.Description

                            End If

                        ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.ProductionSalesGLACode.ToString Then

                            GeneralLedgerAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GeneralLedgerAccount IsNot Nothing Then

                                OfficeSalesClassFunctionAccount.ProductionSalesGLDescription = GeneralLedgerAccount.Description

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.InitNewRowEvent

            DirectCast(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount).OfficeSalesClassFunctionAccount.OfficeCode = TextBoxControl_Code.Text
            DirectCast(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount).OfficeSalesClassFunctionAccount.SalesClassCode = SearchableComboBoxSalesClassFunctionAccounts_SalesClass.GetSelectedValue

            RaiseEvent FunctionAccountsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.SelectionChangedEvent

            If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CustomDeleteButton IsNot Nothing Then

                DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CustomDeleteButton.Enabled = Not DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.IsNewItemRow(DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent SalesClassFunctionAccountsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub SearchableComboBoxSalesClassFunctionAccounts_SalesClass_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSalesClassFunctionAccounts_SalesClass.EditValueChanged

            LoadSalesClassFunctionAccountsTab()

            RaiseEvent SalesClassFunctionAccountsSalesClassSelectedIndexChanged(sender, e)

        End Sub
        Private Sub TextBoxControl_Code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl_Code.TextChanged

            RenameInterCompanyAccountsGridColumns()

        End Sub
        Private Sub DataGridViewInterCompanyAccounts_InterCompanyAccounts_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewInterCompanyAccounts_InterCompanyAccounts.QueryPopupNeedDatasourceEvent

            Dim OfficeCode As String = Nothing

            OverrideDefaultDatasource = True

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueFromGLACode.ToString Then

                    If ComboBoxControl_GLXREFCode.HasASelectedValue Then

                        Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGeneralLedgerOfficeCrossReferenceCode(DbContext, ComboBoxControl_GLXREFCode.GetSelectedValue).ToList

                    End If

                ElseIf DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.DueToGLACode.ToString Then

                    OfficeCode = DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.GetRowCellValue(DataGridViewInterCompanyAccounts_InterCompanyAccounts.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Classes.OfficeInterCompanyDetail.Properties.Code.ToString)

                    If OfficeCode IsNot Nothing AndAlso OfficeCode <> "" Then

                        Datasource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByOfficeCode(DbContext, OfficeCode).ToList

                    Else

                        Datasource = Nothing

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_AddNewRowEvent(RowObject As Object) Handles DataGridViewOverheadSets_OverheadSets.AddNewRowEvent

            Dim OfficeOverheadSet As AdvantageFramework.Database.Classes.OfficeOverheadSet = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OfficeOverheadSet Then

                If _OfficeCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    OfficeOverheadSet = RowObject

                    Try

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            OfficeOverheadSet.DataContext = DataContext

                            If AdvantageFramework.Database.Procedures.OfficeOverheadSet.Insert(DataContext, OfficeOverheadSet.OfficeOverheadSet) Then

                                LoadOverheadSetsTab()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewOverheadSets_OverheadSets.BeforeAddNewRowEvent

            Dim OfficeOverheadSet As AdvantageFramework.Database.Classes.OfficeOverheadSet = Nothing
            Dim IsValid As Boolean = True

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OfficeOverheadSet Then

                OfficeOverheadSet = RowObject
                OfficeOverheadSet.Code = OfficeOverheadSet.OverheadAccountCode & _OfficeCode

                Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OfficeOverheadSet.DataContext = DataContext
                        OfficeOverheadSet.DbContext = DbContext
                        OfficeOverheadSet.ValidateEntity(IsValid)

                    End Using

                End Using

                If Not IsValid Then

                    Cancel = True

                End If

            End If

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewOverheadSets_OverheadSets.CellValueChangedEvent

            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeOverheadSet.Properties.OverheadAccountCode.ToString Then

                Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OverheadAccount = AdvantageFramework.Database.Procedures.OverheadAccount.LoadSingleByCode(DbContext, e.Value)

                    If OverheadAccount IsNot Nothing Then

                        DirectCast(DataGridViewOverheadSets_OverheadSets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeOverheadSet).OverheadAccountDescription = OverheadAccount.Description

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewOverheadSets_OverheadSets.InitNewRowEvent

            If TypeOf DataGridViewOverheadSets_OverheadSets.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OfficeOverheadSet Then

                DirectCast(DataGridViewOverheadSets_OverheadSets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeOverheadSet).OfficeOverheadSet.DatabaseAction = Database.Action.Inserting
                DirectCast(DataGridViewOverheadSets_OverheadSets.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeOverheadSet).OfficeCode = _OfficeCode

            End If

            RaiseEvent OverheadSetsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewOverheadSets_OverheadSets.QueryPopupNeedDatasourceEvent

            'objects
            Dim GeneralLedgerAccounts As Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If FieldName = AdvantageFramework.Database.Classes.OfficeOverheadSet.Properties.OverheadAccountCode.ToString Then

                    OverrideDefaultDatasource = True

                    GeneralLedgerAccounts = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(DbContext, _Session).ToList

                    Datasource = (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.Load(DbContext).ToList
                                  Where GeneralLedgerAccounts.Any(Function(GLA) GLA.Code >= Entity.FromGLACode AndAlso GLA.Code <= Entity.ToGLACode) = True
                                  Select Entity).GroupBy(Function(Entity) Entity.Code).Select(Of AdvantageFramework.Database.Entities.OverheadAccount)(Function(GEntity) GEntity.FirstOrDefault).ToList

                End If

            End Using

        End Sub

        Private Sub DataGridViewOverheadSets_OverheadSets_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOverheadSets_OverheadSets.SelectionChangedEvent

            RaiseEvent OverheadSetsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewOverheadSets_OverheadSets_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewOverheadSets_OverheadSets.ShowingEditorEvent

            If DataGridViewOverheadSets_OverheadSets.CurrentView.FocusedRowHandle >= 0 OrElse
                    DataGridViewOverheadSets_OverheadSets.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.OfficeOverheadSet.Properties.OverheadAccountDescription.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewSalesTaxAccounts_SalesTaxAccounts_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewSalesTaxAccounts_SalesTaxAccounts.AddNewRowEvent

            Dim OfficeSalesTaxAccount As AdvantageFramework.Database.Classes.OfficeSalesTaxAccount = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OfficeSalesTaxAccount Then

                If _OfficeCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    OfficeSalesTaxAccount = RowObject

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            OfficeSalesTaxAccount.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.Insert(DbContext, OfficeSalesTaxAccount.OfficeSalesTaxAccount) Then

                                LoadSalesTaxAccounts()

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewSalesTaxAccounts_SalesTaxAccounts_BeforeAddNewRowEvent(RowObject As Object, ByRef Cancel As Boolean) Handles DataGridViewSalesTaxAccounts_SalesTaxAccounts.BeforeAddNewRowEvent

            Dim OfficeSalesTaxAccount As AdvantageFramework.Database.Classes.OfficeSalesTaxAccount = Nothing

            OfficeSalesTaxAccount = DirectCast(RowObject, AdvantageFramework.Database.Classes.OfficeSalesTaxAccount)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If (From Entity In AdvantageFramework.Database.Procedures.OfficeSalesTaxAccount.LoadByOfficeCode(DbContext, _OfficeCode).ToList
                    Where Entity.SalesTaxCode.ToUpper = OfficeSalesTaxAccount.SalesTaxCode.ToUpper
                    Select Entity).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Duplicate tax code.")

                    OfficeSalesTaxAccount.SalesTaxCode = ""
                    OfficeSalesTaxAccount.SalesTaxDescription = Nothing

                    Cancel = True

                End If

            End Using

        End Sub
        Private Sub DataGridViewSalesTaxAccounts_SalesTaxAccounts_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewSalesTaxAccounts_SalesTaxAccounts.CellValueChangedEvent

            Dim OfficeSalesTaxAccountList As Generic.List(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount) = Nothing
            Dim OfficeSalesTaxAccount As AdvantageFramework.Database.Classes.OfficeSalesTaxAccount = Nothing
            Dim SalesTax As AdvantageFramework.Database.Entities.SalesTax = Nothing

            If TypeOf DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OfficeSalesTaxAccount Then

                OfficeSalesTaxAccountList = DataGridViewSalesTaxAccounts_SalesTaxAccounts.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OfficeSalesTaxAccount).ToList

                OfficeSalesTaxAccount = DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.GetRow(e.RowHandle)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesTaxAccount.Properties.SalesTaxCode.ToString Then

                        If (From OSTA In OfficeSalesTaxAccountList
                            Where OSTA.SalesTaxCode = e.Value
                            Select OSTA).Count > 1 Then

                            AdvantageFramework.WinForm.MessageBox.Show("Duplicate tax code.")

                            OfficeSalesTaxAccount.SalesTaxCode = ""
                            OfficeSalesTaxAccount.SalesTaxDescription = Nothing

                        Else

                            SalesTax = AdvantageFramework.Database.Procedures.SalesTax.LoadBySalesTaxCode(DbContext, e.Value)

                            If SalesTax IsNot Nothing Then

                                OfficeSalesTaxAccount.SalesTaxDescription = SalesTax.Description

                            End If

                        End If

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesTaxAccount.Properties.StateTaxGLACode.ToString Then

                        OfficeSalesTaxAccount.StateTaxGLDescription = OfficeSalesTaxAccount.GetGLDescription(DbContext, e.Value)

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesTaxAccount.Properties.CountyTaxGLACode.ToString Then

                        OfficeSalesTaxAccount.CountyTaxGLDescription = OfficeSalesTaxAccount.GetGLDescription(DbContext, e.Value)

                    ElseIf e.Column.FieldName = AdvantageFramework.Database.Classes.OfficeSalesTaxAccount.Properties.CityTaxGLACode.ToString Then

                        OfficeSalesTaxAccount.CityTaxGLDescription = OfficeSalesTaxAccount.GetGLDescription(DbContext, e.Value)

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewSalesTaxAccounts_SalesTaxAccounts_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewSalesTaxAccounts_SalesTaxAccounts.InitNewRowEvent

            DirectCast(DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OfficeSalesTaxAccount).OfficeSalesTaxAccount.OfficeCode = TextBoxControl_Code.Text

            RaiseEvent SalesTaxAccountsInitNewRowEvent(sender, e)

        End Sub
        Private Sub DataGridViewSalesTaxAccounts_SalesTaxAccounts_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewSalesTaxAccounts_SalesTaxAccounts.SelectionChangedEvent

            If DataGridViewSalesTaxAccounts_SalesTaxAccounts.CustomDeleteButton IsNot Nothing Then

                DataGridViewSalesTaxAccounts_SalesTaxAccounts.CustomDeleteButton.Enabled = Not DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.IsNewItemRow(DataGridViewSalesTaxAccounts_SalesTaxAccounts.CurrentView.FocusedRowHandle)

            End If

            RaiseEvent SalesTaxAccountsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_ProductionSales_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSalesClassAccounts_ProductionSales.EditValueChanged

            EnableOrDisableActions()
            RaiseEvent SalesClassAccountsComboboxChanged(SelectedTab, e)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_ProductionCOS_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSalesClassAccounts_ProductionCOS.EditValueChanged

            EnableOrDisableActions()
            RaiseEvent SalesClassAccountsComboboxChanged(SelectedTab, e)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_MediaSales_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSalesClassAccounts_MediaSales.EditValueChanged

            EnableOrDisableActions()
            RaiseEvent SalesClassAccountsComboboxChanged(SelectedTab, e)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_MediaCOS_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxSalesClassAccounts_MediaCOS.EditValueChanged

            EnableOrDisableActions()
            RaiseEvent SalesClassAccountsComboboxChanged(SelectedTab, e)

        End Sub
        Private Sub CheckBoxControl_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControl_Inactive.CheckedChanged

            Dim IsInactiveValue As Short = 0

            If Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                IsInactiveValue = If(CheckBoxControl_Inactive.Checked, 1, 0)

                Try

                    Me.ShowWaitForm("Processing...")

                    SaveOffice(AdvantageFramework.Database.Entities.Office.Properties.IsInactive, IsInactiveValue)
                    RaiseEvent OfficeInActiveChanged()

                Catch ex As Exception

                Finally
                    Me.CloseWaitForm()
                End Try

            End If

        End Sub
        Private Sub RadioButtonABIncomeRecognition_InitalBilling_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonABIncomeRecognition_InitalBilling.CheckedChanged

            Dim ProductionAdvancedBillingIncomeValue As Short = 0

            If Me.FindForm IsNot Nothing AndAlso Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                If RadioButtonABIncomeRecognition_InitalBilling.Checked Then

                    ProductionAdvancedBillingIncomeValue = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.InitialBilling

                ElseIf RadioButtonABIncomeRecognition_UponReconciliation.Checked Then

                    ProductionAdvancedBillingIncomeValue = AdvantageFramework.Database.Entities.ProductionAdvancedBillingIncome.UponReconciliation

                End If

                If ProductionAdvancedBillingIncomeValue <> 0 Then

                    SaveOffice(AdvantageFramework.Database.Entities.Office.Properties.ProductionAdvancedBillingIncome, ProductionAdvancedBillingIncomeValue)

                End If

            End If

        End Sub
        Private Sub RadioButtonPrebillIncomeRecognition_BillingDate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonPrebillIncomeRecognition_BillingDate.CheckedChanged, RadioButtonPrebillIncomeRecognition_CloseDate.CheckedChanged, RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.CheckedChanged

            Dim MediaAdvancedBillingIncomeValue As Short = 0

            If Me.FindForm IsNot Nothing AndAlso Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                If RadioButtonPrebillIncomeRecognition_BillingDate.Checked Then
                    MediaAdvancedBillingIncomeValue = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.BillingDate
                ElseIf RadioButtonPrebillIncomeRecognition_InsertionBroadcastDate.Checked Then
                    MediaAdvancedBillingIncomeValue = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.InsertionBroadcast
                ElseIf RadioButtonPrebillIncomeRecognition_CloseDate.Checked Then
                    MediaAdvancedBillingIncomeValue = AdvantageFramework.Database.Entities.MediaAdvancedBillingIncome.CloseDate
                End If

                If MediaAdvancedBillingIncomeValue <> 0 AndAlso GroupBoxMediaDefaults_PrebillIncomeRecognition.Tag <> MediaAdvancedBillingIncomeValue Then

                    SaveOffice(AdvantageFramework.Database.Entities.Office.Properties.MediaAdvancedBillingIncome, MediaAdvancedBillingIncomeValue)
                    GroupBoxMediaDefaults_PrebillIncomeRecognition.Tag = MediaAdvancedBillingIncomeValue

                End If

            End If

        End Sub
        Private Sub SearchableComboBoxDefault_AccountsReceivableGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_AccountsReceivableGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_AccountsReceivableGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_AccountsPayableGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_AccountsPayableGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_AccountsPayableGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_AccountsPayableDiscountGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_AccountsPayableDiscountGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_AccountsPayableDiscountGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_CityTaxGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_CityTaxGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_CityTaxGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_CountyTaxGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_CountyTaxGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_CountyTaxGLACode, DataSourceSet)

        End Sub
        'Private Sub SearchableComboBoxDefault_CurrencyExchangeGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean)

        '    Dim GeneralLedgerAccountTypes As IEnumerable(Of String) = Nothing

        '    GeneralLedgerAccountTypes = {AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.CurrentAsset, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.FixedAsset, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.NonCurrentAsset,
        '                                AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.CurrentLiability, AdvantageFramework.Database.Entities.GeneralLedgerAccountTypes.NonCurrentLiability}

        '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '        If _OfficeCode <> "" Then

        '            SearchableComboBoxDefault_CurrencyGainLossGLACode.DataSource = (From GLA In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadWithOfficeLimits(AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext), _Session.AccessibleGLOfficeCodes, _Session.HasLimitedOfficeCodes)
        '                                                                            Where GeneralLedgerAccountTypes.Contains(GLA.Type)
        '                                                                            Select New With {GLA.Code, GLA.Description}).ToList

        '        Else

        '            SearchableComboBoxDefault_CurrencyGainLossGLACode.DataSource = (From GLA In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
        '                                                                            Where GeneralLedgerAccountTypes.Contains(GLA.Type)
        '                                                                            Select New With {GLA.Code, GLA.Description}).ToList
        '        End If

        '    End Using

        '    DataSourceSet = True

        'End Sub
        Private Sub SearchableComboBoxDefault_StateTaxGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_StateTaxGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_StateTaxGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_SuspenseGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_SuspenseGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_SuspenseGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxDefault_ClientLatePaymentFeeGLACode_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxDefault_ClientLatePaymentFeeGLACode.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxDefault_ClientLatePaymentFeeGLACode, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_AccruedAP_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_AccruedAP.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_AccruedAP, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_AccruedCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_AccruedCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_AccruedCOS, DataSourceSet)

        End Sub
        'Private Sub SearchableComboBoxMediaDefaults_AccruedSalesTax_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_AccruedSalesTax.QueryPopupNeedDataSource

        '    SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_AccruedSalesTax, DataSourceSet)

        'End Sub
        Private Sub SearchableComboBoxMediaDefaults_COS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_COS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_COS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_DeferredCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_DeferredCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_DeferredCOS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_DeferredSales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_DeferredSales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_DeferredSales, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_Sales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_Sales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_Sales, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxMediaDefaults_WIP_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxMediaDefaults_WIP.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxMediaDefaults_WIP, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_AccruedAP_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_AccruedAP.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_AccruedAP, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_AccruedCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_AccruedCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_AccruedCOS, DataSourceSet)

        End Sub
        'Private Sub SearchableComboBoxProductionDefaults_AccruedSalesTax_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_AccruedSalesTax.QueryPopupNeedDataSource

        '    SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_AccruedSalesTax, DataSourceSet)

        'End Sub
        Private Sub SearchableComboBoxProductionDefaults_COS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_COS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_COS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_DeferredCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_DeferredCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_DeferredCOS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_DeferredSales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_DeferredSales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_DeferredSales, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_Sales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_Sales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_Sales, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxProductionDefaults_WIP_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxProductionDefaults_WIP.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxProductionDefaults_WIP, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_MediaCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxSalesClassAccounts_MediaCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxSalesClassAccounts_MediaCOS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_MediaSales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxSalesClassAccounts_MediaSales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxSalesClassAccounts_MediaSales, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_ProductionCOS_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxSalesClassAccounts_ProductionCOS.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxSalesClassAccounts_ProductionCOS, DataSourceSet)

        End Sub
        Private Sub SearchableComboBoxSalesClassAccounts_ProductionSales_QueryPopupNeedDataSource(ByRef DataSourceSet As Boolean) Handles SearchableComboBoxSalesClassAccounts_ProductionSales.QueryPopupNeedDataSource

            SetGeneralLedgerAccountDataSource(SearchableComboBoxSalesClassAccounts_ProductionSales, DataSourceSet)

        End Sub
        Private Sub DocumentManagerControlDocuments_OfficeDocuments_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_OfficeDocuments.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub ComboBoxControl_GLXREFCode_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxControl_GLXREFCode.SelectedValueChanged

            If _ReplaceOfficeSegment Then

                ReplaceAllGLAccountOfficeSegments()

            End If

        End Sub
        Private Sub DataGridViewFunctionAccounts_FunctionAccounts_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewFunctionAccounts_FunctionAccounts.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                If DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.OfficeFunctionAccount.Properties.FunctionCode.ToString Then

                    GridLookUpEdit = DataGridViewFunctionAccounts_FunctionAccounts.CurrentView.ActiveEditor

                    If GridLookUpEdit.Properties.View.Columns("Type") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("Type").Visible = True

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewGLSalesClassFunctionAccounts_GLSCFA_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewGLSalesClassFunctionAccounts_GLSCFA.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing

            If TypeOf DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                If DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.OfficeSalesClassFunctionAccount.Properties.FunctionCode.ToString Then

                    GridLookUpEdit = DataGridViewGLSalesClassFunctionAccounts_GLSCFA.CurrentView.ActiveEditor

                    If GridLookUpEdit.Properties.View.Columns("Type") IsNot Nothing Then

                        GridLookUpEdit.Properties.View.Columns("Type").Visible = True

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
