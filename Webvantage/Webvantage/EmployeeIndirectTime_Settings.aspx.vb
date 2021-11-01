Imports Webvantage.cGlobals.Globals

Partial Public Class EmployeeIndirectTime_Settings
    Inherits Webvantage.BaseChildPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_Reports_IndrectTimeRTP)

        If Me.IsPostBack = True Then

        Else
            Me.RadDatePickerStartDate.SelectedDate = LoGlo.FormatDate(Date.Today.ToShortDateString)
            Me.RadDatePickerEndDate.SelectedDate = LoGlo.FormatDate(Date.Today.ToShortDateString)
            loadlists()

            If Not Request.Cookies("EmpNP") Is Nothing Then
                LoadSettings()

            Else
                'Create the cookie and set listbox defaults
                Response.Cookies("EmpNP").Expires = DateTime.Now.AddYears(1)

                Me.lboffice.SelectedIndex = 0
                Me.lbsupervisors.SelectedIndex = 0
                Me.lbemployees.SelectedIndex = 0
                Me.lbdepartments.SelectedIndex = 0

            End If

        End If
    End Sub

    Private Sub loadlists()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))

        'Load Office listbox
        Me.lboffice.DataSource = oDropDowns.GetOfficesEmp(Session("UserCode"))
        Me.lboffice.DataTextField = "Description"
        Me.lboffice.DataValueField = "Code"
        Me.lboffice.DataBind()
        Me.lboffice.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Offices", ""))

        'Load Supervisor listbox
        Me.lbsupervisors.DataSource = oDropDowns.GetSupervisors(Session("UserCode"))
        Me.lbsupervisors.DataTextField = "Description"
        Me.lbsupervisors.DataValueField = "Code"
        Me.lbsupervisors.DataBind()
        Me.lbsupervisors.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Supervisors", ""))

        'Load Employee listbox
        Me.lbemployees.DataSource = oDropDowns.GetEmployees(Session("UserCode"))
        Me.lbemployees.DataTextField = "Description"
        Me.lbemployees.DataValueField = "Code"
        Me.lbemployees.DataBind()
        Me.lbemployees.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Employees", ""))

        'Load Dept listbox
        Me.lbdepartments.DataSource = oDropDowns.ddDepts()
        Me.lbdepartments.DataTextField = "Description"
        Me.lbdepartments.DataValueField = "Code"
        Me.lbdepartments.DataBind()
        Me.lbdepartments.Items.Insert(0, New Telerik.Web.UI.RadListBoxItem("All Departments", ""))

    End Sub

    Private Sub SaveSettings()
        '*****************************************************************
        'NOT REALLY USED, DO ALL THIS IN butView_Click EVENT
        '*****************************************************************
        'Report Options
        Response.Cookies("EmpNP").Values.Clear()
        Response.Cookies("EmpNP").Expires = Now.AddYears(1)

        Dim list As ListItem
        Dim list_ct, lb_idx As Int16
        Dim idx_str As String
        Dim cookie_desc, test, cookie_str As String

        'Gather Office Selections
        cookie_str = ""
        list_ct = 0
        lb_idx = 0
        For Each list In lboffice.Items
            If list.Selected = True Then
                If list_ct > 0 Then
                    cookie_str = cookie_str & "," & list.Value
                    idx_str = idx_str & "," & lb_idx.ToString

                Else
                    If list.Text = "All Offices" Then
                        cookie_str = "%"
                        idx_str = "0"
                        Exit For
                    Else
                        cookie_str = list.Value
                        idx_str = lb_idx.ToString
                    End If
                End If
                list_ct = list_ct + 1
            End If
            lb_idx = lb_idx + 1
        Next
        'test = list.Value   'actual code
        'test = list.Text    'display value (code - desc)
        Response.Cookies("EmpNP")("Office") = cookie_str
        Response.Cookies("EmpNP")("Office_idx") = idx_str


        'Gather Supervisor Selections
        cookie_str = ""
        list_ct = 0
        lb_idx = 0
        For Each list In lbsupervisors.Items
            If list.Selected = True Then
                If list_ct > 0 Then
                    cookie_str = cookie_str & "," & list.Value
                    idx_str = idx_str & "," & lb_idx.ToString
                Else
                    If list.Text = "All Supervisors" Then
                        cookie_str = "%"
                        idx_str = "0"
                        Exit For
                    Else
                        cookie_str = list.Value
                        idx_str = lb_idx.ToString
                    End If
                End If
                list_ct = list_ct + 1
            End If
            lb_idx = lb_idx + 1
        Next
        Response.Cookies("EmpNP")("super") = cookie_str
        Response.Cookies("EmpNP")("super_idx") = idx_str

        'Gather Employee Selections
        cookie_str = ""
        list_ct = 0
        lb_idx = 0
        For Each list In lbemployees.Items
            If list.Selected = True Then
                If list_ct > 0 Then
                    cookie_str = cookie_str & "," & list.Value
                    idx_str = idx_str & "," & lb_idx.ToString
                Else
                    If list.Text = "All Employees" Then
                        cookie_str = "%"
                        idx_str = "0"
                        Exit For
                    Else
                        cookie_str = list.Value
                        idx_str = lb_idx.ToString
                    End If
                End If
                list_ct = list_ct + 1
            End If
            lb_idx = lb_idx + 1
        Next
        Response.Cookies("EmpNP")("emp") = cookie_str
        Response.Cookies("EmpNP")("emp_idx") = idx_str

        'Gather Department Selections
        cookie_str = ""
        list_ct = 0
        lb_idx = 0
        For Each list In lbdepartments.Items
            If list.Selected = True Then
                If list_ct > 0 Then
                    cookie_str = cookie_str & "," & list.Value
                    idx_str = idx_str & "," & lb_idx.ToString
                Else
                    If list.Text = "All Departments" Then
                        cookie_str = "%"
                        idx_str = "0"
                        Exit For
                    Else
                        cookie_str = list.Value
                        idx_str = lb_idx.ToString
                    End If
                End If
                list_ct = list_ct + 1
            End If
            lb_idx = lb_idx + 1
        Next
        Response.Cookies("EmpNP")("dept") = cookie_str
        Response.Cookies("EmpNP")("dept_idx") = idx_str

        'Dates
        Response.Cookies("EmpNP")("StartDate") = wvCDate(Me.RadDatePickerStartDate.SelectedDate)
        Response.Cookies("EmpNP")("EndDate") = wvCDate(Me.RadDatePickerEndDate.SelectedDate)


        'Sort Options
        If Me.rbOE.Checked Then
            Response.Cookies("EmpNP")("sort") = "1"
        ElseIf Me.rbOELFM.Checked Then
            Response.Cookies("EmpNP")("sort") = "2"
        ElseIf Me.rbLFM.Checked Then
            Response.Cookies("EmpNP")("sort") = "3"
        ElseIf Me.rbempcode.Checked Then
            Response.Cookies("EmpNP")("sort") = "4"
        Else
            Response.Cookies("EmpNP")("sort") = "1"
        End If

        'Include terminated employees?
        Response.Cookies("EmpNP")("inclTermEmp") = Me.chkTerminated.Checked
        Response.Cookies("EmpNP")("bytype") = Me.CheckBoxByType.Checked
        Response.Cookies("EmpNP")("ExclFreelance") = Me.CheckBoxFreelance.Checked

    End Sub

    Private Sub butView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles butView.Click
        Dim strURL As String
        Dim office, super, emp, dept, sort, termemps As String
        Dim list As Telerik.Web.UI.RadListBoxItem
        Dim list_ct, lb_idx, bytype As Int16
        Dim idx_str As String
        Dim cookie_desc, test, cookie_str As String
        Dim excludefree As Integer = 0

        If Me.chkSaveSettings.Checked = True Then
            Response.Cookies("EmpNP").Values.Clear()
            Response.Cookies("EmpNP").Expires = Now.AddYears(1)
        End If

        'Validate & Gather Dates
        Dim dtStart As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("1/1/1950 12:00:00 AM"))
        Dim dtEnd As DateTime = Convert.ToDateTime(LoGlo.FormatDateTime("12/31/2050 11:59:59 PM"))
        Try
            If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                Me.ShowMessage("Invalid Start date")
                Exit Sub
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                Me.ShowMessage("Invalid End date")
                Exit Sub
            End If



            If MiscFN.ValidDate(Me.RadDatePickerStartDate, True) = False Then
                Me.ShowMessage("Invalid Start date")
                Exit Sub
            Else
                If Not Me.RadDatePickerStartDate.SelectedDate Is Nothing Then
                    dtStart = Me.RadDatePickerStartDate.SelectedDate
                End If
            End If
            If MiscFN.ValidDate(Me.RadDatePickerEndDate, True) = False Then
                Me.ShowMessage("Invalid End date")
                Exit Sub
            Else
                If Not Me.RadDatePickerEndDate.SelectedDate Is Nothing Then
                    dtEnd = Me.RadDatePickerEndDate.SelectedDate
                End If
            End If

            If MiscFN.ValidDate(Me.RadDatePickerStartDate) = True And MiscFN.ValidDate(Me.RadDatePickerEndDate) = True Then
                If MiscFN.ValidDateRange(Me.RadDatePickerStartDate, Me.RadDatePickerEndDate) = False Then
                    Me.lblError.Text = "End Date must be greater than Start Date"
                    Exit Sub
                End If
            End If

            'Save to cookie
            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("StartDate") = dtStart.ToShortDateString()
                Response.Cookies("EmpNP")("EndDate") = dtEnd.ToShortDateString()
            End If


        Catch ex As Exception
            Me.ShowMessage("Error validating date: " & ex.Message.ToString())

        End Try


        Try 'Gather all other selected settings

            'Include terminated employees
            If Me.chkTerminated.Checked = True Then
                termemps = "1"
            Else
                termemps = "0"
            End If
            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("inclTermEmp") = termemps
            End If

            If Me.CheckBoxFreelance.Checked = True Then
                excludefree = 1
            Else
                excludefree = 0
            End If
            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("ExclFreelance") = excludefree
            End If

            'Sort Order
            If Me.rbOE.Checked Then
                sort = "1"
            ElseIf Me.rbOELFM.Checked Then
                sort = "2"
            ElseIf Me.rbLFM.Checked Then
                sort = "3"
            ElseIf Me.rbempcode.Checked Then
                sort = "4"
            Else
                sort = "1"
            End If
            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("sort") = sort
            End If

            'Group'
            If Me.CheckBoxByType.Checked = True Then
                bytype = 1
            Else
                bytype = 0
            End If
            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("bytype") = bytype
            End If

            'Gather Office Selections
            cookie_str = ""
            list_ct = 0
            lb_idx = 0
            For Each list In lboffice.Items
                If list.Selected = True Then
                    If list_ct > 0 Then
                        cookie_str = cookie_str & "," & list.Value
                        idx_str = idx_str & "," & lb_idx.ToString

                    Else
                        If list.Text = "All Offices" Then
                            cookie_str = "%"
                            idx_str = "0"
                            Exit For
                        Else
                            cookie_str = list.Value
                            idx_str = lb_idx.ToString
                        End If
                    End If
                    list_ct = list_ct + 1
                End If
                lb_idx = lb_idx + 1
            Next

            office = cookie_str

            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("Office") = cookie_str
                Response.Cookies("EmpNP")("Office_idx") = idx_str
            End If


            'Gather Supervisor Selections
            cookie_str = ""
            list_ct = 0
            lb_idx = 0
            For Each list In lbsupervisors.Items
                If list.Selected = True Then
                    If list_ct > 0 Then
                        cookie_str = cookie_str & "," & list.Value
                        idx_str = idx_str & "," & lb_idx.ToString
                    Else
                        If list.Text = "All Supervisors" Then
                            cookie_str = "%"
                            idx_str = "0"
                            Exit For
                        Else
                            cookie_str = list.Value
                            idx_str = lb_idx.ToString
                        End If
                    End If
                    list_ct = list_ct + 1
                End If
                lb_idx = lb_idx + 1
            Next

            super = cookie_str

            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("super") = cookie_str
                Response.Cookies("EmpNP")("super_idx") = idx_str
            End If


            'Gather Employee Selections
            cookie_str = ""
            list_ct = 0
            lb_idx = 0
            For Each list In lbemployees.Items
                If list.Selected = True Then
                    If list_ct > 0 Then
                        cookie_str = cookie_str & "," & list.Value
                        idx_str = idx_str & "," & lb_idx.ToString
                    Else
                        If list.Text = "All Employees" Then
                            cookie_str = "%"
                            idx_str = "0"
                            Exit For
                        Else
                            cookie_str = list.Value
                            idx_str = lb_idx.ToString
                        End If
                    End If
                    list_ct = list_ct + 1
                End If
                lb_idx = lb_idx + 1
            Next

            emp = cookie_str

            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("emp") = cookie_str
                Response.Cookies("EmpNP")("emp_idx") = idx_str
            End If


            'Gather Department Selections
            cookie_str = ""
            list_ct = 0
            lb_idx = 0
            For Each list In lbdepartments.Items
                If list.Selected = True Then
                    If list_ct > 0 Then
                        cookie_str = cookie_str & "," & list.Value
                        idx_str = idx_str & "," & lb_idx.ToString
                    Else
                        If list.Text = "All Departments" Then
                            cookie_str = "%"
                            idx_str = "0"
                            Exit For
                        Else
                            cookie_str = list.Value
                            idx_str = lb_idx.ToString
                        End If
                    End If
                    list_ct = list_ct + 1
                End If
                lb_idx = lb_idx + 1
            Next

            dept = cookie_str

            If Me.chkSaveSettings.Checked = True Then
                Response.Cookies("EmpNP")("dept") = cookie_str
                Response.Cookies("EmpNP")("dept_idx") = idx_str
            End If


            ' Put settings into URL
            strURL = "popReportViewer.aspx?Report=EmpNPTime"
            strURL &= "&SortOrder=" & sort
            strURL &= "&Office=" & office
            strURL &= "&super=" & super
            strURL &= "&emp=" & emp
            strURL &= "&dept=" & dept
            strURL &= "&StartDate=" & dtStart.ToShortDateString()
            strURL &= "&EndDate=" & dtEnd.ToShortDateString()
            strURL &= "&UserID=" & Session("UserCode")
            strURL &= "&inclTermEmp=" & termemps
            strURL &= "&bytype=" & bytype
            strURL &= "&excludeFree=" & excludefree

            Dim ddl As Telerik.Web.UI.RadComboBox
            ddl = reporttype.FindControl("RadComboBoxReportType")
            strURL &= "&Type=" & ddl.SelectedValue
            Response.Redirect(strURL)
        Catch ex As Exception
            Me.ShowMessage("Error setting strURL : " & ex.Message.ToString())
        End Try

    End Sub

    Private Sub LoadSettings()

        Try
            If Not Request.Cookies("EmpNP")("inclTermEmp") Is Nothing Then
                Me.chkTerminated.Checked = Request.Cookies("EmpNP")("inclTermEmp")
            Else
                Me.chkTerminated.Checked = False
            End If
        Catch ex As Exception
            Me.chkTerminated.Checked = False
        End Try

        Try
            If Not Request.Cookies("EmpNP")("ExclFreelance") Is Nothing Then
                Me.CheckBoxFreelance.Checked = Request.Cookies("EmpNP")("ExclFreelance")
            Else
                Me.CheckBoxFreelance.Checked = False
            End If
        Catch ex As Exception
            Me.CheckBoxFreelance.Checked = False
        End Try

        'Sort Options
        Try
            Dim sort_opt As String
            If Not Request.Cookies("EmpNP")("sort") Is Nothing Then
                sort_opt = Request.Cookies("EmpNP")("sort")
            End If
            If sort_opt Is Nothing Then
                Me.rbOE.Checked = True
            Else
                Select Case sort_opt
                    Case "1"
                        Me.rbOE.Checked = True
                    Case "2"
                        Me.rbOELFM.Checked = True
                    Case "3"
                        Me.rbLFM.Checked = True
                    Case "4"
                        Me.rbempcode.Checked = True
                    Case Else
                        Me.rbOE.Checked = True
                End Select
            End If
        Catch ex As Exception
            Me.rbOE.Checked = True
        End Try

        'Date Options 
        Try
            If Not Request.Cookies("EmpNP")("StartDate") Is Nothing Then
                Me.RadDatePickerStartDate.SelectedDate = Request.Cookies("EmpNP")("StartDate")
            End If
        Catch ex As Exception
            Me.RadDatePickerStartDate.SelectedDate = Nothing
        End Try

        Try
            If Not Request.Cookies("EmpNP")("EndDate") Is Nothing Then
                Me.RadDatePickerEndDate.SelectedDate = Request.Cookies("EmpNP")("EndDate")
            End If
        Catch ex As Exception
            Me.RadDatePickerEndDate.SelectedDate = Nothing
        End Try


        'Report Options
        Dim list As ListItem
        Dim list_ct As Int16
        Dim cookie_desc, token_str, cookie_str As String
        Dim pos, nextpos, valuelen, lbidx As Int16
        Dim multiples As Boolean

        'Load Office Listbox 
        cookie_str = ""
        Try
            If Not Request.Cookies("EmpNP")("Office") Is Nothing Then
                cookie_str = Request.Cookies("EmpNP")("Office")
            End If
        Catch ex As Exception
            cookie_str = ""
        End Try
        MiscFN.SetListbox(Me.lboffice, cookie_str)

        'Load Supervisor Listbox
        cookie_str = ""
        Try
            If Not Request.Cookies("EmpNP")("super") Is Nothing Then
                cookie_str = Request.Cookies("EmpNP")("super")
            End If
        Catch ex As Exception
            cookie_str = ""
        End Try
        MiscFN.SetListbox(Me.lbsupervisors, cookie_str)

        'Load Employee Listbox
        cookie_str = ""
        Try
            If Not Request.Cookies("EmpNP")("emp") Is Nothing Then
                cookie_str = Request.Cookies("EmpNP")("emp")
            End If
        Catch ex As Exception
            cookie_str = ""
        End Try
        MiscFN.SetListbox(Me.lbemployees, cookie_str)

        'Load Department Listbox
        cookie_str = ""
        Try
            If Not Request.Cookies("EmpNP")("dept") Is Nothing Then
                cookie_str = Request.Cookies("EmpNP")("dept")
            End If
        Catch ex As Exception
            cookie_str = ""
        End Try
        MiscFN.SetListbox(Me.lbdepartments, cookie_str)

    End Sub

End Class