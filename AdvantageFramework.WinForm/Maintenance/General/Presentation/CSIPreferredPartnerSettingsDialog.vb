Namespace Maintenance.General.Presentation

    Public Class CSIPreferredPartnerSettingsDialog

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


        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim CSIPreferredPartnerSettingsDialog As AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerSettingsDialog = Nothing

            CSIPreferredPartnerSettingsDialog = New AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerSettingsDialog()

            ShowFormDialog = CSIPreferredPartnerSettingsDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CSIPreferredPartnerSettingsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.CSIPreferredPartner.HasAgreementBeenSigned(DbContext, DataContext) Then

                        ButtonItemActions_SignUp.Image = AdvantageFramework.My.Resources.CSIPreferredPartnerUnsubscribeImage

                        ButtonItemActions_SignUp.Text = "Unsubscribe"

                        AdvantageFramework.CSIPreferredPartner.LoadSignedByInformation(DbContext, DataContext, LabelForm_SignedData.Text, LabelForm_ByData.Text)

                    Else

                        ButtonItemActions_SignUp.Image = AdvantageFramework.My.Resources.CSIPreferredPartnerSignUpImage

                        ButtonItemActions_SignUp.Text = "Sign Up"

                    End If

                    If String.IsNullOrWhiteSpace(LabelForm_SignedData.Text) Then

                        LabelForm_SignedData.Text = "Has not been signed."

                    End If

                    If String.IsNullOrWhiteSpace(LabelForm_ByData.Text) Then

                        LabelForm_ByData.Text = "Has not been signed."

                    End If

                End Using

            End Using

        End Sub
        Private Sub CSIPreferredPartnerSettingsDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

            Me.Refresh()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_SignUp_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_SignUp.Click

            'objects
            Dim ErrorMessage As String = ""
            Dim AgreementSigned As Boolean = False
            Dim Setting As AdvantageFramework.Database.Entities.Setting = Nothing

            If ButtonItemActions_SignUp.Text = "Unsubscribe" Then

                ButtonItemActions_SignUp.Image = AdvantageFramework.My.Resources.CSIPreferredPartnerSignUpImage

                ButtonItemActions_SignUp.Text = "Sign Up"

                LabelForm_SignedData.Text = "Has not been signed."
                LabelForm_ByData.Text = "Has not been signed."

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED.ToString)

                        If Setting IsNot Nothing Then

                            Setting.Value = Nothing

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.ADV_CLIENT_CODE.ToString)

                        If Setting IsNot Nothing Then

                            Setting.Value = Nothing

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_DATE.ToString)

                        If Setting IsNot Nothing Then

                            Setting.Value = Nothing

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                        Setting = AdvantageFramework.Database.Procedures.Setting.LoadBySettingCode(DataContext, AdvantageFramework.Agency.Settings.CSI_PP_SIGNED_EMP.ToString)

                        If Setting IsNot Nothing Then

                            Setting.Value = Nothing

                            AdvantageFramework.Database.Procedures.Setting.Update(DataContext, Setting)

                        End If

                    End Using

                End Using

            Else

                If AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerAgreementDialog.ShowFormDialog() = Windows.Forms.DialogResult.OK Then

                    Me.ShowWaitForm("Sending...")

                    Try

                        AgreementSigned = AdvantageFramework.CSIPreferredPartner.SignAgreement(Me.Session, ErrorMessage)

                    Catch ex As Exception
                        ErrorMessage = "Failed signing agreement. Please contact Software Support."
                    End Try

                    Me.CloseWaitForm()

                    If AgreementSigned Then

                        ButtonItemActions_SignUp.Image = AdvantageFramework.My.Resources.CSIPreferredPartnerUnsubscribeImage

                        ButtonItemActions_SignUp.Text = "Unsubscribe"

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                AdvantageFramework.CSIPreferredPartner.LoadSignedByInformation(DbContext, DataContext, LabelForm_SignedData.Text, LabelForm_ByData.Text)

                            End Using

                        End Using

                    Else

                        If ErrorMessage = "" Then

                            ErrorMessage = "Failed signing agreement. Please contact Software Support."

                        End If

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                    End If

                End If

            End If

            RibbonBarOptions_Actions.ResetCachedContentSize()

            RibbonBarOptions_Actions.Refresh()

            RibbonBarOptions_Actions.Width = RibbonBarOptions_Actions.GetAutoSizeWidth

            RibbonBarOptions_Actions.Refresh()

            Me.Refresh()

        End Sub

#End Region

#End Region

    End Class

End Namespace