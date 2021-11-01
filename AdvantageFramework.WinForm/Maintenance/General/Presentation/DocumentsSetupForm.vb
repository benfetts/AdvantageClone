Imports System.Drawing
Imports DevComponents.DotNetBar
Imports DevExpress.XtraGrid.Views.Base

Namespace Maintenance.General.Presentation

    Public Class DocumentsSetupForm

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        'Private _LimitAPTransactionsOptionEnabled As Boolean = False
        'Private _CreateInterCompanyTransactionOptionEnabled As Boolean = False
        Private _Label As AdvantageFramework.Database.Entities.Label = Nothing

#End Region

#Region " Properties "


#End Region

#Region " Methods "

        Private Sub New()

            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
        Private Sub LoadDivisionProductTree(Optional ByVal LabelID As Integer = 0)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Label)
            Dim node As Telerik.WinControls.UI.RadTreeNode = Nothing

            RadTreeViewRightSection_DivisionProducts.Nodes.Clear()

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                If Me.CheckBoxOptions_ShowInactive.Checked = True Then
                    list = AdvantageFramework.Database.Procedures.Label.Load(DataContext).ToList()
                Else
                    list = AdvantageFramework.Database.Procedures.Label.LoadActive(DataContext).ToList()
                End If

                RadTreeViewRightSection_DivisionProducts.DisplayMember = "Name"
                RadTreeViewRightSection_DivisionProducts.ChildMember = "ID"
                RadTreeViewRightSection_DivisionProducts.ValueMember = "ID"
                RadTreeViewRightSection_DivisionProducts.ParentMember = "ParentID"

                RadTreeViewRightSection_DivisionProducts.DataSource = list

            End Using

            If RadTreeViewRightSection_DivisionProducts.Nodes.Count > 0 Then

                RadTreeViewRightSection_DivisionProducts.ExpandAll()

            End If

        End Sub
        Private Sub LoadGrid()

            Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dim list As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType)

                'If Me.CheckBoxShowInactive.Checked = True Then

                ''list = AdvantageFramework.Database.Procedures.DocumentType.Load(dc).Where(Function(DocumentType) DocumentType.ID > 6).ToList()
                list = AdvantageFramework.Database.Procedures.DocumentType.Load(dc).ToList()

                'Else

                'list = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(dc).ToList()

                'End If

                Me.DataGridViewForm_Types.DataSource = list

            End Using

            DataGridViewForm_Types.CurrentView.BestFitColumns()

            DataGridViewForm_Types.Columns(0).Visible = False

        End Sub
        Private Sub LoadColors()

            DevCompColor.CustomStandardColors = New ColorItem()() _
           {
              New ColorItem() _
              {
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFCDD2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#F8BBD0")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#E1BEE7")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#CE93D8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#D1C4E9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#C5CAE9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#BBDEFB")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B3E5FC")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B2EBF2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B2DFDB")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#C8E6C9")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#DCEDC8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#F0F4C3")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFF9C4")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFECB3")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFE0B2")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFCCBC")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#D7CCC8")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#BDBDBD")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#B0BEC5")),
                 New ColorItem("", "", System.Drawing.ColorTranslator.FromHtml("#FFFFFF"))}}


        End Sub
        Private Sub LoadLabelData(ByVal LabelID As Integer)

            Dim list As AdvantageFramework.Database.Entities.Label

            Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                list = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(DataContext, LabelID)
                TextBoxLabelInformation_Name.Text = list.Name
                TextBoxLabelInformation_Description.Text = list.Description
                CheckBoxOptions_LabelInactive.Checked = IIf(list.IsInactive = 0, True, False)
                DevCompColor.SelectedColor = System.Drawing.ColorTranslator.FromHtml(list.HexColor)
                Me.PictureBox1.BackColor = System.Drawing.ColorTranslator.FromHtml(list.HexColor)

            End Using

            _Label = list

        End Sub
        Private Sub ClearData()
            TextBoxLabelInformation_Name.Text = ""
            TextBoxLabelInformation_Description.Text = ""
            CheckBoxOptions_LabelInactive.Checked = False
            DevCompColor.SelectedColor = Nothing
            Me.PictureBox1.BackColor = Nothing
        End Sub
        Private Function CheckForUnsavedChanges() As Boolean

            'objects
            Dim IsOkay As Boolean = True

            If Me.CheckUserEntryChangedSetting Then

                If AdvantageFramework.WinForm.MessageBox.Show("You have unsaved changes. Do you want to save your changes?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                    IsOkay = Me.Validator

                    If IsOkay Then

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.Saving, "Saving...")

                        Try

                            If TabItemDocumentsSetup_Labels.IsSelected Then

                                Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                                If _Label.ID > 0 Then
                                    Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                                        Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, _Label.ID)

                                        If Label IsNot Nothing Then

                                            Label.Name = Me.TextBoxLabelInformation_Name.Text.Trim()
                                            Label.Description = Me.TextBoxLabelInformation_Description.Text.Trim()
                                            Label.HexColor = System.Drawing.ColorTranslator.ToHtml(DevCompColor.SelectedColor)
                                            Label.IsInactive = Not Me.CheckBoxOptions_LabelInactive.Checked

                                            If AdvantageFramework.Database.Procedures.Label.Update(dc, Label) = True Then

                                                ClearChanged()

                                            Else

                                                AdvantageFramework.WinForm.MessageBox.Show("Could not update label")

                                            End If

                                        End If
                                    End Using
                                Else
                                    ClearChanged()
                                End If

                            End If

                        Catch ex As Exception
                            AdvantageFramework.WinForm.MessageBox.Show(ex.Message)
                            IsOkay = False
                        End Try

                        Me.SetFormActionAndShowWaitForm(AdvantageFramework.WinForm.Presentation.FormActions.None)

                        Me.ClearValidations()

                    End If

                End If

            End If

            CheckForUnsavedChanges = IsOkay

        End Function

        Private Sub EnableOrDisableActions()

            If TabItemDocumentsSetup_Types.IsSelected Then
                If DataGridViewForm_Types.IsNewItemRow Then

                    ButtonItemActions_Cancel.Enabled = True
                    ButtonItemActions_Save.Enabled = False
                    ButtonItemActions_Delete.Enabled = False

                Else

                    ButtonItemActions_Cancel.Enabled = False
                    ButtonItemActions_Save.Enabled = Me.UserEntryChanged
                    ButtonItemActions_Delete.Enabled = DataGridViewForm_Types.HasASelectedRow

                End If
            End If

            If TabItemDocumentsSetup_Labels.IsSelected Then
                TextBoxLabelInformation_Name.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 AndAlso Me.FormShown)
                TextBoxLabelInformation_Description.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 AndAlso Me.FormShown)
                CheckBoxOptions_LabelInactive.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 AndAlso Me.FormShown)
                DevCompColor.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 AndAlso Me.FormShown)
                PictureBox1.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 AndAlso Me.FormShown)
                ButtonItemActions_Delete.Enabled = (RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0)
                ButtonItemActions_Save.Enabled = Me.UserEntryChanged
            End If

        End Sub

