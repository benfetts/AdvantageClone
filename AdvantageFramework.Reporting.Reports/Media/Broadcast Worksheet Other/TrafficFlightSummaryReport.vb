Namespace Media.BroadcastWorksheetOther

    Public Class TrafficFlightSummaryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _Date As String = String.Empty
        Private _IsRadio As Boolean = False
        Private _UsePrimaryDemo As Boolean = True
        Private _FromDate As Date = Date.MinValue
        Private _ToDate As Date = Date.MinValue
        Private _TrafficFlightSummaryReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.TrafficFlightSummaryReport) = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ParameterDictionary As Dictionary(Of String, Object)
            Set(ByVal value As Dictionary(Of String, Object))
                _ParameterDictionary = value
            End Set
        End Property
        Public WriteOnly Property LocationEntity As AdvantageFramework.Database.Entities.Location
            Set(ByVal value As AdvantageFramework.Database.Entities.Location)
                _LocationEntity = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub TrafficFlightSummaryReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Me.BeforePrint

            _Date = System.DateTime.Now.ToString("F")

        End Sub
        Private Sub TrafficFlightSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            Dim MediaBroadcastWorksheetID As Integer = 0
            Dim MediaBroadcastWorksheetMarketIDVendorCodes As String = Nothing
            'Dim ShowSecondaryDemo As Boolean = False

            If _Session IsNot Nothing AndAlso _ParameterDictionary IsNot Nothing Then

                MediaBroadcastWorksheetID = _ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.MediaBroadcastWorksheetID.ToString)
                MediaBroadcastWorksheetMarketIDVendorCodes = _ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString)
                _FromDate = _ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.FromDate.ToString)
                _ToDate = _ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.ToDate.ToString)
                'ShowSecondaryDemo = _ParameterDictionary(AdvantageFramework.Reporting.TrafficFlightSummaryReportParameters.ShowSecondardDemo.ToString)

                'If ShowSecondaryDemo Then

                '    _UsePrimaryDemo = False

                'End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _TrafficFlightSummaryReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.TrafficFlightSummaryReport)(String.Format("exec advsp_media_broadcast_worksheet_other_traffic_flight_summary_report {0}, '{1}', '{2}', '{3}'",
                                                                                                                                                                         MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketIDVendorCodes, _FromDate, _ToDate)).ToList

                    If _TrafficFlightSummaryReports.Count > 0 Then

                        If _TrafficFlightSummaryReports.First.MediaType = "R" Then

                            _IsRadio = True

                        End If

                    End If

                    Me.DataSource = _TrafficFlightSummaryReports

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub LabelGroupHeaderStation_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Date.BeforePrint

            LabelGroupHeaderStation_Date.Text = Now.ToShortDateString

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub PageFooter_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles PageFooter.BeforePrint

            LabelPageFooter_Date.Text = _Date
            LabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub
        Private Sub LabelGroupMarketName_MediaType_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupMarketName_MediaType.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MarketScheduleWeeklyDetailReport.Properties.MediaType.ToString) = "R" Then

                LabelGroupMarketName_MediaType.Text = "Spot Radio"

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
