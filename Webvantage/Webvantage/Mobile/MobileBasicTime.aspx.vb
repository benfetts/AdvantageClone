
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Drawing
Imports System.Web.Mobile


Partial Public Class MobileBasicTime
    Inherits MobileBase

    Private CommentsRequired As Boolean = False
    Private DivisionLabel As String = ""
    Private ProductLabel As String = ""
    Private ProductCategoryLabel As String = ""
    Private JobLabel As String = ""
    Private JobComponentLabel As String = ""
    Private FunctionCategoryLabel As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Page.IsPostBack = False Then

            LoadTimePage()
            SetDefaultFunction()

            Dim tm As New AdvantageFramework.Timesheet.TimesheetSettings(Session("ConnString"), Session("UserCode"))
            Dim TsSettings As New AdvantageFramework.Timesheet.Settings.DisplaySettings
            Dim s As String = ""
            TsSettings = tm.GetSettings(Session("UserCode"), s)
            If TsSettings Is Nothing Then

                Response.Write(s)
                Exit Sub

            Else

                With TsSettings
                    Me.DivisionLabel = .Labels.Division
                    Me.ProductLabel = .Labels.Product
                    Me.ProductCategoryLabel = .Labels.ProdCat
                    Me.JobLabel = .Labels.Job
                    Me.JobComponentLabel = .Labels.JobComponent
                    Me.FunctionCategoryLabel = .Labels.FuncCat
                End With

                Me.LabelDivision.Text = Me.DivisionLabel
                Me.LabelProduct.Text = Me.ProductLabel
                'Me.label.Text = Me.ProductCategoryLabel
                Me.LabelJob.Text = Me.JobLabel
                Me.LabelJobComp.Text = Me.JobComponentLabel
                Me.LabelFunction.Text = Me.FunctionCategoryLabel
                Me.LabelCategory.Text = Me.FunctionCategoryLabel

            End If

        End If

        SetCommentRequirement()

    End Sub

    Public Sub SetDefaultFunction()
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim CurrDefaultFN As String = oTS.GetDefaultFunction(CStr(Session("EmpCode")))
        Try
            ddFunction.SelectedValue = CurrDefaultFN
        Catch ex As Exception

        End Try
    End Sub

    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/default.aspx")
        Exit Sub
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Public Sub LoadTimePage()
        'Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        FillClient(Session("EmpCode"))
        'FillDivision()
        'FillProduct()

        ddJob.DataSource = FillJob(CStr(Session("UserCode")), Me.ddClient.SelectedValue.ToString(), Me.ddDivision.SelectedValue.ToString(), Me.ddProduct.SelectedValue.ToString())
        Try
            With Me.ddJob
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        ddJob.SelectedIndex = 0
        ddJob.Enabled = True
        FillFunction("")
        FillTimeCategory("")
        'ddFunction.Enabled = True
        DDTimeCategory.Enabled = True
        LoadDeptDS()
        'FillJobComp(ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_COMP_NBR)
    End Sub

    Private Sub ddClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddClient.SelectedIndexChanged
        If Session("Saved") = True Then
            Session("Saved") = False
        Else
            LblMSG.Text = ""
        End If

        If Not ddClient.SelectedValue.ToString() = "" Then
            'Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            'ddDivision.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), ddClient.SelectedValue.ToString())
            'Try
            '    With Me.ddDivision
            '        .DataTextField = "description"
            '        .DataValueField = "code"
            '        .DataBind()
            '    End With
            'Catch ex As Exception
            '    
            'End Try
            'ddDivision.Items.Insert(0, New ListItem("--Select--", ""))
            Me.lblClient.Text = ddClient.SelectedValue.ToString.Trim
            ddDivision.Enabled = True
            ddProduct.Enabled = False
            FillDivision(ddClient.SelectedValue.ToString(), "")
        Else
            ddDivision.Enabled = False
            ddDivision.DataSource = Nothing
            ddDivision.DataBind()
            ddDivision.Items.Insert(0, New ListItem("--Select--", ""))
            ddDivision.SelectedIndex = 0

        End If
        ddProduct.Enabled = False
        ddProduct.DataSource = Nothing
        ddProduct.DataBind()
        ddProduct.Items.Insert(0, New ListItem("--None--", ""))
        ddProduct.SelectedIndex = 0

        ddJob.Enabled = True
        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), ddProduct.SelectedValue.ToString())
        ddJob.DataBind()
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        ddJob.SelectedIndex = 0
        FillJobComp(0)
    End Sub

    Private Sub ddDivision_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddDivision.SelectedIndexChanged
        FillProduct(ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), "")
        Me.LblMSG.Text = ""
        Me.lblDivision.Text = Me.ddDivision.SelectedValue.ToString.Trim
        'Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'ddProduct.DataSource = oDD.GetProductList(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString())
        'Try
        '    With Me.ddProduct
        '        .DataTextField = "description"
        '        .DataValueField = "code"
        '        .DataBind()
        '    End With
        'Catch ex As Exception
        '    
        'End Try
        'ddProduct.Items.Insert(0, New ListItem("--None--", ""))
        ddProduct.Enabled = True
        'ddProduct.SelectedIndex = 0

        ddJob.Enabled = True
        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), "")
        ddJob.DataBind()
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        ddJob.SelectedIndex = 0
        FillJobComp(0)

    End Sub

    Private Function FillJob(ByVal sUserCode As String, ByVal sClient As String, ByVal sDivision As String, ByVal sProduct As String) As DataTable

        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))

        If sClient.Length < 1 And sDivision.Length < 1 And sProduct.Length < 1 Then
            Return oDD.GetJobList(sUserCode, JobListType.TimeSheet, "ts")
        Else
            Return oDD.GetJobList(sUserCode, sClient, sDivision, sProduct, JobListType.TimeSheet, "", "", "ts")
        End If

    End Function
    Protected Sub DDTimeCategory_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles DDTimeCategory.SelectedIndexChanged
        Me.LblMSG.Text = ""
        If Not DDTimeCategory.SelectedValue = "" Then

        End If
    End Sub

    Private Sub ddJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddJob.SelectedIndexChanged
        Me.LblMSG.Text = ""
        If Not ddJob.SelectedValue = "" Then

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            oTS.GetJobInfo(ddJob.SelectedValue, "", "", lblClient.Text, lblDivision.Text, lblProduct.Text)
            ddClient.Visible = False
            lblClient.Visible = True
            ddDivision.Visible = False
            lblDivision.Visible = True
            lblProduct.Visible = True
            ddProduct.Visible = False
            ddJobComp.Enabled = True

            DDTimeCategory.SelectedIndex = 0
            DDTimeCategory.Enabled = False

            ddFunction.Enabled = True
            FillJobComp(0)


        Else

            ddJobComp.Enabled = False
            ddJobComp.SelectedIndex = 0

            DDTimeCategory.Enabled = True
            DDTimeCategory.SelectedIndex = 0

            ddFunction.Enabled = False
            ddFunction.SelectedIndex = 0


        End If
    End Sub
    Public Sub FillJobComp(ByVal iCompCode As Integer)

        'If JobNo = 0 And CLIENT = "" And DIVISION = "" And PRODUCT = "" Then
        '    Me.lbLookup.DataSource = oDD.GetJobCompListEE(CStr(Session("UserCode")))
        '    Me.txtType.Value = "JobComp1"
        'Else
        '    Me.lbLookup.DataSource = oDD.GetJobCompListEE(Session("UserID"), CLIENT, DIVISION, PRODUCT, JobNo)
        '    Me.txtType.Value = "JobComp2"
        '    Me.txtClient.Value = CLIENT
        '    Me.txtDivision.Value = DIVISION
        '    Me.txtProduct.Value = PRODUCT
        '    Me.txtJob.Value = JobNo
        'End If
        Try
            Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            ddJobComp.DataSource = oDD.GetJobCompListEE(Session("UserID"), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), ddProduct.SelectedValue.ToString(), ddJob.SelectedValue.ToString())
            Try
                With Me.ddJobComp
                    .DataTextField = "description"
                    .DataValueField = "code"
                    .DataBind()
                End With
            Catch ex As Exception
                
            End Try
        Catch
            ddJobComp.DataSource = Nothing
            ddJobComp.Enabled = False
        End Try
        ddJobComp.Items.Insert(0, New ListItem("--Select--", ""))
        If iCompCode > 0 Then
            ddJobComp.SelectedValue = iCompCode
        Else
            ddJobComp.SelectedIndex = 0
        End If

    End Sub
    Public Sub FillFunction(ByVal sFunctionCode As String)
        'Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'ddFunction.DataSource = oDD.GetFunctionsAll()
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddFunction.DataSource = oDD.GetFunctionsByEmpCodeDatatable(Session("EmpCode"))
        Try
            With Me.ddFunction
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        ddFunction.Items.Insert(0, New ListItem("--Select--", ""))
        If sFunctionCode.Length > 0 Then
            ddFunction.SelectedValue = sFunctionCode
        Else
            ddFunction.SelectedIndex = 0
        End If
    End Sub
    Public Sub FillTimeCategory(ByVal sCategoryCode As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        DDTimeCategory.DataSource = oDD.GetCategories()
        Try
            With Me.DDTimeCategory
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        DDTimeCategory.Items.Insert(0, New ListItem("--Select--", ""))
        If sCategoryCode.Length > 0 Then
            DDTimeCategory.SelectedValue = sCategoryCode
        Else
            DDTimeCategory.SelectedIndex = 0
        End If
    End Sub
    Public Sub FillClient(ByVal sClientID As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddClient.DataSource = oDD.GetClientListTS(CStr(Session("UserCode")), "ts")
        Try
            With Me.ddClient
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        ddClient.Items.Insert(0, New ListItem("--Select--", ""))
        If sClientID.Length > 0 Then
            ddClient.SelectedValue = sClientID
        Else
            ddClient.SelectedIndex = 0
        End If

    End Sub
    Public Sub FillDivision(ByVal sClientCode As String, ByVal sDivisionID As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddDivision.DataSource = oDD.GetDivisionListTS(CStr(Session("UserCode")), sClientCode, "ts")
        Try
            With Me.ddDivision
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        ddDivision.Items.Insert(0, New ListItem("--Select--", ""))
        If sDivisionID.Length > 0 Then
            ddDivision.SelectedValue = sDivisionID
        Else
            ddDivision.SelectedIndex = 0
        End If
    End Sub
    Public Sub FillProduct(ByVal sClientCode As String, ByVal sDivisionID As String, ByVal sProductID As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddProduct.DataSource = oDD.GetProductListTS(CStr(Session("UserCode")), sClientCode, sDivisionID, "ts")
        Try
            With Me.ddProduct
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()
            End With
        Catch ex As Exception
            
        End Try
        ddProduct.Items.Insert(0, New ListItem("--None--", ""))
        If sProductID.Length > 0 Then
            ddProduct.SelectedValue = sProductID
        Else
            ddProduct.SelectedIndex = 0
        End If
    End Sub
    Private Sub ddProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProduct.SelectedIndexChanged
        ddJob.Enabled = True
        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), ddProduct.SelectedValue.ToString())
        ddJob.DataBind()
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        FillJobComp(0)
        Me.lblProduct.Text = ddProduct.SelectedValue.ToString.Trim
        Me.LblMSG.Text = ""
    End Sub
    Private Sub LoadDeptDS()
        Dim odd As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'DsDept = odd.GetDeptDS(Session("EmpCode"), True)
        With Me.ddDepartment
            .DataSource = odd.GetDeptDatatable(Session("EmpCode"), True) 'DsDept
            .DataTextField = "description"
            .DataValueField = "code"
            .DataBind()
        End With
        'ddDepartment.Items.Insert(0, New ListItem("--Select--", ""))
        'ddDepartment.SelectedIndex = 0
    End Sub
    Public Sub SetCommentRequirement()
        Dim oReq As New cRequired(Session("ConnString"))
        'Session("CommentsRequired") = oReq.RequiredTimesheetComments.ToString
        'CommentsRequired = CType(Session("CommentsRequired"), Boolean)
        CommentsRequired = oReq.RequiredTimesheetComments
        If CommentsRequired = True Then
            Me.TxtComments.CssClass = "RequiredInput"
        End If
        'MiscFN.SetToolbarButtonEnabled(Me.RadToolbarTimesheetButtons, 3, Not CommentsRequired)
        'MiscFN.SetToolbarButtonEnabled(Me.RadToolbarTimesheetButtons, 6, Not CommentsRequired)
        'Me.LitAllowRowByRow.Visible = Not CommentsRequired
        'Me.ChkAllowRowByRowSave.Visible = Not CommentsRequired 

    End Sub
    Private Sub BtnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        If DDTimeCategory.SelectedIndex = 0 Then

            If lblDivision.Text = "" Or lblClient.Text = "" Or lblProduct.Text = "" Then
                Me.LblMSG.Text = "client/division/product required."
                Exit Sub
            End If

            If ddJob.SelectedValue = "" Or ddJobComp.SelectedValue = "" Then
                If Not DDTimeCategory.SelectedIndex > 0 Then
                    Me.LblMSG.Text = "Job/Comp or Time Category required."
                    Exit Sub
                End If
            End If
            If ddFunction.SelectedIndex = 0 Then
                LblMSG.Text = "Function Required!"
                Exit Sub
            End If

        End If

        If IsNumeric(Me.TxtHours.Text) = False Then
            Me.LblMSG.Text = "Invalid hours."
            Exit Sub
        End If
        If CType(Me.TxtHours.Text, Decimal) > 24 Then
            Me.LblMSG.Text = "Invalid hours."
            Exit Sub
        End If
        If cGlobals.wvIsDate(Me.TxtDate.Text) = False Then
            LblMSG.Text = "Invalid date."
            Exit Sub
        End If
        'If ddDepartment.SelectedIndex = 0 Then
        '    LblMSG.Text = "Department Required!"
        '    Exit Sub
        'End If
        If CommentsRequired = True Then
            If Me.TxtComments.Text.Length < 1 Then
                LblMSG.Text = "Comment Required!"
                TxtComments.CssClass = "RequiredInput"
                Exit Sub
            End If
        End If


        Dim ThisDate As Date = cGlobals.wvCDate(Me.TxtDate.Text)
        Dim ThisHours As Decimal = CType(Me.TxtHours.Text, Decimal)

        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If DDTimeCategory.SelectedIndex = 0 Then

            If myVal.ValidateJobIsOpen(Me.ddJob.SelectedValue.ToString(), Me.ddJobComp.SelectedValue.ToString()) = False Then
                Me.LblMSG.Text = "This job/comp is closed."
                Exit Sub
            End If
        End If

        If lblClient.Text <> "" Then
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), lblClient.Text, "", "", "ts") = False Then
                Me.LblMSG.Text = "Access to this client is denied."
                Exit Sub
            End If
        End If
        If lblClient.Text <> "" And lblDivision.Text <> "" Then
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), lblClient.Text, lblDivision.Text, "", "ts") = False Then
                Me.LblMSG.Text = "Access to this division is denied."
                Exit Sub
            End If
        End If
        If lblClient.Text <> "" And lblDivision.Text <> "" And lblProduct.Text <> "" Then
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), lblClient.Text, lblDivision.Text, lblProduct.Text, "ts") = False Then
                Me.LblMSG.Text = "Access to this product is denied."
                Exit Sub
            End If
        End If
        If DDTimeCategory.SelectedIndex = 0 Then
            If myVal.ValidateJobCompIsViewable(Session("UserCode"), Me.ddJob.SelectedValue.ToString(), Me.ddJobComp.SelectedValue.ToString, "ts") = False Then
                Me.LblMSG.Text = "Access to this job/comp is denied."
                Exit Sub
            End If
            If myVal.ValidateJobCompIsEditable(Me.ddJob.SelectedValue.ToString(), Me.ddJobComp.SelectedValue.ToString()) = False Then
                Me.LblMSG.Text = "Job/comp process control does not allow access."
                Exit Sub
            End If
        End If
        Dim FunCat As String
        If ddJob.SelectedIndex = 0 And DDTimeCategory.SelectedIndex > 0 Then
            FunCat = DDTimeCategory.SelectedValue
        Else
            FunCat = ddFunction.SelectedValue
        End If
        Dim iJob As Integer
        If Not ddJob.SelectedValue = "" Then
            iJob = ddJob.SelectedValue
        Else
            iJob = 0
        End If
        Dim iJobComp As Short
        If Not ddJobComp.SelectedValue = "" Then
            iJobComp = ddJobComp.SelectedValue
        Else
            iJobComp = 0
        End If

        Dim ThisDept As String = ""
        ThisDept = Me.ddDepartment.SelectedValue

        If myVal.ValidateDeptTeam(ThisDept) = False Then

            Me.ddDepartment.Focus()
            Me.LblMSG.Text = "Invalid Department."
            Exit Sub

        End If

        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        If oTS.CheckApprovalStatus(Session("EmpCode"), ThisDate) = True Then
            Me.LblMSG.Text = "Status for this day is approved/pending."
            Exit Sub
        End If
        If oTS.PostPeriodClosed(ThisDate) = True Then
            Me.LblMSG.Text = "This day is in a closed posting period."
            Exit Sub
        End If

        Try
            Dim ErrStr As String
            'Dim TimesheetMethods As New AdvantageFramework.Timesheet.Methods(Session("ConnString"), Session("UserCode"))

            Dim et As Integer = 0
            Dim etd As Integer = 0
            AdvantageFramework.Timesheet.SaveDay(Session("ConnString"), 0, 0, Session("EmpCode"), ThisDate, FunCat, lblProduct.Text, ThisHours, iJob, iJobComp, ThisDept, Session("UserCode"), ErrStr, Me.TxtComments.Text, et, etd, True)

            LblMSG.Text = "Time Saved!"
            LblMSG.ForeColor = Color.Blue
            Session("Saved") = True
            EmailMissingTime()
            clearscreen()

            'MiscFN.ResponseRedirect("~/mobile/default.aspx")

        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString
        End Try


    End Sub
    Public Sub clearscreen()
        Me.ddClient.SelectedIndex = 0
        Me.ddClient_SelectedIndexChanged(Me, Nothing)

        'Me.ddClient.SelectedIndex = 0
        'Me.ddDivision.SelectedIndex = 0
        'Me.ddProduct.SelectedIndex = 0
        'Me.ddJob.SelectedIndex = 0
        'Me.ddJobComp.SelectedIndex = 0
        'Me.ddFunction.SelectedIndex = 0
        'Me.ddDepartment.SelectedIndex = 0
        Me.TxtDate.Text = ""
        Me.TxtComments.Text = ""
        Me.TxtHours.Text = ""
        SetDefaultFunction()
        Me.ddDepartment.SelectedIndex = 0

    End Sub

    Private Sub lbCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbCancel.Click
        clearscreen()

    End Sub


    Private Function EmailMissingTime() As String
        Dim ChangedDate As Date = cGlobals.wvCDate(Me.TxtDate.Text)
        Dim StartDate, EndDate As Date
        Dim strHoursEmailBody As String = String.Empty
        Dim oTS As AdvantageFramework.Timesheet.TimeSheet = New AdvantageFramework.Timesheet.TimeSheet
        Dim cTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        StartDate = CType(ChangedDate.AddDays(-ChangedDate.DayOfWeek), Date)
        EndDate = CType(ChangedDate.AddDays(ChangedDate.DayOfWeek + (6 - ChangedDate.DayOfWeek)), Date)
        oTS = cTS.GetThisTimeSheetForSelection(CStr(Session("EmpCode")), StartDate, EndDate)

        Dim HTMLNewLine As String = "<br />"
        Dim sb As New System.Text.StringBuilder

        sb.AppendLine("<tr><td height=""18"" colspan=""2"" align=""left"" valign=""middle"" bgcolor=""#92B4E0""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"" color=""#FFFFFF""><strong>&nbsp;&nbsp;")
        sb.AppendLine("Alert Details</strong></font></td></tr>")

        sb.AppendLine("<tr><td align=""left"" style=""width:35%; text-align:left""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(0).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Sunday</strong></font></td>")
        sb.AppendLine("<td align=""left"" style=""width:50px; text-align:left""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Sunday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(1).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Monday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Monday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(2).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Tuesday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Tuesday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(3).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Wednesday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Wednesday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(4).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Thursday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Thursday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(5).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Friday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Friday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>" & StartDate.AddDays(6).ToString("MM/dd/yyyy") & "&nbsp;&nbsp;&nbsp;&nbsp;Saturday</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHoursByDay(DayOfWeek.Saturday).ToString("00.00") & "</font></td></tr>")

        sb.AppendLine("<tr><td>&nbsp;</td></tr>")

        sb.AppendLine("<td align=""left"" style=""text-align:left""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
        sb.AppendLine("<strong>Total:</strong></font></td>")
        sb.AppendLine("<td><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">" & oTS.GetTotalHours.ToString("00.00") & "</font></td></tr>")

        strHoursEmailBody = sb.ToString()

        Try
            'If wvIsDate(Me.TxtDate.Text) = True Then   ' Already validated
            Dim str As String = ProcessMissingTime(CStr(Session("EmpCode")), strHoursEmailBody, StartDate.ToShortDateString, CStr(Session("ConnString")))
            'End If
        Catch ex As Exception
            Response.Write("Error in EmailMissingTime: " & ex.Message.ToString())
        End Try

    End Function

    Public Function ProcessMissingTime(ByVal strEmpCode As String, ByVal strHours As String, ByVal strWeekOf As String, ByVal strConnString As String) As String
        Dim oSQL As SqlHelper
        Dim bool As Boolean
        Dim strMSG As String = String.Empty
        Dim strEmailBody As String = String.Empty
        Dim strEmailSubject As String = String.Empty
        Dim strEmp_FullName As String = String.Empty
        Dim dr As SqlDataReader
        Dim arParams(1) As SqlParameter
        Dim parameterEmpCode As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
        parameterEmpCode.Value = strEmpCode
        arParams(0) = parameterEmpCode
        dr = oSQL.ExecuteReader(strConnString, CommandType.StoredProcedure, "usp_wv_ts_MissingTime", arParams)
        Try
            If dr.HasRows Then
                dr.Read()
                With dr
                    If .GetValue(2) = 1 Then
                        'Missing time is true, set variables
                        Dim sb As New System.Text.StringBuilder
                        Dim HTMLNewLine As String = "<br />"
                        strMSG = "Emp has missing time. "
                        strEmp_FullName = .GetString(1)
                        strEmailSubject = "Missing hours notification for: " & strEmp_FullName

                        sb.AppendLine("<body bgcolor=""#FFFFFF"">")
                        sb.AppendLine("<table width=""99%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        sb.AppendLine("<tr><td height=""18"" align=""left"" valign=""middle"" bgcolor=""#92B4E0""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"" color=""#FFFFFF"">")
                        sb.AppendLine("&nbsp;&nbsp;<strong>[New Alert]</strong>")
                        sb.AppendLine("</font></td></tr>")

                        sb.AppendLine("<tr><td align=""left""><font size=""2"" face=""Verdana, Arial, Helvetica, sans-serif"">")
                        sb.AppendLine("On " & Now.ToString("MM/dd/yyyy") & " at " & Now.ToShortTimeString & ", ")
                        sb.AppendLine(strEmp_FullName & " entered time for the week of " & strWeekOf & " and includes the following hours per day:" & HTMLNewLine & HTMLNewLine)
                        sb.AppendLine("</font></td></tr>")
                        sb.AppendLine("</table>")

                        sb.AppendLine("<table width=""99%"" border=""0"" cellspacing=""0"" cellpadding=""2"" bgcolor=""#FFFFFF"">")
                        sb.AppendLine(strHours)
                        sb.AppendLine("</table>")
                        sb.AppendLine("</body>")
                        strEmailBody = sb.ToString()

                        Dim wsEmail As New cWebServices(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"), HttpContext.Current.Session("EmpCode"))
                        Try
                            If .GetValue(3) = 1 Then 'EMAIL_SUPERVISOR is true
                                strMSG &= "Email supervisor is true. "
                                If .IsDBNull(4) = False Then
                                    'send email to EMAIL_SUPERVISOR
                                    bool = wsEmail.SendEmail("", .GetString(4), "Supervisor Alert! " & strEmailSubject, strEmailBody, "", "", True)
                                    If bool = False Then
                                        'JSMessageBox(wsEmail.getErrMsg)
                                        strMSG &= wsEmail.getErrMsg
                                    Else
                                        strMSG &= "Email supervisor sent. "
                                    End If

                                Else
                                    strMSG &= "No supervisor email address! "
                                End If
                            End If
                        Catch ex As Exception
                            Return "Error in ProcessMissingTime:Supervisor Email. " & ex.Message.ToString
                        End Try
                        Try
                            If .GetValue(5) = 1 Then 'EMAIL_IT_CONTACT is true
                                strMSG &= "Email IT Contact is true."
                                If .IsDBNull(6) = False Then
                                    'send email to EMAIL_IT_CONTACT
                                    bool = wsEmail.SendEmail("", .GetString(6), "I/T Contact Alert! " & strEmailSubject, strEmailBody, "", "", True)
                                    If bool = False Then
                                        'JSMessageBox(wsEmail.getErrMsg)
                                        strMSG &= wsEmail.getErrMsg
                                    Else
                                        strMSG &= "Email IT Contact sent. "
                                    End If

                                Else
                                    strMSG &= "No IT Contact email address! "
                                End If
                            End If
                        Catch ex As Exception
                            Return "Error in ProcessMissingTime:IT Contact Email. " & ex.Message.ToString
                        End Try
                        'Update EMPLOYEE.MISSING_TIME flag
                        Try
                            Dim arParamsDel(1) As SqlParameter
                            Dim parameterEmpCodeDel As New SqlParameter("@EMP_CODE", SqlDbType.VarChar, 6)
                            parameterEmpCodeDel.Value = strEmpCode
                            arParamsDel(0) = parameterEmpCode
                            oSQL.ExecuteScalar(strConnString, CommandType.StoredProcedure, "usp_wv_ts_MissingTime_UpdateFlag", arParamsDel)
                            strMSG &= "Updated Emp table and set MISSING_TIME flag to zero. "
                        Catch ex As Exception
                            Return "Error in ProcessMissingTime:Updating EMPLOYEE.MISSING_TIME flag. " & ex.Message.ToString
                        End Try
                        'Response.Write("subject: " & strEmailSubject & "<br />body: " & strEmailBody)
                    Else 'MISSING_TIME column is zero
                        strMSG = "Emp not missing time."
                    End If
                End With
                Return strMSG
                'Response.Write(strMSG)
            Else
                Exit Function
            End If
        Catch ex As Exception
            Response.Write("Error in ProcessMissingTime. " & ex.Message.ToString())
        End Try
    End Function


    Private Sub Page_LoadComplete(sender As Object, e As System.EventArgs) Handles Me.LoadComplete

        Me.TrFunction.Visible = Me.ddFunction.Enabled
        Me.TrCategory.Visible = Not Me.TrFunction.Visible

    End Sub
End Class