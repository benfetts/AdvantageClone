Namespace Importing.Presentation

    Public Class ImportTemplateCopyDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _TemplateID As Short = 0
        Private _ImportTemplateType As Short = 0
        Private _NewTemplateID As Short = 0

#End Region

#Region " Properties "

        Public ReadOnly Property NewTemplateID As Short
            Get
                NewTemplateID = _NewTemplateID
            End Get
        End Property

#End Region

#Region " Methods "

        Private Sub New(ByVal TemplateID As Short, ByVal ImportTemplateType As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _TemplateID = TemplateID
            _ImportTemplateType = ImportTemplateType

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal TemplateID As Short, ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef NewTemplateID As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportTemplateCopyDialog As AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog = Nothing

            ImportTemplateCopyDialog = New AdvantageFramework.Importing.Presentation.ImportTemplateCopyDialog(TemplateID, ImportTemplateType)

            ShowFormDialog = ImportTemplateCopyDialog.ShowDialog()

            NewTemplateID = ImportTemplateCopyDialog.NewTemplateID

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportTemplateCopyDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            CheckBoxForm_UseSameRecordSource.Checked = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ComboBoxForm_Template.DataSource = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, _ImportTemplateType).ToList

                ComboBoxForm_Template.SetRequired(True)

                TextBoxForm_NewTemplateName.SetPropertySettings(AdvantageFramework.Database.Entities.ImportTemplate.Properties.Name)

            End Using

            ComboBoxForm_Template.SelectedValue = _TemplateID

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Create_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Create.Click

            Dim ErrorMessage As String = ""
            Dim TemplateName As String = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    TemplateName = TextBoxForm_NewTemplateName.Text.Trim

                    TemplateName = TemplateName.Replace("'", "''")

                    If AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportType(DbContext, _ImportTemplateType).Where(Function(T) T.Name = TemplateName).Any = False Then

                        _NewTemplateID = DbContext.Database.SqlQuery(Of Short)(String.Format("EXEC [advsp_import_template_copy] {0}, '{1}', '{2}', {3}",
                                                                                                  ComboBoxForm_Template.SelectedValue, Me.Session.UserCode, TemplateName,
                                                                                                  If(CheckBoxForm_UseSameRecordSource.Checked, 1, 0))).FirstOrDefault

                        Me.DialogResult = Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("A template by the name of '" & TemplateName & "' exists.", WinForm.MessageBox.MessageBoxButtons.OK, "Template Not Copied", Windows.Forms.MessageBoxIcon.Error)

                    End If

                End Using

            Else

                For Each LastFailedValidationResult In Me.SuperValidator.LastFailedValidationResults.ToList

                    ErrorMessage &= LastFailedValidationResult.Validator.ErrorMessage & vbCrLf

                Next

                AdvantageFramework.WinForm.MessageBox.Show(ErrorMessage)

            End If

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel

        End Sub

#End Region

#End Region

    End Class

End Namespace