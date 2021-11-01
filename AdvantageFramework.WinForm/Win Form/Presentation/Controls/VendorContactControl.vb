Namespace WinForm.Presentation.Controls

    Public Class VendorContactControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _VendorContactCode As String = Nothing
        Private _VendorCode As String = Nothing
        Private _CanUserPrint As Boolean = False
        Private _CanUserUpdate As Boolean = False
        Private _CanUserAdd As Boolean = False

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

                        _CanUserPrint = AdvantageFramework.Security.CanUserPrintInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)
                        _CanUserUpdate = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)
                        _CanUserAdd = AdvantageFramework.Security.CanUserAddInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Accounting_VendorContact)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            AddressControlControl_Address.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.Address1)
                            AddressControlControl_Address.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.Address2)
                            AddressControlControl_Address.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.City)
                            AddressControlControl_Address.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.County)
                            AddressControlControl_Address.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.State)
                            AddressControlControl_Address.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.Zip)
                            AddressControlControl_Address.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.VendorContact.Properties.Country)
                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Code)
                            TextBoxControl_EmailAddress.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Email)
                            TextBoxControl_FirstName.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.FirstName)
                            TextBoxControl_LastName.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.LastName)
                            TextBoxControl_MiddleInitial.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.MiddleInitial)
                            TextBoxControl_Title.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Title)
                            TextBoxPhone_Cell.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Cell)
                            TextBoxPhone_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Fax)
                            TextBoxPhone_FaxExt.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.FaxExt)
                            TextBoxPhone_Voice.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.Phone)
                            TextBoxPhone_VoiceExt.SetPropertySettings(AdvantageFramework.Database.Entities.VendorContact.Properties.PhoneExt)

                            LoadDropDownDataSources()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadVendorContactEntity(ByVal VendorContact As AdvantageFramework.Database.Entities.VendorContact)

            If VendorContact IsNot Nothing Then

                VendorContact.VendorCode = SearchableComboBoxControl_Vendor.GetSelectedValue
                VendorContact.Code = TextBoxControl_Code.Text
                VendorContact.IsInactive = Convert.ToInt16(CheckBoxControl_Inactive.CheckValue)
                VendorContact.ContactTypeID = SearchableComboBoxControl_ContactType.GetSelectedValue
                VendorContact.Title = TextBoxControl_Title.Text
                VendorContact.FirstName = TextBoxControl_FirstName.Text
                VendorContact.MiddleInitial = TextBoxControl_MiddleInitial.Text
                VendorContact.LastName = TextBoxControl_LastName.Text
                VendorContact.Email = TextBoxControl_EmailAddress.Text

                VendorContact.Address1 = AddressControlControl_Address.Address
                VendorContact.Address2 = AddressControlControl_Address.Address2
                VendorContact.City = AddressControlControl_Address.City
                VendorContact.County = AddressControlControl_Address.County
                VendorContact.State = AddressControlControl_Address.State
                VendorContact.Zip = AddressControlControl_Address.Zip
                VendorContact.Country = AddressControlControl_Address.Country
                VendorContact.Phone = TextBoxPhone_Voice.Text
                VendorContact.PhoneExt = TextBoxPhone_VoiceExt.Text
                VendorContact.Fax = TextBoxPhone_Fax.Text
                VendorContact.FaxExt = TextBoxPhone_FaxExt.Text
                VendorContact.Cell = TextBoxPhone_Cell.Text

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxControl_Vendor.DataSource = AdvantageFramework.Database.Procedures.Vendor.LoadCore(AdvantageFramework.Database.Procedures.Vendor.LoadWithOfficeLimits(AdvantageFramework.Database.Procedures.Vendor.LoadAllActive(DbContext), _Session.AccessibleOfficeCodes, _Session.HasLimitedOfficeCodes))
                SearchableComboBoxControl_ContactType.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).OrderBy(Function(Entity) Entity.Description)

            End Using

        End Sub

