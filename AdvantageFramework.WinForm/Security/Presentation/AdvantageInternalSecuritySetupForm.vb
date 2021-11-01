Namespace Security.Presentation

    Public Class AdvantageInternalSecuritySetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Private _ModuleCodesAdded As Generic.List(Of String) = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadModules()

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                AdvTreeForm_Modules.Nodes.Clear()

                _ModuleCodesAdded = New Generic.List(Of String)

                For Each [Module] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ParentModuleID Is Nothing).OrderBy(Function(ModView) ModView.SortOrder)

                    If _ModuleCodesAdded.Contains([Module].ModuleCode) = False Then

                        Node = New DevComponents.AdvTree.Node

                        Node.Text = [Module].ModuleDescription
                        Node.Tag = [Module]

                        AdvTreeForm_Modules.Nodes.Add(Node)
                        _ModuleCodesAdded.Add([Module].ModuleCode)

                        LoadSubModule([Module], Node)

                    End If

                Next

            End Using

        End Sub
        Private Sub LoadSubModule(ByVal ModuleView As AdvantageFramework.Security.Database.Views.ModuleView, ByRef ParentNode As DevComponents.AdvTree.Node)

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each [SubModule] In SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).Where(Function(ModView) ModView.ParentModuleID = ModuleView.ModuleID).OrderBy(Function(ModView) ModView.SortOrder)

                    If _ModuleCodesAdded.Contains([SubModule].ModuleCode) = False Then

                        Node = New DevComponents.AdvTree.Node

                        Node.Text = SubModule.ModuleDescription
                        Node.Tag = SubModule

                        ParentNode.Nodes.Add(Node)
                        _ModuleCodesAdded.Add([SubModule].ModuleCode)

                        If SubModule.IsCategory Then

                            LoadSubModule(SubModule, Node)

                        End If

                    End If

                Next

            End Using

        End Sub
        Private Function ConvertToBit(ByVal BooleanValue As Boolean) As Integer

            If BooleanValue Then

                ConvertToBit = 1

            Else

                ConvertToBit = 0

            End If

        End Function
        Private Sub LoadSelectedModule()

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim Node As DevComponents.AdvTree.Node = Nothing

            If AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    GroupBoxForm_ModuleInformation.Enabled = False
                    AdvTreeForm_Applications.Enabled = False

                    CheckBoxModuleInformation_IsCategory.Checked = [Module].IsCategory

                    If CheckBoxModuleInformation_IsCategory.Checked Then

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

                    CheckBoxModuleInformation_IsApplication.Checked = [Module].IsApplication
                    CheckBoxModuleInformation_IsDashboardQuery.Checked = [Module].IsDashQuery
                    CheckBoxModuleInformation_IsDesktopObject.Checked = [Module].IsDesktopObject
                    CheckBoxModuleInformation_IsInactive.Checked = [Module].IsInactive
                    CheckBoxModuleInformation_IsMenuItem.Checked = [Module].IsMenuItem
                    CheckBoxModuleInformation_IsReport.Checked = [Module].IsReport

                    TextBoxModuleInformation_Description.Text = [Module].ModuleDescription
                    TextBoxModuleInformation_Code.Text = [Module].ModuleCode
                    TextBoxModuleInformation_ImageName.Text = [Module].ImageName

                    For Each Node In AdvTreeForm_Applications.Nodes

                        Node.Checked = False

                    Next

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        For Each ApplicationModule In AdvantageFramework.Security.Database.Procedures.ApplicationModule.Load(SecurityDbContext).Where(Function(AppMod) AppMod.ModuleID = [Module].ModuleID).ToList

                            For Each Node In AdvTreeForm_Applications.Nodes

                                If Node.Tag = ApplicationModule.ApplicationID Then

                                    Node.Checked = True
                                    Exit For

                                End If

                            Next

                        Next

                    End Using

                    GroupBoxForm_ModuleInformation.Enabled = True
                    AdvTreeForm_Applications.Enabled = True
                    ButtonItemActions_Add.Enabled = [Module].IsCategory

                Else

                    GroupBoxForm_ModuleInformation.Enabled = False
                    AdvTreeForm_Applications.Enabled = False
                    ButtonItemActions_Add.Enabled = False

                    CheckBoxModuleInformation_IsApplication.Checked = False
                    CheckBoxModuleInformation_IsCategory.Checked = False
                    CheckBoxModuleInformation_IsDashboardQuery.Checked = False
                    CheckBoxModuleInformation_IsDesktopObject.Checked = False
                    CheckBoxModuleInformation_IsInactive.Checked = False
                    CheckBoxModuleInformation_IsMenuItem.Checked = False
                    CheckBoxModuleInformation_IsReport.Checked = False

                    TextBoxModuleInformation_Description.Text = ""
                    TextBoxModuleInformation_Code.Text = ""
                    TextBoxModuleInformation_ImageName.Text = ""

                    For Each Node In AdvTreeForm_Applications.Nodes

                        Node.Checked = False

                    Next

                End If

            End If

        End Sub
        Private Function LoadModuleCode(ByRef SecurityDbContext As AdvantageFramework.Security.Database.DbContext, ByVal ModuleID As Integer) As String

            'objects
            Dim ModuleCode As String = ""
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            Try

                [Module] = SecurityDbContext.GetQuery(Of AdvantageFramework.Security.Database.Views.ModuleView).FirstOrDefault(Function(ModView) ModView.ModuleID = ModuleID)

                If [Module] IsNot Nothing Then

                    ModuleCode = [Module].ModuleCode

                End If

            Catch ex As Exception
                ModuleCode = ""
            End Try

            LoadModuleCode = ModuleCode

        End Function

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim AdvantageInternalSecuritySetupForm As AdvantageFramework.Security.Presentation.AdvantageInternalSecuritySetupForm = Nothing

            AdvantageInternalSecuritySetupForm = New AdvantageFramework.Security.Presentation.AdvantageInternalSecuritySetupForm()

            AdvantageInternalSecuritySetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub AdvantageInternalSecuritySetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            'objects
            Dim Node As DevComponents.AdvTree.Node = Nothing

            Me.ShowUnsavedChangesOnFormClosing = False

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_CreateScript.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_EncryptFile.Image = AdvantageFramework.My.Resources.ProcessImage
            ButtonItemActions_DecryptFile.Image = AdvantageFramework.My.Resources.ProcessImage

            GroupBoxForm_ModuleInformation.Enabled = False
            AdvTreeForm_Applications.Enabled = False
            ButtonItemActions_Add.Enabled = False

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                For Each Application In AdvantageFramework.Security.Database.Procedures.Application.Load(SecurityDbContext)

                    Node = New DevComponents.AdvTree.Node

                    Node.CheckBoxVisible = True

                    Node.Text = Application.Name
                    Node.Tag = Application.ID

                    AdvTreeForm_Applications.Nodes.Add(Node)

                Next

            End Using

            LoadModules()

            _ModuleCodesAdded = Nothing

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub ButtonItemActions_DecryptFile_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_DecryptFile.Click

            'objects
            Dim File As String = ""
            Dim FileText As String = ""
            Dim DecryptedFileText As String = ""

            File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen

            If My.Computer.FileSystem.FileExists(File) Then

                FileText = My.Computer.FileSystem.ReadAllText(File)

                DecryptedFileText = AdvantageFramework.Security.Encryption.Decrypt(FileText)

                My.Computer.FileSystem.WriteAllText(File, DecryptedFileText, False)

                My.Computer.FileSystem.RenameFile(File, My.Computer.FileSystem.GetFileInfo(File).Name.Replace(".advenc", ""))

            End If

        End Sub
        Private Sub ButtonItemActions_EncryptFile_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_EncryptFile.Click

            'objects
            Dim File As String = ""
            Dim FileText As String = ""
            Dim EncryptedFileText As String = ""

            File = AdvantageFramework.WinForm.Presentation.SelectFileToOpen

            If My.Computer.FileSystem.FileExists(File) Then

                FileText = My.Computer.FileSystem.ReadAllText(File)

                EncryptedFileText = AdvantageFramework.Security.Encryption.Encrypt(FileText)

                My.Computer.FileSystem.WriteAllText(File, EncryptedFileText, False)

                My.Computer.FileSystem.RenameFile(File, My.Computer.FileSystem.GetFileInfo(File).Name & ".advenc")

            End If

        End Sub
        Private Sub AdvTreeForm_Modules_AfterNodeDrop(sender As Object, e As DevComponents.AdvTree.TreeDragDropEventArgs) Handles AdvTreeForm_Modules.AfterNodeDrop

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing
            Dim Node As DevComponents.AdvTree.Node = Nothing
            Dim ModuleInformation As AdvantageFramework.Security.Database.Entities.ModuleInformation = Nothing

            If e.NewParentNode Is e.OldParentNode Then

                If e.NewParentNode IsNot Nothing Then

                    For Each Node In e.NewParentNode.Nodes

                        Try

                            [Module] = Node.Tag

                        Catch ex As Exception
                            [Module] = Nothing
                        End Try

                        If [Module] IsNot Nothing Then

                            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                                ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                                If ModuleEntity IsNot Nothing Then

                                    ModuleInformation = ModuleEntity.ModuleInformation

                                    ModuleInformation.SortOrder = Node.Index

                                    SecurityDbContext.UpdateObject(ModuleInformation)

                                    SecurityDbContext.SaveChanges()

                                End If

                            End Using

                        End If

                    Next

                End If

            Else

                AdvantageFramework.WinForm.MessageBox.Show("Can not drag and drop to other parent nodes!")

                e.Cancel = True

            End If

        End Sub
        Private Sub AdvTreeForm_Modules_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles AdvTreeForm_Modules.SelectionChanged

            LoadSelectedModule()

        End Sub
        Private Sub ButtonItemView_ExpandAll_Click(sender As System.Object, e As System.EventArgs) Handles ButtonItemView_ExpandAll.Click

            AdvTreeForm_Modules.ExpandAll()

        End Sub
        Private Sub ButtonItemView_CollapseAll_Click(sender As Object, e As System.EventArgs) Handles ButtonItemView_CollapseAll.Click

            AdvTreeForm_Modules.CollapseAll()

        End Sub
        Private Sub ButtonItemActions_CreateScript_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_CreateScript.Click

            'objects
            Dim StringBuilder As System.Text.StringBuilder = Nothing
            Dim Folder As String = ""

            Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                StringBuilder = New System.Text.StringBuilder

                For Each [Module] In SecurityDbContext.ModuleViews.OrderBy(Function(ModView) ModView.ModuleCode).ToList

                    StringBuilder.AppendLine("EXEC [dbo].[advsp_sec_module_create] " & [Module].ApplicationID & ", '" & [Module].ModuleCode & "', '" & [Module].ModuleDescription & "', " _
                                                                                     & ConvertToBit([Module].IsInactive) & ", " & ConvertToBit([Module].IsMenuItem) & ", " & ConvertToBit([Module].IsCategory) & ", " _
                                                                                     & ConvertToBit([Module].IsApplication) & ", " & ConvertToBit([Module].IsReport) & ", " & ConvertToBit([Module].IsDesktopObject) & ", " _
                                                                                     & ConvertToBit([Module].IsDashQuery) & ", '" & LoadModuleCode(SecurityDbContext, [Module].ParentModuleID.GetValueOrDefault(0)) & "', '" & [Module].ImageName & "', " _
                                                                                     & [Module].SortOrder & ", " & ConvertToBit([Module].HasCustomPermission) & ", '" _
                                                                                     & [Module].WebvantageURL & "', '" & [Module].WebvantageImagePathActive & "', '" & [Module].WebvantageImagePath & "', '" _
                                                                                     & [Module].AdvantageApplicationName & "', '" & [Module].AdvantageMenuName & "', '" & [Module].AdvantageApplicationCode & "', '" _
                                                                                     & [Module].AdvantageCommandString & "', " & [Module].AdvantageIconIndex & ", " & [Module].AdvantageAllowMultipleInstances & ", '" _
                                                                                     & [Module].DesktopObjectName & "', " & [Module].DesktopObjectSize & ", '" & [Module].ReportURL & "', '" _
                                                                                     & [Module].ReportImagePathActive & "', '" & [Module].ReportImagePath & "', '" & [Module].ReportDescription & "', '" _
                                                                                     & [Module].ReportPreviewLocation & "', " & ConvertToBit([Module].ReportIsLocked))

                Next

                If AdvantageFramework.WinForm.Presentation.BrowseForFolder(Folder) Then

                    My.Computer.FileSystem.WriteAllText(Folder & "Security Module Script.sql", StringBuilder.ToString, False)

                End If

            End Using

        End Sub
        Private Sub CheckBoxModuleInformation_IsApplication_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsApplication.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsApplication = CheckBoxModuleInformation_IsApplication.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsApplication = CheckBoxModuleInformation_IsApplication.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsDashboardQuery_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsDashboardQuery.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsDashQuery = CheckBoxModuleInformation_IsDashboardQuery.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsDashQuery = CheckBoxModuleInformation_IsDashboardQuery.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsDesktopObject_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsDesktopObject.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsDesktopObject = CheckBoxModuleInformation_IsDesktopObject.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsDesktopObject = CheckBoxModuleInformation_IsDesktopObject.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsInactive_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsInactive.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsInactive = CheckBoxModuleInformation_IsInactive.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsInactive = CheckBoxModuleInformation_IsInactive.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsMenuItem_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsMenuItem.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsMenuItem = CheckBoxModuleInformation_IsMenuItem.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsMenuItem = CheckBoxModuleInformation_IsMenuItem.Checked

                End If

            End If

        End Sub
        Private Sub CheckBoxModuleInformation_IsReport_CheckedChanged(sender As Object, e As System.EventArgs) Handles CheckBoxModuleInformation_IsReport.CheckedChanged

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                        If ModuleEntity IsNot Nothing Then

                            ModuleEntity.IsReport = CheckBoxModuleInformation_IsReport.Checked

                            SecurityDbContext.UpdateObject(ModuleEntity)

                            SecurityDbContext.SaveChanges()

                        End If

                    End Using

                    [Module].IsReport = CheckBoxModuleInformation_IsReport.Checked

                End If

            End If

        End Sub
        Private Sub TextBoxModuleInformation_Description_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxModuleInformation_Description.Validating

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    If [Module].ModuleDescription <> TextBoxModuleInformation_Description.Text Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                            If ModuleEntity IsNot Nothing Then

                                ModuleEntity.Description = TextBoxModuleInformation_Description.Text

                                SecurityDbContext.UpdateObject(ModuleEntity)

                                SecurityDbContext.SaveChanges()

                            End If

                        End Using

                        [Module].ModuleDescription = TextBoxModuleInformation_Description.Text
                        AdvTreeForm_Modules.SelectedNode.Text = TextBoxModuleInformation_Description.Text

                    End If

                End If

            End If

        End Sub
        Private Sub TextBoxModuleInformation_ImageName_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles TextBoxModuleInformation_ImageName.Validating

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ModuleEntity As AdvantageFramework.Security.Database.Entities.[Module] = Nothing
            Dim ModuleInformation As AdvantageFramework.Security.Database.Entities.ModuleInformation = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    If [Module].ImageName <> TextBoxModuleInformation_ImageName.Text Then

                        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            ModuleEntity = AdvantageFramework.Security.Database.Procedures.[Module].LoadByModuleCode(SecurityDbContext, [Module].ModuleCode)

                            If ModuleEntity IsNot Nothing Then

                                ModuleInformation = ModuleEntity.ModuleInformation

                                ModuleInformation.ImageName = TextBoxModuleInformation_ImageName.Text

                                SecurityDbContext.UpdateObject(ModuleInformation)

                                SecurityDbContext.SaveChanges()

                            End If

                        End Using

                        [Module].ImageName = TextBoxModuleInformation_ImageName.Text

                    End If

                End If

            End If

        End Sub
        Private Sub AdvTreeForm_Applications_AfterCheck(sender As Object, e As DevComponents.AdvTree.AdvTreeCellEventArgs) Handles AdvTreeForm_Applications.AfterCheck

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing
            Dim ApplicationModule As AdvantageFramework.Security.Database.Entities.ApplicationModule = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing AndAlso e.Cell.Tag IsNot Nothing AndAlso IsNumeric(e.Cell.Tag) Then

                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        If e.Cell.Checked Then

                            Try

                                AdvantageFramework.Security.Database.Procedures.ApplicationModule.Insert(SecurityDbContext, e.Cell.Tag, [Module].ModuleID, Nothing)

                            Catch ex As Exception

                            End Try

                        Else

                            For Each ApplicationModule In AdvantageFramework.Security.Database.Procedures.ApplicationModule.Load(SecurityDbContext).ToList.Where(Function(AppMod) AppMod.ApplicationID = CInt(e.Cell.Tag) AndAlso AppMod.ModuleID = [Module].ModuleID).ToList

                                AdvantageFramework.Security.Database.Procedures.ApplicationModule.Delete(SecurityDbContext, ApplicationModule)

                            Next

                        End If

                    End Using

                End If

            End If

        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As System.EventArgs) Handles ButtonItemActions_Add.Click

            'objects
            Dim [Module] As AdvantageFramework.Security.Database.Views.ModuleView = Nothing

            If GroupBoxForm_ModuleInformation.Enabled AndAlso AdvTreeForm_Modules.SelectedNode IsNot Nothing Then

                Try

                    [Module] = AdvTreeForm_Modules.SelectedNode.Tag

                Catch ex As Exception
                    [Module] = Nothing
                End Try

                If [Module] IsNot Nothing Then

                    If [Module].IsCategory Then

                        If AdvantageFramework.Security.Setup.Presentation.ModuleEditDialog.ShowFormDialog([Module].ModuleCode, AdvTreeForm_Modules.SelectedNode.Nodes.Count) = Windows.Forms.DialogResult.OK Then

                            LoadModules()

                        End If

                    End If

                End If

            End If

        End Sub

#End Region

#End Region

    End Class

End Namespace