Public Class Maintenance_Status
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Sub UpdateStatus(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim Status As AdvantageFramework.Database.Entities.Status = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                Status = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, GridDataItem.GetDataKeyValue("Code"))

                If Status IsNot Nothing Then

                    Status.Description = CType(GridDataItem.FindControl("TextBoxStatusDescription"), TextBox).Text.Trim

                    If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                        Status.IsInactive = 1

                    Else

                        Status.IsInactive = 0

                    End If

                    AdvantageFramework.Database.Procedures.Status.Update(DbContext, DataContext, Status)

                End If

            End Using

        End Using

    End Sub
#Region "  Form Event Handlers "

    Private Sub StatusMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Status Maintenance"


        If Not Me.IsPostBack And Not Me.IsCallback Then



        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridStatuses.Rebind()

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Statuses As IQueryable(Of AdvantageFramework.Database.Entities.Status) = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Code")
        DataTable.Columns.Add("Description")
        DataTable.Columns.Add("Is Inactive")

        RadGridStatuses.AllowPaging = False

        Me.RadGridStatuses.Rebind()

        For Each GridDataItem In RadGridStatuses.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Code
            NewDataRow(1) = GridDataItem.DataItem.Description

            If GridDataItem.DataItem.IsInactive Then

                NewDataRow(2) = "YES"

            Else

                NewDataRow(2) = "NO"

            End If

        Next

        'DataView = New DataView(DataTable)

        'GridView = New GridView

        'GridView.DataSource = DataView
        'GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("Statuses.xls", GridView)  <--- This doesn' work
        Me.DeliverGrid(DataTable, "Statuses") '<--- This does, please don't change unless you test!!!!

        RadGridStatuses.AllowPaging = True

        Me.RadGridStatuses.Rebind()

    End Sub
    Private Sub RadGridStatuses_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridStatuses.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim Status As AdvantageFramework.Database.Entities.Status = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridStatuses.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridStatuses.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateStatus(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        Status = New AdvantageFramework.Database.Entities.Status

                        Status.DbContext = DbContext

                        Status.Code = CType(e.Item.FindControl("TextBoxStatusCodeEditTextBox"), TextBox).Text.Trim
                        Status.Description = CType(e.Item.FindControl("TextBoxStatusDescriptionEditTextBox"), TextBox).Text.Trim

                        If CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked Then

                            Status.IsInactive = 1

                        Else

                            Status.IsInactive = 0

                        End If

                        Reload = AdvantageFramework.Database.Procedures.Status.Insert(DbContext, DataContext, Status)

                    End Using

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateStatus(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxStatusCodeEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxStatusDescriptionEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            Status = AdvantageFramework.Database.Procedures.Status.LoadByStatusCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                            If Status IsNot Nothing Then

                                AdvantageFramework.Database.Procedures.Status.Delete(DbContext, DataContext, Status)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect("Maintenance_Status.aspx")

            Else

                Me.RadGridStatuses.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxStatusCodeEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridStatuses_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridStatuses.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridStatuses_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridStatuses.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CheckBoxShowInactive.Checked Then

                RadGridStatuses.DataSource = (From Status In AdvantageFramework.Database.Procedures.Status.Load(DbContext).ToList
                                              Select Status.Code,
                                                     Status.Description,
                                                     [IsInactive] = CBool(Status.IsInactive.GetValueOrDefault(0))
                                              Order By Code).ToList

            Else

                RadGridStatuses.DataSource = (From Status In AdvantageFramework.Database.Procedures.Status.LoadAllActive(DbContext).ToList
                                              Select Status.Code,
                                                     Status.Description,
                                                     [IsInactive] = CBool(Status.IsInactive.GetValueOrDefault(0))
                                              Order By Code).ToList

            End If

            RadGridStatuses.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridStatuses.PageSize = MiscFN.LoadPageSize(Me.RadGridStatuses.ID)

    End Sub
    Private Sub RadGridStatuses_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridStatuses.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridStatuses.Rebind()

    End Sub
    Private Sub RadGridStatuses_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridStatuses.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridStatuses.ID, e.NewPageSize)

    End Sub
    Protected Sub TextBoxStatusCodeEditTextBox_OnTextChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        If sender IsNot Nothing Then

            sender = sender

        End If

    End Sub

#End Region

#End Region

End Class