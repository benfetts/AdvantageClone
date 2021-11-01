Namespace Controller.Maintenance.Accounting

    Public Class ClientDiscountController
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
        Public Function Load(ClientDiscountCode As String) As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel

            'objects
            Dim ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel = Nothing
            Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing

            ClientDiscountViewModel = New AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ClientDiscountViewModel.Functions = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.Function).ToList.Select(Function(Entity) New AdvantageFramework.DTO.Function(Entity)).ToList

                If String.IsNullOrWhiteSpace(ClientDiscountCode) = False Then

                    ClientDiscount = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.ClientDiscount).Include("ClientDiscountExclusions").Include("ClientDiscountExclusions.Function").SingleOrDefault(Function(Entity) Entity.Code = ClientDiscountCode)

                    If ClientDiscount IsNot Nothing Then

                        ClientDiscountViewModel.ClientDiscount = New AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount(ClientDiscount)

                        For Each ClientDiscountExclusion In ClientDiscount.ClientDiscountExclusions

                            ClientDiscountViewModel.ClientDiscountExclusions.Add(New AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion(ClientDiscountExclusion))

                        Next

                        ClientDiscountViewModel.AllowCodeEdit = False

                        ClientDiscountViewModel.UpdateEnabled = True

                    End If

                Else

                    ClientDiscountViewModel.ClientDiscount = New AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscount()
                    ClientDiscountViewModel.ClientDiscountExclusions = New Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion)
                    ClientDiscountViewModel.AllowCodeEdit = True
                    ClientDiscountViewModel.AddEnabled = True

                End If

            End Using

            Load = ClientDiscountViewModel

        End Function
        Public Function Add(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing
            Dim ClientDiscountExclusion As AdvantageFramework.Database.Entities.ClientDiscountExclusion = Nothing
            Dim ClientDiscountCode As String = String.Empty

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                ClientDiscountCode = ClientDiscountViewModel.ClientDiscount.Code

                If DbContext.ClientDiscounts.Any(Function(Entity) Entity.Code = ClientDiscountCode) = False Then

                    ClientDiscount = New AdvantageFramework.Database.Entities.ClientDiscount

                    DbContext.ClientDiscounts.Add(ClientDiscount)

                    ClientDiscountViewModel.ClientDiscount.SaveToEntity(ClientDiscount)

                    For Each DiscountExclusionDTO In ClientDiscountViewModel.ClientDiscountExclusions

                        ClientDiscountExclusion = New AdvantageFramework.Database.Entities.ClientDiscountExclusion

                        DiscountExclusionDTO.SaveToEntity(ClientDiscountExclusion)

                        ClientDiscountExclusion.ClientDiscountCode = ClientDiscount.Code

                        DbContext.ClientDiscountExclusions.Add(ClientDiscountExclusion)

                    Next

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    Added = (DbContext.SaveChanges() > 0)

                Else

                    ErrorMessage = "Please enter a unique client discount code."

                End If

            End Using

            Add = Added

        End Function
        Public Sub Save(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel)

            'objects
            Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing
            Dim ClientDiscountExclusion As AdvantageFramework.Database.Entities.ClientDiscountExclusion = Nothing
            Dim FunctionCodes As Generic.List(Of String) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                ClientDiscount = DbContext.ClientDiscounts.Find(ClientDiscountViewModel.ClientDiscount.Code)

                DbContext.Entry(ClientDiscount).Collection(Function(Entity) Entity.ClientDiscountExclusions).Load()

                ClientDiscountViewModel.ClientDiscount.SaveToEntity(ClientDiscount)

                FunctionCodes = New Generic.List(Of String)

                For Each DiscountExclusionDTO In ClientDiscountViewModel.ClientDiscountExclusions

                    ClientDiscountExclusion = ClientDiscount.ClientDiscountExclusions.SingleOrDefault(Function(Entity) Entity.FunctionCode = DiscountExclusionDTO.FunctionCode)

                    If ClientDiscountExclusion Is Nothing Then

                        ClientDiscountExclusion = New AdvantageFramework.Database.Entities.ClientDiscountExclusion

                        DbContext.ClientDiscountExclusions.Add(ClientDiscountExclusion)

                    End If

                    DiscountExclusionDTO.SaveToEntity(ClientDiscountExclusion)

                    FunctionCodes.Add(ClientDiscountExclusion.FunctionCode)

                Next

                For Each ClientDiscountExclusion In ClientDiscount.ClientDiscountExclusions.ToList.Where(Function(Entity) FunctionCodes.Contains(Entity.FunctionCode) = False)

                    DbContext.ClientDiscountExclusions.Remove(ClientDiscountExclusion)

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Function Delete(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim ClientDiscount As AdvantageFramework.Database.Entities.ClientDiscount = Nothing
            Dim ClientDiscountExclusion As AdvantageFramework.Database.Entities.ClientDiscountExclusion = Nothing
            Dim Deleted As Boolean = False

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                ClientDiscount = DbContext.ClientDiscounts.Find(ClientDiscountViewModel.ClientDiscount.Code)

                DbContext.Entry(ClientDiscount).Collection(Function(Entity) Entity.Clients).Load()
                DbContext.Entry(ClientDiscount).Collection(Function(Entity) Entity.JobComponents).Load()

                If ClientDiscount.JobComponents.Any = False AndAlso ClientDiscount.Clients.Any = False Then

                    DbContext.Entry(ClientDiscount).Collection(Function(Entity) Entity.ClientDiscountExclusions).Load()

                    For Each ClientDiscountExclusion In ClientDiscount.ClientDiscountExclusions.ToList

                        DbContext.ClientDiscountExclusions.Remove(ClientDiscountExclusion)

                    Next

                    DbContext.ClientDiscounts.Remove(ClientDiscount)

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    Deleted = (DbContext.SaveChanges() > 0)

                Else

                    ErrorMessage = "Client discount is in use and cannot be deleted."

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function GetRepositoryFunctionDescription(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel, FunctionCode As String) As String

            'objects
            Dim FunctionDescription As String = String.Empty
            Dim [Function] As AdvantageFramework.DTO.Function = Nothing

            [Function] = ClientDiscountViewModel.Functions.FirstOrDefault(Function(Entity) Entity.Code = FunctionCode)

            If [Function] IsNot Nothing Then

                FunctionDescription = [Function].Description

            End If

            GetRepositoryFunctionDescription = FunctionDescription

        End Function
        Public Function GetRepositoryFunctions(ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel) As Generic.List(Of AdvantageFramework.DTO.Function)

            'objects
            Dim Functions As Generic.List(Of AdvantageFramework.DTO.Function) = Nothing

            Functions = (From [Function] In ClientDiscountViewModel.Functions
                         Where [Function].IsInactive = False AndAlso
                               ClientDiscountViewModel.ClientDiscountExclusions.Any(Function(Entity) Entity.FunctionCode = [Function].Code) = False
                         Select [Function]).ToList

            GetRepositoryFunctions = Functions

        End Function
        Public Sub SelectedDiscountExclusionsChanged(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel,
                                                     IsNewItemRow As Boolean,
                                                     ClientDiscountExclusions As Generic.List(Of AdvantageFramework.DTO.Maintenance.Accounting.ClientDiscountExclusion))

            ClientDiscountViewModel.SelectedClientDiscountExclusions = ClientDiscountExclusions

            ClientDiscountViewModel.ClientDiscountExclusions_IsNewRow = IsNewItemRow
            ClientDiscountViewModel.ClientDiscountExclusions_CancelEnabled = IsNewItemRow
            ClientDiscountViewModel.ClientDiscountExclusions_DeleteEnabled = (Not IsNewItemRow AndAlso ClientDiscountViewModel.HasASelectedClientDiscountExclusion)

        End Sub
        Public Sub DiscountExclusions_InitNewRowEvent(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel)

            ClientDiscountViewModel.ClientDiscountExclusions_IsNewRow = True
            ClientDiscountViewModel.ClientDiscountExclusions_CancelEnabled = True
            ClientDiscountViewModel.ClientDiscountExclusions_DeleteEnabled = False

        End Sub
        Public Sub DiscountExclusions_CancelNewItemRow(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel)

            ClientDiscountViewModel.ClientDiscountExclusions_IsNewRow = False
            ClientDiscountViewModel.ClientDiscountExclusions_CancelEnabled = False
            ClientDiscountViewModel.ClientDiscountExclusions_DeleteEnabled = ClientDiscountViewModel.HasASelectedClientDiscountExclusion

        End Sub
        Public Sub DiscountExclusions_Delete(ByRef ClientDiscountViewModel As AdvantageFramework.ViewModels.Maintenance.Accounting.ClientDiscountViewModel)

            If ClientDiscountViewModel.HasASelectedClientDiscountExclusion Then

                For Each ClientDiscountExclusion In ClientDiscountViewModel.SelectedClientDiscountExclusions

                    ClientDiscountViewModel.ClientDiscountExclusions.Remove(ClientDiscountExclusion)

                Next

            End If

        End Sub

#End Region

    End Class

End Namespace