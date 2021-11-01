Namespace Maintenance.Accounting.Presentation

    Public Class OfficeEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _OfficeCode As String = Nothing
        Private _IsCopy As Boolean = False
        Private _CopyDefaultAccts As Boolean = False
        Private _CopyDefaultProductionAccts As Boolean = False
        Private _CopyDefaultMediaAccts As Boolean = False
        Private _CopyProductionSalesClassFunctionAccts As Boolean = False
        Private _CopyProductionFunctionAccts As Boolean = False
        Private _CopyMediaSalesClassAccts As Boolean = False
        Private _CopySalesTaxAccts As Boolean = False
        Private _ReplaceOfficeSegment As Boolean = False

#End Region

#Region " Properties "

        Private ReadOnly Property OfficeCode As String
            Get
                OfficeCode = _OfficeCode
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef OfficeCode As String, ByVal IsCopy As Boolean, ByVal CopyDefaultAccts As Boolean, ByVal CopyDefaultProductionAccts As Boolean, ByVal CopyDefaultMediaAccts As Boolean, ByVal CopyProductionSalesClassFunctionAccts As Boolean, ByVal CopyProductionFunctionAccts As Boolean, ByVal CopyMediaSalesClassAccts As Boolean, ByVal CopySalesTaxAccts As Boolean, ByVal ReplaceOfficeSegment As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _OfficeCode = OfficeCode
            _IsCopy = IsCopy
            _CopyDefaultAccts = CopyDefaultAccts
            _CopyDefaultProductionAccts = CopyDefaultProductionAccts
            _CopyDefaultMediaAccts = CopyDefaultMediaAccts
            _CopyProductionSalesClassFunctionAccts = CopyProductionSalesClassFunctionAccts
            _CopyProductionFunctionAccts = CopyProductionFunctionAccts
            _CopyMediaSalesClassAccts = CopyMediaSalesClassAccts
            _CopySalesTaxAccts = CopySalesTaxAccts
            _ReplaceOfficeSegment = ReplaceOfficeSegment

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef OfficeCode As String, Optional ByVal IsCopy As Boolean = False, Optional ByVal CopyDefaultAccts As Boolean = False, Optional ByVal _CopyDefaultProductionAccts As Boolean = False, Optional ByVal CopyDefaultMediaAccts As Boolean = False, Optional ByVal CopyProductionSalesClassFunctionAccts As Boolean = False, Optional ByVal CopyProductionFunctionAccts As Boolean = False, Optional ByVal CopyMediaSalesClassAccts As Boolean = False, Optional ByVal CopySalesTaxAccts As Boolean = False, Optional ByVal ReplaceOfficeSegment As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim OfficeEditDialog As AdvantageFramework.Maintenance.Accounting.Presentation.OfficeEditDialog = Nothing

            OfficeEditDialog = New AdvantageFramework.Maintenance.Accounting.Presentation.OfficeEditDialog(OfficeCode, IsCopy, CopyDefaultAccts, _CopyDefaultProductionAccts, CopyDefaultMediaAccts, CopyProductionSalesClassFunctionAccts, CopyProductionFunctionAccts, CopyMediaSalesClassAccts, CopySalesTaxAccts, ReplaceOfficeSegment)

            ShowFormDialog = OfficeEditDialog.ShowDialog()

            OfficeCode = OfficeEditDialog.OfficeCode

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub OfficeEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _OfficeCode IsNot Nothing AndAlso _OfficeCode <> "" AndAlso _IsCopy = False Then

                ButtonForm_Add.Visible = False
                'ButtonForm_Update.Visible = True

            Else

                ButtonForm_Add.Visible = True
                'ButtonForm_Update.Visible = False

            End If

            If OfficeControlForm_Office.LoadControl(_OfficeCode, _IsCopy, _CopyDefaultAccts, _CopyDefaultProductionAccts, _CopyDefaultMediaAccts, _CopyProductionSalesClassFunctionAccts, _CopyProductionFunctionAccts, _CopyMediaSalesClassAccts, _CopySalesTaxAccts, _ReplaceOfficeSegment) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("The office you are trying to edit does not exist anymore.")
                Me.Close()

            End If

        End Sub
        Private Sub OfficeEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                OfficeControlForm_Office.TextBoxControl_Code.Focus()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim OfficeCode As String = ""
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    If OfficeControlForm_Office.Insert(OfficeCode, _CopyProductionFunctionAccts, _CopySalesTaxAccts, _CopyMediaSalesClassAccts, _CopyProductionSalesClassFunctionAccts) Then

                        _OfficeCode = OfficeCode

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
        'Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs)

        '    'objects
        '    Dim ErrorMessage As String = ""

        '    If Me.Validator Then

        '        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

        '        Try

        '            OfficeControlForm_Office.Save()

        '            Me.ClearChanged()

        '            Me.DialogResult = Windows.Forms.DialogResult.OK
        '            Me.Close()

        '        Catch ex As Exception
        '            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
        '        End Try

        '        Me.CloseWaitForm()

        '    Else

        '        For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

        '            ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

        '        Next

        '        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

        '    End If

        'End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace