Imports System.Data.SqlClient

Partial Public Class Lookup_VendorPrice
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _VendorCode As String
    Public caller As String

#End Region

#Region " Methods "

#Region "  Form Event Handlers "

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Try
            Me.OpenerRadWindowName = Request.QueryString("opener")
        Catch ex As Exception
            Me.OpenerRadWindowName = ""
        End Try

        Try
            Me.caller = Request.QueryString("caller")
        Catch ex As Exception
            Me.caller = ""
        End Try

        If Not Page.IsPostBack Then
            Try
                If Request.QueryString("Vendor") <> "" Then
                    _VendorCode = Request.QueryString("Vendor")
                End If
            Catch ex As Exception

            End Try
        End If

    End Sub

    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)
        Try

            Dim oGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim ExtendedAmount As Decimal
            MyBase.RaisePostBackEvent(sourceControl, eventArgument)
            If sourceControl Is RadGridVendorPriceList AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") > -1) Then
                oGridDataItem = RadGridVendorPriceList.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True

                    Dim save As Boolean = SaveRate(Request.QueryString("dk"))
                    Dim sb As New System.Text.StringBuilder
                    With sb
                        .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("RateControl") & "').value = '" & Me.SelectedValue & "';")
                        If Me.SelectedValue <> "" AndAlso IsNumeric(Me.SelectedValue) Then
                            ExtendedAmount = CDec(Me.SelectedValue) * CDec(Request.QueryString("Qty"))
                        End If
                        .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("ExtControl") & "').value = '" & ExtendedAmount.ToString & "';")
                    End With
                    Me.ControlsToSet = sb.ToString
                    Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

                    Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")

                End If
            End If
            If sourceControl Is RadGridVendorPriceList AndAlso (eventArgument.IndexOf("IndexOfRowClicked") > -1) Then
                oGridDataItem = RadGridVendorPriceList.Items(Integer.Parse(eventArgument.Split(":"c)(1)))
                If oGridDataItem IsNot Nothing Then
                    oGridDataItem.Selected = True
                End If
            End If

        Catch ex As Exception

            If ex.Message.ToString().Contains("Invalid attempt to call FieldCount when reader is closed") = True Then

                Me.ShowMessage("You cannot search the data before the data is loaded")

            Else

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(ex.Message.ToString()))

            End If

            Me.CloseThisWindow()

        End Try


    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridVendorPriceList_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridVendorPriceList.NeedDataSource

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me.RadGridVendorPriceList.DataSource = (From Entity In AdvantageFramework.Database.Procedures.VendorPricing.LoadByVendorCode(DbContext, _VendorCode).Include("JobType")
                                                        Select New With {.VendorCode = Entity.VendorCode,
                                                                         .JobTypeCode = Entity.JobTypeCode,
                                                                         .JobTypeDescription = Entity.JobType.Description,
                                                                         .Rate = Entity.Rate,
                                                                         .Description = Entity.Description,
                                                                         .Notes = Entity.Notes}).ToList

            End Using

        Catch ex As Exception

        End Try

    End Sub

    Private Sub ButtonClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonClose.Click
        Try
            'Me.CloseThisWindow()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonSelect.Click
        Try
            Dim save As Boolean = SaveRate(Request.QueryString("dk"))
            Dim sb As New System.Text.StringBuilder
            Dim ExtendedAmount As Decimal
            With sb
                .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("RateControl") & "').value = '" & Me.SelectedValue & "';")
                If Me.SelectedValue <> "" AndAlso IsNumeric(Me.SelectedValue) Then
                    ExtendedAmount = CDec(Me.SelectedValue) * CDec(Request.QueryString("Qty"))
                End If
                .Append("CallingWindowContent.document.getElementById('" & Request.QueryString("ExtControl") & "').value = '" & ExtendedAmount.ToString & "';")
            End With
            Me.ControlsToSet = sb.ToString
            Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

            Telerik.Web.UI.RadAjaxManager.GetCurrent(Me.Page).ResponseScripts.Add("returnValue();")
            'Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

        Catch ex As Exception

        End Try
    End Sub

