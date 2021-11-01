Namespace Security.Setup.Presentation

    Public Class ModuleEditDialog

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ParentModuleCode As String = ""
        Private _SortOrder As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New(ByVal ParentModuleCode As String, ByVal SortOrder As Integer)

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            _ParentModuleCode = ParentModuleCode
            _SortOrder = SortOrder

        End Sub
        Private Function ConvertToBit(ByVal BooleanValue As Boolean) As Integer

            If BooleanValue Then

                ConvertToBit = 1

            Else

                ConvertToBit = 0

            End If

        End Function

#Region "  Show Form Methods "

        Public Shared Function ShowFormDialog(ByVal ParentModuleCode As String, ByVal SortOrder As Integer) As System.Windows.Forms.DialogResult

            'objects
            Dim ModuleEditDialog As ModuleEditDialog = Nothing

            ModuleEditDialog = New ModuleEditDialog(ParentModuleCode, SortOrder)

            ShowFormDialog = ModuleEditDialog.ShowDialog()

        End Function

#End Region

#Region "  Form Event Handlers "

        Private Sub ModuleEditDialog_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing

            TextBoxModuleInformation_Description.SetPropertySettings(AdvantageFramework.Security.Database.Entities.Module.Properties.Description)
            TextBoxModuleInformation_ImageName.SetPropertySettings(AdvantageFramework.Security.Database.Entities.ModuleInformation.Properties.ImageName)

            TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_"

            ButtonForm_Add.Visible = True
            Me.Text = "Add Module"

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Application In AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext)

                    Node = New DevComponents.AdvTree.Node

                    Node.CheckBoxVisible = True

                    Node.Text = Application.Name
                    Node.Tag = Application.ID

                    AdvTreeForm_Applications.Nodes.Add(Node)

                Next

            End Using

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonForm_Add_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Add.Click

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim HasAtleastOneApplicationChecked As Boolean = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If TextBoxModuleInformation_Description.Text <> "" Then

                    For Each Node In AdvTreeForm_Applications.Nodes

                        If Node.Checked Then

                            HasAtleastOneApplicationChecked = True
                            Exit For

                        End If

                    Next

                    If HasAtleastOneApplicationChecked Then

                        For Each Node In AdvTreeForm_Applications.Nodes

                            If Node.Checked Then

                                SecurityDbContext.Database.ExecuteSqlCommand("EXEC [dbo].[advsp_sec_module_create] " & Node.Tag & ", '" & TextBoxModuleInformation_Code.Text & "', '" & TextBoxModuleInformation_Description.Text & "', " _
                                                                                                                  & ConvertToBit(CheckBoxModuleInformation_IsInactive.Checked) & ", " & ConvertToBit(CheckBoxModuleInformation_IsMenuItem.Checked) & ", " & ConvertToBit(CheckBoxModuleInformation_IsCategory.Checked) & ", " _
                                                                                                                  & ConvertToBit(CheckBoxModuleInformation_IsApplication.Checked) & ", " & ConvertToBit(CheckBoxModuleInformation_IsReport.Checked) & ", " & ConvertToBit(CheckBoxModuleInformation_IsDesktopObject.Checked) & ", " _
                                                                                                                  & ConvertToBit(CheckBoxModuleInformation_IsDashboardQuery.Checked) & ", '" & _ParentModuleCode & "', '" & TextBoxModuleInformation_ImageName.Text & "', " _
                                                                                                                  & _SortOrder & ", 0, '', '', '', '', '', '', '', 0, 0, '', 0, '', '', '', '', '', 0")


                            End If

                        Next

                        Me.DialogResult = System.Windows.Forms.DialogResult.OK
                        Me.Close()

                    Else

                        AdvantageFramework.WinForm.MessageBox.Show("Please select an application to add a module.")

                    End If

                Else

                    AdvantageFramework.WinForm.MessageBox.Show("Please enter a description.")

                End If

            End Using

        End Sub
        Private Sub ButtonForm_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonForm_Cancel.Click

            Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.Close()

        End Sub
        Private Sub TextBoxModuleInformation_Description_TextChanged(sender As Object, e As System.EventArgs) Handles TextBoxModuleInformation_Description.TextChanged

            If _ParentModuleCode = AdvantageFramework.Security.Modules.Desktop_ReportWriter_AdvancedReportWriterDataSets.ToString Then

                TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_" & TextBoxModuleInformation_Description.Text.Replace(" ", "") & "ARWRPT"

            ElseIf _ParentModuleCode = AdvantageFramework.Security.Modules.Desktop_ReportWriter_DynamicReportDataSets.ToString Then

                TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_" & TextBoxModuleInformation_Description.Text.Replace(" ", "") & "DRPT"

            ElseIf _ParentModuleCode.Contains("DesktopObjects") Then

                TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_" & TextBoxModuleInformation_Description.Text.Replace(" ", "") & "DO"

            ElseIf _ParentModuleCode.Contains("Reports") Then

                TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_" & TextBoxModuleInformation_Description.Text.Replace(" ", "") & "RPT"

            Else

                TextBoxModuleInformation_Code.Text = _ParentModuleCode & "_" & TextBoxModuleInformation_Description.Text.Replace(" ", "")

            End If
            
        End Sub
        Private Sub CheckBoxModuleInformation_IsCategory_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsCategory.CheckedChanged

            If CheckBoxModuleInformation_IsCategory.Checked Then

                CheckBoxModuleInformation_IsApplication.Checked = False
                CheckBoxModuleInformation_IsDashboardQuery.Checked = False
                CheckBoxModuleInformation_IsDesktopObject.Checked = False
                CheckBoxModuleInformation_IsReport.Checked = False

                CheckBoxModuleInformation_IsApplication.Enabled = False
                CheckBoxModuleInformation_IsDashboardQuery.Enabled = False
                CheckBoxModuleInformation_IsDesktopObject.Enabled = False
                CheckBoxModuleInformation_IsReport.Enabled = False

            Else

                CheckBoxModuleInformation_IsApplication.Enabled = True
                CheckBoxModuleInformation_IsDashboardQuery.Enabled = True
                CheckBoxModuleInformation_IsDesktopObject.Enabled = True
                CheckBoxModuleInformation_IsReport.Enabled = True

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsApplication_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsApplication.CheckedChanged, CheckBoxModuleInformation_IsDashboardQuery.CheckedChanged, CheckBoxModuleInformation_IsDesktopObject.CheckedChanged, CheckBoxModuleInformation_IsReport.CheckedChanged

            If CheckBoxModuleInformation_IsApplication.Checked OrElse CheckBoxModuleInformation_IsDashboardQuery.Checked OrElse _
                    CheckBoxModuleInformation_IsDesktopObject.Checked OrElse CheckBoxModuleInformation_IsReport.Checked Then

                CheckBoxModuleInformation_IsCategory.Checked = False

                CheckBoxModuleInformation_IsCategory.Enabled = False

            Else

                CheckBoxModuleInformation_IsCategory.Enabled = True

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace
