
Imports Telerik.Web.UI.Calendar
Imports Webvantage.cGlobals.Globals

Public Class Maintenance_ContractEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _ContractID As Integer = 0
    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _ContractFeeItemList As Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem) = Nothing
    Private _ContractContactList As Generic.List(Of AdvantageFramework.Database.Entities.ContractContact) = Nothing
    Private _ServiceFeeTypeList As Generic.List(Of AdvantageFramework.Database.Entities.ServiceFeeType) = Nothing
    Private _ContractReportDetailList As Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail) = Nothing
    Private _ContractValueAddedList As Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded) = Nothing
    Private _EmployeeList As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
    Private _CycleList As Generic.List(Of AdvantageFramework.Database.Entities.Cycle) = Nothing
    Private _IsCopy As Boolean = False
    Private _IsCRMUser As Boolean = False
    Private _TotalFeeHours As Decimal = 0
    Private _TotalFeeAmount As Decimal = 0
    Private _TotalValueAddedAmount As Decimal = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub CalculateTotalContractValue()

        RadNumericTextBoxTotalContractValue.Value = RadNumericTextBoxFeeRetainer.Value.GetValueOrDefault(0) +
                                                    RadNumericTextBoxFeeIncentiveBonus.Value.GetValueOrDefault(0) +
                                                    RadNumericTextBoxFeeRoyalty.Value.GetValueOrDefault(0) +
                                                    RadNumericTextBoxProjectHourlyTotal.Value.GetValueOrDefault(0) +
                                                    RadNumericTextBoxMediaCommission.Value.GetValueOrDefault(0) +
                                                    RadNumericTextBoxProductionCommission.Value.GetValueOrDefault(0)

    End Sub
    Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Contract

        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing

        Try

            If IsNew Then

                Contract = New AdvantageFramework.Database.Entities.Contract

                LoadContractEntity(Contract, True)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, _ContractID)

                    If Contract IsNot Nothing Then

                        LoadContractEntity(Contract, False)

                    End If

                End Using

            End If

        Catch ex As Exception
            Contract = Nothing
        End Try

        FillObject = Contract

    End Function
    Private Function Insert() As Boolean

        'objects
        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
        Dim ErrorMessage As String = Nothing
        Dim Inserted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Contract = Me.FillObject(True)

                If Contract IsNot Nothing Then

                    Contract.DbContext = DbContext
                    Contract.CreateDate = Now
                    Contract.CreatedByUserCode = _Session.UserCode

                    Inserted = AdvantageFramework.Database.Procedures.Contract.Insert(DbContext, Contract)

                    If Inserted Then

                        SaveContractFees(DbContext, Contract)
                        SaveContractValueAddeds(DbContext, Contract)
                        SaveContractContacts(DbContext, Contract)
                        SaveContractReports(DbContext, Contract)

                    End If

                End If

            End Using

        Catch ex As Exception
            ErrorMessage = "Failed trying to insert into the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Insert = Inserted

    End Function
    Private Sub LoadCommentsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        If Contract IsNot Nothing Then

            TextBoxBillingRateComment.Text = Contract.BillingRateComment
            TextBoxBillingTerms.Text = Contract.BillingTerms
            TextBoxEstimatingTerms.Text = Contract.EstimatingTerms
            TextBoxComments.Text = Contract.ContractComments

        End If

    End Sub
    Private Sub LoadContract()

        'objects
        Dim Loaded As Boolean = True
        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        If _DivisionCode = "" Then

            'SearchableComboBoxGeneral_Division.SetRequired(False)
            'SearchableComboBoxGeneral_Division.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
            'SearchableComboBoxGeneral_Division.Visible = False
            'LabelGeneral_Division.Visible = False

            'SearchableComboBoxGeneral_Product.SetRequired(False)
            'SearchableComboBoxGeneral_Product.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
            'SearchableComboBoxGeneral_Product.Visible = False
            'LabelGeneral_Product.Visible = False

        Else

            'SearchableComboBoxGeneral_Division.SetRequired(True)

        End If

        If _ProductCode = "" Then

            'SearchableComboBoxGeneral_Product.SetRequired(False)
            'SearchableComboBoxGeneral_Product.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
            'SearchableComboBoxGeneral_Product.Visible = False
            'LabelGeneral_Product.Visible = False

        Else

            'SearchableComboBoxGeneral_Product.SetRequired(True)

        End If

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" Then

                    If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                        CheckBoxIsNewBusiness.Checked = True
                        RadioButtonOpportunity.Checked = True
                        RadioButtonContract.Visible = False

                    Else

                        CheckBoxIsNewBusiness.Checked = False
                        RadioButtonContract.Checked = True
                        RadioButtonContract.Visible = True

                    End If

                    RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList

                Else

                    RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList

                End If

                RadComboBoxClient.DataValueField = "Code"
                RadComboBoxClient.DataBind()

            End Using

            If _ContractID <> 0 Then

                TextBoxContractCode.Enabled = _IsCopy
                TextBoxContractCode.ReadOnly = Not _IsCopy
                RadComboBoxClient.Enabled = _IsCopy
                RadComboBoxDivision.Enabled = _IsCopy
                RadComboBoxProduct.Enabled = _IsCopy

                Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, _ContractID)

                If Contract IsNot Nothing Then

                    If _IsCopy = False Then

                        TextBoxContractCode.Text = Contract.Code
                        TextBoxContractName.Text = Contract.Description

                        CheckBoxIsInactive.Checked = Contract.IsInactive

                        RadToolBarButtonDocuments.Visible = True
                        RadToolBarButtonUploadDocument.Visible = True

                    Else

                        TextBoxContractCode.Text = Nothing
                        TextBoxContractName.Text = Nothing

                        CheckBoxIsInactive.Checked = False

                        RadToolBarButtonDocuments.Visible = False
                        RadToolBarButtonUploadDocument.Visible = False

                    End If

                    LoadGeneralTab(Contract)

                    LoadRateTermsTab(Contract)

                    LoadCommentsTab(Contract)

                    LoadContractValueAdded()

                    LoadContractContacts()

                    If Not _IsCopy Then

                        LoadContractReports()

                    End If

                Else

                    Me.ShowMessage("The contract you are trying to edit does not exist anymore.")

                End If

            Else

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    RadComboBoxClient.Enabled = False
                    RadComboBoxDivision.Enabled = False
                    RadComboBoxProduct.Enabled = False

                    RadComboBoxClient.SelectedValue = _ClientCode
                    LoadDivisions()

                    RadComboBoxDivision.SelectedValue = _DivisionCode
                    LoadProducts()

                    RadComboBoxProduct.SelectedValue = _ProductCode

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    UpdateAddressFields(Product)

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    RadComboBoxClient.Enabled = False
                    RadComboBoxDivision.Enabled = False

                    RadComboBoxClient.SelectedValue = _ClientCode
                    LoadDivisions()

                    RadComboBoxDivision.SelectedValue = _DivisionCode
                    LoadProducts()

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    UpdateAddressFields(Division)

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    RadComboBoxClient.Enabled = False
                    RadComboBoxClient.SelectedValue = _ClientCode
                    LoadDivisions()

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    UpdateAddressFields(Client)

                End If

                TextBoxContractCode.Enabled = True
                TextBoxContractCode.ReadOnly = False
                TextBoxContractCode.Focus()

                RadToolBarButtonDocuments.Visible = False
                RadToolBarButtonUploadDocument.Visible = False

                LoadRateTermsTab(Nothing)

                LoadContractContacts()

                LoadContractValueAdded()

                LoadContractReports()

                Me.RadDatePickerStartDate.SelectedDate = Now.Date
                Me.RadDatePickerEndDate.SelectedDate = Now.Date

                Try
                    RadGridValueAdded.Columns(7).Visible = False
                    RadGridValueAdded.Columns(8).Visible = False
                    RadGridValueAdded.Columns(9).Visible = False
                    RadGridValueAdded.Columns(10).Visible = False

                    RadGridReports.Columns(12).Visible = False
                    RadGridReports.Columns(13).Visible = False
                    RadGridReports.Columns(14).Visible = False
                    RadGridReports.Columns(15).Visible = False
                Catch ex As Exception

                End Try

            End If

        End Using

    End Sub
    Private Sub LoadContractContacts()

        _ContractContactList = Session("Contract_RadGridInternalContacts")

        If _ContractContactList Is Nothing Then

            _ContractContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ContractContact)

        End If

        If _ContractID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _ContractContactList.AddRange(AdvantageFramework.Database.Procedures.ContractContact.LoadByContractID(DbContext, _ContractID).ToList)

            End Using

        End If

        RadGridInternalContacts.DataSource = _ContractContactList

        RadGridInternalContacts.MasterTableView.IsItemInserted = True

        RadGridInternalContacts.DataBind()

    End Sub
    Private Sub LoadContractEntity(ByVal Contract As AdvantageFramework.Database.Entities.Contract, ByVal IsNew As Boolean)

        If Contract IsNot Nothing Then

            SaveGeneralTab(Contract)

            SaveRatesTermsTab(Contract)

            SaveCommentsTab(Contract)

        End If

    End Sub
    Private Sub LoadContractFees()

        _ContractFeeItemList = Session("Contract_RadGridContractFees")

        If _ContractFeeItemList Is Nothing Then

            _ContractFeeItemList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem)

        End If

        If _ContractID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _ContractFeeItemList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractFee.LoadByContractID(DbContext, _ContractID).ToList
                                              Select New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, Entity))

            End Using

        End If

        RadGridContractFees.DataSource = _ContractFeeItemList
        RadGridContractFees.MasterTableView.IsItemInserted = True
        RadGridContractFees.DataBind()

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        TextBoxContractCode.CssClass = "RequiredInput"
        TextBoxContractName.CssClass = "RequiredInput"

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.Code, TextBoxContractCode)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.Description, TextBoxContractName)

        RadNumericTextBoxBlendedHourlyRate.MaxLength = 7
        RadNumericTextBoxBlendedHourlyRate.MaxValue = 9999.99
        RadNumericTextBoxBlendedHourlyRate.MinValue = -9999.99
        RadNumericTextBoxBlendedHourlyRate.NumberFormat.GroupSeparator = ","
        RadNumericTextBoxBlendedHourlyRate.NumberFormat.DecimalDigits = 2

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.BillingRateComment, TextBoxBillingRateComment)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.BillingTerms, TextBoxBillingTerms)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.EstimatingTerms, TextBoxEstimatingTerms)

    End Sub
    Private Sub LoadDivisions()

        Dim ClientCode As String = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ClientCode = RadComboBoxClient.SelectedValue

                RadComboBoxDivision.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList
                                                  Where Division.ClientCode = ClientCode
                                                  Select Division).ToList

                RadComboBoxDivision.DataValueField = "Code"
                RadComboBoxDivision.DataBind()

            End Using

            RadComboBoxProduct.DataSource = Nothing

        End Using

    End Sub
    Private Sub LoadGeneralTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        If Contract IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _IsCopy Then

                    CheckBoxIsInactive.Checked = False

                Else

                    CheckBoxIsInactive.Checked = Contract.IsInactive

                End If

                RadComboBoxClient.SelectedValue = Contract.ClientCode
                LoadDivisions()

                RadComboBoxDivision.SelectedValue = Contract.DivisionCode
                LoadProducts()

                RadComboBoxProduct.SelectedValue = Contract.ProductCode

                If Contract.ClientCode <> "" AndAlso Contract.DivisionCode <> "" AndAlso Contract.ProductCode <> "" Then

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, Contract.ClientCode, Contract.DivisionCode, Contract.ProductCode)

                    UpdateAddressFields(Product)

                ElseIf Contract.ClientCode <> "" AndAlso Contract.DivisionCode <> "" Then

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, Contract.ClientCode, Contract.DivisionCode)

                    UpdateAddressFields(Division)

                ElseIf Contract.ClientCode <> "" Then

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Contract.ClientCode)

                    UpdateAddressFields(Client)

                End If

                RadioButtonContract.Checked = Contract.IsContract
                RadioButtonOpportunity.Checked = Not Contract.IsContract

                If Contract.StartDate IsNot Nothing Then

                    RadDatePickerStartDate.SelectedDate = Contract.StartDate

                End If

                If Contract.EndDate IsNot Nothing Then

                    RadDatePickerEndDate.SelectedDate = Contract.EndDate

                End If

            End Using

        End If

    End Sub
    Private Sub LoadProducts()

        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing

        If RadComboBoxClient.SelectedValue <> "" AndAlso RadComboBoxDivision.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = RadComboBoxClient.SelectedValue
                    DivisionCode = RadComboBoxDivision.SelectedValue

                    RadComboBoxProduct.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, True).ToList
                                                     Where Product.ClientCode = ClientCode AndAlso
                                                           Product.DivisionCode = DivisionCode
                                                     Select Product).ToList

                    RadComboBoxProduct.DataValueField = "Code"
                    RadComboBoxProduct.DataBind()

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadRateTermsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        If Contract IsNot Nothing Then

            CheckBoxFee.Checked = Contract.IsFeeType
            CheckBoxProjectHourly.Checked = Contract.IsProjectHourlyType

            RadNumericTextBoxBlendedHourlyRate.Value = Contract.BlendedHourlyRate

            RadNumericTextBoxFeeRetainer.Value = Contract.FeeRetainer
            RadNumericTextBoxFeeIncentiveBonus.Value = Contract.FeeIncentiveBonus
            RadNumericTextBoxFeeRoyalty.Value = Contract.FeeRoyalty
            RadNumericTextBoxProjectHourlyTotal.Value = Contract.FeeProjectHourly
            RadNumericTextBoxHours.Value = Contract.Hours
            RadNumericTextBoxMediaCommission.Value = Contract.MediaCommission
            RadNumericTextBoxProductionCommission.Value = Contract.ProductionCommission

            CalculateTotalContractValue()

        End If

        LoadContractFees()

    End Sub
    Private Sub LoadContractReports()

        _ContractReportDetailList = Session("Contract_RadGridReports")

        If _ContractReportDetailList Is Nothing Then

            _ContractReportDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail)

        End If

        If _ContractID <> 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    _ContractReportDetailList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractReport.LoadByContractID(DbContext, _ContractID).ToList
                                                       Select New AdvantageFramework.Database.Classes.ContractReportDetail(DataContext, Entity))

                End Using

            End Using

        End If

        RadGridReports.DataSource = _ContractReportDetailList
        RadGridReports.MasterTableView.IsItemInserted = True
        RadGridReports.DataBind()

    End Sub
    Private Sub LoadContractReportEntity(ByRef ContractReport As AdvantageFramework.Database.Entities.ContractReport, ByVal GridDataItem As Telerik.Web.UI.GridDataItem)

        ContractReport.Description = CType(GridDataItem.FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox).Text

        If CType(GridDataItem.FindControl("RadComboBoxCycleCode"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

            ContractReport.CycleCode = CType(GridDataItem.FindControl("RadComboBoxCycleCode"), Telerik.Web.UI.RadComboBox).SelectedValue

        End If

        If CType(GridDataItem.FindControl("RadDatePickerLastCompletedDate"), Telerik.Web.UI.RadDatePicker).SelectedDate IsNot Nothing Then

            ContractReport.LastCompletedDate = CType(GridDataItem.FindControl("RadDatePickerLastCompletedDate"), Telerik.Web.UI.RadDatePicker).SelectedDate

        End If

        If CType(GridDataItem.FindControl("RadDatePickerNextStartDate"), Telerik.Web.UI.RadDatePicker).SelectedDate IsNot Nothing Then

            ContractReport.NextStartDate = CType(GridDataItem.FindControl("RadDatePickerNextStartDate"), Telerik.Web.UI.RadDatePicker).SelectedDate

        End If

        ContractReport.NotifyInternalContacts = CType(GridDataItem.FindControl("CheckBoxNotifyInternalContacts"), System.Web.UI.WebControls.CheckBox).Checked

        If CType(GridDataItem.FindControl("RadComboBoxEmployeeCode"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

            ContractReport.EmployeeCode = CType(GridDataItem.FindControl("RadComboBoxEmployeeCode"), Telerik.Web.UI.RadComboBox).SelectedValue

        End If

        If CType(GridDataItem.FindControl("RadNumericTextBoxAlertDaysPrior"), Telerik.Web.UI.RadNumericTextBox).Value IsNot Nothing Then

            ContractReport.AlertDaysPrior = CType(GridDataItem.FindControl("RadNumericTextBoxAlertDaysPrior"), Telerik.Web.UI.RadNumericTextBox).Value

        End If

        ContractReport.SendAlertDaysPrior = CType(GridDataItem.FindControl("CheckBoxSendAlertDaysPrior"), System.Web.UI.WebControls.CheckBox).Checked
        ContractReport.SendAlertUponCompletion = CType(GridDataItem.FindControl("CheckBoxSendAlertUponCompletion"), System.Web.UI.WebControls.CheckBox).Checked

    End Sub
    Private Sub LoadContractValueAddedEntity(ByRef ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded, ByVal GridDataItem As Telerik.Web.UI.GridDataItem)

        ContractValueAdded.Description = CType(GridDataItem.FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox).Text
        ContractValueAdded.Comment = CType(GridDataItem.FindControl("TextBoxComment"), System.Web.UI.WebControls.TextBox).Text
        ContractValueAdded.Amount = CType(GridDataItem.FindControl("RadNumericTextBoxValueAddedAmount"), Telerik.Web.UI.RadNumericTextBox).Value

    End Sub
    Private Sub LoadContractValueAdded()

        _ContractValueAddedList = Session("Contract_RadGridValueAdded")

        If _ContractValueAddedList Is Nothing Then

            _ContractValueAddedList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded)

        End If

        If _ContractID <> 0 Then

            _ContractValueAddedList.Clear()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _ContractValueAddedList.AddRange(From Entity In AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByContractID(DbContext, _ContractID).ToList
                                                 Select New AdvantageFramework.Database.Classes.ContractValueAdded(DbContext, Entity))

            End Using

        End If

        RadGridValueAdded.DataSource = _ContractValueAddedList
        RadGridValueAdded.MasterTableView.IsItemInserted = True
        RadGridValueAdded.DataBind()

    End Sub
    Private Function Save() As Boolean

        'objects
        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Contract = Me.FillObject(False)

                If Contract IsNot Nothing Then

                    Contract.ModifiedByUserCode = _Session.UserCode
                    Contract.ModifiedDate = Now

                    Saved = AdvantageFramework.Database.Procedures.Contract.Update(DbContext, Contract)

                    If Saved Then

                        SaveContractFees(DbContext, Contract)
                        SaveContractValueAddeds(DbContext, Contract)
                        SaveContractContacts(DbContext, Contract)
                        SaveContractReports(DbContext, Contract)

                    End If

                End If

            End Using

            If Not Saved Then

                ErrorMessage = "Failed trying to save data to the database. Please contact software support."

            End If

        Catch ex As Exception
            ErrorMessage = "Failed trying to save data to the database. Please contact software support."
        End Try

        If ErrorMessage <> "" Then

            Me.ShowMessage(ErrorMessage)

        End If

        Save = Saved

    End Function
    Private Sub SaveCommentsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        If Contract IsNot Nothing Then

            Contract.BillingRateComment = TextBoxBillingRateComment.Text
            Contract.BillingTerms = TextBoxBillingTerms.Text
            Contract.EstimatingTerms = TextBoxEstimatingTerms.Text
            Contract.ContractComments = TextBoxComments.Text

        End If

    End Sub
    Private Sub SaveContractContacts(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing

        For Each GridDataItem In RadGridInternalContacts.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If _ContractID <> 0 Then

                ContractContact = AdvantageFramework.Database.Procedures.ContractContact.LoadByContractIDAndEmployeeCode(DbContext, _ContractID, GridDataItem.GetDataKeyValue("EmployeeCode"))

                If ContractContact IsNot Nothing Then

                    ContractContact.IncludeInAlert = CType(GridDataItem.FindControl("CheckBoxIncludeInAlert"), System.Web.UI.WebControls.CheckBox).Checked

                    AdvantageFramework.Database.Procedures.ContractContact.Update(DbContext, ContractContact)

                End If

            Else

                ContractContact = New AdvantageFramework.Database.Entities.ContractContact

                ContractContact.DbContext = DbContext
                ContractContact.ContractID = Contract.ID

                ContractContact.EmployeeCode = CType(GridDataItem.FindControl("RadComboBoxEmployeeCode"), Telerik.Web.UI.RadComboBox).SelectedValue
                ContractContact.IncludeInAlert = CType(GridDataItem.FindControl("CheckBoxIncludeInAlert"), System.Web.UI.WebControls.CheckBox).Checked

                AdvantageFramework.Database.Procedures.ContractContact.Insert(DbContext, ContractContact)

            End If

        Next

    End Sub
    Private Sub SaveContractFees(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        Dim ContractFee As AdvantageFramework.Database.Entities.ContractFee = Nothing

        For Each GridDataItem In RadGridContractFees.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If _ContractID <> 0 Then

                ContractFee = AdvantageFramework.Database.Procedures.ContractFee.LoadByContractIDAndServiceFeeTypeID(DbContext, _ContractID, GridDataItem.GetDataKeyValue("ServiceFeeTypeID"))

                If ContractFee IsNot Nothing Then

                    ContractFee.Hours = CType(GridDataItem.FindControl("RadNumericTextBoxFeeHours"), Telerik.Web.UI.RadNumericTextBox).Value
                    ContractFee.Amount = CType(GridDataItem.FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox).Value

                    AdvantageFramework.Database.Procedures.ContractFee.Update(DbContext, ContractFee)

                End If

            Else

                ContractFee = New AdvantageFramework.Database.Entities.ContractFee

                ContractFee.DbContext = DbContext
                ContractFee.ContractID = Contract.ID

                ContractFee.ServiceFeeTypeID = GridDataItem.GetDataKeyValue("ServiceFeeTypeID")
                ContractFee.Hours = CType(GridDataItem.FindControl("RadNumericTextBoxFeeHours"), Telerik.Web.UI.RadNumericTextBox).Value
                ContractFee.Amount = CType(GridDataItem.FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox).Value

                AdvantageFramework.Database.Procedures.ContractFee.Insert(DbContext, ContractFee)

            End If

        Next

    End Sub
    Private Sub SaveContractReports(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing

        For Each GridDataItem In RadGridReports.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If _ContractID <> 0 Then

                ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                If ContractReport IsNot Nothing Then

                    LoadContractReportEntity(ContractReport, GridDataItem)

                    AdvantageFramework.Database.Procedures.ContractReport.Update(DbContext, ContractReport)

                End If

            Else

                ContractReport = New AdvantageFramework.Database.Entities.ContractReport

                ContractReport.DbContext = DbContext
                ContractReport.ContractID = Contract.ID

                LoadContractReportEntity(ContractReport, GridDataItem)

                AdvantageFramework.Database.Procedures.ContractReport.Insert(DbContext, ContractReport)

            End If

        Next

    End Sub
    Private Sub SaveContractValueAddeds(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        Dim ContractValueAdded As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing

        For Each GridDataItem In RadGridValueAdded.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            If _ContractID <> 0 Then

                ContractValueAdded = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                If ContractValueAdded IsNot Nothing Then

                    LoadContractValueAddedEntity(ContractValueAdded, GridDataItem)

                    AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAdded)

                End If

            Else

                ContractValueAdded = New AdvantageFramework.Database.Entities.ContractValueAdded

                ContractValueAdded.DbContext = DbContext
                ContractValueAdded.ContractID = Contract.ID

                LoadContractValueAddedEntity(ContractValueAdded, GridDataItem)

                AdvantageFramework.Database.Procedures.ContractValueAdded.Insert(DbContext, ContractValueAdded)

            End If

        Next

    End Sub
    Private Sub SaveGeneralTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        If Contract IsNot Nothing Then

            Contract.Code = TextBoxContractCode.Text
            Contract.Description = TextBoxContractName.Text
            Contract.ClientCode = RadComboBoxClient.SelectedValue

            If RadComboBoxDivision.SelectedValue <> "" Then

                Contract.DivisionCode = RadComboBoxDivision.SelectedValue

            End If

            If RadComboBoxProduct.SelectedValue <> "" Then

                Contract.ProductCode = RadComboBoxProduct.SelectedValue

            End If

            Contract.IsInactive = CheckBoxIsInactive.Checked

            Contract.IsContract = RadioButtonContract.Checked
            Contract.StartDate = RadDatePickerStartDate.SelectedDate
            Contract.EndDate = RadDatePickerEndDate.SelectedDate

        End If

    End Sub
    Private Sub SaveRatesTermsTab(ByVal Contract As AdvantageFramework.Database.Entities.Contract)

        If Contract IsNot Nothing Then

            Contract.IsFeeType = CheckBoxFee.Checked
            Contract.IsProjectHourlyType = CheckBoxProjectHourly.Checked
            Contract.BlendedHourlyRate = RadNumericTextBoxBlendedHourlyRate.Value

            Contract.FeeRetainer = RadNumericTextBoxFeeRetainer.Value
            Contract.FeeIncentiveBonus = RadNumericTextBoxFeeIncentiveBonus.Value
            Contract.FeeRoyalty = RadNumericTextBoxFeeRoyalty.Value
            Contract.FeeProjectHourly = RadNumericTextBoxProjectHourlyTotal.Value
            Contract.Hours = RadNumericTextBoxHours.Value
            Contract.MediaCommission = RadNumericTextBoxMediaCommission.Value
            Contract.ProductionCommission = RadNumericTextBoxProductionCommission.Value

        End If

    End Sub
    Private Sub ToggleReportDocumentButtons(ByVal GridItem As Telerik.Web.UI.GridItem, ByVal HasDocument As Boolean)

        Dim ViewDocumentsDiv As HtmlControls.HtmlControl = Nothing

        ViewDocumentsDiv = GridItem.FindControl("DivViewDocuments")

        If ViewDocumentsDiv IsNot Nothing Then

            If HasDocument = False Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(ViewDocumentsDiv)

            End If

        End If

    End Sub
    Private Sub ToggleValueAddedDocumentButtons(ByVal GridItem As Telerik.Web.UI.GridItem, ByVal HasDocument As Boolean, ByVal IsURL As Boolean)

        Dim UploadDiv As HtmlControls.HtmlControl = Nothing
        Dim DownloadDiv As HtmlControls.HtmlControl = Nothing
        Dim OpenURLDiv As HtmlControls.HtmlControl = Nothing
        Dim DeleteDocumentDiv As HtmlControls.HtmlControl = Nothing
        Dim ImageButtonOpenURL As System.Web.UI.WebControls.ImageButton = Nothing

        UploadDiv = GridItem.FindControl("DivUpload")
        DownloadDiv = GridItem.FindControl("DivDownload")
        OpenURLDiv = GridItem.FindControl("DivOpenURL")
        DeleteDocumentDiv = GridItem.FindControl("DivDeleteDocument")
        ImageButtonOpenURL = GridItem.FindControl("ImageButtonOpenURL")

        If UploadDiv IsNot Nothing AndAlso HasDocument Then

            AdvantageFramework.Web.Presentation.Controls.DivHide(UploadDiv)

        End If

        If DownloadDiv IsNot Nothing Then

            If HasDocument AndAlso Not IsURL Then

                'ImageButtonDownload.Visible = True

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(DownloadDiv)

            End If

        End If

        If OpenURLDiv IsNot Nothing Then

            If HasDocument AndAlso IsURL Then

                ImageButtonOpenURL.Attributes.Add("onclick", "javascript:window.open('" & GridItem.DataItem.DocumentURL & "')")

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(OpenURLDiv)

            End If

        End If

        If DeleteDocumentDiv IsNot Nothing AndAlso HasDocument = False Then

            AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDocumentDiv)

        End If

    End Sub
    Private Sub UpdateAddressFields(UpdatedInfo As Object)

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        If TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Client Then

            Client = UpdatedInfo

            TextBoxAddress1.Text = Client.Address
            TextBoxAddress2.Text = Client.Address2
            TextBoxCity.Text = Client.City
            TextBoxCounty.Text = Client.County
            TextBoxState.Text = Client.State
            TextBoxZip.Text = Client.Zip
            TextBoxCountry.Text = Client.Country

        ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Division Then

            Division = UpdatedInfo

            TextBoxAddress1.Text = Division.BillingAddress
            TextBoxAddress2.Text = Division.BillingAddress2
            TextBoxCity.Text = Division.BillingCity
            TextBoxCounty.Text = Division.BillingCounty
            TextBoxState.Text = Division.BillingState
            TextBoxZip.Text = Division.BillingZip
            TextBoxCountry.Text = Division.BillingCountry

        ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Product Then

            Product = UpdatedInfo

            TextBoxAddress1.Text = Product.BillingAddress
            TextBoxAddress2.Text = Product.BillingAddress2
            TextBoxCity.Text = Product.BillingCity
            TextBoxCounty.Text = Product.BillingCounty
            TextBoxState.Text = Product.BillingState
            TextBoxZip.Text = Product.BillingZip
            TextBoxCountry.Text = Product.BillingCountry

        End If

    End Sub
    Private Sub UpdateContractContact(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _ContractID <> 0 Then

                ContractContact = AdvantageFramework.Database.Procedures.ContractContact.LoadByContractIDAndEmployeeCode(DbContext, _ContractID, GridDataItem.GetDataKeyValue("EmployeeCode"))

                If ContractContact IsNot Nothing Then

                    ContractContact.IncludeInAlert = CType(GridDataItem.FindControl("CheckBoxIncludeInAlert"), System.Web.UI.WebControls.CheckBox).Checked

                    AdvantageFramework.Database.Procedures.ContractContact.Update(DbContext, ContractContact)

                End If

            Else

                _ContractContactList = Session("Contract_RadGridInternalContacts")

                If _ContractContactList Is Nothing Then

                    _ContractContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ContractContact)

                End If

                ContractContact = New AdvantageFramework.Database.Entities.ContractContact

                ErrorMessage = ContractContact.ValidateEntity(IsValid)

                If IsValid Then

                    _ContractContactList.Add(ContractContact)
                    Session("Contract_RadGridInternalContacts") = _ContractContactList

                Else

                    Me.ShowMessage(ErrorMessage)

                End If

            End If

        End Using

    End Sub
    Private Sub UpdateContractFee(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim ContractFee As AdvantageFramework.Database.Entities.ContractFee = Nothing
        Dim ContractFeeItem As AdvantageFramework.Database.Classes.ContractFeeItem = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _ContractID <> 0 Then

                ContractFee = AdvantageFramework.Database.Procedures.ContractFee.LoadByContractIDAndServiceFeeTypeID(DbContext, _ContractID, GridDataItem.GetDataKeyValue("ServiceFeeTypeID"))

                If ContractFee IsNot Nothing Then

                    ContractFee.Hours = CType(GridDataItem.FindControl("RadNumericTextBoxFeeHours"), Telerik.Web.UI.RadNumericTextBox).Value
                    ContractFee.Amount = CType(GridDataItem.FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox).Value

                    AdvantageFramework.Database.Procedures.ContractFee.Update(DbContext, ContractFee)

                End If

            Else

                _ContractFeeItemList = Session("Contract_RadGridContractFees")

                If _ContractFeeItemList Is Nothing Then

                    _ContractFeeItemList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem)

                End If

                ContractFeeItem = New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, ContractFee)

                ErrorMessage = ContractFeeItem.ValidateEntity(IsValid)

                If IsValid Then

                    _ContractFeeItemList.Add(New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, ContractFee))
                    Session("Contract_RadGridContractFees") = _ContractFeeItemList

                Else

                    Me.ShowMessage(ErrorMessage)

                End If

            End If

        End Using

    End Sub
    Private Sub UpdateContractReport(ByVal GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
        Dim ContractReportDetail As AdvantageFramework.Database.Classes.ContractReportDetail = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If _ContractID <> 0 Then

                    ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                    If ContractReport IsNot Nothing Then

                        LoadContractReportEntity(ContractReport, GridDataItem)

                        AdvantageFramework.Database.Procedures.ContractReport.Update(DbContext, ContractReport)

                    End If

                Else

                    If _ContractReportDetailList Is Nothing Then

                        _ContractReportDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail)

                    End If

                    ContractReport = New AdvantageFramework.Database.Entities.ContractReport

                    LoadContractReportEntity(ContractReport, GridDataItem)

                    ContractReportDetail = New AdvantageFramework.Database.Classes.ContractReportDetail(DataContext, ContractReport)

                    ErrorMessage = ContractReportDetail.ValidateEntity(IsValid)

                    If IsValid Then

                        _ContractReportDetailList.Add(ContractReportDetail)
                        Session("Contract_RadGridReports") = _ContractReportDetailList

                    Else

                        Me.ShowMessage(ErrorMessage)

                    End If

                End If

            End Using

        End Using

    End Sub
    Private Sub UpdateContractValueAdded(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim ContractValueAddedEntity As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing
        Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _ContractID <> 0 Then

                ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                If ContractValueAddedEntity IsNot Nothing Then

                    LoadContractValueAddedEntity(ContractValueAddedEntity, GridDataItem)

                    AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAddedEntity)

                End If

            Else

                If _ContractValueAddedList Is Nothing Then

                    _ContractValueAddedList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded)

                End If

                ContractValueAddedEntity = New AdvantageFramework.Database.Entities.ContractValueAdded

                LoadContractValueAddedEntity(ContractValueAddedEntity, GridDataItem)

                ContractValueAdded = New AdvantageFramework.Database.Classes.ContractValueAdded(DbContext, ContractValueAddedEntity)

                ErrorMessage = ContractValueAdded.ValidateEntity(IsValid)

                If IsValid Then

                    _ContractValueAddedList.Add(ContractValueAdded)
                    Session("Contract_RadGridValueAdded") = _ContractValueAddedList

                Else

                    Me.ShowMessage(ErrorMessage)

                End If

            End If

        End Using

    End Sub
    Private Sub Upload()

        Session("DocCaption") = ""

        Dim StringFK As String = Nothing
        StringFK = _ClientCode & "," & _DivisionCode & "," & _ProductCode

        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&FK=" & StringFK & "&Level=CT&Value=" & _ContractID, 500, 550)

    End Sub
    Private Sub ViewDocs()

        'Dim URL As String

        'URL = "Documents_List2.aspx?doclvl=" & AdvantageFramework.Database.Entities.DocumentLevel.Contract & "&contract_id=" & _ContractID & "&contract_desc=" & Me.TextBoxContractCode.Text & "-" & Me.TextBoxContractName.Text

        'Me.OpenWindow("View Documents", URL)

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "Documents_List2.aspx"
            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Contract
            .ContractID = Me._ContractID
            .Add("contract_desc", Me.TextBoxContractCode.Text & "-" & Me.TextBoxContractName.Text)

        End With

        Me.OpenWindow(qs, "Document List")

    End Sub
    Private Sub ViewReportDocuments(ByVal ContractReportID As Integer, ByVal ContractReportDescription As String)

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "Documents_List2.aspx"
            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.ContractReport
            .ContractReportID = ContractReportID
            .Add("contract_report", Me.TextBoxContractCode.Text & "-" & Me.TextBoxContractName.Text & " : " & ContractReportDescription)

        End With

        Me.OpenWindow(qs, "Document List")

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ContractEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Contract, False))
        RadToolBarButtonUploadDocument.Enabled = HasAccessToDocuments
        RadToolBarButtonDocuments.Enabled = HasAccessToDocuments

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ContractReport, False))

        Try

            RadGridReports.Columns.FindByUniqueName("GridTemplateColumnUpload").Display = HasAccessToDocuments
            RadGridReports.Columns.FindByUniqueName("GridTemplateColumnViewDocuments").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_ContractValueAdded, False))

        Try

            RadGridValueAdded.Columns.FindByUniqueName("GridTemplateColumnUpload").Display = HasAccessToDocuments
            RadGridValueAdded.Columns.FindByUniqueName("GridTemplateColumnDownload").Display = HasAccessToDocuments
            RadGridValueAdded.Columns.FindByUniqueName("GridTemplateColumnOpenURL").Display = HasAccessToDocuments
            RadGridValueAdded.Columns.FindByUniqueName("GridTemplateColumnDeleteDocument").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller").ToString

        End If

        If Request.QueryString("ContractID") IsNot Nothing Then

            _ContractID = Request.QueryString("ContractID").ToString

        End If

        If Request.QueryString("ClientCode") IsNot Nothing Then

            _ClientCode = Request.QueryString("ClientCode").ToString

        End If

        If Request.QueryString("DivisionCode") IsNot Nothing Then

            _DivisionCode = Request.QueryString("DivisionCode").ToString

        End If

        If Request.QueryString("ProductCode") IsNot Nothing Then

            _ProductCode = Request.QueryString("ProductCode").ToString

        End If

        If Request.QueryString("Mode") IsNot Nothing Then

            If Request.QueryString("Mode").ToString = "Add" Then

                _ContractID = 0

            ElseIf Request.QueryString("Mode").ToString = "Copy" Then

                _IsCopy = True

            End If

        End If

    End Sub
    Private Sub Maintenance_ContractEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Contract"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

            End Using

            Try

                LoadContract()

            Catch ex As Exception
                _ContractID = 0
            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadComboBoxClient_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxClient.SelectedIndexChanged

        Dim ClientCode As String = Nothing

        If RadComboBoxClient.SelectedValue <> "" Then

            ClientCode = RadComboBoxClient.SelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                    CheckBoxIsNewBusiness.Checked = True
                    RadioButtonOpportunity.Checked = True
                    RadioButtonContract.Visible = False

                Else

                    CheckBoxIsNewBusiness.Checked = False
                    RadioButtonContract.Checked = True
                    RadioButtonContract.Visible = True

                End If

            End Using

            RadComboBoxDivision.DataSource = Nothing

            LoadDivisions()

        End If

    End Sub
    Private Sub RadComboBoxDivision_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxDivision.SelectedIndexChanged

        If RadComboBoxDivision.SelectedValue <> "" Then

            LoadProducts()

        End If

    End Sub
    Private Sub RadGridContractFees_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContractFees.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ContractFeeItem As AdvantageFramework.Database.Classes.ContractFeeItem = Nothing
        Dim Reload As Boolean = True
        Dim ContractFee As AdvantageFramework.Database.Entities.ContractFee = Nothing
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContractFees.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridContractFees.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateContractFee(GridDataItem)

                Next

            Case "SaveNewRow"

                ContractFee = New AdvantageFramework.Database.Entities.ContractFee

                If CType(e.Item.FindControl("RadComboBoxServiceFeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ContractFee.ServiceFeeTypeID = CType(e.Item.FindControl("RadComboBoxServiceFeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                End If

                ContractFee.Hours = CType(e.Item.FindControl("RadNumericTextBoxFeeHoursEdit"), Telerik.Web.UI.RadNumericTextBox).Value
                ContractFee.Amount = CType(e.Item.FindControl("RadNumericTextBoxAmountEdit"), Telerik.Web.UI.RadNumericTextBox).Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ContractID <> 0 Then

                        ContractFee.DbContext = DbContext

                        ContractFee.ContractID = _ContractID

                        Reload = AdvantageFramework.Database.Procedures.ContractFee.Insert(DbContext, ContractFee)

                    Else

                        _ContractFeeItemList = Session("Contract_RadGridContractFees")

                        If _ContractFeeItemList Is Nothing Then

                            _ContractFeeItemList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractFeeItem)

                        End If

                        ContractFeeItem = New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, ContractFee)

                        ErrorMessage = ContractFeeItem.ValidateEntity(IsValid)

                        If IsValid Then

                            _ContractFeeItemList.Add(New AdvantageFramework.Database.Classes.ContractFeeItem(DbContext, ContractFee))
                            Session("Contract_RadGridContractFees") = _ContractFeeItemList

                        Else

                            Me.ShowMessage(ErrorMessage)

                        End If

                    End If

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateContractFee(CurrentGridDataItem)

                End If

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("RadComboBoxServiceFeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("RadNumericTextBoxFeeHoursEdit"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                    CType(e.Item.FindControl("RadNumericTextBoxAmountEdit"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ContractFee = AdvantageFramework.Database.Procedures.ContractFee.LoadByContractIDAndServiceFeeTypeID(DbContext, _ContractID, CurrentGridDataItem.GetDataKeyValue("ServiceFeeTypeID"))

                        If ContractFee IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.ContractFee.Delete(DbContext, ContractFee)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContractFees()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("RadComboBoxServiceFeeCodeEdit"), Telerik.Web.UI.RadComboBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridContractFees_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContractFees.ItemDataBound

        'objects
        Dim RadComboBoxServiceFeeCode As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveServiceFeeType As AdvantageFramework.Database.Entities.ServiceFeeType = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem AndAlso Not e.Item.GetType.Name = "GridDataInsertItem" Then

            GridDataItem = DirectCast((e.Item), Telerik.Web.UI.GridDataItem)

            _TotalFeeHours = (_TotalFeeHours + Double.Parse((DirectCast((GridDataItem("GridTemplateColumnHours").FindControl("RadNumericTextBoxFeeHours")), Telerik.Web.UI.RadNumericTextBox)).Value))
            _TotalFeeAmount = (_TotalFeeAmount + Double.Parse((DirectCast((GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxAmount")), Telerik.Web.UI.RadNumericTextBox)).Value))

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then

            GridFooterItem = DirectCast((e.Item), Telerik.Web.UI.GridFooterItem)

            DirectCast(GridFooterItem("GridTemplateColumnHours").FindControl("RadNumericTextBoxTotalFeeHours"), Telerik.Web.UI.RadNumericTextBox).Value = _TotalFeeHours.ToString

            DirectCast(GridFooterItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxTotalFeeAmount"), Telerik.Web.UI.RadNumericTextBox).Value = _TotalFeeAmount.ToString

        End If

        If _ServiceFeeTypeList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _ServiceFeeTypeList = AdvantageFramework.Database.Procedures.ServiceFeeType.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxServiceFeeCode = DirectCast(e.Item.FindControl("RadComboBoxServiceFeeCode"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxServiceFeeCode Is Nothing Then

                RadComboBoxServiceFeeCode = DirectCast(e.Item.FindControl("RadComboBoxServiceFeeCodeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxServiceFeeCode IsNot Nothing Then

                RadComboBoxServiceFeeCode.DataSource = (From ServiceFeeType In _ServiceFeeTypeList
                                                        Where ServiceFeeType.IsInactive = False
                                                        Select ServiceFeeType.ID,
                                                               [Description] = If(ServiceFeeType.IsInactive = False, CStr(ServiceFeeType.Code & " - " & ServiceFeeType.Description & " ").Trim, ServiceFeeType.Description & "*")).ToList

                RadComboBoxServiceFeeCode.DataBind()

                RadComboBoxServiceFeeCode.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveServiceFeeType = (From ServiceFeeType In _ServiceFeeTypeList
                                                  Where ServiceFeeType.ID = e.Item.DataItem.ServiceFeeTypeID AndAlso
                                                        ServiceFeeType.IsInactive = True
                                                  Select ServiceFeeType).Single

                    Catch ex As Exception
                        InactiveServiceFeeType = Nothing
                    End Try

                    If InactiveServiceFeeType IsNot Nothing Then

                        RadComboBoxServiceFeeCode.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveServiceFeeType.Description & "*", InactiveServiceFeeType.Code))

                        RadComboBoxServiceFeeCode.SelectedValue = InactiveServiceFeeType.ID

                    Else

                        RadComboBoxServiceFeeCode.SelectedValue = e.Item.DataItem.ServiceFeeTypeID

                    End If

                    RadComboBoxServiceFeeCode.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxServiceFeeCode = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Protected Sub RadNumericTextBoxProjectHourlyTotal_TextChanged(sender As Object, e As EventArgs)

        If DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).ID = "RadNumericTextBoxProjectHourlyTotal" Then

            If RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing AndAlso RadNumericTextBoxProjectHourlyTotal.Value IsNot Nothing Then

                RadNumericTextBoxHours.Value = CDec(AdvantageFramework.BillingSystem.CalculateQuantity(RadNumericTextBoxBlendedHourlyRate.Value, RadNumericTextBoxProjectHourlyTotal.Value, 2))

            End If

            RadNumericTextBoxHours.Focus()

        End If

        CalculateTotalContractValue()

    End Sub
    Protected Sub RadNumericTextBoxHours_TextChanged(sender As Object, e As EventArgs)

        If RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing Then

            RadNumericTextBoxProjectHourlyTotal.Value = AdvantageFramework.BillingSystem.CalculateAmount(RadNumericTextBoxHours.Value, RadNumericTextBoxBlendedHourlyRate.Value, 2)

            CalculateTotalContractValue()

        End If

    End Sub
    Private Sub LinkButtonRefresh_Click(sender As Object, e As EventArgs) Handles LinkButtonRefresh.Click

        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        For Each GridItem In RadGridContractFees.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)

            If TypeOf GridItem Is Telerik.Web.UI.GridFooterItem Then

                RadNumericTextBox = DirectCast(GridItem.FindControl("RadNumericTextBoxTotalFeeAmount"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBox IsNot Nothing Then

                    RadNumericTextBoxFeeRetainer.Value = RadNumericTextBox.Text

                    CalculateTotalContractValue()

                End If

            End If

        Next

    End Sub
    Protected Sub RadNumericTextBoxFeeHours_TextChanged(sender As Object, e As EventArgs)

        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TotalHours As Decimal = 0
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim Amount As Decimal = 0

        If TypeOf sender Is Telerik.Web.UI.RadNumericTextBox Then

            Try

                RadNumericTextBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing Then

                    RadNumericTextBox.Text = CDec(AdvantageFramework.BillingSystem.CalculateAmount(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Value, RadNumericTextBoxBlendedHourlyRate.Value, 2))

                End If

                RadNumericTextBoxAmount_TextChanged(RadNumericTextBox, Nothing)

                RadNumericTextBox.Focus()

            Catch ex As Exception

            End Try

        End If

        For Each GridDataItem In RadGridContractFees.MasterTableView.Items

            TotalHours = TotalHours + CDec(DirectCast(GridDataItem("GridTemplateColumnHours").FindControl("RadNumericTextBoxFeeHours"), Telerik.Web.UI.RadNumericTextBox).Value)

        Next

        For Each GridItem In RadGridContractFees.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)

            If TypeOf GridItem Is Telerik.Web.UI.GridFooterItem Then

                RadNumericTextBox = DirectCast(GridItem.FindControl("RadNumericTextBoxTotalFeeHours"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBox IsNot Nothing Then

                    RadNumericTextBox.Text = TotalHours

                End If

            End If

        Next

    End Sub
    Protected Sub RadNumericTextBoxFeeHoursEdit_TextChanged(sender As Object, e As EventArgs)

        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadNumericTextBox Then

            Try

                RadNumericTextBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadNumericTextBoxAmountEdit"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing Then

                    RadNumericTextBox.Text = CDec(AdvantageFramework.BillingSystem.CalculateAmount(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Value, RadNumericTextBoxBlendedHourlyRate.Value, 2))

                End If

                RadNumericTextBox.Focus()

            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Sub RadNumericTextBoxAmount_TextChanged(sender As Object, e As EventArgs)

        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TotalAmount As Decimal = 0
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadNumericTextBox AndAlso RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing Then

            Try

                RadNumericTextBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadNumericTextBoxFeeHours"), Telerik.Web.UI.RadNumericTextBox)

                RadNumericTextBox.Text = CDec(AdvantageFramework.BillingSystem.CalculateQuantity(RadNumericTextBoxBlendedHourlyRate.Value, DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Value, 2))

            Catch ex As Exception

            End Try

        End If

        For Each GridDataItem In RadGridContractFees.MasterTableView.Items

            TotalAmount = TotalAmount + CDec(DirectCast(GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxAmount"), Telerik.Web.UI.RadNumericTextBox).Value)

        Next

        For Each GridItem In RadGridContractFees.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)

            If TypeOf GridItem Is Telerik.Web.UI.GridFooterItem Then

                RadNumericTextBox = DirectCast(GridItem.FindControl("RadNumericTextBoxTotalFeeAmount"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBox IsNot Nothing Then

                    RadNumericTextBox.Text = TotalAmount

                End If

            End If

        Next

    End Sub
    Protected Sub RadNumericTextBoxAmountEdit_TextChanged(sender As Object, e As EventArgs)

        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadNumericTextBox AndAlso RadNumericTextBoxBlendedHourlyRate.Value IsNot Nothing Then

            Try

                RadNumericTextBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadNumericTextBoxFeeHoursEdit"), Telerik.Web.UI.RadNumericTextBox)

                RadNumericTextBox.Text = CDec(AdvantageFramework.BillingSystem.CalculateQuantity(RadNumericTextBoxBlendedHourlyRate.Value, DirectCast(sender, Telerik.Web.UI.RadNumericTextBox).Value, 2))

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub RadToolbarContract_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarContract.ButtonClick

        Dim ClosePage As Boolean = False

        Select Case e.Item.Value

            Case "Save"

                If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing And Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
                    If wvCDate(Me.RadDatePickerStartDate.SelectedDate) > wvCDate(Me.RadDatePickerEndDate.SelectedDate) Then
                        Me.ShowMessage("End Date must be greater than Start Date")
                        Exit Sub
                    End If
                End If

                If _ContractID = 0 Then

                    ClosePage = Insert()

                Else

                    ClosePage = Save()

                End If

            Case "Refresh"

                MiscFN.ResponseRedirect("Maintenance_ContractEdit.aspx?" & Request.QueryString.ToString)

            Case "New"

                Me.OpenWindow("New Contract", "Maintenance_ContractEdit.aspx?Caller=" & _Caller & "&Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()

                'qs.CmpIdentifier = Me.CmpIdentifier
                'qs.CampaignCode = Me.CmpCode

                'qs.Page = "Campaign.aspx"

                'With b

                '    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Campaign
                '    .UserCode = Session("UserCode")
                '    .Name = "Campaign: " & Me.CmpIdentifier
                '    .Description = Me.txtCampaignCodeDesc.Text & " Campaign"
                '    .PageURL = qs.ToString(True)

                'End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

        End Select

        If ClosePage Then

            Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx")

        End If

    End Sub
    Private Sub RadGridInternalContacts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridInternalContacts.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ContractContact As AdvantageFramework.Database.Entities.ContractContact = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim IsValid As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridInternalContacts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridInternalContacts.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateContractContact(GridDataItem)

                Next

            Case "SaveNewRow"

                ContractContact = New AdvantageFramework.Database.Entities.ContractContact

                If CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ContractContact.EmployeeCode = CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                End If

                ContractContact.IncludeInAlert = CType(e.Item.FindControl("CheckBoxIncludeInAlertEdit"), System.Web.UI.WebControls.CheckBox).Checked

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ContractID <> 0 Then

                        ContractContact.DbContext = DbContext

                        ContractContact.ContractID = _ContractID

                        Reload = AdvantageFramework.Database.Procedures.ContractContact.Insert(DbContext, ContractContact)

                    Else

                        _ContractContactList = Session("Contract_RadGridInternalContacts")

                        If _ContractContactList Is Nothing Then

                            _ContractContactList = New Generic.List(Of AdvantageFramework.Database.Entities.ContractContact)

                        End If

                        ErrorMessage = ContractContact.ValidateEntity(IsValid)

                        If IsValid Then

                            _ContractContactList.Add(ContractContact)
                            Session("Contract_RadGridInternalContacts") = _ContractContactList

                        Else

                            Me.ShowMessage(ErrorMessage)

                        End If

                    End If

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateContractContact(CurrentGridDataItem)

                End If

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("CheckBoxIncludeInAlertEdit"), System.Web.UI.WebControls.CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ContractContact = AdvantageFramework.Database.Procedures.ContractContact.LoadByContractIDAndEmployeeCode(DbContext, _ContractID, CurrentGridDataItem.GetDataKeyValue("EmployeeCode"))

                        If ContractContact IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.ContractContact.Delete(DbContext, ContractContact)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContractContacts()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridInternalContacts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridInternalContacts.ItemDataBound

        'objects
        Dim RadComboBoxEmployeeCode As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing

        If _EmployeeList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(_Session, DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxEmployeeCode = DirectCast(e.Item.FindControl("RadComboBoxEmployeeCode"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxEmployeeCode Is Nothing Then

                RadComboBoxEmployeeCode = DirectCast(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxEmployeeCode IsNot Nothing Then

                RadComboBoxEmployeeCode.DataSource = (From Employee In _EmployeeList
                                                      Where Employee.TerminationDate Is Nothing
                                                      Select Employee.Code,
                                                             Employee.FirstName,
                                                             Employee.MiddleInitial,
                                                             Employee.LastName).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                         .Name = Entity.Code & " - " & If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName)}).ToList

                RadComboBoxEmployeeCode.DataBind()

                RadComboBoxEmployeeCode.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveEmployee = (From Employee In _EmployeeList
                                            Where Employee.Code = e.Item.DataItem.EmployeeCode AndAlso
                                                  Employee.TerminationDate IsNot Nothing
                                            Select Employee).Single

                    Catch ex As Exception
                        InactiveEmployee = Nothing
                    End Try

                    If InactiveEmployee IsNot Nothing Then

                        RadComboBoxEmployeeCode.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(If(InactiveEmployee.MiddleInitial IsNot Nothing AndAlso InactiveEmployee.MiddleInitial <> "", InactiveEmployee.FirstName & " " & InactiveEmployee.MiddleInitial & ". " & InactiveEmployee.LastName, InactiveEmployee.FirstName & " " & InactiveEmployee.LastName) & "*", InactiveEmployee.Code))

                        RadComboBoxEmployeeCode.SelectedValue = InactiveEmployee.Code

                    Else

                        RadComboBoxEmployeeCode.SelectedValue = e.Item.DataItem.EmployeeCode

                    End If

                    RadComboBoxEmployeeCode.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxEmployeeCode = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridReports_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridReports.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ContractReportDetail As AdvantageFramework.Database.Classes.ContractReportDetail = Nothing
        Dim Reload As Boolean = True
        Dim ContractReport As AdvantageFramework.Database.Entities.ContractReport = Nothing
        Dim ErrorMessage As String = Nothing
        Dim StringFK As String = Nothing
        Dim ReportDescription As String = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridReports.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridReports.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateContractReport(GridDataItem)

                Next

            Case "SaveNewRow"

                ContractReport = New AdvantageFramework.Database.Entities.ContractReport

                ContractReport.Description = CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Text

                If CType(e.Item.FindControl("RadComboBoxCycleCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ContractReport.CycleCode = CType(e.Item.FindControl("RadComboBoxCycleCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                End If

                If CType(e.Item.FindControl("RadDatePickerLastCompletedDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate IsNot Nothing Then

                    ContractReport.LastCompletedDate = CType(e.Item.FindControl("RadDatePickerLastCompletedDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate

                End If

                If CType(e.Item.FindControl("RadDatePickerNextStartDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate IsNot Nothing Then

                    ContractReport.NextStartDate = CType(e.Item.FindControl("RadDatePickerNextStartDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate

                End If

                ContractReport.NotifyInternalContacts = CType(e.Item.FindControl("CheckBoxNotifyInternalContactsEdit"), System.Web.UI.WebControls.CheckBox).Checked

                If CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ContractReport.EmployeeCode = CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                End If

                If CType(e.Item.FindControl("RadNumericTextBoxAlertDaysPriorEdit"), Telerik.Web.UI.RadNumericTextBox).Value IsNot Nothing Then

                    ContractReport.AlertDaysPrior = CType(e.Item.FindControl("RadNumericTextBoxAlertDaysPriorEdit"), Telerik.Web.UI.RadNumericTextBox).Value

                End If

                ContractReport.SendAlertDaysPrior = CType(e.Item.FindControl("CheckBoxSendAlertDaysPriorEdit"), System.Web.UI.WebControls.CheckBox).Checked
                ContractReport.SendAlertUponCompletion = CType(e.Item.FindControl("CheckBoxSendAlertUponCompletionEdit"), System.Web.UI.WebControls.CheckBox).Checked

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        If _ContractID <> 0 Then

                            ContractReport.DbContext = DbContext

                            ContractReport.ContractID = _ContractID

                            Reload = AdvantageFramework.Database.Procedures.ContractReport.Insert(DbContext, ContractReport)

                        Else

                            _ContractReportDetailList = Session("Contract_RadGridReports")

                            If _ContractReportDetailList Is Nothing Then

                                _ContractReportDetailList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractReportDetail)

                            End If

                            ContractReportDetail = New AdvantageFramework.Database.Classes.ContractReportDetail(DataContext, ContractReport)

                            ErrorMessage = ContractReportDetail.ValidateEntity(IsValid)

                            If IsValid Then

                                _ContractReportDetailList.Add(ContractReportDetail)
                                Session("Contract_RadGridReports") = _ContractReportDetailList

                            Else

                                Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                    End Using

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateContractReport(CurrentGridDataItem)

                End If

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Text = Nothing
                    CType(e.Item.FindControl("RadComboBoxCycleCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("RadDatePickerLastCompletedDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate = Nothing
                    CType(e.Item.FindControl("RadDatePickerNextStartDateEdit"), Telerik.Web.UI.RadDatePicker).SelectedDate = Nothing
                    CType(e.Item.FindControl("CheckBoxNotifyInternalContactsEdit"), System.Web.UI.WebControls.CheckBox).Checked = False
                    CType(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("RadNumericTextBoxAlertDaysPriorEdit"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing
                    CType(e.Item.FindControl("CheckBoxSendAlertDaysPriorEdit"), System.Web.UI.WebControls.CheckBox).Checked = False
                    CType(e.Item.FindControl("CheckBoxSendAlertUponCompletionEdit"), System.Web.UI.WebControls.CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _ContractID <> 0 Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If ContractReport IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ContractReport.Delete(DbContext, ContractReport)

                            End If

                        End Using

                    Else

                        For Each GridDataItem In RadGridReports.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            If GridDataItem.Equals(CurrentGridDataItem) = False Then

                                UpdateContractReport(GridDataItem)

                            End If

                        Next

                        Session("Contract_RadGridReports") = _ContractReportDetailList

                    End If

                End If

            Case "UploadDocument"

                StringFK = _ClientCode & "," & _DivisionCode & "," & _ProductCode

                If e.Item IsNot Nothing AndAlso e.Item.FindControl("TextBoxDescription") IsNot Nothing Then

                    ReportDescription = CType(e.Item.FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox).Text

                End If

                Session("DocCaption") = ReportDescription

                Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&FK=" & StringFK & "&Level=ContractReport&Value=" & CurrentGridDataItem.GetDataKeyValue("ID"), 500, 550)

            Case "ViewDocuments"

                If e.Item IsNot Nothing AndAlso e.Item.FindControl("TextBoxDescription") IsNot Nothing Then

                    ReportDescription = CType(e.Item.FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox).Text

                End If

                ViewReportDocuments(CurrentGridDataItem.GetDataKeyValue("ID"), ReportDescription)

                'Case "DownloadDocument"

                'If CurrentGridDataItem IsNot Nothing Then

                '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                '        ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                '        If ContractReport IsNot Nothing Then

                '            Me.DeliverFile(ContractReport.DocumentID)

                '        End If

                '    End Using

                'End If

                'Case "DeleteDocument"

                'If CurrentGridDataItem IsNot Nothing Then

                '    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                '        ContractReport = AdvantageFramework.Database.Procedures.ContractReport.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                '        If ContractReport IsNot Nothing AndAlso ContractReport.Document IsNot Nothing Then

                '            ContractReport.DocumentID = Nothing

                '            If AdvantageFramework.Database.Procedures.ContractReport.Update(DbContext, ContractReport) Then

                '                ContractReport.Document.DbContext = DbContext

                '                AdvantageFramework.Database.Procedures.Document.Delete(DbContext, ContractReport.Document)

                '            End If

                '        End If

                '    End Using

                'End If

        End Select

        If Reload Then

            LoadContractReports()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridReports_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridReports.ItemDataBound

        'objects
        Dim RadComboBoxCycleCode As Telerik.Web.UI.RadComboBox = Nothing
        Dim InactiveCycle As AdvantageFramework.Database.Entities.Cycle = Nothing
        Dim RadComboBoxEmployeeCode As Telerik.Web.UI.RadComboBox = Nothing
        Dim InactiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonDeleteDocument As System.Web.UI.WebControls.ImageButton = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim HasDocumentCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
        'Dim ImageButtonUpload As System.Web.UI.WebControls.ImageButton = Nothing
        'Dim ImageButtonViewDocuments As System.Web.UI.WebControls.ImageButton = Nothing
        ''Dim ImageButtonDownload As System.Web.UI.WebControls.ImageButton = Nothing
        ''Dim ImageButtonOpenURL As System.Web.UI.WebControls.ImageButton = Nothing
        Dim UploadDiv As HtmlControls.HtmlControl = Nothing
        Dim ViewDocumentsDiv As HtmlControls.HtmlControl = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem AndAlso Not e.Item.GetType.Name = "GridDataInsertItem" Then

            GridDataItem = DirectCast((e.Item), Telerik.Web.UI.GridDataItem)

            TextBox = DirectCast(GridDataItem("GridTemplateColumnDescription").FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox)

            If TextBox IsNot Nothing Then

                TextBox.CssClass = "RequiredInput"

            End If

            ToggleReportDocumentButtons(e.Item, e.Item.DataItem.HasDocuments)

        ElseIf e.Item.GetType.Name = "GridDataInsertItem" Then

            HasDocumentCheckBox = e.Item.FindControl("CheckBoxHasDocumentEdit")

            If HasDocumentCheckBox IsNot Nothing Then

                HasDocumentCheckBox.Visible = False

            End If

            UploadDiv = e.Item.FindControl("DivUpload")

            If UploadDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(UploadDiv)

            End If

            ViewDocumentsDiv = e.Item.FindControl("DivViewDocuments")

            If ViewDocumentsDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(ViewDocumentsDiv)

            End If

        End If

        If _CycleList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _CycleList = AdvantageFramework.Database.Procedures.Cycle.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxCycleCode = DirectCast(e.Item.FindControl("RadComboBoxCycleCode"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxCycleCode Is Nothing Then

                RadComboBoxCycleCode = DirectCast(e.Item.FindControl("RadComboBoxCycleCodeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxCycleCode IsNot Nothing Then

                RadComboBoxCycleCode.DataSource = (From Cycle In _CycleList
                                                   Where (Cycle.IsInactive Is Nothing OrElse
                                                          Cycle.IsInactive = 0)
                                                   Select Cycle.Code,
                                                          [Description] = If(Cycle.IsInactive Is Nothing OrElse Cycle.IsInactive = 0, Cycle.Name, Cycle.Name & "*")).ToList

                RadComboBoxCycleCode.DataBind()

                RadComboBoxCycleCode.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveCycle = (From Cycle In _CycleList
                                         Where Cycle.Code = e.Item.DataItem.CycleCode AndAlso
                                               Cycle.IsInactive = 1
                                         Select Cycle).Single

                    Catch ex As Exception
                        InactiveCycle = Nothing
                    End Try

                    If InactiveCycle IsNot Nothing Then

                        RadComboBoxCycleCode.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveCycle.Name & "*", InactiveCycle.Code))

                        RadComboBoxCycleCode.SelectedValue = InactiveCycle.Code

                    Else

                        RadComboBoxCycleCode.SelectedValue = e.Item.DataItem.CycleCode

                    End If

                End If

            End If

        Catch ex As Exception
            RadComboBoxCycleCode = Nothing
        End Try

        If _EmployeeList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _EmployeeList = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxEmployeeCode = DirectCast(e.Item.FindControl("RadComboBoxEmployeeCode"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxEmployeeCode Is Nothing Then

                RadComboBoxEmployeeCode = DirectCast(e.Item.FindControl("RadComboBoxEmployeeCodeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxEmployeeCode IsNot Nothing Then

                RadComboBoxEmployeeCode.DataSource = (From Employee In _EmployeeList
                                                      Where Employee.TerminationDate Is Nothing
                                                      Select Employee.Code,
                                                             Employee.FirstName,
                                                             Employee.MiddleInitial,
                                                             Employee.LastName).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                         .Name = Entity.Code & " - " & If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName)}).ToList

                RadComboBoxEmployeeCode.DataBind()

                RadComboBoxEmployeeCode.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveEmployee = (From Employee In _EmployeeList
                                            Where Employee.Code = e.Item.DataItem.EmployeeCode AndAlso
                                                  Employee.TerminationDate IsNot Nothing
                                            Select Employee).Single

                    Catch ex As Exception
                        InactiveEmployee = Nothing
                    End Try

                    If InactiveEmployee IsNot Nothing Then

                        RadComboBoxEmployeeCode.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(If(InactiveEmployee.MiddleInitial IsNot Nothing AndAlso InactiveEmployee.MiddleInitial <> "", InactiveEmployee.FirstName & " " & InactiveEmployee.MiddleInitial & ". " & InactiveEmployee.LastName, InactiveEmployee.FirstName & " " & InactiveEmployee.LastName) & "*", InactiveEmployee.Code))

                        RadComboBoxEmployeeCode.SelectedValue = InactiveEmployee.Code

                    Else

                        RadComboBoxEmployeeCode.SelectedValue = e.Item.DataItem.EmployeeCode

                    End If

                End If

            End If

        Catch ex As Exception
            RadComboBoxEmployeeCode = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            ImageButtonDeleteDocument = DirectCast(e.Item.FindControl("ImageButtonDeleteDocument"), ImageButton)

            If ImageButtonDeleteDocument IsNot Nothing Then

                ImageButtonDeleteDocument.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this document?');")

            End If

        Catch ex As Exception
            ImageButtonDeleteDocument = Nothing
        End Try

    End Sub
    Private Sub RadGridValueAdded_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridValueAdded.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ContractValueAdded As AdvantageFramework.Database.Classes.ContractValueAdded = Nothing
        Dim Reload As Boolean = True
        Dim ContractValueAddedEntity As AdvantageFramework.Database.Entities.ContractValueAdded = Nothing
        Dim ErrorMessage As String = Nothing
        Dim StringFK As String = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridValueAdded.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridValueAdded.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateContractValueAdded(GridDataItem)

                Next

            Case "SaveNewRow"

                ContractValueAddedEntity = New AdvantageFramework.Database.Entities.ContractValueAdded

                ContractValueAddedEntity.Description = CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Text
                ContractValueAddedEntity.Comment = CType(e.Item.FindControl("TextBoxCommentEdit"), System.Web.UI.WebControls.TextBox).Text
                ContractValueAddedEntity.Amount = CType(e.Item.FindControl("RadNumericTextBoxValueAddedAmountEdit"), Telerik.Web.UI.RadNumericTextBox).Value

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _ContractID <> 0 Then

                        ContractValueAddedEntity.DbContext = DbContext

                        ContractValueAddedEntity.ContractID = _ContractID

                        Reload = AdvantageFramework.Database.Procedures.ContractValueAdded.Insert(DbContext, ContractValueAddedEntity)

                    Else

                        _ContractValueAddedList = Session("Contract_RadGridValueAdded")

                        If _ContractValueAddedList Is Nothing Then

                            _ContractValueAddedList = New Generic.List(Of AdvantageFramework.Database.Classes.ContractValueAdded)

                        End If

                        ContractValueAdded = New AdvantageFramework.Database.Classes.ContractValueAdded(DbContext, ContractValueAddedEntity)

                        ErrorMessage = ContractValueAdded.ValidateEntity(IsValid)

                        If IsValid Then

                            _ContractValueAddedList.Add(ContractValueAdded)
                            Session("Contract_RadGridValueAdded") = _ContractValueAddedList

                        Else

                            Me.ShowMessage(ErrorMessage)

                        End If

                    End If

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateContractValueAdded(CurrentGridDataItem)

                End If

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Text = Nothing
                    CType(e.Item.FindControl("TextBoxCommentEdit"), System.Web.UI.WebControls.TextBox).Text = Nothing
                    CType(e.Item.FindControl("RadNumericTextBoxValueAddedAmountEdit"), Telerik.Web.UI.RadNumericTextBox).Value = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _ContractID = 0 Then

                        For Each GridDataItem In RadGridValueAdded.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            If GridDataItem.Equals(CurrentGridDataItem) = False Then

                                UpdateContractValueAdded(GridDataItem)

                            End If

                        Next

                        Session("Contract_RadGridValueAdded") = _ContractValueAddedList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If ContractValueAddedEntity IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ContractValueAdded.Delete(DbContext, ContractValueAddedEntity)

                            End If

                        End Using

                    End If

                End If

            Case "UploadDocument"

                StringFK = _ClientCode & "," & _DivisionCode & "," & _ProductCode

                Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&FK=" & StringFK & "&Level=ContractValueAdded&Value=" & CurrentGridDataItem.GetDataKeyValue("ID"), 500, 550)

            Case "DownloadDocument"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If ContractValueAddedEntity IsNot Nothing Then

                            Me.DeliverFile(ContractValueAddedEntity.DocumentID)

                        End If

                    End Using

                End If

            Case "DeleteDocument"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ContractValueAddedEntity = AdvantageFramework.Database.Procedures.ContractValueAdded.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If ContractValueAddedEntity IsNot Nothing AndAlso ContractValueAddedEntity.Document IsNot Nothing Then

                            ContractValueAddedEntity.DocumentID = Nothing

                            If AdvantageFramework.Database.Procedures.ContractValueAdded.Update(DbContext, ContractValueAddedEntity) Then

                                ContractValueAddedEntity.Document.DbContext = DbContext

                                AdvantageFramework.Database.Procedures.Document.Delete(DbContext, ContractValueAddedEntity.Document)

                            End If

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContractValueAdded()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxDescriptionEdit"), System.Web.UI.WebControls.TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridValueAdded_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridValueAdded.ItemDataBound

        'objects
        Dim RadNumericTextBoxValueAddedAmount As Telerik.Web.UI.RadNumericTextBox = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim GridFooterItem As Telerik.Web.UI.GridFooterItem = Nothing
        Dim HasDocumentCheckBox As System.Web.UI.WebControls.CheckBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonDeleteDocument As System.Web.UI.WebControls.ImageButton = Nothing
        'Dim ImageButtonUpload As System.Web.UI.WebControls.ImageButton = Nothing
        'Dim ImageButtonDownload As System.Web.UI.WebControls.ImageButton = Nothing
        'Dim ImageButtonOpenURL As System.Web.UI.WebControls.ImageButton = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing
        Dim UploadDiv As HtmlControls.HtmlControl = Nothing
        Dim DownloadDiv As HtmlControls.HtmlControl = Nothing
        Dim OpenURLDiv As HtmlControls.HtmlControl = Nothing
        Dim DeleteDocumentDiv As HtmlControls.HtmlControl = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem AndAlso Not e.Item.GetType.Name = "GridDataInsertItem" Then

            GridDataItem = DirectCast((e.Item), Telerik.Web.UI.GridDataItem)

            TextBox = DirectCast(GridDataItem("GridTemplateColumnAmount").FindControl("TextBoxDescription"), System.Web.UI.WebControls.TextBox)

            If TextBox IsNot Nothing Then

                TextBox.CssClass = "RequiredInput"

            End If

            RadNumericTextBoxValueAddedAmount = DirectCast((GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxValueAddedAmount")), Telerik.Web.UI.RadNumericTextBox)

            If RadNumericTextBoxValueAddedAmount IsNot Nothing AndAlso IsNumeric(RadNumericTextBoxValueAddedAmount.Value) Then

                _TotalValueAddedAmount = (_TotalValueAddedAmount + Double.Parse((DirectCast((GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxValueAddedAmount")), Telerik.Web.UI.RadNumericTextBox)).Value))

            End If

            ToggleValueAddedDocumentButtons(e.Item, e.Item.DataItem.HasDocument, e.Item.DataItem.IsDocumentAURL)

        ElseIf TypeOf e.Item Is Telerik.Web.UI.GridFooterItem Then

            GridFooterItem = DirectCast((e.Item), Telerik.Web.UI.GridFooterItem)

            DirectCast(GridFooterItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxTotalValueAddedAmount"), Telerik.Web.UI.RadNumericTextBox).Value = _TotalValueAddedAmount.ToString

        ElseIf e.Item.GetType.Name = "GridDataInsertItem" Then

            HasDocumentCheckBox = e.Item.FindControl("CheckBoxHasDocumentEdit")

            If HasDocumentCheckBox IsNot Nothing Then

                HasDocumentCheckBox.Visible = False

            End If

            UploadDiv = e.Item.FindControl("DivUpload")

            If UploadDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(UploadDiv)

            End If

            DownloadDiv = e.Item.FindControl("DivDownload")

            If DownloadDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(DownloadDiv)

            End If

            OpenURLDiv = e.Item.FindControl("DivOpenURL")

            If OpenURLDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(OpenURLDiv)

            End If

            DeleteDocumentDiv = e.Item.FindControl("DivDeleteDocument")

            If DeleteDocumentDiv IsNot Nothing Then

                AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDocumentDiv)

            End If

        End If

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            ImageButtonDeleteDocument = DirectCast(e.Item.FindControl("ImageButtonDeleteDocument"), ImageButton)

            If ImageButtonDeleteDocument IsNot Nothing Then

                ImageButtonDeleteDocument.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this document?');")

            End If

        Catch ex As Exception
            ImageButtonDeleteDocument = Nothing
        End Try

    End Sub
    Protected Sub RadNumericTextBoxValueAddedAmount_TextChanged(sender As Object, e As EventArgs)

        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim TotalAmount As Decimal = 0
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim RadNumericTextBox As Telerik.Web.UI.RadNumericTextBox = Nothing

        For Each GridDataItem In RadGridValueAdded.MasterTableView.Items

            RadNumericTextBox = DirectCast(GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxValueAddedAmount"), Telerik.Web.UI.RadNumericTextBox)

            If RadNumericTextBox IsNot Nothing AndAlso IsNumeric(RadNumericTextBox.Value) Then

                TotalAmount = TotalAmount + CDec(DirectCast(GridDataItem("GridTemplateColumnAmount").FindControl("RadNumericTextBoxValueAddedAmount"), Telerik.Web.UI.RadNumericTextBox).Value)

            End If

        Next

        For Each GridItem In RadGridValueAdded.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)

            If TypeOf GridItem Is Telerik.Web.UI.GridFooterItem Then

                RadNumericTextBox = DirectCast(GridItem.FindControl("RadNumericTextBoxTotalValueAddedAmount"), Telerik.Web.UI.RadNumericTextBox)

                If RadNumericTextBox IsNot Nothing Then

                    RadNumericTextBox.Text = TotalAmount

                End If

            End If

        Next
    End Sub
    Protected Sub RadDatePickerLastCompletedDate_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)

        Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadDatePicker As Telerik.Web.UI.RadDatePicker = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadDatePicker Then

            Try

                RadComboBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadDatePicker).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadComboBoxCycleCode"), Telerik.Web.UI.RadComboBox)
                RadDatePicker = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadDatePicker).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadDatePickerNextStartDate"), Telerik.Web.UI.RadDatePicker)

                If RadComboBox.SelectedValue IsNot Nothing AndAlso RadDatePicker IsNot Nothing AndAlso e.NewDate IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Cycle = AdvantageFramework.Database.Procedures.Cycle.LoadByCode(DbContext, RadComboBox.SelectedValue)

                        If Cycle IsNot Nothing Then

                            Select Case Cycle.Type

                                Case "A"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Year, 1, e.NewDate.Value)

                                Case "D"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Day, 1, e.NewDate.Value)

                                Case "M"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Month, 1, e.NewDate.Value)

                                Case "Q"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Quarter, 1, e.NewDate.Value)

                                Case "W"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Day, 7, e.NewDate.Value)

                            End Select

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub
    Protected Sub RadDatePickerLastCompletedDateEdit_SelectedDateChanged(sender As Object, e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs)

        Dim Cycle As AdvantageFramework.Database.Entities.Cycle = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing
        Dim RadDatePicker As Telerik.Web.UI.RadDatePicker = Nothing

        If TypeOf sender Is Telerik.Web.UI.RadDatePicker Then

            Try

                RadComboBox = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadDatePicker).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadComboBoxCycleCodeEdit"), Telerik.Web.UI.RadComboBox)
                RadDatePicker = DirectCast(DirectCast(DirectCast(DirectCast(sender, Telerik.Web.UI.RadDatePicker).Parent, Telerik.Web.UI.GridTableCell).Parent, Telerik.Web.UI.GridDataItem).FindControl("RadDatePickerNextStartDateEdit"), Telerik.Web.UI.RadDatePicker)

                If RadComboBox.SelectedValue IsNot Nothing AndAlso RadDatePicker IsNot Nothing AndAlso e.NewDate IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Cycle = AdvantageFramework.Database.Procedures.Cycle.LoadByCode(DbContext, RadComboBox.SelectedValue)

                        If Cycle IsNot Nothing Then

                            Select Case Cycle.Type

                                Case "A"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Year, 1, e.NewDate.Value)

                                Case "D"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Day, 1, e.NewDate.Value)

                                Case "M"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Month, 1, e.NewDate.Value)

                                Case "Q"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Quarter, 1, e.NewDate.Value)

                                Case "W"

                                    RadDatePicker.SelectedDate = DateAdd(DateInterval.Day, 7, e.NewDate.Value)

                            End Select

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub RadDatePickerStartDate_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerStartDate.SelectedDateChanged
        Try
            If RadDatePickerStartDate.SelectedDate > RadDatePickerEndDate.SelectedDate Then

                RadDatePickerEndDate.SelectedDate = RadDatePickerStartDate.SelectedDate

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadDatePickerEndDate_SelectedDateChanged(sender As Object, e As SelectedDateChangedEventArgs) Handles RadDatePickerEndDate.SelectedDateChanged
        Try
            If RadDatePickerEndDate.SelectedDate < RadDatePickerStartDate.SelectedDate Then

                RadDatePickerStartDate.SelectedDate = RadDatePickerEndDate.SelectedDate

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
