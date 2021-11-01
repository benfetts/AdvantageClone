Namespace WinForm.Presentation.Controls

    Public Class Label
        Inherits DevComponents.DotNetBar.LabelX

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum MarkupLinks
            PowerUserConnected
            WVUserConnected
            CPUserConnected
            MediaToolsUsers
            APIUsers
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Sub New()

            Me.AutoSize = False
            Me.Size = New System.Drawing.Size(Me.Size.Width, 20)
            Me.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
            Me.BackColor = Drawing.Color.White
            Me.DoubleBuffered = True

        End Sub

#Region "  Control Event Handlers "

        Private Sub Label_MarkupLinkClick(sender As Object, e As DevComponents.DotNetBar.MarkupLinkClickEventArgs) Handles Me.MarkupLinkClick

            If e.Name = AdvantageFramework.WinForm.Presentation.Controls.Label.MarkupLinks.PowerUserConnected.ToString Then

                AdvantageFramework.WinForm.Presentation.ConnectedUsersDialog.ShowFormDialog(AdvantageFramework.Security.LicenseKey.Types.PowerUser)

            ElseIf e.Name = AdvantageFramework.WinForm.Presentation.Controls.Label.MarkupLinks.WVUserConnected.ToString Then

                AdvantageFramework.WinForm.Presentation.ConnectedUsersDialog.ShowFormDialog(AdvantageFramework.Security.LicenseKey.Types.WebvantageOnly)

            ElseIf e.Name = AdvantageFramework.WinForm.Presentation.Controls.Label.MarkupLinks.CPUserConnected.ToString Then

                AdvantageFramework.WinForm.Presentation.ConnectedUsersDialog.ShowFormDialog(AdvantageFramework.Security.LicenseKey.Types.ClientPortalUser)

            ElseIf e.Name = AdvantageFramework.WinForm.Presentation.Controls.Label.MarkupLinks.MediaToolsUsers.ToString Then

                AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(CRUDDialog.Type.MediaToolsUsers, False, True)

            ElseIf e.Name = AdvantageFramework.WinForm.Presentation.Controls.Label.MarkupLinks.APIUsers.ToString Then

                AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(CRUDDialog.Type.APIUsers, False, True)

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "



#End Region

#End Region

    End Class

End Namespace