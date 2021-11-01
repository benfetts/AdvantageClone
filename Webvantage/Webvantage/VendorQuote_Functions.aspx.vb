Imports Webvantage.cGlobals

Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Public Class VendorQuote_Functions
    Inherits Webvantage.BaseChildPage
    Private EstimateNum As Integer = 0
    Private EstimateComp As Integer = 0
    Private VendorQuoteNbr As Integer = 0
    Private EstimateQuote As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'Me.RadGridQuotes.Skin = MiscFN.SetRadGridSkin()
        Try
            EstimateNum = CType(Request.QueryString("EstNum"), Integer)
        Catch ex As Exception
            EstimateNum = 0
        End Try
        Try
            EstimateComp = CType(Request.QueryString("EstComp"), Integer)
        Catch ex As Exception
            EstimateComp = 0
        End Try
        Try
            VendorQuoteNbr = CType(Request.QueryString("reqNum"), Integer)
        Catch ex As Exception
            VendorQuoteNbr = 0
        End Try
        Try
            EstimateQuote = CType(Request.QueryString("EstQuote"), Integer)
        Catch ex As Exception
            EstimateQuote = 0
        End Try
        Try
            RevNum = CType(Request.QueryString("RevNum"), Integer)
        Catch ex As Exception
            RevNum = 0
        End Try
        If Not Me.IsPostBack Then
            'LoadQuoteData()
        Else

        End If
        Me.LoadLookups()
    End Sub

    Private Sub LoadLookups()
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

    Private Sub RadGridFunc_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridFunc.NeedDataSource
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim od As New cDropDowns(Session("ConnString"))

            Me.RadGridFunc.DataSource = est.GetFunctionsVendor(Me.EstimateNum, Me.EstimateComp, Me.VendorQuoteNbr, Me.cbDefault.Checked, Session("UserCode"))
        Catch ex As Exception

        End Try
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
    '            ' Me.TxtEstimate.Text = JobNum
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
    '            'If IsDBNull(dr("EST_QUOTE_NBR")) = False Then
    '            '    Me.TxtQuote.Text = dr("EST_QUOTE_NBR")
    '            'End If
    '            'If IsDBNull(dr("EST_QUOTE_DESC")) = False Then
    '            '    Me.TxtQuoteDescription.Text = dr("EST_QUOTE_DESC")
    '            'End If
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
    '    Me.RadGridQuotes.Rebind()
    'End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        'Me.lblMSG.Text = TheMSG
    End Sub

    Private Sub BtnCopy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnCopy.Click
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim dt As DataTable
        Dim ds As DataSet
        Dim dsQuotes As DataSet
        Dim dsVendors As DataSet
        Dim dsReq As DataSet
        Dim functioncode As String
        Dim createdby As String
        Dim createddate As DateTime
        Dim qty As Integer = 0
        Dim vendorcode As String

        dsReq = est.GetRequestData(EstimateNum, EstimateComp, VendorQuoteNbr, Session("UserCode"))
        If dsReq.Tables(0).Rows.Count > 0 Then
            For j As Integer = 0 To dsReq.Tables(0).Rows.Count - 1
                If IsDBNull(dsReq.Tables(0).Rows(j)("CREATED_BY")) = False Then
                    createdby = dsReq.Tables(0).Rows(j)("CREATED_BY")
                End If
                If IsDBNull(dsReq.Tables(0).Rows(j)("CREATE_DATE")) = False Then
                    createddate = dsReq.Tables(0).Rows(j)("CREATE_DATE")
                End If
            Next
        End If
        Dim chk As CheckBox
        For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridFunc.MasterTableView.Items
            chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
            If chk.Checked = True Then
                'Set variables:
                functioncode = gridDataItem("colFNC_CODE").Text.Replace("&nbsp;", "")
                'Save:
                Try
                    Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                    oEstimating.AddNewRequestFunction(EstimateNum, EstimateComp, VendorQuoteNbr, functioncode, "")
                    ds = oEstimating.GetRequestVendors(EstimateNum, EstimateComp, VendorQuoteNbr, Session("UserCode"))
                    If ds.Tables(0).Rows.Count > 0 Then
                        dsQuotes = oEstimating.GetRequestQuotes(EstimateNum, EstimateComp, VendorQuoteNbr, 0, Session("UserCode"))
                        dsVendors = oEstimating.GetRequestVendors(EstimateNum, EstimateComp, VendorQuoteNbr, Session("UserCode"))
                        For x As Integer = 0 To dsQuotes.Tables(0).Rows.Count - 1
                            If IsDBNull(dsQuotes.Tables(0).Rows(x)("EST_QUOTE_NBR")) = False Then
                                QuoteNum = dsQuotes.Tables(0).Rows(x)("EST_QUOTE_NBR")
                            End If
                            If IsDBNull(dsQuotes.Tables(0).Rows(x)("EST_REV_NBR")) = False Then
                                RevNum = dsQuotes.Tables(0).Rows(x)("EST_REV_NBR")
                            End If
                            For i As Integer = 0 To dsVendors.Tables(0).Rows.Count - 1
                                If IsDBNull(dsVendors.Tables(0).Rows(i)("VN_CODE")) = False Then
                                    vendorcode = dsVendors.Tables(0).Rows(i)("VN_CODE")
                                End If
                                oEstimating.AddNewRequestDetail(EstimateNum, EstimateComp, VendorQuoteNbr, QuoteNum, RevNum, functioncode, vendorcode, createdby, createddate, 0, 0, "", 0, "", "", "", qty)
                            Next
                        Next
                    End If
                Catch ex As Exception
                End Try
            End If
        Next
        CloseAndRefresh()

    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("VendorQuote.aspx?tab=1&PageMode=edit&EstNum=" & EstimateNum & "&EstComp=" & EstimateComp & "&vendorreq=" & VendorQuoteNbr, True)
    End Sub


    Private Sub cbDefault_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDefault.CheckedChanged
        Try
            Me.RadGridFunc.Rebind()
        Catch ex As Exception

        End Try
    End Sub
End Class