Namespace Maintenance.Client.Presentation

    Public Class ContractManagerDialog

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

            ButtonItemActions_Copy.Enabled = ContractManagerControlForm_ContractManager.HasOnlyOneSelectedContract
            ButtonItemActions_Edit.Enabled = ContractManagerControlForm_ContractManager.HasOnlyOneSelectedContract
            ButtonItemActions_Delete.Enabled = ContractManagerControlForm_ContractManager.HasOnlyOneSelectedContract

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ContractManagerDialog As AdvantageFramework.Maintenance.Client.Presentation.ContractManagerDialog = Nothing

            ContractManagerDialog = New AdvantageFramework.Maintenance.Client.Presentation.ContractManagerDialog(ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = ContractManagerDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ContractManagerDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Copy.Image = AdvantageFramework.My.Resources.CopyImage
            ButtonItemActions_Edit.Image = AdvantageFramework.My.Resources.EditImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            ButtonItemActions_Add.SecurityEnabled = ContractManagerControlForm_ContractManager.CanUserUpdateInClientMaintenance
            ButtonItemActions_Copy.SecurityEnabled = ContractManagerControlForm_ContractManager.CanUserUpdateInClientMaintenance
            ButtonItemActions_Delete.SecurityEnabled = ContractManagerControlForm_ContractManager.CanUserUpdateInClientMaintenance

            ContractManagerControlForm_ContractManager.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

            EnableOrDisableActions()

        End Sub
        Private Sub ContractManagerDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            ContractManagerControlForm_ContractManager.DataGridViewControl_Contracts.Focus()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            ContractManagerControlForm_ContractManager.AddContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Copy_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Copy.Click

            ContractManagerControlForm_ContractManager.CopyContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Edit_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Edit.Click

            ContractManagerControlForm_ContractManager.EditContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            ContractManagerControlForm_ContractManager.DeleteSelectedContract()

            EnableOrDisableActions()

        End Sub
        Private Sub ContractManagerControlForm_ContractManager_RowCountChangedEvent() Handles ContractManagerControlForm_ContractManager.RowCountChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ContractManagerControlForm_ContractManager_SelectionChangedEvent() Handles ContractManagerControlForm_ContractManager.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace