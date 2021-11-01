Namespace WinForm.Presentation.Controls

    Public Class DivisionControl

        Public Event SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs)
        Public Event SelectedProductChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ProductOptionsChanged()
        Public Event SelectedDocumentChanged()
        Public Event InactiveChangedEvent(ByVal IsInactive As Boolean, ByRef Cancel As Boolean)
        Public Event SelectedDetailTabChangedEvent()
        Public Event DivisionSortKeysInitNewRowEvent()
        Public Event DivisionSortKeysSelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _HasASelectedProduct As String = Nothing
        Private _SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey) = Nothing
        Private _SelectedTab As DevComponents.DotNetBar.TabItem = Nothing
        Private _SortNameMaxLength As Long = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _IsCRMUser As Boolean = False
        Private _HasAccessToDocuments As Boolean = False
        Private _CanUserUpdateInClientMaintenance As Boolean = False
        Private _DoesUserHaveAccessToClientContactMaintenance As Boolean = False
        Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DoesUserHaveAccessToClientContactMaintenance() As Boolean
            Get
                DoesUserHaveAccessToClientContactMaintenance = _DoesUserHaveAccessToClientContactMaintenance
            End Get
        End Property
        Public ReadOnly Property CanUserUpdateInClientMaintenance() As Boolean
            Get
                CanUserUpdateInClientMaintenance = _CanUserUpdateInClientMaintenance
            End Get
        End Property
        Public ReadOnly Property SelectedTab() As DevComponents.DotNetBar.TabItem
            Get
                SelectedTab = _SelectedTab
            End Get
        End Property
        Public ReadOnly Property HasASelectedProduct() As Boolean
            Get
                HasASelectedProduct = _HasASelectedProduct
            End Get
        End Property
        Public ReadOnly Property DocumentManager() As AdvantageFramework.WinForm.Presentation.Controls.DocumentManagerControl
            Get
                DocumentManager = DocumentManagerControlDocuments_Documents
            End Get
        End Property
        Public ReadOnly Property ContractManager() As AdvantageFramework.WinForm.Presentation.Controls.ContractManagerControl
            Get
                ContractManager = ContractManagerControlControl_DivisionContracts
            End Get
        End Property
        Public ReadOnly Property IsCRMUser() As Boolean
            Get
                IsCRMUser = _IsCRMUser
            End Get
        End Property
        Public ReadOnly Property HasAccessToDocuments As Boolean
            Get
                HasAccessToDocuments = _HasAccessToDocuments
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

                        _HasAccessToDocuments = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Division)

                        _CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)
                        _DoesUserHaveAccessToClientContactMaintenance = AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact)

                        DataGridViewProducts_Products.DataSourceViewOption = DataGridView.DataSourceViewOptions.Product_ExcludeClientDivision

                        If Me.CanUserUpdateInClientMaintenance Then

                            DataGridViewOptions_SortOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                        Else

                            DataGridViewOptions_SortOptions.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                CheckBoxGeneral_Inactive.ByPassUserEntryChanged = Not Form.Modal

                                Try

                                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Division.Properties.SortName))

                                Catch ex As Exception
                                    _SortNameMaxLength = Nothing
                                End Try

                                AddressControlGeneral_BillingAddress.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCity)
                                AddressControlGeneral_BillingAddress.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCountry)
                                AddressControlGeneral_BillingAddress.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCounty)
                                AddressControlGeneral_BillingAddress.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingAddress2)
                                AddressControlGeneral_BillingAddress.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingState)
                                AddressControlGeneral_BillingAddress.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingAddress)
                                AddressControlGeneral_BillingAddress.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingZip)

                                AddressControlGeneral_StatementAddress.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.City)
                                AddressControlGeneral_StatementAddress.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Country)
                                AddressControlGeneral_StatementAddress.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.County)
                                AddressControlGeneral_StatementAddress.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Address2)
                                AddressControlGeneral_StatementAddress.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.State)
                                AddressControlGeneral_StatementAddress.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Address)
                                AddressControlGeneral_StatementAddress.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Zip)

                                TextBoxGeneral_AttentionLine.SetPropertySettings(AdvantageFramework.Database.Entities.Division.Properties.AttentionLine)
                                TextBoxGeneral_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Division.Properties.Code)
                                TextBoxGeneral_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Division.Properties.Name)

                                ComboBoxGeneral_Client.SetPropertySettings(AdvantageFramework.Database.Entities.Division.Properties.ClientCode)

                                DataGridViewOptions_SortOptions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey))

                                ButtonItemBillingRefresh_Client.Icon = AdvantageFramework.My.Resources.ClientIcon
                                ButtonItemStatementRefresh_Billing.Icon = AdvantageFramework.My.Resources.PurchaseOrderIcon
                                ButtonItemStatementRefresh_Client.Icon = AdvantageFramework.My.Resources.ClientIcon

                                _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, Security.UserSettings.IsCRMUser)
                                ComboBoxNewDivisionOptions_Office.DataSource = AdvantageFramework.Database.Procedures.Office.LoadCore(AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, _Session))

                            End Using

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function LoadSelectedDivision() As AdvantageFramework.Database.Entities.Division

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    Catch ex As Exception
                        Division = Nothing
                    End Try

                End Using

            End If

            LoadSelectedDivision = Division

        End Function
        Private Sub LoadDivisionDetails(ByVal TabItem As DevComponents.DotNetBar.TabItem)

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

                If TabItem Is Nothing Then

                    For Each TabItem In TabControlControl_DivisionDetails.Tabs.OfType(Of DevComponents.DotNetBar.TabItem)()

                        TabItem.Tag = False

                    Next

                    TabItem = TabControlControl_DivisionDetails.SelectedTab

                End If

                If TabItem.Tag = False Then

                    Division = LoadSelectedDivision()

                    If Division IsNot Nothing Then

                        If TabItem Is TabItemDivisionDetails_GeneralTab OrElse _IsCopy Then

                            LoadGeneralTab(Division)

                        End If

                        If TabItem Is TabItemDivisionDetails_ProductsTab Then

                            LoadProductsTab()

                        End If

                        If TabItem Is TabItemDivisionDetails_DocumentsTab Then

                            LoadDocumentsTab()

                        End If

                        If TabItem Is TabItemDivisionDetails_ContactsTab Then

                            LoadContactsTab(Division)

                        End If

                        If TabItem Is TabItemDivisionDetails_ContractsTab Then

                            LoadContractsTab(Division)

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub LoadGeneralTab(ByVal Division As AdvantageFramework.Database.Entities.Division)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            If Division IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If Division.ClientCode IsNot Nothing Then

                        Try

                            ComboBoxGeneral_Client.SelectedValue = Division.ClientCode

                        Catch ex As Exception
                            ComboBoxGeneral_Client.SelectedIndex = 0
                        End Try

                        If ComboBoxGeneral_Client.HasASelectedValue = False Then

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Division.ClientCode)

                            If Client IsNot Nothing Then

                                ComboBoxGeneral_Client.AddComboItemToExistingDataSource(Client.ToString & "*", Client.Code, False)

                                Try

                                    ComboBoxGeneral_Client.SelectedValue = Division.ClientCode

                                Catch ex As Exception
                                    ComboBoxGeneral_Client.SelectedIndex = 0
                                End Try

                            End If

                        End If

                    Else

                        ComboBoxGeneral_Client.SelectedIndex = 0

                    End If

                    If _IsCopy Then

                        CheckBoxGeneral_Inactive.Checked = False

                    Else

                        CheckBoxGeneral_Inactive.Checked = Not Convert.ToBoolean(Division.IsActive.GetValueOrDefault(0))

                    End If

                    TextBoxGeneral_AttentionLine.Text = Division.AttentionLine

                    AddressControlGeneral_BillingAddress.Address = Division.BillingAddress
                    AddressControlGeneral_BillingAddress.Address2 = Division.BillingAddress2
                    AddressControlGeneral_BillingAddress.County = Division.BillingCounty
                    AddressControlGeneral_BillingAddress.City = Division.BillingCity
                    AddressControlGeneral_BillingAddress.State = Division.BillingState
                    AddressControlGeneral_BillingAddress.Zip = Division.BillingZip
                    AddressControlGeneral_BillingAddress.Country = Division.BillingCountry

                    AddressControlGeneral_StatementAddress.Address = Division.Address
                    AddressControlGeneral_StatementAddress.Address2 = Division.Address2
                    AddressControlGeneral_StatementAddress.County = Division.County
                    AddressControlGeneral_StatementAddress.City = Division.City
                    AddressControlGeneral_StatementAddress.State = Division.State
                    AddressControlGeneral_StatementAddress.Zip = Division.Zip
                    AddressControlGeneral_StatementAddress.Country = Division.Country

                End Using

                TabItemDivisionDetails_GeneralTab.Tag = True

            End If

        End Sub
        Private Sub LoadContactsTab(ByVal Division As AdvantageFramework.Database.Entities.Division)

            If Division IsNot Nothing AndAlso Not _IsCopy Then

                ClientContactManagerControlContacts_DivisionContacts.LoadControl(_ClientCode, _DivisionCode, Nothing)

                TabItemDivisionDetails_ContactsTab.Tag = True

            End If

        End Sub
        Private Sub LoadContractsTab(ByVal Division As AdvantageFramework.Database.Entities.Division)

            If Division IsNot Nothing AndAlso Not _IsCopy Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ContractManagerControlControl_DivisionContracts.LoadControl(Division.ClientCode, Division.Code, Nothing) = False Then

                        ContractManagerControlControl_DivisionContracts.Enabled = False
                        ContractManagerControlControl_DivisionContracts.ClearControl()

                    Else

                        ContractManagerControlControl_DivisionContracts.Enabled = True

                    End If

                End Using

                TabItemDivisionDetails_ContractsTab.Tag = True

            End If

        End Sub
        Private Sub LoadDivisionEntity(ByVal Division As AdvantageFramework.Database.Entities.Division)

            Division.Code = TextBoxGeneral_Code.Text
            Division.Name = TextBoxGeneral_Name.Text

            If ComboBoxGeneral_Client.HasASelectedValue Then
                Division.ClientCode = ComboBoxGeneral_Client.GetSelectedValue
            End If

            Division.IsActive = If(CheckBoxGeneral_Inactive.Checked, 0, 1)
            Division.AttentionLine = TextBoxGeneral_AttentionLine.GetText

            If Division.Name.Length > _SortNameMaxLength Then

                Division.SortName = Division.Name.Substring(0, _SortNameMaxLength)

            Else

                Division.SortName = Division.Name

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                    AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlGeneral_BillingAddress, AddressTypeToValidate.Billing)

                End If

            End Using

            Division.BillingAddress = AddressControlGeneral_BillingAddress.Address
            Division.BillingAddress2 = AddressControlGeneral_BillingAddress.Address2
            Division.BillingCounty = AddressControlGeneral_BillingAddress.County
            Division.BillingCity = AddressControlGeneral_BillingAddress.City
            Division.BillingState = AddressControlGeneral_BillingAddress.State
            Division.BillingZip = AddressControlGeneral_BillingAddress.Zip
            Division.BillingCountry = AddressControlGeneral_BillingAddress.Country

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Agency.GetOptionAvaTaxEnabled(DbContext) AndAlso AdvantageFramework.Agency.GetOptionAvaTaxAddressValidationEnabled(DbContext) Then

                    AdvantageFramework.WinForm.Presentation.Controls.AvataxValidateAddress(_Session, AddressControlGeneral_StatementAddress, AddressTypeToValidate.Statement)

                End If

            End Using

            Division.Address = AddressControlGeneral_StatementAddress.Address
            Division.Address2 = AddressControlGeneral_StatementAddress.Address2
            Division.County = AddressControlGeneral_StatementAddress.County
            Division.City = AddressControlGeneral_StatementAddress.City
            Division.State = AddressControlGeneral_StatementAddress.State
            Division.Zip = AddressControlGeneral_StatementAddress.Zip
            Division.Country = AddressControlGeneral_StatementAddress.Country

        End Sub
        Private Sub LoadSortKeys()

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _SortKeyList = AdvantageFramework.Database.Procedures.DivisionSortKey.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList

                End Using

            End If

            DataGridViewOptions_SortOptions.DataSource = _SortKeyList

        End Sub
        Private Sub LoadProductsTab()

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _FromMaintenance Then

                            DataGridViewProducts_Products.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadWithOfficeLimits(DbContext, _Session).Include("Office").Include("Client").Include("Division")
                                                                        Where Product.ClientCode = _ClientCode AndAlso
                                                                              Product.DivisionCode = _DivisionCode
                                                                        Select Product).ToList

                        Else

                            DataGridViewProducts_Products.DataSource = (From Product In AdvantageFramework.Database.Procedures.Product.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext, True)
                                                                        Where Product.ClientCode = _ClientCode AndAlso
                                                                              Product.DivisionCode = _DivisionCode
                                                                        Select Product).ToList

                        End If

                        DataGridViewProducts_Products.CurrentView.BestFitColumns()
                        DataGridViewProducts_Products.CurrentView.AFActiveFilterString = "[IsInactive] = False"

                    End Using

                End Using

            End If

        End Sub
        Private Sub LoadDocumentsTab()

            'objects
            Dim DocumentLevelSetting As AdvantageFramework.Database.Classes.DocumentLevelSetting = Nothing

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso Not _IsCopy Then

                DocumentLevelSetting = New AdvantageFramework.Database.Classes.DocumentLevelSetting(AdvantageFramework.Database.Entities.DocumentLevel.Division) With {.ClientCode = _ClientCode,
                                                                                                                                                                       .DivisionCode = _DivisionCode}

                DocumentManagerControlDocuments_Documents.ClearControl()

                DocumentManagerControlDocuments_Documents.Enabled = DocumentManagerControlDocuments_Documents.LoadControl(Database.Entities.DocumentLevel.Division, DocumentLevelSetting, DocumentManagerControl.Type.Default, Database.Entities.DocumentSubLevel.Default)

            End If

        End Sub
        Private Function GetUpdatedClient() As AdvantageFramework.Database.Entities.Client

            If ComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    GetUpdatedClient = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ComboBoxGeneral_Client.GetSelectedValue)

                End Using

            Else

                GetUpdatedClient = Nothing

            End If

        End Function
        Private Sub UpdateAddressFields(UpdatedInfo As Object, Address As AdvantageFramework.WinForm.Presentation.Controls.AddressControl)

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim BillingAddress As AdvantageFramework.WinForm.Presentation.Controls.AddressControl = Nothing

            If TypeOf UpdatedInfo Is AdvantageFramework.Database.Entities.Client Then

                Client = UpdatedInfo

                If Address.Name = "AddressControlGeneral_BillingAddress" Then

                    Address.Address = Client.BillingAddress
                    Address.Address2 = Client.BillingAddress2
                    Address.City = Client.BillingCity
                    Address.County = Client.BillingCounty
                    Address.State = Client.BillingState
                    Address.Zip = Client.BillingZip
                    Address.Country = Client.BillingCountry

                    Address.Tag = Nothing

                ElseIf Address.Name = "AddressControlGeneral_StatementAddress" Then

                    Address.Address = Client.StatementAddress
                    Address.Address2 = Client.StatementAddress2
                    Address.City = Client.StatementCity
                    Address.County = Client.StatementCounty
                    Address.State = Client.StatementState
                    Address.Zip = Client.StatementZip
                    Address.Country = Client.StatementCountry

                End If


            ElseIf TypeOf UpdatedInfo Is AdvantageFramework.WinForm.Presentation.Controls.AddressControl Then

                BillingAddress = UpdatedInfo

                Address.Address = BillingAddress.Address
                Address.Address2 = BillingAddress.Address2
                Address.City = BillingAddress.City
                Address.County = BillingAddress.County
                Address.State = BillingAddress.State
                Address.Zip = BillingAddress.Zip
                Address.Country = BillingAddress.Country

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            _HasASelectedProduct = DataGridViewProducts_Products.HasOnlyOneSelectedRow

        End Sub
        Private Sub LoadProductTabOptions()

            Dim ProductGridSize As System.Drawing.Size = Nothing

            If Me.FindForm.Modal Then


            Else

                ProductGridSize = New System.Drawing.Size
                ProductGridSize = DataGridViewProducts_Products.Size

                ProductGridSize.Height = ProductGridSize.Height + 26

                DataGridViewProducts_Products.Size = ProductGridSize

            End If

        End Sub

