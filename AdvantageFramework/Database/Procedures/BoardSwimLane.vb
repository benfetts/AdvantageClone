Namespace Database.Procedures.BoardSwimLane

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

        Public Function LoadByBoardID(ByVal DbContext As AdvantageFramework.Database.DbContext,
                                      ByVal BoardID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardSwimLane)

            ''''LoadByBoardID = From BoardSwimLane In DbContext.GetQuery(Of Database.Entities.BoardSwimLane)
            ''''                Where BoardSwimLane.BoardHeaderID = BoardID
            ''''                Select BoardSwimLane
            Return Nothing
        End Function
        'Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BoardSwimLane)

        '    Load = From BoardSwimLane In DbContext.GetQuery(Of Database.Entities.BoardSwimLane)
        '           Select BoardSwimLane

        'End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardSwimLane As AdvantageFramework.Database.Entities.BoardSwimLane) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.BoardSwimLanes.Add(BoardSwimLane)

                ErrorText = BoardSwimLane.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal BoardSwimLane As AdvantageFramework.Database.Entities.BoardSwimLane) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(BoardSwimLane)

                ErrorText = BoardSwimLane.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal BoardSwimLane As AdvantageFramework.Database.Entities.BoardSwimLane) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                'If AdvantageFramework.Database.Procedures.BoardSwimLane.IsInUse(DataContext, BoardSwimLane.Code) = True OrElse
                '       AdvantageFramework.Database.Procedures.BoardSwimLaneRole.LoadByBoardSwimLaneCode(DataContext, BoardSwimLane.Code).Count > 0 Then

                '    ErrorText = "The task is in use and cannot be deleted."
                '    IsValid = False

                'End If

                If IsValid Then

                    DbContext.DeleteEntityObject(BoardSwimLane)

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
