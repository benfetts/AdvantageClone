Imports DevExpress.Web

Public Class Alert_Comments
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _AlertID As Integer = 0
    Private _DeepLink As AdvantageFramework.Web.DeepLink = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "

    Private Sub Alert_Comments_Init(sender As Object, e As EventArgs) Handles Me.Init

        Dim qs As New AdvantageFramework.Web.QueryString()
        qs = qs.FromCurrent()

        _AlertID = qs.AlertID

        If _AlertID = 0 Then
            _AlertID = Request.QueryString("AlertId")
        End If

        If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

            If _AlertID > 0 Then

                Me.DataListComments_Load()

            End If

        End If

        Me.FocusControl(Me.RadEditorComment)

    End Sub

#End Region

    Private Sub DataListComments_Load()

        Dim Comments As Generic.List(Of SimpleCommentDisplay)

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim sb As New System.Text.StringBuilder

            sb.Append("SELECT 	")
            sb.Append("A.AlertID, 	")
            sb.Append("A.Comment, 	")
            sb.Append("A.[Date], 	")
            sb.Append("A.EmployeeCode, 	")
            sb.Append("A.EmployeeFullName,	")
            'sb.Append("A.NickName, 	")
            sb.Append("A.CommentID, ")
            sb.Append("EP.EMP_IMAGE AS EmployeePicture, EP.EMP_NICKNAME AS NickName FROM ( 	")

            sb.Append("SELECT 	")
            sb.Append("	ALERT_COMMENT.ALERT_ID AS AlertID, 	")
            sb.Append("	CAST(ALERT_COMMENT.COMMENT AS VARCHAR(MAX)) AS Comment, 	")
            sb.Append("	ALERT_COMMENT.GENERATED_DATE AS [Date], 	")
            sb.Append("	EMPLOYEE.EMP_CODE AS EmployeeCode, 	")
            sb.Append("	EMPLOYEE.EMP_FNAME + ISNULL(' ' + EMPLOYEE.EMP_MI + '. ',' ') + EMPLOYEE.EMP_LNAME AS EmployeeFullName, 	")
            'sb.Append("	EMPLOYEE_PICTURE.EMP_NICKNAME AS NickName, 	")
            sb.Append("	ALERT_COMMENT.COMMENT_ID AS CommentID 	")
            'sb.Append("	EMPLOYEE_PICTURE.EMP_IMAGE AS EmployeePicture ")
            sb.Append("FROM 	")
            sb.Append("	ALERT_COMMENT WITH(NOLOCK) ")
            sb.Append("	INNER JOIN 	SEC_USER WITH(NOLOCK) ON UPPER(ALERT_COMMENT.USER_CODE) = UPPER(SEC_USER.USER_CODE) ")
            sb.Append("	INNER JOIN 	EMPLOYEE WITH(NOLOCK) ON SEC_USER.EMP_CODE = EMPLOYEE.EMP_CODE ")
            'sb.Append("	LEFT OUTER JOIN EMPLOYEE_PICTURE WITH(NOLOCK) ON SEC_USER.EMP_CODE = EMPLOYEE_PICTURE.EMP_CODE ")
            sb.Append("WHERE ALERT_COMMENT.ALERT_ID = ")
            sb.Append(_AlertID)
            'If Me.IsClientPortal = True Then
            sb.Append(" UNION SELECT 	")
                sb.Append("	ALERT_COMMENT.ALERT_ID AS AlertID, 	")
                sb.Append("	CAST(ALERT_COMMENT.COMMENT AS VARCHAR(MAX)) AS Comment, 	")
                sb.Append("	ALERT_COMMENT.GENERATED_DATE AS [Date], 	")
                sb.Append("	CAST(CDP_CONTACT_HDR.CDP_CONTACT_ID AS VARCHAR) AS EmployeeCode, 	")
            sb.Append("	CDP_CONTACT_HDR.CONT_FML AS EmployeeFullName, 	")
            sb.Append("	ALERT_COMMENT.COMMENT_ID AS CommentID 	")
            'sb.Append("	'''' AS NickName	")
            'sb.Append("	NULL AS EmployeePicture ")
            sb.Append("FROM 	")
                sb.Append("	ALERT_COMMENT WITH(NOLOCK) ")
                sb.Append("	INNER JOIN 	CDP_CONTACT_HDR WITH (NOLOCK) ON ALERT_COMMENT.USER_CODE_CP = CDP_CONTACT_HDR.CDP_CONTACT_ID ")
                sb.Append("	LEFT OUTER JOIN CP_USER WITH (NOLOCK) ON CP_USER.CDP_CONTACT_ID = CDP_CONTACT_HDR.CDP_CONTACT_ID ")
                sb.Append("WHERE ALERT_COMMENT.ALERT_ID = ")
            sb.Append(_AlertID)
            sb.Append(") AS A LEFT OUTER JOIN EMPLOYEE_PICTURE EP ON A.EmployeeCode = EP.EMP_CODE")
            'End If
            sb.Append(" ORDER BY A.[Date] DESC, A.CommentID DESC;")

            Comments = DbContext.Database.SqlQuery(Of SimpleCommentDisplay)(sb.ToString()).ToList()


            If Comments IsNot Nothing Then

                Me.DataListComments.DataSource = Comments
                Me.DataListComments.DataBind()

            End If

            'Dim a As AdvantageFramework.Database.Entities.Alert
            'a = AdvantageFramework.Database.Procedures.Alert.LoadByAlertID(DbContext, a)

            'If a IsNot Nothing Then

            '    Me.PageTitle = a.Subject

            'End If

        End Using

    End Sub

    Private _CurrentEmployeeCode As String = ""
    Private _PreviousEmployeeCode As String = ""

    Private _PreviousImageCSS As String = ""
    Private _PreviousContainerCSS As String = ""
    Private _PreviousCommentCSS As String = ""
    Private Sub DataListComments_ItemDataBound(sender As Object, e As DataListItemEventArgs) Handles DataListComments.ItemDataBound

        Select Case e.Item.ItemType
            Case ListItemType.Item, ListItemType.AlternatingItem

                Dim Comment As SimpleCommentDisplay
                Comment = e.Item.DataItem

                If Comment IsNot Nothing Then

                    If _DeepLink Is Nothing Then _DeepLink = New AdvantageFramework.Web.DeepLink(Me._Session)
                    Dim DocumentLinksPlaceHolder As PlaceHolder = CType(e.Item.FindControl("PlaceHolderDocumentLinks"), PlaceHolder)
                    Dim InternalLinksPlaceHolder As PlaceHolder = CType(e.Item.FindControl("PlaceHolderInternalLinks"), PlaceHolder)
                    Dim TheComment As String = String.Empty

                    Dim EmployeeASPxBinaryImage As ASPxBinaryImage = e.Item.FindControl("ASPxBinaryImageEmployee")
                    EmployeeASPxBinaryImage.Value = Comment.EmployeePicture

                    Dim EmployeeLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelEmployee")
                    If Comment.EmployeeCode = Session("EmpCode") Then
                        EmployeeLabel.Text = "I said:"
                    Else
                        EmployeeLabel.Text = Comment.EmployeeFullName & " said:"
                    End If

                    Dim CommentLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelComment")

                    'CommentLabel.Text = HttpUtility.HtmlDecode(Comment.Comment)
                    'CommentLabel.Text = HttpUtility.HtmlEncode(Comment.Comment)
                    TheComment = Comment.Comment
                    _DeepLink.UrlToInternalLink(TheComment, InternalLinksPlaceHolder, True)
                    CommentLabel.Text = Me.Sanitize(TheComment)

                    Dim DateLabel As System.Web.UI.WebControls.Label = e.Item.FindControl("LabelDate")
                    DateLabel.Text = String.Format("{0:f}", Comment.Date)

                    _CurrentEmployeeCode = Comment.EmployeeCode

                    If _PreviousEmployeeCode = "" Then

                        _PreviousEmployeeCode = Comment.EmployeeCode
                        _PreviousImageCSS = "wv-employee-img-thumbnail-xxlg"
                        _PreviousContainerCSS = "comment-container"
                        _PreviousCommentCSS = "comment-left"

                    Else

                        If _PreviousEmployeeCode <> _CurrentEmployeeCode Then

                            If _PreviousCommentCSS = "comment-left" Then

                                _PreviousImageCSS = "wv-employee-img-thumbnail-xxlg"
                                _PreviousContainerCSS = "comment-container-right"
                                _PreviousCommentCSS = "comment-right"

                            Else

                                _PreviousImageCSS = "wv-employee-img-thumbnail-xxlg"
                                _PreviousContainerCSS = "comment-container"
                                _PreviousCommentCSS = "comment-left"

                            End If

                            _PreviousEmployeeCode = _CurrentEmployeeCode

                        End If

                    End If

                    Dim CommentContainerDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivCommentContainer")
                    CommentContainerDiv.Attributes.Remove("class")
                    CommentContainerDiv.Attributes.Add("class", _PreviousContainerCSS)

                    Dim CommentDiv As HtmlControls.HtmlGenericControl = e.Item.FindControl("DivComment")
                    CommentDiv.Attributes.Remove("class")
                    CommentDiv.Attributes.Add("class", _PreviousCommentCSS)

                    EmployeeASPxBinaryImage.CssClass = _PreviousImageCSS

                End If

        End Select

    End Sub

    Private Sub ButtonAdd_Click(sender As Object, e As EventArgs) Handles ButtonAdd.Click

        Dim StrComment As String = Me.RadEditorComment.Content

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

            Dim eso As New EmailSessionObject(HttpContext.Current.Session("ConnString"),
                                  HttpContext.Current.Session("UserCode"),
                                  Me._Session,
                                  HttpContext.Current.Session("WebvantageURL"),
                                  HttpContext.Current.Session("ClientPortalURL"))

            With eso

                .AlertId = Me._AlertID
                .Subject = "[Alert Updated]"
                .IsClientPortal = Me.IsClientPortal
                .SessionID = HttpContext.Current.Session.SessionID.ToString()
                .PhysicalApplicationPath = HttpContext.Current.Request.PhysicalApplicationPath
                .Send()

            End With

            Me.CheckForAsyncMessage()

            Me.RadEditorComment.Content = ""
            Me.FocusControl(Me.RadEditorComment)

            Me.DataListComments_Load()

        End If

    End Sub
End Class

Public Class SimpleCommentDisplay

    Public Property AlertID As Integer = 0
    Public Property Comment As String = ""
    Public Property [Date] As Date
    Public Property EmployeeCode As String = ""
    Public Property [EmployeeFullName] As String = ""
    Public Property [EmployeePicture] As Byte()

End Class
