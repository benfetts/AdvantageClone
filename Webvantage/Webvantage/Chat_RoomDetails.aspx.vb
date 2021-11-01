Imports Telerik.Web.UI
Imports Webvantage.wvTimeSheet

Public Class Chat_RoomDetails
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _RoomName As String = ""
    Private _DbChatRoom As AdvantageFramework.Database.Entities.ChatRoom

#End Region

#Region " Properties "

    Private Property _RoomID As String
        Get

            If ViewState("_RoomID") Is Nothing Then

                Return String.Empty

            Else

                Return ViewState("_RoomID")

            End If

        End Get
        Set(value As String)

            ViewState("_RoomID") = value

        End Set
    End Property
    Private Property ChatRoomID As Integer
        Get

            If ViewState("ChatRoomID") Is Nothing Then

                Return 0

            Else

                Return ViewState("ChatRoomID")

            End If

        End Get
        Set(value As Integer)

            ViewState("ChatRoomID") = value

        End Set
    End Property
    Private Property IsExistingRoom As Boolean
        Get

            If ViewState("IsExistingRoom") Is Nothing Then

                Return False

            Else

                Return ViewState("IsExistingRoom")

            End If

        End Get
        Set(value As Boolean)

            ViewState("IsExistingRoom") = value

        End Set
    End Property

#End Region

#Region " Methods "

#Region " Controls "

    Private Sub RadGridChatRoomLog_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridChatRoomLog.NeedDataSource

        If Me.ChatRoomID = 0 AndAlso Me.CurrentQuerystring.ChatRoomId > 0 Then Me.ChatRoomID = Me.CurrentQuerystring.ChatRoomId

        If Me.ChatRoomID > 0 Then

            Using dc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)


                'If Me.CheckBoxHideSystemMessages.Checked = True Then

                '    Dim Messages As Generic.List(Of AdvantageFramework.Database.Entities.ChatMessage)

                '    Messages = Nothing
                '    Messages = AdvantageFramework.Database.Procedures.ChatMessage.LoadByChatRoomIDWithoutSystemMessages(dc, Me.ChatRoomID).ToList()

                '    If Messages Is Nothing Then

                '        Messages = New Generic.List(Of AdvantageFramework.Database.Entities.ChatMessage)

                '    End If

                '    Me.RadGridChatRoomLog.DataSource = Messages

                'Else

                Dim Messages As Generic.List(Of AdvantageFramework.Database.Classes.ChatMessage)
                Messages = Nothing
                Messages = AdvantageFramework.Database.Procedures.ChatMessage.LoadByChatRoomID(dc, Me.ChatRoomID, Me.CheckBoxHideSystemMessages.Checked).ToList()

                If Messages Is Nothing Then

                    Messages = New Generic.List(Of AdvantageFramework.Database.Classes.ChatMessage)

                End If

                Me.RadGridChatRoomLog.DataSource = Messages

                'End If

            End Using

        End If

    End Sub
    Private Sub RadToolBarChatRoomActions_ButtonClick(sender As Object, e As RadToolBarEventArgs) Handles RadToolBarChatRoomActions.ButtonClick

        Dim ErrorMessage As String = ""
        Dim Saved As Boolean = False

        Select Case e.Item.Value
            Case "SaveRoom"

                Me.SaveRoom()

            Case "DiscardDeleteRoom"

                Dim Deleted As Boolean = False

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    _DbChatRoom = Nothing

                    If Me.ChatRoomID > 0 Then

                        _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByID(DbContext, Me.ChatRoomID)

                    Else

                        _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, Me._RoomID)

                    End If

                    If _DbChatRoom IsNot Nothing Then

                        Deleted = SignalR.Classes.ChatHub.DeleteRoomByRoomID(_DbChatRoom, _Session, ErrorMessage)

                    End If

                End Using
                If Deleted = True Then

                    Me.CloseThisWindowAndRefreshCaller("Chat_List.aspx")

                End If

        End Select

    End Sub

