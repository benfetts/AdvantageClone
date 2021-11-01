Namespace BillingCommandCenter.Database.Procedures.BillingStatusComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingUser As String) As Database.Classes.BillingStatus

            Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.BillingStatus)(String.Format("exec dbo.advsp_get_billing_status '{0}'", BillingUser)).FirstOrDefault

        End Function

#End Region

    End Module

End Namespace
