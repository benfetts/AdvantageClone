Public Class Alert_Comment_Editor
    Inherits Webvantage.BaseChildPage

    Private CommentId As Integer = 0
    Private _AlertID As Integer = 0
    Private _AlertType As String = "Alert"
    Private _control As String = ""
    Public radwindowname As String = ""

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            Dim qs As New AdvantageFramework.Web.QueryString()
            qs = qs.FromCurrent()

            _AlertID = qs.AlertID
            _control = qs.GetValue("control")

            If qs.GetValue("Type") = "1" Then
                _AlertType = "Assignment"
            End If

            Try
                Me.radwindowname = qs.GetValue("opener")
            Catch ex As Exception
                Me.radwindowname = ""
            End Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        Try

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click

        If Me._AlertID > 0 Then

            Dim StrComment As String = Me.RadEditorComment.Content

            If _AlertType = "Alert" Then

                If StrComment = "" Or StrComment = "<br>" Then

                    Me.ShowMessage("Please enter a comment")
                    Exit Sub

                Else

                    Dim alertComment As New AlertComment(CStr(Session("ConnString")))
                    If StrComment.Trim() <> "" Then

                        If Me.IsClientPortal = True Then

                            alertComment.AddNewComment(Me._AlertID, "", StrComment, Session("UserID"))

                        Else

                            alertComment.AddNewComment(Me._AlertID, Session("UserCode"), StrComment)

                        End If

                    End If

                    Me.RadEditorComment.Content = ""
                    Me.FocusControl(Me.RadEditorComment)

                    Me.CloseThisWindowAndRefreshCaller("Alert_View.aspx")

                End If

            End If

            If _AlertType = "Assignment" Then

                If StrComment <> "" Or StrComment <> "<br>" Then

                    Session("AssignmentHtmlComment") = StrComment

                End If

                'Dim strScript As String = ""
                'strScript &= "CallingWindowContent.document.getElementById('" & _control & "').value = '" & StrComment & "';"

                'Me.ControlsToSet = strScript
                'Me.ControlsToSet &= Me.SetFocusToInput(Me._control)

                'Me.HiddenFieldControlsToSet.Value = Me.ControlsToSet

                ''Page.ClientScript.RegisterStartupScript(Me.GetType(), "ReturnValue", "<script>returnValue();</script>")

                Me.CloseThisWindowAndRefreshCaller("Alert_View.aspx")
                'Me.CallFunctionOnParentPage("Alert_View.aspx", "SetAssignmentComments", True)

            End If

        End If

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        Me.CloseThisWindow()
    End Sub

    Public Function SetFocusToInput(ByVal InputID As String) As String

        If String.IsNullOrWhiteSpace(InputID) = False Then

            Return String.Format("CallingWindowContent.document.getElementById('{0}').focus();", InputID)

        Else

            Return ""

        End If

    End Function
End Class
