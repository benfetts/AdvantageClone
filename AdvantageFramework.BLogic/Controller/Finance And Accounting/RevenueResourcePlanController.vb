Namespace Controller.FinanceAndAccounting

    Public Class RevenueResourcePlanController
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

#Region "  Public "

        Public Function Delete(Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Deleted As Boolean = False
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlan = DbContext.RevenueResourcePlans.Find(Plan.ID)

                If RevenueResourcePlan IsNot Nothing Then

                    Try

                        DbContext.Entry(RevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanStaffs.ToString).Load()
                        DbContext.Entry(RevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanRevenues.ToString).Load()
                        DbContext.Entry(RevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanResources.ToString).Load()

                        For Each PlanStaff In RevenueResourcePlan.RevenueResourcePlanStaffs.ToList

                            DbContext.Entry(PlanStaff).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanStaff.Properties.RevenueResourcePlanStaffClients.ToString).Load()

                            For Each PlanStaffClient In PlanStaff.RevenueResourcePlanStaffClients.ToList

                                DbContext.RevenueResourcePlanStaffClients.Remove(PlanStaffClient)

                            Next

                            DbContext.RevenueResourcePlanStaffs.Remove(PlanStaff)

                        Next

                        For Each PlanRevenue In RevenueResourcePlan.RevenueResourcePlanRevenues.ToList

                            DbContext.Entry(PlanRevenue).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue.Properties.RevenueResourcePlanRevenueRevisions.ToString).Load()

                            For Each RevenueRevision In PlanRevenue.RevenueResourcePlanRevenueRevisions.ToList

                                DbContext.Entry(RevenueRevision).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision.Properties.RevenueResourcePlanRevenueDetails.ToString).Load()

                                For Each RevenueDetail In RevenueRevision.RevenueResourcePlanRevenueDetails.ToList

                                    DbContext.Entry(RevenueDetail).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail.Properties.RevenueResourcePlanRevenueDetailDates.ToString).Load()

                                    For Each RevenueDetailDate In RevenueDetail.RevenueResourcePlanRevenueDetailDates.ToList

                                        DbContext.RevenueResourcePlanRevenueDetailDates.Remove(RevenueDetailDate)

                                    Next

                                    DbContext.RevenueResourcePlanRevenueDetails.Remove(RevenueDetail)

                                Next

                                DbContext.RevenueResourcePlanRevenueRevisions.Remove(RevenueRevision)

                            Next

                            DbContext.RevenueResourcePlanRevenues.Remove(PlanRevenue)

                        Next

                        For Each PlanResource In RevenueResourcePlan.RevenueResourcePlanResources.ToList

                            DbContext.Entry(PlanResource).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResource.Properties.RevenueResourcePlanResourceRevisions.ToString).Load()

                            For Each ResourceRevision In PlanResource.RevenueResourcePlanResourceRevisions.ToList

                                DbContext.Entry(ResourceRevision).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision.Properties.RevenueResourcePlanResourceDetails.ToString).Load()

                                For Each ResourceDetail In ResourceRevision.RevenueResourcePlanResourceDetails.ToList

                                    DbContext.Entry(ResourceDetail).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail.Properties.RevenueResourcePlanResourceDetailDates.ToString).Load()

                                    For Each ResourceDetailDate In ResourceDetail.RevenueResourcePlanResourceDetailDates.ToList

                                        DbContext.RevenueResourcePlanResourceDetailDates.Remove(ResourceDetailDate)

                                    Next

                                    DbContext.RevenueResourcePlanResourceDetails.Remove(ResourceDetail)

                                Next

                                DbContext.RevenueResourcePlanResourceRevisions.Remove(ResourceRevision)

                            Next

                            DbContext.RevenueResourcePlanResources.Remove(PlanResource)

                        Next

                        DbContext.RevenueResourcePlans.Remove(RevenueResourcePlan)

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                        Deleted = True

                    Catch ex As Exception

                        ErrorMessage = "Failed to delete plan." & System.Environment.NewLine & ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                            If ex.InnerException.InnerException IsNot Nothing Then

                                ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                            End If

                        End If

                    End Try

                Else

                    ErrorMessage = "This plan is no longer valid in the system."

                End If

            End Using

            Delete = Deleted

        End Function
        Public Function Copy(Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Copied As Boolean = False
            Dim CopyFromRevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing
            Dim RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient = Nothing
            Dim RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource = Nothing
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing
            Dim RevenueResourcePlanResourceDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail = Nothing
            Dim RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate = Nothing
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing
            Dim OrginalName As String = String.Empty
            Dim NameCounter As Integer = 1
            Dim MaxRevision As Integer = 1

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                CopyFromRevenueResourcePlan = DbContext.RevenueResourcePlans.Find(Plan.ID)

                If CopyFromRevenueResourcePlan IsNot Nothing Then

                    Try

                        RevenueResourcePlan = New AdvantageFramework.Database.Entities.RevenueResourcePlan

                        RevenueResourcePlan.DbContext = DbContext

                        RevenueResourcePlan.EmployeeCode = CopyFromRevenueResourcePlan.EmployeeCode
                        RevenueResourcePlan.OfficeCode = CopyFromRevenueResourcePlan.OfficeCode
                        RevenueResourcePlan.StartDate = CopyFromRevenueResourcePlan.StartDate
                        RevenueResourcePlan.EndDate = CopyFromRevenueResourcePlan.EndDate
                        RevenueResourcePlan.Description = CopyFromRevenueResourcePlan.Description
                        RevenueResourcePlan.Notes = CopyFromRevenueResourcePlan.Notes

                        OrginalName = CopyFromRevenueResourcePlan.Description

                        Do While True

                            RevenueResourcePlan.Description = OrginalName & " (" & NameCounter & ")"

                            If DbContext.RevenueResourcePlans.Any(Function(Entity) Entity.Description = RevenueResourcePlan.Description) = False Then

                                Exit Do

                            End If

                            NameCounter += 1

                        Loop

                        DbContext.Entry(CopyFromRevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanStaffs.ToString).Load()
                        DbContext.Entry(CopyFromRevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanRevenues.ToString).Load()
                        DbContext.Entry(CopyFromRevenueResourcePlan).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlan.Properties.RevenueResourcePlanResources.ToString).Load()

                        DbContext.RevenueResourcePlans.Add(RevenueResourcePlan)

                        For Each PlanStaff In CopyFromRevenueResourcePlan.RevenueResourcePlanStaffs

                            RevenueResourcePlanStaff = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaff

                            RevenueResourcePlanStaff.DbContext = DbContext

                            RevenueResourcePlanStaff.RevenueResourcePlan = RevenueResourcePlan
                            RevenueResourcePlanStaff.EmployeeCode = PlanStaff.EmployeeCode
                            RevenueResourcePlanStaff.OfficeCode = PlanStaff.OfficeCode
                            RevenueResourcePlanStaff.EmployeeTitleID = PlanStaff.EmployeeTitleID
                            RevenueResourcePlanStaff.DepartmentTeamCode = PlanStaff.DepartmentTeamCode
                            RevenueResourcePlanStaff.Notes = PlanStaff.Notes

                            DbContext.RevenueResourcePlanStaffs.Add(RevenueResourcePlanStaff)

                            DbContext.Entry(PlanStaff).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanStaff.Properties.RevenueResourcePlanStaffClients.ToString).Load()

                            For Each PlanStaffClient In PlanStaff.RevenueResourcePlanStaffClients

                                RevenueResourcePlanStaffClient = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient

                                RevenueResourcePlanStaffClient.DbContext = DbContext

                                RevenueResourcePlanStaffClient.RevenueResourcePlanStaff = RevenueResourcePlanStaff
                                RevenueResourcePlanStaffClient.ClientCode = PlanStaffClient.ClientCode
                                RevenueResourcePlanStaffClient.DivisionCode = PlanStaffClient.DivisionCode
                                RevenueResourcePlanStaffClient.ProductCode = PlanStaffClient.ProductCode
                                RevenueResourcePlanStaffClient.Percent = PlanStaffClient.Percent
                                RevenueResourcePlanStaffClient.Notes = PlanStaffClient.Notes

                                DbContext.RevenueResourcePlanStaffClients.Add(RevenueResourcePlanStaffClient)

                            Next

                        Next

                        For Each PlanRevenue In CopyFromRevenueResourcePlan.RevenueResourcePlanRevenues

                            RevenueResourcePlanRevenue = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue

                            RevenueResourcePlanRevenue.DbContext = DbContext

                            RevenueResourcePlanRevenue.RevenueResourcePlan = RevenueResourcePlan
                            RevenueResourcePlanRevenue.ClientCode = PlanRevenue.ClientCode
                            RevenueResourcePlanRevenue.EmployeeCode = PlanRevenue.EmployeeCode
                            RevenueResourcePlanRevenue.Notes = PlanRevenue.Notes

                            DbContext.RevenueResourcePlanRevenues.Add(RevenueResourcePlanRevenue)

                            DbContext.Entry(PlanRevenue).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue.Properties.RevenueResourcePlanRevenueRevisions.ToString).Load()

                            If PlanRevenue.RevenueResourcePlanRevenueRevisions IsNot Nothing AndAlso PlanRevenue.RevenueResourcePlanRevenueRevisions.Count > 0 Then

                                MaxRevision = PlanRevenue.RevenueResourcePlanRevenueRevisions.Select(Function(Entity) Entity.RevisionNumber).Max

                                For Each RevenueRevision In PlanRevenue.RevenueResourcePlanRevenueRevisions.Where(Function(Entity) Entity.RevisionNumber = MaxRevision)

                                    RevenueResourcePlanRevenueRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision

                                    RevenueResourcePlanRevenueRevision.DbContext = DbContext

                                    RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenue = RevenueResourcePlanRevenue
                                    RevenueResourcePlanRevenueRevision.RevisionNumber = 1
                                    RevenueResourcePlanRevenueRevision.Approved = False
                                    RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Nothing
                                    RevenueResourcePlanRevenueRevision.ApprovedDate = Nothing
                                    RevenueResourcePlanRevenueRevision.Notes = RevenueRevision.Notes

                                    DbContext.RevenueResourcePlanRevenueRevisions.Add(RevenueResourcePlanRevenueRevision)

                                    DbContext.Entry(RevenueRevision).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision.Properties.RevenueResourcePlanRevenueDetails.ToString).Load()

                                    For Each RevenueDetail In RevenueRevision.RevenueResourcePlanRevenueDetails

                                        RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                                        RevenueResourcePlanRevenueDetail.DbContext = DbContext

                                        RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevision = RevenueResourcePlanRevenueRevision
                                        RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = RevenueDetail.RevenueResourcePlanRevenueTypeID
                                        RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = RevenueDetail.RevenueResourcePlanRevenueStatusID
                                        RevenueResourcePlanRevenueDetail.ClientCode = RevenueDetail.ClientCode
                                        RevenueResourcePlanRevenueDetail.DivisionCode = RevenueDetail.DivisionCode
                                        RevenueResourcePlanRevenueDetail.ProductCode = RevenueDetail.ProductCode
                                        RevenueResourcePlanRevenueDetail.JobNumber = RevenueDetail.JobNumber
                                        RevenueResourcePlanRevenueDetail.JobComponentNumber = RevenueDetail.JobComponentNumber
                                        RevenueResourcePlanRevenueDetail.Notes = RevenueDetail.Notes

                                        DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                                        DbContext.Entry(RevenueDetail).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail.Properties.RevenueResourcePlanRevenueDetailDates.ToString).Load()

                                        For Each RevenueDetailDate In RevenueDetail.RevenueResourcePlanRevenueDetailDates

                                            RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                                            RevenueResourcePlanRevenueDetailDate.DbContext = DbContext

                                            RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                                            RevenueResourcePlanRevenueDetailDate.Date = RevenueDetailDate.Date
                                            RevenueResourcePlanRevenueDetailDate.Revenue = RevenueDetailDate.Revenue

                                            DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                                        Next

                                    Next

                                Next

                            End If

                        Next

                        For Each PlanResource In CopyFromRevenueResourcePlan.RevenueResourcePlanResources

                            RevenueResourcePlanResource = New AdvantageFramework.Database.Entities.RevenueResourcePlanResource

                            RevenueResourcePlanResource.DbContext = DbContext

                            RevenueResourcePlanResource.RevenueResourcePlan = RevenueResourcePlan
                            RevenueResourcePlanResource.ClientCode = PlanResource.ClientCode
                            RevenueResourcePlanResource.EmployeeCode = PlanResource.EmployeeCode
                            RevenueResourcePlanResource.Notes = PlanResource.Notes

                            DbContext.RevenueResourcePlanResources.Add(RevenueResourcePlanResource)

                            DbContext.Entry(PlanResource).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResource.Properties.RevenueResourcePlanResourceRevisions.ToString).Load()

                            If PlanResource.RevenueResourcePlanResourceRevisions IsNot Nothing AndAlso PlanResource.RevenueResourcePlanResourceRevisions.Count > 0 Then

                                MaxRevision = PlanResource.RevenueResourcePlanResourceRevisions.Select(Function(Entity) Entity.RevisionNumber).Max

                                For Each RevenueRevision In PlanResource.RevenueResourcePlanResourceRevisions.Where(Function(Entity) Entity.RevisionNumber = MaxRevision)

                                    RevenueResourcePlanResourceRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision

                                    RevenueResourcePlanResourceRevision.DbContext = DbContext

                                    RevenueResourcePlanResourceRevision.RevenueResourcePlanResource = RevenueResourcePlanResource
                                    RevenueResourcePlanResourceRevision.RevisionNumber = 1
                                    RevenueResourcePlanResourceRevision.Approved = False
                                    RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Nothing
                                    RevenueResourcePlanResourceRevision.ApprovedDate = Nothing
                                    RevenueResourcePlanResourceRevision.Notes = RevenueRevision.Notes

                                    DbContext.RevenueResourcePlanResourceRevisions.Add(RevenueResourcePlanResourceRevision)

                                    DbContext.Entry(RevenueRevision).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision.Properties.RevenueResourcePlanResourceDetails.ToString).Load()

                                    For Each RevenueDetail In RevenueRevision.RevenueResourcePlanResourceDetails

                                        RevenueResourcePlanResourceDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail

                                        RevenueResourcePlanResourceDetail.DbContext = DbContext

                                        RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceRevision = RevenueResourcePlanResourceRevision
                                        RevenueResourcePlanResourceDetail.RevenueResourcePlanStaffID = RevenueDetail.RevenueResourcePlanStaffID

                                        DbContext.RevenueResourcePlanResourceDetails.Add(RevenueResourcePlanResourceDetail)

                                        DbContext.Entry(RevenueDetail).Collection(AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail.Properties.RevenueResourcePlanResourceDetailDates.ToString).Load()

                                        For Each RevenueDetailDate In RevenueDetail.RevenueResourcePlanResourceDetailDates

                                            RevenueResourcePlanResourceDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate

                                            RevenueResourcePlanResourceDetailDate.DbContext = DbContext

                                            RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail = RevenueResourcePlanResourceDetail
                                            RevenueResourcePlanResourceDetailDate.Date = RevenueDetailDate.Date
                                            RevenueResourcePlanResourceDetailDate.Hours = RevenueDetailDate.Hours

                                            DbContext.RevenueResourcePlanResourceDetailDates.Add(RevenueResourcePlanResourceDetailDate)

                                        Next

                                    Next

                                Next

                            End If

                        Next

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                        Copied = True

                    Catch ex As Exception

                        ErrorMessage = "Failed to copy plan." & System.Environment.NewLine & ex.Message

                        If ex.InnerException IsNot Nothing Then

                            ErrorMessage &= System.Environment.NewLine & ex.InnerException.Message

                            If ex.InnerException.InnerException IsNot Nothing Then

                                ErrorMessage &= System.Environment.NewLine & ex.InnerException.InnerException.Message

                            End If

                        End If

                    End Try

                Else

                    ErrorMessage = "This plan is no longer valid in the system."

                End If

            End Using

            Copy = Copied

        End Function
        Public Function ValidatePlanDates(Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim PlanDatesAreValid As Boolean = True

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                If Plan.StartDate > Plan.EndDate Then

                    ErrorMessage = "Plan start date cannot exceed the plan end date."
                    PlanDatesAreValid = False

                End If

                If PlanDatesAreValid Then

                    If DateDiff(DateInterval.Day, Plan.StartDate.AddYears(1), Plan.EndDate) > 0 Then

                        ErrorMessage = "Plan date range cannot exceed a year."
                        PlanDatesAreValid = False

                    End If

                End If

            End Using

            ValidatePlanDates = PlanDatesAreValid

        End Function
        Public Sub LoadPlanStaffProperties(DbContext As AdvantageFramework.Database.DbContext,
                                           Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan,
                                           PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff,
                                           RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff)

            'objects
            Dim EmployeeHoursAvailable As Decimal = 0

            If String.IsNullOrWhiteSpace(RevenueResourcePlanStaff.EmployeeCode) Then

                If RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.StaffType.Freelance Then

                    PlanStaff.Type = "Freelance"

                ElseIf RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.StaffType.FullTime Then

                    PlanStaff.Type = "Full Time"

                ElseIf RevenueResourcePlanStaff.RevenueResourcePlanStaffTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.StaffType.PartTime Then

                    PlanStaff.Type = "Part Time"

                End If

                PlanStaff.Status = "Projected"

                PlanStaff.HoursAvailable = RevenueResourcePlanStaff.AltEmployeeMonthlyHours.GetValueOrDefault(0)

                PlanStaff.DirectPercentGoal = RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal.GetValueOrDefault(0)

                If RevenueResourcePlanStaff.AltEmployeeMonthlyHours.GetValueOrDefault(0) <> 0 Then

                    PlanStaff.DirectHoursGoal = Math.Round(CDbl(RevenueResourcePlanStaff.AltEmployeeDirectHoursGoal.GetValueOrDefault(0) * RevenueResourcePlanStaff.AltEmployeeMonthlyHours), 2)

                Else

                    PlanStaff.DirectHoursGoal = 0

                End If

                PlanStaff.PlanAllocatedPercentage = 0

                'If RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.Count > 0 Then

                '    PlanStaff.PlanAllocatedPercentage = Math.Round(CDbl(RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.Sum(Function(Entity) Entity.Percent) / 100), 2)

                'Else

                '    PlanStaff.PlanAllocatedPercentage = 0

                'End If

                PlanStaff.PlanAllocatedHours = Math.Round(CDbl(PlanStaff.HoursAvailable * PlanStaff.PlanAllocatedPercentage), 2)
                PlanStaff.UtilizationVariance = PlanStaff.PlanAllocatedHours - PlanStaff.DirectHoursGoal

                If PlanStaff.HoursAvailable <> 0 Then

                    PlanStaff.UtilizationVariancePercentage = Math.Round(CDbl(PlanStaff.UtilizationVariance / PlanStaff.DirectHoursGoal), 2)

                Else

                    PlanStaff.UtilizationVariancePercentage = 0

                End If

                PlanStaff.EmployeeCost = Math.Round(CDbl(PlanStaff.DirectHoursGoal * RevenueResourcePlanStaff.AltEmployeeHourlyCostRate.GetValueOrDefault(0)), 2)
                PlanStaff.PlanRevenue = Math.Round(CDbl(PlanStaff.DirectHoursGoal * RevenueResourcePlanStaff.AltEmployeeHourlyBillableRate.GetValueOrDefault(0)), 2)
                PlanStaff.CostRevenueVariance = PlanStaff.PlanRevenue - PlanStaff.EmployeeCost

                If PlanStaff.EmployeeCost <> 0 Then

                    PlanStaff.CostRevenueVariancePercentage = Math.Round(CDbl(PlanStaff.CostRevenueVariance / PlanStaff.EmployeeCost), 2)

                Else

                    PlanStaff.CostRevenueVariancePercentage = 0

                End If

            Else

                If CBool(RevenueResourcePlanStaff.Employee.Freelance.GetValueOrDefault(0)) Then

                    PlanStaff.Type = "Freelance"

                    If RevenueResourcePlanStaff.Employee.IsActiveFreelance Then

                        PlanStaff.Status = "Active"

                        If RevenueResourcePlanStaff.Employee.StartDate.GetValueOrDefault(Now.ToShortDateString) > Now Then

                            PlanStaff.Status &= " - Starts on " & RevenueResourcePlanStaff.Employee.StartDate.Value.ToShortDateString

                        End If

                        If RevenueResourcePlanStaff.Employee.TerminationDate.GetValueOrDefault(Now.ToShortDateString) > Now Then

                            PlanStaff.Status &= " - Ends on " & RevenueResourcePlanStaff.Employee.TerminationDate.Value.ToShortDateString

                        End If

                    Else

                        PlanStaff.Status = "Inactive"

                    End If

                Else

                    Try

                        EmployeeHoursAvailable = DbContext.Database.SqlQuery(Of Decimal)(String.Format("EXEC [dbo].[advsp_revenue_resources_load_staff_available_hours] '{0}', '{1}', '{2}'", RevenueResourcePlanStaff.EmployeeCode, Plan.StartDate.ToShortDateString, Plan.EndDate.ToShortDateString)).FirstOrDefault

                    Catch ex As Exception
                        EmployeeHoursAvailable = 0
                    End Try

                    If EmployeeHoursAvailable < 35 Then

                        PlanStaff.Type = "Part Time Employee"

                    Else

                        PlanStaff.Type = "Full Time Employee"

                    End If

                    If RevenueResourcePlanStaff.Employee.StartDate.GetValueOrDefault(Now.ToShortDateString) > Now Then

                        PlanStaff.Status = "Inactive - Starts on " & RevenueResourcePlanStaff.Employee.StartDate.Value.ToShortDateString

                    Else

                        PlanStaff.Status = "Active"

                        If RevenueResourcePlanStaff.Employee.TerminationDate.HasValue Then

                            If RevenueResourcePlanStaff.Employee.TerminationDate.GetValueOrDefault(Now.ToShortDateString) > Now Then

                                PlanStaff.Status &= " - Ends on " & RevenueResourcePlanStaff.Employee.TerminationDate.Value.ToShortDateString

                            Else

                                PlanStaff.Status = "Inactive"

                            End If

                        End If

                    End If

                End If

                PlanStaff.HoursAvailable = EmployeeHoursAvailable

                PlanStaff.DirectPercentGoal = (RevenueResourcePlanStaff.Employee.DirectHours.GetValueOrDefault(0) / 100)

                If PlanStaff.DirectPercentGoal <> 0 Then

                    PlanStaff.DirectHoursGoal = Math.Round(PlanStaff.DirectPercentGoal * PlanStaff.HoursAvailable, 2)

                Else

                    PlanStaff.DirectHoursGoal = 0

                End If

                PlanStaff.PlanAllocatedPercentage = 0

                'If RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.Count > 0 Then

                '    PlanStaff.PlanAllocatedPercentage = Math.Round(CDbl(RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.Sum(Function(Entity) Entity.Percent) / 100), 2)

                'Else

                '    PlanStaff.PlanAllocatedPercentage = 0

                'End If

                PlanStaff.PlanAllocatedHours = Math.Round(CDbl(PlanStaff.HoursAvailable * PlanStaff.PlanAllocatedPercentage), 2)
                PlanStaff.UtilizationVariance = PlanStaff.PlanAllocatedHours - PlanStaff.DirectHoursGoal

                If PlanStaff.DirectHoursGoal <> 0 Then

                    PlanStaff.UtilizationVariancePercentage = Math.Round(CDbl(PlanStaff.UtilizationVariance / PlanStaff.DirectHoursGoal), 2)

                Else

                    PlanStaff.UtilizationVariancePercentage = 0

                End If

                PlanStaff.EmployeeCost = Math.Round(CDbl(PlanStaff.DirectHoursGoal * RevenueResourcePlanStaff.Employee.CostRate.GetValueOrDefault(0)), 2)
                PlanStaff.PlanRevenue = Math.Round(CDbl(PlanStaff.DirectHoursGoal * RevenueResourcePlanStaff.Employee.BillRate.GetValueOrDefault(0)), 2)
                PlanStaff.CostRevenueVariance = PlanStaff.PlanRevenue - PlanStaff.EmployeeCost

                If PlanStaff.EmployeeCost <> 0 Then

                    PlanStaff.CostRevenueVariancePercentage = Math.Round(CDbl(PlanStaff.CostRevenueVariance / PlanStaff.EmployeeCost), 2)

                Else

                    PlanStaff.CostRevenueVariancePercentage = 0

                End If

            End If

        End Sub
        Public Function GetPlanDates(Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan) As Generic.List(Of Date)

            GetPlanDates = GetPlanDates(Plan.StartDate, Plan.EndDate)

        End Function
        Public Function GetPlanDates(StartDate As Date, EndDate As Date) As Generic.List(Of Date)

            'objects
            Dim PlanDates As Generic.List(Of Date) = Nothing
            Dim PlanDate As Date = Date.MinValue

            PlanDates = New Generic.List(Of Date)

            For DateCounter As Integer = 0 To DateDiff(DateInterval.Month, StartDate, EndDate)

                PlanDate = StartDate.AddMonths(DateCounter)

                If PlanDate > EndDate Then

                    Exit For

                Else

                    PlanDates.Add(PlanDate)

                End If

            Next

            GetPlanDates = PlanDates

        End Function

#End Region


#Region "  Setup "

        Public Function Setup_Load() As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel

            'objects
            Dim SetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            SetupViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                SetupViewModel.Plans = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan)
                SetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.SetupFormDashboardDataSource)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanSetup)

                If Dashboard IsNot Nothing Then

                    SetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                Else

                    SetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                End If

            End Using

            Setup_Load = SetupViewModel

        End Function
        Public Sub Setup_LoadPlans(ByRef SetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel)

            'objects
            Dim MediaBroadcastWorksheets As Generic.List(Of AdvantageFramework.Database.Entities.MediaBroadcastWorksheet) = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                SetupViewModel.Plans = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan)
                SetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.SetupFormDashboardDataSource)

                For Each Plan In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").ToList

                    SetupViewModel.Plans.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(Plan))
                    SetupViewModel.DashboardDataSource.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.SetupFormDashboardDataSource(Plan))

                Next

            End Using

        End Sub
        Public Sub Setup_SelectedPlanChanged(ByRef SetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel,
                                             Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan)

            SetupViewModel.SelectedPlan = Plan

        End Sub
        Public Sub Setup_SaveDashboard(ByRef SetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.SetupViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanSetup)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanSetup
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            SetupViewModel.Dashboard.Layout = DashboardLayout

        End Sub

#End Region

#Region "  Edit "

        Public Function Edit_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel

            'objects
            Dim EditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing

            EditViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                Try

                    RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                Catch ex As Exception
                    RevenueResourcePlan = Nothing
                End Try

                If RevenueResourcePlan IsNot Nothing Then

                    EditViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                Else

                    EditViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan()

                End If

                EditViewModel.Offices = AdvantageFramework.Database.Procedures.Office.LoadAllActiveWithOfficeLimits(DbContext, Me.Session).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList
                EditViewModel.Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActiveWithOfficeLimits(Me.Session, DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList
                EditViewModel.Months = [Enum].GetValues(GetType(AdvantageFramework.DateUtilities.Months)).Cast(Of AdvantageFramework.DateUtilities.Months).ToList.Select(Function(Month) New AdvantageFramework.DTO.ComboBoxItem(Month)).ToList

            End Using

            Edit_Load = EditViewModel

        End Function
        Public Sub Edit_Add(ByRef EditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel, ByRef ErrorMessage As String)

            'objects
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                RevenueResourcePlan = New AdvantageFramework.Database.Entities.RevenueResourcePlan

                EditViewModel.Plan.SaveToEntity(RevenueResourcePlan)

                DbContext.RevenueResourcePlans.Add(RevenueResourcePlan)

                DbContext.SaveChanges()

                EditViewModel.Plan.ID = RevenueResourcePlan.ID

            End Using

        End Sub
        Public Sub Edit_Save(ByRef EditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel, ByRef ErrorMessage As String)

            'objects
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlan = DbContext.RevenueResourcePlans.Find(EditViewModel.Plan.ID)

                If RevenueResourcePlan IsNot Nothing Then

                    'If RevenueResourcePlan.StartDate <> EditViewModel.Plan.StartDate OrElse
                    '        RevenueResourcePlan.EndDate <> EditViewModel.Plan.EndDate Then

                    '    DatesHaveChanged = True

                    'End If

                    EditViewModel.Plan.SaveToEntity(RevenueResourcePlan)

                    DbContext.Configuration.AutoDetectChangesEnabled = True

                    DbContext.SaveChanges()

                End If

            End Using

        End Sub
        Public Function Edit_ValidateDates(ByRef EditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.EditViewModel, ByRef ErrorMessage As String) As Boolean

            Edit_ValidateDates = ValidatePlanDates(EditViewModel.Plan, ErrorMessage)

        End Function

#End Region

#Region "  Staff Manage "

        Public Function StaffManage_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel

            'objects
            Dim StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing

            StaffManageViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                StaffManageViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

            End Using

            StaffManage_LoadPlanStaff(StaffManageViewModel)

            StaffManage_Load = StaffManageViewModel

        End Function
        Public Sub StaffManage_DeletePlanStaff(ByRef StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel,
                                               PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            If PlanStaff IsNot Nothing AndAlso PlanStaff.ID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    RevenueResourcePlanStaff = DbContext.RevenueResourcePlanStaffs.Find(PlanStaff.ID)

                    If RevenueResourcePlanStaff IsNot Nothing Then

                        DbContext.Entry(RevenueResourcePlanStaff).Collection("RevenueResourcePlanStaffClients").Load()

                        For Each RevenueResourcePlanStaffClient In RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.ToList

                            DbContext.RevenueResourcePlanStaffClients.Remove(RevenueResourcePlanStaffClient)

                        Next

                        DbContext.RevenueResourcePlanStaffs.Remove(RevenueResourcePlanStaff)

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                        StaffManageViewModel.PlanStaffs.Remove(PlanStaff)

                    End If

                End Using

            End If

        End Sub
        Public Sub StaffManage_SavePlanStaff(ByRef StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel,
                                             PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            If PlanStaff IsNot Nothing AndAlso PlanStaff.ID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    RevenueResourcePlanStaff = DbContext.RevenueResourcePlanStaffs.Find(PlanStaff.ID)

                    If RevenueResourcePlanStaff IsNot Nothing Then

                        PlanStaff.SaveToEntity(RevenueResourcePlanStaff)

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                    End If

                End Using

            End If

        End Sub
        Public Sub StaffManage_SaveDirectPercentGoal(ByRef StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel,
                                                     PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing
            Dim Employee As AdvantageFramework.Database.Views.Employee = Nothing

            If PlanStaff IsNot Nothing AndAlso PlanStaff.ID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    RevenueResourcePlanStaff = DbContext.RevenueResourcePlanStaffs.Find(PlanStaff.ID)

                    If PlanStaff.IsAlternateEmployee Then

                        If RevenueResourcePlanStaff IsNot Nothing Then

                            PlanStaff.SaveToEntity(RevenueResourcePlanStaff)

                            DbContext.Configuration.AutoDetectChangesEnabled = True

                            DbContext.SaveChanges()

                            LoadPlanStaffProperties(DbContext, StaffManageViewModel.Plan, PlanStaff, RevenueResourcePlanStaff)

                        End If

                    Else

                        Employee = DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).SingleOrDefault(Function(Entity) Entity.Code = PlanStaff.EmployeeCode)

                        If Employee IsNot Nothing AndAlso RevenueResourcePlanStaff IsNot Nothing Then

                            Employee.DirectHours = (PlanStaff.DirectPercentGoal * 100)

                            AdvantageFramework.Database.Procedures.EmployeeView.UpdateDirectHours(DbContext, Employee, Employee.DirectHours)

                            LoadPlanStaffProperties(DbContext, StaffManageViewModel.Plan, PlanStaff, RevenueResourcePlanStaff)

                        End If

                    End If

                End Using

            End If

        End Sub
        Public Sub StaffManage_LoadPlanStaff(ByRef StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel)

            'objects
            Dim RevenueResourcePlanStaffs As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff) = Nothing
            Dim RevenueResourcePlanID As Integer = 0
            Dim PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff = Nothing

            RevenueResourcePlanID = StaffManageViewModel.Plan.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanStaffs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff).Include("Employee").
                                                                                                                                 Include("Office").
                                                                                                                                 Include("EmployeeTitle").
                                                                                                                                 Include("DepartmentTeam").
                                                                                                                                 Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList

                StaffManageViewModel.PlanStaffs = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)

                For Each RevenueResourcePlanStaff In RevenueResourcePlanStaffs

                    PlanStaff = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff(RevenueResourcePlanStaff)

                    LoadPlanStaffProperties(DbContext, StaffManageViewModel.Plan, PlanStaff, RevenueResourcePlanStaff)

                    StaffManageViewModel.PlanStaffs.Add(PlanStaff)

                Next

            End Using

        End Sub
        Public Sub StaffManage_SelectedStaffChanged(ByRef StaffManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffManageViewModel,
                                                    PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff)

            StaffManageViewModel.SelectedPlanStaff = PlanStaff

        End Sub

#End Region

