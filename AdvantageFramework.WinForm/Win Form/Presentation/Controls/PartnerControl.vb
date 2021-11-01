Namespace WinForm.Presentation.Controls

    Public Class PartnerControl

        Public Event SelectedProductChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event ProductOptionsChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _PartnerCode As String = Nothing

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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Code)
                            TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Name)
                            NumericInputForm_PercentPartner.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.PartnerPercent)

                            AddressControlLeftColumn_Address.SetCityPropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.City)
                            AddressControlLeftColumn_Address.SetCountryPropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.Country)
                            AddressControlLeftColumn_Address.SetCountyPropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.County)
                            AddressControlLeftColumn_Address.SetAddress2PropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.Address2)
                            AddressControlLeftColumn_Address.SetStatePropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.State)
                            AddressControlLeftColumn_Address.SetStreetPropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.Address1)
                            AddressControlLeftColumn_Address.SetZipPropertySettings(DbContext, AdvantageFramework.Database.Entities.Partner.Properties.Zip)

                            TextBoxContact_Email.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Email)
                            TextBoxContact_Phone.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Phone)
                            TextBoxContact_PhoneExt.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.PhoneExt)
                            TextBoxContact_Fax.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Fax)
                            TextBoxContact_FaxExt.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.FaxExt)
                            TextBoxComment_Comment.SetPropertySettings(AdvantageFramework.Database.Entities.Partner.Properties.Comments)

                            NumericInputForm_PercentPartner.Properties.Buttons.Clear()

                            LoadDropDownDataSources()

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Partner

            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing

            Try

                If IsNew Then

                    Partner = New AdvantageFramework.Database.Entities.Partner

                    LoadPartnerEntity(Partner)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Partner = AdvantageFramework.Database.Procedures.Partner.LoadByPartnerCode(DbContext, _PartnerCode)

                        If Partner IsNot Nothing Then

                            LoadPartnerEntity(Partner)

                        End If

                    End Using

                End If

            Catch ex As Exception
                Partner = Nothing
            End Try

            FillObject = Partner

        End Function
        Private Sub LoadPartnerEntity(ByVal Partner As AdvantageFramework.Database.Entities.Partner)

            Partner.Code = TextBoxForm_Code.Text
            Partner.Name = TextBoxForm_Name.Text
            Partner.PartnerPercent = Convert.ToDecimal(NumericInputForm_PercentPartner.Value)
            Partner.IsInactive = Convert.ToInt16(CheckBoxForm_Inactive.Checked)
            Partner.Address1 = AddressControlLeftColumn_Address.Address
            Partner.Address2 = AddressControlLeftColumn_Address.Address2
            Partner.City = AddressControlLeftColumn_Address.City
            Partner.State = AddressControlLeftColumn_Address.State
            Partner.Zip = AddressControlLeftColumn_Address.Zip
            Partner.Country = AddressControlLeftColumn_Address.Country
            Partner.County = AddressControlLeftColumn_Address.County
            Partner.Email = TextBoxContact_Email.Text
            Partner.Phone = TextBoxContact_Phone.Text
            Partner.PhoneExt = TextBoxContact_PhoneExt.Text
            Partner.Fax = TextBoxContact_Fax.Text
            Partner.FaxExt = TextBoxContact_FaxExt.Text
            Partner.MarketCode = SearchableComboBoxArea_Market.GetSelectedValue
            Partner.RegionCode = SearchableComboBoxArea_Region.GetSelectedValue
            Partner.Comments = TextBoxComment_Comment.Text

        End Sub
        Private Sub EnableOrDisableActions()


        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxArea_Market.DataSource = AdvantageFramework.Database.Procedures.Market.LoadAllActive(DbContext)
                SearchableComboBoxArea_Region.DataSource = AdvantageFramework.Database.Procedures.PrintSpecRegion.LoadAllActive(DbContext)

            End Using

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Partner = Me.FillObject(False)

                    If Partner IsNot Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.Partner.Update(DbContext, Partner)

                    End If

                End Using

            Catch ex As Exception
                Saved = False
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Partner = Me.FillObject(False)

                    If Partner IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.Partner.Delete(DbContext, Partner)

                        If Deleted = False Then

                            ErrorMessage = "The partner is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                Deleted = False
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef PartnerCode As String) As Boolean

            'objects
            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Partner = Me.FillObject(True)

                    If Partner IsNot Nothing Then

                        Partner.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.Partner.Insert(DbContext, Partner)

                        If Inserted Then

                            PartnerCode = Partner.Code

                        End If

                    End If

                End Using

            Catch ex As Exception
                Inserted = False
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function LoadControl(ByVal PartnerCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Partner As AdvantageFramework.Database.Entities.Partner = Nothing

            _PartnerCode = PartnerCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _PartnerCode <> "" Then

                    Partner = AdvantageFramework.Database.Procedures.Partner.LoadByPartnerCode(DbContext, _PartnerCode)

                    If Partner IsNot Nothing Then

                        TextBoxForm_Code.Enabled = False

                        TextBoxForm_Code.Text = Partner.Code
                        TextBoxForm_Name.Text = Partner.Name
                        NumericInputForm_PercentPartner.EditValue = Partner.PartnerPercent
                        CheckBoxForm_Inactive.Checked = Convert.ToBoolean(Partner.IsInactive)
                        AddressControlLeftColumn_Address.Address = Partner.Address1
                        AddressControlLeftColumn_Address.Address2 = Partner.Address2
                        AddressControlLeftColumn_Address.City = Partner.City
                        AddressControlLeftColumn_Address.State = Partner.State
                        AddressControlLeftColumn_Address.Zip = Partner.Zip
                        AddressControlLeftColumn_Address.Country = Partner.Country
                        AddressControlLeftColumn_Address.County = Partner.County
                        TextBoxContact_Email.Text = Partner.Email
                        TextBoxContact_Phone.Text = Partner.Phone
                        TextBoxContact_PhoneExt.Text = Partner.PhoneExt
                        TextBoxContact_Fax.Text = Partner.Fax
                        TextBoxContact_FaxExt.Text = Partner.FaxExt

                        If Partner.MarketCode IsNot Nothing Then
                            SearchableComboBoxArea_Market.SelectedValue = Partner.MarketCode
                        End If

                        If Partner.RegionCode IsNot Nothing Then
                            SearchableComboBoxArea_Region.SelectedValue = Partner.RegionCode
                        End If

                        TextBoxComment_Comment.Text = Partner.Comments

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxForm_Code.Enabled = True

                End If

            End Using

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            TextBoxForm_Code.Text = ""
            TextBoxForm_Name.Text = ""
            NumericInputForm_PercentPartner.EditValue = Nothing
            CheckBoxForm_Inactive.Checked = False
            AddressControlLeftColumn_Address.ClearControl()
            TextBoxContact_Email.Text = ""
            TextBoxContact_Phone.Text = ""
            TextBoxContact_PhoneExt.Text = ""
            TextBoxContact_Fax.Text = ""
            TextBoxContact_FaxExt.Text = ""
            SearchableComboBoxArea_Market.SelectedValue = Nothing
            SearchableComboBoxArea_Region.SelectedValue = Nothing
            TextBoxComment_Comment.Text = ""

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub SpellCheck()

            TextBoxComment_Comment.CheckSpelling()

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PartnerControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
