Namespace WinForm.Presentation.Controls

    Public Class JobSpecificationTemplateControl

        Public Event CategoriesChangedEvent()
        Public Event SelectedCategoryChangedEvent()
        Public Event SelectedFieldChangedEvent()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _JobSpecificationTypeCode As String = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _IsControlClearing As Boolean = False
        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing

#End Region

#Region " Properties "

        Public ReadOnly Property JobSpecificationTypeCode As String
            Get
                JobSpecificationTypeCode = _JobSpecificationTypeCode
            End Get
        End Property
        Public ReadOnly Property CanDeleteCategory As Boolean
            Get
                CanDeleteCategory = CanDeleteSelectedCategory()
            End Get
        End Property
        Public ReadOnly Property SelectedJobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory
            Get

                If TabControlRightSection_Categories.SelectedTab IsNot Nothing Then

                    Try

                        SelectedJobSpecificationCategory = DirectCast(TabControlRightSection_Categories.SelectedTab.Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                    Catch ex As Exception
                        SelectedJobSpecificationCategory = Nothing
                    End Try

                Else

                    SelectedJobSpecificationCategory = Nothing

                End If

            End Get
        End Property
        Public ReadOnly Property SelectedCategoryDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get

                If TabControlRightSection_Categories.SelectedTab IsNot Nothing Then

                    If TabControlRightSection_Categories.SelectedTab.AttachedControl IsNot Nothing Then

                        Try

                            SelectedCategoryDataGridView = TabControlRightSection_Categories.SelectedTab.AttachedControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.DataGridView).FirstOrDefault

                        Catch ex As Exception
                            SelectedCategoryDataGridView = Nothing
                        End Try

                    Else

                        SelectedCategoryDataGridView = Nothing

                    End If

                Else

                    SelectedCategoryDataGridView = Nothing

                End If

            End Get
        End Property
        Public ReadOnly Property CanMoveItemUp As Boolean
            Get
                Try

                    CanMoveItemUp = If(Me.SelectedCategoryDataGridView.Enabled AndAlso Me.SelectedCategoryDataGridView.HasOnlyOneSelectedRow, Not Me.SelectedCategoryDataGridView.CurrentView.IsFirstRow, False)

                Catch ex As Exception
                    CanMoveItemUp = False
                End Try
            End Get
        End Property
        Public ReadOnly Property CanMoveItemDown As Boolean
            Get
                Try

                    CanMoveItemDown = If(Me.SelectedCategoryDataGridView.Enabled AndAlso Me.SelectedCategoryDataGridView.HasOnlyOneSelectedRow, Not Me.SelectedCategoryDataGridView.CurrentView.IsLastRow, False)

                Catch ex As Exception
                    CanMoveItemDown = False
                End Try
            End Get
        End Property
        Public ReadOnly Property CanMoveToNewCategory As Boolean
            Get
                CanMoveToNewCategory = If(Me.SelectedCategoryDataGridView.Enabled AndAlso Me.SelectedCategoryDataGridView.HasOnlyOneSelectedRow AndAlso TabControlRightSection_Categories.Tabs.Count > 1, True, False)
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

                            TextBoxTopSection_Code.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.Code)
                            TextBoxTopSection_Description.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.Description)
                            ComboBoxTopSection_UseVendorTab.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.UseVendorTab)

                            ComboBoxTopSection_UseVendorTab.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationVendorTab.Load(DbContext).ToList

                            DataGridViewLeftSection_AvailableJobSpecificationFields.ItemDescription = "Available Field(s)"

                            _RepositoryItemCheckEdit_Blank = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            _RepositoryItemCheckEdit_Blank.DisplayValueChecked = ""
                            _RepositoryItemCheckEdit_Blank.DisplayValueUnchecked = ""
                            _RepositoryItemCheckEdit_Blank.DisplayValueGrayed = ""
                            _RepositoryItemCheckEdit_Blank.ExportMode = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureChecked = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureGrayed = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureUnchecked = Nothing
                            _RepositoryItemCheckEdit_Blank.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
                            _RepositoryItemCheckEdit_Blank.ValueUnchecked = CShort(0)
                            _RepositoryItemCheckEdit_Blank.ValueChecked = CShort(1)
                            _RepositoryItemCheckEdit_Blank.ValueGrayed = Nothing

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.JobSpecificationType

            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing

            If IsNew Then

                JobSpecificationType = New AdvantageFramework.Database.Entities.JobSpecificationType

                LoadJobSpecificationTypeEntity(JobSpecificationType)

            Else

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobSpecificationType = AdvantageFramework.Database.Procedures.JobSpecificationType.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode)

                    If JobSpecificationType IsNot Nothing Then

                        LoadJobSpecificationTypeEntity(JobSpecificationType)

                    End If

                End Using

            End If

            FillObject = JobSpecificationType

        End Function
        Private Sub LoadJobSpecificationCategories()

            'objects
            Dim JobSpecificationCategories As Generic.List(Of AdvantageFramework.Database.Entities.JobSpecificationCategory) = Nothing
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing

            If _JobSpecificationTypeCode IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobSpecificationCategories = (From Entity In AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode).ToList
                                                  Select Entity
                                                  Order By Entity.SequenceNumber).ToList

                    For Each JobSpecificationCategory In JobSpecificationCategories

                        CreateCategoryTab(JobSpecificationCategory)

                    Next

                End Using

                TabControlRightSection_Categories.RecalcLayout()

            End If

        End Sub
        Private Sub CreateCategoryTab(ByVal JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory)

            'objects
            Dim TabItem As DevComponents.DotNetBar.TabItem = Nothing
            Dim TabControlPanel As DevComponents.DotNetBar.TabControlPanel = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            If JobSpecificationCategory IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Try

                        TabItem = TabControlRightSection_Categories.CreateTab(JobSpecificationCategory.Description)
                        TabItem.Tag = JobSpecificationCategory

                        TabControlPanel = TabItem.AttachedControl

                        DataGridView = New AdvantageFramework.WinForm.Presentation.Controls.DataGridView

                        DataGridView.ControlType = Presentation.Controls.DataGridView.Type.EditableGrid
                        DataGridView.CurrentView.Session = _Session
                        DataGridView.Location = New System.Drawing.Point(4, 4)
                        DataGridView.Size = New System.Drawing.Size(TabControlPanel.Size.Width - 8, TabControlPanel.Size.Height - 8)
                        DataGridView.Name = "DataGridViewCategory_" & JobSpecificationCategory.ID.ToString

                        DataGridView.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                                                       Or System.Windows.Forms.AnchorStyles.Left) _
                                                       Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)

                        LoadJobSpecificationFieldsByCategory(DataGridView, JobSpecificationCategory.ID)

                        DataGridView.OptionsCustomization.AllowFilter = False
                        DataGridView.OptionsCustomization.AllowSort = False
                        DataGridView.OptionsCustomization.AllowQuickHideColumns = False
                        DataGridView.OptionsMenu.EnableColumnMenu = False
                        DataGridView.OptionsMenu.EnableFooterMenu = False
                        DataGridView.OptionsMenu.EnableGroupPanelMenu = False

                        DataGridView.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_Blank)

                        AddHandler DataGridView.ShowingEditorEvent, AddressOf DataGridView_ShowingEditorEvent
                        AddHandler DataGridView.CustomRowCellEditEvent, AddressOf DataGridView_CustomRowCellEditEvent
                        AddHandler DataGridView.SelectionChangedEvent, AddressOf DataGridView_SelectionChangedEvent

                        TabControlPanel.Controls.Add(DataGridView)

                    Catch ex As Exception

                    End Try

                End Using

            End If

        End Sub
        Private Sub LoadJobSpecificationFieldsByCategory(ByVal DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView, ByVal JobSpecificationCategoryID As Integer)

            'objects
            Dim JobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Classes.JobSpecificationField) = Nothing
            Dim CurrentJobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Classes.JobSpecificationField) = Nothing
            Dim DefaultJobSpecFields As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim JobSpecField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim FieldDataType As String = Nothing

            If DataGridView IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobSpecificationFields = New Generic.List(Of AdvantageFramework.Database.Classes.JobSpecificationField)

                    DefaultJobSpecFields = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.JobSpecFields)).ToList

                    Try

                        CurrentJobSpecificationFields = DataGridView.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobSpecificationField)().ToList

                    Catch ex As Exception

                    End Try

                    For Each JobSpecificationField In AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByJobSpecificationCategoryID(DbContext, JobSpecificationCategoryID).OrderBy(Function(JobSpecFld) JobSpecFld.SequenceNumber).ToList

                        JobSpecField = Nothing

                        If CurrentJobSpecificationFields IsNot Nothing AndAlso CurrentJobSpecificationFields.Count > 0 Then

                            Try

                                JobSpecField = (From Entity In CurrentJobSpecificationFields
                                                Where Entity.Name = JobSpecificationField.Name
                                                Select Entity).SingleOrDefault

                            Catch ex As Exception
                                JobSpecField = Nothing
                            End Try

                        End If

                        If JobSpecField Is Nothing Then

                            Try

                                FieldDataType = (From Entity In DefaultJobSpecFields
                                                 Where Entity.Code = JobSpecificationField.Name
                                                 Select Entity.Description).SingleOrDefault

                            Catch ex As Exception
                                FieldDataType = ""
                            End Try

                            JobSpecField = New AdvantageFramework.Database.Classes.JobSpecificationField(JobSpecificationField, FieldDataType)

                        End If

                        JobSpecificationFields.Add(JobSpecField)

                    Next

                    DataGridView.DataSource = JobSpecificationFields
                    DataGridView.CurrentView.BestFitColumns()

                End Using

            End If

        End Sub
        Private Sub LoadDefaultJobSpecificationFields()

            'objects
            Dim JobSpecFields As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing
            Dim JobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Entities.JobSpecificationField) = Nothing
            Dim AvailableJobSpecFields As Generic.List(Of AdvantageFramework.EnumUtilities.Attributes.EnumObjectAttribute) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobSpecFields = AdvantageFramework.EnumUtilities.LoadEnumObjects(GetType(AdvantageFramework.Database.Entities.JobSpecFields))

                If _JobSpecificationTypeCode IsNot Nothing Then

                    JobSpecificationFields = AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode).ToList

                    Try

                        AvailableJobSpecFields = (From Entity In JobSpecFields
                                                  Where JobSpecificationFields.Any(Function(JobSpecificationField) JobSpecificationField.Name = Entity.Code) = False
                                                  Select Entity).ToList

                    Catch ex As Exception
                        AvailableJobSpecFields = Nothing
                    End Try

                End If

                Try

                    DataGridViewLeftSection_AvailableJobSpecificationFields.DataSource = (From Entity In AvailableJobSpecFields
                                                                                          Select [FieldName] = Entity.Code,
                                                                                                 [FieldTypeDesc] = Entity.Description
                                                                                          Order By FieldName).ToList

                    DataGridViewLeftSection_AvailableJobSpecificationFields.CurrentView.BestFitColumns()

                Catch ex As Exception

                End Try

            End Using

        End Sub
        Private Sub LoadJobSpecificationTypeEntity(ByVal JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType)

            If JobSpecificationType IsNot Nothing Then

                JobSpecificationType.Code = TextBoxTopSection_Code.Text
                JobSpecificationType.Description = TextBoxTopSection_Description.Text
                JobSpecificationType.IsInactive = Convert.ToInt16(CheckBoxTopSection_Inactive.Checked)
                JobSpecificationType.UseQuantitiesTab = Convert.ToInt16(CheckBoxTopSection_UseQuantitiesTab.Checked)
                JobSpecificationType.UseVendorTab = ComboBoxTopSection_UseVendorTab.GetSelectedValue

            End If

        End Sub
        Private Sub EnableOrDisableActions()

            'objects
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing

            Try

                TabControlRightSection_Categories.Visible = TabControlRightSection_Categories.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).Any(Function(TabItem) TabItem.Visible)

            Catch ex As Exception
                TabControlRightSection_Categories.Visible = False
            End Try

            For Each TabItem In TabControlRightSection_Categories.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).ToList

                Try

                    JobSpecificationCategory = DirectCast(TabItem.Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                Catch ex As Exception
                    JobSpecificationCategory = Nothing
                End Try

                If JobSpecificationCategory IsNot Nothing Then

                    If Convert.ToBoolean(JobSpecificationCategory.IsInactive) Then

                        TabItem.AttachedControl.Enabled = False

                    Else

                        TabItem.AttachedControl.Enabled = True

                    End If

                End If

            Next

            ButtonRightSection_AddCategory.Visible = Not TabControlRightSection_Categories.Visible
            TabItemCategories_TemplateTab.Visible = False
            ButtonLeftSection_Delete.Enabled = If(Me.SelectedCategoryDataGridView IsNot Nothing, Me.SelectedCategoryDataGridView.HasASelectedRow, False)
            ButtonLeftSection_AddSelected.Enabled = If(TabControlRightSection_Categories.Visible, DataGridViewLeftSection_AvailableJobSpecificationFields.HasASelectedRow, False)

        End Sub
        Private Function CanDeleteSelectedCategory() As Boolean

            'objects
            Dim CanDelete As Boolean = False
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            Try

                If TabControlRightSection_Categories.SelectedTab IsNot Nothing Then

                    If TypeOf TabControlRightSection_Categories.SelectedTab.AttachedControl Is DevComponents.DotNetBar.TabControlPanel Then

                        Try

                            DataGridView = TabControlRightSection_Categories.SelectedTab.AttachedControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.DataGridView).SingleOrDefault

                        Catch ex As Exception
                            DataGridView = Nothing
                        End Try

                        If DataGridView IsNot Nothing Then

                            CanDelete = Not DataGridView.HasRows

                        End If

                    End If

                End If

            Catch ex As Exception
                CanDelete = False
            Finally
                CanDeleteSelectedCategory = CanDelete
            End Try

        End Function
        Private Sub DataGridView_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs)

            'objects
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing
            Dim Cancel As Boolean = False

            Try

                DataGridView = Me.SelectedCategoryDataGridView

            Catch ex As Exception
                DataGridView = Nothing
            End Try

            If DataGridView IsNot Nothing Then

                Try

                    JobSpecificationField = DataGridView.CurrentView.GetRow(DataGridView.CurrentView.FocusedRowHandle)

                Catch ex As Exception
                    JobSpecificationField = Nothing
                End Try

                If JobSpecificationField IsNot Nothing Then

                    If DataGridView.CurrentView.FocusedColumn.FieldName = AdvantageFramework.Database.Classes.JobSpecificationField.Properties.IsInactive.ToString Then

                        Cancel = False

                    Else

                        Cancel = Convert.ToBoolean(JobSpecificationField.IsInactive)

                    End If

                Else

                    Cancel = True

                End If

            Else

                Cancel = True

            End If

            e.Cancel = Cancel

        End Sub
        Private Sub DataGridView_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs)

            'objects
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing

            Try

                DataGridView = Me.SelectedCategoryDataGridView

            Catch ex As Exception
                DataGridView = Nothing
            End Try

            If DataGridView IsNot Nothing Then

                Try

                    JobSpecificationField = DataGridView.CurrentView.GetRow(e.RowHandle)

                Catch ex As Exception
                    JobSpecificationField = Nothing
                End Try

                If JobSpecificationField IsNot Nothing Then

                    If e.Column.FieldName = AdvantageFramework.Database.Classes.JobSpecificationField.Properties.SeparatorLine.ToString OrElse
                        e.Column.FieldName = AdvantageFramework.Database.Classes.JobSpecificationField.Properties.IsRequired.ToString Then

                        If Convert.ToBoolean(JobSpecificationField.IsInactive) Then

                            e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                        Else

                            Try

                                e.RepositoryItem = Nothing

                            Catch ex As Exception

                            End Try

                        End If

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridView_SelectionChangedEvent(sender As Object, e As EventArgs)

            RaiseEvent SelectedFieldChangedEvent()

        End Sub
        Private Sub MoveJobSpecificationField(ByVal JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField, ByVal MoveUp As Boolean)

            'objects
            Dim JobSpecificationFieldAboveOrBelow As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing
            Dim AllJobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Classes.JobSpecificationField) = Nothing

            If JobSpecificationField IsNot Nothing Then

                AllJobSpecificationFields = Me.SelectedCategoryDataGridView.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobSpecificationField).ToList

                If MoveUp Then

                    Try

                        JobSpecificationFieldAboveOrBelow = (From Entity In AllJobSpecificationFields
                                                             Where Entity.SequenceNumber < JobSpecificationField.SequenceNumber
                                                             Order By Entity.SequenceNumber Descending
                                                             Select Entity).FirstOrDefault

                    Catch ex As Exception
                        JobSpecificationFieldAboveOrBelow = Nothing
                    End Try

                    If JobSpecificationFieldAboveOrBelow IsNot Nothing Then

                        JobSpecificationFieldAboveOrBelow.SequenceNumber = JobSpecificationFieldAboveOrBelow.SequenceNumber + 1
                        JobSpecificationField.SequenceNumber = JobSpecificationField.SequenceNumber - 1

                    End If

                Else

                    Try

                        JobSpecificationFieldAboveOrBelow = (From Entity In AllJobSpecificationFields
                                                             Where Entity.SequenceNumber > JobSpecificationField.SequenceNumber
                                                             Order By Entity.SequenceNumber Ascending
                                                             Select Entity).FirstOrDefault

                    Catch ex As Exception
                        JobSpecificationFieldAboveOrBelow = Nothing
                    End Try

                    If JobSpecificationFieldAboveOrBelow IsNot Nothing Then

                        JobSpecificationFieldAboveOrBelow.SequenceNumber = JobSpecificationFieldAboveOrBelow.SequenceNumber - 1
                        JobSpecificationField.SequenceNumber = JobSpecificationField.SequenceNumber + 1

                    End If

                End If

                Me.SelectedCategoryDataGridView.DataSource = AllJobSpecificationFields.OrderBy(Function(Entity) Entity.SequenceNumber)
                Me.SelectedCategoryDataGridView.CurrentView.BestFitColumns()

                Me.SelectedCategoryDataGridView.SetUserEntryChanged()

            End If

        End Sub
        Private Function SaveJobSpecField(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobSpecField As AdvantageFramework.Database.Classes.JobSpecificationField) As Boolean

            'objects
            Dim JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim Saved As Boolean = False

            Try

                JobSpecificationField = AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByFieldNameAndJobSpecificationTypeCode(DbContext, JobSpecField.Name, JobSpecField.JobSpecificationTypeCode)

                If JobSpecificationField IsNot Nothing AndAlso JobSpecField.HasError = False Then

                    JobSpecificationField.Description = JobSpecField.Description
                    JobSpecificationField.IsInactive = JobSpecField.IsInactive
                    JobSpecificationField.IsRequired = JobSpecField.IsRequired
                    JobSpecificationField.SeparatorLine = JobSpecField.SeparatorLine
                    JobSpecificationField.SequenceNumber = JobSpecField.SequenceNumber
                    JobSpecificationField.JobSpecificationCategoryID = JobSpecField.JobSpecificationCategoryID

                    Saved = AdvantageFramework.Database.Procedures.JobSpecificationField.Update(DbContext, JobSpecificationField)

                End If

            Catch ex As Exception
                Saved = False
            Finally
                SaveJobSpecField = Saved
            End Try

        End Function