#Region "  Staff Employees Edit "

        Public Function StaffEmployeesEdit_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel

            'objects
            Dim StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanStaffs As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff) = Nothing
            Dim Employees As Generic.List(Of AdvantageFramework.Database.Views.Employee) = Nothing

            StaffEmployeesEditViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                StaffEmployeesEditViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanStaffs = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff).Include("Employee").
                                                                                                                                 Include("Office").
                                                                                                                                 Include("EmployeeTitle").
                                                                                                                                 Include("DepartmentTeam").
                                                                                                                                 Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList

                Employees = DbContext.GetQuery(Of AdvantageFramework.Database.Views.Employee).Include("Office").
                                                                                              Include("EmployeeTitle").
                                                                                              Include("DepartmentTeam").ToList

                RevenueResourcePlanStaffs = RevenueResourcePlanStaffs.Where(Function(Entity) String.IsNullOrWhiteSpace(Entity.EmployeeCode) = False).ToList

                StaffEmployeesEditViewModel.PlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

                For Each RevenueResourcePlanStaff In RevenueResourcePlanStaffs

                    StaffEmployeesEditViewModel.PlanStaffEmployees.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee(RevenueResourcePlanStaff))

                Next

                Employees = Employees.Where(Function(Entity) RevenueResourcePlanStaffs.Any(Function(RRPS) RRPS.EmployeeCode = Entity.Code) = False).ToList

                StaffEmployeesEditViewModel.AvailablePlanStaffEmployees = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee)

                For Each Emp In Employees

                    If Emp.TerminationDate.HasValue = False OrElse (Emp.TerminationDate.HasValue AndAlso Emp.TerminationDate.Value > Now) Then

                        StaffEmployeesEditViewModel.AvailablePlanStaffEmployees.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee(RevenueResourcePlanID, Emp))

                    End If

                Next

            End Using

            StaffEmployeesEdit_Load = StaffEmployeesEditViewModel

        End Function
        Public Sub StaffEmployeesEdit_Save(ByRef StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel, ByRef ErrorMessage As String)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each AvailablePlanStaffEmployee In StaffEmployeesEditViewModel.AvailablePlanStaffEmployees

                    RevenueResourcePlanStaff = Nothing

                    If AvailablePlanStaffEmployee.ID <> 0 Then

                        Try

                            RevenueResourcePlanStaff = DbContext.RevenueResourcePlanStaffs.Find(AvailablePlanStaffEmployee.ID)

                        Catch ex As Exception
                            RevenueResourcePlanStaff = Nothing
                        End Try

                        If RevenueResourcePlanStaff IsNot Nothing Then

                            DbContext.RevenueResourcePlanStaffs.Remove(RevenueResourcePlanStaff)

                        End If

                    End If

                Next

                For Each PlanStaffEmployee In StaffEmployeesEditViewModel.PlanStaffEmployees

                    RevenueResourcePlanStaff = Nothing

                    If PlanStaffEmployee.ID = 0 Then

                        RevenueResourcePlanStaff = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaff

                        RevenueResourcePlanStaff.RevenueResourcePlanID = StaffEmployeesEditViewModel.Plan.ID
                        RevenueResourcePlanStaff.Notes = String.Empty

                        PlanStaffEmployee.SaveToEntity(RevenueResourcePlanStaff)

                        DbContext.RevenueResourcePlanStaffs.Add(RevenueResourcePlanStaff)

                    End If

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub StaffEmployeesEdit_SelectedAvailablePlanStaffEmployeeChanged(ByRef StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel,
                                                                               PlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee))

            StaffEmployeesEditViewModel.SelectedAvailablePlanStaffEmployees = PlanStaffEmployees

        End Sub
        Public Sub StaffEmployeesEdit_SelectedPlanStaffEmployeeChanged(ByRef StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel,
                                                                      PlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee))

            StaffEmployeesEditViewModel.SelectedPlanStaffEmployees = PlanStaffEmployees

        End Sub
        Public Sub StaffEmployeesEdit_AddEmployees(ByRef StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel,
                                                   PlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee))

            For Each PlanStaffEmployee In PlanStaffEmployees

                StaffEmployeesEditViewModel.AvailablePlanStaffEmployees.Remove(PlanStaffEmployee)
                StaffEmployeesEditViewModel.PlanStaffEmployees.Add(PlanStaffEmployee)

            Next

        End Sub
        Public Sub StaffEmployeesEdit_DeleteEmployees(ByRef StaffEmployeesEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffEmployeesEditViewModel,
                                                      PlanStaffEmployees As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffEmployee))

            For Each PlanStaffEmployee In PlanStaffEmployees

                StaffEmployeesEditViewModel.PlanStaffEmployees.Remove(PlanStaffEmployee)
                StaffEmployeesEditViewModel.AvailablePlanStaffEmployees.Add(PlanStaffEmployee)

            Next

        End Sub

#End Region

#Region "  Staff Alt Employee Edit "

        Public Function StaffAltEmployeeEdit_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel

            'objects
            Dim StaffAltEmployeeEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            StaffAltEmployeeEditViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                StaffAltEmployeeEditViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                If RevenueResourcePlanStaffID <> 0 Then

                    Try

                        RevenueResourcePlanStaff = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff).Include("Employee").
                                                                                                                                        Include("Office").
                                                                                                                                        Include("EmployeeTitle").
                                                                                                                                        Include("DepartmentTeam").
                                                                                                                                        SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanStaffID)

                    Catch ex As Exception
                        RevenueResourcePlanStaff = Nothing
                    End Try

                End If

                If RevenueResourcePlanStaff IsNot Nothing Then

                    StaffAltEmployeeEditViewModel.PlanStaffAltEmployee = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee(RevenueResourcePlanStaff)

                Else

                    StaffAltEmployeeEditViewModel.PlanStaffAltEmployee = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffAltEmployee()

                End If

                StaffAltEmployeeEditViewModel.Offices = (From Entity In AdvantageFramework.Database.Procedures.Office.LoadAllActive(DbContext).ToList
                                                         Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                StaffAltEmployeeEditViewModel.EmployeeTitles = (From Entity In AdvantageFramework.Database.Procedures.EmployeeTitle.LoadAllActive(DbContext).ToList
                                                                Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                StaffAltEmployeeEditViewModel.DepartmentTeams = (From Entity In AdvantageFramework.Database.Procedures.DepartmentTeam.LoadAllActive(DbContext).ToList
                                                                 Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                StaffAltEmployeeEditViewModel.RevenueResourcePlanStaffTypes = (From Entity In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffType).ToList
                                                                               Select New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            StaffAltEmployeeEdit_Load = StaffAltEmployeeEditViewModel

        End Function
        Public Sub StaffAltEmployeeEdit_Add(ByRef StaffAltEmployeeEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanStaff = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaff

                RevenueResourcePlanStaff.RevenueResourcePlanID = StaffAltEmployeeEditViewModel.Plan.ID

                StaffAltEmployeeEditViewModel.PlanStaffAltEmployee.SaveToEntity(RevenueResourcePlanStaff)

                DbContext.RevenueResourcePlanStaffs.Add(RevenueResourcePlanStaff)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub StaffAltEmployeeEdit_Update(ByRef StaffAltEmployeeEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel)

            'objects
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                Try

                    RevenueResourcePlanStaff = DbContext.RevenueResourcePlanStaffs.Find(StaffAltEmployeeEditViewModel.PlanStaffAltEmployee.ID)

                Catch ex As Exception
                    RevenueResourcePlanStaff = Nothing
                End Try

                If RevenueResourcePlanStaff IsNot Nothing Then

                    StaffAltEmployeeEditViewModel.PlanStaffAltEmployee.SaveToEntity(RevenueResourcePlanStaff)

                End If

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Function StaffAltEmployeeEdit_Validate(ByRef StaffAltEmployeeEditViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffAltEmployeeEditViewModel, ByRef ErrorMessage As String) As Boolean

            StaffAltEmployeeEdit_Validate = True

        End Function

#End Region

#Region "  Staff Client Assignment "

        Public Function StaffClientAssignment_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel

            'objects
            Dim StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanStaff As AdvantageFramework.Database.Entities.RevenueResourcePlanStaff = Nothing

            StaffClientAssignmentsViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                StaffClientAssignmentsViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanStaff = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff).Include("Employee").
                                                                                                                                Include("Office").
                                                                                                                                Include("EmployeeTitle").
                                                                                                                                Include("DepartmentTeam").
                                                                                                                                SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanStaffID)

                StaffClientAssignmentsViewModel.PlanStaff = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff(RevenueResourcePlanStaff)

                LoadPlanStaffProperties(DbContext, StaffClientAssignmentsViewModel.Plan, StaffClientAssignmentsViewModel.PlanStaff, RevenueResourcePlanStaff)

            End Using

            StaffClientAssignment_LoadPlanStaffClientAssignments(StaffClientAssignmentsViewModel)

            StaffClientAssignment_Load = StaffClientAssignmentsViewModel

        End Function
        Public Sub StaffClientAssignment_Save(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel)

            'objects
            Dim RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each PlanStaffClientAssignment In StaffClientAssignmentsViewModel.PlanStaffClientAssignments

                    Try

                        RevenueResourcePlanStaffClient = DbContext.RevenueResourcePlanStaffClients.Find(PlanStaffClientAssignment.ID)

                    Catch ex As Exception
                        RevenueResourcePlanStaffClient = Nothing
                    End Try

                    If RevenueResourcePlanStaffClient IsNot Nothing Then

                        PlanStaffClientAssignment.SaveToEntity(RevenueResourcePlanStaffClient)

                    End If

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub StaffClientAssignment_DeletePlanStaffClientAssignment(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel,
                                                                         PlanStaffClientAssignment As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

            'objects
            Dim RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient = Nothing

            If PlanStaffClientAssignment IsNot Nothing AndAlso PlanStaffClientAssignment.ID > 0 Then

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()
                    DbContext.Configuration.AutoDetectChangesEnabled = False

                    RevenueResourcePlanStaffClient = DbContext.RevenueResourcePlanStaffClients.Find(PlanStaffClientAssignment.ID)

                    If RevenueResourcePlanStaffClient IsNot Nothing Then

                        DbContext.RevenueResourcePlanStaffClients.Remove(RevenueResourcePlanStaffClient)

                        DbContext.Configuration.AutoDetectChangesEnabled = True

                        DbContext.SaveChanges()

                        StaffClientAssignmentsViewModel.PlanStaffClientAssignments.Remove(PlanStaffClientAssignment)

                    End If

                End Using

            End If

        End Sub
        Public Sub StaffClientAssignment_LoadPlanStaffClientAssignments(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel)

            'objects
            Dim RevenueResourcePlanStaffClients As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient) = Nothing
            Dim RevenueResourcePlanStaffID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanStaffID = StaffClientAssignmentsViewModel.PlanStaff.ID

                StaffClientAssignmentsViewModel.PlanStaffClientAssignments = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

                RevenueResourcePlanStaffClients = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient).Where(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID).ToList

                For Each RevenueResourcePlanStaffClient In RevenueResourcePlanStaffClients

                    StaffClientAssignmentsViewModel.PlanStaffClientAssignments.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment(DbContext, StaffClientAssignmentsViewModel.Plan, RevenueResourcePlanStaffClient))

                Next

            End Using

        End Sub
        Public Function StaffClientAssignment_Validate(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel) As Boolean

            'objects
            Dim IsValid As Boolean = False
            Dim TotalPercent As Decimal = 0

            For Each PlanStaffClientAssignment In StaffClientAssignmentsViewModel.PlanStaffClientAssignments

                TotalPercent += PlanStaffClientAssignment.Percent

            Next

            If TotalPercent <= 1 Then

                IsValid = True

            End If

            StaffClientAssignment_Validate = IsValid

        End Function
        Public Sub StaffClientAssignment_PercentChanged(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel,
                                                        PlanStaffClientAssignment As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment,
                                                        Percent As Decimal)

            PlanStaffClientAssignment.Hours = (PlanStaffClientAssignment.HoursAvailable * Percent)

        End Sub
        Public Sub StaffClientAssignment_SelectedPlanStaffClientAssignmentChanged(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel,
                                                                                  PlanStaffClientAssignment As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

            StaffClientAssignmentsViewModel.SelectedPlanStaffClientAssignment = PlanStaffClientAssignment

        End Sub
        Public Sub StaffClientAssignment_UserEntryChanged(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel)

            StaffClientAssignmentsViewModel.SaveEnabled = True
            StaffClientAssignmentsViewModel.CancelEnabled = True

        End Sub
        Public Sub StaffClientAssignment_ClearChanged(ByRef StaffClientAssignmentsViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsViewModel)

            StaffClientAssignmentsViewModel.SaveEnabled = False
            StaffClientAssignmentsViewModel.CancelEnabled = False

        End Sub

#End Region

#Region "  Staff Client Assignment Add CDP"

        Public Function StaffClientAssignmentAddCDP_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanStaffID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel

            'objects
            Dim StaffClientAssignmentsAddCDPViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel = Nothing
            Dim RevenueResourcePlanStaffClients As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient) = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan = Nothing

            StaffClientAssignmentsAddCDPViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                StaffClientAssignmentsAddCDPViewModel.PlanID = RevenueResourcePlanID
                StaffClientAssignmentsAddCDPViewModel.PlanStaffID = RevenueResourcePlanStaffID

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanStaffClients = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient).Where(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID).ToList

                StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment)

                For Each RevenueResourcePlanStaffClient In RevenueResourcePlanStaffClients.ToList

                    StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment(DbContext, Plan, RevenueResourcePlanStaffClient))

                Next

                StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentClients = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient)

                For Each Client In AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                    If StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Client.Code) = False Then

                        StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentClients.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentClient(Client))

                    End If

                Next

                'StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentDivisions = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentDivision)

                'For Each Division In AdvantageFramework.Database.Procedures.DivisionView.Load(DbContext).Where(Function(Entity) Entity.IsActive = 1).ToList

                '    If StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Division.ClientCode AndAlso
                '                                                                                             Entity.DivisionCode = Nothing AndAlso
                '                                                                                             Entity.ProductCode = Nothing) = False AndAlso
                '            StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Division.ClientCode AndAlso
                '                                                                                                  Entity.DivisionCode = Division.DivisionCode) = False Then

                '        StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentDivisions.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentDivision(Division))

                '    End If

                'Next

                'StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentProducts = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct)

                'For Each Product In AdvantageFramework.Database.Procedures.ProductView.LoadAllActive(DbContext).ToList

                '    If StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Product.ClientCode AndAlso
                '                                                                                             Entity.DivisionCode = Nothing AndAlso
                '                                                                                             Entity.ProductCode = Nothing) = False AndAlso
                '            StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Product.ClientCode AndAlso
                '                                                                                                  Entity.DivisionCode = Product.DivisionCode AndAlso
                '                                                                                                  Entity.ProductCode = Nothing) = False AndAlso
                '            StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignments.Any(Function(Entity) Entity.ClientCode = Product.ClientCode AndAlso
                '                                                                                                  Entity.DivisionCode = Product.DivisionCode AndAlso
                '                                                                                                  Entity.ProductCode = Product.ProductCode) = False Then

                '        StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentProducts.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignmentProduct(Product))

                '    End If

                'Next

            End Using

            StaffClientAssignmentAddCDP_Load = StaffClientAssignmentsAddCDPViewModel

        End Function
        Public Sub StaffClientAssignmentAddCDP_Save(ByRef StaffClientAssignmentsAddCDPViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel)

            'objects
            Dim RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient = Nothing
            Dim RevenueResourcePlanStaffID As Integer = 0

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanStaffID = StaffClientAssignmentsAddCDPViewModel.PlanStaffID

                For Each PlanStaffClientAssignmentClient In StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentClients

                    If PlanStaffClientAssignmentClient.Selected Then

                        If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient).Any(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID AndAlso
                                                                                                                                           Entity.ClientCode = PlanStaffClientAssignmentClient.ClientCode) = False Then

                            RevenueResourcePlanStaffClient = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient

                            RevenueResourcePlanStaffClient.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID
                            RevenueResourcePlanStaffClient.ClientCode = PlanStaffClientAssignmentClient.ClientCode
                            RevenueResourcePlanStaffClient.DivisionCode = Nothing
                            RevenueResourcePlanStaffClient.ProductCode = Nothing
                            RevenueResourcePlanStaffClient.Percent = 0
                            RevenueResourcePlanStaffClient.Notes = String.Empty

                            DbContext.RevenueResourcePlanStaffClients.Add(RevenueResourcePlanStaffClient)

                        End If

                    End If

                Next

                'For Each PlanStaffClientAssignmentDivision In StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentDivisions

                '    If PlanStaffClientAssignmentDivision.Selected Then

                '        If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient).Any(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID AndAlso
                '                                                                                                                           Entity.ClientCode = PlanStaffClientAssignmentDivision.ClientCode AndAlso
                '                                                                                                                           Entity.DivisionCode = PlanStaffClientAssignmentDivision.DivisionCode) = False Then

                '            RevenueResourcePlanStaffClient = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient

                '            RevenueResourcePlanStaffClient.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID
                '            RevenueResourcePlanStaffClient.ClientCode = PlanStaffClientAssignmentDivision.ClientCode
                '            RevenueResourcePlanStaffClient.DivisionCode = PlanStaffClientAssignmentDivision.DivisionCode
                '            RevenueResourcePlanStaffClient.ProductCode = Nothing
                '            RevenueResourcePlanStaffClient.Percent = 0
                '            RevenueResourcePlanStaffClient.Notes = String.Empty

                '            DbContext.RevenueResourcePlanStaffClients.Add(RevenueResourcePlanStaffClient)

                '        End If

                '    End If

                'Next

                'For Each PlanStaffClientAssignmentProduct In StaffClientAssignmentsAddCDPViewModel.PlanStaffClientAssignmentProducts

                '    If PlanStaffClientAssignmentProduct.Selected Then

                '        If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient).Any(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID AndAlso
                '                                                                                                                           Entity.ClientCode = PlanStaffClientAssignmentProduct.ClientCode AndAlso
                '                                                                                                                           Entity.DivisionCode = PlanStaffClientAssignmentProduct.DivisionCode AndAlso
                '                                                                                                                           Entity.ProductCode = PlanStaffClientAssignmentProduct.ProductCode) = False Then

                '            RevenueResourcePlanStaffClient = New AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient

                '            RevenueResourcePlanStaffClient.RevenueResourcePlanStaffID = RevenueResourcePlanStaffID
                '            RevenueResourcePlanStaffClient.ClientCode = PlanStaffClientAssignmentProduct.ClientCode
                '            RevenueResourcePlanStaffClient.DivisionCode = PlanStaffClientAssignmentProduct.DivisionCode
                '            RevenueResourcePlanStaffClient.ProductCode = PlanStaffClientAssignmentProduct.ProductCode
                '            RevenueResourcePlanStaffClient.Percent = 0
                '            RevenueResourcePlanStaffClient.Notes = String.Empty

                '            DbContext.RevenueResourcePlanStaffClients.Add(RevenueResourcePlanStaffClient)

                '        End If

                '    End If

                'Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub StaffClientAssignmentAddCDP_UserEntryChanged(ByRef StaffClientAssignmentsAddCDPViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel)

            StaffClientAssignmentsAddCDPViewModel.SaveEnabled = True

        End Sub
        Public Sub StaffClientAssignmentAddCDP_ClearChanged(ByRef StaffClientAssignmentsAddCDPViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.StaffClientAssignmentsAddCDPViewModel)

            StaffClientAssignmentsAddCDPViewModel.SaveEnabled = False

        End Sub

