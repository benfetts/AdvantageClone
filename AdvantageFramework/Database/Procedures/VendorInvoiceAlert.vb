Namespace Database.Procedures.VendorInvoiceAlert

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

        Public Function Load(ByVal DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Views.VendorInvoiceAlert)

            Load = From VendorInvoiceAlert In DbContext.GetQuery(Of Database.Views.VendorInvoiceAlert)
                   Select VendorInvoiceAlert

        End Function

#End Region

    End Module

End Namespace
