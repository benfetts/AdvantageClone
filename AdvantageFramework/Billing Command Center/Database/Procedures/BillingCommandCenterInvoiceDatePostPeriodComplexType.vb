Namespace BillingCommandCenter.Database.Procedures.BillingCommandCenterInvoiceDatePostPeriodComplexType

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

        Public Function Load(ByVal BCCDbContext As Database.DbContext, ByVal BillingUserCode As String) As Database.Classes.BillingCommandCenterInvoiceDatePostPeriod

            'objects
            Dim BillingCommandCenterUserCodeObjectParameter As System.Data.Entity.Core.Objects.ObjectParameter = Nothing

            BillingCommandCenterUserCodeObjectParameter = New System.Data.Entity.Core.Objects.ObjectParameter("billing_user", BillingUserCode)

            Try

                Load = BCCDbContext.Database.SqlQuery(Of Database.Classes.BillingCommandCenterInvoiceDatePostPeriod)("BCCObjectContextConnection.LoadBillingCommandCenterInvoiceDatePostPeriod", BillingCommandCenterUserCodeObjectParameter).SingleOrDefault

            Catch ex As Exception
                Load = Nothing
            End Try

        End Function

#End Region

    End Module

End Namespace