#End Region

#Region "  Revenue Setup "

        Public Function RevenueSetup_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel

            'objects
            Dim RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanRevenues As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue) = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            RevenueSetupViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                RevenueSetupViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueSetupViewModel.PlanClientRevenues = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)

                RevenueSetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupFormDashboardDataSource)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanRevenueSetup)

                If Dashboard IsNot Nothing Then

                    RevenueSetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                Else

                    RevenueSetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                End If

                RevenueSetupViewModel.Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            RevenueSetup_LoadPlanClientRevenues(RevenueSetupViewModel)

            RevenueSetup_Load = RevenueSetupViewModel

        End Function
        Public Sub RevenueSetup_LoadPlanClientRevenues(ByRef RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel)

            'objects
            Dim RevenueResourcePlanRevenues As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue) = Nothing
            Dim RevenueResourcePlanID As Integer = 0
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            RevenueResourcePlanID = RevenueSetupViewModel.Plan.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanRevenues = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).Include("Client").
                                                                                                                                     Include("Employee").
                                                                                                                                     Include("RevenueResourcePlanRevenueRevisions").
                                                                                                                                     Include("RevenueResourcePlanRevenueRevisions.ApprovedByEmployee").
                                                                                                                                     Include("RevenueResourcePlanRevenueRevisions.RevenueResourcePlanRevenueDetails").
                                                                                                                                     Include("RevenueResourcePlanRevenueRevisions.RevenueResourcePlanRevenueDetails.RevenueResourcePlanRevenueDetailDates").
                                                                                                                                     Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList

                RevenueSetupViewModel.PlanClientRevenues = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)

                For Each RevenueResourcePlanRevenue In RevenueResourcePlanRevenues

                    RevenueSetupViewModel.PlanClientRevenues.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue(RevenueResourcePlanRevenue))

                Next

                RevenueSetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupFormDashboardDataSource)

                For Each PlanClientRevenue In RevenueSetupViewModel.PlanClientRevenues

                    RevenueResourcePlanRevenueRevision = RevenueResourcePlanRevenues.SelectMany(Function(Entity) Entity.RevenueResourcePlanRevenueRevisions).SingleOrDefault(Function(Entity) Entity.RevenueResourcePlanRevenueID = PlanClientRevenue.ID AndAlso Entity.RevisionNumber = PlanClientRevenue.RevisionNumber)

                    For Each RevenueResourcePlanRevenueDetail In RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenueDetails

                        For Each RevenueResourcePlanRevenueDetailDate In RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates

                            RevenueSetupViewModel.DashboardDataSource.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupFormDashboardDataSource(RevenueResourcePlanRevenueDetailDate, PlanClientRevenue.Client))

                        Next

                    Next

                Next

            End Using

        End Sub
        Public Sub RevenueSetup_SelectedPlanClientRevenueChanged(ByRef RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel,
                                                                 PlanClientRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)

            RevenueSetupViewModel.SelectedPlanClientRevenue = PlanClientRevenue

        End Sub
        Public Sub RevenueSetup_SaveDashboard(ByRef RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanRevenueSetup)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanRevenueSetup
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            RevenueSetupViewModel.Dashboard.Layout = DashboardLayout

        End Sub
        Public Sub RevenueSetup_Delete(ByRef RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel,
                                       PlanClientRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)

            'objects
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenue = DbContext.RevenueResourcePlanRevenues.Find(PlanClientRevenue.ID)

                DbContext.Entry(RevenueResourcePlanRevenue).Collection("RevenueResourcePlanRevenueRevisions").Load()

                For Each RevenueResourcePlanRevenueRevision In RevenueResourcePlanRevenue.RevenueResourcePlanRevenueRevisions.ToList

                    DbContext.Entry(RevenueResourcePlanRevenueRevision).Collection("RevenueResourcePlanRevenueDetails").Load()

                    For Each RevenueResourcePlanRevenueDetail In RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenueDetails.ToList

                        DbContext.Entry(RevenueResourcePlanRevenueDetail).Collection("RevenueResourcePlanRevenueDetailDates").Load()

                        For Each RevenueResourcePlanRevenueDetailDate In RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.ToList

                            DbContext.RevenueResourcePlanRevenueDetailDates.Remove(RevenueResourcePlanRevenueDetailDate)

                        Next

                        DbContext.RevenueResourcePlanRevenueDetails.Remove(RevenueResourcePlanRevenueDetail)

                    Next

                    DbContext.RevenueResourcePlanRevenueRevisions.Remove(RevenueResourcePlanRevenueRevision)

                Next

                DbContext.RevenueResourcePlanRevenues.Remove(RevenueResourcePlanRevenue)

                DbContext.Configuration.AutoDetectChangesEnabled = True
                DbContext.SaveChanges()

                RevenueSetupViewModel.PlanClientRevenues.Remove(PlanClientRevenue)

            End Using

        End Sub
        Public Sub RevenueSetup_Save(ByRef RevenueSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueSetupViewModel,
                                     PlanClientRevenue As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientRevenue)

            'objects
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenue = DbContext.RevenueResourcePlanRevenues.Find(PlanClientRevenue.ID)

                RevenueResourcePlanRevenue.EmployeeCode = If(String.IsNullOrWhiteSpace(PlanClientRevenue.OwnerCode) = False, PlanClientRevenue.OwnerCode, Nothing)
                RevenueResourcePlanRevenue.Notes = PlanClientRevenue.Notes

                RevenueResourcePlanRevenueRevision = DbContext.RevenueResourcePlanRevenueRevisions.Find(PlanClientRevenue.RevenueResourcePlanRevenueRevisionID)

                RevenueResourcePlanRevenueRevision.Notes = PlanClientRevenue.RevisionNotes

                DbContext.Configuration.AutoDetectChangesEnabled = True
                DbContext.SaveChanges()

            End Using

        End Sub

#End Region

#Region "  Revenue Add "

        Public Function RevenueAdd_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddViewModel

            'objects
            Dim RevenueAddViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddViewModel = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim RevenueResourcePlanRevenues As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue) = Nothing

            RevenueAddViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueAddViewModel.PlanID = RevenueResourcePlanID

                RevenueAddViewModel.PlanRevenue = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue

                RevenueAddViewModel.Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                RevenueResourcePlanRevenues = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList
                Clients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                For Each Client In Clients.ToList

                    If RevenueResourcePlanRevenues.Any(Function(Entity) Entity.ClientCode = Client.Code) Then

                        Clients.Remove(Client)

                    End If

                Next

                RevenueAddViewModel.Clients = Clients.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            RevenueAdd_Load = RevenueAddViewModel

        End Function
        Public Function RevenueAdd_Add(ByRef RevenueAddViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenue = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue

                RevenueResourcePlanRevenue.RevenueResourcePlanID = RevenueAddViewModel.PlanID

                RevenueAddViewModel.PlanRevenue.SaveToEntity(RevenueResourcePlanRevenue)
                DbContext.RevenueResourcePlanRevenues.Add(RevenueResourcePlanRevenue)

                RevenueResourcePlanRevenueRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision

                RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenue = RevenueResourcePlanRevenue
                RevenueResourcePlanRevenueRevision.RevisionNumber = 0
                RevenueResourcePlanRevenueRevision.Approved = False
                RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanRevenueRevision.ApprovedDate = Nothing
                RevenueResourcePlanRevenueRevision.Notes = String.Empty

                DbContext.RevenueResourcePlanRevenueRevisions.Add(RevenueResourcePlanRevenueRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).Any(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanRevenue.RevenueResourcePlanID AndAlso
                                                                                                                               Entity.ClientCode = RevenueResourcePlanRevenue.ClientCode) = False Then

                    DbContext.SaveChanges()

                    Added = True

                Else

                    ErrorMessage = "There is already a revenue plan for the client selected. Please select a different client."

                End If

            End Using

            RevenueAdd_Add = Added

        End Function

#End Region

#Region "  Revenue Manage "

        Public Function RevenueManage_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanRevenueID As Integer, RevenueResourcePlanRevenueRevisionID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel

            'objects
            Dim RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing
            Dim PlanRevenueRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision = Nothing

            RevenueManageViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueManageViewModel.RevenueResourcePlanID = RevenueResourcePlanID
                RevenueManageViewModel.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                RevenueManageViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanRevenue = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanRevenueID)

                RevenueManageViewModel.PlanRevenue = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenue(RevenueResourcePlanRevenue)

            End Using

            RevenueManage_GetDetailDates(RevenueManageViewModel)
            RevenueManage_CreateDataTableSchema(RevenueManageViewModel)
            RevenueManage_LoadRevisions(RevenueManageViewModel)

            Try

                PlanRevenueRevision = RevenueManageViewModel.PlanRevenueRevisions.SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanRevenueRevisionID)

            Catch ex As Exception
                PlanRevenueRevision = Nothing
            End Try

            If PlanRevenueRevision IsNot Nothing Then

                RevenueManage_SelectRevision(RevenueManageViewModel, PlanRevenueRevision.RevisionNumber)

            End If

            RevenueManageViewModel.SaveEnabled = False
            RevenueManageViewModel.CancelEnabled = False

            If RevenueManageViewModel.SelectedPlanRevenueRevision IsNot Nothing Then

                RevenueManageViewModel.ApproveVisible = Not RevenueManageViewModel.SelectedPlanRevenueRevision.Approved
                RevenueManageViewModel.Approved = RevenueManageViewModel.SelectedPlanRevenueRevision.Approved
                RevenueManageViewModel.ApprovedBy = RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedByEmployee
                RevenueManageViewModel.ApprovedByDate = If(RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedDate.HasValue, RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedDate.Value.ToShortDateString, String.Empty)

            End If

            RevenueManage_SelectedRowChanged(RevenueManageViewModel, 0)

            RevenueManage_Load = RevenueManageViewModel

        End Function
        Public Sub RevenueManage_Save(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanID As Integer = 0
            Dim RevenueResourcePlanRevenueID As Integer = 0
            Dim RevenueResourcePlanRevenueRevisionID As Integer = 0
            Dim RevenueResourcePlanRevenueDetailID As Integer = 0
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            RevenueResourcePlanID = RevenueManageViewModel.RevenueResourcePlanID
            RevenueResourcePlanRevenueID = RevenueManageViewModel.RevenueResourcePlanRevenueID
            RevenueResourcePlanRevenueRevisionID = RevenueManageViewModel.SelectedPlanRevenueRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each DataRow In RevenueManageViewModel.DataTable.Rows.OfType(Of System.Data.DataRow)

                    RevenueResourcePlanRevenueDetail = Nothing
                    RevenueResourcePlanRevenueDetailID = 0

                    If DataRow.RowState <> System.Data.DataRowState.Unchanged Then

                        RevenueResourcePlanRevenueDetailID = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueDetailID.ToString)

                        Try

                            RevenueResourcePlanRevenueDetail = DbContext.RevenueResourcePlanRevenueDetails.Find(RevenueResourcePlanRevenueDetailID)

                        Catch ex As Exception
                            RevenueResourcePlanRevenueDetail = Nothing
                        End Try

                        If RevenueResourcePlanRevenueDetail IsNot Nothing Then

                            RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueTypeID.ToString)
                            RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueStatusID.ToString)
                            RevenueResourcePlanRevenueDetail.Notes = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Notes.ToString)

                            For Each DetailDate In RevenueManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                                RevenueResourcePlanRevenueDetailDate = Nothing

                                Try

                                    RevenueResourcePlanRevenueDetailDate = DbContext.RevenueResourcePlanRevenueDetailDates.SingleOrDefault(Function(Entity) Entity.RevenueResourcePlanRevenueDetailID = RevenueResourcePlanRevenueDetail.ID AndAlso Entity.Date = DetailDate)

                                Catch ex As Exception
                                    RevenueResourcePlanRevenueDetailDate = Nothing
                                End Try

                                If RevenueResourcePlanRevenueDetailDate IsNot Nothing Then

                                    RevenueResourcePlanRevenueDetailDate.Revenue = DataRow(RevenueManageViewModel.DetailDates(DetailDate))

                                End If

                            Next

                        End If

                    End If

                Next

                For Each RevenueResourcePlanRevenueDetail In DbContext.RevenueResourcePlanRevenueDetails.Include("RevenueResourcePlanRevenueDetailDates").
                                                                                                         Where(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevisionID).ToList

                    If RevenueManageViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueDetailID.ToString) = RevenueResourcePlanRevenueDetail.ID) = False Then

                        For Each RevenueResourcePlanRevenueDetailDate In RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.ToList

                            DbContext.RevenueResourcePlanRevenueDetailDates.Remove(RevenueResourcePlanRevenueDetailDate)

                        Next

                        DbContext.RevenueResourcePlanRevenueDetails.Remove(RevenueResourcePlanRevenueDetail)

                    End If

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

                RevenueManageViewModel.DataTable.AcceptChanges()

            End Using

        End Sub
        Private Sub RevenueManage_GetDetailDates(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim DateCounter As Integer = 1
            Dim DetailDate As Date = Date.MinValue
            Dim PlanDates As Generic.List(Of Date) = Nothing

            PlanDates = GetPlanDates(RevenueManageViewModel.Plan)

            RevenueManageViewModel.DetailDates = New Hashtable

            For Each DetailDate In PlanDates

                RevenueManageViewModel.DetailDates(DetailDate) = "Date" & DateCounter

                DateCounter += 1

            Next

            DateCounter = 1

            RevenueManageViewModel.ActualDetailDates = New Hashtable

            For Each DetailDate In PlanDates

                RevenueManageViewModel.ActualDetailDates(DetailDate) = "Actual" & DateCounter

                DateCounter += 1

            Next

        End Sub
        Private Sub RevenueManage_CreateDataTableSchema(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DetailDate As Date = Date.MinValue

            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.ID.ToString)

            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            RevenueManageViewModel.DataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueDetailID.ToString)

            DataColumn.Caption = "Revenue Detail ID"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueTypeID.ToString)

            DataColumn.Caption = "Revenue Type"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = 1
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueStatusID.ToString)

            DataColumn.Caption = "Status"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = 1
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Client.ToString)

            DataColumn.Caption = "Client"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = String.Empty
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Division.ToString)

            DataColumn.Caption = "Division"
            DataColumn.AllowDBNull = True
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = DBNull.Value
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Product.ToString)

            DataColumn.Caption = "Product"
            DataColumn.AllowDBNull = True
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = DBNull.Value
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobNumber.ToString)

            DataColumn.Caption = "Job"
            DataColumn.AllowDBNull = True
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = DBNull.Value
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponentNumber.ToString)

            DataColumn.Caption = "Job\Component"
            DataColumn.AllowDBNull = True
            DataColumn.DataType = GetType(Short)
            DataColumn.DefaultValue = DBNull.Value
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponent.ToString)

            DataColumn.Caption = "Job\Component"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = String.Empty
            '=============
            DataColumn = RevenueManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Notes.ToString)

            DataColumn.Caption = "Notes"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = String.Empty
            '=============
            For Each DetailDate In RevenueManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                DataColumn = RevenueManageViewModel.DataTable.Columns.Add(RevenueManageViewModel.DetailDates(DetailDate))

                DataColumn.ExtendedProperties.Add("Date", DetailDate)

                DataColumn.Caption = DetailDate.ToString("MM/dd")

                DataColumn.AllowDBNull = False
                DataColumn.DataType = GetType(Integer)
                DataColumn.DefaultValue = 0

                DataColumn = RevenueManageViewModel.DataTable.Columns.Add(RevenueManageViewModel.ActualDetailDates(DetailDate))

                DataColumn.ExtendedProperties.Add("Date", DetailDate)

                DataColumn.Caption = DetailDate.ToString("MM/dd") & " Actual"

                DataColumn.AllowDBNull = False
                DataColumn.DataType = GetType(Decimal)
                DataColumn.DefaultValue = 0

            Next

        End Sub
        Public Sub RevenueManage_LoadRevisions(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanRevenueID As Integer = 0

            RevenueManageViewModel.PlanRevenueRevisions = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanRevenueID = RevenueManageViewModel.RevenueResourcePlanRevenueID

                For Each RevenueResourcePlanRevenueRevision In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision).Include("ApprovedByEmployee").
                                                                                                                                                              Include("RevenueResourcePlanRevenue").
                                                                                                                                                              Where(Function(Entity) Entity.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID).ToList

                    RevenueManageViewModel.PlanRevenueRevisions.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision(RevenueResourcePlanRevenueRevision))

                Next

            End Using

        End Sub
        Public Sub RevenueManage_SelectRevision(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel,
                                                RevisionNumber As Integer)

            'objects
            Dim PlanRevenueRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision = Nothing

            Try

                PlanRevenueRevision = RevenueManageViewModel.PlanRevenueRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = RevisionNumber)

            Catch ex As Exception
                PlanRevenueRevision = Nothing
            End Try

            RevenueManageViewModel.SelectedPlanRevenueRevision = PlanRevenueRevision

            RevenueManage_LoadDetails(RevenueManageViewModel)

        End Sub
        Public Sub RevenueManage_CreateRevision(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing
            Dim RevenueResourcePlanRevenueID As Integer = 0
            Dim RevisionNumber As Integer = -1
            Dim PlanRevenueRevisionID As Integer = 0
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing
            Dim PlanRevenueRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision = Nothing

            RevenueResourcePlanRevenueID = RevenueManageViewModel.RevenueResourcePlanRevenueID

            PlanRevenueRevisionID = RevenueManageViewModel.SelectedPlanRevenueRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevisionNumber = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision).Where(Function(Entity) Entity.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID).Max(Function(Entity) Entity.RevisionNumber) + 1

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenueRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision

                RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID
                RevenueResourcePlanRevenueRevision.RevisionNumber = RevisionNumber
                RevenueResourcePlanRevenueRevision.Approved = False
                RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanRevenueRevision.ApprovedDate = Nothing
                RevenueResourcePlanRevenueRevision.Notes = String.Empty

                DbContext.RevenueResourcePlanRevenueRevisions.Add(RevenueResourcePlanRevenueRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each CopyFromRevenueResourcePlanRevenueDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Include("RevenueResourcePlanRevenueDetailDates").
                                                                                                                                                                  Where(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = PlanRevenueRevisionID).ToList

                    RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevision.ID

                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = CopyFromRevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = CopyFromRevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID

                    RevenueResourcePlanRevenueDetail.ClientCode = CopyFromRevenueResourcePlanRevenueDetail.ClientCode
                    RevenueResourcePlanRevenueDetail.DivisionCode = CopyFromRevenueResourcePlanRevenueDetail.DivisionCode
                    RevenueResourcePlanRevenueDetail.ProductCode = CopyFromRevenueResourcePlanRevenueDetail.ProductCode
                    RevenueResourcePlanRevenueDetail.JobNumber = CopyFromRevenueResourcePlanRevenueDetail.JobNumber
                    RevenueResourcePlanRevenueDetail.JobComponentNumber = CopyFromRevenueResourcePlanRevenueDetail.JobComponentNumber
                    RevenueResourcePlanRevenueDetail.Notes = CopyFromRevenueResourcePlanRevenueDetail.Notes

                    DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                    For Each CopyFromRevenueResourcePlanRevenueDetailDate In CopyFromRevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.ToList

                        RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                        RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                        RevenueResourcePlanRevenueDetailDate.Date = CopyFromRevenueResourcePlanRevenueDetailDate.Date
                        RevenueResourcePlanRevenueDetailDate.Revenue = CopyFromRevenueResourcePlanRevenueDetailDate.Revenue

                        DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                    Next

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            RevenueManage_LoadRevisions(RevenueManageViewModel)

            Try

                PlanRevenueRevision = RevenueManageViewModel.PlanRevenueRevisions.SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanRevenueRevision.ID)

            Catch ex As Exception
                PlanRevenueRevision = Nothing
            End Try

            If PlanRevenueRevision IsNot Nothing Then

                RevenueManage_SelectRevision(RevenueManageViewModel, PlanRevenueRevision.RevisionNumber)

            End If

        End Sub
        Public Sub RevenueManage_DeleteRevision(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing
            Dim PlanRevenueRevisionID As Integer = 0
            Dim MaxRevisionNumber As Integer = 1
            Dim PlanRevenueRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanRevenueRevision = Nothing

            PlanRevenueRevisionID = RevenueManageViewModel.SelectedPlanRevenueRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenueRevision = DbContext.RevenueResourcePlanRevenueRevisions.Include("RevenueResourcePlanRevenueDetails").Include("RevenueResourcePlanRevenueDetails.RevenueResourcePlanRevenueDetailDates").
                                                                                                   SingleOrDefault(Function(Entity) Entity.ID = PlanRevenueRevisionID)

                For Each RevenueResourcePlanRevenueDetail In RevenueResourcePlanRevenueRevision.RevenueResourcePlanRevenueDetails.ToList

                    For Each RevenueResourcePlanRevenueDetailDate In RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.ToList

                        DbContext.RevenueResourcePlanRevenueDetailDates.Remove(RevenueResourcePlanRevenueDetailDate)

                    Next

                    DbContext.RevenueResourcePlanRevenueDetails.Remove(RevenueResourcePlanRevenueDetail)

                Next

                DbContext.RevenueResourcePlanRevenueRevisions.Remove(RevenueResourcePlanRevenueRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            RevenueManage_LoadRevisions(RevenueManageViewModel)

            Try

                MaxRevisionNumber = RevenueManageViewModel.PlanRevenueRevisions.Max(Function(Entity) Entity.RevisionNumber)

            Catch ex As Exception
                MaxRevisionNumber = -1
            End Try

            Try

                PlanRevenueRevision = RevenueManageViewModel.PlanRevenueRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = MaxRevisionNumber)

            Catch ex As Exception
                PlanRevenueRevision = Nothing
            End Try

            If PlanRevenueRevision IsNot Nothing Then

                RevenueManage_SelectRevision(RevenueManageViewModel, PlanRevenueRevision.RevisionNumber)

            End If

        End Sub
        Public Sub RevenueManage_LoadDetails(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim PlanRevenueRevisionID As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            If RevenueManageViewModel.SelectedPlanRevenueRevision IsNot Nothing Then

                RevenueManageViewModel.DataTable.Rows.Clear()

                PlanRevenueRevisionID = RevenueManageViewModel.SelectedPlanRevenueRevision.ID

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    RevenueManageViewModel.DataTable.BeginLoadData()

                    For Each RevenueResourcePlanRevenueDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Include("JobComponent").Include("JobComponent.Job").Include("RevenueResourcePlanRevenueDetailDates").
                                                                                                                                                              Include("Client").Include("Division").Include("Product").
                                                                                                                                                              Where(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = PlanRevenueRevisionID).ToList

                        DataRow = RevenueManageViewModel.DataTable.NewRow()

                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueDetailID.ToString) = RevenueResourcePlanRevenueDetail.ID
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueTypeID.ToString) = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.RevenueStatusID.ToString) = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Client.ToString) = RevenueResourcePlanRevenueDetail.Client.Name
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Division.ToString) = If(RevenueResourcePlanRevenueDetail.Division IsNot Nothing, RevenueResourcePlanRevenueDetail.Division.Name, System.DBNull.Value)
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Product.ToString) = If(RevenueResourcePlanRevenueDetail.Product IsNot Nothing, RevenueResourcePlanRevenueDetail.Product.Name, System.DBNull.Value)
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobNumber.ToString) = If(RevenueResourcePlanRevenueDetail.JobNumber.HasValue, RevenueResourcePlanRevenueDetail.JobNumber.Value, System.DBNull.Value)
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponentNumber.ToString) = If(RevenueResourcePlanRevenueDetail.JobComponentNumber.HasValue, RevenueResourcePlanRevenueDetail.JobComponentNumber.Value, System.DBNull.Value)
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.JobComponent.ToString) = If(RevenueResourcePlanRevenueDetail.JobComponent IsNot Nothing, RevenueResourcePlanRevenueDetail.JobComponent.ToString(True, True), String.Empty)
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueDetailColumns.Notes.ToString) = RevenueResourcePlanRevenueDetail.Notes

                        For Each DetailDate In RevenueManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                            RevenueResourcePlanRevenueDetailDate = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueDetailDates.SingleOrDefault(Function(Entity) Entity.Date = DetailDate)

                            If RevenueResourcePlanRevenueDetailDate IsNot Nothing Then

                                DataRow(RevenueManageViewModel.DetailDates(DetailDate)) = RevenueResourcePlanRevenueDetailDate.Revenue

                            Else

                                DataRow(RevenueManageViewModel.DetailDates(DetailDate)) = 0

                            End If

                        Next

                        RevenueManageViewModel.DataTable.Rows.Add(DataRow)

                    Next

                    RevenueManageViewModel.DataTable.EndLoadData()

                End Using

            End If

        End Sub
        Public Sub RevenueManage_UserEntryChanged(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            RevenueManageViewModel.SaveEnabled = True
            RevenueManageViewModel.CancelEnabled = True

            RevenueManageViewModel.CreateRevisionEnabled = (RevenueManageViewModel.SaveEnabled = False AndAlso
                                                            RevenueManageViewModel.HasASelectedRevision AndAlso
                                                            RevenueManageViewModel.IsMaxRevisionNumber AndAlso
                                                            RevenueManageViewModel.DataTable.Rows.Count > 0 AndAlso
                                                            RevenueManageViewModel.Approved = False)

            RevenueManageViewModel.DeleteRevisionEnabled = (RevenueManageViewModel.SaveEnabled = False AndAlso
                                                            RevenueManageViewModel.HasASelectedRevision AndAlso
                                                            RevenueManageViewModel.IsMaxRevisionNumber AndAlso
                                                            RevenueManageViewModel.SelectedPlanRevenueRevision.RevisionNumber > 0 AndAlso
                                                            RevenueManageViewModel.Approved = False)

        End Sub
        Public Sub RevenueManage_ClearChanged(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            RevenueManageViewModel.SaveEnabled = False
            RevenueManageViewModel.CancelEnabled = False

            RevenueManageViewModel.CreateRevisionEnabled = (RevenueManageViewModel.SaveEnabled = False AndAlso
                                                            RevenueManageViewModel.HasASelectedRevision AndAlso
                                                            RevenueManageViewModel.IsMaxRevisionNumber AndAlso
                                                            RevenueManageViewModel.Approved = False)

            RevenueManageViewModel.DeleteRevisionEnabled = (RevenueManageViewModel.SaveEnabled = False AndAlso
                                                            RevenueManageViewModel.HasASelectedRevision AndAlso
                                                            RevenueManageViewModel.IsMaxRevisionNumber AndAlso
                                                            RevenueManageViewModel.SelectedPlanRevenueRevision.RevisionNumber > 0 AndAlso
                                                            RevenueManageViewModel.Approved = False)

        End Sub
        Public Sub RevenueManage_SelectedRowChanged(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel, SelectedRowCount As Integer)

            RevenueManageViewModel.AddDetailsEnabled = (RevenueManageViewModel.HasASelectedRevision AndAlso RevenueManageViewModel.IsMaxRevisionNumber AndAlso RevenueManageViewModel.Approved = False)
            RevenueManageViewModel.DeleteDetailsEnabled = (SelectedRowCount > 0 AndAlso RevenueManageViewModel.HasASelectedRevision AndAlso RevenueManageViewModel.IsMaxRevisionNumber AndAlso RevenueManageViewModel.Approved = False)

        End Sub
        Public Sub RevenueManage_DeleteDetail(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel, RowIndexes() As Integer)

            For Each RowIndex In RowIndexes.OrderByDescending(Function(RI) RI)

                RevenueManageViewModel.DataTable.Rows.RemoveAt(RowIndex)

            Next

            RevenueManage_UserEntryChanged(RevenueManageViewModel)

        End Sub
        Public Sub RevenueManage_ApproveRevision(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenueRevision = DbContext.RevenueResourcePlanRevenueRevisions.Find(RevenueManageViewModel.SelectedPlanRevenueRevision.ID)

                RevenueResourcePlanRevenueRevision.Approved = True
                RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Me.Session.User.EmployeeCode
                RevenueResourcePlanRevenueRevision.ApprovedDate = Now
                RevenueResourcePlanRevenueRevision.Notes = String.Empty

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            RevenueManageViewModel.ApproveVisible = False

            RevenueManageViewModel.Approved = RevenueResourcePlanRevenueRevision.Approved
            RevenueManageViewModel.SelectedPlanRevenueRevision.Approved = RevenueResourcePlanRevenueRevision.Approved

            RevenueManageViewModel.ApprovedBy = Me.Session.EmployeeName
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedByEmployee = Me.Session.EmployeeName
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedByEmployeeCode = RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode

            RevenueManageViewModel.ApprovedByDate = RevenueResourcePlanRevenueRevision.ApprovedDate.Value.ToShortDateString
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedDate = RevenueResourcePlanRevenueRevision.ApprovedDate

        End Sub
        Public Sub RevenueManage_UnapproveRevision(ByRef RevenueManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueManageViewModel)

            'objects
            Dim RevenueResourcePlanRevenueRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenueRevision = DbContext.RevenueResourcePlanRevenueRevisions.Find(RevenueManageViewModel.SelectedPlanRevenueRevision.ID)

                RevenueResourcePlanRevenueRevision.Approved = False
                RevenueResourcePlanRevenueRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanRevenueRevision.ApprovedDate = Nothing
                RevenueResourcePlanRevenueRevision.Notes = String.Empty

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            RevenueManageViewModel.ApproveVisible = True

            RevenueManageViewModel.Approved = RevenueResourcePlanRevenueRevision.Approved
            RevenueManageViewModel.SelectedPlanRevenueRevision.Approved = RevenueResourcePlanRevenueRevision.Approved

            RevenueManageViewModel.ApprovedBy = String.Empty
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedByEmployee = String.Empty
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedByEmployeeCode = Nothing

            RevenueManageViewModel.ApprovedByDate = String.Empty
            RevenueManageViewModel.SelectedPlanRevenueRevision.ApprovedDate = Nothing

        End Sub

#End Region

#Region "  Revenue Add Detail "

        Public Function RevenueAddDetail_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanRevenueID As Integer, RevenueResourcePlanRevenueRevisionID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel

            'objects
            Dim RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel = Nothing
            Dim Client As AdvantageFramework.Database.Entities.Client = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanRevenue As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue = Nothing
            Dim RevenueResourcePlanRevenueDetails As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail) = Nothing
            Dim Divisions As Generic.List(Of AdvantageFramework.Database.Views.DivisionView) = Nothing
            Dim Products As Generic.List(Of AdvantageFramework.Database.Views.ProductView) = Nothing
            Dim JobComponents As Generic.List(Of AdvantageFramework.Database.Views.JobComponentView) = Nothing

            RevenueAddDetailViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueAddDetailViewModel.RevenueResourcePlanID = RevenueResourcePlanID
                RevenueAddDetailViewModel.RevenueResourcePlanRevenueID = RevenueResourcePlanRevenueID
                RevenueAddDetailViewModel.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevisionID

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                RevenueAddDetailViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanRevenue = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanRevenueID)

                RevenueResourcePlanRevenueDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Where(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueRevisionID).ToList

                RevenueAddDetailViewModel.Clients = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Client)

                Client = AdvantageFramework.Database.Procedures.Client.LoadByClientCode(DbContext, RevenueResourcePlanRevenue.ClientCode)

                If Client IsNot Nothing Then

                    If RevenueResourcePlanRevenueDetails.Any(Function(Entity) Entity.ClientCode = Client.Code AndAlso Entity.DivisionCode Is Nothing AndAlso
                                                                              Entity.ProductCode Is Nothing AndAlso Entity.JobNumber Is Nothing AndAlso Entity.JobComponentNumber Is Nothing) = False Then

                        RevenueAddDetailViewModel.Clients.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Client(Client))

                    End If

                End If

                RevenueAddDetailViewModel.Divisions = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division)

                Divisions = DbContext.GetQuery(Of AdvantageFramework.Database.Views.DivisionView).Where(Function(Entity) Entity.ClientCode = RevenueResourcePlanRevenue.ClientCode).ToList

                For Each Division In Divisions

                    If RevenueResourcePlanRevenueDetails.Any(Function(Entity) Entity.ClientCode = Division.ClientCode AndAlso Entity.DivisionCode = Division.DivisionCode AndAlso
                                                                              Entity.ProductCode Is Nothing AndAlso Entity.JobNumber Is Nothing AndAlso Entity.JobComponentNumber Is Nothing) = False Then

                        RevenueAddDetailViewModel.Divisions.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division(Division))

                    End If

                Next

                RevenueAddDetailViewModel.Products = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product)

                Products = DbContext.GetQuery(Of AdvantageFramework.Database.Views.ProductView).Where(Function(Entity) Entity.ClientCode = RevenueResourcePlanRevenue.ClientCode).ToList

                For Each Product In Products

                    If RevenueResourcePlanRevenueDetails.Any(Function(Entity) Entity.ClientCode = Product.ClientCode AndAlso Entity.DivisionCode = Product.DivisionCode AndAlso
                                                                              Entity.ProductCode = Product.ProductCode AndAlso Entity.JobNumber Is Nothing AndAlso Entity.JobComponentNumber Is Nothing) = False Then

                        RevenueAddDetailViewModel.Products.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product(Product))

                    End If

                Next

                RevenueAddDetailViewModel.JobComponents = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent)

                JobComponents = DbContext.GetQuery(Of AdvantageFramework.Database.Views.JobComponentView).Where(Function(Entity) Entity.ClientCode = RevenueResourcePlanRevenue.ClientCode).ToList

                For Each JobComponent In JobComponents

                    If RevenueResourcePlanRevenueDetails.Any(Function(Entity) Entity.ClientCode = JobComponent.ClientCode AndAlso Entity.DivisionCode = JobComponent.DivisionCode AndAlso
                                                                              Entity.ProductCode = JobComponent.ProductCode AndAlso Entity.JobNumber = JobComponent.JobNumber AndAlso
                                                                              Entity.JobComponentNumber = JobComponent.JobComponentNumber) = False Then

                        RevenueAddDetailViewModel.JobComponents.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent(JobComponent))

                    End If

                Next

                If RevenueAddDetailViewModel.Clients.Count > 0 Then

                    RevenueAddDetailViewModel.ClientSelected = True
                    RevenueAddDetailViewModel.DivisionSelected = False
                    RevenueAddDetailViewModel.ProductSelected = False
                    RevenueAddDetailViewModel.JobComponentSelected = False

                End If

                If RevenueAddDetailViewModel.Clients.Count = 0 AndAlso RevenueAddDetailViewModel.Divisions.Count > 0 Then

                    RevenueAddDetailViewModel.ClientSelected = False
                    RevenueAddDetailViewModel.DivisionSelected = True
                    RevenueAddDetailViewModel.ProductSelected = False
                    RevenueAddDetailViewModel.JobComponentSelected = False

                End If

                If RevenueAddDetailViewModel.Clients.Count = 0 AndAlso RevenueAddDetailViewModel.Divisions.Count = 0 AndAlso RevenueAddDetailViewModel.Products.Count > 0 Then

                    RevenueAddDetailViewModel.ClientSelected = False
                    RevenueAddDetailViewModel.DivisionSelected = False
                    RevenueAddDetailViewModel.ProductSelected = True
                    RevenueAddDetailViewModel.JobComponentSelected = False

                End If

                If RevenueAddDetailViewModel.Clients.Count = 0 AndAlso RevenueAddDetailViewModel.Divisions.Count = 0 AndAlso RevenueAddDetailViewModel.Products.Count = 0 AndAlso RevenueAddDetailViewModel.JobComponents.Count > 0 Then

                    RevenueAddDetailViewModel.ClientSelected = False
                    RevenueAddDetailViewModel.DivisionSelected = False
                    RevenueAddDetailViewModel.ProductSelected = False
                    RevenueAddDetailViewModel.JobComponentSelected = True

                End If

            End Using

            RevenueAddDetail_Load = RevenueAddDetailViewModel

        End Function
        Public Sub RevenueAddDetail_CDPJCChanged(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel,
                                                 ClientSelected As Boolean, DivisionSelected As Boolean, ProductSelected As Boolean, JobComponentSelected As Boolean)

            RevenueAddDetailViewModel.ClientSelected = ClientSelected
            RevenueAddDetailViewModel.DivisionSelected = DivisionSelected
            RevenueAddDetailViewModel.ProductSelected = ProductSelected
            RevenueAddDetailViewModel.JobComponentSelected = JobComponentSelected

        End Sub
        Public Function RevenueAddDetail_AddClient(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel,
                                                   Client As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Client,
                                                   ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID = RevenueAddDetailViewModel.RevenueResourcePlanRevenueRevisionID
                RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueType.Fee
                RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueStatus.Active

                RevenueResourcePlanRevenueDetail.ClientCode = Client.ClientCode
                RevenueResourcePlanRevenueDetail.DivisionCode = Nothing
                RevenueResourcePlanRevenueDetail.ProductCode = Nothing
                RevenueResourcePlanRevenueDetail.JobNumber = Nothing
                RevenueResourcePlanRevenueDetail.JobComponentNumber = Nothing
                RevenueResourcePlanRevenueDetail.Notes = String.Empty

                DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                For Each DetailDate In GetPlanDates(RevenueAddDetailViewModel.Plan)

                    RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                    RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                    RevenueResourcePlanRevenueDetailDate.Date = DetailDate
                    RevenueResourcePlanRevenueDetailDate.Revenue = 0

                    DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Any(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID AndAlso
                                                                                                                                     Entity.ClientCode = RevenueResourcePlanRevenueDetail.ClientCode AndAlso
                                                                                                                                     Entity.DivisionCode Is Nothing AndAlso
                                                                                                                                     Entity.ProductCode Is Nothing AndAlso
                                                                                                                                     Entity.JobNumber Is Nothing AndAlso
                                                                                                                                     Entity.JobComponentNumber Is Nothing) = False Then

                    DbContext.SaveChanges()

                    Added = True

                Else

                    ErrorMessage = "There is already a detail level for the client selected. Please select a different client."

                End If

            End Using

            RevenueAddDetail_AddClient = Added

        End Function
        Public Function RevenueAddDetail_AddDivisions(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel,
                                                      Divisions As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Division),
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each Division In Divisions

                    RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID = RevenueAddDetailViewModel.RevenueResourcePlanRevenueRevisionID
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueType.Fee
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueStatus.Active

                    RevenueResourcePlanRevenueDetail.ClientCode = Division.ClientCode
                    RevenueResourcePlanRevenueDetail.DivisionCode = Division.DivisionCode
                    RevenueResourcePlanRevenueDetail.ProductCode = Nothing
                    RevenueResourcePlanRevenueDetail.JobNumber = Nothing
                    RevenueResourcePlanRevenueDetail.JobComponentNumber = Nothing
                    RevenueResourcePlanRevenueDetail.Notes = String.Empty

                    DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                    For Each DetailDate In GetPlanDates(RevenueAddDetailViewModel.Plan)

                        RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                        RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                        RevenueResourcePlanRevenueDetailDate.Date = DetailDate
                        RevenueResourcePlanRevenueDetailDate.Revenue = 0

                        DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                    Next

                    If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Any(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID AndAlso
                                                                                                                                         Entity.ClientCode = RevenueResourcePlanRevenueDetail.ClientCode AndAlso
                                                                                                                                         Entity.DivisionCode = RevenueResourcePlanRevenueDetail.DivisionCode AndAlso
                                                                                                                                         Entity.ProductCode Is Nothing AndAlso
                                                                                                                                         Entity.JobNumber Is Nothing AndAlso
                                                                                                                                         Entity.JobComponentNumber Is Nothing) = False Then

                        DbContext.SaveChanges()

                        Added = True

                    Else

                        ErrorMessage = "There is already a detail level for one of the selected divisions. Please select a different division."
                        Exit For

                    End If

                Next

            End Using

            RevenueAddDetail_AddDivisions = Added

        End Function
        Public Function RevenueAddDetail_AddProducts(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel,
                                                      Products As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Product),
                                                      ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each Product In Products

                    RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID = RevenueAddDetailViewModel.RevenueResourcePlanRevenueRevisionID
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueType.Fee
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueStatus.Active

                    RevenueResourcePlanRevenueDetail.ClientCode = Product.ClientCode
                    RevenueResourcePlanRevenueDetail.DivisionCode = Product.DivisionCode
                    RevenueResourcePlanRevenueDetail.ProductCode = Product.ProductCode
                    RevenueResourcePlanRevenueDetail.JobNumber = Nothing
                    RevenueResourcePlanRevenueDetail.JobComponentNumber = Nothing
                    RevenueResourcePlanRevenueDetail.Notes = String.Empty

                    DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                    For Each DetailDate In GetPlanDates(RevenueAddDetailViewModel.Plan)

                        RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                        RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                        RevenueResourcePlanRevenueDetailDate.Date = DetailDate
                        RevenueResourcePlanRevenueDetailDate.Revenue = 0

                        DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                    Next

                    If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Any(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID AndAlso
                                                                                                                                         Entity.ClientCode = RevenueResourcePlanRevenueDetail.ClientCode AndAlso
                                                                                                                                         Entity.DivisionCode = RevenueResourcePlanRevenueDetail.DivisionCode AndAlso
                                                                                                                                         Entity.ProductCode = RevenueResourcePlanRevenueDetail.ProductCode AndAlso
                                                                                                                                         Entity.JobNumber Is Nothing AndAlso
                                                                                                                                         Entity.JobComponentNumber Is Nothing) = False Then

                        DbContext.SaveChanges()

                        Added = True

                    Else

                        ErrorMessage = "There is already a detail level for one of the selected products. Please select a different product."
                        Exit For

                    End If

                Next

            End Using

            RevenueAddDetail_AddProducts = Added

        End Function
        Public Function RevenueAddDetail_AddJobComponents(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel,
                                                          JobComponents As Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.JobComponent),
                                                          ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanRevenueDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail = Nothing
            Dim RevenueResourcePlanRevenueDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                For Each JobComponent In JobComponents

                    RevenueResourcePlanRevenueDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail

                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID = RevenueAddDetailViewModel.RevenueResourcePlanRevenueRevisionID
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueTypeID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueType.Fee
                    RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueStatusID = AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.RevenueStatus.Active

                    RevenueResourcePlanRevenueDetail.ClientCode = JobComponent.ClientCode
                    RevenueResourcePlanRevenueDetail.DivisionCode = JobComponent.DivisionCode
                    RevenueResourcePlanRevenueDetail.ProductCode = JobComponent.ProductCode
                    RevenueResourcePlanRevenueDetail.JobNumber = JobComponent.JobNumber
                    RevenueResourcePlanRevenueDetail.JobComponentNumber = JobComponent.JobComponentNumber
                    RevenueResourcePlanRevenueDetail.Notes = String.Empty

                    DbContext.RevenueResourcePlanRevenueDetails.Add(RevenueResourcePlanRevenueDetail)

                    For Each DetailDate In GetPlanDates(RevenueAddDetailViewModel.Plan)

                        RevenueResourcePlanRevenueDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetailDate

                        RevenueResourcePlanRevenueDetailDate.RevenueResourcePlanRevenueDetail = RevenueResourcePlanRevenueDetail
                        RevenueResourcePlanRevenueDetailDate.Date = DetailDate
                        RevenueResourcePlanRevenueDetailDate.Revenue = 0

                        DbContext.RevenueResourcePlanRevenueDetailDates.Add(RevenueResourcePlanRevenueDetailDate)

                    Next

                    If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenueDetail).Any(Function(Entity) Entity.RevenueResourcePlanRevenueRevisionID = RevenueResourcePlanRevenueDetail.RevenueResourcePlanRevenueRevisionID AndAlso
                                                                                                                                         Entity.ClientCode = RevenueResourcePlanRevenueDetail.ClientCode AndAlso
                                                                                                                                         Entity.DivisionCode = RevenueResourcePlanRevenueDetail.DivisionCode AndAlso
                                                                                                                                         Entity.ProductCode = RevenueResourcePlanRevenueDetail.ProductCode AndAlso
                                                                                                                                         Entity.JobNumber = RevenueResourcePlanRevenueDetail.JobNumber AndAlso
                                                                                                                                         Entity.JobComponentNumber = RevenueResourcePlanRevenueDetail.JobComponentNumber) = False Then

                        DbContext.SaveChanges()

                        Added = True

                    Else

                        ErrorMessage = "There is already a detail level for one of the selected job/comps. Please select a different job/comp."
                        Exit For

                    End If

                Next

            End Using

            RevenueAddDetail_AddJobComponents = Added

        End Function
        Public Sub RevenueAddDetail_SelectedRowChanged(ByRef RevenueAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.RevenueAddDetailViewModel, SelectedRowCount As Integer)

            RevenueAddDetailViewModel.AddEnabled = (SelectedRowCount > 0)

        End Sub

#End Region

#Region "  Resource Setup "

        Public Function ResourceSetup_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel

            'objects
            Dim ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanRevenues As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue) = Nothing
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            ResourceSetupViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                ResourceSetupViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                ResourceSetupViewModel.PlanClientResources = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)

                ResourceSetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupFormDashboardDataSource)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanResourceSetup)

                If Dashboard IsNot Nothing Then

                    ResourceSetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard(Dashboard)

                Else

                    ResourceSetupViewModel.Dashboard = New AdvantageFramework.DTO.Dashboard

                End If

                ResourceSetupViewModel.Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            ResourceSetup_LoadPlanClientResources(ResourceSetupViewModel)

            ResourceSetup_Load = ResourceSetupViewModel

        End Function
        Public Sub ResourceSetup_LoadPlanClientResources(ByRef ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel)

            'objects
            Dim RevenueResourcePlanResources As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResource) = Nothing
            Dim RevenueResourcePlanID As Integer = 0
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            RevenueResourcePlanID = ResourceSetupViewModel.Plan.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanResources = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResource).Include("Client").
                                                                                                                                       Include("Employee").
                                                                                                                                       Include("RevenueResourcePlanResourceRevisions").
                                                                                                                                       Include("RevenueResourcePlanResourceRevisions.ApprovedByEmployee").
                                                                                                                                       Include("RevenueResourcePlanResourceRevisions.RevenueResourcePlanResourceDetails").
                                                                                                                                       Include("RevenueResourcePlanResourceRevisions.RevenueResourcePlanResourceDetails.RevenueResourcePlanResourceDetailDates").
                                                                                                                                       Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList

                ResourceSetupViewModel.PlanClientResources = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)

                For Each RevenueResourcePlanResource In RevenueResourcePlanResources

                    ResourceSetupViewModel.PlanClientResources.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource(RevenueResourcePlanResource))

                Next

                ResourceSetupViewModel.DashboardDataSource = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupFormDashboardDataSource)

                For Each PlanClientRevenue In ResourceSetupViewModel.PlanClientResources

                    RevenueResourcePlanResourceRevision = RevenueResourcePlanResources.SelectMany(Function(Entity) Entity.RevenueResourcePlanResourceRevisions).SingleOrDefault(Function(Entity) Entity.RevenueResourcePlanResourceID = PlanClientRevenue.ID AndAlso Entity.RevisionNumber = PlanClientRevenue.RevisionNumber)

                    For Each RevenueResourcePlanResourceDetail In RevenueResourcePlanResourceRevision.RevenueResourcePlanResourceDetails

                        For Each RevenueResourcePlanResourceDetailDate In RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates

                            ResourceSetupViewModel.DashboardDataSource.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupFormDashboardDataSource(RevenueResourcePlanResourceDetailDate, PlanClientRevenue.Client))

                        Next

                    Next

                Next

            End Using

        End Sub
        Public Sub ResourceSetup_SelectedPlanClientResourceChanged(ByRef ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel,
                                                                   PlanClientResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)

            ResourceSetupViewModel.SelectedPlanClientResource = PlanClientResource

        End Sub
        Public Sub ResourceSetup_SaveDashboard(ByRef ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel, DashboardLayout() As Byte)

            'objects
            Dim Dashboard As AdvantageFramework.Database.Entities.Dashboard = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                Dashboard = AdvantageFramework.Database.Procedures.Dashboard.LoadByDashboardType(DbContext, AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanResourceSetup)

                If Dashboard IsNot Nothing Then

                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Update(DbContext, Dashboard)

                Else

                    Dashboard = New AdvantageFramework.Database.Entities.Dashboard

                    Dashboard.DbContext = DbContext
                    Dashboard.Type = AdvantageFramework.Database.Entities.DashboardTypes.RevenueResourcePlanResourceSetup
                    Dashboard.Layout = DashboardLayout

                    AdvantageFramework.Database.Procedures.Dashboard.Insert(DbContext, Dashboard)

                End If

            End Using

            ResourceSetupViewModel.Dashboard.Layout = DashboardLayout

        End Sub
        Public Sub ResourceSetup_Delete(ByRef ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel,
                                        PlanClientResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)

            'objects
            Dim RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResource = DbContext.RevenueResourcePlanResources.Find(PlanClientResource.ID)

                DbContext.Entry(RevenueResourcePlanResource).Collection("RevenueResourcePlanResourceRevisions").Load()

                For Each RevenueResourcePlanResourceRevision In RevenueResourcePlanResource.RevenueResourcePlanResourceRevisions.ToList

                    DbContext.Entry(RevenueResourcePlanResourceRevision).Collection("RevenueResourcePlanResourceDetails").Load()

                    For Each RevenueResourcePlanResourceDetail In RevenueResourcePlanResourceRevision.RevenueResourcePlanResourceDetails.ToList

                        DbContext.Entry(RevenueResourcePlanResourceDetail).Collection("RevenueResourcePlanResourceDetailDates").Load()

                        For Each RevenueResourcePlanResourceDetailDate In RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.ToList

                            DbContext.RevenueResourcePlanResourceDetailDates.Remove(RevenueResourcePlanResourceDetailDate)

                        Next

                        DbContext.RevenueResourcePlanResourceDetails.Remove(RevenueResourcePlanResourceDetail)

                    Next

                    DbContext.RevenueResourcePlanResourceRevisions.Remove(RevenueResourcePlanResourceRevision)

                Next

                DbContext.RevenueResourcePlanResources.Remove(RevenueResourcePlanResource)

                DbContext.Configuration.AutoDetectChangesEnabled = True
                DbContext.SaveChanges()

                ResourceSetupViewModel.PlanClientResources.Remove(PlanClientResource)

            End Using

        End Sub
        Public Sub ResourceSetup_Save(ByRef ResourceSetupViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceSetupViewModel,
                                      PlanClientResource As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanClientResource)

            'objects
            Dim RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource = Nothing
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResource = DbContext.RevenueResourcePlanResources.Find(PlanClientResource.ID)

                RevenueResourcePlanResource.EmployeeCode = If(String.IsNullOrWhiteSpace(PlanClientResource.OwnerCode) = False, PlanClientResource.OwnerCode, Nothing)
                RevenueResourcePlanResource.Notes = PlanClientResource.Notes

                RevenueResourcePlanResourceRevision = DbContext.RevenueResourcePlanResourceRevisions.Find(PlanClientResource.RevenueResourcePlanResourceRevisionID)

                RevenueResourcePlanResourceRevision.Notes = PlanClientResource.RevisionNotes

                DbContext.Configuration.AutoDetectChangesEnabled = True
                DbContext.SaveChanges()

            End Using

        End Sub

