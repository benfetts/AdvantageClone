Namespace Exporting.Presentation

    Public Class ExportSystemTemplateEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ExportType As AdvantageFramework.Exporting.ExportTypes = Nothing
        Private _ExportTemplateID As Short = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByRef ExportTemplateID As Short)

            ' This call is required by the designer.
            InitializeComponent()

            _ExportType = ExportType
            _ExportTemplateID = ExportTemplateID

        End Sub
        Private Sub LoadExportDialog()

            'objects
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, _ExportTemplateID)

                If ExportTemplate IsNot Nothing Then

                    If AdvantageFramework.Database.Procedures.Agency.IsAgencyASP(DbContext) Then

                        TextBoxForm_DefaultDirectory.Text = AdvantageFramework.StringUtilities.AppendTrailingCharacter(AdvantageFramework.Database.Procedures.Agency.LoadImportPath(DbContext), "\") & "Reports"
                        TextBoxForm_DefaultDirectory.Enabled = False

                    Else

                        TextBoxForm_DefaultDirectory.Text = ExportTemplate.DefaultDirectory

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("The export template you are trying to edit does not exist anymore.")
                    Me.Close()

                End If

            End Using

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ExportType As AdvantageFramework.Exporting.ExportTypes, ByVal ExportTemplateID As Short) As System.Windows.Forms.DialogResult

            'objects
            Dim ExportSystemTemplateEditDialog As AdvantageFramework.Exporting.Presentation.ExportSystemTemplateEditDialog = Nothing

            ExportSystemTemplateEditDialog = New AdvantageFramework.Exporting.Presentation.ExportSystemTemplateEditDialog(ExportType, ExportTemplateID)

            ShowFormDialog = ExportSystemTemplateEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ExportSystemTemplateEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_DefaultDirectory.SetPropertySettings(AdvantageFramework.Database.Entities.ExportTemplate.Properties.DefaultDirectory)

                LoadExportDialog()

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim Updated As Boolean = Nothing
            Dim ErrorMessage As String = Nothing
            Dim ExportTemplate As AdvantageFramework.Database.Entities.ExportTemplate = Nothing

            If Me.Validator Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    ExportTemplate = AdvantageFramework.Database.Procedures.ExportTemplate.LoadByExportTemplateID(DbContext, _ExportTemplateID)

                    If ExportTemplate IsNot Nothing Then

                        ExportTemplate.DefaultDirectory = TextBoxForm_DefaultDirectory.GetText

                        Updated = AdvantageFramework.Database.Procedures.ExportTemplate.Update(DbContext, ExportTemplate)

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