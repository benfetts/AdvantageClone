Imports Telerik.Web.UI

Public Class Maintenance_Documents
    Inherits Webvantage.BaseChildPage

#Region " Main Page "

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    'Store viewstate in session instead of on the page...
    'This doesn't work on the base page
    Dim _pers As PageStatePersister

    Protected Overrides ReadOnly Property PageStatePersister() As PageStatePersister
        Get
            If _pers Is Nothing Then
                _pers = New SessionPageStatePersister(Me)
            End If
            Return _pers
        End Get
    End Property
    Public Property SelectedTabIndex As Integer
        Get
            If Me.RadTabStripDocumentMaintenance.SelectedIndex = Nothing Then
                Me.RadTabStripDocumentMaintenance.SelectedIndex = 0
            End If
            Return Me.RadTabStripDocumentMaintenance.SelectedIndex
        End Get
        Set(value As Integer)
            Me.RadTabStripDocumentMaintenance.SelectedIndex = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ImageButtonExport_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButtonExport.Click

        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            Dim DataTable As DataTable = Nothing
            Dim NewDataRow As DataRow = Nothing
            Dim Filename As String = ""

            Select Case Me.SelectedTabIndex
                Case 0 'Types

                    DataTable = New DataTable

                    DataTable.Columns.Add("Name")
                    DataTable.Columns.Add("Active")
                    DataTable.Columns.Add("Default")

                    Dim list As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType)

                    If Me.CheckBoxShowInactive.Checked = True Then
                        list = AdvantageFramework.Database.Procedures.DocumentType.Load(dc).ToList()
                    Else
                        list = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(dc).ToList()
                    End If

                    If list IsNot Nothing AndAlso list.Count > 0 Then

                        For Each DocType As AdvantageFramework.Database.Entities.DataContextDocumentType In list

                            NewDataRow = DataTable.Rows.Add()

                            NewDataRow(0) = DocType.Name

                            If DocType.IsInactive Is Nothing OrElse DocType.IsInactive = False Then

                                NewDataRow(1) = "YES"

                            Else

                                NewDataRow(1) = "NO"

                            End If

                            If DocType.IsDefault Is Nothing OrElse DocType.IsDefault = False Then

                                NewDataRow(2) = "NO"

                            Else

                                NewDataRow(2) = "YES"

                            End If

                        Next

                        list = Nothing

                    End If

                    If Me.CheckBoxShowInactive.Checked = True Then
                        Filename = "All_Document_Types"
                    Else
                        Filename = "Active_Document_Types"
                    End If

                    Me.DeliverGrid(DataTable, Filename)

                Case 1 'Labels

                    DataTable = New DataTable

                    DataTable.Columns.Add("Name")
                    DataTable.Columns.Add("Active")

                    Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Label)
                    If Me.CheckBoxShowInactive.Checked = True Then
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

                    If Me.CheckBoxShowInactive.Checked = True Then
                        Filename = "All_Document_Labels"
                    Else
                        Filename = "Active_Document_Labels"
                    End If

                    Me.DeliverGrid(DataTable, Filename)

            End Select

        End Using

    End Sub
    Private Sub RadTabStripDocumentMaintenance_TabClick(sender As Object, e As RadTabStripEventArgs) Handles RadTabStripDocumentMaintenance.TabClick

        Me.SelectedTabIndex = Me.RadTabStripDocumentMaintenance.SelectedIndex
        Me.SelectTab()

    End Sub

#End Region
#Region " Page "

    Private Sub Maintenance_Documents_Init(sender As Object, e As EventArgs) Handles Me.Init

        Try

            If Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Desktop_DocumentManager, True) = 1 Then

                Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_General_Documents, True)

            End If

            If Not Me.IsPostBack And Not Me.IsCallback Then

                If Me.CurrentQuerystring.GetValue("tabidx") IsNot Nothing AndAlso IsNumeric(Me.CurrentQuerystring.GetValue("tabidx")) Then

                    Me.SelectedTabIndex = CType(Me.CurrentQuerystring.GetValue("tabidx"), Integer)

                End If

                Me.SelectTab()

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub Maintenance_Documents_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.IsCallback Then


        End If

    End Sub

#End Region

    Private Sub SelectTab()

        Me.RadTabStripDocumentMaintenance.SelectedIndex = Me.SelectedTabIndex
        Me.RadMultiPageDocumentMaintenance.SelectedIndex = Me.SelectedTabIndex

        Select Case Me.SelectedTabIndex
            Case 0 'Document Types

                Me.RadGridDocumentTypes.Rebind()
                'Me.CheckBoxShowInactive.Visible = True

            Case 1 'Labels

                Me.LoadLabels()
                Me.DivEditForm.Visible = False
                'Me.CheckBoxShowInactive.Visible = False

        End Select

    End Sub

#End Region

#End Region

#Region " Types Tab "

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridDocumentTypes_CancelCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridDocumentTypes.CancelCommand

        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then

            DirectCast(EditItem.FindControl("TextBoxDescription"), TextBox).Text = ""
            DirectCast(EditItem.FindControl("CheckboxInActive"), CheckBox).Checked = False

        End If

    End Sub
    Private Sub RadGridDocumentTypes_InsertCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridDocumentTypes.InsertCommand

        Dim EditItem As GridEditableItem = CType(e.Item, GridEditableItem)
        If Not EditItem Is Nothing Then

            Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Dim NewDocumentType As New AdvantageFramework.Database.Entities.DataContextDocumentType

                NewDocumentType.Name = DirectCast(EditItem.FindControl("TextBoxDescription"), TextBox).Text.Trim()
                NewDocumentType.IsInactive = DirectCast(EditItem.FindControl("CheckboxInActive"), CheckBox).Checked
                NewDocumentType.IsDefault = DirectCast(EditItem.FindControl("RadioButtonIsDefault"), RadioButton).Checked

                If AdvantageFramework.Database.Procedures.DocumentType.Insert(dc, NewDocumentType) = False Then

                Else

                    MiscFN.ResponseRedirect("Maintenance_Documents.aspx")

                End If

            End Using

        End If

    End Sub
    Private Sub RadGridDocumentTypes_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridDocumentTypes.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = e.Item.ItemIndex
        Dim CurrentRow As Telerik.Web.UI.GridDataItem

        If index > -1 Then CurrentRow = DirectCast(RadGridDocumentTypes.Items(index), Telerik.Web.UI.GridDataItem)

        Select Case e.CommandName
            Case "SaveNewRow"

                e.Item.FireCommandEvent("PerformInsert", e)

            Case "CancelNewRow"

                e.Item.FireCommandEvent("Cancel", e)

            Case "SaveAll"

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Dim FailCount As Integer = 0

                    For Each Row As GridDataItem In Me.RadGridDocumentTypes.MasterTableView.Items

                        If Me.SaveDocumentTypeRow(dc, Row) = False Then

                            FailCount += 1

                        End If

                    Next

                    If FailCount > 0 Then

                        If FailCount = 1 Then

                            Me.ShowMessage(FailCount & " row failed to save.")

                        Else

                            Me.ShowMessage(FailCount & " rows failed to save.")

                        End If

                    Else

                        Me.RadGridDocumentTypes.Rebind()

                    End If

                End Using

            Case "SaveRow"

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Dim s As String = ""
                    If Me.SaveDocumentTypeRow(dc, CurrentRow) = False Then

                        'Me.ShowMessage("Row failed to save.")

                    Else

                        Me.RadGridDocumentTypes.Rebind()

                    End If

                End Using

            Case "DeleteRow"

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Dim DocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType

                    DocumentType = AdvantageFramework.Database.Procedures.DocumentType.LoadByDocumentTypeID(dc, CurrentRow.GetDataKeyValue("ID"))

                    If DocumentType IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.DocumentType.Delete(dc, DocumentType) = False Then

                            'Me.ShowMessage("Row failed to delete.")

                        Else

                            Me.RadGridDocumentTypes.Rebind()

                        End If

                    End If

                End Using

        End Select

    End Sub
    Private Sub RadGridDocumentTypes_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridDocumentTypes.ItemDataBound
        Select Case e.Item.ItemType
            Case GridItemType.AlternatingItem, GridItemType.Item

                Dim CurrentRow As GridDataItem = e.Item
                Dim CurrentDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = CType(e.Item.DataItem, AdvantageFramework.Database.Entities.DataContextDocumentType)

                If CurrentRow IsNot Nothing AndAlso CurrentDocumentType IsNot Nothing Then

                    Dim SaveDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivSave")
                    Dim DeleteDiv As HtmlControls.HtmlControl = CurrentRow.FindControl("DivDelete")
                    Dim TextBoxDescription As TextBox = CurrentRow.FindControl("TextBoxDescription")
                    Dim InActiveCheckbox As CheckBox = CurrentRow.FindControl("CheckboxInActive")
                    Dim IsDefaultRadioButton As RadioButton = CurrentRow.FindControl("RadioButtonIsDefault")

                    If InActiveCheckbox IsNot Nothing AndAlso CurrentDocumentType.IsInactive IsNot Nothing Then

                        InActiveCheckbox.Checked = CurrentDocumentType.IsInactive

                    End If

                    'If CurrentDocumentType.ID < 7 Then 'Core types

                    '    '    If SaveDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(SaveDiv)
                    '    If DeleteDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)
                    '    '    If TextBoxDescription IsNot Nothing Then TextBoxDescription.Enabled = False
                    '    '    If InActiveCheckbox IsNot Nothing Then InActiveCheckbox.Enabled = False

                    'End If

                    If IsDefaultRadioButton IsNot Nothing Then IsDefaultRadioButton.Attributes.Add("onclick", String.Format("selectMeOnly({0}, '{1}');", IsDefaultRadioButton.ClientID, Me.RadGridDocumentTypes.ClientID))

                    If IsDefaultRadioButton IsNot Nothing AndAlso CurrentDocumentType.IsDefault IsNot Nothing Then

                            IsDefaultRadioButton.Checked = CurrentDocumentType.IsDefault

                        End If

                        Dim DeleteImageButton As ImageButton = CurrentRow.FindControl("ImageButtonDelete")
                        If DeleteImageButton IsNot Nothing Then DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

                    End If

        End Select

    End Sub
    Private Sub RadGridDocumentTypes_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridDocumentTypes.NeedDataSource

        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            Dim list As Generic.List(Of AdvantageFramework.Database.Entities.DataContextDocumentType)

            If Me.CheckBoxShowInactive.Checked = True Then

                list = AdvantageFramework.Database.Procedures.DocumentType.Load(dc).ToList()

            Else

                list = AdvantageFramework.Database.Procedures.DocumentType.LoadActive(dc).ToList()

            End If

            Me.RadGridDocumentTypes.DataSource = list

        End Using

        Me.RadGridDocumentTypes.MasterTableView.IsItemInserted = True
        Me.RadGridDocumentTypes.PageSize = MiscFN.LoadPageSize(Me.RadGridDocumentTypes.ID)

    End Sub
    Private Sub RadGridDocumentTypes_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridDocumentTypes.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridDocumentTypes.ID, e.NewPageSize)

    End Sub

