Namespace ViewModels.Maintenance.Accounting

    Public Class VendorComboRadioStationViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property SaveEnabled As Boolean
        Public Property CancelEnabled As Boolean

        Public Property AddVendorGroupsEnabled As Boolean

        Public Property AddEnabled As Boolean
        Public Property AddAllEnabled As Boolean
        Public Property RemoveEnabled As Boolean
        Public Property RemoveAllEnabled As Boolean

        Public Property VendorCode As String

        Public Property Vendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

        Public Property AvailableVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)
        Public Property SelectedVendors As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

#End Region

#Region " Methods "

        Public Sub New()

            Me.SaveEnabled = True
            Me.CancelEnabled = True

            Me.AddVendorGroupsEnabled = True

            Me.AddEnabled = False
            Me.AddAllEnabled = False
            Me.RemoveEnabled = False
            Me.RemoveAllEnabled = False

            Me.VendorCode = String.Empty

            Me.Vendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

            Me.AvailableVendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)
            Me.SelectedVendors = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.Vendor.VendorComboRadioStation)

        End Sub

#End Region

    End Class

End Namespace
