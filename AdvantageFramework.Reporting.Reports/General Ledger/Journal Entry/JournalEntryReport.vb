Namespace GeneralLedger.JournalEntry

    Public Class JournalEntryReport

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _Transaction As Integer = 0

#End Region

#Region " Properties "

        Public WriteOnly Property Session As AdvantageFramework.Security.Session
            Set(ByVal value As AdvantageFramework.Security.Session)
                _Session = value
            End Set
        End Property
        Public WriteOnly Property Transaction As Integer
            Set(ByVal value As Integer)
                _Transaction = value
            End Set
        End Property

#End Region

#Region " Methods "



#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

        Private Sub JournalEntryReport_DataSourceDemanded(sender As Object, e As EventArgs) Handles Me.DataSourceDemanded

            'objects
            Dim JournalEntryReports As Generic.List(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.JournalEntryReport) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                DbContext.Database.Connection.Open()

                JournalEntryReports = DbContext.Database.SqlQuery(Of AdvantageFramework.Classes.GeneralLedger.JournalEntry.JournalEntryReport)(String.Format("EXEC [dbo].[advsp_journal_entry_report_load] {0}", _Transaction)).ToList

                XrLabelPageHeader_AgencyName.Text = AdvantageFramework.Database.Procedures.Agency.LoadName(DbContext)

            End Using

            Me.DataSource = JournalEntryReports

            XrLabelPageFooter_UserCode.Text = _Session.UserCode

        End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace
