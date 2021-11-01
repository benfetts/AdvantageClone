Public Class Reporting_Estimate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportID As Integer = 0
    Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub LoadUserDefinedReportInformation()

        Try

            If Request.QueryString("UserDefinedReportID") IsNot Nothing Then

                _UserDefinedReportID = CType(Request.QueryString("UserDefinedReportID"), Integer)

            End If

        Catch ex As Exception
            _UserDefinedReportID = 0
        End Try

        Try

            If Request.QueryString("AdvancedReportWriterReport") IsNot Nothing Then

                _AdvancedReportWriterReport = CType(Request.QueryString("AdvancedReportWriterReport"), Integer)

            End If

        Catch ex As Exception
            _AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.EstimateForm
        End Try

    End Sub
    

#Region "  Form Event Handlers "

    Private Sub Reporting_JobDetailAnalysis_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        LoadUserDefinedReportInformation()

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_Reports_JobDetailAnalysisRTP)

            If _UserDefinedReportID > 0 Then

                RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday
                RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub RadGridEstimates_ItemCommand(sender As Object, e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimates.ItemCommand
        Try
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
            Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
            Try

                If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

                    CurrentGridDataItem = RadGridEstimates.Items(e.Item.ItemIndex)

                End If

            Catch ex As Exception
                CurrentGridDataItem = Nothing
            End Try

            If CurrentGridDataItem IsNot Nothing Then

                Select Case e.CommandName

                    Case "ViewReport"

                        Session("Estimate_SelectedEstimateNumber") = Nothing
                        Session("Estimate_SelectedEstimateComponentNumber") = Nothing
                        Session("Estimate_SelectedEstimateQuote") = Nothing
                        Session("Estimate_SelectedUserCode") = Nothing

                        Report = AdvantageFramework.Reporting.ReportTypes.UserDefined

                        'EstimateQuote = CType(CurrentGridDataItem, AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)

                        Session("Estimate_SelectedEstimateNumber") = CurrentGridDataItem.GetDataKeyValue("EstimateNumber")
                        Session("Estimate_SelectedEstimateComponentNumber") = CurrentGridDataItem.GetDataKeyValue("EstimateComponentNumber")
                        Session("Estimate_SelectedEstimateQuote") = CurrentGridDataItem.GetDataKeyValue("QuoteNumber").ToString & ","
                        Session("Estimate_SelectedUserCode") = Session("UserCode")
                        Session("UserDefinedReportID") = _UserDefinedReportID

                        MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & "")

                End Select

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub RadGridEstimates_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimates.NeedDataSource
        Try
            Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

                EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_load] '{0}', '{1}', '{2}'", Session("UserCode"), RadDatePickerFrom.SelectedDate, RadDatePickerTo.SelectedDate)).ToList

                RadGridEstimates.DataSource = EstimateQuotes

            End Using
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub RadToolBarJobDetailAnalysis_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarJobDetailAnalysis.ButtonClick

    '    'objects
    '    Dim Report As AdvantageFramework.Reporting.ReportTypes = Nothing
    '    Dim CDPString As String

    '    Dim clients As New System.Collections.Generic.List(Of String)
    '    Dim divisions As New System.Collections.Generic.List(Of String)
    '    Dim products As New System.Collections.Generic.List(Of String)

    '    Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing

    '    Select Case e.Item.Value

    '        Case "View"

    '            Session("Estimate_SelectedEstimateNumber") = Nothing
    '            Session("Estimate_SelectedEstimateComponentNumber") = Nothing
    '            Session("Estimate_SelectedEstimateQuote") = Nothing
    '            Session("Estimate_SelectedUserCode") = Nothing

    '            Report = AdvantageFramework.Reporting.ReportTypes.UserDefined

    '            EstimateQuote = Me.RadGridEstimates.SelectedValue

    '            Session("Estimate_SelectedEstimateNumber") = EstimateQuote.EstimateNumber
    '            Session("Estimate_SelectedEstimateComponentNumber") = EstimateQuote.EstimateComponentNumber
    '            Session("Estimate_SelectedEstimateQuote") = EstimateQuote.QuoteNumber.ToString & ","
    '            Session("Estimate_SelectedUserCode") = Session("UserID")

    '            MiscFN.ResponseRedirect("Reporting_ViewReport.aspx?Report=" & AdvantageFramework.EnumUtilities.GetValue(GetType(AdvantageFramework.Reporting.ReportTypes), Report) & "")

    '    End Select

    'End Sub

    Private Sub RadButton1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton1Year.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-1)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
        Me.RadGridEstimates.Rebind()

    End Sub
    Private Sub RadButton2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButton2Years.Click

        RadDatePickerFrom.SelectedDate = cEmployee.TimeZoneToday.AddYears(-2)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
        Me.RadGridEstimates.Rebind()

    End Sub
    Private Sub RadButtonMTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonMTD.Click

        RadDatePickerFrom.SelectedDate = CDate(cEmployee.TimeZoneToday.Month & "/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
        Me.RadGridEstimates.Rebind()

    End Sub
    Private Sub RadButtonYTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadButtonYTD.Click

        RadDatePickerFrom.SelectedDate = CDate("1/1/" & cEmployee.TimeZoneToday.Year)
        RadDatePickerTo.SelectedDate = cEmployee.TimeZoneToday
        Me.RadGridEstimates.Rebind()

    End Sub
    Private Sub RadDatePickerFrom_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerFrom.SelectedDateChanged

        RadDatePickerTo.MinDate = RadDatePickerFrom.SelectedDate
        Me.RadGridEstimates.Rebind()

    End Sub
    Private Sub RadDatePickerTo_SelectedDateChanged(ByVal sender As Object, ByVal e As Telerik.Web.UI.Calendar.SelectedDateChangedEventArgs) Handles RadDatePickerTo.SelectedDateChanged

        RadDatePickerFrom.MaxDate = RadDatePickerTo.SelectedDate
        Me.RadGridEstimates.Rebind()

    End Sub

#End Region

#End Region

    
End Class