#End Region

#Region "  Resource Add "

        Public Function ResourceAdd_Load(RevenueResourcePlanID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddViewModel

            'objects
            Dim ResourceAddViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddViewModel = Nothing
            Dim Clients As Generic.List(Of AdvantageFramework.Database.Entities.Client) = Nothing
            Dim RevenueResourcePlanResources As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResource) = Nothing

            ResourceAddViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ResourceAddViewModel.PlanID = RevenueResourcePlanID

                ResourceAddViewModel.PlanResource = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResource

                ResourceAddViewModel.Employees = AdvantageFramework.Database.Procedures.EmployeeView.LoadAllActive(DbContext).ToList.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

                RevenueResourcePlanResources = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResource).Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList
                Clients = AdvantageFramework.Database.Procedures.Client.LoadAllActive(DbContext).ToList

                For Each Client In Clients.ToList

                    If RevenueResourcePlanResources.Any(Function(Entity) Entity.ClientCode = Client.Code) Then

                        Clients.Remove(Client)

                    End If

                Next

                ResourceAddViewModel.Clients = Clients.Select(Function(Entity) New AdvantageFramework.DTO.ComboBoxItem(Entity)).ToList

            End Using

            ResourceAdd_Load = ResourceAddViewModel

        End Function
        Public Function ResourceAdd_Add(ByRef ResourceAddViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddViewModel, ByRef ErrorMessage As String) As Boolean

            'objects
            Dim Added As Boolean = False
            Dim RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource = Nothing
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResource = New AdvantageFramework.Database.Entities.RevenueResourcePlanResource

                RevenueResourcePlanResource.RevenueResourcePlanID = ResourceAddViewModel.PlanID

                ResourceAddViewModel.PlanResource.SaveToEntity(RevenueResourcePlanResource)
                DbContext.RevenueResourcePlanResources.Add(RevenueResourcePlanResource)

                RevenueResourcePlanResourceRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision

                RevenueResourcePlanResourceRevision.RevenueResourcePlanResource = RevenueResourcePlanResource
                RevenueResourcePlanResourceRevision.RevisionNumber = 0
                RevenueResourcePlanResourceRevision.Approved = False
                RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanResourceRevision.ApprovedDate = Nothing
                RevenueResourcePlanResourceRevision.Notes = String.Empty

                DbContext.RevenueResourcePlanResourceRevisions.Add(RevenueResourcePlanResourceRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanRevenue).Any(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanResource.RevenueResourcePlanID AndAlso
                                                                                                                               Entity.ClientCode = RevenueResourcePlanResource.ClientCode) = False Then

                    DbContext.SaveChanges()

                    Added = True

                Else

                    ErrorMessage = "There is already a revenue plan for the client selected. Please select a different client."

                End If

            End Using

            ResourceAdd_Add = Added

        End Function

#End Region

