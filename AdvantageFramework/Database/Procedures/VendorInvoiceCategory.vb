Namespace Database.Procedures.VendorInvoiceCategory

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

		Public Function LoadByVendorInvoiceCategoryID(DbContext As Database.DbContext, VendorInvoiceCategoryID As Integer) As Database.Entities.VendorInvoiceCategory

			LoadByVendorInvoiceCategoryID = (From VendorInvoiceCategory In DbContext.GetQuery(Of Database.Entities.VendorInvoiceCategory)
											 Where VendorInvoiceCategory.ID = VendorInvoiceCategoryID
											 Select VendorInvoiceCategory).SingleOrDefault

		End Function
		Public Function Load(DbContext As Database.DbContext) As System.Data.Entity.Infrastructure.DbQuery(Of Database.Entities.VendorInvoiceCategory)

			Load = From VendorInvoiceCategory In DbContext.GetQuery(Of Database.Entities.VendorInvoiceCategory)
				   Select VendorInvoiceCategory

		End Function

#End Region

	End Module

End Namespace
