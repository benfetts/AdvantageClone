Namespace Database.Procedures.EstimateRevision

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.EstimateRevision)

            Load = From EstimateRevision In DbContext.GetQuery(Of Database.Entities.EstimateRevision)
                   Select EstimateRevision

        End Function

#End Region

    End Module

End Namespace
