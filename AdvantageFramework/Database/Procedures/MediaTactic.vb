Namespace Database.Procedures.MediaTactic

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

        Public Function LoadByMediaTacticID(ByVal DbContext As Database.DbContext, MediaTacticID As Integer) As AdvantageFramework.Database.Entities.MediaTactic

            LoadByMediaTacticID = (From MediaTactic In DbContext.GetQuery(Of Database.Entities.MediaTactic)
                                   Where MediaTactic.ID = MediaTacticID
                                   Select MediaTactic).SingleOrDefault

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTactic)

            LoadAllActive = From MediaTactic In DbContext.GetQuery(Of Database.Entities.MediaTactic)
                            Where MediaTactic.IsInactive = False
                            Select MediaTactic

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaTactic)

            Load = From MediaTactic In DbContext.GetQuery(Of Database.Entities.MediaTactic)
                   Select MediaTactic

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTactic As AdvantageFramework.Database.Entities.MediaTactic) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaTactics.Add(MediaTactic)

                ErrorText = MediaTactic.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTactic As AdvantageFramework.Database.Entities.MediaTactic) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaTactic)

                ErrorText = MediaTactic.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaTactic As AdvantageFramework.Database.Entities.MediaTactic) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaTactic)

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
