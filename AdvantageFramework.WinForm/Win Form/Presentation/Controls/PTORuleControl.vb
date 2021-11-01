Namespace WinForm.Presentation.Controls

    Public Class PTORuleControl

        Public Event PTORuleDetailsSelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs)
        Public Event PTORuleDetailsInitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs)
        Public Event PTORuleInActiveChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _PTORuleID As Integer = Nothing
        Private _IsLoading As Boolean = False
        Private _IsClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property PTORuleDetailsHasRows() As Boolean
            Get
                PTORuleDetailsHasRows = DataGridViewControl_RuleDetails.HasRows
            End Get
        End Property
        Public ReadOnly Property PTORuleDetailsHasOnlyOneSelectedRow(Optional ByVal ExcludeNonDataRows As Boolean = True) As Boolean
            Get
                PTORuleDetailsHasOnlyOneSelectedRow = DataGridViewControl_RuleDetails.HasOnlyOneSelectedRow(ExcludeNonDataRows)
            End Get
        End Property
        Public ReadOnly Property PTORuleDetailsIsNewItemRow(ByVal RowHandle As Integer) As Boolean
            Get
                PTORuleDetailsIsNewItemRow = DataGridViewControl_RuleDetails.CurrentView.IsNewItemRow(RowHandle)
            End Get
        End Property
        Public ReadOnly Property PTORuleDetailsFocusedRowHandle() As Integer
            Get
                PTORuleDetailsFocusedRowHandle = DataGridViewControl_RuleDetails.CurrentView.FocusedRowHandle
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

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            TextBoxControl_Name.SetPropertySettings(AdvantageFramework.Database.Entities.PTORule.Properties.Name)

                        End Using

                    End If

                    CheckBoxControl_Inactive.ByPassUserEntryChanged = True

                    RadioButtonControlPTOType_Personal.ByPassUserEntryChanged = True
                    RadioButtonControlPTOType_Sick.ByPassUserEntryChanged = True
                    RadioButtonControlPTOType_Vacation.ByPassUserEntryChanged = True

                    RadioButtonControlAction_Accrue.ByPassUserEntryChanged = True
                    RadioButtonControlAction_Replace.ByPassUserEntryChanged = True

                    CheckBoxControlOptions_Default.ByPassUserEntryChanged = True
                    CheckBoxControlOptions_Qualify.ByPassUserEntryChanged = True

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadModalOptions()

            If Me.FindForm.Modal Then

                DataGridViewControl_RuleDetails.UseEmbeddedNavigator = True

            Else

                DataGridViewControl_RuleDetails.UseEmbeddedNavigator = False

            End If

        End Sub
        Private Sub LoadControlDetails()

            Dim PTORuleDetails As Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _PTORuleID <> 0 Then

                    PTORuleDetails = AdvantageFramework.Database.Procedures.PTORuleDetail.LoadByPTORuleID(DbContext, _PTORuleID).ToList

                    If PTORuleDetails IsNot Nothing Then

                        LoadControlDetails(PTORuleDetails)

                    End If
                End If

            End Using

        End Sub
        Private Sub LoadControlDetails(ByVal PTORuleDetails As Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail))

            DataGridViewControl_RuleDetails.DataSource = PTORuleDetails

            DataGridViewControl_RuleDetails.CurrentView.BestFitColumns()

            DataGridViewControl_RuleDetails.CurrentView.AFActiveFilterString = "[IsInactive] = False"

        End Sub
        Private Sub LoadPTORuleEntity(ByVal PTORule As AdvantageFramework.Database.Entities.PTORule)

            If PTORule IsNot Nothing Then

                PTORule.Name = TextBoxControl_Name.Text

                PTORule.IsInactive = CheckBoxControl_Inactive.CheckValue

                If RadioButtonControlPTOType_Vacation.Checked = True Then
                    PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Vacation
                ElseIf RadioButtonControlPTOType_Sick.Checked = True Then
                    PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Sick
                ElseIf RadioButtonControlPTOType_Personal.Checked = True Then
                    PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Personal
                End If

                If RadioButtonControlAction_Accrue.Checked = True Then
                    PTORule.AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Accrue
                ElseIf RadioButtonControlAction_Replace.Checked = True Then
                    PTORule.AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Replace
                End If

                PTORule.IsDefault = CheckBoxControlOptions_Default.Checked

                PTORule.EqualQualifies = CheckBoxControlOptions_Qualify.Checked

            End If

        End Sub
        Private Sub SavePTORule(ByVal PTORuleProperty As AdvantageFramework.Database.Entities.PTORule.Properties, ByVal NewValue As Object)

            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                PTORule = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, _PTORuleID)

                If PTORule IsNot Nothing Then

                    Try

                        PropertyDescriptor = (From [Property] In System.ComponentModel.TypeDescriptor.GetProperties(PTORule).OfType(Of System.ComponentModel.PropertyDescriptor)()
                                              Where [Property].Name = PTORuleProperty.ToString
                                              Select [Property]).SingleOrDefault

                    Catch ex As Exception
                        PropertyDescriptor = Nothing
                    End Try

                    If PropertyDescriptor IsNot Nothing Then

                        PropertyDescriptor.SetValue(PTORule, NewValue)

                    End If

                    AdvantageFramework.Database.Procedures.PTORule.Update(DbContext, PTORule)

                End If

            End Using

        End Sub

