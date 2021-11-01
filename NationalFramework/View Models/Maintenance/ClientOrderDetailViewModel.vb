Namespace ViewModels.Maintenance

    Public Class ClientOrderDetailViewModel
        Inherits AdvantageFramework.BaseClasses.BaseClass

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public Property ClientOrder As DTO.ClientOrder

        'Public Property SelectedClientOrderDetail As DTO.ClientOrderDetail
        Public Property ClientOrderDetails As Generic.List(Of DTO.ClientOrderDetail)

        'Public Property DetailIsNewRow As Boolean
        'Public Property DetailCancelEnabled As Boolean
        'Public Property DetailDeleteEnabled As Boolean

#End Region

#Region " Methods "

        Public Sub New()

            ClientOrderDetails = New Generic.List(Of DTO.ClientOrderDetail)

        End Sub

#End Region

    End Class

End Namespace

