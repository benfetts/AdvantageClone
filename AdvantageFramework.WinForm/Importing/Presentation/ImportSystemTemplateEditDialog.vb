Namespace Importing.Presentation

    Public Class ImportSystemTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes = Nothing
        Private _ImportTemplateID As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByRef ImportTemplateID As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _ImportTemplateType = ImportTemplateType
            _ImportTemplateID = ImportTemplateID

        End Sub
        Private Sub LoadImportDialog()

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing
            'Dim AgencyImportPath As String = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                    TextBoxForm_DefaultDirectory.Enabled = False

                End If

                ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportTemplateID)

                If ImportTemplate IsNot Nothing Then

                    TextBoxForm_DefaultDirectory.Text = ImportTemplate.DefaultDirectory

                    ComboBoxForm_RecordSource.SelectedValue = ImportTemplate.RecordSourceID

                    If _ImportTemplateType = ImportTemplateTypes.JournalEntry_MOGLIFACE Then

                        TextBoxForm_DefaultDirectory.Enabled = False

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The import template you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ImportTemplateType As AdvantageFramework.Importing.ImportTemplateTypes, ByVal ImportTemplateID As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim ImportSystemTemplateEditDialog As AdvantageFramework.Importing.Presentation.ImportSystemTemplateEditDialog = Nothing

            ImportSystemTemplateEditDialog = New AdvantageFramework.Importing.Presentation.ImportSystemTemplateEditDialog(ImportTemplateType, ImportTemplateID)

            ShowFormDialog = ImportSystemTemplateEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ImportSystemTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_DefaultDirectory.SetPropertySettings(AdvantageFramework.Database.Entities.ImportTemplate.Properties.DefaultDirectory)
                ComboBoxForm_RecordSource.DataSource = AdvantageFramework.Database.Procedures.RecordSource.Load(DbContext).ToList

                LoadImportDialog()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Updated As Boolean = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ImportTemplate As AdvantageFramework.Database.Entities.ImportTemplate = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ImportTemplate = AdvantageFramework.Database.Procedures.ImportTemplate.LoadByImportTemplateID(DbContext, _ImportTemplateID)

                    If ImportTemplate IsNot Nothing Then

                        ImportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText
                        ImportTemplate.RecordSourceID = ComboBoxForm_RecordSource.GetSelectedValue

                        Updated = AdvantageFramework.Database.Procedures.ImportTemplate.Update(DbContext, ImportTemplate)

                    End If

                End Using

                If Updated Then

                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()

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

#End Region

#End Region

    End Class

End Namespace