Public Class Alert_Comment
    Inherits Webvantage.BaseChildPage

    Private CommentId As Integer = 0

    Private Sub Page_Init1(sender As Object, e As System.EventArgs) Handles Me.Init
        Try
            If Not Request.QueryString("cid") Is Nothing Then
                If IsNumeric(Request.QueryString("cid")) = True Then
                    Me.CommentId = CType(Request.QueryString("cid"), Integer)
                End If
            End If
        Catch ex As Exception
            Me.LabelComment.Text = ex.Message.ToString()
        End Try
    End Sub

    Private Sub Page_Load1(sender As Object, e As System.EventArgs) Handles Me.Load
        Try
            If IsNumeric(Me.CommentId) = True Then
                Dim SQL As New System.Text.StringBuilder
                With SQL
                    .Append("SELECT ALERT_COMMENT.COMMENT,")
                    .Append("  SEC_USER.USER_NAME, SEC_USER.EMP_CODE, ALERT_COMMENT.GENERATED_DATE, ")
                    .Append(" 		ISNULL(EMPLOYEE.EMP_FNAME+' ','') + ISNULL(EMPLOYEE.EMP_MI +'. ','') +  ISNULL(EMPLOYEE.EMP_LNAME,'') AS EMP_FML, ALERT_COMMENT.USER_CODE")
                    .Append("		FROM         EMPLOYEE WITH (NOLOCK) INNER JOIN ")
                    .Append("							  SEC_USER WITH (NOLOCK) ON EMPLOYEE.EMP_CODE = SEC_USER.EMP_CODE RIGHT OUTER JOIN ")
                    .Append("							  ALERT_COMMENT WITH (NOLOCK) ON UPPER(SEC_USER.USER_CODE) = UPPER(ALERT_COMMENT.USER_CODE) ")
                    .Append("		WHERE  (ALERT_COMMENT.COMMENT_ID = ")
                    .Append(Me.CommentId)
                    .Append(") AND (USER_CODE_CP IS NULL OR USER_CODE_CP = 0);")
                    .Append("SELECT ALERT_COMMENT.COMMENT,")
                    .Append("  CP_USER.USER_NAME, CDP_CONTACT_HDR.CDP_CONTACT_ID, ALERT_COMMENT.GENERATED_DATE, ")
                    .Append(" 		CDP_CONTACT_HDR.CONT_FML AS EMP_FML")
                    .Append("		FROM         ALERT_COMMENT WITH (NOLOCK) INNER JOIN")
                    .Append("							  CDP_CONTACT_HDR WITH (NOLOCK) ON ALERT_COMMENT.USER_CODE_CP = CDP_CONTACT_HDR.CDP_CONTACT_ID LEFT OUTER JOIN")
                    .Append("							  CP_USER WITH (NOLOCK) ON CP_USER.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID")
                    .Append("		WHERE  (ALERT_COMMENT.COMMENT_ID = ")
                    .Append(Me.CommentId)
                    .Append(") AND (USER_CODE_CP IS NOT NULL);")
                End With
                Dim DtData As New DataSet
                DtData = SqlHelper.ExecuteDataset(Session("ConnString"), CommandType.Text, SQL.ToString())
                If Not DtData Is Nothing Then
                    If DtData.Tables(0).Rows.Count > 0 Then
                        If DtData.Tables(0).Rows.Count > 0 Then
                            Me.LabelComment.Text = DtData.Tables(0).Rows(0)("COMMENT").ToString().Replace(Environment.NewLine, "<br />")
                            If DtData.Tables(0).Rows(0)("EMP_FML").ToString().Trim() = "" Then
                                Me.LabelEmployeeName.Text = DtData.Tables(0).Rows(0)("USER_CODE") & "* (Deleted user)"
                            Else
                                Me.LabelEmployeeName.Text = DtData.Tables(0).Rows(0)("EMP_FML")
                            End If
                            Dim CommentDate As DateTime = CType(DtData.Tables(0).Rows(0)("GENERATED_DATE"), DateTime)
                            Me.LabelGeneratedDate.Text = CommentDate.ToLongDateString() & ", " & CommentDate.ToShortTimeString()
                        End If
                    Else
                        If DtData.Tables(1).Rows.Count > 0 Then
                            Me.LabelComment.Text = DtData.Tables(1).Rows(0)("COMMENT").ToString().Replace(Environment.NewLine, "<br />")
                            Me.LabelEmployeeName.Text = DtData.Tables(1).Rows(0)("EMP_FML")
                            Dim CommentDate As DateTime = CType(DtData.Tables(1).Rows(0)("GENERATED_DATE"), DateTime)
                            Me.LabelGeneratedDate.Text = CommentDate.ToLongDateString() & ", " & CommentDate.ToShortTimeString()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Me.LabelComment.Text = ex.Message.ToString()
        End Try
    End Sub

    Private Sub ButtonClose_Click(sender As Object, e As System.EventArgs) Handles ButtonClose.Click
        Me.CloseThisWindow()
    End Sub

End Class