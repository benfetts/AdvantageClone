Namespace Database.Procedures.MediaSpecsDetail

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

        Public Function LoadBySpecIDLabelIDandMediaType(ByVal DbContext As Database.DbContext, ByVal SpecID As Integer, ByVal LabelID As String, ByVal MediaType As String) As Database.Entities.MediaSpecsDetail

            Try

                LoadBySpecIDLabelIDandMediaType = (From MediaSpecsDetail In DbContext.GetQuery(Of Database.Entities.MediaSpecsDetail)
                                                   Where MediaSpecsDetail.SpecID = SpecID AndAlso
                                                         MediaSpecsDetail.LabelID = LabelID AndAlso
                                                         MediaSpecsDetail.MediaType = MediaType
                                                   Select MediaSpecsDetail).SingleOrDefault

            Catch ex As Exception
                LoadBySpecIDLabelIDandMediaType = Nothing
            End Try

        End Function
        Public Function LoadBySpecID(ByVal DbContext As Database.DbContext, ByVal SpecID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpecsDetail)

            LoadBySpecID = From MediaSpecsDetail In DbContext.GetQuery(Of Database.Entities.MediaSpecsDetail)
                           Where MediaSpecsDetail.SpecID = SpecID
                           Select MediaSpecsDetail

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaSpecsDetail)

            Load = From MediaSpecsDetail In DbContext.GetQuery(Of Database.Entities.MediaSpecsDetail)
                   Select MediaSpecsDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.MediaSpecsDetails.Add(MediaSpecsDetail)

                ErrorText = MediaSpecsDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(MediaSpecsDetail)

                ErrorText = MediaSpecsDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal MediaSpecsDetail As AdvantageFramework.Database.Entities.MediaSpecsDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(MediaSpecsDetail)

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
