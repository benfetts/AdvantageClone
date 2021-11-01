Public Class Maintenance_Client
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _IsCRMUser As Boolean = False
    Private _CRMAddEditViewNewBusinessClientsOnly As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadClients()

        _IsCRMUser = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser)

        If _IsCRMUser Then

            _CRMAddEditViewNewBusinessClientsOnly = AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly)

        End If

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If CheckBoxShowInactive.Checked Then

                    If _CRMAddEditViewNewBusinessClientsOnly Then

                        RadGridClients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, _Session)
                                                     Where Client.IsNewBusiness = 1
                                                     Select Client.Code,
                                                            Client.Name,
                                                            Client.IsNewBusiness,
                                                            Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                      .Client = Client.Code & " - " & Client.Name,
                                                                                                                      .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                      .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList

                    Else

                        RadGridClients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadWithOfficeLimits(DbContext, _Session)
                                                     Select Client.Code,
                                                            Client.Name,
                                                            Client.IsNewBusiness,
                                                            Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                      .Client = Client.Code & " - " & Client.Name,
                                                                                                                      .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                      .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList

                    End If

                Else

                    If _CRMAddEditViewNewBusinessClientsOnly Then

                        RadGridClients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                                     Where Client.IsNewBusiness = 1
                                                     Select Client.Code,
                                                            Client.Name,
                                                            Client.IsNewBusiness,
                                                            Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                      .Client = Client.Code & " - " & Client.Name,
                                                                                                                      .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                      .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList

                    Else

                        RadGridClients.DataSource = (From Client In AdvantageFramework.Database.Procedures.Client.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                                     Select Client.Code,
                                                            Client.Name,
                                                            Client.IsNewBusiness,
                                                            Client.IsActive).ToList.Select(Function(Client) New With {.Code = Client.Code,
                                                                                                                      .Client = Client.Code & " - " & Client.Name,
                                                                                                                      .IsNewBusiness = CBool(Client.IsNewBusiness.GetValueOrDefault(0)),
                                                                                                                      .IsInactive = Not CBool(Client.IsActive.GetValueOrDefault(0))}).ToList

                    End If

                End If

                RadGridClients.DataBind()

            End Using

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_Client_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing

        Me.PageTitle = "Client Maintenance"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            LoadClients()

            RadToolBarButtonAdd.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)
            ImageButtonExport.Enabled = Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

            Try

                GridColumn = RadGridClients.Columns.FindByUniqueName("GridTemplateColumnDelete")

            Catch ex As Exception
                GridColumn = Nothing
            End Try

            If GridColumn IsNot Nothing Then

                GridColumn.Visible = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

            End If

            Try

                GridColumn = RadGridClients.Columns.FindByUniqueName("GridTemplateColumnCopy")

            Catch ex As Exception
                GridColumn = Nothing
            End Try

            If GridColumn IsNot Nothing Then

                GridColumn.Visible = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

            End If

        Else
            Select Case Me.EventArgument
                Case "refresh"
                    LoadClients()
            End Select
        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridClients AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridClients.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                Response.Redirect([String].Format("Maintenance_ClientEdit.aspx?ClientCode={0}", 1, GridDataItem.GetDataKeyValue("Code")))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        LoadClients()

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Clients As IQueryable(Of AdvantageFramework.Database.Entities.Client) = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Client")
        DataTable.Columns.Add("Is New Business")
        DataTable.Columns.Add("Is Inactive")

        RadGridClients.AllowPaging = False

        LoadClients()

        For Each GridDataItem In RadGridClients.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Client

            If GridDataItem.DataItem.IsNewBusiness Then

                NewDataRow(1) = "YES"

            Else

                NewDataRow(1) = "NO"

            End If

            If GridDataItem.DataItem.IsInactive Then

                NewDataRow(2) = "YES"

            Else

                NewDataRow(2) = "NO"

            End If

        Next

        DataView = New DataView(DataTable)

        GridView = New GridView

        GridView.DataSource = DataView
        GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("Clients.xls", GridView) <--- This doesn' work
        Me.DeliverGrid(DataTable, "Clients") '<--- This does, please don't change unless you test!!!!


        RadGridClients.AllowPaging = True

        LoadClients()

    End Sub
    Private Sub RadGridClients_Init(sender As Object, e As EventArgs) Handles RadGridClients.Init

        Dim GridFilterMenu As Telerik.Web.UI.GridFilterMenu = Nothing
        Dim MenuCounter As Integer = 0

        GridFilterMenu = RadGridClients.FilterMenu

        While MenuCounter < GridFilterMenu.Items.Count

            If GridFilterMenu.Items(MenuCounter).Text = "IsNull" OrElse GridFilterMenu.Items(MenuCounter).Text = "NotIsNull" Then

                GridFilterMenu.Items.RemoveAt(MenuCounter)

            Else

                MenuCounter = MenuCounter + 1

            End If

        End While

    End Sub
    Private Sub RadGridClients_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridClients.ItemCommand

        'objects
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridClients.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "Copy"

                Me.OpenWindow("Client Copy", "Maintenance_ClientEdit.aspx?From=Maintenance&Mode=Copy&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("Code"), 0, 0, False, False, "RefreshPage")

                Reload = False

            Case "Detail"

                Me.OpenWindow("Client Detail", "Maintenance_ClientEdit.aspx?From=Maintenance&Mode=Open&ClientCode=" & CurrentGridDataItem.GetDataKeyValue("Code"), 0, 0, False, False, "RefreshPage")

                Reload = False

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                        If Client IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Client.Delete(DbContext, Client) = False Then

                                Me.ShowMessage("Client is in use and cannot be deleted.")
                                Reload = False

                            End If

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            LoadClients()

        End If

    End Sub
    Private Sub RadGridClients_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridClients.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonCopy As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Enabled = Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            ImageButtonCopy = DirectCast(e.Item.FindControl("ImageButtonCopy"), ImageButton)

            If ImageButtonCopy IsNot Nothing Then

                ImageButtonCopy.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client)

            End If

        Catch ex As Exception
            ImageButtonCopy = Nothing
        End Try

    End Sub
    Private Sub RadGridClients_PreRender(sender As Object, e As EventArgs) Handles RadGridClients.PreRender

        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing

        If Not Page.IsPostBack Then

            If _IsCRMUser Then

                RadGridClients.MasterTableView.FilterExpression = "([IsNewBusiness] = True)"

                GridColumn = RadGridClients.MasterTableView.GetColumnSafe("GridTemplateColumnIsNewBusiness")

                GridColumn.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.EqualTo

                GridColumn.CurrentFilterValue = "True"

                RadGridClients.MasterTableView.Rebind()

            End If

        End If

    End Sub
    Private Sub RadToolBarClient_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarClient.ButtonClick

        If DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName = "Add" Then

            Me.OpenWindow("New Client", "Maintenance_ClientEdit.aspx?From=Maintenance&Mode=Add&ClientCode=", 0, 0, False, False, "RefreshPage")

        End If

    End Sub

#End Region

#End Region

End Class
