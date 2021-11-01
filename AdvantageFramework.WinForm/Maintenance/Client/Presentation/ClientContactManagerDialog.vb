Namespace Maintenance.Client.Presentation

    Public Class ClientContactManagerDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Edit.Enabled = ClientContactManagerControlForm_ClientContactManager.HasOnlyOneSelectedContact
            ButtonItemActions_Delete.Enabled = ClientContactManagerControlForm_ClientContactManager.HasOnlyOneSelectedContact

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ClientContactManagerDialog As AdvantageFramework.Maintenance.Client.Presentation.ClientContactManagerDialog = Nothing

            ClientContactManagerDialog = New AdvantageFramework.Maintenance.Client.Presentation.ClientContactManagerDialog(ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = ClientContactManagerDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ClientContactManagerDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            ClientContactManagerControlForm_ClientContactManager.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

            EnableOrDisableActions()

        End Sub
        Private Sub ClientContactManagerDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ClientContactManagerControlForm_ClientContactManager.DataGridViewControl_Contacts.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            ClientContactManagerControlForm_ClientContactManager.AddClientContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Edit.Click

            ClientContactManagerControlForm_ClientContactManager.EditSelectedClientContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            ClientContactManagerControlForm_ClientContactManager.DeleteSelectedClientContact()

            EnableOrDisableActions()

        End Sub
        Private Sub ClientContactManagerControlForm_ClientContactManager_RowCountChangedEvent() Handles ClientContactManagerControlForm_ClientContactManager.RowCountChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ClientContactManagerControlForm_ClientContactManager_SelectionChangedEvent() Handles ClientContactManagerControlForm_ClientContactManager.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace