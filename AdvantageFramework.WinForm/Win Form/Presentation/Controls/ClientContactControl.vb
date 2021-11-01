Namespace WinForm.Presentation.Controls

    Public Class ClientContactControl

        Public Event CommentGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CommentLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientContactID As Int32 = Nothing
        Private _ClientCode As String = Nothing
        Private _LoadingControl As Boolean = False
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "


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

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            SearchableComboBoxSetup_Client.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.ClientCode)
                            SearchableComboBoxSetup_Client.AddInactiveItemsOnSelectedValue = True
                            TextBoxSetup_Code.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.ContactCode)

                            TextBoxContactInformation_FirstName.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.FirstName)
                            TextBoxContactInformation_LastName.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.LastName)
                            TextBoxContactInformation_MiddleInitial.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.MiddleInitial)
                            TextBoxContactInformation_Title.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.Title)
                            TextBoxContactInformation_Email.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.EmailAddress)
                            TextBoxContactInformation_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.Telephone)
                            TextBoxContactInformation_PhoneExtension.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.TelephoneExtension)
                            TextBoxContactInformation_CellPhone.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.CellPhone)
                            TextBoxContactInformation_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.Fax)
                            TextBoxContactInformation_FaxExtension.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.FaxExtension)

                            AddressControlSetup_Address.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.Address)
                            AddressControlSetup_Address.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.Address2)
                            AddressControlSetup_Address.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.City)
                            AddressControlSetup_Address.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.County)
                            AddressControlSetup_Address.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.State)
                            AddressControlSetup_Address.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.Zip)
                            AddressControlSetup_Address.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.ClientContact.Properties.Country)

                            TextBoxComment_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.ClientContact.Properties.Comments)

                            LoadDropDownDataSources()

                            ButtonItemAddressRefresh_Division.Icon = AdvantageFramework.My.Resources.DivisionIcon
                            ButtonItemAddressRefresh_Product.Icon = AdvantageFramework.My.Resources.ProductIcon
                            ButtonItemAddressRefresh_Client.Icon = AdvantageFramework.My.Resources.ClientIcon

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadClientContactEntity(ByVal ClientContact As AdvantageFramework.Database.Entities.ClientContact)

            If SearchableComboBoxSetup_Client.HasASelectedValue Then
                ClientContact.ClientCode = SearchableComboBoxSetup_Client.GetSelectedValue
            End If

            ClientContact.ContactCode = TextBoxSetup_Code.Text
            ClientContact.ContactTypeID = SearchableComboBoxSetup_ContactType.GetSelectedValue
            ClientContact.IsInactive = Convert.ToInt16(CheckBoxForm_Inactive.Checked)

            ClientContact.FirstName = TextBoxContactInformation_FirstName.GetText
            ClientContact.LastName = TextBoxContactInformation_LastName.GetText
            ClientContact.MiddleInitial = TextBoxContactInformation_MiddleInitial.GetText
            ClientContact.Title = TextBoxContactInformation_Title.GetText
            ClientContact.EmailAddress = TextBoxContactInformation_Email.GetText
            ClientContact.Telephone = TextBoxContactInformation_Phone.GetText
            ClientContact.TelephoneExtension = TextBoxContactInformation_PhoneExtension.GetText
            ClientContact.CellPhone = TextBoxContactInformation_CellPhone.GetText
            ClientContact.Fax = TextBoxContactInformation_Fax.GetText
            ClientContact.FaxExtension = TextBoxContactInformation_FaxExtension.GetText

            ClientContact.Address = AddressControlSetup_Address.Address
            ClientContact.Address2 = AddressControlSetup_Address.Address2
            ClientContact.City = AddressControlSetup_Address.City
            ClientContact.County = AddressControlSetup_Address.County
            ClientContact.State = AddressControlSetup_Address.State
            ClientContact.Zip = AddressControlSetup_Address.Zip
            ClientContact.Country = AddressControlSetup_Address.Country

            ClientContact.ScheduleUser = Convert.ToInt16(CheckBoxOptions_ScheduleUser.CheckValue)
            ClientContact.IsClientPortalUser = Convert.ToInt16(CheckBoxOptions_ClientPortalUser.CheckValue)
            ClientContact.GetAlerts = Convert.ToInt16(CheckBoxOptions_GetsAlerts.CheckValue)
            ClientContact.GetEmails = Convert.ToInt16(CheckBoxOptions_EmailRecipient.CheckValue)

            ClientContact.Comments = TextBoxComment_Comment.GetText

        End Sub
        Private Sub UpdateAddressFields(UpdatedInfo As Object, Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Client Then

                Client = UpdatedInfo

                Address.Address = Client.Address
                Address.Address2 = Client.Address2
                Address.City = Client.City
                Address.County = Client.County
                Address.State = Client.State
                Address.Zip = Client.Zip
                Address.Country = Client.Country

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Division Then

                Division = UpdatedInfo

                Address.Address = Division.BillingAddress
                Address.Address2 = Division.BillingAddress2
                Address.City = Division.BillingCity
                Address.County = Division.BillingCounty
                Address.State = Division.BillingState
                Address.Zip = Division.BillingZip
                Address.Country = Division.BillingCountry

            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Product Then

                Product = UpdatedInfo

                Address.Address = Product.BillingAddress
                Address.Address2 = Product.BillingAddress2
                Address.City = Product.BillingCity
                Address.County = Product.BillingCounty
                Address.State = Product.BillingState
                Address.Zip = Product.BillingZip
                Address.Country = Product.BillingCountry

            End If

        End Sub
        Private Sub EnableOrDisableActions()


        End Sub
        Private Sub LoadDivisionProductTree()

            Dim ClientCode As String = Nothing
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim DivisionNode As Telerik.WinControls.UI.RadTreeNode = Nothing
            Dim ProductNode As Telerik.WinControls.UI.RadTreeNode = Nothing
            Dim DivisionList As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim ProductList As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing

            _LoadingControl = True

            If SearchableComboBoxSetup_Client.HasASelectedValue Then

                ClientCode = SearchableComboBoxSetup_Client.GetSelectedValue

                RadTreeViewRightSection_DivisionProducts.Nodes.Clear()

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DivisionList = AdvantageFramework.Database.Procedures.Division.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(Entity) Entity.ClientCode = ClientCode).ToList

                        ClientContactDetailList = AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext).ToList

                        For Each Division In DivisionList

                            ProductList = AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, False).Where(Function(Entity) Entity.ClientCode = ClientCode AndAlso
                                                                                                                                                                                                      Entity.DivisionCode = Division.Code).ToList

                            DivisionNode = New Telerik.WinControls.UI.RadTreeNode

                            DivisionNode.CheckType = Telerik.WinControls.UI.CheckType.None
                            DivisionNode.Value = Division
                            DivisionNode.Text = If(Convert.ToBoolean(Division.IsActive), Division.ToString, Division.ToString & " *")

                            If ClientContactDetailList.Where(Function(CCDetail) CCDetail.ContactID = _ClientContactID AndAlso CCDetail.DivisionCode = Division.Code AndAlso CCDetail.ProductCode = Nothing).Count > 0 Then

                                DivisionNode.Checked = True
                                DivisionNode.Tag = ClientContactDetailList.Where(Function(CCDetail) CCDetail.ContactID = _ClientContactID AndAlso CCDetail.DivisionCode = Division.Code AndAlso CCDetail.ProductCode = Nothing)

                            ElseIf _ClientContactID = 0 Then

                                If _DivisionCode = Division.Code Then

                                    DivisionNode.Checked = True

                                End If

                            Else

                                DivisionNode.Visible = Convert.ToBoolean(Division.IsActive)
                                DivisionNode.Checked = False
                                DivisionNode.Tag = Nothing

                            End If

                            RadTreeViewRightSection_DivisionProducts.Nodes.Add(DivisionNode)

                            For Each Product In ProductList.Where(Function(Prod) Prod.DivisionCode = Division.Code)

                                ProductNode = New Telerik.WinControls.UI.RadTreeNode

                                ProductNode.Text = If(Convert.ToBoolean(Product.IsActive), Product.ToString, Product.ToString & " *")
                                ProductNode.Value = Product
                                ProductNode.Enabled = True

                                If ClientContactDetailList.Where(Function(CCDetail) CCDetail.ContactID = _ClientContactID AndAlso CCDetail.DivisionCode = Division.Code AndAlso CCDetail.ProductCode = Product.Code).Count > 0 Then

                                    ProductNode.Checked = True
                                    ProductNode.Tag = ClientContactDetailList.Where(Function(CCDetail) CCDetail.ContactID = _ClientContactID AndAlso CCDetail.DivisionCode = Division.Code AndAlso CCDetail.ProductCode = Product.Code)

                                ElseIf _ClientContactID = 0 Then

                                    If _ProductCode = Product.Code Then

                                        ProductNode.Checked = True

                                    End If

                                Else

                                    ProductNode.Visible = Convert.ToBoolean(Product.IsActive)
                                    ProductNode.Checked = False
                                    ProductNode.Tag = Nothing

                                End If

                                DivisionNode.Nodes.Add(ProductNode)

                            Next

                        Next

                    End Using

                End Using

            End If

            If RadTreeViewRightSection_DivisionProducts.Nodes.Count > 0 Then

                RadTreeViewRightSection_DivisionProducts.ExpandAll()

            End If

            _LoadingControl = False

        End Sub
        Private Sub CreateMenuItems()

            Dim DivisionSubItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem = Nothing
            Dim ProductSubItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem = Nothing

            ButtonItemAddressRefresh_Division.SubItems.Clear()
            ButtonItemAddressRefresh_Product.SubItems.Clear()

            For Each DivisionNode In RadTreeViewRightSection_DivisionProducts.Nodes

                If DivisionNode.Checked Then

                    DivisionSubItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
                    DivisionSubItem.ImageFixedSize = New System.Drawing.Size(16, 16)
                    DivisionSubItem.Text = DivisionNode.Text
                    DivisionSubItem.Tag = DivisionNode.Value
                    DivisionSubItem.Icon = AdvantageFramework.My.Resources.DivisionIcon

                    AddHandler DivisionSubItem.Click, AddressOf RefreshMenuItem_Click

                    ButtonItemAddressRefresh_Division.SubItems.Add(DivisionSubItem)

                    For Each ProductNode In DivisionNode.Nodes

                        If ProductNode.Checked Then

                            ProductSubItem = New AdvantageFramework.WinForm.Presentation.Controls.ButtonItem
                            ProductSubItem.ImageFixedSize = New System.Drawing.Size(16, 16)

                            ProductSubItem.Text = ProductNode.Text
                            ProductSubItem.Tag = ProductNode.Value
                            ProductSubItem.Icon = AdvantageFramework.My.Resources.ProductIcon

                            AddHandler ProductSubItem.Click, AddressOf RefreshMenuItem_Click

                            ButtonItemAddressRefresh_Product.SubItems.Add(ProductSubItem)

                        End If

                    Next

                End If

            Next

            ButtonItemAddressRefresh_Division.Enabled = Convert.ToBoolean(ButtonItemAddressRefresh_Division.SubItems.Count)
            ButtonItemAddressRefresh_Product.Enabled = Convert.ToBoolean(ButtonItemAddressRefresh_Product.SubItems.Count)

        End Sub
        Private Function GetUpdatedClient() As AdvantageFramework.Database.Entities.Client

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            If SearchableComboBoxSetup_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, SearchableComboBoxSetup_Client.GetSelectedValue)

                End Using

            End If

            GetUpdatedClient = Client

        End Function
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SearchableComboBoxSetup_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).Where(Function(Entity) Entity.IsActive = 1)
                    SearchableComboBoxSetup_ContactType.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).OrderBy(Function(Entity) Entity.Description)

                End Using

            End Using

        End Sub

