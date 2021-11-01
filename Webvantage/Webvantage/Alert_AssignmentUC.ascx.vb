Imports Telerik.Web.UI

Public Class Alert_AssignmentUC
    Inherits Webvantage.BaseChildPageUserControl

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private Property _AlrtNotifyHdrId As Integer
        Get
            Dim i As Integer = 0

            If Not ViewState("_AlrtNotifyHdrId") Is Nothing Then

                If IsNumeric(ViewState("_AlrtNotifyHdrId")) = True Then

                    i = CType(ViewState("_AlrtNotifyHdrId"), Integer)

                End If

            End If

            Return i

        End Get
        Set(value As Integer)

            ViewState("_AlrtNotifyHdrId") = value

        End Set
    End Property
    Private Property _AlertStateId As Integer
        Get
            Dim i As Integer = 0

            If Not ViewState("_AlertStateId") Is Nothing Then

                If IsNumeric(ViewState("_AlertStateId")) = True Then

                    i = CType(ViewState("_AlertStateId"), Integer)

                End If

            End If

            Return i


        End Get
        Set(value As Integer)

            ViewState("_AlertStateId") = value

        End Set
    End Property

#End Region

#Region " Properties "

    Public Property AlertId As Integer
        Get
            Dim i As Integer = 0

            If Not ViewState("AssignmentAlertId") Is Nothing Then

                If IsNumeric(ViewState("AssignmentAlertId")) = True Then

                    i = CType(ViewState("AssignmentAlertId"), Integer)

                End If

            End If

            Return i

        End Get
        Set(value As Integer)

            ViewState("AssignmentAlertId") = value

        End Set
    End Property
    Public Property ErrorMessage As String = ""
    Public ReadOnly Property WorkflowTemplateComboBox() As Telerik.Web.UI.RadComboBox
        Get
            Return Me.RadComboBoxAlertNotifyHdrTemplate
        End Get
    End Property
    Public ReadOnly Property StateTreeView() As Telerik.Web.UI.RadTreeView
        Get
            Return Me.RadTreeViewStates
        End Get
    End Property
    Public ReadOnly Property AssignToComboBox() As Telerik.Web.UI.RadComboBox
        Get
            Return Me.RadComboBoxAssignTo
        End Get
    End Property
    Public Property ShowSaveButton As Boolean = False
    Public Property ShowCommentTextbox As Boolean = False
    Public Property AssignmentIsCompleted As Boolean = False

#End Region

#Region " Page Events "

    Private Sub Page_Init1(sender As Object, e As EventArgs) Handles Me.Init

    End Sub
    Private Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.LoadAlert()

        If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

            Me.BindRadComboBoxAlertNotifyHdrTemplate()

            If Me._AlrtNotifyHdrId > 0 Then
                Try
                    If Me.RadComboBoxAlertNotifyHdrTemplate.Items.FindItemByValue(Me._AlrtNotifyHdrId) Is Nothing Then
                        Dim aa As New cAlerts()
                        Dim dt As New DataTable
                        dt = aa.GetInactiveTemplateInUse(Me._AlrtNotifyHdrId)
                        If Not dt Is Nothing Then
                            If dt.Rows.Count > 0 Then
                                With Me.RadComboBoxAlertNotifyHdrTemplate
                                    .Items.Insert(Me.RadComboBoxAlertNotifyHdrTemplate.Items.Count, New Telerik.Web.UI.RadComboBoxItem(dt.Rows(0)("ALERT_NOTIFY_NAME"), dt.Rows(0)("ALRT_NOTIFY_HDR_ID")))
                                End With
                            End If
                        End If
                    End If
                    MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAlertNotifyHdrTemplate, Me._AlrtNotifyHdrId, False, True)
                Catch ex As Exception
                End Try
            Else
                Me.RadComboBoxAlertNotifyHdrTemplate.SelectedIndex = 0
            End If

            Me.BindRadTreeViewStates()

            If Me._AlertStateId > 0 Then
                Dim n As Telerik.Web.UI.RadTreeNode = Nothing
                n = Me.RadTreeViewStates.FindNodeByValue(Me._AlertStateId)
                If Not n Is Nothing Then
                    n.Selected = True
                End If
            End If

            Me.BindRadComboBoxAssignTo()

        Else

            If Me._AlrtNotifyHdrId = 0 AndAlso IsNumeric(Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue) = True Then
                Me._AlrtNotifyHdrId = CType(Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue, Integer)
            End If
            If Me._AlertStateId = 0 AndAlso IsNumeric(Me.RadTreeViewStates.SelectedNode.Value) = True Then
                Me._AlertStateId = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)
            End If

        End If

        Me.DivSendAssignmentButton.Visible = Me.ShowSaveButton
        Me.DivComment.Visible = Me.ShowCommentTextbox

        Dim alrt As New cAlerts()
        If alrt.AssignmentIsCompleted(Me.AlertId) = True Then

            Me.AssignmentIsCompleted = True

            Me.RadComboBoxAlertNotifyHdrTemplate.Enabled = False
            Me.RadTreeViewStates.Enabled = False
            With Me.RadComboBoxAssignTo
                .Items.Clear()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("COMPLETED", "COMPLETED"))
                .Enabled = False
            End With

            Me.TextBoxComment.Enabled = False
            Me.LabelCompleted.Visible = True
            Me.ButtonSendAssignment.Enabled = False

        Else

            Me.AssignmentIsCompleted = True

            Me.TextBoxComment.Enabled = True
            Me.LabelCompleted.Visible = False
            Me.ButtonSendAssignment.Enabled = True

        End If

    End Sub

