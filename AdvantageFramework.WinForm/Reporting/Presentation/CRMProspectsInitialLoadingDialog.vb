Namespace Reporting.Presentation

    Public Class CRMProspectsInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal DynamicReport As AdvantageFramework.Reporting.DynamicReports, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim CRMProspectsInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.CRMProspectsInitialLoadingDialog = Nothing

            CRMProspectsInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.CRMProspectsInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = CRMProspectsInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = CRMProspectsInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub CRMProspectsInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            If _ParameterDictionary IsNot Nothing Then

                CheckBoxForm_Include.Checked = If(IsNothing(_ParameterDictionary(AdvantageFramework.Reporting.CRMProspectsParameters.IncludeInactiveCDPs.ToString)) OrElse _ParameterDictionary(AdvantageFramework.Reporting.CRMProspectsParameters.IncludeInactiveCDPs.ToString) = 1, True, False)

            Else

                CheckBoxForm_Include.Checked = False

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If _ParameterDictionary Is Nothing Then

                    _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                End If

                _ParameterDictionary(AdvantageFramework.Reporting.CRMProspectsParameters.IncludeInactiveCDPs.ToString) = CheckBoxForm_Include.Checked

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

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