Public Partial Class TrafficSchedule_CommentLog2
    Inherits System.Web.UI.UserControl

    Private _RowCount As Integer = 0
    Public JobNumber As Integer = 0
    Public JobCompNumber As Integer = 0
    Public SeqNum As Integer = 0
    Public isCP As Boolean
  

    Public ReadOnly Property CommentsGrid() As Telerik.Web.UI.RadGrid
        Get
            Return Me.RadGridComments2
        End Get
    End Property


    Public ReadOnly Property RowCount() As Integer
        Get
            Return _RowCount
        End Get
    End Property


    Public ReadOnly Property DataSource() As DataTable
        Get
            Try
                Dim res As Object = Me.Session("_dsComments")
                If res Is Nothing Then
                    Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
                    Session("_dsComments") = s.GetTrafficDetComments(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"))
                End If

                Dim dt As DataTable = DirectCast(Me.Session("_dsComments"), DataTable)
                _RowCount = dt.Rows.Count
                Return dt
            Catch ex As Exception
                BlankDT()
            End Try
        End Get
    End Property

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            Me.JobNumber = Request.QueryString("JobNum")
            Me.JobCompNumber = Request.QueryString("JobComp")
            Me.SeqNum = Request.QueryString("SeqNum")
            Session("JobNumber") = JobNumber
            Session("JobCompNumber") = JobCompNumber
            Session("SeqNum") = SeqNum


        Else

        End If
        If Me.isCP = True Then
            Me.btnSave.Visible = False
            Me.TxtAddComment.Enabled = False
        End If
    End Sub
   
    Public Sub RadGridComments2_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridComments2.ItemCommand

        If e.Item Is Nothing Then Exit Sub


    End Sub

    Public Sub RadGridComments2_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridComments2.ItemDataBound

    End Sub

    Public Sub RadGridComments2_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridComments2.NeedDataSource
        Try
            Me.Session("_dsComments") = Nothing
            Me.RadGridComments2.DataSource = Me.DataSource 'DataTable
        Catch ex As Exception

        End Try
    End Sub
    Private Function BlankDT() As DataTable
        Dim dt As New DataTable
        Return dt
    End Function
    Public Sub RefreshCommentsGrid()
        Me.Session("_dsComments") = Nothing
        Me.RadGridComments2.DataSource = Me.DataSource
        Me.RadGridComments2.DataBind()
    End Sub

    Protected Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
        If Not Me.TxtAddComment.Text.Trim = "" Then
            SaveComment(TxtAddComment.Text.Trim)
        End If
    End Sub
    Public Sub SaveComment(ByVal sComment)
        Dim s As New cSchedule(Session("ConnString"), Session("UserCode"))
        s.SaveTrafficDetComment(Session("JobNumber"), Session("JobCompNumber"), Session("SeqNum"), Session("EmpCode"), Session("EmployeeName"), sComment)
        RefreshCommentsGrid()
        Me.TxtAddComment.Text = ""
    End Sub
End Class