Namespace ProjectManagement.Presentation

    Public Class PurchaseOrderReportsDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsUserDefinedReport As Boolean = False
        Private _AvailablePurchaseOrders() As Integer = Nothing
        Private _SelectedPurchaseOrders() As Integer = Nothing
        Private _Printed As Boolean = False
        Private _Location As AdvantageFramework.Database.Entities.Location = Nothing
        Private _ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property ParameterDictionary As Generic.Dictionary(Of String, Object)
            Get
                ParameterDictionary = _ParameterDictionary
            End Get
        End Property
        Private ReadOnly Property Printed As Boolean
            Get
                Printed = _Printed
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal IsUserDefinedReport As Boolean, ByVal AvailablePurchaseOrders() As Integer, ByVal SelectedPurchaseOrders() As Integer, ByVal Printed As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _IsUserDefinedReport = IsUserDefinedReport
            _AvailablePurchaseOrders = AvailablePurchaseOrders
            _SelectedPurchaseOrders = SelectedPurchaseOrders
            _Printed = Printed

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim PurchaseOrders As Generic.List(Of AdvantageFramework.Database.Entities.PurchaseOrder) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _AvailablePurchaseOrders IsNot Nothing AndAlso _AvailablePurchaseOrders.Count > 0 Then

                    DataGridViewForm_SelectedPurchaseOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(DbContext, Session.UserCode)
                                                                         Where _AvailablePurchaseOrders.Contains(Entity.Number)
                                                                         Select Entity
                                                                         Order By Entity.Number Descending

                Else

                    DataGridViewForm_SelectedPurchaseOrders.DataSource = From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderComplexType.Load(DbContext, Session.UserCode, True)
                                                                         Where _AvailablePurchaseOrders.Contains(Entity.Number)
                                                                         Select Entity
                                                                         Order By Entity.Number Descending

                End If

            End Using

            DataGridViewForm_SelectedPurchaseOrders.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadReports()

            ListBoxForm_Reports.DataSource = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports))
                                              Select [Code] = Entity.Code,
                                                     [Description] = Entity.Description
                                              Order By Description).ToList

        End Sub
        Private Sub LoadPrintOptions()

            'objects
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    PurchaseOrderPrintDefault = (From Entity In AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Load(DbContext)
                                                 Where Entity.UserID = Me.Session.UserCode
                                                 Select Entity).SingleOrDefault

                Catch ex As Exception
                    PurchaseOrderPrintDefault = Nothing
                End Try

                If PurchaseOrderPrintDefault IsNot Nothing Then

                    SearchableComboBoxPrintOptions_Location.SelectedValue = PurchaseOrderPrintDefault.LocationID

                    LoadLocationInformation()

                    CheckBoxPrintOptions_UsePrintedDate.Checked = CBool(PurchaseOrderPrintDefault.DateToPrint.GetValueOrDefault(0))

                    CheckBoxPrintOptions_POInstructions.Checked = CBool(PurchaseOrderPrintDefault.PurchaseOrderInstructions.GetValueOrDefault(0))
                    CheckBoxPrintOptions_ShippingInstructions.Checked = CBool(PurchaseOrderPrintDefault.ShippingInstructions.GetValueOrDefault(0))
                    CheckBoxPrintOptions_DetailDescription.Checked = CBool(PurchaseOrderPrintDefault.DetailDescription.GetValueOrDefault(0))
                    CheckBoxPrintOptions_DetailInstructions.Checked = CBool(PurchaseOrderPrintDefault.DetailInstruction.GetValueOrDefault(0))
                    CheckBoxPrintOptions_FooterComment.Checked = CBool(PurchaseOrderPrintDefault.FooterComment.GetValueOrDefault(0))

                    CheckBoxPrintOptions_VendorCode.Checked = CBool(PurchaseOrderPrintDefault.VendorCode.GetValueOrDefault(0))
                    CheckBoxPrintOptions_VendorContact.Checked = CBool(PurchaseOrderPrintDefault.VendorContact.GetValueOrDefault(0))
                    CheckBoxPrintOptions_ClientName.Checked = CBool(PurchaseOrderPrintDefault.ClientName.GetValueOrDefault(0))
                    CheckBoxPrintOptions_ProductName.Checked = CBool(PurchaseOrderPrintDefault.ProductName.GetValueOrDefault(0))
                    CheckBoxPrintOptions_JobNumberAndComponent.Checked = CBool(PurchaseOrderPrintDefault.JobComponentNumber.GetValueOrDefault(0))
                    CheckBoxPrintOptions_JobDescription.Checked = CBool(PurchaseOrderPrintDefault.JobDescription.GetValueOrDefault(0))
                    CheckBoxPrintOptions_JobComponentDescription.Checked = CBool(PurchaseOrderPrintDefault.JobComponentDescription.GetValueOrDefault(0))
                    CheckBoxPrintOptions_FunctionDescription.Checked = CBool(PurchaseOrderPrintDefault.FunctionDescription.GetValueOrDefault(0))
                    CheckBoxPrintOptions_ExcludeEmployeeSignature.Checked = CBool(PurchaseOrderPrintDefault.UseEmployeeSignature.GetValueOrDefault(0))
                    CheckBoxPrintOptions_UseLoggedInUserSignature.Checked = CBool(PurchaseOrderPrintDefault.UseUserSignature.GetValueOrDefault(0))

                    If Not String.IsNullOrWhiteSpace(PurchaseOrderPrintDefault.ReportFormat) Then

                        If AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Reporting.PurchaseOrderReports)).Any(Function(EnumObj) EnumObj.Code = PurchaseOrderPrintDefault.ReportFormat) Then

                            ListBoxForm_Reports.SelectedValue = PurchaseOrderPrintDefault.ReportFormat

                        End If

                    End If

                End If

                CheckBoxPrintOptions_SaveSelections.Checked = True

            End Using

        End Sub
        Private Sub SelectGridRows()

            If _SelectedPurchaseOrders IsNot Nothing Then

                DataGridViewForm_SelectedPurchaseOrders.CurrentView.BeginSelection()

                DataGridViewForm_SelectedPurchaseOrders.CurrentView.ClearSelection()

                For Each PurchaseOrder In _SelectedPurchaseOrders

                    DataGridViewForm_SelectedPurchaseOrders.SelectRow(0, PurchaseOrder, False)

                Next

            End If

        End Sub
        Private Sub LoadLocationInformation()

            'objects
            Dim Location As AdvantageFramework.Database.Entities.Location = Nothing

            If SearchableComboBoxPrintOptions_Location.HasASelectedValue Then

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Location = AdvantageFramework.Database.Procedures.Location.LoadByLocationID(DataContext, SearchableComboBoxPrintOptions_Location.GetSelectedValue)

                End Using

            End If

            _Location = Location

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonPrintOptions_LocationOverride.Enabled = SearchableComboBoxPrintOptions_Location.HasASelectedValue
            DateTimePickerPrintOptions_PrintedDate.Enabled = CheckBoxPrintOptions_UsePrintedDate.Checked

        End Sub
        Private Sub SavePrintOptions()

            'objects
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
            Dim Insert As Boolean = False

            If CheckBoxPrintOptions_SaveSelections.Checked Then

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Me.Session.UserCode)

                        If PurchaseOrderPrintDefault Is Nothing Then

                            Insert = True
                            PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
                            PurchaseOrderPrintDefault.DbContext = DbContext
                            PurchaseOrderPrintDefault.UserID = Me.Session.UserCode

                        End If

                        FillPurchaseOrderPrintDefault(PurchaseOrderPrintDefault)

                        If Insert Then

                            AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Insert(DbContext, PurchaseOrderPrintDefault)

                        Else

                            AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Update(DbContext, PurchaseOrderPrintDefault)

                        End If

                    End Using

                Catch ex As Exception

                End Try

            End If

        End Sub
        Private Sub FillPurchaseOrderPrintDefault(ByVal PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault)

            If PurchaseOrderPrintDefault IsNot Nothing Then

                PurchaseOrderPrintDefault.LocationID = SearchableComboBoxPrintOptions_Location.GetSelectedValue
                PurchaseOrderPrintDefault.DateToPrint = Convert.ToInt16(CheckBoxPrintOptions_UsePrintedDate.Checked)
                PurchaseOrderPrintDefault.PurchaseOrderInstructions = Convert.ToInt16(CheckBoxPrintOptions_POInstructions.Checked)
                PurchaseOrderPrintDefault.ShippingInstructions = Convert.ToInt16(CheckBoxPrintOptions_ShippingInstructions.Checked)
                PurchaseOrderPrintDefault.DetailDescription = Convert.ToInt16(CheckBoxPrintOptions_DetailDescription.Checked)
                PurchaseOrderPrintDefault.DetailInstruction = Convert.ToInt16(CheckBoxPrintOptions_DetailInstructions.Checked)
                PurchaseOrderPrintDefault.FooterComment = Convert.ToInt16(CheckBoxPrintOptions_FooterComment.Checked)
                PurchaseOrderPrintDefault.VendorCode = Convert.ToInt16(CheckBoxPrintOptions_VendorCode.Checked)
                PurchaseOrderPrintDefault.VendorContact = Convert.ToInt16(CheckBoxPrintOptions_VendorContact.Checked)
                PurchaseOrderPrintDefault.ClientName = Convert.ToInt16(CheckBoxPrintOptions_ClientName.Checked)
                PurchaseOrderPrintDefault.ProductName = Convert.ToInt16(CheckBoxPrintOptions_ProductName.Checked)
                PurchaseOrderPrintDefault.JobComponentNumber = Convert.ToInt16(CheckBoxPrintOptions_JobNumberAndComponent.Checked)
                PurchaseOrderPrintDefault.JobDescription = Convert.ToInt16(CheckBoxPrintOptions_JobDescription.Checked)
                PurchaseOrderPrintDefault.JobComponentDescription = Convert.ToInt16(CheckBoxPrintOptions_JobComponentDescription.Checked)
                PurchaseOrderPrintDefault.FunctionDescription = Convert.ToInt16(CheckBoxPrintOptions_FunctionDescription.Checked)
                PurchaseOrderPrintDefault.UseEmployeeSignature = Convert.ToInt16(CheckBoxPrintOptions_ExcludeEmployeeSignature.Checked)
                PurchaseOrderPrintDefault.UseUserSignature = Convert.ToInt16(CheckBoxPrintOptions_UseLoggedInUserSignature.Checked)
                PurchaseOrderPrintDefault.ReportFormat = ListBoxForm_Reports.SelectedValue

            End If

        End Sub
        Private Sub CreateParameterDictionaryAndUpdatePOsForPrinting()

            'objects
            Dim PurchaseOrderPrintDefault As AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault = Nothing
            Dim IsNewPrintDefault As Boolean = False
            Dim PONumbers As Integer() = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                _ParameterDictionary = New Generic.Dictionary(Of String, Object)

                Select Case ListBoxForm_Reports.SelectedValue

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.StandardFormat).Code

                        _ParameterDictionary("FooterAboveSignature") = False

                    Case AdvantageFramework.EnumUtilities.LoadEnumObject(AdvantageFramework.Reporting.PurchaseOrderReports.FooterAboveSignature).Code

                        _ParameterDictionary("FooterAboveSignature") = True

                End Select

                Try

                    PONumbers = DataGridViewForm_SelectedPurchaseOrders.GetAllSelectedRowsBookmarkValues.OfType(Of Integer).ToArray

                    _ParameterDictionary("PONumbers") = PONumbers

                Catch ex As Exception

                End Try

                PurchaseOrderPrintDefault = AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.LoadByUserCode(DbContext, Me.Session.UserCode)

                If PurchaseOrderPrintDefault Is Nothing Then

                    PurchaseOrderPrintDefault = New AdvantageFramework.Database.Entities.PurchaseOrderPrintDefault
                    IsNewPrintDefault = True

                End If

                FillPurchaseOrderPrintDefault(PurchaseOrderPrintDefault)

                _ParameterDictionary("PrintDefaults") = PurchaseOrderPrintDefault
                _ParameterDictionary("DefaultLocation") = _Location

                If CheckBoxPrintOptions_UsePrintedDate.Checked Then

                    _ParameterDictionary("UsePrintedDate") = DateTimePickerPrintOptions_PrintedDate.ValueObject

                End If

                If CheckBoxPrintOptions_SaveSelections.Checked Then

                    If IsNewPrintDefault Then

                        AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Insert(DbContext, PurchaseOrderPrintDefault)

                    Else

                        AdvantageFramework.Database.Procedures.PurchaseOrderPrintDefault.Update(DbContext, PurchaseOrderPrintDefault)

                    End If

                End If

                DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE [dbo].[PURCHASE_ORDER] SET [PO_PRINTED] = 1 WHERE [PO_NUMBER] IN ({0})", String.Join(",", PONumbers)))

            End Using

        End Sub
        Private Function ValidateBeforePreviewOrPrintOrSend() As Boolean

            'objects
            Dim ParentControl As Object = Nothing
            Dim FailedControl As Object = Nothing
            Dim TabControl As AdvantageFramework.WinForm.Presentation.Controls.TabControl = Nothing
            Dim ReadyForPreviewOrPrintOrSend As Boolean = False

            If Me.Validator Then

                If DataGridViewForm_SelectedPurchaseOrders.HasASelectedRow Then

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

        Public Shared Function ShowFormDialog(ByVal IsUserDefinedReport As Boolean, ByRef ParameterDictionary As Generic.Dictionary(Of String, Object), Optional ByVal AvailablePurchaseOrders() As Integer = Nothing, Optional ByVal SelectedPurchaseOrders() As Integer = Nothing, Optional ByRef Printed As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim PurchaseOrderReportsDialog As AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderReportsDialog = Nothing

            PurchaseOrderReportsDialog = New AdvantageFramework.ProjectManagement.Presentation.PurchaseOrderReportsDialog(IsUserDefinedReport, AvailablePurchaseOrders, SelectedPurchaseOrders, Printed)

            ShowFormDialog = PurchaseOrderReportsDialog.ShowDialog()

            Printed = PurchaseOrderReportsDialog.Printed

            If ShowFormDialog = System.Windows.Forms.DialogResult.OK Then

                ParameterDictionary = PurchaseOrderReportsDialog.ParameterDictionary

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub PurchaseOrderReportsDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            Me.FormAction = WinForm.Presentation.FormActions.Loading

            Me.ShowUnsavedChangesOnFormClosing = False
            Me.ByPassUserEntryChanged = True

            ListBoxForm_Reports.SelectionMode = Windows.Forms.SelectionMode.One

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                SearchableComboBoxPrintOptions_Location.DataSource = AdvantageFramework.Database.Procedures.Location.Load(DataContext)

            End Using

            DateTimePickerPrintOptions_PrintedDate.Value = Now.Date

            Try

                LoadReports()

            Catch ex As Exception

            End Try

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                SelectGridRows()

            Catch ex As Exception

            End Try

            Try

                LoadPrintOptions()

            Catch ex As Exception

            End Try

            DataGridViewForm_SelectedPurchaseOrders.OptionsFind.AllowFindPanel = True

            Me.FormAction = WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub PurchaseOrderReportsDialog_BeforeFormClosing(sender As Object, e As Windows.Forms.FormClosingEventArgs) Handles Me.BeforeFormClosing

            SavePrintOptions()

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

                _Printed = True
                AdvantageFramework.Reporting.Presentation.ReportViewerForm.ShowFormDialog(Me.Session, Reporting.ReportTypes.PurchaseOrderReport, ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

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

                    XtraReport = AdvantageFramework.Reporting.Reports.CreateReport(Me.Session, Reporting.ReportTypes.PurchaseOrderReport, _ParameterDictionary, Nothing, Nothing, Nothing, Nothing)

                    XtraReport.CreateDocument()

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        'If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        '    AgencyImportPath = AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext)

                        '    AgencyImportPath = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AgencyImportPath.Trim, "\")

                        '    If My.Computer.FileSystem.DirectoryExists(AgencyImportPath) Then

                        '        If My.Computer.FileSystem.DirectoryExists(AgencyImportPath & "Reports\") = False Then

                        '            My.Computer.FileSystem.CreateDirectory(AgencyImportPath & "Reports\")

                        '        End If

                        '        AgencyImportPath = AgencyImportPath & "Reports\"

                        '        DefaultFileName = XtraReport.DisplayName & "_" & Now.ToShortDateString.Replace("/", " ").Replace(".", " ") & " " & Now.ToString("HH mm ss")

                        '        XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultFileName = DefaultFileName
                        '        XtraReport.PrintingSystem.ExportOptions.PrintPreview.DefaultDirectory = AgencyImportPath
                        '        XtraReport.PrintingSystem.ExportOptions.PrintPreview.SaveMode = DevExpress.XtraPrinting.SaveMode.UsingDefaultPath
                        '        XtraReport.PrintingSystem.ExportOptions.PrintPreview.ActionAfterExport = DevExpress.XtraPrinting.ActionAfterExport.None

                        '        XtraReport.PrintingSystem.AddCommandHandler(New AdvantageFramework.WinForm.Presentation.Controls.Classes.PrintingSystemCommandHandler(Me.Session, AgencyImportPath, XtraReport.DisplayName))

                        '        'XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.SendFile, DevExpress.XtraPrinting.CommandVisibility.None)
                        '        XtraReport.PrintingSystem.SetCommandVisibility(DevExpress.XtraPrinting.PrintingSystemCommand.ExportHtm, DevExpress.XtraPrinting.CommandVisibility.None)

                        '        XtraReport.ExportToPdf(AgencyImportPath & DefaultFileName & ".pdf")

                        '        AdvantageFramework.WinForm.MessageBox.Show("Your document(s) have been placed on the FTP in the Repository\Out folder.")

                        '    End If

                        'Else

                        Printed = AdvantageFramework.Reporting.Reports.SendToPrinter(XtraReport, True, Me.DefaultLookAndFeel.LookAndFeel, True, False)

                        'End If

                    End Using

                Catch ex As Exception

                End Try

                Me.FormAction = WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

                If Printed = True Then

                    _Printed = True
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

                        _Printed = True
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

            ListBoxForm_Reports.UnSelectAll()
            DataGridViewForm_SelectedPurchaseOrders.CurrentView.ClearSelection()
            SearchableComboBoxPrintOptions_Location.SelectedValue = Nothing
            DateTimePickerPrintOptions_PrintedDate.ValueObject = Nothing

            For Each CheckBox In TabControlPanelPrintOptionsTab_PrintOptions.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.CheckBox)()

                CheckBox.Checked = False

            Next

        End Sub
        Private Sub SearchableComboBoxPrintOptions_Location_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxPrintOptions_Location.EditValueChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                LoadLocationInformation()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxPrintOptions_UsePrintedDate_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPrintOptions_UsePrintedDate.CheckedChanged

            If Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub CheckBoxPrintOptions_ExcludeEmployeeSignature_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxPrintOptions_ExcludeEmployeeSignature.CheckedChanged

            CheckBoxPrintOptions_UseLoggedInUserSignature.Enabled = Not CheckBoxPrintOptions_ExcludeEmployeeSignature.Checked

        End Sub
        Private Sub CheckBoxPrintOptions_UseLoggedInUserSignature_EnabledChanged(sender As Object, e As EventArgs) Handles CheckBoxPrintOptions_UseLoggedInUserSignature.EnabledChanged

            If Not CheckBoxPrintOptions_UseLoggedInUserSignature.Enabled Then

                CheckBoxPrintOptions_UseLoggedInUserSignature.Checked = False

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace