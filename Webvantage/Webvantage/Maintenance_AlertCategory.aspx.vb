Imports Telerik.Web.UI

Public Class Maintenance_AlertCategory
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AlertTypes As New Generic.List(Of AdvantageFramework.Database.Entities.AlertType)

#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Description")
        DataTable.Columns.Add("Active")

        Me.RadGridAlertCategories.AllowPaging = False
        Me.RadGridAlertCategories.Rebind()

        For Each GridDataItem In Me.RadGridAlertCategories.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Description

            If GridDataItem.DataItem.IsInactive = False Then

                NewDataRow(1) = "YES"

            Else

                NewDataRow(1) = "NO"

            End If

        Next

        Me.DeliverGrid(DataTable, "Roles") '<--- Please don't change unless you test!!!!

        Me.RadGridAlertCategories.AllowPaging = True
        Me.RadGridAlertCategories.Rebind()

    End Sub
    Private Sub RadGridAlertCategories_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridAlertCategories.ItemCommand

        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = Me.RadGridAlertCategories.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                Dim Successes As Integer = 0
                Dim Fails As Integer = 0

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    For Each GridDataItem In Me.RadGridAlertCategories.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory
                        AlertCategory = Nothing

                        AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                        If AlertCategory IsNot Nothing Then

                            AlertCategory.Description = CType(GridDataItem.FindControl("TextBoxStatusDescription"), TextBox).Text
                            AlertCategory.AlertTypeID = CType(GridDataItem.FindControl("RadComboBoxAlertType"), Telerik.Web.UI.RadComboBox).SelectedItem.Value
                            AlertCategory.IsInactive = CType(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked

                            If AdvantageFramework.Database.Procedures.AlertCategory.Update(DbContext, AlertCategory, Nothing) = True Then

                                Successes += 1

                            Else

                                Fails += 1

                            End If

                        End If

                    Next

                    If Successes > 0 AndAlso Fails = 0 Then

                        Me.RadGridAlertCategories.Rebind()

                    ElseIf Successes > 0 And Fails > 0 Then

                        Me.ShowMessage(String.Format("{0} rows saved.  {1} rows failed to save.", Successes.ToString(), Fails.ToString()))
                        Me.RadGridAlertCategories.Rebind()

                    ElseIf Successes = 0 And Fails > 0 Then

                        Me.ShowMessage("All rows failed to save")

                    ElseIf Successes = 0 And Fails = 0 Then

                        Me.ShowMessage("No rows saved")

                    End If

                End Using

            Case "SaveNewRow"

                Dim AlertTypeRadComboBox As Telerik.Web.UI.RadComboBox = CType(e.Item.FindControl("RadComboBoxAlertType"), Telerik.Web.UI.RadComboBox)

                If AlertTypeRadComboBox.SelectedIndex = 0 Then

                    Me.ShowMessage("Please select a type")
                    Exit Sub

                Else

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory
                        AlertCategory = New AdvantageFramework.Database.Entities.AlertCategory

                        AlertCategory.DbContext = DbContext

                        AlertCategory.Description = CType(e.Item.FindControl("TextBoxStatusDescription"), TextBox).Text.Trim
                        AlertCategory.AlertTypeID = AlertTypeRadComboBox.SelectedItem.Value
                        AlertCategory.IsInactive = CType(e.Item.FindControl("CheckBoxIsInactive"), CheckBox).Checked
                        AlertCategory.AllowPrompt = 1
                        AlertCategory.GroupLevelSecurityID = 0
                        AlertCategory.IsUserDefined = True

                        If AdvantageFramework.Database.Procedures.AlertCategory.Insert(DbContext, AlertCategory, Nothing) = True Then

                            Me.RadGridAlertCategories.Rebind()

                        End If

                    End Using

                End If

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory

                        AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If AlertCategory IsNot Nothing Then

                            AlertCategory.Description = CType(CurrentGridDataItem.FindControl("TextBoxStatusDescription"), TextBox).Text
                            AlertCategory.AlertTypeID = CType(e.Item.FindControl("RadComboBoxAlertType"), Telerik.Web.UI.RadComboBox).SelectedItem.Value
                            AlertCategory.IsInactive = CType(CurrentGridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked

                            If AdvantageFramework.Database.Procedures.AlertCategory.Update(DbContext, AlertCategory, Nothing) = True Then

                                Me.RadGridAlertCategories.Rebind()

                            End If

                        End If

                    End Using

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxStatusDescription"), TextBox).Text = ""
                    CType(e.Item.FindControl("CheckBoxIsInactive"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory

                        AlertCategory = AdvantageFramework.Database.Procedures.AlertCategory.LoadByID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If AlertCategory IsNot Nothing Then

                            If AdvantageFramework.Database.Procedures.AlertCategory.Delete(DbContext, AlertCategory) = True Then

                                Me.RadGridAlertCategories.Rebind()

                            End If

                        End If

                    End Using

                End If

        End Select

    End Sub
    Private Sub RadGridAlertCategories_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridAlertCategories.ItemDataBound

        Dim AlertTypeRadComboBox As Telerik.Web.UI.RadComboBox
        Dim AlertCategory As AdvantageFramework.Database.Entities.AlertCategory

        If e.Item.ItemType = GridItemType.AlternatingItem OrElse e.Item.ItemType = GridItemType.Item OrElse e.Item.ItemType = GridItemType.EditItem Then

            AlertTypeRadComboBox = e.Item.FindControl("RadComboBoxAlertType")
            If AlertTypeRadComboBox IsNot Nothing Then Me.LoadAlertTypeRadComboBox(AlertTypeRadComboBox)

        End If

        Select Case e.Item.ItemType
            Case GridItemType.AlternatingItem, GridItemType.Item

                AlertCategory = e.Item.DataItem

                If AlertTypeRadComboBox IsNot Nothing AndAlso AlertCategory IsNot Nothing Then

                    If AlertCategory.AlertTypeID IsNot Nothing Then MiscFN.RadComboBoxSetIndex(AlertTypeRadComboBox, AlertCategory.AlertTypeID, False)

                End If

            Case GridItemType.EditItem


        End Select


    End Sub
    Private Sub RadGridAlertCategories_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridAlertCategories.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim AlertCategories As Generic.List(Of AdvantageFramework.Database.Entities.AlertCategory)
            AlertCategories = Nothing

            If Me.CheckBoxShowInactive.Checked = True Then

                AlertCategories = AdvantageFramework.Database.Procedures.AlertCategory.LoadUserDefined(DbContext).ToList()

            Else

                AlertCategories = AdvantageFramework.Database.Procedures.AlertCategory.LoadUserDefinedActive(DbContext).ToList()

            End If

            If AlertCategories Is Nothing Then AlertCategories = New Generic.List(Of AdvantageFramework.Database.Entities.AlertCategory)

            Me.RadGridAlertCategories.DataSource = AlertCategories
            Me.RadGridAlertCategories.MasterTableView.IsItemInserted = True

        End Using

    End Sub
    Private Sub RadGridAlertCategories_PageIndexChanged(sender As Object, e As GridPageChangedEventArgs) Handles RadGridAlertCategories.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridAlertCategories.Rebind()

    End Sub
    Private Sub RadGridAlertCategories_PageSizeChanged(sender As Object, e As GridPageSizeChangedEventArgs) Handles RadGridAlertCategories.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridAlertCategories.ID, e.NewPageSize)

    End Sub

#End Region
#Region " Page "

    Private Sub Maintenance_AlertCategory_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

    End Sub
    Private Sub Maintenance_AlertCategory_Load(sender As Object, e As EventArgs) Handles Me.Load

    End Sub

    Private Sub CheckBoxShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridAlertCategories.Rebind()

    End Sub

#End Region

    Private Sub LoadAlertTypes()

        If Me._AlertTypes Is Nothing Then Me._AlertTypes = New Generic.List(Of AdvantageFramework.Database.Entities.AlertType)

        If Me._AlertTypes.Count = 0 Then

            Using oc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Me._AlertTypes = AdvantageFramework.Database.Procedures.AlertType.LoadOnlyAlertTypes(oc).ToList()

            End Using

        End If

    End Sub

    Private Sub LoadAlertTypeRadComboBox(ByRef ComboBox As Telerik.Web.UI.RadComboBox)

        Me.LoadAlertTypes()

        Dim PleaseSelectRadComboBoxItem As New Telerik.Web.UI.RadComboBoxItem("[Please select]", "0")

        ComboBox.DataSource = Me._AlertTypes
        ComboBox.DataTextField = "Description"
        ComboBox.DataValueField = "ID"
        ComboBox.DataBind()
        ComboBox.Items.Insert(0, PleaseSelectRadComboBoxItem)

    End Sub
#End Region

End Class