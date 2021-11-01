Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports Telerik.Web.UI
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Drawing

Partial Public Class Estimating_JobHistory
    Inherits Webvantage.BaseChildPage

#Region " Variables and Properties "

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

    Private EstimateNum As Integer = 0
    Private EstimateComp As Integer = 0
    Private EstimateQuote As Integer = 0
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Private JobCount As Integer = 0
    Private jobs As String = ""
    Private comps As String = ""
    Private AppVarsInitialized As Boolean = False
    Private QvaFilterBreakoutAllNB As Boolean = False
    Private QvaFilterBreakoutNBForFT As Boolean = False
    Private QvaFilterEmployeeTime As Boolean = False
    Private QvaFilterIncomeOnly As Boolean = False
    Private QvaFilterVendor As Boolean = False

#End Region

#Region " Page "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadTabs("ChildPage.Master")
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()

        'objects
        Dim appr As Integer = 0
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            EstNum = .EstimateNumber
            EstComp = .EstimateComponentNumber
            QuoteNum = .EstimateQuoteNumber
            RevNum = .EstimateRevisionNumber
            appr = .GetValue("appr")
            JobNum = .JobNumber
            JobComp = .JobComponentNumber

        End With

        If appr = 1 Then
            Me.BtnCopy.Attributes.Add("onclick", "return confirm('This quote is approved. Are you sure you want to save the changes?');")
        Else
            Me.BtnCopy.Attributes.Add("onclick", "")
        End If
        If Not Me.IsPostBack Then
            Me.Title = "Review Job History"
            LoadQuoteData()
            Me.pnlQva.Visible = False
            Me.btnGetHistory.Visible = False
            Me.butExport.Visible = False
            Me.BtnCopy.Visible = False
            Me.pnlJH.Visible = False
            Me.SummaryTabs.Visible = False
            Me.pnlFilter.Visible = False
            Dim ts As TimeSpan
            ts = cEmployee.TimeZoneToday.Subtract(Date.Now.AddYears(-2))
            Me.RadDatePickerJobCutOffDate.SelectedDate = cEmployee.TimeZoneToday.AddDays(ts.Days * -1)
            Me.RadDatePickerToDate.SelectedDate = cEmployee.TimeZoneToday

        End If
        Me.LoadLookups()
        If AppVarsInitialized = False Then
            Me.QvaFilterBreakoutAllNB = CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean)
            Me.QvaFilterBreakoutNBForFT = CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean)
            Me.QvaFilterEmployeeTime = CType(oAppVars.getAppVar("QvaFilterEmployeeTime", "Boolean"), Boolean)
            Me.QvaFilterIncomeOnly = CType(oAppVars.getAppVar("QvaFilterIncomeOnly", "Boolean"), Boolean)
            Me.QvaFilterVendor = CType(oAppVars.getAppVar("QvaFilterVendor", "Boolean"), Boolean)
            Me.AppVarsInitialized = True
        End If
        Me.loaddefaults()
    End Sub

    Private Sub LoadTabs(Optional ByVal strTheme As String = "ThreePointOhOatmeal.Master")
        Try

            Dim tab As Integer = 0
            Dim ThisDate As Date

            Try
                If IsNumeric(Session("EstJHTab")) = True Then
                    tab = CInt(Session("EstJHTab"))
                Else
                    tab = 0
                End If
            Catch ex As Exception
                Me.ShowMessage("err getting tab id from qs")
            End Try

            SummaryTabs.Tabs.Clear()

            Dim newTab As New Telerik.Web.UI.RadTab
            newTab.Text = "Summary"
            newTab.Value = 0
            Me.SummaryTabs.Tabs.Add(newTab)
            newTab = New Telerik.Web.UI.RadTab
            newTab.Text = "Filter"
            newTab.Value = 3
            Me.SummaryTabs.Tabs.Add(newTab)

            Dim selectTab As Telerik.Web.UI.RadTab = Me.SummaryTabs.FindTabByValue(tab)
            selectTab.Selected = True



        Catch ex As Exception
            Me.ShowMessage("err loading tabs " & ex.Message.ToString())
        End Try
    End Sub

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=division&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlJobType.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=jobtypejh&control=" & Me.TxtJobType.ClientID & "&type=jobtypejh');return false;")
    End Sub

    Private Sub LoadQuoteData()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
            If dr.HasRows = True Then
                Do While dr.Read
                    'Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
                    'Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
                    'Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
                    'Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
                    'Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
                    'Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
                    'Me.TxtClientCode.Text = dr("CL_CODE")
                    'Me.TxtDivisionCode.Text = dr("DIV_CODE")
                    'Me.TxtProductCode.Text = dr("PRD_CODE")
                    'Me.TxtClientDescription.Text = dr("CL_NAME")
                    'Me.TxtDivisionDescription.Text = dr("DIV_NAME")
                    'Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
                Loop
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        Me.lblMSG.Text = TheMSG
    End Sub

    Private Sub CloseAndRefresh()
        'Dim FunctionName As String = "RefreshFileGrid"
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstComp & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & RevNum, True)
    End Sub

    Private Function createDTJobs()
        Try
            Dim dt As DataTable
            Dim row As DataRow
            Dim jc As New Job(Session("ConnString"))
            dt = New DataTable("jobs")
            Dim job As DataColumn = New DataColumn("JOB_NUMBER")
            Dim jobcomp As DataColumn = New DataColumn("JOB_COMPONENT_NBR")
            Dim compdesc As DataColumn = New DataColumn("JOB_COMP_DESC")
            Dim compdate As DataColumn = New DataColumn("JOB_COMP_DATE")

            dt.Columns.Add(job)
            dt.Columns.Add(jobcomp)
            dt.Columns.Add(compdesc)
            dt.Columns.Add(compdate)
            row = dt.NewRow

            Dim jobsList() As String
            Dim compsList() As String
            jobsList = Me.hfjobs.Value.Split(",")
            compsList = Me.hfcomps.Value.Split(",")

            For i As Integer = 0 To jobsList.Length - 1
                If jobsList(i) <> "" Then
                    row.Item("JOB_NUMBER") = jobsList(i)
                    row.Item("JOB_COMPONENT_NBR") = compsList(i)
                    jc.GetJob(CInt(jobsList(i)), CInt(compsList(i)))
                    row.Item("JOB_COMP_DESC") = jc.JobComponent.JOB_COMP_DESC
                    row.Item("JOB_COMP_DATE") = jc.JobComponent.JOB_COMP_DATE
                    dt.Rows.Add(row)
                End If
                row = dt.NewRow
            Next

            Return dt
        Catch ex As Exception

        End Try
    End Function

    Private Sub loaddefaults()
        Try
            Dim client As New CLIENT(Session("ConnString"))
            Dim division As New DIVISION(Session("ConnString"))
            Dim product As New PRODUCT(Session("ConnString"))
            Dim jobs As New cJobs(Session("ConnString"))
            If Me.TxtClientCode.Text <> "" Then
                client.LoadByPrimaryKey(Me.TxtClientCode.Text)
                Me.TxtClientDescription.Text = client.CL_NAME
            Else
                Me.TxtClientDescription.Text = ""
            End If
            If Me.TxtClientCode.Text <> "" And Me.TxtDivisionCode.Text <> "" Then
                division.LoadByPrimaryKey(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text)
                Me.TxtDivisionDescription.Text = division.DIV_NAME
            Else
                Me.TxtDivisionDescription.Text = ""
            End If
            If Me.TxtClientCode.Text <> "" And Me.TxtDivisionCode.Text <> "" And Me.TxtProductCode.Text <> "" Then
                product.LoadByPrimaryKey(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text)
                Me.TxtProductDescription.Text = product.PRD_DESCRIPTION
            Else
                Me.TxtProductDescription.Text = ""
            End If
            If Me.TxtJobType.Text <> "" Then
                Me.TxtJobTypeDescription.Text = jobs.GetJobTypeDesc(Me.TxtJobType.Text)
            End If
        Catch ex As Exception

        End Try
    End Sub


#End Region

#Region " RadGrid "

    Private Sub RadGridJobHistory_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobHistory.ItemDataBound
        Dim header As GridHeaderItem
        Dim chk As CheckBox
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            e.Item.Cells(8).Text = LoGlo.FormatDate(CDate(e.Item.Cells(8).Text).ToShortDateString)
            e.Item.Cells(4).Text = e.Item.Cells(4).Text.PadLeft(6, "0")
            e.Item.Cells(6).Text = e.Item.Cells(6).Text.PadLeft(2, "0")
        End If
    End Sub

    Private Sub RadGridJobHistory_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobHistory.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim oValidations As cValidations = New cValidations(Session("ConnString"))
            If Me.TxtJobType.Text <> "" Then
                If oValidations.ValidateJobType(Me.TxtJobType.Text) = False Then
                    Me.lblMSG.Text = "Invalid Job Type"
                    Exit Sub
                End If
            End If
            If Me.RadDatePickerJobCutOffDate.DateInput.Text <> "" Then
                If Me.RadDatePickerJobCutOffDate.SelectedDate.HasValue = False Then
                    Me.lblMSG.Text = "Invalid Job Cutoff From Date"
                    Exit Sub
                End If
            End If
            If Me.RadDatePickerToDate.DateInput.Text <> "" Then
                If Me.RadDatePickerToDate.SelectedDate.HasValue = False Then
                    Me.lblMSG.Text = "Invalid Job Cutoff To Date"
                    Exit Sub
                End If
            End If
            If wvCDate(Me.RadDatePickerJobCutOffDate.SelectedDate) > wvCDate(Me.RadDatePickerToDate.SelectedDate) Then
                Me.lblMSG.Text = "Job Cutoff Date From date must not be greater than To date"
                Exit Sub
            End If
            Me.RadGridJobHistory.DataSource = est.GetJobsForHistory(Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.TxtJobType.Text, CDate(Me.RadDatePickerJobCutOffDate.SelectedDate), CDate(Me.RadDatePickerToDate.SelectedDate), Me.cbShowClosed.Checked, Session("UserCode"))
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridJobHistory_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridJobHistory.PreRender
        Try
            For Each item As GridDataItem In RadGridJobHistory.MasterTableView.Items
                item.Selected = True
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QvaRadgridJob_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles QvaRadgridJob.ItemDataBound
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            Dim str As String = e.Item.Cells(5).Text
            If e.Item.Cells(5).Text.Contains("12:00:00 AM") = True Then
                e.Item.Cells(5).Text = e.Item.Cells(5).Text.Replace("12:00:00 AM", "")
            End If
            If e.Item.Cells(5).Text <> "" Then
                e.Item.Cells(5).Text = LoGlo.FormatDate(CDate(e.Item.Cells(5).Text).ToShortDateString)
            End If
            e.Item.Cells(2).Text = e.Item.Cells(2).Text.PadLeft(6, "0")
            e.Item.Cells(3).Text = e.Item.Cells(3).Text.PadLeft(2, "0")
        End If
    End Sub

    Private Sub QvaRadgridJob_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles QvaRadgridJob.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim oValidations As cValidations = New cValidations(Session("ConnString"))
            If Me.TxtJobType.Text <> "" Then
                If oValidations.ValidateJobType(Me.TxtJobType.Text) = False Then
                    Me.lblMSG.Text = "Invalid Job Type"
                    Exit Sub
                End If
            End If
            If Not Me.RadDatePickerJobCutOffDate.SelectedDate Is Nothing Then
                If Me.RadDatePickerJobCutOffDate.SelectedDate.HasValue = False Then
                    Me.lblMSG.Text = "Invalid Job Cutoff From Date."
                    Exit Sub
                End If
            End If
            If Not Me.RadDatePickerToDate.SelectedDate Is Nothing Then
                If Me.RadDatePickerToDate.SelectedDate.HasValue = False Then
                    Me.lblMSG.Text = "Invalid Job Cutoff To Date."
                    Exit Sub
                End If
            End If

            Me.QvaRadgridJob.DataSource = Me.createDTJobs
        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region " QVA "

    Dim QuotedHoursTotal As Decimal = CDec(0.0)
    Dim QuotedAmountTotal As Decimal = CDec(0.0)
    Dim QuotedMarkupTotal As Decimal = CDec(0.0)
    Dim QuotedTaxTotal As Decimal = CDec(0.0)
    Dim QuotedTotal As Decimal = CDec(0.0)
    Dim QuotedTotal2 As Decimal = CDec(0.0)
    Dim ActualHoursTotal As Decimal = CDec(0.0)
    Dim ActualAmountTotal As Decimal = CDec(0.0)
    Dim ActualMarkupTotal As Decimal = CDec(0.0)
    Dim ActualTaxTotal As Decimal = CDec(0.0)
    Dim ActualAmountSubTotal As Decimal = CDec(0.0)
    Dim ActualMarkupSubTotal As Decimal = CDec(0.0)
    Dim ActualTaxSubTotal As Decimal = CDec(0.0)
    Dim ActualTotal As Decimal = CDec(0.0)
    Dim ActualTotal2 As Decimal = CDec(0.0)
    Dim NonBillableSubTotal As Decimal = CDec(0.0)
    Dim NonBillableTotal As Decimal = CDec(0.0)
    Dim OpenPONetAmountTotal As Decimal = CDec(0.0)
    Dim BilledToDateTotal As Decimal = CDec(0.0)
    Dim BilledToDateSubTotal As Decimal = CDec(0.0)
    Dim QuoteVsActualPOTotal As Decimal = CDec(0.0)
    Dim QuoteVsActualPOTotal2 As Decimal = CDec(0.0)
    Dim ActualPOVsBilled As Decimal = CDec(0.0)
    Dim ActualPOVsBilled2 As Decimal = CDec(0.0)
    Dim DecTemp As Decimal = CDec(0.0)
    Dim ApprovedAmtTotal As Decimal = CDec(0.0)
    Dim PercOfQuoteTotal As Decimal = CDec(0.0)
    Dim nbTotal As Decimal = CDec(0.0)
    Dim nbAmt As Decimal = CDec(0.0)
    Dim nbTax As Decimal = CDec(0.0)
    Dim nbMarkup As Decimal = CDec(0.0)
    Dim ActualAmt As Decimal = CDec(0.0)
    Dim ActualTax As Decimal = CDec(0.0)
    Dim ActualMarkup As Decimal = CDec(0.0)

    Private Sub RadGridQvASummary_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridQvASummary.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.Item.ItemType
            Case GridItemType.CommandItem
                If e.CommandName = "Back" Then
                    Dim sbScript As System.Text.StringBuilder = New System.Text.StringBuilder
                    With sbScript
                        .Append("<script type=""text/javascript"">")
                        .Append("window.close();</script>")
                    End With
                    Try
                        If Not Page.IsStartupScriptRegistered("QVA") Then
                            Dim str As String = sbScript.ToString
                            Page.RegisterStartupScript("QVA", str)
                        End If
                    Catch ex As Exception
                        Me.ShowMessage("Error! " & ex.Message.ToString())
                    End Try
                End If
        End Select
    End Sub

    Private Sub RadGridQvASummary_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQvASummary.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item
                If e.Item.DataItem("FNC_TYPE").ToString() <> "Subtotal" And e.Item.DataItem("FNC_TYPE").ToString() <> "" Then
                    If Me.QvaFilterBreakoutAllNB = True Then
                        nbTotal = Convert.ToDecimal(e.Item.DataItem("NBTax")) + Convert.ToDecimal(e.Item.DataItem("NBMarkup")) + Convert.ToDecimal(e.Item.DataItem("NBAmount"))
                        e.Item.Cells(16).Text = nbTotal.ToString("#,##0.00")
                        ActualAmt = (Convert.ToDecimal(e.Item.DataItem("ActualAmount")) - Convert.ToDecimal(e.Item.DataItem("NBAmount"))).ToString
                        ActualTax = (Convert.ToDecimal(e.Item.DataItem("ActualTax")) - Convert.ToDecimal(e.Item.DataItem("NBTax"))).ToString
                        ActualMarkup = (Convert.ToDecimal(e.Item.DataItem("ActualMarkup")) - Convert.ToDecimal(e.Item.DataItem("NBMarkup"))).ToString
                        e.Item.Cells(10).Text = ActualAmt.ToString("#,##0.00")
                        e.Item.Cells(12).Text = ActualTax.ToString("#,##0.00")
                        e.Item.Cells(11).Text = ActualMarkup.ToString("#,##0.00")
                        DecTemp = ActualAmt + ActualTax + ActualMarkup
                        e.Item.Cells(15).Text = DecTemp.ToString("#,##0.00")
                        ActualAmountTotal += ActualAmt
                        ActualMarkupTotal += ActualMarkup
                        ActualTaxTotal += ActualTax
                        ActualAmountSubTotal += ActualAmt
                        ActualMarkupSubTotal += ActualMarkup
                        ActualTaxSubTotal += ActualTax
                        NonBillableSubTotal += nbTotal
                    ElseIf Me.QvaFilterBreakoutNBForFT = True Then
                        If (Me.QvaFilterEmployeeTime = True And e.Item.DataItem("FNC_TYPE").ToString() = "E") Or (Me.QvaFilterIncomeOnly = True And e.Item.DataItem("FNC_TYPE").ToString() = "I") Or (Me.QvaFilterVendor = True And e.Item.DataItem("FNC_TYPE").ToString() = "V") Then
                            ActualAmt = (Convert.ToDecimal(e.Item.DataItem("ActualAmount")) - Convert.ToDecimal(e.Item.DataItem("NBAmount"))).ToString("#,##0.00")
                            ActualTax = (Convert.ToDecimal(e.Item.DataItem("ActualTax")) - Convert.ToDecimal(e.Item.DataItem("NBTax"))).ToString("#,##0.00")
                            ActualMarkup = (Convert.ToDecimal(e.Item.DataItem("ActualMarkup")) - Convert.ToDecimal(e.Item.DataItem("NBMarkup"))).ToString("#,##0.00")
                            nbTotal = Convert.ToDecimal(e.Item.DataItem("NBTax")) + Convert.ToDecimal(e.Item.DataItem("NBMarkup")) + Convert.ToDecimal(e.Item.DataItem("NBAmount"))
                            e.Item.Cells(16).Text = nbTotal.ToString("#,##0.00")
                            NonBillableSubTotal += nbTotal
                        Else
                            ActualAmt = (Convert.ToDecimal(e.Item.DataItem("ActualAmount")))
                            ActualTax = (Convert.ToDecimal(e.Item.DataItem("ActualTax")))
                            ActualMarkup = (Convert.ToDecimal(e.Item.DataItem("ActualMarkup")))
                        End If
                        e.Item.Cells(10).Text = ActualAmt.ToString("#,##0.00")
                        e.Item.Cells(12).Text = ActualTax.ToString("#,##0.00")
                        e.Item.Cells(11).Text = ActualMarkup.ToString("#,##0.00")
                        DecTemp = ActualAmt + ActualTax + ActualMarkup
                        e.Item.Cells(15).Text = DecTemp.ToString("#,##0.00") 'Actual Total column
                        ActualAmountTotal += ActualAmt
                        ActualMarkupTotal += ActualMarkup
                        ActualTaxTotal += ActualTax
                        ActualAmountSubTotal += ActualAmt
                        ActualMarkupSubTotal += ActualMarkup
                        ActualTaxSubTotal += ActualTax
                    Else
                        ActualAmountTotal += Convert.ToDecimal(e.Item.DataItem("ActualAmount"))
                        ActualMarkupTotal += Convert.ToDecimal(e.Item.DataItem("ActualMarkup"))
                        ActualTaxTotal += Convert.ToDecimal(e.Item.DataItem("ActualTax"))
                        ActualAmountSubTotal += Convert.ToDecimal(e.Item.DataItem("ActualAmount"))
                        ActualMarkupSubTotal += Convert.ToDecimal(e.Item.DataItem("ActualMarkup"))
                        ActualTaxSubTotal += Convert.ToDecimal(e.Item.DataItem("ActualTax"))
                        DecTemp = Convert.ToDecimal(e.Item.DataItem("ActualTax")) + Convert.ToDecimal(e.Item.DataItem("ActualMarkup")) + Convert.ToDecimal(e.Item.DataItem("ActualAmount"))
                        e.Item.Cells(15).Text = DecTemp.ToString("#,##0.00")
                    End If
                    DecTemp = Convert.ToDecimal(e.Item.DataItem("QuotedTax")) + Convert.ToDecimal(e.Item.DataItem("QuotedMarkup")) + Convert.ToDecimal(e.Item.DataItem("QuotedAmount"))
                    e.Item.Cells(9).Text = DecTemp.ToString("#,##0.00")

                    DecTemp = Convert.ToDecimal(e.Item.DataItem("POTotal")) - Convert.ToDecimal(e.Item.DataItem("POApplied"))
                    e.Item.Cells(17).Text = DecTemp.ToString("#,##0.00")

                    DecTemp = Convert.ToDecimal(e.Item.DataItem("BilledToDate")) + Convert.ToDecimal(e.Item.DataItem("AdvBilled"))
                    e.Item.Cells(19).Text = DecTemp.ToString("#,##0.00")

                    DecTemp = Convert.ToDecimal(e.Item.Cells(9).Text) - (Convert.ToDecimal(e.Item.Cells(15).Text) + Convert.ToDecimal(e.Item.Cells(17).Text))
                    e.Item.Cells(20).Text = DecTemp.ToString("#,##0.00")

                    DecTemp = (Convert.ToDecimal(e.Item.Cells(15).Text) + Convert.ToDecimal(e.Item.Cells(17).Text)) - (Convert.ToDecimal(e.Item.DataItem("BilledToDate")) + Convert.ToDecimal(e.Item.DataItem("AdvBilled")))
                    e.Item.Cells(21).Text = DecTemp.ToString("#,##0.00")

                    QuotedHoursTotal += Convert.ToDecimal(e.Item.DataItem("QuotedQtyHrs"))

                    QuotedAmountTotal += Convert.ToDecimal(e.Item.DataItem("QuotedAmount"))
                    QuotedMarkupTotal += Convert.ToDecimal(e.Item.DataItem("QuotedMarkup"))
                    QuotedTaxTotal += Convert.ToDecimal(e.Item.DataItem("QuotedTax"))
                    QuotedTotal += Convert.ToDecimal(e.Item.Cells(9).Text)
                    QuotedTotal2 += Convert.ToDecimal(e.Item.Cells(9).Text)
                    ActualHoursTotal += Convert.ToDecimal(e.Item.DataItem("ActualHours"))
                    ' PercOfQuoteTotal += Convert.ToDecimal(e.Item.DataItem("PERCENT_QUOTE"))
                    ActualTotal += Convert.ToDecimal(e.Item.Cells(15).Text)
                    ActualTotal2 += Convert.ToDecimal(e.Item.Cells(15).Text)
                    NonBillableTotal += Convert.ToDecimal(e.Item.Cells(16).Text)
                    OpenPONetAmountTotal += Convert.ToDecimal(e.Item.Cells(17).Text)

                    ApprovedAmtTotal += Convert.ToDecimal(e.Item.DataItem("APPROVED_AMT"))
                    BilledToDateTotal += Convert.ToDecimal(e.Item.DataItem("BilledToDate")) + Convert.ToDecimal(e.Item.DataItem("AdvBilled"))
                    BilledToDateSubTotal += Convert.ToDecimal(e.Item.DataItem("BilledToDate")) + Convert.ToDecimal(e.Item.DataItem("AdvBilled"))

                    QuoteVsActualPOTotal += Convert.ToDecimal(e.Item.Cells(20).Text)
                    QuoteVsActualPOTotal2 += Convert.ToDecimal(e.Item.Cells(20).Text)

                    ActualPOVsBilled += Convert.ToDecimal(e.Item.Cells(21).Text)
                    ActualPOVsBilled2 += Convert.ToDecimal(e.Item.Cells(21).Text)
                ElseIf e.Item.DataItem("FNC_TYPE").ToString() = "Subtotal" Then
                    e.Item.Cells(9).Text = "<div align='right'>" & QuotedTotal2.ToString("#,##0.00").Trim & "</div>"
                    QuotedTotal2 = CDec(0.0)
                    e.Item.Cells(15).Text = "<div align='right'>" & ActualTotal2.ToString("#,##0.00").Trim & "</div>"
                    ActualTotal2 = CDec(0.0)
                    e.Item.Cells(20).Text = "<div align='right'>" & QuoteVsActualPOTotal2.ToString("#,##0.00").Trim & "</div>"
                    QuoteVsActualPOTotal2 = CDec(0.0)
                    e.Item.Cells(21).Text = "<div align='right'>" & ActualPOVsBilled2.ToString("#,##0.00").Trim & "</div>"
                    ActualPOVsBilled2 = CDec(0.0)
                    e.Item.Cells(10).Text = "<div align='right'>" & ActualAmountSubTotal.ToString("#,##0.00").Trim & "</div>"
                    ActualAmountSubTotal = CDec(0.0)
                    e.Item.Cells(11).Text = "<div align='right'>" & ActualMarkupSubTotal.ToString("#,##0.00").Trim & "</div>"
                    ActualMarkupSubTotal = CDec(0.0)
                    e.Item.Cells(12).Text = "<div align='right'>" & ActualTaxSubTotal.ToString("#,##0.00").Trim & "</div>"
                    ActualTaxSubTotal = CDec(0.0)
                    e.Item.Cells(16).Text = "<div align='right'>" & NonBillableSubTotal.ToString("#,##0.00").Trim & "</div>"
                    NonBillableSubTotal = CDec(0.0)
                    e.Item.Cells(19).Text = "<div align='right'>" & BilledToDateSubTotal.ToString("#,##0.00").Trim & "</div>"
                    BilledToDateSubTotal = CDec(0.0)
                    Dim chk As CheckBox
                    Dim dataBoundItem As GridDataItem = e.Item
                    chk = CType(dataBoundItem("ColumnClientSelect").Controls(0), CheckBox)
                    chk.Visible = False
                    e.Item.Cells(2).Text = "&nbsp;"
                ElseIf e.Item.DataItem("FNC_TYPE").ToString() = "" Then
                    Dim chk2 As CheckBox
                    Dim dataBoundItem2 As GridDataItem = e.Item
                    chk2 = CType(dataBoundItem2("ColumnClientSelect").Controls(0), CheckBox)
                    chk2.Visible = False
                    e.Item.Cells(2).Text = "&nbsp;"
                End If

            Case GridItemType.Footer
                Dim i As Int16
                For i = 0 To e.Item.Cells.Count - 1
                    e.Item.Cells(i).Font.Bold = True
                    e.Item.Cells(i).ForeColor = Color.Black
                Next
                If QuotedHoursTotal > 0 Then
                    PercOfQuoteTotal = (ActualHoursTotal / QuotedHoursTotal) * 100
                Else
                    PercOfQuoteTotal = 0.0
                End If
                e.Item.Cells(5).Text = "<div align='right'>" & QuotedAmountTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(6).Text = "<div align='right'>" & QuotedMarkupTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(7).Text = "<div align='right'>" & QuotedTaxTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(8).Text = "<div align='right'>" & QuotedHoursTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(9).Text = "<div align='right'>" & QuotedTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(10).Text = "<div align='right'>" & ActualAmountTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(11).Text = "<div align='right'>" & ActualMarkupTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(12).Text = "<div align='right'>" & ActualTaxTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(13).Text = "<div align='right'>" & ActualHoursTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(14).Text = "<div align='right'>" & PercOfQuoteTotal.ToString("#,##0.00").Trim & "%</div>"
                e.Item.Cells(15).Text = "<div align='right'>" & ActualTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(16).Text = "<div align='right'>" & NonBillableTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(17).Text = "<div align='right'>" & OpenPONetAmountTotal.ToString("#,##0.00").Trim & "</div>"

                'If detail is 0, then try header
                If ApprovedAmtTotal < 0.01 And Me.JobNum > 0 And Me.JobComp > 0 Then
                    ApprovedAmtTotal = getApprovedHeaderAmount(Me.JobNum, Me.JobComp)
                End If
                e.Item.Cells(18).Text = "<div align='right'>" & ApprovedAmtTotal.ToString("#,##0.00").Trim & "</div>"

                e.Item.Cells(19).Text = "<div align='right'>" & BilledToDateTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(20).Text = "<div align='right'>" & QuoteVsActualPOTotal.ToString("#,##0.00").Trim & "</div>"
                e.Item.Cells(21).Text = "<div align='right'>" & ActualPOVsBilled.ToString("#,##0.00").Trim & "</div>"

                'Case GridItemType.CommandItem
                '    If Me.JobNum > 0 And Me.JobCompNum > 0 Then
                '        Dim oJob As New Job(Session("ConnString"))
                '        oJob.GetJob(JobNum, JobCompNum)
                '        Dim lab As System.Web.UI.WebControls.Label
                '        lab = e.Item.FindControl("lblJobNumber")
                '        lab.Text = JobNum.ToString.PadLeft(6, "0") & " - " & oJob.JOB_DESC
                '        lab = e.Item.FindControl("lblJobCompNum")
                '        lab.Text = JobCompNum.ToString.PadLeft(2, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC
                '    End If
        End Select

    End Sub

    Private Sub RadGridQvASummary_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQvASummary.NeedDataSource
        Dim cts As cTimeSheet = New cTimeSheet(Session("ConnString"))
        Dim dr As SqlDataReader
        Dim dt As DataTable
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)

        'dr = cts.GetQuoteVsActualSummary(Session("QvAFilterJob"), Session("QvAFilterJobComp"), Session("UserCode"))
        dr = cts.GetQuoteVsActualSummaryJobHistory(0, 0, Session("UserCode"), Me.TxtJobType.Text, Me.RadDatePickerJobCutOffDate.SelectedDate, Me.RadDatePickerToDate.SelectedDate, Me.TxtClientCode.Text, Me.TxtDivisionCode.Text, Me.TxtProductCode.Text, Me.cbShowClosed.Checked, Me.hfjobs.Value, Me.hfcomps.Value, Me.hfcount.Value)
        dt = createSummaryTable(dr)
        Me.RadGridQvASummary.DataSource = dt
    End Sub

    Private Function createSummaryTable(ByVal dr As SqlDataReader)
        Dim dt As DataTable
        Dim row As DataRow
        Dim prevFncType, fncType, fncCode, fncDesc As String


        Dim QQuoteAmountGrpTotal, QuoteAmountGrpTotal As Decimal

        Dim QQuotedMarkupTotal, QuotedMarkupTotal As Decimal
        Dim QQuotedTaxTotal, QuotedTaxTotal As Decimal
        '   Dim QQuotedTotalTotal, QuotedTotalTotal As Decimal
        Dim QActualHoursTotal, ActualHoursTotal As Decimal
        Dim QActualAmountTotal, ActualAmountTotal As Decimal
        Dim QActualMarkupTotal, ActualMarkupTotal As Decimal
        Dim QActualTaxTotal, ActualTaxTotal As Decimal
        Dim QActualTotalTotal, ActualTotalTotal As Decimal
        Dim QOpenPONetAmtTotal, OpenPONetAmtTotal As Decimal
        Dim QBilledToDateTotal, BilledToDateTotal As Decimal
        Dim QQuotedvsActualPOTotal, QuotedvsActualPOTotal As Decimal
        Dim QActualPOvsBilledTotal, ActualPOvsBilledTotal As Decimal
        Dim QPERCENT_QUOTETOTAL, PERCENT_QUOOTETOTAL As Decimal
        Dim QBillingApprovedPendingTotlal, BillingApprovedPendingTotlal As Decimal

        Dim QoutQtyHrs, QuotedHrsGrpTotal As Decimal
        Dim ActQtyHrs, ActualHrsGrpTotal As Decimal
        dt = New DataTable("summary")
        Dim funccode As DataColumn = New DataColumn("FNC_CODE")
        Dim funcdesc As DataColumn = New DataColumn("FNC_DESC")
        Dim functype As DataColumn = New DataColumn("FNC_TYPE")
        Dim QuotedQtyHrs As DataColumn = New DataColumn("QuotedQtyHrs")
        Dim QuotedAmount As DataColumn = New DataColumn("QuotedAmount")
        Dim QuotedMarkup As DataColumn = New DataColumn("QuotedMarkup")
        Dim QuotedTax As DataColumn = New DataColumn("QuotedTax")
        Dim QuotedTotal As DataColumn = New DataColumn("QuotedTotal")
        Dim ActualHours As DataColumn = New DataColumn("ActualHours")
        Dim ActualAmount As DataColumn = New DataColumn("ActualAmount")
        Dim ActualMarkup As DataColumn = New DataColumn("ActualMarkup")
        Dim ActualTax As DataColumn = New DataColumn("ActualTax")
        Dim ActualTotal As DataColumn = New DataColumn("ActualTotal")
        Dim OpenPONetAmt As DataColumn = New DataColumn("OpenPONetAmt")
        Dim BilledToDate As DataColumn = New DataColumn("BilledToDate")
        Dim QuotedvsActualPO As DataColumn = New DataColumn("QuotedvsActualPO")
        Dim ActualPOvsBilled As DataColumn = New DataColumn("ActualPOvsBilled")
        Dim Qva As DataColumn = New DataColumn("Qva")
        Dim Avb As DataColumn = New DataColumn("Avb")
        Dim QvaPO As DataColumn = New DataColumn("QvaPO")
        Dim AvbPO As DataColumn = New DataColumn("AvbPO")
        Dim NBActualTotal As DataColumn = New DataColumn("NBActualTotal")
        Dim AdvBilled As DataColumn = New DataColumn("AdvBilled")
        Dim POTotal As DataColumn = New DataColumn("POTotal")
        Dim POApplied As DataColumn = New DataColumn("POApplied")
        Dim NBTax As DataColumn = New DataColumn("NBTax")
        Dim NBMarkup As DataColumn = New DataColumn("NBMarkup")
        Dim NBAmount As DataColumn = New DataColumn("NBAmount")
        Dim APPROVED_AMT As DataColumn = New DataColumn("APPROVED_AMT")
        Dim PERCENT_QUOTE As DataColumn = New DataColumn("PERCENT_QUOTE")
        Try
            QuoteAmountGrpTotal = 0.0
            QuotedMarkupTotal = 0.0
            QuotedTaxTotal = 0.0
            'QuotedTotalTotal = 0.0
            ActualHoursTotal = 0.0
            ActualAmountTotal = 0.0
            ActualMarkupTotal = 0.0
            ActualTaxTotal = 0.0
            ActualTotalTotal = 0.0
            OpenPONetAmtTotal = 0.0
            BilledToDateTotal = 0.0
            QuotedvsActualPOTotal = 0.0
            ActualPOvsBilledTotal = 0.0
            PERCENT_QUOOTETOTAL = 0.0
            BillingApprovedPendingTotlal = 0.0

            QuotedHrsGrpTotal = 0.0
            ActualHrsGrpTotal = 0.0
            prevFncType = ""

            dt.Columns.Add(funccode)
            dt.Columns.Add(funcdesc)
            dt.Columns.Add(functype)
            dt.Columns.Add(QuotedQtyHrs)
            dt.Columns.Add(QuotedAmount)
            dt.Columns.Add(QuotedMarkup)
            dt.Columns.Add(QuotedTax)
            dt.Columns.Add(QuotedTotal)
            dt.Columns.Add(ActualHours)
            dt.Columns.Add(ActualAmount)
            dt.Columns.Add(ActualMarkup)
            dt.Columns.Add(ActualTax)
            dt.Columns.Add(ActualTotal)
            dt.Columns.Add(OpenPONetAmt)
            dt.Columns.Add(BilledToDate)
            dt.Columns.Add(QuotedvsActualPO)
            dt.Columns.Add(ActualPOvsBilled)
            dt.Columns.Add(Qva)
            dt.Columns.Add(Avb)
            dt.Columns.Add(QvaPO)
            dt.Columns.Add(AvbPO)
            dt.Columns.Add(NBActualTotal)
            dt.Columns.Add(AdvBilled)
            dt.Columns.Add(POTotal)
            dt.Columns.Add(POApplied)
            dt.Columns.Add(NBTax)
            dt.Columns.Add(NBMarkup)
            dt.Columns.Add(NBAmount)
            dt.Columns.Add(APPROVED_AMT)
            dt.Columns.Add(PERCENT_QUOTE)
            row = dt.NewRow


            Do While dr.Read
                fncType = dr.GetString(2)
                QoutQtyHrs = dr.GetDecimal(3)
                QQuoteAmountGrpTotal = dr.GetDecimal(4)
                QQuotedMarkupTotal = dr.GetDecimal(5)
                QQuotedTaxTotal = dr.GetDecimal(6)
                ' QQuotedTotalTotal = dr.GetDecimal(7)
                QActualHoursTotal = dr.GetDecimal(8)
                QActualAmountTotal = dr.GetDecimal(9)
                QActualMarkupTotal = dr.GetDecimal(10)
                QActualTaxTotal = dr.GetDecimal(11)
                QActualTotalTotal = dr.GetDecimal(12)
                QOpenPONetAmtTotal = dr.GetDecimal(13)
                QBilledToDateTotal = dr.GetDecimal(14)
                QQuotedvsActualPOTotal = dr.GetDecimal(15)
                QActualPOvsBilledTotal = dr.GetDecimal(16)
                QPERCENT_QUOTETOTAL = dr.GetDecimal(29)
                QBillingApprovedPendingTotlal = dr.GetDecimal(28)

                ActQtyHrs = dr.GetDecimal(8)

                If fncType <> prevFncType Then
                    If prevFncType <> "" Then
                        row.Item("FNC_TYPE") = "Subtotal"
                        If QuotedHrsGrpTotal > 0 Then
                            PERCENT_QUOOTETOTAL = (ActualHrsGrpTotal / QuotedHrsGrpTotal) * 100
                        Else
                            PERCENT_QUOOTETOTAL = 0.0
                        End If
                        row.Item("QuotedAmount") = QuoteAmountGrpTotal.ToString("#,##0.00")
                        row.Item("QuotedQtyHrs") = QuotedHrsGrpTotal.ToString("#,##0.00")
                        row.Item("QuotedMarkup") = QuotedMarkupTotal.ToString("#,##0.00")
                        row.Item("QuotedTax") = QuotedTaxTotal.ToString("#,##0.00")
                        '  row.Item("QuotedTotal") = QuotedTotalTotal.ToString("#,##0.00")
                        row.Item("ActualHours") = ActualHrsGrpTotal.ToString("#,##0.00")
                        row.Item("ActualAmount") = ActualAmountTotal.ToString("#,##0.00")
                        row.Item("ActualMarkup") = ActualMarkupTotal.ToString("#,##0.00")
                        row.Item("ActualTax") = ActualTaxTotal.ToString("#,##0.00")
                        row.Item("ActualTotal") = ActualTotalTotal.ToString("#,##0.00")
                        row.Item("OpenPONetAmt") = OpenPONetAmtTotal.ToString("#,##0.00")
                        row.Item("BilledToDate") = BilledToDateTotal.ToString("#,##0.00")
                        row.Item("QuotedvsActualPO") = QuotedvsActualPOTotal.ToString("#,##0.00")
                        row.Item("ActualPOvsBilled") = ActualPOvsBilledTotal.ToString("#,##0.00")
                        row.Item("APPROVED_AMT") = BillingApprovedPendingTotlal.ToString("#,##0.00")
                        row.Item("PERCENT_QUOTE") = PERCENT_QUOOTETOTAL.ToString("#,##0.00")


                        'Add row for space
                        dt.Rows.Add(row)
                        row = dt.NewRow
                        row.Item("FNC_TYPE") = ""

                        'Add another row for next detail row of data
                        dt.Rows.Add(row)
                        row = dt.NewRow
                    End If

                    QuotedHrsGrpTotal = QoutQtyHrs
                    QuoteAmountGrpTotal = QQuoteAmountGrpTotal
                    ActualHrsGrpTotal = ActQtyHrs
                    QuotedMarkupTotal = QQuotedMarkupTotal
                    QuotedTaxTotal = QQuotedTaxTotal
                    ' QuotedTotalTotal = QQuotedTotalTotal
                    ActualHoursTotal = QActualHoursTotal
                    ActualAmountTotal = QActualAmountTotal
                    ActualMarkupTotal = QActualMarkupTotal
                    ActualTaxTotal = QActualTaxTotal
                    ActualTotalTotal = QActualTotalTotal
                    OpenPONetAmtTotal = QOpenPONetAmtTotal
                    BilledToDateTotal = QBilledToDateTotal
                    QuotedvsActualPOTotal = QQuotedvsActualPOTotal
                    ActualPOvsBilledTotal = QActualPOvsBilledTotal
                    PERCENT_QUOOTETOTAL = QPERCENT_QUOTETOTAL
                    BillingApprovedPendingTotlal = QBillingApprovedPendingTotlal

                    prevFncType = fncType

                Else
                    QuoteAmountGrpTotal = QuoteAmountGrpTotal + QQuoteAmountGrpTotal
                    QuotedHrsGrpTotal = QuotedHrsGrpTotal + QoutQtyHrs
                    ActualHrsGrpTotal = ActualHrsGrpTotal + ActQtyHrs
                    QuotedMarkupTotal += QQuotedMarkupTotal
                    QuotedTaxTotal += QQuotedTaxTotal
                    '   QuotedTotalTotal += QQuotedTotalTotal
                    ActualHoursTotal += QActualHoursTotal
                    ActualAmountTotal += QActualAmountTotal
                    ActualMarkupTotal += QActualMarkupTotal
                    ActualTaxTotal += QActualTaxTotal
                    ActualTotalTotal += QActualTotalTotal
                    OpenPONetAmtTotal += QOpenPONetAmtTotal
                    BilledToDateTotal += QBilledToDateTotal
                    QuotedvsActualPOTotal += QQuotedvsActualPOTotal
                    ActualPOvsBilledTotal += QActualPOvsBilledTotal
                    PERCENT_QUOOTETOTAL += QPERCENT_QUOTETOTAL
                    BillingApprovedPendingTotlal += QBillingApprovedPendingTotlal

                End If

                row.Item("FNC_TYPE") = fncType
                row.Item("FNC_CODE") = dr.GetString(0)
                row.Item("FNC_DESC") = dr.GetString(1)
                row.Item("QuotedQtyHrs") = QoutQtyHrs.ToString("#,##0.00")
                row.Item("QuotedAmount") = QQuoteAmountGrpTotal.ToString("#,##0.00") 'dr.GetDecimal(4).ToString("#,##0.00")
                row.Item("QuotedMarkup") = QQuotedMarkupTotal.ToString("#,##0.00")
                row.Item("QuotedTax") = QQuotedTaxTotal.ToString("#,##0.00")
                '    row.Item("QuotedTotal") = QQuotedTotalTotal.ToString("#,##0.00")

                row.Item("ActualHours") = ActQtyHrs.ToString("#,##0.00")

                row.Item("ActualAmount") = QActualAmountTotal.ToString("#,##0.00")
                row.Item("ActualMarkup") = QActualMarkupTotal.ToString("#,##0.00")
                row.Item("ActualTax") = QActualTaxTotal.ToString("#,##0.00")
                row.Item("ActualTotal") = QActualTotalTotal.ToString("#,##0.00")
                row.Item("OpenPONetAmt") = QOpenPONetAmtTotal.ToString("#,##0.00")
                row.Item("BilledToDate") = QBilledToDateTotal.ToString("#,##0.00")
                row.Item("QuotedvsActualPO") = QQuotedvsActualPOTotal.ToString("#,##0.00")
                row.Item("ActualPOvsBilled") = QActualPOvsBilledTotal.ToString("#,##0.00")
                row.Item("Qva") = dr.GetDecimal(17)
                row.Item("Avb") = dr.GetDecimal(18)
                row.Item("QvaPO") = dr.GetDecimal(19)
                row.Item("AvbPO") = dr.GetDecimal(20)
                row.Item("NBActualTotal") = dr.GetDecimal(21)
                row.Item("AdvBilled") = dr.GetDecimal(22)
                row.Item("POTotal") = dr.GetDecimal(23)
                row.Item("POApplied") = dr.GetDecimal(24)
                row.Item("NBTax") = dr.GetDecimal(25)
                row.Item("NBMarkup") = dr.GetDecimal(26)
                row.Item("NBAmount") = dr.GetDecimal(27)
                row.Item("APPROVED_AMT") = QBillingApprovedPendingTotlal.ToString("#,##0.00")
                row.Item("PERCENT_QUOTE") = QPERCENT_QUOTETOTAL.ToString("#,##0.00") 'dr.Item("PERCENT_QUOTE").ToString("#,##0.00")
                dt.Rows.Add(row)
                row = dt.NewRow
            Loop

            row.Item("FNC_TYPE") = "Subtotal"
            row.Item("QuotedAmount") = QuoteAmountGrpTotal.ToString("#,##0.00")
            row.Item("QuotedQtyHrs") = QuotedHrsGrpTotal.ToString("#,##0.00")
            row.Item("ActualHours") = ActualHrsGrpTotal.ToString("#,##0.00")
            '***************************************
            row.Item("QuotedMarkup") = QuotedMarkupTotal.ToString("#,##0.00")
            row.Item("QuotedTax") = QuotedTaxTotal.ToString("#,##0.00")
            ' row.Item("QuotedTotal") = QuotedTotalTotal.ToString("#,##0.00")
            row.Item("ActualAmount") = ActualAmountTotal.ToString("#,##0.00")
            row.Item("ActualMarkup") = ActualMarkupTotal.ToString("#,##0.00")
            row.Item("ActualTax") = ActualTaxTotal.ToString("#,##0.00")
            row.Item("ActualTotal") = ActualTotalTotal.ToString("#,##0.00")
            row.Item("OpenPONetAmt") = OpenPONetAmtTotal.ToString("#,##0.00")
            row.Item("BilledToDate") = BilledToDateTotal.ToString("#,##0.00")
            row.Item("QuotedvsActualPO") = QuotedvsActualPOTotal.ToString("#,##0.00")
            row.Item("ActualPOvsBilled") = ActualPOvsBilledTotal.ToString("#,##0.00")
            row.Item("APPROVED_AMT") = BillingApprovedPendingTotlal.ToString("#,##0.00")
            row.Item("PERCENT_QUOTE") = PERCENT_QUOOTETOTAL.ToString("#,##0.00")

            '***************************************
            dt.Rows.Add(row)
            row = dt.NewRow

            dr.Close()
            Return dt

        Catch ex As Exception
            lblMSG.Text = ex.Message.Trim
        End Try

    End Function

    Private Function getApprovedHeaderAmount(ByVal jobNbr As String, ByVal jobComp As String) As Decimal
        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader
        Dim approvedAmount As Decimal = 0.0

        SQL_STRING = " SELECT ISNULL(SUM(APPROVED_AMT), 0) AS APPROVED_AMT FROM BILL_APPR_HDR "
        SQL_STRING = SQL_STRING & " WHERE JOB_NUMBER = '" & jobNbr & "' And JOB_COMPONENT_NBR = '" & jobComp & "'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:QuoteVsActualSummaryPopup Routine:getApprovedHeaderAmount", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            dr.Read()
            approvedAmount = dr.GetDecimal(0)
        End If

        Return approvedAmount

    End Function

    Private Sub RadGridQvASummary_PreRender(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGridQvASummary.PreRender
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()

        'If Session("QvaFilterBreakoutAllNB") = True Or Session("QvaFilterBreakoutNBForFT") = True Then
        If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then
            Me.RadGridQvASummary.Columns(13).Visible = True
        End If
    End Sub

    Private Sub Estimating_JobHistory_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete
        Try
            Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
            oAppVars.getAllAppVars()

            'If Session("QvaFilterBreakoutAllNB") = True Or Session("QvaFilterBreakoutNBForFT") = True Then
            If CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean) = True Or CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean) = True Then
                Me.RadGridQvASummary.MasterTableView.GetColumn("NBActualTotal").Display = True
            Else
                Me.RadGridQvASummary.MasterTableView.GetColumn("NBActualTotal").Display = False
            End If
            'If Me.JobNum > 0 And Me.JobCompNum > 0 Then
            '    Dim oJob As New Job(Session("ConnString"))
            '    oJob.GetJob(JobNum, JobCompNum)
            '    Dim sb As New System.Text.StringBuilder
            '    With sb
            '        .Append("<div align=""left"">")
            '        .Append("<strong>&nbsp;Job:&nbsp;&nbsp;</strong>")
            '        .Append(JobNum.ToString.PadLeft(6, "0") & " - " & oJob.JOB_DESC)
            '        .Append("<br />")
            '        .Append("<strong>&nbsp;Job Component:&nbsp;&nbsp;</strong>")
            '        .Append(JobCompNum.ToString.PadLeft(2, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC)
            '        .Append("</div>")
            '        '.Append("")
            '        '.Append("")
            '        '.Append("")
            '    End With
            '    Me.RadGridQvASummary.MasterTableView.Caption = sb.ToString()
            '    'Dim lab As System.Web.UI.WebControls.Label
            '    'lab = e.Item.FindControl("lblJobNumber")
            '    'lab.Text = JobNum.ToString.PadLeft(6, "0") & " - " & oJob.JOB_DESC
            '    'lab = e.Item.FindControl("lblJobCompNum")
            '    'lab.Text = JobCompNum.ToString.PadLeft(2, "0") & " - " & oJob.JobComponent.JOB_COMP_DESC
            'End If

        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadGridQvASummary_PageIndexChanged(ByVal source As Object, ByVal e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridQvASummary.PageIndexChanged
        Me.RadGridQvASummary.Rebind()
    End Sub

    Private Sub SummaryTabs_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles SummaryTabs.TabClick
        Try
            If e.Tab.Value = 0 Then
                Me.pnlQva.Visible = True
                Me.pnlFilter.Visible = False
                Me.RadGridQvASummary.Rebind()
                Session("EstJHTab") = 0
                Me.butExport.Visible = True
            End If
            If e.Tab.Value = 3 Then
                Me.pnlQva.Visible = False
                Me.pnlFilter.Visible = True
                LoadSettings()
                Me.QvaRadgridJob.Rebind()
                Me.rbIncludeNB.Checked = True
                Session("EstJHTab") = 3
                Me.butExport.Visible = False
            End If
            LoadTabs()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub rbBreakoutAllNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutAllNB.CheckedChanged
        If Me.rbBreakoutAllNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
        End If
    End Sub

    Private Sub rbBreakoutNBForFT_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBreakoutNBForFT.CheckedChanged
        If Me.rbBreakoutNBForFT.Checked = True Then
            Me.cbEmployeeTime.Checked = True
            Me.cbIncomeOnly.Checked = True
            Me.cbVendor.Checked = True
        End If
    End Sub

    Private Sub rbIncludeNB_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbIncludeNB.CheckedChanged
        If Me.rbIncludeNB.Checked = True Then
            Me.cbEmployeeTime.Checked = False
            Me.cbIncomeOnly.Checked = False
            Me.cbVendor.Checked = False
        End If
    End Sub

    Private Sub cbEmployeeTime_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbEmployeeTime.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub cbIncomeOnly_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncomeOnly.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub cbVendor_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbVendor.CheckedChanged
        If Me.cbEmployeeTime.Checked = True Or Me.cbIncomeOnly.Checked = True Or Me.cbVendor.Checked = True Then
            Me.rbIncludeNB.Checked = False
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = True
        ElseIf Me.cbEmployeeTime.Checked = False And Me.cbIncomeOnly.Checked = False And Me.cbVendor.Checked = False Then
            Me.rbIncludeNB.Checked = True
            Me.rbBreakoutAllNB.Checked = False
            Me.rbBreakoutNBForFT.Checked = False
        End If
    End Sub

    Private Sub LoadSettings()
        Dim ojobs As New Job_Specs(Session("ConnString"))
        Dim dr As SqlDataReader
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)
        oAppVars.getAllAppVars()

        Me.rbIncludeNB.Checked = CType(oAppVars.getAppVar("QvaFilterIncludeNB", "Boolean"), Boolean)
        Me.rbBreakoutAllNB.Checked = CType(oAppVars.getAppVar("QvaFilterBreakoutAllNB", "Boolean"), Boolean)
        Me.rbBreakoutNBForFT.Checked = CType(oAppVars.getAppVar("QvaFilterBreakoutNBForFT", "Boolean"), Boolean)
        Me.cbEmployeeTime.Checked = CType(oAppVars.getAppVar("QvaFilterEmployeeTime", "Boolean"), Boolean)
        Me.cbIncomeOnly.Checked = CType(oAppVars.getAppVar("QvaFilterIncomeOnly", "Boolean"), Boolean)
        Me.cbVendor.Checked = CType(oAppVars.getAppVar("QvaFilterVendor", "Boolean"), Boolean)


    End Sub

    Private Sub butOk_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butOk.Click
        Dim oAppVars As New cAppVars(cAppVars.Application.QVA)

        oAppVars.setAppVarDB("QvaFilterIncludeNB", CStr(Me.rbIncludeNB.Checked), "Boolean")
        oAppVars.setAppVarDB("QvaFilterBreakoutAllNB", CStr(Me.rbBreakoutAllNB.Checked), "Boolean")
        oAppVars.setAppVarDB("QvaFilterBreakoutNBForFT", CStr(Me.rbBreakoutNBForFT.Checked), "Boolean")
        oAppVars.setAppVarDB("QvaFilterEmployeeTime", CStr(Me.cbEmployeeTime.Checked), "Boolean")
        oAppVars.setAppVarDB("QvaFilterIncomeOnly", CStr(Me.cbIncomeOnly.Checked), "Boolean")
        oAppVars.setAppVarDB("QvaFilterVendor", CStr(Me.cbVendor.Checked), "Boolean")
    End Sub

    Private Sub butClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butClear.Click
        Me.rbIncludeNB.Checked = False
        Me.rbBreakoutAllNB.Checked = False
        Me.rbBreakoutNBForFT.Checked = False
        Me.cbEmployeeTime.Checked = False
        Me.cbIncomeOnly.Checked = False
        Me.cbVendor.Checked = False
    End Sub

