Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel
Imports System.IO
Imports System.Threading
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Partial Public Class jobspecs
    Inherits Webvantage.BaseChildPage

#Region " Private vars: "
    Private JobNum As Integer
    Private JobCompNum As Integer
    Private Client As String = ""
    Private Division As String = ""
    Private Product As String = ""
    Private JobSpecCPID As Integer = 0

    Private dtFormData As DataTable = New DataTable("FormData")
    Private dtUserData As DataTable = New DataTable("UserData")
    Private dtEdits As DataTable = New DataTable
    Private quantity As Integer = 0
    Private vendor As Integer = 0
    Private spectype As String
    Private versionNum As Integer
    Private revisionNum As Integer
    Private AddRow As Integer = 0
    Private DelRow As Integer = 0
    Private IsAgencyRequiredEmail As Boolean = False
    Private IsAutoEmailPromptOnNew As Boolean = False
    Private IsAutoEmailPromptOnUpdate As Boolean = False
    Private IsAutoEmailPromptOnRevision As Boolean = False
    Private IsClientGetsEmailOnNew As Boolean = False
    Private IsClientGetsEmailOnUpdate As Boolean = False
    Private IsClientGetsEmailOnRevision As Boolean = False
    Private count As Integer = 0
    Private bool As Boolean

#End Region

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Specifications)

        Me.JobNum = Request.QueryString("JobNum")
        Me.JobCompNum = Request.QueryString("JobCompNum")

        'Clean up old querystring names by letting clean qs class override
        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        If qs.JobNumber > 0 Then Me.JobNum = qs.JobNumber
        If qs.JobComponentNumber > 0 Then Me.JobCompNum = qs.JobComponentNumber
        'If qs.IsJobDashboard = True Then

        Me.RadToolBarJobSpecs.FindItemByText("Print/Send").Visible = False
        Me.RadToolBarJobSpecs.FindItemByValue("PrintSendSeparator").Visible = False

        'End If

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim js As New Job_Specs(Session("ConnString"))

            If Not Page.IsPostBack Then

                Me.lblApproved.Visible = False
                Me.hlApproved.Visible = False
                If Request.QueryString("new") = 1 Then
                    'Me.AddNewJobSpec()
                    Me.txtDesc.Focus()
                    Session("JSNewJobSpec") = 1
                End If
                If Request.QueryString("spec") = 1 Then
                    'Me.ShowMessage("New Version Created")
                End If
                loadVersions()
                loadRevisions()
                If Not Request.QueryString("Version") Is Nothing AndAlso Request.QueryString("Version") <> "" Then
                    Me.ddVersion.SelectedValue = Request.QueryString("Version")
                End If
                If Not Request.QueryString("Revision") Is Nothing AndAlso Request.QueryString("Revision") <> "" Then
                    Me.ddRevision.SelectedValue = Request.QueryString("Revision")
                End If
                Me.loadDescriptionReason()
                Session("VersionNum") = Me.ddVersion.SelectedValue
                Session("RevisionNum") = Me.ddRevision.SelectedValue
                Session("JSAddrowJS") = Request.QueryString("JSAddRow")
                Session("JSDelrowJS") = Request.QueryString("JSDelRow")
                Session("JSItemCode") = Request.QueryString("ItemCode")

            End If

            Select Case Me.EventArgument
                Case "Refresh"
                    loadRevisions()
                    Me.ddRevision.SelectedValue = Session("JobSpecsRevision")
                    Me.loadDescriptionReason()
                Case "JobSpecs"
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=1&spectype=" & Session("JSTemplateNew"))
                    Exit Sub
                Case "HidePopups"
                    Session("JSAddrowJS") = 0
                    Session("JSDelrowJS") = 0
                    Session("JSItemCode") = ""
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                    Exit Sub
                Case "JobSpecsCopy"
                    Me.ShowMessage("New Version Created")
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&spec=1")
                    Exit Sub
                Case "Cancel"
                    Session("NewJSNew") = 0
                    Me.CloseThisWindow()
            End Select

            Me.loadJobSpec()
            Me.SetContentPageData()
            Me.CheckApproval()
            Me.CheckQtyVendor()

            If Me.lblApproved.Visible = False Then
                Me.ButtonDeleteVersion.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this Job Spec Version?');")
                Me.ButtonDeleteRevision.Attributes.Add("onclick", "return confirm('Are you sure you want to delete this Job Spec Revision?');")
            Else
                Me.ButtonDeleteVersion.Attributes.Add("onclick", "")
                Me.ButtonDeleteRevision.Attributes.Add("onclick", "")
            End If
            If Me.lblApproved.Visible = True Then
                Me.ButtonDeleteRevision.Attributes.Add("onclick", "return confirm('This version has been approved and you are attempting to delete a revision, are you sure you want to continue?');")
            End If

            If Me.IsClientPortal = True Then
                Me.RadToolBarJobSpecs.Items(0).Visible = False
                Me.RadToolBarJobSpecs.Items(1).Visible = False
                Me.RadToolBarJobSpecs.Items(2).Visible = False
                Me.RadToolBarJobSpecs.Items(3).Visible = False
                Me.RadToolBarJobSpecs.Items(4).Visible = False
                Me.RadToolBarJobSpecs.Items(5).Visible = False
                Me.RadToolBarJobSpecs.Items(6).Visible = False
                Me.RadToolBarJobSpecs.Items(7).Visible = False
                Me.RadToolBarJobSpecs.Items(8).Visible = False
                Me.RadToolBarJobSpecs.Items(9).Visible = False
                Me.RadToolBarJobSpecs.Items(10).Visible = False
                Me.RadToolBarJobSpecs.Items(11).Visible = False
                Me.ButtonDeleteRevision.Visible = False
                Me.ButtonDeleteVersion.Visible = False
                Me.RadToolBarQty.Visible = False
                Me.RadToolBarVendor.Visible = False
                Me.RadToolBarVendor2.Visible = False
                Me.txtDesc.ReadOnly = True
            End If
            If Me.IsClientPortal = True Then

                Me.RadToolBarJobSpecs.FindItemByValue("SendAssignment").Visible = False

            End If

        Catch ex As Exception
        End Try
    End Sub

