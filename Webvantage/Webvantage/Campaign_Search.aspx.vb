Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic

Imports Webvantage.cGlobals

Partial Public Class Campaign_Search
    Inherits Webvantage.BaseChildPage

    Private Office As String = ""
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private CmpCode As String = ""
    Private Closed As Boolean = False
    Private _LoadingDatasource As Boolean = False

    Private Sub Page_Init(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.SetPanelControls()
        Me.SetQSVars()
    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)

            RadToolBarButtonNew.Enabled = Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Campaigns)

        End If

    End Sub

    Private Sub SetQSVars()
        Try
            Try
                If Not Request.QueryString("c") = Nothing Then
                    Me.Client = Request.QueryString("c").ToString()
                End If
            Catch ex As Exception
                Me.Client = ""
            End Try
            Try
                If Not Request.QueryString("d") = Nothing Then
                    Me.Division = Request.QueryString("d").ToString()
                End If
            Catch ex As Exception
                Me.Division = ""
            End Try
            Try
                If Not Request.QueryString("p") = Nothing Then
                    Me.Product = Request.QueryString("p").ToString()
                End If
            Catch ex As Exception
                Me.Product = ""
            End Try

            Me.txtClient.Text = Me.Client
            Me.txtDivision.Text = Me.Division
            Me.txtProduct.Text = Me.Product

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Protected Sub SetPanelControls()
        Try
            Me.hlOffice.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=cmpsearch&control=" & Me.txtOffice.ClientID & "&type=office&ddtype=client');return false;")

            Me.hlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=cmpsearch&control=" & Me.txtClient.ClientID & "&type=client&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")
            Me.hlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?calledfrom=custom&form=cmpsearch&control=" & Me.txtDivision.ClientID & "&type=divisionjj&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

            Me.hlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=campaignsearch&type=product&control=" & Me.txtProduct.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value);return false;")

            Me.hlCampaignCode.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?calledfrom=custom&form=campaignsearch&type=campaign&control=" & Me.txtCampaignCode.ClientID & "&client=' + document.forms[0]." & Me.txtClient.ClientID & ".value + '&division=' + document.forms[0]." & Me.txtDivision.ClientID & ".value + '&product=' + document.forms[0]." & Me.txtProduct.ClientID & ".value + '&office=' + document.forms[0]." & Me.txtOffice.ClientID & ".value);return false;")

        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

#Region " Radgrid "
    Dim lab As System.Web.UI.WebControls.Label

    Private Sub RadGridCampaignSearch_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridCampaignSearch.ItemCommand


        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0

        If Not e.Item Is Nothing Then

            index = e.Item.ItemIndex

        Else

            Exit Sub

        End If
        If index = -1 Then 'command item

            MiscFN.SavePageSize(Me.RadGridCampaignSearch.ID, Me.RadGridCampaignSearch.PageSize)
            Exit Sub

        End If

        Dim row As Telerik.Web.UI.GridDataItem
        row = e.Item

        Dim q As New AdvantageFramework.Web.QueryString()
        With q

            .Page = "Campaign.aspx"
            .CampaignIdentifier = row.GetDataKeyValue("CMP_IDENTIFIER")
            .CampaignCode = row.GetDataKeyValue("CMP_CODE")

        End With

        Select Case e.CommandName

            Case "Detail"

                q.Add("Mode", "open")
                q.Page = "Campaign.aspx"

            Case "Print"

                q.Page = "Campaign_Print.aspx"

        End Select

        Me.OpenWindow("", q.ToString(True))

    End Sub

    Private Sub RadGridCampaignSearch_ItemDeleted(sender As Object, e As Telerik.Web.UI.GridDeletedEventArgs) Handles RadGridCampaignSearch.ItemDeleted

    End Sub

    Private Sub RadGridCampaignSearch_ItemUpdated(sender As Object, e As Telerik.Web.UI.GridUpdatedEventArgs) Handles RadGridCampaignSearch.ItemUpdated

    End Sub

    Private Sub RadGridCampaignSearch_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCampaignSearch.NeedDataSource
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"))
        Dim dr As DataSet
        Dim rowcount As Integer

        Me.Office = Me.txtOffice.Text
        Me.Client = txtClient.Text
        Me.Division = txtDivision.Text
        Me.Product = txtProduct.Text
        Me.CmpCode = txtCampaignCode.Text
        Me.Closed = Me.cbClosedCampaigns.Checked

        dr = cmp.GetCampaignSearch(Session("UserCode"), Office, Client, Division, Product, CmpCode, Closed)

        Me.RadGridCampaignSearch.DataSource = dr.Tables(0)
        _LoadingDatasource = True

        Try
            If dr.Tables(0).Rows.Count = 1 Then
                If Not IsDBNull(dr.Tables(0).Rows(0)("CMP_IDENTIFIER")) = True Then
                    Dim q As New AdvantageFramework.Web.QueryString()
                    With q

                        .Page = "Campaign.aspx"
                        .CampaignIdentifier = dr.Tables(0).Rows(0)("CMP_IDENTIFIER")
                        .CampaignCode = dr.Tables(0).Rows(0)("CMP_CODE")

                    End With

                    Me.OpenWindow("", q.ToString(True))

                End If
            End If
        Catch ex As Exception
        End Try
        Me.RadGridCampaignSearch.CurrentPageIndex = Me.CurrentGridPageIndex
        Me.RadGridCampaignSearch.PageSize = MiscFN.LoadPageSize(Me.RadGridCampaignSearch.ID)
        _LoadingDatasource = False
    End Sub

    Private Property CurrentGridPageIndex As Integer = 0
    Private Sub RadGridCampaignSearch_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridCampaignSearch.PageIndexChanged
        Me.Office = Me.txtOffice.Text
        Me.Client = txtClient.Text
        Me.Division = txtDivision.Text
        Me.Product = txtProduct.Text
        Me.CmpCode = txtCampaignCode.Text
        Me.Closed = Me.cbClosedCampaigns.Checked
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridCampaignSearch.Rebind()
    End Sub

    Private Sub RadGridCampaignSearch_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridCampaignSearch.PageSizeChanged

        If _LoadingDatasource = False Then

            MiscFN.SavePageSize(Me.RadGridCampaignSearch.ID, e.NewPageSize)

        End If

        Me.ValidateSearch()
    End Sub

