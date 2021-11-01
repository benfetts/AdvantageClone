Public Class XtraReportUDR
    Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _UserDefinedReportID As Integer = 0

#End Region

#Region " Properties "

    Public ReadOnly Property AdvancedReportWriterReport As AdvantageFramework.Reporting.Methods.AdvancedReportWriterReports Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport.AdvancedReportWriterReport
        Get
            AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.Custom
        End Get
    End Property
    Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport.BindingSourceControl
        Get
            BindingSourceControl = Nothing
        End Get
    End Property
    Public Property UserDefinedReportID As Integer Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport.UserDefinedReportID
        Get
            UserDefinedReportID = _UserDefinedReportID
        End Get
        Set(ByVal value As Integer)
            _UserDefinedReportID = value
        End Set
    End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class