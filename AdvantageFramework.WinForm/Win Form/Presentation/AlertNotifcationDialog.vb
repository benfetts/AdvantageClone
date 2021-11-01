Namespace WinForm.Presentation

    Public Class AlertNotifcationDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Session As AdvantageFramework.Security.Session = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal Session As AdvantageFramework.Security.Session, ByVal Location As System.Drawing.Point, ByVal Message As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _Session = Session
            PanelForm_Message.Text = Message
            Me.Location = New System.Drawing.Point(Location.X - 375, Location.Y - 238)

        End Sub
        Private Sub LoadModule(ByVal SecurityModule As AdvantageFramework.Security.Modules)

            'objects
            Dim FormParent As System.Windows.Forms.Form = Nothing
            Dim FormOpenForm As System.Windows.Forms.Form = Nothing

            For Each FormOpenForm In System.Windows.Forms.Application.OpenForms

                If FormOpenForm.TopLevel Then

                    FormParent = FormOpenForm
                    Exit For

                End If

            Next

            If FormParent IsNot Nothing Then

                If TypeOf FormParent Is AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm Then

                    DirectCast(FormParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).OpenModule(SecurityModule)

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm(ByVal Session As AdvantageFramework.Security.Session, ByVal Location As System.Drawing.Point, ByVal Message As String)

            Dim AlertNotifcationDialog As AdvantageFramework.WinForm.Presentation.AlertNotifcationDialog = Nothing

            AlertNotifcationDialog = New AdvantageFramework.WinForm.Presentation.AlertNotifcationDialog(Session, Location, Message)

            AlertNotifcationDialog.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AlertNotifcationDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'objects
            Dim HasAccessToOneOption As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Security_Setup_Group.ToString) Then

                    HasAccessToOneOption = True
                    ButtonItemGoTo_GroupSetup.Enabled = True

                Else

                    ButtonItemGoTo_GroupSetup.Enabled = False

                End If

                If AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Security_Setup_ModuleAccess.ToString) Then

                    HasAccessToOneOption = True
                    ButtonItemGoTo_ModuleAccess.Enabled = True

                Else

                    ButtonItemGoTo_ModuleAccess.Enabled = False

                End If

                If AdvantageFramework.Security.DoesUserHaveAccessToModule(_Session, AdvantageFramework.Security.Modules.Security_Setup_User.ToString) Then

                    HasAccessToOneOption = True
                    ButtonItemGoTo_UserSetup.Enabled = True

                Else

                    ButtonItemGoTo_UserSetup.Enabled = False

                End If

                ButtonItemBottomMenu_Options.Visible = HasAccessToOneOption

            End Using

        End Sub
        Private Sub AlertNotifcationDialog_LostFocus(sender As Object, e As System.EventArgs) Handles Me.LostFocus

            Me.Close()

        End Sub
        Private Sub AlertNotifcationDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemOptions_Read_Click(sender As Object, e As System.EventArgs) Handles ButtonItemOptions_Read.Click

            AdvantageFramework.Security.ClearNewAdvantageApplicationsAlertSetting(_Session)

            Me.Close()

        End Sub
        Private Sub ButtonItemOptions_Hide_Click(sender As Object, e As System.EventArgs) Handles ButtonItemOptions_Hide.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemGoTo_GroupSetup_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGoTo_GroupSetup.Click

            LoadModule(Security.Modules.Security_Setup_Group)

            Me.Close()

        End Sub
        Private Sub ButtonItemGoTo_ModuleAccess_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGoTo_ModuleAccess.Click

            LoadModule(Security.Modules.Security_Setup_ModuleAccess)

            Me.Close()

        End Sub
		Private Sub ButtonItemGoTo_UserSetup_Click(sender As Object, e As System.EventArgs) Handles ButtonItemGoTo_UserSetup.Click

			LoadModule(Security.Modules.Security_Setup_User)

			Me.Close()

		End Sub
		Private Sub PanelForm_Message_Scroll(sender As Object, e As System.Windows.Forms.ScrollEventArgs) Handles PanelForm_Message.Scroll

			PanelForm_Message.SuspendLayout()

			PanelForm_Message.Size = New System.Drawing.Size(PanelForm_Message.Size.Width, PanelForm_Message.Size.Height + 1)
			PanelForm_Message.Size = New System.Drawing.Size(PanelForm_Message.Size.Width, PanelForm_Message.Size.Height - 1)

			PanelForm_Message.ResumeLayout()

		End Sub

#End Region

#End Region

	End Class

End Namespace