Namespace FinanceAndAccounting

    Public Class Detail1099WithDisbursementReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Date As String = String.Empty
        Private _ReportCriteria As String = Nothing
        Private _AgencyName As String = Nothing
        Private _StartDate As Date = Nothing
        Private _EndDate As Date = Nothing

#End Region

#Region " Properties "

        Public Property Session As AdvantageFramework.Security.Session
            Get
                Session = _Session
            End Get
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property StartDate As Date
            Set(value As Date)
                _StartDate = value
            End Set
        End Property
        Public WriteOnly Property EndDate As Date
            Set(value As Date)
                _EndDate = value
            End Set
        End Property
        Public WriteOnly Property ReportCriteria As String
            Set(value As String)
                _ReportCriteria = value
            End Set
        End Property
        Public WriteOnly Property AgencyName As String
            Set(value As String)
                _AgencyName = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub Detail1099WithDisbursementReport_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub Detail1099WithDisbursementReport_DataSourceRowChanged(sender As Object, e As DevExpress.XtraReports.UI.DataSourceRowEventArgs) Handles Me.DataSourceRowChanged

            'objects
            Dim VendorPayToCode As String = Nothing
            Dim IRS1099DetailDisbursementReportList As Generic.List(Of AdvantageFramework.AccountPayable.Classes.IRS1099DetailDisbursementReport) = Nothing

            VendorPayToCode = DirectCast(Me.GetCurrentRow, AdvantageFramework.AccountPayable.Classes.IRS1099Processing).VendorCode

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				IRS1099DetailDisbursementReportList = DbContext.Database.SqlQuery(Of AdvantageFramework.AccountPayable.Classes.IRS1099DetailDisbursementReport) _
						(String.Format("exec advsp_ap_disbursed_amounts_by_glaccount '{0}','{1}','{2}'", VendorPayToCode, _StartDate.ToString("MM/dd/yyyy"), _EndDate.ToString("MM/dd/yyyy"))).ToList

			End Using
            
            SubreportDetail_1099Disbursement.ReportSource.DataSource = IRS1099DetailDisbursementReportList

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub PageHeader_BeforePrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PageHeader.BeforePrint

            LabelPageHeader_ReportCriteria.Text = "For Check Date(s) From: " & _ReportCriteria
            LabelPageHeader_Agency.Text = _AgencyName

        End Sub

#End Region

#End Region

    End Class

End Namespace
