Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Namespace Employee.DirectTime

    Public Class EmployeeDirectTimeReport
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Grouping As String = ""
        Private _PDFPageBreak As Boolean = False
        Private _CultureCode As String = "en-US"

#End Region

#Region " Properties "

        Public Property UserDefinedReportID As Integer Implements IUserDefinedReport.UserDefinedReportID
            Get
                UserDefinedReportID = _UserDefinedReportID
            End Get
            Set(value As Integer)
                _UserDefinedReportID = value
            End Set
        End Property
        Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports Implements IUserDefinedReport.AdvancedReportWriterReport
            Get
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV1Summary
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property
        Public WriteOnly Property Grouping As String
            Set(value As String)
                _Grouping = value
            End Set
        End Property
        Public Property PDFPageBreak As Boolean
            Get
                PDFPageBreak = _PDFPageBreak
            End Get
            Set(value As Boolean)
                _PDFPageBreak = value
            End Set
        End Property
        Public WriteOnly Property CultureCode As String
            Set(value As String)
                _CultureCode = value
            End Set
        End Property

        Private Sub EmployeeDirectTimeReport_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
            Try
                If PDFPageBreak = True Then
                    Me.GroupFooter3.PageBreak = DevExpress.XtraReports.UI.PageBreak.AfterBand
                End If
            Catch ex As Exception

            End Try
        End Sub
        Public Sub SetCulture(ByVal [Report] As AdvantageFramework.Reporting.Reports.Estimating.EstimateReport, Optional ByVal CultureCode As String = "en-US")
            Try
                Dim ci As New System.Globalization.CultureInfo(CultureCode)
                Threading.Thread.CurrentThread.CurrentCulture = ci
            Catch ex As Exception
            End Try
        End Sub

#End Region


    End Class

End Namespace






