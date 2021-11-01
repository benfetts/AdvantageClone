Partial Public Class PasswordPolicyPage
    Inherits BaseWizardPage

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

        InitializeComponent()

    End Sub
    Public Sub Save()

        SimpleButtonSave.PerformClick()

    End Sub

#Region "  Show Form Methods "



#End Region

#Region "  Form Event Handlers "



#End Region

#Region "  Control Event Handlers "

    Private Sub CheckEditPasswordComplexityRequired_CheckedChanged(sender As Object, e As EventArgs) Handles CheckEditPasswordComplexityRequired.CheckedChanged

        CheckEditUppercaseRequired.Enabled = CheckEditPasswordComplexityRequired.Checked
        CheckEditLowercaseRequired.Enabled = CheckEditPasswordComplexityRequired.Checked
        CheckEditNumberRequired.Enabled = CheckEditPasswordComplexityRequired.Checked
        CheckEditSpecialCharacterRequired.Enabled = CheckEditPasswordComplexityRequired.Checked

    End Sub
    Private Sub SimpleButtonSave_Click(sender As Object, e As System.EventArgs) Handles SimpleButtonSave.Click

        Dim Saved As Boolean = False
        Dim ErrorMessage As String = String.Empty
        Dim AgySettingsAppID As Integer = 10
        Dim DbContextTransaction As System.Data.Entity.DbContextTransaction = Nothing
        Dim OverlaySplayScreenHandle As DevExpress.XtraSplashScreen.IOverlaySplashScreenHandle = Nothing

        OverlaySplayScreenHandle = DevExpress.XtraSplashScreen.SplashScreenManager.ShowOverlayForm(Me)

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.WizardViewModel.WizardInputs.ConnectionString, "")

            SecurityDbContext.Database.Connection.Open()

            DbContextTransaction = SecurityDbContext.Database.BeginTransaction

            Try

                If SecurityDbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM AGY_SETTINGS_APP WHERE AGY_SETTINGS_APP = {0}", AgySettingsAppID)).First = 0 Then

                    SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS_APP WITH(ROWLOCK) (AGY_SETTINGS_APP, APP_DESC) VALUES ({0}, 'Password Settings')", AgySettingsAppID))

                End If

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM AGY_SETTINGS_TAB WHERE AGY_SETTINGS_APP = {0}", AgySettingsAppID))
                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS_TAB (AGY_SETTINGS_APP, AGY_SETTINGS_TAB, TAB_DESC) VALUES ({0}, 1, 'Settings')", AgySettingsAppID))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM dbo.AGY_SETTINGS WHERE AGY_SETTINGS_CODE IN ('PWD_CXT_LC','PWD_CXT_NUM','PWD_CXT_REQ','PWD_CXT_UC','PWD_HIST_CT','PWD_MIN_LEN','PWD_XST_SPL')"))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
                                                                            VALUES ('PWD_MIN_LEN', 'Minimum password length', {1}, 0, 1, {0}, 1, 20)", AgySettingsAppID, SpinEditMinPasswordLength.EditValue))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_MIN, AGY_SETTINGS_MAX, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_HIST_CT', 'Password history', {1}, 0, 0, 24, 7, {0}, 1, 20)", AgySettingsAppID, SpinEditCheckPreviousPasswordHistoryCount.EditValue))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_CXT_REQ', 'Password complexity required', {1}, 0, 2, {0}, 1, 16)", AgySettingsAppID, If(CheckEditPasswordComplexityRequired.Checked, 1, 0)))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_CXT_UC', 'Uppercase', {1}, 0, 3, {0}, 1, 16)", AgySettingsAppID, If(CheckEditUppercaseRequired.Checked, 1, 0)))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_CXT_LC', 'Lowercase', {1}, 0, 4, {0}, 1, 16)", AgySettingsAppID, If(CheckEditLowercaseRequired.Checked, 1, 0)))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_CXT_NUM', 'Number', {1}, 0, 5, {0}, 1, 16)", AgySettingsAppID, If(CheckEditNumberRequired.Checked, 1, 0)))

                SecurityDbContext.Database.ExecuteSqlCommand(String.Format("INSERT INTO AGY_SETTINGS WITH(ROWLOCK) (AGY_SETTINGS_CODE, AGY_SETTINGS_DESC, AGY_SETTINGS_VALUE, AGY_SETTINGS_DEF, AGY_SETTINGS_ORDER, AGY_SETTINGS_APP, AGY_SETTINGS_TAB, DTYPE_ID)
										                                    VALUES ('PWD_XST_SPL', 'Special Character', {1}, 0, 6, {0}, 1, 16)", AgySettingsAppID, If(CheckEditSpecialCharacterRequired.Checked, 1, 0)))

                DbContextTransaction.Commit()

                Saved = True

            Catch ex As Exception

                DbContextTransaction.Rollback()

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                End If

                ErrorMessage &= System.Environment.NewLine & "Failed saving password policies. Please contact software support."

            End Try

        End Using

        DevExpress.XtraSplashScreen.SplashScreenManager.CloseOverlayForm(OverlaySplayScreenHandle)

        If Saved Then

            CType(PageViewModel, PasswordPolicyPageViewModel).SetIsComplete(True)

            Me.WizardViewModel.PageCompleted()

        Else

            If CType(Me.WizardViewModel, WizardViewModel).HandsFreeMode Then

                CType(Me.WizardViewModel, WizardViewModel).AddToErrors("PasswordPolicyPage", ErrorMessage)

                CType(Me.WizardViewModel.View.Documents(9).Control, ConversionPage).SetupSkipConversion()
                CType(Me.WizardViewModel.Pages(9), ConversionPageViewModel).SetIsComplete(True)

                CType(PageViewModel, PasswordPolicyPageViewModel).SetIsComplete(True)

                Me.WizardViewModel.GoToPage(10)

            Else

                DevExpress.XtraEditors.XtraMessageBox.Show(ErrorMessage)

            End If

        End If

    End Sub

#End Region

#End Region

End Class
