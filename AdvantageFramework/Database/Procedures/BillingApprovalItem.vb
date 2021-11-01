Namespace Database.Procedures.BillingApprovalItem

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

        Public Function Load(ByVal DbContext As AdvantageFramework.Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of AdvantageFramework.Database.Entities.BillingApprovalItem)

            Load = DbContext.Set(Of AdvantageFramework.Database.Entities.BillingApprovalItem)()

        End Function

#End Region

    End Module

End Namespace
