Namespace DTO.FinanceAndAccounting.RevenueResourcePlan

    Public Class PlanResourceRevisionDetail
        Inherits AdvantageFramework.DTO.BaseClass

#Region " Constants "



#End Region

#Region " Enum "

        Public Enum Properties
            ID
            RevenueResourcePlanResourceID
            RevenueResourcePlanStaffID
            EmployeeTitle
            EmployeeName
            AllocationPercentage
            Hours
            Date1Revenue
            Date1Actual
            Date2Revenue
            Date2Actual
            Date3Revenue
            Date3Actual
            Date4Revenue
            Date4Actual
            Date5Revenue
            Date5Actual
            Date6Revenue
            Date6Actual
            Date7Revenue
            Date7Actual
            Date8Revenue
            Date8Actual
            Date9Revenue
            Date9Actual
            Date10Revenue
            Date10Actual
            Date11Revenue
            Date11Actual
            Date12Revenue
            Date12Actual
        End Enum

#End Region

#Region " Variables "



#End Region

#Region " Properties "

        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property ID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RevenueResourcePlanResourceID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(IsRequired:=True, ShowColumnInGrid:=False, IsReadOnlyColumn:=True)>
        Public Property RevenueResourcePlanStaffID() As Integer
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Title")>
        Public Property EmployeeTitle() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity()>
        Public Property EmployeeName() As String
        <Required>
        <AdvantageFramework.BaseClasses.Attributes.Entity(CustomColumnCaption:="Allocation %", DisplayFormat:="p0")>
        Public Property AllocationPercentage() As Integer
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date1Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date1Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date2Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date2Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date3Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date3Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date4Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date4Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date5Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date5Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date6Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date6Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date7Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date7Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date8Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date8Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date9Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date9Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date10Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date10Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date11Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date11Actual() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1", MinValue:=0, UseMinValue:=True)>
        Public Property Date12Hours() As Decimal
        <AdvantageFramework.BaseClasses.Attributes.Entity(DisplayFormat:="n1")>
        Public Property Date12Actual() As Decimal


#End Region

#Region " Methods "

        Public Sub New()

            Me.ID = 0
            Me.RevenueResourcePlanResourceID = 0
            Me.RevenueResourcePlanStaffID = 0
            Me.EmployeeTitle = String.Empty
            Me.EmployeeName = String.Empty
            Me.AllocationPercentage = 0
            Me.Hours = 0
            Me.Date1Hours = 0
            Me.Date1Actual = 0
            Me.Date2Hours = 0
            Me.Date2Actual = 0
            Me.Date3Hours = 0
            Me.Date3Actual = 0
            Me.Date4Hours = 0
            Me.Date4Actual = 0
            Me.Date5Hours = 0
            Me.Date5Actual = 0
            Me.Date6Hours = 0
            Me.Date6Actual = 0
            Me.Date7Hours = 0
            Me.Date7Actual = 0
            Me.Date8Hours = 0
            Me.Date8Actual = 0
            Me.Date9Hours = 0
            Me.Date9Actual = 0
            Me.Date10Hours = 0
            Me.Date10Actual = 0
            Me.Date11Hours = 0
            Me.Date11Actual = 0
            Me.Date12Hours = 0
            Me.Date12Actual = 0

        End Sub
        Public Sub New(RevenueResourcePlanResourceDetail As AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetail)

            'objects
            Dim RevenueResourcePlanResourceDetailDates As Generic.List(Of AdvantageFramework.Database.Entities.RevenueResourcePlanResourceDetailDate) = Nothing

            Me.ID = RevenueResourcePlanResourceDetail.ID
            Me.RevenueResourcePlanResourceID = RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceRevisionID
            Me.RevenueResourcePlanStaffID = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaffID

            If RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff IsNot Nothing Then

                If RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.EmployeeTitle IsNot Nothing Then

                    Me.EmployeeTitle = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.EmployeeTitle.Description

                Else

                    Me.EmployeeTitle = String.Empty

                End If

                If String.IsNullOrWhiteSpace(RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.EmployeeCode) Then

                    Me.EmployeeName = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.AltEmployeeName

                Else

                    If RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.Employee IsNot Nothing Then

                        Me.EmployeeName = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.Employee.ToString

                    Else

                        Me.EmployeeName = String.Empty

                    End If

                End If

            End If

            'RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.RevenueResourcePlanStaffClients
            'If RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.Any(Function(Entity) Entity.c) Then
            '    Me.AllocationPercentage = RevenueResourcePlanResourceDetail.RevenueResourcePlanStaff.RevenueResourcePlanStaffClients.First.Percent
            'Me.Notes = RevenueResourcePlanResourceDetail.Notes

            If RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates IsNot Nothing AndAlso RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.Count > 0 Then

                RevenueResourcePlanResourceDetailDates = RevenueResourcePlanResourceDetail.RevenueResourcePlanResourceDetailDates.OrderBy(Function(Entity) Entity.Date).ToList

                For Each RevenueResourcePlanResourceDetailDate In RevenueResourcePlanResourceDetailDates

                    Select Case RevenueResourcePlanResourceDetailDates.IndexOf(RevenueResourcePlanResourceDetailDate)

                        Case 1

                            Me.Date1Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date1Actual = 0

                        Case 2

                            Me.Date2Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date2Actual = 0

                        Case 3

                            Me.Date3Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date3Actual = 0

                        Case 4

                            Me.Date4Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date4Actual = 0

                        Case 5

                            Me.Date5Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date5Actual = 0

                        Case 6

                            Me.Date6Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date6Actual = 0

                        Case 7

                            Me.Date7Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date7Actual = 0

                        Case 8

                            Me.Date8Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date8Actual = 0

                        Case 9

                            Me.Date9Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date9Actual = 0

                        Case 10

                            Me.Date10Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date10Actual = 0

                        Case 11

                            Me.Date11Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date11Actual = 0

                        Case 12

                            Me.Date12Hours = RevenueResourcePlanResourceDetailDate.Hours
                            Me.Date12Actual = 0

                    End Select

                Next

            End If

        End Sub
        Public Overrides Function ToString() As String

            ToString = Me.ID.ToString

        End Function

#End Region

    End Class

End Namespace
