Namespace Database.Procedures.AccountPayablePayment

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

        Public Function Load1099InvoicePaymentsByCheckRegisterDate(ByVal DbContext As Database.DbContext, ByVal StartDate As Date, ByVal EndDate As Date, ByVal AccountPayable1099IDs As IEnumerable(Of Integer)) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayablePayment)

            Load1099InvoicePaymentsByCheckRegisterDate = From AccountPayablePayment In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.AccountPayablePayment).Include("CheckRegister")
                                                         Where AccountPayable1099IDs.Contains(AccountPayablePayment.AccountPayableID) AndAlso
                                                               AccountPayablePayment.CheckDate >= StartDate AndAlso
                                                               AccountPayablePayment.CheckDate <= EndDate AndAlso
                                                               (AccountPayablePayment.CheckRegister.IsVoid Is Nothing OrElse
                                                                AccountPayablePayment.CheckRegister.IsVoid = 0)
                                                         Select AccountPayablePayment

        End Function
        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.AccountPayablePayment)

            Load = From AccountPayablePayment In DbContext.GetQuery(Of Database.Entities.AccountPayablePayment)
                   Select AccountPayablePayment

        End Function

#End Region

    End Module

End Namespace
