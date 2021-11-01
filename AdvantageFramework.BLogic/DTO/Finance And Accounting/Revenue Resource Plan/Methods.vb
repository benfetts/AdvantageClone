Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    <HideModuleName>
    Public Module Methods

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum StaffType As Integer
            Freelance = 1
            FullTime = 2
            PartTime = 3
        End Enum

        Public Enum RevenueType As Integer
            Fee = 1
            Project = 2
            ProductionCommission = 3
            MediaCommission = 4
        End Enum

        Public Enum RevenueStatus As Integer
            Active = 1
            Projected = 2
            Stretch = 3
        End Enum

        Public Enum RevenueDetailColumns As Integer
            ID
            RevenueDetailID
            RevenueTypeID
            RevenueStatusID
            Client
            Division
            Product
            JobNumber
            JobComponentNumber
            JobComponent
            Notes
        End Enum

        Public Enum ResourceDetailColumns As Integer
            ID
            ResourceDetailID
            StaffID
            Title
            Employee
            AllocationPercentage
            Hours
            HoursAvailable
            Cost
            Revenue
            ProfitPercentage
            UtilizationVariance
            Notes
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "



#End Region

#Region " Methods "



#End Region

    End Module

End Namespace

