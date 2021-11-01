Imports System.Web.Helpers
Imports Telerik.Web.UI
Imports AdvantageFramework.Media.Classes

Public Class MediaOrder_List
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Private Enum Grouping

        [None] = 0
        Type = 1
        Order_Number = 2
        Vendor = 3
        Ad_Size = 4

    End Enum
    Private Enum Properties

        CanEditOrderProcessingControl
        MediaProcessControls
        IncludeAvailableMedia
        Grouping
        CanEditMediaPage

    End Enum
    Private Enum RowCommand

        RemoveFromThisJob
        AddToThisJob
        RemoveSelected
        AddSelected

    End Enum

#End Region

#Region " Variables "

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Short = 0
    Private _LoadOnlyAvailable As Boolean = False

    Private _HasInternet As Boolean = False
    Private _HasMagazine As Boolean = False
    Private _HasNewspaper As Boolean = False
    Private _HasOutOfHome As Boolean = False
    Private _HasRadio As Boolean = False
    Private _HasTV As Boolean = False

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
    Private Property CanEditOrderProcessingControl As Boolean
        Get
            If ViewState("CanEditOrderProcessingControl") Is Nothing Then
                ViewState("CanEditOrderProcessingControl") = False
            End If
            Return ViewState("CanEditOrderProcessingControl")
        End Get
        Set(value As Boolean)
            ViewState("CanEditOrderProcessingControl") = value
        End Set
    End Property
    Private Property CanEditMediaPage As Boolean
        Get
            If ViewState("CanEditMediaPage") Is Nothing Then
                ViewState("CanEditMediaPage") = False
            End If
            Return ViewState("CanEditMediaPage")
        End Get
        Set(value As Boolean)
            ViewState("CanEditMediaPage") = value
        End Set
    End Property
    Private Property MediaProcessControls As Generic.List(Of AdvantageFramework.Database.Entities.JobProcess) = Nothing
    Private Property IncludeAvailableMedia As Boolean
        Get

            Dim AppVars As New cAppVars(cAppVars.Application.MEDIAORDER_LIST)

            AppVars.getAllAppVars()

            Return AppVars.getAppVar(Me.Properties.IncludeAvailableMedia.ToString(), "Boolean", "False")

        End Get
        Set(value As Boolean)

            Dim AppVars As New cAppVars(cAppVars.Application.MEDIAORDER_LIST)

            AppVars.getAllAppVars()
            AppVars.setAppVar(Me.Properties.IncludeAvailableMedia.ToString(), value, "Boolean")
            AppVars.SaveAllAppVars()

        End Set
    End Property
    Private Property MediaOrderListGrouping As Grouping
        Get

            Dim AppVars As New cAppVars(cAppVars.Application.MEDIAORDER_LIST)

            AppVars.getAllAppVars()

            Return CType(CType(AppVars.getAppVar(Me.Properties.Grouping.ToString(), "Integer", "0"), Integer), Grouping)

        End Get
        Set(value As Grouping)

            Dim AppVars As New cAppVars(cAppVars.Application.MEDIAORDER_LIST)

            AppVars.getAllAppVars()
            AppVars.setAppVar(Me.Properties.Grouping.ToString(), CType(value, Integer).ToString(), "Integer")
            AppVars.SaveAllAppVars()

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    'Public Sub CheckBoxIsOrder_CheckedChanged(sender As Object, e As EventArgs)

    '    Dim Checkbox As CheckBox = DirectCast(sender, CheckBox)

    '    If Checkbox IsNot Nothing Then

    '        Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(Checkbox.Parent.Parent, Telerik.Web.UI.GridDataItem)

    '        If CurrentGridRow IsNot Nothing Then

    '            Dim DataKeyString As String = SetDataKey(CurrentGridRow)

    '            SaveMediaOrderLinesRow(DataKeyString, "chk", "CheckBoxIsOrder", If(Checkbox.Checked = True, "1", "0"))
    '            RadGridMediaOrderLines.Rebind()

    '        End If

    '    End If

    'End Sub

    Private Sub CheckBoxIncludeAvailableMedia_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxIncludeAvailableMedia.CheckedChanged

        Me.IncludeAvailableMedia = CheckBoxIncludeAvailableMedia.Checked
        Me.RadGridMediaOrderLines.Rebind()

    End Sub
    Public Sub CheckBoxIsOrder_CheckedChanged(sender As Object, e As EventArgs)

        Dim Check As CheckBox = CType(sender, CheckBox)
        Dim Row As GridDataItem = Check.Parent.Parent
        If Row IsNot Nothing Then

            SaveMediaOrderLinesRow(SetDataKey(Row), "chk", Check.ClientID, If(Check.Checked, "1", "0"))
            Me.RadGridMediaOrderLines.Rebind()

        End If

    End Sub

    Private Sub RadComboBoxGroupBy_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxGroupBy.SelectedIndexChanged

        MediaOrderListGrouping = CType(CType(Me.RadComboBoxGroupBy.SelectedItem.Value, Integer), Grouping)

        Me.RadGridMediaOrderLines.Rebind()

    End Sub
    Public Sub RadComboBoxOrderProcessingControl_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Dim Combo As RadComboBox = CType(sender, RadComboBox)
        Dim Row As GridDataItem = Combo.Parent.Parent

        If Row IsNot Nothing Then

            SaveMediaOrderLinesRow(SetDataKey(Row), "ddl", Combo.ClientID, Combo.SelectedItem.Value)
            Me.RadGridMediaOrderLines.Rebind()

        End If

    End Sub
    Public Sub RadComboBoxIsOrder_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Dim Combo As RadComboBox = CType(sender, RadComboBox)
        Dim Row As GridDataItem = Combo.Parent.Parent

        If Row IsNot Nothing Then

            SaveMediaOrderLinesRow(SetDataKey(Row), "ddl", Combo.ClientID, Combo.SelectedItem.Value)
            Me.RadGridMediaOrderLines.Rebind()

        End If

    End Sub

    Private Sub RadGridMediaOrderLines_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridMediaOrderLines.ItemCommand

        If IsNumeric(e.CommandName) Then

            Dim SelectedCommand As RowCommand = CType(CType(e.CommandName, Integer), RowCommand)
            Dim CurrentMediaOrderLine As AdvantageFramework.Media.Classes.MediaOrderLine

            Select Case SelectedCommand

                Case RowCommand.AddToThisJob, RowCommand.RemoveFromThisJob

                    CurrentMediaOrderLine = New AdvantageFramework.Media.Classes.MediaOrderLine
                    CurrentMediaOrderLine = ParseDataKey(e.CommandArgument)

                    If CurrentMediaOrderLine IsNot Nothing Then

                        If Me.SaveRow(CurrentMediaOrderLine, SelectedCommand) = True Then

                            Me.RadGridMediaOrderLines.Rebind()

                        End If

                    End If

                Case RowCommand.AddSelected, RowCommand.RemoveSelected

                    Dim Success As Boolean = False
                    Dim HasSelected As Boolean = False

                    For Each Row As GridDataItem In Me.RadGridMediaOrderLines.MasterTableView.Items

                        If Row.Selected = True Then

                            HasSelected = True

                            CurrentMediaOrderLine = New AdvantageFramework.Media.Classes.MediaOrderLine
                            CurrentMediaOrderLine = ParseDataKey(SetDataKey(Row))

                            If Me.SaveRow(CurrentMediaOrderLine, SelectedCommand) = True Then


                            End If

                        End If

                    Next

                    If HasSelected = True Then

                        Me.RadGridMediaOrderLines.Rebind()

                    Else


                    End If

            End Select

        Else

            Select Case e.CommandName


            End Select

        End If


        ''Dim RowSelected As Boolean = False

        ''For Each Row As GridDataItem In Me.RadGridMediaOrderLines.MasterTableView.Items

        ''    If Row.Selected = True Then

        ''        SaveRow(Row, CType(CType(e.CommandName, Integer), RowCommand))
        ''        RowSelected = True

        ''    End If

        ''Next

        ''If RowSelected = False Then

        ''    Dim LinkButton As LinkButton = CType(sender, LinkButton)
        ''    Dim CurrentGridRow As Telerik.Web.UI.GridDataItem = DirectCast(LinkButton.Parent.Parent, Telerik.Web.UI.GridDataItem)

        ''    If CurrentGridRow IsNot Nothing Then

        ''        If SaveRow(CurrentGridRow, CType(CType(e.CommandName, Integer), RowCommand)) = True Then

        ''            Me.RadGridMediaOrderLines.Rebind()

        ''        End If

        ''    End If

        ''End If

    End Sub
    Private Sub RadGridMediaOrderLines_ItemCreated(sender As Object, e As GridItemEventArgs) Handles RadGridMediaOrderLines.ItemCreated

        'If TypeOf e.Item Is GridFilteringItem Then

        '    Dim FilteringItem As GridFilteringItem = e.Item
        '    Dim FilterTextbox As TextBox = FilteringItem("GridBoundColumnOrderNumber").Controls(0)

        '    If FilterTextbox IsNot Nothing Then

        '        FilterTextbox.Width = Unit.Pixel(50)

        '    End If

        'End If


        'If TypeOf e.Item Is GridGroupHeaderItem Then

        '    Dim item As GridGroupHeaderItem = TryCast(e.Item, GridGroupHeaderItem)
        '    'Dim lnk As New LinkButton()
        '    'lnk.ID = "lnkReservations"
        '    'lnk.Text = "ExportGroup"
        '    'AddHandler lnk.Command, AddressOf lnkReservations_Command
        '    Dim Label As New Label
        '    Label.Text = "Is Order:&nbsp;&nbsp;"
        '    Dim CheckBox As New CheckBox
        '    CheckBox.ID = "CheckBoxIsOrder"

        '    item.DataCell.Controls.Add(Label)
        '    item.DataCell.Controls.Add(CheckBox)

        'End If

    End Sub
    Private Sub RadGridMediaOrderLines_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridMediaOrderLines.ItemDataBound
        Select Case e.Item.ItemType

            Case GridItemType.Header

                Dim CurrentHeader As GridHeaderItem = TryCast(e.Item, GridHeaderItem)

                If CurrentHeader IsNot Nothing Then

                    Dim RemoveSelectedFromThisJobImageButton As ImageButton = CurrentHeader.FindControl("ImageButtonRemoveSelectedFromThisJob")
                    Dim AddSelectedToThisJobImageButton As ImageButton = CurrentHeader.FindControl("ImageButtonAddSelectedToThisJob")

                    If RemoveSelectedFromThisJobImageButton IsNot Nothing Then RemoveSelectedFromThisJobImageButton.CommandName = CType(RowCommand.RemoveSelected, Integer).ToString()
                    If AddSelectedToThisJobImageButton IsNot Nothing Then AddSelectedToThisJobImageButton.CommandName = CType(RowCommand.AddSelected, Integer).ToString()

                End If

            Case GridItemType.AlternatingItem, GridItemType.Item

                If _MediaProcessControls Is Nothing Then

                    Using dc As New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                        _MediaProcessControls = AdvantageFramework.Media.LoadMediaProcessControls(dc)

                    End Using

                End If

                Dim CurrentGridRow As GridDataItem = TryCast(e.Item, Telerik.Web.UI.GridDataItem)
                Dim CurrentMediaLine As AdvantageFramework.Media.Classes.MediaOrderLine = CurrentGridRow.DataItem

                If CurrentGridRow IsNot Nothing AndAlso CurrentMediaLine IsNot Nothing Then

                    If CurrentMediaLine.IsInJob = False Then CurrentGridRow.Style.Add("font-style", "italic")

                    'If CurrentMediaLine.OrderType = "I" AndAlso _HasInternet = False Then _HasInternet = True
                    'If CurrentMediaLine.OrderType = "M" AndAlso _HasMagazine = False Then _HasMagazine = True
                    'If CurrentMediaLine.OrderType = "N" AndAlso _HasNewspaper = False Then _HasNewspaper = True
                    'If CurrentMediaLine.OrderType = "O" AndAlso _HasOutOfHome = False Then _HasOutOfHome = True
                    'If CurrentMediaLine.OrderType = "R" AndAlso _HasRadio = False Then _HasRadio = True
                    'If CurrentMediaLine.OrderType = "T" AndAlso _HasTV = False Then _HasTV = True

                    'Dim IsOrderCheckBox As CheckBox = CurrentGridRow.FindControl("CheckBoxIsOrder")
                    Dim OrderProcessingControlRadComboBox As RadComboBox = CurrentGridRow.FindControl("RadComboBoxOrderProcessingControl")
                    Dim IsOrderRadComboBox As RadComboBox = CurrentGridRow.FindControl("RadComboBoxIsOrder")
                    Dim OrderLineStatusLinkButton As LinkButton = CurrentGridRow.FindControl("LinkButtonOrderLineStatus")
                    Dim AdSizeCodeLinkButton As LinkButton = CurrentGridRow.FindControl("LinkButtonAdSizeCode")
                    Dim AdSizeDescriptionLinkButton As LinkButton = CurrentGridRow.FindControl("LinkButtonAdSizeDescription")
                    Dim DateToBillTextBox As TextBox = CurrentGridRow.FindControl("TextBoxDateToBill")

                    Dim RemoveFromThisJobDiv As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivRemoveFromThisJob")
                    Dim RemoveFromThisJobImageButton As ImageButton = CurrentGridRow.FindControl("ImageButtonRemoveFromThisJob")

                    Dim AddToThisJobDiv As HtmlControls.HtmlControl = CurrentGridRow.FindControl("DivAddToThisJob")
                    Dim AddToThisJobImageButton As ImageButton = CurrentGridRow.FindControl("ImageButtonAddToThisJob")

                    Dim DataKeyString As String = SetDataKey(CurrentGridRow)

                    ''IsOrderCheckBox.InputAttributes.Add("onclick", String.Format("dataChangeCheckBoxIsOrder('{0}','{1}');setOrderProcessingControlEdit('{1}','{2}',{3});", _
                    ''                                                             DataKeyString, IsOrderCheckBox.ClientID, OrderProcessingControlRadComboBox.ClientID, _CanEditOrderProcessingControl.ToString().ToLower()))

                    '' ''DateToBillTextBox.Attributes.Add("ondblclick", String.Format("setDataKey('{0}');showPopup(this, event);", DataKeyString))
                    '' ''DateToBillTextBox.Attributes.Add("onblur", String.Format("dataChange('{0}', 'txt', this.name, this.value);", DataKeyString))

                    OrderProcessingControlRadComboBox.DataSource = _MediaProcessControls
                    OrderProcessingControlRadComboBox.DataTextField = AdvantageFramework.Database.Entities.JobProcess.Properties.Description.ToString()
                    OrderProcessingControlRadComboBox.DataValueField = AdvantageFramework.Database.Entities.JobProcess.Properties.ID.ToString()
                    OrderProcessingControlRadComboBox.DataBind()

                    If CurrentMediaLine.OrderProcessingControl IsNot Nothing Then

                        MiscFN.RadComboBoxSetIndex(OrderProcessingControlRadComboBox, CurrentMediaLine.OrderProcessingControl, False, True)

                    End If

                    If CurrentMediaLine.IsOrder.GetValueOrDefault(False) = True Then

                        MiscFN.RadComboBoxSetIndex(IsOrderRadComboBox, CType(AdvantageFramework.Media.MediaLineStatus.Order, Integer).ToString(), False)

                    Else

                        MiscFN.RadComboBoxSetIndex(IsOrderRadComboBox, CType(AdvantageFramework.Media.MediaLineStatus.Quote, Integer).ToString(), False)

                    End If

                    If CurrentMediaLine.IsOrder.GetValueOrDefault(False) = False AndAlso CanEditOrderProcessingControl = True Then

                        OrderProcessingControlRadComboBox.Enabled = True

                    Else

                        OrderProcessingControlRadComboBox.Enabled = False

                    End If


                    '' ''AdSizeCodeLinkButton.Attributes.Add("onclick", String.Format("alert('{0}');return false;", "Drill down to ad specs placeholder"))
                    '' ''AdSizeDescriptionLinkButton.Attributes.Add("onclick", String.Format("alert('{0}');return false;", "Drill down to ad specs placeholder"))

                    If CurrentMediaLine.IsInJob = True Then

                        RemoveFromThisJobImageButton.CommandName = CType(RowCommand.RemoveFromThisJob, Integer).ToString()
                        RemoveFromThisJobImageButton.CommandArgument = DataKeyString
                        AdvantageFramework.Web.Presentation.Controls.DivHide(AddToThisJobDiv)
                        If CanEditMediaPage = True Then
                            DateToBillTextBox.Attributes.Add("ondblclick", String.Format("setDataKey('{0}');showPopup(this, event);return false;", DataKeyString))
                            DateToBillTextBox.Attributes.Add("onblur", String.Format("dataChangeRadGridMediaOrderLines('{0}', 'txt', this.name, this.value);return false;", DataKeyString))
                        Else
                            DateToBillTextBox.Enabled = False
                            IsOrderRadComboBox.Enabled = False
                            OrderProcessingControlRadComboBox.Enabled = False
                            AdSizeCodeLinkButton.Enabled = False
                            AdSizeDescriptionLinkButton.Enabled = False
                        End If

                    Else

                        AddToThisJobImageButton.CommandName = CType(RowCommand.AddToThisJob, Integer).ToString()
                        AddToThisJobImageButton.CommandArgument = DataKeyString
                        AdvantageFramework.Web.Presentation.Controls.DivHide(RemoveFromThisJobDiv)
                        DateToBillTextBox.Enabled = False
                        IsOrderRadComboBox.Enabled = False
                        OrderProcessingControlRadComboBox.Enabled = False
                        AdSizeCodeLinkButton.Enabled = False
                        AdSizeDescriptionLinkButton.Enabled = False

                    End If

                    Dim StatusHistoryQs As New AdvantageFramework.Web.QueryString

                    StatusHistoryQs.Page = "MediaOrder_StatusHistory.aspx"

                    StatusHistoryQs.MediaOrderNumber = CurrentMediaLine.OrderNumber
                    StatusHistoryQs.MediaOrderLineNumber = CurrentMediaLine.LineNumber
                    StatusHistoryQs.MediaOrderRevisionNumber = CurrentMediaLine.RevisionNumber
                    StatusHistoryQs.MediaOrderSequenceNumber = CurrentMediaLine.SequenceNumber

                    If CurrentMediaLine.JobNumber IsNot Nothing Then StatusHistoryQs.JobNumber = CurrentMediaLine.JobNumber
                    If CurrentMediaLine.JobComponentNumber IsNot Nothing Then StatusHistoryQs.JobComponentNumber = CurrentMediaLine.JobComponentNumber

                    Select Case CurrentMediaLine.OrderType
                        Case "I"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.Internet

                        Case "M"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.Magazine

                        Case "N"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.Newspaper

                        Case "O"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.Outdoor

                        Case "R"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.Radio

                        Case "T"

                            StatusHistoryQs.MediaType = AdvantageFramework.Web.QueryString.MediaOrderType.TV

                    End Select

                    OrderLineStatusLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("Status History", StatusHistoryQs.ToString(True)))

                End If

            Case GridItemType.Footer

                Me.CheckBoxIncludeInternet.Visible = _HasInternet
                Me.CheckBoxIncludeMagazine.Visible = _HasMagazine
                Me.CheckBoxIncludeNewspaper.Visible = _HasNewspaper
                Me.CheckBoxIncludeOutOfHome.Visible = _HasOutOfHome
                Me.CheckBoxIncludeRadio.Visible = _HasRadio
                Me.CheckBoxIncludeTV.Visible = _HasTV

        End Select
    End Sub
    Private Sub RadGridMediaOrderLines_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridMediaOrderLines.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me.RadGridMediaOrderLines.DataSource = AdvantageFramework.Media.LoadByJobAndComponent(DbContext, _JobNumber, _JobComponentNumber, Me.CheckBoxIncludeAvailableMedia.Checked, _Session)
            Me.RadGridMediaOrderLines.MasterTableView.GetColumnSafe("GridTemplateColumnAddToThisJob").Visible = Me.CheckBoxIncludeAvailableMedia.Checked

            Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Clear()
            Select Case CType(CType(Me.RadComboBoxGroupBy.SelectedValue, Integer), Grouping)

                Case Grouping.Order_Number

                    Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("OrderNumber Order Group By OrderNumber")

                Case Grouping.Ad_Size

                    Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("AdSizeDescription [Ad Size] Group By AdSizeDescription")

                Case Grouping.Type

                    Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("OrderTypeName Type Group By OrderTypeName")

                Case Grouping.Vendor

                    Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("VendorName Vendor Group By VendorName")

                Case Else

                    Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("IsInJobText Availability Group By IsInJobText")

            End Select

            'Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Clear()
            'Me.RadGridMediaOrderLines.MasterTableView.GroupByExpressions.Add("IsInJob [Is currently in job] Group By IsInJob")

        End Using

    End Sub
    Private Sub RadGridMediaOrderLines_PreRender(sender As Object, e As EventArgs) Handles RadGridMediaOrderLines.PreRender

        'objects


    End Sub

