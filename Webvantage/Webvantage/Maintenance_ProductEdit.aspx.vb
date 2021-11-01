Public Class Maintenance_ProductEdit
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _IsCopy As Boolean = False
    Private _IsCRMUser As Boolean = False
    Private _SortNameMaxLength As Long = Nothing
    Private _CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

    Private _ProductSortKeyList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel) = Nothing
    Private _CompanyProfileAffiliationList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel) = Nothing
    Private _ActivityCompetitionList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel) = Nothing
    'Private _AffiliationList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.AffiliationViewModel) = Nothing
    'Private _CompetitionList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.CompetitionViewModel) = Nothing '

    Private _ProductSortKeyEntityList As Generic.List(Of AdvantageFramework.Database.Entities.ProductSortKey) = Nothing
    Private _CompanyProfileAffiliationEntityList As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing
    Private _AffiliationEntityList As Generic.List(Of AdvantageFramework.Database.Entities.Affiliation) = Nothing
    Private _ActivityCompetitionEntityList As Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition) = Nothing
    Private _CompetitionEntityList As Generic.List(Of AdvantageFramework.Database.Entities.Competition) = Nothing '


    Private _Activity As AdvantageFramework.Database.Entities.Activity = Nothing
    Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Protected Function AssignInactiveJavascript(IsDefault As Object, IsInactive As Object) As String

        If IsDefault AndAlso Not IsInactive Then

            Return "InactiveConfirm"

        Else

            Return Nothing

        End If

    End Function
    Protected Function AssignAEDefaultJavascript(ByVal IsDefault As Boolean, ByVal IsInactive As Boolean, ByVal EmployeeCode As String) As String

        Dim AccountExecutiveList As Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive) = Nothing

        If Not IsDefault Then

            If AccountExecutiveList Is Nothing Then

                AccountExecutiveList = RadGridAccountExecutives.DataSource

            End If

            If AccountExecutiveList.Where(Function(AE) AE.IsDefault = True AndAlso AE.EmployeeCode <> EmployeeCode).Any Then

                Return "AEDefaultExists"

            ElseIf IsInactive Then

                Return "DefaultConfirm"

            Else

                Return Nothing

            End If

        Else

            Return Nothing

        End If

    End Function
    Private Sub LoadContactsTab()

        Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
        Dim ClientContactDetailList As Integer() = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) = False Then

                ClientContactIDs = New Generic.List(Of Integer)

                ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                           Where Entity.DivisionCode = _DivisionCode AndAlso
                                                 Entity.ProductCode = _ProductCode
                                           Select Entity.ContactID).ToArray)

                ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
                                           Where Entity.DivisionCode = _DivisionCode AndAlso
                                                 Entity.ProductCode Is Nothing
                                           Select Entity.ContactID).ToArray)

                ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).Include("ClientContactDetail")
                                           Where Entity.ClientContactDetail.Count = 0
                                           Select Entity.ContactID).ToArray)

                ClientContactDetailList = ClientContactIDs.Distinct.ToArray

                ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode)
                                  Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

                If CheckBoxContactsShowInactive.Checked Then

                    RadGridContacts.DataSource = (From Contact In ClientContacts
                                                  Select New With {.ContactID = Contact.ContactID,
                                                                   .Code = Contact.ContactCode,
                                                                   .Name = Contact.ToString,
                                                                   .IsInactive = CBool(Contact.IsInactive.GetValueOrDefault(0))}).ToList

                Else

                    RadGridContacts.DataSource = (From Contact In ClientContacts
                                                  Where Contact.IsInactive Is Nothing OrElse
                                                        Contact.IsInactive = 0
                                                  Select New With {.ContactID = Contact.ContactID,
                                                                   .Code = Contact.ContactCode,
                                                                   .Name = Contact.ToString,
                                                                   .IsInactive = CBool(Contact.IsInactive.GetValueOrDefault(0))}).ToList

                End If

            Else

                ClientContacts = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)

                RadGridContacts.DataSource = ClientContacts

            End If

            RadGridContacts.DataBind()

        End Using

    End Sub
    Private Sub LoadContractsTab()

        Dim Contracts As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

        If Not _IsCopy Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = Nothing Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing AndAlso _ProductCode = Nothing Then

                    Contracts = AdvantageFramework.Database.Procedures.Contract.LoadByClientCode(DbContext, _ClientCode).ToList

                End If

            End Using

        Else

            Contracts = New Generic.List(Of AdvantageFramework.Database.Entities.Contract)

        End If

        RadGridContracts.DataSource = Contracts

        RadGridContracts.DataBind()

    End Sub
    Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

        TextBoxProductCode.CssClass = "RequiredInput"
        TextBoxProductName.CssClass = "RequiredInput"

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.Code, TextBoxProductCode)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.Name, TextBoxProductName)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingAddress, TextBoxBillingAddress1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingAddress2, TextBoxBillingAddress2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCounty, TextBoxBillingCounty)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCity, TextBoxBillingCity)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingState, TextBoxBillingState)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingZip, TextBoxBillingZip)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingCountry, TextBoxBillingCountry)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingPhone, TextBoxBillingPhone)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingPhoneExtension, TextBoxBillingPhoneExt)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingFax, TextBoxBillingFax)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.BillingFaxExtension, TextBoxBillingFaxExt)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementAddress, TextBoxStatementAddress1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementAddress2, TextBoxStatementAddress2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCounty, TextBoxStatementCounty)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCity, TextBoxStatementCity)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementState, TextBoxStatementState)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementZip, TextBoxStatementZip)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementCountry, TextBoxStatementCountry)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementPhone, TextBoxStatementPhone)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementPhoneExtension, TextBoxStatementPhoneExt)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementFax, TextBoxStatementFax)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.StatementFaxExtension, TextBoxStatementFaxExt)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.AttentionTo, TextBoxAttentionLine)

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField1, TextBoxUserDefinedField1)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField2, TextBoxUserDefinedField2)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField3, TextBoxUserDefinedField3)
        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Product.Properties.UserDefinedField4, TextBoxUserDefinedField4)

        ' Company Profile tab
        RadNumericTextBoxRevenue.MaxLength = 15
        RadNumericTextBoxRevenue.MaxValue = 999999999999.99

        RadNumericTextBoxNumEmployees.MaxLength = 11
        RadNumericTextBoxNumEmployees.MaxValue = 99999999999

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.CompanyProfile.Properties.Notes, TextBoxNotes)

        '_AffiliationList = New Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation)

        'DataGridViewCompanyProfile_Affiliations.DataSource = _AffiliationList

        ' Activity Summary tab
        'SearchableComboBoxActivitySummary_Source.SetPropertySettings(AdvantageFramework.Database.Entities.Activity.Properties.SourceID)
        'SearchableComboBoxActivitySummary_Source.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

        'SearchableComboBoxActivitySummary_Rating.SetPropertySettings(AdvantageFramework.Database.Entities.Activity.Properties.RatingID)
        'SearchableComboBoxActivitySummary_Rating.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

        '_ActivityCompetitionList = New Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition)

        'DataGridViewActivitySummary_Competitors.DataSource = _ActivityCompetitionList

        'NumericInputActivitySummary_Probability.Properties.MaxLength = 3
        'NumericInputActivitySummary_Probability.Properties.MinValue = 0
        'NumericInputActivitySummary_Probability.Properties.MaxValue = 100

        'NumericInputActivitySummary_TotalOpportunity.SetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Contract.Properties.ProductionCommission)

        'TextBoxActivitySummary_LastActivityDate.ByPassUserEntryChanged = True
        'DataGridViewActivitySummary_Summary.ByPassUserEntryChanged = True

        _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

        If _IsCRMUser Then

            'TabItemProductSetup_Production.Visible = False
            'TabItemProductSetup_BroadcastMedia.Visible = False
            'TabItemProductSetup_PrintMedia.Visible = False
            'TabItemProductSetup_OutOfHomeInternetMedia.Visible = False

        End If

    End Sub
    Private Sub LoadProduct()

        'objects
        Dim Loaded As Boolean = True
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" Then

                    If _FromMaintenance Then

                        RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, _Session).ToList

                    Else

                        RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList

                    End If

                ElseIf _IsCRMUser Then

                    If _FromMaintenance Then

                        RadComboBoxClient.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                                        Where Entity.IsNewBusiness = 1
                                                        Select Entity).ToList
                    Else

                        RadComboBoxClient.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                        Where Entity.IsNewBusiness = 1
                                                        Select Entity).ToList

                    End If

                Else

                    If _FromMaintenance Then

                        RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveWithOfficeLimits(DbContext, _Session).ToList

                    Else

                        RadComboBoxClient.DataSource = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode).ToList

                    End If

                End If

                RadComboBoxClient.DataValueField = "Code"
                RadComboBoxClient.DataBind()

                LoadDivisions()

            End Using

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                TextBoxProductCode.Enabled = _IsCopy
                TextBoxProductCode.ReadOnly = Not _IsCopy
                RadComboBoxClient.Enabled = _IsCopy
                RadComboBoxDivision.Enabled = _IsCopy

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                If Product IsNot Nothing Then

                    If _IsCopy = False Then

                        TextBoxProductCode.Text = Product.Code
                        CollapsablePanelAccountExecutives.Visible = True
                        CollapsablePanelContacts.Visible = True
                        CollapsablePanelContracts.Visible = True

                        Me.RadToolbarProduct.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

                    Else

                        RadToolBarButtonUploadDocument.Visible = False
                        RadToolBarButtonDocuments.Visible = False

                        CollapsablePanelAccountExecutives.Visible = False
                        CollapsablePanelContacts.Visible = False
                        CollapsablePanelContracts.Visible = False

                    End If

                    RadComboBoxClient.SelectedValue = _ClientCode

                    LoadDivisions()

                    RadComboBoxDivision.SelectedValue = _DivisionCode

                    TextBoxProductName.Text = Product.Name

                    LoadSortKeys()
                    LoadGeneralTab(Product)

                    'LoadProductionTab(Product)
                    'LoadBroadcastMediaTab(Product)
                    'LoadPrintMediaTab(Product)
                    'LoadInternetMediaOutOfHomeTab(Product)

                    LoadCompanyProfileTab(Product)
                    LoadEmployeesAndAccountExecutives()
                    LoadContactsTab()
                    LoadContractsTab()
                    LoadActivitySummaryTab(Product)

                Else

                    Me.ShowMessage("The product you are trying to edit does not exist anymore.")

                End If

            ElseIf _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode = "" Then

                Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                UpdateAddressFields(Division, "BOTH")

                LoadSortKeys()
                LoadCompanyProfileTab(Product)
                LoadActivitySummaryTab(Product)

                RadComboBoxClient.Enabled = False
                RadComboBoxDivision.Enabled = False
                CheckBoxIsInactive.Checked = False
                TextBoxProductCode.Enabled = True
                TextBoxProductCode.ReadOnly = False
                TextBoxProductName.Enabled = True
                TextBoxProductName.ReadOnly = False
                RadComboBoxClient.SelectedValue = _ClientCode

                LoadDivisions()

                RadComboBoxDivision.SelectedValue = _DivisionCode

                CollapsablePanelAccountExecutives.Visible = False
                CollapsablePanelContacts.Visible = False
                CollapsablePanelContracts.Visible = False

                RadToolBarButtonUploadDocument.Visible = False
                RadToolBarButtonDocuments.Visible = False

                ButtonAddDiary.Visible = False
                RadGridActivitySummary.Visible = False

                Me.RadToolbarProduct.FindItemByValue("Bookmark").Visible = False

            ElseIf _ClientCode <> "" AndAlso _DivisionCode = "" AndAlso _ProductCode = "" Then

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                UpdateAddressFields(Client, "BOTH")

                LoadSortKeys()
                LoadCompanyProfileTab(Product)
                LoadActivitySummaryTab(Product)

                RadComboBoxClient.Enabled = False
                RadComboBoxDivision.Enabled = True
                CheckBoxIsInactive.Checked = False
                TextBoxProductCode.Enabled = True
                TextBoxProductCode.ReadOnly = False
                TextBoxProductName.Enabled = True
                TextBoxProductName.ReadOnly = False

                RadComboBoxClient.SelectedValue = _ClientCode

                LoadDivisions()

                CollapsablePanelAccountExecutives.Visible = False
                CollapsablePanelContacts.Visible = False
                CollapsablePanelContracts.Visible = False

                RadToolBarButtonUploadDocument.Visible = False
                RadToolBarButtonDocuments.Visible = False

                ButtonAddDiary.Visible = False
                RadGridActivitySummary.Visible = False

                Me.RadToolbarProduct.FindItemByValue("Bookmark").Visible = False

            Else

                LoadSortKeys()
                LoadCompanyProfileTab(Product)
                LoadActivitySummaryTab(Product)

                RadComboBoxClient.Enabled = True
                RadComboBoxDivision.Enabled = True
                TextBoxProductCode.Enabled = True
                TextBoxProductCode.ReadOnly = False
                TextBoxProductName.Enabled = True
                TextBoxProductName.ReadOnly = False

                CollapsablePanelAccountExecutives.Visible = False
                CollapsablePanelContacts.Visible = False
                CollapsablePanelContracts.Visible = False

                RadToolBarButtonUploadDocument.Visible = False
                RadToolBarButtonDocuments.Visible = False

                ButtonAddDiary.Visible = False
                RadGridActivitySummary.Visible = False

                Me.RadToolbarProduct.FindItemByValue("Bookmark").Visible = False

            End If

            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToInternet_UseFlags)
            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToMagazine_UseFlags)
            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToNewspaper_UseFlags)
            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToOutOfHome_UseFlags)
            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToRadio_UseFlags)
            'HandleApplyTaxCheckBoxes(CheckBoxApplySalesTaxToTelevision_UseFlags)

        End Using

    End Sub
    Private Sub LoadDivisions()

        Dim ClientCode As String = Nothing

        If RadComboBoxClient.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = RadComboBoxClient.SelectedValue

                    If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                        CheckBoxIsNewBusiness.Checked = True

                    Else

                        CheckBoxIsNewBusiness.Checked = False

                    End If

                    If _FromMaintenance Then

                        If _DivisionCode <> "" Then

                            RadComboBoxDivision.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.Load(DbContext)
                                                              Where Division.ClientCode = ClientCode
                                                              Select Division).ToList

                        Else

                            RadComboBoxDivision.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActive(DbContext)
                                                              Where Division.ClientCode = ClientCode
                                                              Select Division).ToList

                        End If

                    Else

                        If _DivisionCode <> "" Then

                            RadComboBoxDivision.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                              Where Division.ClientCode = ClientCode
                                                              Select Division).ToList

                        Else

                            RadComboBoxDivision.DataSource = (From Division In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                                              Where Division.ClientCode = ClientCode
                                                              Select Division).ToList

                        End If

                    End If

                    RadComboBoxDivision.DataValueField = "Code"
                    RadComboBoxDivision.DataBind()

                End Using

            End Using

        End If

    End Sub
    Private Sub LoadEmployeesAndAccountExecutives()

        Dim AccountExecutives As Generic.List(Of AdvantageFramework.Database.Entities.AccountExecutive) = Nothing
        Dim AvailableEmployees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing
        Dim EmployeeCodes As String() = Nothing
        Dim CoreEmployees As Generic.List(Of AdvantageFramework.Database.Core.Employee) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    AccountExecutives = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList

                    CoreEmployees = AdvantageFramework.Database.Procedures.EmployeeView.LoadCore(DbContext).ToList

                    EmployeeCodes = (From AccountExec In AccountExecutives
                                     Select AccountExec.EmployeeCode).ToArray

                    Try

                        RadGridEmployees.DataSource = (From Emp In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserOffice(DbContext, _Session.User.EmployeeCode)
                                                       Where EmployeeCodes.Contains(Emp.Code) = False
                                                       Select Emp.Code,
                                                          Emp.FirstName,
                                                          Emp.MiddleInitial,
                                                              Emp.LastName).ToList.Select(Function(Entity) New With {.Code = Entity.Code,
                                                                                                                     .Name = If(Entity.MiddleInitial IsNot Nothing AndAlso Entity.MiddleInitial <> "", Entity.FirstName & " " & Entity.MiddleInitial & ". " & Entity.LastName, Entity.FirstName & " " & Entity.LastName)}).ToList

                    Catch ex As Exception
                        RadGridEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                    End Try

                    Try

                        RadGridAccountExecutives.DataSource = AccountExecutives _
                                                          .Select(Function(AcctExec) New AdvantageFramework.Database.Classes.AccountExecutive(AcctExec, (From Emp In CoreEmployees
                                                                                                                                                         Where Emp.Code = AcctExec.EmployeeCode
                                                                                                                                                         Select Emp).Single)).ToList

                    Catch ex As Exception
                        RadGridAccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive)
                    End Try

                    ImageButtonAddAccountExecutive.Enabled = True
                    ImageButtonRemoveAccountExecutive.Enabled = True

                Else

                    RadGridEmployees.DataSource = New Generic.List(Of AdvantageFramework.Database.Views.Employee)
                    RadGridAccountExecutives.DataSource = New Generic.List(Of AdvantageFramework.Database.Classes.AccountExecutive)

                End If

                RadGridEmployees.DataBind()
                RadGridAccountExecutives.DataBind()

            End Using

        End Using

    End Sub
    Private Sub LoadGeneralTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        Dim Office As AdvantageFramework.Database.Entities.Office = Nothing

        If Product IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _IsCopy Then

                    CheckBoxIsInactive.Checked = False

                Else

                    CheckBoxIsInactive.Checked = Not Convert.ToBoolean(Product.IsActive.GetValueOrDefault(0))

                End If

                TextBoxBillingAddress1.Text = Product.BillingAddress
                TextBoxBillingAddress2.Text = Product.BillingAddress2
                TextBoxBillingCity.Text = Product.BillingCity
                TextBoxBillingCounty.Text = Product.BillingCounty
                TextBoxBillingState.Text = Product.BillingState
                TextBoxBillingZip.Text = Product.BillingZip
                TextBoxBillingCountry.Text = Product.BillingCountry
                TextBoxBillingPhone.Text = Product.BillingPhone
                TextBoxBillingPhoneExt.Text = Product.BillingPhoneExtension
                TextBoxBillingFax.Text = Product.BillingFax
                TextBoxBillingFaxExt.Text = Product.BillingFaxExtension

                TextBoxStatementAddress1.Text = Product.StatementAddress
                TextBoxStatementAddress2.Text = Product.StatementAddress2
                TextBoxStatementCity.Text = Product.StatementCity
                TextBoxStatementCounty.Text = Product.StatementCounty
                TextBoxStatementState.Text = Product.StatementState
                TextBoxStatementZip.Text = Product.StatementZip
                TextBoxStatementCountry.Text = Product.StatementCountry
                TextBoxStatementPhone.Text = Product.StatementPhone
                TextBoxStatementPhoneExt.Text = Product.StatementPhoneExtension
                TextBoxStatementFax.Text = Product.StatementFax
                TextBoxStatementFaxExt.Text = Product.StatementFaxExtension

                TextBoxUserDefinedField1.Text = Product.UserDefinedField1
                TextBoxUserDefinedField2.Text = Product.UserDefinedField2
                TextBoxUserDefinedField3.Text = Product.UserDefinedField3
                TextBoxUserDefinedField4.Text = Product.UserDefinedField4

                TextBoxAttentionLine.Text = Product.AttentionTo

                If Product.CurrencyCode IsNot Nothing Then
                    RadComboBoxCurrency.SelectedValue = Product.CurrencyCode
                Else
                    RadComboBoxCurrency.SelectedValue = ""
                End If

                If Product.OfficeCode IsNot Nothing Then

                    Try

                        RadComboBoxOffice.SelectedValue = Product.OfficeCode

                    Catch ex As Exception
                        RadComboBoxOffice.SelectedValue = ""
                    End Try

                    If RadComboBoxOffice.SelectedValue = "" Then

                        Office = AdvantageFramework.Database.Procedures.Office.LoadByOfficeCode(DbContext, Product.OfficeCode)

                        If Office IsNot Nothing Then

                            RadComboBoxOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(Office.Code & " - " & Office.Name & "*", Office.Code))

                            Try

                                RadComboBoxOffice.SelectedValue = Product.OfficeCode

                            Catch ex As Exception
                                RadComboBoxOffice.SelectedValue = ""
                            End Try

                        End If

                    End If

                Else

                    RadComboBoxOffice.SelectedValue = ""

                End If

            End Using

        End If

    End Sub
    Private Sub LoadSortKeys()

        If _IsCopy OrElse _ProductCode = "" Then

            _ProductSortKeyList = Session("ProductEdit_RadGridSortKeys")

        End If

        If _ProductSortKeyList Is Nothing Then

            _ProductSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                _ProductSortKeyList.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ProductSortKeyEntityList = Nothing
                    _ProductSortKeyEntityList = AdvantageFramework.Database.Procedures.ProductSortKey.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList()

                    If _ProductSortKeyEntityList IsNot Nothing Then

                        _ProductSortKeyList = (From Entity In _ProductSortKeyEntityList
                                               Select New AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel With {.ClientCode = Entity.ClientCode,
                                                                                                                                       .DivisionCode = Entity.DivisionCode,
                                                                                                                                       .ProductCode = Entity.ProductCode,
                                                                                                                                       .SortKey = Entity.SortKey}).ToList()

                    End If

                End Using

            End If

        End If

        RadGridSortKeys.DataSource = _ProductSortKeyList
        RadGridSortKeys.MasterTableView.IsItemInserted = True
        RadGridSortKeys.DataBind()

        If _IsCopy OrElse _ProductCode = "" Then

            Session("ProductEdit_RadGridSortKeys") = _ProductSortKeyList

        End If

    End Sub
    Private Sub LoadTotalOpportunity()

        Dim TotalAmount As Decimal = 0
        Dim Contract As Generic.List(Of AdvantageFramework.Database.Entities.Contract) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Try

                Contract = (From Entity In AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)
                            Where Entity.IsInactive = False
                            Select Entity).ToList

                TotalAmount = Contract.Sum(Function(Entity) Entity.FeeIncentiveBonus.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeProjectHourly.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeRetainer.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.FeeRoyalty.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.MediaCommission.GetValueOrDefault(0)) +
                          Contract.Sum(Function(Entity) Entity.ProductionCommission.GetValueOrDefault(0))

            Catch ex As Exception
                TotalAmount = 0
            End Try

        End Using

        RadNumericTextBoxTotalOpportunity.Value = TotalAmount

    End Sub
    Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Product

        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        Try

            If IsNew Then

                Product = New AdvantageFramework.Database.Entities.Product
                _CompanyProfile = New AdvantageFramework.Database.Entities.CompanyProfile
                _Activity = New AdvantageFramework.Database.Entities.Activity

                LoadProductEntity(Product, True)

                LoadCompanyProfileEntity(_CompanyProfile, True)

                _CompanyProfile.ClientCode = Product.ClientCode
                _CompanyProfile.DivisionCode = Product.DivisionCode
                _CompanyProfile.ProductCode = Product.Code

                LoadActivityEntity(_Activity, True)

                _Activity.ClientCode = Product.ClientCode
                _Activity.DivisionCode = Product.DivisionCode
                _Activity.ProductCode = Product.Code

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If Product IsNot Nothing Then

                        LoadProductEntity(Product, False)

                        _CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                        If _CompanyProfile Is Nothing Then

                            _CompanyProfile = New AdvantageFramework.Database.Entities.CompanyProfile

                            LoadCompanyProfileEntity(_CompanyProfile, True)

                            _CompanyProfile.ClientCode = Product.ClientCode
                            _CompanyProfile.DivisionCode = Product.DivisionCode
                            _CompanyProfile.ProductCode = Product.Code

                        Else

                            LoadCompanyProfileEntity(_CompanyProfile, False)

                        End If

                        _Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                        If _Activity Is Nothing Then

                            _Activity = New AdvantageFramework.Database.Entities.Activity

                            LoadActivityEntity(_Activity, True)

                            _Activity.ClientCode = Product.ClientCode
                            _Activity.DivisionCode = Product.DivisionCode
                            _Activity.ProductCode = Product.Code

                        Else

                            LoadActivityEntity(_Activity, False)

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception
            Product = Nothing
        End Try

        FillObject = Product

    End Function
    Private Function GetUpdatedClient() As AdvantageFramework.Database.Entities.Client

        If RadComboBoxClient.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                GetUpdatedClient = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RadComboBoxClient.SelectedValue)

            End Using

        Else

            GetUpdatedClient = Nothing

        End If

    End Function
    Private Function GetUpdatedDivision() As AdvantageFramework.Database.Entities.Division

        If RadComboBoxClient.SelectedValue <> "" AndAlso RadComboBoxDivision.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                GetUpdatedDivision = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, RadComboBoxClient.SelectedValue, RadComboBoxDivision.SelectedValue)

            End Using

        Else

            GetUpdatedDivision = Nothing

        End If

    End Function
    Private Sub LoadProductEntity(ByVal Product As AdvantageFramework.Database.Entities.Product, ByVal IsNew As Boolean)

        If Product IsNot Nothing Then

            SaveGeneralTab(Product)

        End If

    End Sub
    Private Sub LoadCompanyProfileEntity(ByVal CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile, ByVal IsNew As Boolean)

        If CompanyProfile IsNot Nothing Then

            If RadComboBoxIndustry.SelectedValue <> "" Then

                CompanyProfile.IndustryID = RadComboBoxIndustry.SelectedValue

            End If

            If RadComboBoxSpecialty.SelectedValue <> "" Then

                CompanyProfile.SpecialtyID = RadComboBoxSpecialty.SelectedValue

            End If

            If RadComboBoxRegion.SelectedValue <> "" Then

                CompanyProfile.RegionCode = RadComboBoxRegion.SelectedValue

            End If

            CompanyProfile.Revenue = RadNumericTextBoxRevenue.Value
            CompanyProfile.NumberOfEmployees = RadNumericTextBoxNumEmployees.Value
            CompanyProfile.Notes = TextBoxNotes.Text
            CompanyProfile.CaseStudyDone = CheckBoxCaseStudy.Checked
            CompanyProfile.UseAsReference = CheckBoxReference.Checked

        End If

    End Sub
    Private Sub LoadCompanyProfileAffiliations()

        If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxCompanyProfileID.Text) = False Then

            If Session("ProductEdit_RadGridCompanyProfileAffiliations") IsNot Nothing Then

                _CompanyProfileAffiliationList = Session("ProductEdit_RadGridCompanyProfileAffiliations")

            End If

        End If

        If _CompanyProfileAffiliationList Is Nothing Then

            _CompanyProfileAffiliationList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                _CompanyProfileAffiliationList.Clear()

                If IsNumeric(TextBoxCompanyProfileID.Text) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        _CompanyProfileAffiliationEntityList = Nothing
                        _CompanyProfileAffiliationEntityList = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByCompanyProfileID(DbContext, TextBoxCompanyProfileID.Text).ToList()

                        If _CompanyProfileAffiliationEntityList IsNot Nothing Then

                            _CompanyProfileAffiliationList = (From Entity In _CompanyProfileAffiliationEntityList
                                                              Select New AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel With {.ID = Entity.ID,
                                                                  .AffiliationID = Entity.AffiliationID,
                                                                  .CompanyProfileID = Entity.CompanyProfileID}).ToList()
                        End If

                    End Using

                End If

            End If

        End If

        RadGridCompanyProfileAffiliations.DataSource = _CompanyProfileAffiliationList
        RadGridCompanyProfileAffiliations.MasterTableView.IsItemInserted = True
        RadGridCompanyProfileAffiliations.DataBind()

        If _IsCopy OrElse _ProductCode = "" Then

            Session("ProductEdit_RadGridCompanyProfileAffiliations") = _CompanyProfileAffiliationList

        End If

    End Sub
    Private Sub LoadCompanyProfileTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

        If Product IsNot Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                If CompanyProfile IsNot Nothing Then

                    If CompanyProfile.IndustryID IsNot Nothing Then

                        RadComboBoxIndustry.SelectedValue = CompanyProfile.IndustryID

                    End If

                    If CompanyProfile.SpecialtyID IsNot Nothing Then

                        RadComboBoxSpecialty.SelectedValue = CompanyProfile.SpecialtyID

                    End If

                    RadComboBoxRegion.SelectedValue = CompanyProfile.RegionCode

                    RadNumericTextBoxRevenue.Value = CompanyProfile.Revenue

                    RadNumericTextBoxNumEmployees.Value = CompanyProfile.NumberOfEmployees

                    CheckBoxCaseStudy.Checked = CompanyProfile.CaseStudyDone

                    CheckBoxReference.Checked = CompanyProfile.UseAsReference

                    TextBoxNotes.Text = CompanyProfile.Notes

                    TextBoxCompanyProfileID.Text = CompanyProfile.ID

                End If

            End Using

        End If

        LoadCompanyProfileAffiliations()

    End Sub
    Private Sub LoadActivityEntity(ByVal Activity As AdvantageFramework.Database.Entities.Activity, ByVal IsNew As Boolean)

        If Activity IsNot Nothing Then

            Activity.LeadDate = RadDatePickerLeadDate.SelectedDate

            If RadComboBoxSource.SelectedValue <> "" Then

                Activity.SourceID = RadComboBoxSource.SelectedValue

            End If

            Activity.LastContactDate = RadDatePickerLastContactDate.SelectedDate
            Activity.SoldDate = RadDatePickerSoldDate.SelectedDate
            Activity.LostDate = RadDatePickerLostDate.SelectedDate
            Activity.Probability = RadNumericTextBoxProbability.Value

            If RadComboBoxRating.SelectedValue <> "" Then

                Activity.RatingID = RadComboBoxRating.SelectedValue

            End If

            Activity.CurrentProvider = TextBoxCurrentProvider.Text

        End If

    End Sub
    Private Sub LoadActivitySummary()

        Dim CRMActivitySummaryList As Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary) = Nothing
        Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            CRMActivitySummaryList = New Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary)

            CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Alert.LoadByTypeIDAndClientAndDivisionAndProductCode(DbContext, 11, _ClientCode, _DivisionCode, _ProductCode).ToList
                                            Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

            CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(DbContext, "C", _ClientCode, _DivisionCode, _ProductCode).ToList
                                            Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

            If CRMActivitySummaryList.Count > 0 Then

                RadGridActivitySummary.DataSource = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate)

            Else

                RadGridActivitySummary.DataSource = CRMActivitySummaryList

            End If

            RadGridActivitySummary.DataBind()

            Try

                CRMActivitySummary = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate).FirstOrDefault

                If CRMActivitySummary IsNot Nothing AndAlso CRMActivitySummary.ActivityDate IsNot Nothing Then

                    TextBoxLastActivityDate.Text = CRMActivitySummary.ActivityDate

                End If

            Catch ex As Exception
            End Try

        End Using

    End Sub
    Private Sub LoadActivitySummaryCompetitors()

        If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxActivityID.Text) = False Then

            If Session("ProductEdit_RadGridCompetitors") IsNot Nothing Then

                _ActivityCompetitionList = Session("ProductEdit_RadGridCompetitors")

            End If

        End If

        If _ActivityCompetitionList Is Nothing Then

            _ActivityCompetitionList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                _ActivityCompetitionList.Clear()

                If IsNumeric(TextBoxActivityID.Text) Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        _ActivityCompetitionEntityList = Nothing
                        _ActivityCompetitionEntityList = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByActivityID(DbContext, TextBoxActivityID.Text).ToList

                        If _ActivityCompetitionEntityList IsNot Nothing Then

                            _ActivityCompetitionList = (From Entity In _ActivityCompetitionEntityList
                                                        Select New AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel With {.ID = Entity.ID,
                                                            .ActivityID = Entity.ActivityID,
                                                            .CompetitionID = Entity.CompetitionID}).ToList()

                        End If

                    End Using

                End If

            End If

        End If

        RadGridCompetitors.DataSource = _ActivityCompetitionList
        RadGridCompetitors.MasterTableView.IsItemInserted = True
        RadGridCompetitors.DataBind()

        If _IsCopy OrElse _ProductCode = "" Then

            Session("ProductEdit_RadGridCompetitors") = _ActivityCompetitionList

        End If

    End Sub
    Private Sub LoadActivitySummaryTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

        TotalOpportunitySection.Visible = CheckBoxIsNewBusiness.Checked

        If Product IsNot Nothing AndAlso Not _IsCopy Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                If Activity IsNot Nothing Then

                    If Activity.LeadDate IsNot Nothing Then

                        RadDatePickerLeadDate.SelectedDate = Activity.LeadDate

                    End If

                    If Activity.SourceID IsNot Nothing Then

                        RadComboBoxSource.SelectedValue = Activity.SourceID

                    End If

                    If Activity.LastContactDate IsNot Nothing Then

                        RadDatePickerLastContactDate.SelectedDate = Activity.LastContactDate

                    End If

                    If Activity.SoldDate IsNot Nothing Then

                        RadDatePickerSoldDate.SelectedDate = Activity.SoldDate

                    End If

                    If Activity.LostDate IsNot Nothing Then

                        RadDatePickerLostDate.SelectedDate = Activity.LostDate

                    End If

                    RadNumericTextBoxProbability.Value = Activity.Probability

                    If Activity.RatingID IsNot Nothing Then

                        RadComboBoxRating.SelectedValue = Activity.RatingID

                    End If

                    TextBoxCurrentProvider.Text = Activity.CurrentProvider

                    TextBoxActivityID.Text = Activity.ID

                End If

            End Using

            If CheckBoxIsNewBusiness.Checked Then

                LoadTotalOpportunity()

            End If

        End If

        LoadActivitySummaryCompetitors()

        LoadActivitySummary()

    End Sub
    Private Sub ResetDataSources()

        'objects
        'Dim SalesTaxes As Generic.List(Of AdvantageFramework.Database.Entities.SalesTax) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadComboBoxOffice.DataSource = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session).ToList
            RadComboBoxOffice.DataValueField = "Code"
            RadComboBoxOffice.DataBind()
            RadComboBoxOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            RadComboBoxCurrency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.Load(DbContext).ToList
            RadComboBoxCurrency.DataValueField = "Code"
            RadComboBoxCurrency.DataBind()
            RadComboBoxCurrency.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            'SalesTaxes = AdvantageFramework.Database.Procedures.SalesTax.LoadAllActive(DbContext).ToList

            'ComboBoxInternet_TaxCode.DataSource = SalesTaxes
            'ComboBoxMagazine_TaxCode.DataSource = SalesTaxes
            'ComboBoxNewspaper_TaxCode.DataSource = SalesTaxes
            'ComboBoxOutOfHome_TaxCode.DataSource = SalesTaxes
            'ComboBoxProduction_DefaultTaxCode.DataSource = SalesTaxes
            'ComboBoxRadio_TaxCode.DataSource = SalesTaxes
            'ComboBoxTelevision_TaxCode.DataSource = SalesTaxes

            'ComboBoxProduction_DefaultAlertGroup.DataSource = AdvantageFramework.Database.Procedures.AlertGroup.LoadAllActive(DbContext)

            RadComboBoxIndustry.DataSource = AdvantageFramework.Database.Procedures.Industry.LoadAllActive(DbContext).ToList
            RadComboBoxIndustry.DataValueField = "ID"
            RadComboBoxIndustry.DataTextField = "Description"
            RadComboBoxIndustry.DataBind()
            RadComboBoxIndustry.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            RadComboBoxSpecialty.DataSource = AdvantageFramework.Database.Procedures.Specialty.LoadAllActive(DbContext).ToList
            RadComboBoxSpecialty.DataValueField = "ID"
            RadComboBoxSpecialty.DataTextField = "Description"
            RadComboBoxSpecialty.DataBind()
            RadComboBoxSpecialty.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            RadComboBoxRegion.DataSource = AdvantageFramework.Database.Procedures.PrintSpecRegion.LoadAllActive(DbContext).ToList
            RadComboBoxRegion.DataValueField = "Code"
            RadComboBoxRegion.DataBind()
            RadComboBoxRegion.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            RadComboBoxSource.DataSource = AdvantageFramework.Database.Procedures.Source.LoadAllActive(DbContext).ToList
            RadComboBoxSource.DataValueField = "ID"
            RadComboBoxSource.DataTextField = "Description"
            RadComboBoxSource.DataBind()
            RadComboBoxSource.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

            RadComboBoxRating.DataSource = AdvantageFramework.Database.Procedures.Rating.LoadAllActive(DbContext).ToList
            RadComboBoxRating.DataValueField = "ID"
            RadComboBoxRating.DataTextField = "Description"
            RadComboBoxRating.DataBind()
            RadComboBoxRating.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        End Using

    End Sub
    Private Function Insert() As Boolean

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
        Dim ErrorMessage As String = Nothing
        Dim Inserted As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Product.Properties.SortName))

                Catch ex As Exception
                    _SortNameMaxLength = Nothing
                End Try

                Product = Me.FillObject(True)

                If Product IsNot Nothing Then

                    Product.DbContext = DbContext

                    Inserted = AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                    If Inserted Then

                        SaveSortKeys(DbContext, Product)

                        If _CompanyProfile IsNot Nothing Then

                            _CompanyProfile.DbContext = DbContext

                            _CompanyProfile.CreateDate = Now
                            _CompanyProfile.CreatedByUserCode = _Session.UserCode

                            If AdvantageFramework.Database.Procedures.CompanyProfile.Insert(DbContext, _CompanyProfile) Then

                                _CompanyProfileAffiliationList = Session("ProductEdit_RadGridCompanyProfileAffiliations")

                                If _CompanyProfileAffiliationList IsNot Nothing Then

                                    For Each Affiliation In _CompanyProfileAffiliationList

                                        CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                                        CompanyProfileAffiliation.DbContext = DbContext
                                        CompanyProfileAffiliation.CompanyProfileID = _CompanyProfile.ID
                                        CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                                        AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

                                    Next

                                End If

                            End If

                        End If

                        If _Activity IsNot Nothing Then

                            _Activity.DbContext = DbContext
                            _Activity.CreateDate = Now
                            _Activity.CreatedByUserCode = _Session.UserCode

                            If AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, _Activity) Then

                                _ActivityCompetitionList = Session("ProductEdit_RadGridCompetitors")

                                If _ActivityCompetitionList IsNot Nothing Then

                                    For Each Competition In _ActivityCompetitionList

                                        ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                                        ActivityCompetition.DbContext = DbContext
                                        ActivityCompetition.ActivityID = _Activity.ID
                                        ActivityCompetition.CompetitionID = Competition.CompetitionID

                                        AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                                    Next

                                End If

                            End If

                        End If

                        _ClientCode = Product.ClientCode
                        _DivisionCode = Product.DivisionCode
                        _ProductCode = Product.Code

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
    Private Function Save() As Boolean

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Product.Properties.SortName))

                Catch ex As Exception
                    _SortNameMaxLength = Nothing
                End Try

                Product = Me.FillObject(False)

                If Product IsNot Nothing Then

                    Saved = AdvantageFramework.Database.Procedures.Product.Update(DbContext, Product)

                    If Saved Then

                        If _CompanyProfile IsNot Nothing Then

                            If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.CompanyProfile).Where(Function(Entity) Entity.ClientCode = _CompanyProfile.ClientCode AndAlso
                                                                                                                                 Entity.DivisionCode = _CompanyProfile.DivisionCode AndAlso
                                                                                                                                 Entity.ProductCode = _CompanyProfile.ProductCode).Any Then

                                _CompanyProfile.ModifiedDate = Now
                                _CompanyProfile.ModifiedByUserCode = _Session.UserCode

                                AdvantageFramework.Database.Procedures.CompanyProfile.Update(DbContext, _CompanyProfile)

                            Else

                                _CompanyProfile.DbContext = DbContext
                                _CompanyProfile.CreateDate = Now
                                _CompanyProfile.CreatedByUserCode = _Session.UserCode

                                AdvantageFramework.Database.Procedures.CompanyProfile.Insert(DbContext, _CompanyProfile)

                                _CompanyProfileAffiliationList = Session("ProductEdit_RadGridCompanyProfileAffiliations")

                                If _CompanyProfileAffiliationList IsNot Nothing Then

                                    For Each Affiliation In _CompanyProfileAffiliationList

                                        If Affiliation.IsEntityBeingAdded = True Then

                                            CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                                            CompanyProfileAffiliation.DbContext = DbContext
                                            CompanyProfileAffiliation.CompanyProfileID = _CompanyProfile.ID
                                            CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                                            AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

                                        End If

                                    Next

                                End If

                            End If

                        End If

                        If _Activity IsNot Nothing Then

                            If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Activity).Where(Function(Entity) Entity.ClientCode = _Activity.ClientCode AndAlso
                                                                                                                           Entity.DivisionCode = _Activity.DivisionCode AndAlso
                                                                                                                           Entity.ProductCode = _Activity.ProductCode).Any Then

                                _Activity.ModifiedDate = Now
                                _Activity.ModifiedByUserCode = _Session.UserCode

                                AdvantageFramework.Database.Procedures.Activity.Update(DbContext, _Activity)

                            Else

                                _Activity.DbContext = DbContext
                                _Activity.CreateDate = Now
                                _Activity.CreatedByUserCode = _Session.UserCode

                                AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, _Activity)

                                _ActivityCompetitionList = Session("ProductEdit_RadGridCompetitors")

                                If _ActivityCompetitionList IsNot Nothing Then

                                    For Each Competition In _ActivityCompetitionList

                                        If Competition.IsEntityBeingAdded Then

                                            ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                                            ActivityCompetition.DbContext = DbContext
                                            ActivityCompetition.ActivityID = _Activity.ID
                                            ActivityCompetition.CompetitionID = Competition.CompetitionID

                                            AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                                        End If

                                    Next

                                End If

                            End If

                        End If

                        _ClientCode = Product.ClientCode
                        _DivisionCode = Product.DivisionCode
                        _ProductCode = Product.Code

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
    Private Sub SaveGeneralTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        If Product IsNot Nothing Then

            Product.Code = TextBoxProductCode.Text
            Product.Name = TextBoxProductName.Text
            Product.ClientCode = RadComboBoxClient.SelectedValue
            Product.DivisionCode = RadComboBoxDivision.SelectedValue

            Product.IsActive = If(CheckBoxIsInactive.Checked, 0, 1)

            Product.BillingAddress = TextBoxBillingAddress1.Text
            Product.BillingAddress2 = TextBoxBillingAddress2.Text
            Product.BillingCity = TextBoxBillingCity.Text
            Product.BillingCounty = TextBoxBillingCounty.Text
            Product.BillingState = TextBoxBillingState.Text
            Product.BillingZip = TextBoxBillingZip.Text
            Product.BillingCountry = TextBoxBillingCountry.Text
            Product.BillingPhone = TextBoxBillingPhone.Text
            Product.BillingPhoneExtension = TextBoxBillingPhoneExt.Text
            Product.BillingFax = TextBoxBillingFax.Text
            Product.BillingFaxExtension = TextBoxBillingFaxExt.Text

            Product.StatementAddress = TextBoxStatementAddress1.Text
            Product.StatementAddress2 = TextBoxStatementAddress2.Text
            Product.StatementCity = TextBoxStatementCity.Text
            Product.StatementCounty = TextBoxStatementCounty.Text
            Product.StatementState = TextBoxStatementState.Text
            Product.StatementZip = TextBoxStatementZip.Text
            Product.StatementCountry = TextBoxStatementCountry.Text
            Product.StatementPhone = TextBoxStatementPhone.Text
            Product.StatementPhoneExtension = TextBoxStatementPhoneExt.Text
            Product.StatementFax = TextBoxStatementFax.Text
            Product.StatementFaxExtension = TextBoxStatementFaxExt.Text

            Product.UserDefinedField1 = TextBoxUserDefinedField1.Text
            Product.UserDefinedField2 = TextBoxUserDefinedField2.Text
            Product.UserDefinedField3 = TextBoxUserDefinedField3.Text
            Product.UserDefinedField4 = TextBoxUserDefinedField4.Text

            If Product.Name.Length > _SortNameMaxLength Then

                Product.SortName = Product.Name.Substring(0, _SortNameMaxLength)

            Else

                Product.SortName = Product.Name

            End If

            Product.AttentionTo = TextBoxAttentionLine.Text

            If RadComboBoxCurrency.SelectedValue <> "" Then

                Product.CurrencyCode = RadComboBoxCurrency.SelectedValue

            End If

            If RadComboBoxOffice.SelectedValue <> "" Then

                Product.OfficeCode = RadComboBoxOffice.SelectedValue

            End If

        End If

    End Sub
    Private Sub SaveSortKeys(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Product As AdvantageFramework.Database.Entities.Product)

        _ProductSortKeyList = Session("ProductEdit_RadGridSortKeys")

        If _ProductSortKeyList IsNot Nothing Then

            Dim EntityProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey = Nothing

            For Each ProductSortKey As AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel In _ProductSortKeyList

                If _IsCopy Or _ProductCode = "" Then

                    EntityProductSortKey = New AdvantageFramework.Database.Entities.ProductSortKey

                    EntityProductSortKey.DbContext = DbContext
                    EntityProductSortKey.ClientCode = Product.ClientCode
                    EntityProductSortKey.DivisionCode = Product.DivisionCode
                    EntityProductSortKey.ProductCode = Product.Code

                    AdvantageFramework.Database.Procedures.ProductSortKey.Insert(DbContext, EntityProductSortKey)

                    EntityProductSortKey = Nothing

                End If

            Next

        End If

    End Sub
    Private Sub UpdateAddressFields(ByVal Entity As Object, ByVal AddressType As String)

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

        If TypeOf Entity Is AdvantageFramework.Database.Entities.Client Then

            Client = DirectCast(Entity, AdvantageFramework.Database.Entities.Client)

            If AddressType = "BILLING" OrElse AddressType = "BOTH" Then

                TextBoxBillingAddress1.Text = Client.BillingAddress
                TextBoxBillingAddress2.Text = Client.BillingAddress2
                TextBoxBillingCity.Text = Client.BillingCity
                TextBoxBillingCounty.Text = Client.BillingCounty
                TextBoxBillingState.Text = Client.BillingState
                TextBoxBillingZip.Text = Client.BillingZip
                TextBoxBillingCountry.Text = Client.BillingCountry

            End If

            If AddressType = "STATEMENT" OrElse AddressType = "BOTH" Then

                TextBoxStatementAddress1.Text = Client.StatementAddress
                TextBoxStatementAddress2.Text = Client.StatementAddress2
                TextBoxStatementCity.Text = Client.StatementCity
                TextBoxStatementCounty.Text = Client.StatementCounty
                TextBoxStatementState.Text = Client.StatementState
                TextBoxStatementZip.Text = Client.StatementZip
                TextBoxStatementCountry.Text = Client.StatementCountry

            End If

        ElseIf TypeOf Entity Is AdvantageFramework.Database.Entities.Division Then

            Division = DirectCast(Entity, AdvantageFramework.Database.Entities.Division)

            If AddressType = "BILLING" OrElse AddressType = "BOTH" Then

                TextBoxBillingAddress1.Text = Division.BillingAddress
                TextBoxBillingAddress2.Text = Division.BillingAddress2
                TextBoxBillingCity.Text = Division.BillingCity
                TextBoxBillingCounty.Text = Division.BillingCounty
                TextBoxBillingState.Text = Division.BillingState
                TextBoxBillingZip.Text = Division.BillingZip
                TextBoxBillingCountry.Text = Division.BillingCountry

            End If

            If AddressType = "STATEMENT" OrElse AddressType = "BOTH" Then

                TextBoxStatementAddress1.Text = Division.Address
                TextBoxStatementAddress2.Text = Division.Address2
                TextBoxStatementCity.Text = Division.City
                TextBoxStatementCounty.Text = Division.County
                TextBoxStatementState.Text = Division.State
                TextBoxStatementZip.Text = Division.Zip
                TextBoxStatementCountry.Text = Division.Country

            End If

        End If

    End Sub
    Private Sub UpdateAddressFields(ByVal Division As AdvantageFramework.Database.Entities.Division, ByVal AddressType As String)

        If AddressType = "BILLING" OrElse AddressType = "BOTH" Then

            TextBoxBillingAddress1.Text = Division.BillingAddress
            TextBoxBillingAddress2.Text = Division.BillingAddress2
            TextBoxBillingCity.Text = Division.BillingCity
            TextBoxBillingCounty.Text = Division.BillingCounty
            TextBoxBillingState.Text = Division.BillingState
            TextBoxBillingZip.Text = Division.BillingZip
            TextBoxBillingCountry.Text = Division.BillingCountry

        End If

        If AddressType = "STATEMENT" OrElse AddressType = "BOTH" Then

            TextBoxStatementAddress1.Text = Division.Address
            TextBoxStatementAddress2.Text = Division.Address2
            TextBoxStatementCity.Text = Division.City
            TextBoxStatementCounty.Text = Division.County
            TextBoxStatementState.Text = Division.State
            TextBoxStatementZip.Text = Division.Zip
            TextBoxStatementCountry.Text = Division.Country

        End If

    End Sub
    Private Sub Upload()

        Session("DocCaption") = ""

        Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=PR&FK=" & _ClientCode & "," & _DivisionCode & "," & _ProductCode, 500, 550)

    End Sub
    Private Sub ViewDocs()

        'Dim URL As String

        'URL = "Documents_List2.aspx?doclvl=" & AdvantageFramework.Database.Entities.DocumentLevel.Product & "&cl_code=" & _ClientCode & "&div_code=" & _DivisionCode & "&prd_code=" & _ProductCode & "&product_desc=" & Me.TextBoxProductCode.Text & "-" & Me.TextBoxProductName.Text

        'Me.OpenWindow("View Documents", URL)

        Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "Documents_List2.aspx"
            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Product
            .ClientCode = Me._ClientCode
            .DivisionCode = Me._DivisionCode
            .ProductCode = Me._ProductCode
            .Add("product_desc", Me.TextBoxProductCode.Text & "-" & Me.TextBoxProductName.Text)

        End With

        Me.OpenWindow(qs, "Document List")

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_ProductEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Division, False))
        RadToolBarButtonUploadDocument.Enabled = HasAccessToDocuments
        RadToolBarButtonDocuments.Enabled = HasAccessToDocuments

        RadToolBarButtonNew.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadToolBarButtonSave.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        CollapsablePanelHeader.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelAddresses.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelOptions.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelAccountExecutives.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            CollapsablePanelContacts.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode)

        End Using

        CollapsablePanelCompanyProfile.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelActivitySummary.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelContracts.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        If Request.QueryString("From") IsNot Nothing Then

            If Request.QueryString("From").ToString = "Maintenance" Then

                _FromMaintenance = True

            End If

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

                _ProductCode = ""

            ElseIf Request.QueryString("Mode").ToString = "Copy" Then

                _IsCopy = True

            End If

        End If

    End Sub
    Private Sub Maintenance_ProductEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Product"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

                ResetDataSources()

            End Using

            Try

                LoadProduct()

            Catch ex As Exception
                _ProductCode = Nothing
            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonAddContact_Click(sender As Object, e As EventArgs) Handles ButtonAddContact.Click

        Try

            Me.OpenWindow("Add Contact", "popContactsAdd.aspx?From=ProductEdit&client=" & _ClientCode, 750, 950, False, True)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridSortKeys_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSortKeys.ItemCommand

        'objects
        Dim MyProductSortKey As AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel = Nothing
        Dim ProductSortKey As AdvantageFramework.Database.Entities.ProductSortKey = Nothing

        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridSortKeys.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                MyProductSortKey = New AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel

                MyProductSortKey.ClientCode = _ClientCode
                MyProductSortKey.DivisionCode = _DivisionCode
                MyProductSortKey.ProductCode = _ProductCode
                MyProductSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                ProductSortKey = New AdvantageFramework.Database.Entities.ProductSortKey

                ProductSortKey.ClientCode = _ClientCode
                ProductSortKey.DivisionCode = _DivisionCode
                ProductSortKey.ProductCode = _ProductCode
                ProductSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy OrElse _ProductCode = "" Then

                        _ProductSortKeyList = Session("ProductEdit_RadGridSortKeys")

                        If _ProductSortKeyList Is Nothing Then

                            _ProductSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel)

                        End If

                        If _ProductSortKeyList.Where(Function(Entity) Entity.SortKey = MyProductSortKey.SortKey).Any = True Then

                            Me.ShowMessage("Sort option has already been added.  Please choose another.")

                        Else

                            ErrorMessage = ProductSortKey.ValidateEntity(IsValid)

                            If IsValid Then

                                _ProductSortKeyList.Add(MyProductSortKey)
                                Session("ProductEdit_RadGridSortKeys") = _ProductSortKeyList

                            Else

                                Me.ShowMessage(ErrorMessage)

                            End If

                        End If

                    Else

                        ProductSortKey.DbContext = DbContext
                        ProductSortKey.ClientCode = _ClientCode
                        ProductSortKey.DivisionCode = _DivisionCode
                        ProductSortKey.ProductCode = _ProductCode

                        Reload = AdvantageFramework.Database.Procedures.ProductSortKey.Insert(DbContext, ProductSortKey)

                    End If

                End Using

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _ProductCode = "" Then

                        _ProductSortKeyList = Session("ProductEdit_RadGridSortKeys")

                        TextBox = CType(e.Item.FindControl("TextBoxSortKey"), TextBox)

                        If _ProductSortKeyList IsNot Nothing Then

                            Dim psk As AdvantageFramework.ViewModels.Maintenance.General.ProductSortViewModel = Nothing
                            Try

                                psk = (From Entity In _ProductSortKeyList
                                       Where Entity.SortKey = TextBox.Text
                                       Select Entity).SingleOrDefault()

                            Catch ex As Exception
                                psk = Nothing
                            End Try

                            If psk IsNot Nothing Then _ProductSortKeyList.Remove(psk)

                        End If

                        Session("ProductEdit_RadGridSortKeys") = _ProductSortKeyList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ProductSortKey = AdvantageFramework.Database.Procedures.ProductSortKey.LoadByClientAndDivisionAndProductCodeAndSortKey(DbContext, _ClientCode, _DivisionCode, _ProductCode, CurrentGridDataItem.GetDataKeyValue("SortKey"))

                            If ProductSortKey IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ProductSortKey.Delete(DbContext, ProductSortKey)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

            _ProductSortKeyList = Nothing
            LoadSortKeys()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridSortKeys_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridSortKeys.ItemDataBound

        Dim TextBoxSortKeyEditTextBox As System.Web.UI.WebControls.TextBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            TextBoxSortKeyEditTextBox = DirectCast(e.Item.FindControl("TextBoxSortKey"), System.Web.UI.WebControls.TextBox)

            If TextBoxSortKeyEditTextBox IsNot Nothing AndAlso CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                TextBoxSortKeyEditTextBox.Enabled = False

            End If

        Catch ex As Exception

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
    Private Sub RadToolbarProduct_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProduct.ButtonClick

        Dim Bookmark As AdvantageFramework.Web.Presentation.Bookmarks.Bookmark = Nothing
        Dim BookmarkMethods As AdvantageFramework.Web.Presentation.Bookmarks.Methods = Nothing
        Dim WebQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim ErrorMessage As String = ""

        Select Case e.Item.Value

            Case "Save"

                If _IsCopy OrElse _ProductCode = "" Then

                    If Insert() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Product", "Maintenance_ProductEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode, , , True)

                        Else

                            Me.OpenWindow("Product", "Maintenance_ProductEdit.aspx?ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode, , , True)

                        End If

                    End If

                Else

                    If Save() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Product", "Maintenance_ProductEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode, , , True)

                        Else

                            Me.OpenWindow("Pr9oduct", "Maintenance_ProductEdit.aspx?ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode, , , True)

                        End If

                    End If

                End If

            Case "Refresh"

                LoadProduct()

            Case "New"

                If _FromMaintenance Then

                    Me.OpenWindow("New Product", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=&ProductCode=")

                Else

                    Me.OpenWindow("New Product", "Maintenance_ProductEdit.aspx?Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=&ProductCode=")

                End If

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

            Case "Bookmark"

                Bookmark = New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark

                BookmarkMethods = New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                WebQueryString = New AdvantageFramework.Web.QueryString()

                WebQueryString = WebQueryString.FromCurrent()

                With Bookmark

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Maintenance_ProductEdit
                    .UserCode = Session("UserCode")
                    .Name = "Product: " & _ClientCode & "\" & _DivisionCode & "\" & _ProductCode
                    .PageURL = "Maintenance_ProductEdit.aspx" & WebQueryString.ToString()

                End With

                If BookmarkMethods.SaveBookmark(Bookmark, ErrorMessage) = False Then

                    Me.ShowMessage(ErrorMessage)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub
    Private Sub RadGridContacts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContacts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ClientContactDetail As AdvantageFramework.Database.Entities.ClientContactDetail = Nothing
        Dim DetailQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Reload As Boolean = False

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContacts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                Me.OpenWindow("Edit Contact", "popContactsAdd.aspx?From=ProductEdit&ccid=" & CurrentGridDataItem.GetDataKeyValue("ContactID") & "&client=" & _ClientCode & "&code=" & CurrentGridDataItem.GetDataKeyValue("Code"), 750, 950, , True)

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            ClientContactDetail = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, CurrentGridDataItem.GetDataKeyValue("ContactID"))
                                                   Where Entity.DivisionCode = _DivisionCode AndAlso
                                                         Entity.ProductCode = _ProductCode).Single

                        Catch ex As Exception
                            ClientContactDetail = Nothing
                        End Try

                        If ClientContactDetail IsNot Nothing Then

                            Reload = AdvantageFramework.Database.Procedures.ClientContactDetail.Delete(DbContext, ClientContactDetail)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContactsTab()

        End If

    End Sub
    Private Sub RadGridContacts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContacts.ItemDataBound

        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridEmployees_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEmployees.ItemCommand

        Dim Reload As Boolean = True

        If Reload Then

            LoadEmployeesAndAccountExecutives()

        End If

    End Sub
    Private Sub RadGridAccountExecutives_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAccountExecutives.ItemCommand

        Dim Reload As Boolean = True

        If Reload Then

            LoadEmployeesAndAccountExecutives()

        End If

    End Sub
    Private Sub LinkButtonBilling_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonBilling_Client.Click

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

        Client = GetUpdatedClient()

        UpdateAddressFields(Client, "BILLING")

    End Sub
    Private Sub LinkButtonBilling_Division_Click(sender As Object, e As EventArgs) Handles LinkButtonBilling_Division.Click

        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

        Division = GetUpdatedDivision()

        UpdateAddressFields(Division, "BILLING")

    End Sub
    Private Sub LinkButtonStatement_Billing_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Billing.Click

        TextBoxStatementAddress1.Text = TextBoxBillingAddress1.Text
        TextBoxStatementAddress2.Text = TextBoxBillingAddress2.Text
        TextBoxStatementCity.Text = TextBoxBillingCity.Text
        TextBoxStatementCounty.Text = TextBoxBillingCounty.Text
        TextBoxStatementState.Text = TextBoxBillingState.Text
        TextBoxStatementZip.Text = TextBoxBillingZip.Text
        TextBoxStatementCountry.Text = TextBoxBillingCountry.Text

    End Sub
    Private Sub LinkButtonStatement_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Client.Click

        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

        Client = GetUpdatedClient()

        UpdateAddressFields(Client, "STATEMENT")

    End Sub
    Private Sub LinkButtonStatement_Division_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Division.Click

        Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

        Division = GetUpdatedDivision()

        UpdateAddressFields(Division, "STATEMENT")

    End Sub
    Protected Sub RadComboBoxClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

        If RadComboBoxClient.SelectedValue <> "" Then

            LoadDivisions()

        End If

    End Sub
    Private Sub ImageButtonAddAccountExecutive_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonAddAccountExecutive.Click

        'objects
        Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" AndAlso RadGridEmployees.SelectedItems.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each Item In RadGridEmployees.SelectedItems

                    AccountExecutive = New AdvantageFramework.Database.Entities.AccountExecutive

                    AccountExecutive.ClientCode = _ClientCode
                    AccountExecutive.DivisionCode = _DivisionCode
                    AccountExecutive.ProductCode = _ProductCode
                    AccountExecutive.EmployeeCode = Item("Code").Text
                    AccountExecutive.IsInactive = 0
                    AccountExecutive.IsDefaultAccountExecutive = 0

                    AdvantageFramework.Database.Procedures.AccountExecutive.Insert(DbContext, AccountExecutive)

                Next

                LoadEmployeesAndAccountExecutives()

            End Using

        End If

    End Sub
    Private Sub ImageButtonRemoveAccountExecutive_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonRemoveAccountExecutive.Click

        'objects
        Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" AndAlso RadGridAccountExecutives.SelectedItems.Count > 0 Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                For Each Item In RadGridAccountExecutives.SelectedItems

                    AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, _ClientCode, _DivisionCode, _ProductCode, Item("EmployeeCode").Text)

                    AdvantageFramework.Database.Procedures.AccountExecutive.Delete(DbContext, AccountExecutive)

                Next

                LoadEmployeesAndAccountExecutives()

            End Using

        End If

    End Sub
    Protected Sub RadButtonIsInactive_Click(sender As Object, e As EventArgs)

        'objects
        Dim DoSave As Boolean = Nothing
        Dim EmployeeCode As String = Nothing
        Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

        EmployeeCode = DirectCast(sender, Telerik.Web.UI.RadButton).CommandArgument

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DoSave = False

            AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, _ClientCode, _DivisionCode, _ProductCode, EmployeeCode)

            If AccountExecutive IsNot Nothing Then

                If DirectCast(sender, Telerik.Web.UI.RadButton).Checked = True Then

                    If AccountExecutive.IsDefaultAccountExecutive.GetValueOrDefault(0) = 1 Then

                        DoSave = True

                        AccountExecutive.IsDefaultAccountExecutive = 0
                        AccountExecutive.IsInactive = 1

                    Else

                        DoSave = True
                        AccountExecutive.IsInactive = 1

                    End If

                Else

                    DoSave = True
                    AccountExecutive.IsInactive = 0

                End If

            End If

            If DoSave Then

                AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AccountExecutive)
                LoadEmployeesAndAccountExecutives()

            End If

        End Using

    End Sub
    Protected Sub RadButtonIsDefault_Click(sender As Object, e As EventArgs)

        'objects
        Dim DoSave As Boolean = Nothing
        Dim EmployeeCode As String = Nothing
        Dim AccountExecutive As AdvantageFramework.Database.Entities.AccountExecutive = Nothing

        EmployeeCode = DirectCast(sender, Telerik.Web.UI.RadButton).CommandArgument

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DoSave = False

            AccountExecutive = AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductAndEmployeeCode(DbContext, _ClientCode, _DivisionCode, _ProductCode, EmployeeCode)

            If AccountExecutive IsNot Nothing Then

                If DirectCast(sender, Telerik.Web.UI.RadButton).Checked = True Then

                    If (From AccountExec In AdvantageFramework.Database.Procedures.AccountExecutive.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode).ToList
                        Where AccountExec.IsDefaultAccountExecutive = 1 AndAlso
                              AccountExec.EmployeeCode <> AccountExecutive.EmployeeCode
                        Select AccountExec).Any Then

                        Me.ShowMessage("Only one default A/E is allowed.")

                        DirectCast(sender, Telerik.Web.UI.RadButton).Checked = False

                    Else

                        DoSave = True
                        AccountExecutive.IsDefaultAccountExecutive = 1
                        AccountExecutive.IsInactive = 0

                    End If

                Else

                    DoSave = True
                    AccountExecutive.IsDefaultAccountExecutive = 0

                End If

            End If

            If DoSave Then

                AdvantageFramework.Database.Procedures.AccountExecutive.Update(DbContext, AccountExecutive)
                LoadEmployeesAndAccountExecutives()

            End If

        End Using

    End Sub
    Private Sub RadGridCompanyProfileAffiliations_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridCompanyProfileAffiliations.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
        Dim MyCompanyProfileAffiliation As AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridCompanyProfileAffiliations.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                If CType(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation
                    CompanyProfileAffiliation.AffiliationID = CType(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox).SelectedValue
                    CompanyProfileAffiliation.CompanyProfileID = TextBoxCompanyProfileID.Text

                    MyCompanyProfileAffiliation = New AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel
                    MyCompanyProfileAffiliation.AffiliationID = CType(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox).SelectedValue
                    CompanyProfileAffiliation.CompanyProfileID = TextBoxCompanyProfileID.Text

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxCompanyProfileID.Text) = False Then

                            _CompanyProfileAffiliationList = Session("ProductEdit_RadGridCompanyProfileAffiliations")

                            If _CompanyProfileAffiliationList Is Nothing Then

                                _CompanyProfileAffiliationList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.CompanyProfileAffiliationViewModel)

                            End If

                            If _CompanyProfileAffiliationList.Where(Function(Entity) Entity.AffiliationID = CompanyProfileAffiliation.AffiliationID).Any = True Then

                                Me.ShowMessage("Affiliation has already been added.  Please choose another.")

                            Else

                                ErrorMessage = CompanyProfileAffiliation.ValidateEntity(IsValid)

                                If IsValid Then

                                    MyCompanyProfileAffiliation.IsEntityBeingAdded = True
                                    _CompanyProfileAffiliationList.Add(MyCompanyProfileAffiliation)
                                    Session("ProductEdit_RadGridCompanyProfileAffiliations") = _CompanyProfileAffiliationList

                                Else

                                    Me.ShowMessage(ErrorMessage)

                                End If

                            End If

                        Else

                            CompanyProfileAffiliation.DbContext = DbContext

                            Reload = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

                        End If

                    End Using

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxCompanyProfileID.Text) = False Then

                        _CompanyProfileAffiliationList = Session("ProductEdit_RadGridCompanyProfileAffiliations")

                        RadComboBox = CType(e.Item.FindControl("RadComboBoxAffiliation"), Telerik.Web.UI.RadComboBox)

                        If _CompanyProfileAffiliationList IsNot Nothing Then

                            Try

                                MyCompanyProfileAffiliation = Nothing
                                MyCompanyProfileAffiliation = (From Entity In _CompanyProfileAffiliationList
                                                               Where Entity.AffiliationID = RadComboBox.SelectedValue
                                                               Select Entity).Single

                            Catch ex As Exception
                                CompanyProfileAffiliation = Nothing
                            End Try

                            If MyCompanyProfileAffiliation IsNot Nothing Then _CompanyProfileAffiliationList.Remove(MyCompanyProfileAffiliation)

                        End If

                            Session("ProductEdit_RadGridCompanyProfileAffiliations") = _CompanyProfileAffiliationList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            CompanyProfileAffiliation = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If CompanyProfileAffiliation IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Delete(DbContext, CompanyProfileAffiliation)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

            _CompanyProfileAffiliationList = Nothing
            LoadCompanyProfileAffiliations()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridCompanyProfileAffiliations_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCompanyProfileAffiliations.ItemDataBound

        'objects
        Dim RadComboBoxAffiliation As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveAffiliation As AdvantageFramework.Database.Entities.Affiliation = Nothing

        If _AffiliationEntityList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _AffiliationEntityList = AdvantageFramework.Database.Procedures.Affiliation.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxAffiliation = DirectCast(e.Item.FindControl("RadComboBoxAffiliation"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxAffiliation Is Nothing Then

                RadComboBoxAffiliation = DirectCast(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxAffiliation IsNot Nothing Then

                RadComboBoxAffiliation.DataSource = (From Affiliation In _AffiliationEntityList
                                                     Where Affiliation.IsInactive = False
                                                     Select Affiliation.ID,
                                                            [Description] = If(Affiliation.IsInactive = False, CStr(Affiliation.Description & " ").Trim, Affiliation.Description & "*")).ToList

                RadComboBoxAffiliation.DataBind()
                RadComboBoxAffiliation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Affiliation In _AffiliationEntityList
                        Where Affiliation.ID = e.Item.DataItem.AffiliationID
                        Select Affiliation).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveAffiliation = AdvantageFramework.Database.Procedures.Affiliation.LoadByID(DbContext, e.Item.DataItem.AffiliationID)

                            If InactiveAffiliation IsNot Nothing Then

                                RadComboBoxAffiliation.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveAffiliation.Description & "*", InactiveAffiliation.ID))
                                RadComboBoxAffiliation.SelectedValue = InactiveAffiliation.ID

                            End If

                        End Using

                    Else

                        RadComboBoxAffiliation.SelectedValue = e.Item.DataItem.AffiliationID

                    End If

                    RadComboBoxAffiliation.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxAffiliation = Nothing
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
    Private Sub RadGridCompetitors_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridCompetitors.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
        Dim MyActivityCompetition As AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim RadComboBox As Telerik.Web.UI.RadComboBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridCompetitors.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                If CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then

                    ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition
                    ActivityCompetition.CompetitionID = CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue
                    ActivityCompetition.ActivityID = TextBoxActivityID.Text

                    MyActivityCompetition = New AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel
                    MyActivityCompetition.CompetitionID = CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue
                    MyActivityCompetition.ActivityID = TextBoxActivityID.Text

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxActivityID.Text) = False Then

                            _ActivityCompetitionList = Session("ProductEdit_RadGridCompetitors")

                            If _ActivityCompetitionList Is Nothing Then

                                _ActivityCompetitionList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.ActivityCompetitionViewModel)

                            End If

                            If _ActivityCompetitionList.Where(Function(Entity) Entity.CompetitionID = ActivityCompetition.CompetitionID).Any = True Then

                                Me.ShowMessage("Competitor has already been added.  Please choose another.")

                            Else

                                ErrorMessage = ActivityCompetition.ValidateEntity(IsValid)

                                If IsValid Then

                                    _ActivityCompetitionList.Add(MyActivityCompetition)
                                    Session("ProductEdit_RadGridCompetitors") = _ActivityCompetitionList

                                Else

                                    Me.ShowMessage(ErrorMessage)

                                End If

                            End If

                        Else

                            ActivityCompetition.DbContext = DbContext
                            Reload = AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                        End If

                    End Using

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _ProductCode = "" OrElse IsNumeric(TextBoxActivityID.Text) = False Then

                        _ActivityCompetitionList = Session("ProductEdit_RadGridCompetitors")

                        RadComboBox = CType(e.Item.FindControl("RadComboBoxCompetitor"), Telerik.Web.UI.RadComboBox)

                        If _ActivityCompetitionList IsNot Nothing Then

                            Try

                                MyActivityCompetition = Nothing
                                MyActivityCompetition = (From Entity In _ActivityCompetitionList
                                                         Where Entity.CompetitionID = RadComboBox.SelectedValue
                                                         Select Entity).Single

                            Catch ex As Exception
                                _ActivityCompetitionList = Nothing
                            End Try

                            If MyActivityCompetition IsNot Nothing Then _ActivityCompetitionList.Remove(MyActivityCompetition)

                        End If

                        Session("ProductEdit_RadGridCompetitors") = _ActivityCompetitionList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            ActivityCompetition = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If ActivityCompetition IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.ActivityCompetition.Delete(DbContext, ActivityCompetition)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

            _ActivityCompetitionList = Nothing
            LoadActivitySummaryCompetitors()

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridCompetitors_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCompetitors.ItemDataBound

        'objects
        Dim RadComboBoxCompetitor As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveCompetitor As AdvantageFramework.Database.Entities.Competition = Nothing

        If _CompetitionEntityList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _CompetitionEntityList = AdvantageFramework.Database.Procedures.Competition.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxCompetitor = DirectCast(e.Item.FindControl("RadComboBoxCompetitor"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxCompetitor Is Nothing Then

                RadComboBoxCompetitor = DirectCast(e.Item.FindControl("RadComboBoxCompetitorEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxCompetitor IsNot Nothing Then

                RadComboBoxCompetitor.DataSource = (From Competition In _CompetitionEntityList
                                                    Where Competition.IsInactive = False
                                                    Select Competition.ID,
                                                           [Description] = If(Competition.IsInactive = False, CStr(Competition.Description & " ").Trim, Competition.Description & "*")).ToList

                RadComboBoxCompetitor.DataBind()

                RadComboBoxCompetitor.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Competition In _CompetitionEntityList
                        Where Competition.ID = e.Item.DataItem.CompetitionID
                        Select Competition).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveCompetitor = AdvantageFramework.Database.Procedures.Competition.LoadByID(DbContext, e.Item.DataItem.CompetitionID)

                            If InactiveCompetitor IsNot Nothing Then

                                RadComboBoxCompetitor.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveCompetitor.Description & "*", InactiveCompetitor.ID))
                                RadComboBoxCompetitor.SelectedValue = InactiveCompetitor.ID

                            End If

                        End Using

                    Else

                        RadComboBoxCompetitor.SelectedValue = e.Item.DataItem.CompetitionID

                    End If

                    RadComboBoxCompetitor.Enabled = False

                End If

            End If

        Catch ex As Exception
            RadComboBoxCompetitor = Nothing
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
    Private Sub RadGridActivitySummary_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridActivitySummary.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridActivitySummary.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "EditDiary"

                Me.OpenWindow("", "Maintenance_DiaryEdit.aspx?Mode=Update&AlertID=" & CurrentGridDataItem.GetDataKeyValue("AlertID"))

        End Select

        If Reload Then

            LoadActivitySummary()

        End If

    End Sub
    Private Sub RadGridActivitySummary_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridActivitySummary.ItemDataBound

        Dim ImageButtonEdit As System.Web.UI.WebControls.ImageButton = Nothing

        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            ImageButtonEdit = e.Item.FindControl("ImageButtonEdit")

            If ImageButtonEdit IsNot Nothing Then

                If e.Item.DataItem.ActivityType = "Diary" Then

                    ImageButtonEdit.Visible = True

                Else

                    ImageButtonEdit.Visible = False

                End If

            End If

        End If

    End Sub
    Private Sub RadGridContracts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContracts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Contract As AdvantageFramework.Database.Entities.Contract = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContracts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                Me.OpenWindow("Contract Edit", "Maintenance_ContractEdit.aspx?Caller=Maintenance_ProductEdit&Mode=Open&ContractID=" & CurrentGridDataItem.GetDataKeyValue("ID") & "&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Contract = AdvantageFramework.Database.Procedures.Contract.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If Contract IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.Contract.Delete(DbContext, Contract)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadContractsTab()

        End If

    End Sub
    Private Sub RadGridContracts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContracts.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub ButtonAddContract_Click(sender As Object, e As EventArgs) Handles ButtonAddContract.Click

        Try

            Me.OpenWindow("New Contract", "Maintenance_ContractEdit.aspx?Caller=Maintenance_ProductEdit&Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButtonAddDiary_Click(sender As Object, e As EventArgs) Handles ButtonAddDiary.Click

        Me.OpenWindow("Add Diary", "Maintenance_DiaryEdit.aspx?Caller=Maintenance_ProductEdit&Mode=Add&AlertTypeID=11&AlertCategoryID=58&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode & "&ProductCode=" & _ProductCode)

    End Sub
    Private Sub CheckBoxContactsShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxContactsShowInactive.CheckedChanged

        LoadContactsTab()

    End Sub

#End Region

#End Region

End Class
