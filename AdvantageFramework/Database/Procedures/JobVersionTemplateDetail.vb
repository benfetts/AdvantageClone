Namespace Database.Procedures.JobVersionTemplateDetail

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

        Public Function LoadByJobVersionTemplateCode(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateCode As String) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            LoadByJobVersionTemplateCode = From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                                           Where JobVersionTemplateDetail.JobVersionTemplateCode = JobVersionTemplateCode
                                           Select JobVersionTemplateDetail

        End Function
        Public Function LoadAllActive(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            LoadAllActive = From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                            Where JobVersionTemplateDetail.IsInactive = 0 OrElse
                                  JobVersionTemplateDetail.IsInactive Is Nothing
                            Select JobVersionTemplateDetail

        End Function
        Public Function LoadByJobVersionTemplateDetailID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateDetailID As Long) As AdvantageFramework.Database.Entities.JobVersionTemplateDetail

            Try

                LoadByJobVersionTemplateDetailID = (From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                                                    Where JobVersionTemplateDetail.ID = JobVersionTemplateDetailID
                                                    Select JobVersionTemplateDetail).SingleOrDefault

            Catch ex As Exception
                LoadByJobVersionTemplateDetailID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail)

            Load = From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                   Select JobVersionTemplateDetail

        End Function
        Public Function LoadByJobVersionTemplateCodeAndFieldName(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateCode As String, ByVal FieldName As String) As AdvantageFramework.Database.Entities.JobVersionTemplateDetail

            Try
                LoadByJobVersionTemplateCodeAndFieldName = (From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                                                            Where JobVersionTemplateDetail.JobVersionTemplateCode = JobVersionTemplateCode And
                                                            JobVersionTemplateDetail.Label = FieldName
                                                            Select JobVersionTemplateDetail).SingleOrDefault
            Catch ex As Exception
                LoadByJobVersionTemplateCodeAndFieldName = Nothing
            End Try


        End Function

        Public Function LoadByJobVersionTemplateCodeAndMapping(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateCode As String, ByVal Mapping As String, ByVal currentRowID As Integer) As AdvantageFramework.Database.Entities.JobVersionTemplateDetail

            Try
                LoadByJobVersionTemplateCodeAndMapping = (From JobVersionTemplateDetail In DbContext.GetQuery(Of Database.Entities.JobVersionTemplateDetail)
                                                          Where JobVersionTemplateDetail.JobVersionTemplateCode = JobVersionTemplateCode And
                                                                JobVersionTemplateDetail.JobTemplateMapping = Mapping And
                                                                JobVersionTemplateDetail.ID <> currentRowID
                                                          Select JobVersionTemplateDetail).SingleOrDefault
            Catch ex As Exception
                LoadByJobVersionTemplateCodeAndMapping = Nothing
            End Try


        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobVersionTemplateDetails.Add(JobVersionTemplateDetail)

                ErrorText = JobVersionTemplateDetail.ValidateEntity(IsValid)

                If IsValid Then

                    If JobVersionTemplateDetail.OrderNumber = 0 Then

                        If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail).Where(Function(TemplateDetail) TemplateDetail.JobVersionTemplateCode = JobVersionTemplateDetail.JobVersionTemplateCode AndAlso
                                                                                                                                               TemplateDetail.OrderNumber = JobVersionTemplateDetail.OrderNumber).Any Then

                            JobVersionTemplateDetail.OrderNumber = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.JobVersionTemplateDetail).Where(Function(TemplateDetail) TemplateDetail.JobVersionTemplateCode = JobVersionTemplateDetail.JobVersionTemplateCode).
                                                                                                                                                        Select(Function(TemplateDetail) TemplateDetail.OrderNumber).Max + 1

                        End If

                    End If

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobVersionTemplateDetail)

                ErrorText = JobVersionTemplateDetail.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal DataContext As AdvantageFramework.Database.DataContext, ByVal JobVersionTemplateDetail As AdvantageFramework.Database.Entities.JobVersionTemplateDetail) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Dim JobVersionTemplateDetailListValue As AdvantageFramework.Database.Entities.JobVersionTemplateDetailListValue = Nothing

            Try

                If DbContext.Database.SqlQuery(Of Integer)(String.Format("SELECT COUNT(*) FROM JOB_VER_DTL WHERE JV_TMPLT_DTL_ID ={0}", JobVersionTemplateDetail.ID)).FirstOrDefault > 0 Then

                    ErrorText = "The job version template detail is in use and cannot be deleted."
                    IsValid = False

                End If

                If IsValid Then

                    If (From Entity In DbContext.GetQuery(Of Database.Entities.JobVersionDatabaseType)
                        Where Entity.IsList = 1 AndAlso
                              Entity.ID = JobVersionTemplateDetail.DatabaseTypeID
                        Select Entity).Any Then

                        For Each JobVersionTemplateDetailListValue In AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.LoadByJobVersionTemplateDetailID(DataContext, JobVersionTemplateDetail.ID)

                            If AdvantageFramework.Database.Procedures.JobVersionTemplateDetailListValue.Delete(DataContext, JobVersionTemplateDetailListValue) = False Then

                                ErrorText = "Problem deleting job version template detail."
                                IsValid = False

                            End If

                        Next

                    End If

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(JobVersionTemplateDetail)

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

