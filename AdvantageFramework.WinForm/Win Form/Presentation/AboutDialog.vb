Namespace WinForm.Presentation

    Public Class AboutDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As Windows.Forms.DialogResult

            Dim AboutDialog As AdvantageFramework.WinForm.Presentation.AboutDialog = Nothing

            AboutDialog = New AdvantageFramework.WinForm.Presentation.AboutDialog()

            ShowFormDialog = AboutDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AboutDialog_BeforeShowDialog() Handles Me.BeforeShowDialog

            Me.MaximizeBox = False
            Me.ControlBox = False

        End Sub
        Private Sub AboutDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ApplicationTitle As String = ""
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim LicenseKeyDate As Date = Nothing
            Dim DaysUntilFileExpires As Integer = 0
            Dim DaysUntilKeyExpires As Integer = 0
            Dim PowerUsersQuantity As Integer = 0
            Dim WVOnlyUsersQuantity As Integer = 0
            Dim ClientPortalUsersQuantity As Integer = 0
            Dim MediaToolsUsersQuantity As Integer = 0
            Dim APIUsersQuantity As Integer = 0
            Dim EnableProofingTool As Boolean = False
            Dim AgencyName As String = ""
            Dim LicenseKey As String = ""
            Dim DatabaseID As Integer = 0
            Dim ErrorMessage As String = String.Empty

            Me.ShowUnsavedChangesOnFormClosing = False

            If My.Application.Info.Title <> "" Then

                ApplicationTitle = My.Application.Info.Title

            Else

                ApplicationTitle = System.IO.Path.GetFileNameWithoutExtension(My.Application.Info.AssemblyName)

            End If

            LabelForm_Application.Text = String.Format(LabelForm_Application.Text, ApplicationTitle)
            LabelForm_SoftwareVersion.Text = String.Format(LabelForm_SoftwareVersion.Text, "v" & Format(My.Application.Info.Version.Major, "##") & "." & Format(My.Application.Info.Version.Minor, "##") & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00"))
            LabelForm_Copyright.Text = My.Application.Info.Copyright
            LabelForm_Description.Text = String.Format(LabelForm_Description.Text, My.Application.Info.Description)
            LabelForm_VersionDescription.Text = String.Format(LabelForm_VersionDescription.Text, "v" & Format(My.Application.Info.Version.Major, "##") & "." & Format(My.Application.Info.Version.Minor, "##") & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00"))
            LabelForm_Locale.Text = String.Format(LabelForm_Locale.Text, My.Application.Culture.EnglishName)

            If Me.Session IsNot Nothing Then

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        LabelForm_CollationMessage.Text = "Collation: " & AdvantageFramework.Database.LoadDatabaseCollation(Session.ConnectionString)

                        If LabelForm_CollationMessage.Text.Contains("SQL_Latin1_General_CP1_CS_AS") = False Then

                            LabelForm_CollationMessage.ForeColor = Drawing.Color.Red

                        End If

                    Catch ex As Exception
                        LabelForm_CollationMessage.Text = "Collation: "
                    End Try

                    LabelForm_ServerName.Text = String.Format(LabelForm_ServerName.Text, Me.Session.ServerName)
                    LabelForm_DatabaseName.Text = String.Format(LabelForm_DatabaseName.Text, Me.Session.DatabaseName)
                    LabelForm_User.Text = String.Format(LabelForm_User.Text, Me.Session.User.ID & " - " & Me.Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                        Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    End Using

                    If Agency IsNot Nothing Then

                        LicenseKey = AdvantageFramework.Security.LicenseKey.Read(Agency.LicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                                 PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName,
                                                                                 DatabaseID, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                        If LicenseKey <> "" Then

                            If WVOnlyUsersQuantity <> -1 AndAlso APIUsersQuantity <> 0 Then

                                WVOnlyUsersQuantity += 1

                            End If

                            LabelForm_Agency.Text = String.Format(LabelForm_Agency.Text, AgencyName.Trim)
                            LabelForm_PowerUsers.Text = String.Format(LabelForm_PowerUsers.Text, IIf(PowerUsersQuantity = -1, "ULTD", PowerUsersQuantity))
                            LabelForm_PowerUsersConnected.Text = String.Format(LabelForm_PowerUsersConnected.Text, AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.PowerUser).Count)
                            LabelForm_WVUsers.Text = String.Format(LabelForm_WVUsers.Text, IIf(WVOnlyUsersQuantity = -1, "ULTD", WVOnlyUsersQuantity))
                            LabelForm_WVUsersConnected.Text = String.Format(LabelForm_WVUsersConnected.Text, AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly).Count)
                            LabelForm_CPUsers.Text = String.Format(LabelForm_CPUsers.Text, IIf(ClientPortalUsersQuantity = -1, "ULTD", ClientPortalUsersQuantity))
                            LabelForm_CPUsersConnected.Text = String.Format(LabelForm_CPUsersConnected.Text, AdvantageFramework.Security.LicenseKey.LoadConnectedUsers(Me.Session, AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser).Count)
                            LabelForm_MediaToolsUsers.Text = String.Format(LabelForm_MediaToolsUsers.Text, IIf(MediaToolsUsersQuantity = -1, "ULTD", MediaToolsUsersQuantity))
                            LabelForm_APIUsers.Text = String.Format(LabelForm_APIUsers.Text, IIf(APIUsersQuantity = -1, "ULTD", APIUsersQuantity))
                            LabelForm_ProofingToolEnabled.Text = String.Format(LabelForm_ProofingToolEnabled.Text, IIf(EnableProofingTool = True, "Yes", "No"))

                        End If

                    End If

                    Try

                        LabelForm_WebvantageDatabaseVersion.Text = String.Format(LabelForm_WebvantageDatabaseVersion.Text, SecurityDbContext.Database.SqlQuery(Of String)("SELECT WEBVAN_VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault)

                    Catch ex As Exception
                        LabelForm_WebvantageDatabaseVersion.Text = String.Format(LabelForm_WebvantageDatabaseVersion.Text, "")
                    End Try

                    Try

                        LabelForm_AdvantageDatabaseVersion.Text = String.Format(LabelForm_AdvantageDatabaseVersion.Text, SecurityDbContext.Database.SqlQuery(Of String)("SELECT VERSION_ID FROM dbo.ADVAN_UPDATE").FirstOrDefault)

                    Catch ex As Exception
                        LabelForm_AdvantageDatabaseVersion.Text = String.Format(LabelForm_AdvantageDatabaseVersion.Text, "v" & Format(My.Application.Info.Version.Major, "##") & "." & Format(My.Application.Info.Version.Minor, "##") & "." & Format(My.Application.Info.Version.Build, "00") & "." & Format(My.Application.Info.Version.Revision, "00"))
                    End Try

                    Try

                        LabelForm_LastDatabaseUpdate.Text = String.Format(LabelForm_LastDatabaseUpdate.Text, SecurityDbContext.Database.SqlQuery(Of Date)("SELECT DB_UPDATE FROM dbo.ADVAN_UPDATE").FirstOrDefault.ToString)

                    Catch ex As Exception
                        LabelForm_LastDatabaseUpdate.Text = String.Format(LabelForm_LastDatabaseUpdate.Text, "")
                    End Try

                    Try

                        LabelForm_SQLServerAppName.Text = String.Format(LabelForm_SQLServerAppName.Text, SecurityDbContext.Database.SqlQuery(Of String)("SELECT APP_NAME()").FirstOrDefault)

                    Catch ex As Exception
                        LabelForm_SQLServerAppName.Text = String.Format(LabelForm_SQLServerAppName.Text, "")
                    End Try

                End Using

            Else

                LabelForm_CollationMessage.Text = "Collation: "
                LabelForm_ServerName.Text = String.Format(LabelForm_ServerName.Text, "")
                LabelForm_DatabaseName.Text = String.Format(LabelForm_DatabaseName.Text, "")
                LabelForm_User.Text = String.Format(LabelForm_User.Text, "")

                LabelForm_Agency.Text = String.Format(LabelForm_Agency.Text, "")
                LabelForm_PowerUsers.Text = String.Format(LabelForm_PowerUsers.Text, "")
                LabelForm_PowerUsersConnected.Text = String.Format(LabelForm_PowerUsersConnected.Text, "")
                LabelForm_PowerUsersConnected.Enabled = False
                LabelForm_WVUsers.Text = String.Format(LabelForm_WVUsers.Text, "")
                LabelForm_WVUsersConnected.Text = String.Format(LabelForm_WVUsersConnected.Text, "")
                LabelForm_WVUsersConnected.Enabled = False
                LabelForm_CPUsers.Text = String.Format(LabelForm_CPUsers.Text, "")
                LabelForm_CPUsersConnected.Text = String.Format(LabelForm_CPUsersConnected.Text, "")
                LabelForm_CPUsersConnected.Enabled = False
                LabelForm_MediaToolsUsers.Text = String.Format(LabelForm_MediaToolsUsers.Text, "")
                LabelForm_APIUsers.Text = String.Format(LabelForm_APIUsers.Text, "")

                LabelForm_WebvantageDatabaseVersion.Text = String.Format(LabelForm_WebvantageDatabaseVersion.Text, "")
                LabelForm_AdvantageDatabaseVersion.Text = String.Format(LabelForm_AdvantageDatabaseVersion.Text, "")
                LabelForm_LastDatabaseUpdate.Text = String.Format(LabelForm_LastDatabaseUpdate.Text, "")
                LabelForm_SQLServerAppName.Text = String.Format(LabelForm_SQLServerAppName.Text, "")

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
