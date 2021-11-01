Imports Telerik.Web.UI

Public Class Maintenance_EstimateTemplate
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _FunctionsList As Generic.IEnumerable(Of Object) = Nothing
    Private _VendorsList As Generic.IEnumerable(Of Object) = Nothing
    Private _EmployeesList As Generic.IEnumerable(Of Object) = Nothing
    Private _ErrorMessage As String = ""

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

#End Region

#Region " Methods "

    Private Function LoadEstimateTemplates(ByRef DbContext As AdvantageFramework.Database.DbContext) As Generic.IEnumerable(Of Object)

        'objects
        Dim EstimateTemplates As Generic.IEnumerable(Of Object) = Nothing

        If CheckBoxShowInactive.Checked Then

            EstimateTemplates = From EstimateTemplate In AdvantageFramework.Database.Procedures.EstimateTemplate.Load(DbContext).ToList
                                Select EstimateTemplate.Code,
                                       EstimateTemplate.Description,
                                       EstimateTemplate.DefaultComment,
                                       [IsInactive] = CBool(EstimateTemplate.IsInactive.GetValueOrDefault(0))
                                Order By
                                    Description

        Else

            EstimateTemplates = From EstimateTemplate In AdvantageFramework.Database.Procedures.EstimateTemplate.LoadAllActive(DbContext).ToList
                                Select EstimateTemplate.Code,
                                       EstimateTemplate.Description,
                                       EstimateTemplate.DefaultComment,
                                       [IsInactive] = CBool(EstimateTemplate.IsInactive.GetValueOrDefault(0))
                                Order By
                                    Description

        End If

        LoadEstimateTemplates = EstimateTemplates

    End Function
    Private Sub LoadEstimateTemplateDetailTab(ByVal EstimateTemplateCode As String)

        'objects
        Dim EstimateTemplates As Generic.IEnumerable(Of Object) = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EstimateTemplates = LoadEstimateTemplates(DbContext)

            DropDownListEstimateTemplates.DataSource = EstimateTemplates

            DropDownListEstimateTemplates.DataBind()

            DropDownListEstimateTemplates.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

            DropDownListCopyEstimateTemplateDetails.DataSource = EstimateTemplates

            DropDownListCopyEstimateTemplateDetails.DataBind()

            DropDownListCopyEstimateTemplateDetails.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))

        End Using

        Try

            If EstimateTemplateCode <> "" Then

                DropDownListEstimateTemplates.SelectedValue = EstimateTemplateCode

            End If

        Catch ex As Exception

            If DropDownListEstimateTemplates.Items.Count > 0 Then

                DropDownListEstimateTemplates.SelectedIndex = 0

            End If

        End Try

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            Me.RadGridEstimateTemplateDetails.Rebind()

        Else

            CheckBoxIsInactive.Checked = False

            TextBoxEstimateTemplateDescription.Text = ""

            RadGridEstimateTemplateDetails.DataSource = ""
            RadGridEstimateTemplateDetails.DataBind()

        End If

    End Sub
    Private Sub UpdateEstimateTemplateDetail(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
        Dim DropDownListTemplateDetailSuppliedBy As Telerik.Web.UI.RadComboBox = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                EstimateTemplateDetail = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateDetailID(DataContext, GridDataItem.GetDataKeyValue("ID"))

                If EstimateTemplateDetail IsNot Nothing Then

                    EstimateTemplateDetail.FunctionCode = CType(GridDataItem.FindControl("DropDownListTemplateDetailFunction"), Telerik.Web.UI.RadComboBox).SelectedValue

                    DropDownListTemplateDetailSuppliedBy = CType(GridDataItem.FindControl("DropDownListTemplateDetailSuppliedByVendor"), Telerik.Web.UI.RadComboBox)

                    If DropDownListTemplateDetailSuppliedBy.Visible Then

                        EstimateTemplateDetail.SuppliedBy = DropDownListTemplateDetailSuppliedBy.SelectedValue

                    Else

                        DropDownListTemplateDetailSuppliedBy = CType(GridDataItem.FindControl("DropDownListTemplateDetailSuppliedByEmployee"), Telerik.Web.UI.RadComboBox)

                        If DropDownListTemplateDetailSuppliedBy.Visible Then

                            EstimateTemplateDetail.SuppliedBy = DropDownListTemplateDetailSuppliedBy.SelectedValue

                        Else

                            EstimateTemplateDetail.SuppliedBy = ""

                        End If

                    End If

                    EstimateTemplateDetail.Hours = CType(GridDataItem.FindControl("TextBoxTemplateDetailHours"), Telerik.Web.UI.RadNumericTextBox).Value

                    AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Update(DbContext, DataContext, EstimateTemplateDetail)

                End If

            End Using

        End Using

    End Sub
    Private Sub UpdateEstimateTemplateOnEstimateTemplatesTab(ByRef GridDataItem As Telerik.Web.UI.GridDataItem)

        'objects
        Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, GridDataItem.GetDataKeyValue("Code").ToString())

            If EstimateTemplate IsNot Nothing Then

                EstimateTemplate.Description = CType(GridDataItem.FindControl("TextBoxTemplateDescription"), TextBox).Text.Trim
                EstimateTemplate.DefaultComment = CType(GridDataItem.FindControl("TextBoxDefaultComment"), TextBox).Text.Trim

                If DirectCast(GridDataItem.FindControl("CheckBoxIsInactive"), CheckBox).Checked Then

                    EstimateTemplate.IsInactive = 1

                Else

                    EstimateTemplate.IsInactive = 0

                End If

                AdvantageFramework.Database.Procedures.EstimateTemplate.Update(DbContext, EstimateTemplate)

            End If

        End Using

    End Sub
    Private Sub ChangeTabs(ByVal EstimateTemplateCode As String)

        Select Case RadTabStripEstimateTemplates.SelectedIndex

            Case 0

                Me.RadGridEstimateTemplates.Rebind()

            Case 1

                LoadEstimateTemplateDetailTab(EstimateTemplateCode)

        End Select

    End Sub
    Public Sub ShowMessage(ByVal [ErrorMessage] As String)

        Me.ShowMessage(ErrorMessage)

    End Sub

