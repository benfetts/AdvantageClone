Public Class Maintenance_ClientContactManager
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

#End Region

#Region " Properties "



#End Region

#Region " Methods "


#Region "  Form Event Handlers "

    Private Sub Maintenance_ClientContactManager_Init(sender As Object, e As EventArgs) Handles Me.Init

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

        'RadGridContacts.Rebind()

    End Sub
    Private Sub Maintenance_ClientContactManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Client Contact Manager"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

        Else
            Dim eventArgument As String = IIf(Me.Request("__EVENTARGUMENT") = Nothing, String.Empty, Me.Request("__EVENTARGUMENT"))

            If (eventArgument = "Refresh") Then
                RadGridContacts.Rebind()
            End If

        End If

    End Sub
    Private Sub Maintenance_ClientContactManager_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        _DbContext.Database.Connection.Close()

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadToolbarClientContact_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarClientContact.ButtonClick

        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
        Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing

        Select Case e.Item.Value

            Case RadToolBarButtonAdd.Value

                Me.OpenWindow("Add Contact", "popContactsAdd.aspx?From=Maintenance_ClientContactManager&client=" & _ClientCode, 750, 950, False, True, "Refresh")

        End Select

    End Sub
    Private Sub RadGridContacts_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContacts.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim ClientContact As AdvantageFramework.Database.Entities.ClientContact = Nothing
        Dim DetailQueryString As AdvantageFramework.Web.QueryString = Nothing
        Dim Reload As Boolean = False

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridContacts.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Detail"

                Me.OpenWindow("Edit Contact", "popContactsAdd.aspx?From=Maintenance_ClientContactManager&ccid=" & CurrentGridDataItem.GetDataKeyValue("ContactID") & "&client=" & _ClientCode & "&code=" & CurrentGridDataItem.GetDataKeyValue("Code"), 750, 950, , True)

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Try

                        ClientContact = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(_DbContext, CurrentGridDataItem.GetDataKeyValue("ContactID"))

                    Catch ex As Exception
                        ClientContact = Nothing
                    End Try

                    If ClientContact IsNot Nothing Then

                        Reload = AdvantageFramework.Database.Procedures.ClientContact.Delete(_DbContext, ClientContact)

                    End If

                End If
            Case "Refresh"
                Reload = True
        End Select

        If Reload Then

            RadGridContacts.Rebind()

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
    Private Sub RadGridContacts_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridContacts.NeedDataSource

        'objects
        Dim ClientContacts As Generic.List(Of AdvantageFramework.Database.Entities.ClientContact) = Nothing
        Dim ClientContactDetailList As Integer() = Nothing
        Dim ClientContactIDs As Generic.List(Of Integer) = Nothing

        ClientContactIDs = New Generic.List(Of Integer)

        If String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) = False Then

            ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(_DbContext)
                                       Where Entity.DivisionCode = _DivisionCode AndAlso
                                             Entity.ProductCode = _ProductCode
                                       Select Entity.ContactID).ToArray)

            ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(_DbContext)
                                       Where Entity.DivisionCode = _DivisionCode AndAlso
                                             Entity.ProductCode Is Nothing
                                       Select Entity.ContactID).ToArray)

            ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(_DbContext, _ClientCode).Include("ClientContactDetail")
                                       Where Entity.ClientContactDetail.Count = 0
                                       Select Entity.ContactID).ToArray)

            ClientContactDetailList = ClientContactIDs.Distinct.ToArray

            ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(_DbContext, _ClientCode)
                              Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

        ElseIf String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) = False AndAlso String.IsNullOrEmpty(_ProductCode) Then

            ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContactDetail.Load(_DbContext)
                                       Where Entity.DivisionCode = _DivisionCode
                                       Select Entity.ContactID).ToArray)

            ClientContactIDs.AddRange((From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(_DbContext, _ClientCode).Include("ClientContactDetail")
                                       Where Entity.ClientContactDetail.Count = 0
                                       Select Entity.ContactID).ToArray)

            ClientContactDetailList = ClientContactIDs.Distinct.ToArray

            ClientContacts = (From Entity In AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(_DbContext, _ClientCode)
                              Where ClientContactDetailList.Contains(Entity.ContactID)).ToList

        ElseIf String.IsNullOrEmpty(_ClientCode) = False AndAlso String.IsNullOrEmpty(_DivisionCode) AndAlso String.IsNullOrEmpty(_ProductCode) Then

            ClientContacts = AdvantageFramework.Database.Procedures.ClientContact.LoadByClientCode(_DbContext, _ClientCode).ToList

        Else

            ClientContacts = New Generic.List(Of AdvantageFramework.Database.Entities.ClientContact)

        End If

        RadGridContacts.DataSource = (From Contact In ClientContacts
                                      Select New With {.ContactID = Contact.ContactID,
                                                       .Code = Contact.ContactCode,
                                                       .Name = Contact.ToString,
                                                       .Title = Contact.Title,
                                                       .Telephone = Contact.Telephone,
                                                       .CellPhone = Contact.CellPhone,
                                                       .Fax = Contact.Fax,
                                                       .EmailAddress = Contact.EmailAddress,
                                                       .IsInactive = CBool(Contact.IsInactive.GetValueOrDefault(0))}).ToList


    End Sub

#End Region

#End Region

End Class
