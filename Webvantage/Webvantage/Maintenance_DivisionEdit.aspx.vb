Public Class Maintenance_DivisionEdit
	Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

	Private _ClientCode As String = ""
	Private _DivisionCode As String = ""
	Private _IsCopy As Boolean = False
	Private _IsCRMUser As Boolean = False
	Private _SortNameMaxLength As Long = Nothing
    Private _DivisionSortKeyList As Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel) = Nothing
    Private _DivisionSortKeyEntityList As Generic.List(Of AdvantageFramework.Database.Entities.DivisionSortKey) = Nothing
    Private _FromMaintenance As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function GetUpdatedClient() As AdvantageFramework.Database.Entities.Client

		If RadComboBoxClient.SelectedValue <> "" Then

			Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				GetUpdatedClient = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RadComboBoxClient.SelectedValue)

			End Using

		Else

			GetUpdatedClient = Nothing

		End If

	End Function
	Private Sub LoadDivision()

		Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
		Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

		Try

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

				End Using

				If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

					TextBoxDivisionCode.Enabled = _IsCopy
					TextBoxDivisionCode.ReadOnly = Not _IsCopy
					RadComboBoxClient.Enabled = _IsCopy

					Division = AdvantageFramework.Database.Procedures.Division.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode)

					If Division IsNot Nothing Then

						UpdateAddressFields(Division)

						If _IsCopy = False Then

							TextBoxDivisionCode.Text = Division.Code
							CollapsablePanelProducts.Visible = True
							RadToolBarButtonUploadDocument.Visible = True
							RadToolBarButtonDocuments.Visible = True
							CollapsablePanelContacts.Visible = True

						Else

							CollapsablePanelProducts.Visible = False
							RadToolBarButtonUploadDocument.Visible = False
							RadToolBarButtonDocuments.Visible = False
							CollapsablePanelContacts.Visible = False

						End If

						RadComboBoxClient.SelectedValue = _ClientCode

						TextBoxDivisionName.Text = Division.Name

						CheckBoxIsNewBusiness.Checked = CBool(Division.Client.IsNewBusiness.GetValueOrDefault(0))

						LoadSortKeys()

						LoadGeneralTab(Division)

						LoadProductsTab()

						LoadContactsTab()

						If _IsCRMUser Then

							CheckBoxIsNewBusiness.Enabled = False

						End If

					End If

				ElseIf _ClientCode <> "" AndAlso _DivisionCode = "" Then

					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, _ClientCode)

					CheckBoxIsNewBusiness.Checked = CBool(Client.IsNewBusiness.GetValueOrDefault(0))

					UpdateAddressFields(Client, "BOTH")

					LoadSortKeys()

                    If Request.QueryString("Mode").ToString = "New" Then
                        RadComboBoxClient.Enabled = True
                    Else
                        RadComboBoxClient.Enabled = False
                    End If

                    TextBoxDivisionCode.Enabled = True
					TextBoxDivisionName.Enabled = True
					TextBoxDivisionCode.ReadOnly = False
					TextBoxDivisionName.ReadOnly = False
					CheckBoxIsInactive.Checked = False
					RadComboBoxClient.SelectedValue = _ClientCode
					CollapsablePanelProducts.Visible = False
					CollapsablePanelContacts.Visible = False
					RadToolBarButtonUploadDocument.Visible = False
					RadToolBarButtonDocuments.Visible = False

					If _IsCRMUser Then

						CheckBoxIsNewBusiness.Checked = True
						CheckBoxIsNewBusiness.Enabled = False

					End If

				Else

					LoadSortKeys()

					Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RadComboBoxClient.SelectedValue)

					CheckBoxIsNewBusiness.Checked = CBool(Client.IsNewBusiness.GetValueOrDefault(0))

					RadComboBoxClient.Enabled = True
					TextBoxDivisionCode.Enabled = True
					TextBoxDivisionName.Enabled = True
					TextBoxDivisionCode.ReadOnly = False
					TextBoxDivisionName.ReadOnly = False
					CollapsablePanelProducts.Visible = False
					CollapsablePanelContacts.Visible = False
					RadToolBarButtonUploadDocument.Visible = False
					RadToolBarButtonDocuments.Visible = False

					If _IsCRMUser Then

						CheckBoxIsNewBusiness.Checked = True
						CheckBoxIsNewBusiness.Enabled = False

					End If

				End If

			End Using

		Catch ex As Exception

			Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

		End Try

	End Sub
	Private Sub LoadGeneralTab(ByVal Division As AdvantageFramework.Database.Entities.Division)

		Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

		If Division IsNot Nothing Then

			Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				If Division.ClientCode IsNot Nothing Then

					Try

						RadComboBoxClient.SelectedValue = Division.ClientCode

					Catch ex As Exception
						RadComboBoxClient.SelectedValue = ""
					End Try

					If RadComboBoxClient.SelectedValue = "" Then

						Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Division.ClientCode)

						If Client IsNot Nothing Then

							RadComboBoxClient.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem(Client.ToString & "*", Client.Code))

							Try

								RadComboBoxClient.SelectedValue = Division.ClientCode

							Catch ex As Exception
								RadComboBoxClient.SelectedValue = ""
							End Try

						End If

					End If

				Else

					RadComboBoxClient.SelectedValue = ""

				End If

				If _IsCopy Then

					CheckBoxIsInactive.Checked = False

				Else

					CheckBoxIsInactive.Checked = Not Convert.ToBoolean(Division.IsActive.GetValueOrDefault(0))

				End If

				TextBoxAttentionLine.Text = Division.AttentionLine

			End Using

		End If

	End Sub
	Private Sub UpdateAddressFields(ByVal Division As AdvantageFramework.Database.Entities.Division)

		TextBoxBillingAddress1.Text = Division.BillingAddress
		TextBoxBillingAddress2.Text = Division.BillingAddress2
		TextBoxBillingCity.Text = Division.BillingCity
		TextBoxBillingCounty.Text = Division.BillingCounty
		TextBoxBillingState.Text = Division.BillingState
		TextBoxBillingZip.Text = Division.BillingZip
		TextBoxBillingCountry.Text = Division.BillingCountry

		TextBoxStatementAddress1.Text = Division.Address
		TextBoxStatementAddress2.Text = Division.Address2
		TextBoxStatementCity.Text = Division.City
		TextBoxStatementCounty.Text = Division.County
		TextBoxStatementState.Text = Division.State
		TextBoxStatementZip.Text = Division.Zip
		TextBoxStatementCountry.Text = Division.Country

	End Sub
	Private Sub UpdateAddressFields(ByVal Client As AdvantageFramework.Database.Entities.Client, ByVal AddressType As String)

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

	End Sub
	Private Sub LoadContactsTab()

		Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
		Dim ClientContactIDs As Generic.List(Of Integer) = Nothing
		Dim ClientContactDetailList As Integer() = Nothing

		Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

			If String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False Then

				ClientContactIDs = New Generic.List(Of Integer)

				ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(DbContext)
										   Where Entity.DivisionCode = _DivisionCode
										   Select Entity.ContactID).ToArray)

				ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode).Include("ClientContactDetail")
										   Where Entity.ClientContactDetail.Count = 0
										   Select Entity.ContactID).ToArray)

				ClientContactDetailList = ClientContactIDs.Distinct.ToArray

				ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(DbContext, _ClientCode)
								  Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

			End If

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

			RadGridContacts.DataBind()

		End Using

	End Sub
	Private Sub LoadControlSettings(ByVal DbContext As AdvantageFramework.Database.DbContext)

		TextBoxDivisionCode.CssClass = "RequiredInput"
		TextBoxDivisionName.CssClass = "RequiredInput"

		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Code, TextBoxDivisionCode)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Name, TextBoxDivisionName)

		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingAddress, TextBoxBillingAddress1)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingAddress2, TextBoxBillingAddress2)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCounty, TextBoxBillingCounty)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCity, TextBoxBillingCity)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingState, TextBoxBillingState)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingZip, TextBoxBillingZip)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.BillingCountry, TextBoxBillingCountry)

		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Address, TextBoxStatementAddress1)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Address2, TextBoxStatementAddress2)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.County, TextBoxStatementCounty)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.City, TextBoxStatementCity)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.State, TextBoxStatementState)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Zip, TextBoxStatementZip)
		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.Country, TextBoxStatementCountry)

		AdvantageFramework.Web.Presentation.Controls.SetMaxLength(DbContext, AdvantageFramework.Database.Entities.Division.Properties.AttentionLine, TextBoxAttentionLine)

	End Sub
	Private Sub LoadProductsTab()

		If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

			Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

					If CheckBoxProductShowInactive.Checked Then

						RadGridProducts.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, True)
													  Where Entity.ClientCode = _ClientCode AndAlso
															Entity.DivisionCode = _DivisionCode
													  Select Entity).ToList

					Else

						RadGridProducts.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, True)
													  Where Entity.ClientCode = _ClientCode AndAlso
															Entity.DivisionCode = _DivisionCode AndAlso
															Entity.IsActive = 1
													  Select Entity).ToList

					End If

					RadGridProducts.DataBind()

				End Using

			End Using

		End If

	End Sub
	Private Sub LoadSortKeys()

        If _IsCopy OrElse _DivisionCode = "" Then

            _DivisionSortKeyList = Session("DivisionEdit_RadGridSortKeys")

        End If
        If _DivisionSortKeyList Is Nothing Then

            _DivisionSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" Then

				_DivisionSortKeyList.Clear()

				Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _DivisionSortKeyEntityList = Nothing
                    _DivisionSortKeyEntityList = AdvantageFramework.Database.Procedures.DivisionSortKey.LoadByClientAndDivisionCode(DbContext, _ClientCode, _DivisionCode).ToList()

                    If _DivisionSortKeyEntityList IsNot Nothing Then

                        _DivisionSortKeyList = (From Entity In _DivisionSortKeyEntityList
                                                Select New AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel With {.ClientCode = Entity.ClientCode,
                                                                                                                                         .DivisionCode = Entity.DivisionCode,
                                                                                                                                         .SortKey = Entity.SortKey}).ToList()

                    End If

                End Using

			End If

		End If

        RadGridSortKeys.DataSource = _DivisionSortKeyList
        RadGridSortKeys.MasterTableView.IsItemInserted = True
        RadGridSortKeys.DataBind()

		If _IsCopy OrElse _DivisionCode = "" Then

			Session("DivisionEdit_RadGridSortKeys") = _DivisionSortKeyList

		End If

	End Sub
	Private Sub LoadDivisionEntity(ByVal Division As AdvantageFramework.Database.Entities.Division)

		Division.Code = TextBoxDivisionCode.Text
		Division.Name = TextBoxDivisionName.Text

		If RadComboBoxClient.SelectedValue <> "" Then

			Division.ClientCode = RadComboBoxClient.SelectedValue

		End If

		Division.IsActive = If(CheckBoxIsInactive.Checked, 0, 1)
		Division.AttentionLine = TextBoxAttentionLine.Text

		If Division.Name.Length > _SortNameMaxLength Then

			Division.SortName = Division.Name.Substring(0, _SortNameMaxLength)

		Else

			Division.SortName = Division.Name

		End If

		Division.BillingAddress = TextBoxBillingAddress1.Text
		Division.BillingAddress2 = TextBoxBillingAddress2.Text
		Division.BillingCounty = TextBoxBillingCounty.Text
		Division.BillingCity = TextBoxBillingCity.Text
		Division.BillingState = TextBoxBillingState.Text
		Division.BillingZip = TextBoxBillingZip.Text
		Division.BillingCountry = TextBoxBillingCountry.Text

		Division.Address = TextBoxStatementAddress1.Text
		Division.Address2 = TextBoxStatementAddress2.Text
		Division.County = TextBoxStatementCounty.Text
		Division.City = TextBoxStatementCity.Text
		Division.State = TextBoxStatementState.Text
		Division.Zip = TextBoxStatementZip.Text
		Division.Country = TextBoxStatementCountry.Text

	End Sub
	Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Division

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
	Private Function Insert() As Boolean

		Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
		Dim DivSortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing
		Dim ErrorMessage As String = Nothing
		Dim Inserted As Boolean = False

		Try

			Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				Division = Me.FillObject(True)

				If Division IsNot Nothing Then

					Division.DbContext = DbContext

					Inserted = AdvantageFramework.Database.Procedures.Division.Insert(DbContext, Division)

					If Inserted Then

						SaveSortKeys(DbContext, Division)

						_ClientCode = Division.ClientCode
						_DivisionCode = Division.Code

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
		Dim Division As AdvantageFramework.Database.Entities.Division = Nothing
		Dim ErrorMessage As String = ""
		Dim Saved As Boolean = False

		Try

			Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				Division = Me.FillObject(False)

				If Division IsNot Nothing Then

					Saved = AdvantageFramework.Database.Procedures.Division.Update(DbContext, Division)

					If Saved Then

						_ClientCode = Division.ClientCode
						_DivisionCode = Division.Code

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
	Private Sub SaveSortKeys(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal Division As AdvantageFramework.Database.Entities.Division)

		_DivisionSortKeyList = Session("DivisionEdit_RadGridSortKeys")

		If _DivisionSortKeyList IsNot Nothing Then

            Dim EntitySortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing

            For Each DivisionSortKey In _DivisionSortKeyList

                If _IsCopy Or _DivisionCode = "" Then

                    EntitySortKey = New AdvantageFramework.Database.Entities.DivisionSortKey

                    EntitySortKey.DbContext = DbContext
                    EntitySortKey.ClientCode = Division.ClientCode
                    EntitySortKey.DivisionCode = Division.Code

                    AdvantageFramework.Database.Procedures.DivisionSortKey.Insert(DbContext, EntitySortKey)

                    EntitySortKey = Nothing

                End If

            Next

		End If

	End Sub
	Private Sub Upload()

		Session("DocCaption") = ""

		Me.OpenWindow("Upload a new document", "Documents_Upload.aspx?caller=" & Me.PageFilename & "&Level=DI&FK=" & _ClientCode & "," & _DivisionCode, 500, 550)

	End Sub
	Private Sub ViewDocs()

		'Dim URL As String

		'URL = "Documents_List2.aspx?doclvl=" & AdvantageFramework.Database.Entities.DocumentLevel.Division & "&cl_code=" & _ClientCode & "&div_code=" & _DivisionCode & "&division_desc=" & Me.TextBoxDivisionCode.Text & "-" & Me.TextBoxDivisionName.Text

		'Me.OpenWindow("View Documents", URL)

		Dim qs As New AdvantageFramework.Web.QueryString()
        With qs

            .Page = "Documents_List2.aspx"
            .DocumentLevel = AdvantageFramework.Database.Entities.DocumentLevel.Division
            .ClientCode = Me._ClientCode
            .DivisionCode = Me._DivisionCode
            .Add("division_desc", Me.TextBoxDivisionCode.Text & "-" & Me.TextBoxDivisionName.Text)

        End With

        Me.OpenWindow(qs, "Document List")

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_DivisionEdit_Init(sender As Object, e As EventArgs) Handles Me.Init

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_Division, False))
        RadToolBarButtonUploadDocument.Enabled = HasAccessToDocuments
        RadToolBarButtonDocuments.Enabled = HasAccessToDocuments

        RadToolBarButtonNew.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadToolBarButtonSave.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        CollapsablePanelAddresses.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelHeader.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CollapsablePanelOptions.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            CollapsablePanelContacts.Enabled = AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode)

        End Using

        CollapsablePanelProducts.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

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

        If Request.QueryString("Mode") IsNot Nothing Then

            If Request.QueryString("Mode").ToString = "Add" Then

                _DivisionCode = ""

            ElseIf Request.QueryString("Mode").ToString = "Copy" Then

                _IsCopy = True

            End If

        End If

    End Sub
    Private Sub Maintenance_DivisionEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Division"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadControlSettings(DbContext)

                Try

                    _SortNameMaxLength = AdvantageFramework.BaseClasses.Entity.LoadPropertyMaxLength(AdvantageFramework.BaseClasses.Entity.LoadProperty(AdvantageFramework.Database.Entities.Division.Properties.SortName))

                Catch ex As Exception
                    _SortNameMaxLength = Nothing
                End Try

            End Using

            Try

                LoadDivision()

            Catch ex As Exception
                _DivisionCode = Nothing
            End Try

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ButtonAddContact_Click(sender As Object, e As EventArgs) Handles ButtonAddContact.Click

        Try

            Me.OpenWindow("Add Contact", "popContactsAdd.aspx?From=DivisionEdit&client=" & _ClientCode, 750, 950, False, True)

        Catch ex As Exception

        End Try

    End Sub
    Private Sub ButtonAddProduct_Click(sender As Object, e As EventArgs) Handles ButtonAddProduct.Click

        Try

            If _FromMaintenance Then

                Me.OpenWindow("Add Product", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, 750, 950, False, True)

            Else

                Me.OpenWindow("Add Product", "Maintenance_ProductEdit.aspx?Mode=Add&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, 750, 950, False, True)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridSortKeys_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridSortKeys.ItemCommand

        'objects
        Dim DivisionSortKey As AdvantageFramework.Database.Entities.DivisionSortKey = Nothing
        Dim MyDivisionSortKey As AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Reload As Boolean = True
        Dim ErrorMessage As String = Nothing
        Dim TextBox As System.Web.UI.WebControls.TextBox = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridSortKeys.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveNewRow"

                DivisionSortKey = New AdvantageFramework.Database.Entities.DivisionSortKey

                DivisionSortKey.ClientCode = _ClientCode
                DivisionSortKey.DivisionCode = _DivisionCode
                DivisionSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                MyDivisionSortKey = New AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel

                MyDivisionSortKey.ClientCode = _ClientCode
                MyDivisionSortKey.DivisionCode = _DivisionCode
                MyDivisionSortKey.SortKey = CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text.Trim

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If _IsCopy OrElse _DivisionCode = "" Then

                        _DivisionSortKeyList = Session("DivisionEdit_RadGridSortKeys")

                        If _DivisionSortKeyList Is Nothing Then

                            _DivisionSortKeyList = New Generic.List(Of AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel)

                        End If

                        ErrorMessage = DivisionSortKey.ValidateEntity(IsValid)

                        If IsValid Then

                            _DivisionSortKeyList.Add(MyDivisionSortKey)
                            Session("DivisionEdit_RadGridSortKeys") = _DivisionSortKeyList

                        Else

                            Me.ShowMessage(ErrorMessage)

                        End If

                    Else

                        DivisionSortKey.DbContext = DbContext

                        Reload = AdvantageFramework.Database.Procedures.DivisionSortKey.Insert(DbContext, DivisionSortKey)

                    End If

                End Using

            Case "CancelAddRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxSortKeyEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    If _IsCopy OrElse _DivisionCode = "" Then

                        _DivisionSortKeyList = Session("DivisionEdit_RadGridSortKeys")

                        TextBox = CType(e.Item.FindControl("TextBoxSortKey"), TextBox)

                        If _DivisionSortKeyList IsNot Nothing Then

                            Dim dsk As AdvantageFramework.ViewModels.Maintenance.General.DivisionSortViewModel = Nothing
                            Try

                                dsk = (From Entity In _DivisionSortKeyList
                                       Where Entity.SortKey = TextBox.Text
                                       Select Entity).SingleOrDefault()

                            Catch ex As Exception
                                DivisionSortKey = Nothing
                            End Try

                            _DivisionSortKeyList.Remove(dsk)

                        End If

                        Session("DivisionEdit_RadGridSortKeys") = _DivisionSortKeyList

                    Else

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DivisionSortKey = AdvantageFramework.Database.Procedures.DivisionSortKey.LoadByClientAndDivisionCodeAndSortKey(DbContext, _ClientCode, _DivisionCode, CurrentGridDataItem.GetDataKeyValue("SortKey"))

                            If DivisionSortKey IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.DivisionSortKey.Delete(DbContext, DivisionSortKey)

                            End If

                        End Using

                    End If

                End If

        End Select

        If Reload Then

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
    Private Sub RadToolbarDivision_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarDivision.ButtonClick

        Select Case e.Item.Value

            Case "Save"

                If _IsCopy OrElse _DivisionCode = "" Then

                    If Insert() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Edit Division", "Maintenance_DivisionEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, , , True)

                        Else

                            Me.OpenWindow("Edit Division", "Maintenance_DivisionEdit.aspx?ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, , , True)

                        End If

                    End If

                Else

                    If Save() Then

                        If _FromMaintenance Then

                            Me.OpenWindow("Edit Division", "Maintenance_DivisionEdit.aspx?From=Maintenance&ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, , , True)

                        Else

                            Me.OpenWindow("Edit Division", "Maintenance_DivisionEdit.aspx?ClientCode=" & _ClientCode & "&DivisionCode=" & _DivisionCode, , , True)

                        End If

                    End If

                End If

            Case "Refresh"

                LoadDivision()

            Case "New"

                If _FromMaintenance Then

                    Me.OpenWindow("New Division", "Maintenance_DivisionEdit.aspx?From=Maintenance&Mode=New&ClientCode=" & _ClientCode & "&DivisionCode=", , , True)

                Else

                    Me.OpenWindow("New Division", "Maintenance_DivisionEdit.aspx?Mode=New&ClientCode=" & _ClientCode & "&DivisionCode=", , , True)

                End If

            Case "Upload"

                Upload()

            Case "ViewDocs"

                ViewDocs()

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

                Me.OpenWindow("Edit Contact", "popContactsAdd.aspx?From=DivisionEdit&ccid=" & CurrentGridDataItem.GetDataKeyValue("ContactID") & "&client=" & _ClientCode & "&code=" & CurrentGridDataItem.GetDataKeyValue("Code"), 750, 950, , True)

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            ClientContactDetail = (From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.LoadByContactID(DbContext, CurrentGridDataItem.GetDataKeyValue("ContactID"))
                                                   Where Entity.DivisionCode = _DivisionCode AndAlso
                                                         Entity.ProductCode Is Nothing).Single

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
    Private Sub RadGridProducts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProducts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing
        Dim DetailQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridProducts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                If _FromMaintenance Then

                    Me.OpenWindow("Product Detail", "Maintenance_ProductEdit.aspx?From=Maintenance&Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                Else

                    Me.OpenWindow("Product Detail", "Maintenance_ProductEdit.aspx?Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("ClientCode") & "&DivisionCode=" & CurrentGridDataItem.GetDataKeyValue("DivisionCode") & "&ProductCode=" & CurrentGridDataItem.GetDataKeyValue("Code"))

                End If

                Reload = False

			Case "DeleteRow"

				If CurrentGridDataItem IsNot Nothing Then

					Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

						Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(DbContext, CurrentGridDataItem.GetDataKeyValue("ClientCode"), CurrentGridDataItem.GetDataKeyValue("DivisionCode"), CurrentGridDataItem.GetDataKeyValue("Code"))

						If Product IsNot Nothing Then

							AdvantageFramework.Database.Procedures.Product.Delete(DbContext, Product)

						End If

					End Using

				End If

		End Select

		If Reload Then

			LoadProductsTab()

		End If

	End Sub
	Private Sub RadGridProducts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProducts.ItemDataBound

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
	Private Sub LinkButtonBilling_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonBilling_Client.Click

		Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

		Client = GetUpdatedClient()

		UpdateAddressFields(Client, "BILLING")

	End Sub
	Private Sub LinkButtonStatement_Client_Click(sender As Object, e As EventArgs) Handles LinkButtonStatement_Client.Click

		Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

		Client = GetUpdatedClient()

		UpdateAddressFields(Client, "STATEMENT")

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
	Protected Sub RadComboBoxClient_SelectedIndexChanged(sender As Object, e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs)

		Dim Client As AdvantageFramework.Database.Entities.Client = Nothing

		If RadComboBoxClient.SelectedValue <> "" Then

			Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

				CheckBoxIsNewBusiness.Checked = CBool(AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RadComboBoxClient.SelectedValue).IsNewBusiness.GetValueOrDefault(0))

			End Using

		End If

	End Sub
	Private Sub CheckBoxContactsShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxContactsShowInactive.CheckedChanged

		LoadContactsTab()

	End Sub
	Private Sub CheckBoxProductShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxProductShowInactive.CheckedChanged

		LoadProductsTab()

	End Sub

#End Region

#End Region

End Class