#End Region
#Region " Page "

    Private Sub MediaOrder_List_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Me.CheckModuleAccess(AdvantageFramework.Security.Modules.ProjectManagement_JobJacket, True)

        'This has to be called on every load
        AdvantageFramework.Web.Presentation.Controls.LoadDataGridViewColumnUserSettings(Me.RadGridMediaOrderLines)

        Me.CanEditOrderProcessingControl = Me.CheckAdvantageModuleAccess(AdvantageFramework.Security.Modules.Media_OrderProcessCtrl) = 1
        Me.CanEditMediaPage = Me.LoadUserGroupSettingAccess(AdvantageFramework.Security.GroupSettings.Schedule_AllowMediaPageEdit) = 1

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            'Dim GridSettings As New GridSettingsPersister(Me.RadGridMediaOrderLines)
            'GridSettings.LoadFromDatabase()

        End If

        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber

        If Me.CurrentQuerystring.Get("loa") IsNot Nothing Then

            Me._LoadOnlyAvailable = Me.CurrentQuerystring.Get("loa") = "1"

        End If

    End Sub
    Protected Sub MediaOrder_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.LoadGroupBy()
            MiscFN.RadComboBoxSetIndex(Me.RadComboBoxGroupBy, CType(MediaOrderListGrouping, Integer).ToString(), False)
            Me.CheckBoxIncludeAvailableMedia.Checked = Me.IncludeAvailableMedia

        Else

            Select Case Me.EventTarget

                Case "RefreshGrid"

                    Me.RadGridMediaOrderLines.Rebind()

            End Select

        End If

    End Sub

#End Region
#Region " Pagemethods "

    <System.Web.Services.WebMethod(True)>
    Public Shared Function SaveMediaOrderLinesRow(ByVal DataKey As String,
                                                  ByVal ControlType As String, ByVal ControlName As String, ByVal ControlValue As String) As String

        Dim ReturnString As String = ""

        Try
            Dim ar As String()
            ar = DataKey.Split("|")

            If ar.Length <> 8 Then

                Return "Error: Could not get datakey"

            Else

                Dim Update As Boolean = False
                Dim UpdateHeader As Boolean = False
                Dim OrderType As String = String.Empty
                Dim OrderNumber As Integer = 0
                Dim LineNumber As Short = 0
                Dim RevisionNumber As Short = -1
                Dim SequenceNumber As Short = -1
                Dim JobNumber As Integer = 0
                Dim JobComponentNumber As Short = 0
                Dim IsInJob As Boolean = False

                If ar(0) IsNot Nothing Then OrderType = ar(0)
                If ar(1) IsNot Nothing AndAlso IsNumeric(ar(1)) Then OrderNumber = CType(ar(1), Integer)
                If ar(2) IsNot Nothing AndAlso IsNumeric(ar(2)) Then LineNumber = CType(ar(2), Short)
                If ar(3) IsNot Nothing AndAlso IsNumeric(ar(3)) Then RevisionNumber = CType(ar(3), Short)
                If ar(4) IsNot Nothing AndAlso IsNumeric(ar(4)) Then SequenceNumber = CType(ar(4), Short)
                If ar(5) IsNot Nothing AndAlso IsNumeric(ar(5)) Then JobNumber = CType(ar(5), Integer)
                If ar(6) IsNot Nothing AndAlso IsNumeric(ar(6)) Then JobComponentNumber = CType(ar(6), Short)
                If ar(7) IsNot Nothing AndAlso ar(7).ToString().ToLower() = "true" Then IsInJob = True

                If OrderType IsNot String.Empty AndAlso OrderNumber > 0 AndAlso LineNumber > 0 AndAlso RevisionNumber >= 0 AndAlso SequenceNumber >= 0 AndAlso JobNumber > 0 AndAlso JobComponentNumber > 0 Then

                    If ControlName.Contains("RadComboBoxIsOrder") OrElse ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                        UpdateHeader = True

                    ElseIf ControlName.Contains("TextBoxDateToBill") Then

                        UpdateHeader = False

                    End If

                    Using DbContext = New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                        Select Case OrderType

                            Case "I"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.InternetOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.InternetOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.InternetOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.InternetOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                            Case "M"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.MagazineOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.MagazineOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.MagazineOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.MagazineOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.MagazineOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                            Case "N"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.NewspaperOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.NewspaperOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.NewspaperOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.NewspaperOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                            Case "O"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.OutOfHomeOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.OutOfHomeOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.OutOfHomeOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.OutOfHomeOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                            Case "R"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.RadioOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.RadioOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.RadioOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.RadioOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.RadioOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                            Case "T"

                                If UpdateHeader = True Then

                                    Dim OrderHeader As New AdvantageFramework.Database.Entities.TVOrder
                                    OrderHeader = Nothing

                                    OrderHeader = AdvantageFramework.Database.Procedures.TVOrder.LoadByOrderNumber(DbContext, OrderNumber)

                                    If OrderHeader IsNot Nothing Then

                                        If ControlName.Contains("RadComboBoxIsOrder") Then

                                            OrderHeader.Status = ControlValue
                                            Update = True

                                        ElseIf ControlName.Contains("RadComboBoxOrderProcessingControl") Then

                                            OrderHeader.OrderProcessControl = CType(ControlValue, Short)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.TVOrder.Update(DbContext, OrderHeader)

                                    End If

                                Else

                                    Dim OrderDetail As New AdvantageFramework.Database.Entities.TVOrderDetail
                                    OrderDetail = Nothing

                                    OrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadByAllPrimaryKeys(DbContext, OrderNumber, LineNumber, RevisionNumber, SequenceNumber)

                                    If OrderDetail IsNot Nothing Then

                                        If ControlName.Contains("TextBoxDateToBill") = True Then

                                            OrderDetail.DateToBill = CType(ControlValue, Date)
                                            Update = True

                                        End If

                                        If Update = True Then AdvantageFramework.Database.Procedures.TVOrderDetail.Update(DbContext, OrderDetail)

                                    End If

                                End If

                        End Select

                    End Using

                End If

            End If

            If ControlName.Contains("CheckBoxIsOrder") Then

                ReturnString = "REBIND"

            End If

            Return ReturnString

        Catch ex As Exception

            Return ex.Message.ToString()

        End Try

    End Function

