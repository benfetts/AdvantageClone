Namespace Media

    Public Class MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport

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

        Private Sub MediaBroadcastWorksheetRadioPreBuyDaypartSummaryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

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

                    LabelDetail_SpotEstimate.TextFormatString = "{0:n0}"
                    GroupFooterDaypart_SpotEstimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_SpotEstimate.TextFormatString = "{0:n0}"
                    ReportFooter_SpotEstimate.TextFormatString = "{0:n0}"

                    LabelDetail_SpotUpdatedEstimate.TextFormatString = "{0:n0}"
                    GroupFooterDaypart_SpotUpdatedEstimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_SpotUpdatedEstimate.TextFormatString = "{0:n0}"
                    ReportFooter_SpotUpdatedEstimate.TextFormatString = "{0:n0}"

                Else

                    LabelDetail_SpotEstimate.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_SpotEstimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_SpotEstimate.TextFormatString = "{0:n1}"
                    ReportFooter_SpotEstimate.TextFormatString = "{0:n1}"

                    LabelDetail_SpotUpdatedEstimate.TextFormatString = "{0:n1}"
                    GroupFooterDaypart_SpotUpdatedEstimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_SpotUpdatedEstimate.TextFormatString = "{0:n1}"
                    ReportFooter_SpotUpdatedEstimate.TextFormatString = "{0:n1}"

                End If

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Me.DataSource = AdvantageFramework.Reporting.LoadMediaBroadcastWorksheetRadioPreBuyData(DbContext, _ParameterDictionary).ToList

                End Using

            Else

                Me.DataSource = New Generic.List(Of AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport)

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

            _DemographicDescription = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.DemographicDescription.ToString)

            If _ParameterDictionary IsNot Nothing Then

                If _ParameterDictionary.ContainsKey(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString) Then

                    Try

                        WorksheetMarketVendors = _ParameterDictionary(AdvantageFramework.Reporting.MediaBroadcastWorksheetInitialCriteria.WorksheetMarketVendors.ToString)

                    Catch ex As Exception
                        WorksheetMarketVendors = Nothing
                    End Try

                    If WorksheetMarketVendors IsNot Nothing Then

                        ShowStationLabel = True

                        CurrentMediaBroadcastWorksheetMarketID = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.MediaBroadcastWorksheetMarketID.ToString)

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
        Private Sub LabelGroupHeaderStation_UpdatedBooksLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PreBuyBooksLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.UpdatedBooks.ToString) Is Nothing Then

                e.Cancel = True

            End If

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

            ElseIf Me.GroupFooterDaypart_SpotEstimate.Summary.GetResult = 0 Then

                GroupFooterDaypart_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterDaypart_Index.Text = FormatNumber(Me.GroupFooterDaypart_SpotUpdatedEstimate.Summary.GetResult / Me.GroupFooterDaypart_SpotEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub GroupFooterMarket_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.GroupFooterMarket_SpotEstimate.Summary.GetResult = 0 Then

                GroupFooterMarket_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterMarket_Index.Text = FormatNumber(Me.GroupFooterMarket_SpotUpdatedEstimate.Summary.GetResult / Me.GroupFooterMarket_SpotEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub ReportFooter_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf Me.ReportFooter_SpotEstimate.Summary.GetResult = 0 Then

                ReportFooter_Index.Text = FormatNumber(0, 0)

            Else

                ReportFooter_Index.Text = FormatNumber(Me.ReportFooter_SpotUpdatedEstimate.Summary.GetResult / Me.ReportFooter_SpotEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_ReportingDatesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_ReportingDatesLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.ReportedDates.ToString) Is Nothing Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_Demographic_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_Demographic.BeforePrint

            'objects
            Dim DemographicInfo As String = String.Empty

            Try

                DemographicInfo = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.DemographicDescription.ToString)

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
        Private Sub LabelDetail_SpotEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SpotEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_SpotUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SpotUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterDaypart_SpotEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_SpotEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterDaypart_SpotUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterDaypart_SpotUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_SpotEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_SpotEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_SpotUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_SpotUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_SpotEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_SpotEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_SpotUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_SpotUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_WorksheetBooks_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_WorksheetBooks.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.WorksheetBooks.ToString)) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
