Namespace Database.Procedures.ChatRoom

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

        Public Function LoadSavedRoomNameCount(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoomName As String) As Integer

            LoadSavedRoomNameCount = (From ChatRoom In DbContext.ChatRooms
                                      Where ChatRoom.Name = RoomName AndAlso ChatRoom.IsSaved = True).Count

        End Function
        Public Function LoadRoomNameCount(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoomName As String) As Integer

            LoadRoomNameCount = (From ChatRoom In DbContext.ChatRooms
                                 Where ChatRoom.Name = RoomName).Count

        End Function
        Public Function LoadActiveRooms(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As Collections.Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            Dim list As Collections.Generic.List(Of AdvantageFramework.Database.Entities.ChatRoom)

            list = (From ChatRoom In DbContext.ChatRooms
                    Join ChatUser In DbContext.ChatUsers On ChatRoom.ID Equals ChatUser.ChatRoomID
                    Where (ChatRoom.IsActive = True AndAlso ChatRoom.IsPrivate = False) OrElse
                          (ChatRoom.IsActive = True AndAlso ChatRoom.IsPrivate = True AndAlso (ChatRoom.StartedByUserCode = UserCode OrElse ChatUser.UserCode = UserCode))
                    Order By ChatRoom.Name
                    Select ChatRoom).Distinct.ToList

            LoadActiveRooms = list

        End Function
        Public Function LoadActiveByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            Try

                LoadActiveByUserCode = (From ChatRoom In DbContext.ChatRooms
                                        Where (ChatRoom.IsActive = True AndAlso ChatRoom.IsPrivate = False) OrElse (ChatRoom.IsActive = True AndAlso ChatRoom.StartedByUserCode = UserCode)
                                        Order By ChatRoom.Name
                                        Select ChatRoom).Distinct

            Catch ex As Exception
                LoadActiveByUserCode = Nothing
            End Try

        End Function
        Public Function LoadActiveByRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoomID As String) As AdvantageFramework.Database.Entities.ChatRoom

            LoadActiveByRoomID = (From ChatRoom In DbContext.ChatRooms
                                  Where ChatRoom.IsActive = True AndAlso ChatRoom.RoomID = RoomID
                                  Order By ChatRoom.Name
                                  Select ChatRoom).FirstOrDefault


        End Function

        Public Function LoadByJobNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            LoadByJobNumber = (From ChatRoom In DbContext.ChatRooms
                               Where ChatRoom.JobNumber = JobNumber
                               Order By ChatRoom.CreateDate Descending
                               Select ChatRoom)

        End Function
        Public Function LoadByJobAndComponentNumber(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Short) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            LoadByJobAndComponentNumber = (From ChatRoom In DbContext.ChatRooms
                                           Where ChatRoom.JobNumber = JobNumber AndAlso ChatRoom.JobComponentNumber = JobComponentNumber
                                           Order By ChatRoom.CreateDate Descending
                                           Select ChatRoom)

        End Function

        Public Function LoadParticipatedIn(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            LoadParticipatedIn = (From ChatRoom In DbContext.ChatRooms
                                  Join ChatUser In DbContext.ChatUsers
                                  On ChatRoom.ID Equals ChatUser.ChatRoomID
                                  Where ChatUser.UserCode = UserCode AndAlso ChatRoom.StartedByUserCode <> UserCode
                                  Order By ChatRoom.CreateDate Descending
                                  Select ChatRoom).Distinct

        End Function
        Public Function LoadByStartedByUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal UserCode As String) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            LoadByStartedByUserCode = (From ChatRoom In DbContext.ChatRooms
                                       Where ChatRoom.StartedByUserCode = UserCode
                                       Order By ChatRoom.CreateDate Descending
                                       Select ChatRoom)

        End Function
        Public Function LoadByRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal RoomID As String) As AdvantageFramework.Database.Entities.ChatRoom

            LoadByRoomID = (From ChatRoom In Load(DbContext)
                            Where ChatRoom.RoomID = RoomID
                            Select ChatRoom).FirstOrDefault

        End Function
        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.ChatRoom

            LoadByID = (From ChatRoom In Load(DbContext)
                        Where ChatRoom.ID = ID
                        Select ChatRoom).FirstOrDefault

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatRoom)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ChatRoom)()

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ChatRoom As AdvantageFramework.Database.Entities.ChatRoom, ByRef ErrorMessage As String) As Boolean

            ChatRoom.RoomID = Guid.NewGuid().ToString().GetHashCode().ToString("x")
            ChatRoom.CreateDate = DateTime.Now
            If String.IsNullOrWhiteSpace(ChatRoom.Name) = True Then

                ChatRoom.Name = DbContext.UserCode & "_" & ChatRoom.RoomID & "_" & ChatRoom.CreateDate

            End If

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ChatRooms.Add(ChatRoom)

                ErrorMessage = ChatRoom.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByRef ChatRoom As AdvantageFramework.Database.Entities.ChatRoom, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.Entry(ChatRoom).State = Entity.EntityState.Modified

                ErrorMessage = ChatRoom.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                End If

            Catch ex As Exception

                Updated = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    ErrorMessage &= System.Environment.NewLine & System.Environment.NewLine & ex.InnerException.Message

                End If

            Finally
                Update = Updated
            End Try

        End Function
        'Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoom As AdvantageFramework.Database.Entities.ChatRoom) As Boolean

        '    Dim Deleted As Boolean = False
        '    Dim IsValid As Boolean = True
        '    Dim ErrorText As String = ""

        '    Try

        '        If IsValid Then

        '            DbContext.Entry(ChatRoom).State = Entity.EntityState.Deleted

        '            DbContext.SaveChanges()

        '            Deleted = True

        '        Else

        '            AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

        '        End If

        '    Catch ex As Exception
        '        Deleted = False
        '    Finally
        '        Delete = Deleted
        '    End Try

        'End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As Boolean

            Dim Deleted As Boolean = False

            Try

                DbContext.Database.ExecuteSqlCommand(String.Format("DELETE FROM CHAT_MESSAGE WITH(ROWLOCK) WHERE CHAT_ROOM_ID = {0};DELETE FROM CHAT_USER WITH(ROWLOCK) WHERE CHAT_ROOM_ID = {0};DELETE FROM CHAT_ROOM WITH(ROWLOCK) WHERE ID = {0};", ChatRoomID))
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
