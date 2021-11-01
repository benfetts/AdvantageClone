Partial Public Class ConversionPage
    Inherits BaseWizardPage

#Region " Constants "

    Private Const DropSIDFunction As String = "IF EXISTS(SELECT SPECIFIC_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE SPECIFIC_NAME = 'fn_SIDToString' AND ROUTINE_TYPE = 'FUNCTION') BEGIN

	DROP FUNCTION [dbo].[fn_SIDToString]

END"

    Private Const CreateSIDFunction As String = "CREATE FUNCTION [dbo].[fn_SIDToString]
(
  @BinSID AS VARBINARY(100)
)
RETURNS VARCHAR(100)
AS BEGIN

  IF LEN(@BinSID) % 4 <> 0 RETURN(NULL)

  DECLARE @StringSID VARCHAR(100)
  DECLARE @i AS INT
  DECLARE @j AS INT

  SELECT @StringSID = 'S-'
     + CONVERT(VARCHAR, CONVERT(INT, CONVERT(VARBINARY, SUBSTRING(@BinSID, 1, 1)))) 
  SELECT @StringSID = @StringSID + '-'
     + CONVERT(VARCHAR, CONVERT(INT, CONVERT(VARBINARY, SUBSTRING(@BinSID, 3, 6))))

  SET @j = 9
  SET @i = LEN(@BinSID)

  WHILE @j < @i
  BEGIN
    DECLARE @val BINARY(4)
    SELECT @val = SUBSTRING(@BinSID, @j, 4)
    SELECT @StringSID = @StringSID + '-'
      + CONVERT(VARCHAR, CONVERT(BIGINT, CONVERT(VARBINARY, REVERSE(CONVERT(VARBINARY, @val))))) 
    SET @j = @j + 4
  END
  RETURN ( @StringSID ) 
END"


