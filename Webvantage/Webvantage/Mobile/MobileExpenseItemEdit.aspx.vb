
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Drawing

Partial Public Class MobileExpenseItemEdit1
    Inherits MobileBase

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)
            If Request.QueryString("ItemNumber") = "new" Then
                Session("NewExpense") = True
                NewExpenseItem(CInt(Request.QueryString("invoice")))
            Else
                LoadExpenseItem(CInt(Request.QueryString("invoice")), CInt(Request.QueryString("ItemNumber")))
            End If
        End If
    End Sub
    Public Sub NewExpenseItem(ByVal iInvoiceNumber As Integer)
        Dim ThisExpenseHeader As ExpenseHeader
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim Invoice As Integer = iInvoiceNumber
        ThisExpenseHeader = oExpense.GetExpenseHeader(Invoice, False)

        If oTS.UserLimited(Session("UserCode")) = True Then
            If Session("EmpCode") <> ThisExpenseHeader.EMP_CODE Then
                Exit Sub
            End If
        End If
        Me.lblReportNum.Text = ThisExpenseHeader.INV_NBR
        Me.lblEmployee.Text = ThisExpenseHeader.EMP_CODE '+ " " + ThisExpenseHeader.EmployeeName
        Select Case ThisExpenseHeader.STATUS
            Case ExpenseStatus.Open
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                Me.lbSave.Visible = True
                Me.lbSave.Enabled = True

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

                ddClient.Enabled = True
                ' lbFunction.Enabled = True
                ddFunction.Enabled = True
                ddClient.Enabled = True
                'txtFunction.Enabled = True
            Case ExpenseStatus.Pending
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

            Case ExpenseStatus.Approved

                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

        End Select
        'Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'ddClient.DataSource = oDD.GetClientList(CStr(Session("UserCode")))
        'Try
        '    With Me.ddClient
        '        .DataTextField = "description"
        '        .DataValueField = "code"
        '        .DataBind()
        '    End With
        'Catch ex As Exception
        '    
        'End Try
        'ddClient.Items.Insert(0, New ListItem("--Select--", ""))
        FillClient("")
        FillFunction("")
        ddJob.Enabled = True
        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), ddProduct.SelectedValue.ToString())

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

    End Sub

    Public Sub LoadExpenseItem(ByVal iInvoiceNumber As Integer, ByVal ItemNumber As Integer)

        Dim ThisExpenseHeader As ExpenseHeader
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim Invoice As Integer = iInvoiceNumber
        Dim iItemNumber As Integer = ItemNumber '- 1
        ThisExpenseHeader = oExpense.GetExpenseHeader(Invoice, False)
        lblItemNumber.Text = ItemNumber.ToString
        If oTS.UserLimited(Session("UserCode")) = True Then
            If Session("EmpCode") <> ThisExpenseHeader.EMP_CODE Then
                Exit Sub
            End If
        End If
        'check for billable.
        Dim oJobFunctions As cJobFunctions = New cJobFunctions(Session("ConnString"))
        Dim isBillable As Boolean = oJobFunctions.IsJobBillable("", ThisExpenseHeader.ExpenseDetails(iItemNumber).FNC_CODE.ToString(), ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE.ToString(), ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE.ToString(), ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE.ToString(), CInt(ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_NBR.ToString()), CInt(ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_COMP_NBR.ToString()))
        If isBillable = True Then
            chkNonBillable.Visible = False
            chkNonBillable.Checked = False
        Else
            chkNonBillable.Visible = True
            chkNonBillable.Checked = True
            chkNonBillable.Enabled = False
        End If

        Me.lblReportNum.Text = ThisExpenseHeader.INV_NBR
        Me.lblEmployee.Text = ThisExpenseHeader.EMP_CODE '+ " " + ThisExpenseHeader.EmployeeName
        Select Case ThisExpenseHeader.STATUS
            Case ExpenseStatus.Open
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC

                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE


                Me.lbSave.Visible = True
                Me.lbSave.Enabled = True

                Me.lbDeleteItem.Visible = True
                Me.lbDeleteItem.Enabled = True

            Case ExpenseStatus.Pending
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                txtItemDate.Enabled = False
                chkNonBillable.Enabled = False
                txtQty.Enabled = False
                txtRate.Enabled = False
                txtAmount.Enabled = False
                txtDescription.Enabled = False
                Me.txtItemDescription.Enabled = False
                Me.chkCreditCard.Enabled = False
                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

            Case ExpenseStatus.Approved

                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                txtItemDate.Enabled = False
                chkNonBillable.Enabled = False
                txtQty.Enabled = False
                txtRate.Enabled = False
                txtAmount.Enabled = False
                txtDescription.Enabled = False
                Me.txtItemDescription.Enabled = False

                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

                Me.chkCreditCard.Enabled = False
        End Select
        Me.lblEXPDETAILID.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).EXPDETAILID
        Me.txtItemDate.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).ITEM_DATE
        Me.chkCreditCard.Checked = ThisExpenseHeader.ExpenseDetails(iItemNumber).CC_FLAG
        'Me.txtClient.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE
        'Me.txtDivision.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE
        'Me.txtProduct.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE
        'Me.txtJob.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_NBR
        'Me.txtJobComp.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_COMP_NBR
        'Me.txtFunction.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).FNC_CODE
        Me.txtQty.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).QTY
        Me.txtRate.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).RATE
        Me.txtAmount.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).AMOUNT
        Me.txtItemDescription.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).ITEM_DESC

        FillFunction(ThisExpenseHeader.ExpenseDetails(iItemNumber).FNC_CODE)

        'Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        'ddClient.DataSource = oDD.GetClientList(CStr(Session("UserCode")))
        'Try
        '    With Me.ddClient
        '        .DataTextField = "description"
        '        .DataValueField = "code"
        '        .DataBind()
        '    End With
        'Catch ex As Exception
        '    
        'End Try
        ' FillClient(ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE)
        Me.lblClient.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE
        lblClient.Visible = True
        Me.ddClient.Visible = False
        'ddClient.SelectedValue = ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE
        'ddDivision.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE)
        'Try
        '    With Me.ddDivision
        '        .DataTextField = "description"
        '        .DataValueField = "code"
        '        .DataBind()
        '    End With
        'Catch ex As Exception
        '    
        'End Try
        FillDivision(ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE)
        Me.lblDivision.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE
        Me.lblDivision.Visible = True
        Me.ddDivision.Visible = False
        ' ddDivision.DataSource = ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE
        'ddProduct.DataSource = oDD.GetProductList(CStr(Session("UserCode")), ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE)
        'Try
        '    With Me.ddProduct
        '        .DataTextField = "description"
        '        .DataValueField = "code"
        '        .DataBind()
        '    End With
        'Catch ex As Exception
        '    
        'End Try
        FillProduct(ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE)
        Me.lblProduct.Text = ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE
        Me.lblProduct.Visible = True
        Me.ddProduct.Visible = False
        'ddProduct.DataSource = ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE

        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ThisExpenseHeader.ExpenseDetails(iItemNumber).CL_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).DIV_CODE, ThisExpenseHeader.ExpenseDetails(iItemNumber).PRD_CODE)
        Try
            With Me.ddJob
                .DataTextField = "description"
                .DataValueField = "code"
                .DataBind()

            End With
        Catch ex As Exception

        End Try
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        ddJob.SelectedValue = ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_NBR.ToString
        ddJob.Enabled = False
        FillJobComp(ThisExpenseHeader.ExpenseDetails(iItemNumber).JOB_COMP_NBR)
    End Sub
    Private Sub AddExpenseItem()
        Dim ThisExpenseDetail As ExpenseDetail
        'Modified by Sam Tran on 2006/05/17
        '	added vars below
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim ThisJob As String
        Dim ThisJobComp As String
        Dim ThisClient As String
        Dim ThisDiv As String
        Dim ThisProd As String
        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))

        If Me.lblClient.Text <> "" Then
            If oValidation.ValidateCDP(lblClient.Text.Trim, "", "") = False Then

                lblMessage.Text = "Inactive Client."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), lblClient.Text.Trim, "", "") = False Then

                lblMessage.Text = "Access to this client is denied."
                lblMessage.ForeColor = Color.Red

                Exit Sub
            End If
        End If

        If lblClient.Text.Trim <> "" And lblDivision.Text.Trim <> "" Then
            If oValidation.ValidateCDP(lblClient.Text.Trim, lblDivision.Text.Trim, "") = False Then

                lblMessage.Text = "Invalid Division."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), lblClient.Text.Trim, lblDivision.Text.Trim, "") = False Then

                lblMessage.Text = "Access to this division is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If lblClient.Text <> "" And lblDivision.Text <> "" And lblProduct.Text <> "" Then
            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), lblClient.Text.Trim, lblDivision.Text.ToString.Trim, lblProduct.Text.Trim) = False Then

                lblMessage.Text = "Access to this product is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If Me.ddJob.SelectedValue.ToString() <> "" Then
            If IsNumeric(ddJob.SelectedValue.ToString.Trim) = False Then

                lblMessage.Text = "Job number is not a number!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateJobNumber(ddJob.SelectedValue.ToString()) = False Then

                lblMessage.Text = "This job does not exist!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If ddJobComp.SelectedValue.ToString() <> "" Then
            If IsNumeric(ddJobComp.SelectedValue.ToString.Trim) = False Then

                lblMessage.Text = "Job component number is not a number!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If ddJob.SelectedValue.ToString() = "" And ddJobComp.SelectedValue.ToString() <> "" Then


            lblMessage.Text = "You cannot enter a component number without a job number."
            lblMessage.ForeColor = Color.Red

            Exit Sub
        End If
        If ddJob.SelectedValue.ToString() <> "" And ddJobComp.SelectedValue.ToString() <> "" Then
            If oValidation.ValidateJobCompNumber(ddJob.SelectedValue.ToString(), ddJobComp.SelectedValue.ToString()) = False Then
                lblMessage.Text = "This is not a valid job/component!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateJobCompIsViewable(Session("UserCode"), ddJob.SelectedValue.ToString.Trim, ddJobComp.SelectedValue.ToString.Trim) = False Then
                lblMessage.Text = "Access to this job/comp is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If



        'Modified by Sam Tran on 2006/05/17
        If ddJob.SelectedValue.ToString.Trim = "" Then
            ThisJob = 0
        Else
            If IsNumeric(ddJob.SelectedValue.ToString()) Then
                ThisJob = CInt(ddJob.SelectedValue.ToString())
            End If
        End If

        If ddJobComp.SelectedValue.ToString.Trim = "" Then
            ThisJobComp = 0
        Else
            If IsNumeric(ddJobComp.SelectedValue.ToString()) Then
                ThisJobComp = CInt(ddJobComp.SelectedValue.ToString())
            End If
        End If

        If ThisJob > 0 And ThisJobComp = 0 Then
            lblMessage.Text = "Job selected without a component"
            lblMessage.ForeColor = Color.Red
            Exit Sub
        End If

        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                lblMessage.Text = "Invalid Job and Job Component."
                lblMessage.ForeColor = Color.Red

                Exit Sub
            End If
        End If
        Dim dTotal As Double
        ' = (CDbl(txtQty.Text) * CDbl(txtRate.Text))
        If IsNumeric(txtAmount.Text) Then
            dTotal = CDbl(txtAmount.Text)
        End If
        ThisExpenseDetail = ValidateLine(0, Me.txtItemDate.Text, ThisClient, ThisDiv, ThisProd, ddJob.SelectedValue.ToString.Trim, ddJobComp.SelectedValue.ToString.Trim, ddFunction.SelectedValue.ToString.Trim, Me.txtQty.Text.Trim, Me.txtRate.Text.Trim, dTotal.ToString(), Me.chkCreditCard.Checked, Me.txtItemDescription.Text.Trim)
        'st: validate line function above should be stopping the insert but I don't see it happening 
        If Not ThisExpenseDetail Is Nothing Then
            If oExpense.InsertExpenseDetail(ThisExpenseDetail) > 0 Then
                Session("NewExpense") = Nothing
                MiscFN.ResponseRedirect("~/mobile/MobileExpenseEdit.aspx?invoice=" & Me.lblReportNum.Text)
            End If
        End If

    End Sub
    Private Function ValidateLine(ByVal ExpDetailID As Integer, _
                                      ByVal ItemDate As String, _
                                      ByVal ClientCode As String, _
                                      ByVal DivisionCode As String, _
                                      ByVal ProductCode As String, _
                                      ByVal Job As String, _
                                      ByVal JobComp As String, _
                                      ByVal FunctCat As String, _
                                      ByVal Qty As String, _
                                      ByVal Rate As String, _
                                      ByVal Amount As String, _
                                      ByVal CreditCard As Boolean, _
                                      ByVal ItemDesc As String) As ExpenseDetail
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
        Dim ThisExpenseDetail As ExpenseDetail = New ExpenseDetail
        Dim ThisJob As Integer
        Dim ThisJobComp As Integer
        Dim ThisClient As String
        Dim ThisDiv As String
        Dim ThisProd As String

        'Expense Header ID
        ThisExpenseDetail.INV_NBR = Me.lblReportNum.Text
        ThisExpenseDetail.EXPDETAILID = ExpDetailID

        'Item Date
        If ItemDate.Trim = "" Then
            lblMessage.Text = "Date is required."
            lblMessage.ForeColor = Color.Red
            Exit Function
        End If

        If wvIsDate(ItemDate) = False Then
            'Me.ShowMessage(ItemDate & " is an invalid date.")
            lblMessage.Text = ItemDate & " is an invalid date."
            lblMessage.ForeColor = Color.Red
            Exit Function
        Else
            ThisExpenseDetail.ITEM_DATE = wvCDate(ItemDate)
            'ThisExpenseDetail.ITEM_DATE = ItemDate
        End If

        Dim dtStart As DateTime = Convert.ToDateTime("3/31/1974 12:00:00 AM")
        Dim dtEnd As DateTime = Convert.ToDateTime("6/6/2079 11:59:59 PM")
        If ThisExpenseDetail.ITEM_DATE < dtStart Or ThisExpenseDetail.ITEM_DATE > dtEnd Then
            lblMessage.Text = "Date invalid"
            lblMessage.ForeColor = Color.Red
            Exit Function
        End If

        'Modified by Sam Tran on 2006/05/17
        '	not touching the below, running another if
        'If Not Job Is Nothing Or Job.Length > 0 Or Job <> String.Empty Or Job <> "" Then
        'If JobComp.Length = 0 Or JobComp Is Nothing Or JobComp = String.Empty Or JobComp = "" Then
        'wvMsgBox("You specified a job without specifying a job component!<BR />Please either supply a job component, or remove the job number!")
        'Exit Function
        'End If
        'End If


        'Get Client, Division and Product of only Job and Job Comp is given
        If Job = "" Then
            'ThisJob = Nothing
        Else
            If IsNumeric(Job) Then
                ThisJob = CInt(Job)
            Else
                'ThisJob = Nothing
            End If
        End If

        If JobComp = "" Then
            'ThisJobComp = Nothing
        Else
            If IsNumeric(JobComp) Then
                ThisJobComp = CInt(JobComp)
            Else
                'ThisJobComp = Nothing
            End If
        End If
        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.IsJobExpensible(ThisJob, ThisJobComp) = False Then
                'Me.ShowMessage("Invalid Job and Job Component (Not Expensible)")
                lblMessage.Text = "Invalid Job and Job Component (Not Expensible)."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If

            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                'Me.ShowMessage("Invalid Job and Job Component")
                lblMessage.Text = "Invalid Job and Job Component."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
            'Modified by Sam Tran on 2006/05/17
            '	  added the elsif
            'ElseIf ThisJob > 0 And ThisJobComp <= 0 Then
            'wvMsgBox("You specified a job without specifying a job component!<BR />Please either supply a job component, or remove the job number!")
            'Exit Function
        End If

        If ThisClient <> "" Then
            If oValidation.ValidateCDP(ThisClient, "", "") = False Then
                'Me.ShowMessage("Inactive Client.")
                lblMessage.Text = "Inactive Client."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), ThisClient, "", "") = False Then
                'Me.ShowMessage("Access to client is denied.")
                lblMessage.Text = "Access to client is denied."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
        End If
        If ThisDiv <> "" Then
            If oValidation.ValidateCDP(ThisClient, ThisDiv, "") = False Then
                ' Me.ShowMessage("Invalid division.")
                lblMessage.Text = "Invalid Division."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), ThisClient, ThisDiv, "") = False Then
                'Me.ShowMessage("Access to client is denied.")
                lblMessage.Text = "Access to client is denied."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
        End If
        If ThisProd <> "" Then
            If oValidation.ValidateCDP(ThisClient, ThisDiv, ThisProd) = False Then
                'Me.ShowMessage("Invalid Product.")
                lblMessage.Text = "Invalid Product."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), ThisClient, ThisDiv, ThisProd) = False Then
                '  Me.ShowMessage("Access to client is denied.")
                lblMessage.Text = "Access to client is denied."
                lblMessage.ForeColor = Color.Red
                Exit Function
            End If
        End If
        ThisExpenseDetail.CL_CODE = ThisClient
        ThisExpenseDetail.DIV_CODE = ThisDiv
        ThisExpenseDetail.PRD_CODE = ThisProd
        ThisExpenseDetail.JOB_NBR = ThisJob
        ThisExpenseDetail.JOB_COMP_NBR = ThisJobComp

        'Check Function
        If FunctCat = "" Then
            'Me.ShowMessage("Function is a required field.")
            lblMessage.Text = "Function is a required field."
            lblMessage.ForeColor = Color.Red
            Exit Function
        End If
        If oValidation.ValidateFunctionCategoryAll(Me.lblEmployee.Text.Trim, FunctCat, "V", False) = False Then
            'Me.ShowMessage(FunctCat & " is an invalid function.")
            lblMessage.Text = FunctCat & " is an invalid function."
            lblMessage.ForeColor = Color.Red
            Exit Function
        Else
            ThisExpenseDetail.FNC_CODE = FunctCat
        End If

        'Qty
        If Qty <> "" And Qty <> String.Empty Then
            If IsNumeric(Qty) = False Then
                'Me.ShowMessage(Qty & " is not a numeric quantity.")
                lblMessage.Text = Qty & " is not a numeric quantity."
                lblMessage.ForeColor = Color.Red
                Exit Function
            Else
                ThisExpenseDetail.QTY = CInt(Qty)
            End If
        End If

        'Check Rate
        If Rate <> "" Then
            If IsNumeric(Rate) = False Then
                'Me.ShowMessage(Rate & " is not a numeric rate.")
                lblMessage.Text = Rate & " is not a numeric rate."
                lblMessage.ForeColor = Color.Red
                Exit Function
            Else
                ThisExpenseDetail.RATE = CDec(Rate)
            End If
        End If

        'Check Amount
        If Amount = "" Then
            'Me.ShowMessage("You need to enter an Amount.")
            lblMessage.Text = "You need to enter an Amount."
            lblMessage.ForeColor = Color.Red
            Exit Function
        Else
            If IsNumeric(Amount) = False Then
                'Me.ShowMessage(Amount & " is not a numeric amount.")
                lblMessage.Text = Amount & " is not a numeric amount."
                lblMessage.ForeColor = Color.Red
                Exit Function
            Else
                ThisExpenseDetail.AMOUNT = CDec(Amount)
            End If
        End If

        'Check Description
        If ItemDesc = "" Then
            ' Me.ShowMessage("You need to enter a Description.")
            lblMessage.Text = "You need to enter a Description."
            lblMessage.ForeColor = Color.Red
            Exit Function
        Else
            ThisExpenseDetail.ITEM_DESC = ItemDesc
        End If

        ThisExpenseDetail.CC_FLAG = CreditCard
        ThisExpenseDetail.CREATE_USER_ID = Session("UserCode")
        '---------------------------------------------------------------------------------
        'CTB: 06/06/2006 - Date was storing as a date only when date and time were needed.
        '---------------------------------------------------------------------------------
        ThisExpenseDetail.MOD_DATE = DateTime.Now.ToString
        ThisExpenseDetail.MOD_USER_ID = Session("UserCode")

        Return ThisExpenseDetail

    End Function
    'Public Sub CheckAppAccess(ByVal ThisAppName As String)
    '    Try
    '        Dim oSec As New cSecurity(Session("ConnString"))
    '        If oSec.UserHasAccessToApp(ThisAppName, Session("UserCode")) = False Then
    '            Server.Transfer("~/mobile/NoAccess.aspx")
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileExpenseEdit.aspx?invoice=" & Me.lblReportNum.Text)
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Private Sub lbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSave.Click
        If Session("NewExpense") = True Then
            AddExpenseItem()
        Else
            Save_Click()
        End If
    End Sub

    Private Function IsApproved(ByVal ExpenseReportNumber As Integer) As Boolean
        Try
            Dim oExpense As cExpense = New cExpense(Session("ConnString"))
            Dim eh As ExpenseHeader
            eh = oExpense.GetExpenseHeader(ExpenseReportNumber, False)
            If eh.STATUS = ExpenseStatus.Approved Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            ' Me.ShowMessage(ex.Message.ToString(), "Error checking expense header status.")
            lblMessage.Text = "Error checking expense header status."
            lblMessage.ForeColor = Color.Red
        End Try
    End Function
    Private Sub Save_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                'Me.ShowMessage("Expense report has already been approved and cannot be modified.")
                Me.lblMessage.Text = "Expense report has already been approved."
                lblMessage.ForeColor = Color.Red
                LoadExpenseItem(CType(Me.lblReportNum.Text.Trim, Integer), CInt(lblItemNumber.Text))
                Exit Sub
            End If
        End If

        '_________________________________________________________
        Dim ThisExpenseDetail As ExpenseDetail
        'Modified by Sam Tran on 2006/05/17
        '	added vars below
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
        Dim ThisJob As String
        Dim ThisJobComp As String
        Dim ThisClient As String
        Dim ThisDiv As String
        Dim ThisProd As String
        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))

        If lblClient.Text <> "" Then
            'If oValidation.ValidateCDP(ddClient.SelectedValue.ToString.Trim, "", "") = False Then
            If oValidation.ValidateCDP(lblClient.Text.Trim, "", "") = False Then
                lblMessage.Text = "Inactive Client."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            'If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), ddClient.SelectedValue.ToString.Trim, "", "") = False Then
            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), lblClient.Text.Trim, "", "") = False Then
                lblMessage.Text = "Access to this client is denied."
                lblMessage.ForeColor = Color.Red

                Exit Sub
            End If
        End If

        If ddClient.SelectedValue.ToString() <> "" And ddDivision.SelectedValue.ToString() <> "" Then
            If oValidation.ValidateCDP(ddClient.SelectedValue.ToString.Trim, lblDivision.Text.Trim, "") = False Then

                lblMessage.Text = "Invalid Division."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), lblClient.Text.Trim, lblDivision.Text.Trim, "") = False Then

                lblMessage.Text = "Access to this division is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If lblClient.Text.Trim <> "" And lblDivision.Text.Trim <> "" And lblProduct.Text.Trim <> "" Then
            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), lblClient.Text.Trim, lblDivision.Text.Trim, lblProduct.Text.Trim) = False Then

                lblMessage.Text = "Access to this product is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If ddJob.SelectedValue.ToString() <> "" Then
            If IsNumeric(ddJob.SelectedValue.ToString.Trim) = False Then

                lblMessage.Text = "Job number is not a number!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateJobNumber(ddJob.SelectedValue.ToString()) = False Then

                lblMessage.Text = "This job does not exist!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If ddJobComp.SelectedValue.ToString() <> "" Then
            If IsNumeric(ddJobComp.SelectedValue.ToString.Trim) = False Then

                lblMessage.Text = "Job component number is not a number!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If
        If ddJob.SelectedValue.ToString() = "" And ddJobComp.SelectedValue.ToString() <> "" Then


            lblMessage.Text = "You cannot enter a component number without a job number."
            lblMessage.ForeColor = Color.Red

            Exit Sub
        End If
        If ddJob.SelectedValue.ToString() <> "" And ddJobComp.SelectedValue.ToString() <> "" Then
            If oValidation.ValidateJobCompNumber(ddJob.SelectedValue.ToString(), ddJobComp.SelectedValue.ToString()) = False Then
                lblMessage.Text = "This is not a valid job/component!"
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
            If oValidation.ValidateJobCompIsViewable(Session("UserCode"), ddJob.SelectedValue.ToString.Trim, ddJobComp.SelectedValue.ToString.Trim) = False Then
                lblMessage.Text = "Access to this job/comp is denied."
                lblMessage.ForeColor = Color.Red
                Exit Sub
            End If
        End If



        'Modified by Sam Tran on 2006/05/17
        If ddJob.SelectedValue.ToString.Trim = "" Then
            ThisJob = 0
        Else
            If IsNumeric(ddJob.SelectedValue.ToString()) Then
                ThisJob = CInt(ddJob.SelectedValue.ToString())
            End If
        End If

        If ddJobComp.SelectedValue.ToString.Trim = "" Then
            ThisJobComp = 0
        Else
            If IsNumeric(ddJobComp.SelectedValue.ToString()) Then
                ThisJobComp = CInt(ddJobComp.SelectedValue.ToString())
            End If
        End If

        If ThisJob > 0 And ThisJobComp = 0 Then
            lblMessage.Text = "Job selected without a component"
            lblMessage.ForeColor = Color.Red
            Exit Sub
        End If

        If ThisJob > 0 And ThisJobComp > 0 Then
            If oJobFuncs.GetCliDivProdFromJob(ThisJob, ThisJobComp, ThisClient, ThisDiv, ThisProd) = False Then
                lblMessage.Text = "Invalid Job and Job Component."
                lblMessage.ForeColor = Color.Red

                Exit Sub
            End If
        End If
        If Not IsNumeric(txtAmount.Text) Then
            If txtAmount.Text.Length < 1 Then
                lblMessage.Text = "Amount required."
                lblMessage.ForeColor = Color.Red
            Else
                lblMessage.Text = "Must be a numeric Amount"
                lblMessage.ForeColor = Color.Red

            End If
        End If

        'Dim dTotal As Double = (CDbl(txtQty.Text) * CDbl(txtRate.Text))
        Dim dTotal As Double
        ' = (CDbl(txtQty.Text) * CDbl(txtRate.Text))
        If IsNumeric(txtAmount.Text) Then
            dTotal = CDbl(txtAmount.Text)
        End If
        '_____________________________________________________
        If lblItemNumber.Text <> "" Then
            ThisExpenseDetail = ValidateLine(CInt(Me.lblEXPDETAILID.Text), Me.txtItemDate.Text, ThisClient, ThisDiv, ThisProd, ddJob.SelectedValue.ToString.Trim, ddJobComp.SelectedValue.ToString.Trim, ddFunction.SelectedValue.ToString.Trim, Me.txtQty.Text.Trim, Me.txtRate.Text.Trim, dTotal.ToString(), Me.chkCreditCard.Checked, Me.txtItemDescription.Text.Trim)
            If Not ThisExpenseDetail Is Nothing Then

                If oExpense.UpdateExpenseDetail(ThisExpenseDetail) = False Then
                    lblMessage.Text = "Save Failed"
                    lblMessage.ForeColor = Color.Red
                    Session("lcSavedOK") = "No"
                    Exit Sub
                Else
                    MiscFN.ResponseRedirect("~/mobile/MobileExpenseEdit.aspx?invoice=" & Me.lblReportNum.Text)
                End If

            Else
                Session("lcSavedOK") = "No"
                Exit Sub
            End If
        End If
    End Sub

    Protected Sub lbDeleteItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbDeleteItem.Click
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim myReturn As Boolean
        If oExpense.DeleteExpenseDetail(CInt(Me.lblEXPDETAILID.Text)) = True Then
            MiscFN.ResponseRedirect("~/mobile/MobileExpenseEdit.aspx?invoice=" & Me.lblReportNum.Text)
        Else
            lblMessage.Text = "Delete failed!"
            lblMessage.ForeColor = Color.Red
        End If
    End Sub

    Private Sub ddClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddClient.SelectedIndexChanged
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
            ddDivision.Enabled = True
            ddProduct.Enabled = False
            Me.lblClient.Text = ddClient.SelectedValue.ToString
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
        lblDivision.Text = ddDivision.SelectedValue.ToString
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
            Return oDD.GetJobList(sUserCode, JobListType.ExpenseEdit)
        Else
            Return oDD.GetJobList(sUserCode, sClient, sDivision, sProduct, JobListType.ExpenseEdit)
        End If

    End Function


    Private Sub ddJob_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddJob.SelectedIndexChanged
        If Not ddJob.SelectedValue = "" Then

            Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
            'Dim ds As DataSet
            'ds = oTS.GetInfoForPopup(ddJob.SelectedValue)
            'If ds.Tables(0).Rows.Count > 0 Then
            '    lblClient.Text = ds.Tables(0).Rows(0).Item("client").ToString
            '    lblDivision.Text = ds.Tables(0).Rows(0).Item("division").ToString
            '    lblProduct.Text = ds.Tables(0).Rows(0).Item("product").ToString
            '    ddClient.Visible = False
            '    lblClient.Visible = True
            '    ddDivision.Visible = False
            '    lblDivision.Visible = True
            '    lblProduct.Visible = True
            '    ddProduct.Visible = False
            '    ddJobComp.Enabled = True
            '    FillJobComp(0)
            'End If
            oTS.GetJobInfo(ddJob.SelectedValue, "", "", lblClient.Text, lblDivision.Text, lblProduct.Text)
            ddClient.Visible = False
            lblClient.Visible = True
            ddDivision.Visible = False
            lblDivision.Visible = True
            lblProduct.Visible = True
            ddProduct.Visible = False
            ddJobComp.Enabled = True
            FillJobComp(0)

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

                ddJobComp.DataSource = Nothing
                ddJobComp.Enabled = False
            End Try
        Catch

        End Try
        ddJobComp.Items.Insert(0, New ListItem("--Select--", ""))
        If iCompCode > 0 Then
            ddJobComp.SelectedValue = iCompCode.ToString
        Else
            ddJobComp.SelectedIndex = 0
        End If

    End Sub
    Public Sub FillFunction(ByVal sFunctionCode As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddFunction.DataSource = oDD.GetFunctionsAll()
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
    Public Sub FillClient(ByVal sClientID As String)
        Dim oDD As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
        ddClient.DataSource = oDD.GetClientList(CStr(Session("UserCode")))
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
        ddDivision.DataSource = oDD.GetDivisionList(CStr(Session("UserCode")), sClientCode)
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
        ddProduct.DataSource = oDD.GetProductList(CStr(Session("UserCode")), sClientCode, sDivisionID)
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

    Protected Sub ImgBtnGetRate_Click(ByVal sender As System.Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnGetRate.Click
        Try
            Dim oExpense As cExpense = New cExpense(Session("ConnString"))
            Dim decRate As Decimal = oExpense.GetFunctionRate(ddFunction.SelectedValue.ToString.Trim)

            If ddFunction.SelectedValue.ToString() <> "" And ddFunction.SelectedValue.ToString.Length > 0 Then
                If decRate > 0 Then
                    Me.txtRate.Text = decRate.ToString
                    If Me.txtQty.Text <> "" And Me.txtQty.Text.Length > 0 And IsNumeric(Me.txtQty.Text) Then
                        Me.txtAmount.Text = CType(CType(Me.txtQty.Text, Decimal) * decRate, String).ToString
                    End If
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ddProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddProduct.SelectedIndexChanged
        Me.lblProduct.Text = ddProduct.SelectedValue.ToString
        ddJob.Enabled = True
        ddJob.DataSource = FillJob(CStr(Session("UserCode")), ddClient.SelectedValue.ToString(), ddDivision.SelectedValue.ToString(), ddProduct.SelectedValue.ToString())
        ddJob.DataBind()
        ddJob.Items.Insert(0, New ListItem("--Select--", ""))
        FillJobComp(0)

    End Sub

    Protected Sub imgBtnCalcTotal_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgBtnCalcTotal.Click
        If Me.txtQty.Text <> "" And Me.txtQty.Text.Length > 0 And IsNumeric(Me.txtQty.Text) Then
            If Me.txtRate.Text <> "" And Me.txtRate.Text.Length > 0 And IsNumeric(Me.txtRate.Text) Then
                Me.txtAmount.Text = CType(CType(Me.txtQty.Text, Decimal) * CType(Me.txtRate.Text, Decimal), String).ToString
            End If
        End If
    End Sub
End Class