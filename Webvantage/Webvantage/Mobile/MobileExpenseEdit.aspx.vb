
Imports System.Data.SqlClient
Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Drawing
Imports System.Web.Mobile


Partial Public Class MobileExpenseEdit
    Inherits MobileBase
    Public mStatus As ExpenseStatus
    Public mstatusCalc As ExpenseStatusCalculated

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Page.IsPostBack = False Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)
            If Request.QueryString("invoice") = "new" Then
                NewExpense()
            Else
                LoadExpense(CInt(Request.QueryString("invoice")))
            End If
        End If

        'MiscFN.SetToolbarButtonClientClick(Me.RadToolbarExpenseEdit, 4, String.Format("realPostBack('{0}', ''); return false;", RadToolbarButtonDelete.UniqueID))
        'MiscFN.SetToolbarButtonClientClick(Me.RadToolbarExpenseEdit, 9, "Javascript:window.open('expense_print.aspx?invoice=" & Me.lblExpRptNbr.Text & "','','screenX=150,left=150,screenY=150,top=150,width=800,height=450,scrollbars=yes,resizable=yes,menubar=no,maximazable=no');return false;")

    End Sub
    Private Sub NewExpense()
        Dim oEMp As cEmployee = New cEmployee(CStr(Session("ConnString")))
        Me.lblEmployee.Text = Request.QueryString("empcode")
        ' Me.lblEmpName.Text = oEMp.GetName(Request.QueryString("empcode"))
        ' Me.lblStatus.Text = "New"
        Me.lblReportNum.Text = ""
        Me.txtReportDate.Text = Date.Today.ToShortDateString
        Me.lbSave.Visible = True
        Me.lbSave.Enabled = True
        SetTotals(0)
    End Sub

    Private Sub LoadExpense(ByVal Invoice As Integer)
        Dim ThisExpenseHeader As ExpenseHeader
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
        Dim lineItems As Integer

        lineItems = oExpense.GetExpenseLineItemCount(CStr(Invoice))

        ThisExpenseHeader = oExpense.GetExpenseHeader(Invoice, False)

        If oTS.UserLimited(Session("UserCode")) = True Then
            If Session("EmpCode") <> ThisExpenseHeader.EMP_CODE Then
                Exit Sub
            End If
        End If
        Me.lblReportNum.Text = ThisExpenseHeader.INV_NBR
        Me.lblEmployee.Text = ThisExpenseHeader.EMP_CODE '+ " " + ThisExpenseHeader.EmployeeName
        'Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE
        'Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
        'Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC


        'Me.lblStatus.Text = ThisExpenseHeader.STATUS.ToString
        'Me.lblVendorCode.Text = ThisExpenseHeader.VN_CODE
        Me.txtDetail.Visible = False
        'Me.txtdetaildesc.Visible = False
        'Me.lbldetaildesc.Visible = False
        Me.txtDescription.Visible = False
        'Me.txtEXPDescription.Visible = False
        'Me.lblEXPDescription.Visible = False
        'Me.lblInvDate.Visible = False
        'Me.txtInvDate.Visible = False
        Me.txtReportDate.Visible = False

        mStatus = ThisExpenseHeader.STATUS
        mstatusCalc = ThisExpenseHeader.STATUS_CALC

        Select Case mstatusCalc
            Case 0  'ExpenseStatus.Open
                Me.txtDetail.Visible = True
                'Me.txtdetaildesc.Visible = True
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Visible = True
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Visible = True
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE
                'Add New Item MiscFN.SetToolbarButtonEnabled(Me.RadToolbarExpenseEdit, 1, True)
                'Save 2
                'Delete MiscFN.SetToolbarButtonEnabled(Me.RadToolbarExpenseEdit, 3, True)
                'Submit MiscFN.SetToolbarButtonEnabled(Me.RadToolbarExpenseEdit, 4, True)
                'Un Submit 5
                'Print MiscFN.SetToolbarButtonEnabled(Me.RadToolbarExpenseEdit, 6, Me.IsVendorAssociated)
                'Cancel MiscFN.SetToolbarButtonVisible(Me.RadToolbarExpenseEdit, 7, False)
                Me.lbAddItem.Enabled = True
                Me.lbAddItem.Visible = True

                Me.lbSave.Visible = True
                Me.lbSave.Enabled = True

                If lineItems > 0 Then
                    Me.lbSubmit.Visible = True
                    Me.lbSubmit.Enabled = True
                Else
                    Me.lbSubmit.Visible = False
                    Me.lbSubmit.Enabled = False
                End If

                Me.lbDeleteItem.Visible = True
                Me.lbDeleteItem.Enabled = True
                Me.lbUnSubmit.Visible = False

            Case 1, 3, 4   'Pending/Denied   'ExpenseStatus.Pending
                Me.txtDetail.Visible = True
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Visible = True
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Visible = True
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE

                txtDescription.Enabled = False
                txtDetail.Enabled = False
                txtReportDate.Enabled = False

                Me.lbAddItem.Enabled = False
                Me.lbAddItem.Visible = False

                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbSubmit.Visible = False
                Me.lbSubmit.Enabled = False

                Me.lbUnSubmit.Visible = True
                Me.lbUnSubmit.Enabled = True

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False


            Case 2, 5, 6    'Approved/Approved by Supervisor/Approved by Accounting  /////ExpenseStatus.Approved
                Me.txtDetail.Visible = True
                Me.txtDetail.Text = ThisExpenseHeader.DTL_DESC
                Me.txtDescription.Visible = True
                Me.txtDescription.Text = ThisExpenseHeader.EXP_DESC
                Me.txtReportDate.Visible = True
                Me.txtReportDate.Text = ThisExpenseHeader.INV_DATE
                Me.lbAddItem.Enabled = False
                Me.lbAddItem.Visible = False

                txtDescription.Enabled = False
                txtDetail.Enabled = False
                txtReportDate.Enabled = False


                Me.lbSave.Visible = False
                Me.lbSave.Enabled = False

                Me.lbSubmit.Visible = False
                Me.lbSubmit.Enabled = False

                Me.lbUnSubmit.Visible = False
                Me.lbUnSubmit.Enabled = False

                Me.lbDeleteItem.Visible = False
                Me.lbDeleteItem.Enabled = False

        End Select
        Me.ddItems.DataSource = ThisExpenseHeader.ExpenseDetails
        Me.ddItems.DataTextField = "ITEM_DESC"
        Me.ddItems.DataValueField = "LINE_NBR"

        Me.ddItems.DataBind()
        If ddItems.Items.Count > 0 Then
            ddItems.Enabled = True
            Me.lbViewItem.Enabled = True
        Else
            ddItems.Enabled = False
            Me.lbViewItem.Enabled = False
        End If
        'Me.rpExpenseDetail.DataSource = ThisExpenseHeader.ExpenseDetails
        'Me.rpExpenseDetail.DataBind()

        SetTotals(Invoice)
    End Sub
    Private Sub SetTotals(ByVal Invoice As Integer)

        If Invoice > 0 Then
            Dim oExpense As cExpense = New cExpense(Session("ConnString"))
            Dim dr As SqlDataReader
            Dim str As String
            Dim nbr As Decimal
            dr = oExpense.GetExpenseTotals(Invoice)

            If dr.HasRows Then
                Do While dr.Read
                    'Me.lblTotalExpense.Text = CStr(dr("EXPENSE_AMOUNT"))
                    nbr = dr("EXPENSE_AMOUNT")
                    Me.lblTotalExpense.Text = nbr.ToString("#,##0.00")

                    'Me.lblCreditCard.Text = CStr(dr("CC_AMT_TOTAL"))
                    nbr = dr("CC_AMT_TOTAL")
                    Me.lblLessCreditCard.Text = nbr.ToString("#,##0.00")

                    'Me.lblTotalDue.Text = CStr(dr("TOTAL_EXPENSE"))
                    nbr = dr("TOTAL_EXPENSE")
                    Me.lblTotalDue.Text = nbr.ToString("#,##0.00")
                Loop
            End If

            dr.Close()
            dr = Nothing
        Else
            Me.lblTotalExpense.Text = "0.00"
            Me.lblLessCreditCard.Text = "0.00"
            Me.lblTotalDue.Text = "0.00"
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

    Private Sub Submit_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                'Me.ShowMessage("Expense report has already been approved and cannot be modified.")
                Me.lblMessage.Text = "Expense report has already been approved."
                Me.lblMessage.ForeColor = Color.Red
                LoadExpense(CType(Me.lblReportNum.Text.Trim, Integer))
                Exit Sub
            End If
        End If
        Dim llOK2Submit As Boolean

        '''Me.but_Save_Click(New System.Object, New System.EventArgs)
        Save_Click()

        If Session("lcSavedOK") = "Yes" Or Session("lcSavedOK") = Nothing Then
            llOK2Submit = True
        ElseIf Session("lcSavedOK") = "No" Then
            llOK2Submit = False
        End If

        If llOK2Submit Then
            Dim oExpense As cExpense = New cExpense(Session("ConnString"))
            Dim blnReturn As Boolean

            'blnReturn = oExpense.UpdateStatus(Me.lblReportNum.Text.Trim, ExpenseStatus.Pending)
            If oExpense.SuperApprovalNeeded(Session("EmpCode")) = True Then
                blnReturn = oExpense.UpdateStatus(Me.lblReportNum.Text.Trim, ExpenseStatus.Pending, 1, 0)
            Else
                blnReturn = oExpense.UpdateStatus(Me.lblReportNum.Text.Trim, ExpenseStatus.Pending, 0, 0)
            End If

            oExpense.InsertCreditLine(CInt(Me.lblReportNum.Text))
            LoadExpense(CInt(Me.lblReportNum.Text))
        Else
            '            wvMsgBox("You must save your changes before Submitting the Expense Sheet.")
            lblMessage.Text = "You must save your changes first."
            lblMessage.ForeColor = Color.Red
        End If

    End Sub
    Private Sub Save_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                Me.lblMessage.Text = "Expense report has already been approved."
                Me.lblMessage.ForeColor = Color.Red
                LoadExpense(CType(Me.lblReportNum.Text.Trim, Integer))
                Exit Sub
            End If
        End If

        Dim oExpenseHdr As ExpenseHeader
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim ThisExpenseDetail As ExpenseDetail


        If Me.txtReportDate.Text = "" Then
            Me.lblMessage.Text = "Please enter a report date."
            Me.lblMessage.ForeColor = Color.Red
            Session("lcSavedOK") = "No"
            Exit Sub
        End If
        If Webvantage.cGlobals.wvIsDate(Me.txtReportDate.Text) = False Then
            'Me.ShowMessage("Please enter a valid date.")
            Me.lblMessage.Text = "Please enter a valid report date."
            Me.lblMessage.ForeColor = Color.Red
            Session("lcSavedOK") = "No"
            Exit Sub
        End If

        Session("lcSavedOK") = "Yes"

        If Me.txtDescription.Text.Trim = "" Then
            Me.lblMessage.Text = "Description Required."
            Me.lblMessage.ForeColor = Color.Red
            Session("lcSavedOK") = "No"
            Exit Sub
        End If


        If IsNumeric(Me.lblReportNum.Text) = False Then
            'New 
            oExpenseHdr = New ExpenseHeader
            oExpenseHdr.EXP_DESC = Me.txtDescription.Text.Trim
            oExpenseHdr.DTL_DESC = Me.txtDetail.Text.Trim
            oExpenseHdr.EMP_CODE = Me.lblEmployee.Text.Trim
            oExpenseHdr.INV_DATE = wvCDate(Me.txtReportDate.Text)
            Try
                Me.lblReportNum.Text = oExpense.InsertExpenseHeader(oExpenseHdr).ToString
            Catch ex As Exception
                'wvMsgBox("Error: " & Err.Description)
                lblMessage.Text = "Error: " & Err.Description
                Exit Sub
            End Try
        Else
            'Update
            oExpenseHdr = New ExpenseHeader
            oExpenseHdr.INV_NBR = Me.lblReportNum.Text.Trim
            oExpenseHdr.INV_DATE = wvCDate(Me.txtReportDate.Text)
            oExpenseHdr.EXP_DESC = Me.txtDescription.Text.Trim
            oExpenseHdr.DTL_DESC = Me.txtDetail.Text.Trim
            Try
                If oExpense.UpdateExpenseHeader(oExpenseHdr) = False Then
                    ' Me.ShowMessage("Save failed.")
                    lblMessage.Text = "Save failed."
                    lblMessage.ForeColor = Color.Red
                    Exit Sub
                Else
                    lblMessage.Text = "Report Saved"
                    lblMessage.ForeColor = Color.Blue
                End If
            Catch ex As Exception
                'Me.ShowMessage("Error: " & Err.Description)
                lblMessage.Text = "Error: " & Err.Description
            End Try
        End If


        LoadExpense(CInt(Me.lblReportNum.Text))

    End Sub
    Private Sub UnSubmit_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                Me.lblMessage.Text = "Expense report has already been approved."
                Me.lblMessage.ForeColor = Color.Red
                LoadExpense(CType(Me.lblReportNum.Text.Trim, Integer))
                Exit Sub
            End If
        End If
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim blnReturn As Boolean

        blnReturn = oExpense.UpdateStatus(Me.lblReportNum.Text.Trim, ExpenseStatus.Open, 0, 0)

        oExpense.DeleteCreditLine(CInt(Me.lblReportNum.Text))

        LoadExpense(CInt(Me.lblReportNum.Text))
    End Sub
    Private Sub Delete_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                Me.lblMessage.Text = "Expense report has already been approved."
                Me.lblMessage.ForeColor = Color.Red
                LoadExpense(CType(Me.lblReportNum.Text.Trim, Integer))
                Exit Sub
            End If
        End If
        Dim oExpense As cExpense = New cExpense(Session("ConnString"))
        Dim ThisDate As Date

        If mStatus = ExpenseStatus.Open Then
            If oExpense.DeleteExpenseHeader(Me.lblReportNum.Text.Trim) = False Then
                ' Me.ShowMessage("Could not delete Expense Report")
                lblMessage.Text = "Could not delete"
                lblMessage.ForeColor = Color.Red
            Else
                'but_Cancel_Click("delete", System.EventArgs.Empty)
                MiscFN.ResponseRedirect("~/Mobile/MobileExpenseMain.aspx")
            End If
        Else
            'Me.ShowMessage("Can only delete open Expense Reports")
            lblMessage.Text = "Can only delete open Expense Reports"
            lblMessage.ForeColor = Color.Red
        End If

    End Sub
    Private Sub AddNew_Click()
        If IsNumeric(Me.lblReportNum.Text) Then
            If IsApproved(CType(Me.lblReportNum.Text.Trim, Integer)) = True Then
                Me.lblMessage.Text = "Expense report has already been approved."
                Me.lblMessage.ForeColor = Color.Red
                LoadExpense(CType(Me.lblReportNum.Text.Trim, Integer))
                Exit Sub
            End If
        End If
        MiscFN.ResponseRedirect("~/Mobile/MobileExpenseItemEdit.aspx?invoice=" & Me.lblReportNum.Text & "&ItemNumber=new")
        'Goto the MobileExpenseItemEdit/Add page.
    End Sub
    Private Sub lbBack_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnBack.Click
        MiscFN.ResponseRedirect("~/mobile/MobileExpenseMain.aspx")
    End Sub

    Private Sub lbLogout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLogout.Click
        Me.SignOut()
    End Sub

    Private Sub lbSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSave.Click
        Save_Click()
    End Sub

    Private Sub lbSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSubmit.Click
        Submit_Click()
    End Sub


    Private Sub lbUnSubmit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbUnSubmit.Click
        UnSubmit_Click()
    End Sub

    Private Sub lbViewItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbViewItem.Click
        MiscFN.ResponseRedirect("~/Mobile/MobileExpenseItemEdit.aspx?invoice=" & Me.lblReportNum.Text & "&ItemNumber=" & Me.ddItems.SelectedIndex.ToString())
    End Sub

    Private Sub lbDeleteItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbDeleteItem.Click
        Delete_Click()
    End Sub

    Private Sub lbAddItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbAddItem.Click
        AddNew_Click()
    End Sub
End Class