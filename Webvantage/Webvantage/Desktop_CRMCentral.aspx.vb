Imports Telerik.Web.UI

Public Class Desktop_CRMCentral
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _DbContext As AdvantageFramework.Database.DbContext = Nothing

#End Region

#Region " Properties "

    Private Shared Property GridPageIndex As Integer?
        Get
            GridPageIndex = HttpContext.Current.Session("CRMCentral_PageIndex_GridSelect")
        End Get
        Set(value As Integer?)
            HttpContext.Current.Session("CRMCentral_PageIndex_GridSelect") = value
        End Set
    End Property
    Private Shared Property SelectedClientCode As String
        Get
            SelectedClientCode = HttpContext.Current.Session("CRMCentral_ClientCode_GridSelect")
        End Get
        Set(value As String)
            HttpContext.Current.Session("CRMCentral_ClientCode_GridSelect") = value
        End Set
    End Property
    Private Shared Property SelectedDivisionCode As String
        Get
            SelectedDivisionCode = HttpContext.Current.Session("CRMCentral_DivisionCode_GridSelect")
        End Get
        Set(value As String)
            HttpContext.Current.Session("CRMCentral_DivisionCode_GridSelect") = value
        End Set
    End Property
    Private Shared Property SelectedProductCode As String
        Get
            SelectedProductCode = HttpContext.Current.Session("CRMCentral_ProductCode_GridSelect")
        End Get
        Set(value As String)
            HttpContext.Current.Session("CRMCentral_ProductCode_GridSelect") = value
        End Set
    End Property

#End Region

