Imports Telerik.Web.UI

Public Class Maintenance_JobVersionTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _JobVersionDatabaseTypeList As Generic.IEnumerable(Of Object) = Nothing
    Private _JobVersionJobTemplateMappingList As Generic.IEnumerable(Of Object) = Nothing

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
    Private Property CurrentGridPageIndex As Integer = 0
    Private Property CurrentPageNumber As Integer = 0

#End Region

#Region " Methods "

    Private Function LoadJobVersionTemplates(ByRef DbContext As AdvantageFramework.Database.DbContext, ByVal OrderByDescription As Boolean) As Generic.IEnumerable(Of Object)

        'objects
        Dim JobVersionTemplates As Generic.IEnumerable(Of Object) = Nothing

        If CheckBoxShowInactive.Checked Then

            JobVersionTemplates = From JobVersionTemplate In AdvantageFramework.Database.Procedures.JobVersionTemplate.Load(DbContext).ToList
                                  Select JobVersionTemplate.Code,
                                          JobVersionTemplate.Description,
                                          [IsInactive] = CBool(JobVersionTemplate.IsInactive.GetValueOrDefault(0))
                                  Distinct

        Else

            JobVersionTemplates = From JobVersionTemplate In AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadAllActive(DbContext).ToList
                                  Select JobVersionTemplate.Code,
                                          JobVersionTemplate.Description,
                                          [IsInactive] = CBool(JobVersionTemplate.IsInactive.GetValueOrDefault(0))
                                  Distinct

        End If

        If OrderByDescription Then

            JobVersionTemplates = JobVersionTemplates.OrderBy(Function(JobVersionTemplate) JobVersionTemplate.Description)

        End If

        LoadJobVersionTemplates = JobVersionTemplates

    End Function
    Private Sub LoadJobVersionTemplateDetailTab(ByVal JobVersionTemplateCode As String)

        'objects
        Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            DropDownListJobVersionTemplates.DataSource = LoadJobVersionTemplates(DbContext, True)

            DropDownListJobVersionTemplates.DataBind()

            DropDownListJobVersionTemplates.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

        Try

            If JobVersionTemplateCode <> "" Then

                DropDownListJobVersionTemplates.SelectedValue = JobVersionTemplateCode

            End If

        Catch ex As Exception

            If DropDownListJobVersionTemplates.Items.Count > 0 Then

                DropDownListJobVersionTemplates.SelectedIndex = 0

            End If

        End Try

        If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue <> "" Then

            Me.RadGridJobVersionTemplateDetails.Rebind()

        Else


            RadGridJobVersionTemplateDetails.DataSource = Nothing
            RadGridJobVersionTemplateDetails.DataBind()

        End If

    End Sub
    Private Sub UpdateJobVersionTemplateOnJobVersionTemplatesTab(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, GridDataItem.GetDataKeyValue("Code").ToString())

                If JobVersionTemplate IsNot Nothing Then

                    JobVersionTemplate.Description = CType(GridDataItem.FindControl("TextBoxJobVersionTemplateDescription"), TextBox).Text.Trim

                    If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                        JobVersionTemplate.IsInactive = 1

                    Else

                        JobVersionTemplate.IsInactive = 0

                    End If

                    AdvantageFramework.Database.Procedures.JobVersionTemplate.Update(DbContext, DataContext, JobVersionTemplate)

                End If

            End Using

        End Using

    End Sub
    Private Sub UpdateJobVersionTemplateDetailOnJobVersionTemplateDetailsTab(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim JobVersionTemplateDetailMapping As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, GridDataItem.GetDataKeyValue("ID"))

            If JobVersionTemplateDetail IsNot Nothing Then

                JobVersionTemplateDetail.Label = CType(GridDataItem.FindControl("TextBoxJobVersionTemplateDetailLabel"), TextBox).Text.Trim
                JobVersionTemplateDetail.DatabaseTypeID = CType(GridDataItem.FindControl("DropDownListJobVersionTemplateDetailDatabaseType"), Telerik.Web.UI.RadComboBox).SelectedValue

                If JobVersionTemplateDetail.DatabaseTypeID <> 12 Then

                    JobVersionTemplateDetailMapping = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCodeAndMapping(DbContext, Me.DropDownListJobVersionTemplates.SelectedValue, CType(GridDataItem.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMapping"), Telerik.Web.UI.RadComboBox).SelectedValue, GridDataItem.GetDataKeyValue("ID"))

                    If JobVersionTemplateDetailMapping IsNot Nothing Then

                        If JobVersionTemplateDetailMapping.JobTemplateMapping <> "" Then

                            Me.ShowMessage("This field is already mapped.  Please choose a different field.")
                            Exit Sub

                        End If

                    End If

                    If DirectCast(GridDataItem.FindControl("CheckBoxIsRequired"), CheckBox).Checked Then

                        JobVersionTemplateDetail.IsRequired = 1

                    Else

                        JobVersionTemplateDetail.IsRequired = 0

                    End If

                    JobVersionTemplateDetail.Instructions = CType(GridDataItem.FindControl("TextBoxJobVersionTemplateDetailInstructions"), TextBox).Text.Trim
                    JobVersionTemplateDetail.JobTemplateMapping = CType(GridDataItem.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMapping"), Telerik.Web.UI.RadComboBox).SelectedValue

                End If

                If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                    JobVersionTemplateDetail.IsInactive = 0

                Else

                    JobVersionTemplateDetail.IsInactive = 1

                End If

                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetail)

            End If

        End Using

    End Sub
    Private Sub ChangeTabs(ByVal JobVersionTemplateCode As String)

        Select Case RadTabStripJobVersionTemplates.SelectedIndex

            Case 0

                Me.RadGridJobVersionTemplates.Rebind()

            Case 1

                LoadJobVersionTemplateDetailTab(JobVersionTemplateCode)

        End Select

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_JobVersionTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.PageTitle = "Job Version Template Maintenance"

        'objects
        Dim TabIndex As Integer = 0
        Dim JobVersionTemplateCode As String = ""

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

                If Not Request.QueryString("JobVersionTemplateCode") Is Nothing Then

                    JobVersionTemplateCode = CType(Request.QueryString("JobVersionTemplateCode"), String)

                End If

            Catch ex As Exception
                TabIndex = 0
                JobVersionTemplateCode = ""
            End Try

            Try

                RadTabStripJobVersionTemplates.SelectedIndex = TabIndex
                RadMultiPageJobVersionTemplates.SelectedIndex = TabIndex

                ChangeTabs(JobVersionTemplateCode)

            Catch ex As Exception

            End Try
        Else

            Select Case Me.EventArgument

                Case "Refresh"

                    MiscFN.RadWindowsClose(Me.RadWindowManager)

                Case "HidePopups"

                    MiscFN.RadWindowsClose(Me.RadWindowManager)

            End Select

        End If

    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridJobVersionTemplates AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridJobVersionTemplates.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                Response.Redirect([String].Format("Maintenance_JobVersionTemplate.aspx?TabIndex={0}&JobVersionTemplateCode={1}", 1, GridDataItem.GetDataKeyValue("Code")))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub UserDefinedListValues_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs)

        'objects
        Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim JobVersionDatabaseType As AdvantageFramework.Database.Entities.JobVersionDatabaseType = Nothing
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim RowIndex As Integer = 0
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        Try

            GridItem = CType(CType(sender, ImageButton).Parent.Parent, Telerik.Web.UI.GridItem)

            RowIndex = GridItem.RowIndex - 2

            GridDataItem = DirectCast(RadGridJobVersionTemplateDetails.MasterTableView.Items(RowIndex), Telerik.Web.UI.GridDataItem)

            If GridDataItem IsNot Nothing Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                    If JobVersionTemplateDetail IsNot Nothing Then

                        JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, JobVersionTemplateDetail.DatabaseTypeID)

                        If JobVersionDatabaseType IsNot Nothing Then

                            If JobVersionDatabaseType.IsList.GetValueOrDefault(0) = 1 Then

                                'AdvantageFramework.Web.Presentation.ShowRadWindow(Me.RadWindowManager, "JobVersionTemplateDetailListValue", "", "Maintenance_JobVersionTemplateDetailListValue.aspx?JobVersionTemplateDetailID=" & JobVersionTemplateDetail.ID, 450, 500, True)
                                Me.OpenWindow("", "Maintenance_JobVersionTemplateDetailListValue.aspx?JobVersionTemplateDetailID=" & JobVersionTemplateDetail.ID, 450, 500, False, True)
                            End If

                        End If

                    End If

                End Using

            End If

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        'objects
        Dim JobVersionTemplateCode As String = ""

        If RadTabStripJobVersionTemplates.SelectedIndex = 1 AndAlso DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue <> "" Then

            JobVersionTemplateCode = DropDownListJobVersionTemplates.SelectedValue

        End If

        ChangeTabs(JobVersionTemplateCode)

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim JobVersionDatabaseType As AdvantageFramework.Database.Entities.JobVersionDatabaseType = Nothing

        Select Case RadTabStripJobVersionTemplates.SelectedIndex

            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Code")
                DataTable.Columns.Add("Description")
                DataTable.Columns.Add("Active")

                RadGridJobVersionTemplates.AllowPaging = False

                Me.RadGridJobVersionTemplates.Rebind()

                For Each GridDataItem In RadGridJobVersionTemplates.MasterTableView.Items

                    NewDataRow = DataTable.Rows.Add()

                    NewDataRow(0) = GridDataItem.DataItem.Code

                    NewDataRow(1) = GridDataItem.DataItem.Description

                    If GridDataItem.DataItem.IsInactive = False Then

                        NewDataRow(2) = "YES"

                    Else

                        NewDataRow(2) = "NO"

                    End If

                Next

                'DataView = New DataView(DataTable)

                'GridView = New GridView

                'GridView.DataSource = DataView
                'GridView.DataBind()

                'AdvantageFramework.Web.Exporting.ToExcel("Job Version Templates.xls", GridView) <--- This doesn' work
                Me.DeliverGrid(DataTable, "Job Version Templates") '<--- This does, please don't change unless you test!!!!

                RadGridJobVersionTemplates.AllowPaging = True

                Me.RadGridJobVersionTemplates.Rebind()

            Case 1

                If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue.ToString() <> "" Then

                    DataTable = New DataTable

                    DataTable.Columns.Add("Label")
                    DataTable.Columns.Add("Database Type")
                    DataTable.Columns.Add("Active")
                    DataTable.Columns.Add("Required")
                    DataTable.Columns.Add("Instructions")
                    DataTable.Columns.Add("Job Template Mapping")

                    RadGridJobVersionTemplateDetails.AllowPaging = False

                    Me.RadGridJobVersionTemplateDetails.Rebind()

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GridDataItem In RadGridJobVersionTemplateDetails.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, GridDataItem.GetDataKeyValue("ID"))

                            If JobVersionTemplateDetail IsNot Nothing Then

                                NewDataRow = DataTable.Rows.Add()

                                NewDataRow(0) = JobVersionTemplateDetail.Label

                                JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, JobVersionTemplateDetail.DatabaseTypeID)

                                If JobVersionDatabaseType IsNot Nothing Then

                                    NewDataRow(1) = JobVersionDatabaseType.Description

                                End If

                                If JobVersionTemplateDetail.IsInactive = False Then

                                    NewDataRow(2) = "YES"

                                Else

                                    NewDataRow(2) = "NO"

                                End If

                                If JobVersionTemplateDetail.IsRequired Then

                                    NewDataRow(3) = "YES"

                                Else

                                    NewDataRow(3) = "NO"

                                End If

                                NewDataRow(4) = JobVersionTemplateDetail.Instructions
                                Dim JobTemplateItem As AdvantageFramework.Database.Entities.JobTemplateItem = Nothing
                                JobTemplateItem = AdvantageFramework.Database.Procedures.JobTemplateItem.LoadByCode(DbContext, JobVersionTemplateDetail.JobTemplateMapping).FirstOrDefault
                                If JobTemplateItem IsNot Nothing Then
                                    NewDataRow(5) = JobTemplateItem.Description
                                End If

                            End If

                        Next

                    End Using

                    'DataView = New DataView(DataTable)

                    'GridView = New GridView

                    'GridView.DataSource = DataView
                    'GridView.DataBind()

                    ' AdvantageFramework.Web.Exporting.ToExcel("Job Version Template Details.xls", GridView)  <--- This doesn' work
                    Me.DeliverGrid(DataTable, "Job Version Template Details") '<--- This does, please don't change unless you test!!!!

                    RadGridJobVersionTemplateDetails.AllowPaging = True

                    Me.RadGridJobVersionTemplateDetails.Rebind()

                End If

        End Select

    End Sub
    Private Sub RadGridJobVersionTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobVersionTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobVersionTemplates.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridJobVersionTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateJobVersionTemplateOnJobVersionTemplatesTab(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        JobVersionTemplate = New AdvantageFramework.Database.Entities.JobVersionTemplate

                        JobVersionTemplate.DbContext = DbContext

                        JobVersionTemplate.Code = CType(e.Item.FindControl("TextBoxJobVersionTemplateCodeEditTextBox"), TextBox).Text.Trim
                        JobVersionTemplate.Description = CType(e.Item.FindControl("TextBoxJobVersionTemplateDescriptionEditTextBox"), TextBox).Text.Trim

                        If CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked Then

                            JobVersionTemplate.IsInactive = 1

                        Else

                            JobVersionTemplate.IsInactive = 0

                        End If

                        Reload = AdvantageFramework.Database.Procedures.JobVersionTemplate.Insert(DbContext, DataContext, JobVersionTemplate)

                    End Using

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateJobVersionTemplateOnJobVersionTemplatesTab(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxJobVersionTemplateCodeEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxJobVersionTemplateDescriptionEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                            JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                            If JobVersionTemplate IsNot Nothing Then

                                If AdvantageFramework.Database.Procedures.JobVersionTemplate.Delete(DbContext, DataContext, JobVersionTemplate) = True Then

                                    Me.RadGridJobVersionTemplates.Rebind()

                                End If

                            End If

                        End Using

                    End Using

                End If

            Case "Sync"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AdvantageFramework.Database.Procedures.JobVersionTemplate.Sync(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                        Me.ShowMessage("Job version template sync complete.")

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect(String.Format("Maintenance_JobVersionTemplate.aspx?TabIndex={0}", RadTabStripJobVersionTemplates.SelectedIndex))
                Exit Sub

            Else

                Me.RadGridJobVersionTemplateDetails.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxJobVersionTemplateCodeEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub DropDownListJobVersionTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListJobVersionTemplates.SelectedIndexChanged

        If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue <> "" Then

            Me.RadGridJobVersionTemplateDetails.Rebind()

        Else

            RadGridJobVersionTemplateDetails.DataSource = Nothing

            RadGridJobVersionTemplateDetails.DataBind()

        End If

    End Sub
    Private Sub RadTabStripJobVersionTemplates_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripJobVersionTemplates.TabClick

        ChangeTabs("")

    End Sub
    Private Sub CheckBoxJobVersionTemplateIsInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxJobVersionTemplateIsInactive.CheckedChanged

        'objects
        Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

        If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                    JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, DropDownListJobVersionTemplates.SelectedValue)

                    If JobVersionTemplate IsNot Nothing Then

                        If CheckBoxJobVersionTemplateIsInactive.Checked Then

                            JobVersionTemplate.IsInactive = 1

                        Else

                            JobVersionTemplate.IsInactive = 0

                        End If

                        AdvantageFramework.Database.Procedures.JobVersionTemplate.Update(DbContext, DataContext, JobVersionTemplate)

                    End If

                End Using

            End Using

            LoadJobVersionTemplateDetailTab(DropDownListJobVersionTemplates.SelectedValue)

        End If

    End Sub
    Private Sub RadGridJobVersionTemplates_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobVersionTemplates.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim ImageButtonSync As System.Web.UI.WebControls.ImageButton = Nothing

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            ImageButtonSync = DirectCast(e.Item.FindControl("ImageButtonSync"), ImageButton)

            If ImageButtonSync IsNot Nothing Then

                If e.Item.IsInEditMode = False Then

                    ImageButtonSync.Attributes.Add("onclick", "return confirm('Are you sure you want to sync all job/comp versions with this template?');")

                Else

                    ImageButtonSync.Visible = False

                End If

            End If

        Catch ex As Exception
            ImageButtonSync = Nothing
        End Try

    End Sub
    Private Sub RadGridJobVersionTemplateDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridJobVersionTemplateDetails.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim MoveGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim JobVersionTemplateDetailMapping As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim MoveJobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail = Nothing
        Dim DynamicReportList As Generic.List(Of AdvantageFramework.Reporting.Database.Entities.DynamicReport) = Nothing
        Dim DynamicReportColumn As AdvantageFramework.Reporting.Database.Entities.DynamicReportColumn = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridJobVersionTemplateDetails.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "ModifyUserDefinedListValues"

                Reload = False
                Dim qs As New AdvantageFramework.Web.QueryString

                qs.Page = "Maintenance_JobVersionTemplateDetailListValue.aspx"
                qs.Add("JobVersionTemplateDetailID", CurrentGridDataItem.GetDataKeyValue("ID"))

                Me.OpenWindow(qs)

            Case "MoveDown"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If CurrentGridDataItem.ItemIndex < RadGridJobVersionTemplateDetails.Items.Count - 1 Then

                        MoveGridDataItem = RadGridJobVersionTemplateDetails.Items(CurrentGridDataItem.ItemIndex + 1)

                        If MoveGridDataItem IsNot Nothing Then

                            JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))
                            MoveJobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, MoveGridDataItem.GetDataKeyValue("ID"))

                            If JobVersionTemplateDetail IsNot Nothing AndAlso MoveJobVersionTemplateDetail IsNot Nothing Then

                                Dim JobVersionTemplateDetailOrderNumber As Integer = 0
                                Dim MoveJobVersionTemplateDetailOrderNumber As Integer = MoveJobVersionTemplateDetail.OrderNumber

                                JobVersionTemplateDetailOrderNumber = MoveJobVersionTemplateDetailOrderNumber

                                If MoveJobVersionTemplateDetailOrderNumber - 1 < 0 Then

                                    MoveJobVersionTemplateDetailOrderNumber = 0

                                Else

                                    MoveJobVersionTemplateDetailOrderNumber -= 1

                                End If

                                JobVersionTemplateDetail.OrderNumber = JobVersionTemplateDetailOrderNumber
                                MoveJobVersionTemplateDetail.OrderNumber = MoveJobVersionTemplateDetailOrderNumber

                                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetail)
                                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, MoveJobVersionTemplateDetail)

                            End If

                        End If

                    Else

                        Reload = False

                    End If

                End Using

            Case "MoveUp"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    If CurrentGridDataItem.ItemIndex > 0 Then

                        MoveGridDataItem = RadGridJobVersionTemplateDetails.Items(CurrentGridDataItem.ItemIndex - 1)

                        If MoveGridDataItem IsNot Nothing Then

                            JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))
                            MoveJobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, MoveGridDataItem.GetDataKeyValue("ID"))

                            If JobVersionTemplateDetail IsNot Nothing AndAlso MoveJobVersionTemplateDetail IsNot Nothing Then

                                Dim JobVersionTemplateDetailOrderNumber As Integer = 0
                                Dim MoveJobVersionTemplateDetailOrderNumber As Integer = MoveJobVersionTemplateDetail.OrderNumber

                                JobVersionTemplateDetailOrderNumber = MoveJobVersionTemplateDetailOrderNumber
                                MoveJobVersionTemplateDetailOrderNumber += 1

                                'JobVersionTemplateDetail.OrderNumber -= 1
                                MoveJobVersionTemplateDetail.OrderNumber += 1

                                JobVersionTemplateDetail.OrderNumber = JobVersionTemplateDetailOrderNumber
                                MoveJobVersionTemplateDetail.OrderNumber = MoveJobVersionTemplateDetailOrderNumber

                                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetail)
                                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, MoveJobVersionTemplateDetail)

                            End If

                        End If

                    Else

                        Reload = False

                    End If

                End Using

            Case "SaveAll"

                For Each GridDataItem In RadGridJobVersionTemplateDetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateJobVersionTemplateDetailOnJobVersionTemplateDetailsTab(GridDataItem)

                Next

            Case "SaveNewRow"

                If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobVersionTemplateDetail = New AdvantageFramework.Database.Entities.JobVersionTemplateDetail
                        JobVersionTemplateDetail.DatabaseTypeID = CType(e.Item.FindControl("DropDownListJobVersionTemplateDetailDatabaseTypeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                        If JobVersionTemplateDetail.DatabaseTypeID <> 12 Then

                            JobVersionTemplateDetailMapping = New AdvantageFramework.Database.Entities.JobVersionTemplateDetail

                            If CType(e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue <> "" Then
                                JobVersionTemplateDetailMapping = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCodeAndMapping(DbContext, Me.DropDownListJobVersionTemplates.SelectedValue, CType(e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue, 0)
                            End If

                            If JobVersionTemplateDetailMapping IsNot Nothing AndAlso JobVersionTemplateDetailMapping.JobTemplateMapping IsNot Nothing Then

                                Me.ShowMessage("This field is already mapped.  Please choose a different field.")
                                Exit Sub

                            End If

                        End If

                        JobVersionTemplateDetail.DbContext = DbContext

                        JobVersionTemplateDetail.JobVersionTemplateCode = DropDownListJobVersionTemplates.SelectedValue
                        JobVersionTemplateDetail.Label = CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailLabelEditTextBox"), TextBox).Text.Trim

                        If DirectCast(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked Then

                            JobVersionTemplateDetail.IsInactive = 0

                        Else

                            JobVersionTemplateDetail.IsInactive = 1

                        End If

                        If JobVersionTemplateDetail.DatabaseTypeID <> 12 Then

                            If DirectCast(e.Item.FindControl("CheckBoxIsRequiredEditCheckBox"), CheckBox).Checked Then

                                JobVersionTemplateDetail.IsRequired = 1

                            Else

                                JobVersionTemplateDetail.IsRequired = 0

                            End If

                            JobVersionTemplateDetail.Instructions = CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailInstructionsEditTextBox"), TextBox).Text.Trim
                            JobVersionTemplateDetail.JobTemplateMapping = CType(e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue

                        End If

                        Reload = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Insert(DbContext, JobVersionTemplateDetail)

                    End Using

                End If

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateJobVersionTemplateDetailOnJobVersionTemplateDetailsTab(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailLabelEditTextBox"), TextBox).Text = ""
                    CType(e.Item.FindControl("DropDownListJobVersionTemplateDetailDatabaseTypeEditDropDownList"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("CheckBoxIsInactiveEditCheckBox"), CheckBox).Checked = False
                    CType(e.Item.FindControl("CheckBoxIsRequiredEditCheckBox"), CheckBox).Checked = False
                    CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailInstructionsEditTextBox"), TextBox).Text = ""

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using ReportingDbContext = New AdvantageFramework.Reporting.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                                JobVersionTemplateDetail = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                                If JobVersionTemplateDetail IsNot Nothing Then

                                    AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Delete(DbContext, DataContext, JobVersionTemplateDetail)

                                    DynamicReportList = AdvantageFramework.Reporting.Database.Procedures.DynamicReport.LoadByTemplateCode(ReportingDbContext, JobVersionTemplateDetail.JobVersionTemplateCode).ToList

                                    For Each DynamicReport In DynamicReportList

                                        DynamicReportColumn = AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.LoadByDynamicReportIDAndFieldName(ReportingDbContext, DynamicReport.ID, JobVersionTemplateDetail.Label)

                                        If DynamicReportColumn IsNot Nothing Then

                                            AdvantageFramework.Reporting.Database.Procedures.DynamicReportColumn.Delete(ReportingDbContext, DynamicReportColumn)

                                        End If
                                    Next

                                End If

                            End Using

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            LoadJobVersionTemplateDetailTab(DropDownListJobVersionTemplates.SelectedValue)

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxJobVersionTemplateDetailLabelEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub RadGridJobVersionTemplateDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridJobVersionTemplateDetails.ItemDataBound

        'objects
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim DropDownListJobVersionDatabaseTypes As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListJobVersionJobTemplateMapping As Telerik.Web.UI.RadComboBox = Nothing
        Dim JobVersionDatabaseType As AdvantageFramework.Database.Entities.JobVersionDatabaseType = Nothing
        Dim jv As New JobVersion(Session("ConnString"))
        Dim UserDefinedListValuesDiv As HtmlControls.HtmlControl = Nothing
        Dim dt As DataTable

        If _JobVersionDatabaseTypeList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _JobVersionDatabaseTypeList = (From oEntity In AdvantageFramework.Database.Procedures.JobVersionDatabaseType.Load(DbContext)
                                               Select oEntity.ID,
                                                        oEntity.Description).ToList

            End Using

        End If

        Try

            DropDownListJobVersionDatabaseTypes = DirectCast(e.Item.FindControl("DropDownListJobVersionTemplateDetailDatabaseType"), Telerik.Web.UI.RadComboBox)

            If DropDownListJobVersionDatabaseTypes Is Nothing Then

                DropDownListJobVersionDatabaseTypes = DirectCast(e.Item.FindControl("DropDownListJobVersionTemplateDetailDatabaseTypeEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListJobVersionDatabaseTypes IsNot Nothing Then

                DropDownListJobVersionDatabaseTypes.DataSource = _JobVersionDatabaseTypeList

                DropDownListJobVersionDatabaseTypes.DataBind()

                DropDownListJobVersionDatabaseTypes.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    DropDownListJobVersionDatabaseTypes.SelectedValue = e.Item.DataItem.DatabaseTypeID

                    If DropDownListJobVersionDatabaseTypes.SelectedValue IsNot Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, e.Item.DataItem.DatabaseTypeID)

                            If JobVersionDatabaseType IsNot Nothing Then

                                Try

                                    UserDefinedListValuesDiv = e.Item.FindControl("DivUserDefinedListValues")

                                Catch ex As Exception
                                    UserDefinedListValuesDiv = Nothing
                                Finally


                                End Try

                                If JobVersionDatabaseType.IsList.GetValueOrDefault(0) = 0 Then

                                    If UserDefinedListValuesDiv IsNot Nothing Then

                                        AdvantageFramework.Web.Presentation.Controls.DivHide(UserDefinedListValuesDiv)

                                    End If

                                End If

                            End If

                        End Using

                    End If

                    Dim itemDD As Telerik.Web.UI.RadComboBoxItem = DropDownListJobVersionDatabaseTypes.FindItemByValue(e.Item.DataItem.DatabaseTypeID)
                    DropDownListJobVersionDatabaseTypes.Items.Clear()
                    DropDownListJobVersionDatabaseTypes.Items.Add(itemDD)

                End If

            End If

        Catch ex As Exception
            DropDownListJobVersionDatabaseTypes = Nothing
        End Try


        'Job Template mapping

        Try

            DropDownListJobVersionJobTemplateMapping = DirectCast(e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMapping"), Telerik.Web.UI.RadComboBox)

            If DropDownListJobVersionJobTemplateMapping Is Nothing Then

                DropDownListJobVersionJobTemplateMapping = DirectCast(e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListJobVersionJobTemplateMapping IsNot Nothing Then

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    DropDownListJobVersionJobTemplateMapping.SelectedValue = e.Item.DataItem.JobTemplateMapping

                    If _JobVersionJobTemplateMappingList Is Nothing Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, e.Item.DataItem.DatabaseTypeID)

                            If JobVersionDatabaseType.DatabaseTypeID = 1 Then
                                DropDownListJobVersionJobTemplateMapping.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext)
                                                                                       Where Entity.DatabaseTypeID = 1 Or
                                                                                             Entity.DatabaseTypeID = 6
                                                                                       Select Entity.Code, Entity.Description).ToList
                            Else
                                DropDownListJobVersionJobTemplateMapping.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.LoadByCodeandDatabaseTypeID(DbContext, JobVersionDatabaseType.DatabaseTypeID)
                                                                                       Select Entity.Code, Entity.Description).ToList
                            End If

                            'dt = jv.GetJobTemplateItems(JobVersionDatabaseType.DatabaseTypeID, e.Item.DataItem.DatabaseTypeID)

                        End Using

                    End If

                    DropDownListJobVersionJobTemplateMapping.DataBind()

                    DropDownListJobVersionJobTemplateMapping.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                    If DropDownListJobVersionJobTemplateMapping.Items.Count = 1 Then
                        DropDownListJobVersionJobTemplateMapping.Visible = False
                    Else
                        DropDownListJobVersionJobTemplateMapping.Visible = True
                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListJobVersionDatabaseTypes = Nothing
        End Try

        Try

            ImageButtonDelete = DirectCast(e.Item.FindControl("ImageButtonDelete"), ImageButton)

            If ImageButtonDelete IsNot Nothing Then

                ImageButtonDelete.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")

            End If

        Catch ex As Exception
            ImageButtonDelete = Nothing
        End Try

        Try

            Dim CheckBoxIsRequired As CheckBox = e.Item.FindControl("CheckBoxIsRequired")
            If CheckBoxIsRequired IsNot Nothing Then CheckBoxIsRequired.Visible = e.Item.DataItem.DatabaseTypeID <> 12

            Dim TextBoxJobVersionTemplateDetailInstructions As TextBox = e.Item.FindControl("TextBoxJobVersionTemplateDetailInstructions")
            If TextBoxJobVersionTemplateDetailInstructions IsNot Nothing Then TextBoxJobVersionTemplateDetailInstructions.Visible = e.Item.DataItem.DatabaseTypeID <> 12

            Dim DropDownListJobVersionTemplateDetailJobTemplateMapping As RadComboBox = e.Item.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMapping")
            If DropDownListJobVersionTemplateDetailJobTemplateMapping IsNot Nothing Then DropDownListJobVersionTemplateDetailJobTemplateMapping.Visible = e.Item.DataItem.DatabaseTypeID <> 12

            Dim DivUserDefinedListValues As HtmlControls.HtmlControl = e.Item.FindControl("DivUserDefinedListValues")
            If DivUserDefinedListValues IsNot Nothing Then DivUserDefinedListValues.Visible = e.Item.DataItem.DatabaseTypeID <> 12


        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridJobVersionTemplates_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobVersionTemplates.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridJobVersionTemplates.DataSource = LoadJobVersionTemplates(DbContext, False).ToList
            RadGridJobVersionTemplates.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridJobVersionTemplates.PageSize = MiscFN.LoadPageSize(Me.RadGridJobVersionTemplates.ID)

    End Sub
    Private Sub RadGridJobVersionTemplates_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridJobVersionTemplates.PageIndexChanged

        Me.CurrentPageNumber = e.NewPageIndex
        Me.RadGridJobVersionTemplates.Rebind()

    End Sub
    Private Sub RadGridJobVersionTemplates_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridJobVersionTemplates.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridJobVersionTemplates.ID, e.NewPageSize)

    End Sub
    Private Sub RadGridJobVersionTemplateDetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridJobVersionTemplateDetails.NeedDataSource
        'objects
        Dim JobVersionTempCode As String = ""
        Dim JobVersionTemplate As AdvantageFramework.Database.Entities.JobVersionTemplate = Nothing

        If DropDownListJobVersionTemplates.SelectedValue IsNot Nothing AndAlso DropDownListJobVersionTemplates.SelectedValue <> "" Then

            JobVersionTempCode = DropDownListJobVersionTemplates.SelectedValue

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                JobVersionTemplate = AdvantageFramework.Database.Procedures.JobVersionTemplate.LoadByJobVersionTemplateCode(DbContext, JobVersionTempCode)

                If JobVersionTemplate IsNot Nothing Then

                    If JobVersionTemplate.IsInactive = 1 Then

                        CheckBoxJobVersionTemplateIsInactive.Checked = True

                    Else

                        CheckBoxJobVersionTemplateIsInactive.Checked = False

                    End If

                    RadGridJobVersionTemplateDetails.DataSource = (From JobVersionTemplateDetail In AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateCode(DbContext, JobVersionTemplate.Code).OrderBy(Function(Entity) Entity.OrderNumber).ToList
                                                                   Select JobVersionTemplateDetail.ID,
                                                                          JobVersionTemplateDetail.JobVersionTemplateCode,
                                                                          JobVersionTemplateDetail.DatabaseTypeID,
                                                                          JobVersionTemplateDetail.Label,
                                                                          JobVersionTemplateDetail.OrderNumber,
                                                                          JobVersionTemplateDetail.IsRequired,
                                                                          [IsInactive] = Not CBool(JobVersionTemplateDetail.IsInactive.GetValueOrDefault(0)),
                                                                          JobVersionTemplateDetail.Instructions,
                                                                          JobVersionTemplateDetail.JobTemplateMapping).ToList

                    RadGridJobVersionTemplateDetails.MasterTableView.IsItemInserted = True

                End If

            End Using

        End If

    End Sub
    Public Sub RadComboBoxItem_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)
        Try

            Dim RadComboBoxJobVersionTemplateDetailDatabaseType As RadComboBox = sender

            Dim edititem As GridDataInsertItem
            Dim item As GridItem

            Dim JobTemplateMappingRadComboBox As RadComboBox
            Dim RequiredCheckBox As CheckBox
            Dim InstructionsTextBox As TextBox

            Dim JobVersionDatabaseType As AdvantageFramework.Database.Entities.JobVersionDatabaseType = Nothing
            Dim jv As New JobVersion(Session("ConnString"))
            Dim dt As DataTable

            Try

                edititem = RadComboBoxJobVersionTemplateDetailDatabaseType.NamingContainer

            Catch ex As Exception
                edititem = Nothing
            End Try

            Try
                If edititem Is Nothing Then

                    item = RadComboBoxJobVersionTemplateDetailDatabaseType.NamingContainer

                Else

                    JobTemplateMappingRadComboBox = edititem.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMappingEditDropDownList")
                    RequiredCheckBox = edititem.FindControl("CheckBoxIsRequiredEditCheckBox")
                    InstructionsTextBox = edititem.FindControl("TextBoxJobVersionTemplateDetailInstructionsEditTextBox")

                End If
            Catch ex As Exception
            End Try

            If item Is Nothing AndAlso JobTemplateMappingRadComboBox Is Nothing Then

                JobTemplateMappingRadComboBox = edititem.FindControl("DropDownListJobVersionTemplateDetailJobTemplateMapping")
                RequiredCheckBox = edititem.FindControl("CheckBoxIsRequired")
                InstructionsTextBox = edititem.FindControl("TextBoxJobVersionTemplateDetailInstructions")

            End If

            Try

                If JobTemplateMappingRadComboBox IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        JobVersionDatabaseType = AdvantageFramework.Database.Procedures.JobVersionDatabaseType.LoadByJobVersionDatabaseTypeID(DbContext, RadComboBoxJobVersionTemplateDetailDatabaseType.SelectedValue)

                        If JobVersionDatabaseType IsNot Nothing Then
                            If JobVersionDatabaseType.DatabaseTypeID = 1 Then
                                JobTemplateMappingRadComboBox.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.Load(DbContext)
                                                                            Where Entity.DatabaseTypeID = 1 Or
                                                                                    Entity.DatabaseTypeID = 6
                                                                            Select Entity.Code, Entity.Description).ToList
                            Else
                                JobTemplateMappingRadComboBox.DataSource = (From Entity In AdvantageFramework.Database.Procedures.JobTemplateItem.LoadByCodeandDatabaseTypeID(DbContext, JobVersionDatabaseType.DatabaseTypeID)
                                                                            Select Entity.Code, Entity.Description).ToList
                            End If

                            'JobTemplateMappingRadComboBox.DataSource = jv.GetJobTemplateItems(JobVersionDatabaseType.DatabaseTypeID, RadComboBoxJobVersionTemplateDetailDatabaseType.SelectedValue)
                            JobTemplateMappingRadComboBox.DataBind()
                            JobTemplateMappingRadComboBox.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                        Else

                            JobTemplateMappingRadComboBox.Items.Clear()

                        End If

                    End Using

                    If JobTemplateMappingRadComboBox.Items.Count = 1 Then

                        JobTemplateMappingRadComboBox.Visible = False

                    Else

                        JobTemplateMappingRadComboBox.Visible = True

                    End If

                End If
            Catch ex As Exception
                If JobTemplateMappingRadComboBox IsNot Nothing Then JobTemplateMappingRadComboBox.Items.Clear()
            End Try

            If RadComboBoxJobVersionTemplateDetailDatabaseType IsNot Nothing AndAlso RadComboBoxJobVersionTemplateDetailDatabaseType.SelectedItem IsNot Nothing Then

                Dim IsSection As Boolean = RadComboBoxJobVersionTemplateDetailDatabaseType.SelectedItem.Value = "12"

                If RequiredCheckBox IsNot Nothing Then RequiredCheckBox.Visible = Not IsSection
                If InstructionsTextBox IsNot Nothing Then InstructionsTextBox.Visible = Not IsSection
                If JobTemplateMappingRadComboBox IsNot Nothing Then JobTemplateMappingRadComboBox.Visible = Not IsSection

            End If

        Catch ex As Exception
        End Try

    End Sub
    Private Sub RadGridJobVersionTemplateDetails_RowDrop(sender As Object, e As GridDragDropEventArgs) Handles RadGridJobVersionTemplateDetails.RowDrop

        'If String.IsNullOrEmpty(e.HtmlElement) Then

        '    If e.DestDataItem IsNot Nothing AndAlso e.DestDataItem.OwnerGridID = RadGridJobVersionTemplateDetails.ClientID AndAlso
        '        e.DraggedItems IsNot Nothing AndAlso e.DraggedItems(0) IsNot Nothing Then

        '        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

        '            Dim NewIndex As Integer = e.DestDataItem.RowIndex
        '            Dim DroppedID As Integer = CType(e.DestDataItem.GetDataKeyValue("ID"), Integer)
        '            Dim MovedID As Integer = e.DraggedItems(0).GetDataKeyValue("ID")

        '            Dim JobVersionTemplateDetailMoved As AdvantageFramework.Database.Entities.JobVersionTemplateDetail
        '            Dim JobVersionTemplateDetailReplaced As AdvantageFramework.Database.Entities.JobVersionTemplateDetail

        '            JobVersionTemplateDetailMoved = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, MovedID)
        '            JobVersionTemplateDetailReplaced = AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.LoadByJobVersionTemplateDetailID(DbContext, DroppedID)

        '            If JobVersionTemplateDetailMoved IsNot Nothing AndAlso JobVersionTemplateDetailReplaced IsNot Nothing Then

        '                Dim ReplacedOrderNumber As Integer = JobVersionTemplateDetailReplaced.OrderNumber + 1
        '                JobVersionTemplateDetailMoved.OrderNumber = JobVersionTemplateDetailReplaced.OrderNumber
        '                JobVersionTemplateDetailReplaced.OrderNumber = ReplacedOrderNumber

        '                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetailMoved)
        '                AdvantageFramework.Database.Procedures.JobVersionTemplateDetail.Update(DbContext, JobVersionTemplateDetailReplaced)

        '                'DbContext.Database.ExecuteSqlCommand(String.Format("EXEC [dbo].[advsp_job_version_template_resequence] '{0}';", DropDownListJobVersionTemplates.SelectedItem.Value))

        '            End If

        '        End Using

        '        Me.RadGridJobVersionTemplateDetails.Rebind()

        '    End If

        'End If

    End Sub

#End Region

#End Region

End Class