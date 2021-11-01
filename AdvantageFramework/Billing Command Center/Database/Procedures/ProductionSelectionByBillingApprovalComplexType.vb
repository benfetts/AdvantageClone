Namespace BillingCommandCenter.Database.Procedures.ProductionSelectionByBillingApprovalComplexType

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
                             ByVal BillApprovalBatchID As Nullable(Of Integer),
                             ByVal Finished As Boolean) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ProductionSelectionByBillingApproval)

            'objects
            Dim BillingCommandCenterIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim BillApprovalBatchIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim FinishedObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingCommandCenterIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bcc_id_in", BillingCommandCenterID)
            BillApprovalBatchIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ba_batch_id_in", If(BillApprovalBatchID Is Nothing, DBNull.Value, BillApprovalBatchID))
            FinishedObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("finished", If(Finished, 1, 0))

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.ProductionSelectionByBillingApproval)("BCCObjectContextConnection.LoadProductionSelectionByBillingApprovals", BillingCommandCenterIDObjectParameter, BillApprovalBatchIDObjectParameter, FinishedObjectParameter)

        End Function

#End Region

    End Module

End Namespace
