Namespace Maintenance.Accounting.Presentation

    Public Class CurrencyCodeSetupForm

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

            Dim CurrencyCodeHome As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) Then

                    CurrencyCodeHome = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)

                    DataGridViewLeftSection_Currencies.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Currency.Load(DbContext)
                                                                     Where Entity.CurrencyCode <> CurrencyCodeHome
                                                                     Select Entity).ToList

                Else

                    DataGridViewLeftSection_Currencies.DataSource = AdvantageFramework.Database.Procedures.Currency.Load(DbContext).ToList

                End If

            End Using

            DataGridViewLeftSection_Currencies.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadSelectedItemDetails()

            CurrencyCodeRightSection_CurrencyCode.ClearControl()

            CurrencyCodeRightSection_CurrencyCode.Enabled = DataGridViewLeftSection_Currencies.HasOnlyOneSelectedRow

            If CurrencyCodeRightSection_CurrencyCode.Enabled Then

                CurrencyCodeRightSection_CurrencyCode.Enabled = CurrencyCodeRightSection_CurrencyCode.LoadControl(DataGridViewLeftSection_Currencies.GetFirstSelectedRowBookmarkValue)

            End If

            Me.ClearChanged()

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Delete.Enabled = DataGridViewLeftSection_Currencies.HasOnlyOneSelectedRow
            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

            ButtonItemDetails_Cancel.Enabled = (CurrencyCodeRightSection_CurrencyCode.Enabled AndAlso CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsIsNewItemRow(CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsFocusedRowHandle))
            ButtonItemDetails_Delete.Enabled = CurrencyCodeRightSection_CurrencyCode.Enabled

            CurrencyCodeRightSection_CurrencyCode.Enabled = (DataGridViewLeftSection_Currencies.HasOnlyOneSelectedRow AndAlso Me.FormShown)

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            CurrencyCodeRightSection_CurrencyCode.Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim CurrencyCodeSetupForm As AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeSetupForm = Nothing

            CurrencyCodeSetupForm = New AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeSetupForm()

            CurrencyCodeSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub CurrencyCodeSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage
            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Refresh.Image = AdvantageFramework.My.Resources.RefreshImage

            ButtonItemExchangeRates_GetCurrentRates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage

            ButtonItemDetails_Delete.Image = AdvantageFramework.My.Resources.DetailDeleteImage
            ButtonItemDetails_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            DataGridViewLeftSection_Currencies.MultiSelect = False

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading

            RibbonBarOptions_ExchangeRates.Visible = False

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsMultiCurrencyEnabled(DbContext) AndAlso Not String.IsNullOrWhiteSpace(AdvantageFramework.Agency.GetValue(DbContext, Agency.Methods.Settings.CURRENCY_API_KEY)) Then

                    RibbonBarOptions_ExchangeRates.Visible = True

                End If

            End Using

            Try

                LoadGrid()

            Catch ex As Exception

            End Try

            Try

                DataGridViewLeftSection_Currencies.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            Catch ex As Exception

            End Try

            Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            EnableOrDisableActions()

        End Sub
        Private Sub CurrencyCodeSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CurrencyCodeRightSection_CurrencyCode_ComparisonCurrencyChanged() Handles CurrencyCodeRightSection_CurrencyCode.ComparisonCurrencyChanged

            If Me.FormShown Then

                LoadGrid()

            End If

        End Sub
        Private Sub CurrencyCodeSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub CurrencyCodeSetupForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

            DataGridViewLeftSection_Currencies.FocusToFindPanel(True)

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub DataGridViewLeftSection_Currencies_LeavingRowEvent(ByVal e As DevExpress.XtraGrid.Views.Base.RowAllowEventArgs) Handles DataGridViewLeftSection_Currencies.LeavingRowEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                e.Allow = CheckForUnsavedChanges()

            End If

        End Sub
        Private Sub ButtonItemExport_All_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_All.Click

            'objects
            Dim CodesList As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                CodesList = DataGridViewLeftSection_Currencies.GetAllRowsBookmarkValues.OfType(Of String).ToList

                DataGridViewLeftSection_CurrenciesExport.DataSource = AdvantageFramework.Database.Procedures.CurrencyDetail.Load(DbContext).ToList.Where(Function(Entity) CodesList.Contains(Entity.CurrencyCode) = True).OrderBy(Function(Entity) Entity.CurrencyCode).ToList

                If DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString) IsNot Nothing Then

                    DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString).Visible = True
                    DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString).VisibleIndex = 0

                End If

                DataGridViewLeftSection_CurrenciesExport.CurrentView.BestFitColumns()

                DataGridViewLeftSection_CurrenciesExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

            End Using

        End Sub
        Private Sub ButtonItemExport_CurrentView_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemExport_CurrentView.Click

            DataGridViewLeftSection_CurrenciesExport.DataSource = CurrencyCodeRightSection_CurrencyCode.CurrencyDetails

            If DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString) IsNot Nothing Then

                DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString).Visible = True
                DataGridViewLeftSection_CurrenciesExport.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString).VisibleIndex = 0

            End If

            DataGridViewLeftSection_CurrenciesExport.CurrentView.BestFitColumns()

            DataGridViewLeftSection_CurrenciesExport.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

        End Sub
        Private Sub DataGridViewLeftSection_Currencies_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewLeftSection_Currencies.SelectionChangedEvent

            If Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None Then

                LoadSelectedItemDetails()
                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim ErrorMessage As String = ""

            If DataGridViewLeftSection_Currencies.HasOnlyOneSelectedRow Then

                If Me.Validator Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                    Try

                        CurrencyCodeRightSection_CurrencyCode.Save()

                        Me.ClearChanged()

                        LoadGrid()

                    Catch ex As Exception
                        ErrorMessage = ex.Message
                        AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                    If ErrorMessage = "" Then

                        DataGridViewLeftSection_Currencies.FocusToFindPanel(False)

                    End If

                Else

                    For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                        ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                    Next

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a currency code to save.")

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim CurrencyCode As String = Nothing
            Dim ContinueAdd As Boolean = True

            If DataGridViewLeftSection_Currencies.HasOnlyOneSelectedRow Then

                ContinueAdd = CheckForUnsavedChanges()

            End If

            If ContinueAdd Then

                If AdvantageFramework.Maintenance.Accounting.Presentation.CurrencyCodeEditDialog.ShowFormDialog(CurrencyCode) = System.Windows.Forms.DialogResult.OK Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                    Try

                        LoadGrid()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                    DataGridViewLeftSection_Currencies.SelectRow(CurrencyCode)

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Delete.Click

            If DataGridViewLeftSection_Currencies.HasASelectedRow Then

                If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Deleting, "Deleting...")

                    Try

                        CurrencyCodeRightSection_CurrencyCode.Delete()

                        LoadGrid()

                        LoadSelectedItemDetails()

                    Catch ex As Exception
                        AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                    End Try

                    Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Please select a currency code to delete.")

            End If

        End Sub
        Private Sub CurrencyCodeRightSection_CurrencyCode_CurrencyDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsInitNewRowEvent

            ButtonItemDetails_Cancel.Enabled = True
            ButtonItemDetails_Delete.Enabled = False

        End Sub
        Private Sub CurrencyCodeRightSection_CurrencyCode_CurrencyDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsSelectionChangedEvent

            If CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsHasOnlyOneSelectedRow(False) Then

                If CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsIsNewItemRow(CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsFocusedRowHandle) Then

                    ButtonItemDetails_Cancel.Enabled = True
                    ButtonItemDetails_Delete.Enabled = False

                Else

                    ButtonItemDetails_Cancel.Enabled = False
                    ButtonItemDetails_Delete.Enabled = True

                End If

            Else

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Cancel.Click

            CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsCancelNewItemRow()

            If CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsHasOnlyOneSelectedRow(False) Then

                ButtonItemDetails_Cancel.Enabled = False
                ButtonItemDetails_Delete.Enabled = CurrencyCodeRightSection_CurrencyCode.CurrencyDetailsHasRows

            End If

        End Sub
        Private Sub ButtonItemDetails_Delete_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemDetails_Delete.Click

            CurrencyCodeRightSection_CurrencyCode.DeleteCurrencyDetails()

        End Sub
        Private Sub ButtonItemActions_Refresh_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Refresh.Click

            If CheckForUnsavedChanges() Then

                Me.FormAction = WinForm.Presentation.FormActions.Refreshing
                Me.ShowWaitForm("Processing...")

                Try

                    CurrencyCodeRightSection_CurrencyCode.RefreshControl()

                    Me.ClearChanged()

                Catch ex As Exception

                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                DataGridViewLeftSection_Currencies.GridViewSelectionChanged()

            End If

        End Sub
        Private Sub ButtonItemExchangeRates_GetCurrentRates_Click(sender As Object, e As EventArgs) Handles ButtonItemExchangeRates_GetCurrentRates.Click

            Dim CurrencyList As IEnumerable(Of String) = Nothing
            Dim CurrencyCodeComparison As String = Nothing
            Dim ErrorMessage As String = ""

            Me.ShowWaitForm("Updating...")

            CurrencyCodeComparison = CurrencyCodeRightSection_CurrencyCode.SearchableComboBoxControl_HomeCurrency.GetSelectedValue

            CurrencyList = DataGridViewLeftSection_Currencies.GetAllRowsBookmarkValues(0).OfType(Of String).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                If AdvantageFramework.Currency.GetRealtimeRates(DbContext, CurrencyList, CurrencyCodeComparison, ErrorMessage) Then

                    LoadSelectedItemDetails()

                    AdvantageFramework.WinForm.MessageBox.Show("Exchanges rates updated successfully.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End Using

            Me.CloseWaitForm()

        End Sub

#End Region

#End Region

    End Class

End Namespace