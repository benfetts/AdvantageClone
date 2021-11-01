Namespace WinForm.Presentation.Controls

    Public Class VendorRepresentativeControl

#Region " Constants "


#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorRepCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _SelectedClients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
        Private _CanUserPrint As Boolean = False
        Private _CanUserUpdate As Boolean = False
        Private _CanUserAdd As Boolean = False
        Private _LockVendorSelection As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserPrint As Boolean
            Get
                CanUserPrint = _CanUserPrint
            End Get
        End Property
        Public ReadOnly Property CanUserUpdate As Boolean
            Get
                CanUserUpdate = _CanUserUpdate
            End Get
        End Property
        Public ReadOnly Property CanUserAdd As Boolean
            Get
                CanUserAdd = _CanUserAdd
            End Get
        End Property
        Public ReadOnly Property SelectedClients As Generic.List(Of AdvantageFramework.Database.Entities.Client)
            Get
                SelectedClients = _SelectedClients
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            ''AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

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

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
                        _CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)
                        _CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Media_VendorRep)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            SearchableComboBoxSetup_Vendor.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.VendorCode)
                            TextBoxSetup_Code.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Code)
                            TextBoxSetup_FirmName.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.FirmName)
                            'TextBoxSetup_Label.SetPropertySettings( AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Label)
                            TextBoxSetup_FirstName.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.FirstName)
                            TextBoxSetup_MiddleInitial.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.MiddleInitial)
                            TextBoxSetup_LastName.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.LastName)

                            AddressControlSetup_Address.SetStreetPropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Address1)
                            AddressControlSetup_Address.SetAddress2PropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Address2)
                            AddressControlSetup_Address.SetCityPropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.City)
                            AddressControlSetup_Address.SetStatePropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.State)
                            AddressControlSetup_Address.SetZipPropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Zip)
                            AddressControlSetup_Address.SetCountyPropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.County)
                            AddressControlSetup_Address.SetCountryPropertySettings(DataContext, AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Country)

                            TextBoxSetup_Cell.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.CellPhone)
                            TextBoxSetup_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Telephone)
                            TextBoxSetup_PhoneExt.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.TelephoneExtension)
                            TextBoxSetup_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.Fax)
                            TextBoxSetup_FaxExt.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.FaxExtension)
                            TextBoxSetup_Email.SetPropertySettings(AdvantageFramework.Database.Entities.VendorRepresentative.Properties.EmailAddress)

                            LoadDropDownDataSources()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadVendorRepresentativeEntity(ByVal VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative)

            If VendorRepresentative IsNot Nothing Then

                VendorRepresentative.VendorCode = SearchableComboBoxSetup_Vendor.SelectedValue
                VendorRepresentative.Code = TextBoxSetup_Code.Text
                VendorRepresentative.IsInactive = If(CheckBoxSetup_Inactive.Checked, 1, 0)
                VendorRepresentative.FirmName = TextBoxSetup_FirmName.Text
                'VendorRepresentative.Label = TextBoxSetup_Label.Text
                VendorRepresentative.ContactTypeID = SearchableComboBoxSetup_ContactType.GetSelectedValue
                VendorRepresentative.FirstName = TextBoxSetup_FirstName.Text
                VendorRepresentative.MiddleInitial = TextBoxSetup_MiddleInitial.Text
                VendorRepresentative.LastName = TextBoxSetup_LastName.Text

                VendorRepresentative.Address1 = AddressControlSetup_Address.Address
                VendorRepresentative.Address2 = AddressControlSetup_Address.Address2
                VendorRepresentative.City = AddressControlSetup_Address.City
                VendorRepresentative.State = AddressControlSetup_Address.State
                VendorRepresentative.Zip = AddressControlSetup_Address.Zip
                VendorRepresentative.County = AddressControlSetup_Address.County
                VendorRepresentative.Country = AddressControlSetup_Address.Country

                VendorRepresentative.CellPhone = TextBoxSetup_Cell.Text
                VendorRepresentative.Telephone = TextBoxSetup_Phone.Text
                VendorRepresentative.TelephoneExtension = TextBoxSetup_PhoneExt.Text
                VendorRepresentative.Fax = TextBoxSetup_Fax.Text
                VendorRepresentative.FaxExtension = TextBoxSetup_FaxExt.Text
                VendorRepresentative.EmailAddress = TextBoxSetup_Email.Text

            End If

        End Sub
        Private Sub LoadClients()

            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim AvailableClients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim SelectedClients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim SelectedClientCodes As IEnumerable(Of String) = Nothing
            Dim VendorRepresentativeClients As Generic.List(Of AdvantageFramework.Database.Entities.VendorRepresentativeClient) = Nothing
            Dim ClientCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Clients = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList

                    If _VendorCode IsNot Nothing AndAlso _VendorRepCode IsNot Nothing Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                VendorRepresentativeClients = AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepAndVendorCode(DataContext, _VendorRepCode, _VendorCode).ToList

                                SelectedClients = Clients.Where(Function(Client) VendorRepresentativeClients.Where(Function(VendorRepClient) VendorRepClient.ClientCode = Client.Code).Any = True).ToList

                            Catch ex As Exception
                                VendorRepresentativeClients = Nothing
                            End Try

                        End Using

                    Else

                        SelectedClients = _SelectedClients

                    End If

                    AvailableClients = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext).ToList.Where(Function(Client) SelectedClients.Where(Function(SelectedClient) SelectedClient.Code = Client.Code).Any = False).ToList

                    DataGridViewLeftSection_AvailableClients.DataSource = AvailableClients
                    DataGridViewLeftSection_AvailableClients.CurrentView.BestFitColumns()
                    DataGridViewLeftSection_AvailableClients.CurrentView.ViewCaption = DataGridViewLeftSection_AvailableClients.CurrentView.RowCount & " Available Client(s)"

                    DataGridViewRightSection_SelectedClients.DataSource = SelectedClients
                    DataGridViewRightSection_SelectedClients.CurrentView.BestFitColumns()
                    DataGridViewRightSection_SelectedClients.CurrentView.ViewCaption = DataGridViewRightSection_SelectedClients.CurrentView.RowCount & " Selected Client(s)"

                End Using

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddClient.Enabled = DataGridViewLeftSection_AvailableClients.HasASelectedRow
            ButtonRightSection_RemoveClient.Enabled = DataGridViewRightSection_SelectedClients.HasASelectedRow

        End Sub
        Private Sub LoadDropDownDataSources()

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxSetup_Vendor.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext), _Session.AccessibleOfficeCodes, _Session.HasLimitedOfficeCodes)
                SearchableComboBoxSetup_ContactType.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).OrderBy(Function(Entity) Entity.Description)

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, _VendorCode)

            End Using

            If _LockVendorSelection AndAlso Vendor IsNot Nothing Then

                SearchableComboBoxSetup_Vendor.SelectedValue = _VendorCode

                If SearchableComboBoxSetup_Vendor.SelectedValue Is Nothing Then

                    SearchableComboBoxSetup_Vendor.AddComboItemToExistingDataSource(Vendor.Name, Vendor.Code, True)
                    SearchableComboBoxSetup_Vendor.SelectedValue = _VendorCode
                    SearchableComboBoxSetup_Vendor.ReadOnly = True

                End If

            End If

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal VendorCode As String, ByVal VendorRepCode As String, LockVendorSelection As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

            _VendorRepCode = VendorRepCode
            _VendorCode = VendorCode
            _LockVendorSelection = LockVendorSelection

            LoadDropDownDataSources()

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" AndAlso _VendorRepCode <> "" Then

                    SearchableComboBoxSetup_Vendor.Enabled = False
                    TextBoxSetup_Code.Enabled = False

                    VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, _VendorRepCode, _VendorCode)

                    If VendorRepresentative IsNot Nothing Then

                        SearchableComboBoxSetup_Vendor.SelectedValue = VendorRepresentative.VendorCode
                        TextBoxSetup_Code.Text = VendorRepresentative.Code
                        CheckBoxSetup_Inactive.Checked = CBool(VendorRepresentative.IsInactive.GetValueOrDefault(0))
                        TextBoxSetup_FirmName.Text = VendorRepresentative.FirmName
                        'TextBoxSetup_Label.Text = VendorRepresentative.Label
                        SearchableComboBoxSetup_ContactType.SelectedValue = VendorRepresentative.ContactTypeID
                        TextBoxSetup_FirstName.Text = VendorRepresentative.FirstName
                        TextBoxSetup_MiddleInitial.Text = VendorRepresentative.MiddleInitial
                        TextBoxSetup_LastName.Text = VendorRepresentative.LastName

                        AddressControlSetup_Address.Address = VendorRepresentative.Address1
                        AddressControlSetup_Address.Address2 = VendorRepresentative.Address2
                        AddressControlSetup_Address.City = VendorRepresentative.City
                        AddressControlSetup_Address.State = VendorRepresentative.State
                        AddressControlSetup_Address.Zip = VendorRepresentative.Zip
                        AddressControlSetup_Address.County = VendorRepresentative.County
                        AddressControlSetup_Address.Country = VendorRepresentative.Country

                        TextBoxSetup_Cell.Text = VendorRepresentative.CellPhone
                        TextBoxSetup_Phone.Text = VendorRepresentative.Telephone
                        TextBoxSetup_PhoneExt.Text = VendorRepresentative.TelephoneExtension
                        TextBoxSetup_Fax.Text = VendorRepresentative.Fax
                        TextBoxSetup_FaxExt.Text = VendorRepresentative.FaxExtension
                        TextBoxSetup_Email.Text = VendorRepresentative.EmailAddress

                    Else

                        Loaded = False

                    End If

                ElseIf _VendorCode <> "" AndAlso _VendorRepCode = Nothing Then

                    SearchableComboBoxSetup_Vendor.SelectedValue = _VendorCode
                    TextBoxSetup_Code.Enabled = True
                    TextBoxSetup_Code.ReadOnly = False
                    _SelectedClients = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                Else

                    SearchableComboBoxSetup_Vendor.Enabled = True
                    TextBoxSetup_Code.Enabled = True
                    TextBoxSetup_Code.ReadOnly = False
                    _SelectedClients = New Generic.List(Of AdvantageFramework.Database.Entities.Client)

                End If

            End Using

            LoadClients()

            EnableOrDisableActions()

            DataGridViewLeftSection_AvailableClients.CurrentView.AFActiveFilterString = "[IsInactive] = False"
            DataGridViewRightSection_SelectedClients.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean, ByVal DataContext As AdvantageFramework.Database.DataContext) As AdvantageFramework.Database.Entities.VendorRepresentative

            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing

            Try

                If IsNew Then

                    VendorRepresentative = New AdvantageFramework.Database.Entities.VendorRepresentative

                    LoadVendorRepresentativeEntity(VendorRepresentative)

                Else

                    VendorRepresentative = AdvantageFramework.Database.Procedures.VendorRepresentative.LoadByCodeAndVendorCode(DataContext, _VendorRepCode, _VendorCode)

                    If VendorRepresentative IsNot Nothing Then

                        LoadVendorRepresentativeEntity(VendorRepresentative)

                    End If

                End If

            Catch ex As Exception
                VendorRepresentative = Nothing
            End Try

            FillObject = VendorRepresentative

        End Function
        Public Sub Save()

            'objects
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentative = Me.FillObject(False, DataContext)

                        If VendorRepresentative IsNot Nothing Then

                            VendorRepresentative.DbContext = DbContext

                            If AdvantageFramework.Database.Procedures.VendorRepresentative.Update(DataContext, VendorRepresentative) = True Then



                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Delete()

            'objects
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    VendorRepresentative = Me.FillObject(False, DataContext)

                    If VendorRepresentative IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.VendorRepresentative.Delete(DataContext, VendorRepresentative)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The vendor rep is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Insert(ByRef VendorCode As String, ByRef VendorRepresentativeCode As String)

            'objects
            Dim VendorRepresentative As AdvantageFramework.Database.Entities.VendorRepresentative = Nothing
            Dim VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorRepresentative = Me.FillObject(True, DataContext)

                        If VendorRepresentative IsNot Nothing Then

                            VendorRepresentative.DbContext = DbContext
                            VendorRepresentative.DataContext = DataContext

                            If AdvantageFramework.Database.Procedures.VendorRepresentative.Insert(DataContext, VendorRepresentative) Then

                                For Each Client In Me.SelectedClients

                                    VendorRepresentativeClient = New AdvantageFramework.Database.Entities.VendorRepresentativeClient

                                    VendorRepresentativeClient.DataContext = DataContext
                                    VendorRepresentativeClient.ClientCode = Client.Code
                                    VendorRepresentativeClient.VendorCode = VendorRepresentative.VendorCode
                                    VendorRepresentativeClient.VendorRepCode = VendorRepresentative.Code

                                    AdvantageFramework.Database.Procedures.VendorRepresentativeClient.Insert(DataContext, VendorRepresentativeClient)

                                Next

                                VendorCode = VendorRepresentative.VendorCode
                                VendorRepresentativeCode = VendorRepresentative.Code

                            End If

                        End If

                    End Using

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub ClearControl()

            SearchableComboBoxSetup_Vendor.SelectedValue = Nothing
            TextBoxSetup_Code.Text = ""
            CheckBoxSetup_Inactive.Checked = False
            TextBoxSetup_FirmName.Text = ""
            'TextBoxSetup_Label.Text = ""
            SearchableComboBoxSetup_ContactType.SelectedValue = Nothing
            TextBoxSetup_FirstName.Text = ""
            TextBoxSetup_MiddleInitial.Text = ""
            TextBoxSetup_LastName.Text = ""

            AddressControlSetup_Address.Address = ""
            AddressControlSetup_Address.Address2 = ""
            AddressControlSetup_Address.City = ""
            AddressControlSetup_Address.State = ""
            AddressControlSetup_Address.Zip = ""
            AddressControlSetup_Address.County = ""
            AddressControlSetup_Address.Country = ""

            TextBoxSetup_Cell.Text = ""
            TextBoxSetup_Phone.Text = ""
            TextBoxSetup_PhoneExt.Text = ""
            TextBoxSetup_Fax.Text = ""
            TextBoxSetup_FaxExt.Text = ""
            TextBoxSetup_Email.Text = ""

            DataGridViewLeftSection_AvailableClients.DataSource = Nothing
            DataGridViewRightSection_SelectedClients.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub VendorRepresentative_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemRefresh_Vendor.Image = AdvantageFramework.My.Resources.SmallVendorImage

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonItemRefresh_Vendor_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemRefresh_Vendor.Click

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, SearchableComboBoxSetup_Vendor.GetSelectedValue)

                If Vendor IsNot Nothing Then

                    AddressControlSetup_Address.Address = Vendor.StreetAddressLine1
                    AddressControlSetup_Address.Address2 = Vendor.StreetAddressLine2
                    AddressControlSetup_Address.City = Vendor.City
                    AddressControlSetup_Address.State = Vendor.State
                    AddressControlSetup_Address.Country = Vendor.Country
                    AddressControlSetup_Address.County = Vendor.County
                    AddressControlSetup_Address.Zip = Vendor.ZipCode

                End If

            End Using

        End Sub
        Private Sub ButtonRightSection_AddClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_AddClient.Click

            Dim SelectedClients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim ClientCodes As IEnumerable = Nothing
            Dim VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient = Nothing
            Dim Inserted As Boolean = True

            If DataGridViewLeftSection_AvailableClients.HasASelectedRow Then

                ClientCodes = DataGridViewLeftSection_AvailableClients.GetAllSelectedRowsBookmarkValues

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _VendorRepCode IsNot Nothing AndAlso _VendorCode IsNot Nothing Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            For Each ClientCode In ClientCodes.OfType(Of String)()

                                VendorRepresentativeClient = New AdvantageFramework.Database.Entities.VendorRepresentativeClient

                                VendorRepresentativeClient.DbContext = DbContext
                                VendorRepresentativeClient.DataContext = DataContext
                                VendorRepresentativeClient.ClientCode = ClientCode
                                VendorRepresentativeClient.VendorCode = _VendorCode
                                VendorRepresentativeClient.VendorRepCode = _VendorRepCode

                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.Insert(DataContext, VendorRepresentativeClient) = False Then

                                    Inserted = False

                                End If

                            Next

                        End Using

                    Else

                        For Each ClientCode In ClientCodes.OfType(Of String)()

                            Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, ClientCode)

                            If Client IsNot Nothing Then

                                _SelectedClients.Add(Client)

                            End If

                        Next

                    End If

                End Using

                If Inserted Then

                    LoadClients()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveClient_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonRightSection_RemoveClient.Click

            Dim VendorRepresentativeClient As AdvantageFramework.Database.Entities.VendorRepresentativeClient = Nothing
            Dim ClientCodes As IEnumerable = Nothing
            Dim ClientCode As String = Nothing
            Dim Deleted As Boolean = True

            If DataGridViewRightSection_SelectedClients.HasASelectedRow Then

                ClientCodes = DataGridViewRightSection_SelectedClients.GetAllSelectedRowsBookmarkValues

                If _VendorRepCode IsNot Nothing AndAlso _VendorCode IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        For Each ClientCode In ClientCodes.OfType(Of String)()

                            VendorRepresentativeClient = AdvantageFramework.Database.Procedures.VendorRepresentativeClient.LoadByVendorRepVendorAndClientCode(DataContext, _VendorRepCode, _VendorCode, ClientCode)

                            If VendorRepresentativeClient IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.VendorRepresentativeClient.Delete(DataContext, VendorRepresentativeClient) = False Then

                                    Deleted = False

                                End If

                            End If

                        Next

                    End Using

                Else

                    For Each ClientCode In ClientCodes.OfType(Of String)()

                        If _SelectedClients.Remove(_SelectedClients.Where(Function(Client) Client.Code = ClientCode).SingleOrDefault) = False Then

                            Deleted = False

                        End If

                    Next

                End If

                If Deleted Then

                    LoadClients()

                    EnableOrDisableActions()

                End If

            End If

        End Sub
        Private Sub DataGridViewLeftSection_AvailableClients_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_AvailableClients.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewRightSection_SelectedClients_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewRightSection_SelectedClients.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace
