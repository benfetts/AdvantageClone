Imports Telerik.Web.UI

Public Class Chat_RoomViewAsLog
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

    Private _ChatRoomID As Integer = 0

#End Region

#Region " Properties "



#End Region

#Region " Methods "

#Region " Controls "


#End Region
#Region " Page "

    Private Sub Chat_RoomViewAsLog_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me._ChatRoomID = Me.CurrentQuerystring.ChatRoomId

    End Sub

    Private Sub RadGridChatRoomLog_NeedDataSource(sender As Object, e As GridNeedDataSourceEventArgs) Handles RadGridChatRoomLog.NeedDataSource

        Using dc = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

            Dim Messages As Generic.List(Of AdvantageFramework.Database.Entities.ChatMessage)
            Messages = Nothing

            Messages = AdvantageFramework.Database.Procedures.ChatMessage.LoadByChatRoomID(dc, Me._ChatRoomID).ToList()

            If Messages Is Nothing Then

                Messages = New Generic.List(Of AdvantageFramework.Database.Entities.ChatMessage)

            End If

            Me.RadGridChatRoomLog.DataSource = Messages

        End Using

    End Sub

#End Region

#End Region

End Class