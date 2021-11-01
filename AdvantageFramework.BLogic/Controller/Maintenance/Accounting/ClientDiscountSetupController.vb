Namespace Controller.Maintenance.Accounting

    Public Class ClientDiscountSetupController
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
        Public Function Load() As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel

            'objects
            Dim ClientDiscountSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel = Nothing

            ClientDiscountSetupViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel

            LoadClientDiscounts(ClientDiscountSetupViewModel)

            Load = ClientDiscountSetupViewModel

        End Function
        Public Sub LoadClientDiscounts(ByRef ClientDiscountSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ClientDiscountSetupViewModel.ClientDiscounts = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientDiscount).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount(Entity)).ToList

            End Using

        End Sub
        Public Sub SelectedDiscountChanged(ByRef ClientDiscountSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel,
                                           ClientDiscount As AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount)

            ClientDiscountSetupViewModel.SelectedClientDiscount = ClientDiscount

            ClientDiscountSetupViewModel.DeleteEnabled = ClientDiscountSetupViewModel.HasASelectedClientDiscount

        End Sub
        Public Sub UserEntryChanged(ByRef ClientDiscountSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel)

            ClientDiscountSetupViewModel.SaveEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef ClientDiscountSetupViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountSetupViewModel)

            ClientDiscountSetupViewModel.SaveEnabled = False

        End Sub

#End Region

    End Class

End Namespace