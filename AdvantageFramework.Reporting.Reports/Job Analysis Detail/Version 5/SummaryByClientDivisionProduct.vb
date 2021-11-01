Imports System.Drawing.Printing

Namespace JobAnalysisDetail.Version5

    Public Class SummaryByClientDivisionProduct
        Inherits DevExpress.XtraReports.UI.XtraReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0
        Private _Grouping As String = ""

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.JobDetailAnalysisV5CliDivPrd
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

        Private Sub SummaryByClientDivisionProduct_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
            If _Grouping <> "AccountExecutive" Then

                Me.GroupHeader2.GroupFields.Clear()
                Me.GroupHeader2.Visible = False
                Me.GroupFooter2.Visible = False

            Else

                Me.LabelPageHeader_SortBy.Text = "Sorted by Account Executive "

            End If
        End Sub

#End Region


    End Class

End Namespace







