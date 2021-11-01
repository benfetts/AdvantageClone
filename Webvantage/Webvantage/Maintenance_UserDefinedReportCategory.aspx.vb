Public Class Maintenance_UserDefinedReportCategory
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Function UpdateUserDefinedReportCategory(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory = Nothing
        Dim UserDefinedReportCategoryUpdated As Boolean = False

        Try

            Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                UserDefinedReportCategory = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.LoadByUserDefinedReportCategoryID(ReportingDbContext, GridDataItem.GetDataKeyValue("ID"))

                If UserDefinedReportCategory IsNot Nothing Then

                    UserDefinedReportCategory.Description = CType(GridDataItem.FindControl("TextBoxUserDefinedReportCategoryDescription"), TextBox).Text.Trim

                    UserDefinedReportCategoryUpdated = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Update(ReportingDbContext, UserDefinedReportCategory)

                End If

            End Using

        Catch ex As Exception
            UserDefinedReportCategoryUpdated = False
        Finally
            UpdateUserDefinedReportCategory = UserDefinedReportCategoryUpdated
        End Try

    End Function
    Private Sub LoadUserDefinedReportCategories()

        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridUserDefinedReportCategories.DataSource = (From UserDefinedReportCategory In AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Load(ReportingDbContext)
                                                             Select UserDefinedReportCategory.ID,
                                                                    UserDefinedReportCategory.Description
                                                             Order By Description).ToList

            RadGridUserDefinedReportCategories.MasterTableView.IsItemInserted = True

            RadGridUserDefinedReportCategories.DataBind()

        End Using

    End Sub

#Region "  Form Event Handlers "

    Private Sub UserDefinedReportCategoryMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "User Defined Report Categories Maintenance"

        If Not Me.IsPostBack And Not Me.IsCallback Then

            LoadUserDefinedReportCategories()

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim UserDefinedReportCategorys As IQueryable(Of AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory) = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Description")

        RadGridUserDefinedReportCategories.AllowPaging = False

        LoadUserDefinedReportCategories()

        For Each GridDataItem In RadGridUserDefinedReportCategories.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

            NewDataRow = DataTable.Rows.Add()

            NewDataRow(0) = GridDataItem.DataItem.Description

        Next

        'DataView = New DataView(DataTable)

        'GridView = New GridView

        'GridView.DataSource = DataView
        'GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("UserDefinedReportCategorys.xls", GridView) <--- This doesn' work
        Me.DeliverGrid(DataTable, "UserDefinedReportCategories") '<--- This does, please don't change unless you test!!!!

        RadGridUserDefinedReportCategories.AllowPaging = True

        LoadUserDefinedReportCategories()

    End Sub
    Private Sub RadGridUserDefinedReportCategories_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridUserDefinedReportCategories.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim UserDefinedReportCategory As AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridUserDefinedReportCategories.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridUserDefinedReportCategories.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateUserDefinedReportCategory(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveNewRow"

                Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    UserDefinedReportCategory = New AdvantageFramework.Reporting.Database.Entities.UserDefinedReportCategory

                    UserDefinedReportCategory.DbContext = ReportingDbContext

                    UserDefinedReportCategory.Description = CType(e.Item.FindControl("TextBoxUserDefinedReportCategoryDescriptionEditTextBox"), TextBox).Text.Trim

                    Reload = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Insert(ReportingDbContext, UserDefinedReportCategory)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateUserDefinedReportCategory(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxUserDefinedReportCategoryDescriptionEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        UserDefinedReportCategory = AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.LoadByUserDefinedReportCategoryID(ReportingDbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                        If UserDefinedReportCategory IsNot Nothing Then

                            AdvantageFramework.Reporting.Database.Procedures.UserDefinedReportCategory.Delete(ReportingDbContext, UserDefinedReportCategory)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect("Maintenance_UserDefinedReportCategory.aspx")

            Else

                LoadUserDefinedReportCategories()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxUserDefinedReportCategoryDescriptionEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridUserDefinedReportCategories_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridUserDefinedReportCategories.ItemDataBound

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

#End Region

#End Region

End Class