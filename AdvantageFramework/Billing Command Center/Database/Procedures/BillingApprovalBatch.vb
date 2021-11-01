Namespace BillingCommandCenter.Database.Procedures.BillingApprovalBatch

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

        Public Function LoadByID(ByVal BCCDbContext As Database.DbContext, ByVal ID As Integer) As Database.Entities.BillingApprovalBatch

            Try

                LoadByID = (From BillingApprovalBatch In BCCDbContext.GetQuery(Of Database.Entities.BillingApprovalBatch)
                            Where BillingApprovalBatch.ID = ID
                            Select BillingApprovalBatch).SingleOrDefault

            Catch ex As Exception
                LoadByID = Nothing
            End Try

        End Function
        Public Function Load(ByVal BCCDbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.BillingApprovalBatch)

            Load = From BillingApprovalBatch In BCCDbContext.GetQuery(Of Database.Entities.BillingApprovalBatch)
                   Select BillingApprovalBatch

        End Function

#End Region

    End Module

End Namespace
