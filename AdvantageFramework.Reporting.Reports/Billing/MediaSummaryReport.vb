Namespace Billing

    Public Class MediaSummaryReport
        Implements AdvantageFramework.Reporting.Reports.IUserDefinedReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportID As Integer = 0

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
                AdvancedReportWriterReport = AdvantageFramework.Reporting.AdvancedReportWriterReports.BillingWorksheetMedia
            End Get
        End Property
        Public ReadOnly Property BindingSourceControl As System.Windows.Forms.BindingSource Implements IUserDefinedReport.BindingSourceControl
            Get
                BindingSourceControl = BindingSource
            End Get
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

        Private Sub LabelPageHeader_BroadcastFrom_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_BroadcastFrom.BeforePrint

            If Year(Parameters("brdcast_date1").Value) = 1 Then

                e.Cancel = True

            End If

        End Sub
		Private Sub LabelPageHeader_BroadcastTo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelPageHeader_BroadcastTo.BeforePrint

			If Year(Parameters("brdcast_date2").Value) = 1 Then

				e.Cancel = True

			End If

		End Sub
        Private Sub label13_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles label13.BeforePrint

            'objects
            Dim InsertDate As Date = Date.MinValue

            If String.IsNullOrWhiteSpace(label13.Text) = False AndAlso Not label13.Text.Contains(" ") Then

                Try

                    InsertDate = Date.Parse(label13.Text, New Globalization.CultureInfo("en-us", False))

                Catch ex As Exception
                    InsertDate = Date.MinValue
                End Try

                If InsertDate <> Date.MinValue Then

                    label13.Text = InsertDate.ToShortDateString

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
