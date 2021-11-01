Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports Webvantage.cGlobals
Imports Telerik.Web.UI

Partial Public Class DesktopProjectViewpoint
    Inherits Webvantage.BaseDesktopObject

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    'AciveViewIndex:
    '0 = ViewMain
    '1 = BudgetView
    '2 = Hours Viewpoint
    ' Private p As ParentPage = CType(Me.Page.Master, ParentPage)
    Private viewidx As Integer = 0

    Private strThreshold As String
    Private strTimeOnly As String
    Private dr_QvA As System.Data.DataTableReader
    Private dr_Alerts As SqlDataReader
    Private dr_jobSpecs As SqlDataReader
    Private dt_jobSpecs As DataTable
    Private IsFloat As Boolean = False
    Private StrAEs As String = ""

#End Region

#Region " Properties "

    Private Property CurrentNumberOfPages As Integer = 0
    Private Property CurrentPageNumber() As Integer
        Get

            Try

                If ViewState("RadGridProjectViewpointMainCurrentPageNumber") Is Nothing Then ViewState("RadGridProjectViewpointMainCurrentPageNumber") = 0
                Return CInt(ViewState("RadGridProjectViewpointMainCurrentPageNumber"))

            Catch ex As Exception
                Return 0
            End Try

        End Get
        Set(ByVal value As Integer)
            ViewState("RadGridProjectViewpointMainCurrentPageNumber") = value
        End Set
    End Property

#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init


        Dim otask As cTasks = New cTasks(Session("ConnString"))

        'objects
        Dim HasAccessToDocuments As Boolean = False

        HasAccessToDocuments = Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManagerLevels_JobComponent, False))

        Try

            RadGridProjectViewpointMain.Columns.FindByUniqueName("documents").Display = HasAccessToDocuments

        Catch ex As Exception

        End Try

        Try
            If Not Session("currentPVView") Is Nothing Then
                viewidx = Session("currentPVView")

                If viewidx < Me.MultiView1.Views.Count Then
                    Me.MultiView1.ActiveViewIndex = viewidx
                End If

            End If
        Catch ex As Exception
        End Try

        If IsClientPortal = True Then

            Me.RadToolbarProjectViewpoint.FindItemByValue("FilterView").Visible = False

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridProjectViewpointMain)

        If Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket) = False Then

            Me.RadToolbarProjectViewpoint.FindItemByValue("NewJob").Visible = False
            Me.RadToolbarProjectViewpoint.FindItemByValue("SeparatorNewJob").Visible = False

        End If

        If Not Me.IsPostBack And Not Me.Page.IsCallback Then

            Me.CurrentPageNumber = 0
            'Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            If otask.hasAppVars(Session("UserCode"), "PROJECTVIEWPOINT") = False And IsClientPortal = False Then
                SaveInitialFilter()
            End If
            SetSessionVars()
            Dim hasAccess As Boolean

            'hasAccess = CheckDOAccess("Hours Viewpoint")

            Me.RadToolbarProjectViewpoint.FindItemByValue("HoursViewpoint").Enabled = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DesktopObjects_HoursViewpointDO, False) = 1

            ' ''Add functionality to export main grid to excel
            ''Me.HookUpProjectExport()

            If otask.getAppVars(Session("UserCode"), "PROJECTVIEWPOINT", "SelectionLevel") = "CAMPAIGN" Then
                Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint").Enabled = False
            Else
                'hasAccess = CheckDOAccess("Budget Viewpoint")

                Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint").Enabled = Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DesktopObjects_BudgetViewpointDO, False) = 1

            End If

            Dim cPV As cProjectViewpoint = New cProjectViewpoint()
            Select Case Me.MultiView1.ActiveViewIndex
                Case -1 'None set yet
                    'Session("switchingViews") = False
                    Me.MultiView1.ActiveViewIndex = 0
                    CType(Me.RadToolbarProjectViewpoint.FindItemByValue("ProjectViewpoint"), RadToolBarButton).Checked = True
                    'SetSessionVars()
                    LoadGrid()
                    Session("previdx") = 0
                    Session("currentPVView") = 0
                Case 0
                    CType(Me.RadToolbarProjectViewpoint.FindItemByValue("ProjectViewpoint"), RadToolBarButton).Checked = True
                Case 1
                    CType(Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint"), RadToolBarButton).Checked = True
                Case 2
                    CType(Me.RadToolbarProjectViewpoint.FindItemByValue("HoursViewpoint"), RadToolBarButton).Checked = True
                Case 3
                    CType(Me.RadToolbarProjectViewpoint.FindItemByValue("FilterView"), RadToolBarButton).Checked = True
            End Select

            If viewidx = 3 Then
                Me.LoadFilterView()
                CType(Me.RadToolbarProjectViewpoint.FindItemByValue("FilterView"), RadToolBarButton).Checked = True
            End If
            Session("PVDOSortExp") = ""
            Session("BVDOSortExp") = ""
            Session("HVDOSortExp") = ""
        Else

            Select Case Me.EventArgument

            End Select

        End If

        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("RefreshActuals"), RadToolBarButton).Enabled = CType(Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint"), RadToolBarButton).Checked

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridProjectViewpointMain)


        If Me.IsClientPortal = True Then

            AddHandler RadGridProjectViewpointMain.HeaderContextMenu.ItemCreated, AddressOf HeaderContextMenuItemCreated

        End If

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim h As GridHeaderItem
            If Not RadGridProjectViewpointMain.MasterTableView.GetItems(GridItemType.Header)(0) Is Nothing Then
                Me.HideIconHeaderLabels(TryCast(RadGridProjectViewpointMain.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem))
            End If
        Catch ex As Exception
        End Try

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Dim ScheduleMethods As New cSchedule()
            Me.LabelManager.Text = ScheduleMethods.GetManagerLabel()

        End If

        If Me.IsClientPortal = True Then
            Me.RadToolbarProjectViewpoint.FindItemByValue("Bookmark").Visible = False
        End If

        Try
            Me.RadGridProjectViewpointMain.CurrentPageIndex = Me.CurrentPageNumber
        Catch ex As Exception
            Me.RadGridProjectViewpointMain.CurrentPageIndex = 0
        End Try

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadToolbarProjectViewpoint_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarProjectViewpoint.ButtonClick
        Select Case e.Item.Value
            Case "Refresh"
                Me.RefreshAction()
            Case "ProjectViewpoint"

                Session("currentPVView") = 0

                Me.MultiView1.SetActiveView(ViewMain)
                Me.RadGridProjectViewpointMain.MasterTableView.CurrentPageIndex = 0
                LoadGrid()
                CType(Me.RadToolbarProjectViewpoint.FindItemByValue("ProjectViewpoint"), RadToolBarButton).Checked = True

            Case "BudgetViewpoint"
                Dim cPV As cProjectViewpoint = New cProjectViewpoint()

                Me.MultiView1.SetActiveView(ViewBudgetView)
                Me.RadGridBudgetView.MasterTableView.CurrentPageIndex = 0

                LoadGridBV()

                Me.LabelLastRefreshed.Text = getLastRefreshed()
                Me.lblFilterOption.Text = cPV.getForecastOption()

                Session("currentPVView") = 1

                ''Me.HookUpBudgetExport()

                CType(Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint"), RadToolBarButton).Checked = True
            Case "HoursViewpoint"

                Me.MultiView1.SetActiveView(HoursViewpoint)
                Me.RadGridHoursView.MasterTableView.CurrentPageIndex = 0

                LoadGridHV()

                Session("currentPVView") = 2

                ''Me.HookUpHoursExport()

                CType(Me.RadToolbarProjectViewpoint.FindItemByValue("HoursViewpoint"), RadToolBarButton).Checked = True

            Case "NewJob"

                Me.OpenWindow("New Job", "JobTemplate_New.aspx", 720, 1200)

            Case "FilterView"

                Session("currentPVView") = 3
                Me.LoadFilterView()
                CType(Me.RadToolbarProjectViewpoint.FindItemByValue("FilterView"), RadToolBarButton).Checked = True

            Case "RefreshActuals"

                refreshActuals()
                LoadGridBV()
                Me.LabelLastRefreshed.Text = getLastRefreshed()
                Session("currentPVView") = 1

            Case "Bookmark"

                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.ProjectManagement_ProjectViewpoint
                    .UserCode = Session("UserCode")
                    .Name = "Project Viewpoint"
                    .Description = "Project Viewpoint"
                    .PageURL = "DesktopObjectLoadWindow.aspx" & qs.ToString().Replace("&bm=1", "")

                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                Else
                    Me.RefreshBookmarksDesktopObject()

                End If

            Case "Export"

                Select Case Me.MultiView1.ActiveViewIndex

                    Case 0 'Main Project Viewpoint

                        Try

                            Dim dt As New DataTable

                            With dt.Columns

                                .Add(New DataColumn("Client"))
                                .Add(New DataColumn("Project"))
                                .Add(New DataColumn("AE"))
                                .Add(New DataColumn("Start"))
                                .Add(New DataColumn("Due/Completed"))
                                .Add(New DataColumn("Status"))

                            End With

                            Me.RadGridProjectViewpointMain.AllowPaging = False
                            Me.RadGridProjectViewpointMain.Rebind()

                            For i = 0 To Me.RadGridProjectViewpointMain.MasterTableView.Items.Count - 1

                                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridProjectViewpointMain.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                                Dim DatatableRow As DataRow = dt.NewRow

                                With DatatableRow

                                    .Item("Client") = CurrentGridRow("CDP").Text.Replace("&nbsp;", "")
                                    .Item("Project") = CurrentGridRow("JobAndComp").Text.Replace("&nbsp;", "")
                                    .Item("AE") = CurrentGridRow("AcctExec").Text.Replace("&nbsp;", "")
                                    .Item("Start") = CurrentGridRow("openClosed").Text.Replace("&nbsp;", "")
                                    .Item("Due/Completed") = CurrentGridRow("DueActualDate").Text.Replace("&nbsp;", "").Replace("<br />", " - ").Replace("--", "NA")
                                    .Item("Status") = CurrentGridRow("GridBoundColumnStatus").Text.Replace("&nbsp;", "")

                                End With

                                dt.Rows.Add(DatatableRow)

                            Next

                            Me.RadGridProjectViewpointMain.AllowPaging = True
                            Me.RadGridProjectViewpointMain.Rebind()

                            'Dim Grid As New GridView

                            'With Grid

                            '    .AutoGenerateColumns = True
                            '    .DataSource = dt
                            '    .DataBind()

                            'End With

                            Me.DeliverGrid(dt, "Project_Viewpoint")

                        Catch ex As Exception

                            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

                        End Try

                    Case 1 'Budget

                        Me.OpenFloatingWindow("", "dtp_BudgetViewpoint.aspx?view=BV", 1, 1)

                    Case 2 'Hours

                        Me.OpenFloatingWindow("", "dtp_exportToExcel.aspx?view=HV&show=0", 1, 1)

                End Select

        End Select

        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("RefreshActuals"), RadToolBarButton).Enabled = CType(Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint"), RadToolBarButton).Checked

    End Sub
    Private Sub BtnSave_Click(sender As Object, e As System.EventArgs) Handles BtnSave.Click

        Me.SaveFilter()

    End Sub
    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        Me.MyUnityContextMenu.JobNumber = RadGridProjectViewpointMain.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_NUMBER")
        Me.MyUnityContextMenu.JobComponentNumber = RadGridProjectViewpointMain.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JOB_COMPONENT_NBR")

    End Sub
    Private Sub HeaderContextMenuItemCreated(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadMenuEventArgs)
        Try
            If e.Item.Controls.Count > 0 Then
                If e.Item.Text = "Add Time" Then
                    e.Item.Visible = False
                End If
                If e.Item.Text = "Stopwatch" Then
                    e.Item.Visible = False
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " Methods "

    Private Function SaveInitialFilter() As String
        Try
            Dim SbSQL As New System.Text.StringBuilder
            Dim SbSQLDelete As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim value As String
            Dim UserCode As String = Session("UserCode")

            ' clear out existing data first:
            With SbSQLDelete
                .Append("DELETE FROM PV_AE WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM PV_CDP WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM PV_CMP WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM APP_VARS WHERE USERID = '")
                .Append(UserCode)
                .Append("' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'OFFICE' ")
                .Append(";")
                .Append("DELETE FROM APP_VARS WHERE USERID = '")
                .Append(UserCode)
                .Append("' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'SC' ")
                .Append(";")
            End With

            StrSQL = SbSQLDelete.ToString()

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
                        Return "Error saving selections SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            Dim oSQL As SqlHelper
            Dim SQL_STRING As String
            Dim dr As SqlDataReader
            Dim ae As String

            SQL_STRING = "SELECT EMP_CODE FROM PV_AE WHERE USERID = '" & CStr(Session("UserCode")) & "'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateAEListbox", Err.Description)
            Finally
            End Try

            If dr.HasRows Then
                Do While dr.Read
                    ae = dr.GetString(0)
                    Session("inclAEPV") = "Y"
                Loop
            Else
                ae = "ALL"
                Session("inclAEPV") = "N"
            End If
            dr.Close()

            StrSQL = ""

            'Insert variable data         
            If ae <> "" Then
                With SbSQL
                    .Append("INSERT INTO PV_AE (USERID, EMP_CODE) VALUES ('")
                    .Append(UserCode)
                    .Append("','")
                    .Append(ae)
                    .Append("');")
                End With
            End If

            'Save Selected Office    
            value = "ALL"
            With SbSQL
                .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                .Append(UserCode)
                .Append("','PROJECTVIEWPOINT','OFFICE','")
                .Append(value)
                .Append("','String','")
                .Append(value)
                .Append("');")
            End With


            'Save Selected Sales Class
            With SbSQL
                .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                .Append(UserCode)
                .Append("','PROJECTVIEWPOINT','SC','")
                .Append(value)
                .Append("','String','")
                .Append(value)
                .Append("');")
            End With

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

