Namespace Maintenance.Accounting.Presentation

    Public Class CurrencyCodeEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _CurrencyCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property CurrencyCode As String
            Get
                CurrencyCode = _CurrencyCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef CurrencyCode As String)

            ' This call is required by the designer.
            InitializeComponent()

            _CurrencyCode = CurrencyCode

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef CurrencyCode As String = Nothing) As System.Windows.Forms.DialogResult

            'objects
            Dim CurrencyCodeEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeEditDialog = Nothing

            CurrencyCodeEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeEditDialog(CurrencyCode)

            ShowFormDialog = CurrencyCodeEditDialog.ShowDialog()

            CurrencyCode = CurrencyCodeEditDialog.CurrencyCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CurrencyCodeEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _CurrencyCode <> "" Then

                ButtonForm_Add.Visible = False
                ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                ButtonForm_Update.Visible = False

            End If

            If CurrencyCodeForm_CurrencyCode.LoadControl(_CurrencyCode) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The currency you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim CurrencyCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    CurrencyCodeForm_CurrencyCode.Insert(CurrencyCode)

                    _CurrencyCode = CurrencyCode

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    CurrencyCodeForm_CurrencyCode.Save()

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace