Namespace Controller.Maintenance.Accounting

	Public Class VendorInvoiceCategoryController
		Inherits AdvantageFramework.Controller.BaseController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "

		Public Sub New(Session As AdvantageFramework.Security.Session)

			MyBase.New(Session)

		End Sub
		Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel

			'objects
			Dim VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel = Nothing
			Dim VendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory = Nothing

			VendorInvoiceCategorySetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				DbContext.Database.Connection.Open()

				VendorInvoiceCategorySetupViewModel.VendorInvoiceCategories = AdvantageFramework.Database.Procedures.VendorInvoiceCategory.Load(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.VendorInvoiceCategory(Entity)).ToList

			End Using

			VendorInvoiceCategorySetupViewModel.IsNewRow = False
			VendorInvoiceCategorySetupViewModel.DeleteEnabled = False
			VendorInvoiceCategorySetupViewModel.CancelEnabled = False

			Load = VendorInvoiceCategorySetupViewModel

		End Function
		Public Function Add(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel,
							VendorInvoiceCategoryDTO As AdvantageFramework.DTO.VendorInvoiceCategory,
							ByRef ErrorMessage As String) As Boolean

			'objects
			Dim IsValid As Boolean = True
			Dim VendorInvoiceCategory As AdvantageFramework.Database.Entities.VendorInvoiceCategory = Nothing
			Dim Added As Boolean = False

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				VendorInvoiceCategory = New AdvantageFramework.Database.Entities.VendorInvoiceCategory

				VendorInvoiceCategory.DbContext = DbContext

				VendorInvoiceCategoryDTO.SaveToEntity(VendorInvoiceCategory)

				DbContext.VendorInvoiceCategories.Add(VendorInvoiceCategory)

				Try

					DbContext.SaveChanges()

					Added = True

					VendorInvoiceCategoryDTO.ID = VendorInvoiceCategory.ID

				Catch ex As SqlClient.SqlException
					Added = False
					ErrorMessage = ex.Message
				End Try

			End Using

			Add = Added

		End Function
		Public Function Delete(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel,
							   ByRef ErrorMessage As String) As Boolean

			'objects
			Dim Deleted As Boolean = False
			Dim VendorInvoiceCategory As AdvantageFramework.Database.Entities.VendorInvoiceCategory = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				DbContext.Database.Connection.Open()

				VendorInvoiceCategory = AdvantageFramework.Database.Procedures.VendorInvoiceCategory.LoadByVendorInvoiceCategoryID(DbContext, VendorInvoiceCategorySetupViewModel.SelectedVendorInvoiceCategory.ID)

				If VendorInvoiceCategory IsNot Nothing Then

					If AdvantageFramework.Database.Procedures.Vendor.Load(DbContext).Any(Function(Entity) Entity.VendorInvoiceCategoryID = VendorInvoiceCategory.ID) = False Then

						DbContext.DeleteEntityObject(VendorInvoiceCategory)

						DbContext.SaveChanges()

						Deleted = VendorInvoiceCategorySetupViewModel.VendorInvoiceCategories.Remove(VendorInvoiceCategorySetupViewModel.SelectedVendorInvoiceCategory)

					Else

						ErrorMessage &= System.Environment.NewLine & "This vendor invoice category is in use."

					End If

				Else

					ErrorMessage &= System.Environment.NewLine & "This vendor invoice category is no longer valid in the system."

				End If

			End Using

			Delete = Deleted

		End Function
		Public Function Save(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel) As Boolean

			'objects
			Dim Saved As Boolean = True
			Dim VendorInvoiceCategory As AdvantageFramework.Database.Entities.VendorInvoiceCategory = Nothing
			Dim VendorInvoiceCategories As Generic.List(Of AdvantageFramework.Database.Entities.VendorInvoiceCategory) = Nothing

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				DbContext.Database.Connection.Open()

				VendorInvoiceCategories = DbContext.VendorInvoiceCategories.ToList

				For Each VendorInvoiceCategoryDTO In VendorInvoiceCategorySetupViewModel.VendorInvoiceCategories

					VendorInvoiceCategory = VendorInvoiceCategories.SingleOrDefault(Function(Entity) Entity.ID = VendorInvoiceCategoryDTO.ID)

					If VendorInvoiceCategory IsNot Nothing Then

						VendorInvoiceCategoryDTO.SaveToEntity(VendorInvoiceCategory)

					End If

				Next

				DbContext.SaveChanges()

			End Using

			Save = Saved

		End Function
		Public Sub CancelNewItemRow(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel)

			VendorInvoiceCategorySetupViewModel.IsNewRow = False
			VendorInvoiceCategorySetupViewModel.CancelEnabled = False
			VendorInvoiceCategorySetupViewModel.DeleteEnabled = VendorInvoiceCategorySetupViewModel.HasASelectedVendorInvoiceCategory

		End Sub
		Public Sub SelectionChanged(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel,
									IsNewItemRow As Boolean,
									SelectedVendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory)

			VendorInvoiceCategorySetupViewModel.IsNewRow = IsNewItemRow
			VendorInvoiceCategorySetupViewModel.CancelEnabled = IsNewItemRow
			VendorInvoiceCategorySetupViewModel.DeleteEnabled = Not IsNewItemRow

			VendorInvoiceCategorySetupViewModel.SelectedVendorInvoiceCategory = SelectedVendorInvoiceCategory

			If VendorInvoiceCategorySetupViewModel.DeleteEnabled AndAlso VendorInvoiceCategorySetupViewModel.SelectedVendorInvoiceCategory Is Nothing Then

				VendorInvoiceCategorySetupViewModel.DeleteEnabled = False

			End If

		End Sub
		Public Sub InitNewRowEvent(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel)

			VendorInvoiceCategorySetupViewModel.IsNewRow = True
			VendorInvoiceCategorySetupViewModel.CancelEnabled = True
			VendorInvoiceCategorySetupViewModel.DeleteEnabled = False

		End Sub
		Public Sub UserEntryChanged(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel)

			VendorInvoiceCategorySetupViewModel.SaveEnabled = True

		End Sub
		Public Sub ClearChanged(ByRef VendorInvoiceCategorySetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.VendorInvoiceCategorySetupViewModel)

			VendorInvoiceCategorySetupViewModel.SaveEnabled = False

		End Sub
		Public Function ValidateEntity(VendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory, ByRef IsValid As Boolean) As String

			'objects
			Dim ErrorText As String = String.Empty

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

					ErrorText = ValidateDTO(DbContext, DataContext, VendorInvoiceCategory, IsValid)

				End Using

			End Using

			ValidateEntity = ErrorText

		End Function
		Public Function ValidateProperty(VendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory, FieldName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = String.Empty
			Dim PropertyDescriptor As System.ComponentModel.PropertyDescriptor = Nothing
			Dim PropertyValue As String = String.Empty

			PropertyDescriptor = System.ComponentModel.TypeDescriptor.GetProperties(VendorInvoiceCategory.GetType).OfType(Of System.ComponentModel.PropertyDescriptor)().FirstOrDefault(Function(PD) PD.Name = FieldName)

			Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

				Using DataContext = New AdvantageFramework.Database.DataContext(Me.Session.ConnectionString, Me.Session.UserCode)

					ErrorText = ValidateDTOProperty(DbContext, DataContext, VendorInvoiceCategory, PropertyDescriptor, IsValid, Value)

				End Using

			End Using

			ValidateProperty = ErrorText

		End Function
		Public Overrides Function ValidateCustomProperties(DbContext As AdvantageFramework.BaseClasses.DbContext, DataContext As AdvantageFramework.BaseClasses.DataContext,
														   ByRef DTO As AdvantageFramework.DTO.BaseClass, PropertyName As String, ByRef IsValid As Boolean, ByRef Value As Object) As String

			'objects
			Dim ErrorText As String = ""
			Dim PropertyValue As Object = Nothing
			Dim VendorInvoiceCategory As AdvantageFramework.DTO.VendorInvoiceCategory = Nothing

			If PropertyName = AdvantageFramework.DTO.VendorInvoiceCategory.Properties.Name.ToString Then

				VendorInvoiceCategory = DTO

				PropertyValue = Value.ToString

				If AdvantageFramework.Database.Procedures.VendorInvoiceCategory.Load(DbContext).Any(Function(Entity) Entity.ID <> VendorInvoiceCategory.ID AndAlso
																													 Entity.Name.ToUpper = DirectCast(PropertyValue, String).ToUpper) Then

					ErrorText = "Please enter unique name."
					IsValid = False

				End If

			End If

			ValidateCustomProperties = ErrorText

		End Function

#End Region

	End Class

End Namespace
