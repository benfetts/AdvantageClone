﻿Namespace BillingCommandCenter.Database.Procedures.ProductionJobComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingCommandCenterID As Integer) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ProductionJob)

            'objects
            Dim BillingCommandCenterIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingCommandCenterIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bcc_id_in", BillingCommandCenterID)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.ProductionJob)("BCCObjectContextConnection.LoadProductionJobs", BillingCommandCenterIDObjectParameter)

        End Function

#End Region

    End Module

End Namespace
