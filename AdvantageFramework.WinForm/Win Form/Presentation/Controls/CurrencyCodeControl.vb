Namespace WinForm.Presentation.Controls

    Public Class CurrencyCodeControl

        Public Event CurrencyDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event CurrencyDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event ComparisonCurrencyChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _CurrencyCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property CurrencyDetailsHasRows() As Boolean
            Get
                CurrencyDetailsHasRows = DataGridViewControl_CurrencyDetails.HasRows
            End Get
        End Property
        Public ReadOnly Property CurrencyDetailsHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                CurrencyDetailsHasOnlyOneSelectedRow = DataGridViewControl_CurrencyDetails.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property CurrencyDetailsIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                CurrencyDetailsIsNewItemRow = DataGridViewControl_CurrencyDetails.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property CurrencyDetailsFocusedRowHandle() As Integer
            Get
                CurrencyDetailsFocusedRowHandle = DataGridViewControl_CurrencyDetails.CurrentView.FocusedRowHandle
            End Get
        End Property
        Public ReadOnly Property CurrencyDetails() As Generic.List(Of AdvantageFramework.Database.Entities.CurrencyDetail)
            Get
                CurrencyDetails = DataGridViewControl_CurrencyDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CurrencyDetail).ToList
            End Get
        End Property

#End Region

#Region " Methods "

        Public Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            Me.DoubleBuffered = True
            'AddHandler AdvantageFramework.WinForm.Presentation.Controls.LoadFormSettingsEvent, AddressOf LoadFormSettings

        End Sub
        Protected Overrides Sub LoadFormSettings(ByVal Form As System.Windows.Forms.Form)

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso _
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    SearchableComboBoxControl_DefaultAPAccount.SetPropertySettings(AdvantageFramework.Database.Entities.Currency.Properties.GLACode)
                    SearchableComboBoxControl_APForeignCurrencyExchangeAccount.SetPropertySettings(AdvantageFramework.Database.Entities.Currency.Properties.ForeignCurrencyGLACode)
                    SearchableComboBoxControl_Currency.SetPropertySettings(AdvantageFramework.Database.Entities.Currency.Properties.CurrencyCode)
                    SearchableComboBoxControl_HomeCurrency.SetPropertySettings(AdvantageFramework.Database.Entities.Currency.Properties.CurrencyCode)

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        LoadDropDownDataSources()

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadControlDetails()

            'objects
            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _CurrencyCode <> "" Then

                    Currency = AdvantageFramework.Database.Procedures.Currency.LoadByCurrencyCode(DbContext, _CurrencyCode)

                    If Currency IsNot Nothing Then

                        LoadControlDetails(Currency.CurrencyDetails.ToList)

                    End If

                Else

                    LoadControlDetails(New Generic.List(Of AdvantageFramework.Database.Entities.CurrencyDetail))

                End If

            End Using

        End Sub
        Private Sub LoadControlDetails(ByVal CurrencyDetails As Generic.List(Of AdvantageFramework.Database.Entities.CurrencyDetail))

            DataGridViewControl_CurrencyDetails.DataSource = CurrencyDetails.OrderByDescending(Function(Entity) Entity.ExchangeDate).ToList

            If DataGridViewControl_CurrencyDetails.CurrentView.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.ExchangeRate.ToString) IsNot Nothing AndAlso SearchableComboBoxControl_HomeCurrency.HasASelectedValue Then

                DataGridViewControl_CurrencyDetails.CurrentView.Columns(AdvantageFramework.Database.Entities.CurrencyDetail.Properties.ExchangeRate.ToString).Caption = "1 " & _CurrencyCode & " Equals " & SearchableComboBoxControl_HomeCurrency.GetSelectedValue

            End If

            DataGridViewControl_CurrencyDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadCurrencyEntity(ByRef Currency As AdvantageFramework.Database.Entities.Currency)

            If Currency IsNot Nothing Then

                Currency.CurrencyCode = SearchableComboBoxControl_Currency.GetSelectedValue

                Currency.GLACode = SearchableComboBoxControl_DefaultAPAccount.GetSelectedValue
                Currency.ForeignCurrencyGLACode = SearchableComboBoxControl_APForeignCurrencyExchangeAccount.GetSelectedValue

                Currency.IsInactive = CShort(CheckBoxControl_Inactive.CheckValue)

            End If

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewControl_CurrencyDetails.UseEmbeddedNavigator = True

            Else

                DataGridViewControl_CurrencyDetails.UseEmbeddedNavigator = False

            End If

        End Sub
        Private Sub LoadDropDownDataSources()

            Dim CurrencyCodeComparison As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                SearchableComboBoxControl_HomeCurrency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActive(DbContext)
                SearchableComboBoxControl_HomeCurrency.SelectedValue = AdvantageFramework.Database.Procedures.Agency.GetHomeCurrency(DbContext)
                SearchableComboBoxControl_HomeCurrency.ReadOnly = True

                CurrencyCodeComparison = SearchableComboBoxControl_HomeCurrency.SelectedValue

                SearchableComboBoxControl_DefaultAPAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(GLA) GLA.Type = "5")
                SearchableComboBoxControl_APForeignCurrencyExchangeAccount.DataSource = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext).Where(Function(GLA) GLA.Type = "5")
                SearchableComboBoxControl_Currency.DataSource = AdvantageFramework.Database.Procedures.CurrencyCode.LoadAllActive(DbContext)

            End Using

        End Sub

