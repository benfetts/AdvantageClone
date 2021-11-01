Namespace Controller.Security.Setup

    Public Class CDPSecurityGroupSetupController
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
        Public Function Load() As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel

            'objects
            Dim CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel = Nothing
            Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing

            CDPSecurityGroupSetupViewModel = New AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel

            LoadCDPSecurityGroups(CDPSecurityGroupSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CDPSecurityGroupSetupViewModel.Employees = DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).Include("Office").Include("DepartmentTeam").ToList.
                                                             Select(Function(Entity) New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee(Entity)).ToList

                CDPSecurityGroupSetupViewModel.CDPs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Product).Include("Office").Include("Client").Include("Division").
                                                        Select(Function(Entity) New With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID,
                                                                                          .OfficeCode = Entity.OfficeCode,
                                                                                          .OfficeName = Entity.Office.Name,
                                                                                          .ClientCode = Entity.ClientCode,
                                                                                          .ClientName = Entity.Client.Name,
                                                                                          .ClientIsActive = Entity.Client.IsActive,
                                                                                          .DivisionCode = Entity.DivisionCode,
                                                                                          .DivisionName = Entity.Division.Name,
                                                                                          .DivisionIsActive = Entity.Division.IsActive,
                                                                                          .ProductCode = Entity.Code,
                                                                                          .ProductName = Entity.Name,
                                                                                          .IsActive = Entity.IsActive}).ToList.
                                                        Select(Function(Entity) New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP With {.CDPSecurityGroupID = Entity.CDPSecurityGroupID.GetValueOrDefault(0),
                                                                                                                                                 .OfficeCode = Entity.OfficeCode,
                                                                                                                                                 .OfficeName = Entity.OfficeName,
                                                                                                                                                 .ClientCode = Entity.ClientCode,
                                                                                                                                                 .ClientName = Entity.ClientName,
                                                                                                                                                 .DivisionCode = Entity.DivisionCode,
                                                                                                                                                 .DivisionName = Entity.DivisionName,
                                                                                                                                                 .ProductCode = Entity.ProductCode,
                                                                                                                                                 .ProductName = Entity.ProductName,
                                                                                                                                                 .IsActive = CBool(If(Entity.ClientIsActive.GetValueOrDefault(0) = 1 AndAlso Entity.DivisionIsActive.GetValueOrDefault(0) = 1, Entity.IsActive.GetValueOrDefault(0), 0))}).ToList

                CDPSecurityGroupSetupViewModel.AddEnabled = True
                CDPSecurityGroupSetupViewModel.SaveEnabled = False
                CDPSecurityGroupSetupViewModel.CancelEnabled = False
                CDPSecurityGroupSetupViewModel.DeleteEnabled = False
                CDPSecurityGroupSetupViewModel.RefreshEnabled = True

            End Using

            Load = CDPSecurityGroupSetupViewModel

        End Function
        Public Function Add(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel, CDPSecurityGroupName As String, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing
            Dim CDPSecurityGroupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)
            CDPSecurityGroupViewModel = New AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupViewModel

            CDPSecurityGroupViewModel.CDPSecurityGroup = New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup
            CDPSecurityGroupViewModel.CDPSecurityGroup.Name = CDPSecurityGroupName

            Added = CDPSecurityGroupController.Add(CDPSecurityGroupViewModel, CDPSecurityGroupName, ErrorMessage)

            Add = Added

        End Function
        Public Function Save(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel, ByRef ErrorMessage As String) As Boolean


            'objects
            Dim Saved As Boolean = False
            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            Saved = CDPSecurityGroupController.Save(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel, ErrorMessage)

            CDPSecurityGroupSetupViewModel.SaveEnabled = Not Saved
            CDPSecurityGroupSetupViewModel.CancelEnabled = Not Saved

            Save = Saved

        End Function
        Public Function Delete(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            Deleted = CDPSecurityGroupController.Delete(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel, ErrorMessage)

            Delete = Deleted

        End Function
        Public Sub SelectedCDPSecurityGroupsChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel,
                                            CDPSecurityGroup As AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup)

            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroup = CDPSecurityGroup

            If CDPSecurityGroupSetupViewModel.HasASelectedCDPSecurityGroup Then

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel = CDPSecurityGroupController.Load(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroup.ID, CDPSecurityGroupSetupViewModel.Employees, CDPSecurityGroupSetupViewModel.CDPs)

            Else

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel = Nothing

            End If

            CDPSecurityGroupSetupViewModel.AddEnabled = True
            CDPSecurityGroupSetupViewModel.DeleteEnabled = CDPSecurityGroupSetupViewModel.HasASelectedCDPSecurityGroup
            CDPSecurityGroupSetupViewModel.RefreshEnabled = True

        End Sub
        Public Sub SelectedAvailableEmployeesChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel,
                                                     Employees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee))

            If CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedAvailableEmployees.Clear()

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedAvailableEmployees.AddRange(Employees)

            End If

        End Sub
        Public Sub SelectedGroupEmployeesChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel,
                                                 Employees As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.Employee))

            If CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedGroupEmployees.Clear()

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedGroupEmployees.AddRange(Employees)

            End If

        End Sub
        Public Sub SelectedAvailableCDPsChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel,
                                                CDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP))

            If CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedAvailableCDPs.Clear()

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedAvailableCDPs.AddRange(CDPs)

            End If

        End Sub
        Public Sub SelectedGroupCDPsChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel,
                                            CDPs As Generic.List(Of AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDP))

            If CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel IsNot Nothing Then

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedGroupCDPs.Clear()

                CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel.SelectedGroupCDPs.AddRange(CDPs)

            End If

        End Sub
        Public Sub LoadCDPSecurityGroups(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                CDPSecurityGroupSetupViewModel.CDPSecurityGroups = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.CDPSecurityGroup).ToList.
                                                                             Select(Function(Entity) New AdvantageFramework.DTO.Security.Setup.CDPSecurityGroup.CDPSecurityGroup(Entity)).ToList

            End Using

        End Sub
        Public Sub UserEntryChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            CDPSecurityGroupSetupViewModel.SaveEnabled = True
            CDPSecurityGroupSetupViewModel.CancelEnabled = True

        End Sub
        Public Sub ClearChanged(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            CDPSecurityGroupSetupViewModel.SaveEnabled = False
            CDPSecurityGroupSetupViewModel.CancelEnabled = False

        End Sub
        Public Sub AddEmployees(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            CDPSecurityGroupController.AddEmployees(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel)

        End Sub
        Public Sub RemoveEmployees(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            CDPSecurityGroupController.RemoveEmployees(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel)

        End Sub
        Public Sub AddCDPs(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            CDPSecurityGroupController.AddCDPs(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel)

        End Sub
        Public Sub RemoveCDPs(ByRef CDPSecurityGroupSetupViewModel As AdvantageFramework.ViewModels.Security.Setup.CDPSecurityGroupSetupViewModel)

            Dim CDPSecurityGroupController As AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController = Nothing

            CDPSecurityGroupController = New AdvantageFramework.Controller.Security.Setup.CDPSecurityGroupController(Me.Session)

            CDPSecurityGroupController.RemoveCDPs(CDPSecurityGroupSetupViewModel.SelectedCDPSecurityGroupViewModel)

        End Sub

#End Region

    End Class

End Namespace
