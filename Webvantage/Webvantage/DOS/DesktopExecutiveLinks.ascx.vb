Partial Public Class DesktopExecutiveLinks
    Inherits Webvantage.BaseDesktopObject

    Public li_status As Int16
    Public is_comment As String

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Me.IsPostBack And Not Me.Page.IsCallback Then
            LoadDocumentTypeList()
        End If
    End Sub

    Private Sub LoadLinks()
        Try
            Me.RadGridExecutive.Rebind()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub LoadDocumentTypeList()
        Dim oDropDowns As cDropDowns = New cDropDowns(Session("ConnString"))
        Me.ddlType.DataSource = oDropDowns.GetDocumentTypeList(Session("UserCode"))
        Me.ddlType.DataTextField = "Description"
        Me.ddlType.DataValueField = "Code"
        Me.ddlType.DataBind()
        Me.ddlType.Items.Insert(0, New Telerik.Web.UI.RadComboBoxItem("All Types", "0"))
    End Sub

    Private Sub butrefreshExecutive_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles butRefreshExecutive.Click
        LoadLinks()
    End Sub

    Private Sub ddlType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ddlType.SelectedIndexChanged
        If Me.ddlType.SelectedValue > 0 Then
            Me.RadGridExecutive.CurrentPageIndex = 0
        End If
        LoadLinks()
    End Sub

    Private Sub RadGridExecutive_ItemCommand(ByVal source As Object, ByVal e As Telerik.Web.UI.GridCommandEventArgs) Handles RadGridExecutive.ItemCommand

        If e.Item Is Nothing Then Exit Sub

        Select Case e.CommandName
            Case "View"
                Dim DocumentId As Integer = CInt(e.CommandArgument)
                Me.DeliverFile(DocumentId)
                'Case "ViewAlert"
                '    Session("ViewAlertApplication") = "desktop"
                '    MiscFN.ResponseRedirect("Alert_View.aspx?Alert=" & e.CommandArgument.ToString())
        End Select
    End Sub

    Private Sub RadGridExecutive_ItemDataBound(ByVal sender As Object, ByVal e As Telerik.Web.UI.GridItemEventArgs) Handles RadGridExecutive.ItemDataBound
        Select Case e.Item.ItemType
            Case Telerik.Web.UI.GridItemType.AlternatingItem, Telerik.Web.UI.GridItemType.Item

                Dim alertList As New AlertRecipient(Session("ConnString"))
                Dim str As String = e.Item.Cells(6).Text
                Dim dt As DateTime

                dt = CDate(e.Item.Cells(6).Text)

                e.Item.Cells(6).Text = LoGlo.FormatDate(dt)
                e.Item.Cells(4).ToolTip = e.Item.DataItem("FILENAME")

                Dim SizeCell As Integer = 5
                Dim IconCell As Integer = 3
                Dim LinkButtonCell As Integer = 4
                Dim HistoryCell As Integer = 8
                Dim AlertCell As Integer = 2

                Dim AlertDiv As HtmlControls.HtmlControl = DirectCast(e.Item.FindControl("DivAlert"), HtmlControls.HtmlControl)
                Dim AlertImageButton As System.Web.UI.WebControls.ImageButton = e.Item.Cells(AlertCell).FindControl("ImageButtonAlert")

                Dim DocumentTypeDiv As HtmlControls.HtmlControl = DirectCast(e.Item.FindControl("DivDocumentType"), HtmlControls.HtmlControl)
                Dim DocumentTypeLinkButton As System.Web.UI.WebControls.LinkButton = DirectCast(e.Item.FindControl("LinkButtonDocumentType"), LinkButton)

                AdvantageFramework.Web.Presentation.Controls.SetDocumentIcon(DocumentTypeDiv, DocumentTypeLinkButton, e.Item.DataItem("MIME_TYPE"),
                                                                             False, e.Item.DataItem("FILENAME"))

                If CType(e.Item.DataItem("ALERT_ID") = 0, Integer) Then

                    AdvantageFramework.Web.Presentation.Controls.DivHide(AlertDiv)

                Else

                    alertList.Where.ALERT_ID.Value = e.Item.DataItem("ALERT_ID")
                    alertList.Where.EMP_CODE.Value = Session("EmpCode")
                    alertList.Query.Load()

                    If alertList.RowCount > 0 Then

                        If alertList.s_READ_ALERT = "" Then

                            AlertImageButton.ImageUrl = "Images/Icons/White/256/mail.png"

                        Else

                            AlertImageButton.ImageUrl = "Images/Icons/White/256/mail_open.png"

                        End If

                        'AlertImageButton.CommandArgument = hf.Value
                        'AlertImageButton.CommandName = "ViewAlert"
                        AlertImageButton.Attributes.Remove("onclick")
                        AlertImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", "Desktop_AlertView?SprintID=0&AlertID=" & e.Item.DataItem("ALERT_ID")))

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(AlertDiv)

                    End If

                End If

                Select Case e.Item.DataItem("MIME_TYPE")
                    Case "URL"

                        Dim filename As String = e.Item.DataItem("REPOSITORY_FILENAME")

                        DocumentTypeLinkButton.Attributes.Remove("onclick")
                        DocumentTypeLinkButton.Attributes.Add("onclick", "open_JSWindow('" & filename & "','" & e.Item.DataItem("REPOSITORY_FILENAME") & "',0,0,'yes','yes','no','yes');return false;")


                    Case Else

                        DocumentTypeLinkButton.CommandArgument = e.Item.DataItem("DOCUMENT_ID")
                        DocumentTypeLinkButton.CommandName = "View"

                End Select

            Case Telerik.Web.UI.GridItemType.GroupHeader

        End Select
    End Sub

    Private Sub RadGridExecutive_NeedDataSource(ByVal source As Object, ByVal e As Telerik.Web.UI.GridNeedDataSourceEventArgs) Handles RadGridExecutive.NeedDataSource
        Try
            Dim oDO As New cDesktopObjects(Session("ConnString"))
            Dim accessPrivate As Integer = Me.CheckUserGroupSetting(AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments) 'Convert.ToInt32(AdvantageFramework.Security.LoadUserGroupSetting(_Session, AdvantageFramework.Security.GroupSettings.DocumentManager_ViewPrivateDocuments).Any(Function(SettingValue) SettingValue = True))
            Me.RadGridExecutive.DataSource = oDO.LoadExecutiveLinks(Session("UserCode"), Session("EmpCode"), Me.ddlType.SelectedValue, accessPrivate)
        Catch ex As Exception

        End Try
    End Sub

End Class
