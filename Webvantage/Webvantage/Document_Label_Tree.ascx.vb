Imports Telerik.Web.UI

Public Class Document_Label_Tree_UC
    Inherits Webvantage.BaseUserControl

#Region " Constants "

    Public Event NodeClick(sender As Object, e As RadTreeNodeEventArgs)

#End Region

#Region " Enum "


#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property Tree As RadTreeView
        Get
            Return Me.RadTreeViewLabels
        End Get
        Set(value As RadTreeView)
            Me.RadTreeViewLabels = value
        End Set
    End Property
    Public Property DocumentID As Integer
        Get
            If ViewState("DocumentID") Is Nothing Then
                ViewState("DocumentID") = 0
            End If
            Return CType(ViewState("DocumentID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("DocumentID") = value
        End Set
    End Property
    Public Property LabelID As Integer
        Get
            If ViewState("LabelID") Is Nothing Then
                ViewState("LabelID") = 0
            End If
            Return CType(ViewState("LabelID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("LabelID") = value
        End Set
    End Property
    Public Property ShowAllNode As Boolean
        Get
            If ViewState("ShowAllNode") Is Nothing Then
                ViewState("ShowAllNode") = False
            End If
            Return CType(ViewState("ShowAllNode"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("ShowAllNode") = value
        End Set
    End Property
    Public Property SelectAllNode As Boolean
        Get
            If ViewState("SelectAllNode") Is Nothing Then
                ViewState("SelectAllNode") = False
            End If
            Return CType(ViewState("SelectAllNode"), Boolean)
        End Get
        Set(value As Boolean)
            ViewState("SelectAllNode") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadTreeViewLabels_NodeCheck(sender As Object, e As RadTreeNodeEventArgs) Handles RadTreeViewLabels.NodeCheck

        If Me.DocumentID > 0 Then

            Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

                If e.Node.Checked = True Then

                    Dim ld As AdvantageFramework.Database.Entities.LabelDocument

                    ld = AdvantageFramework.Database.Procedures.LabelDocument.LoadByLabelIDAndDocumentID(dc, e.Node.Value, Me.DocumentID)

                    If ld Is Nothing Then

                        ld = New AdvantageFramework.Database.Entities.LabelDocument

                        ld.DocumentID = Me.DocumentID
                        ld.LabelID = e.Node.Value

                        AdvantageFramework.Database.Procedures.LabelDocument.Insert(dc, ld)

                    End If

                ElseIf e.Node.Checked = False Then

                    AdvantageFramework.Database.Procedures.LabelDocument.DeleteByLabelIDAndDocumentID(dc, e.Node.Value, Me.DocumentID)

                End If

            End Using

            Me.LoadLabels()
            Me.LoadExistingLabelsForDocument()

        End If

    End Sub
    Private Sub RadTreeViewLabels_NodeClick(sender As Object, e As RadTreeNodeEventArgs) Handles RadTreeViewLabels.NodeClick

        Me.LabelID = Me.RadTreeViewLabels.SelectedNode.Value
        RaiseEvent NodeClick(sender, e)

    End Sub
    Private Sub RadTreeViewLabels_NodeDataBound(sender As Object, e As RadTreeNodeEventArgs) Handles RadTreeViewLabels.NodeDataBound

        Dim Label As AdvantageFramework.Database.Entities.Label = e.Node.DataItem

        If Label IsNot Nothing Then

            e.Node.ToolTip = Label.Description

        End If

    End Sub

#End Region
#Region " Page "

    Private Sub Document_Label_Tree_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack And Not Me.Page.IsCallback Then

            'Me.LoadLabels()

            If Me.DocumentID > 0 Then

                Me.LoadExistingLabelsForDocument()

            End If

        End If

    End Sub

#End Region

    Public Sub LoadExistingLabelsForDocument()

        Me.RadTreeViewLabels.CheckBoxes = Me.DocumentID > 0

        If Me.DocumentID > 0 Then

            Using dc = New AdvantageFramework.Database.DataContext(HttpContext.Current.Session("ConnString"), HttpContext.Current.Session("UserCode"))

                Dim DocumentLabelIDs As New Generic.List(Of Long)

                DocumentLabelIDs = (From Labels In dc.LabelDocuments
                                    Join Entity In dc.Labels On Labels.LabelID Equals Entity.ID
                                    Where Labels.DocumentID = Me.DocumentID AndAlso
                                    (Entity.IsInactive Is Nothing OrElse Entity.IsInactive = 0)
                                    Select Labels.LabelID).ToList()

                If (DocumentLabelIDs IsNot Nothing) AndAlso (Me.RadTreeViewLabels.Nodes IsNot Nothing AndAlso Me.RadTreeViewLabels.Nodes.Count > 0) Then

                    Dim n As RadTreeNode

                    For Each Node As RadTreeNode In Me.RadTreeViewLabels.GetAllNodes()

                        Node.Checked = DocumentLabelIDs.Contains(CType(Node.Value, Long)) = True

                    Next

                End If

            End Using

        End If

    End Sub
    Public Sub LoadLabels(Optional LoadAllLabels As Boolean = False, Optional ByVal LabelID As Integer = 0)

        Me.RadTreeViewLabels.Nodes.Clear()

        Using dc = New AdvantageFramework.Database.DataContext(_Session.ConnectionString, _Session.UserCode)

            Dim HasAllNode As Boolean = False
            Dim node As RadTreeNode
            Dim LabelsList As Generic.List(Of AdvantageFramework.Database.Entities.Label)

            If LoadAllLabels = True Then

                LabelsList = AdvantageFramework.Database.Procedures.Label.Load(dc).ToList()

            Else

                LabelsList = AdvantageFramework.Database.Procedures.Label.LoadActive(dc).ToList()

            End If

            If LabelsList Is Nothing Then LabelsList = New Generic.List(Of AdvantageFramework.Database.Entities.Label)

            Me.RadTreeViewLabels.DataTextField = "Name"
            Me.RadTreeViewLabels.DataValueField = "ID"
            Me.RadTreeViewLabels.DataFieldID = "ID"
            Me.RadTreeViewLabels.DataFieldParentID = "ParentID"

            Me.RadTreeViewLabels.DataSource = LabelsList
            Me.RadTreeViewLabels.DataBind()

            Me.RadTreeViewLabels.ExpandAllNodes()

            If ShowAllNode = True Then

                Me.RadTreeViewLabels.Nodes.Insert(0, New RadTreeNode("[All]", "0"))
                HasAllNode = True

            End If

        End Using

        If LabelID > 0 Then

            Me.LabelID = LabelID
            Me.SelectLabel()
        Else

            If ShowAllNode = True AndAlso SelectAllNode = True Then

                Me.LabelID = 0
                Me.SelectLabel()

            End If

        End If

    End Sub
    Public Sub SelectLabel()

        If Me.RadTreeViewLabels.Nodes IsNot Nothing AndAlso Me.RadTreeViewLabels.Nodes.Count > 0 Then

            Dim n As RadTreeNode
            n = Me.RadTreeViewLabels.Nodes.FindNodeByValue(Me.LabelID)

            If n IsNot Nothing Then

                n.Selected = True

            End If

        End If

    End Sub

#End Region

End Class