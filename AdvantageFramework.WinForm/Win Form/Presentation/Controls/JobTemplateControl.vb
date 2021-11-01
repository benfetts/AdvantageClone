Namespace WinForm.Presentation.Controls

    Public Class JobTemplateControl

        Public Event SelectedJobTemplateDetailChanged()
        Public Event SelectedJobTemplateItemChanged()

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _FormSettingsLoaded As Boolean = False
        Private _Session As AdvantageFramework.Security.Session = Nothing
        Private _JobTemplateCode As String = Nothing
        Private _RepositoryItemCheckEdit_Blank As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit = Nothing
        Private _JobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing
        Private _JobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
        Private _IsCopy As Boolean = Nothing
        Private _IsControlClearing As Boolean = False

#End Region

#Region " Properties "

        Public ReadOnly Property JobTemplateCode As String
            Get
                JobTemplateCode = _JobTemplateCode
            End Get
        End Property
        Public ReadOnly Property JobTemplateDetailsGrid As AdvantageFramework.WinForm.Presentation.Controls.DataGridView
            Get
                JobTemplateDetailsGrid = DataGridViewRightSection_JobTemplateDetails
            End Get
        End Property
        Public ReadOnly Property CanMoveItemUp As Boolean
            Get
                CanMoveItemUp = If(DataGridViewRightSection_JobTemplateDetails.HasOnlyOneSelectedRow, Not DataGridViewRightSection_JobTemplateDetails.CurrentView.IsFirstRow, False)
            End Get
        End Property
        Public ReadOnly Property CanMoveItemDown As Boolean
            Get
                CanMoveItemDown = If(DataGridViewRightSection_JobTemplateDetails.HasOnlyOneSelectedRow, Not DataGridViewRightSection_JobTemplateDetails.CurrentView.IsLastRow, False)
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

                            ComboBoxLeftSection_Items.ByPassUserEntryChanged = True

                            TextBoxTopSection_Code.SetPropertySettings(AdvantageFramework.Database.Entities.JobTemplate.Properties.Code)
                            TextBoxTopSection_Description.SetPropertySettings(AdvantageFramework.Database.Entities.JobTemplate.Properties.Description)
                            SearchableComboBoxTopSection_DefaultSalesClass.SetPropertySettings(AdvantageFramework.Database.Entities.JobTemplate.Properties.DefaultSalesClassCode)

                            _RepositoryItemCheckEdit_Blank = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
                            _RepositoryItemCheckEdit_Blank.DisplayValueChecked = ""
                            _RepositoryItemCheckEdit_Blank.DisplayValueUnchecked = ""
                            _RepositoryItemCheckEdit_Blank.DisplayValueGrayed = ""
                            _RepositoryItemCheckEdit_Blank.ExportMode = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureChecked = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureGrayed = Nothing
                            _RepositoryItemCheckEdit_Blank.PictureUnchecked = Nothing
                            _RepositoryItemCheckEdit_Blank.CheckStyle = DevExpress.XtraEditors.Controls.CheckStyles.UserDefined
                            _RepositoryItemCheckEdit_Blank.ValueUnchecked = CByte(0)
                            _RepositoryItemCheckEdit_Blank.ValueChecked = CByte(1)
                            _RepositoryItemCheckEdit_Blank.ValueGrayed = Nothing
                            DataGridViewRightSection_JobTemplateDetails.GridControl.RepositoryItems.Add(_RepositoryItemCheckEdit_Blank)

                            LoadDropDownDataSources()

                            ComboBoxLeftSection_Items.DataSource = AdvantageFramework.EnumUtilities.GetEnumDataTable(GetType(AdvantageFramework.Database.Entities.JobTemplateItemCategory), False)

                        End Using

                    End If

                End If

                _FormSettingsLoaded = True

            End If

        End Sub
        Private Sub LoadJobTemplateDetails()

            'objects
            Dim JobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing
            Dim AvailableJobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobTemplateDetails IsNot Nothing Then

                    If _JobTemplateDetails.Count > 0 Then

                        DataGridViewRightSection_JobTemplateDetails.DataSource = _JobTemplateDetails.OrderBy(Function(JobTempDtl) JobTempDtl.SequenceNumber)

                    Else

                        DataGridViewRightSection_JobTemplateDetails.DataSource = Nothing

                    End If

                    DataGridViewRightSection_JobTemplateDetails.CurrentView.BestFitColumns()

                    If _JobTemplateItems IsNot Nothing Then

                        Try

                            AvailableJobTemplateItems = (From Entity In _JobTemplateItems
                                                         Where _JobTemplateDetails.Any(Function(JobTemplateDetail) JobTemplateDetail.ItemCode = Entity.Code) = False OrElse
                                                               Convert.ToBoolean(Entity.AllowMultiple) = True
                                                         Select Entity
                                                         Order By Entity.DisplayOrder).ToList

                            Select Case DirectCast(CShort(ComboBoxLeftSection_Items.GetSelectedValue), AdvantageFramework.Database.Entities.JobTemplateItemCategory)

                                Case Database.Entities.JobTemplateItemCategory.All

                                    JobTemplateItems = AvailableJobTemplateItems

                                Case Database.Entities.JobTemplateItemCategory.Fields

                                    JobTemplateItems = (From Entity In AvailableJobTemplateItems
                                                        Where Entity.Type = "F" OrElse
                                                              Entity.Type = "S" OrElse
                                                              Entity.Type = "D"
                                                        Select Entity
                                                        Order By Entity.DisplayOrder).ToList

                                Case Database.Entities.JobTemplateItemCategory.SystemRequired

                                    JobTemplateItems = (From Entity In AvailableJobTemplateItems
                                                        Where Convert.ToBoolean(Entity.AdvantageRequired) = True
                                                        Select Entity
                                                        Order By Entity.DisplayOrder).ToList

                                    'Case Database.Entities.JobTemplateItemCategory.WorkflowItems

                                    '    JobTemplateItems = (From Entity In AvailableJobTemplateItems _
                                    '                        Where Entity.Type = "W" _
                                    '                        Select Entity _
                                    '                        Order By Entity.DisplayOrder).ToList

                            End Select

                        Catch ex As Exception
                            JobTemplateItems = New Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem)
                        End Try

                        DataGridViewLeftSection_JobTemplateItems.DataSource = JobTemplateItems
                        DataGridViewLeftSection_JobTemplateItems.CurrentView.BestFitColumns()

                    End If

                End If

            End Using

        End Sub
        Private Sub LoadJobTemplateEntity(ByVal JobTemplate As AdvantageFramework.Database.Entities.JobTemplate)

            If JobTemplate IsNot Nothing Then

                JobTemplate.Code = TextBoxTopSection_Code.Text
                JobTemplate.Description = TextBoxTopSection_Description.Text
                JobTemplate.DefaultSalesClassCode = SearchableComboBoxTopSection_DefaultSalesClass.GetSelectedValue
                JobTemplate.IsInactive = Convert.ToInt16(CheckBoxTopSection_Inactive.Checked)

            End If

        End Sub
        Private Sub MoveTemplateItem(ByVal JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail, ByVal MoveUp As Boolean)

            'objects
            Dim JobTemplateDetailAboveOrBelow As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing
            Dim AllJobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
            Dim IsASection As Boolean = Nothing
            Dim IsNextTemplateASection As Boolean = Nothing
            Dim FocusedRowHandle As Integer = Nothing

            FocusedRowHandle = DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle

            If JobTemplateDetail IsNot Nothing Then

                AllJobTemplateDetails = DataGridViewRightSection_JobTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail).ToList

                If MoveUp Then

                    Try

                        JobTemplateDetailAboveOrBelow = (From Entity In AllJobTemplateDetails
                                                         Where Entity.SequenceNumber < JobTemplateDetail.SequenceNumber
                                                         Order By Entity.SequenceNumber Descending
                                                         Select Entity).FirstOrDefault

                    Catch ex As Exception
                        JobTemplateDetailAboveOrBelow = Nothing
                    End Try

                    If JobTemplateDetailAboveOrBelow IsNot Nothing Then

                        JobTemplateDetailAboveOrBelow.SequenceNumber = JobTemplateDetailAboveOrBelow.SequenceNumber + 1

                        JobTemplateDetail.SequenceNumber = JobTemplateDetail.SequenceNumber - 1

                    End If

                Else

                    Try

                        JobTemplateDetailAboveOrBelow = (From Entity In AllJobTemplateDetails
                                                         Where Entity.SequenceNumber > JobTemplateDetail.SequenceNumber
                                                         Order By Entity.SequenceNumber Ascending
                                                         Select Entity).FirstOrDefault

                    Catch ex As Exception
                        JobTemplateDetailAboveOrBelow = Nothing
                    End Try

                    If JobTemplateDetailAboveOrBelow IsNot Nothing Then

                        JobTemplateDetailAboveOrBelow.SequenceNumber = JobTemplateDetailAboveOrBelow.SequenceNumber - 1

                        JobTemplateDetail.SequenceNumber = JobTemplateDetail.SequenceNumber + 1

                    End If

                End If

                DataGridViewRightSection_JobTemplateDetails.DataSource = AllJobTemplateDetails.OrderBy(Function(JobTempDtl) JobTempDtl.SequenceNumber)

                DataGridViewRightSection_JobTemplateDetails.CurrentView.BestFitColumns()

                If MoveUp Then
                    DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = FocusedRowHandle

                    DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = FocusedRowHandle - 1
                Else
                    DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = FocusedRowHandle

                    DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = FocusedRowHandle + 1
                End If


                DataGridViewRightSection_JobTemplateDetails.SetUserEntryChanged()

            End If

        End Sub
        Private Sub InsertTemplateItem()

            'objects
            Dim SelectedJobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing
            Dim AllJobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
            Dim JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing
            Dim SelectedJobTemplateItemCodes() As String = Nothing
            Dim SelectedJobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing
            Dim JobTemplateItem As AdvantageFramework.Database.Entities.JobTemplateItem = Nothing
            Dim SequenceStart As Short = Nothing
            Dim SectionOrder As Short = Nothing
            Dim SelectedJobTemplateItemCode As String = Nothing

            If DataGridViewLeftSection_JobTemplateItems.HasASelectedRow Then

                Try

                    SelectedJobTemplateItemCodes = DataGridViewLeftSection_JobTemplateItems.GetAllSelectedRowsBookmarkValues.OfType(Of String).ToArray

                    Try

                        SelectedJobTemplateDetail = DataGridViewRightSection_JobTemplateDetails.GetFirstSelectedRowDataBoundItem

                    Catch ex As Exception
                        SelectedJobTemplateDetail = Nothing
                    End Try

                    If SelectedJobTemplateDetail IsNot Nothing Then

                        SequenceStart = SelectedJobTemplateDetail.SequenceNumber + 1
                        SectionOrder = SelectedJobTemplateDetail.SectionOrder

                    Else

                        SectionOrder = 1
                        SequenceStart = 1

                    End If

                    For Each SelectedJobTemplateItemCode In SelectedJobTemplateItemCodes

                        Try

                            JobTemplateItem = (From Entity In _JobTemplateItems
                                               Where Entity.Code = SelectedJobTemplateItemCode
                                               Select Entity).SingleOrDefault

                        Catch ex As Exception
                            JobTemplateItem = Nothing
                        End Try

                        If JobTemplateItem IsNot Nothing Then

                            JobTemplateDetail = New AdvantageFramework.Database.Classes.JobTemplateDetail

                            JobTemplateDetail.SequenceNumber = SequenceStart
                            JobTemplateDetail.ItemCode = JobTemplateItem.Code
                            JobTemplateDetail.OriginalLabel = JobTemplateItem.Description
                            JobTemplateDetail.Label = JobTemplateItem.Description
                            JobTemplateDetail.SectionOrder = SectionOrder
                            JobTemplateDetail.AdvantageRequired = JobTemplateItem.AdvantageRequired
                            JobTemplateDetail.Include = CByte(1)
                            JobTemplateDetail.IsRequired = JobTemplateItem.AdvantageRequired

                            _JobTemplateDetails.Add(JobTemplateDetail)

                            SequenceStart = SequenceStart + 1

                        End If

                    Next

                    Try

                        AllJobTemplateDetails = DataGridViewRightSection_JobTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail).ToList

                    Catch ex As Exception
                        AllJobTemplateDetails = Nothing
                    End Try

                    If AllJobTemplateDetails IsNot Nothing Then

                        For Each JobTemplateDetail In AllJobTemplateDetails.Where(Function(JobTempDtl) JobTempDtl.SequenceNumber > SelectedJobTemplateDetail.SequenceNumber).ToList

                            JobTemplateDetail.SequenceNumber = JobTemplateDetail.SequenceNumber + SelectedJobTemplateItemCodes.Count

                        Next

                    End If

                Catch ex As Exception

                End Try

                LoadJobTemplateDetails()

            End If

        End Sub
        Private Sub DeleteTemplateDetail()

            'objects
            Dim SelectedJobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing

            Try

                For Each SelectedJobTemplateDetail In DataGridViewRightSection_JobTemplateDetails.GetAllSelectedRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail)()

                    Try

                        For Each JobTemplateDetail In DataGridViewRightSection_JobTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail).Where(Function(JobTempDtl) JobTempDtl.SequenceNumber > SelectedJobTemplateDetail.SequenceNumber)

                            JobTemplateDetail.SequenceNumber = JobTemplateDetail.SequenceNumber - 1

                        Next

                        _JobTemplateDetails.Remove(SelectedJobTemplateDetail)

                    Catch ex As Exception

                    End Try

                Next

            Catch ex As Exception

            End Try

            LoadJobTemplateDetails()

            Try
                DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle + 1
                DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle = DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedRowHandle - 1
            Catch ex As Exception

            End Try

        End Sub
        Private Sub SelectRequiredItems()

            Try

                ExpandableSplitterControlRightSection_LeftRight.Expanded = True

                ComboBoxLeftSection_Items.SelectedValue = CInt(Database.Entities.JobTemplateItemCategory.SystemRequired)

            Catch ex As Exception

            End Try

        End Sub
        Private Sub LoadDropDownDataSources()

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _JobTemplateItems = AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext).ToList

                SearchableComboBoxTopSection_DefaultSalesClass.DataSource = AdvantageFramework.Database.Procedures.SalesClass.LoadAllActive(DbContext).ToList

            End Using

        End Sub