#Region "  Public "

        Public Function LoadControl(Optional ByVal ClientContactID As Int32 = Nothing, Optional ByVal ClientCode As String = "", Optional ByVal DivisionCode As String = Nothing, Optional ByVal ProductCode As String = Nothing) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            _ClientContactID = ClientContactID
            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientContactID <> Nothing Then

                    ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, _ClientContactID)

                    If ClientContact IsNot Nothing Then

                        TextBoxSetup_Code.ReadOnly = True
                        SearchableComboBoxSetup_Client.Enabled = False
                        SearchableComboBoxSetup_Client.SelectedValue = ClientContact.ClientCode

                        If ClientCode = "" Then

                            _ClientCode = ClientContact.ClientCode

                        End If

                        TextBoxComment_Comment.Text = ClientContact.Comments
                        TextBoxContactInformation_CellPhone.Text = ClientContact.CellPhone
                        TextBoxContactInformation_Email.Text = ClientContact.EmailAddress
                        TextBoxContactInformation_Fax.Text = ClientContact.Fax
                        TextBoxContactInformation_FaxExtension.Text = ClientContact.FaxExtension
                        TextBoxContactInformation_FirstName.Text = ClientContact.FirstName
                        TextBoxContactInformation_LastName.Text = ClientContact.LastName
                        TextBoxContactInformation_MiddleInitial.Text = ClientContact.MiddleInitial
                        TextBoxContactInformation_Phone.Text = ClientContact.Telephone
                        TextBoxContactInformation_PhoneExtension.Text = ClientContact.TelephoneExtension
                        TextBoxContactInformation_Title.Text = ClientContact.Title
                        TextBoxSetup_Code.Text = ClientContact.ContactCode

                        AddressControlSetup_Address.Address = ClientContact.Address
                        AddressControlSetup_Address.City = ClientContact.City
                        AddressControlSetup_Address.Country = ClientContact.Country
                        AddressControlSetup_Address.County = ClientContact.County
                        AddressControlSetup_Address.Address2 = ClientContact.Address2
                        AddressControlSetup_Address.Zip = ClientContact.Zip
                        AddressControlSetup_Address.State = ClientContact.State

                        SearchableComboBoxSetup_ContactType.SelectedValue = ClientContact.ContactTypeID
                        CheckBoxForm_Inactive.Checked = Convert.ToBoolean(ClientContact.IsInactive.GetValueOrDefault(0))
                        CheckBoxOptions_ClientPortalUser.Checked = Convert.ToBoolean(ClientContact.IsClientPortalUser)

                        CheckBoxOptions_EmailRecipient.Enabled = CheckBoxOptions_ClientPortalUser.Checked
                        CheckBoxOptions_GetsAlerts.Enabled = CheckBoxOptions_ClientPortalUser.Checked
                        CheckBoxOptions_EmailRecipient.Checked = Convert.ToBoolean(ClientContact.GetEmails)
                        CheckBoxOptions_GetsAlerts.Checked = Convert.ToBoolean(ClientContact.GetAlerts)

                        CheckBoxOptions_ScheduleUser.Checked = Convert.ToBoolean(ClientContact.ScheduleUser)

                        CreateMenuItems()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The client you are trying to edit does not exist anymore.")

                    End If

                ElseIf _ClientCode <> "" Then

                    SearchableComboBoxSetup_Client.SelectedValue = _ClientCode
                    TextBoxSetup_Code.ReadOnly = False
                    CheckBoxForm_Inactive.Checked = False
                    CheckBoxOptions_GetsAlerts.Enabled = False
                    CheckBoxOptions_EmailRecipient.Enabled = False

                Else

                    SearchableComboBoxSetup_Client.Enabled = True
                    TextBoxSetup_Code.ReadOnly = False
                    CheckBoxOptions_GetsAlerts.Enabled = False
                    CheckBoxOptions_EmailRecipient.Enabled = False

                End If

                If _ProductCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso _ClientCode IsNot Nothing Then

                    ButtonItemAddressRefresh_Client.Enabled = True
                    ButtonItemAddressRefresh_Division.Enabled = True
                    ButtonItemAddressRefresh_Product.Enabled = True

                    SearchableComboBoxSetup_Client.Enabled = False

                ElseIf _DivisionCode IsNot Nothing AndAlso _ClientCode IsNot Nothing Then

                    ButtonItemAddressRefresh_Client.Enabled = True
                    ButtonItemAddressRefresh_Division.Enabled = True
                    ButtonItemAddressRefresh_Product.Enabled = False

                    SearchableComboBoxSetup_Client.Enabled = False

                ElseIf _ClientCode IsNot Nothing Then

                    ButtonItemAddressRefresh_Client.Enabled = True
                    ButtonItemAddressRefresh_Division.Enabled = False
                    ButtonItemAddressRefresh_Product.Enabled = False

                Else

                    ButtonItemAddressRefresh_Client.Enabled = False
                    ButtonItemAddressRefresh_Division.Enabled = False
                    ButtonItemAddressRefresh_Product.Enabled = False

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.ClientContact

            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing

            Try

                If IsNew Then

                    ClientContact = New AdvantageFramework.Database.Entities.ClientContact

                    LoadClientContactEntity(ClientContact)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, _ClientContactID)

                        If ClientContact IsNot Nothing Then

                            LoadClientContactEntity(ClientContact)

                        End If

                    End Using

                End If

            Catch ex As Exception
                ClientContact = Nothing
            End Try

            FillObject = ClientContact

        End Function
        Public Function Save() As Boolean

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
            Dim OriginalContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContact = Me.FillObject(False)

                    If ClientContact IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.ClientContact.Update(DbContext, ClientContact) Then

                            Saved = True

                            OriginalContactDetailList = AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, ClientContact.ContactID).ToList

                            For Each ClientContactDetail In OriginalContactDetailList

                                AdvantageFramework.Database.Procedures.ClientContactDetail.Delete(DbContext, ClientContactDetail)

                            Next

                            DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = " & ClientContact.ContactID)

                            _ClientContactID = ClientContact.ContactID

                            ClientContactDetailList = Me.LoadClientContactDetailEntities()

                            If ClientContactDetailList IsNot Nothing AndAlso ClientContactDetailList.Count > 0 Then

                                For Each ClientContactDetail In ClientContactDetailList

                                    ClientContactDetail.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.ClientContactDetail.Insert(DbContext, ClientContactDetail)

                                Next

                            Else

                                Using DbContextSecurity = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    Dim Product As AdvantageFramework.Security.Database.Entities.Product = Nothing

                                    For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoadAllActive(DbContextSecurity).Where(Function(Prod) Prod.ClientCode = ClientContact.ClientCode).ToList

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" &
                                                                                        "VALUES({0}, '{1}', '{2}', '{3}')", ClientContact.ContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

                                    Next

                                    For Each Division In AdvantageFramework.Security.Database.Procedures.Division.LoadAllActive(DbContextSecurity).Where(Function(Div) Div.ClientCode = ClientContact.ClientCode AndAlso Div.Products.Count = 0).ToList

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE])" &
                                                                                        "VALUES({0}, '{1}', '{2}')", ClientContact.ContactID, Division.ClientCode, Division.Code))

                                    Next

                                End Using

                            End If

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContact = Me.FillObject(False)

                    If ClientContact IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.ClientContact.Delete(DbContext, ClientContact) Then

                            Deleted = True

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ClientContactID As String) As Boolean

            Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientContact = Me.FillObject(True)

                    If ClientContact IsNot Nothing Then

                        ClientContact.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.ClientContact.Insert(DbContext, ClientContact) Then

                            Inserted = True

                            _ClientContactID = ClientContact.ContactID

                            ClientContactDetailList = Me.LoadClientContactDetailEntities()

                            If ClientContactDetailList IsNot Nothing Then

                                For Each ClientContactDetail In ClientContactDetailList

                                    ClientContactDetail.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.ClientContactDetail.Insert(DbContext, ClientContactDetail)

                                Next

                            End If

                            ClientContactID = Convert.ToString(ClientContact.ContactID)

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadClientContactDetailEntities() As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail)

            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
            Dim ClientContactDetail As AdvantageFramework.Database.Entities.ClientContactDetail = Nothing

            Try

                ClientContactDetailList = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail)

                For Each DivisionNode In RadTreeViewRightSection_DivisionProducts.Nodes

                    If DivisionNode.Nodes.Where(Function(Node) Node.Checked).Count > 0 Then

                        For Each ProductNode In DivisionNode.Nodes.Where(Function(Node) Node.Checked)

                            ClientContactDetail = New AdvantageFramework.Database.Entities.ClientContactDetail

                            ClientContactDetail.ContactID = _ClientContactID
                            ClientContactDetail.DivisionCode = DivisionNode.Value.Code
                            ClientContactDetail.ProductCode = ProductNode.Value.Code

                            ClientContactDetailList.Add(ClientContactDetail)

                        Next

                    ElseIf DivisionNode.Checked Then

                        ClientContactDetail = New AdvantageFramework.Database.Entities.ClientContactDetail

                        ClientContactDetail.ContactID = _ClientContactID
                        ClientContactDetail.DivisionCode = DivisionNode.Value.Code
                        ClientContactDetail.ProductCode = Nothing

                        ClientContactDetailList.Add(ClientContactDetail)

                    End If

                Next

                LoadClientContactDetailEntities = ClientContactDetailList

            Catch ex As Exception
                LoadClientContactDetailEntities = Nothing
            End Try

        End Function
        Public Sub ClearControl()

            SearchableComboBoxSetup_Client.SelectedValue = Nothing
            SearchableComboBoxSetup_ContactType.SelectedValue = Nothing
            TextBoxSetup_Code.Text = ""
            CheckBoxForm_Inactive.Checked = False
            TextBoxContactInformation_FirstName.Text = ""
            TextBoxContactInformation_LastName.Text = ""
            TextBoxContactInformation_MiddleInitial.Text = ""
            TextBoxContactInformation_Title.Text = ""
            TextBoxContactInformation_Email.Text = ""
            TextBoxContactInformation_Phone.Text = ""
            TextBoxContactInformation_PhoneExtension.Text = ""
            TextBoxContactInformation_CellPhone.Text = ""
            TextBoxContactInformation_Fax.Text = ""
            TextBoxContactInformation_FaxExtension.Text = ""
            AddressControlSetup_Address.Address = ""
            AddressControlSetup_Address.Address2 = ""
            AddressControlSetup_Address.City = ""
            AddressControlSetup_Address.County = ""
            AddressControlSetup_Address.State = ""
            AddressControlSetup_Address.Zip = ""
            AddressControlSetup_Address.Country = ""
            TextBoxComment_Comment.Text = ""
            CheckBoxOptions_ClientPortalUser.Checked = False
            CheckBoxOptions_EmailRecipient.Checked = False
            CheckBoxOptions_GetsAlerts.Checked = False
            CheckBoxOptions_ScheduleUser.Checked = False
            ButtonItemAddressRefresh_Division.SubItems.Clear()
            ButtonItemAddressRefresh_Product.SubItems.Clear()
            RadTreeViewRightSection_DivisionProducts.Nodes.Clear()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ClientContactControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load


        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub SearchableComboBoxSetup_Client_EditValueChanged(sender As Object, e As System.EventArgs) Handles SearchableComboBoxSetup_Client.EditValueChanged

            ButtonItemAddressRefresh_Client.Enabled = SearchableComboBoxSetup_Client.HasASelectedValue
            LoadDivisionProductTree()

        End Sub
        Private Sub RadTreeViewRightSecion_DivisionProducts_NodeCheckedChanged(sender As Object, e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles RadTreeViewRightSection_DivisionProducts.NodeCheckedChanged

            'objects
            Dim ClientContactDetailList As Generic.List(Of AdvantageFramework.Database.Entities.ClientContactDetail) = Nothing
            Dim Product As AdvantageFramework.Security.Database.Entities.Product = Nothing

            CreateMenuItems()

            If _LoadingControl = False Then

                If _ClientContactID <> Nothing AndAlso _ClientCode <> "" Then

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each ClientContactDetail In AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, _ClientContactID).ToList

                                AdvantageFramework.Database.Procedures.ClientContactDetail.Delete(DbContext, ClientContactDetail)

                            Next

                            DbContext.Database.ExecuteSqlCommand("DELETE FROM dbo.CP_SEC_CLIENT WHERE [CDP_CONTACT_ID] = " & _ClientContactID)

                            ClientContactDetailList = Me.LoadClientContactDetailEntities()

                            If ClientContactDetailList IsNot Nothing AndAlso ClientContactDetailList.Count > 0 Then

                                For Each ClientContactDetail In ClientContactDetailList

                                    ClientContactDetail.DbContext = DbContext

                                    AdvantageFramework.Database.Procedures.ClientContactDetail.Insert(DbContext, ClientContactDetail)

                                Next

                            Else

                                Using DbContextSecurity = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                    For Each Product In AdvantageFramework.Security.Database.Procedures.Product.LoadAllActive(DbContextSecurity).Where(Function(Prod) Prod.ClientCode = _ClientCode).ToList

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE], [PRD_CODE])" &
                                                                                        "VALUES({0}, '{1}', '{2}', '{3}')", _ClientContactID, Product.ClientCode, Product.DivisionCode, Product.Code))

                                    Next

                                    For Each Division In AdvantageFramework.Security.Database.Procedures.Division.LoadAllActive(DbContextSecurity).Where(Function(Div) Div.ClientCode = _ClientCode AndAlso Div.Products.Count = 0).ToList

                                        DbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO dbo.CP_SEC_CLIENT([CDP_CONTACT_ID], [CL_CODE], [DIV_CODE])" &
                                                                                        "VALUES({0}, '{1}', '{2}')", _ClientContactID, Division.ClientCode, Division.Code))

                                    Next

                                End Using

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                End If

            End If

        End Sub
        Private Sub RefreshMenuItem_Click(sender As Object, e As System.EventArgs)

            Dim ButtonItem As AdvantageFramework.WinForm.Presentation.Controls.ButtonItem = Nothing

            If TypeOf sender Is AdvantageFramework.WinForm.Presentation.Controls.ButtonItem Then

                ButtonItem = sender

                UpdateAddressFields(ButtonItem.Tag, AddressControlSetup_Address)

            End If

        End Sub
        Private Sub ButtonItemAddressRefresh_Client_Click(sender As Object, e As System.EventArgs) Handles ButtonItemAddressRefresh_Client.Click

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            Client = GetUpdatedClient()

            If Client IsNot Nothing Then

                UpdateAddressFields(Client, AddressControlSetup_Address)

            End If

        End Sub
        Private Sub ButtonItemAddressRefresh_Division_Click(sender As Object, e As EventArgs) Handles ButtonItemAddressRefresh_Division.Click

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            If _DivisionCode IsNot Nothing AndAlso _ClientCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    If Division IsNot Nothing Then

                        UpdateAddressFields(Division, AddressControlSetup_Address)

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemAddressRefresh_Product_Click(sender As Object, e As EventArgs) Handles ButtonItemAddressRefresh_Product.Click

            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If _ProductCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso _ClientCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If Product IsNot Nothing Then

                        UpdateAddressFields(Product, AddressControlSetup_Address)

                    End If

                End Using

            End If

        End Sub
        Private Sub CheckBoxOptions_ClientPortalUser_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxOptions_ClientPortalUser.CheckedChanged

            CheckBoxOptions_GetsAlerts.Enabled = sender.Checked
            CheckBoxOptions_EmailRecipient.Enabled = sender.Checked

            If Not sender.Checked Then

                CheckBoxOptions_GetsAlerts.Checked = False
                CheckBoxOptions_EmailRecipient.Checked = False

            End If

        End Sub
        Private Sub TextBoxComment_Comment_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxComment_Comment.GotFocus

            RaiseEvent CommentGotFocusEvent(sender, e)

        End Sub
		Private Sub TextBoxComment_Comment_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxComment_Comment.LostFocus

			RaiseEvent CommentLostFocusEvent(sender, e)

		End Sub
		Private Sub TextBoxContactInformation_Email_FinalizeValidationEvent(ByRef IsValid As Boolean, ByRef ErrorText As String) Handles TextBoxContactInformation_Email.FinalizeValidationEvent

			'objects
			Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
			Dim ClientPortalUser As AdvantageFramework.Security.Database.Entities.ClientPortalUser = Nothing
			Dim APIReponse As AdvantageFramework.ConceptShare.Classes.APIResponse = Nothing

			If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm AndAlso
					DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).FormAction = FormActions.None Then

				If IsValid Then

					Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

						Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

							Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

								ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, _ClientContactID)

								If ClientContact IsNot Nothing Then

									ClientPortalUser = AdvantageFramework.Security.Database.Procedures.ClientPortalUser.LoadByClientContactID(SecurityDbContext, _ClientContactID)

									If ClientPortalUser IsNot Nothing AndAlso ClientPortalUser.ConceptShareUserID.GetValueOrDefault(0) > 0 Then

										If String.IsNullOrWhiteSpace(TextBoxContactInformation_Email.Text) AndAlso String.IsNullOrWhiteSpace(ClientContact.EmailAddress) = False Then

											If AdvantageFramework.WinForm.MessageBox.Show("Removing the email address from this client contact will remove the client contact from ConceptShare." &
																						  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
																						  AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Deleting, "Removing User...")

												APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, New Security.Classes.ClientPortalUser(ClientPortalUser))

												If APIReponse.CompletedSuccessfully Then

													AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

												Else

													AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

													TextBoxContactInformation_Email.Text = ClientContact.EmailAddress

												End If

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

											Else

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Refreshing, "Refeshing...")

												TextBoxContactInformation_Email.Text = ClientContact.EmailAddress

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

											End If

										ElseIf TextBoxContactInformation_Email.Text <> ClientContact.EmailAddress Then

											If AdvantageFramework.WinForm.MessageBox.Show("Changing the email address for this client contact will remove the client contact from ConceptShare." &
																						  System.Environment.NewLine & System.Environment.NewLine & "Are you sure you want to continue?",
																						  AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo, "ConceptShare") = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Deleting, "Removing User...")

												APIReponse = AdvantageFramework.ConceptShare.RemoveConceptShareUser(DataContext, New Security.Classes.ClientPortalUser(ClientPortalUser))

												If APIReponse.CompletedSuccessfully Then

													AdvantageFramework.WinForm.MessageBox.Show("ConceptShare user removed!")

												Else

													AdvantageFramework.WinForm.MessageBox.Show(APIReponse.ErrorMessage)

													TextBoxContactInformation_Email.Text = ClientContact.EmailAddress

												End If

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

											Else

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.Refreshing, "Refeshing...")

												TextBoxContactInformation_Email.Text = ClientContact.EmailAddress

												DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SetFormActionAndShowWaitForm(FormActions.None)

											End If

										End If

									End If

								End If

							End Using

						End Using

					End Using

				End If

			End If

		End Sub

#End Region

#End Region

	End Class

End Namespace
