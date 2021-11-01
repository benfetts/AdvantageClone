Namespace GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryPostReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _PostPeriodCode As String = String.Empty
        Private _CycleCode As String = String.Empty

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property PostPeriodCode As String
            Set(ByVal value As String)
                _PostPeriodCode = value
            End Set
        End Property
        Public WriteOnly Property CycleCode As String
            Set(ByVal value As String)
                _CycleCode = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub RecurringJournalEntryPostReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim RecurringJournalEntryPostReports As Generic.List(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryPostReport) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                RecurringJournalEntryPostReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryPostReport)(String.Format("EXEC [dbo].[advsp_recurring_journal_entry_post_report_load] '{0}', '{1}'", _PostPeriodCode, _CycleCode)).ToList

                XrLabelPageHeader_AgencyName.Text = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

            End Using

            Me.DataSource = RecurringJournalEntryPostReports

            XrLabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
