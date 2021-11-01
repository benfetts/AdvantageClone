Public Class Maintenance_CompanyProfile
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _Caller As String = ""
    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""
    Private _IsCRMUser As Boolean = False
    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing
    Private _CompanyProfileAffiliationList As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing
    Private _AffiliationList As Generic.List(Of AdvantageFramework.Database.Entities.Affiliation) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function FillObject() As AdvantageFramework.Database.Entities.CompanyProfile

        Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

        Try

            CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

            If CompanyProfile IsNot Nothing Then

                LoadEntity(CompanyProfile)

            Else

                CompanyProfile = New AdvantageFramework.Database.Entities.CompanyProfile

                LoadEntity(CompanyProfile)

            End If

        Catch ex As Exception
            CompanyProfile = Nothing
        End Try

        FillObject = CompanyProfile

    End Function
    Private Sub LoadEntity(ByVal CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile)

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
            CompanyProfile.TurnoverPercent = RadNumericTextBoxTurnoverPercent.Value

            If Not String.IsNullOrWhiteSpace(RadComboBoxType1.SelectedValue) Then

                CompanyProfile.ClientType1ID = CInt(RadComboBoxType1.SelectedValue)

            Else

                CompanyProfile.ClientType1ID = Nothing

            End If

            If Not String.IsNullOrWhiteSpace(RadComboBoxType2.SelectedValue) Then

                CompanyProfile.ClientType2ID = CInt(RadComboBoxType2.SelectedValue)

            Else

                CompanyProfile.ClientType2ID = Nothing

            End If

            If Not String.IsNullOrWhiteSpace(RadComboBoxType3.SelectedValue) Then

                CompanyProfile.ClientType3ID = CInt(RadComboBoxType3.SelectedValue)

            Else

                CompanyProfile.ClientType3ID = Nothing

            End If

            CompanyProfile.Notes = TextBoxNotes.Text
            CompanyProfile.CaseStudyDone = CheckBoxCaseStudy.Checked
            CompanyProfile.UseAsReference = CheckBoxReference.Checked

        End If

    End Sub
    Private Sub LoadCompanyProfileAffiliations()

        If IsNumeric(TextBoxCompanyProfileID.Text) = False Then

            _CompanyProfileAffiliationList = Session("CompanyProfile_RadGridCompanyProfileAffiliations")

        End If

        If _CompanyProfileAffiliationList Is Nothing Then

            _CompanyProfileAffiliationList = New Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation)

            If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                _CompanyProfileAffiliationList.Clear()

                If IsNumeric(TextBoxCompanyProfileID.Text) Then

                    _CompanyProfileAffiliationList.AddRange(AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByCompanyProfileID(_DbContext, TextBoxCompanyProfileID.Text).ToList)

                End If

            End If

        End If

        RadGridCompanyProfileAffiliations.DataSource = _CompanyProfileAffiliationList

        RadGridCompanyProfileAffiliations.MasterTableView.IsItemInserted = True

        RadGridCompanyProfileAffiliations.DataBind()

    End Sub
    Private Sub LoadCompanyProfileTab(ByVal Product As AdvantageFramework.Database.Entities.Product)

        Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
        Dim ClientType1 As AdvantageFramework.Database.Entities.ClientType1 = Nothing
        Dim ClientType2 As AdvantageFramework.Database.Entities.ClientType2 = Nothing
        Dim ClientType3 As AdvantageFramework.Database.Entities.ClientType3 = Nothing

        If Product IsNot Nothing Then

            CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

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

                RadNumericTextBoxTurnoverPercent.Value = CompanyProfile.TurnoverPercent

                If CompanyProfile.ClientType1ID IsNot Nothing Then

                    RadComboBoxType1.SelectedValue = CompanyProfile.ClientType1ID

                End If

                If String.IsNullOrWhiteSpace(RadComboBoxType1.SelectedValue) AndAlso CompanyProfile.ClientType1 IsNot Nothing Then

                    RadComboBoxType1.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(CompanyProfile.ClientType1.Description, CompanyProfile.ClientType1.ID))
                    RadComboBoxType1.SelectedValue = CompanyProfile.ClientType1ID

                End If

                If CompanyProfile.ClientType2ID IsNot Nothing Then

                    RadComboBoxType2.SelectedValue = CompanyProfile.ClientType2ID

                End If

                If String.IsNullOrWhiteSpace(RadComboBoxType2.SelectedValue) AndAlso CompanyProfile.ClientType2 IsNot Nothing Then

                    RadComboBoxType2.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(CompanyProfile.ClientType2.Description, CompanyProfile.ClientType2.ID))
                    RadComboBoxType2.SelectedValue = CompanyProfile.ClientType2ID

                End If

                If CompanyProfile.ClientType3ID IsNot Nothing Then

                    RadComboBoxType3.SelectedValue = CompanyProfile.ClientType3ID

                End If

                If String.IsNullOrWhiteSpace(RadComboBoxType3.SelectedValue) AndAlso CompanyProfile.ClientType3 IsNot Nothing Then

                    RadComboBoxType3.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(CompanyProfile.ClientType3.Description, CompanyProfile.ClientType3.ID))
                    RadComboBoxType3.SelectedValue = CompanyProfile.ClientType3ID

                End If

                TextBoxNotes.Text = CompanyProfile.Notes

                TextBoxCompanyProfileID.Text = CompanyProfile.ID

            End If

        End If

        LoadCompanyProfileAffiliations()

    End Sub
    Private Sub LoadControlSettings()

        RadNumericTextBoxRevenue.MaxLength = 15
        RadNumericTextBoxRevenue.MaxValue = 999999999999.99

        RadNumericTextBoxNumEmployees.MaxLength = 11
        RadNumericTextBoxNumEmployees.MaxValue = 99999999999

        AdvantageFramework.Web.Presentation.Controls.SetMaxLength(_DbContext, AdvantageFramework.Database.Entities.CompanyProfile.Properties.Notes, TextBoxNotes)

    End Sub
    Private Sub ResetDataSources()

        RadComboBoxIndustry.DataSource = AdvantageFramework.Database.Procedures.Industry.LoadAllActive(_DbContext).ToList
        RadComboBoxIndustry.DataValueField = "ID"
        RadComboBoxIndustry.DataTextField = "Description"
        RadComboBoxIndustry.DataBind()
        RadComboBoxIndustry.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxSpecialty.DataSource = AdvantageFramework.Database.Procedures.Specialty.LoadAllActive(_DbContext).ToList
        RadComboBoxSpecialty.DataValueField = "ID"
        RadComboBoxSpecialty.DataTextField = "Description"
        RadComboBoxSpecialty.DataBind()
        RadComboBoxSpecialty.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxRegion.DataSource = AdvantageFramework.Database.Procedures.PrintSpecRegion.LoadAllActive(_DbContext).ToList
        RadComboBoxRegion.DataValueField = "Code"
        RadComboBoxRegion.DataBind()
        RadComboBoxRegion.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxType1.DataSource = AdvantageFramework.Database.Procedures.ClientType1.LoadAllActive(_DbContext).ToList
        RadComboBoxType1.DataValueField = "ID"
        RadComboBoxType1.DataTextField = "Description"
        RadComboBoxType1.DataBind()
        RadComboBoxType1.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxType2.DataSource = AdvantageFramework.Database.Procedures.ClientType2.LoadAllActive(_DbContext).ToList
        RadComboBoxType2.DataValueField = "ID"
        RadComboBoxType2.DataTextField = "Description"
        RadComboBoxType2.DataBind()
        RadComboBoxType2.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

        RadComboBoxType3.DataSource = AdvantageFramework.Database.Procedures.ClientType3.LoadAllActive(_DbContext).ToList
        RadComboBoxType3.DataValueField = "ID"
        RadComboBoxType3.DataTextField = "Description"
        RadComboBoxType3.DataBind()
        RadComboBoxType3.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_CompanyProfile_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        _DbContext.Database.Connection.Open()

        If Request.QueryString("Caller") IsNot Nothing Then

            _Caller = Request.QueryString("Caller").ToString

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

    End Sub
    Private Sub Maintenance_CompanyProfile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim Product As AdvantageFramework.Database.Entities.Product = Nothing

        Me.PageTitle = "Company Profile"

        RadToolBarButtonSave.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadComboBoxIndustry.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadComboBoxSpecialty.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadComboBoxRegion.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadNumericTextBoxRevenue.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadNumericTextBoxNumEmployees.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CheckBoxCaseStudy.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        CheckBoxReference.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        TextBoxNotes.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
        RadGridCompanyProfileAffiliations.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

            LoadControlSettings()

            ResetDataSources()

            Try

                Product = AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionAndProductCode(_DbContext, _ClientCode, _DivisionCode, _ProductCode)

            Catch ex As Exception
                Product = Nothing
            End Try

            LoadCompanyProfileTab(Product)

        End If

    End Sub
    Private Sub Maintenance_CompanyProfile_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        _DbContext.Database.Connection.Close()

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarCompanyProfile_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCompanyProfile.ButtonClick

        Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
        Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonSave.Value

                CompanyProfile = FillObject()

                If CompanyProfile.IsEntityBeingAdded() Then

                    CompanyProfile.ClientCode = _ClientCode
                    CompanyProfile.DivisionCode = _DivisionCode
                    CompanyProfile.ProductCode = _ProductCode

                    CompanyProfile.CreatedByUserCode = _Session.UserCode
                    CompanyProfile.CreateDate = Now

                    If AdvantageFramework.Database.Procedures.CompanyProfile.Insert(_DbContext, CompanyProfile) Then

                        _CompanyProfileAffiliationList = Session("CompanyProfile_RadGridCompanyProfileAffiliations")

                        For Each Affiliation In _CompanyProfileAffiliationList

                            If Affiliation.IsEntityBeingAdded() Then

                                CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                                CompanyProfileAffiliation.DbContext = _DbContext
                                CompanyProfileAffiliation.CompanyProfileID = CompanyProfile.ID
                                CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                                AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(_DbContext, CompanyProfileAffiliation)

                            End If

                        Next

                    End If

                Else

                    CompanyProfile.ModifiedByUserCode = _Session.UserCode
                    CompanyProfile.ModifiedDate = Now

                    AdvantageFramework.Database.Procedures.CompanyProfile.Update(_DbContext, CompanyProfile)

                End If

                Me.CloseThisWindowAndRefreshCaller(_Caller & ".aspx", True, True)

            Case RadToolBarButtonCancel.Value

                Me.CloseThisWindow()

        End Select

    End Sub
    Private Sub RadGridCompanyProfileAffiliations_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridCompanyProfileAffiliations.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
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

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If _ProductCode = "" OrElse IsNumeric(TextBoxCompanyProfileID.Text) = False Then

                            _CompanyProfileAffiliationList = Session("CompanyProfile_RadGridCompanyProfileAffiliations")

                            If _CompanyProfileAffiliationList Is Nothing Then

                                _CompanyProfileAffiliationList = New Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation)

                            End If

                            If _CompanyProfileAffiliationList.Where(Function(Entity) Entity.AffiliationID = CompanyProfileAffiliation.AffiliationID).Any = True Then

                                Me.ShowMessage("Affiliation has already been added.  Please choose another.")

                            Else

                                ErrorMessage = CompanyProfileAffiliation.ValidateEntity(IsValid)

                                If IsValid Then

                                    _CompanyProfileAffiliationList.Add(CompanyProfileAffiliation)
                                    Session("CompanyProfile_RadGridCompanyProfileAffiliations") = _CompanyProfileAffiliationList

                                Else

                                    Me.ShowMessage(ErrorMessage)

                                End If

                            End If

                        Else

                            CompanyProfileAffiliation.DbContext = DbContext
                            CompanyProfileAffiliation.CompanyProfileID = TextBoxCompanyProfileID.Text

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

                    If IsNumeric(TextBoxCompanyProfileID.Text) = False Then

                        _CompanyProfileAffiliationList = Session("CompanyProfile_RadGridCompanyProfileAffiliations")

                        RadComboBox = CType(e.Item.FindControl("RadComboBoxAffiliation"), Telerik.Web.UI.RadComboBox)

                        Try

                            CompanyProfileAffiliation = (From Entity In _CompanyProfileAffiliationList
                                                         Where Entity.AffiliationID = RadComboBox.SelectedValue
                                                         Select Entity).Single

                        Catch ex As Exception
                            CompanyProfileAffiliation = Nothing
                        End Try

                        _CompanyProfileAffiliationList.Remove(CompanyProfileAffiliation)

                        Session("CompanyProfile_RadGridCompanyProfileAffiliations") = _CompanyProfileAffiliationList

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

        If _AffiliationList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _AffiliationList = AdvantageFramework.Database.Procedures.Affiliation.LoadAllActive(DbContext).ToList

            End Using

        End If

        Try

            RadComboBoxAffiliation = DirectCast(e.Item.FindControl("RadComboBoxAffiliation"), Telerik.Web.UI.RadComboBox)

            If RadComboBoxAffiliation Is Nothing Then

                RadComboBoxAffiliation = DirectCast(e.Item.FindControl("RadComboBoxAffiliationEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If RadComboBoxAffiliation IsNot Nothing Then

                RadComboBoxAffiliation.DataSource = (From Affiliation In _AffiliationList
                                                     Where Affiliation.IsInactive = False
                                                     Select Affiliation.ID,
                                                            [Description] = If(Affiliation.IsInactive = False, CStr(Affiliation.Description & " ").Trim, Affiliation.Description & "*")).ToList

                RadComboBoxAffiliation.DataBind()

                RadComboBoxAffiliation.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Affiliation In _AffiliationList
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

#End Region

#End Region

End Class