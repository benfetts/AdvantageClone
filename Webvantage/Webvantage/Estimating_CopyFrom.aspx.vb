Imports Webvantage.cGlobals

Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Public Class Estimating_CopyFrom
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
            Me.hfApproved.Value = "1"
            'Me.BtnCopy.Attributes.Add("onclick", "return confirm('This quote is approved. Are you sure you want to save the changes?');")
        Else
            'Me.BtnCopy.Attributes.Add("onclick", "")
        End If
        If Not Me.IsPostBack Then
            LoadQuoteData()
        End If
        Me.LoadLookups()
    End Sub

    Private Sub LoadLookups()
        Me.HlClient.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=client&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlDivision.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=division&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlProduct.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp_Quick.aspx?fromform=schedulefilterjh&type=product&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlEstimate.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatequotedetailscopy&type=estimate&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value);return false;")
        Me.HlEstimateComponent.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatequotedetailscopy&type=estimatecomp&control=" & Me.TxtEstimateComponent.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value);return false;")
        Me.HlQuote.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=estimatequotedetailscopy&type=estimatequote&control=" & Me.TxtEstimateComponent.ClientID & "&client=' + document.forms[0]." & Me.TxtClientCode.ClientID & ".value + '&division=' + document.forms[0]." & Me.TxtDivisionCode.ClientID & ".value + '&product=' + document.forms[0]." & Me.TxtProductCode.ClientID & ".value + '&estimate=' + document.forms[0]." & Me.TxtEstimate.ClientID & ".value + '&estimatecomp=' + document.forms[0]." & Me.TxtEstimateComponent.ClientID & ".value);return false;")
    End Sub

    Private Sub LoadQuoteData()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dr As SqlDataReader
            dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
            If dr.HasRows = True Then
                Do While dr.Read
                    Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
                    Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
                    'Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
                    Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
                    Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
                    'Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
                    Me.TxtClientCode.Text = dr("CL_CODE")
                    Me.TxtDivisionCode.Text = dr("DIV_CODE")
                    Me.TxtProductCode.Text = dr("PRD_CODE")
                    Me.TxtClientDescription.Text = dr("CL_NAME")
                    Me.TxtDivisionDescription.Text = dr("DIV_NAME")
                    Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
                Loop
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridCopyFromQuotes_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCopyFromQuotes.NeedDataSource
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim max As Integer
        If Me.TxtEstimate.Text <> "" And Me.TxtEstimateComponent.Text <> "" And Me.TxtQuote.Text <> "" Then
            If IsNumeric(Me.TxtEstimate.Text) = True And IsNumeric(Me.TxtEstimateComponent.Text) = True And IsNumeric(Me.TxtQuote.Text) = True Then
                max = est.GetEstimateQuoteMaxRevision(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuote.Text)
                Me.RadGridCopyFromQuotes.DataSource = est.GetEstimateQuoteDetailsDS(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuote.Text, max)
            End If
        End If
    End Sub

    'Private Sub BtnRefresh_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnRefresh.Click
    '    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
    '    If Me.TxtEstimate.Text <> "" Then
    '        If IsNumeric(Me.TxtEstimate.Text) = False Then
    '            QuickMSG("Please enter a valid estimate number.")
    '            Me.TxtEstimate.Focus()
    '            Exit Sub
    '        End If
    '    End If
    '    If Me.TxtEstimateComponent.Text <> "" Then
    '        If IsNumeric(Me.TxtEstimateComponent.Text) = False Then
    '            QuickMSG("Please enter a valid component number.")
    '            Me.TxtEstimateComponent.Focus()
    '            Exit Sub
    '        End If
    '    End If
    '    If Me.TxtQuote.Text <> "" Then
    '        If IsNumeric(Me.TxtQuote.Text) = False Then
    '            QuickMSG("Please enter a valid quote number.")
    '            Exit Sub
    '        End If
    '    End If
    '    If Me.TxtEstimate.Text <> "" Then
    '        EstNum = CInt(Me.TxtEstimate.Text)
    '    End If
    '    If Me.TxtEstimateComponent.Text <> "" Then
    '        EstComp = CInt(Me.TxtEstimateComponent.Text)
    '    End If
    '    If Me.TxtQuote.Text <> "" Then
    '        QuoteNum = CInt(Me.TxtQuote.Text)
    '    End If

    '    If EstNum <= 0 Then
    '        QuickMSG("Please enter a valid estimate number.")
    '        Me.TxtEstimate.Focus()
    '        Exit Sub
    '    End If
    '    If EstComp <= 0 Then
    '        If EstNum > 0 Then
    '            Me.TxtEstimate.Text = JobNum
    '        End If
    '        QuickMSG("Please enter a valid component number.")
    '        Me.TxtEstimateComponent.Focus()
    '        Exit Sub
    '    End If
    '    If QuoteNum <= 0 Then
    '        QuickMSG("Please enter a valid quote number.")
    '        Me.TxtQuote.Focus()
    '        Exit Sub
    '    End If
    '    'Some basic job validation:
    '    Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
    '    If myVal.ValidateEstimateNumber(EstNum) = False Then
    '        QuickMSG("This estimate does not exist!")
    '        Me.TxtEstimate.Focus()
    '        Exit Sub
    '    End If
    '    If myVal.ValidateEstimateCompNumber(EstNum, EstComp) = False Then
    '        QuickMSG("This is not a valid estimate/component!")
    '        Me.TxtEstimate.Focus()
    '        Exit Sub
    '    End If
    '    'If myVal.ValidateQuoteNumber(EstNum, EstComp, QuoteNum) = False Then
    '    '    QuickMSG("This is not a valid estimate/component/quote!")
    '    '    Me.TxtEstimate.Focus()
    '    '    Exit Sub
    '    'End If
    '    'If JobNum > 0 And JobComp > 0 Then
    '    '    If myVal.ValidateJobCompIsViewable(Session("UserCode"), JobNum, JobComp) = False Then
    '    '        QuickMSG("Access to this job/comp is denied.")
    '    '        Me.TxtJobNum.Focus()
    '    '        Exit Sub
    '    '    End If
    '    '    'If myVal.ValidateJobCompIsEditable(JobNum, JobComp) = False Then
    '    '    '    QuickMSG("Job/comp process control does not allow access.")
    '    '    '    Me.TxtJobNum.Focus()
    '    '    '    Exit Sub
    '    '    'End If
    '    'End If
    '    Me.lblMSG.Text = ""
    '    Dim dr As SqlDataReader = est.GetEstimateQuoteInfo(EstNum, EstComp, QuoteNum, 0)
    '    If dr.HasRows = True Then
    '        Do While dr.Read
    '            If IsDBNull(dr("CL_CODE")) = False Then
    '                Me.TxtClientCode.Text = dr("CL_CODE")
    '            End If
    '            If IsDBNull(dr("CL_NAME")) = False Then
    '                Me.TxtClientDescription.Text = dr("CL_NAME")
    '            End If
    '            If IsDBNull(dr("DIV_CODE")) = False Then
    '                Me.TxtDivisionCode.Text = dr("DIV_CODE")
    '            End If
    '            If IsDBNull(dr("DIV_NAME")) = False Then
    '                Me.TxtDivisionDescription.Text = dr("DIV_NAME")
    '            End If
    '            If IsDBNull(dr("PRD_CODE")) = False Then
    '                Me.TxtProductCode.Text = dr("PRD_CODE")
    '            End If
    '            If IsDBNull(dr("PRD_DESCRIPTION")) = False Then
    '                Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
    '            End If
    '            If IsDBNull(dr("ESTIMATE_NUMBER")) = False Then
    '                Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
    '            End If
    '            If IsDBNull(dr("EST_LOG_DESC")) = False Then
    '                Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
    '            End If
    '            If IsDBNull(dr("EST_COMPONENT_NBR")) = False Then
    '                Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
    '            End If
    '            If IsDBNull(dr("EST_COMP_DESC")) = False Then
    '                Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
    '            End If
    '            If IsDBNull(dr("EST_QUOTE_NBR")) = False Then
    '                Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
    '            End If
    '            If IsDBNull(dr("EST_QUOTE_DESC")) = False Then
    '                Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
    '            End If
    '            'If IsDBNull(dr("JOB_NUMBER")) = False Then
    '            '    Me.TxtJobNum.Text = dr("JOB_NUMBER")
    '            'End If
    '            'If IsDBNull(dr("JOB_DESC")) = False Then
    '            '    Me.TxtJobDescription.Text = dr("JOB_DESC")
    '            'End If
    '            'If IsDBNull(dr("JOB_COMPONENT_NBR")) = False Then
    '            '    Me.TxtJobCompNum.Text = dr("JOB_COMPONENT_NBR")
    '            'End If
    '            'If IsDBNull(dr("JOB_COMP_DESC")) = False Then
    '            '    Me.TxtJobCompDescription.Text = dr("JOB_COMP_DESC")
    '            'End If
    '        Loop
    '    End If
    '    dr.Close()
    '    Me.RadGridCopyFromQuotes.Rebind()
    'End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        Me.lblMSG.Text = TheMSG
    End Sub

    'Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
    '    'If e.CommandName = "AddFunctions" Then
    '    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
    '    Dim dt As DataTable

    '    Dim functioncode As String = ""
    '    Dim suppliedby As String = ""
    '    Dim markuppct As Decimal = 0.0
    '    Dim contpct As Decimal = 0.0
    '    Dim contamt As Decimal = 0.0
    '    Dim quantityhours As Decimal = 0.0
    '    Dim rate As Decimal = 0.0
    '    Dim extamt As Decimal = 0.0
    '    Dim markupamt As Decimal = 0.0
    '    Dim fnctype As String = ""
    '    Dim fnccpmflag As Integer
    '    Dim taxcomm As Integer
    '    Dim taxcommonly As Integer
    '    Dim fncnobillflag As Integer
    '    Dim fnctaxflag As Integer
    '    Dim fnccommflag As Integer
    '    Dim taxstatepct As Decimal = 0.0
    '    Dim taxcountypct As Decimal = 0.0
    '    Dim taxcitypct As Decimal = 0.0
    '    Dim taxresale As Integer = 0
    '    Dim taxresalenbr As String = ""
    '    Dim extnonresaletax As Decimal = 0.0
    '    Dim extstateresale As Decimal = 0.0
    '    Dim extcountyresale As Decimal = 0.0
    '    Dim extcityresale As Decimal = 0.0
    '    Dim extstatenonresale As Decimal = 0.0
    '    Dim extcountynonresale As Decimal = 0.0
    '    Dim extcitynonresale As Decimal = 0.0
    '    Dim extstatemarkup As Decimal = 0.0
    '    Dim extcountymarkup As Decimal = 0.0
    '    Dim extcitymarkup As Decimal = 0.0
    '    Dim extmucont As Decimal = 0.0
    '    Dim extstatecont As Decimal = 0.0
    '    Dim extcountycont As Decimal = 0.0
    '    Dim extcitycont As Decimal = 0.0
    '    Dim extnrcont As Decimal = 0.0
    '    Dim linetotal As Decimal = 0.0
    '    Dim linetotalcont As Decimal = 0.0
    '    Dim taxcode As String = ""
    '    Dim estmarkuppct As Decimal = 0
    '    Dim jobmarkuppct As Decimal = 0
    '    Dim feetime As Integer = 0
    '    Dim estbillrateflag As Integer = 0
    '    Dim clcode As String
    '    Dim divcode As String
    '    Dim prdcode As String
    '    Dim blendedrate As Decimal = 0.0
    '    Dim seqnbr As Integer = 0
    '    Dim suppliedbynotes As String
    '    Dim fnccomment As String
    '    Dim inclcpu As Integer = 0

    '    Dim dr As SqlClient.SqlDataReader
    '    Dim max As Integer
    '    Dim sort As Integer
    '    'max = est.GetEstimateQuoteMaxRevision(EstimateNum, EstimateComp, EstimateQuote)
    '    dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
    '    If dr.HasRows = True Then
    '        Do While dr.Read
    '            clcode = dr("CL_CODE")
    '            divcode = dr("DIV_CODE")
    '            prdcode = dr("PRD_CODE")
    '            If IsDBNull(dr("BLENDED_TIME_RATE")) = False Then
    '                blendedrate = dr("BLENDED_TIME_RATE")
    '            Else
    '                blendedrate = -1.0
    '            End If
    '        Loop
    '    End If
    '    dr.Close()

    '    estbillrateflag = est.GetEstBillRateFlag(clcode, divcode, prdcode)

    '    Dim chk As CheckBox
    '    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCopyFromQuotes.MasterTableView.Items
    '        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
    '        If chk.Checked = True Then
    '            'Set variables:
    '            functioncode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")
    '            Try
    '                seqnbr = CType(CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFSeqNum"), HiddenField).Value, Integer)
    '            Catch ex As Exception
    '                seqnbr = 0
    '            End Try
    '            Try
    '                suppliedby = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
    '            Catch ex As Exception
    '                suppliedby = ""
    '            End Try
    '            Try
    '                quantityhours = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("TxtEST_REV_QUANTITY"), TextBox).Text, Decimal)
    '            Catch ex As Exception
    '                quantityhours = 0
    '            End Try
    '            Try
    '                suppliedbynotes = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFSuppliedByNotes"), HiddenField).Value
    '            Catch ex As Exception
    '                suppliedbynotes = ""
    '            End Try
    '            Try
    '                fnccomment = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncComment"), HiddenField).Value
    '            Catch ex As Exception
    '                fnccomment = ""
    '            End Try
    '            Try
    '                inclcpu = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFCPU"), HiddenField).Value, Integer)
    '            Catch ex As Exception
    '                inclcpu = 0
    '            End Try
    '            Try
    '                If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
    '                    rate = blendedrate
    '                Else
    '                    rate = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFRate"), HiddenField).Value, Decimal)
    '                End If
    '            Catch ex As Exception
    '                rate = 0
    '            End Try


    '            If Me.cbRecalculate.Checked = True Then
    '                If functioncode = "" Then
    '                    '"Function Code Required."
    '                    Exit Sub
    '                Else
    '                    markuppct = 0.0
    '                    markupamt = 0.0
    '                    taxcode = ""
    '                    contamt = 0.0
    '                    linetotalcont = 0.0
    '                    linetotal = 0.0
    '                    feetime = 0
    '                    'rate = 0.0
    '                    extamt = 0.0
    '                    dt = est.GetDefaultFunctionData(functioncode, Session("QuickAddEstJobNum"), Session("QuickAddEstJobCompNum"), Session("QuickAddEstClient"), Session("QuickAddEstDivision"), Session("QuickAddEstProduct"), Session("QuickAddEstSalesClass"), suppliedby)
    '                    If dt.Rows.Count > 0 Then
    '                        If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
    '                            fnctype = dt.Rows(0)("FNC_TYPE")
    '                        End If
    '                        If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
    '                            rate = blendedrate
    '                        ElseIf fnctype = "V" Or fnctype = "I" Then
    '                            If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
    '                                If dt.Rows(0)("BILLING_RATE") <> 0 Then
    '                                    rate = dt.Rows(0)("BILLING_RATE")
    '                                End If
    '                            End If
    '                        Else
    '                            If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
    '                                rate = dt.Rows(0)("BILLING_RATE")
    '                            End If
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("NOBILL_FLAG")) = False Then
    '                            fncnobillflag = dt.Rows(0)("NOBILL_FLAG")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("TAX_COMM")) = False Then
    '                            taxcomm = dt.Rows(0)("TAX_COMM")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("TAX_COMM_ONLY")) = False Then
    '                            taxcommonly = dt.Rows(0)("TAX_COMM_ONLY")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("TAX_CODE")) = False Then
    '                            taxcode = dt.Rows(0)("TAX_CODE")
    '                            fnctaxflag = 1
    '                        Else
    '                            taxcode = ""
    '                            fnctaxflag = 0
    '                        End If
    '                        taxstatepct = dt.Rows(0)("TAX_STATE_PERCENT")
    '                        taxcountypct = dt.Rows(0)("TAX_COUNTY_PERCENT")
    '                        taxcitypct = dt.Rows(0)("TAX_CITY_PERCENT")
    '                        If IsDBNull(dt.Rows(0)("TAX_RESALE")) = False Then
    '                            taxresale = dt.Rows(0)("TAX_RESALE")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("TAX_RESALE_NUMBER")) = False Then
    '                            taxresalenbr = dt.Rows(0)("TAX_RESALE_NUMBER")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("FEE_TIME_FLAG")) = False Then
    '                            feetime = dt.Rows(0)("FEE_TIME_FLAG")
    '                        End If
    '                        If IsDBNull(dt.Rows(0)("COMM")) = False Then
    '                            markuppct = dt.Rows(0)("COMM")
    '                            If markuppct = 0 Then
    '                                fnccommflag = 0
    '                            Else
    '                                fnccommflag = 1
    '                            End If
    '                        Else
    '                            fnccommflag = 1
    '                            markuppct = estmarkuppct
    '                        End If
    '                        If rate > 0 Then
    '                            extamt = quantityhours * rate
    '                        End If
    '                        If markuppct <> 0 And extamt > 0 Then
    '                            markupamt = extamt * (markuppct / 100)
    '                            extmucont = markupamt * (contpct / 100)
    '                        Else
    '                            markupamt = 0.0
    '                        End If
    '                        If contpct <> 0 Then
    '                            contamt = extamt * (contpct / 100)
    '                            If markuppct > 0 Then
    '                                linetotalcont += (markupamt * (contpct / 100))
    '                            End If
    '                        End If
    '                        If taxresale = 1 Then
    '                            If taxcommonly <> 1 Then
    '                                extstateresale = extamt * (taxstatepct / 100)
    '                                extcountyresale = extamt * (taxcountypct / 100)
    '                                extcityresale = extamt * (taxcitypct / 100)
    '                            End If
    '                            If taxcomm = 1 Then
    '                                If markupamt > 0 Then
    '                                    extstatemarkup = markupamt * (taxstatepct / 100)
    '                                    extcountymarkup = markupamt * (taxcountypct / 100)
    '                                    extcitymarkup = markupamt * (taxcitypct / 100)
    '                                End If
    '                            End If
    '                            extstateresale += extstatemarkup
    '                            extcountyresale += extcountymarkup
    '                            extcityresale += extcitymarkup
    '                            If contamt > 0 Then
    '                                If taxcomm = 1 And taxcommonly = 1 Then
    '                                    extstatecont = extmucont * (taxstatepct / 100)
    '                                    extcountycont = extmucont * (taxcountypct / 100)
    '                                    extcitycont = extmucont * (taxcitypct / 100)
    '                                ElseIf taxcomm = 1 Then
    '                                    extstatecont = (contamt + extmucont) * (taxstatepct / 100)
    '                                    extcountycont = (contamt + extmucont) * (taxcountypct / 100)
    '                                    extcitycont = (contamt + extmucont) * (taxcitypct / 100)
    '                                Else
    '                                    extstatecont = contamt * (taxstatepct / 100)
    '                                    extcountycont = contamt * (taxcountypct / 100)
    '                                    extcitycont = contamt * (taxcitypct / 100)
    '                                End If
    '                            End If
    '                        End If
    '                        If taxresale <> 1 Then
    '                            If fnctype = "V" Then
    '                                If taxcommonly <> 1 Then
    '                                    extstatenonresale = extamt * (taxstatepct / 100)
    '                                    extcountynonresale = extamt * (taxcountypct / 100)
    '                                    extcitynonresale = extamt * (taxcitypct / 100)
    '                                    extnonresaletax = extstatenonresale + extcountynonresale + extcitynonresale
    '                                End If
    '                                If contamt > 0 Then
    '                                    If taxcomm = 1 And taxcommonly = 1 Then
    '                                        extnrcont = extmucont * (taxstatepct / 100) + extmucont * (taxcountypct / 100) + extmucont * (taxcitypct / 100)
    '                                    ElseIf taxcomm = 1 Then
    '                                        extnrcont = (contamt + extmucont) * (taxstatepct / 100) + contamt * (taxcountypct / 100) + contamt * (taxcitypct / 100)
    '                                    End If
    '                                End If
    '                            ElseIf fnctype = "E" Or fnctype = "I" Then
    '                                If taxcommonly <> 1 Then
    '                                    extstateresale = extamt * (taxstatepct / 100)
    '                                    extcountyresale = extamt * (taxcountypct / 100)
    '                                    extcityresale = extamt * (taxcitypct / 100)
    '                                End If
    '                                If contamt > 0 Then
    '                                    If taxcomm = "1" And taxcommonly = "1" Then
    '                                        extstatecont = extmucont * (taxstatepct / 100)
    '                                        extcountycont = extmucont * (taxcountypct / 100)
    '                                        extcitycont = extmucont * (taxcitypct / 100)
    '                                    ElseIf taxcomm = "1" Then
    '                                        extstatecont = (contamt + extmucont) * (taxstatepct / 100)
    '                                        extcountycont = (contamt + extmucont) * (taxcountypct / 100)
    '                                        extcitycont = (contamt + extmucont) * (taxcitypct / 100)
    '                                    End If
    '                                End If
    '                            End If
    '                            If taxcomm = 1 Then
    '                                If markupamt > 0 Then
    '                                    extstatemarkup = markupamt * (taxstatepct / 100)
    '                                    extcountymarkup = markupamt * (taxcountypct / 100)
    '                                    extcitymarkup = markupamt * (taxcitypct / 100)
    '                                End If
    '                            End If
    '                            extstateresale += extstatemarkup
    '                            extcountyresale += extcountymarkup
    '                            extcityresale += extcitymarkup
    '                        End If
    '                    End If
    '                    dt = est.GetAddNewFunctionData(functioncode)
    '                    If dt.Rows.Count > 0 Then
    '                        fnccpmflag = dt.Rows(0)("FNC_CPM_FLAG")
    '                    End If
    '                End If

    '                linetotal = extamt + markupamt + Math.Round(extstateresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountyresale, 2, MidpointRounding.AwayFromZero) + Math.Round(extcityresale, 2, MidpointRounding.AwayFromZero)
    '                linetotalcont += contamt + Math.Round(extstatecont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcountycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extcitycont, 2, MidpointRounding.AwayFromZero) + Math.Round(extnrcont, 2, MidpointRounding.AwayFromZero)
    '            Else
    '                Try
    '                    extamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text, Decimal)
    '                Catch ex As Exception
    '                    extamt = 0
    '                End Try
    '                'End If

    '                Try
    '                    markuppct = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMarkupPct"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    markuppct = 0
    '                End Try

    '                Try
    '                    contpct = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFContPct"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    contpct = 0
    '                End Try

    '                Try
    '                    fnctype = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncType"), HiddenField).Value
    '                Catch ex As Exception
    '                    fnctype = ""
    '                End Try

    '                Try
    '                    If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
    '                        rate = blendedrate
    '                    Else
    '                        rate = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFRate"), HiddenField).Value, Decimal)
    '                    End If
    '                Catch ex As Exception
    '                    rate = 0
    '                End Try

    '                Try
    '                    taxcode = CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCode"), HiddenField).Value
    '                Catch ex As Exception
    '                    taxcode = ""
    '                End Try

    '                Try
    '                    markupamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMarkupAmt"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    markupamt = 0
    '                End Try

    '                Try
    '                    contamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFContAmt"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    contamt = 0
    '                End Try

    '                Try
    '                    linetotal = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFLineTotal"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    linetotal = 0
    '                End Try

    '                Try
    '                    fnctype = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncType"), HiddenField).Value
    '                Catch ex As Exception
    '                    fnctype = ""
    '                End Try

    '                Try
    '                    fnccpmflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFCPMFlag"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    fnccpmflag = 0
    '                End Try

    '                Try
    '                    taxstatepct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxStatePct"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    taxstatepct = 0
    '                End Try
    '                Try
    '                    taxcountypct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCountyPct"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    taxcountypct = 0
    '                End Try
    '                Try
    '                    taxcitypct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCityPct"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    taxcitypct = 0
    '                End Try

    '                Try
    '                    taxcomm = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxComm"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    taxcomm = 0
    '                End Try
    '                Try
    '                    taxcommonly = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCommOnly"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    taxcommonly = 0
    '                End Try
    '                Try
    '                    taxresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxResale"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    taxresale = 0
    '                End Try
    '                Try
    '                    fnccommflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFCommFlag"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    fnccommflag = 0
    '                End Try
    '                Try
    '                    fnctaxflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxFlag"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    fnctaxflag = 0
    '                End Try
    '                Try
    '                    fncnobillflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFNonbillFlag"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    fncnobillflag = 0
    '                End Try
    '                Try
    '                    feetime = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFFeeTime"), HiddenField).Value, Integer)
    '                Catch ex As Exception
    '                    feetime = 0
    '                End Try
    '                Try
    '                    extnonresaletax = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFNonResaleTax"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extnonresaletax = 0
    '                End Try

    '                Try
    '                    extstateresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtStateResale"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extstateresale = 0
    '                End Try
    '                Try
    '                    extcountyresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtCountyResale"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extcountyresale = 0
    '                End Try
    '                Try
    '                    extcityresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtCityResale"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extcityresale = 0
    '                End Try

    '                Try
    '                    extmucont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMUCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extmucont = 0
    '                End Try
    '                Try
    '                    extstatecont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtStateCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extstatecont = 0
    '                End Try
    '                Try
    '                    extcountycont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtCountyCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extcountycont = 0
    '                End Try
    '                Try
    '                    extcitycont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtCityCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extcitycont = 0
    '                End Try
    '                Try
    '                    extnrcont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFNRCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    extnrcont = 0
    '                End Try
    '                Try
    '                    linetotalcont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFLineTotalCont"), HiddenField).Value, Decimal)
    '                Catch ex As Exception
    '                    linetotalcont = 0
    '                End Try
    '            End If



    '            'Save:
    '            Try
    '                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
    '                oEstimating.AddNewFunction(EstimateNum, EstimateComp, EstimateQuote, RevNum, seqnbr, functioncode, markuppct, contpct, quantityhours, _
    '                                            rate, suppliedby, suppliedbynotes, extamt, taxcode, fnccomment, markupamt, _
    '                                            contamt, linetotal, inclcpu, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly, _
    '                                            taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale, _
    '                                            extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime)
    '            Catch ex As Exception
    '            End Try
    '        End If
    '    Next
    '    CloseAndRefresh()
    '    'End If

    'End Sub

    Private Sub CloseAndRefresh()
        'Dim FunctionName As String = "RefreshFileGrid"
        'Me.LitScript.Text = "<script>CallFunctionOnParentPage('" + FunctionName + "');</" + "script>"
        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx?EstNum=" & Me.EstimateNum & "&EstComp=" & Me.EstimateComp & "&QuoteNum=" & Me.EstimateQuote & "&RevNum=" & RevNum, True)
    End Sub

    Private Sub RadToolBarQuote_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarQuote.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Add"
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim dt As DataTable

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
                    Dim seqnbr As Integer = 0
                    Dim suppliedbynotes As String
                    Dim fnccomment As String
                    Dim inclcpu As Integer = 0

                    Dim quotecomments As String = ""
                    Dim quotecommentsHTML As String = ""

                    Dim dr As SqlClient.SqlDataReader
                    Dim max As Integer
                    Dim sort As Integer
                    'max = est.GetEstimateQuoteMaxRevision(EstimateNum, EstimateComp, EstimateQuote)
                    dr = est.GetEstimateQuoteInfo(EstimateNum, EstimateComp, EstimateQuote, RevNum)
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
                            If IsDBNull(dr("EST_QTE_COMMENT")) = False Then
                                quotecomments = dr("EST_QTE_COMMENT")
                            End If
                            If IsDBNull(dr("EST_QTE_COMMENT_HTML")) = False Then
                                quotecommentsHTML = dr("EST_QTE_COMMENT_HTML")
                            End If
                        Loop
                    End If
                    dr.Close()

                    estbillrateflag = est.GetEstBillRateFlag(clcode, divcode, prdcode)

                    Dim chk As CheckBox
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridCopyFromQuotes.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            'Set variables:
                            functioncode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")
                            Try
                                seqnbr = CType(CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFSeqNum"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                seqnbr = 0
                            End Try
                            Try
                                suppliedby = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("TxtEST_REV_SUP_BY_CDE"), TextBox).Text
                            Catch ex As Exception
                                suppliedby = ""
                            End Try
                            Try
                                quantityhours = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("TxtEST_REV_QUANTITY"), TextBox).Text, Decimal)
                            Catch ex As Exception
                                quantityhours = 0
                            End Try
                            Try
                                suppliedbynotes = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFSuppliedByNotes"), HiddenField).Value
                            Catch ex As Exception
                                suppliedbynotes = ""
                            End Try
                            Try
                                fnccomment = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncComment"), HiddenField).Value
                            Catch ex As Exception
                                fnccomment = ""
                            End Try
                            Try
                                inclcpu = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFCPU"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                inclcpu = 0
                            End Try
                            Try
                                fnccpmflag = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFCPMFlag"), HiddenField).Value, Integer)
                            Catch ex As Exception
                                fnccpmflag = 0
                            End Try
                            Try
                                If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
                                    rate = blendedrate
                                Else
                                    rate = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFRate"), HiddenField).Value, Decimal)
                                End If
                            Catch ex As Exception
                                rate = 0
                            End Try


                            If Me.cbRecalculate.Checked = True Then
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
                                    'rate = 0.0
                                    extamt = 0.0
                                    dt = est.GetDefaultFunctionData(functioncode, JobNum, JobComp, ClientCode, DivisionCode, ProductCode, SalesClass, suppliedby)
                                    If dt.Rows.Count > 0 Then
                                        If IsDBNull(dt.Rows(0)("FNC_TYPE")) = False Then
                                            fnctype = dt.Rows(0)("FNC_TYPE")
                                        End If
                                        If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
                                            rate = blendedrate
                                        ElseIf fnctype = "V" Or fnctype = "I" Then
                                            If IsDBNull(dt.Rows(0)("BILLING_RATE")) = False Then
                                                If dt.Rows(0)("BILLING_RATE") <> 0 Then
                                                    rate = dt.Rows(0)("BILLING_RATE")
                                                End If
                                            End If
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
                                            If fnccpmflag = 1 Then
                                                extamt = (quantityhours / 1000) * rate
                                            Else
                                                extamt = quantityhours * rate
                                            End If
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
                            Else
                                Try
                                    extamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("TxtEST_REV_EXT_AMT"), TextBox).Text, Decimal)
                                Catch ex As Exception
                                    extamt = 0
                                End Try
                                'End If

                                Try
                                    markuppct = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMarkupPct"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    markuppct = 0
                                End Try

                                Try
                                    contpct = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFContPct"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    contpct = 0
                                End Try

                                Try
                                    fnctype = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncType"), HiddenField).Value
                                Catch ex As Exception
                                    fnctype = ""
                                End Try

                                Try
                                    If estbillrateflag = 1 And fnctype = "E" And blendedrate <> -1.0 Then
                                        rate = blendedrate
                                    Else
                                        rate = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFRate"), HiddenField).Value, Decimal)
                                    End If
                                Catch ex As Exception
                                    rate = 0
                                End Try

                                Try
                                    taxcode = CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCode"), HiddenField).Value
                                Catch ex As Exception
                                    taxcode = ""
                                End Try

                                Try
                                    markupamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMarkupAmt"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    markupamt = 0
                                End Try

                                Try
                                    contamt = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFContAmt"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    contamt = 0
                                End Try

                                Try
                                    linetotal = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFLineTotal"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    linetotal = 0
                                End Try

                                Try
                                    fnctype = CType(gridDataItem("colEST_REV_SUP_BY_CDE").FindControl("HFFncType"), HiddenField).Value
                                Catch ex As Exception
                                    fnctype = ""
                                End Try

                                Try
                                    fnccpmflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFCPMFlag"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    fnccpmflag = 0
                                End Try

                                Try
                                    taxstatepct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxStatePct"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    taxstatepct = 0
                                End Try
                                Try
                                    taxcountypct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCountyPct"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    taxcountypct = 0
                                End Try
                                Try
                                    taxcitypct = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCityPct"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    taxcitypct = 0
                                End Try

                                Try
                                    taxcomm = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxComm"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    taxcomm = 0
                                End Try
                                Try
                                    taxcommonly = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxCommOnly"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    taxcommonly = 0
                                End Try
                                Try
                                    taxresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxResale"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    taxresale = 0
                                End Try
                                Try
                                    fnccommflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFCommFlag"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    fnccommflag = 0
                                End Try
                                Try
                                    fnctaxflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFTaxFlag"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    fnctaxflag = 0
                                End Try
                                Try
                                    fncnobillflag = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFNonbillFlag"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    fncnobillflag = 0
                                End Try
                                Try
                                    feetime = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFFeeTime"), HiddenField).Value, Integer)
                                Catch ex As Exception
                                    feetime = 0
                                End Try
                                Try
                                    extnonresaletax = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFNonResaleTax"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extnonresaletax = 0
                                End Try

                                Try
                                    extstateresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtStateResale"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extstateresale = 0
                                End Try
                                Try
                                    extcountyresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtCountyResale"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extcountyresale = 0
                                End Try
                                Try
                                    extcityresale = CType(CType(gridDataItem("colEST_REV_QUANTITY").FindControl("HFExtCityResale"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extcityresale = 0
                                End Try

                                Try
                                    extmucont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFMUCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extmucont = 0
                                End Try
                                Try
                                    extstatecont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtStateCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extstatecont = 0
                                End Try
                                Try
                                    extcountycont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtCountyCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extcountycont = 0
                                End Try
                                Try
                                    extcitycont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFExtCityCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extcitycont = 0
                                End Try
                                Try
                                    extnrcont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFNRCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    extnrcont = 0
                                End Try
                                Try
                                    linetotalcont = CType(CType(gridDataItem("colEST_REV_EXT_AMT").FindControl("HFLineTotalCont"), HiddenField).Value, Decimal)
                                Catch ex As Exception
                                    linetotalcont = 0
                                End Try
                            End If



                            'Save:
                            Try
                                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                                oEstimating.AddNewFunction(EstimateNum, EstimateComp, EstimateQuote, RevNum, seqnbr, functioncode, markuppct, contpct, quantityhours,
                                                            rate, suppliedby, suppliedbynotes, extamt, taxcode, fnccomment, markupamt,
                                                            contamt, linetotal, inclcpu, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly,
                                                            taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale,
                                                            extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime, 0)
                            Catch ex As Exception
                            End Try
                        End If
                    Next

                    If CheckBoxIncludeQuoteComments.Checked Then
                        Dim update As Boolean = est.UpdateCopyQuoteComments(EstimateNum, EstimateComp, EstimateQuote, RevNum, Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuote.Text, 0)
                    End If

                    CloseAndRefresh()

                Case "Refresh"
                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    If Me.TxtEstimate.Text <> "" Then
                        If IsNumeric(Me.TxtEstimate.Text) = False Then
                            QuickMSG("Please enter a valid estimate number.")
                            Me.TxtEstimate.Focus()
                            Exit Sub
                        End If
                    End If
                    If Me.TxtEstimateComponent.Text <> "" Then
                        If IsNumeric(Me.TxtEstimateComponent.Text) = False Then
                            QuickMSG("Please enter a valid component number.")
                            Me.TxtEstimateComponent.Focus()
                            Exit Sub
                        End If
                    End If
                    If Me.TxtQuote.Text <> "" Then
                        If IsNumeric(Me.TxtQuote.Text) = False Then
                            QuickMSG("Please enter a valid quote number.")
                            Exit Sub
                        End If
                    End If
                    If Me.TxtEstimate.Text <> "" Then
                        EstNum = CInt(Me.TxtEstimate.Text)
                    End If
                    If Me.TxtEstimateComponent.Text <> "" Then
                        EstComp = CInt(Me.TxtEstimateComponent.Text)
                    End If
                    If Me.TxtQuote.Text <> "" Then
                        QuoteNum = CInt(Me.TxtQuote.Text)
                    End If

                    If EstNum <= 0 Then
                        QuickMSG("Please enter a valid estimate number.")
                        Me.TxtEstimate.Focus()
                        Exit Sub
                    End If
                    If EstComp <= 0 Then
                        If EstNum > 0 Then
                            Me.TxtEstimate.Text = JobNum
                        End If
                        QuickMSG("Please enter a valid component number.")
                        Me.TxtEstimateComponent.Focus()
                        Exit Sub
                    End If
                    If QuoteNum <= 0 Then
                        QuickMSG("Please enter a valid quote number.")
                        Me.TxtQuote.Focus()
                        Exit Sub
                    End If
                    'Some basic job validation:
                    Dim myVal As cValidations = New cValidations(CStr(Session("ConnString")))
                    If myVal.ValidateEstimateNumber(EstNum) = False Then
                        QuickMSG("This estimate does not exist!")
                        Me.TxtEstimate.Focus()
                        Exit Sub
                    End If
                    If myVal.ValidateEstimateCompNumber(EstNum, EstComp) = False Then
                        QuickMSG("This is not a valid estimate/component!")
                        Me.TxtEstimate.Focus()
                        Exit Sub
                    End If
                    Me.lblMSG.Text = ""
                    Dim dr As SqlDataReader = est.GetEstimateQuoteInfo(EstNum, EstComp, QuoteNum, 0)
                    If dr.HasRows = True Then
                        Do While dr.Read
                            If IsDBNull(dr("CL_CODE")) = False Then
                                Me.TxtClientCode.Text = dr("CL_CODE")
                            End If
                            If IsDBNull(dr("CL_NAME")) = False Then
                                Me.TxtClientDescription.Text = dr("CL_NAME")
                            End If
                            If IsDBNull(dr("DIV_CODE")) = False Then
                                Me.TxtDivisionCode.Text = dr("DIV_CODE")
                            End If
                            If IsDBNull(dr("DIV_NAME")) = False Then
                                Me.TxtDivisionDescription.Text = dr("DIV_NAME")
                            End If
                            If IsDBNull(dr("PRD_CODE")) = False Then
                                Me.TxtProductCode.Text = dr("PRD_CODE")
                            End If
                            If IsDBNull(dr("PRD_DESCRIPTION")) = False Then
                                Me.TxtProductDescription.Text = dr("PRD_DESCRIPTION")
                            End If
                            If IsDBNull(dr("ESTIMATE_NUMBER")) = False Then
                                Me.TxtEstimate.Text = dr("ESTIMATE_NUMBER")
                            End If
                            If IsDBNull(dr("EST_LOG_DESC")) = False Then
                                Me.TxtEstimateDescription.Text = dr("EST_LOG_DESC")
                            End If
                            If IsDBNull(dr("EST_COMPONENT_NBR")) = False Then
                                Me.TxtEstimateComponent.Text = dr("EST_COMPONENT_NBR")
                            End If
                            If IsDBNull(dr("EST_COMP_DESC")) = False Then
                                Me.TxtEstimateComponentDescription.Text = dr("EST_COMP_DESC")
                            End If
                            If IsDBNull(dr("EST_QUOTE_NBR")) = False Then
                                Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
                            End If
                            If IsDBNull(dr("EST_QUOTE_DESC")) = False Then
                                Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
                            End If
                        Loop
                    End If
                    dr.Close()
                    Me.RadGridCopyFromQuotes.Rebind()

            End Select
        Catch ex As Exception

        End Try
    End Sub

End Class
