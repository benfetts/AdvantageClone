Partial Public Class BillingApproval_View
    Inherits Webvantage.BaseChildPage

#Region " Constants "

    Private Const _SettingName As cAppVars.Application = cAppVars.Application.BILL_APPR_BATCH_VIEW

#End Region

#Region " Enum "

    Private Enum Setting
        Month
        Year
    End Enum

#End Region

#Region " Variables "

    Private _Month As Integer = Now.Month
    Private _Year As Integer = Now.Year
    Private _DataSet As New DataSet
    Protected WithEvents RadComboBoxMonth As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadComboBoxYear As Telerik.Web.UI.RadComboBox
    Protected WithEvents RadNumericTextBoxBatchId As Telerik.Web.UI.RadNumericTextBox

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

    Private Sub RadToolbarBatch_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarBatch.ButtonClick
        Select Case e.Item.Value
            Case "RefreshSearch"
                Dim BatchId As Integer = 0
                Try
                    BatchId = CType(Me.RadNumericTextBoxBatchId.Value, Integer)
                Catch ex As Exception
                    BatchId = 0
                End Try
                If BatchId > 0 Then
                    Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                    If b.BatchExists(CType(Me.RadNumericTextBoxBatchId.Value, Integer)) = True Then
                        Me.LblMSG.Visible = False
                        Dim StrURL As String = "BillingApproval_Batch.aspx?BAID=" & CType(Me.RadNumericTextBoxBatchId.Value, Integer).ToString()
                        Me.CloseThisWindowAndOpenNewWindow(StrURL, True)
                    Else
                        Me.LblMSG.Visible = True
                        Me.RadNumericTextBoxBatchId.Focus()
                    End If
                Else
                    Me.LblMSG.Visible = False
                    Me.RadNumericTextBoxBatchId.Text = ""
                    Me.RefreshGrids()
                End If

            Case "NewBatch"
                Me.OpenWindow("New Billing Approval Batch", "BillingApproval_Batch.aspx")

            Case "Bookmark"
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

                Dim qs As New AdvantageFramework.Web.QueryString()
                qs = qs.FromCurrent()
                qs.Page = "BillingApproval_View.aspx"
                qs.Add("bm", "1")

                With b
                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Billing_BillingApprovalBatch
                    .UserCode = Session("UserCode")
                    .Name = "Billing Approval Batch"
                    .Description = "Billing Approval Batch"
                    .PageURL = qs.ToString(True)
                End With

                Dim s As String = ""
                If BmMethods.SaveBookmark(b, s) = False Then
                    Me.ShowMessage(s)
                End If

        End Select
    End Sub
    Private Sub RadComboBoxMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxMonth.SelectedIndexChanged

        Me.UpdateAppVars()
        Me.RefreshGrids()

    End Sub
    Private Sub RadComboBoxYear_SelectedIndexChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxYear.SelectedIndexChanged

        Me.UpdateAppVars()
        Me.RefreshGrids()

    End Sub

#Region " My Batches Grid "

    Private Sub RadGridBillingApproval_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBillingApproval.ItemCommand

        If e.Item Is Nothing Then Exit Sub
        Dim index As Integer = e.Item.ItemIndex

        Select Case e.CommandName
            Case "ViewBatch"

                Dim StrURL As String = "BillingApproval_Batch.aspx?BAID=" & e.CommandArgument
                Me.OpenWindow("Billing Approval Batch", StrURL)

            Case "AlertList"

                Dim StrURL As String = "BillingApproval_AlertList.aspx?P=1&BAID=" & e.CommandArgument & "&m=" & Me.RadComboBoxMonth.SelectedValue.ToString() & "&y=" & Me.RadComboBoxYear.SelectedValue.ToString()
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

        End If

    End Sub
    Private Sub RadGridBillingApproval_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBillingApproval.NeedDataSource

        Me._Month = Me.RadComboBoxMonth.SelectedValue
        Me._Year = Me.RadComboBoxYear.SelectedValue

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = b.GetBatchListView(_Month, _Year, Session("UserCode"), False)
        Me.RadGridBillingApproval.DataSource = dt

    End Sub

#End Region
#Region " My Unfinished Batches Grid "

    Private Sub RadGridMyUnfinishedBatches_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridMyUnfinishedBatches.ItemCommand

        Dim index As Integer = e.Item.ItemIndex

        Select Case e.CommandName
            Case "ViewBatch"

                Dim StrURL As String = "BillingApproval_Batch.aspx?BAID=" & e.CommandArgument
                Me.OpenWindow("Billing Approval Batch", StrURL)

            Case "AlertList"

                Dim StrURL As String = "BillingApproval_AlertList.aspx?P=1&BAID=" & e.CommandArgument & "&m=" & Me.RadComboBoxMonth.SelectedValue.ToString() & "&y=" & Me.RadComboBoxYear.SelectedValue.ToString()
                Me.OpenWindow("Billing Approval Alerts", StrURL, 500, 900)

        End Select

    End Sub
    Private Sub RadGridMyUnfinishedBatches_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridMyUnfinishedBatches.ItemDataBound

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

        End If

    End Sub
    Private Sub RadGridMyUnfinishedBatches_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridMyUnfinishedBatches.NeedDataSource

        Me._Month = Me.RadComboBoxMonth.SelectedValue
        Me._Year = Me.RadComboBoxYear.SelectedValue

        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
        Dim dt As New DataTable
        dt = b.GetBatchListView(_Month, _Year, Session("UserCode"), True)
        Me.RadGridMyUnfinishedBatches.DataSource = dt
        Me.CollapsablePanelMyUnfinishedBatches.Visible = dt.Rows.Count > 0

    End Sub

