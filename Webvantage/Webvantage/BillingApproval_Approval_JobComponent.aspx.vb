Imports System.Data
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports Telerik.Web.UI
Imports System.Collections.Generic
Imports System.Linq

'Bill Types:
'0 - Progress Bill
'1 - Bill Hold
'2 - AB to Quote
'3 - AB Manual

Partial Public Class BillingApproval_Approval_JobComponent
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

#Region " General variables "

    'These should never change:
    Private BatchID As Integer = 0
    Private ApprovalID As Integer = 0
    Private JobNumber As Integer = 0
    Private JobComponentNbr As Integer = 0
    Private ShowRateDetails As Boolean = False

    Private ApprovalHeaderID As Integer = 0

    Public JSArray As String = ""
    Public JSArrayNet As String = ""
    Public JSArrayMarkupAmt As String = ""
    Public JSArrayTaxAmt As String = ""

    Private ShowDetailLevel As Boolean = True
    Private ShowQtyRateColumns As Boolean = False

    Private IsAdvancedBilling As Boolean = False
    Private BillType As Integer = 0
    Private BillHold As Integer = 0

    Private IsAdjusted As Boolean = False

    Private HasQuantityRate As Boolean = False
    Private IsReadOnly As Boolean = False

    Public CanDelete As Integer = 1

    Private ApplyTaxUponBilling As Boolean = False

