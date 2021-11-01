Namespace Media

    Public Class MediaBroadcastWorksheetRadioPreBuyReport

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

        Private Sub MediaBroadcastWorksheetRadioPreBuyReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

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
                    LabelDetail_TotalEstimate.TextFormatString = "{0:n0}"
                    GroupFooterStation_TotalEstimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_TotalEstimate.TextFormatString = "{0:n0}"
                    ReportFooter_TotalEstimate.TextFormatString = "{0:n0}"

                    LabelDetail_SpotUpdatedEstimate.TextFormatString = "{0:n0}"
                    LabelDetail_TotalUpdatedEstimate.TextFormatString = "{0:n0}"
                    GroupFooterStation_TotalUpdatedEstimate.TextFormatString = "{0:n0}"
                    GroupFooterMarket_TotalUpdatedEstimate.TextFormatString = "{0:n0}"
                    ReportFooter_TotalUpdatedEstimate.TextFormatString = "{0:n0}"

                Else

                    LabelDetail_Estimate.TextFormatString = "{0:n1}"
                    LabelDetail_TotalEstimate.TextFormatString = "{0:n1}"
                    GroupFooterStation_TotalEstimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_TotalEstimate.TextFormatString = "{0:n1}"
                    ReportFooter_TotalEstimate.TextFormatString = "{0:n1}"

                    LabelDetail_SpotUpdatedEstimate.TextFormatString = "{0:n1}"
                    LabelDetail_TotalUpdatedEstimate.TextFormatString = "{0:n1}"
                    GroupFooterStation_TotalUpdatedEstimate.TextFormatString = "{0:n1}"
                    GroupFooterMarket_TotalUpdatedEstimate.TextFormatString = "{0:n1}"
                    ReportFooter_TotalUpdatedEstimate.TextFormatString = "{0:n1}"

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

        Private Sub LabelGroupHeaderStation_Date_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Date.BeforePrint

            LabelGroupHeaderStation_Date.Text = Now.ToShortDateString

        End Sub
        Private Sub LabelGroupHeaderStation_UpdatedBooksLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_PreBuyBooksLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.UpdatedBooks.ToString) Is Nothing Then

                LabelGroupHeaderStation_PreBuyBooksLabel.Text = Nothing

            End If

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
        Private Sub GroupFooterMarket_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf GroupFooterMarket_TotalEstimate.Summary.GetResult = 0 Then

                GroupFooterMarket_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterMarket_Index.Text = FormatNumber(GroupFooterMarket_TotalUpdatedEstimate.Summary.GetResult / GroupFooterMarket_TotalEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub GroupFooterStation_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf GroupFooterStation_TotalEstimate.Summary.GetResult = 0 Then

                GroupFooterStation_Index.Text = FormatNumber(0, 0)

            Else

                GroupFooterStation_Index.Text = FormatNumber(GroupFooterStation_TotalUpdatedEstimate.Summary.GetResult / GroupFooterStation_TotalEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub ReportFooter_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            ElseIf ReportFooter_TotalEstimate.Summary.GetResult = 0 Then

                ReportFooter_Index.Text = FormatNumber(0, 0)

            Else

                ReportFooter_Index.Text = FormatNumber(ReportFooter_TotalUpdatedEstimate.Summary.GetResult / ReportFooter_TotalEstimate.Summary.GetResult * 100, 0)

            End If

        End Sub
        Private Sub LabelGroupHeaderMarketName_ReportingDatesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderMarketName_ReportingDatesLabel.BeforePrint

            If Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.ReportedDates.ToString) Is Nothing Then

                LabelGroupHeaderMarketName_ReportingDatesLabel.Text = Nothing

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_Demographic_BeforePrint(sender As Object, e As Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_Demographic.BeforePrint

            'objects
            Dim DemographicInfo As String = String.Empty

            Try

                DemographicInfo = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.DemographicDescription.ToString)

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

                AddedValue = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.AddedValue.ToString)

            Catch ex As Exception
                AddedValue = False
            End Try

            If AddedValue Then

                LabelDetail_Daypart.Text &= " - AV"

            End If

        End Sub
        Private Sub GroupHeaderMarketName_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupHeaderMarketName.BeforePrint

            _DemographicDescription = Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.DemographicDescription.ToString)

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
        Private Sub LabelGroupHeaderStation_SpotLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SpotLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_TotalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_TotalLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SpotEstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SpotEstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_SpotUpdatedEstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_SpotUpdatedEstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_TotalEstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_TotalEstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_TotalUpdatedEstimateLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_TotalUpdatedEstimateLabel.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Estimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Estimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_SpotUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SpotUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_TotalEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_TotalEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_TotalUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_TotalUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_Index_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_Index.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterStation_TotalEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_TotalEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterStation_TotalUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterStation_TotalUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_TotalEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_TotalEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub GroupFooterMarket_TotalUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles GroupFooterMarket_TotalUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_TotalEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_TotalEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub ReportFooter_TotalUpdatedEstimate_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles ReportFooter_TotalUpdatedEstimate.BeforePrint

            If String.IsNullOrWhiteSpace(_DemographicDescription) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_ScheduleBooksLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_ScheduleBooksLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.WorksheetBooks.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelGroupHeaderStation_IndexLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelGroupHeaderStation_IndexLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.Reporting.Database.Classes.MediaBroadcastWorksheetRadioPreBuyReport.Properties.WorksheetBooks.ToString)) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
