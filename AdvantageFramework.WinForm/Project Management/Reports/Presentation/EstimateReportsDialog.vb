Namespace ProjectManagement.Reports.Presentation

    Public Class EstimateReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUserDefinedReport As Boolean = False
        Private _AvailableEstimates() As Integer = Nothing
        Private _SelectedEstimates() As Integer = Nothing
        Private _AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = Reporting.AdvancedReportWriterReports.OneQuotePerPage
        Private _Location As AdvantageFramework.Database.Entities.Location = Nothing
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

        Private Sub New(ByVal IsUserDefinedReport As Boolean, ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports)

            ' This call is required by the designer.
            InitializeComponent()

            _IsUserDefinedReport = IsUserDefinedReport
            _AdvancedReportWriterReport = AdvancedReportWriterReport
            '_AvailableEstimates = AvailableEstimates
            '_SelectedEstimates = SelectedEstimates

        End Sub
        Private Sub LoadGrid()

            'objects
           Dim EstimateQuotes As Generic.List(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                EstimateQuotes = DbContext.Database.SqlQuery(Of AdvantageFramework.Estimate.Printing.Classes.EstimateQuote)(String.Format("EXEC [dbo].[advsp_estimate_printing_load] '{0}', '{1}', '{2}'", Me.Session.UserCode, DateTimePickerDates_From.Value.ToShortDateString, DateTimePickerDates_To.Value.ToShortDateString)).ToList

                DataGridViewForm_Estimates.CurrentView.BeginUpdate()

                DataGridViewForm_Estimates.DataSource = EstimateQuotes

                DataGridViewForm_Estimates.CurrentView.BestFitColumns()

                DataGridViewForm_Estimates.CurrentView.EndUpdate()

            End Using

            DataGridViewForm_Estimates.CurrentView.BestFitColumns()

        End Sub
        'Private Sub LoadPrintOptions()

        '    'objects
        '    Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

        '    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

        '        Try

        '            PurchaseOrderPrintDefault = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Load(DbContext) _
        '                                         Where Entity.UserID = Me.Session.UserCode _
        '                                         Select Entity).SingleOrDefault

        '        Catch ex As Exception
        '            PurchaseOrderPrintDefault = Nothing
        '        End Try

        '        If PurchaseOrderPrintDefault IsNot Nothing Then

        '            SearchableComboBoxPrintOptions_Location.SelectedValue = PurchaseOrderPrintDefault.LocationID

        '            LoadLocationInformation()

        '            CheckBoxPrintOptions_UsePrintedDate.Checked = CBool(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0))

        '            CheckBoxPrintOptions_POInstructions.Checked = CBool(PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_ShippingInstructions.Checked = CBool(PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_DetailDescription.Checked = CBool(PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_DetailInstructions.Checked = CBool(PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_FooterComment.Checked = CBool(PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0))

        '            CheckBoxPrintOptions_VendorCode.Checked = CBool(PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_VendorContact.Checked = CBool(PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_ClientName.Checked = CBool(PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_ProductName.Checked = CBool(PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_JobNumberAndComponent.Checked = CBool(PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_JobDescription.Checked = CBool(PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_FunctionDescription.Checked = CBool(PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0))
        '            CheckBoxPrintOptions_ExcludeEmployeeSignature.Checked = CBool(PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0))

        '        End If

        '        CheckBoxPrintOptions_SaveSelections.Checked = True

        '    End Using

        'End Sub
        Private Sub SelectGridRows()

            If _SelectedEstimates IsNot Nothing Then

                DataGridViewForm_Estimates.CurrentView.BeginSelection()

                DataGridViewForm_Estimates.CurrentView.ClearSelection()

                For Each PurchaseOrder In _SelectedEstimates

                    DataGridViewForm_Estimates.SelectRow(0, PurchaseOrder, False)

                Next

            End If

        End Sub
        Private Sub CreateParameterDictionaryAndUpdatePOsForPrinting()

            'objects
            Dim EstimatePrintDefault As AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting = Nothing
            Dim EstimateQuote As AdvantageFramework.Estimate.Printing.Classes.EstimateQuote = Nothing
            Dim PONumbers As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                Try

                    EstimateQuote = DataGridViewForm_Estimates.GetFirstSelectedRowDataBoundItem

                    _ParameterDictionary("EstimateQuote") = EstimateQuote
                    _ParameterDictionary("EstimateNumber") = EstimateQuote.EstimateNumber
                    _ParameterDictionary("EstimateComponent") = EstimateQuote.EstimateComponentNumber
                    _ParameterDictionary("EstimateQuote") = EstimateQuote.QuoteNumber.ToString & ","
                    _ParameterDictionary("EstimateUserID") = Me.Session.UserCode


                Catch ex As Exception

                End Try

                EstimatePrintDefault = AdvantageFramework.Estimate.Printing.LoadEstimatePrintingSettingsWV(DbContext, False, Me.Session.UserCode).FirstOrDefault

                If EstimatePrintDefault Is Nothing Then

                    EstimatePrintDefault = New AdvantageFramework.Estimate.Printing.Classes.EstimatePrintSetting

                End If

                _ParameterDictionary("PrintDefaults") = EstimatePrintDefault
                '_ParameterDictionary("DefaultLocation") = _Location

                'If CheckBoxPrintOptions_UsePrintedDate.Checked Then

                '    _ParameterDictionary("UsePrintedDate") = DateTimePickerPrintOptions_PrintedDate.ValueObject

                'End If

                'DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[PURCHASE_ORDER] SET [PO_PRINTED] = 1 WHERE [PO_NUMBER] IN ({0})", String.Join(",", PONumbers)))

            End Using

        End Sub
        Private Function ValidateBeforePreviewOrPrintOrSend() As Boolean

            'objects
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim TabControl As AdvantageFramework.WinForm.Presentation.Controls.TabControl = Nothing
            Dim ReadyForPreviewOrPrintOrSend As Boolean = False

            If Me.Validator Then

                If DataGridViewForm_Estimates.HasASelectedRow Then

                    CreateParameterDictionaryAndUpdatePOsForPrinting()

                    ReadyForPreviewOrPrintOrSend = True

                End If

            Else

                FailedControl = (Me.SuperValidator.LastFailedValidationResults.ToList.FirstOrDefault).Control

                If FailedControl IsNot Nothing Then

                    ParentControl = FailedControl.Parent

                    Do While True

                        Try

                            If ParentControl Is Nothing Then

                                Exit Do

                            ElseIf TypeOf ParentControl Is System.Windows.Forms.Form Then

                                Exit Do

                            ElseIf TypeOf ParentControl.Parent Is System.Windows.Forms.Form Then

                                Exit Do

                            End If

                        Catch ex As Exception
                            'ParentControl = Nothing
                        End Try

                        Try

                            If TypeOf ParentControl Is DevComponents.DotNetBar.TabControlPanel Then

                                TabControl = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).Parent
                                TabControl.SelectedTab = DirectCast(ParentControl, DevComponents.DotNetBar.TabControlPanel).TabItem

                                ParentControl = ParentControl.Parent

                            Else

                                ParentControl = ParentControl.Parent

                            End If

                        Catch ex As Exception
                            ParentControl = Nothing
                        End Try

                    Loop

                    FailedControl.Focus()

                End If

            End If

            ValidateBeforePreviewOrPrintOrSend = ReadyForPreviewOrPrintOrSend

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal IsUserDefinedReport As Boolean, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object),
                                              Optional ByVal AdvancedReportWriterReport As AdvantageFramework.Reporting.AdvancedReportWriterReports = Reporting.AdvancedReportWriterReports.OneQuotePerPage) As System.Windows.Forms.DialogResult

            'objects
            Dim EstimateReportsDialog As AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog = Nothing

            EstimateReportsDialog = New AdvantageFramework.ProjectManagement.Reports.Presentation.EstimateReportsDialog(IsUserDefinedReport, AdvancedReportWriterReport)

            ShowFormDialog = EstimateReportsDialog.ShowDialog()

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                ParameterDictionary = EstimateReportsDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub EstimateReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            Me.DateTimePickerDates_From.Value = Now.Date
            Me.DateTimePickerDates_To.Value = Now.Date

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxPrintOptions_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext)

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                'SelectGridRows()

            Catch ex As Exception

            End Try

            Try

                'LoadPrintOptions()

            Catch ex As Exception

            End Try

            DataGridViewForm_Estimates.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

        End Sub
        Private Sub PurchaseOrderReportsDialog_FormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            'SavePrintOptions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonPrintOptions_LocationOverride_Click(sender As Object, e As EventArgs) Handles ButtonPrintOptions_LocationOverride.Click

            If SearchableComboBoxPrintOptions_Location.HasASelectedValue AndAlso _Location IsNot Nothing Then

                AdvantageFramework.ProjectManagement.Presentation.LocationDefaultsOverrideDialog.ShowFormDialog(_Location)

            End If

        End Sub
        Private Sub ButtonForm_Preview_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Preview.Click

            If ValidateBeforePreviewOrPrintOrSend() Then

                'AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.UserDefined, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonForm_Print_Click(sender As Object, e As EventArgs) Handles ButtonForm_Print.Click

            Dim Printed As Boolean = True
            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim SelectedFolder As String = Nothing

            If ValidateBeforePreviewOrPrintOrSend() Then

                Me.FormAction = WinForm.Presentation.FormActions.Printing
                Me.ShowWaitForm("Printing...")

                Try

                    XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(Me.Session, Reporting.ReportTypes.UserDefined, _ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    XtraReport.CreateDocument()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                            AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                            If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                    My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                                End If

                                AgencyImportPath = AgencyImportPath & "Reports\"

								DefaultFileName = XtraReport.DisplayName & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

								XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                XtraReport.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                XtraReport.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                XtraReport.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, AgencyImportPath, XtraReport.DisplayName))

                                'XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                                XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                                XtraReport.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")

                                AdvantageFramework.WinForm.MessageBox.Show("Your document(s) have been placed on the FTP in the Repository\Out folder.")

                            End If

                        Else

                            Printed = AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReport, True, Me.DefaultLookAndFeel.LookAndFeel, True, False)

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If Printed = True Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            End If

        End Sub
        Private Sub ButtonForm_SendEmail_Click(sender As Object, e As EventArgs) Handles ButtonForm_SendEmail.Click

            Dim XtraReport As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim Agency As AdvantageFramework.Database.Entities.Agency = Nothing
            Dim AgencyImportPath As String = Nothing
            Dim AccessReportTempPath As String = Nothing
            Dim DefaultFileName As String = Nothing
            Dim ToRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim CcRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim BccRecipients As Generic.List(Of AdvantageFramework.Email.Classes.RecipientEmailAddress) = Nothing
            Dim SendingEmailStatus As AdvantageFramework.Email.SendingEmailStatus = Email.SendingEmailStatus.EmailSent
            Dim ErrorMessage As String = ""
            Dim [To] As String = Nothing
            Dim [Cc] As String = Nothing
            Dim [Bcc] As String = Nothing
            Dim EmailSent As Boolean = False

            If ValidateBeforePreviewOrPrintOrSend() Then

                If AdvantageFramework.WinForm.Presentation.EmailRecipientDialog.ShowFormDialog(ToRecipients, CcRecipients, BccRecipients) = Windows.Forms.DialogResult.OK Then

                    If ToRecipients IsNot Nothing AndAlso ToRecipients.Count > 0 Then

                        [To] = Join(ToRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If CcRecipients IsNot Nothing AndAlso CcRecipients.Count > 0 Then

                        [Cc] = Join(CcRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    If BccRecipients IsNot Nothing AndAlso BccRecipients.Count > 0 Then

                        [Bcc] = Join(BccRecipients.Select(Function(Entity) Entity.EmailAddress).ToArray, "; ")

                    End If

                    Me.FormAction = WinForm.Presentation.FormActions.Printing
                    Me.ShowWaitForm("Printing...")

                    Try

                        XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(Me.Session, Reporting.ReportTypes.PurchaseOrderReport, _ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                        XtraReport.CreateDocument()

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                                AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                                AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                                If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                                    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                                        My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                                    End If

                                    AgencyImportPath = AgencyImportPath & "Reports\"

									DefaultFileName = XtraReport.DisplayName & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

									XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                                    XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                                    XtraReport.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                                    XtraReport.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                                    XtraReport.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, AgencyImportPath, XtraReport.DisplayName))

                                    'XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                                    XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                                    XtraReport.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")

                                    Me.ShowWaitForm("Sending...")

                                    EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], XtraReport.DisplayName, "", 3, New String() {AgencyImportPath & DefaultFileName & ".pdf"}, SendingEmailStatus, ErrorMessage)

                                    If My.Computer.FileSystem.FileExists(AgencyImportPath & DefaultFileName & ".pdf") Then

                                        My.Computer.FileSystem.DeleteFile(AgencyImportPath & DefaultFileName & ".pdf")

                                    End If

                                End If

                            Else

                                Agency = AdvantageFramework.Database.Procedures.Agency.Load(DbContext)

                                If Agency IsNot Nothing Then

                                    Try

                                        AccessReportTempPath = AdvantageFramework.Agency.LoadMachineAccessSettings(AdvantageFramework.Agency.LocalMachineAccess.AccessTmpPath)

                                    Catch ex As Exception
                                        AccessReportTempPath = Nothing
                                    End Try

                                    AccessReportTempPath = If(String.IsNullOrWhiteSpace(AccessReportTempPath), Agency.AccessReportTemporaryPath, AccessReportTempPath)

									DefaultFileName = XtraReport.DisplayName & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

									XtraReport.ExportToPdf(AccessReportTempPath & DefaultFileName & ".pdf")

                                    Me.ShowWaitForm("Sending...")

                                    EmailSent = AdvantageFramework.Email.Send(DbContext, [To], [Cc], [Bcc], XtraReport.DisplayName, "", 3, New String() {AccessReportTempPath & DefaultFileName & ".pdf"}, SendingEmailStatus, ErrorMessage)

                                    If My.Computer.FileSystem.FileExists(AccessReportTempPath & DefaultFileName & ".pdf") Then

                                        My.Computer.FileSystem.DeleteFile(AccessReportTempPath & DefaultFileName & ".pdf")

                                    End If

                                End If

                            End If

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.FormAction = WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                    If EmailSent Then

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        If SendingEmailStatus <> Email.SendingEmailStatus.EmailSent Then

                            AdvantageFramework.WinForm.MessageBox.Show(AdvantageFramework.Email.LoadEmailErrorMessage(SendingEmailStatus))

                        ElseIf String.IsNullOrEmpty(ErrorMessage) = False Then

                            AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Failed creating or sending PO Report.  Please contact software support.")

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_Clear_Click(sender As Object, e As EventArgs) Handles ButtonForm_Clear.Click

            DataGridViewForm_Estimates.CurrentView.ClearSelection()
            SearchableComboBoxPrintOptions_Location.SelectedValue = Nothing
            DateTimePickerPrintOptions_PrintedDate.ValueObject = Nothing

            For Each CheckBox In TabControlPanelPrintOptionsTab_PrintOptions.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                CheckBox.Checked = False

            Next

        End Sub
        Private Sub DateTimePickerDates_From_TextChanged(sender As Object, e As EventArgs) Handles DateTimePickerDates_From.TextChanged
            LoadGrid()
        End Sub
        Private Sub DateTimePickerDates_To_TextChanged(sender As Object, e As EventArgs) Handles DateTimePickerDates_To.TextChanged
            LoadGrid()
        End Sub

#End Region

#End Region

        
        
    End Class

End Namespace
