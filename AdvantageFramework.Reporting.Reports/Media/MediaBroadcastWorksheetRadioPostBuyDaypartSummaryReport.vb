Namespace Media

    Public Class MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _UseImpressions As Boolean = False
        Private _MediaBroadcastWorksheetRadioPostBuyReport As Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport) = Nothing
        Private _PostBooks As String = Nothing
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

        Private Sub MediaBroadcastWorksheetRadioPostBuyDaypartSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

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
                    GroupFooterDaypart_Estimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_Estimate.TextFormatString = "{0:n0}"
                    ReportFooter_Estimate.TextFormatString = "{0:n0}"

                    LabelDetail_Actual.TextFormatString = "{0:n0}"
                    GroupFooterDaypart_Actual.TextFormatString = "{0:n0}"
                    GroupFooterMarket_Actual.TextFormatString = "{0:n0}"
                    ReportFooter_Actual.TextFormatString = "{0:n0}"

                Else

                    LabelDetail_Estimate.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_Estimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_Estimate.TextFormatString = "{0:n1}"
                    ReportFooter_Estimate.TextFormatString = "{0:n1}"

                    LabelDetail_Actual.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_Actual.TextFormatString = "{0:n1}"
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
                                              ExternalRadioSource = Entity.ExternalRadioSource
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
                                            .DetailCost = Group.Sum(Function(Entity) Entity.DetailCost),
                                            .DetailEstimate = Group.Sum(Function(Entity) Entity.DetailEstimate),
                                            .DetailActual = Group.Sum(Function(Entity) Entity.DetailActual)}).ToList

                End Using

            Else

                Me.DataSource = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            'objects
            Dim ShowStationLabel As Boolean = False
            Dim StationNames As String = String.Empty
            Dim WorksheetMarketVendors As Generic.List(Of AdvantageFramework.DTO.Reporting.WorksheetMarketVendor) = Nothing
            Dim CurrentMediaBroadcastWorksheetMarketID As Integer = 0
            Dim DetailNielsenRadioPeriodIDs As Generic.List(Of Integer) = Nothing

            _DemographicDescription = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DemographicDescription.ToString)

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString) Then

                    Try

                        WorksheetMarketVendors = _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString)

                    Catch ex As Exception
                        WorksheetMarketVendors = Nothing
                    End Try

                    If WorksheetMarketVendors IsNot Nothing Then

                        ShowStationLabel = True

                        CurrentMediaBroadcastWorksheetMarketID = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.MediaBroadcastWorksheetMarketID.ToString)

                        For Each WMV In WorksheetMarketVendors.Where(Function(Entity) Entity.MediaBroadcastWorksheetMarketID = CurrentMediaBroadcastWorksheetMarketID)

                            If String.IsNullOrWhiteSpace(StationNames) Then

                                StationNames = WMV.VendorName

                            Else

                                StationNames &= ", " & WMV.VendorName

                            End If

                        Next

                    End If

                End If

            End If

            DetailNielsenRadioPeriodIDs = (From Entity In _MediaBroadcastWorksheetRadioPostBuyReport
                                           Where Entity.MediaBroadcastWorksheetMarketID = CurrentMediaBroadcastWorksheetMarketID AndAlso
                                                 Entity.DetailLineDate IsNot Nothing
                                           Select Entity.DetailNielsenRadioPeriodID).Distinct.ToList

            _PostBooks = AdvantageFramework.Reporting.Reports.Media.GetRadioBooks(_Session, DetailNielsenRadioPeriodIDs)

            LabelGroupHeaderStation_StationLabel.Visible = ShowStationLabel
            LabelGroupHeaderStation_StationName.Visible = ShowStationLabel
            LabelGroupHeaderStation_StationName.Text = StationNames

        End Sub
        Private Sub LabelGroupHeaderMarketName_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Date.BeforePrint

            LabelGroupHeaderMarketName_Date.Text = Now.ToShortDateString

        End Sub
        Private Sub LabelGroupHeaderMarketName_Requester_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Requester.BeforePrint

            LabelGroupHeaderMarketName_Requester.Text = _Session.EmployeeName

        End Sub
        Private Sub XrPictureBoxHeaderLogo_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles XrPictureBoxHeaderLogo.BeforePrint

            Dim Cancel As Boolean = True

            If _LocationEntity IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(_LocationEntity.LogoLandscapePath) AndAlso My.Computer.FileSystem.FileExists(_LocationEntity.LogoLandscapePath) Then

                XrPictureBoxHeaderLogo.ImageUrl = _LocationEntity.LogoLandscapePath

                Cancel = False

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub GroupFooterDaypart_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.GroupFooterDaypart_Estimate.Summary.GetResult = 0 Then

                GroupFooterDaypart_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterDaypart_Index.Text = FormatNumber(Me.GroupFooterDaypart_Actual.Summary.GetResult / Me.GroupFooterDaypart_Estimate.Summary.GetResult * 100, 0)

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
        Private Sub LabelGroupHeaderMarketName_ReportingDatesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_ReportingDatesLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.ReportedDates.ToString) Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_Demographic_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Demographic.BeforePrint

            'objects
            Dim DemographicInfo As String = String.Empty

            Try

                DemographicInfo = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.DemographicDescription.ToString)

            Catch ex As Exception
                DemographicInfo = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(DemographicInfo) = False Then

                If _UseImpressions Then

                    LabelGroupHeaderMarketName_Demographic.Text = DemographicInfo & " / AQH (00)"

                Else

                    LabelGroupHeaderMarketName_Demographic.Text = DemographicInfo & " / AQH Ratings"

                End If

            Else

                LabelGroupHeaderMarketName_Demographic.Text = String.Empty

            End If

        End Sub
        Private Sub GroupFooterDaypart_Daypart_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_Daypart.BeforePrint

            'objects
            Dim AddedValue As Boolean = False

            Try

                AddedValue = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.AddedValue.ToString)

            Catch ex As Exception
                AddedValue = False
            End Try

            If AddedValue Then

                GroupFooterDaypart_Daypart.Text &= " - AV"

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_PostBook_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_PostBook.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString) Is Nothing Then

                LabelGroupHeaderMarketName_PostBook.Text = _PostBooks

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_PostBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_PostBookLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString)) AndAlso
                    (Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPostBuyReport.Properties.PostBook.ToString) Is Nothing AndAlso String.IsNullOrWhiteSpace(_PostBooks)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_EstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_EstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_ActualLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_ActualLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_IndexLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_IndexLabel.BeforePrint

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
        Private Sub GroupFooterDaypart_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterDaypart_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_Actual.BeforePrint

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
        Private Sub LabelGroupHeaderMarketName_Source_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Source.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_SourceLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_SourceLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
