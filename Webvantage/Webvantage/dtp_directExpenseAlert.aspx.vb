Imports System.Data.SqlClient

Partial Public Class dtp_directExpenseAlert
    Inherits Webvantage.BaseChildPage

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True

    End Sub

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        LoadHeader()
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Dim oDO As cDesktopObjects = New cDesktopObjects(CStr(Session("ConnString")))
        Dim startPP, endPP, Office As String
        Dim amount As String
        Dim amount_dec As Decimal

        Dim oSQL As SqlHelper
        Dim SQL_STRING As String
        Dim dr As SqlDataReader

        SQL_STRING = "SELECT CAST(AGY_SETTINGS_VALUE AS DECIMAL(15,2)) FROM AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'DIRECT_EXP_ALERT_AMT'"

        Try
            dr = oSQL.ExecuteReader(CStr(Session("ConnString")), CommandType.Text, SQL_STRING)
        Catch
            Err.Raise(Err.Number, "Class:dt_directExpenseAlert Routine:LoadGrid", Err.Description)
        Finally

        End Try

        If dr.HasRows Then
            Do While dr.Read
                amount_dec = dr.GetDecimal(0)
            Loop
        End If

        startPP = Session("PPBEGIN_DEA")
        endPP = Session("PPEND_DEA")
        Office = Session("OFFICE_DEA")
        amount = CStr(Session("Amount"))

        If Office = "All" Then
            Office = ""
        End If
        If Request.QueryString("from") = "mydexp" Then
            Me.RadGrid1.DataSource = oDO.GetDirectExpense(startPP, endPP, Office, amount, Session("UserCode"), "mydexp")
        Else
            Me.RadGrid1.DataSource = oDO.GetDirectExpense(startPP, endPP, Office, amount, Session("UserCode"), "")
        End If

        Me.RadGrid1.DataBind()

    End Sub

    Private Sub LoadHeader()
        Dim startPP, endPP, Office As String
        Dim header_str As String

        startPP = Session("PPBEGIN_DEA")
        endPP = Session("PPEND_DEA")
        Office = Session("OFFICE_DEA")


        If Office = "All" Then
            Office = ""
        End If
        If Request.QueryString("from") = "mydexp" Then
            header_str = "My Direct Expense Alert &nbsp;&nbsp;&nbsp;&nbsp; Period Range: " & startPP & " to " & endPP
        Else
            header_str = "Direct Expense Alert &nbsp;&nbsp;&nbsp;&nbsp; Period Range: " & startPP & " to " & endPP
        End If
        Me.Label1.Text = header_str

        If Office <> "" Then
            header_str = "Office: " & Office
        Else
            header_str = "Office: All"
        End If

        Me.lblType.Text = header_str

    End Sub

End Class