Imports Telerik.Web.UI
Imports System.Data.SqlClient

Partial Public Class DesktopQvA
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "

    Public Enum PageMode

        AllQvA = 1
        MyQvA = 2

    End Enum

#End Region

#Region " Variables "

    Public CurrentPageMode As PageMode = PageMode.AllQvA

    Private CurrentDTO As cAppVars.Application = cAppVars.Application.ALL_QVA_DTO

    Private strTimeOnly As String = ""
    Private strThreshold As String = ""
    Private StrAEs As String = ""

#End Region

#Region " Properties "



#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Try

            If Not Request.QueryString("m") Is Nothing Then

                If IsNumeric(Request.QueryString("m")) = True Then

                    Me.CurrentPageMode = CType(CType(Request.QueryString("m"), Integer), PageMode)

                End If

            End If

        Catch ex As Exception

            Me.CurrentPageMode = PageMode.AllQvA

        End Try
        If Me.CurrentPageMode = PageMode.MyQvA Then

            Me.CurrentDTO = cAppVars.Application.MY_QVA_DTO

        End If

        If Me.CurrentPageMode = PageMode.AllQvA Then
            Me.CbLimitToMyJobs.Visible = False
        Else
            Me.CbLimitToMyJobs.Visible = True
        End If

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim printJS As String = ""
        Dim taskVar As String = ""
        Dim otask As cTasks = New cTasks(Session("ConnString"))
        Dim group As String = ""
        Dim grouptype As String = ""

        strTimeOnly = Me.ddQvAType.SelectedValue

        If Not Me.IsPostBack Then

            Dim oAppVars As New cAppVars(Me.CurrentDTO)
            oAppVars.getAllAppVars()


            If Me.IsClientPortal = False AndAlso oAppVars.HasAppVars = False Then

                oAppVars.setAppVar("ExcludeCA", Me.cbExcludeClientApproval.Checked.ToString(), "Boolean")
                oAppVars.setAppVar("ExcludeIA", Me.cbExcludeInternalApproval.Checked.ToString(), "Boolean")
                oAppVars.setAppVar("InclClosedJobs", Me.cbClosedJobs.Checked.ToString(), "Boolean")
                oAppVars.setAppVar("ProcessingAll", Me.cbAllProcessing.Checked.ToString(), "Boolean")
                oAppVars.setAppVar("SalesTax", Me.cbSalesTax.Checked.ToString(), "Boolean")
                oAppVars.setAppVar("Type", Me.ddQvAType.SelectedValue, "String")
                oAppVars.setAppVar("Search", "", "String")
                oAppVars.setAppVar("Threshold", Me.RadNumericTextBoxThreshold.Text, "String")
                oAppVars.setAppVar("SelectionLevel", "CDPC", "String")
                oAppVars.setAppVar("LimitMyJobs", Me.CbLimitToMyJobs.Checked.ToString(), "Boolean")

                oAppVars.SaveAllAppVars()

            End If

            taskVar = oAppVars.getAppVar("Type", "Boolean")

            If taskVar <> "" Then

                Me.ddQvAType.SelectedValue = taskVar

            End If

            Double.TryParse(oAppVars.getAppVar("Threshold", "", "100"), Me.RadNumericTextBoxThreshold.Value)
            Me.txtSearch.Text = oAppVars.getAppVar("Search")

            Try

                taskVar = oAppVars.getAppVar("ExcludeCA")

                If taskVar <> "" Then

                    Me.cbExcludeClientApproval.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("ExcludeIA")

                If taskVar <> "" Then

                    Me.cbExcludeInternalApproval.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("ProcessingAll")

                If taskVar <> "" Then

                    Me.cbAllProcessing.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("SalesTax")

                If taskVar <> "" Then

                    Me.cbSalesTax.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("SelectionLevel")

                If taskVar <> "" Then

                    Me.RblSelectionLevel.SelectedValue = taskVar

                End If

                taskVar = oAppVars.getAppVar("GroupJob")

                If taskVar <> "" Then

                    Me.RadToolbarButtonGroupJob.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("GroupCampaign")

                If taskVar <> "" Then

                    Me.RadToolbarButtonGroupCampaign.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("GroupCampaignMasterJob")

                If taskVar <> "" Then

                    Me.RadToolbarButtonGroupCampaignMaster.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("GroupCampaignJob")

                If taskVar <> "" Then

                    Me.RadToolbarButtonGroupCampaignJob.Checked = taskVar

                End If

                taskVar = oAppVars.getAppVar("LimitMyJobs")

                If taskVar <> "" Then

                    Me.CbLimitToMyJobs.Checked = taskVar

                End If

                Try

                    taskVar = oAppVars.getAppVar("InclClosedJobs", "Boolean", "False")

                    Me.cbClosedJobs.Checked = taskVar = "True"

                Catch ex As Exception
                End Try


            Catch ex As Exception

            End Try

            Me.MultiView1.ActiveViewIndex = 0

            LoadFilter()
            'Me.RadGridQVA.Rebind()

            If Me.RadNumericTextBoxThreshold.Value > 100 Then

                Me.RadNumericTextBoxThreshold.Value = 100

            ElseIf Me.RadNumericTextBoxThreshold.Value < 0 Then

                Me.RadNumericTextBoxThreshold.Value = 0

            End If

            If Me.CurrentPageMode = PageMode.MyQvA Then

                Me.TrAeOfficeSalesClassManagerFilters.Visible = False

            End If

        End If

        If Me.RadToolbarButtonGroupJob.Checked = True Then
            group = "job"
            'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = False
            Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
        End If

        If Me.RadToolbarButtonGroupCampaign.Checked = True Or RadToolbarButtonGroupCampaignJob.Checked = True Or RadToolbarButtonGroupCampaignMaster.Checked Then
            group = "campaign"
            Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = True
            If RadToolbarButtonGroupCampaignMaster.Checked = True Then
                Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
            Else
                Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = False
            End If
        End If

        If Me.RadToolbarButtonGroupCampaign.Checked = True Then
            grouptype = "campaign"
        ElseIf Me.RadToolbarButtonGroupCampaignJob.Checked = True Then
            grouptype = "job"
        ElseIf Me.RadToolbarButtonGroupCampaignMaster.Checked = True Then
            grouptype = "campaignmaster"
        Else
            grouptype = "job"
        End If

        With Me.RadToolbarQvA.FindItemByValue("ExportExcel").Attributes

            .Remove("onclick")
            .Add("onclick", "window.open('dtp_qva_all.aspx?m=" & CType(Me.CurrentPageMode, Integer).ToString() & "&threshold=" & Me.RadNumericTextBoxThreshold.Value.GetValueOrDefault(100) & "&timeonly=" & Me.ddQvAType.SelectedValue & "&export=1&group=" & group & "&grouptype=" & grouptype & "', 'PopLookup','screenX=100,left=100,screenY=150,top=150,width=100,height=100,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")

        End With

        With Me.RadToolbarQvA.FindItemByValue("Print").Attributes

            printJS = "Javascript:window.open('dtp_qva_all.aspx?m=" & CType(Me.CurrentPageMode, Integer).ToString() & "&threshold=" & Me.RadNumericTextBoxThreshold.Value.GetValueOrDefault(100) & _
            "&timeonly=" & Me.ddQvAType.SelectedValue & "&group=" & group & "&grouptype=" & grouptype & "', 'PopLookup','screenX=100,left=100,screenY=150,top=150,width=1050,height=400,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;"
            .Remove("onclick")
            .Add("onclick", printJS)

        End With

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridQVA)

    End Sub

#End Region