#Region " Methods "

    Private Sub EnableOrDisableActions()

        RadToolBarButtonPrint.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0)
        RadToolBarButtonClient.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonDivision.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonProduct.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonCompanyProfile.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonActivitySummary.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonContracts.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)))
        RadToolBarButtonAddDiary.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0 AndAlso Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)) AndAlso Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client))
        RadToolBarButtonAddActivity.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0)

        Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If AdvantageFramework.Security.DoesUserHaveAccessToModule(SecurityDbContext, AdvantageFramework.Security.Application.Advantage, AdvantageFramework.Security.Modules.Maintenance_Client_ClientContact.ToString, _Session.UserCode) Then

                RadToolBarButtonClientContacts.Enabled = (RadGridCRMCentralProducts.SelectedItems.Count > 0)

            Else

                RadToolBarButtonClientContacts.Enabled = False

            End If

        End Using

    End Sub
    Private Sub RefreshColumnOrderAndVisibility()

        'objects
        Dim VisibleString As String = ""

        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString)
        HideOrShowColumn(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString)

        For Each GridColumn In RadGridCRMCentralProducts.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()

            If GridColumn.Display = True Then

                If String.IsNullOrEmpty(VisibleString) = False Then

                    VisibleString = VisibleString & ", "

                End If

                VisibleString = VisibleString & "'" & GridColumn.UniqueName & "'"

            End If

        Next

        If String.IsNullOrEmpty(VisibleString) = False Then

            Me.AddJavascriptToPage("var visiblecolumns = [" & VisibleString & "]; ModifyColumns(visiblecolumns); ")

        End If

    End Sub
    Private Sub HideOrShowColumn(ByVal FieldName As String)

        'objects
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim GridColumnOption As AdvantageFramework.CRMCentral.GridColumnOptions = AdvantageFramework.CRMCentral.GridColumnOptions.Both

        GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe(FieldName)

        If GridColumn IsNot Nothing Then

            If RadToolBarButtonBoth.Checked Then

                GridColumnOption = AdvantageFramework.CRMCentral.GridColumnOptions.Both

            ElseIf RadToolBarButtonCodes.Checked Then

                GridColumnOption = AdvantageFramework.CRMCentral.GridColumnOptions.Codes

            ElseIf RadToolBarButtonDescriptions.Checked Then

                GridColumnOption = AdvantageFramework.CRMCentral.GridColumnOptions.Descriptions

            End If

            GridColumn.Display = AdvantageFramework.CRMCentral.IsColumnVisible(FieldName, GridColumnOption)

        End If

    End Sub
    Private Sub LoadColumnFiltersFromSession()

        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString)
        LoadColumnFilterFromSession(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString)

    End Sub
    Private Sub LoadColumnFilterFromSession(ByVal ColumnUniqueName As String)

        'objects
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim CurrentFilterValueKey As String = Nothing
        Dim CurrentFilterFunctionKey As String = Nothing
        Dim CurrentFilterFunction As Telerik.Web.UI.GridKnownFunction = Telerik.Web.UI.GridKnownFunction.NoFilter
        Dim CurrentFilterValue As String = ""

        GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe(ColumnUniqueName)

        If GridColumn IsNot Nothing Then

            CurrentFilterValueKey = "CRMCentral_" & ColumnUniqueName & "_Value"
            CurrentFilterFunctionKey = "CRMCentral_" & ColumnUniqueName & "_Function"

            Try

                If Session(CurrentFilterFunctionKey) IsNot Nothing Then

                    CurrentFilterFunction = DirectCast(Session(CurrentFilterFunctionKey), Telerik.Web.UI.GridKnownFunction)

                End If

            Catch ex As Exception
                CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.NoFilter
            End Try

            Try

                If Session(CurrentFilterValueKey) IsNot Nothing Then

                    CurrentFilterValue = Session(CurrentFilterValueKey).ToString

                End If

            Catch ex As Exception
                CurrentFilterValue = ""
            End Try

            If String.IsNullOrWhiteSpace(CurrentFilterValue) = False AndAlso CurrentFilterFunction <> Telerik.Web.UI.GridKnownFunction.NoFilter Then

                GridColumn.CurrentFilterValue = CurrentFilterValue
                GridColumn.CurrentFilterFunction = CurrentFilterFunction

            End If

        End If

    End Sub
    Private Sub SaveColumnFilterSessionVariables()

        'objects
        Dim GridColumnList As String() = Nothing
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing

        GridColumnList = {AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString}

        For Each GridColumnName In GridColumnList

            GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe(GridColumnName)

            If GridColumn IsNot Nothing Then

                Session("CRMCentral_" & GridColumnName & "_Value") = GridColumn.CurrentFilterValue
                Session("CRMCentral_" & GridColumnName & "_Function") = GridColumn.CurrentFilterFunction

            End If

        Next

    End Sub
    Private Function DoSelectRow() As Boolean

        'objects
        Dim SelectRow As Boolean = False

        If Me.GridPageIndex.HasValue AndAlso
           String.IsNullOrWhiteSpace(SelectedClientCode) = False AndAlso
           String.IsNullOrWhiteSpace(SelectedDivisionCode) = False AndAlso
           String.IsNullOrWhiteSpace(SelectedProductCode) = False Then

            SelectRow = True

        End If

        DoSelectRow = SelectRow

    End Function

#Region "  Form Event Handlers "

    Public Shared Sub SetGridSelectVariables(ByVal ClientCode As String, ByVal DivisionCode As String, ByVal ProductCode As String)

        SelectedClientCode = ClientCode
        SelectedDivisionCode = DivisionCode
        SelectedProductCode = ProductCode

    End Sub
    Public Shared Sub ResetSessionVariables()

        'objects
        Dim GridColumnList As String() = Nothing

        GridColumnList = {AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.OfficeName.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutiveCode.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DefaultAccountExecutive.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.NewBusiness.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.IsInactive.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityDate.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivityType.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastActivitySubject.ToString,
                          AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.LastContactDate.ToString}

        For Each GridColumnName In GridColumnList

            HttpContext.Current.Session("CRMCentral_" & GridColumnName & "_Value") = Nothing
            HttpContext.Current.Session("CRMCentral_" & GridColumnName & "_Function") = Nothing

        Next

        SetGridSelectVariables(Nothing, Nothing, Nothing)
        GridPageIndex = Nothing

    End Sub
    Private Sub Desktop_CRMCentral_Init(sender As Object, e As EventArgs) Handles Me.Init

        _DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

    End Sub
    Private Sub Desktop_CRMCentral_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        'objects
        Dim GridColumnOption As AdvantageFramework.CRMCentral.GridColumnOptions = AdvantageFramework.CRMCentral.GridColumnOptions.Both

        If Me.IsPostBack = False Then

            GridColumnOption = AdvantageFramework.CRMCentral.LoadDataGridViewUserSetting(_Session)

            If DoSelectRow() Then

                RadGridCRMCentralProducts.CurrentPageIndex = GridPageIndex.GetValueOrDefault(0)

            End If

            Select Case GridColumnOption

                Case AdvantageFramework.CRMCentral.GridColumnOptions.Both

                    RadToolBarButtonBoth.Checked = True
                    RadToolBarButtonCodes.Checked = False
                    RadToolBarButtonDescriptions.Checked = False

                Case AdvantageFramework.CRMCentral.GridColumnOptions.Codes

                    RadToolBarButtonBoth.Checked = False
                    RadToolBarButtonCodes.Checked = True
                    RadToolBarButtonDescriptions.Checked = False

                Case AdvantageFramework.CRMCentral.GridColumnOptions.Descriptions

                    RadToolBarButtonBoth.Checked = False
                    RadToolBarButtonCodes.Checked = False
                    RadToolBarButtonDescriptions.Checked = True

            End Select

        Else

            If Me.EventTarget = "Export" Then

                Me.ExportGridToExcel()

            End If

        End If

        Try

            CType(RadGridCRMCentralProducts.Columns.FindByUniqueName("LastContactDate"), Telerik.Web.UI.GridTemplateColumn).ReadOnly = Not (Convert.ToBoolean(Me.CheckModuleAccess(AdvantageFramework.Security.Modules.Maintenance_Client_Client, False)) AndAlso Me.UserCanUpdateInModule(AdvantageFramework.Security.Modules.Maintenance_Client_Client))

        Catch ex As Exception
        End Try

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridCRMCentralProducts)


    End Sub
    Private Sub Desktop_CRMCentral_LoadComplete(sender As Object, e As EventArgs) Handles Me.LoadComplete

        EnableOrDisableActions()

    End Sub
    Private Sub Desktop_CRMCentral_Unload(sender As Object, e As EventArgs) Handles Me.Unload

        AdvantageFramework.Database.CloseDbContext(_DbContext)

    End Sub

#End Region

