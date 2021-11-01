Namespace Reporting.Presentation

    Public Class JobVersionReportUpdateDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _UserDefinedReportType As AdvantageFramework.Reporting.UDRTypes = Reporting.UDRTypes.Dynamic
        Private _ReportID As Integer = 0
        Private _JobVersionTemplateCode As String = ""
        Private _Description As String = ""
        Private _UserDefinedReportCategoryID As Nullable(Of Integer) = 0

#End Region

#Region " Properties "

        Private ReadOnly Property JobVersionTemplateCode As String
            Get
                JobVersionTemplateCode = _JobVersionTemplateCode
            End Get
        End Property
        Private ReadOnly Property Description As String
            Get
                Description = _Description
            End Get
        End Property
        Private ReadOnly Property UserDefinedReportCategoryID As Nullable(Of Integer)
            Get
                UserDefinedReportCategoryID = _UserDefinedReportCategoryID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal ReportID As Integer, ByVal JobVersionTemplateCode As String, ByRef Description As String, ByRef UserDefinedReportCategoryID As Nullable(Of Integer), ByVal AllowReportTypeChange As Boolean)

            ' This call is required by the designer.
            InitializeComponent()

            _ReportID = ReportID
            _JobVersionTemplateCode = JobVersionTemplateCode
            _Description = Description
            _UserDefinedReportCategoryID = UserDefinedReportCategoryID
            ComboBoxForm_JobVersionTemplate.Enabled = AllowReportTypeChange

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ReportID As Integer, ByRef JobVersionTemplateCode As String, ByRef Description As String, ByRef UserDefinedReportCategoryID As Nullable(Of Integer), ByVal AllowReportTypeChange As Boolean) As System.Windows.Forms.DialogResult

            'objects
            Dim JobVersionReportUpdateDialog As AdvantageFramework.Reporting.Presentation.JobVersionReportUpdateDialog = Nothing

            JobVersionReportUpdateDialog = New AdvantageFramework.Reporting.Presentation.JobVersionReportUpdateDialog(ReportID, JobVersionTemplateCode, Description, UserDefinedReportCategoryID, AllowReportTypeChange)

            ShowFormDialog = JobVersionReportUpdateDialog.ShowDialog()

            If ShowFormDialog = Windows.Forms.DialogResult.OK Then

                JobVersionTemplateCode = JobVersionReportUpdateDialog.JobVersionTemplateCode
                Description = JobVersionReportUpdateDialog.Description
                UserDefinedReportCategoryID = JobVersionReportUpdateDialog.UserDefinedReportCategoryID

            End If

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobVersionReportUpdateDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim DynamicReport As AdvantageFramework.Reporting.Database.Entities.DynamicReport = Nothing

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ComboBoxForm_JobVersionTemplate.DataSource = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadAllActive(DbContext)
                    ComboBoxForm_JobVersionTemplate.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.TemplateCode)
                    ComboBoxForm_JobVersionTemplate.SetRequired(True)

                    TextBoxForm_Description.SetPropertySettings(AdvantageFramework.Reporting.Database.Entities.DynamicReport.Properties.Description)

                    ComboBoxForm_ReportCategory.DataSource = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext)

                    If _ReportID <> 0 Then

                        ButtonForm_Add.Visible = False
                        ButtonForm_Update.Visible = True

                        DynamicReport = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByDynamicReportID(ReportingDbContext, _ReportID)

                        If DynamicReport IsNot Nothing Then

                            ComboBoxForm_JobVersionTemplate.SelectedValue = DynamicReport.TemplateCode
                            TextBoxForm_Description.Text = DynamicReport.Description
                            ComboBoxForm_ReportCategory.SelectedValue = DynamicReport.UserDefinedReportCategoryID.GetValueOrDefault(0)

                        Else

                            AdvantageFramework.WinForm.MessageBox.Show("The report you are trying to edit does not exist anymore.")
                            Me.Close()

                        End If

                    Else

                        ComboBoxForm_JobVersionTemplate.SelectedValue = _JobVersionTemplateCode

                        ButtonForm_Add.Visible = True
                        ButtonForm_Update.Visible = False

                    End If

                End Using

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Adding, "Adding...")

                Try

                    _JobVersionTemplateCode = ComboBoxForm_JobVersionTemplate.GetSelectedValue
                    _Description = TextBoxForm_Description.Text
                    _UserDefinedReportCategoryID = ComboBoxForm_ReportCategory.GetSelectedValue

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim ErrorMessage As String = ""

            If Me.Validator Then

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                Try

                    _JobVersionTemplateCode = ComboBoxForm_JobVersionTemplate.GetSelectedValue
                    _Description = TextBoxForm_Description.Text
                    _UserDefinedReportCategoryID = ComboBoxForm_ReportCategory.GetSelectedValue

                    Me.ClearChanged()

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

                Catch ex As Exception
                    AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                End Try

                Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

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

#End Region

#End Region

    End Class

End Namespace