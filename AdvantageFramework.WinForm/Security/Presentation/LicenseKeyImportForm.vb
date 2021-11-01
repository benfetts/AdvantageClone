Namespace Security.Presentation

    Public Class LicenseKeyImportForm

#Region " Constants "



#End Region

#Region " Enum "

        Private Enum LicenseFileType
            Advantage
            Comscore
        End Enum

#End Region

#Region " Variables "

        Private _LoadUserModuleAccess As Boolean = False
        Private _LoadUserUserSettings As Boolean = False
        Private _UserList As Generic.List(Of AdvantageFramework.Security.Database.Entities.User) = Nothing
        Private _LicenseFileType As LicenseFileType = LicenseFileType.Advantage

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

        Public Shared Sub ShowForm()

            'objects
            Dim LicenseKeyImportForm As AdvantageFramework.Security.Presentation.LicenseKeyImportForm = Nothing

            LicenseKeyImportForm = New AdvantageFramework.Security.Presentation.LicenseKeyImportForm()

            LicenseKeyImportForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub LicenseKeyImportForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

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

            ButtonItemActions_Import.Image = AdvantageFramework.My.Resources.DatabaseImportImage

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

            End Using

            If Agency IsNot Nothing Then

                LicenseKey = AdvantageFramework.Security.LicenseKey.Read(Agency.LicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                         PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID,
                                                                         MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                If LicenseKey <> "" Then

                    LabelCurrentLicenseKeyFileInformation_AgencyName.Text = AgencyName.Trim
                    LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Text = IIf(ClientPortalUsersQuantity = -1, "Unlimited", ClientPortalUsersQuantity)
                    LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Text = IIf(WVOnlyUsersQuantity = -1, "Unlimited", WVOnlyUsersQuantity)
                    LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Text = IIf(PowerUsersQuantity = -1, "Unlimited", PowerUsersQuantity)
                    LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Text = IIf(MediaToolsUsersQuantity = -1, "Unlimited", MediaToolsUsersQuantity)
                    LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Text = IIf(APIUsersQuantity = -1, "Unlimited", APIUsersQuantity)
                    LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Text = IIf(EnableProofingTool = True, "Yes", "No")

                Else

                    LabelCurrentLicenseKeyFileInformation_AgencyName.Text = ""
                    LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Text = ""
                    LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Text = ""
                    LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Text = ""
                    LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Text = ""
                    LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Text = ""
                    LabelCurrentLicenseKeyFileInformation_ProofingEnabledYesNo.Text = ""

                End If

            Else

                LabelCurrentLicenseKeyFileInformation_AgencyName.Text = ""
                LabelCurrentLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Text = ""
                LabelCurrentLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Text = ""
                LabelCurrentLicenseKeyFileInformation_PowerLicenseQuantityAmount.Text = ""
                LabelCurrentLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Text = ""
                LabelCurrentLicenseKeyFileInformation_APILicenseQuantityAmount.Text = ""

            End If

            TextBoxForm_LicenseKeyFile.SetAgencyImportPath("", False)

            PanelForm_LicenseKeyInformation.Visible = True
            PanelForm_ComscoreLicenseInfo.Visible = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Import_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Import.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim Remove As Boolean = False

            If Me.Validator Then

                If _LicenseFileType = LicenseFileType.Advantage Then

                    If AdvantageFramework.Security.LicenseKey.ImportLicenseKey(Me.Session, TextBoxForm_LicenseKeyFile.Text, ErrorMessage) Then

                        AdvantageFramework.WinForm.MessageBox.Show("License key imported successfully.")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                ElseIf _LicenseFileType = LicenseFileType.Comscore Then

                    If AdvantageFramework.Security.LicenseKey.ImportComscoreLicenseKey(Me.Session, TextBoxForm_LicenseKeyFile.Text, ErrorMessage, Remove) Then

                        If Remove Then

                            LabelCurrectComscore_ClientIDValue.Text = "Not Licensed"

                        Else

                            LabelCurrectComscore_ClientIDValue.Text = "Licensed"

                        End If

                        AdvantageFramework.WinForm.MessageBox.Show("License key imported successfully.")

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

        End Sub
        Private Sub TextBoxForm_LicenseKeyFile_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxForm_LicenseKeyFile.TextChanged

            TextBoxForm_LicenseKeyFile.Validate("")

        End Sub
        Private Sub TextBoxForm_LicenseKeyFile_TagObjectChanged() Handles TextBoxForm_LicenseKeyFile.TagObjectChanged

            'objects
            Dim LicenseKey As String = ""
            Dim EncryptedLicenseKey As String = ""
            Dim ReadFile As Boolean = False
            Dim FileInfo As System.IO.FileInfo = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim DatabaseDetail As AdvantageFramework.Database.MasterDatabase.Entities.DatabaseDetail = Nothing
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
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim LicenseKeyFileExpireDate As Date = Nothing
            Dim ServerDate As Date = Nothing
            Dim ComscoreClientID As String = Nothing
            Dim ErrorMessage As String = String.Empty

            If TextBoxForm_LicenseKeyFile.Tag IsNot Nothing AndAlso TypeOf TextBoxForm_LicenseKeyFile.Tag Is System.IO.FileInfo Then

                FileInfo = TextBoxForm_LicenseKeyFile.Tag

                If FileInfo IsNot Nothing Then

                    If FileInfo.Name.ToUpper.StartsWith("COMSCORE") Then

                        _LicenseFileType = LicenseFileType.Comscore
                        PanelForm_ComscoreLicenseInfo.Visible = True
                        PanelForm_LicenseKeyInformation.Visible = False

                    Else

                        _LicenseFileType = LicenseFileType.Advantage
                        PanelForm_LicenseKeyInformation.Visible = True
                        PanelForm_ComscoreLicenseInfo.Visible = False

                    End If

                    Try

                        EncryptedLicenseKey = FileInfo.OpenText.ReadToEnd

                        ReadFile = True

                    Catch ex As Exception
                        ReadFile = False
                    End Try

                    If ReadFile AndAlso _LicenseFileType = LicenseFileType.Advantage Then

                        LicenseKey = AdvantageFramework.Security.LicenseKey.Read(EncryptedLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires,
                                                                                 PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, 0,
                                                                                 MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool, ErrorMessage)

                        LabelSelectedLicenseKeyFileInformation_AgencyName.Text = AgencyName.Trim
                        LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Text = IIf(ClientPortalUsersQuantity = -1, "Unlimited", ClientPortalUsersQuantity)
                        LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Text = IIf(WVOnlyUsersQuantity = -1, "Unlimited", WVOnlyUsersQuantity)
                        LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Text = IIf(PowerUsersQuantity = -1, "Unlimited", PowerUsersQuantity)
                        LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Text = IIf(MediaToolsUsersQuantity = -1, "Unlimited", MediaToolsUsersQuantity)
                        LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Text = IIf(APIUsersQuantity = -1, "Unlimited", APIUsersQuantity)
                        LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Text = IIf(EnableProofingTool = True, "Yes", "No")

                    ElseIf ReadFile AndAlso _LicenseFileType = LicenseFileType.Comscore Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                                Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSCORE_AS_CLIENT_ID.ToString)

                            End Using

                            Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                        End Using

                        If Agency IsNot Nothing Then

                            LabelCurrectComscore_AgencyName.Text = Agency.Name

                        End If

                        If Setting IsNot Nothing AndAlso Not String.IsNullOrWhiteSpace(Setting.Value) Then

                            LabelCurrectComscore_ClientIDValue.Text = "Licensed"

                        Else

                            LabelCurrectComscore_ClientIDValue.Text = "Not Licensed"

                        End If

                        LicenseKey = AdvantageFramework.Security.LicenseKey.ComscoreRead(EncryptedLicenseKey, AgencyName, ComscoreClientID)

                        LabelComscoreSelected_AgencyName.Text = AgencyName
                        LabelComscoreSelected_ComscoreIDValue.Text = "Licensed"

                    End If

                End If

            Else

                LabelSelectedLicenseKeyFileInformation_AgencyName.Text = ""
                LabelSelectedLicenseKeyFileInformation_ClientPortalLicenseQuantityAmount.Text = ""
                LabelSelectedLicenseKeyFileInformation_WebvantageOnlyLicenseQuantityAmount.Text = ""
                LabelSelectedLicenseKeyFileInformation_PowerLicenseQuantityAmount.Text = ""
                LabelSelectedLicenseKeyFileInformation_MediaToolsLicenseQuantityAmount.Text = ""
                LabelSelectedLicenseKeyFileInformation_APILicenseQuantityAmount.Text = ""
                LabelSelectedLicenseKeyFileInformation_ProofingEnabledYesNo.Text = ""

                LabelComscoreSelected_AgencyName.Text = ""
                LabelComscoreSelected_ComscoreIDValue.Text = "Not Licensed"

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
