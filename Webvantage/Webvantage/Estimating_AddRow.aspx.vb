Public Class Estimating_AddRow
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

    Private PageMode As Integer = 0  '  0 = Template Add,  1 = New Quick Add

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
    End Sub

    Dim i As Integer = 0
    Private Sub RadGridQuickAdd_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuickAdd.ItemDataBound
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then
            Try
                Dim hf As System.Web.UI.WebControls.HiddenField
                Dim txt As System.Web.UI.WebControls.TextBox
                Dim imgbtn As System.Web.UI.WebControls.ImageButton
                Dim ColumnClientSelectClientId As String = Nothing
                Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item
                hf = e.Item.FindControl("HfFunctionType")
                txt = e.Item.FindControl("TxtSUPPLIED_BY")
                imgbtn = e.Item.FindControl("ImgBtnSuppliedBy")
                If hf.Value = "I" Or hf.Value = "C" Then
                    imgbtn.Visible = False
                    txt.ReadOnly = True
                    'imgbtn.Attributes.Add("onclick", "radalert('Supplied By can only be specified for employee time or vendor functions');")
                    'tb.Attributes.Add("ondblclick", "radalert('Supplied By can only be specified for employee time or vendor functions');")
                Else
                    imgbtn.Attributes.Add("onclick", "OpenRadWindowLookup('LookUp.aspx?form=suppliedby&page=qa&control=" & txt.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&funccode=" & dataItem.GetDataKeyValue("FNC_CODE") & "');return false;")
                    'tb.Attributes.Add("ondblclick", "Javascript:OpenRadWindowLookup('LookUp.aspx?form=suppliedby&control=" & tb.ClientID & "&type=suppliedby&functype=' + document.forms[0]." & hf.ClientID & ".value + '&funccode=" & fcode & "');return false;")
                End If

                ColumnClientSelectClientId = DirectCast(dataItem("ColumnClientSelect").Controls(0), System.Web.UI.WebControls.CheckBox).ClientID

                Using TextBox = DirectCast(dataItem.FindControl("TxtROW_QTY"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(dataItem.FindControl("TxtSUPPLIED_BY"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

                Using TextBox = DirectCast(dataItem.FindControl("TxtHRS_QTY"), System.Web.UI.WebControls.TextBox)

                    TextBox.Attributes.Add("onkeydown", "CheckTheRow('" & ColumnClientSelectClientId & "');")

                End Using

            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub RadGridQuickAdd_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuickAdd.NeedDataSource
        Try
            Dim s As cSchedule = New cSchedule(Session("ConnString"), Session("EmpCode"))
            Dim dt As New DataTable
            Dim dv As New DataView
            Dim est As cEstimating = New cEstimating(Session("ConnString"), Session("EmpCode"))

            dt = est.GetQuickAddDT(False, Me.JobNum, Me.ClientCode)
            dv = dt.DefaultView

            Me.RadGridQuickAdd.DataSource = dv
        Catch ex As Exception

        End Try
    End Sub

    Private Sub BtnAddTasks_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnAddTasks.Click
        Try
            'If e.CommandName = "AddTasks" Then
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim v As New cValidations(Session("ConnString"))

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
            Dim NumberOfRowsToAdd As Integer = 1

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
                            Dim s As String = CType(gridDataItem("ColROW_QTY").FindControl("TxtROW_QTY"), TextBox).Text
                            If IsNumeric(s) = True Then
                                NumberOfRowsToAdd = CType(s, Integer)
                            Else
                                NumberOfRowsToAdd = 1
                            End If
                        Catch ex As Exception
                            NumberOfRowsToAdd = 1
                        End Try
                        Try
                            fnctype = CType(gridDataItem("colSUPPLIED_BY").FindControl("HfFunctionType"), HiddenField).Value
                        Catch ex As Exception
                            fnctype = ""
                        End Try
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
                        If fnctype = "E" Then
                            If suppliedby <> "" Then
                                If v.ValidateEmpCodetd(suppliedby) = False Then
                                    suppliedby = ""
                                    Me.ShowMessage("Invalid Employee Code.")
                                    Exit Sub
                                End If
                                Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
                                Dim Employeeoffice As System.Collections.Generic.List(Of String) = Nothing
                                Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))
                                    Employeeoffice = AdvantageFramework.Database.Procedures.EmployeeOffice.LoadByEmployeeCode(DbContext, Session("EmpCode")).Select(Function(Entity) Entity.OfficeCode).ToList

                                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Session("ConnString"), Session("UserCode"))
                                        Try
                                            Employee = (From Entity In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllEmployeesByUser(DbContext, SecurityDbContext, Session("UserCode"))
                                                        Where Entity.Code = suppliedby
                                                        Select Entity).Single
                                        Catch ex As Exception
                                            Employee = Nothing
                                        End Try

                                        If Employeeoffice.Count > 0 And Employee.Code <> Session("EmpCode") Then
                                            If Employeeoffice.Contains(Employee.OfficeCode) = False Then
                                                Me.ShowMessage("Invalid Employee Code.")
                                                Exit Sub
                                            End If
                                        End If
                                    End Using
                                End Using

                            End If
                        ElseIf fnctype = "V" Then
                            If suppliedby <> "" Then
                                If v.ValidateVendor(suppliedby) = False Then
                                    suppliedby = ""
                                    Me.ShowMessage("Invalid Vendor Code.")
                                    Exit Sub
                                End If
                            End If
                        End If
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
                                    If markuppct <> 0 Then
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
                            For i As Integer = 0 To NumberOfRowsToAdd - 1


                                oEstimating.AddNewFunction(EstNum, EstCompNum, QuoteNum, RevNum, 0, functioncode, markuppct, contpct, quantityhours,
                                                        rate, suppliedby, "", extamt, taxcode, "", markupamt,
                                                        contamt, linetotal, 1, Session("UserCode"), fnctype, fnccpmflag, taxstatepct, taxcountypct, taxcitypct, taxcomm, taxcommonly,
                                                        taxresale, fnccommflag, fnctaxflag, fncnobillflag, extnonresaletax, extstateresale, extcountyresale,
                                                        extcityresale, extmucont, extstatecont, extcountycont, extcitycont, extnrcont, linetotalcont, feetime, 0)


                            Next
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
            ' End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("Estimating_Quote.aspx?EstNum=" & Me.EstNum & "&EstComp=" & Me.EstCompNum & "&QuoteNum=" & Me.QuoteNum & "&RevNum=" & RevNum, True)
    End Sub

End Class