#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _SkipConversion As Boolean = False

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Public Sub New()

        InitializeComponent()

    End Sub
    Public Sub Convert()

        SimpleButtonForm_Convert.PerformClick()

    End Sub
    Public Sub SetupSkipConversion()

        SimpleButtonForm_Convert.Text = "Conversion Already Completed!  Please click next to continue!"
        SimpleButtonForm_Convert.Enabled = False
        _SkipConversion = True

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub SimpleButtonForm_Convert_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonForm_Convert.Click

        Dim Converted As Boolean = False
        Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing
        Dim SQL As String = String.Empty
        Dim ErrorMessage As String = String.Empty
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing
        Dim AgencySettingCode As String = String.Empty
        Dim ErrorDroppingUser As Boolean = False
        Dim DBUserName As String = String.Empty
        Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
        Dim EmployeeEmailPassword As String = String.Empty
        Dim EmployeeConceptSharePassword As String = String.Empty
        Dim EmployeeIsAPIUser As String = String.Empty
        Dim UserIsMediaToolsUser As String = String.Empty
        Dim CPConceptSharePassword As String = String.Empty
        Dim CSCORE_CLIENT_ID As String = String.Empty
        Dim CSCORE_CLIENT_SECRET As String = String.Empty
        Dim CSCORE_AS_CLIENT_ID As String = String.Empty
        Dim CSI_PP_SIGNED As String = String.Empty
        Dim CSI_PP_PW As String = String.Empty
        Dim SID As String = String.Empty

        If _SkipConversion = False Then

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                DbContext.Database.Connection.Open()

                DbContextTransaction = DbContext.Database.BeginTransaction

                OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

                Try

                    SQL = "IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SEC_USER' AND COLUMN_NAME = 'PASSWORD') BEGIN

	                            ALTER TABLE [dbo].[SEC_USER] ADD [PASSWORD] [varchar](MAX) NOT NULL DEFAULT('')
	
                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'SEC_USER' AND COLUMN_NAME = 'SID') BEGIN

	                            ALTER TABLE [dbo].[SEC_USER] ADD [SID] [varchar](MAX) NOT NULL DEFAULT('')
	
                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'EMPLOYEE_CLOAK' AND COLUMN_NAME = 'EMAIL_PWD') BEGIN

	                            ALTER TABLE [dbo].[EMPLOYEE_CLOAK] ALTER COLUMN [EMAIL_PWD] varchar(MAX) NULL

                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'DOC_REPOSITORY_USER_PASSWORD') BEGIN

	                            ALTER TABLE [dbo].[AGENCY] ALTER COLUMN [DOC_REPOSITORY_USER_PASSWORD] varchar(MAX) NULL

                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'EMAIL_PWD') BEGIN

	                            ALTER TABLE [dbo].[AGENCY] ALTER COLUMN [EMAIL_PWD] varchar(MAX) NULL

                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF NOT EXISTS (SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGENCY' AND COLUMN_NAME = 'PROOFING_URL') BEGIN

	                            ALTER TABLE AGENCY ADD PROOFING_URL VARCHAR(256) NULL
	
                           END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "EXEC [dbo].[advsp_sql_column_prepare] 'AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT', 'PASSWORD'"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT' AND COLUMN_NAME = 'PASSWORD') BEGIN

	                            ALTER TABLE [dbo].[AGY_POP3_AUTOMATED_ASSIGNMENT_ACCOUNT] ALTER COLUMN [PASSWORD] varchar(MAX) NOT NULL
	
                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "EXEC [dbo].[advsp_sql_column_prepare] 'AGY_POP3_ACCOUNT', 'PASSWORD'"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    SQL = "IF EXISTS(SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = 'AGY_POP3_ACCOUNT' AND COLUMN_NAME = 'PASSWORD') BEGIN

	                            ALTER TABLE [dbo].[AGY_POP3_ACCOUNT] ALTER COLUMN [PASSWORD] varchar(MAX) NULL
	
                            END"

                    DbContext.Database.ExecuteSqlCommand(SQL)

                    Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                    If String.IsNullOrWhiteSpace(Agency.POP3Password) = False Then

                        'Agency.POP3Password = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(Agency.POP3Password)
                        Agency.POP3Password = AdvantageFramework.Security.Encryption.Encrypt(Agency.POP3Password)

                    End If

                    If String.IsNullOrWhiteSpace(Agency.EmailPassword) = False Then

                        'Agency.EmailPassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(Agency.EmailPassword)
                        Agency.EmailPassword = AdvantageFramework.Security.Encryption.Encrypt(Agency.EmailPassword)

                    End If

                    If String.IsNullOrWhiteSpace(Agency.FileSystemPassword) = False Then

                        Agency.FileSystemPassword = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt(Agency.FileSystemPassword)
                        Agency.FileSystemPassword = AdvantageFramework.Security.Encryption.Encrypt(Agency.FileSystemPassword)

                    End If

                    AdvantageFramework.Database.Procedures.Agency.Update(DbContext, Agency)

                    For Each POP3EmailListenerAccount In AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.Load(DbContext).ToList

                        If String.IsNullOrWhiteSpace(POP3EmailListenerAccount.Password) = False Then

                            'POP3EmailListenerAccount.Password = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(POP3EmailListenerAccount.Password)
                            POP3EmailListenerAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3EmailListenerAccount.Password)

                            AdvantageFramework.Database.Procedures.POP3EmailListenerAccount.Update(DbContext, POP3EmailListenerAccount)

                        End If

                    Next

                    For Each POP3AutomatedAssignmentAccount In AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Load(DbContext).ToList

                        If String.IsNullOrWhiteSpace(POP3AutomatedAssignmentAccount.Password) = False Then

                            'POP3AutomatedAssignmentAccount.Password = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(POP3AutomatedAssignmentAccount.Password)
                            POP3AutomatedAssignmentAccount.Password = AdvantageFramework.Security.Encryption.Encrypt(POP3AutomatedAssignmentAccount.Password)

                            AdvantageFramework.Database.Procedures.POP3AutomatedAssignmentAccount.Update(DbContext, POP3AutomatedAssignmentAccount)

                        End If

                    Next

                    For Each EmployeeCode In AdvantageFramework.Database.Procedures.EmployeeView.Load(DbContext).Select(Function(Entity) Entity.Code).ToList

                        EmployeeCode = EmployeeCode.Replace("'", "''")

                        EmployeeEmailPassword = String.Empty
                        EmployeeConceptSharePassword = String.Empty
                        EmployeeIsAPIUser = String.Empty

                        EmployeeEmailPassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(EMAIL_PWD, '') FROM dbo.EMPLOYEE WHERE EMP_CODE = '{0}'", EmployeeCode)).FirstOrDefault

                        If String.IsNullOrWhiteSpace(EmployeeEmailPassword) = False Then

                            'EmployeeEmailPassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(EmployeeEmailPassword)
                            EmployeeEmailPassword = AdvantageFramework.Security.Encryption.Encrypt(EmployeeEmailPassword)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET EMAIL_PWD = '{0}' WHERE EMP_CODE = '{1}'", EmployeeEmailPassword, EmployeeCode))

                        End If

                        EmployeeConceptSharePassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CS_PASSWORD, '') FROM dbo.EMPLOYEE WHERE EMP_CODE = '{0}'", EmployeeCode)).FirstOrDefault

                        If String.IsNullOrWhiteSpace(EmployeeConceptSharePassword) = False Then

                            EmployeeConceptSharePassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(EmployeeConceptSharePassword)
                            EmployeeConceptSharePassword = AdvantageFramework.Security.Encryption.Encrypt(EmployeeConceptSharePassword)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET CS_PASSWORD = '{0}' WHERE EMP_CODE = '{1}'", EmployeeConceptSharePassword, EmployeeCode))

                        End If

                        EmployeeIsAPIUser = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(IS_API_USER, '') FROM dbo.EMPLOYEE WHERE EMP_CODE = '{0}'", EmployeeCode)).FirstOrDefault

                        If String.IsNullOrWhiteSpace(EmployeeIsAPIUser) = False Then

                            EmployeeIsAPIUser = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(EmployeeIsAPIUser)
                            EmployeeIsAPIUser = AdvantageFramework.Security.Encryption.Encrypt(EmployeeIsAPIUser)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.EMPLOYEE SET IS_API_USER = '{0}' WHERE EMP_CODE = '{1}'", EmployeeIsAPIUser, EmployeeCode))

                        End If

                    Next

                    For Each UserID In DbContext.Database.SqlQuery(Of Integer)("SELECT SEC_USER_ID FROM dbo.SEC_USER").ToList

                        UserIsMediaToolsUser = String.Empty

                        UserIsMediaToolsUser = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(STRING_VALUE, '') FROM dbo.SEC_USER_SETTING WHERE SEC_USER_ID = {0} AND SETTING_CODE = 'IsMediaToolsUser'", UserID)).FirstOrDefault

                        If String.IsNullOrWhiteSpace(UserIsMediaToolsUser) = False Then

                            UserIsMediaToolsUser = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(UserIsMediaToolsUser)
                            UserIsMediaToolsUser = AdvantageFramework.Security.Encryption.Encrypt(UserIsMediaToolsUser)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_SETTING SET STRING_VALUE = '{0}' WHERE SEC_USER_ID = {1} AND SETTING_CODE = 'IsMediaToolsUser'", UserIsMediaToolsUser, UserID))

                        End If

                    Next

                    For Each CPUserGuid In DbContext.Database.SqlQuery(Of Guid)("SELECT USER_GUID FROM dbo.CP_USER").ToList

                        CPConceptSharePassword = String.Empty

                        CPConceptSharePassword = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CS_PASSWORD, '') FROM dbo.CP_USER WHERE USER_GUID = '{0}'", CPUserGuid)).FirstOrDefault

                        If String.IsNullOrWhiteSpace(CPConceptSharePassword) = False Then

                            CPConceptSharePassword = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(CPConceptSharePassword)
                            CPConceptSharePassword = AdvantageFramework.Security.Encryption.Encrypt(CPConceptSharePassword)

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.CP_USER SET CS_PASSWORD = '{0}' WHERE USER_GUID = '{1}'", CPConceptSharePassword, CPUserGuid))

                        End If

                    Next

                    CSCORE_CLIENT_ID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_ID'").FirstOrDefault

                    If String.IsNullOrWhiteSpace(CSCORE_CLIENT_ID) = False Then

                        CSCORE_CLIENT_ID = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt(CSCORE_CLIENT_ID)
                        CSCORE_CLIENT_ID = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_ID)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}'  WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_ID'", CSCORE_CLIENT_ID))

                    End If

                    CSCORE_CLIENT_SECRET = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_SECRET'").FirstOrDefault

                    If String.IsNullOrWhiteSpace(CSCORE_CLIENT_SECRET) = False Then

                        CSCORE_CLIENT_SECRET = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt(CSCORE_CLIENT_SECRET)
                        CSCORE_CLIENT_SECRET = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_CLIENT_SECRET)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}'  WHERE AGY_SETTINGS_CODE = 'CSCORE_CLIENT_SECRET'", CSCORE_CLIENT_SECRET))

                    End If

                    CSCORE_AS_CLIENT_ID = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSCORE_AS_CLIENT_ID'").FirstOrDefault

                    If String.IsNullOrWhiteSpace(CSCORE_AS_CLIENT_ID) = False Then

                        CSCORE_AS_CLIENT_ID = AdvantageFramework.Security.Encryption.RijndaelSimpleDecrypt(CSCORE_AS_CLIENT_ID)
                        CSCORE_AS_CLIENT_ID = AdvantageFramework.Security.Encryption.Encrypt(CSCORE_AS_CLIENT_ID)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}'  WHERE AGY_SETTINGS_CODE = 'CSCORE_AS_CLIENT_ID'", CSCORE_AS_CLIENT_ID))

                    End If

                    CSI_PP_SIGNED = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSI_PP_SIGNED'").FirstOrDefault

                    If String.IsNullOrWhiteSpace(CSI_PP_SIGNED) = False Then

                        CSI_PP_SIGNED = AdvantageFramework.Security.Encryption.DecryptOld_DONOTUSE(CSI_PP_SIGNED)
                        CSI_PP_SIGNED = AdvantageFramework.Security.Encryption.Encrypt(CSI_PP_SIGNED)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}' WHERE AGY_SETTINGS_CODE = 'CSI_PP_SIGNED'", CSI_PP_SIGNED))

                    End If

                    CSI_PP_PW = DbContext.Database.SqlQuery(Of String)("SELECT ISNULL(AGY_SETTINGS_VALUE, '') FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'CSI_PP_PW'").FirstOrDefault

                    If String.IsNullOrWhiteSpace(CSI_PP_PW) = False Then

                        CSI_PP_PW = AdvantageFramework.Security.Encryption.ASCIIDecoding(CSI_PP_PW)
                        CSI_PP_PW = AdvantageFramework.Security.Encryption.Encrypt(CSI_PP_PW)

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = '{0}' WHERE AGY_SETTINGS_CODE = 'CSI_PP_PW'", CSI_PP_PW))

                    End If

                    For Each UserAuth In DbContext.Database.SqlQuery(Of UserAuth)("SELECT [ID] = [SEC_AUTH_ID], [Password] = [PWD_D] FROM dbo.SEC_USER_AUTH").ToList

                        If String.IsNullOrWhiteSpace(UserAuth.Password) = False Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER_AUTH SET PWD_D = '{0}' WHERE SEC_AUTH_ID = {1}", AdvantageFramework.Security.Encryption.EncryptPassword(UserAuth.Password), UserAuth.ID))

                        End If

                    Next

                    DbContext.SaveChanges()

                    Converted = True

                Catch ex As Exception

                    ErrorMessage = ex.Message

                    If ex.InnerException IsNot Nothing Then

                        ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                        If ex.InnerException.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                        End If

                    End If

                End Try

                If Converted Then

                    DbContextTransaction.Commit()

                Else

                    DbContextTransaction.Rollback()

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                    If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            CType(Me.WizardViewModel, WizardViewModel).AddToErrors("ConversionPage", "Failed to convert advantage database.")

                        Else

                            CType(Me.WizardViewModel, WizardViewModel).AddToErrors("ConversionPage", "Failed to convert advantage database." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    Else

                        If String.IsNullOrWhiteSpace(ErrorMessage) Then

                            DevExpress.XtraEditors.XtraMessageBox.Show("Failed to convert advantage database.")

                        Else

                            DevExpress.XtraEditors.XtraMessageBox.Show("Failed to convert advantage database." & System.Environment.NewLine & System.Environment.NewLine & ErrorMessage)

                        End If

                    End If

                End If

                If Converted Then

                    Try

                        AgencySettingCode = DbContext.Database.SqlQuery(Of String)("SELECT AGY_SETTINGS_CODE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE = 'AUW_6700700'").FirstOrDefault()

                    Catch ex As Exception
                        AgencySettingCode = String.Empty
                    End Try

                    If String.IsNullOrWhiteSpace(AgencySettingCode) Then

                        DbContext.Database.ExecuteSqlCommand("INSERT INTO dbo.AGY_SETTINGS([AGY_SETTINGS_CODE],[AGY_SETTINGS_DESC], [AGY_SETTINGS_VALUE]) VALUES('AUW_6700700', '', 1)")

                    Else

                        DbContext.Database.ExecuteSqlCommand("UPDATE dbo.AGY_SETTINGS SET AGY_SETTINGS_VALUE = 1 WHERE AGY_SETTINGS_CODE = 'AUW_6700700'")

                    End If

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

                        AdvantageFramework.Agency.SaveEncryptedPasswordsPhase1(DataContext, True)

                    End Using

                    DbContext.Database.ExecuteSqlCommand(DropSIDFunction)

                    DbContext.Database.ExecuteSqlCommand(CreateSIDFunction)

                    For Each User In DbContext.Database.SqlQuery(Of User)("SELECT [ID] = [SEC_USER_ID], [UserName] = [USER_NAME] FROM dbo.SEC_USER").ToList

                        ErrorDroppingUser = False
                        DBUserName = String.Empty
                        SID = String.Empty

                        Try

                            If User.UserName.ToUpper <> Me.WizardViewModel.WizardInputs.AdvantageUserName.ToUpper Then

                                If User.UserName IsNot Nothing AndAlso User.UserName.Contains("\") Then

                                    Try

                                        SID = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT dbo.fn_SIDToString(sid) FROM sys.database_principals WHERE [name] = '{0}'", User.UserName)).FirstOrDefault

                                        If String.IsNullOrWhiteSpace(SID) = False Then

                                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.SEC_USER SET [SID] = '{0}' WHERE SEC_USER_ID = {1}", SID, User.ID))

                                        End If

                                    Catch ex As Exception

                                    End Try

                                End If

                                Try

                                    DbContext.Database.ExecuteSqlCommand(String.Format("DROP USER [{0}]", User.UserName))

                                Catch ex As Exception
                                    ErrorDroppingUser = True
                                End Try

                                If ErrorDroppingUser Then

                                    Try

                                        DBUserName = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT [name] FROM sys.database_principals WHERE UPPER([name]) = '{0}'", User.UserName.ToUpper)).FirstOrDefault()

                                    Catch ex As Exception
                                        DBUserName = String.Empty
                                    End Try

                                    If String.IsNullOrWhiteSpace(DBUserName) = False Then

                                        Try

                                            DbContext.Database.ExecuteSqlCommand(String.Format("DROP USER [{0}]", DBUserName))

                                        Catch ex As Exception

                                        End Try

                                    End If

                                End If

                            End If

                            'If UserName.ToUpper <> Me.WizardViewModel.WizardInputs.AdvantageUserName.ToUpper AndAlso
                            '        UserName.ToUpper <> Me.WizardViewModel.WizardInputs.UserName.ToUpper Then

                            '    Try

                            '        SecurityDbContext.Database.ExecuteSqlCommand(String.Format("USE master; DROP LOGIN [{0}]; USE {1};", UserName, Me.WizardViewModel.WizardInputs.Database))

                            '    Catch ex As Exception

                            '    End Try

                            'End If

                        Catch ex As Exception

                        End Try

                    Next

                    DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

                End If

            End Using

        Else

            Converted = True

        End If

        If Converted Then

            CType(PageViewModel, ConversionPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            System.Windows.Forms.Application.Exit()

        End If

    End Sub

#End Region

#End Region

    Public Class User

        Public Property ID As Integer
        Public Property UserName As String

    End Class
    Public Class UserAuth

        Public Property ID As Integer
        Public Property Password As String

    End Class

End Class
