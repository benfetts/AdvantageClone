Namespace Database.Procedures.ChatActiveRoom

    <HideModuleName()>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

        Public Function LoadByRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoomID As String) As AdvantageFramework.Database.Entities.ChatActiveRoom

            LoadByRoomID = (From ChatActiveRoom In DbContext.ChatActiveRooms
                            Where ChatActiveRoom.RoomID = RoomID
                            Select ChatActiveRoom).FirstOrDefault

        End Function
        Public Function LoadByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveRoom)

            LoadByUserCode = (From ChatActiveRoom In DbContext.ChatActiveRooms
                              Where ChatActiveRoom.StartedByUserCode = UserCode OrElse ChatActiveRoom.IsPrivate = False
                              Select ChatActiveRoom)

        End Function
        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatActiveRoom)

        '    Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ChatActiveRoom)()

        'End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ChatActiveRoom As AdvantageFramework.Database.Entities.ChatActiveRoom, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ChatActiveRooms.Add(ChatActiveRoom)

                ErrorMessage = ChatActiveRoom.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message.ToString()

                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatActiveRoomID As Integer) As Boolean

            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CHAT_ACTIVE_ROOM WITH(ROWLOCK) WHERE ID = {0};", ChatActiveRoomID))
                Deleted = True

            Catch ex As Exception
                AdvantageFramework.Navigation.ShowMessageBox(ex.Message.ToString())
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace
