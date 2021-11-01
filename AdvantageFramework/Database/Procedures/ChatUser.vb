Namespace Database.Procedures.ChatUser

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

        Public Function LoadActiveContextUserIdentityNameByChatRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As List(Of String)

            LoadActiveContextUserIdentityNameByChatRoomID = (From ChatUser In DbContext.ChatUsers
                                                             Join ChatActiveUser In DbContext.ChatActiveUsers On ChatUser.UserCode Equals ChatActiveUser.UserCode
                                                             Where ChatUser.ChatRoomID = ChatRoomID AndAlso ChatActiveUser.DoNotDisturb = False
                                                             Select ChatActiveUser.ContextUserIdentityName).ToList

        End Function

        Public Function LoadActiveByChatRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ChatUser)

            LoadActiveByChatRoomID = (From ChatUser In DbContext.ChatUsers
                                      Join ChatActiveUser In DbContext.ChatActiveUsers On ChatUser.UserCode Equals ChatActiveUser.UserCode
                                      Where ChatUser.ChatRoomID = ChatRoomID AndAlso ChatActiveUser.DoNotDisturb = False
                                      Select ChatUser)

        End Function

        Public Function UserIsInRoom(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer, ByVal UserCode As String) As Boolean

            Dim Count As Integer = 0

            Count = (From ChatUser In DbContext.ChatUsers
                     Where ChatUser.ChatRoomID = ChatRoomID AndAlso ChatUser.UserCode = UserCode).Count

            UserIsInRoom = Count > 0

        End Function
        Public Function LoadByChatRoomIDAndUserCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer, ByVal UserCode As String) As AdvantageFramework.Database.Entities.ChatUser

            LoadByChatRoomIDAndUserCode = (From ChatUser In DbContext.ChatUsers
                                           Where ChatUser.ChatRoomID = ChatRoomID AndAlso ChatUser.UserCode = UserCode
                                           Select ChatUser).FirstOrDefault

        End Function
        Public Function LoadByChatRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ChatUser)

            LoadByChatRoomID = (From ChatUser In DbContext.ChatUsers
                                Where ChatUser.ChatRoomID = ChatRoomID
                                Select ChatUser)

        End Function
        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatUser)

        '    Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ChatUser)()

        'End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatUser As AdvantageFramework.Database.Entities.ChatUser, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ChatUsers.Add(ChatUser)

                ErrorMessage = ChatUser.ValidateEntity(IsValid)

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

                AdvantageFramework.Navigation.ShowMessageBox(ErrorMessage)

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatUser As AdvantageFramework.Database.Entities.ChatUser) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ChatUser).State = Entity.EntityState.Deleted

                    DbContext.SaveChanges()

                    Deleted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Deleted = False
            Finally
                Delete = Deleted
            End Try

        End Function

#End Region

    End Module

End Namespace