Imports Telerik.Web.UI
Imports AdvantageFramework.AlertSystem.Classes

Public Class Alert_ListPage
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AlertListLevel As AdvantageFramework.Database.Entities.AlertListLevel = AdvantageFramework.Database.Entities.AlertListLevel.NotSet

    Private _JobNumber As Integer = 0
    Private _JobComponentNumber As Integer = 0
    Private _TaskSequenceNumber As Integer = 0
    Private _CampaignID As Integer = 0

    Private _EstimateNumber As Integer = 0
    Private _EstimateComponentNumber As Integer = 0
    Private _EstimateQuoteNumber As Integer = 0
    Private _EstimateSelectedQuotes As String = ""
    Private _EstimatePrintAll As Boolean = False

    Private _MediaATBRevisionID As Integer = 0
    Private _MediaATBNumber As Integer = 0
    Private _MediaATBRevisionNumber As Integer = 0

    Private _AccountsPayableID As Integer = 0
    Private _AccountsPayableSequenceNumber As Integer = 0

    Private _PurchaseOrderNumber As Integer = 0

    Private _RadComboBoxGroupBy As Telerik.Web.UI.RadComboBox
    Private _RadComboBoxShow As Telerik.Web.UI.RadComboBox
    Private _CheckBoxIncludeCompletedAssignments As Web.UI.WebControls.CheckBox

#End Region

#Region " Properties "

    Private Property _IncludeTasks As Boolean = False
    Public Property PageTitleString As String
        Get
            If Not ViewState("_PageTitleString") Is Nothing Then

                Return ViewState("_PageTitleString").ToString()

            Else

                Return "Alert List"

            End If
        End Get
        Set(value As String)

            ViewState("_PageTitleString") = value

        End Set
    End Property

#End Region

#Region " Page "

    Private Sub Alert_List_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString
        qs = qs.FromCurrent()

        If IsNumeric(qs.GetValue("lstlvl")) = True Then Me._AlertListLevel = CType(CType(qs.GetValue("lstlvl"), Integer), AdvantageFramework.Database.Entities.AlertListLevel)

        Me._JobNumber = qs.JobNumber

        Me._JobComponentNumber = qs.JobComponentNumber
        Me._TaskSequenceNumber = qs.TaskSequenceNumber

        Me._CampaignID = qs.CampaignIdentifier

        Me._EstimateNumber = qs.EstimateNumber
        Me._EstimateComponentNumber = qs.EstimateComponentNumber
        Me._EstimateQuoteNumber = qs.EstimateQuoteNumber
        Me._EstimateSelectedQuotes = qs.GetValue("sel_quotes")
        Me._EstimatePrintAll = qs.GetValue("print_all").ToLower() = "true"

        Me._MediaATBRevisionID = qs.MediaATBRevisionID
        Me._MediaATBNumber = qs.MediaATBNumber
        Me._MediaATBRevisionNumber = qs.MediaATBRevisionNumber

        Me._AccountsPayableID = qs.APID
        Me._AccountsPayableSequenceNumber = qs.InvoiceSequenceNumber

        Me._PurchaseOrderNumber = qs.PurchaseOrderNumber

        Me.MyUnityContextMenu.JobNumber = Me._JobNumber
        Me.MyUnityContextMenu.JobComponentNumber = Me._JobComponentNumber
        Me.MyUnityContextMenu.HideItems = New UnityUC.UnityItem() {UnityUC.UnityItem.Alerts}

    End Sub
    Private Sub Alert_List_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me._RadComboBoxGroupBy = Me.RadToolbarAlertList.Items.FindItemByValue("RadToolBarButtonRadComboBoxGroupBy").FindControl("RadComboBoxGroupBy")
        Me._RadComboBoxShow = Me.RadToolbarAlertList.Items.FindItemByValue("RadToolBarButtonRadComboBoxShow").FindControl("RadComboBoxShow")
        Me._CheckBoxIncludeCompletedAssignments = Me.RadToolbarAlertList.Items.FindItemByValue("RadToolBarButtonCheckBoxIncludeCompletedAssignments").FindControl("CheckBoxIncludeCompletedAssignments")

        If Not Me.IsPostBack And Not Me.IsCallback Then

            MiscFN.RadComboBoxSetIndex(Me._RadComboBoxGroupBy, "17", False)
            Me.RadToolbarAlertList.FindItemByValue("Bookmark").Visible = Me.EnableBookmarks

        Else

            Select Case Me.EventTarget

                Case "RebindGrid"

                    Me.RadGridAlertList.Rebind()

            End Select

        End If

    End Sub

#End Region

#Region " Controls "

    Public Sub ChkIncludeCompletedAssignments_CheckedChanged(sender As Object, e As EventArgs)

        Me.RadGridAlertList.Rebind()

    End Sub
    Public Sub RadComboBoxShow_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Me.RadGridAlertList.Rebind()

    End Sub
    Public Sub RadComboBoxGroupBy_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs)

        Me.RadGridAlertList.Rebind()

    End Sub

    Private Sub RadGridAlertList_DetailTableDataBind(sender As Object, e As Telerik.Web.UI.GridDetailTableDataBindEventArgs) Handles RadGridAlertList.DetailTableDataBind

        If Not e.DetailTableView.ParentItem Is Nothing Then

            Dim ParentGridDataItem As GridDataItem = CType(e.DetailTableView.ParentItem, GridDataItem)

            If Not ParentGridDataItem Is Nothing Then

                Dim AlertID As Integer = ParentGridDataItem.GetDataKeyValue("AlertID")

                Using DbContext = New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                    Dim Employees As Generic.List(Of AdvantageFramework.Security.Database.Views.Employee) = Nothing
                    Using SecurityDbContext = New AdvantageFramework.Security.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

                        Employees = AdvantageFramework.Security.Database.Procedures.EmployeeView.Load(SecurityDbContext).Include("Users").ToList()

                    End Using

                    Select Case e.DetailTableView.Name
                        Case "Attachments"

                            Dim Attachments As Generic.List(Of AdvantageFramework.Database.Views.AlertAttachmentView) = Nothing
                            Attachments = AdvantageFramework.Database.Procedures.AlertAttachmentView.LoadByAlertID(DbContext, AlertID).ToList()

                            If Not Attachments Is Nothing Then e.DetailTableView.DataSource = Attachments

                        Case "Comments"

                            Dim Comments As Generic.List(Of AdvantageFramework.Database.Entities.AlertComment) = Nothing
                            Dim SimpleComments As New Generic.List(Of SimpleComment)

                            Comments = AdvantageFramework.Database.Procedures.AlertComment.LoadByAlertID(DbContext, AlertID).ToList()


                            For Each Comment In Comments

                                Dim NewSimpleComment As New SimpleComment

                                NewSimpleComment.Comment = Comment.Comment
                                NewSimpleComment.GeneratedDate = Comment.GeneratedDate
                                NewSimpleComment.GeneratedBy = Employees.FirstOrDefault(Function(Entity) Entity.Users.Any(Function(User) User.UserCode = Comment.UserCode) = True).ToString()

                                SimpleComments.Add(NewSimpleComment)

                                NewSimpleComment = Nothing

                            Next

                            If Not SimpleComments Is Nothing Then e.DetailTableView.DataSource = SimpleComments

                        Case "Recipients"

                            Dim Recipients As New Generic.List(Of SimpleRecipient)

                            Dim AlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipient) = Nothing
                            AlertRecipients = AdvantageFramework.Database.Procedures.AlertRecipient.LoadByAlertID(DbContext, AlertID).ToList()

                            If Not AlertRecipients Is Nothing Then

                                For Each ar In AlertRecipients

                                    Dim sr As New SimpleRecipient

                                    sr.EmployeeCode = ar.EmployeeCode
                                    sr.EmployeeName = Employees.FirstOrDefault(Function(Entity) Entity.Code = ar.EmployeeCode).ToString()
                                    If Not ar.IsCurrentNotify Is Nothing Then sr.IsAssignee = ar.IsCurrentNotify
                                    If Not ar.IsCurrentRecipient Is Nothing Then sr.IsActive = Not ar.IsCurrentRecipient
                                    If sr.IsAssignee = True Then sr.EmployeeName = sr.EmployeeName & " (Currently Assigned)"

                                    Recipients.Add(sr)

                                Next

                            End If

                            Dim DismissedAlertRecipients As Generic.List(Of AdvantageFramework.Database.Entities.AlertRecipientDismissed) = Nothing
                            DismissedAlertRecipients = AdvantageFramework.Database.Procedures.AlertRecipientDismissed.LoadByAlertID(DbContext, AlertID).ToList()

                            If Not DismissedAlertRecipients Is Nothing Then

                                For Each ar In DismissedAlertRecipients

                                    Dim sr As New SimpleRecipient

                                    sr.EmployeeCode = ar.EmployeeCode
                                    sr.EmployeeName = Employees.FirstOrDefault(Function(Entity) Entity.Code = ar.EmployeeCode).ToString()
                                    If Not ar.IsCurrentNotify Is Nothing Then sr.IsAssignee = ar.IsCurrentNotify
                                    If Not ar.IsCurrentRecipient Is Nothing Then sr.IsActive = Not ar.IsCurrentRecipient
                                    If sr.IsAssignee = True Then sr.EmployeeName = sr.EmployeeName & " (Currently Assigned)"

                                    Recipients.Add(sr)

                                Next

                            End If

                            If Not Recipients Is Nothing Then

                                Try

                                    Recipients.Sort(Function(p1, p2) p1.EmployeeName.CompareTo(p2.EmployeeName))

                                Catch ex As Exception

                                End Try

                                e.DetailTableView.DataSource = Recipients

                            End If

                    End Select

                End Using

            End If

        End If

    End Sub
    Private Sub RadGridAlertList_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridAlertList.ItemCommand

        Dim CurrentGridDataItem As Telerik.Web.UI.GridDataItem = Nothing

        If e.Item IsNot Nothing AndAlso e.Item.ItemIndex > -1 Then CurrentGridDataItem = RadGridAlertList.Items(e.Item.ItemIndex)

        Select Case e.CommandName

            Case "Download"

                Dim DocumentID As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentID)

        End Select

    End Sub
    Private Sub RadGridAlertList_ItemDataBound(sender As Object, e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridAlertList.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.Header

            Case Telerik.Web.UI.GridItemType.Item, Telerik.Web.UI.GridItemType.AlternatingItem

                Dim CurrentRow As GridDataItem = CType(e.Item, GridDataItem)

                If Not CurrentRow Is Nothing Then

                    Dim AlertID As Integer = CurrentRow.GetDataKeyValue("AlertID")
                    Dim IsAssignment As Boolean = CurrentRow.GetDataKeyValue("IsAssignment")

                    Dim SubjectLinkButton As System.Web.UI.WebControls.LinkButton = CurrentRow.FindControl("LinkButtonSubject")
                    Dim AssignmentLinkButton As System.Web.UI.WebControls.LinkButton = CurrentRow.FindControl("LinkButtonAssignedTo")

                    Try

                        Dim AttachmentCount As Integer = CType(CurrentRow.GetDataKeyValue("AttachmentCount"), Integer)
                        Dim AttachmentCountImage As System.Web.UI.WebControls.Image = CurrentRow.FindControl("ImageAttachmentCount")
                        Dim DivAttachments As HtmlControls.HtmlControl = e.Item.FindControl("DivAttachments")

                        If AttachmentCount > 0 Then

                            If AttachmentCount = 1 Then

                                AttachmentCountImage.ToolTip = "1 attachment"

                            ElseIf AttachmentCount > 1 Then

                                AttachmentCountImage.ToolTip = AttachmentCount.ToString() & " attachments"

                            End If

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivAttachments, "standard-green")

                        Else

                            AdvantageFramework.Web.Presentation.Controls.DivAddCssClass(DivAttachments, "standard-red")

                        End If
                    Catch ex As Exception

                    End Try

                    If Not SubjectLinkButton Is Nothing Then

                        SubjectLinkButton.ToolTip = "View Alert"
                        SubjectLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Desktop_AlertView?SprintID=0&AlertID=" & AlertID.ToString()))

                    End If
                    If IsAssignment AndAlso Not AssignmentLinkButton Is Nothing Then

                        Dim qs As New AdvantageFramework.Web.QueryString()
                        With qs

                            .Page = "Alert_Assignment.aspx"
                            .AlertID = AlertID

                        End With

                        AssignmentLinkButton.ToolTip = "Click to Re-Assign"
                        AssignmentLinkButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))

                    End If

                    Try

                        Dim TableCellFileSize As WebControls.TableCell
                        TableCellFileSize = CurrentRow("GridBoundColumnSize")
                        If Not TableCellFileSize Is Nothing AndAlso IsNumeric(TableCellFileSize.Text) Then

                            Dim FileSize As Integer = CType(TableCellFileSize.Text, Integer)

                            Select Case FileSize
                                Case Is < 1024

                                    TableCellFileSize.Text = FileSize.ToString() & " B"

                                Case Is >= 1024 AndAlso FileSize < 1048576

                                    TableCellFileSize.Text = FormatNumber((FileSize / 1024), 2) & " KB"

                                Case Is >= 1048576

                                    TableCellFileSize.Text = FormatNumber((FileSize / 1048576), 2) & " MB"

                                Case Is >= 1073741824

                                    TableCellFileSize.Text = FormatNumber((FileSize / 1073741824), 2) & " GB"

                            End Select

                        End If

                    Catch ex As Exception

                    End Try

                End If

            Case Telerik.Web.UI.GridItemType.Footer

            Case GridItemType.DetailTemplateItem

        End Select
    End Sub
    Private Sub RadGridAlertList_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridAlertList.NeedDataSource

        Dim ma As New ModuleAlerts(Me._Session.ConnectionString, Me._Session.UserCode, HttpContext.Current.Session("EmpCode"))

        ma.Level = Me._AlertListLevel
        ma.IncludeCompletedAssignments = Me._CheckBoxIncludeCompletedAssignments.Checked
        If Not Me._RadComboBoxShow.SelectedItem Is Nothing Then ma.AlertsToDisplay = Me._RadComboBoxShow.SelectedItem.Value

        ma.JobNumber = Me._JobNumber
        ma.JobComponentNumber = Me._JobComponentNumber
        ma.TaskSequenceNumber = Me._TaskSequenceNumber
        ma.CampaignID = Me._CampaignID
        ma.EstimateNumber = Me._EstimateNumber
        ma.EstimateComponentNumber = Me._EstimateComponentNumber
        ma.EstimateQuoteNumber = Me._EstimateQuoteNumber
        ma.EstimateSelectedQuotes = Me._EstimateSelectedQuotes
        ma.EstimatePrintAll = Me._EstimatePrintAll
        ma.MediaATBRevisionID = Me._MediaATBRevisionID
        ma.MediaATBNumber = Me._MediaATBNumber
        ma.MediaATBRevisionNumber = Me._MediaATBRevisionNumber
        ma.AccountsPayableID = Me._AccountsPayableID
        ma.AccountsPayableSequenceNumber = Me._AccountsPayableSequenceNumber
        ma.PurchaseOrderNumber = Me._PurchaseOrderNumber

        If Not Me._RadComboBoxGroupBy.SelectedItem Is Nothing Then ma.GroupBy = CType(Me._RadComboBoxGroupBy.SelectedItem.Value, Integer)

        ma.Load()

        Dim s As String = "Alert List for "

        If Not Me._RadComboBoxShow.SelectedItem Is Nothing Then s = Me._RadComboBoxShow.SelectedItem.Text & " for "

        Me.PageTitleString = s & ma.Title
        Me.PageTitle = Me.PageTitleString

        If Not ma.Alerts Is Nothing Then Me.RadGridAlertList.DataSource = ma.Alerts

        Me.ApplyGrouping()

    End Sub

    Private Sub RadToolbarAlertList_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarAlertList.ButtonClick

        Select Case e.Item.Value

            Case "NewAlert"

                Dim qs As New AdvantageFramework.Web.QueryString()

                Select Case Me._AlertListLevel

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Estimate, AdvantageFramework.Database.Entities.AlertListLevel.EstimateComponent, AdvantageFramework.Database.Entities.AlertListLevel.EstimateQuote

                        qs.Page = "Estimating_Print.aspx"

                        qs.EstimateNumber = Me._EstimateNumber
                        qs.EstimateComponentNumber = Me._EstimateComponentNumber
                        qs.JobNumber = Me._JobNumber
                        qs.JobComponentNumber = Me._JobComponentNumber

                        qs.Add("from", "Est")
                        qs.Add("sel_quotes", Me._EstimateSelectedQuotes)
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)
                        qs.Add("print_all", Me._EstimatePrintAll.ToString())

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.MediaATB

                        qs.Page = "Media_ATB_Print.aspx"
                        qs.Add("ATBNbr", Me._MediaATBNumber.ToString)
                        qs.Add("RevNbr", Me._MediaATBRevisionNumber.ToString)
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.PurchaseOrder

                        qs.Page = "PurchaseOrder_Print.aspx"
                        qs.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(Me._PurchaseOrderNumber))
                        qs.Add("callingpagemode", "")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Campaign

                        qs.Page = "Campaign_Print.aspx"
                        qs.CampaignIdentifier = Me._CampaignID
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectSchedule

                        qs.Page = "TrafficSchedule_Print.aspx"
                        qs.JobNumber = Me._JobNumber
                        qs.JobComponentNumber = Me._JobComponentNumber
                        qs.Add("sort", "")
                        qs.Add("pm", "0")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectScheduleTask

                        qs.Page = "Alert_New.aspx"
                        qs.Add("assn", "0")
                        qs.Add("pop", "1")
                        qs.Add("f", CType(MiscFN.Source_App.ProjectScheduleTask, Integer).ToString())
                        qs.Add("j", Me._JobNumber)
                        qs.Add("jc", Me._JobComponentNumber)
                        qs.Add("seq", Me._TaskSequenceNumber)
                        qs.Add("fnc", "") '?
                        qs.Add("cli", "")
                        qs.Add("div", "")
                        qs.Add("prd", "")

                        Me.OpenWindow(qs)

                End Select

            Case "NewAssignment"

                Dim qs As New AdvantageFramework.Web.QueryString()

                Select Case Me._AlertListLevel

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Estimate, AdvantageFramework.Database.Entities.AlertListLevel.EstimateComponent, AdvantageFramework.Database.Entities.AlertListLevel.EstimateQuote

                        qs.Page = "Estimating_Print.aspx"

                        qs.EstimateNumber = Me._EstimateNumber
                        qs.EstimateComponentNumber = Me._EstimateComponentNumber
                        qs.JobNumber = Me._JobNumber
                        qs.JobComponentNumber = Me._JobComponentNumber

                        qs.Add("from", "Est")
                        qs.Add("sel_quotes", Me._EstimateSelectedQuotes)
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)
                        qs.Add("print_all", Me._EstimatePrintAll.ToString())

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.MediaATB

                        qs.Page = "Media_ATB_Print.aspx"
                        qs.Add("ATBNbr", Me._MediaATBNumber.ToString)
                        qs.Add("RevNbr", Me._MediaATBRevisionNumber.ToString)
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.PurchaseOrder

                        qs.Page = "PurchaseOrder_Print.aspx"
                        qs.Add("po_number", AdvantageFramework.Security.Encryption.EncryptPO(Me._PurchaseOrderNumber))
                        qs.Add("callingpagemode", "")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAlert)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.Campaign

                        qs.Page = "Campaign_Print.aspx"
                        qs.CampaignIdentifier = Me._CampaignID
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectSchedule

                        qs.Page = "TrafficSchedule_Print.aspx"
                        qs.JobNumber = Me._JobNumber
                        qs.JobComponentNumber = Me._JobComponentNumber
                        qs.Add("sort", "")
                        qs.Add("pm", "0")
                        qs.Add("mode", Webvantage.BasePrintSendPage.PageMode.SendAssignment)

                        Me.OpenPrintSendSilently(qs)

                    Case AdvantageFramework.Database.Entities.AlertListLevel.ProjectScheduleTask

                        qs.Page = "Alert_New.aspx"
                        qs.Add("assn", "1")
                        qs.Add("pop", "1")
                        qs.Add("f", CType(MiscFN.Source_App.ProjectScheduleTask, Integer).ToString())
                        qs.Add("j", Me._JobNumber)
                        qs.Add("jc", Me._JobComponentNumber)
                        qs.Add("seq", Me._TaskSequenceNumber)
                        qs.Add("fnc", "") '?
                        qs.Add("cli", "")
                        qs.Add("div", "")
                        qs.Add("prd", "")

                        Me.OpenWindow(qs)

                End Select

            Case "Bookmark"

                Dim s As String = ""
                Dim b As New AdvantageFramework.Web.Presentation.Bookmarks.Bookmark
                Dim BmMethods As New AdvantageFramework.Web.Presentation.Bookmarks.Methods(Session("ConnString"), Session("UserCode"))
                Dim qs As New AdvantageFramework.Web.QueryString()

                qs = qs.FromCurrent()

                With b

                    .BookmarkType = AdvantageFramework.Web.Presentation.Bookmarks.BookmarkType.Desktop_AlertList
                    .UserCode = Session("UserCode")
                    .Name = Me.PageTitleString
                    .PageURL = "Alert_List.aspx" & qs.ToString()

                End With

                If BmMethods.SaveBookmark(b, s) = False Then

                    Me.ShowMessage(s)

                Else

                    Me.RefreshBookmarksDesktopObject()

                End If

        End Select

    End Sub

#End Region

#Region " Methods "

    Private Sub ApplyGrouping()

        Me.RadGridAlertList.MasterTableView.GroupByExpressions.Clear()

        If Not Me._RadComboBoxGroupBy.SelectedItem Is Nothing Then

            Select Case CType(Me._RadComboBoxGroupBy.SelectedItem.Value, AdvantageFramework.Database.Entities.AlertListGrouping)

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Category

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("Category Category Group By Category")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.State

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("State State Group By State")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.DueDate

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("Due Due Group By Due")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Priority

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("PriorityString Priority Group By PrioritySort")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Client

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("GroupingText Client Group By GroupingText")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Division

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("GroupingText Division Group By GroupingText")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Product

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("GroupingText Product Group By GroupingText")

                Case AdvantageFramework.Database.Entities.AlertListGrouping.Level

                    Me.RadGridAlertList.MasterTableView.GroupByExpressions.Add("GroupingText Level Group By GroupingText")


            End Select

        End If

    End Sub

#End Region

    '' Not needed because it looks like all estimate pages create alerts at one level, "EST"
    'Case AlertListLevel.Estimate

    '    _PageTitleString &= "Estimate " & Me._EstimateNumber.ToString().PadLeft(6, "0") & " " & _
    '        DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(EST_LOG_DESC, '') FROM ESTIMATE_LOG WITH(NOLOCK) WHERE ESTIMATE_NUMBER = {0}", Me._EstimateNumber)).SingleOrDefault().ToString()

    '    Alerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments") _
    '              Where Entity.EstimateNumber = Me._EstimateNumber).ToList()

    'Case AlertListLevel.EstimateQuote

    '    _PageTitleString &= "Estimate Quote " & Me._EstimateNumber.ToString().PadLeft(6, "0") & "/" & Me._EstimateComponentNumber.ToString().PadLeft(2, "0") & "/" & Me._EstimateQuoteNumber.ToString().PadLeft(2, "0") & _
    '        DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(EST_QUOTE_DESC, '') FROM ESTIMATE_QUOTE WITH(NOLOCK) WHERE ESTIMATE_NUMBER = {0} AND EST_COMPONENT_NBR = {1} AND EST_QUOTE_NBR = {2}", Me._EstimateNumber, Me._EstimateComponentNumber, Me._EstimateQuoteNumber)).SingleOrDefault().ToString()

    '    Alerts = (From Entity In AdvantageFramework.Database.Procedures.Alert.Load(DbContext).Include("AlertRecipients").Include("AlertRecipientDismisseds").Include("AlertAttachments") _
    '              Where Entity.EstimateNumber = Me._EstimateNumber _
    '              And Entity.EstimateComponentNumber = Me._EstimateComponentNumber _
    '              And Entity.EstimateQuoteNumber = Me._EstimateQuoteNumber).ToList()

End Class
