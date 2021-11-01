Namespace WinForm.Presentation.Controls

    Public Class CompanyProfileControl

        Public Event AffiliationInitNewRowEvent()
        Public Event AffiliationSelectionChangedEvent()
        Public Event NotesGotFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event NotesLostFocusEvent(ByVal sender As Object, ByVal e As System.EventArgs)

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
        Private _CompanyProfileID As Integer = 0
        Private _CompanyProfileAffiliationList As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing
        Private _CanUserUpdateInClientMaintenance As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property CanUserUpdateInClientMaintenance() As Boolean
            Get
                CanUserUpdateInClientMaintenance = _CanUserUpdateInClientMaintenance
            End Get
        End Property
        Public ReadOnly Property AffiliationsIsNewItemRow As Boolean
            Get
                AffiliationsIsNewItemRow = DataGridViewCompanyProfile_Affiliations.IsNewItemRow()
            End Get
        End Property
        Public ReadOnly Property AffiliationsHasOnlyOneSelectedRow As Boolean
            Get
                AffiliationsHasOnlyOneSelectedRow = DataGridViewCompanyProfile_Affiliations.HasOnlyOneSelectedRow
            End Get
        End Property
        Public ReadOnly Property IsNewCompanyProfile(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean
            Get

                'objects
                Dim NewCompanyProfile As Boolean = False

                Try

                    If AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode) IsNot Nothing Then

                        NewCompanyProfile = False

                    Else

                        NewCompanyProfile = True

                    End If

                Catch ex As Exception
                    NewCompanyProfile = True
                End Try

                IsNewCompanyProfile = NewCompanyProfile

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

                            SearchableComboBoxCompanyProfile_Industry.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.IndustryID)
                            SearchableComboBoxCompanyProfile_Industry.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

                            SearchableComboBoxCompanyProfile_Specialty.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.SpecialtyID)
                            SearchableComboBoxCompanyProfile_Specialty.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None

                            SearchableComboBoxCompanyProfile_Region.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.RegionCode)
                            SearchableComboBoxCompanyProfile_Region.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                            SearchableComboBoxViewCompanyProfile_Region.IsInGridLookupEditControl = True

                            NumericInputCompanyProfile_Revenue.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.Revenue)
                            NumericInputCompanyProfile_NumEmployees.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.NumberOfEmployees)

                            NumericInputCompanyProfile_TurnoverPercent.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.TurnoverPercent)

                            SearchableComboBoxCompanyProfile_ClientType1.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.ClientType1)
                            SearchableComboBoxCompanyProfile_ClientType1.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                            SearchableComboBoxCompanyProfile_ClientType1.AddInactiveItemsOnSelectedValue = True

                            SearchableComboBoxCompanyProfile_ClientType2.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.ClientType2)
                            SearchableComboBoxCompanyProfile_ClientType2.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                            SearchableComboBoxCompanyProfile_ClientType2.AddInactiveItemsOnSelectedValue = True

                            SearchableComboBoxCompanyProfile_ClientType3.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.ClientType3)
                            SearchableComboBoxCompanyProfile_ClientType3.ExtraComboBoxItem = SearchableComboBox.ExtraComboBoxItems.None
                            SearchableComboBoxCompanyProfile_ClientType3.AddInactiveItemsOnSelectedValue = True

                            TextBoxCompanyProfile_Notes.SetPropertySettings(AdvantageFramework.Database.Entities.CompanyProfile.Properties.Notes)

                            _CompanyProfileAffiliationList = New Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation)

                            DataGridViewCompanyProfile_Affiliations.DataSource = _CompanyProfileAffiliationList

                            ResetDataSources(DbContext)

                            If Me.CanUserUpdateInClientMaintenance Then

                                DataGridViewCompanyProfile_Affiliations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top

                            Else

                                DataGridViewCompanyProfile_Affiliations.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.None

                            End If

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal DbContext As AdvantageFramework.Database.DbContext) As AdvantageFramework.Database.Entities.CompanyProfile

            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

            Try

                CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                If CompanyProfile IsNot Nothing Then

                    LoadEntity(CompanyProfile)

                Else

                    CompanyProfile = New AdvantageFramework.Database.Entities.CompanyProfile

                    LoadEntity(CompanyProfile)

                End If

            Catch ex As Exception
                CompanyProfile = Nothing
            End Try

            FillObject = CompanyProfile

        End Function
        Private Sub LoadEntity(ByVal CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile)

            If CompanyProfile IsNot Nothing Then

                CompanyProfile.IndustryID = SearchableComboBoxCompanyProfile_Industry.GetSelectedValue
                CompanyProfile.SpecialtyID = SearchableComboBoxCompanyProfile_Specialty.GetSelectedValue
                CompanyProfile.RegionCode = SearchableComboBoxCompanyProfile_Region.GetSelectedValue
                CompanyProfile.Revenue = NumericInputCompanyProfile_Revenue.EditValue
                CompanyProfile.NumberOfEmployees = CInt(NumericInputCompanyProfile_NumEmployees.EditValue)
                CompanyProfile.Notes = TextBoxCompanyProfile_Notes.Text
                CompanyProfile.CaseStudyDone = CheckBoxCompanyProfile_CaseStudy.Checked
                CompanyProfile.UseAsReference = CheckBoxCompanyProfile_Reference.Checked

                CompanyProfile.TurnoverPercent = CDec(NumericInputCompanyProfile_TurnoverPercent.EditValue)
                CompanyProfile.ClientType1ID = SearchableComboBoxCompanyProfile_ClientType1.GetSelectedValue
                CompanyProfile.ClientType2ID = SearchableComboBoxCompanyProfile_ClientType2.GetSelectedValue
                CompanyProfile.ClientType3ID = SearchableComboBoxCompanyProfile_ClientType3.GetSelectedValue

            End If

        End Sub
        Private Sub LoadCompanyProfileAffiliations()

            If _CompanyProfileID <> 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _CompanyProfileAffiliationList = AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.LoadByCompanyProfileID(DbContext, _CompanyProfileID).ToList

                End Using

            End If

            DataGridViewCompanyProfile_Affiliations.DataSource = _CompanyProfileAffiliationList
            DataGridViewCompanyProfile_Affiliations.CurrentView.BestFitColumns()

        End Sub
        Protected Sub ResetDataSources(ByVal DbContext As AdvantageFramework.Database.DbContext)

            SearchableComboBoxCompanyProfile_Industry.DataSource = AdvantageFramework.Database.Procedures.Industry.LoadAllActive(DbContext)
            SearchableComboBoxCompanyProfile_Specialty.DataSource = AdvantageFramework.Database.Procedures.Specialty.LoadAllActive(DbContext)
            SearchableComboBoxCompanyProfile_Region.DataSource = AdvantageFramework.Database.Procedures.PrintSpecRegion.LoadAllActive(DbContext)
            SearchableComboBoxCompanyProfile_ClientType1.DataSource = AdvantageFramework.Database.Procedures.ClientType1.LoadAllActive(DbContext)
            SearchableComboBoxCompanyProfile_ClientType2.DataSource = AdvantageFramework.Database.Procedures.ClientType2.LoadAllActive(DbContext)
            SearchableComboBoxCompanyProfile_ClientType3.DataSource = AdvantageFramework.Database.Procedures.ClientType3.LoadAllActive(DbContext)

        End Sub
        Protected Sub ResetDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                ResetDataSources(DbContext)

            End Using

        End Sub

