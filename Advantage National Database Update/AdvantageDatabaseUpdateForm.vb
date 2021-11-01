Public Class AdvantageDatabaseUpdateForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If My.Application.CommandLineArgs.Count = 0 Then

            _UseSecurityLogin = True

        Else

            _UseSecurityLogin = False

        End If

        _Application = AdvantageFramework.Security.Application.Advantage_Nielsen_Database_Update

    End Sub
    Private Function RunFirstUpdate() As String

        RunFirstUpdate = "CREATE TABLE [dbo].[ADVAN_UPDATE] (
	                            [ADVAN_UPDATE_ID] [int] IDENTITY(1,1) NOT NULL,
	                            [VERSION_ID] [varchar](15) NOT NULL,
	                            [DB_UPDATE] [smalldatetime] NOT NULL,
                            CONSTRAINT [PK_ADVAN_UPDATE] PRIMARY KEY CLUSTERED 
                            (
	                            [ADVAN_UPDATE_ID] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                            ) ON [PRIMARY]

                            INSERT [dbo].[ADVAN_UPDATE]([VERSION_ID],[DB_UPDATE])
                            VALUES('6.70.02.00', GETDATE())

                            CREATE TABLE [dbo].[DB_UPDATE] (
	                            [DB_UPDATE_ID] [int] IDENTITY(1,1) NOT NULL,
	                            [VERSION_ID] [varchar](15) NOT NULL,
	                            [PATCH] [varchar](MAX) NOT NULL,
	                            [DATE_APPLIED] [smalldatetime] NOT NULL,
	                            [FILE_HASH] [varchar](MAX) NOT NULL,
                            CONSTRAINT [PK_DB_UPDATE] PRIMARY KEY CLUSTERED 
                            (
	                            [DB_UPDATE_ID] ASC
                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                            ) ON [PRIMARY]"

    End Function

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageDatabaseUpdateForm_CloseProgressBarEvent() Handles Me.CloseProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Visible = False

        Me.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_SetProgressBarValueEvent(CurrentValue As Integer) Handles Me.SetProgressBarValueEvent

        ProgressBarItemStatusBar_ProgressBar.Value = CurrentValue

        ProgressBarItemStatusBar_ProgressBar.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_SetupProgressBarEvent(MinimumValue As Integer, MaximumValue As Integer, StartValue As Integer) Handles Me.SetupProgressBarEvent

        ProgressBarItemStatusBar_ProgressBar.Minimum = MinimumValue
        ProgressBarItemStatusBar_ProgressBar.Maximum = MaximumValue
        ProgressBarItemStatusBar_ProgressBar.Value = StartValue

        ProgressBarItemStatusBar_ProgressBar.Visible = True

        Me.Refresh()

    End Sub
    Private Sub AdvantageDatabaseUpdateForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'objects
        Dim ShowDatabaseUpdateForm As Boolean = True
        Dim CompatibilityLevel As Integer = 0

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ADVAN_UPDATE' ").FirstOrDefault = 0 Then

                Try

                    DbContext.Database.ExecuteSqlCommand(RunFirstUpdate)

                Catch ex As Exception
                    ShowDatabaseUpdateForm = False
                End Try

            End If

            If ShowDatabaseUpdateForm Then

                If DbContext.Database.SqlQuery(Of Integer)("SELECT COUNT(*) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'ADVAN_UPDATE' AND COLUMN_NAME = 'ADVAN_UPDATE_ID' ").FirstOrDefault = 0 Then

                    AdvantageFramework.WinForm.MessageBox.Show("This is not a valid Nielsen Database.")
                    ShowDatabaseUpdateForm = False

                End If

            End If

            If ShowDatabaseUpdateForm Then

                Try

                    CompatibilityLevel = DbContext.Database.SqlQuery(Of Byte)(String.Format("SELECT [compatibility_level] FROM sys.databases WHERE name = '{0}'", _Session.DatabaseName)).FirstOrDefault

                Catch ex As Exception
					CompatibilityLevel = 100
				End Try

				If CompatibilityLevel < 100 Then

					AdvantageFramework.WinForm.MessageBox.Show("Compatibility Level for the database has to be 2008 and above.  Please contact technical support.")
					ShowDatabaseUpdateForm = False

				End If

			End If

        End Using

        If ShowDatabaseUpdateForm Then

            AdvantageFramework.Database.Presentation.NationalDatabaseUpdateForm.ShowForm(_InternalOnlyMode, _BatchMode)

        Else

            Me.Close()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
