Namespace Exporting.Presentation

    Public Class ExportTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "


#End Region

#Region " Variables "

        Private _ExportType As AdvantageFramework.Exporting.ExportTypes = ExportTypes.MediaPlanData
        Private _ExportTemplateID As Integer = 0
        Private _ExportFields As Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField) = Nothing
        Private _AvailableFields As Generic.List(Of AdvantageFramework.Exporting.Classes.AvailableField) = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property ExportTemplateID As Integer
            Get
                ExportTemplateID = _ExportTemplateID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByVal ExportTemplateID As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            _ExportType = ExportType
            _ExportTemplateID = ExportTemplateID

        End Sub
        Private Sub LoadGrids(ByVal ShowFixedTemplateColumns As Boolean)

            DataGridViewLeftSection_AvailableTemplateDetails.DataSource = _AvailableFields
            DataGridViewRightSection_TemplateDetails.DataSource = _ExportFields.OrderBy(Function(EF) EF.Position).ToList

            DataGridViewRightSection_TemplateDetails.MakeColumnNotVisible(AdvantageFramework.Exporting.Classes.ExportField.Properties.Start.ToString)
            DataGridViewRightSection_TemplateDetails.MakeColumnNotVisible(AdvantageFramework.Exporting.Classes.ExportField.Properties.Length.ToString)

            If ShowFixedTemplateColumns Then

                DataGridViewRightSection_TemplateDetails.MakeColumnVisible(AdvantageFramework.Exporting.Classes.ExportField.Properties.Start.ToString)
                DataGridViewRightSection_TemplateDetails.MakeColumnVisible(AdvantageFramework.Exporting.Classes.ExportField.Properties.Length.ToString)

            End If

            DataGridViewLeftSection_AvailableTemplateDetails.CurrentView.BestFitColumns()
            DataGridViewRightSection_TemplateDetails.CurrentView.BestFitColumns()

        End Sub
        Private Sub RefreshExportFieldsPositions()

            For Each ExportField In _ExportFields

                ExportField.Position = _ExportFields.IndexOf(ExportField)

            Next

        End Sub
        Private Sub EnableOrDisableActions()

            ButtonRightSection_AddTemplateDetail.Enabled = DataGridViewLeftSection_AvailableTemplateDetails.HasASelectedRow
            ButtonRightSection_RemoveTemplateDetail.Enabled = DataGridViewRightSection_TemplateDetails.HasASelectedRow

            ButtonRightSection_MoveUp.Enabled = DataGridViewRightSection_TemplateDetails.HasOnlyOneSelectedRow
            ButtonRightSection_MoveDown.Enabled = DataGridViewRightSection_TemplateDetails.HasOnlyOneSelectedRow

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByRef ExportTemplateID As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ExportTemplateEditDialog As AdvantageFramework.Exporting.Presentation.ExportTemplateEditDialog = Nothing

            ExportTemplateEditDialog = New AdvantageFramework.Exporting.Presentation.ExportTemplateEditDialog(ExportType, ExportTemplateID)

            ShowFormDialog = ExportTemplateEditDialog.ShowDialog()

            ExportTemplateID = ExportTemplateEditDialog.ExportTemplateID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim PropertyDescriptors As Generic.List(Of System.ComponentModel.PropertyDescriptor) = Nothing
            Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing

            DataGridViewLeftSection_AvailableTemplateDetails.OptionsView.ShowFooter = False

            DataGridViewRightSection_TemplateDetails.OptionsView.ShowFooter = False

            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowColumnMoving = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowSort = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowQuickHideColumns = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowGroup = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowFilter = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowRowSizing = False
            DataGridViewRightSection_TemplateDetails.OptionsCustomization.AllowColumnResizing = True

            DataGridViewRightSection_TemplateDetails.OptionsMenu.EnableColumnMenu = False

            DataGridViewRightSection_TemplateDetails.RunStandardValidation = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Name.SetPropertySettings(AdvantageFramework.Database.Entities.ExportTemplate.Properties.Name)
                TextBoxForm_DefaultDirectory.SetPropertySettings(AdvantageFramework.Database.Entities.ExportTemplate.Properties.DefaultDirectory)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    TextBoxForm_DefaultDirectory.SecurityEnabled = False

                End If

                PropertyDescriptors = AdvantageFramework.Exporting.LoadPropertiesByExportTemplateType(_ExportType)

                If _ExportTemplateID = 0 Then

                    Me.Text = "Add Export Template"
                    Me.ButtonForm_Add.Visible = True
                    Me.ButtonForm_Update.Visible = False

                    _ExportFields = New Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)
                    _AvailableFields = PropertyDescriptors.Select(Function(PD) New AdvantageFramework.Exporting.Classes.AvailableField(PD)).ToList

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        TextBoxForm_DefaultDirectory.Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Reports"
                        TextBoxForm_DefaultDirectory.Enabled = False

                    End If

                Else

                    Me.Text = "Update Export Template"
                    Me.ButtonForm_Add.Visible = False
                    Me.ButtonForm_Update.Visible = True

                    ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, _ExportTemplateID)

                    If ExportTemplate IsNot Nothing Then

                        TextBoxForm_Name.Text = ExportTemplate.Name

                        If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                            TextBoxForm_DefaultDirectory.Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Reports"
                            TextBoxForm_DefaultDirectory.Enabled = False

                        Else

                            TextBoxForm_DefaultDirectory.Text = ExportTemplate.DefaultDirectory

                        End If

                        If ExportTemplate.FileType = AdvantageFramework.Exporting.FileTypes.CSV Then

                            RadioButtonForm_CSV.Checked = True

                        Else

                            RadioButtonForm_Fixed.Checked = True

                        End If

                        CheckBoxForm_IncludeColumnHeaders.Checked = ExportTemplate.IncludeColumnHeaders

                        _ExportFields = New Generic.List(Of AdvantageFramework.Exporting.Classes.ExportField)

                        For Each ExportTemplateDetail In ExportTemplate.ExportTemplateDetails.OrderBy(Function(Entity) Entity.Position).ToList

                            Try

                                PropertyDescriptor = PropertyDescriptors.SingleOrDefault(Function(PD) PD.Name = ExportTemplateDetail.FieldName)

                            Catch ex As Exception
                                PropertyDescriptor = Nothing
                            End Try

                            _ExportFields.Add(New AdvantageFramework.Exporting.Classes.ExportField(ExportTemplateDetail, PropertyDescriptor))

                        Next

                        _AvailableFields = New Generic.List(Of AdvantageFramework.Exporting.Classes.AvailableField)

                        For Each PropertyDescriptor In PropertyDescriptors

                            If _ExportFields.Any(Function(EF) EF.FieldName = PropertyDescriptor.Name) = False Then

                                _AvailableFields.Add(New AdvantageFramework.Exporting.Classes.AvailableField(PropertyDescriptor))

                            End If

                        Next

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The export template you are trying to edit does not exist anymore.")
                        Me.Close()

                    End If

                End If

            End Using

        End Sub
        Private Sub ExportTemplateEditDialog_Shown(sender As Object, e As EventArgs) Handles Me.Shown

            If Me.IsFormClosing = False Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                Me.ShowWaitForm()

                Try

                    LoadGrids(RadioButtonForm_Fixed.Checked)

                    TextBoxForm_Name.Focus()

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
            Dim ExportTemplateDetailIDs As Generic.List(Of Integer) = Nothing
            Dim Updated As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If Me.Validator Then

                If DataGridViewRightSection_TemplateDetails.HasRows Then

                    DataGridViewRightSection_TemplateDetails.ValidateAllRows()

                    If DataGridViewRightSection_TemplateDetails.HasAnyInvalidRows = False Then

                        RefreshExportFieldsPositions()

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            Try

                                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, _ExportTemplateID)

                                ExportTemplate.DbContext = DbContext
                                ExportTemplate.Name = TextBoxForm_Name.Text
                                ExportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                                ExportTemplate.Type = _ExportType
                                ExportTemplate.IncludeColumnHeaders = CheckBoxForm_IncludeColumnHeaders.Checked

                                If RadioButtonForm_CSV.Checked Then

                                    ExportTemplate.FileType = AdvantageFramework.Exporting.FileTypes.CSV
                                    ExportTemplate.Delimiter = ","

                                Else

                                    ExportTemplate.FileType = AdvantageFramework.Exporting.FileTypes.Fixed
                                    ExportTemplate.Delimiter = Nothing

                                End If

                                If AdvantageFramework.Database.Procedures.ExportTemplate.Update(DbContext, ExportTemplate) Then

                                    ExportTemplateDetailIDs = New Generic.List(Of Integer)

                                    Updated = True

                                    For Each ExportField In _ExportFields

                                        ExportTemplateDetail = ExportField.GetEntity

                                        ExportTemplateDetail.ExportTemplateID = ExportTemplate.ID

                                        If ExportTemplateDetail.IsEntityBeingAdded() Then

                                            If AdvantageFramework.Database.Procedures.ExportTemplateDetail.Insert(DbContext, ExportTemplateDetail) Then

                                                ExportTemplateDetailIDs.Add(ExportTemplateDetail.ID)

                                            Else

                                                Updated = False
                                                Exit For

                                            End If

                                        Else

                                            If AdvantageFramework.Database.Procedures.ExportTemplateDetail.Update(DbContext, ExportTemplateDetail) Then

                                                ExportTemplateDetailIDs.Add(ExportTemplateDetail.ID)

                                            Else

                                                Updated = False
                                                Exit For

                                            End If

                                        End If

                                    Next

                                    If Updated Then

                                        For Each ExportTemplateDetail In AdvantageFramework.Database.Procedures.ExportTemplateDetail.LoadByExportTemplateID(DbContext, _ExportTemplateID).Where(Function(Entity) ExportTemplateDetailIDs.Contains(Entity.ID) = False).ToList

                                            DbContext.DeleteEntityObject(ExportTemplateDetail)

                                        Next

                                        Try

                                            DbContext.SaveChanges()

                                        Catch ex As Exception
                                            Updated = False
                                        End Try

                                    End If

                                End If

                            Catch ex As Exception
                                Updated = False
                            End Try

                            If Updated Then

                                DbTransaction.Commit()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            Else

                                DbTransaction.Rollback()
                                AdvantageFramework.WinForm.MessageBox.Show("Failed saving template. Please contact Software Support.")

                            End If

                            DbContext.Database.Connection.Close()

                        End Using

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix template detail errors.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please inlcude at least one field in the template.")

                End If

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing
            Dim ExportTemplateDetail As AdvantageFramework.Database.Entities.ExportTemplateDetail = Nothing
            Dim Added As Boolean = False
            Dim DbTransaction As System.Data.Entity.DbContextTransaction = Nothing

            If Me.Validator Then

                If DataGridViewRightSection_TemplateDetails.HasRows Then

                    DataGridViewRightSection_TemplateDetails.ValidateAllRows()

                    If DataGridViewRightSection_TemplateDetails.HasAnyInvalidRows = False Then

                        RefreshExportFieldsPositions()

                        Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            DbContext.Database.Connection.Open()

                            DbTransaction = DbContext.Database.BeginTransaction

                            Try

                                ExportTemplate = New AdvantageFramework.Database.Entities.ExportTemplate

                                ExportTemplate.DbContext = DbContext
                                ExportTemplate.Name = TextBoxForm_Name.Text
                                ExportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                                ExportTemplate.Type = _ExportType
                                ExportTemplate.IncludeColumnHeaders = CheckBoxForm_IncludeColumnHeaders.Checked

                                If RadioButtonForm_CSV.Checked Then

                                    ExportTemplate.FileType = AdvantageFramework.Exporting.FileTypes.CSV
                                    ExportTemplate.Delimiter = ","

                                Else

                                    ExportTemplate.FileType = AdvantageFramework.Exporting.FileTypes.Fixed
                                    ExportTemplate.Delimiter = Nothing

                                End If

                                If AdvantageFramework.Database.Procedures.ExportTemplate.Insert(DbContext, ExportTemplate) Then

                                    Added = True

                                    For Each ExportField In _ExportFields

                                        ExportTemplateDetail = ExportField.GetEntity

                                        ExportTemplateDetail.ExportTemplateID = ExportTemplate.ID

                                        If AdvantageFramework.Database.Procedures.ExportTemplateDetail.Insert(DbContext, ExportTemplateDetail) = False Then

                                            Added = False
                                            Exit For

                                        End If

                                    Next

                                End If

                            Catch ex As Exception
                                Added = False
                            End Try

                            If Added Then

                                DbTransaction.Commit()

                                Me.DialogResult = Windows.Forms.DialogResult.OK
                                Me.Close()

                            Else

                                DbTransaction.Rollback()
                                AdvantageFramework.WinForm.MessageBox.Show("Failed saving template. Please contact Software Support.")

                            End If

                            DbContext.Database.Connection.Close()

                        End Using

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please fix template detail errors.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please inlcude at least one field in the template.")

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
        Private Sub DataGridViewLeftSection_AvailableTemplateDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewLeftSection_AvailableTemplateDetails.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_TemplateDetails_SelectionChangedEvent(sender As Object, e As EventArgs) Handles DataGridViewRightSection_TemplateDetails.SelectionChangedEvent

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                EnableOrDisableActions()

            End If

        End Sub
        Private Sub DataGridViewRightSection_TemplateDetails_ValidateRowEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs) Handles DataGridViewRightSection_TemplateDetails.ValidateRowEvent

            'objects
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing
            Dim ErrorTexts As Generic.List(Of String) = Nothing

            If RadioButtonForm_Fixed.Checked Then

                Try

                    ExportField = e.Row

                Catch ex As Exception
                    ExportField = Nothing
                End Try

                If ExportField IsNot Nothing Then

                    ErrorTexts = New Generic.List(Of String)

                    If ExportField.Start.HasValue AndAlso ExportField.Length.HasValue Then

                        For Each EF In _ExportFields.Where(Function(Entity) Entity.FieldName <> ExportField.FieldName).ToList

                            If EF.Start.HasValue AndAlso EF.Length.HasValue Then

                                If ExportField.Start >= EF.Start AndAlso ExportField.Start <= EF.End Then

                                    ErrorTexts.Add(EF.FieldName & " is overlapping.")

                                ElseIf ExportField.End >= EF.Start AndAlso ExportField.End <= EF.End Then

                                    ErrorTexts.Add(EF.FieldName & " is overlapping.")

                                End If

                            End If

                        Next

                    Else

                        If ExportField.Start.HasValue = False Then

                            ExportField.SetPropertyError(Exporting.Classes.ExportField.Properties.Start.ToString, Exporting.Classes.ExportField.Properties.Start.ToString & " is required.")

                        End If

                        If ExportField.Length.HasValue = False Then

                            ExportField.SetPropertyError(Exporting.Classes.ExportField.Properties.Length.ToString, Exporting.Classes.ExportField.Properties.Length.ToString & " is required.")

                        End If

                    End If

                    ExportField.EntityError = ExportField.LoadEntityError()

                    If ErrorTexts.Any Then

                        ExportField.EntityError = IIf(ExportField.EntityError = "", Join(ErrorTexts.ToArray, Environment.NewLine), ExportField.EntityError & Environment.NewLine & Join(ErrorTexts.ToArray, Environment.NewLine))

                    End If

                    e.ErrorText = ExportField.EntityError

                Else

                    e.ErrorText = ""

                End If

                e.Valid = True

            End If

        End Sub
        Private Sub DataGridViewRightSection_TemplateDetails_ValidatingEditorEvent(sender As Object, e As DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs) Handles DataGridViewRightSection_TemplateDetails.ValidatingEditorEvent

            'objects
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing

            If RadioButtonForm_Fixed.Checked Then

                Try

                    ExportField = DataGridViewRightSection_TemplateDetails.CurrentView.GetFocusedRow

                Catch ex As Exception
                    ExportField = Nothing
                End Try

                If ExportField IsNot Nothing Then

                    If DataGridViewRightSection_TemplateDetails.CurrentView.FocusedColumn.FieldName = Exporting.Classes.ExportField.Properties.Start.ToString OrElse _
                            DataGridViewRightSection_TemplateDetails.CurrentView.FocusedColumn.FieldName = Exporting.Classes.ExportField.Properties.Length.ToString Then

                        If IsNothing(e.Value) Then

                            e.ErrorText = DataGridViewRightSection_TemplateDetails.CurrentView.FocusedColumn.FieldName & " is required."

                        End If

                        ExportField.SetPropertyError(DataGridViewRightSection_TemplateDetails.CurrentView.FocusedColumn.FieldName, e.ErrorText)

                        e.Valid = True

                    End If

                End If

            End If

        End Sub
        Private Sub ButtonRightSection_AddTemplateDetail_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_AddTemplateDetail.Click

            'objects
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing
            Dim LastEnd As Integer = 0

            If DataGridViewLeftSection_AvailableTemplateDetails.HasASelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Adding...")

                Try

                    If RadioButtonForm_Fixed.Checked AndAlso _ExportFields.Count > 0 Then

                        LastEnd = _ExportFields.Select(Function(EF) EF.End).Max

                    End If

                    For Each AvailableField In DataGridViewLeftSection_AvailableTemplateDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Exporting.Classes.AvailableField).ToList

                        ExportField = New AdvantageFramework.Exporting.Classes.ExportField(AvailableField)

                        _ExportFields.Add(ExportField)

                        ExportField.Position = _ExportFields.IndexOf(ExportField)

                        If RadioButtonForm_Fixed.Checked Then

                            ExportField.Start = LastEnd + 1

                        End If

                        _AvailableFields.Remove(AvailableField)

                    Next

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm("Loading...")

                    RefreshExportFieldsPositions()

                    LoadGrids(RadioButtonForm_Fixed.Checked)

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_RemoveTemplateDetail_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_RemoveTemplateDetail.Click

            If DataGridViewRightSection_TemplateDetails.HasASelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Removing...")

                Try

                    For Each ExportField In DataGridViewRightSection_TemplateDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Exporting.Classes.ExportField).ToList

                        _AvailableFields.Add(New AdvantageFramework.Exporting.Classes.AvailableField(ExportField.FieldName, ExportField.PreDefinedLength))

                        _ExportFields.Remove(ExportField)

                    Next

                    For Each ExportField In _ExportFields

                        ExportField.Position = _ExportFields.IndexOf(ExportField)

                    Next

                    Me.FormAction = WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm("Loading...")

                    RefreshExportFieldsPositions()

                    LoadGrids(RadioButtonForm_Fixed.Checked)

                    EnableOrDisableActions()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_MoveUp_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_MoveUp.Click

            'objects
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing

            If DataGridViewRightSection_TemplateDetails.HasOnlyOneSelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Moving up...")

                Try

                    Try

                        ExportField = DataGridViewRightSection_TemplateDetails.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ExportField = Nothing
                    End Try

                    If ExportField IsNot Nothing Then

                        If ExportField.Position > 0 Then

                            _ExportFields.Remove(ExportField)

                            ExportField.Position -= 1

                            _ExportFields.Insert(ExportField.Position, ExportField)

                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm("Loading...")

                            LoadGrids(RadioButtonForm_Fixed.Checked)

                            RefreshExportFieldsPositions()

                            EnableOrDisableActions()

                        End If

                    End If

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_MoveDown_Click(sender As Object, e As EventArgs) Handles ButtonRightSection_MoveDown.Click

            'objects
            Dim ExportField As AdvantageFramework.Exporting.Classes.ExportField = Nothing

            If DataGridViewRightSection_TemplateDetails.HasOnlyOneSelectedRow Then

                Me.FormAction = WinForm.Presentation.FormActions.Modifying
                Me.ShowWaitForm()
                Me.ShowWaitForm("Moving down...")

                Try

                    Try

                        ExportField = DataGridViewRightSection_TemplateDetails.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        ExportField = Nothing
                    End Try

                    If ExportField IsNot Nothing Then

                        If ExportField.Position < _ExportFields.Count - 1 Then

                            _ExportFields.Remove(ExportField)

                            ExportField.Position += 1

                            _ExportFields.Insert(ExportField.Position, ExportField)

                            Me.FormAction = WinForm.Presentation.FormActions.Loading
                            Me.ShowWaitForm("Loading...")

                            LoadGrids(RadioButtonForm_Fixed.Checked)

                            RefreshExportFieldsPositions()

                            EnableOrDisableActions()

                        End If

                    End If

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub RadioButtonForm_Fixed_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_Fixed.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If RadioButtonForm_Fixed.Checked Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        For Each ExportField In _ExportFields

                            ExportField.Start = Nothing
                            ExportField.Length = Nothing

                        Next

                        LoadGrids(RadioButtonForm_Fixed.Checked)

                        RefreshExportFieldsPositions()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Private Sub RadioButtonForm_CSV_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButtonForm_CSV.CheckedChanged

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

                If RadioButtonForm_CSV.Checked Then

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Loading
                    Me.ShowWaitForm()

                    Try

                        For Each ExportField In _ExportFields

                            ExportField.Start = Nothing
                            ExportField.Length = Nothing

                        Next

                        LoadGrids(RadioButtonForm_Fixed.Checked)

                        RefreshExportFieldsPositions()

                        EnableOrDisableActions()

                    Catch ex As Exception

                    End Try

                    Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None
                    Me.CloseWaitForm()

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace