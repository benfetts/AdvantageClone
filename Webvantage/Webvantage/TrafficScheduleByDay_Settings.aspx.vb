Imports Webvantage.cGlobals
Public Class TrafficScheduleByDay_Settings
	Inherits Webvantage.BaseChildPage


	Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'Me.PageTitle.InnerText = System.Configuration.ConfigurationManager.AppSettings("AppTitle")
		'header.SubMenu = SubMenu.Production
		Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_TrafficByDayRTP)
        Dim oReports As New cReports(Session("ConnString"))


        If Page.IsPostBack = False Then
            LoadCDPs()
            LoadDropDowns()
            LoadOfficeList()
            LoadAEListbox()
            'If Not Request.Cookies("rpttrafficschedulebyday") Is Nothing Then
            LoadSettings()
            'End If
            Dim str As String = oReports.GetManagerLabel(Session("UserCode"))
            If str <> "" Or Not str Is Nothing Then
                Me.lblManager.Text = str & ":"
            End If
        End If

        If Me.IsClientPortal = True Then
			Me.rblOffices.Visible = False
			Me.lbOffices.Visible = False
			Me.rdlClients.Visible = False
			Me.lstClients.Visible = False
			Me.rdlAE.Visible = False
			Me.lstAEs.Visible = False
			Me.PanelOptions.Visible = False
		End If
	End Sub
	Private Sub LoadOfficeList()
		Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
		Me.lbOffices.DataSource = oDropDowns.GetOfficesEmp(Session("UserCode"))
		Me.lbOffices.DataTextField = "Description"
		Me.lbOffices.DataValueField = "Code"
		Me.lbOffices.DataBind()
        Me.lbOffices.SelectionMode = ListSelectionMode.Multiple
        Me.lbOffices.Enabled = rblOffices.Items(1).Selected
        'Me.lbOffice.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Offices", "%"))

    End Sub

    Private Sub LoadDivisions()



    End Sub

    Private Sub LoadProducts()



    End Sub

    Private Sub LoadAEListbox()
		Dim ocPV As cProjectViewpoint = New cProjectViewpoint(CStr(Session("ConnString")))

		Me.lstAEs.ClearSelection()
		With Me.lstAEs
			.DataSource = ocPV.GetAEList("", "", "", CStr(Session("UserCode")))
			.DataTextField = "description"
			.DataValueField = "code"
			.DataBind()
			.Enabled = False
		End With
	End Sub

    Private Sub LoadDropDowns()
		Dim dsTasks As DataSet

		Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        'Populate Client List Box
        'Me.lstClients.DataSource = odd.GetClientList(CStr(Session("UserCode")))
        'Me.lstClients.DataTextField = "description"
        'Me.lstClients.DataValueField = "code"
        'Me.lstClients.DataBind()
        'Me.lstClients.SelectionMode = ListSelectionMode.Multiple

        With Me.ddManager
			.DataSource = odd.GetManagers(Session("UserCode"))
			.DataValueField = "Code"
			.DataTextField = "Description"
			.DataBind()
			.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[All]", "All"))
		End With

		'Get Task DataSet
		dsTasks = odd.GetTaskDescriptions

		Dim dsRow As DataRow
		dsRow = dsTasks.Tables(0).NewRow
		dsRow.Item(0) = ""
		dsRow.Item(1) = "None"
		dsTasks.Tables(0).Rows.InsertAt(dsRow, 0)



	End Sub
	Private Sub SaveSettings()
		Try
			Dim ThisString As String
			Dim I As Integer

			Dim oAppVars As New cAppVars(cAppVars.Application.SCHED_BY_DAY_RPT, Session("UserCode"))

			oAppVars.getAllAppVars()
			With oAppVars
				'Report Options
				.setAppVar("closedjobs", Me.chkClosedJobs.Checked)
				'Report Title
				.setAppVar("ReportTitle", Me.txtReportTitle.Text)
				'Day Column Options
				.setAppVar("ddEmployeeOption", Me.ddEmpoyeeOption.SelectedValue)
				.setAppVar("ddTaskOption", Me.ddTaskOption.SelectedValue)
				.setAppVar("ddColSort", Me.ddColSort.SelectedValue)
				.setAppVar("ddSort1", Me.ddSort1.SelectedValue)
				.setAppVar("ddSort2", Me.ddSort2.SelectedValue)
				.setAppVar("ddSort1Direction", Me.ddSort1Direction.SelectedValue)
				.setAppVar("ddSort2Direction", Me.ddSort2Direction.SelectedValue)
				.setAppVar("ddManager", Me.ddManager.SelectedValue)

				If MiscFN.ValidDate(Me.RadDatePickerStartingDate) = True Then
					.setAppVar("txtStartingDate", Me.RadDatePickerStartingDate.SelectedDate)
				Else
					.setAppVar("txtStartingDate", "")
				End If

				.setAppVar("ddDays", Me.ddDays.SelectedValue)
				.setAppVar("chkWeekends", Me.chkWeekends.Checked)

				.setAppVar("chkManager", Me.chkManager.Checked)
				.setAppVar("chkProjectDate", Me.chkProjectDate.Checked)
				.setAppVar("chkClientDesc", Me.chkClientDesc.Checked)
				.setAppVar("chkClientCode", Me.chkClientCode.Checked)
				.setAppVar("chkDivisionDesc", Me.chkDivisionDesc.Checked)
				.setAppVar("chkDivisionCode", Me.chkDivisionCode.Checked)
				.setAppVar("chkProductCode", Me.chkProductCode.Checked)
				.setAppVar("chkProductDesc", Me.chkProductDesc.Checked)
				.setAppVar("chkJobCompNum", Me.chkJobCompNum.Checked)
				.setAppVar("chkJobCompDesc", Me.chkJobCompDesc.Checked)
				.setAppVar("chkClientReference", Me.chkClientReference.Checked)
				.setAppVar("chkAccountExecutive", Me.chkAccountExecutive.Checked)
				.setAppVar("chkJobType", Me.chkJobType.Checked)
				.setAppVar("chkJobTypeDesc", Me.chkJobTypeDesc.Checked)
				.setAppVar("chkTrafficStatus", Me.chkTrafficStatus.Checked)
				.setAppVar("chkComments", Me.chkComments.Checked)
				.setAppVar("CheckBoxPhase", Me.CheckBoxPhase.Checked)
				.setAppVar("Completed", Me.chkCompleted.Checked)
				.SaveAllAppVars()
			End With

		Catch ex As Exception

		End Try
	End Sub
	Private Sub LoadSettings()
		Try
			Dim ThisString As String
			Dim Clients() As String
			Dim I As Integer
			Dim oAppVars As New cAppVars(cAppVars.Application.SCHED_BY_DAY_RPT, Session("UserCode"))
			oAppVars.getAllAppVars()
			Dim s As String = ""
			s = oAppVars.getAppVar("txtStartingDate")
			If s <> "" Then
				Me.RadDatePickerStartingDate.SelectedDate = CType(s, Date)
			End If
			s = oAppVars.getAppVar("closedjobs")
			If s <> "" Then
				Me.chkClosedJobs.Checked = s
			End If
			s = oAppVars.getAppVar("Completed")
			If s <> "" Then
				Me.chkCompleted.Checked = s
			End If
			s = oAppVars.getAppVar("ReportTitle")
			If s <> "" Then
				Me.txtReportTitle.Text = s
			Else
				Me.txtReportTitle.Text = "Schedule by Days"
			End If
			s = oAppVars.getAppVar("ddEmployeeOption")
			If s <> "" Then
				Me.ddEmpoyeeOption.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddTaskOption")
			If s <> "" Then
				Me.ddTaskOption.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddColSort")
			If s <> "" Then
				Me.ddColSort.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddSort1")
			If s <> "" Then
				Me.ddSort1.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddSort2")
			If s <> "" Then
				Me.ddSort2.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddSort1Direction")
			If s <> "" Then
				Me.ddSort1Direction.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddSort2Direction")
			If s <> "" Then
				Me.ddSort2Direction.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddManager")
			If s <> "" Then
				Me.ddManager.SelectedValue = s
			End If
			s = oAppVars.getAppVar("ddDays")
			If s <> "" Then
				Me.ddDays.SelectedValue = s
			End If
			s = oAppVars.getAppVar("chkWeekends")
			If s <> "" Then
				Me.chkWeekends.Checked = s
			End If
			s = oAppVars.getAppVar("chkManager")
			If s <> "" Then
				Me.chkManager.Checked = s
			End If
			s = oAppVars.getAppVar("chkProjectDate")
			If s <> "" Then
				Me.chkProjectDate.Checked = s
			End If
			s = oAppVars.getAppVar("chkClientDesc")
			If s <> "" Then
				Me.chkClientDesc.Checked = s
			End If
			s = oAppVars.getAppVar("chkClientCode")
			If s <> "" Then
				Me.chkClientCode.Checked = s
			End If
			s = oAppVars.getAppVar("chkDivisionDesc")
			If s <> "" Then
				Me.chkDivisionDesc.Checked = s
			End If
			s = oAppVars.getAppVar("chkDivisionCode")
			If s <> "" Then
				Me.chkDivisionCode.Checked = s
			End If
			s = oAppVars.getAppVar("chkProductCode")
			If s <> "" Then
				Me.chkProductCode.Checked = s
			End If
			s = oAppVars.getAppVar("chkProductDesc")
			If s <> "" Then
				Me.chkProductDesc.Checked = s
			End If
			s = oAppVars.getAppVar("chkJobCompNum")
			If s <> "" Then
				Me.chkJobCompNum.Checked = s
			End If
			s = oAppVars.getAppVar("chkJobCompDesc")
			If s <> "" Then
				Me.chkJobCompDesc.Checked = s
			End If
			s = oAppVars.getAppVar("chkClientReference")
			If s <> "" Then
				Me.chkClientReference.Checked = s
			End If
			s = oAppVars.getAppVar("chkAccountExecutive")
			If s <> "" Then
				Me.chkAccountExecutive.Checked = s
			End If
			s = oAppVars.getAppVar("chkJobType")
			If s <> "" Then
				Me.chkJobType.Checked = s
			End If
			s = oAppVars.getAppVar("chkJobTypeDesc")
			If s <> "" Then
				Me.chkJobTypeDesc.Checked = s
			End If
			s = oAppVars.getAppVar("chkTrafficStatus")
			If s <> "" Then
				Me.chkTrafficStatus.Checked = s
			End If
			s = oAppVars.getAppVar("chkComments")
			If s <> "" Then
				Me.chkComments.Checked = s
			End If
			s = oAppVars.getAppVar("CheckBoxPhase")
			If s <> "" Then
				Me.CheckBoxPhase.Checked = s
			End If


		Catch
		End Try

	End Sub
	Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
		Try
			Dim strURL As String
			Dim I As Integer
            Dim Tasked As Boolean = False
            Dim SelectedCDPs As Generic.List(Of String) = New Generic.List(Of String)

            Me.lblMessage.Text = ""

			If Not Me.RadDatePickerStartingDate.SelectedDate Is Nothing Then
				If MiscFN.ValidDate(Me.RadDatePickerStartingDate) = False Then
					Me.lblMessage.Text = "Starting Date is not valid"
					Exit Sub
				End If
			Else
				Me.lblMessage.Text = "Must have a Starting Date"
				Exit Sub
			End If

			Dim dtStart As DateTime = Convert.ToDateTime(LoGlo.FormatDate("3/31/1974 12:00:00 AM"))
			Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDate("6/6/2079 11:59:59 PM"))
			If wvCDate(Me.RadDatePickerStartingDate.SelectedDate) < dtStart Or wvCDate(Me.RadDatePickerStartingDate.SelectedDate) > dtEnd Then
				Me.lblMessage.Text = "Date is invalid"
				Exit Sub
			End If
			'If Me.RadDatePickerStartingDate.SelectedDate = "12:00:00 AM" Then
			'    Me.lblMessage.Text = "Must have a Starting Date"
			'    Exit Sub
			'End If

			strURL = "TrafficScheduleByDay_Render.aspx"
			strURL &= "?clients="

			Dim clients As String
			Dim offices As String
			Dim AECode As String

			If Me.IsClientPortal = True Then
				strURL &= Session("CL_CODE")
			Else
                If rdlClients.Items(1).Selected = True Then
                    For Each RadListBoxItem In lstClients.SelectedItems

                        SelectedCDPs.Add(RadListBoxItem.Value)

                    Next
                    'For I = 0 To Me.lstClients.Items.Count - 1
                    '    If Me.lstClients.Items(I).Selected = True Then
                    '        strURL &= Me.lstClients.Items(I).Value & ","
                    '        clients &= Me.lstClients.Items(I).Value & ","
                    '    End If
                    'Next I
                    strURL &= String.Join(",", SelectedCDPs)
                    clients = String.Join(",", SelectedCDPs)
                End If
            End If

			strURL &= "&Offices="
			If Me.rblOffices.Items(1).Selected = True Then
				For I = 0 To Me.lbOffices.Items.Count - 1
					If Me.lbOffices.Items(I).Selected = True Then
						strURL &= Me.lbOffices.Items(I).Value & ","
						offices &= Me.lbOffices.Items(I).Value & ","
					End If
				Next I
				strURL = strURL.Substring(0, strURL.Length - 1)
				offices = offices.Substring(0, offices.Length - 1)
			End If

			strURL &= "&AECodes="
			If Me.rdlAE.Items(1).Selected = True Then
				For I = 0 To Me.lstAEs.Items.Count - 1
					If Me.lstAEs.Items(I).Selected = True Then
						strURL &= Me.lstAEs.Items(I).Value & ","
						AECode &= Me.lstAEs.Items(I).Value & ","
					End If
				Next I
				strURL = strURL.Substring(0, strURL.Length - 1)
				AECode = AECode.Substring(0, AECode.Length - 1)
			Else
				strURL &= "%"
			End If

			strURL &= "&taskdesc="

			strURL &= "&" & Me.chkManager.ID & "=" & CInt(Me.chkManager.Checked).ToString
			strURL &= "&" & Me.chkProjectDate.ID & "=" & CInt(Me.chkProjectDate.Checked).ToString
			strURL &= "&" & Me.chkClientCode.ID & "=" & CInt(Me.chkClientCode.Checked).ToString
			strURL &= "&" & Me.chkClientDesc.ID & "=" & CInt(Me.chkClientDesc.Checked).ToString
			strURL &= "&" & Me.chkDivisionCode.ID & "=" & CInt(Me.chkDivisionCode.Checked).ToString
			strURL &= "&" & Me.chkDivisionDesc.ID & "=" & CInt(Me.chkDivisionDesc.Checked).ToString
			strURL &= "&" & Me.chkProductCode.ID & "=" & CInt(Me.chkProductCode.Checked).ToString
			strURL &= "&" & Me.chkProductDesc.ID & "=" & CInt(Me.chkProductDesc.Checked).ToString
			strURL &= "&" & Me.chkJobCompNum.ID & "=" & CInt(Me.chkJobCompNum.Checked).ToString
			strURL &= "&" & Me.chkJobCompDesc.ID & "=" & CInt(Me.chkJobCompDesc.Checked).ToString
			strURL &= "&" & Me.chkClientReference.ID & "=" & CInt(Me.chkClientReference.Checked).ToString
			strURL &= "&" & Me.chkAccountExecutive.ID & "=" & CInt(Me.chkAccountExecutive.Checked).ToString
			strURL &= "&" & Me.chkJobType.ID & "=" & CInt(Me.chkJobType.Checked).ToString
			strURL &= "&" & Me.chkJobTypeDesc.ID & "=" & CInt(Me.chkJobTypeDesc.Checked).ToString
			strURL &= "&" & Me.chkTrafficStatus.ID & "=" & CInt(Me.chkTrafficStatus.Checked).ToString
			strURL &= "&" & Me.chkComments.ID & "=" & CInt(Me.chkComments.Checked).ToString
			strURL &= "&" & Me.CheckBoxPhase.ID & "=" & CInt(Me.CheckBoxPhase.Checked).ToString

			Session("TrafficByDayReportTitle") = Me.txtReportTitle.Text
			'strURL &= "&" & "txtReportTitle=" & Me.txtReportTitle.Text

			strURL &= "&closed=" & CInt(Me.chkClosedJobs.Checked).ToString

			strURL &= "&colsort=" & Me.ddColSort.SelectedValue
			strURL &= "&sort1=" & Me.ddSort1.SelectedValue & " " & Me.ddSort1Direction.SelectedValue
			strURL &= "&sort2=" & Me.ddSort2.SelectedValue & " " & Me.ddSort2Direction.SelectedValue
			If Me.ddEmpoyeeOption.SelectedValue = 1 Then
				strURL &= "&empoption=" & "False"
			Else
				strURL &= "&empoption=" & "True"
			End If
			strURL &= "&taskoption=" & Me.ddTaskOption.SelectedValue

			If MiscFN.ValidDate(Me.RadDatePickerStartingDate, True) = True Then
				If Not Me.RadDatePickerStartingDate.SelectedDate Is Nothing Then
					strURL &= "&startdate=" & wvCDate(Me.RadDatePickerStartingDate.SelectedDate)
				Else
					strURL &= "&startdate="
				End If
			End If

			strURL &= "&days=" & Me.ddDays.SelectedValue
			strURL &= "&weekends=" & Me.chkWeekends.Checked
			strURL &= "&ddManager=" & Me.ddManager.SelectedValue

			If Me.chkCompleted.Checked = True Then
				strURL &= "&chkCompleted=1"
			Else
				strURL &= "&chkCompleted=0"
			End If

			If Me.chkSaveSettings.Checked = True Then
				SaveSettings()
			End If

			Dim oReport As cReports = New cReports(CStr(Session("ConnString")))
			Dim ds As DataSet

			If IsClientPortal = True Then
				ds = oReport.TrafficScheduleByDayCP(clients, wvCDate(Me.RadDatePickerStartingDate.SelectedDate), CInt(Me.ddDays.SelectedValue), CInt(Me.chkClosedJobs.Checked).ToString, Me.ddColSort.SelectedValue, CBool(Me.chkWeekends.Checked), IIf(Me.ddEmpoyeeOption.SelectedValue = 1, False, True), CInt(Me.ddTaskOption.SelectedValue), offices, Session("UserCode"), Me.ddManager.SelectedValue, IIf(Me.chkCompleted.Checked = True, 1, 0), AECode, Session("UserID"))
			Else
				ds = oReport.TrafficScheduleByDay(clients, wvCDate(Me.RadDatePickerStartingDate.SelectedDate), CInt(Me.ddDays.SelectedValue), CInt(Me.chkClosedJobs.Checked).ToString, Me.ddColSort.SelectedValue, CBool(Me.chkWeekends.Checked), IIf(Me.ddEmpoyeeOption.SelectedValue = 1, False, True), CInt(Me.ddTaskOption.SelectedValue), offices, Session("UserCode"), Me.ddManager.SelectedValue, IIf(Me.chkCompleted.Checked = True, 1, 0), AECode, Session("UserID"))
			End If

			If ds.Tables(0).Rows.Count = 0 Then
				Me.lblMessage.Text = "No data to display."
				Exit Sub
			End If

			'make open new browser
			'Dim strBuilder As System.Text.StringBuilder = New System.Text.StringBuilder
			'strBuilder.Append("<script language='javascript'>")
			'strBuilder.Append("window.open('" & strURL & "', '', 'scrollbars=yes,resizable=yes,menubar=no,maximazable=yes')")
			'strBuilder.Append("</")
			'strBuilder.Append("script>")
			'RegisterStartupScript("newpage", strBuilder.ToString())
			Response.Redirect(strURL.ToString())

		Catch ex As Exception
			Me.ShowMessage(ex.Message.ToString())
		End Try
	End Sub

    'Private Sub lstClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstClients.SelectedIndexChanged
    '	Dim i As Integer
    '	Dim j As Integer
    '	For i = 0 To lstClients.Items.Count - 1
    '		If lstClients.Items(i).Selected = True Then
    '			rdlClients.Items(1).Selected = True
    '			Exit For
    '		Else
    '			rdlClients.Items(0).Selected = True
    '			rdlClients.Items(1).Selected = False
    '		End If
    '	Next

    'End Sub

    Private Sub lbOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbOffices.SelectedIndexChanged
		Dim i As Integer
		Dim j As Integer
		For i = 0 To lbOffices.Items.Count - 1
			If lbOffices.Items(i).Selected = True Then
				rblOffices.Items(1).Selected = True
				Exit For
			Else
				rblOffices.Items(0).Selected = True
				rblOffices.Items(1).Selected = False
			End If
		Next
	End Sub

	Private Sub rdlAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlAE.SelectedIndexChanged
		Dim i As Integer

		If Me.rdlAE.Items(0).Selected = True Then
			For i = 0 To Me.lstAEs.Items.Count - 1
				If Me.lstAEs.Items(i).Selected = True Then
					Me.lstAEs.Items(i).Selected = False
				End If
			Next
			Me.lstAEs.Enabled = False
		Else
			Me.lstAEs.Enabled = True
		End If
	End Sub

    Private Sub LoadCDPs()

        Try
            rdlClients.Items(0).Text = "All " & RadioButtonListSelectBy.SelectedValue & "s"
            rdlClients.Items(1).Text = "Choose " & RadioButtonListSelectBy.SelectedValue & "s"

            lstClients.Enabled = rdlClients.Items(1).Selected

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Select Case RadioButtonListSelectBy.SelectedValue

                        Case "Client"

                            lstClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                     Select [Code] = Item.Code,
                                                                [Description] = Item.Name).ToList

                        Case "Division"

                            lstClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Division.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                     Let [Div] = Item.Code & " - " & Item.Name
                                                     Select [Code] = Item.ClientCode & "|" & Item.Code,
                                                            [Description] = [Div] & " | " & Item.ClientCode).ToList

                        Case "Product"

                            lstClients.DataSource = (From Item In AdvantageFramework.Database.Procedures.Product.LoadAllActiveByUserCodeWithOfficeLimits(_Session, DbContext, SecurityDbContext)
                                                     Let [Prd] = Item.Code & " - " & Item.Name
                                                     Select [Code] = Item.ClientCode & "|" & Item.DivisionCode & "|" & Item.Code,
                                                            [Description] = Prd & " | " & Item.ClientCode & " - " & Item.DivisionCode).ToList

                    End Select

                End Using

            End Using

            lstClients.DataBind()

        Catch ex As Exception

        End Try

    End Sub

    Protected Sub RadioButtonListSelectBy_SelectedIndexChanged(sender As Object, e As EventArgs)

        LoadCDPs()

    End Sub
    Private Sub rblOffices_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblOffices.SelectedIndexChanged
        Dim i As Integer
        If Me.rblOffices.Items(0).Selected = True Then
            For i = 0 To Me.lbOffices.Items.Count - 1
                If Me.lbOffices.Items(i).Selected = True Then
                    Me.lbOffices.Items(i).Selected = False
                End If
            Next
            lbOffices.Enabled = False
        Else
            lbOffices.Enabled = True
        End If
    End Sub
    Private Sub rdlClients_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rdlClients.SelectedIndexChanged
        Dim i As Integer
        If Me.rdlClients.Items(0).Selected = True Then
            For i = 0 To Me.lstClients.Items.Count - 1
                If Me.lstClients.Items(i).Selected = True Then
                    Me.lstClients.Items(i).Selected = False
                End If
            Next
            lstClients.Enabled = False
        Else
            lstClients.Enabled = True
        End If
    End Sub

End Class