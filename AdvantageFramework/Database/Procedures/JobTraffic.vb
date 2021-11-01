Namespace Database.Procedures.JobTraffic

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

        Public Function LoadByID(ByVal DbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.JobTraffic

            Try

                LoadByID = (From JobTraffic In DbContext.JobTraffic
                            Where JobTraffic.RowID = ID
                            Select JobTraffic).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.JobTraffic)

            Load = From JobTraffic In DbContext.JobTraffic
                   Select JobTraffic

        End Function
        Public Function LoadByJobNumberAndJobComponentNumber(ByVal DbContext As Database.DbContext, ByVal JobNumber As Integer, ByVal JobComponentNumber As Integer) As AdvantageFramework.Database.Entities.JobTraffic

            LoadByJobNumberAndJobComponentNumber = (From JobTraffic In DbContext.JobTraffic
                                                    Where JobTraffic.JobNumber = JobNumber AndAlso JobTraffic.JobComponentNumber = JobComponentNumber
                                                    Select JobTraffic).FirstOrDefault()

        End Function
        Public Function Insert(ByVal DbContext As Database.DbContext, ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic) As Boolean

            'objects
            Dim Inserted As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.JobTraffic.Add(JobTraffic)

                ErrorText = JobTraffic.ValidateEntity(IsValid)

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
        Public Function Update(ByVal DbContext As Database.DbContext, ByVal JobTraffic As AdvantageFramework.Database.Entities.JobTraffic) As Boolean

            'objects
            Dim Updated As Boolean = False
            Dim IsValid As Boolean = True
            Dim ErrorText As String = ""

            Try

                DbContext.UpdateObject(JobTraffic)

                ErrorText = JobTraffic.ValidateEntity(IsValid)

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

#End Region

    End Module

End Namespace
