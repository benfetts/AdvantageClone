Namespace Billing.Reports.Presentation

    Public Class InvoicePrintingQuickSelectionDialog

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum InvoiceTypes
            [All]
            [ProductionOnly]
            [MediaOnly]
        End Enum

#End Region

#Region " Variables "

        Private _AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice) = Nothing
        Private _InvoiceType As InvoiceTypes = InvoiceTypes.All

#End Region

#Region " Properties "

        Private ReadOnly Property AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)
            Get
                AccountReceivableInvoices = _AccountReceivableInvoices
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(InvoiceType As InvoiceTypes, Multiselect As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            DataGridViewForm_Invoices.MultiSelect = Multiselect
            DataGridViewForm_Invoices.ShowSelectDeselectAllButtons = Multiselect
            _InvoiceType = InvoiceType

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
                                                                                                                     ButtonItemSearch_Newspaper.Checked, ButtonItemSearch_Internet.Checked, ButtonItemSearch_OutOfHome.Checked, ButtonItemSearch_Radio.Checked, ButtonItemSearch_TV.Checked, False, 0, False).ToList

                    End If

                    AccountReceivableInvoices = AccountReceivableInvoices.Where(Function(Entity) Entity.RecordType <> "C").ToList

                    If Me.Session.HasLimitedOfficeCodes Then

                        AccountReceivableInvoices = (From ARI In AccountReceivableInvoices
                                                     Where Me.Session.AccessibleOfficeCodes.Contains(ARI.OfficeCode) = True
                                                     Select ARI).ToList

                    End If

                    ClientCodes = AdvantageFramework.Database.Procedures.Client.LoadAllActiveByUserCodeWithOfficeLimits(Me.Session, DbContext, SecurityDbContext).Select(Function(Entity) Entity.Code).ToList

                    AccountReceivableInvoices = (From ARI In AccountReceivableInvoices
                                                 Where ClientCodes.Contains(ARI.ClientCode) = True
                                                 Select ARI).ToList

                    DataGridViewForm_Invoices.CurrentView.BeginUpdate()

                    DataGridViewForm_Invoices.DataSource = AccountReceivableInvoices

                    DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

                    DataGridViewForm_Invoices.CurrentView.BestFitColumns()

                    DataGridViewForm_Invoices.CurrentView.EndUpdate()

                End Using

            End Using

        End Sub
        Private Sub EnableOrDisableActions()

            DataGridViewForm_Invoices.OptionsBehavior.Editable = False

            ItemContainerDates_Dates.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            DateTimePickerDates_From.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            DateTimePickerDates_To.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_Production.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_MediaGroup1.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ItemContainerSeach_MediaGroup2.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)
            ButtonItemSearch_Search.Enabled = (ButtonItemSearch_DraftInvoices.Checked = False)

            ButtonItemActions_Select.Enabled = DataGridViewForm_Invoices.HasASelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef AccountReceivableInvoices As Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice), InvoiceType As InvoiceTypes, Multiselect As Boolean) As Windows.Forms.DialogResult

            'objects
            Dim InvoicePrintingQuickSelectionDialog As InvoicePrintingQuickSelectionDialog = Nothing

            InvoicePrintingQuickSelectionDialog = New InvoicePrintingQuickSelectionDialog(InvoiceType, Multiselect)

            ShowFormDialog = InvoicePrintingQuickSelectionDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                AccountReceivableInvoices = InvoicePrintingQuickSelectionDialog.AccountReceivableInvoices

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub InvoicePrintingQuickSelectionDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Select.Image = AdvantageFramework.My.Resources.PrintSelectedReportImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemSearch_Internet.Image = AdvantageFramework.My.Resources.InternetImage
            ButtonItemSearch_Magazine.Image = AdvantageFramework.My.Resources.MagazineOrderImage
            ButtonItemSearch_Newspaper.Image = AdvantageFramework.My.Resources.NewspaperOrdersImage
            ButtonItemSearch_OutOfHome.Image = AdvantageFramework.My.Resources.OutOfHomeOrdersImage
            ButtonItemSearch_Production.Image = AdvantageFramework.My.Resources.ProductionImage
            ButtonItemSearch_Radio.Image = AdvantageFramework.My.Resources.BroadcastOrdersRadioImage
            ButtonItemSearch_TV.Image = AdvantageFramework.My.Resources.BroadcastOrdersTVImage
            ButtonItemSearch_Search.Image = AdvantageFramework.My.Resources.DashboardAndQueryImage
            ButtonItemSearch_DraftInvoices.Image = AdvantageFramework.My.Resources.PrintImage

            DateTimePickerDates_To.ByPassUserEntryChanged = True
            DateTimePickerDates_From.ByPassUserEntryChanged = True

            DateTimePickerDates_From.ValueObject = Nothing
            DateTimePickerDates_To.ValueObject = Nothing

            ButtonItemSearch_Production.FixedSize = New System.Drawing.Size(61, 68)

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            Try

                DataGridViewForm_Invoices.DataSource = New Generic.List(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice)

            Catch ex As Exception

            End Try

            DataGridViewForm_Invoices.MakeColumnVisible(AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice.Properties.InvoiceSequenceNumber.ToString)

            DataGridViewForm_Invoices.CurrentView.BestFitColumns()

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ButtonItemSearch_DraftInvoices.SecurityEnabled = AdvantageFramework.InvoicePrinting.LoadAccountReceivableInvoices(DbContext, Me.Session.UserCode, Now, Now, True, True, True, True, True, True, True, True, 0, False).Any

            End Using

            If _InvoiceType = InvoiceTypes.MediaOnly Then

                ButtonItemSearch_Production.SecurityEnabled = False
                ButtonItemSearch_Production.Checked = False

                ButtonItemSearch_Magazine.SecurityEnabled = True
                ButtonItemSearch_Newspaper.SecurityEnabled = True
                ButtonItemSearch_Internet.SecurityEnabled = True
                ButtonItemSearch_OutOfHome.SecurityEnabled = True
                ButtonItemSearch_Radio.SecurityEnabled = True
                ButtonItemSearch_TV.SecurityEnabled = True

            ElseIf _InvoiceType = InvoiceTypes.ProductionOnly Then

                ButtonItemSearch_Production.SecurityEnabled = True

                ButtonItemSearch_Magazine.SecurityEnabled = False
                ButtonItemSearch_Magazine.Checked = False
                ButtonItemSearch_Newspaper.SecurityEnabled = False
                ButtonItemSearch_Newspaper.Checked = False
                ButtonItemSearch_Internet.SecurityEnabled = False
                ButtonItemSearch_Internet.Checked = False
                ButtonItemSearch_OutOfHome.SecurityEnabled = False
                ButtonItemSearch_OutOfHome.Checked = False
                ButtonItemSearch_Radio.SecurityEnabled = False
                ButtonItemSearch_Radio.Checked = False
                ButtonItemSearch_TV.SecurityEnabled = False
                ButtonItemSearch_TV.Checked = False

            End If

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub InvoicePrintingQuickSelectionDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            'objects
            Dim LastInvoiceDate As Date = Nothing

            If Debugger.IsAttached Then

                DateTimePickerDates_From.Value = CDate("01/01/2002")
                DateTimePickerDates_To.Value = Now

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm("Loading...")

                Try

                    LoadGrid()

                Catch ex As Exception

                End Try

                'DataGridViewForm_Invoices.CurrentView.AFActiveFilterString = "[RecordType] = 'I'"

                If DataGridViewForm_Invoices.MultiSelect Then

                    DataGridViewForm_Invoices.SelectAll()

                End If

                'ButtonItemActions_Print.RaiseClick(DevComponents.DotNetBar.eEventSource.Code)

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            Else

                LastInvoiceDate = LoadLastInvoiceDate(Me.Session)

                DateTimePickerDates_From.Value = LastInvoiceDate
                DateTimePickerDates_To.Value = LastInvoiceDate

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Select_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Select.Click

            If DataGridViewForm_Invoices.HasASelectedRow Then

                _AccountReceivableInvoices = DataGridViewForm_Invoices.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.InvoicePrinting.Classes.AccountReceivableInvoice).ToList

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewForm_Invoices_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewForm_Invoices.SelectionChangedEvent

            EnableOrDisableActions()

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

            If DateTimePickerDates_From.Value = Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select valid start date")
                Search = False

            ElseIf DateTimePickerDates_To.Value = Nothing Then

                AdvantageFramework.WinForm.MessageBox.Show("Please select valid end date")
                Search = False

            ElseIf DateTimePickerDates_To.Value < DateTimePickerDates_From.Value Then

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

        End Sub
        Private Sub ButtonItemSearch_DraftInvoices_CheckedChanged(sender As Object, e As EventArgs) Handles ButtonItemSearch_DraftInvoices.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.Methods.FormActions.None Then

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

#End Region

#End Region

    End Class

End Namespace