#Region " RadGrids: "

    Private Sub RadGridQuantity_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuantity.ItemDataBound
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                Dim quantity As System.Web.UI.WebControls.TextBox = CType(dataItem.FindControl("TxtQuantity"), TextBox)
                If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, CInt(Me.ddVersion.SelectedValue)) > CInt(Me.ddRevision.SelectedValue) Then
                    quantity.ReadOnly = True
                Else
                    quantity.ReadOnly = False
                End If
                If Me.IsClientPortal = True Then
                    quantity.ReadOnly = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQuantity_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuantity.NeedDataSource
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Me.RadGridQuantity.DataSource = js.GetJobSpecsQtyDataWithEst(JobNum, JobCompNum, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVendor.ItemCommand
        Try
            Select Case e.CommandName
                Case "EditRow"
                    Dim specid As String = e.CommandArgument
                    Dim StrURL As String
                    If CurrentQuerystring.IsJobDashboard = True Then
                        StrURL = "jobspecs_AddNew.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&Version=" & ddVersion.SelectedValue & "&Revision=" & ddRevision.SelectedValue & "&AddType=2&Row=Ven&Detail=yes&SpecID=" & specid & "&jd=1"
                    Else
                        StrURL = "jobspecs_AddNew.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&Version=" & ddVersion.SelectedValue & "&Revision=" & ddRevision.SelectedValue & "&AddType=2&Row=Ven&Detail=yes&SpecID=" & specid
                    End If
                    Me.OpenWindow("Vendor Detail", StrURL, 585, 700, False, True)
                Case "AdSize"
                    Dim ven As String = e.CommandArgument
                    Dim control As String = e.Item.FindControl("TxtAdSize").ClientID
                    Dim strURL As String = "LookUp_Quick.aspx?calledfrom=custom&control=" & control & "&type=adsize&vendor=" & ven
                    Me.OpenLookUp(strURL)
                Case "Status"
                    Dim control As String = e.Item.FindControl("TxtStatus").ClientID
                    Dim strURL As String = "LookUp_Quick.aspx?calledfrom=custom&control=" & control & "&type=status"
                    Me.OpenLookUp(strURL)
                Case "Region"
                    Dim control As String = e.Item.FindControl("TxtRegion").ClientID
                    Dim strURL As String = "LookUp_Quick.aspx?calledfrom=custom&control=" & control & "&type=region"
                    Me.OpenLookUp(strURL)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVendor.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

                'date textboxes:

                Dim rdp As Telerik.Web.UI.RadDatePicker
                Dim tb As System.Web.UI.WebControls.TextBox
                Dim ImgBtn As System.Web.UI.WebControls.ImageButton
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerClose_Date"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("Close_Date")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("Close_Date")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("Close_Date"), Date)
                            End If
                        End If
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerRun_Date"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("Run_Date")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("Run_Date")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("Run_Date"), Date)
                            End If
                        End If
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try
                Try
                    rdp = CType(dataItem.FindControl("RadDatePickerExt_Date"), Telerik.Web.UI.RadDatePicker)
                    If Not rdp Is Nothing Then
                        If IsDBNull(dataItem.DataItem("Ext_Date")) = False Then
                            If cGlobals.wvIsDate(dataItem.DataItem("Ext_Date")) = True Then
                                rdp.SelectedDate = CType(dataItem.DataItem("Ext_Date"), Date)
                            End If
                        End If
                        rdp.SharedCalendar = Me.RadCalendarShared
                    End If
                Catch ex As Exception
                End Try

                Try
                    If Me.IsClientPortal = True Then
                        tb = CType(dataItem.FindControl("TxtVendor"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtAdSize"), TextBox)
                        tb.ReadOnly = True
                        ImgBtn = CType(dataItem.FindControl("ImgBtnAdSize"), ImageButton)
                        ImgBtn.Visible = False
                        tb = CType(dataItem.FindControl("TxtSize_Desc"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtBleed_Size"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtTrim_Size"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtLive_Area"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtScreen"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtColor"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtStatus"), TextBox)
                        tb.ReadOnly = True
                        ImgBtn = CType(dataItem.FindControl("ImgBtnStatus"), ImageButton)
                        ImgBtn.Visible = False
                        ImgBtn = CType(dataItem.FindControl("ImgBtnRegion"), ImageButton)
                        ImgBtn.Visible = False
                        tb = CType(dataItem.FindControl("TxtRegion"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtDensity"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtFilm"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtShipping_Comments"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtSpecial_Instructions"), TextBox)
                        tb.ReadOnly = True
                        rdp = CType(dataItem.FindControl("RadDatePickerClose_Date"), Telerik.Web.UI.RadDatePicker)
                        rdp.DateInput.ReadOnly = True
                        rdp.Enabled = False
                        rdp = CType(dataItem.FindControl("RadDatePickerRun_Date"), Telerik.Web.UI.RadDatePicker)
                        rdp.DateInput.ReadOnly = True
                        rdp.Enabled = False
                        rdp = CType(dataItem.FindControl("RadDatePickerExt_Date"), Telerik.Web.UI.RadDatePicker)
                        rdp.DateInput.ReadOnly = True
                        rdp.Enabled = False
                    End If
                Catch ex As Exception
                End Try

                Dim AdSizeTextBox As TextBox = e.Item.FindControl("TxtAdSize")
                Dim SizeDescriptionTextBox As TextBox = e.Item.FindControl("TxtSize_Desc")

                AdSizeTextBox.Attributes.Add("onchange", String.Format("ClearDescription('{0}','{1}');", AdSizeTextBox.ClientID, SizeDescriptionTextBox.ClientID))
                AdSizeTextBox.Attributes.Add("onkeyup", String.Format("ClearDescription('{0}','{1}');", AdSizeTextBox.ClientID, SizeDescriptionTextBox.ClientID))

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendor.NeedDataSource
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dt As DataTable = js.GetJobSpecsVendorData(JobNum, JobCompNum, 1)
            If dt.Rows.Count > 0 Then
                Me.RadCalendarShared.Visible = True
            Else
                Me.RadCalendarShared.Visible = False
            End If
            Me.RadGridVendor.DataSource = dt
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor2_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridVendor2.ItemCommand
        Try
            Select Case e.CommandName
                Case "EditRow"
                    Dim specid As String = e.CommandArgument
                    Dim StrURL As String
                    If CurrentQuerystring.IsJobDashboard = True Then
                        StrURL = "jobspecs_AddNew.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&Version=" & ddVersion.SelectedValue & "&Revision=" & ddRevision.SelectedValue & "&AddType=2&Row=Ven&Detail=yes&SpecID=" & specid & "&jd=1"
                    Else
                        StrURL = "jobspecs_AddNew.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&Version=" & ddVersion.SelectedValue & "&Revision=" & ddRevision.SelectedValue & "&AddType=2&Row=Ven&Detail=yes&SpecID=" & specid
                    End If

                    Me.OpenWindow("Vendor Detail", StrURL, 585, 700, False, True)
                Case "AdSize"
                    Dim ven As String = e.CommandArgument
                    Dim control As String = e.Item.FindControl("TxtAdSize").ClientID
                    Dim strURL As String = "LookUp_Quick.aspx?calledfrom=custom&control=" & control & "&type=adsize&vendor=" & ven
                    Me.OpenLookUp(strURL)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridVendor2.ItemDataBound
        Try
            If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

                'date textboxes:

                Dim tb As System.Web.UI.WebControls.TextBox
                Dim ImgBtn As System.Web.UI.WebControls.ImageButton

                Try
                    If Me.IsClientPortal = True Then
                        tb = CType(dataItem.FindControl("TxtVendor"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtAdSize"), TextBox)
                        tb.ReadOnly = True
                        ImgBtn = CType(dataItem.FindControl("ImgBtnAdSize"), ImageButton)
                        ImgBtn.Visible = False
                        tb = CType(dataItem.FindControl("TxtSize_Desc"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtOutdoor_Company"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtLocation_of_Sign"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtOverall_Size"), TextBox)
                        tb.ReadOnly = True
                        tb = CType(dataItem.FindControl("TxtCopy_Area"), TextBox)
                        tb.ReadOnly = True
                    End If
                Catch ex As Exception
                End Try



            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridVendor2_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendor2.NeedDataSource
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Me.RadGridVendor2.DataSource = js.GetJobSpecsVendorData(JobNum, JobCompNum, 2)
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Controls: "

    Private Sub RadToolBarJobSpecs_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobSpecs.ButtonClick
        Dim js As New Job_Specs(Session("ConnString"))
        Select Case e.Item.Value
            Case "Save"
                Try
                    SaveChangedData()
                Catch ex As Exception
                End Try
            Case "NewVer"
                Me.AddNewVersion()
                Me.RadGridQuantity.Rebind()
                Me.RadGridVendor.Rebind()
                Me.RadGridVendor2.Rebind()
            Case "CopyVer"
                Me.CopyNewVersion()
                Me.RadGridQuantity.Rebind()
                Me.RadGridVendor.Rebind()
                Me.RadGridVendor2.Rebind()
            Case "CopyRev"
                Me.CopyNewRevision()
                Me.RadGridQuantity.Rebind()
                Me.RadGridVendor.Rebind()
                Me.RadGridVendor2.Rebind()
            Case "AddRow"
                Try
                    Me.SaveData()
                    Dim dr As SqlDataReader
                    Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                    If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                        Me.ShowMessage("You can only add rows to the max revision.")
                        Exit Sub
                    End If
                    dr = js.GetJobSpecQtyVendorTabs(type)
                    Do While dr.Read
                        If dr.GetInt16(1) = 1 And dr.GetInt16(2) <> 1 And dr.GetInt16(2) <> 2 Then
                            Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Qty"
                            Me.OpenWindow("Add New Row", StrURL, 225, 700, , True)
                        ElseIf dr.GetInt16(1) <> 1 And (dr.GetInt16(2) = 1 Or dr.GetInt16(2) = 2) Then
                            Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Ven"
                            Me.OpenWindow("Add New Row", StrURL, 575, 700, , True)
                        Else
                            Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2"
                            Me.OpenWindow("Add New Row", StrURL, 625, 700, , True)
                        End If
                    Loop
                    dr.Close()
                Catch ex As Exception
                    Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
                End Try

                '' ''Case "Print"
                '' ''    Session("JSDescription") = Me.txtDesc.Text
                '' ''    Session("JSReason") = Me.txtReason.Text
                '' ''    Session("JSReportTitle") = ""

                '' ''    Me.OpenWindow("", "JobSpecs_Print.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&version=" & Me.ddVersion.SelectedValue & "&revision=" & Me.ddRevision.SelectedValue)

            Case "Print"
                Me.SaveData()
                Session("JSDescription") = Me.txtDesc.Text
                Session("JSReason") = Me.txtReason.Text
                Session("JSReportTitle") = ""

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobSpecs_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then qs.VersionID = CType(Me.ddVersion.SelectedValue, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.RevisionID = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Print)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendAlert"
                Me.SaveData()
                Session("JSDescription") = Me.txtDesc.Text
                Session("JSReason") = Me.txtReason.Text
                Session("JSReportTitle") = ""

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobSpecs_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then qs.VersionID = CType(Me.ddVersion.SelectedValue, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.RevisionID = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendAssignment"
                Me.SaveData()
                Session("JSDescription") = Me.txtDesc.Text
                Session("JSReason") = Me.txtReason.Text
                Session("JSReportTitle") = ""

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobSpecs_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then qs.VersionID = CType(Me.ddVersion.SelectedValue, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.RevisionID = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "SendEmail"
                Me.SaveData()
                Session("JSDescription") = Me.txtDesc.Text
                Session("JSReason") = Me.txtReason.Text
                Session("JSReportTitle") = ""

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobSpecs_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then qs.VersionID = CType(Me.ddVersion.SelectedValue, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.RevisionID = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendEmail)

                'Me.OpenWindow(qs)
                Me.OpenPrintSendSilently(qs)

            Case "PrintSendOptions"
                Me.SaveData()
                Session("JSDescription") = Me.txtDesc.Text
                Session("JSReason") = Me.txtReason.Text
                Session("JSReportTitle") = ""

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "JobSpecs_Print.aspx"
                qs.JobNumber = Me.JobNum
                qs.JobComponentNumber = Me.JobCompNum
                If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then qs.VersionID = CType(Me.ddVersion.SelectedValue, Integer)
                If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then qs.RevisionID = CType(Me.ddRevision.SelectedValue, Integer)

                qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.Options)

                Me.OpenWindow(qs)



            Case "Approve"
                Me.SaveData()
                Dim dr As SqlDataReader
                If e.Item.Text = "Approve" Then
                    dr = js.GetJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            Me.ShowMessage("Warning, approval of version " & dr.GetInt32(0).ToString() & " will be deleted and version " & Me.ddVersion.SelectedValue & " will be approved.")
                        Loop
                        dr.Close()
                    End If
                    Dim StrURL As String = "JobSpecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&AddType=5"
                    Me.OpenWindow("Approve Version", StrURL, 320, 500)
                End If
                If e.Item.Text = "Unapprove" Then
                    Dim delete As Boolean
                    delete = js.DeleteJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
                    If delete = True Then
                        Me.lblApproved.Visible = False
                        Me.hlApproved.Visible = False
                        e.Item.Text = "Approve"
                        Me.ShowMessage("Approval Deleted")
                        e.Item.ToolTip = "Approve"
                    End If
                End If
            Case "Refresh"
                MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                Exit Sub
            Case "DelRow"
                'Dim rowCount As Integer = Me.QtyVendorCheckedRows(Page)
                'If rowCount <> 0 Then
                '    Try
                '        Dim js As New Job_Specs(Session("ConnString"))
                '        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                '            Me.ShowMessage("You can only delete rows from the max revision.")
                '            Exit Sub
                '        End If
                '        Me.DeleteRowQtyVendor(Page)
                '        Me.loadJobSpec()
                '        Me.loadDescriptionReason()
                '    Catch ex As Exception
                '        Me.ShowMessage("Error! " & ex.Message.ToString())
                '    End Try
                'Else
                '    Try
                '        Me.ShowMessage("No rows were selected for deletion.")
                '    Catch ex As Exception
                '        Me.ShowMessage("Error! " & ex.Message.ToString())
                '    End Try
                'End If
                'count = 0

                Dim delete As Boolean
                Dim chk As CheckBox
                Dim DelString As String = ""
                Dim countAssignment As Integer = 0
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuantity.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        If IsNumeric(gridDataItem.GetDataKeyValue("SeqNum")) Then
                            delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 1, 0, 0, CInt(gridDataItem.GetDataKeyValue("SeqNum")))
                        End If
                    End If
                    count += 1
                Next
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendor.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 1, CInt(gridDataItem.GetDataKeyValue("SPEC_ID")), 0)
                    End If
                    count += 1
                Next
                For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendor2.MasterTableView.Items
                    chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                    If chk.Checked = True Then
                        delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 2, CInt(gridDataItem.GetDataKeyValue("SPEC_ID")), 0)
                    End If
                    count += 1
                Next

                If count = 0 Then
                    Try
                        Me.ShowMessage("No rows were selected for deletion.")
                    Catch ex As Exception
                        Me.ShowMessage("Error! " & ex.Message.ToString())
                    End Try
                End If

                Me.RadGridQuantity.Rebind()
                Me.RadGridVendor.Rebind()
                Me.RadGridVendor2.Rebind()
                Me.loadJobSpec()
                Me.loadDescriptionReason()

        End Select

        Me.SetContentPageData()

    End Sub

    Private Sub ddVersion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddVersion.SelectedIndexChanged
        Try
            If Me.ddVersion.SelectedValue = "NV" Then
                Me.AddNewVersion()
            ElseIf Me.ddVersion.SelectedValue = "CV" Then
                Me.CopyNewVersion()
            Else
                Me.loadRevisions()
                Me.loadDescriptionReason()
                Me.loadJobSpec()
                Session("VersionNum") = Me.ddVersion.SelectedValue
                Session("RevisionNum") = Me.ddRevision.SelectedValue
                'MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
            End If
            Me.RadGridQuantity.Rebind()
            Me.RadGridVendor.Rebind()
            Me.RadGridVendor2.Rebind()
            Me.SetContentPageData()
        Catch ex As Exception
            Me.ShowMessage("Error ddVersions!<BR />" & ex.Message.ToString())
        End Try

    End Sub

    Private Sub ddRevision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddRevision.SelectedIndexChanged
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            If Me.ddRevision.SelectedValue = "CR" Then
                Me.CopyNewRevision()
            Else
                Me.loadDescriptionReason()
                Me.loadJobSpec()
                'MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
            End If
            Me.RadGridQuantity.Rebind()
            Me.RadGridVendor.Rebind()
            Me.RadGridVendor2.Rebind()
            Me.SetContentPageData()
        Catch ex As Exception
            Me.ShowMessage("Error ddVersions!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub ButtonDeleteVersion_Click(sender As Object, e As EventArgs) Handles ButtonDeleteVersion.Click
        Try
            If Me.hlApproved.Visible = True Then
                Me.ShowMessage("This version has been approved. You must delete the approval before the version can be deleted.")
                Exit Sub
            End If
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim dr2 As SqlDataReader
            Dim strURL As String
            Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            dr2 = js.GetJobSpecQtyVendorTabs(type)
            Dim delete As Boolean = js.DeleteJobSpec(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, quantity, 1, 0)
            If delete = True Then
                dr = js.GetJobSpecData(Me.JobNum, Me.JobCompNum, -1, -1)
                If dr.HasRows = True Then
                    Me.loadVersions()
                    Me.loadRevisions()
                    Me.loadJobSpec()
                    Me.loadDescriptionReason()
                    Me.CheckApproval()
                    Me.ShowMessage("Delete Successful")
                    Session("VersionNum") = Me.ddVersion.SelectedValue
                    Session("RevisionNum") = Me.ddRevision.SelectedValue
                Else
                    Do While dr2.Read
                        If dr2.GetInt16(2) = 1 Then
                            delete = js.DeleteJobSpecVenRows(Me.JobNum, Me.JobCompNum, 1)
                        End If
                        If dr2.GetInt16(2) = 2 Then
                            delete = js.DeleteJobSpecVenRows(Me.JobNum, Me.JobCompNum, 2)
                        End If
                    Loop
                    dr2.Close()

                    strURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&AddType=4"

                    Me.OpenWindow("Select Template", strURL, 325, 625, False, True)
                    Me.CloseThisWindow()
                End If
            Else
                Me.ShowMessage("Delete Failed")
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub ButtonDeleteRevision_Click(sender As Object, e As EventArgs) Handles ButtonDeleteRevision.Click
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                Me.ShowMessage("You can only delete the max revision number.")
                Exit Sub
            End If
            If Me.ddRevision.SelectedValue = "0" Then
                Me.ShowMessage("There is no revision to delete.")
                Exit Sub
            End If
            Dim delete As Boolean = js.DeleteJobSpec(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, quantity, 0, 1)
            If delete = True Then
                Me.loadRevisions()
                Me.ddRevision.SelectedValue = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue)
                Me.loadJobSpec()
                Me.loadDescriptionReason()
                Me.CheckApproval()
                Me.ShowMessage("Delete Successful")
                Session("VersionNum") = Me.ddVersion.SelectedValue
                Session("RevisionNum") = Me.ddRevision.SelectedValue
            Else
                Me.ShowMessage("Delete Failed")
            End If
        Catch ex As Exception
            Me.ShowMessage(ex.Message)
        End Try
    End Sub

    Private Sub btnDelAction(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        If e.CommandName = "DelRowGrid" Then
            Try
                Try
                    Dim js As New Job_Specs(Session("ConnString"))
                    If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                        Me.ShowMessage("You can only delete rows from the max revision.")
                        Exit Sub
                    End If
                    If Me.QtyVendorCheckedRows(Page) = 0 Then
                        Try
                            Me.ShowMessage("No rows were selected for deletion.")
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    Else
                        Try
                            If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                                Me.ShowMessage("You can only delete rows from the max revision.")
                                Exit Sub
                            End If
                            Me.DeleteRowQtyVendor(Page)
                            Me.loadJobSpec()
                            Me.loadDescriptionReason()
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error DeleteRows!<BR />" & ex.Message.ToString())
                End Try
            Catch ex As Exception
                Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
            End Try
        End If
    End Sub

    Public Sub btnAddAction(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.CommandEventArgs)
        Dim save As Boolean = Me.SaveData()
        If save = False Then
            Exit Sub
        End If
        Dim StrURL As String = ""
        If e.CommandName = "AddRowGridQty" Then
            Try
                Dim dr As SqlDataReader
                Dim js As New Job_Specs(Session("ConnString"))
                Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                    Me.ShowMessage("You can only add rows to the max revision.")
                    Exit Sub
                End If
                StrURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Qty"
                Me.OpenWindow("Add New Row", StrURL, 250, 500, , True)
            Catch ex As Exception
                Me.ShowMessage("Error AddRows!" & ex.Message.ToString())
            End Try
        End If
        If e.CommandName = "AddRowGridVen" Then
            Try
                Dim dr As SqlDataReader
                Dim js As New Job_Specs(Session("ConnString"))
                Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                    Me.ShowMessage("You can only add rows to the max revision.")
                    Exit Sub
                End If
                StrURL = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Ven"
                Me.OpenWindow("Add New Row", StrURL, 585, 700, , True)
            Catch ex As Exception
                Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
            End Try
        End If
    End Sub

    Private Sub hlApproved_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles hlApproved.Click
        Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&AddType=6"
        Me.OpenWindow("Approval Data", StrURL, 315, 500, False, True)
    End Sub

    Private Sub viewDetail(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs)
        Try
            If e.CommandName = "Detail" Then
                Dim specid As String = e.Item.DataItem("SPEC_ID").ToString
                Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&Version=" & ddVersion.SelectedValue & "&Revision=" & ddRevision.SelectedValue & "&AddType=2&Row=Ven&Detail=yes&SpecID=" & specid
                Me.OpenWindow("Vendor Detail", StrURL, 585, 700, False, True)
            End If
            Dim ven As String = e.Item.DataItem("Vendor").ToString
            Dim control As String = e.Item.FindControl("txtAdSize").ClientID
            If e.CommandName = "AdSize" Then
                Dim strURL As String = "LookUp_Quick.aspx?calledfrom=custom&control=" & control & "&type=adsize&vendor=" & ven
                Me.OpenLookUp(strURL)
            End If
        Catch ex As Exception
            'Me.ShowMessage("Error View!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub RadToolBarQty_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarQty.ButtonClick
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Select Case e.Item.Value
                Case "AddRow"
                    Try
                        Me.SaveData()
                        Dim dr As SqlDataReader
                        Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only add rows to the max revision.")
                            Exit Sub
                        End If

                        Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Qty"
                        Me.OpenWindow("Add New Row", StrURL, 225, 535, , True)

                    Catch ex As Exception
                        Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
                    End Try
                Case "DelRow"
                    Try
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only delete rows from the max revision.")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Error! " & ex.Message.ToString())
                    End Try

                    Dim delete As Boolean
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim countAssignment As Integer = 0
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuantity.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            If IsNumeric(gridDataItem.GetDataKeyValue("SeqNum")) Then
                                delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 1, 0, 0, CInt(gridDataItem.GetDataKeyValue("SeqNum")))
                            End If
                        End If
                        count += 1
                    Next

                    If count = 0 Then
                        Try
                            Me.ShowMessage("No rows were selected for deletion.")
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    End If

                    Me.RadGridQuantity.Rebind()
                    Me.loadJobSpec()
                    Me.loadDescriptionReason()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolBarVendor_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarVendor.ButtonClick
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Select Case e.Item.Value
                Case "AddRow"
                    Try
                        Me.SaveData()
                        Dim dr As SqlDataReader
                        Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only add rows to the max revision.")
                            Exit Sub
                        End If

                        Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Ven"
                        Me.OpenWindow("Add New Row", StrURL, 575, 700, , True)

                    Catch ex As Exception
                        Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
                    End Try

                Case "DelRow"
                    Try
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only delete rows from the max revision.")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Error! " & ex.Message.ToString())
                    End Try

                    Dim delete As Boolean
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim countAssignment As Integer = 0

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendor.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 1, CInt(gridDataItem.GetDataKeyValue("SPEC_ID")), 0)
                        End If
                        count += 1
                    Next

                    If count = 0 Then
                        Try
                            Me.ShowMessage("No rows were selected for deletion.")
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    End If

                    Me.RadGridVendor.Rebind()
                    Me.loadJobSpec()
                    Me.loadDescriptionReason()
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadToolBarVendor2_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarVendor2.ButtonClick
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Select Case e.Item.Value
                Case "AddRow"
                    Try
                        Me.SaveData()
                        Dim dr As SqlDataReader
                        Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only add rows to the max revision.")
                            Exit Sub
                        End If

                        Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & Me.ddVersion.SelectedValue & "&Revision=" & Me.ddRevision.SelectedValue & "&AddType=2&Row=Ven"
                        Me.OpenWindow("Add New Row", StrURL, 575, 700, , True)

                    Catch ex As Exception
                        Me.ShowMessage("Error AddRows!<BR />" & ex.Message.ToString())
                    End Try

                Case "DelRow"
                    Try
                        If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                            Me.ShowMessage("You can only delete rows from the max revision.")
                            Exit Sub
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Error! " & ex.Message.ToString())
                    End Try

                    Dim delete As Boolean
                    Dim chk As CheckBox
                    Dim DelString As String = ""
                    Dim countAssignment As Integer = 0

                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendor2.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 2, CInt(gridDataItem.GetDataKeyValue("SPEC_ID")), 0)
                        End If
                        count += 1
                    Next

                    If count = 0 Then
                        Try
                            Me.ShowMessage("No rows were selected for deletion.")
                        Catch ex As Exception
                            Me.ShowMessage("Error! " & ex.Message.ToString())
                        End Try
                    End If

                    Me.RadGridVendor2.Rebind()
                    Me.loadJobSpec()
                    Me.loadDescriptionReason()
            End Select
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " SubRoutines "

    'Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
    '    Try
    '        Dim tab As Integer = 0
    '        Dim i As Integer
    '        Dim dr As SqlDataReader
    '        Dim ds As DataSet
    '        Dim type As String

    '        Try
    '            If IsNumeric(Request.QueryString("Tab")) = True Then
    '                tab = CInt(Request.QueryString("Tab"))
    '            Else
    '                tab = 0
    '            End If
    '        Catch ex As Exception
    '            Me.ShowMessage("err getting tab id from qs")
    '        End Try

    '        Dim js As New Job_Specs(Session("ConnString"))
    '        type = js.GetJobSpecType(67, 1)
    '        ds = js.GetJobSpecCategories(type)
    '        tab = CInt(ds.Tables(0).Rows(0)("CATEGORY_ID").ToString())
    '        RadTabStrip.Tabs.Clear()
    '        For i = 0 To ds.Tables(0).Rows.Count - 1
    '            Dim newTab As New Telerik.Web.UI.RadTab
    '            newTab.Text = ds.Tables(0).Rows(i)("CATEGORY_DESC")
    '            newTab.Value = ds.Tables(0).Rows(i)("CATEGORY_ID")
    '            newTab.NavigateUrl = "jobspecs.aspx?tab=" & ds.Tables(0).Rows(i)("CATEGORY_ID").ToString
    '            Me.RadTabStrip.Tabs.Add(newTab)
    '        Next
    '        dr = js.GetJobSpecQtyVendorTabs(type)
    '        If dr.HasRows = True Then
    '            Do While dr.Read()
    '                If dr.GetInt16(1) = 1 Then
    '                    Dim newTabQ As New Telerik.Web.UI.RadTab
    '                    newTabQ.Text = "Quantity"
    '                    newTabQ.Value = i
    '                    newTabQ.NavigateUrl = "jobspecs.aspx?tab=" & i
    '                    Me.RadTabStrip.Tabs.Add(newTabQ)
    '                End If
    '                If dr.GetInt16(2) <> 0 Then
    '                    Dim newTabV As New Telerik.Web.UI.RadTab
    '                    newTabV.Text = "Vendor"
    '                    newTabV.Value = i + 1
    '                    newTabV.NavigateUrl = "jobspecs.aspx?tab=" & i + 1
    '                    Me.RadTabStrip.Tabs.Add(newTabV)
    '                End If
    '            Loop
    '        End If

    '        Dim selectTab As Telerik.Web.UI.RadTab = Me.RadTabStrip.FindTabByValue(tab)
    '        Session("JSTabCategory") = tab
    '        selectTab.Selected = True
    '        dr.Close()
    '    Catch ex As Exception
    '        Me.ShowMessage("err loading tabs " & ex.Message.ToString())
    '    End Try
    'End Sub
    Private Sub LoadButtons(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try
            Dim button As Integer = 0
            Dim i As Integer
            Dim dr As SqlDataReader
            Dim ds As DataSet
            Dim type As String = ""

            Dim js As New Job_Specs(Session("ConnString"))
            type = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            If type = "" Then
                type = Request.QueryString("spectype")
            End If
            Session("JSType") = type
            ds = js.GetJobSpecCategories(type)
            button = CInt(ds.Tables(0).Rows(0)("CATEGORY_ID").ToString())
            'Me.RadToolbar1.Items.Clear()
            'Dim newSeparator As New Telerik.Web.UI.RadToolbarSeparator
            'newSeparator.Width = 20
            'Me.RadToolbar1.Items.Add(newSeparator)
            For i = 0 To ds.Tables(0).Rows.Count - 1
                Dim newButton As New Telerik.Web.UI.RadToolBarButton
                newButton.Text = ds.Tables(0).Rows(i)("CATEGORY_DESC")
                newButton.CommandName = ds.Tables(0).Rows(i)("CATEGORY_DESC")
                newButton.CommandArgument = ds.Tables(0).Rows(i)("CATEGORY_ID").ToString
                'Me.RadToolbar1.Items.Add(newButton)
                'newSeparator = New Telerik.Web.UI.RadToolbarSeparator
                'newSeparator.Width = 20
                'Me.RadToolbar1.Items.Add(newSeparator)
            Next
            dr = js.GetJobSpecQtyVendorTabs(type)
            If dr.HasRows = True Then
                Do While dr.Read()
                    If dr.GetInt16(1) = 1 Then
                        Dim newButtonQ As New Telerik.Web.UI.RadToolBarButton
                        newButtonQ.Text = "Quantity"
                        newButtonQ.CommandName = "Quantity"
                        newButtonQ.CommandArgument = "Qty"
                        quantity = 1
                    End If
                    If dr.GetInt16(2) <> 0 Then
                        Dim newButtonV As New Telerik.Web.UI.RadToolBarButton
                        newButtonV.Text = "Vendor"
                        newButtonV.CommandName = "Vendor"
                        newButtonV.CommandArgument = "Ven"
                        vendor = 1
                    End If
                Loop
            End If
            If Session("JSTabCategory") = Nothing Then
                Session("JSTabCategory") = button
                Me.RadToolBarJobSpecs.FindItemByValue("AddRow").Enabled = False
                Me.RadToolBarJobSpecs.FindItemByValue("DelRow").Enabled = False
            End If


            dr.Close()
        Catch ex As Exception
            Me.ShowMessage("err loading buttons " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub loadVersions()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim oDropDowns As Job_Specs = New Job_Specs(Session("ConnString"))
            Me.ddVersion.DataSource = oDropDowns.GetJobSpecVersions(Me.JobNum, Me.JobCompNum)
            Me.ddVersion.DataTextField = "SPEC_VER"
            Me.ddVersion.DataValueField = "SPEC_VER"
            Me.ddVersion.DataBind()
            'Me.ddVersion.Items.Insert(0, none)
            If Me.IsClientPortal = False Then
                Me.ddVersion.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Copy", "CV"))
                Me.ddVersion.Items.Add(New Telerik.Web.UI.RadComboBoxItem("New", "NV"))
            End If

            Dim dr As SqlDataReader
            dr = js.GetJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
            If dr.HasRows = True Then
                dr.Read()
                Me.ddVersion.SelectedValue = dr.GetInt32(0)
            End If
            dr.Close()
        Catch ex As Exception
            Me.ShowMessage("Error ddVersions!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub loadRevisions()
        Try
            If IsNumeric(Me.ddVersion.SelectedValue) = True Then
                Dim oDropDowns As Job_Specs = New Job_Specs(Session("ConnString"))
                Me.ddRevision.DataSource = oDropDowns.GetJobSpecRevisions(Me.JobNum, Me.JobCompNum, CInt(Me.ddVersion.SelectedValue))
                Me.ddRevision.DataTextField = "SPEC_REV"
                Me.ddRevision.DataValueField = "SPEC_REV"
                Me.ddRevision.DataBind()
            End If
            If Me.IsClientPortal = False Then
                Me.ddRevision.Items.Add(New Telerik.Web.UI.RadComboBoxItem("Copy", "CR"))
            End If
            If IsNumeric(Me.ddVersion.SelectedValue) = True Then
                Dim js As New Job_Specs(Session("ConnString"))
                Me.ddRevision.SelectedValue = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue)
            End If
        Catch ex As Exception
            Me.ShowMessage("Error ddRevisions!<BR />" & ex.Message.ToString())
        Finally

        End Try
    End Sub

    Private Sub loadDescriptionReason()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            If Me.ddRevision.SelectedValue <> "CR" And Me.ddVersion.SelectedValue <> "CV" And Me.ddVersion.SelectedValue <> "NV" Then
                dr = js.GetJobSpecData(Me.JobNum, Me.JobCompNum, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                If dr.HasRows = True Then
                    Do While dr.Read
                        If dr.GetString(9) <> "0" Then
                            Me.txtDesc.Text = dr.GetString(9)
                            Session("JobSpecDescription") = Me.txtDesc.Text
                            If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                                Me.txtDesc.ReadOnly = True
                            Else
                                Me.txtDesc.ReadOnly = False
                            End If
                        Else
                            Me.txtDesc.Text = ""
                        End If
                        If dr.GetString(4) <> "0" Then
                            Me.txtReason.Text = dr.GetString(4)
                        Else
                            Me.txtReason.Text = ""
                        End If
                    Loop
                End If
                dr.Close()
            End If
        Catch ex As Exception
            Me.ShowMessage("err loading desc " & ex.Message.ToString())
        End Try
    End Sub

    ''TODO: FIX SPELLCHECKER!
    'Private Function WriteSpellScript(ByVal source_string As String) As String
    '    Dim sb As New System.Text.StringBuilder

    '    'With sb
    '    '    .Append("<script type=""text/javascript"">" & Environment.NewLine)
    '    '    .Append("/*<![CDATA[*/" & Environment.NewLine)

    '    '    .Append("function MultipleTextSource(sources)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("this.sources = sources;" & Environment.NewLine)
    '    '    .Append("" & Environment.NewLine)
    '    '    .Append("this.GetText = function()" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("var texts = [];" & Environment.NewLine)
    '    '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("texts[texts.length] = this.sources[i].getText();" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("return texts.join(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)
    '    '    .Append("this.SetText = function(text)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("var texts = text.split(""<controlSeparator><br/></controlSeparator>"");" & Environment.NewLine)
    '    '    .Append("for (var i = 0; i < this.sources.length; i++)" & Environment.NewLine)
    '    '    .Append("{" & Environment.NewLine)
    '    '    .Append("this.sources[i].setText(texts[i]);" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)

    '    '    .Append("function startSpell()" & Environment.NewLine)
    '    '    .Append("{    " & Environment.NewLine)
    '    '    .Append("var sources = " & Environment.NewLine)
    '    '    .Append("[" & Environment.NewLine)
    '    '    .Append(source_string)
    '    '    .Append("];" & Environment.NewLine)
    '    '    .Append(Environment.NewLine)
    '    '    .Append("var spell = GetRadSpell('" & spell1.ClientID & "');" & Environment.NewLine)
    '    '    .Append("spell.SetTextSource(new MultipleTextSource(sources));" & Environment.NewLine)
    '    '    .Append("spell.StartSpellCheck();" & Environment.NewLine)
    '    '    .Append("}" & Environment.NewLine)
    '    '    .Append("/*]]>*/" & Environment.NewLine)
    '    '    .Append("</script>" & Environment.NewLine)
    '    'End With
    '    Return sb.ToString()
    'End Function

    'Private Sub startSpell()
    '    Dim textboxCount, idx As Integer
    '    Dim textboxID As String
    '    Dim spelID As String
    '    Dim sb As New System.Text.StringBuilder

    '    Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
    '    With sbScript
    '        .Append("<script type=""text/javascript"">startSpell();</script>")
    '    End With
    '    Try
    '        If Not Page.IsStartupScriptRegistered("CBSpell") Then
    '            Dim str As String = sbScript.ToString
    '            Page.RegisterStartupScript("CBSpell", str)
    '        End If
    '    Catch ex As Exception
    '        Me.ShowMessage("Error! " & ex.Message.ToString())
    '    End Try

    'End Sub

    Private Sub loadJobSpec()
        Try
            Dim SpellCheckObjects As String = ""
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim ds As DataSet
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            Session("JSType") = type
            dr = js.GetJobSpecQtyVendorTabs(type)
            If dr.HasRows = True Then
                Do While dr.Read()
                    If dr.GetInt16(1) = 1 Then
                        quantity = 1
                    End If
                Loop
            End If
            If Me.ddRevision.SelectedValue <> "CR" And Me.ddVersion.SelectedValue <> "CV" And Me.ddVersion.SelectedValue <> "NV" Then
                dtFormData = js.BuildJobSpecsForm(Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, Me.PlaceHolderMain, Me.JobNum, Me.JobCompNum, "", type, "", SpellCheckObjects, Me.IsClientPortal)
                dr = js.GetJobSpecData(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue)
                If dr.HasRows = True Then
                    dr.Read()
                    Me.PageTitle = "Specifications - " & dr.GetString(148) & " for Job/Comp " & Me.JobNum.ToString.PadLeft(6, "0") & "/" & Me.JobCompNum.ToString.PadLeft(3, "0")
                    Me.LabelTemplate.Text = dr.GetString(8) & " - " & dr.GetString(148)
                End If
                dr.Close()

                ds = js.GetJobSpecQtyVendorTabsDataSet(type)
                If ds.Tables(0).Rows(0)("USE_QTY").ToString() = "1" Then
                    Me.CollapsablePanelQty.Visible = True
                End If
                If ds.Tables(0).Rows(0)("USE_VENDOR_TAB").ToString() = "1" Then
                    Me.CollapsablePanelVendor.Visible = True
                End If
                If ds.Tables(0).Rows(0)("USE_VENDOR_TAB").ToString() = "2" Then
                    Me.CollapsablePanelVendor2.Visible = True
                End If

            End If
        Catch ex As Exception
            Me.ShowMessage("err loading specs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub AddNewVersion()
        Try
            Dim dt As DataTable
            Dim js As New Job_Specs(Session("ConnString"))
            Dim max As Integer
            Dim maxVer As Integer
            Dim save As Boolean
            Dim saveqty As Boolean
            maxVer = js.GetJobSpecMaxVersion(Me.JobNum, Me.JobCompNum)
            max = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, maxVer)
            save = js.AddJobSpecCopy(Me.JobNum, Me.JobCompNum, maxVer, max, 0, 0, 0, maxVer + 1, 1, "", "", Session("UserCode"))
            If save = True Then
                Me.loadVersions()
                Me.ddVersion.SelectedValue = maxVer + 1
                Me.loadRevisions()
                Me.loadJobSpec()
                Me.loadDescriptionReason()
                Me.CheckApproval()
                Me.ShowMessage("New Version Created")
                Me.txtDesc.Text = ""
                Me.txtReason.Text = ""
                Session("JSNewVersion") = "1"
                Session("JSNewRevision") = ""
                'Session("JSMaxVersionNext") = maxVer + 1
            Else
                Me.ShowMessage("Creation Failed")
            End If
        Catch ex As Exception
            Me.ShowMessage("Error AddNewVersions!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CopyNewVersion()
        Try
            Dim dt As DataTable
            Dim js As New Job_Specs(Session("ConnString"))
            Dim max As Integer
            Dim maxVer As Integer
            Dim save As Boolean
            Dim saveqty As Boolean

            max = js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, CInt(Session("VersionNum")))
            maxVer = js.GetJobSpecMaxVersion(Me.JobNum, Me.JobCompNum)
            save = js.AddJobSpecCopy(Me.JobNum, Me.JobCompNum, CInt(Session("VersionNum")), max, 0, 0, 1, maxVer + 1, 0, "", "", Session("UserCode"))
            If quantity = 1 Then
                dt = js.GetJobSpecsQtyDataRows(Me.JobNum, Me.JobCompNum, CInt(Session("VersionNum")), max)
                Dim i As Integer
                If dt.Rows.Count > 0 Then
                    For i = 0 To dt.Rows.Count - 1
                        saveqty = js.AddJobSpecCopyQty(CInt(dt.Rows(i).Item(0).ToString()), CInt(dt.Rows(i).Item(1).ToString()), CInt(dt.Rows(i).Item(2).ToString()), CInt(dt.Rows(i).Item(3).ToString()), CInt(dt.Rows(i).Item(4).ToString()), CInt(dt.Rows(i).Item(5).ToString()), 0, 0, 1, maxVer + 1, 0)
                    Next
                    If saveqty = False Then
                        Me.ShowMessage("Creation Failed at Qty.")
                    End If
                End If
            End If
            If save = True Then
                Me.loadVersions()
                Me.ddVersion.SelectedValue = maxVer + 1
                Me.loadRevisions()
                Me.loadJobSpec()
                Me.loadDescriptionReason()
                Me.CheckApproval()
                Me.ShowMessage("New Version Created")
                Session("JSNewVersion") = "1"
                Session("JSNewRevision") = ""
            Else
                Me.ShowMessage("Copy Failed")
            End If
        Catch ex As Exception
            Me.ShowMessage("Error CopyNewVersions!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CopyNewRevision()
        Try
            Session("VersionNum") = Me.ddVersion.SelectedValue
            Dim StrURL As String = "jobspecs_AddNew.aspx?JobNum=" & Me.JobNum & "&JobCompNum=" & Me.JobCompNum & "&Version=" & CInt(Session("VersionNum")) & "&Quantity=" & quantity & "&AddType=1"
            Me.OpenWindow("Create New Spec Revision", StrURL, 315, 550, , True)
        Catch ex As Exception
            Me.ShowMessage("Error CopyNewRevisions!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub DeleteRowQtyVendor(ByVal pg As System.Web.UI.Control)
        Try
            Dim rad As New RadGrid
            Dim z As Integer
            Dim cb As New CheckBox
            Dim lab As New System.Web.UI.WebControls.Label
            Dim txtbox As New System.Web.UI.WebControls.TextBox
            Dim js As New Job_Specs(Session("ConnString"))
            Dim delete As Boolean
            Dim dr As SqlDataReader
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            For Each ctrl As System.Web.UI.Control In pg.Controls
                Dim test As String = ctrl.GetType.ToString
                If ctrl.GetType.ToString() = "Telerik.Web.UI.RadGrid" Then
                    rad = CType(ctrl, RadGrid)
                    If InStr(ctrl.ClientID, "Quantity") > 0 Then
                        Dim strQty As String = "Deleted Quantity Rows:" & "<br />"
                        For z = 0 To rad.Items.Count - 1
                            cb = rad.Items(z).FindControl("cbDelete")
                            If cb.Checked = True Then
                                lab = rad.Items(z).FindControl("lblSeqNum")
                                delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 1, 0, 0, CInt(lab.Text))
                                If delete = True Then
                                    Session("JSDelJobQtyRow") = "1"
                                    txtbox = rad.Items(z).FindControl("txtQuantity")
                                    strQty &= "Quantity:  " & txtbox.Text & "<br />"
                                    lab = rad.Items(z).FindControl("lblEstimateNumber")
                                    strQty &= "Estimate Number:  " & lab.Text & "<br />"
                                    lab = rad.Items(z).FindControl("lblCompNum")
                                    strQty &= "Comp Num:  " & lab.Text & "<br />"
                                    lab = rad.Items(z).FindControl("lblQuoteNum")
                                    strQty &= "Quote Num:  " & lab.Text & "<br />"
                                    lab = rad.Items(z).FindControl("lblRevNum")
                                    strQty &= "Rev Num:  " & lab.Text & "<br />"
                                    Session("JSDelJobQtyRowText") = strQty
                                End If
                            End If
                        Next
                    End If
                    If InStr(ctrl.ClientID, "Vendor") > 0 Then
                        Dim strVen As String = "Deleted Vendor Rows:" & "<br />"
                        For z = 0 To rad.Items.Count - 1
                            cb = rad.Items(z).FindControl("cbDelete")
                            If cb.Checked = True Then
                                txtbox = rad.Items(z).FindControl("txtSPEC_ID")
                                dr = js.GetJobSpecQtyVendorTabs(type)
                                Do While dr.Read
                                    If dr.GetInt16(2) = 1 Then
                                        delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 1, CInt(txtbox.Text), 0)
                                    End If
                                    If dr.GetInt16(2) = 2 Then
                                        delete = js.DeleteJobSpecQtyVenRows(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue, Me.ddRevision.SelectedValue, 0, 2, CInt(txtbox.Text), 0)
                                    End If
                                    If delete = True Then
                                        Session("JSDelJobVenRow") = "1"
                                        txtbox = rad.Items(z).FindControl("txtVendor")
                                        strVen &= "Vendor:  " & txtbox.Text & "<br />"
                                        Session("JSDelJobVenRowText") = strVen
                                    End If
                                Loop
                                dr.Close()
                            End If
                        Next
                    End If
                End If
                If ctrl.Controls.Count > 0 Then
                    Me.DeleteRowQtyVendor(ctrl)
                End If
            Next
        Catch ex As Exception
            Me.ShowMessage("Error DeleteRows!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Function QtyVendorCheckedRows(ByVal pg As System.Web.UI.Control)
        Try
            Dim rad As New RadGrid
            Dim z As Integer
            Dim cb As New CheckBox
            Dim lab As New System.Web.UI.WebControls.Label
            Dim txtbox As New System.Web.UI.WebControls.TextBox
            Dim js As New Job_Specs(Session("ConnString"))
            Dim delete As Boolean
            Dim dr As SqlDataReader
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            For Each ctrl As System.Web.UI.Control In pg.Controls
                Dim test As String = ctrl.GetType.ToString
                If ctrl.GetType.ToString() = "Telerik.Web.UI.RadGrid" Then
                    rad = CType(ctrl, RadGrid)
                    If InStr(ctrl.ClientID, "Quantity") > 0 Then
                        For z = 0 To rad.Items.Count - 1
                            cb = rad.Items(z).FindControl("cbDelete")
                            If cb.Checked = True Then
                                count = count + 1
                            End If
                        Next
                    End If
                    If InStr(ctrl.ClientID, "Vendor") > 0 Then
                        For z = 0 To rad.Items.Count - 1
                            cb = rad.Items(z).FindControl("cbDelete")
                            If cb.Checked = True Then
                                count = count + 1
                            End If
                        Next
                    End If
                End If
                If ctrl.Controls.Count > 0 Then
                    Me.QtyVendorCheckedRows(ctrl)
                End If
            Next
            Return count
        Catch ex As Exception
            Me.ShowMessage("Error DeleteRows!<BR />" & ex.Message.ToString())
        End Try
    End Function

    Private Sub AddNewJobSpec()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim save As Boolean
            save = js.AddJobSpecNew(Me.JobNum, Me.JobCompNum, 1, 0, Session("UserCode"), Request.QueryString("spectype"))
            If save = True Then
                Me.ShowMessage("New Version Created")
                Session("JSNewVersion") = "1"
                Session("JSNewRevision") = "0"
            Else
                Me.ShowMessage("Creation Failed")
            End If
        Catch ex As Exception
            Me.ShowMessage("Error AddNewjobspecs!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CheckApproval()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim approval As Boolean
            dr = js.GetJobSpecApprovalData(Me.JobNum, Me.JobCompNum)
            Dim button As New Telerik.Web.UI.RadToolBarButton
            If Me.ddRevision.SelectedValue <> "CR" And Me.ddVersion.SelectedValue <> "CV" And Me.ddVersion.SelectedValue <> "NV" Then
                Do While dr.Read
                    Dim e As Integer = dr.GetInt32(0)
                    JobSpecCPID = dr.GetInt32(5)
                    If dr.GetInt32(0) = CInt(Me.ddVersion.SelectedValue) Then
                        Me.hlApproved.Text = "Approved Version"
                        Me.hlApproved.Visible = True
                        Me.lblApproved.Visible = False
                        button = Me.RadToolBarJobSpecs.FindItemByValue("Approve")
                        button.Text = "Unapprove"
                        button.ToolTip = "Unapprove"
                        If IsClientPortal = True And JobSpecCPID = 0 Then
                            button.Enabled = False
                        End If
                    Else
                        Me.lblApproved.Visible = False
                        Me.hlApproved.Visible = False
                        button = Me.RadToolBarJobSpecs.FindItemByValue("Approve")
                        button.Text = "Approve"
                        button.ToolTip = "Approve"
                    End If
                Loop
                dr.Close()
            End If
        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Sub CheckQtyVendor()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            dr = js.GetJobSpecQtyVendorTabs(type)
            Dim button As New Telerik.Web.UI.RadToolBarButton
            Do While dr.Read
                If dr.GetInt16(1) <> 1 And dr.GetInt16(2) <> 1 And dr.GetInt16(2) <> 2 Then
                    Me.RadToolBarJobSpecs.FindItemByValue("AddRow").Enabled = False
                    Me.RadToolBarJobSpecs.FindItemByValue("DelRow").Enabled = False
                Else
                    Me.RadToolBarJobSpecs.FindItemByValue("AddRow").Enabled = True
                    Me.RadToolBarJobSpecs.FindItemByValue("DelRow").Enabled = True
                End If
            Loop
            dr.Close()
        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Sub

    Private Function checkDataChanges()
        Try
            Dim MyJobSpecs As Job_Specs = New Job_Specs(Session("ConnString"))
            With MyJobSpecs
                dtUserData = .CreateUserDataDataTable(Page) 'Get the form data
                .UpdateDTFormValues(dtFormData, dtUserData, Session("JobSpecDescription"))
            End With
            'With GridView1
            '    .DataSource = dtFormData
            '    .DataBind()
            'End With
            Dim dvChanges As DataView = New DataView(dtFormData)
            Dim StrDefaultFilter As String = "(DBValue <> FormValue)"
            dvChanges.RowFilter = StrDefaultFilter ' & StrIncludeTaxFilter

            Dim dtChanges As DataTable = New DataTable
            dtChanges = dvChanges.ToTable
            If dtChanges.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Me.ShowMessage("Error checkapproval!<BR />" & ex.Message.ToString())
        End Try
    End Function

    Private Sub PageLoadJS(ByVal strJS As String)
        Dim strTmpJS As String = String.Empty
        strTmpJS = "<script type=""text/javascript"">function init() { " & strJS & " } window.onload = init;</script>"
        If Not Page.IsStartupScriptRegistered("JSPageLoad" & Now.Millisecond) Then
            Page.RegisterStartupScript("JSAlert", strTmpJS)
        End If
    End Sub

    Private Function GetEmailAddressFromGroup(ByVal strEmailGroup As String) As SqlDataReader
        Try
            Dim oSQL As SqlHelper
            Dim strReturn As String = String.Empty
            Dim dr As SqlDataReader
            If strEmailGroup <> "" Then
                Dim arParams(1) As SqlParameter
                Dim paramEmailGroup As New SqlParameter("@EmailGroup", SqlDbType.VarChar, 50)
                paramEmailGroup.Value = strEmailGroup
                arParams(0) = paramEmailGroup
                'use mConnString if moving to class instead of session
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_GetEmailAddressFromGroup", arParams)
            End If
            Return dr
        Catch ex As Exception
        End Try
    End Function

    Private Function GetYesNo(ByVal ThisShort As Short) As String
        If ThisShort = 1 Then
            Return "Yes"
        Else
            Return "No"
        End If
    End Function

#End Region

    Private Sub SaveChangedData()
        Session("MSG") = ""
        Dim MyJobSpecs As Job_Specs = New Job_Specs(Session("ConnString"))
        Dim oReqCheck As cRequired = New cRequired(CStr(Session("ConnString")))
        Dim oValidations As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim oJob As Job = New Job(Session("ConnString"))
        Dim oAgency As New cAgency(Session("ConnString"))
        Dim ocJobs As New cJobs(Session("ConnString"))
        Dim jsjsnew As String = Session("JSNewVersion")
        oJob.GetJob(JobNum, JobCompNum)
        'Me.Page.Trace.IsEnabled = True

        Me.Client = oJob.CL_CODE
        Me.Division = oJob.DIV_CODE
        Me.Product = oJob.PRD_CODE

        Dim SaveSuccessful As Boolean = False
        Dim SaveMessageReturn As String = String.Empty
        Dim SaveTemplate As Boolean = False

        Try
            'dtFormData set when page first loads
            'then this sub sets dtUserData
            'then it updates the dtformdata with user(form) data.
            With MyJobSpecs
                dtUserData = .CreateUserDataDataTable(Page) 'Get the form data
                'With GridView2
                '    .DataSource = dtUserData 'dvChanges has DBValue field and FormValue field
                '    .DataBind()
                'End With
                .UpdateDTFormValues(dtFormData, dtUserData, Session("JobSpecDescription"))
            End With
            'With GridView1
            '    .DataSource = dtFormData
            '    .DataBind()
            'End With
            Dim dvChanges As DataView = New DataView(dtFormData)

            'Set the datatable to filter only changed rows
            'Dim StrDefaultFilter As String = "((ItemCode LIKE 'JOB_LOG%' OR ItemCode LIKE 'JOB_COMPONENT%' OR ItemCode LIKE 'JOB_CLIENT_REF%') AND (DBValue <> FormValue))"
            Dim StrDefaultFilter As String = "(DBValue <> FormValue)"
            'Include the tax flag and tax code regardless if changed or not
            Dim StrIncludeTaxFilter As String = " OR ItemCode = 'SPEC_VER_DESC'"

            dvChanges.RowFilter = StrDefaultFilter & StrIncludeTaxFilter


            Dim dtChanges As DataTable = New DataTable
            dtChanges = dvChanges.ToTable
            dtEdits = dvChanges.ToTable

            ''Just testing by outputting to gridview
            'With GridView1
            '    .DataSource = dtChanges
            '    .DataBind()
            'End With
            'With GridView3
            '    .DataSource = dtFormData 'dvChanges has DBValue field and FormValue field
            '    .DataBind()
            'End With
            'With GridView2
            '    .DataSource = dtUserData 'dvChanges has DBValue field and FormValue field
            '    .DataBind()
            'End With

            'Validate user input

            SaveQtyVendorGrids()

            If dtChanges.Rows.Count > 0 And Page.IsValid Then
                Try
                    Dim dtAllLookUps As DataTable = New DataTable
                    Dim sbInvalid As StringBuilder = New StringBuilder
                    Dim strSHORT_DESC As String = String.Empty
                    Dim IsValidUserData As Boolean = True
                    dtAllLookUps = MyJobSpecs.CreateLookupDataTable()

                    'Create dataview of ALL lookups:
                    Dim dvLookups As DataView = New DataView(dtAllLookUps)

                    'loop through all the changes in the changes datatable
                    For i As Integer = 0 To dtChanges.Rows.Count - 1
                        Dim CurrentItemCaption As String = ""

                        If IsDBNull(dtChanges.Rows(i)("ItemCaption")) = False Then

                            CurrentItemCaption = dtChanges.Rows(i)("ItemCaption")

                        End If

                        If InStr(dtChanges.Rows(i)("ItemCode"), "INT") > 0 Then
                            If IsNumeric(dtChanges.Rows(i)("FormValue")) = False Then
                                Me.ShowMessage("Please enter a number for " + CurrentItemCaption)
                                Exit Sub
                            End If
                        End If
                        If InStr(dtChanges.Rows(i)("ItemCode"), "Date") > 0 Then

                            If dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                If wvIsDate(dtChanges.Rows(i)("FormValue").ToString()) = False Then
                                    'Dim str() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                                    'If InStr(dtChanges.Rows(i)("ControlID"), "Vendor") > 0 Then
                                    '    Me.ShowMessage("Please enter a valid Date for " & str(2) & " " & str(3) & " " & str(4))
                                    'Else
                                    '    Me.ShowMessage("Please enter a valid Date for " & str(2))
                                    'End If
                                    Me.ShowMessage("Please enter a valid date for " + CurrentItemCaption)
                                    Exit Sub
                                Else
                                    dtChanges.Rows(i).Item(3) = wvCDate(dtChanges.Rows(i)("FormValue"))
                                End If
                            End If
                        End If
                        If InStr(dtChanges.Rows(i)("ItemCode"), "Quantity") > 0 Then

                            If IsNumeric(dtChanges.Rows(i)("FormValue")) = False Then
                                Me.ShowMessage("Please enter a number for " + CurrentItemCaption)
                                Exit Sub
                            End If
                            If dtChanges.Rows(i)("FormValue") > 2147483647 Then
                                Me.ShowMessage("Please enter a valid quantity for " + CurrentItemCaption)
                                Exit Sub
                            End If
                        End If
                        'Create another dataview to hold possible values for one lookup type.
                        Dim dvFilter As New DataView
                        'set the filter dataview to include all the lookups
                        dvFilter = dvLookups
                        'filter it to one type
                        dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "'"

                        If dvFilter.ToTable.Rows.Count > 0 Then ' Less than zero means it doesn't have a lookup
                            strSHORT_DESC = dvFilter.ToTable.Rows(0)("SHORT_DESC")
                            'refilter
                            Dim s As String = dtChanges.Rows(i)("FormValue").ToString
                            If dtChanges.Rows(i)("FormValue") <> "" Then 'Make sure we don't validate a change to empty data
                                dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "' AND code = '" & dtChanges.Rows(i)("FormValue") & "'"
                                If dvFilter.ToTable.Rows.Count <= 0 Then 'Not valid lookup
                                    With sbInvalid
                                        .Append("Invalid ")
                                        .Append(strSHORT_DESC)
                                        .Append(".<br />")
                                    End With
                                    IsValidUserData = False
                                End If
                            End If
                        End If

                    Next

                    If IsValidUserData = False Then
                        Me.ShowMessage("Your input had the following validation problems:<br />" & sbInvalid.ToString())
                        Exit Sub
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error validating lookups!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
                    Exit Sub
                End Try
            End If


            Try
                If dtChanges.Rows.Count > 0 And Page.IsValid Then
                    'stringbuilders for sql
                    Dim sbJobUpdate As StringBuilder = New StringBuilder
                    Dim sbJobQtyUpdate As StringBuilder = New StringBuilder
                    Dim sbJobVendor As StringBuilder = New StringBuilder
                    Dim parametertCloseDate As New SqlParameter("@cdate", SqlDbType.SmallDateTime)
                    Dim parametertRunDate As New SqlParameter("@rdate", SqlDbType.SmallDateTime)
                    Dim parametertExtDate As New SqlParameter("@edate", SqlDbType.SmallDateTime)
                    Dim arParams(4) As SqlParameter

                    'stringbuilder for alert
                    Dim sbAlertEmail As StringBuilder = New StringBuilder

                    sbJobUpdate.Append("UPDATE JOB_SPECS SET ")

                    Dim JobHasChange As Boolean = False
                    Dim QtyHasChange As Boolean = False
                    Dim VendorHasChange As Boolean = False
                    Dim js As New Job_Specs(Session("ConnString"))
                    'This is main loop that builds the change sql
                    'includes DBValue field which is data pulled from db
                    'and FormValue field which is data pulled from form
                    For i As Integer = 0 To dtChanges.Rows.Count - 1
                        If InStr(dtChanges.Rows(i)("ControlID"), "_TxtValue") > 0 Or InStr(dtChanges.Rows(i)("ControlID"), "txtDesc") > 0 Or InStr(dtChanges.Rows(i)("ControlID"), "_RadEditorValue") > 0 Then
                            If InStr(dtChanges.Rows(i)("ItemCode"), "INT") > 0 Then
                                sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue").ToString.Replace(",", "")) & "', ")
                            Else
                                sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            End If
                            JobHasChange = True
                            'ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Quantity_QuantityEst") > 0 Then
                            '    Dim strArr() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                            '    Dim estnum As Integer = CInt(strArr(4))
                            '    Dim comp As Integer = CInt(strArr(5))
                            '    Dim quote As Integer = CInt(strArr(6))
                            '    Dim rev As Integer = CInt(strArr(7))
                            '    sbJobQtyUpdate.Append("UPDATE ESTIMATE_REV SET ")
                            '    sbJobQtyUpdate.Append("JOB_QTY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '    sbJobQtyUpdate.Append(" WHERE ESTIMATE_NUMBER = " & estnum & " AND EST_COMPONENT_NBR = " & comp & " AND EST_QUOTE_NBR = " & quote & " AND EST_REV_NBR = " & rev & " ")
                            '    QtyHasChange = True
                            'ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Quantity_Quantity") > 0 Then
                            '    sbJobQtyUpdate.Append("UPDATE JOB_SPEC_QTY SET ")
                            '    sbJobQtyUpdate.Append("JOB_QTY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue").ToString.Replace(",", "")) & "', ")
                            '    sbJobQtyUpdate.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.ddVersion.SelectedValue & " AND SPEC_REV = " & Me.ddRevision.SelectedValue & " AND SEQ_NBR = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '    QtyHasChange = True
                            'ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Vendor") > 0 Then
                            '    Dim dr As SqlDataReader
                            '    Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                            '    dr = js.GetJobSpecQtyVendorTabs(type)
                            '    Do While dr.Read
                            '        If dr.GetInt16(2) = 1 Then
                            '            sbJobVendor.Append("UPDATE JOB_PUB_VENDOR SET ")
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Vendor") > 0 Then
                            '                sbJobVendor.Append("VN_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Close_Date") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_CLOSE_DATE = CAST(@cdate AS VARCHAR), ")
                            '                parametertCloseDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                            '                arParams(0) = parametertCloseDate
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Run_Date") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_RUN_DATE = CAST(@rdate AS VARCHAR), ")
                            '                parametertRunDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                            '                arParams(1) = parametertRunDate
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Ext_Date") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_EXT_DATE = CAST(@edate AS VARCHAR), ")
                            '                parametertExtDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                            '                arParams(2) = parametertExtDate
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Bleed_Size") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_BLEED_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Trim_Size") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_TRIM_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Live_Area") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_LIVE_AREA = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Screen") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_SCREEN = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Color") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_COLOR = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Status") > 0 Then
                            '                sbJobVendor.Append("STATUS_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Region") > 0 Then
                            '                sbJobVendor.Append("REGION_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Density") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_DENSITY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Film") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_FILM = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Shipping_Comments") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_SHIP_COMM = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Special_Instructions") > 0 Then
                            '                sbJobVendor.Append("JOB_PUB_SPCL_INST = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "AdSize") > 0 Then
                            '                sbJobVendor.Append("AD_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '        End If
                            '        If dr.GetInt16(2) = 2 Then
                            '            sbJobVendor.Append("UPDATE JOB_OUTDOOR_VENDOR SET ")
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Vendor") > 0 Then
                            '                sbJobVendor.Append("VN_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Copy_Area") > 0 Then
                            '                sbJobVendor.Append("JOB_OUT_COPY_AREA = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Location_of_Sign") > 0 Then
                            '                sbJobVendor.Append("JOB_OUT_LOCATION = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "Overall_Size") > 0 Then
                            '                sbJobVendor.Append("JOB_OUT_OVR_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '            If InStr(dtChanges.Rows(i)("ItemCode"), "AdSize") > 0 Then
                            '                sbJobVendor.Append("AD_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            '                sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            '            End If
                            '        End If
                            '    Loop
                            '    VendorHasChange = True
                        End If
                    Next
                    sbJobUpdate.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.ddVersion.SelectedValue & " AND SPEC_REV = " & Me.ddRevision.SelectedValue)


                    Dim sbMainSQL As StringBuilder = New StringBuilder
                    With sbMainSQL
                        If JobHasChange = True Then
                            .Append(sbJobUpdate.ToString() & ";")
                        End If
                        If QtyHasChange = True Then
                            .Append(sbJobQtyUpdate.ToString() & ";")
                        End If
                        If VendorHasChange = True Then
                            .Append(sbJobVendor.ToString() & ";")
                        End If
                    End With

                    ''Just a test string
                    'If Trace.IsEnabled = True Then
                    '    lblMSG.Text = "<hr /><Strong>SQL:</Strong><BR/>" & sbMainSQL.ToString.Replace(",  WHERE", " WHERE") & "<BR/><BR/><hr />"
                    'End If

                    'do more req checks on string here?
                    'like tax field and tax flag?

                    ''run actual update
                    'If Trace.IsEnabled = False Then
                    Try
                        Dim str As String = sbMainSQL.ToString.Replace(",  WHERE", " WHERE")

                        'str = str.Replace("$", "")
                        'str = str.Replace("%", "")
                        If str <> "" Then 'And (JobHasChange = True Or CompHasChange = True Or JobCliRefHasChange = True) Then
                            SaveMessageReturn = "Job Update: " & MyJobSpecs.UpdateJob(str, arParams, SaveSuccessful).ToString
                        Else
                            Me.ShowMessage("No changes detected!")
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Job NOT Updated!<br />" & ex.Message.ToString)
                        Exit Sub
                    End Try
                    'End If

                    ''Just testing by outputting to gridview
                    'With GridView3
                    '    .DataSource = dvChanges 'dvChanges has DBValue field and FormValue field
                    '    .DataBind()
                    'End With



                    'Pop the Job Jacket alert window:
                    'Get the requirements:
                    Dim dtAlertReqs As New DataTable("AlertReqs")
                    dtAlertReqs = MyJobSpecs.GetAlertRequirements(JobNum, JobCompNum, oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
                    Dim strReqDescript As String = String.Empty
                    For j As Integer = 0 To dtAlertReqs.Rows.Count - 1
                        strReqDescript = dtAlertReqs.Rows(j)("ReqDescript")
                        Select Case strReqDescript
                            Case "AgencyRequiredEmail"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsAgencyRequiredEmail = True
                                End If
                            Case "AutoEmailPromptOnNew"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsAutoEmailPromptOnNew = True
                                End If
                            Case "AutoEmailPromptOnUpdate"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsAutoEmailPromptOnUpdate = True
                                End If
                            Case "AutoEmailPromptOnRevision"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsAutoEmailPromptOnRevision = True
                                End If
                            Case "ClientGetsEmailOnNewJS"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsClientGetsEmailOnNew = True
                                End If
                            Case "ClientGetsEmailOnUpdateJS"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsClientGetsEmailOnUpdate = True
                                End If
                            Case "ClientGetsEmailOnRevisionJS"
                                If dtAlertReqs.Rows(j)("IsRequired") = "1" Then
                                    IsClientGetsEmailOnRevision = True
                                End If
                        End Select
                    Next

                    'should this be a "reload" type fn instead of a re-direct
                    'if redirect, need to add another qs to show pop

                    If SaveSuccessful = True Then
                        Dim strAlertPopUp_title As String
                        Dim strAlertPopUp_body As String
                        Dim strAlertBody As String
                        Dim boolIsNew As Boolean
                        Dim oJob2 As Job = New Job(Session("ConnString"))
                        oJob2.GetJob(JobNum, JobCompNum)
                        Dim sendalert As Boolean = Me.CheckChanges(oJob2, strAlertBody, Me.dtEdits)
                        'Dim strJS_RedirectToReadOnly As String = Server.UrlDecode("location.href=""jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                        'Me.ShowMessage("Save Successful!")
                        Dim strNew As String = Session("JSNewVersion")
                        Dim strNEW2 As String = Session("JSNewRevision")
                        Try
                            If Session("JSNewVersion") = "1" Then   'this is a new job
                                strAlertPopUp_title = "New Job Specification Version - " & JobNum.ToString.PadLeft(6, "0") & "-" & JobCompNum.ToString.PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                boolIsNew = True
                                'Can combine the below elsif with the above,
                                'but in a separate elseif, we can differentiate a new job from a new comp in the future
                            ElseIf Session("JSNewRevision") = "1" Then 'this is a new component
                                strAlertPopUp_title = "New Job Specification Revision - " & JobNum.ToString.PadLeft(6, "0") & "-" & JobCompNum.ToString.PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " created by " & Session("EmployeeName")
                                boolIsNew = True
                            ElseIf IsNumeric(JobNum) And IsNumeric(JobCompNum) Then 'this is an edit
                                strAlertPopUp_title = "Existing Job Specification - " & JobNum.ToString.PadLeft(6, "0") & "-" & JobCompNum.ToString.PadLeft(3, "0") & " - " & oJob2.JobComponent.JOB_COMP_DESC & " for client " & oJob2.CL_CODE & " modified by " & Session("EmployeeName")
                                boolIsNew = False
                            End If
                            strAlertPopUp_body = strAlertBody
                            'Me.txtJobNo.Value = oJob.JOB_NUMBER
                            'Me.txtJobCompNo.Value = oJob.JobComponent.JOB_COMPONENT_NBR
                        Catch ex As Exception
                            Me.ShowMessage("Error in getting QS vars: " & ex.Message.ToString())
                        End Try

                        'Modified by Sam Tran on 2006/05/12
                        '	At this point, looks like the save is successful and we're going to pop the new email page now.
                        '   the specific job obj is still in memory, will use it to send new querystrings
                        '   This section added to move the pop over email notification into normal popup page.

                        'Set querystring vars:
                        Dim sbQSVars As System.Text.StringBuilder = New System.Text.StringBuilder
                        'Dim od As cDefaults = New cDefaults(CStr(Session("ConnString")))
                        'Dim strCurrEmailGroup As String
                        'strCurrEmailGroup = od.GetDefaultGroup(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE)
                        Dim od As cAlerts = New cAlerts(CStr(Session("ConnString")))
                        Dim Employee As New cEmployee(CStr(Session("ConnString")))
                        Dim strCurrEmailGroup As String
                        strCurrEmailGroup = od.GetDefaultGroup(oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, Me.JobNum, Me.JobCompNum)
                        Try
                            With sbQSVars
                                .Append("?")
                                .Append("EmailGroup=" & strCurrEmailGroup.Replace("/", "-").Replace("&", "and").Replace("'", "").Replace(",", ""))
                                .Append("&DivCode=" & oJob.DIV_CODE)
                                .Append("&JobCompNo=" & JobCompNum)
                                .Append("&JobNo=" & JobNum)
                                .Append("&ProdCode=" & oJob.PRD_CODE)
                                .Append("&Recipients=" & "")
                                .Append("&ClientCode=" & oJob.CL_CODE)
                                .Append("&Version=" & Me.ddVersion.SelectedValue)
                                .Append("&Revision=" & Me.ddRevision.SelectedValue)
                                If boolIsNew = True Then
                                    .Append("&New=1")
                                Else
                                    .Append("&New=0")
                                End If
                                If Session("JSNewJobSpec") = 1 Then
                                    .Append("&NewJS=1")
                                Else
                                    .Append("&NewJS=0")
                                End If
                                .Append("&f=")
                                .Append(MiscFN.SourceApp_ToInt(Source_App.JobSpecs))

                            End With
                        Catch ex As Exception
                            Me.ShowMessage("Error setting sbQSVars: " & ex.Message.ToString())
                        End Try

                        Try
                            'st:   test using session instead of qs to pass what could potentially be too much data for a qs
                            Session("AlertPopUpJS_Title") = strAlertPopUp_title
                            Session("AlertPopUpJS_Body") = strAlertPopUp_body
                        Catch ex As Exception
                            Me.ShowMessage("Error in setting pop up body and title from session: " & ex.Message.ToString())
                        End Try
                        Try
                            Dim strJS_PopEmail As String = Server.UrlDecode("window.open('popup_email_alert.aspx" & sbQSVars.ToString() & "','','screenX=150,left=150,screenY=150,top=150,width=310,height=575,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;")
                            If IsAgencyRequiredEmail = True Then
                                Try
                                    If IsClientGetsEmailOnUpdate = True And Session("JSNewVersion") <> "1" And Session("JSNewRevision") <> "1" Then
                                        If IsAutoEmailPromptOnUpdate = True Then   'do prompt check here   , if prompt is true
                                            'PageLoadJS(strJS_PopEmail)
                                            Me.OpenWindow("", "popup_email_alert.aspx" & sbQSVars.ToString(), 575, 350, , True)
                                        Else 'prompt is false , Send silent
                                            'loop through the group and send silent the email:
                                            Try

                                                Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                                                Dim AlertID As Integer
                                                If Session("JSNewJobSpec") = 1 Then
                                                    AlertID = oAlert.AddAlerts(2, 15, strAlertPopUp_title, strAlertPopUp_body, Now, "", oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, "",
                                                    JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))
                                                    Me.SendSilentEmail(strCurrEmailGroup, 2, 15, strAlertPopUp_title, strAlertPopUp_body)
                                                Else
                                                    AlertID = oAlert.AddAlerts(2, 22, strAlertPopUp_title, strAlertPopUp_body, Now, "", oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, "",
                                                    JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))
                                                    Me.SendSilentEmail(strCurrEmailGroup, 2, 22, strAlertPopUp_title, strAlertPopUp_body)
                                                End If


                                                Session("JSNewVersion") = ""
                                                Session("JSNewRevision") = ""
                                                MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                                                Exit Sub
                                            Catch ex As Exception
                                                Me.ShowMessage("Error in PopEmailUpdate conditional else case: " & ex.Message.ToString())
                                            End Try
                                        End If
                                    ElseIf IsClientGetsEmailOnNew = True And Session("JSNewVersion") = "1" Then
                                        Try
                                            If IsAutoEmailPromptOnNew = True And Session("JSNewVersion") = "1" Then
                                                'PageLoadJS(strJS_PopEmail)
                                                Me.OpenWindow("", "popup_email_alert.aspx" & sbQSVars.ToString(), 575, 350, , True)
                                            Else
                                                Try

                                                    Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                                                    Dim AlertID As Integer
                                                    If Session("JSNewJobSpec") = 1 Then
                                                        AlertID = oAlert.AddAlerts(2, 15, strAlertPopUp_title, strAlertPopUp_body, Now, "", oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, "",
                                                        JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))
                                                        Me.SendSilentEmail(strCurrEmailGroup, 2, 15, strAlertPopUp_title, strAlertPopUp_body)
                                                    Else
                                                        AlertID = oAlert.AddAlerts(2, 16, strAlertPopUp_title, strAlertPopUp_body, Now, "", oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, "",
                                                        JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))
                                                        Me.SendSilentEmail(strCurrEmailGroup, 2, 16, strAlertPopUp_title, strAlertPopUp_body)
                                                    End If

                                                    Session("JSNewVersion") = ""
                                                    Session("JSNewRevision") = ""
                                                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                                                    Exit Sub
                                                Catch ex As Exception
                                                    Me.ShowMessage("Error in getting pop email new loop: " & ex.Message.ToString())
                                                End Try
                                            End If
                                        Catch ex As Exception
                                            Me.ShowMessage("Error in PopEmailNew conditional: " & ex.Message.ToString())
                                        End Try
                                    ElseIf IsClientGetsEmailOnRevision = True And Session("JSNewRevision") = "1" Then
                                        Try
                                            If IsAutoEmailPromptOnRevision = True And Session("JSNewRevision") = "1" Then
                                                'PageLoadJS(strJS_PopEmail)
                                                Me.OpenWindow("", "popup_email_alert.aspx" & sbQSVars.ToString(), 575, 350, , True)
                                            Else
                                                Try
                                                    Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
                                                    Dim AlertID As Integer
                                                    AlertID = oAlert.AddAlerts(2, 16, strAlertPopUp_title, strAlertPopUp_body, Now, "", oJob.CL_CODE, oJob.DIV_CODE, oJob.PRD_CODE, "",
                                                    JobNum, JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))

                                                    Me.SendSilentEmail(strCurrEmailGroup, 2, 16, strAlertPopUp_title, strAlertPopUp_body)

                                                    Session("JSNewVersion") = ""
                                                    Session("JSNewRevision") = ""
                                                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                                                    Exit Sub
                                                Catch ex As Exception
                                                    Me.ShowMessage("Error in getting pop email new loop: " & ex.Message.ToString())
                                                End Try
                                            End If
                                        Catch ex As Exception
                                            Me.ShowMessage("Error in PopEmailNew conditional: " & ex.Message.ToString())
                                        End Try
                                    Else
                                        Try
                                            Session("JSNewVersion") = ""
                                            Session("JSNewRevision") = ""
                                            MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                                            Exit Sub
                                        Catch ex As Exception
                                            Me.ShowMessage("Error in popEmailNew conditional for else case: " & ex.Message.ToString())
                                        End Try
                                    End If
                                Catch ex As Exception
                                    Me.ShowMessage("Error saving when ClientGetsEmail on Update is true: " & ex.Message.ToString())
                                    Exit Sub
                                Finally
                                End Try
                            Else
                                MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                                Exit Sub
                            End If
                            Session("JSNewVersion") = ""
                            Session("JSNewRevision") = ""
                            Session("JSNewJobSpec") = 0
                        Catch ex As Exception
                            Me.ShowMessage("Error saving when autoemail is true: " & ex.Message.ToString())
                            Exit Sub
                        Finally
                        End Try
                        Me.loadJobSpec()
                    End If
                ElseIf SaveSuccessful = False And SaveTemplate = True Then
                    MiscFN.ResponseRedirect("jobspecs.aspx?JobNum=" & JobNum & "&JobCompNum=" & JobCompNum & "&new=0")
                    Exit Sub
                Else
                    Me.ShowMessage("No changes were saved.<br />Please make a change and/or review the form for errors before saving")
                End If
            Catch ex As Exception
                Me.ShowMessage("Error creating update sql!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
            End Try
        Catch ex As Exception
            Me.ShowMessage("Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
        End Try
    End Sub

    Private Function SaveData()
        'Me.JobNum = HttpContext.Current.Request.QueryString("JobNum")
        'Me.JobCompNum = HttpContext.Current.Request.QueryString("JobCompNum")

        Dim MyJobSpecs As Job_Specs = New Job_Specs(HttpContext.Current.Session("ConnString"))
        Dim oReqCheck As cRequired = New cRequired(CStr(HttpContext.Current.Session("ConnString")))
        Dim oValidations As cValidations = New cValidations(CStr(HttpContext.Current.Session("ConnString")))
        Dim oJob As Job = New Job(HttpContext.Current.Session("ConnString"))
        Dim oAgency As New cAgency(HttpContext.Current.Session("ConnString"))
        Dim ocJobs As New cJobs(HttpContext.Current.Session("ConnString"))
        oJob.GetJob(JobNum, JobCompNum)
        'Me.Page.Trace.IsEnabled = True

        Dim SaveSuccessful As Boolean = False
        Dim SaveMessageReturn As String = String.Empty
        Dim SaveTemplate As Boolean = False

        Try
            'dtFormData set when page first loads
            'then this sub sets dtUserData
            'then it updates the dtformdata with user(form) data.
            With MyJobSpecs
                dtUserData = .CreateUserDataDataTable(Page) 'Get the form data
                .UpdateDTFormValues(dtFormData, dtUserData, HttpContext.Current.Session("JobSpecDescription"))
            End With
            Dim dvChanges As DataView = New DataView(dtFormData)
            Dim StrDefaultFilter As String = "(DBValue <> FormValue)"

            dvChanges.RowFilter = StrDefaultFilter

            Dim dtChanges As DataTable = New DataTable
            dtChanges = dvChanges.ToTable
            dtEdits = dvChanges.ToTable

            'Validate user input
            If dtChanges.Rows.Count > 0 Then
                Try
                    Dim dtAllLookUps As DataTable = New DataTable
                    Dim sbInvalid As StringBuilder = New StringBuilder
                    Dim strSHORT_DESC As String = String.Empty
                    Dim IsValidUserData As Boolean = True
                    dtAllLookUps = MyJobSpecs.CreateLookupDataTable()

                    'Create dataview of ALL lookups:
                    Dim dvLookups As DataView = New DataView(dtAllLookUps)

                    'loop through all the changes in the changes datatable
                    For i As Integer = 0 To dtChanges.Rows.Count - 1
                        Dim str3 As String = dtChanges.Rows(i)("ItemCode").ToString
                        If InStr(dtChanges.Rows(i)("ItemCode"), "INT") > 0 Then
                            Dim str1 As String = dtChanges.Rows(i)("FormValue").ToString
                            Dim str2 As String = dtChanges.Rows(i)("FormValue").ToString
                            If IsNumeric(dtChanges.Rows(i)("FormValue")) = False Then
                                Dim str() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                                Dim name As String
                                For m As Integer = 0 To str.Length - 1
                                    If InStr(str(m), "colpnl") = 0 And InStr(str(m), "TxtValue") = 0 And InStr(str(m), "INT") = 0 And InStr(str(m), "SMALLINT") = 0 Then
                                        name = name & str(m) & " "
                                    End If
                                Next
                                Me.ShowMessage("Please enter a number for " & name.Substring(0, name.Length - 2))
                                Return False
                                Exit Function
                            End If
                        End If
                        If InStr(dtChanges.Rows(i)("ItemCode"), "Date") > 0 Then
                            Dim str1 As String = dtChanges.Rows(i)("FormValue").ToString
                            Dim str2 As String = dtChanges.Rows(i)("FormValue").ToString
                            If dtChanges.Rows(i)("FormValue").ToString() <> "" Then
                                If wvIsDate(dtChanges.Rows(i)("FormValue").ToString()) = False Then
                                    Dim str() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                                    If InStr(dtChanges.Rows(i)("ControlID"), "Vendor") > 0 Then
                                        Me.ShowMessage("Please enter a valid Date for " & str(2) & " " & str(3) & " " & str(4))
                                    Else
                                        Me.ShowMessage("Please enter a valid Date for " & str(2))
                                    End If
                                    Exit Function
                                Else
                                    dtChanges.Rows(i).Item(3) = wvCDate(dtChanges.Rows(i)("FormValue"))
                                End If
                            End If
                        End If
                        If InStr(dtChanges.Rows(i)("ItemCode"), "Quantity") > 0 Then
                            Dim str1 As String = dtChanges.Rows(i)("FormValue").ToString
                            Dim str2 As String = dtChanges.Rows(i)("FormValue").ToString
                            If IsNumeric(dtChanges.Rows(i)("FormValue")) = False Then
                                Dim str() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                                Me.ShowMessage("Please enter a number for " & str(2))
                                Return False
                                Exit Function
                            End If
                            If dtChanges.Rows(i)("FormValue") > 2147483647 Then
                                Dim str() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                                Me.ShowMessage("Please enter a valid quantity for " & str(2))
                                Return False
                                Exit Function
                            End If
                        End If
                        'Create another dataview to hold possible values for one lookup type.
                        Dim dvFilter As New DataView
                        'set the filter dataview to include all the lookups
                        dvFilter = dvLookups
                        'filter it to one type
                        dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "'"

                        If dvFilter.ToTable.Rows.Count > 0 Then ' Less than zero means it doesn't have a lookup
                            strSHORT_DESC = dvFilter.ToTable.Rows(0)("SHORT_DESC")
                            'refilter
                            Dim s As String = dtChanges.Rows(i)("FormValue").ToString
                            If dtChanges.Rows(i)("FormValue") <> "" Then 'Make sure we don't validate a change to empty data
                                dvFilter.RowFilter = "ItemCode = '" & dtChanges.Rows(i)("ItemCode") & "' AND code = '" & dtChanges.Rows(i)("FormValue") & "'"
                                If dvFilter.ToTable.Rows.Count <= 0 Then 'Not valid lookup
                                    With sbInvalid
                                        .Append("Invalid ")
                                        .Append(strSHORT_DESC)
                                        .Append(".<br />")
                                    End With
                                    IsValidUserData = False
                                End If
                            End If
                        End If

                    Next


                    If IsValidUserData = False Then
                        Me.ShowMessage("Your input had the following validation problems:<br />" & sbInvalid.ToString())
                        Return False
                        Exit Function
                    End If
                Catch ex As Exception
                    Me.ShowMessage("Error validating lookups!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
                    Return False
                    Exit Function
                End Try
            End If


            Try
                If dtChanges.Rows.Count > 0 Then
                    'stringbuilders for sql
                    Dim sbJobUpdate As StringBuilder = New StringBuilder
                    Dim sbJobQtyUpdate As StringBuilder = New StringBuilder
                    Dim sbJobVendor As StringBuilder = New StringBuilder
                    Dim parametertCloseDate As New SqlParameter("@cdate", SqlDbType.SmallDateTime)
                    Dim parametertRunDate As New SqlParameter("@rdate", SqlDbType.SmallDateTime)
                    Dim parametertExtDate As New SqlParameter("@edate", SqlDbType.SmallDateTime)
                    Dim arParams(4) As SqlParameter

                    'stringbuilder for alert
                    Dim sbAlertEmail As StringBuilder = New StringBuilder

                    sbJobUpdate.Append("UPDATE JOB_SPECS SET ")

                    Dim JobHasChange As Boolean = False
                    Dim QtyHasChange As Boolean = False
                    Dim VendorHasChange As Boolean = False
                    Dim js As New Job_Specs(Session("ConnString"))
                    'This is main loop that builds the change sql
                    'includes DBValue field which is data pulled from db
                    'and FormValue field which is data pulled from form
                    For i As Integer = 0 To dtChanges.Rows.Count - 1
                        If InStr(dtChanges.Rows(i)("ControlID"), "_TxtValue") > 0 Or InStr(dtChanges.Rows(i)("ControlID"), "txtDesc") > 0 Or InStr(dtChanges.Rows(i)("ControlID"), "_RadEditorValue") > 0 Then
                            If InStr(dtChanges.Rows(i)("ItemCode"), "INT") > 0 Then
                                sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue").ToString.Replace(",", "")) & "', ")
                            Else
                                sbJobUpdate.Append(ParseLastDot(dtChanges.Rows(i)("ItemCode")) & " = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            End If
                            JobHasChange = True
                        ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Quantity_QuantityEst") > 0 Then
                            Dim strArr() As String = dtChanges.Rows(i)("ControlID").ToString.Split("_")
                            Dim estnum As Integer = CInt(strArr(4))
                            Dim comp As Integer = CInt(strArr(5))
                            Dim quote As Integer = CInt(strArr(6))
                            Dim rev As Integer = CInt(strArr(7))
                            sbJobQtyUpdate.Append("UPDATE ESTIMATE_REV SET ")
                            sbJobQtyUpdate.Append("JOB_QTY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            sbJobQtyUpdate.Append(" WHERE ESTIMATE_NUMBER = " & estnum & " AND EST_COMPONENT_NBR = " & comp & " AND EST_QUOTE_NBR = " & quote & " AND EST_REV_NBR = " & rev & " ")
                            QtyHasChange = True
                        ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Quantity_Quantity") > 0 Then
                            sbJobQtyUpdate.Append("UPDATE JOB_SPEC_QTY SET ")
                            sbJobQtyUpdate.Append("JOB_QTY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                            sbJobQtyUpdate.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.ddVersion.SelectedValue & " AND SPEC_REV = " & Me.ddRevision.SelectedValue & " AND SEQ_NBR = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                            QtyHasChange = True
                        ElseIf InStr(dtChanges.Rows(i)("ControlID"), "RadGrid_Vendor") > 0 Then
                            Dim dr As SqlDataReader
                            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
                            dr = js.GetJobSpecQtyVendorTabs(type)
                            Do While dr.Read
                                If dr.GetInt16(2) = 1 Then
                                    sbJobVendor.Append("UPDATE JOB_PUB_VENDOR SET ")
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Vendor") > 0 Then
                                        sbJobVendor.Append("VN_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Close_Date") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_CLOSE_DATE = CAST(@cdate AS VARCHAR), ")
                                        parametertCloseDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        arParams(0) = parametertCloseDate
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Run_Date") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_RUN_DATE = CAST(@rdate AS VARCHAR), ")
                                        parametertRunDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        arParams(1) = parametertRunDate
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Ext_Date") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_EXT_DATE = CAST(@edate AS VARCHAR), ")
                                        parametertExtDate.Value = MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue"))
                                        arParams(2) = parametertExtDate
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Bleed_Size") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_BLEED_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Trim_Size") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_TRIM_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Live_Area") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_LIVE_AREA = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Screen") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_SCREEN = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Color") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_COLOR = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Status") > 0 Then
                                        sbJobVendor.Append("STATUS_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Region") > 0 Then
                                        sbJobVendor.Append("REGION_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Density") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_DENSITY = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Film") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_FILM = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Shipping_Comments") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_SHIP_COMM = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Special_Instructions") > 0 Then
                                        sbJobVendor.Append("JOB_PUB_SPCL_INST = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "AdSize") > 0 Then
                                        sbJobVendor.Append("AD_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                End If
                                If dr.GetInt16(2) = 2 Then
                                    sbJobVendor.Append("UPDATE JOB_OUTDOOR_VENDOR SET ")
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Vendor") > 0 Then
                                        sbJobVendor.Append("VN_CODE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Copy_Area") > 0 Then
                                        sbJobVendor.Append("JOB_OUT_COPY_AREA = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Location_of_Sign") > 0 Then
                                        sbJobVendor.Append("JOB_OUT_LOCATION = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "Overall_Size") > 0 Then
                                        sbJobVendor.Append("JOB_OUT_OVR_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                    If InStr(dtChanges.Rows(i)("ItemCode"), "AdSize") > 0 Then
                                        sbJobVendor.Append("AD_SIZE = '" & MyJobSpecs.EncodeSQL(dtChanges.Rows(i)("FormValue")) & "', ")
                                        sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & dtChanges.Rows(i)("ControlID").ToString.Substring(dtChanges.Rows(i)("ControlID").ToString.Length - 1) & " ")
                                    End If
                                End If
                            Loop
                            VendorHasChange = True
                        End If
                    Next
                    sbJobUpdate.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.ddVersion.SelectedValue & " AND SPEC_REV = " & Me.ddRevision.SelectedValue)


                    Dim sbMainSQL As StringBuilder = New StringBuilder
                    With sbMainSQL
                        If JobHasChange = True Then
                            .Append(sbJobUpdate.ToString() & ";")
                        End If
                        If QtyHasChange = True Then
                            .Append(sbJobQtyUpdate.ToString() & ";")
                        End If
                        If VendorHasChange = True Then
                            .Append(sbJobVendor.ToString() & ";")
                        End If
                    End With

                    '''Just a test string
                    'If Trace.IsEnabled = True Then
                    '    lblMSG.Text = "<hr /><Strong>SQL:</Strong><BR/>" & sbMainSQL.ToString.Replace(",  WHERE", " WHERE") & "<BR/><BR/><hr />"
                    'End If

                    'do more req checks on string here?
                    'like tax field and tax flag?

                    ''run actual update
                    'If Trace.IsEnabled = False Then
                    Try
                        Dim str As String = sbMainSQL.ToString.Replace(",  WHERE", " WHERE")
                        'str = str.Replace("$", "")
                        'str = str.Replace("%", "")
                        If str <> "" Then 'And (JobHasChange = True Or CompHasChange = True Or JobCliRefHasChange = True) Then
                            SaveMessageReturn = "Job Update: " & MyJobSpecs.UpdateJob(str, arParams, SaveSuccessful).ToString
                            Return SaveSuccessful
                        Else
                            Me.ShowMessage("No changes detected!")
                            Return True
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Job NOT Updated!<br />" & ex.Message.ToString)
                        Exit Function
                    End Try
                Else
                    Return True
                End If
            Catch ex As Exception
                Me.ShowMessage("Error creating update sql!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
            End Try
        Catch ex As Exception
            Me.ShowMessage("Error!<br />" & ex.Message.ToString() & "<br />" & ex.InnerException.ToString)
        End Try
    End Function

    Private Function SaveQtyVendorGrids()
        Try
            Dim js As New Job_Specs(Session("ConnString"))
            Dim SaveSuccessful As Boolean = False
            Dim RowCount As Integer = Me.RadGridQuantity.MasterTableView.Items.Count
            If RowCount > 0 Then
                Dim sbJobQtyUpdate As StringBuilder = New StringBuilder
                For i As Integer = 0 To RowCount - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridQuantity.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim quantity As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtQuantity"), TextBox)

                    If IsNumeric(quantity.Text) = False Then
                        Me.ShowMessage("Please enter a number for Quantity")
                        Exit Function
                    End If
                    If CInt(quantity.Text) > 2147483647 Then
                        Me.ShowMessage("Please enter a valid quantity for Quantity")
                        Exit Function
                    End If

                    If CurrentGridRow.GetDataKeyValue("EstimateNumber") = 0 Then
                        sbJobQtyUpdate.Append("UPDATE JOB_SPEC_QTY SET ")
                        sbJobQtyUpdate.Append("JOB_QTY = '" & js.EncodeSQL(quantity.Text) & "' ")
                        sbJobQtyUpdate.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_VER = " & Me.ddVersion.SelectedValue & " AND SPEC_REV = " & Me.ddRevision.SelectedValue & " AND SEQ_NBR = " & CurrentGridRow.GetDataKeyValue("SeqNum") & " ")
                    Else
                        sbJobQtyUpdate.Append("UPDATE ESTIMATE_REV SET ")
                        sbJobQtyUpdate.Append("JOB_QTY = '" & js.EncodeSQL(quantity.Text) & "' ")
                        sbJobQtyUpdate.Append(" WHERE ESTIMATE_NUMBER = " & CurrentGridRow.GetDataKeyValue("EstimateNumber") & " AND EST_COMPONENT_NBR = " & CurrentGridRow.GetDataKeyValue("CompNum") & " AND EST_QUOTE_NBR = " & CurrentGridRow.GetDataKeyValue("QuoteNum") & " AND EST_REV_NBR = " & CurrentGridRow.GetDataKeyValue("RevNum") & "; ")
                    End If

                    js.UpdateJob(sbJobQtyUpdate.ToString, Nothing, SaveSuccessful)

                    sbJobQtyUpdate.Clear()

                Next
            End If
            RowCount = Me.RadGridVendor.MasterTableView.Items.Count
            If RowCount > 0 Then
                Dim sbJobVendor As StringBuilder = New StringBuilder
                For i As Integer = 0 To RowCount - 1
                    Dim arParams(4) As SqlParameter
                    Dim parametertCloseDate As New SqlParameter("@cdate", SqlDbType.SmallDateTime)
                    Dim parametertRunDate As New SqlParameter("@rdate", SqlDbType.SmallDateTime)
                    Dim parametertExtDate As New SqlParameter("@edate", SqlDbType.SmallDateTime)

                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridVendor.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim vendor As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtVendor"), TextBox)
                    Dim closedate As RadDatePicker = CType(CurrentGridRow.FindControl("RadDatePickerClose_Date"), RadDatePicker)
                    Dim rundate As RadDatePicker = CType(CurrentGridRow.FindControl("RadDatePickerRun_Date"), RadDatePicker)
                    Dim extdate As RadDatePicker = CType(CurrentGridRow.FindControl("RadDatePickerExt_Date"), RadDatePicker)

                    Dim cldate As DateTime
                    Dim rudate As DateTime
                    Dim exdate As DateTime

                    If Not closedate.SelectedDate Is Nothing Then
                        If ValidDate(closedate) Then
                            cldate = CDate(closedate.SelectedDate)
                        Else
                            Me.ShowMessage("Invalid Completed Date")
                            Exit Function
                        End If
                    End If

                    If Not rundate.SelectedDate Is Nothing Then
                        If ValidDate(rundate) Then
                            rudate = CDate(rundate.SelectedDate)
                        Else
                            Me.ShowMessage("Invalid Run Date")
                            Exit Function
                        End If
                    End If

                    If Not extdate.SelectedDate Is Nothing Then
                        If ValidDate(extdate) Then
                            exdate = CDate(extdate.SelectedDate)
                        Else
                            Me.ShowMessage("Invalid Ext Date")
                            Exit Function
                        End If
                    End If

                    Dim Adsize As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAdSize"), TextBox)
                    Dim bleedsize As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtBleed_Size"), TextBox)
                    Dim trimsize As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtTrim_Size"), TextBox)
                    Dim livearea As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtLive_Area"), TextBox)
                    Dim screen As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtScreen"), TextBox)
                    Dim color As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtColor"), TextBox)
                    Dim status As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtStatus"), TextBox)
                    Dim region As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtRegion"), TextBox)
                    Dim density As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtDensity"), TextBox)
                    Dim film As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtFilm"), TextBox)
                    Dim shippingcomments As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtShipping_Comments"), TextBox)
                    Dim specialinstructions As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtSpecial_Instructions"), TextBox)

                    sbJobVendor.Append("UPDATE JOB_PUB_VENDOR SET ")
                    sbJobVendor.Append("VN_CODE = '" & js.EncodeSQL(vendor.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_CLOSE_DATE = CAST(@cdate AS VARCHAR), ")
                    If cldate = Nothing Then
                        parametertCloseDate.Value = DBNull.Value
                    Else
                        parametertCloseDate.Value = cldate
                    End If
                    arParams(0) = parametertCloseDate
                    sbJobVendor.Append("JOB_PUB_RUN_DATE = CAST(@rdate AS VARCHAR), ")
                    If rudate = Nothing Then
                        parametertRunDate.Value = DBNull.Value
                    Else
                        parametertRunDate.Value = rudate
                    End If
                    arParams(1) = parametertRunDate
                    sbJobVendor.Append("JOB_PUB_EXT_DATE = CAST(@edate AS VARCHAR), ")
                    If exdate = Nothing Then
                        parametertExtDate.Value = DBNull.Value
                    Else
                        parametertExtDate.Value = exdate
                    End If
                    arParams(2) = parametertExtDate

                    sbJobVendor.Append("JOB_PUB_BLEED_SIZE = '" & js.EncodeSQL(bleedsize.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_TRIM_SIZE = '" & js.EncodeSQL(trimsize.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_LIVE_AREA = '" & js.EncodeSQL(livearea.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_SCREEN = '" & js.EncodeSQL(screen.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_COLOR = '" & js.EncodeSQL(color.Text) & "', ")
                    If status.Text <> "" Then
                        sbJobVendor.Append("STATUS_CODE = '" & js.EncodeSQL(status.Text) & "', ")
                    Else
                        sbJobVendor.Append("STATUS_CODE = NULL, ")
                    End If
                    If region.Text <> "" Then
                        sbJobVendor.Append("REGION_CODE = '" & js.EncodeSQL(region.Text) & "', ")
                    Else
                        sbJobVendor.Append("REGION_CODE = NULL, ")
                    End If
                    If Adsize.Text <> "" Then
                        sbJobVendor.Append("AD_SIZE = '" & js.EncodeSQL(Adsize.Text) & "', ")
                    Else
                        sbJobVendor.Append("AD_SIZE = NULL, ")
                    End If
                    sbJobVendor.Append("JOB_PUB_DENSITY = '" & js.EncodeSQL(density.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_FILM = '" & js.EncodeSQL(film.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_SHIP_COMM = '" & js.EncodeSQL(shippingcomments.Text) & "', ")
                    sbJobVendor.Append("JOB_PUB_SPCL_INST = '" & js.EncodeSQL(specialinstructions.Text) & "' ")
                    sbJobVendor.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & CurrentGridRow.GetDataKeyValue("SPEC_ID") & "; ")

                    js.UpdateJob(sbJobVendor.ToString, arParams, SaveSuccessful)
                    sbJobVendor.Clear()

                Next
            End If
            RowCount = Me.RadGridVendor2.MasterTableView.Items.Count
            If RowCount > 0 Then
                Dim sbJobVendor2 As StringBuilder = New StringBuilder
                For i As Integer = 0 To RowCount - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridVendor2.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim vendor As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtVendor"), TextBox)
                    Dim Adsize As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAdSize"), TextBox)
                    Dim copyarea As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtCopy_Area"), TextBox)
                    Dim overallsize As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtOverall_Size"), TextBox)
                    Dim locationofsign As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtLocation_of_Sign"), TextBox)

                    sbJobVendor2.Append("UPDATE JOB_OUTDOOR_VENDOR SET ")
                    sbJobVendor2.Append("VN_CODE = '" & js.EncodeSQL(vendor.Text) & "', ")
                    sbJobVendor2.Append("JOB_OUT_COPY_AREA = '" & js.EncodeSQL(copyarea.Text) & "', ")
                    sbJobVendor2.Append("JOB_OUT_LOCATION = '" & js.EncodeSQL(locationofsign.Text) & "', ")
                    sbJobVendor2.Append("JOB_OUT_OVR_SIZE = '" & js.EncodeSQL(overallsize.Text) & "', ")
                    sbJobVendor2.Append("AD_SIZE = '" & js.EncodeSQL(Adsize.Text) & "' ")
                    sbJobVendor2.Append(" WHERE JOB_NUMBER = " & JobNum & " AND JOB_COMPONENT_NBR = " & JobCompNum & " AND SPEC_ID = " & CurrentGridRow.GetDataKeyValue("SPEC_ID") & "; ")

                    js.UpdateJob(sbJobVendor2.ToString, Nothing, SaveSuccessful)
                    sbJobVendor2.Clear()

                Next
            End If
        Catch ex As Exception

        End Try
    End Function

    Private Function CheckChanges(ByRef ojob As Job, ByRef strBody As String, ByRef dtchanges As DataTable) As Boolean
        Try
            Dim Changes As Boolean = False
            Dim js As New Job_Specs(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim ds As DataSet
            Dim ds2 As DataSet
            Dim data As DataTable = New DataTable
            strBody &= "Client: " & ojob.CL_CODE & " - " & ojob.ClientDesc & "<br />"
            strBody &= "Division: " & ojob.DIV_CODE & " - " & ojob.DivisionDesc & "<br />"
            strBody &= "Product: " & ojob.PRD_CODE & " - " & ojob.ProductDesc & "<br />"
            If Session("JSNewVersion") = "1" Then
                strBody &= "NEW SPECIFICATION CREATED!" & "<br />" & "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />" & "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            ElseIf Session("JSNewRevision") = "1" Then
                strBody &= vbCrLf & "NEW SPECIFICATION REVISION CREATED!" & "<br />" & "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />" & "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            Else
                strBody &= "Job: " & ojob.JOB_NUMBER & " - " & ojob.JOB_DESC & "<br />"
                strBody &= "Job Comp: " & ojob.JobComponent.JOB_COMPONENT_NBR & " - " & ojob.JobComponent.JOB_COMP_DESC & "<br />"
            End If
            strBody &= "Version: " & Me.ddVersion.SelectedValue & "<br />"
            strBody &= "Revision: " & Me.ddRevision.SelectedValue & "<br />" & "<br />"

            Dim type As String = js.GetJobSpecType(Me.JobNum, Me.JobCompNum)
            ds = js.GetJobSpecQtyVendorTabsDataSet(type)

            If Session("JSNewVersion") = "1" Then
                strBody &= "--------------------------------------" & "<br />"
                strBody &= "NEW VERSION DETAILS ARE AS FOLLOWS:" & "<br />"
                strBody &= "--------------------------------------" & "<br />"
                Dim i As Integer
                For i = 0 To Me.dtEdits.Rows.Count - 1
                    If Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        'If InStr(dtEdits.Rows(i)("ControlID"), "RadGrid_Quantity") > 0 Then
                        '    strBody &= "Quantity:  " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        If InStr(dtEdits.Rows(i)("ControlID"), "txtDesc") > 0 Then
                            strBody &= "Description:  " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                            'Else
                            '    strBody &= js.GetJobSpecFieldDesc(Me.dtEdits.Rows(i).Item(0).ToString(), Session("JSType")) & ":  " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        End If

                        'strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        'strBody &= "--------------------------------------" & "<br />"
                        'Changes = True
                    End If
                Next
                ds2 = js.GetJobSpecsDataSet(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                If ds2.Tables(0).Rows.Count <> 0 Then
                    For m As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        strBody &= ds2.Tables(0).Rows(m)("SHORT_DESC").ToString() & ":  " & Job_Specs.DecodeSQL(ds2.Tables(0).Rows(m)("FIELD_VALUE").ToString()) & "<br />"
                    Next
                End If
                If ds.Tables(0).Rows.Count <> 0 Then
                    If ds.Tables(0).Rows(0)("USE_QTY").ToString() = "1" Then
                        data = js.GetJobSpecsQtyDataWithEst(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                        For k As Integer = 0 To data.Rows.Count - 1
                            strBody &= "Quantity:  " & data.Rows(k).Item(9).ToString() & "<br />"
                            strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString() & "<br />"
                            strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString() & "<br />"
                            strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString() & "<br />"
                            strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString() & "<br />"
                        Next
                    End If
                End If

                If Session("JSAddJobVenRow") = "1" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 1)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If
                If Session("JSAddJobVenRow") = "2" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 2)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If
                'Changes = True
            ElseIf Session("JSNewRevision") = "1" Then
                strBody &= "--------------------------------------" & "<br />"
                strBody &= "NEW REVISION DETAILS ARE AS FOLLOWS:" & "<br />"
                strBody &= "--------------------------------------" & "<br />"
                Dim i As Integer
                For i = 0 To Me.dtEdits.Rows.Count - 1
                    If Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        'If InStr(dtEdits.Rows(i)("ControlID"), "RadGrid_Quantity") > 0 Then
                        '    strBody &= "Quantity:  " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        'Else
                        If InStr(dtEdits.Rows(i)("ControlID"), "txtDesc") > 0 Then
                            strBody &= "Description:  " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                            'Else
                            '    strBody &= js.GetJobSpecFieldDesc(Me.dtEdits.Rows(i).Item(0).ToString(), Session("JSType")) & ":  " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        End If

                        'strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString()& "<br />"
                        'strBody &= "--------------------------------------" & "<br />"
                        'Changes = True
                    End If
                Next
                ds2 = js.GetJobSpecsDataSet(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                If ds2.Tables(0).Rows.Count <> 0 Then
                    For m As Integer = 0 To ds2.Tables(0).Rows.Count - 1
                        strBody &= ds2.Tables(0).Rows(m)("SHORT_DESC").ToString() & ":  " & ds2.Tables(0).Rows(m)("FIELD_VALUE").ToString() & "<br />"
                    Next
                End If
                If ds.Tables(0).Rows.Count <> 0 Then
                    If ds.Tables(0).Rows(0)("USE_QTY").ToString() = "1" Then
                        data = js.GetJobSpecsQtyDataWithEst(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                        For k As Integer = 0 To data.Rows.Count - 1
                            strBody &= "Quantity:  " & data.Rows(k).Item(9).ToString() & "<br />"
                            strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString() & "<br />"
                            strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString() & "<br />"
                            strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString() & "<br />"
                            strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString() & "<br />"
                        Next
                    End If
                End If
                If Session("JSAddJobVenRow") = "1" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 1)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If
                If Session("JSAddJobVenRow") = "2" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 2)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If
                'Changes = True
            Else
                Dim myJobChangePlaceHolder As String = "|||JobSpecChanges|||"
                strBody &= myJobChangePlaceHolder
                'Job changes:
                Dim i As Integer
                For i = 0 To Me.dtEdits.Rows.Count - 1
                    Dim test As String = dtEdits.Rows(i)("ControlID").ToString
                    If Me.dtEdits.Rows(i).Item(2).ToString() <> Me.dtEdits.Rows(i).Item(3).ToString() Then
                        If InStr(dtEdits.Rows(i)("ControlID"), "RadGrid_Quantity") = 0 Or InStr(dtEdits.Rows(i)("ControlID"), "RadGrid_Quantity_Quantity") > 0 Then
                            If InStr(dtEdits.Rows(i)("ControlID"), "RadGrid_Quantity_Quantity") > 0 Then
                                strBody &= "Quantity" & "<br />"
                            ElseIf InStr(dtEdits.Rows(i)("ControlID"), "txtDesc") > 0 Then
                                strBody &= "Description" & "<br />"
                            Else
                                strBody &= js.GetJobSpecFieldDesc(Me.dtEdits.Rows(i).Item(0).ToString(), Session("JSType")) & "<br />"
                            End If
                            strBody &= "New Value: " & Me.dtEdits.Rows(i).Item(3).ToString() & "<br />"
                            strBody &= "Original Value: " & Me.dtEdits.Rows(i).Item(2).ToString() & "<br />"
                            strBody &= "--------------------------------------" & "<br />"
                            Changes = True
                        End If
                    End If
                Next

                If Session("JSAddJobQtyRow") = "1" Then
                    If ds.Tables(0).Rows.Count <> 0 Then
                        If ds.Tables(0).Rows(0)("USE_QTY").ToString() = "1" Then
                            data = js.GetJobSpecsQtyDataWithEst(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, CInt(Me.ddVersion.SelectedValue), CInt(Me.ddRevision.SelectedValue))
                            For k As Integer = 0 To data.Rows.Count - 1
                                strBody &= "Quantity:  " & data.Rows(k).Item(9).ToString() & "<br />"
                                strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString() & "<br />"
                                strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString() & "<br />"
                                strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString() & "<br />"
                                strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString() & "<br />"
                            Next
                        End If
                    End If
                End If

                If Session("JSAddJobVenRow") = "1" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 1)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If
                If Session("JSAddJobVenRow") = "2" Then
                    data = js.GetJobSpecsVendorData(ojob.JOB_NUMBER, ojob.JobComponent.JOB_COMPONENT_NBR, 2)
                    For k As Integer = 0 To data.Rows.Count - 1
                        strBody &= "Vendor:  " & data.Rows(k).Item(0).ToString() & "<br />"
                        'strBody &= "Estimate Number:  " & data.Rows(k).Item(2).ToString()& "<br />"
                        'strBody &= "Comp Num:  " & data.Rows(k).Item(3).ToString()& "<br />"
                        'strBody &= "Quote Num:  " & data.Rows(k).Item(4).ToString()& "<br />"
                        'strBody &= "Rev Num:  " & data.Rows(k).Item(5).ToString()& "<br />"
                    Next
                End If

                If Session("JSDelJobQtyRow") = "1" Then
                    strBody &= Session("JSDelJobQtyRowText")
                End If

                If Session("JSDelJobVenRow") = "1" Then
                    strBody &= Session("JSDelJobVenRowText")
                End If

                If Changes = True Then
                    Dim strHDR As String = String.Empty
                    strHDR &= "--------------------------------------" & "<br />"
                    strHDR &= "JOB SPEC CHANGES ARE AS FOLLOWS:" & "<br />"
                    strHDR &= "--------------------------------------" & "<br />"
                    strBody = Replace(strBody, myJobChangePlaceHolder, strHDR)
                Else
                    strBody = Replace(strBody, myJobChangePlaceHolder, "")
                End If

            End If
            strBody &= vbCrLf & "<br />"
            Session("JSAddJobQtyRow") = ""
            Session("JSDelJobVenRow") = ""
            Session("JSDelJobQtyRow") = ""
            Session("JSAddJobVenRow") = ""
            Return True
        Catch ex As Exception
            Me.ShowMessage("Error in CheckChanges" & ex.Message.ToString())
            'Return False
        Finally
        End Try
    End Function

    Private Sub jobspecs_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Select Case Me.EventArgument
            Case "DelRow"
                Try
                    Dim js As New Job_Specs(Session("ConnString"))
                    If js.GetJobSpecMaxRevision(Me.JobNum, Me.JobCompNum, Me.ddVersion.SelectedValue) > Me.ddRevision.SelectedValue Then
                        Me.ShowMessage("You can only delete rows from the max revision.")
                        Exit Sub
                    End If
                    Me.DeleteRowQtyVendor(Page)
                    Me.loadJobSpec()
                    Me.loadDescriptionReason()
                Catch ex As Exception
                    Me.ShowMessage("Error DeleteRows!<BR />" & ex.Message.ToString())
                End Try
        End Select
    End Sub

    Private Sub SendSilentEmail(ByVal EmailGroupCode As String, ByVal AlertTypeId As Integer, ByVal AlertCategoryId As Integer, ByVal AlertSubject As String,
                                ByVal AlertBody As String)
        Try
            Dim Employee As New cEmployee(CStr(Session("ConnString")))
            Dim EmailFlag As Integer
            Dim dr As SqlDataReader = GetEmailAddressFromGroup(EmailGroupCode)

            Dim oAlert As cAlerts = New cAlerts(CStr(Session("ConnString")))
            Dim AlertID As Integer
            AlertID = oAlert.AddAlerts(AlertTypeId, AlertCategoryId, AlertSubject, AlertBody, Now, "", Me.Client, Me.Division, Me.Product, "",
            Me.JobNum, Me.JobCompNum, Session("EmpCode"), "JC", Session("UserCode"))

            If Not dr Is Nothing Then
                If dr.HasRows = True Then

                    Dim wsEmail As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))

                    Dim EmpList As New System.Text.StringBuilder

                    Do While dr.Read()
                        Dim IsSelf As Boolean = False
                        If IsDBNull(dr(1)) = False Then
                            If dr(1).ToString().Trim() = HttpContext.Current.Session("ConnString") Then
                                IsSelf = True
                            End If
                            EmailFlag = Employee.GetAlertEmailFlag(dr.GetString(0))
                            If EmailFlag = 1 And IsSelf = False Then
                                With EmpList
                                    .Append(dr.GetString(0))
                                    .Append(",")
                                End With
                            ElseIf EmailFlag = 2 Then
                                oAlert.AddAlertRecipient(AlertID, dr.GetString(0), dr.GetString(1))
                            ElseIf EmailFlag = 3 Then
                                If IsSelf = False Then
                                    With EmpList
                                        .Append(dr.GetString(0))
                                        .Append(",")
                                    End With
                                End If
                                oAlert.AddAlertRecipient(AlertID, dr.GetString(0), dr.GetString(1))
                            End If
                        End If
                    Loop


                    Dim dtEmailList As New DataTable
                    Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), CStr(Session("UserCode")))
                    Dim StrEmps As String = EmpList.ToString()
                    StrEmps = MiscFN.CleanStringForSplit(StrEmps, ",")
                    dtEmailList = oTrafficSchedule.NotifyGetEmailEmployees(StrEmps)

                    If dtEmailList.Rows.Count > 0 Then
                        Dim SendToList As New System.Text.StringBuilder
                        Dim ws As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                        For i As Integer = 0 To dtEmailList.Rows.Count - 1
                            With SendToList
                                If dtEmailList.Rows(i)("EMP_CODE").ToString().Trim() <> HttpContext.Current.Session("EmpCode").ToString().Trim() Then
                                    .Append(dtEmailList.Rows(i)("MAILBEE_TITLE").ToString())
                                    .Append(",")
                                End If
                            End With
                        Next
                        Dim s As String = SendToList.ToString()
                        s = MiscFN.CleanStringForSplit(s, ",", False, True, True, False, True)
                        bool = ws.SendEmail("", s, AlertSubject, AlertBody, , , True, )
                        'If bool = False Then
                        '    Me.ShowMessage(ws.getErrMsg)
                        'End If
                        Me.CheckForAsyncMessage()
                    End If

                End If
            End If
        Catch ex As Exception
            Me.ShowMessage("Error in PopEmailUpdate conditional else case: " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub SetContentPageData()

        Dim cpd As New AdvantageFramework.Web.Classes.ContentPageData

        If cpd.Load() = True Then

            If Not Me.ddVersion.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddVersion.SelectedValue) = True Then cpd.JobSpecVersionID = CType(Me.ddVersion.SelectedValue, Integer)
            If Not Me.ddRevision.SelectedValue Is Nothing AndAlso IsNumeric(Me.ddRevision.SelectedValue) = True Then cpd.JobSpecRevisionID = CType(Me.ddRevision.SelectedValue, Integer)
            cpd.JobSpecReason = Me.txtReason.Text
            cpd.JobSpecDescription = Me.txtDesc.Text

            cpd.Save()

        End If

    End Sub

End Class
