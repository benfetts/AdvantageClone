Namespace Billing.Presentation

    Public Class BillingCommandCenterCurrencyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _BillingUser As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(BillingUser As String)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _BillingUser = BillingUser

        End Sub
        Private Sub LoadGrid()

            Dim CurrencyRates As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate) = Nothing

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                CurrencyRates = DbContext.Database.SqlQuery(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate)(String.Format("exec dbo.advsp_bcc_get_currency_rates '{0}'", _BillingUser)).ToList

                DataGridViewPanel_CurrencyRates.DataSource = CurrencyRates

            End Using

            DataGridViewPanel_CurrencyRates.CurrentView.BestFitColumns()

        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        IsOkay = False

                        Me.Cursor = Windows.Forms.Cursors.WaitCursor
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Saving

                        Try

                            IsOkay = Save()

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                        End Try

                        If IsOkay = False Then

                            If AdvantageFramework.Navigation.ShowMessageBox("Saving failed. Do you want to continue without saving?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                                IsOkay = True

                            End If

                        End If

                        Me.Cursor = Windows.Forms.Cursors.Default
                        Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function
        Private Function Save() As Boolean

            Dim CurrencyRates As IEnumerable(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate) = Nothing
            Dim Saved As Boolean = False

            DataGridViewPanel_CurrencyRates.CurrentView.CloseEditorForUpdating()

            DataGridViewPanel_CurrencyRates.ValidateAllRows()

            If DataGridViewPanel_CurrencyRates.HasAnyInvalidRows Then

                AdvantageFramework.WinForm.MessageBox.Show("Please fix errors in grid before saving.")

            Else

                CurrencyRates = DataGridViewPanel_CurrencyRates.GetAllModifiedRows.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate).ToList()

                Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                    For Each CurrencyRate In CurrencyRates

                        DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.W_AR_FUNCTION SET CURRENCY_RATE = {1} WHERE CURRENCY_CODE = '{0}'", CurrencyRate.CurrencyCode, CurrencyRate.CurrencyRate))

                    Next

                End Using

                Saved = True

            End If

            Save = Saved

        End Function
        Private Sub EnableOrDisableActions()

            ButtonItemActions_Save.Enabled = DataGridViewPanel_CurrencyRates.UserEntryChanged
            ButtonItemActions_Cancel.Enabled = DataGridViewPanel_CurrencyRates.UserEntryChanged

            ButtonItemExchangeRates_GetCurrentRates.Enabled = DataGridViewPanel_CurrencyRates.HasRows

        End Sub

#Region "  Show Form Methods "

        Public Overloads Shared Sub ShowDialog(BillingUser As String)

            'objects
            Dim BillingCommandCenterCurrencyDialog As AdvantageFramework.Billing.Presentation.BillingCommandCenterCurrencyDialog = Nothing

            BillingCommandCenterCurrencyDialog = New AdvantageFramework.Billing.Presentation.BillingCommandCenterCurrencyDialog(BillingUser)

            BillingCommandCenterCurrencyDialog.ShowDialog()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub BillingCommandCenterCurrencyDialog_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage

            ButtonItemExchangeRates_GetCurrentRates.Image = AdvantageFramework.My.Resources.CurrencyDollarImage

            LoadGrid()

            EnableOrDisableActions()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemSystem_Close_Click(sender As Object, e As EventArgs) Handles ButtonItemSystem_Close.Click

            Me.Close()

        End Sub
        Private Sub ButtonItemActions_Save_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Save.Click

            If Save() Then

                Me.ClearChanged()

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Cancel.Click

            LoadGrid()

            Me.ClearChanged()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemExchangeRates_GetCurrentRates_Click(sender As Object, e As EventArgs) Handles ButtonItemExchangeRates_GetCurrentRates.Click

            Dim CurrencyRateList As Generic.List(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate) = Nothing
            Dim CurrencyList As IEnumerable(Of String) = Nothing
            Dim ErrorFound As Boolean = False
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim ErrorMessage As String = ""

            Me.ShowWaitForm("Updating...")

            CurrencyRateList = DataGridViewPanel_CurrencyRates.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate).ToList

            Using DbContext As New AdvantageFramework.Database.DbContext(Session.ConnectionString, Session.UserCode)

                For Each CurrencyRate In CurrencyRateList

                    CurrencyList = {CurrencyRate.CurrencyCode}

                    If Not AdvantageFramework.Currency.GetRealtimeRates(DbContext, CurrencyList, CurrencyRate.CurrencyCodeComparison, ErrorMessage) Then

                        ErrorFound = True
                        Exit For

                    End If

                Next

                If Not ErrorFound Then

                    For Each CurrencyRate In CurrencyRateList

                        CurrencyDetail = AdvantageFramework.Database.Procedures.CurrencyDetail.LoadLatestByCurrencyCodeAndCurrencyCodeComparison(DbContext, CurrencyRate.CurrencyCode, CurrencyRate.CurrencyCodeComparison)

                        If CurrencyDetail IsNot Nothing Then

                            DbContext.Database.ExecuteSqlCommand(String.Format("UPDATE dbo.W_AR_FUNCTION SET CURRENCY_RATE = {1} WHERE CURRENCY_CODE = '{0}'", CurrencyRate.CurrencyCode, CurrencyDetail.ReciprocalExchangeRate))

                        End If

                    Next

                    LoadGrid()

                    EnableOrDisableActions()

                    AdvantageFramework.WinForm.MessageBox.Show("Exchanges rates updated successfully.")

                Else

                    AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

                End If

            End Using

            Me.CloseWaitForm()

        End Sub
        Private Sub DataGridViewPanel_CurrencyRates_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewPanel_CurrencyRates.ShowingEditorEvent

            If DataGridViewPanel_CurrencyRates.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.BillingCommandCenter.Classes.CurrencyRate.Properties.CurrencyRate.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewPanel_CurrencyRates_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewPanel_CurrencyRates.CellValueChangedEvent

            EnableOrDisableActions()

        End Sub

#End Region

#End Region

    End Class

End Namespace