#Region " Controls Events "


    Private Sub ddQvAType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddQvAType.SelectedIndexChanged

        Dim oAppVars As New cAppVars(Me.CurrentDTO)
        oAppVars.setAppVarDB("Type", Me.ddQvAType.SelectedValue, "Boolean")
        Me.RadGridQVA.Rebind()

    End Sub

    Private Sub RadNumericTextBoxThreshold_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadNumericTextBoxThreshold.TextChanged

        Dim oAppVars As New cAppVars(Me.CurrentDTO)
        oAppVars.setAppVarDB("Threshold", Me.RadNumericTextBoxThreshold.Text)
        Me.RadGridQVA.Rebind()

    End Sub

    Private Sub RadGridQVA_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQVA.ItemDataBound
        Try
            Dim jobtemp As Job_Template = New Job_Template(Session("ConnString"))
            Dim dt As New DataTable

            Dim QueryTypeID As String = "All"

            If Me.CurrentPageMode = PageMode.MyQvA Then

                QueryTypeID = "My"

            End If

            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim FlagColorDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivFlagColor")
                GetColor(FlagColorDiv, e.Item.DataItem("Quoted"), e.Item.DataItem("Actual"))

                Dim ViewImage As WebControls.ImageButton = e.Item.Cells(0).FindControl("ImageButtonViewDetails")
                If Me.RadToolbarButtonGroupJob.Checked = True Then
                    Me.HookUpOpenWindow(ViewImage, "QuoteVsActualSummaryPopup.aspx?JobNo=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value & "&JobComp=0&group=job")
                ElseIf Me.RadToolbarButtonGroupCampaign.Checked = True Then
                    Me.HookUpOpenWindow(ViewImage, "QuoteVsActualSummaryPopup.aspx?CampaignID=" & CType(e.Item.FindControl("HfCampaignID"), HiddenField).Value & "&JobComp=0&group=campaign&grouptype=campaign&DO=" & QueryTypeID)
                ElseIf Me.RadToolbarButtonGroupCampaignJob.Checked = True Then
                    Me.HookUpOpenWindow(ViewImage, "QuoteVsActualSummaryPopup.aspx?CampaignID=" & CType(e.Item.FindControl("HfCampaignID"), HiddenField).Value & "&JobComp=0&group=campaign&grouptype=job&DO=" & QueryTypeID)
                ElseIf Me.RadToolbarButtonGroupCampaignMaster.Checked = True Then
                    Me.HookUpOpenWindow(ViewImage, "QuoteVsActualSummaryPopup.aspx?CampaignID=" & CType(e.Item.FindControl("HfCampaignID"), HiddenField).Value & "&JobComp=0&group=campaign&grouptype=campaignmaster&DO=" & QueryTypeID)
                Else
                    Me.HookUpOpenWindow(ViewImage, "QuoteVsActualSummaryPopup.aspx?JobNo=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value & "&JobComp=" & CType(e.Item.FindControl("HfJobCompNumber"), HiddenField).Value)
                End If

                Dim ViewLinkButton As System.Web.UI.WebControls.LinkButton = e.Item.Cells(2).FindControl("ViewLinkButton")
                If Me.RadToolbarButtonGroupJob.Checked = True Then
                    ViewLinkButton.Text = e.Item.DataItem("Job")
                    dt = jobtemp.GetJobsForTemplateGrid(Session("UserCode"), "", "", "", CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value, "", "", "", "", False, "", Me.IsClientPortal, Session("UserID"))
                    If dt.Rows.Count > 1 Then
                        Me.HookUpOpenWindow(ViewLinkButton, "JobTemplate_Search.aspx?f=2&j=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value)
                    Else
                        Me.HookUpOpenWindow(ViewLinkButton, "Content.aspx?PageMode=Edit&JobNum=" & dt.Rows(0)("JOB_NUMBER").ToString() & "&JobCompNum=" & dt.Rows(0)("JOB_COMPONENT_NBR").ToString() & "&NewComp=0")
                    End If
                Else
                    ViewLinkButton.Text = e.Item.DataItem("JobAndComp")
                    Me.HookUpOpenWindow(ViewLinkButton, "Content.aspx?PageMode=Edit&JobNum=" & CType(e.Item.FindControl("HfJobNumber"), HiddenField).Value & "&JobCompNum=" & CType(e.Item.FindControl("HfJobCompNumber"), HiddenField).Value & "&NewComp=0")
                End If

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQVA_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQVA.NeedDataSource
        Try

            Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
            Dim client As String = ""
            Dim division As String = ""
            Dim product As String = ""
            Dim office As String = ""
            Dim group As String = ""
            Dim grouptype As String = ""

            Dim sLoadLevel As String = Me.RblSelectionLevel.SelectedValue.ToUpper
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sSalesClass As String = ""
            Dim sManager As String = ""
            Dim sAEs As String = ""
            Dim sJobs As String = ""
            Dim sComps As String = ""
            Dim sm As String = ""

            BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs, sSalesClass, sManager, sJobs, sComps, office)

            If office = "ALL" Then office = ""
            If sSalesClass = "ALL" Then sSalesClass = ""
            If sManager = "ALL" Then sManager = ""
            If sAEs = "ALL," Then sAEs = ""

            Dim QueryTypeID As String = "All"

            If Me.CurrentPageMode = PageMode.MyQvA Then

                QueryTypeID = "My"

                sAEs = "" 'CStr(Session("EmpCode"))
                office = ""
                sSalesClass = ""
                sManager = ""

            End If

            If Me.RadToolbarButtonGroupJob.Checked = True Then
                group = "job"
            End If

            If Me.RadToolbarButtonGroupCampaign.Checked = True Or RadToolbarButtonGroupCampaignJob.Checked = True Or RadToolbarButtonGroupCampaignMaster.Checked Then
                group = "campaign"
            End If

            If Me.RadToolbarButtonGroupCampaign.Checked = True Then
                grouptype = "campaign"
            ElseIf Me.RadToolbarButtonGroupCampaignJob.Checked = True Then
                grouptype = "job"
            ElseIf Me.RadToolbarButtonGroupCampaignMaster.Checked = True Then
                grouptype = "campaignmaster"
            Else
                grouptype = "job"
            End If

            Me.RadGridQVA.DataSource = oDO.GetQVA(sAEs, sClients, sDivisions, sProducts, _
                                                  Me.ddQvAType.SelectedValue, Session("UserCode"), _
                                                  Me.txtSearch.Text, QueryTypeID, office, _
                                                  sSalesClass, sManager, sJobs, sComps, sCampaigns, group, grouptype)

        Catch ex As Exception

        End Try
    End Sub
    Private Sub RadGridQVA_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridQVA.PreRender

        Session("DOSortExp") = Me.RadGridQVA.MasterTableView.SortExpressions.GetSortString

        Session("DOFilterExp") = Me.RadGridQVA.MasterTableView.FilterExpression

    End Sub

    Private Sub RadToolbarQvA_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarQvA.ButtonClick

        Try
            Select Case e.Item.Value

                Case "QvA"

                    Me.MultiView1.SetActiveView(ViewMain)
                    Me.RadGridQVA.MasterTableView.CurrentPageIndex = 0
                    Me.RadGridQVA.Rebind()
                    CType(Me.RadToolbarQvA.FindItemByValue("QvA"), RadToolBarButton).Checked = True

                Case "FilterView"

                    Me.LoadFilterView()
                    CType(Me.RadToolbarQvA.FindItemByValue("FilterView"), RadToolBarButton).Checked = True

                Case "Refresh"

                    Me.LblMSG.Text = ""
                    If Me.RadNumericTextBoxThreshold.Value.HasValue = False Then

                        Me.LblMSG.Text = "Invalid threshold"

                    Else
                        Dim oAppVars As New cAppVars(Me.CurrentDTO)
                        oAppVars.setAppVarDB("Threshold", Me.RadNumericTextBoxThreshold.Value.ToString())
                        oAppVars.setAppVarDB("Search", Me.txtSearch.Text)
                        Me.RadGridQVA.Rebind()
                    End If

                Case "GroupJob"
                    Dim oAppVars As New cAppVars(Me.CurrentDTO)
                    oAppVars.setAppVarDB("GroupJob", Me.RadToolbarButtonGroupJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaign", Me.RadToolbarButtonGroupCampaign.Checked)
                    oAppVars.setAppVarDB("GroupCampaignJob", Me.RadToolbarButtonGroupCampaignJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaignMasterJob", Me.RadToolbarButtonGroupCampaignMaster.Checked)
                    'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = False
                    Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
                    Me.RadGridQVA.Rebind()

                Case "GroupJobCampaign"
                    Dim oAppVars As New cAppVars(Me.CurrentDTO)

                    oAppVars.setAppVarDB("GroupJob", Me.RadToolbarButtonGroupJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaign", Me.RadToolbarButtonGroupCampaign.Checked)
                    oAppVars.setAppVarDB("GroupCampaignJob", Me.RadToolbarButtonGroupCampaignJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaignMasterJob", Me.RadToolbarButtonGroupCampaignMaster.Checked)
                    If Me.RadToolbarButtonGroupCampaign.Checked = True Then
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = True
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = False
                    Else
                        'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = False
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
                    End If
                    Me.RadGridQVA.Rebind()

                Case "GroupJobCampaignJob"
                    Dim oAppVars As New cAppVars(Me.CurrentDTO)

                    oAppVars.setAppVarDB("GroupJob", Me.RadToolbarButtonGroupJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaign", Me.RadToolbarButtonGroupCampaign.Checked)
                    oAppVars.setAppVarDB("GroupCampaignJob", Me.RadToolbarButtonGroupCampaignJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaignMasterJob", Me.RadToolbarButtonGroupCampaignMaster.Checked)
                    If Me.RadToolbarButtonGroupCampaignJob.Checked = True Then
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = True
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = False
                    Else
                        ' Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = False
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
                    End If
                    Me.RadGridQVA.Rebind()

                Case "GroupJobCampaignMaster"
                    Dim oAppVars As New cAppVars(Me.CurrentDTO)

                    oAppVars.setAppVarDB("GroupJob", Me.RadToolbarButtonGroupJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaign", Me.RadToolbarButtonGroupCampaign.Checked)
                    oAppVars.setAppVarDB("GroupCampaignJob", Me.RadToolbarButtonGroupCampaignJob.Checked)
                    oAppVars.setAppVarDB("GroupCampaignMasterJob", Me.RadToolbarButtonGroupCampaignMaster.Checked)
                    If Me.RadToolbarButtonGroupCampaignMaster.Checked = True Then
                        Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = True
                        'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = False
                    Else
                        ' Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("columnCampaign").Display = False
                        'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Display = True
                    End If
                    Me.RadGridQVA.Rebind()

                Case "Bookmark"

                    Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                    Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                    Dim qs As New AdvantageFramework.Web.QueryString()

                    qs = qs.FromCurrent()

                    With b

                        If Me.CurrentPageMode = PageMode.MyQvA Then
                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_MyQVA
                            .UserCode = Session("UserCode")
                            .Name = "QvA (My)"
                            .Description = "QvA (My)"
                            .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")
                        Else
                            .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_QVA
                            .UserCode = Session("UserCode")
                            .Name = "QvA (All)"
                            .Description = "QvA (All)"
                            .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")
                        End If

                    End With

                    Dim s As String = ""
                    If BmMethods.SaveBookmark(b, s) = False Then
                        Me.ShowMessage(s)
                    Else
                        Me.RefreshBookmarksDesktopObject()

                    End If

                Case "ExportExcel", "ExportPDF"

                    'Dim str As String = ""

                    'str = Me.CurrentPageMode.ToString() & AdvantageFramework.StringUtilities.GUID_Date(True, False, False, False)


                    'With Me.RadGridQVA.ExportSettings

                    '    .ExportOnlyData = True
                    '    .FileName = str
                    '    .IgnorePaging = True
                    '    .OpenInNewWindow = True

                    'End With

                    'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Visible = False
                    'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridBoundColumnProject").Visible = True

                    'If e.Item.Value = "ExportExcel" Then

                    '    Me.RadGridQVA.MasterTableView.ExportToExcel()

                    'ElseIf e.Item.Value = "ExportPDF" Then

                    '    Me.RadGridQVA.MasterTableView.ExportToPdf()

                    'End If

                    'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridTemplateColumnProject").Visible = True
                    'Me.RadGridQVA.MasterTableView.Columns.FindByUniqueName("GridBoundColumnProject").Visible = False

            End Select

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        End Try

    End Sub
    Private Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles BtnSave.Click

        Me.SaveFilter()

    End Sub

    Private Sub RblSelectionLevel_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles RblSelectionLevel.SelectedIndexChanged

        Me.LoadCDPCListBox()

    End Sub

#End Region

#Region " Methods "

    Private Sub GetColor(ByRef Div As HtmlControls.HtmlControl, ByVal Quoted As Decimal, ByVal Actual As Decimal)

        Dim dThresh As Double = 0

        If Me.RadNumericTextBoxThreshold.Value.HasValue Then

            dThresh = Me.RadNumericTextBoxThreshold.Value

        End If

        AdvantageFramework.Web.Presentation.Controls.SetFlagColor(Div, dThresh, Quoted, Actual)

    End Sub

    Private Sub loadSCListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        ' Get both Production & Media sales classes
        SQL_STRING = "SELECT SC_CODE as code, SC_CODE + ' - ' + SC_DESCRIPTION as description FROM SALES_CLASS WHERE INACTIVE_FLAG = 0 Or INACTIVE_FLAG Is NULL"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            With Me.LBSC
                .DataSource = dr
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()

                .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
            End With

            PopulateSalesClassListbox()
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:loadSCListbox", Err.Description)
        Finally
        End Try

    End Sub

    Private Sub LoadFilterView()
        Try

            strTimeOnly = Me.ddQvAType.SelectedValue

            If IsNumeric(Me.RadNumericTextBoxThreshold.Text.Trim) Then

                strThreshold = Me.RadNumericTextBoxThreshold.Text.Trim

            Else

                strThreshold = "100"

            End If

            ''If Not Me.IsPostBack And Not Me.Page.IsCallback Then
            'Dim otask As New cTasks(Session("ConnString"))
            'If otask.getAppVars(Session("UserCode"), Me.CurrentPageMode.ToString(), "MyProjectsOnly") = "" Then

            '    otask.setAppVars(Session("UserCode"), Me.CurrentPageMode.ToString(), "MyProjectsOnly", "System.Boolean", "True")

            'End If
            ''End If

            Me.MultiView1.ActiveViewIndex = 1
            Me.MultiView1.SetActiveView(ViewFilter)

            LoadFilterObjects()

            LoadAEListbox()
            LoadOfficeListbox()
            loadSCListbox()
            LoadManagerListbox()

            PopulateCDPListbox()

            If Me.IsClientPortal = True Then

                Me.RblSelectionLevel.Items().FindByValue("CLIENT").Enabled = False

            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadFilter()
        Try

            strTimeOnly = Me.ddQvAType.SelectedValue

            If IsNumeric(Me.RadNumericTextBoxThreshold.Text.Trim) Then

                strThreshold = Me.RadNumericTextBoxThreshold.Text.Trim

            Else

                strThreshold = "100"

            End If


            'Dim otask As New cTasks(Session("ConnString"))
            'If otask.getAppVars(Session("UserCode"), Me.CurrentPageMode.ToString(), "MyProjectsOnly") = "" Then

            '    otask.setAppVars(Session("UserCode"), Me.CurrentPageMode.ToString(), "MyProjectsOnly", "Boolean", "True")
            'End If


            LoadAEListbox()
            LoadOfficeListbox()
            loadSCListbox()
            LoadManagerListbox()

            PopulateCDPListbox()
            LoadFilterObjects()

            If Me.IsClientPortal = True Then

                Me.RblSelectionLevel.Items().FindByValue("CLIENT").Enabled = False

            End If


        Catch ex As Exception

        End Try
    End Sub
    Private Sub LoadAEListbox()
        Dim ocPV As cProjectViewpoint = New cProjectViewpoint(CStr(Session("ConnString")))

        Me.LbAEs.ClearSelection()

        With Me.LbAEs
            .DataSource = ocPV.GetAEList("", "", "", CStr(Session("UserCode")))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()

            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
        End With

        PopulateAEListbox()

    End Sub
    Private Sub LoadManagerListbox()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        Me.RadListBoxManager.ClearSelection()

        With Me.RadListBoxManager
            .DataSource = oDD.GetManagers(Session("UserCode"))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()

            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
        End With

        PopulateManagerListbox()

    End Sub
    Private Sub LoadOfficeListbox()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        Me.LBOffice.ClearSelection()

        With Me.LBOffice
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()

            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
        End With

        PopulateOfficeListbox()

    End Sub
    Private Sub LoadCDPCListBox()

        Dim CDPList As String = ""
        Dim AEList As String = ""
        Dim OfficeList As String = ""
        Dim FilterString As String = ""
        Dim AEIDX As Integer
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

        Dim MyObjDef As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), Nothing)
        Dim HasDynamicRestriction As Boolean = False

        HasDynamicRestriction = MyObjDef.EmployeeHasDynamicRestriction(Session("EmpCode"), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA)

        If Me.CurrentPageMode = PageMode.AllQvA Then

            HasDynamicRestriction = False

        End If

        'Gather AE's to filter CDP list & Project Viewpoint by
        For AEIDX = 0 To Me.LbAEs.Items.Count - 1
            If Me.LbAEs.Items.Item(AEIDX).Selected = True Then
                If AEList = "" Then
                    If Me.LbAEs.Items.Item(AEIDX).Value = "ALL" Then
                        AEList = "ALL"
                        Exit For
                    End If
                    AEList = "('" & Me.LbAEs.Items.Item(AEIDX).Value & "'"
                Else
                    AEList = AEList & ",'" & Me.LbAEs.Items.Item(AEIDX).Value & "'"
                End If
            End If
        Next
        If AEList <> "ALL" And AEList <> "" Then
            AEList &= ")"
        End If

        Dim SQL As New System.Text.StringBuilder

        If AEList <> "ALL" Then ' Or OfficeList <> "ALL" Then

            If Me.RblSelectionLevel.SelectedValue = "CAMPAIGN" Then

                SQL.Append("SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) ")
                SQL.Append(" FROM CAMPAIGN C ")
                SQL.Append(" INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE ")
                SQL.Append(" LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE ")
                SQL.Append(" LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE ")
                SQL.Append(" INNER JOIN ACCOUNT_EXECUTIVE AE ON C.CL_CODE = AE.CL_CODE  ")
                SQL.Append("   AND ( C.DIV_CODE = AE.DIV_CODE OR C.DIV_CODE IS NULL) ")
                SQL.Append("   AND ( C.PRD_CODE = AE.PRD_CODE OR C.PRD_CODE IS NULL) ")
                SQL.Append("   AND AE.EMP_CODE IN ")
                SQL.Append(AEList)
                SQL.Append(" WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )")

                If HasDynamicRestriction = True Then

                    SQL.Append(" UNION ")

                    SQL.Append("SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) ")
                    SQL.Append(" FROM CAMPAIGN C ")
                    SQL.Append(" INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE ")
                    SQL.Append(" LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE ")
                    SQL.Append(" LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE ")
                    SQL.Append(" INNER JOIN ACCOUNT_EXECUTIVE AE ON C.CL_CODE = AE.CL_CODE  ")
                    SQL.Append("   AND ( C.DIV_CODE = AE.DIV_CODE OR C.DIV_CODE IS NULL) ")
                    SQL.Append("   AND ( C.PRD_CODE = AE.PRD_CODE OR C.PRD_CODE IS NULL) ")
                    SQL.Append("   AND AE.EMP_CODE IN ")
                    SQL.Append(AEList)
                    SQL.Append("  INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](")
                    SQL.Append(CType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects, Integer).ToString())
                    SQL.Append(" ,'")
                    SQL.Append(Session("EmpCode"))
                    SQL.Append("') AS DR ON DR.CL_CODE = C.CL_CODE  ")
                    SQL.Append(" AND ((D.DIV_CODE = DR.DIV_CODE) OR (D.DIV_CODE IS NULL)) ")
                    SQL.Append(" AND ((P.PRD_CODE = DR.PRD_CODE) OR (P.PRD_CODE IS NULL)) ")
                    SQL.Append(" WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )")

                End If


            Else


                SQL.Append("SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE ")
                SQL.Append(" FROM         PRODUCT INNER JOIN")
                SQL.Append("                      ACCOUNT_EXECUTIVE AS AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND ")
                SQL.Append("                      PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN")
                SQL.Append("                      DIVISION INNER JOIN")
                SQL.Append("                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE")
                SQL.Append(" WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND AE.EMP_CODE IN " & AEList)
                SQL.Append(" AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) ")

                If HasDynamicRestriction = True Then

                    SQL.Append(" UNION ")

                    SQL.Append("SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE ")
                    SQL.Append(" FROM         PRODUCT INNER JOIN")
                    SQL.Append("                      ACCOUNT_EXECUTIVE AS AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND ")
                    SQL.Append("                      PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN")
                    SQL.Append("                      DIVISION INNER JOIN")
                    SQL.Append("                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE")
                    SQL.Append("  INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](")
                    SQL.Append(CType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects, Integer).ToString())
                    SQL.Append(" ,'")
                    SQL.Append(Session("EmpCode"))
                    SQL.Append("') AS DR ON DR.CL_CODE = CLIENT.CL_CODE  ")
                    SQL.Append(" AND ((DIVISION.DIV_CODE = DR.DIV_CODE) OR (DIVISION.DIV_CODE IS NULL)) ")
                    SQL.Append(" AND ((PRODUCT.PRD_CODE = DR.PRD_CODE) OR (PRODUCT.PRD_CODE IS NULL)) ")
                    SQL.Append(" WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND AE.EMP_CODE IN " & AEList)
                    SQL.Append(" AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) ")

                End If

            End If

        Else 'No AE's from listbox to restrict CDP

            If Me.RblSelectionLevel.SelectedValue = "CAMPAIGN" Then

                SQL.Append("SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) ")
                SQL.Append(" FROM CAMPAIGN C ")
                SQL.Append(" INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE ")
                SQL.Append(" LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE ")
                SQL.Append(" LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE ")
                SQL.Append(" WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )")

                If HasDynamicRestriction = True Then

                    SQL.Append(" UNION ")

                    SQL.Append("SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) ")
                    SQL.Append(" FROM CAMPAIGN C ")
                    SQL.Append(" INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE ")
                    SQL.Append(" LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE ")
                    SQL.Append(" LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE ")
                    SQL.Append("  INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](")
                    SQL.Append(CType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects, Integer).ToString())
                    SQL.Append(" ,'")
                    SQL.Append(Session("EmpCode"))
                    SQL.Append("') AS DR ON DR.CL_CODE = C.CL_CODE  ")
                    SQL.Append(" AND ((D.DIV_CODE = DR.DIV_CODE) OR (D.DIV_CODE IS NULL)) ")
                    SQL.Append(" AND ((P.PRD_CODE = DR.PRD_CODE) OR (P.PRD_CODE IS NULL)) ")
                    SQL.Append(" WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )")

                End If

            Else

                SQL.Append(" SELECT DISTINCT PRODUCT.CL_CODE, PRODUCT.DIV_CODE, PRODUCT.PRD_CODE ")
                SQL.Append(" FROM CLIENT")
                SQL.Append(" INNER JOIN DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE ")
                SQL.Append(" INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE ")
                SQL.Append(" WHERE PRODUCT.ACTIVE_FLAG = 1 And CLIENT.ACTIVE_FLAG = 1 And DIVISION.ACTIVE_FLAG = 1 ")

                If HasDynamicRestriction = True Then

                    SQL.Append(" UNION ")

                    SQL.Append(" SELECT DISTINCT PRODUCT.CL_CODE, PRODUCT.DIV_CODE, PRODUCT.PRD_CODE ")
                    SQL.Append(" FROM CLIENT")
                    SQL.Append(" INNER JOIN DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE ")
                    SQL.Append(" INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE ")
                    SQL.Append("  INNER JOIN [dbo].[fn_my_objects_get_dynamic_restrictions](")
                    SQL.Append(CType(AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects, Integer).ToString())
                    SQL.Append(" ,'")
                    SQL.Append(Session("EmpCode"))
                    SQL.Append("') AS DR ON DR.CL_CODE = CLIENT.CL_CODE  ")
                    SQL.Append(" AND ((DIVISION.DIV_CODE = DR.DIV_CODE) OR (DIVISION.DIV_CODE IS NULL)) ")
                    SQL.Append(" AND ((PRODUCT.PRD_CODE = DR.PRD_CODE) OR (PRODUCT.PRD_CODE IS NULL)) ")
                    SQL.Append(" WHERE PRODUCT.ACTIVE_FLAG = 1 And CLIENT.ACTIVE_FLAG = 1 And DIVISION.ACTIVE_FLAG = 1 ")

                End If

            End If

        End If

        Try

            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL.ToString())

        Catch

            'Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:AddControl", Err.Description)

        Finally
        End Try

        AEIDX = 0
        If dr.HasRows And Me.RblSelectionLevel.SelectedValue <> "JOB" And Me.RblSelectionLevel.SelectedValue <> "COMP" Then
            Do While dr.Read
                If CDPList = "" Then
                    CDPList = "("
                Else
                    CDPList = CDPList & ","
                End If
                Try
                    Select Case Me.RblSelectionLevel.SelectedValue
                        Case "CDPC"
                            'Exit Sub ' No filter
                            CDPList = ""
                        Case "CLIENT"
                            CDPList = CDPList & "'" & dr.GetString(0) & "'"
                        Case "DIVISION"
                            CDPList = CDPList & "'" & dr.GetString(0) & ":" & dr.GetString(1) & "'"
                        Case "PRODUCT"
                            CDPList = CDPList & "'" & dr.GetString(0) & ":" & dr.GetString(1) & ":" & dr.GetString(2) & "'"
                        Case "CAMPAIGN"
                            CDPList = CDPList & "'" & dr.GetString(0) & ":" & dr.GetString(1) & ":" & dr.GetString(2) & ":" & dr.GetString(3) & ":" & dr(4) & "'"
                    End Select
                Catch ex As Exception
                    'CDPList = ""
                End Try
            Loop

        Else
            CDPList = ""
        End If

        If CDPList = "(" Then

            CDPList = ""
        End If
        If CDPList <> "" Then

            CDPList = CDPList & ")"
        End If
        dr.Close()


        Me.LbCDPCSelections.Items.Clear()

        Dim dtData As DataTable = New DataTable
        Dim dtDataFiltered As DataTable = New DataTable
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.LbCDPCSelections

            Select Case Me.RblSelectionLevel.SelectedValue
                Case "CDPC"

                    .Enabled = False
                    .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
                    Exit Sub

                Case "CLIENT"

                    .Enabled = True

                    If HasDynamicRestriction = True Then

                        dtData.Load(oDD.GetClientListAE(Session("UserCode"), _
                                        AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))
                    Else

                        dtData.Load(oDD.GetClientList(Session("UserCode")))

                    End If


                Case "DIVISION"

                    .Enabled = True

                    If Me.IsClientPortal = True Then

                        dtData = Me.GetDivisionsAllCP(Session("UserID"))

                    Else

                        If HasDynamicRestriction = True Then

                            dtData.Load(oDD.GetDivisionListAE(Session("UserCode"), "", _
                                            AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))


                        Else

                            dtData.Load(oDD.GetDivisionsAll(Session("UserCode")))

                        End If

                    End If

                Case "PRODUCT"

                    .Enabled = True

                    If Me.IsClientPortal = True Then

                        dtData = Me.GetProductsAllCP(Session("UserID"))

                    Else

                        If HasDynamicRestriction = True Then

                            dtData.Load(oDD.GetProductListAE(Session("UserCode"), "", "", _
                                                             AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))


                        Else

                            dtData.Load(oDD.GetProductsAll(Session("UserCode")))

                        End If

                    End If

                Case "CAMPAIGN"

                    .Enabled = True

                    If Me.IsClientPortal = True Then

                        dtData = Me.GetAllCampaignsWithCDPCP(Session("UserID"))

                    Else

                        If HasDynamicRestriction = True Then

                            dtData.Load(oDD.GetAllCampaignsAE(Session("UserCode"), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))

                        Else

                            dtData.Load(oDD.GetAllCampaignsWithCDP(Session("UserCode")))

                        End If

                    End If


                Case "JOB"

                    .Enabled = True

                    If Me.IsClientPortal = True Then

                        dtData.Load(oDD.GetJobList(Session("UserCode"), JobListType.JobJacket, Me.cbClosedJobs.Checked, ""))

                    Else

                        If HasDynamicRestriction = True Then

                            dtData.Load(oDD.GetJobListAE(Session("UserCode"), Me.cbClosedJobs.Checked,
                                                         AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))

                        Else

                            dtData.Load(oDD.GetJobList(Session("UserCode"), JobListType.JobJacket, Me.cbClosedJobs.Checked, ""))

                        End If

                    End If

                Case "COMP"

                    .Enabled = True

                    If Me.IsClientPortal = True Then

                        dtData.Load(oDD.GetJobCompListJJ(Session("UserCode"), Me.cbClosedJobs.Checked))

                    Else

                        If HasDynamicRestriction = True Then

                            dtData.Load(oDD.GetJobComponentListAE(Session("UserCode"), Me.cbClosedJobs.Checked, _
                                                                  AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.MyQvA))

                        Else

                            dtData.Load(oDD.GetJobCompListJJ(Session("UserCode"), Me.cbClosedJobs.Checked))

                        End If

                    End If

            End Select

            Dim CodeField As String = "Code"
            Dim TextField As String = "Description"

            If HasDynamicRestriction = True Then

                Select Case Me.RblSelectionLevel.SelectedValue

                    Case "DIVISION", "PRODUCT"

                        CodeField = "SplitPK"
                        TextField = "DescriptionWithExtra"

                End Select

            End If


            If AEList = "ALL" Then

                .DataSource = dtData
                .DataValueField = CodeField
                .DataTextField = TextField
                .DataBind()

            Else

                If CDPList <> "" Then

                    Dim dv As DataView = New DataView(dtData)

                    dv.RowFilter = CodeField & " IN " & CDPList
                    dtDataFiltered = dv.ToTable()

                    .DataSource = dtDataFiltered
                    .DataValueField = CodeField
                    .DataTextField = TextField
                    .DataBind()

                Else

                    .DataSource = dtData
                    .DataValueField = CodeField
                    .DataTextField = TextField
                    .DataBind()

                End If

            End If

            Try
                If dtData IsNot Nothing Then dtData.Dispose()
            Catch ex As Exception
            End Try
            Try
                If dtDataFiltered IsNot Nothing Then dtDataFiltered.Dispose()
            Catch ex As Exception
            End Try


        End With

    End Sub
    Private Sub LoadFilterObjects()
        Dim strValue As String
        Dim boolVal As Boolean
        Dim tempDate As Date
        Dim mthStr, yrStr As String
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim NeedsSave As Boolean = False
        Dim appVars As New cAppVars(Me.CurrentDTO)

        tempDate = cEmployee.TimeZoneToday
        mthStr = CType(tempDate.Month, String)
        mthStr = mthStr.ToString.PadLeft(2, "0")
        yrStr = CType(tempDate.Year, String)

        appVars.getAllAppVars()

        strValue = appVars.getAppVar("InclClosedJobs", "Boolean", "False")
        Me.cbClosedJobs.Checked = CType(strValue, Boolean)

        strValue = appVars.getAppVar("Type", "Boolean", "False")
        Me.ddQvAType.SelectedValue = strValue

        strValue = appVars.getAppVar("SalesTax", "Boolean", "False")
        Me.cbSalesTax.Checked = CType(strValue, Boolean)

        strValue = appVars.getAppVar("LimitMyJobs", "Boolean", "False")
        Me.CbLimitToMyJobs.Checked = CType(strValue, Boolean)

        strValue = appVars.getAppVar("Threshold", "100")
        If IsNumeric(strValue) = False Then

            strValue = "100"

        End If

        Me.RadNumericTextBoxThreshold.Text = strValue

    End Sub

    Private Sub PopulateAEListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim ae As String

        Me.LbAEs.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & "' AND APPLICATION = '" & Me.CurrentDTO.ToString() & "' AND VARIABLE_NAME = 'AE'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateAEListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                ae = dr.GetString(0)
                Dim str() As String = ae.Split(",")
                Try
                    For i As Integer = 0 To str.Length - 1
                        LbAEs.FindItemByValue(str(i)).Selected = True
                    Next
                Catch ex As Exception
                End Try
            Loop

        Else
            LbAEs.FindItemByValue("ALL").Selected = True
        End If
        dr.Close()
    End Sub
    Private Sub PopulateOfficeListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim office As String

        Me.LBOffice.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & "' AND APPLICATION = '" & Me.CurrentDTO.ToString() & "' AND VARIABLE_NAME = 'OFFICE'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateOfficeListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                office = dr.GetString(0)
                Dim str() As String = office.Split(",")
                Try
                    For i As Integer = 0 To str.Length - 1
                        LBOffice.FindItemByValue(str(i)).Selected = True
                    Next
                Catch ex As Exception
                End Try
            Loop
        Else
            SetOfficeToAll()
        End If
        dr.Close()
    End Sub
    Private Sub PopulateManagerListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim Manager As String

        Me.RadListBoxManager.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) &
                        "' AND APPLICATION = '" & Me.CurrentDTO.ToString() & "' AND VARIABLE_NAME = 'MANAGER'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateManagerListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                Manager = dr.GetString(0)
                Dim str() As String = Manager.Split(",")
                Try
                    For i As Integer = 0 To str.Length - 1
                        RadListBoxManager.FindItemByValue(str(i)).Selected = True
                    Next
                Catch ex As Exception
                End Try
            Loop
        Else
            SetManagerToAll()
        End If
        dr.Close()
    End Sub
    Private Sub PopulateSalesClassListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim sc As String

        Me.LBSC.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & "' AND APPLICATION = '" & Me.CurrentDTO.ToString() & "' AND VARIABLE_NAME = 'SC'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateOfficeListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                sc = dr.GetString(0)
                Dim str() As String = sc.Split(",")
                Try
                    For i As Integer = 0 To str.Length - 1
                        LBSC.FindItemByValue(str(i)).Selected = True
                    Next
                Catch ex As Exception
                End Try
            Loop
        Else
            SetSCToAll()
        End If
        dr.Close()
    End Sub
    Private Sub PopulateCDPListbox()
        Try
            Dim oSQL As SqlHelper
            Dim SQL_STRING, SQL_STRING2 As String
            Dim dr, dr2 As SqlDataReader
            Dim CDPCString, CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, DESCRIPTION As String
            Dim CDPLoadLevel As Integer = 0
            Dim cmp_id As Integer
            Dim lbLoaded As Boolean = False
            Dim taskVar As String

            LoadCDPCListBox()

            Dim oAppVars As New cAppVars(Me.CurrentDTO)
            oAppVars.getAllAppVars()

            Select Case Me.RblSelectionLevel.SelectedValue
                Case "CDPC" 'This is "all"...no criteria set
                    'no save needed to cdp and campaign table
                Case "CLIENT"
                    taskVar = oAppVars.getAppVar("CLIENT")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If
                Case "DIVISION"
                    taskVar = oAppVars.getAppVar("DIVISION")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If
                Case "PRODUCT"
                    taskVar = oAppVars.getAppVar("PRODUCT")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If
                Case "CAMPAIGN"
                    taskVar = oAppVars.getAppVar("CAMPAIGN")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If
                Case "JOB"
                    taskVar = oAppVars.getAppVar("JOB")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If
                Case "COMP"
                    taskVar = oAppVars.getAppVar("COMP")
                    Dim arCDP() As String
                    If taskVar <> "" Then
                        Try
                            arCDP = taskVar.Split(",")
                            For x As Integer = 0 To arCDP.Length - 1
                                For i As Integer = 0 To RblSelectionLevel.Items.Count - 1
                                    LbCDPCSelections.FindItemByValue(arCDP(x).ToString).Selected = True
                                Next
                            Next
                        Catch ex As Exception
                        End Try
                    End If

            End Select


        Catch ex As Exception

        End Try
    End Sub

    Private Sub SaveFilter()
        Try

            Dim thresh As Integer = 0

            If IsNumeric(RadNumericTextBoxThreshold.Text) = False Then

                Me.LblMSG.Text = "Invalid threshold"
                Me.RadNumericTextBoxThreshold.Focus()
                Exit Sub

            Else

                thresh = CType(Me.RadNumericTextBoxThreshold.Text, Integer)
                If thresh > 100 Then
                    thresh = 100
                ElseIf thresh < 0 Then
                    thresh = 0
                End If

            End If
            RadNumericTextBoxThreshold.Text = thresh.ToString()

            Dim sLoadLevel As String = Me.RblSelectionLevel.SelectedValue.ToUpper
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sAEs As String = ""
            Dim sSalesClass As String = ""
            Dim sManager As String = ""
            Dim sJobs As String = ""
            Dim sComps As String = ""
            Dim sOffices As String = ""
            Dim sm As String = ""

            Dim savefilter As String = True
            savefilter = BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs, sSalesClass, sManager, sJobs, sComps, sOffices)

            If savefilter = False Then
                Exit Sub
            End If

            sm = Me.SaveSelections(sLoadLevel, sAEs, sSelectionsBase)

            If sm <> "" Then
                Me.LblMSG.Text = sm
                Exit Sub
            End If

            Dim mth, yr, days As Integer
            Dim startDate, endDate As String
            Dim tempDate As Date

            If Me.cbClosedJobs.Checked Then
                Session("inclClosedJobsQvA") = "Y"
            Else
                Session("inclClosedJobsQvA") = "N"
            End If

            '0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
            Select Case Me.RblSelectionLevel.SelectedValue
                Case "CDPC"
                    Session("cdpcLevelQvA") = "0"
                Case "CLIENT"
                    Session("cdpcLevelQvA") = "1"
                Case "DIVISION"
                    Session("cdpcLevelQvA") = "2"
                Case "PRODUCT"
                    Session("cdpcLevelQvA") = "3"
                Case "CAMPAIGN"
                    Session("cdpcLevelQvA") = "4"
                Case "JOB"
                    Session("cdpcLevelQvA") = "5"
                Case "COMP"
                    Session("cdpcLevelQvA") = "6"
            End Select

            If sAEs.Length > 0 And sAEs <> "'ALL'" Then
                Session("inclAEQvA") = "Y"
            Else
                Session("inclAEQvA") = "N"
            End If
        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString()
            Exit Sub
        End Try
        'Me.GoBack()
        CType(Me.RadToolbarQvA.FindItemByValue("QvA"), RadToolBarButton).Checked = True
        Me.MultiView1.ActiveViewIndex = 0
        Me.MultiView1.SetActiveView(Me.ViewMain)
        Me.RadGridQVA.Rebind()
    End Sub

    Private Sub SetOfficeToAll()
        LBOffice.FindItemByValue("ALL").Selected = True
    End Sub
    Private Sub SetManagerToAll()
        Me.RadListBoxManager.FindItemByValue("ALL").Selected = True
    End Sub
    Private Sub SetCDPCToAll()
        'Set default for CDPC selection:
        Me.RblSelectionLevel.SelectedIndex = 0
        With Me.LbCDPCSelections
            .Items.Clear()
            .Enabled = False
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
        End With
    End Sub
    Private Sub SetSCToAll()
        LBSC.FindItemByValue("ALL").Selected = True
    End Sub

    Public Function GetAllCampaignsWithCDP(ByVal UserID As String) As DataTable
        Dim dt As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllCampaignsWithCDP", "tblcmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetAllCampaignsWithCDP", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetAllCampaignsWithCDPCP(ByVal CPID As Integer) As DataTable
        Dim dt As DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_cp_dd_GetAllCampaignsWithCDP", "tblcmp", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetAllCampaignsWithCDPCP", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetProductsAll(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllProducts_withCnD", "tblprd", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetProductsAll", Err.Description)
        End Try

        Return dt
    End Function
    Public Function GetProductsAllCP(ByVal CPID As Integer) As DataTable
        Dim dt As New DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_cp_dd_GetAllProducts_withCnD", "tblprd", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetProductsAllCP", Err.Description)
        End Try

        Return dt
    End Function

    Public Function GetDivisionsAll(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllDivisions_withclient", "tblcdiv", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetDivisionsAll", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetDivisionsAllCP(ByVal CPID As Integer) As DataTable
        Dim dt As New DataTable
        Dim oSQL As SqlHelper
        Dim arParams(0) As SqlParameter

        Dim parameterCPID As New SqlParameter("@CPID", SqlDbType.Int)
        parameterCPID.Value = CPID
        arParams(0) = parameterCPID

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_cp_dd_GetAllDivisions_withclient", "tblcdiv", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetDivisionsAllCP", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetClientList(ByVal UserID As String) As DataTable
        Dim dt As New DataTable
        Dim oSQL As SqlHelper
        Dim arParams(2) As SqlParameter

        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID
        arParams(0) = parameterUserID

        Dim parameterFromApp As New SqlParameter("@FromApp", SqlDbType.VarChar, 6)
        parameterFromApp.Value = ""
        arParams(1) = parameterFromApp

        Try
            dt = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetClients", "tblclient", arParams)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter.aspx Routine:GetClientList", Err.Description)
        End Try

        Return dt

    End Function
    Public Function GetJobList(ByVal UserID As String, ByVal ShowAll As Boolean) As DataTable
        Dim dr As DataTable
        Dim oSQL As SqlHelper

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            If ShowAll = True Then
                dr = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket_withClosed", "dt", parameterUserID)
            Else
                dr = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobsJobJacket", "dt", parameterUserID)
            End If

        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobList", Err.Description)
        End Try

        Return dr
    End Function
    Public Function GetJobCompListJJ(ByVal UserID As String, ByVal ShowAll As Boolean) As DataTable
        Dim dr As DataTable
        Dim oSQL As SqlHelper

        '*** Create Parameters
        Dim parameterUserID As New SqlParameter("@UserID", SqlDbType.VarChar, 100)
        parameterUserID.Value = UserID

        Try
            If ShowAll = True Then
                dr = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ_withClosed", "dt", parameterUserID)
            Else
                dr = oSQL.ExecuteDataTable(CStr(Session("ConnString")), CommandType.StoredProcedure, "usp_wv_dd_GetAllJobCompsJJ", "dt", parameterUserID)
            End If
        Catch
            Err.Raise(Err.Number, "Class:cDropDowns Routine:GetJobCompList", Err.Description)
        End Try

        Return dr
    End Function


    Private Function SaveSelections(ByVal LoadLevel As String, ByVal AESelectionString As String, ByVal CDPCSelectionString As String) As String

        Dim value As String = ""
        Dim UserCode As String = Session("UserCode")
        Dim SbSQL As New System.Text.StringBuilder
        Dim SbSQLDelete As New System.Text.StringBuilder
        Dim StrSQL As String = ""
        Dim appVars As New cAppVars(Me.CurrentDTO)

        appVars.setAppVar("InclClosedJobs", Me.cbClosedJobs.Checked.ToString(), "Boolean")
        appVars.setAppVar("Type", Me.ddQvAType.SelectedValue, "String")

        If IsNumeric(Me.RadNumericTextBoxThreshold.Text) = False Then

            Me.LblMSG.Text = "Invalid threshold"
            Exit Function

        Else

            appVars.setAppVar("Threshold", Me.RadNumericTextBoxThreshold.Text, "String")

        End If

        appVars.setAppVar("SelectionLevel", Me.RblSelectionLevel.SelectedValue, "String")
        appVars.setAppVar("ExcludeCA", Me.cbExcludeClientApproval.Checked, "Boolean")
        appVars.setAppVar("ExcludeIA", Me.cbExcludeInternalApproval.Checked, "Boolean")
        appVars.setAppVar("ProcessingAll", Me.cbAllProcessing.Checked, "Boolean")
        appVars.setAppVar("SalesTax", Me.cbSalesTax.Checked, "Boolean")
        appVars.setAppVar("Search", Me.txtSearch.Text, "String")
        appVars.setAppVar("LimitMyJobs", Me.CbLimitToMyJobs.Checked, "Boolean")

        appVars.SaveAllAppVars()

        Try

            'Save Selected Office values from listbox.
            If Me.CurrentPageMode = PageMode.AllQvA Then

                For i As Integer = 0 To Me.LBOffice.Items.Count - 1
                    If Me.LBOffice.Items(i).Selected = True Then
                        If Me.LBOffice.Items(i).Value = "ALL" Then
                            value = Me.LBOffice.Items(i).Value
                        Else
                            value &= Me.LBOffice.Items(i).Value & ","
                        End If
                        If i = 0 And value = "ALL" Then Exit For
                    End If
                Next

                With SbSQL
                    .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                    .Append(UserCode)
                    .Append("','" & Me.CurrentDTO.ToString() & "','0','OFFICE',")
                    .Append("'String','")
                    .Append(value)
                    .Append("');")
                End With


                value = ""

                'Save Selected Sales Class values from listbox.
                For i As Integer = 0 To Me.LBSC.Items.Count - 1
                    If Me.LBSC.Items(i).Selected = True Then
                        If Me.LBSC.Items(i).Value = "ALL" Then
                            value = Me.LBSC.Items(i).Value
                        Else
                            value &= Me.LBSC.Items(i).Value & ","
                        End If
                        If i = 0 And value = "ALL" Then Exit For
                    End If
                Next
                With SbSQL
                    .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                    .Append(UserCode)
                    .Append("','" & Me.CurrentDTO.ToString() & "','0','SC',")
                    .Append("'String','")
                    .Append(value)
                    .Append("');")
                End With

                value = ""

                'Save Selected Manager values from listbox.
                For i As Integer = 0 To Me.RadListBoxManager.Items.Count - 1
                    If Me.RadListBoxManager.Items(i).Selected = True Then
                        If Me.RadListBoxManager.Items(i).Value = "ALL" Then
                            value = Me.RadListBoxManager.Items(i).Value
                        Else
                            value &= Me.RadListBoxManager.Items(i).Value & ","
                        End If
                        If i = 0 And value = "ALL" Then Exit For
                    End If
                Next
                With SbSQL
                    .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                    .Append(UserCode)
                    .Append("','" & Me.CurrentDTO.ToString() & "','0','MANAGER',")
                    .Append("'String','")
                    .Append(value)
                    .Append("');")
                End With

                value = ""
                'Save Selected AEs values from listbox.
                For i As Integer = 0 To Me.LbAEs.Items.Count - 1
                    If Me.LbAEs.Items(i).Selected = True Then
                        If Me.LbAEs.Items(i).Value = "ALL" Then
                            value = Me.LbAEs.Items(i).Value
                        Else
                            value &= Me.LbAEs.Items(i).Value & ","
                        End If
                        If i = 0 And value = "ALL" Then Exit For
                    End If
                Next
                With SbSQL
                    .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                    .Append(UserCode)
                    .Append("','" & Me.CurrentDTO.ToString() & "','0','AE',")
                    .Append("'String','")
                    .Append(value)
                    .Append("');")
                End With

            End If

            If CDPCSelectionString.Trim() <> "" Then

                Dim j As Integer = 0
                Dim arCDP() As String
                arCDP = CDPCSelectionString.Split(",")

                Select Case LoadLevel
                    Case "CDPC" 'This is "all"...no criteria set
                        'no save needed to cdp and campaign table
                    Case "CLIENT"
                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','CLIENT',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With
                    Case "DIVISION"
                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','DIVISION',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With
                    Case "PRODUCT"
                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','PRODUCT',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With
                    Case "CAMPAIGN"
                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','CAMPAIGN',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With
                    Case "JOB"
                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','JOB',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With
                    Case "COMP"

                        With SbSQL
                            .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                            .Append(UserCode)
                            .Append("','" & Me.CurrentDTO.ToString() & "','0','COMP',")
                            .Append("'String','")
                            .Append(CDPCSelectionString)
                            .Append("');")
                        End With

                End Select
            End If

            StrSQL = SbSQL.ToString()

            'Save:
            If StrSQL.Trim() <> "" Then
                Using MyConn As New SqlConnection(CStr(Session("ConnString")))
                    MyConn.Open()
                    Dim MyTrans As SqlTransaction = MyConn.BeginTransaction
                    Dim MyCmd As New SqlCommand(StrSQL, MyConn, MyTrans)
                    Try
                        MyCmd.ExecuteNonQuery()
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                        Return "Error saving selection SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Return ""
        Catch ex As Exception
            Return "Error saving filter selections:&nbsp;&nbsp;" & ex.Message.ToString()
        End Try
    End Function
    Private Function BuildCodeStrings(ByVal LoadLevel As String, ByRef StrSelectionsBase As String, ByRef StrClients As String, ByRef StrDivisions As String, ByRef StrProducts As String, ByRef StrCampaigns As String, ByRef StrAEs As String, _
                                      ByRef StrSalesClass As String, ByRef StrManagers As String, ByRef StrJobs As String, ByRef StrComps As String, ByRef StrOffices As String) As Boolean
        Try
            'Build code strings:
            '===================================================================================
            'AE's
            For i As Integer = 0 To Me.LbAEs.Items.Count - 1
                If Me.LbAEs.Items(i).Selected = True Then
                    StrAEs &= "" & Me.LbAEs.Items(i).Value & ","
                    If i = 0 And Me.LbAEs.Items(i).Value = "ALL" Then Exit For
                End If
            Next
            StrAEs = MiscFN.RemoveDuplicatesFromString(StrAEs, ",") & ","
            'StrAEs = MiscFN.RemoveTrailingDelimiter(StrAEs, ",")

            'SalesClass
            For i As Integer = 0 To Me.LBSC.Items.Count - 1
                If Me.LBSC.Items(i).Selected = True Then
                    StrSalesClass &= "" & Me.LBSC.Items(i).Value & ","
                    If i = 0 And Me.LBSC.Items(i).Value = "ALL" Then Exit For
                End If
            Next
            StrSalesClass = MiscFN.RemoveDuplicatesFromString(StrSalesClass, ",")
            StrSalesClass = MiscFN.RemoveTrailingDelimiter(StrSalesClass, ",")

            'Manager
            For i As Integer = 0 To Me.RadListBoxManager.Items.Count - 1
                If Me.RadListBoxManager.Items(i).Selected = True Then
                    StrManagers &= "" & Me.RadListBoxManager.Items(i).Value & ","
                    If i = 0 And Me.RadListBoxManager.Items(i).Value = "ALL" Then Exit For
                End If
            Next
            StrManagers = MiscFN.RemoveDuplicatesFromString(StrManagers, ",")
            StrManagers = MiscFN.RemoveTrailingDelimiter(StrManagers, ",")

            'Office
            For i As Integer = 0 To Me.LBOffice.Items.Count - 1
                If Me.LBOffice.Items(i).Selected = True Then
                    StrOffices &= "" & Me.LBOffice.Items(i).Value & ","
                    If i = 0 And Me.LBOffice.Items(i).Value = "ALL" Then Exit For
                End If
            Next
            StrOffices = MiscFN.RemoveDuplicatesFromString(StrOffices, ",")
            StrOffices = MiscFN.RemoveTrailingDelimiter(StrOffices, ",")

            'Selection Level:
            For j As Integer = 0 To Me.LbCDPCSelections.Items.Count - 1
                If Me.LbCDPCSelections.Items(j).Selected = True Then
                    StrSelectionsBase &= Me.LbCDPCSelections.Items(j).Value & ","
                End If
            Next
            StrSelectionsBase = MiscFN.RemoveDuplicatesFromString(StrSelectionsBase, ",")
            StrSelectionsBase = MiscFN.RemoveTrailingDelimiter(StrSelectionsBase, ",")

            'Selection Level:
            Dim k As Integer = 0
            Dim ar() As String
            ar = StrSelectionsBase.Split(",")

            If ar(0).ToString() = "" And Me.RblSelectionLevel.SelectedValue <> "CDPC" And Me.RblSelectionLevel.SelectedValue <> "" Then
                Me.ShowMessage("Please select at least one item from list")
                Me.LbCDPCSelections.Focus()
                Return False
            End If

            Select Case LoadLevel
                Case "CDPC", "" 'This is "all"...no criteria set
                    'Make sure all empty:
                    StrClients = ""
                    StrDivisions = ""
                    StrProducts = ""
                    StrCampaigns = ""
                Case "CLIENT"
                    'Parse:
                    For k = 0 To ar.Length - 1
                        StrClients &= ar(k).ToString() & ","
                    Next
                    StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                    StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                    'Make sure empty:
                    StrDivisions = ""
                    StrProducts = ""
                    StrCampaigns = ""
                Case "DIVISION"
                    'Parse:
                    For k = 0 To ar.Length - 1

                        Dim ar2(1) As String
                        ar2 = ar(k).Split(":")
                        StrClients &= ar2(0).ToString() & ","
                        StrDivisions &= ar2(1).ToString() & ","
                    Next
                    StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                    StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                    StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                    StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")

                    'Make sure empty:
                    StrProducts = ""
                    StrCampaigns = ""
                Case "PRODUCT"
                    'Parse:
                    For k = 0 To ar.Length - 1
                        Dim ar2(2) As String
                        ar2 = ar(k).Split(":")
                        StrClients &= ar2(0).ToString() & ","
                        StrDivisions &= ar2(1).ToString() & ","
                        StrProducts &= ar2(2).ToString() & ","
                    Next
                    StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                    StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                    StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                    StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")
                    StrProducts = MiscFN.RemoveDuplicatesFromString(StrProducts, ",")
                    StrProducts = MiscFN.RemoveTrailingDelimiter(StrProducts, ",")

                    'Make sure empty:
                    StrCampaigns = ""
                Case "CAMPAIGN"
                    'Parse all:
                    For k = 0 To ar.Length - 1
                        Dim ar2(3) As String
                        ar2 = ar(k).Split(":")
                        StrClients &= ar2(0).ToString() & ","
                        StrDivisions &= ar2(1).ToString() & ","
                        StrProducts &= ar2(2).ToString() & ","
                        StrCampaigns &= ar2(4).ToString() & ","
                    Next
                    StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                    StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                    StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                    StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")
                    StrProducts = MiscFN.RemoveDuplicatesFromString(StrProducts, ",")
                    StrProducts = MiscFN.RemoveTrailingDelimiter(StrProducts, ",")
                    'StrCampaigns = MiscFN.RemoveDuplicatesFromString(StrCampaigns, ",")
                    'StrCampaigns = MiscFN.RemoveTrailingDelimiter(StrCampaigns, ",")
                Case "JOB"
                    'Parse:
                    For k = 0 To ar.Length - 1
                        StrJobs &= ar(k).ToString() & ","
                    Next
                    StrClients = ""
                    StrDivisions = ""
                    StrProducts = ""
                    StrCampaigns = ""
                Case "COMP"
                    'Parse:
                    For k = 0 To ar.Length - 1
                        Dim arj() As String = ar(k).Split("-")
                        StrJobs &= arj(0).ToString() & ","
                        StrComps &= arj(1).ToString() & ","
                    Next
                    StrClients = ""
                    StrDivisions = ""
                    StrProducts = ""
                    StrCampaigns = ""
            End Select
            Return True
        Catch ex As Exception

        End Try
    End Function

#End Region

End Class
