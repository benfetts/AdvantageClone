Imports Telerik.Web.UI

Public Class Chat_NewRoomCreator
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "

    Private Enum LoadType

        Job = 1
        Job_Component = 2
        Alert = 3
        Task = 4

    End Enum
    Private Enum EmployeeType

        AlertGroup = 1
        ScheduleAssignments = 2
        TaskAssignments = 3
        AccountExecutive = 4
        AlertRecipients = 5
        ProjectManager = 6

    End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

    Public Property JobNumber As Integer
        Get
            If ViewState("JobNumber") Is Nothing Then
                ViewState("JobNumber") = 0
            End If
            Return CType(ViewState("JobNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("JobNumber") = value
        End Set
    End Property
    Public Property JobComponentNumber As Short
        Get
            If ViewState("JobComponentNumber") Is Nothing Then
                ViewState("JobComponentNumber") = 0
            End If
            Return CType(ViewState("JobComponentNumber"), Short)
        End Get
        Set(value As Short)
            ViewState("JobComponentNumber") = value
        End Set
    End Property
    Public Property AlertID As Integer
        Get
            If ViewState("AlertID") Is Nothing Then
                ViewState("AlertID") = 0
            End If
            Return CType(ViewState("AlertID"), Integer)
        End Get
        Set(value As Integer)
            ViewState("AlertID") = value
        End Set
    End Property
    Public Property TaskSequenceNumber As Integer
        Get
            If ViewState("TaskSequenceNumber") Is Nothing Then
                ViewState("TaskSequenceNumber") = -1
            End If
            Return CType(ViewState("TaskSequenceNumber"), Integer)
        End Get
        Set(value As Integer)
            ViewState("TaskSequenceNumber") = value
        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadioButtonListEmployeeType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles RadioButtonListEmployeeType.SelectedIndexChanged

        Me.LoadEmployeeList()

    End Sub
    Private Sub RadToolbarNewChatRoom_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolbarNewChatRoom.ButtonClick

        Select Case e.Item.Value
            Case "Chat"

                If Me.RadListBoxEmployees.SelectedItems Is Nothing OrElse Me.RadListBoxEmployees.SelectedItems.Count = 0 Then

                    Me.ShowMessage("No one but yourself would be in the room; room not created.")

                Else

                    Me.CreateRoom()

                End If

        End Select

    End Sub

#End Region
#Region " Page "

    Private Sub Chat_NewRoomCreator_Init(sender As Object, e As EventArgs) Handles Me.Init

        If Me.CurrentQuerystring.AlertID > 0 Then Me.AlertID = Me.CurrentQuerystring.AlertID
        If Me.CurrentQuerystring.JobNumber > 0 Then Me.JobNumber = Me.CurrentQuerystring.JobNumber
        If Me.CurrentQuerystring.JobComponentNumber > 0 Then Me.JobComponentNumber = Me.CurrentQuerystring.JobComponentNumber
        If Me.CurrentQuerystring.TaskSequenceNumber > -1 Then Me.TaskSequenceNumber = Me.CurrentQuerystring.TaskSequenceNumber

    End Sub
    Private Sub Chat_NewRoomCreator_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.Page.IsPostBack AndAlso Not Me.Page.IsCallback Then

            Me.LoadEmployeeRadioButtonList()

            If Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

                Me.TextBoxRoomName.Text = String.Format("Job {0}/{1}", Me.JobNumber.ToString.PadLeft(6, "0"),
                                                        Me.JobComponentNumber.ToString.PadLeft(2, "0"))

            End If
            If Me.AlertID > 0 Then

                Me.TextBoxRoomName.Text = String.Format("Alert {0}", Me.AlertID)

            End If

        End If

    End Sub

#End Region

    Private Sub LoadEmployeeRadioButtonList()

        Me.RadioButtonListEmployeeType.Items.Clear()

        Dim EmployeeTypeListItem As ListItem

        If Me.AlertID > 0 Then

            EmployeeTypeListItem = New ListItem
            EmployeeTypeListItem.Text = "Alert Recipients"
            EmployeeTypeListItem.Value = 5
            RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
            EmployeeTypeListItem = Nothing

        End If
        If Me.JobNumber > 0 AndAlso Me.JobComponentNumber > 0 Then

            Dim HasSchedule As Boolean = False

            Try

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Schedule As AdvantageFramework.Database.Entities.JobTraffic

                    Schedule = Nothing
                    Schedule = AdvantageFramework.Database.Procedures.JobTraffic.LoadByJobNumberAndJobComponentNumber(DbContext, Me.JobNumber, Me.JobComponentNumber)

                    If Schedule IsNot Nothing Then

                        HasSchedule = True

                    End If

                End Using

            Catch ex As Exception
                HasSchedule = False
            End Try

            EmployeeTypeListItem = New ListItem
            EmployeeTypeListItem.Text = "All"
            EmployeeTypeListItem.Value = 0
            RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
            EmployeeTypeListItem = Nothing

            EmployeeTypeListItem = New ListItem
            EmployeeTypeListItem.Text = "Alert Group"
            EmployeeTypeListItem.Value = 1
            RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
            EmployeeTypeListItem = Nothing

            If HasSchedule = True Then

                EmployeeTypeListItem = New ListItem
                EmployeeTypeListItem.Text = "Schedule Assignments"
                EmployeeTypeListItem.Value = 2
                RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
                EmployeeTypeListItem = Nothing

            End If

            EmployeeTypeListItem = New ListItem
            EmployeeTypeListItem.Text = "Account Executive"
            EmployeeTypeListItem.Value = 4
            RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
            EmployeeTypeListItem = Nothing

            If HasSchedule = True Then

                EmployeeTypeListItem = New ListItem
                EmployeeTypeListItem.Text = "Project Manager"
                EmployeeTypeListItem.Value = 6
                RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
                EmployeeTypeListItem = Nothing

                EmployeeTypeListItem = New ListItem
                EmployeeTypeListItem.Text = "Task Assignments"
                EmployeeTypeListItem.Value = 3
                RadioButtonListEmployeeType.Items.Add(EmployeeTypeListItem)
                EmployeeTypeListItem = Nothing

            End If

        End If

    End Sub
    Private Sub LoadEmployeeList()

        Me.RadListBoxEmployees.Items.Clear()

        Dim Users As Generic.List(Of ChatUserListBox)

        Try

            Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                Users = DbContext.Database.SqlQuery(Of ChatUserListBox)(String.Format("EXEC advsp_chat_load_users {0}, {1}, {2}, {3}, '{4}';",
                                                                                      JobNumber, JobComponentNumber, AlertID,
                                                                                      Me.RadioButtonListEmployeeType.SelectedItem.Value,
                                                                                      _Session.UserCode)).ToList

            End Using

        Catch ex As Exception
            Users = Nothing
        End Try

        If Users Is Nothing Then Users = New Generic.List(Of ChatUserListBox)

        Me.RadListBoxEmployees.DataSource = Users
        Me.RadListBoxEmployees.DataTextField = "FullName"
        Me.RadListBoxEmployees.DataValueField = "UserCode"
        Me.RadListBoxEmployees.DataBind()

        If Me.RadListBoxEmployees.Items IsNot Nothing AndAlso Me.RadListBoxEmployees.Items.Count > 0 AndAlso Me.RadioButtonListEmployeeType.SelectedItem.Value <> "0" Then

            For Each Item As RadListBoxItem In Me.RadListBoxEmployees.Items

                Item.Selected = True

            Next

        End If

    End Sub
    Private Sub CreateRoom()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            'Create room
            Dim RoomName As String = Me.TextBoxRoomName.Text
            Dim NewRoom As New AdvantageFramework.Database.Entities.ChatRoom
            Dim HasMe As Boolean = False

            NewRoom.Name = SignalR.Classes.ChatHub.CheckRoomName(DbContext, RoomName)
            NewRoom.StartedByUserCode = _Session.UserCode
            NewRoom.IsPrivate = Me.CheckBoxIsPrivate.Checked
            NewRoom.IsActive = True
            NewRoom.IsSaved = Me.CheckBoxSaveRoom.Checked
            If String.IsNullOrWhiteSpace(Me.TextBoxRoomDescription.Text) = False Then

                NewRoom.Description = Me.TextBoxRoomDescription.Text

            End If

            If Me.JobNumber > 0 Then

                Try

                    Dim Job As AdvantageFramework.Database.Entities.Job
                    Job = AdvantageFramework.Database.Procedures.Job.LoadByJobNumber(DbContext, Me.JobNumber)

                    If Job IsNot Nothing Then

                        NewRoom.ClientCode = Job.ClientCode
                        NewRoom.DivisionCode = Job.DivisionCode
                        NewRoom.ProductCode = Job.ProductCode
                        NewRoom.JobNumber = Me.JobNumber

                    End If

                Catch ex As Exception
                End Try

            End If
            If Me.JobComponentNumber > 0 Then

                NewRoom.JobComponentNumber = Me.JobComponentNumber

            End If

            If AdvantageFramework.Database.Procedures.ChatRoom.Insert(DbContext, NewRoom, Nothing) = True Then

                'Add users
                Dim RoomMember As AdvantageFramework.Database.Entities.ChatUser = Nothing
                Dim ErrorMessage As String = String.Empty
                Dim UsersInRoom As Integer = 0

                For Each Item As RadListBoxItem In Me.RadListBoxEmployees.SelectedItems

                    RoomMember = New AdvantageFramework.Database.Entities.ChatUser

                    RoomMember.ChatRoomID = NewRoom.ID
                    RoomMember.UserCode = Item.Value

                    If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, RoomMember, ErrorMessage) = True Then

                        UsersInRoom += 1

                        If RoomMember.UserCode = _Session.UserCode Then

                            HasMe = True

                        End If

                    Else

                        If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                            Me.ShowMessage(ErrorMessage)

                        End If

                    End If

                Next

                If HasMe = False Then

                    Try

                        RoomMember = New AdvantageFramework.Database.Entities.ChatUser

                        RoomMember.ChatRoomID = NewRoom.ID
                        RoomMember.UserCode = _Session.UserCode

                        If AdvantageFramework.Database.Procedures.ChatUser.Insert(DbContext, RoomMember, ErrorMessage) = True Then

                            UsersInRoom += 1

                        End If


                    Catch ex As Exception
                    End Try

                End If

                If UsersInRoom > 0 Then

                    'continue chat
                    SignalR.Classes.ChatHub.ContinueChatRoom(NewRoom.RoomID, _Session)
                    Me.CloseThisWindow()

                End If

            End If

        End Using

    End Sub

#End Region

    <Serializable()>
    Public Class ChatUserListBox

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property UserCode As String
        Public Property EmployeeCode As String
        Public Property FullName As String
        Public Property Picture As Byte()
        Public Property Nickname As String

#End Region

#Region " Methods "



#End Region

    End Class

End Class