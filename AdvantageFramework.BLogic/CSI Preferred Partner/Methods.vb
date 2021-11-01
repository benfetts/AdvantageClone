Namespace CSIPreferredPartner

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enums "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function SaveUserNameAndPassword(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal UserName As String, ByVal Password As String) As Boolean

            'objects
            Dim UserNameSaved As Boolean = False
            Dim PasswordSaved As Boolean = False
            Dim UserNameSetting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim PasswordSetting As AdvantageFramework.Database.Entities.Setting = Nothing

            UserNameSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_USER.ToString)

            If UserNameSetting IsNot Nothing Then

                UserNameSetting.Value = UserName

                UserNameSaved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, UserNameSetting)

            End If

            PasswordSetting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_PW.ToString)

            If PasswordSetting IsNot Nothing Then

                PasswordSetting.Value = AdvantageFramework.Security.Encryption.Encrypt(Password)

                PasswordSaved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, PasswordSetting)

            End If

            SaveUserNameAndPassword = (UserNameSaved AndAlso PasswordSaved)

        End Function
        Public Sub LoadSignedByInformation(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByRef SignedDate As String, ByRef SignedBy As String)

            'objects
            Dim AgreementHasBeenSigned As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SettingValue As String = ""
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_DATE.ToString)

            If Setting IsNot Nothing Then

                SignedDate = Setting.Value

            End If

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_EMP.ToString)

            If Setting IsNot Nothing Then

                SettingValue = Setting.Value

                Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, SettingValue)

                If Employee IsNot Nothing Then

                    SignedBy = Employee.ToString

                End If

            End If

        End Sub
        Public Function HasAgreementBeenSigned(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext) As Boolean

            'objects
            Dim AgreementHasBeenSigned As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim SettingValue As String = ""

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED.ToString)

            If Setting IsNot Nothing Then

                If IsNothing(Setting.Value) = False AndAlso IsDBNull(Setting.Value) = False Then

                    Try

                        SettingValue = Setting.Value

                    Catch ex As Exception
                        SettingValue = ""
                    End Try

                    If AdvantageFramework.Security.Encryption.Decrypt(SettingValue) = AdvantageFramework.Agency.Settings.CSI_PP_SIGNED.ToString Then

                        AgreementHasBeenSigned = True

                    End If

                End If

            End If

            HasAgreementBeenSigned = AgreementHasBeenSigned

        End Function
        Public Function HasAgreementBeenSigned(ByVal Session As AdvantageFramework.Security.Session) As Boolean

            'objects
            Dim AgreementHasBeenSigned As Boolean = False

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AgreementHasBeenSigned = HasAgreementBeenSigned(DbContext, DataContext)

                End Using

            End Using

            HasAgreementBeenSigned = AgreementHasBeenSigned

        End Function
        Public Function SignAgreement(ByVal Session As AdvantageFramework.Security.Session, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim AgreementHasBeenSigned As Boolean = False
            Dim LicenseKey As String = ""
            Dim EmployeeName As String = ""
            Dim AgencyLicenseKey As String = ""
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
            Dim DatabaseID As Integer = 0
            'Dim CSIPreferredPartner As AdvantageFramework.CSIPreferredPartner.CSIPreferredPartner = Nothing
            'Dim AgreementSignedResponse As AdvantageFramework.CSIPreferredPartner.AgreementSignedResponse = Nothing
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            'Try

            '	System.Net.ServicePointManager.ServerCertificateValidationCallback = New System.Net.Security.RemoteCertificateValidationCallback(AddressOf ValidateRemoteCertificate)

            'Catch ex As Exception

            'End Try

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    AgencyLicenseKey = AdvantageFramework.Database.Procedures.Agency.LoadLicenseKey(DbContext)

                    If AgencyLicenseKey <> "" Then

                        AdvantageFramework.Security.LicenseKey.Read(AgencyLicenseKey, LicenseKeyDate, DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity,
                                                                    WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, DatabaseID, MediaToolsUsersQuantity,
                                                                    APIUsersQuantity, EnableProofingTool, ErrorMessage)

                        LicenseKey = AdvantageFramework.Security.LicenseKey.Create(DaysUntilFileExpires, DaysUntilKeyExpires, PowerUsersQuantity, WVOnlyUsersQuantity, ClientPortalUsersQuantity, AgencyName, 0, MediaToolsUsersQuantity, APIUsersQuantity, EnableProofingTool)

                        EmployeeName = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, Session.User.EmployeeCode).ToString

                        'CSIPreferredPartner = New AdvantageFramework.CSIPreferredPartner.CSIPreferredPartner

                        'AgreementSignedResponse = CSIPreferredPartner.SignAgreement(LicenseKey, Session.UserCode, Session.User.EmployeeCode, EmployeeName)

                        'If AgreementSignedResponse IsNot Nothing Then

                        '	If AgreementSignedResponse.Signed Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED.ToString)

                            If Setting IsNot Nothing Then

                                Setting.Value = AdvantageFramework.Security.Encryption.Encrypt(AdvantageFramework.Agency.Settings.CSI_PP_SIGNED.ToString)

                                AgreementHasBeenSigned = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                            End If

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.ADV_CLIENT_CODE.ToString)

                            If Setting IsNot Nothing Then

                                Setting.Value = AgencyName

                                AgreementHasBeenSigned = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                            End If

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_DATE.ToString)

                            If Setting IsNot Nothing Then

                                Setting.Value = Now.ToShortDateString & " " & Now.ToShortTimeString

                                AgreementHasBeenSigned = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                            End If

                            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_EMP.ToString)

                            If Setting IsNot Nothing Then

                                Setting.Value = Session.User.EmployeeCode

                                AgreementHasBeenSigned = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                            End If

                        End Using


                        '		Else

                        '			AgreementHasBeenSigned = False
                        '			ErrorMessage = AgreementSignedResponse.ErrorMessage

                        '		End If

                        '	Else

                        '		AgreementHasBeenSigned = False
                        '		ErrorMessage = "Failed to connect with Advantage servers to sign the agreement."

                        '	End If

                    Else

                        AgreementHasBeenSigned = False
                        ErrorMessage = "No license key on file."

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = ex.Message
            End Try

            SignAgreement = AgreementHasBeenSigned

        End Function
        Private Function ValidateRemoteCertificate(sender As Object, certificate As System.Security.Cryptography.X509Certificates.X509Certificate, chain As System.Security.Cryptography.X509Certificates.X509Chain, sslPolicyErrors As System.Net.Security.SslPolicyErrors)

            ValidateRemoteCertificate = True

        End Function
        Public Function LoadClearedChecksImportPath(ByVal DataContext As AdvantageFramework.Database.DataContext) As String

            'objects
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing
            Dim ClearedChecksImportPath As String = ""

            Try

                If DataContext IsNot Nothing Then

                    Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_IMPORT_PATH.ToString)

                    If Setting IsNot Nothing Then

                        ClearedChecksImportPath = Setting.Value

                    End If

                End If

            Catch ex As Exception
                ClearedChecksImportPath = ""
            End Try

            LoadClearedChecksImportPath = ClearedChecksImportPath

        End Function
        Public Function SaveClearedChecksImportPath(ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal ClearedChecksImportPath As String) As Boolean

            'objects
            Dim ClearedChecksImportPathSaved As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_IMPORT_PATH.ToString)

            If Setting IsNot Nothing Then

                Setting.Value = ClearedChecksImportPath

                ClearedChecksImportPathSaved = AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

            End If

            SaveClearedChecksImportPath = ClearedChecksImportPathSaved

        End Function

#End Region

    End Module

End Namespace
