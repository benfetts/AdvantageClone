Namespace Database.Procedures.JobTrafficSetupDetail

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

        Public Function LoadByHeaderCodeAndColumnID(ByVal DbContext As Database.DbContext, ByVal HeaderCode As String, ByVal ColumnID As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficSetupDetail)

            LoadByHeaderCodeAndColumnID = From JobTrafficSetupDetail In DbContext.GetQuery(Of Database.Entities.JobTrafficSetupDetail)
                                          Where JobTrafficSetupDetail.HeaderCode = HeaderCode AndAlso
                                                JobTrafficSetupDetail.ColumnID = ColumnID
                                          Select JobTrafficSetupDetail

        End Function
        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.JobTrafficSetupDetail

            Try

                LoadByID = (From JobTrafficSetupDetail In DbContext.GetQuery(Of Database.Entities.JobTrafficSetupDetail)
                            Where JobTrafficSetupDetail.ID = ID
                            Select JobTrafficSetupDetail).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficSetupDetail)

            Load = From JobTrafficSetupDetail In DbContext.GetQuery(Of Database.Entities.JobTrafficSetupDetail)
                   Select JobTrafficSetupDetail

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficSetupDetail As AdvantageFramework.Database.Entities.JobTrafficSetupDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTrafficSetupDetails.Add(JobTrafficSetupDetail)

                ErrorText = JobTrafficSetupDetail.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficSetupDetail As AdvantageFramework.Database.Entities.JobTrafficSetupDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTrafficSetupDetail)

                ErrorText = JobTrafficSetupDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficSetupDetail As AdvantageFramework.Database.Entities.JobTrafficSetupDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobTrafficSetupDetail)

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
