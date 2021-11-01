Imports System.Data.SqlClient
Public Class dtp_billing_trends
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Page.IsPostBack = False Then
            Try
                If Not Session("ConnString") Is Nothing Then
                    If Session("ConnString") <> "" Then
                        LoadData()
                        Dim strType As String = String.Empty

                        'catch "%,P,[^P]"
                        Select Case Request.QueryString("rectype")
                            Case "%"
                                strType = "&nbsp;&nbsp;Type: All"
                            Case "P"
                                strType = "&nbsp;&nbsp;Type: Production;"
                            Case "[^P]"
                                strType = "&nbsp;&nbsp;Type: Media"
                        End Select
                        Me.lblTitle.Text = "Billing Trends" ': " & Request.QueryString("client")
                        If Request.QueryString("office") = "%" Then
                            Me.lblType.Text = "All Offices"
                        Else
                            Me.lblType.Text = "Office: " & Request.QueryString("office")
                        End If
                        If Request.QueryString("client") = "%" Then
                            Me.lblType.Text = Me.lblType.Text & "/Clients"
                        Else
                            Me.lblType.Text = Me.lblType.Text & "&nbsp;&nbsp;Client: " & Request.QueryString("client")
                        End If
                        If Request.QueryString("division") = "%" Then
                            Me.lblType.Text = Me.lblType.Text & "/Division"
                        Else
                            Me.lblType.Text = Me.lblType.Text & "&nbsp;&nbsp;Division: " & Request.QueryString("division")
                        End If
                        If Request.QueryString("product") = "%" Then
                            Me.lblType.Text = Me.lblType.Text & "/Products"
                        Else
                            Me.lblType.Text = Me.lblType.Text & "&nbsp;&nbsp;Product: " & Request.QueryString("product")
                        End If
                        If Request.QueryString("sales") = "%" Then
                            Me.lblType.Text = Me.lblType.Text & "/Sales Classes, " & strType
                        Else
                            Me.lblType.Text = Me.lblType.Text & "&nbsp;&nbsp;Sales Class: " & Request.QueryString("sales") & ", " & strType
                        End If
                        Me.lblDate.Text = Now.ToShortDateString
                    End If
                End If
            Catch ex As Exception
                Throw (ex)
            End Try
        End If
    End Sub
    Dim strClient1 As String
    Private Sub LoadData()
        Session("dsBillingTrends") = ""
        Session("dsBillingTrends") = Nothing
        Dim dr As SqlDataReader
        Dim oDesktop As cDesktopObjects = New cDesktopObjects(Session("ConnString"))
        If Request.QueryString("client") = "ALL" Then
            strClient1 = "%"
        Else
            strClient1 = Request.QueryString("client")
        End If

        dr = oDesktop.GetBillingTrends(Request.QueryString("client"), Request.QueryString("rectype"), Request.QueryString("sales"), Session("UserCode"), Request.QueryString("office"), Request.QueryString("division"), Request.QueryString("product"), Request.QueryString("year1"), Request.QueryString("year2"))

        Dim ds As DataSet = New DataSet
        Dim ThisTable As DataTable = New DataTable("BillingTrends")

        ThisTable.Columns.Add("Year", System.Type.GetType("System.String"))
        ThisTable.Columns.Add("Jan", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Feb", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Mar", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Apr", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("May", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Jun", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Jul", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Aug", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Sep", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Oct", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Nov", System.Type.GetType("System.Decimal"))
        ThisTable.Columns.Add("Dec", System.Type.GetType("System.Decimal"))

        Dim ThisRow As DataRow
        Dim FirstYear As String = ""
        Dim ThisYear As String = ""
        Dim ThisMonth As Integer = 0
        Dim ThisValue As Decimal
        Dim RowIndex As Integer = -1
        Do While dr.Read
            ThisYear = dr.GetString(2).ToString
            If ThisYear <> FirstYear Then
                If FirstYear <> "" Then
                    ThisTable.Rows.Add(ThisRow)
                End If
                FirstYear = ThisYear
                ThisRow = ThisTable.NewRow
                ThisRow("Year") = ThisYear.ToString
                ThisRow("Jan") = 0.0
                ThisRow("Feb") = 0.0
                ThisRow("Mar") = 0.0
                ThisRow("Apr") = 0.0
                ThisRow("May") = 0.0
                ThisRow("Jun") = 0.0
                ThisRow("Jul") = 0.0
                ThisRow("Aug") = 0.0
                ThisRow("Sep") = 0.0
                ThisRow("Oct") = 0.0
                ThisRow("Nov") = 0.0
                ThisRow("Dec") = 0.0
            End If
            ThisMonth = dr.GetSqlInt16(1).Value
            ThisValue = CDec(dr.GetSqlDecimal(0).Value)
            Select Case ThisMonth
                Case 1
                    ThisRow("Jan") += ThisValue
                Case 2
                    ThisRow("Feb") += ThisValue
                Case 3
                    ThisRow("Mar") += ThisValue
                Case 4
                    ThisRow("Apr") += ThisValue
                Case 5
                    ThisRow("May") += ThisValue
                Case 6
                    ThisRow("Jun") += ThisValue
                Case 7
                    ThisRow("Jul") += ThisValue
                Case 8
                    ThisRow("Aug") += ThisValue
                Case 9
                    ThisRow("Sep") += ThisValue
                Case 10
                    ThisRow("Oct") += ThisValue
                Case 11
                    ThisRow("Nov") += ThisValue
                Case 12
                    ThisRow("Dec") += ThisValue
            End Select
        Loop

        If Not ThisRow Is Nothing Then
            ThisTable.Rows.Add(ThisRow)
            ThisTable.AcceptChanges()
        End If


        If ThisTable.Rows.Count > 0 Then
            ds.Tables.Add(ThisTable)
            Session("dsBillingTrends") = ds
        End If
        dr.Close()

        CreateChart()

    End Sub

    Private Sub CreateChart()

        cCharting.GetLineChart_BillingTrends(RadHtmlChartBillingTrends, Session("dsBillingTrends"))

    End Sub

End Class