#Region "  Show Form Methods "

        Public Shared Sub ShowForm()

            'objects
            Dim DocumentsSetupForm As AdvantageFramework.Maintenance.General.Presentation.DocumentsSetupForm = Nothing

            DocumentsSetupForm = New AdvantageFramework.Maintenance.General.Presentation.DocumentsSetupForm()

            DocumentsSetupForm.Show()

        End Sub

#End Region

#Region "  Form Event Handlers "

        Private Sub DocumentsSetupForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

            ButtonItemActions_Add.Image = AdvantageFramework.My.Resources.AddImage
            ButtonItemActions_Save.Image = AdvantageFramework.My.Resources.SaveImage
            ButtonItemActions_Delete.Image = AdvantageFramework.My.Resources.DeleteImage
            ButtonItemActions_Cancel.Image = AdvantageFramework.My.Resources.CancelImage
            ButtonItemActions_Export.Image = AdvantageFramework.My.Resources.DatabaseExportImage

            LoadGrid()
            LoadColors()
            LoadDivisionProductTree()

            DataGridViewForm_Types.CurrentView.AFActiveFilterString = "[IsInactive] = False"

            If DataGridViewForm_Types.Columns("IsInactive") IsNot Nothing Then

                DataGridViewForm_Types.Columns("IsInactive").Caption = "Is Inactive"

            End If

        End Sub
        Private Sub DocumentsSetupForm_ClearChangedEvent() Handles Me.ClearChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub
        Private Sub DocumentsSetupForm_UserEntryChangedEvent(ByVal Control As WinForm.Presentation.Controls.Interfaces.IUserEntryControl) Handles Me.UserEntryChangedEvent

            ButtonItemActions_Save.Enabled = Me.UserEntryChanged

        End Sub

#End Region

