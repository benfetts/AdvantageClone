Namespace BillingCommandCenter.Database.Procedures.ProductionSelectionByClientComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingCommandCenterID As Integer,
                             ByVal BillApprovalBatchID As Nullable(Of Integer)) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ProductionSelectionByClient)

            'objects
            Dim BillingCommandCenterIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim BillApprovalBatchIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingCommandCenterIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bcc_id_in", BillingCommandCenterID)
            BillApprovalBatchIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ba_batch_id", If(BillApprovalBatchID Is Nothing, DBNull.Value, BillApprovalBatchID))

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.ProductionSelectionByClient)("BCCObjectContextConnection.LoadProductionSelectionByClients", BillingCommandCenterIDObjectParameter, BillApprovalBatchIDObjectParameter)

        End Function

#End Region

    End Module

End Namespace