#End Region
#Region " Page "



#End Region

    Private Function SaveDocumentTypeRow(ByRef DataContext As AdvantageFramework.Database.DataContext, ByRef Row As GridDataItem) As Boolean

        Dim Saved As Boolean = False

        Dim UpdateDocumentType As AdvantageFramework.Database.Entities.DataContextDocumentType = Nothing

        UpdateDocumentType = AdvantageFramework.Database.Procedures.DocumentType.LoadByDocumentTypeID(DataContext, Row.GetDataKeyValue("ID"))

        If UpdateDocumentType IsNot Nothing Then

            UpdateDocumentType.Name = DirectCast(Row.FindControl("TextBoxDescription"), TextBox).Text.Trim()
            UpdateDocumentType.IsInactive = DirectCast(Row.FindControl("CheckboxInActive"), CheckBox).Checked
            UpdateDocumentType.IsDefault = DirectCast(Row.FindControl("RadioButtonIsDefault"), RadioButton).Checked

            Saved = AdvantageFramework.Database.Procedures.DocumentType.Update(DataContext, UpdateDocumentType)

        End If


        Return Saved

    End Function


#End Region

#End Region

#Region " Labels Tab "

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property _SelectedLabelID As Integer
        Get
            If ViewState("_SelectedLabelID") Is Nothing Then

                ViewState("_SelectedLabelID") = 0

            End If

            Return CType(ViewState("_SelectedLabelID"), Integer)

        End Get
        Set(value As Integer)

            ViewState("_SelectedLabelID") = value

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub CheckBoxShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Select Case Me.SelectedTabIndex
            Case 0
                Me.RadGridDocumentTypes.Rebind()
            Case 1
                Me.LoadLabels()
        End Select


    End Sub
    Private Sub RadToolbarLabels_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarLabels.ButtonClick

        Select Case e.Item.Value
            Case "Save"

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                    If Me._SelectedLabelID = 0 Then

                        If Me.CheckBoxIsTopLevel.Checked = False AndAlso Me.RadTreeViewLabels.SelectedNode Is Nothing Then

                            Me.ShowMessage("Please select a parent label or check the ""\Top Level""\ checkbox")
                            Exit Sub

                        End If

                        Label = New AdvantageFramework.Database.Entities.Label

                        Label.Name = Me.TextBoxName.Text.Trim()
                        Label.Description = Me.TextBoxDescription.Text.Trim()
                        Label.HexColor = System.Drawing.ColorTranslator.ToHtml(Me.RadColorPickerLabelColor.SelectedColor)
                        Label.IsInactive = Not Me.CheckBoxIsActive.Checked
                        Label.CreatedBy = _Session.UserCode

                        If Me.RadTreeViewLabels.SelectedNode IsNot Nothing Then

                            Label.ParentID = Me.RadTreeViewLabels.SelectedNode.Value

                        End If
                        If Me.CheckBoxIsTopLevel.Checked Then

                            Label.ParentID = Nothing

                        End If

                        If AdvantageFramework.Database.Procedures.Label.Insert(dc, Label) = True Then

                            Me._SelectedLabelID = Label.ID
                            Me.LoadLabels()

                            If Me._SelectedLabelID > 0 AndAlso Me.RadTreeViewLabels.Nodes.Count > 0 Then

                                Dim SelectedNode As RadTreeNode = Me.RadTreeViewLabels.Nodes.FindNodeByValue(Me._SelectedLabelID)

                                If SelectedNode IsNot Nothing Then SelectedNode.Selected = True

                            End If

                            If Me._SelectedLabelID > 0 Then Me.LoadEditForm()

                        Else

                            'Me.ShowMessage("Could not add new label")

                        End If

                    Else

                        Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me._SelectedLabelID)

                        If Label IsNot Nothing Then

                            Label.Name = Me.TextBoxName.Text.Trim()
                            Label.Description = Me.TextBoxDescription.Text.Trim()
                            Label.HexColor = System.Drawing.ColorTranslator.ToHtml(Me.RadColorPickerLabelColor.SelectedColor)
                            Label.IsInactive = Not Me.CheckBoxIsActive.Checked

                            If AdvantageFramework.Database.Procedures.Label.Update(dc, Label) = True Then

                                Me.LoadLabels()
                                If Me._SelectedLabelID > 0 Then Me.LoadEditForm()

                            Else

                                'Me.ShowMessage("Could not update label")

                            End If

                        End If

                    End If

                End Using

            Case "New"

                Me.DivEditForm.Visible = True
                Me.ClearEditForm()
                Me._SelectedLabelID = 0
                Me.DivTopLevel.Visible = True
                Me.LabelFormTitle.Text = "New"
                Me.RadToolbarLabels.FindItemByValue("Refresh").Visible = False
                Me.RadToolbarLabels.FindItemByValue("Delete").Visible = False
                ''Me.RadToolbarLabels.FindItemByValue("LastSeparator").Visible = False
                Me.RadToolbarLabels.FindItemByValue("Cancel").Visible = True

            Case "Cancel"

                Me.DivEditForm.Visible = False
                Me.ClearEditForm()
                Me._SelectedLabelID = 0
                Me.DivTopLevel.Visible = False
                Me.LabelFormTitle.Text = "Edit"
                Me.RadToolbarLabels.FindItemByValue("Refresh").Visible = True
                Me.RadToolbarLabels.FindItemByValue("Delete").Visible = True
                ''Me.RadToolbarLabels.FindItemByValue("LastSeparator").Visible = True
                Me.RadToolbarLabels.FindItemByValue("Cancel").Visible = False

            Case "Delete"

                Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                    Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me._SelectedLabelID)

                    If Label IsNot Nothing Then

                        If AdvantageFramework.Database.Procedures.Label.Delete(dc, Label) = True Then

                            Me.ClearEditForm()
                            Me.DivEditForm.Visible = False
                            Me.LoadLabels()

                        Else

                            'Me.ShowMessage("Could not delete label")

                        End If

                    End If

                End Using

            Case "Refresh"

                Me.LoadLabels()

        End Select

    End Sub

    Private Sub RadTreeViewLabels_NodeClick(sender As Object, e As RadTreeNodeEventArgs) Handles RadTreeViewLabels.NodeClick

        Me._SelectedLabelID = e.Node.Value
        Me.LoadEditForm()

    End Sub
    Private Sub RadTreeViewLabels_NodeDataBound(sender As Object, e As RadTreeNodeEventArgs) Handles RadTreeViewLabels.NodeDataBound

        Dim Label As AdvantageFramework.Database.Entities.Label = e.Node.DataItem

        If Label IsNot Nothing Then

            e.Node.ToolTip = Label.Description
            If Label.IsInactive IsNot Nothing And Label.IsInactive = 1 Then
                e.Node.Checked = False
            Else
                e.Node.Checked = True
            End If

        End If

    End Sub

