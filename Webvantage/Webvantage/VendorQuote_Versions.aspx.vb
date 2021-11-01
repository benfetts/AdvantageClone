Imports Webvantage.cGlobals

Imports System.Data.Sql
Imports System.Data.SqlClient
Partial Public Class VendorQuote_Versions
    Inherits Webvantage.BaseChildPage

    Private EstimateNum As Integer = 0
    Private EstimateComp As Integer = 0
    Private VendorQuoteNbr As Integer = 0
    Private EstNum As Integer = 0
    Private EstComp As Integer = 0
    Private QuoteNum As Integer = 0
    Private RevNum As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        ' Me.RadGridQuotes.Skin = MiscFN.SetRadGridSkin()
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
        'Try
        '    RevNum = CType(Request.QueryString("RevNum"), Integer)
        'Catch ex As Exception
        '    RevNum = 0
        'End Try
        If Not Me.IsPostBack Then
            LoadQuoteData()
        End If
        Me.LoadLookups()
    End Sub

    Private Sub LoadLookups()
    End Sub

    Private Sub LoadQuoteData()
        Try
            Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
            Dim dt As DataTable
            dt = est.GetEstimateData(EstimateNum, EstimateComp, 0, 0, Session("UserCode"))
            If dt.Rows.Count > 0 Then
                For i As Integer = 0 To dt.Rows.Count - 1
                    If IsDBNull(dt.Rows(0)("ESTIMATE_NUMBER")) = False Then
                        Me.TxtEstimate.Text = dt.Rows(0)("ESTIMATE_NUMBER")
                    Else
                        Me.TxtEstimate.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("EST_LOG_DESC")) = False Then
                        Me.TxtEstimateDescription.Text = dt.Rows(0)("EST_LOG_DESC")
                    Else
                        Me.TxtEstimateDescription.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("EST_COMPONENT_NBR")) = False Then
                        Me.TxtEstimateComponent.Text = dt.Rows(0)("EST_COMPONENT_NBR")
                    Else
                        Me.TxtEstimateComponent.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("EST_COMP_DESC")) = False Then
                        Me.TxtEstimateComponentDescription.Text = dt.Rows(0)("EST_COMP_DESC")
                    Else
                        Me.TxtEstimateComponentDescription.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("CL_CODE")) = False Then
                        Me.TxtClientCode.Text = dt.Rows(0)("CL_CODE")
                    Else
                        Me.TxtClientCode.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("CL_NAME")) = False Then
                        Me.TxtClientDescription.Text = dt.Rows(0)("CL_NAME")
                    Else
                        Me.TxtClientDescription.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_CODE")) = False Then
                        Me.TxtDivisionCode.Text = dt.Rows(0)("DIV_CODE")
                    Else
                        Me.TxtDivisionCode.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("DIV_NAME")) = False Then
                        Me.TxtDivisionDescription.Text = dt.Rows(0)("DIV_NAME")
                    Else
                        Me.TxtDivisionDescription.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_CODE")) = False Then
                        Me.TxtProductCode.Text = dt.Rows(0)("PRD_CODE")
                    Else
                        Me.TxtProductCode.Text = ""
                    End If
                    If IsDBNull(dt.Rows(0)("PRD_DESCRIPTION")) = False Then
                        Me.TxtProductDescription.Text = dt.Rows(0)("PRD_DESCRIPTION")
                    Else
                        Me.TxtProductDescription.Text = ""
                    End If
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub QuickMSG(ByVal TheMSG As String)
        Me.lblMSG.Text = TheMSG
    End Sub

    Private Sub CloseAndRefresh()
        Me.CloseThisWindowAndRefreshCaller("VendorQuote.aspx?tab=1&PageMode=edit&EstNum=" & EstimateNum & "&EstComp=" & EstimateComp & "&vendorreq=" & VendorQuoteNbr, True)
    End Sub

    Private Sub RadGridQuote_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridQuote.ItemDataBound
        Try
            If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item Or e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = e.Item
                Dim str As String = CurrentGridRow("colEST_QUOTE_DESC").Text

                If str = "&nbsp;" Then
                    CurrentGridRow("colEST_QUOTE_DESC").Text = "Quote " & CurrentGridRow.GetDataKeyValue("EST_QUOTE_NBR").ToString
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridQuote_NeedDataSource(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridQuote.NeedDataSource
        Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
        Dim max As Integer
        If Me.TxtEstimate.Text <> "" And Me.TxtEstimateComponent.Text <> "" Then
            If IsNumeric(Me.TxtEstimate.Text) = True And IsNumeric(Me.TxtEstimateComponent.Text) = True Then
                'max = est.GetEstimateQuoteMaxRevision(Me.TxtEstimate.Text, Me.TxtEstimateComponent.Text, Me.TxtQuote.Text)
                Me.RadGridQuote.DataSource = est.GetEstimateQuotes(CInt(Me.TxtEstimate.Text), CInt(Me.TxtEstimateComponent.Text))
            End If
        End If
    End Sub

    Private Sub RadToolBarQuote_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarQuote.ButtonClick
        Try
            Select Case e.Item.Value
                Case "Add"

                    Dim est As New cEstimating(Session("ConnString"), Session("UserCode"))
                    Dim dt As DataTable
                    Dim ds As DataSet
                    Dim dsFunctions As DataSet
                    Dim dsVendors As DataSet
                    Dim dsReq As DataSet
                    Dim functioncode As String
                    Dim createdby As String
                    Dim createddate As DateTime
                    Dim qty As Integer = 0
                    Dim vendorcode As String

                    Dim estquote As Integer
                    Dim estrev As Integer

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
                    For Each gridDataItem As Telerik.Web.UI.GridDataItem In Me.RadGridQuote.MasterTableView.Items
                        chk = CType(gridDataItem("ColumnClientSelect").Controls(0), CheckBox)
                        If chk.Checked = True Then
                            'Set variables:
                            estquote = gridDataItem.GetDataKeyValue("EST_QUOTE_NBR")
                            estrev = gridDataItem.GetDataKeyValue("EST_REV_NBR")

                            'Save:
                            Try
                                Dim oEstimating As cEstimating = New cEstimating(Session("ConnString"), CStr(Session("UserCode")))
                                oEstimating.AddNewRequestQuote(EstimateNum, EstimateComp, VendorQuoteNbr, estquote, estrev, "")
                                ds = oEstimating.GetRequestVendorReplies(EstimateNum, EstimateComp, VendorQuoteNbr, Session("UserCode"))
                                If ds.Tables(0).Rows.Count > 0 Then
                                    dsFunctions = oEstimating.GetRequestQuotes(EstimateNum, EstimateComp, VendorQuoteNbr, 0, Session("UserCode"))
                                    dsVendors = oEstimating.GetRequestVendors(EstimateNum, EstimateComp, VendorQuoteNbr, Session("UserCode"))
                                    For x As Integer = 0 To dsFunctions.Tables(1).Rows.Count - 1
                                        If IsDBNull(dsFunctions.Tables(1).Rows(x)("EST_FNC_CODE")) = False Then
                                            functioncode = dsFunctions.Tables(1).Rows(x)("EST_FNC_CODE")
                                        End If
                                        For i As Integer = 0 To dsVendors.Tables(0).Rows.Count - 1
                                            If IsDBNull(dsVendors.Tables(0).Rows(i)("VN_CODE")) = False Then
                                                vendorcode = dsVendors.Tables(0).Rows(i)("VN_CODE")
                                            End If
                                            oEstimating.AddNewRequestDetail(EstimateNum, EstimateComp, VendorQuoteNbr, estquote, estrev, functioncode, vendorcode, createdby, createddate, 0, 0, "", 0, "", "", "", qty)
                                        Next
                                    Next
                                End If
                            Catch ex As Exception
                            End Try
                        End If
                    Next
                    CloseAndRefresh()

            End Select
        Catch ex As Exception

        End Try
    End Sub
End Class