#Region "  Public "

        Public Function LoadControl(ByVal JobSpecificationTypeCode As String, Optional ByVal IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing

            _JobSpecificationTypeCode = JobSpecificationTypeCode
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobSpecificationTypeCode <> "" Then

                    JobSpecificationType = AdvantageFramework.Database.Procedures.JobSpecificationType.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode)

                    If JobSpecificationType IsNot Nothing Then

                        If _IsCopy = False Then

                            TextBoxTopSection_Code.Text = JobSpecificationType.Code
                            TextBoxTopSection_Description.Text = JobSpecificationType.Description

                        End If

                        TextBoxTopSection_Code.Enabled = _IsCopy
                        TextBoxTopSection_Code.ReadOnly = Not _IsCopy

                        CheckBoxTopSection_Inactive.Checked = Convert.ToBoolean(JobSpecificationType.IsInactive)
                        CheckBoxTopSection_UseQuantitiesTab.Checked = Convert.ToBoolean(JobSpecificationType.UseQuantitiesTab)

                        If JobSpecificationType.UseVendorTab IsNot Nothing Then

                            ComboBoxTopSection_UseVendorTab.SelectedValue = JobSpecificationType.UseVendorTab

                        End If

                        LoadJobSpecificationCategories()

                    Else

                        Loaded = False

                    End If

                Else

                    TextBoxTopSection_Code.Enabled = True
                    TextBoxTopSection_Code.ReadOnly = False

                End If

            End Using

            LoadDefaultJobSpecificationFields()

            EnableOrDisableActions()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            TextBoxTopSection_Code.Text = Nothing
            TextBoxTopSection_Description.Text = Nothing
            CheckBoxTopSection_Inactive.Checked = False
            DataGridViewLeftSection_AvailableJobSpecificationFields.DataSource = Nothing
            TabControlRightSection_Categories.Tabs.Clear()
            TabControlRightSection_Categories.RecalcLayout()
            DataGridViewTemplate_TemplateGrid.DataSource = Nothing
            ComboBoxTopSection_UseVendorTab.SelectedValue = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub DeletedSelectedCategory()

            'objects
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim JobSpecificationCategories As Generic.List(Of AdvantageFramework.Database.Entities.JobSpecificationCategory) = Nothing

            If TabControlRightSection_Categories.SelectedTab IsNot Nothing AndAlso Me.CanDeleteCategory Then

                If AdvantageFramework.Navigation.ShowMessageBox("Deleting categories requires changes to be immediately saved and discarding edits will not be allowed. Are you sure you wish to continue?", MessageBox.MessageBoxButtons.YesNo) = MessageBox.DialogResults.Yes Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Try

                            JobSpecificationCategory = DirectCast(TabControlRightSection_Categories.SelectedTab.Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                        Catch ex As Exception
                            JobSpecificationCategory = Nothing
                        End Try

                        If JobSpecificationCategory IsNot Nothing Then

                            JobSpecificationCategories = (From Entity In AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode).ToList
                                                          Where Entity.SequenceNumber > JobSpecificationCategory.SequenceNumber
                                                          Select Entity).ToList

                            If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Delete(DbContext, JobSpecificationCategory) Then

                                For Each JobSpecCategory In JobSpecificationCategories

                                    JobSpecCategory.SequenceNumber = JobSpecCategory.SequenceNumber - 1

                                    AdvantageFramework.Database.Procedures.JobSpecificationCategory.Update(DbContext, JobSpecCategory)

                                Next

                                TabControlRightSection_Categories.Tabs.Clear()

                                LoadJobSpecificationCategories()

                                EnableOrDisableActions()

                                RaiseEvent CategoriesChangedEvent()

                            End If

                        End If

                    End Using

                End If

            End If

        End Sub
        Public Sub RenameCategory()

            'objects
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim NewName As String = ""

            If TabControlRightSection_Categories.SelectedTab IsNot Nothing Then

                Try

                    JobSpecificationCategory = DirectCast(TabControlRightSection_Categories.SelectedTab.Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                Catch ex As Exception
                    JobSpecificationCategory = Nothing
                End Try

                If JobSpecificationCategory IsNot Nothing Then

                    If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Rename Category", "Enter Name of Category:", JobSpecificationCategory.Description, NewName, AdvantageFramework.Database.Entities.JobSpecificationCategory.Properties.Description) = Windows.Forms.DialogResult.OK Then

                        If NewName <> "" Then

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                JobSpecificationCategory.Description = NewName

                                If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Update(DbContext, JobSpecificationCategory) Then

                                    TabControlRightSection_Categories.SelectedTab.Text = NewName

                                End If

                            End Using

                        End If

                    End If

                End If

            End If

        End Sub
        Public Sub Save()

            'objects
            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing
            Dim JobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Classes.JobSpecificationField) = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim DataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobSpecificationType = Me.FillObject(False)

                    If JobSpecificationType IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.JobSpecificationType.Update(DbContext, JobSpecificationType) Then

                            For Each TabItem In TabControlRightSection_Categories.Tabs.OfType(Of DevComponents.DotNetBar.TabItem).Where(Function(TabItm) TabItm.Visible = True).ToList

                                Try

                                    DataGridView = TabItem.AttachedControl.Controls.OfType(Of AdvantageFramework.WinForm.Presentation.Controls.DataGridView).SingleOrDefault

                                Catch ex As Exception
                                    DataGridView = Nothing
                                End Try

                                If DataGridView IsNot Nothing Then

                                    DataGridView.CurrentView.CloseEditorForUpdating()

                                    JobSpecificationFields = DataGridView.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobSpecificationField).ToList

                                    For Each JobSpecField In JobSpecificationFields

                                        SaveJobSpecField(DbContext, JobSpecField)

                                    Next

                                End If

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

        End Sub
        Public Sub Delete()

            'objects
            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing
            Dim ErrorMessage As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobSpecificationType = Me.FillObject(False)

                    If JobSpecificationType IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.JobSpecificationType.Delete(DbContext, JobSpecificationType) = False Then

                            ErrorMessage = "Code is in use and cannot be deleted."

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
        Public Sub ActivateOrDectivateCategory(ByVal Active As Boolean)

            'objects
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing

            If TabControlRightSection_Categories.SelectedTab IsNot Nothing Then

                Try

                    JobSpecificationCategory = DirectCast(TabControlRightSection_Categories.SelectedTab.Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                Catch ex As Exception
                    JobSpecificationCategory = Nothing
                End Try

                If JobSpecificationCategory IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        If Active Then

                            JobSpecificationCategory.IsInactive = 0

                        Else

                            JobSpecificationCategory.IsInactive = 1

                        End If

                        If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Update(DbContext, JobSpecificationCategory) Then

                            RaiseEvent SelectedCategoryChangedEvent()

                            EnableOrDisableActions()

                        End If

                    End Using

                End If

            End If

        End Sub
        Public Sub MoveUpSelectedItem()

            'objects
            Dim JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing

            Try

                JobSpecificationField = Me.SelectedCategoryDataGridView.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                JobSpecificationField = Nothing
            End Try

            If JobSpecificationField IsNot Nothing Then

                MoveJobSpecificationField(JobSpecificationField, True)

                Me.SelectedCategoryDataGridView.SetUserEntryChanged()

            End If

        End Sub
        Public Sub MoveDownSelectedItem()

            'objects
            Dim JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing

            Try

                JobSpecificationField = Me.SelectedCategoryDataGridView.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                JobSpecificationField = Nothing
            End Try

            If JobSpecificationField IsNot Nothing Then

                MoveJobSpecificationField(JobSpecificationField, False)

                Me.SelectedCategoryDataGridView.SetUserEntryChanged()

            End If

        End Sub
        Public Sub AddCategory()

            'objects
            Dim CategoryDescription As String = ""
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing

            If AdvantageFramework.WinForm.Presentation.InputDialog.ShowFormDialog("Job Specification Category", "Name of new category:", "", CategoryDescription, AdvantageFramework.Database.Entities.JobSpecificationCategory.Properties.Description) = Windows.Forms.DialogResult.OK Then

                If CategoryDescription <> "" Then

                    Me.ShowWaitForm("Processing...")

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobSpecificationCategory = New AdvantageFramework.Database.Entities.JobSpecificationCategory

                        JobSpecificationCategory.Description = CategoryDescription
                        JobSpecificationCategory.JobSpecificationTypeCode = _JobSpecificationTypeCode
                        JobSpecificationCategory.IsInactive = 0
                        JobSpecificationCategory.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Insert(DbContext, JobSpecificationCategory) Then

                            CreateCategoryTab(JobSpecificationCategory)

                            EnableOrDisableActions()

                            RaiseEvent CategoriesChangedEvent()

                        End If

                    End Using

                    Me.CloseWaitForm()

                End If

            End If

        End Sub
        Public Function MoveItemToNewCategory() As Boolean

            'objects
            Dim JobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing
            Dim SelectedObjects As IEnumerable = Nothing
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim JobSpecificationCategoryID As Integer = 0
            Dim ParameterDictionary As Generic.Dictionary(Of String, Object) = Nothing
            Dim Moved As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                If Me.SelectedCategoryDataGridView.HasOnlyOneSelectedRow Then

                    JobSpecificationField = Me.SelectedCategoryDataGridView.GetFirstSelectedRowDataBoundItem

                    If JobSpecificationField IsNot Nothing AndAlso JobSpecificationField.HasError = False Then

                        ParameterDictionary = New Generic.Dictionary(Of String, Object)

                        ParameterDictionary("JobSpecificationTypeCode") = JobSpecificationField.JobSpecificationTypeCode

                        If AdvantageFramework.WinForm.Presentation.CRUDDialog.ShowFormDialog(CRUDDialog.Type.JobSpecCategory, True, True, SelectedObjects, False, Nothing, False, False, ParameterDictionary) = Windows.Forms.DialogResult.OK Then

                            Try

                                JobSpecificationCategoryID = (From Entity In SelectedObjects
                                                              Select Entity.ID).FirstOrDefault

                            Catch ex As Exception
                                JobSpecificationCategoryID = 0
                            End Try

                            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                                JobSpecificationCategory = AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByID(DbContext, JobSpecificationCategoryID)

                                If JobSpecificationCategory IsNot Nothing Then

                                    If JobSpecificationCategory.ID <> JobSpecificationField.JobSpecificationCategoryID Then

                                        Try

                                            JobSpecificationField.SequenceNumber = (From Entity In AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByJobSpecificationCategoryID(DbContext, JobSpecificationCategory.ID)
                                                                                    Select Entity.SequenceNumber).Max + 1

                                        Catch ex As Exception
                                            JobSpecificationField.SequenceNumber = 1
                                        End Try

                                        JobSpecificationField.JobSpecificationCategoryID = JobSpecificationCategory.ID

                                        Moved = SaveJobSpecField(DbContext, JobSpecificationField)

                                    End If

                                End If

                            End Using

                        End If

                    End If

                End If

            Catch ex As Exception
                ErrorMessage = "There was a problem moving the item to a new category. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New Exception(ErrorMessage)

            End If

            MoveItemToNewCategory = Moved

        End Function

#End Region

#Region "  Control Event Handlers "

        Private Sub JobSpecificationTemplateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ButtonLeftSection_Delete_Click(sender As Object, e As System.EventArgs) Handles ButtonLeftSection_Delete.Click

            'objects
            Dim SelectedCategoryDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim SelectedJobSpecificationField As AdvantageFramework.Database.Classes.JobSpecificationField = Nothing
            Dim SelectedFieldName As String = Nothing
            Dim AlertMessage As String = ""

            SelectedCategoryDataGridView = Me.SelectedCategoryDataGridView

            If SelectedCategoryDataGridView IsNot Nothing AndAlso SelectedCategoryDataGridView.HasOnlyOneSelectedRow Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    SelectedJobSpecificationField = SelectedCategoryDataGridView.GetFirstSelectedRowDataBoundItem

                    Try

                        If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM dbo.JOB_SPECS WHERE SPEC_TYPE_CODE = '{0}' AND {1} IS NOT NULL",
                                                                                     SelectedJobSpecificationField.JobSpecificationTypeCode,
                                                                                     SelectedJobSpecificationField.Name)).FirstOrDefault > 0 Then

                            AlertMessage = "'" & SelectedJobSpecificationField.Description & "' is in use. Are you sure you want to delete?"

                        Else

                            AlertMessage = "Are you sure you want to delete?"

                        End If

                    Catch ex As Exception
                        AlertMessage = "Are you sure you want to delete?"
                    End Try

                    If AdvantageFramework.Navigation.ShowMessageBox(AlertMessage, WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        JobSpecificationField = AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByFieldNameAndJobSpecificationTypeCode(DbContext, SelectedJobSpecificationField.Name, SelectedJobSpecificationField.JobSpecificationTypeCode)

                        If AdvantageFramework.Database.Procedures.JobSpecificationField.Delete(DbContext, JobSpecificationField) Then

                            LoadJobSpecificationFieldsByCategory(SelectedCategoryDataGridView, SelectedJobSpecificationField.JobSpecificationCategoryID)

                            LoadDefaultJobSpecificationFields()

                            EnableOrDisableActions()

                            RaiseEvent SelectedFieldChangedEvent()

                        End If

                    End If

                End Using

            End If

        End Sub
        Private Sub ButtonLeftSection_AddSelected_Click(sender As Object, e As System.EventArgs) Handles ButtonLeftSection_AddSelected.Click

            'objects
            Dim FieldNames As IEnumerable = Nothing
            Dim SelectedJobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim JobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim SelectedCategoryDataGridView As AdvantageFramework.WinForm.Presentation.Controls.DataGridView = Nothing

            If DataGridViewLeftSection_AvailableJobSpecificationFields.HasASelectedRow Then

                Me.ShowWaitForm("Processing...")

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    FieldNames = DataGridViewLeftSection_AvailableJobSpecificationFields.GetAllSelectedRowsBookmarkValues

                    SelectedJobSpecificationCategory = Me.SelectedJobSpecificationCategory

                    If SelectedJobSpecificationCategory IsNot Nothing Then

                        For Each FieldName In FieldNames.OfType(Of String)()

                            JobSpecificationField = New AdvantageFramework.Database.Entities.JobSpecificationField
                            JobSpecificationField.DbContext = DbContext
                            JobSpecificationField.Name = FieldName
                            JobSpecificationField.JobSpecificationTypeCode = _JobSpecificationTypeCode
                            JobSpecificationField.JobSpecificationCategoryID = SelectedJobSpecificationCategory.ID
                            JobSpecificationField.IsInactive = 0
                            JobSpecificationField.IsRequired = 0
                            JobSpecificationField.Description = FieldName

                            AdvantageFramework.Database.Procedures.JobSpecificationField.Insert(DbContext, JobSpecificationField)

                        Next

                        LoadJobSpecificationFieldsByCategory(Me.SelectedCategoryDataGridView, SelectedJobSpecificationCategory.ID)

                        LoadDefaultJobSpecificationFields()

                        EnableOrDisableActions()

                        RaiseEvent SelectedFieldChangedEvent()

                    End If

                End Using

                Me.CloseWaitForm()

            End If

        End Sub
        Private Sub ButtonRightSection_AddCategory_Click(sender As Object, e As System.EventArgs) Handles ButtonRightSection_AddCategory.Click

            AddCategory()

        End Sub
        Private Sub DataGridViewLeftSection_JobTemplateItems_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_AvailableJobSpecificationFields.SelectionChangedEvent

            EnableOrDisableActions()

            'RaiseEvent SelectedJobTemplateItemChanged()

        End Sub
        Private Sub TabControlRightSection_Categories_MouseClick(sender As Object, e As Windows.Forms.MouseEventArgs) Handles TabControlRightSection_Categories.MouseClick

            If e.Button = Windows.Forms.MouseButtons.Right Then

                Dim asasadasd As Object = Nothing

            End If

        End Sub
        Private Sub TabControlRightSection_Categories_SelectedTabChanged(sender As Object, e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlRightSection_Categories.SelectedTabChanged

            EnableOrDisableActions()

            RaiseEvent SelectedCategoryChangedEvent()

        End Sub
        Private Sub TabControlRightSection_Categories_TabMoved(sender As Object, e As DevComponents.DotNetBar.TabStripTabMovedEventArgs) Handles TabControlRightSection_Categories.TabMoved

            Dim SelectedJobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim SwitchWithJobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim SelectedCategorySequence As Integer = Nothing
            Dim SwitchWithCategorySequence As Integer = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Try

                    SelectedJobSpecificationCategory = DirectCast(TabControlRightSection_Categories.Tabs(e.OldIndex).Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)
                    SwitchWithJobSpecificationCategory = DirectCast(TabControlRightSection_Categories.Tabs(e.NewIndex).Tag, AdvantageFramework.Database.Entities.JobSpecificationCategory)

                Catch ex As Exception
                    SelectedJobSpecificationCategory = Nothing
                    SwitchWithJobSpecificationCategory = Nothing
                End Try

                If SelectedJobSpecificationCategory IsNot Nothing AndAlso SwitchWithJobSpecificationCategory IsNot Nothing Then

                    SelectedCategorySequence = SelectedJobSpecificationCategory.SequenceNumber
                    SwitchWithCategorySequence = SwitchWithJobSpecificationCategory.SequenceNumber

                    SelectedJobSpecificationCategory.SequenceNumber = SwitchWithCategorySequence
                    SwitchWithJobSpecificationCategory.SequenceNumber = SelectedCategorySequence

                    If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Update(DbContext, SelectedJobSpecificationCategory) = False OrElse
                       AdvantageFramework.Database.Procedures.JobSpecificationCategory.Update(DbContext, SwitchWithJobSpecificationCategory) = False Then

                        LoadJobSpecificationCategories()

                    End If

                End If

            End Using

        End Sub

#End Region

#End Region

    End Class

End Namespace
