Partial Public Class BillingApproval_View_Approvals
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const _SettingName As cAppVars.Application = cAppVars.Application.BILL_APPR_APPR_VIEW

#End Region

#Region " Enum "

    Private Enum Setting
        Month
        Year
    End Enum

#End Region

#Region " Variables "

    Private _BaEmpCode As String = ""
    Private _Month As Integer = Now.Month
    Private _Year As Integer = Now.Year
    Protected WithEvents RadComboBoxMonth As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxYear As Telerik.Web.UI.RadComboBox

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

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridBillingApproval_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBillingApproval.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Select Case e.CommandName
            Case "ViewBatch"
                Dim StrURL As String = "BillingApproval_Approval.aspx?BAID=" & e.CommandArgument
                Me.OpenWindow("View Billing Approval", StrURL)
            Case "AlertList"
                Dim StrURL As String = "BillingApproval_AlertList.aspx?P=2&BAID=" & e.CommandArgument & "&m=" & Me.RadComboBoxMonth.SelectedValue.ToString() & "&y=" & Me.RadComboBoxYear.SelectedValue.ToString()
                Me.OpenWindow("Alerts for Batch:  " & e.CommandArgument.ToString().PadLeft(6, "0"), StrURL, 500, 900)
        End Select

    End Sub
    Private Sub RadGridBillingApproval_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridBillingApproval.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            'Set alert image:
            cBillingApproval.SetAlertColumn(DirectCast(e.Item.FindControl("DivAlertStatus"), HtmlControls.HtmlControl),
                                            DirectCast(e.Item.FindControl("ImageButtonAlertStatus"), WebControls.Image),
                                            e.Item.DataItem("ALERT_STATUS").ToString())

            'set status image:
            cBillingApproval.SetStatusColumn(DirectCast(e.Item.FindControl("DivStatusColor"), HtmlControls.HtmlControl),
                                             DirectCast(e.Item.FindControl("ImageStatus"), WebControls.Image),
                                             DirectCast(e.Item.FindControl("HfAPPROVED"), WebControls.HiddenField).Value = "True",
                                             DirectCast(e.Item.FindControl("HfFINISHED"), WebControls.HiddenField).Value = "True")
            'Set tooltip:
            Try
                Dim LblJobCount As System.Web.UI.WebControls.Label = CType(e.Item.FindControl("LblJOB_COUNT"), Label)
                Me.RadToolTipManager1.TargetControls.Add(LblJobCount.ClientID, e.Item.DataItem("BA_BATCH_ID"), True)
            Catch ex As Exception
            End Try

            e.Item.Cells(5).Text = LoGlo.FormatDate(e.Item.Cells(5).Text)

        End If
    End Sub
    Private Sub RadGridBillingApproval_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBillingApproval.NeedDataSource

        Try

            If String.IsNullOrWhiteSpace(Me.RadComboBoxMonth.SelectedValue) = False Then

                Me._Month = Me.RadComboBoxMonth.SelectedValue

            End If

        Catch ex As Exception
            Me._Month = 0
        End Try
        Try

            If String.IsNullOrWhiteSpace(Me.RadComboBoxYear.SelectedValue) = False Then

                Me._Year = Me.RadComboBoxYear.SelectedValue

            End If

        Catch ex As Exception
            Me._Year = 0
        End Try
        If Me._Month = 0 Then

            Me._Month = Today.Date.Month

        End If
        If Me._Year = 0 Then

            Me._Year = Today.Date.Year

        End If

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Me.RadGridBillingApproval.DataSource = b.GetApprovalListView(_Month, _Year, _BaEmpCode)

    End Sub

    Private Sub RadComboBoxMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxMonth.SelectedIndexChanged

        With Me.RadToolTipManager1

            .TargetControls.Clear()

        End With

        Me.UpdateAppVars()
        Me.RadGridBillingApproval.Rebind()

    End Sub
    Private Sub RadComboBoxYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadComboBoxYear.SelectedIndexChanged

        With Me.RadToolTipManager1

            .TargetControls.Clear()

        End With

        Me.UpdateAppVars()
        Me.RadGridBillingApproval.Rebind()

    End Sub

    Private Sub RadToolbarBatchView_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBatchView.ButtonClick

        Select Case e.Item.Value

            Case "Refresh"

                With Me.RadToolTipManager1

                    .TargetControls.Clear()

                End With

                Me.RadGridBillingApproval.Rebind()

        End Select
    End Sub

#End Region
#Region " Page "

    Private Sub Page_Init2(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApproval)

        If Not Session("BA_EMP_CODE") = Nothing Then

            _BaEmpCode = AdvantageFramework.Security.Encryption.ASCIIDecoding(Session("BA_EMP_CODE").ToString())

        Else

            Me.CloseThisWindowAndOpenNewWindow("BillingApproval.aspx")

        End If

        Me.PageTitle = "Billing Approval - Batch Selection"
        Me.RadComboBoxMonth = CType(Me.RadToolbarBatchView.FindItemByValue("RadToolBarButtonNav").FindControl("RadComboBoxMonth"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBoxYear = CType(Me.RadToolbarBatchView.FindItemByValue("RadToolBarButtonNav").FindControl("RadComboBoxYear"), Telerik.Web.UI.RadComboBox)

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LoadMonths()
            Me.LoadYears()

            Dim AppVars As New cAppVars(_SettingName)
            AppVars.getAllAppVars()

            _Month = CType(AppVars.getAppVar(Setting.Month.ToString() & "_" & _BaEmpCode, "Integer", _Month.ToString()), Integer)
            _Year = CType(AppVars.getAppVar(Setting.Year.ToString() & "_" & _BaEmpCode, "Integer", _Year.ToString()), Integer)

            Dim Update As Boolean = False
            Try
                If IsNumeric(Request.QueryString("mm")) = True Then
                    _Month = Request.QueryString("mm")
                    Update = True
                End If
            Catch ex As Exception
            End Try
            Try
                If IsNumeric(Request.QueryString("yyyy")) = True Then
                    _Year = Request.QueryString("yyyy")
                    Update = True
                End If
            Catch ex As Exception
            End Try
            If Update = True Then

                Me.UpdateAppVars()

            End If

            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxMonth, _Month.ToString().Trim().PadLeft(2, "0"), False, False)
            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxYear, _Year.ToString().Trim().PadLeft(2, "0"), False, True)

        Else

            Select Case Me.EventArgument

                Case "Refresh"

                    Me.RadGridBillingApproval.Rebind()

            End Select

        End If
    End Sub

#End Region

    Private Sub LoadMonths(Optional ByVal M As String = "")

        With Me.RadComboBoxMonth.Items

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

    End Sub
    Private Sub LoadYears(Optional ByVal Y As String = "")

        With Me.RadComboBoxYear.Items

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

    End Sub
    Private Sub UpdateAppVars()

        Me._Month = Me.RadComboBoxMonth.SelectedValue
        Me._Year = Me.RadComboBoxYear.SelectedValue

        Dim AppVars As New cAppVars(_SettingName)
        AppVars.getAllAppVars()

        AppVars.setAppVar(Setting.Month.ToString() & "_" & _BaEmpCode, _Month, "Integer")
        AppVars.setAppVar(Setting.Year.ToString() & "_" & _BaEmpCode, _Year, "Integer")

        AppVars.SaveAllAppVars()

    End Sub

    'tooltip:
    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)
        Me.UpdateToolTip(args.Value, args.UpdatePanel)
    End Sub
    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)
        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Batch_Tooltip_JobList.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Batch_Tooltip_JobList = DirectCast(ctrl, BillingApproval_Batch_Tooltip_JobList)
        With t
            .BatchID = ArguementValue
            .GetSimpleList = True
        End With
    End Sub

#End Region

End Class