#End Region
#Region " Other emp's batches grid "

    Private Sub RadGridBillingApprovalOtherUsers_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridBillingApprovalOtherUsers.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Select Case e.CommandName
            Case "ViewBatch"
                Dim StrURL As String = "BillingApproval_Batch.aspx?BAID=" & e.CommandArgument
                Me.OpenWindow("Billing Approval Batch", StrURL)
        End Select

    End Sub
    Private Sub RadGridBillingApprovalOtherUsers_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridBillingApprovalOtherUsers.ItemDataBound
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

        End If
    End Sub
    Private Sub RadGridBillingApprovalOtherUsers_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridBillingApprovalOtherUsers.NeedDataSource

        Me._Month = Me.RadComboBoxMonth.SelectedValue
        Me._Year = Me.RadComboBoxYear.SelectedValue

        Dim dt As New DataTable
        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))

        dt = b.GetBatchListViewOtherUsers(_Month, _Year, Session("UserCode"))

        Me.RadGridBillingApprovalOtherUsers.DataSource = dt
        Me.CollapsablePanelOtherInformation.Visible = dt.Rows.Count > 0

    End Sub

#End Region

#End Region
#Region " Page "

    Private Sub BillingApproval_View_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Billing_BillingApprovalBatch)

        'Me.PageTitle = "Billing Approval Batch View"

        LoGlo.PageCultureSet(Me.Page)

        Session("BA_EMP_CODE") = Nothing
        Session("BA_BATCH_GO_BACK") = Nothing

        Me.RadComboBoxMonth = CType(Me.RadToolbarBatch.FindItemByValue("RadToolBarButtonNav").FindControl("RadComboBoxMonth"), Telerik.Web.UI.RadComboBox)
        Me.RadComboBoxYear = CType(Me.RadToolbarBatch.FindItemByValue("RadToolBarButtonNav").FindControl("RadComboBoxYear"), Telerik.Web.UI.RadComboBox)

        Me.RadNumericTextBoxBatchId = CType(Me.RadToolbarBatch.FindItemByValue("RadToolBarButtonBatchId").FindControl("RadNumericTextBoxBatchId"), Telerik.Web.UI.RadNumericTextBox)

    End Sub
    Protected Sub BillingApproval_View_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.LblMSG.Visible = False
            Me.LoadMonths()
            Me.LoadYears()

            Dim AppVars As New cAppVars(_SettingName)
            AppVars.getAllAppVars()

            _Month = CType(AppVars.getAppVar(Setting.Month.ToString(), "Integer", _Month.ToString()), Integer)
            _Year = CType(AppVars.getAppVar(Setting.Year.ToString(), "Integer", _Year.ToString()), Integer)

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

            Me._Month = Me.RadComboBoxMonth.SelectedValue
            Me._Year = Me.RadComboBoxYear.SelectedValue

            Select Case Me.EventArgument
                Case "Refresh"
                    If IsNumeric(Me.RadNumericTextBoxBatchId.Value) = True Then
                        'verify it exists
                        Dim b As New cBillingApproval(Session("ConnString"), Session("UserCode"))
                        If b.BatchExists(CType(Me.RadNumericTextBoxBatchId.Value, Integer)) = True Then

                            Me.LblMSG.Visible = False
                            Dim StrURL As String = "BillingApproval_Batch.aspx?BAID=" & CType(Me.RadNumericTextBoxBatchId.Value, Integer).ToString()
                            Response.Redirect(StrURL, False)

                        Else

                            Me.LblMSG.Visible = True
                            Me.RadNumericTextBoxBatchId.Focus()

                        End If

                    Else

                        Me.LblMSG.Visible = False
                        Me.RadNumericTextBoxBatchId.Text = ""
                        Me.RadGridBillingApproval.Rebind()

                    End If
                Case "HidePopups"

                    Me.LblMSG.Visible = False

            End Select

        End If

    End Sub

#End Region

#Region " ToolTip "

    Protected Sub OnAjaxUpdate(ByVal sender As Object, ByVal args As Telerik.Web.UI.ToolTipUpdateEventArgs)

        Me.UpdateToolTip(args.Value, args.UpdatePanel)

    End Sub
    Private Sub UpdateToolTip(ByVal ArguementValue As String, ByVal panel As UpdatePanel)

        Dim ctrl As System.Web.UI.Control = Page.LoadControl("BillingApproval_Batch_Tooltip_JobList.ascx")
        panel.ContentTemplateContainer.Controls.Add(ctrl)

        Dim t As BillingApproval_Batch_Tooltip_JobList = DirectCast(ctrl, BillingApproval_Batch_Tooltip_JobList)
        With t

            .BatchID = ArguementValue

        End With

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
    Private Sub RefreshGrids()

        With Me.RadToolTipManager1

            .TargetControls.Clear()

        End With

        Me.RadGridBillingApproval.Rebind()
        Me.RadGridMyUnfinishedBatches.Rebind()
        Me.RadGridBillingApprovalOtherUsers.Rebind()

    End Sub
    Private Sub UpdateAppVars()

        Me._Month = Me.RadComboBoxMonth.SelectedValue
        Me._Year = Me.RadComboBoxYear.SelectedValue

        Dim AppVars As New cAppVars(_SettingName)
        AppVars.getAllAppVars()

        AppVars.setAppVar(Setting.Month.ToString(), _Month, "Integer")
        AppVars.setAppVar(Setting.Year.ToString(), _Year, "Integer")

        AppVars.SaveAllAppVars()

    End Sub

#End Region

End Class
