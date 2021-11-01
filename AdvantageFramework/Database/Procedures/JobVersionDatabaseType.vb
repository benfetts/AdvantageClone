Namespace Database.Procedures.JobVersionDatabaseType

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

        Public Function LoadByJobVersionDatabaseTypeID(ByVal DbContext As AdvantageFramework.Database.DbContext, ByVal JobVersionDatabaseTypeID As Long) As AdvantageFramework.Database.Entities.JobVersionDatabaseType

            Try

                LoadByJobVersionDatabaseTypeID = (From JobVersionDatabaseType In DbContext.GetQuery(Of Database.Entities.JobVersionDatabaseType)
                                                  Where JobVersionDatabaseType.ID = JobVersionDatabaseTypeID
                                                  Select JobVersionDatabaseType).SingleOrDefault

            Catch ex As Exception
                LoadByJobVersionDatabaseTypeID = Nothing
            End Try

        End Function
        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.JobVersionDatabaseType)

            Load = From JobVersionDatabaseType In DbContext.GetQuery(Of Database.Entities.JobVersionDatabaseType)
                   Order By JobVersionDatabaseType.Description
                   Select JobVersionDatabaseType

        End Function

#End Region

    End Module

End Namespace
