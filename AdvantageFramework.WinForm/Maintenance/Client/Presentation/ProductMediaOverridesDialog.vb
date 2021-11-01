Namespace Maintenance.Client.Presentation

    Public Class ProductMediaOverridesDialog

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

        Private Sub New(ClientCode As String, DivisionCode As String, ProductCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

        End Sub
        Private Sub EnableOrDisableActions()

            If ProductMediaOverrideControlForm_Overrides.DataGridViewForm_ProductMediaOverrides.IsNewItemRow Then

                ButtonItemActions_Cancel.Enabled = True
                ButtonItemActions_Save.Enabled = False
                ButtonItemActions_Delete.Enabled = False

            Else

                ButtonItemActions_Cancel.Enabled = False
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                ButtonItemActions_Delete.Enabled = ProductMediaOverrideControlForm_Overrides.DataGridViewForm_ProductMediaOverrides.HasASelectedRow

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ClientCode As String, DivisionCode As String, ProductCode As String) As System.Windows.Forms.DialogResult

            'objects
            Dim ProductMediaOverridesDialog As AdvantageFramework.Maintenance.Client.Presentation.ProductMediaOverridesDialog = Nothing

            ProductMediaOverridesDialog = New AdvantageFramework.Maintenance.Client.Presentation.ProductMediaOverridesDialog(ClientCode, DivisionCode, ProductCode)

            ShowFormDialog = ProductMediaOverridesDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ProductMediaOverridesDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            ProductMediaOverrideControlForm_Overrides.LoadControl(_ClientCode, _DivisionCode, _ProductCode)

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub ProductMediaOverridesDialog_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub ProductMediaOverridesDialog_UserEntryChangedEvent(Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            ProductMediaOverrideControlForm_Overrides.Save()

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            ProductMediaOverrideControlForm_Overrides.Delete()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            ProductMediaOverrideControlForm_Overrides.DataGridViewForm_ProductMediaOverrides.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ProductMediaOverrideControlForm_Overrides_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles ProductMediaOverrideControlForm_Overrides.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ProductMediaOverrideControlForm_Overrides_SelectionChangedEvent(sender As Object, e As EventArgs) Handles ProductMediaOverrideControlForm_Overrides.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace