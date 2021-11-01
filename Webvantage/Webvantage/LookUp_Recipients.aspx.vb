Imports Telerik.Web.UI

Public Class LookUp_Recipients
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AutoGroup As Boolean = False

    Private _JobNumber As Integer = 0
    Private _JobComponentNbr As Integer = 0

    Private _ClientCode As String = ""
    Private _DivisionCode As String = ""
    Private _ProductCode As String = ""

    Private _AlertId As Integer = 0
    Private _AlertGroup As String = ""

    Private _SelectedGroups As String = ""
    Private _SelectedGroupMembers As String = ""

    Private _NewAlertLevel As String = ""
    Private _UseAutoComplete As Boolean = False

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

#Region " Page "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        Me._JobNumber = qs.JobNumber
        Me._JobComponentNbr = qs.JobComponentNumber
        Me._AlertGroup = qs.EmailGroup
        Me._ClientCode = qs.ClientCode
        Me._DivisionCode = qs.DivisionCode
        Me._ProductCode = qs.ProductCode
        Me._NewAlertLevel = qs.GetValue("NewAlertLevel")
        Me.CallingControlName = qs.GetValue("textbox")
        Me.OpenerRadWindowName = qs.GetValue("opener")

        Me._AlertId = qs.AlertID

        Me._UseAutoComplete = qs.GetValue("uac") = "1"

        If Me._AlertGroup = "No Default Selected" Then

            Me._AlertGroup = ""

        Else

            If Me._AlertGroup.LastIndexOf(",") = Me._AlertGroup.Length - 1 Then

                Me._AlertGroup = Me._AlertGroup.Replace(",", ",chk_")
                Me._AlertGroup = Me._AlertGroup.Insert(0, "chk_")

            End If

            Me._AlertGroup = Me._AlertGroup.Replace("-", "/").Replace("and", "&").Replace(",", "_").Replace("__", "'")

        End If

        Try

            If IsNumeric(qs.GetValue("ag")) = True Then

                Me._AutoGroup = CType(qs.GetValue("ag"), Integer) = 1

            End If

        Catch ex As Exception

            Me._AutoGroup = False

        End Try

    End Sub
    Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try

            Dim oAlerts As cAlerts = New cAlerts(Session("ConnString"))

            Try
                If Page.IsPostBack = False And Page.IsCallback = False Then

                    oAlerts.LoadEmailGroupsWebUI(Me._AlertGroup, Me.RadTreeViewRecipients, _
                                                 Me._ClientCode, _
                                                 Me._DivisionCode, _
                                                 Me._ProductCode, _
                                                 Me._NewAlertLevel, _
                                                 Me._JobNumber, Me._JobComponentNbr, Me._AutoGroup, 0, Me.IsClientPortal)

                    Me.RadTreeViewRecipients.Width = New Unit(350, UnitType.Pixel)
                    Me.RadTreeViewRecipients.Height = New Unit(320, UnitType.Pixel)

                End If

            Catch

                Err.Raise(9999, "Error: Loading Groups", Err.Description)

            End Try

            Try

                If Request.QueryString("seldrcpt") IsNot Nothing Then

                    Dim ar() As String
                    ar = Request.QueryString("seldrcpt").ToString().Split(",")

                    For Each item As Telerik.Web.UI.RadTreeNode In Me.RadTreeViewRecipients.GetAllNodes()

                        If Array.IndexOf(ar, item.Value) > -1 Then

                            item.Checked = True
                            item.ExpandParentNodes()
                            If Me._AlertId > 0 Then

                                item.Enabled = False

                            End If

                        End If

                    Next

                    Request.QueryString("seldrcpt") = Nothing

                End If

            Catch ex As Exception

            End Try

        Catch ex As Exception

            Throw (ex)

        End Try

    End Sub

#End Region

#Region " Controls "

    Private Sub butAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles butAdd.Click

        Me.SetSelected()

        ''If Me._AlertId = 0 Then

        If Me._UseAutoComplete = False Then

            Me.ControlsToSet = "CallingWindowContent.document.getElementById('" & Me.CallingControlName & "').value = '" & Me._SelectedGroupMembers & "';"
            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

        Else

            Dim ce As New cEmployee(HttpContext.Current.Session("ConnString"))
            Dim ar() As String
            Dim sb As New System.Text.StringBuilder

            ar = Me._SelectedGroupMembers.Split(",")

            For i As Integer = 0 To ar.Length - 1

                If ar(i).Contains("(CC)") Then

                    Dim CCID As Integer = 0
                    Dim CCFN As String = ""

                    Me.GetClientContactIdAndFullNameFromCode(ar(i).ToString().Replace("(CC)", ""), CCID, CCFN)

                    sb.Append(CCID)
                    sb.Append(",")
                    sb.Append(CCFN)
                    sb.Append("|")


                Else

                    sb.Append(ar(i))
                    sb.Append(",")
                    sb.Append(ce.GetName(ar(i)))
                    sb.Append("|")

                End If

            Next

            Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnAutoCompleteValue('" & _
                                                    AdvantageFramework.StringUtilities.JavascriptSafe(sb.ToString()) & _
                                                    "');</script>")

        End If

        ''Else

        ''    'add recipients 
        ''    Dim RecipientArray() As String
        ''    RecipientArray = Me._SelectedGroupMembers.Split(",")
        ''    Dim CurrentAlert = New Alert(Session("ConnString"))
        ''    CurrentAlert.LoadByPrimaryKey(Me._AlertId)

        ''    If Not RecipientArray Is Nothing Then
        ''        For i = 0 To RecipientArray.Length - 1
        ''            If RecipientArray(i) <> "" Then
        ''                If CurrentAlert.AlertCheckForDuplicates(Me._AlertId, RecipientArray(i)) = False Then

        ''                    CurrentAlert.AddAlertRecipient(RecipientArray(i))

        ''                End If
        ''            End If
        ''        Next
        ''    End If

        ''    '
        ''    Me.RefreshAlertRecipients()


        ''End If

    End Sub
    'Private Sub RadTreeViewRecipients_NodeClick(sender As Object, e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeViewRecipients.NodeClick

    '    If Me._AlertId > 0 And e.Node.Checked = True Then

    '        Dim cEmp As New Webvantage.cEmployee(HttpContext.Current.Session("ConnString"))
    '        Using DbContext As New AdvantageFramework.Database.DbContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

    '            Dim Recipient As New AdvantageFramework.Database.Entities.AlertRecipient
    '            With Recipient

    '                .AlertID = Me._AlertId
    '                .EmployeeCode = e.Node.Value
    '                .EmployeeEmail = cEmp.GetEmail(e.Node.Value)
    '                .ID = 0

    '            End With

    '            AdvantageFramework.Database.Procedures.AlertRecipient.Insert(DbContext, Recipient)

    '        End Using

    '    End If

    '    For Each node As RadTreeNode In RadTreeViewRecipients.Nodes

    '        If node.Value = e.Node.Value Then

    '            node.Checked = e.Node.Checked

    '        End If

    '    Next

    'End Sub

#End Region

#Region " Methods "

    Private Sub SetSelected()
        For Each node As Telerik.Web.UI.RadTreeNode In Me.RadTreeViewRecipients.Nodes
            For Each AlertGroup As Telerik.Web.UI.RadTreeNode In node.Nodes
                If AlertGroup.Checked = True Then
                    If AlertGroup.Value.Contains("(CC)") Or AlertGroup.Nodes.Count = 0 Then
                        _SelectedGroupMembers &= AlertGroup.Value & ","
                    Else
                        _SelectedGroups &= AlertGroup.Value & ","
                    End If
                End If
                For Each GroupEmp As Telerik.Web.UI.RadTreeNode In AlertGroup.Nodes
                    If GroupEmp.Checked = True Then
                        _SelectedGroupMembers &= GroupEmp.Value & ","
                    End If
                Next
            Next
        Next

        _SelectedGroups = MiscFN.CleanStringForSplit(_SelectedGroups, ",")
        _SelectedGroupMembers = MiscFN.CleanStringForSplit(_SelectedGroupMembers, ",")

    End Sub
    Sub RetrieveVendorContactEmailList(ByVal RefId As Integer, ByVal RadTreeViewRecipient As Telerik.Web.UI.RadTreeView)
        Dim ds As DataSet
        Dim POHeader As New wPurchaseOrder.cPurchaseOrder(Session("ConnString"))

        ds = POHeader.Get_PO_Vendor_EmailDS(1, RefId, "")

        Dim main_node As Telerik.Web.UI.RadTreeNode = Me.CreateNode("Contacts", True, "")
        main_node.Value = "node1"
        RadTreeViewRecipient.Nodes.Add(main_node)
        main_node.Expanded = True
        main_node.Checkable = False

        Dim gRow As DataRow
        For Each gRow In ds.Tables(0).Rows
            Dim node As Telerik.Web.UI.RadTreeNode = Me.CreateNode(gRow(5).ToString(), True, "")
            node.Value = gRow(6).ToString
            If node.Value.Trim = "" Then
                node.Enabled = False
            Else
                If gRow(7).ToString.Trim = "1" Then 'automatically select default contract from po header...
                    node.Checked = True
                    'Me.txtTo.Text = node.Value
                End If
            End If
            main_node.Nodes.Add(node)
        Next

    End Sub
    Private Function CreateNode(ByVal NodeText As String, ByVal expanded As Boolean, ByVal id As String) As Telerik.Web.UI.RadTreeNode
        Dim node As New Telerik.Web.UI.RadTreeNode(NodeText.Trim)
        node.Expanded = expanded
        Return node
    End Function
    Private Sub GetClientContactIdAndFullNameFromCode(ByVal ContactCode As String, ByRef ClientContactId As Integer, ByRef ClientContactFullName As String)

        Using DbContext As New AdvantageFramework.Database.DbContext(Me._Session.ConnectionString, Me._Session.UserCode)

            If String.IsNullOrWhiteSpace(Me._ClientCode) = True AndAlso Me._JobNumber > 0 Then

                Me._ClientCode = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT CL_CODE FROM JOB_LOG WITH(NOLOCK) WHERE JOB_NUMBER = {0};", Me._JobNumber)).SingleOrDefault

            End If

            Dim SessionKey As String = String.Format("GetClientContactIdAndFullNameFromCode_{0}_{1}", Me._ClientCode, ContactCode)
            Dim ReturnString As String = ""
            Dim a As New cAlerts()
            Dim CurrentContactId As Integer = 0
            Dim FullName As String = ""

            If HttpContext.Current.Session(SessionKey) Is Nothing Then

                Try

                    CurrentContactId = a.CPGetContactCodeID(ContactCode, Me._ClientCode)

                Catch ex As Exception

                    CurrentContactId = 0

                End Try

                If CurrentContactId > 0 Then

                    Dim cc As AdvantageFramework.Database.Entities.ClientContact = Nothing
                    cc = AdvantageFramework.Database.Procedures.ClientContact.LoadByContactID(DbContext, CurrentContactId)

                    If Not cc Is Nothing Then

                        If Not cc.MiddleInitial Is Nothing AndAlso cc.MiddleInitial <> "" Then

                            FullName = cc.FirstName & " " & cc.MiddleInitial & ". " & cc.LastName

                        Else

                            FullName = cc.FirstName & " " & cc.LastName

                        End If

                        FullName &= " (CC)"

                    End If

                End If

                ClientContactId = CurrentContactId
                ClientContactFullName = FullName

                HttpContext.Current.Session(SessionKey) = ClientContactId.ToString() & "|" & FullName

            Else

                Dim ar() As String
                ar = HttpContext.Current.Session(SessionKey).ToString().Split("|")

                ClientContactId = ar(0)
                ClientContactFullName = ar(1)

            End If

        End Using

    End Sub

#End Region


End Class