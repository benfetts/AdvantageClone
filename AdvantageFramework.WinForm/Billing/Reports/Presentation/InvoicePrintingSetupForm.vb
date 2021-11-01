Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingSetupForm

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

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadGrid()

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim ClientCodes As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If ButtonItemSearch_DraftInvoices.Checked Then

                        AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, Me.Session.UserCode, DateTimePickerDates_From.Value, DateTimePickerDates_To.Value, True, True, True, True, True, True, True, True, 0, False).ToList

                    Else

                        AccountReceivableInvoices = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, Me.Session.UserCode, DateTimePickerDates_From.Value, DateTimePickerDates_To.Value, ButtonItemSearch_Production.Checked, ButtonItemSearch_Magazine.Checked,
                                                                                                                     ButtonItemSearch_Newspaper.Checked, ButtonItemSearch_Internet.Checked, ButtonItemSearch_OutOfHome.Checked, ButtonItemSearch_Radio.Checked, ButtonItemSearch_TV.Checked,
                                                                                                                     False, NumericInputDates_InvoiceNumber.EditValue, ButtonItemActions_CombineCoopInvoices.Checked).ToList

                    End If

                    If Me.Session.HasLimitedOfficeCodes Then

                        AccountReceivableInvoices = (From ARI In AccountReceivableInvoices
                                                     Where Me.Session.AccessibleOfficeCodes.Contains(ARI.OfficeCode) = True
                                                     Select ARI).ToList

                    End If

					ClientCodes = AdvantageFramework.Database.Procedures.Client.LoadByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Select(Function(Entity) Entity.Code).ToList

					AccountReceivableInvoices = (From ARI In AccountReceivableInvoices
                                                 Where ClientCodes.Contains(ARI.ClientCode) = True
                                                 Select ARI).ToList

                    DataGridViewForm_Invoices.CurrentView.BeginUpdate()

                    DataGridViewForm_Invoices.DataSource = AccountReceivableInvoices

                    If ButtonItemActions_ShowSequenceNumber.Checked = False Then

                        DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

                    Else

                        DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

                    End If

                    If ButtonItemActions_ShowDivisionProductJobComp.Checked = False Then

                        DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                        DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                        DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)

                    Else

                        DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                        DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString).VisibleIndex = 6

                        DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                        DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString).VisibleIndex = 7

                        DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)
                        DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString).VisibleIndex = 8

                    End If

                    If ButtonItemSearch_DraftInvoices.Checked Then

						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DueDate.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceComment.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContactName.ToString)

					Else

						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DueDate.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceComment.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContactName.ToString)

					End If

					If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
						DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

					Else

						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
						DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

					End If

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.LastAutoEmailDate.ToString)

                    DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.LastAutoEmailDate.ToString).FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText

                    DataGridViewForm_Invoices.CurrentView.BestFitColumns()

                    DataGridViewForm_Invoices.CurrentView.EndUpdate()

                End Using

            End Using

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting AndAlso ButtonItemActions_Save.Enabled Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    DataGridViewForm_Invoices.CurrentView.CloseEditorForUpdating()

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.ShowWaitForm("Saving...")
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", AdvantageFramework.WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.CloseWaitForm()
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewForm_Invoices.HasRows Then

                Saved = True

                DataGridViewForm_Invoices.CurrentView.CloseEditorForUpdating()

                AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllModifiedRows.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                Me.ShowWaitForm()
                Me.ShowWaitForm("Saving...")
                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each AccountReceivableInvoice In AccountReceivableInvoices

                            AdvantageFramework.InvoicePrinting.SaveInvoice(DbContext, AccountReceivableInvoice)

                        Next

                    End Using

                Catch ex As Exception
                    Saved = False
                End Try

                AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                If Saved Then

                    Try

                        DataGridViewForm_Invoices.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                End If

                Me.CloseWaitForm()

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            'objects
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ComboInvoiceDefault As AdvantageFramework.Database.Entities.ComboInvoiceDefault = Nothing

            ButtonItemActions_Print.Enabled = DataGridViewForm_Invoices.HasASelectedRow
            ButtonItemActions_PrintPreview.Enabled = DataGridViewForm_Invoices.HasASelectedRow
            ButtonItemInvoiceFormatSettings_Client.Enabled = DataGridViewForm_Invoices.HasOnlyOneSelectedRow

            ButtonItemActions_AutoFill.Enabled = DataGridViewForm_Invoices.HasASelectedRow

            If DataGridViewForm_Invoices.HasOnlyOneSelectedRow AndAlso ComboBoxFormatType_FormatType.GetSelectedValue = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault Then

                Try

                    AccountReceivableInvoice = DataGridViewForm_Invoices.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AccountReceivableInvoice = Nothing
                End Try

                If AccountReceivableInvoice IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If AccountReceivableInvoice.RecordType <> "P" AndAlso AccountReceivableInvoice.RecordType <> "C" Then

                            MediaInvoiceDefault = AdvantageFramework.Database.Procedures.MediaInvoiceDefault.LoadByClientCode(DbContext, AccountReceivableInvoice.ClientCode)

                            If MediaInvoiceDefault IsNot Nothing Then

                                If AccountReceivableInvoice.RecordType = "T" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.TVCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.TVUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                                If AccountReceivableInvoice.RecordType = "N" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.NewspaperCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.NewspaperUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                                If AccountReceivableInvoice.RecordType = "M" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.MagazineCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.MagazineUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                                If AccountReceivableInvoice.RecordType = "R" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.RadioCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.RadioUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                                If AccountReceivableInvoice.RecordType = "O" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.OutOfHomeCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.OutdoorUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                                If AccountReceivableInvoice.RecordType = "I" Then

                                    If String.IsNullOrWhiteSpace(MediaInvoiceDefault.InternetCustomFormat) = False Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                    Else

                                        If MediaInvoiceDefault.InternetUseAgencySetting Then

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                        Else

                                            LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                        End If

                                    End If

                                End If

                            Else

                                LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                            End If

                        ElseIf AccountReceivableInvoice.RecordType = "P" Then

                            ProductionInvoiceDefault = AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.LoadByClientCode(DbContext, AccountReceivableInvoice.ClientCode)

                            If ProductionInvoiceDefault IsNot Nothing Then

                                If String.IsNullOrWhiteSpace(ProductionInvoiceDefault.CustomFormatName) = False Then

                                    LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                Else

                                    If ProductionInvoiceDefault.UseAgencySetting Then

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                                    Else

                                        LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                    End If

                                End If

                            Else

                                LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                            End If

                        ElseIf AccountReceivableInvoice.RecordType = "C" Then

                            ComboInvoiceDefault = AdvantageFramework.Database.Procedures.ComboInvoiceDefault.LoadByClientCode(DbContext, AccountReceivableInvoice.ClientCode)

                            If ComboInvoiceDefault IsNot Nothing Then

                                If String.IsNullOrWhiteSpace(ComboInvoiceDefault.CustomFormatName) = False Then

                                    LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Custom.ToString)

                                Else

                                    LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.Client.ToString)

                                End If

                            Else

                                LabelItemPrintOption_SelectedFormat.Text = AdvantageFramework.EnumUtilities.LoadEnumObjectDescription(GetType(AdvantageFramework.Database.Entities.InvoiceFormats), AdvantageFramework.Database.Entities.InvoiceFormats.AgencyDefault.ToString.Replace("Agency", ""))

                            End If

                        End If

                    End Using

                Else

                    LabelItemPrintOption_SelectedFormat.Text = " "

                End If

            Else

                LabelItemPrintOption_SelectedFormat.Text = " "

            End If

            RibbonBarOptions_PrintOptions.Refresh()

            ButtonItemComments_Job.Enabled = (DataGridViewForm_Invoices.HasASelectedRow AndAlso DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").Any)
            ButtonItemComments_Function.Enabled = (DataGridViewForm_Invoices.HasASelectedRow AndAlso DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").Any)

            ButtonItemSingleFile_SendToDocumentManager.Enabled = DataGridViewForm_Invoices.HasOnlyOneSelectedRow

            ButtonItemPrint_AutoEmail.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)

			ItemContainerDates_Dates.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            DateTimePickerDates_From.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            DateTimePickerDates_To.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_Production.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_MediaGroup1.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_MediaGroup2.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
			ButtonItemSearch_Search.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)

			RibbonBarOptions_Search.RecalcLayout()
			RibbonBarOptions_Search.Refresh()

			RibbonBarOptions_Comments.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)

			DateTimePickerOverrides_DueDate.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
			ButtonItemOverrides_DueDate.Enabled = (DataGridViewForm_Invoices.HasASelectedRow AndAlso ButtonItemSearch_DraftInvoices.Checked = False)
			ButtonItemOverrides_InvoiceDate.Enabled = DataGridViewForm_Invoices.HasASelectedRow

		End Sub
        Private Sub PrintToFile(ByVal ToSingleFile As Boolean, ByVal ToFileOption As AdvantageFramework.InvoicePrinting.ToFileOptions)

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Invoices.HasASelectedRow Then

                        InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                        Try

                            AdvantageFramework.Billing.Reports.Presentation.PrintToFile(Nothing, Me.Session, AccountReceivableInvoices, InvoiceFormatType, ToSingleFile, ToFileOption, ButtonItemSearch_DraftInvoices.Checked, Nothing)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim InvoicePrintingSetupForm As InvoicePrintingSetupForm = Nothing

            InvoicePrintingSetupForm = New InvoicePrintingSetupForm()

            InvoicePrintingSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoicePrintingSetupForm_FormClosed(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

            AdvantageFramework.Reporting.Reports.ClearAllCustomReportsFiles(Me.Session)

        End Sub
        Private Sub InvoicePrintingSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Print.Image = AdvantageFramework.My.Resources.InvoicePrintImage
            ButtonItemActions_PrintPreview.Image = AdvantageFramework.My.Resources.PrintPreviewImage
            ButtonItemActions_ShowSequenceNumber.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage
            ButtonItemActions_ShowDivisionProductJobComp.Image = AdvantageFramework.My.Resources.ShowOnlyColumnDescriptionsImage
            ButtonItemActions_CombineCoopInvoices.Image = AdvantageFramework.My.Resources.InvoiceCoopImage
            ButtonItemActions_AutoFill.Image = AdvantageFramework.My.Resources.AutoFillImage

            ButtonItemOptions_Settings.Image = AdvantageFramework.My.Resources.InvoicePropertiesImage

            ButtonItemPrint_ToFiles.Icon = AdvantageFramework.My.Resources.DocumentManagerIcon
            ButtonItemToFile_SingleFile.Icon = AdvantageFramework.My.Resources.DocumentIcon
            ButtonItemSingleFile_PDF.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportPdf.GetHicon)
            ButtonItemSingleFile_RTF.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportRtf.GetHicon)
            ButtonItemSingleFile_XLS.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportXls.GetHicon)
            ButtonItemSingleFile_XLSX.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportXlsx.GetHicon)
            ButtonItemSingleFile_Image.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportGraphic.GetHicon)
            ButtonItemToFile_SeparateFiles.Icon = AdvantageFramework.My.Resources.DocumentManagerIcon
            ButtonItemSeparateFiles_PDF.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportPdf.GetHicon)
            ButtonItemSeparateFiles_RTF.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportRtf.GetHicon)
            ButtonItemSeparateFiles_XLS.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportXls.GetHicon)
            ButtonItemSeparateFiles_XLSX.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportXlsx.GetHicon)
            ButtonItemSeparateFiles_Image.Icon = System.Drawing.Icon.FromHandle(PrintRibbonControllerResources.RibbonPrintPreview_ExportGraphic.GetHicon)
            ButtonItemPrint_SendEmails.Icon = AdvantageFramework.My.Resources.EmailNewIcon
            ButtonItemPrint_AutoEmail.Icon = AdvantageFramework.My.Resources.EmailSendIcon

            ButtonItemSearch_Internet.Image = AdvantageFramework.My.Resources.InternetImage
            ButtonItemSearch_Magazine.Image = AdvantageFramework.My.Resources.MagazineOrderImage
            ButtonItemSearch_Newspaper.Image = AdvantageFramework.My.Resources.NewspaperOrdersImage
            ButtonItemSearch_OutOfHome.Image = AdvantageFramework.My.Resources.OutOfHomeOrdersImage
            ButtonItemSearch_Production.Image = AdvantageFramework.My.Resources.ProductionImage
            ButtonItemSearch_Radio.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage
            ButtonItemSearch_TV.Image = AdvantageFramework.My.Resources.BroadcastOrdersTVImage
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemSearch_DraftInvoices.Image = AdvantageFramework.My.Resources.PrintImage

            ButtonItemInvoiceFormatSettings_Client.Image = AdvantageFramework.My.Resources.ClientImage
            ButtonItemInvoiceFormatSettings_Agency.Image = AdvantageFramework.My.Resources.AgencyImage
            ButtonItemInvoiceFormatSettings_OneTime.Image = AdvantageFramework.My.Resources.InvoicePropertiesImage

            ButtonItemComments_Job.Icon = AdvantageFramework.My.Resources.InvoicePropertiesIcon
            ButtonItemComments_Function.Icon = AdvantageFramework.My.Resources.InvoicePropertiesIcon

            ButtonItemInvoiceFormatSettings_CustomizeTemplates.Image = AdvantageFramework.My.Resources.AdvantageReportsImage

            DateTimePickerDates_To.ByPassUserEntryChanged = True
            DateTimePickerDates_From.ByPassUserEntryChanged = True

            DateTimePickerOverrides_DueDate.ByPassUserEntryChanged = True
            DateTimePickerOverrides_InvoiceDate.ByPassUserEntryChanged = True

            DateTimePickerDates_From.ValueObject = Nothing
            DateTimePickerDates_To.ValueObject = Nothing

            DateTimePickerOverrides_DueDate.ValueObject = Nothing
            DateTimePickerOverrides_InvoiceDate.ValueObject = Nothing

            ComboBoxFormatType_FormatType.ByPassUserEntryChanged = True

            NumericInputDates_InvoiceNumber.EditValue = Nothing
            NumericInputDates_InvoiceNumber.ByPassUserEntryChanged = True

            ButtonItemSearch_Production.FixedSize = New System.Drawing.Size(61, 68)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 0) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime)

                    End If

                    If AdvantageFramework.Database.Procedures.ProductionInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 1) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency)

                    End If

                    If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 0) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime)

                    End If

                    If AdvantageFramework.Database.Procedures.MediaInvoiceDefault.Load(DbContext).Any(Function(Entity) Entity.ClientOrDefault = 1) = False Then

                        AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency)

                    End If

                End Using

            Catch ex As Exception

            End Try

            ComboBoxFormatType_FormatType.DataSource = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.InvoicePrinting.InvoiceFormatTypes))

            Try

                DataGridViewForm_Invoices.DataSource = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            Catch ex As Exception

            End Try

            Try

                ButtonItemActions_ShowSequenceNumber.Checked = AdvantageFramework.InvoicePrinting.LoadShowSequenceNumberInInvoicePrinting(Me.Session)

            Catch ex As Exception

            End Try

            If ButtonItemActions_ShowSequenceNumber.Checked = False Then

                DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

            Else

                DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

            End If

            Try

                ButtonItemActions_ShowDivisionProductJobComp.Checked = AdvantageFramework.InvoicePrinting.LoadShowDivisionProductJobCompInInvoicePrinting(Me.Session)

            Catch ex As Exception

            End Try

            If ButtonItemActions_ShowDivisionProductJobComp.Checked = False Then

                DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)

            Else

                DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString).VisibleIndex = 6

                DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString).VisibleIndex = 7

                DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)
                DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString).VisibleIndex = 8

            End If

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Try

                    ButtonItemActions_CombineCoopInvoices.Checked = AdvantageFramework.InvoicePrinting.LoadCombineCoopInvoices(DataContext)

                Catch ex As Exception

                End Try

                If ButtonItemActions_CombineCoopInvoices.Checked = False Then

                    ButtonItemActions_ShowDivisionProductJobComp.Enabled = True
                    ButtonItemActions_ShowSequenceNumber.Enabled = True

                Else

                    ButtonItemActions_ShowDivisionProductJobComp.Checked = False
                    ButtonItemActions_ShowSequenceNumber.Checked = False

                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)
                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)

                    ButtonItemActions_ShowDivisionProductJobComp.Enabled = False
                    ButtonItemActions_ShowSequenceNumber.Enabled = False

                End If

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

					DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
					DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
					DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

				Else

					DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyCode.ToString)
					DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyRate.ToString)
					DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.CurrencyAmount.ToString)

				End If

			End Using

            DataGridViewForm_Invoices.CurrentView.BestFitColumns()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemSearch_DraftInvoices.SecurityEnabled = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, Me.Session.UserCode, Now, Now, True, True, True, True, True, True, True, True, 0, True).Any

            End Using

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

        End Sub
        Private Sub InvoicePrintingSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = False

        End Sub
        Private Sub InvoicePrintingSetupForm_UserEntryChangedEvent(Control As AdvantageFramework.WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub InvoicePrintingSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim LastInvoiceDate As Date = Nothing

            EnableOrDisableActions()

            If Debugger.IsAttached Then

                ButtonItemSearch_Production.Checked = True
                ButtonItemSearch_Magazine.Checked = True
                ButtonItemSearch_Newspaper.Checked = True
                ButtonItemSearch_Internet.Checked = True
                ButtonItemSearch_OutOfHome.Checked = True
                ButtonItemSearch_Radio.Checked = True
                ButtonItemSearch_TV.Checked = True

                DateTimePickerDates_From.Value = Now.AddMonths(-2)
                DateTimePickerDates_To.Value = Now

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                'DataGridViewForm_Invoices.CurrentView.AFActiveFilterString = "[RecordType] = 'I'"

                DataGridViewForm_Invoices.SelectAll()

                'ButtonItemActions_Print.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                LastInvoiceDate = AdvantageFramework.Billing.Reports.Presentation.LoadLastInvoiceDate(Me.Session)

                DateTimePickerDates_From.Value = LastInvoiceDate
                DateTimePickerDates_To.Value = LastInvoiceDate

                DateTimePickerOverrides_DueDate.Value = LastInvoiceDate
                DateTimePickerOverrides_InvoiceDate.Value = LastInvoiceDate

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            Save()

        End Sub
        Private Sub ButtonItemActions_PrintPreview_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_PrintPreview.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingComboSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting) = Nothing

			DataGridViewForm_Invoices.CurrentView.CloseEditorForUpdating()

			If CheckForUnsavedChanges() Then

                If DataGridViewForm_Invoices.HasASelectedRow Then

                    If ComboBoxFormatType_FormatType.HasASelectedValue Then

                        AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                        InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            InvoicePrintingSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoiceFormatType).ToList
                            InvoicePrintingMediaSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoiceFormatType).ToList

                            AgencyInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.Agency).FirstOrDefault
                            OneTimeInvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.InvoiceFormatTypes.OneTime).FirstOrDefault

                        End Using

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            InvoicePrintingComboSettings = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoiceFormatType).ToList

                        End Using

                        Me.ClearChanged()

                        InvoiceViewingForm.ShowFormDialog(Me.Session, InvoiceFormatType, AccountReceivableInvoices, InvoicePrintingSettings, InvoicePrintingMediaSettings,
                                                          AgencyInvoicePrintingMediaSetting, OneTimeInvoicePrintingMediaSetting, InvoicePrintingComboSettings, ButtonItemSearch_DraftInvoices.Checked)

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                        Me.ShowWaitForm("Loading...")

                        Try


                            DataGridViewForm_Invoices.CurrentView.RefreshData()

                            EnableOrDisableActions()

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                        Me.CloseWaitForm()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub
        Private Sub ButtonItemPrint_SendEmails_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_SendEmails.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault

            If CheckForUnsavedChanges() Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    If DataGridViewForm_Invoices.HasASelectedRow Then

                        InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                        Try

                            AdvantageFramework.Billing.Reports.Presentation.SendInvoiceEmails(Nothing, Me.Session, AccountReceivableInvoices, InvoiceFormatType, ButtonItemSearch_DraftInvoices.Checked, InvoicePrinting.ToFileOptions.PDF, Nothing)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None


                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            End If

        End Sub
        Private Sub ButtonItemDates_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_YTD.Click

			DateTimePickerDates_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_MTD.Click

			DateTimePickerDates_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_1Year.Click

            DateTimePickerDates_From.Value = Now.AddYears(-1)
            DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemDates_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDates_2Years.Click

            DateTimePickerDates_From.Value = Now.AddYears(-2)
            DateTimePickerDates_To.Value = Now

        End Sub
        Private Sub ButtonItemSearch_Search_Click(sender As Object, e As EventArgs) Handles ButtonItemSearch_Search.Click

            'objects
            Dim Search As Boolean = True

            If CheckForUnsavedChanges() Then

                If DateTimePickerDates_To.Value < DateTimePickerDates_From.Value Then

                    AdvantageFramework.WinForm.MessageBox.Show("End date is less than start date")
                    Search = False

                End If

                If ButtonItemSearch_Internet.Checked = False AndAlso ButtonItemSearch_Magazine.Checked = False AndAlso
                        ButtonItemSearch_Newspaper.Checked = False AndAlso ButtonItemSearch_OutOfHome.Checked = False AndAlso
                        ButtonItemSearch_Production.Checked = False AndAlso ButtonItemSearch_Radio.Checked = False AndAlso
                        ButtonItemSearch_TV.Checked = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("Please select at least one record type")
                    Search = False

                End If

                If Search Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm("Loading...")

                    Try

                        LoadGrid()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Invoices_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewForm_Invoices.CellValueChangingEvent

            If e.Column.FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceDate.ToString Then

                Saved = True

            End If

        End Sub
        Private Sub DataGridViewForm_Invoices_GridViewMouseDownEvent(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles DataGridViewForm_Invoices.GridViewMouseDownEvent

            'objects
            Dim GridHitInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo = Nothing

            If e.Button = Windows.Forms.MouseButtons.Right AndAlso DataGridViewForm_Invoices.HasMultipleSelectedRows Then

                Try

                    GridHitInfo = DataGridViewForm_Invoices.CurrentView.CalcHitInfo(e.Location)

                Catch ex As Exception
                    GridHitInfo = Nothing
                End Try

                If GridHitInfo IsNot Nothing Then

                    If GridHitInfo.HitTest = DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitTest.RowCell Then

                        ButtonItemCM_Invoices.Popup(System.Windows.Forms.Form.MousePosition)

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewForm_Invoices_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewForm_Invoices.QueryPopupNeedDatasourceEvent

            'objects
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing

            If FieldName = AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceContact.ToString Then

                Try

                    AccountReceivableInvoice = DataGridViewForm_Invoices.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AccountReceivableInvoice = Nothing
                End Try

                If AccountReceivableInvoice IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Datasource = AdvantageFramework.Database.Procedures.ClientContact.LoadAllActiveByClientCode(DbContext, AccountReceivableInvoice.ClientCode).ToList

                    End Using

                End If

                OverrideDefaultDatasource = True

            End If

        End Sub
        Private Sub DataGridViewForm_Invoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Invoices.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ComboBoxFormatType_FormatType_SelectedValueChanged(sender As Object, e As EventArgs) Handles ComboBoxFormatType_FormatType.SelectedValueChanged

            If Me.FormShown AndAlso Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemInvoiceFormatSettings_OneTime_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceFormatSettings_OneTime.Click

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim ShowProductionOptions As Boolean = True
            Dim ShowMagazineOptions As Boolean = True
            Dim ShowNewspaperOptions As Boolean = True
            Dim ShowInternetOptions As Boolean = True
            Dim ShowOutdoorOptions As Boolean = True
            Dim ShowRadioOptions As Boolean = True
            Dim ShowTVOptions As Boolean = True
            Dim ShowComboOptions As Boolean = True
            Dim HasSelectedInvoice As Boolean = False

            Try

                AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

            Catch ex As Exception
                AccountReceivableInvoices = Nothing
            End Try

            If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                HasSelectedInvoice = True

                Try

                    ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToList

                Catch ex As Exception

                End Try

                ShowProductionOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "P")
                ShowMagazineOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "M")
                ShowNewspaperOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "N")
                ShowInternetOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "I")
                ShowOutdoorOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "O")
                ShowRadioOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "R")
                ShowTVOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "T")
                ShowComboOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "C")

                If ShowComboOptions Then

                    ShowProductionOptions = True
                    ShowMagazineOptions = True
                    ShowNewspaperOptions = True
                    ShowInternetOptions = True
                    ShowOutdoorOptions = True
                    ShowRadioOptions = True
                    ShowTVOptions = True

                End If

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                InvoicePrintingSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime).FirstOrDefault
                InvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime).FirstOrDefault

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                InvoicePrintingComboSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.OneTime).FirstOrDefault

            End Using

            InvoicePrintingOptionsDialog.ShowFormDialog(InvoicePrinting.InvoiceFormatTypes.OneTime, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                        ClientCodes, ButtonItemSearch_DraftInvoices.Checked, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions,
                                                        ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, HasSelectedInvoice)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInvoiceFormatSettings_Agency_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceFormatSettings_Agency.Click

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim ShowProductionOptions As Boolean = True
            Dim ShowMagazineOptions As Boolean = True
            Dim ShowNewspaperOptions As Boolean = True
            Dim ShowInternetOptions As Boolean = True
            Dim ShowOutdoorOptions As Boolean = True
            Dim ShowRadioOptions As Boolean = True
            Dim ShowTVOptions As Boolean = True
            Dim ShowComboOptions As Boolean = True
            Dim HasSelectedInvoice As Boolean = False

            Try

                AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

            Catch ex As Exception
                AccountReceivableInvoices = Nothing
            End Try

            If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                HasSelectedInvoice = True

                Try

                    ClientCodes = AccountReceivableInvoices.Select(Function(ARI) ARI.ClientCode).Distinct.ToList

                Catch ex As Exception

                End Try

                ShowProductionOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "P")
                ShowMagazineOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "M")
                ShowNewspaperOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "N")
                ShowInternetOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "I")
                ShowOutdoorOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "O")
                ShowRadioOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "R")
                ShowTVOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "T")
                ShowComboOptions = AccountReceivableInvoices.Any(Function(Entity) Entity.RecordType = "C")

                If ShowComboOptions Then

                    ShowProductionOptions = True
                    ShowMagazineOptions = True
                    ShowNewspaperOptions = True
                    ShowInternetOptions = True
                    ShowOutdoorOptions = True
                    ShowRadioOptions = True
                    ShowTVOptions = True

                End If

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                InvoicePrintingSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency).FirstOrDefault
                InvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency).FirstOrDefault

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                InvoicePrintingComboSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.Agency).FirstOrDefault

            End Using

            InvoicePrintingOptionsDialog.ShowFormDialog(InvoicePrinting.InvoiceFormatTypes.Agency, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                        ClientCodes, ButtonItemSearch_DraftInvoices.Checked, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions,
                                                        ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, HasSelectedInvoice)

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemInvoiceFormatSettings_Client_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceFormatSettings_Client.Click

            'objects
            Dim ClientCodes As Generic.List(Of String) = Nothing
            Dim AccountReceivableInvoice As AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice = Nothing
            Dim ProductionInvoiceDefault As AdvantageFramework.Database.Entities.ProductionInvoiceDefault = Nothing
            Dim MediaInvoiceDefault As AdvantageFramework.Database.Entities.MediaInvoiceDefault = Nothing
            Dim ProductionInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.ProductionInvoiceSetting = Nothing
            Dim MediaInvoiceSetting As AdvantageFramework.InvoicePrinting.Classes.MediaInvoiceSetting = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim InvoicePrintingComboSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingComboSetting = Nothing
            Dim AgencyInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim OneTimeInvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim ShowProductionOptions As Boolean = True
            Dim ShowMagazineOptions As Boolean = True
            Dim ShowNewspaperOptions As Boolean = True
            Dim ShowInternetOptions As Boolean = True
            Dim ShowOutdoorOptions As Boolean = True
            Dim ShowRadioOptions As Boolean = True
            Dim ShowTVOptions As Boolean = True
            Dim ShowComboOptions As Boolean = True

            If DataGridViewForm_Invoices.HasOnlyOneSelectedRow Then

                Try

                    AccountReceivableInvoice = DataGridViewForm_Invoices.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    AccountReceivableInvoice = Nothing
                End Try

                If AccountReceivableInvoice IsNot Nothing Then

                    ShowProductionOptions = AccountReceivableInvoice.RecordType = "P"
                    ShowMagazineOptions = AccountReceivableInvoice.RecordType = "M"
                    ShowNewspaperOptions = AccountReceivableInvoice.RecordType = "N"
                    ShowInternetOptions = AccountReceivableInvoice.RecordType = "I"
                    ShowOutdoorOptions = AccountReceivableInvoice.RecordType = "O"
                    ShowRadioOptions = AccountReceivableInvoice.RecordType = "R"
                    ShowTVOptions = AccountReceivableInvoice.RecordType = "T"
                    ShowComboOptions = AccountReceivableInvoice.RecordType = "C"

                    If ShowComboOptions Then

                        ShowProductionOptions = True
                        ShowMagazineOptions = True
                        ShowNewspaperOptions = True
                        ShowInternetOptions = True
                        ShowOutdoorOptions = True
                        ShowRadioOptions = True
                        ShowTVOptions = True

                    End If

                    ClientCodes = New Generic.List(Of String)

                    ClientCodes.Add(AccountReceivableInvoice.ClientCode)

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        InvoicePrintingSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault, AccountReceivableInvoice.ClientCode).FirstOrDefault()
                        InvoicePrintingMediaSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingMediaSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault, AccountReceivableInvoice.ClientCode).FirstOrDefault()

                    End Using

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        InvoicePrintingComboSetting = AdvantageFramework.InvoicePrinting.LoadInvoicePrintingComboSettings(DbContext, InvoicePrinting.Methods.InvoiceFormatTypes.ClientDefault, AccountReceivableInvoice.ClientCode).FirstOrDefault

                    End Using

                    If ShowComboOptions = False Then

                        If (ShowMagazineOptions AndAlso InvoicePrintingMediaSetting.MagazineUseAgencySetting) OrElse
                                (ShowNewspaperOptions AndAlso InvoicePrintingMediaSetting.NewspaperUseAgencySetting) OrElse
                                (ShowInternetOptions AndAlso InvoicePrintingMediaSetting.InternetUseAgencySetting) OrElse
                                (ShowOutdoorOptions AndAlso InvoicePrintingMediaSetting.OutdoorUseAgencySetting) OrElse
                                (ShowRadioOptions AndAlso InvoicePrintingMediaSetting.RadioUseAgencySetting) OrElse
                                (ShowTVOptions AndAlso InvoicePrintingMediaSetting.TVUseAgencySetting) Then

                            InvoicePrintingMediaSetting.AddressBlockType = AgencyInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.AddressBlockType.GetValueOrDefault(1))

                            If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.CustomFormatName) = True Then

                                InvoicePrintingMediaSetting.CustomFormatName = OneTimeInvoicePrintingMediaSetting.CustomFormatName

                            Else

                                InvoicePrintingMediaSetting.CustomFormatName = AgencyInvoicePrintingMediaSetting.CustomFormatName

                            End If

							InvoicePrintingMediaSetting.MagazineCustomInvoiceID = AgencyInvoicePrintingMediaSetting.MagazineCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.MagazineCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.NewspaperCustomInvoiceID = AgencyInvoicePrintingMediaSetting.NewspaperCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.NewspaperCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.InternetCustomInvoiceID = AgencyInvoicePrintingMediaSetting.InternetCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.InternetCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.OutdoorCustomInvoiceID = AgencyInvoicePrintingMediaSetting.OutdoorCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.OutdoorCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.RadioCustomInvoiceID = AgencyInvoicePrintingMediaSetting.RadioCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.RadioCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.TVCustomInvoiceID = AgencyInvoicePrintingMediaSetting.TVCustomInvoiceID.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.TVCustomInvoiceID.GetValueOrDefault(0))
							InvoicePrintingMediaSetting.PrintClientName = AgencyInvoicePrintingMediaSetting.PrintClientName
							InvoicePrintingMediaSetting.PrintDivisionName = AgencyInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintDivisionName.GetValueOrDefault(False))
                            InvoicePrintingMediaSetting.PrintProductDescription = AgencyInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintProductDescription.GetValueOrDefault(False))
                            InvoicePrintingMediaSetting.PrintContactAfterAddress = AgencyInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.PrintContactAfterAddress.GetValueOrDefault(False))
                            InvoicePrintingMediaSetting.ShowCodes = AgencyInvoicePrintingMediaSetting.ShowCodes
                            InvoicePrintingMediaSetting.ContactType = AgencyInvoicePrintingMediaSetting.ContactType
                            InvoicePrintingMediaSetting.IncludeBillingComment = AgencyInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.IncludeBillingComment.GetValueOrDefault(False))
                            InvoicePrintingMediaSetting.ApplyExchangeRate = AgencyInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.ApplyExchangeRate.GetValueOrDefault(1))
                            InvoicePrintingMediaSetting.ExchangeRateAmount = AgencyInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.ExchangeRateAmount.GetValueOrDefault(1))
                            InvoicePrintingMediaSetting.InvoiceFooterCommentType = AgencyInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.InvoiceFooterCommentType.GetValueOrDefault(1))

                            If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.InvoiceFooterComment) = True Then

                                InvoicePrintingMediaSetting.InvoiceFooterComment = OneTimeInvoicePrintingMediaSetting.InvoiceFooterComment

                            Else

                                InvoicePrintingMediaSetting.InvoiceFooterComment = AgencyInvoicePrintingMediaSetting.InvoiceFooterComment

                            End If

                            If String.IsNullOrWhiteSpace(AgencyInvoicePrintingMediaSetting.LocationCode) = True Then

                                InvoicePrintingMediaSetting.LocationCode = OneTimeInvoicePrintingMediaSetting.LocationCode

                            Else

                                InvoicePrintingMediaSetting.LocationCode = AgencyInvoicePrintingMediaSetting.LocationCode

                            End If

                            InvoicePrintingMediaSetting.UseLocationPrintOptions = AgencyInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(OneTimeInvoicePrintingMediaSetting.UseLocationPrintOptions.GetValueOrDefault(False))

                        End If

                    End If

                    InvoicePrintingOptionsDialog.ShowFormDialog(InvoicePrinting.InvoiceFormatTypes.ClientDefault, InvoicePrintingSetting, InvoicePrintingMediaSetting, InvoicePrintingComboSetting,
                                                                ClientCodes, ButtonItemSearch_DraftInvoices.Checked, ShowProductionOptions, ShowMagazineOptions, ShowNewspaperOptions, ShowInternetOptions,
                                                                ShowOutdoorOptions, ShowRadioOptions, ShowTVOptions, ShowComboOptions, True)

                    EnableOrDisableActions()

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice before modifying printing options.")

            End If

        End Sub
        Private Sub ButtonItemComments_Job_Click(sender As Object, e As EventArgs) Handles ButtonItemComments_Job.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewForm_Invoices.HasASelectedRow Then

                Try

                    AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").ToList

                Catch ex As Exception
                    AccountReceivableInvoices = Nothing
                End Try

                If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                    InvoicePrintingCommentsDialog.ShowFormDialog(InvoicePrintingCommentsDialog.Type.JobComment, AccountReceivableInvoices)

                End If

            End If

        End Sub
        Private Sub ButtonItemComments_Function_Click(sender As Object, e As EventArgs) Handles ButtonItemComments_Function.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing

            If DataGridViewForm_Invoices.HasASelectedRow Then

                Try

                    AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().Where(Function(Entity) Entity.RecordType = "P" OrElse Entity.RecordType = "C").ToList

                Catch ex As Exception
                    AccountReceivableInvoices = Nothing
                End Try

                If AccountReceivableInvoices IsNot Nothing AndAlso AccountReceivableInvoices.Count > 0 Then

                    InvoicePrintingCommentsDialog.ShowFormDialog(InvoicePrintingCommentsDialog.Type.JobFunctionComment, AccountReceivableInvoices)

                End If

            End If

        End Sub
        Private Sub ButtonItemInovices_SetInvoiceCategory_Click(sender As Object, e As EventArgs) Handles ButtonItemInovices_SetInvoiceCategory.Click

            'objects
            Dim SelectedInvoiceCategories As IEnumerable = Nothing
            Dim InvoiceCategoryCode As String = Nothing
            Dim RowHandle As Integer = 0

            If DataGridViewForm_Invoices.HasMultipleSelectedRows Then

                If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(AdvantageFramework.WinForm.Presentation.CRUDDialog.Type.InvoiceCategory, True, False, SelectedInvoiceCategories, False) = Windows.Forms.DialogResult.OK Then

                    If SelectedInvoiceCategories IsNot Nothing Then

                        Try

                            InvoiceCategoryCode = (From Entity In SelectedInvoiceCategories
                                                   Select Entity.Code).FirstOrDefault

                        Catch ex As Exception
                            InvoiceCategoryCode = Nothing
                        End Try

                        If String.IsNullOrWhiteSpace(InvoiceCategoryCode) = False Then

                            For Each RowHandle In DataGridViewForm_Invoices.CurrentView.GetSelectedRows

                                DataGridViewForm_Invoices.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceCategoryCode.ToString, InvoiceCategoryCode)

                            Next

                            DataGridViewForm_Invoices.CurrentView.RefreshData()

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonItemInvoiceFormatSettings_CustomizeTemplates_Click(sender As Object, e As EventArgs) Handles ButtonItemInvoiceFormatSettings_CustomizeTemplates.Click

            Try

                If CType(Me.MdiParent, AdvantageFramework.WinForm.Presentation.BaseForms.MDIApplicationForm).CheckFormOpenForm(GetType(AdvantageFramework.Billing.Reports.Presentation.CustomInvoiceReportsForm)) = False Then

                    AdvantageFramework.Billing.Reports.Presentation.CustomInvoiceReportsForm.ShowForm()

                End If

            Catch ex As Exception

            End Try

        End Sub
        Private Sub ButtonItemSeparateFiles_PDF_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_PDF.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub ButtonItemSeparateFiles_RTF_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_RTF.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.RTF)

        End Sub
        Private Sub ButtonItemSeparateFiles_XLS_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_XLS.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.XLS)

        End Sub
        Private Sub ButtonItemSeparateFiles_XLSX_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_XLSX.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX)

        End Sub
        Private Sub ButtonItemSeparateFiles_Image_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_Image.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.Image)

        End Sub
        Private Sub ButtonItemSeparateFiles_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemSeparateFiles_SendToDocumentManager.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager)

        End Sub
        Private Sub ButtonItemSingleFile_PDF_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_PDF.Click

            PrintToFile(True, AdvantageFramework.InvoicePrinting.ToFileOptions.PDF)

        End Sub
        Private Sub ButtonItemSingleFile_RTF_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_RTF.Click

            PrintToFile(True, AdvantageFramework.InvoicePrinting.ToFileOptions.RTF)

        End Sub
        Private Sub ButtonItemSingleFile_XLS_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_XLS.Click

            PrintToFile(True, AdvantageFramework.InvoicePrinting.ToFileOptions.XLS)

        End Sub
        Private Sub ButtonItemSingleFile_XLSX_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_XLSX.Click

            PrintToFile(True, AdvantageFramework.InvoicePrinting.ToFileOptions.XLSX)

        End Sub
        Private Sub ButtonItemSingleFile_Image_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_Image.Click

            PrintToFile(True, AdvantageFramework.InvoicePrinting.ToFileOptions.Image)

        End Sub
        Private Sub ButtonItemSingleFile_SendToDocumentManager_Click(sender As Object, e As EventArgs) Handles ButtonItemSingleFile_SendToDocumentManager.Click

            PrintToFile(False, AdvantageFramework.InvoicePrinting.ToFileOptions.DocumentManager)

        End Sub
        Private Sub ButtonItemPrint_AutoEmail_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_AutoEmail.Click

            'objects
            Dim AllAccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault

            If DataGridViewForm_Invoices.HasASelectedRow Then

                If ComboBoxFormatType_FormatType.HasASelectedValue Then

                    InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                    AllAccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                    AdvantageFramework.Billing.Reports.Presentation.AutoEmailInvoices(Nothing, Me.Session, AllAccountReceivableInvoices, InvoiceFormatType, ButtonItemSearch_DraftInvoices.Checked, InvoicePrinting.ToFileOptions.PDF, Me.DefaultLookAndFeel.LookAndFeel, Nothing)

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

            End If

        End Sub
        Private Sub ButtonItemPrint_QuickPrint_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_QuickPrint.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False

            If CheckForUnsavedChanges() Then

                If DataGridViewForm_Invoices.HasASelectedRow Then

                    If ComboBoxFormatType_FormatType.HasASelectedValue Then

                        InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                        Try

                            AdvantageFramework.Billing.Reports.Presentation.QuickPrintInvoices(Nothing, Me.Session, AccountReceivableInvoices, InvoiceFormatType, ButtonItemSearch_DraftInvoices.Checked, Me.DefaultLookAndFeel.LookAndFeel, Nothing)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub
        Private Sub ButtonItemPrint_Print_Click(sender As Object, e As EventArgs) Handles ButtonItemPrint_Print.Click

            'objects
            Dim AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
            Dim InvoiceFormatType As AdvantageFramework.InvoicePrinting.InvoiceFormatTypes = AdvantageFramework.InvoicePrinting.InvoiceFormatTypes.ClientDefault
            Dim InvoicePrintingSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting) = Nothing
            Dim InvoicePrintingMediaSettings As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting) = Nothing
            Dim InvoicePrintingSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingSetting = Nothing
            Dim InvoicePrintingMediaSetting As AdvantageFramework.InvoicePrinting.Classes.InvoicePrintingMediaSetting = Nothing
            Dim Report As DevExpress.XtraReports.UI.XtraReport = Nothing
            Dim AgencyReportFolder As String = ""
            Dim IsCustomReport As Boolean = False

            If CheckForUnsavedChanges() Then

                If DataGridViewForm_Invoices.HasASelectedRow Then

                    If ComboBoxFormatType_FormatType.HasASelectedValue Then

                        InvoiceFormatType = ComboBoxFormatType_FormatType.GetSelectedValue

                        AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)().ToList

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Printing

                        Try

                            AdvantageFramework.Billing.Reports.Presentation.PrintInvoices(Nothing, Me.Session, AccountReceivableInvoices, InvoiceFormatType, ButtonItemSearch_DraftInvoices.Checked, Me.DefaultLookAndFeel.LookAndFeel, Nothing)

                        Catch ex As Exception

                        End Try

                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select a format type.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please select an invoice.")

                End If

            End If

        End Sub
        Private Sub ButtonItemOverrides_DueDate_Click(sender As Object, e As EventArgs) Handles ButtonItemOverrides_DueDate.Click

            If DataGridViewForm_Invoices.HasASelectedRow AndAlso DateTimePickerOverrides_DueDate.Value <> Nothing Then

                For Each KeyValuePair In DataGridViewForm_Invoices.GetAllSelectedRowsRowHandlesAndDataBoundItems

                    CType(KeyValuePair.Value, AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).DueDate = DateTimePickerOverrides_DueDate.Value

                    DataGridViewForm_Invoices.AddToModifiedRows(KeyValuePair.Key)

                Next

                DataGridViewForm_Invoices.CurrentView.RefreshData()

                DataGridViewForm_Invoices.SetUserEntryChanged()

                Me.RaiseUserEntryChangedEvent(DataGridViewForm_Invoices)

            End If

        End Sub
        Private Sub ButtonItemOverrides_InvoiceDate_Click(sender As Object, e As EventArgs) Handles ButtonItemOverrides_InvoiceDate.Click

            If DataGridViewForm_Invoices.HasASelectedRow AndAlso DateTimePickerOverrides_InvoiceDate.Value <> Nothing Then

                For Each AccountReceivableInvoice In DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ToList

                    AccountReceivableInvoice.InvoiceDate = DateTimePickerOverrides_InvoiceDate.Value

                Next

                DataGridViewForm_Invoices.CurrentView.RefreshData()

            End If

        End Sub
        Private Sub ButtonItemActions_ShowSequenceNumber_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowSequenceNumber.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemActions_ShowSequenceNumber.Checked = Not ButtonItemActions_ShowSequenceNumber.Checked

                Try

                    AdvantageFramework.InvoicePrinting.SaveShowSequenceNumberInInvoicePrinting(Me.Session, ButtonItemActions_ShowSequenceNumber.Checked)

                Catch ex As Exception

                End Try

                If ButtonItemActions_ShowSequenceNumber.Checked = False Then

                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

                Else

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

                    DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString).VisibleIndex = 1

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_ShowDivisionProductJobComp_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_ShowDivisionProductJobComp.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemActions_ShowDivisionProductJobComp.Checked = Not ButtonItemActions_ShowDivisionProductJobComp.Checked

                Try

                    AdvantageFramework.InvoicePrinting.SaveShowDivisionProductJobCompInInvoicePrinting(Me.Session, ButtonItemActions_ShowDivisionProductJobComp.Checked)

                Catch ex As Exception

                End Try

                If ButtonItemActions_ShowDivisionProductJobComp.Checked = False Then

                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                    DataGridViewForm_Invoices.MakeColumnNotVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)

                Else

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString)
                    DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.DivisionName.ToString).VisibleIndex = 6

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString)
                    DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.ProductName.ToString).VisibleIndex = 7

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString)
                    DataGridViewForm_Invoices.Columns(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.JobComponent.ToString).VisibleIndex = 8

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_CombineCoopInvoices_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_CombineCoopInvoices.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                ButtonItemActions_CombineCoopInvoices.Checked = Not ButtonItemActions_CombineCoopInvoices.Checked

                Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    Try

                        AdvantageFramework.InvoicePrinting.SaveCombineCoopInvoices(DataContext, ButtonItemActions_CombineCoopInvoices.Checked)

                    Catch ex As Exception

                    End Try

                End Using

                If ButtonItemActions_CombineCoopInvoices.Checked = False Then

                    ButtonItemActions_ShowDivisionProductJobComp.Enabled = True
                    ButtonItemActions_ShowSequenceNumber.Enabled = True

                Else

                    ButtonItemActions_ShowDivisionProductJobComp.Checked = False
                    ButtonItemActions_ShowSequenceNumber.Checked = False

                    ButtonItemActions_ShowDivisionProductJobComp.Enabled = False
                    ButtonItemActions_ShowSequenceNumber.Enabled = False

                End If

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemSearch_DraftInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearch_DraftInvoices.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

                If ButtonItemSearch_DraftInvoices.Checked Then

                    ButtonItemActions_CombineCoopInvoices.Enabled = False

                Else

                    ButtonItemActions_CombineCoopInvoices.Enabled = True

                End If

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonItemOptions_Settings_Click(sender As Object, e As EventArgs) Handles ButtonItemOptions_Settings.Click

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                AdvantageFramework.Billing.Reports.Presentation.InvoicePrintingCoversheetOptionsDialog.ShowFormDialog()

            End If

        End Sub
        Private Sub ButtonItemActions_AutoFill_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_AutoFill.Click

            'objects
            Dim SelectedItems As IEnumerable = Nothing
            Dim ModifiedDictonary As Generic.Dictionary(Of Integer, Object) = Nothing

            DataGridViewForm_Invoices.CurrentView.CloseEditorForUpdating()

            SelectedItems = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ToList

            ModifiedDictonary = DataGridViewForm_Invoices.GetAllSelectedRowsRowHandlesAndDataBoundItems()

            If AdvantageFramework.WinForm.Presentation.AutoFillDialog.ShowFormDialog(SelectedItems, DataGridViewForm_Invoices.GetFirstSelectedRowDataBoundItem) = Windows.Forms.DialogResult.OK Then

                For Each KeyValuePair In ModifiedDictonary

                    DataGridViewForm_Invoices.AddToModifiedRows(KeyValuePair.Key)

                Next

                DataGridViewForm_Invoices.CurrentView.RefreshData()

                DataGridViewForm_Invoices.SetUserEntryChanged()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
