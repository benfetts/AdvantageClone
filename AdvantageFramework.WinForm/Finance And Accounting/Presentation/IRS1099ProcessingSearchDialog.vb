Namespace FinanceAndAccounting.Presentation

    Public Class IRS1099ProcessingSearchDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _StartDate As Nullable(Of Date) = Nothing
        Private _EndDate As Nullable(Of Date) = Nothing
        Private _SelectedBanks As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property StartDate As Date
            Get
                StartDate = _StartDate
            End Get
        End Property
        Private ReadOnly Property EndDate As Date
            Get
                EndDate = _EndDate
            End Get
        End Property
        Private ReadOnly Property SelectedBanks As Generic.List(Of String)
            Get
                SelectedBanks = _SelectedBanks
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal StartDate As Nullable(Of Date), ByVal EndDate As Nullable(Of Date), ByVal SelectedBanks As Generic.List(Of String))

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _StartDate = StartDate
            _EndDate = EndDate
            _SelectedBanks = SelectedBanks

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonForm_OK.Enabled = DataGridViewRightSection_Banks.HasRows

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByRef StartDate As Nullable(Of Date), ByRef EndDate As Nullable(Of Date), ByRef SelectedBanks As Generic.List(Of String)) As Windows.Forms.DialogResult

            'objects
            Dim IRS1099ProcessingSearchDialog As AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSearchDialog = Nothing

            IRS1099ProcessingSearchDialog = New AdvantageFramework.FinanceAndAccounting.Presentation.IRS1099ProcessingSearchDialog(StartDate, EndDate, SelectedBanks)

            ShowFormDialog = IRS1099ProcessingSearchDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                StartDate = IRS1099ProcessingSearchDialog.StartDate
                EndDate = IRS1099ProcessingSearchDialog.EndDate
                SelectedBanks = IRS1099ProcessingSearchDialog.SelectedBanks

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub IRS1099ProcessingSearchDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            DateTimePickerCheckDates_Starting.ByPassUserEntryChanged = True
            DateTimePickerCheckDates_Starting.SetRequired(True)
            DateTimePickerCheckDates_Starting.MinDate = DateSerial(1900, 1, 1)
            DateTimePickerCheckDates_Starting.MaxDate = DateSerial(2079, 6, 6)

            DateTimePickerCheckDates_Ending.ByPassUserEntryChanged = True
            DateTimePickerCheckDates_Ending.SetRequired(True)
            DateTimePickerCheckDates_Ending.MinDate = DateSerial(1900, 1, 1)
            DateTimePickerCheckDates_Ending.MaxDate = DateSerial(2079, 6, 6)

            DataGridViewLeftSection_Banks.ByPassUserEntryChanged = True
            DataGridViewRightSection_Banks.ByPassUserEntryChanged = True

            If _StartDate IsNot Nothing Then

                DateTimePickerCheckDates_Starting.ValueObject = _StartDate

            Else

                DateTimePickerCheckDates_Starting.ValueObject = DateSerial(DateAdd(DateInterval.Year, -1, System.DateTime.Today).Year, 1, 1)

            End If

            If _EndDate IsNot Nothing Then

                DateTimePickerCheckDates_Ending.ValueObject = _EndDate

            Else

                DateTimePickerCheckDates_Ending.ValueObject = DateSerial(DateAdd(DateInterval.Year, -1, System.DateTime.Today).Year, 12, 31)

            End If

            Using DbContext As New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If _SelectedBanks IsNot Nothing Then

                    DataGridViewRightSection_Banks.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                                                 Where _SelectedBanks.Contains(Entity.Code) AndAlso
                                                                       Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode)
                                                                 Select Entity.Code, Entity.Description).ToList

                    DataGridViewLeftSection_Banks.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                                                Where Not _SelectedBanks.Contains(Entity.Code) AndAlso
                                                                      Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode)
                                                                Select Entity.Code, Entity.Description).ToList

                Else

                    DataGridViewRightSection_Banks.DataSource = (From Entity In AdvantageFramework.Database.Procedures.Bank.LoadAllActive(DbContext)
                                                                 Where Session.AccessibleOfficeCodes.Contains(Entity.OfficeCode)
                                                                 Select Entity.Code, Entity.Description).ToList

                    DataGridViewLeftSection_Banks.DataSource = AdvantageFramework.Database.Procedures.Bank.LoadByBankCode(DbContext, Nothing)

                End If

            End Using

            DataGridViewRightSection_Banks.CurrentView.BestFitColumns()
            DataGridViewLeftSection_Banks.CurrentView.BestFitColumns()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_OK_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_OK.Click

            'objects
            Dim ErrorMessage As String = Nothing

            If Me.Validator Then

                If DateTimePickerCheckDates_Starting.Value > DateTimePickerCheckDates_Ending.Value Then

                    AdvantageFramework.WinForm.MessageBox.Show("Starting date can not be greater than ending date.")

                Else

                    _StartDate = DateTimePickerCheckDates_Starting.GetValue
                    _EndDate = DateTimePickerCheckDates_Ending.GetValue

                    _SelectedBanks = DataGridViewRightSection_Banks.GetAllRowsBookmarkValues.OfType(Of String).ToList

                    Me.DialogResult = System.Windows.Forms.DialogResult.OK
                    Me.Close()

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub DataGridViewRightSection_Banks_RowCountChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_Banks.RowCountChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonRightSection_AddBank_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddBank.Click

            Dim SelectedBanks As IEnumerable(Of Object) = Nothing

            If DataGridViewLeftSection_Banks.HasASelectedRow Then

                SelectedBanks = DataGridViewRightSection_Banks.GetAllRowsDataBoundItems

                SelectedBanks = SelectedBanks.Union(DataGridViewLeftSection_Banks.GetAllSelectedRowsDataBoundItems)

                DataGridViewRightSection_Banks.DataSource = SelectedBanks

                DataGridViewLeftSection_Banks.CurrentView.DeleteSelectedRows()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveBank_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveBank.Click

            Dim SelectedBanks As IEnumerable(Of Object) = Nothing

            If DataGridViewRightSection_Banks.HasASelectedRow Then

                SelectedBanks = DataGridViewLeftSection_Banks.GetAllRowsDataBoundItems

                SelectedBanks = SelectedBanks.Union(DataGridViewRightSection_Banks.GetAllSelectedRowsDataBoundItems)

                DataGridViewLeftSection_Banks.DataSource = SelectedBanks

                DataGridViewRightSection_Banks.CurrentView.DeleteSelectedRows()

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace