Partial Public Class ResourcesPage
    Inherits Webvantage.BaseChildPage

    Private EventId As Integer = -1
    Private ResourceCode As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Me.AllowFloat = True
    End Sub
    'Private JobNumber As Integer = 0
    'Private JobComponentNbr As Integer = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.SetQSVars()

        If Not Me.IsPostBack And Not Me.IsCallback Then
            With Me.UcResources
                .ResourceCode = Me.ResourceCode
                .EventId = Me.EventId
            End With
        End If
    End Sub

    Private Sub SetQSVars()
        Try
            EventId = CType(Request.QueryString("evt"), Integer)
        Catch ex As Exception
            EventId = 0
        End Try
        Try
            ResourceCode = Request.QueryString("resc")
        Catch ex As Exception
            ResourceCode = ""
        End Try

    End Sub

    Private Sub BtnSelect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnSelect.Click
        Try
            If EventId > 0 Then
                Dim rsc As New cResources()
                If rsc.ResourceIsBooked(Me.UcResources.ResourceCode, Me.EventId) = True Then
                    Me.LblMSG.Text = "This resource is booked on another event"
                    Exit Sub
                End If
                Dim evt As New cEvents
                evt.EventUpdateResource(EventId, Me.UcResources.ResourceCode, True, False, Me.UcResources.DeleteAutoTasks)
                Me.CloseAndRefresh()
            End If
        Catch ex As Exception
            Me.LblMSG.Text = ex.Message.ToString()
        End Try
    End Sub

    Private Sub CloseAndRefresh()
        'window.opener.location.href = window.opener.location.href;
        'refreshParent
        Me.LitScript.Text = "<script>refreshParent();</" + "script>"
    End Sub

End Class