Namespace Maintenance.ProjectManagement.Presentation

    Public Class JobCustomTabNamesEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

        End Sub

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog() As System.Windows.Forms.DialogResult

            'objects
            Dim JobCustomTabNamesEditDialog As AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobCustomTabNamesEditDialog = Nothing

            JobCustomTabNamesEditDialog = New AdvantageFramework.Maintenance.ProjectManagement.Presentation.JobCustomTabNamesEditDialog()

            ShowFormDialog = JobCustomTabNamesEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub JobCustomTabNamesEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                TextBoxForm_JobTab.SetPropertySettings(AdvantageFramework.Database.Entities.UserDefinedLabel.Properties.Label)
                TextBoxForm_JobComponentTab.SetPropertySettings(AdvantageFramework.Database.Entities.UserDefinedLabel.Properties.Label)

                UserDefinedLabel = AdvantageFramework.Database.Procedures.UserDefinedLabel.LoadByUserDefinedLabelTable(DbContext, AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_TAB.ToString)

                If UserDefinedLabel IsNot Nothing Then

                    TextBoxForm_JobTab.Text = UserDefinedLabel.Label

                End If

                UserDefinedLabel = AdvantageFramework.Database.Procedures.UserDefinedLabel.LoadByUserDefinedLabelTable(DbContext, AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_TAB.ToString)

                If UserDefinedLabel IsNot Nothing Then

                    TextBoxForm_JobComponentTab.Text = UserDefinedLabel.Label

                End If

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Update_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Update.Click

            'objects
            Dim UserDefinedLabel As AdvantageFramework.Database.Entities.UserDefinedLabel = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                UserDefinedLabel = AdvantageFramework.Database.Procedures.UserDefinedLabel.LoadByUserDefinedLabelTable(DbContext, Database.Entities.UserDefinedLabelTables.JOB_LOG_TAB.ToString)

                If UserDefinedLabel IsNot Nothing Then

                    UserDefinedLabel.Label = TextBoxForm_JobTab.Text

                    AdvantageFramework.Database.Procedures.UserDefinedLabel.Update(DbContext, UserDefinedLabel)

                Else

                    UserDefinedLabel = New AdvantageFramework.Database.Entities.UserDefinedLabel

                    UserDefinedLabel.DbContext = DbContext

                    UserDefinedLabel.AssociatedTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_LOG_TAB.ToString
                    UserDefinedLabel.Label = TextBoxForm_JobTab.Text

                    AdvantageFramework.Database.Procedures.UserDefinedLabel.Insert(DbContext, UserDefinedLabel)

                End If

                UserDefinedLabel = AdvantageFramework.Database.Procedures.UserDefinedLabel.LoadByUserDefinedLabelTable(DbContext, Database.Entities.UserDefinedLabelTables.JOB_CMP_TAB.ToString)

                If UserDefinedLabel IsNot Nothing Then

                    UserDefinedLabel.Label = TextBoxForm_JobComponentTab.Text

                    AdvantageFramework.Database.Procedures.UserDefinedLabel.Update(DbContext, UserDefinedLabel)

                Else

                    UserDefinedLabel = New AdvantageFramework.Database.Entities.UserDefinedLabel

                    UserDefinedLabel.DbContext = DbContext

                    UserDefinedLabel.AssociatedTable = AdvantageFramework.Database.Entities.UserDefinedLabelTables.JOB_CMP_TAB.ToString
                    UserDefinedLabel.Label = TextBoxForm_JobComponentTab.Text

                    AdvantageFramework.Database.Procedures.UserDefinedLabel.Insert(DbContext, UserDefinedLabel)

                End If

                Me.DialogResult = System.Windows.Forms.DialogResult.OK
                Me.Close()

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(sender As Object, e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub

#End Region

#End Region

    End Class

End Namespace