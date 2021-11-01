Namespace BillingCommandCenter.Database.Procedures.ProductionSelectionByJobComponentComplexType

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
                             ByVal BillApprovalBatchID As Nullable(Of Integer), ByVal BillingUserCode As String) As System.Data.Entity.Infrastructure.DbRawSqlQuery(Of Database.Classes.ProductionSelectionByJobComponent)

            'objects
            Dim BillingCommandCenterIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim BillApprovalBatchIDObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing
            Dim BillUserObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingCommandCenterIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bcc_id_in", BillingCommandCenterID)
            BillApprovalBatchIDObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("ba_batch_id_in", If(BillApprovalBatchID Is Nothing, DBNull.Value, BillApprovalBatchID))
            BillUserObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("bill_user_in", BillingUserCode)

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.ProductionSelectionByJobComponent)("BCCObjectContextConnection.LoadProductionSelectionByJobComponents", BillingCommandCenterIDObjectParameter, BillApprovalBatchIDObjectParameter, BillUserObjectParameter)

        End Function

#End Region

    End Module

End Namespace
