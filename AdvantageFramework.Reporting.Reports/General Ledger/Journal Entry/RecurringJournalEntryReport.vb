Namespace GeneralLedger.JournalEntry

    Public Class RecurringJournalEntryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ControlNumber As Integer = 0

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property ControlNumber As Integer
            Set(ByVal value As Integer)
                _ControlNumber = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub RecurringJournalEntryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim RecurringJournalEntryReports As Generic.List(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryReport) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                RecurringJournalEntryReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.RecurringJournalEntryReport)(String.Format("EXEC [dbo].[advsp_recurring_journal_entry_report_load] {0}", _ControlNumber)).ToList

                XrLabelPageHeader_AgencyName.Text = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

            End Using

            Me.DataSource = RecurringJournalEntryReports

            XrLabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
