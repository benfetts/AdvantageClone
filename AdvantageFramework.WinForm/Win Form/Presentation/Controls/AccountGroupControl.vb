Namespace WinForm.Presentation.Controls

    Public Class AccountGroupControl

        Public Event SelectedAccountGroupDetailChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _AccountGroupCode As String = Nothing
        Private _ShowInactiveAccounts As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property DetailsDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                DetailsDataGridView = DataGridViewControl_AccountGroupDetails
            End Get
        End Property
        Public Property ShowInactiveAccounts As Boolean
            Get
                ShowInactiveAccounts = _ShowInactiveAccounts
            End Get
            Set(value As Boolean)
                _ShowInactiveAccounts = value
            End Set
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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DataGridViewControl_AccountGroupDetails.AutoFilterLookupColumns = True
                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.AccountGroup.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.AccountGroup.Properties.Description)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadEntity(ByVal AccountGroup As AdvantageFramework.Database.Entities.AccountGroup)

            If AccountGroup IsNot Nothing Then

                AccountGroup.Code = TextBoxControl_Code.Text
                AccountGroup.Description = TextBoxControl_Description.Text

                If RadioButtonControlControl_FullAccountCode.Checked Then

                    AccountGroup.Type = 1

                ElseIf RadioButtonControlControl_BaseAccountCode.Checked Then

                    AccountGroup.Type = 2

                Else

                    AccountGroup.Type = Nothing

                End If

            End If

        End Sub
        Private Sub LoadAccountGroupDetails()

            If _AccountGroupCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    DataGridViewControl_AccountGroupDetails.DataSource = AdvantageFramework.Database.Procedures.AccountGroupDetail.LoadByAccountGroupCode(DbContext, _AccountGroupCode).ToList

                End Using

                DataGridViewControl_AccountGroupDetails.CurrentView.BestFitColumns()

            End If

        End Sub
        Private Sub LoadEntityDetails()

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing

            If _AccountGroupCode <> "" Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, _AccountGroupCode)

                    If AccountGroup IsNot Nothing Then

                        TextBoxControl_Description.Text = AccountGroup.Description

                        If AccountGroup.Type = 1 Then

                            RadioButtonControlControl_FullAccountCode.Checked = True

                        ElseIf AccountGroup.Type = 2 Then

                            RadioButtonControlControl_BaseAccountCode.Checked = True

                        Else

                            RadioButtonControlControl_FullAccountCode.Checked = True

                        End If

                        LoadAccountGroupDetails()

                    End If

                End Using

            End If

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountGroup = Me.FillObject(False)

                    If AccountGroup IsNot Nothing Then

                        Saved = AdvantageFramework.Database.Procedures.AccountGroup.Update(DbContext, AccountGroup)

                        If Saved Then

                            For Each AccountGroupDetail In DataGridViewControl_AccountGroupDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AccountGroupDetail).ToList

                                AdvantageFramework.Database.Procedures.AccountGroupDetail.Update(DbContext, AccountGroupDetail)

                            Next

                        End If

                    End If

                End Using

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Delete() As Boolean

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountGroup = Me.FillObject(False)

                    If AccountGroup IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.AccountGroup.Delete(DbContext, AccountGroup)

                    End If

                End Using

                If Deleted = False Then

                    ErrorMessage = "The account group is in use and cannot be deleted."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef AccountGroupCode As String) As Boolean

            'objects
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AccountGroup = Me.FillObject(True)

                    If AccountGroup IsNot Nothing Then

                        AccountGroup.DbContext = DbContext

                        Inserted = AdvantageFramework.Database.Procedures.AccountGroup.Insert(DbContext, AccountGroup)

                        If Inserted Then

                            For Each AccountGroupDetail In DataGridViewControl_AccountGroupDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AccountGroupDetail)()

                                AccountGroupDetail.DbContext = DbContext
                                AccountGroupDetail.AccountGroupCode = AccountGroup.Code

                                If AdvantageFramework.Database.Procedures.AccountGroupDetail.Insert(DbContext, AccountGroupDetail) = False Then

                                    DbContext.UndoChanges(AccountGroupDetail)

                                End If

                            Next

                            AccountGroupCode = AccountGroup.Code

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert into the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Function DeleteSelectedDetail() As Boolean

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing
            Dim RowHandlesAndDataBoundItems As Generic.Dictionary(Of Integer, Object) = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = True

            Try

                If DataGridViewControl_AccountGroupDetails.HasASelectedRow Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        RowHandlesAndDataBoundItems = DataGridViewControl_AccountGroupDetails.GetAllSelectedRowsRowHandlesAndDataBoundItems

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each RowHandleAndDataBoundItem In RowHandlesAndDataBoundItems.ToList

                                Try

                                    AccountGroupDetail = RowHandleAndDataBoundItem.Value

                                Catch ex As Exception
                                    AccountGroupDetail = Nothing
                                End Try

                                If AccountGroupDetail IsNot Nothing Then

                                    If _AccountGroupCode <> "" Then

                                        Deleted = AdvantageFramework.Database.Procedures.AccountGroupDetail.Delete(DbContext, AccountGroupDetail)

                                    End If

                                    If Deleted Then

                                        DataGridViewControl_AccountGroupDetails.CurrentView.DeleteFromDataSource(RowHandleAndDataBoundItem.Value)

                                    End If

                                End If

                            Next

                        End Using

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            DeleteSelectedDetail = Deleted

        End Function
        Public Function LoadControl(ByVal AccountGroupCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing

            _AccountGroupCode = AccountGroupCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _AccountGroupCode <> "" Then

                    TextBoxControl_Code.Enabled = False
                    TextBoxControl_Code.ReadOnly = True

                    RadioButtonControlControl_BaseAccountCode.Enabled = False
                    RadioButtonControlControl_FullAccountCode.Enabled = False

                    AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, _AccountGroupCode)

                    If AccountGroup IsNot Nothing Then

                        TextBoxControl_Code.Text = AccountGroup.Code

                        LoadEntityDetails()

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxControl_Code.Enabled = True
                    TextBoxControl_Code.ReadOnly = False
                    RadioButtonControlControl_BaseAccountCode.Enabled = True
                    RadioButtonControlControl_FullAccountCode.Enabled = True
                    RadioButtonControlControl_FullAccountCode.Checked = True
                    DataGridViewControl_AccountGroupDetails.DataSource = New Generic.List(Of AdvantageFramework.Database.Entities.AccountGroupDetail)
                    DataGridViewControl_AccountGroupDetails.CurrentView.BestFitColumns()

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.AccountGroup

            Dim AccountGroup As AdvantageFramework.Database.Entities.AccountGroup = Nothing

            Try

                If IsNew Then

                    AccountGroup = New AdvantageFramework.Database.Entities.AccountGroup

                    LoadEntity(AccountGroup)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AccountGroup = AdvantageFramework.Database.Procedures.AccountGroup.LoadByAccountGroupCode(DbContext, _AccountGroupCode)

                        If AccountGroup IsNot Nothing Then

                            LoadEntity(AccountGroup)

                        End If

                    End Using

                End If

            Catch ex As Exception
                AccountGroup = Nothing
            End Try

            FillObject = AccountGroup

        End Function
        Public Sub ClearControl()

            TextBoxControl_Code.Text = ""
            TextBoxControl_Description.Text = ""
            RadioButtonControlControl_FullAccountCode.Checked = True
            DataGridViewControl_AccountGroupDetails.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.AccountGroupDetail))

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function ValidateDetails(ByRef IsValid As Boolean) As String

            'objects
            Dim ErrorText As String = Nothing

            If DataGridViewControl_AccountGroupDetails.CurrentView.RowCount = 0 Then

                ErrorText = "You must select an individual account or a range of accounts."
                IsValid = False

            Else

                For Each AccountGroupDetail In DataGridViewControl_AccountGroupDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.AccountGroupDetail).ToList

                    If String.IsNullOrWhiteSpace(AccountGroupDetail.GLACode) AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) Then

                        ErrorText = "You must select an individual account or a range of accounts."
                        IsValid = False

                    ElseIf String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) Then

                        ErrorText = "You have selected a Range From Account without selecting a Range To Account."
                        IsValid = False

                    ElseIf String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                        ErrorText = "You have selected a Range To Account without selecting a Range From Account."
                        IsValid = False

                    ElseIf String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeFrom) = False AndAlso String.IsNullOrWhiteSpace(AccountGroupDetail.GLACodeTo) = False Then

                        If CLng(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(AccountGroupDetail.GLACodeFrom)) > CLng(AdvantageFramework.StringUtilities.RemoveAllNonNumeric(AccountGroupDetail.GLACodeTo)) Then

                            ErrorText = "The ""Range From"" Account must be less than the ""Range To"" Account."
                            IsValid = False

                        End If

                    End If

                    If IsValid = False Then

                        Exit For

                    End If

                Next

                If IsValid Then

                    DataGridViewControl_AccountGroupDetails.ValidateAllRows()

                    If DataGridViewControl_AccountGroupDetails.CurrentView.HasAnyInvalidRows Then

                        ErrorText = "Please fix invalid row(s)."
                        IsValid = False

                    End If

                End If

            End If

            ValidateDetails = ErrorText

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub AccountGroupControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_AccountGroupDetails_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_AccountGroupDetails.InitNewRowEvent

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing


            Try

                AccountGroupDetail = DirectCast(DataGridViewControl_AccountGroupDetails.CurrentView.GetFocusedRow, AdvantageFramework.Database.Entities.AccountGroupDetail)

                AccountGroupDetail.SetGLAType(RadioButtonControlControl_BaseAccountCode.Checked)

            Catch ex As Exception
                AccountGroupDetail = Nothing
            End Try

            RaiseEvent SelectedAccountGroupDetailChangedEvent()

        End Sub
        Private Sub DataGridViewControl_AccountGroupDetails_QueryPopupNeedDatasourceEvent(FieldName As String, ByRef OverrideDefaultDatasource As Boolean, ByRef Datasource As Object) Handles DataGridViewControl_AccountGroupDetails.QueryPopupNeedDatasourceEvent

            If FieldName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACode.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeFrom.ToString OrElse
                   FieldName = AdvantageFramework.Database.Entities.AccountGroupDetail.Properties.GLACodeTo.ToString Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If RadioButtonControlControl_BaseAccountCode.Checked Then

                        If _ShowInactiveAccounts Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                          Select New With {.Code = Entity.BaseCode,
                                                           .Description = Entity.Description}).Distinct.OrderBy(Function(Entity) Entity.Code).ToList

                        Else

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                          Select New With {.Code = Entity.BaseCode,
                                                           .Description = Entity.Description}).Distinct.OrderBy(Function(Entity) Entity.Code).ToList

                        End If

                        OverrideDefaultDatasource = True

                    ElseIf RadioButtonControlControl_FullAccountCode.Checked Then

                        If _ShowInactiveAccounts Then

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.Load(DbContext)
                                          Select New With {.Code = Entity.Code,
                                                           .Description = Entity.Description}).Distinct.OrderBy(Function(Entity) Entity.Code).ToList

                        Else

                            Datasource = (From Entity In AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadAllActive(DbContext)
                                          Select New With {.Code = Entity.Code,
                                                           .Description = Entity.Description}).Distinct.ToList

                        End If

                        OverrideDefaultDatasource = True

                    Else

                        OverrideDefaultDatasource = False
                        Datasource = Nothing

                    End If

                End Using

            End If

        End Sub
        Private Sub DataGridViewControl_AccountGroupDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewControl_AccountGroupDetails.SelectionChangedEvent

            RaiseEvent SelectedAccountGroupDetailChangedEvent()

        End Sub
        Private Sub DataGridViewControl_AccountGroupDetails_AddNewRowEvent(RowObject As Object) Handles DataGridViewControl_AccountGroupDetails.AddNewRowEvent

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.AccountGroupDetail Then

                Me.ShowWaitForm("Processing...")

                AccountGroupDetail = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If AccountGroupDetail.IsEntityBeingAdded() Then

                        If _AccountGroupCode IsNot Nothing Then

                            AccountGroupDetail.DbContext = DbContext

                            AccountGroupDetail.AccountGroupCode = _AccountGroupCode

                            AdvantageFramework.Database.Procedures.AccountGroupDetail.Insert(DbContext, AccountGroupDetail)

                        End If

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RadioButtonControlControl_BaseAccountCode_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlControl_BaseAccountCode.CheckedChangedEx

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If String.IsNullOrEmpty(_AccountGroupCode) Then

                    For RowHandle = 0 To DataGridViewControl_AccountGroupDetails.CurrentView.RowCount - 1

                        Try

                            AccountGroupDetail = DirectCast(DataGridViewControl_AccountGroupDetails.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Entities.AccountGroupDetail)

                            AccountGroupDetail.SetGLAType(RadioButtonControlControl_BaseAccountCode.Checked)

                        Catch ex As Exception

                        End Try

                    Next

                    DataGridViewControl_AccountGroupDetails.ValidateAllRows()

                End If

            End If

        End Sub
        Private Sub RadioButtonControlControl_FullAccountCode_CheckedChangedEx(sender As Object, e As DevComponents.DotNetBar.Controls.CheckBoxXChangeEventArgs) Handles RadioButtonControlControl_FullAccountCode.CheckedChangedEx

            'objects
            Dim AccountGroupDetail As AdvantageFramework.Database.Entities.AccountGroupDetail = Nothing

            If e.EventSource <> DevComponents.DotNetBar.eEventSource.Code Then

                If String.IsNullOrEmpty(_AccountGroupCode) Then

                    For RowHandle = 0 To DataGridViewControl_AccountGroupDetails.CurrentView.RowCount - 1

                        Try

                            AccountGroupDetail = DirectCast(DataGridViewControl_AccountGroupDetails.CurrentView.GetRow(RowHandle), AdvantageFramework.Database.Entities.AccountGroupDetail)

                            AccountGroupDetail.SetGLAType(RadioButtonControlControl_BaseAccountCode.Checked)

                        Catch ex As Exception

                        End Try

                    Next

                    DataGridViewControl_AccountGroupDetails.ValidateAllRows()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