#End Region

    Private Function LoadGroupBy()

        Me.RadComboBoxGroupBy.Items.Clear()

        Dim Items As Generic.Dictionary(Of Long, String) = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(Grouping), True)
        Dim ComboBoxItem As RadComboBoxItem

        If Items IsNot Nothing Then

            For Each Item In Items

                ComboBoxItem = New RadComboBoxItem

                ComboBoxItem.Text = Item.Value.ToString().Replace("_", " ")
                ComboBoxItem.Value = Item.Key

                Me.RadComboBoxGroupBy.Items.Add(ComboBoxItem)

            Next

        End If

    End Function
    Private Function LoadMediaLineStatus(ByRef ComboBox As RadComboBox)

        ComboBox.Items.Clear()

        Dim Items As Generic.Dictionary(Of Long, String) = AdvantageFramework.EnumUtilities.GetEnumDictionary(GetType(AdvantageFramework.Media.MediaLineStatus), True)
        Dim ComboBoxItem As RadComboBoxItem

        If Items IsNot Nothing Then

            For Each Item In Items

                ComboBoxItem = New RadComboBoxItem

                ComboBoxItem.Text = Item.Value
                ComboBoxItem.Value = Item.Key

                ComboBox.Items.Add(ComboBoxItem)

            Next

        End If

    End Function
    Private Function ParseDataKey(ByVal DataKey As String) As AdvantageFramework.Media.Classes.MediaOrderLine

        Try

            Dim mol As New AdvantageFramework.Media.Classes.MediaOrderLine
            Dim ar As String()
            ar = DataKey.Split("|")

            mol.OrderType = ar(0)
            mol.OrderNumber = ar(1)
            mol.LineNumber = ar(2)
            mol.RevisionNumber = ar(3)
            mol.SequenceNumber = ar(4)
            If IsNumeric(ar(5)) Then mol.JobNumber = ar(5)
            If IsNumeric(ar(6)) Then mol.JobComponentNumber = ar(6)
            If ar(7) IsNot Nothing AndAlso ar(7).ToString().ToLower() = "true" Then mol.IsInJob = True

            Return mol

        Catch ex As Exception

            Me.ShowMessage(ex.Message.ToString())
            Return Nothing

        End Try

    End Function
    Private Function SaveRow(ByRef MediaOrderLine As AdvantageFramework.Media.Classes.MediaOrderLine, ByVal Command As RowCommand) As Boolean

        Dim Success As Boolean = False

        If MediaOrderLine IsNot Nothing Then

            Using DbContext As New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Select Case MediaOrderLine.OrderType
                    Case "I"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.InternetOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.InternetOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.InternetOrderDetail.Update(DbContext, OrderDetail)

                        End If

                    Case "M"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.MagazineOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.MagazineOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.MagazineOrderDetail.Update(DbContext, OrderDetail)

                        End If

                    Case "N"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.NewspaperOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.NewspaperOrderDetail.Update(DbContext, OrderDetail)

                        End If

                    Case "O"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.OutOfHomeOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.OutOfHomeOrderDetail.Update(DbContext, OrderDetail)

                        End If

                    Case "R"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.RadioOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.RadioOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.RadioOrderDetail.Update(DbContext, OrderDetail)

                        End If

                    Case "T"

                        Dim OrderDetail As New AdvantageFramework.Database.Entities.TVOrderDetail
                        OrderDetail = Nothing

                        OrderDetail = AdvantageFramework.Database.Procedures.TVOrderDetail.LoadByAllPrimaryKeys(DbContext, MediaOrderLine.OrderNumber, MediaOrderLine.LineNumber, MediaOrderLine.RevisionNumber, MediaOrderLine.SequenceNumber)

                        If OrderDetail IsNot Nothing Then

                            Select Case Command

                                Case RowCommand.RemoveFromThisJob, RowCommand.RemoveSelected

                                    OrderDetail.JobNumber = Nothing
                                    OrderDetail.JobComponentNumber = Nothing

                                Case RowCommand.AddToThisJob, RowCommand.AddSelected

                                    OrderDetail.JobNumber = Me._JobNumber
                                    OrderDetail.JobComponentNumber = Me._JobComponentNumber

                            End Select

                            Success = AdvantageFramework.Database.Procedures.TVOrderDetail.Update(DbContext, OrderDetail)

                        End If

                End Select

            End Using

        End If

        Return Success

    End Function
    Private Function SetDataKey(ByRef GridRow As GridDataItem) As String

        Dim DataKeyString As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}", GridRow.GetDataKeyValue("OrderType"),
                                                                                   GridRow.GetDataKeyValue("OrderNumber"),
                                                                                   GridRow.GetDataKeyValue("LineNumber"),
                                                                                   GridRow.GetDataKeyValue("RevisionNumber"),
                                                                                   GridRow.GetDataKeyValue("SequenceNumber"),
                                                                                   GridRow.GetDataKeyValue("JobNumber"),
                                                                                   GridRow.GetDataKeyValue("JobComponentNumber"),
                                                                                   GridRow.GetDataKeyValue("IsInJob"))

        Return DataKeyString

    End Function

#End Region

End Class
