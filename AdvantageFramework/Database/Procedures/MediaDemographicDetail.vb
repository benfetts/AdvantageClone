Namespace Database.Procedures.MediaDemographicDetail

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

        Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.MediaDemographicDetail)

            Load = From MediaDemographicDetail In DbContext.GetQuery(Of Database.Entities.MediaDemographicDetail)
                   Select MediaDemographicDetail

        End Function

#End Region

    End Module

End Namespace