#End Region
#Region " Variables for sums "

    'Total totals:
    Private SUM_QUOTE_AMT As Decimal = CType(0.0, Decimal)
    Private SUM_ACTUALS_AMT As Decimal = CType(0.0, Decimal)
    Private SUM_BILLED_REC As Decimal = CType(0.0, Decimal)
    Private SUM_BILL_HOLD As Decimal = CType(0.0, Decimal)
    Private SUM_NON_BILL_FEE As Decimal = CType(0.0, Decimal)
    Private SUM_UNBILLED As Decimal = CType(0.0, Decimal)
    Private SUM_OPEN_PO As Decimal = CType(0.0, Decimal)
    Private SUM_APPR_NET As Decimal = CType(0.0, Decimal)
    Private SUM_QUOTE_NET As Decimal = CType(0.0, Decimal)

    Private SUM_MARKUP_AMT As Decimal = CType(0.0, Decimal)
    Private SUM_TAX_AMT As Decimal = CType(0.0, Decimal)

    Private SUM_QUOTE_QTY_HRS As Decimal = CType(0.0, Decimal)
    Private SUM_ACTUAL_QTY_HRS As Decimal = CType(0.0, Decimal)

    Private SUM_APPROVED_AMT As Decimal = CType(0.0, Decimal)
    Private SUM_EXTENDED_AMT As Decimal = CType(0.0, Decimal)

    Private SUM_TEMP_CUTOFF_APPROVED_AMT As Decimal = CType(0.0, Decimal)

    '''Employee type totals:
    ''Private SUM_EMP_QUOTE_AMT As Decimal = 0.0
    ''Private SUM_EMP_BILLED_REC As Decimal = 0.0
    ''Private SUM_EMP_BILL_HOLD As Decimal = 0.0
    ''Private SUM_EMP_NON_BILL_FEE As Decimal = 0.0
    ''Private SUM_EMP_UNBILLED As Decimal = 0.0
    ''Private SUM_EMP_OPEN_PO As Decimal = 0.0
    '''Vendor type totals:
    ''Private SUM_VEN_QUOTE_AMT As Decimal = 0.0
    ''Private SUM_VEN_BILLED_REC As Decimal = 0.0
    ''Private SUM_VEN_BILL_HOLD As Decimal = 0.0
    ''Private SUM_VEN_NON_BILL_FEE As Decimal = 0.0
    ''Private SUM_VEN_UNBILLED As Decimal = 0.0
    ''Private SUM_VEN_OPEN_PO As Decimal = 0.0
    '''Income Only totals:
    ''Private SUM_IO_QUOTE_AMT As Decimal = 0.0
    ''Private SUM_IO_BILLED_REC As Decimal = 0.0
    ''Private SUM_IO_BILL_HOLD As Decimal = 0.0
    ''Private SUM_IO_NON_BILL_FEE As Decimal = 0.0
    ''Private SUM_IO_UNBILLED As Decimal = 0.0
    ''Private SUM_IO_OPEN_PO As Decimal = 0.0

#End Region

    Private AutoSaveHappened As Boolean = False
    Protected WithEvents LblStatus As System.Web.UI.WebControls.Label
    Protected WithEvents LabelJobCount As System.Web.UI.WebControls.Label
    Public counter As Integer = 0
    'cell index is off by 2 due to row select and expand columns which are visible = false!
    Private index As Integer = 0
    Private CurrRecType As String = ""
    Private CellStartIndex As Integer = 0
    Private _HasUserAddedDeletableRow As Boolean = False

#End Region

#Region " Properties "

    Private Function GetFunctionTypesFromCheckboxList() As List(Of cBillingApproval.BillingApprovalFunctionType)

        Dim FilterFunctionTypes As New List(Of cBillingApproval.BillingApprovalFunctionType)

        Try

            For Each item As ListItem In Me.CheckBoxListApproveThroughTypes.Items
                If item.Selected = True Then

                    FilterFunctionTypes.Add(CType(item.Value, cBillingApproval.BillingApprovalFunctionType))

                End If
            Next

        Catch ex As Exception

        End Try

        Return FilterFunctionTypes

    End Function

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
    Public Property MainDT() As DataTable
        Get
            Me.SetBAJC()
            Try
                Dim o As Object = Session("BA_COMPONENT_DT")
                If o Is Nothing Then
                    Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    Dim FilterDateString As String = ""
                    Try
                        If Me.RadDatePickerApproveThroughDate.SelectedDate.HasValue = True Then
                            FilterDateString = CType(Me.RadDatePickerApproveThroughDate.SelectedDate, Date).ToShortDateString()
                        End If
                    Catch ex As Exception
                        FilterDateString = ""
                    End Try
                    Return ba.ApprovalDetailDatatable(Me.JobNumber, Me.JobComponentNbr, Me.ApprovalID, Me.BatchID, Me.DropGroupBy.SelectedIndex,
                                                      FilterDateString, GetFunctionTypesFromCheckboxList())
                Else
                    Return CType(Session("BA_COMPONENT_DT"), DataTable)
                End If
            Catch ex As Exception
            End Try
        End Get
        Set(ByVal value As DataTable)
            Session("BA_COMPONENT_DT") = value
        End Set
    End Property
    Public Property CollapsedHeaders() As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
        Get
            If IsNothing(Session.Item("BAJCCGH")) Then
                Session.Item("BAJCCGH") = New AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
            End If
            Return Session.Item("BAJCCGH")
        End Get
        Set(ByVal value As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection)
            Session.Item("BAJCCGH") = value
        End Set
    End Property

#End Region

#Region " Page Events "

    Private Sub BillingApproval_Approval_JobComponent_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender

        If IsNothing(Session.Item("BAJCCGH")) = False Then

            Dim groupHeaders As List(Of GridItem) = Me.RadGridComponentList.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()
            Dim expanded As List(Of GridItem) = (From g In groupHeaders
                                                 Where g.Expanded
                                                 Select g).ToList()


            For Each expandedItem As GridItem In expanded

                If Me.CollapsedHeaders.GroupCaptions.Contains(expandedItem.Cells(1).Text) Then

                    expandedItem.Expanded = False

                End If

            Next

        End If

    End Sub
    Private Sub BillingApproval_Approval_JobComponent_Init(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApproval)

        Me.SetBAJC()

        Me.MyUnityContextMenu.JobNumber = Me.JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = Me.JobComponentNbr

        Me.LblStatus = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("RadToolBarButtonLblStatus").FindControl("LblStatus"), Label)
        Me.LabelJobCount = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("RadToolBarButtonLabelJob").FindControl("LabelJob"), Label)

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
            Try

                Session("BA_COMPONENT_DT") = Nothing

                Dim str As String = Session("BA_APPROVAL_DETAIL_JOB_LIST").ToString()
                If str.Length > 0 Then
                    Dim arJobAndComps() As String
                    arJobAndComps = str.Split("|")
                    If arJobAndComps.Length > 0 Then
                        Dim arJC() As String
                        For i As Integer = 0 To arJobAndComps.Length - 1
                            arJC = arJobAndComps(i).ToString().Split(",")
                            If arJC.Length = 2 Then
                                If IsNumeric(arJC(0)) = True And IsNumeric(arJC(1)) = True Then
                                    If CType(arJC(0), Integer) = Me.JobNumber And CType(arJC(1), Integer) = Me.JobComponentNbr Then
                                        Me.LabelJobCount.Text = i + 1 & " of " & arJobAndComps.Length.ToString & " Job(s)"
                                    End If
                                End If
                            End If
                        Next
                    End If
                End If

                'page defaults:
                Try
                    If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
                        'get page settings
                        Dim baD As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                        Dim dt As New DataTable
                        dt = baD.GetPageSetting(cBillingApproval.BA_Page.Billing_Approval_Job_Component)
                        For i As Integer = 0 To dt.Rows.Count - 1
                            Select Case dt.Rows(i)("AGY_SETTINGS_CODE").ToString()
                                Case "BA_RATE_DETAILS"
                                    CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
                                    Me.SetRateQtyColumns()
                                Case "BA_APPR_INFO_SECT"
                                    Me.CollapsablePanelApprovalInfo.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
                                Case "BA_CMNT_SECT"
                                    Me.CollapsablePanelComments.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
                                Case "BA_DTLS_SECT"
                                    Me.CollapsablePanelDetails.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
                                    'Case "BA_DTLS_OPT"
                                    '    Me.ChkHideColumnsDetails.Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
                                    'Case "BA_CMNT_OPT"
                                    '    Me.ChkHideColumnsComments.Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
                            End Select
                        Next
                    End If
                Catch ex As Exception
                End Try

                Me.LoadUserSettings()

            Catch ex As Exception
            End Try
        End If

        'This has to be called on every load
        If AdvantageFramework.Web.Presentation.Controls.CheckUserColumns(Session("Connstring"), "RadGridComponentList", _Session.UserCode) = 0 Then

            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColQUANTITY", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColRATE", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColAPPR_MARKUP_PCT", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColAPPR_MARKUP_AMT", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColAPPR_TAX_CODE", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColAPPR_TAX_AMT", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColNON_BILL_FEE", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColBILL_HOLD", False)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColOPEN_PO", False)

            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "colAPPR_COMMENTS", True)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "colCLIENT_COMMENTS", True)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColNET_QUOTE_UNBILLED_AMT", True)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "ColAPPROVED_AMT", True)
            AdvantageFramework.Web.Presentation.Controls.SaveColumnUserSetting(_Session.ConnectionString, _Session.UserCode, "RadGridComponentList", "colQUOTE_NET", False)

            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridComponentList)
        Else
            AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(RadGridComponentList)
        End If

    End Sub
    Protected Sub BillingApproval_Approval_JobComponent_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
        Me.SetRateQtyColumns()

        If Me.ShowDetailLevel = True Then
            Me.TxtApprovalAmount.ReadOnly = True
        End If

        Dim ba As New cBillingApproval()
        Me.AutoSaveHappened = ba.AutoSave(Me.BatchID, Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr)

        If Not Me.IsPostBack = True And Not Me.IsCallback = True Then

            Me.FocusControl(Me.TxtCommentsApproval)
            Me.RbAdvanceBillYes.Attributes.Add("onclick", "showAB();")
            Me.RbAdvancedBillNo.Attributes.Add("onclick", "hideAB();")
            Me.SetHeader()
            Me.DropGroupBy.SelectedIndex = 1
            Me.SetGrouping()

        Else

            If Me.RbAdvanceBillYes.Checked = True Then

                Me.RowHoldJC.Attributes.Add("style", "display:none;")
                Me.RowInstructions1.Attributes.Remove("style")
                Me.RowInstructions2.Attributes.Remove("style")

            Else

                Me.RowHoldJC.Attributes.Remove("style")
                Me.RowInstructions1.Attributes.Add("style", "display:none;")
                Me.RowInstructions2.Attributes.Add("style", "display:none;")

            End If

            Select Case Me.EventTarget

                Case "RebindGrid"
                    Me.RadGridComponentList.Rebind()

            End Select
        End If
        If Me.TxtApprovalAmount.ReadOnly = False Then

            Me.TxtApprovalAmount.TabIndex = 3

        Else

            Me.TxtApprovalAmount.TabIndex = -1

        End If
    End Sub
    Private Sub BillingApproval_Approval_JobComponent_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        'If Me.ApprovalHeaderID = 0 Then
        '    Dim RowCount As Integer = Me.RadGridComponentList.MasterTableView.Items.Count
        '    Me.SaveAll(RowCount)
        'End If

        If Me.LblStatus.Text = "Job/Component Not Saved To This Approval" Then
            Me.ButtonNewUserRow.Enabled = False
            Me.ButtonDeleteUserRow.Enabled = False
            CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("DeleteApproval"), Telerik.Web.UI.RadToolBarButton).Enabled = False
            'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Enabled = False
            'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Enabled = False
        End If
        Dim counter As Integer = 0
        Me.JSArray = ""
        Me.JSArrayNet = ""
        Me.JSArrayMarkupAmt = ""
        Me.JSArrayTaxAmt = ""

        For i As Integer = 0 To Me.RadGridComponentList.MasterTableView.Items.Count - 1
            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
            Try
                Dim tb As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                JSArray &= "try { myArray[" & counter.ToString() & "] = document.getElementById('" & tb.ClientID & "').value; }catch(err){}" & Environment.NewLine
            Catch ex As Exception
            End Try
            Try
                Dim tb1 As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox)
                JSArrayNet &= "try { myArrayNet[" & counter.ToString() & "] = document.getElementById('" & tb1.ClientID & "').value; }catch(err){}" & Environment.NewLine
            Catch ex As Exception
            End Try

            Try
                Dim tb2 As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_MARKUP_AMT"), TextBox)
                JSArrayMarkupAmt &= "try { myArrayMarkupAmt[" & counter.ToString() & "] = document.getElementById('" & tb2.ClientID & "').value; }catch(err){}" & Environment.NewLine
            Catch ex As Exception
            End Try
            Try
                Dim tb3 As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_TAX_AMT"), TextBox)
                JSArrayTaxAmt &= "try { myArrayTaxAmt[" & counter.ToString() & "] = document.getElementById('" & tb3.ClientID & "').value; }catch(err){}" & Environment.NewLine
            Catch ex As Exception
            End Try
            counter += 1
        Next
        'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColNET_QUOTE_UNBILLED_AMT").Display = Me.ShowDetailLevel

        Try
            If Me.DropGroupBy.SelectedIndex = 0 Then
                Me.LBtnExpandCollapse.Visible = False
            Else
                Me.LBtnExpandCollapse.Visible = True
            End If
        Catch ex As Exception
        End Try

        '''Hide columns
        ''Try
        ''    Me.RadGridComponentList.MasterTableView.GetColumn("ColNON_BILL_FEE").Display = Not Me.ChkHideColumnsDetails.Checked
        ''    Me.RadGridComponentList.MasterTableView.GetColumn("ColBILL_HOLD").Display = Not Me.ChkHideColumnsDetails.Checked
        ''    Me.RadGridComponentList.MasterTableView.GetColumn("ColOPEN_PO").Display = Not Me.ChkHideColumnsDetails.Checked

        ''    Me.RadGridComponentList.MasterTableView.GetColumn("colAPPR_COMMENTS").Display = Not Me.ChkHideColumnsComments.Checked
        ''    Me.RadGridComponentList.MasterTableView.GetColumn("colCLIENT_COMMENTS").Display = Not Me.ChkHideColumnsComments.Checked

        ''Catch ex As Exception

        ''End Try

        ''page defaults:
        'Try
        '    If Not Me.IsPostBack = True And Not Me.IsCallback = True Then
        '        'get page settings
        '        Dim baD As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        '        Dim dt As New DataTable
        '        dt = baD.GetPageSetting(cBillingApproval.BA_Page.Billing_Approval_Job_Component)
        '        For i As Integer = 0 To dt.Rows.Count - 1
        '            Select Case dt.Rows(i)("AGY_SETTINGS_CODE").ToString()
        '                Case "BA_RATE_DETAILS"
        '                    CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
        '                    Me.SetRateQtyColumns()
        '                Case "BA_APPR_INFO_SECT"
        '                    Me.CollapsablePanelApprovalInfo.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
        '                Case "BA_CMNT_SECT"
        '                    Me.CollapsablePanelComments.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
        '                Case "BA_DTLS_SECT"
        '                    Me.CollapsablePanelDetails.Collapsed = Not dt.Rows(i)("AGY_SETTINGS_VALUE")
        '                Case "BA_DTLS_OPT"
        '                    Me.ChkHideColumnsDetails.Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
        '                Case "BA_CMNT_OPT"
        '                    Me.ChkHideColumnsComments.Checked = dt.Rows(i)("AGY_SETTINGS_VALUE")
        '            End Select
        '        Next
        '    End If
        'Catch ex As Exception
        'End Try

        ''override agency setting if user clicked button
        'Try
        '    Me.ShowQtyRateColumns = CType(Session("BA_APPROVAL_SHOW_RATE_DETAILS"), Boolean)
        'Catch ex As Exception
        '    Me.ShowQtyRateColumns = False
        'End Try
        'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked = Me.ShowQtyRateColumns
        'If Me.ShowQtyRateColumns = True Then
        '    Me.SetRateQtyColumns()
        'End If

        'Hide columns
        Try
            'Me.RadGridComponentList.MasterTableView.GetColumn("ColNON_BILL_FEE").Display = Not Me.ChkHideColumnsDetails.Checked
            'Me.RadGridComponentList.MasterTableView.GetColumn("ColBILL_HOLD").Display = Not Me.ChkHideColumnsDetails.Checked
            'Me.RadGridComponentList.MasterTableView.GetColumn("ColOPEN_PO").Display = Not Me.ChkHideColumnsDetails.Checked

            'Me.RadGridComponentList.MasterTableView.GetColumn("colAPPR_COMMENTS").Display = Not Me.ChkHideColumnsComments.Checked
            'Me.RadGridComponentList.MasterTableView.GetColumn("colCLIENT_COMMENTS").Display = Not Me.ChkHideColumnsComments.Checked

        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region " Controls Events "

    Private Sub ButtonNewUserRow_Click(sender As Object, e As EventArgs) Handles ButtonNewUserRow.Click

        Dim NeedsFullRefresh As Boolean = False
        Dim ba As New cBillingApproval()
        Dim RowCount As Integer = Me.RadGridComponentList.MasterTableView.Items.Count
        Me.SaveAll(RowCount, True)
        Me.SaveAll(RowCount, False)

        'save current new user rows
        If RowCount > 0 Then

            Dim RowIndex As Integer = 0

            For i As Integer = 0 To RowCount - 1

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim IsUserAddedRow As Boolean = False

                Dim RowFunctionCode As String = ""
                Dim RowFunctionDescription As String = ""
                Dim RowQuantity As Decimal = 0.0
                Dim RowRate As Decimal = 0.0
                Dim RowApprovedAmt As Decimal = 0.0
                Dim RowApprovedComment As String = ""
                Dim RowClientComment As String = ""
                Dim RowApprovedNet As Decimal = 0.0

                If IsUserAddedRow = True Then

                    Dim tbValue As System.Web.UI.WebControls.TextBox

                    Try
                        tbValue = CType(CurrentGridRow.FindControl("TxtFNC_CODE"), TextBox)

                        If tbValue.Visible = True Then 'shouldn't need this check, but can't hurt

                            RowFunctionCode = tbValue.Text

                        Else

                            RowFunctionCode = ""

                        End If
                    Catch ex As Exception

                        RowFunctionCode = ""

                    End Try

                    If RowFunctionCode.Trim() <> "" Then
                        'get grid data:
                        Try
                            RowFunctionDescription = CType(CurrentGridRow.FindControl("TxtFNC_DESCRIPTION"), TextBox).Text
                        Catch ex As Exception
                            RowFunctionDescription = ""
                        End Try
                        Try
                            RowQuantity = CType(CType(CurrentGridRow.FindControl("TxtQUANTITY"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            RowQuantity = 0
                        End Try
                        Try
                            RowRate = CType(CType(CurrentGridRow.FindControl("TxtRATE"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            RowRate = 0
                        End Try
                        Try
                            RowApprovedAmt = CType(CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            RowApprovedAmt = 0
                        End Try
                        Try
                            RowApprovedComment = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox).Text
                        Catch ex As Exception
                            RowApprovedComment = ""
                        End Try
                        Try
                            RowClientComment = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox).Text
                        Catch ex As Exception
                            RowClientComment = ""
                        End Try
                        Try
                            RowApprovedNet = CType(CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            RowApprovedNet = 0
                        End Try
                        Dim PK As Integer = -1
                        Try
                            PK = CurrentGridRow.OwnerTableView.DataKeyValues(RowIndex)("INDEX")
                        Catch ex As Exception
                            PK = -1
                        End Try

                        If PK >= 0 Then

                            ba.ApprovalDetailDatatable_UpdateRow_User(MainDT, PK, RowFunctionCode, RowFunctionDescription, RowQuantity, RowRate, RowApprovedAmt, RowApprovedComment, RowClientComment, RowApprovedNet)

                        End If
                    End If

                End If

                RowIndex += 1

            Next
        End If

        'add new blank row
        Me.MainDT_UserRowAdd("", "", 0, 0, 0.0, "", "", 0.0, 0)
        Me.RadGridComponentList.Rebind()

    End Sub
    Private Sub ButtonDeleteUserRow_Click(sender As Object, e As EventArgs) Handles ButtonDeleteUserRow.Click

        Dim NeedsFullRefresh As Boolean = False
        Dim ba As New cBillingApproval()
        Dim RowCount As Integer = Me.RadGridComponentList.MasterTableView.Items.Count
        Me.SaveAll(RowCount, True)

        If RowCount > 0 Then

            For i As Integer = 0 To RowCount - 1

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim DtPk As Integer = 0
                Dim chk As CheckBox

                chk = CType(CurrentGridRow.FindControl("ChkDelete"), CheckBox)

                Try

                    DtPk = CType(CurrentGridRow.GetDataKeyValue("INDEX"), Integer)

                Catch ex As Exception

                    DtPk = 0

                End Try

                If DtPk > 0 Then

                    Dim r As DataRow = MainDT.Rows.Find(DtPk)

                    If r IsNot Nothing Then

                        Dim ThisFncCode As String = ""
                        Dim ThisFncDescription As String = ""
                        Dim ThisApprovedAmt As Decimal = 0.0
                        Dim ThisApprComment As String = ""
                        Dim ThisClientComment As String = ""
                        Dim ThisBaDtlId As Integer = -1

                        ThisBaDtlId = CType(CType(CurrentGridRow.FindControl("HfBA_DTL_ID"), HiddenField).Value, Integer)
                        ThisFncDescription = CType(CurrentGridRow.FindControl("TxtFNC_DESCRIPTION"), TextBox).Text

                        If IsNumeric(CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox).Text) = True Then

                            ThisApprovedAmt = CType(CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox).Text, Decimal)

                        Else

                            ThisApprovedAmt = 0.0

                        End If

                        ThisApprComment = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox).Text
                        ThisClientComment = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox).Text

                        If chk.Enabled = True Then 'it is a user row

                            If chk.Checked = True Then

                                If ThisBaDtlId = -1 Then

                                    'delete user row that has not yet been committed to db (only from datatable)
                                    MainDT.Rows.Remove(r)

                                Else

                                    'delete user row from db
                                    ba.ApprovalDetail_DeleteRow(ThisBaDtlId)
                                    NeedsFullRefresh = True

                                End If
                            Else

                                'update user row
                                ThisFncCode = CType(CurrentGridRow.FindControl("TxtFNC_CODE"), TextBox).Text
                                'need to validate the function code here! before continuing?

                                'for now just do it:
                                r("FNC_CODE") = ThisFncCode
                                r("FNC_DESCRIPTION") = ThisFncDescription
                                r("APPROVED_AMT") = ThisApprovedAmt
                                r("APPR_COMMENTS") = ThisApprComment
                                r("CLIENT_COMMENTS") = ThisClientComment

                            End If

                        Else 'it is a db row and cannot be deleted, only updated

                            'update db row
                            r("FNC_DESCRIPTION") = ThisFncDescription
                            r("APPROVED_AMT") = ThisApprovedAmt
                            r("APPR_COMMENTS") = ThisApprComment
                            r("CLIENT_COMMENTS") = ThisClientComment

                        End If

                    End If

                End If

            Next

            If NeedsFullRefresh = True Then

                Me.ClearSessionDT()

            End If

            Me.RadGridComponentList.Rebind()

        End If

    End Sub
    'Private Sub ChkHideColumnsComments_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkHideColumnsComments.CheckedChanged

    '    Me.SaveUserSettings()
    '    Me.RadGridComponentList.Rebind()

    'End Sub
    'Private Sub ChkHideColumnsDetails_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChkHideColumnsDetails.CheckedChanged

    '    Me.SaveUserSettings()
    '    Me.RadGridComponentList.Rebind()

    'End Sub
    Private Sub DropGroupBy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropGroupBy.SelectedIndexChanged
        SaveUserSettings()
        SetGrouping()

        If DropGroupBy.Text <> Me.CollapsedHeaders.GroupName Then

            Me.CollapsedHeaders.GroupName = DropGroupBy.Text
            Me.CollapsedHeaders.GroupCaptions.Clear()

        End If

    End Sub
    Private Sub ImgBtnClearAmounts_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImgBtnClearAmounts.Click
        Me.ZeroGridAmounts()
    End Sub
    Private Sub LBtnExpandCollapse_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LBtnExpandCollapse.Click
        'Try
        '    Me.SaveGrid(Me.RadGridComponentList.MasterTableView.Items.Count)
        'Catch ex As Exception
        'End Try
        Try
            If Me.LBtnExpandCollapse.Text = "Collapse All" Then
                With Me.RadGridComponentList
                    .MasterTableView.GroupsDefaultExpanded = False
                    .Rebind()
                End With
                Me.LBtnExpandCollapse.Text = "Expand All"
            Else
                With Me.RadGridComponentList
                    .MasterTableView.GroupsDefaultExpanded = True
                    .Rebind()
                End With
                Me.LBtnExpandCollapse.Text = "Collapse All"
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LinkButtonFilterByTempCutoff_Click(sender As Object, e As System.EventArgs) Handles LinkButtonFilterByTempCutoff.Click

        If CheckBoxListApproveThroughTypes.SelectedIndex = -1 Then

            Me.RadDatePickerApproveThroughDate.SelectedDate = Nothing
            Me.RadDatePickerApproveThroughDate.DateInput.Text = ""

        Else

            If Me.RadDatePickerApproveThroughDate.SelectedDate = Nothing Then

            End If

        End If

        Me.ClearSessionDT()
        Me.RadGridComponentList.Rebind()

        Me.FocusControl(Me.LinkButtonFilterByTempCutoff)

    End Sub
    Private Sub LinkButtonToQuotePercent_Click(sender As Object, e As EventArgs) Handles LinkButtonToQuotePercent.Click
        If IsNumeric(Me.TxtToQuotePercent.Text) = True Then
            Me.RbToQuotePercent.Checked = True
            Dim NewTotal As Decimal = 0.0 'Approved amount
            Dim NewTotalNet As Decimal = 0.0
            Dim NewTotalMarkupAmt As Decimal = 0.0
            Dim NewTotalTaxAmt As Decimal = 0.0
            Dim ExcludeNonBillable As Boolean = Me.ChkToQuotePercentExludeNonBillable.Checked

            Try
                For i As Integer = 0 To Me.RadGridComponentList.MasterTableView.Items.Count - 1
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim RowQuoteAmt As Decimal = 0.0
                    Dim RowIsNonBillable As Boolean = False
                    Try
                        Dim hfNoBill As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfROW_TYPE"), HiddenField)
                        If hfNoBill.Value = "1" Then 'It is non-billable
                            RowIsNonBillable = True
                        End If
                    Catch ex As Exception
                    End Try

                    Dim m As Decimal = 0.0
                    Dim RowApprovedAmt As Decimal = 0.0
                    Dim TbApproval As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                    m = CType(Me.TxtToQuotePercent.Text, Decimal)
                    If m > 100.0 Then
                        m = 100
                    End If
                    If m < 0 Then
                        m = 0
                    End If
                    Try
                        RowQuoteAmt = CType(CType(CurrentGridRow.FindControl("HfQUOTE_AMT"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowQuoteAmt = 0.0
                    End Try
                    If ExcludeNonBillable = True And RowIsNonBillable = True Then
                        RowApprovedAmt = 0.0
                    Else 'the normal old path
                        RowApprovedAmt = RowQuoteAmt * (m / 100)
                    End If

                    NewTotal += RowApprovedAmt
                    TbApproval.Text = FormatNumber(RowApprovedAmt, 2, True, False, False)

                    'for net
                    Dim RowQuoteNetAmt As Decimal = 0.0
                    Try
                        'NET APPROVED AMOUNT PRESET:
                        'Does it need to multiply by the percentage?
                        'new rows only?
                        Dim TbApprovedNet As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox)
                        Try
                            RowQuoteNetAmt = CType(CType(CurrentGridRow.FindControl("HfQUOTE_NET"), HiddenField).Value, Decimal)
                        Catch ex As Exception
                            RowQuoteNetAmt = 0.0
                        End Try
                        If ExcludeNonBillable = True And RowIsNonBillable = True Then
                            RowQuoteNetAmt = 0.0
                        Else 'the normal old path
                            RowQuoteNetAmt = RowQuoteNetAmt * (m / 100)
                        End If
                        TbApprovedNet.Text = FormatNumber(RowQuoteNetAmt, 2, TriState.True, TriState.False, TriState.False)
                    Catch ex As Exception
                    End Try
                    NewTotalNet += RowQuoteNetAmt


                    'for new markup
                    Dim RowMarkupAmt As Decimal = 0.0
                    Try
                        Dim TbMarkupAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_MARKUP_AMT"), TextBox)
                        If IsNumeric(TbMarkupAmt.Text) = True Then
                            RowMarkupAmt = CType(TbMarkupAmt.Text, Decimal)
                        End If
                        RowMarkupAmt = RowMarkupAmt * (m / 100.0)
                        TbMarkupAmt.Text = FormatNumber(RowMarkupAmt, 2, TriState.True, TriState.False, TriState.False)
                    Catch ex As Exception
                    End Try
                    NewTotalMarkupAmt += RowMarkupAmt

                    'for new tax
                    Dim RowTaxAmt As Decimal = 0.0
                    Dim RowQuoteResaleTax As Decimal = 0.0
                    Dim RowQuoteVendorTax As Decimal = 0.0
                    Try
                        Dim TbTaxAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_TAX_AMT"), TextBox)
                        Dim HfQuoteResaleTax As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfQUOTE_RESALE_TAX"), HiddenField)
                        Dim HfQuoteVendorTax As System.Web.UI.WebControls.HiddenField = CType(CurrentGridRow.FindControl("HfQUOTE_VENDOR_TAX"), HiddenField)
                        If IsNumeric(HfQuoteResaleTax.Value) = True Then
                            RowQuoteResaleTax = CType(HfQuoteResaleTax.Value, Decimal)
                        End If
                        If IsNumeric(HfQuoteVendorTax.Value) = True Then
                            RowQuoteVendorTax = CType(HfQuoteVendorTax.Value, Decimal)
                        End If
                        RowQuoteResaleTax = RowQuoteResaleTax * (m / 100.0)
                        RowQuoteVendorTax = RowQuoteVendorTax * (m / 100.0)
                        RowTaxAmt = RowQuoteResaleTax + RowQuoteVendorTax
                        TbTaxAmt.Text = FormatNumber(RowTaxAmt, 2, TriState.True, TriState.False, TriState.False)
                    Catch ex As Exception
                    End Try
                    NewTotalTaxAmt += RowTaxAmt


                Next
            Catch ex As Exception
            End Try

            'footer totals:
            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridComponentList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
            Try
                Dim lbSumTotal As System.Web.UI.WebControls.Label
                lbSumTotal = CType(footerItem.FindControl("LabelSUM_APPROVED_AMT"), Label)
                lbSumTotal.Text = FormatNumber(NewTotal, 2, True, False, False)
                Dim tbSumTotal As System.Web.UI.WebControls.TextBox
                tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), TextBox)
                tbSumTotal.Text = FormatNumber(NewTotal, 2, True, False, False)
            Catch ex As Exception
            End Try

            Try
                Dim tbSumTotalNet As System.Web.UI.WebControls.Label
                tbSumTotalNet = CType(footerItem.FindControl("LabelSUM_APPR_NET"), Label)
                tbSumTotalNet.Text = FormatNumber(NewTotalNet, 2, True, False, False)
            Catch ex As Exception
            End Try

            Try
                Dim tbSumTotalMarkup As System.Web.UI.WebControls.Label
                tbSumTotalMarkup = CType(footerItem.FindControl("TxtSUM_APPR_MARKUP_AMT"), Label)
                tbSumTotalMarkup.Text = FormatNumber(NewTotalMarkupAmt, 2, True, False, False)
            Catch ex As Exception
            End Try

            Try
                Dim tbSumTotalTax As System.Web.UI.WebControls.Label
                tbSumTotalTax = CType(footerItem.FindControl("TxtSUM_APPR_TAX_AMT"), Label)
                tbSumTotalTax.Text = FormatNumber(NewTotalTaxAmt, 2, True, False, False)
            Catch ex As Exception
            End Try

            'header textbox
            Try
                Me.TxtApprovalAmount.Text = FormatNumber(NewTotal, 2, True, False, False)
            Catch ex As Exception
            End Try

            'make sure numbers are saved and re-calced...
            Me.SaveGrid(Me.RadGridComponentList.MasterTableView.Items.Count)

        End If

    End Sub
    Private Sub RbManualOnApprovalAmt_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbManualOnApprovalAmt.CheckedChanged
        'Me.SaveHeader()
        Me.RefreshGrid()
    End Sub

    Private Sub RadGridComponentList_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridComponentList.ItemCommand

        Me.SetBAJC()

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        If index = -1 Then 'command item

            Select Case e.CommandName
                Case "ExpandCollapse"

                    If (Me.DropGroupBy.SelectedIndex <> -1) Then

                        Dim groupHeaders As List(Of GridItem) = Me.RadGridComponentList.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

                        Dim captions As List(Of String) = (From g In groupHeaders
                                                           Where g.Expanded = False
                                                           Select g.Cells(1).Text).ToList()

                        If (e.Item.Expanded) Then

                            captions.Add(e.Item.Cells(1).Text)

                        Else
                            If (captions.Contains(e.Item.Cells(1).Text)) Then

                                captions.Remove(e.Item.Cells(1).Text)

                            End If
                        End If

                        Me.CollapsedHeaders.GroupName = DropGroupBy.SelectedItem.Text
                        Me.CollapsedHeaders.GroupCaptions = captions

                    End If

            End Select

            Exit Sub

        Else

            Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.Items(index), Telerik.Web.UI.GridDataItem)

            Select Case e.CommandName
                Case "ViewItemDetail"

                    Dim ThisFncCode As String = ""
                    Dim ThisBaDtlID As Integer = -1
                    Dim ItemExists As String = ""

                    Try
                        ThisFncCode = CType(CurrentGridRow.FindControl("HfFNC_CODE"), HiddenField).Value
                    Catch ex As Exception
                        ThisFncCode = ""
                    End Try

                    Try
                        ThisBaDtlID = CType(CType(CurrentGridRow.FindControl("HfBA_DTL_ID"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        ThisBaDtlID = -1
                    End Try

                    Try
                        ItemExists = CType(CurrentGridRow.FindControl("HfITEM_EXISTS"), HiddenField).Value
                    Catch ex As Exception
                        ItemExists = ""
                    End Try

                    Me.SaveAll(Me.RadGridComponentList.MasterTableView.Items.Count, True)

                    Dim StrURL As String = "BillingApproval_Approval_Item_Detail.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" &
                                            Me.ApprovalID.ToString() & "&J=" & Me.JobNumber.ToString() & "&C=" & Me.JobComponentNbr.ToString() &
                                            "&FN=" & ThisFncCode & "&I=" & index & "&ex=" & ItemExists & "&D=" & ThisBaDtlID &
                                            "&ab=" & Me.RbAdvanceBillYes.Checked.ToString() & "&ro=" &
                                            Me.IsReadOnly.ToString() & "&dt=" & Me.ShowDetailLevel.ToString() & "&bt=" & Me.BillType.ToString()


                    Me.OpenWindow("", StrURL)

                    'Dim StrURL As String = "BillingApproval_Approval_Item_Detail.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" & Me.ApprovalID.ToString() & "&J=" & _
                    'Me.JobNumber.ToString() & "&C=" & Me.JobComponentNbr.ToString() & "&FN=" & lb.Text.Trim() & "&I=" & index & "&ex=" & hf.Value & "&D=" & ThisDetailID.ToString()

                    'Dim StrJS = "javascript:window.open('" & StrURL & "', 'PopApproval','screenX=150,left=5,screenY=150,top=5,width=1020,height=700,scrollbars=no,resizable=no,menubar=no,maximazable=no');return false;"
                    'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManagerBillingApproval, "ItemDetailWindow", "Item Details", StrURL, 500, 700, True)

                Case "GetRate"
                    Try
                        Dim ThisFncCode As String = ""
                        Try
                            ThisFncCode = CType(CurrentGridRow.FindControl("HfFNC_CODE"), HiddenField).Value
                        Catch ex As Exception
                            ThisFncCode = ""
                        End Try
                        If ThisFncCode.Trim() <> "" And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then
                            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                            Dim tbQty As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtQUANTITY"), TextBox)
                            Dim tbRate As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtRATE"), TextBox)
                            Dim tbAmount As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                            Dim tbNet As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox)
                            tbNet.Text = "0.00"
                            tbRate.Text = FormatNumber(ba.ApprovalDetailGetBillingRate(Me.JobNumber, Me.JobComponentNbr, ThisFncCode.Trim()), 2, True, False, False).ToString
                            If IsNumeric(tbQty.Text) = True And IsNumeric(tbRate.Text) = True Then
                                Dim t As Decimal = CType(tbQty.Text, Decimal) * CType(tbRate.Text, Decimal)
                                tbAmount.Text = FormatNumber(t, 2, True, False, False)
                                Me.RecalcTotal()
                            End If
                        End If
                    Catch ex As Exception
                    End Try
                Case "ShowComments"
                    Try
                        Dim ThisBaDtlID As Integer = -1
                        Try
                            ThisBaDtlID = CType(CType(CurrentGridRow.FindControl("HfBA_DTL_ID"), HiddenField).Value, Integer)
                        Catch ex As Exception
                            ThisBaDtlID = -1
                        End Try
                        If ThisBaDtlID = -1 Then
                            Me.ShowMessage("Please save before trying to view comments.")
                        Else
                            Me.SaveAll(Me.RadGridComponentList.MasterTableView.Items.Count, True)
                            Me.OpenWindow("Comment", "BillingApproval_Approval_JobComponent_Comments.aspx?BA_DTL_ID=" & ThisBaDtlID.ToString(), 375, 525)
                        End If
                    Catch ex As Exception
                    End Try
            End Select
        End If
    End Sub
    Private _ControlFocused As Boolean = False
    Private Sub RadGridComponentList_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComponentList.ItemDataBound

        'This manages the offset of the collapsable plus/minus icon column
        If Me.DropGroupBy.SelectedIndex = 1 Then

            CellStartIndex = 1

        End If

        Dim RowIndex As Integer = e.Item.ItemIndex

        Select Case e.Item.ItemType
            Case GridItemType.Header

                Dim ag As New cAgency(Session("ConnString"))
                Me.ApplyTaxUponBilling = ag.ApplyTaxUponBilling()

                'If Me.ApplyTaxUponBilling = True Then
                '    Dim Header As Telerik.Web.UI.GridHeaderItem = e.Item
                '    Header("ColAPPR_TAX_AMT").Text = "Tax Amount*"
                'End If

            Case GridItemType.Item, GridItemType.AlternatingItem

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(e.Item, Telerik.Web.UI.GridDataItem)

                CurrRecType = CType(CurrentGridRow.FindControl("HfFNC_TYPE"), HiddenField).Value

                Try
                    If IsNumeric(CurrentGridRow("ColQUOTE_AMT").Text) = True Then
                        SUM_QUOTE_AMT += CType(CurrentGridRow("ColQUOTE_AMT").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColACTUALS_AMT").Text) = True Then
                        SUM_ACTUALS_AMT += CType(CurrentGridRow("ColACTUALS_AMT").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColNON_BILL_FEE").Text) = True Then
                        SUM_NON_BILL_FEE += CType(CurrentGridRow("ColNON_BILL_FEE").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColBILL_HOLD").Text) = True Then
                        SUM_BILL_HOLD += CType(CurrentGridRow("ColBILL_HOLD").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColOPEN_PO").Text) = True Then
                        SUM_OPEN_PO += CType(CurrentGridRow("ColOPEN_PO").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColBILLED_REC").Text) = True Then
                        SUM_BILLED_REC += CType(CurrentGridRow("ColBILLED_REC").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColUNBILLED").Text) = True Then
                        SUM_UNBILLED += CType(CurrentGridRow("ColUNBILLED").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try

                Try
                    If IsNumeric(CurrentGridRow("ColQUOTE_QTY_HRS").Text) = True Then
                        SUM_QUOTE_QTY_HRS += CType(CurrentGridRow("ColQUOTE_QTY_HRS").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("ColACTUAL_QTY_HRS").Text) = True Then
                        SUM_ACTUAL_QTY_HRS += CType(CurrentGridRow("ColACTUAL_QTY_HRS").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If IsNumeric(CurrentGridRow("colQUOTE_NET").Text) = True Then
                        SUM_QUOTE_NET += CType(CurrentGridRow("colQUOTE_NET").Text, Decimal)
                    End If
                Catch ex As Exception
                End Try

                Dim QuantityTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtQUANTITY"), TextBox)
                Dim RateTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtRATE"), TextBox)
                Dim ApprovalMarkupPercentTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_MARKUP_PCT"), TextBox)
                Dim ApprovalMarkupAmountTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_MARKUP_AMT"), TextBox)
                Dim FunctionCodeTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtFNC_CODE"), TextBox)
                Dim FunctionCodeLinkButton As System.Web.UI.WebControls.LinkButton = CType(e.Item.FindControl("LBtnFNC_CODE"), LinkButton)
                Dim FunctionDescriptionTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtFNC_DESCRIPTION"), TextBox)
                Dim FunctionCodeLookupImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImgBtnFNC_CODE"), ImageButton)
                Dim ApprovedAmtTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPROVED_AMT"), TextBox)
                Dim NetApprovedAmtTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_NET"), TextBox)
                Dim MarkupAmountTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_MARKUP_AMT"), TextBox)
                Dim TaxAmountTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_TAX_AMT"), TextBox)
                Dim TaxCodeTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TextBoxAPPR_TAX_CODE"), TextBox)
                Dim TaxCodeImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImageButtonAPPR_TAX_CODE"), ImageButton)
                Dim ApprovalCommentsTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtAPPR_COMMENTS"), TextBox)
                Dim ClientCommentsTextBox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtCLIENT_COMMENTS"), TextBox)
                Dim ExtendedAmtTextbox As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtEXTENDED_AMT"), TextBox)
                Dim CommentPopUpImageButton As System.Web.UI.WebControls.ImageButton = CType(e.Item.FindControl("ImgBtnCOMMENT_POPUP"), ImageButton)
                Dim DeleteCheckBox As System.Web.UI.WebControls.CheckBox = CType(e.Item.FindControl("ChkDelete"), CheckBox)
                Dim TaxAmountHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_AMT"), HiddenField)
                Dim UnbilledNetHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfUNBILLED_NET"), HiddenField)
                Dim ApprovalResaleTaxHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_RESALE_TAX"), HiddenField)
                Dim ApprovalVendorTaxHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_VENDOR_TAX"), HiddenField)
                Dim UnbilledResaleTaxHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfUNBILLED_RESALE_TAX"), HiddenField)
                Dim UnbilledVendorTaxHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfUNBILLED_VENDOR_TAX"), HiddenField)
                Dim UnbilledMarkupHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfUNBILLED_MARKUP"), HiddenField)
                Dim ApprovalResaleTaxFlagHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_RESALE"), HiddenField)
                Dim ApprovalTaxCommissionFlagHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_COMM"), HiddenField)
                Dim ApprovalTaxCommissionOnlyFlagHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_COMM_ONLY"), HiddenField)
                Dim FunctionTypeHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfFNC_TYPE"), HiddenField)
                Dim StateTaxPercentageHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_STATE_PCT"), HiddenField)
                Dim CountyTaxPercentageHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_COUNTY_PCT"), HiddenField)
                Dim CityTaxPercentageHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfAPPR_TAX_CITY_PCT"), HiddenField)
                Dim ItemExistsHiddenField As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfITEM_EXISTS"), HiddenField)

                Dim UnbilledNet As Decimal = 0.0
                Dim VendorTaxAmt As Decimal = 0.0
                Dim ResaleTaxAmt As Decimal = 0.0
                Dim UnbilledResaleTaxAmt As Decimal = 0.0
                Dim UnbilledVendorTaxAmt As Decimal = 0.0
                Dim UnbilledMarkupAmt As Decimal = 0.0

                Dim CurrID As Integer = -1
                Dim IsUserAddedRow As Boolean = False

                'Added for new temp cutoff feature
                Dim CurrApprovalAmt As Decimal = 0.0
                Dim CurrUnbilledNet_AKA_NetApprovedAmt As Decimal = 0.0

                Try

                    CurrID = CType(CType(e.Item.FindControl("HfBA_DTL_ID"), HiddenField).Value, Integer)

                Catch ex As Exception

                    CurrID = -1

                End Try

                Try

                    IsUserAddedRow = CType(CType(e.Item.FindControl("HfIS_USER_ADDED"), HiddenField).Value, Boolean)

                Catch ex As Exception

                    IsUserAddedRow = False

                End Try

                Me.IsAdvancedBilling = Me.RbAdvanceBillYes.Checked

                'new for the net pre-fill:
                Try

                    Try
                        If IsNumeric(UnbilledNetHiddenField.Value) = True Then
                            UnbilledNet = CType(UnbilledNetHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        UnbilledNet = 0.0
                    End Try
                    Try
                        If IsNumeric(ApprovalVendorTaxHiddenField.Value) = True Then
                            VendorTaxAmt = CType(ApprovalVendorTaxHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        VendorTaxAmt = 0.0
                    End Try
                    Try
                        If IsNumeric(ApprovalResaleTaxHiddenField.Value) = True Then
                            ResaleTaxAmt = CType(ApprovalResaleTaxHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        ResaleTaxAmt = 0.0
                    End Try
                    Try
                        If IsNumeric(UnbilledResaleTaxHiddenField.Value) = True Then
                            UnbilledResaleTaxAmt = CType(UnbilledResaleTaxHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        UnbilledResaleTaxAmt = 0.0
                    End Try
                    Try
                        If IsNumeric(UnbilledVendorTaxHiddenField.Value) = True Then
                            UnbilledVendorTaxAmt = CType(UnbilledVendorTaxHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        UnbilledVendorTaxAmt = 0.0
                    End Try
                    Try
                        If IsNumeric(UnbilledMarkupHiddenField.Value) = True Then
                            UnbilledMarkupAmt = CType(UnbilledMarkupHiddenField.Value, Decimal)
                        End If
                    Catch ex As Exception
                        UnbilledMarkupAmt = 0.0
                    End Try

                    'default the net amount
                    NetApprovedAmtTextbox.Text = e.Item.DataItem("APPR_NET")
                    If (Me.ShowDetailLevel = True And CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True Then

                        NetApprovedAmtTextbox.Text = FormatNumber(UnbilledNet, 2, TriState.True, TriState.False, TriState.False)

                    ElseIf Me.RbManualOnApprovalAmt.Checked = True And ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) Then

                        NetApprovedAmtTextbox.Text = FormatNumber(UnbilledNet, 2, TriState.True, TriState.False, TriState.False)

                    End If

                    If ((Me.BillType = 2 Or Me.BillType = 3) And ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True)) _
                        Or (Me.IsAdvancedBilling = True And IsUserAddedRow = False And CurrID = -1) Then 'advance bill default

                        NetApprovedAmtTextbox.Text = "0.00"

                    End If

                    'default the markup amount
                    If ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) And Me.RbAdvancedBillNo.Checked = True Then 'default "unbilled" path

                        MarkupAmountTextbox.Text = FormatNumber(UnbilledMarkupAmt, 2, TriState.True, TriState.False, TriState.False)

                    ElseIf ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) And Me.RbToQuotePercent.Checked = True Then
                        'does anything need to be done here?
                    ElseIf CurrID > 0 And Me.AutoSaveHappened = False Then 'pop with real data

                        If IsNumeric(MarkupAmountTextbox.Text) = True Then

                            MarkupAmountTextbox.Text = FormatNumber(MarkupAmountTextbox.Text, 2, TriState.True, TriState.False, TriState.False)

                        Else

                            MarkupAmountTextbox.Text = "0.00"

                        End If

                    Else 'not sure if/when it jumps into this

                        MarkupAmountTextbox.Text = "0.00"

                    End If

                    'default the extended amount
                    Dim ExtendedAmount As Decimal
                    If NetApprovedAmtTextbox.Text <> "" AndAlso IsNumeric(NetApprovedAmtTextbox.Text) Then
                        ExtendedAmount = ExtendedAmount + CDec(NetApprovedAmtTextbox.Text)
                    End If
                    If MarkupAmountTextbox.Text <> "" AndAlso IsNumeric(MarkupAmountTextbox.Text) Then
                        ExtendedAmount = ExtendedAmount + CDec(MarkupAmountTextbox.Text)
                    End If
                    ExtendedAmtTextbox.Text = FormatNumber(ExtendedAmount, 2, TriState.True, TriState.False, TriState.False)

                    'default the tax amount
                    Dim SumTax As Decimal = UnbilledResaleTaxAmt + UnbilledVendorTaxAmt '3893/1/16
                    Dim SumSetTax As Decimal = ResaleTaxAmt + VendorTaxAmt
                    'Dim SumTax As Decimal = UnbilledVendorTaxAmt
                    'Dim SumSetTax As Decimal = VendorTaxAmt

                    If ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) And Me.RbAdvancedBillNo.Checked = True Then 'default "unbilled" path

                        TaxAmountTextbox.Text = FormatNumber(SumTax, 2, TriState.True, TriState.False, TriState.False)

                    ElseIf ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) And Me.RbToQuotePercent.Checked = True Then
                        'does anything need to be done here?
                    ElseIf CurrID > 0 And Me.AutoSaveHappened = False Then 'pop with real data

                        TaxAmountTextbox.Text = FormatNumber(SumSetTax, 2, TriState.True, TriState.False, TriState.False)

                    Else 'not sure if/when it jumps into this

                        TaxAmountTextbox.Text = FormatNumber("0", 2, TriState.True, TriState.False, TriState.False)

                    End If

                    'set default values:
                    'Based on level setting:
                    If (Me.ShowDetailLevel = True And CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True Then 'default on unbilled amount

                        ApprovedAmtTextbox.Text = CType(CurrentGridRow("ColUNBILLED").Text, Decimal) + VendorTaxAmt
                        'ApprovedAmtTextbox.Text = CType(CurrentGridRow("ColUNBILLED").Text, Decimal) + VendorTaxAmt - UnbilledResaleTaxAmt

                    End If
                    'Based on AB setting:
                    If Me.RbManualOnApprovalAmt.Checked = True And ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True) Then

                        ApprovedAmtTextbox.Text = CType(CurrentGridRow("ColUNBILLED").Text, Decimal) + VendorTaxAmt
                        'ApprovedAmtTextbox.Text = CType(CurrentGridRow("ColUNBILLED").Text, Decimal) + VendorTaxAmt - UnbilledResaleTaxAmt

                    End If
                    If ((Me.BillType = 2 Or Me.BillType = 3) And ((CurrID = -1 And IsUserAddedRow = False) Or Me.AutoSaveHappened = True)) _
                        Or (Me.IsAdvancedBilling = True And IsUserAddedRow = False And CurrID = -1) Then 'it is advanced Bill

                        ApprovedAmtTextbox.Text = "0.00"

                    End If

                Catch ex As Exception
                End Try

                If e.Item.DataItem("IS_USING_TEMP_APPROVED_AMT") = True Then

                    'Net Approved
                    CurrUnbilledNet_AKA_NetApprovedAmt = CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_NET"), Decimal)
                    NetApprovedAmtTextbox.Text = FormatNumber(CurrUnbilledNet_AKA_NetApprovedAmt, 2, TriState.True, TriState.False, TriState.False)

                    'Tax Amt
                    UnbilledResaleTaxAmt = CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_TAX"), Decimal)
                    UnbilledVendorTaxAmt = CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_NR"), Decimal)
                    Dim SumTax As Decimal = UnbilledResaleTaxAmt + UnbilledVendorTaxAmt
                    TaxAmountTextbox.Text = FormatNumber(SumTax, 2, TriState.True, TriState.False, TriState.False)

                    'Markup
                    MarkupAmountTextbox.Text = FormatNumber(CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_MU"), Decimal), 2, TriState.True, TriState.False, TriState.False)

                    'Approved Amt
                    CurrApprovalAmt = CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_TOT"), Decimal)
                    ApprovedAmtTextbox.Text = FormatNumber(CurrApprovalAmt + UnbilledVendorTaxAmt, 2, TriState.True, TriState.False, TriState.False)

                    'Extended Amt
                    ExtendedAmtTextbox.Text = FormatNumber(CurrUnbilledNet_AKA_NetApprovedAmt + CType(e.Item.DataItem("TEMP_CUTOFF_UNBILLED_MU"), Decimal), 2, TriState.True, TriState.False, TriState.False)

                End If


                Try

                    If IsNumeric(NetApprovedAmtTextbox.Text) = True Then

                        NetApprovedAmtTextbox.Text = FormatNumber(NetApprovedAmtTextbox.Text, 2, TriState.True, TriState.False, TriState.False)
                        SUM_APPR_NET += CType(NetApprovedAmtTextbox.Text, Decimal)

                    End If

                Catch ex As Exception

                End Try

                Try

                    If IsNumeric(ExtendedAmtTextbox.Text) = True Then

                        ExtendedAmtTextbox.Text = FormatNumber(ExtendedAmtTextbox.Text, 2, TriState.True, TriState.False, TriState.False)
                        SUM_EXTENDED_AMT += CType(ExtendedAmtTextbox.Text, Decimal)

                    End If

                Catch ex As Exception

                End Try

                'set summing of approved amounts
                Try
                    If Me.ShowDetailLevel = True Then

                        ' ''ApprovedAmtTextbox.Attributes.Add("onkeyup", "javascript:SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")
                        ' ''ApprovedAmtTextbox.Attributes.Add("onblur", "javascript:SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        counter += 1


                    End If

                    ApprovedAmtTextbox.ReadOnly = True ' Change to always be read only, issue: 3893/01/13

                    If IsNumeric(ApprovedAmtTextbox.Text) = True Then

                        SUM_APPROVED_AMT += CType(ApprovedAmtTextbox.Text, Decimal)

                    End If
                Catch ex As Exception
                End Try

                'set multiply/sum of rate and quantity and approved amount
                Try
                    'Add the javascript:

                    Dim StrCopyNet As String = "CopyNumericValue('" & ApprovedAmtTextbox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "');"
                    Dim StrCopyNet1 As String = "CopyNumericValue('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovedAmtTextbox.ClientID & "');"

                    'If MiscFN.ToolbarButtonToggleIsToggled(Me.RadToolbarBillingApproval2, 10) = False Then 'Qty/Rate button
                    StrCopyNet = ""
                    StrCopyNet1 = ""
                    'End If


                    Dim strTaxCalc As String = "BACalculateTax('" & ApprovalResaleTaxFlagHiddenField.ClientID & "','" & ApprovalTaxCommissionFlagHiddenField.ClientID & "','" & ApprovalTaxCommissionOnlyFlagHiddenField.ClientID & "','" & FunctionTypeHiddenField.ClientID & "','" &
                                                NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & StateTaxPercentageHiddenField.ClientID & "','" & CountyTaxPercentageHiddenField.ClientID & "','" & CityTaxPercentageHiddenField.ClientID & "','" &
                                                ApprovalResaleTaxHiddenField.ClientID & "','" & ApprovalVendorTaxHiddenField.ClientID & "','" & TaxAmountTextbox.ClientID & "','" & TaxAmountHiddenField.ClientID & "'," & Me.ApplyTaxUponBilling.ToString().ToLower() & ");"

                    Dim strCalcApprAmt As String = "BACalculateApprovedAmount('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ApprovalVendorTaxHiddenField.ClientID & "','" &
                        ApprovalResaleTaxHiddenField.ClientID & "','" & ApprovedAmtTextbox.ClientID & "');"

                    If Me.ApplyTaxUponBilling = True Then

                        strTaxCalc = ""
                        TaxAmountTextbox.Enabled = False

                    End If

                    If IsUserAddedRow = False Then

                        'Quantity textbox
                        QuantityTextBox.Attributes.Add("onkeyup", "javascript:CalcRate('" & QuantityTextBox.ClientID & "','" & RateTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "');Multiply('" &
                                                       QuantityTextBox.ClientID & "','" & RateTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "');MultiplyPerc('" & NetApprovedAmtTextbox.ClientID & "','" &
                                                       ApprovalMarkupPercentTextBox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "');" & StrCopyNet & strTaxCalc & strCalcApprAmt & "SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" &
                                                       Me.TxtApprovalAmount.ClientID & "');AddTotalExtMU('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ExtendedAmtTextbox.ClientID & "');")
                        QuantityTextBox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        'Rate textbox
                        RateTextBox.Attributes.Add("onkeyup", "javascript:Multiply('" & QuantityTextBox.ClientID & "','" & RateTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "');MultiplyPerc('" &
                                                   NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "');" & StrCopyNet & strTaxCalc & strCalcApprAmt & "SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');AddTotalExtMU('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ExtendedAmtTextbox.ClientID & "');")
                        RateTextBox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        'Net approved amount textbox
                        NetApprovedAmtTextbox.Attributes.Add("onkeyup", "javascript:CalcRateOverride('" & QuantityTextBox.ClientID & "','" & RateTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "');MultiplyPerc('" &
                                                             NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "');" & strTaxCalc & strCalcApprAmt & "SumItUpNet();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');AddTotalExtMU('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ExtendedAmtTextbox.ClientID & "');")
                        NetApprovedAmtTextbox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        'Markup percent textbox
                        ApprovalMarkupPercentTextBox.Attributes.Add("onkeyup", "javascript:MultiplyPerc('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "');" &
                                                                    strTaxCalc & strCalcApprAmt & "SumItUpNet();" & "SumItUp('" & Me.TxtApprovalAmount.ClientID & "');AddTotalExtMU('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ExtendedAmtTextbox.ClientID & "');")
                        ApprovalMarkupPercentTextBox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        'Markup amount textbox
                        ApprovalMarkupAmountTextBox.Attributes.Add("onkeyup", "javascript:CalculatePercInt('" & ApprovalMarkupAmountTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "');" &
                                                                   strTaxCalc & strCalcApprAmt & "SumItUpNet();" & "SumItUp('" & Me.TxtApprovalAmount.ClientID & "');AddTotalExtMU('" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ExtendedAmtTextbox.ClientID & "');")
                        ApprovalMarkupAmountTextBox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        ''extended amount textbox
                        'ExtendedAmtTextbox.Attributes.Add("onkeyup", "javascript:CalculatePercInt('" & ApprovalMarkupAmountTextBox.ClientID & "','" & NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "');" &
                        '                                           strTaxCalc & strCalcApprAmt & "SumItUpNet();" & "SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")
                        'ExtendedAmtTextbox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                        '' ''Approved amount textbox
                        ' ''ApprovedAmtTextbox.Attributes.Add("onkeydown", "javascript:BACalculateApprovedAmtInput('" & QuantityTextBox.ClientID & "','" & RateTextBox.ClientID & "','" & ApprovedAmtTextbox.ClientID & "','" & _
                        ' ''                                  NetApprovedAmtTextbox.ClientID & "','" & ApprovalMarkupPercentTextBox.ClientID & "','" & ApprovalMarkupAmountTextBox.ClientID & "','" & ApprovalResaleTaxHiddenField.ClientID & "','" & ApprovalVendorTaxHiddenField.ClientID & "','" & TaxAmountTextbox.ClientID & "');" & "SumItUpNet();SumItUpMarkup();SumItUpTax();" & "SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")
                        ' ''ApprovedAmtTextbox.Attributes.Add("onblur", "javascript:SumItUpNet();SumItUpMarkup();SumItUpTax();SumItUp('" & Me.TxtApprovalAmount.ClientID & "');")

                    End If

                Catch ex As Exception

                End Try

                'set function textbox/label
                Try

                    FunctionCodeLinkButton.Visible = Not IsUserAddedRow
                    FunctionCodeTextBox.Visible = IsUserAddedRow

                    'hide lookup
                    FunctionCodeLookupImageButton.Visible = IsUserAddedRow
                    If IsUserAddedRow = True Then

                        FunctionCodeLookupImageButton.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=approval_detail_fn&ctrlc=" & FunctionCodeTextBox.ClientID & "&ctrld=" & FunctionDescriptionTextBox.ClientID &
                                                                     "&job=" & Me.JobNumber & "&jobcomp=" & Me.JobComponentNbr & "&baid=" & Me.BatchID & "&aid=" & Me.ApprovalID & "&type=badtl_avail_fn');return false;")
                        FunctionCodeTextBox.Attributes.Add("ondblclick", "OpenRadWindowLookup('LookUp.aspx?form=approval_detail_fn&ctrlc=" & FunctionCodeTextBox.ClientID & "&ctrld=" & FunctionDescriptionTextBox.ClientID & "&job=" &
                                                           Me.JobNumber & "&jobcomp=" & Me.JobComponentNbr & "&baid=" & Me.BatchID & "&aid=" & Me.ApprovalID & "&type=badtl_avail_fn');return false;")

                    End If

                    If IsUserAddedRow = True AndAlso Me._ControlFocused = False Then

                        Me.FocusControl(FunctionCodeTextBox)
                        Me._ControlFocused = True

                    End If

                Catch ex As Exception

                End Try

                Dim TaxCodeLookupJS As String = "OpenRadWindowLookup('LookUp.aspx?form=approval_detail_taxc&ctrlc=" & TaxCodeTextbox.ClientID & "&ctrld=&job=" & Me.JobNumber & "&jobcomp=" & Me.JobComponentNbr & "&baid=" &
                                                Me.BatchID & "&aid=" & Me.ApprovalID & "&type=taxcodes');return false;"

                TaxCodeTextbox.Attributes.Add("ondblclick", TaxCodeLookupJS)
                TaxCodeImageButton.Attributes.Add("onclick", TaxCodeLookupJS)

                'set popup to item level:
                Try

                    If CurrID > 0 Then

                        'Dim StrURL As String = "BillingApproval_Approval_Item_Detail.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" & Me.ApprovalID.ToString() & "&J=" & Me.JobNumber.ToString() & "&C=" & Me.JobComponentNbr.ToString() & "&FN=" & lb.Text.Trim() & "&I=" & index & "&ex=" & hf.Value & "&D=" & ThisDetailID.ToString() & "&ab=" & Me.RbAdvanceBillYes.Checked.ToString() & "&ro=" & Me.IsReadOnly.ToString() & "&dt=" & Me.ShowDetailLevel.ToString() & "&bt=" & Me.BillType.ToString()
                        'lb.Attributes.Add("onclick", "window.open('" & StrURL & "', 'PopApproval','screenX=150,left=5,screenY=150,top=5,width=1190,height=700,scrollbars=yes,resizable=no,menubar=no,maximazable=no');return false;")
                        'lb.Attributes.Add("onclick", "OpenRadWindow('Function Details','" & StrURL & "',0,0);return false;")
                        FunctionCodeLinkButton.ToolTip = e.Item.DataItem("DEFAULT_DESCRIPTION")

                    Else

                        FunctionCodeLinkButton.Attributes.Add("onclick", "void(0);")
                        FunctionCodeLinkButton.ToolTip = e.Item.DataItem("DEFAULT_DESCRIPTION") & " (Save to see details)"

                    End If

                    index += 1

                Catch ex As Exception

                End Try

                'keep 3 if's separate for now, merge into one with "or" later?
                If Me.IsReadOnly = True Then

                    '734-1-2114 - Billing approval, unable to change the function description
                    'Restore below
                    FunctionDescriptionTextBox.ReadOnly = True

                    QuantityTextBox.ReadOnly = True
                    RateTextBox.ReadOnly = True
                    ApprovedAmtTextbox.ReadOnly = True
                    'ApprovalCommentsTextBox.ReadOnly = True
                    'ClientCommentsTextBox.ReadOnly = True

                End If

                'Allow comments when approving at job level 3980/1/202; only disable when read-only
                If Me.IsReadOnly = True Then

                    ApprovalCommentsTextBox.ReadOnly = True
                    ClientCommentsTextBox.ReadOnly = True

                End If

                '''Always disable.  3980/1/203
                ''FunctionDescriptionTextBox.ReadOnly = True

                ''Set non-billable image
                'Try
                '    Dim hf As System.Web.UI.WebControls.HiddenField = CType(e.Item.FindControl("HfROW_TYPE"), HiddenField)
                '    If hf.Value = "1" Then 'It is non-billable
                '        Dim ImgRowType As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgROW_TYPE"), System.Web.UI.WebControls.Image)
                '        Dim ImgRowTypeSpacer As System.Web.UI.WebControls.Image = CType(e.Item.FindControl("ImgROW_TYPE_SPACER"), System.Web.UI.WebControls.Image)
                '        ImgRowType.Visible = True
                '        ImgRowTypeSpacer.Visible = False
                '    End If
                'Catch ex As Exception
                'End Try

                'sum markup amt
                If IsNumeric(MarkupAmountTextbox.Text) = True Then

                    Me.SUM_MARKUP_AMT += CType(MarkupAmountTextbox.Text, Decimal)

                End If

                'sum tax amt
                If IsNumeric(TaxAmountTextbox.Text) = True Then

                    Me.SUM_TAX_AMT += CType(TaxAmountTextbox.Text, Decimal)

                End If

                'make user rows non-editable the "IS_USER_ADDED" field is only true when 
                'the datatables user added rows have not yet been commited to the database
                Try

                    If IsUserAddedRow = True Then

                        QuantityTextBox.ReadOnly = True
                        RateTextBox.ReadOnly = True
                        NetApprovedAmtTextbox.ReadOnly = True
                        ApprovalMarkupPercentTextBox.ReadOnly = True
                        MarkupAmountTextbox.ReadOnly = True
                        ApprovedAmtTextbox.ReadOnly = True

                    End If
                Catch ex As Exception
                End Try

                Try
                    If CurrID = -1 Then

                        With CommentPopUpImageButton

                            .Attributes.Add("onclick", "void(0);")
                            .ToolTip = "Please save before attempting to view comments."
                            .AlternateText = "Please save before attempting to view comments."

                        End With

                    End If
                Catch ex As Exception
                End Try


                If IsUserAddedRow = True Then

                    DeleteCheckBox.Enabled = True
                    Me._HasUserAddedDeletableRow = True

                End If


            Case GridItemType.Footer

                Dim CurrentGridFooter As Telerik.Web.UI.GridFooterItem = Me.RadGridComponentList.MasterTableView.GetItems(GridItemType.Footer)(0)
                If Me.CurrentTheme = TkTheme.Large Then
                    'header:
                    CurrentGridFooter("colFNC_DESCRIPTION").Text = "<strong>Totals&nbsp;&nbsp;</strong><br />"
                    'quote amount:
                    CurrentGridFooter("ColQUOTE_AMT").Text = "<strong>" & FormatNumber(SUM_QUOTE_AMT, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'actuals:
                    CurrentGridFooter("ColACTUALS_AMT").Text = "<strong>" & FormatNumber(SUM_ACTUALS_AMT, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'non bill/fee:
                    CurrentGridFooter("ColNON_BILL_FEE").Text = "<strong>" & FormatNumber(SUM_NON_BILL_FEE, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'bill hold:
                    CurrentGridFooter("ColBILL_HOLD").Text = "<strong>" & FormatNumber(SUM_BILL_HOLD, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'open po:
                    CurrentGridFooter("ColOPEN_PO").Text = "<strong>" & FormatNumber(SUM_OPEN_PO, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'billed/rec:
                    CurrentGridFooter("ColBILLED_REC").Text = "<strong>" & FormatNumber(SUM_BILLED_REC, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'unbilled:
                    CurrentGridFooter("ColUNBILLED").Text = "<strong>" & FormatNumber(SUM_UNBILLED, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'quote quantity/hours
                    CurrentGridFooter("ColQUOTE_QTY_HRS").Text = "<strong>" & FormatNumber(SUM_QUOTE_QTY_HRS, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'actual quantity/hours
                    CurrentGridFooter("ColACTUAL_QTY_HRS").Text = "<strong>" & FormatNumber(SUM_ACTUAL_QTY_HRS, 2, True, False, True) & "&nbsp;&nbsp;</strong>"
                    'quote net amount:
                    CurrentGridFooter("colQUOTE_NET").Text = "<strong>" & FormatNumber(SUM_QUOTE_NET, 2, True, False, True) & "&nbsp;&nbsp;</strong>"

                    Dim Div As HtmlControls.HtmlControl
                    Div = CurrentGridFooter("ColNET_QUOTE_UNBILLED_AMT").FindControl("DivNetApprovedAmount")
                    Div.Attributes.Add("style", "padding-right: 12px ")

                    Div = CurrentGridFooter("ColAPPR_MARKUP_AMT").FindControl("DivMarkupAmount")
                    Div.Attributes.Add("style", "padding-right: 12px ")

                    Div = CurrentGridFooter("ColEXTENDED_AMT").FindControl("DivExtendedAmount")
                    Div.Attributes.Add("style", "padding-right: 12px ")

                    Div = CurrentGridFooter("ColAPPROVED_AMT").FindControl("DivApprovedAmount")
                    Div.Attributes.Add("style", "padding-right: 12px ")

                    Div = CurrentGridFooter("ColAPPR_TAX_AMT").FindControl("DivTaxAmount")
                    Div.Attributes.Add("style", "padding-right: 12px ")

                Else
                    'header:
                    CurrentGridFooter("colFNC_DESCRIPTION").Text = "<strong>Totals</strong><br />"
                    'quote amount:
                    CurrentGridFooter("ColQUOTE_AMT").Text = "<strong>" & FormatNumber(SUM_QUOTE_AMT, 2, True, False, True) & "</strong>"
                    'actuals:
                    CurrentGridFooter("ColACTUALS_AMT").Text = "<strong>" & FormatNumber(SUM_ACTUALS_AMT, 2, True, False, True) & "</strong>"
                    'non bill/fee:
                    CurrentGridFooter("ColNON_BILL_FEE").Text = "<strong>" & FormatNumber(SUM_NON_BILL_FEE, 2, True, False, True) & "</strong>"
                    'bill hold:
                    CurrentGridFooter("ColBILL_HOLD").Text = "<strong>" & FormatNumber(SUM_BILL_HOLD, 2, True, False, True) & "</strong>"
                    'open po:
                    CurrentGridFooter("ColOPEN_PO").Text = "<strong>" & FormatNumber(SUM_OPEN_PO, 2, True, False, True) & "</strong>"
                    'billed/rec:
                    CurrentGridFooter("ColBILLED_REC").Text = "<strong>" & FormatNumber(SUM_BILLED_REC, 2, True, False, True) & "</strong>"
                    'unbilled:
                    CurrentGridFooter("ColUNBILLED").Text = "<strong>" & FormatNumber(SUM_UNBILLED, 2, True, False, True) & "</strong>"
                    'quote quantity/hours
                    CurrentGridFooter("ColQUOTE_QTY_HRS").Text = "<strong>" & FormatNumber(SUM_QUOTE_QTY_HRS, 2, True, False, True) & "</strong>"
                    'actual quantity/hours
                    CurrentGridFooter("ColACTUAL_QTY_HRS").Text = "<strong>" & FormatNumber(SUM_ACTUAL_QTY_HRS, 2, True, False, True) & "</strong>"
                    'quote net amount:
                    CurrentGridFooter("colQUOTE_NET").Text = "<strong>" & FormatNumber(SUM_QUOTE_NET, 2, True, False, True) & "</strong>"
                End If

                'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
                'net approved:
                Try
                    Dim SUM_APPR_NETLabel As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LabelSUM_APPR_NET"), Label)
                    SUM_APPR_NETLabel.Text = FormatNumber(SUM_APPR_NET, 2, True, False, True)
                Catch ex As Exception
                End Try

                'approved:
                Dim lbSum As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LabelSUM_APPROVED_AMT"), Label)
                Dim tbSum As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TxtSUM_APPROVED_AMT"), TextBox)

                lbSum.Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)
                tbSum.Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)

                If Me.ShowDetailLevel = True Then

                    tbSum.Attributes.Add("style", "display:none !important;")

                Else

                    lbSum.Attributes.Add("style", "display:none !important;")

                End If
                'Dim tbSum As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("TxtSUM_APPROVED_AMT"), Label)
                'With tbSum

                '    .Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)
                '    '.ReadOnly = Me.ShowDetailLevel

                'End With

                'If Me.TxtApprovalAmount.Text.Trim() = "" And Me.ShowDetailLevel = True Then

                '    Me.TxtApprovalAmount.Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)

                'ElseIf Me.TxtApprovalAmount.Text.Trim() = "" And Me.ShowDetailLevel = False Then

                '    Me.TxtApprovalAmount.Text = FormatNumber(SUM_UNBILLED, 2, True, False, True)

                'End If
                ''If Me.TxtApprovalAmount.Text.Trim() = "" Or IsNumeric(Me.TxtApprovalAmount.Text) = False Then

                ''Me.TxtApprovalAmount.Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)

                ''End If

                If ShowDetailLevel = True Then 'don't overwrite what user sees when details are off

                    Me.TxtApprovalAmount.Text = FormatNumber(SUM_APPROVED_AMT, 2, True, False, True)

                End If

                Me.TxtApprovalAmount.ReadOnly = Me.ShowDetailLevel

                If Me.IsReadOnly = True Then
                    'tbSum.ReadOnly = True
                End If

                'Display markup total
                Try
                    Dim tbMUTotal As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("TxtSUM_APPR_MARKUP_AMT"), Label)
                    tbMUTotal.Text = FormatNumber(SUM_MARKUP_AMT, 2, True, False, True)
                Catch ex As Exception
                End Try

                'Display tax total
                Try
                    Dim tbTAXTotal As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("TxtSUM_APPR_TAX_AMT"), Label)
                    tbTAXTotal.Text = FormatNumber(SUM_TAX_AMT, 2, True, False, True)
                Catch ex As Exception
                End Try

                'Display extended total
                Try
                    Dim tbEXTENDEDTotal As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("TxtSUM_EXTENDED_AMT"), Label)
                    tbEXTENDEDTotal.Text = FormatNumber(SUM_EXTENDED_AMT, 2, True, False, True)
                Catch ex As Exception
                End Try

                If Me.ApplyTaxUponBilling = True Then

                    'CType(CurrentGridFooter("ColAPPR_TAX_AMT").FindControl("TxtSUM_APPR_TAX_AMT"), TextBox).Enabled = False
                    'CurrentGridFooter("ColAPPR_TAX_AMT").Text = "<span style=""font-size:x-small;"">*Tax Applied Upon Billing</span>"

                End If

                Me.ButtonDeleteUserRow.Enabled = Me._HasUserAddedDeletableRow

                'set the Reconciled Total
                Try
                    Dim TotalBilledReconciled As Decimal = SUM_BILLED_REC
                    Dim TotalAdvancedBilled As Decimal = 0.0
                    If IsNumeric(Me.lblAB_BILLED.Text.Replace(",", "")) = True Then
                        TotalAdvancedBilled = TotalBilledReconciled - CType(Me.lblAB_BILLED.Text, Decimal)
                    End If
                    Me.lblRECONCILED_TOTAL.Text = FormatNumber(TotalAdvancedBilled, 2, TriState.True, TriState.False, TriState.True)
                Catch ex As Exception
                End Try
                Try
                    Me.lblACTUAL_LESS_BILLED.Text = FormatNumber((SUM_ACTUALS_AMT - SUM_BILLED_REC), 2, TriState.True, TriState.False, TriState.True)
                Catch ex As Exception

                End Try

        End Select

    End Sub
    Private Sub RadGridComponentList_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComponentList.NeedDataSource

        Me.RadGridComponentList.DataSource = MainDT

        With Me.GridView1
            If .Visible = True Then
                .DataSource = MainDT
                .DataBind()
            End If
        End With

        'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPROVED_AMT").Display = Me.ShowDetailLevel

        'If Me.ShowDetailLevel = False Then

        '    CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked = Me.ShowDetailLevel

        'End If

        'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Enabled = Me.ShowDetailLevel

        Me.SetRateQtyColumns()

    End Sub

    Private Sub RadToolbarBillingApprovalJobComponent_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBillingApprovalJobComponent.ButtonClick
        Dim RowCount As Integer = Me.RadGridComponentList.MasterTableView.Items.Count
        Dim ba As New cBillingApproval()
        Select Case e.Item.Value
            Case "MovePrevious"
                Me.SetBAJC()
                If Not Session("BA_APPROVAL_DETAIL_JOB_LIST") Is Nothing Then
                    Dim str As String = Session("BA_APPROVAL_DETAIL_JOB_LIST").ToString()
                    If str.Length > 0 Then
                        Dim arJobAndComps() As String
                        arJobAndComps = str.Split("|")
                        If arJobAndComps.Length > 0 Then
                            Dim arJC() As String
                            For i As Integer = 0 To arJobAndComps.Length - 1
                                arJC = arJobAndComps(i).ToString().Split(",")
                                If arJC.Length = 2 Then
                                    If IsNumeric(arJC(0)) = True And IsNumeric(arJC(1)) = True Then
                                        If CType(arJC(0), Integer) = Me.JobNumber And CType(arJC(1), Integer) = Me.JobComponentNbr Then
                                            'i is the current index
                                            If i - 1 < 0 Then
                                                arJC = arJobAndComps(arJobAndComps.Length - 1).ToString().Split(",")
                                            Else
                                                arJC = arJobAndComps(i - 1).ToString().Split(",")
                                            End If
                                            Dim qs As New AdvantageFramework.Web.QueryString()
                                            With qs
                                                .Page = "BillingApproval_Approval_JobComponent.aspx"
                                                .BillingApprovalBatchID = Me.BatchID
                                                .BillingApprovalId = Me.ApprovalID
                                                .JobNumber = arJC(0)
                                                .JobComponentNumber = arJC(1)
                                                .Add("L", Me.HfJobOnOtherBatch.Value)
                                            End With
                                            Session("BillingApproval_Approval_JobComponent_Nav") = Me.BatchID & "|" & Me.ApprovalID & "|" & arJC(0).ToString() & "|" & arJC(1).ToString()
                                            qs.Go()
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If

            Case "MoveNext"
                Me.SetBAJC()
                If Not Session("BA_APPROVAL_DETAIL_JOB_LIST") Is Nothing Then
                    Dim str As String = Session("BA_APPROVAL_DETAIL_JOB_LIST").ToString()
                    If str.Length > 0 Then
                        Dim arJobAndComps() As String
                        arJobAndComps = str.Split("|")
                        If arJobAndComps.Length > 0 Then
                            Dim arJC() As String
                            For i As Integer = 0 To arJobAndComps.Length - 1
                                arJC = arJobAndComps(i).ToString().Split(",")
                                If arJC.Length = 2 Then
                                    If IsNumeric(arJC(0)) = True And IsNumeric(arJC(1)) = True Then
                                        If CType(arJC(0), Integer) = Me.JobNumber And CType(arJC(1), Integer) = Me.JobComponentNbr Then
                                            'i is the current index
                                            If i + 1 >= arJobAndComps.Length Then
                                                arJC = arJobAndComps(0).ToString().Split(",")
                                            Else
                                                arJC = arJobAndComps(i + 1).ToString().Split(",")
                                            End If
                                            ' Me.LabelJobCount.Text = i + 1 & " of " & arJobAndComps.Length.ToString
                                            Dim qs As New AdvantageFramework.Web.QueryString()
                                            With qs
                                                .Page = "BillingApproval_Approval_JobComponent.aspx"
                                                .BillingApprovalBatchID = Me.BatchID
                                                .BillingApprovalId = Me.ApprovalID
                                                .JobNumber = arJC(0)
                                                .JobComponentNumber = arJC(1)
                                                .Add("L", Me.HfJobOnOtherBatch.Value)
                                            End With
                                            Session("BillingApproval_Approval_JobComponent_Nav") = Me.BatchID & "|" & Me.ApprovalID & "|" & arJC(0).ToString() & "|" & arJC(1).ToString()
                                            qs.Go()
                                        End If
                                    End If
                                End If
                            Next
                        End If
                    End If
                End If
            Case "DeleteApproval"
                If Me.HfCanDelete.Value = "0" Then
                    Dim StrMSG As String = ""
                    Me.ShowMessage("This billing approval record is selected in the Billing Command Center and cannot be deleted.")
                    Exit Sub
                End If
                Dim aid As Integer = 0
                Try
                    aid = CType(Me.HfBA_HDR_ID.Value, Integer)
                Catch ex As Exception
                    aid = 0
                End Try
                If aid > 0 Then
                    Dim str As String = ba.DeleteAllFromComponent(aid)
                    If str = "" Then
                        Me.CloseThisWindowAndRefreshCaller("BillingApproval_Approval_Detail.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" & Me.ApprovalID.ToString(), True)
                    Else
                        Me.ShowMessage(str)
                    End If
                    Exit Sub
                End If
            Case "Save"

                If Me.SaveAll(RowCount, True, 0) = "INVALID_FNC_CODE" Then

                    Exit Sub

                Else

                    Me.ClearApproveThroughFilter()
                    Me.ClearSessionDT()
                    Me.SaveUserSettings()
                    Me.RadGridComponentList.Rebind()

                End If

            'Case "EnableDetails"
            '    Me.SaveUserSettings()
            '    If Me.RbAdvanceBillYes.Enabled = True And Me.RbAdvancedBillNo.Enabled = True And CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked = False Then
            '        Me.RbAdvanceBillYes.Checked = False
            '        Me.RbAdvancedBillNo.Checked = True
            '        Me.RbToQuotePercent.Checked = False
            '        Me.RbHoldJobCompYes.Checked = False
            '        Me.RbHoldJobCompNo.Checked = True
            '    End If
            '    Me.SaveAll(RowCount, True)
            '    Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
            '    If Me.ShowDetailLevel = False Then
            '        Me.ClearApprovalAmounts()
            '    End If
            '    Me.SetHeader()
            '    Me.ClearSessionDT()
            '    Session("BA_APPROVAL_SHOW_RATE_DETAILS") = Me.ShowDetailLevel
            '    Me.RadGridComponentList.Rebind()

            Case "ViewMedia"

            'Case "EnableQtyRate"
            '    Me.SaveUserSettings()
            '    Me.SaveAll(RowCount, True)
            '    Me.ClearSessionDT()
            '    Me.SetRateQtyColumns()
            '    Session("BA_APPROVAL_SHOW_RATE_DETAILS") = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked
            '    Me.RadGridComponentList.Rebind()
            Case "Refresh"
                Me.SetHeader()
                Me.ClearSessionDT()
                Dim str As String = ""
                Try
                    str = Request.QueryString("L")
                Catch ex As Exception
                    str = ""
                End Try
                Dim qs As New AdvantageFramework.Web.QueryString()
                With qs
                    .Page = "BillingApproval_Approval_JobComponent.aspx"
                    .BillingApprovalBatchID = Me.BatchID
                    .BillingApprovalId = Me.ApprovalID
                    .JobNumber = Me.JobNumber
                    .JobComponentNumber = Me.JobComponentNbr
                    .Add("L", str)
                    '.Add("status", status)
                    .Go()
                End With
            Case "ViewRollup"

                Dim qs As New AdvantageFramework.Web.QueryString()
                With qs

                    .Page = "BillingApproval_Approval_Summary.aspx"
                    .BillingApprovalBatchID = Me.BatchID
                    .BillingApprovalId = Me.ApprovalID
                    .JobNumber = Me.JobNumber
                    .JobComponentNumber = Me.JobComponentNbr

                End With

                Me.OpenWindow(qs)

        End Select
    End Sub

#End Region

#Region " Methods "

    Private Sub ClearApproveThroughFilter()
        Me.RadDatePickerApproveThroughDate.SelectedDate = Nothing
        Me.RadDatePickerApproveThroughDate.DateInput.Text = ""
        For Each item As ListItem In Me.CheckBoxListApproveThroughTypes.Items
            item.Selected = False
        Next
    End Sub
    Private Sub SetBAJC()

        Dim qs As New AdvantageFramework.Web.QueryString()
        If Session("BillingApproval_Approval_JobComponent_Nav") Is Nothing Then
            qs = qs.FromCurrent()
            With qs
                Me.BatchID = .BillingApprovalBatchID
                Me.ApprovalID = .BillingApprovalId
                Me.JobNumber = .JobNumber
                Me.JobComponentNbr = .JobComponentNumber
            End With
        Else
            Dim ar() As String
            ar = Session("BillingApproval_Approval_JobComponent_Nav").ToString().Split("|")
            Me.BatchID = ar(0)
            Me.ApprovalID = ar(1)
            Me.JobNumber = CType(ar(2), Integer)
            Me.JobComponentNbr = CType(ar(3), Integer)
        End If


        Me.HfBA_BATCH_ID.Value = Me.BatchID.ToString()
        Me.LblApprovalID.Text = Me.ApprovalID.ToString().PadLeft(6, "0")
        Me.HfJOB_NUMBER.Value = Me.JobNumber.ToString()
        Me.HfJOB_COMPONENT_NBR.Value = Me.JobComponentNbr.ToString()

    End Sub
    Private Sub SetHeader()
        If Me.BatchID > 0 And Me.ApprovalID > 0 And Me.JobNumber > 0 And Me.JobComponentNbr > 0 Then

            Me.LblCampaign.Text = ""
            Me.LabelContact.Text = ""
            Me.LblInvoiceNumber.Text = ""
            Me.LabelClientPO.Text = ""

            Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim DsHeader As New DataSet
            Dim DtBaseInfo As New DataTable
            Dim DtApprovalHeaderInfo As New DataTable
            Dim DtApprovalInfo As New DataTable
            Dim DtABData As New DataTable

            DsHeader = b.GetComponentHeader(Me.BatchID, Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr)
            DtBaseInfo = DsHeader.Tables(0)
            DtApprovalHeaderInfo = DsHeader.Tables(1)
            DtApprovalInfo = DsHeader.Tables(2)
            DtABData = DsHeader.Tables(3)

            If DtBaseInfo.Rows.Count > 0 Then
                If IsDBNull(DtBaseInfo.Rows(0)("EMP_CODE")) = False Then
                    Me.HfAccountExecutiveCode.Value = DtBaseInfo.Rows(0)("EMP_CODE")
                Else
                    Me.HfAccountExecutiveCode.Value = ""
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("CMP_IDENTIFIER")) = False Then
                    Me.HfCampaignIdentifier.Value = DtBaseInfo.Rows(0)("CMP_IDENTIFIER")
                Else
                    Me.HfCampaignIdentifier.Value = ""
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("CMP_CODE")) = False Then
                    Me.HfCampaignCode.Value = DtBaseInfo.Rows(0)("CMP_CODE")
                Else
                    Me.HfCampaignCode.Value = ""
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("CLIENT_DISPLAY")) = False Then
                    Me.LblClient.Text = DtBaseInfo.Rows(0)("CLIENT_DISPLAY")
                End If
                If IsDBNull(DtBaseInfo.Rows(0)("DIVISION_DISPLAY")) = False Then
                    Me.LblDivision.Text = DtBaseInfo.Rows(0)("DIVISION_DISPLAY")
                End If
                If IsDBNull(DtBaseInfo.Rows(0)("PRODUCT_DISPLAY")) = False Then
                    Me.LblProduct.Text = DtBaseInfo.Rows(0)("PRODUCT_DISPLAY")
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("CAMPAIGN_DISPLAY")) = False Then
                    Me.LblCampaign.Text = DtBaseInfo.Rows(0)("CAMPAIGN_DISPLAY")
                    'Else
                    '    Me.LblCampaign.Text = "[None]"
                End If
                Me.TrCampaign.Visible = Me.LblCampaign.Text <> ""

                If IsDBNull(DtBaseInfo.Rows(0)("JOB_NUMBER")) = False Then
                    Me.LblJob.Text = DtBaseInfo.Rows(0)("JOB_NUMBER").ToString().PadLeft(6, "0")
                End If
                If IsDBNull(DtBaseInfo.Rows(0)("JOB_DESC")) = False Then
                    Me.LblJob.Text &= " - " & DtBaseInfo.Rows(0)("JOB_DESC").ToString()
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("JOB_COMPONENT_NBR")) = False Then
                    Me.LblComponent.Text = DtBaseInfo.Rows(0)("JOB_COMPONENT_NBR").ToString().PadLeft(2, "0")
                End If
                If IsDBNull(DtBaseInfo.Rows(0)("JOB_COMP_DESC")) = False Then
                    Me.LblComponent.Text &= " - " & DtBaseInfo.Rows(0)("JOB_COMP_DESC").ToString()
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("AE_EMP_FML_NAME")) = False Then
                    Me.LblAccountExecutive.Text = DtBaseInfo.Rows(0)("AE_EMP_FML_NAME")
                    Me.HfAccountExecutiveCode.Value = DtBaseInfo.Rows(0)("EMP_CODE")
                End If
                If IsDBNull(DtBaseInfo.Rows(0)("AB_FLAG")) = False Then
                    Dim x As Integer = CType(DtBaseInfo.Rows(0)("AB_FLAG"), Integer)
                    If x = 0 Then
                        Me.IsAdvancedBilling = False
                    Else
                        Me.IsAdvancedBilling = True
                    End If
                    Me.HfIsAdvancedBilling.Value = Me.IsAdvancedBilling.ToString()
                End If
                'JOB_BILL_HOLD
                If IsDBNull(DtBaseInfo.Rows(0)("JOB_BILL_HOLD")) = False Then
                    Me.BillHold = DtBaseInfo.Rows(0)("JOB_BILL_HOLD")
                    If Me.BillHold = 1 Or Me.BillHold = 2 Then
                        Me.LblJobComponentIsOnHold.Visible = True
                    Else
                        Me.LblJobComponentIsOnHold.Visible = False
                    End If
                End If

                'DISABLE DELETE IF J/C IS ON THE CURRENT BATCH
                Me.HfCanDelete.Value = "1"
                If IsDBNull(DtBaseInfo.Rows(0)("CAN_DELETE")) = False Then
                    If CType(DtBaseInfo.Rows(0)("CAN_DELETE"), Integer) = 0 Then
                        Me.HfCanDelete.Value = 0
                        Me.CanDelete = 0
                    End If
                End If

                If IsDBNull(DtBaseInfo.Rows(0)("JOB_CL_PO_NBR")) = False Then
                    Me.LabelClientPO.Text = DtBaseInfo.Rows(0)("JOB_CL_PO_NBR").ToString()
                End If
                Me.TrClientPO.Visible = Me.LabelClientPO.Text <> ""

                If IsDBNull(DtBaseInfo.Rows(0)("JOB_COMPONENT_CONTACT_FULL_NAME")) = False Then
                    Me.LabelContact.Text = DtBaseInfo.Rows(0)("JOB_COMPONENT_CONTACT_FULL_NAME").ToString()
                End If
                Me.TrContact.Visible = Me.LabelContact.Text <> ""

                If IsDBNull(DtBaseInfo.Rows(0)("JOB_PROCESS")) = False Then
                    Me.LabelProcessControl.Text = DtBaseInfo.Rows(0)("JOB_PROCESS").ToString()
                End If

            End If

            Me.HfApprStatus.Value = 0
            If DtApprovalHeaderInfo.Rows.Count > 0 Then

                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("APPR_STATUS")) = False Then
                    Me.HfApprStatus.Value = DtApprovalHeaderInfo.Rows(0)("APPR_STATUS").ToString()
                End If

                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("APPR_COMMENTS")) = False Then
                    Me.TxtCommentsApproval.Text = DtApprovalHeaderInfo.Rows(0)("APPR_COMMENTS")
                Else
                    Me.TxtCommentsApproval.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("CLIENT_COMMENTS")) = False Then
                    Me.TxtCommentsClient.Text = DtApprovalHeaderInfo.Rows(0)("CLIENT_COMMENTS")
                Else
                    Me.TxtCommentsClient.Text = ""
                End If
                'Override the current component ae with the approval header ae:
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("ACCT_EXEC")) = False Then
                    Me.LblAccountExecutive.Text = DtApprovalHeaderInfo.Rows(0)("AE_EMP_FML_NAME")
                    Me.HfAccountExecutiveCode.Value = DtApprovalHeaderInfo.Rows(0)("ACCT_EXEC")
                Else
                    Me.LblAccountExecutive.Text = ""
                    Me.HfAccountExecutiveCode.Value = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("BA_HDR_ID")) = False Then
                    Me.ApprovalHeaderID = CType(DtApprovalHeaderInfo.Rows(0)("BA_HDR_ID"), Integer)
                Else
                    Me.ApprovalHeaderID = 0
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("APPROVED_AMT")) = False Then
                    Me.TxtApprovalAmount.Text = FormatNumber(DtApprovalHeaderInfo.Rows(0)("APPROVED_AMT"), 2, True, False, True)
                Else
                    Me.TxtApprovalAmount.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("BILL_TYPE")) = False Then
                    Me.BillType = CType(DtApprovalHeaderInfo.Rows(0)("BILL_TYPE"), Integer)
                Else
                    Me.BillType = 0
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("ADJUSTED")) = False Then
                    Me.IsAdjusted = CType(DtApprovalHeaderInfo.Rows(0)("ADJUSTED"), Boolean)
                Else
                    Me.IsAdjusted = False
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("AB_BILLED")) = False Then
                    Me.lblAB_BILLED.Text = FormatNumber(DtApprovalHeaderInfo.Rows(0)("AB_BILLED"), 2, True, False, True)
                Else
                    Me.lblAB_BILLED.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("AB_UNBILLED")) = False Then
                    Me.lblAB_UNBILLED.Text = FormatNumber(DtApprovalHeaderInfo.Rows(0)("AB_UNBILLED"), 2, True, False, True)
                Else
                    Me.lblAB_UNBILLED.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("AB_INCOME_REC")) = False Then
                    Me.lbl_INCOME_REC.Text = FormatNumber(DtApprovalHeaderInfo.Rows(0)("AB_INCOME_REC"), 2, True, False, True)
                Else
                    Me.lbl_INCOME_REC.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("AR_INV_NBR")) = False Then

                    Me.LblInvoiceNumber.Text = DtApprovalHeaderInfo.Rows(0)("AR_INV_NBR").ToString().PadLeft(6, "0")

                End If
                Me.TrInvoice.Visible = LblInvoiceNumber.Text <> ""

                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("INVOICE_DATE")) = False Then
                    Me.LblInvoiceDate.Text = LoGlo.FormatDate(CType(DtApprovalHeaderInfo.Rows(0)("INVOICE_DATE"), Date).ToShortDateString())
                Else
                    Me.LblInvoiceDate.Text = ""
                End If
                If IsDBNull(DtApprovalHeaderInfo.Rows(0)("APPR_STATUS")) = False Then
                    If CType(DtApprovalHeaderInfo.Rows(0)("APPR_STATUS"), Integer) = 1 Then
                        Me.HfCanDelete.Value = 0
                        Me.CanDelete = 0
                    End If
                End If
            Else 'there is no header record
                Me.ApprovalHeaderID = 0
                If IsDBNull(DtABData.Rows(0)("DEFAULT_BILL_TYPE")) = False Then
                    Me.BillType = CType(DtABData.Rows(0)("DEFAULT_BILL_TYPE"), Integer)
                Else
                    Me.BillType = 0
                End If
                If IsDBNull(DtABData.Rows(0)("AB_BILLED")) = False Then
                    Me.lblAB_BILLED.Text = FormatNumber(DtABData.Rows(0)("AB_BILLED"), 2, True, False, True)
                Else
                    Me.lblAB_BILLED.Text = ""
                End If
                If IsDBNull(DtABData.Rows(0)("AB_UNBILLED")) = False Then
                    Me.lblAB_UNBILLED.Text = FormatNumber(DtABData.Rows(0)("AB_UNBILLED"), 2, True, False, True)
                Else
                    Me.lblAB_UNBILLED.Text = ""
                End If
                If IsDBNull(DtABData.Rows(0)("AB_INCOME_REC")) = False Then
                    Me.lbl_INCOME_REC.Text = FormatNumber(DtABData.Rows(0)("AB_INCOME_REC"), 2, True, False, True)
                Else
                    Me.lbl_INCOME_REC.Text = ""
                End If
            End If
            If IsDBNull(DtABData.Rows(0)("HAS_QTY_RATE")) = False Then
                If CType(DtABData.Rows(0)("HAS_QTY_RATE"), Integer) = 0 Then
                    Me.HasQuantityRate = False
                Else
                    Me.HasQuantityRate = True
                End If
            Else
                Me.HasQuantityRate = False
            End If
            If IsDBNull(DtABData.Rows(0)("IS_READ_ONLY")) = False Then
                Me.IsReadOnly = CType(DtABData.Rows(0)("IS_READ_ONLY"), Boolean)
            Else
                Me.IsReadOnly = False
            End If
            Me.HfIsReadOnly.Value = Me.IsReadOnly.ToString()
            If IsDBNull(DtABData.Rows(0)("JC_STATUS")) = False Then
                Me.LblStatus.Text = DtABData.Rows(0)("JC_STATUS").ToString()
            Else
                Me.LblStatus.Text = ""
            End If

            Me.SetFormReadOnly(Me.IsReadOnly)

            Me.HfBA_HDR_ID.Value = Me.ApprovalHeaderID.ToString()
            Me.HfBillType.Value = Me.BillType.ToString()

            If DtApprovalInfo.Rows.Count > 0 Then
                If IsDBNull(DtApprovalInfo.Rows(0)("BA_ID")) = False Then
                    Me.LblApprovalID.Text = DtApprovalInfo.Rows(0)("BA_ID").ToString().PadLeft(6, "0")
                Else
                    Me.LblApprovalID.Text = ""
                End If
                If IsDBNull(DtApprovalInfo.Rows(0)("BA_CL_DESC")) = False Then
                    Me.LblApprovalDescription.Text = DtApprovalInfo.Rows(0)("BA_CL_DESC")
                Else
                    Me.LblApprovalDescription.Text = ""
                End If
            End If


            'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
            Me.RbAdvanceBillYes.Enabled = Me.ShowDetailLevel
            Me.RbAdvancedBillNo.Enabled = Me.ShowDetailLevel
            Me.RbToQuotePercent.Enabled = Me.ShowDetailLevel
            Me.RbManualOnApprovalAmt.Enabled = Me.ShowDetailLevel
            Me.TxtToQuotePercent.Enabled = Me.ShowDetailLevel
            Me.LinkButtonToQuotePercent.Visible = Me.ShowDetailLevel
            Me.ImgBtnClearAmounts.Visible = Me.ShowDetailLevel


            'set option visibility:
            If Me.IsAdvancedBilling = False Then
                Me.RbAdvanceBillYes.Checked = False
                Me.RbAdvancedBillNo.Checked = True
                're-write attribute default:
                'show hold:
                Me.RowHoldJC.Attributes.Remove("style")
                'hide instructions:
                Me.RowInstructions1.Attributes.Add("style", "display:none;")
                Me.RowInstructions2.Attributes.Add("style", "display:none;")
            ElseIf Me.IsAdvancedBilling = True Then
                Me.RbAdvanceBillYes.Enabled = False
                Me.RbAdvancedBillNo.Enabled = False
                If Me.BillType = 2 Or Me.BillType = 3 Then
                    Me.RbToQuotePercent.Enabled = False
                    Me.RbManualOnApprovalAmt.Enabled = False
                    'Me.ImgBtnToQuotePercent.Enabled = False
                End If
            End If

            'Override the ab_flag from the component table with the bill type:
            If Me.IsAdvancedBilling = False Then
                If Me.BillType = 2 Or Me.BillType = 3 Then
                    Me.RbAdvanceBillYes.Checked = True
                    Me.RbAdvancedBillNo.Checked = False
                    Me.RowHoldJC.Attributes.Add("style", "display:none;")
                    Me.RowInstructions1.Attributes.Remove("style")
                    Me.RowInstructions2.Attributes.Remove("style")
                ElseIf Me.BillType = 0 Or Me.BillType = 1 Then
                    Me.RbAdvanceBillYes.Checked = False
                    Me.RbAdvancedBillNo.Checked = True
                    Me.RowHoldJC.Attributes.Remove("style")
                    Me.RowInstructions1.Attributes.Add("style", "display:none;")
                    Me.RowInstructions2.Attributes.Add("style", "display:none;")
                End If
            End If

            If Me.BillHold = 0 Then
                Me.RbHoldJobCompYes.Checked = False
                Me.RbHoldJobCompNo.Checked = True
            Else
                Me.RbHoldJobCompYes.Checked = True
                Me.RbHoldJobCompNo.Checked = False
            End If

            'set options:
            Select Case Me.BillType
                Case 0 'Progress Bil
                    Me.RbHoldJobCompYes.Checked = False
                    Me.RbHoldJobCompNo.Checked = True
                Case 1 'Bill Hold
                    Me.RbHoldJobCompYes.Checked = True
                    Me.RbHoldJobCompNo.Checked = False
                Case 2 'AB to Quote
                    Me.RbToQuotePercent.Checked = True
                    Me.RbManualOnApprovalAmt.Checked = False
                Case 3 'AB Manual
                    Me.RbToQuotePercent.Checked = False
                    Me.RbManualOnApprovalAmt.Checked = True
                Case Else
                    Me.RbToQuotePercent.Checked = False
                    Me.RbManualOnApprovalAmt.Checked = True
            End Select

            ''Set toolbar delete enabled or not:
            'MiscFN.SetToolbarButtonEnabled(Me.RadToolbarBillingApproval, 1, IsAdjusted) 'Save button
            If Me.IsReadOnly = False Then
                CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("DeleteApproval"), Telerik.Web.UI.RadToolBarButton).Enabled = Not IsAdjusted
            End If
            If Me.CanDelete = 0 Then
                CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("DeleteApproval"), Telerik.Web.UI.RadToolBarButton).Enabled = False
            End If

        End If
        'If Me.ApprovalHeaderID = 0 And Me.LblStatus.Text.IndexOf("Approved") = -1 And Me.LblStatus.Text <> "Job/Component Not Part Of Current Batch" Then
        '    Me.LblStatus.Text = "Job/Component Not Saved To This Approval"
        'End If

    End Sub
    Private Sub SetFormReadOnly(ByVal ItIsReadOnly As Boolean)

        If ItIsReadOnly = True Then
            CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("Save"), Telerik.Web.UI.RadToolBarButton).Enabled = False
            Me.ButtonNewUserRow.Enabled = False
            Me.ButtonDeleteUserRow.Enabled = False
            CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("DeleteApproval"), Telerik.Web.UI.RadToolBarButton).Enabled = False
            'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Enabled = False

            Me.RbAdvanceBillYes.Enabled = False
            Me.RbAdvancedBillNo.Enabled = False
            Me.RbHoldJobCompYes.Enabled = False
            Me.RbHoldJobCompNo.Enabled = False
            Me.RbToQuotePercent.Enabled = False
            Me.RbManualOnApprovalAmt.Enabled = False
            Me.TxtToQuotePercent.ReadOnly = True
            Me.TxtCommentsApproval.ReadOnly = True
            Me.TxtCommentsClient.ReadOnly = True
            With Me.TxtApprovalAmount
                .ReadOnly = True
                '.BorderWidth = Unit.Pixel(0)
                '.BorderStyle = BorderStyle.None
            End With
        Else
            With Me.TxtApprovalAmount
                .ReadOnly = False
                '.BorderWidth = Unit.Pixel(1)
                '.BorderStyle = BorderStyle.Solid
            End With
        End If

    End Sub
    Private Sub ClearApprovalAmounts()
        'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
        Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        ba.ComponentClearApprovalAmounts(Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr)
    End Sub
    Private Function SaveAll(ByVal CurrRowCount As Integer, ByVal SaveGridUserRows As Boolean, Optional ByVal SetApprStatusTo As Integer = -1) As String
        Dim s As String = ""
        s = Me.SaveGrid(CurrRowCount, SaveGridUserRows)
        Me.SaveHeader(SetApprStatusTo)
        Dim ba As New cBillingApproval()
        Me.AutoSaveHappened = ba.AutoSave(Me.BatchID, Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr)

        Return s
    End Function
    Private Function SaveHeader(Optional ByVal SetApprStatusTo As Integer = -1) As String
        Try
            'some basic validation here:
            'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked
            If Me.ShowDetailLevel = True Then
                Me.TxtApprovalAmount.Text = ""
            End If
            Me.TxtApprovalAmount.Text = Me.TxtApprovalAmount.Text.Trim()
            Me.TxtApprovalAmount.Text = Me.TxtApprovalAmount.Text.Replace("$", "")
            Me.TxtApprovalAmount.Text = Me.TxtApprovalAmount.Text.Replace(",", "")
            If Me.TxtApprovalAmount.Text <> "" Then
                If IsNumeric(Me.TxtApprovalAmount.Text) = False Then
                    Me.ShowMessage("Approval amount is not a number")
                    Exit Function
                End If
                If Me.RbAdvanceBillYes.Checked = True And Me.RbToQuotePercent.Checked = True Then
                    Dim m As Decimal = 0.0
                    Dim ApprovalAmt As Decimal = CType(Me.TxtApprovalAmount.Text, Decimal)
                    If IsNumeric(Me.TxtToQuotePercent.Text) = True Then
                        m = CType(Me.TxtToQuotePercent.Text, Decimal)
                        ''disable because we're doing it in the grid refresh?
                        'Me.TxtApprovalAmount.Text = ApprovalAmt * (m / 100)
                    Else
                        'Me.ShowMessage("Invalid quote percent."
                        'Exit Function
                        m = 0.0
                    End If
                End If
                Dim str As String = Me.TxtApprovalAmount.Text
                If str.IndexOf(".") > 0 Then
                    'has decimal
                    If str.Length > 16 Then
                        Me.ShowMessage("Approval amount exceeds allowable value")
                        Exit Function
                    End If
                Else
                    If str.Length > 13 Then
                        Me.ShowMessage("Approval amount exceeds allowable value")
                        Exit Function
                    End If
                End If

            End If

            'Set Billing Type:
            Dim ThisBillType As Integer = 0
            If Me.RbAdvanceBillYes.Checked = True Then
                If Me.RbToQuotePercent.Checked = True Then
                    ThisBillType = 2
                End If
                If Me.RbManualOnApprovalAmt.Checked = True Then
                    ThisBillType = 3
                End If
                If Me.RbToQuotePercent.Checked = False And Me.RbManualOnApprovalAmt.Checked = False Then
                    ThisBillType = 3
                End If
            ElseIf Me.RbAdvancedBillNo.Checked = True Then
                If Me.RbHoldJobCompYes.Checked = True Then
                    ThisBillType = 1
                End If
                If Me.RbHoldJobCompNo.Checked = True Then
                    ThisBillType = 0
                End If
            End If

            '
            Dim ApprStatus As Integer = 99 'Don't change

            If Me.AutoSaveHappened = True Then
                ApprStatus = 1
            End If
            If SetApprStatusTo > -1 Then
                ApprStatus = SetApprStatusTo
            End If

            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim ThisHeaderID As Integer = CType(Me.HfBA_HDR_ID.Value, Integer)
            If ThisHeaderID > 0 Then
                'update
                ba.ApprovalHeaderUpdate(ThisHeaderID, Me.TxtApprovalAmount.Text, Me.TxtCommentsApproval.Text, Me.TxtCommentsClient.Text, ThisBillType, ApprStatus)
                Me.SetHeader()
            Else
                'insert
                Dim NewHeaderID As Integer = 0
                Dim str As String = ba.ApprovalHeaderAddNew(Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr, Me.HfAccountExecutiveCode.Value, Me.TxtApprovalAmount.Text,
                                                            Me.TxtCommentsApproval.Text, Me.TxtCommentsClient.Text, Session("UserCode").ToString(), -999, "", ThisBillType, ApprStatus)
                If IsNumeric(str) = True Then
                    NewHeaderID = CType(str, Integer)
                Else
                    Me.ShowMessage(str)
                    Exit Function
                End If
                If NewHeaderID > 0 Then
                    'redirect back to self
                    Dim qs As New AdvantageFramework.Web.QueryString()
                    qs.PassThroughTo("BillingApproval_Approval_JobComponent.aspx")
                    'MiscFN.ResponseRedirect("BillingApproval_Approval_JobComponent.aspx?BAID=" & Me.BatchID.ToString() & "&AID=" & Me.ApprovalID.ToString() & 
                    '                  _"&J=" & Me.JobNumber.ToString() & "&C=" & Me.JobComponentNbr.ToString(), False)
                End If
            End If
        Catch ex As Exception
            Return "Error saving header: " & ex.Message.ToString()
        End Try
    End Function
    Private Function SaveGrid(ByVal iRowCount As Integer, Optional ByVal SaveUserRows As Boolean = True) As String

        'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked

        If Me.ShowDetailLevel = False Then

            Exit Function

        End If
        Try

            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            Dim TotalForHeader

            If iRowCount > 0 Then

                For i As Integer = 0 To iRowCount - 1

                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Me.RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)

                    Dim StrErrorMessage As String = ""
                    Dim BoolIsUserAdded As Boolean = False
                    Dim RowBillingApprovalDetailID As Integer = -1
                    Dim RowFunctionCode As String = ""
                    Dim RowFunctionDescription As String = ""
                    Dim RowQuantity As Decimal = 0.0
                    Dim RowRate As Decimal = 0.0
                    Dim RowApprovedAmt As Decimal = 0.0
                    Dim RowApprovedComment As String = ""
                    Dim RowClientComment As String = ""
                    Dim RowQuoteAmt As Decimal = 0.0
                    Dim RowIndex As Integer = -1
                    Dim RowMarkedForDelete As Boolean = False
                    Dim RowApprovedNet As Decimal = 0.0
                    Dim RowApprMarkupPct As Decimal = 0.0
                    Dim RowApprMarkupAmt As Decimal = 0.0
                    Dim RowApprTaxCode As String = ""
                    Dim RowApprTaxComm As Integer = 0
                    Dim RowApprTaxCommOnly As Integer = 0
                    Dim RowApprTaxResale As Integer = 0
                    Dim RowApprResaleTax As Decimal = 0.0
                    Dim RowApprVendorTax As Decimal = 0.0
                    Dim RowApprTaxStatePct As Decimal = 0.0
                    Dim RowApprTaxCountyPct As Decimal = 0.0
                    Dim RowApprTaxCityPct As Decimal = 0.0

                    Dim RowRowType As Integer = 0
                    Dim RowIsUserRow As Boolean = False

                    BoolIsUserAdded = CType(CType(CurrentGridRow.FindControl("HfIS_USER_ADDED"), HiddenField).Value, Boolean)

                    Dim tbValue As System.Web.UI.WebControls.TextBox

                    'get grid data:
                    Try
                        RowIndex = CType(CurrentGridRow.GetDataKeyValue("INDEX"), Integer)
                    Catch ex As Exception
                        RowIndex = -1
                    End Try
                    Try
                        RowFunctionDescription = CType(CurrentGridRow.FindControl("TxtFNC_DESCRIPTION"), TextBox).Text
                    Catch ex As Exception
                        RowFunctionDescription = ""
                    End Try
                    Try
                        RowMarkedForDelete = CType(CurrentGridRow.FindControl("ChkDelete"), CheckBox).Checked
                    Catch ex As Exception
                        RowMarkedForDelete = False
                    End Try
                    'i'm inserting into quantity_hrs...but dt and query has separate QUANTITY AND QTY_HRS fields!!!!!!
                    Try
                        RowQuantity = CType(CType(CurrentGridRow.FindControl("TxtQUANTITY"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowQuantity = 0
                    End Try
                    Try
                        RowRate = CType(CType(CurrentGridRow.FindControl("TxtRATE"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowRate = -1
                    End Try
                    Try
                        RowApprovedAmt = CType(CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowApprovedAmt = 0
                    End Try
                    Try
                        RowApprovedComment = CType(CurrentGridRow.FindControl("TxtAPPR_COMMENTS"), TextBox).Text
                    Catch ex As Exception
                        RowApprovedComment = ""
                    End Try
                    Try
                        RowClientComment = CType(CurrentGridRow.FindControl("TxtCLIENT_COMMENTS"), TextBox).Text
                    Catch ex As Exception
                        RowClientComment = ""
                    End Try
                    Try
                        RowQuoteAmt = CType(CType(CurrentGridRow.FindControl("HfQUOTE_AMT"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowQuoteAmt = 0
                    End Try
                    Try
                        RowApprovedNet = CType(CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowApprovedNet = 0
                    End Try

                    'NEW TAX/RATE STUFF
                    'VISIBLE FIELDS:
                    Try
                        RowApprMarkupPct = CType(CType(CurrentGridRow.FindControl("TxtAPPR_MARKUP_PCT"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowApprMarkupPct = 0
                    End Try

                    Try
                        RowApprMarkupAmt = CType(CType(CurrentGridRow.FindControl("TxtAPPR_MARKUP_AMT"), TextBox).Text, Decimal)
                    Catch ex As Exception
                        RowApprMarkupAmt = 0
                    End Try

                    Try
                        RowApprTaxCode = CType(CurrentGridRow.FindControl("TextBoxAPPR_TAX_CODE"), TextBox).Text.Trim().Replace("&nbsp;", "")
                    Catch ex As Exception
                        RowApprTaxCode = ""
                    End Try
                    'HIDDEN DATA:
                    'RowApprTaxComm As Integer = 0
                    'RowApprTaxCommOnly As Integer = 0
                    'RowApprTaxResale As Integer = 0
                    'RowApprResaleTax As Decimal = 0.0
                    'RowApprVendorTax As Decimal = 0.0
                    'RowApprTaxStatePct As Decimal = 0.0
                    'RowApprTaxCountyPct As Decimal = 0.0
                    'RowApprTaxCityPct As Decimal = 0.0

                    Try
                        RowApprTaxComm = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_COMM"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        RowApprTaxComm = 0
                    End Try
                    Try
                        RowApprTaxCommOnly = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_COMM_ONLY"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        RowApprTaxCommOnly = 0
                    End Try
                    Try
                        RowApprTaxResale = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_RESALE"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        RowApprTaxResale = 0
                    End Try
                    Try
                        RowApprResaleTax = CType(CType(CurrentGridRow.FindControl("HfAPPR_RESALE_TAX"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowApprResaleTax = 0.0
                    End Try
                    Try
                        RowApprVendorTax = CType(CType(CurrentGridRow.FindControl("HfAPPR_VENDOR_TAX"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowApprVendorTax = 0.0
                    End Try

                    'For default taxes when using unbilled (ab = no)
                    Dim RowUnbilledResaleTaxDefaultForInsert As Decimal = 0.0
                    Dim RowUnbilledVendorTaxDefaultForInsert As Decimal = 0.0
                    Try
                        RowUnbilledResaleTaxDefaultForInsert = CType(CType(CurrentGridRow.FindControl("HfUNBILLED_RESALE_TAX"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowUnbilledResaleTaxDefaultForInsert = 0.0
                    End Try
                    Try
                        RowUnbilledVendorTaxDefaultForInsert = CType(CType(CurrentGridRow.FindControl("HfUNBILLED_VENDOR_TAX"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowUnbilledVendorTaxDefaultForInsert = 0.0
                    End Try


                    Try
                        RowApprTaxStatePct = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_STATE_PCT"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowApprTaxStatePct = 0.0
                    End Try
                    Try
                        RowApprTaxCountyPct = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_COUNTY_PCT"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowApprTaxCountyPct = 0.0
                    End Try
                    Try
                        RowApprTaxCityPct = CType(CType(CurrentGridRow.FindControl("HfAPPR_TAX_CITY_PCT"), HiddenField).Value, Decimal)
                    Catch ex As Exception
                        RowApprTaxCityPct = 0.0
                    End Try
                    Try
                        RowRowType = CType(CType(CurrentGridRow.FindControl("HfROW_TYPE"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        RowRowType = 0
                    End Try
                    Try
                        RowBillingApprovalDetailID = CType(CType(CurrentGridRow.FindControl("HfBA_DTL_ID"), HiddenField).Value, Integer)
                    Catch ex As Exception
                        RowBillingApprovalDetailID = -1
                    End Try
                    'above try block will differentiate an insert and an update, should never be equal, less than zero,
                    'but in temp table of sproc, setting to minus one...

                    'If Me.RbToQuotePercent.Checked = True And IsNumeric(Me.TxtToQuotePercent.Text) = True Then
                    '    Dim m As Decimal = CType(Me.TxtToQuotePercent.Text, Decimal)
                    '    RowApprovedAmt = RowQuoteAmt * (m / 100)
                    'End If


                    If RowApprovedAmt <> 0 AndAlso RowApprovedNet <> 0 AndAlso (RowApprovedNet + RowApprMarkupAmt = RowApprovedAmt) Then 'Recalc markup

                        RowApprMarkupPct = (RowApprMarkupAmt / RowApprovedNet) * 100

                    End If

                    If RowMarkedForDelete = False Then

                        TotalForHeader += RowApprovedAmt
                        If RowBillingApprovalDetailID > 0 Then 'it is an update of an existing record in billing approval detail table
                            ba.ApprovalDetail_UpdateRow(RowBillingApprovalDetailID, RowQuantity, RowFunctionDescription, RowApprovedAmt, RowApprovedComment, RowClientComment, RowRowType, RowRate, RowApprovedNet,
                                                        RowApprMarkupPct, RowApprMarkupAmt, RowApprTaxCode, RowApprTaxComm, RowApprTaxCommOnly, RowApprTaxResale, RowApprResaleTax, RowApprVendorTax, RowApprTaxStatePct,
                                                        RowApprTaxCountyPct, RowApprTaxCityPct)
                            'update the session datatable so updates refresh properly when mainpulating temporary user roles
                            'this just makes it match up on screen when doing a postback that doesn't include refreshing the session datatable
                            If RowIndex > -1 Then

                                ba.ApprovalDetailDatatable_UpdateRow_NonUser(Me.MainDT, RowIndex, RowFunctionDescription, RowQuantity, RowRate, RowApprovedAmt, RowApprovedComment, RowClientComment, RowApprovedNet)

                            End If
                        Else 'it is an insert,
                            'an insert can be pre-defined (from Ben's sproc, which automatically came onto grid) and/or a user row added by user
                            Dim bIsUserRow As Boolean = False
                            Try
                                RowFunctionCode = CType(CType(CurrentGridRow.FindControl("HfFNC_CODE"), HiddenField).Value, String).Replace("&nbsp;", "")
                            Catch ex As Exception
                                RowFunctionCode = ""
                            End Try
                            Try
                                tbValue = CType(CurrentGridRow.FindControl("TxtFNC_CODE"), TextBox)
                                If tbValue.Visible = True Then 'shouldn't need this check, but can't hurt
                                    'textbox should only be visible for user row
                                    bIsUserRow = True
                                    RowFunctionCode = tbValue.Text
                                End If
                            Catch ex As Exception
                                RowFunctionCode = ""
                            End Try
                            'for a new insert that is not advance bill, use the unbilled tax amount from Ben's function
                            Try
                                If Me.RbAdvancedBillNo.Checked = True Then
                                    RowApprResaleTax = RowUnbilledResaleTaxDefaultForInsert
                                    RowApprVendorTax = RowUnbilledVendorTaxDefaultForInsert
                                End If
                            Catch ex As Exception

                            End Try

                            If SaveUserRows = True Then 'a true save all
                                If bIsUserRow = True Then
                                    If RowFunctionCode.Trim() <> "" Then
                                        'get defaults from function
                                        Dim fnc As String = ba.ApprovalDetail_GetBillingRateData(RowFunctionCode, Me.JobNumber, Me.JobComponentNbr, Me.BatchID, RowRate, RowRowType, RowApprMarkupPct, RowApprTaxCode, RowApprTaxComm, RowApprTaxResale, RowApprTaxStatePct, RowApprTaxCountyPct, RowApprTaxCityPct, RowApprTaxCommOnly)
                                        If fnc = "INVALID_FNC_CODE" Then
                                            Me.ShowMessage("Invalid function code")
                                            Return "INVALID_FNC_CODE"
                                        End If
                                    End If
                                End If
                                RowIsUserRow = bIsUserRow
                                If RowFunctionCode.Trim() <> "" Then
                                    'if it is not a user row, then rely on data that is already there; dont need to get defaults
                                    RowBillingApprovalDetailID = ba.ApprovalDetail_AddRow(Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr, RowFunctionCode, RowQuantity, RowFunctionDescription, RowApprovedAmt, RowApprovedComment, RowClientComment, RowRowType, RowRate, RowApprovedNet,
                                                                                          RowApprMarkupPct, RowApprMarkupAmt, RowApprTaxCode, RowApprTaxComm, RowApprTaxCommOnly, RowApprTaxResale, RowApprResaleTax, RowApprVendorTax, RowApprTaxStatePct,
                                                                                          RowApprTaxCountyPct, RowApprTaxCityPct, RowIsUserRow, StrErrorMessage)
                                End If
                            Else 'don't save user rows

                                If RowFunctionCode.Trim() <> "" And bIsUserRow = False Then 'has a function code and is not a user row
                                    'need to get/set values here!
                                    RowBillingApprovalDetailID = ba.ApprovalDetail_AddRow(Me.ApprovalID, Me.JobNumber, Me.JobComponentNbr, RowFunctionCode, RowQuantity, RowFunctionDescription, RowApprovedAmt, RowApprovedComment, RowClientComment, RowRowType, RowRate, RowApprovedNet,
                                                                                          RowApprMarkupPct, RowApprMarkupAmt, RowApprTaxCode, RowApprTaxComm, RowApprTaxCommOnly, RowApprTaxResale, RowApprResaleTax, RowApprVendorTax, RowApprTaxStatePct,
                                                                                          RowApprTaxCountyPct, RowApprTaxCityPct, RowIsUserRow, StrErrorMessage)
                                End If

                            End If

                        End If

                        'MOVED TO THE INSERT AND UPDATE SPROCS
                        'If RowBillingApprovalDetailID > 0 Then

                        '    ba.ApprovalDetail_CalculateAmounts(RowBillingApprovalDetailID)

                        'End If


                        '''Else 'make sure it gets deleted
                        '''    'DELETES ROWS NOT YET COMMITTED
                        '''    Dim r As DataRow = MainDT.Rows.Find(RowIndex)
                        '''    MainDT.Rows.Remove(r)
                        '''    'DELETE (USER) ROWS FROM DB:
                        '''    If RowBillingApprovalDetailID > 0 Then
                        '''        Dim STR As String = "HELLO!"
                        '''    End If

                    End If


                Next


                'Me.ShowDetailLevel = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked

                If Me.ShowDetailLevel = True Then

                    Me.TxtApprovalAmount.Text = TotalForHeader.ToString()

                End If

                Return ""

            End If
        Catch ex As Exception

            Return "Error saving grid: " & ex.Message.ToString()

        End Try

    End Function
    Private Sub RefreshGrid()
        Me.ClearSessionDT()
        Me.RadGridComponentList.Rebind()
    End Sub
    Private Sub ClearSessionDT()
        Session("BA_COMPONENT_DT") = Nothing
    End Sub
    Private Function MainDT_UserRowAdd(ByVal FncCode As String, ByVal FncDescription As String,
                                       ByVal Quantity As Decimal, ByVal Rate As Decimal, ByVal ApprovedAmount As Decimal,
                                       ByVal ApprovalComments As String, ByVal ClientComments As String, ByVal ApprovedNet As Decimal, ByVal RowType As Integer) As String
        Me.SetBAJC()
        Try
            Dim ba As New cBillingApproval(Session("ConnString"), Session("UserCode"))
            ba.ApprovalDetailDatatable_AddRow_User(MainDT, "", "", FncCode, FncDescription, Quantity, Rate, ApprovedAmount, ApprovalComments, ClientComments, ApprovedNet, RowType)
        Catch ex As Exception
            Return ex.Message.ToString()
        End Try
    End Function
    Private Sub RecalcTotal()
        Dim NewTotal As Decimal = 0.0
        Dim NewNetTotal As Decimal = 0.0
        Try
            For i As Integer = 0 To Me.RadGridComponentList.MasterTableView.Items.Count - 1
                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                Dim RowApprovedAmt As Decimal = 0.0
                Dim RowNetAmt As Decimal = 0.0
                Dim TbApproval As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                Dim TbNet As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox)
                If IsNumeric(TbApproval.Text) = True Then
                    RowApprovedAmt = CType(TbApproval.Text, Decimal)
                End If
                If IsNumeric(TbNet.Text) = True Then
                    RowNetAmt = CType(TbNet.Text, Decimal)
                End If
                NewTotal += RowApprovedAmt
                NewNetTotal += RowNetAmt
            Next
        Catch ex As Exception
        End Try
        Try
            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridComponentList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
            Dim tbSumTotal As System.Web.UI.WebControls.Label
            tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), Label)
            tbSumTotal.Text = FormatNumber(NewTotal, 2, True, False, False)
            Dim tbSumNet As System.Web.UI.WebControls.Label
            tbSumNet = CType(footerItem.FindControl("LabelSUM_APPR_NET"), Label)
            tbSumNet.Text = FormatNumber(NewNetTotal, 2, True, False, False)
        Catch ex As Exception
        End Try
        Try
            Me.TxtApprovalAmount.Text = FormatNumber(NewTotal, 2, True, False, False)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub SetRateQtyColumns()
        'Me.ShowQtyRateColumns = CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColQUANTITY").Display = Me.ShowQtyRateColumns
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColRATE").Display = Me.ShowQtyRateColumns

        'Me.RadGridComponentList.MasterTableView.GetColumn("ColNET_QUOTE_UNBILLED_AMT").Display = Me.ShowQtyRateColumns
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_MARKUP_PCT").Display = Me.ShowQtyRateColumns
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_MARKUP_AMT").Display = Me.ShowQtyRateColumns
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_CODE").Display = Me.ShowQtyRateColumns
        'Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_AMT").Display = Me.ShowQtyRateColumns
        'If Me.ShowQtyRateColumns = True Then
        '    Me.ImgTableSpacer.Width = New System.Web.UI.WebControls.Unit(CType(Me.HfTableWidthExpanded.Value, Integer), UnitType.Pixel)
        'Else
        '    Me.ImgTableSpacer.Width = New System.Web.UI.WebControls.Unit(CType(Me.HfTableWidthDefault.Value, Integer), UnitType.Pixel)
        'End If
        Dim ag As New cAgency(Session("ConnString"))
        Me.ApplyTaxUponBilling = ag.ApplyTaxUponBilling()

        If Me.ApplyTaxUponBilling = True Then
            Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_CODE").Display = False
            Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_AMT").Display = False
            Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_CODE").HeaderAbbr = "FIXED"
            Me.RadGridComponentList.MasterTableView.GetColumn("ColAPPR_TAX_AMT").HeaderAbbr = "FIXED"
        End If
    End Sub
    Private Sub SetGrouping()
        Try
            If Me.DropGroupBy.SelectedIndex = 0 Then
                Me.RadGridComponentList.MasterTableView.GroupByExpressions.Clear()
            ElseIf Me.DropGroupBy.SelectedIndex = 1 Then
                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_TYPE_DESC Type Group By FNC_TYPE_DESC")
                With Me.RadGridComponentList
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                End With
            ElseIf Me.DropGroupBy.SelectedIndex = 2 Then
                Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("FNC_HEADING_DESC Description Group By FNC_HEADING_DESC")
                With Me.RadGridComponentList
                    .MasterTableView.GroupByExpressions.Clear()
                    .MasterTableView.GroupByExpressions.Add(GrpExpr)
                    .MasterTableView.GroupsDefaultExpanded = True
                End With
            End If
            'Me.RadGridComponentList.Rebind()
            Me.LBtnExpandCollapse.Text = "Collapse All"
            Me.RefreshGrid()
        Catch ex As Exception

        End Try
    End Sub
    Private Sub SaveUserSettings()

        Dim AppVars As New cAppVars(cAppVars.Application.BILLING_APPROVAL)
        AppVars.getAllAppVars()

        'AppVars.setAppVar(ChkHideColumnsComments.ID, Me.ChkHideColumnsComments.Checked.ToString().ToLower())
        'AppVars.setAppVar(ChkHideColumnsDetails.ID, Me.ChkHideColumnsDetails.Checked.ToString().ToLower())
        'AppVars.setAppVar("BAJC_EnableDetails", CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked.ToString().ToLower())
        'AppVars.setAppVar("BAJC_EnableQtyRate", CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked.ToString().ToLower())
        AppVars.setAppVar(Me.DropGroupBy.ID, Me.DropGroupBy.SelectedItem.Value)

        AppVars.SaveAllAppVars()

    End Sub
    Private Sub LoadUserSettings()

        Dim AppVars As New cAppVars(cAppVars.Application.BILLING_APPROVAL)
        AppVars.getAllAppVars()

        'Me.ChkHideColumnsComments.Checked = AppVars.getAppVar(Me.ChkHideColumnsComments.ID, "String", "false") = "true"
        'Me.ChkHideColumnsDetails.Checked = AppVars.getAppVar(Me.ChkHideColumnsDetails.ID, "String", "false") = "true"
        'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableDetails"), Telerik.Web.UI.RadToolBarButton).Checked = AppVars.getAppVar("BAJC_EnableDetails", "string", "true") = "true"
        'CType(Me.RadToolbarBillingApprovalJobComponent.FindItemByValue("EnableQtyRate"), Telerik.Web.UI.RadToolBarButton).Checked = AppVars.getAppVar("BAJC_EnableQtyRate", "string", "false") = "true"
        MiscFN.RadComboBoxSetIndex(Me.DropGroupBy, AppVars.getAppVar(Me.DropGroupBy.ID, "string", ""), False)


    End Sub
    Private Sub ZeroGridAmounts(Optional ByVal DisableControls As Boolean = False)
        Try
            For i As Integer = 0 To Me.RadGridComponentList.MasterTableView.Items.Count - 1
                Try
                    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridComponentList.MasterTableView.Items(i), Telerik.Web.UI.GridDataItem)
                    Dim CurrenttbApprAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPROVED_AMT"), TextBox)
                    Dim CurrenttbApprNet As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_NET"), TextBox)
                    Dim CurrentMarkupAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_MARKUP_AMT"), TextBox)

                    'Clear Tax hidden fields:
                    Try
                        CType(CurrentGridRow.FindControl("HfAPPR_RESALE_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("HfAPPR_VENDOR_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("HfUNBILLED_RESALE_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("HfUNBILLED_VENDOR_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("HfQUOTE_RESALE_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try
                    Try
                        CType(CurrentGridRow.FindControl("HfQUOTE_VENDOR_TAX"), HiddenField).Value = "0.00"
                    Catch ex As Exception
                    End Try



                    Dim CurrentTaxAmt As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtAPPR_TAX_AMT"), TextBox)
                    Dim CurrentQuantity As System.Web.UI.WebControls.TextBox = CType(CurrentGridRow.FindControl("TxtQUANTITY"), TextBox)

                    CurrenttbApprAmt.Text = "0.00"
                    CurrenttbApprNet.Text = "0.00"
                    CurrentMarkupAmt.Text = "0.00"
                    CurrentQuantity.Text = "0.00"

                    CurrentTaxAmt.Text = "0.00"
                    If DisableControls = True Then
                        CurrenttbApprAmt.ReadOnly = True
                        CurrenttbApprNet.ReadOnly = True
                    End If
                Catch ex As Exception
                End Try
            Next
        Catch ex As Exception
        End Try
        Try
            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(RadGridComponentList.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.Footer)(0), Telerik.Web.UI.GridFooterItem)
            Dim tbSumTotal As System.Web.UI.WebControls.Label
            Dim tbSumTotalApprNet As System.Web.UI.WebControls.Label
            Dim tbSumTotalMarkupAmt As System.Web.UI.WebControls.Label
            Dim tbSumTotalTaxAmt As System.Web.UI.WebControls.Label

            tbSumTotal = CType(footerItem.FindControl("TxtSUM_APPROVED_AMT"), Label)
            tbSumTotalApprNet = CType(footerItem.FindControl("LabelSUM_APPR_NET"), Label)
            tbSumTotalMarkupAmt = CType(footerItem.FindControl("TxtSUM_APPR_MARKUP_AMT"), Label)
            tbSumTotalTaxAmt = CType(footerItem.FindControl("TxtSUM_APPR_TAX_AMT"), Label)

            tbSumTotal.Text = "0.00"
            tbSumTotalApprNet.Text = "0.00"
            tbSumTotalMarkupAmt.Text = "0.00"
            tbSumTotalTaxAmt.Text = "0.00"

            If DisableControls = True Then
                'tbSumTotal.ReadOnly = True
                'tbSumTotalApprNet.ReadOnly = True
            End If
        Catch ex As Exception
        End Try
        Try
            Me.TxtApprovalAmount.Text = "0.00"
        Catch ex As Exception

        End Try
    End Sub

#End Region

End Class
