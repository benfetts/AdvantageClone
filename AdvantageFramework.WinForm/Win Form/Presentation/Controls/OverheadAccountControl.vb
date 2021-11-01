Namespace WinForm.Presentation.Controls

    Public Class OverheadAccountControl

        Public Event OverheadDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event OverheadDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _OverheadAccountCode As String = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property OverheadDetailsHasRows() As Boolean
            Get
                OverheadDetailsHasRows = DataGridViewControl_OverheadAccountDetails.HasRows
            End Get
        End Property
        Public ReadOnly Property OverheadDetailsHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                OverheadDetailsHasOnlyOneSelectedRow = DataGridViewControl_OverheadAccountDetails.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property OverheadDetailsIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                OverheadDetailsIsNewItemRow = DataGridViewControl_OverheadAccountDetails.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property OverheadDetailsFocusedRowHandle() As Integer
            Get
                OverheadDetailsFocusedRowHandle = DataGridViewControl_OverheadAccountDetails.CurrentView.FocusedRowHandle
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

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxControl_Code.SetPropertySettings(AdvantageFramework.Database.Entities.OverheadAccount.Properties.Code)
                            TextBoxControl_Description.SetPropertySettings(AdvantageFramework.Database.Entities.OverheadAccount.Properties.Description)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadControlDetails()

            Dim OverheadAccountDetailsList As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _OverheadAccountCode <> "" Then

                    OverheadAccountDetailsList = New Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail)

                    OverheadAccountDetailsList.AddRange(From OverheadAccount In AdvantageFramework.Database.Procedures.OverheadAccount.LoadAllByCode(DbContext, _OverheadAccountCode).ToList
                                                        Where OverheadAccount.Code = _OverheadAccountCode
                                                        Select New AdvantageFramework.Database.Classes.OverheadAccountDetail(DbContext, OverheadAccount))

                    DataGridViewControl_OverheadAccountDetails.DataSource = OverheadAccountDetailsList

                    DataGridViewControl_OverheadAccountDetails.CurrentView.BestFitColumns()

                End If

            End Using

        End Sub
        Private Sub LoadControlDetails(ByVal OverheadAccountDetails As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail))

            DataGridViewControl_OverheadAccountDetails.DataSource = OverheadAccountDetails

            DataGridViewControl_OverheadAccountDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadOverheadAccountEntity(ByVal OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount)

            If OverheadAccount IsNot Nothing Then

                OverheadAccount.Code = TextBoxControl_Code.Text
                OverheadAccount.Description = TextBoxControl_Description.Text

            End If

        End Sub
        Private Function AccountsInUse(ByVal FromCode As String, ByVal ToCode As String, ByVal RowHandle As Integer) As Boolean

            Dim OverheadAccountDetails As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail) = Nothing
            Dim CodeInUse As Boolean = False

            OverheadAccountDetails = DataGridViewControl_OverheadAccountDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OverheadAccountDetail).ToList

            For Each OverheadAccountDetail In OverheadAccountDetails

                If Not (RowHandle >= 0 AndAlso OverheadAccountDetails.IndexOf(OverheadAccountDetail) = RowHandle) Then

                    If OverheadAccountDetail.ToGLACode = "" Then

                        If FromCode <> "" AndAlso ToCode = "" AndAlso FromCode = OverheadAccountDetail.FromGLACode Then

                            CodeInUse = True
                            Exit For

                        ElseIf FromCode = "" AndAlso ToCode <> "" AndAlso ToCode = OverheadAccountDetail.FromGLACode Then

                            CodeInUse = True
                            Exit For

                        ElseIf FromCode <> "" AndAlso ToCode <> "" AndAlso FromCode <= OverheadAccountDetail.FromGLACode AndAlso OverheadAccountDetail.FromGLACode <= ToCode Then

                            CodeInUse = True
                            Exit For

                        End If

                    Else

                        If FromCode <> "" AndAlso ToCode = "" AndAlso OverheadAccountDetail.FromGLACode <= FromCode AndAlso FromCode <= OverheadAccountDetail.ToGLACode Then

                            CodeInUse = True
                            Exit For

                        ElseIf FromCode = "" AndAlso ToCode <> "" AndAlso OverheadAccountDetail.FromGLACode <= ToCode AndAlso ToCode <= OverheadAccountDetail.ToGLACode Then

                            CodeInUse = True
                            Exit For

                        ElseIf FromCode <> "" AndAlso ToCode <> "" Then

                            If OverheadAccountDetail.FromGLACode <= FromCode AndAlso FromCode <= OverheadAccountDetail.ToGLACode Then

                                CodeInUse = True
                                Exit For

                            End If

                            If OverheadAccountDetail.FromGLACode <= ToCode AndAlso ToCode <= OverheadAccountDetail.ToGLACode Then

                                CodeInUse = True
                                Exit For

                            End If

                            If FromCode <= OverheadAccountDetail.FromGLACode AndAlso OverheadAccountDetail.FromGLACode <= ToCode Then

                                CodeInUse = True
                                Exit For

                            End If

                            If FromCode <= OverheadAccountDetail.ToGLACode AndAlso OverheadAccountDetail.ToGLACode <= ToCode Then

                                CodeInUse = True
                                Exit For

                            End If

                        End If

                    End If

                End If

            Next

            AccountsInUse = CodeInUse

        End Function
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewControl_OverheadAccountDetails.UseEmbeddedNavigator = True

            Else

                DataGridViewControl_OverheadAccountDetails.UseEmbeddedNavigator = False

            End If

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal OverheadAccountCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing

            _OverheadAccountCode = OverheadAccountCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _OverheadAccountCode <> "" Then

                    OverheadAccount = AdvantageFramework.Database.Procedures.OverheadAccount.LoadSingleByCode(DbContext, _OverheadAccountCode)

                    If OverheadAccount IsNot Nothing Then

                        TextBoxControl_Code.Text = OverheadAccount.Code
                        TextBoxControl_Code.Enabled = False
                        TextBoxControl_Description.Text = OverheadAccount.Description

                        LoadControlDetails()

                    Else

                        Loaded = False

                    End If

                Else

                    DataGridViewControl_OverheadAccountDetails.Enabled = False
                    LoadControlDetails(New Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail))

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillOverheadAccountDetailObjects() As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail)

            'objects
            Dim OverheadAccountDetails As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail) = Nothing

            DataGridViewControl_OverheadAccountDetails.CurrentView.CloseEditorForUpdating()

            OverheadAccountDetails = DataGridViewControl_OverheadAccountDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OverheadAccountDetail).ToList

            FillOverheadAccountDetailObjects = OverheadAccountDetails

        End Function
        Public Sub OverheadAccountDetailsCancelNewItemRow()

            DataGridViewControl_OverheadAccountDetails.CancelNewItemRow()

        End Sub
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.OverheadAccount

            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing

            Try

                If IsNew Then

                    OverheadAccount = New AdvantageFramework.Database.Entities.OverheadAccount

                    LoadOverheadAccountEntity(OverheadAccount)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        OverheadAccount = AdvantageFramework.Database.Procedures.OverheadAccount.LoadSingleByCode(DbContext, _OverheadAccountCode)

                    End Using

                    If OverheadAccount IsNot Nothing Then

                        OverheadAccount.Description = TextBoxControl_Description.Text

                    End If

                End If

            Catch ex As Exception
                OverheadAccount = Nothing
            End Try

            FillObject = OverheadAccount

        End Function
        Public Sub DeleteOverheadAccountDetails()

            'objects
            Dim OverheadAccountDetails As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail) = Nothing
            Dim OverHeadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing
            Dim OverheadAccountCode As String = Nothing
            Dim OverheadAccountGLAFromCode As String = Nothing

            If DataGridViewControl_OverheadAccountDetails.HasASelectedRow Then

                If _OverheadAccountCode <> "" Then

                    DataGridViewControl_OverheadAccountDetails.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        OverheadAccountDetails = DataGridViewControl_OverheadAccountDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.OverheadAccountDetail)().ToList

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            For Each OverheadAccountDetail In OverheadAccountDetails

                                OverheadAccountCode = OverheadAccountDetail.OverheadAccountCode

                                OverheadAccountGLAFromCode = OverheadAccountDetail.FromGLACode

                                Try

                                    OverHeadAccount = (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.Load(DbContext)
                                                       Where Entity.Code = OverheadAccountCode AndAlso
                                                             Entity.FromGLACode = OverheadAccountGLAFromCode
                                                       Select Entity).SingleOrDefault

                                Catch ex As Exception
                                    OverHeadAccount = Nothing
                                End Try

                                If OverHeadAccount IsNot Nothing Then

                                    If AdvantageFramework.Database.Procedures.OverheadAccount.Delete(DbContext, OverHeadAccount) = False Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Code is in use and cannot be deleted.")

                                    End If

                                End If

                            Next

                        End Using

                        Me.CloseWaitForm()

                        LoadControlDetails()

                    End If

                Else

                    DataGridViewControl_OverheadAccountDetails.CurrentView.DeleteSelectedRows()

                End If

            End If

        End Sub
        Public Sub ClearControl()

            TextBoxControl_Code.Text = Nothing
            TextBoxControl_Description.Text = Nothing

            DataGridViewControl_OverheadAccountDetails.DataSource = Nothing
            DataGridViewControl_OverheadAccountDetails.ClearColumns()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each OverheadAccountDetail In FillOverheadAccountDetailObjects()

                        OverheadAccountDetail.OverheadAccount.DbContext = DbContext

                        OverheadAccountDetail.OverheadAccount.Description = TextBoxControl_Description.Text

                        If AdvantageFramework.Database.Procedures.OverheadAccount.Update(DbContext, OverheadAccountDetail.OverheadAccount) = False Then

                            DbContext.UndoChanges(OverheadAccountDetail.OverheadAccount)

                        Else

                            Saved = True

                        End If

                    Next

                End Using

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
            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OverheadAccount = Me.FillObject(False)

                    If OverheadAccount IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.OverheadAccount.DeleteAllByCode(DbContext, OverheadAccount.Code) Then

                            Deleted = True

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("Code is in use and cannot be deleted.")

                        End If

                    End If

                End Using

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef Code As String) As Boolean

            'objects
            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing
            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing
            Dim OverheadAccountDetails As Generic.List(Of AdvantageFramework.Database.Classes.OverheadAccountDetail) = Nothing
            Dim OverheadAccountDescription As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    OverheadAccount = Me.FillObject(True)

                    If OverheadAccount IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.OverheadAccount.LoadAllByCode(DbContext, OverheadAccount.Code).Count > 0 Then

                            ErrorMessage = "Code entered is already on file.  Please enter a new code."

                        Else

                            OverheadAccount.DbContext = DbContext
                            OverheadAccountDescription = OverheadAccount.Description

                            OverheadAccountDetails = FillOverheadAccountDetailObjects()

                            If OverheadAccountDetails.Count = 0 Then

                                ErrorMessage = "From account for each table entry is required."

                            Else

                                For Each OverheadAccountDetail In OverheadAccountDetails

                                    OverheadAccount = New AdvantageFramework.Database.Entities.OverheadAccount

                                    OverheadAccount.DbContext = DbContext
                                    OverheadAccount.Code = OverheadAccountDetail.OverheadAccountCode
                                    OverheadAccount.Description = OverheadAccountDescription
                                    OverheadAccount.FromGLACode = OverheadAccountDetail.FromGLACode
                                    OverheadAccount.ToGLACode = OverheadAccountDetail.ToGLACode

                                    AdvantageFramework.Database.Procedures.OverheadAccount.Insert(DbContext, OverheadAccount)

                                    Inserted = True

                                Next

                                Code = OverheadAccount.Code

                            End If

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

