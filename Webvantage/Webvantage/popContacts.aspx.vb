Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet

Partial Public Class popContacts
    Inherits Webvantage.BaseChildPage

    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""

    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0

    Private FromAlertPage As Boolean = False

    Private Sub Page_Init1(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

        Try
            If Not Request.QueryString("client") Is Nothing Then
                Client = Request.QueryString("client")
            End If
        Catch ex As Exception
            Client = ""
        End Try
        Try
            If Not Request.QueryString("division") Is Nothing Then
                Division = Request.QueryString("division")
            End If
        Catch ex As Exception
            Division = ""
        End Try
        Try
            If Not Request.QueryString("product") Is Nothing Then
                Product = Request.QueryString("product")
            End If
        Catch ex As Exception
            Product = ""
        End Try

        Try
            Me.JobNumber = CType(Request.QueryString("j"), Integer)
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            Me.JobComponentNbr = CType(Request.QueryString("jc"), Integer)
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try

        Try
            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ClientCode) = False Then Me.Client = Me.CurrentQuerystring.ClientCode
        Catch ex As Exception
        End Try
        Try
            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.DivisionCode) = False Then Me.Division = Me.CurrentQuerystring.DivisionCode
        Catch ex As Exception
        End Try
        Try
            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.ProductCode) = False Then Me.Product = Me.CurrentQuerystring.ProductCode
        Catch ex As Exception
        End Try
        Try
            If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        Catch ex As Exception
        End Try
        Try
            If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNbr = Me.CurrentQuerystring.JobComponentNumber
        Catch ex As Exception
        End Try

        Try
            If Request.QueryString("from").ToString().ToLower().IndexOf("alert") > -1 Then
                Me.FromAlertPage = True
            End If
        Catch ex As Exception
            Me.FromAlertPage = False
        End Try

        'Me.ButtonAddContact.Visible = Not Me.FromAlertPage

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack And Not Page.IsCallback Then

            If Request.QueryString("from") = "jjcl" Then

                Me.RadGridContacts.Visible = False
                Me.RadioButtonClient.Checked = True
                Me.ButtonAddContact.Visible = False
                Me.Page.Title = "Job Control"
                Me.PanelJPC.Visible = False

            ElseIf Request.QueryString("from") = "jjpc" Then

                Me.RadGridContacts.Visible = False
                Me.RadGridCDP.Visible = False
                Me.LabelAddress.Visible = False
                Me.RadioButtonClient.Visible = False
                Me.RadioButtonDivision.Visible = False
                Me.RadioButtonProduct.Visible = False
                Me.PanelJPC.Visible = True
                LoadJobProcessControls()
                Me.ButtonUpdateJPC.Visible = True
                Me.ButtonAddContact.Visible = False

            Else

                Me.Page.Title = "Contacts"
                Me.RadGridCDP.Visible = False
                Me.LabelAddress.Visible = False
                Me.RadioButtonClient.Visible = False
                Me.RadioButtonDivision.Visible = False
                Me.RadioButtonProduct.Visible = False

                Try

                    If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

                        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                        oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, "", "", "", Client, Division, Product)

                    End If
                Catch ex As Exception
                End Try

                Dim sec As New cSecurity(Session("ConnString"))
                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode) = False Then

                        Me.ButtonAddContact.Visible = False
                    Else

                        If IIf(AdvantageFramework.Security.CanUserAddInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode), "Y", "N") = "N" Then

                            Me.ButtonAddContact.Visible = False

                        End If

                    End If

                End Using

                If Me.ButtonAddContact.Visible = True Then

                    Dim job As New Job_Template(Session("ConnString"))
                    If job.GetContactSecurity(Session("UserCode")) = "N" Then

                        Me.ButtonAddContact.Visible = False

                    End If

                End If

                Me.PanelJPC.Visible = False

            End If
        Else
            Select Case Me.EventArgument
                Case "Refresh"
                    Me.RadGridContacts.Rebind()

                    'Me.Response.Redirect("popContacts.aspx")
            End Select
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.CloseThisWindow()

    End Sub

    Private Sub RadGridContacts_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridContacts.ItemCommand
        Try
            If Client = "" Then
                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, "", "", "", Client, Division, Product)
                End If
            End If
            If e.CommandName = "Detail" Then
                Dim dataitem As Telerik.Web.UI.GridDataItem
                dataitem = e.Item
                Me.OpenWindow("Edit Contact", "popContactsAdd.aspx?ccid=" & dataitem.GetDataKeyValue("CDP_CONTACT_ID") & "&client=" & Me.Client & "&code=" & dataitem.GetDataKeyValue("code"), 750, 950, False, False, "RefreshPage")


            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridContacts_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridContacts.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim phone As String = String.Empty
                Dim gdi As Telerik.Web.UI.GridDataItem = e.Item
                Dim ContactPhone As String = String.Empty

                Try

                    Dim str As String = e.Item.Cells(2).Text
                    Dim str2 As String = e.Item.Cells(3).Text
                    Dim str3 As String = e.Item.Cells(4).Text
                    Dim str4 As String = e.Item.Cells(6).Text
                    Dim str5 As String = e.Item.Cells(8).Text

                    phone = e.Item.Cells(7).Text
                    ContactPhone = phone
                    If phone <> "" Then
                        'phone = phone.Replace("-", "").Replace("(", "").Replace(")", "").Replace("ext", "").Trim
                        If phone.Length = 10 And phone.Contains("-") = False And phone.Contains("(") = False Then
                            phone = "(" & phone.Substring(0, 3) & ") " & phone.Substring(3, 3) & "-" & phone.Substring(6)
                        End If
                        If phone.Length = 7 Then
                            phone = phone.Substring(0, 3) & "-" & phone.Substring(3)
                        End If
                        e.Item.Cells(7).Text = phone
                        ContactPhone = phone
                    End If
                    phone = e.Item.Cells(8).Text
                    If phone <> "" Then
                        'phone = phone.Replace("-", "").Replace("(", "").Replace(")", "").Replace("ext", "").Trim
                        If phone.Length = 10 And phone.Contains("-") = False And phone.Contains("(") = False Then
                            phone = "(" & phone.Substring(0, 3) & ") " & phone.Substring(3, 3) & "-" & phone.Substring(6)
                        End If
                        If phone.Length = 7 Then
                            phone = phone.Substring(0, 3) & "-" & phone.Substring(3)
                        End If
                        e.Item.Cells(8).Text = phone
                    End If
                    phone = e.Item.Cells(9).Text
                    If phone <> "" Then
                        'phone = phone.Replace("-", "").Replace("(", "").Replace(")", "").Replace("ext", "").Trim
                        If phone.Length = 10 And phone.Contains("-") = False And phone.Contains("(") = False Then
                            phone = "(" & phone.Substring(0, 3) & ") " & phone.Substring(3, 3) & "-" & phone.Substring(6)
                        End If
                        If phone.Length = 7 Then
                            phone = phone.Substring(0, 3) & "-" & phone.Substring(3)
                        End If
                        e.Item.Cells(9).Text = phone
                    End If

                    If e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" And gdi.GetDataKeyValue("CONT_EXTENTION") <> "" And gdi.GetDataKeyValue("CONT_EXTENTION") <> "&nbsp;" Then
                        e.Item.Cells(7).Text = e.Item.Cells(7).Text & " ext " & gdi.GetDataKeyValue("CONT_EXTENTION")
                    End If
                    If e.Item.Cells(9).Text <> "" And e.Item.Cells(9).Text <> "&nbsp;" And gdi.GetDataKeyValue("CONT_FAX_EXTENTION") <> "" And gdi.GetDataKeyValue("CONT_FAX_EXTENTION") <> "&nbsp;" Then
                        e.Item.Cells(9).Text = e.Item.Cells(9).Text & " ext " & gdi.GetDataKeyValue("CONT_FAX_EXTENTION")
                    End If

                    Dim sec As New cSecurity(Session("ConnString"))
                    Dim dr As SqlDataReader
                    Dim secInsert As String

                    secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact), "Y", "N")

                    Dim job As New Job_Template(Session("ConnString"))
                    Dim ViewImage As WebControls.ImageButton = e.Item.Cells(0).FindControl("butDetail")
                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode) = False Then
                            ViewImage.Visible = False
                        End If
                    End Using
                    'If job.GetContactSecurity(Session("UserCode")) = "N" Or secInsert = "N" Then
                    '    ViewImage.Attributes.Add("onclick", "")
                    'Else
                    'If Request.QueryString("From") = "ca" Then
                    '    ViewImage.Attributes.Add("onclick", "window.open('popContactsAdd.aspx?From=ca&ccid=" & e.Item.Cells(5).Text & "&client=" & Me.Client & "&code=" & e.Item.Cells(4).Text & "', 'PopCC','screenX=50,left=50,screenY=150,top=150,width=950,height=750,scrollbars=yes,resizable=no,menubar=no,maximazable=yes');return false;")
                    'End If

                    'End If

                    If Request.QueryString("From") = "jj" Then
                        If e.Item.Cells(3).Text <> "" Then
                            Dim strCC() As String = e.Item.Cells(3).Text.Split("-")
                            e.Item.Cells(3).Text = strCC(1).Trim
                        End If
                    End If

                Catch ex As Exception
                End Try

                'Copy/Paste
                Try

                    Dim CopyPasteImageButton As WebControls.ImageButton = e.Item.FindControl("ImageButtonCopyPaste")
                    Dim CopyPasteStringBuilder As New System.Text.StringBuilder

                    Try

                        Dim ar As String()
                        ar = e.Item.DataItem("description").ToString.Split(" - ")

                        If ar.Length > 2 Then

                            Dim code As String = ar(0).Trim & " - "
                            Dim desc As String = e.Item.DataItem("description").ToString

                            desc = desc.Replace(code, "Contact:  ")
                            CopyPasteStringBuilder.Append(desc)
                            CopyPasteStringBuilder.Append(" | ")

                        Else

                            CopyPasteStringBuilder.Append(e.Item.DataItem("description"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                        CopyPasteStringBuilder.Append(e.Item.DataItem("description"))
                        CopyPasteStringBuilder.Append(" | ")
                    End Try

                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("CONT_TITLE").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append(e.Item.DataItem("CONT_TITLE"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(ContactPhone.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append("p:")
                            CopyPasteStringBuilder.Append(ContactPhone)
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("CELL_PHONE").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append("c:")
                            CopyPasteStringBuilder.Append(e.Item.DataItem("CELL_PHONE"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("CONT_FAX").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append("f:")
                            CopyPasteStringBuilder.Append(e.Item.DataItem("CONT_FAX"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("EMAIL_ADDRESS").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append(e.Item.DataItem("EMAIL_ADDRESS"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("CONT_EXTENTION").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append("px:")
                            CopyPasteStringBuilder.Append(e.Item.DataItem("CONT_EXTENTION"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try
                    Try

                        If String.IsNullOrWhiteSpace(e.Item.DataItem("CONT_FAX_EXTENTION").ToString.Replace("&nbsp;", "")) = False Then

                            CopyPasteStringBuilder.Append("fx:")
                            CopyPasteStringBuilder.Append(e.Item.DataItem("CONT_FAX_EXTENTION"))
                            CopyPasteStringBuilder.Append(" | ")

                        End If

                    Catch ex As Exception
                    End Try

                    Dim s As String = CopyPasteStringBuilder.ToString

                    s = s.ToString.Replace("&nbsp; |", "")
                    s = MiscFN.RemoveTrailingDelimiter(s, "|")

                    gdi("column1").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))
                    gdi("column56").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))
                    gdi("column55").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))
                    gdi("column6").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))
                    gdi("column7").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))
                    gdi("column8").Attributes.Add("onclick", String.Format("copyToClipboard('{0}');", s))

                Catch ex As Exception
                End Try

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridContacts_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridContacts.NeedDataSource
        Try

            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Dim HasDataSource As Boolean = False

            If Me.JobNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim JobLog As AdvantageFramework.Database.Entities.Job

                    JobLog = Nothing
                    JobLog = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(Nothing, Me.JobNumber)

                    If JobLog IsNot Nothing Then

                        Me.Client = JobLog.ClientCode
                        Me.Division = JobLog.DivisionCode
                        Me.Product = JobLog.ProductCode

                    End If

                End Using

            End If

            If Request.QueryString("From") = "jj" OrElse Me.FromAlertPage = True Then

                Me.RadGridContacts.DataSource = oDD.GetCDP_ProductContact(Client, Division, Product, "jj")

            Else

                If String.IsNullOrWhiteSpace(Division) = True AndAlso String.IsNullOrWhiteSpace(Product) = True Then

                    Me.RadGridContacts.DataSource = oDD.GetCDP_ClientContact(Client)

                Else

                    Me.RadGridContacts.DataSource = oDD.GetCDP_ProductContactOnly(Client, Division, Product, "")

                End If

            End If

        Catch ex As Exception
        End Try

    End Sub

    Private Sub RadGridCDP_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCDP.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then
                Dim str As String = e.Item.Cells(2).Text
                Dim str2 As String = e.Item.Cells(5).Text ' cl address
                Dim str3 As String = e.Item.Cells(7).Text
                Dim str4 As String = e.Item.Cells(9).Text
                Dim str5 As String = e.Item.Cells(10).Text

                If e.Item.Cells(6).Text <> "" Then
                    e.Item.Cells(5).Text &= vbCrLf & e.Item.Cells(6).Text
                End If
                If e.Item.Cells(11).Text <> "" Then
                    e.Item.Cells(10).Text &= vbCrLf & e.Item.Cells(11).Text
                End If
                If e.Item.Cells(16).Text <> "" Then
                    e.Item.Cells(15).Text &= vbCrLf & e.Item.Cells(16).Text
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCDP_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCDP.NeedDataSource
        Try
            Dim rpt As New cReports(CStr(Session("ConnString")))

            Try
                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, "", "", "", Client, Division, Product)
                End If
            Catch ex As Exception
            End Try

            Try
                If Me.RadioButtonClient.Checked = True Then
                    For i As Integer = 0 To Me.RadGridCDP.MasterTableView.Columns.Count - 1
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column4" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column6" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column7" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column8" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column9" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column11" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column12" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column13" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column14" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column16" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column17" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column18" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column19" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                    Next
                End If
                If Me.RadioButtonDivision.Checked = True Then
                    For i As Integer = 0 To Me.RadGridCDP.MasterTableView.Columns.Count - 1
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column4" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column6" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column7" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column8" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column9" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column11" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column12" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column13" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column14" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column16" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column17" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column18" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column19" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                    Next
                End If
                If Me.RadioButtonProduct.Checked = True Then
                    For i As Integer = 0 To Me.RadGridCDP.MasterTableView.Columns.Count - 1
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column4" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column6" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column7" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column8" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column9" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column11" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column12" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column13" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = False
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column14" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column16" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column17" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column18" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                        If Me.RadGridCDP.MasterTableView.Columns(i).UniqueName = "column19" Then
                            Me.RadGridCDP.MasterTableView.Columns(i).Visible = True
                        End If
                    Next
                End If
            Catch ex As Exception

            End Try

            Me.RadGridCDP.DataSource = rpt.GetCDPAddressInfo("CDP", Client, Division, Product)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCDP_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridCDP.PreRender

    End Sub

    Private Sub RadioButtonClient_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonClient.CheckedChanged
        Me.RadGridCDP.Rebind()
    End Sub

    Private Sub RadioButtonDivision_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonDivision.CheckedChanged
        Me.RadGridCDP.Rebind()
    End Sub

    Private Sub RadioButtonProduct_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonProduct.CheckedChanged
        Me.RadGridCDP.Rebind()
    End Sub

    Public Sub LoadJobProcessControls()
        Try
            Dim odd As New cDropDowns(Session("ConnString"))
            'With Me.RadioButtonListJPC
            '    .DataSource = odd.GetJobProcessControls
            '    .DataTextField = "description"
            '    .DataValueField = "code"
            '    .DataBind()
            'End With

            For i As Integer = 0 To Me.RadioButtonListJPC.Items.Count - 1
                Dim jc As New JOB_COMPONENT(Session("ConnString"))
                jc.Where.JOB_NUMBER.Value = JobNumber
                jc.Where.JOB_COMPONENT_NBR.Value = JobComponentNbr
                If jc.Query.Load() Then
                    If Me.RadioButtonListJPC.Items(i).Value = jc.JOB_PROCESS_CONTRL Then
                        Me.RadioButtonListJPC.Items(i).Selected = True
                    End If
                End If
            Next

            Dim jt As New Job_Template(Session("ConnString"))
            Dim ds As DataSet = jt.GetJobProcessLog(Me.JobNumber, Me.JobComponentNbr)

            If ds.Tables(0).Rows.Count > 0 Then
                Me.LabelBy.Text = ds.Tables(0).Rows(0)("PROCESS_USER")
                Me.LabelDate.Text = String.Format("{0:g}", ds.Tables(0).Rows(0)("PROCESS_DATE"))
                Me.LabelChangedFrom.Text = ds.Tables(0).Rows(0)("JOB_PROCESS_DESC")
                Me.TextBoxProcessComment.Text = ds.Tables(0).Rows(0)("PROCESS_COMMENT")
                Me.HiddenFieldJPC.Value = ds.Tables(0).Rows(0)("NEW_PROCESS_CNTRL")
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonUpdateJPC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonUpdateJPC.Click
        Try
            Dim SQL_UPDATE_STR As String
            Dim oSQL As SqlHelper
            Dim save As Integer
            'SQL_UPDATE_STR = "UPDATE JOB_COMPONENT SET JOB_PROCESS_CONTRL = " & Me.RadioButtonListJPC.SelectedValue & " WHERE JOB_NUMBER = " & Me.JobNumber & " AND JOB_COMPONENT_NBR = " & Me.JobComponentNbr

            'Try
            '    oSQL.ExecuteScalar(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)
            'Catch
            '    Err.Raise(Err.Number, "Class:UpdateJPC", Err.Description)
            'End Try

            Try
                Dim jt As New Job_Template(Session("ConnString"))
                save = jt.UpdateJobProcessLog(Me.JobNumber, Me.JobComponentNbr, Me.RadioButtonListJPC.SelectedValue, Me.TextBoxProcessComment.Text)
                'Dim save As Boolean = jt.AddNewJobProcessLog(Me.JobNumber, Me.JobComponentNbr, Me.HiddenFieldJPC.Value, Me.RadioButtonListJPC.SelectedValue, Session("UserCode"), Me.TextBoxProcessComment.Text)
            Catch ex As Exception

            End Try

            If save = 0 Then
                Me.CloseThisWindowAndRefreshCaller("Content.aspx")
            Else
                Me.ShowMessage("The job is not completely billed or it contains open Purchase Orders. Please print the Billing Report for details.")
            End If


            'Dim cScript As String
            'cScript = "<script language='javascript'> window.opener.location='jobtemplate.aspx?PageMode=Edit&JobNum=" & JobNumber & "&JobCompNum=" & JobComponentNbr & "&NewComp=0&NewJS=0'; </script>"
            'RegisterStartupScript("parentwindow2", cScript)

            'Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
            'With sbScript
            '    .Append("<script type=""text/javascript"">")
            '    .Append("window.close();</script>")
            'End With
            'Try
            '    If Not Page.IsStartupScriptRegistered("JS") Then
            '        Dim str As String = sbScript.ToString
            '        Page.RegisterStartupScript("JS", str)
            '    End If
            'Catch ex As Exception
            '    Me.ShowMessage("Error! " & ex.Message.ToString())
            'End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonAddContact_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonAddContact.Click
        Try
            If Client = "" Then
                If Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.GetJobComponentInfo(Me.JobNumber, Me.JobComponentNbr, "", "", "", Client, Division, Product)
                End If
            End If
            Me.OpenWindow("Add Contact", "popContactsAdd.aspx?From=jj&client=" & Client & "&division=" & Division & "&product=" & Product, 750, 1200, False, False, "RefreshPage")
        Catch ex As Exception
        End Try
    End Sub
End Class