#Region " Project Viewpoint "

    Private Sub deleteCreativeBrief()
        Dim SQL_UPDATE_STR As String
        Dim oSQL As SqlHelper

        SQL_UPDATE_STR = "DELETE CRTV_BRF_DTL WHERE JOB_NUMBER = " & Session("PVJobNbr") & " AND JOB_COMPONENT_NBR = " & Session("PVCompNbr")

        Try
            oSQL.ExecuteDataset(CStr(Session("ConnString")), CommandType.Text, SQL_UPDATE_STR)
            Session("CBDeleted") = 1
        Catch
            Err.Raise(Err.Number, "Class:CreativeBrief.aspx Routine:deleteCreativeBrief", Err.Description)
        End Try

    End Sub
    Private Sub HideIconHeaderLabels(ByRef header As GridHeaderItem)

        If Not header Is Nothing Then

            Try
                header("GridTemplateColumnPrint").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("alerts").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("documents").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("cb").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("specs").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("versions").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("est").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("sched").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("qva").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("summary").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("GridTemplateColumnStopwatch").Text = "&nbsp;"
            Catch ex As Exception
            End Try
            Try
                header("GridTemplateColumnAddTime").Text = "&nbsp;"
            Catch ex As Exception
            End Try

        End If

    End Sub

    Private Sub LoadGrid()
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT)
        Dim str As String
        Dim days, rows As Integer
        Dim mth, yr, mth2, yr2 As String
        Dim startDate, endDate As String
        Dim tempDate As Date

        appVars.getAllAppVars()

        If Session("inclAEPV") Is Nothing Then
            Session("inclAEPV") = "N"
        End If

        If Session("cdpcLevelPV") Is Nothing Then
            Session("cdpcLevelPV") = "0"
        End If

        If Session("startDatePV") Is Nothing Then

            mth = CType(appVars.getAppVar("PVMonth", "Number"), String)
            yr = CType(appVars.getAppVar("PVYear", "Number"), String)
            mth2 = CType(appVars.getAppVar("PVMonth2", "Number"), String)
            yr2 = CType(appVars.getAppVar("PVYear2", "Number"), String)

            If mth = "0" Or yr = "0" Then
                tempDate = cEmployee.TimeZoneToday
                mth = CStr(tempDate.Month)
                yr = CStr(tempDate.Year)
            End If
            startDate = mth & "/1/" & yr

            If mth2 = "0" Or yr2 = "0" Then
                tempDate = mth & "/1/" & yr
                days = tempDate.DaysInMonth(yr, mth)
            Else
                tempDate = mth2 & "/1/" & yr2
                days = tempDate.DaysInMonth(yr2, mth2)
            End If
            endDate = mth2 & "/" & CStr(days) & "/" & yr2

            Session("startDatePV") = startDate
            Session("endDatePV") = endDate
        End If

        Dim truefalse As String
        truefalse = appVars.getAppVar("PVInclClosedJobs", "Boolean", "False")
        If truefalse = "True" Then
            Session("inclClosedJobsPV") = "Y"
        Else
            Session("inclClosedJobsPV") = "N"
        End If

        truefalse = appVars.getAppVar("PVExclJobsCompSched", "Boolean", "False")
        If truefalse = "True" Then
            Session("PVExclJobsCompSched") = "Y"
        Else
            Session("PVExclJobsCompSched") = "N"
        End If

        truefalse = appVars.getAppVar("PVMyProjectsOnly", "Boolean", "False")
        If truefalse = "True" Then
            Session("PVMyProjectsOnly") = "Y"
        Else
            Session("PVMyProjectsOnly") = "N"
        End If


        Me.RadGridProjectViewpointMain.Rebind()
    End Sub

    Private Function SetSessionVars() As Boolean
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim ct, ctdiv, ctprd As Integer
        Dim emp As String
        Dim filterOn As Boolean = False

        SQL_STRING = "SELECT EMP_CODE FROM PV_AE WHERE UPPER(USERID) = '" & CStr(Session("UserCode")).ToUpper() & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            If dr.HasRows Then
                dr.Read()
                emp = dr.GetString(0)
                If emp = "ALL" Then
                    Session("inclAEPV") = "N"
                Else
                    Session("inclAEPV") = "Y"
                    filterOn = True
                End If
            Else
                Session("inclAEPV") = "N"
            End If
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:SetSessionVars", Err.Description)
        Finally
        End Try

        dr.Close()

        '0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
        SQL_STRING = "SELECT COUNT(CL_CODE), COUNT(DIV_CODE), COUNT(PRD_CODE) FROM PV_CDP WHERE UPPER(USERID) = '" & CStr(Session("UserCode")).ToUpper() & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

            dr.Read()
            ct = dr.GetInt32(0)
            ctdiv = dr.GetInt32(1)
            ctprd = dr.GetInt32(2)

            If ct = 0 Then
                Session("cdpcLevelPV") = "0"
            Else
                filterOn = True
                If ctdiv = 0 Then
                    Session("cdpcLevelPV") = "1"
                Else
                    If ctprd = 0 Then
                        Session("cdpcLevelPV") = "2"
                    Else
                        Session("cdpcLevelPV") = "3"
                    End If
                End If
            End If
            dr.Close()

            If Session("cdpcLevelPV") = "0" Then
                SQL_STRING = "SELECT COUNT(*) FROM PV_CMP WHERE UPPER(USERID) = '" & CStr(Session("UserCode")).ToUpper() & "'"
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

                dr.Read()
                ct = dr.GetInt32(0)
                If ct = 0 Then
                    Session("cdpcLevelPV") = "0"
                Else
                    Session("cdpcLevelPV") = "4"
                End If
            End If

        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:SetSessionVars", Err.Description)
        Finally
        End Try

        dr.Close()

        'Get Include Closed Jobs filter option
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim truefalse As String
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
        appVars.getAllAppVars()

        truefalse = appVars.getAppVar("PVInclClosedJobs", "Boolean", "False")
        If truefalse = "True" Then
            Session("inclClosedJobsPV") = "Y"
        Else
            Session("inclClosedJobsPV") = "N"
        End If

        truefalse = appVars.getAppVar("PVExclJobsCompSched", "Boolean", "False")
        If truefalse = "True" Then
            Session("PVExclJobsCompSched") = "Y"
        Else
            Session("PVExclJobsCompSched") = "N"
        End If

        truefalse = appVars.getAppVar("PVMyProjectsOnly", "Boolean", "False")
        If truefalse = "True" Then
            Session("PVMyProjectsOnly") = "Y"
        Else
            Session("PVMyProjectsOnly") = "N"
        End If

        Return filterOn

    End Function

    Private Sub OpenJobVersion(ByVal jobNbr As String, ByVal compNbr As String)

        Try
            Dim jv As New JobVersion(Session("ConnString"))
            Dim existingtemps As Boolean

            existingtemps = jv.ExistingTemplates(jobNbr, compNbr)

            Dim qs As New AdvantageFramework.Web.QueryString
            qs.JobNumber = jobNbr
            qs.JobComponentNumber = compNbr
            qs.Page = "Content.aspx"
            qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

            Me.OpenWindow("", qs.ToString(True))

        Catch ex As Exception
            Me.ShowMessage("error opening Job Version window")
        End Try

    End Sub
    Private Sub OpenCreativeBrief(ByVal jobNbr As String, ByVal compNbr As String)

        Try

            Dim cb As New cCreativeBrief(Session("ConnString"), Session("UserCode"))
            Dim existingtemps As Boolean
            Dim qs As New AdvantageFramework.Web.QueryString
            qs.JobNumber = jobNbr
            qs.JobComponentNumber = compNbr

            Session("FromWindow") = "ProjectView"
            Session("CBDeleted") = 0
            Session("CBNewSaved") = 1
            existingtemps = cb.ExistingTemplates(jobNbr, compNbr)

            If existingtemps = False Then

                If Me.IsClientPortal = True Then

                    Me.ShowMessage("No Creative Brief exist for this job")

                Else

                    Session("CBNewSaved") = 0
                    Session("CBNewCanceled") = 0

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief
                    Me.OpenWindow("", qs.ToString(True))

                End If

            Else

                qs.Page = "Content.aspx"
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.CreativeBrief
                Me.OpenWindow("", qs.ToString(True))

            End If


        Catch ex As Exception

            Me.ShowMessage("error opening Creative Brief window")

        End Try

    End Sub

    Private Sub RadGridProjectViewpointMain_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridProjectViewpointMain.ItemCommand

        If TypeOf e.Item Is GridDataItem Then

            If e.Item Is Nothing Then Exit Sub

            Dim Row As GridDataItem = TryCast(e.Item, GridDataItem)
            Dim ThisJobNumber As Integer = CType(Row.GetDataKeyValue("JOB_NUMBER"), Integer)
            Dim ThisJobComponentNbr As Integer = CType(Row.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
            Dim qs As New AdvantageFramework.Web.QueryString

            qs.JobNumber = ThisJobNumber
            qs.JobComponentNumber = ThisJobComponentNbr
            Session("PVJobNbr") = ThisJobNumber
            Session("PVCompNbr") = ThisJobComponentNbr
            Session("FromWindow") = "ProjectView"

            Select Case e.CommandName

                Case "versions"

                    OpenJobVersion(ThisJobNumber, ThisJobComponentNbr)

                Case "specs"

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobSpecifications
                    Me.OpenWindow("", qs.ToString(True))

                Case "sched"

                    qs.Add("JT", "2")
                    qs.Add("JobNum", ThisJobNumber)
                    qs.Add("JobComp", ThisJobComponentNbr)
                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Schedule
                    Me.OpenWindow("", qs.ToString(True))

                Case "est"

                    qs.Add("JobNum", ThisJobNumber)
                    qs.Add("JobComp", ThisJobComponentNbr)
                    qs.Add("JT", 0)

                    Dim dr As SqlDataReader
                    Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))

                    dr = oEstimating.GetEstJob(ThisJobNumber, ThisJobComponentNbr)

                    If dr.HasRows = True Then
                        dr.Read()

                        If dr("ESTIMATE_NUMBER") <> 0 Then

                            qs.Page = "Content.aspx"
                            qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                            qs.Add("EstNum", dr("ESTIMATE_NUMBER"))
                            qs.Add("EstComp", dr("EST_COMPONENT_NBR"))
                            qs.Add("newEst", "edit")

                        Else

                            qs.Page = "Content.aspx"
                            qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                            Me.OpenWindow("", qs.ToString(True))

                        End If

                    Else

                        qs.Page = "Content.aspx"
                        qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                        qs.Add("newEst", "job")
                        Me.OpenWindow("", qs.ToString(True))

                    End If

                Case "alerts"

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Alerts

                    Me.OpenWindow("", qs.ToString(True))

                Case "documents"

                    Session("DocFilterLevel") = "JC"
                    Session("DocFilterValue") = ThisJobNumber.ToString() & "," & ThisJobComponentNbr.ToString()

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Documents
                    qs.Add("m", "D")
                    Me.OpenWindow("", qs.ToString(True))

                Case "qva"

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.FinancialStatus
                    qs.Add("JobNo", ThisJobNumber)
                    qs.Add("JobComp", ThisJobComponentNbr)

                    Me.OpenWindow("", qs.ToString(True))

                Case "cb"

                    OpenCreativeBrief(ThisJobNumber, ThisJobComponentNbr)

                Case "summary"

                    Dim strURL As String = "TrafficSchedule_ProjectSummary.aspx?JobNo=" & ThisJobNumber.ToString() & "&JobComp=" & ThisJobComponentNbr.ToString()
                    Me.OpenWindow("Project Viewpoint Summary", strURL)

                Case "Detail"

                    qs.Page = "Content.aspx"
                    qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                    qs.Add("JobNum", ThisJobNumber)
                    qs.Add("JobCompNum", ThisJobComponentNbr)
                    qs.Add("NewComp", "0")

                    Me.OpenWindow("", qs.ToString(True))

                Case "Print"

                    Me.OpenWindow("Print Job Jacket", "JobTemplate_Print.aspx?Job=" & _
                                  ThisJobNumber.ToString() & "&JobComp=" & ThisJobComponentNbr.ToString() & "&fromapp=projectview")

                Case "StartStopwatch"

                    Dim s As String = ""
                    If AdvantageFramework.Timesheet.StopwatchStart(Session("ConnString"), Session("UserCode"), Session("EmpCode"), ThisJobNumber, ThisJobComponentNbr, -1, 0, s) = True Then

                        'Me.OpenTimesheetStopwatchNotificationWindow()

                        Me.OpenWindow("Timesheet Stopwatch", "Timesheet_Stopwatch.aspx", 475, 500)

                    Else

                        Me.ShowMessage(s)

                    End If

                Case "AddTime"

                    With qs

                        '.Page = "modules/project-management/agile/new-work-item-time-dialog"
                        .Page = "Employee/Timesheet/Entry"
                        '.Add("Type", "New")
                        '.Add("caller", "AlertView")
                        '.Add("single", "1")
                        '.JobNumber = ThisJobNumber
                        '.JobComponentNbr = ThisJobComponentNbr

                    End With

                    Me.OpenWindow("Add Time", qs.ToString(True), 600, 600)

            End Select

        End If

        Try

            Dim h As GridHeaderItem
            If Not RadGridProjectViewpointMain.MasterTableView.GetItems(GridItemType.Header)(0) Is Nothing Then

                Me.HideIconHeaderLabels(TryCast(RadGridProjectViewpointMain.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem))

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridProjectViewpointMain_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridProjectViewpointMain.ItemDataBound

        Dim parmStr As String = ""
        Dim desc As String = ""

        If e.Item.ItemType = GridItemType.Header Then

            Me.HideIconHeaderLabels(TryCast(e.Item, GridHeaderItem))

        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0

            Try
                JobNumber = CType(CurrentGridRow.GetDataKeyValue("JOB_NUMBER"), Integer)
            Catch ex As Exception
                JobNumber = 0
            End Try

            Try
                JobComponentNbr = CType(CurrentGridRow.GetDataKeyValue("JOB_COMPONENT_NBR"), Integer)
            Catch ex As Exception
                JobComponentNbr = 0
            End Try

            Dim DueDateDisplay As String = "--"
            Dim CompletedDateDisplay As String = "--"

            If Not e.Item.DataItem("JOB_FIRST_USE_DATE") Is Nothing _
                        AndAlso IsDBNull(e.Item.DataItem("JOB_FIRST_USE_DATE")) = False _
                        AndAlso IsDate(e.Item.DataItem("JOB_FIRST_USE_DATE")) = True Then

                DueDateDisplay = CType(e.Item.DataItem("JOB_FIRST_USE_DATE"), Date).ToShortDateString()

            End If

            If Not e.Item.DataItem("COMPLETED_DATE") Is Nothing _
                        AndAlso IsDBNull(e.Item.DataItem("COMPLETED_DATE")) = False _
                        AndAlso IsDate(e.Item.DataItem("COMPLETED_DATE")) = True Then

                CompletedDateDisplay = CType(e.Item.DataItem("COMPLETED_DATE"), Date).ToShortDateString()

            End If

            If DueDateDisplay = "--" And CompletedDateDisplay = "--" Then

                CurrentGridRow("DueActualDate").Text = "&nbsp;"

            Else

                CurrentGridRow("DueActualDate").Text = DueDateDisplay & "<br />" & CompletedDateDisplay

            End If

            If JobNumber > 0 And JobComponentNbr > 0 Then

                Dim VersionsLinkButton As WebControls.LinkButton = e.Item.FindControl("LinkButtonVersions")
                VersionsLinkButton.ToolTip = e.Item.DataItem("JOB_VERSIONS_LABEL")
                If e.Item.DataItem("JOB_VERSIONS_LABEL") <> "" Then
                    VersionsLinkButton.Text = e.Item.DataItem("JOB_VERSIONS_LABEL").ToString().Substring(0, 1).ToUpper()
                End If

                Dim qs As New AdvantageFramework.Web.QueryString
                qs.JobNumber = JobNumber
                qs.JobComponentNumber = JobComponentNbr
                qs.Page = "Content.aspx"
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobVersion

                Me.HookUpOpenWindow(VersionsLinkButton, qs.ToString(True))

                Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
                Dim js As New Job_Specs(Session("ConnString"))
                Dim strURL As String

                Dim QvADiv As HtmlControls.HtmlControl = e.Item.FindControl("DivQvA")

                Select Case CType(e.Item.DataItem("THRESHOLD_STATUS"), Integer)
                    Case 0

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(QvADiv, "standard-yellow")

                    Case 1

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(QvADiv, "standard-green")

                    Case 2

                        AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(QvADiv, "standard-red")

                End Select

                QvADiv.Attributes.Remove("onclick")

                Dim SummaryLinkButton As WebControls.LinkButton = e.Item.FindControl("LinkButtonSummary")
                Me.HookUpOpenWindow(SummaryLinkButton, "TrafficSchedule_ProjectSummary.aspx?JobNo=" & JobNumber & "&JobComp=" & JobComponentNbr)

                Try

                    If Me.DesktopObjectsAreFloating = True Then

                        Me.RadToolTipManagerSummaryTooltip.TargetControls.Add(SummaryLinkButton.ClientID, e.Item.DataItem("JOB_NUMBER") & "|" & e.Item.DataItem("JOB_COMPONENT_NBR"), True)

                    End If

                Catch ex As Exception
                End Try

                Dim ViewDetailsImageButton As WebControls.ImageButton = e.Item.FindControl("ImageButtonViewDetails")
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.JobTemplate
                Me.HookUpOpenWindow(ViewDetailsImageButton, qs.ToString(True))

                Dim PrintImageButton As WebControls.ImageButton = e.Item.FindControl("ImageButtonPrint")
                Me.HookUpOpenWindow(PrintImageButton, "JobTemplate_Print.aspx?client=&division=&product=&job=" & JobNumber & "&jobcomp=" & JobComponentNbr)

                Dim EstimateLinkButton As WebControls.LinkButton = e.Item.FindControl("LinkButtonEstimate")
                qs.ContentArea = AdvantageFramework.Web.QueryString.ContentAreaName.Estimates
                qs.Add("newEst", "edit")
                Me.HookUpOpenWindow(EstimateLinkButton, qs.ToString(True))

                Dim sec As New cSecurity(Session("ConnString"))
                Dim dr As SqlDataReader
                Dim secInsert As String
                Dim secView As String
                Dim est As Integer

                secInsert = IIf(Me.UserCanAddInModule(AdvantageFramework.Security.Modules.ProjectManagement_Estimating), "Y", "N")

                est = e.Item.DataItem("ESTIMATE_NUMBER")

                Dim EstimateDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivEstimate")
                If secInsert = "N" And est = 0 Then
                    AdvantageFramework.Web.Presentation.Controls.DivHide(EstimateDiv)
                End If

                secView = IIf(Me.UserCanPrintInModule(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket), "Y", "N")

                If secView = "N" Then
                    Me.ImageButtonPrint.Visible = False
                End If
                'openclosed
                Try
                    If e.Item.Cells(24).Text <> "" And e.Item.Cells(24).Text <> "&nbsp;" Then
                        If e.Item.Cells(26).Text = "6" Or e.Item.Cells(26).Text = "12" Then
                            e.Item.Cells(7).Text = IIf(IsDate(e.Item.Cells(7).Text), CDate(e.Item.Cells(7).Text).ToShortDateString(), e.Item.Cells(7).Text) & " - " & vbCrLf & IIf(IsDate(e.Item.Cells(24).Text), CDate(e.Item.Cells(24).Text).ToShortDateString(), e.Item.Cells(24).Text)
                        Else
                            If e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" Then
                                e.Item.Cells(7).Text = IIf(IsDate(e.Item.Cells(7).Text), CDate(e.Item.Cells(7).Text).ToShortDateString(), e.Item.Cells(7).Text)
                            End If
                        End If
                    Else
                        If e.Item.Cells(7).Text <> "" And e.Item.Cells(7).Text <> "&nbsp;" Then
                            e.Item.Cells(7).Text = IIf(IsDate(e.Item.Cells(7).Text), CDate(e.Item.Cells(7).Text).ToShortDateString(), e.Item.Cells(7).Text)
                        End If
                    End If
                Catch ex As Exception
                End Try
                'dueactualdate
                Try
                    If e.Item.Cells(25).Text <> "" And e.Item.Cells(25).Text <> "&nbsp;" Then
                        If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
                            e.Item.Cells(8).Text = IIf(IsDate(e.Item.Cells(8).Text), CDate(e.Item.Cells(8).Text).ToShortDateString(), e.Item.Cells(8).Text) & " - " & vbCrLf & IIf(IsDate(e.Item.Cells(25).Text), CDate(e.Item.Cells(25).Text).ToShortDateString(), e.Item.Cells(25).Text)
                        Else
                            e.Item.Cells(8).Text = IIf(IsDate(e.Item.Cells(24).Text), CDate(e.Item.Cells(24).Text).ToShortDateString(), e.Item.Cells(24).Text)
                        End If
                    Else
                        If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
                            e.Item.Cells(8).Text = IIf(IsDate(e.Item.Cells(8).Text), CDate(e.Item.Cells(8).Text).ToShortDateString(), e.Item.Cells(8).Text)
                        End If
                    End If
                Catch ex As Exception
                End Try
            End If
        End If
        If e.Item.ItemType = GridItemType.Footer Then
            'Set display properies depending on user security access
            Dim oSec As New cSecurity(Session("ConnString"))
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("alerts").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_Alerts, False) = 1)
            If Me.IsClientPortal = True Then
                Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("documents").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Documents, False) = 1)
                Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("GridTemplateColumnAddTime").Display = False
                Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("GridTemplateColumnStopwatch").Display = False
            Else
                Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("documents").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, False) = 1)
            End If
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("specs").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Specifications, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("versions").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobVersions, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("est").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Estimating, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("sched").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_ProjectSchedule, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("qva").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DashboardQueries_QuotevsActualsDQ, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("cb").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_CreativeBrief, False) = 1)
            Me.RadGridProjectViewpointMain.MasterTableView.GetColumn("summary").Display = (Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_DesktopObjects_ProjectViewpointSnapshot, False) = 1)

        End If
    End Sub
    Private Sub RadGridProjectViewpointMain_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridProjectViewpointMain.NeedDataSource
        'DON'T ALLOW GRID TO LOAD IF USER HAS NOT CREATED SOME DEFAULTS....
        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            If otask.hasAppVars(Session("UserCode"), "PROJECTVIEWPOINT") = False And IsClientPortal = False Then
                Me.LoadFilterView()
            End If

        End If

        Dim cPV As cProjectViewpoint = New cProjectViewpoint()

        Dim dt As New DataTable
        dt.CaseSensitive = False

        Dim ExcludeClosedSched As Boolean = False
        If Session("PVExclJobsCompSched") = "Y" Then
            ExcludeClosedSched = True
        End If


        RadGridProjectViewpointMain.AllowCustomPaging = Not ShouldApplySortFilterOrGroup()

        If IsClientPortal = True Then

            Me.RadGridProjectViewpointMain.AllowCustomPaging = False

            dt = cPV.getPVListCP(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"), Session("inclClosedJobsPV"), "N", Session("UserID"), ExcludeClosedSched)

        Else

            Dim RecCount As Integer = 5000
            Try

                Dim DtCount As New DataTable
                DtCount = cPV.getPVList(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"), Session("inclClosedJobsPV"), Session("PVMyProjectsOnly"),
                               ExcludeClosedSched, 0, 0, True)

                If DtCount IsNot Nothing AndAlso DtCount.Rows.Count > 0 Then

                    RecCount = DtCount.Rows(0)(0)

                End If

            Catch ex As Exception
                RecCount = 5000
            End Try

            Me.RadGridProjectViewpointMain.PageSize = MiscFN.LoadPageSize(Me.RadGridProjectViewpointMain.ID)

            Me.RadGridProjectViewpointMain.VirtualItemCount = RecCount

            Dim startRowIndex As Integer = If((ShouldApplySortFilterOrGroup()), 0, RadGridProjectViewpointMain.CurrentPageIndex * RadGridProjectViewpointMain.PageSize)
            Dim maximumRows As Integer

            If Me.RadGridProjectViewpointMain.AllowPaging = False Then

                maximumRows = RecCount

            Else

                If ShouldApplySortFilterOrGroup() = True Then

                    maximumRows = RecCount

                Else

                    maximumRows = RadGridProjectViewpointMain.PageSize

                End If

            End If

            If maximumRows = RecCount Then

                dt = cPV.getPVList(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"), Session("inclClosedJobsPV"), Session("PVMyProjectsOnly"),
                                   ExcludeClosedSched, 0, 0, False)

            Else

                dt = cPV.getPVList(Session("inclAEPV"), Session("cdpcLevelPV"), Session("startDatePV"), Session("endDatePV"), Session("inclClosedJobsPV"), Session("PVMyProjectsOnly"),
                                   ExcludeClosedSched, CurrentPageNumber, maximumRows, False)

            End If

        End If


        Me.RadGridProjectViewpointMain.DataSource = dt

    End Sub
    Public Function ShouldApplySortFilterOrGroup() As Boolean
        Return RadGridProjectViewpointMain.MasterTableView.FilterExpression <> "" OrElse (RadGridProjectViewpointMain.MasterTableView.GroupByExpressions.Count > 0) OrElse RadGridProjectViewpointMain.MasterTableView.SortExpressions.Count > 0
    End Function


    Private Sub RadGridProjectViewpointMain_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridProjectViewpointMain.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridProjectViewpointMain.Rebind()

    End Sub

    Private Sub RadGridProjectViewpointMain_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridProjectViewpointMain.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridProjectViewpointMain.ID, e.NewPageSize)

    End Sub
    Private Sub RadGridProjectViewpointMain_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridProjectViewpointMain.PreRender

        Session("PVDOSortExp") = Me.RadGridProjectViewpointMain.MasterTableView.SortExpressions.GetSortString()

        Try

            Me.CurrentNumberOfPages = Me.RadGridProjectViewpointMain.PageCount
            If Me.CurrentPageNumber <= Me.CurrentNumberOfPages Then

                Me.RadGridProjectViewpointMain.CurrentPageIndex = Me.CurrentPageNumber

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ResetPageIndex()

        Me.CurrentPageNumber = 0
        Me.RadGridProjectViewpointMain.CurrentPageIndex = 0

    End Sub

    Private Sub RefreshAction()
        Select Case Me.MultiView1.ActiveViewIndex
            Case 0  'ProjectViewpoint
                LoadGrid()
                Me.ResetPageIndex()
            Case 1  'BudgetViewpoint
                LoadGridBV()
            Case 2  'HoursViewpoint
                LoadGridHV()
        End Select
    End Sub
    Private Sub RefreshGrids()
        'With Me.RadToolTipManager1
        '    .TargetControls.Clear()
        'End With
        'With Me.RadToolTipManager2
        '    .TargetControls.Clear()
        'End With
        Me.RadGridProjectViewpointMain.Rebind()
    End Sub

    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub
    Protected Sub OnAjaxUpdate2(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("ProjectViewpointTooltip.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim appName As String
        Dim job, comp As String
        Dim strVals(20) As String

        strVals = ArguementValue.Split(",")
        appName = strVals(0)
        job = strVals(1)
        comp = strVals(2)

        Dim t As ProjectViewpointTooltip = DirectCast(ctrl, ProjectViewpointTooltip)
        With t
            .appName = appName
            .Job = job
            .Comp = comp
        End With

    End Sub
    Private Function getQuoted(ByVal job As Integer, ByVal comp As Int16) As Decimal
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper
        Dim jobStr, compStr As String
        Dim timeOnly As String
        Dim quoted As Decimal
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
        appVars.getAllAppVars()

        timeOnly = appVars.getAppVar("PVQvAType", "Boolean", "False")
        If timeOnly = "True" Then
            timeOnly = "E"
        End If

        jobStr = CType(job, String)
        compStr = CType(comp, String)

        SQL_STRING = "SELECT  ISNULL(Sum(ESTIMATE_REV_DET.LINE_TOTAL),0) "
        SQL_STRING += " FROM ESTIMATE_REV_DET "
        SQL_STRING += "	INNER JOIN ESTIMATE_APPROVAL ON ESTIMATE_REV_DET.ESTIMATE_NUMBER = ESTIMATE_APPROVAL.ESTIMATE_NUMBER "
        SQL_STRING += "	  AND ESTIMATE_REV_DET.EST_COMPONENT_NBR = ESTIMATE_APPROVAL.EST_COMPONENT_NBR "
        SQL_STRING += "	  AND ESTIMATE_REV_DET.EST_QUOTE_NBR = ESTIMATE_APPROVAL.EST_QUOTE_NBR "
        SQL_STRING += "	  AND ESTIMATE_REV_DET.EST_REV_NBR = ESTIMATE_APPROVAL.EST_REVISION_NBR "
        SQL_STRING += "	INNER JOIN JOB_LOG ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_LOG.JOB_NUMBER "
        SQL_STRING += "	INNER JOIN JOB_COMPONENT ON ESTIMATE_APPROVAL.JOB_NUMBER = JOB_COMPONENT.JOB_NUMBER "
        SQL_STRING += "	  AND ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = JOB_COMPONENT.JOB_COMPONENT_NBR "

        SQL_STRING += " Where (NOT (JOB_COMPONENT.JOB_PROCESS_CONTRL IN (6, 12))) "
        SQL_STRING += " And ESTIMATE_APPROVAL.JOB_NUMBER = " & jobStr & " And ESTIMATE_APPROVAL.JOB_COMPONENT_NBR = " & compStr

        If timeOnly = "E" Then
            SQL_STRING += " And ESTIMATE_REV_DET.EST_FNC_TYPE = '" + timeOnly + "'"
        End If

        SQL_STRING += " Group By ESTIMATE_APPROVAL.JOB_NUMBER, ESTIMATE_APPROVAL.JOB_COMPONENT_NBR "

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_ProjectViewMultiview.ascx Routine:getQuoted", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            dr.Read()
            quoted = dr.GetDecimal(0)
        Else
            quoted = 0
        End If

        dr.Close()

        Return quoted

    End Function

    Protected Sub SummaryTooltipOnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)
        Me.UpdateSummaryTooltip(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateSummaryTooltip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("DOS/DesktopProjectViewpoint_Details.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim ar() As String
        ar = ArguementValue.Split("|")
        If ar.Length = 2 Then
            If IsNumeric(ar(0)) = True And IsNumeric(ar(1)) = True Then

                Dim t As DesktopProjectViewpoint_Details = DirectCast(ctrl, DesktopProjectViewpoint_Details)
                With t

                    .Job = CType(ar(0), Integer)
                    .Comp = CType(ar(1), Integer)

                End With

            End If
        End If
    End Sub

#End Region

#Region " Budget Viewpoint "

    Private Sub LoadGridBV()
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
        appVars.getAllAppVars()
        Dim month, year As String
        Dim cdpLevel As Integer
        Dim startDate As Date
        Dim PVForecast As String

        cdpLevel = Me.ddGroupBy.SelectedValue   '1-All	2-Type	3-Sales Class
        Session("ProjectViewpointGroup") = cdpLevel

        PVForecast = appVars.getAppVar("PVForecast", "Number")

        Dim gridcolBilling As Telerik.Web.UI.GridColumn
        Dim gridcolGI As Telerik.Web.UI.GridColumn
        gridcolBilling = Me.RadGridBudgetView.Columns.FindByUniqueName("ACTUAL_BILLING")
        gridcolGI = Me.RadGridBudgetView.Columns.FindByUniqueName("ACTUAL_GI")

        Select Case PVForecast
            Case 0
                gridcolBilling.HeaderText = "Actual Billed<br/>Billing"
                gridcolGI.HeaderText = "Actual Billed<br/>Gross Income"

            Case 1
                gridcolBilling.HeaderText = "Actual Posted<br/>Billing"
                gridcolGI.HeaderText = "Actual Posted<br/>Gross Income"

            Case Else
                gridcolBilling.HeaderText = "Forecasted<br/>Billing"
                gridcolGI.HeaderText = "Forecasted<br/>Gross Income"
        End Select

        Me.RadGridBudgetView.DataSource = oPV.getBudgetViewpoint(cdpLevel)
        Me.RadGridBudgetView.DataBind()

    End Sub

    Private Sub RadGridBudgetView_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBudgetView.NeedDataSource
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim month, year As String
        Dim cdpLevel As Integer
        Dim startDate As Date

        If Not Session("startDatePV") Is Nothing Then
            startDate = Session("startDatePV")
        Else
            startDate = Date.Today
        End If

        month = startDate.Month.ToString.PadLeft(2, "0")
        year = startDate.Year.ToString.PadLeft(4, "0")

        cdpLevel = Me.ddGroupBy.SelectedValue   '1-All	2-Type	3-Sales Class
        Session("ProjectViewpointGroup") = cdpLevel

        Me.RadGridBudgetView.DataSource = oPV.getBudgetViewpoint(cdpLevel)
    End Sub

    Private Sub RadGridBudgetView_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridBudgetView.PreRender
        Session("BVDOSortExp") = Me.RadGridBudgetView.MasterTableView.SortExpressions.GetSortString
    End Sub

    Private Sub ddGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddGroupBy.SelectedIndexChanged
        Me.RadGridBudgetView.MasterTableView.CurrentPageIndex = 0
        LoadGridBV()
    End Sub

    Private Sub refreshActuals()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT, Session("UserCode"))
        appVars.getAllAppVars()
        Dim month, year, month2, year2, PPstart, PPend As String
        Dim userID As String
        Dim ct, inUse, rc As Integer
        Dim now As DateTime = System.DateTime.Now

        Try

            month = appVars.getAppVar("PVMonth")
            year = appVars.getAppVar("PVYear")
            month2 = appVars.getAppVar("PVMonth2")
            year2 = appVars.getAppVar("PVYear2")

            If month = "" Or year = "" Then
                Me.ShowMessage("Please apply date ranges in filter tab.")
                Exit Sub
            End If

            PPstart = year & month.PadLeft(2, "0")
            PPend = year2 & month2.PadLeft(2, "0")

            Try
                'See if actual data exists yet
                SQL_STRING = "SELECT count(*) FROM ACTUALS_ACC_HDR"
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

                dr.Read()
                ct = dr.GetInt32(0)
                If ct = 0 Then
                    SQL_STRING = "INSERT INTO ACTUALS_ACC_HDR (EMP_CODE,LAST_UPDATE,IN_USE) "
                    SQL_STRING &= " VALUES('" & Session("UserCode") & "','" & now & "'," & CStr(0) & ")"
                    oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                End If

                dr.Close()

                'See if actuals are currently being refreshed
                SQL_STRING = "SELECT IN_USE, EMP_CODE FROM ACTUALS_ACC_HDR"
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                dr.Read()
                inUse = dr.GetInt16(0)
                userID = dr.GetString(1)
                dr.Close()

                If inUse = 1 Then
                    If userID = Session("UserCode") Then
                        'Don't need to do anything, allow processing to continue
                        'SQL_STRING = "UPDATE ACTUALS_ACC_HDR SET IN_USE = 0"
                        'oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                    Else
                        Me.ShowMessage("The actuals are currently being updated. This utility cannot be run now.")
                        Exit Sub
                    End If

                Else
                    SQL_STRING = "UPDATE ACTUALS_ACC_HDR SET IN_USE = 1"
                    oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                End If

            Catch
                Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:refreshActuals", Err.Description)
                Exit Sub
            Finally
            End Try

            rc = oPV.refreshData(PPstart, PPend)

            'Delete actual values of 0
            SQL_STRING = "DELETE ACTUALS_ACC WHERE AMOUNT = 0"
            oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

            'Update actuals header table
            now = System.DateTime.Now
            now.ToShortTimeString()

            SQL_STRING = " UPDATE ACTUALS_ACC_HDR "
            SQL_STRING &= "	SET IN_USE=0, EMP_CODE= '" & Session("UserCode") & "', LAST_UPDATE='" & CStr(now) & "'"
            oSQL.ExecuteNonQuery(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)

            Me.LabelLastRefreshed.Text = getLastRefreshed()
        Catch ex As Exception

        End Try

    End Sub

    Private Function getLastRefreshed() As String
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim refreshdata As String = ""
        Dim refreshby As String = ""
        Dim refreshDate As DateTime

        'Actuals Emp code is actually userid (ACTUALS_ACC_HDR.EMP_CODE)
        SQL_STRING = "SELECT dbo.advfn_get_user_name(ACTUALS_ACC_HDR.EMP_CODE), ACTUALS_ACC_HDR.LAST_UPDATE "
        SQL_STRING &= "FROM ACTUALS_ACC_HDR"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:getLastRefreshed", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Try
                dr.Read()
                refreshby = dr.GetString(0)
                refreshDate = dr.GetDateTime(1)

                refreshdata = "Last Refreshed by:&nbsp;" & refreshby & "&nbsp;at&nbsp;" & CStr(refreshDate.ToShortDateString) & "&nbsp;" & CStr(refreshDate.ToShortTimeString)
            Catch ex As Exception
            End Try
        End If
        dr.Close()

        Return refreshdata

    End Function

#End Region

#Region " Hours Viewpoint "

    Private Sub LoadGridHV()
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim groupingLevel As Integer
        Dim groupDesc As String
        Dim gridcolGrouping As Telerik.Web.UI.GridColumn

        gridcolGrouping = Me.RadGridHoursView.Columns.FindByUniqueName("GROUPING")

        groupingLevel = ddHoursViewpointGrouping.SelectedValue  '--> 0-none; 1-Function; 2-Job/Comp; 3-Employee
        Session("ProjectViewpointGroupLevel") = ddHoursViewpointGrouping.SelectedValue
        Select Case groupingLevel
            Case 0
                gridcolGrouping.HeaderText = ""
            Case 1
                gridcolGrouping.HeaderText = "Function"
            Case 2
                gridcolGrouping.HeaderText = "Project"
            Case 3
                gridcolGrouping.HeaderText = "Employee"
        End Select

        Me.RadGridHoursView.DataSource = oPV.getHoursViewpoint(CStr(groupingLevel))
        Me.RadGridHoursView.DataBind()

    End Sub

    Private Sub RadGridHoursView_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridHoursView.NeedDataSource
        Dim oPV As cProjectViewpoint = New cProjectViewpoint()
        Dim groupingLevel As Integer

        groupingLevel = ddHoursViewpointGrouping.SelectedValue  '--> 0-none; 1-Function; 2-Job/Comp; 3-Employee
        Session("ProjectViewpointGroupLevel") = ddHoursViewpointGrouping.SelectedValue

        Me.RadGridHoursView.DataSource = oPV.getHoursViewpoint(CStr(groupingLevel))
    End Sub
    Private Sub RadGridHoursView_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridHoursView.PreRender
        Session("HVDOSortExp") = Me.RadGridHoursView.MasterTableView.SortExpressions.GetSortString
    End Sub
    Private Sub ddHoursViewpointGrouping_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddHoursViewpointGrouping.SelectedIndexChanged
        Me.RadGridHoursView.CurrentPageIndex = 0
        LoadGridHV()

    End Sub
    Private Sub cbShowAmounts_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbShowAmounts.CheckedChanged
        Dim gridcol_BILLED_AMT As Telerik.Web.UI.GridColumn
        Dim gridcol_UNBILLED_AMT As Telerik.Web.UI.GridColumn
        Dim gridcol_NON_BILLABLE As Telerik.Web.UI.GridColumn
        Dim gridcol_ADJUSTED_AMT As Telerik.Web.UI.GridColumn

        gridcol_BILLED_AMT = Me.RadGridHoursView.Columns.FindByUniqueName("BILLED_AMT")
        gridcol_UNBILLED_AMT = Me.RadGridHoursView.Columns.FindByUniqueName("UNBILLED_AMT")
        gridcol_NON_BILLABLE = Me.RadGridHoursView.Columns.FindByUniqueName("NON_BILLABLE")
        gridcol_ADJUSTED_AMT = Me.RadGridHoursView.Columns.FindByUniqueName("ADJUSTED_AMT")

        If cbShowAmounts.Checked = True Then
            gridcol_BILLED_AMT.Visible = True
            gridcol_UNBILLED_AMT.Visible = True
            gridcol_NON_BILLABLE.Visible = True
            gridcol_ADJUSTED_AMT.Visible = True
        Else
            gridcol_BILLED_AMT.Visible = False
            gridcol_UNBILLED_AMT.Visible = False
            gridcol_NON_BILLABLE.Visible = False
            gridcol_ADJUSTED_AMT.Visible = False
        End If

        ''Me.HookUpHoursExport()

        Me.RadGridHoursView.Rebind()

    End Sub

#End Region

#Region " Filter View "

#Region "Filter Methods"

    Private Function BuildCodeStrings(ByVal LoadLevel As String, ByRef StrSelectionsBase As String, ByRef StrClients As String, _
                                     ByRef StrDivisions As String, ByRef StrProducts As String, ByRef StrCampaigns As String, ByRef StrAEs As String) As Boolean
        'Build code strings:
        '===================================================================================
        'AE's
        For i As Integer = 0 To Me.RadListBoxAccountExecutives.Items.Count - 1
            If Me.RadListBoxAccountExecutives.Items(i).Selected = True Then
                StrAEs &= "'" & Me.RadListBoxAccountExecutives.Items(i).Value & "',"
                If i = 0 And Me.RadListBoxAccountExecutives.Items(i).Value = "ALL" Then Exit For
            End If
        Next
        StrAEs = MiscFN.RemoveDuplicatesFromString(StrAEs, ",")
        StrAEs = MiscFN.RemoveTrailingDelimiter(StrAEs, ",")

        'Selection Level:
        For j As Integer = 0 To Me.RadListBoxCDPCSelections.Items.Count - 1
            If Me.RadListBoxCDPCSelections.Items(j).Selected = True Then
                StrSelectionsBase &= Me.RadListBoxCDPCSelections.Items(j).Value & ","
            End If
        Next
        StrSelectionsBase = MiscFN.RemoveDuplicatesFromString(StrSelectionsBase, ",")
        StrSelectionsBase = MiscFN.RemoveTrailingDelimiter(StrSelectionsBase, ",")

        'Selection Level:
        Dim k As Integer = 0
        Dim ar() As String
        ar = StrSelectionsBase.Split(",")

        If ar(0).ToString() = "" And Me.RadioButtonListSelectionLevel.SelectedValue <> "CDPC" Then

            Me.ShowMessage("Please select at least one item from list")
            Me.RadListBoxCDPCSelections.Focus()
            Return False

        End If

        Select Case LoadLevel
            Case "CDPC" 'This is "all"...no criteria set
                'Make sure all empty:
                StrClients = ""
                StrDivisions = ""
                StrProducts = ""
                StrCampaigns = ""
            Case "CLIENT"
                'Parse:
                For k = 0 To ar.Length - 1
                    StrClients &= "'" & ar(k).ToString() & "',"
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
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
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
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
                    StrProducts &= "'" & ar2(2).ToString() & "',"
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
                    StrClients &= "'" & ar2(0).ToString() & "',"
                    StrDivisions &= "'" & ar2(1).ToString() & "',"
                    StrProducts &= "'" & ar2(2).ToString() & "',"
                    StrCampaigns &= "'" & ar2(3).ToString() & "',"
                Next
                StrClients = MiscFN.RemoveDuplicatesFromString(StrClients, ",")
                StrClients = MiscFN.RemoveTrailingDelimiter(StrClients, ",")
                StrDivisions = MiscFN.RemoveDuplicatesFromString(StrDivisions, ",")
                StrDivisions = MiscFN.RemoveTrailingDelimiter(StrDivisions, ",")
                StrProducts = MiscFN.RemoveDuplicatesFromString(StrProducts, ",")
                StrProducts = MiscFN.RemoveTrailingDelimiter(StrProducts, ",")
                StrCampaigns = MiscFN.RemoveDuplicatesFromString(StrCampaigns, ",")
                StrCampaigns = MiscFN.RemoveTrailingDelimiter(StrCampaigns, ",")
        End Select

        Return True

    End Function

    Private Sub LoadFilterView()
        'NEED TO REDIRECT TO FILTER PAGE!!!
        '' Me.GoToFilter()
        strTimeOnly = Me.ddQvAType.SelectedValue
        If IsNumeric(Me.txtThreshold.Text.Trim) Then
            strThreshold = Me.txtThreshold.Text.Trim
        Else
            strThreshold = "100"
        End If
        'If Not Me.IsPostBack And Not Me.Page.IsCallback Then
        Dim otask As New cTasks(Session("ConnString"))
        If otask.getAppVars(Session("UserCode"), "PROJECTVIEWPOINT", "PVMyProjectsOnly") = "" Then
            otask.setAppVars(Session("UserCode"), "PROJECTVIEWPOINT", "PVMyProjectsOnly", "System.Boolean", "True")
        End If
        'End If

        Me.MultiView1.ActiveViewIndex = 3
        Me.MultiView1.SetActiveView(ViewFilter)

        LoadMonths()
        LoadYears()
        LoadAEListbox()
        LoadOfficeListbox()
        loadSCListbox()
        LoadManagerListbox()

        PopulateCDPListbox()

        LoadFilterObjects()

        If Me.IsClientPortal = True Then
            Me.RadioButtonListSelectionLevel.Items().FindByValue("CLIENT").Enabled = False
        End If

    End Sub
    Private Sub LoadMonths(Optional ByVal M As String = "")
        With Me.ddlMonth.Items
            .Clear()
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("01"), CStr("01")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("02"), CStr("02")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("03"), CStr("03")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("04"), CStr("04")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("05"), CStr("05")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("06"), CStr("06")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("07"), CStr("07")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("08"), CStr("08")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("09"), CStr("09")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("10"), CStr("10")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("11"), CStr("11")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("12"), CStr("12")))
        End With

        With Me.ddlMonth2.Items
            .Clear()
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("01"), CStr("01")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("02"), CStr("02")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("03"), CStr("03")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("04"), CStr("04")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("05"), CStr("05")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("06"), CStr("06")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("07"), CStr("07")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("08"), CStr("08")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("09"), CStr("09")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("10"), CStr("10")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("11"), CStr("11")))
            .Add(New Telerik.Web.UI.RadComboBoxItem(CStr("12"), CStr("12")))
        End With

        Try
            If IsNumeric(Request.QueryString("m")) = True Then
                Me.ddlMonth.SelectedValue = Request.QueryString("m")
                Me.ddlMonth2.SelectedValue = Request.QueryString("m")
            Else
                Me.ddlMonth.SelectedValue = Now.ToString("MM")
                Me.ddlMonth2.SelectedValue = Now.ToString("MM")
            End If
        Catch ex As Exception
            Me.ddlMonth.SelectedValue = Now.ToString("MM")
            Me.ddlMonth2.SelectedValue = Now.ToString("MM")
        End Try
    End Sub
    Private Sub LoadYears(Optional ByVal Y As String = "")
        With Me.ddlYear.Items
            .Clear()
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-5).Year.ToString(), Now.AddYears(-5).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-4).Year.ToString(), Now.AddYears(-4).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-3).Year.ToString(), Now.AddYears(-3).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-2).Year.ToString(), Now.AddYears(-2).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-1).Year.ToString(), Now.AddYears(-1).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.Year.ToString(), Now.Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(1).Year.ToString(), Now.AddYears(1).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(2).Year.ToString(), Now.AddYears(2).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(3).Year.ToString(), Now.AddYears(3).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(4).Year.ToString(), Now.AddYears(4).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(5).Year.ToString(), Now.AddYears(5).Year.ToString()))
        End With

        With Me.ddlYear2.Items
            .Clear()
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-5).Year.ToString(), Now.AddYears(-5).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-4).Year.ToString(), Now.AddYears(-4).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-3).Year.ToString(), Now.AddYears(-3).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-2).Year.ToString(), Now.AddYears(-2).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(-1).Year.ToString(), Now.AddYears(-1).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.Year.ToString(), Now.Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(1).Year.ToString(), Now.AddYears(1).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(2).Year.ToString(), Now.AddYears(2).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(3).Year.ToString(), Now.AddYears(3).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(4).Year.ToString(), Now.AddYears(4).Year.ToString()))
            .Add(New Telerik.Web.UI.RadComboBoxItem(Now.AddYears(5).Year.ToString(), Now.AddYears(5).Year.ToString()))
        End With

        Try
            If IsNumeric(Request.QueryString("y")) = True Then
                Me.ddlYear.SelectedValue = Request.QueryString("y")
                Me.ddlYear2.SelectedValue = Request.QueryString("y")
            Else
                Me.ddlYear.SelectedValue = Now.Year.ToString()
                Me.ddlYear2.SelectedValue = Now.Year.ToString()
            End If
        Catch ex As Exception
            Me.ddlYear.SelectedValue = Now.Year.ToString()
            Me.ddlYear2.SelectedValue = Now.Year.ToString()
        End Try
    End Sub
    Private Sub loadSCListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        ' Get both Production & Media sales classes
        SQL_STRING = "SELECT SC_CODE as code, SC_CODE + ' - ' + SC_DESCRIPTION as description FROM SALES_CLASS WHERE INACTIVE_FLAG = 0 Or INACTIVE_FLAG Is NULL"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            With Me.RadListBoxSalesClasses
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
    Private Sub LoadAEListbox()
        Dim ocPV As cProjectViewpoint = New cProjectViewpoint(CStr(Session("ConnString")))

        Me.RadListBoxAccountExecutives.ClearSelection()

        With Me.RadListBoxAccountExecutives
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

        Me.RadListBoxOffices.ClearSelection()

        With Me.RadListBoxOffices
            .DataSource = oDD.GetOfficesEmp(Session("UserCode"))
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()

            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
        End With

        PopulateOfficeListbox()

    End Sub
    Private Sub LoadFilterObjects()
        Dim strValue As String
        Dim boolVal As Boolean
        Dim tempDate As Date
        Dim mthStr, yrStr As String
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim NeedsSave As Boolean = False
        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT)

        tempDate = cEmployee.TimeZoneToday
        mthStr = CType(tempDate.Month, String)
        mthStr = mthStr.ToString.PadLeft(2, "0")
        yrStr = CType(tempDate.Year, String)

        appVars.getAllAppVars()

        strValue = appVars.getAppVar("PVMyProjectsOnly", "Boolean", "False")
        Me.CheckBoxMyProjects.Checked = CType(strValue, Boolean)

        strValue = appVars.getAppVar("PVInclClosedJobs", "Boolean", "False")
        Me.CheckboxClosedJobs.Checked = False 'CType(strValue, Boolean)

        strValue = appVars.getAppVar("PVExclJobsCompSched", "Boolean", "False")
        Me.CheckBoxExcludeJobsWithCompletedSchedules.Checked = CType(strValue, Boolean)

        strValue = appVars.getAppVar("PVMonth", "String", mthStr)
        Me.ddlMonth.SelectedValue = strValue

        strValue = appVars.getAppVar("PVYear", "String", yrStr)
        Me.ddlYear.SelectedValue = strValue

        strValue = appVars.getAppVar("PVMonth2", "String", mthStr)
        Me.ddlMonth2.SelectedValue = strValue

        strValue = appVars.getAppVar("PVYear2", "String", yrStr)
        Me.ddlYear2.SelectedValue = strValue

        strValue = appVars.getAppVar("PVForecast", "Number", "-1")
        Me.ddlForecast.SelectedIndex = CInt(strValue)

        strValue = appVars.getAppVar("PVQvAType", "Boolean", "False")
        Me.ddQvAType.SelectedValue = strValue

        strValue = appVars.getAppVar("PVQvAThreshold", "100")
        If IsNumeric(strValue) = False Then
            strValue = "100"
        End If
        Me.txtThreshold.Text = strValue

    End Sub
    Private Sub LoadCDPCListBox()

        Dim dr As SqlDataReader = Nothing
        Dim oSQL As SqlHelper = Nothing
        Dim MyObjDef As New AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Methods(Session("ConnString"), Session("UserCode"), Nothing)
        Dim HasDynamicRestriction As Boolean = False

        Dim CDPList As String = ""
        Dim AEList As String = ""
        Dim OfficeList As String = ""
        Dim FilterString As String = ""
        Dim AEIDX As Integer = 0

        HasDynamicRestriction = MyObjDef.EmployeeHasDynamicRestriction(Session("EmpCode"), AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects)

        If Me.CheckBoxMyProjects.Checked = False Then

            HasDynamicRestriction = False

        End If

        'Gather AE's to filter CDP list & Project Viewpoint by
        For AEIDX = 0 To Me.RadListBoxAccountExecutives.Items.Count - 1

            If Me.RadListBoxAccountExecutives.Items.Item(AEIDX).Selected = True Then

                If AEList = "" Then

                    If Me.RadListBoxAccountExecutives.Items.Item(AEIDX).Value = "ALL" Then

                        AEList = "ALL"
                        Exit For

                    End If

                    AEList = "('" & Me.RadListBoxAccountExecutives.Items.Item(AEIDX).Value & "'"

                Else

                    AEList = AEList & ",'" & Me.RadListBoxAccountExecutives.Items.Item(AEIDX).Value & "'"

                End If

            End If

        Next

        If AEList <> "ALL" And AEList <> "" Then

            AEList &= ")"

        End If

        If AEList = "" Then
            AEList = "ALL"
        End If

        Dim SQL As New System.Text.StringBuilder

        If AEList <> "ALL" Then

            If Me.RadioButtonListSelectionLevel.SelectedValue = "CAMPAIGN" Then

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

            If Me.RadioButtonListSelectionLevel.SelectedValue = "CAMPAIGN" Then

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

        Catch ex As Exception

            Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

        Finally

        End Try

        AEIDX = 0
        If dr.HasRows Then
            Do While dr.Read
                If CDPList = "" Then

                    CDPList = "("

                Else
                    CDPList = CDPList & ","

                End If
                Try
                    Select Case Me.RadioButtonListSelectionLevel.SelectedValue
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

        Me.RadListBoxCDPCSelections.Items.Clear()

        Dim dtData As DataTable = New DataTable
        Dim dtDataFiltered As DataTable = New DataTable
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        With Me.RadListBoxCDPCSelections

            Select Case Me.RadioButtonListSelectionLevel.SelectedValue
                Case "CDPC"

                    .Enabled = False
                    .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))

                    Exit Sub

                Case "CLIENT"

                    .Enabled = True

                    If HasDynamicRestriction = True Then

                        dtData.Load(oDD.GetClientListAE(Session("UserCode"), _
                                        AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects))
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
                                            AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects))


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
                                                             AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects))


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

                            dtData.Load(oDD.GetAllCampaignsAE(Session("UserCode"), _
                                                              AdvantageFramework.EmployeeUtilities.MyObjectsDefinition.Objects.ProjectViewpoint_MyProjects))

                        Else

                            dtData.Load(oDD.GetAllCampaignsWithCDP(Session("UserCode")))

                        End If

                    End If
            End Select

            If AEList = "ALL" And OfficeList = "ALL" Then

                .DataSource = dtData
                .DataValueField = "Code"
                .DataTextField = "Description"
                .DataBind()

            Else

                If CDPList <> "" Then

                    Dim dv As DataView = New DataView(dtData)
                    dv.RowFilter = "Code IN " & CDPList
                    dtDataFiltered = dv.ToTable()

                    .DataSource = dtDataFiltered
                    .DataValueField = "Code"
                    .DataTextField = "Description"
                    .DataBind()

                End If

            End If

        End With

    End Sub

    Private Sub SetListboxSelecteItems(ByVal dtSource As DataTable, ByVal lb As Telerik.Web.UI.RadListBox)
        If dtSource.Rows.Count > 0 And lb.Items.Count > 0 Then
            For i As Integer = 0 To dtSource.Rows.Count - 1
                If IsDBNull(dtSource.Rows(i)("SELECTED_VALUES")) = False Then
                    Try
                        lb.FindItemByValue(dtSource.Rows(i)("SELECTED_VALUES")).Selected = True
                    Catch ex As Exception
                    End Try
                End If
            Next
        End If
    End Sub
    Private Sub SetCDPCToAll()
        'Set default for CDPC selection:
        Me.RadioButtonListSelectionLevel.SelectedIndex = 0
        With Me.RadListBoxCDPCSelections
            .Items.Clear()
            .Enabled = False
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
        End With
    End Sub
    Private Sub SetOfficeToAll()
        RadListBoxOffices.FindItemByValue("ALL").Selected = True
    End Sub
    Private Sub SetManagerToAll()
        Me.RadListBoxManager.FindItemByValue("ALL").Selected = True
    End Sub
    Private Sub SetSCToAll()
        RadListBoxSalesClasses.FindItemByValue("ALL").Selected = True
    End Sub

    Private Sub PopulateAEListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim ae As String

        Me.RadListBoxAccountExecutives.ClearSelection()

        SQL_STRING = "SELECT EMP_CODE FROM PV_AE WHERE USERID = '" & CStr(Session("UserCode")) & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateAEListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                ae = dr.GetString(0)
                Try
                    RadListBoxAccountExecutives.FindItemByValue(ae).Selected = True
                Catch ex As Exception
                End Try
            Loop

        Else
            RadListBoxAccountExecutives.FindItemByValue("ALL").Selected = True
        End If
        dr.Close()
    End Sub
    Private Sub PopulateOfficeListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim office As String

        Me.RadListBoxOffices.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & "' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'OFFICE'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateOfficeListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                office = dr.GetString(0)
                Try
                    RadListBoxOffices.FindItemByValue(office).Selected = True
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

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & _
                        "' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'MANAGER'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateManagerListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                Manager = dr.GetString(0)
                Try
                    RadListBoxManager.FindItemByValue(Manager).Selected = True
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

        Me.RadListBoxSalesClasses.ClearSelection()

        SQL_STRING = "SELECT VARIABLE_VALUE FROM APP_VARS WHERE USERID = '" & CStr(Session("UserCode")) & "' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'SC'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateOfficeListbox", Err.Description)
        Finally
        End Try

        If dr.HasRows Then
            Do While dr.Read
                sc = dr.GetString(0)
                Try
                    RadListBoxSalesClasses.FindItemByValue(sc).Selected = True
                Catch ex As Exception
                End Try
            Loop
        Else
            SetSCToAll()
        End If
        dr.Close()
    End Sub
    Private Sub PopulateCDPListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING, SQL_STRING2 As String
        Dim dr, dr2 As SqlDataReader
        Dim CDPCString, CL_CODE, DIV_CODE, PRD_CODE, CMP_CODE, DESCRIPTION As String
        Dim CDPLoadLevel As Integer = 0
        Dim cmp_id As Integer
        Dim lbLoaded As Boolean = False

        SQL_STRING = "SELECT ISNULL(CL_CODE,''), ISNULL(DIV_CODE,''), ISNULL(PRD_CODE,'') FROM PV_CDP WHERE USERID = '" & CStr(Session("UserCode")) & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateCDPListbox", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            Do While dr.Read
                CDPCString = ""

                CL_CODE = dr.GetString(0)
                If CL_CODE <> "" Then
                    CDPCString = CDPCString & CL_CODE
                    CDPLoadLevel = 1
                End If

                DIV_CODE = dr.GetString(1)
                If DIV_CODE <> "" Then
                    CDPCString = CDPCString & " | " & DIV_CODE
                    CDPLoadLevel = 2
                End If

                PRD_CODE = dr.GetString(2)
                If PRD_CODE <> "" Then
                    CDPCString = CDPCString & " | " & PRD_CODE
                    CDPLoadLevel = 3
                End If

                Select Case CDPLoadLevel
                    Case 1
                        Me.RadioButtonListSelectionLevel.SelectedIndex = 1
                        SQL_STRING = "SELECT ISNULL(CL_NAME,'') FROM CLIENT WHERE CL_CODE = '" & CL_CODE & "'"
                    Case 2
                        Me.RadioButtonListSelectionLevel.SelectedIndex = 2
                        SQL_STRING = "SELECT ISNULL(DIV_NAME,'') FROM DIVISION WHERE CL_CODE = '" & CL_CODE & "' AND DIV_CODE = '" & DIV_CODE & "'"
                    Case 3
                        Me.RadioButtonListSelectionLevel.SelectedIndex = 3
                        SQL_STRING = "SELECT ISNULL(PRD_DESCRIPTION,'') FROM PRODUCT WHERE CL_CODE = '" & CL_CODE & "' AND DIV_CODE = '" & DIV_CODE & "' AND PRD_CODE = '" & PRD_CODE & "'"

                End Select

                If lbLoaded = False Then
                    LoadCDPCListBox()
                    lbLoaded = True
                End If

                Try
                    dr2 = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                Catch
                    Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateCDPListbox", Err.Description)
                Finally
                End Try

                If dr2.HasRows Then
                    dr2.Read()
                    DESCRIPTION = dr2.GetString(0)
                    If DESCRIPTION <> "" Then
                        CDPCString = CDPCString & " - " & DESCRIPTION
                    End If
                End If

                Try
                    'RadListBoxCDPCSelections.FindItemByValue(CDPCString).Selected = True
                    RadListBoxCDPCSelections.FindItemByText(CDPCString).Selected = True
                Catch ex As Exception
                End Try
            Loop

        Else 'Check Campaign table
            SQL_STRING = "SELECT CMP_IDENTIFIER FROM PV_CMP WHERE USERID = '" & CStr(Session("UserCode")) & "'"

            Try
                dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
            Catch
                Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateCDPListbox", Err.Description)
            Finally

            End Try

            If dr.HasRows Then
                CDPLoadLevel = 4
                'Me.RadioButtonListSelectionLevel.SelectedValue = "CAMPAIGN"
                Me.RadioButtonListSelectionLevel.SelectedIndex = 4
                LoadCDPCListBox()

                Do While dr.Read
                    cmp_id = dr.GetInt32(0)
                    SQL_STRING = "SELECT ISNULL(CL_CODE,''), ISNULL(DIV_CODE,''), ISNULL(PRD_CODE,''), ISNULL(CMP_CODE,''), ISNULL(CMP_NAME,'') FROM CAMPAIGN WHERE CMP_IDENTIFIER = " & CStr(cmp_id)

                    Try
                        dr2 = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
                    Catch
                        Err.Raise(Err.Number, "Class:ProjectViewpointFilter Routine:PopulateCDPListbox", Err.Description)
                    Finally

                    End Try

                    If dr2.HasRows Then
                        dr2.Read()

                        CDPCString = dr2.GetString(0)

                        DIV_CODE = dr2.GetString(1)
                        CDPCString = CDPCString & " | " & DIV_CODE

                        PRD_CODE = dr2.GetString(2)
                        CDPCString = CDPCString & " | " & PRD_CODE

                        CMP_CODE = dr2.GetString(3)
                        CDPCString = CDPCString & " | " & CMP_CODE

                        DESCRIPTION = dr2.GetString(4)
                        CDPCString = CDPCString & " - " & DESCRIPTION

                        Try
                            RadListBoxCDPCSelections.FindItemByText(CDPCString).Selected = True
                        Catch ex As Exception
                        End Try

                    End If
                Loop

            Else 'All 
                SetCDPCToAll()
            End If

        End If

        dr.Close()
    End Sub

    Private Sub SaveFilter()
        Try
            Dim thresh As Integer = 0
            If IsNumeric(txtThreshold.Text) = False Then
                Me.LblMSG.Text = "Invalid threshold"
                Me.txtThreshold.Focus()
                Exit Sub
            Else
                thresh = CType(Me.txtThreshold.Text, Integer)
                If thresh > 100 Then
                    thresh = 100
                ElseIf thresh < 0 Then
                    thresh = 0
                End If
            End If
            txtThreshold.Text = thresh.ToString()

            Dim sLoadLevel As String = Me.RadioButtonListSelectionLevel.SelectedValue.ToUpper
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sAEs As String = ""
            Dim sm As String = ""

            If BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs) = False Then

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

            mth = CType(Me.ddlMonth.SelectedValue, Integer)
            yr = CType(Me.ddlYear.SelectedValue, Integer)

            startDate = CStr(mth) & "/1/" & CStr(yr)
            tempDate = mth & "/1/" & yr
            days = tempDate.DaysInMonth(yr, mth)
            endDate = CStr(mth) & "/" & CStr(days) & "/" & CStr(yr)

            Session("startDatePV") = startDate
            Session("endDatePV") = endDate

            If Me.CheckboxClosedJobs.Checked Then
                Session("inclClosedJobsPV") = "N"
            Else
                Session("inclClosedJobsPV") = "N"
            End If

            If Me.CheckBoxMyProjects.Checked Then
                Session("PVMyProjectsOnly") = "Y"
            Else
                Session("PVMyProjectsOnly") = "N"
            End If

            If Me.CheckBoxExcludeJobsWithCompletedSchedules.Checked Then
                Session("PVExclJobsCompSched") = "Y"
            Else
                Session("PVExclJobsCompSched") = "N"
            End If
            '0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
            Select Case Me.RadioButtonListSelectionLevel.SelectedValue
                Case "CDPC"
                    Session("cdpcLevelPV") = "0"
                Case "CLIENT"
                    Session("cdpcLevelPV") = "1"
                Case "DIVISION"
                    Session("cdpcLevelPV") = "2"
                Case "PRODUCT"
                    Session("cdpcLevelPV") = "3"
                Case "CAMPAIGN"
                    Session("cdpcLevelPV") = "4"
            End Select

            If sAEs.Length > 0 And sAEs <> "'ALL'" Then
                Session("inclAEPV") = "Y"
            Else
                Session("inclAEPV") = "N"
            End If


        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString()
            Exit Sub
        End Try
        'Me.GoBack()
        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("ProjectViewpoint"), RadToolBarButton).Checked = True
        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("BudgetViewpoint"), RadToolBarButton).Checked = False
        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("HoursViewpoint"), RadToolBarButton).Checked = False
        CType(Me.RadToolbarProjectViewpoint.FindItemByValue("FilterView"), RadToolBarButton).Checked = False

        Session("currentPVView") = 0

        Me.MultiView1.ActiveViewIndex = 0
        Me.MultiView1.SetActiveView(Me.ViewMain)
        Me.RadGridProjectViewpointMain.Rebind()
        Me.ResetPageIndex()

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

    Private Function SaveSelections(ByVal LoadLevel As String, ByVal AESelectionString As String, ByVal CDPCSelectionString As String) As String

        Dim appVars As New cAppVars(cAppVars.Application.PROJECTVIEWPOINT)
        appVars.setAppVar("PVMyProjectsOnly", Me.CheckBoxMyProjects.Checked.ToString(), "Boolean")
        appVars.setAppVar("PVInclClosedJobs", Me.CheckboxClosedJobs.Checked.ToString(), "Boolean")
        appVars.setAppVar("PVMonth", Me.ddlMonth.SelectedValue, "String")
        appVars.setAppVar("PVYear", Me.ddlYear.SelectedValue, "String")
        appVars.setAppVar("PVMonth2", Me.ddlMonth2.SelectedValue, "String")
        appVars.setAppVar("PVYear2", Me.ddlYear2.SelectedValue, "String")
        appVars.setAppVar("PVForecast", CStr(Me.ddlForecast.SelectedIndex), "String")
        appVars.setAppVar("PVExclJobsCompSched", Me.CheckBoxExcludeJobsWithCompletedSchedules.Checked.ToString(), "Boolean")

        appVars.setAppVar("PVQvAType", Me.ddQvAType.SelectedValue, "String")
        If IsNumeric(Me.txtThreshold.Text) = False Then
            Me.LblMSG.Text = "Invalid threshold"
            Exit Function
        Else
            appVars.setAppVar("PVQvAThreshold", Me.txtThreshold.Text, "String")
        End If
        appVars.setAppVar("SelectionLevel", Me.RadioButtonListSelectionLevel.SelectedValue, "String")
        appVars.SaveAllAppVars()

        Try
            Dim SbSQL As New System.Text.StringBuilder
            Dim SbSQLDelete As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim value As String
            Dim UserCode As String = Session("UserCode")

            ' clear out existing data first:
            With SbSQLDelete
                .Append("DELETE FROM PV_AE WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM PV_CDP WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM PV_CMP WITH(ROWLOCK) WHERE USERID = '")
                .Append(UserCode)
                .Append("';")
                .Append("DELETE FROM APP_VARS WHERE USERID = '")
                .Append(UserCode)
                .Append("' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'OFFICE' ")
                .Append(";")
                .Append("DELETE FROM APP_VARS WHERE USERID = '")
                .Append(UserCode)
                .Append("' AND APPLICATION = 'PROJECTVIEWPOINT' AND VARIABLE_GROUP = 'SC' ")
                .Append(";")
            End With

            StrSQL = SbSQLDelete.ToString()

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
                        Return "Error saving selections SQL:&nbsp;&nbsp;" & ex.Message.ToString()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using
            End If

            StrSQL = ""

            'Insert variable data
            If AESelectionString.Trim() <> "" Then
                Dim arAE() As String
                arAE = AESelectionString.Split(",")
                For i As Integer = 0 To arAE.Length - 1
                    With SbSQL
                        .Append("INSERT INTO PV_AE (USERID, EMP_CODE) VALUES ('")
                        .Append(UserCode)
                        .Append("',")
                        .Append(arAE(i).ToString())
                        .Append(");")
                    End With
                Next
            End If

            'Save Selected Office values from listbox.
            For i As Integer = 0 To Me.RadListBoxOffices.Items.Count - 1
                If Me.RadListBoxOffices.Items(i).Selected = True Then
                    value = Me.RadListBoxOffices.Items(i).Value
                    With SbSQL
                        .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                        .Append(UserCode)
                        .Append("','PROJECTVIEWPOINT','OFFICE','")
                        .Append(value)
                        .Append("','String','")
                        .Append(value)
                        .Append("');")
                    End With
                    If i = 0 And value = "ALL" Then Exit For
                End If
            Next

            'Save Selected Sales Class values from listbox.
            For i As Integer = 0 To Me.RadListBoxSalesClasses.Items.Count - 1
                If Me.RadListBoxSalesClasses.Items(i).Selected = True Then
                    value = Me.RadListBoxSalesClasses.Items(i).Value
                    With SbSQL
                        .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                        .Append(UserCode)
                        .Append("','PROJECTVIEWPOINT','SC','")
                        .Append(value)
                        .Append("','String','")
                        .Append(value)
                        .Append("');")
                    End With
                    If i = 0 And value = "ALL" Then Exit For
                End If
            Next

            'Save Selected Manager values from listbox.
            For i As Integer = 0 To Me.RadListBoxManager.Items.Count - 1
                If Me.RadListBoxManager.Items(i).Selected = True Then
                    value = Me.RadListBoxManager.Items(i).Value
                    With SbSQL
                        .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                        .Append(UserCode)
                        .Append("','PROJECTVIEWPOINT','MANAGER','")
                        .Append(value)
                        .Append("','String','")
                        .Append(value)
                        .Append("');")
                    End With
                    If i = 0 And value = "ALL" Then Exit For
                End If
            Next

            If CDPCSelectionString.Trim() <> "" Then
                Dim j As Integer = 0
                Dim arCDP() As String
                arCDP = CDPCSelectionString.Split(",")
                Select Case LoadLevel
                    Case "CDPC" 'This is "all"...no criteria set
                        'no save needed to cdp and campaign table
                    Case "CLIENT"
                        For j = 0 To arCDP.Length - 1
                            If arCDP(j) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO PV_CDP (USERID,CL_CODE,DIV_CODE,PRD_CODE) VALUES ('")
                                    .Append(UserCode)
                                    .Append("','")
                                    .Append(arCDP(j).ToString())
                                    .Append("',NULL,NULL);")
                                End With
                            End If
                        Next
                    Case "DIVISION"
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            If arSplit(0) <> "" And arSplit(1) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO PV_CDP (USERID,CL_CODE,DIV_CODE,PRD_CODE) VALUES ('")
                                    .Append(UserCode)
                                    .Append("','")
                                    .Append(arSplit(0).ToString()) 'client code
                                    .Append("','")
                                    .Append(arSplit(1).ToString()) 'division code
                                    .Append("',NULL);")
                                End With
                            End If
                        Next
                    Case "PRODUCT"
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            If arSplit(0) <> "" And arSplit(1) <> "" And arSplit(2) <> "" Then
                                With SbSQL
                                    .Append("INSERT INTO PV_CDP (USERID,CL_CODE,DIV_CODE,PRD_CODE) VALUES ('")
                                    .Append(UserCode)
                                    .Append("','")
                                    .Append(arSplit(0).ToString()) 'client code
                                    .Append("','")
                                    .Append(arSplit(1).ToString()) 'division code
                                    .Append("','")
                                    .Append(arSplit(2).ToString()) 'product code
                                    .Append("');")
                                End With
                            End If
                        Next
                    Case "CAMPAIGN"
                        'will need to build the cdp string for insert as well as the cmp identifier string! (?)
                        For j = 0 To arCDP.Length - 1
                            Dim arSplit() As String
                            arSplit = arCDP(j).Split(":")
                            With SbSQL

                                'CMP IDENTIFIER:
                                .Append("INSERT INTO PV_CMP (USERID,CMP_IDENTIFIER) VALUES ('")
                                .Append(UserCode)
                                .Append("','")
                                .Append(arSplit(4).ToString()) 'campaign identifier
                                .Append("');")
                            End With
                        Next

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

    Private Function ValidateData() As Boolean
        'If Me.TxtBatchDescription.Text.Trim = "" Then
        '    Me.LblMSG.Text = "Please enter a batch description."
        '    Me.TxtBatchDescription.Focus()
        '    Return False
        'End If

        Return True
    End Function

    Private Sub CheckBoxMyProjects_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxMyProjects.CheckedChanged

        Me.LoadCDPCListBox()

    End Sub
    Private Sub RadioButtonListSelectionLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonListSelectionLevel.SelectedIndexChanged

        Me.LoadCDPCListBox()

    End Sub
    Private Sub RadListBoxAccountExecutives_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListBoxAccountExecutives.SelectedIndexChanged

        LoadCDPCListBox()

    End Sub
    Private Sub RadListBoxOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadListBoxOffices.SelectedIndexChanged

        LoadCDPCListBox()

    End Sub

#End Region

#End Region

#End Region

End Class