#Region " Public "

        Public Function LoadControl(ByVal PTORuleID As Integer) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing

            _PTORuleID = PTORuleID

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _PTORuleID <> 0 Then

                    PTORule = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, _PTORuleID)

                    If PTORule IsNot Nothing Then

                        _IsLoading = True

                        TextBoxControl_Name.Text = PTORule.Name
                        CheckBoxControl_Inactive.CheckValue = PTORule.IsInactive
                        If PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Vacation Then
                            RadioButtonControlPTOType_Vacation.Checked = True
                        ElseIf PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Sick Then
                            RadioButtonControlPTOType_Sick.Checked = True
                        ElseIf PTORule.Type = AdvantageFramework.Database.Entities.PTOTypes.Personal Then
                            RadioButtonControlPTOType_Personal.Checked = True
                        End If
                        If PTORule.AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Accrue Then
                            RadioButtonControlAction_Accrue.Checked = True
                        ElseIf PTORule.AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Replace Then
                            RadioButtonControlAction_Replace.Checked = True
                        End If
                        CheckBoxControlOptions_Default.Checked = PTORule.IsDefault
                        CheckBoxControlOptions_Qualify.Checked = PTORule.EqualQualifies

                        LoadControlDetails()

                        _IsLoading = False

                    Else

                        Loaded = False

                    End If

                Else

                    LoadControlDetails(New Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail))

                End If

            End Using

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillPTORuleDetailObjects() As Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail)

            'objects
            Dim PTORuleDetails As Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail) = Nothing

            DataGridViewControl_RuleDetails.CurrentView.CloseEditorForUpdating()

            PTORuleDetails = DataGridViewControl_RuleDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PTORuleDetail).ToList

            FillPTORuleDetailObjects = PTORuleDetails

        End Function
        Public Sub PTORuleDetailsCancelNewItemRow()

            DataGridViewControl_RuleDetails.CancelNewItemRow()

        End Sub
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.PTORule

            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing

            Try

                If IsNew Then

                    PTORule = New AdvantageFramework.Database.Entities.PTORule

                    LoadPTORuleEntity(PTORule)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        PTORule = AdvantageFramework.Database.Procedures.PTORule.LoadByID(DbContext, _PTORuleID)

                    End Using

                    If PTORule IsNot Nothing Then

                        LoadPTORuleEntity(PTORule)

                    End If

                End If

            Catch ex As Exception
                PTORule = Nothing
            End Try

            FillObject = PTORule

        End Function
        Public Sub DeletePTORuleDetails()

            'objects
            Dim PTORuleDetails As Generic.List(Of AdvantageFramework.Database.Entities.PTORuleDetail) = Nothing

            If DataGridViewControl_RuleDetails.HasASelectedRow Then

                If _PTORuleID <> 0 Then

                    DataGridViewControl_RuleDetails.CurrentView.CloseEditorForUpdating()

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Me.ShowWaitForm("Processing...")

                        Try

                            PTORuleDetails = DataGridViewControl_RuleDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.PTORuleDetail)().ToList

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                For Each PTORuleDetail In PTORuleDetails

                                    AdvantageFramework.Database.Procedures.PTORuleDetail.Delete(DbContext, PTORuleDetail)

                                Next

                            End Using

                        Catch ex As Exception

                        End Try

                        Me.CloseWaitForm()

                        LoadControlDetails()

                    End If

                Else

                    DataGridViewControl_RuleDetails.CurrentView.DeleteSelectedRows()

                End If

            End If

        End Sub
        Public Sub ClearControl()

            _IsClearing = True

            TextBoxControl_Name.Text = Nothing
            CheckBoxControl_Inactive.Checked = False
            RadioButtonControlAction_Accrue.Checked = False
            RadioButtonControlAction_Replace.Checked = False
            RadioButtonControlPTOType_Personal.Checked = False
            RadioButtonControlPTOType_Sick.Checked = False
            RadioButtonControlPTOType_Vacation.Checked = False
            DataGridViewControl_RuleDetails.DataSource = Nothing
            DataGridViewControl_RuleDetails.ClearColumns()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsClearing = False

        End Sub
        Public Function Save() As Boolean

            'objects
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing
            Dim ErrorMessage As String = ""
            Dim Saved As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PTORule = Me.FillObject(False)

                    If PTORule IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.PTORule.Update(DbContext, PTORule) Then

                            Saved = True

                            For Each PTORuleDetail In FillPTORuleDetailObjects()

                                AdvantageFramework.Database.Procedures.PTORuleDetail.Update(DbContext, PTORuleDetail)

                            Next

                        End If

                    End If

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
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing
            Dim ErrorMessage As String = ""
            Dim Deleted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PTORule = Me.FillObject(False)

                    If PTORule IsNot Nothing Then

                        Deleted = AdvantageFramework.Database.Procedures.PTORule.Delete(DbContext, PTORule)

                        If Deleted = False Then

                            ErrorMessage = "The PTO Rule is in use and cannot be deleted."

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
        Public Function Insert(ByRef ID As Integer) As Boolean

            'objects
            Dim PTORule As AdvantageFramework.Database.Entities.PTORule = Nothing
            Dim ErrorMessage As String = Nothing
            Dim Inserted As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    PTORule = Me.FillObject(True)

                    If PTORule IsNot Nothing Then

                        PTORule.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.PTORule.Insert(DbContext, PTORule) Then

                            Inserted = True

                            For Each PTORuleDetail In FillPTORuleDetailObjects()

                                PTORuleDetail.PTORuleID = PTORule.ID

                                AdvantageFramework.Database.Procedures.PTORuleDetail.Insert(DbContext, PTORuleDetail)

                            Next

                            ID = PTORule.ID

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

        Private Sub PTORuleControl_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            LoadModalOptions()

        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub DataGridViewControl_RuleDetails_AddNewRowEvent(ByVal RowObject As Object) Handles DataGridViewControl_RuleDetails.AddNewRowEvent

            'objects
            Dim PTORuleDetail As AdvantageFramework.Database.Entities.PTORuleDetail = Nothing

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.PTORuleDetail Then

                If _PTORuleID <> 0 Then

                    Me.ShowWaitForm("Processing...")

                    PTORuleDetail = RowObject

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If PTORuleDetail.IsEntityBeingAdded() Then

                            PTORuleDetail.DbContext = DbContext

                            PTORuleDetail.PTORuleID = _PTORuleID

                            AdvantageFramework.Database.Procedures.PTORuleDetail.Insert(DbContext, PTORuleDetail)

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub DataGridViewControl_RuleDetails_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewControl_RuleDetails.SelectionChangedEvent

            RaiseEvent PTORuleDetailsSelectionChangedEvent(sender, e)

        End Sub
        Private Sub DataGridViewControl_RuleDetails_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewControl_RuleDetails.InitNewRowEvent

            If TypeOf DataGridViewControl_RuleDetails.CurrentView.GetRow(e.RowHandle) Is AdvantageFramework.Database.Entities.PTORuleDetail Then

                RaiseEvent PTORuleDetailsInitNewRowEvent(sender, e)

            End If

        End Sub
        Private Sub DataGridViewControl_RuleDetails_EmbeddedNavigatorButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.NavigatorButtonClickEventArgs) Handles DataGridViewControl_RuleDetails.EmbeddedNavigatorButtonClick

            If Not e.Handled Then

                Select Case CType(e.Button.Tag, DevExpress.XtraEditors.NavigatorButtonType)

                    Case DevExpress.XtraEditors.NavigatorButtonType.CancelEdit

                        DataGridViewControl_RuleDetails.CancelNewItemRow()

                        e.Handled = True

                    Case DevExpress.XtraEditors.NavigatorButtonType.Remove

                        DeletePTORuleDetails()

                        e.Handled = True

                End Select

            End If

        End Sub
        Private Sub DataGridViewControl_RuleDetails_CellValueChangingEvent(ByRef Saved As Boolean, ByVal e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewControl_RuleDetails.CellValueChangingEvent

            'objects
            Dim PTORuleDetail As AdvantageFramework.Database.Entities.PTORuleDetail = Nothing

            If e.RowHandle <> DevExpress.XtraGrid.GridControl.NewItemRowHandle AndAlso e.Column.FieldName = AdvantageFramework.Database.Entities.PTORuleDetail.Properties.IsInactive.ToString Then

                Try

                    PTORuleDetail = DataGridViewControl_RuleDetails.GetFirstSelectedRowDataBoundItem

                Catch ex As Exception
                    PTORuleDetail = Nothing
                End Try

                If PTORuleDetail IsNot Nothing Then

                    Try

                        PTORuleDetail.IsInactive = Convert.ToInt16(e.Value)

                    Catch ex As Exception
                        PTORuleDetail.IsInactive = PTORuleDetail.IsInactive
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Me.ShowWaitForm("Processing...")

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Saved = AdvantageFramework.Database.Procedures.PTORuleDetail.Update(DbContext, PTORuleDetail)

                        End Using

                        If Saved Then

                            DataGridViewControl_RuleDetails.CurrentView.RefreshData()

                        End If

                    Catch ex As Exception

                    Finally
                        Me.CloseWaitForm()
                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                End If

            End If

        End Sub
        Private Sub CheckBoxControl_Inactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControl_Inactive.CheckedChanged

            If Me.FindForm.Modal = False AndAlso Not _IsLoading AndAlso Not _IsClearing Then

                SavePTORule(AdvantageFramework.Database.Entities.PTORule.Properties.IsInactive, CheckBoxControl_Inactive.Checked)
                RaiseEvent PTORuleInActiveChanged()

            End If

        End Sub
        Private Sub CheckBoxControlOptions_Default_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControlOptions_Default.CheckedChanged

            If Me.FindForm.Modal = False AndAlso Not _IsLoading Then

                SavePTORule(AdvantageFramework.Database.Entities.PTORule.Properties.IsDefault, CheckBoxControlOptions_Default.Checked)

            End If

        End Sub
        Private Sub CheckBoxControlOptions_Qualify_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxControlOptions_Qualify.CheckedChanged

            If Me.FindForm.Modal = False AndAlso Not _IsLoading Then

                SavePTORule(AdvantageFramework.Database.Entities.PTORule.Properties.EqualQualifies, CheckBoxControlOptions_Qualify.Checked)

            End If

        End Sub
        Private Sub RadioButtonControlAction_Replace_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonControlAction_Replace.CheckedChanged

            Dim AppendReplace As Byte = 0

            If Me.FindForm.Modal = False AndAlso Not _IsLoading Then

                If RadioButtonControlAction_Accrue.Checked = True Then
                    AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Accrue
                ElseIf RadioButtonControlAction_Replace.Checked = True Then
                    AppendReplace = AdvantageFramework.Database.Entities.PTOActions.Replace
                End If

                If AppendReplace <> 0 Then

                    SavePTORule(AdvantageFramework.Database.Entities.PTORule.Properties.AppendReplace, AppendReplace)

                End If

            End If

        End Sub
        Private Sub RadioButtonControlPTOType_Personal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButtonControlPTOType_Personal.CheckedChanged, RadioButtonControlPTOType_Sick.CheckedChanged, RadioButtonControlPTOType_Vacation.CheckedChanged

            Dim Type As Byte = 0

            If Me.FindForm IsNot Nothing AndAlso Me.FindForm.Modal = False AndAlso Not _IsLoading Then

                If RadioButtonControlPTOType_Vacation.Checked = True Then
                    Type = AdvantageFramework.Database.Entities.PTOTypes.Vacation
                ElseIf RadioButtonControlPTOType_Sick.Checked = True Then
                    Type = AdvantageFramework.Database.Entities.PTOTypes.Sick
                ElseIf RadioButtonControlPTOType_Personal.Checked = True Then
                    Type = AdvantageFramework.Database.Entities.PTOTypes.Personal
                End If

                If Type <> 0 AndAlso GroupBoxControl_PTOType.Tag <> Type Then

                    SavePTORule(AdvantageFramework.Database.Entities.PTORule.Properties.Type, Type)
                    GroupBoxControl_PTOType.Tag = Type

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
