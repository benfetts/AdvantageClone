Imports System.Text
Imports Webvantage.MiscFN
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports eWorld.UI.CollapsablePanel

Imports Webvantage.cGlobals

Partial Public Class ProjectViewpoint_Filter
    Inherits Webvantage.BaseChildPage
    Public strTimeOnly As String
    Public strThreshold As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Project Viewpoint Setup"
        strTimeOnly = Me.ddQvAType.SelectedValue
        If IsNumeric(Me.txtThreshold.Text.Trim) Then
            strThreshold = Me.txtThreshold.Text.Trim
        Else
            strThreshold = "80"
        End If
        If Not Me.IsPostBack Or Me.IsCallback Then
            Me.LoadFilterView()
        End If
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

            Dim sLoadLevel As String = Me.RblSelectionLevel.SelectedValue.ToUpper
            Dim sSelectionsBase As String = ""
            Dim sClients As String = ""
            Dim sDivisions As String = ""
            Dim sProducts As String = ""
            Dim sCampaigns As String = ""
            Dim sAEs As String = ""
            Dim sm As String = ""

            BuildCodeStrings(sLoadLevel, sSelectionsBase, sClients, sDivisions, sProducts, sCampaigns, sAEs)

            sm = Me.SaveSelections(sLoadLevel, sAEs, sSelectionsBase)
            If sm <> "" Then
                Me.LblMSG.Text = sm
                Exit Sub
            End If
            'Save into session variables for parent main page
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

            If Me.cbClosedJobs.Checked Then
                Session("inclClosedJobsPV") = "Y"
            Else
                Session("inclClosedJobsPV") = "N"
            End If

            If Me.cbMyProjects.Checked Then
                Session("PVMyProjectsOnly") = "Y"
            Else
                Session("PVMyProjectsOnly") = "N"
            End If

            '0-none; 1-c; 2-c/d; 3-c/d/p; 4-campaign
            Select Case Me.RblSelectionLevel.SelectedValue
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
        Me.GoBack()
    End Sub

    Private Sub LoadFilterView()
        If Not Me.IsPostBack And Not Me.Page.IsCallback Then
            Dim otask As New cTasks(Session("ConnString"))
            If otask.getAppVars(Session("UserCode"), "PROJECTVIEWPOINT", "PVMyProjectsOnly") = "" Then
                otask.setAppVars(Session("UserCode"), "PROJECTVIEWPOINT", "PVMyProjectsOnly", "System.Boolean", "True")
            End If
        End If
        'Me.MultiView1.ActiveViewIndex = 1
        '''Me.MultiView1.SetActiveView(ViewFilter)

        LoadMonths()
        LoadYears()
        LoadAEListbox()
        LoadOfficeListbox()
        loadSCListbox()

        PopulateCDPListbox()
        LoadFilterObjects()


        'redirectRefresh()

    End Sub
#Region "Filter Procedures/Functions"

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
        Me.RblSelectionLevel.SelectedIndex = 0
        With Me.LbCDPCSelections
            .Items.Clear()
            .Enabled = False
            .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL", "ALL"))
        End With
    End Sub

    Private Sub SetOfficeToAll()
        LBOffice.FindItemByValue("ALL").Selected = True
    End Sub

    Private Sub SetSCToAll()
        LBSC.FindItemByValue("ALL").Selected = True
    End Sub

    Private Sub PopulateAEListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim ae As String

        Me.LbAEs.ClearSelection()

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
                    LbAEs.FindItemByValue(ae).Selected = True
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
                    LBOffice.FindItemByValue(office).Selected = True
                Catch ex As Exception
                End Try
            Loop
        Else
            SetOfficeToAll()
        End If
        dr.Close()
    End Sub

    Private Sub PopulateSalesClassListbox()
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim sc As String

        Me.LBSC.ClearSelection()

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
                    LBSC.FindItemByValue(sc).Selected = True
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
                        Me.RblSelectionLevel.SelectedIndex = 1
                        SQL_STRING = "SELECT ISNULL(CL_NAME,'') FROM CLIENT WHERE CL_CODE = '" & CL_CODE & "'"
                    Case 2
                        Me.RblSelectionLevel.SelectedIndex = 2
                        SQL_STRING = "SELECT ISNULL(DIV_NAME,'') FROM DIVISION WHERE CL_CODE = '" & CL_CODE & "' AND DIV_CODE = '" & DIV_CODE & "'"
                    Case 3
                        Me.RblSelectionLevel.SelectedIndex = 3
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
                    'LbCDPCSelections.FindItemByValue(CDPCString).Selected = True
                    LbCDPCSelections.FindItemByText(CDPCString).Selected = True
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
                'Me.RblSelectionLevel.SelectedValue = "CAMPAIGN"
                Me.RblSelectionLevel.SelectedIndex = 4
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
                            LbCDPCSelections.FindItemByText(CDPCString).Selected = True
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

    Private StrAEs As String = ""
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

    Private Sub RblSelectionLevel_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblSelectionLevel.SelectedIndexChanged
        Me.LoadCDPCListBox()

        If RblSelectionLevel.SelectedValue = "CAMPAIGN" Then
            'Webvantage.MiscFN.SetToolbarButtonEnabled(OptionsRadToolbar, 2, False)
        Else
            'Webvantage.MiscFN.SetToolbarButtonEnabled(OptionsRadToolbar, 2, True)
        End If
    End Sub

    Private Sub LoadCDPCListBox()
        Dim CDPList As String = ""
        Dim AEList As String = ""
        Dim OfficeList As String = ""
        Dim FilterString As String = ""
        Dim AEIDX As Integer
        Dim SQL_STRING As String
        Dim SQL_SELECT As String = ""
        Dim SQL_FROM As String = ""
        Dim SQL_WHERE As String = ""
        Dim dr As SqlDataReader
        Dim oSQL As SqlHelper

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

        '*****************************************************************************************
        'jtg - commented out 5/5/2010 - Segue Issue 1104 - Do not limit CDP selection by Office
        '       Still Save because will still filter jobs in main view
        '*****************************************************************************************
        'Gather Offices's to filter CDP list & Project Viewpoint by
        'For AEIDX = 0 To Me.LBOffice.Items.Count - 1
        '    If Me.LBOffice.Items.Item(AEIDX).Selected = True Then
        '        If OfficeList = "" Then
        '            If Me.LBOffice.Items.Item(AEIDX).Value = "ALL" Then
        '                OfficeList = "ALL"
        '                Exit For
        '            End If
        '            OfficeList = "('" & Me.LBOffice.Items.Item(AEIDX).Value & "'"
        '        Else
        '            OfficeList &= ",'" & Me.LBOffice.Items.Item(AEIDX).Value & "'"
        '        End If
        '    End If
        'Next
        'If OfficeList <> "ALL" And OfficeList <> "" Then
        '    OfficeList &= ")"
        'End If

        If AEList <> "ALL" Then ' Or OfficeList <> "ALL" Then
            If Me.RblSelectionLevel.SelectedValue = "CAMPAIGN" Then
                SQL_SELECT = "SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                SQL_FROM = " FROM CAMPAIGN C "
                SQL_FROM &= " INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE "
                SQL_FROM &= " LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE "
                SQL_FROM &= " LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE "
                SQL_FROM &= " INNER JOIN ACCOUNT_EXECUTIVE AE ON C.CL_CODE = AE.CL_CODE  "
                SQL_FROM &= "   AND ( C.DIV_CODE = AE.DIV_CODE OR C.DIV_CODE IS NULL) "
                SQL_FROM &= "   AND ( C.PRD_CODE = AE.PRD_CODE OR C.PRD_CODE IS NULL) "
                SQL_FROM &= "   AND AE.EMP_CODE IN " & AEList
                SQL_WHERE = " WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )"

                'SQL_STRING = "SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                'SQL_STRING &= " FROM ACCOUNT_EXECUTIVE AE INNER JOIN CAMPAIGN C ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE	AND C.PRD_CODE = AE.PRD_CODE "
                'SQL_STRING &= " WHERE AE.DEFAULT_AE = 1 AND AE.EMP_CODE IN " & AEList
                'If OfficeList <> "ALL" Then
                '    SQL_SELECT = "SELECT DISTINCT P.CL_CODE, P.DIV_CODE, P.PRD_CODE, C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                '    SQL_FROM = "	FROM         PRODUCT AS P INNER JOIN"
                '    SQL_FROM &= "						  CAMPAIGN AS C ON C.CL_CODE = P.CL_CODE AND C.DIV_CODE = P.DIV_CODE AND C.PRD_CODE = P.PRD_CODE INNER JOIN"
                '    SQL_FROM &= "						  DIVISION ON P.CL_CODE = DIVISION.CL_CODE AND P.DIV_CODE = DIVISION.DIV_CODE INNER JOIN"
                '    SQL_FROM &= "						  CLIENT ON P.CL_CODE = CLIENT.CL_CODE"
                '    SQL_WHERE = " WHERE P.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND P.OFFICE_CODE IN " & OfficeList

                '    If AEList <> "ALL" Then
                '        SQL_FROM &= " INNER JOIN ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE "
                '        SQL_WHERE &= " AND AE.DEFAULT_AE = 1 AND AE.EMP_CODE IN " & AEList
                '        SQL_WHERE &= " AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) "
                '    End If

                'Else    'Only filter by AE
                'SQL_SELECT = "SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                'SQL_FROM = " FROM         PRODUCT INNER JOIN"
                'SQL_FROM &= "                       ACCOUNT_EXECUTIVE AS AE INNER JOIN "
                'SQL_FROM &= "                       CAMPAIGN AS C ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE AND C.PRD_CODE = AE.PRD_CODE ON "
                'SQL_FROM &= "                       PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN "
                'SQL_FROM &= "                       CLIENT INNER JOIN"
                'SQL_FROM &= "                       DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE "
                'SQL_WHERE = " WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND  AE.DEFAULT_AE = 1 AND AE.EMP_CODE IN " & AEList
                'SQL_WHERE &= " AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) "
                'End If

            Else
                'If OfficeList <> "ALL" Then
                '    SQL_SELECT = "SELECT DISTINCT P.CL_CODE, P.DIV_CODE, P.PRD_CODE "
                '    SQL_FROM = "	FROM         PRODUCT AS P LEFT OUTER JOIN"
                '    SQL_FROM &= "						  CAMPAIGN AS C ON C.CL_CODE = P.CL_CODE AND C.DIV_CODE = P.DIV_CODE AND C.PRD_CODE = P.PRD_CODE INNER JOIN"
                '    SQL_FROM &= "						  DIVISION ON P.CL_CODE = DIVISION.CL_CODE AND P.DIV_CODE = DIVISION.DIV_CODE INNER JOIN"
                '    SQL_FROM &= "						  CLIENT ON P.CL_CODE = CLIENT.CL_CODE"
                '    SQL_WHERE = " WHERE P.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND P.OFFICE_CODE IN " & OfficeList

                '    If AEList <> "ALL" Then
                '        SQL_FROM &= " INNER JOIN ACCOUNT_EXECUTIVE AE ON P.CL_CODE = AE.CL_CODE AND P.DIV_CODE = AE.DIV_CODE AND P.PRD_CODE = AE.PRD_CODE "
                '        SQL_WHERE &= " AND AE.DEFAULT_AE = 1 AND AE.EMP_CODE IN " & AEList
                '        SQL_WHERE &= " AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) "
                '    End If

                'Else    'Only filter by AE
                'SQL_SELECT = "SELECT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, AE.EMP_CODE "

                SQL_SELECT = "SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE "
                SQL_FROM &= " FROM         PRODUCT INNER JOIN"
                SQL_FROM &= "                      ACCOUNT_EXECUTIVE AS AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND "
                SQL_FROM &= "                      PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN"
                SQL_FROM &= "                      DIVISION INNER JOIN"
                SQL_FROM &= "                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE"
                SQL_WHERE = " WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND AE.EMP_CODE IN " & AEList
                SQL_WHERE &= " AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) "
                'End If
            End If

        Else
            If Me.RblSelectionLevel.SelectedValue = "CAMPAIGN" Then
                SQL_SELECT = "SELECT DISTINCT C.CL_CODE, ISNULL(C.DIV_CODE,''), ISNULL(C.PRD_CODE,''), C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                SQL_FROM = " FROM CAMPAIGN C "
                SQL_FROM &= " INNER JOIN CLIENT CL ON C.CL_CODE = CL.CL_CODE "
                SQL_FROM &= " LEFT OUTER JOIN DIVISION D ON D.CL_CODE = C.CL_CODE AND D.DIV_CODE = C.DIV_CODE "
                SQL_FROM &= " LEFT OUTER JOIN PRODUCT P ON P.CL_CODE = C.CL_CODE AND P.DIV_CODE = C.DIV_CODE AND P.PRD_CODE = C.PRD_CODE "
                SQL_WHERE = " WHERE C.CMP_TYPE = 2 AND (C.CMP_CLOSED = 0 OR C.CMP_CLOSED IS NULL )"
                'SQL_SELECT = "SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE, C.CMP_CODE, CAST(C.CMP_IDENTIFIER AS VARCHAR) "
                'SQL_FROM = " FROM         PRODUCT INNER JOIN"
                'SQL_FROM &= "                       ACCOUNT_EXECUTIVE AS AE INNER JOIN "
                'SQL_FROM &= "                       CAMPAIGN AS C ON C.CL_CODE = AE.CL_CODE AND C.DIV_CODE = AE.DIV_CODE AND C.PRD_CODE = AE.PRD_CODE ON "
                'SQL_FROM &= "                       PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN "
                'SQL_FROM &= "                       CLIENT INNER JOIN"
                'SQL_FROM &= "                       DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE "
                'SQL_WHERE = " WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 AND  AE.DEFAULT_AE = 1 "
                'SQL_WHERE &= " AND (AE.INACTIVE_FLAG = 0 OR AE.INACTIVE_FLAG IS NULL) "

            Else
                SQL_SELECT = " SELECT DISTINCT PRODUCT.CL_CODE, PRODUCT.DIV_CODE, PRODUCT.PRD_CODE "
                SQL_FROM &= " FROM CLIENT"
                SQL_FROM &= " INNER JOIN DIVISION ON CLIENT.CL_CODE = DIVISION.CL_CODE "
                SQL_FROM &= " INNER JOIN PRODUCT ON DIVISION.CL_CODE = PRODUCT.CL_CODE AND DIVISION.DIV_CODE = PRODUCT.DIV_CODE "
                SQL_WHERE = " WHERE PRODUCT.ACTIVE_FLAG = 1 And CLIENT.ACTIVE_FLAG = 1 And DIVISION.ACTIVE_FLAG = 1 "
                'SQL_SELECT = "SELECT DISTINCT AE.CL_CODE, AE.DIV_CODE, AE.PRD_CODE "
                'SQL_FROM &= " FROM PRODUCT INNER JOIN"
                'SQL_FROM &= "                      ACCOUNT_EXECUTIVE AS AE ON PRODUCT.CL_CODE = AE.CL_CODE AND PRODUCT.DIV_CODE = AE.DIV_CODE AND "
                'SQL_FROM &= "                      PRODUCT.PRD_CODE = AE.PRD_CODE INNER JOIN"
                'SQL_FROM &= "                      DIVISION INNER JOIN"
                'SQL_FROM &= "                      CLIENT ON DIVISION.CL_CODE = CLIENT.CL_CODE ON PRODUCT.CL_CODE = DIVISION.CL_CODE AND PRODUCT.DIV_CODE = DIVISION.DIV_CODE"
                'SQL_WHERE = " WHERE PRODUCT.ACTIVE_FLAG = 1 AND CLIENT.ACTIVE_FLAG = 1 AND DIVISION.ACTIVE_FLAG = 1 "
            End If

        End If

        SQL_STRING = SQL_SELECT & SQL_FROM & SQL_WHERE

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:JobVerTmplt.ascx Routine:AddControl", Err.Description)
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

        Dim dtData As DataTable
        Dim dtDataFiltered As DataTable

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        With Me.LbCDPCSelections
            Select Case Me.RblSelectionLevel.SelectedValue
                Case "CDPC"
                    .Enabled = False
                    .Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("ALL"))
                    Exit Sub

                Case "CLIENT"
                    .Enabled = True
                    dtData = Me.GetClientList(Session("UserCode"))

                Case "DIVISION"
                    .Enabled = True
                    dtData = Me.GetDivisionsAll(Session("UserCode"))

                Case "PRODUCT"
                    .Enabled = True
                    dtData = Me.GetProductsAll(Session("UserCode"))

                Case "CAMPAIGN"
                    .Enabled = True
                    dtData = Me.GetAllCampaignsWithCDP(Session("UserCode"))

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

    Private Function SaveSelections(ByVal LoadLevel As String, ByVal AESelectionString As String, ByVal CDPCSelectionString As String) As String
        Try
            Dim SbSQL As New System.Text.StringBuilder
            Dim SbSQLDelete As New System.Text.StringBuilder
            Dim StrSQL As String = ""
            Dim value As String
            Dim UserCode As String = Session("UserCode")
            Dim cPV As cProjectViewpoint = New cProjectViewpoint()

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
            For i As Integer = 0 To Me.LBOffice.Items.Count - 1
                If Me.LBOffice.Items(i).Selected = True Then
                    value = Me.LBOffice.Items(i).Value
                    With SbSQL
                        .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                        .Append(UserCode)
                        .Append("','PROJECTVIEWPOINT','OFFICE','")
                        .Append(value)
                        .Append("','String','")
                        .Append(value)
                        .Append("');")
                    End With
                End If
            Next

            'Save Selected Sales Class values from listbox.
            For i As Integer = 0 To Me.LBSC.Items.Count - 1
                If Me.LBSC.Items(i).Selected = True Then
                    value = Me.LBSC.Items(i).Value
                    With SbSQL
                        .Append("INSERT INTO APP_VARS (USERID, APPLICATION, VARIABLE_GROUP, VARIABLE_NAME, VARIABLE_TYPE, VARIABLE_VALUE) VALUES('")
                        .Append(UserCode)
                        .Append("','PROJECTVIEWPOINT','SC','")
                        .Append(value)
                        .Append("','String','")
                        .Append(value)
                        .Append("');")
                    End With
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

            cPV.setAppVars("PVMyProjectsOnly", Me.cbMyProjects.Checked.GetType.ToString(), Me.cbMyProjects.Checked.ToString())
            cPV.setAppVars("PVInclClosedJobs", Me.cbClosedJobs.Checked.GetType.ToString(), Me.cbClosedJobs.Checked.ToString())
            cPV.setAppVars("PVMonth", "String", Me.ddlMonth.SelectedValue)
            cPV.setAppVars("PVYear", "String", Me.ddlYear.SelectedValue)
            cPV.setAppVars("PVMonth2", "String", Me.ddlMonth2.SelectedValue)
            cPV.setAppVars("PVYear2", "String", Me.ddlYear2.SelectedValue)
            cPV.setAppVars("PVForecast", "String", CStr(Me.ddlForecast.SelectedIndex))

            cPV.setAppVars("PVQvAType", "String", Me.ddQvAType.SelectedValue)
            If IsNumeric(Me.txtThreshold.Text) = False Then
                Me.LblMSG.Text = "Invalid threshold"
                Exit Function
            Else
                cPV.setAppVars("PVQvAThreshold", "String", Me.txtThreshold.Text)
            End If
            cPV.setAppVars("SelectionLevel", "String", Me.RblSelectionLevel.SelectedValue)

            'With Response
            '    .Cookies("PVInclClosedJobs").Value = Me.cbClosedJobs.Checked
            '    .Cookies("PVInclClosedJobs").Expires = DateTime.Now.AddDays(14)
            '    .Cookies("PVMonth").Value = Me.ddlMonth.Text
            '    .Cookies("PVMonth").Expires = DateTime.Now.AddDays(14)
            '    .Cookies("PVYear").Value = Me.ddlYear.Text
            '    .Cookies("PVYear").Expires = DateTime.Now.AddDays(14)
            'End With

            Return ""
        Catch ex As Exception
            Return "Error saving filter selections:&nbsp;&nbsp;" & ex.Message.ToString()
        End Try
    End Function

    Private Sub LoadFilterObjects()
        Dim strValue As String
        Dim boolVal As Boolean
        Dim tempDate As Date
        Dim mthStr, yrStr As String
        Dim cPV As cProjectViewpoint = New cProjectViewpoint()
        Dim appVars As New cAppVars("PROJECTVIEWPOINT", Session("UserCode"))

        tempDate = System.DateTime.Today
        mthStr = CType(tempDate.Month, String)
        mthStr = mthStr.ToString.PadLeft(2, "0")
        yrStr = CType(tempDate.Year, String)

        appVars.getAllAppVars()

        'strValue = cPV.getAppVars("PVMyProjectsOnly")
        strValue = appVars.getAppVar("PVMyProjectsOnly", "Boolean", "False")
        'If strValue = "" Then
        'strValue = "False"
        'cPV.setAppVars("PVMyProjectsOnly", "System.Boolean", strValue)
        'End If
        Me.cbMyProjects.Checked = CType(strValue, Boolean)

        'strValue = cPV.getAppVars("PVInclClosedJobs")
        strValue = appVars.getAppVar("PVInclClosedJobs", "Boolean", "False")
        'If strValue = "" Then
        '    strValue = "False"
        '    cPV.setAppVars("PVInclClosedJobs", "System.Boolean", strValue)
        'End If
        Me.cbClosedJobs.Checked = CType(strValue, Boolean)

        'strValue = cPV.getAppVars("PVMonth")
        strValue = appVars.getAppVar("PVMonth")
        If strValue = "" Then
            strValue = mthStr
            cPV.setAppVars("PVMonth", "String", strValue)
        End If
        Me.ddlMonth.SelectedValue = strValue

        'strValue = cPV.getAppVars("PVYear")
        strValue = appVars.getAppVar("PVYear")
        If strValue = "" Then
            strValue = yrStr
            cPV.setAppVars("PVYear", "String", strValue)
        End If
        Me.ddlYear.SelectedValue = strValue

        'strValue = cPV.getAppVars("PVMonth2")
        strValue = appVars.getAppVar("PVMonth2")
        If strValue = "" Then
            strValue = mthStr
            cPV.setAppVars("PVMonth2", "String", strValue)
        End If
        Me.ddlMonth2.SelectedValue = strValue

        'strValue = cPV.getAppVars("PVYear2")
        strValue = appVars.getAppVar("PVYear2")
        If strValue = "" Then
            strValue = yrStr
            cPV.setAppVars("PVYear2", "String", strValue)
        End If
        Me.ddlYear2.SelectedValue = strValue

        'strValue = cPV.getAppVars("PVForecast")
        strValue = appVars.getAppVar("PVForecast", "Number")
        'If strValue = "" Then
        '    strValue = "0"
        '    cPV.setAppVars("PVForecast", "String", strValue)
        'End If
        Me.ddlForecast.SelectedIndex = CInt(strValue)

        'strValue = cPV.getAppVars("PVQvAType")
        strValue = appVars.getAppVar("PVQvAType", "Boolean")
        'If strValue = "" Then
        '    strValue = "False"
        '    cPV.setAppVars("PVQvAType", "String", strValue)
        'End If
        Me.ddQvAType.SelectedValue = strValue

        'strValue = cPV.getAppVars("PVQvAThreshold")
        strValue = appVars.getAppVar("PVQvAThreshold")
        If strValue = "" Then
            strValue = "80"
            cPV.setAppVars("PVQvAThreshold", "String", strValue)
        End If
        If IsNumeric(strValue) = False Then
            strValue = "80"
            cPV.setAppVars("PVQvAThreshold", "String", strValue)
        End If
        Me.txtThreshold.Text = strValue

    End Sub

    Private Function ValidateData() As Boolean
        'If Me.TxtBatchDescription.Text.Trim = "" Then
        '    Me.LblMSG.Text = "Please enter a batch description."
        '    Me.TxtBatchDescription.Focus()
        '    Return False
        'End If

        Return True
    End Function

    Private Function BuildCodeStrings(ByVal LoadLevel As String, ByRef StrSelectionsBase As String, ByRef StrClients As String, ByRef StrDivisions As String, ByRef StrProducts As String, ByRef StrCampaigns As String, ByRef StrAEs As String) As Boolean
        'Build code strings:
        '===================================================================================
        'AE's
        For i As Integer = 0 To Me.LbAEs.Items.Count - 1
            If Me.LbAEs.Items(i).Selected = True Then
                StrAEs &= "'" & Me.LbAEs.Items(i).Value & "',"
            End If
        Next
        StrAEs = MiscFN.RemoveDuplicatesFromString(StrAEs, ",")
        StrAEs = MiscFN.RemoveTrailingDelimiter(StrAEs, ",")

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

        If ar(0).ToString() = "" And Me.RblSelectionLevel.SelectedValue <> "CDPC" Then
            ShowError("Please select at least one item from list")
            Me.LbCDPCSelections.Focus()
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
    End Function


    Private Sub LbAEs_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LbAEs.SelectedIndexChanged
        LoadCDPCListBox()
    End Sub

    Private Sub LBOffice_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBOffice.SelectedIndexChanged
        LoadCDPCListBox()
    End Sub

#End Region

    Public Sub ShowError(ByVal strMessage As String, Optional ByVal MsgIcon As MsgBoxIcon = MsgBoxIcon.SystemError)
        Dim strScript As String
        strScript = "<script type=""text/javascript"">alert ('" & strMessage & "');</script>"
        If Not Page.IsStartupScriptRegistered("JSAlert") Then
            Page.RegisterStartupScript("JSAlert", strScript)
        End If
    End Sub

    Private Sub BtnBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnBack.Click
        Me.GoBack()
    End Sub

    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try
            Me.SaveFilter()
        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString()
            Exit Sub
        End Try
        'Me.GoBack()
    End Sub

    Private Sub GoBack()
        Session("currentPVView") = 0
        'Dim CurrTab As Integer = -1
        'Try
        '    If IsNumeric(Request.QueryString("tab")) = True Then
        '        CurrTab = CType(Request.QueryString("tab"), Integer)
        '    End If
        'Catch ex As Exception
        '    CurrTab = -1
        'End Try
        'Dim suffix As String = ""
        'If CurrTab > -1 Then
        '    suffix = "?tab=" & CurrTab.ToString()
        'End If
        'MiscFN.ResponseRedirect("Default.aspx" & suffix)
        Me.CloseThisWindow()
    End Sub

End Class