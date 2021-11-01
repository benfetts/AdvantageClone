Namespace Database.Procedures.JobServiceFee

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

        Public Function LoadByID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal ID As Integer) As AdvantageFramework.Database.Entities.JobServiceFee

            LoadByID = (From JobServiceFee In DbContext.GetQuery(Of Database.Entities.JobServiceFee)
                        Where JobServiceFee.ID = ID
                        Select JobServiceFee).SingleOrDefault

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobServiceFee)

            Load = From JobServiceFee In DbContext.GetQuery(Of Database.Entities.JobServiceFee)
                   Select JobServiceFee

        End Function
        Public Function LoadByJobComponent(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobServiceFee)

            LoadByJobComponent = From JobServiceFee In DbContext.GetQuery(Of Database.Entities.JobServiceFee)
                                 Where JobServiceFee.JobNumber = JobNumber AndAlso
                                       JobServiceFee.JobComponentNumber = JobComponentNumber
                                 Select JobServiceFee

        End Function
        Public Function Insert(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobServiceFees.Add(JobServiceFee)

                ErrorText = JobServiceFee.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobServiceFee)

                ErrorText = JobServiceFee.ValidateEntity(IsValid)

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
        Public Function Delete(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobServiceFee As AdvantageFramework.Database.Entities.JobServiceFee) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                If (From Entity In AdvantageFramework.Database.Procedures.IncomeOnly.Load(DbContext) _
                    Where Entity.JobServiceFeeID = JobServiceFee.ID _
                    Select Entity).Any Then

                    IsValid = False
                    ErrorText = "Contract is in use and cannot be deleted."

                End If

                If IsValid Then

                    DbContext.DeleteEntityObject(JobServiceFee)

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