#End Region

#Region " Controls Events "

    Private Sub RadComboBoxAssignTo_ItemsRequested(sender As Object, e As Telerik.Web.UI.RadComboBoxItemsRequestedEventArgs) Handles RadComboBoxAssignTo.ItemsRequested

        If Me.RadComboBoxAlertNotifyHdrTemplate.SelectedIndex > -1 AndAlso IsNumeric(Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue) Then

            Me._AlrtNotifyHdrId = CType(Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue, Integer)

        End If
        If Me.RadTreeViewStates.SelectedNode IsNot Nothing AndAlso IsNumeric(Me.RadTreeViewStates.SelectedNode.Value) Then

            Me._AlertStateId = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)

        End If

        Dim a As New cAlerts()
        Dim data As DataTable = a.GetNotificationRecipients(Me._AlertStateId, 0, 0, Me._AlrtNotifyHdrId, e.Text, Me.CheckBoxShowAllAssignmentEmployees.Checked)
        Dim itemOffset As Integer = e.NumberOfItems
        Dim endOffset As Integer = Math.Min(itemOffset + Me.RadComboBoxAssignTo.ItemsPerRequest, data.Rows.Count)
        e.EndOfItems = endOffset = data.Rows.Count

        RadComboBoxAssignTo.Items.Clear()

        For i As Integer = itemOffset To endOffset - 1

            RadComboBoxAssignTo.Items.Add(New RadComboBoxItem(data.Rows(i)("EMP_FML").ToString(),
                                                              data.Rows(i)("EMP_CODE").ToString()))

        Next

        e.Message = AdvantageFramework.Web.Presentation.Controls.RadComboBoxAutoFillGetStatusMessage(endOffset, data.Rows.Count)

    End Sub
    Private Sub RadTreeViewStates_NodeClick(sender As Object, e As Telerik.Web.UI.RadTreeNodeEventArgs) Handles RadTreeViewStates.NodeClick
        If Me.RadComboBoxAlertNotifyHdrTemplate.SelectedIndex > 0 And Me.RadTreeViewStates.SelectedNode.Index > -1 Then
            Dim CurrentEmpCode As String = Me.RadComboBoxAssignTo.SelectedValue

            Dim a As New cAlerts()
            With Me.RadComboBoxAssignTo

                .Items.Clear()
                .Text = ""
                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"
                .DataSource = a.GetNotificationRecipients(Me.RadTreeViewStates.SelectedValue, 0, 0, Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue)
                .DataBind()
                .Enabled = True
                .Focus()

            End With
            Try
                If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                    Dim HasDefaultEmpCode As Boolean = False
                    For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                        If item.Text.Contains("*") = True Then

                            item.Selected = True
                            Me.RadComboBoxAssignTo.Text = item.Text
                            Me.RadComboBoxAssignTo.SelectedValue = item.Value
                            Me.RadComboBoxAssignTo.Items.FindItemByValue(item.Value).Selected = True

                            HasDefaultEmpCode = True
                            Exit For

                        End If

                    Next

                    If HasDefaultEmpCode = False And CurrentEmpCode <> "" Then

                        MiscFN.RadComboBoxSetIndex(Me.RadComboBoxAssignTo, CurrentEmpCode, False)

                    End If

                End If
            Catch ex As Exception

            End Try

            'Try
            '    If Me.RadComboBoxCategory.Items.Count > 0 And Me.RadComboBoxCategory.Enabled = True Then
            '        Me.RadComboBoxCategory.FindItemByValue(a.GetDefaultCategory(Me.RadTreeViewStates.SelectedValue)).Selected = True
            '    End If
            'Catch ex As Exception
            'End Try

            Try
                Dim SelectedState As String = ""
                Dim SelectedTemplate As String = ""
                Try
                    If Me.RadTreeViewStates.Nodes.Count > 0 Then
                        SelectedState = Me.RadTreeViewStates.SelectedNode.Text
                    End If
                Catch ex As Exception
                    SelectedState = ""
                End Try
                Try
                    If SelectedState.LastIndexOf("*") = SelectedState.Length - 1 Then
                        SelectedState = SelectedState.Substring(0, SelectedState.Length - 1)
                    End If
                Catch ex As Exception
                End Try
                Try
                    If Me.RadComboBoxAlertNotifyHdrTemplate.Items.Count > 0 Then
                        SelectedTemplate = Me.RadComboBoxAlertNotifyHdrTemplate.SelectedItem.Text
                    End If
                Catch ex As Exception
                    SelectedTemplate = ""
                End Try

                If SelectedState = "" Or SelectedState = "[Please select]" Then SelectedState = "N/A"
                If SelectedTemplate = "" Or SelectedTemplate = "[Please select]" Then SelectedTemplate = "N/A"

            Catch ex As Exception

            End Try

        Else

            Try

                With Me.RadComboBoxAssignTo

                    If .Items.Count > 0 Then

                        .SelectedIndex = 0

                    End If

                    .Enabled = False

                End With

            Catch ex As Exception

            End Try

        End If

    End Sub

