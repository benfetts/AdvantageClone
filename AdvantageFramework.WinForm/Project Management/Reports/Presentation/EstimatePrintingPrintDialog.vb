Namespace ProjectManagement.Reports.Presentation

    Public Class EstimatePrintingPrintDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings = Nothing
        Private _SendingToPrinter As Boolean = False
        Private _ToSingleFile As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings
            Get
                PrintSettings = _PrintSettings
            End Get
        End Property

#End Region

#Region " Methods "

        Protected Sub New(ByVal PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings, ByVal SendingToPrinter As Boolean, ToSingleFile As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _PrintSettings = PrintSettings
            _SendingToPrinter = SendingToPrinter
            _ToSingleFile = ToSingleFile

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PrintSettings As AdvantageFramework.Estimate.Classes.PrintSettings, ByVal SendingToPrinter As Boolean, ToSingleFile As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimatePrintingPrintDialog As EstimatePrintingPrintDialog = Nothing

            EstimatePrintingPrintDialog = New EstimatePrintingPrintDialog(PrintSettings, SendingToPrinter, ToSingleFile)

            ShowFormDialog = EstimatePrintingPrintDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                PrintSettings = EstimatePrintingPrintDialog.PrintSettings

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Protected Sub EstimatePrintingPrintDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemOptions_IncludeCoverSheet.Image = AdvantageFramework.My.Resources.CoverSheetImage



            TextBoxForm_ExportPath.SetDefaultPropertySettings(DisplayName:="Export Path")
            LabelForm_ExportPath.Visible = Not _SendingToPrinter
            TextBoxForm_ExportPath.Visible = Not _SendingToPrinter

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If _PrintSettings Is Nothing Then

                _PrintSettings = New AdvantageFramework.Estimate.Classes.PrintSettings

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) OrElse _SendingToPrinter = True Then

                    TextBoxForm_ExportPath.SecurityEnabled = False
                    TextBoxForm_ExportPath.SetRequired(False)

                Else

                    TextBoxForm_ExportPath.SecurityEnabled = True
                    TextBoxForm_ExportPath.SetRequired(True)

                End If

            End Using

            TextBoxForm_ExportPath.Text = _PrintSettings.ExportPath

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Protected Sub EstimatePrintingPrintDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Protected Sub ButtonItemActions_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                        _PrintSettings.ExportPath = TextBoxForm_ExportPath.Text

                    End If

                End Using

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Protected Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
