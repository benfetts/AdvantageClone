Namespace Maintenance.Management.Presentation

    Public Class OverheadAccountEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OverheadAccountCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property OverheadAccountCode As String
            Get
                OverheadAccountCode = _OverheadAccountCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef OverheadAccountCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _OverheadAccountCode = OverheadAccountCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef OverheadAccountCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim OverheadAccountEditDialog As AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountEditDialog = Nothing

            OverheadAccountEditDialog = New AdvantageFramework.Maintenance.Management.Presentation.OverheadAccountEditDialog(OverheadAccountCode)

            ShowFormDialog = OverheadAccountEditDialog.ShowDialog()

            OverheadAccountCode = OverheadAccountEditDialog.OverheadAccountCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub OverheadAccountEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _OverheadAccountCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If OverheadAccountControlForm_OverheadAccount.LoadControl(_OverheadAccountCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The Overhead Account you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim OverheadAccountCode As String = Nothing
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If OverheadAccountControlForm_OverheadAccount.Insert(OverheadAccountCode) Then

                        _OverheadAccountCode = OverheadAccountCode

                        Me.ClearChanged()

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    End If

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace