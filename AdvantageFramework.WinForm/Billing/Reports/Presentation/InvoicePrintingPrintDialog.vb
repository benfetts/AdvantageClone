Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingPrintDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings = Nothing
        Private _SendingToPrinter As Boolean = False
        Private _ToSingleFile As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings
            Get
                PrintSettings = _PrintSettings
            End Get
        End Property

#End Region

#Region " Methods "

        Protected Sub New(ByVal PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings, ByVal SendingToPrinter As Boolean, ToSingleFile As Boolean)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _PrintSettings = PrintSettings
            _SendingToPrinter = SendingToPrinter
            _ToSingleFile = ToSingleFile

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal PrintSettings As AdvantageFramework.InvoicePrinting.Classes.PrintSettings, ByVal SendingToPrinter As Boolean, ToSingleFile As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim InvoicePrintingPrintDialog As InvoicePrintingPrintDialog = Nothing

            InvoicePrintingPrintDialog = New InvoicePrintingPrintDialog(PrintSettings, SendingToPrinter, ToSingleFile)

            ShowFormDialog = InvoicePrintingPrintDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                PrintSettings = InvoicePrintingPrintDialog.PrintSettings

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Protected Sub InvoicePrintingPrintDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ButtonItemActions_Process.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemOptions_SendToDocumentManager.Image = AdvantageFramework.My.Resources.DocumentManagerImage
            ButtonItemOptions_IncludeCoverSheet.Image = AdvantageFramework.My.Resources.CoverSheetImage



            TextBoxForm_ExportPath.SetDefaultPropertySettings(DisplayName:="Export Path")
            LabelForm_ExportPath.Visible = Not _SendingToPrinter
            TextBoxForm_ExportPath.Visible = Not _SendingToPrinter

            If _SendingToPrinter Then

                RibbonBarOptions_PackageOptions.Visible = False
                RibbonBarOptions_Include.Visible = False

            Else

                If _ToSingleFile Then

                    RibbonBarOptions_PackageOptions.Visible = False
                    RibbonBarOptions_Include.Visible = False

                Else

                    RibbonBarOptions_PackageOptions.Visible = True
                    RibbonBarOptions_Include.Visible = True

                End If

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            If _PrintSettings Is Nothing Then

                _PrintSettings = New AdvantageFramework.InvoicePrinting.Classes.PrintSettings

            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(Session.ConnectionString, Session.UserCode)

                _PrintSettings.IncludeCoverSheet = AdvantageFramework.InvoicePrinting.LoadDefaultIncludeCoverSheet(DataContext)
                _PrintSettings.SendToDocumentManager = AdvantageFramework.InvoicePrinting.LoadDefaultUploadDocumentManager(DataContext)

                _PrintSettings.PackageType = AdvantageFramework.InvoicePrinting.LoadDefaultPackageType(DataContext)

            End Using

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

            ButtonItemOptions_IncludeCoverSheet.Checked = _PrintSettings.IncludeCoverSheet
            ButtonItemOptions_SendToDocumentManager.Checked = _PrintSettings.SendToDocumentManager

            If _PrintSettings.PackageType = InvoicePrinting.Methods.PackageTypes.OneZip Then

                ButtonItemPackageOptions_OneZip.Checked = True
                ButtonItemPackageOptions_OneZipPerInvoice.Checked = False

            ElseIf _PrintSettings.PackageType = InvoicePrinting.Methods.PackageTypes.OneZipPerInvoice Then

                ButtonItemPackageOptions_OneZip.Checked = False
                ButtonItemPackageOptions_OneZipPerInvoice.Checked = True

            ElseIf _PrintSettings.PackageType = InvoicePrinting.Methods.PackageTypes.None Then

                ButtonItemPackageOptions_OneZip.Checked = False
                ButtonItemPackageOptions_OneZipPerInvoice.Checked = False

            End If

            CheckBoxItemInclude_APDocuments.Checked = _PrintSettings.IncludeAPDocuments
            CheckBoxItemInclude_ExpenseDocuments.Checked = _PrintSettings.IncludeExpenseReportReceipts

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Protected Sub InvoicePrintingPrintDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown



        End Sub

#End Region

#Region "  Control Event Handlers "

        Protected Sub ButtonItemActions_Process_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Process.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ButtonItemOptions_SendToDocumentManager.Checked = False OrElse AdvantageFramework.FileSystem.CheckRepositoryLimit(DbContext, ErrorMessage) Then

                        _PrintSettings.SendToDocumentManager = ButtonItemOptions_SendToDocumentManager.Checked
                        _PrintSettings.IncludeCoverSheet = ButtonItemOptions_IncludeCoverSheet.Checked

                        If _SendingToPrinter Then

                            _PrintSettings.PackageType = InvoicePrinting.PackageTypes.None
                            _PrintSettings.IncludeAPDocuments = False
                            _PrintSettings.IncludeExpenseReportReceipts = False

                        Else

                            If _ToSingleFile Then

                                _PrintSettings.PackageType = InvoicePrinting.PackageTypes.None
                                _PrintSettings.IncludeAPDocuments = False
                                _PrintSettings.IncludeExpenseReportReceipts = False

                            Else

                                If ButtonItemPackageOptions_OneZip.Checked Then

                                    _PrintSettings.PackageType = InvoicePrinting.PackageTypes.OneZip

                                ElseIf ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                                    _PrintSettings.PackageType = InvoicePrinting.PackageTypes.OneZipPerInvoice

                                Else

                                    _PrintSettings.PackageType = InvoicePrinting.PackageTypes.None

                                End If

                                _PrintSettings.IncludeAPDocuments = CheckBoxItemInclude_APDocuments.Checked
                                _PrintSettings.IncludeExpenseReportReceipts = CheckBoxItemInclude_ExpenseDocuments.Checked

                            End If

                        End If

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) = False Then

                            _PrintSettings.ExportPath = TextBoxForm_ExportPath.Text

                        End If

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage & " Uncheck Send to Document Repository and try again.")

                    End If

                End Using

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
        Private Sub ButtonItemPackageOptions_OneZip_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZip.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemPackageOptions_OneZip.Checked Then

                    ButtonItemPackageOptions_OneZipPerInvoice.Checked = False

                End If

            End If

        End Sub
        Private Sub ButtonItemPackageOptions_OneZipPerInvoice_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemPackageOptions_OneZipPerInvoice.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If ButtonItemPackageOptions_OneZipPerInvoice.Checked Then

                    ButtonItemPackageOptions_OneZip.Checked = False

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
