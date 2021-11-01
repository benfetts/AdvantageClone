Public Class Maintenance_JobType
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _SalesClasses As Generic.List(Of AdvantageFramework.Database.Entities.SalesClass) = Nothing

#End Region

#Region " Properties "

    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Function UpdateJobType(ByRef GridDataItem As Telerik.Web.UI.GridDataItem) As Boolean

        'objects
        Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing
        Dim JobTypeUpdated As Boolean = False

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobType = AdvantageFramework.Database.Procedures.JobType.LoadByJobTypeCode(DbContext, GridDataItem.GetDataKeyValue("Code"))

                If JobType IsNot Nothing Then

                    JobType.Description = CType(GridDataItem.FindControl("TextBoxJobTypeDescription"), TextBox).Text.Trim

                    If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                        JobType.IsInactive = 1

                    Else

                        JobType.IsInactive = 0

                    End If

                    If CType(GridDataItem.FindControl("DropDownListJobTypeSalesClass"), Telerik.Web.UI.RadComboBox).SelectedValue.ToString() <> "" Then

                        JobType.SalesClassCode = CType(GridDataItem.FindControl("DropDownListJobTypeSalesClass"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        JobType.SalesClassCode = Nothing

                    End If

                    JobTypeUpdated = AdvantageFramework.Database.Procedures.JobType.Update(DbContext, JobType)

                End If

            End Using

        Catch ex As Exception
            JobTypeUpdated = False
        Finally
            UpdateJobType = JobTypeUpdated
        End Try

    End Function

#Region "  Form Event Handlers "

    Private Sub JobTypeMaintenance_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.PageTitle = "Job Type Maintenance"

        If Not Me.IsPostBack And Not Me.IsCallback Then



        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        Me.RadGridJobTypes.Rebind()

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim JobTypes As IQueryable(Of AdvantageFramework.Database.Entities.JobType) = Nothing
        Dim SalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

        DataTable = New DataTable

        DataTable.Columns.Add("Code")
        DataTable.Columns.Add("Description")
        DataTable.Columns.Add("Sales Class")
        DataTable.Columns.Add("Is Inactive")

        RadGridJobTypes.AllowPaging = False

        Me.RadGridJobTypes.Rebind()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            For Each GridDataItem In RadGridJobTypes.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                NewDataRow = DataTable.Rows.Add()

                NewDataRow(0) = GridDataItem.DataItem.Code
                NewDataRow(1) = GridDataItem.DataItem.Description

                SalesClass = AdvantageFramework.Database.Procedures.SalesClass.LoadBySalesClassCode(DbContext, GridDataItem.DataItem.SalesClassCode)

                If SalesClass IsNot Nothing Then

                    NewDataRow(2) = SalesClass.Description

                Else

                    NewDataRow(2) = ""

                End If

                If GridDataItem.DataItem.IsInactive Then

                    NewDataRow(3) = "YES"

                Else

                    NewDataRow(3) = "NO"

                End If

            Next

        End Using

        'DataView = New DataView(DataTable)

        'GridView = New GridView

        'GridView.DataSource = DataView
        'GridView.DataBind()

        'AdvantageFramework.Web.Exporting.ToExcel("JobTypes.xls", GridView) <--- This doesn' work
        Me.DeliverGrid(DataTable, "Job Types") '<--- This does, please don't change unless you test!!!!

        RadGridJobTypes.AllowPaging = True

        Me.RadGridJobTypes.Rebind()

    End Sub
    Private Sub RadGridJobTypes_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobTypes.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobType As AdvantageFramework.Database.Entities.JobType = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobTypes.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridJobTypes.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    If UpdateJobType(GridDataItem) = False Then

                        Reload = False
                        Exit For

                    End If

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobType = New AdvantageFramework.Database.Entities.JobType

                    JobType.DbContext = DbContext
                    JobType.Code = CType(e.Item.FindControl("TextBoxJobTypeCodeEdit"), TextBox).Text.Trim
                    JobType.Description = CType(e.Item.FindControl("TextBoxJobTypeDescriptionEdit"), TextBox).Text.Trim

                    If CType(e.Item.FindControl("DropDownListJobTypeSalesClassEdit"), Telerik.Web.UI.RadComboBox).SelectedValue.ToString() <> "" Then

                        JobType.SalesClassCode = CType(e.Item.FindControl("DropDownListJobTypeSalesClassEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                    Else

                        JobType.SalesClassCode = Nothing

                    End If

                    If CType(e.Item.FindControl("CheckBoxIsInactiveEdit"), CheckBox).Checked Then

                        JobType.IsInactive = 1

                    Else

                        JobType.IsInactive = 0

                    End If

                    Reload = AdvantageFramework.Database.Procedures.JobType.Insert(DbContext, JobType)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Reload = UpdateJobType(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxJobTypeCodeEdit"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxJobTypeDescriptionEdit"), TextBox).Text = ""
                    CType(e.Item.FindControl("DropDownListJobTypeSalesClassEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = ""
                    CType(e.Item.FindControl("CheckBoxIsInactiveEdit"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobType = AdvantageFramework.Database.Procedures.JobType.LoadByJobTypeCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                        If JobType IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.JobType.Delete(DbContext, JobType)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect("Maintenance_JobType.aspx")

            Else

                Me.RadGridJobTypes.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxJobTypeDescriptionEdit"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridJobTypes_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobTypes.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DropDownListSalesClasses As Telerik.Web.UI.RadComboBox = Nothing
        Dim InactiveSalesClass As AdvantageFramework.Database.Entities.SalesClass = Nothing

        If _SalesClasses Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _SalesClasses = AdvantageFramework.Database.Procedures.SalesClass.Load(DbContext).ToList

                _SalesClasses = _SalesClasses.FindAll(Function(Entity) Entity.SalesClassTypeCode.ToLower = "p")

            End Using

        End If

        Try

            DropDownListSalesClasses = DirectCast(e.Item.FindControl("DropDownListJobTypeSalesClass"), Telerik.Web.UI.RadComboBox)

            If DropDownListSalesClasses Is Nothing Then

                DropDownListSalesClasses = DirectCast(e.Item.FindControl("DropDownListJobTypeSalesClassEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListSalesClasses IsNot Nothing Then

                DropDownListSalesClasses.DataSource = (From SalesClass In _SalesClasses
                                                       Where SalesClass.IsInactive Is Nothing OrElse
                                                             SalesClass.IsInactive = 0
                                                       Select SalesClass.Code,
                                                              SalesClass.Description).ToList

                DropDownListSalesClasses.DataBind()

                DropDownListSalesClasses.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    Try

                        InactiveSalesClass = (From SalesClass In _SalesClasses
                                              Where SalesClass.Code = e.Item.DataItem.SalesClassCode AndAlso
                                                    SalesClass.IsInactive = 1
                                              Select SalesClass).SingleOrDefault

                    Catch ex As Exception
                        InactiveSalesClass = Nothing
                    End Try

                    If InactiveSalesClass IsNot Nothing Then

                        DropDownListSalesClasses.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveSalesClass.Description & "*", InactiveSalesClass.Code))

                        DropDownListSalesClasses.SelectedValue = InactiveSalesClass.Code

                    Else

                        DropDownListSalesClasses.SelectedValue = e.Item.DataItem.SalesClassCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListSalesClasses = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

    End Sub
    Private Sub RadGridJobTypes_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobTypes.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If CheckBoxShowInactive.Checked Then

                RadGridJobTypes.DataSource = (From JobType In AdvantageFramework.Database.Procedures.JobType.Load(DbContext).ToList
                                              Select JobType.Code,
                                                     JobType.Description,
                                                     JobType.SalesClassCode,
                                                     [IsInactive] = CBool(JobType.IsInactive.GetValueOrDefault(0))
                                              Order By Code,
                                                       Description).ToList

            Else

                RadGridJobTypes.DataSource = (From JobType In AdvantageFramework.Database.Procedures.JobType.LoadAllActive(DbContext).ToList
                                              Select JobType.Code,
                                                     JobType.Description,
                                                     JobType.SalesClassCode,
                                                     [IsInactive] = CBool(JobType.IsInactive.GetValueOrDefault(0))
                                              Order By Code,
                                                       Description).ToList

            End If

            RadGridJobTypes.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridJobTypes.PageSize = MiscFN.LoadPageSize(Me.RadGridJobTypes.ID)

    End Sub
    Private Sub RadGridJobTypes_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridJobTypes.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridJobTypes.Rebind()

    End Sub
    Private Sub RadGridJobTypes_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridJobTypes.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridJobTypes.ID, e.NewPageSize)

    End Sub

#End Region

#End Region

End Class
