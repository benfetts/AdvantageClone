Namespace ViewModels.Maintenance.Media

    Public Class InvoiceMatchingSettingViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property CancelEnabled As Boolean
        Public Property DeleteEnabled As Boolean
        Public Property InvoiceMatchingSettings As Generic.List(Of AdvantageFramework.Database.Entities.InvoiceMatchingSetting)
        Public Property Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client)
        Public ReadOnly Property HasASelectedInvoiceMatchingSetting As Boolean
            Get
                HasASelectedInvoiceMatchingSetting = SelectedInvoiceMatchingSetting IsNot Nothing
            End Get
        End Property
        Public Property IsNewRow As Boolean
        Public Property SelectedInvoiceMatchingSetting As AdvantageFramework.Database.Entities.InvoiceMatchingSetting
        Public Property MediaTypes As Generic.List(Of AdvantageFramework.DTO.ComboBoxItem)

#End Region

#Region " Methods "

        Public Sub New()



        End Sub

#End Region

    End Class

End Namespace

