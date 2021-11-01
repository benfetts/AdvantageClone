Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Collections.Generic

Partial Public Class BillingApproval_Approval_Item_Detail
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Protected WithEvents DropMarkAllINSTR As Telerik.Web.UI.RadComboBox
    'Protected WithEvents ChkUpdateFunctionApprovedAmount As CheckBox
    Private BatchID As Integer = 0
    Private ApprovalID As Integer = 0
    Private DetailID As Integer = 0
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private FncCode As String = ""
    Private FncIndex As Integer = 0
    Private ItemExists As Boolean = False
    Private IsAB As Boolean = False
    Private _HasVersion As Boolean = False

    Public JSArray As String = ""

    Private ApprovalHeaderID As Integer = 0

    Private IsReadOnly As Boolean = False
    Private BillType As Integer = 0

    Private SUM_APPROVED_AMT As Decimal = CType(0.0, Decimal)
    Public counter As Integer = 0
    Public FunctionType As String = ""
    Private SUM_QTY_HRS As Decimal = CType(0.0, Decimal)
    Private SUM_NET As Decimal = CType(0.0, Decimal)
    Private SUM_MARKUP As Decimal = CType(0.0, Decimal)
    Private SUM_RESALE_TAX As Decimal = CType(0.0, Decimal)
    Private SUM_TOTAL_NR As Decimal = CType(0.0, Decimal) 'this is the vendor tax????
    Private SUM_TOTAL As Decimal = CType(0.0, Decimal)