#End Region

    Private Sub RadToolbarCampaignSearch_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarCampaignSearch.ButtonClick
        Select Case e.Item.Value
            Case "Search"
                Try
                    If Me.ValidateSearch() = True Then
                        Me.RadGridCampaignSearch.Rebind()
                    End If
                Catch ex As Exception
                    Me.ShowMessage("err in search")
                End Try
            Case "Clear"
                Me.txtOffice.Text = ""
                Me.txtClient.Text = ""
                Me.txtDivision.Text = ""
                Me.txtProduct.Text = ""
                Me.txtCampaignCode.Text = ""

                Me.cbClosedCampaigns.Checked = False
                Me.Office = ""
                Me.Client = ""
                Me.Division = ""
                Me.Product = ""
                Me.CmpCode = ""



                Me.SetPanelControls()
                Me.RadGridCampaignSearch.MasterTableView.CurrentPageIndex = 0
                Me.RadGridCampaignSearch.Rebind()

            Case "New"

                Me.OpenWindow("", "Campaign_New.aspx")

        End Select
    End Sub

    Private Function ValidateSearch() As Boolean
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim cmp As cCampaign = New cCampaign(Session("ConnString"))

        If Me.txtOffice.Text <> "" Then
            If myVal.ValidateOffice(Me.txtOffice.Text, True) = False Then
                Me.ShowMessage("Invalid Office")
                MiscFN.SetFocus(Me.txtOffice)
                Return False
            End If
        End If

        If txtClient.Text <> "" Then
            If cmp.ValidateClient(txtClient.Text) = False Then
                Me.ShowMessage("Invalid Client")
                MiscFN.SetFocus(Me.txtClient)
                Return False
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), txtClient.Text, "", "") = False Then
                Me.ShowMessage("Access to this client is denied.")
                Return False
            End If
        End If

        If txtDivision.Text <> "" Then
            If cmp.ValidateDivision(txtClient.Text, txtDivision.Text) = False Then
                Me.ShowMessage("Invalid Division")
                MiscFN.SetFocus(Me.txtDivision)
                Return False
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), txtClient.Text, txtDivision.Text, "") = False Then
                Me.ShowMessage("Access to this division is denied.")
                Return False
            End If
        End If

        If txtProduct.Text <> "" Then
            If cmp.ValidateProduct(txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                Me.ShowMessage("Invalid Product")
                MiscFN.SetFocus(Me.txtProduct)
                Return False
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text) = False Then
                Me.ShowMessage("Access to this product is denied.")
                Return False
            End If
        End If

        If txtCampaignCode.Text <> "" Then
            If cmp.CampaignExists(txtCampaignCode.Text) = False Then
                Me.ShowMessage("Invalid Campaign")
                MiscFN.SetFocus(Me.txtCampaignCode)
                Return False
            End If

            If myVal.ValidateCampaignIsViewable(Session("UserCode"), txtClient.Text, txtDivision.Text, txtProduct.Text, txtCampaignCode.Text) = False Then
                Me.ShowMessage("Access to this campaign is denied.")
                MiscFN.SetFocus(Me.txtCampaignCode)
                Return False
            End If
        End If

        Me.Office = Me.txtOffice.Text
        Me.Client = txtClient.Text
        Me.Division = txtDivision.Text
        Me.Product = txtProduct.Text
        Me.CmpCode = txtCampaignCode.Text
        Me.Closed = Me.cbClosedCampaigns.Checked

        Return True

    End Function

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Try
            If Me.ValidateSearch() = True Then
                Me.RadGridCampaignSearch.Rebind()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
