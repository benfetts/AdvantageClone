Public Class Chat_Room
    Inherits Webvantage.BaseChildPage

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "


#End Region

#Region " Properties "

    Public ReadOnly Property RoomID As String
        Get

            Return Me.CurrentQuerystring.RoomID

        End Get
    End Property
    Public ReadOnly Property RoomName As String
        Get
            Try

                Return Me.CurrentQuerystring.RoomName

            Catch ex As Exception
                Return ""
            End Try
        End Get
    End Property
    Public Property ChatRoomID As Integer
        Get

            If ViewState("ChatRoomID") Is Nothing Then ViewState("ChatRoomID") = 0
            Return CType(ViewState("ChatRoomID"), Integer)

        End Get
        Set(value As Integer)

            ViewState("ChatRoomID") = value

        End Set
    End Property
#End Region

#Region " Methods "

#Region " Controls "



#End Region
#Region " Page "

    Private Sub Chat_Init(sender As Object, e As EventArgs) Handles Me.Init

        Me.AllowFloat = False

        Try

            If String.IsNullOrWhiteSpace(RoomID) = False AndAlso Not Me.IsPostBack AndAlso Not Me.IsCallback Then

                Using DbContext = New AdvantageFramework.Database.DbContext(_Session.ConnectionString, _Session.UserCode)

                    Dim Room As AdvantageFramework.Database.Entities.ChatRoom

                    Room = Nothing
                    Room = AdvantageFramework.Database.Procedures.ChatRoom.LoadByRoomID(DbContext, RoomID)

                    If Room IsNot Nothing Then

                        Me.Title = "Chat room:  " & Room.Name
                        Me.ChatRoomID = Room.ID

                    Else

                        Me.CloseThisWindow()

                    End If

                End Using

            End If

        Catch ex As Exception
            Me.CloseThisWindow()
        End Try

    End Sub

#End Region

#End Region

End Class