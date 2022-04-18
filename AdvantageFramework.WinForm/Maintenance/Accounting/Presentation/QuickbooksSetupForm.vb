Namespace Maintenance.Accounting.Presentation

    Public Class QuickbooksSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _QuickBooksSetting As AdvantageFramework.Quickbooks.Classes.QuickBooksSetting = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub Save()

            Dim ErrorMessage As String = Nothing

            _QuickBooksSetting.InvoiceEmployeeTimeItem = SearchableComboBoxFunction_EmployeeTime.GetSelectedValue
            _QuickBooksSetting.InvoiceProductionItem = SearchableComboBoxFunction_ProductionVendorCost.GetSelectedValue
            _QuickBooksSetting.InvoiceIncomeOnlyItem = SearchableComboBoxFunction_IncomeOnly.GetSelectedValue
            _QuickBooksSetting.InvoiceOrderItem = SearchableComboBoxMedia_Order.GetSelectedValue

            _QuickBooksSetting.InvoiceNumberSuffix = TextBoxForm_InvoiceSuffix.GetText

            _QuickBooksSetting.InvoiceLineProductionSalesClass = CheckBoxInvoiceProduction_IncludeSalesClass.Checked
            _QuickBooksSetting.InvoiceLineProductionJobNumber = CheckBoxInvoiceProduction_IncludeJobNumber.Checked
            _QuickBooksSetting.InvoiceLineProductionComponentNumber = CheckBoxInvoiceProduction_IncludeComponentNumber.Checked
            _QuickBooksSetting.InvoiceLineProductionJobDescription = CheckBoxInvoiceProduction_IncludeJobDescription.Checked
            _QuickBooksSetting.InvoiceLineProductionComponentDescription = CheckBoxInvoiceProduction_IncludeComponentDescription.Checked
            _QuickBooksSetting.InvoiceLineProductionFunctionDescription = CheckBoxInvoiceProduction_IncludeFunctionDescription.Checked

            _QuickBooksSetting.InvoiceLineMediaSalesClass = CheckBoxInvoiceMedia_IncludeSalesClass.Checked
            _QuickBooksSetting.InvoiceLineMediaOrderNumber = CheckBoxInvoiceMedia_IncludeOrderNumber.Checked
            _QuickBooksSetting.InvoiceLineMediaOrderLineNumber = CheckBoxInvoiceMedia_IncludeOrderLineNumber.Checked

            _QuickBooksSetting.BillMediaAccount = SearchableComboBoxBill_Media.GetSelectedValue
            _QuickBooksSetting.BillNonClientAccount = SearchableComboBoxBill_NonClient.GetSelectedValue
            _QuickBooksSetting.BillProductionAccount = SearchableComboBoxBill_Production.GetSelectedValue

            If AdvantageFramework.Quickbooks.SaveSettings(Me.Session, _QuickBooksSetting, ErrorMessage) Then

                AdvantageFramework.WinForm.MessageBox.Show("Settings saved.")
                Me.ClearChanged()

            ElseIf String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                AdvantageFramework.WinForm.MessageBox.Show("An error occurred: " & ErrorMessage)

            End If

        End Sub
        Private Function AtLeastOneProductionIncludeChecked() As Boolean

            Dim IsOkay As Boolean = False

            For Each Control In Me.GroupBoxInvoiceProduction_Include.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If Control.Checked Then

                    IsOkay = True
                    Exit For

                End If

            Next

            AtLeastOneProductionIncludeChecked = IsOkay

        End Function
        Private Function AtLeastOneMediaIncludeChecked() As Boolean

            Dim IsOkay As Boolean = False

            For Each Control In Me.GroupBoxInvoiceMedia_Include.Controls.OfType(Of AdvantageFramework.WinForm.MVC.Presentation.Controls.CheckBox)

                If Control.Checked Then

                    IsOkay = True
                    Exit For

                End If

            Next

            AtLeastOneMediaIncludeChecked = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim QuickbooksSetupForm As Presentation.QuickbooksSetupForm = Nothing

            QuickbooksSetupForm = New Presentation.QuickbooksSetupForm()

            QuickbooksSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub QuickbooksSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub QuickbooksSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            Me.SearchableComboBoxFunction_EmployeeTime.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Id.ToString
            Me.SearchableComboBoxFunction_EmployeeTime.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Name.ToString
            Me.SearchableComboBoxFunction_EmployeeTime.SetRequired(True)
            Me.SearchableComboBoxFunction_EmployeeTime.HideValueMemberColumn = True

            Me.SearchableComboBoxFunction_IncomeOnly.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Id.ToString
            Me.SearchableComboBoxFunction_IncomeOnly.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Name.ToString
            Me.SearchableComboBoxFunction_IncomeOnly.SetRequired(True)
            Me.SearchableComboBoxFunction_IncomeOnly.HideValueMemberColumn = True

            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Id.ToString
            Me.SearchableComboBoxFunction_ProductionVendorCost.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Name.ToString
            Me.SearchableComboBoxFunction_ProductionVendorCost.SetRequired(True)
            Me.SearchableComboBoxFunction_ProductionVendorCost.HideValueMemberColumn = True

            Me.SearchableComboBoxMedia_Order.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Id.ToString
            Me.SearchableComboBoxMedia_Order.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Item.Properties.Name.ToString
            Me.SearchableComboBoxMedia_Order.SetRequired(True)
            Me.SearchableComboBoxMedia_Order.HideValueMemberColumn = True

            Me.TextBoxForm_InvoiceSuffix.MaxLength = 5
            Me.TextBoxForm_InvoiceSuffix.SetRequired(True)

            Me.SearchableComboBoxBill_Media.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Id.ToString
            Me.SearchableComboBoxBill_Media.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Name.ToString
            Me.SearchableComboBoxBill_Media.SetRequired(True)
            Me.SearchableComboBoxBill_Media.HideValueMemberColumn = True

            Me.SearchableComboBoxBill_NonClient.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Id.ToString
            Me.SearchableComboBoxBill_NonClient.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Name.ToString
            Me.SearchableComboBoxBill_NonClient.SetRequired(True)
            Me.SearchableComboBoxBill_NonClient.HideValueMemberColumn = True

            Me.SearchableComboBoxBill_Production.Properties.ValueMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Id.ToString
            Me.SearchableComboBoxBill_Production.Properties.DisplayMember = AdvantageFramework.Quickbooks.Classes.Account.Properties.Name.ToString
            Me.SearchableComboBoxBill_Production.SetRequired(True)
            Me.SearchableComboBoxBill_Production.HideValueMemberColumn = True

        End Sub
        Private Sub QuickbooksSetupForm_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            Dim ErrorMessage As String = Nothing
            Dim Items As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Item) = Nothing
            Dim Accounts As Generic.List(Of AdvantageFramework.Quickbooks.Classes.Account) = Nothing

            Me.ShowWaitForm("..Loading")

            If AdvantageFramework.Quickbooks.GetSettings(Me.Session, Items, Accounts, _QuickBooksSetting, ErrorMessage) Then

                SearchableComboBoxFunction_EmployeeTime.DataSource = Items
                SearchableComboBoxFunction_IncomeOnly.DataSource = Items
                SearchableComboBoxFunction_ProductionVendorCost.DataSource = Items
                SearchableComboBoxMedia_Order.DataSource = Items

                SearchableComboBoxBill_Media.DataSource = Accounts
                SearchableComboBoxBill_NonClient.DataSource = Accounts
                SearchableComboBoxBill_Production.DataSource = Accounts

                SearchableComboBoxFunction_EmployeeTime.SelectedValue = _QuickBooksSetting.InvoiceEmployeeTimeItem
                SearchableComboBoxFunction_ProductionVendorCost.SelectedValue = _QuickBooksSetting.InvoiceProductionItem
                SearchableComboBoxFunction_IncomeOnly.SelectedValue = _QuickBooksSetting.InvoiceIncomeOnlyItem
                SearchableComboBoxMedia_Order.SelectedValue = _QuickBooksSetting.InvoiceOrderItem

                TextBoxForm_InvoiceSuffix.Text = _QuickBooksSetting.InvoiceNumberSuffix

                CheckBoxInvoiceProduction_IncludeSalesClass.Checked = _QuickBooksSetting.InvoiceLineProductionSalesClass
                CheckBoxInvoiceProduction_IncludeJobNumber.Checked = _QuickBooksSetting.InvoiceLineProductionJobNumber
                CheckBoxInvoiceProduction_IncludeComponentNumber.Checked = _QuickBooksSetting.InvoiceLineProductionComponentNumber
                CheckBoxInvoiceProduction_IncludeJobDescription.Checked = _QuickBooksSetting.InvoiceLineProductionJobDescription
                CheckBoxInvoiceProduction_IncludeComponentDescription.Checked = _QuickBooksSetting.InvoiceLineProductionComponentDescription
                CheckBoxInvoiceProduction_IncludeFunctionDescription.Checked = _QuickBooksSetting.InvoiceLineProductionFunctionDescription

                CheckBoxInvoiceMedia_IncludeSalesClass.Checked = _QuickBooksSetting.InvoiceLineMediaSalesClass
                CheckBoxInvoiceMedia_IncludeOrderNumber.Checked = _QuickBooksSetting.InvoiceLineMediaOrderNumber
                CheckBoxInvoiceMedia_IncludeOrderLineNumber.Checked = _QuickBooksSetting.InvoiceLineMediaOrderLineNumber

                SearchableComboBoxBill_Media.SelectedValue = _QuickBooksSetting.BillMediaAccount
                SearchableComboBoxBill_NonClient.SelectedValue = _QuickBooksSetting.BillNonClientAccount
                SearchableComboBoxBill_Production.SelectedValue = _QuickBooksSetting.BillProductionAccount

            Else

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

            Me.ClearChanged()

            Me.CloseWaitForm()

        End Sub
        Private Sub QuickbooksSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_Save_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            Dim ErrorMessage As String = String.Empty

            If Me.Validator Then

                If AtLeastOneProductionIncludeChecked() = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("At least one production include must be checked.")

                ElseIf AtLeastOneMediaIncludeChecked() = False Then

                    AdvantageFramework.WinForm.MessageBox.Show("At least one media include must be checked.")

                Else

                    Save()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click


        End Sub

#End Region

#End Region

    End Class

End Namespace