#End Region


    Private Function SelectedValue() As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorPriceList.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.GetDataKeyValue("Rate")
            End If
        Next
    End Function

    Private Function SelectedText() As String
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridVendorPriceList.MasterTableView.Items
            If gridDataItem.Selected = True Then
                Return gridDataItem.Item("Description").Text
            End If
        Next
    End Function

    Private Function SaveRate(ByVal dk As String)
        Try
            Dim EstNumber As Integer = 0
            Dim EstComponentNbr As Integer = 0
            Dim EstQuoteNbr As Integer = 0
            Dim EstRevNbr As Integer = 0
            Dim JobNumber As Integer = 0
            Dim JobComponentNbr As Integer = 0
            Dim SeqNbr As Integer = -1
            Dim SQL As New System.Text.StringBuilder

            Dim ar() As String
            ar = dk.Split("|")
            If ar.Length <> 5 Then
                Return "Error:  Could not get datakey"
                Exit Function
            End If
            Try
                EstNumber = ar(0)
            Catch ex As Exception
                EstNumber = 0
            End Try
            Try
                EstComponentNbr = ar(1)
            Catch ex As Exception
                EstComponentNbr = 0
            End Try
            Try
                EstQuoteNbr = ar(2)
            Catch ex As Exception
                EstQuoteNbr = 0
            End Try
            Try
                EstRevNbr = ar(3)
            Catch ex As Exception
                EstRevNbr = 0
            End Try
            Try
                SeqNbr = ar(4)
            Catch ex As Exception
                SeqNbr = -1
            End Try

            If EstNumber > 0 And EstComponentNbr > 0 And EstQuoteNbr > 0 And SeqNbr > -1 Then
                Dim IsValid As Boolean = False
                Dim GoodFncCode As String = ""
                Dim dt As New DataTable
                Dim v As New cValidations(HttpContext.Current.Session("ConnString"))
                Dim est As New cEstimating(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))
                Dim dtEst As DataTable
                dtEst = est.GetEstimateQuoteDetailBySeq(EstNumber, EstComponentNbr, EstQuoteNbr, EstRevNbr, SeqNbr)

                Dim parameterEST_REV_QUANTITY As New SqlParameter("@EST_REV_QUANTITY", SqlDbType.Decimal)
                Dim parameterEST_REV_RATE As New SqlParameter("@EST_REV_RATE", SqlDbType.Decimal)
                Dim parameterEST_REV_EXT_AMT As New SqlParameter("@EST_REV_EXT_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_COMM_PCT As New SqlParameter("@EST_REV_COMM_PCT", SqlDbType.Decimal)
                Dim parameterEXT_MARKUP_AMT As New SqlParameter("@EXT_MARKUP_AMT", SqlDbType.Decimal)
                Dim parameterEST_REV_CONT_PCT As New SqlParameter("@EST_REV_CONT_PCT", SqlDbType.Decimal)
                Dim parameterEXT_CONTINGENCY As New SqlParameter("@EXT_CONTINGENCY", SqlDbType.Decimal)
                Dim parameterEXT_MU_CONT As New SqlParameter("@EXT_MU_CONT", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL As New SqlParameter("@LINE_TOTAL", SqlDbType.Decimal)
                Dim parameterLINE_TOTAL_CONT As New SqlParameter("@LINE_TOTAL_CONT", SqlDbType.Decimal)
                Dim parameterEXT_STATE_RESALE As New SqlParameter("@EXT_STATE_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_RESALE As New SqlParameter("@EXT_COUNTY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_CITY_RESALE As New SqlParameter("@EXT_CITY_RESALE", SqlDbType.Decimal)
                Dim parameterEXT_STATE_CONT As New SqlParameter("@EXT_STATE_CONT", SqlDbType.Decimal)
                Dim parameterEXT_COUNTY_CONT As New SqlParameter("@EXT_COUNTY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_CITY_CONT As New SqlParameter("@EXT_CITY_CONT", SqlDbType.Decimal)
                Dim parameterEXT_NONRESALE_TAX As New SqlParameter("@EXT_NONRESALE_TAX", SqlDbType.Decimal)
                Dim parameterEXT_NR_CONT As New SqlParameter("@EXT_NR_CONT", SqlDbType.Decimal)
                Dim parameterTAX_CODE As New SqlParameter("@TAX_CODE", SqlDbType.VarChar)

                parameterEST_REV_QUANTITY.Value = 0
                parameterEST_REV_RATE.Value = 0
                parameterEST_REV_EXT_AMT.Value = 0
                parameterEXT_MARKUP_AMT.Value = 0
                parameterEXT_CONTINGENCY.Value = 0
                parameterEXT_MU_CONT.Value = 0
                parameterLINE_TOTAL.Value = 0
                parameterLINE_TOTAL_CONT.Value = 0
                parameterEXT_STATE_RESALE.Value = 0
                parameterEXT_COUNTY_RESALE.Value = 0
                parameterEXT_CITY_RESALE.Value = 0
                parameterEXT_STATE_CONT.Value = 0
                parameterEXT_COUNTY_CONT.Value = 0
                parameterEXT_CITY_CONT.Value = 0
                parameterEXT_NONRESALE_TAX.Value = 0
                parameterEXT_NR_CONT.Value = 0

                Dim taxresalestate As Decimal = 0.0
                Dim taxresalecity As Decimal = 0.0
                Dim taxresalecounty As Decimal = 0.0
                Dim taxnonresalestate As Decimal = 0.0
                Dim taxnonresalecity As Decimal = 0.0
                Dim taxnonresalecounty As Decimal = 0.0
                Dim taxmarkupstate As Decimal = 0.0
                Dim taxmarkupcity As Decimal = 0.0
                Dim taxmarkupcounty As Decimal = 0.0
                Dim taxcontstate As Decimal = 0.0
                Dim taxcontcity As Decimal = 0.0
                Dim taxcontcounty As Decimal = 0.0
                Dim ExtAmount As Decimal = 0.0
                Dim MarkupAmount As Decimal = 0.0
                Dim LineTotal As Decimal = 0.0
                Dim LineTotalCont As Decimal = 0.0
                Dim RowContAmt As Decimal = 0.0
                Dim RowMuContAmt As Decimal = 0.0
                Dim RowRate As Decimal = 0.0

                Dim CPM As String = ""
                If IsDBNull(dtEst.Rows(0)("EST_CPM_FLAG")) = False Then
                    CPM = dtEst.Rows(0)("EST_CPM_FLAG").ToString()
                End If
                Dim Qty As Decimal = 0.0
                If IsDBNull(dtEst.Rows(0)("EST_REV_QUANTITY")) = False Then
                    Qty = dtEst.Rows(0)("EST_REV_QUANTITY")
                End If
                Dim MarkupPct As Decimal = 0.0
                If IsDBNull(dtEst.Rows(0)("EST_REV_COMM_PCT")) = False Then
                    MarkupPct = dtEst.Rows(0)("EST_REV_COMM_PCT")
                End If
                Dim ContPct As Decimal = 0.0
                If IsDBNull(dtEst.Rows(0)("EST_REV_CONT_PCT")) = False Then
                    ContPct = dtEst.Rows(0)("EST_REV_CONT_PCT")
                End If
                Dim TaxCode As String = ""
                If IsDBNull(dtEst.Rows(0)("TAX_CODE")) = False Then
                    TaxCode = dtEst.Rows(0)("TAX_CODE")
                End If
                Dim TaxComm As String = ""
                If IsDBNull(dtEst.Rows(0)("TAX_COMM")) = False Then
                    TaxComm = dtEst.Rows(0)("TAX_COMM")
                End If
                Dim TaxCommOnly As String = ""
                If IsDBNull(dtEst.Rows(0)("TAX_COMM_ONLY")) = False Then
                    TaxCommOnly = dtEst.Rows(0)("TAX_COMM_ONLY")
                End If
                Dim TheFunctionType As String = ""
                If IsDBNull(dtEst.Rows(0)("EST_FNC_TYPE")) = False Then
                    TheFunctionType = dtEst.Rows(0)("EST_FNC_TYPE")
                End If

                SQL.Append("UPDATE [ESTIMATE_REV_DET] WITH(ROWLOCK) SET")
                ''SQL.Append(" EST_REV_QUANTITY = @EST_REV_QUANTITY,")
                ''parameterEST_REV_QUANTITY.Value = Qty

                SQL.Append(" EST_REV_RATE = @EST_REV_RATE,")
                parameterEST_REV_RATE.Value = Me.SelectedValue
                RowRate = Me.SelectedValue

                SQL.Append(" EST_REV_EXT_AMT = @EST_REV_EXT_AMT,")
                If CPM = "1" Then
                    ExtAmount = (CDec(Qty) / 1000) * RowRate
                Else
                    ExtAmount = CDec(Qty) * RowRate
                End If
                parameterEST_REV_EXT_AMT.Value = ExtAmount

                SQL.Append(" EST_REV_COMM_PCT = @EST_REV_COMM_PCT,")
                parameterEST_REV_COMM_PCT.Value = CDec(MarkupPct)

                SQL.Append(" EXT_MARKUP_AMT = @EXT_MARKUP_AMT,")
                If MarkupPct > 0 Then
                    MarkupAmount = ExtAmount * (CDec(MarkupPct) / 100)
                End If
                parameterEXT_MARKUP_AMT.Value = MarkupAmount

                If ContPct > 0 Then
                    RowContAmt = ExtAmount * (CDec(ContPct) / 100)
                    RowMuContAmt = (MarkupAmount * (CDec(ContPct) / 100))
                    LineTotalCont += RowContAmt + RowMuContAmt
                End If
                LineTotal += ExtAmount + MarkupAmount

                SQL.Append(" EST_REV_CONT_PCT = @EST_REV_CONT_PCT,")
                parameterEST_REV_CONT_PCT.Value = CDec(ContPct)
                SQL.Append(" EXT_CONTINGENCY = @EXT_CONTINGENCY,")
                parameterEXT_CONTINGENCY.Value = RowContAmt
                SQL.Append(" EXT_MU_CONT = @EXT_MU_CONT,")
                parameterEXT_MU_CONT.Value = RowMuContAmt
                SQL.Append(" TAX_CODE = @TAX_CODE")
                parameterTAX_CODE.Value = TaxCode

                If TaxCode <> "" Then
                    dt = est.GetAddNewTaxData(TaxCode)
                    If dt.Rows.Count > 0 Then
                        If dt.Rows(0)("TAX_RESALE") = 1 Then
                            If TaxCommOnly <> "1" Then
                                taxresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount > 0 Then
                                    taxmarkupstate = MarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxmarkupcounty = MarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxmarkupcity = MarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity

                            If RowContAmt > 0 Then
                                If TaxComm = "1" And TaxCommOnly = "1" Then
                                    RowContAmt = RowMuContAmt
                                ElseIf TaxComm = "1" Then
                                    RowContAmt += RowMuContAmt
                                End If
                                taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                parameterEXT_STATE_CONT.Value = taxcontstate
                                parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                parameterEXT_CITY_CONT.Value = taxcontcity
                                LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                            End If
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE, EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                        End If
                        If dt.Rows(0)("TAX_RESALE") <> 1 Then
                            If TheFunctionType = "V" Then
                                If TaxCommOnly <> "1" Then
                                    taxnonresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxnonresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxnonresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    Dim trstate As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    Dim trcounty As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    Dim trcity As Decimal = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(trstate, 2, MidpointRounding.AwayFromZero) + Math.Round(trcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(trcity, 2, MidpointRounding.AwayFromZero)

                                    parameterEXT_NONRESALE_TAX.Value = taxnonresalestate + taxnonresalecounty + taxnonresalecity
                                    SQL.Append(", EXT_NONRESALE_TAX = @EXT_NONRESALE_TAX")
                                End If
                                If RowContAmt > 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                    parameterEXT_NR_CONT.Value = taxcontstate + taxcontcounty + taxcontcity
                                    SQL.Append(", EXT_NR_CONT = @EXT_NR_CONT")
                                    LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            ElseIf TheFunctionType = "E" Or TheFunctionType = "I" Then
                                If TaxCommOnly <> "1" Then
                                    taxresalestate = ExtAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxresalecounty = ExtAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxresalecity = ExtAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxresalestate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxresalecity, 2, MidpointRounding.AwayFromZero)
                                End If
                                If RowContAmt > 0 Then
                                    If TaxComm = "1" And TaxCommOnly = "1" Then
                                        RowContAmt = RowMuContAmt
                                    ElseIf TaxComm = "1" Then
                                        RowContAmt += RowMuContAmt
                                    End If
                                    taxcontstate = RowContAmt * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxcontcounty = RowContAmt * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxcontcity = RowContAmt * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)

                                    parameterEXT_STATE_CONT.Value = taxcontstate
                                    parameterEXT_COUNTY_CONT.Value = taxcontcounty
                                    parameterEXT_CITY_CONT.Value = taxcontcity
                                    LineTotalCont += Math.Round(taxcontstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxcontcity, 2, MidpointRounding.AwayFromZero)
                                    SQL.Append(", EXT_STATE_CONT = @EXT_STATE_CONT, EXT_COUNTY_CONT = @EXT_COUNTY_CONT, EXT_CITY_CONT = @EXT_CITY_CONT")
                                End If
                            End If
                            If TaxComm = "1" Then
                                If MarkupAmount > 0 Then
                                    taxmarkupstate = MarkupAmount * ((CDec(dt.Rows(0)("TAX_STATE_PERCENT"))) / 100)
                                    taxmarkupcounty = MarkupAmount * ((CDec(dt.Rows(0)("TAX_COUNTY_PERCENT"))) / 100)
                                    taxmarkupcity = MarkupAmount * ((CDec(dt.Rows(0)("TAX_CITY_PERCENT"))) / 100)
                                    LineTotal += Math.Round(taxmarkupstate, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcounty, 2, MidpointRounding.AwayFromZero) + Math.Round(taxmarkupcity, 2, MidpointRounding.AwayFromZero)
                                End If
                            End If

                            parameterEXT_STATE_RESALE.Value = taxresalestate + taxmarkupstate
                            parameterEXT_COUNTY_RESALE.Value = taxresalecounty + taxmarkupcounty
                            parameterEXT_CITY_RESALE.Value = taxresalecity + taxmarkupcity
                            SQL.Append(", EXT_STATE_RESALE = @EXT_STATE_RESALE, EXT_COUNTY_RESALE = @EXT_COUNTY_RESALE, EXT_CITY_RESALE = @EXT_CITY_RESALE")
                        End If
                    End If
                End If
                SQL.Append(", LINE_TOTAL = @LINE_TOTAL")
                parameterLINE_TOTAL.Value = LineTotal
                SQL.Append(", LINE_TOTAL_CONT = @LINE_TOTAL_CONT")
                parameterLINE_TOTAL_CONT.Value = LineTotalCont
                With SQL
                    .Append(" WHERE ESTIMATE_NUMBER = @ESTIMATE_NUMBER AND EST_COMPONENT_NBR = @EST_COMPONENT_NBR AND EST_QUOTE_NBR = @EST_QUOTE_NBR AND EST_REV_NBR = @EST_REV_NBR AND SEQ_NBR = @SEQ_NBR;")
                End With

                Dim MyCmd As New SqlCommand()
                ''MyCmd.Parameters.Add(parameterEST_REV_QUANTITY)
                MyCmd.Parameters.Add(parameterEST_REV_RATE)
                MyCmd.Parameters.Add(parameterEST_REV_EXT_AMT)
                MyCmd.Parameters.Add(parameterEST_REV_COMM_PCT)
                MyCmd.Parameters.Add(parameterEST_REV_CONT_PCT)
                MyCmd.Parameters.Add(parameterEXT_MARKUP_AMT)
                MyCmd.Parameters.Add(parameterEXT_CONTINGENCY)
                MyCmd.Parameters.Add(parameterEXT_MU_CONT)
                MyCmd.Parameters.Add(parameterLINE_TOTAL)
                MyCmd.Parameters.Add(parameterLINE_TOTAL_CONT)
                MyCmd.Parameters.Add(parameterTAX_CODE)
                If TaxCode <> "" Then
                    MyCmd.Parameters.Add(parameterEXT_STATE_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_COUNTY_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_CITY_RESALE)
                    MyCmd.Parameters.Add(parameterEXT_STATE_CONT)
                    MyCmd.Parameters.Add(parameterEXT_COUNTY_CONT)
                    MyCmd.Parameters.Add(parameterEXT_CITY_CONT)
                    MyCmd.Parameters.Add(parameterEXT_NONRESALE_TAX)
                    MyCmd.Parameters.Add(parameterEXT_NR_CONT)
                End If

                Dim pESTIMATE_NUMBER As New SqlParameter("@ESTIMATE_NUMBER", SqlDbType.Int)
                pESTIMATE_NUMBER.Value = EstNumber
                MyCmd.Parameters.Add(pESTIMATE_NUMBER)

                Dim pEST_COMPONENT_NBR As New SqlParameter("@EST_COMPONENT_NBR", SqlDbType.SmallInt)
                pEST_COMPONENT_NBR.Value = EstComponentNbr
                MyCmd.Parameters.Add(pEST_COMPONENT_NBR)

                Dim pEST_QUOTE_NBR As New SqlParameter("@EST_QUOTE_NBR", SqlDbType.Int)
                pEST_QUOTE_NBR.Value = EstQuoteNbr
                MyCmd.Parameters.Add(pEST_QUOTE_NBR)

                Dim pEST_REV_NBR As New SqlParameter("@EST_REV_NBR", SqlDbType.SmallInt)
                pEST_REV_NBR.Value = EstRevNbr
                MyCmd.Parameters.Add(pEST_REV_NBR)

                Dim pSEQ_NBR As New SqlParameter("@SEQ_NBR", SqlDbType.SmallInt)
                pSEQ_NBR.Value = SeqNbr
                MyCmd.Parameters.Add(pSEQ_NBR)

                Using MyConn As New SqlConnection(HttpContext.Current.Session("ConnString"))
                    Dim MyTrans As SqlTransaction
                    MyConn.Open()
                    MyTrans = MyConn.BeginTransaction
                    Try
                        With MyCmd
                            .CommandText = SQL.ToString()
                            .CommandType = CommandType.Text
                            .Connection = MyConn
                            .Transaction = MyTrans
                            .ExecuteNonQuery()
                            'ReturnMessage = "OK|" & Qty
                        End With
                        MyTrans.Commit()
                    Catch ex As Exception
                        MyTrans.Rollback()
                    Finally
                        If MyConn.State = ConnectionState.Open Then MyConn.Close()
                    End Try
                End Using

            End If

            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function


#End Region








End Class
