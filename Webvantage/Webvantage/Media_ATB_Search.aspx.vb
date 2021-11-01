Public Class Media_ATB_Search
    Inherits Webvantage.BaseChildPage

#Region " Constants "


#End Region

#Region " Enum "


#End Region

#Region " Variables "

    Private _IsClearingFilter As Boolean = False

#End Region

#Region " Properties "

    Private Property IsClearingFilter As Boolean
        Get
            IsClearingFilter = _IsClearingFilter
        End Get
        Set(value As Boolean)
            _IsClearingFilter = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub ResetSearch()

        Me.IsClearingFilter = True

        TextBox_Client.Text = ""
        TextBox_Division.Text = ""
        TextBox_Product.Text = ""
        TextBox_Campaign.Text = ""
        TextBox_ATB.Text = ""
        TextBox_ATBDescription.Text = ""
        HiddenField_Campaign.Value = ""
        CheckBoxShowClosed.Checked = False

        SetPanelControls()

        RadGrid_ATBSearch.MasterTableView.CurrentPageIndex = 0
        RadGrid_ATBSearch.Rebind()

    End Sub
    Protected Sub SetPanelControls()

        Try

            HyperLink_Client.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=atbsearch&control=" & Me.TextBox_Client.ClientID & "&type=client&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
            HyperLink_Division.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=atbsearch&control=" & Me.TextBox_Division.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
            HyperLink_Product.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=atbsearch&type=product&control=" & Me.TextBox_Product.ClientID & "&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
            HyperLink_Campaign.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=atbsearch&type=campaign&control=" & Me.TextBox_Campaign.ClientID & "&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value);return false;")
            HyperLink_ATB.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=atbsearch&type=atb&control=" & Me.TextBox_ATB.ClientID & "&atbnumber=' + document.forms[0]." & Me.TextBox_ATB.ClientID & ".value + '&client=' + document.forms[0]." & Me.TextBox_Client.ClientID & ".value + '&division=' + document.forms[0]." & Me.TextBox_Division.ClientID & ".value + '&product=' + document.forms[0]." & Me.TextBox_Product.ClientID & ".value + '&campaign=' + document.forms[0]." & Me.HiddenField_Campaign.ClientID & ".value);return false;")

            TextBox_Client.Attributes.Add("onkeyup", "javascript:ClearInputs(['" & TextBox_Division.ClientID & "', '" & TextBox_Product.ClientID & "']);")
            TextBox_Division.Attributes.Add("onkeyup", "javascript:ClearInputs(['" & TextBox_Product.ClientID & "']);")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString)
        End Try

    End Sub
    Protected Function ValidateSearch() As Boolean

        'objects
        Dim IsValid As Boolean = True
        Dim MediaATB As AdvantageFramework.Database.Entities.MediaATB = Nothing
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If String.IsNullOrEmpty(TextBox_Client.Text) = False Then

                        If (From Entity In AdvantageFramework.Database.Procedures.Client.Load(DbContext)
                            Where Entity.Code = TextBox_Client.Text
                            Select Entity).Any = False Then

                            Me.ShowMessage("Invalid Client")
                            IsValid = False

                        ElseIf (From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                Where Entity.Code = TextBox_Client.Text
                                Select Entity).Any = False Then

                            Me.ShowMessage("Access to this client is denied.")
                            IsValid = False

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_Division.Text) = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByClientCode(DbContext, TextBox_Client.Text)
                                Where Entity.Code = TextBox_Division.Text
                                Select Entity).Any = False Then

                                Me.ShowMessage("Invalid Division")
                                IsValid = False

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                    Where Entity.ClientCode = TextBox_Client.Text AndAlso
                                          Entity.Code = TextBox_Division.Text
                                    Select Entity).Any = False Then

                                Me.ShowMessage("Access to this division is denied.")
                                IsValid = False

                            End If

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_Product.Text) = False Then

                            If (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByClientAndDivisionCode(DbContext, TextBox_Client.Text, TextBox_Division.Text)
                                Where Entity.Code = TextBox_Product.Text
                                Select Entity).Any = False Then

                                Me.ShowMessage("Invalid Product")
                                IsValid = False

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, False)
                                    Where Entity.ClientCode = TextBox_Client.Text AndAlso
                                          Entity.DivisionCode = TextBox_Division.Text AndAlso
                                          Entity.Code = TextBox_Product.Text
                                    Select Entity).Any = False Then

                                Me.ShowMessage("Access to this Product is denied.")
                                IsValid = False

                            End If

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_ATB.Text) = False Then

                            MediaATB = AdvantageFramework.Database.Procedures.MediaATB.LoadByATBNumber(DbContext, CInt(TextBox_ATB.Text))

                            If MediaATB Is Nothing Then

                                Me.ShowMessage("Invalid ATB")
                                IsValid = False

                            ElseIf (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, False)
                                    Where Entity.ClientCode = MediaATB.ClientCode AndAlso
                                          Entity.DivisionCode = MediaATB.DivisionCode AndAlso
                                          Entity.Code = MediaATB.ProductCode
                                    Select Entity).Any = False Then

                                Me.ShowMessage("Access to this ATB is denied.")
                                IsValid = False

                            End If

                        End If

                    End If

                    If IsValid Then

                        If String.IsNullOrEmpty(TextBox_Campaign.Text) = False Then

                            Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignID(DbContext, CInt(HiddenField_Campaign.Value))

                            If Campaign Is Nothing Then

                                Me.ShowMessage("Invalid Campaign")
                                IsValid = False

                            ElseIf String.IsNullOrEmpty(Campaign.ClientCode) = False AndAlso String.IsNullOrEmpty(Campaign.DivisionCode) = False AndAlso String.IsNullOrEmpty(Campaign.ProductCode) = False Then

                                If (From Entity In AdvantageFramework.Database.Procedures.Product.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode, False, False)
                                    Where Entity.ClientCode = Campaign.ClientCode AndAlso
                                          Entity.DivisionCode = Campaign.DivisionCode AndAlso
                                          Entity.Code = Campaign.ProductCode
                                    Select Entity).Any = False Then

                                    Me.ShowMessage("Access to this Campaign is denied.")
                                    IsValid = False

                                End If

                            ElseIf String.IsNullOrEmpty(Campaign.ClientCode) = False AndAlso String.IsNullOrEmpty(Campaign.DivisionCode) = False AndAlso String.IsNullOrEmpty(Campaign.ProductCode) = True Then

                                If (From Entity In AdvantageFramework.Database.Procedures.Division.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                    Where Entity.ClientCode = Campaign.ClientCode AndAlso
                                          Entity.Code = Campaign.DivisionCode
                                    Select Entity).Any = False Then

                                    Me.ShowMessage("Access to this Campaign is denied.")
                                    IsValid = False

                                End If

                            ElseIf String.IsNullOrEmpty(Campaign.ClientCode) = False AndAlso String.IsNullOrEmpty(Campaign.DivisionCode) = True AndAlso String.IsNullOrEmpty(Campaign.ProductCode) = True Then

                                If (From Entity In AdvantageFramework.Database.Procedures.Client.LoadByUserCode(DbContext, SecurityDbContext, _Session.UserCode)
                                    Where Entity.Code = Campaign.ClientCode
                                    Select Entity).Any = False Then

                                    Me.ShowMessage("Access to this Campaign is denied.")
                                    IsValid = False

                                End If

                            End If

                        End If

                    End If

                End Using

            End Using

        Catch ex As Exception
            IsValid = False
        Finally
            ValidateSearch = IsValid
        End Try

    End Function
    Private Sub CheckUserRights()

        'objects
        Dim CanView As Boolean = False
        Dim CanEdit As Boolean = False
        Dim CanInsert As Boolean = False

        Try

            CanView = Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
            CanEdit = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)
            CanInsert = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            If CanEdit = False AndAlso CanInsert = False Then

                RadToolBar_ATBSearch.FindItemByValue("New").Enabled = False

            ElseIf CanEdit = True AndAlso CanInsert = False Then

                RadToolBar_ATBSearch.FindItemByValue("New").Enabled = False

            ElseIf CanEdit = False AndAlso CanInsert = True Then


            End If

        Catch ex As Exception

        End Try

    End Sub

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ATBNumber As Integer = Nothing

        Me.PageTitle = "Find Authorization to Buy Digital Media Orders"

        SetPanelControls()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Media_AuthorizationToBuy)

            CheckUserRights()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGrid_ATBSearch_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGrid_ATBSearch.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing Then

            If e.Item.ItemIndex = -1 Then

                MiscFN.SavePageSize(Me.RadGrid_ATBSearch.ID, Me.RadGrid_ATBSearch.PageSize)

            End If

        End If

        Select Case e.CommandName

            Case "Detail"

                If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                    CurrentGridDataItem = RadGrid_ATBSearch.Items(e.Item.ItemIndex)

                End If

                Me.OpenWindow("", "Media_ATB.aspx?Mode=Open&ATBNbr=" & CurrentGridDataItem.GetDataKeyValue("ATBNumber"))

                Reload = False

        End Select

    End Sub
    Private Sub RadToolBar_MediaATB_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBar_ATBSearch.ButtonClick

        Select Case e.Item.Value

            Case "Search"

                If ValidateSearch() = True Then

                    RadGrid_ATBSearch.Rebind()

                End If

            Case "Clear"

                ResetSearch()

            Case "New"

                Me.OpenWindow("New Order", "Media_ATB_Add.aspx", 700, 350)

        End Select

    End Sub
    Private Sub RadGrid_ATBSearch_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGrid_ATBSearch.NeedDataSource

        'objects
        Dim MediaATBComplexList As Generic.List(Of AdvantageFramework.Database.Classes.MediaATBComplex) = Nothing
        Dim Campaign As AdvantageFramework.Database.Entities.Campaign = Nothing
        Dim ClientCode As String = Nothing
        Dim DivisionCode As String = Nothing
        Dim ProductCode As String = Nothing
        Dim CampaignCode As String = Nothing
        Dim CampaignID As Integer = 0
        Dim ATBNumber As Integer = Nothing
        Dim Description As String = Nothing

        ClientCode = TextBox_Client.Text.Trim()
        DivisionCode = TextBox_Division.Text.Trim()
        ProductCode = TextBox_Product.Text.Trim()

        If String.IsNullOrWhiteSpace(TextBox_Campaign.Text) = False Then

            Try

                CampaignCode = TextBox_Campaign.Text

            Catch ex As Exception
                CampaignCode = Nothing
            End Try

            If String.IsNullOrWhiteSpace(CampaignCode) = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Campaign = AdvantageFramework.Database.Procedures.Campaign.LoadByCampaignCode(DbContext, CampaignCode)

                    If Campaign IsNot Nothing Then

                        CampaignID = Campaign.ID

                    End If

                End Using

            End If

        End If

        If String.IsNullOrEmpty(TextBox_ATB.Text) = False Then

            Try

                ATBNumber = CInt(TextBox_ATB.Text.Trim())

            Catch ex As Exception
                ATBNumber = 0
            End Try

        End If

        Description = TextBox_ATBDescription.Text.Trim()

        If (String.IsNullOrWhiteSpace(ClientCode) AndAlso String.IsNullOrWhiteSpace(DivisionCode) AndAlso
            String.IsNullOrWhiteSpace(ProductCode) AndAlso String.IsNullOrWhiteSpace(Description) AndAlso
            ATBNumber <= 0 AndAlso CampaignID <= 0 AndAlso Me.Page.IsPostBack = False) OrElse Me.IsClearingFilter = True Then

            Me.IsClearingFilter = False
            MediaATBComplexList = New Generic.List(Of AdvantageFramework.Database.Classes.MediaATBComplex)

        Else

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaATBComplexList = AdvantageFramework.Database.Procedures.MediaATBComplex.Load(DbContext, _Session.UserCode, ATBNumber, Description, CampaignID, ClientCode, DivisionCode, ProductCode, CheckBoxShowClosed.Checked).ToList

            End Using

        End If

        RadGrid_ATBSearch.DataSource = MediaATBComplexList.OrderByDescending(Function(MediaATBCom) MediaATBCom.ATBNumber)
        RadGrid_ATBSearch.PageSize = MiscFN.LoadPageSize(Me.RadGrid_ATBSearch.ID)

        Try

            If MediaATBComplexList IsNot Nothing AndAlso MediaATBComplexList.Count = 1 Then

                Me.OpenWindow("", "Media_ATB.aspx?Mode=Open&ATBNbr=" & MediaATBComplexList.First.ATBNumber.ToString & "&RevNbr=" & MediaATBComplexList.First.RevisionNumber.ToString)

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGrid_ATBSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGrid_ATBSearch.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGrid_ATBSearch.ID, e.NewPageSize)

    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            If ValidateSearch() = True Then

                RadGrid_ATBSearch.Rebind()

            End If
        Catch ex As Exception

        End Try
    End Sub

#End Region

#End Region

End Class