#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister
    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Public ReadOnly Property MainDT() As DataTable
        Get
            Me.SetQSVariables()
            Try
                Dim o As Object = Session("BA_COMPONENT_DT")
                If o Is Nothing Then
                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim EmptyList As New List(Of cBillingApproval.BillingApprovalFunctionType)
                    Return ba.ApprovalDetailDatatable(Me.JobNumber, Me.JobComponentNbr, Me.ApprovalID, Me.BatchID, 0, "", EmptyList)
                Else
                    Return CType(Session("BA_COMPONENT_DT"), DataTable)
                End If
            Catch ex As Exception
            End Try
        End Get
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    'tooltip:
    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Me.SetQSVariables()
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Approval_JobComponent_Tooltip.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Approval_JobComponent_Tooltip = DirectCast(ctrl, BillingApproval_Approval_JobComponent_Tooltip)
        With t
            .iBatchID = Me.BatchID
            .iApprovalID = Me.ApprovalID
            .iJobNumber = Me.JobNumber
            .iJobComponentNbr = Me.JobComponentNbr
        End With
    End Sub

    'new tooltip:
    Protected Sub OnAjaxUpdate2(ByVal sender As Object, ByVal args As ToolTipUpdateEventArgs)
        Me.UpdateToolTip2(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip2(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Me.SetQSVariables()
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Approval_Item_Detail_Tooltip_VerDesc.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Approval_Item_Detail_Tooltip_VerDesc = DirectCast(ctrl, BillingApproval_Approval_Item_Detail_Tooltip_VerDesc)
        t.JobVerHdrId = CType(ArguementValue, Integer)

    End Sub

    Private Sub RadGridItemList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridItemList.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "ShowDoc"
                Dim i As Integer = -1
                Try
                    i = CType(e.CommandArgument, Integer)
                Catch ex As Exception
                    i = -1
                End Try

                If i > 0 Then
                    Me.DeliverFile(i)
                End If

        End Select
    End Sub
    Private Sub RadGridItemList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridItemList.ItemDataBound
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Or e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Then
            ''set the dropdownlist
            'Try
            '    Dim hf As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("TxtAPPROVED_AMT"), HiddenField)
            '    Dim ddl As Telerik.Web.UI.RadComboBox = CType(e.Item.FindControl("TxtAPPROVED_AMT"), Telerik.Web.UI.RadComboBox)
            'Catch ex As Exception

            'End Try
            Dim RowIsPO As Boolean = False
            'disable row if source is PO
            Try
                Dim hf As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfSOURCE"), HiddenField)
                If hf.Value.Trim() = "PO" Then
                    RowIsPO = True
                    'CType(e.Item.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).Enabled = False
                    Dim tb As System.Web.UI.WebControls.TextBox
                    'tb = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
                    'tb.Text = "0.00"
                    'tb.ReadOnly = True
                    'tb = CType(e.Item.FindControl("TxtAPPR_COMMENTS"), TextBox)
                    'tb.Text = ""
                    'tb.ReadOnly = True

                    Try 'Set Net amount to the total amount which from the function is column :"PO"
                        If CType(e.Item.FindControl("LblUNBILLED_NET"), Label).Text = "" Or CType(e.Item.FindControl("LblUNBILLED_NET"), Label).Text = "0.00" Then
                            CType(e.Item.FindControl("LblUNBILLED_NET"), Label).Text = CType(e.Item.FindControl("LblTOTAL"), Label).Text
                        End If
                    Catch ex As Exception
                    End Try

                    tb = CType(e.Item.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                    tb.Text = ""
                    tb.ReadOnly = True
                    Try
                        e.Item.Cells(4).Text = "PO:&nbsp;" & e.Item.Cells(4).Text
                    Catch ex As Exception
                    End Try
                    'Try
                    '    e.Item.Cells(4).Text = "PO:&nbsp;" & e.Item.DataItem("INV_NBR").ToString() & "-" & e.Item.DataItem("MAX_SEQ").ToString()
                    'Catch ex As Exception
                    'End Try
                    Try
                        'e.Item.Cells(6).Text = e.Item.DataItem("INV_NBR").ToString() & "-" & e.Item.DataItem("MAX_SEQ").ToString()
                        CType(e.Item.FindControl("LblINV_NBR"), Label).Text = e.Item.DataItem("INV_NBR").ToString() & "-" & e.Item.DataItem("SEQ_NBR").ToString()
                    Catch ex As Exception
                    End Try
                End If
            Catch ex As Exception
            End Try

            'bind instruction ddl:
            Me.BindBillingOptions(CType(e.Item.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox), RowIsPO)
            'Set selected index:
            Try
                MiscFN.RadComboBoxSetIndex(CType(e.Item.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox), e.Item.DataItem("INSTR"), False)
            Catch ex As Exception
            End Try

            Dim ApprovedAmountTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
            ''Try
            ''    If IsNumeric(e.Item.DataItem("INSTR")) = True AndAlso CType(e.Item.DataItem("INSTR"), Integer) <> 1 Then

            ''        ApprovedAmountTextbox.Text = "0.00"

            ''    End If

            ''Catch ex As Exception

            ''End Try

            'set function type:
            Try
                Dim hf1 As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfREC_TYPE"), HiddenField)
                Me.FunctionType = hf1.Value
            Catch ex As Exception
            End Try
            'set summing of approved amounts
            Try
                'tb.ReadOnly = False
                'tb.Enabled = True
                ApprovedAmountTextbox.Attributes.Add("onkeyup", "javascript:SumItUp();")
                ApprovedAmountTextbox.Attributes.Add("onblur", "javascript:SumItUp();")
                JSArray &= "myArray[" & counter.ToString() & "] = document.getElementById('" & ApprovedAmountTextbox.ClientID & "').value;" & Environment.NewLine
                counter += 1
                If IsNumeric(ApprovedAmountTextbox.Text) = True Then
                    SUM_APPROVED_AMT += CType(ApprovedAmountTextbox.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            Dim lb As System.Web.UI.WebControls.Label
            'set sum qty/hrs:
            Try
                lb = CType(e.Item.FindControl("LblQTY_HRS"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_QTY_HRS += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            'set sum net:
            Try
                lb = CType(e.Item.FindControl("LblUNBILLED_NET"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_NET += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            'set sum markup:
            Try
                lb = CType(e.Item.FindControl("LblUNBILLED_MU"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_MARKUP += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            'set sum resale tax:
            Try
                lb = CType(e.Item.FindControl("LblUNBILLED_TAX"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_RESALE_TAX += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            'set sum total:
            Try
                lb = CType(e.Item.FindControl("LblTOTAL"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_TOTAL += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
            'set sum vendor tax:
            Try
                lb = CType(e.Item.FindControl("LblVENDOR_TAX"), Label)
                If IsNumeric(lb.Text) = True Then
                    SUM_TOTAL_NR += CType(lb.Text, Decimal)
                End If
            Catch ex As Exception
            End Try


            'disable if ab or readonly:
            Try
                If Me.IsAB = True Or Me.IsReadOnly = True Then
                    Dim tb As System.Web.UI.WebControls.TextBox
                    tb = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
                    tb.ReadOnly = True
                    tb = CType(e.Item.FindControl("TxtAPPR_COMMENTS"), TextBox)
                    tb.ReadOnly = True
                    tb = CType(e.Item.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                    tb.ReadOnly = True
                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(e.Item.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox)
                    ddl.Enabled = False
                End If
            Catch ex As Exception
            End Try
            'disable if item is on another approval
            Try
                Dim ThisApprovalID As Integer = CType(e.Item.DataItem("BA_ID"), Integer)

                If ThisApprovalID > 0 AndAlso ThisApprovalID <> Me.ApprovalID Then
                    Dim tb As System.Web.UI.WebControls.TextBox
                    tb = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
                    tb.ReadOnly = True
                    tb = CType(e.Item.FindControl("TxtAPPR_COMMENTS"), TextBox)
                    tb.ReadOnly = True
                    tb = CType(e.Item.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                    tb.ReadOnly = True
                    Dim ddl As Telerik.Web.UI.RadComboBox = CType(e.Item.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox)
                    ddl.Enabled = False
                End If
            Catch ex As Exception
            End Try
            'disable if bill/reconcile or hold
            Try
                Dim hf As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfINSTR"), HiddenField)
                If hf.Value = "1" Or hf.Value = "4" Then
                    Dim tb As System.Web.UI.WebControls.TextBox
                    tb = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
                    tb.ReadOnly = True
                End If
            Catch ex As Exception
            End Try
            'make sure cell renders something:
            Try
                Dim lbl As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LblVERSION_ID"), Label)
                If lbl.Text.Trim() = "" Then
                    lbl.Text = "&nbsp;"
                End If
            Catch ex As Exception
            End Try
            'link to document:
            Try
                Dim HfDoc As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfHAS_AP_DOCUMENT"), HiddenField)
                Dim lbInvNum As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LblINV_NBR"), Label)
                Dim lbtnInvNum As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LbtnINV_NBR"), LinkButton)
                ''If HfDoc.Value = "True" Then
                ''    lbtnInvNum.Visible = True
                ''    lbInvNum.Visible = False
                ''    'Else
                ''    '    lbtnInvNum.Visible = False
                ''    '    lbInvNum.Visible = True
                ''End If
            Catch ex As Exception
            End Try

            Try

                If e.Item.DataItem("VERSION_ID").ToString().Length > 0 AndAlso _HasVersion = False Then

                    _HasVersion = True

                End If

            Catch ex As Exception

            End Try


        End If
        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Footer Then
            'set other totals:
            Try
                CType(e.Item.FindControl("LblSUM_QTY_HRS"), Label).Text = FormatNumber(SUM_QTY_HRS, 2, True, False, True)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("LblSUM_UNBILLED_NET"), Label).Text = FormatNumber(SUM_NET, 2, True, False, True)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("LblSUM_UNBILLED_MU"), Label).Text = FormatNumber(SUM_MARKUP, 2, True, False, True)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("LblSUM_UNBILLED_TAX"), Label).Text = FormatNumber(SUM_RESALE_TAX, 2, True, False, True)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("LblSUM_TOTAL"), Label).Text = FormatNumber(SUM_TOTAL, 2, True, False, True)
            Catch ex As Exception
            End Try
            Try
                CType(e.Item.FindControl("LblSUM_VENDOR_TAX"), Label).Text = FormatNumber(SUM_TOTAL_NR, 2, True, False, True)
            Catch ex As Exception
            End Try


            'set amount textbox total
            Dim tbSum As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("TxtSUM_APPROVED_AMT"), Label)
            With tbSum
                .Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, False)
            End With
            Select Case FunctionType
                Case "E"
                    'If MiscFN.ToolbarButtonToggleIsToggled(Me.RadToolbarBillingApproval, 10) = True Then
                    '    Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = True
                    '    Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = True
                    'Else
                    '    Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
                    '    Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
                    'End If
                    Me.RadGridItemList.MasterTableView.GetColumn("ColINV_NBR").Display = False
                Case "I"
                    Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
                    Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
                    Me.RadGridItemList.MasterTableView.GetColumn("ColINV_NBR").Display = True
                Case "V"
                    Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
                    Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
                    Me.RadGridItemList.MasterTableView.GetColumn("ColINV_NBR").Display = True
            End Select
            'disable if ab or readonly:
            Try
                If Me.IsAB = True Or Me.IsReadOnly = True Then
                    Dim tb As System.Web.UI.WebControls.Label
                    tb = CType(e.Item.FindControl("TxtSUM_APPROVED_AMT"), Label)
                End If
            Catch ex As Exception
            End Try

        End If

    End Sub
    Private Sub RadGridItemList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridItemList.NeedDataSource
        If Me.BatchID > 0 And Me.ApprovalID > 0 And Me.DetailID > 0 And Me.JobNumber > 0 And Me.JobComponentNbr > 0 And Me.FncCode <> "" Then
            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Me.RadGridItemList.DataSource = ba.ApprovalItemsGetTable(Me.BatchID, Me.ApprovalID, Me.DetailID, Me.JobNumber, Me.JobComponentNbr, Me.FncCode)
        End If
        Try
            If Me.HfGrouping.Value <> "" Then
                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse(Me.HfGrouping.Value.ToString().Trim())
                With Me.RadGridItemList
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                End With

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadToolbarBillingApproval_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApproval.ButtonClick
        Me.SetQSVariables()
        Dim RowCount As Integer = Me.RadGridItemList.MasterTableView.Items.Count
        Select Case e.Item.Value
            Case "ShowVersionColumns"
                Me.RadGridItemList.Rebind()
            Case "Save"
                Try
                    If RowCount > 0 Then

                        Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                        Dim NewTotal As Decimal = 0.0
                        Dim UnbilledNetTotal As Decimal = 0.0
                        Dim VendorTaxTotal As Decimal = 0.0
                        Dim ResaleTaxTotal As Decimal = 0.0
                        Dim MarkupTotal As Decimal = 0.0

                        For i As Integer = 0 To RowCount - 1

                            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridItemList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

                            Dim RowBaItemID As Integer = -1
                            Dim RowBaDtlID As Integer = Me.DetailID
                            Dim RowRecType As String = ""
                            Dim RowRecID As Integer = -1
                            Dim RowApprovedAmt As Decimal = 0.0
                            Dim RowApprovalComment As String = ""
                            Dim RowBillingInstruction As Integer = 0
                            Dim RowClientComment As String = ""
                            Dim RowApprovalID As Integer = -1
                            Dim RowIsPreviouslyApproved As Boolean = False
                            Dim RowUnbilledNet As Decimal = 0.0

                            Dim RowVendorTax As Decimal = 0.0
                            Dim RowResaleTax As Decimal = 0.0
                            Dim RowMarkup As Decimal = 0.0

                            Dim RowSource As String = ""
                            Dim RowIsPO As Boolean = False
                            Dim RowPONumber As Integer = 0
                            Dim RowPOLineNumber As Integer = 0

                            Dim RowRecordDetailID As Integer = 0

                            Try
                                Dim hf As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfSOURCE"), HiddenField)
                                If hf.Value.Trim = "PO" Then
                                    RowIsPO = True
                                Else
                                    RowIsPO = False
                                End If
                            Catch ex As Exception
                                RowIsPO = False
                            End Try

                            Try
                                RowBaItemID = CType(CType(CurrentGridRow.FindControl("HfBA_ITEM_ID"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                RowBaItemID = -1
                            End Try
                            Try
                                RowRecType = CType(CurrentGridRow.FindControl("HfREC_TYPE"), HiddenField).Value
                            Catch ex As Exception
                                RowRecType = ""
                            End Try
                            Try
                                RowRecID = CType(CType(CurrentGridRow.FindControl("HfREC_ID"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                RowRecID = -1
                            End Try
                            Try
                                RowApprovedAmt = CType(CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox).Text, Decimal)
                            Catch ex As Exception
                                RowApprovedAmt = 0.0
                            End Try

                            Try
                                'If CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).SelectedIndex = 1 Then 'this also determines total being saved and now whether or not to include PO
                                RowUnbilledNet = CType(CType(CurrentGridRow.FindControl("LblUNBILLED_NET"), Label).Text, Decimal)
                                'End If
                            Catch ex As Exception
                                RowUnbilledNet = 0.0
                            End Try
                            UnbilledNetTotal += RowUnbilledNet

                            Try
                                RowApprovalComment = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox).Text
                            Catch ex As Exception
                                RowApprovalComment = ""
                            End Try
                            Try
                                RowBillingInstruction = CType(CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).SelectedValue, Integer)
                            Catch ex As Exception
                                RowBillingInstruction = 0
                            End Try
                            Try
                                RowClientComment = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox).Text
                            Catch ex As Exception
                                RowClientComment = ""
                            End Try
                            Try
                                RowApprovalID = CType(CType(CurrentGridRow.FindControl("HfBAID"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                RowApprovalID = -1
                            End Try

                            Try
                                RowIsPreviouslyApproved = CType(CType(CurrentGridRow.FindControl("HfIS_PREVIOUSLY_APPROVED"), HiddenField).Value, Boolean)
                            Catch ex As Exception
                                RowIsPreviouslyApproved = False
                            End Try

                            'new tax stuff:
                            'only add to sum if bill/reconcile
                            Try
                                If CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).SelectedIndex = 1 Then
                                    RowVendorTax = CType(CType(CurrentGridRow.FindControl("LblVENDOR_TAX"), Label).Text.Trim(), Decimal)
                                End If
                            Catch ex As Exception
                                RowVendorTax = 0.0
                            End Try
                            VendorTaxTotal += RowVendorTax

                            Try
                                If CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).SelectedIndex = 1 Then
                                    RowResaleTax = CType(CType(CurrentGridRow.FindControl("UNBILLED_TAX"), Label).Text.Trim(), Decimal)
                                End If
                            Catch ex As Exception
                                RowResaleTax = 0.0
                            End Try
                            ResaleTaxTotal += RowResaleTax

                            Try
                                If CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox).SelectedIndex = 1 Then
                                    RowMarkup = CType(CType(CurrentGridRow.FindControl("LblUNBILLED_MU"), Label).Text.Trim(), Decimal)
                                End If
                            Catch ex As Exception
                                RowMarkup = 0.0
                            End Try
                            MarkupTotal += RowMarkup


                            Try
                                RowPONumber = CType(CType(CurrentGridRow.FindControl("HfINV_NBR"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                RowPONumber = 0
                            End Try

                            Try
                                RowPOLineNumber = CType(CType(CurrentGridRow.FindControl("HfMAX_SEQ"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                RowPOLineNumber = 0
                            End Try

                            Try
                                RowRecordDetailID = CType(CurrentGridRow.GetDataKeyValue("REC_DTL_ID"), Integer)
                            Catch ex As Exception
                                RowRecordDetailID = 0
                            End Try


                            If RowApprovalID = Me.ApprovalID Or RowApprovalID = -1 Then
                                If RowBaItemID > 0 Then 'it exists and is an update
                                    ba.ApprovalItemsUpdate(RowBaItemID, RowApprovedAmt, RowApprovalComment, RowBillingInstruction, RowClientComment, Me.ApprovalID, RowRecType, RowRecID, _
                                                           Me.JobNumber, Me.JobComponentNbr, Me.FncCode, RowIsPO, RowPONumber, RowPOLineNumber, RowRecordDetailID)
                                Else 'it doesn't exist and is an insert
                                    ba.ApprovalItemsInsert(RowBaDtlID, RowRecType, RowRecID, RowApprovedAmt, RowApprovalComment, RowBillingInstruction, RowClientComment, _
                                                           Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr, Me.FncCode, RowIsPO, RowPONumber, RowPOLineNumber, RowRecordDetailID)
                                End If
                                NewTotal += RowApprovedAmt
                            End If

                        Next
                        'update detail table total:
                        'If Me.ChkUpdateFunctionApprovedAmount.Checked = True Then
                        '    ba.ApprovalItemsUpdateDetailTotal(Me.DetailID, NewTotal)
                        'End If
                        '' ''Me.RadToolBarButtonUpdateFunctionApprovedAmount.Checked = True
                        '' ''If Me.RadToolBarButtonUpdateFunctionApprovedAmount.Checked = True Then

                        'ba.ApprovalItemsUpdateDetailTotal(Me.DetailID, NewTotal)
                        ba.ApprovalItemsUpdateDetailApprovalNetTotal(Me.DetailID, NewTotal)
                        'update tax and markup
                        'ba.ApprovalItemsUpdateDetailApprovalTaxesAndMarkup(Me.DetailID, ResaleTaxTotal, VendorTaxTotal, MarkupTotal)
                        '' ''End If
                        ba.SetApprStatus(Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr, -1)

                        ba.ApprovalDetail_CalculateAmounts(Me.DetailID)

                    End If

                    Me.CloseThisWindowAndRefreshCaller("BillingApproval_Approval_JobComponent.aspx", False, True)

                    Exit Sub

                Catch ex As Exception

                End Try
            Case "Close"
                Me.CloseThisWindow()
            Case "MarkAll"
                'need to loop through grid and set the data:
                Dim RunningTotal As Decimal = 0.0
                For i As Integer = 0 To Me.RadGridItemList.MasterTableView.Items.Count - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridItemList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim CurrentDDL As Telerik.Web.UI.RadComboBox = CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox)
                    Dim CurrenttbApprAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                    Dim CurrenttbApprComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox)
                    Dim CurrenttbClientComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                    Dim Currenthf As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfTotal"), HiddenField)
                    Dim CurrentHFPO As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfSOURCE"), HiddenField)
                    Dim CurrentApprovedNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfAPPROVED_AMT"), HiddenField)
                    Dim CurrentNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HiddenFieldUnbilledNet"), HiddenField)
                    Dim CurrentIsPreviouslyApproved As Boolean = False
                    Dim CurrentApprovalID As Integer = -1
                    Try
                        CurrentApprovalID = CType(CType(CurrentGridRow.FindControl("HfBAID"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        CurrentApprovalID = -1
                    End Try

                    'CurrentDDL.SelectedIndex = Me.DropMarkAllINSTR.SelectedIndex
                    'Try
                    '    CurrentIsPreviouslyApproved = CType(CType(CurrentGridRow.FindControl("HfIS_PREVIOUSLY_APPROVED"), HiddenField).Value, Boolean)
                    'Catch ex As Exception
                    '    CurrentIsPreviouslyApproved = False
                    'End Try
                    If CurrentApprovalID = -1 Or CurrentApprovalID = Me.ApprovalID Then
                        CurrentIsPreviouslyApproved = False
                    Else
                        CurrentIsPreviouslyApproved = True
                    End If

                    If CurrentIsPreviouslyApproved = False And CurrentHFPO.Value <> "PO" Then
                        MiscFN.RadComboBoxSetIndex(CurrentDDL, Me.DropMarkAllINSTR.SelectedValue, False)
                        Me.SetRowInstructionData(CurrentDDL, Currenthf, CurrenttbApprAmt, CurrenttbApprComment, CurrenttbClientComment, CurrentHFPO, CurrentNetHiddenField)
                    ElseIf CurrentIsPreviouslyApproved = False And CurrentHFPO.Value = "PO" Then 'if it is a po
                        If Me.DropMarkAllINSTR.SelectedIndex = 0 Or Me.DropMarkAllINSTR.SelectedIndex = 1 Then 'only allow "N/A" or bill/reconcile when it is a PO
                            MiscFN.RadComboBoxSetIndex(CurrentDDL, Me.DropMarkAllINSTR.SelectedValue, False)
                            Me.SetRowInstructionData(CurrentDDL, Currenthf, CurrenttbApprAmt, CurrenttbApprComment, CurrenttbClientComment, CurrentHFPO, CurrentNetHiddenField)
                        End If
                    End If
                    If IsNumeric(CurrenttbApprAmt.Text) = True Then
                        RunningTotal += CType(CurrenttbApprAmt.Text, Decimal)
                    End If
                Next
                Try
                    Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridItemList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
                    Dim tbSumTotal As System.Web.UI.WebControls.Label
                    tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), Label)
                    tbSumTotal.Text = FormatNumber(RunningTotal, 2, True, False, False)
                Catch ex As Exception
                End Try



            Case "MarkChecked"
                'need to loop through grid and set the data:
                Dim RunningTotal As Decimal = 0.0
                Dim HasACheckedRow As Boolean = False
                For i As Integer = 0 To Me.RadGridItemList.MasterTableView.Items.Count - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridItemList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

                    Dim RowChecked As CheckBox = CType(CurrentGridRow("ColumnClientSelect").Controls(0), CheckBox)
                    Dim CurrenttbApprAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)

                    If RowChecked.Checked = True Then
                        HasACheckedRow = True
                        Dim CurrentDDL As Telerik.Web.UI.RadComboBox = CType(CurrentGridRow.FindControl("DropINSTR"), Telerik.Web.UI.RadComboBox)
                        Dim CurrenttbApprComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox)
                        Dim CurrenttbClientComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                        Dim Currenthf As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfTotal"), HiddenField)
                        Dim CurrentHFPO As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfSOURCE"), HiddenField)
                        Dim CurrentApprovedNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfAPPROVED_AMT"), HiddenField)
                        Dim CurrentNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HiddenFieldUnbilledNet"), HiddenField)
                        Dim CurrentIsPreviouslyApproved As Boolean = False
                        Dim CurrentApprovalID As Integer = -1
                        Try
                            CurrentApprovalID = CType(CType(CurrentGridRow.FindControl("HfBAID"), HiddenField).Value, Integer)
                        Catch ex As Exception
                            CurrentApprovalID = -1
                        End Try

                        'CurrentDDL.SelectedIndex = Me.DropMarkAllINSTR.SelectedIndex
                        'Try
                        '    CurrentIsPreviouslyApproved = CType(CType(CurrentGridRow.FindControl("HfIS_PREVIOUSLY_APPROVED"), HiddenField).Value, Boolean)
                        'Catch ex As Exception
                        '    CurrentIsPreviouslyApproved = False
                        'End Try
                        If CurrentApprovalID = -1 Or CurrentApprovalID = Me.ApprovalID Then
                            CurrentIsPreviouslyApproved = False
                        Else
                            CurrentIsPreviouslyApproved = True
                        End If

                        If CurrentIsPreviouslyApproved = False And CurrentHFPO.Value <> "PO" Then 'go ahead and set it
                            MiscFN.RadComboBoxSetIndex(CurrentDDL, Me.DropMarkAllINSTR.SelectedValue, False)
                            Me.SetRowInstructionData(CurrentDDL, Currenthf, CurrenttbApprAmt, CurrenttbApprComment, CurrenttbClientComment, CurrentHFPO, CurrentNetHiddenField)
                        ElseIf CurrentIsPreviouslyApproved = False And CurrentHFPO.Value = "PO" Then 'if it is a po
                            If Me.DropMarkAllINSTR.SelectedIndex = 0 Or Me.DropMarkAllINSTR.SelectedIndex = 1 Then 'only allow "N/A" or bill/reconcile when it is a PO
                                MiscFN.RadComboBoxSetIndex(CurrentDDL, Me.DropMarkAllINSTR.SelectedValue, False)
                                Me.SetRowInstructionData(CurrentDDL, Currenthf, CurrenttbApprAmt, CurrenttbApprComment, CurrenttbClientComment, CurrentHFPO, CurrentNetHiddenField)
                            End If
                        End If
                    End If
                    If IsNumeric(CurrenttbApprAmt.Text) = True Then
                        RunningTotal += CType(CurrenttbApprAmt.Text, Decimal)
                    End If
                Next


                If HasACheckedRow = True Then
                    Try
                        Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridItemList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
                        Dim tbSumTotal As System.Web.UI.WebControls.Label
                        tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), Label)
                        tbSumTotal.Text = FormatNumber(RunningTotal, 2, True, False, False)
                    Catch ex As Exception
                    End Try
                End If


        End Select
    End Sub

    Public Sub DropINSTR_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast((DirectCast(sender, Control).NamingContainer), Telerik.Web.UI.GridDataItem)
        Dim CurrentDDL As Telerik.Web.UI.RadComboBox = CType(sender, Telerik.Web.UI.RadComboBox)
        Dim CurrenttbApprAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
        Dim CurrenttbApprComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox)
        Dim CurrenttbClientComment As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox)
        Dim Currenthf As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfTotal"), HiddenField)
        Dim CurrenthfSource As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfSOURCE"), HiddenField)
        Dim CurrentApprovedNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfAPPROVED_AMT"), HiddenField)
        Dim CurrentNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HiddenFieldUnbilledNet"), HiddenField)

        Me.SetRowInstructionData(CurrentDDL, Currenthf, CurrenttbApprAmt, CurrenttbApprComment, CurrenttbClientComment, CurrenthfSource, CurrentNetHiddenField)

    End Sub

#End Region
#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.DropMarkAllINSTR = CType(Me.RadToolBarTemplateButtonMarkInstruction.FindControl("DropMarkAllINSTR"), Telerik.Web.UI.RadComboBox)
        Me.DropMarkAllINSTR = CType(Me.RadToolbarBillingApproval.Items.FindItemByValue("MarkInstruction").FindControl("DropMarkAllINSTR"), Telerik.Web.UI.RadComboBox)

        Me.SetQSVariables()
        Me.RadToolbarButtonSave.Enabled = Not Me.IsAB
        Me.RadToolbarButtonSave.Enabled = Not Me.IsReadOnly
        If Me.IsAB = True Or Me.IsReadOnly = True Then
            Me.DropMarkAllINSTR.Enabled = False
        Else
            Me.DropMarkAllINSTR.Enabled = True
        End If

        Me.DropMarkAllINSTR.Enabled = Not Me.IsAB
        Me.DropMarkAllINSTR.Enabled = Not Me.IsReadOnly

        With Me.RadToolBarButtonUpdateFunctionApprovedAmount
            .Visible = False
            .Checked = True
        End With
        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try
                Me.LoadForm()
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private Sub BillingApproval_Approval_Item_Detail_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'only display version toggle for function type "E"
        If Me.FunctionType = "E" Then
            Me.RadToolbarToggleButtonShowVersionColumns.Enabled = True
        Else
            Me.RadToolbarToggleButtonShowVersionColumns.Enabled = False
        End If

        If Not Page.IsPostBack And Not Page.IsCallback Then
            'get setting from db:
            Dim baD As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim dt As New DataTable
            Dim ShowVersion As Boolean = False
            dt = baD.GetPageSetting(cBillingApproval.BA_Page.Unbilled_Function_Detail)
            ShowVersion = dt.Rows(0)("AGY_SETTINGS_VALUE")

            Me.RadToolbarToggleButtonShowVersionColumns.Checked = ShowVersion
        End If


        Dim AgySetting As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)
        If AgySetting.GetValue(AdvantageFramework.Agency.Settings.BA_VER_INFO, "") = "1" Then

            Me.RadToolbarToggleButtonShowVersionColumns.Visible = True
            'actually show/hide the version columns:
            If Me.RadToolbarToggleButtonShowVersionColumns.Checked = True And Me.FunctionType = "E" Then ' Show Version columns
                Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = True
                Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = True
            Else
                Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
                Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
            End If

        Else
            Me.RadToolbarToggleButtonShowVersionColumns.Visible = False
            Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
            Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
        End If

        If _HasVersion = False Then

            Me.RadGridItemList.MasterTableView.GetColumn("ColVERSION_ID").Display = False
            Me.RadGridItemList.MasterTableView.GetColumn("ColJOB_VER_DESC").Display = False
            Me.RadToolbarBillingApproval.FindItemByValue("ShowVersionColumns").Visible = False

        End If

        'disable all when no data
        If Me.RadGridItemList.MasterTableView.Items.Count = 0 Then
            Me.RadToolbarButtonSave.Enabled = False
            Me.RadToolBarButtonUpdateFunctionApprovedAmount.Enabled = False
            Me.RadToolbarToggleButtonShowVersionColumns.Enabled = False

            Me.DropMarkAllINSTR.Enabled = False

            Me.RadToolbarButtonMarkAll.Enabled = False
            Me.RadToolbarButtonMarkChecked.Enabled = False
        End If

    End Sub

#End Region

    Private Sub LoadForm()
        Me.LblFunction.Text = SetFunctionLabel()
        'wire up tooltip
        With Me.RadToolTipManager1.TargetControls
            .Clear()
            .Add(Me.LblInfo.ClientID, BatchID, True)
        End With
        Me.SetQSVariables()
        'If Me.BillType = 2 Or Me.BillType = 3 Then
        '    Me.RadToolBarButtonUpdateFunctionApprovedAmount.Checked = False
        'Else
        Me.RadToolBarButtonUpdateFunctionApprovedAmount.Checked = True
        'End If
    End Sub
    Private Sub SetQSVariables()
        Try
            If Not Request.QueryString("BAID") = Nothing Then
                Me.BatchID = CType(Request.QueryString("BAID"), Integer)
            End If
        Catch ex As Exception
            Me.BatchID = 0
        End Try
        Try
            If Not Request.QueryString("AID") = Nothing Then
                Me.ApprovalID = CType(Request.QueryString("AID"), Integer)
            End If
        Catch ex As Exception
            Me.ApprovalID = 0
        End Try
        Try
            If Not Request.QueryString("J") = Nothing Then
                Me.JobNumber = CType(Request.QueryString("J"), Integer)
            End If
        Catch ex As Exception
            Me.JobNumber = 0
        End Try
        Try
            If Not Request.QueryString("C") = Nothing Then
                Me.JobComponentNbr = CType(Request.QueryString("C"), Integer)
            End If
        Catch ex As Exception
            Me.JobComponentNbr = 0
        End Try

        Try
            If Not Request.QueryString("FN") = Nothing Then
                Me.FncCode = CType(Request.QueryString("FN"), String)
            End If
        Catch ex As Exception
            Me.FncCode = ""
        End Try

        Try
            If Not Request.QueryString("I") = Nothing Then
                Me.FncIndex = CType(Request.QueryString("I"), Integer)
            End If
        Catch ex As Exception
            Me.FncIndex = 0
        End Try

        Try
            If Not Request.QueryString("ex") = Nothing Then
                Me.ItemExists = CType(Request.QueryString("ex"), Boolean)
            End If
        Catch ex As Exception
            Me.ItemExists = False
        End Try

        Try
            If Not Request.QueryString("D") = Nothing Then
                Me.DetailID = CType(Request.QueryString("D"), Integer)
            End If
        Catch ex As Exception
            Me.DetailID = 0
        End Try

        'disable AB check issue 539:
        'Try
        '    If Not Request.QueryString("ab") = Nothing Then
        '        Me.IsAB = CType(Request.QueryString("ab"), Boolean)
        '    End If
        'Catch ex As Exception
        '    Me.IsAB = False
        'End Try

        Try
            If Not Request.QueryString("ro") = Nothing Then
                Me.IsReadOnly = CType(Request.QueryString("ro"), Boolean)
            End If
        Catch ex As Exception
            Me.IsReadOnly = False
        End Try

        If Me.IsReadOnly = False Then 'if showing detail level, also read only 
            Try
                If Not Request.QueryString("dt") = Nothing Then
                    Me.IsReadOnly = Not CType(Request.QueryString("dt"), Boolean)
                End If
            Catch ex As Exception
                Me.IsReadOnly = False
            End Try
        End If
        If Me.IsReadOnly = False Then 'if bill type = 1, also read only 
            Try
                If Not Request.QueryString("bt") = Nothing Then
                    Dim i As Integer = CType(Request.QueryString("bt"), Integer)
                    Me.BillType = i
                    If i = 1 Then
                        Me.IsReadOnly = True
                    End If
                End If
            Catch ex As Exception
                Me.IsReadOnly = False
            End Try
        End If


    End Sub
    Private Function SetFunctionLabel() As String
        Try
            If Me.FncCode <> "" Then
                If MainDT.Rows.Count > 0 Then
                    Dim str As String = Me.FncCode & " - "
                    Dim StrSQL As String = "SELECT FNC_DESCRIPTION FROM FUNCTIONS WITH(NOLOCK) WHERE FNC_CODE = '" & Me.FncCode.Trim() & "'"
                    Using MyConn As New SqlConnection(Session("ConnString"))
                        MyConn.Open()
                        Dim MyCmd As New SqlCommand(StrSQL, MyConn)
                        Try
                            str &= MyCmd.ExecuteScalar()
                        Catch ex As Exception
                        Finally
                            If MyConn.State = ConnectionState.Open Then MyConn.Close()
                        End Try
                    End Using
                    Return str
                End If
            End If
        Catch ex As Exception
            Return "Error getting function: " & ex.Message.ToString()
        End Try

        'Try
        '    If Me.FncCode <> "" Then

        '    End If
        '    If MainDT.Rows.Count > 0 Then
        '        Dim str As String

        '        'If IsDBNull(MainDT.Rows(Index)("FNC_CODE")) = False Then
        '        '    str = MainDT.Rows(Index)("FNC_CODE").ToString()
        '        'End If
        '        'If IsDBNull(MainDT.Rows(Index)("FNC_DESCRIPTION")) = False Then
        '        '    str &= " - " & MainDT.Rows(Index)("FNC_DESCRIPTION").ToString()
        '        'End If

        '        Return str
        '    End If
        'Catch ex As Exception
        '    Return "Error getting function: " & ex.Message.ToString()
        'End Try
    End Function
    Private Sub SetRowInstructionData(ByVal ThisDDL As Telerik.Web.UI.RadComboBox, ByVal hfTotal As System.Web.UI.WebControls.HiddenField, ByRef tbApprAmt As System.Web.UI.WebControls.TextBox, _
                                      ByRef tbApprComment As System.Web.UI.WebControls.TextBox, ByRef tbClientComment As System.Web.UI.WebControls.TextBox, ByVal hfSource As System.Web.UI.WebControls.HiddenField, _
                                      ByVal ApprovedNetHiddenField As System.Web.UI.WebControls.HiddenField)
        Dim IsPO As Boolean = False
        If hfSource.Value.Trim() = "PO" Then
            IsPO = True
        End If
        Select Case CType(ThisDDL.SelectedValue, Integer)
            Case 0 'NA (Default)
                'Do not mark item in detail table with BA ID
                'Upate Approved Amount for this item to 0.00 but don’t allow override.
                'Do not allow approval amount or comments at all.
                With tbApprAmt
                    .Text = "0.00"
                    .ReadOnly = True
                    '.Enabled = False
                End With
                With tbApprComment
                    .Text = ""
                    .ReadOnly = True
                End With
                With tbClientComment
                    .Text = ""
                    .ReadOnly = True
                End With
            Case 1 'Bill
                '' ''Update Approved Amount with Unbilled Total and allow override.
                '' ''Mark item in detail table with BA ID upon Save.
                ' ''Dim RowTotal As Decimal = 0.0
                ' ''If IsNumeric(hfTotal.Value) = True Then
                ' ''    RowTotal = CType(hfTotal.Value, Decimal)
                ' ''End If
                ' ''With tbApprAmt
                ' ''    .ReadOnly = True
                ' ''    '.Enabled = True
                ' ''    .Text = FormatNumber(RowTotal, 2, True, True, False)
                ' ''End With

                'Issue 3893/1/15, default in NET (which is already there, but re-apply)
                With tbApprAmt
                    .ReadOnly = True
                    If ApprovedNetHiddenField IsNot Nothing AndAlso IsNumeric(ApprovedNetHiddenField.Value) Then
                        .Text = FormatNumber(ApprovedNetHiddenField.Value, 2, True, True, False)
                    End If
                End With
                With tbApprComment
                    .ReadOnly = False
                End With
                With tbClientComment
                    .ReadOnly = IsPO
                End With
            Case 2 'Adjust
                'Update Approved Amount to 0.00 and allow override.
                'Mark item in detail table with BA ID
                With tbApprAmt
                    .Text = "0.00"
                    .ReadOnly = False
                    '.Enabled = True
                End With
                With tbApprComment
                    .ReadOnly = False
                End With
                With tbClientComment
                    .ReadOnly = False
                End With
            Case 3 'Transfer
                'Update Approved Amount to 0.00 and allow override.
                'Mark item in the detail table with BA ID
                With tbApprAmt
                    .Text = "0.00"
                    .ReadOnly = False
                    '.Enabled = True
                End With
                With tbApprComment
                    .ReadOnly = False
                End With
                With tbClientComment
                    .ReadOnly = False
                End With
            Case 4 'Hold
                'Force Approved Amount for this item to 0.00 and don’t allow override.
                'Default this to the current setting for the item on New, allow change. Once saved in table, use that value.  Need to have Ben add this to the SP.
                'Mark item in detail table with BA ID upon Save.
                With tbApprAmt
                    .Text = "0.00"
                    .ReadOnly = True
                    '.Enabled = False
                End With
        End Select
        Me.UpdateFooterTotal()
    End Sub
    Private Sub UpdateFooterTotal()
        'need to loop through grid and set the data:
        Dim RunningTotal As Decimal = 0.0
        For i As Integer = 0 To Me.RadGridItemList.MasterTableView.Items.Count - 1
            Try
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridItemList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim CurrenttbApprAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                If IsNumeric(CurrenttbApprAmt.Text) = True Then
                    RunningTotal += CType(CurrenttbApprAmt.Text, Decimal)
                End If
            Catch ex As Exception
            End Try
        Next
        Try
            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridItemList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
            Dim tbSumTotal As System.Web.UI.WebControls.Label
            tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), Label)
            tbSumTotal.Text = FormatNumber(RunningTotal, 2, True, False, False)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub UpdateNetAmount()
        For i As Integer = 0 To Me.RadGridItemList.MasterTableView.Items.Count - 1
            Try
            Catch ex As Exception
            End Try

        Next
    End Sub
    Private Sub BindBillingOptions(ByRef ddl As Telerik.Web.UI.RadComboBox, ByVal IsPo As Boolean)
        With ddl
            .Items.Clear()
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem("NA", "0"))
            .Items.Add(New Telerik.Web.UI.RadComboBoxItem("Bill/Reconcile", "1"))
            If IsPo = False Then
                .Items.Add(New Telerik.Web.UI.RadComboBoxItem("Adjust", "2"))
                .Items.Add(New Telerik.Web.UI.RadComboBoxItem("Transfer", "3"))
                .Items.Add(New Telerik.Web.UI.RadComboBoxItem("Hold", "4"))
            End If
        End With
    End Sub

#End Region

End Class