#End Region

#Region "  Control Event Handlers "

        Private Sub OverheadAccountControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadModalOptions()

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_OverheadAccountDetails.AddNewRowEvent

            'objects
            Dim OverheadAccount As AdvantageFramework.Database.Entities.OverheadAccount = Nothing
            Dim OverheadAccountDetail As AdvantageFramework.Database.Classes.OverheadAccountDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Classes.OverheadAccountDetail Then

                If _OverheadAccountCode <> "" Then

                    Me.ShowWaitForm("Processing...")

                    OverheadAccountDetail = RowObject

                    Try

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            OverheadAccount = New AdvantageFramework.Database.Entities.OverheadAccount

                            OverheadAccount.DbContext = DbContext

                            OverheadAccount.Code = TextBoxControl_Code.Text
                            OverheadAccount.FromGLACode = OverheadAccountDetail.FromGLACode
                            OverheadAccount.Description = TextBoxControl_Description.Text
                            OverheadAccount.ToGLACode = OverheadAccountDetail.ToGLACode

                            AdvantageFramework.Database.Procedures.OverheadAccount.Insert(DbContext, OverheadAccount)

                            'LoadControlDetails()

                        End Using

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_ValidatingEditorEvent(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewControl_OverheadAccountDetails.ValidatingEditorEvent

            Dim CurrentGridView As GridView = Nothing
            Dim GLAccount As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing

            CurrentGridView = DirectCast(sender, GridView)

            If CurrentGridView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.OverheadAccount.Properties.FromGLACode.ToString OrElse
                    CurrentGridView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.OverheadAccount.Properties.ToGLACode.ToString Then

                If e.Value IsNot Nothing AndAlso e.Value <> "" Then

                    Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GLAccount = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                        If GLAccount Is Nothing Then

                            AdvantageFramework.WinForm.MessageBox.Show("Please enter a valid code.")

                            e.Valid = False

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_OverheadAccountDetails.SelectionChangedEvent

            RaiseEvent OverheadDetailsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_OverheadAccountDetails.InitNewRowEvent

            Dim GLA As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim CurrentGridView As GridView = Nothing

            CurrentGridView = DataGridViewControl_OverheadAccountDetails.CurrentView

            If TypeOf CurrentGridView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OverheadAccountDetail Then

                DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).OverheadAccountCode = TextBoxControl_Code.Text

                If CurrentGridView.FocusedColumn.FieldName = "FromGLACode" Then

                    DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).FromGLACode = CurrentGridView.EditingValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.Load(DbContext).ToList
                            Where Entity.Code.ToUpper = TextBoxControl_Code.Text.ToUpper AndAlso Entity.FromGLACode.ToUpper = CurrentGridView.EditingValue.ToString.ToUpper
                            Select Entity).Any Then

                            AdvantageFramework.WinForm.MessageBox.Show("Account already in list.  Please choose another account.")

                            CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromGLACode.ToString), "")
                            CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), "")

                        Else

                            GLA = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, CurrentGridView.EditingValue)

                            If GLA IsNot Nothing Then

                                CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), GLA.Description)

                            End If

                        End If

                    End Using

                ElseIf CurrentGridView.FocusedColumn.FieldName = "ToGLACode" Then

                    DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).ToGLACode = CurrentGridView.EditingValue

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        GLA = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, CurrentGridView.EditingValue)

                        If GLA IsNot Nothing Then

                            CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString), GLA.Description)

                        End If

                    End Using

                End If

                RaiseEvent OverheadDetailsInitNewRowEvent(sender, e)

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_CellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_OverheadAccountDetails.CellValueChangedEvent

            Dim GLA As AdvantageFramework.Database.Entities.GeneralLedgerAccount = Nothing
            Dim CurrentGridView As GridView = Nothing
            Dim ToGLACode As String = Nothing
            Dim FromGLACode As String = Nothing

            CurrentGridView = DataGridViewControl_OverheadAccountDetails.CurrentView

            If TypeOf CurrentGridView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Classes.OverheadAccountDetail Then

                If e.Column.FieldName = "FromGLACode" Then

                    If e.Value = "" Then

                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), "")

                    Else

                        ToGLACode = DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).ToGLACode

                        If ToGLACode Is Nothing Then

                            ToGLACode = ""

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            GLA = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GLA IsNot Nothing Then

                                If AccountsInUse(GLA.Code, ToGLACode, e.RowHandle) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("This account has already been included in a range of accounts.  Please select another account.")
                                    CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromGLACode.ToString), "")
                                    CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), "")

                                Else

                                    If (From Entity In AdvantageFramework.Database.Procedures.OverheadAccount.Load(DbContext).ToList
                                        Where Entity.Code.ToUpper = TextBoxControl_Code.Text.ToUpper AndAlso Entity.FromGLACode.ToUpper = e.Value.ToUpper
                                        Select Entity).Any Then

                                        AdvantageFramework.WinForm.MessageBox.Show("Account already in list.  Please choose another account.")

                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromGLACode.ToString), "")
                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), "")

                                    ElseIf ToGLACode <> "" AndAlso e.Value > ToGLACode Then

                                        AdvantageFramework.WinForm.MessageBox.Show("From account must be less than 'To' account.")

                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromGLACode.ToString), "")
                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), "")

                                    Else

                                        DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).FromGLACode = e.Value

                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromDescription.ToString), GLA.Description)

                                    End If

                                End If

                            End If

                        End Using

                    End If

                ElseIf e.Column.FieldName = "ToGLACode" Then

                    If e.Value = "" Then

                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString), "")

                    Else

                        FromGLACode = DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).FromGLACode

                        If FromGLACode Is Nothing Then

                            FromGLACode = ""

                        End If

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            GLA = AdvantageFramework.Database.Procedures.GeneralLedgerAccount.LoadByGLACode(DbContext, e.Value)

                            If GLA IsNot Nothing Then

                                If AccountsInUse(FromGLACode, GLA.Code, e.RowHandle) Then

                                    AdvantageFramework.WinForm.MessageBox.Show("This account has already been included in a range of accounts.  Please select another account.")
                                    CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToGLACode.ToString), "")
                                    CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString), "")

                                Else

                                    If FromGLACode <> "" AndAlso FromGLACode > e.Value Then

                                        AdvantageFramework.WinForm.MessageBox.Show("To account must be greater than 'From' account.")

                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToGLACode.ToString), "")
                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString), "")

                                    Else

                                        DirectCast(CurrentGridView.GetRow(e.RowHandle), AdvantageFramework.Database.Classes.OverheadAccountDetail).ToGLACode = e.Value

                                        CurrentGridView.SetRowCellValue(e.RowHandle, CurrentGridView.Columns(AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToDescription.ToString), GLA.Description)

                                    End If

                                End If

                            End If

                        End Using

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_ShowingEditorEvent(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles DataGridViewControl_OverheadAccountDetails.ShowingEditorEvent

            If DataGridViewControl_OverheadAccountDetails.CurrentView.IsNewItemRow(DataGridViewControl_OverheadAccountDetails.CurrentView.FocusedRowHandle) = False AndAlso _
                    DataGridViewControl_OverheadAccountDetails.CurrentView.FocusedColumn.FieldName <> AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.ToGLACode.ToString Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_ShownEditorEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_OverheadAccountDetails.ShownEditorEvent

            Dim edit As DevExpress.XtraEditors.BaseEdit = Nothing

            edit = CType(sender, AdvantageFramework.WinForm.Presentation.Controls.GridView).ActiveEditor

            If TypeOf edit Is DevExpress.XtraEditors.ButtonEdit Then

                If CType(edit, DevExpress.XtraEditors.ButtonEdit).Properties.Buttons.Count > 0 Then

                    CType(edit, DevExpress.XtraEditors.ButtonEdit).Properties.Buttons(0).Enabled = True

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_CustomDrawCellEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewControl_OverheadAccountDetails.CustomDrawCellEvent

            Dim CellInfo As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo = Nothing
            Dim ButtonEditViewInfo As DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Classes.OverheadAccountDetail.Properties.FromGLACode.ToString Then

                CellInfo = CType(e.Cell, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridCellInfo)

                ButtonEditViewInfo = CType(CellInfo.ViewInfo, DevExpress.XtraEditors.ViewInfo.ButtonEditViewInfo)

                If ButtonEditViewInfo.RightButtons.Count <> 0 Then

                    ButtonEditViewInfo.RightButtons(0).State = DevExpress.Utils.Drawing.ObjectState.Disabled

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_OverheadAccountDetails_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_OverheadAccountDetails.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        OverheadAccountDetailsCancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeleteOverheadAccountDetails()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub TextBoxControl_Code_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxControl_Code.TextChanged

            If TextBoxControl_Code.Text.Trim <> "" Then

                DataGridViewControl_OverheadAccountDetails.Enabled = True

            Else

                DataGridViewControl_OverheadAccountDetails.Enabled = False

            End If

        End Sub

#End Region

#Region "  Custom Control Event Handlers "


#End Region

#End Region

    End Class

End Namespace
