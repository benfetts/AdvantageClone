Namespace ViewModels.Maintenance

    Public Class ClientOrderViewModel

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "



#End Region

#Region " Properties "

        Public ReadOnly Property HasASelectedClientOrder As Boolean
            Get
                HasASelectedClientOrder = (SelectedClientOrder IsNot Nothing)
            End Get
        End Property

        Public Property ClientOrders As Generic.List(Of DTO.ClientOrder)
        Public Property SelectedClientOrder As DTO.ClientOrder
        Public Property ClientName As String

#End Region

#Region " Methods "

        Sub New()

            ClientOrders = New Generic.List(Of DTO.ClientOrder)

        End Sub

#End Region

    End Class

End Namespace