#Region "  Public "

        Public Sub AddProduct()

            Dim ProductCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing Then

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, _ClientCode, _DivisionCode, ProductCode) = System.Windows.Forms.DialogResult.OK Then

                    LoadProductsTab()

                    DataGridViewProducts_Products.SelectRow(0, _ClientCode & "|" & _DivisionCode & "|" & ProductCode)

                End If

            End If

        End Sub
        Public Sub EditProduct()

            Dim ProductCode As String = Nothing

            If DataGridViewProducts_Products.HasOnlyOneSelectedRow AndAlso _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing Then

                ProductCode = DataGridViewProducts_Products.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, _ClientCode, _DivisionCode, ProductCode) = System.Windows.Forms.DialogResult.OK Then

                    LoadProductsTab()

                End If

            End If

        End Sub
        Public Sub CopyProductFrom()

            'objects
            Dim SelectedProducts As IEnumerable = Nothing
            Dim ProductToCopy As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Product, True, False, SelectedProducts) = Windows.Forms.DialogResult.OK Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each SelectedProduct In SelectedProducts

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        ProductToCopy = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, SelectedProduct.ClientCode, SelectedProduct.DivisionCode, SelectedProduct.Code)

                        If ProductToCopy IsNot Nothing Then

                            Product = New AdvantageFramework.Database.Entities.Product

                            Product = AdvantageFramework.Database.Procedures.Product.Copy(ProductToCopy)

                            Product.DbContext = DbContext
                            Product.ClientCode = _ClientCode
                            Product.DivisionCode = _DivisionCode

                            If (From Entity In DbContext.Products
                                Where Entity.Code.ToUpper = Product.Code.ToUpper AndAlso
                                      Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                      Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any Then

                                ProductCode = Product.Code

                                Do While ValidCode = False

                                    DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Product Code", "Please enter a unique code for: " & vbCrLf & Product.ToString, ProductCode, ProductCode, AdvantageFramework.Database.Entities.Product.Properties.Code)

                                    If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                        Exit Do

                                    Else

                                        If (From Entity In DbContext.Products
                                            Where Entity.Code.ToUpper = ProductCode.ToUpper AndAlso
                                                  Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                                  Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any = False Then

                                            Product.Code = ProductCode
                                            ValidCode = True

                                        End If

                                    End If

                                Loop

                            Else

                                ValidCode = True

                            End If

                            If ValidCode Then

                                Try

                                    AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                                    ProductCode = Product.Code
                                    DivisionCode = Product.DivisionCode
                                    ClientCode = Product.ClientCode

                                Catch ex As Exception

                                End Try

                            End If

                        End If

                    Next

                End Using

                LoadProductsTab()

                DataGridViewProducts_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

            End If

        End Sub
        Public Sub CopyProductTo()

            'objects
            Dim SelectedDivisions As IEnumerable = Nothing
            Dim ProductToCopy As AdvantageFramework.Database.Entities.Product = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim ValidCode As Boolean = False
            Dim DialogResult As System.Windows.Forms.DialogResult = System.Windows.Forms.DialogResult.OK

            If _ClientCode IsNot Nothing AndAlso DataGridViewProducts_Products.HasOnlyOneSelectedRow Then

                DivisionCode = _DivisionCode
                ProductCode = DataGridViewProducts_Products.GetFirstSelectedRowBookmarkValue

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(WinForm.Presentation.CRUDDialog.Type.Division, True, True, SelectedDivisions, LimitToNewBusinessClients:=Me.IsCRMUser) = Windows.Forms.DialogResult.OK Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        DialogResult = System.Windows.Forms.DialogResult.OK
                        ValidCode = False

                        ProductToCopy = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, DivisionCode, ProductCode)

                        If ProductToCopy IsNot Nothing Then

                            For Each SelectedDivision In SelectedDivisions

                                Product = New AdvantageFramework.Database.Entities.Product

                                Product = AdvantageFramework.Database.Procedures.Product.Copy(ProductToCopy)

                                Product.DbContext = DbContext
                                Product.ClientCode = SelectedDivision.ClientCode
                                Product.DivisionCode = SelectedDivision.Code

                                If (From Entity In DbContext.Products
                                    Where Entity.Code.ToUpper = Product.Code.ToUpper AndAlso
                                          Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper AndAlso
                                          Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper).Any Then

                                    ProductCode = Product.Code

                                    Do While ValidCode = False

                                        DialogResult = AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Invalid Product Code", "Please enter a unique code for: " & vbCrLf & Product.ToString, ProductCode, ProductCode, AdvantageFramework.Database.Entities.Product.Properties.Code)

                                        If DialogResult = System.Windows.Forms.DialogResult.Cancel Then

                                            Exit Do

                                        Else

                                            If (From Entity In DbContext.Products
                                                Where Entity.Code.ToUpper = ProductCode.ToUpper AndAlso
                                                      Entity.ClientCode.ToUpper = Product.ClientCode.ToUpper AndAlso
                                                      Entity.DivisionCode.ToUpper = Product.DivisionCode.ToUpper).Any = False Then

                                                Product.Code = ProductCode
                                                ValidCode = True

                                            End If

                                        End If

                                    Loop

                                Else

                                    ValidCode = True

                                End If

                                If ValidCode Then

                                    Try

                                        AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                                    Catch ex As Exception

                                    End Try

                                End If

                            Next

                        End If

                    End Using

                    LoadProductsTab()

                End If

            End If

        End Sub
        Public Sub DeleteProduct()

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso DataGridViewProducts_Products.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    ClientCode = _ClientCode
                    DivisionCode = _DivisionCode
                    ProductCode = DataGridViewProducts_Products.GetFirstSelectedRowBookmarkValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                        If Product IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Product.Delete(DbContext, Product) Then

                                LoadProductsTab()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("The product is in use and cannot be deleted.")

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = Me.FillObject(False)

                    If Division IsNot Nothing AndAlso AddressControlGeneral_BillingAddress.Tag Is Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.Division.Update(DbContext, Division)

                        If Not Saved Then

                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                        End If

                    ElseIf AddressControlGeneral_BillingAddress.Tag IsNot Nothing Then

                        ErrorMessage = "Failed to validate billing address."

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
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = Me.FillObject(False)

                    If Division IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Division.Delete(DbContext, Division)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The division is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef ClientCode As String, ByRef DivisionCode As String) As Boolean

            'objects
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim DivSortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False
            Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Division = Me.FillObject(True)

                    If Division IsNot Nothing AndAlso AddressControlGeneral_BillingAddress.Tag Is Nothing Then

                        Division.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division)

                        If Inserted Then

                            If Me.GetSortKeyList IsNot Nothing Then

                                For Each DivisionSortKey In Me.GetSortKeyList.OfType(Of AdvantageFramework.Database.Entities.DivisionSortKey)()

                                    DivSortKey = New AdvantageFramework.Database.Entities.DivisionSortKey

                                    DivSortKey.ClientCode = Division.ClientCode
                                    DivSortKey.DivisionCode = Division.Code
                                    DivSortKey.SortKey = DivisionSortKey.SortKey

                                    AdvantageFramework.Database.Procedures.DivisionSortKey.Insert(DbContext, DivSortKey)

                                Next

                            End If

                            If CheckBoxNewDivisionOptions_DuplicateForProduct.Checked Then

                                Product = AdvantageFramework.Database.Procedures.Product.CreateFromDivision(Division)

                                If Product IsNot Nothing Then

                                    Product.DbContext = DbContext
                                    Product.OfficeCode = ComboBoxNewDivisionOptions_Office.GetSelectedValue

                                    AdvantageFramework.Database.Procedures.Product.Insert(DbContext, Product)

                                End If

                            End If

                            ClientCode = Division.ClientCode
                            DivisionCode = Division.Code

                        Else

                            ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                        End If

                    ElseIf AddressControlGeneral_BillingAddress.Tag IsNot Nothing Then

                        ErrorMessage = "Failed to validate billing address."

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
        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal IsCopy As Boolean, FromMaintenance As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _IsCopy = IsCopy
            _FromMaintenance = FromMaintenance

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _FromMaintenance Then

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.Load(DbContext))

                        Else

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext))

                        End If

                    Else

                        If String.IsNullOrWhiteSpace(_ClientCode) = False Then

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode))

                        Else

                            ComboBoxGeneral_Client.DataSource = AdvantageFramework.Database.Procedures.Client.LoadCore(AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCode(DbContext, SecurityDbContext, _Session.UserCode))

                        End If

                    End If

                End Using

                If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

                    TextBoxGeneral_Code.Enabled = _IsCopy
                    TextBoxGeneral_Code.ReadOnly = Not _IsCopy
                    ComboBoxGeneral_Client.Enabled = _IsCopy

                    Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                    If Division IsNot Nothing Then

                        UpdateAddressFields(Division, AddressControlGeneral_BillingAddress)
                        UpdateAddressFields(Division, AddressControlGeneral_StatementAddress)

                        If _IsCopy = False Then

                            TextBoxGeneral_Code.Text = Division.Code
                            TabItemDivisionDetails_ProductsTab.Visible = True
                            TabItemDivisionDetails_DocumentsTab.Visible = _HasAccessToDocuments
                            TabItemDivisionDetails_ContactsTab.Visible = True
                            TabItemDivisionDetails_ContractsTab.Visible = False
                            GroupBoxLeftColumn_NewDivisionOptions.Visible = False

                        Else

                            TabItemDivisionDetails_ProductsTab.Visible = False
                            TabItemDivisionDetails_DocumentsTab.Visible = False
                            TabItemDivisionDetails_ContactsTab.Visible = False
                            TabItemDivisionDetails_ContractsTab.Visible = False
                            GroupBoxLeftColumn_NewDivisionOptions.Visible = True

                        End If

                        ComboBoxGeneral_Client.SelectedValue = _ClientCode

                        TextBoxGeneral_Name.Text = Division.Name

                        LoadSortKeys()

                        LoadDivisionDetails(Nothing)

                    Else

                        Loaded = False

                    End If

                ElseIf _ClientCode <> "" AndAlso _DivisionCode = Nothing Then

                    Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

                    CheckBoxGeneral_NewBusiness.Checked = CBool(Client.IsNewBusiness.GetValueOrDefault(0))

                    UpdateAddressFields(Client, AddressControlGeneral_BillingAddress)
                    UpdateAddressFields(Client, AddressControlGeneral_StatementAddress)

                    ComboBoxGeneral_Client.Enabled = False
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Name.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Name.ReadOnly = False
                    CheckBoxGeneral_Inactive.Checked = False
                    ComboBoxGeneral_Client.SelectedValue = _ClientCode
                    TabItemDivisionDetails_ProductsTab.Visible = False
                    TabItemDivisionDetails_DocumentsTab.Visible = False
                    TabItemDivisionDetails_ContactsTab.Visible = False
                    TabItemDivisionDetails_ContractsTab.Visible = False
                    GroupBoxLeftColumn_NewDivisionOptions.Visible = True

                Else

                    ComboBoxGeneral_Client.Enabled = True
                    TextBoxGeneral_Code.Enabled = True
                    TextBoxGeneral_Name.Enabled = True
                    TextBoxGeneral_Code.ReadOnly = False
                    TextBoxGeneral_Name.ReadOnly = False
                    TabItemDivisionDetails_ProductsTab.Visible = False
                    TabItemDivisionDetails_DocumentsTab.Visible = False
                    TabItemDivisionDetails_ContactsTab.Visible = False
                    TabItemDivisionDetails_ContractsTab.Visible = False
                    GroupBoxLeftColumn_NewDivisionOptions.Visible = True

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Division

            Dim Division As AdvantageFramework.Database.Entities.Division = Nothing

            Try

                If IsNew Then

                    Division = New AdvantageFramework.Database.Entities.Division

                    LoadDivisionEntity(Division)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

                        If Division IsNot Nothing Then

                            LoadDivisionEntity(Division)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Division = Nothing
            End Try

            FillObject = Division

        End Function
        Public Sub ClearControl()

            TextBoxGeneral_Code.Text = ""
            TextBoxGeneral_Name.Text = ""
            ComboBoxGeneral_Client.SelectedIndex = -1
            DataGridViewOptions_SortOptions.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey))
            TextBoxGeneral_AttentionLine.Text = ""
            CheckBoxGeneral_Inactive.Checked = False
            AddressControlGeneral_BillingAddress.ClearControl()
            AddressControlGeneral_StatementAddress.ClearControl()

            DataGridViewProducts_Products.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function GetSortKeyList() As Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey)

            Dim SortKeyList As Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey) = Nothing

            Try

                SortKeyList = _SortKeyList

            Catch ex As Exception
                SortKeyList = Nothing
            End Try

            GetSortKeyList = SortKeyList

        End Function
		Public Sub UploadDocument()

			DocumentManagerControlDocuments_Documents.UploadNewDocument()

		End Sub
		Public Sub SendASPUploadEmail()

			DocumentManagerControlDocuments_Documents.SendASPUploadEmail()

		End Sub
		Public Sub DownloadDocument()

            DocumentManagerControlDocuments_Documents.DownloadSelectedDocument()

        End Sub
        Public Sub DeleteDocument()

            DocumentManagerControlDocuments_Documents.DeleteSelectedDocument()

        End Sub
        Public Sub DeleteSelectedSortKey()

            'objects
            Dim DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing

            If DataGridViewOptions_SortOptions.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        DivisionSortKey = DataGridViewOptions_SortOptions.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        DivisionSortKey = Nothing
                    End Try

                    If DivisionSortKey IsNot Nothing Then

                        If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.DivisionSortKey.Delete(DbContext, DivisionSortKey) Then

                                    LoadSortKeys()

                                End If

                            End Using

                        Else

                            Try

                                _SortKeyList.Remove(_SortKeyList.Where(Function(DivSortKey) DivSortKey.SortKey = DivisionSortKey.SortKey).FirstOrDefault)

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub CancelAddSelectedSortKey()

            DataGridViewOptions_SortOptions.CancelNewItemRow()

        End Sub
        Public Sub AddContact()

            ClientContactManagerControlContacts_DivisionContacts.AddClientContact()

        End Sub
        Public Sub EditContact()

            ClientContactManagerControlContacts_DivisionContacts.EditSelectedClientContact()

        End Sub
        Public Sub DeleteContact()

            ClientContactManagerControlContacts_DivisionContacts.DeleteSelectedClientContact()

        End Sub
        Public Sub AddContract()

            ContractManagerControlControl_DivisionContracts.AddContract()

        End Sub
        Public Sub CopyContract()

            ContractManagerControlControl_DivisionContracts.CopyContract()

        End Sub
        Public Sub DeleteContract()

            ContractManagerControlControl_DivisionContracts.DeleteSelectedContract()

        End Sub
        Public Sub EditContract()

            ContractManagerControlControl_DivisionContracts.EditContract()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DivisionControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            _SortKeyList = New Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey)

            ButtonItemBillingRefresh_Client.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemStatementRefresh_Billing.Icon = AdvantageFramework.My.Resources.ClientIcon
            ButtonItemStatementRefresh_Billing.Icon = AdvantageFramework.My.Resources.PurchaseOrderIcon

            LoadProductTabOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ComboBoxGeneral_Client_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxGeneral_Client.SelectedValueChanged

            Dim ClientCode As String = Nothing

            If ComboBoxGeneral_Client.HasASelectedValue Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ClientCode = ComboBoxGeneral_Client.GetSelectedValue

                    If AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode).IsNewBusiness.GetValueOrDefault(0) = 1 Then

                        CheckBoxGeneral_NewBusiness.Checked = True

                    Else

                        CheckBoxGeneral_NewBusiness.Checked = False

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonItemRefresh_Client_Click(sender As Object, e As System.EventArgs) Handles ButtonItemBillingRefresh_Client.Click, ButtonItemStatementRefresh_Client.Click

            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim AddressControl As AdvantageFramework.WinForm.Presentation.Controls.AddressControl = Nothing

            If sender Is ButtonItemBillingRefresh_Client Then

                AddressControl = AddressControlGeneral_BillingAddress

            ElseIf sender Is ButtonItemStatementRefresh_Client Then

                AddressControl = AddressControlGeneral_StatementAddress

            End If

            Client = GetUpdatedClient()

            If Client IsNot Nothing AndAlso AddressControl IsNot Nothing Then

                UpdateAddressFields(Client, AddressControl)

            End If

        End Sub
        Private Sub ButtonItemStatementRefresh_Billing_Click(sender As Object, e As System.EventArgs) Handles ButtonItemStatementRefresh_Billing.Click

            UpdateAddressFields(AddressControlGeneral_BillingAddress, AddressControlGeneral_StatementAddress)

        End Sub
        Private Sub DataGridViewProducts_Products_RowDoubleClickEvent() Handles DataGridViewProducts_Products.RowDoubleClickEvent

            Dim ClientCode As String = Nothing
            Dim DivisionCode As String = Nothing
            Dim ProductCode As String = Nothing

            If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing AndAlso DataGridViewProducts_Products.HasOnlyOneSelectedRow Then

                ClientCode = _ClientCode
                DivisionCode = _DivisionCode
                ProductCode = DataGridViewProducts_Products.GetFirstSelectedRowBookmarkValue

                AdvantageFramework.Maintenance.Client.Presentation.ProductEditDialog.ShowFormDialog(_FromMaintenance, ClientCode, DivisionCode, ProductCode)

                LoadProductsTab()

                DataGridViewProducts_Products.SelectRow(0, ClientCode & "|" & DivisionCode & "|" & ProductCode)

            End If

        End Sub
        Private Sub DataGridViewProducts_Products_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewProducts_Products.SelectionChangedEvent

            EnableOrDisableActions()

            RaiseEvent SelectedProductChanged(sender, e)

        End Sub
        Private Sub TabControlControl_DivisionDetails_SelectedTabChanging(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlControl_DivisionDetails.SelectedTabChanging

            LoadDivisionDetails(e.NewTab)

            _SelectedTab = e.NewTab

            RaiseEvent SelectedTabChanging(sender, e)

        End Sub
        Private Sub DocumentManagerControlDocuments_Documents_SelectedDocumentChanged() Handles DocumentManagerControlDocuments_Documents.SelectedDocumentChanged

            RaiseEvent SelectedDocumentChanged()

        End Sub
        Private Sub CheckBoxGeneral_Inactive_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles CheckBoxGeneral_Inactive.CheckedChangedEx

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                RaiseEvent InactiveChangedEvent(CheckBoxGeneral_Inactive.Checked, e.Cancel)

                If e.Cancel Then

                    CheckBoxGeneral_Inactive.Checked = Not CheckBoxGeneral_Inactive.Checked

                End If

            End If

        End Sub
        Private Sub TabControlGeneral_General_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlGeneral_General.SelectedTabChanged

            RaiseEvent SelectedDetailTabChangedEvent()

        End Sub
        Private Sub DataGridViewOptions_SortOptions_AddNewRowEvent(RowObject As Object) Handles DataGridViewOptions_SortOptions.AddNewRowEvent

            'objects
            Dim DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.DivisionSortKey Then

                Me.ShowWaitForm("Processing...")

                DivisionSortKey = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If DivisionSortKey.IsEntityBeingAdded() Then

                        If _ClientCode IsNot Nothing AndAlso _DivisionCode IsNot Nothing Then

                            DivisionSortKey.DbContext = DbContext

                            DivisionSortKey.ClientCode = _ClientCode
                            DivisionSortKey.DivisionCode = _DivisionCode

                            AdvantageFramework.Database.Procedures.DivisionSortKey.Insert(DbContext, DivisionSortKey)

                        Else

                            If _SortKeyList.Where(Function(DivSrtKey) DivSrtKey.SortKey = DivisionSortKey.SortKey).Any = False Then

                                _SortKeyList.Add(DivisionSortKey)

                            End If

                        End If

                    End If

                End Using

                LoadSortKeys()

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewOptions_SortOptions_DataSourceChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewOptions_SortOptions.DataSourceChangedEvent, DataGridViewOptions_SortOptions.Resize

            If DataGridViewOptions_SortOptions.CurrentView.VisibleColumns.Count >= 1 Then

                DataGridViewOptions_SortOptions.CurrentView.VisibleColumns(0).Width = DataGridViewOptions_SortOptions.Width - 35

            End If

        End Sub
        Private Sub DataGridViewOptions_SortOptions_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewOptions_SortOptions.InitNewRowEvent

			DataGridViewOptions_SortOptions.CurrentView.SetRowCellValue(DataGridViewOptions_SortOptions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.DivisionSortKey.Properties.ClientCode.ToString, _ClientCode)
			DataGridViewOptions_SortOptions.CurrentView.SetRowCellValue(DataGridViewOptions_SortOptions.CurrentView.FocusedRowHandle, AdvantageFramework.Database.Entities.DivisionSortKey.Properties.DivisionCode.ToString, _DivisionCode)

			RaiseEvent DivisionSortKeysInitNewRowEvent()

        End Sub
        Private Sub DataGridViewOptions_SortOptions_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewOptions_SortOptions.SelectionChangedEvent

            RaiseEvent DivisionSortKeysSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewOptions_SortOptions_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewOptions_SortOptions.ShowingEditorEvent

            If DataGridViewOptions_SortOptions.IsNewItemRow = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub CheckBoxNewDivisionOptions_DuplicateForProduct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxNewDivisionOptions_DuplicateForProduct.CheckedChanged

            ComboBoxNewDivisionOptions_Office.SetRequired(CheckBoxNewDivisionOptions_DuplicateForProduct.Checked)

            If CheckBoxNewDivisionOptions_DuplicateForProduct.Checked = False Then

                If TypeOf Me.FindForm Is AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm Then

                    DirectCast(Me.FindForm, AdvantageFramework.WinForm.Presentation.BaseForms.BaseForm).ValidateControl(ComboBoxNewDivisionOptions_Office)

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
