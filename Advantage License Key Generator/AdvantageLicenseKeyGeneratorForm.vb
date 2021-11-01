Public Class AdvantageLicenseKeyGeneratorForm

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

        _Application = AdvantageFramework.Security.Application.Advantage_Database_Update

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "

    Private Sub AdvantageLicenseKeyGeneratorForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        TabStripForm_MDIChildren.Visible = False
        TabStripForm_MDIChildren.MdiTabbedDocuments = False

        If _UseSecurityLogin = False Then

            LoadStartUpInformation(My.Application.CommandLineArgs)

        End If

    End Sub
    Private Sub AdvantageLicenseKeyGeneratorForm_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        'objects
        Dim DatabaseSQLUser As AdvantageFramework.Security.Database.Views.DatabaseSQLUser = Nothing
        Dim LicenseWrite As Boolean = True
        Dim LicenseRead As Boolean = True
        Dim IsSysAdmin As Boolean = False

        LicenseWrite = False
        LicenseRead = False

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            'Try

            '    'DatabaseSQLUser = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.LoadByName(SecurityDbContext, _Session.User.UserName)

            '    'If DatabaseSQLUser IsNot Nothing Then

            '    LicenseWrite = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserLicenseWrite(SecurityDbContext, DatabaseSQLUser.ID)
            '    LicenseRead = AdvantageFramework.Security.Database.Procedures.DatabaseSQLUserView.IsDatabaseSQLUserLicenseRead(SecurityDbContext, DatabaseSQLUser.ID)

            '    ' End If

            'Catch ex As Exception
            '    LicenseWrite = False
            '    LicenseRead = False
            'End Try

            Try

                IsSysAdmin = (SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_SRVROLEMEMBER('sysadmin'), 0)").FirstOrDefault <> 0)

            Catch ex As Exception
                IsSysAdmin = False
            End Try

            If IsSysAdmin = False Then

                Try

                    LicenseWrite = (SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_MEMBER('license_write'), 0)").FirstOrDefault <> 0)

                Catch ex As Exception
                    LicenseWrite = False
                End Try

                Try

                    LicenseRead = (SecurityDbContext.Database.SqlQuery(Of Integer)("SELECT ISNULL(IS_MEMBER('license_read'), 0)").FirstOrDefault <> 0)

                Catch ex As Exception
                    LicenseRead = False
                End Try

            Else

                LicenseWrite = True
                LicenseRead = True

            End If

        End Using

        If LicenseRead OrElse LicenseWrite Then

            AdvantageFramework.Security.Presentation.LicenseKeySetupForm.ShowForm(LicenseRead, LicenseWrite)

        Else

            AdvantageFramework.WinForm.MessageBox.Show("You must be a license_read or license_write member to have access to this application.")

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "



#End Region

#End Region

End Class