#Region "  Form Event Handlers "

    Private Sub Maintenance_EstimateTemplate_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim TabIndex As Integer = 0
        Dim EstimateTemplateCode As String = ""



        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_ProjectManagement_EstimateTemplates)

            Try

                If Not Request.QueryString("TabIndex") Is Nothing Then

                    TabIndex = CType(Request.QueryString("TabIndex"), Integer)

                End If

                If Not Request.QueryString("EstimateTemplateCode") Is Nothing Then

                    EstimateTemplateCode = CType(Request.QueryString("EstimateTemplateCode"), String)

                End If

            Catch ex As Exception
                TabIndex = 0
                EstimateTemplateCode = ""
            End Try

            Try

                RadTabStripEstimateTemplates.SelectedIndex = TabIndex
                RadMultiPageEstimateTemplates.SelectedIndex = TabIndex

                ChangeTabs(EstimateTemplateCode)

            Catch ex As Exception

            End Try

        End If

    End Sub
    Private Sub Maintenance_EstimateTemplate_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete
        'Try
        '    If _ErrorMessage <> "" Then
        '        Me.ShowMessage(_ErrorMessage)
        '    End If
        'Catch ex As Exception

        'End Try
    End Sub
    Protected Overrides Sub RaisePostBackEvent(ByVal sourceControl As System.Web.UI.IPostBackEventHandler, ByVal eventArgument As String)

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        MyBase.RaisePostBackEvent(sourceControl, eventArgument)

        If sourceControl Is RadGridEstimateTemplates AndAlso (eventArgument.IndexOf("IndexOfRowDoubleClicked") <> -1) Then

            GridDataItem = RadGridEstimateTemplates.Items(Integer.Parse(eventArgument.Split(":"c)(1)))

            If GridDataItem IsNot Nothing Then

                Response.Redirect([String].Format("Maintenance_EstimateTemplate.aspx?TabIndex={0}&EstimateTemplateCode={1}", 1, GridDataItem.GetDataKeyValue("Code")))

            End If

        End If

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub DropDownListTemplateDetailFunctionSelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)

        'objects
        Dim GridItem As Telerik.Web.UI.GridItem = Nothing
        Dim FunctionCode As String = ""
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing

        Try

            GridItem = CType(CType(sender, Telerik.Web.UI.RadComboBox).Parent.Parent, Telerik.Web.UI.GridItem)

            If GridItem.IsInEditMode Then

                FunctionCode = CType(GridItem.FindControl("DropDownListTemplateDetailFunctionEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

            Else

                FunctionCode = CType(GridItem.FindControl("DropDownListTemplateDetailFunction"), Telerik.Web.UI.RadComboBox).SelectedValue

            End If

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, FunctionCode)

                If [Function] IsNot Nothing Then

                    If [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.V.ToString() Then

                        If GridItem.IsInEditMode Then

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox).Visible = True
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox).Visible = False

                        Else

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendor"), Telerik.Web.UI.RadComboBox).Visible = True
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployee"), Telerik.Web.UI.RadComboBox).Visible = False

                        End If

                    ElseIf [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.E.ToString() Then

                        If GridItem.IsInEditMode Then

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox).Visible = False
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox).Visible = True

                        Else

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendor"), Telerik.Web.UI.RadComboBox).Visible = False
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployee"), Telerik.Web.UI.RadComboBox).Visible = True

                        End If

                    Else

                        If GridItem.IsInEditMode Then

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox).Visible = False
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox).Visible = False

                        Else

                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByVendor"), Telerik.Web.UI.RadComboBox).Visible = False
                            CType(GridItem.FindControl("DropDownListTemplateDetailSuppliedByEmployee"), Telerik.Web.UI.RadComboBox).Visible = False

                        End If

                    End If

                End If

            End Using

        Catch ex As Exception

        End Try

    End Sub
    Private Sub CheckBoxShowInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxShowInactive.CheckedChanged

        'objects
        Dim EstimateTemplateCode As String = ""

        If RadTabStripEstimateTemplates.SelectedIndex = 1 AndAlso DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso
                DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            EstimateTemplateCode = DropDownListEstimateTemplates.SelectedValue

        End If

        ChangeTabs(EstimateTemplateCode)

    End Sub
    Private Sub ImageButtonExport_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonExport.Click

        'objects
        Dim GridView As GridView = Nothing
        Dim DataView As DataView = Nothing
        Dim DataTable As DataTable = Nothing
        Dim NewDataRow As DataRow = Nothing
        Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim [Function] As AdvantageFramework.Database.Entities.Function = Nothing
        Dim Vendor As AdvantageFramework.Database.Entities.Vendor = Nothing

        Select Case RadTabStripEstimateTemplates.SelectedIndex

            Case 0

                DataTable = New DataTable

                DataTable.Columns.Add("Code")
                DataTable.Columns.Add("Description")
                DataTable.Columns.Add("Active")

                RadGridEstimateTemplates.AllowPaging = False

                Me.RadGridEstimateTemplates.Rebind()

                For Each GridDataItem In RadGridEstimateTemplates.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

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

                'AdvantageFramework.Web.Exporting.ToExcel("Estimate Templates.xls", GridView)<--- This doesn' work
                Me.DeliverGrid(DataTable, "Estimate Templates") '<--- This does, please don't change unless you test!!!!

                RadGridEstimateTemplates.AllowPaging = True

                Me.RadGridEstimateTemplates.Rebind()

            Case 1

                If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

                    DataTable = New DataTable

                    DataTable.Columns.Add("Function")
                    DataTable.Columns.Add("Supplied By")
                    DataTable.Columns.Add("Qty/Hours")

                    RadGridEstimateTemplateDetails.AllowPaging = False

                    Me.RadGridEstimateTemplateDetails.Rebind()

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        For Each GridDataItem In RadGridEstimateTemplateDetails.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                            NewDataRow = DataTable.Rows.Add()

                            [Function] = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, GridDataItem.DataItem.FunctionCode)

                            If [Function] IsNot Nothing Then

                                NewDataRow(0) = [Function].Description

                                If [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.E.ToString() Then

                                    Employee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, GridDataItem.DataItem.SuppliedBy)

                                    If Employee IsNot Nothing Then

                                        NewDataRow(1) = Employee.ToString

                                    End If

                                ElseIf [Function].Type = AdvantageFramework.Database.Entities.FunctionTypes.V.ToString() Then

                                    Vendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, GridDataItem.DataItem.SuppliedBy)

                                    If Vendor IsNot Nothing Then

                                        NewDataRow(1) = Vendor.Name

                                    End If

                                Else

                                    NewDataRow(1) = ""

                                End If

                            End If

                            NewDataRow(2) = FormatNumber(GridDataItem.DataItem.Hours, 2)

                        Next

                    End Using

                    'DataView = New DataView(DataTable)

                    'GridView = New GridView

                    'GridView.DataSource = DataView
                    'GridView.DataBind()

                    'AdvantageFramework.Web.Exporting.ToExcel("Estimate Template Details.xls", GridView) <--- This doesn' work
                    Me.DeliverGrid(DataTable, "Estimate Template Details") '<--- This does, please don't change unless you test!!!!

                    RadGridEstimateTemplateDetails.AllowPaging = True

                    Me.RadGridEstimateTemplateDetails.Rebind()

                End If

        End Select

    End Sub
    Private Sub RadGridEstimateTemplates_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimateTemplates.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridEstimateTemplates.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridEstimateTemplates.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateEstimateTemplateOnEstimateTemplatesTab(GridDataItem)

                Next

            Case "SaveNewRow"

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateTemplate = New AdvantageFramework.Database.Entities.EstimateTemplate

                    EstimateTemplate.DbContext = DbContext

                    EstimateTemplate.Code = CType(e.Item.FindControl("TextBoxTemplateCodeEdit"), TextBox).Text.Trim
                    EstimateTemplate.Description = CType(e.Item.FindControl("TextBoxTemplateDescriptionEdit"), TextBox).Text.Trim
                    EstimateTemplate.DefaultComment = CType(e.Item.FindControl("TextBoxDefaultCommentEdit"), TextBox).Text.Trim

                    If CType(e.Item.FindControl("CheckBoxIsInactiveEdit"), CheckBox).Checked Then

                        EstimateTemplate.IsInactive = 1

                    Else

                        EstimateTemplate.IsInactive = 0

                    End If

                    Reload = AdvantageFramework.Database.Procedures.EstimateTemplate.Insert(DbContext, EstimateTemplate)

                End Using

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateEstimateTemplateOnEstimateTemplatesTab(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("TextBoxTemplateCodeEdit"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxTemplateDescriptionEdit"), TextBox).Text = ""
                    CType(e.Item.FindControl("TextBoxDefaultCommentEdit"), TextBox).Text = ""
                    CType(e.Item.FindControl("CheckBoxIsInactiveEdit"), CheckBox).Checked = False

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, CurrentGridDataItem.GetDataKeyValue("Code"))

                        If EstimateTemplate IsNot Nothing Then

                            AdvantageFramework.Database.Procedures.EstimateTemplate.Delete(DbContext, EstimateTemplate)

                        End If

                    End Using

                End If

        End Select

        If Reload Then

            If e.CommandName = "SaveNewRow" Then

                MiscFN.ResponseRedirect(String.Format("Maintenance_EstimateTemplate.aspx?TabIndex={0}", RadTabStripEstimateTemplates.SelectedIndex))
                Exit Sub

            Else

                Me.RadGridEstimateTemplates.Rebind()

            End If

        Else

            If e.Item.IsInEditMode Then

                CType(e.Item.FindControl("TextBoxEstimateTemplateCodeEditTextBox"), TextBox).Focus()

            End If

        End If

    End Sub
    Private Sub DropDownListEstimateTemplates_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DropDownListEstimateTemplates.SelectedIndexChanged

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            Me.RadGridEstimateTemplateDetails.Rebind()

        Else

            CheckBoxIsInactive.Checked = False

            TextBoxEstimateTemplateDescription.Text = ""

            RadGridEstimateTemplateDetails.DataSource = ""
            RadGridEstimateTemplateDetails.DataBind()

        End If

    End Sub
    Private Sub RadTabStripEstimateTemplates_TabClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadTabStripEventArgs) Handles RadTabStripEstimateTemplates.TabClick

        ChangeTabs("")

    End Sub
    Private Sub CheckBoxIsInactive_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CheckBoxIsInactive.CheckedChanged

        'objects
        Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, DropDownListEstimateTemplates.SelectedValue)

                If EstimateTemplate IsNot Nothing Then

                    If CheckBoxIsInactive.Checked Then

                        EstimateTemplate.IsInactive = 1

                    Else

                        EstimateTemplate.IsInactive = 0

                    End If

                    AdvantageFramework.Database.Procedures.EstimateTemplate.Update(DbContext, EstimateTemplate)

                End If

            End Using

            LoadEstimateTemplateDetailTab(DropDownListEstimateTemplates.SelectedValue)

        End If

    End Sub
    Private Sub RadGridEstimateTemplateDetails_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridEstimateTemplateDetails.ItemDataBound

        'objects
        Dim DropDownListFunctions As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListVendors As Telerik.Web.UI.RadComboBox = Nothing
        Dim DropDownListEmployees As Telerik.Web.UI.RadComboBox = Nothing
        Dim ImageButtonDelete As System.Web.UI.WebControls.ImageButton = Nothing
        Dim InactiveFunction As AdvantageFramework.Database.Entities.Function = Nothing
        Dim InactiveVendor As AdvantageFramework.Database.Entities.Vendor = Nothing
        Dim InactiveEmployee As AdvantageFramework.Database.Views.Employee = Nothing
        Dim EstimateTemplateDetailFunction As AdvantageFramework.Database.Entities.Function = Nothing

        If _FunctionsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _FunctionsList = (From [Function] In AdvantageFramework.Database.Procedures.Function.LoadAllActive(DbContext)
                                  Select [Function].Code,
                                         [Function].Description).ToList

            End Using

        End If

        If _VendorsList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                _VendorsList = (From Vendor In AdvantageFramework.Database.Procedures.Vendor.LoadAllActiveWithOfficeLimits(DbContext, _Session)
                                Select Vendor.Code,
                                       Vendor.Name).ToList

            End Using

        End If

        If _EmployeesList Is Nothing Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _EmployeesList = (From Employee In AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveEmployeesByUserandOffice(DbContext, SecurityDbContext, _Session.UserCode, _Session.User.EmployeeCode)
                                      Select Employee.Code,
                                         [Name] = Employee.FirstName & " " & Employee.LastName).ToList

                End Using

            End Using

        End If

        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then

            If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    EstimateTemplateDetailFunction = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Item.DataItem.FunctionCode)

                End Using

            End If

        End If

        Try

            DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTemplateDetailFunction"), Telerik.Web.UI.RadComboBox)

            If DropDownListFunctions Is Nothing Then

                DropDownListFunctions = DirectCast(e.Item.FindControl("DropDownListTemplateDetailFunctionEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListFunctions IsNot Nothing Then

                DropDownListFunctions.DataSource = _FunctionsList

                DropDownListFunctions.DataBind()

                DropDownListFunctions.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From [Function] In _FunctionsList
                        Where [Function].Code = e.Item.DataItem.FunctionCode
                        Select [Function]).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveFunction = AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, e.Item.DataItem.FunctionCode)

                            If InactiveFunction IsNot Nothing Then

                                DropDownListFunctions.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveFunction.Description & "*", InactiveFunction.Code))

                                DropDownListFunctions.SelectedValue = InactiveFunction.Code

                            End If

                        End Using

                    Else

                        DropDownListFunctions.SelectedValue = e.Item.DataItem.FunctionCode

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListFunctions = Nothing
        End Try

        Try

            DropDownListVendors = DirectCast(e.Item.FindControl("DropDownListTemplateDetailSuppliedByVendor"), Telerik.Web.UI.RadComboBox)

            If DropDownListVendors Is Nothing Then

                DropDownListVendors = DirectCast(e.Item.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListVendors IsNot Nothing Then

                If EstimateTemplateDetailFunction IsNot Nothing Then

                    If EstimateTemplateDetailFunction.Type <> AdvantageFramework.Database.Entities.FunctionTypes.V.ToString() Then

                        DropDownListVendors.Visible = False

                    End If

                End If

                DropDownListVendors.DataSource = _VendorsList

                DropDownListVendors.DataBind()

                DropDownListVendors.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Vendor In _VendorsList
                        Where Vendor.Code = e.Item.DataItem.SuppliedBy
                        Select Vendor).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveVendor = AdvantageFramework.Database.Procedures.Vendor.LoadByVendorCode(DbContext, e.Item.DataItem.SuppliedBy)

                            If InactiveVendor IsNot Nothing Then

                                DropDownListVendors.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveVendor.Name & "*", InactiveVendor.Code))

                                DropDownListVendors.SelectedValue = InactiveVendor.Code

                            End If

                        End Using

                    Else

                        DropDownListVendors.SelectedValue = e.Item.DataItem.SuppliedBy

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListVendors = Nothing
        End Try

        Try

            DropDownListEmployees = DirectCast(e.Item.FindControl("DropDownListTemplateDetailSuppliedByEmployee"), Telerik.Web.UI.RadComboBox)

            If DropDownListEmployees Is Nothing Then

                DropDownListEmployees = DirectCast(e.Item.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox)

            End If

            If DropDownListEmployees IsNot Nothing Then

                If EstimateTemplateDetailFunction IsNot Nothing Then

                    If EstimateTemplateDetailFunction.Type <> AdvantageFramework.Database.Entities.FunctionTypes.E.ToString() Then

                        DropDownListEmployees.Visible = False

                    End If

                End If

                DropDownListEmployees.DataSource = _EmployeesList

                DropDownListEmployees.DataBind()

                DropDownListEmployees.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("", ""))

                If CType(e.Item, Telerik.Web.UI.GridEditableItem).IsInEditMode = False Then

                    If (From Employee In _EmployeesList
                        Where Employee.Code = e.Item.DataItem.SuppliedBy
                        Select Employee).Any = False Then

                        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            InactiveEmployee = AdvantageFramework.Database.Procedures.EmployeeView.LoadByEmployeeCode(DbContext, e.Item.DataItem.SuppliedBy)

                            If InactiveEmployee IsNot Nothing Then

                                DropDownListEmployees.Items.Insert(1, New Telerik.Web.UI.RadComboBoxItem(InactiveEmployee.FirstName & " " & InactiveEmployee.LastName & "*", InactiveEmployee.Code))

                                DropDownListEmployees.SelectedValue = InactiveEmployee.Code

                            End If

                        End Using

                    Else

                        DropDownListEmployees.SelectedValue = e.Item.DataItem.SuppliedBy

                    End If

                End If

            End If

        Catch ex As Exception
            DropDownListEmployees = Nothing
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
    Private Sub RadGridEstimateTemplates_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridEstimateTemplates.ItemDataBound

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

    Private Sub RadGridEstimateTemplateDetails_ItemCommand(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridEstimateTemplateDetails.ItemCommand

        'objects
        Dim GridEditableItem As Telerik.Web.UI.GridEditableItem = Nothing
        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing
        Dim EstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing
        Dim DropDownListTemplateDetailSuppliedBy As Telerik.Web.UI.RadComboBox = Nothing
        Dim Reload As Boolean = True

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then

            CurrentGridDataItem = RadGridEstimateTemplateDetails.Items(e.Item.ItemIndex)

        End If

        Select Case e.CommandName

            Case "SaveAll"

                For Each GridDataItem In RadGridEstimateTemplateDetails.MasterTableView.Items.OfType(Of Telerik.Web.UI.GridDataItem)()

                    UpdateEstimateTemplateDetail(GridDataItem)

                Next

            Case "SaveNewRow"

                If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            EstimateTemplateDetail = New AdvantageFramework.Database.Entities.EstimateTemplateDetail

                            EstimateTemplateDetail.EstimateTemplateCode = DropDownListEstimateTemplates.SelectedValue
                            EstimateTemplateDetail.FunctionCode = CType(e.Item.FindControl("DropDownListTemplateDetailFunctionEdit"), Telerik.Web.UI.RadComboBox).SelectedValue

                            DropDownListTemplateDetailSuppliedBy = CType(e.Item.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox)

                            If DropDownListTemplateDetailSuppliedBy.Visible Then

                                EstimateTemplateDetail.SuppliedBy = DropDownListTemplateDetailSuppliedBy.SelectedValue

                            Else

                                DropDownListTemplateDetailSuppliedBy = CType(e.Item.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox)

                                If DropDownListTemplateDetailSuppliedBy.Visible Then

                                    EstimateTemplateDetail.SuppliedBy = DropDownListTemplateDetailSuppliedBy.SelectedValue

                                Else

                                    EstimateTemplateDetail.SuppliedBy = ""

                                End If

                            End If

                            EstimateTemplateDetail.Hours = CType(e.Item.FindControl("TextBoxTemplateDetailHoursEdit"), Telerik.Web.UI.RadNumericTextBox).Value

                            Reload = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Insert(DbContext, DataContext, EstimateTemplateDetail)

                        End Using

                    End Using

                End If

            Case "SaveRow"

                If CurrentGridDataItem IsNot Nothing Then

                    UpdateEstimateTemplateDetail(CurrentGridDataItem)

                End If

            Case "CancelNewRow"

                If e.Item IsNot Nothing Then

                    CType(e.Item.FindControl("DropDownListTemplateDetailFunctionEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("DropDownListTemplateDetailSuppliedByEmployeeEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("DropDownListTemplateDetailSuppliedByVendorEdit"), Telerik.Web.UI.RadComboBox).SelectedValue = Nothing
                    CType(e.Item.FindControl("TextBoxTemplateDetailHoursEdit"), Telerik.Web.UI.RadNumericTextBox).Value = 0

                End If

            Case "DeleteRow"

                If CurrentGridDataItem IsNot Nothing Then

                    Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                        Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                            EstimateTemplateDetail = AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateDetailID(DataContext, CurrentGridDataItem.GetDataKeyValue("ID"))

                            If EstimateTemplateDetail IsNot Nothing Then

                                If DataContext.EstimateTemplateDetails.Where(Function(EstTempDet) EstTempDet.EstimateTemplateCode = EstimateTemplateDetail.EstimateTemplateCode).Count = 1 Then

                                    AdvantageFramework.Navigation.ShowMessageBox("Estimate Template must have at least one Estimate Template Detail.")

                                End If

                                AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Delete(DbContext, DataContext, EstimateTemplateDetail)

                            End If

                        End Using

                    End Using

                End If

        End Select

        If Reload Then

            LoadEstimateTemplateDetailTab(DropDownListEstimateTemplates.SelectedValue)

        Else

            CType(e.Item.FindControl("DropDownListTemplateDetailFunctionEdit"), Telerik.Web.UI.RadComboBox).Focus()

        End If

    End Sub
    Private Sub TextBoxEstimateTemplateDescription_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBoxEstimateTemplateDescription.TextChanged

        'objects
        Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, DropDownListEstimateTemplates.SelectedValue)

                If EstimateTemplate IsNot Nothing Then

                    EstimateTemplate.Description = TextBoxEstimateTemplateDescription.Text

                    AdvantageFramework.Database.Procedures.EstimateTemplate.Update(DbContext, EstimateTemplate)

                End If

            End Using

        End If

    End Sub
    Private Sub ImageButtonCopyEstimateTemplateDetails_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles ImageButtonCopyEstimateTemplateDetails.Click

        'objects
        Dim NewEstimateTemplateDetail As AdvantageFramework.Database.Entities.EstimateTemplateDetail = Nothing

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" AndAlso
                DropDownListCopyEstimateTemplateDetails.SelectedValue IsNot Nothing AndAlso DropDownListCopyEstimateTemplateDetails.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    For Each EstimateTemplateDetail In AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateCode(DataContext, DropDownListCopyEstimateTemplateDetails.SelectedValue)

                        NewEstimateTemplateDetail = New AdvantageFramework.Database.Entities.EstimateTemplateDetail

                        NewEstimateTemplateDetail.EstimateTemplateCode = DropDownListEstimateTemplates.SelectedValue
                        NewEstimateTemplateDetail.FunctionCode = EstimateTemplateDetail.FunctionCode
                        NewEstimateTemplateDetail.SuppliedBy = EstimateTemplateDetail.SuppliedBy
                        NewEstimateTemplateDetail.Hours = EstimateTemplateDetail.Hours
                        NewEstimateTemplateDetail.NetAmount = EstimateTemplateDetail.NetAmount

                        AdvantageFramework.Database.Procedures.EstimateTemplateDetail.Insert(DbContext, DataContext, NewEstimateTemplateDetail)

                    Next

                End Using

            End Using

            LoadEstimateTemplateDetailTab(DropDownListEstimateTemplates.SelectedValue)

        End If

    End Sub

#End Region

#End Region

    Private Sub RadGridEstimateTemplates_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimateTemplates.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            RadGridEstimateTemplates.DataSource = LoadEstimateTemplates(DbContext).ToList

            RadGridEstimateTemplates.MasterTableView.IsItemInserted = True

        End Using

        Me.RadGridEstimateTemplates.PageSize = MiscFN.LoadPageSize(Me.RadGridEstimateTemplates.ID)

    End Sub

    Private Sub RadGridEstimateTemplates_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridEstimateTemplates.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridEstimateTemplates.ID, e.NewPageSize)

    End Sub

    Private Sub RadGridEstimateTemplateDetails_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridEstimateTemplateDetails.NeedDataSource

        'objects
        Dim EstimateTemplate As AdvantageFramework.Database.Entities.EstimateTemplate = Nothing

        If DropDownListEstimateTemplates.SelectedValue IsNot Nothing AndAlso DropDownListEstimateTemplates.SelectedValue.ToString() <> "" Then

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Using DataContext = New AdvantageFramework.Database.DataContext(Session("ConnString").ToString(), Session("UserCode").ToString())

                    EstimateTemplate = AdvantageFramework.Database.Procedures.EstimateTemplate.LoadByEstimateTemplateCode(DbContext, DropDownListEstimateTemplates.SelectedValue)

                    If EstimateTemplate IsNot Nothing Then

                        TextBoxEstimateTemplateDescription.Text = EstimateTemplate.Description

                        If EstimateTemplate.IsInactive.GetValueOrDefault(0) = 1 Then

                            CheckBoxIsInactive.Checked = True

                        Else

                            CheckBoxIsInactive.Checked = False

                        End If

                        RadGridEstimateTemplateDetails.DataSource = (From EstimateTemplateDetail In AdvantageFramework.Database.Procedures.EstimateTemplateDetail.LoadByEstimateTemplateCode(DataContext, EstimateTemplate.Code)
                                                                     Select EstimateTemplateDetail.ID,
                                                                            EstimateTemplateDetail.FunctionCode,
                                                                            AdvantageFramework.Database.Procedures.Function.LoadByFunctionCode(DbContext, EstimateTemplateDetail.FunctionCode).Description,
                                                                            EstimateTemplateDetail.SuppliedBy,
                                                                            [Hours] = EstimateTemplateDetail.Hours).ToList

                        RadGridEstimateTemplateDetails.MasterTableView.IsItemInserted = True

                    End If

                End Using

            End Using

        End If

        Me.RadGridEstimateTemplateDetails.PageSize = MiscFN.LoadPageSize(Me.RadGridEstimateTemplateDetails.ID)

    End Sub

    Private Sub RadGridEstimateTemplateDetails_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridEstimateTemplateDetails.PageSizeChanged

        MiscFN.SavePageSize(Me.RadGridEstimateTemplateDetails.ID, e.NewPageSize)

    End Sub


End Class
