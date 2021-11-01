Namespace Maintenance.General.Presentation

    Public Class CSIPreferredPartnerAgreementDialog

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
            Dim CSIPreferredPartnerAgreementDialog As AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerAgreementDialog = Nothing

            CSIPreferredPartnerAgreementDialog = New AdvantageFramework.Maintenance.General.Presentation.CSIPreferredPartnerAgreementDialog()

            ShowFormDialog = CSIPreferredPartnerAgreementDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CSIPreferredPartnerAgreementDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim MemoryStream As System.IO.MemoryStream = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

			MemoryStream = New System.IO.MemoryStream(My.Resources.CSI_Data_Transfer_Agreement)

			RichEditForm_Agreement.RichEditControl.LoadDocument(MemoryStream, DevExpress.XtraRichEdit.DocumentFormat.OpenXml)

        End Sub
        Private Sub CSIPreferredPartnerAgreementDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            RichEditForm_Agreement.ShowEditButtons = False

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_OK.Click

            If CheckBoxForm_AcceptAgreement.Checked Then

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please check that you agree to terms of the agreement.")

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace