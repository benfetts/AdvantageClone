Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Drawing
Imports Telerik.Web.UI
Imports Webvantage.cGlobals
Imports Webvantage.wvTimeSheet
Imports Webvantage.ViewModels
Imports Newtonsoft.Json
Imports System.Globalization
Imports System.Threading

Public Class AccountSetupForm
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

#End Region

#Region " Variables"

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0

#End Region

#Region " Properties "

    Public Property SecurityModule As Integer = CInt(AdvantageFramework.EnumUtilities.GetValue(AdvantageFramework.Security.Modules.Employee_Timesheet))

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

    Public Property CollapsedHeaders() As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
        Get
            If IsNothing(Session.Item("CollapsedGroupHeaders")) Then
                Session.Item("CollapsedGroupHeaders") = New AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection
            End If
            Return Session.Item("CollapsedGroupHeaders")
        End Get
        Set(ByVal value As AdvantageFramework.Web.Presentation.Controls.RadGridCollapsedGroupHeaderCollection)
            Session.Item("CollapsedGroupHeaders") = value
        End Set
    End Property

    Private ReadOnly Property GroupingIndex As Integer
        Get
            Try
                Dim av As New cAppVars(cAppVars.Application.TIMESHEET)
                av.getAllAppVars()
                Return CType(av.getAppVar("DropGroupByIndex", "Integer", "0"), Integer)
            Catch ex As Exception
                Return 0
            End Try
        End Get
    End Property

    Public ReadOnly Property TextBox_ClientCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ClientCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_DivisionCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_DivisionCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_ProductCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ProductCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_AccountSetupCode1() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_AccountSetupCode1")
        End Get
    End Property

    Public ReadOnly Property TextBox_AccountSetupCode2() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_AccountSetupCode2")
        End Get
    End Property

    Public ReadOnly Property TextBox_AccountSetupCode3() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_AccountSetupCode3")
        End Get
    End Property

    Public ReadOnly Property TextBox_AccountSetupCode4() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_AccountSetupCode4")
        End Get
    End Property
    Public ReadOnly Property TextBox_PercentSplit() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_PercentSplit")
        End Get
    End Property
    Public ReadOnly Property TextBox_JobCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_JobCode")
        End Get
    End Property

    Public ReadOnly Property TextBox_ComponentCode() As TextBox
        Get
            Return FindControlRecursive(Master, "TextBox_ComponentCode")
        End Get
    End Property
    Public ReadOnly Property ImageButton_SaveNewRow() As ImageButton
        Get
            Return FindControlRecursive(Master, "ImageButton_SaveNewRow")
        End Get
    End Property

    Public ReadOnly Property ImageButton_CancelNewRow() As ImageButton
        Get
            Return FindControlRecursive(Master, "ImageButton_CancelNewRow")
        End Get
    End Property
    Public ReadOnly Property HiddenField_Job() As HiddenField
        Get
            Return FindControlRecursive(Master, "HiddenField_Job")
        End Get
    End Property

    Public ReadOnly Property HiddenField_Component() As HiddenField
        Get
            Return FindControlRecursive(Master, "HiddenField_Component")
        End Get
    End Property


#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init

        Me.AllowFloat = False
        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_AccountSetupForm)

        Me.RadToolbarButtonDelete.ToolTip = "Delete selected row(s)"

        If Not Me.IsPostBack And Not Me.IsCallback Then
            Try

            Catch ex As Exception
            End Try
        Else

        End If

        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

        'set date
        Dim DateSet As Boolean = False
        If Not Me.IsPostBack And Not Me.IsCallback Then

            If Not Request.QueryString("from") Is Nothing Then

            End If

        End If

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridAccountSetupForm)


    End Sub
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.RadScriptManagerParent.RegisterPostBackControl(Me.RadToolbarButtonRefresh)

        If IsNothing(Me.ImageButton_SaveNewRow) = False Then

            Me.RadScriptManagerParent.RegisterPostBackControl(Me.ImageButton_SaveNewRow)
            Me.RadScriptManagerParent.RegisterPostBackControl(Me.ImageButton_CancelNewRow)

        End If

        If Not Me.IsPostBack And Not Me.IsCallback Then

            Me.BodyTag.Attributes.Add("ondragstart", "return false;")
            Me.BodyTag.Attributes.Add("draggable", "false")

        Else 'It is a postback/callback

            CheckForRowInsert()

            Select Case Me.EventTarget
                Case "RebindGrid"
                    Me.RadGridAccountSetupForm.Rebind()

            End Select

        End If

        Me.MyUnityContextMenu.SetRadGrid(Me.RadGridAccountSetupForm)

    End Sub
    Private Sub Page_PreRender(sender As Object, e As EventArgs) Handles Me.PreRender
        If IsNothing(Session.Item("CollapsedGroupHeaders")) = False Then
            Dim groupHeaders As List(Of GridItem) = Me.RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

            Dim expanded As List(Of GridItem) = (From g In groupHeaders
                                                 Where g.Expanded
                                                 Select g).ToList()


            For Each expandedItem As GridItem In expanded
                If Me.CollapsedHeaders.GroupCaptions.Contains(expandedItem.Cells(1).Text) Then
                    expandedItem.Expanded = False
                End If
            Next

        End If

    End Sub
    Private Sub AccountSetupForm_LoadComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LoadComplete

        If Not Me.IsPostBack And Not Me.IsCallback Then

        End If

        Dim head As GridHeaderItem
        Try
            If Not Me.RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.Header) Is Nothing Then
                head = TryCast(Me.RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
            End If
        Catch ex As Exception

            head = Nothing

        End Try

    End Sub

#End Region

#Region " Control Events "

    Private Sub MyUnityContextMenu_RadContextMenuUnityItemClick(sender As Object, e As RadMenuEventArgs) Handles MyUnityContextMenu.RadContextMenuUnityItemClick

        If IsNumeric(RadGridAccountSetupForm.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNumber")) = True AndAlso
           IsNumeric(RadGridAccountSetupForm.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComponentNbr")) = True Then

            Me.MyUnityContextMenu.JobNumber = RadGridAccountSetupForm.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobNumber")
            Me.MyUnityContextMenu.JobComponentNumber = RadGridAccountSetupForm.Items(Me.MyUnityContextMenu.GridIndex).GetDataKeyValue("JobComponentNbr")

        End If

    End Sub

    Private Sub RRadToolbarAccountSetupButtons_ButtonClick(ByVal sender As Object, ByVal e As Telerik.Web.UI.RadToolBarEventArgs) Handles RadToolbarAccountSetupButtons.ButtonClick

        Select Case e.Item.Value
            Case "refresh"
                Me.RadGridAccountSetupForm.Rebind()

            Case "save" 'only for Comments required

                If Me.CheckGridForInputErrors = True Then Exit Sub
                Me.SaveGrid(True)

            Case "print"

                Dim qs As New AdvantageFramework.Web.QueryString()

                qs.Page = "dtp_accountsetupprint.aspx"
                qs.JobNumber = Me._JobNumber
                qs.JobComponentNumber = Me._JobComponentNumber

                Me.OpenWindow("Account Setup Print", qs.ToString(True))

                'Me.OpenWindow("Print Timesheet", "Timesheet_QuickPrintSettings.aspx?empcode=" & Me.TimesheetEmpCode & "&tsdate=" & CType(Me.RadDatePickerStartDate.SelectedDate, Date).ToShortDateString() & "&sortkey=&Type=1&Report=timesheetprint", 220, 365)

            Case "DeleteSelected"
                Dim itemCheckBox As CheckBox = Nothing
                Dim currentRowCount As Integer = Me.RadGridAccountSetupForm.MasterTableView.Items().Count
                Dim gridDataItem As Telerik.Web.UI.GridDataItem = Nothing
                Dim UndeletableRowsSelected = False
                Dim HiddenField_RowIsDeleteable As HiddenField

                For rowIndex As Integer = currentRowCount To 1 Step -1
                    gridDataItem = Me.RadGridAccountSetupForm.MasterTableView.Items(rowIndex - 1)
                    If gridDataItem.Selected Then
                        HiddenField_RowIsDeleteable = gridDataItem.FindControl("HiddenField_RowIsDeleteable")
                        If (CBool(HiddenField_RowIsDeleteable.Value) = False) Then
                            UndeletableRowsSelected = True
                        End If
                        DeleteGridRow(gridDataItem, gridDataItem.ItemIndex, False)
                    End If
                Next

                Me.RadGridAccountSetupForm.Rebind()

                If UndeletableRowsSelected Then
                    Page.ClientScript.RegisterStartupScript(Me.GetType(), "AlertCannotDelete", "ShowMessage('One or more rows could not be deleted.');", True)
                End If


        End Select
    End Sub

    Private Function SaveGridRow(ByVal GridRow As Telerik.Web.UI.GridDataItem, Optional ByRef ErrorMessage As String = "") As Boolean
        Try

            Dim HasSaved As Boolean
            Dim EverythingSavedOK As Boolean = True
            Dim ReturnMessage As String = String.Empty

            'Dim ClientTextBox As TextBox = CType(GridRow.FindControl("TextBox_ClientCode"), TextBox)
            'Dim DivisionTextBox As TextBox = CType(GridRow.FindControl("TextBox_DivisionCode"), TextBox)
            'Dim ProductTextBox As TextBox = CType(GridRow.FindControl("TextBox_ProductCode"), TextBox)
            Dim Code1TextBox As TextBox = CType(GridRow.FindControl("TextBoxAccountSetupCode1"), TextBox)
            Dim Code2TextBox As TextBox = CType(GridRow.FindControl("TextBoxAccountSetupCode2"), TextBox)
            Dim Code3TextBox As TextBox = CType(GridRow.FindControl("TextBoxAccountSetupCode3"), TextBox)
            Dim Code4TextBox As TextBox = CType(GridRow.FindControl("TextBoxAccountSetupCode4"), TextBox)
            Dim PercentSplitTextBox As TextBox = CType(GridRow.FindControl("TextBoxPercentSplit"), TextBox)

            Dim AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm = Nothing

            'Set the datasource:
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                If GridRow.GetDataKeyValue("ID") IsNot Nothing Then
                    AccountSetupForm = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByID(DbContext, GridRow.GetDataKeyValue("ID"))
                    If AccountSetupForm IsNot Nothing Then
                        AccountSetupForm.AccountSetupCode1 = Code1TextBox.Text
                        AccountSetupForm.AccountSetupCode2 = Code2TextBox.Text
                        AccountSetupForm.AccountSetupCode3 = Code3TextBox.Text
                        AccountSetupForm.AccountSetupCode4 = Code4TextBox.Text
                        AccountSetupForm.PercentSplit = PercentSplitTextBox.Text
                        AdvantageFramework.Database.Procedures.AccountSetupForm.Update(DbContext, AccountSetupForm, ReturnMessage)
                    Else
                        'AdvantageFramework.Database.Procedures.AccountSetupForm.Insert(DbContext, AccountSetupForm, ReturnMessage)
                    End If
                End If

            End Using

            If EverythingSavedOK = True Then
                ErrorMessage = String.Empty
                Return True
            Else
                Return False
            End If

        Catch ex As Exception
            ErrorMessage = ex.Message.ToString()
            Return False
        End Try
    End Function

    'RESOURCE:  http://weblog.west-wind.com/posts/2006/Apr/09/ASPNET-20-MasterPages-and-FindControl
    Public Shared Function FindControlRecursive(Root As System.Web.UI.Control, Id As String) As System.Web.UI.Control

        If Root.ID = Id Then
            Return Root
        End If

        For Each Ctl As System.Web.UI.Control In Root.Controls


            Dim FoundCtl As System.Web.UI.Control = FindControlRecursive(Ctl, Id)

            If FoundCtl IsNot Nothing Then

                Return FoundCtl

            End If
        Next

        Return Nothing

    End Function

#Region " RadGrid Functions"

    Private Property CurrentGridPageIndex As Integer = 0
    Private IsSingleDayView As Boolean = False
    Private ArrayCounter As Integer = 0
    Private _HasPostedProgress As Boolean = False
    Private _TotalPercent As Decimal = CDec(0)
    Private _Balanced As Boolean = False


    Private Sub RadGridAccountSetupForm_PageIndexChanged(sender As Object, e As Telerik.Web.UI.GridPageChangedEventArgs) Handles RadGridAccountSetupForm.PageIndexChanged
        Me.CurrentGridPageIndex = e.NewPageIndex
        Me.RadGridAccountSetupForm.Rebind()
    End Sub
    Private Sub RadGridAccountSetupForm_PageSizeChanged(sender As Object, e As Telerik.Web.UI.GridPageSizeChangedEventArgs) Handles RadGridAccountSetupForm.PageSizeChanged
        MiscFN.SavePageSize(Me.RadGridAccountSetupForm.ID, e.NewPageSize)
    End Sub
    Private Sub RadGridAccountSetupForm_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridAccountSetupForm.NeedDataSource

        Try
            Dim oA As cAgency = New cAgency(CStr(Session("ConnString")))
            Dim AccountSetupForm As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
            Dim Client As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim Division As Generic.List(Of AdvantageFramework.Database.Entities.Division) = Nothing
            Dim Product As Generic.List(Of AdvantageFramework.Database.Entities.Product) = Nothing
            Dim MyJobTemplate As Job_Template = New Job_Template(Session("ConnString"))

            'Set the datasource:
            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AccountSetupForm = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByJobandComponent(DbContext, _JobNumber, _JobComponentNumber).ToList
                Client = AdvantageFramework.Database.Procedures.Client.Load(DbContext).ToList
                Division = AdvantageFramework.Database.Procedures.Division.Load(DbContext).ToList
                Product = AdvantageFramework.Database.Procedures.Product.Load(DbContext).ToList

                Me.RadGridAccountSetupForm.DataSource = MyJobTemplate.GetAccountSetupData(_JobNumber, _JobComponentNumber)

                'Dim AccountSetupSelections As Generic.List(Of AccountSetupSelection) = Nothing

                'AccountSetupSelections = New Generic.List(Of AccountSetupSelection)

                'AccountSetupSelections.AddRange((From a In AccountSetupForm
                '                                 Join p In Product On p.ClientCode Equals a.ClientCode And p.DivisionCode Equals a.DivisionCode And p.Code Equals a.ProductCode
                '                                 Join d In Division On d.ClientCode Equals a.ClientCode And d.Code Equals a.DivisionCode
                '                                 Join c In Client On c.Code Equals a.ClientCode
                '                                 Where a.ClientCode IsNot Nothing AndAlso a.DivisionCode IsNot Nothing AndAlso a.ProductCode IsNot Nothing
                '                                 Select New AccountSetupSelection With {.ID = a.ID,
                '                                                                        .JobNumber = a.JobNumber,
                '                                                                        .JobComponentNumber = a.JobComponentNumber,
                '                                                                        .ClientCode = a.ClientCode,
                '                                                                        .ClientName = c.Name,
                '                                                                        .DivisionCode = a.DivisionCode,
                '                                                                        .DivisionName = d.Name,
                '                                                                        .ProductCode = a.ProductCode,
                '                                                                        .ProductName = p.Name,
                '                                                                        .AccountSetupCode1 = a.AccountSetupCode1,
                '                                                                        .AccountSetupCode2 = a.AccountSetupCode2,
                '                                                                        .AccountSetupCode3 = a.AccountSetupCode3,
                '                                                                        .AccountSetupCode4 = a.AccountSetupCode4,
                '                                                                        .PercentSplit = a.PercentSplit,
                '                                                                        .Balanced = a.Balanced}).ToList)

                'AccountSetupSelections.AddRange((From a In AccountSetupForm
                '                                 Join d In Division On d.ClientCode Equals a.ClientCode And d.Code Equals a.DivisionCode
                '                                 Join c In Client On c.Code Equals d.ClientCode
                '                                 Where a.ClientCode IsNot Nothing AndAlso a.DivisionCode IsNot Nothing AndAlso a.ProductCode Is Nothing
                '                                 Select New AccountSetupSelection With {.ID = a.ID,
                '                                                                        .JobNumber = a.JobNumber,
                '                                                                        .JobComponentNumber = a.JobComponentNumber,
                '                                                                        .ClientCode = a.ClientCode,
                '                                                                        .ClientName = c.Name,
                '                                                                        .DivisionCode = a.DivisionCode,
                '                                                                        .DivisionName = d.Name,
                '                                                                        .ProductCode = "",
                '                                                                        .ProductName = "",
                '                                                                        .AccountSetupCode1 = a.AccountSetupCode1,
                '                                                                        .AccountSetupCode2 = a.AccountSetupCode2,
                '                                                                        .AccountSetupCode3 = a.AccountSetupCode3,
                '                                                                        .AccountSetupCode4 = a.AccountSetupCode4,
                '                                                                        .PercentSplit = a.PercentSplit,
                '                                                                        .Balanced = a.Balanced}).ToList)

                'AccountSetupSelections.AddRange((From a In AccountSetupForm
                '                                 Join c In Client On c.Code Equals a.ClientCode
                '                                 Where a.ClientCode IsNot Nothing AndAlso a.DivisionCode Is Nothing AndAlso a.ProductCode Is Nothing
                '                                 Select New AccountSetupSelection With {.ID = a.ID,
                '                                                                        .JobNumber = a.JobNumber,
                '                                                                        .JobComponentNumber = a.JobComponentNumber,
                '                                                                        .ClientCode = a.ClientCode,
                '                                                                        .ClientName = c.Name,
                '                                                                        .DivisionCode = "",
                '                                                                        .DivisionName = "",
                '                                                                        .ProductCode = "",
                '                                                                        .ProductName = "",
                '                                                                        .AccountSetupCode1 = a.AccountSetupCode1,
                '                                                                        .AccountSetupCode2 = a.AccountSetupCode2,
                '                                                                        .AccountSetupCode3 = a.AccountSetupCode3,
                '                                                                        .AccountSetupCode4 = a.AccountSetupCode4,
                '                                                                        .PercentSplit = a.PercentSplit,
                '                                                                        .Balanced = a.Balanced}).ToList)

                'Me.RadGridAccountSetupForm.DataSource = AccountSetupSelections

                'Me.RadGridAccountSetupForm.DataSource = (From a In AccountSetupForm
                '                                         Join p In Product On a.ClientCode Equals p.ClientCode And a.DivisionCode Equals p.DivisionCode And a.ProductCode Equals p.Code
                '                                         Join d In Division On d.ClientCode Equals p.ClientCode And d.Code Equals p.DivisionCode
                '                                         Join c In Client On c.Code Equals d.ClientCode
                '                                         Select New With {.ID = a.ID,
                '                                                .JobNumber = a.JobNumber,
                '                                                .JobComponentNumber = a.JobComponentNumber,
                '                                                .ClientCode = a.ClientCode,
                '                                                .ClientName = c.Name,
                '                                                .DivisionCode = a.DivisionCode,
                '                                                .DivisionName = d.Name,
                '                                                .ProductCode = a.ProductCode,
                '                                                .ProductName = p.Name,
                '                                                .AccountSetupCode1 = a.AccountSetupCode1,
                '                                                .AccountSetupCode2 = a.AccountSetupCode2,
                '                                                .AccountSetupCode3 = a.AccountSetupCode3,
                '                                                .AccountSetupCode4 = a.AccountSetupCode4,
                '                                                .PercentSplit = a.PercentSplit,
                '                                                .Balanced = a.Balanced}).ToList()


            End Using

            Me.RadGridAccountSetupForm.CurrentPageIndex = Me.CurrentGridPageIndex

            Me.RadGridAccountSetupForm.MasterTableView.IsItemInserted = True
        Catch ex As Exception

        End Try

    End Sub
    Private Sub RadGridAccountSetupForm_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAccountSetupForm.ItemDataBound

        If TypeOf e.Item Is Telerik.Web.UI.GridEditableItem Then


        End If
        If TypeOf e.Item Is Telerik.Web.UI.GridDataItem Then

            Dim dataItem As Telerik.Web.UI.GridDataItem = e.Item

            If TypeOf (dataItem.DataItem) Is Telerik.Web.UI.GridInsertionObject Then

                Exit Sub

            End If

            Dim QuerystringTimesheetDetails As New AdvantageFramework.Web.QueryString

            Dim DeleteImageButton As System.Web.UI.WebControls.ImageButton = CType(dataItem.FindControl("ImageButtonDelete"), ImageButton)
            Dim DeleteDiv As HtmlControls.HtmlControl = dataItem.FindControl("DivDelete")
            Dim CanDelete As Boolean = False

            CanDelete = True 'Not TimesheetRow.CannotEditDueToProcessingControl

            If CanDelete = True Then

            End If

            If CanDelete = True Then

                If (IsNothing(DeleteImageButton) = False) Then

                    DeleteImageButton.Attributes("onclick") = "return confirm('Are you sure you want to delete this row?')"
                    DeleteImageButton.Enabled = True
                    DeleteImageButton.ToolTip = "Delete row"

                End If

            Else

                AdvantageFramework.Web.Presentation.Controls.DivHide(DeleteDiv)

            End If

            Dim HiddenField_RowIsDeleteable As HiddenField = e.Item.FindControl("HiddenField_RowIsDeleteable")

            HiddenField_RowIsDeleteable.Value = CanDelete

            Dim TextBoxPercentSplit As System.Web.UI.WebControls.TextBox = CType(e.Item.FindControl("TextBoxPercentSplit"), TextBox)

            If TextBoxPercentSplit.Text <> "" Then
                _TotalPercent += CDec(TextBoxPercentSplit.Text)
            End If

            If dataItem.GetDataKeyValue("Balanced") = True Then
                _Balanced = True
            End If


        End If

        If (TypeOf e.Item Is Telerik.Web.UI.GridFooterItem) Then

            Dim footerItem As Telerik.Web.UI.GridFooterItem = CType(e.Item, Telerik.Web.UI.GridFooterItem)

            If _Balanced = False And Me.RadGridAccountSetupForm.MasterTableView.Items.Count > 0 Then
                footerItem("GridBoundColumnPercentSplit").ForeColor = Color.Red
                footerItem("GridBoundColumnPercentSplit").Text = _TotalPercent.ToString & " (Unbalanced)"
            Else
                footerItem("GridBoundColumnPercentSplit").ForeColor = Color.Black
                footerItem("GridBoundColumnPercentSplit").Text = _TotalPercent
            End If

        End If

    End Sub
    Private Sub RadGridAccountSetupForm_PreRender(sender As Object, e As System.EventArgs) Handles RadGridAccountSetupForm.PreRender
        Me.SetLookUps()
        Me.SetGridDescriptionHeaders()

        Dim GridSettings As New GridSettingsPersister(Me.RadGridAccountSetupForm)
        GridSettings.SaveToDatabase()

        For Each groupheader As GridGroupHeaderItem In Me.RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.GroupHeader)

            Dim flag As New Boolean

            For Each I As GridItem In groupheader.GetChildItems()
                If I.Display Then
                    flag = True
                    Exit For
                End If
            Next

            groupheader.Visible = flag

        Next

    End Sub
    Private Sub RadGridAccountSetupForm_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridAccountSetupForm.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Dim index As Integer = 0
        If Not e.Item Is Nothing Then
            index = e.Item.ItemIndex
        Else
            Exit Sub
        End If

        If index = -1 Then 'command item
            MiscFN.SavePageSize(Me.RadGridAccountSetupForm.ID, Me.RadGridAccountSetupForm.PageSize)
        End If

        Select Case e.CommandName
            Case "Page"
                PreserveHeaderRowSelectorsAfterPostback()
            Case "ExpandCollapse"

                Dim groupHeaders As List(Of GridItem) = Me.RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.GroupHeader).ToList()

                Dim captions As List(Of String) = (From g In groupHeaders
                                                   Where g.Expanded = False
                                                   Select g.Cells(1).Text).ToList()

                If (e.Item.Expanded) Then
                    captions.Add(e.Item.Cells(1).Text)
                Else
                    If (captions.Contains(e.Item.Cells(1).Text)) Then
                        captions.Remove(e.Item.Cells(1).Text)
                    End If
                End If

                Me.CollapsedHeaders.GroupCaptions = captions


            Case "NewRowCancel"
                Me.SetLookUps()
                Me.ClearAddNewTextboxes()

            Case "NewRowCommitInsert"


            Case RadGridAccountSetupForm.DeleteCommandName, "RowDelete"

                Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(RadGridAccountSetupForm.Items(index), Telerik.Web.UI.GridDataItem)
                DeleteGridRow(CurrentGridRow, index)

            Case "Sort"
                PreserveHeaderRowSelectorsAfterPostback()
        End Select
    End Sub

    Public Sub PreserveHeaderRowSelectorsAfterPostback()

        Dim templateStringBuilder As New System.Text.StringBuilder()

        templateStringBuilder.AppendLine("$(document).ready(function () {{")
        ' templateStringBuilder.AppendLine("ShowMessage('PreserveHeaderRowSelectorsAfterPostback()');")
        templateStringBuilder.AppendLine("var timesheetSelectorScope = angular.element($('#TextBox_ClientCode')).scope();")
        templateStringBuilder.AppendLine("timesheetSelectorScope.ClientCode = '{0}'; timesheetSelectorScope.DivisionCode = '{1}'; timesheetSelectorScope.ProductCode = '{2}'; timesheetSelectorScope.JobCode = '{3}'; timesheetSelectorScope.ComponentCode = '{4}';")
        templateStringBuilder.AppendLine("timesheetSelectorScope.$apply()")
        templateStringBuilder.AppendLine("}});")

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "PreserveHeaderRowSelectorsAfterPostback", String.Format(templateStringBuilder.ToString(), TextBox_ClientCode.Text.Trim(), Me.TextBox_DivisionCode.Text.Trim(), Me.TextBox_ProductCode.Text.Trim(), _JobNumber, _JobComponentNumber, Me.TextBox_PercentSplit.Text.Trim()), True)
    End Sub

    Public Sub SetClientCodeFocus()

        Dim templateStringBuilder As New System.Text.StringBuilder()

        templateStringBuilder.AppendLine("$(document).ready(function () {{")
        templateStringBuilder.AppendLine("$('#TextBox_ClientCode').Focus();")
        templateStringBuilder.AppendLine("}});")

        Page.ClientScript.RegisterStartupScript(Me.GetType(), "SetClientCodeFocus", templateStringBuilder.ToString(), True)
    End Sub

    Private Sub SetGridDescriptionHeaders()

        Dim DaysToShow As Integer = 0
        Dim StartWeekOn As String = String.Empty
        Dim ShowCommentUsing As String = String.Empty
        Dim DivisionLabel As String = String.Empty
        Dim ProductLabel As String = String.Empty
        Dim ProductCategoryLabel As String = String.Empty
        Dim JobLabel As String = String.Empty
        Dim JobComponentLabel As String = String.Empty
        Dim FunctionCategoryLabel As String = String.Empty

        Dim connectionString As New cTimeSheet(Session("ConnString"))
        Dim errorMessage As String = String.Empty

        Dim agency As New AdvantageFramework.Web.AgencySettings.Methods(Session("ConnString"), Session("UserCode"), HttpContext.Current)

        Dim header As GridHeaderItem = TryCast(RadGridAccountSetupForm.MasterTableView.GetItems(GridItemType.Header)(0), GridHeaderItem)
        If Not header Is Nothing Then

            CType(header("GridBoundColumnAccountSetupCode1").Controls(0), LiteralControl).Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_1, "")
            CType(header("GridBoundColumnAccountSetupCode2").Controls(0), LiteralControl).Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_2, "")
            CType(header("GridBoundColumnAccountSetupCode3").Controls(0), LiteralControl).Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_3, "")
            CType(header("GridBoundColumnAccountSetupCode4").Controls(0), LiteralControl).Text = agency.GetValue(AdvantageFramework.Agency.Settings.ACC_SETUP_CODE_4, "")
            'CType(header("GridTemplateColumnJobNumber").Controls(0), LinkButton).Text = JobLabel
            'CType(header("GridTemplateColumnJobDescription").Controls(0), LinkButton).Text = JobLabel & " Description"
            'CType(header("GridTemplateColumnJobComponentNumber").Controls(0), LinkButton).Text = JobComponentLabel
            'CType(header("GridTemplateColumnJobComponentDescription").Controls(0), LinkButton).Text = JobComponentLabel & " Description"
            'CType(header("GridBoundColumnProductCategory").Controls(0), System.Web.UI.LiteralControl).Text = ProductCategoryLabel
            'CType(header("GridTemplateColumnFunctionCategory").Controls(0), LinkButton).Text = FunctionCategoryLabel
            'CType(header("GridBoundColumnFunctionCategoryDesc").Controls(0), System.Web.UI.LiteralControl).Text = FunctionCategoryLabel + " Desc"
        End If


    End Sub

    Private Function DeleteGridRow(ByVal TheGridRow As Telerik.Web.UI.GridDataItem, ByVal TheGridRowIndex As Integer, Optional ByVal RebindGrid As Boolean = True) As String

        Dim ET_ID As Integer = 0
        Dim ETD_ID As Integer = 0
        Dim TimeType As String = String.Empty
        Dim TheDay As String = String.Empty
        Dim dayPrefix As String = String.Empty
        Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        Dim DayCount As Integer = 0

        Dim AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm = Nothing

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)
            AccountSetupForm = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByID(DbContext, TheGridRow.GetDataKeyValue("ID"))
            If AccountSetupForm IsNot Nothing Then
                AdvantageFramework.Database.Procedures.AccountSetupForm.Delete(DbContext, AccountSetupForm)
            End If
            Me.CheckForBalance()
        End Using

        If (RebindGrid) Then
            Me.RadGridAccountSetupForm.Rebind()
        End If
    End Function

    Private Sub GetInfoForDelete(ByVal Datakey As String, ByRef EtId As Integer, ByRef EtDtlId As Integer, ByRef TimeType As String)
        Dim dataKeyArray() As String
        dataKeyArray = Datakey.Split("|")
        Try
            If IsNumeric(dataKeyArray(7)) = True Then
                EtId = CType(dataKeyArray(7), Integer)
            Else
                EtId = 0
            End If
        Catch ex As Exception
            EtId = 0
        End Try
        Try
            If IsNumeric(dataKeyArray(8)) = True Then
                EtDtlId = CType(dataKeyArray(8), Integer)
            Else
                EtDtlId = 0
            End If
        Catch ex As Exception
            EtDtlId = 0
        End Try
        Try
            TimeType = dataKeyArray(10)
        Catch ex As Exception
            TimeType = "D"
        End Try
    End Sub

    Private Function EditFlagMessage(ByVal TheDay As String, ByVal EditFlag As Integer) As String
        Select Case EditFlag
            Case 1
                Return "Item has been billed"
            Case 2
                Return "Item has been summarizedYou must insert a new row to adjust your time" '"The item is a summary valueYou must insert a new row to adjust your time."
                'Case 3
                '    Return TheDay & " has been billed"
            Case 4
                Return "Item is in billing"
            Case 5
                Return "Item is pending"
            Case 6
                Return "Item has been approved"
        End Select
    End Function

    Private Function SetGridCell(ByRef Row As Telerik.Web.UI.GridDataItem, ByVal ColumnDate As Date, Optional ByRef ErrorMessage As String = "") As Boolean
        Try
            Dim DayAbbreviation As String = String.Empty
            Dim FullDay As String = String.Empty
            Dim Pending As Boolean = False

            Dim TimesheetRow As AdvantageFramework.Timesheet.TimesheetLine
            TimesheetRow = CType(Row.DataItem, AdvantageFramework.Timesheet.TimesheetLine)
            Dim TimesheetCell As AdvantageFramework.Timesheet.TimesheetEntry

            Dim HoursTextbox As TextBox = CType(Row.FindControl("Txt" & FullDay), TextBox)
            Dim DivComment As HtmlControls.HtmlControl = CType(Row.FindControl(DayAbbreviation & "DivComment"), HtmlControls.HtmlControl)
            Dim CommentImageButton As System.Web.UI.WebControls.ImageButton = CType(Row.FindControl(DayAbbreviation & "ImageButtonComment"), ImageButton)
            Dim CommentTextbox As System.Web.UI.WebControls.TextBox = CType(Row.FindControl(DayAbbreviation & "TextBoxComment"), TextBox)
            Dim DatakeyHiddenField As System.Web.UI.WebControls.HiddenField = CType(Row.FindControl(DayAbbreviation & "Datakey"), HiddenField)
            Dim CannotEditDueToProcessingControlImage As WebControls.Image = CType(Row.FindControl("ImageProcessControlWarning"), WebControls.Image)

            Dim PostPeriodClosed As Boolean = False
            Dim EditFlag As Integer = 0
            Dim EditType As AdvantageFramework.Timesheet.TimesheetEditType = 0
            Dim NonEditMessage As String = String.Empty
            Dim HasComments As Boolean = False

            Dim EtId As Integer = 0
            Dim EtDtlId As Integer = 0
            Dim TimeType As String = String.Empty
            Dim CellDate As String = ColumnDate.ToShortDateString()

            'set edit for time entry
            Dim CanEdit As Boolean = False
            Dim CannotEditDueToProcessingControl As Boolean = False
            Dim Hours As Double = CType(0, Double)
            Dim HasStopWatch As Boolean = False
            Dim CanDelete As Boolean = False

            Dim ClientPrefix As String = DatakeyHiddenField.ClientID.Replace("Datakey", String.Empty)
            Dim WebDataKey As String = String.Empty
            Dim CommentRequired As Boolean = False

            CannotEditDueToProcessingControl = TimesheetRow.NonEditMessage.Trim() <> String.Empty

            If Not TimesheetCell Is Nothing Then

                EditFlag = TimesheetCell.EditFlag
                EditType = CType(EditFlag, AdvantageFramework.Timesheet.TimesheetEditType)
                NonEditMessage = TimesheetRow.NonEditMessage
                EtId = TimesheetCell.ETID
                EtDtlId = TimesheetCell.ETDTLID
                TimeType = TimesheetCell.TimeType
                If TimesheetCell.Comments.Trim() <> String.Empty Then
                    HasComments = True
                End If
                Hours = TimesheetCell.Hours
                HasStopWatch = TimesheetCell.HasStopwatch
                WebDataKey = TimesheetCell.WebDataKey
                CommentRequired = TimesheetCell.CommentsRequired
                CanDelete = TimesheetCell.CanDelete

            End If

            Dim dataKeyStringBuilder As New System.Text.StringBuilder
            With dataKeyStringBuilder
                .Append(ClientPrefix) '0
                .Append("|")
                If WebDataKey.Trim() <> String.Empty Then
                    .Append(WebDataKey)
                Else
                    .Append(Session("TimesheetEmpCode"))
                    .Append("|")
                    .Append(TimesheetRow.FuncCat)
                    .Append("|")
                    .Append(TimesheetRow.Dept)
                    .Append("|")
                    .Append(TimesheetRow.ProductCategory)
                    .Append("|")
                    .Append(TimesheetRow.JobNumber)
                    .Append("|")
                    .Append(TimesheetRow.JobComponentNbr)
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    .Append(ColumnDate.ToShortDateString())
                    .Append("|")
                    .Append(TimesheetRow.TimeType)
                    .Append("|")
                    .Append("0")
                    .Append("|")
                    '.Append(Me.CommentsRequired.ToString().ToLower())
                    .Append("|")
                    .Append("false")
                    .Append("|")
                    .Append(Hours.ToString())
                End If
            End With

            DatakeyHiddenField.Value = dataKeyStringBuilder.ToString()

            HoursTextbox.Text = Microsoft.VisualBasic.FormatNumber(Hours, 2, TriState.UseDefault, TriState.UseDefault, TriState.UseDefault)

            Select Case EditType
                Case AdvantageFramework.Timesheet.TimesheetEditType.Edit, AdvantageFramework.Timesheet.TimesheetEditType.Denied
                    CanEdit = True
            End Select
            If CanEdit = True And EditType = AdvantageFramework.Timesheet.TimesheetEditType.PendingApproval Then
                CanEdit = False
            End If
            If CanEdit = True And CannotEditDueToProcessingControl = True Then
                CanEdit = False
            End If
            If CanEdit = True Then
                CanEdit = Not PostPeriodClosed
            End If

            HoursTextbox.Enabled = CanEdit
            CommentTextbox.Enabled = CanEdit

            CannotEditDueToProcessingControlImage.Visible = CannotEditDueToProcessingControl
            HoursTextbox.Attributes.Remove("onblur")
            CommentTextbox.Attributes.Remove("onblur")

            ErrorMessage = String.Empty
            Return True

        Catch ex As Exception
            ErrorMessage = MiscFN.JavascriptSafe(ex.Message.ToString())
            Return False
        End Try
    End Function

    Private Function SaveGrid(ByVal RebindGrid As Boolean)

        Dim RowCount As Integer = Me.RadGridAccountSetupForm.MasterTableView.Items.Count
        Dim AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm = Nothing
        Dim AccountSetupForms As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
        Dim returnmessage As String = ""
        Dim msg As String = String.Empty
        Dim TotalPercent As Decimal = 0

        If RowCount > 0 Then

            Dim EverythingSavedOK As Boolean = True
            For Each GridRow As GridDataItem In Me.RadGridAccountSetupForm.MasterTableView.Items
                Dim s As String = String.Empty
                If Me.SaveGridRow(GridRow, s) = False Then
                    If s <> String.Empty Then
                        msg &= s
                        EverythingSavedOK = False
                    End If
                End If
            Next

            If EverythingSavedOK = True Then

                Me.CheckForBalance()

            End If

            If EverythingSavedOK = True And RebindGrid = True Then

                Me.RadGridAccountSetupForm.Rebind()

            End If

            If EverythingSavedOK = False And msg.Trim() <> String.Empty Then

                Me.ShowMessage(AdvantageFramework.StringUtilities.JavascriptSafe(msg))

            End If

        Else

            Me.ShowMessage("Account Setup has no rows to save")
            Exit Function

        End If

    End Function

    Private Function CheckGridForInputErrors() As Boolean

        Dim GridHasErrors As Boolean = False
        Dim PercentError As Boolean = False
        Dim PercentTotalError As Boolean = False


        Dim PercentTextBox As New TextBox
        Dim TotalPercent As Decimal = 0

        For Each GridRow As GridDataItem In Me.RadGridAccountSetupForm.MasterTableView.Items

            Dim RowJobNum As Integer = 0
            Dim RowJobCompNum As Integer = 0

            Try
                RowJobNum = CType(GridRow.GetDataKeyValue("JobNumber"), Integer)
            Catch ex As Exception
                RowJobNum = 0
            End Try
            Try
                RowJobCompNum = CType(GridRow.GetDataKeyValue("JobComponentNumber"), Integer)
            Catch ex As Exception
                RowJobCompNum = 0
            End Try

            PercentTextBox = CType(GridRow.FindControl("TextBoxPercentSplit"), TextBox)

            If IsNumeric(PercentTextBox.Text) = False Then
                GridHasErrors = True
                PercentError = True
            Else
                TotalPercent += CDec(PercentTextBox.Text)
            End If

        Next

        If TotalPercent > 100.0 Then
            GridHasErrors = True
            PercentTotalError = True
        End If

        If GridHasErrors = True Then

            Dim SbError As New System.Text.StringBuilder

            'SbError.Append("Invalid Percent.\n\n")

            If PercentError Then
                SbError.Append("Invalid Percent.\n")
            End If

            If PercentTotalError Then
                ' SbError.Append("Total Percent can not be more than 100.\n")
            End If


            Me.ShowMessage(SbError.ToString())

        End If

        Return GridHasErrors

    End Function

