Namespace Database.Procedures.ChatMessage

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

        Public Function LoadByChatRoomID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer, ByVal HideSystemMessages As Boolean) As IEnumerable(Of AdvantageFramework.Database.Classes.ChatMessage)

            LoadByChatRoomID = DbContext.Database.SqlQuery(Of AdvantageFramework.Database.Classes.ChatMessage)(String.Format("EXEC [dbo].[advsp_chat_load_message_by_chat_room_id] {0}, {1};", ChatRoomID.ToString(), If(HideSystemMessages = True, 1, 0)))

        End Function
        Public Function LoadByChatRoomIDWithoutSystemMessages(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatRoomID As Integer) As IQueryable(Of AdvantageFramework.Database.Entities.ChatMessage)

            LoadByChatRoomIDWithoutSystemMessages = (From ChatMessage In DbContext.ChatMessages
                                                     Where ChatMessage.ChatRoomID = ChatRoomID AndAlso ChatMessage.IsSystemMessage = False
                                                     Select ChatMessage)

        End Function
        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As IQueryable(Of AdvantageFramework.Database.Entities.ChatMessage)

        '    Load = DbContext.Set(Of AdvantageFramework.Database.Entities.ChatMessage)()

        'End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatMessage As AdvantageFramework.Database.Entities.ChatMessage, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True

            Try

                DbContext.ChatMessages.Add(ChatMessage)

                ErrorMessage = ChatMessage.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                End If

            Catch ex As Exception

                Inserted = False

                ErrorMessage = ex.Message

                If ex.InnerException IsNot Nothing Then

                    Dim InnerMessage As String = ex.InnerException.Message.ToString()

                    If ErrorMessage = InnerMessage AndAlso ex.InnerException.InnerException IsNot Nothing Then

                        ErrorMessage &= ex.InnerException.InnerException.Message.ToString()

                    Else

                        ErrorMessage &= ex.InnerException.Message.ToString()

                    End If


                End If

            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ChatMessage As AdvantageFramework.Database.Entities.ChatMessage) As Boolean

            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.Entry(ChatMessage).State = Entity.EntityState.Deleted

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