Namespace FinanceAndAccounting.Presentation

    Public Class AccountsPayableInitialLoadingDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _Value As Object = Nothing
        Private _Criteria As Integer = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property Value As Object
            Get
                Value = _Value
            End Get
        End Property
        'Private ReadOnly Property [From] As Date
        '    Get
        '        [From] = DateTimePickerPanelDates_From.Value
        '    End Get
        'End Property
        'Private ReadOnly Property [To] As Date
        '    Get
        '        [To] = DateTimePickerPanelDates_To.Value
        '    End Get
        'End Property
        Private ReadOnly Property Criteria As Integer
            Get
                Criteria = _Criteria
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal Criteria As Integer)

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ComboBoxForm_Criteria.ByPassUserEntryChanged = True

            DateTimePickerPanelDates_From.ByPassUserEntryChanged = True
            DateTimePickerPanelDates_To.ByPassUserEntryChanged = True
            SearchableComboBoxForm_Criteria.ByPassUserEntryChanged = True
            TextBoxForm_Criteria.ByPassUserEntryChanged = True
            NumericInputForm_Criteria.ByPassUserEntryChanged = True
            ComboBoxForm_CriteriaSelection.ByPassUserEntryChanged = True

            _Criteria = Criteria

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef Value As Object, ByRef Criteria As Integer) As Windows.Forms.DialogResult

            'objects
            Dim AccountsPayableInitialLoadingDialog As AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableInitialLoadingDialog = Nothing

            AccountsPayableInitialLoadingDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.AccountsPayableInitialLoadingDialog(Criteria)

            ShowFormDialog = AccountsPayableInitialLoadingDialog.ShowDialog()

            Criteria = AccountsPayableInitialLoadingDialog.Criteria
            Value = AccountsPayableInitialLoadingDialog.Value
            '[From] = AccountsPayableInitialLoadingDialog.[From]
            '[To] = AccountsPayableInitialLoadingDialog.[To]

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub AccountsPayableInitialLoadingDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerPanelDates_From.Value = Now
            DateTimePickerPanelDates_To.Value = Now

            ComboBoxForm_Criteria.DataSource = ((From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.AccountPayable.InvoiceDetailCriteria))
                                                 Select Entity.Description).ToArray)

            ComboBoxForm_Criteria.SelectedIndex = _Criteria

            ComboBoxForm_Criteria.SetRequired(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            Dim ErrorMessage As String = ""

            If Me.Validator Then

                _Criteria = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.AccountPayable.InvoiceDetailCriteria))
                             Where (Entity.Description = ComboBoxForm_Criteria.SelectedValue)
                             Select Entity.Code).SingleOrDefault

                Select Case _Criteria

                    Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.GLACode

                        _Value = SearchableComboBoxForm_Criteria.GetSelectedValue

                    Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.PONumber, AdvantageFramework.AccountPayable.InvoiceDetailCriteria.JobNumber

                        _Value = CInt(SearchableComboBoxForm_Criteria.GetSelectedValue)

                    Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.OrderNumber

                        _Value = NumericInputForm_Criteria.EditValue

                    Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.ApprovalStatus

                        _Value = ComboBoxForm_CriteriaSelection.GetSelectedValue

                End Select

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    If LastFailedValidationResult.Validator.ErrorMessage.Contains("Enum Data") OrElse LastFailedValidationResult.Validator.ErrorMessage.Trim = "is required." Then

                        ErrorMessage &= "Please select valid criteria." & vbCrLf

                    Else

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    End If

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub ButtonForm_YTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_YTD.Click

			DateTimePickerPanelDates_From.Value = New Date(Now.Year, 1, 1)
			DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_MTD_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_MTD.Click

			DateTimePickerPanelDates_From.Value = New Date(Now.Year, Now.Month, 1)
			DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_1Year_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_1Year.Click

            DateTimePickerPanelDates_From.Value = Now.AddYears(-1)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub ButtonForm_2Years_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonPanelDates_2Years.Click

            DateTimePickerPanelDates_From.Value = Now.AddYears(-2)
            DateTimePickerPanelDates_To.Value = Now

        End Sub
        Private Sub DateTimePickerForm_To_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerPanelDates_To.ValueChanged

            DateTimePickerPanelDates_From.MaxDate = DateTimePickerPanelDates_To.Value

        End Sub
        Private Sub DateTimePickerForm_From_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DateTimePickerPanelDates_From.ValueChanged

            DateTimePickerPanelDates_To.MinDate = DateTimePickerPanelDates_From.Value

        End Sub
		Private Sub ComboBoxForm_Criteria_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBoxForm_Criteria.SelectedValueChanged

			Dim Criteria As String = Nothing

            PanelForm_Dates.Visible = False
            SearchableComboBoxForm_Criteria.Visible = False
            TextBoxForm_Criteria.Visible = False
            NumericInputForm_Criteria.Visible = False
            ComboBoxForm_CriteriaSelection.Visible = False

            NumericInputForm_Criteria.SetRequired(False)
            TextBoxForm_Criteria.SetRequired(False)
            DateTimePickerPanelDates_From.SetRequired(False)
            DateTimePickerPanelDates_To.SetRequired(False)
            ComboBoxForm_CriteriaSelection.SetRequired(False)
            SearchableComboBoxForm_Criteria.SetRequired(False)

            If ComboBoxForm_Criteria.SelectedValue IsNot Nothing Then

                Try

                    Criteria = (From Entity In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.AccountPayable.InvoiceDetailCriteria))
                                Where (Entity.Description = ComboBoxForm_Criteria.SelectedValue)
                                Select Entity.Code).SingleOrDefault

                Catch ex As Exception
                    Criteria = Nothing
                End Try

                If Criteria IsNot Nothing Then

                    SearchableComboBoxForm_Criteria.DataSource = Nothing

                    SearchableComboBoxForm_Criteria.SelectedValue = Nothing

                    Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        Select Case Criteria

                            Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.OrderNumber

                                NumericInputForm_Criteria.SetFormat("f0")
                                NumericInputForm_Criteria.Visible = True
                                NumericInputForm_Criteria.SetRequired(True)

                            Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.PONumber

                                SearchableComboBoxForm_Criteria.SetRequired(True)
                                SearchableComboBoxForm_Criteria.Visible = True
                                SearchableComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.PurchaseOrder
                                SearchableComboBoxForm_Criteria.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders)

                                SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.AccountPayable.GetOpenPurchaseOrders(DbContext, DbContext.UserCode, IncludeJobProcessControl:=False, IncludeCompletedPOs:=True).OrderByDescending(Function(PO) PO.Number)

                                If SearchableComboBoxForm_Criteria.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders.Properties.POComplete.ToString) IsNot Nothing Then

                                    SearchableComboBoxForm_Criteria.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableProductionPurchaseOrders.Properties.POComplete.ToString).Visible = True

                                End If

                                SearchableComboBoxForm_Criteria.Properties.View.ActiveFilterString = "[POComplete] = False"

                            Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.JobNumber

                                SearchableComboBoxForm_Criteria.SetRequired(True)
                                SearchableComboBoxForm_Criteria.Visible = True
                                SearchableComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.Job
                                SearchableComboBoxForm_Criteria.Properties.ValueMember = "Number"
                                SearchableComboBoxForm_Criteria.DataSource = New Generic.List(Of AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs)

                                SearchableComboBoxForm_Criteria.Properties.ValueMember = AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.Number.ToString
                                SearchableComboBoxForm_Criteria.DataSource = AdvantageFramework.AccountPayable.GetAvailableProductionJobs(DbContext, DbContext.UserCode, Nothing, Nothing, Nothing, Nothing, True)

                                If SearchableComboBoxForm_Criteria.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.IsClosed.ToString) IsNot Nothing Then

                                    SearchableComboBoxForm_Criteria.Properties.View.Columns(AdvantageFramework.AccountPayable.Classes.AccountPayableAvailableProductionJobs.Properties.IsClosed.ToString).Visible = True

                                End If

                                SearchableComboBoxForm_Criteria.Properties.View.ActiveFilterString = "[IsClosed] = False"

                            Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.GLACode

                                SearchableComboBoxForm_Criteria.SetRequired(True)
                                SearchableComboBoxForm_Criteria.Visible = True
                                SearchableComboBoxForm_Criteria.ControlType = AdvantageFramework.WinForm.Presentation.Controls.SearchableComboBox.Type.GeneralLedgerAccount
                                SearchableComboBoxForm_Criteria.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.GeneralLedgerAccount)

                                SearchableComboBoxForm_Criteria.DataSource = (From GeneralLedgerAccount In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActiveWithOfficeLimits(DbContext, Session)
                                                                              Select GeneralLedgerAccount.Code,
                                                                                     GeneralLedgerAccount.Description).ToList.Select(Function(GeneralLedgerAccount) New With {.Code = GeneralLedgerAccount.Code,
                                                                                                                                                                              .Description = GeneralLedgerAccount.Description}).ToList

                            Case AdvantageFramework.AccountPayable.InvoiceDetailCriteria.ApprovalStatus

                                ComboBoxForm_CriteriaSelection.SetRequired(True)
                                ComboBoxForm_CriteriaSelection.Visible = True
                                ComboBoxForm_CriteriaSelection.DataSource = (From EnumObject In AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.MediaApprovalStatus)).ToList
                                                                             Select [Name] = EnumObject.Description,
                                                                                    [Value] = EnumObject.Code).ToList

                        End Select

                    End Using

                End If

            End If

        End Sub
		Private Sub SearchableComboBoxForm_Criteria_Popup(sender As Object, e As EventArgs) Handles SearchableComboBoxForm_Criteria.Popup

			If ComboBoxForm_Criteria.SelectedValue = "Job Number" Then

				DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.ActiveFilterString = "[IsClosed] = False"

			ElseIf ComboBoxForm_Criteria.SelectedValue = "Purchase Order" Then

				DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.ActiveFilterString = "[POComplete] = False"

			Else

				DirectCast(sender, DevExpress.XtraEditors.SearchLookUpEdit).Properties.View.ActiveFilterString = ""

			End If

		End Sub

#End Region

#End Region

    End Class

End Namespace