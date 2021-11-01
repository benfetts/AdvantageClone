Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports Telerik.Web.UI

Partial Public Class popContactsAdd
    Inherits Webvantage.BaseChildPage

    Public ccid As Integer = 0
    Public code As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Page.IsPostBack Then
            Try
                LoadDropDownDataSources()
                Me.CheckBoxGetAlerts.Enabled = False
                Me.CheckBoxEmailRcpt.Enabled = False
                If Not Request.QueryString("client") Is Nothing Then
                    Me.TextBoxClient.Text = Request.QueryString("client")
                End If
                If Not Request.QueryString("ccid") Is Nothing Then
                    ccid = CInt(Request.QueryString("ccid"))
                    LoadContact()
                    'Me.BtnSave.Visible = False
                    'Me.BtnUpdate.Visible = True
                    CheckSecurity()
                    Me.Title = "Edit Contact"
                Else
                    Me.Title = "Add Contact"
                End If
                Me.TextBoxContactCode.Focus()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.CloseThisWindow()
    End Sub

    Private Sub RadGridDP_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridDP.ItemDataBound
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridDP_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridDP.NeedDataSource

        'objects
        Dim DataSet As System.Data.DataSet = Nothing
        Dim DataTable As System.Data.DataTable = Nothing
        Dim job As Job_Template = Nothing

        Try

            job = New Job_Template(Session("ConnString"))

            DataSet = job.GetContactDP(Request.QueryString("client"))

            If DataSet IsNot Nothing AndAlso DataSet.Tables.Count > 0 AndAlso DataSet.Tables(0) IsNot Nothing Then

                DataTable = DataSet.Tables(0)

                Me.RadGridDP.DataSource = DataTable.Select("PRD_CODE <> ''")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub RadGridDP_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridDP.PreRender
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim chk As CheckBox
            If ccid <> 0 Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDP.MasterTableView.Items
                    Dim dr As SqlDataReader
                    dr = job.GetContactDivPrd(ccid)
                    If dr.HasRows = True Then
                        Do While dr.Read

                            If gridDataItem.GetDataKeyValue("DIV_CODE") = dr("DIV_CODE") And (gridDataItem.GetDataKeyValue("PRD_CODE") = dr("PRD_CODE") Or
                                                                                      (gridDataItem.GetDataKeyValue("PRD_CODE") = "" And dr("PRD_CODE") = "")) Then
                                gridDataItem.Selected = True
                            End If
                        Loop
                    End If
                    Dim sec As New cSecurity(Session("ConnString"))
                    Dim dr2 As SqlDataReader
                    Dim secUpdate As String

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                        secUpdate = IIf(AdvantageFramework.Security.CanUserUpdateInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode), "Y", "N")
                    End Using

                    If job.GetContactSecurity(Session("UserCode")) = "N" Or secUpdate = "N" Then
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        chk.Enabled = False
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim chk As CheckBox
            If Me.TextBoxContactCode.Text = "" Then
                Me.lblMSG.Text = "Contact Code is required."
                Exit Sub
            End If
            Dim save As Boolean
            Dim cdpid As Integer = 0
            Dim duplicate As Boolean = job.CheckContactDuplicates(Request.QueryString("client"), Me.TextBoxContactCode.Text)
            If duplicate = True Then
                Me.lblMSG.Text = "Duplicate Contact Codes not allowed."
                Exit Sub
            End If
            cdpid = job.AddNewContact(Request.QueryString("client"), Me.TextBoxContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                     Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                     Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text,
                                     Me.CheckBoxScheduleUser.Checked, Me.CheckBoxCPUser.Checked, Me.CheckBoxGetAlerts.Checked, Me.CheckBoxEmailRcpt.Checked,
                                     Me.CheckBoxInactive.Checked, Me.CheckBoxCopyAddress.Checked, Me.TextBoxComment.Text, CInt(Me.RadComboBoxContactType.SelectedValue))

            If cdpid <> 0 Then
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDP.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        save = job.AddNewContactDP(cdpid, gridDataItem.GetDataKeyValue("DIV_CODE"), gridDataItem.GetDataKeyValue("PRD_CODE"))
                    End If
                    'If gridDataItem.Selected = True Then

                    'End If
                Next
            End If

            'If Request.QueryString("From") = "ca" Then
            '    Dim cScript2 As String = "<script language='javascript'>window.opener.location=window.opener.location;window.close();</script>"
            '    If Not Page.IsStartupScriptRegistered("Webvantage") Then
            '        Page.RegisterStartupScript("Webvantage", cScript2)
            '    End If

            'Else
            If Request.QueryString("From") = "ClientEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientEdit.aspx")

            ElseIf Request.QueryString("From") = "DivisionEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_DivisionEdit.aspx")

            ElseIf Request.QueryString("From") = "ProductEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_ProductEdit.aspx")

            ElseIf Request.QueryString("From") = "Maintenance_ClientContactManager" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientContactManager.aspx")

            Else

                Me.CloseThisWindowAndRefreshCaller("popContacts.aspx")

            End If

            'End If


        Catch ex As Exception
            Me.ShowMessage(ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadContact()
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim dr As SqlDataReader
            dr = job.GetContact(ccid)
            If dr.HasRows = True Then
                Do While dr.Read
                    Me.TextBoxContactCode.Text = dr("CONT_CODE")
                    Me.txtFirstName.Text = dr("CONT_FNAME")
                    Me.txtLastName.Text = dr("CONT_LNAME")
                    Me.txtMI.Text = dr("CONT_MI")
                    Me.txtTitle.Text = dr("CONT_TITLE")
                    Me.txtAddress1.Text = dr("CONT_ADDRESS1")
                    Me.txtAddress2.Text = dr("CONT_ADDRESS2")
                    Me.txtCity.Text = dr("CONT_CITY")
                    Me.txtCounty.Text = dr("CONT_COUNTY")
                    Me.txtState.Text = dr("CONT_STATE")
                    Me.txtCountry.Text = dr("CONT_COUNTRY")
                    Me.txtZip.Text = dr("CONT_ZIP")
                    Me.txtPhone.Text = dr("CONT_TELEPHONE")
                    Me.txtPhoneExt.Text = dr("CONT_EXTENTION")
                    Me.txtFax.Text = dr("CONT_FAX")
                    Me.txtFaxExt.Text = dr("CONT_FAX_EXTENTION")
                    Me.txtEmailAddress.Text = dr("EMAIL_ADDRESS")
                    Me.txtCell.Text = dr("CELL_PHONE")
                    Me.TextBoxComment.Text = dr("CONT_COMMENT")
                    If dr("SCHEDULE_USER") = 1 Then
                        Me.CheckBoxScheduleUser.Checked = True
                    End If
                    If dr("CP_USER") = 1 Then
                        Me.CheckBoxCPUser.Checked = True
                        Me.CheckBoxGetAlerts.Enabled = True
                        Me.CheckBoxEmailRcpt.Enabled = True
                    Else
                        Me.CheckBoxGetAlerts.Enabled = False
                        Me.CheckBoxEmailRcpt.Enabled = False
                    End If
                    If dr("CP_ALERTS") = 1 Then
                        Me.CheckBoxGetAlerts.Checked = True
                    End If
                    If dr("EMAIL_RCPT") = 1 Then
                        Me.CheckBoxEmailRcpt.Checked = True
                    End If
                    If dr("INACTIVE_FLAG") = 1 Then
                        Me.CheckBoxInactive.Checked = True
                    End If
                    Me.RadComboBoxContactType.SelectedValue = dr("CONTACT_TYPE_ID")
                Loop
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LoadDropDownDataSources()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                RadComboBoxContactType.DataSource = AdvantageFramework.Database.Procedures.ContactType.Load(DbContext).OrderBy(Function(Entity) Entity.Description).ToList
                RadComboBoxContactType.DataTextField = "Description"
                RadComboBoxContactType.DataValueField = "ID"
                RadComboBoxContactType.DataBind()

                RadComboBoxContactType.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", "0"))

            End Using

        End Using

    End Sub

    Private Sub CheckSecurity()
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim sec As New cSecurity(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim secUpdate As String

            'secUpdate = IIf(Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact), "Y", "N")
            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                secUpdate = IIf(AdvantageFramework.Security.CanUserUpdateInModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode), "Y", "N")
            End Using


            If job.GetContactSecurity(Session("UserCode")) = "N" Or secUpdate = "N" Then
                Me.TextBoxClient.Enabled = False
                Me.TextBoxContactCode.Enabled = False
                Me.txtFirstName.Enabled = False
                Me.txtLastName.Enabled = False
                Me.txtMI.Enabled = False
                Me.txtEmailAddress.Enabled = False
                Me.txtTitle.Enabled = False
                Me.txtAddress1.Enabled = False
                Me.txtAddress2.Enabled = False
                Me.txtCity.Enabled = False
                Me.txtCounty.Enabled = False
                Me.txtState.Enabled = False
                Me.txtZip.Enabled = False
                Me.txtCountry.Enabled = False
                Me.txtPhone.Enabled = False
                Me.txtPhoneExt.Enabled = False
                Me.txtFax.Enabled = False
                Me.txtFaxExt.Enabled = False
                Me.txtCell.Enabled = False
                Me.CheckBoxScheduleUser.Enabled = False
                Me.CheckBoxCPUser.Enabled = False
                Me.CheckBoxGetAlerts.Enabled = False
                Me.CheckBoxEmailRcpt.Enabled = False
                Me.CheckBoxInactive.Enabled = False
                Me.CheckBoxCopyAddress.Enabled = False
                'Me.RadGridDP.Enabled = False
                Me.BtnSave.Visible = False
                Me.BtnUpdate.Visible = False
                Me.RadToolBarButtonSave.Enabled = False
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnUpdate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnUpdate.Click
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim oAlerts As New cAlerts(Session("ConnString"))
            ccid = CInt(Request.QueryString("ccid"))
            code = Request.QueryString("code")
            Dim chk As CheckBox
            If Me.TextBoxContactCode.Text = "" Then
                Me.lblMSG.Text = "Contact Code Is required."
                Exit Sub
            End If
            If code <> Me.TextBoxContactCode.Text Then
                Dim duplicate As Boolean = job.CheckContactDuplicates(Request.QueryString("client"), Me.TextBoxContactCode.Text)
                If duplicate = True Then
                    Me.lblMSG.Text = "Duplicate Contact Codes Not allowed."
                    Exit Sub
                End If
            End If
            Dim save As Boolean
            save = job.UpdateContact(ccid, Request.QueryString("client"), Me.TextBoxContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                     Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                     Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text,
                                     Me.CheckBoxScheduleUser.Checked, Me.CheckBoxCPUser.Checked, Me.CheckBoxGetAlerts.Checked, Me.CheckBoxEmailRcpt.Checked,
                                     Me.CheckBoxInactive.Checked, Me.CheckBoxCopyAddress.Checked, Me.TextBoxComment.Text, CInt(Me.RadComboBoxContactType.SelectedValue))

            If ccid <> 0 Then
                save = job.DeleteContactDP(ccid)
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDP.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        save = job.AddNewContactDP(ccid, gridDataItem.GetDataKeyValue("DIV_CODE"), gridDataItem.GetDataKeyValue("PRD_CODE"))
                    End If
                    'If gridDataItem.Selected = True Then

                    'End If
                Next
            End If

            'If Request.QueryString("From") = "ca" Then
            '    Dim cScript As String
            '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
            '    RegisterStartupScript("parentwindow", cScript)

            '    Dim cScript2 As String
            '    cScript2 = "<script>window.close();</script>"
            '    RegisterStartupScript("page55", cScript2)
            'Else
            If Request.QueryString("From") = "ClientEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientEdit.aspx")

            ElseIf Request.QueryString("From") = "DivisionEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_DivisionEdit.aspx")

            ElseIf Request.QueryString("From") = "ProductEdit" Then

                Me.CloseThisWindowAndRefreshCaller("Maintenance_ProductEdit.aspx")

            Else

                Me.CloseThisWindowAndRefreshCaller("popContacts.aspx")

            End If

            'End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxCPUser_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxCPUser.CheckedChanged
        Try
            If Me.CheckBoxCPUser.Checked = True Then
                Me.CheckBoxEmailRcpt.Enabled = True
                Me.CheckBoxGetAlerts.Enabled = True
            Else
                Me.CheckBoxGetAlerts.Checked = False
                Me.CheckBoxEmailRcpt.Checked = False
                Me.CheckBoxEmailRcpt.Enabled = False
                Me.CheckBoxGetAlerts.Enabled = False
            End If
            Me.CheckBoxCPUser.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CheckBoxCopyAddress_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxCopyAddress.CheckedChanged
        Try
            If Request.QueryString("client") <> "" Then
                Dim client As AdvantageFramework.Database.Entities.Client = Nothing
                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
                    client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, Request.QueryString("client"))
                    If client IsNot Nothing Then
                        Me.txtAddress1.Text = client.Address
                        Me.txtAddress2.Text = client.Address2
                        Me.txtCity.Text = client.City
                        Me.txtState.Text = client.State
                        Me.txtZip.Text = client.Zip
                    End If
                End Using
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub RadToolBarClient_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarClient.ButtonClick
        Try
            Dim job As New Job_Template(Session("ConnString"))
            Dim chk As CheckBox

            Select Case e.Item.Value
                Case "Save"
                    If Not Request.QueryString("ccid") Is Nothing Then
                        Dim oAlerts As New cAlerts(Session("ConnString"))
                        ccid = CInt(Request.QueryString("ccid"))
                        code = Request.QueryString("code")

                        If Me.TextBoxContactCode.Text = "" Then
                            Me.lblMSG.Text = "Contact Code Is required."
                            Exit Sub
                        End If
                        If code <> Me.TextBoxContactCode.Text Then
                            Dim duplicate As Boolean = job.CheckContactDuplicates(Request.QueryString("client"), Me.TextBoxContactCode.Text)
                            If duplicate = True Then
                                Me.lblMSG.Text = "Duplicate Contact Codes Not allowed."
                                Exit Sub
                            End If
                        End If
                        Dim save As Boolean
                        save = job.UpdateContact(ccid, Request.QueryString("client"), Me.TextBoxContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                                 Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                                 Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text,
                                                 Me.CheckBoxScheduleUser.Checked, Me.CheckBoxCPUser.Checked, Me.CheckBoxGetAlerts.Checked, Me.CheckBoxEmailRcpt.Checked,
                                                 Me.CheckBoxInactive.Checked, Me.CheckBoxCopyAddress.Checked, Me.TextBoxComment.Text, CInt(Me.RadComboBoxContactType.SelectedValue))

                        If ccid <> 0 Then
                            save = job.DeleteContactDP(ccid)
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDP.MasterTableView.Items
                                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                                If chk.Checked = True Then
                                    save = job.AddNewContactDP(ccid, gridDataItem.GetDataKeyValue("DIV_CODE"), gridDataItem.GetDataKeyValue("PRD_CODE"))
                                End If
                                'If gridDataItem.Selected = True Then

                                'End If
                            Next
                        End If

                        'If Request.QueryString("From") = "ca" Then
                        '    Dim cScript As String
                        '    cScript = "<script language='javascript'> window.opener.location=window.opener.location; </script>"
                        '    RegisterStartupScript("parentwindow", cScript)

                        '    Dim cScript2 As String
                        '    cScript2 = "<script>window.close();</script>"
                        '    RegisterStartupScript("page55", cScript2)
                        'Else
                        If Request.QueryString("From") = "ClientEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientEdit.aspx")

                        ElseIf Request.QueryString("From") = "DivisionEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_DivisionEdit.aspx")

                        ElseIf Request.QueryString("From") = "ProductEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_ProductEdit.aspx")

                        Else

                            Me.CloseThisWindowAndRefreshCaller("popContacts.aspx")

                        End If

                    Else

                        If Me.TextBoxContactCode.Text = "" Then
                            Me.lblMSG.Text = "Contact Code is required."
                            Exit Sub
                        End If
                        Dim save As Boolean
                        Dim cdpid As Integer = 0
                        Dim duplicate As Boolean = job.CheckContactDuplicates(Request.QueryString("client"), Me.TextBoxContactCode.Text)
                        If duplicate = True Then
                            Me.lblMSG.Text = "Duplicate Contact Codes not allowed."
                            Exit Sub
                        End If
                        cdpid = job.AddNewContact(Request.QueryString("client"), Me.TextBoxContactCode.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.txtMI.Text, Me.txtTitle.Text, Me.txtAddress1.Text,
                                             Me.txtAddress2.Text, Me.txtCity.Text, Me.txtCounty.Text, Me.txtState.Text, Me.txtCountry.Text, Me.txtZip.Text, Me.txtPhone.Text,
                                             Me.txtPhoneExt.Text, Me.txtFax.Text, Me.txtFaxExt.Text, Me.txtEmailAddress.Text, Me.txtCell.Text,
                                             Me.CheckBoxScheduleUser.Checked, Me.CheckBoxCPUser.Checked, Me.CheckBoxGetAlerts.Checked, Me.CheckBoxEmailRcpt.Checked,
                                             Me.CheckBoxInactive.Checked, Me.CheckBoxCopyAddress.Checked, Me.TextBoxComment.Text, CInt(Me.RadComboBoxContactType.SelectedValue))

                        If cdpid <> 0 Then
                            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridDP.MasterTableView.Items
                                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                                If chk.Checked = True Then
                                    save = job.AddNewContactDP(cdpid, gridDataItem.GetDataKeyValue("DIV_CODE"), gridDataItem.GetDataKeyValue("PRD_CODE"))
                                End If
                                'If gridDataItem.Selected = True Then

                                'End If
                            Next
                        End If

                        'If Request.QueryString("From") = "ca" Then
                        '    Dim cScript2 As String = "<script language='javascript'>window.opener.location=window.opener.location;window.close();</script>"
                        '    If Not Page.IsStartupScriptRegistered("Webvantage") Then
                        '        Page.RegisterStartupScript("Webvantage", cScript2)
                        '    End If

                        'Else
                        If Request.QueryString("From") = "ClientEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientEdit.aspx")

                        ElseIf Request.QueryString("From") = "DivisionEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_DivisionEdit.aspx")

                        ElseIf Request.QueryString("From") = "ProductEdit" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_ProductEdit.aspx")

                        ElseIf Request.QueryString("From") = "Maintenance_ClientContactManager" Then

                            Me.CloseThisWindowAndRefreshCaller("Maintenance_ClientContactManager.aspx")

                        Else

                            Me.CloseThisWindowAndRefreshCaller("popContacts.aspx")

                        End If

                        'End If
                    End If

            End Select



        Catch ex As Exception

        End Try
    End Sub
End Class