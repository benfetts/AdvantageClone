Namespace Media

    Public Class MediaBroadcastWorksheetRadioPostBuyReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _MediaBroadcastWorksheetRadioPostBuyReport As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport) = Nothing
        Private _UseImpressions As Boolean = False
        Private _DemographicDescription As String = Nothing

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

        Private Sub MediaBroadcastWorksheetRadioPostBuyReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaBroadcastWorksheetMarketBookList As Generic.List(Of DTO.Reporting.MediaBroadcastWorksheetPreBuy.MediaBroadcastWorksheetMarketBook) = Nothing

            If _Session IsNot Nothing Then

                If Not _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.Session.ToString) Then

                    _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.Session.ToString) = _Session

                End If

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.MediaBroadcastWorksheetMarketBooks.ToString) Then

                    Try

                        MediaBroadcastWorksheetMarketBookList = _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.MediaBroadcastWorksheetMarketBooks.ToString)

                    Catch ex As Exception
                        MediaBroadcastWorksheetMarketBookList = Nothing
                    End Try

                    If MediaBroadcastWorksheetMarketBookList IsNot Nothing AndAlso MediaBroadcastWorksheetMarketBookList.Count > 0 Then

                        _UseImpressions = MediaBroadcastWorksheetMarketBookList(0).UseImpressions

                    End If

                End If

                If _UseImpressions Then

                    LabelDetail_Estimate.TextFormatString = "{0:n0}"
                    Detail1_DetailEstimate.TextFormatString = "{0:n0}"
                    GroupFooterStation_Estimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_Estimate.TextFormatString = "{0:n0}"
                    ReportFooter_Estimate.TextFormatString = "{0:n0}"

                    LabelDetail_Actual.TextFormatString = "{0:n0}"
                    Detail1_DetailActual.TextFormatString = "{0:n0}"
                    GroupFooterStation_Actual.TextFormatString = "{0:n0}"
                    GroupFooterMarket_Actual.TextFormatString = "{0:n0}"
                    ReportFooter_Actual.TextFormatString = "{0:n0}"

                Else

                    LabelDetail_Estimate.TextFormatString = "{0:n1}"
                    Detail1_DetailEstimate.TextFormatString = "{0:n1}"
                    GroupFooterStation_Estimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_Estimate.TextFormatString = "{0:n1}"
                    ReportFooter_Estimate.TextFormatString = "{0:n1}"

                    LabelDetail_Actual.TextFormatString = "{0:n1}"
                    Detail1_DetailActual.TextFormatString = "{0:n1}"
                    GroupFooterStation_Actual.TextFormatString = "{0:n1}"
                    GroupFooterMarket_Actual.TextFormatString = "{0:n1}"
                    ReportFooter_Actual.TextFormatString = "{0:n1}"

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _MediaBroadcastWorksheetRadioPostBuyReport = AdvantageFramework.Reporting.LoadMediaBroadcastWorksheetRadioPostBuyData(DbContext, _ParameterDictionary, False)

                    Me.DataSource = (From Entity In _MediaBroadcastWorksheetRadioPostBuyReport
                                     Group By ClientName = Entity.ClientName,
                                        DivisionName = Entity.DivisionName,
                                        ProductDescription = Entity.ProductDescription,
                                        MediaBroadcastWorksheetName = Entity.MediaBroadcastWorksheetName,
                                        MarketName = Entity.MarketName,
                                        MediaBroadcastWorksheetMarketID = Entity.MediaBroadcastWorksheetMarketID,
                                        VendorName = Entity.VendorName,
                                        FlightDates = Entity.FlightDates,
                                        PostBook = Entity.PostBook,
                                        LineNumber = Entity.LineNumber,
                                        MakeGoodNumber = Entity.MakeGoodNumber,
                                        LineMinDate = Entity.LineMinDate,
                                        LineMaxDate = Entity.LineMaxDate,
                                        Days = Entity.Days,
                                        Time = Entity.Time,
                                        Daypart = Entity.Daypart,
                                        AddedValue = Entity.AddedValue,
                                        Len = Entity.Len,
                                        OrdSpots = Entity.OrdSpots,
                                        ActualSpots = Entity.ActualSpots,
                                        Cost = Entity.Cost,
                                        Estimate = Entity.Estimate,
                                        Actual = Entity.Actual,
                                        NielsenRadioStationComboID = Entity.NielsenRadioStationComboID,
                                        DemographicDescription = Entity.DemographicDescription,
                                        StationName = Entity.StationName,
                                        NielsenMarketNumber = Entity.NielsenMarketNumber,
                                        MediaBroadcastWorksheetMarketDetailID = Entity.MediaBroadcastWorksheetMarketDetailID,
                                        ReportedDates = Entity.ReportedDates,
                                        ExternalRadioSource = Entity.ExternalRadioSource,
                                        GeographyEthnicity = Entity.GeographyEthnicity
                                 Into Group = Group
                                     Select New AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport With {
                                        .ClientName = ClientName,
                                        .DivisionName = DivisionName,
                                        .ProductDescription = ProductDescription,
                                        .MediaBroadcastWorksheetName = MediaBroadcastWorksheetName,
                                        .MarketName = MarketName,
                                        .MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID,
                                        .VendorName = VendorName,
                                        .FlightDates = FlightDates,
                                        .PostBook = PostBook,
                                        .LineNumber = LineNumber,
                                        .MakeGoodNumber = MakeGoodNumber,
                                        .LineMinDate = LineMinDate,
                                        .LineMaxDate = LineMaxDate,
                                        .Days = Days,
                                        .Time = Time,
                                        .Daypart = Daypart,
                                        .AddedValue = AddedValue,
                                        .Len = Len,
                                        .OrdSpots = OrdSpots,
                                        .ActualSpots = ActualSpots,
                                        .Cost = Cost,
                                        .Estimate = Estimate,
                                        .Actual = Actual,
                                        .NielsenRadioStationComboID = NielsenRadioStationComboID,
                                        .DemographicDescription = DemographicDescription,
                                        .StationName = StationName,
                                        .NielsenMarketNumber = NielsenMarketNumber,
                                        .MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID,
                                        .ReportedDates = ReportedDates,
                                        .ExternalRadioSource = ExternalRadioSource,
                                        .GeographyEthnicity = GeographyEthnicity}).OrderBy(Function(Entity) Entity.MarketName).ThenBy(Function(Entity) Entity.StationName).ThenBy(Function(Entity) Entity.LineNumber).ThenBy(Function(Entity) Entity.MakeGoodNumber).ToList

                End Using

            Else

                Me.DataSource = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DetailReport_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles DetailReport.BeforePrint

            'objects
            Dim MediaBroadcastWorksheetMarketDetailID As Integer = Nothing
            Dim MediaBroadcastWorksheetRadioPostBuyReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport) = Nothing

            Try

                MediaBroadcastWorksheetMarketDetailID = DirectCast(Me.GetCurrentRow, AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport).MediaBroadcastWorksheetMarketDetailID

                MediaBroadcastWorksheetRadioPostBuyReportList = (From Entity In _MediaBroadcastWorksheetRadioPostBuyReport
                                                                 Where Entity.MediaBroadcastWorksheetMarketDetailID = MediaBroadcastWorksheetMarketDetailID AndAlso
                                                                       Entity.DetailLineDate IsNot Nothing
                                                                 Select Entity).ToList

                DetailReport.DataSource = MediaBroadcastWorksheetRadioPostBuyReportList.OrderBy(Function(RPT) RPT.DetailLineDate)

            Catch ex As Exception
                DetailReport.DataSource = Nothing
            End Try

            If DetailReport.DataSource Is Nothing OrElse MediaBroadcastWorksheetRadioPostBuyReportList.Count = 0 Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Date.BeforePrint

            LabelGroupHeaderStation_Date.Text = Now.ToShortDateString

        End Sub
        Private Sub LabelGroupHeaderStation_Requester_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Requester.BeforePrint

            LabelGroupHeaderStation_Requester.Text = _Session.EmployeeName

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub GroupFooterStation_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.GroupFooterStation_Estimate.Summary.GetResult = 0 Then

                GroupFooterStation_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterStation_Index.Text = FormatNumber(Me.GroupFooterStation_Actual.Summary.GetResult / Me.GroupFooterStation_Estimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub GroupFooterMarket_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.GroupFooterMarket_Estimate.Summary.GetResult = 0 Then

                GroupFooterMarket_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterMarket_Index.Text = FormatNumber(Me.GroupFooterMarket_Actual.Summary.GetResult / Me.GroupFooterMarket_Estimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub ReportFooter_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.ReportFooter_Estimate.Summary.GetResult = 0 Then

                ReportFooter_Index.Text = FormatNumber(0, 0)

            Else

                ReportFooter_Index.Text = FormatNumber(Me.ReportFooter_Actual.Summary.GetResult / Me.ReportFooter_Estimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub Detail1_DetailActual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail1_DetailActual.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf _UseImpressions Then

                If DetailReport.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.OverridePostAQH.ToString) = True Then

                    Detail1_DetailActual.Text = "* " & FormatNumber(DetailReport.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DetailActual.ToString), 0)

                End If

            Else

                If DetailReport.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.OverridePost.ToString) = True Then

                    Detail1_DetailActual.Text = "* " & DetailReport.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DetailActual.ToString)

                End If

            End If

        End Sub
        Private Sub LabelDetail_ActualCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_ActualCost.BeforePrint

            Dim NielsenMarketNumber As Integer = 0
            Dim StationName As String = Nothing
            Dim FormattedLineNumber As String = Nothing

            NielsenMarketNumber = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.NielsenMarketNumber.ToString)

            StationName = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.StationName.ToString)

            FormattedLineNumber = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.FormattedLineNumber.ToString)

            LabelDetail_ActualCost.Text = FormatNumber(_MediaBroadcastWorksheetRadioPostBuyReport.Where(Function(rpt) rpt.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                                                                                      rpt.StationName = StationName AndAlso
                                                                                                                      rpt.FormattedLineNumber = FormattedLineNumber).Sum(Function(rpt) rpt.DetailCost), 2)

        End Sub
        Private Sub GroupFooterStation_ActualCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_ActualCost.BeforePrint

            Dim NielsenMarketNumber As Integer = 0
            Dim StationName As String = Nothing

            NielsenMarketNumber = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.NielsenMarketNumber.ToString)

            StationName = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.StationName.ToString)

            GroupFooterStation_ActualCost.Text = FormatNumber(_MediaBroadcastWorksheetRadioPostBuyReport.Where(Function(rpt) rpt.NielsenMarketNumber = NielsenMarketNumber AndAlso
                                                                                                                        rpt.StationName = StationName).Sum(Function(rpt) rpt.DetailCost), 2)

        End Sub
        Private Sub GroupFooterMarket_ActualCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_ActualCost.BeforePrint

            Dim NielsenMarketNumber As Integer = 0

            NielsenMarketNumber = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.NielsenMarketNumber.ToString)

            GroupFooterMarket_ActualCost.Text = FormatNumber(_MediaBroadcastWorksheetRadioPostBuyReport.Where(Function(rpt) rpt.NielsenMarketNumber = NielsenMarketNumber).Sum(Function(rpt) rpt.DetailCost), 2)

        End Sub
        Private Sub ReportFooter_ActualCost_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_ActualCost.BeforePrint

            ReportFooter_ActualCost.Text = FormatNumber(_MediaBroadcastWorksheetRadioPostBuyReport.Sum(Function(rpt) rpt.DetailCost), 2)

        End Sub
        Private Sub LabelGroupHeaderStation_ReportingDatesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ReportingDatesLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.ReportedDates.ToString) Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_Demographic_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Demographic.BeforePrint

            'objects
            Dim DemographicInfo As String = String.Empty

            Try

                DemographicInfo = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DemographicDescription.ToString)

            Catch ex As Exception
                DemographicInfo = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(DemographicInfo) = False Then

                If _UseImpressions Then

                    LabelGroupHeaderStation_Demographic.Text = DemographicInfo & " / AQH (00)"

                Else

                    LabelGroupHeaderStation_Demographic.Text = DemographicInfo & " / AQH Ratings"

                End If

            Else

                LabelGroupHeaderStation_Demographic.Text = String.Empty

            End If

        End Sub
        Private Sub LabelDetail_Daypart_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelDetail_Daypart.BeforePrint

            'objects
            Dim AddedValue As Boolean = False

            Try

                AddedValue = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.AddedValue.ToString)

            Catch ex As Exception
                AddedValue = False
            End Try

            If AddedValue Then

                LabelDetail_Daypart.Text &= " - AV"

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_PostBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PostBookLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Override_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Override.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.OverridePost.ToString) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_PostingBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PostingBookLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString)) = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail1_DetailBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail1_DetailBook.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString)) = False Then

                e.Cancel = True

            End If

            'If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.OverridePost.ToString) = True Then

            '    e.Cancel = True

            'End If

        End Sub
        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            _DemographicDescription = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DemographicDescription.ToString)

        End Sub
        Private Sub LabelGroupHeaderStation_EstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_EstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_ActualLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ActualLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_IndexLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_IndexLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Actual.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail1_DetailEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail1_DetailEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub Detail1_DetailIndex_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles Detail1_DetailIndex.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterStation_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterStation_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_Actual.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_Actual.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_Actual.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_Source_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Source.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SourceLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SourceLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