#Region "  Public "

        Public Function LoadControl(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing

            _ClientCode = ClientCode
            _DivisionCode = DivisionCode
            _ProductCode = ProductCode

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                    CompanyProfile = AdvantageFramework.Database.Procedures.CompanyProfile.LoadByClientAndDivisionAndProductCode(DbContext, _ClientCode, _DivisionCode, _ProductCode)

                    If CompanyProfile IsNot Nothing Then

                        SearchableComboBoxCompanyProfile_Industry.SelectedValue = CompanyProfile.IndustryID

                        SearchableComboBoxCompanyProfile_Specialty.SelectedValue = CompanyProfile.SpecialtyID

                        SearchableComboBoxCompanyProfile_Region.SelectedValue = CompanyProfile.RegionCode

                        NumericInputCompanyProfile_Revenue.EditValue = CompanyProfile.Revenue

                        NumericInputCompanyProfile_NumEmployees.EditValue = CompanyProfile.NumberOfEmployees

                        CheckBoxCompanyProfile_CaseStudy.Checked = CompanyProfile.CaseStudyDone

                        CheckBoxCompanyProfile_Reference.Checked = CompanyProfile.UseAsReference

                        NumericInputCompanyProfile_TurnoverPercent.EditValue = CompanyProfile.TurnoverPercent

                        SearchableComboBoxCompanyProfile_ClientType1.SelectedValue = CompanyProfile.ClientType1ID

                        SearchableComboBoxCompanyProfile_ClientType2.SelectedValue = CompanyProfile.ClientType2ID

                        SearchableComboBoxCompanyProfile_ClientType3.SelectedValue = CompanyProfile.ClientType3ID

                        TextBoxCompanyProfile_Notes.Text = CompanyProfile.Notes

                        _CompanyProfileID = CompanyProfile.ID

                    End If

                    LoadCompanyProfileAffiliations()

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function Save(ByVal DbContext As AdvantageFramework.Database.DbContext) As Boolean

            'objects
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                CompanyProfile = Me.FillObject(DbContext)

                If CompanyProfile.IsEntityBeingAdded() Then

                    CompanyProfile.ClientCode = _ClientCode
                    CompanyProfile.DivisionCode = _DivisionCode
                    CompanyProfile.ProductCode = _ProductCode

                    CompanyProfile.CreatedByUserCode = _Session.UserCode
                    CompanyProfile.CreateDate = Now

                    Saved = AdvantageFramework.Database.Procedures.CompanyProfile.Insert(DbContext, CompanyProfile)

                Else

                    CompanyProfile.ModifiedByUserCode = _Session.UserCode
                    CompanyProfile.ModifiedDate = Now

                    Saved = AdvantageFramework.Database.Procedures.CompanyProfile.Update(DbContext, CompanyProfile)

                End If

                If Saved Then

                    For Each Affiliation In _CompanyProfileAffiliationList

                        If Affiliation.IsEntityBeingAdded() Then

                            CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                            CompanyProfileAffiliation.DbContext = DbContext
                            CompanyProfileAffiliation.CompanyProfileID = CompanyProfile.ID
                            CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                            AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

                        End If

                    Next

                End If

                If Not Saved Then

                    ErrorMessage = "Failed trying to save data to the database. Please contact software support."

                Else

                    LoadCompanyProfileAffiliations()

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
            Dim CompanyProfile As AdvantageFramework.Database.Entities.CompanyProfile = Nothing
            Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing
            Dim ErrorMessage As String = ""
            Dim Inserted As Boolean = False

            Try

                CompanyProfile = Me.FillObject(DbContext)

                If CompanyProfile.IsEntityBeingAdded() Then

                    CompanyProfile.ClientCode = ClientCode
                    CompanyProfile.DivisionCode = DivisionCode
                    CompanyProfile.ProductCode = ProductCode

                    CompanyProfile.CreatedByUserCode = _Session.UserCode
                    CompanyProfile.CreateDate = Now

                    Inserted = AdvantageFramework.Database.Procedures.CompanyProfile.Insert(DbContext, CompanyProfile)

                Else

                    CompanyProfile.ModifiedByUserCode = _Session.UserCode
                    CompanyProfile.ModifiedDate = Now

                    Inserted = AdvantageFramework.Database.Procedures.CompanyProfile.Update(DbContext, CompanyProfile)

                End If

                If Inserted Then

                    For Each Affiliation In _CompanyProfileAffiliationList

                        If Affiliation.IsEntityBeingAdded() Then

                            CompanyProfileAffiliation = New AdvantageFramework.Database.Entities.CompanyProfileAffiliation

                            CompanyProfileAffiliation.DbContext = DbContext
                            CompanyProfileAffiliation.CompanyProfileID = CompanyProfile.ID
                            CompanyProfileAffiliation.AffiliationID = Affiliation.AffiliationID

                            AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation)

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

            SearchableComboBoxCompanyProfile_Industry.SelectedValue = Nothing
            SearchableComboBoxCompanyProfile_Specialty.SelectedValue = Nothing
            SearchableComboBoxCompanyProfile_Region.SelectedValue = Nothing
            NumericInputCompanyProfile_Revenue.EditValue = Nothing
            NumericInputCompanyProfile_NumEmployees.EditValue = Nothing
            TextBoxCompanyProfile_Notes.Text = Nothing
            CheckBoxCompanyProfile_CaseStudy.Checked = False
            CheckBoxCompanyProfile_Reference.Checked = False
            DataGridViewCompanyProfile_Affiliations.ClearDatasource(New Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation))

            NumericInputCompanyProfile_TurnoverPercent.EditValue = Nothing
            SearchableComboBoxCompanyProfile_ClientType1.SelectedValue = Nothing
            SearchableComboBoxCompanyProfile_ClientType2.SelectedValue = Nothing
            SearchableComboBoxCompanyProfile_ClientType3.SelectedValue = Nothing

            ResetDataSources()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

        End Sub
        Public Sub CancelAddNewCompanyProfileAffiliation()

            DataGridViewCompanyProfile_Affiliations.CancelNewItemRow()

        End Sub
        Public Sub DeleteSelectedCompanyProfileAffiliation()

            'objects
            Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing

            If DataGridViewCompanyProfile_Affiliations.HasOnlyOneSelectedRow Then

                If AdvantageFramework.WinForm.MessageBox.Show("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = AdvantageFramework.WinForm.MessageBox.DialogResults.Yes Then

                    Try

                        CompanyProfileAffiliation = DataGridViewCompanyProfile_Affiliations.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        CompanyProfileAffiliation = Nothing
                    End Try

                    If CompanyProfileAffiliation IsNot Nothing Then

                        If _ClientCode <> "" AndAlso _DivisionCode <> "" AndAlso _ProductCode <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                If AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Delete(DbContext, CompanyProfileAffiliation) Then

                                    LoadCompanyProfileAffiliations()

                                End If

                            End Using

                        Else

                            DataGridViewCompanyProfile_Affiliations.CurrentView.DeleteSelectedRows()

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub CompanyProfileControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load

            'ButtonRateTerm_UpdateFeeRetainer.icon = AdvantageFramework.My.Resources.MoneyUpdateImage

            DataGridViewCompanyProfile_Affiliations.CurrentView.OptionsView.ColumnAutoWidth = True

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewCompanyProfile_Affiliations_AddNewRowEvent(RowObject As Object) Handles DataGridViewCompanyProfile_Affiliations.AddNewRowEvent

            'objects
            Dim CompanyProfileAffiliation As AdvantageFramework.Database.Entities.CompanyProfileAffiliation = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.CompanyProfileAffiliation Then

                AdvantageFramework.WinForm.Presentation.ShowWaitForm("Adding...")

                CompanyProfileAffiliation = RowObject

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If CompanyProfileAffiliation.IsEntityBeingAdded() Then

                        If _CompanyProfileID <> 0 Then

                            CompanyProfileAffiliation.DbContext = DbContext

                            CompanyProfileAffiliation.CompanyProfileID = _CompanyProfileID

                            If AdvantageFramework.Database.Procedures.CompanyProfileAffiliation.Insert(DbContext, CompanyProfileAffiliation) Then

                                DataGridViewCompanyProfile_Affiliations.SelectRow(CompanyProfileAffiliation.ID)

                            End If

                        Else

                            DataGridViewCompanyProfile_Affiliations.SetUserEntryChanged()

                        End If

                        LoadCompanyProfileAffiliations()

                    End If

                End Using

                AdvantageFramework.WinForm.Presentation.CloseWaitForm()

            End If

        End Sub
        Private Sub DataGridViewCompanyProfile_Affiliations_InitNewRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewCompanyProfile_Affiliations.InitNewRowEvent

            RaiseEvent AffiliationInitNewRowEvent()

        End Sub
        Private Sub DataGridViewCompanyProfile_Affiliations_NewItemRowCellValueChangedEvent(e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewCompanyProfile_Affiliations.NewItemRowCellValueChangedEvent

            Dim CompanyProfileAffiliationList As Generic.List(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation) = Nothing

            If e.Column.FieldName = AdvantageFramework.Database.Entities.CompanyProfileAffiliation.Properties.AffiliationID.ToString Then

                CompanyProfileAffiliationList = DataGridViewCompanyProfile_Affiliations.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.CompanyProfileAffiliation)().ToList

                If CompanyProfileAffiliationList.Where(Function(Entity) Entity.AffiliationID = e.Value).Any Then

                    AdvantageFramework.WinForm.MessageBox.Show("Affiliation has already been added.  Please choose another.")

                    DataGridViewCompanyProfile_Affiliations.CurrentView.SetRowCellValue(e.RowHandle, AdvantageFramework.Database.Entities.CompanyProfileAffiliation.Properties.AffiliationID.ToString, 0)

                End If

            End If

        End Sub
        Private Sub DataGridViewCompanyProfile_Affiliations_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewCompanyProfile_Affiliations.SelectionChangedEvent

            RaiseEvent AffiliationSelectionChangedEvent()

        End Sub
        Private Sub DataGridViewCompanyProfile_Affiliations_ShowingEditorEvent(sender As Object, e As ComponentModel.CancelEventArgs) Handles DataGridViewCompanyProfile_Affiliations.ShowingEditorEvent

            If DataGridViewCompanyProfile_Affiliations.IsNewItemRow = False Then

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewCompanyProfile_Affiliations_ShownEditorEvent(sender As Object, e As EventArgs) Handles DataGridViewCompanyProfile_Affiliations.ShownEditorEvent

            Dim GridLookUpEdit As DevExpress.XtraEditors.GridLookUpEdit = Nothing
            Dim BindingSource As System.Windows.Forms.BindingSource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If TypeOf DataGridViewCompanyProfile_Affiliations.CurrentView.ActiveEditor Is DevExpress.XtraEditors.GridLookUpEdit Then

                    GridLookUpEdit = DataGridViewCompanyProfile_Affiliations.CurrentView.ActiveEditor

                    If DataGridViewCompanyProfile_Affiliations.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Entities.CompanyProfileAffiliation.Properties.AffiliationID.ToString Then

                        BindingSource = New System.Windows.Forms.BindingSource
                        BindingSource.DataSource = AdvantageFramework.Database.Procedures.Affiliation.LoadAllActive(DbContext).ToList

                        GridLookUpEdit.Properties.DataSource = BindingSource

                    End If

                End If

            End Using

        End Sub
        Private Sub TextBoxCompanyProfile_Notes_GotFocus(sender As Object, e As EventArgs) Handles TextBoxCompanyProfile_Notes.GotFocus

            RaiseEvent NotesGotFocusEvent(sender, e)

        End Sub
        Private Sub TextBoxCompanyProfile_Notes_LostFocus(sender As Object, e As EventArgs) Handles TextBoxCompanyProfile_Notes.LostFocus

            RaiseEvent NotesLostFocusEvent(sender, e)

        End Sub

#End Region

#End Region

    End Class

End Namespace