#Region "  Public "

        Public Function Save() As Boolean

            'objects
            Dim JobTemplate As AdvantageFramework.Database.Entities.JobTemplate = Nothing
            Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail = Nothing
            Dim JobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
            Dim JobTemplateDetailsOriginal As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateDetail) = Nothing
            Dim SequenceNumber As Short = 1
            Dim SectionNumber As Short = Nothing
            Dim ItemOrder As Short = Nothing
            Dim AdvantageRequiredJobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing
            Dim Saved As Boolean = False
            Dim ErrorMessage As String = ""
            Dim Label As String = ""

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageRequiredJobTemplateItems = AdvantageFramework.Database.Procedures.JobTemplateItem.LoadRequired(DbContext).ToList

                    JobTemplateDetails = DataGridViewRightSection_JobTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail).ToList

                    For Each JobTempDetail In JobTemplateDetails
                        If JobTempDetail.Label = "" Then

                            AdvantageFramework.WinForm.MessageBox.Show("Label is required.")
                            Exit For

                        End If

                        JobTemplateDetailsOriginal = AdvantageFramework.Database.Procedures.JobTemplateDetail.LoadByJobTemplateCode(DbContext, _JobTemplateCode).ToList

                        For Each JobTempDetailOrig In JobTemplateDetailsOriginal
                            If JobTempDetail.ItemCode = JobTempDetailOrig.ItemCode And JobTempDetail.Label <> JobTempDetailOrig.Label And JobTempDetailOrig.ItemCode <> "SECTION" Then
                                If (From Entity In AdvantageFramework.Database.Procedures.JobTemplateDetail.LoadByJobTemplateCode(DbContext, _JobTemplateCode).ToList
                                    Where Entity.Label.ToUpper = JobTempDetail.Label.ToUpper And Entity.ItemCode <> "SECTION"
                                    Select Entity).Count = 1 Then

                                    ErrorMessage = "Duplicate Label(s) for '" & JobTempDetail.Label & "' ."
                                    Exit For

                                End If
                            End If
                        Next

                        If ErrorMessage <> "" Then
                            Exit For
                        End If

                    Next

                    If (From Entity In JobTemplateDetails
                        Where AdvantageRequiredJobTemplateItems.Where(Function(RequiredTemplateItem) RequiredTemplateItem.Code = Entity.ItemCode).Any
                        Select Entity).Count <> AdvantageRequiredJobTemplateItems.Count Then

                        ErrorMessage = "Fields required by Advantage are missing."

                        SelectRequiredItems()

                    ElseIf ErrorMessage = "" Then

                        JobTemplate = Me.FillObject(False)

                        If JobTemplate IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.JobTemplate.Update(DbContext, JobTemplate) Then

                                Saved = True

                                If AdvantageFramework.Database.Procedures.JobTemplateDetail.DeleteByJobTemplateCode(DbContext, JobTemplate.Code) Then

                                    For Each JobTempDetail In JobTemplateDetails

                                        JobTemplateDetail = JobTempDetail.GetJobTemplateDetail

                                        JobTemplateDetail.DbContext = DbContext
                                        JobTemplateDetail.JobTemplateCode = JobTemplate.Code
                                        JobTemplateDetail.SequenceNumber = SequenceNumber

                                        If JobTemplateDetail.ItemCode = "SECTION" Then

                                            SectionNumber = SectionNumber + 1
                                            JobTemplateDetail.ItemOrder = Nothing

                                        Else

                                            ItemOrder = ItemOrder + 1
                                            JobTemplateDetail.ItemOrder = ItemOrder

                                        End If

                                        JobTemplateDetail.SectionOrder = SectionNumber

                                        If AdvantageFramework.Database.Procedures.JobTemplateDetail.Insert(DbContext, JobTemplateDetail) Then

                                            SequenceNumber = SequenceNumber + 1

                                        End If

                                    Next

                                End If

                            End If

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
            Dim JobTemplate As AdvantageFramework.Database.Entities.JobTemplate = Nothing
            Dim Deleted As Boolean = False
            Dim ErrorMessage As String = ""
            Dim JobCount As Integer = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobTemplate = Me.FillObject(False)

                    If JobTemplate IsNot Nothing Then

                        JobCount = (From Entity In AdvantageFramework.Database.Procedures.JobComponent.Load(DbContext)
                                    Where Entity.JobTemplateCode = JobTemplate.Code
                                    Select Entity.JobNumber Distinct).Count

                        If JobCount > 0 Then

                            ErrorMessage = "This template is used on " & JobCount.ToString & " job(s). It cannot be deleted."

                        Else

                            Deleted = AdvantageFramework.Database.Procedures.JobTemplate.Delete(DbContext, JobTemplate)

                        End If

                    End If

                End Using

                If Deleted = False AndAlso ErrorMessage = "" Then

                    ErrorMessage = "Failed trying to delete from the database. Please contact software support."

                End If

            Catch ex As Exception
                ErrorMessage = "Failed trying to delete from the database. Please contact software support."
            End Try

            If ErrorMessage <> "" Then

                Throw New System.Exception(ErrorMessage)

            End If

            Delete = Deleted

        End Function
        Public Function Insert(ByRef JobTemplateCode As String) As Boolean

            'objects
            Dim JobTemplate As AdvantageFramework.Database.Entities.JobTemplate = Nothing
            Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail = Nothing
            Dim JobTemplateDetails As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
            Dim JobTemplateDetailsOriginal As Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail) = Nothing
            Dim SequenceNumber As Short = 1
            Dim SectionNumber As Short = Nothing
            Dim ItemOrder As Short = Nothing
            Dim AdvantageRequiredJobTemplateItems As Generic.List(Of AdvantageFramework.Database.Entities.JobTemplateItem) = Nothing
            Dim Inserted As Boolean = False
            Dim ErrorMessage As String = Nothing

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    AdvantageRequiredJobTemplateItems = AdvantageFramework.Database.Procedures.JobTemplateItem.LoadRequired(DbContext).ToList

                    JobTemplateDetails = DataGridViewRightSection_JobTemplateDetails.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Classes.JobTemplateDetail).ToList

                    For Each JobTempDetail In JobTemplateDetails
                        If JobTempDetail.Label = "" Then

                            ErrorMessage = "Label is required."
                            Exit For

                        End If

                        JobTemplateDetailsOriginal = JobTemplateDetails

                        If (From Entity In JobTemplateDetailsOriginal
                            Where Entity.Label.ToUpper = JobTempDetail.Label.ToUpper And Entity.ItemCode <> "SECTION"
                            Select Entity).Count > 1 Then

                            ErrorMessage = "Duplicate Label(s) for '" & JobTempDetail.Label & "' ."
                            Exit For

                        End If

                        If ErrorMessage <> "" Then
                            Exit For
                        End If

                    Next

                    If (From Entity In JobTemplateDetails
                        Where AdvantageRequiredJobTemplateItems.Where(Function(RequiredTemplateItem) RequiredTemplateItem.Code = Entity.ItemCode).Any
                        Select Entity).Count <> AdvantageRequiredJobTemplateItems.Count Then

                        AdvantageFramework.Navigation.ShowMessageBox("Fields required by Advantage are missing.")

                        SelectRequiredItems()

                    ElseIf ErrorMessage = "" Then

                        JobTemplate = Me.FillObject(True)

                        JobTemplate.DbContext = DbContext

                        If AdvantageFramework.Database.Procedures.JobTemplate.Insert(DbContext, JobTemplate) Then

                            Inserted = True

                            For Each JobTempDetail In JobTemplateDetails

                                JobTemplateDetail = JobTempDetail.GetJobTemplateDetail

                                JobTemplateDetail.DbContext = DbContext
                                JobTemplateDetail.JobTemplateCode = JobTemplate.Code
                                JobTemplateDetail.SequenceNumber = SequenceNumber

                                If JobTemplateDetail.ItemCode = "SECTION" Then

                                    SectionNumber = SectionNumber + 1
                                    JobTemplateDetail.ItemOrder = Nothing

                                Else

                                    ItemOrder = ItemOrder + 1
                                    JobTemplateDetail.ItemOrder = ItemOrder

                                End If

                                JobTemplateDetail.SectionOrder = SectionNumber

                                If AdvantageFramework.Database.Procedures.JobTemplateDetail.Insert(DbContext, JobTemplateDetail) Then

                                    SequenceNumber = SequenceNumber + 1

                                End If

                            Next

                            JobTemplateCode = JobTemplate.Code

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
        Public Function LoadControl(ByVal JobTemplateCode As String, Optional ByVal IsCopy As Boolean = False) As Boolean

            'objects
            Dim Loaded As Boolean = True
            Dim JobTemplate As AdvantageFramework.Database.Entities.JobTemplate = Nothing

            _JobTemplateCode = JobTemplateCode
            _IsCopy = IsCopy

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If _JobTemplateCode <> "" Then

                    JobTemplate = AdvantageFramework.Database.Procedures.JobTemplate.LoadByJobTemplateCode(DbContext, _JobTemplateCode)

                    If JobTemplate IsNot Nothing Then

                        If _IsCopy = False Then

                            TextBoxTopSection_Code.Text = JobTemplate.Code
                            TextBoxTopSection_Description.Text = JobTemplate.Description

                        End If

                        TextBoxTopSection_Code.Enabled = _IsCopy
                        TextBoxTopSection_Code.ReadOnly = Not _IsCopy

                        CheckBoxTopSection_Inactive.Checked = Convert.ToBoolean(JobTemplate.IsInactive.GetValueOrDefault(0))

                        If JobTemplate.DefaultSalesClassCode IsNot Nothing Then

                            SearchableComboBoxTopSection_DefaultSalesClass.SelectedValue = JobTemplate.DefaultSalesClassCode

                        End If

                        _JobTemplateDetails = AdvantageFramework.Database.Procedures.JobTemplateDetail.LoadByJobTemplateCode(DbContext, _JobTemplateCode).Include("JobTemplateItem").ToList.Select(Function(JobTempDtl) New AdvantageFramework.Database.Classes.JobTemplateDetail(JobTempDtl)).ToList

                    Else

                        Loaded = False

                    End If

                Else

                    _JobTemplateDetails = New Generic.List(Of AdvantageFramework.Database.Classes.JobTemplateDetail)

                    TextBoxTopSection_Code.Enabled = True
                    TextBoxTopSection_Code.ReadOnly = False

                End If

            End Using

            ComboBoxLeftSection_Items.SelectedValue = CInt(Database.Entities.JobTemplateItemCategory.All)
            'LoadJobTemplateDetails()

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            LoadControl = Loaded

        End Function
        Public Function FillObject(ByVal IsNew As Boolean) As AdvantageFramework.Database.Entities.JobTemplate

            Dim JobTemplate As AdvantageFramework.Database.Entities.JobTemplate = Nothing

            Try

                If IsNew Then

                    JobTemplate = New AdvantageFramework.Database.Entities.JobTemplate

                    LoadJobTemplateEntity(JobTemplate)

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobTemplate = AdvantageFramework.Database.Procedures.JobTemplate.LoadByJobTemplateCode(DbContext, _JobTemplateCode)

                        If JobTemplate IsNot Nothing Then

                            LoadJobTemplateEntity(JobTemplate)

                        End If

                    End Using

                End If

            Catch ex As Exception
                JobTemplate = Nothing
            End Try

            FillObject = JobTemplate

        End Function
        Public Sub ClearControl()

            _IsControlClearing = True

            TextBoxTopSection_Code.Text = Nothing
            TextBoxTopSection_Description.Text = Nothing
            ComboBoxLeftSection_Items.SelectedValue = Nothing
            CheckBoxTopSection_Inactive.Checked = False
            DataGridViewLeftSection_JobTemplateItems.DataSource = Nothing
            DataGridViewRightSection_JobTemplateDetails.DataSource = Nothing
            SearchableComboBoxTopSection_DefaultSalesClass.SelectedValue = Nothing

            AdvantageFramework.WinForm.Presentation.Controls.ClearUserEntryChangedSetting(Me)

            _IsControlClearing = False

        End Sub
        Public Sub AddSelectedTemplateItems()

            If ExpandableSplitterControlRightSection_LeftRight.Expanded Then

                InsertTemplateItem()

                DataGridViewRightSection_JobTemplateDetails.SetUserEntryChanged()

            Else

                ExpandableSplitterControlRightSection_LeftRight.Expanded = True

            End If

        End Sub
        Public Sub DeleteSelectedTemplateItems()

            If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                DeleteTemplateDetail()

                DataGridViewRightSection_JobTemplateDetails.SetUserEntryChanged()

            End If

        End Sub
        Public Sub MoveUpSelectedItem()

            'objects
            Dim JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing

            JobTemplateDetail = DataGridViewRightSection_JobTemplateDetails.GetFirstSelectedRowDataBoundItem

            If JobTemplateDetail IsNot Nothing Then

                MoveTemplateItem(JobTemplateDetail, True)

                DataGridViewRightSection_JobTemplateDetails.SetUserEntryChanged()

            End If

        End Sub
        Public Sub MoveDownSelectedItem()

            'objects
            Dim JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing

            JobTemplateDetail = DataGridViewRightSection_JobTemplateDetails.GetFirstSelectedRowDataBoundItem

            If JobTemplateDetail IsNot Nothing Then

                MoveTemplateItem(JobTemplateDetail, False)

                DataGridViewRightSection_JobTemplateDetails.SetUserEntryChanged()

            End If

        End Sub
        Public Sub RefreshControl()

            LoadDropDownDataSources()

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub JobTemplateControl_Load(sender As Object, e As System.EventArgs) Handles Me.Load



        End Sub

