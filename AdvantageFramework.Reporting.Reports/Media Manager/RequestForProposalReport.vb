Namespace MediaManager

    Public Class RequestForProposalReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _MediaRFPHeaderID As Integer = Nothing
        Private _MediaRFPPrintSetting As AdvantageFramework.Database.Entities.MediaRFPPrintSetting = Nothing

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property MediaRFPHeaderID As Integer
            Set(ByVal value As Integer)
                _MediaRFPHeaderID = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub RequestForProposalReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim MediaRFPHeader As AdvantageFramework.Database.Entities.MediaRFPHeader = Nothing
            Dim PrintSetting As AdvantageFramework.DTO.Media.RFP.PrintSetting = Nothing
            Dim RFPReports As Generic.List(Of AdvantageFramework.DTO.Media.RFP.RFPReport) = Nothing
            Dim RFPReport As AdvantageFramework.DTO.Media.RFP.RFPReport = Nothing
            Dim HtmlEmail As AdvantageFramework.Email.Classes.HtmlEmail = Nothing

            RFPReports = New Generic.List(Of AdvantageFramework.DTO.Media.RFP.RFPReport)

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                MediaRFPHeader = AdvantageFramework.Database.Procedures.MediaRFPHeader.LoadByID(DbContext, _MediaRFPHeaderID)

                If MediaRFPHeader IsNot Nothing Then

                    _MediaRFPPrintSetting = AdvantageFramework.Database.Procedures.MediaRFPPrintSetting.LoadByUserCodeAndMediaType(DbContext, _Session.UserCode, MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode)

                    If _MediaRFPPrintSetting Is Nothing Then

                        PrintSetting = New AdvantageFramework.DTO.Media.RFP.PrintSetting(_Session.UserCode, MediaRFPHeader.MediaBroadcastWorksheetMarket.MediaBroadcastWorksheet.MediaTypeCode)

                        _MediaRFPPrintSetting = New AdvantageFramework.Database.Entities.MediaRFPPrintSetting

                        PrintSetting.SaveToEntity(_MediaRFPPrintSetting)

                        _MediaRFPPrintSetting.DbContext = DbContext

                        AdvantageFramework.Database.Procedures.MediaRFPPrintSetting.Insert(DbContext, _MediaRFPPrintSetting, Nothing)

                        PrintSetting = New AdvantageFramework.DTO.Media.RFP.PrintSetting(_MediaRFPPrintSetting)

                    End If

                    HtmlEmail = New AdvantageFramework.Email.Classes.HtmlEmail(False, True)

                    CreateRFPReport(_Session, DbContext, MediaRFPHeader, HtmlEmail, RFPReport)

                    HtmlEmail.Finish()

                    RFPReports.Add(RFPReport)

                End If

            End Using

            Me.DataSource = RFPReports

        End Sub
        Private Sub LabelDetail_CPPGoal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CPPGoal.BeforePrint

            If _MediaRFPPrintSetting.IncludeCPP = AdvantageFramework.Media.MediaRFPIncludeCPPSettings.DoNotShow Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_CPPGoalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_CPPGoalLabel.BeforePrint

            If _MediaRFPPrintSetting.IncludeCPP = AdvantageFramework.Media.MediaRFPIncludeCPPSettings.DoNotShow Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_GRPGoal_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_GRPGoal.BeforePrint

            If _MediaRFPPrintSetting.IncludeGRP = AdvantageFramework.Media.MediaRFPIncludeGRPSettings.DoNotShow Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_GRPGoalLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_GRPGoalLabel.BeforePrint

            If _MediaRFPPrintSetting.IncludeGRP = AdvantageFramework.Media.MediaRFPIncludeGRPSettings.DoNotShow Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_RatingsSourceLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_RatingsSourceLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.DTO.Media.RFP.RFPReport.Properties.RatingsSource.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_SecondaryTargetAudiencesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_SecondaryTargetAudiencesLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.DTO.Media.RFP.RFPReport.Properties.SecondaryTargetAudiences.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_TargetAudienceLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_TargetAudienceLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.DTO.Media.RFP.RFPReport.Properties.TargetAudience.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_DaypartLengthLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_DaypartLengthLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.DTO.Media.RFP.RFPReport.Properties.Daypart.ToString)) Then

                e.Cancel = True

            End If

        End Sub
        Private Sub LabelDetail_AdditionalGuidelinesLabel_BeforePrint(sender As Object, e As System.Drawing.Printing.PrintEventArgs) Handles LabelDetail_AdditionalGuidelinesLabel.BeforePrint

            If String.IsNullOrWhiteSpace(Me.GetCurrentColumnValue(AdvantageFramework.DTO.Media.RFP.RFPReport.Properties.AdditionalGuidelines.ToString)) Then

                e.Cancel = True

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
