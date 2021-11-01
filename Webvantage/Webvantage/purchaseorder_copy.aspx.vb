Imports System.Data.SqlClient
Imports Webvantage.MiscFN
Imports Webvantage.cGlobals
Partial Public Class purchaseorder_copy
    Inherits Webvantage.BaseChildPage


    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Copy Purchase Order"
        If Not Page.IsPostBack Then
            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_PurchaseOrders)

            If Not Request.QueryString("ponumber") Is Nothing Then
                Purchaseorder_base_info1.PO_Number = AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("ponumber").Trim)
                Purchaseorder_base_info1.RetrievePOHeader()

                Me.RadDatePickerPODate.SelectedDate = cEmployee.TimeZoneToday
                Me.RadDatePickerPODue.SelectedDate = cEmployee.TimeZoneToday

            End If
            If Not Request.QueryString("callingpage") Is Nothing Then
                lbl_CallingPage.Text = Request.QueryString("callingpage")
            End If
            Dim PODtl As New wPurchaseOrder.cPurchaseOrder.cPurchaseOrderDetail(Session("ConnString"))
            Dim oValidations As New cValidations(Session("ConnString"))
            Dim sb1, sb2 As New System.Text.StringBuilder
            Dim ds As DataSet = New DataSet
            Dim message As String
            Dim newLine As String = "\n"
            ds = PODtl.GetPODtlInfo(Int32.Parse(AdvantageFramework.Security.Encryption.DecryptPO(Request.QueryString("ponumber").Trim)))
            sb1.Append("Warning")
            sb1.Append(newLine.ToString())

            For Each dr As DataRow In ds.Tables(0).Rows
                If dr.Item(0).ToString() <> "0" Then
                    If oValidations.ValidateJobIsOpen(dr.Item(0).ToString(), dr.Item(1).ToString()) = False Then
                        sb2.Append("Job Number: ")
                        sb2.Append(dr.Item(0).ToString())
                        sb2.Append(" , Job Component Number: ")
                        sb2.Append(dr.Item(1).ToString())
                        sb2.Append(" is Closed and will be removed from the line item ")
                        sb2.Append(dr.Item(3).ToString())
                        sb2.Append(".")
                        sb2.Append(newLine.ToString())
                    Else
                        If PODtl.CheckNonBilliableFlag(Convert.ToInt32(dr.Item(0)), Convert.ToInt32(dr.Item(1))) = True _
                                           And PODtl.CheckNonBilliableFNCFlag(dr.Item(2)) = True Then
                            sb2.Append("Job Number: ")
                            sb2.Append(dr.Item(0).ToString())
                            sb2.Append(" , Job Component Number: ")
                            sb2.Append(dr.Item(1).ToString())
                            sb2.Append(" and Function Code: (")
                            sb2.Append(dr.Item(2).ToString())
                            sb2.Append(") are marked Non Billable.")
                            sb2.Append(newLine.ToString())
                        End If
                        If PODtl.CheckNonBilliableFlag(Convert.ToInt32(dr.Item(0)), Convert.ToInt32(dr.Item(1))) = True _
                           And PODtl.CheckNonBilliableFNCFlag(dr.Item(2)) = False Then
                            sb2.Append("Job Number: ")
                            sb2.Append(dr.Item(0).ToString())
                            sb2.Append(" , Job Component Number: ")
                            sb2.Append(dr.Item(1).ToString())
                            sb2.Append(" are marked Non Billable.")
                            sb2.Append(newLine.ToString())
                        End If
                        If PODtl.CheckNonBilliableFlag(Convert.ToInt32(dr.Item(0)), Convert.ToInt32(dr.Item(1))) = False And
                            PODtl.CheckNonBilliableFNCFlag(dr.Item(2)) = True Then
                            sb2.Append("Function Code: (")
                            sb2.Append(dr.Item(2).ToString())
                            sb2.Append(") is marked Non Billable for Job Number: ")
                            sb2.Append(dr.Item(0))
                            sb2.Append(".")
                            sb2.Append(newLine.ToString())
                        End If
                    End If
                End If
            Next
            If sb2.ToString() <> "" Then
                message = sb1.ToString() & sb2.ToString
                Me.ShowMessage(message)
            End If
            Dim PO As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            If PO.GetPODoOwnSecurity(Session("UserCode")) = "Y" Then
                Me.ck_New_Emp_Code.Checked = False
                Me.ck_New_Emp_Code.Enabled = False
            End If
        End If
    End Sub

    Protected Sub btn_cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_cancel.Click
        Me.CloseThisWindow()
    End Sub

    Protected Sub btn_copy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_copy.Click
        CopyPurchaseOrder()
    End Sub
    Sub CopyPurchaseOrder()
        Dim ecode As String
        Dim copymemo As Int16
        Dim newponum As Integer
        Dim PODate As DateTime
        Dim DueDate As Object
        Dim sb1 As New System.Text.StringBuilder
        Dim session_user As String
        Dim porulecode As String
        Dim sec As New cSecurity(Session("ConnString"))

        Me.lbl_msg.Text = ""

        If Me.RadDatePickerPODate.DateInput.Text = "" Then
            lbl_msg.Text = "New PO Date is Required"
            Exit Sub
        End If
        If Me.RadDatePickerPODate.SelectedDate.HasValue = False Then
            lbl_msg.Text = "Invalid PO Date"
            Exit Sub
        End If

        If Me.RadDatePickerPODue.DateInput.Text <> "" And Me.RadDatePickerPODue.SelectedDate.HasValue = False Then
            Me.lbl_msg.Text = "Invalid PO Due Date"
            Exit Sub
        End If

        PODate = Globals.wvCDate(Me.RadDatePickerPODate.SelectedDate)

        If Not String.IsNullOrEmpty(Session("UserCode")) Then
            session_user = Session("UserCode")
        End If

        If ck_New_Emp_Code.Checked = True Then 'session empcode is used if item is checked.
            ecode = Session("Empcode")
        Else
            ecode = ""
        End If

        If ck_New_Emp_Code.Enabled = False Then
            ecode = Session("Empcode")
        End If

        If ck_Copy_Instruct.Checked = True Then
            copymemo = 1
        Else
            copymemo = 0
        End If

        If Me.RadDatePickerPODue.DateInput.Text = "" Then
            DueDate = System.DBNull.Value
        Else
            DueDate = cGlobals.wvCDate(Me.RadDatePickerPODue.SelectedDate)
        End If

        porulecode = Request.QueryString("rc")

        'copy
        Try
            Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))
            newponum = POHeader.Copy_PO(Purchaseorder_base_info1.PO_Number, session_user.Trim, PODate, DueDate, ecode, copymemo, porulecode)

            'go to new PO
            sb1.Append("purchaseorder.aspx?po_number=")

            sb1.Append(AdvantageFramework.Security.Encryption.EncryptPO(newponum.ToString()))
            sb1.Append("&pagemode=copy")
            If Me.CurrentQuerystring.IsJobDashboard = True Then
                MiscFN.ResponseRedirect(sb1.ToString, True)
            Else
                Me.CloseThisWindowAndRefreshCaller(sb1.ToString, True)
            End If
            'Server.Transfer(sb1.ToString())
        Catch ex As Exception
            Me.lbl_msg.Text = ex.Message.Trim
        Finally
            sb1 = Nothing
        End Try

    End Sub
End Class