#End Region

#Region " Controls "

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Me.lblMSG.Text = ""
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
        If Me.TxtJobType.Text <> "" Then
            If myVal.ValidateJobType(Me.TxtJobType.Text) = False Then
                Me.QuickMSG("Invalid Job Type")
                Exit Sub
            End If
        End If
        If Me.TxtClientCode.Text <> "" Then
            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, "", "", True) = False Then
                Me.QuickMSG("Invalid Client!")
                Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TxtClientCode.Text.Trim, "", "") = False Then
                Me.QuickMSG("Access to this client is denied.")
                Exit Sub
            End If
        End If
        If Me.TxtClientCode.Text <> "" And Me.TxtDivisionCode.Text <> "" Then
            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "", True) = False Then
                Me.QuickMSG("Invalid Client, Division!")
                Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, "") = False Then
                Me.QuickMSG("Access to this division is denied.")
                Exit Sub
            End If
        End If
        If Me.TxtClientCode.Text <> "" And Me.TxtDivisionCode.Text <> "" And Me.TxtProductCode.Text <> "" Then
            If myVal.ValidateCDP(Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim, True) = False Then
                Me.QuickMSG("Invalid Client, Division, Product!")
                Exit Sub
            End If
            If myVal.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TxtClientCode.Text.Trim, Me.TxtDivisionCode.Text.Trim, Me.TxtProductCode.Text.Trim) = False Then
                Me.QuickMSG("Access to this product is denied.")
                Exit Sub
            End If
        End If
        If Me.TxtJobType.Text = "" Then
            Me.QuickMSG("Job Type is required")
            Exit Sub
        End If
        If Me.RadDatePickerJobCutOffDate.DateInput.Text = "" Then
            Me.QuickMSG("Job Cutoff Date From is required")
            Exit Sub
        End If
        If Me.RadDatePickerToDate.DateInput.Text = "" Then
            Me.QuickMSG("Job Cutoff Date To is required")
            Exit Sub
        End If



        Dim dr As SqlDataReader = est.GetEstimateQuoteInfo(EstNum, EstComp, QuoteNum, 0)
        If dr.HasRows = True Then
            Do While dr.Read
                If IsDBNull(dr("CL_CODE")) = False Then
                    Me.hfestclient.Value = dr("CL_CODE")
                End If
                'If IsDBNull(dr("CL_NAME")) = False Then
                '    Me.TxtClientDescription.Text = dr("CL_NAME")
                'End If
                If IsDBNull(dr("DIV_CODE")) = False Then
                    Me.hfestdivision.Value = dr("DIV_CODE")
                End If
                'If IsDBNull(dr("DIV_NAME")) = False Then
                '    Me.TxtDivisionDescription.Text = dr("DIV_NAME")
                'End If
                If IsDBNull(dr("PRD_CODE")) = False Then
                    Me.hfestproduct.Value = dr("PRD_CODE")
                End If
                'If IsDBNull(dr("PRD_DESCRIPTION")) = False Then
                '    Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
                'End If
                'If IsDBNull(dr("ESTIMATE_NUMBER")) = False Then
                '    Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
                'End If
                'If IsDBNull(dr("EST_LOG_DESC")) = False Then
                '    Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
                'End If
                'If IsDBNull(dr("EST_COMPONENT_NBR")) = False Then
                '    Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
                'End If
                'If IsDBNull(dr("EST_COMP_DESC")) = False Then
                '    Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
                'End If
                'If IsDBNull(dr("EST_QUOTE_NBR")) = False Then
                '    Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
                'End If
                'If IsDBNull(dr("EST_QUOTE_DESC")) = False Then
                '    Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
                'End If
                If IsDBNull(dr("JOB_NUMBER")) = False Then
                    Me.hfestjob.Value = dr("JOB_NUMBER")
                Else
                    Me.hfestjob.Value = 0
                End If
                'If IsDBNull(dr("JOB_DESC")) = False Then
                '    Me.TxtJobDescription.Text = dr("JOB_DESC")
                'End If
                If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
                    Me.hfestcomp.Value = dr("JOB_COMPONENT_NBR")
                Else
                    Me.hfestcomp.Value = 0
                End If
                'If IsDBNull(dr("JOB_COMP_DESC")) = False Then
                '    Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
                'End If
                If IsDBNull(dr("SC_CODE")) = False Then
                    Me.hfsalesclass.Value = dr("SC_CODE")
                End If
            Loop
        End If
        dr.Close()
        Me.pnlJH.Visible = True
        Me.btnGetHistory.Visible = True
        Me.pnlQva.Visible = False
        Me.butExport.Visible = False
        Me.BtnCopy.Visible = False
        Me.pnlFilter.Visible = False
        Me.SummaryTabs.Visible = False
        Session("EstJHTab") = 0
        Me.RadGridJobHistory.Rebind()

    End Sub

    Private Sub btnGetHistory_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnGetHistory.Click
        Try
            Dim chk As CheckBox
            Dim DelString As String = ""
            Dim count As Integer = 0
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridJobHistory.MasterTableView.Items
                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked Then
                    Me.jobs &= gridDataItem("colJOB_NUMBER").Text.Replace("&nbsp;", "") & ","
                    Me.comps &= gridDataItem("colJOB_COMPONENT_NBR").Text.Replace("&nbsp;", "") & ","
                    count += 1
                End If
            Next

            If count = 0 Then
                Me.QuickMSG("No rows were selected")
                Exit Sub
            End If
            Me.lblMSG.Text = ""
            JobCount = count
            Me.hfjobs.Value = Me.jobs
            Me.hfcomps.Value = Me.comps
            Me.hfcount.Value = Me.JobCount
            Me.RadGridQvASummary.Rebind()
            Me.pnlQva.Visible = True
            Me.butExport.Visible = True
            Me.pnlJH.Visible = False
            Me.btnGetHistory.Visible = False
            Me.BtnCopy.Visible = True
            Me.SummaryTabs.Visible = True
            Session("EstJHTab") = 0


        Catch ex As Exception

        End Try
    End Sub

    Private Sub butExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butExport.Click
        Try
            Dim str As String = ""
            str = "Job History" & "_" & Now.Year.ToString() & Now.Month.ToString() & Now.Day.ToString()
            AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridQvASummary, str)
            RadGridQvASummary.MasterTableView.ExportToExcel()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))


        Dim functioncode As String = ""
        Dim suppliedby As String = ""
        Dim markuppct As Decimal = 0.0
        Dim contpct As Decimal = 0.0
        Dim contamt As Decimal = 0.0
        Dim quantityhours As Decimal = 0.0
        Dim rate As Decimal = 0.0
        Dim extamt As Decimal = 0.0
        Dim actualamt As Decimal = 0.0
        Dim markupamt As Decimal = 0.0
        Dim fnctype As String = ""
        Dim fnccpmflag As Integer
        Dim taxcomm As Integer
        Dim taxcommonly As Integer
        Dim fncnobillflag As Integer
        Dim fnctaxflag As Integer
        Dim fnccommflag As Integer
        Dim taxstatepct As Decimal = 0.0
        Dim taxcountypct As Decimal = 0.0
        Dim taxcitypct As Decimal = 0.0
        Dim taxresale As Integer = 0
        Dim taxresalenbr As String = ""
        Dim extnonresaletax As Decimal = 0.0
        Dim extstateresale As Decimal = 0.0
        Dim extcountyresale As Decimal = 0.0
        Dim extcityresale As Decimal = 0.0
        Dim extstatenonresale As Decimal = 0.0
        Dim extcountynonresale As Decimal = 0.0
        Dim extcitynonresale As Decimal = 0.0
        Dim extstatemarkup As Decimal = 0.0
        Dim extcountymarkup As Decimal = 0.0
        Dim extcitymarkup As Decimal = 0.0
        Dim extmucont As Decimal = 0.0
        Dim extstatecont As Decimal = 0.0
        Dim extcountycont As Decimal = 0.0
        Dim extcitycont As Decimal = 0.0
        Dim extnrcont As Decimal = 0.0
        Dim linetotal As Decimal = 0.0
        Dim linetotalcont As Decimal = 0.0
        Dim taxcode As String = ""
        Dim estmarkuppct As Decimal = 0
        Dim jobmarkuppct As Decimal = 0
        Dim feetime As Integer = 0
        Dim estbillrateflag As Integer = 0
        Dim clcode As String
        Dim divcode As String
        Dim prdcode As String
        Dim blendedrate As Decimal = 0.0

        Dim dr As SqlClient.SqlDataReader
        Dim max As Integer
        Dim sort As Integer

        Dim chk As CheckBox
        Dim count As Integer = 0
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQvASummary.MasterTableView.Items
            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If chk.Checked Then
                count += 1
            End If
        Next
        If count = 0 Then
            Me.QuickMSG("No functions were selected")
            Me.RadGridQvASummary.Rebind()
            Exit Sub
        End If

        dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstComp, Me.QuoteNum, Me.RevNum)
        If dr.HasRows = True Then
            Do While dr.Read
                contpct = dr("PRD_CONT_PCT")
                estmarkuppct = dr("EST_MARKUP_PCT")
                jobmarkuppct = dr("JOB_MARKUP_PCT")
                clcode = dr("CL_CODE")
                divcode = dr("DIV_CODE")
                prdcode = dr("PRD_CODE")
                If IsDBNull(dr("BLENDED_TIME_RATE")) = False Then
                    blendedrate = dr("BLENDED_TIME_RATE")
                Else
                    blendedrate = -1.0
                End If
            Loop
        End If
        dr.Close()

        estbillrateflag = est.GetEstBillRateFlag(clcode, divcode, prdcode)

        Dim dt As DataTable

        Dim LegacyValidation As New cValidations(_Session.ConnectionString)
        Dim FunctionIsValid As Boolean = True
        Dim InValidFunctionCount As Integer = 0

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQvASummary.MasterTableView.Items

            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

            If chk.Checked = True Then

                functioncode = gridDataItem.GetDataKeyValue("FNC_CODE")
                FunctionIsValid = True

                If String.IsNullOrWhiteSpace(functioncode) = False Then

                    If LegacyValidation.ValidateFunctionCodeEst(functioncode, JobNum, clcode) = False Then

                        FunctionIsValid = False
                        InValidFunctionCount += 1

                    End If

                End If

                If FunctionIsValid = True Then

                    Try
                        quantityhours = CType(gridDataItem("ActualHours").Text, Decimal)
                    Catch ex As Exception
                        quantityhours = 0
                    End Try

                    Try
                        actualamt = CType(gridDataItem("ActualAmount").Text, Decimal)
                    Catch ex As Exception
                        actualamt = 0
                    End Try

                    If functioncode = "" Then
                        '"Function Code Required."
                        Exit Sub
                    Else
                        extamt = 0.0
                        markuppct = 0.0
                        markupamt = 0.0
                        taxcode = ""
                        contamt = 0.0
                        linetotalcont = 0.0
                        linetotal = 0.0
                        feetime = 0
                        rate = 0.0
                        dt = est.GetDefaultFunctionData(functioncode, hfestjob.Value, hfestcomp.Value, hfestclient.Value, hfestdivision.Value, hfestproduct.Value, hfsalesclass.Value, "")
                        If dt.Rows.Count > 0 Then
                            If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
                                fnctype = dt.Rows(0)("FNC_TYPE")
                            End If
                            If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
                                rate = blendedrate
                            Else
                                If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
                                    rate = dt.Rows(0)("BILLING_RATE")
                                End If
                            End If
                            If IsDBNull(dt.Rows(0)("NOBILL_FLAG")) = False Then
                                fncnobillflag = dt.Rows(0)("NOBILL_FLAG")
                            End If
                            If IsDBNull(dt.Rows(0)("TAX_COMM")) = False Then
                                taxcomm = dt.Rows(0)("TAX_COMM")
                            End If
                            If IsDBNull(dt.Rows(0)("TAX_COMM_ONLY")) = False Then
                                taxcommonly = dt.Rows(0)("TAX_COMM_ONLY")
                            End If
                            If IsDBNull(dt.Rows(0)("TAX_CODE")) = False Then
                                taxcode = dt.Rows(0)("TAX_CODE")
                                fnctaxflag = 1
                            Else
                                taxcode = ""
                                fnctaxflag = 0
                            End If
                            taxstatepct = dt.Rows(0)("TAX_STATE_PERCENT")
                            taxcountypct = dt.Rows(0)("TAX_COUNTY_PERCENT")
                            taxcitypct = dt.Rows(0)("TAX_CITY_PERCENT")
                            If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
                                taxresale = dt.Rows(0)("TAX_RESALE")
                            End If
                            If IsDBNull(dt.Rows(0)("TAX_RESALE_NUMBER")) = False Then
                                taxresalenbr = dt.Rows(0)("TAX_RESALE_NUMBER")
                            End If
                            If IsDBNull(dt.Rows(0)("FEE_TIME_FLAG")) = False Then
                                feetime = dt.Rows(0)("FEE_TIME_FLAG")
                            End If
                            If IsDBNull(dt.Rows(0)("COMM")) = False Then
                                markuppct = dt.Rows(0)("COMM")
                                If markuppct = 0 Then
                                    fnccommflag = 0
                                Else
                                    fnccommflag = 1
                                End If
                            Else
                                fnccommflag = 1
                                markuppct = estmarkuppct
                            End If
                            If rate > 0 Then
                                extamt = quantityhours * rate
                            End If
                            If (fnctype = "V" Or fnctype = "I") And actualamt > 0 Then
                                extamt = actualamt
                                quantityhours = 0
                            End If
                            If markuppct <> 0 And extamt > 0 Then
                                markupamt = extamt * (markuppct / 100)
                                extmucont = markupamt * (contpct / 100)
                            Else
                                markupamt = 0.0
                            End If
                            If contpct <> 0 Then
                                contamt = extamt * (contpct / 100)
                                If markuppct > 0 Then
                                    linetotalcont += (markupamt * (contpct / 100))
                                End If
                            End If
                            If taxresale = 1 Then
                                If taxcommonly <> 1 Then
                                    extstateresale = extamt * (taxstatepct / 100)
                                    extcountyresale = extamt * (taxcountypct / 100)
                                    extcityresale = extamt * (taxcitypct / 100)
                                End If
                                If taxcomm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxstatepct / 100)
                                        extcountymarkup = markupamt * (taxcountypct / 100)
                                        extcitymarkup = markupamt * (taxcitypct / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                                If contamt > 0 Then
                                    If taxcomm = 1 And taxcommonly = 1 Then
                                        extstatecont = extmucont * (taxstatepct / 100)
                                        extcountycont = extmucont * (taxcountypct / 100)
                                        extcitycont = extmucont * (taxcitypct / 100)
                                    ElseIf taxcomm = 1 Then
                                        extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                        extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                        extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                                    Else
                                        extstatecont = contamt * (taxstatepct / 100)
                                        extcountycont = contamt * (taxcountypct / 100)
                                        extcitycont = contamt * (taxcitypct / 100)
                                    End If
                                End If
                            End If
                            If taxresale <> 1 Then
                                If fnctype = "V" Then
                                    If taxcommonly <> 1 Then
                                        extstatenonresale = extamt * (taxstatepct / 100)
                                        extcountynonresale = extamt * (taxcountypct / 100)
                                        extcitynonresale = extamt * (taxcitypct / 100)
                                        extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
                                    End If
                                    If contamt > 0 Then
                                        If taxcomm = 1 And taxcommonly = 1 Then
                                            extnrcont = extmucont * (taxstatepct / 100) + extmucont * (taxcountypct / 100) + extmucont * (taxcitypct / 100)
                                        ElseIf taxcomm = 1 Then
                                            extnrcont = (contamt + extmucont) * (taxstatepct / 100) + (contamt + extmucont) * (taxcountypct / 100) + (contamt + extmucont) * (taxcitypct / 100)
                                        Else
                                            extnrcont = contamt * (taxstatepct / 100) + contamt * (taxcountypct / 100) + contamt * (taxcitypct / 100)
                                        End If
                                    End If
                                ElseIf fnctype = "E" Or fnctype = "I" Then
                                    If taxcommonly <> 1 Then
                                        extstateresale = extamt * (taxstatepct / 100)
                                        extcountyresale = extamt * (taxcountypct / 100)
                                        extcityresale = extamt * (taxcitypct / 100)
                                    End If
                                    If contamt > 0 Then
                                        If taxcomm = "1" And taxcommonly = "1" Then
                                            extstatecont = extmucont * (taxstatepct / 100)
                                            extcountycont = extmucont * (taxcountypct / 100)
                                            extcitycont = extmucont * (taxcitypct / 100)
                                        ElseIf taxcomm = "1" Then
                                            extstatecont = (contamt + extmucont) * (taxstatepct / 100)
                                            extcountycont = (contamt + extmucont) * (taxcountypct / 100)
                                            extcitycont = (contamt + extmucont) * (taxcitypct / 100)
                                        Else
                                            extstatecont = contamt * (taxstatepct / 100)
                                            extcountycont = contamt * (taxcountypct / 100)
                                            extcitycont = contamt * (taxcitypct / 100)
                                        End If
                                    End If
                                End If
                                If taxcomm = 1 Then
                                    If markupamt > 0 Then
                                        extstatemarkup = markupamt * (taxstatepct / 100)
                                        extcountymarkup = markupamt * (taxcountypct / 100)
                                        extcitymarkup = markupamt * (taxcitypct / 100)
                                    End If
                                End If
                                extstateresale += extstatemarkup
                                extcountyresale += extcountymarkup
                                extcityresale += extcitymarkup
                            End If
                        End If
                        dt = est.GetAddNewFunctionData(functioncode)
                        If dt.Rows.Count > 0 Then
                            fnccpmflag = dt.Rows(0)("FNC_CPM_FLAG")
                        End If
                    End If

                    linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extnonresaletax, 2, MidpointRounding.AwayFromZero)
                    linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)

                    'Save:
                    Try
                        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                        'straighten out the phaseID and description! (also on quick add)
                        oEstimating.AddNewFunction(EstNum, EstComp, QuoteNum, RevNum, 0, functioncode, markuppct, contpct, quantityhours,
                                                    rate, suppliedby, "", extamt, taxcode, "", markupamt,
                                                    contamt, linetotal, 1, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly,
                                                    taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale,
                                                    extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime, 0)

                    Catch ex As Exception
                    End Try

                Else

                    InValidFunctionCount += 1

                End If

            End If

        Next

        If InValidFunctionCount > 0 Then

            If InValidFunctionCount = 1 Then

                Me.ShowMessage("One restricted function not added.")

            Else

                Me.ShowMessage(InValidFunctionCount.ToString & " restricted functions not added.")

            End If

        End If

        CloseAndRefresh()

    End Sub

#End Region

End Class