#Region "  Resource Manage "

        Public Function ResourceManage_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanResourceID As Integer, RevenueResourcePlanResourceRevisionID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel

            'objects
            Dim ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanResource As AdvantageFramework.Database.Entities.RevenueResourcePlanResource = Nothing
            Dim PlanResourceRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision = Nothing

            ResourceManageViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ResourceManageViewModel.RevenueResourcePlanID = RevenueResourcePlanID
                ResourceManageViewModel.RevenueResourcePlanResourceID = RevenueResourcePlanResourceID

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                ResourceManageViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanResource = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResource).SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanResourceID)

                ResourceManageViewModel.PlanResource = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResource(RevenueResourcePlanResource)

            End Using

            ResourceManage_GetDetailDates(ResourceManageViewModel)
            ResourceManage_CreateDataTableSchema(ResourceManageViewModel)
            ResourceManage_LoadRevisions(ResourceManageViewModel)

            Try

                PlanResourceRevision = ResourceManageViewModel.PlanResourceRevisions.SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanResourceRevisionID)

            Catch ex As Exception
                PlanResourceRevision = Nothing
            End Try

            If PlanResourceRevision IsNot Nothing Then

                ResourceManage_SelectRevision(ResourceManageViewModel, PlanResourceRevision.RevisionNumber)

            End If

            ResourceManageViewModel.SaveEnabled = False
            ResourceManageViewModel.CancelEnabled = False

            If ResourceManageViewModel.SelectedPlanResourceRevision IsNot Nothing Then

                ResourceManageViewModel.ApproveVisible = Not ResourceManageViewModel.SelectedPlanResourceRevision.Approved
                ResourceManageViewModel.Approved = ResourceManageViewModel.SelectedPlanResourceRevision.Approved
                ResourceManageViewModel.ApprovedBy = ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedByEmployee
                ResourceManageViewModel.ApprovedByDate = If(ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedDate.HasValue, ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedDate.Value.ToShortDateString, String.Empty)

            End If

            ResourceManage_SelectedRowChanged(ResourceManageViewModel, 0)

            ResourceManage_Load = ResourceManageViewModel

        End Function
        Public Sub ResourceManage_Save(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanID As Integer = 0
            Dim RevenueResourcePlanResourceID As Integer = 0
            Dim RevenueResourcePlanResourceRevisionID As Integer = 0
            Dim RevenueResourcePlanResourceDetailID As Integer = 0
            Dim RevenueResourcePlanResourceDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail = Nothing
            Dim RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate = Nothing

            RevenueResourcePlanID = ResourceManageViewModel.RevenueResourcePlanID
            RevenueResourcePlanResourceID = ResourceManageViewModel.RevenueResourcePlanResourceID
            RevenueResourcePlanResourceRevisionID = ResourceManageViewModel.SelectedPlanResourceRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each DataRow In ResourceManageViewModel.DataTable.Rows.OfType(Of System.Data.DataRow)

                    RevenueResourcePlanResourceDetail = Nothing
                    RevenueResourcePlanResourceDetailID = 0

                    If DataRow.RowState <> System.Data.DataRowState.Unchanged Then

                        RevenueResourcePlanResourceDetailID = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ResourceDetailID.ToString)

                        Try

                            RevenueResourcePlanResourceDetail = DbContext.RevenueResourcePlanResourceDetails.Find(RevenueResourcePlanResourceDetailID)

                        Catch ex As Exception
                            RevenueResourcePlanResourceDetail = Nothing
                        End Try

                        If RevenueResourcePlanResourceDetail IsNot Nothing Then

                            RevenueResourcePlanResourceDetail.Notes = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Notes.ToString)

                            For Each DetailDate In ResourceManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                                RevenueResourcePlanResourceDetailDate = Nothing

                                Try

                                    RevenueResourcePlanResourceDetailDate = DbContext.RevenueResourcePlanResourceDetailDates.SingleOrDefault(Function(Entity) Entity.RevenueResourcePlanResourceDetailID = RevenueResourcePlanResourceDetail.ID AndAlso Entity.Date = DetailDate)

                                Catch ex As Exception
                                    RevenueResourcePlanResourceDetailDate = Nothing
                                End Try

                                If RevenueResourcePlanResourceDetailDate IsNot Nothing Then

                                    RevenueResourcePlanResourceDetailDate.Hours = DataRow(ResourceManageViewModel.DetailDates(DetailDate))

                                End If

                            Next

                        End If

                    End If

                Next

                For Each RevenueResourcePlanResourceDetail In DbContext.RevenueResourcePlanResourceDetails.Include("RevenueResourcePlanResourceDetailDates").
                                                                                                           Where(Function(Entity) Entity.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID).ToList

                    If ResourceManageViewModel.DataTable.Rows.OfType(Of System.Data.DataRow).Any(Function(DR) DR(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ResourceDetailID.ToString) = RevenueResourcePlanResourceDetail.ID) = False Then

                        For Each RevenueResourcePlanResourceDetailDate In RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.ToList

                            DbContext.RevenueResourcePlanResourceDetailDates.Remove(RevenueResourcePlanResourceDetailDate)

                        Next

                        DbContext.RevenueResourcePlanResourceDetails.Remove(RevenueResourcePlanResourceDetail)

                    End If

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

                ResourceManageViewModel.DataTable.AcceptChanges()

            End Using

        End Sub
        Private Sub ResourceManage_GetDetailDates(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim DateCounter As Integer = 1
            Dim DetailDate As Date = Date.MinValue
            Dim PlanDates As Generic.List(Of Date) = Nothing

            PlanDates = GetPlanDates(ResourceManageViewModel.Plan)

            ResourceManageViewModel.DetailDates = New Hashtable

            For Each DetailDate In PlanDates

                ResourceManageViewModel.DetailDates(DetailDate) = "Date" & DateCounter

                DateCounter += 1

            Next

        End Sub
        Private Sub ResourceManage_CreateDataTableSchema(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim DataColumn As System.Data.DataColumn = Nothing
            Dim DetailDate As Date = Date.MinValue

            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ID.ToString)

            DataColumn.AutoIncrement = True
            DataColumn.AllowDBNull = False
            ResourceManageViewModel.DataTable.PrimaryKey = New System.Data.DataColumn() {DataColumn}
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ResourceDetailID.ToString)

            DataColumn.Caption = "Resource Detail ID"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.StaffID.ToString)

            DataColumn.Caption = "Staff ID"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Integer)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Title.ToString)

            DataColumn.Caption = "Title"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = ""
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Employee.ToString)

            DataColumn.Caption = "Employee"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = ""
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString)

            DataColumn.Caption = "Allocation %"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString)

            DataColumn.Caption = "Hours"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.HoursAvailable.ToString)

            DataColumn.Caption = "Hours Available"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            For Each DetailDate In ResourceManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                DataColumn = ResourceManageViewModel.DataTable.Columns.Add(ResourceManageViewModel.DetailDates(DetailDate))

                DataColumn.ExtendedProperties.Add("Date", DetailDate)

                DataColumn.Caption = DetailDate.ToString("MM/dd")

                DataColumn.AllowDBNull = False
                DataColumn.DataType = GetType(Decimal)
                DataColumn.DefaultValue = 0

            Next
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Cost.ToString)

            DataColumn.Caption = "Cost"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Revenue.ToString)

            DataColumn.Caption = "Revenue"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ProfitPercentage.ToString)

            DataColumn.Caption = "Profit %"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.UtilizationVariance.ToString)

            DataColumn.Caption = "Utilization Variance %"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(Decimal)
            DataColumn.DefaultValue = 0
            '=============
            DataColumn = ResourceManageViewModel.DataTable.Columns.Add(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Notes.ToString)

            DataColumn.Caption = "Notes"
            DataColumn.AllowDBNull = False
            DataColumn.DataType = GetType(String)
            DataColumn.DefaultValue = ""

        End Sub
        Public Sub ResourceManage_LoadRevisions(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanResourceID As Integer = 0

            ResourceManageViewModel.PlanResourceRevisions = New List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision)

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevenueResourcePlanResourceID = ResourceManageViewModel.RevenueResourcePlanResourceID

                For Each RevenueResourcePlanResourceRevision In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision).Include("ApprovedByEmployee").
                                                                                                                                                                Include("RevenueResourcePlanResource").
                                                                                                                                                                Where(Function(Entity) Entity.RevenueResourcePlanResourceID = RevenueResourcePlanResourceID).ToList

                    ResourceManageViewModel.PlanResourceRevisions.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision(RevenueResourcePlanResourceRevision))

                Next

            End Using

        End Sub
        Public Sub ResourceManage_SelectRevision(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel,
                                                RevisionNumber As Integer)

            'objects
            Dim PlanResourceRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision = Nothing

            Try

                PlanResourceRevision = ResourceManageViewModel.PlanResourceRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = RevisionNumber)

            Catch ex As Exception
                PlanResourceRevision = Nothing
            End Try

            ResourceManageViewModel.SelectedPlanResourceRevision = PlanResourceRevision

            ResourceManage_LoadDetails(ResourceManageViewModel)

        End Sub
        Public Sub ResourceManage_CreateRevision(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing
            Dim RevenueResourcePlanResourceID As Integer = 0
            Dim RevisionNumber As Integer = -1
            Dim PlanResourceRevisionID As Integer = 0
            Dim RevenueResourcePlanResourceDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail = Nothing
            Dim RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate = Nothing
            Dim PlanResourceRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision = Nothing

            RevenueResourcePlanResourceID = ResourceManageViewModel.RevenueResourcePlanResourceID

            PlanResourceRevisionID = ResourceManageViewModel.SelectedPlanResourceRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                RevisionNumber = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision).Where(Function(Entity) Entity.RevenueResourcePlanResourceID = RevenueResourcePlanResourceID).Max(Function(Entity) Entity.RevisionNumber) + 1

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResourceRevision = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision

                RevenueResourcePlanResourceRevision.RevenueResourcePlanResourceID = RevenueResourcePlanResourceID
                RevenueResourcePlanResourceRevision.RevisionNumber = RevisionNumber
                RevenueResourcePlanResourceRevision.Approved = False
                RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanResourceRevision.ApprovedDate = Nothing
                RevenueResourcePlanResourceRevision.Notes = String.Empty

                DbContext.RevenueResourcePlanResourceRevisions.Add(RevenueResourcePlanResourceRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                For Each CopyFromRevenueResourcePlanResourceDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail).Include("RevenueResourcePlanResourceDetailDates").
                                                                                                                                                                  Where(Function(Entity) Entity.RevenueResourcePlanResourceRevisionID = PlanResourceRevisionID).ToList

                    RevenueResourcePlanResourceDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail

                    RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevision.ID

                    'RevenueResourcePlanResourceDetail. = CopyFromRevenueResourcePlanResourceDetail.RevenueResourcePlanResourceTypeID
                    'RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceStatusID = CopyFromRevenueResourcePlanResourceDetail.RevenueResourcePlanResourceStatusID

                    'RevenueResourcePlanResourceDetail.ClientCode = CopyFromRevenueResourcePlanResourceDetail.ClientCode
                    'RevenueResourcePlanResourceDetail.DivisionCode = CopyFromRevenueResourcePlanResourceDetail.DivisionCode
                    'RevenueResourcePlanResourceDetail.ProductCode = CopyFromRevenueResourcePlanResourceDetail.ProductCode
                    'RevenueResourcePlanResourceDetail.JobNumber = CopyFromRevenueResourcePlanResourceDetail.JobNumber
                    'RevenueResourcePlanResourceDetail.JobComponentNumber = CopyFromRevenueResourcePlanResourceDetail.JobComponentNumber
                    'RevenueResourcePlanResourceDetail.Notes = CopyFromRevenueResourcePlanResourceDetail.Notes

                    DbContext.RevenueResourcePlanResourceDetails.Add(RevenueResourcePlanResourceDetail)

                    For Each CopyFromRevenueResourcePlanResourceDetailDate In CopyFromRevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.ToList

                        RevenueResourcePlanResourceDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate

                        RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail = RevenueResourcePlanResourceDetail
                        RevenueResourcePlanResourceDetailDate.Date = CopyFromRevenueResourcePlanResourceDetailDate.Date
                        RevenueResourcePlanResourceDetailDate.Hours = CopyFromRevenueResourcePlanResourceDetailDate.Hours

                        DbContext.RevenueResourcePlanResourceDetailDates.Add(RevenueResourcePlanResourceDetailDate)

                    Next

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            ResourceManage_LoadRevisions(ResourceManageViewModel)

            Try

                PlanResourceRevision = ResourceManageViewModel.PlanResourceRevisions.SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanResourceRevision.ID)

            Catch ex As Exception
                PlanResourceRevision = Nothing
            End Try

            If PlanResourceRevision IsNot Nothing Then

                ResourceManage_SelectRevision(ResourceManageViewModel, PlanResourceRevision.RevisionNumber)

            End If

        End Sub
        Public Sub ResourceManage_DeleteRevision(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing
            Dim PlanResourceRevisionID As Integer = 0
            Dim MaxRevisionNumber As Integer = 1
            Dim PlanResourceRevision As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceRevision = Nothing

            PlanResourceRevisionID = ResourceManageViewModel.SelectedPlanResourceRevision.ID

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResourceRevision = DbContext.RevenueResourcePlanResourceRevisions.Include("RevenueResourcePlanResourceDetails").Include("RevenueResourcePlanResourceDetails.RevenueResourcePlanResourceDetailDates").
                                                                                                     SingleOrDefault(Function(Entity) Entity.ID = PlanResourceRevisionID)

                For Each RevenueResourcePlanResourceDetail In RevenueResourcePlanResourceRevision.RevenueResourcePlanResourceDetails.ToList

                    For Each RevenueResourcePlanResourceDetailDate In RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.ToList

                        DbContext.RevenueResourcePlanResourceDetailDates.Remove(RevenueResourcePlanResourceDetailDate)

                    Next

                    DbContext.RevenueResourcePlanResourceDetails.Remove(RevenueResourcePlanResourceDetail)

                Next

                DbContext.RevenueResourcePlanResourceRevisions.Remove(RevenueResourcePlanResourceRevision)

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            ResourceManage_LoadRevisions(ResourceManageViewModel)

            Try

                MaxRevisionNumber = ResourceManageViewModel.PlanResourceRevisions.Max(Function(Entity) Entity.RevisionNumber)

            Catch ex As Exception
                MaxRevisionNumber = -1
            End Try

            Try

                PlanResourceRevision = ResourceManageViewModel.PlanResourceRevisions.SingleOrDefault(Function(Entity) Entity.RevisionNumber = MaxRevisionNumber)

            Catch ex As Exception
                PlanResourceRevision = Nothing
            End Try

            If PlanResourceRevision IsNot Nothing Then

                ResourceManage_SelectRevision(ResourceManageViewModel, PlanResourceRevision.RevisionNumber)

            End If

        End Sub
        Public Sub ResourceManage_LoadDetails(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim PlanResourceRevisionID As Integer = 0
            Dim DataRow As System.Data.DataRow = Nothing
            Dim RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate = Nothing
            Dim RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient = Nothing
            Dim PlanStaff As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff = Nothing
            Dim PlanStaffClientAssignment As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment = Nothing
            Dim ClientCode As String = String.Empty

            If ResourceManageViewModel.SelectedPlanResourceRevision IsNot Nothing Then

                ResourceManageViewModel.DataTable.Rows.Clear()

                PlanResourceRevisionID = ResourceManageViewModel.SelectedPlanResourceRevision.ID
                ClientCode = ResourceManageViewModel.PlanResource.ClientCode

                Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                    DbContext.Database.Connection.Open()

                    ResourceManageViewModel.DataTable.BeginLoadData()

                    For Each RevenueResourcePlanResourceDetail In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail).Include("RevenueResourcePlanStaff").Include("RevenueResourcePlanStaff.EmployeeTitle").
                                                                                                                                                                Include("RevenueResourcePlanStaff.Employee").Include("RevenueResourcePlanResourceDetailDates").
                                                                                                                                                                Include("RevenueResourcePlanStaff.RevenueResourcePlanStaffClients").
                                                                                                                                                                Where(Function(Entity) Entity.RevenueResourcePlanResourceRevisionID = PlanResourceRevisionID).ToList

                        DataRow = ResourceManageViewModel.DataTable.NewRow()

                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ResourceDetailID.ToString) = RevenueResourcePlanResourceDetail.ID
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.StaffID.ToString) = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaffID

                        PlanStaff = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaff(RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff)

                        LoadPlanStaffProperties(DbContext, ResourceManageViewModel.Plan, PlanStaff, RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff)

                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Title.ToString) = PlanStaff.EmployeeTitle
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Employee.ToString) = PlanStaff.StaffName

                        Try

                            RevenueResourcePlanStaffClient = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.SingleOrDefault(Function(Entity) Entity.ClientCode = ClientCode AndAlso Entity.DivisionCode Is Nothing AndAlso Entity.ProductCode Is Nothing)

                        Catch ex As Exception

                        End Try

                        If RevenueResourcePlanStaffClient IsNot Nothing Then

                            PlanStaffClientAssignment = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanStaffClientAssignment(DbContext, ResourceManageViewModel.Plan, RevenueResourcePlanStaffClient)

                            DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString) = PlanStaffClientAssignment.Percent
                            DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString) = PlanStaffClientAssignment.Hours
                            DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.HoursAvailable.ToString) = PlanStaffClientAssignment.HoursAvailable

                        End If

                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Cost.ToString) = PlanStaff.EmployeeCost
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Revenue.ToString) = PlanStaff.PlanRevenue
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.ProfitPercentage.ToString) = PlanStaff.CostRevenueVariancePercentage
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.UtilizationVariance.ToString) = PlanStaff.UtilizationVariancePercentage
                        DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Notes.ToString) = RevenueResourcePlanResourceDetail.Notes

                        For Each DetailDate In ResourceManageViewModel.DetailDates.Keys.OfType(Of Date).OrderBy(Function(DD) DD)

                            RevenueResourcePlanResourceDetailDate = RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.SingleOrDefault(Function(Entity) Entity.Date = DetailDate)

                            If RevenueResourcePlanResourceDetailDate IsNot Nothing Then

                                DataRow(ResourceManageViewModel.DetailDates(DetailDate)) = RevenueResourcePlanResourceDetailDate.Hours

                            Else

                                DataRow(ResourceManageViewModel.DetailDates(DetailDate)) = 0

                            End If

                        Next

                        ResourceManageViewModel.DataTable.Rows.Add(DataRow)

                    Next

                    ResourceManageViewModel.DataTable.EndLoadData()

                End Using

            End If

        End Sub
        Public Sub ResourceManage_UserEntryChanged(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            ResourceManageViewModel.SaveEnabled = True
            ResourceManageViewModel.CancelEnabled = True

            ResourceManageViewModel.CreateRevisionEnabled = (ResourceManageViewModel.SaveEnabled = False AndAlso
                                                             ResourceManageViewModel.HasASelectedRevision AndAlso
                                                             ResourceManageViewModel.IsMaxRevisionNumber AndAlso
                                                             ResourceManageViewModel.DataTable.Rows.Count > 0 AndAlso
                                                             ResourceManageViewModel.Approved = False)

            ResourceManageViewModel.DeleteRevisionEnabled = (ResourceManageViewModel.SaveEnabled = False AndAlso
                                                             ResourceManageViewModel.HasASelectedRevision AndAlso
                                                             ResourceManageViewModel.IsMaxRevisionNumber AndAlso
                                                             ResourceManageViewModel.SelectedPlanResourceRevision.RevisionNumber > 0 AndAlso
                                                             ResourceManageViewModel.Approved = False)

        End Sub
        Public Sub ResourceManage_ClearChanged(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            ResourceManageViewModel.SaveEnabled = False
            ResourceManageViewModel.CancelEnabled = False

            ResourceManageViewModel.CreateRevisionEnabled = (ResourceManageViewModel.SaveEnabled = False AndAlso
                                                             ResourceManageViewModel.HasASelectedRevision AndAlso
                                                             ResourceManageViewModel.IsMaxRevisionNumber AndAlso
                                                             ResourceManageViewModel.Approved = False)

            ResourceManageViewModel.DeleteRevisionEnabled = (ResourceManageViewModel.SaveEnabled = False AndAlso
                                                             ResourceManageViewModel.HasASelectedRevision AndAlso
                                                             ResourceManageViewModel.IsMaxRevisionNumber AndAlso
                                                             ResourceManageViewModel.SelectedPlanResourceRevision.RevisionNumber > 0 AndAlso
                                                             ResourceManageViewModel.Approved = False)

        End Sub
        Public Sub ResourceManage_SelectedRowChanged(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel, SelectedRowCount As Integer)

            ResourceManageViewModel.AddDetailsEnabled = (ResourceManageViewModel.HasASelectedRevision AndAlso ResourceManageViewModel.IsMaxRevisionNumber AndAlso ResourceManageViewModel.Approved = False)
            ResourceManageViewModel.DeleteDetailsEnabled = (SelectedRowCount > 0 AndAlso ResourceManageViewModel.HasASelectedRevision AndAlso ResourceManageViewModel.IsMaxRevisionNumber AndAlso ResourceManageViewModel.Approved = False)

        End Sub
        Public Sub ResourceManage_DeleteDetail(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel, RowIndexes() As Integer)

            For Each RowIndex In RowIndexes.OrderByDescending(Function(RI) RI)

                ResourceManageViewModel.DataTable.Rows.RemoveAt(RowIndex)

            Next

            ResourceManage_UserEntryChanged(ResourceManageViewModel)

        End Sub
        Public Sub ResourceManage_ApproveRevision(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResourceRevision = DbContext.RevenueResourcePlanResourceRevisions.Find(ResourceManageViewModel.SelectedPlanResourceRevision.ID)

                RevenueResourcePlanResourceRevision.Approved = True
                RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Me.Session.User.EmployeeCode
                RevenueResourcePlanResourceRevision.ApprovedDate = Now
                RevenueResourcePlanResourceRevision.Notes = String.Empty

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            ResourceManageViewModel.ApproveVisible = False

            ResourceManageViewModel.Approved = RevenueResourcePlanResourceRevision.Approved
            ResourceManageViewModel.SelectedPlanResourceRevision.Approved = RevenueResourcePlanResourceRevision.Approved

            ResourceManageViewModel.ApprovedBy = Me.Session.EmployeeName
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedByEmployee = Me.Session.EmployeeName
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedByEmployeeCode = RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode

            ResourceManageViewModel.ApprovedByDate = RevenueResourcePlanResourceRevision.ApprovedDate.Value.ToShortDateString
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedDate = RevenueResourcePlanResourceRevision.ApprovedDate

        End Sub
        Public Sub ResourceManage_UnapproveRevision(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel)

            'objects
            Dim RevenueResourcePlanResourceRevision As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceRevision = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResourceRevision = DbContext.RevenueResourcePlanResourceRevisions.Find(ResourceManageViewModel.SelectedPlanResourceRevision.ID)

                RevenueResourcePlanResourceRevision.Approved = False
                RevenueResourcePlanResourceRevision.ApprovedByEmployeeCode = Nothing
                RevenueResourcePlanResourceRevision.ApprovedDate = Nothing
                RevenueResourcePlanResourceRevision.Notes = String.Empty

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

            ResourceManageViewModel.ApproveVisible = True

            ResourceManageViewModel.Approved = RevenueResourcePlanResourceRevision.Approved
            ResourceManageViewModel.SelectedPlanResourceRevision.Approved = RevenueResourcePlanResourceRevision.Approved

            ResourceManageViewModel.ApprovedBy = String.Empty
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedByEmployee = String.Empty
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedByEmployeeCode = Nothing

            ResourceManageViewModel.ApprovedByDate = String.Empty
            ResourceManageViewModel.SelectedPlanResourceRevision.ApprovedDate = Nothing

        End Sub
        Public Sub ResourceManage_AllocationPercentageChanged(ByRef ResourceManageViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceManageViewModel,
                                                              RowIndex As Integer)

            'objects
            Dim DataRow As System.Data.DataRow = Nothing

            DataRow = ResourceManageViewModel.DataTable.Rows(RowIndex)

            DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.Hours.ToString) = DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.HoursAvailable.ToString) * DataRow(AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.ResourceDetailColumns.AllocationPercentage.ToString)

        End Sub

#End Region

#Region "  Resource Add Detail"

        Public Function ResourceAddDetail_Load(RevenueResourcePlanID As Integer, RevenueResourcePlanResourceID As Integer, RevenueResourcePlanResourceRevisionID As Integer) As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel

            'objects
            Dim ResourceAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel = Nothing
            Dim RevenueResourcePlan As AdvantageFramework.Database.Entities.RevenueResourcePlan = Nothing
            Dim RevenueResourcePlanResourceDetails As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail) = Nothing

            ResourceAddDetailViewModel = New AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()

                ResourceAddDetailViewModel.RevenueResourcePlanID = RevenueResourcePlanID
                ResourceAddDetailViewModel.RevenueResourcePlanResourceID = RevenueResourcePlanResourceID
                ResourceAddDetailViewModel.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID

                RevenueResourcePlan = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlan).Include("Office").Include("Employee").SingleOrDefault(Function(Entity) Entity.ID = RevenueResourcePlanID)

                ResourceAddDetailViewModel.Plan = New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan(RevenueResourcePlan)

                RevenueResourcePlanResourceDetails = DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail).Where(Function(Entity) Entity.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID).ToList

                ResourceAddDetailViewModel.PlanResourceStaffs = New Generic.List(Of AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff)

                For Each RevenueResourcePlanStaff In DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanStaff).Include("EmployeeTitle").Include("Office").Include("DepartmentTeam").Include("Employee").
                                                               Where(Function(Entity) Entity.RevenueResourcePlanID = RevenueResourcePlanID).ToList

                    If RevenueResourcePlanResourceDetails.Any(Function(Entity) Entity.RevenueResourcePlanStaffID = RevenueResourcePlanStaff.ID) = False Then

                        ResourceAddDetailViewModel.PlanResourceStaffs.Add(New AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.PlanResourceStaff(RevenueResourcePlanStaff))

                    End If

                Next

            End Using

            ResourceAddDetail_Load = ResourceAddDetailViewModel

        End Function
        Public Sub ResourceAddDetail_Add(ByRef ResourceAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel)

            'objects
            Dim RevenueResourcePlanResourceDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail = Nothing
            Dim RevenueResourcePlanResourceRevisionID As Integer = 0
            Dim RevenueResourcePlanResourceDetailDate As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate = Nothing

            Using DbContext = New AdvantageFramework.Database.DbContext(Me.Session.ConnectionString, Me.Session.UserCode)

                DbContext.Database.Connection.Open()
                DbContext.Configuration.AutoDetectChangesEnabled = False

                RevenueResourcePlanResourceRevisionID = ResourceAddDetailViewModel.RevenueResourcePlanResourceRevisionID

                For Each PlanResourceStaff In ResourceAddDetailViewModel.PlanResourceStaffs

                    If PlanResourceStaff.Selected Then

                        If DbContext.GetQuery(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail).Any(Function(Entity) Entity.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID AndAlso
                                                                                                                                              Entity.RevenueResourcePlanStaffID = PlanResourceStaff.ID) = False Then

                            RevenueResourcePlanResourceDetail = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail

                            RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceRevisionID = RevenueResourcePlanResourceRevisionID
                            RevenueResourcePlanResourceDetail.RevenueResourcePlanStaffID = PlanResourceStaff.ID
                            RevenueResourcePlanResourceDetail.Notes = String.Empty

                            DbContext.RevenueResourcePlanResourceDetails.Add(RevenueResourcePlanResourceDetail)

                            For Each DetailDate In GetPlanDates(ResourceAddDetailViewModel.Plan)

                                RevenueResourcePlanResourceDetailDate = New AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate

                                RevenueResourcePlanResourceDetailDate.RevenueResourcePlanResourceDetail = RevenueResourcePlanResourceDetail
                                RevenueResourcePlanResourceDetailDate.Date = DetailDate
                                RevenueResourcePlanResourceDetailDate.Hours = 0

                                DbContext.RevenueResourcePlanResourceDetailDates.Add(RevenueResourcePlanResourceDetailDate)

                            Next

                        End If

                    End If

                Next

                DbContext.Configuration.AutoDetectChangesEnabled = True

                DbContext.SaveChanges()

            End Using

        End Sub
        Public Sub ResourceAddDetail_SelectedChanged(ByRef ResourceAddDetailViewModel As AdvantageFramework.ViewModels.FinanceAndAccounting.RevenueResourcePlan.ResourceAddDetailViewModel)

            If ResourceAddDetailViewModel.PlanResourceStaffs.Any(Function(Entity) Entity.Selected = True) Then

                ResourceAddDetailViewModel.AddEnabled = True

            Else

                ResourceAddDetailViewModel.AddEnabled = False

            End If


        End Sub

#End Region

#End Region

    End Class

End Namespace