#Region " Code Blocks for Grid"

    'used in add new header only
    Public Function SetAddNewDayHeaders() As String
        Dim lg As New LoGlo()

        Dim timeSheet As New cTimeSheet(Session("ConnString"))
        Dim errorMessage As String = String.Empty

        Dim DaysToShow As Integer = 0
        Dim StartWeekOn As String = String.Empty
        Dim ShowCommentUsing As String = String.Empty
        Dim DivisionLabel As String = String.Empty
        Dim ProductLabel As String = String.Empty
        Dim ProductCategoryLabel As String = String.Empty
        Dim JobLabel As String = String.Empty
        Dim JobComponentLabel As String = String.Empty
        Dim FunctionCategoryLabel As String = String.Empty
    End Function

#End Region

#End Region

#End Region

#Region " Methods "

#Region " Add New / Add New Panel Code"

    Private Sub ClearAddNewTextboxes()
        Me.TextBox_ClientCode.Text = String.Empty
        Me.TextBox_DivisionCode.Text = String.Empty
        Me.TextBox_ProductCode.Text = String.Empty
        Me.TextBox_AccountSetupCode1.Text = String.Empty
        Me.TextBox_AccountSetupCode2.Text = String.Empty
        Me.TextBox_AccountSetupCode3.Text = String.Empty
        Me.TextBox_AccountSetupCode4.Text = String.Empty
        Me.TextBox_PercentSplit.Text = "0.00"

    End Sub

    Private Sub SetLookUps()

        If RadGridAccountSetupForm.MasterTableView.IsItemInserted Then
            Dim dropDowns As cDropDowns = New cDropDowns(CStr(Session("ConnString")))
            Dim timeSheet As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))

        End If
    End Sub

#End Region

#Region " Validations"

#End Region

    Private Sub CheckForRowInsert()

        If Me.IsPostBack Then

            If Me.EventTarget = "InsertTimesheetRow" AndAlso Me.EventArgument = "angularjs" Then

                Dim oJobFuncs As cJobFunctions = New cJobFunctions(CStr(Session("ConnString")))
                Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                Dim ThisClient As String
                Dim ThisDiv As String
                Dim ThisProd As String
                Dim ThisJob As String
                Dim ThisJobComp As String
                Dim ThisFuncCat As String
                Dim ThisDept As String
                Dim ThisProdCat As String
                Dim ThisHours As String
                Dim strError As String
                Dim CurrEditStatus As AdvantageFramework.Timesheet.TimesheetEditType
                Dim returnmessage As String = ""
                Dim AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm = Nothing
                Dim AccountSetupForms As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
                Dim TotalPercent As Decimal = 0

                Try
                    Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                        AccountSetupForms = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByJobandComponent(DbContext, _JobNumber, _JobComponentNumber).ToList

                        If AccountSetupForms IsNot Nothing Then
                            For Each AccountSetup In AccountSetupForms
                                If AccountSetup.ClientCode = Me.TextBox_ClientCode.Text.Trim And AccountSetup.DivisionCode = Me.TextBox_DivisionCode.Text.Trim And AccountSetup.ProductCode = Me.TextBox_ProductCode.Text.Trim Then
                                    Me.ShowMessage("Client, Division, Product has already been added.")
                                    Exit Sub
                                End If
                            Next
                        End If

                        Dim oValidation As cValidations = New cValidations(CStr(Session("ConnString")))
                        If oValidation.ValidateCDP(Me.TextBox_ClientCode.Text.Trim, "", "", True) = False Then
                            Me.ShowMessage("Invalid Client!")
                            Exit Sub
                        End If
                        If oValidation.ValidateCDP(Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, "", True) = False Then
                            Me.ShowMessage("Invalid Client, Division!")
                            Exit Sub
                        End If
                        If oValidation.ValidateCDP(Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, Me.TextBox_ProductCode.Text.Trim, True) = False Then
                            Me.ShowMessage("Invalid Client, Division, Product!")
                            Exit Sub
                        End If

                        If Me.TextBox_ClientCode.Text <> String.Empty Then
                            If oValidation.ValidateCDPIsViewable("CL", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, String.Empty, String.Empty, "ts") = False Then
                                Me.TextBox_ClientCode.Focus()
                                Me.ShowMessage("Access to this Client is denied.")

                                Exit Sub
                            End If
                        End If
                        If Me.TextBox_ClientCode.Text <> String.Empty And Me.TextBox_DivisionCode.Text <> String.Empty Then
                            If oValidation.ValidateCDPIsViewable("DI", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, String.Empty, "ts") = False Then
                                Me.TextBox_DivisionCode.Focus()
                                Me.ShowMessage("Access to this Division is denied.")

                                Exit Sub
                            End If
                        End If
                        If Me.TextBox_ClientCode.Text <> String.Empty And Me.TextBox_DivisionCode.Text <> String.Empty And Me.TextBox_ProductCode.Text <> String.Empty Then
                            If oValidation.ValidateCDPIsViewable("PR", Session("UserCode"), Me.TextBox_ClientCode.Text.Trim, Me.TextBox_DivisionCode.Text.Trim, Me.TextBox_ProductCode.Text.Trim, "ts") = False Then
                                Me.TextBox_ProductCode.Focus()
                                Me.ShowMessage("Access to this Product is denied.")

                                Exit Sub
                            End If
                        End If

                        If IsNumeric(Me.TextBox_PercentSplit.Text) = False Then
                            Me.ShowMessage("Invalid Percent.")

                            Exit Sub
                        End If


                        AccountSetupForm = New AdvantageFramework.Database.Entities.AccountSetupForm
                        AccountSetupForm.JobNumber = _JobNumber
                        AccountSetupForm.JobComponentNumber = _JobComponentNumber
                        AccountSetupForm.ClientCode = Me.TextBox_ClientCode.Text
                        AccountSetupForm.DivisionCode = Me.TextBox_DivisionCode.Text
                        AccountSetupForm.ProductCode = Me.TextBox_ProductCode.Text
                        AccountSetupForm.AccountSetupCode1 = Me.TextBox_AccountSetupCode1.Text
                        AccountSetupForm.AccountSetupCode2 = Me.TextBox_AccountSetupCode2.Text
                        AccountSetupForm.AccountSetupCode3 = Me.TextBox_AccountSetupCode3.Text
                        AccountSetupForm.AccountSetupCode4 = Me.TextBox_AccountSetupCode4.Text
                        AccountSetupForm.PercentSplit = Me.TextBox_PercentSplit.Text
                        AccountSetupForm.Balanced = False
                        AdvantageFramework.Database.Procedures.AccountSetupForm.Insert(DbContext, AccountSetupForm, returnmessage)

                    End Using

                    Me.CheckForBalance()

                    Me.RadGridAccountSetupForm.Rebind()
                    Me.ClearAddNewTextboxes()
                    Me.SetClientCodeFocus()

                Catch ex As Exception
                    Me.ShowMessage(("Error saving new row"))
                End Try
            End If
        End If
    End Sub

    Private Sub CheckForBalance()
        Try
            Dim AccountSetupForm As AdvantageFramework.Database.Entities.AccountSetupForm = Nothing
            Dim AccountSetupForms As Generic.List(Of AdvantageFramework.Database.Entities.AccountSetupForm) = Nothing
            Dim returnmessage As String = ""
            Dim TotalPercent As Decimal = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                AccountSetupForms = AdvantageFramework.Database.Procedures.AccountSetupForm.LoadByJobandComponent(DbContext, _JobNumber, _JobComponentNumber).ToList

                If AccountSetupForms IsNot Nothing Then
                    For Each AccountSetup In AccountSetupForms
                        TotalPercent += AccountSetup.PercentSplit
                    Next
                End If

                If TotalPercent = 0 Or TotalPercent = 100 Then
                    For Each AccountSetup In AccountSetupForms
                        If AccountSetup IsNot Nothing Then
                            AccountSetup.Balanced = True
                            AdvantageFramework.Database.Procedures.AccountSetupForm.Update(DbContext, AccountSetup, returnmessage)
                        End If
                    Next
                Else
                    For Each AccountSetup In AccountSetupForms
                        If AccountSetup IsNot Nothing Then
                            AccountSetup.Balanced = False
                            AdvantageFramework.Database.Procedures.AccountSetupForm.Update(DbContext, AccountSetup, returnmessage)
                        End If
                    Next
                End If

            End Using


        Catch ex As Exception

        End Try
    End Sub

    Private Function ShowNewEntryMessage(ByVal DataKey As String, ByRef Message As String) As Boolean
        Dim ReturnValue As Boolean = False

        Try

            If DataKey.Contains("|") = True Then

                Dim ar() As String

                ar = DataKey.Split("|") '"INSERT_SUCCESS|4129|1|8.000|120.000|0|-15|Warning, your time entry will cause the total hours posted to exceed the approved estimate amount for the function."

                If ar IsNot Nothing AndAlso ar.Length > 7 Then
                    If ar(6) IsNot Nothing AndAlso ar(7) IsNot Nothing Then

                        Select Case CType(ar(6), Integer)
                            Case -15, -16, -17

                                ReturnValue = True
                                Message = ar(7)

                        End Select

                    End If
                End If

            End If

        Catch ex As Exception
        End Try

        Return ReturnValue

    End Function

#End Region

End Class

Public Class AccountSetupSelection

    Public Property ID As Integer
    Public Property JobNumber As Integer
    Public Property JobComponentNumber As Short
    Public Property ClientCode As String
    Public Property ClientName As String
    Public Property DivisionCode As String
    Public Property DivisionName As String
    Public Property ProductCode As String
    Public Property ProductName As String
    Public Property AccountSetupCode1 As String
    Public Property AccountSetupCode2 As String
    Public Property AccountSetupCode3 As String
    Public Property AccountSetupCode4 As String
    Public Property PercentSplit As Decimal
    Public Property Balanced As Boolean

End Class
