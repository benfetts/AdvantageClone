Namespace Database.Procedures.JobTrafficTemplate

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficTemplate)

            Load = From JobTrafficTemplate In DbContext.GetQuery(Of Database.Entities.JobTrafficTemplate)
                   Select JobTrafficTemplate

        End Function
        Public Function LoadAllActive(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTrafficTemplate)

            LoadAllActive = From JobTrafficTemplate In DbContext.GetQuery(Of Database.Entities.JobTrafficTemplate)
                            Where JobTrafficTemplate.IsInactive Is Nothing Or JobTrafficTemplate.IsInactive = 0
                            Select JobTrafficTemplate

        End Function
        Public Function LoadByJobTrafficTemplateID(ByVal DbContext As Database.DbContext, ByVal TemplateID As Integer) As Database.Entities.JobTrafficTemplate

            LoadByJobTrafficTemplateID = (From JobTrafficTemplate In DbContext.GetQuery(Of Database.Entities.JobTrafficTemplate)
                                          Where JobTrafficTemplate.ID = TemplateID
                                          Select JobTrafficTemplate).SingleOrDefault

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, JobTrafficTemplate As Database.Entities.JobTrafficTemplate) As Boolean

            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If JobTrafficTemplate.IsEntityBeingAdded() = True Then

                    DbContext.JobTrafficTemplates.Add(JobTrafficTemplate)
                    ErrorText = JobTrafficTemplate.ValidateEntity(IsValid)

                    If IsValid = True Then

                        DbContext.SaveChanges()
                        Inserted = True

                    Else

                        AdvantageFramework.Navigation.ShowMessageBox(ErrorText)
                    End If

                End If

            Catch ex As Exception

                Inserted = False

            Finally

                Insert = Inserted

            End Try

        End Function
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficTemplate As AdvantageFramework.Database.Entities.JobTrafficTemplate) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTrafficTemplate)

                ErrorText = JobTrafficTemplate.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobTrafficTemplate As AdvantageFramework.Database.Entities.JobTrafficTemplate) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If IsValid Then

                    DbContext.DeleteEntityObject(JobTrafficTemplate)

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
