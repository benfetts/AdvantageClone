Public Class Expense_Print
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _InvoiceNumber As Integer = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub PrintExpenseReport()

        'objects
        Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
        Dim ParameterDictionary As System.Collections.Generic.Dictionary(Of String, Object) = Nothing
        Dim DataSource As Object = Nothing
        Dim URL As String = Nothing

        If _InvoiceNumber > 0 Then

            ParameterDictionary = New System.Collections.Generic.Dictionary(Of String, Object)

            ParameterDictionary.Add("InvoiceNumbers", {_InvoiceNumber})
            ParameterDictionary.Add("PrintApproverName", CheckBoxPrintSupervisorName.Checked)
            ParameterDictionary.Add("ExcludeEmployeeSignature", CheckBoxExcludeEmployeeSignature.Checked)
            ParameterDictionary.Add("IncludeReceipts", CheckBoxIncludeReceipts.Checked)
            ParameterDictionary.Add("IncludeReport", True)

            Session("Report_ParameterDictionary") = ParameterDictionary

            Report = AdvantageFramework.Reporting.ReportTypes.EmployeeExpenseReport

            URL = "Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & ""

            CloseThisWindowAndOpenNewWindow(URL)

        End If

    End Sub

#Region "  Form Event Handlers "

    Private Sub Page_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Request.QueryString("InvoiceNumber") IsNot Nothing Then

                _InvoiceNumber = CInt(Request.QueryString("InvoiceNumber"))

            End If

        Catch ex As Exception
            _InvoiceNumber = 0
        End Try

    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim ExpenseReport As AdvantageFramework.Database.Entities.ExpenseReport = Nothing

        Me.Title = "Expense Report"

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Employee_ExpenseReports)

            If _InvoiceNumber > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    ExpenseReport = AdvantageFramework.Database.Procedures.ExpenseReport.LoadByInvoiceNumber(DbContext, _InvoiceNumber)

                End Using

            End If

            If ExpenseReport Is Nothing Then

                Me.ShowMessage("Error printing expense report!")
                Me.CloseThisWindow()

            End If

        End If

    End Sub

#End Region

#Region " Control Event Handlers "

    Private Sub RadToolbarOptions_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarOptions.ButtonClick

        If TypeOf e.Item Is Telerik.Web.UI.RadToolBarButton Then

            Select Case DirectCast(e.Item, Telerik.Web.UI.RadToolBarButton).CommandName

                Case RadToolBarButtonPrint.CommandName

                    PrintExpenseReport()

            End Select

        End If

    End Sub

#End Region

#End Region

End Class