#Region "  Control Event Handlers "

        Private Sub TabControlForm_AgencySetup_SelectedTabChanging(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangingEventArgs) Handles TabControlForm_AgencySetup.SelectedTabChanging

            Me.SuspendedForLoading = True

            If Me.FormShown AndAlso Me.FormAction = WinForm.Presentation.FormActions.None Then

            End If

        End Sub
        Private Sub TabControlForm_AgencySetup_SelectedTabChanged(ByVal sender As Object, ByVal e As DevComponents.DotNetBar.TabStripTabChangedEventArgs) Handles TabControlForm_AgencySetup.SelectedTabChanged

            Me.SuspendedForLoading = False

            If TabItemDocumentsSetup_Types.IsSelected Then
                ButtonItemActions_Add.Enabled = False
            End If

            If TabItemDocumentsSetup_Labels.IsSelected Then
                ButtonItemActions_Add.Enabled = True
            End If

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Save_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Save.Click

            'objects
            Dim DocumentTypes As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType) = Nothing
            Dim hasDefault As Boolean = False
            Dim count As Integer = 0

            If TabItemDocumentsSetup_Types.IsSelected Then

                If DataGridViewForm_Types.HasRows Then

                    DataGridViewForm_Types.CurrentView.CloseEditorForUpdating()

                    DocumentTypes = DataGridViewForm_Types.GetAllRowsDataBoundItems.OfType(Of AdvantageFramework.Database.Entities.DataContextDocumentType)().ToList

                    For Each doctype In DocumentTypes
                        If doctype.IsDefault Then
                            count += 1
                        End If
                    Next

                    If count > 1 Then
                        AdvantageFramework.WinForm.MessageBox.Show("Only one default Type is allowed.")
                        Exit Sub
                    End If

                    Me.ShowWaitForm()
                    Me.ShowWaitForm("Saving...")
                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = True

                    Try

                        Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For Each DocumentType In DocumentTypes

                                AdvantageFramework.Database.Procedures.DocumentType.Update(dc, DocumentType)

                            Next

                        End Using

                    Catch ex As Exception

                    End Try

                    AdvantageFramework.WinForm.MessageBox.SuppressMessageBox = False

                    Try

                        DataGridViewForm_Types.ValidateAllRowsAndClearChanged(True)

                    Catch ex As Exception

                    End Try

                    Me.CloseWaitForm()

                End If

            End If

            If TabItemDocumentsSetup_Labels.IsSelected Then

                Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                If Me.RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 Then
                    Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                        Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me.RadTreeViewRightSection_DivisionProducts.SelectedNode.Value)

                        If Label IsNot Nothing Then

                            Label.Name = Me.TextBoxLabelInformation_Name.Text.Trim()
                            Label.Description = Me.TextBoxLabelInformation_Description.Text.Trim()
                            Label.HexColor = System.Drawing.ColorTranslator.ToHtml(DevCompColor.SelectedColor)
                            Label.IsInactive = Not Me.CheckBoxOptions_LabelInactive.Checked

                            If AdvantageFramework.Database.Procedures.Label.Update(dc, Label) = True Then

                                ClearChanged()

                            Else

                                AdvantageFramework.WinForm.MessageBox.Show("Could not update label")

                            End If

                        End If
                    End Using
                Else
                    ClearChanged()
                End If

            End If

            LoadGrid()

            EnableOrDisableActions()



        End Sub
        Private Sub ButtonItemActions_Add_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Add.Click

            'If Me.CheckBoxOptions_TopLevelLabel.Checked = False AndAlso Me.RadTreeViewLabels.SelectedNode Is Nothing Then

            '    Me.ShowMessage("Please select a parent label or check the ""\Top Level""\ checkbox")
            '    Exit Sub

            'End If

            Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

            If Me.RadTreeViewRightSection_DivisionProducts.SelectedNodes.Count > 0 Then
                Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                    Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me.RadTreeViewRightSection_DivisionProducts.SelectedNode.Value)
                End Using
            End If

            If AdvantageFramework.Maintenance.General.Presentation.DocumentsEditDialog.ShowFormDialog(Label) = System.Windows.Forms.DialogResult.OK Then

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.Adding

                Try

                    LoadGrid()
                    LoadColors()
                    LoadDivisionProductTree()

                Catch ex As Exception

                End Try

                Me.FormAction = AdvantageFramework.WinForm.Presentation.FormActions.None

            End If
        End Sub
        Private Sub ButtonItemActions_Delete_Click(sender As Object, e As EventArgs) Handles ButtonItemActions_Delete.Click

            Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dim Label As AdvantageFramework.Database.Entities.Label = Nothing
                Dim DocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType


                If TabItemDocumentsSetup_Types.IsSelected Then

                    If DataGridViewForm_Types.HasASelectedRow Then
                        If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                            DocumentType = DataGridViewForm_Types.GetFirstSelectedRowDataBoundItem

                            If DocumentType IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.DocumentType.Delete(dc, DocumentType) = False Then

                                    'AdvantageFramework.WinForm.MessageBox.Show("Row failed to delete.")

                                Else

                                    LoadGrid()
                                    LoadDivisionProductTree()

                                End If

                            End If

                        End If

                    End If

                End If

                If TabItemDocumentsSetup_Labels.IsSelected Then

                    If AdvantageFramework.Navigation.ShowMessageBox("Are you sure you want to delete?", WinForm.MessageBox.MessageBoxButtons.YesNo) = WinForm.MessageBox.DialogResults.Yes Then

                        Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me.RadTreeViewRightSection_DivisionProducts.SelectedNode.Value)

                        If Label IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.Label.Delete(dc, Label) = True Then

                                LoadGrid()
                                LoadDivisionProductTree()
                                ClearData()
                                RadTreeViewRightSection_DivisionProducts.ClearSelection()
                                ClearChanged()
                                EnableOrDisableActions()
                                TextBoxLabelInformation_Name.Enabled = False
                                TextBoxLabelInformation_Description.Enabled = False
                                CheckBoxOptions_LabelInactive.Enabled = False
                                DevCompColor.Enabled = False
                                PictureBox1.Enabled = False

                            Else

                                'AdvantageFramework.WinForm.MessageBox.Show("Could not delete label")

                            End If

                        End If

                    End If

                End If

            End Using
        End Sub
        Private Sub CheckBoxOptions_ShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxOptions_ShowInactive.CheckedChanged

            'If CheckForUnsavedChanges() Then
            LoadGrid()
            LoadDivisionProductTree()
            ClearData()
            ClearChanged()
            EnableOrDisableActions()
            'End If

        End Sub

        Private Sub RadTreeViewRightSection_DivisionProducts_Click(sender As Object, e As EventArgs) Handles RadTreeViewRightSection_DivisionProducts.NodeCheckedChanging
        End Sub

        Private Sub RadTreeViewRightSection_DivisionProducts_NodeMouseClick(sender As Object, e As Telerik.WinControls.UI.RadTreeViewEventArgs) Handles RadTreeViewRightSection_DivisionProducts.NodeMouseClick

            If CheckForUnsavedChanges() Then

                Me.LoadLabelData(Me.RadTreeViewRightSection_DivisionProducts.SelectedNode.Value)

                Me.ClearChanged()

                EnableOrDisableActions()

                If RadTreeViewRightSection_DivisionProducts.Nodes.Count > 0 Then

                    RadTreeViewRightSection_DivisionProducts.ExpandAll()

                End If

            End If


        End Sub

        Private Sub DataGridViewForm_Types_AddNewRowEvent(RowObject As Object) Handles DataGridViewForm_Types.AddNewRowEvent
            'objects
            Dim DocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing
            Dim DocumentTypes As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType) = Nothing
            Dim hasDefault As Boolean = False

            If TypeOf RowObject Is AdvantageFramework.Database.Entities.DataContextDocumentType Then

                Me.ShowWaitForm("Processing...")

                DocumentType = RowObject

                If DocumentType IsNot Nothing Then

                    Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                        DocumentType.DataContext = DataContext

                        'DocumentType.IsInactive = If(DocumentType.IsInactive Is Nothing, 1, 0)

                        DocumentTypes = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(DataContext).ToList

                        For Each doctype In DocumentTypes
                            If doctype.IsDefault Then
                                hasDefault = True
                                Exit For
                            End If
                        Next

                        If DocumentType.IsDefault And hasDefault Then
                            AdvantageFramework.WinForm.MessageBox.Show("Only one default Type is allowed.")
                            DocumentType.IsDefault = False
                            If AdvantageFramework.Database.Procedures.DocumentType.Insert(DataContext, DocumentType) = False Then
                                LoadGrid()
                            End If
                        Else
                            If AdvantageFramework.Database.Procedures.DocumentType.Insert(DataContext, DocumentType) = False Then
                                LoadGrid()
                            End If
                        End If

                    End Using

                End If

                Me.CloseWaitForm()

            End If
        End Sub
        Private Sub DataGridViewForm_Types_InitNewRowEvent(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs) Handles DataGridViewForm_Types.InitNewRowEvent

            EnableOrDisableActions()

        End Sub
        Private Sub DataGridViewForm_Types_SelectionChangedEvent(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridViewForm_Types.SelectionChangedEvent

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Cancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Cancel.Click

            DataGridViewForm_Types.CancelNewItemRow()

            EnableOrDisableActions()

        End Sub
        Private Sub ButtonItemActions_Export_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonItemActions_Export.Click

            Dim DataTable As DataTable = Nothing
            Dim NewDataRow As DataRow = Nothing

            Using dc = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)
                If TabItemDocumentsSetup_Types.IsSelected Then
                    DataGridViewForm_Types.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))
                End If

                If TabItemDocumentsSetup_Labels.IsSelected Then

                    DataTable = New DataTable

                    DataTable.Columns.Add("Name")
                    DataTable.Columns.Add("Active")

                    Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Label)
                    If Me.CheckBoxOptions_ShowInactive.Checked = True Then
                        list = AdvantageFramework.Database.Procedures.Label.Load(dc).ToList()
                    Else
                        list = AdvantageFramework.Database.Procedures.Label.LoadActive(dc).ToList()
                    End If

                    If list IsNot Nothing AndAlso list.Count > 0 Then

                        For Each Label As AdvantageFramework.Database.Entities.Label In list

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = Label.Name

                            If Label.IsInactive = 1 Then

                                NewDataRow(1) = "NO"

                            Else

                                NewDataRow(1) = "YES"

                            End If

                        Next

                        list = Nothing

                    End If

                    Dim datagrid As New AdvantageFramework.WinForm.Presentation.Controls.DataGridView()
                    datagrid.DataSource = DataTable

                    datagrid.Print(DefaultLookAndFeel.LookAndFeel, Me.Name.Replace("SetupForm", ""))

                    'If Me.CheckBoxShowInactive.Checked = True Then
                    '    Filename = "All_Document_Labels"
                    'Else
                    '    Filename = "Active_Document_Labels"
                    'End If

                End If
            End Using

        End Sub

        'Private Sub ColorEdit_Labels_ColorChanged(sender As Object, e As EventArgs) Handles ColorEdit_Labels.ColorChanged
        '    _UserEntryChanged = True

        '    Me.RaiseUserEntryChangedEvent(Me)
        'End Sub

        Private Sub DataGridViewForm_Types_CellValueChangingEvent(ByRef Saved As Boolean, e As CellValueChangedEventArgs) Handles DataGridViewForm_Types.CellValueChangingEvent

            Dim DocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing
            Dim CurrentRowDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing
            Dim DisplayMessage As String = Nothing
            Dim IsDefault As Boolean = Nothing
            Dim HasError As Boolean = Nothing
            Dim DoSave As Boolean = Nothing

            DoSave = False
            HasError = False

            DocumentType = DataGridViewForm_Types.CurrentView.GetRow(e.RowHandle)

            If DocumentType IsNot Nothing AndAlso DocumentType.ID > 0 Then

                If e.Column.FieldName = AdvantageFramework.Database.Entities.DataContextDocumentType.Properties.IsDefault.ToString Then

                    If e.Value Then

                        Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

                            For RowHandle = 0 To DataGridViewForm_Types.CurrentView.RowCount - 1

                                CurrentRowDocumentType = DataGridViewForm_Types.CurrentView.GetRow(RowHandle)

                                If CurrentRowDocumentType IsNot DocumentType AndAlso CurrentRowDocumentType.IsDefault Then

                                    AdvantageFramework.WinForm.MessageBox.Show("Only one default Type is allowed.")

                                    'DocumentType.IsDefault = False

                                    HasError = True

                                    Exit For

                                End If

                            Next

                            If HasError Then
                                'LoadGrid()
                            End If

                        End Using

                    End If

                End If

            End If




        End Sub

        Private Sub DevCompColor_SelectedColorChanged(sender As Object, e As EventArgs) Handles DevCompColor.SelectedColorChanged

            Me.PictureBox1.BackColor = DevCompColor.SelectedColor
            _UserEntryChanged = True

            Me.RaiseUserEntryChangedEvent(Me)
        End Sub

        Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

        End Sub

#End Region

#End Region









    End Class

End Namespace