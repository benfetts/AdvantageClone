Namespace ViewModels.Maintenance.Accounting

	Public Class VendorInvoiceCategorySetupViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

		Public Property IsNewRow As Boolean
		Public Property SaveEnabled As Boolean
		Public Property DeleteEnabled As Boolean
		Public Property CancelEnabled As Boolean

		Public ReadOnly Property HasASelectedVendorInvoiceCategory As Boolean
			Get
				HasASelectedVendorInvoiceCategory = (Me.SelectedVendorInvoiceCategory IsNot Nothing)
			End Get
		End Property

		Public Property VendorInvoiceCategories As Generic.List(Of AdvantageFramework.DTO.VendorInvoiceCategory)
		Public Property SelectedVendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory

#End Region

#Region " Methods "

		Public Sub New()

			Me.IsNewRow = False
			Me.SaveEnabled = False
			Me.DeleteEnabled = False
			Me.CancelEnabled = False

			Me.VendorInvoiceCategories = New Generic.List(Of AdvantageFramework.DTO.VendorInvoiceCategory)
			Me.SelectedVendorInvoiceCategory = Nothing

		End Sub

#End Region

	End Class

End Namespace
