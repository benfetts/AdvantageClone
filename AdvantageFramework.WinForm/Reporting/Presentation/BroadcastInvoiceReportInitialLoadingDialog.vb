Namespace Reporting.Presentation

    Public Class BroadcastInvoiceReportInitialLoadingDialog

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

        Private Sub New(ParameterDictionary As Generic.Dictionary(Of String, Object))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParameterDictionary = ParameterDictionary

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef ParameterDictionary As Generic.Dictionary(Of String, Object)) As Windows.Forms.DialogResult

            'objects
            Dim BroadcastInvoiceReportInitialLoadingDialog As AdvantageFramework.Reporting.Presentation.BroadcastInvoiceReportInitialLoadingDialog = Nothing

            BroadcastInvoiceReportInitialLoadingDialog = New AdvantageFramework.Reporting.Presentation.BroadcastInvoiceReportInitialLoadingDialog(ParameterDictionary)

            ShowFormDialog = BroadcastInvoiceReportInitialLoadingDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                ParameterDictionary = BroadcastInvoiceReportInitialLoadingDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub BroadcastInvoiceReportInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.ByPassUserEntryChanged = True
            Me.ShowUnsavedChangesOnFormClosing = False

            ComboBoxForm_Report.DisplayName = "Report"
            ComboBoxForm_Report.SetRequired(True)

            Using DbContext = New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                ComboBoxForm_Report.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.BroadcastInvoiceReportTypes)).OrderBy(Function(EnumObject) EnumObject.Description).ToList

            End Using

            Me.BroadcastInvoiceControl.LoadControl()

        End Sub
        Private Sub BroadcastInvoiceReportInitialLoadingDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            BroadcastInvoiceControl.CDPChooserControlSelectClients_SelectClients.ForceResize()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                If BroadcastInvoiceControl.ValidateControl(ErrorMessage) Then

                    If _ParameterDictionary Is Nothing Then

                        _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                    End If

                    _ParameterDictionary = BroadcastInvoiceControl.ParameterDictionary

                    AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, ComboBoxForm_Report.GetSelectedValue, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

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
