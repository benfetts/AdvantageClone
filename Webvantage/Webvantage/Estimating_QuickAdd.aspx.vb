Imports Webvantage.wvTimeSheet
Imports Webvantage.cGlobals
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI

Partial Public Class Estimating_QuickAdd
    Inherits Webvantage.BaseChildPage
    Private EstNum As Integer = 0
    Private EstCompNum As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Private JobNum As Integer = 0
    Private JobCompNum As Integer = 0
    Dim ClientCode As String = ""
    Dim DivisionCode As String = ""
    Dim ProductCode As String = ""
    Dim SalesClass As String = ""
    Private IsRush As Boolean = False
    Private SchedDueDate As String
    Private RushApproved As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'objects
        Dim appr As Integer = 0
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            EstNum = .EstimateNumber
            EstCompNum = .EstimateComponentNumber
            QuoteNum = .EstimateQuoteNumber
            RevNum = .EstimateRevisionNumber
            appr = .GetValue("appr")
            ClientCode = .ClientCode
            DivisionCode = .DivisionCode
            ProductCode = .ProductCode
            SalesClass = .SalesClassCode
            JobNum = .JobNumber
            JobCompNum = .JobComponentNumber

        End With

        If appr = 1 Then
            Me.BtnAddTasks.Attributes.Add("onclick", "return confirm('This quote is approved. Are you sure you want to save the changes?');")
        Else
            Me.BtnAddTasks.Attributes.Add("onclick", "")
        End If


        If Not Me.IsPostBack Then
            BindDropPresets()
            Me.Title = "Template Options"
            'group:
            'Dim GrpExpr As Telerik.Web.UI.GridGroupByExpression = Telerik.Web.UI.GridGroupByExpression.Parse("TRF_PRESET_DESC Template Group By TRF_PRESET_DESC")
            'With Me.RadGridQuickAdd
            '    .MasterTableView.GroupByExpressions.Clear()
            '    .MasterTableView.GroupByExpressions.Add(GrpExpr)
            '    .MasterTableView.GroupsDefaultExpanded = True
            '    .Rebind()
            '    .MasterTableView.GetColumn("colTRF_PRESET_DESC").Display = False
            'End With
        End If
    End Sub

    Private Sub BindDropPresets()
        Dim d As cDropDowns = New cDropDowns(Session("ConnString"))
        With Me.DropPreset
            .DataSource = d.GetEstimatingPresets
            .DataTextField = "CodeAndDescription"
            .DataValueField = "code"
            .DataBind()
            .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Select Template]", "[Select Template]"))
            .Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem("[All Templates]", "[All Templates]"))
        End With
    End Sub

    Private Sub RadGridQuickAdd_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuickAdd.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim hf As System.Web.UI.WebControls.HiddenField
                Dim txt As System.Web.UI.WebControls.TextBox
                hf = e.Item.FindControl("HfFunctionType")
                txt = e.Item.FindControl("TxtSUPPLIED_BY")
                If hf.Value = "I" Or hf.Value = "C" Then
                    txt.ReadOnly = True
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGridQuickAdd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuickAdd.NeedDataSource
        If Me.DropPreset.SelectedIndex > 0 Then
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))
            Dim dt As New DataTable
            Dim dv As New DataView
            dt = est.GetQuickAddDT(True, Me.JobNum, Me.ClientCode)
            dv = dt.DefaultView
            If Me.DropPreset.SelectedIndex > 1 Then
                dv.RowFilter = "PRESET_CODE = '" & Me.DropPreset.SelectedValue.ToString() & "'"
            End If
            Me.RadGridQuickAdd.DataSource = dv
            'SetRushData()
            'SetRushColumns()
        End If
    End Sub

    'Private Sub BtnAddTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddTasks.Click

    'End Sub

    Private Sub CloseAndRefresh()
        'Me.CallFunctionOnParentPage("RefreshFileGrid")
        'Dim FunctionName As String = "RefreshGrid"
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"

        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & RevNum, True)
    End Sub

    Private Sub DropPreset_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropPreset.SelectedIndexChanged
        Select Case Me.DropPreset.SelectedIndex
            Case 0
                'ClearRushLabels()
            Case 1
                'ClearRushLabels()
                Me.RadGridQuickAdd.Rebind()
            Case Else
                Me.RadGridQuickAdd.Visible = True
                Me.RadGridQuickAdd.Rebind()
        End Select
        'If RushApproved = True Then
        '    Me.RblStandardRush.SelectedIndex = 1
        '    IsRush = True
        '    SetRushColumns()
        'End If
    End Sub

    Private Sub ClearRushLabels()
        Me.RblStandardRush.Items(0).Text = "Standard Days"
        Me.RblStandardRush.Items(1).Text = "Rush Days"
    End Sub

    Private Sub SetRushColumns()
        With Me.RadGridQuickAdd.MasterTableView
            .GetColumn("colTRF_PRESET_DAYS").Display = Not IsRush
            .GetColumn("colTRF_PRESET_HRS").Display = Not IsRush
            .GetColumn("colRUSH_DAYS").Display = IsRush
            .GetColumn("colRUSH_HOURS").Display = IsRush
        End With
        Me.RblStandardRush.Items(0).Selected = Not IsRush
        Me.RblStandardRush.Items(1).Selected = IsRush
    End Sub

    Private Sub SetRushData()
        Dim i As Integer = MiscFN.GetWorkingDays(Now.ToShortDateString(), SchedDueDate).ToString
        Dim rec As String = " (Recommended)"
        Dim std As Integer
        Dim rush As Integer
        If Me.DropPreset.SelectedIndex > 1 Then
            Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            s.GetPresetDays(Me.DropPreset.SelectedValue, std, rush)
            If std > i Then
                If rush = 0 Then
                    rec = " (Recommended, but no days set.)"
                End If
                Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & std.ToString() & " days"
                Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & rush.ToString() & " days" & rec
            Else
                If std = 0 Then
                    rec = " (Recommended, but no days set.)"
                End If
                Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & std.ToString() & " days" & rec
                Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & rush.ToString() & " days"
            End If
        ElseIf Me.DropPreset.SelectedIndex = 1 Then
            Me.RblStandardRush.Items(0).Text = "Standard"
            Me.RblStandardRush.Items(1).Text = "Rush"
        End If
        'add as final override if rush is approved:
        If RushApproved = True Then
            Me.RblStandardRush.Items(0).Text = "Standard Schedule: " & std.ToString() & " days"
            Me.RblStandardRush.Items(1).Text = "Rush Schedule: " & rush.ToString() & " days (Rush Charges approved!)"
            'Me.RblStandardRush.SelectedIndex = 1
            'IsRush = True
        End If
    End Sub

    Private Sub RblStandardRush_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RblStandardRush.SelectedIndexChanged
        If Me.RblStandardRush.SelectedIndex = 0 Then
            IsRush = False
        Else
            IsRush = True
        End If
        Me.RadGridQuickAdd.Rebind()
    End Sub

    Private Sub BtnAddTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddTasks.Click
        Try
            'If e.CommandName = "AddTasks" Then
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))

            Dim functioncode As String = ""
            Dim suppliedby As String = ""
            Dim markuppct As Decimal = 0.0
            Dim contpct As Decimal = 0.0
            Dim contamt As Decimal = 0.0
            Dim quantityhours As Decimal = 0.0
            Dim rate As Decimal = 0.0
            Dim extamt As Decimal = 0.0
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
            dr = est.GetEstimateQuoteInfo(Me.EstNum, Me.EstCompNum, Me.QuoteNum, Me.RevNum)
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

            Dim chk As CheckBox
            Dim dt As DataTable
            Dim InValidFunctionCount As Integer = 0
            Dim LegacyValidation As New cValidations(_Session.ConnectionString)
            Dim FunctionIsValid As Boolean = True

            For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuickAdd.MasterTableView.Items
                chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                If chk.Checked = True Then
                    'Set variables:
                    FunctionIsValid = True
                    functioncode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")

                    If String.IsNullOrWhiteSpace(functioncode) = False Then

                        If LegacyValidation.ValidateFunctionCodeEst(functioncode, JobNum, ClientCode) = False Then

                            FunctionIsValid = False
                            InValidFunctionCount += 1

                        End If

                    End If

                    If FunctionIsValid = True Then

                        'NewTaskDescription = gridDataItem("colTRF_DESC").Text.Replace("&nbsp;", "")
                        Try
                            suppliedby = CType(gridDataItem("colSUPPLIED_BY").FindControl("TxtSUPPLIED_BY"), TextBox).Text
                        Catch ex As Exception
                            suppliedby = ""
                        End Try
                        Try
                            quantityhours = CType(CType(gridDataItem("colHRS_QTY").FindControl("TxtHRS_QTY"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            quantityhours = 0
                        End Try
                        Try
                            extamt = CType(CType(gridDataItem("colNET_AMOUNT").FindControl("TxtNET_AMOUNT"), TextBox).Text, Decimal)
                        Catch ex As Exception
                            extamt = 0
                        End Try
                        If functioncode = "" Then
                            '"Function Code Required."
                            Exit Sub
                        Else
                            markuppct = 0.0
                            markupamt = 0.0
                            taxcode = ""
                            contamt = 0.0
                            linetotalcont = 0.0
                            linetotal = 0.0
                            feetime = 0
                            rate = 0.0
                            dt = est.GetDefaultFunctionData(functioncode, JobNum, JobCompNum, ClientCode, DivisionCode, ProductCode, SalesClass, suppliedby)
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
                                If rate > 0 And quantityhours > 0 Then
                                    extamt = quantityhours * rate
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
                            'straighten out the phaseID and description! (also on quick add)
                            est.AddNewFunction(EstNum, EstCompNum, QuoteNum, RevNum, 0, functioncode, markuppct, contpct, quantityhours,
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

            If Me.DropPreset.SelectedValue <> "[Select Template]" And Me.DropPreset.SelectedValue <> "[All Templates]" Then
                Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate
                Dim EstimateComments As String
                Dim EstimateCompComments As String
                dt = est.GetEstimateData(EstNum, EstCompNum, 0, 0, Session("UserCode"))
                If dt.Rows.Count > 0 Then
                    EstimateComments = dt.Rows(0)("EST_LOG_COMMENT").ToString
                    EstimateCompComments = dt.Rows(0)("EST_COMP_COMMENT").ToString
                End If
                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                    EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, Me.DropPreset.SelectedValue)
                    If EstimateTemplate.DefaultComment IsNot Nothing Then
                        If EstimateComments = "" Then
                            est.UpdateEstimateComments(EstNum, EstCompNum, EstimateCompComments, EstimateTemplate.DefaultComment)
                        ElseIf EstimateComments.Contains(EstimateTemplate.DefaultComment) = False Then
                            EstimateComments &= vbCrLf & EstimateTemplate.DefaultComment
                            est.UpdateEstimateComments(EstNum, EstCompNum, EstimateCompComments, EstimateComments)
                        End If
                    End If
                End Using
            End If

            If InValidFunctionCount > 0 Then

                If InValidFunctionCount = 1 Then

                    Me.ShowMessage("One restricted function not added.")

                Else

                    Me.ShowMessage(InValidFunctionCount.ToString & " restricted functions not added.")

                End If

            End If


            CloseAndRefresh()
            ' End If
        Catch ex As Exception

        End Try
    End Sub


End Class
