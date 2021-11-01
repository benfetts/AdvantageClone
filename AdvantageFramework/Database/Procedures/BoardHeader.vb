Namespace Database.Procedures.BoardHeader

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

        Public Function LoadBySprintID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                       ByVal SprintID As Integer) As AdvantageFramework.Database.Entities.BoardHeader

            ''Dim ThisBoardID As Integer = 0

            ''ThisBoardID = (From SprintHeader In DbContext.GetQuery(Of Database.Entities.SprintHeader)
            ''               Where SprintHeader.ID = SprintID
            ''               Select SprintHeader.BoardHeaderID).SingleOrDefault

            ''If ThisBoardID > 0 Then

            ''    Return LoadByBoardID(DbContext, ThisBoardID)

            ''Else

            ''    Return Nothing

            ''End If
            Return Nothing

        End Function
        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardHeaderID As Integer) As AdvantageFramework.Database.Entities.BoardHeader

            LoadByBoardID = (From BoardHeader In DbContext.GetQuery(Of Database.Entities.BoardHeader)
                             Where BoardHeader.ID = BoardHeaderID
                             Select BoardHeader).SingleOrDefault

        End Function
        Public Function LoadActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardHeader)

            LoadActive = From BoardHeader In DbContext.GetQuery(Of Database.Entities.BoardHeader)
                         Where (BoardHeader.IsActive Is Nothing) Or (BoardHeader.IsActive = True)
                         Select BoardHeader

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardHeader)

            Load = From BoardHeader In DbContext.GetQuery(Of Database.Entities.BoardHeader)
                   Select BoardHeader

        End Function

        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardHeader As AdvantageFramework.Database.Entities.BoardHeader) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BoardHeaders.Add(BoardHeader)

                ErrorText = BoardHeader.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Inserted = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Inserted = False
            Finally
                Insert = Inserted
            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardHeader As AdvantageFramework.Database.Entities.BoardHeader) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BoardHeader)

                ErrorText = BoardHeader.ValidateEntity(IsValid)

                If IsValid Then

                    DbContext.SaveChanges()

                    Updated = True

                Else

                    AdvantageFramework.Navigation.ShowMessageBox(ErrorText)

                End If

            Catch ex As Exception
                Updated = False
            Finally
                Update = Updated
            End Try

        End Function
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BoardHeader As AdvantageFramework.Database.Entities.BoardHeader) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.BoardHeader.IsInUse(DataContext, BoardHeader.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.BoardHeaderRole.LoadByBoardHeaderCode(DataContext, BoardHeader.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(BoardHeader)

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
