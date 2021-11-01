Namespace Media

    Public Class MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ParameterDictionary As Dictionary(Of String, Object) = Nothing
        Private _LocationEntity As AdvantageFramework.Database.Entities.Location = Nothing
        Private _StationIndex As Integer = 0
        Private _StationActual As Decimal = 0
        Private _StationEstimate As Decimal = 0
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

        Private Sub MediaBroadcastWorksheetPreBuyStationDaypartSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

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

                    GroupHeaderStation_Estimate.TextFormatString = "{0:n1}"
                    LabelDetail_Estimate.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_Estimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_Estimate.TextFormatString = "{0:n1}"
                    ReportFooter_Estimate.TextFormatString = "{0:n1}"

                    GroupHeaderStation_Actual.TextFormatString = "{0:n1}"
                    LabelDetail_Actual.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_Actual.TextFormatString = "{0:n1}"
                    GroupFooterMarket_Actual.TextFormatString = "{0:n1}"
                    ReportFooter_Actual.TextFormatString = "{0:n1}"

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.DataSource = AdvantageFramework.Reporting.LoadMediaBroadcastWorksheetPreBuyData(DbContext, _ParameterDictionary).OrderBy(Function(Entity) Entity.MarketName).ThenBy(Function(Entity) Entity.StationName).ThenBy(Function(Entity) Entity.Daypart).ToList

                End Using

            Else

                Me.DataSource = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport)

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

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
        Private Sub GroupHeaderStation_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderStation_Index.BeforePrint

            'objects
            Dim MediaBroadcastWorksheetMarketID As Integer = 0
            Dim StationName As String = Nothing
            Dim SpotUpdatedEstimateTotal As Decimal = 0
            Dim SpotEstimateTotal As Decimal = 0

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            Else

                MediaBroadcastWorksheetMarketID = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.MediaBroadcastWorksheetMarketID.ToString)

                StationName = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.StationName.ToString)

                SpotUpdatedEstimateTotal = (From Entity In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport))
                                            Where Entity.StationName = StationName AndAlso
                                              Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                            Select Entity.TotalUpdatedEstimate).Sum

                SpotEstimateTotal = (From Entity In DirectCast(Me.DataSource, Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport))
                                     Where Entity.StationName = StationName AndAlso
                                       Entity.MediaBroadcastWorksheetMarketID = MediaBroadcastWorksheetMarketID
                                     Select Entity.TotalEstimate).Sum

                If SpotEstimateTotal = 0 Then

                    GroupHeaderStation_Index.Text = FormatNumber(0, 0)

                Else

                    GroupHeaderStation_Index.Text = FormatNumber(SpotUpdatedEstimateTotal / SpotEstimateTotal * 100, 0)

                End If

            End If

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
        Private Sub LabelGroupHeaderMarketName_ReportingDatesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_ReportingDatesLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.ReportedDates.ToString) Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_Demographic_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Demographic.BeforePrint

            'objects
            Dim DemographicInfo As String = String.Empty

            Try

                DemographicInfo = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPostBuyReport.Properties.DemographicDescription.ToString)

            Catch ex As Exception
                DemographicInfo = String.Empty
            End Try

            If String.IsNullOrWhiteSpace(DemographicInfo) = False Then

                If _UseImpressions Then

                    LabelGroupHeaderMarketName_Demographic.Text = DemographicInfo & " / Imp (000)"

                Else

                    LabelGroupHeaderMarketName_Demographic.Text = DemographicInfo & " / Ratings"

                End If

            Else

                LabelGroupHeaderMarketName_Demographic.Text = String.Empty

            End If

        End Sub
        Private Sub GroupFooterDaypart_Daypart_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_Daypart.BeforePrint

            'objects
            Dim AddedValue As Boolean = False

            Try

                AddedValue = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPostBuyReport.Properties.AddedValue.ToString)

            Catch ex As Exception
                AddedValue = False
            End Try

            If AddedValue Then

                GroupFooterDaypart_Daypart.Text &= " - AV"

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_ScheduleShareBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ScheduleShareBookLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.ScheduleBooks.ToString) Is Nothing OrElse
                    String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.ScheduleBooks.ToString)) Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.RatingsServiceID.ToString) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                LabelGroupHeaderStation_ScheduleShareBookLabel.Text = LabelGroupHeaderStation_ScheduleShareBookLabel.Text.Replace("H/PUT", "SIU")

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_PreBuyShareBookLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PreBuyShareBookLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.PreBuyBooks.ToString) Is Nothing OrElse
                    String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.PreBuyBooks.ToString)) Then

                e.Cancel = True

            ElseIf Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.RatingsServiceID.ToString) = AdvantageFramework.Nielsen.Database.Entities.RatingsServiceID.Comscore Then

                LabelGroupHeaderStation_PreBuyShareBookLabel.Text = LabelGroupHeaderStation_PreBuyShareBookLabel.Text.Replace("H/PUT", "SIU")

            End If

        End Sub
        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            _DemographicDescription = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetPreBuyReport.Properties.DemographicDescription.ToString)

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
        Private Sub GroupHeaderStation_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderStation_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupHeaderStation_Actual_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderStation_Actual.BeforePrint

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

#End Region

#End Region

    End Class

End Namespace