#End Region
#Region " Page "

    Private Sub Chat_RoomDetails_Init(sender As Object, e As EventArgs) Handles Me.Init

        If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.RoomID) = False Then Me._RoomID = Me.CurrentQuerystring.RoomID

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

            If String.IsNullOrWhiteSpace(Me.CurrentQuerystring.RoomName) = False Then Me._RoomName = Me.CurrentQuerystring.RoomName
            If Me.CurrentQuerystring.ChatRoomId > 0 Then Me.ChatRoomID = Me.CurrentQuerystring.ChatRoomId

            Try

                Me.CheckBoxIsPrivate.Checked = Me.CurrentQuerystring.GetValue("pvt") = "true"

            Catch ex As Exception
            End Try

            Me.LoadDbChatRoom()

        End If

    End Sub
    Private Sub Chat_RoomDetails_Load(sender As Object, e As EventArgs) Handles Me.Load

        If Not Me.IsPostBack AndAlso Not Me.IsCallback Then

        Else

            Select Case Me.EventTarget
                Case "angularjs"
                    Select Case Me.EventArgument
                        Case "Save"
                            Me.SaveRoom()
                    End Select
            End Select

        End If

    End Sub

#End Region

    Private Sub LoadDbChatRoom()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Me.DivChatLog.Visible = False

            _DbChatRoom = Nothing

            If Me.ChatRoomID > 0 Then

                _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByID(DbContext, Me.ChatRoomID)

            Else

                _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, Me._RoomID)

            End If

            If _DbChatRoom IsNot Nothing Then

                Dim HasJobNumber As Boolean = False
                Me.IsExistingRoom = True
                Me.ChatRoomID = _DbChatRoom.ID
                Me.DivChatLog.Visible = True

                Dim SaveButton As RadToolBarItem
                SaveButton = Me.RadToolBarChatRoomActions.FindItemByValue("SaveRoom")

                If SaveButton IsNot Nothing Then

                    If _DbChatRoom.IsSaved = True Then

                        SaveButton.ToolTip = "Update this saved room"

                    Else

                        SaveButton.ToolTip = "Save this room"

                    End If

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.RoomID) = False Then

                    Me._RoomID = _DbChatRoom.RoomID

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.Name) = False Then

                    Me.TextBoxRoomName.Text = _DbChatRoom.Name

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.Description) = False Then

                    Me.TextBoxRoomDescription.Text = _DbChatRoom.Description

                End If
                If _DbChatRoom.IsPrivate <> Nothing Then

                    Me.CheckBoxIsPrivate.Checked = _DbChatRoom.IsPrivate

                End If
                If _DbChatRoom.StartedByUserCode <> _Session.UserCode Then

                    Me.RadToolBarChatRoomActions.FindItemByValue("DiscardDeleteRoom").Visible = False

                End If
                If _DbChatRoom.JobNumber IsNot Nothing AndAlso _DbChatRoom.JobNumber > 0 Then

                    HasJobNumber = True

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.ClientCode) = False Then

                    Me.TextBoxClientCode.Text = _DbChatRoom.ClientCode

                    If HasJobNumber = False Then Me.TextBoxClientName.Text = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(CL_NAME, '') FROM CLIENT WITH(NOLOCK) WHERE CL_CODE = '{0}';", _DbChatRoom.ClientCode)).SingleOrDefault

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.DivisionCode) = False Then

                    Me.TextBoxDivisionCode.Text = _DbChatRoom.DivisionCode

                    If HasJobNumber = False Then Me.TextBoxDivisionName.Text = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(DIV_NAME, '') FROM DIVISION WITH(NOLOCK) WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}';", _DbChatRoom.ClientCode, _DbChatRoom.DivisionCode)).SingleOrDefault

                End If
                If String.IsNullOrWhiteSpace(_DbChatRoom.ProductCode) = False Then

                    Me.TextBoxProductCode.Text = _DbChatRoom.ProductCode

                    If HasJobNumber = False Then Me.TextBoxProductDescription.Text = DbContext.Database.SqlQuery(Of String)(String.Format("SELECT ISNULL(PRD_DESCRIPTION, '') FROM PRODUCT WITH(NOLOCK) WHERE CL_CODE = '{0}' AND DIV_CODE = '{1}' AND PRD_CODE = '{2}';", _DbChatRoom.ClientCode, _DbChatRoom.DivisionCode, _DbChatRoom.ProductCode)).SingleOrDefault

                End If
                If HasJobNumber = True Then

                    Me.TextBoxJobNumber.Text = _DbChatRoom.JobNumber

                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.GetJobInfo(_DbChatRoom.JobNumber, Me.TextBoxJobDescription.Text,
                                       "", Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text,
                                       Nothing,
                                       Me.TextBoxClientName.Text, Me.TextBoxDivisionName.Text, Me.TextBoxProductDescription.Text)

                End If
                If _DbChatRoom.JobComponentNumber IsNot Nothing AndAlso _DbChatRoom.JobComponentNumber > 0 Then

                    Me.TextBoxJobComponentNumber.Text = _DbChatRoom.JobComponentNumber

                    Try

                        Using oc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                            Dim jc As AdvantageFramework.Database.Entities.JobComponent
                            jc = Nothing

                            jc = AdvantageFramework.Database.Procedures.JobComponent.LoadByJobNumberAndJobComponentNumber(oc, _DbChatRoom.JobNumber, _DbChatRoom.JobComponentNumber)

                            If jc IsNot Nothing Then

                                Me.TextBoxJobComponentDescription.Text = jc.Description

                            End If

                        End Using

                    Catch ex As Exception
                    End Try

                End If

                If _DbChatRoom.StartedByUserCode <> _Session.UserCode Then

                    Me.RadToolBarChatRoomActions.FindItemByValue("DiscardDeleteRoom").Visible = False

                End If

            End If

            Dim SbAngular As System.Text.StringBuilder = New System.Text.StringBuilder

            SbAngular.AppendLine("$(document).ready(function () {{")
            SbAngular.AppendLine(" setTimeout(function(){{")
            SbAngular.AppendLine("	var currentScope = angular.element($('#TextBoxClientCode')).scope();")
            SbAngular.AppendLine("	currentScope.clientCode = '{0}';")
            SbAngular.AppendLine("	currentScope.divisionCode = '{1}';")
            SbAngular.AppendLine("	currentScope.productCode = '{2}';")
            SbAngular.AppendLine("	currentScope.jobNumber = '{3}';")
            SbAngular.AppendLine("	currentScope.jobComponentNumber = '{4}';")
            SbAngular.AppendLine("	currentScope.clientName = '{5}';")
            SbAngular.AppendLine("	currentScope.divisionName = '{6}';")
            SbAngular.AppendLine("	currentScope.productDescription = '{7}';")
            SbAngular.AppendLine("	currentScope.jobDescription = '{8}';")
            SbAngular.AppendLine("	currentScope.jobComponentDescription = '{9}';")
            SbAngular.AppendLine("   currentScope.$apply();")
            SbAngular.AppendLine(" }}, 500);")
            SbAngular.AppendLine("}});")

            Page.ClientScript.RegisterStartupScript(Me.Page.GetType(), "InitializeAngularValues", String.Format(SbAngular.ToString(),
                                                                                                                        Me.TextBoxClientCode.Text,
                                                                                                                        Me.TextBoxDivisionCode.Text,
                                                                                                                        Me.TextBoxProductCode.Text,
                                                                                                                        Me.TextBoxJobNumber.Text,
                                                                                                                        Me.TextBoxJobComponentNumber.Text,
                                                                                                                        Me.TextBoxClientName.Text,
                                                                                                                        Me.TextBoxDivisionName.Text,
                                                                                                                        Me.TextBoxProductDescription.Text,
                                                                                                                        Me.TextBoxJobDescription.Text,
                                                                                                                        Me.TextBoxJobComponentDescription.Text), True)

            If String.IsNullOrWhiteSpace(Me.TextBoxRoomName.Text) = False Then Me.Page.Title = Me.TextBoxRoomName.Text

        End Using

    End Sub
    Private Sub CheckBoxHideSystemMessages_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxHideSystemMessages.CheckedChanged

        Me.RadGridChatRoomLog.Rebind()

    End Sub
    Private Sub SaveRoom()

        Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            If _DbChatRoom Is Nothing AndAlso Me.ChatRoomID > 0 Then


                _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByID(DbContext, Me.ChatRoomID)


            End If
            If _DbChatRoom Is Nothing AndAlso String.IsNullOrEmpty(Me._RoomID) = False Then

                _DbChatRoom = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, Me._RoomID)

            End If

            If _DbChatRoom IsNot Nothing Then

                Dim ErrorMessage As String = String.Empty
                Dim NameChange As Boolean = False

                If _DbChatRoom.Name <> Me.TextBoxRoomName.Text.Trim() Then

                    NameChange = True

                End If
                If _DbChatRoom.IsSaved = False Then

                    _DbChatRoom.IsSaved = True
                    _DbChatRoom.Name = Webvantage.SignalR.Classes.ChatHub.CheckSavedRoomName(DbContext, Me.TextBoxRoomName.Text.Trim())

                Else

                    If NameChange = True Then

                        _DbChatRoom.Name = Webvantage.SignalR.Classes.ChatHub.CheckSavedRoomName(DbContext, Me.TextBoxRoomName.Text.Trim())

                    End If

                End If

                _DbChatRoom.Description = Me.TextBoxRoomDescription.Text

                If String.IsNullOrWhiteSpace(Me.TextBoxClientCode.Text) = False Then _DbChatRoom.ClientCode = Me.TextBoxClientCode.Text
                If String.IsNullOrWhiteSpace(Me.TextBoxDivisionCode.Text) = False Then _DbChatRoom.DivisionCode = Me.TextBoxDivisionCode.Text
                If String.IsNullOrWhiteSpace(Me.TextBoxProductCode.Text) = False Then _DbChatRoom.ProductCode = Me.TextBoxProductCode.Text

                If IsNumeric(TextBoxJobNumber.Text) = True Then

                    _DbChatRoom.JobNumber = CType(TextBoxJobNumber.Text, Integer)

                    Dim oTS As cTimeSheet = New cTimeSheet(CStr(Session("ConnString")))
                    oTS.GetJobInfo(_DbChatRoom.JobNumber, Me.TextBoxJobDescription.Text,
                                           "", Me.TextBoxClientCode.Text, Me.TextBoxDivisionCode.Text, Me.TextBoxProductCode.Text,
                                           Nothing,
                                           Me.TextBoxClientName.Text, Me.TextBoxDivisionName.Text, Me.TextBoxProductDescription.Text)

                    If String.IsNullOrWhiteSpace(Me.TextBoxClientCode.Text) = False Then _DbChatRoom.ClientCode = Me.TextBoxClientCode.Text
                    If String.IsNullOrWhiteSpace(Me.TextBoxDivisionCode.Text) = False Then _DbChatRoom.DivisionCode = Me.TextBoxDivisionCode.Text
                    If String.IsNullOrWhiteSpace(Me.TextBoxProductCode.Text) = False Then _DbChatRoom.ProductCode = Me.TextBoxProductCode.Text

                End If
                If IsNumeric(TextBoxJobComponentNumber.Text) = True Then _DbChatRoom.JobComponentNumber = CType(TextBoxJobComponentNumber.Text, Integer)
                If IsNumeric(TextBoxAlertAssignmentID.Text) = True Then _DbChatRoom.AlertID = CType(TextBoxAlertAssignmentID.Text, Integer)

                If AdvantageFramework.Database.Procedures.ChatRoom.Update(DbContext, _DbChatRoom, ErrorMessage) = False Then

                    If String.IsNullOrWhiteSpace(ErrorMessage) = False Then

                        Me.ShowMessage(ErrorMessage)

                    Else

                        Me.ShowMessage("Error updating")

                    End If

                Else

                    Me.LoadDbChatRoom()

                    Try

                        If NameChange = True AndAlso _DbChatRoom.IsActive = True Then

                            Webvantage.SignalR.Classes.ChatHub.RoomNameUpdated(DbContext, _DbChatRoom)

                        End If

                    Catch ex As Exception
                    End Try

                End If

            End If

        End Using

    End Sub


#End Region

End Class