#End Region

#Region " Methods "

    Private Sub BindRadComboBoxAlertNotifyHdrTemplate()
        Try
            Dim a As New cAlerts()
            With Me.RadComboBoxAlertNotifyHdrTemplate
                .DataSource = a.GetAlertNotifyTemplates(False)
                .DataValueField = "ALRT_NOTIFY_HDR_ID"
                .DataTextField = "ALERT_NOTIFY_NAME"
                .DataBind()
                .Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("[Please select]", ""))
            End With
            ' Me.RadComboBoxAssignTo.Enabled = False
        Catch ex As Exception
        End Try
    End Sub
    Private Sub BindRadTreeViewStates()
        Me.RadTreeViewStates.Nodes.Clear()
        If Me._AlrtNotifyHdrId > 0 Then
            'bind treeview
            Dim d As New DataTable
            Dim a As New cAlerts()
            d = a.GetAlertStates("", "", Me._AlrtNotifyHdrId)
            Me.RadTreeViewStates.Nodes.Clear()

            Try
                If d.Rows.Count > 0 Then
                    For i As Integer = 0 To d.Rows.Count - 1
                        Dim nn As New Telerik.Web.UI.RadTreeNode
                        With nn
                            .Text = d.Rows(i)("ALERT_STATE_NAME")
                            .Value = d.Rows(i)("ALERT_STATE_ID")
                        End With
                        Me.RadTreeViewStates.Nodes.Add(nn)
                    Next
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Private Sub BindRadComboBoxAssignTo()

        If Me._AlrtNotifyHdrId > 0 And Me._AlertStateId > 0 Then

            Dim a As New cAlerts()

            With Me.RadComboBoxAssignTo

                .Items.Clear()
                .Text = ""
                .DataTextField = "EMP_FML"
                .DataValueField = "EMP_CODE"
                .DataSource = a.GetNotificationRecipients(Me._AlertStateId, 0, 0, Me._AlrtNotifyHdrId, "", Me.CheckBoxShowAllAssignmentEmployees.Checked)
                .DataBind()

            End With

            If Not Me.Page.IsPostBack And Not Me.Page.IsCallback Then

                a.SetAssignmentComboBox(Me.RadComboBoxAssignTo, Me.AlertId)

            Else

                For Each item As Telerik.Web.UI.RadComboBoxItem In Me.RadComboBoxAssignTo.Items

                    If item.Text.Contains("*") = True Then

                        item.Selected = True
                        Me.RadComboBoxAssignTo.Text = item.Text
                        Me.RadComboBoxAssignTo.SelectedValue = item.Value
                        Me.RadComboBoxAssignTo.Items.FindItemByValue(item.Value).Selected = True
                        Exit For

                    End If

                Next

            End If

            Me.RadComboBoxAssignTo.Focus()

        End If

    End Sub

    Private Sub LoadAlertStates(ByVal JobNumber As String, ByVal JobComponentNbr As String)
        Try
            Dim a As New cAlerts()
            Dim d As New DataTable
            d = a.GetAlertStates(JobNumber, JobComponentNbr)
            Me.RadTreeViewStates.Nodes.Clear()

            For i As Integer = 0 To d.Rows.Count - 1
                Dim nn As New Telerik.Web.UI.RadTreeNode
                With nn
                    .Text = d.Rows(i)("ALERT_STATE_NAME")
                    .Value = d.Rows(i)("ALERT_STATE_ID")
                End With
                Me.RadTreeViewStates.Nodes.Add(nn)
            Next
        Catch ex As Exception
        End Try
    End Sub
    Private Sub LoadAlert()

        Dim a As AdvantageFramework.Database.Entities.Alert = Nothing
        Using DbContext = New AdvantageFramework.Database.DbContext(Session("ConnString"), Session("UserCode"))

            a = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, Me.AlertId)

            Try

                If Not a Is Nothing Then

                    If a.AlertAssignmentTemplateID IsNot Nothing Then Me._AlrtNotifyHdrId = a.AlertAssignmentTemplateID
                    If a.AlertStateID IsNot Nothing Then Me._AlertStateId = a.AlertStateID
                    Me.Assignment.Text = a.Subject

                End If

            Catch ex As Exception
            End Try

        End Using

    End Sub

    Public Function SaveAssignment() As Boolean

        Dim Success As Boolean = True

        Dim ThisNotifyAssign_AlrtNotifyHdrId As Integer = 0
        Dim ThisNotifyAssign_StateId As Integer = 0
        Dim ThisNotifyAssign_Emp As String = "unassigned"

        Try
            If Me.RadComboBoxAlertNotifyHdrTemplate.SelectedIndex > 0 Then
                ThisNotifyAssign_AlrtNotifyHdrId = CType(Me.RadComboBoxAlertNotifyHdrTemplate.SelectedValue, Integer)
            End If
        Catch ex As Exception
            ThisNotifyAssign_AlrtNotifyHdrId = 0
        End Try
        Try
            If Me.RadTreeViewStates.Nodes.Count > 0 Then
                If Me.RadTreeViewStates.SelectedNode.Index > -1 Then
                    ThisNotifyAssign_StateId = CType(Me.RadTreeViewStates.SelectedNode.Value, Integer)
                End If
            End If
        Catch ex As Exception
            ThisNotifyAssign_StateId = 0
        End Try
        Try
            If Me.RadComboBoxAssignTo.Items.Count > 0 Then
                If Me.RadComboBoxAssignTo.SelectedIndex > -1 Then
                    ThisNotifyAssign_Emp = Me.RadComboBoxAssignTo.SelectedValue
                End If
            End If
        Catch ex As Exception
            ThisNotifyAssign_Emp = "unassigned"
        End Try

        If ThisNotifyAssign_AlrtNotifyHdrId > 0 And ThisNotifyAssign_StateId > 0 Then

            Dim a As New cAlerts()

            If a.AlertIsDismissed(Me.AlertId, Session("EmpCode")) = True Then

                a.UnDismissAlert(Me.AlertId, MiscFN.IsClientPortal, Session("UserID"))

            End If

            Dim s As String = ""
            If a.SaveNotifyAssignmentAlertRecipient(Me.AlertId,
                                                    ThisNotifyAssign_Emp,
                                                    0,
                                                    ThisNotifyAssign_StateId,
                                                    ThisNotifyAssign_AlrtNotifyHdrId,
                                                    Me.TextBoxComment.Text.Trim(),
                                                    True,
                                                    False,
                                                    s) = True Then

                s = ""

                'Dim alrt As New Alert(HttpContext.Current.Session("ConnString"))
                'alrt.LoadByPrimaryKey(Me.AlertId)

                'If alrt.SendEmail("[Alert Updated]", "", "", , , , , MiscFN.IsClientPortal, False, s) = True Then

                '    Success = True

                'Else

                '    ErrorMessage = s

                'End If


                Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                                  HttpContext.Current.Session("UserCode"),
                                                  Me._Session,
                                                  HttpContext.Current.Session("WebvantageURL"),
                                                  HttpContext.Current.Session("ClientPortalURL"))

                With eso

                    .AlertId = AlertId
                    .Subject = "[Alert Updated]"
                    .IsClientPortal = MiscFN.IsClientPortal
                    .IncludeOriginator = True

                End With

                Me.SendEmail(eso.ToSession())

            Else

                Success = False
                ErrorMessage = s

            End If

            Return Success

        End If

    End Function

#End Region

    Private Sub CheckBoxShowAllAssignmentEmployees_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowAllAssignmentEmployees.CheckedChanged

        Me.BindRadComboBoxAssignTo()

    End Sub

End Class
