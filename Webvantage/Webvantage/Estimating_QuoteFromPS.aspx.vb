Imports Webvantage.cGlobals
Imports Telerik.Web.UI
Imports System.Data.Sql
Imports System.Data.SqlClient

Partial Public Class Estimating_QuoteFromPS
    Inherits Webvantage.BaseChildPage
    Private EstimateNum As Integer = 0
    Private EstimateComp As Integer = 0
    Private EstimateQuote As Integer = 0
    Private JobNum As Integer = 0
    Private JobComp As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0
    Dim ClientCode As String = ""
    Dim DivisionCode As String = ""
    Dim ProductCode As String = ""
    Dim SalesClass As String = ""

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim appr As Integer = 0
        Dim QueryString As AdvantageFramework.Web.QueryString = Nothing

        QueryString = New AdvantageFramework.Web.QueryString()

        QueryString = QueryString.FromCurrent()

        With QueryString

            EstimateNum = .EstimateNumber
            EstimateComp = .EstimateComponentNumber
            EstimateQuote = .EstimateQuoteNumber
            RevNum = .EstimateRevisionNumber
            appr = .GetValue("appr")
            ClientCode = .ClientCode
            DivisionCode = .DivisionCode
            ProductCode = .ProductCode
            SalesClass = .SalesClassCode
            JobNum = .JobNumber
            JobComp = .JobComponentNumber

        End With

        If appr = 1 Then
            Me.BtnCopy.Attributes.Add("onclick", "return confirm('This quote is approved. Are you sure you want to save the changes?');")
        Else
            Me.BtnCopy.Attributes.Add("onclick", "")
        End If
        If Not Me.IsPostBack Then
            Me.Title = "Create Quote From Schedule"
            'LoadQuoteData()
        End If
        'Me.LoadLookups()
    End Sub


    'Private Sub LoadQuoteData()
    '    Try
    '        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
    '        Dim dr As SqlDataReader
    '        dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
    '        If dr.HasRows = True Then
    '            Do While dr.Read
    '                Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
    '                Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
    '                'Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
    '                Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
    '                Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
    '                'Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
    '                Me.TxtClientCode.Text = dr("CL_CODE")
    '                Me.TxtDivisionCode.Text = dr("DIV_CODE")
    '                Me.TxtProductCode.Text = dr("PRD_CODE")
    '                Me.TxtClientDescription.Text = dr("CL_NAME")
    '                Me.TxtDivisionDescription.Text = dr("DIV_NAME")
    '                Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
    '            Loop
    '        End If
    '    Catch ex As Exception

    '    End Try
    'End Sub

    Private Sub RadGridCopyFromQuotes_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCopyFromQuotes.ItemDataBound
        Dim oTrafficSchedule As cSchedule = New cSchedule(Session("ConnString"), Session("UserCode"))
        Dim dr As SqlDataReader
        If e.Item.ItemType = GridItemType.Item Or e.Item.ItemType = GridItemType.AlternatingItem Then
            Dim str As String = e.Item.Cells(5).Text
            If e.Item.Cells(5).Text = " ... " Then
                'e.Item.Cells(5).Text = oTrafficSchedule.GetTaskEmpListString(JobNum, JobComp, CInt(e.Item.Cells(8).Text))
                'e.Item.Cells(6).Text = "&nbsp;"
            Else
                'e.Item.Cells(6).Text = "&nbsp;"
            End If
            'If Me.cbIncludeEmployees.Checked = True Then
            'If e.Item.Cells(8).Text <> "" And e.Item.Cells(8).Text <> "&nbsp;" Then
            '    e.Item.Cells(7).Text = e.Item.Cells(8).Text
            'End If
            'End If

        End If
    End Sub

    Private Sub RadGridCopyFromQuotes_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCopyFromQuotes.NeedDataSource

        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim dt As DataTable

        dt = est.GetEstimateData(EstimateNum, EstimateComp, 0, 0, Session("UserCode"))

        If dt.Rows.Count > 0 Then

            If IsDBNull(dt.Rows(0)("JOB_NUMBER")) = False Then

                JobNum = dt.Rows(0)("JOB_NUMBER")

            End If
            If IsDBNull(dt.Rows(0)("JOB_COMPONENT_NBR")) = False Then

                JobComp = dt.Rows(0)("JOB_COMPONENT_NBR")

            End If

        End If

        Me.RadGridCopyFromQuotes.DataSource = est.GetEstimateTasks(JobNum, JobComp, "estquote", CStr(Session("UserCode")), "", "", "", True, False, False, "", "no_filter", Me.cbIncludeEmployees.Checked)


    End Sub

    Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
        Me.RadGridCopyFromQuotes.Rebind()
    End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        'Me.lblMSG.Text = TheMSG
    End Sub

    'Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click


    'End Sub

    Private Sub CloseAndRefresh()
        'Dim FunctionName As String = "RefreshFileGrid"
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx?EstNum=" & Me.EstimateNum & "&EstComp=" & Me.EstimateComp & "&QuoteNum=" & Me.EstimateQuote & "&RevNum=" & RevNum, True)
    End Sub

    Private Sub cbIncludeEmployees_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbIncludeEmployees.CheckedChanged
        Try
            If Me.cbIncludeEmployees.Checked = True Then
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEMP_CODE").Display = True
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEmpName").Display = True
            Else
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEMP_CODE").Display = False
                Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colEmpName").Display = False
            End If
            Me.RadGridCopyFromQuotes.Rebind()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim emp As AdvantageFramework.Database.Views.Employee = Nothing

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
        Dim feetime = 0
        Dim estbillrateflag As Integer = 0
        Dim clcode As String
        Dim divcode As String
        Dim prdcode As String
        Dim blendedrate As Decimal = 0.0
        Dim emptask As String = ""
        Dim task As String = ""
        Dim seqnbr As Integer = 0
        Dim fncseqnbr As Integer = 0

        Dim dr As SqlClient.SqlDataReader
        Dim max As Integer
        Dim sort As Integer
        dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
        If dr.HasRows = True Then
            Do While dr.Read
                contpct = dr("PRD_CONT_PCT")
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

        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCopyFromQuotes.MasterTableView.Items

            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)

            If chk.Checked = True Then

                FunctionIsValid = True
                'Set variables:
                functioncode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")

                If String.IsNullOrWhiteSpace(functioncode) = False Then

                    If LegacyValidation.ValidateFunctionCodeEst(functioncode, JobNum, ClientCode) = False Then

                        FunctionIsValid = False
                        InValidFunctionCount += 1

                    End If

                End If

                If FunctionIsValid = True Then

                    Try
                        seqnbr = CType(gridDataItem("colSEQ_NBR").Text, Integer)
                    Catch ex As Exception
                    End Try
                    Try
                        fncseqnbr = CType(gridDataItem.GetDataKeyValue("FNC_SEQ_NBR"), Integer)
                    Catch ex As Exception
                    End Try

                    task = gridDataItem.GetDataKeyValue("FNC_CODE")
                    Try
                        suppliedby = gridDataItem("colEMP_CODE").Text.Replace("&nbsp;", "")
                    Catch ex As Exception
                        suppliedby = ""
                    End Try
                    If suppliedby.Contains(",") = True Then
                        suppliedby = ""
                    End If
                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                        emp = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, suppliedby)
                    End Using
                    If cbIncludeEmployees.Checked = True And functioncode = "" Then
                        functioncode = emp.FunctionCode
                    End If
                    Try
                        If Me.RadioButtonDisbursed.Checked = True Then
                            quantityhours = CType(gridDataItem("colHOURS").Text, Decimal)
                        Else
                            quantityhours = CType(gridDataItem("colJOB_HRS").Text, Decimal)
                        End If
                    Catch ex As Exception
                        quantityhours = 0
                    End Try
                    If functioncode = "" Then
                        '"Function Code Required."
                        emptask &= suppliedby & "(" & task & "), "
                        'Exit Sub
                    Else
                        markuppct = 0.0
                        markupamt = 0.0
                        taxcode = ""
                        contamt = 0.0
                        linetotalcont = 0.0
                        linetotal = 0.0
                        extamt = 0.0
                        rate = 0.0
                        dt = est.GetDefaultFunctionData(functioncode, JobNum, JobComp, ClientCode, DivisionCode, ProductCode, SalesClass, suppliedby)
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
                            End If
                            If rate > 0 Then
                                extamt = quantityhours * rate
                            End If
                            If markuppct <> 0 And extamt > 0 Then
                                markupamt = extamt * (markuppct / 100)
                                extmucont = markupamt * (contpct / 100)
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
                                        If taxcomm = "1" And taxcommonly = "1" Then
                                            extnrcont = extmucont * (taxstatepct / 100) + extmucont * (taxcountypct / 100) + extmucont * (taxcitypct / 100)
                                        ElseIf taxcomm = "1" Then
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
                        Dim comments As String = ""
                        Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                        'straighten out the phaseID and description! (also on quick add)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Dim t As AdvantageFramework.Database.Entities.JobComponentTask
                            t = AdvantageFramework.Database.Procedures.JobComponentTask.LoadByJobNumberAndJobComponentNumberAndSequenceNumber(DbContext, Me.JobNum, Me.JobComp, fncseqnbr)

                            If t IsNot Nothing Then

                                comments = t.Comment

                            End If

                        End Using

                        oEstimating.AddNewFunction(EstimateNum, EstimateComp, EstimateQuote, RevNum, seqnbr, functioncode, markuppct, contpct, quantityhours,
                                                rate, suppliedby, "", extamt, taxcode, If(Me.CheckBoxIncludeTaskComments.Checked, comments, ""), markupamt,
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
        If emptask <> "" Then

            Me.ShowMessage("The following employee(s)(task(s)) were not added to estimate:  " & MiscFN.RemoveTrailingDelimiter(emptask, ","))

        End If

        CloseAndRefresh()

    End Sub

    Private Sub RadioButtonDefault_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDefault.CheckedChanged
        If Me.RadioButtonDisbursed.Checked = True Then
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colHOURS").Display = True
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colJOB_HRS").Display = False
        Else
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colHOURS").Display = False
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colJOB_HRS").Display = True
        End If
        RadGridCopyFromQuotes.Rebind()
    End Sub

    Private Sub RadioButtonDisbursed_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonDisbursed.CheckedChanged
        If Me.RadioButtonDisbursed.Checked = True Then
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colHOURS").Display = True
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colJOB_HRS").Display = False
        Else
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colHOURS").Display = False
            Me.RadGridCopyFromQuotes.MasterTableView.GetColumn("colJOB_HRS").Display = True
        End If
        RadGridCopyFromQuotes.Rebind()
    End Sub


End Class
