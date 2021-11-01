Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobSpecificationTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _IsCopy As Boolean = Nothing
        Private _JobSpecificationTypeCode As String = Nothing

#End Region

#Region " Properties "

        Private ReadOnly Property JobSpecificationTypeCode As String
            Get
                JobSpecificationTypeCode = _JobSpecificationTypeCode
            End Get
        End Property
        Private ReadOnly Property IsCopy As Boolean
            Get
                IsCopy = _IsCopy
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByRef JobSpecificationTypeCode As String, ByVal IsCopy As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _JobSpecificationTypeCode = JobSpecificationTypeCode
            _IsCopy = IsCopy

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(Optional ByRef JobSpecificationTypeCode As String = Nothing, Optional ByVal IsCopy As Boolean = False) As System.Windows.Forms.DialogResult

            'objects
            Dim JobSpecificationTemplateEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateEditDialog = Nothing

            JobSpecificationTemplateEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobSpecificationTemplateEditDialog(JobSpecificationTypeCode, IsCopy)

            ShowFormDialog = JobSpecificationTemplateEditDialog.ShowDialog()

            JobSpecificationTypeCode = JobSpecificationTemplateEditDialog.JobSpecificationTypeCode
            IsCopy = JobSpecificationTemplateEditDialog.IsCopy

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobSpecificationTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_Code.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.Code)
                TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.Description)
                ComboBoxForm_UseVendorTab.SetPropertySettings(AdvantageFramework.Database.Entities.JobSpecificationType.Properties.UseVendorTab)

                ComboBoxForm_UseVendorTab.DataSource = AdvantageFramework.Database.Procedures.JobSpecificationVendorTab.Load(DbContext).ToList

                If _IsCopy Then

                    JobSpecificationType = AdvantageFramework.Database.Procedures.JobSpecificationType.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode)

                    Me.Text = "Copy Job Specification Template"

                    If JobSpecificationType IsNot Nothing Then

                        TextBoxForm_Description.Text = JobSpecificationType.Description
                        CheckBoxForm_Inactive.Checked = Convert.ToBoolean(JobSpecificationType.IsInactive)
                        CheckBoxForm_UseQuantitiesTab.Checked = Convert.ToBoolean(JobSpecificationType.UseQuantitiesTab)
                        ComboBoxForm_UseVendorTab.SelectedValue = JobSpecificationType.UseVendorTab

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("The job specification template you are trying to copy does not exist anymore.")
                        Me.Close()

                    End If

                Else

                    Me.Text = "Add Job Specification Template"

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Add.Click

            Dim JobSpecificationType As AdvantageFramework.Database.Entities.JobSpecificationType = Nothing
            Dim JobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim DuplicateJobSpecificationCategory As AdvantageFramework.Database.Entities.JobSpecificationCategory = Nothing
            Dim JobSpecificationCategories As Generic.List(Of AdvantageFramework.Database.Entities.JobSpecificationCategory) = Nothing
            Dim JobSpecificationFields As Generic.List(Of AdvantageFramework.Database.Entities.JobSpecificationField) = Nothing
            Dim DuplicateJobSpecificationField As AdvantageFramework.Database.Entities.JobSpecificationField = Nothing
            Dim ErrorMessage As String = Nothing
            Dim IsValid As Boolean = True

            If Me.Validator Then

                Me.ShowWaitForm("Processing...")

                Try

                    Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        JobSpecificationType = New AdvantageFramework.Database.Entities.JobSpecificationType

                        JobSpecificationType.DbContext = DbContext
                        JobSpecificationType.Code = TextBoxForm_Code.Text
                        JobSpecificationType.Description = TextBoxForm_Description.Text
                        JobSpecificationType.UseQuantitiesTab = Convert.ToInt16(CheckBoxForm_UseQuantitiesTab.Checked)
                        JobSpecificationType.UseVendorTab = ComboBoxForm_UseVendorTab.GetSelectedValue
                        JobSpecificationType.IsInactive = Convert.ToInt16(CheckBoxForm_Inactive.Checked)

                        If AdvantageFramework.Database.Procedures.JobSpecificationType.Insert(DbContext, JobSpecificationType) Then

                            If _IsCopy Then

                                JobSpecificationCategories = AdvantageFramework.Database.Procedures.JobSpecificationCategory.LoadByJobSpecificationTypeCode(DbContext, _JobSpecificationTypeCode).ToList

                                For Each JobSpecificationCategory In JobSpecificationCategories.OrderBy(Function(Entity) Entity.SequenceNumber).ToList

                                    DuplicateJobSpecificationCategory = New AdvantageFramework.Database.Entities.JobSpecificationCategory

                                    DuplicateJobSpecificationCategory.DbContext = DbContext

                                    DuplicateJobSpecificationCategory = JobSpecificationCategory.DuplicateEntity()

                                    DuplicateJobSpecificationCategory.JobSpecificationTypeCode = JobSpecificationType.Code

                                    If AdvantageFramework.Database.Procedures.JobSpecificationCategory.Insert(DbContext, DuplicateJobSpecificationCategory) Then

                                        JobSpecificationFields = AdvantageFramework.Database.Procedures.JobSpecificationField.LoadByJobSpecificationCategoryID(DbContext, JobSpecificationCategory.ID).ToList

                                        For Each JobSpecificationField In JobSpecificationFields.OrderBy(Function(Entity) Entity.SequenceNumber).ToList

                                            DuplicateJobSpecificationField = New AdvantageFramework.Database.Entities.JobSpecificationField

                                            DuplicateJobSpecificationField.DbContext = DbContext

                                            DuplicateJobSpecificationField = JobSpecificationField.DuplicateEntity()

                                            DuplicateJobSpecificationField.Name = JobSpecificationField.Name
                                            DuplicateJobSpecificationField.JobSpecificationCategoryID = DuplicateJobSpecificationCategory.ID
                                            DuplicateJobSpecificationField.JobSpecificationTypeCode = JobSpecificationType.Code

                                            AdvantageFramework.Database.Procedures.JobSpecificationField.Insert(DbContext, DuplicateJobSpecificationField)

                                        Next

                                    End If

                                Next

                            Else

                                JobSpecificationCategory = New AdvantageFramework.Database.Entities.JobSpecificationCategory

                                JobSpecificationCategory.DbContext = DbContext
                                JobSpecificationCategory.Description = "General Information"
                                JobSpecificationCategory.JobSpecificationTypeCode = JobSpecificationType.Code
                                JobSpecificationCategory.IsInactive = 0

                                AdvantageFramework.Database.Procedures.JobSpecificationCategory.Insert(DbContext, JobSpecificationCategory)

                            End If

                            _JobSpecificationTypeCode = JobSpecificationType.Code

                            Me.DialogResult = System.Windows.Forms.DialogResult.OK
                            Me.Close()

                        End If

                    End Using

                Catch ex As Exception

                End Try

                Me.CloseWaitForm()

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace
