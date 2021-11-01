Namespace WinForm.Presentation.Controls

    Public Class ActivitySummaryControl

        Public Event CompetitorInitNewRowEvent()
        Public Event CompetitorSelectionChangedEvent()
        Public Event CRMActivitySelectionChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _ClientCode As String = Nothing
        Private _DivisionCode As String = Nothing
        Private _ProductCode As String = Nothing
        Private _ActivityID As Integer = 0
        Private _ActivityCompetitionList As Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition) = Nothing
        Private _CanUserUpdateInClientMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInClientMaintenance() As Boolean
            Get
                CanUserUpdateInClientMaintenance = _CanUserUpdateInClientMaintenance
            End Get
        End Property
        Public ReadOnly Property SelectedCRMActivityIsDiaryEntry() As Boolean
            Get
                Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

                CRMActivitySummary = DataGridViewActivitySummary_Summary.GetFirstSelectedRowDataBoundItem

                If DataGridViewActivitySummary_Summary.HasOnlyOneSelectedRow AndAlso CRMActivitySummary.AlertID IsNot Nothing AndAlso CRMActivitySummary.ActivityType = "Diary" Then

                    SelectedCRMActivityIsDiaryEntry = True

                Else

                    SelectedCRMActivityIsDiaryEntry = False

                End If

            End Get
        End Property
        Public ReadOnly Property SelectedCRMActivityAlertID() As Integer
            Get
                Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing

                CRMActivitySummary = DataGridViewActivitySummary_Summary.GetFirstSelectedRowDataBoundItem

                SelectedCRMActivityAlertID = CRMActivitySummary.AlertID

            End Get
        End Property
        Public ReadOnly Property CompetitorsIsNewItemRow As Boolean
            Get
                CompetitorsIsNewItemRow = DataGridViewActivitySummary_Competitors.IsNewItemRow()
            End Get
        End Property
        Public ReadOnly Property CompetitorsHasOnlyOneSelectedRow As Boolean
            Get
                CompetitorsHasOnlyOneSelectedRow = DataGridViewActivitySummary_Competitors.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property IsNewActivitySummary(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean
            Get

                'objects
                Dim NewActivitySummary As Boolean = False

                Try

                    If AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode) IsNot Nothing Then

                        NewActivitySummary = False

                    Else

                        NewActivitySummary = True

                    End If

                Catch ex As Exception
                    NewActivitySummary = True
                End Try

                IsNewActivitySummary = NewActivitySummary

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

            If _FormSettingsLoaded = False AndAlso Me.Name <> "" AndAlso
                    Form.Controls.Find(Me.Name, True).Any Then

                If TypeOf Form Is AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm Then

                    If DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator IsNot Nothing Then

                        DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).SuperValidator.SetValidator1(Me, New AdvantageFramework.WinForm.Presentation.Controls.Validation.CustomValidatorControl)

                    End If

                    _Session = DirectCast(Form, AdvantageFramework.WinForm.Presentation.BaseForms.Interfaces.IBaseForm).Session

                    If _Session IsNot Nothing Then

                        _CanUserUpdateInClientMaintenance = AdvantageFramework.Security.CanUserUpdateInModule(_Session, AdvantageFramework.Security.Modules.Maintenance_Client_Client)

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            DateTimePickerActivitySummary_LastContactDate.ValueObject = Nothing
                            DateTimePickerActivitySummary_LeadDate.ValueObject = Nothing
                            DateTimePickerActivitySummary_LostDate.ValueObject = Nothing
                            DateTimePickerActivitySummary_SoldDate.ValueObject = Nothing

                            SearchableComboBoxActivitySummary_Source.SetPropertySettings(AdvantageFramework.Database.Entities.Activity.Properties.SourceID)
                            SearchableComboBoxActivitySummary_Source.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

                            SearchableComboBoxActivitySummary_Rating.SetPropertySettings(AdvantageFramework.Database.Entities.Activity.Properties.RatingID)
                            SearchableComboBoxActivitySummary_Rating.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

                            _ActivityCompetitionList = New Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition)

                            DataGridViewActivitySummary_Competitors.DataSource = _ActivityCompetitionList

                            NumericInputActivitySummary_Probability.Properties.MaxLength = 3
                            NumericInputActivitySummary_Probability.Properties.MinValue = 0
                            NumericInputActivitySummary_Probability.Properties.MaxValue = 100

                            NumericInputActivitySummary_TotalOpportunity.SetPropertySettings(AdvantageFramework.Database.Entities.Contract.Properties.ProductionCommission)

                            TextBoxActivitySummary_LastActivityDate.ByPassUserEntryChanged = True
                            DataGridViewActivitySummary_Summary.ByPassUserEntryChanged = True

                            ResetDataSources(DbContext)

                            If Me.CanUserUpdateInClientMaintenance Then

                                DataGridViewActivitySummary_Competitors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                            Else

                                DataGridViewActivitySummary_Competitors.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                            End If

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.Activity

            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            Try

                Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                If Activity IsNot Nothing Then

                    LoadEntity(Activity)

                Else

                    Activity = New AdvantageFramework.Database.Entities.Activity

                    LoadEntity(Activity)

                End If

            Catch ex As Exception
                Activity = Nothing
            End Try

            FillObject = Activity

        End Function
        Private Sub LoadEntity(ByVal Activity As AdvantageFramework.Database.Entities.Activity)

            If Activity IsNot Nothing Then

                Activity.LeadDate = DateTimePickerActivitySummary_LeadDate.GetValue
                Activity.SourceID = SearchableComboBoxActivitySummary_Source.GetSelectedValue
                Activity.LastContactDate = DateTimePickerActivitySummary_LastContactDate.GetValue
                Activity.Probability = CByte(NumericInputActivitySummary_Probability.EditValue)
                Activity.RatingID = SearchableComboBoxActivitySummary_Rating.GetSelectedValue
                Activity.CurrentProvider = TextBoxActivitySummary_CurrentProvider.Text
                Activity.SoldDate = DateTimePickerActivitySummary_SoldDate.GetValue
                Activity.LostDate = DateTimePickerActivitySummary_LostDate.GetValue

            End If

        End Sub
        Private Sub LoadActivitySummary()

            Dim CRMActivitySummaryList As Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary) = Nothing
            Dim CRMActivitySummary As AdvantageFramework.Database.Classes.CRMActivitySummary = Nothing
            Dim GridColumn As DevExpress.XtraGrid.Columns.GridColumn = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                CRMActivitySummaryList = New Generic.List(Of AdvantageFramework.Database.Classes.CRMActivitySummary)

                CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.Alert.LoadByTypeIDAndClientAndDivisionAndProductCode(DbContext, 11, _ClientCode, _DivisionCode, _ProductCode).ToList
                                                Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                CRMActivitySummaryList.AddRange(From Entity In AdvantageFramework.Database.Procedures.EmployeeNonTask.LoadByCallMeetingToDoAndClientAndDivisionAndProductCode(DbContext, "C", _ClientCode, _DivisionCode, _ProductCode).ToList
                                                Select New AdvantageFramework.Database.Classes.CRMActivitySummary(DbContext, Entity))

                If CRMActivitySummaryList.Count > 0 Then

                    DataGridViewActivitySummary_Summary.DataSource = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate)

                Else

                    DataGridViewActivitySummary_Summary.DataSource = CRMActivitySummaryList

                End If

                DataGridViewActivitySummary_Summary.CurrentView.BestFitColumns()

                If DataGridViewActivitySummary_Summary.CurrentView.VisibleColumns.Count > 1 Then

                    DataGridViewActivitySummary_Summary.CurrentView.Columns(AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.ActivityDate.ToString).Width = 130
                    DataGridViewActivitySummary_Summary.CurrentView.Columns(AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.Body.ToString).Width = 300

                End If

                Try

                    CRMActivitySummary = CRMActivitySummaryList.OrderByDescending(Function(E) E.ActivityDate).FirstOrDefault

                    If CRMActivitySummary IsNot Nothing Then

                        TextBoxActivitySummary_LastActivityDate.Text = CRMActivitySummary.ActivityDate

                    End If

                Catch ex As Exception

                End Try

                GridColumn = DataGridViewActivitySummary_Summary.Columns(AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.Body.ToString)
                GridColumn.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.True

            End Using

        End Sub
        Private Sub LoadActivitySummaryCompetitors()

            If _ActivityID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _ActivityCompetitionList = AdvantageFramework.Database.Procedures.ActivityCompetition.LoadByActivityID(DbContext, _ActivityID).ToList

                End Using

            End If

            DataGridViewActivitySummary_Competitors.DataSource = _ActivityCompetitionList
            DataGridViewActivitySummary_Competitors.CurrentView.BestFitColumns()

        End Sub
        Private Sub LoadTotalOpportunity(ByVal DbContext As AdvantageFramework.Database.DbContext)

            Dim TotalAmount As Decimal = 0

            Try

                TotalAmount = (From Entity In AdvantageFramework.Database.Procedures.Contract.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)
                               Where Entity.IsInactive = False
                               Select Entity).Sum(Function(Contract) Contract.FeeIncentiveBonus +
                                                                        Contract.FeeProjectHourly +
                                                                        Contract.FeeRetainer +
                                                                        Contract.FeeRoyalty +
                                                                        Contract.MediaCommission +
                                                                        Contract.ProductionCommission)

            Catch ex As Exception
                TotalAmount = 0
            End Try

            NumericInputActivitySummary_TotalOpportunity.EditValue = TotalAmount

        End Sub
        Private Sub LoadTotalOpportunity()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                LoadTotalOpportunity(DbContext)

            End Using

        End Sub
        Protected Sub ResetDataSources(ByVal DbContext As AdvantageFramework.Database.DbContext)

            SearchableComboBoxActivitySummary_Source.DataSource = AdvantageFramework.Database.Procedures.Source.LoadAllActive(DbContext)
            SearchableComboBoxActivitySummary_Rating.DataSource = AdvantageFramework.Database.Procedures.Rating.LoadAllActive(DbContext)

        End Sub
        Protected Sub ResetDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ResetDataSources(DbContext)

            End Using

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String, ByVal IsNewBusiness As Boolean) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            LabelActivitySummary_TotalOpportunity.Visible = IsNewBusiness
            NumericInputActivitySummary_TotalOpportunity.Visible = IsNewBusiness

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If Activity IsNot Nothing Then

                        DateTimePickerActivitySummary_LeadDate.ValueObject = Activity.LeadDate

                        SearchableComboBoxActivitySummary_Source.SelectedValue = Activity.SourceID

                        DateTimePickerActivitySummary_LastContactDate.ValueObject = Activity.LastContactDate
                        DateTimePickerActivitySummary_SoldDate.ValueObject = Activity.SoldDate
                        DateTimePickerActivitySummary_LostDate.ValueObject = Activity.LostDate

                        NumericInputActivitySummary_Probability.EditValue = Activity.Probability

                        SearchableComboBoxActivitySummary_Rating.SelectedValue = Activity.RatingID

                        TextBoxActivitySummary_CurrentProvider.Text = Activity.CurrentProvider

                        _ActivityID = Activity.ID

                    Else

                        DateTimePickerActivitySummary_LeadDate.ValueObject = Nothing
                        DateTimePickerActivitySummary_LastContactDate.ValueObject = Nothing
                        DateTimePickerActivitySummary_SoldDate.ValueObject = Nothing
                        DateTimePickerActivitySummary_LostDate.ValueObject = Nothing

                    End If

                    If IsNewBusiness Then

                        LoadTotalOpportunity(DbContext)

                    End If

                    LoadActivitySummaryCompetitors()

                    LoadActivitySummary()

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Activity = Me.FillObject(DbContext)

                If Activity.IsEntityBeingAdded() Then

                    Activity.ClientCode = _ClientCode
                    Activity.DivisionCode = _DivisionCode
                    Activity.ProductCode = _ProductCode

                    Activity.CreatedByUserCode = _Session.UserCode
                    Activity.CreateDate = Now

                    Saved = AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, Activity)

                Else

                    Activity.ModifiedByUserCode = _Session.UserCode
                    Activity.ModifiedDate = Now

                    Saved = AdvantageFramework.Database.Procedures.Activity.Update(DbContext, Activity)

                End If

                If Saved Then

                    For Each Competition In _ActivityCompetitionList

                        If Competition.IsEntityBeingAdded() Then

                            ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                            ActivityCompetition.DbContext = DbContext
                            ActivityCompetition.ActivityID = Activity.ID
                            ActivityCompetition.CompetitionID = Competition.CompetitionID

                            AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                        End If

                    Next

                End If

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                Else

                    LoadActivitySummaryCompetitors()

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to save data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Save = Saved

        End Function
        Public Function Save() As Boolean

            'objects
            Dim Saved As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Saved = Save(DbContext)

            End Using

            Save = Saved

        End Function
        Public Function Insert(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Inserted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Inserted = Insert(DbContext, ClientCode, DivisionCode, ProductCode)

            End Using

            Insert = Inserted

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
            Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing
            Dim ErrorMessage As String = ""
            Dim Inserted As Boolean = False

            Try

                Activity = Me.FillObject(DbContext)

                If Activity.IsEntityBeingAdded() Then

                    Activity.ClientCode = ClientCode
                    Activity.DivisionCode = DivisionCode
                    Activity.ProductCode = ProductCode

                    Activity.CreatedByUserCode = _Session.UserCode
                    Activity.CreateDate = Now

                    Inserted = AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, Activity)

                Else

                    Activity.ModifiedByUserCode = _Session.UserCode
                    Activity.ModifiedDate = Now

                    Inserted = AdvantageFramework.Database.Procedures.Activity.Update(DbContext, Activity)

                End If

                If Inserted Then

                    For Each Competition In _ActivityCompetitionList

                        If Competition.IsEntityBeingAdded() Then

                            ActivityCompetition = New AdvantageFramework.Database.Entities.ActivityCompetition

                            ActivityCompetition.DbContext = DbContext
                            ActivityCompetition.ActivityID = Activity.ID
                            ActivityCompetition.CompetitionID = Competition.CompetitionID

                            AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition)

                        End If

                    Next

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to insert data to the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Insert = Inserted

        End Function
        Public Sub ClearControl()

            DateTimePickerActivitySummary_LeadDate.Value = Nothing
            SearchableComboBoxActivitySummary_Source.SelectedValue = Nothing
            TextBoxActivitySummary_LastActivityDate.Text = Nothing
            DateTimePickerActivitySummary_LastContactDate.Value = Nothing
            DateTimePickerActivitySummary_SoldDate.Value = Nothing
            DateTimePickerActivitySummary_LostDate.Value = Nothing
            NumericInputActivitySummary_Probability.EditValue = Nothing
            SearchableComboBoxActivitySummary_Rating.SelectedValue = Nothing
            DataGridViewActivitySummary_Competitors.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition))

            ResetDataSources()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CancelAddNewActivityCompetitor()

            DataGridViewActivitySummary_Competitors.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedActivityCompetitor()

            'objects
            Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing

            If DataGridViewActivitySummary_Competitors.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        ActivityCompetition = DataGridViewActivitySummary_Competitors.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ActivityCompetition = Nothing
                    End Try

                    If ActivityCompetition IsNot Nothing Then

                        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.ActivityCompetition.Delete(DbContext, ActivityCompetition) Then

                                    LoadActivitySummaryCompetitors()

                                End If

                            End Using

                        Else

                            DataGridViewActivitySummary_Competitors.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub RefreshActivitySummary()

            LoadActivitySummary()

        End Sub
        Public Sub RefreshTotalOpportunity()

            LoadTotalOpportunity()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ActivitySummaryControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'ButtonRateTerm_UpdateFeeRetainer.icon = AdvantageFramework.My.Resources.MoneyUpdateImage

            DataGridViewActivitySummary_Competitors.CurrentView.OptionsView.ColumnAutoWidth = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewActivitySummary_Competitors_AddNewRowEvent(RowObject As Object) Handles DataGridViewActivitySummary_Competitors.AddNewRowEvent

            'objects
            Dim ActivityCompetition As AdvantageFramework.Database.Entities.ActivityCompetition = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.ActivityCompetition Then

                Me.ShowWaitForm("Processing...")

                ActivityCompetition = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If ActivityCompetition.IsEntityBeingAdded() Then

                        If _ActivityID <> 0 Then

                            ActivityCompetition.DbContext = DbContext

                            ActivityCompetition.ActivityID = _ActivityID

                            If AdvantageFramework.Database.Procedures.ActivityCompetition.Insert(DbContext, ActivityCompetition) Then

                                DataGridViewActivitySummary_Competitors.SelectRow(ActivityCompetition.ID)

                            End If

                        Else

                            DataGridViewActivitySummary_Competitors.SetUserEntryChanged()

                        End If

                        LoadActivitySummaryCompetitors()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewActivitySummary_Competitors_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewActivitySummary_Competitors.InitNewRowEvent

            RaiseEvent CompetitorInitNewRowEvent()

        End Sub
        Private Sub DataGridViewActivitySummary_Competitors_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewActivitySummary_Competitors.NewItemRowCellValueChangedEvent

            Dim ActivityCompetitionList As Generic.List(Of AdvantageFramework.Database.Entities.ActivityCompetition) = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.ActivityCompetition.Properties.CompetitionID.ToString AndAlso DataGridViewActivitySummary_Competitors.CurrentView.IsNewItemRow(e.RowHandle) Then

                ActivityCompetitionList = DataGridViewActivitySummary_Competitors.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.ActivityCompetition)().ToList

                If ActivityCompetitionList.Where(Function(Entity) Entity.CompetitionID = e.Value).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Competitor has already been added.  Please choose another.")

                    DataGridViewActivitySummary_Competitors.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.ActivityCompetition.Properties.CompetitionID.ToString, 0)

                End If

            End If

        End Sub
        Private Sub DataGridViewActivitySummary_Competitors_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewActivitySummary_Competitors.SelectionChangedEvent

            RaiseEvent CompetitorSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewActivitySummary_Competitors_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewActivitySummary_Competitors.ShowingEditorEvent

            If DataGridViewActivitySummary_Competitors.IsNewItemRow = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewActivitySummary_Competitors_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewActivitySummary_Competitors.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If TypeOf DataGridViewActivitySummary_Competitors.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DataGridViewActivitySummary_Competitors.CurrentView.ActiveEditor

                    If DataGridViewActivitySummary_Competitors.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.ActivityCompetition.Properties.CompetitionID.ToString Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.Database.Procedures.Competition.LoadAllActive(DbContext).ToList

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    End If

                End If

            End Using

        End Sub
        Private Sub DataGridViewActivitySummary_Summary_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewActivitySummary_Summary.CustomDrawCellEvent

            If e.Column.FieldName = AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.ActivityDate.ToString Then

				e.DisplayText = If(e.CellValue IsNot Nothing, Format(e.CellValue, "g"), Nothing)

			End If

        End Sub
        Private Sub DataGridViewActivitySummary_Summary_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewActivitySummary_Summary.SelectionChangedEvent

            RaiseEvent CRMActivitySelectionChangedEvent()

        End Sub
        Private Sub DataGridViewActivitySummary_Summary_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewActivitySummary_Summary.ShownEditorEvent

            Dim MemoExEdit As DevExpress.XtraEditors.MemoExEdit = Nothing

            If TypeOf DataGridViewActivitySummary_Summary.CurrentView.ActiveEditor Is DevExpress.XtraEditors.MemoExEdit Then

                If DataGridViewActivitySummary_Summary.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.CRMActivitySummary.Properties.Body.ToString Then

                    MemoExEdit = DataGridViewActivitySummary_Summary.CurrentView.ActiveEditor
                    MemoExEdit.Properties.ReadOnly = True

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