#Region "  Public "

        Public Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.Currency

            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing

            Try

                If IsNew Then

                    Currency = New AdvantageFramework.Database.Entities.Currency

                    Currency.DbContext = DbContext

                    LoadCurrencyEntity(Currency)

                Else

                    Currency = AdvantageFramework.Database.Procedures.Currency.LoadByCurrencyCode(DbContext, _CurrencyCode)

                    If Currency IsNot Nothing Then

                        LoadCurrencyEntity(Currency)

                    End If

                End If

            Catch ex As Exception
                Currency = Nothing
            End Try

            FillObject = Currency

        End Function
        Public Function LoadControl(ByVal CurrencyCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing

            _CurrencyCode = CurrencyCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _CurrencyCode <> "" Then

                    Currency = AdvantageFramework.Database.Procedures.Currency.LoadByCurrencyCode(DbContext, _CurrencyCode)

                    If Currency IsNot Nothing Then

                        SearchableComboBoxControl_Currency.SelectedValue = _CurrencyCode
                        SearchableComboBoxControl_Currency.Enabled = False

                        SearchableComboBoxControl_DefaultAPAccount.SelectedValue = Currency.GLACode
                        SearchableComboBoxControl_APForeignCurrencyExchangeAccount.SelectedValue = Currency.ForeignCurrencyGLACode

                        CheckBoxControl_Inactive.CheckValue = Currency.IsInactive.GetValueOrDefault(0)

                        LoadControlDetails(AdvantageFramework.Database.Procedures.CurrencyDetail.LoadByCurrencyCode(DbContext, Currency.CurrencyCode).ToList)

                    Else

                        Loaded = False

                    End If

                Else

                    SearchableComboBoxControl_Currency.Enabled = True

                    LoadControlDetails(New Generic.List(Of AdvantageFramework.Database.Entities.CurrencyDetail))

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub Save()

            'objects
            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing
            Dim ErrorMessage As String = ""

            Try

                If DataGridViewControl_CurrencyDetails.CurrentView.HasAnyInvalidRows Then

                    ErrorMessage = "Please fix invalid rows."

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Currency = Me.FillObject(DbContext, False)

                        If Currency IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Currency.Update(DbContext, Currency) Then

                                For Each CurrencyDetail In Me.CurrencyDetails.ToList

                                    CurrencyDetail.ReciprocalExchangeRate = FormatNumber(1 / CurrencyDetail.ExchangeRate, 6)

                                    AdvantageFramework.Database.Procedures.CurrencyDetail.Update(DbContext, CurrencyDetail)

                                Next

                            End If

                        End If

                    End Using

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Insert(ByVal CurrencyCode As String)

            'objects
            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Currency = Me.FillObject(DbContext, True)

                    If Currency IsNot Nothing Then

                        Currency.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.Currency.Insert(DbContext, Currency) Then

                            For Each CurrencyDetail In Me.CurrencyDetails.ToList

                                CurrencyDetail.DbContext = DbContext
                                CurrencyDetail.CurrencyCodeComparison = SearchableComboBoxControl_HomeCurrency.GetSelectedValue

                                CurrencyDetail.ReciprocalExchangeRate = FormatNumber(1 / CurrencyDetail.ExchangeRate, 6)

                                AdvantageFramework.Database.Procedures.CurrencyDetail.Insert(DbContext, CurrencyDetail)

                            Next

                            CurrencyCode = Currency.CurrencyCode

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub Delete()

            'objects
            Dim Currency As AdvantageFramework.Database.Entities.Currency = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Currency = Me.FillObject(DbContext, False)

                    If Currency IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Currency.Delete(DbContext, Currency) = False Then

                            ErrorMessage = "The currency is in use and cannot be deleted."

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

        End Sub
        Public Sub ClearControl()

            SearchableComboBoxControl_Currency.SelectedValue = Nothing

            SearchableComboBoxControl_DefaultAPAccount.SelectedValue = Nothing
            SearchableComboBoxControl_APForeignCurrencyExchangeAccount.SelectedValue = Nothing

            CheckBoxControl_Inactive.CheckValue = 0

            DataGridViewControl_CurrencyDetails.DataSource = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CurrencyDetailsCancelNewItemRow()

            DataGridViewControl_CurrencyDetails.CancelNewItemRow()

        End Sub
        Public Sub DeleteCurrencyDetails()

            'objects
            Dim CurrencyDetails As Generic.List(Of AdvantageFramework.Database.Entities.CurrencyDetail) = Nothing

            If DataGridViewControl_CurrencyDetails.HasASelectedRow Then

                If _CurrencyCode <> "" Then

                    DataGridViewControl_CurrencyDetails.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            CurrencyDetails = DataGridViewControl_CurrencyDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CurrencyDetail)().ToList

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each CurrencyDetail In CurrencyDetails

                                    AdvantageFramework.Database.Procedures.CurrencyDetail.Delete(DbContext, CurrencyDetail)

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                        LoadControlDetails()

                    End If

                Else

                    DataGridViewControl_CurrencyDetails.CurrentView.DeleteSelectedRows()

                End If

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub CurrencyCodeControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_CurrencyDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_CurrencyDetails.SelectionChangedEvent

            RaiseEvent CurrencyDetailsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_CurrencyDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_CurrencyDetails.AddNewRowEvent

            'objects
            Dim CurrencyDetail As AdvantageFramework.Database.Entities.CurrencyDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.CurrencyDetail Then

                If _CurrencyCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    CurrencyDetail = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If CurrencyDetail.IsEntityBeingAdded() Then

                            CurrencyDetail.DbContext = DbContext

                            CurrencyDetail.CurrencyCode = _CurrencyCode

                            CurrencyDetail.ReciprocalExchangeRate = FormatNumber(1 / CurrencyDetail.ExchangeRate, 6)

                            AdvantageFramework.Database.Procedures.CurrencyDetail.Insert(DbContext, CurrencyDetail)

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_CurrencyDetails_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_CurrencyDetails.EmbeddedNavigatorButtonClick

            Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                    CurrencyDetailsCancelNewItemRow()

                    e.Handled = True

                Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                    DeleteCurrencyDetails()

                    e.Handled = True

            End Select

        End Sub
        Private Sub DataGridViewControl_CurrencyDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_CurrencyDetails.InitNewRowEvent

            If TypeOf DataGridViewControl_CurrencyDetails.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.CurrencyDetail Then

                DirectCast(DataGridViewControl_CurrencyDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.CurrencyDetail).CurrencyCode = SearchableComboBoxControl_Currency.GetSelectedValue
                DirectCast(DataGridViewControl_CurrencyDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.CurrencyDetail).ExchangeDate = Now
                DirectCast(DataGridViewControl_CurrencyDetails.CurrentView.GetRow(e.RowHandle), AdvantageFramework.Database.Entities.CurrencyDetail).CurrencyCodeComparison = SearchableComboBoxControl_HomeCurrency.GetSelectedValue

                RaiseEvent CurrencyDetailsInitNewRowEvent(sender, e)

            End If

        End Sub
        Private Sub SearchableComboBoxControl_Currency_EditValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SearchableComboBoxControl_Currency.EditValueChanged

            If _CurrencyCode = "" Then

                For RowHandle = 0 To DataGridViewControl_CurrencyDetails.CurrentView.RowCount - 1

                    DataGridViewControl_CurrencyDetails.CurrentView.SetRowCellValue(RowHandle, AdvantageFramework.Database.Entities.CurrencyDetail.Properties.CurrencyCode.ToString, SearchableComboBoxControl_Currency.GetSelectedValue)

                Next

            End If

        End Sub
        Private Sub SearchableComboBoxControl_HomeCurrency_EditValueChanged(sender As Object, e As EventArgs) Handles SearchableComboBoxControl_HomeCurrency.EditValueChanged

            RaiseEvent ComparisonCurrencyChanged()

        End Sub

#End Region

#End Region

    End Class

End Namespace
