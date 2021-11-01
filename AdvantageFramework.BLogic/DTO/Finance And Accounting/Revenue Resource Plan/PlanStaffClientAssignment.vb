Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanStaffClientAssignment
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanStaffID
            HoursAvailable
            ClientCode
            Client
            DivisionCode
            Division
            ProductCode
            Product
            Percent
            Hours
            Notes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False)>
        Public Property RevenueResourcePlanStaffID() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n2", ShowColumnInGrid:=False)>
        Public Property HoursAvailable() As Decimal
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ClientCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Client() As String
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property DivisionCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Division() As String
        <Required>
        <MaxLength(6)>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True, ShowColumnInGrid:=False)>
        Public Property ProductCode() As String
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsReadOnlyColumn:=True)>
        Public Property Product() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="p0", MinValue:=0, UseMinValue:=True)>
        Public Property Percent() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, DisplayFormat:="n1", IsReadOnlyColumn:=True)>
        Public Property Hours() As Decimal
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True)>
        Public Property Notes() As String

#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanStaffID = 0
            Me.HoursAvailable = 0
            Me.ClientCode = Nothing
            Me.Client = String.Empty
            Me.DivisionCode = Nothing
            Me.Division = String.Empty
            Me.ProductCode = Nothing
            Me.Product = String.Empty
            Me.Percent = 0
            Me.Hours = 0
            Me.Notes = String.Empty

        End Sub
        Public Sub New(DbContext As AdvantageFramework.Database.DbContext,
                       Plan As AdvantageFramework.DTO.FinanceAndAccounting.RevenueResourcePlan.Plan,
                       RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient)

            'objects
            Dim EmployeeHoursAvailable As Decimal = 0

            Me.ID = RevenueResourcePlanStaffClient.ID
            Me.RevenueResourcePlanStaffID = RevenueResourcePlanStaffClient.RevenueResourcePlanStaffID

            If String.IsNullOrWhiteSpace(RevenueResourcePlanStaffClient.RevenueResourcePlanStaff.EmployeeCode) = False Then

                Try

                    EmployeeHoursAvailable = DbContext.Database.SqlQuery(Of Decimal)(String.Format("EXEC [dbo].[advsp_revenue_resources_load_staff_available_hours] '{0}', '{1}', '{2}'", RevenueResourcePlanStaffClient.RevenueResourcePlanStaff.EmployeeCode, Plan.StartDate.ToShortDateString, Plan.EndDate.ToShortDateString)).FirstOrDefault

                Catch ex As Exception
                    EmployeeHoursAvailable = 0
                End Try

                'EmployeeHoursAvailable = AdvantageFramework.EmployeeUtilities.LoadTotalRequiredHours(DbContext, RevenueResourcePlanStaffClient.RevenueResourcePlanStaff.EmployeeCode)

            Else

                EmployeeHoursAvailable = RevenueResourcePlanStaffClient.RevenueResourcePlanStaff.AltEmployeeMonthlyHours

            End If

            Me.HoursAvailable = EmployeeHoursAvailable
            Me.ClientCode = RevenueResourcePlanStaffClient.ClientCode
            Me.Client = If(RevenueResourcePlanStaffClient.Client IsNot Nothing, RevenueResourcePlanStaffClient.Client.Name, String.Empty)
            Me.DivisionCode = RevenueResourcePlanStaffClient.DivisionCode
            Me.Division = If(RevenueResourcePlanStaffClient.Division IsNot Nothing, RevenueResourcePlanStaffClient.Division.Name, String.Empty)
            Me.ProductCode = RevenueResourcePlanStaffClient.ProductCode
            Me.Product = If(RevenueResourcePlanStaffClient.Product IsNot Nothing, RevenueResourcePlanStaffClient.Product.Name, String.Empty)
            Me.Percent = (RevenueResourcePlanStaffClient.Percent / 100)
            Me.Hours = (EmployeeHoursAvailable * Me.Percent)
            Me.Notes = RevenueResourcePlanStaffClient.Notes

        End Sub
        Public Sub SaveToEntity(ByRef RevenueResourcePlanStaffClient As AdvantageFramework.Database.Entities.RevenueResourcePlanStaffClient)

            RevenueResourcePlanStaffClient.ClientCode = Me.ClientCode
            RevenueResourcePlanStaffClient.DivisionCode = Me.DivisionCode
            RevenueResourcePlanStaffClient.ProductCode = Me.ProductCode
            RevenueResourcePlanStaffClient.Percent = (Me.Percent * 100)
            RevenueResourcePlanStaffClient.Notes = Me.Notes

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