#Region "  Public "

        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.VendorContact

            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            Try

                If IsNew Then

                    VendorContact = New AdvantageFramework.Database.Entities.VendorContact

                    LoadVendorContactEntity(VendorContact)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, _VendorCode, _VendorContactCode)

                        If VendorContact IsNot Nothing Then

                            LoadVendorContactEntity(VendorContact)

                        End If

                    End Using

                End If

            Catch ex As Exception
                VendorContact = Nothing
            End Try

            FillObject = VendorContact

        End Function
        Public Sub ClearControl()

            CheckBoxControl_Inactive.Checked = False
            SearchableComboBoxControl_Vendor.SelectedValue = Nothing
            SearchableComboBoxControl_ContactType.SelectedValue = Nothing
            TextBoxControl_Code.Text = Nothing
            TextBoxControl_Title.Text = Nothing
            TextBoxControl_FirstName.Text = Nothing
            TextBoxControl_MiddleInitial.Text = Nothing
            TextBoxControl_LastName.Text = Nothing
            TextBoxControl_EmailAddress.Text = Nothing

            AddressControlControl_Address.ClearControl()

            TextBoxPhone_Voice.Text = Nothing
            TextBoxPhone_VoiceExt.Text = Nothing
            TextBoxPhone_Fax.Text = Nothing
            TextBoxPhone_FaxExt.Text = Nothing
            TextBoxPhone_Cell.Text = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function LoadControl(ByVal VendorCode As String, ByVal VendorContactCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing

            _VendorCode = VendorCode
            _VendorContactCode = VendorContactCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _VendorCode <> "" AndAlso _VendorContactCode <> "" Then

                    VendorContact = AdvantageFramework.Database.Procedures.VendorContact.LoadByVendorAndVendorContactCode(DbContext, _VendorCode, _VendorContactCode)

                    If VendorContact IsNot Nothing Then

                        SearchableComboBoxControl_Vendor.Enabled = False
                        TextBoxControl_Code.Enabled = False
                        SearchableComboBoxControl_Vendor.SelectedValue = VendorContact.VendorCode

                        If VendorContact.ContactTypeID.HasValue Then

                            SearchableComboBoxControl_ContactType.SelectedValue = VendorContact.ContactTypeID

                        Else

                            SearchableComboBoxControl_ContactType.SelectedValue = Nothing

                        End If

                        TextBoxControl_Code.Text = VendorContact.Code
                        TextBoxControl_Title.Text = VendorContact.Title
                        CheckBoxControl_Inactive.CheckValue = VendorContact.IsInactive.GetValueOrDefault(0)

                        TextBoxControl_FirstName.Text = VendorContact.FirstName
                        TextBoxControl_MiddleInitial.Text = VendorContact.MiddleInitial
                        TextBoxControl_LastName.Text = VendorContact.LastName
                        TextBoxControl_EmailAddress.Text = VendorContact.Email

                        AddressControlControl_Address.Address = VendorContact.Address1
                        AddressControlControl_Address.Address2 = VendorContact.Address2
                        AddressControlControl_Address.City = VendorContact.City
                        AddressControlControl_Address.County = VendorContact.County
                        AddressControlControl_Address.State = VendorContact.State
                        AddressControlControl_Address.Zip = VendorContact.Zip
                        AddressControlControl_Address.Country = VendorContact.Country

                        TextBoxPhone_Voice.Text = VendorContact.Phone
                        TextBoxPhone_VoiceExt.Text = VendorContact.PhoneExt
                        TextBoxPhone_Fax.Text = VendorContact.Fax
                        TextBoxPhone_FaxExt.Text = VendorContact.FaxExt
                        TextBoxPhone_Cell.Text = VendorContact.Cell

                    Else

                        Loaded = False

                    End If

                ElseIf _VendorCode <> "" Then

                    SearchableComboBoxControl_Vendor.SelectedValue = _VendorCode
                    SearchableComboBoxControl_Vendor.Enabled = True
                    TextBoxControl_Code.Enabled = True

                Else

                    SearchableComboBoxControl_Vendor.Enabled = True
                    TextBoxControl_Code.Enabled = True

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub Save()

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContact = Me.FillObject(False)

                    If VendorContact IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.VendorContact.Update(DbContext, VendorContact) Then



                        End If

                    End If

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
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContact = Me.FillObject(False)

                    If VendorContact IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.VendorContact.Delete(DbContext, VendorContact)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "Vendor Contact is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Insert(ByRef VendorCode As String, ByRef VendorContactCode As String)

            'objects
            Dim VendorContact As AdvantageFramework.Database.Entities.VendorContact = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    VendorContact = Me.FillObject(True)

                    If VendorContact IsNot Nothing Then

                        VendorContact.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.VendorContact.Insert(DbContext, VendorContact) Then

                            VendorCode = VendorContact.VendorCode
                            VendorContactCode = VendorContact.Code

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub VendorContactControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemRefresh_Vendor.Image = AdvantageFramework.My.Resources.SmallVendorImage

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonItemRefresh_Vendor_Click(sender As Object, e As System.EventArgs) Handles ButtonItemRefresh_Vendor.Click

            Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing
            Dim VendorCode As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                VendorCode = SearchableComboBoxControl_Vendor.GetSelectedValue
                Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, VendorCode)

                If Vendor IsNot Nothing Then

                    AddressControlControl_Address.Address = Vendor.StreetAddressLine1
                    AddressControlControl_Address.Address2 = Vendor.StreetAddressLine2
                    AddressControlControl_Address.City = Vendor.City
                    AddressControlControl_Address.County = Vendor.County
                    AddressControlControl_Address.State = Vendor.State
                    AddressControlControl_Address.Zip = Vendor.ZipCode
                    AddressControlControl_Address.Country = Vendor.Country

                End If

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
