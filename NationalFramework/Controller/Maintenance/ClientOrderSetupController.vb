Namespace Controller.Maintenance

    Public Class ClientOrderSetupController

#Region " Constants "



#End Region

#Region " Enum "



#End Region

#Region " Variables "

        Protected _ConnectionString As String = Nothing

#End Region

#Region " Properties "



#End Region

#Region " Methods "


#Region " Public "

        Public Sub New(ConnectionString As String)

            _ConnectionString = ConnectionString

        End Sub
        Public Sub ClientOrderSelectionChanged(ClientOrderViewModel As NationalFramework.ViewModels.Maintenance.ClientOrderViewModel,
                                               SelectedClientOrder As NationalFramework.DTO.ClientOrder)

            ClientOrderViewModel.SelectedClientOrder = SelectedClientOrder

        End Sub
        Public Function Load(ClientID As Integer, OrderType As String) As NationalFramework.ViewModels.Maintenance.ClientOrderViewModel

            'objects
            Dim ClientOrderViewModel As ViewModels.Maintenance.ClientOrderViewModel = Nothing
            Dim Client As Database.Entities.Client = Nothing

            ClientOrderViewModel = New ViewModels.Maintenance.ClientOrderViewModel

            Using DbContext = New Database.DbContext(_ConnectionString)

                ClientOrderViewModel.ClientOrders.AddRange(From Entity In Database.Procedures.ClientOrder.LoadByClientIDandOrderType(DbContext, ClientID).OrderBy(Function(Entity) Entity.OrderNumber).ToList
                                                           Select New DTO.ClientOrder(Entity))

                Client = Database.Procedures.Client.LoadByID(DbContext, ClientID)

                If Client IsNot Nothing Then

                    ClientOrderViewModel.ClientName = Client.Name

                End If

            End Using

            Load = ClientOrderViewModel

        End Function

#End Region

#End Region

    End Class

End Namespace
