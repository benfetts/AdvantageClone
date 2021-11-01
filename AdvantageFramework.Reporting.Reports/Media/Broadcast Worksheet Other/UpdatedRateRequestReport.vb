Namespace Media.BroadcastWorksheetOther

    Public Class UpdatedRateRequestReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _UseImpressions As Boolean = False
        Private _DemographicDescription As String = Nothing
        Private _Sharebook As String = Nothing
        Private _HPUTbook As String = Nothing
        Private _Books As String = Nothing
        Private _UpdatedRateRequestReports As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport) = Nothing
        Private _ShowSecondaryDemo As Boolean = False

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

        Private Sub UpdatedRateRequestReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaBroadcastWorksheetID As Integer = 0
            Dim MediaBroadcastWorksheetMarketIDVendorCodes As String = Nothing
            Dim ShowRatingsCPP As Boolean = False

            If _Session IsNot Nothing AndAlso _ParameterDictionary IsNot Nothing Then

                MediaBroadcastWorksheetID = _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.MediaBroadcastWorksheetID.ToString)
                MediaBroadcastWorksheetMarketIDVendorCodes = _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.MediaBroadcastWorksheetMarketIDVendorCodes.ToString)
                ShowRatingsCPP = _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowRatingsCPP.ToString)
                _ShowSecondaryDemo = _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowSecondardDemo.ToString)

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _UpdatedRateRequestReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport)(String.Format("exec advsp_media_broadcast_worksheet_other_updated_rate_request_report {0}, '{1}', {2}",
                                                                                                                                                                         MediaBroadcastWorksheetID, MediaBroadcastWorksheetMarketIDVendorCodes, ShowRatingsCPP)).ToList

                    LabelDetail_PrimaryCPPCPM.TextFormatString = "{0:c2}"
                    LabelDetail_SecondaryCPPCPM.TextFormatString = "{0:c2}"

                    If _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowRatingsCPP.ToString) Then

                        LabelGroupHeaderStation_RTGIMPLabel.Text = "Rating"
                        LabelGroupHeaderStation_SecondaryRTGIMPLabel.Text = "Rating"

                        LabelGroupHeaderStation_PrimaryCPPCPMLabel.Text = "CPP"
                        LabelGroupHeaderStation_SecondaryCPPCPMLabel.Text = "CPP"

                    Else

                        If _UpdatedRateRequestReports IsNot Nothing AndAlso _UpdatedRateRequestReports.Count > 0 AndAlso _UpdatedRateRequestReports.First.MediaType = "T" Then

                            LabelGroupHeaderStation_RTGIMPLabel.Text = "IMP (000)"
                            LabelGroupHeaderStation_SecondaryRTGIMPLabel.Text = "IMP (000)"

                        Else

                            LabelGroupHeaderStation_RTGIMPLabel.Text = "IMP (00)"
                            LabelGroupHeaderStation_SecondaryRTGIMPLabel.Text = "IMP (00)"

                        End If

                        LabelGroupHeaderStation_PrimaryCPPCPMLabel.Text = "CPM"
                        LabelGroupHeaderStation_SecondaryCPPCPMLabel.Text = "CPM"

                    End If

                    Me.DataSource = _UpdatedRateRequestReports

                End Using

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            'objects
            Dim UpdatedRateRequestReport As AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport = Nothing
            Dim ComscoreTVBook As AdvantageFramework.Database.Entities.ComscoreTVBook = Nothing
            Dim NielsenTVBook As AdvantageFramework.Nielsen.Database.Entities.NielsenTVBook = Nothing
            Dim NielsenRadioPeriod As AdvantageFramework.Nielsen.Database.Entities.NielsenRadioPeriod = Nothing
            Dim DTONielsenRadioPeriod As AdvantageFramework.DTO.Media.NielsenRadioPeriod = Nothing

            _Sharebook = Nothing
            _HPUTbook = Nothing

            Try

                UpdatedRateRequestReport = Me.GetCurrentRow()

                If UpdatedRateRequestReport IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If UpdatedRateRequestReport.MediaType = "T" AndAlso UpdatedRateRequestReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Comscore Then

                            If UpdatedRateRequestReport.SharebookID.GetValueOrDefault(0) <> 0 Then

                                ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, UpdatedRateRequestReport.SharebookID.Value)

                                If ComscoreTVBook IsNot Nothing Then

                                    _Sharebook = MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(ComscoreTVBook)

                                End If

                            End If

                            If UpdatedRateRequestReport.HPUTbookID.GetValueOrDefault(0) <> 0 Then

                                ComscoreTVBook = AdvantageFramework.Database.Procedures.ComscoreTVBook.LoadByID(DbContext, UpdatedRateRequestReport.HPUTbookID.Value)

                                If ComscoreTVBook IsNot Nothing Then

                                    _HPUTbook = MonthName(ComscoreTVBook.Month, True) & ComscoreTVBook.Year & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(ComscoreTVBook)

                                End If

                            End If

                        ElseIf UpdatedRateRequestReport.MediaType = "T" AndAlso UpdatedRateRequestReport.RatingsServiceID = Nielsen.Database.Entities.Methods.RatingsServiceID.Nielsen Then

                            If _Session.IsNielsenSetup Then

                                If UpdatedRateRequestReport.SharebookID.GetValueOrDefault(0) <> 0 Then

                                    Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                                        NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, UpdatedRateRequestReport.SharebookID.Value)

                                        If NielsenTVBook IsNot Nothing Then

                                            _Sharebook = MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(NielsenTVBook)

                                        End If

                                        If UpdatedRateRequestReport.HPUTbookID.GetValueOrDefault(0) <> 0 Then

                                            NielsenTVBook = AdvantageFramework.Nielsen.Database.Procedures.NielsenTVBook.LoadByID(NielsenDbContext, UpdatedRateRequestReport.HPUTbookID.Value)

                                            If NielsenTVBook IsNot Nothing Then

                                                _HPUTbook = MonthName(NielsenTVBook.Month, True) & NielsenTVBook.Year.ToString.Substring(2) & "-" & AdvantageFramework.Reporting.Reports.GetStreamName(NielsenTVBook)

                                            End If

                                        End If

                                    End Using

                                End If

                            End If

                        ElseIf UpdatedRateRequestReport.MediaType = "R" AndAlso _Session.IsNielsenSetup Then

                            Using NielsenDbContext = New AdvantageFramework.Nielsen.Database.DbContext(_Session.NielsenConnectionString, Nothing)

                                If UpdatedRateRequestReport.RadioPeriod1.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, UpdatedRateRequestReport.RadioPeriod1.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books = DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If UpdatedRateRequestReport.RadioPeriod2.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, UpdatedRateRequestReport.RadioPeriod2.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If UpdatedRateRequestReport.RadioPeriod3.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, UpdatedRateRequestReport.RadioPeriod3.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If UpdatedRateRequestReport.RadioPeriod4.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, UpdatedRateRequestReport.RadioPeriod4.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                                If UpdatedRateRequestReport.RadioPeriod5.GetValueOrDefault(0) <> 0 Then

                                    NielsenRadioPeriod = AdvantageFramework.Nielsen.Database.Procedures.NielsenRadioPeriod.LoadByID(NielsenDbContext, UpdatedRateRequestReport.RadioPeriod5.Value)

                                    If NielsenRadioPeriod IsNot Nothing Then

                                        DTONielsenRadioPeriod = New AdvantageFramework.DTO.Media.NielsenRadioPeriod(NielsenRadioPeriod)
                                        _Books += ", " & DTONielsenRadioPeriod.Description

                                    End If

                                End If

                            End Using

                        End If

                    End Using

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LabelGroupHeaderStation_ShareBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ShareBookLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport.Properties.MediaType.ToString) = "R" Then

                If String.IsNullOrWhiteSpace(_Books) Then

                    e.Cancel = True

                Else

                    LabelGroupHeaderStation_ShareBookLabel.Text = "Book(s):"

                End If

            ElseIf String.IsNullOrWhiteSpace(_Sharebook) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_ShareBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ShareBook.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport.Properties.MediaType.ToString) = "R" Then

                LabelGroupHeaderStation_ShareBook.Text = _Books

            Else

                LabelGroupHeaderStation_ShareBook.Text = _Sharebook

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_HPUTBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_HPUTBookLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_HPUTbook) Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport.Properties.RatingsServiceID.ToString) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                LabelGroupHeaderStation_HPUTBookLabel.Text = LabelGroupHeaderStation_HPUTBookLabel.Text.Replace("H/PUT", "SIU")

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_HPUTBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_HPUTBook.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.UpdatedRateRequestReport.Properties.MediaType.ToString) = "R" Then

                e.Cancel = True

            Else

                LabelGroupHeaderStation_HPUTBook.Text = _HPUTbook

            End If

        End Sub
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
        Private Sub LabelGroupHeaderStation_PrimaryCPPCPMLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PrimaryCPPCPMLabel.BeforePrint

            If _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowRatingsCPP.ToString) Then

                LabelGroupHeaderStation_PrimaryCPPCPMLabel.Text = "CPP"

            ElseIf _ParameterDictionary(AdvantageFramework.Reporting.UpdatedRateRequestReportParameters.ShowImpressionsCPM.ToString) Then

                LabelGroupHeaderStation_PrimaryCPPCPMLabel.Text = "CPM"

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SecondaryDemographic_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SecondaryDemographic.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SecondaryRTGIMPLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SecondaryRTGIMPLabel.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SecondaryCPPCPMLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SecondaryCPPCPMLabel.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_RevisedSecondaryRating_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_RevisedSecondaryRating.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_SecondaryCPPCPM_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SecondaryCPPCPM.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_SecondaryRatingImpression_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SecondaryRatingImpression.BeforePrint

            If _ShowSecondaryDemo = False Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