#Region "  Control Event Handlers "

    Protected Sub ASPxDateEditLastContactDate_OnValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        'objects
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
        Dim LastContactDate As Nullable(Of Date) = Nothing
        Dim Activity As AdvantageFramework.Database.Entities.Activity = Nothing
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        Try

            GridDataItem = DirectCast(DirectCast(sender, Telerik.Web.UI.RadDatePicker).Parent.Parent, Telerik.Web.UI.GridDataItem)

        Catch ex As Exception

        End Try

        If GridDataItem IsNot Nothing Then

            ClientCode = GridDataItem(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString).Text
            DivisionCode = GridDataItem(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString).Text
            ProductCode = GridDataItem(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString).Text

            Try

                LastContactDate = CType(sender, Telerik.Web.UI.RadDatePicker).SelectedDate

            Catch ex As Exception
                LastContactDate = Nothing
            End Try

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Activity = AdvantageFramework.Database.Procedures.Activity.LoadByClientAndDivisionAndProductCode(DbContext, ClientCode, DivisionCode, ProductCode)

                    If Activity IsNot Nothing Then

                        Activity.LastContactDate = LastContactDate

                        Activity.ModifiedByUserCode = _Session.UserCode
                        Activity.ModifiedDate = Now

                        AdvantageFramework.Database.Procedures.Activity.Update(DbContext, Activity)

                    Else

                        Activity = New AdvantageFramework.Database.Entities.Activity

                        Activity.LastContactDate = LastContactDate

                        Activity.ClientCode = ClientCode
                        Activity.DivisionCode = DivisionCode
                        Activity.ProductCode = ProductCode

                        Activity.CreatedByUserCode = _Session.UserCode
                        Activity.CreateDate = Now

                        AdvantageFramework.Database.Procedures.Activity.Insert(DbContext, Activity)

                    End If

                End Using

            Catch ex As Exception
                Activity = Nothing
            End Try

        End If

    End Sub
    Private Sub RadToolBarCRMCentral_ButtonClick(sender As Object, e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolBarCRMCentral.ButtonClick

        'objects
        Dim ClientCode As String = ""
        Dim DivisionCode As String = ""
        Dim ProductCode As String = ""
        Dim GridColumnOption As AdvantageFramework.CRMCentral.GridColumnOptions = AdvantageFramework.CRMCentral.GridColumnOptions.Both

        If e.Item.Value = "Bookmark" Then
            Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
            Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))

            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()
            qs.Page = "Desktop_CRMCentral.aspx"
            qs.Add("bm", "1")

            With b
                .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_CRMCentral
                .UserCode = Session("UserCode")
                .Name = "CRM Central"
                .Description = "CRM Central"
                .PageURL = qs.ToString(True)
            End With

            Dim s As String = ""
            If BmMethods.SaveBookmark(b, s) = False Then
                Me.ShowMessage(s)
            End If

        ElseIf e.Item.Value = "ClearFilter" Then

            For Each column As GridColumn In Me.RadGridCRMCentralProducts.MasterTableView.Columns
                column.CurrentFilterFunction = GridKnownFunction.NoFilter
                column.CurrentFilterValue = String.Empty
            Next

            Me.RadGridCRMCentralProducts.MasterTableView.FilterExpression = String.Empty
            Me.RadGridCRMCentralProducts.Rebind()

        ElseIf e.Item.Value = RadToolBarButtonExport.Value Then

            ExportGridToExcel()

        Else

            If e.Item.Value = RadToolBarButtonBoth.Value Then

                AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(_Session, AdvantageFramework.CRMCentral.GridColumnOptions.Both)
                RefreshColumnOrderAndVisibility()

            ElseIf e.Item.Value = RadToolBarButtonCodes.Value Then

                AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(_Session, AdvantageFramework.CRMCentral.GridColumnOptions.Codes)
                RefreshColumnOrderAndVisibility()

            ElseIf e.Item.Value = RadToolBarButtonDescriptions.Value Then

                AdvantageFramework.CRMCentral.SaveDataGridViewUserSetting(_Session, AdvantageFramework.CRMCentral.GridColumnOptions.Descriptions)
                RefreshColumnOrderAndVisibility()

            Else

                If RadGridCRMCentralProducts.SelectedItems.Count = 1 Then

                    GridPageIndex = RadGridCRMCentralProducts.CurrentPageIndex

                    SaveColumnFilterSessionVariables()

                    ClientCode = CType(RadGridCRMCentralProducts.SelectedItems(0), Telerik.Web.UI.GridDataItem)(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ClientCode.ToString).Text
                    DivisionCode = CType(RadGridCRMCentralProducts.SelectedItems(0), Telerik.Web.UI.GridDataItem)(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.DivisionCode.ToString).Text
                    ProductCode = CType(RadGridCRMCentralProducts.SelectedItems(0), Telerik.Web.UI.GridDataItem)(AdvantageFramework.CRMCentral.Classes.CRMActivity.Properties.ProductCode.ToString).Text

                    Select Case e.Item.Value

                        Case RadToolBarButtonPrint.Value

                            Me.OpenWindow("Product Reports", "Reporting_ProductReports.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonClient.Value

                            Me.OpenWindow("Client", "Maintenance_ClientEdit.aspx?ClientCode=" & ClientCode)

                        Case RadToolBarButtonDivision.Value

                            Me.OpenWindow("Division", "Maintenance_DivisionEdit.aspx?ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode)

                        Case RadToolBarButtonProduct.Value

                            Me.OpenWindow("Product", "Maintenance_ProductEdit.aspx?ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonCompanyProfile.Value

                            Me.OpenWindow("Company Profile", "Maintenance_CompanyProfile.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonActivitySummary.Value

                            Me.OpenWindow("Activity Summary", "Maintenance_ActivitySummary.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonContracts.Value

                            Me.OpenWindow("Contracts / Opportunities", "Maintenance_ContractManager.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonClientContacts.Value

                            Me.OpenWindow("Client Contacts", "Maintenance_ClientContactManager.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonAddDiary.Value

                            Me.OpenWindow("Add Diary", "Maintenance_DiaryEdit.aspx?Caller=Desktop_CRMCentral&Mode=Add&AlertTypeID=11&AlertCategoryID=58&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                        Case RadToolBarButtonAddActivity.Value

                            Me.OpenWindow("Add Activity", "Calendar_NewActivity.aspx?Caller=Desktop_CRMCentral&ClientCode=" & ClientCode & "&DivisionCode=" & DivisionCode & "&ProductCode=" & ProductCode)

                    End Select

                End If

            End If

        End If

    End Sub
    Private Sub RadGridProducts_GridExporting(sender As Object, e As Telerik.Web.UI.GridExportingArgs) Handles RadGridCRMCentralProducts.GridExporting

        'objects
        Dim GridFilteringItem As Telerik.Web.UI.GridFilteringItem = Nothing

        Try

            GridFilteringItem = RadGridCRMCentralProducts.MasterTableView.GetItems(Telerik.Web.UI.GridItemType.FilteringItem)(0)

            GridFilteringItem.Visible = False

        Catch ex As Exception

        End Try

        If String.IsNullOrEmpty(e.ExportOutput) = False Then

            e.ExportOutput = e.ExportOutput.Replace("<td>True</td>", "<td>Yes</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td>true</td>", "<td>Yes</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td>False</td>", "<td>No</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td>false</td>", "<td>No</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td style=""white-space:nowrap;"">True</td>", "<td style=""white-space:nowrap;"">Yes</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td style=""white-space:nowrap;"">true</td>", "<td style=""white-space:nowrap;"">Yes</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td style=""white-space:nowrap;"">False</td>", "<td style=""white-space:nowrap;"">No</td>")
            e.ExportOutput = e.ExportOutput.Replace("<td style=""white-space:nowrap;"">false</td>", "<td style=""white-space:nowrap;"">No</td>")

        End If

    End Sub
    Private Sub RadGridProducts_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridCRMCentralProducts.ItemDataBound

        'objects
        Dim GridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        If e.Item.ItemType = Telerik.Web.UI.GridItemType.Item OrElse e.Item.ItemType = Telerik.Web.UI.GridItemType.AlternatingItem Then

            Try

                GridDataItem = e.Item

            Catch ex As Exception

            End Try

            If GridDataItem IsNot Nothing Then

                If DoSelectRow() Then

                    If GridDataItem("ClientCode").Text = SelectedClientCode AndAlso GridDataItem("DivisionCode").Text = SelectedDivisionCode AndAlso GridDataItem("ProductCode").Text = SelectedProductCode Then

                        GridDataItem.Selected = True

                    End If

                End If

            End If

        End If

    End Sub
    Private Sub RadGridProducts_NeedDataSource(sender As Object, e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridCRMCentralProducts.NeedDataSource

        Try

            If AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.CRMAddEditViewNewBusinessClientsOnly) Then

                RadGridCRMCentralProducts.DataSource = (From Entity In _DbContext.Database.SqlQuery(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)(String.Format("EXEC [dbo].[advsp_crm_load] '{0}'", _Session.UserCode))
                                                        Where Entity.NewBusiness = True
                                                        Select Entity).ToList
            Else

                RadGridCRMCentralProducts.DataSource = _DbContext.Database.SqlQuery(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)(String.Format("EXEC [dbo].[advsp_crm_load] '{0}'", _Session.UserCode)).ToList

            End If

            Dim otask As cTasks = New cTasks(Session("ConnString"))
            Dim GridSortExpression As GridSortExpression
            If otask.getAppVars(Session("UserCode"), "CRMCentral", "GridSort") <> "" And Me.IsPostBack = False Then
                GridSortExpression = New GridSortExpression()
                GridSortExpression.FieldName = otask.getAppVars(Session("UserCode"), "CRMCentral", "GridSort")
                If otask.getAppVars(Session("UserCode"), "CRMCentral", "GridSortOrder") <> "" Then
                    GridSortExpression.SortOrder = otask.getAppVars(Session("UserCode"), "CRMCentral", "GridSortOrder")
                End If
                Me.RadGridCRMCentralProducts.MasterTableView.SortExpressions.AddSortExpression(GridSortExpression)
            End If

        Catch ex As Exception
            RadGridCRMCentralProducts.DataSource = New Generic.List(Of AdvantageFramework.CRMCentral.Classes.CRMActivity)
        End Try

    End Sub
    Private Sub RadGridProducts_PreRender(sender As Object, e As EventArgs) Handles RadGridCRMCentralProducts.PreRender

        'objects
        Dim GridColumn As Telerik.Web.UI.GridColumn = Nothing
        Dim FilterExpression As String = ""

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If AdvantageFramework.Security.LoadUserSetting(_Session, _Session.User.ID, AdvantageFramework.Security.UserSettings.IsCRMUser) Then

                GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe("NewBusiness")

                If GridColumn IsNot Nothing Then

                    GridColumn.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.EqualTo

                    GridColumn.CurrentFilterValue = "True"

                End If

                GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe("IsInactive")

                If GridColumn IsNot Nothing Then

                    GridColumn.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.EqualTo

                    GridColumn.CurrentFilterValue = "False"

                End If

            Else

                GridColumn = RadGridCRMCentralProducts.MasterTableView.GetColumnSafe("IsInactive")

                If GridColumn IsNot Nothing Then

                    GridColumn.CurrentFilterFunction = Telerik.Web.UI.GridKnownFunction.EqualTo

                    GridColumn.CurrentFilterValue = "False"

                End If

            End If

            LoadColumnFiltersFromSession()

            Try

                FilterExpression = String.Join(" And ", (From GridCol In RadGridCRMCentralProducts.MasterTableView.Columns.OfType(Of Telerik.Web.UI.GridColumn)()
                                                         Where GridCol.CurrentFilterFunction <> Telerik.Web.UI.GridKnownFunction.NoFilter AndAlso
                                                               GridCol.CurrentFilterValue <> ""
                                                         Select GridCol.EvaluateFilterExpression).ToArray)

            Catch ex As Exception
                FilterExpression = RadGridCRMCentralProducts.MasterTableView.FilterExpression
            End Try

            RadGridCRMCentralProducts.MasterTableView.FilterExpression = FilterExpression

            RefreshColumnOrderAndVisibility()

            RadGridCRMCentralProducts.MasterTableView.Rebind()

            GridPageIndex = Nothing
            Webvantage.Desktop_CRMCentral.SetGridSelectVariables(Nothing, Nothing, Nothing)

        End If

    End Sub
    Private Sub RadGridProducts_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadGridCRMCentralProducts.SelectedIndexChanged

        EnableOrDisableActions()

    End Sub

    Private Sub RadGridCRMCentralProducts_SortCommand(sender As Object, e As GridSortCommandEventArgs) Handles RadGridCRMCentralProducts.SortCommand
        Try
            Dim otask As cTasks = New cTasks(Session("ConnString"))
            otask.setAppVars(Session("UserCode"), "CRMCentral", "GridSort", "", e.SortExpression)
            otask.setAppVars(Session("UserCode"), "CRMCentral", "GridSortOrder", "", e.NewSortOrder)

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ExportGridToExcel()

        Dim Filename As String = "CRM_Central_Export_" & AdvantageFramework.StringUtilities.GUID_Date(True, True, True, True)

        RadGridCRMCentralProducts.MasterTableView.GetColumn("LastContactDate").Visible = False
        RadGridCRMCentralProducts.MasterTableView.GetColumn("LastContactDateExport").Visible = True

        AdvantageFramework.Web.Presentation.Controls.SetRadGridExcelExportSettings(Me.RadGridCRMCentralProducts, Filename)

        RadGridCRMCentralProducts.MasterTableView.ExportToExcel()

    End Sub

    Private Sub RadGridCRMCentralProducts_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridCRMCentralProducts.ItemCommand
        If (e.CommandName = RadGrid.FilterCommandName) Then

            'e.Item.CssClass = "rgFiltered"


        End If

    End Sub

    Private Sub RadGridCRMCentralProducts_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridCRMCentralProducts.ItemCreated
        Dim Grid As RadGrid = sender

        'If (e.Item.ItemType = GridItemType.FilteringItem And Grid.MasterTableView.FilterExpression <> "") Then
        '    Dim colName() As String = Grid.MasterTableView.FilterExpression.Replace("[", "").Replace("]", "").Split("=")
        '    If colName(0) <> "" Then
        '        e.Item.CssClass = "rgFiltered"
        '    End If
        'End If

    End Sub

#End Region

#End Region

End Class