#End Region

#Region "  Custom Control Event Handlers "

        Private Sub ComboBoxLeftSection_Items_SelectedValueChanged(sender As Object, e As System.EventArgs) Handles ComboBoxLeftSection_Items.SelectedValueChanged

            'objects
            Dim SelectedValue As Object = Nothing

            If ComboBoxLeftSection_Items.IsDataSourceLoading = False Then

                If ComboBoxLeftSection_Items.HasASelectedValue Then

                    SelectedValue = ComboBoxLeftSection_Items.GetSelectedValue

                    LoadJobTemplateDetails()

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_JobTemplateDetails_CellValueChangingEvent(ByRef Saved As Boolean, e As DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs) Handles DataGridViewRightSection_JobTemplateDetails.CellValueChangingEvent

            'objects
            Dim JobTempDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing
            Dim JobTemplateDetail As AdvantageFramework.Database.Entities.JobTemplateDetail = Nothing

            If String.IsNullOrEmpty(_JobTemplateCode) = False AndAlso _IsCopy = False Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.JobTemplateDetail.Properties.IsRequired.ToString OrElse
                    e.Column.FieldName = AdvantageFramework.Database.Entities.JobTemplateDetail.Properties.Include.ToString Then

                    Try

                        JobTempDetail = DataGridViewRightSection_JobTemplateDetails.CurrentView.GetRow(e.RowHandle)

                    Catch ex As Exception
                        JobTempDetail = Nothing
                    End Try

                    If JobTempDetail IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Try

                                JobTemplateDetail = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateDetail.LoadByJobTemplateCode(DbContext, _JobTemplateCode)
                                                     Where Entity.ItemCode = JobTempDetail.ItemCode
                                                     Select Entity).SingleOrDefault

                            Catch ex As Exception
                                JobTemplateDetail = Nothing
                            End Try

                            If JobTemplateDetail IsNot Nothing Then

                                Select Case e.Column.FieldName

                                    Case AdvantageFramework.Database.Entities.JobTemplateDetail.Properties.IsRequired.ToString

                                        JobTemplateDetail.IsRequired = CByte(e.Value)

                                    Case AdvantageFramework.Database.Entities.JobTemplateDetail.Properties.Include.ToString

                                        JobTemplateDetail.Include = CByte(e.Value)

                                End Select

                                Saved = AdvantageFramework.Database.Procedures.JobTemplateDetail.Update(DbContext, JobTemplateDetail)

                            End If

                        End Using

                    End If

                ElseIf e.Column.FieldName = AdvantageFramework.Database.Entities.JobTemplateDetail.Properties.Label.ToString Then


                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_JobTemplateDetails_ShowingEditorEvent(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DataGridViewRightSection_JobTemplateDetails.ShowingEditorEvent

            'objects
            Dim JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing
            Dim FocusedColumnFieldName As String = Nothing

            Try

                JobTemplateDetail = DataGridViewRightSection_JobTemplateDetails.GetFirstSelectedRowDataBoundItem

            Catch ex As Exception
                JobTemplateDetail = Nothing
            End Try

            If JobTemplateDetail IsNot Nothing Then

                FocusedColumnFieldName = DataGridViewRightSection_JobTemplateDetails.CurrentView.FocusedColumn.FieldName

                If FocusedColumnFieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.IsRequired.ToString OrElse
                   FocusedColumnFieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.Include.ToString Then

                    If JobTemplateDetail.ItemCode = "SECTION" Then

                        e.Cancel = True

                    ElseIf Convert.ToBoolean(JobTemplateDetail.AdvantageRequired) Then

                        e.Cancel = True

                    End If

                End If

            Else

                e.Cancel = True

            End If

        End Sub
        Private Sub DataGridViewRightSection_JobTemplateDetails_CustomDrawCellEvent(sender As Object, e As DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs) Handles DataGridViewRightSection_JobTemplateDetails.CustomDrawCellEvent

            'objects
            Dim ItemCode As String = Nothing
            Dim AdvantageRequired As Boolean = Nothing

            Try

                ItemCode = DataGridViewRightSection_JobTemplateDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.ItemCode.ToString)
                AdvantageRequired = CBool(DataGridViewRightSection_JobTemplateDetails.CurrentView.GetRowCellValue(e.RowHandle, AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.AdvantageRequired.ToString))

            Catch ex As Exception
                ItemCode = ""
                AdvantageRequired = False
            End Try

            If ItemCode <> "" AndAlso ItemCode.ToUpper = "SECTION" Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(255, 255, 128)

            ElseIf AdvantageRequired Then

                e.Appearance.BackColor = System.Drawing.Color.FromArgb(183, 216, 221)

            End If

        End Sub
        Private Sub DataGridViewRightSection_JobTemplateDetails_CustomRowCellEditEvent(sender As Object, e As DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs) Handles DataGridViewRightSection_JobTemplateDetails.CustomRowCellEditEvent

            'objects
            Dim JobTemplateDetail As AdvantageFramework.Database.Classes.JobTemplateDetail = Nothing

            Try

                JobTemplateDetail = DataGridViewRightSection_JobTemplateDetails.CurrentView.GetRow(e.RowHandle)

            Catch ex As Exception
                JobTemplateDetail = Nothing
            End Try

            If JobTemplateDetail IsNot Nothing Then

                If e.Column.FieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.IsRequired.ToString OrElse
                   e.Column.FieldName = AdvantageFramework.Database.Classes.JobTemplateDetail.Properties.Include.ToString Then

                    If JobTemplateDetail.ItemCode = "SECTION" Then

                        e.RepositoryItem = _RepositoryItemCheckEdit_Blank

                    End If

                End If

            End If

        End Sub
        Private Sub DataGridViewRightSection_JobTemplateDetails_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewRightSection_JobTemplateDetails.SelectionChangedEvent

            RaiseEvent SelectedJobTemplateDetailChanged()

        End Sub
        Private Sub DataGridViewLeftSection_JobTemplateItems_SelectionChangedEvent(sender As Object, e As System.EventArgs) Handles DataGridViewLeftSection_JobTemplateItems.SelectionChangedEvent

            RaiseEvent SelectedJobTemplateItemChanged()

        End Sub

#End Region

#End Region

    End Class

End Namespace
