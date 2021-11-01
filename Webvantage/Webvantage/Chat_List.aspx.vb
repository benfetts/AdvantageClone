Imports Telerik.Web.UI

Public Class Chat_List
    Inherits Webvantage.BaseChildPage


#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Private Property _JobNumber As Integer = 0
    Private Property _JobComponentNumber As Integer = 0

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadComboBoxChatType_SelectedIndexChanged(sender As Object, e As RadComboBoxSelectedIndexChangedEventArgs) Handles RadComboBoxChatType.SelectedIndexChanged

        Me.RadGridChatList.Rebind()

    End Sub

    Private Sub RadGridChatList_ItemCommand(sender As Object, e As GridCommandEventArgs) Handles RadGridChatList.ItemCommand

        Dim ErrorMessage As String = ""

        Select Case e.CommandName
            Case "DeleteRow"

                Dim Deleted As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim ChatRoomID As Integer = CType(e.CommandArgument, Integer)
                    Dim ChatRoomRoomID As String = String.Empty

                    Dim DbChatRoom As AdvantageFramework.Database.Entities.ChatRoom

                    DbChatRoom = Nothing
                    DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByID(DbContext, ChatRoomID)

                    If DbChatRoom IsNot Nothing Then

                        ChatRoomRoomID = DbChatRoom.RoomID
                        Deleted = SignalR.Classes.ChatHub.DeleteRoomByRoomID(DbChatRoom, _Session, ErrorMessage)

                    End If

                End Using

                If Deleted = True Then Me.RadGridChatList.Rebind()

            Case "ContinueChat"

                SignalR.Classes.ChatHub.ContinueChatRoom(e.CommandArgument, _Session)

        End Select

    End Sub
    Private Sub RadGridChatList_ItemDataBound(sender As Object, e As GridItemEventArgs) Handles RadGridChatList.ItemDataBound

        Select Case e.Item.ItemType
            Case GridItemType.Header

            Case GridItemType.Item, GridItemType.AlternatingItem

                Dim CurrentGridRow As GridDataItem = e.Item
                Dim ViewDetailsImageButton As ImageButton = e.Item.FindControl("ImageButtonViewDetails")
                Dim Room As AdvantageFramework.Database.Entities.ChatRoom

                Room = e.Item.DataItem

                If ViewDetailsImageButton IsNot Nothing Then

                    Dim qs As New AdvantageFramework.Web.QueryString
                    qs.Page = "Chat_RoomDetails.aspx"
                    qs.ChatRoomId = CurrentGridRow.GetDataKeyValue("ID")
                    qs.RoomID = CurrentGridRow.GetDataKeyValue("RoomID")

                    ViewDetailsImageButton.Attributes.Add("onclick", Me.HookUpOpenWindow("", qs.ToString(True)))

                End If

                Dim RoomNameLabel As Label = e.Item.FindControl("LabelRoomName")
                Dim RoomDescriptionLabel As Label = e.Item.FindControl("LabelRoomDescription")
                Dim RoomDescriptionDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivRoomDescription")

                If RoomNameLabel IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Room.Name) = False Then

                    RoomNameLabel.Text = Room.Name

                End If
                If RoomDescriptionLabel IsNot Nothing AndAlso String.IsNullOrWhiteSpace(Room.Description) = False Then

                    RoomDescriptionLabel.Text = Room.Description

                Else

                    If RoomDescriptionDiv IsNot Nothing Then AdvantageFramework.Web.Presentation.Controls.DivHide(RoomDescriptionDiv)

                End If

                Dim DeleteImageButton As ImageButton = e.Item.FindControl("ImageButtonDelete")
                Dim DeleteButtonDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivDeleteButton")
                If DeleteImageButton IsNot Nothing Then

                    DeleteImageButton.Attributes.Add("onclick", "return confirm('Are you sure you want to delete?');")
                    DeleteImageButton.CommandArgument = Room.ID

                    If Room.StartedByUserCode = _Session.UserCode Then

                        DeleteButtonDiv.Visible = True

                    Else

                        DeleteButtonDiv.Visible = False

                    End If

                End If

                Dim ContinueChatImageButton As ImageButton = e.Item.FindControl("ImageButtonContinueChat")
                If ContinueChatImageButton IsNot Nothing Then

                    ContinueChatImageButton.CommandArgument = Room.RoomID

                End If

                Dim JobAndComponentLabel As Label = e.Item.FindControl("LabelJobAndComponent")
                Dim JobAndComponentDiv As HtmlControls.HtmlControl = e.Item.FindControl("DivJobAndComponent")

                If JobAndComponentDiv IsNot Nothing AndAlso JobAndComponentLabel IsNot Nothing Then

                    If Me.RadComboBoxChatType.SelectedItem IsNot Nothing AndAlso Me.RadComboBoxChatType.SelectedItem.Value <> "job_component" AndAlso
                            Room.JobNumber > 0 AndAlso Room.JobComponentNumber > 0 Then

                        JobAndComponentLabel.Text = "Job:  " & Room.JobNumber.ToString().PadLeft(6, "0") & "/" & Room.JobComponentNumber.ToString().PadLeft(2, "0")

                    Else

                        AdvantageFramework.Web.Presentation.Controls.DivHide(JobAndComponentDiv)

                    End If

                End If

            Case GridItemType.Footer

        End Select

    End Sub
    Private Sub RadGridChatList_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridChatList.NeedDataSource

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Rooms As New Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)
            Dim AllowDelete As Boolean = False

            Rooms = Nothing

            If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                If Me.RadComboBoxChatType.SelectedItem IsNot Nothing Then

                    Select Case Me.RadComboBoxChatType.SelectedItem.Value
                        Case "job_component"

                            Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadByJobAndComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber).ToList()

                        Case "job"

                            Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadByJobNumber(DbContext, Me._JobNumber).ToList()

                    End Select

                Else

                    Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadByJobAndComponentNumber(DbContext, Me._JobNumber, Me._JobComponentNumber).ToList()

                End If

            Else

                If Me.RadComboBoxChatType.SelectedItem IsNot Nothing Then

                    Select Case Me.RadComboBoxChatType.SelectedItem.Value
                        Case "started"

                            Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadByStartedByUserCode(DbContext, _Session.UserCode).ToList()
                            AllowDelete = True

                        Case "participated"

                            Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadParticipatedIn(DbContext, _Session.UserCode).ToList()

                    End Select

                Else

                    Rooms = AdvantageFramework.Database.Procedures.ChatRoom.LoadByStartedByUserCode(DbContext, _Session.UserCode).ToList()

                End If

            End If

            If Rooms Is Nothing Then

                Rooms = New Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            End If

            Me.RadGridChatList.DataSource = Rooms

            Me.RadGridChatList.MasterTableView.GetColumnSafe("GridTemplateColumnDelete").Visible = AllowDelete

        End Using

    End Sub

#End Region
#Region " Page "

    Private Sub Chat_List_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me._JobNumber = Me.CurrentQuerystring.JobNumber
        Me._JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        LoGlo.PageCultureSet(Me.Page)

    End Sub
    Private Sub Chat_List_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            Me.RadComboBoxChatType.Items.Clear()
            If Me._JobNumber > 0 AndAlso Me._JobComponentNumber > 0 Then

                Me.RadComboBoxChatType.Items.Add(New RadComboBoxItem("For this Job Component", "job_component"))
                Me.RadComboBoxChatType.Items.Add(New RadComboBoxItem("For this Job", "job"))

            Else

                Me.RadComboBoxChatType.Items.Add(New RadComboBoxItem("Chats I started", "started"))
                Me.RadComboBoxChatType.Items.Add(New RadComboBoxItem("Chats I took part in", "participated"))

            End If

        End If

    End Sub

#End Region

#End Region

End Class