Namespace Database.Procedures.AgencyComment

    <HideModuleName()> _
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

        Public Function LoadByCommentType(ByVal DbContext As Database.DbContext, ByVal AgencyCommentType As AdvantageFramework.Database.Entities.AgencyCommentTypes) As Database.Entities.AgencyComment

            Try

                Select Case AgencyCommentType

                    Case Entities.AgencyCommentTypes.AUTO_AR_STATEMENT

                        LoadByCommentType = (From AgencyComment In DbContext.GetQuery(Of Database.Entities.AgencyComment)
                                             Where AgencyComment.Type = "AUTO_AR_STATEMENT"
                                             Select AgencyComment).FirstOrDefault

                    Case Else

                        LoadByCommentType = Nothing

                End Select

            Catch ex As Exception
                LoadByCommentType = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AgencyComment)

            Load = From AgencyComment In DbContext.GetQuery(Of Database.Entities.AgencyComment)
                   Select AgencyComment

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyComment As AdvantageFramework.Database.Entities.AgencyComment) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.AgencyComments.Add(AgencyComment)

                ErrorText = AgencyComment.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyComment As AdvantageFramework.Database.Entities.AgencyComment) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(AgencyComment)

                ErrorText = AgencyComment.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal AgencyComment As AdvantageFramework.Database.Entities.AgencyComment) As Boolean

            'objects
            Dim Deleted As Boolean = True
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(AgencyComment)

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