#End Region
#Region " Page "


#End Region

    Private Sub ClearEditForm()

        Me.TextBoxName.Text = ""
        Me.TextBoxDescription.Text = ""
        Me.RadColorPickerLabelColor.SelectedColor = Nothing
        Me.CheckBoxIsActive.Checked = True
        Me.DivTopLevel.Visible = False

    End Sub
    Private Sub LoadLabels()

        Me.RadTreeViewLabels.Nodes.Clear()

        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            Dim list As New Generic.List(Of AdvantageFramework.Database.Entities.Label)
            Dim node As RadTreeNode

            If Me.CheckBoxShowInactive.Checked = True Then
                list = AdvantageFramework.Database.Procedures.Label.Load(dc).ToList()
            Else
                list = AdvantageFramework.Database.Procedures.Label.LoadActive(dc).ToList()
            End If

            Me.RadTreeViewLabels.DataTextField = "Name"
            Me.RadTreeViewLabels.DataValueField = "ID"
            Me.RadTreeViewLabels.DataFieldID = "ID"
            Me.RadTreeViewLabels.DataFieldParentID = "ParentID"

            Me.RadTreeViewLabels.DataSource = list

            Me.RadTreeViewLabels.DataBind()

            Me.RadTreeViewLabels.ExpandAllNodes()
            'Me.RadTreeViewLabels.CheckBoxes = True

        End Using

    End Sub
    Private Sub LoadEditForm()

        Me.ClearEditForm()
        Me.DivEditForm.Visible = False

        If Me._SelectedLabelID > 0 Then

            Me.LabelFormTitle.Text = "Edit"

            Me.RadToolbarLabels.FindItemByValue("Refresh").Visible = True
            Me.RadToolbarLabels.FindItemByValue("Delete").Visible = True
            ''Me.RadToolbarLabels.FindItemByValue("LastSeparator").Visible = True
            Me.RadToolbarLabels.FindItemByValue("Cancel").Visible = False

            Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Dim Label As AdvantageFramework.Database.Entities.Label = Nothing

                Label = AdvantageFramework.Database.Procedures.Label.LoadByLabelID(dc, Me._SelectedLabelID)

                If Label IsNot Nothing Then

                    If Label.Name IsNot Nothing Then Me.TextBoxName.Text = Label.Name
                    If Label.Description IsNot Nothing Then Me.TextBoxDescription.Text = Label.Description
                    If Label.HexColor IsNot Nothing Then Me.RadColorPickerLabelColor.SelectedColor = System.Drawing.ColorTranslator.FromHtml(Label.HexColor)
                    If Label.IsInactive IsNot Nothing AndAlso Label.IsInactive = 1 Then
                        Me.CheckBoxIsActive.Checked = False
                    Else
                        Me.CheckBoxIsActive.Checked = True
                    End If

                    Me.DivEditForm.Visible = True

                Else

                    Me.ShowMessage("Cannot load label information")

                End If

            End Using

        Else

            Me.DivEditForm.Visible = False

        End If


    End Sub

#End Region

#End Region

End Class